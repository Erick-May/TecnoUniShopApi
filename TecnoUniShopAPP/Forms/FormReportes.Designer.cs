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
            chartVentas = new System.Windows.Forms.DataVisualization.Charting.Chart();
            dtpInicio = new DateTimePicker();
            dtpFin = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            btnFiltrar = new Button();
            dgvReporte = new DataGridView();
            btnExportarExcel = new Button();
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
            chartVentas.Location = new Point(31, 257);
            chartVentas.Name = "chartVentas";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chartVentas.Series.Add(series1);
            chartVentas.Size = new Size(653, 450);
            chartVentas.TabIndex = 0;
            chartVentas.Text = "chart1";
            // 
            // dtpInicio
            // 
            dtpInicio.Location = new Point(216, 120);
            dtpInicio.Name = "dtpInicio";
            dtpInicio.Size = new Size(352, 31);
            dtpInicio.TabIndex = 1;
            // 
            // dtpFin
            // 
            dtpFin.Location = new Point(216, 190);
            dtpFin.Name = "dtpFin";
            dtpFin.Size = new Size(352, 31);
            dtpFin.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(35, 128);
            label1.Name = "label1";
            label1.Size = new Size(128, 25);
            label1.TabIndex = 3;
            label1.Text = "Fecha de inicio";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(37, 188);
            label2.Name = "label2";
            label2.Size = new Size(82, 25);
            label2.TabIndex = 4;
            label2.Text = "Fecha fin";
            // 
            // btnFiltrar
            // 
            btnFiltrar.Location = new Point(627, 183);
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Size = new Size(188, 49);
            btnFiltrar.TabIndex = 5;
            btnFiltrar.Text = "Generar Reporte";
            btnFiltrar.UseVisualStyleBackColor = true;
            btnFiltrar.Click += btnFiltrar_Click;
            // 
            // dgvReporte
            // 
            dgvReporte.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReporte.Location = new Point(764, 257);
            dgvReporte.Name = "dgvReporte";
            dgvReporte.RowHeadersWidth = 62;
            dgvReporte.Size = new Size(704, 450);
            dgvReporte.TabIndex = 6;
            // 
            // btnExportarExcel
            // 
            btnExportarExcel.Location = new Point(860, 183);
            btnExportarExcel.Name = "btnExportarExcel";
            btnExportarExcel.Size = new Size(188, 49);
            btnExportarExcel.TabIndex = 7;
            btnExportarExcel.Text = "Exportar a Excel";
            btnExportarExcel.UseVisualStyleBackColor = true;
            btnExportarExcel.Click += btnExportarExcel_Click;
            // 
            // FormReportes
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1519, 729);
            Controls.Add(btnExportarExcel);
            Controls.Add(dgvReporte);
            Controls.Add(btnFiltrar);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dtpFin);
            Controls.Add(dtpInicio);
            Controls.Add(chartVentas);
            Name = "FormReportes";
            Text = "FormReportes";
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
    }
}