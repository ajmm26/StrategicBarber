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
    public partial class restoreUser : Form
    {
        public restoreUser()
        {
            InitializeComponent();
        }

        private void restoreUser_Load(object sender, EventArgs e)
        {



        }

        private void buttonRestore_Click(object sender, EventArgs e)
        {
            string dni = txtBoxDni.Text.Trim();

            if (!string.IsNullOrEmpty(dni) && dni.Length == 8)
            {

                int dniParseado = Convert.ToInt32(dni);
                DataBaseEmpleado dbEmp = new DataBaseEmpleado();
                int IDempleado = dbEmp.ExistEmp(dniParseado);
                if (IDempleado > 1)
                {

                    if (dbEmp.ActivedEmp(IDempleado) == 1)
                    {

                        DialogResult r = MessageBox.Show("Se ha recuperado el empleado", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if (r == DialogResult.OK)
                        {
                            this.Close();

                        }
                    }
                    else
                    {

                        MessageBox.Show("No se ha podido recuperar el Empleado, vuelva a intentarlo", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                }
                else
                {

                    MessageBox.Show("No existe registro de su empleado previamente, Cree nuevamente al empleado", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }


            }
            else {

                MessageBox.Show("DNI Invalido", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }



        }
    }
}
