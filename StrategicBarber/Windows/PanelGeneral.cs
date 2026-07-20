using StrategicBarber.Clases;
using StrategicBarber.DataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Drawing.Printing;
using System.Reflection.Emit;
using System.Text;
using System.Windows.Forms;

namespace StrategicBarber.Windows
{
    public partial class PanelGeneral : Form
    {
        private int cantAct = 0;
        private List<int> listaEmpleadosSeleccionadosID = new List<int>();
        private List<ClassEmpleado> panels = new List<ClassEmpleado>();


        public PanelGeneral()
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
        }

        private void PanelGeneral_Load(object sender, EventArgs e)
        {
            labelUserAct.Text = $"Usuario: {Session.nombre} {Session.apellido}";
            Session.OnUsuarioCambiado += ActualizarNombreUsuarioActual;

              DataBaseEmpleado dbEmp = new DataBaseEmpleado();
            if (dbEmp.GetNumberEmpleados() > 0)
            {


                DiaInicio cantEmp = new DiaInicio();
                DialogResult result = cantEmp.ShowDialog();

                if (result == DialogResult.OK && cantEmp.initCant > 0)
                {
                    cantAct = cantEmp.initCant;
                    CrearEmpleados(cantAct);
                }
                else
                {



                }

            }
        }


        private void ActualizarNombreUsuarioActual() {

            labelUserAct.Text = $"Usuario: {Session.nombre} {Session.apellido}";
        
        }
        private void CrearEmpleados(int cant)
        {

            for (int i = 0; i < cant; i++)
            {

                createBox(i);

            }


        }





        private void createBox(int i)
        {
            //PanelPrueba
            Panel contect = new Panel();
            contect.Width = 150;
            contect.Height = 230;
            contect.Margin = new Padding(70);
            contect.BorderStyle = BorderStyle.Fixed3D;

            Panel box = new Panel();
            box.BackColor = Color.LightGreen;
            box.Width = 150;
            box.Height = 150;

            System.Windows.Forms.Label l = new System.Windows.Forms.Label();
            l.Font = new System.Drawing.Font(l.Font.FontFamily, 12f);
            l.AutoSize = false;
            l.Dock = DockStyle.Fill;
            l.TextAlign = ContentAlignment.MiddleCenter;
            l.Click += (sender, e) => eventAddClick(sender, contect);
            l.MouseHover += (sender, e) => mouse_On(sender, e, box);
            l.MouseLeave += (sender, e) => mouse_Leave(sender, e, box);
            l.Cursor = Cursors.Hand;
            //Botones prueba

            Button eliminar = new Button();
            eliminar.Text = "Eliminar";
            eliminar.Height = 40;
            eliminar.Width = contect.Width;
            eliminar.Dock = DockStyle.Bottom;
            eliminar.Tag = i;
            eliminar.Click += (sender, e) => buttonEliminar_click(sender, e, contect);
            eliminar.Cursor = Cursors.Hand;

            Button modificar = new Button();
            modificar.Text = "Modificar";
            modificar.Height = 40;
            modificar.Width = contect.Width;
            modificar.Dock = DockStyle.Bottom;
            modificar.Click += (sender, e) => buttonModificar_click(sender, contect, l);
            modificar.Cursor = Cursors.Hand;

            box.Controls.Add(l);
            contect.Controls.Add(box);
            contect.Controls.Add(modificar);
            contect.Controls.Add(eliminar);
            contEmpAct.Controls.Add(contect);

        }

        private void mouse_Leave(object sender, EventArgs e, Panel box) { 
        
            box.BackColor = Color.LightGreen;

        }

        private void mouse_On(object sender, EventArgs e, Panel box)
        {
            box.BackColor = Color.ForestGreen;
        }


        private void eventAddClick(object sender, Panel contect)
        {

            System.Windows.Forms.Label p = (System.Windows.Forms.Label)sender;
            if (p.Tag == null)
            {


                ClassEmpleado empSelect = ObtenerEmpleadoElegido();



                if (empSelect.id > 0 && revisarEmpleado(empSelect) == false)
                {

                    p.Tag = empSelect;
                    listaEmpleadosSeleccionadosID.Add(empSelect.id);
                    p.Text = empSelect.nombre + " " + empSelect.apellido;
                    contect.Tag = empSelect.id;

                }
                else
                {

                    if (empSelect.id > 0)
                    {
                        MessageBox.Show("El empleado ya se encuentra activo", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }

            }
            else
            {


                CargarServicio CS = new CargarServicio((ClassEmpleado)p.Tag);
                CS.ShowDialog();

            }


        }


        private void buttonModificar_click(object sender, Panel content, System.Windows.Forms.Label l)
        {

            if (content.Tag == null)
            {

                MessageBox.Show("No hay empleado seleccionado para modificar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                listaEmpleadosSeleccionadosID.Remove((int)content.Tag);
                ClassEmpleado classEmpleado = ObtenerEmpleadoElegido();
                l.Tag = classEmpleado;
                l.Text = classEmpleado.nombre + " " + classEmpleado.apellido;
                listaEmpleadosSeleccionadosID.Add(classEmpleado.id);
            }


        }

        private void buttonEliminar_click(object sender, EventArgs e, Panel contect)
        {

            if (contect.Tag != null)
            {
                int empDeleteID = (int)contect.Tag;
                listaEmpleadosSeleccionadosID.Remove(empDeleteID);
            }

            contEmpAct.Controls.Remove(contect);

            contect.Dispose();


        }

        private bool revisarEmpleado(ClassEmpleado emp)
        {

            if (listaEmpleadosSeleccionadosID.Contains(emp.id))
            {

                return true;
            }


            return false;
        }

        private ClassEmpleado ObtenerEmpleadoElegido()
        {

            ventanaTablaEmpleados ve = new ventanaTablaEmpleados(2);
            ve.ShowDialog();
            return ve.empSelect;
        }

        ///Funciones de complemento
        private void setPositionFloatMenu(Object sender, ContextMenuStrip floatMenu)
        {

            Control control = (Control)sender;

            Point point = new Point(control.Width + 5, 0);

            floatMenu.Show(control, point);
        }

        ///Funciones click
        private void labelUsers_Click(object sender, EventArgs e)
        {
            setPositionFloatMenu(sender, floatMenuUsers);
        }
        private void labelNegocio_Click(object sender, EventArgs e)
        {
            setPositionFloatMenu(sender, floatMenuNegocio);
        }

        private void labelEmpleado_Click(object sender, EventArgs e)
        {
            setPositionFloatMenu(sender, floatMenuEmpleados);
        }


        private void labelServicios_Click(object sender, EventArgs e)
        {
            setPositionFloatMenu(sender, floatMenuServicios);
        }

        private void labelDatos_Click(object sender, EventArgs e)
        {
            setPositionFloatMenu(sender, floatMenuDatos);
        }

        private void modificarPorcentajeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ventanaEmergenteNegocio newVentana = new ventanaEmergenteNegocio(1);
            newVentana.ShowDialog();
        }

        private void modificarNombreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ventanaEmergenteNegocio newVentana = new ventanaEmergenteNegocio(0);
            newVentana.ShowDialog();
        }

        private void eliminarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ventanaTablasUsuarios newVentana = new ventanaTablasUsuarios(0);
            newVentana.ShowDialog();
        }

