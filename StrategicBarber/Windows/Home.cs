using StrategicBarber.Clases;
using StrategicBarber.ClassDataBase;
using StrategicBarber.Windows;
using System.Diagnostics;
namespace StrategicBarber
{
    public partial class  
         Inicio : Form
    {
        private int principalWindows = 0;
        public bool isAdmin= false;


        public Inicio(int num=0)
        {
            principalWindows = num;
            InitializeComponent();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            if (principalWindows == 0) {

                label3.Text = "Permiso de administrador";
                label3.Location = new Point(80,30);
                botonIniciarSesion.Text = "Autorizar";
            }


        }

        private void botonIniciarSesion_Click(object sender, EventArgs e)
        {
            string username = textboxUserName.Text.Trim();
            string pass = textBoxPassword.Text.Trim();
            bool res=validateInput(username, pass);


             bool userLogin = verifcarUsuario(username,pass);

             if (userLogin && res)
             {

                if (principalWindows > 0)
                {

                    PanelGeneral panelGeneral = new PanelGeneral();
                    panelGeneral.Show();
                    this.Hide();

                }
                else {

                    this.isAdmin = true;
                    this.DialogResult = DialogResult.OK;
                }
                 
             }
             else {

                 MessageBox.Show("Usuario o Clave incorrecta, Vuelva a intentarlo", "Error", MessageBoxButtons.OK);
                 

             }



        }

        private bool validateInput(string username, string password)
        {
            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Por favor, ingrese un usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Por favor, ingrese una contraseña.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private bool verifcarUsuario(string username, string pass) { 

        ClassUsuario user = new ClassUsuario();
        DataBaseUsuarios dbUsers = new DataBaseUsuarios();
            user = dbUsers.verficacionUserLogin(username, pass);
            if (user.Usuario == username && user.password == pass)
            {
                return true;
            }
        return false;
        }

        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (principalWindows > 0)
            {
                // Cierra la cola de mensajes y detiene todos los hilos del entorno
                Application.Exit();
            }
        }

    }
}
