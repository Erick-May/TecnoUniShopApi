using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TecnoUniShopApi.Data;
using TecnoUniShopApi.DTOs;
using TecnoUniShopApi.Models; // ¡Asegurate de tener este!
using System; // ¡¡Y este, para el DateTime.Now!!

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

        // --- ¡¡NUEVO HELPER!! ---
        // Para obtener el ID del Admin/Inventarista desde el Token
        private int GetEmpleadoId()
        {
            // Leemos el claim "sub" (Subject) que guardamos en el Login
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
            // ... (Este metodo se queda igual, no necesita cambios)
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
                // --- ¡¡CAMBIO!! Usamos transaccion por si falla el log ---
                using (var transaccion = await context.Database.BeginTransactionAsync())
                {
                    try
                    {
                        // 1. Obtenemos el ID del empleado que esta haciendo esto
                        var empleadoId = GetEmpleadoId();

                        // 2. Creamos el producto
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
                        await context.SaveChangesAsync(); // Guardamos para tener el ID

                        // 3. --- ¡¡LOGICA NUEVA!! ---
                        // Creamos el registro en la bitacora
                        var log = new DetalleRegistro
                        {
                            IdAdmin = empleadoId,
                            IdProducto = productoNuevo.IdProducto, // Usamos el ID nuevo
                            FechaRegistro = DateTime.Now
                        };
                        context.DetalleRegistros.Add(log);

                        // 4. Guardamos el log
                        await context.SaveChangesAsync();
                        await transaccion.CommitAsync(); // Confirmamos todo
                    }
                    catch (Exception ex)
                    {
                        await transaccion.RollbackAsync(); // Deshacemos todo si falla
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

                        // Actualizamos el producto
                        productoEnDb.NombreProducto = productoDto.NombreProducto;
                        productoEnDb.Descripcion = productoDto.Descripcion;
                        // ... (resto de campos)
                        productoEnDb.Estado = productoDto.Estado;

                        // --- ¡¡LOGICA NUEVA!! ---
                        // Creamos el registro en la bitacora
                        // (Nota: Tu BD solo permite un registro por admin-producto)
                        // (Vamos a buscar si ya existe y si no, lo creamos)
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
                            // Si ya existia, solo actualizamos la fecha
                            logExistente.FechaRegistro = DateTime.Now;
                        }

                        await context.SaveChangesAsync();
                        await transaccion.CommitAsync(); // Confirmamos todo

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

        // DELETE: api/Productos/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrador, Inventarista")]
        public async Task<IActionResult> DeleteProducto(int id)
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

                        // --- ¡¡LOGICA NUEVA!! ---
                        // Antes de borrar el producto, borramos los logs asociados
                        // (Porque si no, SQL Server fallara por la FK)
                        var logs = context.DetalleRegistros.Where(l => l.IdProducto == id);
                        context.DetalleRegistros.RemoveRange(logs);

                        // (Tambien habria que borrarlo de Productos_carrito, etc...)
                        // (Por ahora solo borramos el log y el producto)

                        context.Productos.Remove(productoEnDb);
                        await context.SaveChangesAsync();
                        await transaccion.CommitAsync();

                        return Ok(new { Mensaje = "Producto eliminado." });
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
} //hola