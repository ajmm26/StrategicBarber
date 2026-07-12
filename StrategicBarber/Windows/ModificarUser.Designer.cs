namespace StrategicBarber.Windows
{
    partial class ModificarUser
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
            panel1 = new Panel();
            label9 = new Label();
            selectorRoles = new ComboBox();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            claveaActualMod = new TextBox();
            buttonModificarUser = new Button();
            claveNuevaMod = new TextBox();
            userMod = new TextBox();
            apellidoMod = new TextBox();
            nombreMod = new TextBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(0, 0);
            label1.Margin = new Padding(0, 15, 0, 5);
            label1.Name = "label1";
            label1.Size = new Size(493, 44);
            label1.TabIndex = 0;
            label1.Text = "Modificar Usuario";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.Controls.Add(label9);
            panel1.Controls.Add(selectorRoles);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(claveaActualMod);
            panel1.Controls.Add(buttonModificarUser);
            panel1.Controls.Add(claveNuevaMod);
            panel1.Controls.Add(userMod);
            panel1.Controls.Add(apellidoMod);
            panel1.Controls.Add(nombreMod);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 44);
            panel1.Name = "panel1";
            panel1.Size = new Size(493, 529);
            panel1.TabIndex = 1;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(115, 257);
            label9.Name = "label9";
            label9.Size = new Size(24, 15);
            label9.TabIndex = 14;
            label9.Text = "Rol";
            // 
            // selectorRoles
            // 
            selectorRoles.FormattingEnabled = true;
            selectorRoles.Location = new Point(115, 275);
            selectorRoles.Name = "selectorRoles";
            selectorRoles.Size = new Size(270, 23);
            selectorRoles.TabIndex = 13;
            // 
            // label8
            // 
            label8.Dock = DockStyle.Top;
            label8.Font = new Font("Segoe UI", 9.75F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label8.Location = new Point(0, 21);
            label8.Margin = new Padding(3, 10, 3, 0);
            label8.Name = "label8";
            label8.Size = new Size(493, 17);
            label8.TabIndex = 12;
            label8.Text = "Nota: Si desea cambiar la clave, debe ingresar la actual y la nueva";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            label7.Dock = DockStyle.Top;
            label7.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label7.Location = new Point(0, 0);
            label7.Margin = new Padding(5);
            label7.Name = "label7";
            label7.Size = new Size(493, 21);
            label7.TabIndex = 11;
            label7.Text = "Solo rellene los campos a modificar";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(115, 376);
            label6.Name = "label6";
            label6.Size = new Size(73, 15);
            label6.TabIndex = 10;
            label6.Text = "Nueva Clave";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(115, 315);
            label5.Name = "label5";
            label5.Size = new Size(73, 15);
            label5.TabIndex = 9;
            label5.Text = "Clave Actual";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(115, 198);
            label4.Name = "label4";
            label4.Size = new Size(47, 15);
            label4.TabIndex = 8;
            label4.Text = "Usuario";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(115, 138);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 7;
            label3.Text = "Apellido";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(115, 74);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 6;
            label2.Text = "Nombre";
            // 
            // claveaActualMod
            // 
            claveaActualMod.Location = new Point(115, 333);
            claveaActualMod.Name = "claveaActualMod";
            claveaActualMod.PasswordChar = '*';
            claveaActualMod.PlaceholderText = "Clave atual";
            claveaActualMod.Size = new Size(270, 23);
            claveaActualMod.TabIndex = 5;
            // 
            // buttonModificarUser
            // 
            buttonModificarUser.Location = new Point(168, 469);
            buttonModificarUser.Name = "buttonModificarUser";
            buttonModificarUser.Size = new Size(136, 38);
            buttonModificarUser.TabIndex = 4;
            buttonModificarUser.Text = "Modificar";
            buttonModificarUser.UseVisualStyleBackColor = true;
            buttonModificarUser.Click += buttonModificarUser_Click;
            // 
            // claveNuevaMod
            // 
            claveNuevaMod.Location = new Point(115, 394);
            claveNuevaMod.Name = "claveNuevaMod";
            claveNuevaMod.PasswordChar = '*';
            claveNuevaMod.PlaceholderText = "Nueva Clave";
            claveNuevaMod.Size = new Size(270, 23);
            claveNuevaMod.TabIndex = 3;
            // 
            // userMod
            // 
            userMod.Location = new Point(115, 216);
            userMod.Name = "userMod";
            userMod.PlaceholderText = "Usuario";
            userMod.Size = new Size(270, 23);
            userMod.TabIndex = 2;
            // 
            // apellidoMod
            // 
            apellidoMod.Location = new Point(115, 156);
            apellidoMod.Name = "apellidoMod";
            apellidoMod.PlaceholderText = "Apellido";
            apellidoMod.Size = new Size(270, 23);
            apellidoMod.TabIndex = 1;
            // 
            // nombreMod
            // 
            nombreMod.Location = new Point(115, 92);
            nombreMod.Name = "nombreMod";
            nombreMod.PlaceholderText = "Nombre";
            nombreMod.Size = new Size(270, 23);
            nombreMod.TabIndex = 0;
            // 
            // ModificarUser
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(493, 573);
            Controls.Add(panel1);
            Controls.Add(label1);
            Name = "ModificarUser";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Modificar Usuario";
            Load += ModificarUser_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private TextBox claveNuevaMod;
        private TextBox userMod;
        private TextBox apellidoMod;
        private TextBox nombreMod;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox claveaActualMod;
        private Button buttonModificarUser;
        private Label label9;
        private ComboBox selectorRoles;
    }
}