using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;
using System.Windows.Forms.DataVisualization.Charting;
using TecnoUniShopAPP.DTOs;
using TecnoUniShopAPP.Servicios;

namespace TecnoUniShopAPP.Forms
{
    public partial class FormReportes : Form
    {
        private readonly string _token;
        private readonly ApiService _apiService;
        private List<ReporteVentasDto> _datosReporte;

        public FormReportes(string token)
        {
            InitializeComponent();
            _token = token;
            _apiService = new ApiService();

            dtpInicio.Value = DateTime.Now.AddMonths(-1);
            dtpFin.Value = DateTime.Now;
        }

        private void FormReportes_Load(object sender, EventArgs e)
        {
            btnFiltrar_Click(null, null);
            CargarGrafica();
        }

        private async void CargarGrafica()
        {
            var datos = await _apiService.GetReporteVentasAsync(_token);

            if (datos != null && datos.Count > 0)
            {
                chartVentas.Series[0].Points.Clear();
                chartVentas.Titles.Clear();
                chartVentas.Titles.Add("Top 5 Productos Más Vendidos");

                foreach (var item in datos)
                {
                    // --- ¡¡AQUI ESTABA EL ERROR!! ---
                    // Cambiamos 'TotalVendido' por 'UnidadesVendidas'
                    chartVentas.Series[0].Points.AddXY(item.Producto, item.UnidadesVendidas);
                }

                chartVentas.Series[0].IsValueShownAsLabel = true;
            }
            else
            {
                MessageBox.Show("No hay datos de ventas para graficar.");
            }
        }

        private async void btnFiltrar_Click(object sender, EventArgs e)
        {
            // 1. Obtener datos del RANGO DE FECHAS (El endpoint nuevo)
            _datosReporte = await _apiService.GetReporteRangoAsync(_token, dtpInicio.Value, dtpFin.Value);

            // 2. Llenar DataGridView
            dgvReporte.DataSource = null;
            dgvReporte.DataSource = _datosReporte;

            // 3. ¡¡LLENAR LA GRAFICA CON ESTOS MISMOS DATOS!!
            ActualizarGrafico(_datosReporte);

            if (_datosReporte.Count == 0)
            {
                MessageBox.Show("No se encontraron ventas en ese rango de fechas.");
            }
        }

        private void ActualizarGrafico(List<ReporteVentasDto> datos)
        {
            // Limpiamos datos viejos
            if (chartVentas.Series.IndexOf("Ventas") != -1)
            {
                chartVentas.Series["Ventas"].Points.Clear();
            }

            if (datos != null && datos.Count > 0)
            {
                foreach (var item in datos)
                {
                    // Agregamos X (Nombre) e Y (CANTIDAD VENDIDA)
                    // OJO: Usa 'UnidadesVendidas', no 'TotalVendido'
                    if (item.UnidadesVendidas > 0)
                    {
                        chartVentas.Series["Ventas"].Points.AddXY(item.Producto, item.UnidadesVendidas);
                    }
                }
            }
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            if (_datosReporte == null || _datosReporte.Count == 0)
            {
                MessageBox.Show("Primero genera el reporte para tener datos.");
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Workbook|*.xlsx";
            sfd.FileName = $"ReporteVentas_{DateTime.Now:yyyyMMdd}.xlsx";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (var workbook = new XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add("Ventas");

                        // --- CABECERAS ---
                        worksheet.Cell(1, 1).Value = "Producto";
                        worksheet.Cell(1, 2).Value = "Categoria";
                        worksheet.Cell(1, 3).Value = "Unidades Vendidas";
                        worksheet.Cell(1, 4).Value = "Ingresos Totales";

                        // (Quitamos los estilos que daban error para asegurar que compile)
                        // var rangoCabecera = worksheet.Range("A1:D1");
                        // rangoCabecera.Style.Font.Bold = true; 

                        // --- DATOS ---
                        int fila = 2;
                        foreach (var item in _datosReporte)
                        {
                            worksheet.Cell(fila, 1).Value = item.Producto;
                            worksheet.Cell(fila, 2).Value = item.Categoria;
                            worksheet.Cell(fila, 3).Value = item.UnidadesVendidas;
                            worksheet.Cell(fila, 4).Value = item.TotalIngresos;

                            // (Quitamos el formato de moneda que daba error)
                            // worksheet.Cell(fila, 4).Style.NumberFormat.Format = "$ #,##0.00";

                            fila++;
                        }

                        worksheet.Columns().AdjustToContents();
                        workbook.SaveAs(sfd.FileName);
                        MessageBox.Show("Reporte exportado exitosamente.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al exportar: " + ex.Message);
                }
            }
        }
    }
}
