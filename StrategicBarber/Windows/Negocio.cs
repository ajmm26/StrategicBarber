using Microsoft.VisualBasic;
using StrategicBarber.Clases;
using StrategicBarber.ClassDataBase;
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
    public partial class Negocio : Form
    {
        public Negocio()
        {
            InitializeComponent();
        }

        private void Negocio_Load(object sender, EventArgs e)
        {
            bool res = verificationDataBase();
            if (!res) { 
            DataBaseInitialize();
            }




        }

        private void botonCrearEmpresa_Click(object sender, EventArgs e)
        {
            string porcentajeNegocio = inputPorcentajeCobro.Text.Trim();

            try {
                ClassNegocio negocio1;
            string nameNegocio = obtenerNameNegocio();

                if (string.IsNullOrEmpty(nameNegocio))
                {
                    MessageBox.Show("Por favor, ingrese un nombre para el negocio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else {
                    DateTime fechaActual = DateTime.Now;
                    string fechaYHora = fechaActual.ToString("yyyy-MM-dd HH:mm:ss");
                    DataBaseNegocio negocio = new DataBaseNegocio();
                    string porcentajeCobro = string.IsNullOrEmpty(porcentajeNegocio) ? "0" : porcentajeNegocio;

                    double porcentajeCobroDouble = double.TryParse(porcentajeCobro, out porcentajeCobroDouble) ? porcentajeCobroDouble : 0.0;
                    if (double.IsPositive(porcentajeCobroDouble))
                    {

                        negocio1 = new ClassNegocio(nameNegocio, porcentajeCobroDouble, fechaYHora);
                    }
                    else { 
                      negocio1 = new ClassNegocio(nameNegocio, fechaYHora);
                    }

                    int res =  negocio.agregarNegocio(negocio1);

                    if (res > 0) { 
                    MessageBox.Show("Negocio creado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CrearUsuario crearUsuario = new CrearUsuario(0);
                        crearUsuario.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Error al crear el negocio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();

                    }
                  
                }


            } catch(Exception ex){
               

            }


        }


        private void DataBaseInitialize()
        {
            try
            {
                DataBaseCreate db = new DataBaseCreate();
                bool resCreation = db.CreateDataBaseFiles();

                if (resCreation)
                {
                    MessageBox.Show("Base de datos creada e inicializada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("La base de datos ya existe o no se pudo inicializar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


            }
            catch (Exception ex)
            {

                string msg = ex.ToString();
                MessageBox.Show("Error al cargar el negocio: " + msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private bool verificationDataBase()
        {
            bool verification = false;
            try
            {
                DataBaseConection dbConnection = new DataBaseConection();
                verification = dbConnection.connectToDataBaseVerification();
            }
            catch (Exception ex)
            {
                string msg = ex.ToString();
                MessageBox.Show("Error al verificar la base de datos: " + msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return verification;

        }

        string obtenerNameNegocio()
        {
            string name = string.Empty;
            if (!string.IsNullOrWhiteSpace(inputNameNegocio.Text.Trim()))
            {
                name = inputNameNegocio.Text.Trim();
                Debug.WriteLine("El nombre del negocio es: " + name);
            }

            return name;
        }
    }
}
