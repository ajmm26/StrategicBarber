namespace StrategicBarber.Windows
{
    partial class ventanaTablaEmpleados
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
            panelFlp = new Panel();
            flpButtons = new FlowLayoutPanel();
            dtgvEmpleados = new DataGridView();
            panel1.SuspendLayout();
            panelFlp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgvEmpleados).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(1015, 51);
            label1.TabIndex = 0;
            label1.Text = "Empleados registrados";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.Controls.Add(panelFlp);
            panel1.Controls.Add(dtgvEmpleados);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 51);
            panel1.Name = "panel1";
            panel1.Size = new Size(1015, 562);
            panel1.TabIndex = 1;
            // 
            // panelFlp
            // 
            panelFlp.Controls.Add(flpButtons);
            panelFlp.Dock = DockStyle.Bottom;
            panelFlp.Location = new Point(0, 483);
            panelFlp.Name = "panelFlp";
            panelFlp.Size = new Size(1015, 79);
            panelFlp.TabIndex = 1;
            // 
            // flpButtons
            // 
            flpButtons.Dock = DockStyle.Fill;
            flpButtons.Location = new Point(0, 0);
            flpButtons.Name = "flpButtons";
            flpButtons.Padding = new Padding(30, 10, 30, 10);
            flpButtons.Size = new Size(1015, 79);
            flpButtons.TabIndex = 0;
            // 
            // dtgvEmpleados
            // 
            dtgvEmpleados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvEmpleados.BackgroundColor = SystemColors.ButtonHighlight;
            dtgvEmpleados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgvEmpleados.Dock = DockStyle.Fill;
            dtgvEmpleados.Location = new Point(0, 0);
            dtgvEmpleados.Name = "dtgvEmpleados";
            dtgvEmpleados.Size = new Size(1015, 562);
            dtgvEmpleados.TabIndex = 0;
            // 
            // ventanaTablaEmpleados
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1015, 613);
            Controls.Add(panel1);
            Controls.Add(label1);
            Name = "ventanaTablaEmpleados";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ventanaTablaEmpleados";
            Load += ventanaTablaEmpleados_Load;
            panel1.ResumeLayout(false);
            panelFlp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dtgvEmpleados).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private DataGridView dtgvEmpleados;
        private Panel panelFlp;
        private FlowLayoutPanel flpButtons;
    }
}