using Microsoft.Data.Sqlite;
using StrategicBarber.Clases;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace StrategicBarber.ClassDataBase
{
    internal class DataBaseCreate
    {


      
        private string rootDbText;
        private string rootDbFile;

        public bool CreateDataBaseFiles()
        {
            bool creacion = false;

            try
            {
                var carpetaExistente = Rutas.VerificarRuta(Environment.GetEnvironmentVariable("databaseNameFolder"));


                if (carpetaExistente.rutaValida)
                {
                    MessageBox.Show("La carpeta para la base de datos ya existe. Es: " + carpetaExistente.rutaArchivo, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    string rutaTexto = Path.Combine(carpetaExistente.rutaArchivo, Environment.GetEnvironmentVariable("databaseNameText"));

                    if (!Directory.Exists(rutaTexto))
                    {
                        CreateDatabaseText(rutaTexto);
                        rootDbText = rutaTexto;
                    }

                    string rutaBaseDatos = Path.Combine(carpetaExistente.rutaArchivo, Environment.GetEnvironmentVariable("databaseNameFile"));

                    if (!Directory.Exists(rutaBaseDatos))
                    {
                        creacion = CreateDatabaseFile(rutaBaseDatos, creacion);
                    }

                }

            }
            catch (Exception ex)
            {

                string error = ex.Message.ToString();
                MessageBox.Show("Error al crear la base de datos: " + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            return creacion;

        }

        private bool CreateDatabaseFile(string rutaBaseDatos, bool creacion)
        {
            int res = 0;
            try
            {
                string scriptSql = File.ReadAllText(rootDbText);
                string connectionString = $"Data Source={rutaBaseDatos};";
                using (SqliteConnection connection = new SqliteConnection(connectionString))
                {
                    connection.Open();

                    using (SqliteCommand command = connection.CreateCommand())
                    {
                        // Pasamos el texto del .txt como el comando a ejecutar
                        command.CommandText = scriptSql;

                        // Ejecuta todos los CREATE TABLE y CREATE INDEX en bloque
                        res = command.ExecuteNonQuery();
                    }
                }
                if (res == 1)
                {

                    MessageBox.Show("Se ha creado el archivo de base de datos", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                rootDbFile = rutaBaseDatos;
                creacion = true;

            }
            catch (Exception ex)
            {
                string error = ex.Message.ToString();
                MessageBox.Show("Error al crear la base de datos File: " + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return creacion;
        }


        private void CreateDatabaseText(string rutaBaseDatosTexto)
        {

            try
            {

                File.WriteAllText(rutaBaseDatosTexto, Environment.GetEnvironmentVariable("SQL_SCHEMA"));
                MessageBox.Show("Se ha creado el archivo de texto para la base de datos", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                rootDbText = rutaBaseDatosTexto;

            }
            catch (Exception ex)
            {
                string error = ex.Message.ToString();
                MessageBox.Show("Error al crear la base de datos Texto: " + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


    }
}
