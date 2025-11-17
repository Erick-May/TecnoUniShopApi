namespace TecnoUniShopApi.DTOs
{
    // DTO para un solo item en el carrito
    public class CarritoItemDto
    {
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal SubTotal { get; set; }
    }
}