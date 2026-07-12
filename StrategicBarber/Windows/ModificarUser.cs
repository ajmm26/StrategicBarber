using StrategicBarber.Clases;
using StrategicBarber.ClassDataBase;
using StrategicBarber.DataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace StrategicBarber.Windows
{
    public partial class ModificarUser : Form
    {
        private int idUserAct = 0;
        private ClassUsuario user;
        public ModificarUser(int num)
        {
            idUserAct = num;
            DataBaseUsuarios dbUser = new DataBaseUsuarios();
            user = dbUser.getUser(idUserAct);
            InitializeComponent();
        }

        private void ModificarUser_Load(object sender, EventArgs e)
        {
         DataBaseRol dbRol = new DataBaseRol();
         List<ClassRoles> roles = dbRol.GetRolList();
            addValuesSelector(roles);
        }

        private void buttonModificarUser_Click(object sender, EventArgs e)
        {

            ///Actualizar Nombre
            string nombre = nombreMod.Text.Trim();   
            bool ressName = validarInputText(nombre);
        

            //Actualizar Apellido
            string apellido = apellidoMod.Text.Trim();
            bool resSencondName = validarInputText(apellido);
          
            
            //Actualizar Usuario
            string username = userMod.Text.Trim();
            bool resUsername = validarInputText(username);

            ///Actualizar IDRol
            int idRol = Convert.ToInt32(selectorRoles.SelectedValue);
             bool ressRol = verificationIdRol(idRol);

            //Actualizar clave usuario
            string pass = claveaActualMod.Text.Trim();
            string newpass =claveNuevaMod.Text.Trim();
            bool resPass = verificationPassword(pass,newpass);

            if (ressName || resSencondName || resUsername || resPass || ressRol) {

                Inicio VentanaVerificar = new Inicio(0);
                DialogResult result = VentanaVerificar.ShowDialog();

                if (result == DialogResult.OK && VentanaVerificar.isAdmin)
                {

                    actualizarNombre(ressName,nombre);
                    actualizarApellido(resSencondName,apellido);
                    actualizarUsuario(resUsername,username);
                    actualizarRol(ressRol,idRol);
                    actualizarClave(resPass,pass,newpass);
                
                
                }

                }
            

        }

        private bool validarInputText(string campo)
        {
            if (string.IsNullOrEmpty(campo)) {

                return false;
            }


            return true;
        }

        private bool verificationPassword(string actual, string nueva) {

            // 1. Si ambos están vacíos, no hace nada (retorna true para que el flujo continúe sin actualizar la clave)
            if (string.IsNullOrEmpty(actual) && string.IsNullOrEmpty(nueva))
            {
                return false;
            }

            // 2. Si llegamos aquí, sabemos que al menos uno de los dos tiene texto. 
            // Ahora validamos si falta el otro.
            if (string.IsNullOrEmpty(actual) || string.IsNullOrEmpty(nueva))
            {
                MessageBox.Show("Uno de los campos está vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // 3. Ya sabemos que ambos tienen texto. Validamos que no sean exactamente iguales.
            if (actual == nueva)
            {
                MessageBox.Show("Los valores ingresados como claves, no puede ser iguales.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private bool verificationIdRol(int idRol) {
       

            if (idRol > 0)
            {
                if (idRol == user.idRol)
                {
                    return false;
                }
                else { 
                
                DataBaseUsuarios dbuser = new DataBaseUsuarios();
                    if (dbuser.getAdmins() < 2)
                    {

                        MessageBox.Show("No se puede modificar su rol, debe haber mas de 1 administrador", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                
                }
                return true;
            }
            return false;
        }

        private void addValuesSelector(List<ClassRoles> roles) {

            roles.Insert(0, new ClassRoles()
            {
                idRol = 0,
                nameRol = ""
            });

            selectorRoles.DataSource = roles;
            selectorRoles.DisplayMember = "nameRol";
            selectorRoles.ValueMember = "idRol";
        }

        private void actualizarClave(bool res, string actual,string nuevaClave) {

            if (res)
            {
                DataBaseUsuarios dbUser = new DataBaseUsuarios();
               
                if (user.password == actual)
                {

                        int response = dbUser.updateUser(nuevaClave, idUserAct);

                        if (response > 0)
                        {
                            MessageBox.Show("Se ha actualizado su nueva clave", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }

                }
                else {

                    MessageBox.Show("La clave ingresa como 'Actual' no es igual a tu clave", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

            }
           

        }

        private void actualizarNombre(bool res,string nombre) {

            DataBaseUsuarios dbUser = new DataBaseUsuarios();

            if (res) {

                if (user.Nombre != nombre)
                {
   
                    
                        int response = dbUser.updateName(nombre,idUserAct);

                    if (response > 0) {
                        MessageBox.Show("Se ha Actualizado el nombre", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                         }
                    
                  

                }
                else {

                    MessageBox.Show("El nombre ingresado es el actual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                }
            
            }


        }


        private void actualizarApellido(bool res, string apellido)
        {

            DataBaseUsuarios dbUser = new DataBaseUsuarios();

            if (res)
            {

                if (user.Apellido != apellido)
                {

                        int response = dbUser.updateSecondName(apellido, idUserAct);

                        if (response > 0)
                        {
                            MessageBox.Show("Se ha Actualizado el Apellido", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                 
                }
                else
                {

                    MessageBox.Show("El Apellido ingresado es el actual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }


        }

        private void actualizarUsuario(bool res, string userNew) {


            DataBaseUsuarios dbUser = new DataBaseUsuarios();

            if (res)
            {

                if (user.Usuario != userNew)
                { 

                    
                        int response = dbUser.updateUserName(userNew, idUserAct);

                    if (response > 0)
                    {
                        MessageBox.Show("Se ha Actualizado el usuario", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
 
                     }
 
                   
                }
                else
                {

                    MessageBox.Show("El Usuario ingresado es igual al actual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }


        }


        private void actualizarRol(bool ressRol, int rol) {
             DataBaseUsuarios dbuser = new DataBaseUsuarios();

            if (ressRol) {

                if (rol != user.idRol) {


                        int response = dbuser.updateUserRol(rol, user.userid);

                        if (response > 0)
                        {

                            MessageBox.Show("Se ha actualizado el rol del Usuario", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    
                   

                }
            
            }
          
        
        
        }
    }
}
