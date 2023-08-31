using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Diseño
{
    public partial class Principal : Form
    {
        //Atributos o variables:
        string insertarCelulares;
        string insertarTrabajo;

        string modelo;
        string marca;
        string imei;
        string estado;
        string ci_Cliente;
        int id_Usuario;

        //instancias:
        Usuarios Usuarios = new Usuarios();
        DataTable DataTable = new DataTable();
        Utilidades Seguridad = new Utilidades();
        MySqlConnection conn = DataBaseConnect.conectarse();
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataReader reader;

        //Constructor
        public Principal()
        {
            InitializeComponent();
        }

        //Metodos SQL:
        private void MostrarDatosEnLasTablasCelulares()
        {
            try
            {
                conn.Open();
                cmd = new MySqlCommand("SELECT * FROM celulares;", conn);
                cmd.CommandType = System.Data.CommandType.Text;
                reader = cmd.ExecuteReader();
                DataTable.Load(reader);    
            }
            catch (Exception x)
            {
                MessageBox.Show("Fallo la conexion con el servidor o la base de datos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
            tablaCelulares.DataSource = DataTable;
        }

        //Método activador de el campo de busqueda y el botón de buscar si una opcion de filtro está seleccionada:
        private void MenuOpciones_SelectedIndexChanged(object sender, EventArgs e)
        {    
            txtCampo_Busqueda.Enabled = true;
            btnBuscar.Enabled = true;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            // Salta error para no crashear el programa:
            if (MenuOpciones.Text.Equals("") || txtCampo_Busqueda.Text == "")

//          |-----------------------------------------------------------------------------------------------------------------------------------------------------|
//          | Y ahora cuál es el plan? Porque hay 2 menu opciones, celular y trabajo... 2 if, quizás... con un boolean que indique cuál la tabla en al que estás. |
//          |-----------------------------------------------------------------------------------------------------------------------------------------------------|

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
            MostrarDatosEnLasTablasCelulares();
            radioButton_TablaTrabajos.Checked = true;
            radioButton_TRABAJO_Agregar.Checked = true;
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

                tablaCelulares.Location = new Point(124, 78);
                tablaTrabajos.Location = new Point(124, 373);
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
                tablaCelulares.Location = new Point(49, 78);
                tablaTrabajo.Location = new Point(49, 373);
            }
        }
        //Codigo referente a los botones del menu secundario:
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (Seguridad.getInvitado == false)
            {
                if (panel_Agregar.Height < 600)
                {
                    //Panel-Agregar y GroupBoxes-Agregar:
                    timer_Agregar_Agrandar.Enabled = true;
                    timer_Agregar_Reducir.Enabled = false;
                    panel_Agregar.Enabled = true;
                    panel_Agregar.BringToFront();

                    //Panel-Modificar y GroupBoxes-Modificar:
                    timer_Modificar_Reducir.Enabled = true;
                    timer_Modificar_Agrandar.Enabled = false;
                    timer_GroupBox_ModificarC_Reducir.Enabled = true;
                    timer_GroupBox_ModificarT_Reducir.Enabled = true;
                    timer_GroupBox_ModificarC_Agrandar.Enabled = false;
                    timer_GroupBox_ModificarT_Agrandar.Enabled = false;
                    panel_Modificar.Enabled = false;
                    panel_Modificar.SendToBack();

                    //Panel-Eliminar y GroupBoxes-Eliminar:
                    timer_Eliminar_Reducir.Enabled = true;
                    timer_Eliminar_Agrandar.Enabled = false;
                    timer_GroupBox_EliminarC_Reducir.Enabled = true;
                    timer_GroupBox_EliminarT_Reducir.Enabled = true;
                    timer_GroupBox_EliminarC_Agrandar.Enabled = false;
                    timer_GroupBox_EliminarT_Agrandar.Enabled = false;
                    panel_Eliminar.Enabled = false;
                    panel_Eliminar.SendToBack();

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
                if (panel_Modificar.Height < 600)
                {
                    //Panel-Modificar y GroupBoxes-Modificar:
                    timer_Modificar_Agrandar.Enabled = true;
                    timer_Modificar_Reducir.Enabled = false;
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

                    //Panel-Eliminar y GroupBoxes-Eliminar:
                    timer_Eliminar_Reducir.Enabled = true;
                    timer_Eliminar_Agrandar.Enabled = false;
                    timer_GroupBox_EliminarC_Reducir.Enabled = true;
                    timer_GroupBox_EliminarT_Reducir.Enabled = true;
                    timer_GroupBox_EliminarC_Agrandar.Enabled = false;
                    timer_GroupBox_EliminarT_Agrandar.Enabled = false;
                    panel_Eliminar.Enabled = false;
                    panel_Eliminar.SendToBack();

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
                if (panel_Eliminar.Height < 600)
                {
                    //Panel-Eliminar y GroupBoxes-Modificar:
                    timer_Eliminar_Agrandar.Enabled = true;
                    timer_Eliminar_Reducir.Enabled = false;
                    panel_Eliminar.Enabled = true;
                    panel_Eliminar.BringToFront();

                    //Panel-Agregar y GroupBoxes-Agregar:
                    timer_Agregar_Reducir.Enabled = true;
                    timer_Agregar_Agrandar.Enabled = false;
                    timer_GroupBox_AgregarC_Reducir.Enabled = true;
                    timer_GroupBox_AgregarT_Reducir.Enabled = true;
                    timer_GroupBox_AgregarC_Agrandar.Enabled = false;
                    timer_GroupBox_AgregarT_Agrandar.Enabled = false;
                    panel_Agregar.Enabled = false;
                    panel_Agregar.SendToBack();

                    //Panel-Modificar y GroupBoxes-Modificar:
                    timer_Modificar_Reducir.Enabled = true;
                    timer_Modificar_Agrandar.Enabled = false;
                    timer_GroupBox_ModificarC_Reducir.Enabled = true;
                    timer_GroupBox_ModificarT_Reducir.Enabled = true;
                    timer_GroupBox_ModificarC_Agrandar.Enabled = false;
                    timer_GroupBox_ModificarT_Agrandar.Enabled = false;
                    panel_Modificar.Enabled = false;
                    panel_Modificar.SendToBack();

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
                    timer_Eliminar_Reducir.Enabled = true;
                    timer_Eliminar_Agrandar.Enabled = false;
                    timer_GroupBox_EliminarC_Reducir.Enabled = true;
                    timer_GroupBox_EliminarT_Reducir.Enabled = true;
                    timer_GroupBox_EliminarC_Agrandar.Enabled = false;
                    timer_GroupBox_EliminarT_Agrandar.Enabled = false;
                    panel_Eliminar.Enabled = false;
                    panel_Eliminar.SendToBack();
                }
            }
            else
            {
                MessageBox.Show("Si quiere realizar cualquer cambio sobre la informacion debe ingresar como un usuario", "Un momento!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnMenu_Principal(object sender, EventArgs e)
        {
            if (panel_Menu.Height < 600)
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

                //Panel-Modificar y GroupBoxes-Modificar:
                timer_Modificar_Reducir.Enabled = true;
                timer_Modificar_Agrandar.Enabled = false;
                timer_GroupBox_ModificarC_Reducir.Enabled = true;
                timer_GroupBox_ModificarT_Reducir.Enabled = true;
                timer_GroupBox_ModificarC_Agrandar.Enabled = false;
                timer_GroupBox_ModificarT_Agrandar.Enabled = false;
                panel_Modificar.Enabled = false;
                panel_Modificar.SendToBack();

                //Panel-Eliminar y GroupBoxes-Eliminar:
                timer_Eliminar_Reducir.Enabled = true;
                timer_Eliminar_Agrandar.Enabled = false;
                timer_GroupBox_EliminarC_Reducir.Enabled = true;
                timer_GroupBox_EliminarT_Reducir.Enabled = true;
                timer_GroupBox_EliminarC_Agrandar.Enabled = false;
                timer_GroupBox_EliminarT_Agrandar.Enabled = false;
                panel_Eliminar.Enabled = false;
                panel_Eliminar.SendToBack();
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
            try
            {
                if (txtModelo_Agregar.Text != "" || txtMarca_Agregar.Text != "" || txtIMEI_Agregar.Text != "" || txtCI_Del_Dueño_Agregar.Text != "" || txtTecnico_Agregar.Text != "")
                {
                    if (radioButton_Arreglado_Agregar.Checked || radioButton_Averiado_Agregar.Checked)
                    {
                        conn.Open();
                        modelo = txtModelo_Agregar.Text;
                        marca = txtMarca_Agregar.Text;
                        imei = txtIMEI_Agregar.Text;
                        if (radioButton_Arreglado_Agregar.Checked)
                        {
                            estado = "Arreglado";
                        }
                        else
                        {
                            estado = "Averiado";
                        }
                        ci_Cliente = txtCI_Del_Dueño_Agregar.Text;
                        id_Usuario = int.Parse(txtTecnico_Agregar.Text);

                        insertarCelulares = "INSERT INTO celulares(Modelo, Marca, IMEI, Estado, Cedula_Cliente, ID_Usuario) VALUES('" + modelo + "', '" + marca + "', '" + imei + "', '" + estado + "', '" + ci_Cliente + "', " + id_Usuario + ")";
                        cmd = new MySqlCommand(insertarCelulares, conn);

                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("No se ingreso correctamente el celular", "Ups..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        } 
                    }
                }
                else
                {
                    MessageBox.Show("No deje un campo de texto obligatorio en blanco", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            catch
            {

            }
            finally
            {
                conn.Close();
                MostrarDatosEnLasTablasCelulares();
            }
        }

        private void btnModificar_Celular_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Trabajo_Click(object sender, EventArgs e)
        {

        }

        private void btnModificar_Trabajo_Click(object sender, EventArgs e)
        {

        }

        //Botones del Menu:
        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            Usuarios.Show();
            this.Hide();
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
                timer_Modificar_Reducir.Enabled = false;
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
        private void timer_Eliminar_Reducir_Tick(object sender, EventArgs e)
        {
            if (panel_Eliminar.Height > 0)
            {
                panel_Eliminar.Height = panel_Eliminar.Height - 12;
                panel_Eliminar.Enabled = false;
            }
            else
            {
                timer_Eliminar_Reducir.Enabled = false;
            }
        }

        private void timer_Eliminar_Agrandar_Tick(object sender, EventArgs e)
        {
            if (panel_Eliminar.Height < 600)
            {
                panel_Eliminar.Height = panel_Eliminar.Height + 12;
                panel_Eliminar.Enabled = true;
            }
            else
            {
                timer_Eliminar_Agrandar.Enabled = false;
            }
        }

        //Timers de los GroupBoxes:
        private void timer_GroupBox_AgregarC_Reducir_Tick(object sender, EventArgs e)
        {
            if (groupBox_AgregarCelulares.Height > 0)
            {
                groupBox_AgregarCelulares.Height = groupBox_AgregarCelulares.Height - 12;
                groupBox_AgregarCelulares.Enabled = false;
                groupBox_AgregarCelulares.SendToBack();
            }
            else
            {
                timer_GroupBox_AgregarC_Reducir.Enabled = false;
            }
        }

        private void timer_GroupBox_AgregarC_Agrandar_Tick(object sender, EventArgs e)
        {
            if (groupBox_AgregarCelulares.Height < 486)
            {
                groupBox_AgregarCelulares.Height = groupBox_AgregarCelulares.Height + 12;
                groupBox_AgregarCelulares.Enabled = true;
                groupBox_AgregarCelulares.BringToFront();
            }
            else
            {
                timer_GroupBox_AgregarC_Agrandar.Enabled = false;
            }
        }

        private void timer_GroupBox_AgregarT_Reducir_Tick(object sender, EventArgs e)
        {
            if (groupBox_AgregarTrabajos.Height > 0)
            {
                groupBox_AgregarTrabajos.Height = groupBox_AgregarTrabajos.Height - 12;
                groupBox_AgregarTrabajos.Enabled = false;
                groupBox_AgregarTrabajos.SendToBack();
            }
            else
            {
                timer_GroupBox_AgregarT_Reducir.Enabled = false;
            }
        }

        private void timer_GroupBox_AgregarT_Agrandar_Tick(object sender, EventArgs e)
        {
            if (groupBox_AgregarTrabajos.Height < 486)
            {
                groupBox_AgregarTrabajos.Height = groupBox_AgregarTrabajos.Height + 12;
                groupBox_AgregarTrabajos.Enabled = true;
                groupBox_AgregarTrabajos.BringToFront();
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
            if (groupBox_ModificarCelulares.Height > 0)
            {
                groupBox_ModificarCelulares.Height = groupBox_ModificarCelulares.Height - 12;
                groupBox_ModificarCelulares.Enabled = false;
            }
            else
            {
                timer_GroupBox_ModificarC_Reducir.Enabled = false;
            }
        }

        private void timer_GroupBox_ModificarC_Agrandar_Tick(object sender, EventArgs e)
        {
            if (groupBox_ModificarCelulares.Height < 486)
            {
                groupBox_ModificarCelulares.Height = groupBox_ModificarCelulares.Height + 12;
                groupBox_ModificarCelulares.Enabled = true;
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

        private void timer_GroupBox_EliminarC_Reducir_Tick(object sender, EventArgs e)
        {
            if (groupBox_EliminarCelulares.Height > 0)
            {
                groupBox_EliminarCelulares.Height = groupBox_EliminarCelulares.Height - 12;
                groupBox_EliminarCelulares.Enabled = false;
            }
            else
            {
                timer_GroupBox_EliminarC_Reducir.Enabled = false;
            }
        }

        private void timer_GroupBox_EliminarC_Agrandar_Tick(object sender, EventArgs e)
        {
            if (groupBox_EliminarCelulares.Height < 486)
            {
                groupBox_EliminarCelulares.Height = groupBox_EliminarCelulares.Height + 12;
                groupBox_EliminarCelulares.Enabled = true;
            }
            else
            {
                timer_GroupBox_EliminarC_Agrandar.Enabled = false;
            }
        }

        private void timer_GroupBox_EliminarT_Reducir_Tick(object sender, EventArgs e)
        {
            if (groupBox_EliminarTrabajos.Height > 0)
            {
                groupBox_EliminarTrabajos.Height = groupBox_EliminarTrabajos.Height - 12;
                groupBox_EliminarTrabajos.Enabled = false;
            }
            else
            {
                timer_GroupBox_EliminarT_Reducir.Enabled = false;
            }
        }

        private void timer_GroupBox_EliminarT_Agrandar_Tick(object sender, EventArgs e)
        {
            if (groupBox_EliminarTrabajos.Height < 486)
            {
                groupBox_EliminarTrabajos.Height = groupBox_EliminarTrabajos.Height + 12;
            }
            else
            {
                timer_GroupBox_EliminarT_Agrandar.Enabled = false;
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
            timer_GroupBox_ModificarC_Agrandar.Enabled = true;
            timer_GroupBox_ModificarC_Reducir.Enabled = false;

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

        private void radioButton_CELULARES_Eliminar_CheckedChanged(object sender, EventArgs e)
        {
            timer_GroupBox_EliminarC_Agrandar.Enabled = true;
            timer_GroupBox_EliminarC_Reducir.Enabled = false;

            timer_GroupBox_EliminarT_Agrandar.Enabled = false;
            timer_GroupBox_EliminarT_Reducir.Enabled = true;
        }

        private void radioButton_TRABAJO_Eliminar_CheckedChanged(object sender, EventArgs e)
        {
            timer_GroupBox_EliminarT_Agrandar.Enabled = true;
            timer_GroupBox_EliminarT_Reducir.Enabled = false;

            timer_GroupBox_EliminarC_Agrandar.Enabled = false;
            timer_GroupBox_EliminarC_Reducir.Enabled = true;
        }

        private void radioButton_TablaCelulares_CheckedChanged(object sender, EventArgs e)
        {
            if (tablaCelulares.Height < 600)
            {
                tablaCelulares.Height = 600;
            }
            else 
            {
                tablaCelulares.Height = 0;
            }
        }

        private void radioButton_TablaTrabajo_CheckedChanged(object sender, EventArgs e)
        {
            if (tablaTrabajo.Height < 600)
            {
                tablaTrabajo.Height = 600;
            }
            else
            {
                tablaTrabajo.Height = 0;
            }
        }
    }
}
