using StrategicBarber.Clases;
using StrategicBarber.DataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace StrategicBarber.Windows
{
    public partial class VentanaServicios : Form
    {
        int modo = 0; // 0 para agregar, 1 para editar
        ClassServicio servicioActual = new ClassServicio(); // Para almacenar el servicio que se está editando
        public int actualizacion;

        public VentanaServicios(int modo, ClassServicio serv=null)
        {
            this.modo = modo;
            this.servicioActual = serv;
            InitializeComponent();
        }

        private void VentanaServicios_Load(object sender, EventArgs e)
        {

            switch (modo) {

                case 0:
                    modoAgregar();
                    break;
                case 1:
                    modoModificar();
                    break;
                case 2:
                    //Eliminar();
                    break;

            }


        }

        private bool validatetext(string n)
        {

            if (string.IsNullOrEmpty(n))
            {

                return false;
            }

            return true;
        }

        private double parseDouble(string num)
        {
            double resultado = 0;

            if (!string.IsNullOrEmpty(num))
            {

                // Intentamos parsear. Si falla, el TryParse nos avisa directamente
                if (!double.TryParse(num, out resultado))
                {
                    MessageBox.Show("Por favor, ingresa un número válido (solo dígitos)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 0;
                }

                if (resultado <= 0)
                {
                    MessageBox.Show("El valor del porcentaje debe ser mayor a 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 0;
                }

            }

            return resultado; // Si pasó todas las pruebas, devolvemos el número limpio
        }

        private void buttonServicio_Click(object sender, EventArgs e)
        {

            switch (modo) {
                case 0:
                    processAdd();
                    break;

                case 1:
                    processUpdate();
                    break;
                case 2:
                    Eliminar();
                    break;

            }

        }

        private void modoAgregar()
        {
            buttonServicio.Text = "Agregar";
            txtTittle.Text = "Agregar Servicio";
        }


        private void modoModificar()
        {
            buttonServicio.Text = "Modificar";
            txtTittle.Text = "Modificar Servicio " + servicioActual.nombre;
        }


        private void processAdd() {

            string nombre = inputNombre.Text.Trim();
            string costo = InputCosto.Text.Trim();

            bool resNombre = validatetext(nombre);
            double costoParseado = parseDouble(costo);

            if (resNombre && costoParseado > 0)
            {

                Inicio ventanaVerificar = new Inicio(0);
                DialogResult result = ventanaVerificar.ShowDialog();
                if (result == DialogResult.OK && ventanaVerificar.isAdmin)
                {

                    ClassServicio serv = new ClassServicio(nombre, costoParseado);
                    DataBaseServicios dbServ = new DataBaseServicios();
                    int res = dbServ.insertServicies(serv);
                    if (res > 0)
                    {
                        MessageBox.Show("Se ha agregado el servicio", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {

                        MessageBox.Show("Error al agregar", "ERROR", MessageBoxButtons.OK);

                    }

                    this.Close();
                }
            }

        }


        private void processUpdate()
        {

            string nombre = inputNombre.Text.Trim();
            string costo = InputCosto.Text.Trim();
            double costoParseado = 0;

            int error = 0;

            if (!string.IsNullOrEmpty(costo)) {

                 costoParseado = parseDouble(costo);

                if (costoParseado <= 0 || !servicioActual.verificarCosto(costoParseado)) {

                    error++;

                }
            }

            if (!string.IsNullOrEmpty(nombre)) { 
            
            if (!servicioActual.verificarNombre(nombre)) {
                error++;
               }
       
            }



            if (error > 0)
            {

                MessageBox.Show("Los datos no pueden ser iguales a los actuales o vacios","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else {

                Inicio ventanaVerificar = new Inicio(0);
                DialogResult result = ventanaVerificar.ShowDialog();

                if (result == DialogResult.OK && ventanaVerificar.isAdmin)
                {

                    this.actualizacion += ActualizarNombre(nombre);
                    this.actualizacion += ActualizarPrecio(costoParseado);

                }

                if (actualizacion == 0)
                {

                    MessageBox.Show("No se ha podido modificar el servicios. Intente nuevamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else {

                    DialogResult r = MessageBox.Show("Se ha modificado el servicio","EXITO",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    if (r == DialogResult.OK) { 
                    this.DialogResult = r;
                        this.Close();
                    }
                  
                }


            }
        }

        private int ActualizarPrecio(double costo) {
                      
            int res = 0;

            if (costo > 0) { 
            DataBaseServicios dbServ = new DataBaseServicios();
            res= dbServ.UpdatePrice(costo,servicioActual.id);
            }
            return res;
        }


        private int ActualizarNombre(string nombre) {

            int res = 0;
            if (!string.IsNullOrEmpty(nombre))
            {
                DataBaseServicios dbServ = new DataBaseServicios();
               res = dbServ.UpdateName(nombre, servicioActual.id);
            }

            return res;
        }

        private void Eliminar()
        {

            Inicio ventana = new Inicio(0);
            DialogResult r = ventana.ShowDialog();

            if (ventana.isAdmin)
            {

                DataBaseServicios dbServ = new DataBaseServicios();
                int res = dbServ.deleteService(servicioActual.id);

                if (res > 0)
                {

                    DialogResult rr = MessageBox.Show("Se ha Eliminado el servicio", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (rr == DialogResult.OK)
                    {

                        this.DialogResult = DialogResult.OK;
                        actualizacion++;

                    }
                }

            }



        }


    }
}
