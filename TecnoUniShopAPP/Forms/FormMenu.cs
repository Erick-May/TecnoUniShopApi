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
            // Repartidor y Contador solo ven el catálogo
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
                // Lógica para agregar al carrito (Próximo paso)
                // Por ahora solo mostramos mensaje
                MessageBox.Show($"Agregando producto ID {idProducto} al carrito...");

                // Aqui llamaremos a _apiService.AgregarAlCarritoAsync(...)
            }
            else if (_rol == "Inventarista" || _rol == "Administrador")
            {
                MessageBox.Show($"Abriendo editor para producto ID {idProducto}...");
            }
            else if (_rol == "Inventarista" || _rol == "Administrador")
            {
                // Buscamos el objeto producto completo de la lista en memoria
                var productoSeleccionado = _listaProductos.Find(p => p.IdProducto == idProducto);

                if (productoSeleccionado != null)
                {
                    // Abrimos en modo EDITAR (token + producto)
                    FormRegistrarProducto frm = new FormRegistrarProducto(_token, productoSeleccionado);

                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        CargarProductos();
                    }
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


    }
}
