using System;
using System.Collections.Generic;

namespace TecnoUniShopApi.Models
{
    // Esta clase representa la tabla Facturas_ts
    public class Factura
    {
        public int IdFactura { get; set; }
        public int IdPedido { get; set; } // Llave foranea
        public DateTime FechaEmision { get; set; }
        public string MetodoPago { get; set; }
        public decimal MontoTotal { get; set; }

        // Propiedades de Navegacion
        public Pedido Pedido { get; set; }
        public ICollection<DetalleFactura> DetallesFactura { get; set; }
    }
}