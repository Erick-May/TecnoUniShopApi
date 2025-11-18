using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TecnoUniShopApi.Data;
using TecnoUniShopApi.DTOs;
using TecnoUniShopApi.Models;
using System;

namespace TecnoUniShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductosController : ControllerBase
    {
        private readonly IConfiguration _config;
        public ProductosController(IConfiguration config) { _config = config; }

        #region Helpers
        private ApplicationDbContext CrearContextoSegunRol()
        {
            var rolUsuario = User.FindFirst(ClaimTypes.Role)?.Value;
            string connectionString = "";
            switch (rolUsuario)
            {
                case "Cliente": connectionString = _config.GetConnectionString("ClienteConnection"); break;
                case "Repartidor": connectionString = _config.GetConnectionString("RepartidorConnection"); break;
                case "Contador": connectionString = _config.GetConnectionString("ContadorConnection"); break;
                case "Inventarista": connectionString = _config.GetConnectionString("InventaristaConnection"); break;
                case "Administrador": connectionString = _config.GetConnectionString("AdminConnection"); break;
                default: throw new Exception("Rol de usuario no valido.");
            }
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(connectionString);
            return new ApplicationDbContext(optionsBuilder.Options);
        }

        private int GetEmpleadoId()
        {
            var idClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (idClaim == null)
            {
                throw new Exception("Token invalido - No se encontro el ID de empleado.");
            }
            return int.Parse(idClaim);
        }
        #endregion

        // GET: api/Productos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductoReadDto>>> GetProductos()
        {
            using (var context = CrearContextoSegunRol())
            {
                try
                {
                    var productos = await context.Productos
                        .Include(p => p.Categoria)
                        .Select(p => new ProductoReadDto
                        {
                            IdProducto = p.IdProducto,
                            NombreProducto = p.NombreProducto,
                            Descripcion = p.Descripcion,
                            Precio = p.Precio,
                            Cantidad = p.Cantidad,
                            Estado = p.Estado,
                            Categoria = (p.Categoria != null) ? p.Categoria.NombreCategoria : "N/A"
                        })
                        .ToListAsync();
                    return Ok(productos);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, new
                    {
                        Mensaje = "Error interno al buscar productos: " + ex.Message,
                        InnerError = ex.InnerException?.Message
                    });
                }
            }
        }

        // POST: api/Productos
        [HttpPost]
        [Authorize(Roles = "Administrador, Inventarista")]
        public async Task<ActionResult<ProductoReadDto>> PostProducto([FromBody] ProductoCreateDto productoDto)
        {
            using (var context = CrearContextoSegunRol())
            {
                using (var transaccion = await context.Database.BeginTransactionAsync())
                {
                    try
                    {
                        var empleadoId = GetEmpleadoId();
                        var productoNuevo = new Models.Producto
                        {
                            NombreProducto = productoDto.NombreProducto,
                            Descripcion = productoDto.Descripcion,
                            Precio = productoDto.Precio,
                            Cantidad = productoDto.Cantidad,
                            IdCategoria = productoDto.IdCategoria,
                            Estado = productoDto.Estado,
                            ImagenProducto = productoDto.ImagenProducto
                        };
                        context.Productos.Add(productoNuevo);
                        await context.SaveChangesAsync();

                        var log = new DetalleRegistro
                        {
                            IdAdmin = empleadoId,
                            IdProducto = productoNuevo.IdProducto,
                            FechaRegistro = DateTime.Now
                        };
                        context.DetalleRegistros.Add(log);

                        await context.SaveChangesAsync();
                        await transaccion.CommitAsync();
                    }
                    catch (Exception ex)
                    {
                        await transaccion.RollbackAsync();
                        return BadRequest(new
                        {
                            Mensaje = "Error de base de datos: " + ex.Message,
                            InnerError = ex.InnerException?.Message
                        });
                    }
                }
                return Ok(new { Mensaje = "Producto creado y registrado exitosamente." });
            }
        }

        // PUT: api/Productos/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Administrador, Inventarista")]
        public async Task<IActionResult> PutProducto(int id, [FromBody] ProductoUpdateDto productoDto)
        {
            using (var context = CrearContextoSegunRol())
            {
                using (var transaccion = await context.Database.BeginTransactionAsync())
                {
                    try
                    {
                        var empleadoId = GetEmpleadoId();

                        var productoEnDb = await context.Productos.FindAsync(id);
                        if (productoEnDb == null) { return NotFound(new { Mensaje = "Producto no encontrado." }); }

                        // Copiamos TODOS los campos del DTO
                        productoEnDb.NombreProducto = productoDto.NombreProducto;
                        productoEnDb.Descripcion = productoDto.Descripcion;
                        productoEnDb.Precio = productoDto.Precio;
                        productoEnDb.Cantidad = productoDto.Cantidad;
                        productoEnDb.IdCategoria = productoDto.IdCategoria;
                        productoEnDb.ImagenProducto = productoDto.ImagenProducto;
                        productoEnDb.Estado = productoDto.Estado;

                        // (Logica de la bitacora)
                        var logExistente = await context.DetalleRegistros
                            .FirstOrDefaultAsync(l => l.IdAdmin == empleadoId && l.IdProducto == id);

                        if (logExistente == null)
                        {
                            var log = new DetalleRegistro
                            {
                                IdAdmin = empleadoId,
                                IdProducto = id,
                                FechaRegistro = DateTime.Now
                            };
                            context.DetalleRegistros.Add(log);
                        }
                        else
                        {
                            logExistente.FechaRegistro = DateTime.Now;
                        }

                        await context.SaveChangesAsync();
                        await transaccion.CommitAsync();

                        return Ok(new { Mensaje = "Producto actualizado y registrado." });
                    }
                    catch (Exception ex)
                    {
                        await transaccion.RollbackAsync();
                        return BadRequest(new
                        {
                            Mensaje = "Error de base de datos: " + ex.Message,
                            InnerError = ex.InnerException?.Message
                        });
                    }
                }
            }
        }

        // --- ¡¡AQUI ESTA EL CAMBIO!! ---
        // DELETE: api/Productos/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrador, Inventarista")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            // Esta funcion ya no borra, solo marca como "Agotado"
            using (var context = CrearContextoSegunRol())
            {
                using (var transaccion = await context.Database.BeginTransactionAsync())
                {
                    try
                    {
                        var empleadoId = GetEmpleadoId();
                        var productoEnDb = await context.Productos.FindAsync(id);
                        if (productoEnDb == null) { return NotFound(new { Mensaje = "Producto no encontrado." }); }

                        // --- ¡¡NUEVA LOGICA!! ---
                        // No borramos, solo cambiamos el estado.
                        productoEnDb.Estado = "Agotado";
                        productoEnDb.Cantidad = 0; // Opcional: poner el stock en 0

                        // --- Logica de la bitacora (igual que en PUT) ---
                        var logExistente = await context.DetalleRegistros
                            .FirstOrDefaultAsync(l => l.IdAdmin == empleadoId && l.IdProducto == id);

                        if (logExistente == null)
                        {
                            var log = new DetalleRegistro
                            {
                                IdAdmin = empleadoId,
                                IdProducto = id,
                                FechaRegistro = DateTime.Now
                            };
                            context.DetalleRegistros.Add(log);
                        }
                        else
                        {
                            logExistente.FechaRegistro = DateTime.Now; // Actualiza la fecha del log
                        }

                        await context.SaveChangesAsync();
                        await transaccion.CommitAsync();

                        return Ok(new { Mensaje = "Producto marcado como Agotado." });
                    }
                    catch (Exception ex)
                    {
                        await transaccion.RollbackAsync();
                        return BadRequest(new
                        {
                            Mensaje = "Error de base de datos: " + ex.Message,
                            InnerError = ex.InnerException?.Message
                        });
                    }
                }
            }
        }
    }
}