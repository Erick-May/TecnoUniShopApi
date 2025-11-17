// --- Archivo: Controllers/CarritoController.cs ---

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims; // Para leer el ID del token
using System.Threading.Tasks;
using TecnoUniShopApi.Data;
using TecnoUniShopApi.DTOs;
using TecnoUniShopApi.Models;

namespace TecnoUniShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Cliente")] // ¡¡BLOQUEADO!! Solo para Clientes
    public class CarritoController : ControllerBase
    {
        private readonly IConfiguration _config;

        public CarritoController(IConfiguration config)
        {
            _config = config;
        }

        #region Helpers
        // --- Metodo para obtener el ID del Cliente desde el Token ---
        private int GetClienteId()
        {
            var idClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (idClaim == null)
            {
                throw new Exception("Token invalido - No se encontro el ID de usuario.");
            }
            return int.Parse(idClaim);
        }

        // --- Metodo para crear el DbContext con la conexion de Cliente ---
        private ApplicationDbContext CrearContextoCliente()
        {
            var connectionString = _config.GetConnectionString("ClienteConnection");
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(connectionString);
            return new ApplicationDbContext(optionsBuilder.Options);
        }
        #endregion


        // --- Endpoint para OBTENER el carrito del cliente ---
        // GET: api/Carrito
        [HttpGet]
        public async Task<ActionResult<CarritoReadDto>> GetMiCarrito()
        {
            using (var context = CrearContextoCliente())
            {
                try
                {
                    var idCliente = GetClienteId();

                    // 1. Buscar el carrito del cliente
                    var carrito = await context.Carritos
                        .Include(c => c.ProductosCarrito)
                            .ThenInclude(pc => pc.Producto)
                        .FirstOrDefaultAsync(c => c.IdCliente == idCliente);

                    // 2. Si no tiene carrito, crear uno vacio
                    if (carrito == null)
                    {
                        carrito = new Carrito
                        {
                            IdCliente = idCliente,
                            FechaAgregado = DateTime.Now,
                            ProductosCarrito = new List<ProductoCarrito>() // Inicializar lista
                        };
                        context.Carritos.Add(carrito);
                        await context.SaveChangesAsync();
                    }

                    // 3. Convertir el carrito a DTO
                    var carritoDto = new CarritoReadDto
                    {
                        IdCarrito = carrito.IdCarrito,
                        Items = carrito.ProductosCarrito.Select(pc => new CarritoItemDto
                        {
                            IdProducto = pc.IdProducto,
                            NombreProducto = (pc.Producto != null) ? pc.Producto.NombreProducto : "Producto no encontrado",
                            Cantidad = pc.CantidadProducto,
                            PrecioUnitario = pc.Precio,
                            SubTotal = pc.CantidadProducto * pc.Precio
                        }).ToList()
                    };

                    carritoDto.Total = carritoDto.Items.Sum(item => item.SubTotal);

                    return Ok(carritoDto);
                }
                catch (Exception ex)
                {
                    // --- ¡¡ARREGLO!! No usamos Forbid(). ---
                    return StatusCode(500, new
                    {
                        Mensaje = "Error interno al obtener el carrito: " + ex.Message,
                        InnerError = ex.InnerException?.Message
                    });
                }
            }
        }


        // --- Endpoint para AGREGAR un item al carrito ---
        // POST: api/Carrito/agregar
        [HttpPost("agregar")]
        public async Task<ActionResult<CarritoReadDto>> AgregarItem([FromBody] CarritoItemCreateDto itemDto)
        {
            using (var context = CrearContextoCliente())
            {
                try
                {
                    var idCliente = GetClienteId();

                    // 1. Buscar el carrito (o crearlo si no existe)
                    var carrito = await context.Carritos
                        .Include(c => c.ProductosCarrito)
                        .FirstOrDefaultAsync(c => c.IdCliente == idCliente);

                    if (carrito == null)
                    {
                        carrito = new Carrito { IdCliente = idCliente, FechaAgregado = DateTime.Now };
                        context.Carritos.Add(carrito);
                        await context.SaveChangesAsync(); // Guardar para obtener IdCarrito
                    }

                    // 2. Buscar el producto en la BD (para stock y precio)
                    var producto = await context.Productos.FindAsync(itemDto.IdProducto);
                    if (producto == null)
                    {
                        return NotFound(new { Mensaje = "Producto no encontrado." });
                    }
                    if (producto.Cantidad < itemDto.Cantidad)
                    {
                        return BadRequest(new { Mensaje = "No hay suficiente stock." });
                    }

                    // 3. Buscar si el item ya existe en el carrito
                    var itemExistente = carrito.ProductosCarrito
                        .FirstOrDefault(pc => pc.IdProducto == itemDto.IdProducto);

                    if (itemExistente != null)
                    {
                        // Si existe, sumar la cantidad
                        itemExistente.CantidadProducto += itemDto.Cantidad;
                    }
                    else
                    {
                        // Si no existe, agregarlo
                        var nuevoItem = new ProductoCarrito
                        {
                            IdCarrito = carrito.IdCarrito,
                            IdProducto = itemDto.IdProducto,
                            CantidadProducto = itemDto.Cantidad,
                            Precio = producto.Precio // Guardamos el precio actual
                        };
                        context.ProductosCarritos.Add(nuevoItem);
                    }

                    // 4. Guardar cambios
                    await context.SaveChangesAsync();

                    // 5. Devolver el carrito actualizado (llamando al otro metodo)
                    return await GetMiCarrito();
                }
                catch (Exception ex)
                {
                    // --- ¡¡ARREGLO!! No usamos Forbid(). ---
                    return StatusCode(500, new
                    {
                        Mensaje = "Error interno al agregar al carrito: " + ex.Message,
                        InnerError = ex.InnerException?.Message
                    });
                }
            }
        }
    }
}