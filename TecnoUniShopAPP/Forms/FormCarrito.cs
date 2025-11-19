using Newtonsoft.Json.Linq;
using System;
using System.Windows.Forms;
using TecnoUniShopAPP.DTOs;
using TecnoUniShopAPP.Servicios;

namespace TecnoUniShopAPP.Forms
{
    public partial class FormCarrito : Form
    {
        private readonly string _token;
        private readonly ApiService _apiService;
        public FormCarrito(string token)
        {
            InitializeComponent();
            _token = token;
            _apiService = new ApiService();
        }

        private void FormCarrito_Load(object sender, EventArgs e)
        {
            cmbMetodoPago.Items.Clear();
            cmbMetodoPago.Items.Add("En fisico");
            cmbMetodoPago.Items.Add("Tarjeta");
            cmbMetodoPago.Items.Add("Transferencia");
            cmbMetodoPago.Items.Add("Paypal");
            cmbMetodoPago.SelectedIndex = 0;

            CargarCarrito();
        }

        private async void CargarCarrito()
        {
            var carrito = await _apiService.GetCarritoAsync(_token);

            if (carrito != null && carrito.Items != null)
            {
                dgvCarrito.DataSource = null;
                dgvCarrito.DataSource = carrito.Items;

                // Ocultar columnas feas si quieres (como IdProducto)
                // dgvCarrito.Columns["IdProducto"].Visible = false;

                lblTotal.Text = $"Total: $ {carrito.Total:N2}";

                // Si el carrito esta vacio, deshabilitar el boton comprar
                if (carrito.Items.Count == 0)
                {
                    btnComprar.Enabled = false;
                    MessageBox.Show("Tu carrito esta vacio.");
                }
                else
                {
                    btnComprar.Enabled = true;
                }
            }
            else
            {
                lblTotal.Text = "Total: $ 0.00";
                btnComprar.Enabled = false;
            }
        }

        private async void btnComprar_Click(object sender, EventArgs e)
        {
            if (cmbMetodoPago.SelectedItem == null)
            {
                MessageBox.Show("Selecciona un metodo de pago.");
                return;
            }

            string metodoPago = cmbMetodoPago.SelectedItem.ToString();

            // Preguntar confirmacion
            var confirm = MessageBox.Show($"¿Confirmar compra por ${lblTotal.Text} con {metodoPago}?",
                                          "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                btnComprar.Enabled = false; // Evitar doble click

                var respuesta = await _apiService.CrearPedidoAsync(_token, metodoPago);

                if (respuesta.Exitoso)
                {
                    MessageBox.Show(respuesta.Mensaje, "Compra Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); // Cerramos el carrito y volvemos al menu
                }
                else
                {
                    MessageBox.Show(respuesta.Mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnComprar.Enabled = true;
                }
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
