using StrategicBarber.Clases;
using StrategicBarber.ClassDataBase;
using StrategicBarber.DataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace StrategicBarber.Windows
{
    public partial class DatosPagos : Form
    {
        DataBaseEmpleado dbEmp = new DataBaseEmpleado();
        FacturacionEmpleados fE = new FacturacionEmpleados();
        List<FacturacionEmpleados> list = new List<FacturacionEmpleados>();
        string tiempo;
        string inicio;
        string fin;
        int modo = 0;
        int offset = 0;
        int numPaginas = 0;
        int pageActual = 1;
        double total = 0;
        double comisiones = 0;
        

        public DatosPagos(string tiempo, int modo)
        {
            this.tiempo = tiempo;
            this.modo = modo;
            InitializeComponent();
        }

        private void DatosPagos_Load(object sender, EventArgs e)
        {
           DataBaseConsultasDatosFacturacion dbf = new DataBaseConsultasDatosFacturacion();
                modalidadTiempo();
            if (modo != 2)
            {
                this.total = dbf.GetTotalGeneratedServicios(inicio, fin);
                numPaginas = numPaginas = (int)Math.Ceiling(dbEmp.GetNumberEmpleados() / 10.0);
                calcularPagina();
                obtenerDatos();
                fE.cargarDatagried(list, dataGridView1, ref comisiones);
                mostrarTotalGenerado();
            }
        }

        private void mostrarTotalGenerado() {
            DataBaseConsultasDatosFacturacion dbf = new DataBaseConsultasDatosFacturacion();
            this.total = dbf.GetTotalGeneratedServicios(inicio, fin);
            txtTg.Text = total.ToString("C2");
            txtTp.Text = comisiones.ToString("C2");
            txtGN.Text = (total - comisiones).ToString("C2");
        }

        private void modalidadTiempo() {


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
        
        }


        private bool FechasActuales()
        {
            DateTime hoy = DateTime.Now;
            bool fechas;

            switch (tiempo.ToLower())
            {

                case "diaria":
                    radioButtonAct.Text = "Hoy";
                    radioButtonYest.Text = "Ayer";
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

            return fechas = verificarStringFecha();

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
                    obtenerDatos();
                    break;

                case "semanal":

                    // 1. Encontramos el lunes de la semana ACTUAL
                    int diasParaRestar = (hoy.DayOfWeek == DayOfWeek.Sunday) ? 6 : (int)hoy.DayOfWeek - 1;
                    DateTime lunesActual = hoy.AddDays(-diasParaRestar).Date;
                    DateTime lunesSemanaPasada = lunesActual.AddDays(-7);
                    inicio = lunesSemanaPasada.ToString("yyyy-MM-dd 00:00:00");
                    DateTime domingoSemanaPasada = lunesSemanaPasada.AddDays(6);
                    fin = domingoSemanaPasada.ToString("yyyy-MM-dd 23:59:59");
                    obtenerDatos();
                    break;

                case "mensual":
                    hoy = new DateTime(hoy.Year, hoy.Month, 1).AddMonths(-1);
                    inicio = hoy.ToString("yyyy-MM-dd 00:00:00");
                    fechaObjetivo = hoy.AddMonths(1).AddSeconds(-1);
                    fin = fechaObjetivo.ToString("yyyy-MM-dd 23:59:59");
                    obtenerDatos();
                    break;

                case "semestral":
                    obtenerSemestre(true);
                    obtenerDatos();
                    break;

                case "anual":
                    radioButtonAct.Text = "Año Actual";
                    radioButtonYest.Text = "Año Anterior";
                    DateTime Ahoy = DateTime.Now; // Toma el año en curso (2026)
                    inicio = new DateTime(Ahoy.Year, 1, 1).AddYears(-1).ToString("yyyy-MM-dd 00:00:00");
                    fin = new DateTime(Ahoy.Year, 12, 31).AddYears(-1).ToString("yyyy-MM-dd 23:59:59");
                    obtenerDatos();
                    break;

            }
            return fechas = verificarStringFecha();
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

        private bool verificarStringFecha()
        {

            if (string.IsNullOrEmpty(inicio) || string.IsNullOrEmpty(inicio))
            {
                return false;
            }
            return true;
        }

        private void obtenerDatos()
        {
            DataBaseConsultasDatosFacturacion dbF = new DataBaseConsultasDatosFacturacion();
            list = null;
            calcularPagina();
            list = dbF.GetDataEmpleados(inicio,fin,offset);

        }

        private void calcularPagina() {

            if (pageActual != 0) {

                offset= 10 * (pageActual - 1);

            }
        
        }

        private void radioButtonYest_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioButtonYest.Checked) return;
            modo = 1;
            modalidadTiempo();
            comisiones = 0;
            total = 0;
            numPaginas = numPaginas = (int)Math.Ceiling(dbEmp.GetNumberEmpleados() / 10.0);
            offset = 0;
            pageActual = 1;
            obtenerDatos();
            fE.cargarDatagried(list, dataGridView1, ref comisiones);
            mostrarTotalGenerado();
        }

        private void radioButtonAct_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioButtonAct.Checked) return;
            modo = 0;
            modalidadTiempo();
            comisiones = 0;
            total = 0;
            numPaginas = numPaginas = (int)Math.Ceiling(dbEmp.GetNumberEmpleados() / 10.0);
            offset = 0;
            pageActual = 1;
            obtenerDatos();
            fE.cargarDatagried(list, dataGridView1,ref comisiones);
            mostrarTotalGenerado();
        }

        private void modoFechaEspecifica()
        {
            txtDesde.Text = "Desde";
            txtHasta.Text = "Hasta";
            radioButtonAct.Visible = false;
            radioButtonYest.Visible = false;
            Dtp1.Visible = true;
            Dtp2.Visible = true;
            txtDesde.Visible = true;
            txtHasta.Visible = true;
            buttonSearchDate.Visible = true;
        }


        private void estilosFechaEspecifica()
        {

            Dtp1.MaxDate = DateTime.Now;
            Dtp2.MaxDate = DateTime.Now;
            Dtp1.Format = DateTimePickerFormat.Custom;
            Dtp1.CustomFormat = "dd / MM / yyyy";
            Dtp2.Format = DateTimePickerFormat.Custom;
            Dtp2.CustomFormat = "dd / MM / yyyy";
            Dtp1.CalendarMonthBackground = Color.White;

            // Cambia el color del texto de los días dentro del calendario
            Dtp1.CalendarTitleForeColor = Color.FromArgb(31, 31, 31); // Gris oscuro moderno

            // Cambia el color de fondo de la barra de título del calendario desplegado
            Dtp1.CalendarTitleBackColor = Color.LightGray;

            Dtp2.CalendarMonthBackground = Color.White;

            // Cambia el color del texto de los días dentro del calendario
            Dtp2.CalendarTitleForeColor = Color.FromArgb(31, 31, 31); // Gris oscuro moderno

            // Cambia el color de fondo de la barra de título del calendario desplegado
            Dtp2.CalendarTitleBackColor = Color.LightGray;
        }

        private bool obtenerFechaEspecifica()
        {
            inicio = Dtp1.Value.ToString("yyyy-MM-dd 00:00:00");
            fin = Dtp2.Value.ToString("yyyy-MM-dd 23:59:59");

            if (string.IsNullOrEmpty(inicio) || string.IsNullOrEmpty(fin) || inicio == fin)
            {

                MessageBox.Show("Por favor, seleccione un rango de fechas válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }
            return true;
        }

        private void buttonSearchDate_Click(object sender, EventArgs e)
        {
            bool res = obtenerFechaEspecifica();
            if (res)
            {
                DataBaseConsultasDatosFacturacion dbf = new DataBaseConsultasDatosFacturacion();
                modo = 2;
                this.total = dbf.GetTotalGeneratedServicios(inicio, fin);
                numPaginas = numPaginas = (int)Math.Ceiling(dbEmp.GetNumberEmpleados() / 10.0);
                calcularPagina();
                createButtonsPagination();
                obtenerDatos();
                fE.cargarDatagried(list, dataGridView1, ref comisiones);
                mostrarTotalGenerado();

            }


        }


        private void createButtonsPagination()
        {
            flp1.Controls.Clear();


            if (numPaginas > 1)
            {
                Button btnPrimera = new Button();
                btnPrimera.Text = "<<";
                 btnPrimera.Click += flpButtons_Click;

                Button btnAnterior = new Button();
                btnAnterior.Text = "<";
                 btnAnterior.Click += flpButtons_Click;

                flp1.Controls.Add(btnPrimera);
                flp1.Controls.Add(btnAnterior);
            }


            for (int i = 0; i < numPaginas; i++)
            {

                Button page = new Button();
                page.Text = (i + 1).ToString();
                page.Click += flpButtons_Click;
                flp1.Controls.Add(page);

            }


            if (numPaginas > 1)
            {

                Button btnUlt = new Button();
                btnUlt.Text = ">>";
                btnUlt.Click += flpButtons_Click;

                Button btnSig = new Button();
                btnSig.Text = ">";
                btnSig.Click += flpButtons_Click;

                flp1.Controls.Add(btnSig);
                flp1.Controls.Add(btnUlt);

            }
        }

        private void flpButtons_Click(object sender, EventArgs e) {

            Button b = (Button)sender;

            if (!string.IsNullOrEmpty(b.Text))
            {

                cambioDePagina(b.Text);

            }

        }


        private void cambioDePagina(string x)
        {

            switch (x)
            {

                case ">>":
                    if (pageActual != numPaginas)
                    {
                        pageActual = numPaginas;
                    }
                    break;

                case ">":
                    if (pageActual < numPaginas)
                    {
                        pageActual++;
                    }
                    break;
                case "<<":
                    if (pageActual > 1)
                    {
                        pageActual = 1;
                    }
                    break;
                case "<":
                    if (pageActual > 1)
                    {
                        pageActual--;
                    }
                    break;
                default:
                    pageActual = int.Parse(x);
                    break;

            }

            actualizarPagina();

        }


        private void actualizarPagina() {
            DataBaseConsultasDatosFacturacion dbf = new DataBaseConsultasDatosFacturacion();
            calcularPagina();
            createButtonsPagination();
            obtenerDatos();
            fE.cargarDatagried(list, dataGridView1, ref comisiones);
        }
    }
}
