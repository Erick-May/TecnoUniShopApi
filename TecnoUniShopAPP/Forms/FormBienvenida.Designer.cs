namespace TecnoUniShopAPP.Forms
{
    partial class FormBienvenida
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnEntrar = new Button();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // btnEntrar
            // 
            btnEntrar.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnEntrar.Location = new Point(388, 208);
            btnEntrar.Name = "btnEntrar";
            btnEntrar.Size = new Size(172, 59);
            btnEntrar.TabIndex = 0;
            btnEntrar.Text = "Entrar";
            btnEntrar.UseVisualStyleBackColor = true;
            btnEntrar.Click += btnEntrar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Stencil", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(86, 40);
            label1.Name = "label1";
            label1.Size = new Size(771, 38);
            label1.TabIndex = 1;
            label1.Text = "¡BIENVENIDO A TU TIENDA EN LINEA FAVORITA!";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Stencil", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(322, 113);
            label2.Name = "label2";
            label2.Size = new Size(283, 38);
            label2.TabIndex = 2;
            label2.Text = "TECNO UNI SHOP\r\n";
            // 
            // FormBienvenida
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(951, 450);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnEntrar);
            Name = "FormBienvenida";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnEntrar;
        private Label label1;
        private Label label2;
    }
}
