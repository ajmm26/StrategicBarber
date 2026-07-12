
using StrategicBarber.Clases;
using StrategicBarber.ClassDataBase;
using StrategicBarber.DataBase;
using StrategicBarber.Windows;
using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Velopack;



namespace StrategicBarber
{
    static class Program
    {
        [STAThread]
        static void Main()
        {

            // Inicializa los estilos modernos de Windows
            ApplicationConfiguration.Initialize();


            DotNetEnv.Env.Load();

            VelopackApp.Build().Run();

            InitScreen();
        }

        private static bool verificationAdmin() {
           
            ClassUsuario user = new ClassUsuario();
            DataBaseUsuarios dbUser = new DataBaseUsuarios();
            user = dbUser.getUser(1);
            if (user.idRol == 1) {
                return true;
            }
            return false;
        }

        private static void InitScreen() {


            DataBaseConection db = new DataBaseConection();
            DataBaseNegocio dbNegocio = new DataBaseNegocio();
            DataBaseCreate dbCreated = new DataBaseCreate();
            bool verification = db.connectToDataBaseVerification();

            if (!verification)
            {
                if (dbCreated.CreateDataBaseFiles())
                {

                    Application.Run(new Negocio()); // O la ventana que corresponda aquí
                }
            }
            else
            {
                ClassNegocio neg = dbNegocio.ObtenerNegocio();
                if (neg.id > 0)
                {

                    if (verificationInit())
                    {

                        bool existAdmin = verificationAdmin();

                        if (existAdmin)
                        {

                            Application.Run(new Inicio(1));
                        }
                        else
                        {

                            Application.Run(new CrearUsuario(0));

                        }
                    }
                    else { 
                        DialogResult r=  MessageBox.Show("Fecha inconsistente, corrija la fecha de su equipo","ERROR", MessageBoxButtons.OK,MessageBoxIcon.Error);
                        if (r == DialogResult.OK) {
                            Application.Exit();
                            return;
                        }
                    
                    }

                }
                else
                {
                    if (neg.fallout != 1)
                    {
                        Application.Run(new Negocio()); // O la ventana que corresponda aquí
                    }
                }

            }

        }


       static private bool verificationInit() { 
        
            DataBaseNegocio dbNeg = new DataBaseNegocio();
            string validacion = dbNeg.verificacionNegocioValido();
            DateTime joyboy = DateTime.Now;
            

            if (DateTime.TryParse(validacion, out DateTime jkiojk)) {

                if(joyboy > jkiojk)
                return true;
            }

            return false;
        }

    }
}