namespace StrategicBarber.Windows
{
    partial class DatosFacturacion
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
            tituloFact = new Label();
            panel1 = new Panel();
            flpanel = new FlowLayoutPanel();
            dtgvDatosFact = new DataGridView();
            panelContent = new Panel();
            Dtp2 = new DateTimePicker();
            buttonSearchDate = new Button();
            panelChart = new Panel();
            txtTotal = new Label();
            txtHasta = new Label();
            txtDesde = new Label();
            Dtp1 = new DateTimePicker();
            radioButtonAct = new RadioButton();
            radioButtonYest = new RadioButton();
            Dtp3 = new DateTimePicker();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgvDatosFact).BeginInit();
            panelContent.SuspendLayout();
            SuspendLayout();
            // 
            // tituloFact
            // 
            tituloFact.Dock = DockStyle.Top;
            tituloFact.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            tituloFact.Location = new Point(0, 0);
            tituloFact.Name = "tituloFact";
            tituloFact.Size = new Size(1270, 86);
            tituloFact.TabIndex = 0;
            tituloFact.Text = "Facturacion";
            tituloFact.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.Controls.Add(flpanel);
            panel1.Controls.Add(dtgvDatosFact);
            panel1.Controls.Add(panelContent);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 86);
            panel1.Name = "panel1";
            panel1.Size = new Size(1270, 648);
            panel1.TabIndex = 1;
            // 
            // flpanel
            // 
            flpanel.BackColor = SystemColors.HighlightText;
            flpanel.Dock = DockStyle.Bottom;
            flpanel.Location = new Point(0, 615);
            flpanel.Name = "flpanel";
            flpanel.Size = new Size(1270, 33);
            flpanel.TabIndex = 2;
            // 
            // dtgvDatosFact
            // 
            dtgvDatosFact.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvDatosFact.BackgroundColor = SystemColors.ButtonHighlight;
            dtgvDatosFact.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgvDatosFact.Dock = DockStyle.Fill;
            dtgvDatosFact.Location = new Point(0, 383);
            dtgvDatosFact.Name = "dtgvDatosFact";
            dtgvDatosFact.Size = new Size(1270, 265);
            dtgvDatosFact.TabIndex = 1;
            // 
            // panelContent
            // 
            panelContent.Controls.Add(Dtp2);
            panelContent.Controls.Add(buttonSearchDate);
            panelContent.Controls.Add(panelChart);
            panelContent.Controls.Add(txtTotal);
            panelContent.Dock = DockStyle.Top;
            panelContent.Location = new Point(0, 0);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(1270, 383);
            panelContent.TabIndex = 0;
            // 
            // Dtp2
            // 
            Dtp2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            Dtp2.Location = new Point(99, -23);
            Dtp2.Name = "Dtp2";
            Dtp2.Size = new Size(156, 23);
            Dtp2.TabIndex = 1;
            Dtp2.Value = new DateTime(2026, 7, 1, 0, 0, 0, 0);
            Dtp2.Visible = false;
            // 
            // buttonSearchDate
            // 
            buttonSearchDate.Location = new Point(118, 8);
            buttonSearchDate.Name = "buttonSearchDate";
            buttonSearchDate.Size = new Size(75, 23);
            buttonSearchDate.TabIndex = 0;
            buttonSearchDate.Text = "Buscar";
            buttonSearchDate.UseVisualStyleBackColor = true;
            buttonSearchDate.Visible = false;
            buttonSearchDate.Click += buttonSearchDate_Click;
            // 
            // panelChart
            // 
            panelChart.Dock = DockStyle.Fill;
            panelChart.Location = new Point(0, 41);
            panelChart.Name = "panelChart";
            panelChart.Size = new Size(1270, 342);
            panelChart.TabIndex = 2;
            // 
            // txtTotal
            // 
            txtTotal.Dock = DockStyle.Top;
            txtTotal.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            txtTotal.ImageAlign = ContentAlignment.TopCenter;
            txtTotal.Location = new Point(0, 0);
            txtTotal.Name = "txtTotal";
            txtTotal.Size = new Size(1270, 41);
            txtTotal.TabIndex = 1;
            txtTotal.Text = "ghnghnhgn";
            txtTotal.TextAlign = ContentAlignment.TopCenter;
            // 
            // txtHasta
            // 
            txtHasta.AutoSize = true;
            txtHasta.Location = new Point(39, 49);
            txtHasta.Name = "txtHasta";
            txtHasta.Size = new Size(37, 15);
            txtHasta.TabIndex = 3;
            txtHasta.Text = "Hasta";
            txtHasta.Visible = false;
            // 
            // txtDesde
            // 
            txtDesde.AutoSize = true;
            txtDesde.Location = new Point(37, 12);
            txtDesde.Name = "txtDesde";
            txtDesde.Size = new Size(39, 15);
            txtDesde.TabIndex = 2;
            txtDesde.Text = "Desde";
            txtDesde.Visible = false;
            // 
            // Dtp1
            // 
            Dtp1.Location = new Point(99, 8);
            Dtp1.Name = "Dtp1";
            Dtp1.Size = new Size(156, 23);
            Dtp1.TabIndex = 0;
            Dtp1.Visible = false;
            // 
            // radioButtonAct
            // 
            radioButtonAct.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            radioButtonAct.AutoSize = true;
            radioButtonAct.Checked = true;
            radioButtonAct.Location = new Point(1091, 12);
            radioButtonAct.Name = "radioButtonAct";
            radioButtonAct.Size = new Size(47, 19);
            radioButtonAct.TabIndex = 2;
            radioButtonAct.TabStop = true;
            radioButtonAct.Text = "Hoy";
            radioButtonAct.UseVisualStyleBackColor = true;
            radioButtonAct.CheckedChanged += radioButtonAct_CheckedChanged;
            // 
            // radioButtonYest
            // 
            radioButtonYest.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            radioButtonYest.AutoSize = true;
            radioButtonYest.Location = new Point(1091, 37);
            radioButtonYest.Name = "radioButtonYest";
            radioButtonYest.Size = new Size(49, 19);
            radioButtonYest.TabIndex = 3;
            radioButtonYest.Text = "Ayer";
            radioButtonYest.UseVisualStyleBackColor = true;
            radioButtonYest.CheckedChanged += radioButtonYest_CheckedChanged;
            // 
            // Dtp3
            // 
            Dtp3.Location = new Point(99, 49);
            Dtp3.Name = "Dtp3";
            Dtp3.Size = new Size(156, 23);
            Dtp3.TabIndex = 0;
            // 
            // DatosFacturacion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1270, 734);
            Controls.Add(Dtp3);
            Controls.Add(txtHasta);
            Controls.Add(radioButtonYest);
            Controls.Add(txtDesde);
            Controls.Add(Dtp1);
            Controls.Add(radioButtonAct);
            Controls.Add(panel1);
            Controls.Add(tituloFact);
            Name = "DatosFacturacion";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DatosFacturacion";
            Load += DatosFacturacion_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dtgvDatosFact).EndInit();
            panelContent.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label tituloFact;
        private Panel panel1;
        private DataGridView dtgvDatosFact;
        private Panel panelContent;
        private Label txtTotal;
        private RadioButton radioButtonAct;
        private RadioButton radioButtonYest;
        private DateTimePicker Dtp2;
        private DateTimePicker Dtp1;
        private Label txtHasta;
        private Label txtDesde;
        private Button buttonSearchDate;
        private FlowLayoutPanel flpanel;
        private Panel panelChart;
        private DateTimePicker Dpt2;
        private DateTimePicker Dtp3;
    }
}