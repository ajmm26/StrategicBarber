namespace StrategicBarber
{
    partial class Inicio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inicio));
            textBoxPassword = new TextBox();
            textboxUserName = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            botonIniciarSesion = new Button();
            SuspendLayout();
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(100, 190);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.PasswordChar = '*';
            textBoxPassword.PlaceholderText = "Clave";
            textBoxPassword.Size = new Size(192, 23);
            textBoxPassword.TabIndex = 1;
            // 
            // textboxUserName
            // 
            textboxUserName.Location = new Point(100, 121);
            textboxUserName.Name = "textboxUserName";
            textboxUserName.PlaceholderText = "Usuario";
            textboxUserName.Size = new Size(192, 23);
            textboxUserName.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(171, 103);
            label1.Name = "label1";
            label1.Size = new Size(47, 15);
            label1.TabIndex = 3;
            label1.Text = "Usuario";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(171, 172);
            label2.Name = "label2";
            label2.Size = new Size(36, 15);
            label2.TabIndex = 4;
            label2.Text = "Clave";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.ButtonFace;
            label3.Font = new Font("Segoe UI", 15F);
            label3.Location = new Point(134, 47);
            label3.Name = "label3";
            label3.Size = new Size(126, 28);
            label3.TabIndex = 5;
            label3.Text = "Iniciar Sesion";
            // 
            // botonIniciarSesion
            // 
            botonIniciarSesion.Location = new Point(134, 239);
            botonIniciarSesion.Name = "botonIniciarSesion";
            botonIniciarSesion.Size = new Size(105, 34);
            botonIniciarSesion.TabIndex = 6;
            botonIniciarSesion.Text = "Iniciar Sesion";
            botonIniciarSesion.UseVisualStyleBackColor = true;
            botonIniciarSesion.Click += botonIniciarSesion_Click;
            // 
            // Inicio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            BackgroundImage = Properties.Resources._1f4860aa43302bf38239891372ae98fb;
            ClientSize = new Size(404, 318);
            Controls.Add(botonIniciarSesion);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textboxUserName);
            Controls.Add(textBoxPassword);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Inicio";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Inicio";
            FormClosed += MainWindow_FormClosed;
            Load += Inicio_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textBoxPassword;
        private TextBox textboxUserName;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button botonIniciarSesion;
    }
}
