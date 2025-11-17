using System;
using System.Collections.Generic;

namespace TecnoUniShopApi.DTOs
{
    // DTO para mostrar el pedido que se acaba de crear
    public class PedidoReadDto
    {
        public int IdPedido { get; set; }
        public int IdFactura { get; set; }
        public DateTime FechaPedido { get; set; }
        public string EstadoPedido { get; set; }
        public decimal TotalPedido { get; set; }
        public string MetodoPago { get; set; }

        // Re-usamos el CarritoItemDto para mostrar los items
        public List<CarritoItemDto> Items { get; set; }
    }
}