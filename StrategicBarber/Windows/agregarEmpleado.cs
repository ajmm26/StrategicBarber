using StrategicBarber.Clases;
using StrategicBarber.DataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StrategicBarber.Windows
{
    public partial class agregarEmpleado : Form
    {
        private int modo;
        private ClassEmpleado empleado;
        private int actualizado = 0;

        public agregarEmpleado(int modo, ClassEmpleado emp = null)
        {
            InitializeComponent();
            this.modo = modo;
            empleado = emp;
        }

        private async void buttonAgregar_Click(object sender, EventArgs e)
        {

            string dni = dniEmpleado.Text.Trim();
            int dniParseado = parseDni(dni);
            string nombre = nombreEmpleado.Text.Trim();
            bool resNombre = validarInputText(nombre);
            string apellido = apellidoEmpleado.Text.Trim();
            bool resApellido = validarInputText(apellido);
            string porcentaje = porcentajeEmpleado.Text.Trim();
            double porcentajeParseado = parsePorcentaje(porcentaje);
            bool existP = existPorcentaje();

            if (modo == 0)
            {
                processAdd(existP, resNombre, resApellido, nombre, apellido, dniParseado, porcentajeParseado);
            }

            if (modo == 1)
            {

                await processModificar(resNombre, resApellido, dniParseado, porcentajeParseado, nombre, apellido);


            }

        }


        private int parseDni(string num)
        {
            if (string.IsNullOrEmpty(num) && modo == 0)
            {
                MessageBox.Show("El dni no puede estar vacío", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }


            if ((num.Length > 8 || num.Length < 8) && modo == 0)
            {

                MessageBox.Show("El dni no es valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;

            }

            // Intentamos parsear. Si falla, el TryParse nos avisa directamente
            if (!int.TryParse(num, out int dni))
            {
                if (modo == 0)
                {
                    MessageBox.Show("Por favor, ingresa un número válido (solo dígitos)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return 0;
            }


            return dni; // Si pasó todas las pruebas, devolvemos el número limpio
        }


        private double parsePorcentaje(string num)
        {
            double resultado= -1;



            if (!string.IsNullOrEmpty(num))
            {

                // Intentamos parsear. Si falla, el TryParse nos avisa directamente
                if (!double.TryParse(num, out resultado))
                {
                    MessageBox.Show("Por favor, ingresa un número válido (solo dígitos)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }

                if (resultado < 0)
                {
                    MessageBox.Show("El valor del porcentaje debe ser mayor a 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }


            }

            return resultado; // Si pasó todas las pruebas, devolvemos el número limpio
        }

        private bool validarInputText(string campo)
        {
            if (string.IsNullOrEmpty(campo))
            {

                return false;
            }


            return true;
        }

        private void addEmpleado(bool resNombre, bool resApellido, int dniParseado, string nombre, string apellido, double porcentajeParseado, int ban)
        {
            DataBaseEmpleado dbEmp = new DataBaseEmpleado();

            if (resNombre && resApellido && dniParseado > 0)
            {

                int res = 0;
                if (Session.idRolSession == 1)
                {
                    ClassEmpleado newEmpleado = new ClassEmpleado(nombre.ToLower(), apellido.ToLower(), dniParseado, porcentajeParseado, ban);
                    res = dbEmp.insertEmpleado(newEmpleado);
                }
                else {

                    Inicio ventanaVerificar = new Inicio(0);
                     DialogResult result = ventanaVerificar.ShowDialog();
                if (result == DialogResult.OK && ventanaVerificar.isAdmin)
                {
                    ClassEmpleado newEmpleado = new ClassEmpleado(nombre.ToLower(), apellido.ToLower(), dniParseado, porcentajeParseado, ban);
                     res = dbEmp.insertEmpleado(newEmpleado);
                    }
                

                }

                if (res > 0)
                {
                    DialogResult r = MessageBox.Show("Se ha agregado el empleado: " + nombre + " " + apellido, "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (r == DialogResult.OK) this.Close();
                }
            }

            }

        private async Task processModificar(bool resNombre, bool resApellido, int dniParseado, double porcentaje, string nombre, string apellido)
        {

            if (tipoDePermisos())
            {

                if (resNombre)
                {

                    actualizarNombre(nombre);

                }

                if (resApellido)
                {

                    actualizarApellido(apellido);

                }

                if (dniParseado > 0)
                {

                    actualizarDni(dniParseado);

                }

                if (porcentaje > 0)
                {

                    await actualizarPorcentaje(porcentaje, 1);

                }
                else
                {
                    if (porcentaje == 0.0)
                    {
                        await actualizarPorcentaje(porcentaje, 0);
                    }
                }


                if (actualizado > 0)
                {

                    this.DialogResult = DialogResult.OK;
                }
            }
        }





        private void processAdd(bool existPorcentajeGoblal, bool resNombre, bool resApellido, string nombre, string apellido, int dni, double porcentajeParseado)
        {
            DataBaseEmpleado dbEmp = new DataBaseEmpleado();
            DataBaseNegocio dbN = new DataBaseNegocio();
            ClassNegocio neg = dbN.ObtenerNegocio();
 
                if ((!existPorcentajeGoblal && porcentajeParseado > 0) || (existPorcentajeGoblal && porcentajeParseado > 0))
                {
                    addEmpleado(resNombre, resApellido, dni, nombre, apellido, porcentajeParseado, 1);
                }
                else
                {

                    if (neg.porcentajeGloblal > 0)
                    {
                        addEmpleado(resNombre, resApellido, dni, nombre, apellido, neg.porcentajeGloblal, 0);
                    }
                    else
                    {
                        MessageBox.Show("No se puede crear un empleado. Configure un porcentaje global para el negocio o asigne un porcentaje de cobro al empleado", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
        }

        private bool existPorcentaje()
        {
            DataBaseNegocio dbneg = new DataBaseNegocio();
            ClassNegocio neg = dbneg.ObtenerNegocio();
            if (neg.porcentajeGloblal > 0)
            {
                return true;
            }
            return false;
        }

        private void agregarEmpleado_Load(object sender, EventArgs e)
        {
            if (modo > 0)
            {
                tituloVersionVentana.Text = "Modificar Empleado";
                buttonAgregar.Text = "Modificar";
            }
        }

        private void actualizarNombre(string nombre)
        {
            DataBaseEmpleado dbEmp = new DataBaseEmpleado();
           
                if (empleado.verificarNombre(nombre.ToLower()))
                {
                    int res = dbEmp.updateNombre(nombre.ToLower(), empleado.id);
                    if (res > 0)
                    {

                        DialogResult r = MessageBox.Show("Se actualizo el nombre: " + nombre, "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (r == DialogResult.OK)
                        {

                            actualizado++;
                        }

                    }
                }

        }

        private void actualizarApellido(string apellido)
        {
            DataBaseEmpleado dbEmp = new DataBaseEmpleado();
          
                if (empleado.verificarApellido(apellido.ToLower()))
                {
                    int res = dbEmp.updateApellido(apellido.ToLower(), empleado.id);
                    if (res > 0)
                    {

                        DialogResult r = MessageBox.Show("Se actualizo el apellido: " + apellido, "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (r == DialogResult.OK)
                        {

                            actualizado++;
                        }

                    }
                }
        }

        private void actualizarDni(int dni)
        {
                DataBaseEmpleado dbEmp = new DataBaseEmpleado();
                if (empleado.verificarDni(dni))
                {

                    int res = dbEmp.updateDni(dni, empleado.id);

                    if (res > 0)
                    {

                        DialogResult r = MessageBox.Show("Se actualizo el dni", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (r == DialogResult.OK)
                        {

                            actualizado++;
                        }
                    }

                }
        }

        private async Task actualizarPorcentaje(double p, int b)
        {
            if( p >= 0.0) { 
                DataBaseEmpleado dbEmp = new DataBaseEmpleado();
                int res = await dbEmp.updatePorcentaje(p, empleado.id, b);

                if (res > 0)
                {
                    DialogResult r = MessageBox.Show("Se actualizo el Porcentaje", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (r == DialogResult.OK)
                    {
                        actualizado++;

                    }
                }
            }
        }


        private bool tipoDePermisos()
        {

            if (Session.idRolSession == 1)
            {

                return true;

            }
            else
            {

                Inicio ventanaAdmin = new Inicio(0);
                ventanaAdmin.ShowDialog();
                if (ventanaAdmin.isAdmin)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }

        }

    }
}
