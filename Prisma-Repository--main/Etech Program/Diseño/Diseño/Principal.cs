using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Diseño
{
    public partial class Principal : Form
    {
        //instancias:
        Utilidades Seguridad = new Utilidades();
        MySqlConnection conn = DataBaseConnect.conectarse();
        MySqlCommand cmd = new MySqlCommand();

        //Constructor
        public Principal()
        {
            InitializeComponent();
        }

        private void MenuOpciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Método activador de el campo de busqueda y el botón de buscar si una opcion de filtro está seleccionada:
            txtCampo_Busqueda.Enabled = true;
            btnBuscar.Enabled = true;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            // Salta error para no crashear el programa:
            if (MenuOpciones.Text.Equals("") || txtCampo_Busqueda.Text == "")
            {
                MessageBox.Show("Antes de buscar seleccione una opción de filtro y escribe algo en el campo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Acá va la operación de búsqueda:
            }
        }

        //Método necesario para cerrar el programa si se cierra el Formulario, sino, solo se cierra y no termina el proceso.
        private void Principal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            //Conexion con la base de datos:
            try
            {
                conn.Open();
                cmd.Connection = conn;
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message + x.StackTrace);
            }
            finally
            {
                conn.Close();
            }
        }
       
        //Codigo referente al menu secundario:
        private void btnMenu_Click(object sender, EventArgs e)
        {
            if (panelD.Size.Width == 45)
            {
                panelD.Width = 119;
                btnAgregar.ForeColor = Color.Black;
                btnModificar.ForeColor = Color.Black;
                btnEliminar.ForeColor = Color.Black;
                btnCerrarSesion.ForeColor = Color.Black;
                btnMenuPrincipal.ForeColor = Color.Black;
                btnAgregar.BackColor = Color.DarkRed;
                btnModificar.BackColor = Color.DarkRed;
                btnEliminar.BackColor = Color.DarkRed;
                btnCerrarSesion.BackColor = Color.DarkRed;
                btnMenuPrincipal.BackColor = Color.DarkRed;

                //tablaCelulares.Location = new Point(124, 78);
                //tablaTrabajo.Location = new Point(124, 373);
            }
            else
            {
                panelD.Width = 45;
                btnAgregar.ForeColor = Color.Firebrick;
                btnModificar.ForeColor = Color.Firebrick;
                btnEliminar.ForeColor = Color.Firebrick;
                btnCerrarSesion.ForeColor = Color.Firebrick;
                btnMenuPrincipal.ForeColor = Color.Firebrick;
                btnAgregar.BackColor = Color.Firebrick;
                btnCerrarSesion.BackColor = Color.Firebrick;
                btnEliminar.BackColor = Color.Firebrick;
                btnModificar.BackColor = Color.Firebrick;
                btnMenuPrincipal.BackColor = Color.Firebrick;

                btnAgregar.FlatStyle = FlatStyle.Flat;
                btnModificar.FlatStyle = FlatStyle.Flat;
                btnEliminar.FlatStyle = FlatStyle.Flat;
                btnCerrarSesion.FlatStyle = FlatStyle.Flat;
                //tablaCelulares.Location = new Point(49, 78);
                //tablaTrabajo.Location = new Point(49, 373);
            }
        }
        //Codigo referente a los botones del menu secundario:
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (Seguridad.getInvitado == false)
            {
                if (panel_Agregar.Height < 591)
                {
                    //Panel-Agregar y GroupBoxes-Agregar:
                    timer_Agregar_Agrandar.Enabled = true;
                    timer_Agregar_Reducir.Enabled = false;
                    panel_Agregar.Enabled = true;
                    panel_Agregar.BringToFront();

                    //Panel-Menu y GroupBoxes-Menu:
                    timer_Menu_Reducir.Enabled = true;
                    timer_Menu_Agrandar.Enabled = false;
                    timer_GroupBox_Menu_Reducir.Enabled = true;
                    timer_GroupBox_Menu_Agrandar.Enabled = false;
                    panel_Menu.Enabled = false;
                    panel_Menu.SendToBack();
                }
                else
                {
                    timer_Agregar_Reducir.Enabled = true;
                    timer_Agregar_Agrandar.Enabled = false;
                    timer_GroupBox_AgregarC_Reducir.Enabled = true;
                    timer_GroupBox_AgregarT_Reducir.Enabled = true;
                    timer_GroupBox_AgregarC_Agrandar.Enabled = false;
                    timer_GroupBox_AgregarT_Agrandar.Enabled = false;
                    panel_Agregar.Enabled = false;
                    panel_Agregar.SendToBack();
                }
            }
            else
            {
                MessageBox.Show("Si quiere realizar cualquer cambio sobre la informacion debe ingresar como un usuario", "Un momento!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (Seguridad.getInvitado == false)
            {
                if (panel_Modificar.Height < 591)
                {
                    //Panel-Modificar y GroupBoxes-Modificar:
                    timer_Modificar_Agrandar.Enabled = true;
                    timer_Modificar_Reducir.Enabled=false;
                    panel_Modificar.Enabled = true;
                    panel_Agregar.BringToFront();

                    //Panel-Agregar y GroupBoxes-Agregar:
                    timer_Agregar_Reducir.Enabled = true;
                    timer_Agregar_Agrandar.Enabled = false;
                    timer_GroupBox_AgregarC_Reducir.Enabled = true;
                    timer_GroupBox_AgregarT_Reducir.Enabled = true;
                    timer_GroupBox_AgregarC_Agrandar.Enabled = false;
                    timer_GroupBox_AgregarT_Agrandar.Enabled = false;
                    panel_Agregar.Enabled = false;
                    panel_Agregar.SendToBack();

                    //Panel-Menu y GroupBoxes-Menu:
                    timer_Menu_Reducir.Enabled = true;
                    timer_Menu_Agrandar.Enabled = false;
                    timer_GroupBox_Menu_Reducir.Enabled = true;
                    timer_GroupBox_Menu_Agrandar.Enabled = false;
                    panel_Menu.Enabled = false;
                    panel_Menu.SendToBack();
                }
                else
                {
                    timer_Modificar_Reducir.Enabled = true;
                    timer_Modificar_Agrandar.Enabled = false;
                    timer_GroupBox_ModificarC_Reducir.Enabled = true;
                    timer_GroupBox_ModificarT_Reducir.Enabled = true;
                    timer_GroupBox_ModificarC_Agrandar.Enabled = false;
                    timer_GroupBox_ModificarT_Agrandar.Enabled = false;
                    panel_Modificar.Enabled = false;
                    panel_Modificar.SendToBack();
                }
            }
            else
            {
                MessageBox.Show("Si quiere realizar cualquer cambio sobre la informacion debe ingresar como un usuario", "Un momento!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Seguridad.getInvitado == false)
            {

            }
            else
            {
                MessageBox.Show("Si quiere realizar cualquer cambio sobre la informacion debe ingresar como un usuario", "Un momento!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnMenu_Principal(object sender, EventArgs e)
        {
            if (panel_Menu.Height < 591)
            {
                //Panel-Menu y GroupBoxes-Menu:
                timer_Menu_Agrandar.Enabled = true;
                timer_Menu_Reducir.Enabled = false;
                timer_GroupBox_Menu_Agrandar.Enabled = true;
                timer_GroupBox_Menu_Reducir.Enabled = false;
                panel_Menu.Enabled = true;
                panel_Menu.BringToFront();

                //Panel-Agregar y GroupBoxes-Agregar:
                timer_Agregar_Reducir.Enabled = true;
                timer_Agregar_Agrandar.Enabled = false;
                timer_GroupBox_AgregarC_Reducir.Enabled = true;
                timer_GroupBox_AgregarT_Reducir.Enabled = true;
                timer_GroupBox_AgregarC_Agrandar.Enabled = false;
                timer_GroupBox_AgregarT_Agrandar.Enabled = false;
                panel_Agregar.Enabled = false;
                panel_Agregar.SendToBack();
            }
            else
            {
                timer_Menu_Reducir.Enabled = true;
                timer_Menu_Agrandar.Enabled = false;
                timer_GroupBox_Menu_Reducir.Enabled = true;
                timer_GroupBox_Menu_Agrandar.Enabled = false;
                panel_Menu.Enabled = false;
                panel_Menu.SendToBack();
            }
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Seguridad.SetInvitado = true;
            conn.Close();
            MessageBox.Show("Cerrando Sesión", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.Restart();
        }

        //Botones con funciones SQL:
        private void btnAgregarCelular_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Trabajo_Click(object sender, EventArgs e)
        {

        }

        private void btnModificar_Celular_Click(object sender, EventArgs e)
        {

        }

        private void btnModificar_Trabajo_Click(object sender, EventArgs e)
        {

        }

        //Timers de los paneles:
        private void timer_Agregar_Reducir_Tick(object sender, EventArgs e)
        {
            if (panel_Agregar.Height > 0)
            {
                panel_Agregar.Height = panel_Agregar.Height - 12;
                panel_Agregar.Enabled = false;
            }
            else
            {
                timer_Agregar_Reducir.Enabled = false;
            }
        }

        private void timer_Agregar_Agrandar_Tick(object sender, EventArgs e)
        {
            if (panel_Agregar.Height < 600)
            {
                panel_Agregar.Height = panel_Agregar.Height + 12;
                panel_Agregar.Enabled = true;
            }
            else
            {
                timer_Agregar_Agrandar.Enabled = false;
            }
        }

        private void timer_Modificar_Reducir_Tick(object sender, EventArgs e)
        {
            if (panel_Modificar.Height > 0)
            {
                panel_Modificar.Height = panel_Modificar.Height - 12;
                panel_Modificar.Enabled = false;
            }
            else
            {
                timer_Modificar_Reducir.Enabled= false;
            }
        }

        private void timer_Modificar_Agrandar_Tick(object sender, EventArgs e)
        {
            if (panel_Modificar.Height < 600)
            {
                panel_Modificar.Height = panel_Modificar.Height + 12;
                panel_Modificar.Enabled = true;
            }
            else
            {
                timer_Modificar_Agrandar.Enabled = false;
            }
        }

        private void timer_Menu_Reducir_Tick(object sender, EventArgs e)
        {
            if (panel_Menu.Height > 0)
            {
                panel_Menu.Height = panel_Menu.Height - 12;
                panel_Menu.Enabled = true;
            }
            else
            {
                timer_Menu_Reducir.Enabled = false;
            }
        }

        private void timer_Menu_Agrandar_Tick(object sender, EventArgs e)
        {
            if (panel_Menu.Height < 600)
            {
                panel_Menu.Height = panel_Menu.Height + 12;
                panel_Menu.Enabled = true;
            }
            else
            {
                timer_Menu_Agrandar.Enabled = false;
            }
        }

        //Timers de los GroupBoxes:
        private void timer_GroupBox_AgregarC_Reducir_Tick(object sender, EventArgs e)
        {
            if (GroupBox_AgregarCelulares.Height > 0)
            {
                GroupBox_AgregarCelulares.Height = GroupBox_AgregarCelulares.Height - 12;
                GroupBox_AgregarCelulares.Enabled = false;
                GroupBox_AgregarCelulares.SendToBack();
            }
            else
            {
                timer_GroupBox_AgregarC_Reducir.Enabled = false;
            }
        }

        private void timer_GroupBox_AgregarC_Agrandar_Tick(object sender, EventArgs e)
        {
            if (GroupBox_AgregarCelulares.Height < 486)
            {
                GroupBox_AgregarCelulares.Height = GroupBox_AgregarCelulares.Height + 12;
                GroupBox_AgregarCelulares.Enabled = true;
                GroupBox_AgregarCelulares.BringToFront();
            }
            else
            {
                timer_GroupBox_AgregarC_Agrandar.Enabled = false;
            }
        }

        private void timer_GroupBox_AgregarT_Reducir_Tick(object sender, EventArgs e)
        {
            if (groupBox_AgregarTrabajo.Height > 0)
            {
                groupBox_AgregarTrabajo.Height = groupBox_AgregarTrabajo.Height - 12;
                groupBox_AgregarTrabajo.Enabled = false;
                groupBox_AgregarTrabajo.SendToBack();
            }
            else
            {
                timer_GroupBox_AgregarT_Reducir.Enabled = false;
            }
        }

        private void timer_GroupBox_AgregarT_Agrandar_Tick(object sender, EventArgs e)
        {
            if (groupBox_AgregarTrabajo.Height < 486)
            {
                groupBox_AgregarTrabajo.Height = groupBox_AgregarTrabajo.Height + 12;
                groupBox_AgregarTrabajo.Enabled = true;
                groupBox_AgregarTrabajo.BringToFront();
            }
            else
            {
                timer_GroupBox_AgregarT_Agrandar.Enabled = false;
            }
        }

        private void timer_GroupBox_Menu_Reducir_Tick(object sender, EventArgs e)
        {
            if (groupBox_Menu.Height > 0)
            {
                groupBox_Menu.Height = groupBox_Menu.Height - 12;
                groupBox_Menu.Enabled = false;
            }
            else
            {
                timer_GroupBox_Menu_Reducir.Enabled = false;
            }
        }

        private void timer_GroupBox_Menu_Agrandar_Tick(object sender, EventArgs e)
        {
            if (groupBox_Menu.Height < 475)
            {
                groupBox_Menu.Height = groupBox_Menu.Height + 12;
                groupBox_Menu.Enabled = true;
            }
            else
            {
                timer_GroupBox_Menu_Agrandar.Enabled = false;
            }
        }

        private void timer_GroupBox_ModificarC_Reducir_Tick(object sender, EventArgs e)
        {
            if (groupBox_ModificarCelular.Height > 0)
            {
                groupBox_ModificarCelular.Height = groupBox_ModificarCelular.Height - 12;
                groupBox_ModificarCelular.Enabled = false;
            }
            else
            {
                timer_GroupBox_ModificarC_Reducir.Enabled = false;
            }
        }

        private void timer_GroupBox_ModificarC_Agrandar_Tick(object sender, EventArgs e)
        {
            if (groupBox_ModificarCelular.Height < 486)
            {
                groupBox_ModificarCelular.Height = groupBox_ModificarCelular.Height + 12;
                groupBox_ModificarCelular.Enabled = true;
            }
            else
            {
                timer_GroupBox_ModificarC_Agrandar.Enabled = false;
            }
        }

        private void timer_GroupBox_ModificarT_Reducir_Tick(object sender, EventArgs e)
        {
            if (groupBox_ModificarTrabajos.Height > 0)
            {
                groupBox_ModificarTrabajos.Height = groupBox_ModificarTrabajos.Height - 12;
                groupBox_ModificarTrabajos.Enabled = false;
            }
            else
            {
                timer_GroupBox_ModificarT_Reducir.Enabled = false;
            }
        }

        private void timer_GroupBox_ModificarT_Agrandar_Tick(object sender, EventArgs e)
        {
            if (groupBox_ModificarTrabajos.Height < 486)
            {
                groupBox_ModificarTrabajos.Height = groupBox_ModificarTrabajos.Height + 12;
                groupBox_ModificarTrabajos.Enabled = true;
            }
            else
            {
                timer_GroupBox_ModificarT_Agrandar.Enabled = false;
            }
        }

        //RadioButtons:
        private void radioButton_CELULARES_Agregar_CheckedChanged(object sender, EventArgs e)
        {
            timer_GroupBox_AgregarC_Agrandar.Enabled = true;
            timer_GroupBox_AgregarC_Reducir.Enabled = false;

            timer_GroupBox_AgregarT_Agrandar.Enabled = false;
            timer_GroupBox_AgregarT_Reducir.Enabled = true;
        }
        private void radioButton_TRABAJO_Agregar_CheckedChanged(object sender, EventArgs e)
        {
            timer_GroupBox_AgregarT_Agrandar.Enabled = true;
            timer_GroupBox_AgregarT_Reducir.Enabled = false;

            timer_GroupBox_AgregarC_Reducir.Enabled = true;
            timer_GroupBox_AgregarC_Agrandar.Enabled = false;
        }
        private void radioButton_CELULARES_Modificar_CheckedChanged(object sender, EventArgs e)
        {
            timer_GroupBox_ModificarC_Agrandar.Enabled= true;
            timer_GroupBox_ModificarC_Reducir.Enabled= false;

            timer_GroupBox_ModificarT_Agrandar.Enabled = false;
            timer_GroupBox_ModificarT_Reducir.Enabled = true;
        }

        private void radioButton_TRABAJO_Modificar_CheckedChanged(object sender, EventArgs e)
        {
            timer_GroupBox_ModificarT_Agrandar.Enabled = true;
            timer_GroupBox_ModificarT_Reducir.Enabled = false;
        
            timer_GroupBox_ModificarC_Agrandar.Enabled = false;
            timer_GroupBox_ModificarC_Reducir.Enabled = true;
        }
    }
}
