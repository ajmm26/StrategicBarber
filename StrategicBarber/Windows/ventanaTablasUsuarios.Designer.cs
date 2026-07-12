namespace StrategicBarber.Windows
{
    partial class ventanaTablasUsuarios
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
            panel2 = new Panel();
            dtgvUsuarios = new DataGridView();
            panelCantidadPaginas = new Panel();
            panel3 = new Panel();
            buttonBuscarUsuario = new Button();
            textBox1 = new TextBox();
            label1 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgvUsuarios).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(878, 580);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.AutoSize = true;
            panel2.Controls.Add(dtgvUsuarios);
            panel2.Controls.Add(panelCantidadPaginas);
            panel2.Controls.Add(panel3);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 45);
            panel2.Name = "panel2";
            panel2.Size = new Size(878, 535);
            panel2.TabIndex = 1;
            // 
            // dtgvUsuarios
            // 
            dtgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvUsuarios.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dtgvUsuarios.BackgroundColor = SystemColors.ButtonHighlight;
            dtgvUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgvUsuarios.Dock = DockStyle.Fill;
            dtgvUsuarios.Location = new Point(0, 54);
            dtgvUsuarios.Name = "dtgvUsuarios";
            dtgvUsuarios.Size = new Size(878, 438);
            dtgvUsuarios.TabIndex = 3;
            // 
            // panelCantidadPaginas
            // 
            panelCantidadPaginas.Dock = DockStyle.Bottom;
            panelCantidadPaginas.Location = new Point(0, 492);
            panelCantidadPaginas.Name = "panelCantidadPaginas";
            panelCantidadPaginas.Size = new Size(878, 43);
            panelCantidadPaginas.TabIndex = 2;
            // 
            // panel3
            // 
            panel3.Controls.Add(buttonBuscarUsuario);
            panel3.Controls.Add(textBox1);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(878, 54);
            panel3.TabIndex = 0;
            // 
            // buttonBuscarUsuario
            // 
            buttonBuscarUsuario.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            buttonBuscarUsuario.Location = new Point(772, 17);
            buttonBuscarUsuario.Name = "buttonBuscarUsuario";
            buttonBuscarUsuario.Size = new Size(75, 23);
            buttonBuscarUsuario.TabIndex = 1;
            buttonBuscarUsuario.Text = "Buscar";
            buttonBuscarUsuario.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            textBox1.Location = new Point(560, 17);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Usuario";
            textBox1.Size = new Size(190, 23);
            textBox1.TabIndex = 0;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Padding = new Padding(50, 0, 50, 0);
            label1.Size = new Size(878, 45);
            label1.TabIndex = 0;
            label1.Text = "Usuarios Registrados";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ventanaTablas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(878, 580);
            Controls.Add(panel1);
            Name = "ventanaTablas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Usuarios";
            Load += ventanaTablas_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dtgvUsuarios).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Label label1;
        private Panel panel3;
        private Button buttonBuscarUsuario;
        private TextBox textBox1;
        private Panel panelCantidadPaginas;
        private DataGridView dtgvUsuarios;
    }
}