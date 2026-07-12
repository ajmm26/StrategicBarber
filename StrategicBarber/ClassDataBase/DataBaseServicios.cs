using Microsoft.Data.Sqlite;
using Microsoft.VisualBasic;
using StrategicBarber.Clases;
using StrategicBarber.ClassDataBase;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Core.Mapping;
using System.Data.SQLite;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace StrategicBarber.DataBase
{
    internal class DataBaseServicios
    {

        public int insertServicies(ClassServicio servicio) { 
        
            int res = 0;
            DataBaseConection conection = new DataBaseConection();
            try {
                conection.OpenDataBase();
                conection.CreateCommand();
                conection.sqlCommandParamertsString("@n",servicio.nombre);
                conection.sqlCommandParamertsDouble("@c",servicio.costo);
                res = conection.ExecuteCommandNonQuery("INSERT INTO SERVICIOS (NOMBRE,COSTO) VALUES (@n,@c)");
                conection.CloseDataBase();
            
            } catch(Exception e) {

                string msg = e.ToString();
                MessageBox.Show(msg,"Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            }

            return res;
        }


        public List<ClassServicio> GetListServices() {

            List<ClassServicio> list = new List<ClassServicio>();
            DataBaseConection conection = new DataBaseConection();
            try
            {
                conection.OpenDataBase();
                conection.CreateCommand();
                SqliteDataReader reader =  conection.ExecuteCommandReader("SELECT * FROM SERVICIOS WHERE activo = 1");
                while (reader.Read()) {

                    ClassServicio ser = new ClassServicio();
                    ser.nombre = reader["Nombre"].ToString();
                    ser.costo = double.Parse(reader["Costo"].ToString());
                    ser.id = int.Parse(reader["IDServicio"].ToString());
                    list.Add(ser);
                }
                reader.Close();
                conection.CloseDataBase();
            }
            catch
            {



            }

            return list;

        }

        public List<ClassServicio> GetListLike(string txt) {


            List<ClassServicio> list = new List<ClassServicio>();
            DataBaseConection conection = new DataBaseConection();
            try
            {
                conection.OpenDataBase();
                conection.CreateCommand();
                conection.sqlCommandParamertsString("@txt", "%"+txt+"%");
                SqliteDataReader reader = conection.ExecuteCommandReader("SELECT * FROM SERVICIOS WHERE NOMBRE LIKE @txt");
                while (reader.Read())
                {

                    ClassServicio ser = new ClassServicio();
                    ser.nombre = reader["Nombre"].ToString();
                    ser.costo = double.Parse(reader["Costo"].ToString());
                    ser.id = int.Parse(reader["IDServicio"].ToString());
                    list.Add(ser);
                }

                reader.Close();
                conection.CloseDataBase();

            }
            catch(Exception e)
            {

                string msg = e.ToString();
                MessageBox.Show(msg, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            return list;

        }


        public int insertServicesProduct(ClassEmpleado empleado, ClassServicio serv, string fecha) {

            int res = 0;
            DataBaseConection conection = new DataBaseConection();
            try
            {
                conection.OpenDataBase();
                conection.CreateCommand();
                conection.sqlCommandParamertsInt("@ids",serv.id);
                conection.sqlCommandParamertsInt("@ide",empleado.id);
                conection.sqlCommandParamertsString("@f",fecha);
                conection.sqlCommandParamertsDouble("@p",empleado.porcentajeCobro);
                conection.sqlCommandParamertsDouble("@c", serv.costo);
                res = conection.ExecuteCommandNonQuery("INSERT INTO ServiciosHistorial (IDServicio, IDEmpleado, FechaServicio, CostoServicio, PorcentajeCobro) Values (@ids,@ide,@f,@c,@p)");
                conection.CloseDataBase();

            }
            catch (Exception e)
            {

                string msg = e.ToString();
                MessageBox.Show(msg, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            
            return res;
        }


        public int UpdatePrice(double c, int id) {

            int res = 0;
            DataBaseConection conection = new DataBaseConection();
            try {
                conection.OpenDataBase();
                conection.CreateCommand();
                conection.sqlCommandParamertsInt("@id", id);
                conection.sqlCommandParamertsDouble("@c", c);
                res = conection.ExecuteCommandNonQuery("UPDATE Servicios SET Costo = @c WHERE Servicios.IDServicio = @id");
               conection.CloseDataBase();
            }

            catch (Exception e) {

                string msg = e.ToString();
                MessageBox.Show(msg, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return res;
        }

        public int UpdateName(string n, int id)
        {

            int res = 0;
            DataBaseConection conection = new DataBaseConection();
            try
            {
                conection.OpenDataBase();
                conection.CreateCommand();
                conection.sqlCommandParamertsInt("@id", id);
                conection.sqlCommandParamertsString("@n", n);
                res = conection.ExecuteCommandNonQuery("UPDATE Servicios SET Nombre = @n WHERE Servicios.IDServicio = @id");
                conection.CloseDataBase();
            }
            catch (Exception e)
            {

                string msg = e.ToString();
                MessageBox.Show(msg, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            return res;
        }

        public int deleteService(int id) {


            int res = 0;
            DataBaseConection conection = new DataBaseConection();
            try
            {
                conection.OpenDataBase();
                conection.CreateCommand();
                conection.sqlCommandParamertsInt("@id", id);
                res = conection.ExecuteCommandNonQuery("UPDATE Servicios SET activo = 0 WHERE Servicios.IDServicio = @id");
                conection.CloseDataBase();
            }
            catch (Exception e)
            {

                string msg = e.ToString();
                MessageBox.Show(msg, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            return res;

        }

    }
}
