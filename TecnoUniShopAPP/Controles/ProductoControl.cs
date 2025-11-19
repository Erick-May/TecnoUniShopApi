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

            // --- AQUI ESTA EL ARREGLO DE LA IMAGEN ---
            if (!string.IsNullOrEmpty(imagenBase64))
            {
                try
                {
                    // 1. Limpiar basura vieja 
                    if (imagenBase64.Length < 100)
                    {
                        pbImagen.Image = null; // Es texto basura
                    }
                    else
                    {
                        byte[] imageBytes = Convert.FromBase64String(imagenBase64);

                        MemoryStream ms = new MemoryStream(imageBytes);
                        pbImagen.Image = Image.FromStream(ms);
                    }
                }
                catch
                {
                    pbImagen.Image = null;
                }
            }
            else
            {
                pbImagen.Image = null;
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
