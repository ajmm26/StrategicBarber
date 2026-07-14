using Microsoft.Data.Sqlite;
using StrategicBarber.Clases;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategicBarber.DataBase
{
    internal class DataBaseNegocio
    {

        public int agregarNegocio(ClassNegocio neg) {

            int respuesta = 0;
            try {

                DataBaseConection conection = new DataBaseConection();

                bool existenciaDataBase = conection.connectToDataBaseVerification();

                if (existenciaDataBase)
                {

                    conection.OpenDataBase();

                    conection.CreateCommand();

                    conection.sqlCommandParamertsString("@NombreNegocio", neg.nombreNegocio);
                    conection.sqlCommandParamertsString("@FechaCreacion", neg.date);
                    if (double.IsPositive(neg.porcentajeGloblal))
                    {
                        conection.sqlCommandParamertsDouble("@PorcentajeCobro", neg.porcentajeGloblal);
                        respuesta = conection.ExecuteCommandNonQuery("INSERT INTO Negocio (NombreNegocio,PorcentajeCobro,FechaCreacion) VALUES (@NombreNegocio,@PorcentajeCobro,@FechaCreacion)");
                    }
                    else {
                        respuesta = conection.ExecuteCommandNonQuery("INSERT INTO Negocio (NombreNegocio,FechaCreacion) VALUES (@NombreNegocio,@FechaCreacion)");
                    }
                    conection.CloseDataBase();
                }

            }
            catch (Exception ex){
            
                string msg = ex.ToString();
                MessageBox.Show("No se ha podido agregar el negocio. Erro: " +msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
    
            return respuesta;
        }

        public ClassNegocio ObtenerNegocio()
        {
            DataBaseConection conection = new DataBaseConection();
            ClassNegocio newNegocio = new ClassNegocio();

            try {

            conection.OpenDataBase();
            conection.CreateCommand();
            conection.sqlCommandParamertsInt("@IDNegocio", 1);
            SqliteDataReader reader = conection.ExecuteCommandReader("SELECT * from Negocio where IDNegocio=@IDNegocio LIMIT 1");
                if (reader.Read()) {
                    newNegocio.nombreNegocio = reader["NombreNegocio"].ToString();
                    newNegocio.id = int.Parse(reader["IDNegocio"].ToString());
                    newNegocio.date = reader["FechaCreacion"].ToString();
                    newNegocio.porcentajeGloblal = double.Parse(reader["PorcentajeCobro"].ToString());
                }
                reader.Close();
                conection.CloseDataBase();
            } catch (Exception ex) { 
            
                string msg = ex.ToString();
                MessageBox.Show("No se ha podido obtener el negocio. Error: " + msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                newNegocio.fallout = 1;
                return newNegocio;
            }
           

        return newNegocio;
        }


        public async Task<int> modificarPorcentaje(double porcent) {

            DataBaseConection conection = new DataBaseConection();
            int response=0;

            try {
                conection.OpenDataBase();
                conection.CreateCommand();
                conection.sqlCommandParamertsDouble("@porcentaje", porcent);
                response = await conection.ExecuteComandoAsync("UPDATE Negocio SET PorcentajeCobro=@porcentaje WHERE IDNegocio=1");
                conection.CloseDataBase();
            }
            catch (Exception ex) {
                string msg = ex.ToString();
                MessageBox.Show("Ha ocurrido un error en el proceso: " + msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return response;
        
        }

        public int modificarNombre(string name)
        {

            DataBaseConection conection = new DataBaseConection();
            int response = 0;

            try
            {
                conection.OpenDataBase();
                conection.CreateCommand();
                conection.sqlCommandParamertsString("@name", name);
                response = conection.ExecuteCommandNonQuery("UPDATE Negocio SET NombreNegocio=@name WHERE IDNegocio=1");
                conection.CloseDataBase();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                MessageBox.Show("Ha ocurrido un error en el proceso: "+msg,"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return response;

        }


        public string verificacionNegocioValido() {

            string dato = string.Empty;
            DataBaseConection conection = new DataBaseConection();

            try
            {

                conection.OpenDataBase();
                conection.CreateCommand();
                conection.sqlCommandParamertsInt("@IDNegocio", 1);
                SqliteDataReader reader = conection.ExecuteCommandReader(Environment.GetEnvironmentVariable("consulta_verificacion"));
                if (reader.Read())
                {
                   dato = reader.GetString(0);
                }
                reader.Close();
                conection.CloseDataBase();
            }
            catch (Exception ex)
            {

                string msg = ex.ToString();
                MessageBox.Show("No se ha podido obtener el negocio. Error: " + msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }

            return dato;
        }


        public string getCodeMembresy()
        {
            string codigo = null;
            DataBaseConection conection = new DataBaseConection();
            conection.OpenDataBase();
            conection.CreateCommand();
            SqliteDataReader reader = conection.ExecuteCommandReader("Select Codigo from Codigos ORDER BY IDCodigo DESC Limit 1");
            if (reader.Read())
            {
                codigo = reader.GetString(0);
            }
            reader.Close();
            conection.CloseDataBase();
            return codigo;


        }


        public int insertCode(string c) {

            int res = 0;
            try
            {
                DataBaseConection conection = new DataBaseConection();
                conection.OpenDataBase();
                conection.CreateCommand();
                conection.sqlCommandParamertsString("@c", c);
                res = conection.ExecuteCommandNonQuery("Insert into CODIGOS (Codigo) VALUES (@c)");
                conection.CloseDataBase();
            }catch(Exception ex) {

                string msg = ex.ToString();
                MessageBox.Show("Error al guardar el codigo: " + msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
          
          return res;

        }


    }
}
