using MySql.Data.MySqlClient;
using MySql.Utility.Forms;
using System;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Reflection;
using System.Security.Cryptography;
using System.Windows.Forms;




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
        MySqlConnection conn = DataBaseConnect.Conectarse("", "");
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
                cmd = new MySqlCommand("SELECT ID, Modelo, Marca, IMEI, Estado, Cedula_Cliente, ID_Usuario, Baja FROM celulares WHERE Baja = 0;", conn);
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
        private void MostrarDatosEnLasTablasTrabajos()
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
                MessageBox.Show("Fallo la conexion con el servidor o la base de datos\n\n" + x.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                radioButton_Arreglado_Modificar.Location = new Point(6, 290);
                radioButton_Averiado_Modificar.Location = new Point(93, 290);

                //Modificar Columna:
                labelModificar_Columna_Celulares.Enabled = false;
                labelModificar_Columna_Celulares.Visible = false;

                txtModificar_Columna_Celulares.Enabled = false;
                txtModificar_Columna_Celulares.Visible = false;
            }
            else if (comboBoxColumnas_Celulares.Text.Equals("Estado"))
            {
                //Modificar Columna:
                labelModificar_Columna_Celulares.Enabled = false;
                labelModificar_Columna_Celulares.Visible = false;

                txtModificar_Columna_Celulares.Enabled = false;
                txtModificar_Columna_Celulares.Visible = false;

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

                labelEstado_Modificar.Enabled = true;
                labelEstado_Modificar.Visible = true;

                labelEstado_Modificar.Location = new Point(3, 80);

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

                radioButton_Arreglado_Modificar.Enabled = true;
                radioButton_Arreglado_Modificar.Visible = true;

                radioButton_Averiado_Modificar.Enabled = true;
                radioButton_Averiado_Modificar.Visible = true;

                radioButton_Arreglado_Modificar.Location = new Point(6, 96);
                radioButton_Averiado_Modificar.Location = new Point(93, 96);
            }
            else
            {
                //Modificar Columna:
                labelModificar_Columna_Celulares.Enabled = true;
                labelModificar_Columna_Celulares.Visible = true;

                txtModificar_Columna_Celulares.Enabled = true;
                txtModificar_Columna_Celulares.Visible = true;

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

                radioButton_Arreglado_Modificar.Location = new Point(6, 96);
                radioButton_Averiado_Modificar.Location = new Point(93, 96);
            }
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

                txtID_Tecnico_Trabajo_Modficar.Enabled = true;
                txtID_Tecnico_Trabajo_Modficar.Visible = true;

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

                txtID_Tecnico_Trabajo_Modficar.Enabled = false;
                txtID_Tecnico_Trabajo_Modficar.Visible = false;
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

                txtID_Tecnico_Trabajo_Modficar.Enabled = false;
                txtID_Tecnico_Trabajo_Modficar.Visible = false;
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

                txtID_Tecnico_Trabajo_Modficar.Enabled = false;
                txtID_Tecnico_Trabajo_Modficar.Visible = false;
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
                            labelError_MenuOpciones.Visible = false;
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
                            labelError_MenuOpciones.Visible = false;
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
                            labelError_MenuOpciones.Visible = false;
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
                            labelError_MenuOpciones.Visible = false;
                            labelError_MenuOpciones.Visible = false;
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
                            labelError_MenuOpciones.Visible = false;
                            labelError_MenuOpciones.Visible = false;
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
                            labelError_MenuOpciones.Visible = false;
                            labelError_MenuOpciones.Visible = false;
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
                            labelError_MenuOpciones.Visible = true;
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

                tablaCelulares.Location = new Point(124, 78);
                tablaTrabajos.Location = new Point(124, 78);
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
                tablaCelulares.Location = new Point(49, 78);
                tablaTrabajos.Location = new Point(49, 78);
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
            if (e.RowIndex >= 0)
            {
                numeroDeFilaCelulares = e.RowIndex;
                clavePrimariaCelulares = tablaCelulares.Rows[numeroDeFilaCelulares].Cells["ID"].Value.ToString();
                if (groupBox_EliminarCelulares.Height > 300)
                {
                    labMostrarIDdelCelularSeleccionado.ForeColor = Color.Black;
                    labMostrarIDdelCelularSeleccionado.Text = clavePrimariaCelulares;
                }
                else
                {
                    labMostrarIDdelCelularSeleccionado.ForeColor = Color.Brown;
                    labMostrarIDdelCelularSeleccionado.Text = "Seleccione un elemento de la tabla.";
                }
            }
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
            txtCI_Del_Dueño_Agregar.MaxLength = 8;
            try
            {
                if (txtModelo_Agregar.Text != "" && txtMarca_Agregar.Text != "" && txtCI_Del_Dueño_Agregar.Text != "" && txtID_Tecnico_Agregar_Celulares.Text != "")
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
                        ciCliente = txtCI_Del_Dueño_Agregar.Text;
                        idUsuario = int.Parse(txtID_Tecnico_Agregar_Celulares.Text);

                        insertarCelulares = "INSERT INTO celulares(Modelo, Marca, IMEI, Estado, Cedula_Cliente, ID_Usuario) VALUES('" + modelo + "', '" + marca + "', '" + imei + "', '" + estado + "', '" + ciCliente + "', " + idUsuario + ")";
                        cmd = new MySqlCommand(insertarCelulares, conn);

                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("No se ingreso correctamente el celular\n\n" + ex.Message, "Ups..", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (comboBoxColumnas_Celulares.Text.Equals("Todas..."))
            {
                //Label error:
                labelError_Modificar_Celulares.Enabled = false;
                labelError_Modificar_Celulares.Visible = false;

                //Codigo para modificar el Celular:
                if (txtModelo_Modificar.Text != "" && txtMarca_Modificar.Text != "" && txtIMEI_Modificar.Text != "" && txtCI_Del_Dueño_Modificar.Text != "" && txtTecnico_Modificar.Text != "")
                {
                    if (radioButton_Arreglado_Modificar.Checked == true || radioButton_Averiado_Modificar.Checked == true)
                    {
                        try
                        {
                            conn.Open();
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
                            ciCliente = txtCI_Del_Dueño_Modificar.Text;
                            idUsuario = int.Parse(txtTecnico_Modificar.Text);

                            modifcarCelulares = "UPDATE celulares SET Modelo = '" + modelo + "', Marca = '" + marca + "', IMEI = '" + imei + "', Estado = '" + estado + "', Cedula_Cliente = '" + ciCliente + "', ID_Usuario = " + idUsuario + " WHERE celulares.ID = " + clavePrimariaCelulares + ";";
                            cmd = new MySqlCommand(modifcarCelulares, conn);

                            try
                            {
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("No se pudo modificar el celular.\n\nCompruebe la existencia del celular y el ID del mismo." + ex.Message, "Ups..", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            else if (comboBoxColumnas_Celulares.Text.Equals("Modelo") || comboBoxColumnas_Celulares.Text.Equals("Marca") || comboBoxColumnas_Celulares.Text.Equals("IMEI") || comboBoxColumnas_Celulares.Text.Equals("Estado") || comboBoxColumnas_Celulares.Text.Equals("Cedula del dueño") || comboBoxColumnas_Celulares.Text.Equals("ID del usuario/ tecnico"))
            {
                //Label error:
                labelError_Modificar_Celulares.Enabled = false;
                labelError_Modificar_Celulares.Visible = false;

                //Codigo para modificar el celular:
                option = comboBoxColumnas_Celulares.Text;

                switch (option)
                {
                    case "Modelo":
                        if (txtModificar_Columna_Celulares.Text != "")
                        {
                            conn.Open();
                            modelo = txtModificar_Columna_Celulares.Text;
                            modifcarCelulares = "UPDATE celulares SET Modelo = '" + modelo + "' WHERE celulares.ID = " + clavePrimariaCelulares + ";";
                            cmd = new MySqlCommand(modifcarCelulares, conn);

                            try
                            {
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("No se modifico correctamente el celular\n\n" + ex.Message, "Ups..", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        break;

                    case "Marca":
                        if (txtModificar_Columna_Celulares.Text != "")
                        {
                            conn.Open();
                            marca = txtModificar_Columna_Celulares.Text;
                            modifcarCelulares = "UPDATE celulares SET Marca = '" + marca + "' WHERE celulares.ID = " + clavePrimariaCelulares + ";";
                            cmd = new MySqlCommand(modifcarCelulares, conn);

                            try
                            {
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("No se modifico correctamente el celular\n\n" + ex.Message, "Ups..", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        break;

                    case "IMEI":
                        if (txtModificar_Columna_Celulares.Text != "")
                        {
                            conn.Open();
                            imei = txtModificar_Columna_Celulares.Text;
                            modifcarCelulares = "UPDATE celulares SET IMEI = '" + imei + "' WHERE celulares.ID = " + clavePrimariaCelulares + ";";
                            cmd = new MySqlCommand(modifcarCelulares, conn);

                            try
                            {
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("No se modifico correctamente el celular\n\n" + ex.Message, "Ups..", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        break;

                    case "Estado":
                        if (radioButton_Averiado_Modificar.Checked.Equals(true) || radioButton_Arreglado_Modificar.Checked.Equals(true))
                        {
                            if (radioButton_Arreglado_Modificar.Checked)
                            {
                                estado = "Arreglado";
                            }
                            else
                            {
                                estado = "Averiado";
                            }

                            conn.Open();
                            modifcarCelulares = "UPDATE celulares SET Estado = '" + estado + "' WHERE celulares.ID = " + clavePrimariaCelulares + ";";
                            cmd = new MySqlCommand(modifcarCelulares, conn);

                            try
                            {
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("No se modifico correctamente el celular\n\n" + ex.Message, "Ups..", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        break;

                    case "Cedula del dueño":
                        if (txtModificar_Columna_Celulares.Text != "")
                        {
                            conn.Open();
                            ciCliente = txtModificar_Columna_Celulares.Text;
                            modifcarCelulares = "UPDATE celulares SET Cedula_Cliente = '" + ciCliente + "' WHERE celulares.ID = " + clavePrimariaCelulares + ";";
                            cmd = new MySqlCommand(modifcarCelulares, conn);

                            try
                            {
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("No se modifico correctamente el celular\n\n" + ex.Message, "Ups..", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        break;

                    case "ID del usuario/tecnico":
                        if (txtModificar_Columna_Celulares.Text != "")
                        {
                            conn.Open();
                            idUsuario = int.Parse(txtModificar_Columna_Celulares.Text);
                            modifcarCelulares = "UPDATE celulares SET ID_Usuario = " + idUsuario + " WHERE celulares.ID = " + clavePrimariaCelulares + ";";
                            cmd = new MySqlCommand(modifcarCelulares, conn);

                            try
                            {
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("No se modifico correctamente el celular\n\n" + ex.Message, "Ups..", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        break;

                    default:
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

                        labelModificar_Columna_Celulares.Enabled = false;
                        labelModificar_Columna_Celulares.Visible = false;

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

                        txtModificar_Columna_Celulares.Enabled = false;
                        txtModificar_Columna_Celulares.Visible = false;
                        break;
                }
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

                labelModificar_Columna_Celulares.Enabled = false;
                labelModificar_Columna_Celulares.Visible = false;

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

                txtModificar_Columna_Celulares.Enabled = false;
                txtModificar_Columna_Celulares.Visible = false;
            }
        }

        private void btnEliminar_Celular_Click(object sender, EventArgs e)
        {

        
            
            try
            {
                conn.Open();
                eliminarCelulares = "UPDATE celulares SET Baja = 0 WHERE ID = " + idCelular + ";";
                cmd = new MySqlCommand(eliminarCelulares, conn);

                try
                {
                    cmd.ExecuteNonQuery();
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
            catch (Exception ex)
            {
                MessageBox.Show("Fallo la conexion con el servidor o la base de datos\n\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        


    }








    private void btnAgregar_Trabajo_Click(object sender, EventArgs e)
    {
        if (txtPresupuesto_Agregar.Text != "" && txtProblema_Agregar.Text != "" && dateTimePicker_FechaDeIngreso_Agregar.Value != null && txtID_Trabajo_Agregar.Text != "" || txtID_Tecnico_Agregar_Trabajos.Text != "")
        {
            try
            {
                conn.Open();
                idCelular = int.Parse(txtID_Trabajo_Agregar.Text);
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
                tecnicoACargo = int.Parse(txtID_Tecnico_Agregar_Trabajos.Text);

                insertarTrabajos = "INSERT INTO Trabajos(ID_Tecnico, Plazo, Presupuesto, Problema, Fecha_Ingreso, Adelanto, ID_Celular) VALUES(" + tecnicoACargo + ",'" + stringPlazo + "', " + presupuesto + ", '" + problema + "', '" + stringFechaIngreso + "', " + adelanto + ", " + idCelular + ")";
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
        if (comboBoxColumnas_Trabajos.Text.Equals("Todas..."))
        {
            //Label de error:
            labelError_Modificar_Trabajos.Enabled = false;
            labelError_Modificar_Trabajos.Visible = false;

            //Codigo para modificar el Trabajos:
            if (txtTrabajo_ID_Modificar.Text != "" && dateTimePicker_Plazo_Modificar.Value != null && txtPresupuesto_Modificar.Text != "" && txtProblema_Modificar.Text != "" && dateTimePicker_FechaDeIngreso_Modificar.Value != null && txtAdelanto_Modificar.Text != null)
            {
                try
                {
                    conn.Open();
                    tecnicoACargo = int.Parse(txtID_Tecnico_Trabajo_Modficar.Text);
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

        else if (comboBoxColumnas_Trabajos.Text.Equals("Adelanto") || comboBoxColumnas_Trabajos.Text.Equals("Plazo") || comboBoxColumnas_Trabajos.Text.Equals("Presupuesto") || comboBoxColumnas_Trabajos.Text.Equals("Problema") || comboBoxColumnas_Trabajos.Text.Equals("Fecha de ingreso") || comboBoxColumnas_Trabajos.Text.Equals("ID del celular") || comboBoxColumnas_Trabajos.Text.Equals("ID del tecnico"))
        {
            labelError_Modificar_Trabajos.Enabled = false;
            labelError_Modificar_Trabajos.Visible = false;

            option = comboBoxColumnas_Trabajos.Text;

            switch (option)
            {
                case "Plazo":
                    if (dateTimePicker_Plazo_Modificar.Value != null)
                    {
                        conn.Open();
                        plazo = dateTimePicker_Plazo_Modificar.Value;
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

                        modifcarTrabajos = "UPDATE trabajos SET Plazo = '" + stringPlazo + "' WHERE trabajos.ID = " + clavePrimariaTrabajos + ";";
                        cmd = new MySqlCommand(modifcarTrabajos, conn);

                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("No se modifico correctamente el trabajo\n\n" + ex.Message, "Ups..", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    break;

                case "Presupuesto":
                    if (txtModificar_Columna_Trabajos.Text != "")
                    {
                        conn.Open();
                        presupuesto = int.Parse(txtModificar_Columna_Trabajos.Text);

                        modifcarTrabajos = "UPDATE trabajos SET Presupuesto = " + presupuesto + " WHERE trabajos.ID = " + clavePrimariaTrabajos + ";";
                        cmd = new MySqlCommand(modifcarTrabajos, conn);

                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("No se modifico correctamente el trabajo\n\n" + ex.Message, "Ups..", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    break;

                case "Problema":
                    if (txtModificar_Columna_Trabajos.Text != "")
                    {
                        conn.Open();
                        problema = txtModificar_Columna_Trabajos.Text;

                        modifcarTrabajos = "UPDATE trabajos SET Problema = '" + problema + "' WHERE trabajos.ID = " + clavePrimariaTrabajos + ";";
                        cmd = new MySqlCommand(modifcarTrabajos, conn);

                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("No se modifico correctamente el trabajo\n\n" + ex.Message, "Ups..", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    break;

                case "Fecha de ingreso":
                    if (dateTimePicker_FechaDeIngreso_Modificar.Value != null)
                    {
                        conn.Open();
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

                        modifcarTrabajos = "UPDATE trabajos SET Fecha_Ingreso = '" + stringFechaIngreso + "' WHERE trabajos.ID = " + clavePrimariaTrabajos + ";";
                        cmd = new MySqlCommand(modifcarTrabajos, conn);

                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("No se modifico correctamente el trabajo\n\n" + ex.Message, "Ups..", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    break;
                case "Adelanto":
                    if (txtModificar_Columna_Trabajos.Text != "")
                    {
                        conn.Open();
                        adelanto = int.Parse(txtModificar_Columna_Trabajos.Text);

                        modifcarTrabajos = "UPDATE trabajos SET Adelanto = " + adelanto + " WHERE trabajos.ID = " + clavePrimariaTrabajos + ";";
                        cmd = new MySqlCommand(modifcarTrabajos, conn);

                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("No se modifico correctamente el trabajo\n\n" + ex.Message, "Ups..", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    break;

                case "ID del celular":
                    if (txtModificar_Columna_Trabajos.Text != "")
                    {
                        conn.Open();
                        idCelular = int.Parse(txtModificar_Columna_Trabajos.Text);

                        modifcarTrabajos = "UPDATE trabajos SET ID_Celular = " + idCelular + " WHERE trabajos.ID = " + clavePrimariaTrabajos + ";";
                        cmd = new MySqlCommand(modifcarTrabajos, conn);

                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("No se modifico correctamente el trabajo\n\n" + ex.Message, "Ups..", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    break;
                case "ID del tecnico":
                    if (txtModificar_Columna_Trabajos.Text != "")
                    {
                        conn.Open();
                        tecnicoACargo = int.Parse(txtModificar_Columna_Trabajos.Text);

                        modifcarTrabajos = "UPDATE trabajos SET ID_Tecnico = " + tecnicoACargo + " WHERE trabajos.ID = " + clavePrimariaTrabajos + ";";
                        cmd = new MySqlCommand(modifcarTrabajos, conn);

                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("No se modifico correctamente el trabajo\n\n" + ex.Message, "Ups..", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    break;
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
                eliminarTrabajos = "UPDATE trabajos SET Baja = 0 WHERE ID = " + idTrabajo + ";";
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

    private void radioButton_TablaTrabajo_CheckedChanged(object sender, EventArgs e)
    {
        AyudaVisual_Tabla_Mostrar();
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

    /// <summary>
    /// Esta parte del código es para la personalización programática para el cargar visualmente bien de las tablas.
    /// </summary>

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
            tablaCelulares.Columns["IMEI"].Width = longitudDeColumna_LargaL;
            tablaCelulares.Columns["Modelo"].Width = lonigtudDeColumna_Larga;
            tablaCelulares.Columns["ID_Usuario"].Width = 73;

            //Renombre de columnas, más que nada es estético.
            tablaCelulares.Columns["Cedula_Cliente"].HeaderText = "Cédula";
            tablaCelulares.Columns["ID_Usuario"].HeaderText = "Técnico";

            //Tooltips al posar el mouse
            tablaCelulares.Columns["ID"].ToolTipText = "Número identificatorio para cada celular en esta tabla";
            tablaCelulares.Columns["Marca"].ToolTipText = "La marca del teléfono";
            tablaCelulares.Columns["Modelo"].ToolTipText = "El modelo del teléfono";
            tablaCelulares.Columns["IMEI"].ToolTipText = "El número único identificatorio para cada dispositivo, normalmente viene detrás de este como una pegatina";
            tablaCelulares.Columns["Estado"].ToolTipText = "El estado en el que está actualmente el celular";
            tablaCelulares.Columns["Cedula_Cliente"].ToolTipText = "La cédula del dueño del teléfono";
            tablaCelulares.Columns["ID_Usuario"].ToolTipText = "El ID del Técnico a cargo del teléfono";
        }
    }

    //Que se cague, no más de 8 caracteres, que es lo que sería la cédula sin los puntos ni el guión.
    private void txtCI_Del_Dueño_Agregar_TextChanged(object sender, EventArgs e)
    {
        if (txtCI_Del_Dueño_Agregar.Text.Length <= 8 && txtCI_Del_Dueño_Agregar.Text.Length > 0)
        {
            label_CaracteresRestantesCI_AgregarCelulares.Visible = true;
            int caracteresRestantes = 8 - txtCI_Del_Dueño_Agregar.TextLength;
            label_CaracteresRestantesCI_AgregarCelulares.Text = "Caracteres Restantes: " + caracteresRestantes + "/8";
        }
        else
        {
            label_CaracteresRestantesCI_AgregarCelulares.Visible = false;
        }
    }

    private void ToolTips_de_los_Campos_de_Texto(object sender, EventArgs e)
    {

    }
}
}