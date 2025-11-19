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
            splitContainer1 = new SplitContainer();
            lblUsuarioInfo = new Label();
            btnRefrescar = new Button();
            btnAgregarProducto = new Button();
            panelInicial = new Panel();
            btnCerrarSesion = new Button();
            btnVerCarrito = new Button();
            btnMisPedidos = new Button();
            btnOcultar = new Button();
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
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(lblUsuarioInfo);
            splitContainer1.Panel1.Controls.Add(btnRefrescar);
            splitContainer1.Panel1.Controls.Add(btnAgregarProducto);
            splitContainer1.Panel1.Controls.Add(panelInicial);
            splitContainer1.Panel1.Controls.Add(btnOcultar);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(flowPanelProductos);
            splitContainer1.Size = new Size(1242, 557);
            splitContainer1.SplitterDistance = 64;
            splitContainer1.TabIndex = 0;
            // 
            // lblUsuarioInfo
            // 
            lblUsuarioInfo.AutoSize = true;
            lblUsuarioInfo.Location = new Point(936, 20);
            lblUsuarioInfo.Name = "lblUsuarioInfo";
            lblUsuarioInfo.Size = new Size(109, 25);
            lblUsuarioInfo.TabIndex = 4;
            lblUsuarioInfo.Text = "Info Usuario";
            // 
            // btnRefrescar
            // 
            btnRefrescar.Location = new Point(777, 15);
            btnRefrescar.Name = "btnRefrescar";
            btnRefrescar.Size = new Size(141, 34);
            btnRefrescar.TabIndex = 3;
            btnRefrescar.Text = "Refrescar";
            btnRefrescar.UseVisualStyleBackColor = true;
            // 
            // btnAgregarProducto
            // 
            btnAgregarProducto.Location = new Point(542, 15);
            btnAgregarProducto.Name = "btnAgregarProducto";
            btnAgregarProducto.Size = new Size(215, 34);
            btnAgregarProducto.TabIndex = 2;
            btnAgregarProducto.Text = "Agregar Producto";
            btnAgregarProducto.UseVisualStyleBackColor = true;
            btnAgregarProducto.Click += btnAgregarProducto_Click;
            // 
            // panelInicial
            // 
            panelInicial.Controls.Add(btnCerrarSesion);
            panelInicial.Controls.Add(btnVerCarrito);
            panelInicial.Controls.Add(btnMisPedidos);
            panelInicial.Dock = DockStyle.Left;
            panelInicial.Location = new Point(73, 0);
            panelInicial.Name = "panelInicial";
            panelInicial.Size = new Size(457, 64);
            panelInicial.TabIndex = 2;
            panelInicial.Visible = false;
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.Location = new Point(303, 11);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(141, 34);
            btnCerrarSesion.TabIndex = 2;
            btnCerrarSesion.Text = "Cerrar Sesion";
            btnCerrarSesion.UseVisualStyleBackColor = true;
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
            // btnOcultar
            // 
            btnOcultar.Dock = DockStyle.Left;
            btnOcultar.Location = new Point(0, 0);
            btnOcultar.Name = "btnOcultar";
            btnOcultar.Size = new Size(73, 64);
            btnOcultar.TabIndex = 0;
            btnOcultar.Text = ".";
            btnOcultar.UseVisualStyleBackColor = true;
            btnOcultar.Click += btnOcultar_Click;
            // 
            // flowPanelProductos
            // 
            flowPanelProductos.AutoScroll = true;
            flowPanelProductos.Dock = DockStyle.Fill;
            flowPanelProductos.Location = new Point(0, 0);
            flowPanelProductos.Name = "flowPanelProductos";
            flowPanelProductos.Size = new Size(1242, 489);
            flowPanelProductos.TabIndex = 0;
            // 
            // FormMenu
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1242, 557);
            Controls.Add(splitContainer1);
            Name = "FormMenu";
            Text = "FormMenu";
            Load += FormMenu_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
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
    }
}