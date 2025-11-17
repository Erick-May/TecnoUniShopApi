namespace TecnoUniShopApi.Models
{
    public class ProductoCarrito
    {
        // Llaves primarias compuestas
        public int IdProducto { get; set; }
        public int IdCarrito { get; set; }

        public decimal Precio { get; set; } // Precio al momento de agregar
        public int CantidadProducto { get; set; }

        // Propiedades de Navegacion
        public Producto Producto { get; set; }
        public Carrito Carrito { get; set; }
    }
}