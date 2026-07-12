using Microsoft.Data.Sqlite;
using StrategicBarber.Clases;
using StrategicBarber.DataBase;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StrategicBarber.ClassDataBase
{
    internal class DataBaseUsuarios
    {

        public int insertUser(ClassUsuario user) {
            int result = 0;
            DataBaseConection conection = new DataBaseConection();
            try {
                conection.OpenDataBase();
                conection.CreateCommand();
                conection.sqlCommandParamertsString("@nombrePersona", user.Nombre);
                conection.sqlCommandParamertsString("@ApellidoPersona", user.Apellido);
                conection.sqlCommandParamertsString("@name", user.Usuario);
                conection.sqlCommandParamertsString("@password", user.password);
                conection.sqlCommandParamertsInt("@idRol", user.idRol);
                result = conection.ExecuteCommandNonQuery("INSERT INTO Usuario (NombrePersona,ApellidoPersona,NombreUsuario, ClaveUsuario, idRol) VALUES (@nombrePersona,@ApellidoPersona,@name, @password, @idRol)");
                conection.CloseDataBase();
            } catch (Exception ex) {
                string msg = ex.Message;
                MessageBox.Show("Error al crear el usuario: " + msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            return result;

        }

        public ClassUsuario getUser(int id = 1)
        {
            ClassUsuario user = new ClassUsuario();
            DataBaseConection conection = new DataBaseConection();

            try {

                conection.OpenDataBase();
                conection.CreateCommand();
                conection.sqlCommandParamertsInt("@id", id);
                SqliteDataReader reader = conection.ExecuteCommandReader("SELECT * FROM USUARIO WHERE IDUser=@id");
                if (reader.Read()) {
                    user.Nombre = reader["NombrePersona"].ToString();
                    user.Apellido = reader["ApellidoPersona"].ToString();
                    user.Usuario = reader["NombreUsuario"].ToString();
                    user.password = reader["ClaveUsuario"].ToString();
                    user.idRol = int.Parse(reader["IDRol"].ToString());
                    user.userid = int.Parse(reader["iDUser"].ToString());
                }

                reader.Close();
                conection.CloseDataBase();

            } catch (Exception ex) {

                string message = ex.Message;
                MessageBox.Show("Ha ocurrido un error con su usuario en la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return user;
        }


        public List<ClassUsuario> getAllUsers()
        {
            List<ClassUsuario> listaUsuarios = new List<ClassUsuario>();
            DataBaseConection conection = new DataBaseConection();

            try
            {

                conection.OpenDataBase();
                conection.CreateCommand();
                SqliteDataReader reader = conection.ExecuteCommandReader("SELECT * FROM USUARIO");
                while (reader.Read())
                {
                    ClassUsuario user = new ClassUsuario();
                    user.userid = int.Parse(reader["IDUser"].ToString());
                    user.Nombre = reader["NombrePersona"].ToString();
                    user.Apellido = reader["ApellidoPersona"].ToString();
                    user.Usuario = reader["NombreUsuario"].ToString();
                    user.idRol = int.Parse(reader["IDRol"].ToString());
                    listaUsuarios.Add(user);
                }

                reader.Close();
                conection.CloseDataBase();

            }
            catch (Exception ex)
            {

                string message = ex.Message;
                MessageBox.Show("Ha ocurrido un error con su usuario en la base de datos", "Error", MessageBoxButtons.OK);
            }
            return listaUsuarios;
        }


        public ClassUsuario verficacionUserLogin(string name, string pass) {

            ClassUsuario usuario = new ClassUsuario();
            DataBaseConection conection = new DataBaseConection();

            try {
                conection.OpenDataBase();
                conection.CreateCommand();
                conection.sqlCommandParamertsString("@NombreUsuario", name);
                conection.sqlCommandParamertsString("@ClaveUsuario", pass);
                SqliteDataReader reader = conection.ExecuteCommandReader("SELECT * FROM USUARIO WHERE NombreUsuario=@NombreUsuario AND ClaveUsuario=@ClaveUsuario");
                if (reader.Read()) {
                    usuario.Usuario = reader["NombreUsuario"].ToString();
                    usuario.password = reader["ClaveUsuario"].ToString();
                }

                reader.Close();
                conection.CloseDataBase();

            } catch (Exception ex) {
                string msg = ex.Message;
                MessageBox.Show("Error en la base de datos de usuarios: " + msg);
            }
            return usuario;
        }

        public int updateUser(string nuevaClave, int id)
        {
            int res = 0;
            DataBaseConection conection = new DataBaseConection();

            try
            {
                conection.OpenDataBase();
                conection.CreateCommand();
                conection.sqlCommandParamertsString("@nuevaClave", nuevaClave);
                conection.sqlCommandParamertsInt("@id", id);
                res = conection.ExecuteCommandNonQuery("UPDATE Usuario SET ClaveUsuario = @nuevaClave WHERE IDUser = @id");
                conection.CloseDataBase();
            }
            catch (Exception ex) {

            }
            return res;
        }

        public int deleteUser(int id) {
            int res = 0;
            DataBaseConection conection = new DataBaseConection();
            try {
                conection.OpenDataBase();
                conection.CreateCommand();
                conection.sqlCommandParamertsInt("@id", id);
                res = conection.ExecuteCommandNonQuery("DELETE FROM USUARIO WHERE IDUser = @id");
                conection.CloseDataBase();
            } catch (Exception ex) {

            }
            return res;
        }


        public int updateName(string nombre, int id) {
            int res = 0;
            DataBaseConection conection = new DataBaseConection();
            try
            {
                conection.OpenDataBase();
                conection.CreateCommand();
                conection.sqlCommandParamertsInt("@id", id);
                conection.sqlCommandParamertsString("@nombre", nombre);
                res = conection.ExecuteCommandNonQuery("UPDATE Usuario SET NombrePersona=@nombre WHERE IDUser = @id");
                conection.CloseDataBase();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                MessageBox.Show("No se ha podido cambiar el nombre del usuario: " + msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return res;

        }

        public int updateSecondName(string apellido, int id) {

            int res = 0;
            DataBaseConection conection = new DataBaseConection();
            try
            {
                conection.OpenDataBase();
                conection.CreateCommand();
                conection.sqlCommandParamertsInt("@id", id);
                conection.sqlCommandParamertsString("@apellido", apellido);
                res = conection.ExecuteCommandNonQuery("UPDATE Usuario SET ApellidoPersona=@apellido WHERE IDUser = @id");
                conection.CloseDataBase();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                MessageBox.Show("No se ha podido cambiar el apellido del usuario: " + msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return res;

        }

        public int updateUserName(string username, int id) {

            int res = 0;
            DataBaseConection conection = new DataBaseConection();
            try
            {
                conection.OpenDataBase();
                conection.CreateCommand();
                conection.sqlCommandParamertsInt("@id", id);
                conection.sqlCommandParamertsString("@username", username);
                res = conection.ExecuteCommandNonQuery("UPDATE Usuario SET NombreUsuario=@username WHERE IDUser = @id");
                conection.CloseDataBase();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                MessageBox.Show("No se ha podido cambiar el Usuario del usuario: " + msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return res;

        }

        public int updateUserRol(int rol, int id){
        
        int res = 0;
        DataBaseConection conection =new DataBaseConection();

            try {
                conection.OpenDataBase();
                conection.CreateCommand();
                conection.sqlCommandParamertsInt("@rol",rol);
                conection.sqlCommandParamertsInt("@id", id);
                res = conection.ExecuteCommandNonQuery("UPDATE USUARIO SET IDRol WHERE IDUser = @id" );
                conection.CloseDataBase();

            } catch (Exception ex) { 
            
            string msg = ex.Message;
                MessageBox.Show("Ha ocurrido un error al actulizar su Rol: "+msg,"ERROR",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            return res;
        }


        public int getAdmins() {

            int res = 0;
            DataBaseConection conection = new DataBaseConection();

            try
            {
                conection.OpenDataBase();
                conection.CreateCommand();
                SqliteDataReader reader = conection.ExecuteCommandReader("SELECT COUNT(*) FROM USUARIO WHERE IDRol  = 1");
                if (reader.Read())
                {
                    res = reader.GetInt32(0);

                }
                reader.Close();
                conection.CloseDataBase();

            }
            catch (Exception ex)
            {

                string msg = ex.Message;
                MessageBox.Show("Ha ocurrido un error al actulizar su Rol: " + msg, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            return res;


        }

    }

}
