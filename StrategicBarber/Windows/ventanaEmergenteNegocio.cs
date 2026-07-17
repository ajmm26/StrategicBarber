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
    public partial class ventanaEmergenteNegocio : Form
    {
        private int tipoEmergenteNegocio;

        public ventanaEmergenteNegocio(int tipoEmergenteNegocio)
        {
            InitializeComponent();
            this.tipoEmergenteNegocio = tipoEmergenteNegocio;
        }

        private void ventanaEmergenteNegocio_Load(object sender, EventArgs e)
        {
            if (tipoEmergenteNegocio > 0)
            {
                modoPorcentaje();
            }


        }

        private void modoPorcentaje()
        {

            tituloVentanaEmergenteneg.Text = "Modificar Porcentaje Globlal";
            tituloVentanaEmergenteneg.Location = new Point(120, 40);
            minitituloVentanaEmerNeg.Text = "Porcentaje";
            inputVentanaEmerNeg.PlaceholderText = "Porcentaje";

        }

        private async void buttonModificarNeg_Click(object sender, EventArgs e)
        {

            if (tipoEmergenteNegocio > 0)
            {
                string nuevoPorcentaje = inputVentanaEmerNeg.Text.Trim();
                double newPorcent = parsePorcentaje(nuevoPorcentaje);

                if (newPorcent >= 0)
                {
                    bool succes = Tipopermisos();
                    if (succes)
                    {
                        DataBaseNegocio dbNegocio = new DataBaseNegocio();
                        int res = await dbNegocio.modificarPorcentaje(newPorcent);
                        mensajeRespuestaPorcentaje(res);

                    }
                    else
                    {
                        MessageBox.Show("Acción cancelada. Se requieren permisos de administrador.", "Operación Cancelada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else {

                string txt = inputVentanaEmerNeg.Text.Trim();

                if (!string.IsNullOrEmpty(txt))
                {
                    bool succes = Tipopermisos();
                    if (succes)
                    {
                        DataBaseNegocio dbNegocio = new DataBaseNegocio();
                        int res = dbNegocio.modificarNombre(txt);
                        mensajeRespuestaNombre(res);
                    }
                    else
                    {

                        MessageBox.Show("Acción cancelada. Se requieren permisos de administrador.", "Operación Cancelada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else {

                    MessageBox.Show("Debe escribir un nombre", "Operación Cancelada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }


            
            }

        }

           private double parsePorcentaje(string num)
        {
            if (string.IsNullOrEmpty(num))
            {
                MessageBox.Show("El valor del porcentaje no puede estar vacío", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }

            // Intentamos parsear. Si falla, el TryParse nos avisa directamente
            if (!double.TryParse(num, out double resultado))
            {
                MessageBox.Show("Por favor, ingresa un número válido (solo dígitos)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }

            if (resultado < 0)
            {
                MessageBox.Show("El porcentaje NO debe ser menor a 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }

            return resultado; // Si pasó todas las pruebas, devolvemos el número limpio
        }

        private void  mensajeRespuestaPorcentaje(int res) {

            if (res > 0)
            {

               DialogResult r = MessageBox.Show("Se ha actulizado el porcentaje global de tu negocio", "Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (r == DialogResult.OK) { 
                this.Close();
                }
            }
            else {
                MessageBox.Show("Ha ocurrido un error al actulizar el porcentaje global de tu negocio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
        }

        private void mensajeRespuestaNombre(int res)
        {

            if (res > 0)
            {

                MessageBox.Show("Se ha actualizado el nombre de tu negocio", "Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Ha ocurrido un error al actulizar el nombre de tu negocio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private bool verficaradmin() {

            Inicio init = new Inicio(0);

            DialogResult resultado = init.ShowDialog();
            if (resultado == DialogResult.OK && init.isAdmin) {
                return true;
            }
            return false;
        }


        private bool Tipopermisos()
        {
            bool acceso = false;

            if (Session.idRolSession == 1) {

                return acceso = true;
            }


            return acceso = verficaradmin();

        }


    }
}
