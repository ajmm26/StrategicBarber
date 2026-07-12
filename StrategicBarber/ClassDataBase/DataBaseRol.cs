using Microsoft.Data.Sqlite;
using StrategicBarber.Clases;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace StrategicBarber.DataBase
{
    internal class DataBaseRol
    {

        public ClassRoles GetRol(int id)
        {
            ClassRoles roles = new ClassRoles();
            DataBaseConection conection = new DataBaseConection();
            conection.OpenDataBase();
            conection.CreateCommand();
            conection.sqlCommandParamertsInt("@id", id);
            SqliteDataReader reader = conection.ExecuteCommandReader("SELECT * FROM ROLES WHERE IDRol=@id");
            if (reader.Read()) { 
            roles.idRol = int.Parse(reader["IDRol"].ToString());
            roles.nameRol = reader["NombreRol"].ToString();
            }
            reader.Close();
            conection.CloseDataBase();
            return roles;
        }

        public List<ClassRoles> GetRolList() { 
        
        List<ClassRoles> listRoles= new List<ClassRoles>();
        DataBaseConection conection = new DataBaseConection();

            try
            {
                conection.OpenDataBase();
                conection.CreateCommand();
                SqliteDataReader reader = conection.ExecuteCommandReader("SELECT * FROM ROLES");
                while (reader.Read()) { 
                ClassRoles role = new ClassRoles();
                    role.nameRol = reader["NombreRol"].ToString();
                    role.idRol = int.Parse(reader["IDRol"].ToString());
                    listRoles.Add(role);
                }
            }
            catch (Exception ex) { 
            }
            return listRoles;
        
        }
    }
}
