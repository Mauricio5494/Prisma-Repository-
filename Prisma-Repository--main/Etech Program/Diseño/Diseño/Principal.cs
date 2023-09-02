﻿using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Security.Cryptography;
using System.Windows.Forms;


namespace Diseño
{
    public partial class Principal : Form
    {
        //Atributos o variables:
        string insertarCelulares;
        string insertarTrabajos;
        string modifcarCelulares;
        string modifcarTrabajos;
        string eliminarCelulares;
        string eliminarTrabajos;
        string option;
        string busqueda;

        int mesPlazo;
        int diaPlazo;
        int mesFechaIngreso;
        int diaFechaIngreso;

        //Tabla Celulares:
        int idCelular;
        string modelo;
        string marca;
        string imei;
        string estado;
        string ci_Cliente;
        int id_Usuario;

        //Tabla Trabajos:  
        DateTime plazo;
        string stringPlazo;
        int presupuesto;
        string problema;
        DateTime fechaIngreso;
        string stringFechaIngreso;
        int adelanto;

        //instancias:
        Usuarios Usuarios = new Usuarios();
        DataTable DataTableCelulares = new DataTable();
        DataTable DataTableTrabajos = new DataTable();
        DataTable DataTableCelularesBusqueda = new DataTable();
        DataTable DataTableTrabajosBusqueda = new DataTable();
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
                DataTableCelulares.Rows.Clear(); 
                conn.Open();
                cmd = new MySqlCommand("SELECT * FROM celulares;", conn);
                cmd.CommandType = System.Data.CommandType.Text;
                reader = cmd.ExecuteReader();
                DataTableCelulares.Load(reader);    
            }
            catch (Exception x)
            {
                MessageBox.Show("Fallo la conexion con el servidor o la base de datos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
            tablaCelulares.DataSource = DataTableCelulares;
        }
        private void MostrarDatosEnLasTablasTrabajos()
        {
            try
            {
                DataTableTrabajos.Rows.Clear();
                conn.Open();
                cmd = new MySqlCommand("SELECT * FROM trabajos;", conn);
                cmd.CommandType = System.Data.CommandType.Text;
                reader = cmd.ExecuteReader();
                DataTableTrabajos.Load(reader);
            }
            catch (Exception x)
            {
                MessageBox.Show("Fallo la conexion con el servidor o la base de datos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
            tablaTrabajos.DataSource = DataTableTrabajos;
        }


        //Métodos de los ComboBox:
        private void MenuOpciones_SelectedIndexChanged(object sender, EventArgs e)
        {    
            txtCampo_Busqueda.Enabled = true;
            btnBuscar.Enabled = true;
        }

        private void MenuOpcionesTrabajos_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCampo_Busqueda.Enabled = true;
            btnBuscar.Enabled = true;
        }

        private void comboBoxColumnas_Celulares_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxColumnas_Celulares.Text.Equals("Todas..."))
            {
                //Labels:
                labelError_Modificar_Celulares.Enabled = false;
                labelError_Modificar_Celulares.Visible = false;

                labelID_Dueño_Modificar.Enabled = true;
                labelID_Dueño_Modificar.Visible = true;

                labelIMEI_Modificar.Enabled = true;
                labelIMEI_Modificar.Visible = true;

                labelModelo_Modificar.Enabled = true;
                labelModelo_Modificar.Visible = true;

                labelMarca_Modificar.Enabled = true;
                labelMarca_Modificar.Visible = true;

                labelTecnico_A_Cargo_Modificar.Enabled = true;
                labelTecnico_A_Cargo_Modificar.Visible = true;

                labelEstado_Modificar.Enabled = true;
                labelEstado_Modificar.Visible = true;

                //TextBox y RadioButtons:
                txtCI_Del_Dueño_Modificar.Enabled = true;
                txtCI_Del_Dueño_Modificar.Visible = true;

                txtIMEI_Modificar.Enabled = true;
                txtIMEI_Modificar.Visible = true;

                txtModelo_Modificar.Enabled = true;
                txtModelo_Modificar.Visible = true;

                txtMarca_Modificar.Enabled = true;
                txtMarca_Modificar.Visible = true;

                txtTecnico_Modificar.Enabled = true;
                txtTecnico_Modificar.Visible = true;

                radioButton_Arreglado_Modificar.Enabled = true;
                radioButton_Arreglado_Modificar.Visible = true;

                radioButton_Averiado_Modificar.Enabled = true;
                radioButton_Averiado_Modificar.Visible = true;

                //Modificar Columna:
                labelModificar_Columna.Enabled = false;
                labelModificar_Columna.Visible = false;

                txtModifcar_Columna_Celulares.Enabled = false;
                txtModifcar_Columna_Celulares.Visible = false;
            }
            else
            {
                //Modificar Columna:
                labelModificar_Columna.Enabled = true;
                labelModificar_Columna.Visible = true;

                txtModifcar_Columna_Celulares.Enabled = true;
                txtModifcar_Columna_Celulares.Visible = true;

                //Labels:
                labelError_Modificar_Celulares.Enabled = false;
                labelError_Modificar_Celulares.Visible = false;

                labelID_Dueño_Modificar.Enabled = false;
                labelID_Dueño_Modificar.Visible = false;

                labelIMEI_Modificar.Enabled = false;
                labelIMEI_Modificar.Visible = false;

                labelModelo_Modificar.Enabled = false;
                labelModelo_Modificar.Visible = false;

                labelMarca_Modificar.Enabled = false;
                labelMarca_Modificar.Visible = false;

                labelTecnico_A_Cargo_Modificar.Enabled = false;
                labelTecnico_A_Cargo_Modificar.Visible = false;

                labelEstado_Modificar.Enabled = false;
                labelEstado_Modificar.Visible = false;

                //TextBox y RadioButtons:
                txtCI_Del_Dueño_Modificar.Enabled = false;
                txtCI_Del_Dueño_Modificar.Visible = false;

                txtIMEI_Modificar.Enabled = false;
                txtIMEI_Modificar.Visible = false;

                txtModelo_Modificar.Enabled = false;
                txtModelo_Modificar.Visible = false;

                txtMarca_Modificar.Enabled = false;
                txtMarca_Modificar.Visible = false;

                txtTecnico_Modificar.Enabled = false;
                txtTecnico_Modificar.Visible = false;

                radioButton_Arreglado_Modificar.Enabled = false;
                radioButton_Arreglado_Modificar.Visible = false;

                radioButton_Averiado_Modificar.Enabled = false;
                radioButton_Averiado_Modificar.Visible = false;
            }
        }

