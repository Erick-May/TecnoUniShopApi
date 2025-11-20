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
                        var itemsParaDto = new List<CarritoItemDto>();

                        foreach (var item in carrito.ProductosCarrito)
                        {
                            var productoEnDb = await context.Productos.FindAsync(item.IdProducto);
                            if (productoEnDb == null) { throw new Exception($"Producto ID {item.IdProducto} no existe."); }
                            if (productoEnDb.Cantidad < item.CantidadProducto) { throw new Exception($"No hay stock suficiente para {productoEnDb.NombreProducto}"); }

                            productoEnDb.Cantidad -= item.CantidadProducto;
                            totalPedido += item.Precio * item.CantidadProducto;

                            itemsParaDto.Add(new CarritoItemDto
                            {
                                IdProducto = item.IdProducto,
                                NombreProducto = productoEnDb.NombreProducto,
                                Cantidad = item.CantidadProducto,
                                PrecioUnitario = item.Precio,
                                SubTotal = item.Precio * item.CantidadProducto
                            });
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

                        foreach (var item in carrito.ProductosCarrito)
                        {
                            var detalle = new DetallePedido
                            {
                                IdPedido = nuevoPedido.IdPedido,
                                IdProducto = item.IdProducto,
                                EstadoProducto = "Sin Entregar"
                            };
                            context.DetallesPedidos.Add(detalle);
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
                        // --- ¡¡AQUI ESTA EL ARREGLO!! ---
                        // Solo cambiamos a "Entregado" si NO ha sido devuelto
                        if (detalle.EstadoProducto != "Devuelto" && detalle.EstadoProducto != "Cancelado")
                        {
                            detalle.EstadoProducto = "Entregado";
                        }
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

        // --- ENDPOINTS DE CANCELACION ---

        [HttpPut("{idPedido}/cancelarProducto/{idProducto}")]
        [Authorize(Roles = "Cliente, Administrador")]
        public async Task<IActionResult> CancelarProductoDePedido(int idPedido, int idProducto)
        {
            using (var context = CrearContextoCliente())
            {
                var idCliente = GetClienteId();

                using (var transaccion = await context.Database.BeginTransactionAsync())
                {
                    try
                    {
                        var pedido = await context.Pedidos.FirstOrDefaultAsync(p => p.IdPedido == idPedido && p.IdCliente == idCliente);
                        if (pedido == null) { return NotFound(new { Mensaje = "Pedido no encontrado o no le pertenece." }); }

                        var detallePedido = await context.DetallesPedidos
                            .FirstOrDefaultAsync(dp => dp.IdPedido == idPedido && dp.IdProducto == idProducto);

                        if (detallePedido == null) { return NotFound(new { Mensaje = "Producto no encontrado en este pedido." }); }

                        if (detallePedido.EstadoProducto == "Entregado") { return BadRequest(new { Mensaje = "No se puede cancelar un producto que ya fue entregado." }); }
                        if (detallePedido.EstadoProducto == "Devuelto") { return BadRequest(new { Mensaje = "Este producto ya fue devuelto/cancelado." }); }

                        var factura = await context.Facturas
                            .Include(f => f.DetallesFactura)
                            .FirstOrDefaultAsync(f => f.IdPedido == idPedido);

                        if (factura == null) { throw new Exception("Error critico: El pedido no tiene factura asociada."); }

                        var detalleFactura = factura.DetallesFactura
                            .FirstOrDefault(df => df.IdProducto == idProducto);

                        if (detalleFactura == null) { throw new Exception("Error critico: El pedido no tiene este producto en la factura."); }

                        var producto = await context.Productos.FindAsync(idProducto);
                        if (producto == null) { throw new Exception($"Producto ID {idProducto} no existe en el catalogo."); }

                        var cantidadDevuelta = detalleFactura.Cantidad;
                        var subtotalDevuelto = detalleFactura.PrecioUnitario * detalleFactura.Cantidad;

                        producto.Cantidad += cantidadDevuelta;
                        pedido.TotalPedido -= subtotalDevuelto;
                        factura.MontoTotal -= subtotalDevuelto;

                        detallePedido.EstadoProducto = "Devuelto";

                        await context.SaveChangesAsync();
                        await transaccion.CommitAsync();

                        return Ok(new { Mensaje = $"Producto ID {idProducto} cancelado del pedido {idPedido}." });
                    }
                    catch (Exception ex)
                    {
                        await transaccion.RollbackAsync();
                        return StatusCode(500, new
                        {
                            Mensaje = "Error interno al cancelar el producto: " + ex.Message,
                            InnerError = ex.InnerException?.Message
                        });
                    }
                }
            }
        }

        // --- NUEVO: VER MIS PEDIDOS (HISTORIAL) ---
        [HttpGet("mis-pedidos")]
        [Authorize(Roles = "Cliente")]
        public async Task<ActionResult<IEnumerable<PedidoReadDto>>> GetMisPedidos()
        {
            var idCliente = GetClienteId();
            using (var context = CrearContextoCliente())
            {
                try
                {
                    var pedidos = await context.Pedidos
                        .Where(p => p.IdCliente == idCliente)
                        .OrderByDescending(p => p.FechaPedido)
                        .ToListAsync();

                    var listaPedidosDto = new List<PedidoReadDto>();

                    foreach (var pedido in pedidos)
                    {
                        var factura = await context.Facturas
                            .Include(f => f.DetallesFactura)
                                .ThenInclude(df => df.Producto)
                            .FirstOrDefaultAsync(f => f.IdPedido == pedido.IdPedido);

                        var itemsDto = new List<CarritoItemDto>();
                        string metodoPago = "N/A";
                        int idFactura = 0;

                        if (factura != null)
                        {
                            metodoPago = factura.MetodoPago;
                            idFactura = factura.IdFactura;

                            itemsDto = factura.DetallesFactura.Select(df => new CarritoItemDto
                            {
                                IdProducto = df.IdProducto,
                                NombreProducto = (df.Producto != null) ? df.Producto.NombreProducto : "Producto borrado",
                                Cantidad = df.Cantidad,
                                PrecioUnitario = df.PrecioUnitario,
                                SubTotal = df.Cantidad * df.PrecioUnitario,

                                // Buscamos el estado para mostrarlo en el grid
                                Estado = context.DetallesPedidos
                                            .Where(dp => dp.IdPedido == pedido.IdPedido && dp.IdProducto == df.IdProducto)
                                            .Select(dp => dp.EstadoProducto)
                                            .FirstOrDefault() ?? "Desconocido"
                            }).ToList();
                        }

                        listaPedidosDto.Add(new PedidoReadDto
                        {
                            IdPedido = pedido.IdPedido,
                            IdFactura = idFactura,
                            FechaPedido = pedido.FechaPedido,
                            EstadoPedido = pedido.EstadoPedido,
                            TotalPedido = pedido.TotalPedido,
                            MetodoPago = metodoPago,
                            Items = itemsDto
                        });
                    }

                    return Ok(listaPedidosDto);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, new { Mensaje = "Error al cargar historial: " + ex.Message });
                }
            }
        }

        [HttpPut("{id}/cancelar")]
        [Authorize(Roles = "Cliente, Administrador")]
        public async Task<IActionResult> CancelarPedidoCompleto(int id)
        {
            using (var context = CrearContextoCliente())
            {
                var idCliente = GetClienteId();

                using (var transaccion = await context.Database.BeginTransactionAsync())
                {
                    try
                    {
                        var pedido = await context.Pedidos.FirstOrDefaultAsync(p => p.IdPedido == id && p.IdCliente == idCliente);
                        if (pedido == null) { return NotFound(new { Mensaje = "Pedido no encontrado o no le pertenece." }); }

                        if (pedido.EstadoPedido == "Entregado") { return BadRequest(new { Mensaje = "No se puede cancelar un pedido que ya fue entregado." }); }
                        if (pedido.EstadoPedido == "Cancelado") { return BadRequest(new { Mensaje = "Este pedido ya fue cancelado." }); }

                        var factura = await context.Facturas
                            .Include(f => f.DetallesFactura)
                            .FirstOrDefaultAsync(f => f.IdPedido == id);

                        if (factura != null && factura.DetallesFactura != null)
                        {
                            foreach (var detalleFactura in factura.DetallesFactura)
                            {
                                var producto = await context.Productos.FindAsync(detalleFactura.IdProducto);
                                if (producto != null)
                                {
                                    producto.Cantidad += detalleFactura.Cantidad;
                                }
                            }
                        }

                        pedido.EstadoPedido = "Cancelado";

                        var detallesPedido = await context.DetallesPedidos
                                                .Where(dp => dp.IdPedido == id)
                                                .ToListAsync();

                        foreach (var detalle in detallesPedido)
                        {
                            detalle.EstadoProducto = "Devuelto";
                        }

                        await context.SaveChangesAsync();
                        await transaccion.CommitAsync();

                        return Ok(new { Mensaje = $"Pedido ID {id} ha sido cancelado." });
                    }
                    catch (Exception ex)
                    {
                        await transaccion.RollbackAsync();
                        return StatusCode(500, new
                        {
                            Mensaje = "Error interno al cancelar el pedido: " + ex.Message,
                            InnerError = ex.InnerException?.Message
                        });
                    }
                }
            }
        }
    }
}