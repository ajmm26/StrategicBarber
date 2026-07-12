namespace StrategicBarber.Windows
{
    partial class restoreUser
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
            txtBoxDni = new TextBox();
            buttonRestore = new Button();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(556, 53);
            label1.TabIndex = 0;
            label1.Text = "Recuperar Usuario";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtBoxDni
            // 
            txtBoxDni.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtBoxDni.Location = new Point(169, 141);
            txtBoxDni.Name = "txtBoxDni";
            txtBoxDni.PlaceholderText = "DNI";
            txtBoxDni.Size = new Size(218, 23);
            txtBoxDni.TabIndex = 1;
            // 
            // buttonRestore
            // 
            buttonRestore.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            buttonRestore.Location = new Point(216, 184);
            buttonRestore.Name = "buttonRestore";
            buttonRestore.Size = new Size(111, 33);
            buttonRestore.TabIndex = 2;
            buttonRestore.Text = "Recuperar";
            buttonRestore.UseVisualStyleBackColor = true;
            buttonRestore.Click += buttonRestore_Click;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(169, 123);
            label2.Name = "label2";
            label2.Size = new Size(27, 15);
            label2.TabIndex = 3;
            label2.Text = "DNI";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.Location = new Point(74, 82);
            label3.Name = "label3";
            label3.Size = new Size(433, 15);
            label3.TabIndex = 4;
            label3.Text = "Si la persona ya fue registrada alguna vez, Ingrese su DNI (Unicamente numeros)";
            // 
            // restoreUser
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(556, 278);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(buttonRestore);
            Controls.Add(txtBoxDni);
            Controls.Add(label1);
            Name = "restoreUser";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "restoreUser";
            Load += restoreUser_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtBoxDni;
        private Button buttonRestore;
        private Label label2;
        private Label label3;
    }
}