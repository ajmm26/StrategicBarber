using StrategicBarber.Clases;
using StrategicBarber.ClassDataBase;
using StrategicBarber.DataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace StrategicBarber.Windows
{
    public partial class CrearUsuario : Form
    {

        private int existAdmin = 1;

        public CrearUsuario(int num = 1)
        {
            existAdmin = num;
            InitializeComponent();
        }
        private void CrearUsuario_Load(object sender, EventArgs e)
        {
            if (existAdmin > 0) { 
            
                ComboBox selectorRol = new ComboBox();
                createComboBox(selectorRol);
            
            }

        }

        private void CrearUsuarioBoton_Click(object sender, EventArgs e)
        {
            DataBaseUsuarios dataBaseUsuarios = new DataBaseUsuarios();
            string nombrePersona = InputNombre.Text.Trim();
            string apellidoPersona = inputApellido.Text.Trim(); 
            string username = inputUsuario.Text.Trim();
            string password = inputClave.Text.Trim();
            int respuesta = 0;

            if (existAdmin == 0 && validateInput(username, password, nombrePersona, apellidoPersona))
            {
                ClassRoles roles = new ClassRoles();
                DataBaseRol rol = new DataBaseRol();
                roles = rol.GetRol(1);
                ClassUsuario newAdmin = new ClassUsuario(nombrePersona, apellidoPersona, username, password, roles.idRol);
                respuesta = dataBaseUsuarios.insertUser(newAdmin);
            }
            else {
                CrearUsuarioConSessionIniciada(username, password, nombrePersona, apellidoPersona);
               }


            if (respuesta > 0 && existAdmin == 0)
            {

                DialogResult r = MessageBox.Show("Se ha creado el Usuario", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (r == DialogResult.OK)
                {
                    Inicio VentanaInicio = new Inicio(1);
                    VentanaInicio.Show();
                    this.Hide();
                }

            }


        }

        private bool validateInput(string username, string password, string nombre, string apellido)
        {
            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Por favor, ingrese un nombre de usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Por favor, ingrese una contraseña.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("Por favor, ingrese su nombre.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(apellido))
            {
                MessageBox.Show("Por favor, ingrese su apellido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;


        }


        private void createComboBox(ComboBox selectorRol) {

            selectorRol.Name = "selectorRol";
            selectorRol.Location = new Point(40, 260);
            selectorRol.Size = new Size(200, 30);
            selectorRol.SelectedIndex = -1;
            panelContentCreatedUser.Controls.Add(selectorRol);

            var listaRoles = new List<KeyValuePair<int, string>>()
{
             new KeyValuePair<int, string>(1, "Administrador"),
             new KeyValuePair<int, string>(2, "Encargado"),
};
            selectorRol.DataSource = listaRoles;
            selectorRol.DisplayMember = "Value"; // Muestra el texto ("Administrador")
            selectorRol.ValueMember = "Key";     // Guarda el número (1)
        }


        private int parseIntRol(string num) {

            if (int.TryParse(num, out int rol))
            {

                return rol;

            }
            else {

                MessageBox.Show("No se ha podido elegir un rol", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            
            }
        
        
        }

        private void CrearUsuarioConSessionIniciada(string username, string password,string  nombrePersona, string apellidoPersona) {
            DataBaseUsuarios dataBaseUsuarios = new DataBaseUsuarios();
            bool valores = validateInput(username, password, nombrePersona, apellidoPersona);
            int respuesta = 0;
                if (valores && Session.idRolSession ==1)
                {
                    ComboBox selectorRolExistente = (ComboBox)panelContentCreatedUser.Controls["selectorRol"];
                    string valorRol = selectorRolExistente.SelectedValue?.ToString();
                    int rol = parseIntRol(valorRol);
                    ClassUsuario newAdmin = new ClassUsuario(nombrePersona, apellidoPersona, username, password, rol);
                    respuesta = dataBaseUsuarios.insertUser(newAdmin);
                 
                }


            if (valores && Session.idRolSession != 1)
            {

                Inicio ventanaInico = new Inicio(0);

                if (ventanaInico.isAdmin)
                {

                    ComboBox selectorRolExistente = (ComboBox)panelContentCreatedUser.Controls["selectorRol"];
                    string valorRol = selectorRolExistente.SelectedValue?.ToString();
                    int rol = parseIntRol(valorRol);
                    ClassUsuario newAdmin = new ClassUsuario(nombrePersona, apellidoPersona, username, password, rol);
                    respuesta = dataBaseUsuarios.insertUser(newAdmin);

                }
                else {

                    MessageBox.Show("Necesitas permisos de adminitrador","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
                
                }


            }


            if (respuesta > 0) { 
            
            DialogResult r = MessageBox.Show("Se ha creado el Usuario", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (r == DialogResult.OK) {

                    this.Close();
                }

            }

        }


    }
}
