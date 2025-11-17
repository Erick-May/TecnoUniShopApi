using System;
using System.Collections.Generic;

namespace TecnoUniShopApi.DTOs
{
    // DTO para mostrar una factura completa
    public class FacturaReadDto
    {
        public int IdFactura { get; set; }
        public int IdPedido { get; set; }
        public DateTime FechaEmision { get; set; }
        public string MetodoPago { get; set; }
        public decimal MontoTotal { get; set; }

        // Una factura tiene muchos detalles
        public List<DetalleFacturaReadDto> Detalles { get; set; }
    }
}