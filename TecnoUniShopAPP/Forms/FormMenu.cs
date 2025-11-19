using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using TecnoUniShopAPP.Controles; // Para usar tu ProductoControl
using TecnoUniShopAPP.DTOs;
using TecnoUniShopAPP.Servicios;

namespace TecnoUniShopAPP.Forms
{
    public partial class FormMenu : Form
    {
        private readonly string _token;
        private readonly string _rol;
        private readonly ApiService _apiService;

        private List<ProductoReadDto> _listaProductos;
        public FormMenu(string token, string rol)
        {
            InitializeComponent();

            _token = token;
            _rol = rol;
            _apiService = new ApiService();

            ConfigurarPermisos();
            lblUsuarioInfo.Text = $"Rol: {_rol}";

            ConfigurarPermisos();
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {
            CargarProductos();
        }

        private void ConfigurarPermisos()
        {
            // 1. Ocultar botones sensibles por defecto
            if (btnAgregarProducto != null) btnAgregarProducto.Visible = false;
            if (btnVerCarrito != null) btnVerCarrito.Visible = false;

            // 2. Mostrar según rol
            if (_rol == "Administrador" || _rol == "Inventarista")
            {
                if (btnAgregarProducto != null) btnAgregarProducto.Visible = true;
            }
            else if (_rol == "Cliente")
            {
                if (btnVerCarrito != null) btnVerCarrito.Visible = true;
            }
            else if (_rol == "Repartidor")
            {
                if (btnZonaRepartidor != null) btnZonaRepartidor.Visible = true;
            }

        }

        private async void CargarProductos()
        {
            // Mostrar cursor de carga (opcional)
            this.Cursor = Cursors.WaitCursor;
            flowPanelProductos.Controls.Clear(); // Limpiar panel

            try
            {
                // 1. Llamar a la API
                _listaProductos = await _apiService.GetProductosAsync(_token);

                if (_listaProductos != null && _listaProductos.Count > 0)
                {
                    // 2. Crear una tarjeta por cada producto
                    foreach (var prod in _listaProductos)
                    {
                        var tarjeta = new ProductoControl();

                        // Llenar datos de la tarjeta
                        tarjeta.SetData(
                            prod.IdProducto,
                            prod.NombreProducto,
                            prod.Descripcion ?? "Sin descripción", // Manejar nulos
                            prod.Precio,
                            prod.Cantidad,
                            prod.Categoria,
                            prod.ImagenProducto,
                            _rol // Pasamos el rol para que la tarjeta sepa qué botón mostrar
                        );

                        // Suscribir al evento del botón de la tarjeta
                        tarjeta.OnBtnAccionClick += Tarjeta_OnBtnAccionClick;

                        // Agregar al panel con scroll
                        flowPanelProductos.Controls.Add(tarjeta);
                    }
                }
                else
                {
                    MessageBox.Show("No se encontraron productos o hubo un error al cargar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        // Este metodo se ejecuta cuando tocan el boton dentro de CUALQUIER tarjeta
        private void Tarjeta_OnBtnAccionClick(object sender, int idProducto)
        {
            if (_rol == "Cliente")
            {
                // (Aquí va la lógica del carrito que ya teníamos)
                AgregarAlCarrito(idProducto);
            }
            else if (_rol == "Inventarista" || _rol == "Administrador")
            {
                // 1. Buscar el producto completo en nuestra lista en memoria
                // (Usamos _listaProductos que llenamos en el Load)
                var productoSeleccionado = _listaProductos.Find(p => p.IdProducto == idProducto);

                if (productoSeleccionado != null)
                {
                    // 2. Abrir el formulario en modo EDITAR (pasamos token + producto)
                    FormRegistrarProducto frm = new FormRegistrarProducto(_token, productoSeleccionado);

                    // 3. Si le dan a "Guardar" o "Eliminar", recargamos la lista
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        CargarProductos(); // Refresca el catálogo para ver los cambios
                    }
                }
                else
                {
                    MessageBox.Show("No se pudo cargar la información del producto.");
                }
            }
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            CargarProductos();
        }

        private void btnOcultar_Click(object sender, EventArgs e)
        {
            panelInicial.Visible = !panelInicial.Visible;
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            // Abrimos en modo CREAR (solo token)
            FormRegistrarProducto frm = new FormRegistrarProducto(_token);

            // Si devuelve OK, es que guardo algo, asi que recargamos la lista
            if (frm.ShowDialog() == DialogResult.OK)
            {
                CargarProductos();
            }
        }

        private async void AgregarAlCarrito(int idProducto)
        {
            // 1. Pedimos la cantidad al usuario
            int cantidad = PedirCantidad();

            if (cantidad > 0)
            {
                // 2. Llamamos a la API
                var resp = await _apiService.AgregarAlCarritoAsync(_token, idProducto, cantidad);

                if (resp.Exitoso)
                {
                    MessageBox.Show(resp.Mensaje, "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(resp.Mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // --- HELPER PARA PEDIR CANTIDAD (Crea un mini form al vuelo) ---
        private int PedirCantidad()
        {
            Form formCantidad = new Form();
            formCantidad.Size = new Size(400, 200); // Mas grande
            formCantidad.Text = "Seleccionar Cantidad";
            formCantidad.StartPosition = FormStartPosition.CenterParent;
            formCantidad.FormBorderStyle = FormBorderStyle.FixedDialog;
            formCantidad.MaximizeBox = false;
            formCantidad.MinimizeBox = false;

            Label lbl = new Label() { Left = 50, Top = 30, Text = "Cantidad a comprar:", AutoSize = true, Font = new Font("Segoe UI", 12F) };

            NumericUpDown numeric = new NumericUpDown() { Left = 50, Top = 60, Width = 280, Minimum = 1, Maximum = 100, Value = 1, Font = new Font("Segoe UI", 14F) };

            Button btnOk = new Button() { Text = "Agregar", Left = 200, Width = 130, Top = 110, Height = 40, DialogResult = DialogResult.OK, BackColor = Color.LightGreen };
            Button btnCancel = new Button() { Text = "Cancelar", Left = 50, Width = 130, Top = 110, Height = 40, DialogResult = DialogResult.Cancel };

            formCantidad.Controls.Add(lbl);
            formCantidad.Controls.Add(numeric);
            formCantidad.Controls.Add(btnOk);
            formCantidad.Controls.Add(btnCancel);
            formCantidad.AcceptButton = btnOk;
            formCantidad.CancelButton = btnCancel;

            if (formCantidad.ShowDialog() == DialogResult.OK)
            {
                return (int)numeric.Value;
            }
            else
            {
                return 0;
            }
        }

        private void btnVerCarrito_Click(object sender, EventArgs e)
        {
            FormCarrito frm = new FormCarrito(_token);
            frm.ShowDialog();
        }

        private void btnMisPedidos_Click(object sender, EventArgs e)
        {
            FormMisPedidos frm = new FormMisPedidos(_token);
            frm.ShowDialog();
        }

        private void btnZonaRepartidor_Click(object sender, EventArgs e)
        {
            FormPedidosRepartidor frm = new FormPedidosRepartidor(_token);
            frm.ShowDialog();
        }
    }
}
