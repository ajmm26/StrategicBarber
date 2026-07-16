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
            if (existAdmin > 0)
            {
                ComboBox selectorRol = new ComboBox();
                createComboBox(selectorRol);

            }
        }

        private void CrearUsuarioBoton_Click(object sender, EventArgs e)
        {

            string nombrePersona = InputNombre.Text.Trim();
            string apellidoPersona = inputApellido.Text.Trim(); 
            string username = inputUsuario.Text.Trim();
            string password = inputClave.Text.Trim();

            if (validateInput(username, password,nombrePersona,apellidoPersona) )
            {
                if (existAdmin == 0) { 

                ClassRoles roles = new ClassRoles();
                DataBaseRol rol = new DataBaseRol();

                roles = rol.GetRol(1);
                if (roles.idRol == 1)
                {
                    ClassUsuario newAdmin = new ClassUsuario();
                    newAdmin= completedUser(nombrePersona,apellidoPersona,username, password, roles.idRol);
                    DataBaseUsuarios dataBaseUsuarios = new DataBaseUsuarios();
                    int nose = dataBaseUsuarios.insertUser(newAdmin);
                    if (nose > 0)
                    {
                        MessageBox.Show("Usuario creado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Inicio inicio = new Inicio(1);
                        inicio.Show();
                        this.Hide();
                    }
                }
                
                }
                else
                {
                    if (panelContentCreatedUser.Controls.ContainsKey("selectorRol")) {

                        ComboBox selectorRolExistente = (ComboBox)panelContentCreatedUser.Controls["selectorRol"];
                        string valorRol = selectorRolExistente.SelectedValue?.ToString();
                        int rol = parseIntRol(valorRol);
                        if (rol > 0) { 
                        
                        Inicio ventanaVerificacion = new Inicio(0);
                         DialogResult resultado = ventanaVerificacion.ShowDialog();
                            if (resultado == DialogResult.OK && ventanaVerificacion.isAdmin)
                            {
                                ClassUsuario newUser = new ClassUsuario();
                                DataBaseUsuarios dbUsers = new DataBaseUsuarios();
                                newUser = completedUser(nombrePersona, apellidoPersona, username, password, rol);
                                int res = dbUsers.insertUser(newUser);
                                if (res > 0) {

                                    MessageBox.Show("Se ha creado el usuario: "+newUser.Usuario, "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                }
                            }
                            else {

                                MessageBox.Show("Se necesitan permisos de administrador para finalizar esta accion","ERROR",MessageBoxButtons.OK, MessageBoxIcon.Error);
                            
                            }


                        }
                    }




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


        private ClassUsuario completedUser(string nombre, string apellido ,string username, string pass, int id) {

            ClassUsuario newUser = new ClassUsuario();
            newUser.Nombre = nombre.ToLower();
            newUser.Apellido = apellido.ToLower();
            newUser.Usuario = username;
            newUser.password = pass;
            newUser.idRol = id;
            return newUser;
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

    }
}
