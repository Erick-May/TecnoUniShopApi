using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecnoUniShopApi.Data;
using TecnoUniShopApi.DTOs;
using TecnoUniShopApi.Models; // ¡¡ASEGURATE DE TENER ESTE!!

namespace TecnoUniShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Contador, Administrador")]
    public class FacturasController : ControllerBase
    {
        private readonly IConfiguration _config;

        public FacturasController(IConfiguration config)
        {
            _config = config;
        }

        // --- HELPER para la conexion del Contador ---
        private ApplicationDbContext CrearContextoContador()
        {
            var connectionString = _config.GetConnectionString("ContadorConnection");
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(connectionString);
            return new ApplicationDbContext(optionsBuilder.Options);
        }


        // GET: api/Facturas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FacturaReadDto>>> GetFacturas()
        {
            using (var context = CrearContextoContador())
            {
                try
                {
                    // 1. Buscamos las facturas
                    var facturas = await context.Facturas
                        .Include(f => f.DetallesFactura)
                            .ThenInclude(df => df.Producto)
                        .Select(f => new FacturaReadDto
                        {
                            IdFactura = f.IdFactura,
                            IdPedido = f.IdPedido,
                            FechaEmision = f.FechaEmision, // Ya no es nulo
                            MetodoPago = f.MetodoPago,
                            MontoTotal = f.MontoTotal,
                            Detalles = f.DetallesFactura.Select(df => new DetalleFacturaReadDto
                            {
                                IdProducto = df.IdProducto,
                                NombreProducto = (df.Producto != null) ? df.Producto.NombreProducto : "N/A",
                                Cantidad = df.Cantidad,
                                PrecioUnitario = df.PrecioUnitario,
                                Subtotal = df.Cantidad * df.PrecioUnitario
                            }).ToList()
                        })
                        .ToListAsync();

                    return Ok(facturas);
                }
                catch (Exception ex)
                {
                    // --- ¡¡ARREGLO!! No usamos Forbid(). ---
                    return StatusCode(500, new
                    {
                        Mensaje = "Error interno al buscar facturas: " + ex.Message,
                        InnerError = ex.InnerException?.Message
                    });
                }
            }
        }
    }
}