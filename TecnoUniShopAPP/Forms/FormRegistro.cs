using System;
using System.Threading.Tasks; // Para el Task.Delay
using System.Windows.Forms;
using TecnoUniShopAPP.DTOs; // Usamos nuestros DTOs
using TecnoUniShopAPP.Servicios;

namespace TecnoUniShopAPP.Forms
{
    public partial class FormRegistro : Form
    {
        private readonly ApiService _apiService;
        public FormRegistro()
        {
            InitializeComponent();
            _apiService = new ApiService();
        }

        private async void btnCrearCuenta_Click(object sender, EventArgs e)
        {
            //1. VALIDACION 
            if (string.IsNullOrEmpty(txtNombre.Text) ||
                string.IsNullOrEmpty(txtEmail.Text) ||
                string.IsNullOrEmpty(txtPassword.Text) ||
                string.IsNullOrEmpty(txtConfirmarPassword.Text) ||
                string.IsNullOrEmpty(txtTelefono.Text) ||
                string.IsNullOrEmpty(txtCiudad.Text) ||
                string.IsNullOrEmpty(txtBarrio.Text))
            {
                MessageBox.Show("Por favor, llene todos los campos.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // No continua
            }

            if (txtPassword.Text != txtConfirmarPassword.Text)
            {
                MessageBox.Show("Las contrasenas no coinciden.", "Error de contrasena", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // No continua
            }

            // --- 2. Si todo esta bien, creamos el DTO ---
            var nuevoCliente = new ClienteCreateDto
            {
                Nombre = txtNombre.Text,
                Email = txtEmail.Text,
                Password = txtPassword.Text,
                Telefono = txtTelefono.Text,
                Ciudad = txtCiudad.Text,
                Barrio = txtBarrio.Text
            };

            btnCrearCuenta.Enabled = false; // Desactivar boton

            try
            {
                // --- 3. Llamamos a la API ---
                var respuesta = await _apiService.RegistrarAsync(nuevoCliente);

                if (respuesta.Exitoso)
                {
                    // --- 4. ¡EXITO! (La logica que pediste) ---
                    LimpiarCampos();
                    MessageBox.Show(respuesta.Mensaje, "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Esperamos 3 segundos
                    await Task.Delay(3000);

                    // Cerramos este formulario (y volvemos al de Login)
                    this.Close();
                }
                else
                {
                    // Error 400 (ej: email duplicado)
                    MessageBox.Show(respuesta.Mensaje, "Error de Registro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error critico: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            btnCrearCuenta.Enabled = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtEmail.Clear();
            txtPassword.Clear();
            txtConfirmarPassword.Clear();
            txtTelefono.Clear();
            txtCiudad.Clear();
            txtBarrio.Clear();
        }
    }
}
