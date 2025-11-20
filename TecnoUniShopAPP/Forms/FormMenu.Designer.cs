namespace TecnoUniShopAPP.Forms
{
    partial class FormMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMenu));
            splitContainer1 = new SplitContainer();
            lblUsuarioInfo = new Label();
            btnRefrescar = new Button();
            btnAgregarProducto = new Button();
            panelInicial = new Panel();
            btnCerrarSesion = new Button();
            btnVerCarrito = new Button();
            btnMisPedidos = new Button();
            btnOcultar = new Button();
            btnZonaRepartidor = new Button();
            btnFacturas = new Button();
            flowPanelProductos = new FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panelInicial.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Margin = new Padding(2, 2, 2, 2);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.BackColor = SystemColors.ControlLightLight;
            splitContainer1.Panel1.Controls.Add(btnCerrarSesion);
            splitContainer1.Panel1.Controls.Add(lblUsuarioInfo);
            splitContainer1.Panel1.Controls.Add(btnRefrescar);
            splitContainer1.Panel1.Controls.Add(btnAgregarProducto);
            splitContainer1.Panel1.Controls.Add(panelInicial);
            splitContainer1.Panel1.Controls.Add(btnOcultar);
            splitContainer1.Panel1.Controls.Add(btnZonaRepartidor);
            splitContainer1.Panel1.Controls.Add(btnFacturas);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(flowPanelProductos);
            splitContainer1.Size = new Size(1220, 565);
            splitContainer1.SplitterDistance = 64;
            splitContainer1.SplitterWidth = 3;
            splitContainer1.TabIndex = 0;
            // 
            // lblUsuarioInfo
            // 
            lblUsuarioInfo.Image = (Image)resources.GetObject("lblUsuarioInfo.Image");
            lblUsuarioInfo.ImageAlign = ContentAlignment.MiddleLeft;
            lblUsuarioInfo.Location = new Point(1042, -1);
            lblUsuarioInfo.Margin = new Padding(2, 0, 2, 0);
            lblUsuarioInfo.Name = "lblUsuarioInfo";
            lblUsuarioInfo.Size = new Size(92, 64);
            lblUsuarioInfo.TabIndex = 4;
            lblUsuarioInfo.Text = "Usuario";
            lblUsuarioInfo.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnRefrescar
            // 
            btnRefrescar.BackColor = Color.LightSlateGray;
            btnRefrescar.Cursor = Cursors.Hand;
            btnRefrescar.FlatAppearance.MouseOverBackColor = Color.FromArgb(128, 255, 255);
            btnRefrescar.FlatStyle = FlatStyle.Flat;
            btnRefrescar.Image = (Image)resources.GetObject("btnRefrescar.Image");
            btnRefrescar.ImageAlign = ContentAlignment.MiddleLeft;
            btnRefrescar.Location = new Point(751, 0);
            btnRefrescar.Margin = new Padding(2, 2, 2, 2);
            btnRefrescar.Name = "btnRefrescar";
            btnRefrescar.Size = new Size(119, 64);
            btnRefrescar.TabIndex = 3;
            btnRefrescar.Text = "Refrescar";
            btnRefrescar.TextAlign = ContentAlignment.MiddleRight;
            btnRefrescar.UseVisualStyleBackColor = false;
            // 
            // btnAgregarProducto
            // 
            btnAgregarProducto.BackColor = Color.LightSlateGray;
            btnAgregarProducto.Cursor = Cursors.Hand;
            btnAgregarProducto.FlatAppearance.MouseOverBackColor = Color.FromArgb(128, 255, 255);
            btnAgregarProducto.FlatStyle = FlatStyle.Flat;
            btnAgregarProducto.Image = (Image)resources.GetObject("btnAgregarProducto.Image");
            btnAgregarProducto.ImageAlign = ContentAlignment.MiddleLeft;
            btnAgregarProducto.Location = new Point(369, -1);
            btnAgregarProducto.Margin = new Padding(2, 2, 2, 2);
            btnAgregarProducto.Name = "btnAgregarProducto";
            btnAgregarProducto.Size = new Size(170, 65);
            btnAgregarProducto.TabIndex = 2;
            btnAgregarProducto.Text = "Agregar Producto";
            btnAgregarProducto.TextAlign = ContentAlignment.MiddleRight;
            btnAgregarProducto.UseVisualStyleBackColor = false;
            btnAgregarProducto.Click += btnAgregarProducto_Click;
            // 
            // panelInicial
            // 
            panelInicial.Controls.Add(btnVerCarrito);
            panelInicial.Controls.Add(btnMisPedidos);
            panelInicial.Dock = DockStyle.Left;
            panelInicial.Location = new Point(58, 0);
            panelInicial.Margin = new Padding(2, 2, 2, 2);
            panelInicial.Name = "panelInicial";
            panelInicial.Size = new Size(292, 64);
            panelInicial.TabIndex = 2;
            panelInicial.Visible = false;
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.BackColor = Color.LightSlateGray;
            btnCerrarSesion.Cursor = Cursors.Hand;
            btnCerrarSesion.FlatAppearance.MouseOverBackColor = Color.Red;
            btnCerrarSesion.FlatStyle = FlatStyle.Flat;
            btnCerrarSesion.Image = (Image)resources.GetObject("btnCerrarSesion.Image");
            btnCerrarSesion.Location = new Point(1158, 0);
            btnCerrarSesion.Margin = new Padding(2, 2, 2, 2);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(62, 65);
            btnCerrarSesion.TabIndex = 2;
            btnCerrarSesion.UseVisualStyleBackColor = false;
            btnCerrarSesion.Click += btnCerrarSesion_Click_1;
            // 
            // btnVerCarrito
            // 
            btnVerCarrito.BackColor = Color.LightSlateGray;
            btnVerCarrito.Cursor = Cursors.Hand;
            btnVerCarrito.FlatAppearance.MouseOverBackColor = Color.FromArgb(128, 255, 255);
            btnVerCarrito.FlatStyle = FlatStyle.Flat;
            btnVerCarrito.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnVerCarrito.ForeColor = Color.Black;
            btnVerCarrito.Image = (Image)resources.GetObject("btnVerCarrito.Image");
            btnVerCarrito.ImageAlign = ContentAlignment.MiddleLeft;
            btnVerCarrito.Location = new Point(24, 0);
            btnVerCarrito.Margin = new Padding(2, 2, 2, 2);
            btnVerCarrito.Name = "btnVerCarrito";
            btnVerCarrito.Size = new Size(111, 64);
            btnVerCarrito.TabIndex = 0;
            btnVerCarrito.Text = "Carrito";
            btnVerCarrito.TextAlign = ContentAlignment.MiddleRight;
            btnVerCarrito.UseVisualStyleBackColor = false;
            btnVerCarrito.Click += btnVerCarrito_Click;
            // 
            // btnMisPedidos
            // 
            btnMisPedidos.BackColor = Color.LightSlateGray;
            btnMisPedidos.Cursor = Cursors.Hand;
            btnMisPedidos.FlatAppearance.MouseOverBackColor = Color.FromArgb(128, 255, 255);
            btnMisPedidos.FlatStyle = FlatStyle.Flat;
            btnMisPedidos.ForeColor = SystemColors.WindowText;
            btnMisPedidos.Image = (Image)resources.GetObject("btnMisPedidos.Image");
            btnMisPedidos.ImageAlign = ContentAlignment.MiddleLeft;
            btnMisPedidos.Location = new Point(156, 0);
            btnMisPedidos.Margin = new Padding(2, 2, 2, 2);
            btnMisPedidos.Name = "btnMisPedidos";
            btnMisPedidos.Size = new Size(135, 64);
            btnMisPedidos.TabIndex = 1;
            btnMisPedidos.Text = "Mis Pedidos";
            btnMisPedidos.TextAlign = ContentAlignment.MiddleRight;
            btnMisPedidos.UseVisualStyleBackColor = false;
            btnMisPedidos.Click += btnMisPedidos_Click;
            // 
            // btnOcultar
            // 
            btnOcultar.BackColor = Color.LightSlateGray;
            btnOcultar.Cursor = Cursors.Hand;
            btnOcultar.Dock = DockStyle.Left;
            btnOcultar.FlatAppearance.MouseOverBackColor = Color.FromArgb(128, 255, 255);
            btnOcultar.FlatStyle = FlatStyle.Flat;
            btnOcultar.Image = (Image)resources.GetObject("btnOcultar.Image");
            btnOcultar.Location = new Point(0, 0);
            btnOcultar.Margin = new Padding(2, 2, 2, 2);
            btnOcultar.Name = "btnOcultar";
            btnOcultar.Size = new Size(58, 64);
            btnOcultar.TabIndex = 0;
            btnOcultar.Text = ".";
            btnOcultar.UseVisualStyleBackColor = false;
            btnOcultar.Click += btnOcultar_Click;
            // 
            // btnZonaRepartidor
            // 
            btnZonaRepartidor.BackColor = Color.LightSlateGray;
            btnZonaRepartidor.Cursor = Cursors.Hand;
            btnZonaRepartidor.FlatAppearance.MouseOverBackColor = Color.FromArgb(128, 255, 255);
            btnZonaRepartidor.FlatStyle = FlatStyle.Flat;
            btnZonaRepartidor.Image = (Image)resources.GetObject("btnZonaRepartidor.Image");
            btnZonaRepartidor.ImageAlign = ContentAlignment.MiddleLeft;
            btnZonaRepartidor.Location = new Point(560, 0);
            btnZonaRepartidor.Margin = new Padding(2, 2, 2, 2);
            btnZonaRepartidor.Name = "btnZonaRepartidor";
            btnZonaRepartidor.Size = new Size(174, 64);
            btnZonaRepartidor.TabIndex = 5;
            btnZonaRepartidor.Text = "Pedidos a Entregar";
            btnZonaRepartidor.TextAlign = ContentAlignment.MiddleRight;
            btnZonaRepartidor.UseVisualStyleBackColor = false;
            btnZonaRepartidor.Visible = false;
            btnZonaRepartidor.Click += btnZonaRepartidor_Click;
            // 
            // btnFacturas
            // 
            btnFacturas.BackColor = Color.LightSlateGray;
            btnFacturas.Cursor = Cursors.Hand;
            btnFacturas.FlatAppearance.MouseOverBackColor = Color.FromArgb(128, 255, 255);
            btnFacturas.FlatStyle = FlatStyle.Flat;
            btnFacturas.Image = (Image)resources.GetObject("btnFacturas.Image");
            btnFacturas.ImageAlign = ContentAlignment.MiddleLeft;
            btnFacturas.Location = new Point(889, -1);
            btnFacturas.Margin = new Padding(2, 2, 2, 2);
            btnFacturas.Name = "btnFacturas";
            btnFacturas.Size = new Size(134, 65);
            btnFacturas.TabIndex = 6;
            btnFacturas.Text = "Ver Facturas";
            btnFacturas.TextAlign = ContentAlignment.MiddleRight;
            btnFacturas.UseVisualStyleBackColor = false;
            btnFacturas.Visible = false;
            btnFacturas.Click += btnFacturas_Click;
            // 
            // flowPanelProductos
            // 
            flowPanelProductos.AutoScroll = true;
            flowPanelProductos.BackColor = SystemColors.ActiveCaption;
            flowPanelProductos.Dock = DockStyle.Fill;
            flowPanelProductos.Location = new Point(0, 0);
            flowPanelProductos.Margin = new Padding(2, 2, 2, 2);
            flowPanelProductos.Name = "flowPanelProductos";
            flowPanelProductos.Size = new Size(1220, 498);
            flowPanelProductos.TabIndex = 0;
            // 
            // FormMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1220, 565);
            Controls.Add(splitContainer1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2, 2, 2, 2);
            Name = "FormMenu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Menu";
            Load += FormMenu_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panelInicial.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Label lblUsuarioInfo;
        private Button btnRefrescar;
        private Button btnAgregarProducto;
        private FlowLayoutPanel flowPanelProductos;
        private Panel panelInicial;
        private Button btnCerrarSesion;
        private Button btnVerCarrito;
        private Button btnMisPedidos;
        private Button btnOcultar;
        private Button btnZonaRepartidor;
        private Button btnFacturas;
    }
}