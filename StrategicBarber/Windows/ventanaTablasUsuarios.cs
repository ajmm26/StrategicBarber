using StrategicBarber.Clases;
using StrategicBarber.ClassDataBase;
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

    public partial class ventanaTablasUsuarios : Form
    {
        private int modo = 0;

        public ventanaTablasUsuarios(int num)
        {
            modo = num;
            InitializeComponent();
        }

        private void ventanaTablas_Load(object sender, EventArgs e)
        {
            List<ClassUsuario> listUsers = new List<ClassUsuario>();

           listUsers = obtenerListaUsuarios(listUsers);
            showUsersList(listUsers);
        }

        private  List<ClassUsuario> obtenerListaUsuarios(List<ClassUsuario> listUsers) {

            DataBaseUsuarios dbUsers = new DataBaseUsuarios();
             listUsers = new List<ClassUsuario>();
             listUsers = dbUsers.getAllUsers();
             return listUsers;

        }

        private void showUsersList(List<ClassUsuario> listUsers) {

            dtgvUsuarios.DataSource = null;
            dtgvUsuarios.DataSource = listUsers;
            dtgvUsuarios.CellContentClick += buttonActionClick;
            dtgvUsuarios.Columns["password"].Visible = false;
            dtgvUsuarios.Columns["userid"].Visible = false;
            dtgvUsuarios.Columns["idRol"].Visible = false;
            DataGridViewButtonColumn columnaAccion = new DataGridViewButtonColumn();
            addColumnAction(columnaAccion);
        }

        private void buttonActionClick(object sender, DataGridViewCellEventArgs e)
        {
            bool res = false;
            if (e.RowIndex >= 0 && dtgvUsuarios.Columns[e.ColumnIndex].Name == "accion")
            {
                ClassUsuario usuarioSeleccionado = (ClassUsuario)dtgvUsuarios.Rows[e.RowIndex].DataBoundItem;

                if (usuarioSeleccionado != null)
                {
                    int id = usuarioSeleccionado.userid;
              

                    if (modo == 0 )
                    {
                        eliminarUser(res, id);
                    }
                    else {
                        ModificarUser ventanaModificar = new ModificarUser(id);
                        ventanaModificar.Show();
                    //res = obtenerPermisoAdmin(resultado, ventanaVerificar);

                    }
                    
                }
            }
        }

        private void addColumnAction(DataGridViewButtonColumn columnaAccion) {

            if (modo == 0)
            {
                columnaAccion.Name = "accion";
                columnaAccion.HeaderText = "Acción";
                columnaAccion.Text = "Eliminar"; // Texto que aparecerá en el botón
                columnaAccion.UseColumnTextForButtonValue = true; // Hace que el texto se muestre en cada celda
                
                // Agrega la columna al final del DataGridView
                dtgvUsuarios.Columns.Add(columnaAccion);

            }
            else
            {

                columnaAccion.Name = "accion";
                columnaAccion.HeaderText = "Acción";
                columnaAccion.Text = "Modificar"; // Texto que aparecerá en el botón
                columnaAccion.UseColumnTextForButtonValue = true; // Hace que el texto se muestre en cada celda

                // Agrega la columna al final del DataGridView
                dtgvUsuarios.Columns.Add(columnaAccion);

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


        private void eliminarUser(bool res, int id) {
            if (tipoDePermisos())
            {
                DataBaseUsuarios dbuser = new DataBaseUsuarios();
                int response = dbuser.deleteUser(id);
                if (response > 0) {
                    MessageBox.Show("Se ha eliminado el usuario", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            else {

                MessageBox.Show("Necesitan permisos del administrador", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            }
        }

    }
}
