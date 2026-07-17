using StrategicBarber.Clases;
using StrategicBarber.DataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace StrategicBarber.Windows
{
    public partial class ventanaTablaEmpleados : Form
    {
        private int modo;
        public ClassEmpleado empSelect = new ClassEmpleado();
        int pageActual = 1;

        int numPaginas = 0;
        int offset = 0;
        public ventanaTablaEmpleados(int modo)
        {
            InitializeComponent();
            this.modo = modo;
        }

        private void ventanaTablaEmpleados_Load(object sender, EventArgs e)
        {
            // Suscribimos el evento una Sola vez aquí al cargar la ventana
            dtgvEmpleados.CellContentClick += buttonActionClick;
            List<ClassEmpleado> listEmpleados = new List<ClassEmpleado>();
            DataBaseEmpleado dbEmp = new DataBaseEmpleado();
            numPaginas = (int)Math.Ceiling(dbEmp.GetNumberEmpleados() / 10.0);
            listEmpleados = obtenerListaUsuarios(listEmpleados);
            showEmpleadosList(listEmpleados);
            crearBotonesPaginas();
        }

        private List<ClassEmpleado> obtenerListaUsuarios(List<ClassEmpleado> listEmpleados)
        {
            DataBaseEmpleado dbEmp = new DataBaseEmpleado();
            listEmpleados = dbEmp.obtenerListaEmpleados(offset);
            return listEmpleados;
        }


        private void showEmpleadosList(List<ClassEmpleado> listUsers)
        {
            // 1. Desvinculamos el DataSource actual
            dtgvEmpleados.DataSource = null;

            // 2. IMPORTANTE: Eliminamos la columna de acción previa si es que existe 
            // para evitar que se duplique al recargar la lista.
            if (dtgvEmpleados.Columns.Contains("accion"))
            {
                dtgvEmpleados.Columns.Remove("accion");
            }

            // 3. Asignamos la nueva lista
            dtgvEmpleados.DataSource = listUsers;

            // Ocultamos el ID
            if (dtgvEmpleados.Columns["id"] != null)
            {
                dtgvEmpleados.Columns["id"].Visible = false;
            }

            if (dtgvEmpleados.Columns["ban"] != null)
            {

                dtgvEmpleados.Columns["ban"].Visible = false;


            }

            // 4. Creamos y agregamos la columna de acción de forma limpia
            DataGridViewButtonColumn columnaAccion = new DataGridViewButtonColumn();
            addColumnAction(columnaAccion);
        }

        private void buttonActionClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dtgvEmpleados.Columns[e.ColumnIndex].Name == "accion")
            {
                if (modo == 0)
                {
                    borrarUsuarioAction(e);
                }

                if (modo == 1)
                {
                    ClassEmpleado empleadoSeleccionado = (ClassEmpleado)dtgvEmpleados.Rows[e.RowIndex].DataBoundItem;
                    agregarEmpleado ventanaModificar = new agregarEmpleado(1, empleadoSeleccionado);
                    DialogResult r = ventanaModificar.ShowDialog();
                    if (r == DialogResult.OK)
                    {
                        List<ClassEmpleado> listEmpleados = new List<ClassEmpleado>();
                        DataBaseEmpleado dbEmp = new DataBaseEmpleado();
                        numPaginas = (int)Math.Ceiling(dbEmp.GetNumberEmpleados() / 10.0);
                        listEmpleados = obtenerListaUsuarios(listEmpleados);
                        showEmpleadosList(listEmpleados);
                        crearBotonesPaginas();
                    }
                }

                if (modo == 2)
                {

                    ClassEmpleado empleadoSeleccionado = (ClassEmpleado)dtgvEmpleados.Rows[e.RowIndex].DataBoundItem;
                    this.DialogResult = DialogResult.OK;
                    empSelect = empleadoSeleccionado;
                    this.Close();

                }
            }

        }

        private void addColumnAction(DataGridViewButtonColumn columnaAccion)
        {

            if (modo == 0)
            {
                columnaAccion.Name = "accion";
                columnaAccion.HeaderText = "Acción";
                columnaAccion.Text = "Eliminar"; // Texto que aparecerá en el botón
                columnaAccion.UseColumnTextForButtonValue = true; // Hace que el texto se muestre en cada celda

                // Agrega la columna al final del DataGridView
                dtgvEmpleados.Columns.Add(columnaAccion);

            }
            if (modo == 1)
            {

                columnaAccion.Name = "accion";
                columnaAccion.HeaderText = "Acción";
                columnaAccion.Text = "Modificar"; // Texto que aparecerá en el botón
                columnaAccion.UseColumnTextForButtonValue = true; // Hace que el texto se muestre en cada celda

                // Agrega la columna al final del DataGridView
                dtgvEmpleados.Columns.Add(columnaAccion);

            }

            if (modo == 2)
            {

                columnaAccion.Name = "accion";
                columnaAccion.HeaderText = "Acción";
                columnaAccion.Text = "Elegir"; // Texto que aparecerá en el botón
                columnaAccion.UseColumnTextForButtonValue = true; // Hace que el texto se muestre en cada celda

                // Agrega la columna al final del DataGridView
                dtgvEmpleados.Columns.Add(columnaAccion);


            }

        }

        private void borrarUsuarioAction(DataGridViewCellEventArgs e)
        {

           

            if (e.RowIndex >= 0 && dtgvEmpleados.Columns[e.ColumnIndex].Name == "accion")
            {

                ClassEmpleado empleadoSeleccionado = (ClassEmpleado)dtgvEmpleados.Rows[e.RowIndex].DataBoundItem;

                if (empleadoSeleccionado != null)
                {
                    int id = empleadoSeleccionado.id;
                    if (tipoDePermisos())
                    {

                        DataBaseEmpleado dbEmp = new DataBaseEmpleado();
                        int res = dbEmp.DeleteEmp(id);
                        if (res > 0)
                        {
                            DialogResult r = MessageBox.Show("Se ha eliminado el usario de forma correcta", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (r == DialogResult.OK)
                            {
                                List<ClassEmpleado> listEmpleados = new List<ClassEmpleado>();
                                numPaginas = (int)Math.Ceiling(dbEmp.GetNumberEmpleados() / 10.0);
                                listEmpleados = obtenerListaUsuarios(listEmpleados);
                                showEmpleadosList(listEmpleados);
                                crearBotonesPaginas();
                            }
                        }
                    }
                }

            }


        }


        private void crearBotonesPaginas()
        {

            flpButtons.Controls.Clear();



            Button btnPrimera = new Button();
            btnPrimera.Text = "<<";
            btnPrimera.Click += flpButtons_Click;

            Button btnAnterior = new Button();
            btnAnterior.Text = "<";
            btnAnterior.Click += flpButtons_Click;

            flpButtons.Controls.Add(btnPrimera);
            flpButtons.Controls.Add(btnAnterior);

            for (int i = 0; i < numPaginas; i++)
            {

                Button page = new Button();
                page.Text = (i + 1).ToString();
                page.Click += flpButtons_Click;
                flpButtons.Controls.Add(page);

            }

            Button btnUlt = new Button();
            btnUlt.Text = ">>";
            btnUlt.Click += flpButtons_Click;

            Button btnSig = new Button();
            btnSig.Text = ">";
            btnSig.Click += flpButtons_Click;

            flpButtons.Controls.Add(btnSig);
            flpButtons.Controls.Add(btnUlt);

        }


        private void flpButtons_Click(object sender, EventArgs e)
        {
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

        private void actualizarPagina()
        {

            DataBaseEmpleado dbEmp = new DataBaseEmpleado();
            calcularPaginas();
            List<ClassEmpleado> list = dbEmp.obtenerListaEmpleados(offset);
            showEmpleadosList(list);
        }


        private void calcularPaginas()
        {
            if (pageActual != 0)
            {
                offset = (10 * (pageActual - 1));
                Debug.WriteLine(offset);
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(textBox1.Text))
            {

                if (textBox1.TextLength > 3)
                {
                    buttonViewAll.Visible = true;
                    buttonViewAll.Enabled = false;
                    List<ClassEmpleado> listEmpleados = new List<ClassEmpleado>();
                    DataBaseEmpleado dbEmp = new DataBaseEmpleado();
                    offset = 0;
                    numPaginas = (int)Math.Ceiling(dbEmp.GetNumberEmpleadosLIKE(textBox1.Text.Trim()) / 10.0);
                    pageActual = 1;
                    listEmpleados = dbEmp.obtenerListaEmpleadosLIKE(offset, textBox1.Text.Trim());
                    showEmpleadosList(listEmpleados);
                    crearBotonesPaginas();

                }

            }
            buttonViewAll.Enabled=true;
        }

        private void buttonViewAll_Click(object sender, EventArgs e)
        {

            buttonViewAll.Visible = false;
            textBox1.Text = string.Empty;
            List<ClassEmpleado> listEmpleados = new List<ClassEmpleado>();
            DataBaseEmpleado dbEmp = new DataBaseEmpleado();
            offset= 0;
            pageActual= 1;
            numPaginas = (int)Math.Ceiling(dbEmp.GetNumberEmpleados() / 10.0);
            listEmpleados = obtenerListaUsuarios(listEmpleados);
            showEmpleadosList(listEmpleados);
            crearBotonesPaginas();


        }

        private bool tipoDePermisos()
        {

            if (Session.idRolSession == 1)
            {

                return true;

            }
            else
            {

                Inicio ventanaAdmin = new Inicio(0);
                ventanaAdmin.ShowDialog();
                if (ventanaAdmin.isAdmin)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }

        }

    }
}

