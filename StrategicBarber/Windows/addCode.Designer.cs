namespace StrategicBarber.Windows
{
    partial class addCode
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
            panel1 = new Panel();
            Guardar = new Button();
            inputCodigo = new TextBox();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(Guardar);
            panel1.Controls.Add(inputCodigo);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(829, 351);
            panel1.TabIndex = 0;
            // 
            // Guardar
            // 
            Guardar.Location = new Point(331, 232);
            Guardar.Name = "Guardar";
            Guardar.Size = new Size(158, 47);
            Guardar.TabIndex = 2;
            Guardar.Text = "Guardar";
            Guardar.UseVisualStyleBackColor = true;
            Guardar.Click += Guardar_Click;
            // 
            // inputCodigo
            // 
            inputCodigo.Location = new Point(149, 93);
            inputCodigo.Multiline = true;
            inputCodigo.Name = "inputCodigo";
            inputCodigo.PlaceholderText = "Ingrese su codigo";
            inputCodigo.Size = new Size(537, 112);
            inputCodigo.TabIndex = 1;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(825, 41);
            label1.TabIndex = 0;
            label1.Text = "Ingresar Codigo Plan Anual";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // addCode
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(829, 351);
            Controls.Add(panel1);
            Name = "addCode";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "addCode";
            Load += addCode_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button Guardar;
        private TextBox inputCodigo;
        private Label label1;
    }
}