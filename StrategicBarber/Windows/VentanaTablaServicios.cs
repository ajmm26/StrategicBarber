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
    public partial class VentanaTablaServicios : Form
    {
        private int modo = 0;

        public VentanaTablaServicios(int modo)
        {
            this.modo = modo;
            InitializeComponent();
        }

        private void VentanaTablaServicios_Load(object sender, EventArgs e)
        {
            List<ClassServicio> listServs = new List<ClassServicio>();
            listServs = obtenerListaUsuarios(listServs);
            showUsersList(listServs);
        }


        private List<ClassServicio> obtenerListaUsuarios(List<ClassServicio> listServs)
        {

            DataBaseServicios dbServ = new DataBaseServicios();
            listServs = new List<ClassServicio>();
            listServs = dbServ.GetListServices();
            return listServs;

        }


        private void showUsersList(List<ClassServicio> listUsers)
        {
            dtgvServicios.DataSource = null;
            dtgvServicios.DataSource = listUsers;
            dtgvServicios.CellContentClick += buttonActionClick;
            dtgvServicios.Columns["id"].Visible = false;;

            if (dtgvServicios.Columns["accion"] != null) {

                dtgvServicios.Columns["accion"].Visible = false;

            }

            DataGridViewButtonColumn columnaAccion = new DataGridViewButtonColumn();
            addColumnAction(columnaAccion);
        }

        private void buttonActionClick(object sender, DataGridViewCellEventArgs e)
        {

            switch (modo) {

                case 0:
                    Delete(e);
                    break;

                case 1:
                    Modificar(e);
                    break;

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
                dtgvServicios.Columns.Add(columnaAccion);

            }
            else
            {

                columnaAccion.Name = "accion";
                columnaAccion.HeaderText = "Acción";
                columnaAccion.Text = "Modificar"; // Texto que aparecerá en el botón
                columnaAccion.UseColumnTextForButtonValue = true; // Hace que el texto se muestre en cada celda
           
                // Agrega la columna al final del DataGridView
                dtgvServicios.Columns.Add(columnaAccion);

            }

        }


        private void Modificar(DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && dtgvServicios.Columns[e.ColumnIndex].Name == "accion")
            {

                ClassServicio serv = (ClassServicio)dtgvServicios.Rows[e.RowIndex].DataBoundItem;

                if (serv.id > 0)
                {
                    VentanaServicios ventana = new VentanaServicios(1, serv);
                    DialogResult r = ventana.ShowDialog();
                    if (ventana.actualizacion > 0) {
                        List<ClassServicio> listServs = new List<ClassServicio>();
                        listServs = obtenerListaUsuarios(listServs);
                        showUsersList(listServs);
                    }
                }

            }
        }

       private void Delete(DataGridViewCellEventArgs e) {

            if (e.RowIndex >= 0 && dtgvServicios.Columns[e.ColumnIndex].Name == "accion")
            {

                ClassServicio serv = (ClassServicio)dtgvServicios.Rows[e.RowIndex].DataBoundItem;

                if (serv.id > 0)
                {

                    if (tipoDePermisos()) {
                        DataBaseServicios dbServ = new DataBaseServicios();
                        int res= dbServ.deleteService(serv.id);

                        if (res > 0)
                        {
                            DialogResult rr = MessageBox.Show("Se ha eliminado el servicio", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            if (rr == DialogResult.OK)
                            {
                                List<ClassServicio> listServs = new List<ClassServicio>();
                                listServs = obtenerListaUsuarios(listServs);
                                showUsersList(listServs);
                            }
                        }
                    }
                }

            }

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
