using LiveChartsCore;
using LiveChartsCore.Measure;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.WinForms;
using StrategicBarber.Clases;
using StrategicBarber.ClassDataBase;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Mapping;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Text;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace StrategicBarber.Windows
{
    public partial class DatosFacturacion : Form
    {
        double total = 0;
        string tiempo;
        string inicio = string.Empty;
        string fin = string.Empty;
        IList x = null;
        int modo;
        int offset = 0;
        int numPaginas = 0;
        int paginaActual = 1;

        public DatosFacturacion(string t, int modo)
        {
            tiempo = t;
            this.modo = modo;
            InitializeComponent();
        }

        private void DatosFacturacion_Load(object sender, EventArgs e)
        {
            tituloFact.Text += " " + tiempo;
            DataBaseConsultasDatosFacturacion dbf  = new DataBaseConsultasDatosFacturacion();
            establecerModalidadTemporal();
            this.total = dbf.GetTotalGeneratedServicios(inicio, fin);
            numPaginas = (int)Math.Ceiling(dbf.getCantServices(inicio, fin)/10.0);
            createPieChart(1);
            drawDataGried();
            createButtonsPagination();

        }
        

        private void drawDataGried() {
          
          FacturacionServicios fact = new FacturacionServicios();
          fact.cargarDatagried(x, dtgvDatosFact, total);
               
        }


        private void FechasActuales()
        {
            DataBaseConsultasDatosFacturacion dbf = new DataBaseConsultasDatosFacturacion();
            DateTime hoy = DateTime.Now;
           

            switch (tiempo.ToLower())
            {

                case "diaria":
                   
                    inicio = hoy.ToString("yyyy-MM-dd 00:00:00");
                    DateTime fechaFin = DateTime.Now;
                    fin = fechaFin.ToString("yyyy-MM-dd 23:59:59");
                   
                    break;

                case "mensual":
                    radioButtonAct.Text = "Mes Actual";
                    radioButtonYest.Text = "Mes Anterior";
                    DateTime primerDiaDelMes = new DateTime(hoy.Year, hoy.Month, 1);
                    inicio = primerDiaDelMes.ToString("yyyy-MM-dd 00:00:00");
                    fin = hoy.ToString("yyyy-MM-dd 23:59:59");
                   
                    break;

                case "semanal":
                    radioButtonAct.Text = "Semana Actual";
                    radioButtonYest.Text = "Semnana Anterior";
                    int diasParaRestar = (hoy.DayOfWeek == DayOfWeek.Sunday) ? 6 : (int)hoy.DayOfWeek - 1;
                    DateTime lunesActual = hoy.AddDays(-diasParaRestar).Date;
                    inicio = lunesActual.ToString("yyyy-MM-dd 00:00:00");
                    DateTime domingoActual = lunesActual.AddDays(6);
                    fin = domingoActual.ToString("yyyy-MM-dd 23:59:59");
                    
                    break;

                case "semestral":
                    radioButtonAct.Text = "1er Semestre";
                    radioButtonYest.Text = "2do Semestre";
                    obtenerSemestre();
                    
                    break;

                case "anual":
                    radioButtonAct.Text = "Año Actual";
                    radioButtonYest.Text = "Año Anterior";
                    inicio = new DateTime(hoy.Year, 1, 1).ToString("yyyy-MM-dd 00:00:00");
                    fin = new DateTime(hoy.Year, 12, 31).ToString("yyyy-MM-dd 23:59:59");
                    
                    break;

                case "por fecha":
                    modoFechaEspecifica();
                    estilosFechaEspecifica();
                    break;
            }


            numPaginas = (int)Math.Ceiling(dbf.getCantServices(inicio, fin) / 10.0);
            createButtonsPagination();
        }


        private void establecerModalidadTemporal() {

            DataBaseConsultasDatosFacturacion dbf = new DataBaseConsultasDatosFacturacion();

            switch (modo) {

                case 0:
                    FechasActuales();
                    break;
                case 1:
                    FechasAnteriores();
                    break;
                case 2:
                    modoFechaEspecifica();
                    estilosFechaEspecifica();
                    break;
            
            }

            numPaginas = (int)Math.Ceiling(dbf.getCantServices(inicio, fin) / 10.0);
            createButtonsPagination();

        }

        private bool FechasAnteriores()
        {
            bool fechas;
            DateTime hoy = DateTime.Now;
            DateTime fechaObjetivo = DateTime.Now;
            switch (tiempo.ToLower())
            {

                case "diaria":
                    hoy = hoy.AddDays(-1);
                    inicio = hoy.ToString("yyyy-MM-dd 00:00:00");
                    fin = hoy.ToString("yyyy-MM-dd 23:59:59");
                   
                    break;

                case "semanal":

                    // 1. Encontramos el lunes de la semana ACTUAL
                    int diasParaRestar = (hoy.DayOfWeek == DayOfWeek.Sunday) ? 6 : (int)hoy.DayOfWeek - 1;
                    DateTime lunesActual = hoy.AddDays(-diasParaRestar).Date;
                    DateTime lunesSemanaPasada = lunesActual.AddDays(-7);
                    inicio = lunesSemanaPasada.ToString("yyyy-MM-dd 00:00:00");
                    DateTime domingoSemanaPasada = lunesSemanaPasada.AddDays(6);
                    fin = domingoSemanaPasada.ToString("yyyy-MM-dd 23:59:59");
                    
                    break;

                case "mensual":
                    hoy = new DateTime(hoy.Year, hoy.Month, 1).AddMonths(-1);
                    inicio = hoy.ToString("yyyy-MM-dd 00:00:00");
                    fechaObjetivo = hoy.AddMonths(1).AddSeconds(-1);
                    fin = fechaObjetivo.ToString("yyyy-MM-dd 23:59:59");
                   
                    break;

                case "semestral":
                    obtenerSemestre(true);
                    
                    break;

                case "anual":
                    radioButtonAct.Text = "Año Actual";
                    radioButtonYest.Text = "Año Anterior";
                    DateTime Ahoy = DateTime.Now; // Toma el año en curso (2026)
                    inicio = new DateTime(Ahoy.Year, 1, 1).AddYears(-1).ToString("yyyy-MM-dd 00:00:00");
                    fin = new DateTime(Ahoy.Year, 12, 31).AddYears(-1).ToString("yyyy-MM-dd 23:59:59");
                   
                    break;

                case "por fecha":
                    modoFechaEspecifica();
                    estilosFechaEspecifica();
                    break;
            }
            return fechas = verificarStringFecha();
        }



        private void obtenerDatos() {
           DataBaseConsultasDatosFacturacion dbF = new DataBaseConsultasDatosFacturacion();
            calcularPagina();
                    x = null;
                    x = dbF.GetDataFact(inicio, fin, offset);
        }


        private void createPieChart( int tmp)
        {
            panelChart.Controls.Clear();
       

            obtenerDatos();

            if (x == null || x.Count == 0 && tiempo != "Por Fecha")
            {
                MessageBox.Show("No tiene datos en esta fecha", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            PieChart chart = new PieChart();
            chart.Size = new System.Drawing.Size(panelContent.Width, panelContent.Height);
            chart.Dock = DockStyle.Fill;

            // ─── 🛠️ AQUÍ ACTIVAMOS LA LEYENDA Y EL TOOLTIP ───

            // 1. Mostrar la leyenda a la derecha (Right). 
            // También puedes usar Top, Bottom o Left si cambia el diseño de tu panel.
            chart.LegendPosition = LiveChartsCore.Measure.LegendPosition.Bottom;

            // 2. Mostrar el Tooltip flotante al pasar el mouse por encima
            chart.TooltipPosition = LiveChartsCore.Measure.TooltipPosition.Bottom;

            // ────────────────────────────────────────────────

            List<ISeries> series = new List<ISeries>();
            foreach (dynamic fact in x)
            {
                var nuevaSerie = new PieSeries<double>
                {
                    Values = new double[] { fact.totalGenerado },
                    Name = fact.nombre,
                    DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Middle,
                    DataLabelsFormatter = punto => $"{punto.Coordinate.PrimaryValue:C2}"
                };
                series.Add(nuevaSerie);
            }

            chart.Series = series;
            panelChart.Controls.Add(chart);

            chart.Update();

            txtTotal.Text = " ";
            txtTotal.Text = "Total Generado: " + total.ToString();
            panelChart.Refresh();
        }

        private void radioButtonYest_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioButtonYest.Checked) return;
                 modo = 1;
                establecerModalidadTemporal();
               createPieChart(0);
                drawDataGried();
        }

        private void radioButtonAct_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioButtonAct.Checked) return;
             modo = 0;
            establecerModalidadTemporal();
             createPieChart(1);
             drawDataGried();
        }

        private void obtenerSemestre(bool calcularAnterior = false)
        {
            DateTime hoy = DateTime.Now;
            int anio = hoy.Year;

            // 1. Averiguamos en qué semestre estamos HOY (1 o 2)
            int semestreActual = (hoy.Month <= 6) ? 1 : 2;

            // 2. Si nos piden el anterior, calculamos matemáticamente cuál fue
            int semestreADeterminar = semestreActual;
            if (calcularAnterior)
            {
                if (semestreActual == 1)
                {
                    // Si hoy es S1, el anterior fue el S2 del AÑO PASADO
                    semestreADeterminar = 2;
                    anio = anio - 1;
                }
                else
                {
                    // Si hoy es S2, el anterior fue el S1 de ESTE MISMO AÑO
                    semestreADeterminar = 1;
                    // El año se queda igual
                }
            }

            // 3. Ahora que sabemos el semestre exacto y el año exacto, armamos las fechas fijas
            if (semestreADeterminar == 1)
            {
                // Primer Semestre (S1) estricto
                inicio = new DateTime(anio, 1, 1).ToString("yyyy-MM-dd 00:00:00");
                fin = new DateTime(anio, 6, 30).ToString("yyyy-MM-dd 23:59:59");
            }
            else
            {
                // Segundo Semestre (S2) estricto
                inicio = new DateTime(anio, 7, 1).ToString("yyyy-MM-dd 00:00:00");
                fin = new DateTime(anio, 12, 31).ToString("yyyy-MM-dd 23:59:59");
            }
        }

        private void modoFechaEspecifica()
        {
            radioButtonAct.Visible = false;
            radioButtonYest.Visible = false;
            Dtp1.Visible = true;
            Dtp3.Visible = true;
            txtDesde.Visible = true;
            txtHasta.Visible = true;
            buttonSearchDate.Visible = true;

        }


        private void estilosFechaEspecifica()
        {

            Dtp1.MaxDate = DateTime.Now;
            Dtp3.MaxDate = DateTime.Now;
            Dtp1.Format = DateTimePickerFormat.Custom;
            Dtp1.CustomFormat = "dd / MM / yyyy";
            Dtp3.Format = DateTimePickerFormat.Custom;
            Dtp3.CustomFormat = "dd / MM / yyyy";
            Dtp1.CalendarMonthBackground = Color.White;

            // Cambia el color del texto de los días dentro del calendario
            Dtp1.CalendarTitleForeColor = Color.FromArgb(31, 31, 31); // Gris oscuro moderno

            // Cambia el color de fondo de la barra de título del calendario desplegado
            Dtp1.CalendarTitleBackColor = Color.LightGray;

            Dtp3.CalendarMonthBackground = Color.White;

            // Cambia el color del texto de los días dentro del calendario
            Dtp3.CalendarTitleForeColor = Color.FromArgb(31, 31, 31); // Gris oscuro moderno

            // Cambia el color de fondo de la barra de título del calendario desplegado
            Dtp3.CalendarTitleBackColor = Color.LightGray;
        }


        private bool obtenerFechaEspecifica()
        {
            inicio = Dtp1.Value.ToString("yyyy-MM-dd 00:00:00");
            fin = Dtp3.Value.ToString("yyyy-MM-dd 23:59:59");

            if (string.IsNullOrEmpty(inicio) || string.IsNullOrEmpty(fin) || inicio == fin)
            {

                MessageBox.Show("Por favor, seleccione un rango de fechas válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; 

            }
            return true;
        }

        private void buttonSearchDate_Click(object sender, EventArgs e)
        {
            DataBaseConsultasDatosFacturacion dbf = new DataBaseConsultasDatosFacturacion();
            bool res = obtenerFechaEspecifica();
            if (res) {
                modo = 2;
                this.total = dbf.GetTotalGeneratedServicios(inicio, fin);
                createPieChart(2);
                drawDataGried();

            }


        }

        private bool verificarStringFecha() {

            if (string.IsNullOrEmpty(inicio) || string.IsNullOrEmpty(inicio)) {
            return false;
            }
            return true;
        }


        private void calcularPagina() {

            if (paginaActual != 0) {
                offset = 10 * (paginaActual - 1);
            }
        
        }

        private void createButtonsPagination()
        {
            flpanel.Controls.Clear();


            if (numPaginas > 1) { 
            Button btnPrimera = new Button();
            btnPrimera.Text = "<<";
           // btnPrimera.Click += flpButtons_Click;

            Button btnAnterior = new Button();
            btnAnterior.Text = "<";
           // btnAnterior.Click += flpButtons_Click;

            flpanel.Controls.Add(btnPrimera);
            flpanel.Controls.Add(btnAnterior);
            }


            for (int i = 0; i < numPaginas; i++)
            {

                Button page = new Button();
                page.Text = (i + 1).ToString();
                //page.Click += flpButtons_Click;
                flpanel.Controls.Add(page);

            }


            if (numPaginas > 1) { 
            
            Button btnUlt = new Button();
            btnUlt.Text = ">>";
            //btnUlt.Click += flpButtons_Click;

            Button btnSig = new Button();
            btnSig.Text = ">";
           // btnSig.Click += flpButtons_Click;

            flpanel.Controls.Add(btnSig);
            flpanel.Controls.Add(btnUlt);
            
            }
        }

    }
}
