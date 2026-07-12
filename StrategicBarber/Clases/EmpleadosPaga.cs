using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace StrategicBarber.Clases
{
    internal class EmpleadosPaga
    {
        [DisplayName("Nombre Completo")]
        public string nombre { set; get; }

        [DisplayName("DNI")]
        public int dni { set; get; }

        [DisplayName("Cantidad DE Servicios")]
        public int CantidadServicios { set; get; }

        [DisplayName("Total Generado")]
        public double totalGenerado { set; get; }

        [DisplayName("Cantidad A Pagar")]
        public double cantPay { set; get; }

        [DisplayName("Porcentaje Cobro")]
        public double porcentajeCobroEmpleado { set; get; }



    }
}
