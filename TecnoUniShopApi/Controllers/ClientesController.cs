using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography; // Para SHA256
using System.Text;
using TecnoUniShopApi.Data;
using TecnoUniShopApi.DTOs;
using TecnoUniShopApi.Models; // Para los modelos

namespace TecnoUniShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IConfiguration _config;

        public ClientesController(IConfiguration config)
        {
            _config = config;
        }

        // --- Metodo privado para hashear la contrasena ---
        private byte[] ObtenerSha256(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
            }
        }


        // POST: api/Clientes/registrar
        [HttpPost("registrar")]
        [AllowAnonymous]
        public async Task<IActionResult> RegistrarCliente([FromBody] ClienteCreateDto clienteDto)
        {
            // Usamos la AdminConnection
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(_config.GetConnectionString("AdminConnection"));

            using (var context = new ApplicationDbContext(optionsBuilder.Options))
            {
                // 1. Revisar si el email ya existe
                if (await context.Clientes.AnyAsync(c => c.Email == clienteDto.Email))
                {
                    return BadRequest(new { Mensaje = "El email ya esta registrado." });
                }

                // 2. Revisar si el telefono ya existe (Lo agrego por si acaso)
                if (await context.Clientes.AnyAsync(c => c.Telefono == clienteDto.Telefono))
                {
                    return BadRequest(new { Mensaje = "El telefono ya esta registrado." });
                }


                // --- ¡¡AQUI ESTA EL ARREGLO!! ---

                // 3. Crear la NUEVA Direccion (sin guardarla aun)
                var nuevaDireccion = new Direccion
                {
                    Ciudad = clienteDto.Ciudad,
                    Barrio = clienteDto.Barrio
                };

                // 4. Hashear la contrasena
                var passwordHash = ObtenerSha256(clienteDto.Password);

                // 5. Crear el NUEVO Cliente
                var nuevoCliente = new Cliente
                {
                    Nombre = clienteDto.Nombre,
                    Email = clienteDto.Email,
                    Contrasena = passwordHash,
                    Telefono = clienteDto.Telefono,

                    // 6. ¡LA MAGIA! Solo le asignamos el objeto de la direccion
                    Direccion = nuevaDireccion
                    // Ya NO necesitamos el 'IdDireccion'
                };

                // 7. Guardar TODO de un solo golpe
                // EF Core es lo suficientemente inteligente para:
                // a. Insertar la 'nuevaDireccion'
                // b. Obtener el 'id_direccion' nuevo
                // c. Insertar el 'nuevoCliente' con ese 'id_direccion'
                // Todo en una sola transaccion.
                try
                {
                    context.Clientes.Add(nuevoCliente);
                    await context.SaveChangesAsync(); // ¡¡Solo un SaveChanges!!

                    return Ok(new { Mensaje = "Cliente registrado exitosamente." });
                }
                catch (Exception ex)
                {
                    // Si algo falla (como un telefono duplicado que no vimos)
                    // nos dara el error real
                    var innerException = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                    return BadRequest(new
                    {
                        Mensaje = "Error al registrar: " + innerException
                    });
                }
            }
        }
    }
}