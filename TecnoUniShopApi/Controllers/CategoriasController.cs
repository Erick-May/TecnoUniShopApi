using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TecnoUniShopApi.Data;
using TecnoUniShopApi.DTOs;

namespace TecnoUniShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // Cualquier usuario logueado puede ver las categorias
    public class CategoriasController : ControllerBase
    {
        private readonly IConfiguration _config;

        public CategoriasController(IConfiguration config)
        {
            _config = config;
        }

        // Usamos la conexion de Cliente (es suficiente, solo es lectura)
        private ApplicationDbContext CrearContexto()
        {
            var connectionString = _config.GetConnectionString("ClienteConnection");
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(connectionString);
            return new ApplicationDbContext(optionsBuilder.Options);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaReadDto>>> GetCategorias()
        {
            using (var context = CrearContexto())
            {
                var categorias = await context.Categorias
                    .Select(c => new CategoriaReadDto
                    {
                        IdCategoria = c.IdCategoria,
                        NombreCategoria = c.NombreCategoria,
                        Descripcion = c.Descripcion
                    })
                    .ToListAsync();

                return Ok(categorias);
            }
        }
    }
}