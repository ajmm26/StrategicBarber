namespace StrategicBarber.Windows
{
    partial class Negocio
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
            label2 = new Label();
            inputNameNegocio = new TextBox();
            inputPorcentajeCobro = new TextBox();
            label4 = new Label();
            botonCrearEmpresa = new Button();
            label5 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(186, 19);
            label1.Name = "label1";
            label1.Size = new Size(168, 25);
            label1.TabIndex = 0;
            label1.Text = "CREA TU NEGOCIO";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(150, 70);
            label2.Name = "label2";
            label2.Size = new Size(59, 19);
            label2.TabIndex = 1;
            label2.Text = "Nombre";
            // 
            // inputNameNegocio
            // 
            inputNameNegocio.Location = new Point(150, 94);
            inputNameNegocio.Name = "inputNameNegocio";
            inputNameNegocio.PlaceholderText = "Nombre ";
            inputNameNegocio.Size = new Size(231, 23);
            inputNameNegocio.TabIndex = 2;
            // 
            // inputPorcentajeCobro
            // 
            inputPorcentajeCobro.Location = new Point(159, 237);
            inputPorcentajeCobro.Name = "inputPorcentajeCobro";
            inputPorcentajeCobro.PlaceholderText = "Comision a pagar";
            inputPorcentajeCobro.Size = new Size(222, 23);
            inputPorcentajeCobro.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(159, 221);
            label4.Name = "label4";
            label4.Size = new Size(151, 13);
            label4.TabIndex = 5;
            label4.Text = "Comision a pagar (opcional)";
            // 
            // botonCrearEmpresa
            // 
            botonCrearEmpresa.Location = new Point(195, 298);
            botonCrearEmpresa.Name = "botonCrearEmpresa";
            botonCrearEmpresa.Size = new Size(128, 36);
            botonCrearEmpresa.TabIndex = 7;
            botonCrearEmpresa.Text = "Crear";
            botonCrearEmpresa.UseVisualStyleBackColor = true;
            botonCrearEmpresa.Click += botonCrearEmpresa_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label5.Location = new Point(65, 155);
            label5.MaximumSize = new Size(450, 200);
            label5.Name = "label5";
            label5.Size = new Size(432, 30);
            label5.TabIndex = 8;
            label5.Text = "El porcentaje de comision que coloque aca, sera global para todos sus empleados. Sino desea puede colocar comision por empleado";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Negocio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(546, 375);
            Controls.Add(label5);
            Controls.Add(botonCrearEmpresa);
            Controls.Add(inputPorcentajeCobro);
            Controls.Add(label4);
            Controls.Add(inputNameNegocio);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Negocio";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Negocio";
            Load += Negocio_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox inputNameNegocio;
        private TextBox inputPorcentajeCobro;
        private Label label4;
        private Button botonCrearEmpresa;
        private Label label5;
    }
}