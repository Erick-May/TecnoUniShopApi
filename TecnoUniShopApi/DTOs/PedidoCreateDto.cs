namespace TecnoUniShopApi.DTOs
{

    public class PedidoCreateDto
    {
        // El unico dato que necesitamos del cliente es
        // como va a pagar. El resto lo leemos del carrito.
        public string MetodoPago { get; set; } = "Tarjeta"; // Valor por defecto

        // En el futuro, aqui podrias pedir IdRepartidor si el cliente lo elige
        // public int IdRepartidor { get; set; }
    }
}