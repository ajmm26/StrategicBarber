using StrategicBarber.Clases;
using StrategicBarber.ClassDataBase;
using StrategicBarber.Windows;
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
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

            if (principalWindows == 2) {
                label3.Text = "Cambiar De Usuario";
                label3.Location = new Point(110, 30);
                botonIniciarSesion.Text = "Cambiar";

            }

        }

        private void botonIniciarSesion_Click(object sender, EventArgs e)
        {
            string username = textboxUserName.Text.Trim();
            string pass = textBoxPassword.Text.Trim();

            bool res = validateInput(username, pass);


            if (res) { seleccionDeFuncion(username, pass);}
        }


        private void seleccionDeFuncion(string username, string pass) {

            ClassUsuario usuarioLogeado = ObtenerUsuarioPorCredenciales(username, pass);

            if (usuarioLogeado.userid <= 0)
            {
                MessageBox.Show("Usuario o Clave incorrecta, Vuelva a intentarlo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            switch (principalWindows)
            {

                case 1:
                    Session.IniciarSession(usuarioLogeado);
                    PanelGeneral panelGeneral = new PanelGeneral();
                    panelGeneral.Show();
                    this.Hide();
                    break;
                case 0:
                    this.isAdmin = true;
                    this.DialogResult = DialogResult.OK;
                    break;
                case 2:
                    Session.IniciarSession(usuarioLogeado);
                    DialogResult r = MessageBox.Show("Se ha Cambiado la Session del usuario", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (r == DialogResult.OK)
                    {
                        this.Close();
                    }
                    break;
                default:
                    break;


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

        private ClassUsuario ObtenerUsuarioPorCredenciales(string username, string pass) { 

        ClassUsuario user = new ClassUsuario();
        DataBaseUsuarios dbUsers = new DataBaseUsuarios();
            user = dbUsers.verficacionUserLogin(username, pass);
            if (user.Usuario == username && user.password == pass)
            {
                return user;
            }
        return user;
        }

        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (principalWindows == 1)
            {
                // Cierra la cola de mensajes y detiene todos los hilos del entorno
                Application.Exit();
            }
        }

    }
}
