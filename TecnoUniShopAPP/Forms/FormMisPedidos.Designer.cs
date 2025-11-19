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
            label1.Font = new Font("Sitka Text", 16F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(325, 9);
            label1.Name = "label1";
            label1.Size = new Size(234, 47);
            label1.TabIndex = 13;
            label1.Text = "MIS PEDIDOS";
            // 
            // btnCancelarPedido
            // 
            btnCancelarPedido.Location = new Point(34, 681);
            btnCancelarPedido.Name = "btnCancelarPedido";
            btnCancelarPedido.Size = new Size(261, 50);
            btnCancelarPedido.TabIndex = 15;
            btnCancelarPedido.Text = "Cancelar Pedido";
            btnCancelarPedido.UseVisualStyleBackColor = true;
            btnCancelarPedido.Click += btnCancelarPedido_Click;
            // 
            // btnDevolverProducto
            // 
            btnDevolverProducto.Location = new Point(325, 681);
            btnDevolverProducto.Name = "btnDevolverProducto";
            btnDevolverProducto.Size = new Size(261, 50);
            btnDevolverProducto.TabIndex = 16;
            btnDevolverProducto.Text = "Devolver Pedido";
            btnDevolverProducto.UseVisualStyleBackColor = true;
            btnDevolverProducto.Click += btnDevolverProducto_Click;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(606, 681);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(261, 50);
            btnVolver.TabIndex = 17;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Sitka Text", 16F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.Location = new Point(301, 344);
            label2.Name = "label2";
            label2.Size = new Size(297, 47);
            label2.TabIndex = 18;
            label2.Text = "DETALLE PEDIDO";
            // 
            // dgvPedidos
            // 
            dgvPedidos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPedidos.Location = new Point(34, 73);
            dgvPedidos.Name = "dgvPedidos";
            dgvPedidos.RowHeadersWidth = 62;
            dgvPedidos.Size = new Size(833, 268);
            dgvPedidos.TabIndex = 19;
            dgvPedidos.SelectionChanged += dgvPedidos_SelectionChanged;
            // 
            // dgvDetalles
            // 
            dgvDetalles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetalles.Location = new Point(34, 394);
            dgvDetalles.Name = "dgvDetalles";
            dgvDetalles.RowHeadersWidth = 62;
            dgvDetalles.Size = new Size(833, 268);
            dgvDetalles.TabIndex = 20;
            // 
            // FormMisPedidos
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(903, 743);
            Controls.Add(dgvDetalles);
            Controls.Add(dgvPedidos);
            Controls.Add(label2);
            Controls.Add(btnVolver);
            Controls.Add(btnDevolverProducto);
            Controls.Add(btnCancelarPedido);
            Controls.Add(label1);
            Name = "FormMisPedidos";
            Text = "FormMisPedidos";
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