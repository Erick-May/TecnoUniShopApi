namespace TecnoUniShopAPP.Forms
{
    partial class FormMisPedidos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMisPedidos));
            label1 = new Label();
            btnCancelarPedido = new Button();
            btnDevolverProducto = new Button();
            btnVolver = new Button();
            label2 = new Label();
            dgvPedidos = new DataGridView();
            dgvDetalles = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvPedidos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetalles).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(276, 18);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(258, 50);
            label1.TabIndex = 13;
            label1.Text = "MIS PEDIDOS";
            // 
            // btnCancelarPedido
            // 
            btnCancelarPedido.BackColor = Color.MidnightBlue;
            btnCancelarPedido.Cursor = Cursors.Hand;
            btnCancelarPedido.FlatAppearance.MouseOverBackColor = Color.Red;
            btnCancelarPedido.FlatStyle = FlatStyle.Flat;
            btnCancelarPedido.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCancelarPedido.ForeColor = SystemColors.ControlLightLight;
            btnCancelarPedido.Location = new Point(61, 567);
            btnCancelarPedido.Margin = new Padding(2, 2, 2, 2);
            btnCancelarPedido.Name = "btnCancelarPedido";
            btnCancelarPedido.Size = new Size(177, 60);
            btnCancelarPedido.TabIndex = 15;
            btnCancelarPedido.Text = "Cancelar Pedido";
            btnCancelarPedido.UseVisualStyleBackColor = false;
            btnCancelarPedido.Click += btnCancelarPedido_Click;
            // 
            // btnDevolverProducto
            // 
            btnDevolverProducto.BackColor = Color.MidnightBlue;
            btnDevolverProducto.Cursor = Cursors.Hand;
            btnDevolverProducto.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 128, 0);
            btnDevolverProducto.FlatStyle = FlatStyle.Flat;
            btnDevolverProducto.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDevolverProducto.ForeColor = SystemColors.ControlLightLight;
            btnDevolverProducto.Location = new Point(325, 567);
            btnDevolverProducto.Margin = new Padding(2, 2, 2, 2);
            btnDevolverProducto.Name = "btnDevolverProducto";
            btnDevolverProducto.Size = new Size(177, 60);
            btnDevolverProducto.TabIndex = 16;
            btnDevolverProducto.Text = "Devolver Pedido";
            btnDevolverProducto.UseVisualStyleBackColor = false;
            btnDevolverProducto.Click += btnDevolverProducto_Click;
            // 
            // btnVolver
            // 
            btnVolver.BackColor = Color.MidnightBlue;
            btnVolver.Cursor = Cursors.Hand;
            btnVolver.FlatAppearance.MouseOverBackColor = Color.Silver;
            btnVolver.FlatStyle = FlatStyle.Flat;
            btnVolver.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnVolver.ForeColor = SystemColors.ControlLightLight;
            btnVolver.Location = new Point(586, 567);
            btnVolver.Margin = new Padding(2, 2, 2, 2);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(177, 60);
            btnVolver.TabIndex = 17;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = false;
            btnVolver.Click += btnVolver_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(246, 286);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(319, 50);
            label2.TabIndex = 18;
            label2.Text = "DETALLE PEDIDO";
            // 
            // dgvPedidos
            // 
            dgvPedidos.BackgroundColor = SystemColors.ActiveCaption;
            dgvPedidos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPedidos.Location = new Point(28, 70);
            dgvPedidos.Margin = new Padding(2, 2, 2, 2);
            dgvPedidos.Name = "dgvPedidos";
            dgvPedidos.RowHeadersWidth = 62;
            dgvPedidos.Size = new Size(762, 214);
            dgvPedidos.TabIndex = 19;
            dgvPedidos.SelectionChanged += dgvPedidos_SelectionChanged;
            // 
            // dgvDetalles
            // 
            dgvDetalles.BackgroundColor = SystemColors.ActiveCaption;
            dgvDetalles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetalles.Location = new Point(27, 338);
            dgvDetalles.Margin = new Padding(2, 2, 2, 2);
            dgvDetalles.Name = "dgvDetalles";
            dgvDetalles.RowHeadersWidth = 62;
            dgvDetalles.Size = new Size(762, 214);
            dgvDetalles.TabIndex = 20;
            // 
            // FormMisPedidos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(823, 653);
            Controls.Add(dgvDetalles);
            Controls.Add(dgvPedidos);
            Controls.Add(label2);
            Controls.Add(btnVolver);
            Controls.Add(btnDevolverProducto);
            Controls.Add(btnCancelarPedido);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2, 2, 2, 2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormMisPedidos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Pedidos";
            Load += FormMisPedidos_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPedidos).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetalles).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Button btnCancelarPedido;
        private Button btnDevolverProducto;
        private Button btnVolver;
        private Label label2;
        private DataGridView dgvPedidos;
        private DataGridView dgvDetalles;
    }
}