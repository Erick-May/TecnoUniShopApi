using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;
using System.Windows.Forms.DataVisualization.Charting; // Necesario para el Chart
using TecnoUniShopAPP.DTOs;
using TecnoUniShopAPP.Servicios;
using System.Linq;

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

            // --- ¡ESTA ES LA SOLUCIÓN! ---
            // Llamamos a esta función para preparar la gráfica antes de usarla
            ConfigurarGrafico();
        }

        private void ConfigurarGrafico()
        {
            // Limpiamos todo para empezar de cero
            chartVentas.Series.Clear();
            chartVentas.Titles.Clear();
            chartVentas.Legends.Clear();

            // --- 1. CONFIGURAR LA LEYENDA (A LA DERECHA) ---
            Legend miLeyenda = new Legend("LeyendaPrincipal");
            miLeyenda.Docking = Docking.Right; // La pegamos a la derecha
            miLeyenda.Alignment = StringAlignment.Center; // Centrada verticalmente
            miLeyenda.IsTextAutoFit = true;
            chartVentas.Legends.Add(miLeyenda);

            // --- 2. CONFIGURAR LA SERIE (PASTEL) ---
            Series serie = new Series("Ventas");
            serie.ChartType = SeriesChartType.Pie; // <--- AQUÍ CAMBIAMOS A PASTEL

            // Conectamos la serie con la leyenda que acabamos de crear
            serie.Legend = "LeyendaPrincipal";
            serie.IsVisibleInLegend = true;

            // Configuración de etiquetas (lo que sale encima del pastel)
            serie.Label = "#VALY"; // #VALY muestra la cantidad (ej: 50)
                                   // Si prefieres porcentaje usa: serie.Label = "#PERCENT"; 

            // Agregamos la serie y el título
            chartVentas.Series.Add(serie);
            chartVentas.Titles.Add("Top 5 Productos Más Vendidos");
        }

        private void FormReportes_Load(object sender, EventArgs e)
        {
            // Simulamos clic para cargar datos iniciales
            btnFiltrar_Click(null, null);
            // CargarGrafica(); // Ya no es necesario llamarlo aquí si btnFiltrar lo hace, pero lo dejamos por si acaso quieres el Top 5 general
            // Si quieres cargar el Top 5 al inicio descomenta la linea de abajo, pero asegurate que use "Ventas"
            CargarGraficaTop5();
        }

        private async void CargarGraficaTop5()
        {
            var datos = await _apiService.GetReporteVentasAsync(_token);
            ActualizarGrafico(datos); // Reutilizamos el metodo que ya funciona
            chartVentas.Titles[0].Text = "Top 5 Productos Más Vendidos";
        }


        private async void btnFiltrar_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Obtener datos del RANGO DE FECHAS
                _datosReporte = await _apiService.GetReporteRangoAsync(_token, dtpInicio.Value, dtpFin.Value);

                // 2. Llenar DataGridView
                dgvReporte.DataSource = null;
                dgvReporte.DataSource = _datosReporte;

                // 3. Llenar la Gráfica
                ActualizarGrafico(_datosReporte);

                if (_datosReporte.Count == 0)
                {
                    MessageBox.Show("No se encontraron ventas en ese rango.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar: " + ex.Message);
            }
        }

        private void ActualizarGrafico(List<ReporteVentasDto> datos)
        {
            // Limpiamos los puntos viejos
            chartVentas.Series["Ventas"].Points.Clear();

            if (datos != null && datos.Count > 0)
            {
                // Ordenamos y tomamos los 5 mejores
                var top5 = datos.OrderByDescending(x => x.UnidadesVendidas)
                                .Take(5)
                                .ToList();

                foreach (var item in top5)
                {
                    if (item.UnidadesVendidas > 0)
                    {
                        // Al agregar (Producto, Cantidad):
                        // - El "Producto" se va automáticamente a la Leyenda (derecha)
                        // - La "Cantidad" se va al Pastel
                        chartVentas.Series["Ventas"].Points.AddXY(item.Producto, item.UnidadesVendidas);
                    }
                }

                // Opcional: Si quieres que los colores sean variados y bonitos por defecto
                chartVentas.Palette = ChartColorPalette.BrightPastel;
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

                        // Cabeceras
                        worksheet.Cell(1, 1).Value = "Producto";
                        worksheet.Cell(1, 2).Value = "Categoria";
                        worksheet.Cell(1, 3).Value = "Unidades Vendidas";
                        worksheet.Cell(1, 4).Value = "Ingresos Totales";

                        // Datos
                        int fila = 2;
                        foreach (var item in _datosReporte)
                        {
                            worksheet.Cell(fila, 1).Value = item.Producto;
                            worksheet.Cell(fila, 2).Value = item.Categoria;
                            worksheet.Cell(fila, 3).Value = item.UnidadesVendidas;
                            worksheet.Cell(fila, 4).Value = item.TotalIngresos;
                            fila++;
                        }

                        worksheet.Columns().AdjustToContents();
                        workbook.SaveAs(sfd.FileName);
                        MessageBox.Show("Reporte exportado exitosamente.","EXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al exportar: " + ex.Message);
                }
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
