using System;

namespace TecnoUniShopApi.Models
{
    // Esta clase representa la tabla Detalle_registros_ts
    public class DetalleRegistro
    {
        // Llaves primarias compuestas
        public int IdAdmin { get; set; } 
        public int IdProducto { get; set; }

        public DateTime FechaRegistro { get; set; }

        // Propiedades de Navegacion
        public Administrador Administrador { get; set; }
        public Producto Producto { get; set; }
    }
}

