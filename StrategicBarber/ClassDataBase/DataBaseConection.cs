using Microsoft.Data.Sqlite;
using Microsoft.VisualBasic;
using StrategicBarber.Clases;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Text;

namespace StrategicBarber.DataBase
{
    internal class DataBaseConection
    {

        private string connectionString;
        private string databasefile = "DataBaseFile.db";
        private string databaseFolder = "DataBaseField";
        private SqliteConnection connection;
        public SqliteCommand command;
        public SqliteDataReader reader;

     
        public bool connectToDataBaseVerification()
        {
            bool conexionExitosa = false;

            try
            {
                // 2. Obtenemos la ruta de AppData (Exactamente igual que en tu clase Rutas)
                string carpetaAppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

                // 3. Combinamos para obtener la ruta real del archivo .db en AppData
                string pathDb = Path.Combine(carpetaAppData, "SRoom", databaseFolder, databasefile);

                // 4. Verificamos si el archivo existe en AppData
                if (File.Exists(pathDb))
                {
                    // 5. ¡ESTA ES LA CLAVE! Armamos la cadena de conexión real con la ruta absoluta
                    connectionString = $"Data Source={pathDb};";

                    conexionExitosa = true;
                }
                else
                {
                    MessageBox.Show("No se encontró el archivo de la base de datos en la ruta segura de AppData.",
                                    "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show("Error al conectar a la base de datos: " + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return conexionExitosa;
        }


        public void OpenDataBase()
        {
            // Si por alguna razón la cadena está vacía, la armamos inmediatamente antes de conectar
            if (string.IsNullOrEmpty(connectionString))
            {
                string carpetaAppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                string pathDb = Path.Combine(carpetaAppData, "SRoom", databaseFolder, databasefile);
                connectionString = $"Data Source={pathDb};";
            }

            connection = new SqliteConnection(connectionString);
            connection.Open();
            Debug.WriteLine("Conexión a la base de datos SQLite abierta con éxito.");
        }

        public void CloseDataBase()
        {
            connection.Close();
        }

        public void CreateCommand()
        {
            if (connection == null || connection.State != System.Data.ConnectionState.Open)
            {
                throw new InvalidOperationException("La conexión a la base de datos no está abierta.");
            }
            command = connection.CreateCommand();
        }


        public void sqlCommandParamertsString(string parameter, string value)
        {

            command.Parameters.AddWithValue(parameter, value);

        }

        public void sqlCommandParamertsDouble(string parameter, double value)
        {

            command.Parameters.AddWithValue(parameter, value);

        }

        public void sqlCommandParamertsInt(string parameter, int value)
        {

            command.Parameters.AddWithValue(parameter, value);

        }



        public SqliteDataReader ExecuteCommandReader(string sql)
        {

            command.CommandText = sql;
            reader = command.ExecuteReader();
            return reader;
        }


        public int ExecuteCommandNonQuery(string sql)
        {
            command.CommandText = sql;
            int rowsAffected = command.ExecuteNonQuery();
            return rowsAffected;

        }

        public async Task<int> ExecuteComandoAsync(string sql)
        {
            command.CommandText = sql;
            int res = await command.ExecuteNonQueryAsync();
            return res;
            }
        


    }
}
