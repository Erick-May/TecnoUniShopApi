namespace TecnoUniShopAPP.Forms
{
    partial class FormReportes
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReportes));
            chartVentas = new System.Windows.Forms.DataVisualization.Charting.Chart();
            dtpInicio = new DateTimePicker();
            dtpFin = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            btnFiltrar = new Button();
            dgvReporte = new DataGridView();
            btnExportarExcel = new Button();
            label3 = new Label();
            btnVolver = new Button();
            ((System.ComponentModel.ISupportInitialize)chartVentas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvReporte).BeginInit();
            SuspendLayout();
            // 
            // chartVentas
            // 
            chartArea1.Name = "ChartArea1";
            chartVentas.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chartVentas.Legends.Add(legend1);
            chartVentas.Location = new Point(25, 206);
            chartVentas.Margin = new Padding(2, 2, 2, 2);
            chartVentas.Name = "chartVentas";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chartVentas.Series.Add(series1);
            chartVentas.Size = new Size(522, 360);
            chartVentas.TabIndex = 0;
            chartVentas.Text = "chart1";
            // 
            // dtpInicio
            // 
            dtpInicio.Location = new Point(229, 101);
            dtpInicio.Margin = new Padding(2, 2, 2, 2);
            dtpInicio.Name = "dtpInicio";
            dtpInicio.Size = new Size(282, 27);
            dtpInicio.TabIndex = 1;
            // 
            // dtpFin
            // 
            dtpFin.Location = new Point(229, 152);
            dtpFin.Margin = new Padding(2, 2, 2, 2);
            dtpFin.Name = "dtpFin";
            dtpFin.Size = new Size(282, 27);
            dtpFin.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(54, 100);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(150, 28);
            label1.TabIndex = 3;
            label1.Text = "Fecha de inicio :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(81, 151);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(98, 28);
            label2.TabIndex = 4;
            label2.Text = "Fecha fin :";
            // 
            // btnFiltrar
            // 
            btnFiltrar.BackColor = Color.MidnightBlue;
            btnFiltrar.Cursor = Cursors.Hand;
            btnFiltrar.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 192, 0);
            btnFiltrar.FlatStyle = FlatStyle.Flat;
            btnFiltrar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnFiltrar.ForeColor = SystemColors.ControlLightLight;
            btnFiltrar.Location = new Point(611, 136);
            btnFiltrar.Margin = new Padding(2, 2, 2, 2);
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Size = new Size(175, 49);
            btnFiltrar.TabIndex = 5;
            btnFiltrar.Text = "Generar Reporte";
            btnFiltrar.UseVisualStyleBackColor = false;
            btnFiltrar.Click += btnFiltrar_Click;
            // 
            // dgvReporte
            // 
            dgvReporte.BackgroundColor = SystemColors.ActiveCaption;
            dgvReporte.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReporte.Location = new Point(611, 206);
            dgvReporte.Margin = new Padding(2, 2, 2, 2);
            dgvReporte.Name = "dgvReporte";
            dgvReporte.RowHeadersWidth = 62;
            dgvReporte.Size = new Size(563, 360);
            dgvReporte.TabIndex = 6;
            // 
            // btnExportarExcel
            // 
            btnExportarExcel.BackColor = Color.MidnightBlue;
            btnExportarExcel.Cursor = Cursors.Hand;
            btnExportarExcel.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 192, 128);
            btnExportarExcel.FlatStyle = FlatStyle.Flat;
            btnExportarExcel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnExportarExcel.ForeColor = SystemColors.ControlLightLight;
            btnExportarExcel.Location = new Point(821, 136);
            btnExportarExcel.Margin = new Padding(2, 2, 2, 2);
            btnExportarExcel.Name = "btnExportarExcel";
            btnExportarExcel.Size = new Size(172, 49);
            btnExportarExcel.TabIndex = 7;
            btnExportarExcel.Text = "Exportar a Excel";
            btnExportarExcel.UseVisualStyleBackColor = false;
            btnExportarExcel.Click += btnExportarExcel_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(393, 9);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(445, 50);
            label3.TabIndex = 14;
            label3.Text = "REPORTE DE MEJORES 5";
            // 
            // btnVolver
            // 
            btnVolver.BackColor = Color.MidnightBlue;
            btnVolver.Cursor = Cursors.Hand;
            btnVolver.FlatAppearance.MouseOverBackColor = Color.LightGray;
            btnVolver.FlatStyle = FlatStyle.Flat;
            btnVolver.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnVolver.ForeColor = SystemColors.ControlLightLight;
            btnVolver.Location = new Point(1024, 136);
            btnVolver.Margin = new Padding(2, 2, 2, 2);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(150, 49);
            btnVolver.TabIndex = 15;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = false;
            btnVolver.Click += btnVolver_Click;
            // 
            // FormReportes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1215, 583);
            Controls.Add(btnVolver);
            Controls.Add(label3);
            Controls.Add(btnExportarExcel);
            Controls.Add(dgvReporte);
            Controls.Add(btnFiltrar);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dtpFin);
            Controls.Add(dtpInicio);
            Controls.Add(chartVentas);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2, 2, 2, 2);
            Name = "FormReportes";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Reportes";
            Load += FormReportes_Load;
            ((System.ComponentModel.ISupportInitialize)chartVentas).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvReporte).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartVentas;
        private DateTimePicker dtpInicio;
        private DateTimePicker dtpFin;
        private Label label1;
        private Label label2;
        private Button btnFiltrar;
        private DataGridView dgvReporte;
        private Button btnExportarExcel;
        private Label label3;
        private Button btnVolver;
    }
}