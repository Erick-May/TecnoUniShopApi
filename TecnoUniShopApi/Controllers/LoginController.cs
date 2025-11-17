// --- Archivo: Controllers/LoginController.cs ---

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using TecnoUniShopApi.Data;   // Tu namespace
using TecnoUniShopApi.DTOs; // Tu namespace
using TecnoUniShopApi.Models; // Tu namespace
using Microsoft.AspNetCore.Authorization; // Para [AllowAnonymous]

namespace TecnoUniShopApi.Controllers // Tu namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _config;

        public LoginController(IConfiguration config)
        {
            _config = config;
        }

        // --- El metodo para hacer HASH de la contrasena ---
        private byte[] ObtenerSha256(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
            }
        }

        // --- El metodo para comparar los hashes ---
        private bool CompararHashes(byte[] hash1, byte[] hash2)
        {
            if (hash1 == null || hash2 == null)
            {
                return false;
            }
            if (hash1.Length != hash2.Length)
            {
                return false;
            }
            for (int i = 0; i < hash1.Length; i++)
            {
                if (hash1[i] != hash2[i])
                {
                    return false;
                }
            }
            return true;
        }


        [HttpPost("autenticar")]
        [AllowAnonymous] // ¡¡Para que no pida token!!
        public async Task<ActionResult<LoginResponseDto>> Autenticar([FromBody] LoginRequestDto login)
        {
            // 1. Crear el DbContext usando la CONEXION DE ADMIN
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

            optionsBuilder.UseSqlServer(_config.GetConnectionString("AdminConnection"));

            using (var context = new ApplicationDbContext(optionsBuilder.Options))
            {
                // 2. Hashear la contrasena que envio el usuario
                var passwordHash = ObtenerSha256(login.Password);

                string rol = "";
                int idUsuario = 0;

                // 3. --- ¡¡AQUI ESTA EL CAMBIO!! ---
                // Buscar en la tabla de staff (Administrador, Inventarista, Contador)
                var admin = await context.Administradores
                                .FirstOrDefaultAsync(a => a.Email == login.Email);

                if (admin != null)
                {
                    if (CompararHashes(admin.Contrasena, passwordHash))
                    {
                        // ¡Leemos el ROL desde la BD!
                        rol = admin.Rol;
                        idUsuario = admin.IdAdmin;
                    }
                }

                // 4. Si no es staff, buscar en Clientes
                if (string.IsNullOrEmpty(rol))
                {
                    var cliente = await context.Clientes
                                    .FirstOrDefaultAsync(c => c.Email == login.Email);

                    if (cliente != null)
                    {
                        if (CompararHashes(cliente.Contrasena, passwordHash))
                        {
                            rol = "Cliente";
                            idUsuario = cliente.IdCliente;
                        }
                    }
                }

                // 5. Si no es staff ni cliente, buscar en Repartidores
                if (string.IsNullOrEmpty(rol))
                {
                    var repartidor = await context.Repartidores
                                        .FirstOrDefaultAsync(r => r.Email == login.Email);

                    if (repartidor != null)
                    {
                        if (CompararHashes(repartidor.Contrasenia, passwordHash))
                        {
                            rol = "Repartidor";
                            idUsuario = repartidor.IdRepartidor;
                        }
                    }
                }

                // 6. (Ya no se necesita este paso, el paso 3 lo maneja)


                // 7. Si no encontramos a nadie
                if (string.IsNullOrEmpty(rol))
                {
                    return Ok(new LoginResponseDto
                    {
                        Exitoso = false,
                        Mensaje = "Email o contrasena incorrectos."
                    });
                }

                // 8. Si encontramos a alguien, ¡generamos el token!
                var token = GenerarToken(idUsuario.ToString(), rol);

                return Ok(new LoginResponseDto
                {
                    Exitoso = true,
                    Mensaje = "Login exitoso",
                    Token = token,
                    Rol = rol
                });
            }
        }


        private string GenerarToken(string idUsuario, string rol)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, idUsuario), // El ID del usuario
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), // Un ID unico para el token
                new Claim(ClaimTypes.Role, rol) // ¡El ROL!
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_config["Jwt:ExpireMinutes"])),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}