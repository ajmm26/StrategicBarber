using System;
using System.Collections.Generic;
using System.Text;

namespace StrategicBarber.Clases
{
    internal class ClassNegocio
    {
        public int id { get; set; }
        public string nombreNegocio { get; set; }
        public double porcentajeGloblal { get; set; }
        public string date { get; set; }

        public int fallout { get; set; }

        public ClassNegocio()
        {
        }

        public ClassNegocio(string nombreNegocio, double porcentajeGloblal, string date)
        {
            this.nombreNegocio = nombreNegocio;
            this.porcentajeGloblal = porcentajeGloblal;
            this.date = date;
        }

       public ClassNegocio(string nombreNegocio, string date)
        {
            this.nombreNegocio = nombreNegocio;
            this.date = date;
        }


    }
}
