using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TecnoUniShopAPP.DTOs;
using TecnoUniShopAPP.Servicios;

namespace TecnoUniShopAPP.Forms
{
    public partial class FormRegistrarProducto : Form
    {
        private readonly ApiService _apiService;
        private readonly string _token;
        private readonly int? _idProductoEditar; // Si es null, es modo CREAR
        private string _imagenBase64;

        public FormRegistrarProducto(string token)
        {
            InitializeComponent();

            _token = token;
            _apiService = new ApiService();
            _idProductoEditar = null; // Modo Crear

            ConfigurarFormulario("Nuevo Producto");
            btnEliminar.Visible = false;
        }

        // Constructor para EDITAR (Recibe token y el producto a editar)
        public FormRegistrarProducto(string token, ProductoReadDto producto)
        {
            InitializeComponent();
            _token = token;
            _apiService = new ApiService();
            _idProductoEditar = producto.IdProducto; // Modo Editar

            ConfigurarFormulario("Editar Producto");
            CargarDatos(producto);
        }

        private async void FormRegistrarProducto_Load(object sender, EventArgs e)
        {
            await CargarCategorias();
        }

        private void ConfigurarFormulario(string titulo)
        {
            this.Text = titulo;
            cmbEstado.Items.Add("Disponible");
            cmbEstado.Items.Add("Agotado");
            cmbEstado.SelectedIndex = 0; // Por defecto Disponible
        }

        private async Task CargarCategorias()
        {
            var categorias = await _apiService.GetCategoriasAsync(_token);
            cmbCategoria.DataSource = categorias;
            cmbCategoria.DisplayMember = "NombreCategoria"; // Lo que se ve
            cmbCategoria.ValueMember = "IdCategoria";       // El valor real (ID)
            cmbCategoria.SelectedIndex = -1; // Nada seleccionado al inicio
        }

        private void CargarDatos(ProductoReadDto prod)
        {
            txtNombre.Text = prod.NombreProducto;
            txtDescripcion.Text = prod.Descripcion;
            txtPrecio.Text = prod.Precio.ToString();
            txtStock.Text = prod.Cantidad.ToString();

            // Seleccionar estado
            cmbEstado.SelectedItem = prod.Estado;

            // Cargar imagen
            if (!string.IsNullOrEmpty(prod.ImagenProducto))
            {
                _imagenBase64 = prod.ImagenProducto;
                pbImagen.Image = Base64ToImage(_imagenBase64);
            }

            // NOTA: La categoria se selecciona automaticamente si el ComboBox 
            // ya cargo y coinciden los nombres/IDs. Si no, habria que ajustarlo.
            cmbCategoria.Text = prod.Categoria;
        }

        private void btnSeleccionarImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Imagenes|*.jpg;*.jpeg;*.png;*.bmp";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // 1. Leemos los bytes del archivo DIRECTAMENTE (Esto no falla)
                    byte[] imageBytes = File.ReadAllBytes(ofd.FileName);

                    // 2. Guardamos la cadena Base64 (Esto es lo que va a la BD)
                    _imagenBase64 = Convert.ToBase64String(imageBytes);

                    // 3. Mostramos la imagen en pantalla (usando una copia en memoria)
                    using (var ms = new MemoryStream(imageBytes))
                    {
                        pbImagen.Image = Image.FromStream(ms);
                    }
                }
                catch (Exception ex)
                {
                    // Ahora si mostramos el error REAL por si acaso
                    MessageBox.Show("Error al cargar la imagen: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validaciones basicas
            if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtPrecio.Text) ||
                cmbCategoria.SelectedValue == null)
            {
                MessageBox.Show("Nombre, Precio y Categoria son obligatorios.");
                return;
            }

            if (!decimal.TryParse(txtPrecio.Text, out decimal precio))
            {
                MessageBox.Show("El precio debe ser un numero valido.");
                return;
            }

            if (!int.TryParse(txtStock.Text, out int stock)) stock = 0;

            btnGuardar.Enabled = false;

            // CREAR
            if (_idProductoEditar == null)
            {
                var nuevoProd = new ProductoCreateDto
                {
                    NombreProducto = txtNombre.Text,
                    Descripcion = txtDescripcion.Text,
                    Precio = precio,
                    Cantidad = stock,
                    IdCategoria = (int)cmbCategoria.SelectedValue,
                    Estado = cmbEstado.SelectedItem.ToString(),
                    ImagenProducto = _imagenBase64
                };

                var resp = await _apiService.CrearProductoAsync(_token, nuevoProd);
                MostrarResultado(resp);
            }
            // EDITAR
            else
            {
                var editProd = new ProductoUpdateDto
                {
                    NombreProducto = txtNombre.Text,
                    Descripcion = txtDescripcion.Text,
                    Precio = precio,
                    Cantidad = stock,
                    IdCategoria = (int)cmbCategoria.SelectedValue,
                    Estado = cmbEstado.SelectedItem.ToString(),
                    ImagenProducto = _imagenBase64
                };

                var resp = await _apiService.ActualizarProductoAsync(_token, _idProductoEditar.Value, editProd);
                MostrarResultado(resp);
            }
        }

        private void MostrarResultado(GenericResponseDto resp)
        {
            btnGuardar.Enabled = true;
            if (resp.Exitoso)
            {
                MessageBox.Show(resp.Mensaje, "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK; // Avisa al menu que recargue
                this.Close();
            }
            else
            {
                MessageBox.Show("Error: " + resp.Mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (_idProductoEditar == null) return;

            var confirm = MessageBox.Show("¿Seguro que desea deshabilitar este producto?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.Yes)
            {
                var resp = await _apiService.EliminarProductoAsync(_token, _idProductoEditar.Value);
                MostrarResultado(resp);
            }
        }



        // --- Helpers de Imagen (PEGA ESTO AL FINAL DE TU CLASE) ---

        private Image Base64ToImage(string base64String)
        {
            if (string.IsNullOrEmpty(base64String)) return null;

            try
            {
                byte[] imageBytes = Convert.FromBase64String(base64String);
                // OJO: No usamos 'using' aqui para que la imagen no se borre de la memoria
                MemoryStream ms = new MemoryStream(imageBytes);
                return Image.FromStream(ms);
            }
            catch
            {
                return null;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
