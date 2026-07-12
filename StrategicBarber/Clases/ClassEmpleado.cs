using System;
using System.Collections.Generic;
using System.Text;

namespace StrategicBarber.Clases
{
    public class ClassEmpleado
    {

        public string nombre { set; get; }

        public string apellido { set; get; }

        public int dni { set; get; }

        public double porcentajeCobro { set; get; }

        public int id { set; get; }

        public int ban { set; get; }

        public ClassEmpleado() { }

        public ClassEmpleado(string n, string a, int d, double porcentaje, int b,int i=0) { 
        
        nombre = n;
        apellido = a;
        dni = d;
        porcentajeCobro = porcentaje;
        this.ban = b;
        id = i;

        }

        public bool verificarDni(int d) {

             
            if (d > 0 ) { 
            
              return true;
            
            }

            return false;
        }

        public bool verificarNombre(string n)
        {


            if (this.nombre != n)
            {

                return true;

            }

            return false;
        }

        public bool verificarApellido(string a)
        {


            if (a != this.apellido)
            {

                return true;

            }

            return false;
        }

    }
}
