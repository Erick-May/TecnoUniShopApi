namespace TecnoUniShopApi.DTOs
{
    // DTO para ACTUALIZAR un producto
    // El Inventarista puede cambiar todo esto
    public class ProductoUpdateDto
    {
        public int IdCategoria { get; set; }
        public string NombreProducto { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public string? ImagenProducto { get; set; }
        public string Estado { get; set; }
    }
}