using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.WinForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
namespace StrategicBarber.Clases
{
    internal class FacturacionServicios
    {
        [DisplayName("Nombre")]
       public string nombre { set; get; }

        [DisplayName("Costo Servicio")]
        public double costo { set; get; }

        [DisplayName("Cantidad Servicio")]
        public  int cantidad { set; get; }

        [DisplayName("Total Generado")]
        public double totalGenerado { set; get; }

        [DisplayName("Porcentaje %")]
        public string porcentajes { set; get; }


        public void cargarDatagried(IList listFact, DataGridView dtgvDatosFact, double total)
        {
            var listaTipada = (List<FacturacionServicios>)listFact;

            if (listFact == null || listFact.Count == 0) return;

            // 2. Calculamos el porcentaje para cada objeto de la lista
            foreach (FacturacionServicios fact in listFact)
            {
                double totalServicio = Convert.ToDouble(fact.totalGenerado);
                double porcentaje = (total > 0) ? (totalServicio / total) * 100 : 0;

                // Asignamos el string formateado a la propiedad 'Porcentaje' de tu clase Facturacion
                fact.porcentajes = porcentaje.ToString("0.0") + "%";
            }

            // 3. Limpiamos y asignamos la lista directamente a tu DataGridView REAL de la pantalla
            dtgvDatosFact.DataSource = null; // Reseteas para evitar bugs visuales
            dtgvDatosFact.DataSource = listFact;

        }

     


    }
}
