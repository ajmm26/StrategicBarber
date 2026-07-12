using Microsoft.Data.Sqlite;
using StrategicBarber.Clases;
using StrategicBarber.ClassDataBase;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Core.Mapping;
using System.Net;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StrategicBarber.DataBase
{
    internal class DataBaseEmpleado
    {
       

        public int insertEmpleado(ClassEmpleado empleado) {

            int res = 0;

            try
            {
                DataBaseConection conection = new DataBaseConection();
                conection.OpenDataBase();
                conection.CreateCommand();
                conection.sqlCommandParamertsString("@nombre", empleado.nombre);
                conection.sqlCommandParamertsString("@apellido", empleado.apellido);
                conection.sqlCommandParamertsInt("@dni", empleado.dni);
                conection.sqlCommandParamertsDouble("@p", empleado.porcentajeCobro);
                conection.sqlCommandParamertsDouble("@b", empleado.ban);
                res = conection.ExecuteCommandNonQuery("INSERT INTO EMPLEADO (Nombre, Apellido, Dni, PorcentajeCobro, PorcentajeEspecial) Values (@nombre,@apellido,@dni,@p,@b)");
                conection.CloseDataBase();
            }
            catch (Exception ex) { 
               
                string msg = ex.Message;
                MessageBox.Show("Error al agregar el empleado: "+ msg,"ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
            } 
            return res; 
            
            }

        public List<ClassEmpleado> obtenerListaEmpleados(int idx){

            List<ClassEmpleado> list = new List<ClassEmpleado>(); 

            try
            {
                DataBaseConection conection = new DataBaseConection();
                conection.OpenDataBase();
                conection.CreateCommand();
                conection.sqlCommandParamertsInt("@idx", idx);
                SqliteDataReader reader= conection.ExecuteCommandReader("SELECT * FROM EMPLEADO WHERE EmpleadoActivo > 0 LIMIT 10 OFFSET @idx");
                while (reader.Read()) {
                    ClassEmpleado empleado = new ClassEmpleado();

                    empleado.nombre = reader["Nombre"].ToString();
                     empleado.apellido = reader["Apellido"].ToString();
                    empleado.dni = int.Parse(reader["Dni"].ToString());
                     empleado.porcentajeCobro = double.Parse(reader["PorcentajeCobro"].ToString());
                    empleado.id= int.Parse(reader["IDEmpleado"].ToString());
                  
                   
                    list.Add(empleado);

                }
                reader.Close();
                conection.CloseDataBase();
            }
            catch (Exception ex)
            {

                string msg = ex.Message;
                MessageBox.Show("Error al agregar el empleado: " + msg, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return list;

        }

        public int DeleteEmp(int id) {

            int res = 0;
            try
            {
                DataBaseConection conection = new DataBaseConection();
                conection.OpenDataBase();
                conection.CreateCommand();
                conection.sqlCommandParamertsInt("@id", id);
                res = conection.ExecuteCommandNonQuery("UPDATE EMPLEADO SET EmpleadoActivo = 0  WHERE IDEmpleado = @id");
                conection.CloseDataBase();
            }
            catch (Exception ex)
            {

                string msg = ex.Message;
                MessageBox.Show("Error al eliminar empleado: " + msg, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return res;

        }

        public int ActivedEmp(int id)
        {

            int res = 0;
            try
            {
                DataBaseConection conection = new DataBaseConection();
                conection.OpenDataBase();
                conection.CreateCommand();
                conection.sqlCommandParamertsInt("@id", id);
                res = conection.ExecuteCommandNonQuery("UPDATE EMPLEADO SET EmpleadoActivo = 1  WHERE IDEmpleado = @id");
                conection.CloseDataBase();
            }
            catch (Exception ex)
            {

                string msg = ex.Message;
                MessageBox.Show("Error al eliminar empleado: " + msg, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return res;

        }


        public int ExistEmp(int dni) {

            int res = 0;
            try {

                DataBaseConection conection = new DataBaseConection();
                conection.OpenDataBase();
                conection.CreateCommand();
                conection.sqlCommandParamertsInt("@dni", dni);
                SqliteDataReader reader = conection.ExecuteCommandReader("SELECT IDEmpleado FROM Empleado WHERE Empleado.DNI = @dni");
                if (reader.Read()) {

                    res = int.Parse(reader["IDEmpleado"].ToString());

                }
                conection.CloseDataBase();

            }
            catch (Exception ex)
            {

                string msg = ex.Message;
                MessageBox.Show("Error al eliminar empleado: " + msg, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return res;
        }

        public int GetNumberEmpleados()
        {
            int res = 0;
            DataBaseConection conection = new DataBaseConection();
            conection.OpenDataBase();
            conection.CreateCommand();
            SqliteDataReader reader = conection.ExecuteCommandReader("SELECT COUNT(*) FROM EMPLEADO WHERE EmpleadoActivo > 0");
            if (reader.Read()) {

                res = reader.GetInt32(0);

            }
            reader.Close();
            conection.CloseDataBase();
            return res;
        }


        public int updateDni(int dni,int id) {

            int res = 0;
            try
            {
                DataBaseConection conection = new DataBaseConection();
                conection.OpenDataBase();
                conection.CreateCommand();
                conection.sqlCommandParamertsInt("@d", dni);
                conection.sqlCommandParamertsInt("@id", id);
                res = conection.ExecuteCommandNonQuery("UPDATE EMPLEADO SET Dni = @d WHERE IDEmpleado = @id");
                conection.CloseDataBase();
            }
            catch (Exception ex)
            {

                string msg = ex.Message;
                MessageBox.Show("Error: " + msg, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return res;

        }


        public async Task<int> updatePorcentaje(double porcentaje, int id, int b)
        {
            int res = 0;
            try
            {

                DataBaseConection conection = new DataBaseConection();
                conection.OpenDataBase();
                conection.CreateCommand();
                conection.sqlCommandParamertsDouble("@p", porcentaje);
                conection.sqlCommandParamertsInt("@id", id);
                conection.sqlCommandParamertsInt("@b", b);
                res = await conection.ExecuteComandoAsync("UPDATE EMPLEADO SET PorcentajeCobro=@p, PorcentajeEspecial = @b WHERE IDEmpleado=@id");
                conection.CloseDataBase();

            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                MessageBox.Show("Error: " + msg, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return res;
        }


        public int updateNombre(string nombre, int id)
        {
            int res = 0;
            try
            {

                DataBaseConection conection = new DataBaseConection();
                conection.OpenDataBase();
                conection.CreateCommand();
                conection.sqlCommandParamertsString("@n", nombre);
                conection.sqlCommandParamertsInt("@id", id);
                res = conection.ExecuteCommandNonQuery("UPDATE EMPLEADO SET Nombre=@n WHERE IDEmpleado=@id");
                conection.CloseDataBase();

            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                MessageBox.Show("Error: " + msg, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return res;
        }


        public int updateApellido(string apellido, int id)
        {
            int res = 0;
            try
            {

                DataBaseConection conection = new DataBaseConection();
                conection.OpenDataBase();
                conection.CreateCommand();
                conection.sqlCommandParamertsString("@a", apellido);
                conection.sqlCommandParamertsInt("@id", id);
                res = conection.ExecuteCommandNonQuery("UPDATE EMPLEADO SET Apellido=@a WHERE IDEmpleado=@id");
                conection.CloseDataBase();

            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                MessageBox.Show("Error: " + msg, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return res;
        }

    }
}
