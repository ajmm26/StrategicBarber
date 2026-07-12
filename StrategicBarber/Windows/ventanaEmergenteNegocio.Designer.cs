namespace StrategicBarber.Windows
{
    partial class ventanaEmergenteNegocio
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
            tituloVentanaEmergenteneg = new Label();
            inputVentanaEmerNeg = new TextBox();
            buttonModificarNeg = new Button();
            minitituloVentanaEmerNeg = new Label();
            SuspendLayout();
            // 
            // tituloVentanaEmergenteneg
            // 
            tituloVentanaEmergenteneg.AutoSize = true;
            tituloVentanaEmergenteneg.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tituloVentanaEmergenteneg.Location = new Point(126, 57);
            tituloVentanaEmergenteneg.Name = "tituloVentanaEmergenteneg";
            tituloVentanaEmergenteneg.Size = new Size(213, 21);
            tituloVentanaEmergenteneg.TabIndex = 0;
            tituloVentanaEmergenteneg.Text = "Modificar Nombre Negocio";
            // 
            // inputVentanaEmerNeg
            // 
            inputVentanaEmerNeg.Location = new Point(140, 136);
            inputVentanaEmerNeg.Name = "inputVentanaEmerNeg";
            inputVentanaEmerNeg.PlaceholderText = "Nombre";
            inputVentanaEmerNeg.Size = new Size(172, 23);
            inputVentanaEmerNeg.TabIndex = 1;
            // 
            // buttonModificarNeg
            // 
            buttonModificarNeg.Location = new Point(168, 206);
            buttonModificarNeg.Name = "buttonModificarNeg";
            buttonModificarNeg.Size = new Size(98, 35);
            buttonModificarNeg.TabIndex = 2;
            buttonModificarNeg.Text = "Modificar";
            buttonModificarNeg.UseVisualStyleBackColor = true;
            buttonModificarNeg.Click += buttonModificarNeg_Click;
            // 
            // minitituloVentanaEmerNeg
            // 
            minitituloVentanaEmerNeg.AutoSize = true;
            minitituloVentanaEmerNeg.Location = new Point(140, 118);
            minitituloVentanaEmerNeg.Name = "minitituloVentanaEmerNeg";
            minitituloVentanaEmerNeg.Size = new Size(51, 15);
            minitituloVentanaEmerNeg.TabIndex = 3;
            minitituloVentanaEmerNeg.Text = "Nombre";
            // 
            // ventanaEmergenteNegocio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(470, 315);
            Controls.Add(minitituloVentanaEmerNeg);
            Controls.Add(buttonModificarNeg);
            Controls.Add(inputVentanaEmerNeg);
            Controls.Add(tituloVentanaEmergenteneg);
            Name = "ventanaEmergenteNegocio";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ventanaEmergenteNegocio";
            Load += ventanaEmergenteNegocio_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label tituloVentanaEmergenteneg;
        private TextBox inputVentanaEmerNeg;
        private Button buttonModificarNeg;
        private Label minitituloVentanaEmerNeg;
    }
}