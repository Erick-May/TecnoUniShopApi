// --- Archivo: Controllers/PedidosController.cs ---

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TecnoUniShopApi.Data;
using TecnoUniShopApi.DTOs;
using TecnoUniShopApi.Models;

namespace TecnoUniShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PedidosController : ControllerBase
    {
        private readonly IConfiguration _config;

        public PedidosController(IConfiguration config)
        {
            _config = config;
        }

        #region Helpers
        private int GetClienteId()
        {
            var idClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (idClaim == null) { throw new Exception("Token invalido - No se encontro el ID de usuario."); }
            return int.Parse(idClaim);
        }
        private ApplicationDbContext CrearContextoCliente()
        {
            var connectionString = _config.GetConnectionString("ClienteConnection");
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(connectionString);
            return new ApplicationDbContext(optionsBuilder.Options);
        }
        private ApplicationDbContext CrearContextoRepartidor()
        {
            var connectionString = _config.GetConnectionString("RepartidorConnection");
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(connectionString);
            return new ApplicationDbContext(optionsBuilder.Options);
        }
        #endregion

        // --- Endpoint para CREAR EL PEDIDO (Checkout) ---
        [HttpPost("crear")]
        [Authorize(Roles = "Cliente")]
        public async Task<ActionResult<PedidoReadDto>> CrearPedido([FromBody] PedidoCreateDto pedidoDto)
        {
            var idCliente = GetClienteId();
            using (var context = CrearContextoCliente())
            {
                using (var transaccion = await context.Database.BeginTransactionAsync())
                {
                    try
                    {
                        var carrito = await context.Carritos
                            .Include(c => c.ProductosCarrito)
                            .FirstOrDefaultAsync(c => c.IdCliente == idCliente);

                        if (carrito == null || !carrito.ProductosCarrito.Any())
                        {
                            return BadRequest(new { Mensaje = "Tu carrito esta vacio." });
                        }

                        var repartidor = await context.Repartidores.FirstOrDefaultAsync();
                        if (repartidor == null)
                        {
                            return BadRequest(new { Mensaje = "No hay repartidores disponibles." });
                        }

                        decimal totalPedido = 0;
                        foreach (var item in carrito.ProductosCarrito)
                        {
                            var productoEnDb = await context.Productos.FindAsync(item.IdProducto);
                            if (productoEnDb == null) { throw new Exception($"Producto ID {item.IdProducto} no existe."); }
                            if (productoEnDb.Cantidad < item.CantidadProducto) { throw new Exception($"No hay stock suficiente para {productoEnDb.NombreProducto}"); }

                            productoEnDb.Cantidad -= item.CantidadProducto;
                            totalPedido += item.Precio * item.CantidadProducto;
                        }
                        await context.SaveChangesAsync();


                        var nuevoPedido = new Pedido
                        {
                            IdCliente = idCliente,
                            IdRepartidor = repartidor.IdRepartidor,
                            FechaPedido = DateTime.Now,
                            EstadoPedido = "En Proceso",
                            TotalPedido = totalPedido
                        };
                        context.Pedidos.Add(nuevoPedido);
                        await context.SaveChangesAsync();

                        var itemsParaDto = new List<CarritoItemDto>();
                        foreach (var item in carrito.ProductosCarrito)
                        {
                            var detalle = new DetallePedido
                            {
                                IdPedido = nuevoPedido.IdPedido,
                                IdProducto = item.IdProducto,
                                EstadoProducto = "Sin Entregar"
                            };
                            context.DetallesPedidos.Add(detalle);

                            itemsParaDto.Add(new CarritoItemDto
                            {
                                IdProducto = item.IdProducto,
                                Cantidad = item.CantidadProducto,
                                PrecioUnitario = item.Precio,
                                SubTotal = item.Precio * item.CantidadProducto
                            });
                        }

                        var nuevaFactura = new Factura
                        {
                            IdPedido = nuevoPedido.IdPedido,
                            FechaEmision = DateTime.Now,
                            MetodoPago = pedidoDto.MetodoPago,
                            MontoTotal = totalPedido
                        };
                        context.Facturas.Add(nuevaFactura);
                        await context.SaveChangesAsync();

                        foreach (var item in carrito.ProductosCarrito)
                        {
                            var detalleFactura = new DetalleFactura
                            {
                                IdFactura = nuevaFactura.IdFactura,
                                IdProducto = item.IdProducto,
                                Cantidad = item.CantidadProducto,
                                PrecioUnitario = item.Precio
                            };
                            context.DetallesFacturas.Add(detalleFactura);
                        }

                        var itemsCarrito = context.ProductosCarritos
                            .Where(pc => pc.IdCarrito == carrito.IdCarrito);
                        context.ProductosCarritos.RemoveRange(itemsCarrito);

                        await context.SaveChangesAsync();
                        await transaccion.CommitAsync();

                        var pedidoDtoRespuesta = new PedidoReadDto
                        {
                            IdPedido = nuevoPedido.IdPedido,
                            IdFactura = nuevaFactura.IdFactura,
                            FechaPedido = nuevoPedido.FechaPedido,
                            EstadoPedido = nuevoPedido.EstadoPedido,
                            TotalPedido = nuevoPedido.TotalPedido,
                            MetodoPago = nuevaFactura.MetodoPago,
                            Items = itemsParaDto
                        };

                        return Ok(pedidoDtoRespuesta);
                    }
                    catch (Exception ex)
                    {
                        await transaccion.RollbackAsync();
                        return StatusCode(500, new
                        {
                            Mensaje = "Error interno al crear el pedido: " + ex.Message,
                            InnerError = ex.InnerException?.Message
                        });
                    }
                }
            }
        }

        // --- ENDPOINTS PARA REPARTIDOR ---

        // GET: api/Pedidos/disponibles
        [HttpGet("disponibles")]
        [Authorize(Roles = "Repartidor, Administrador")]
        public async Task<ActionResult<IEnumerable<PedidoRepartidorDto>>> GetPedidosDisponibles()
        {
            using (var context = CrearContextoRepartidor())
            {
                try
                {
                    var pedidos = await context.Pedidos
                        .Where(p => p.EstadoPedido == "En Proceso")
                        // --- ¡¡ARREGLO!! ---
                        // Quitamos los 'Include' y dejamos que el 'Select'
                        // haga los JOINs de forma segura.
                        .Select(p => new PedidoRepartidorDto
                        {
                            IdPedido = p.IdPedido,
                            FechaPedido = p.FechaPedido,
                            EstadoPedido = p.EstadoPedido,
                            TotalPedido = p.TotalPedido,
                            NombreCliente = (p.Cliente != null) ? p.Cliente.Nombre : "N/A",
                            TelefonoCliente = (p.Cliente != null) ? p.Cliente.Telefono : "N/A",
                            Ciudad = (p.Cliente != null && p.Cliente.Direccion != null) ? p.Cliente.Direccion.Ciudad : "N/A",
                            Barrio = (p.Cliente != null && p.Cliente.Direccion != null) ? p.Cliente.Direccion.Barrio : "N/A"
                        })
                        .ToListAsync();

                    return Ok(pedidos);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, new
                    {
                        Mensaje = "Error interno al buscar pedidos: " + ex.Message,
                        InnerError = ex.InnerException?.Message
                    });
                }
            }
        }

        // PUT: api/Pedidos/entregar/5
        [HttpPut("entregar/{id}")]
        [Authorize(Roles = "Repartidor, Administrador")]
        public async Task<IActionResult> MarcarComoEntregado(int id)
        {
            using (var context = CrearContextoRepartidor())
            {
                try
                {
                    var pedido = await context.Pedidos.FindAsync(id);

                    if (pedido == null)
                    {
                        return NotFound(new { Mensaje = "Pedido no encontrado." });
                    }

                    pedido.EstadoPedido = "Entregado";

                    var detalles = await context.DetallesPedidos
                                        .Where(d => d.IdPedido == id)
                                        .ToListAsync();

                    foreach (var detalle in detalles)
                    {
                        detalle.EstadoProducto = "Entregado";
                    }

                    await context.SaveChangesAsync();

                    return Ok(new { Mensaje = "Pedido marcado como Entregado." });
                }
                catch (Exception ex)
                {
                    return StatusCode(500, new
                    {
                        Mensaje = "Error interno al marcar como entregado: " + ex.Message,
                        InnerError = ex.InnerException?.Message
                    });
                }
            }
        }
    }
}