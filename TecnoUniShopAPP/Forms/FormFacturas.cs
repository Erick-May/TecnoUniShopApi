using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TecnoUniShopAPP.DTOs;
using TecnoUniShopAPP.Servicios;

namespace TecnoUniShopAPP.Forms
{
    public partial class FormFacturas : Form
    {
        private readonly string _token;
        private readonly ApiService _apiService;
        private List<FacturaReadDto> _listaFacturas;

        public FormFacturas(string token)
        {
            InitializeComponent();
            _token = token;
            _apiService = new ApiService();
        }

        private void FormFacturas_Load(object sender, EventArgs e)
        {
            CargarFacturas();
        }

        private async void CargarFacturas()
        {
            // 1. Pedimos las facturas a la API
            _listaFacturas = await _apiService.GetFacturasAsync(_token);

            if (_listaFacturas != null)
            {
                dgvFacturas.DataSource = null;
                dgvFacturas.DataSource = _listaFacturas;

                // Ocultamos la columna compleja de detalles en la vista principal
                if (dgvFacturas.Columns["Detalles"] != null)
                    dgvFacturas.Columns["Detalles"].Visible = false;

                // Cargamos el primero por defecto
                if (dgvFacturas.Rows.Count > 0)
                {
                    dgvFacturas_SelectionChanged(null, null);
                }
            }
            else
            {
                MessageBox.Show("No se pudieron cargar las facturas o no tienes permiso.");
            }
        }

        private void dgvFacturas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvFacturas.CurrentRow != null)
            {
                var factura = (FacturaReadDto)dgvFacturas.CurrentRow.DataBoundItem;

                dgvDetalles.DataSource = null;
                dgvDetalles.Rows.Clear();

                if (factura.Detalles != null)
                {
                    dgvDetalles.AutoGenerateColumns = true;
                    dgvDetalles.DataSource = factura.Detalles;
                }
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            FormReportes reportes = new FormReportes(_token);
            reportes.ShowDialog();
        }
    }
}
