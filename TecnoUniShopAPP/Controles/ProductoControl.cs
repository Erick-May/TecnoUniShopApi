using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using TecnoUniShopAPP.DTOs;

namespace TecnoUniShopAPP.Controles
{
    public partial class ProductoControl : UserControl
    {
        public event EventHandler<int> OnBtnAccionClick;

        public int IdProducto
        {
            get; private set;
        }
        public ProductoControl()
        {
            InitializeComponent();
        }

        public void SetData(int id, string nombre, string descripcion, decimal precio, int stock, string categoria, string imagenBase64, string rolUsuario)
        {
            IdProducto = id;
            lblNombre.Text = nombre;
            lblDescripcion.Text = descripcion;
            lblPrecio.Text = $"$ {precio:N2}";
            lblStock.Text = $"Stock: {stock}";
            lblCategoria.Text = categoria;

            // --- CODIGO BLINDADO PARA IMAGENES ---
            pbImagen.Image = null; // Limpiar imagen anterior

            if (!string.IsNullOrEmpty(imagenBase64) && imagenBase64.Length > 100)
            {
                try
                {
                    // 1. Limpiar encabezados basura (si los hubiera)
                    string base64Limpia = imagenBase64;
                    if (base64Limpia.Contains(",")) base64Limpia = base64Limpia.Split(',')[1];

                    // 2. Convertir a bytes
                    byte[] imageBytes = Convert.FromBase64String(base64Limpia);

                    // 3. Crear imagen usando "Copia Profunda" (Deep Copy) para no bloquear memoria
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        using (Image imagenTemporal = Image.FromStream(ms))
                        {
                            pbImagen.Image = new Bitmap(imagenTemporal);
                        }
                    }
                }
                catch
                {
                    // Si falla, no hacemos nada y se queda la imagen vacia (o pon una por defecto)
                    pbImagen.Image = null;
                }
            }

            ConfigurarBoton(rolUsuario);
        }

        private void ConfigurarBoton(string rol)
        {
            switch (rol)
            {
                case "Cliente":
                    btnAccion.Text = "Agregar al Carrito";
                    btnAccion.Visible = true;
                    break;
                case "Inventarista":
                case "Administrador":
                    btnAccion.Text = "Editar / Ver";
                    btnAccion.Visible = true;
                    break;
                default:
                    // Repartidor y Contador solo ven, no tocan
                    btnAccion.Visible = false;
                    break;
            }
        }

        private void btnAccion_Click(object sender, EventArgs e)
        {
            OnBtnAccionClick?.Invoke(this, IdProducto);
        }
    }
}
