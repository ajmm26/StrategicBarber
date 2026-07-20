using StrategicBarber.Clases;
using StrategicBarber.DataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace StrategicBarber.Windows
{
    public partial class CargarServicio : Form
    {
        private ClassEmpleado empleado;
        public CargarServicio(ClassEmpleado empleado)
        {
            this.empleado = empleado;
            InitializeComponent();
        }

        private void CargarServicio_Load(object sender, EventArgs e)
        {
            nombreEmpleado.Text = "Cargar Servicio a " + empleado.nombre + " " + empleado.apellido;
            DataBaseServicios dbServ = new DataBaseServicios();
            List<ClassServicio> listServ = dbServ.GetListServices();
            cargarComboBox(listServ);
            comboBoxServicios.SelectedIndex = 0;
        }

        private void comboBoxServicios_TextChanged(object sender, EventArgs e)
        {
            string txtEscrito = comboBoxServicios.Text; // No uses .Trim() aquí para permitir espacios mientras escribe

            // 1. 🌟 GUARDAR la posición actual del cursor
            int posicionCursor = comboBoxServicios.SelectionStart;

            DataBaseServicios dbServ = new DataBaseServicios();
            List<ClassServicio> listServ = dbServ.GetListLike(txtEscrito.Trim());

            // 2. 🌟 APAGAR el evento temporalmente para que cambiar los datos no vuelva loco al programa
            comboBoxServicios.TextChanged -= comboBoxServicios_TextChanged;

            cargarComboBox(listServ);

            // 3. 🌟 RESTAURAR el texto y el cursor a donde el usuario lo dejó
            comboBoxServicios.Text = txtEscrito;
            comboBoxServicios.SelectionStart = posicionCursor;

            // 4. 🌟 VOLVER A ENCENDER el evento
            comboBoxServicios.TextChanged += comboBoxServicios_TextChanged;

            // EXTRA: Desplegar automáticamente la lista para que el usuario vea los resultados filtrados
            comboBoxServicios.DroppedDown = false;

        }

        private void cargarComboBox(List<ClassServicio> listServ)
        {

            comboBoxServicios.DisplayMember = "nombre";
            comboBoxServicios.DataSource = listServ;
            comboBoxServicios.DroppedDown = false;

        }

        private void buttonCargar_Click(object sender, EventArgs e)
        {
            ClassServicio serv = new ClassServicio();
             serv = obtenerServicioSelect(serv);
             validarCargar(serv);


            DateTime fechaServicio = DateTime.Now;
            string fechaYHora = fechaServicio.ToString("yyyy-MM-dd HH:mm:ss");
            DataBaseServicios dbServ = new DataBaseServicios();
            int res = dbServ.insertServicesProduct(this.empleado, serv,fechaYHora);

            if (res > 0) {

              DialogResult r = MessageBox.Show("Se ha cargado el servico de forma correcta", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (r == DialogResult.OK) {
                    this.Close();
                }
            }
        }


        private ClassServicio obtenerServicioSelect(ClassServicio serv) {

         serv = (ClassServicio)comboBoxServicios.SelectedItem;
         return serv;
        }


        private bool validarCargar(ClassServicio serv) {

            if (serv.id > 0 && serv.costo > 0) {

                return true;
            }
        
            return false;
        }

    }
}
