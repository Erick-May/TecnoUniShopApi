namespace TecnoUniShopAPP.Forms
{
    partial class FormCarrito
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
            dgvCarrito = new DataGridView();
            label1 = new Label();
            btnComprar = new Button();
            btnVolver = new Button();
            lblTotal = new Label();
            cmbMetodoPago = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvCarrito).BeginInit();
            SuspendLayout();
            // 
            // dgvCarrito
            // 
            dgvCarrito.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCarrito.Location = new Point(28, 70);
            dgvCarrito.Name = "dgvCarrito";
            dgvCarrito.RowHeadersWidth = 62;
            dgvCarrito.Size = new Size(935, 315);
            dgvCarrito.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Sitka Text", 16F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(301, 9);
            label1.Name = "label1";
            label1.Size = new Size(385, 47);
            label1.TabIndex = 12;
            label1.Text = "CARRITO DE COMPRAS\r\n";
            // 
            // btnComprar
            // 
            btnComprar.Location = new Point(28, 505);
            btnComprar.Name = "btnComprar";
            btnComprar.Size = new Size(189, 54);
            btnComprar.TabIndex = 14;
            btnComprar.Text = "COMPRAR";
            btnComprar.UseVisualStyleBackColor = true;
            btnComprar.Click += btnComprar_Click;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(257, 505);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(189, 54);
            btnVolver.TabIndex = 15;
            btnVolver.Text = "VOLVER";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Sitka Text", 16F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblTotal.Location = new Point(28, 401);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(251, 47);
            lblTotal.TabIndex = 16;
            lblTotal.Text = " Total: C$ 0.00";
            // 
            // cmbMetodoPago
            // 
            cmbMetodoPago.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMetodoPago.FormattingEnabled = true;
            cmbMetodoPago.Location = new Point(649, 401);
            cmbMetodoPago.Name = "cmbMetodoPago";
            cmbMetodoPago.Size = new Size(314, 33);
            cmbMetodoPago.TabIndex = 17;
            // 
            // FormCarrito
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1005, 571);
            Controls.Add(cmbMetodoPago);
            Controls.Add(lblTotal);
            Controls.Add(btnVolver);
            Controls.Add(btnComprar);
            Controls.Add(label1);
            Controls.Add(dgvCarrito);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormCarrito";
            Text = "FormCarrito";
            Load += FormCarrito_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCarrito).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvCarrito;
        private Label label1;
        private Button btnComprar;
        private Button btnVolver;
        private Label lblTotal;
        private ComboBox cmbMetodoPago;
    }
}