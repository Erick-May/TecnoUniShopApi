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
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {
            CargarProductos();
        }

        private void ConfigurarPermisos()
        {
            // Ocultar todo primero
            btnAgregarProducto.Visible = false;
            btnVerCarrito.Visible = false;
            // btnMisPedidos.Visible = false;

            if (_rol == "Administrador" || _rol == "Inventarista")
            {
                btnAgregarProducto.Visible = true;
            }
            else if (_rol == "Cliente")
            {
                btnVerCarrito.Visible = true;
                // btnMisPedidos.Visible = true;
            }
            // Repartidor y Contador ven el catalogo pero sin botones especiales aqui
        }

        private async void CargarProductos()
        {
            flowPanelProductos.Controls.Clear(); // Limpiar lo viejo

            try
            {
                // Llamada a la API (Necesitas agregar este metodo a tu ApiService)
                // _apiService.ObtenerProductosAsync(_token);
                // Por ahora simulare que recibimos la lista, luego actualizamos ApiService

                // --- TODO: Descomentar esto cuando actualicemos ApiService ---
                // _listaProductos = await _apiService.GetProductosAsync(_token);

                if (_listaProductos != null)
                {
                    foreach (var prod in _listaProductos)
                    {
                        // Crear una tarjeta por cada producto
                        var tarjeta = new ProductoControl();

                        // Llenar los datos (asegurate que tu DTO tenga estos campos)
                        // tarjeta.SetData(prod.IdProducto, prod.NombreProducto, prod.Precio, prod.Cantidad, prod.Categoria, prod.ImagenProducto, _rol);

                        // Suscribirse al click del boton de la tarjeta
                        tarjeta.OnBtnAccionClick += Tarjeta_OnBtnAccionClick;

                        // Agregar al panel magico
                        flowPanelProductos.Controls.Add(tarjeta);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos: " + ex.Message);
            }
        }

        // Este metodo se ejecuta cuando tocan el boton dentro de CUALQUIER tarjeta
        private void Tarjeta_OnBtnAccionClick(object sender, int idProducto)
        {
            if (_rol == "Cliente")
            {
                // Logica para agregar al carrito
                // AgregarAlCarrito(idProducto, 1);
                MessageBox.Show($"Agregando producto {idProducto} al carrito...", "Cargando");
            }
            else if (_rol == "Inventarista" || _rol == "Administrador")
            {
                // Logica para editar
                MessageBox.Show($"Abriendo editor para producto {idProducto}...");
                // FormEditarProducto frm = new FormEditarProducto(idProducto, _token);
                // frm.ShowDialog();
                // CargarProductos(); // Recargar al volver
            }
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPanel_Click(object sender, EventArgs e)
        {
            panel.Visible = !panel.Visible;
        }
    }
}
