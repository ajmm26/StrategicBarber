namespace StrategicBarber.Windows
{
    partial class agregarEmpleado
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
            tituloVersionVentana = new Label();
            panel1 = new Panel();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            buttonAgregar = new Button();
            porcentajeEmpleado = new TextBox();
            dniEmpleado = new TextBox();
            apellidoEmpleado = new TextBox();
            nombreEmpleado = new TextBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // tituloVersionVentana
            // 
            tituloVersionVentana.Dock = DockStyle.Top;
            tituloVersionVentana.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            tituloVersionVentana.Location = new Point(0, 0);
            tituloVersionVentana.Name = "tituloVersionVentana";
            tituloVersionVentana.Size = new Size(578, 43);
            tituloVersionVentana.TabIndex = 0;
            tituloVersionVentana.Text = "Agregar Empleado";
            tituloVersionVentana.TextAlign = ContentAlignment.BottomCenter;
            // 
            // panel1
            // 
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(buttonAgregar);
            panel1.Controls.Add(porcentajeEmpleado);
            panel1.Controls.Add(dniEmpleado);
            panel1.Controls.Add(apellidoEmpleado);
            panel1.Controls.Add(nombreEmpleado);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 43);
            panel1.Name = "panel1";
            panel1.Size = new Size(578, 485);
            panel1.TabIndex = 1;
            // 
            // label6
            // 
            label6.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label6.Location = new Point(97, 253);
            label6.Name = "label6";
            label6.Size = new Size(399, 43);
            label6.TabIndex = 14;
            label6.Text = "Nota: Si usted cuenta con porcentaje global, al rellenar \"Porcentaje a cobrar\" este ultimo es el que se usara para los calculos de este empleado";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(171, 310);
            label5.Name = "label5";
            label5.Size = new Size(109, 15);
            label5.TabIndex = 13;
            label5.Text = "Porcentaje a cobrar";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(171, 182);
            label4.Name = "label4";
            label4.Size = new Size(27, 15);
            label4.TabIndex = 12;
            label4.Text = "DNI";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(171, 118);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 11;
            label3.Text = "Apellido";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(171, 50);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 10;
            label2.Text = "Nombre";
            // 
            // buttonAgregar
            // 
            buttonAgregar.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            buttonAgregar.Location = new Point(192, 383);
            buttonAgregar.Name = "buttonAgregar";
            buttonAgregar.Size = new Size(143, 33);
            buttonAgregar.TabIndex = 9;
            buttonAgregar.Text = "Agregar";
            buttonAgregar.UseVisualStyleBackColor = true;
            buttonAgregar.Click += buttonAgregar_Click;
            // 
            // porcentajeEmpleado
            // 
            porcentajeEmpleado.Location = new Point(171, 328);
            porcentajeEmpleado.Name = "porcentajeEmpleado";
            porcentajeEmpleado.PlaceholderText = "Porcentaje";
            porcentajeEmpleado.Size = new Size(216, 23);
            porcentajeEmpleado.TabIndex = 8;
            // 
            // dniEmpleado
            // 
            dniEmpleado.Location = new Point(171, 200);
            dniEmpleado.Name = "dniEmpleado";
            dniEmpleado.PlaceholderText = "DNI";
            dniEmpleado.Size = new Size(216, 23);
            dniEmpleado.TabIndex = 7;
            // 
            // apellidoEmpleado
            // 
            apellidoEmpleado.Location = new Point(171, 136);
            apellidoEmpleado.Name = "apellidoEmpleado";
            apellidoEmpleado.PlaceholderText = "Apellido";
            apellidoEmpleado.Size = new Size(216, 23);
            apellidoEmpleado.TabIndex = 6;
            // 
            // nombreEmpleado
            // 
            nombreEmpleado.Location = new Point(171, 68);
            nombreEmpleado.Name = "nombreEmpleado";
            nombreEmpleado.PlaceholderText = "Nombre";
            nombreEmpleado.Size = new Size(216, 23);
            nombreEmpleado.TabIndex = 5;
            // 
            // agregarEmpleado
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(578, 528);
            Controls.Add(panel1);
            Controls.Add(tituloVersionVentana);
            Name = "agregarEmpleado";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "agregarEmpleado";
            Load += agregarEmpleado_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label tituloVersionVentana;
        private Panel panel1;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Button buttonAgregar;
        private TextBox porcentajeEmpleado;
        private TextBox dniEmpleado;
        private TextBox apellidoEmpleado;
        private TextBox nombreEmpleado;
        private Label label6;
    }
}