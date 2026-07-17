using System;
using System.Collections.Generic;
using System.Text;

namespace StrategicBarber.Clases
{
    public class ClassUsuario
    {
        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Usuario { get; set; }
        public string password { get; set; }
        public int idRol { get; set; }

        public int userid { get; set; }

        public string Rol { get; set; }

        public ClassUsuario(){}


        public ClassUsuario(string n, string a, string u, string p, int idR) { 
        
        
        Nombre = n;
        Apellido = a;
        Usuario = u;
        password = p;
        idRol = idR;
        
        }
    }
}
