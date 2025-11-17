namespace TecnoUniShopApi.Models
{
    public class DetallePedido
    {
        // Llaves primarias compuestas
        public int IdProducto { get; set; }
        public int IdPedido { get; set; }

        public string EstadoProducto { get; set; }

        public Producto Producto { get; set; }
        public Pedido Pedido { get; set; }
    }
}