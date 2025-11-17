namespace TecnoUniShopApi.DTOs
{
    // DTO para mostrar un item de una factura
    public class DetalleFacturaReadDto
    {
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }
    }
}