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
            flowPanelProductos = new FlowLayoutPanel();
            panelMenu = new Panel();
            lblUsuarioInfo = new Label();
            btnRefrescar = new Button();
            btnAgregarProducto = new Button();
            panel = new Panel();
            btnCerrarSesion = new Button();
            btnVerCarrito = new Button();
            btnMisPedidos = new Button();
            btnPanel = new Button();
            flowPanelProductos.SuspendLayout();
            panelMenu.SuspendLayout();
            panel.SuspendLayout();
            SuspendLayout();
            // 
            // flowPanelProductos
            // 
            flowPanelProductos.AutoScroll = true;
            flowPanelProductos.Controls.Add(panelMenu);
            flowPanelProductos.Dock = DockStyle.Fill;
            flowPanelProductos.Location = new Point(0, 0);
            flowPanelProductos.Name = "flowPanelProductos";
            flowPanelProductos.Size = new Size(1242, 557);
            flowPanelProductos.TabIndex = 0;
            // 
            // panelMenu
            // 
            panelMenu.Controls.Add(lblUsuarioInfo);
            panelMenu.Controls.Add(btnRefrescar);
            panelMenu.Controls.Add(btnAgregarProducto);
            panelMenu.Controls.Add(panel);
            panelMenu.Controls.Add(btnPanel);
            panelMenu.Dock = DockStyle.Top;
            panelMenu.Location = new Point(3, 3);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(1239, 57);
            panelMenu.TabIndex = 0;
            // 
            // lblUsuarioInfo
            // 
            lblUsuarioInfo.AutoSize = true;
            lblUsuarioInfo.Location = new Point(924, 16);
            lblUsuarioInfo.Name = "lblUsuarioInfo";
            lblUsuarioInfo.Size = new Size(109, 25);
            lblUsuarioInfo.TabIndex = 4;
            lblUsuarioInfo.Text = "Info Usuario";
            // 
            // btnRefrescar
            // 
            btnRefrescar.Location = new Point(761, 11);
            btnRefrescar.Name = "btnRefrescar";
            btnRefrescar.Size = new Size(141, 34);
            btnRefrescar.TabIndex = 3;
            btnRefrescar.Text = "Refrescar";
            btnRefrescar.UseVisualStyleBackColor = true;
            // 
            // btnAgregarProducto
            // 
            btnAgregarProducto.Location = new Point(530, 11);
            btnAgregarProducto.Name = "btnAgregarProducto";
            btnAgregarProducto.Size = new Size(215, 34);
            btnAgregarProducto.TabIndex = 2;
            btnAgregarProducto.Text = "Agregar Producto";
            btnAgregarProducto.UseVisualStyleBackColor = true;
            // 
            // panel
            // 
            panel.Controls.Add(btnCerrarSesion);
            panel.Controls.Add(btnVerCarrito);
            panel.Controls.Add(btnMisPedidos);
            panel.Location = new Point(67, 0);
            panel.Name = "panel";
            panel.Size = new Size(457, 57);
            panel.TabIndex = 1;
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.Location = new Point(303, 11);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(141, 34);
            btnCerrarSesion.TabIndex = 2;
            btnCerrarSesion.Text = "Cerrar Sesion";
            btnCerrarSesion.UseVisualStyleBackColor = true;
            btnCerrarSesion.Click += btnCerrarSesion_Click;
            // 
            // btnVerCarrito
            // 
            btnVerCarrito.Location = new Point(9, 11);
            btnVerCarrito.Name = "btnVerCarrito";
            btnVerCarrito.Size = new Size(141, 34);
            btnVerCarrito.TabIndex = 0;
            btnVerCarrito.Text = "Carrito";
            btnVerCarrito.UseVisualStyleBackColor = true;
            // 
            // btnMisPedidos
            // 
            btnMisPedidos.Location = new Point(156, 11);
            btnMisPedidos.Name = "btnMisPedidos";
            btnMisPedidos.Size = new Size(141, 34);
            btnMisPedidos.TabIndex = 1;
            btnMisPedidos.Text = "Mis Pedidos";
            btnMisPedidos.UseVisualStyleBackColor = true;
            // 
            // btnPanel
            // 
            btnPanel.Dock = DockStyle.Left;
            btnPanel.Location = new Point(0, 0);
            btnPanel.Name = "btnPanel";
            btnPanel.Size = new Size(70, 57);
            btnPanel.TabIndex = 0;
            btnPanel.Text = ".";
            btnPanel.UseVisualStyleBackColor = true;
            btnPanel.Click += btnPanel_Click;
            // 
            // FormMenu
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1242, 557);
            Controls.Add(flowPanelProductos);
            Name = "FormMenu";
            Text = "FormMenu";
            Load += FormMenu_Load;
            flowPanelProductos.ResumeLayout(false);
            panelMenu.ResumeLayout(false);
            panelMenu.PerformLayout();
            panel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowPanelProductos;
        private Panel panelMenu;
        private Button btnPanel;
        private Panel panel;
        private Button btnVerCarrito;
        private Button btnRefrescar;
        private Button btnAgregarProducto;
        private Button btnCerrarSesion;
        private Button btnMisPedidos;
        private Label lblUsuarioInfo;
    }
}