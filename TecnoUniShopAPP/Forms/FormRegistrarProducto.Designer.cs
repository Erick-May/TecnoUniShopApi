namespace TecnoUniShopAPP.Forms
{
    partial class FormRegistrarProducto
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtNombre = new TextBox();
            txtDescripcion = new TextBox();
            txtPrecio = new TextBox();
            txtStock = new TextBox();
            cmbCategoria = new ComboBox();
            cmbEstado = new ComboBox();
            pbImagen = new PictureBox();
            btnSeleccionarImagen = new Button();
            btnEliminar = new Button();
            btnGuardar = new Button();
            btnCancelar = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            ((System.ComponentModel.ISupportInitialize)pbImagen).BeginInit();
            SuspendLayout();
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(491, 76);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(353, 31);
            txtNombre.TabIndex = 0;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(491, 133);
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(353, 82);
            txtDescripcion.TabIndex = 1;
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(491, 285);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(353, 31);
            txtPrecio.TabIndex = 2;
            // 
            // txtStock
            // 
            txtStock.Location = new Point(491, 344);
            txtStock.Name = "txtStock";
            txtStock.Size = new Size(353, 31);
            txtStock.TabIndex = 3;
            // 
            // cmbCategoria
            // 
            cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategoria.FormattingEnabled = true;
            cmbCategoria.Location = new Point(491, 231);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(353, 33);
            cmbCategoria.TabIndex = 4;
            // 
            // cmbEstado
            // 
            cmbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstado.FormattingEnabled = true;
            cmbEstado.Location = new Point(491, 407);
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(353, 33);
            cmbEstado.TabIndex = 5;
            // 
            // pbImagen
            // 
            pbImagen.Location = new Point(12, 76);
            pbImagen.Name = "pbImagen";
            pbImagen.Size = new Size(231, 267);
            pbImagen.SizeMode = PictureBoxSizeMode.StretchImage;
            pbImagen.TabIndex = 6;
            pbImagen.TabStop = false;
            // 
            // btnSeleccionarImagen
            // 
            btnSeleccionarImagen.Location = new Point(12, 400);
            btnSeleccionarImagen.Name = "btnSeleccionarImagen";
            btnSeleccionarImagen.Size = new Size(231, 40);
            btnSeleccionarImagen.TabIndex = 7;
            btnSeleccionarImagen.Text = "Seleccionar Imagen";
            btnSeleccionarImagen.UseVisualStyleBackColor = true;
            btnSeleccionarImagen.Click += btnSeleccionarImagen_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(14, 493);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(229, 43);
            btnEliminar.TabIndex = 8;
            btnEliminar.Text = "Desactivar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(317, 493);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(229, 43);
            btnGuardar.TabIndex = 9;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(615, 493);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(229, 43);
            btnCancelar.TabIndex = 10;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Sitka Text", 16F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(139, 9);
            label1.Name = "label1";
            label1.Size = new Size(627, 47);
            label1.TabIndex = 11;
            label1.Text = "AGREGAR O ACTUALIZAR PRODUCTOS";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(289, 83);
            label2.Name = "label2";
            label2.Size = new Size(146, 25);
            label2.TabIndex = 12;
            label2.Text = "Nmbre producto";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(289, 136);
            label3.Name = "label3";
            label3.Size = new Size(104, 25);
            label3.TabIndex = 13;
            label3.Text = "Descripcion";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(289, 285);
            label4.Name = "label4";
            label4.Size = new Size(60, 25);
            label4.TabIndex = 14;
            label4.Text = "Precio";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(289, 344);
            label5.Name = "label5";
            label5.Size = new Size(83, 25);
            label5.TabIndex = 15;
            label5.Text = "Cantidad";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(284, 231);
            label6.Name = "label6";
            label6.Size = new Size(88, 25);
            label6.TabIndex = 16;
            label6.Text = "Categoria";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(289, 408);
            label7.Name = "label7";
            label7.Size = new Size(144, 25);
            label7.TabIndex = 17;
            label7.Text = "Estado Producto";
            // 
            // FormRegistrarProducto
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(909, 548);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(btnEliminar);
            Controls.Add(btnSeleccionarImagen);
            Controls.Add(pbImagen);
            Controls.Add(cmbEstado);
            Controls.Add(cmbCategoria);
            Controls.Add(txtStock);
            Controls.Add(txtPrecio);
            Controls.Add(txtDescripcion);
            Controls.Add(txtNombre);
            Name = "FormRegistrarProducto";
            Text = "FormRegistrarProducto";
            Load += FormRegistrarProducto_Load;
            ((System.ComponentModel.ISupportInitialize)pbImagen).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNombre;
        private TextBox txtDescripcion;
        private TextBox txtPrecio;
        private TextBox txtStock;
        private ComboBox cmbCategoria;
        private ComboBox cmbEstado;
        private PictureBox pbImagen;
        private Button btnSeleccionarImagen;
        private Button btnEliminar;
        private Button btnGuardar;
        private Button btnCancelar;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
    }
}