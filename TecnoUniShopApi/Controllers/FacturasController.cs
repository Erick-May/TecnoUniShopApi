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

        // GET: api/Facturas/reporte-ventas
        [HttpGet("reporte-ventas")]
        public async Task<ActionResult<IEnumerable<ReporteVentasDto>>> GetReporteVentas()
        {
            using (var context = CrearContextoContador())
            {
                try
                {
                    // Llamada al SP usando SQL Raw
                    // Nota: EF Core requiere una clase 'Keyless' para esto, 
                    // pero para hacerlo rapido haremos una proyeccion manual o usamos un truco.

                    // TRUCO RAPIDO: Usar Database.GetDbConnection
                    var lista = new List<ReporteVentasDto>();
                    var conn = context.Database.GetDbConnection();
                    await conn.OpenAsync();

                    using (var command = conn.CreateCommand())
                    {
                        command.CommandText = "EXEC sp_ReporteProductosMasVendidos";
                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                lista.Add(new ReporteVentasDto
                                {
                                    Producto = reader.GetString(0),
                                    TotalVendido = reader.GetInt32(1)
                                });
                            }
                        }
                    }
                    return Ok(lista);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, new { Mensaje = "Error en reporte: " + ex.Message });
                }
            }
        }

        // GET: api/Facturas/reporte-rango?inicio=2025-01-01&fin=2025-12-31
        [HttpGet("reporte-rango")]
        public async Task<ActionResult<IEnumerable<ReporteVentasDto>>> GetReporteRango(DateTime inicio, DateTime fin)
        {
            using (var context = CrearContextoContador())
            {
                try
                {
                    var lista = new List<ReporteVentasDto>();
                    var conn = context.Database.GetDbConnection();
                    await conn.OpenAsync();

                    using (var command = conn.CreateCommand())
                    {
                        // Pasamos las fechas formateadas
                        string fechaIni = inicio.ToString("yyyy-MM-dd");
                        string fechaFin = fin.ToString("yyyy-MM-dd");

                        command.CommandText = $"EXEC sp_ReporteVentasPorFecha '{fechaIni}', '{fechaFin}'";

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                lista.Add(new ReporteVentasDto
                                {
                                    Producto = reader.GetString(0),
                                    Categoria = reader.GetString(1),
                                    UnidadesVendidas = reader.GetInt32(2),
                                    TotalIngresos = reader.GetDecimal(3)
                                });
                            }
                        }
                    }
                    return Ok(lista);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, new { Mensaje = "Error en reporte: " + ex.Message });
                }
            }
        }
    }
}