using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace StrategicBarber.Clases
{
    public class ClassServicio
    {

        public int id { set; get; } 
        public string nombre { get; set; }

        public double costo { set; get; }


        public ClassServicio() { }

        public ClassServicio(string n, double c) {
        nombre = n; 
            
        costo = c;

        }


        public bool verificarNombre(string n)
        {
            Debug.WriteLine("EL nombre ES: " + n.ToString());

            if (this.nombre == n) {

                return false;
            }

            return true;
        }


       public bool verificarCosto(double c)
        {
            Debug.WriteLine("EL COSTO ES: " + c.ToString());

            if (this.costo == c ||  c == null || c==0)
            {
                return false;
            }
            return true;
        }
    }
}
