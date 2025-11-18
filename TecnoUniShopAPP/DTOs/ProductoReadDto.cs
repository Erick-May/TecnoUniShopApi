using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecnoUniShopAPP.DTOs
{
    public class ProductoReadDto
    {
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public string Descripcion { get; set; } // ¡Importante para el label nuevo!
        public decimal Precio { get; set; }
        public int Cantidad { get; set; } // Stock
        public string Estado { get; set; }
        public string Categoria { get; set; }
        public string ImagenProducto { get; set; } // Viene en Base64
    }
}