        private void modificarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ventanaTablasUsuarios newVentana = new ventanaTablasUsuarios(1);
            newVentana.ShowDialog();
        }

        private void agregarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CrearUsuario CU = new CrearUsuario(1);
            CU.ShowDialog();
        }

        private void agregarEmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            agregarEmpleado newEmpleado = new agregarEmpleado(0);
            newEmpleado.Show();
        }

        private void modificarEmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ventanaTablaEmpleados VE = new ventanaTablaEmpleados(1);
            VE.Show();
        }

        private void eliminarEmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ventanaTablaEmpleados VE = new ventanaTablaEmpleados(0);
            VE.Show();
        }

        private void buttonAgregarEmpAct_Click(object sender, EventArgs e)
        {
            createBox(cantAct);
            cantAct++;
        }

        private void agregarServicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VentanaServicios newV = new VentanaServicios(0);
            newV.ShowDialog();
        }

        private void modificarServicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VentanaTablaServicios NV = new VentanaTablaServicios(1);
            NV.Show();
        }

        private void diarioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DatosFacturacion DT = new DatosFacturacion("Diaria", 0);
            DT.Show();
        }

        private void mensualToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            DatosFacturacion DT = new DatosFacturacion("Mensual", 0);
            DT.Show();
        }

        private void semanalToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            DatosFacturacion DT = new DatosFacturacion("Semanal", 0);
            DT.Show();
        }

        private void semetralToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DatosFacturacion DT = new DatosFacturacion("Semestral", 0);
            DT.Show();
        }

        private void anualToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DatosFacturacion DT = new DatosFacturacion("Anual", 0);
            DT.Show();
        }

        private void fechaEspecificaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DatosFacturacion DT = new DatosFacturacion("Por Fecha", 2);
            DT.Show();
        }

        private void diarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DatosFacturacion DT = new DatosFacturacion("Diaria", 0);
            DT.Show();
        }

        private void semanalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DatosFacturacion DT = new DatosFacturacion("Semanal", 0);
            DT.Show();
        }

        private void porFechaEspecificaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DatosFacturacion DT = new DatosFacturacion("Por Fecha", 0);
            DT.Show();
        }

        private void mensualToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DatosFacturacion DT = new DatosFacturacion("Mensual", 0);
            DT.Show();
        }

        private void semestralToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DatosFacturacion DT = new DatosFacturacion("Semestral", 0);
            DT.Show();
        }

        private void anualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DatosFacturacion DT = new DatosFacturacion("Anual", 0);
            DT.Show();
        }

        private void diarioToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            DatosPagos DP = new DatosPagos("Diaria", 0);
            DP.Show();
        }

        private void eliminarServicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VentanaTablaServicios newV = new VentanaTablaServicios(0);
            newV.ShowDialog();
        }

        private void recuperarEmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            restoreUser RU = new restoreUser();
            RU.ShowDialog();
        }

        private void semanalToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DatosPagos DP = new DatosPagos("Semanal", 0);
            DP.Show();
        }

        private void mensualToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            DatosPagos DP = new DatosPagos("Mensual", 0);
            DP.Show();
        }

        private void semestralToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            DatosPagos DP = new DatosPagos("Semestral", 0);
            DP.Show();
        }

        private void anualToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            DatosPagos DP = new DatosPagos("Anual", 0);
            DP.Show();
        }

        private void fechaEspecificaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DatosPagos DP = new DatosPagos("Por Fecha", 2);
            DP.Show();
        }

        private void ingresarCodigoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addCode Ac = new addCode();
            Ac.ShowDialog();
        }

        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Cierra la cola de mensajes y detiene todos los hilos del entorno
            Application.Exit();
        }

        private void buttonChangeUser_Click(object sender, EventArgs e)
        {

            Inicio ventana = new Inicio(2); 
            ventana.ShowDialog();

        }
    }
}
 
 