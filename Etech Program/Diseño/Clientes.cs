using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

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

        //Instancias:
        Usuarios Usuarios = new Usuarios();
        Principal Taller = new Principal();
        MySqlConnection conn = DataBaseConnect.Conectarse("", "");
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataAdapter adapter = new MySqlDataAdapter();
        MySqlDataReader reader;
        DataTable DataTable = new DataTable();
        Utilidades Seguridad = new Utilidades();

        public Clientes()
        {
            InitializeComponent();
        }

        private void Clientes_Load(object sender, EventArgs e)
        {
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
            catch (Exception ex)
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
            txtCampo_Busqueda.Enabled = true;
            
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
            }
        }

        //Botones con sentencias SQL:
        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            if (txtCedula_Agregar.Text != "" && txtNombre_Agregar.Text != "" && txtCorreoElectronico_Agregar.Text != "" && txtCelular_Agregar.Text != "")
            {
                cedula = txtCedula_Agregar.Text;
                nombre = txtNombre_Agregar.Text;
                telefono = txtTelefono_Agregar.Text;
                correoElectronico = txtCorreoElectronico_Agregar.Text;
                celular = txtCelular_Agregar.Text;

                insertar = "INSERT INTO clientes(Cedula, Nombre, Telefono, CorreoElectronico, Celular, Baja) VALUES('" + cedula + "', '" + nombre + "', '" + telefono + "', '" + correoElectronico + "', '" + cedula + "', Baja = 1);";

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
                        txtCedula_Agregar.Text = "";
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
            if (comboBoxModificar.Text.Equals("Todas..."))
            {
                if (txtCedula_Modificar.Text != "" && txtNombre_Modificar.Text != "" && txtTelefono_Modificar.Text != "" && txtCorreoElectronico_Modificar.Text != "" && txtCedula_Modificar.Text != "")
                {
                    cedula = txtCedula_Modificar.Text;
                    nombre = txtNombre_Modificar.Text;
                    telefono = txtTelefono_Modificar.Text;
                    correoElectronico = txtCorreoElectronico_Modificar.Text;
                    celular = txtCedula_Modificar.Text;

                    modificar = "UPDATE clientes SET Cedula = '" + cedula + "', Nombre = '" + nombre + "', Telefono = '" + telefono + "', CorreoElectronico = '" + correoElectronico + "', Celular = '" + celular + "' WHERE Cedula = '" + clavePrimaria + "';";

                    try
                    {
                        conn.Open();
                        cmd = new MySqlCommand(modificar, conn);
                        try
                        {
                            cmd.ExecuteNonQuery();
                            txtCelular_Modificar.Text = "";
                            txtNombre_Modificar.Text = "";
                            txtTelefono_Modificar.Text = "";
                            txtCorreoElectronico_Modificar.Text = "";
                            txtCelular_Modificar.Text = "";
                            txtNuevaInformacion.Text = "";
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
            else
            {
                columna = comboBoxModificar.Text;

                switch (columna)
                {
                    case "Cedula":
                        if (txtNuevaInformacion.Text != "")
                        {
                            cedula = txtNuevaInformacion.Text;

                            modificar = "UPDATE clientes SET Cedula = '" + cedula + "' WHERE Cedula = '" + clavePrimaria + "';";

                            try
                            {
                                conn.Open();
                                cmd = new MySqlCommand(modificar, conn);
                                try
                                {
                                    cmd.ExecuteNonQuery();
                                    txtCelular_Modificar.Text = "";
                                    txtNombre_Modificar.Text = "";
                                    txtTelefono_Modificar.Text = "";
                                    txtCorreoElectronico_Modificar.Text = "";
                                    txtCelular_Modificar.Text = "";
                                    txtNuevaInformacion.Text = "";
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
                        break; 

                    case "Nombre":
                        if (txtNuevaInformacion.Text != "")
                        {
                            nombre = txtNuevaInformacion.Text;

                            modificar = "UPDATE clientes SET Nombre = '" + nombre + "' WHERE Cedula = '" + clavePrimaria + "';";

                            try
                            {
                                conn.Open();
                                cmd = new MySqlCommand(modificar, conn);
                                try
                                {
                                    cmd.ExecuteNonQuery();
                                    txtCelular_Modificar.Text = "";
                                    txtNombre_Modificar.Text = "";
                                    txtTelefono_Modificar.Text = "";
                                    txtCorreoElectronico_Modificar.Text = "";
                                    txtCelular_Modificar.Text = "";
                                    txtNuevaInformacion.Text = "";
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
                        break;

                    case "Telefono":
                        if (txtNuevaInformacion.Text != "")
                        {
                            telefono = txtNuevaInformacion.Text;

                            modificar = "UPDATE clientes SET Telefono = '" + telefono + "' WHERE Cedula = '" + clavePrimaria + "';";

                            try
                            {
                                conn.Open();
                                cmd = new MySqlCommand(modificar, conn);
                                try
                                {
                                    cmd.ExecuteNonQuery();
                                    txtCelular_Modificar.Text = "";
                                    txtNombre_Modificar.Text = "";
                                    txtTelefono_Modificar.Text = "";
                                    txtCorreoElectronico_Modificar.Text = "";
                                    txtCelular_Modificar.Text = "";
                                    txtNuevaInformacion.Text = "";
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
                        break;

                    case "Correo Electronico":
                        if (txtNuevaInformacion.Text != "")
                        {
                            correoElectronico = txtNuevaInformacion.Text;

                            modificar = "UPDATE clientes SET CorreoElectronico = '" + correoElectronico + "' WHERE Cedula = '" + clavePrimaria + "';";

                            try
                            {
                                conn.Open();
                                cmd = new MySqlCommand(modificar, conn);
                                try
                                {
                                    cmd.ExecuteNonQuery();
                                    txtCelular_Modificar.Text = "";
                                    txtNombre_Modificar.Text = "";
                                    txtTelefono_Modificar.Text = "";
                                    txtCorreoElectronico_Modificar.Text = "";
                                    txtCelular_Modificar.Text = "";
                                    txtNuevaInformacion.Text = "";
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
                        break;
                    case "Celular":
                        if (txtNuevaInformacion.Text != "")
                        {
                            celular = txtNuevaInformacion.Text;

                            modificar = "UPDATE clientes SET Celular = '" + celular + "' WHERE Cedula = '" + clavePrimaria + "';";

                            try
                            {
                                conn.Open();
                                cmd = new MySqlCommand(modificar, conn);
                                try
                                {
                                    cmd.ExecuteNonQuery();
                                    txtCelular_Modificar.Text = "";
                                    txtNombre_Modificar.Text = "";
                                    txtTelefono_Modificar.Text = "";
                                    txtCorreoElectronico_Modificar.Text = "";
                                    txtCelular_Modificar.Text = "";
                                    txtNuevaInformacion.Text = "";
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
                        break;
                }
            }
        }

        private void btnEliminarCliente_Click(object sender, EventArgs e)
        {
            if (txtCI_Eliminar.Text != "")
            {
                cedula = txtCI_Eliminar.Text;

                modificar = "UPDATE clientes SET Baja = 0 WHERE Cedula = '" + cedula + "';";

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

                tablaClientes.Location = new Point(124, 78); 
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
                tablaClientes.Location = new Point(49, 78);
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

        private void comboBoxModificar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxModificar.Text.Equals("Todas..."))
            {
                //lables:
                labelCedula_Modficiar.Enabled = true;
                labelCedula_Modficiar.Visible = true;

                labelNombre_Modificar.Enabled = true;
                labelNombre_Modificar.Visible = true;

                labelTelefono_Modificar.Enabled = true;
                labelTelefono_Modificar.Visible = true;

                labelCorreoElectronico_Modificar.Enabled = true;
                labelCorreoElectronico_Modificar.Visible = true;

                labelCelular_Modificar.Enabled = true;
                labelCedula_Modficiar.Visible = true;

                labelNueva_Informacion.Enabled = false;
                labelNueva_Informacion.Visible = false;

                //campos de texto:
                txtCedula_Modificar.Enabled = true;
                txtCedula_Modificar.Visible = true;

                txtNombre_Modificar.Enabled = true;
                txtNombre_Modificar.Visible = true;

                txtTelefono_Modificar.Enabled = true;
                txtTelefono_Modificar.Visible = true;

                txtCorreoElectronico_Modificar.Enabled = true;
                txtCorreoElectronico_Modificar.Visible = true;

                txtCedula_Modificar.Enabled = true;
                txtCedula_Modificar.Visible = true;

                txtNuevaInformacion.Enabled = false;
                txtNuevaInformacion.Visible = false;
            }
            else
            {
                //lables:
                labelNueva_Informacion.Enabled = true;
                labelNueva_Informacion.Visible = true;

                labelCedula_Modficiar.Enabled = false;
                labelCedula_Modficiar.Visible = false;

                labelNombre_Modificar.Enabled = false;
                labelNombre_Modificar.Visible = false;

                labelTelefono_Modificar.Enabled = false;
                labelTelefono_Modificar.Visible = false;

                labelCorreoElectronico_Modificar.Enabled = false;
                labelCorreoElectronico_Modificar.Visible = false;

                labelCelular_Modificar.Enabled = false;
                labelCedula_Modficiar.Visible = false;

                //campos de texto:
                txtNuevaInformacion.Enabled = true;
                txtNuevaInformacion.Visible = true;

                txtCedula_Modificar.Enabled = false;
                txtCedula_Modificar.Visible = false;

                txtNombre_Modificar.Enabled = false;
                txtNombre_Modificar.Visible = false;

                txtTelefono_Modificar.Enabled = false;
                txtTelefono_Modificar.Visible = false;

                txtCorreoElectronico_Modificar.Enabled = false;
                txtCorreoElectronico_Modificar.Visible = false;

                txtCedula_Modificar.Enabled = false;
                txtCedula_Modificar.Visible = false;
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

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            Usuarios.Show();
            this.Hide();
        }

        private void btnTaller_Click(object sender, EventArgs e)
        {
            Taller.Show();
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
                tablaClientes.Columns["Celular"].HeaderText = "N° Celular provicional";

                //Tooltips al posar el mouse
                tablaClientes.Columns["Cedula"].ToolTipText = "Cédula de identidad del cliente, necesaria para identificar los dueños de los celulares en el taller";
                tablaClientes.Columns["Nombre"].ToolTipText = "Nombre de pila y apellido del cliente";
                tablaClientes.Columns["Telefono"].ToolTipText = "Teléfono fijo, como forma de contactar al cliente.";
                tablaClientes.Columns["CorreoElectronico"].ToolTipText = "El E-Mail del cliente, otra forma de contactar con el mismo";
                tablaClientes.Columns["Celular"].ToolTipText = "Número de celular el cuál no sea el que está para arreglar";
            }
        }

        private void timer_RecargarBD_Tick(object sender, EventArgs e)
        {
            MostrarDatosEnLaTablaClientes_SinMensajeDeError();
        }
    }
}
