using Microsoft.Data.Sqlite;
using StrategicBarber.Clases;
using StrategicBarber.DataBase;
using StrategicBarber.Windows;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace StrategicBarber.ClassDataBase
{
    internal class DataBaseConsultasDatosFacturacion
    {

        public List<FacturacionServicios> GetDataFact(string diaInicio, string diaFin, int idx) { 
        
            List<FacturacionServicios> listFactDaily = new List<FacturacionServicios>();
            DataBaseConection conection = new DataBaseConection();
            try {
                conection.OpenDataBase();
                conection.CreateCommand();
                conection.sqlCommandParamertsString("@fi", diaInicio);
                conection.sqlCommandParamertsString("@ff", diaFin);
                conection.sqlCommandParamertsInt("@idx", idx);
                SqliteDataReader reader =  conection.ExecuteCommandReader("SELECT S.nombre, count(sh.IDServicio) as Cantidad, s.Costo as CostoActual,sum(sh.CostoServicio) as totalGenerado FROM ServiciosHistorial sh left join Servicios s on s.IDServicio = sh.IDServicio WHERE sh.FechaServicio BETWEEN @fi and @ff Group by s.Nombre ORDER by cantidad DESC LIMIT 10 OFFSET @idx");
                while (reader.Read()) {
                    FacturacionServicios fact = new FacturacionServicios();
                    fact.nombre = reader["Nombre"].ToString();
                    fact.cantidad = int.Parse(reader["Cantidad"].ToString());
                    fact.costo = double.Parse(reader["CostoActual"].ToString());
                    fact.totalGenerado = double.Parse(reader["totalGenerado"].ToString());
                    listFactDaily.Add(fact);
                }
                reader.Close();
                conection.CloseDataBase();
            }
            catch (Exception ex) {
                MessageBox.Show("Error: "+ex.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            }

            return listFactDaily;
        }


        public List<FacturacionEmpleados> GetDataEmpleados(string diaInicio, string diaFin, int idx)
        {

            List<FacturacionEmpleados> listFactDaily = new List<FacturacionEmpleados>();
            DataBaseConection conection = new DataBaseConection();
            try
            {
                conection.OpenDataBase();
                conection.CreateCommand();
                conection.sqlCommandParamertsString("@fi", diaInicio);
                conection.sqlCommandParamertsString("@ff", diaFin);
                conection.sqlCommandParamertsInt("@idx", idx);
                SqliteDataReader reader = conection.ExecuteCommandReader("SELECT Concat(E.Nombre,' ',E.Apellido) as nombreCompleto, E.DNI as dni ,count(s.IDEmpleado) as CantServicios  ,E.PorcentajeCobro as pc, sum(S.CostoServicio) as totalGenerado from ServiciosHistorial s Left join Empleado E on s.IDEmpleado = E.IDEmpleado WHERE s.FechaServicio BETWEEN @fi AND @ff GROUP BY E.IDEmpleado, nombreCompleto, E.DNI, E.PorcentajeCobro ORDER BY totalGenerado DESC, E.DNI ASC  LIMIT 10 OFFSET @idx ");
                while (reader.Read())
                {
                    FacturacionEmpleados fact = new FacturacionEmpleados();
                    fact.nombre = reader["nombreCompleto"].ToString();
                    fact.dni = int.Parse(reader["dni"].ToString());
                    fact.CantidadServicios = int.Parse(reader["CantServicios"].ToString());
                    fact.porcentajeCobroEmpleado = double.Parse(reader["pc"].ToString());
                    fact.totalGenerado = double.Parse(reader["totalGenerado"].ToString());
                    listFactDaily.Add(fact);
                }
                reader.Close();
                conection.CloseDataBase();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            return listFactDaily;
        }


        public double GetTotalGeneratedServicios(string i, string f) {
            double result = 0;
            DataBaseConection conection = new DataBaseConection();
            try
            {
                conection.OpenDataBase();
                conection.CreateCommand();
                conection.sqlCommandParamertsString("@fi", i);
                conection.sqlCommandParamertsString("@ff", f);
                SqliteDataReader reader = conection.ExecuteCommandReader("select sum(sh.CostoServicio) as totalGenerado from ServiciosHistorial sh WHERE sh.FechaServicio BETWEEN @fi and @ff");
                if (reader.Read())
                {
                    double.TryParse(reader["totalGenerado"].ToString(), out result);
                }
                reader.Close();
                conection.CloseDataBase();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            return result;
        }


        public int GetCantEmpleadoPay(string fi, string ff)
        {



            int res = 0;
            DataBaseConection conection = new DataBaseConection();
            conection.OpenDataBase();
            conection.CreateCommand();
            conection.sqlCommandParamertsString("@fi", fi);
            conection.sqlCommandParamertsString("@ff", ff);
            SqliteDataReader reader = conection.ExecuteCommandReader("select count(DISTINCT sh.IDEmpleado) from ServiciosHistorial sh Where sh.FechaServicio BETWEEN @fi and @ ff");
            if (reader.Read())
            {

                res = reader.GetInt32(0);

            }
            reader.Close();
            conection.CloseDataBase();
            return res;
        }

        public int getCantServices(string fi, string ff)
        {
            int res = 0;
            DataBaseConection conection = new DataBaseConection();
            conection.OpenDataBase();
            conection.CreateCommand();
            conection.sqlCommandParamertsString("@fi", fi);
            conection.sqlCommandParamertsString("@ff", ff);
            SqliteDataReader reader = conection.ExecuteCommandReader("select count(DISTINCT sh.IDServicio) from ServiciosHistorial sh Where sh.FechaServicio BETWEEN @fi and @ff");
            if (reader.Read())
            {
                res = reader.GetInt32(0);
            }
            reader.Close();
            conection.CloseDataBase();
            return res;

        }
    }
}
