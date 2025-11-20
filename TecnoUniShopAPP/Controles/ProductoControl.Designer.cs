namespace TecnoUniShopAPP.Controles
{
    partial class ProductoControl
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            pbImagen = new PictureBox();
            lblNombre = new Label();
            lblPrecio = new Label();
            lblCategoria = new Label();
            btnAccion = new Button();
            lblDescripcion = new Label();
            lblStock = new Label();
            ((System.ComponentModel.ISupportInitialize)pbImagen).BeginInit();
            SuspendLayout();
            // 
            // pbImagen
            // 
            pbImagen.Location = new Point(12, 13);
            pbImagen.Name = "pbImagen";
            pbImagen.Size = new Size(231, 267);
            pbImagen.SizeMode = PictureBoxSizeMode.StretchImage;
            pbImagen.TabIndex = 0;
            pbImagen.TabStop = false;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Sitka Small", 11F, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline, GraphicsUnit.Point, 0);
            lblNombre.Location = new Point(12, 296);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(217, 33);
            lblNombre.TabIndex = 1;
            lblNombre.Text = "Nombre Producto";
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.Font = new Font("Sitka Small", 10F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblPrecio.Location = new Point(294, 34);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(79, 29);
            lblPrecio.TabIndex = 2;
            lblPrecio.Text = "Precio";
            // 
            // lblCategoria
            // 
            lblCategoria.AutoSize = true;
            lblCategoria.Font = new Font("Sitka Small", 10F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblCategoria.Location = new Point(290, 90);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(113, 29);
            lblCategoria.TabIndex = 3;
            lblCategoria.Text = "Categoria";
            // 
            // btnAccion
            // 
            btnAccion.Font = new Font("Sitka Heading", 11F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnAccion.Location = new Point(416, 296);
            btnAccion.Name = "btnAccion";
            btnAccion.Size = new Size(181, 51);
            btnAccion.TabIndex = 5;
            btnAccion.Text = "Agregar";
            btnAccion.UseVisualStyleBackColor = true;
            btnAccion.Click += btnAccion_Click;
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoEllipsis = true;
            lblDescripcion.AutoSize = true;
            lblDescripcion.Font = new Font("Sitka Heading", 10F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblDescripcion.Location = new Point(294, 196);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(113, 29);
            lblDescripcion.TabIndex = 6;
            lblDescripcion.Text = "Descripcion";
            // 
            // lblStock
            // 
            lblStock.AutoSize = true;
            lblStock.Font = new Font("Sitka Small", 10F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblStock.Location = new Point(290, 147);
            lblStock.Name = "lblStock";
            lblStock.Size = new Size(106, 29);
            lblStock.TabIndex = 7;
            lblStock.Text = "Cantidad";
            // 
            // ProductoControl
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblStock);
            Controls.Add(lblDescripcion);
            Controls.Add(btnAccion);
            Controls.Add(lblCategoria);
            Controls.Add(lblPrecio);
            Controls.Add(lblNombre);
            Controls.Add(pbImagen);
            Name = "ProductoControl";
            Size = new Size(605, 356);
            ((System.ComponentModel.ISupportInitialize)pbImagen).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbImagen;
        private Label lblNombre;
        private Label lblPrecio;
        private Label lblCategoria;
        private Button btnAccion;
        private Label lblDescripcion;
        private Label lblStock;
    }
}
