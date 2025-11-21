using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TecnoUniShopAPP.DTOs;
using TecnoUniShopAPP.Servicios;

namespace TecnoUniShopAPP.Forms
{
    public partial class FormPedidosRepartidor : Form
    {
        private readonly string _token;
        private readonly ApiService _apiService;
        private readonly string _rol;

        public FormPedidosRepartidor(string token, string rol)
        {
            InitializeComponent();
            _token = token;
            _apiService = new ApiService();
            _rol = rol;

            if (rol == "Administrador") btnEntregar.Visible = false;
        }

        private void FormPedidosRepartidor_Load(object sender, EventArgs e)
        {
            CargarPedidos();
        }

        private async void CargarPedidos()
        {
            var lista = await _apiService.GetPedidosDisponiblesAsync(_token);
            if (lista != null)
            {
                dgvPedidos.DataSource = null;
                dgvPedidos.DataSource = lista;
            }
            else
            {
                MessageBox.Show("No se pudieron cargar los pedidos.");
            }
        }

        private async void btnEntregar_Click(object sender, EventArgs e)
        {
            if (dgvPedidos.CurrentRow == null)
            {
                MessageBox.Show("Selecciona un pedido para entregar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var pedido = (PedidoRepartidorDto)dgvPedidos.CurrentRow.DataBoundItem;

            var confirm = MessageBox.Show($"¿Confirmar entrega del pedido #{pedido.IdPedido} para {pedido.NombreCliente}?",
                                          "Confirmar Entrega", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                var resp = await _apiService.EntregarPedidoAsync(_token, pedido.IdPedido);

                if (resp.Exitoso)
                {
                    MessageBox.Show("¡Pedido entregado exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarPedidos(); // Refrescar la lista
                }
                else
                {
                    MessageBox.Show("Error: " + resp.Mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
