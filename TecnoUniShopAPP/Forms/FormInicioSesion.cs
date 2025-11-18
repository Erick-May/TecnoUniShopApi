using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TecnoUniShopAPP.Servicios;

namespace TecnoUniShopAPP.Forms
{
    public partial class FormInicioSesion : Form
    {
        private readonly ApiService _apiService;
        public FormInicioSesion()
        {
            InitializeComponent();
            _apiService = new ApiService();
        }

        private async void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Por favor, ingrese email y contrasena.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Desactivamos el boton para que no le den clic 1000 veces
            btnIniciarSesion.Enabled = false;

            try
            {
                // ¡Llamamos a la API!
                var respuesta = await _apiService.LoginAsync(email, password);

                if (respuesta != null && respuesta.Exitoso)
                {
                    // ¡¡EXITO!!
                    MessageBox.Show($"¡Bienvenido! Rol: {respuesta.Rol}", "Login Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // (Aqui guardariamos el token y el rol)
                    string token = respuesta.Token;
                    string rol = respuesta.Rol;

                    // Ocultamos el login
                    this.Hide();

                    // Abrimos el FormPrincipal (que aun no hemos creado)
                    // FormPrincipal formPrincipal = new FormPrincipal(token, rol);
                    // formPrincipal.ShowDialog();

                    // Cuando se cierre el FormPrincipal, cerramos este tambien
                    this.Close();
                }
                else
                {
                    // ¡Fallo!
                    string mensajeError = (respuesta != null) ? respuesta.Mensaje : "Error desconocido.";
                    MessageBox.Show(mensajeError, "Error de Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error critico: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Volvemos a activar el boton
            btnIniciarSesion.Enabled = true;
        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            // Ocultamos el Login temporalmente
            this.Hide();

            // Abrimos el formulario de Registro
            FormRegistro formRegistro = new FormRegistro();
            formRegistro.ShowDialog();

            // Cuando el FormRegistro se cierre,
            // volvemos a mostrar el Login
            this.Show();
        }
    }
}
