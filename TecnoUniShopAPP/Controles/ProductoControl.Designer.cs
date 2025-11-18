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
            lblStock = new Label();
            btnAccion = new Button();
            lblDescripcion = new Label();
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
            lblNombre.Location = new Point(44, 296);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(156, 25);
            lblNombre.TabIndex = 1;
            lblNombre.Text = "Nombre Producto";
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.Location = new Point(294, 34);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(60, 25);
            lblPrecio.TabIndex = 2;
            lblPrecio.Text = "Precio";
            // 
            // lblCategoria
            // 
            lblCategoria.AutoSize = true;
            lblCategoria.Location = new Point(294, 90);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(88, 25);
            lblCategoria.TabIndex = 3;
            lblCategoria.Text = "Categoria";
            // 
            // lblStock
            // 
            lblStock.AutoSize = true;
            lblStock.Location = new Point(295, 154);
            lblStock.Name = "lblStock";
            lblStock.Size = new Size(83, 25);
            lblStock.TabIndex = 4;
            lblStock.Text = "Cantidad";
            // 
            // btnAccion
            // 
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
            lblDescripcion.Location = new Point(301, 196);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(104, 25);
            lblDescripcion.TabIndex = 6;
            lblDescripcion.Text = "Descripcion";
            // 
            // ProductoControl
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblDescripcion);
            Controls.Add(btnAccion);
            Controls.Add(lblStock);
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
        private Label lblStock;
        private Button btnAccion;
        private Label lblDescripcion;
    }
}
