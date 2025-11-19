namespace TecnoUniShopAPP.Forms
{
    partial class FormRegistro
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
            txtNombre = new TextBox();
            txtEmail = new TextBox();
            txtPassword = new TextBox();
            txtTelefono = new TextBox();
            txtConfirmarPassword = new TextBox();
            txtCiudad = new TextBox();
            txtBarrio = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label4 = new Label();
            btnCrearCuenta = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(348, 92);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(286, 31);
            txtNombre.TabIndex = 0;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(348, 154);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(286, 31);
            txtEmail.TabIndex = 1;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(348, 212);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(286, 31);
            txtPassword.TabIndex = 2;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(348, 336);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(286, 31);
            txtTelefono.TabIndex = 3;
            // 
            // txtConfirmarPassword
            // 
            txtConfirmarPassword.Location = new Point(348, 272);
            txtConfirmarPassword.Name = "txtConfirmarPassword";
            txtConfirmarPassword.Size = new Size(286, 31);
            txtConfirmarPassword.TabIndex = 4;
            // 
            // txtCiudad
            // 
            txtCiudad.Location = new Point(348, 396);
            txtCiudad.Name = "txtCiudad";
            txtCiudad.Size = new Size(286, 31);
            txtCiudad.TabIndex = 5;
            // 
            // txtBarrio
            // 
            txtBarrio.Location = new Point(348, 456);
            txtBarrio.Name = "txtBarrio";
            txtBarrio.Size = new Size(286, 31);
            txtBarrio.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Stencil", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(305, 19);
            label1.Name = "label1";
            label1.Size = new Size(178, 38);
            label1.TabIndex = 7;
            label1.Text = "Registro";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(125, 91);
            label2.Name = "label2";
            label2.Size = new Size(78, 25);
            label2.TabIndex = 8;
            label2.Text = "Nombre";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(125, 155);
            label3.Name = "label3";
            label3.Size = new Size(54, 25);
            label3.TabIndex = 9;
            label3.Text = "Email";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(135, 278);
            label5.Name = "label5";
            label5.Size = new Size(185, 25);
            label5.TabIndex = 11;
            label5.Text = "Confirmar Contrasena";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(137, 333);
            label6.Name = "label6";
            label6.Size = new Size(79, 25);
            label6.TabIndex = 12;
            label6.Text = "Telefono";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(138, 397);
            label7.Name = "label7";
            label7.Size = new Size(68, 25);
            label7.TabIndex = 13;
            label7.Text = "Ciudad";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(139, 462);
            label8.Name = "label8";
            label8.Size = new Size(58, 25);
            label8.TabIndex = 14;
            label8.Text = "Barrio";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(130, 220);
            label4.Name = "label4";
            label4.Size = new Size(101, 25);
            label4.TabIndex = 15;
            label4.Text = "Contrasena";
            // 
            // btnCrearCuenta
            // 
            btnCrearCuenta.Location = new Point(130, 542);
            btnCrearCuenta.Name = "btnCrearCuenta";
            btnCrearCuenta.Size = new Size(218, 51);
            btnCrearCuenta.TabIndex = 16;
            btnCrearCuenta.Text = "Crear Cuenta";
            btnCrearCuenta.UseVisualStyleBackColor = true;
            btnCrearCuenta.Click += btnCrearCuenta_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(416, 542);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(218, 51);
            btnCancelar.TabIndex = 17;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // FormRegistro
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 616);
            Controls.Add(btnCancelar);
            Controls.Add(btnCrearCuenta);
            Controls.Add(label4);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtBarrio);
            Controls.Add(txtCiudad);
            Controls.Add(txtConfirmarPassword);
            Controls.Add(txtTelefono);
            Controls.Add(txtPassword);
            Controls.Add(txtEmail);
            Controls.Add(txtNombre);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormRegistro";
            Text = "FormRegistro";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNombre;
        private TextBox txtEmail;
        private TextBox txtPassword;
        private TextBox txtTelefono;
        private TextBox txtConfirmarPassword;
        private TextBox txtCiudad;
        private TextBox txtBarrio;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label4;
        private Button btnCrearCuenta;
        private Button btnCancelar;
    }
}