namespace StrategicBarber.Windows
{
    partial class PanelGeneral
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
            components = new System.ComponentModel.Container();
            tableLayoutPanel1 = new TableLayoutPanel();
            labelDatos = new Label();
            labelServicios = new Label();
            labelUsers = new Label();
            labelEmpleado = new Label();
            labelNegocio = new Label();
            panel1 = new Panel();
            panelEmpAct = new Panel();
            contEmpAct = new FlowLayoutPanel();
            panel2 = new Panel();
            buttonAgregarEmpAct = new Button();
            floatMenuUsers = new ContextMenuStrip(components);
            agregarUsuarioToolStripMenuItem = new ToolStripMenuItem();
            eliminarUsuarioToolStripMenuItem = new ToolStripMenuItem();
            modificarUsuarioToolStripMenuItem = new ToolStripMenuItem();
            floatMenuNegocio = new ContextMenuStrip(components);
            modificarPorcentajeToolStripMenuItem = new ToolStripMenuItem();
            modificarNombreToolStripMenuItem = new ToolStripMenuItem();
            floatMenuEmpleados = new ContextMenuStrip(components);
            agregarEmpleadoToolStripMenuItem = new ToolStripMenuItem();
            modificarEmpleadoToolStripMenuItem = new ToolStripMenuItem();
            recuperarEmpleadoToolStripMenuItem = new ToolStripMenuItem();
            eliminarEmpleadoToolStripMenuItem = new ToolStripMenuItem();
            floatMenuServicios = new ContextMenuStrip(components);
            agregarServicioToolStripMenuItem = new ToolStripMenuItem();
            modificarServicioToolStripMenuItem = new ToolStripMenuItem();
            eliminarServicioToolStripMenuItem = new ToolStripMenuItem();
            floatMenuDatos = new ContextMenuStrip(components);
            verFacturacionToolStripMenuItem = new ToolStripMenuItem();
            anualToolStripMenuItem1 = new ToolStripMenuItem();
            semetralToolStripMenuItem = new ToolStripMenuItem();
            mensualToolStripMenuItem2 = new ToolStripMenuItem();
            semanalToolStripMenuItem3 = new ToolStripMenuItem();
            diarioToolStripMenuItem1 = new ToolStripMenuItem();
            fechaEspecificaToolStripMenuItem = new ToolStripMenuItem();
            verCantidadAPagarToolStripMenuItem = new ToolStripMenuItem();
            anualToolStripMenuItem2 = new ToolStripMenuItem();
            semestralToolStripMenuItem2 = new ToolStripMenuItem();
            mensualToolStripMenuItem3 = new ToolStripMenuItem();
            semanalToolStripMenuItem1 = new ToolStripMenuItem();
            diarioToolStripMenuItem2 = new ToolStripMenuItem();
            fechaEspecificaToolStripMenuItem1 = new ToolStripMenuItem();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            panelEmpAct.SuspendLayout();
            panel2.SuspendLayout();
            floatMenuUsers.SuspendLayout();
            floatMenuNegocio.SuspendLayout();
            floatMenuEmpleados.SuspendLayout();
            floatMenuServicios.SuspendLayout();
            floatMenuDatos.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Outset;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Controls.Add(labelDatos, 0, 4);
            tableLayoutPanel1.Controls.Add(labelServicios, 0, 3);
            tableLayoutPanel1.Controls.Add(labelUsers, 0, 1);
            tableLayoutPanel1.Controls.Add(labelEmpleado, 0, 2);
            tableLayoutPanel1.Controls.Add(labelNegocio, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Left;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20.0000038F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 19.9999981F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 19.9999981F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20.0000038F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 19.9999981F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(200, 665);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // labelDatos
            // 
            labelDatos.AutoSize = true;
            labelDatos.Dock = DockStyle.Fill;
            labelDatos.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            labelDatos.Location = new Point(5, 530);
            labelDatos.Name = "labelDatos";
            labelDatos.Size = new Size(190, 133);
            labelDatos.TabIndex = 5;
            labelDatos.Text = "Datos";
            labelDatos.TextAlign = ContentAlignment.MiddleCenter;
            labelDatos.Click += labelDatos_Click;
            // 
            // labelServicios
            // 
            labelServicios.AutoSize = true;
            labelServicios.Dock = DockStyle.Fill;
            labelServicios.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            labelServicios.Location = new Point(5, 398);
            labelServicios.Name = "labelServicios";
            labelServicios.Size = new Size(190, 130);
            labelServicios.TabIndex = 4;
            labelServicios.Text = "Servicios";
            labelServicios.TextAlign = ContentAlignment.MiddleCenter;
            labelServicios.Click += labelServicios_Click;
            // 
            // labelUsers
            // 
            labelUsers.AutoSize = true;
            labelUsers.Dock = DockStyle.Fill;
            labelUsers.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            labelUsers.Location = new Point(5, 134);
            labelUsers.Name = "labelUsers";
            labelUsers.Size = new Size(190, 130);
            labelUsers.TabIndex = 0;
            labelUsers.Text = "Usuarios";
            labelUsers.TextAlign = ContentAlignment.MiddleCenter;
            labelUsers.Click += labelUsers_Click;
            // 
            // labelEmpleado
            // 
            labelEmpleado.AutoSize = true;
            labelEmpleado.Cursor = Cursors.Hand;
            labelEmpleado.Dock = DockStyle.Fill;
            labelEmpleado.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            labelEmpleado.Location = new Point(5, 266);
            labelEmpleado.Name = "labelEmpleado";
            labelEmpleado.Size = new Size(190, 130);
            labelEmpleado.TabIndex = 3;
            labelEmpleado.Text = "Empleados";
            labelEmpleado.TextAlign = ContentAlignment.MiddleCenter;
            labelEmpleado.Click += labelEmpleado_Click;
            // 
            // labelNegocio
            // 
            labelNegocio.AutoSize = true;
            labelNegocio.Cursor = Cursors.Hand;
            labelNegocio.Dock = DockStyle.Fill;
            labelNegocio.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic);
            labelNegocio.Location = new Point(5, 2);
            labelNegocio.Name = "labelNegocio";
            labelNegocio.Size = new Size(190, 130);
            labelNegocio.TabIndex = 2;
            labelNegocio.Text = "Negocio";
            labelNegocio.TextAlign = ContentAlignment.MiddleCenter;
            labelNegocio.Click += labelNegocio_Click;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(panelEmpAct);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(200, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(742, 665);
            panel1.TabIndex = 1;
            // 
            // panelEmpAct
            // 
            panelEmpAct.Controls.Add(contEmpAct);
            panelEmpAct.Dock = DockStyle.Fill;
            panelEmpAct.Location = new Point(0, 54);
            panelEmpAct.Name = "panelEmpAct";
            panelEmpAct.Size = new Size(738, 607);
            panelEmpAct.TabIndex = 1;
            // 
            // contEmpAct
            // 
            contEmpAct.AutoScroll = true;
            contEmpAct.BackgroundImage = Properties.Resources.OIP__5_;
            contEmpAct.Dock = DockStyle.Fill;
            contEmpAct.Location = new Point(0, 0);
            contEmpAct.Name = "contEmpAct";
            contEmpAct.Size = new Size(738, 607);
            contEmpAct.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(buttonAgregarEmpAct);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(738, 54);
            panel2.TabIndex = 0;
            // 
            // buttonAgregarEmpAct
            // 
            buttonAgregarEmpAct.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonAgregarEmpAct.Location = new Point(495, 10);
            buttonAgregarEmpAct.Name = "buttonAgregarEmpAct";
            buttonAgregarEmpAct.Size = new Size(240, 38);
            buttonAgregarEmpAct.TabIndex = 0;
            buttonAgregarEmpAct.Text = "Agregar Empleado activo";
            buttonAgregarEmpAct.UseVisualStyleBackColor = true;
            buttonAgregarEmpAct.Click += buttonAgregarEmpAct_Click;
            // 
            // floatMenuUsers
            // 
            floatMenuUsers.Items.AddRange(new ToolStripItem[] { agregarUsuarioToolStripMenuItem, eliminarUsuarioToolStripMenuItem, modificarUsuarioToolStripMenuItem });
            floatMenuUsers.Name = "contextMenuStrip1";
            floatMenuUsers.Size = new Size(169, 70);
            // 
            // agregarUsuarioToolStripMenuItem
            // 
            agregarUsuarioToolStripMenuItem.Name = "agregarUsuarioToolStripMenuItem";
            agregarUsuarioToolStripMenuItem.Size = new Size(168, 22);
            agregarUsuarioToolStripMenuItem.Text = "Agregar Usuario";
            agregarUsuarioToolStripMenuItem.Click += agregarUsuarioToolStripMenuItem_Click;
            // 
            // eliminarUsuarioToolStripMenuItem
            // 
            eliminarUsuarioToolStripMenuItem.Name = "eliminarUsuarioToolStripMenuItem";
            eliminarUsuarioToolStripMenuItem.Size = new Size(168, 22);
            eliminarUsuarioToolStripMenuItem.Text = "Eliminar Usuario";
            eliminarUsuarioToolStripMenuItem.Click += eliminarUsuarioToolStripMenuItem_Click;
            // 
            // modificarUsuarioToolStripMenuItem
            // 
            modificarUsuarioToolStripMenuItem.Name = "modificarUsuarioToolStripMenuItem";
            modificarUsuarioToolStripMenuItem.Size = new Size(168, 22);
            modificarUsuarioToolStripMenuItem.Text = "Modificar Usuario";
            modificarUsuarioToolStripMenuItem.Click += modificarUsuarioToolStripMenuItem_Click;
            // 
            // floatMenuNegocio
            // 
            floatMenuNegocio.Items.AddRange(new ToolStripItem[] { modificarPorcentajeToolStripMenuItem, modificarNombreToolStripMenuItem });
            floatMenuNegocio.Name = "contextMenuStrip1";
            floatMenuNegocio.Size = new Size(222, 48);
            // 
            // modificarPorcentajeToolStripMenuItem
            // 
            modificarPorcentajeToolStripMenuItem.Name = "modificarPorcentajeToolStripMenuItem";
            modificarPorcentajeToolStripMenuItem.Size = new Size(221, 22);
            modificarPorcentajeToolStripMenuItem.Text = "Modificar Porcentaje Global";
            modificarPorcentajeToolStripMenuItem.Click += modificarPorcentajeToolStripMenuItem_Click;
            // 
            // modificarNombreToolStripMenuItem
            // 
            modificarNombreToolStripMenuItem.Name = "modificarNombreToolStripMenuItem";
            modificarNombreToolStripMenuItem.Size = new Size(221, 22);
            modificarNombreToolStripMenuItem.Text = "Modificar Nombre";
            modificarNombreToolStripMenuItem.Click += modificarNombreToolStripMenuItem_Click;
            // 
            // floatMenuEmpleados
            // 
            floatMenuEmpleados.Items.AddRange(new ToolStripItem[] { agregarEmpleadoToolStripMenuItem, modificarEmpleadoToolStripMenuItem, recuperarEmpleadoToolStripMenuItem, eliminarEmpleadoToolStripMenuItem });
            floatMenuEmpleados.Name = "floatMenuEmpleados";
            floatMenuEmpleados.Size = new Size(184, 92);
            // 
            // agregarEmpleadoToolStripMenuItem
            // 
            agregarEmpleadoToolStripMenuItem.Name = "agregarEmpleadoToolStripMenuItem";
            agregarEmpleadoToolStripMenuItem.Size = new Size(183, 22);
            agregarEmpleadoToolStripMenuItem.Text = "Agregar Empleado";
            agregarEmpleadoToolStripMenuItem.Click += agregarEmpleadoToolStripMenuItem_Click;
            // 
            // modificarEmpleadoToolStripMenuItem
            // 
            modificarEmpleadoToolStripMenuItem.Name = "modificarEmpleadoToolStripMenuItem";
            modificarEmpleadoToolStripMenuItem.Size = new Size(183, 22);
            modificarEmpleadoToolStripMenuItem.Text = "Modificar Empleado";
            modificarEmpleadoToolStripMenuItem.Click += modificarEmpleadoToolStripMenuItem_Click;
            // 
            // recuperarEmpleadoToolStripMenuItem
            // 
            recuperarEmpleadoToolStripMenuItem.Name = "recuperarEmpleadoToolStripMenuItem";
            recuperarEmpleadoToolStripMenuItem.Size = new Size(183, 22);
            recuperarEmpleadoToolStripMenuItem.Text = "Recuperar Empleado";
            recuperarEmpleadoToolStripMenuItem.Click += recuperarEmpleadoToolStripMenuItem_Click;
            // 
            // eliminarEmpleadoToolStripMenuItem
            // 
            eliminarEmpleadoToolStripMenuItem.Name = "eliminarEmpleadoToolStripMenuItem";
            eliminarEmpleadoToolStripMenuItem.Size = new Size(183, 22);
            eliminarEmpleadoToolStripMenuItem.Text = "Eliminar Empleado";
            eliminarEmpleadoToolStripMenuItem.Click += eliminarEmpleadoToolStripMenuItem_Click;
            // 
            // floatMenuServicios
            // 
            floatMenuServicios.Items.AddRange(new ToolStripItem[] { agregarServicioToolStripMenuItem, modificarServicioToolStripMenuItem, eliminarServicioToolStripMenuItem });
            floatMenuServicios.Name = "floatMenuServicios";
            floatMenuServicios.Size = new Size(170, 70);
            // 
            // agregarServicioToolStripMenuItem
            // 
            agregarServicioToolStripMenuItem.Name = "agregarServicioToolStripMenuItem";
            agregarServicioToolStripMenuItem.Size = new Size(169, 22);
            agregarServicioToolStripMenuItem.Text = "Agregar Servicio";
            agregarServicioToolStripMenuItem.Click += agregarServicioToolStripMenuItem_Click;
            // 
            // modificarServicioToolStripMenuItem
            // 
            modificarServicioToolStripMenuItem.Name = "modificarServicioToolStripMenuItem";
            modificarServicioToolStripMenuItem.Size = new Size(169, 22);
            modificarServicioToolStripMenuItem.Text = "Modificar Servicio";
            modificarServicioToolStripMenuItem.Click += modificarServicioToolStripMenuItem_Click;
            // 
            // eliminarServicioToolStripMenuItem
            // 
            eliminarServicioToolStripMenuItem.Name = "eliminarServicioToolStripMenuItem";
            eliminarServicioToolStripMenuItem.Size = new Size(169, 22);
            eliminarServicioToolStripMenuItem.Text = "Eliminar Servicio";
            eliminarServicioToolStripMenuItem.Click += eliminarServicioToolStripMenuItem_Click;
            // 
            // floatMenuDatos
            // 
            floatMenuDatos.Items.AddRange(new ToolStripItem[] { verFacturacionToolStripMenuItem, verCantidadAPagarToolStripMenuItem });
            floatMenuDatos.Name = "floatMenuDatos";
            floatMenuDatos.Size = new Size(184, 70);
            // 
            // verFacturacionToolStripMenuItem
            // 
            verFacturacionToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { anualToolStripMenuItem1, semetralToolStripMenuItem, mensualToolStripMenuItem2, semanalToolStripMenuItem3, diarioToolStripMenuItem1, fechaEspecificaToolStripMenuItem });
            verFacturacionToolStripMenuItem.Name = "verFacturacionToolStripMenuItem";
            verFacturacionToolStripMenuItem.Size = new Size(183, 22);
            verFacturacionToolStripMenuItem.Text = "Ver facturacion";
            // 
            // anualToolStripMenuItem1
            // 
            anualToolStripMenuItem1.Name = "anualToolStripMenuItem1";
            anualToolStripMenuItem1.Size = new Size(160, 22);
            anualToolStripMenuItem1.Text = "Anual";
            anualToolStripMenuItem1.Click += anualToolStripMenuItem1_Click;
            // 
            // semetralToolStripMenuItem
            // 
            semetralToolStripMenuItem.Name = "semetralToolStripMenuItem";
            semetralToolStripMenuItem.Size = new Size(160, 22);
            semetralToolStripMenuItem.Text = "Semetral";
            semetralToolStripMenuItem.Click += semetralToolStripMenuItem_Click;
            // 
            // mensualToolStripMenuItem2
            // 
            mensualToolStripMenuItem2.Name = "mensualToolStripMenuItem2";
            mensualToolStripMenuItem2.Size = new Size(160, 22);
            mensualToolStripMenuItem2.Text = "Mensual";
            mensualToolStripMenuItem2.Click += mensualToolStripMenuItem2_Click;
            // 
            // semanalToolStripMenuItem3
            // 
            semanalToolStripMenuItem3.Name = "semanalToolStripMenuItem3";
            semanalToolStripMenuItem3.Size = new Size(160, 22);
            semanalToolStripMenuItem3.Text = "Semanal";
            semanalToolStripMenuItem3.Click += semanalToolStripMenuItem3_Click;
            // 
            // diarioToolStripMenuItem1
            // 
            diarioToolStripMenuItem1.Name = "diarioToolStripMenuItem1";
            diarioToolStripMenuItem1.Size = new Size(160, 22);
            diarioToolStripMenuItem1.Text = "Diario";
            diarioToolStripMenuItem1.Click += diarioToolStripMenuItem1_Click;
            // 
            // fechaEspecificaToolStripMenuItem
            // 
            fechaEspecificaToolStripMenuItem.Name = "fechaEspecificaToolStripMenuItem";
            fechaEspecificaToolStripMenuItem.Size = new Size(160, 22);
            fechaEspecificaToolStripMenuItem.Text = "Fecha especifica";
            fechaEspecificaToolStripMenuItem.Click += fechaEspecificaToolStripMenuItem_Click;
            // 
            // verCantidadAPagarToolStripMenuItem
            // 
            verCantidadAPagarToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { anualToolStripMenuItem2, semestralToolStripMenuItem2, mensualToolStripMenuItem3, semanalToolStripMenuItem1, diarioToolStripMenuItem2, fechaEspecificaToolStripMenuItem1 });
            verCantidadAPagarToolStripMenuItem.Name = "verCantidadAPagarToolStripMenuItem";
            verCantidadAPagarToolStripMenuItem.Size = new Size(183, 22);
            verCantidadAPagarToolStripMenuItem.Text = "Ver Cantidad a pagar";
            // 
            // anualToolStripMenuItem2
            // 
            anualToolStripMenuItem2.Name = "anualToolStripMenuItem2";
            anualToolStripMenuItem2.Size = new Size(180, 22);
            anualToolStripMenuItem2.Text = "Anual";
            anualToolStripMenuItem2.Click += anualToolStripMenuItem2_Click;
            // 
            // semestralToolStripMenuItem2
            // 
            semestralToolStripMenuItem2.Name = "semestralToolStripMenuItem2";
            semestralToolStripMenuItem2.Size = new Size(180, 22);
            semestralToolStripMenuItem2.Text = "Semestral";
            semestralToolStripMenuItem2.Click += semestralToolStripMenuItem2_Click;
            // 
            // mensualToolStripMenuItem3
            // 
            mensualToolStripMenuItem3.Name = "mensualToolStripMenuItem3";
            mensualToolStripMenuItem3.Size = new Size(180, 22);
            mensualToolStripMenuItem3.Text = "Mensual";
            mensualToolStripMenuItem3.Click += mensualToolStripMenuItem3_Click;
            // 
            // semanalToolStripMenuItem1
            // 
            semanalToolStripMenuItem1.Name = "semanalToolStripMenuItem1";
            semanalToolStripMenuItem1.Size = new Size(180, 22);
            semanalToolStripMenuItem1.Text = "Semanal";
            semanalToolStripMenuItem1.Click += semanalToolStripMenuItem1_Click;
            // 
            // diarioToolStripMenuItem2
            // 
            diarioToolStripMenuItem2.Name = "diarioToolStripMenuItem2";
            diarioToolStripMenuItem2.Size = new Size(180, 22);
            diarioToolStripMenuItem2.Text = "Diario";
            diarioToolStripMenuItem2.Click += diarioToolStripMenuItem2_Click;
            // 
            // fechaEspecificaToolStripMenuItem1
            // 
            fechaEspecificaToolStripMenuItem1.Name = "fechaEspecificaToolStripMenuItem1";
            fechaEspecificaToolStripMenuItem1.Size = new Size(180, 22);
            fechaEspecificaToolStripMenuItem1.Text = "Fecha Especifica";
            fechaEspecificaToolStripMenuItem1.Click += fechaEspecificaToolStripMenuItem1_Click;
            // 
            // PanelGeneral
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(942, 665);
            Controls.Add(panel1);
            Controls.Add(tableLayoutPanel1);
            Name = "PanelGeneral";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Panel General";
            Load += PanelGeneral_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            panel1.ResumeLayout(false);
            panelEmpAct.ResumeLayout(false);
            panel2.ResumeLayout(false);
            floatMenuUsers.ResumeLayout(false);
            floatMenuNegocio.ResumeLayout(false);
            floatMenuEmpleados.ResumeLayout(false);
            floatMenuServicios.ResumeLayout(false);
            floatMenuDatos.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Panel panel1;
        private Label label2;
        private Label label4;
        private Label label3;
        private Label labelDatos;
        private Label labelServicios;
        private Label labelNegocio;
        private Label labelUsers;
        private Label labelEmpleado;
        private ContextMenuStrip floatMenuNegocio;
        private ToolStripMenuItem agregarUsuarioToolStripMenuItem;
        private ToolStripMenuItem eliminarUsuarioToolStripMenuItem;
        private ToolStripMenuItem modificarUsuarioToolStripMenuItem;
        private ContextMenuStrip floatMenuUsers;
        private ToolStripMenuItem modificarPorcentajeToolStripMenuItem;
        private ToolStripMenuItem modificarPrecioSIllaToolStripMenuItem;
        private ToolStripMenuItem modificarNombreToolStripMenuItem;
        private ContextMenuStrip floatMenuEmpleados;
        private ToolStripMenuItem agregarEmpleadoToolStripMenuItem;
        private ToolStripMenuItem modificarEmpleadoToolStripMenuItem;
        private ToolStripMenuItem eliminarEmpleadoToolStripMenuItem;
        private ContextMenuStrip floatMenuServicios;
        private ToolStripMenuItem agregarServicioToolStripMenuItem;
        private ToolStripMenuItem modificarServicioToolStripMenuItem;
        private ToolStripMenuItem eliminarServicioToolStripMenuItem;
        private ContextMenuStrip floatMenuDatos;
        private ToolStripMenuItem verFacturacionToolStripMenuItem;
        private ToolStripMenuItem verCantidadAPagarToolStripMenuItem;
        private ToolStripMenuItem anualToolStripMenuItem2;
        private ToolStripMenuItem semestralToolStripMenuItem2;
        private ToolStripMenuItem mensualToolStripMenuItem3;
        private ToolStripMenuItem semanalToolStripMenuItem1;
        private ToolStripMenuItem diarioToolStripMenuItem2;
        private ToolStripMenuItem fechaEspecificaToolStripMenuItem1;
        private Panel panelEmpAct;
        private Panel panel2;
        private Button buttonAgregarEmpAct;
        private FlowLayoutPanel contEmpAct;
        private ToolStripMenuItem anualToolStripMenuItem1;
        private ToolStripMenuItem semetralToolStripMenuItem;
        private ToolStripMenuItem mensualToolStripMenuItem2;
        private ToolStripMenuItem semanalToolStripMenuItem3;
        private ToolStripMenuItem diarioToolStripMenuItem1;
        private ToolStripMenuItem fechaEspecificaToolStripMenuItem;
        private ToolStripMenuItem recuperarEmpleadoToolStripMenuItem;
    }
}