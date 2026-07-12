namespace StrategicBarber.Windows
{
    partial class DatosPagos
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
            Dtp2 = new DateTimePicker();
            txtHasta = new Label();
            buttonSearchDate = new Button();
            Dtp1 = new DateTimePicker();
            txtDesde = new Label();
            panelFiltroFecha = new Panel();
            radioButtonYest = new RadioButton();
            radioButtonAct = new RadioButton();
            label1 = new Label();
            panel3 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            panelTG = new Panel();
            txtTg = new Label();
            label2 = new Label();
            panelPC = new Panel();
            txtTp = new Label();
            label3 = new Label();
            panelGN = new Panel();
            txtGN = new Label();
            label4 = new Label();
            panel4 = new Panel();
            panel5 = new Panel();
            dataGridView1 = new DataGridView();
            flp1 = new FlowLayoutPanel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panelFiltroFecha.SuspendLayout();
            panel3.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panelTG.SuspendLayout();
            panelPC.SuspendLayout();
            panelGN.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(panelFiltroFecha);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1269, 76);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(Dtp2);
            panel2.Controls.Add(txtHasta);
            panel2.Controls.Add(buttonSearchDate);
            panel2.Controls.Add(Dtp1);
            panel2.Controls.Add(txtDesde);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(314, 76);
            panel2.TabIndex = 4;
            // 
            // Dtp2
            // 
            Dtp2.Location = new Point(55, 47);
            Dtp2.Name = "Dtp2";
            Dtp2.Size = new Size(167, 23);
            Dtp2.TabIndex = 4;
            Dtp2.Visible = false;
            // 
            // txtHasta
            // 
            txtHasta.AutoSize = true;
            txtHasta.Location = new Point(12, 51);
            txtHasta.Name = "txtHasta";
            txtHasta.Size = new Size(37, 15);
            txtHasta.TabIndex = 1;
            txtHasta.Text = "Hasta";
            txtHasta.Visible = false;
            // 
            // buttonSearchDate
            // 
            buttonSearchDate.Location = new Point(239, 31);
            buttonSearchDate.Name = "buttonSearchDate";
            buttonSearchDate.Size = new Size(75, 23);
            buttonSearchDate.TabIndex = 2;
            buttonSearchDate.Text = "Buscar";
            buttonSearchDate.UseVisualStyleBackColor = true;
            buttonSearchDate.Visible = false;
            buttonSearchDate.Click += buttonSearchDate_Click;
            // 
            // Dtp1
            // 
            Dtp1.Location = new Point(57, 3);
            Dtp1.Name = "Dtp1";
            Dtp1.Size = new Size(167, 23);
            Dtp1.TabIndex = 3;
            Dtp1.Visible = false;
            // 
            // txtDesde
            // 
            txtDesde.AutoSize = true;
            txtDesde.Location = new Point(12, 9);
            txtDesde.Name = "txtDesde";
            txtDesde.Size = new Size(39, 15);
            txtDesde.TabIndex = 0;
            txtDesde.Text = "Desde";
            txtDesde.Visible = false;
            // 
            // panelFiltroFecha
            // 
            panelFiltroFecha.Controls.Add(radioButtonYest);
            panelFiltroFecha.Controls.Add(radioButtonAct);
            panelFiltroFecha.Dock = DockStyle.Right;
            panelFiltroFecha.Location = new Point(911, 0);
            panelFiltroFecha.Name = "panelFiltroFecha";
            panelFiltroFecha.Size = new Size(358, 76);
            panelFiltroFecha.TabIndex = 1;
            // 
            // radioButtonYest
            // 
            radioButtonYest.AutoSize = true;
            radioButtonYest.Location = new Point(49, 51);
            radioButtonYest.Name = "radioButtonYest";
            radioButtonYest.Size = new Size(94, 19);
            radioButtonYest.TabIndex = 1;
            radioButtonYest.TabStop = true;
            radioButtonYest.Text = "radioButton2";
            radioButtonYest.UseVisualStyleBackColor = true;
            radioButtonYest.CheckedChanged += radioButtonYest_CheckedChanged;
            // 
            // radioButtonAct
            // 
            radioButtonAct.AutoSize = true;
            radioButtonAct.Location = new Point(49, 12);
            radioButtonAct.Name = "radioButtonAct";
            radioButtonAct.Size = new Size(94, 19);
            radioButtonAct.TabIndex = 0;
            radioButtonAct.TabStop = true;
            radioButtonAct.Text = "radioButton1";
            radioButtonAct.UseVisualStyleBackColor = true;
            radioButtonAct.CheckedChanged += radioButtonAct_CheckedChanged;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(1269, 76);
            label1.TabIndex = 0;
            label1.Text = "Liquidacion y Pagos";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            panel3.Controls.Add(tableLayoutPanel1);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 76);
            panel3.Name = "panel3";
            panel3.Size = new Size(1269, 306);
            panel3.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.Controls.Add(panelTG, 0, 0);
            tableLayoutPanel1.Controls.Add(panelPC, 1, 0);
            tableLayoutPanel1.Controls.Add(panelGN, 2, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(1269, 306);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panelTG
            // 
            panelTG.Anchor = AnchorStyles.None;
            panelTG.BackColor = SystemColors.HighlightText;
            panelTG.BorderStyle = BorderStyle.FixedSingle;
            panelTG.Controls.Add(txtTg);
            panelTG.Controls.Add(label2);
            panelTG.Location = new Point(25, 29);
            panelTG.Name = "panelTG";
            panelTG.Size = new Size(373, 247);
            panelTG.TabIndex = 4;
            // 
            // txtTg
            // 
            txtTg.Dock = DockStyle.Fill;
            txtTg.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtTg.Location = new Point(0, 44);
            txtTg.Name = "txtTg";
            txtTg.Size = new Size(371, 201);
            txtTg.TabIndex = 1;
            txtTg.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.Dock = DockStyle.Top;
            label2.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.DodgerBlue;
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(371, 44);
            label2.TabIndex = 0;
            label2.Text = "TOTAL GENERADO";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelPC
            // 
            panelPC.Anchor = AnchorStyles.None;
            panelPC.BackColor = SystemColors.HighlightText;
            panelPC.BorderStyle = BorderStyle.FixedSingle;
            panelPC.Controls.Add(txtTp);
            panelPC.Controls.Add(label3);
            panelPC.Location = new Point(448, 29);
            panelPC.Name = "panelPC";
            panelPC.Size = new Size(373, 247);
            panelPC.TabIndex = 3;
            // 
            // txtTp
            // 
            txtTp.Dock = DockStyle.Fill;
            txtTp.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtTp.Location = new Point(0, 44);
            txtTp.Name = "txtTp";
            txtTp.Size = new Size(371, 201);
            txtTp.TabIndex = 2;
            txtTp.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.Dock = DockStyle.Top;
            label3.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.DarkOrange;
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(371, 44);
            label3.TabIndex = 0;
            label3.Text = "TOTAL A PAGAR (COMISIONES)";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelGN
            // 
            panelGN.Anchor = AnchorStyles.None;
            panelGN.BackColor = SystemColors.HighlightText;
            panelGN.BorderStyle = BorderStyle.FixedSingle;
            panelGN.Controls.Add(txtGN);
            panelGN.Controls.Add(label4);
            panelGN.Location = new Point(871, 29);
            panelGN.Name = "panelGN";
            panelGN.Size = new Size(373, 247);
            panelGN.TabIndex = 2;
            // 
            // txtGN
            // 
            txtGN.Dock = DockStyle.Fill;
            txtGN.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtGN.Location = new Point(0, 44);
            txtGN.Name = "txtGN";
            txtGN.Size = new Size(371, 201);
            txtGN.TabIndex = 2;
            txtGN.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.Dock = DockStyle.Top;
            label4.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.LimeGreen;
            label4.Location = new Point(0, 0);
            label4.Name = "label4";
            label4.Size = new Size(371, 44);
            label4.TabIndex = 1;
            label4.Text = "GANANCIA NETA SALON";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            panel4.Controls.Add(flp1);
            panel4.Dock = DockStyle.Bottom;
            panel4.Location = new Point(0, 615);
            panel4.Name = "panel4";
            panel4.Size = new Size(1269, 34);
            panel4.TabIndex = 2;
            // 
            // panel5
            // 
            panel5.Controls.Add(dataGridView1);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(0, 382);
            panel5.Name = "panel5";
            panel5.Size = new Size(1269, 233);
            panel5.TabIndex = 3;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = SystemColors.ButtonHighlight;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(1269, 233);
            dataGridView1.TabIndex = 0;
            // 
            // flp1
            // 
            flp1.Dock = DockStyle.Fill;
            flp1.Location = new Point(0, 0);
            flp1.Name = "flp1";
            flp1.Size = new Size(1269, 34);
            flp1.TabIndex = 0;
            // 
            // DatosPagos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1269, 649);
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Name = "DatosPagos";
            Text = "DatosPagos";
            Load += DatosPagos_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panelFiltroFecha.ResumeLayout(false);
            panelFiltroFecha.PerformLayout();
            panel3.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            panelTG.ResumeLayout(false);
            panelPC.ResumeLayout(false);
            panelGN.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panelFiltroFecha;
        private Label label1;
        private RadioButton radioButtonYest;
        private RadioButton radioButtonAct;
        private Panel panel3;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel4;
        private Panel panel5;
        private DataGridView dataGridView1;
        private Panel panelGN;
        private Panel panelTG;
        private Panel panelPC;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label txtTg;
        private Label txtTp;
        private Label txtGN;
        private Panel panel2;
        private DateTimePicker Dtp2;
        private Label txtHasta;
        private Button buttonSearchDate;
        private DateTimePicker Dtp1;
        private Label txtDesde;
        private FlowLayoutPanel flp1;
    }
}