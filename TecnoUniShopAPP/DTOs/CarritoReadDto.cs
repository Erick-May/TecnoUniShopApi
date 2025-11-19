using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecnoUniShopAPP.DTOs
{
    public class CarritoReadDto
    {
        public int IdCarrito { get; set; }
        public decimal Total { get; set; }

        // La lista de productos dentro del carrito
        public List<CarritoItemDto> Items { get; set; } = new List<CarritoItemDto>();
    }
}
