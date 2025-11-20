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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCarrito));
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
            dgvCarrito.BackgroundColor = SystemColors.ActiveCaption;
            dgvCarrito.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCarrito.Location = new Point(23, 59);
            dgvCarrito.Margin = new Padding(2, 2, 2, 2);
            dgvCarrito.Name = "dgvCarrito";
            dgvCarrito.RowHeadersWidth = 62;
            dgvCarrito.Size = new Size(788, 252);
            dgvCarrito.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(206, 7);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(427, 50);
            label1.TabIndex = 12;
            label1.Text = "CARRITO DE COMPRAS\r\n";
            // 
            // btnComprar
            // 
            btnComprar.BackColor = Color.MidnightBlue;
            btnComprar.Cursor = Cursors.Hand;
            btnComprar.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 192, 0);
            btnComprar.FlatStyle = FlatStyle.Flat;
            btnComprar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnComprar.ForeColor = SystemColors.ControlLightLight;
            btnComprar.Location = new Point(206, 395);
            btnComprar.Margin = new Padding(2, 2, 2, 2);
            btnComprar.Name = "btnComprar";
            btnComprar.Size = new Size(177, 60);
            btnComprar.TabIndex = 14;
            btnComprar.Text = "COMPRAR";
            btnComprar.UseVisualStyleBackColor = false;
            btnComprar.Click += btnComprar_Click;
            // 
            // btnVolver
            // 
            btnVolver.BackColor = Color.MidnightBlue;
            btnVolver.Cursor = Cursors.Hand;
            btnVolver.FlatAppearance.MouseOverBackColor = Color.Silver;
            btnVolver.FlatStyle = FlatStyle.Flat;
            btnVolver.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnVolver.ForeColor = SystemColors.ControlLightLight;
            btnVolver.Location = new Point(456, 395);
            btnVolver.Margin = new Padding(2, 2, 2, 2);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(177, 60);
            btnVolver.TabIndex = 15;
            btnVolver.Text = "VOLVER";
            btnVolver.UseVisualStyleBackColor = false;
            btnVolver.Click += btnVolver_Click;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotal.Location = new Point(206, 322);
            lblTotal.Margin = new Padding(2, 0, 2, 0);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(180, 38);
            lblTotal.TabIndex = 16;
            lblTotal.Text = " Total: $ 0.00";
            // 
            // cmbMetodoPago
            // 
            cmbMetodoPago.BackColor = SystemColors.GradientActiveCaption;
            cmbMetodoPago.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMetodoPago.FormattingEnabled = true;
            cmbMetodoPago.Location = new Point(418, 332);
            cmbMetodoPago.Margin = new Padding(2, 2, 2, 2);
            cmbMetodoPago.Name = "cmbMetodoPago";
            cmbMetodoPago.Size = new Size(252, 28);
            cmbMetodoPago.TabIndex = 17;
            // 
            // FormCarrito
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(840, 481);
            Controls.Add(cmbMetodoPago);
            Controls.Add(lblTotal);
            Controls.Add(btnVolver);
            Controls.Add(btnComprar);
            Controls.Add(label1);
            Controls.Add(dgvCarrito);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2, 2, 2, 2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormCarrito";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Carrito";
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