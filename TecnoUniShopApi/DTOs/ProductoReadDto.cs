namespace TecnoUniShopApi.DTOs
{
    public class ProductoReadDto
    {
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public string Estado { get; set; }

        // Traemos el nombre de la categoria, no solo el ID
        public string Categoria { get; set; }

        public string? ImagenProducto { get; set; } 
    }
}
