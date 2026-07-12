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
    public partial class DiaInicio : Form
    {
        public int initCant = 0;

        public DiaInicio()
        {
            InitializeComponent();
        }

        private void buttonCantEmp_Click(object sender, EventArgs e)
        {
            string txt = inputCantEmp.Text.Trim();

            if (!string.IsNullOrEmpty(txt))
            {

                if (int.TryParse(txt, out int cant))
                {

                    if (cant <= 0)
                    {

                        MessageBox.Show("La cantidad no puede ser 0");

                    }
                    else
                    {

                        initCant = cant;
                        this.DialogResult = DialogResult.OK;
                        this.Close();

                    }
                }
                else {

                    MessageBox.Show("Debe ingresar un numero","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
                
                }

            }


        }

        private void DiaInicio_Load(object sender, EventArgs e)
        {
            DataBaseNegocio dbneg = new DataBaseNegocio();
            ClassNegocio  neg =dbneg.ObtenerNegocio();

            saludotxt.Text = "Buen Dia, " + neg.nombreNegocio;
        }
    }
}
