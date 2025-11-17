namespace TecnoUniShopApi.DTOs
{
    // DTO para CREAR un producto nuevo
    public class ProductoCreateDto
    {
        public int IdCategoria { get; set; }
        public string NombreProducto { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public string? ImagenProducto { get; set; } // Opcional
        public string Estado { get; set; } = "Disponible";
    }
}