        //Boton de busqueda
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (MenuOpcionesCelular.Text.Equals("") && txtCampo_Busqueda.Text.Equals("") || MenuOpcionesTrabajos.Equals("") && txtCampo_Busqueda.Text.Equals(""))
            {
                MessageBox.Show("Antes de buscar seleccione una opción de filtro y escribe algo en el campo", "Alto!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                //busqueda para celulares:
                if (MenuOpcionesCelular.Enabled == true)
                {
                    option = MenuOpcionesCelular.Text;
                    switch (option)
                    {
                        case "Dueño":
                            labelError_MenuOpciones.Visible = false;
                            DataTableCelularesBusqueda.Rows.Clear();
                            try
                            {
                                conn.Open();
                                busqueda = "SELECT * FROM celulares WHERE Cedula_Cliente = (SELECT cedula FROM clientes WHERE Nombre = '" + txtCampo_Busqueda.Text + "')";
                                cmd = new MySqlCommand(busqueda, conn);
                                cmd.CommandType = System.Data.CommandType.Text;
                                reader = cmd.ExecuteReader();
                                DataTableCelularesBusqueda.Load(reader);
                            }
                            catch (Exception x)
                            {
                                MessageBox.Show("Ocurrio un error inesperado durante la busqueda", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            finally
                            {
                                conn.Close();
                            }
                            tablaCelulares.DataSource = DataTableCelularesBusqueda;
                            break;

                        case "Marca":
                            labelError_MenuOpciones.Visible = false;
                            DataTableCelularesBusqueda.Rows.Clear();
                            try
                            {
                                conn.Open();
                                busqueda = "SELECT * FROM celulares WHERE Marca = '" + txtCampo_Busqueda.Text + "'";
                                cmd = new MySqlCommand(busqueda, conn);
                                cmd.CommandType = System.Data.CommandType.Text;
                                reader = cmd.ExecuteReader();
                                DataTableCelularesBusqueda.Load(reader);
                            }
                            catch (Exception x)
                            {
                                MessageBox.Show("Ocurrio un error inesperado durante la busquedas", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            finally
                            {
                                conn.Close();
                            }
                            tablaCelulares.DataSource = DataTableCelularesBusqueda;
                            break;

                        case "Modelo":
                            labelError_MenuOpciones.Visible = false;
                            DataTableCelularesBusqueda.Rows.Clear();
                            try
                            {
                                conn.Open();
                                busqueda = "SELECT * FROM celulares WHERE Modelo = '" + txtCampo_Busqueda.Text + "'";
                                cmd = new MySqlCommand(busqueda, conn);
                                cmd.CommandType = System.Data.CommandType.Text;
                                reader = cmd.ExecuteReader();
                                DataTableCelularesBusqueda.Load(reader);
                            }
                            catch (Exception x)
                            {
                                MessageBox.Show("Ocurrio un error inesperado durante la busqueda", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            finally
                            {
                                conn.Close();
                            }
                            tablaCelulares.DataSource = DataTableCelularesBusqueda;
                            break;

                        case "ID":
                            labelError_MenuOpciones.Visible = false;
                            DataTableCelularesBusqueda.Rows.Clear();
                            try
                            {
                                conn.Open();
                                busqueda = "SELECT * FROM celulares WHERE ID = " + txtCampo_Busqueda.Text + "";
                                cmd = new MySqlCommand(busqueda, conn);
                                cmd.CommandType = System.Data.CommandType.Text;
                                reader = cmd.ExecuteReader();
                                DataTableCelularesBusqueda.Load(reader);
                            }
                            catch (Exception x)
                            {
                                MessageBox.Show("Ocurrio un error inesperado durante la busqueda", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            finally
                            {
                                conn.Close();
                            }
                            tablaCelulares.DataSource = DataTableCelularesBusqueda;
                            break;

                        default:
                            labelError_MenuOpciones.Visible = true;
                            break;
                    }
                }
                else
                {
                    //Busqueda para Trabajos:
                    option = MenuOpcionesTrabajos.Text;
                    switch (option)
                    {
                        case "Presupuesto":
                            labelError_MenuOpciones.Visible = false;
                            DataTableTrabajosBusqueda.Rows.Clear();
                            try
                            {
                                conn.Open();
                                busqueda = "SELECT * FROM trabajos WHERE Presupuesto = " + txtCampo_Busqueda.Text + ";";
                                cmd = new MySqlCommand(busqueda, conn);
                                cmd.CommandType = System.Data.CommandType.Text;
                                reader = cmd.ExecuteReader();
                                DataTableTrabajosBusqueda.Load(reader);
                            }
                            catch (Exception x)
                            {
                                MessageBox.Show("Ocurrio un error inesperado durante la busquedas", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            finally
                            {
                                conn.Close();
                            }
                            tablaTrabajos.DataSource = DataTableTrabajosBusqueda;
                            break;
                      
                        case "Problema":
                            labelError_MenuOpciones.Visible = false;
                            labelError_MenuOpciones.Visible = false;
                            DataTableTrabajosBusqueda.Rows.Clear();
                            try
                            {
                                conn.Open();
                                busqueda = "SELECT * FROM trabajos WHERE Problema = '" + txtCampo_Busqueda.Text + "';";
                                cmd = new MySqlCommand(busqueda, conn);
                                cmd.CommandType = System.Data.CommandType.Text;
                                reader = cmd.ExecuteReader();
                                DataTableTrabajosBusqueda.Load(reader);
                            }
                            catch (Exception x)
                            {
                                MessageBox.Show("Ocurrio un error inesperado durante la busquedas", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            finally
                            {
                                conn.Close();
                            }
                            tablaTrabajos.DataSource = DataTableTrabajosBusqueda;
                            break;
                 
                        case "Fecha de ingreso":
                            labelError_MenuOpciones.Visible = false;
                            labelError_MenuOpciones.Visible = false;
                            DataTableTrabajosBusqueda.Rows.Clear();
                            try
                            {
                                conn.Open();
                                busqueda = "SELECT * FROM trabajos WHERE Fecha_Ingreso = '" + txtCampo_Busqueda.Text + "';";
                                cmd = new MySqlCommand(busqueda, conn);
                                cmd.CommandType = System.Data.CommandType.Text;
                                reader = cmd.ExecuteReader();
                                DataTableTrabajosBusqueda.Load(reader);
                            }
                            catch (Exception x)
                            {
                                MessageBox.Show("Ocurrio un error inesperado durante la busquedas", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            finally
                            {
                                conn.Close();
                            }
                            tablaTrabajos.DataSource = DataTableTrabajosBusqueda;
                            break;
               
                        case "ID del celular":
                            labelError_MenuOpciones.Visible = false;
                            labelError_MenuOpciones.Visible = false;
                            DataTableTrabajosBusqueda.Rows.Clear();
                            try
                            {
                                conn.Open();
                                busqueda = "SELECT * FROM trabajos WHERE ID_Celular = " + txtCampo_Busqueda.Text + ";";
                                cmd = new MySqlCommand(busqueda, conn);
                                cmd.CommandType = System.Data.CommandType.Text;
                                reader = cmd.ExecuteReader();
                                DataTableTrabajosBusqueda.Load(reader);
                            }
                            catch (Exception x)
                            {
                                MessageBox.Show("Ocurrio un error inesperado durante la busquedas", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            finally
                            {
                                conn.Close();
                            }
                            tablaTrabajos.DataSource = DataTableTrabajosBusqueda;
                            break;
                        
                        default:
                            labelError_MenuOpciones.Visible = true;
                            break;
                    }
                }
            }
        }

        private void Principal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            
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
                tablaTrabajos.Location = new Point(49, 373);
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
                if (txtModelo_Agregar.Text != "" && txtMarca_Agregar.Text != "" && txtIMEI_Agregar.Text != "" && txtCI_Del_Dueño_Agregar.Text != "" && txtTecnico_Agregar.Text != "")
                {
                    if (radioButton_Arreglado_Agregar.Checked.Equals(true) || radioButton_Averiado_Agregar.Checked.Equals(true))
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
                        catch
                        {
                            MessageBox.Show("No se ingreso correctamente el celular", "Ups..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        } 
                    }
                    else
                    {
                        MessageBox.Show("No deje un campo de texto obligatorio en blanco", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                else
                {
                    MessageBox.Show("No deje un campo de texto obligatorio en blanco", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            catch
            {
                MessageBox.Show("Fallo la conexion con el servidor o la base de datos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
                MostrarDatosEnLasTablasCelulares();
            }
        }

        private void btnModificar_Celular_Click(object sender, EventArgs e)
        {
            if (comboBoxColumnas_Celulares.Text.Equals("Todas..."))
            {
                //Label error:
                labelError_Modificar_Celulares.Enabled = false;
                labelError_Modificar_Celulares.Visible = false;

                //Codigo para modificar el Celular:
                if (txtModelo_Modificar.Text != "" && txtMarca_Modificar.Text != "" && txtIMEI_Modificar.Text != "" && txtCI_Del_Dueño_Modificar.Text != "" && txtID_Tabla_Celular_Modificar.Text != "" && txtTecnico_Modificar.Text != "") 
                {
                    if (radioButton_Arreglado_Modificar.Checked == true || radioButton_Averiado_Modificar.Checked == true)
                    {
                        try
                        {
                            conn.Open();
                            idCelular = int.Parse(txtID_Tabla_Celular_Modificar.Text);
                            modelo = txtModelo_Modificar.Text;
                            marca = txtMarca_Modificar.Text;
                            imei = txtIMEI_Modificar.Text;
                            if (radioButton_Arreglado_Modificar.Checked)
                            {
                                estado = "Arreglado";
                            }
                            else
                            {
                                estado = "Averiado";
                            }
                            ci_Cliente = txtCI_Del_Dueño_Modificar.Text;
                            id_Usuario = int.Parse(txtTecnico_Modificar.Text);

                            modifcarCelulares = "UPDATE celulares SET Modelo = '" + modelo + "', Marca = '" + marca + "', IMEI = '" + imei + "', Estado = '" + estado + "', Cedula_Cliente = '" + ci_Cliente + "', ID_Usuario = " + id_Usuario + " WHERE celulares.ID = " + idCelular + ";";
                            cmd = new MySqlCommand(modifcarCelulares, conn);

                            try
                            {
                                cmd.ExecuteNonQuery();
                            }
                            catch
                            {
                                MessageBox.Show("No se modifico correctamente el celular", "Ups..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch 
                        {
                            MessageBox.Show("Fallo la conexion con el servidor o la base de datos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            conn.Close();
                            MostrarDatosEnLasTablasCelulares();
                        }
                    }
                    else
                    {
                        MessageBox.Show("No deje un campo de texto obligatorio en blanco", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                else
                {
                    MessageBox.Show("No deje un campo de texto obligatorio en blanco", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            else if (comboBoxColumnas_Celulares.Text.Equals("Modelo") || comboBoxColumnas_Celulares.Text.Equals("Marca") || comboBoxColumnas_Celulares.Text.Equals("IMEI") || comboBoxColumnas_Celulares.Text.Equals("Estado") || comboBoxColumnas_Celulares.Text.Equals("Cedula del dueño") || comboBoxColumnas_Celulares.Text.Equals("ID del usuario/ tecnico"))
            {
                //Label error:
                labelError_Modificar_Celulares.Enabled = false;
                labelError_Modificar_Celulares.Visible = false;

                //Codigo para modificar el celular:
            }
            else
            {
                labelError_Modificar_Celulares.Enabled = true;
                labelError_Modificar_Celulares.Visible = true;

                //Labels:
                labelID_Dueño_Modificar.Enabled = false;
                labelID_Dueño_Modificar.Visible = false;

                labelIMEI_Modificar.Enabled = false;
                labelIMEI_Modificar.Visible = false;

                labelModelo_Modificar.Enabled = false;
                labelModelo_Modificar.Visible = false;

                labelMarca_Modificar.Enabled = false;
                labelMarca_Modificar.Visible = false;

                labelTecnico_A_Cargo_Modificar.Enabled = false;
                labelTecnico_A_Cargo_Modificar.Visible = false;

                labelEstado_Modificar.Enabled = false;
                labelEstado_Modificar.Visible = false;

                labelModificar_Columna.Enabled = false;
                labelModificar_Columna.Visible = false;

                //TextBox y RadioButtons:
                txtCI_Del_Dueño_Modificar.Enabled = false;
                txtCI_Del_Dueño_Modificar.Visible = false;

                txtIMEI_Modificar.Enabled = false;
                txtIMEI_Modificar.Visible = false;

                txtModelo_Modificar.Enabled = false;
                txtModelo_Modificar.Visible = false;

                txtMarca_Modificar.Enabled = false;
                txtMarca_Modificar.Visible = false;

                txtTecnico_Modificar.Enabled = false;
                txtTecnico_Modificar.Visible = false;

                radioButton_Arreglado_Modificar.Enabled = false;
                radioButton_Arreglado_Modificar.Visible = false;

                radioButton_Averiado_Modificar.Enabled = false;
                radioButton_Averiado_Modificar.Visible = false;

                txtModifcar_Columna_Celulares.Enabled = false;
                txtModifcar_Columna_Celulares.Visible = false;
            }
        }

        private void btnAgregar_Trabajo_Click(object sender, EventArgs e)
        {
            if (txtPresupuesto_Agregar.Text != "" && txtProblema_Agregar.Text != "" && dateTimePicker_fechaIngreso.Value != null && txtID_Trabajo_Agregar.Text != "")
            {
                try
                {
                    conn.Open();
                    idCelular = int.Parse(txtID_Trabajo_Agregar.Text);
                    plazo = dateTimePicker_Plazo.Value;
                    mesPlazo = plazo.Month;
                    diaPlazo = plazo.Day;
                    if (mesPlazo < 10)
                    {
                        if (diaPlazo < 10) 
                        {
                            stringPlazo = plazo.Year.ToString() + "-0" + plazo.Month.ToString() + "-0" + plazo.Day.ToString();
                        }
                        else
                        {
                            stringPlazo = plazo.Year.ToString() + "-0" + plazo.Month.ToString() + "-" + plazo.Day.ToString();
                        }
                    }
                    else
                    {
                        if (diaPlazo <10)
                        {
                            stringPlazo = plazo.Year.ToString() + "-" + plazo.Month.ToString() + "-0" + plazo.Day.ToString();
                        }
                        else
                        {
                            stringPlazo = plazo.Year.ToString() + "-" + plazo.Month.ToString() + "-" + plazo.Day.ToString();
                        }      
                    }
                    presupuesto = int.Parse(txtPresupuesto_Agregar.Text);
                    problema = txtProblema_Agregar.Text;
                    fechaIngreso = dateTimePicker_fechaIngreso.Value;
                    mesFechaIngreso = fechaIngreso.Month;
                    diaFechaIngreso = fechaIngreso.Day;
                    if (mesFechaIngreso < 10)
                    {
                        if (diaFechaIngreso < 10)
                        {
                            stringFechaIngreso = fechaIngreso.Year.ToString() + "-0" + fechaIngreso.Month.ToString() + "-0" + fechaIngreso.Day.ToString();
                        }
                        else
                        {
                            stringFechaIngreso = fechaIngreso.Year.ToString() + "-0" + fechaIngreso.Month.ToString() + "-" + fechaIngreso.Day.ToString();
                        }
                    }
                    else
                    {
                        if (diaFechaIngreso < 10)
                        {
                            stringFechaIngreso = fechaIngreso.Year.ToString() + "-" + fechaIngreso.Month.ToString() + "-0" + fechaIngreso.Day.ToString();
                        }
                        else
                        {
                            stringFechaIngreso = fechaIngreso.Year.ToString() + "-" + fechaIngreso.Month.ToString() + "-" + fechaIngreso.Day.ToString();
                        }
                    }
                    adelanto = int.Parse(txtAdelanto_Agregar.Text);

                    insertarTrabajos = "INSERT INTO Trabajos(Plazo, Presupuesto, Problema, Fecha_Ingreso, Adelanto, ID_Celular) VALUES('" + stringPlazo + "', " + presupuesto + ", '" + problema + "', '" + stringFechaIngreso + "', " + adelanto + ", " + idCelular + ")";
                    cmd = new MySqlCommand(insertarTrabajos, conn);
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch
                    {
                        MessageBox.Show("No se ingreso correctamente el Trabajo", "Ups..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch 
                {
                    MessageBox.Show("Fallo la conexion con el servidor o la base de datos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    conn.Close();
                    MostrarDatosEnLasTablasTrabajos();
                }
            }
            else
            {
                MessageBox.Show("No deje un campo de texto obligatorio en blanco", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnModificar_Trabajo_Click(object sender, EventArgs e)
        {

        }

        private void btnRecargar_Click(object sender, EventArgs e)
        {
            if (radioButton_TablaCelulares.Checked == true)
            {
                MostrarDatosEnLasTablasCelulares();
            }
            else if (radioButton_TablaTrabajos.Checked == true)
            {
                MostrarDatosEnLasTablasTrabajos();
            }
        }

        //Botones del Menu principal:
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
            btnRecargar.Enabled = true;
            btnRecargar.Visible = true;

            MenuOpcionesCelular.Enabled = true;
            MenuOpcionesCelular.Visible = true;
            MenuOpcionesTrabajos.Enabled = false;
            MenuOpcionesTrabajos.Visible = false;



            if (tablaCelulares.Height < 600)
            {
                tablaTrabajos.Height = 0;
                tablaCelulares.Height = 600;
                MostrarDatosEnLasTablasCelulares();
            }
            else 
            {
                MostrarDatosEnLasTablasCelulares();
            }
        }

        private void radioButton_TablaTrabajo_CheckedChanged(object sender, EventArgs e)
        {
            btnRecargar.Enabled = true;
            btnRecargar.Visible = true;

            MenuOpcionesTrabajos.Enabled = true;
            MenuOpcionesTrabajos.Visible = true;
            MenuOpcionesCelular.Enabled = false;
            MenuOpcionesCelular.Visible = false;

            if (tablaTrabajos.Height < 600)
            {
                tablaCelulares.Height = 0;
                tablaTrabajos.Height = 600;
                MostrarDatosEnLasTablasTrabajos();
            }
            else
            {
                MostrarDatosEnLasTablasTrabajos();
            }
        }
    }
}