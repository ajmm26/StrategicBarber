namespace StrategicBarber.Windows
{
    partial class CrearUsuario
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
            label1 = new Label();
            inputUsuario = new TextBox();
            inputClave = new TextBox();
            CrearUsuarioBoton = new Button();
            label2 = new Label();
            label3 = new Label();
            panelContentCreatedUser = new Panel();
            label5 = new Label();
            label4 = new Label();
            inputApellido = new TextBox();
            InputNombre = new TextBox();
            panelContentCreatedUser.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            label1.Location = new Point(158, 37);
            label1.Name = "label1";
            label1.Size = new Size(147, 30);
            label1.TabIndex = 0;
            label1.Text = "Crear Usuario";
            // 
            // inputUsuario
            // 
            inputUsuario.Location = new Point(44, 144);
            inputUsuario.Name = "inputUsuario";
            inputUsuario.PlaceholderText = "Usuario";
            inputUsuario.Size = new Size(192, 23);
            inputUsuario.TabIndex = 1;
            // 
            // inputClave
            // 
            inputClave.Location = new Point(44, 209);
            inputClave.Name = "inputClave";
            inputClave.PasswordChar = '*';
            inputClave.PlaceholderText = "Clave";
            inputClave.Size = new Size(192, 23);
            inputClave.TabIndex = 2;
            // 
            // CrearUsuarioBoton
            // 
            CrearUsuarioBoton.Location = new Point(172, 415);
            CrearUsuarioBoton.Name = "CrearUsuarioBoton";
            CrearUsuarioBoton.Size = new Size(102, 23);
            CrearUsuarioBoton.TabIndex = 3;
            CrearUsuarioBoton.Text = "Crear Usuario";
            CrearUsuarioBoton.UseVisualStyleBackColor = true;
            CrearUsuarioBoton.Click += CrearUsuarioBoton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(44, 126);
            label2.Name = "label2";
            label2.Size = new Size(47, 15);
            label2.TabIndex = 4;
            label2.Text = "Usuario";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(44, 191);
            label3.Name = "label3";
            label3.Size = new Size(36, 15);
            label3.TabIndex = 5;
            label3.Text = "Clave";
            // 
            // panelContentCreatedUser
            // 
            panelContentCreatedUser.Controls.Add(label5);
            panelContentCreatedUser.Controls.Add(label4);
            panelContentCreatedUser.Controls.Add(inputApellido);
            panelContentCreatedUser.Controls.Add(InputNombre);
            panelContentCreatedUser.Controls.Add(inputClave);
            panelContentCreatedUser.Controls.Add(label2);
            panelContentCreatedUser.Controls.Add(label3);
            panelContentCreatedUser.Controls.Add(inputUsuario);
            panelContentCreatedUser.Location = new Point(92, 79);
            panelContentCreatedUser.Name = "panelContentCreatedUser";
            panelContentCreatedUser.Size = new Size(289, 312);
            panelContentCreatedUser.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(44, 4);
            label5.Name = "label5";
            label5.Size = new Size(51, 15);
            label5.TabIndex = 9;
            label5.Text = "Nombre";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(44, 64);
            label4.Name = "label4";
            label4.Size = new Size(51, 15);
            label4.TabIndex = 8;
            label4.Text = "Apellido";
            // 
            // inputApellido
            // 
            inputApellido.Location = new Point(44, 82);
            inputApellido.Name = "inputApellido";
            inputApellido.PlaceholderText = "Apellido";
            inputApellido.Size = new Size(192, 23);
            inputApellido.TabIndex = 7;
            // 
            // InputNombre
            // 
            InputNombre.Location = new Point(44, 22);
            InputNombre.Name = "InputNombre";
            InputNombre.PlaceholderText = "Nombre";
            InputNombre.Size = new Size(192, 23);
            InputNombre.TabIndex = 6;
            // 
            // CrearUsuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(482, 450);
            Controls.Add(panelContentCreatedUser);
            Controls.Add(CrearUsuarioBoton);
            Controls.Add(label1);
            Name = "CrearUsuario";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CrearUsuario";
            Load += CrearUsuario_Load;
            panelContentCreatedUser.ResumeLayout(false);
            panelContentCreatedUser.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox inputUsuario;
        private TextBox inputClave;
        private Button button1;
        private Label label2;
        private Label label3;
        private Button CrearUsuarioBoton;
        private Panel panelContentCreatedUser;
        private Label label5;
        private Label label4;
        private TextBox inputApellido;
        private TextBox InputNombre;
    }
}