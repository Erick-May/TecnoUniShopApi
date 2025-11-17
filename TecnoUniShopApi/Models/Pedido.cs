using System;
using System.Collections.Generic; // <--- AGREGA ESTE USING

namespace TecnoUniShopApi.Models
{
    public class Pedido
    {
        public int IdPedido { get; set; }
        public int IdCliente { get; set; }
        public int IdRepartidor { get; set; }
        public DateTime FechaPedido { get; set; }
        public string EstadoPedido { get; set; }
        public decimal TotalPedido { get; set; }

        // Propiedades de Navegacion
        public Cliente Cliente { get; set; }
        public Repartidor Repartidor { get; set; }
        public ICollection<DetallePedido> DetallesPedido { get; set; }
    }
}