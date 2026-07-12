namespace StrategicBarber.Windows
{
    partial class VentanaServicios
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
            txtTittle = new Label();
            panel1 = new Panel();
            label3 = new Label();
            label2 = new Label();
            buttonServicio = new Button();
            inputNombre = new TextBox();
            InputCosto = new TextBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // txtTittle
            // 
            txtTittle.Dock = DockStyle.Top;
            txtTittle.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            txtTittle.Location = new Point(0, 0);
            txtTittle.Name = "txtTittle";
            txtTittle.Size = new Size(538, 58);
            txtTittle.TabIndex = 0;
            txtTittle.Text = "Agregar Servicio";
            txtTittle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(buttonServicio);
            panel1.Controls.Add(inputNombre);
            panel1.Controls.Add(InputCosto);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 58);
            panel1.Name = "panel1";
            panel1.Size = new Size(538, 384);
            panel1.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(177, 129);
            label3.Name = "label3";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 4;
            label3.Text = "Costo";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(177, 58);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 3;
            label2.Text = "Nombre";
            // 
            // buttonServicio
            // 
            buttonServicio.Location = new Point(195, 212);
            buttonServicio.Name = "buttonServicio";
            buttonServicio.Size = new Size(114, 39);
            buttonServicio.TabIndex = 2;
            buttonServicio.Text = "Agregar";
            buttonServicio.UseVisualStyleBackColor = true;
            buttonServicio.Click += buttonServicio_Click;
            // 
            // inputNombre
            // 
            inputNombre.Location = new Point(177, 76);
            inputNombre.Name = "inputNombre";
            inputNombre.PlaceholderText = "Nombre";
            inputNombre.Size = new Size(171, 23);
            inputNombre.TabIndex = 1;
            // 
            // InputCosto
            // 
            InputCosto.Location = new Point(177, 147);
            InputCosto.Name = "InputCosto";
            InputCosto.PlaceholderText = "Costo";
            InputCosto.Size = new Size(171, 23);
            InputCosto.TabIndex = 0;
            // 
            // VentanaServicios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(538, 442);
            Controls.Add(panel1);
            Controls.Add(txtTittle);
            Name = "VentanaServicios";
            Text = "VentanaServicios";
            Load += VentanaServicios_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label txtTittle;
        private Panel panel1;
        private TextBox inputNombre;
        private TextBox InputCosto;
        private Label label3;
        private Label label2;
        private Button buttonServicio;
    }
}