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
            label1.Font = new Font("Sitka Text", 16F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(306, 9);
            label1.Name = "label1";
            label1.Size = new Size(361, 47);
            label1.TabIndex = 14;
            label1.Text = "REPORTE DE VENTAS";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Sitka Text", 16F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.Location = new Point(306, 304);
            label2.Name = "label2";
            label2.Size = new Size(343, 47);
            label2.TabIndex = 15;
            label2.Text = "DETALLE FACTURAS";
            // 
            // dgvFacturas
            // 
            dgvFacturas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFacturas.Location = new Point(12, 59);
            dgvFacturas.Name = "dgvFacturas";
            dgvFacturas.RowHeadersWidth = 62;
            dgvFacturas.Size = new Size(1062, 225);
            dgvFacturas.TabIndex = 16;
            dgvFacturas.SelectionChanged += dgvFacturas_SelectionChanged;
            // 
            // dgvDetalles
            // 
            dgvDetalles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetalles.Location = new Point(12, 369);
            dgvDetalles.Name = "dgvDetalles";
            dgvDetalles.RowHeadersWidth = 62;
            dgvDetalles.Size = new Size(1062, 225);
            dgvDetalles.TabIndex = 17;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(12, 633);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(199, 44);
            btnVolver.TabIndex = 18;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // FormFacturas
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1096, 689);
            Controls.Add(btnVolver);
            Controls.Add(dgvDetalles);
            Controls.Add(dgvFacturas);
            Controls.Add(label2);
            Controls.Add(label1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormFacturas";
            Text = "FormFacturas";
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