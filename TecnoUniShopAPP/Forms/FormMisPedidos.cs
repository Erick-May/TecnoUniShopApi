using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TecnoUniShopAPP.DTOs;
using TecnoUniShopAPP.Servicios;

namespace TecnoUniShopAPP.Forms
{
    public partial class FormMisPedidos : Form
    {
        private readonly string _token;
        private readonly ApiService _apiService;
        private List<PedidoReadDto> _listaPedidos;

        public FormMisPedidos(string token)
        {
            InitializeComponent();
            _token = token;
            _apiService = new ApiService();
        }

        private void FormMisPedidos_Load(object sender, EventArgs e)
        {
            CargarPedidos();
        }

        private async void CargarPedidos()
        {
            _listaPedidos = await _apiService.GetMisPedidosAsync(_token);

            if (_listaPedidos != null)
            {
                dgvPedidos.DataSource = null;
                dgvPedidos.DataSource = _listaPedidos;

                // Ocultar la columna compleja de Items en el grid de arriba
                if (dgvPedidos.Columns["Items"] != null) dgvPedidos.Columns["Items"].Visible = false;

                // --- TRUCO: Forzar la carga de detalles del primer pedido ---
                if (dgvPedidos.Rows.Count > 0)
                {
                    dgvPedidos_SelectionChanged(null, null);
                }
            }
        }

        private void dgvPedidos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificamos que haya una fila seleccionada
            if (dgvPedidos.CurrentRow != null)
            {
                // Obtenemos el objeto Pedido de esa fila
                var pedido = (PedidoReadDto)dgvPedidos.CurrentRow.DataBoundItem;

                // Limpiamos el grid de detalles
                dgvDetalles.DataSource = null;
                dgvDetalles.Rows.Clear();

                // Asignamos la lista de items de ese pedido
                if (pedido.Items != null && pedido.Items.Count > 0)
                {
                    dgvDetalles.AutoGenerateColumns = true; // ¡IMPORTANTE!
                    dgvDetalles.DataSource = pedido.Items;

                    // Opcional: Ocultar columnas feas como IdProducto
                    if (dgvDetalles.Columns["IdProducto"] != null) dgvDetalles.Columns["IdProducto"].Visible = false;
                }
            }
        }

        private async void btnCancelarPedido_Click(object sender, EventArgs e)
        {
            if (dgvPedidos.CurrentRow == null) return;
            var pedido = (PedidoReadDto)dgvPedidos.CurrentRow.DataBoundItem;

            if (MessageBox.Show("¿Seguro que quiere cancelar todo el pedido?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var resp = await _apiService.CancelarPedidoAsync(_token, pedido.IdPedido);
                MessageBox.Show(resp.Mensaje);
                if (resp.Exitoso) CargarPedidos(); // Recargar para ver el cambio de estado
            }
        }

        private async void btnDevolverProducto_Click(object sender, EventArgs e)
        {
            if (dgvPedidos.CurrentRow == null || dgvDetalles.CurrentRow == null)
            {
                MessageBox.Show("Selecciona un pedido y un producto.");
                return;
            }

            var pedido = (PedidoReadDto)dgvPedidos.CurrentRow.DataBoundItem;
            var item = (CarritoItemDto)dgvDetalles.CurrentRow.DataBoundItem;

            if (MessageBox.Show($"¿Devolver solo el producto '{item.NombreProducto}'?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var resp = await _apiService.DevolverProductoAsync(_token, pedido.IdPedido, item.IdProducto);
                MessageBox.Show(resp.Mensaje);
                if (resp.Exitoso) CargarPedidos();
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvPedidos_SelectionChanged(object sender, EventArgs e)
        {
            // Verificamos que haya una fila seleccionada
            if (dgvPedidos.CurrentRow != null)
            {
                // Obtenemos el objeto Pedido de esa fila
                var pedido = (PedidoReadDto)dgvPedidos.CurrentRow.DataBoundItem;

                // Limpiamos el grid de detalles
                dgvDetalles.DataSource = null;
                dgvDetalles.Rows.Clear();

                // Asignamos la lista de items de ese pedido
                if (pedido.Items != null && pedido.Items.Count > 0)
                {
                    dgvDetalles.AutoGenerateColumns = true; // ¡IMPORTANTE!
                    dgvDetalles.DataSource = pedido.Items;

                    // Opcional: Ocultar columnas feas como IdProducto
                    if (dgvDetalles.Columns["IdProducto"] != null) dgvDetalles.Columns["IdProducto"].Visible = false;
                }
            }
        }
    }
}
