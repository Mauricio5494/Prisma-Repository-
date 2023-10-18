using Microsoft.ReportingServices.Diagnostics.Internal;
using MySql.Data.MySqlClient;
using MySql.Utility.Classes;
using MySql.Utility.Forms;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Reflection;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Xml;

namespace Diseño
{
    public partial class Principal : Form
    {
        //Atributos o variables:
        int numeroDeFilaCelulares;
        int numeroDeFilaTrabajos;
        int activo = 1;
        int inactivo = 0;
        string clavePrimariaCelulares;
        string clavePrimariaTrabajos;
        string insertarCelulares;
        string insertarTrabajos;
        string modifcarCelulares;
        string modifcarTrabajos;
        string eliminarCelulares;
        string eliminarTrabajos;
        string option;
        string busqueda;
        int caracteresMaximos = 8;


        //De tabla
        int lonigtudDeColumna_Corta = 50;
        int lonigtudDeColumna_Media = 80;
        int lonigtudDeColumna_Larga = 120;
        int lonigtudDeColumna_LargaM = 160;
        int longitudDeColumna_LargaL = 180;
        int longitudDeColumna_LargaXL = 200;
        int longitudDeColumna_XLXL = 250;

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
        string ciCliente;
        int idUsuario;

        //Tabla Trabajos:  
        int idTrabajo;
        DateTime plazo;
        string stringPlazo;
        int presupuesto;
        string problema;
        DateTime fechaIngreso;
        string stringFechaIngreso;
        int adelanto;
        int tecnicoACargo;

        //instancias:
        private Usuarios Usuarios; /* <-- aunque no son instancias objetualizadas, sirven solo para sacar valores públicos de dentro como getters, setters, etc. */
        private Clientes clientes;
        DataTable DataTableCelulares = new DataTable();
        DataTable DataTableTrabajos = new DataTable();
        DataTable DataTableCelularesBusqueda = new DataTable();
        DataTable DataTableTrabajosBusqueda = new DataTable();
        Utilidades Seguridad = new Utilidades();
        MySqlConnection conn = DataBaseConnect.Conectarse();
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataReader reader;

