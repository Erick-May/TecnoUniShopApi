namespace TecnoUniShopAPP.Forms
{
    partial class FormFacturas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFacturas));
            label1 = new Label();
            label2 = new Label();
            dgvFacturas = new DataGridView();
            dgvDetalles = new DataGridView();
            btnVolver = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvFacturas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetalles).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(245, 7);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(389, 50);
            label1.TabIndex = 14;
            label1.Text = "REPORTE DE VENTAS";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(257, 254);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(367, 50);
            label2.TabIndex = 15;
            label2.Text = "DETALLE FACTURAS";
            // 
            // dgvFacturas
            // 
            dgvFacturas.BackgroundColor = SystemColors.ActiveCaption;
            dgvFacturas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFacturas.Location = new Point(16, 59);
            dgvFacturas.Margin = new Padding(2, 2, 2, 2);
            dgvFacturas.Name = "dgvFacturas";
            dgvFacturas.RowHeadersWidth = 62;
            dgvFacturas.Size = new Size(863, 193);
            dgvFacturas.TabIndex = 16;
            dgvFacturas.SelectionChanged += dgvFacturas_SelectionChanged;
            // 
            // dgvDetalles
            // 
            dgvDetalles.BackgroundColor = SystemColors.ActiveCaption;
            dgvDetalles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetalles.Location = new Point(16, 306);
            dgvDetalles.Margin = new Padding(2, 2, 2, 2);
            dgvDetalles.Name = "dgvDetalles";
            dgvDetalles.RowHeadersWidth = 62;
            dgvDetalles.Size = new Size(863, 193);
            dgvDetalles.TabIndex = 17;
            // 
            // btnVolver
            // 
            btnVolver.BackColor = Color.MidnightBlue;
            btnVolver.Cursor = Cursors.Hand;
            btnVolver.FlatAppearance.MouseOverBackColor = Color.Silver;
            btnVolver.FlatStyle = FlatStyle.Flat;
            btnVolver.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnVolver.ForeColor = SystemColors.ControlLightLight;
            btnVolver.Location = new Point(354, 508);
            btnVolver.Margin = new Padding(2, 2, 2, 2);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(177, 60);
            btnVolver.TabIndex = 18;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = false;
            btnVolver.Click += btnVolver_Click;
            // 
            // FormFacturas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(903, 579);
            Controls.Add(btnVolver);
            Controls.Add(dgvDetalles);
            Controls.Add(dgvFacturas);
            Controls.Add(label2);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2, 2, 2, 2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormFacturas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Facturas";
            Load += FormFacturas_Load;
            ((System.ComponentModel.ISupportInitialize)dgvFacturas).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetalles).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private DataGridView dgvFacturas;
        private DataGridView dgvDetalles;
        private Button btnVolver;
    }
}