
namespace TecnoUniShopAPP.Forms
{
    public partial class FormBienvenida : Form
    {
        public FormBienvenida()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            // Ocultamos este formulario
            this.Hide();

            // Creamos y mostramos el formulario de Login
            FormInicioSesion formLogin = new FormInicioSesion();
            formLogin.ShowDialog();

            // Cuando el formulario de Login se cierre,
            // cerramos tambien este (la aplicacion termina)
            this.Close();
        }
    }
}
