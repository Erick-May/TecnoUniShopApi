using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecnoUniShopAPP.DTOs
{
    public class PedidoRepartidorDto
    {
        public int IdPedido { get; set; }
        public DateTime? FechaPedido { get; set; }
        public string EstadoPedido { get; set; }
        public decimal TotalPedido { get; set; }

        // Info del Cliente
        public string NombreCliente { get; set; }
        public string TelefonoCliente { get; set; }

        // Info de la Direccion
        public string Ciudad { get; set; }
        public string Barrio { get; set; }
    }
}
