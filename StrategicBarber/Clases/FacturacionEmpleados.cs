using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Collections;
using System.Data.Entity;
using StrategicBarber.DataBase;

namespace StrategicBarber.Clases
{
    internal class FacturacionEmpleados
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
        public double cantPaga { set; get; }
         
        [DisplayName("Porcentaje Cobro")]
        public double porcentajeCobroEmpleado { set; get; }




        public void cargarDatagried(IList listFacTEmpleados, DataGridView dtgvDatosFact, ref double comisiones)
        {
            if (listFacTEmpleados == null || listFacTEmpleados.Count == 0) return;

            var listaTipada = (List<FacturacionEmpleados>)listFacTEmpleados;

            // 2. Calculamos el porcentaje para cada objeto de la lista
            foreach (FacturacionEmpleados fact in listaTipada)
            {
                fact.cantPaga = calcularComisiones(fact);
                comisiones += fact.cantPaga; // Acumulamos la comisión total
            }

            // 3. Limpiamos y asignamos la lista directamente a tu DataGridView REAL de la pantalla
            dtgvDatosFact.DataSource = null; // Reseteas para evitar bugs visuales
            dtgvDatosFact.DataSource = listFacTEmpleados;


        }


        private double calcularComisiones(FacturacionEmpleados fact)
        {
            DataBaseNegocio dbN = new DataBaseNegocio();
            ClassNegocio neg = dbN.ObtenerNegocio();
            double resultado = 0;

            if (fact.porcentajeCobroEmpleado > 0 && fact.totalGenerado > 0) {

                resultado = fact.totalGenerado * (fact.porcentajeCobroEmpleado / 100);
               return resultado;
            }

            if (neg.porcentajeGloblal > 0 && fact.totalGenerado > 0) {

                resultado = fact.totalGenerado * (neg.porcentajeGloblal / 100);
                return resultado;
            }
            return resultado;
        }

    }
}
