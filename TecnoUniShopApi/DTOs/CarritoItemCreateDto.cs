namespace TecnoUniShopApi.DTOs
{
    // DTO para agregar un item al carrito
    public class CarritoItemCreateDto
    {
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
    }
}