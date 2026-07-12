namespace StrategicBarber.Windows
{
    partial class DiaInicio
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
            saludotxt = new Label();
            panel1 = new Panel();
            buttonCantEmp = new Button();
            inputCantEmp = new TextBox();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // saludotxt
            // 
            saludotxt.Dock = DockStyle.Top;
            saludotxt.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            saludotxt.Location = new Point(0, 0);
            saludotxt.Name = "saludotxt";
            saludotxt.Size = new Size(560, 56);
            saludotxt.TabIndex = 0;
            saludotxt.Text = "label1";
            saludotxt.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.Controls.Add(buttonCantEmp);
            panel1.Controls.Add(inputCantEmp);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 56);
            panel1.Name = "panel1";
            panel1.Size = new Size(560, 416);
            panel1.TabIndex = 1;
            // 
            // buttonCantEmp
            // 
            buttonCantEmp.Location = new Point(205, 245);
            buttonCantEmp.Name = "buttonCantEmp";
            buttonCantEmp.Size = new Size(148, 40);
            buttonCantEmp.TabIndex = 2;
            buttonCantEmp.Text = "Guardar";
            buttonCantEmp.UseVisualStyleBackColor = true;
            buttonCantEmp.Click += buttonCantEmp_Click;
            // 
            // inputCantEmp
            // 
            inputCantEmp.Location = new Point(152, 170);
            inputCantEmp.Name = "inputCantEmp";
            inputCantEmp.PlaceholderText = "Empleados";
            inputCantEmp.Size = new Size(261, 23);
            inputCantEmp.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Verdana", 14.25F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(118, 88);
            label1.Name = "label1";
            label1.Size = new Size(331, 23);
            label1.TabIndex = 0;
            label1.Text = "Ingresa la cantidad de empleados";
            // 
            // DiaInicio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(560, 472);
            Controls.Add(panel1);
            Controls.Add(saludotxt);
            Name = "DiaInicio";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DiaInicio";
            Load += DiaInicio_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label saludotxt;
        private Panel panel1;
        private TextBox inputCantEmp;
        private Label label1;
        private Button buttonCantEmp;
    }
}