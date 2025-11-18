namespace TecnoUniShopAPP.Forms
{
    partial class FormInicioSesion
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
            btnIniciarSesion = new Button();
            btnRegistrarse = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtEmail = new TextBox();
            txtPassword = new TextBox();
            SuspendLayout();
            // 
            // btnIniciarSesion
            // 
            btnIniciarSesion.Location = new Point(101, 372);
            btnIniciarSesion.Name = "btnIniciarSesion";
            btnIniciarSesion.Size = new Size(182, 46);
            btnIniciarSesion.TabIndex = 0;
            btnIniciarSesion.Text = "Iniciar Sesion";
            btnIniciarSesion.UseVisualStyleBackColor = true;
            btnIniciarSesion.Click += btnIniciarSesion_Click;
            // 
            // btnRegistrarse
            // 
            btnRegistrarse.Location = new Point(410, 372);
            btnRegistrarse.Name = "btnRegistrarse";
            btnRegistrarse.Size = new Size(182, 46);
            btnRegistrarse.TabIndex = 1;
            btnRegistrarse.Text = "Registrarse";
            btnRegistrarse.UseVisualStyleBackColor = true;
            btnRegistrarse.Click += btnRegistrarse_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(70, 197);
            label1.Name = "label1";
            label1.Size = new Size(54, 25);
            label1.TabIndex = 2;
            label1.Text = "Email";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(68, 269);
            label2.Name = "label2";
            label2.Size = new Size(101, 25);
            label2.TabIndex = 3;
            label2.Text = "Contrasena";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(276, 36);
            label3.Name = "label3";
            label3.Size = new Size(158, 25);
            label3.TabIndex = 4;
            label3.Text = "INICIO DE SESION";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(265, 193);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(274, 31);
            txtEmail.TabIndex = 5;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(265, 266);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(274, 31);
            txtPassword.TabIndex = 6;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // FormInicioSesion
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(764, 580);
            Controls.Add(txtPassword);
            Controls.Add(txtEmail);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnRegistrarse);
            Controls.Add(btnIniciarSesion);
            Name = "FormInicioSesion";
            Text = "FormInicioSesion";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnIniciarSesion;
        private Button btnRegistrarse;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtEmail;
        private TextBox txtPassword;
    }
}