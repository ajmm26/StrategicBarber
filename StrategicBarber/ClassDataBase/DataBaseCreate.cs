using DotNetEnv;
using Microsoft.Data.Sqlite;
using OpenTK.Input;
using StrategicBarber.Clases;
using StrategicBarber.Windows;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Net;
using System.Security.Cryptography.Xml;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StrategicBarber.ClassDataBase
{
    internal class DataBaseCreate
    {


        private string databaseNameFolder = "DataBaseField";
        private string databaseNameFile = "DataBaseFile.db";
        private string databaseNameText = "Negocio.txt";
        private string rootDbText;
        private string rootDbFile;

        public bool CreateDataBaseFiles()
        {
            bool creacion = false;

            try
            {
                var carpetaExistente = Rutas.VerificarRuta(databaseNameFolder);


                if (carpetaExistente.rutaValida)
                {
                    MessageBox.Show("La carpeta para la base de datos ya existe", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                  
                    string rutaBaseDatos = Path.Combine(carpetaExistente.rutaArchivo, databaseNameFile);

                    if (!Directory.Exists(rutaBaseDatos))
                    {
                        creacion = CreateDatabaseFile(rutaBaseDatos, creacion);
                    }

                }

            }
            catch (Exception ex)
            {

                string error = ex.Message.ToString();
                MessageBox.Show("Error al crear la base de datos hhjh: " + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            return creacion;

        }

        private bool CreateDatabaseFile(string rutaBaseDatos, bool creacion)
        {
            int res = 0;
            try
            {
                string scriptSql = "CREATE TABLE Negocio (IDNegocio INTEGER PRIMARY KEY AUTOINCREMENT, NombreNegocio TEXT, PorcentajeCobro REAL DEFAULT NULL, FechaCreacion TEXT NOT NULL); CREATE TABLE Roles (IDRol INTEGER PRIMARY KEY AUTOINCREMENT, NombreRol TEXT NOT NULL); CREATE TABLE Usuario (IDUser INTEGER PRIMARY KEY AUTOINCREMENT, NombrePersona TEXT NOT NULL, NombreUsuario TEXT NOT NULL UNIQUE, ApellidoPersona TEXT NOT NULL, ClaveUsuario TEXT NOT NULL, IDRol INTEGER NOT NULL, FOREIGN KEY (IDRol) REFERENCES Roles(IDRol)); CREATE TABLE Empleado (IDEmpleado INTEGER PRIMARY KEY AUTOINCREMENT, Nombre TEXT NOT NULL, Apellido TEXT NOT NULL, DNI INTEGER NOT NULL UNIQUE, PorcentajeCobro REAL DEFAULT NULL, PorcentajeEspecial INTEGER DEFAULT 0 NOT NULL, empleadoActivo INTEGER DEFAULT 1 NOT NULL);CREATE TABLE IF NOT EXISTS Servicios (IDServicio INTEGER PRIMARY KEY AUTOINCREMENT, Nombre TEXT NOT NULL, Costo REAL NOT NULL, activo INTEGER DEFAULT 1 NOT NULL); CREATE TABLE IF NOT EXISTS ServiciosHistorial (IDServicioHistorial INTEGER PRIMARY KEY AUTOINCREMENT, IDServicio INTEGER NOT NULL, IDEmpleado INTEGER NOT NULL, FechaServicio TEXT NOT NULL, CostoServicio REAL NOT NULL, PorcentajeCobro REAL NOT NULL, FOREIGN KEY (IDServicio) REFERENCES Servicios(IDServicio), FOREIGN KEY (IDEmpleado) REFERENCES Empleado(IDEmpleado)); CREATE TABLE IF NOT EXISTS Codigos (IDCodigo INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, Codigo TEXT); CREATE UNIQUE INDEX IF NOT EXISTS idx_empleado_dni ON Empleado(DNI); CREATE INDEX IF NOT EXISTS idx_usuario_rol ON Usuario(IDRol);  CREATE INDEX IF NOT EXISTS idx_historial_empleado ON ServiciosHistorial(IDEmpleado); CREATE INDEX IF NOT EXISTS idx_historial_servicio ON ServiciosHistorial(IDServicio); CREATE INDEX IF NOT EXISTS idx_historial_fecha ON ServiciosHistorial(FechaServicio); CREATE INDEX IF NOT EXISTS idx_nombre_apellido ON Empleado(Nombre, Apellido); INSERT INTO ROLES (NombreRol) VALUES ('Administrador'); INSERT INTO ROLES (NombreRol) VALUES ('Gerente'); CREATE TRIGGER TR_ActualizarPorcentajeGlobal AFTER UPDATE of PorcentajeCobro on Negocio FOR EACH ROW Begin UPDATE EMPLEADO SET PorcentajeCobro = NEW.PorcentajeCobro WHERE PorcentajeEspecial = 0; END; CREATE TRIGGER TR_BorrarPorcentajeEspecial AFTER UPDATE OF PorcentajeCobro ON Empleado FOR EACH ROW BEGIN UPDATE Empleado SET PorcentajeEspecial = 0, PorcentajeCobro = (SELECT PorcentajeCobro FROM Negocio WHERE IDNegocio = 1) WHERE IDEmpleado = NEW.IDEmpleado AND NEW.PorcentajeCobro = 0 AND OLD.PorcentajeEspecial = 1 AND OLD.PorcentajeCobro > 0; END;";
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


    }
}
