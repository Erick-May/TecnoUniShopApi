using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecnoUniShopAPP.DTOs
{
    public class PedidoReadDto
    {
        public int IdPedido { get; set; }
        public int IdFactura { get; set; }
        public DateTime FechaPedido { get; set; }
        public string EstadoPedido { get; set; }
        public decimal TotalPedido { get; set; }
        public string MetodoPago { get; set; }

        // Lista de productos dentro del pedido
        public List<CarritoItemDto> Items { get; set; }
    }
}
