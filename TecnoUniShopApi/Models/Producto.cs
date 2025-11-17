namespace TecnoUniShopApi.Models
{
    // Esta clase representa la tabla Productos_ts
    public class Producto
    {
        public int IdProducto { get; set; } // Nombre de C#
        public int IdCategoria { get; set; }
        public string NombreProducto { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public string? ImagenProducto { get; set; } // Puede ser nulo
        public string Estado { get; set; }

        public Categoria Categoria { get; set; }
    }
}