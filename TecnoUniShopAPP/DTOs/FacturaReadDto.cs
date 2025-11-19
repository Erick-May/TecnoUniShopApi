using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecnoUniShopAPP.DTOs
{
    public class FacturaReadDto
    {
        public int IdFactura { get; set; }
        public int IdPedido { get; set; }
        public DateTime FechaEmision { get; set; }
        public string MetodoPago { get; set; }
        public decimal MontoTotal { get; set; }

        public List<DetalleFacturaReadDto> Detalles { get; set; }
    }
}