        //Constructor
        public Principal()
        {
            InitializeComponent();
        }
        /*
         * 
         * 
         */
        //Metodos SQL:
        private void MostrarDatosEnLasTablasCelulares()
        {
            try
            {
                DataTableCelulares.Rows.Clear();
                conn.Open();
                cmd = new MySqlCommand("SELECT celulares.ID, celulares.Marca, celulares.Modelo, celulares.IMEI, celulares.Estado, celulares.Cedula_Cliente, usuarios.Nombre " +
                                     "FROM celulares " +
                                     "INNER JOIN usuarios ON celulares.ID_Usuario = usuarios.ID " +
                                     "WHERE celulares.Baja = 0 AND usuarios.Baja = 0;", conn);
                cmd.CommandType = CommandType.Text;
                reader = cmd.ExecuteReader();
                DataTableCelulares.Load(reader);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fallo la conexion con el servidor o la base de datos\n\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
            tablaCelulares.DataSource = DataTableCelulares;
        }

        private void MostrarDatosEnLasTablasCelulares_SinMensajeDeError()
        {
            try
            {
                DataTableCelulares.Clear();
                conn.Open();
                cmd = new MySqlCommand("SELECT celulares.ID, celulares.Marca, celulares.Modelo, celulares.IMEI, celulares.Estado, celulares.Cedula_Cliente, usuarios.Nombre " +
                                     "FROM celulares " +
                                     "INNER JOIN usuarios ON celulares.ID_Usuario = usuarios.ID " +
                                     "WHERE celulares.Baja = 0 AND usuarios.Baja = 0;", conn);
                cmd.CommandType = CommandType.Text;
                reader = cmd.ExecuteReader();
                DataTableCelulares.Load(reader);
            }
            catch (Exception ex)
            {
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

                DataTableTrabajos.Clear();
                conn.Open();
                cmd = new MySqlCommand("SELECT ID, ID_Tecnico, Presupuesto, Problema, Fecha_Ingreso, Plazo, Adelanto, ID_Celular FROM trabajos WHERE Baja = 0;", conn);
                cmd.CommandType = System.Data.CommandType.Text;
                reader = cmd.ExecuteReader();
                DataTableTrabajos.Load(reader);

            }
            catch (Exception x)
            {
                MessageBox.Show("Fallo la conexion con el servidor o la base de datos\n\n" + x.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
            tablaTrabajos.DataSource = DataTableTrabajos;
        }

        private void MostrarDatosEnLasTablasTrabajos_SinMensajeDeError()
        {
            try
            {
                DataTableTrabajos.Rows.Clear();
                conn.Open();
                cmd = new MySqlCommand("SELECT ID, ID_Tecnico, Plazo, Presupuesto, Problema, Fecha_Ingreso, Adelanto, ID_Celular FROM trabajos WHERE Baja = 0;", conn);
                cmd.CommandType = System.Data.CommandType.Text;
                reader = cmd.ExecuteReader();
                DataTableTrabajos.Load(reader);
            }
            catch (Exception x)
            {
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

        }

        private void MenuOpcionesTrabajos_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCampo_Busqueda.Enabled = true;

        }

        private void comboBoxColumnas_Trabajos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxColumnas_Trabajos.Text.Equals("Todas..."))
            {
                //Labels:
                labelError_Modificar_Trabajos.Enabled = false;
                labelError_Modificar_Trabajos.Visible = false;

                labelTrabajo_ID_Modificar.Enabled = true;
                labelTrabajo_ID_Modificar.Visible = true;

                labelPlazo_Modificar.Enabled = true;
                labelPlazo_Modificar.Visible = true;

                labelPresupuesto_Modificar.Enabled = true;
                labelPresupuesto_Modificar.Visible = true;

                labelProblema_Modificar.Enabled = true;
                labelProblema_Modificar.Visible = true;

                labelFechaDeIngreso_Modificar.Enabled = true;
                labelFechaDeIngreso_Modificar.Visible = true;

                labelAdelanto_Modificar.Enabled = true;
                labelAdelanto_Modificar.Visible = true;

                labelID_Tecnico_Trabajo_Modificar.Enabled = true;
                labelID_Tecnico_Trabajo_Modificar.Visible = true;

                //TextBox y DateTimePicker:
                txtTrabajo_ID_Modificar.Enabled = true;
                txtTrabajo_ID_Modificar.Visible = true;

                dateTimePicker_Plazo_Modificar.Enabled = true;
                dateTimePicker_Plazo_Modificar.Visible = true;

                dateTimePicker_Plazo_Modificar.Location = new Point(6, 133);

                txtPresupuesto_Modificar.Enabled = true;
                txtPresupuesto_Modificar.Visible = true;

                txtProblema_Modificar.Enabled = true;
                txtProblema_Modificar.Visible = true;

                dateTimePicker_FechaDeIngreso_Modificar.Enabled = true;
                dateTimePicker_FechaDeIngreso_Modificar.Visible = true;

                dateTimePicker_FechaDeIngreso_Modificar.Location = new Point(6, 284);

                txtAdelanto_Modificar.Enabled = true;
                txtAdelanto_Modificar.Visible = true;

                combobox_IDTecnico_Modificar_Trabajo.Enabled = true;
                combobox_IDTecnico_Modificar_Trabajo.Visible = true;

                //Modificar Columna:
                labelModificar_Columna_Trabajos.Enabled = false;
                labelModificar_Columna_Trabajos.Visible = false;

                txtModificar_Columna_Trabajos.Enabled = false;
                txtModificar_Columna_Trabajos.Visible = false;
            }
            else if (comboBoxColumnas_Trabajos.Text.Equals("Plazo"))
            {
                dateTimePicker_Plazo_Modificar.Enabled = true;
                dateTimePicker_Plazo_Modificar.Visible = true;

                dateTimePicker_Plazo_Modificar.Location = new Point(6, 95);

                labelModificar_Columna_Trabajos.Enabled = true;
                labelModificar_Columna_Trabajos.Visible = true;

                labelID_Tecnico_Trabajo_Modificar.Enabled = false;
                labelID_Tecnico_Trabajo_Modificar.Visible = false;

                //Labels:
                labelError_Modificar_Trabajos.Enabled = false;
                labelError_Modificar_Trabajos.Visible = false;

                labelTrabajo_ID_Modificar.Enabled = false;
                labelTrabajo_ID_Modificar.Visible = false;

                labelPlazo_Modificar.Enabled = false;
                labelPlazo_Modificar.Visible = false;

                labelPlazo_Modificar.Location = new Point(3, 79);

                labelPresupuesto_Modificar.Enabled = false;
                labelPresupuesto_Modificar.Visible = false;

                labelProblema_Modificar.Enabled = false;
                labelProblema_Modificar.Visible = false;

                labelFechaDeIngreso_Modificar.Enabled = false;
                labelFechaDeIngreso_Modificar.Visible = false;

                labelAdelanto_Modificar.Enabled = false;
                labelAdelanto_Modificar.Visible = false;

                //TextBox y DateTimePicker:
                txtTrabajo_ID_Modificar.Enabled = false;
                txtTrabajo_ID_Modificar.Visible = false;

                txtPresupuesto_Modificar.Enabled = false;
                txtPresupuesto_Modificar.Visible = false;

                txtProblema_Modificar.Enabled = false;
                txtProblema_Modificar.Visible = false;

                dateTimePicker_FechaDeIngreso_Modificar.Enabled = false;
                dateTimePicker_FechaDeIngreso_Modificar.Visible = false;

                txtAdelanto_Modificar.Enabled = false;
                txtAdelanto_Modificar.Visible = false;

                txtModificar_Columna_Trabajos.Enabled = false;
                txtModificar_Columna_Trabajos.Visible = false;

                combobox_IDTecnico_Modificar_Trabajo.Enabled = false;
                combobox_IDTecnico_Modificar_Trabajo.Visible = false;
            }
            else if (comboBoxColumnas_Trabajos.Text.Equals("Fecha de ingreso"))
            {
                dateTimePicker_FechaDeIngreso_Modificar.Enabled = true;
                dateTimePicker_FechaDeIngreso_Modificar.Visible = true;
                dateTimePicker_FechaDeIngreso_Modificar.Location = new Point(6, 95);

                labelModificar_Columna_Trabajos.Enabled = true;
                labelModificar_Columna_Trabajos.Visible = true;
                labelModificar_Columna_Trabajos.Location = new Point(3, 79);

                //Labels:
                labelError_Modificar_Trabajos.Enabled = false;
                labelError_Modificar_Trabajos.Visible = false;

                labelTrabajo_ID_Modificar.Enabled = false;
                labelTrabajo_ID_Modificar.Visible = false;

                labelPlazo_Modificar.Enabled = false;
                labelPlazo_Modificar.Visible = false;

                labelPresupuesto_Modificar.Enabled = false;
                labelPresupuesto_Modificar.Visible = false;

                labelProblema_Modificar.Enabled = false;
                labelProblema_Modificar.Visible = false;

                labelFechaDeIngreso_Modificar.Enabled = false;
                labelFechaDeIngreso_Modificar.Visible = false;

                labelAdelanto_Modificar.Enabled = false;
                labelAdelanto_Modificar.Visible = false;

                labelID_Tecnico_Trabajo_Modificar.Enabled = false;
                labelID_Tecnico_Trabajo_Modificar.Visible = false;

                //TextBox y DateTimePicker:
                txtTrabajo_ID_Modificar.Enabled = false;
                txtTrabajo_ID_Modificar.Visible = false;

                dateTimePicker_Plazo_Modificar.Enabled = false;
                dateTimePicker_Plazo_Modificar.Visible = false;

                txtPresupuesto_Modificar.Enabled = false;
                txtPresupuesto_Modificar.Visible = false;

                txtProblema_Modificar.Enabled = false;
                txtProblema_Modificar.Visible = false;

                txtAdelanto_Modificar.Enabled = false;
                txtAdelanto_Modificar.Visible = false;

                txtModificar_Columna_Trabajos.Enabled = false;
                txtModificar_Columna_Trabajos.Visible = false;

                combobox_IDTecnico_Modificar_Trabajo.Enabled = false;
                combobox_IDTecnico_Modificar_Trabajo.Visible = false;
            }
            else
            {
                //Modificar Columna:
                labelModificar_Columna_Trabajos.Enabled = true;
                labelModificar_Columna_Trabajos.Visible = true;

                txtModificar_Columna_Trabajos.Enabled = true;
                txtModificar_Columna_Trabajos.Visible = true;

                //Labels:
                labelError_Modificar_Trabajos.Enabled = false;
                labelError_Modificar_Trabajos.Visible = false;

                labelTrabajo_ID_Modificar.Enabled = false;
                labelTrabajo_ID_Modificar.Visible = false;

                labelPlazo_Modificar.Enabled = false;
                labelPlazo_Modificar.Visible = false;

                labelPresupuesto_Modificar.Enabled = false;
                labelPresupuesto_Modificar.Visible = false;

                labelProblema_Modificar.Enabled = false;
                labelProblema_Modificar.Visible = false;

                labelFechaDeIngreso_Modificar.Enabled = false;
                labelFechaDeIngreso_Modificar.Visible = false;

                labelAdelanto_Modificar.Enabled = false;
                labelAdelanto_Modificar.Visible = false;

                labelID_Tecnico_Trabajo_Modificar.Enabled = false;
                labelID_Tecnico_Trabajo_Modificar.Visible = false;

                //TextBox y DateTimePicker:
                txtTrabajo_ID_Modificar.Enabled = false;
                txtTrabajo_ID_Modificar.Visible = false;

                dateTimePicker_Plazo_Modificar.Enabled = false;
                dateTimePicker_Plazo_Modificar.Visible = false;

                txtPresupuesto_Modificar.Enabled = false;
                txtPresupuesto_Modificar.Visible = false;

                txtProblema_Modificar.Enabled = false;
                txtProblema_Modificar.Visible = false;

                dateTimePicker_FechaDeIngreso_Modificar.Enabled = false;
                dateTimePicker_FechaDeIngreso_Modificar.Visible = false;

                txtAdelanto_Modificar.Enabled = false;
                txtAdelanto_Modificar.Visible = false;

                combobox_IDTecnico_Modificar_Trabajo.Enabled = false;
                combobox_IDTecnico_Modificar_Trabajo.Visible = false;
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

                            DataTableCelularesBusqueda.Rows.Clear();
                            try
                            {
                                conn.Open();
                                busqueda = "SELECT ID, Modelo, Marca, IMEI, Estado, Cedula_Cliente, ID_Usuario FROM celulares WHERE Cedula_Cliente = (SELECT cedula FROM clientes WHERE Nombre = '" + txtCampo_Busqueda.Text + "') AND Baja = 1;";
                                cmd = new MySqlCommand(busqueda, conn);
                                cmd.CommandType = System.Data.CommandType.Text;
                                reader = cmd.ExecuteReader();
                                DataTableCelularesBusqueda.Load(reader);
                            }
                            catch (Exception x)
                            {
                                MessageBox.Show("Ocurrio un error inesperado durante la busqueda\n\n" + x.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            finally
                            {
                                conn.Close();
                            }
                            tablaCelulares.DataSource = DataTableCelularesBusqueda;
                            break;

                        case "Marca":

                            DataTableCelularesBusqueda.Rows.Clear();
                            try
                            {
                                conn.Open();
                                busqueda = "SELECT ID, Modelo, Marca, IMEI, Estado, Cedula_Cliente, ID_Usuario FROM celulares WHERE Marca = '" + txtCampo_Busqueda.Text + "' AND Baja = 1;";
                                cmd = new MySqlCommand(busqueda, conn);
                                cmd.CommandType = System.Data.CommandType.Text;
                                reader = cmd.ExecuteReader();
                                DataTableCelularesBusqueda.Load(reader);
                            }
                            catch (Exception x)
                            {
                                MessageBox.Show("Ocurrio un error inesperado durante la busquedas\n\n" + x.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            finally
                            {
                                conn.Close();
                            }
                            tablaCelulares.DataSource = DataTableCelularesBusqueda;
                            break;

                        case "Modelo":

                            DataTableCelularesBusqueda.Rows.Clear();
                            try
                            {
                                conn.Open();
                                busqueda = "SELECT ID, Modelo, Marca, IMEI, Estado, Cedula_Cliente, ID_Usuario FROM celulares WHERE Modelo = '" + txtCampo_Busqueda.Text + "' AND Baja = 1;";
                                cmd = new MySqlCommand(busqueda, conn);
                                cmd.CommandType = System.Data.CommandType.Text;
                                reader = cmd.ExecuteReader();
                                DataTableCelularesBusqueda.Load(reader);
                            }
                            catch (Exception x)
                            {
                                MessageBox.Show("Ocurrio un error inesperado durante la busqueda\n\n" + x.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            finally
                            {
                                conn.Close();
                            }
                            tablaCelulares.DataSource = DataTableCelularesBusqueda;
                            break;

                        case "ID":

                            DataTableCelularesBusqueda.Rows.Clear();
                            try
                            {
                                conn.Open();
                                busqueda = "SELECT ID, Modelo, Marca, IMEI, Estado, Cedula_Cliente, ID_Usuario FROM celulares WHERE ID = " + txtCampo_Busqueda.Text + " AND Baja = 1;";
                                cmd = new MySqlCommand(busqueda, conn);
                                cmd.CommandType = System.Data.CommandType.Text;
                                reader = cmd.ExecuteReader();
                                DataTableCelularesBusqueda.Load(reader);
                            }
                            catch (Exception x)
                            {
                                MessageBox.Show("Ocurrio un error inesperado durante la busqueda\n\n" + x.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            finally
                            {
                                conn.Close();
                            }
                            tablaCelulares.DataSource = DataTableCelularesBusqueda;
                            break;

                        default:

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

                            DataTableTrabajosBusqueda.Rows.Clear();
                            try
                            {
                                conn.Open();
                                busqueda = "SELECT ID, ID_Tecnico, Plazo, Presupuesto, Problema, Fecha_Ingreso, Adelanto, ID_Celular FROM trabajos WHERE Presupuesto = " + txtCampo_Busqueda.Text + " AND Baja = 1;";
                                cmd = new MySqlCommand(busqueda, conn);
                                cmd.CommandType = System.Data.CommandType.Text;
                                reader = cmd.ExecuteReader();
                                DataTableTrabajosBusqueda.Load(reader);
                            }
                            catch (Exception x)
                            {
                                MessageBox.Show("Ocurrio un error inesperado durante la busquedas\n\n" + x.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            finally
                            {
                                conn.Close();
                            }
                            tablaTrabajos.DataSource = DataTableTrabajosBusqueda;
                            break;

                        case "Problema":


                            DataTableTrabajosBusqueda.Rows.Clear();
                            try
                            {
                                conn.Open();
                                busqueda = "SELECT ID, ID_Tecnico, Plazo, Presupuesto, Problema, Fecha_Ingreso, Adelanto, ID_Celular FROM trabajos WHERE Problema = '" + txtCampo_Busqueda.Text + "' AND Baja = 1;";
                                cmd = new MySqlCommand(busqueda, conn);
                                cmd.CommandType = System.Data.CommandType.Text;
                                reader = cmd.ExecuteReader();
                                DataTableTrabajosBusqueda.Load(reader);
                            }
                            catch (Exception x)
                            {
                                MessageBox.Show("Ocurrio un error inesperado durante la busquedas\n\n" + x.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            finally
                            {
                                conn.Close();
                            }
                            tablaTrabajos.DataSource = DataTableTrabajosBusqueda;
                            break;

                        case "Fecha de ingreso":


                            DataTableTrabajosBusqueda.Rows.Clear();
                            try
                            {
                                conn.Open();
                                busqueda = "SELECT ID, ID_Tecnico, Plazo, Presupuesto, Problema, Fecha_Ingreso, Adelanto, ID_Celular FROM trabajos WHERE Fecha_Ingreso = '" + txtCampo_Busqueda.Text + "' AND Baja = 1;";
                                cmd = new MySqlCommand(busqueda, conn);
                                cmd.CommandType = System.Data.CommandType.Text;
                                reader = cmd.ExecuteReader();
                                DataTableTrabajosBusqueda.Load(reader);
                            }
                            catch (Exception x)
                            {
                                MessageBox.Show("Ocurrio un error inesperado durante la busquedas\n\n" + x.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            finally
                            {
                                conn.Close();
                            }
                            tablaTrabajos.DataSource = DataTableTrabajosBusqueda;
                            break;

                        case "ID del celular":


                            DataTableTrabajosBusqueda.Rows.Clear();
                            try
                            {
                                conn.Open();
                                busqueda = "SELECT ID, ID_Tecnico, Plazo, Presupuesto, Problema, Fecha_Ingreso, Adelanto, ID_Celular FROM trabajos WHERE ID_Celular = " + txtCampo_Busqueda.Text + " AND Baja = 1;";
                                cmd = new MySqlCommand(busqueda, conn);
                                cmd.CommandType = System.Data.CommandType.Text;
                                reader = cmd.ExecuteReader();
                                DataTableTrabajosBusqueda.Load(reader);
                            }
                            catch (Exception x)
                            {
                                MessageBox.Show("Ocurrio un error inesperado durante la busquedas\n\n" + x.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            finally
                            {
                                conn.Close();
                            }
                            tablaTrabajos.DataSource = DataTableTrabajosBusqueda;
                            break;

                        default:

                            break;
                    }
                }
            }
        }

        //Función para una ayuda visual al usuario, no muy elegante pero intenta hacer su función principal.
        private void AyudaVisual_Tabla_Mostrar()
        {
            /*
            if (radioButton_TablaCelulares.Checked || radioButton_TablaTrabajos.Checked)
            {
                labAyudaVisual_SeleccionarTabla.Visible = false;
                labAyudaVisual_SeleccionarTabla.Enabled = false;
            }
            else
            {
                labAyudaVisual_SeleccionarTabla.Visible = true;
                labAyudaVisual_SeleccionarTabla.Enabled = true;
            }
            */
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            MostrarDatosEnLasTablasCelulares();
            MostrarDatosEnLasTablasTrabajos();
            MostrarNombreYelIDdelTecnicoEnUnComboBox();
            MostrarNombreYlaCeduladelClienteEnUnComboBoxParaModificacionOAdiciónDeLosCelulares();
            MostrarModeloMarcaYlaCedulaDelClienteEnUnComboBoxParaModificacionOAdiciónDeLosCelulares();


            MenuOpcionesCelular.Enabled = true;
            MenuOpcionesCelular.Visible = true;


        }

        private void Principal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
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
                btnAgregar.BackColor = Color.FromArgb(255, 40, 40);
                btnModificar.BackColor = Color.FromArgb(255, 40, 40);
                btnEliminar.BackColor = Color.FromArgb(255, 40, 40);
                btnCerrarSesion.BackColor = Color.FromArgb(255, 40, 40);
                btnMenuPrincipal.BackColor = Color.FromArgb(255, 40, 40);

                tabIndex_Pestañas.Location = new Point(124, 78);
                //tablaTrabajos.Location = new Point(124, 78);
            }
            else
            {
                panelD.Width = 45;
                btnAgregar.ForeColor = Color.FromArgb(255, 40, 40);
                btnModificar.ForeColor = Color.FromArgb(255, 40, 40);
                btnEliminar.ForeColor = Color.FromArgb(255, 40, 40);
                btnCerrarSesion.ForeColor = Color.FromArgb(255, 40, 40);
                btnMenuPrincipal.ForeColor = Color.FromArgb(255, 40, 40);
                btnAgregar.BackColor = Color.FromArgb(255, 40, 40);
                btnCerrarSesion.BackColor = Color.FromArgb(255, 40, 40);
                btnEliminar.BackColor = Color.FromArgb(255, 40, 40);
                btnModificar.BackColor = Color.FromArgb(255, 40, 40);
                btnMenuPrincipal.BackColor = Color.FromArgb(255, 40, 40);

                btnAgregar.FlatStyle = FlatStyle.Flat;
                btnModificar.FlatStyle = FlatStyle.Flat;
                btnEliminar.FlatStyle = FlatStyle.Flat;
                btnCerrarSesion.FlatStyle = FlatStyle.Flat;
                //tablaCelulares.Location = new Point(49, 78);
                //tablaTrabajos.Location = new Point(49, 78);
                tabIndex_Pestañas.Location = new Point(49, 78);
            }
        }


        //Codigo referente a los botones del menu secundario:

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (Seguridad.getInvitado == false)
            {
                if (tabIndex_Pestañas.SelectedTab == tab_Celulares)
                {
                    //Panel-Agregar y GroupBoxes-Agregar:
                    panel_Agregar.Enabled = true;
                    panel_Agregar.BringToFront();
                    timer_Agregar_Agrandar.Enabled = true;
                    timer_Agregar_Reducir.Enabled = false;

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
            DialogResult siono = MessageBox.Show("¿Está seguro de Cerrar la Sesión?", "Hmm...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (siono == DialogResult.Yes)
            {
                Application.Restart();
            }
            else
            {

            }
        }

        //Botones con funciones SQL:
        private void tablaCelulares_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            MostrarNombreYelIDdelTecnicoEnUnComboBox();

            //linkeo de la cedula del cliente:
            if (e.RowIndex >= 0 && e.ColumnIndex == 6)
            {

                string cedula = tablaCelulares.Rows[e.RowIndex].Cells["Cedula_Cliente"].Value.ToString();


                string nombreDelCliente = ObtenerNombreHaciendoClickEnCedula(cedula);
                string celularDelCliente = ObtenerCelularHaciendoClickEnCedula(cedula);
                string telefonoDelCliente = ObtenerTelefonoHaciendoClickEnCedula(cedula);
                string correoElectrionicoDelCliente = ObtenerCorreoElectronicoHaciendoClickEnCedula(cedula);


                MessageBox.Show($"Información del Cliente:\n\nNombre y Apellido: {nombreDelCliente}\n\nCelular Adicional: {celularDelCliente}\n\nTelefono Fijo: {telefonoDelCliente}\n\nCorreo Electrónico: {correoElectrionicoDelCliente}", "Información acerca del Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //Sino que solo seleccione el ID para borrar o modificar el celular.
            else if (e.RowIndex >= 0)
            {

                DataGridViewRow filaSeleccionada = tablaCelulares.Rows[e.RowIndex];

                //para poner todos los valores en la tabla de modificación de celulares:
                if (groupBox_ModificarCelulares.Enabled == true && panel_Modificar.Enabled == true && groupBox_ModificarCelulares.Visible == true && panel_Modificar.Visible == true)
                {


                    //Selección:
                    string seleccion = filaSeleccionada.Cells["ID"].Value.ToString();
                    clavePrimariaCelulares = seleccion;
                    label_modificarCelular_Seleccion.Text = "Selección: " + clavePrimariaCelulares;

                    //textBoxes:
                    string IMEI = filaSeleccionada.Cells["IMEI"].Value.ToString();
                    string modelo = filaSeleccionada.Cells["Modelo"].Value.ToString();
                    string marca = filaSeleccionada.Cells["Marca"].Value.ToString();


                    //comboboxes:
                    string nombreTecnico = filaSeleccionada.Cells["Nombre"].Value.ToString();
                    string CIcliente = filaSeleccionada.Cells["Cedula_Cliente"].Value.ToString();


                    //aplicaciones:
                    txtIMEI_Modificar.Text = IMEI;
                    txtModelo_Modificar.Text = modelo;
                    txtMarca_Modificar.Text = marca;

                    //comboboxes:
                    foreach (Cliente cliente in combobox_CI_Del_Dueño_Modificar.Items)
                    {
                        if (cliente.Cedula == CIcliente)
                        {
                            combobox_CI_Del_Dueño_Modificar.SelectedItem = cliente;
                            break;
                        }
                    }

                    foreach (Tecnicos tecnico in comboBox_ModificarTecnicoACargo.Items)
                    {
                        if (tecnico.Nombre == nombreTecnico)
                        {
                            comboBox_ModificarTecnicoACargo.SelectedItem = tecnico;
                            break;
                        }
                    }

                    //para los detalles:

                    string detalles = string.Empty;

                    try
                    {
                        conn.Open();
                        string query = $"SELECT Detalles FROM celulares WHERE ID ={seleccion}";
                        cmd = new MySqlCommand(query, conn);
                        reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            detalles = reader["Detalles"].ToString();

                            txtDetallesUobservaciones_Modificar.Text = detalles;
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("No se pudo meter los detalles en el campo de texto de Detalles/Observaciones\n\n" + ex.Message, "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                    finally
                    {
                        conn.Close();
                    }


                    //string query = $"SELECT detalles from celulares WHERE ID ={clavePrimariaCelulares}";

                    //try
                    //{
                    //    conn.Open();
                    //    cmd = new MySqlCommand(query, conn);
                    //    string detalles = cmd.ExecuteNonQuery().ToString();
                    //    txtDetallesUobservaciones_Modificar.Text = detalles;
                    //}
                    //catch (Exception ex)
                    //{
                    //    MessageBox.Show("No se pudo poner los detalles en el campo de texto!\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //}
                    //finally
                    //{
                    //    conn.Close();
                    //}

                }
                else if (groupBox_ModificarTrabajos.Enabled == true && panel_Modificar.Enabled == true && groupBox_ModificarTrabajos.Visible == true && panel_Modificar.Visible == true)
                {

                }
                // para dar de baja los celulares.
                else
                {
                    numeroDeFilaCelulares = e.RowIndex;
                    clavePrimariaCelulares = tablaCelulares.Rows[numeroDeFilaCelulares].Cells["ID"].Value.ToString();
                    if (groupBox_EliminarCelulares.Height > 300)
                    {
                        labMostrarIDdelCelularSeleccionado.ForeColor = Color.Black;
                        labMostrarIDdelCelularSeleccionado.Text = clavePrimariaCelulares;
                    }
                    else if (groupBox_ModificarCelulares.Height > 300)
                    {
                        label_modificarCelular_Seleccion.Text = "Selección: " + clavePrimariaCelulares;
                    }
                    else
                    {
                        labMostrarIDdelCelularSeleccionado.ForeColor = Color.Brown;
                        labMostrarIDdelCelularSeleccionado.Text = "Seleccione un elemento de la tabla.";

                    }
                }
            }
            else
            {

            }

            if (e.RowIndex >= 0 && e.ColumnIndex == 4)
            {
                string detalles = ObtenerDetallesDesdeElEstado();

                MessageBox.Show("Detalles/Observaciones:\n\n" + detalles, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private string ObtenerNombreHaciendoClickEnCedula(string cedula)
        {
            string nombreDelCliente = string.Empty;

            try
            {
                conn.Open();
                string query = $"SELECT Nombre FROM Clientes WHERE Cedula = @cedula";
                cmd = new MySqlCommand(query, conn);
                try
                {
                    cmd.Parameters.AddWithValue("@cedula", cedula);
                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        nombreDelCliente = reader["Nombre"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return nombreDelCliente;
        }
        private string ObtenerTelefonoHaciendoClickEnCedula(string cedula)
        {
            string telefonoDelCliente = string.Empty;


            try
            {
                conn.Open();
                string query = $"SELECT Telefono FROM Clientes WHERE cedula = @cedula";
                cmd = new MySqlCommand(query, conn);
                try
                {
                    cmd.Parameters.AddWithValue("@cedula", cedula);
                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        telefonoDelCliente = reader["Telefono"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return telefonoDelCliente;
        }

        private string ObtenerCorreoElectronicoHaciendoClickEnCedula(string cedula)
        {
            string correoElectronicoDelCliente = string.Empty;


            try
            {
                conn.Open();
                string query = $"SELECT CorreoElectronico FROM Clientes WHERE Cedula = @cedula";
                cmd = new MySqlCommand(query, conn);
                try
                {
                    cmd.Parameters.AddWithValue("@cedula", cedula);
                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        correoElectronicoDelCliente = reader["CorreoElectronico"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return correoElectronicoDelCliente;
        }

        private string ObtenerCelularHaciendoClickEnCedula(string cedula)
        {
            string celularDelCliente = string.Empty;

            try
            {
                conn.Open();
                string query = $"SELECT celular FROM Clientes WHERE cedula = @cedula";
                cmd = new MySqlCommand(query, conn);
                try
                {
                    cmd.Parameters.AddWithValue("@cedula", cedula);
                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        celularDelCliente = reader["Celular"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return celularDelCliente;
        }

        private string ObtenerDetallesDesdeElEstado()
        {
            string estadoDelCelular = string.Empty;

            try
            {
                conn.Open();
                string query = $"SELECT detalles FROM celulares WHERE ID = {clavePrimariaCelulares}";
                cmd = new MySqlCommand(query, conn);
                try
                {
                    cmd.Parameters.AddWithValue("@detalles", estadoDelCelular);
                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        estadoDelCelular = reader["Detalles"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return estadoDelCelular;
        }

        private void tablaTrabajos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                numeroDeFilaTrabajos = e.RowIndex;
                clavePrimariaTrabajos = tablaTrabajos.Rows[numeroDeFilaTrabajos].Cells["ID"].Value.ToString();
                if (groupBox_EliminarTrabajos.Height > 300)
                {
                    txtID_Trabajo_Eliminar.Text = clavePrimariaTrabajos;
                }
            }
        }

        private void btnAgregarCelular_Click(object sender, EventArgs e)
        {
            Tecnicos idDelTecnicoAcargo = (Tecnicos)comboBox_AgregarCelular_IdDelTecnicoAcargo.SelectedItem;
            Cliente cedulaDelPropietarioDelCelular = (Cliente)comboBox_AgregarCelular_CedulaDelDueño.SelectedItem;

            try
            {
                if (txtModelo_Agregar.Text != "" && txtDetallesUobservaciones_Agregar.Text != "" && txtMarca_Agregar.Text != "" && comboBox_AgregarCelular_CedulaDelDueño.Items != null && comboBox_AgregarCelular_IdDelTecnicoAcargo.Items != null)
                {

                    if (radioButton_Arreglado_Agregar.Checked.Equals(true) || radioButton_Averiado_Agregar.Checked.Equals(true) || radioButton_EnProceso_Agregar.Checked.Equals(true) || radioButton_EnEspera_Agregar.Checked.Equals(true))
                    {
                        conn.Open();
                        modelo = txtModelo_Agregar.Text;
                        marca = txtMarca_Agregar.Text;
                        imei = txtIMEI_Agregar.Text;
                        string detalles = txtDetallesUobservaciones_Agregar.Text;
                        if (radioButton_Arreglado_Agregar.Checked)
                        {
                            estado = "Arreglado";
                        }
                        else if (radioButton_Averiado_Agregar.Checked)
                        {
                            estado = "Averiado";
                        }
                        else if (radioButton_EnEspera_Agregar.Checked)
                        {
                            estado = "En Espera";
                        }
                        else if (radioButton_EnProceso_Agregar.Checked)
                        {
                            estado = "En Proceso";
                        }
                        string ciCliente = cedulaDelPropietarioDelCelular.Cedula;
                        string idUsuario = idDelTecnicoAcargo.ID;

                        insertarCelulares = "INSERT INTO celulares(Modelo, Marca, IMEI, Detalles, Estado, Cedula_Cliente, ID_Usuario) VALUES('" + modelo + "', '" + marca + "', '" + imei + "', '" + detalles + "', '" + estado + "', '" + ciCliente + "', " + idUsuario + ")";
                        cmd = new MySqlCommand(insertarCelulares, conn);

                        try
                        {
                            cmd.ExecuteNonQuery();

                            txtModelo_Agregar.Text = "";
                            txtIMEI_Agregar.Text = "";
                            txtMarca_Agregar.Text = "";
                            txtDetallesUobservaciones_Agregar.Text = "";
                            combobox_IDdelTecnico_AgregarTrabajos.SelectedItem = null;
                            comboBox_AgregarCelular_CedulaDelDueño.SelectedItem = null;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("No se ingreso correctamente el celular\n\n" + ex.Message, "Ups..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            MessageBox.Show(ex.Message);
                        }
                    }

                    else
                    {
                        MessageBox.Show("¿Está averiado o...?", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                else
                {
                    MessageBox.Show("No deje un campo de texto obligatorio en blanco", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fallo la conexion con el servidor o la base de datos\n\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
                MostrarDatosEnLasTablasCelulares();
            }
        }

        private void btnModificar_Celular_Click(object sender, EventArgs e)
        {
            Tecnicos idDelTecnicoSeleccionado = (Tecnicos)comboBox_ModificarTecnicoACargo.SelectedItem;
            Cliente CIcliente = (Cliente)combobox_CI_Del_Dueño_Modificar.SelectedItem;

            if (idDelTecnicoSeleccionado != null)
            {

                //Codigo para modificar el Celular:
                if (txtModelo_Modificar.Text != "" && txtMarca_Modificar.Text != "" && txtIMEI_Modificar.Text != "" && combobox_CI_Del_Dueño_Modificar.Text != "" && comboBox_ModificarTecnicoACargo.SelectedItem != null && txtDetallesUobservaciones_Modificar.Text != "")
                {

                    if (radioButton_Arreglado_Modificar.Checked == true || radioButton_Averiado_Modificar.Checked == true || radioButton_EnProceso_Modificar.Checked || radioButton_EnEspera_Modificar.Checked)
                    {
                        try
                        {
                            conn.Open();
                            modelo = txtModelo_Modificar.Text;
                            marca = txtMarca_Modificar.Text;
                            imei = txtIMEI_Modificar.Text;
                            string detalles = txtDetallesUobservaciones_Modificar.Text;
                            string ciCliente = CIcliente.Cedula;
                            string idUsuario = idDelTecnicoSeleccionado.ID;

                            if (radioButton_Arreglado_Modificar.Checked)
                            {
                                estado = "Arreglado";
                            }
                            else if (radioButton_Averiado_Modificar.Checked)
                            {
                                estado = "Averiado";
                            }
                            else if (radioButton_EnProceso_Modificar.Checked)
                            {
                                estado = "En Proceso";
                            }
                            else if (radioButton_EnEspera_Modificar.Checked)
                            {
                                estado = "En Espera";
                            }

                            modifcarCelulares = $"UPDATE celulares SET Modelo ='{modelo}', Marca ='{marca}', IMEI ='{imei}',Estado ='{estado}',Cedula_Cliente ='{ciCliente}', ID_Usuario ={idUsuario}, Detalles ='{detalles}' WHERE celulares.ID ={clavePrimariaCelulares}";
                            cmd = new MySqlCommand(modifcarCelulares, conn);

                            DialogResult siono = MessageBox.Show("¿Está seguro de querer modificar este celular?", "Hmm...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (siono == DialogResult.Yes)
                            {
                                try
                                {
                                    cmd.ExecuteNonQuery();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("No se pudo modificar el celular.\n\nCompruebe la existencia del celular y el ID del mismo." + ex.Message, "Ups..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("No se han realizado cambios", "Está bien...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Fallo la conexion con el servidor o la base de datos\n\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        }

        private void btnEliminar_Celular_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                eliminarCelulares = $"UPDATE celulares SET Baja = 1 WHERE ID ={clavePrimariaCelulares};";
                cmd = new MySqlCommand(eliminarCelulares, conn);
                DialogResult siono = MessageBox.Show("¿Está seguro que desea eliminar este celular?\n\n No lo volverá a ver nunca más.", "Hmm...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (siono == DialogResult.Yes)
                {

                    try
                    {
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Eliminación correcta del celular", "Éxito!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se elimino correctamente el celular\n\n" + ex.Message, "Ups..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        conn.Close();
                        MostrarDatosEnLasTablasCelulares();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fallo la conexion con el servidor o la base de datos\n\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_EliminarTrabajos_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                eliminarCelulares = $"UPDATE trabajos SET Baja = 1 WHERE ID ={clavePrimariaTrabajos};";
                cmd = new MySqlCommand(eliminarCelulares, conn);
                DialogResult siono = MessageBox.Show("¿Está seguro que desea eliminar este trabajo?.", "Hmm...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (siono == DialogResult.Yes)
                {

                    try
                    {
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Eliminación correcta del celular", "Éxito!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se elimino correctamente el celular\n\n" + ex.Message, "Ups..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        conn.Close();
                        MostrarDatosEnLasTablasCelulares();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fallo la conexion con el servidor o la base de datos\n\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregar_Trabajo_Click(object sender, EventArgs e)
        {
            Tecnicos idDelTecnico = (Tecnicos)combobox_IDdelTecnico_AgregarTrabajos.SelectedItem;
            Celulares idDelCelular = (Celulares)combobox_IDdelCelular_Trabajo_Agregar.SelectedItem;

            if (txtPresupuesto_Agregar.Text != "" && txtProblema_Agregar.Text != "" && dateTimePicker_FechaDeIngreso_Agregar.Value != null && combobox_IDdelCelular_Trabajo_Agregar.Text != "" || combobox_IDdelTecnico_AgregarTrabajos.Text != "")
            {
                try
                {
                    conn.Open();
                    string idCelular = idDelCelular.ID;
                    plazo = dateTimePicker_Plazo_Agregar.Value;
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
                        if (diaPlazo < 10)
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
                    fechaIngreso = dateTimePicker_FechaDeIngreso_Agregar.Value;
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
                    string tecnicoACargo = idDelTecnico.ID;

                    insertarTrabajos = $"INSERT INTO Trabajos (ID_Tecnico, Plazo, Presupuesto, Problema, Fecha_Ingreso, Adelanto, ID_Celular) VALUES(" + tecnicoACargo + ",'" + stringPlazo + "', " + presupuesto + ", '" + problema + "', '" + stringFechaIngreso + "', " + adelanto + ", " + idCelular + ")";
                    cmd = new MySqlCommand(insertarTrabajos, conn);
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se ingreso correctamente el Trabajo\n\n" + ex.Message, "Ups..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Fallo la conexion con el servidor o la base de datos\n\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (txtIMEI_Modificar.Text == "" && txtMarca_Modificar.Text == "" && txtModelo_Modificar.Text == "" || combobox_CI_Del_Dueño_Modificar.Items == null && comboBox_ModificarTecnicoACargo.Items == null)
            {
                //instanciación de la clase "Tecnicos", objetualizada e inicializada en el combobox:
                Tecnicos idDelTecnicoaCargo = (Tecnicos)combobox_IDTecnico_Modificar_Trabajo.SelectedItem;

                //Label de error:
                labelError_Modificar_Trabajos.Enabled = false;
                labelError_Modificar_Trabajos.Visible = false;

                //textBox:
                txtTrabajo_ID_Modificar.BringToFront();

                //Codigo para modificar el Trabajos:
                if (combobox_IDTecnico_Modificar_Trabajo.Items != null && dateTimePicker_Plazo_Modificar.Value != null && txtPresupuesto_Modificar.Text != "" && txtProblema_Modificar.Text != "" && dateTimePicker_FechaDeIngreso_Modificar.Value != null && txtAdelanto_Modificar.Text != null)
                {
                    try
                    {
                        conn.Open();
                        string tecnicoACargo = idDelTecnicoaCargo.ID;
                        idCelular = int.Parse(txtTrabajo_ID_Modificar.Text);
                        plazo = dateTimePicker_FechaDeIngreso_Modificar.Value;
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
                            if (diaPlazo < 10)
                            {
                                stringPlazo = plazo.Year.ToString() + "-" + plazo.Month.ToString() + "-0" + plazo.Day.ToString();
                            }
                            else
                            {
                                stringPlazo = plazo.Year.ToString() + "-" + plazo.Month.ToString() + "-" + plazo.Day.ToString();
                            }
                        }
                        presupuesto = int.Parse(txtPresupuesto_Modificar.Text);
                        problema = txtProblema_Modificar.Text;
                        fechaIngreso = dateTimePicker_FechaDeIngreso_Modificar.Value;
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
                        adelanto = int.Parse(txtAdelanto_Modificar.Text);

                        modifcarTrabajos = "UPDATE trabajos SET ID_Tecnico = '" + tecnicoACargo + "' Plazo = '" + stringPlazo + "', Presupuesto = " + presupuesto + ", Problema = '" + problema + "', Fecha_Ingreso = '" + stringFechaIngreso + "', Adelanto = " + adelanto + ", ID_Celular = " + idCelular + " WHERE trabajos.ID = " + clavePrimariaTrabajos + ";";
                        cmd = new MySqlCommand(modifcarTrabajos, conn);
                        try
                        {
                            cmd.ExecuteNonQuery();
                            txtTrabajo_ID_Modificar.Text = "";
                            txtPresupuesto_Modificar.Text = "";
                            txtProblema_Modificar.Text = "";
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("No se modifico correctamente el trabajo\n\n" + ex.Message, "Ups..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Fallo la conexion con el servidor o la base de datos\n\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            else
            {
                comboBoxColumnas_Trabajos.Text = null;
                //Labels:
                labelError_Modificar_Trabajos.Enabled = true;
                labelError_Modificar_Trabajos.Visible = true;

                labelTrabajo_ID_Modificar.Enabled = false;
                labelTrabajo_ID_Modificar.Visible = false;

                labelPlazo_Modificar.Enabled = false;
                labelPlazo_Modificar.Visible = false;

                labelPresupuesto_Modificar.Enabled = false;
                labelPresupuesto_Modificar.Visible = false;

                labelProblema_Modificar.Enabled = false;
                labelProblema_Modificar.Visible = false;

                labelFechaDeIngreso_Modificar.Enabled = false;
                labelFechaDeIngreso_Modificar.Visible = false;

                labelAdelanto_Modificar.Enabled = false;
                labelAdelanto_Modificar.Visible = false;

                labelModificar_Columna_Trabajos.Enabled = false;
                labelModificar_Columna_Trabajos.Visible = false;

                //TextBox y DateTimePicker:
                txtTrabajo_ID_Modificar.Enabled = false;
                txtTrabajo_ID_Modificar.Visible = false;

                dateTimePicker_Plazo_Modificar.Enabled = false;
                dateTimePicker_Plazo_Modificar.Visible = false;

                txtPresupuesto_Modificar.Enabled = false;
                txtPresupuesto_Modificar.Visible = false;

                txtProblema_Modificar.Enabled = false;
                txtProblema_Modificar.Visible = false;

                dateTimePicker_FechaDeIngreso_Modificar.Enabled = false;
                dateTimePicker_FechaDeIngreso_Modificar.Visible = false;

                txtAdelanto_Modificar.Enabled = false;
                txtAdelanto_Modificar.Visible = false;

                txtModificar_Columna_Trabajos.Enabled = false;
                txtModificar_Columna_Trabajos.Visible = false;
            }
        }




        private void btnEliminar_Trabajo_Click(object sender, EventArgs e)
        {
            if (txtID_Trabajo_Eliminar.Text != "")
            {
                idTrabajo = int.Parse(txtID_Trabajo_Eliminar.Text);
                try
                {
                    conn.Open();
                    eliminarTrabajos = "UPDATE trabajos SET Baja = 1 WHERE ID = " + idTrabajo + ";";
                    cmd = new MySqlCommand(eliminarTrabajos, conn);

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se elimino correctamente el trabajo\n\n" + ex.Message, "Ups..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        conn.Close();
                        MostrarDatosEnLasTablasTrabajos();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Fallo la conexion con el servidor o la base de datos\n\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No deje un campo de texto obligatorio en blanco", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }



        //Botones del Menu principal:
        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            Usuarios mostrar = new Usuarios();
            mostrar.Show();
            this.Hide();
        }
        private void btnClientes_Click(object sender, EventArgs e)
        {
            Clientes mostrar = new Clientes();
            mostrar.Show();
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
                groupBox_AgregarCelulares.Height = 593;
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
                groupBox_AgregarTrabajos.Height = 593;
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
            if (groupBox_Menu.Height < 480)
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
                groupBox_ModificarCelulares.Height = groupBox_ModificarCelulares.Height + 45;
                groupBox_ModificarCelulares.Enabled = true;
            }
            else
            {
                timer_GroupBox_ModificarC_Agrandar.Enabled = false;
                groupBox_ModificarCelulares.Width = 413;
                groupBox_ModificarCelulares.Height = 564;
            }
        }

        private void timer_GroupBox_ModificarT_Reducir_Tick(object sender, EventArgs e)
        {
            if (groupBox_ModificarTrabajos.Height > 0)
            {
                groupBox_ModificarTrabajos.Height = groupBox_ModificarTrabajos.Height - 45;
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
                groupBox_ModificarTrabajos.Height = groupBox_ModificarTrabajos.Height + 45;
                groupBox_ModificarTrabajos.Enabled = true;
            }
            else
            {
                timer_GroupBox_ModificarT_Agrandar.Enabled = false;
                groupBox_ModificarTrabajos.Width = 413;
                groupBox_ModificarTrabajos.Height = 564;
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
                groupBox_EliminarCelulares.Height = 593;
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
                groupBox_EliminarTrabajos.Height = 593;
                groupBox_EliminarTrabajos.Enabled = true;
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
            MostrarNombreYelIDdelTecnicoEnUnComboBox();

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
            AyudaVisual_Tabla_Mostrar();
            btnRecargar.Enabled = true;
            btnRecargar.Visible = true;

            MenuOpcionesCelular.Enabled = true;
            MenuOpcionesCelular.Visible = true;
            MenuOpcionesTrabajos.Enabled = false;
            MenuOpcionesTrabajos.Visible = false;



            if (tablaCelulares.Height <= 600)
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

        //Botón de cierre del programa con shortcut Default: "Escape"
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            DialogResult seguridad = MessageBox.Show("¿Está seguro de querer Cerrar el programa?", "Saliendo del Programa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (seguridad == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                //seguridad = DialogResult.No;
            }

        }



        private void tablaCelulares_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

            /*
             * Valor de longitudes:
             * Corta: 50px
             * Media: 80px
             * Larga: 120px
             * LargaM: 160px
             * LargaL: 180px
             * LargaXL: 200px
             * XLXL: 250px
             * 
             * valores pero totalmente al pedo, se pueden poner como un número entero sin necesidad de declararlo con anterioridad.
             * Pero bueno, le da un toque de profesionalizmo... no, lo contrario, mrd. *pain noises*
             */

            if (tablaCelulares.Columns.Contains("ID"))
            {
                //Largo de las columnas

                tablaCelulares.Columns["ID"].Width = lonigtudDeColumna_Corta;
                tablaCelulares.Columns["Marca"].Width = lonigtudDeColumna_Larga;
                tablaCelulares.Columns["IMEI"].Width = 200;
                tablaCelulares.Columns["Modelo"].Width = lonigtudDeColumna_Larga;
                tablaCelulares.Columns["Nombre"].Width = 115;


                //Renombre de columnas, más que nada es estético.
                tablaCelulares.Columns["Cedula_Cliente"].HeaderText = "Cédula";
                tablaCelulares.Columns["Nombre"].HeaderText = "Técnico";

                //Tooltips al posar el mouse
                tablaCelulares.Columns["ID"].ToolTipText = "Número identificatorio para cada celular en esta tabla";
                tablaCelulares.Columns["Marca"].ToolTipText = "La marca del teléfono";
                tablaCelulares.Columns["Modelo"].ToolTipText = "El modelo del teléfono";
                tablaCelulares.Columns["IMEI"].ToolTipText = "El número único identificatorio para cada dispositivo, normalmente viene detrás de este como una pegatina";
                tablaCelulares.Columns["Estado"].ToolTipText = "El estado en el que está actualmente el celular";
                tablaCelulares.Columns["Cedula_Cliente"].ToolTipText = "La cédula del dueño del teléfono";
                tablaCelulares.Columns["Nombre"].ToolTipText = "El Nombre del Técnico a cargo del teléfono";
            }

            int columnIndexCedula = 5;

            foreach (DataGridViewRow row in tablaCelulares.Rows)
            {
                if (row.Cells[columnIndexCedula].Value != null)
                {
                    DataGridViewCell cell = row.Cells[columnIndexCedula];
                    cell.Style.ForeColor = Color.Blue;
                }
            }
        }

        private void tablaTrabajos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (tablaTrabajos.Columns.Contains("ID"))
            {

                //Largo de las tablas:
                tablaTrabajos.Columns["ID"].Width = 50;
                tablaTrabajos.Columns["ID"].Width = 50;
                tablaTrabajos.Columns["ID"].Width = 50;
                tablaTrabajos.Columns["ID"].Width = 50;
                tablaTrabajos.Columns["ID"].Width = 50;
            }
        }

        //Que se cague, no más de 8 caracteres, que es lo que sería la cédula sin los puntos ni el guión.

        private void txtCampo_Busqueda_TextChanged(object sender, EventArgs e)
        {
            if (txtCampo_Busqueda.Text.Equals(""))
            {
                MostrarDatosEnLasTablasCelulares_SinMensajeDeError();
            }
            else
            {
                //busqueda para celulares:
                if (MenuOpcionesCelular.Enabled == true)
                {
                    option = MenuOpcionesCelular.Text;
                    switch (option)
                    {
                        case "Cedula del dueño":

                            DataTableCelularesBusqueda.Rows.Clear();
                            try
                            {
                                conn.Open();
                                busqueda = "SELECT celulares.ID, celulares.Modelo, celulares.Marca, celulares.IMEI, celulares.Estado, celulares.Cedula_Cliente, usuarios.Nombre " +
                                           "FROM celulares " +
                                           "INNER JOIN usuarios ON celulares.ID_Usuario = usuarios.ID " +
                                           $"WHERE celulares.Baja = 0 AND usuarios.Baja = 0 AND celulares.Cedula_Cliente LIKE '%{txtCampo_Busqueda.Text}%'";


                                cmd = new MySqlCommand(busqueda, conn);
                                cmd.CommandType = System.Data.CommandType.Text;
                                reader = cmd.ExecuteReader();
                                DataTableCelularesBusqueda.Load(reader);
                            }
                            catch (Exception x)
                            {
                                MessageBox.Show("Ocurrio un error inesperado durante la busqueda\n\n" + x.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            finally
                            {
                                conn.Close();
                            }
                            tablaCelulares.DataSource = DataTableCelularesBusqueda;
                            break;

                        case "Marca":

                            DataTableCelularesBusqueda.Rows.Clear();
                            try
                            {
                                conn.Open();
                                busqueda = "SELECT celulares.ID, celulares.Modelo, celulares.Marca, celulares.IMEI, celulares.Estado, celulares.Cedula_Cliente, usuarios.Nombre " +
                                           "FROM celulares " +
                                           "INNER JOIN usuarios ON celulares.ID_Usuario = usuarios.ID " +
                                           $"WHERE celulares.Baja = 0 AND usuarios.Baja = 0 AND celulares.Marca LIKE '%{txtCampo_Busqueda.Text}%'";
                                cmd = new MySqlCommand(busqueda, conn);
                                cmd.CommandType = System.Data.CommandType.Text;
                                reader = cmd.ExecuteReader();
                                DataTableCelularesBusqueda.Load(reader);
                            }
                            catch (Exception x)
                            {
                                MessageBox.Show("Ocurrio un error inesperado durante la busquedas\n\n" + x.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            finally
                            {
                                conn.Close();
                            }
                            tablaCelulares.DataSource = DataTableCelularesBusqueda;
                            break;

                        case "Modelo":

                            DataTableCelularesBusqueda.Rows.Clear();
                            try
                            {
                                conn.Open();
                                busqueda = "SELECT celulares.ID, celulares.Modelo, celulares.Marca, celulares.IMEI, celulares.Estado, celulares.Cedula_Cliente, usuarios.Nombre " +
                                           "FROM celulares " +
                                           "INNER JOIN usuarios ON celulares.ID_Usuario = usuarios.ID " +
                                           $"WHERE celulares.Baja = 0 AND usuarios.Baja = 0 AND celulares.Modelo LIKE '%{txtCampo_Busqueda.Text}%'";
                                cmd = new MySqlCommand(busqueda, conn);
                                cmd.CommandType = System.Data.CommandType.Text;
                                reader = cmd.ExecuteReader();
                                DataTableCelularesBusqueda.Load(reader);
                            }
                            catch (Exception x)
                            {
                                MessageBox.Show("Ocurrio un error inesperado durante la busqueda\n\n" + x.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            finally
                            {
                                conn.Close();
                            }
                            tablaCelulares.DataSource = DataTableCelularesBusqueda;
                            break;

                        case "Estado":

                            DataTableCelularesBusqueda.Rows.Clear();
                            try
                            {
                                conn.Open();
                                busqueda = "SELECT celulares.ID, celulares.Modelo, celulares.Marca, celulares.IMEI, celulares.Estado, celulares.Cedula_Cliente, usuarios.Nombre " +
                                           "FROM celulares " +
                                           "INNER JOIN usuarios ON celulares.ID_Usuario = usuarios.ID " +
                                           $"WHERE celulares.Baja = 0 AND usuarios.Baja = 0 AND celulares.Estado LIKE '%{txtCampo_Busqueda.Text}%'";
                                cmd = new MySqlCommand(busqueda, conn);
                                cmd.CommandType = System.Data.CommandType.Text;
                                reader = cmd.ExecuteReader();
                                DataTableCelularesBusqueda.Load(reader);
                            }
                            catch (Exception x)
                            {
                                MessageBox.Show("Ocurrio un error inesperado durante la busqueda\n\n" + x.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            finally
                            {
                                conn.Close();
                            }
                            tablaCelulares.DataSource = DataTableCelularesBusqueda;
                            break;

                        case "Tecnico a cargo":

                            DataTableCelularesBusqueda.Rows.Clear();
                            try
                            {
                                conn.Open();
                                busqueda = "SELECT celulares.ID, celulares.Modelo, celulares.Marca, celulares.IMEI, celulares.Estado, celulares.Cedula_Cliente, usuarios.Nombre " +
                                           "FROM celulares " +
                                           "INNER JOIN usuarios ON celulares.ID_Usuario = usuarios.ID " +
                                           $"WHERE celulares.Baja = 0 AND usuarios.Baja = 0 AND usuarios.Nombre LIKE '%{txtCampo_Busqueda.Text}%'";
                                cmd = new MySqlCommand(busqueda, conn);
                                cmd.CommandType = System.Data.CommandType.Text;
                                reader = cmd.ExecuteReader();
                                DataTableCelularesBusqueda.Load(reader);
                            }
                            catch (Exception x)
                            {
                                MessageBox.Show("Ocurrio un error inesperado durante la busqueda\n\n" + x.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            finally
                            {
                                conn.Close();
                            }
                            tablaCelulares.DataSource = DataTableCelularesBusqueda;
                            break;

                        default:

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

                            DataTableTrabajosBusqueda.Rows.Clear();
                            try
                            {
                                conn.Open();
                                busqueda = $"SELECT ID, ID_Tecnico, Plazo, Presupuesto, Problema, Fecha_Ingreso, Adelanto, ID_Celular FROM trabajos WHERE Presupuesto LIKE '%{txtCampo_Busqueda.Text}%' AND Baja = 0;";
                                cmd = new MySqlCommand(busqueda, conn);
                                cmd.CommandType = System.Data.CommandType.Text;
                                reader = cmd.ExecuteReader();
                                DataTableTrabajosBusqueda.Load(reader);
                            }
                            catch (Exception x)
                            {
                                MessageBox.Show("Ocurrio un error inesperado durante la busquedas\n\n" + x.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            finally
                            {
                                conn.Close();
                            }
                            tablaTrabajos.DataSource = DataTableTrabajosBusqueda;
                            break;

                        case "Problema":


                            DataTableTrabajosBusqueda.Rows.Clear();
                            try
                            {
                                conn.Open();
                                busqueda = $"SELECT ID, ID_Tecnico, Plazo, Presupuesto, Problema, Fecha_Ingreso, Adelanto, ID_Celular FROM trabajos WHERE Problema LIKE '%{txtCampo_Busqueda.Text}%' AND Baja = 0;";
                                cmd = new MySqlCommand(busqueda, conn);
                                cmd.CommandType = System.Data.CommandType.Text;
                                reader = cmd.ExecuteReader();
                                DataTableTrabajosBusqueda.Load(reader);
                            }
                            catch (Exception x)
                            {
                                MessageBox.Show("Ocurrio un error inesperado durante la busquedas\n\n" + x.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            finally
                            {
                                conn.Close();
                            }
                            tablaTrabajos.DataSource = DataTableTrabajosBusqueda;
                            break;

                        case "Fecha de ingreso":


                            DataTableTrabajosBusqueda.Rows.Clear();
                            try
                            {
                                conn.Open();
                                busqueda = $"SELECT ID, ID_Tecnico, Plazo, Presupuesto, Problema, Fecha_Ingreso, Adelanto, ID_Celular FROM trabajos WHERE Fecha_Ingreso LIKE '%{txtCampo_Busqueda.Text}%' AND Baja = 0;";
                                cmd = new MySqlCommand(busqueda, conn);
                                cmd.CommandType = System.Data.CommandType.Text;
                                reader = cmd.ExecuteReader();
                                DataTableTrabajosBusqueda.Load(reader);
                            }
                            catch (Exception x)
                            {
                                MessageBox.Show("Ocurrio un error inesperado durante la busquedas\n\n" + x.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            finally
                            {
                                conn.Close();
                            }
                            tablaTrabajos.DataSource = DataTableTrabajosBusqueda;
                            break;

                        default:

                            break;
                    }
                }
            }
        }

        private void radioButton_TablaTrabajos_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void MostrarNombreYelIDdelTecnicoEnUnComboBox()
        {

            try
            {
                string query = $"SELECT ID, Nombre FROM usuarios WHERE Baja = 0";
                conn.Open();
                cmd = new MySqlCommand(query, conn);
                reader = cmd.ExecuteReader();

                comboBox_ModificarTecnicoACargo.Items.Clear();
                comboBox_AgregarCelular_IdDelTecnicoAcargo.Items.Clear();

                List<Tecnicos> listaUsuarios = new List<Tecnicos>();

                while (reader.Read())
                {
                    string nombre = reader["Nombre"].ToString();
                    string id = reader["ID"].ToString();

                    comboBox_ModificarTecnicoACargo.Items.Add(new Tecnicos
                    {
                        Nombre = nombre,
                        ID = id
                    });

                    comboBox_AgregarCelular_IdDelTecnicoAcargo.Items.Add(new Tecnicos
                    {
                        Nombre = nombre,
                        ID = id
                    });

                    combobox_IDTecnico_Modificar_Trabajo.Items.Add(new Tecnicos
                    {
                        Nombre = nombre,
                        ID = id
                    });

                    combobox_IDdelTecnico_AgregarTrabajos.Items.Add(new Tecnicos
                    {
                        Nombre = nombre,
                        ID = id
                    });
                }


                comboBox_ModificarTecnicoACargo.DisplayMember = "";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void MostrarNombreYlaCeduladelClienteEnUnComboBoxParaModificacionOAdiciónDeLosCelulares()
        {

            try
            {
                string query = $"SELECT Nombre, Cedula FROM clientes WHERE Baja = 0";
                conn.Open();
                cmd = new MySqlCommand(query, conn);
                reader = cmd.ExecuteReader();

                comboBox_ModificarTecnicoACargo.Items.Clear();

                List<Cliente> listaUsuarios = new List<Cliente>();

                while (reader.Read())
                {
                    string nombre = reader["Nombre"].ToString();
                    string cedula = reader["Cedula"].ToString();

                    comboBox_AgregarCelular_CedulaDelDueño.Items.Add(new Cliente
                    {
                        Nombre = nombre,
                        Cedula = cedula
                    });
                    combobox_CI_Del_Dueño_Modificar.Items.Add(new Cliente
                    {
                        Nombre = nombre,
                        Cedula = cedula
                    });

                }


                comboBox_ModificarTecnicoACargo.DisplayMember = "";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void MostrarModeloMarcaYlaCedulaDelClienteEnUnComboBoxParaModificacionOAdiciónDeLosCelulares()
        {

            try
            {
                string query = $"SELECT ID, Marca, Modelo, Cedula_Cliente FROM celulares WHERE Baja = 0";
                conn.Open();
                cmd = new MySqlCommand(query, conn);
                reader = cmd.ExecuteReader();

                combobox_IDdelCelular_Trabajo_Agregar.Items.Clear();

                List<Celulares> listaUsuarios = new List<Celulares>();

                while (reader.Read())
                {
                    string id = reader["ID"].ToString();
                    string marca = reader["Marca"].ToString();
                    string modelo = reader["Modelo"].ToString();
                    string ci_Cliente = reader["Cedula_Cliente"].ToString();

                    combobox_IDdelCelular_Trabajo_Agregar.Items.Add(new Celulares
                    {
                        Marca = marca,
                        Modelo = modelo,
                        CI_Cliente = ci_Cliente,
                        ID = id
                    });

                }


                combobox_IDdelCelular_Trabajo_Agregar.DisplayMember = "";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        private void tabIndex_Pestañas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabIndex_Pestañas.SelectedTab == tab_Celulares)
            {

                if (panel_Modificar.Enabled == true && panel_Modificar.Visible == true)
                {
                    timer_GroupBox_ModificarC_Agrandar.Enabled = true;
                    timer_GroupBox_ModificarC_Reducir.Enabled = false;

                    timer_GroupBox_ModificarT_Agrandar.Enabled = true;
                    timer_GroupBox_ModificarT_Reducir.Enabled = true;
                }
                else
                {

                    timer_GroupBox_AgregarC_Agrandar.Enabled = true;
                    timer_GroupBox_AgregarC_Reducir.Enabled = false;

                    timer_GroupBox_AgregarT_Agrandar.Enabled = false;
                    timer_GroupBox_AgregarT_Reducir.Enabled = true;
                }

                if (panel_Eliminar.Enabled == true && panel_Eliminar.Visible == true)
                {

                    timer_GroupBox_EliminarC_Agrandar.Enabled = true;
                    timer_GroupBox_EliminarC_Reducir.Enabled = false;

                    timer_GroupBox_EliminarT_Agrandar.Enabled = false;
                    timer_GroupBox_EliminarT_Reducir.Enabled = true;

                }
                else
                {

                    timer_GroupBox_EliminarC_Agrandar.Enabled = false;
                    timer_GroupBox_EliminarC_Reducir.Enabled = true;

                    timer_GroupBox_EliminarT_Agrandar.Enabled = true;
                    timer_GroupBox_EliminarT_Reducir.Enabled = false;
                }
            }
            else if (tabIndex_Pestañas.SelectedTab == tab_Trabajos)
            {
                if (panel_Modificar.Visible == true && panel_Modificar.Enabled == true)
                {
                    timer_GroupBox_ModificarC_Agrandar.Enabled = false;
                    timer_GroupBox_ModificarC_Reducir.Enabled = true;

                    timer_GroupBox_ModificarT_Agrandar.Enabled = false;
                    timer_GroupBox_ModificarT_Reducir.Enabled = false;
                }
                else
                {
                 
                    timer_GroupBox_AgregarT_Agrandar.Enabled = true;
                    timer_GroupBox_AgregarT_Reducir.Enabled = false;

           
                    timer_GroupBox_AgregarC_Reducir.Enabled = true;
                    timer_GroupBox_AgregarC_Agrandar.Enabled = false;

                }

                if (panel_Eliminar.Enabled == true && panel_Eliminar.Visible == true)
                {
                   
                    timer_GroupBox_EliminarC_Agrandar.Enabled = false;
                    timer_GroupBox_EliminarC_Reducir.Enabled = true;

                    timer_GroupBox_EliminarT_Agrandar.Enabled = true;
                    timer_GroupBox_EliminarT_Reducir.Enabled = false;

                }
                else
                {
                    
                    timer_GroupBox_EliminarC_Agrandar.Enabled = true;
                    timer_GroupBox_EliminarC_Reducir.Enabled = false;

                    timer_GroupBox_EliminarT_Agrandar.Enabled = false;
                    timer_GroupBox_EliminarT_Reducir.Enabled = true;
                }

            }
        }

        private void tabIndex_Pestañas_TabIndexChanged(object sender, EventArgs e)
        {

        }

        private void tablaCelulares_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 4 && e.RowIndex >= 0)
            {
                string estado = tablaCelulares.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                if (estado == "Averiado")
                {
                    e.CellStyle.BackColor = Color.DarkRed;
                    e.CellStyle.ForeColor = Color.White;
                }
                else if (estado == "Arreglado")
                {
                    e.CellStyle.BackColor = Color.DarkGreen;
                    e.CellStyle.ForeColor = Color.White;
                }
                else if (estado == "En Espera")
                {
                    e.CellStyle.BackColor = Color.FromArgb(255, 221, 51);
                    e.CellStyle.ForeColor = Color.Black;
                }
                else if (estado == "En Proceso")
                {
                    e.CellStyle.BackColor = Color.MidnightBlue;
                    e.CellStyle.ForeColor = Color.White;
                }
            }
        }

        private void tablaCelulares_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 5)
            {
                DataGridViewCell cell = tablaCelulares.Rows[e.RowIndex].Cells[e.ColumnIndex];
                cell.Style.ForeColor = Color.Blue;
                tablaCelulares.Cursor = Cursors.Hand;
            }
            else
            {
                tablaCelulares.Cursor = Cursors.Default;
            }
        }

        private void timer_RecargarBDs_Tick(object sender, EventArgs e)
        {
            //Mala idea. No deja buscar a gusto.
            MostrarDatosEnLasTablasCelulares_SinMensajeDeError();
            MostrarDatosEnLasTablasTrabajos_SinMensajeDeError();
        }

        private void comboBox_AgregarCelular_IdDelTecnicoAcargo_Click(object sender, EventArgs e)
        {

        }

        private void combobox_IDdelCelular_Trabajo_Agregar_Click(object sender, EventArgs e)
        {

        }

        private void tablaTrabajos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //para que se ponga de colores los plazos.
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (tablaTrabajos.Columns[e.ColumnIndex].Name == "Plazo")
                {
                    plazo = (DateTime)e.Value;
                    DateTime diaDeHoy = DateTime.Now.Date;

                    if (plazo <= diaDeHoy)
                    {
                        e.CellStyle.BackColor = Color.DarkRed;
                        e.CellStyle.ForeColor = Color.White;
                    }
                    else if ((plazo - diaDeHoy).Days <= 3)
                    {
                        e.CellStyle.BackColor = Color.Yellow;
                    }
                    else
                    {
                        e.CellStyle.BackColor = Color.LightGreen;
                        e.CellStyle.ForeColor = Color.Black;
                    }
                }
            }
        }

        private void txtDetallesUobservaciones_Agregar_TextChanged(object sender, EventArgs e)
        {
            int caracteresRestantes = 255 - txtDetallesUobservaciones_Agregar.Text.Length;

            if (caracteresRestantes < 0)
            {
                caracteresRestantes = 0;
            }

            label_CaracteresRestantes_Detalles_Agregar.Text = $"{caracteresRestantes}/255";
        }

        private void txtDetallesUobservaciones_Agregar_KeyPress(object sender, KeyPressEventArgs e)
        {
            int caracteresRestantes = 255;

            if (txtDetallesUobservaciones_Agregar.Text.Length >= caracteresRestantes && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void txtDetallesUobservaciones_Modificar_TextChanged(object sender, EventArgs e)
        {
            int caracteresRestantes = 255 - txtDetallesUobservaciones_Modificar.Text.Length;

            if (caracteresRestantes < 0)
            {
                caracteresRestantes = 0;
            }

            label_caracteresRestantes_Detalles_Modificar.Text = $"{caracteresRestantes}/255";
        }

        private void txtDetallesUobservaciones_Modificar_KeyPress(object sender, KeyPressEventArgs e)
        {
            int caracteresRestantes = 255;

            if (txtDetallesUobservaciones_Modificar.Text.Length >= caracteresRestantes && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }


    }
}



/* It just works.
 * 
            - Tom Howard   */