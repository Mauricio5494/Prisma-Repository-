using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Security;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Diseño
{
    public partial class Clientes : Form
    {
        //Atributos o variables:
        string opcion;
        string clavePrimaria;
        int numeroDeFila;
        string cedula;
        string nombre;
        string telefono;
        string correoElectronico;
        string celular;
        string insertar;
        string modificar;
        string columna;
        string option;
        string busqueda;
        string transicion;
        bool drag;
        int mouseStartX, mouseStartY;

        //Instancias:
        Principal Taller = new Principal();
        Usuarios Usuarios = new Usuarios();
        Estadisticas Estadisticas = new Estadisticas();
        MySqlConnection conn = DataBaseConnect.Conectarse();
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataAdapter adapter = new MySqlDataAdapter();
        MySqlDataReader reader;
        DataTable DataTable = new DataTable();
        Utilidades Seguridad = new Utilidades();

        public Clientes()
        {
            InitializeComponent();

            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        private void Clientes_Load(object sender, EventArgs e)
        {
            transicion = "FadeIn";
            timer_Transicion.Start();

            MostrarDatosEnLaTablaClientes();
        }

        private void MostrarDatosEnLaTablaClientes()
        {
            try
            {
                DataTable.Rows.Clear();
                conn.Open();
                cmd = new MySqlCommand("SELECT Cedula, Nombre, Telefono, CorreoElectronico, Celular FROM clientes WHERE Baja = 0;", conn);
                cmd.CommandType = System.Data.CommandType.Text;
                reader = cmd.ExecuteReader();
                DataTable.Load(reader);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fallo la conexion con el servidor o la base de datos\n\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
            tablaClientes.DataSource = DataTable;
        }
        private void MostrarDatosEnLaTablaClientes_SinMensajeDeError()
        {
            try
            {
                DataTable.Rows.Clear();
                conn.Open();
                cmd = new MySqlCommand("SELECT Cedula, Nombre, Telefono, CorreoElectronico, Celular FROM clientes WHERE Baja = 0;", conn);
                cmd.CommandType = System.Data.CommandType.Text;
                reader = cmd.ExecuteReader();
                DataTable.Load(reader);
            }
            catch
            {

            }
            finally
            {
                conn.Close();
            }
            tablaClientes.DataSource = DataTable;
        }

        private void MenuOpcionesClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!txtCampo_Busqueda.Enabled)
            {
                txtCampo_Busqueda.Enabled = true;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtCampo_Busqueda.Text != "")
            {
                opcion = MenuOpcionesClientes.Text;

                switch (opcion)
                {
                    case "Cedula":
                        try
                        {
                            DataTable.Rows.Clear();
                            conn.Open();
                            cmd = new MySqlCommand("SELECT Cedula, Nombre, Telefono, CorreoElectronico, Celular FROM clientes WHERE Baja = 1 AND Cedula ='" + txtCampo_Busqueda.Text + "';", conn);
                            cmd.CommandType = System.Data.CommandType.Text;
                            reader = cmd.ExecuteReader();
                            DataTable.Load(reader);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Fallo la conexion con el servidor o la base de datos\n\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            conn.Close();
                        }
                        tablaClientes.DataSource = DataTable;
                        break;

                    case "Nombre":
                        try
                        {
                            DataTable.Rows.Clear();
                            conn.Open();
                            cmd = new MySqlCommand("SELECT Cedula, Nombre, Telefono, CorreoElectronico, Celular FROM clientes WHERE Baja =1 AND Nombre ='" + txtCampo_Busqueda.Text + "';", conn);
                            cmd.CommandType = System.Data.CommandType.Text;
                            reader = cmd.ExecuteReader();
                            DataTable.Load(reader);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Fallo la conexion con el servidor o la base de datos\n\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            conn.Close();
                        }
                        tablaClientes.DataSource = DataTable;
                        break;

                    case "Telefono":
                        try
                        {
                            DataTable.Rows.Clear();
                            conn.Open();
                            cmd = new MySqlCommand("SELECT Cedula, Nombre, Telefono, CorreoElectronico, Celular FROM clientes WHERE Baja = 1 AND Telefono ='" + txtCampo_Busqueda.Text + "';", conn);
                            cmd.CommandType = System.Data.CommandType.Text;
                            reader = cmd.ExecuteReader();
                            DataTable.Load(reader);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Fallo la conexion con el servidor o la base de datos\n\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            conn.Close();
                        }
                        tablaClientes.DataSource = DataTable;
                        break;

                    case "Correo electronico":
                        try
                        {
                            DataTable.Rows.Clear();
                            conn.Open();
                            cmd = new MySqlCommand("SELECT Cedula, Nombre, Telefono, CorreoElectronico, Celular FROM clientes WHERE Baja =1 AND CorreoElectronico ='" + txtCampo_Busqueda.Text + "';", conn);
                            cmd.CommandType = System.Data.CommandType.Text;
                            reader = cmd.ExecuteReader();
                            DataTable.Load(reader);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Fallo la conexion con el servidor o la base de datos\n\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            conn.Close();
                        }
                        tablaClientes.DataSource = DataTable;
                        break;

                    case "Celular":
                        try
                        {
                            DataTable.Rows.Clear();
                            conn.Open();
                            cmd = new MySqlCommand("SELECT Cedula, Nombre, Telefono, CorreoElectronico, Celular FROM clientes WHERE Baja = 1 AND Celular = '" + txtCampo_Busqueda.Text + "';", conn);
                            cmd.CommandType = System.Data.CommandType.Text;
                            reader = cmd.ExecuteReader();
                            DataTable.Load(reader);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Fallo la conexion con el servidor o la base de datos\n\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            conn.Close();
                        }
                        tablaClientes.DataSource = DataTable;
                        break;
                }
            }
            else
            {
                MessageBox.Show("Antes de buscar escriba algo en el campo", "Alto!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        //Botones del menu lateral:
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (panel_Agregar.Height < 600)
            {
                //panel Agregar:
                timerAgregar_Agrandar.Enabled = true;
                timerAgregar_Reducir.Enabled = false;

                //panel Modificar:
                timer_Modificar_Agrandar.Enabled = false;
                timer_Modificar_Reducir.Enabled = true;

                //panel Eliminar:
                timer_Eliminar_Agrandar.Enabled = false;
                timer_Eliminar_Reducir.Enabled = true;

                //panel Menu:
                timer_Menu_Agrandar.Enabled = false;
                timer_Menu_Reducir.Enabled = true;
            }
            else
            {
                //Panel Agregar:
                timerAgregar_Agrandar.Enabled = false;
                timerAgregar_Reducir.Enabled = true;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (panel_Modificar.Height < 600)
            {
                //panel Modificar:
                timer_Modificar_Agrandar.Enabled = true;
                timer_Modificar_Reducir.Enabled = false;

                //panel Agregar:
                timerAgregar_Agrandar.Enabled = false;
                timerAgregar_Reducir.Enabled = true;

                //panel Eliminar:
                timer_Eliminar_Agrandar.Enabled = false;
                timer_Eliminar_Reducir.Enabled = true;

                //panel Menu:
                timer_Menu_Agrandar.Enabled = false;
                timer_Menu_Reducir.Enabled = true;
            }
            else
            {
                timer_Modificar_Agrandar.Enabled = false;
                timer_Modificar_Reducir.Enabled = true;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (panel_Eliminar.Height < 600)
            {
                //panel Eliminar:
                timer_Eliminar_Agrandar.Enabled = true;
                timer_Eliminar_Reducir.Enabled = false;

                //panel Agregar:
                timerAgregar_Agrandar.Enabled = false;
                timerAgregar_Reducir.Enabled = true;

                //panel Modificar:
                timer_Modificar_Agrandar.Enabled = false;
                timer_Modificar_Reducir.Enabled = true;

                //panel Menu:
                timer_Menu_Agrandar.Enabled = false;
                timer_Menu_Reducir.Enabled = true;
            }
            else
            {
                timer_Eliminar_Agrandar.Enabled = false;
                timer_Eliminar_Reducir.Enabled = true;
            }
        }

        private void btnMenuPrincipal_Click(object sender, EventArgs e)
        {
            if (panel_Menu.Height < 600)
            {
                //panel Menu:
                timer_Menu_Agrandar.Enabled = true;
                timer_Menu_Reducir.Enabled = false;

                //panel Agregar:
                timerAgregar_Agrandar.Enabled = false;
                timerAgregar_Reducir.Enabled = true;

                //panel Modificar:
                timer_Modificar_Agrandar.Enabled = false;
                timer_Modificar_Reducir.Enabled = true;

                //panel Eliminar:
                timer_Eliminar_Agrandar.Enabled = false;
                timer_Eliminar_Reducir.Enabled = true;
            }
            else
            {
                timer_Menu_Agrandar.Enabled = false;
                timer_Menu_Reducir.Enabled = true;
            }
        }

        private void btnRecargar_Click(object sender, EventArgs e)
        {
            MostrarDatosEnLaTablaClientes();
        }

        private void tablaClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                numeroDeFila = e.RowIndex;
                clavePrimaria = tablaClientes.Rows[numeroDeFila].Cells["Cedula"].Value.ToString();
                if (panel_Eliminar.Height == 600)
                {
                    txtCI_Eliminar.Text = clavePrimaria.ToString();
                }

                txtCedula_Modificar.Text = tablaClientes.Rows[numeroDeFila].Cells["Cedula"].Value.ToString();
                txtNombre_Modificar.Text = tablaClientes.Rows[numeroDeFila].Cells["Nombre"].Value.ToString();
                txtTelefono_Modificar.Text = tablaClientes.Rows[numeroDeFila].Cells["Telefono"].Value.ToString();
                txtCorreoElectronico_Modificar.Text = tablaClientes.Rows[numeroDeFila].Cells["CorreoElectronico"].Value.ToString();
                txtCelular_Modificar.Text = tablaClientes.Rows[numeroDeFila].Cells["Celular"].Value.ToString();
            }

            labelSeleccion_Modificar.Text = "Selección: " + clavePrimaria.ToString();
        }

        //Botones con sentencias SQL:
        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            if (txtCedula_Agregar.Text != "" && txtNombre_Agregar.Text != "" && txtCelular_Agregar.Text != "")
            {
                cedula = txtCedula_Agregar.Text;
                nombre = txtNombre_Agregar.Text;
                telefono = txtTelefono_Agregar.Text;
                correoElectronico = txtCorreoElectronico_Agregar.Text;
                celular = txtCelular_Agregar.Text;

                insertar = $"INSERT INTO clientes(Cedula, Nombre, Telefono, CorreoElectronico, Celular, Baja) VALUES ('{cedula}', '{nombre}', '{telefono}', '{correoElectronico}', '{celular}', '0')";

                try
                {
                    conn.Open();
                    cmd = new MySqlCommand(insertar, conn);
                    try
                    {
                        cmd.ExecuteNonQuery();

                        txtCedula_Agregar.Text = "";
                        txtNombre_Agregar.Text = "";
                        txtTelefono_Agregar.Text = "";
                        txtCorreoElectronico_Agregar.Text = "";
                        txtCelular_Agregar.Text = "";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se agrego correctamente el cliente\n\n" + ex.Message, "Ups..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Fallo la conexion con el servidor o la base de datos\n\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    conn.Close();
                    MostrarDatosEnLaTablaClientes();
                }
            }
            else
            {
                MessageBox.Show("No deje un campo de texto obligatorio en blanco", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnModificarCliente_Click(object sender, EventArgs e)
        {
            if (txtCedula_Modificar.Text != "" && txtNombre_Modificar.Text != "" && txtTelefono_Modificar.Text != "" && txtCorreoElectronico_Modificar.Text != "" && txtCedula_Modificar.Text != "")
            {

                cedula = txtCedula_Modificar.Text;
                nombre = txtNombre_Modificar.Text;
                telefono = txtTelefono_Modificar.Text;
                correoElectronico = txtCorreoElectronico_Modificar.Text;
                celular = txtCelular_Modificar.Text;
                try
                {
                    conn.Open();
                    modificar = $"UPDATE clientes SET Cedula = @Cedula, Nombre = @Nombre, Telefono = @Telefono, Celular = @Celular, CorreoElectronico = @CorreoElectronico WHERE Cedula = @Claveprimaria";
                    cmd = new MySqlCommand(modificar, conn);


                    cmd.Parameters.AddWithValue("@Cedula", cedula);
                    cmd.Parameters.AddWithValue("@Nombre", nombre);
                    cmd.Parameters.AddWithValue("@Telefono", telefono);
                    cmd.Parameters.AddWithValue("@Celular", celular);
                    cmd.Parameters.AddWithValue("@CorreoElectronico", correoElectronico);
                    cmd.Parameters.AddWithValue("@Claveprimaria", clavePrimaria);

                    try
                    {
                        cmd.ExecuteNonQuery();

                        txtCedula_Modificar.Text = "";
                        txtNombre_Modificar.Text = "";
                        txtTelefono_Modificar.Text = "";
                        txtCorreoElectronico_Modificar.Text = "";
                        txtCelular_Modificar.Text = "";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se modifico correctamente el cliente\n\n" + ex.Message, "Ups..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Fallo la conexion con el servidor o la base de datos\n\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    conn.Close();
                    MostrarDatosEnLaTablaClientes();
                }
            }
            else
            {
                MessageBox.Show("No deje un campo de texto obligatorio en blanco", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

        }

        private void btnEliminarCliente_Click(object sender, EventArgs e)
        {
            if (txtCI_Eliminar.Text != "")
            {
                cedula = txtCI_Eliminar.Text;

                modificar = "UPDATE clientes SET Baja = 1 WHERE Cedula = '" + cedula + "';";

                try
                {
                    conn.Open();
                    cmd = new MySqlCommand(modificar, conn);
                    try
                    {
                        cmd.ExecuteNonQuery();
                        txtCI_Eliminar.Text = "";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se modifico correctamente el cliente\n\n" + ex.Message, "Ups..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Fallo la conexion con el servidor o la base de datos\n\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    conn.Close();
                    MostrarDatosEnLaTablaClientes();
                }
            }
            else
            {
                MessageBox.Show("Seleccione o escriba la cedula del cliente que desea eliminar", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
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

                //tablaClientes.Location = new Point(124, 78);
                if (panel_Agregar.Visible == true)
                {
                    panel_Agregar.SendToBack();
                }
                else if (panel_Modificar.Visible)
                {
                    panel_Modificar.SendToBack();
                }
                else if (panel_Eliminar.Visible)
                {
                    panel_Eliminar.SendToBack();
                }
                else if (panel_Menu.Visible)
                {
                    panel_Menu.SendToBack();
                }
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
                //tablaClientes.Location = new Point(49, 78);
            }
        }

        //timers:
        private void timerAgregar_Agrandar_Tick(object sender, EventArgs e)
        {
            if (panel_Agregar.Height < 600)
            {
                panel_Agregar.Height = panel_Agregar.Height + 12;
                panel_Agregar.Enabled = true;
                panel_Agregar.BringToFront();
            }
            else
            {
                timerAgregar_Agrandar.Enabled = false;
            }
        }

        private void timerAgregar_Reducir_Tick(object sender, EventArgs e)
        {
            if (panel_Agregar.Height > 0)
            {
                panel_Agregar.Height = panel_Agregar.Height - 12;
                panel_Agregar.Enabled = false;
                panel_Agregar.SendToBack();
            }
            else
            {
                timerAgregar_Reducir.Enabled = false;
            }
        }

        private void timer_Modificar_Agrandar_Tick(object sender, EventArgs e)
        {
            if (panel_Modificar.Height < 600)
            {
                panel_Modificar.Height = panel_Modificar.Height + 12;
                panel_Modificar.Enabled = true;
                panel_Agregar.BringToFront();
            }
            else
            {
                timer_Modificar_Agrandar.Enabled = false;
            }
        }

        private void timer_Modificar_Reducir_Tick(object sender, EventArgs e)
        {
            if (panel_Modificar.Height > 0)
            {
                panel_Modificar.Height = panel_Modificar.Height - 12;
                panel_Modificar.Enabled = false;
                panel_Modificar.SendToBack();
            }
            else
            {
                timer_Modificar_Reducir.Enabled = false;
            }
        }

        private void timer_Eliminar_Agrandar_Tick(object sender, EventArgs e)
        {
            if (panel_Eliminar.Height < 600)
            {
                panel_Eliminar.Height = panel_Eliminar.Height + 12;
                panel_Eliminar.Enabled = true;
                panel_Eliminar.BringToFront();
            }
            else
            {
                timer_Eliminar_Agrandar.Enabled = false;
            }
        }

        private void timer_Eliminar_Reducir_Tick(object sender, EventArgs e)
        {
            if (panel_Eliminar.Height > 0)
            {
                panel_Eliminar.Height = panel_Eliminar.Height - 12;
                panel_Eliminar.Enabled = false;
                panel_Eliminar.SendToBack();
            }
            else
            {
                timer_Eliminar_Reducir.Enabled = false;
            }
        }

        private void timer_Menu_Agrandar_Tick(object sender, EventArgs e)
        {
            if (panel_Menu.Height < 600)
            {
                panel_Menu.Height = panel_Menu.Height + 12;
                panel_Menu.Enabled = true;
                panel_Menu.BringToFront();
            }
            else
            {
                timer_Menu_Agrandar.Enabled = false;
            }
        }

        private void timer_Menu_Reducir_Tick(object sender, EventArgs e)
        {
            if (panel_Menu.Height > 0)
            {
                panel_Menu.Height = panel_Menu.Height - 12;
                panel_Menu.Enabled = false;
                panel_Menu.SendToBack();
            }
            else
            {
                timer_Menu_Reducir.Enabled = false;
            }
        }


        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Seguridad.SetInvitado = true;
            conn.Close();

            DialogResult siono = MessageBox.Show("¿Está seguro de Cerrar la Sesión?", "Hmm...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (siono == DialogResult.Yes)
            {
                transicion = "FadeOut";
                timer_Transicion.Start();

                Application.Restart();
            }
        }

        private void btnTaller_Click(object sender, EventArgs e)
        {
            transicion = "FadeOutTaller";
            timer_Transicion.Start();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            Usuarios.Show();
            this.Hide();
        }

        private void btnEstadisticas_Click(object sender, EventArgs e)
        {
            Estadisticas.Show();
            this.Hide();
        }

        private void txtCampo_Busqueda_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void Clientes_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void tablaClientes_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (tablaClientes.Columns.Contains("Cedula"))
            {
                //Largo de las columnas

                tablaClientes.Columns["Cedula"].Width = 100;
                tablaClientes.Columns["Nombre"].Width = 185;
                tablaClientes.Columns["Telefono"].Width = 100;
                tablaClientes.Columns["CorreoElectronico"].Width = 235;
                tablaClientes.Columns["Celular"].Width = 200;


                //Renombre de columnas, más que nada es estético.
                tablaClientes.Columns["Telefono"].HeaderText = "Teléfono fijo";
                tablaClientes.Columns["Nombre"].HeaderText = "Nombre y Apellido";
                tablaClientes.Columns["CorreoElectronico"].HeaderText = "Correo Electrónico";
                tablaClientes.Columns["Celular"].HeaderText = "Celular provicional";

                //Tooltips al posar el mouse
                tablaClientes.Columns["Cedula"].ToolTipText = "Cédula de identidad del cliente, necesaria para identificar los dueños de los celulares en el taller";
                tablaClientes.Columns["Nombre"].ToolTipText = "Nombre de pila y apellido del cliente";
                tablaClientes.Columns["Telefono"].ToolTipText = "Teléfono fijo, como forma de contactar al cliente.";
                tablaClientes.Columns["CorreoElectronico"].ToolTipText = "El E-Mail del cliente, otra forma de contactar con el mismo (Menos probable que te contesten).";
                tablaClientes.Columns["Celular"].ToolTipText = "Número de celular el cuál no sea el del celular que está para arreglar, sino otro con el cual contractar al cliente.";
            }
        }

        private void timer_RecargarBD_Tick(object sender, EventArgs e)
        {
            MostrarDatosEnLaTablaClientes_SinMensajeDeError();
        }


        private void txtCampo_Busqueda_TextChanged(object sender, EventArgs e)
        {


            if (txtCampo_Busqueda.Text.Equals(""))
            {
                MostrarDatosEnLaTablaClientes_SinMensajeDeError();
            }
            else
            {
                option = MenuOpcionesClientes.Text;
                switch (option)
                {
                    case "Cedula":

                        DataTable.Clear();
                        try
                        {
                            conn.Open();
                            busqueda = $"SELECT Cedula, nombre, telefono, correoelectronico, celular FROM clientes WHERE Baja = 0 AND Cedula LIKE '%{txtCampo_Busqueda.Text}%'";


                            cmd = new MySqlCommand(busqueda, conn);
                            cmd.CommandType = System.Data.CommandType.Text;
                            reader = cmd.ExecuteReader();
                            DataTable.Load(reader);
                        }
                        catch (Exception x)
                        {
                            MessageBox.Show("Ocurrio un error inesperado durante la busqueda\n\n" + x.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            conn.Close();
                        }
                        tablaClientes.DataSource = DataTable;
                        break;

                    case "Nombre":

                        DataTable.Rows.Clear();
                        try
                        {
                            conn.Open();
                            busqueda = $"SELECT Cedula, nombre, telefono, correoelectronico, celular FROM clientes WHERE Baja = 0 AND nombre LIKE '%{txtCampo_Busqueda.Text}%'";
                            cmd = new MySqlCommand(busqueda, conn);
                            cmd.CommandType = System.Data.CommandType.Text;
                            reader = cmd.ExecuteReader();
                            DataTable.Load(reader);
                        }
                        catch (Exception x)
                        {
                            MessageBox.Show("Ocurrio un error inesperado durante la busquedas\n\n" + x.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            conn.Close();
                        }
                        tablaClientes.DataSource = DataTable;
                        break;

                    case "Telefono":

                        DataTable.Rows.Clear();
                        try
                        {
                            conn.Open();
                            busqueda = $"SELECT Cedula, nombre, telefono, correoelectronico, celular FROM clientes WHERE Baja = 0 AND telefono LIKE '%{txtCampo_Busqueda.Text}%'";

                            cmd = new MySqlCommand(busqueda, conn);
                            cmd.CommandType = System.Data.CommandType.Text;
                            reader = cmd.ExecuteReader();
                            DataTable.Load(reader);
                        }
                        catch (Exception x)
                        {
                            MessageBox.Show("Ocurrio un error inesperado durante la busqueda\n\n" + x.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            conn.Close();
                        }
                        tablaClientes.DataSource = DataTable;
                        break;

                    case "Correo Electrónico":

                        DataTable.Rows.Clear();
                        try
                        {
                            conn.Open();
                            busqueda = $"SELECT Cedula, nombre, telefono, correoelectronico, celular FROM clientes WHERE Baja = 0 AND correoelectronico LIKE '%{txtCampo_Busqueda.Text}%'";

                            cmd = new MySqlCommand(busqueda, conn);
                            cmd.CommandType = System.Data.CommandType.Text;
                            reader = cmd.ExecuteReader();
                            DataTable.Load(reader);
                        }
                        catch (Exception x)
                        {
                            MessageBox.Show("Ocurrio un error inesperado durante la busqueda\n\n" + x.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            conn.Close();
                        }
                        tablaClientes.DataSource = DataTable;
                        break;

                    case "Celular":

                        DataTable.Rows.Clear();
                        try
                        {
                            conn.Open();
                            busqueda = $"SELECT Cedula, nombre, telefono, correoelectronico, celular FROM clientes WHERE Baja = 0 AND celular LIKE '%{txtCampo_Busqueda.Text}%'";

                            cmd = new MySqlCommand(busqueda, conn);
                            cmd.CommandType = System.Data.CommandType.Text;
                            reader = cmd.ExecuteReader();
                            DataTable.Load(reader);
                        }
                        catch (Exception x)
                        {
                            MessageBox.Show("Ocurrio un error inesperado durante la busqueda\n\n" + x.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            conn.Close();
                        }
                        tablaClientes.DataSource = DataTable;
                        break;

                    default:

                        break;
                }
            }
        }

        private void txtCedula_Agregar_TextChanged(object sender, EventArgs e)
        {
            int caracteresRestantes = Math.Max(0, 8 - txtCedula_Agregar.TextLength);

            label_CaracteresRestantesCI_AgregarCelulares.Visible = true;
            label_CaracteresRestantesCI_AgregarCelulares.Text = caracteresRestantes + "/8";
        }
        private void txtCedula_Agregar_KeyPress(object sender, KeyPressEventArgs e)
        {
            int caracteresRestantes = 8;

            if (txtCedula_Agregar.Text.Length >= caracteresRestantes && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void tablaClientes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                MostrarDatosEnLaTablaClientes();
            }
        }

        private void txtCelular_Agregar_TextChanged(object sender, EventArgs e)
        { 
            int caracteresRestantes = Math.Max(0, 9 - txtCelular_Agregar.TextLength);

            labCaracteresRestantesCelular.Visible = true;
            labCaracteresRestantesCelular.Text = caracteresRestantes + "/9";
        }

        private void txtCelular_Agregar_KeyPress(object sender, KeyPressEventArgs e)
        {
            int caracteresRestantes = 9;

            if (txtCelular_Agregar.Text.Length >= caracteresRestantes && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }


        private void labCaracteresRestantesCelular_TextChanged(object sender, EventArgs e)
        {
            if (labCaracteresRestantesCelular.Text == "0/9")
            {
                labCaracteresRestantesCelular.ForeColor = Color.Red;
            }
            else
            {
                labCaracteresRestantesCelular.ForeColor = Color.Black;
            }
        }

        private void label_CaracteresRestantesCI_AgregarCelulares_TextChanged(object sender, EventArgs e)
        {
            if (label_CaracteresRestantesCI_AgregarCelulares.Text == "0/8")
            {
                label_CaracteresRestantesCI_AgregarCelulares.ForeColor = Color.Red;
            }
            else
            {
                label_CaracteresRestantesCI_AgregarCelulares.ForeColor = Color.Black;
            }
        }

        private void timer_Transicion_Tick(object sender, EventArgs e)
        {
            if (transicion == "FadeIn")
            {
                if (this.Opacity == 1)
                {
                    timer_Transicion.Stop();
                }
                else
                {
                    this.Opacity += .15;
                }
            }
            if (transicion == "FadeOut")
            {
                if (this.Opacity == 0)
                {
                    timer_Transicion.Stop();
                }
                else
                {
                    if (this.WindowState == FormWindowState.Normal)
                    {
                        this.Opacity -= .15;
                        this.Left -= 15;
                        this.Hide();
                    }
                    else
                    {
                        this.Opacity -= .15;
                        this.Hide();
                    }
                }
            }
            if (transicion == "FadeOutTaller")
            {
                if (this.Opacity == 0)
                {
                    timer_Transicion.Stop();

                }
                else
                {
                    if (this.WindowState == FormWindowState.Normal)
                    {
                        this.Left = this.Left + 10;
                        this.Opacity -= .15;
                        Taller.Show();
                        this.Hide();
                    }
                    else
                    {
                        this.Opacity -= .15;
                        Taller.Show();
                        this.Hide();
                    }
                }
            }
            if (transicion == "FadeOutUsuarios")
            {
                if (this.Opacity == 1)
                {
                    timer_Transicion.Stop();
                }
                else
                {

                    if (this.WindowState == FormWindowState.Normal)
                    {
                        this.Left = this.Left + 10;
                        this.Opacity -= .15;
                        Usuarios.Show();
                        this.Hide();
                    }
                    else
                    {
                        this.Opacity -= .15;
                        Usuarios.Show();
                        this.Hide();
                    }
                }
            }
            if (transicion == "FadeOutEstadisticas")
            {
                if (this.Opacity == 1)
                {
                    timer_Transicion.Stop();
                }
                else
                {
                    if (this.WindowState == FormWindowState.Normal)
                    {
                        this.Left = this.Left + 10;
                        this.Opacity -= .15;
                        Estadisticas.Show();
                        this.Hide();
                    }
                    else
                    {
                        this.Opacity -= .15;
                        Estadisticas.Show();
                        this.Hide();
                    }
                }
            }
        }

        private void txtTelefono_Agregar_TextChanged(object sender, EventArgs e)
        {
            //if (txtTelefono_Agregar.Text.Length <= 8 && txtTelefono_Agregar.Text.Length > 0)
            //{
            //    labCaracteresRestantesTelefono.Visible = true;
            //    int caracteresRestantes = 8 - txtTelefono_Agregar.TextLength;
            //    labCaracteresRestantesTelefono.Text = caracteresRestantes + "/8";
            //}

            int caracteresRestantes = Math.Max(0, 8 - txtTelefono_Agregar.TextLength);

            labCaracteresRestantesTelefono.Visible = true;
            labCaracteresRestantesTelefono.Text = caracteresRestantes + "/8";
        }

        private void txtTelefono_Agregar_KeyPress(object sender, KeyPressEventArgs e)
        {
            int caracteresRestantes = 8;

            if (txtTelefono_Agregar.Text.Length >= caracteresRestantes && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void labCaracteresRestantesTelefono_TextChanged(object sender, EventArgs e)
        {
            if (labCaracteresRestantesTelefono.Text == "0/8")
            {
                labCaracteresRestantesTelefono.ForeColor = Color.Red;
            }
            else
            {
                labCaracteresRestantesTelefono.ForeColor = Color.Black;
            }
        }

        private void panelE_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult seguro = MessageBox.Show("¿Está seguro que quiere Cerrar el programa?", "Hmm...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (seguro == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                if (this.WindowState == FormWindowState.Maximized)
                {
                    this.WindowState = FormWindowState.Normal;


                }

                if (this.WindowState == FormWindowState.Normal)
                {
                    int mouseX = MousePosition.X;
                    int mouseY = MousePosition.Y;

                    this.SetDesktopLocation(mouseX - mouseStartX, mouseY - mouseStartY);

                }
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;

            if (this.Top <= 0)
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                drag = true;

                mouseStartX = e.X;
                mouseStartY = e.Y;
            }
        }
    }
}