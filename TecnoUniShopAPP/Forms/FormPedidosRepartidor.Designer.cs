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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPedidosRepartidor));
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
            label1.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(168, 26);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(699, 50);
            label1.TabIndex = 14;
            label1.Text = "PEDIDOS PENDIENTES POR ENTREGAR";
            // 
            // dgvPedidos
            // 
            dgvPedidos.BackgroundColor = SystemColors.ActiveCaption;
            dgvPedidos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPedidos.Location = new Point(10, 78);
            dgvPedidos.Margin = new Padding(2, 2, 2, 2);
            dgvPedidos.Name = "dgvPedidos";
            dgvPedidos.RowHeadersWidth = 62;
            dgvPedidos.Size = new Size(1021, 232);
            dgvPedidos.TabIndex = 15;
            // 
            // btnEntregar
            // 
            btnEntregar.BackColor = Color.MidnightBlue;
            btnEntregar.Cursor = Cursors.Hand;
            btnEntregar.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 192, 0);
            btnEntregar.FlatStyle = FlatStyle.Flat;
            btnEntregar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnEntregar.ForeColor = SystemColors.ControlLightLight;
            btnEntregar.Location = new Point(306, 330);
            btnEntregar.Margin = new Padding(2, 2, 2, 2);
            btnEntregar.Name = "btnEntregar";
            btnEntregar.Size = new Size(177, 60);
            btnEntregar.TabIndex = 16;
            btnEntregar.Text = "Entregar";
            btnEntregar.UseVisualStyleBackColor = false;
            btnEntregar.Click += btnEntregar_Click;
            // 
            // btnVolver
            // 
            btnVolver.BackColor = Color.MidnightBlue;
            btnVolver.Cursor = Cursors.Hand;
            btnVolver.FlatAppearance.MouseOverBackColor = Color.Silver;
            btnVolver.FlatStyle = FlatStyle.Flat;
            btnVolver.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnVolver.ForeColor = SystemColors.ControlLightLight;
            btnVolver.Location = new Point(606, 330);
            btnVolver.Margin = new Padding(2, 2, 2, 2);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(177, 60);
            btnVolver.TabIndex = 17;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = false;
            btnVolver.Click += btnVolver_Click;
            // 
            // FormPedidosRepartidor
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(1042, 412);
            Controls.Add(btnVolver);
            Controls.Add(btnEntregar);
            Controls.Add(dgvPedidos);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2, 2, 2, 2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormPedidosRepartidor";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Pedidos Repartidor";
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