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
    public partial class addCode : Form
    {
        public addCode()
        {
            InitializeComponent();
        }

        private void addCode_Load(object sender, EventArgs e)
        {

        }

        private void Guardar_Click(object sender, EventArgs e)
        {

            string codigo = inputCodigo.Text.Trim();

            if (string.IsNullOrWhiteSpace(codigo))
            {

                MessageBox.Show("El codigo no puede estar vacio", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else { 
            
            DataBaseNegocio da = new DataBaseNegocio();
            int r = da.insertCode(codigo);
                if (r > 0) {

                   DialogResult rr =  MessageBox.Show("Se ha guardado su codigo", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (rr == DialogResult.OK) { 
                    
                    this.Close();
                    
                    }
                }
            }

        }
    }
}
