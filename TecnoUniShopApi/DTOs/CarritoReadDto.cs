using System.Collections.Generic;

namespace TecnoUniShopApi.DTOs
{
    public class CarritoReadDto
    {
        public int IdCarrito { get; set; }
        public List<CarritoItemDto> Items { get; set; } = new List<CarritoItemDto>();
        public decimal Total { get; set; }
    }
}