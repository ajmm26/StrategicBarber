using System;
using System.Collections.Generic;
using System.Text;

namespace StrategicBarber.Clases
{
    internal class Rutas
    {

        public static(bool rutaValida, string rutaArchivo) VerificarRuta(string target) {


            string carpetaAppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            string carpetaApp = Path.Combine(carpetaAppData, Environment.GetEnvironmentVariable("carpeta_db"), target);

            bool rutaValida = false;
            string rutaArchivo = null;

            try { 
                if (!Directory.Exists(carpetaApp)) {
                    MessageBox.Show("La carpeta no existe, se creará una nueva carpeta para la base de datos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Directory.CreateDirectory(carpetaApp);
                    rutaArchivo = carpetaApp;
                    rutaValida = true;
                }
                else
                {
                  MessageBox.Show("La ruta es válida: " + carpetaApp, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    rutaValida = false;
                    rutaArchivo = carpetaApp;
                }

            }
            catch (Exception ex) { 
              

                string msg = ex.Message;
                MessageBox.Show(msg);

            }


            return (rutaValida, rutaArchivo);

        }


        private bool createFolderDataBasefiles() {

            return true;
        }

    }
}
