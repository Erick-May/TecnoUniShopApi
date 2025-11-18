using Microsoft.EntityFrameworkCore;
using TecnoUniShopApi.Models;

namespace TecnoUniShopApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        // Constructor que usaremos
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Mapeo de tus clases a las tablas de la BD
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Administrador> Administradores { get; set; }
        public DbSet<Repartidor> Repartidores { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Direccion> Direcciones { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Carrito> Carritos { get; set; }
        public DbSet<ProductoCarrito> ProductosCarritos { get; set; }
        public DbSet<DetallePedido> DetallesPedidos { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<DetalleFactura> DetallesFacturas { get; set; }
        public DbSet<DetalleRegistro> DetalleRegistros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // --- Mapeo de Producto ---
            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("Productos_ts");

                entity.HasKey(e => e.IdProducto);
                entity.Property(e => e.IdProducto).HasColumnName("id_producto");

                entity.Property(e => e.NombreProducto).HasColumnName("nombre_producto");
                entity.Property(e => e.ImagenProducto).HasColumnName("imagen_producto");

                entity.Property(e => e.Descripcion).HasColumnName("descripcion");
                entity.Property(e => e.Precio).HasColumnName("precio");
                entity.Property(e => e.Cantidad).HasColumnName("cantidad");
                entity.Property(e => e.Estado).HasColumnName("estado");


                // Mapeo de la Llave Foranea
                entity.HasOne(p => p.Categoria)
                      .WithMany()
                      .HasForeignKey(p => p.IdCategoria)
                      .HasConstraintName("fk_categoria_producto");
                entity.Property(e => e.IdCategoria).HasColumnName("id_categoria");
            });

            // --- Mapeo de Categoria ---
            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.ToTable("Categorias_ts");
                entity.HasKey(e => e.IdCategoria);
                entity.Property(e => e.IdCategoria).HasColumnName("id_categoria");
                entity.Property(e => e.NombreCategoria).HasColumnName("nombre_categoria");
            });

            // --- Mapeo de Cliente ---
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("Clientes_ts");
                entity.HasKey(e => e.IdCliente);
                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
                entity.Property(e => e.Contrasena).HasColumnName("contrasenia");

                entity.HasOne(c => c.Direccion)
                      .WithMany()
                      .HasForeignKey(c => c.IdDireccion)
                      .HasConstraintName("fk_direccion_cliente");
                entity.Property(e => e.IdDireccion).HasColumnName("id_direccion");
            });

            // --- Mapeo de Direccion ---
            modelBuilder.Entity<Direccion>(entity =>
            {
                entity.ToTable("Direccion_ts");
                entity.HasKey(e => e.IdDireccion);
                entity.Property(e => e.IdDireccion).HasColumnName("id_direccion");
            });

            // --- Mapeo de Administrador ---
            modelBuilder.Entity<Administrador>(entity =>
            {
                entity.ToTable("Administrador_ts");
                entity.HasKey(e => e.IdAdmin);
                entity.Property(e => e.IdAdmin).HasColumnName("id_admin");
                entity.Property(e => e.Contrasena).HasColumnName("contrasenia");
                entity.Property(e => e.Rol).HasColumnName("rol");
            });

            // --- Mapeo de Repartidor ---
            modelBuilder.Entity<Repartidor>(entity =>
            {
                entity.ToTable("Repartidor_ts");
                entity.HasKey(e => e.IdRepartidor);
                entity.Property(e => e.IdRepartidor).HasColumnName("id_repartidor");
                entity.Property(e => e.NombreRepartidor).HasColumnName("nombre_repartidor");
                entity.Property(e => e.Contrasenia).HasColumnName("contrasenia");
            });

            // --- Mapeo de Pedido ---
            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.ToTable("Pedidos_ts");
                entity.HasKey(e => e.IdPedido);
                entity.Property(e => e.IdPedido).HasColumnName("id_pedido");
                entity.Property(e => e.FechaPedido).HasColumnName("fecha_pedido");
                entity.Property(e => e.EstadoPedido).HasColumnName("estado_pedido");
                entity.Property(e => e.TotalPedido).HasColumnName("total_pedido");

                entity.HasOne(p => p.Cliente)
                      .WithMany()
                      .HasForeignKey(p => p.IdCliente)
                      .HasConstraintName("fk_pedido_cliente");

                // ¡¡ARREGLO!!
                entity.Property(p => p.IdCliente).HasColumnName("id_cliente");

                entity.HasOne(p => p.Repartidor)
                      .WithMany()
                      .HasForeignKey(p => p.IdRepartidor)
                      .HasConstraintName("fk_pedido_repartidor");

                // ¡¡ARREGLO!!
                entity.Property(p => p.IdRepartidor).HasColumnName("id_repartidor");
            });

            // --- Mapeo de DetalleRegistro ---
            modelBuilder.Entity<DetalleRegistro>(entity =>
            {
                entity.ToTable("Detalle_registros_ts");

                // Llave primaria compuesta
                entity.HasKey(dr => new { dr.IdAdmin, dr.IdProducto });

                // Mapeo de columnas
                entity.Property(dr => dr.IdAdmin).HasColumnName("id_admin");
                entity.Property(dr => dr.IdProducto).HasColumnName("id_producto");
                entity.Property(dr => dr.FechaRegistro).HasColumnName("fecha_registro");

                // Relacion con Administrador (Empleado)
                entity.HasOne(dr => dr.Administrador)
                      .WithMany()
                      .HasForeignKey(dr => dr.IdAdmin)
                      .HasConstraintName("fk_dr_admin");

                // Relacion con Producto
                entity.HasOne(dr => dr.Producto)
                      .WithMany()
                      .HasForeignKey(dr => dr.IdProducto)
                      .HasConstraintName("fk_dr_producto");
            });

            // --- Mapeo de Carrito ---
            modelBuilder.Entity<Carrito>(entity =>
            {
                entity.ToTable("Carrito_ts");
                entity.HasKey(e => e.IdCarrito);
                entity.Property(e => e.IdCarrito).HasColumnName("id_carrito");
                entity.Property(e => e.FechaAgregado).HasColumnName("fecha_agregado");

                entity.HasOne(c => c.Cliente)
                      .WithMany()
                      .HasForeignKey(c => c.IdCliente)
                      .HasConstraintName("fk_carrito_cliente");

                // ¡¡ARREGLO!!
                entity.Property(c => c.IdCliente).HasColumnName("id_cliente");
            });

            // --- Mapeo de ProductoCarrito ---
            modelBuilder.Entity<ProductoCarrito>(entity =>
            {
                entity.ToTable("Productos_carrito");
                entity.HasKey(pc => new { pc.IdProducto, pc.IdCarrito });

                // ¡¡ARREGLO!!
                entity.Property(pc => pc.IdProducto).HasColumnName("id_producto");
                entity.Property(pc => pc.IdCarrito).HasColumnName("id_carrito");

                entity.Property(e => e.CantidadProducto).HasColumnName("cantidad_producto");

                entity.HasOne(pc => pc.Producto)
                      .WithMany()
                      .HasForeignKey(pc => pc.IdProducto)
                      .HasConstraintName("fk_pc_producto");

                entity.HasOne(pc => pc.Carrito)
                      .WithMany(c => c.ProductosCarrito)
                      .HasForeignKey(pc => pc.IdCarrito)
                      .HasConstraintName("fk_pc_carrito");
            });

            // --- Mapeo de DetallePedido ---
            modelBuilder.Entity<DetallePedido>(entity =>
            {
                entity.ToTable("Detalle_pedidos_ts");
                entity.HasKey(dp => new { dp.IdProducto, dp.IdPedido });

                // ¡¡ARREGLO!!
                entity.Property(dp => dp.IdProducto).HasColumnName("id_producto");
                entity.Property(dp => dp.IdPedido).HasColumnName("id_pedido");

                entity.Property(e => e.EstadoProducto).HasColumnName("estado_producto");

                entity.HasOne(dp => dp.Producto)
                      .WithMany()
                      .HasForeignKey(dp => dp.IdProducto)
                      .HasConstraintName("fk_dp_producto");

                entity.HasOne(dp => dp.Pedido)
                      .WithMany(p => p.DetallesPedido)
                      .HasForeignKey(dp => dp.IdPedido)
                      .HasConstraintName("fk_dp_pedido");
            });

            // --- Mapeo de Factura ---
            modelBuilder.Entity<Factura>(entity =>
            {
                entity.ToTable("Facturas_ts");
                entity.HasKey(e => e.IdFactura);
                entity.Property(e => e.IdFactura).HasColumnName("id_factura");
                entity.Property(e => e.FechaEmision).HasColumnName("fecha_emision");
                entity.Property(e => e.MetodoPago).HasColumnName("metodo_pago");
                entity.Property(e => e.MontoTotal).HasColumnName("monto_total");

                entity.HasOne(f => f.Pedido)
                      .WithMany()
                      .HasForeignKey(f => f.IdPedido)
                      .HasConstraintName("fk_factura_pedido");

                // ¡¡ARREGLO!!
                entity.Property(f => f.IdPedido).HasColumnName("id_pedido");
            });

            // --- Mapeo de DetalleFactura ---
            modelBuilder.Entity<DetalleFactura>(entity =>
            {
                entity.ToTable("Detalle_facturas_ts");
                entity.HasKey(df => new { df.IdFactura, df.IdProducto });

                // ¡¡ARREGLO!!
                entity.Property(df => df.IdFactura).HasColumnName("id_factura");
                entity.Property(df => df.IdProducto).HasColumnName("id_producto");

                entity.Property(e => e.PrecioUnitario).HasColumnName("precio_unitario");

                entity.HasOne(df => df.Factura)
                      .WithMany(f => f.DetallesFactura)
                      .HasForeignKey(df => df.IdFactura)
                      .HasConstraintName("fk_df_factura");

                entity.HasOne(df => df.Producto)
                      .WithMany()
                      .HasForeignKey(df => df.IdProducto)
                      .HasConstraintName("fk_df_producto");
            });
        }
    }
}