namespace StrategicBarber.Windows
{
    partial class CargarServicio
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
            comboBoxServicios = new ComboBox();
            buttonCargar = new Button();
            nombreEmpleado = new Label();
            SuspendLayout();
            // 
            // comboBoxServicios
            // 
            comboBoxServicios.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            comboBoxServicios.FormattingEnabled = true;
            comboBoxServicios.Location = new Point(146, 168);
            comboBoxServicios.Name = "comboBoxServicios";
            comboBoxServicios.Size = new Size(241, 23);
            comboBoxServicios.TabIndex = 0;
            comboBoxServicios.TextChanged += comboBoxServicios_TextChanged;
            // 
            // buttonCargar
            // 
            buttonCargar.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            buttonCargar.Location = new Point(203, 252);
            buttonCargar.Name = "buttonCargar";
            buttonCargar.Size = new Size(127, 42);
            buttonCargar.TabIndex = 1;
            buttonCargar.Text = "Cargar";
            buttonCargar.UseVisualStyleBackColor = true;
            buttonCargar.Click += buttonCargar_Click;
            // 
            // nombreEmpleado
            // 
            nombreEmpleado.Dock = DockStyle.Top;
            nombreEmpleado.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            nombreEmpleado.Location = new Point(0, 0);
            nombreEmpleado.Name = "nombreEmpleado";
            nombreEmpleado.Size = new Size(540, 72);
            nombreEmpleado.TabIndex = 2;
            nombreEmpleado.Text = "label1";
            nombreEmpleado.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // CargarServicio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(540, 408);
            Controls.Add(nombreEmpleado);
            Controls.Add(buttonCargar);
            Controls.Add(comboBoxServicios);
            Name = "CargarServicio";
            Text = "CargarServicio";
            Load += CargarServicio_Load;
            ResumeLayout(false);
        }

        #endregion

        private ComboBox comboBoxServicios;
        private Button buttonCargar;
        private Label nombreEmpleado;
    }
}