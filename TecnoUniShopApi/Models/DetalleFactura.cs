namespace TecnoUniShopApi.Models
{
    // Esta clase representa la tabla Detalle_facturas_ts
    public class DetalleFactura
    {
        // Llaves primarias compuestas
        public int IdFactura { get; set; }
        public int IdProducto { get; set; }

        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public Factura Factura { get; set; }
        public Producto Producto { get; set; }
    }
}