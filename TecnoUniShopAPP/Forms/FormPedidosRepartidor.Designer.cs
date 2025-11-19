namespace TecnoUniShopAPP.Forms
{
    partial class FormPedidosRepartidor
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
            dgvPedidos = new DataGridView();
            btnEntregar = new Button();
            btnVolver = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPedidos).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Sitka Text", 16F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(340, 9);
            label1.Name = "label1";
            label1.Size = new Size(643, 47);
            label1.TabIndex = 14;
            label1.Text = "PEDIDOS PENDIENTES POR ENTREGAR";
            // 
            // dgvPedidos
            // 
            dgvPedidos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPedidos.Location = new Point(12, 69);
            dgvPedidos.Name = "dgvPedidos";
            dgvPedidos.RowHeadersWidth = 62;
            dgvPedidos.Size = new Size(1276, 225);
            dgvPedidos.TabIndex = 15;
            // 
            // btnEntregar
            // 
            btnEntregar.Location = new Point(12, 327);
            btnEntregar.Name = "btnEntregar";
            btnEntregar.Size = new Size(171, 48);
            btnEntregar.TabIndex = 16;
            btnEntregar.Text = "Entregar";
            btnEntregar.UseVisualStyleBackColor = true;
            btnEntregar.Click += btnEntregar_Click;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(1117, 327);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(171, 48);
            btnVolver.TabIndex = 17;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // FormPedidosRepartidor
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1303, 450);
            Controls.Add(btnVolver);
            Controls.Add(btnEntregar);
            Controls.Add(dgvPedidos);
            Controls.Add(label1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormPedidosRepartidor";
            Text = "FormPedidosRepartidor";
            Load += FormPedidosRepartidor_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPedidos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dgvPedidos;
        private Button btnEntregar;
        private Button btnVolver;
    }
}