using Microsoft.ReportingServices.Diagnostics.Internal;
using MySql.Data.MySqlClient;
using MySql.Utility.Classes;
using MySql.Utility.Enums;
using MySql.Utility.Structs;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;

namespace Diseño
{
    public partial class Usuarios : Form
    {
        //Variables:
        private int idTecnico;
        public bool PassSucess;

        //Instancias:
        DataTable dataTableUsuarios = new DataTable();
        MySqlConnection conn = DataBaseConnect.Conectarse();
        MySqlCommand cmd = new MySqlCommand();
        MySqlCommand cmd_Registro;
        MySqlCommand cmd_Seguridad;
        MySqlDataReader reader;
        ToolTip ayudaVisual = new ToolTip();

        //Base de Datos:
        private string eliminarTecnico; /* <-- totalmente al pedo la viriable, pero bueno ta, no hace ninguna diferencia su existencia igualmente, se puede quedar así. */
        private bool existe_otra_cuenta;
        private string sql_Registro;
        private string sql_Seguridad;
        private string Nombre;
        private string Password;
        private string Correo;
        private string Celular;
        private string Telefono;




        public Usuarios()
        {

            InitializeComponent();
        }

        private void MostrarBaseDeDatosDeLaTablaUsuarios()
        {
            try
            {
                dataTableUsuarios.Rows.Clear();   /*<-- RECORDATORIO: No poner el nombre del DataGridView, sino el de la instancia DataTable de MySQL (Línea 21).*/
                conn.Open();
                cmd = new MySqlCommand("SELECT * FROM usuarios", conn);
                cmd.CommandType = System.Data.CommandType.Text;
                reader = cmd.ExecuteReader();
                dataTableUsuarios.Load(reader);
                label_BD_Mostrada.Text = "Mostrando Usuarios";
                label_BD_Mostrada.ForeColor = Color.ForestGreen;
            }
            catch (Exception ex)
            {
                if (conn.Equals(ConnectionState.Open))
                {
                    label_BD_Mostrada.Text = "Mostrando Usuarios";
                    label_BD_Mostrada.ForeColor = Color.ForestGreen;
                }
                else
                {
                    MessageBox.Show("No se pudo contectar con la Base de Datos", "FATAL ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MessageBox.Show(ex.Message, "Información acerca del Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    label_BD_Mostrada.Text = "No se pudo mostrar la Tabla";
                    label_BD_Mostrada.ForeColor = Color.DarkRed;
                }
            }
            finally
            {
                conn.Close();
            }
            tabla_Usuarios.DataSource = dataTableUsuarios;
        }

        private void MostrarBaseDeDatosDeLaTablaUsuariosd_SinMensajeDeError()
        {
            try
            {
                dataTableUsuarios.Rows.Clear();
                conn.Open();
                cmd = new MySqlCommand("SELECT * FROM usuarios", conn);
                cmd.CommandType = System.Data.CommandType.Text;
                reader = cmd.ExecuteReader();
                dataTableUsuarios.Load(reader);
                label_BD_Mostrada.Text = "Mostrando Usuarios";
                label_BD_Mostrada.ForeColor = Color.ForestGreen;
            }
            catch (Exception ex)
            {
                if (conn.Equals(ConnectionState.Open))
                {
                    label_BD_Mostrada.Text = "Mostrando Usuarios";
                    label_BD_Mostrada.ForeColor = Color.ForestGreen;
                }
                else
                {
                    label_BD_Mostrada.Text = "No se pudo mostrar la Tabla";
                    label_BD_Mostrada.ForeColor = Color.DarkRed;
                }
            }
            finally
            {
                conn.Close();
            }
            tabla_Usuarios.DataSource = dataTableUsuarios;
        }

        private void btnEliminar_panelBorrarTecnico_Click(object sender, EventArgs e)
        {
            //People will die... starting tonight... i'm a man of my word. 


            //  Único método para hacer que este programa tenga una confirmación mediante un form Externo
            //  (No lo pienso hacer 2 veces, no es necesario en la premisa del programa).
            Confirmacion_Con_ContraseñaMaestro confirmacion = new Confirmacion_Con_ContraseñaMaestro();

            if (txtID_panelBorrarUsuarios.Text != "")
            {
                //Para que si toque que si, que se borre, sino que no haga nada más que refrescar la tabla.
                DialogResult byebye = MessageBox.Show("¿Estás seguro de borrar este usuario?", "Hmm...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (byebye == DialogResult.Yes)
                {
                    idTecnico = int.Parse(txtID_panelBorrarUsuarios.Text);
                    confirmacion.Show();

                    confirmacion.FormClosing += (s, args) =>  /* <-- Que paja entender la expresión lambda, pero al final lo entendí */
                    {
                        if (confirmacion.PassBien == true)
                        {

                            try
                            {
                                conn.Open();
                                eliminarTecnico = "DELETE FROM trabajos WHERE ID_Tecnico = " + idTecnico + ";" + "DELETE FROM celulares WHERE ID_Usuario =" + idTecnico +
                                    ";" + "DELETE FROM usuarios WHERE ID =" + idTecnico + ";";
                                cmd = new MySqlCommand(eliminarTecnico, conn);
                                txtID_panelBorrarUsuarios.Text = "";
                                try
                                {
                                    cmd.ExecuteNonQuery();

                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("No se pudo recargar la Tabla", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    MessageBox.Show(ex.Message, "Ínformación Técnica del Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                finally
                                {
                                    conn.Close();
                                }
                                tabla_Usuarios.DataSource = dataTableUsuarios;
                                tabla_Usuarios.Refresh();
                                PassSucess = false;

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("No se pudo Borrar dicho usuario, puede deberse a que no existe el ID o hubo un fallo en la Base de Datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                MessageBox.Show(ex.Message, "Información Técnica del error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                        }

                        else
                        {
                            MessageBox.Show("Contraseña Incorrecta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    };

                }
                else
                {
                    MostrarBaseDeDatosDeLaTablaUsuarios();
                    //Como para decir que no pasa nada... porque no tiene por qué pasar algo si dice que no.

                }

            }
            else
            {
                MessageBox.Show("No deje el campo ID vacío", "Por Favor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (panel_BorrarUsuario.Height == 0 && panel_Registro.Height == 0)
            {
                panel_BorrarUsuario.Height = 590;
            }
            else
            {
                panel_Registro.Height = 0;
                panel_BorrarUsuario.Height = 0;
            }
        }

        private void btnRecargar_Click(object sender, EventArgs e)
        {
            MostrarBaseDeDatosDeLaTablaUsuarios();
            tabla_Usuarios.Refresh();
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

                tabla_Usuarios.Location = new Point(124, 78);

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
                tabla_Usuarios.Location = new Point(49, 78);

            }
        }

        private void Usuarios_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            MostrarBaseDeDatosDeLaTablaUsuarios();

            panel_Registro.Height = 0;
            panel_BorrarUsuario.Height = 0;

            labelNota_panelBorrarTecnico.Text = "Nota:\n\nSi eliminas un técnico, se eliminarán\ntodos los celulares que se le \nasignaron al técnico en cuestión.";
            ayudaVisual.SetToolTip(btnEliminar_panelBorrarTecnico, "¿Estás Seguro?");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (panel_Registro.Height == 0)
            {
                panel_Registro.Height = 599;
            }
            else
            {
                panel_Registro.Height = 0;
                panel_BorrarUsuario.Height = 0;
            }
        }
        private void panelAgregarUsuario_btnAgregar_Click(object sender, EventArgs e)
        {
            Comprobacion();
            Nombre = txtNombre.Text;
            Password = txtPassword.Text;
            Telefono = txtTelefono.Text;
            Correo = txtCorreo.Text;
            Celular = txtCelular.Text;

            if (txtNombre.Text.Equals("") || txtPassword.Text.Equals("") || txtCorreo.Text.Equals("") || txtCelular.Text.Equals(""))
            {
                MessageBox.Show("No deje un campo de texto obligatorio en blanco", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                if (existe_otra_cuenta == false)
                {
                    try
                    {
                        conn.Open();
                        sql_Registro = "INSERT INTO usuarios(Nombre, Contraseña, Telefono, CorreoElectronico, Celular) VALUES ('" + Nombre + "', '" + Password + "','" + Telefono + "','" + Correo + "','" + Celular + "')";
                        cmd_Registro = new MySqlCommand(sql_Registro, conn);
                        try
                        {
                            cmd_Registro.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("No se ingreso correctamente el usuario", "Ups..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception E)
                    {
                        MessageBox.Show("Fallo la conexion con el servidor o la base de datos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Ya existe otra cuenta con esa informacion", "Ups...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            txtNombre.Text = "";
            txtPassword.Text = "";
            txtTelefono.Text = "";
            txtCorreo.Text = "";
            txtCelular.Text = "";
        }

        private void Comprobacion()
        {
            try
            {
                conn.Open();
                sql_Seguridad = "SELECT Nombre, Contraseña FROM usuarios WHERE nombre = '" + Nombre + "' and Contraseña = '" + Password + "'";
                cmd_Seguridad = new MySqlCommand(sql_Seguridad, conn);
                reader = cmd_Seguridad.ExecuteReader();

                if (reader.Read())
                {
                    existe_otra_cuenta = true;
                }
                else
                {
                    existe_otra_cuenta = false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Falló la conexion con el servidor o la base de datos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        private void MenuOpciones_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void timer_RecargarBD_Tick(object sender, EventArgs e)
        {
            MostrarBaseDeDatosDeLaTablaUsuariosd_SinMensajeDeError();
        }

        private void Usuarios_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                MostrarBaseDeDatosDeLaTablaUsuarios();
            }
        }

        private void btnMenuPrincipal_Click(object sender, EventArgs e)
        {
            if (panel_Menu.Height == 0)
            {
                panel_Menu.Height = 599;
                panel_BorrarUsuario.Height = 0;
                panel_Registro.Height = 0;
            }
            else
            {
                panel_Menu.Height = 0;
            }
        }

        private void tabla_Usuarios_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (tabla_Usuarios.Columns.Contains("ID"))
            {

                //Cambia los tamaños de las columnas para que se acomplen mejor a la tabla y que no parezca una cosa mal hecha... no es que esté mal hecha.
                tabla_Usuarios.Columns["ID"].Width = 40;
                tabla_Usuarios.Columns["Nombre"].Width = 175;
                tabla_Usuarios.Columns["CorreoElectronico"].Width = 250;
                tabla_Usuarios.Columns["Celular"].Width = 79;
                tabla_Usuarios.Columns["Contraseña"].Width = 185;

                //Renombres del texto descriptivo de las columnas necesarias.
                tabla_Usuarios.Columns["Contraseña"].HeaderText = "HASH";
                tabla_Usuarios.Columns["CorreoElectronico"].HeaderText = "E-Mail";
                tabla_Usuarios.Columns["Nombre"].HeaderText = "Nombre de Usuario";

                //Tooltips
                tabla_Usuarios.Columns["ID"].ToolTipText = "El Identificador (ID) de cada usuario, este es único y no hay 2 iguales.";
                tabla_Usuarios.Columns["Nombre"].ToolTipText = "El nombre de usuario de cada cuenta creada.";
                tabla_Usuarios.Columns["CorreoElectronico"].ToolTipText = "El Correo Electrónico, este solo funciona como una forma de intentar contactar con dicho empleado";
                tabla_Usuarios.Columns["Celular"].ToolTipText = "El número de teléfono, otra vía por donde contactar al empleado";
                tabla_Usuarios.Columns["Contraseña"].ToolTipText = "Este es el Hash de la contraeña, es así para que no se puedan robar las cuentas, está codificado";
            }
            else
            {
                MessageBox.Show("Parece que cambió algo en las tablas\nasí que no se pudo cargarlas como es debido", "Algo salió mal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MessageBox.Show("¿Acaso alguien tocó la base de datos?\nEn cualquier caso, contacte con el Soporte Prisma", "Atención",MessageBoxButtons.OK ,MessageBoxIcon.Question);
            }
        }
    }
}
