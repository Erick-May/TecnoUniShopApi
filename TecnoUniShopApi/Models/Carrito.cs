using System;
using System.Collections.Generic;

namespace TecnoUniShopApi.Models
{
    public class Carrito
    {
        public int IdCarrito { get; set; }
        public int IdCliente { get; set; } // Llave foranea
        public DateTime FechaAgregado { get; set; }

        // Propiedad de Navegacion
        public Cliente Cliente { get; set; }

        // Un carrito tiene MUCHOS productos
        public ICollection<ProductoCarrito> ProductosCarrito { get; set; }
    }
}