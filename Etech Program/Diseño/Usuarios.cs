using Diseño.Properties;
using Microsoft.ReportingServices.Diagnostics.Internal;
using MySql.Data.MySqlClient;
using MySql.Utility.Classes;
using MySql.Utility.Enums;
using MySql.Utility.Structs;
using System;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Diseño
{
    public partial class Usuarios : Form
    {
        //Variables:
        private int idTecnico;
        public bool PassSucess;
        private string modificarAtributosDeUsuarios;
        DataBaseConnect connect = new DataBaseConnect();

        //Instancias
        DataTable dataTableUsuarios = new DataTable();
        MySqlConnection conn = DataBaseConnect.Conectarse("", "");
        MySqlCommand cmd = new MySqlCommand();
        MySqlCommand cmd_Registro;
        MySqlCommand cmd_Seguridad;
        MySqlDataReader reader;
        ToolTip ayudaVisual = new ToolTip();
        Utilidades seguridad = new Utilidades();

        //Forms:


        //Base de Datos:
        private string eliminarTecnico; /* <-- totalmente al pedo la viriable, pero bueno ta, no hace ninguna diferencia su existencia igualmente, se puede quedar así. */
        private bool existe_otra_cuenta;
        private bool ApareceLaContraseñaMaestra = false;
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
            if (seguridad.getInvitado)
            {
                pictureBox_WarningLeft.Visible = true;
                pictureBox_WarningRight.Visible = true;
                label_InvitadoDetectado.Visible = true;
            }
            else
            {

                try
                {
                    dataTableUsuarios.Rows.Clear();   /*<-- RECORDATORIO: No poner el nombre del DataGridView, sino el de la instancia DataTable de MySQL.*/
                    conn.Open();
                    cmd = new MySqlCommand("SELECT * FROM usuarios WHERE Baja = 0", conn);
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

        }

        private void MostrarBaseDeDatosDeLaTablaUsuariosd_SinMensajeDeError()
        {
            try
            {
                dataTableUsuarios.Rows.Clear();
                conn.Open();
                cmd = new MySqlCommand("SELECT * FROM usuarios WHERE Baja = 0 ", conn);
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
                    ApareceLaContraseñaMaestra = true;

                    confirmacion.FormClosing += (s, args) =>    /* <-- Que paja entender la expresión (en este caso, sentencia) lambda, pero al final lo entendí */
                    {

                        if (confirmacion.PassBien == true)
                        {

                            try
                            {
                                conn.Open();
                                eliminarTecnico = $"UPDATE trabajos SET Baja = 0 WHERE ID_Tecnico = {idTecnico}; UPDATE celulares SET Baja = 0 WHERE ID_Usuario = {idTecnico}; DELETE FROM usuarios WHERE ID = {idTecnico};";
                                cmd = new MySqlCommand(eliminarTecnico, conn);
                                txtID_panelBorrarUsuarios.Text = "";
                                ApareceLaContraseñaMaestra = false;
                                try
                                {
                                    cmd.ExecuteNonQuery();
                                    ApareceLaContraseñaMaestra = false;

                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("No se pudo recargar la Tabla", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    MessageBox.Show(ex.Message, "Ínformación Técnica del Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    ApareceLaContraseñaMaestra = false;
                                }
                                finally
                                {
                                    conn.Close();
                                    ApareceLaContraseñaMaestra = false;
                                }
                                tabla_Usuarios.DataSource = dataTableUsuarios;
                                tabla_Usuarios.Refresh();
                                PassSucess = false;

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("No se pudo Borrar dicho usuario, puede deberse a que no existe el ID o hubo un fallo en la Base de Datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                MessageBox.Show(ex.Message, "Información Técnica del error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ApareceLaContraseñaMaestra = false;
                            }

                        }

                        else
                        {

                        }

                        ApareceLaContraseñaMaestra = false;

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
            if (panel_BorrarUsuario.Height == 0)
            {
                panel_BorrarUsuario.Height = 590;
                panel_BorrarUsuario.Visible = true;
                panel_Menu.Height = 0;
                panel_Registro.Height = 0;
                panel_Modificar.Height = 0;
            }
            else
            {
                panel_BorrarUsuario.Height = 0;
                panel_BorrarUsuario.Visible = false;
            }

            if (tabla_Usuarios.Size.Equals(new Size(872, 599)) && panelD.Size.Equals(new Size(119, 1060)))  /* <-- Andá a adivinar que esto era así...*/
            {
                tabla_Usuarios.Size = new Size(800, 599);
            }
            else
            {
                tabla_Usuarios.Size = new Size(872, 599);
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

                //Botones:
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

                //La tabla:
                tabla_Usuarios.Location = new Point(124, 78);

                if (panel_BorrarUsuario.Visible == true || panel_Menu.Visible == true || panel_Registro.Visible == true || panel_Modificar.Visible == true)
                {
                    tabla_Usuarios.Size = new Size(800, 599);
                }
                else
                {
                    tabla_Usuarios.Size = new Size(872, 599);
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
                tabla_Usuarios.Location = new Point(49, 78);
                tabla_Usuarios.Size = new Size(872, 599);
            }
        }

        private void Usuarios_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            MostrarBaseDeDatosDeLaTablaUsuarios();

            labelNota_panelBorrarTecnico.Text = "Nota:\n\nSi eliminas un técnico, se eliminarán\ntodos los celulares que se le \nasignaron al técnico en cuestión.";
            ayudaVisual.SetToolTip(btnEliminar_panelBorrarTecnico, "¿Estás Seguro?");
            ayudaVisual.SetToolTip(chbMostrarContraseña_PanelRegistro, "Ocultar o Mostrar contraseña");
            ayudaVisual.SetToolTip(chbOcultarContraseña_groupboxModificar_PanelModificar, "Ocultar o Mostrar contraseña");


            comboBoxModifcar_groupBoxModificar_PanelModificar.Text = "Todos";

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (tabla_Usuarios.Size.Equals(new Size(872, 599)) && panelD.Size.Equals(new Size(119, 1060)))  /* <-- Andá a adivinar que esto era así...*/
            {
                tabla_Usuarios.Size = new Size(800, 599);
            }
            else
            {
                tabla_Usuarios.Size = new Size(872, 599);
            }

            if (panel_Registro.Height == 0)
            {
                panel_Registro.Height = 599;
                panel_Registro.Visible = true;
                panel_Menu.Height = 0;
                panel_Modificar.Height = 0;
                panel_BorrarUsuario.Height = 0;


            }
            else
            {
                panel_Registro.Height = 0;
                panel_BorrarUsuario.Height = 0;
                panel_Registro.Visible = false;
            }

        }
        private void panelAgregarUsuario_btnAgregar_Click(object sender, EventArgs e)
        {
            Confirmacion_Con_ContraseñaMaestro contraseñaMaestra = new Confirmacion_Con_ContraseñaMaestro();

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
                contraseñaMaestra.Show();
                contraseñaMaestra.FormClosing += (s, args) =>
                {
                    ApareceLaContraseñaMaestra = true;
                    if (contraseñaMaestra.PassBien)
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
                            txtNombre.Text = "";
                            txtPassword.Text = "";
                            txtTelefono.Text = "";
                            txtCorreo.Text = "";
                            txtCelular.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("Ya existe otra cuenta con esa informacion", "Ups...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {

                    }
                    ApareceLaContraseñaMaestra = false;
                };


            }

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

        private void timer_RecargarBD_Tick(object sender, EventArgs e)
        {
            MostrarBaseDeDatosDeLaTablaUsuariosd_SinMensajeDeError();
        }

        private void Usuarios_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void btnMenuPrincipal_Click(object sender, EventArgs e)
        {
            if (panel_Menu.Height == 0)
            {
                panel_Menu.Height = 599;
                panel_BorrarUsuario.Height = 0;
                panel_Registro.Height = 0;
                panel_Modificar.Height = 0;
                panel_Menu.Visible = true;

            }
            else
            {
                panel_Menu.Height = 0;
                panel_Menu.Visible = false;
            }
            if (tabla_Usuarios.Size.Equals(new Size(872, 599)) && panelD.Size.Equals(new Size(119, 1060)))  /* <-- Andá a adivinar que esto era así...*/
            {
                tabla_Usuarios.Size = new Size(800, 599);
            }
            else
            {
                tabla_Usuarios.Size = new Size(872, 599);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (panel_Modificar.Height == 0)
            {
                panel_Modificar.Visible = true;
                panel_Modificar.Height = 599;
                panel_BorrarUsuario.Height = 0;
                panel_Registro.Height = 0;
                panel_Menu.Height = 0;

            }
            else
            {
                panel_Modificar.Height = 0;
                panel_Modificar.Visible = false;
            }
            if (tabla_Usuarios.Size.Equals(new Size(872, 599)) && panelD.Size.Equals(new Size(119, 1060)))  /* <-- Andá a adivinar que esto era así...*/
            {
                tabla_Usuarios.Size = new Size(800, 599);
            }
            else
            {
                tabla_Usuarios.Size = new Size(872, 599);
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
                tabla_Usuarios.Columns["Telefono"].ToolTipText = "¡Hola! ¡Si, soy yo! Resulta que la Organización tiene teléfonos fijos... si... si... ¡Pero!.. Está bien... Te mantendré informado. El, Psy, Kongroo";
                tabla_Usuarios.Columns["Celular"].ToolTipText = "El número de teléfono, otra vía por donde contactar al empleado";
                tabla_Usuarios.Columns["Contraseña"].ToolTipText = "Este es el Hash de la contraeña, es así para que no se puedan robar las cuentas, está codificado";
            }
            else
            {
                MessageBox.Show("Parece que cambió algo en las tablas\nasí que no se pudo cargarlas como es debido", "Algo salió mal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MessageBox.Show("¿Acaso alguien tocó la base de datos?\nEn cualquier caso, contacte con el Soporte Prisma", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        private void chbMostrarContraseña_PanelRegistro_CheckedChanged(object sender, EventArgs e)
        {
            if (chbMostrarContraseña_PanelRegistro.Checked)
            {
                //Se cambia la imagen y la sintaxis cambia a letras y números
                picMostrar.Image = Resources.ojo;
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                //Se cambia la imagen y la sintaxis cambia a Asteriscos " * "
                picMostrar.Image = Resources.ojo_tapado;
                txtPassword.PasswordChar = '*';
            }
        }

        private void chbOcultarContraseña_groupboxModificar_PanelModificar_CheckedChanged(object sender, EventArgs e)
        {
            if (chbOcultarContraseña_groupboxModificar_PanelModificar.Checked)
            {
                //Se cambia la imagen y la sintaxis cambia a letras y números
                picMostrar_groupBoxModificar_PanelModificar.Image = Resources.ojo;
                txtContraseña_groupboxModificar_PanelModificar.PasswordChar = '\0';
            }
            else
            {
                //Se cambia la imagen y la sintaxis cambia a Asteriscos " * "
                picMostrar_groupBoxModificar_PanelModificar.Image = Resources.ojo_tapado;
                txtContraseña_groupboxModificar_PanelModificar.PasswordChar = '*';
            }
        }

        private void comboBoxModifcar_groupBoxModificar_PanelModificar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxModifcar_groupBoxModificar_PanelModificar.Text == "Todos")
            {
                //Nombre:
                labNombre_groupBoxModificar_PanelModificar.Visible = true;
                labNombre_groupBoxModificar_PanelModificar.Location = new Point(3, 66);
                txtNombre_groupboxModificar_PanelModificar.Visible = true;
                txtNombre_groupboxModificar_PanelModificar.Location = new Point(6, 81);

                //Contraseña:
                labelContraseña_groupboxModificar_PanelModificar.Visible = true;
                labelContraseña_groupboxModificar_PanelModificar.Location = new Point(3, 109);
                txtContraseña_groupboxModificar_PanelModificar.Visible = true;
                txtContraseña_groupboxModificar_PanelModificar.Location = new Point(6, 123);
                chbOcultarContraseña_groupboxModificar_PanelModificar.Visible = true;
                chbOcultarContraseña_groupboxModificar_PanelModificar.Location = new Point(353, 126);
                picMostrar_groupBoxModificar_PanelModificar.Location = new Point(353, 126);
                picMostrar_groupBoxModificar_PanelModificar.Visible = true;


                //Correo:
                labelCorreoElectronico_groupBoxModificar_PanelModificar.Visible = true;
                labelCorreoElectronico_groupBoxModificar_PanelModificar.Location = new Point(3, 153);
                txtCorreoElectronico_groupBoxModificar_PanelModificar.Visible = true;
                txtCorreoElectronico_groupBoxModificar_PanelModificar.Location = new Point(6, 168);

                //Telefono:
                labelTelefono_groupBoxModificar_PanelModificar.Visible = true;
                labelTelefono_groupBoxModificar_PanelModificar.Location = new Point(3, 201);
                txtTelefono_groupBoxModificar_PanelModificar.Visible = true;
                txtTelefono_groupBoxModificar_PanelModificar.Location = new Point(6, 215);

                //Celular:
                labelCelular_groupBoxModificar_PanelModificar.Visible = true;
                labelCelular_groupBoxModificar_PanelModificar.Location = new Point(3, 249);
                txtCelular_groupBoxModificar_PanelModificar.Visible = true;
                txtCelular_groupBoxModificar_PanelModificar.Location = new Point(6, 263);

            }
            else if (comboBoxModifcar_groupBoxModificar_PanelModificar.Text == "Nombre")
            {
                //Nombre:
                labNombre_groupBoxModificar_PanelModificar.Visible = true;
                labNombre_groupBoxModificar_PanelModificar.Location = new Point(3, 66);
                txtNombre_groupboxModificar_PanelModificar.Visible = true;
                txtNombre_groupboxModificar_PanelModificar.Location = new Point(6, 81);

                //Contraseña:
                labelContraseña_groupboxModificar_PanelModificar.Visible = false;
                labelContraseña_groupboxModificar_PanelModificar.Location = new Point(3, 109);
                txtContraseña_groupboxModificar_PanelModificar.Visible = false;
                txtContraseña_groupboxModificar_PanelModificar.Location = new Point(6, 123);
                picMostrar_groupBoxModificar_PanelModificar.Visible = false;
                chbOcultarContraseña_groupboxModificar_PanelModificar.Visible = false;

                //Correo:
                labelCorreoElectronico_groupBoxModificar_PanelModificar.Visible = false;
                labelCorreoElectronico_groupBoxModificar_PanelModificar.Location = new Point(3, 153);
                txtCorreoElectronico_groupBoxModificar_PanelModificar.Visible = false;
                txtCorreoElectronico_groupBoxModificar_PanelModificar.Location = new Point(6, 168);

                //Teléfono:
                labelTelefono_groupBoxModificar_PanelModificar.Visible = false;
                labelTelefono_groupBoxModificar_PanelModificar.Location = new Point(3, 201);
                txtTelefono_groupBoxModificar_PanelModificar.Visible = false;
                txtTelefono_groupBoxModificar_PanelModificar.Location = new Point(6, 215);

                //Celular:
                labelCelular_groupBoxModificar_PanelModificar.Visible = false;
                labelCelular_groupBoxModificar_PanelModificar.Location = new Point(3, 249);
                txtCelular_groupBoxModificar_PanelModificar.Visible = false;
                txtCelular_groupBoxModificar_PanelModificar.Location = new Point(6, 263);

            }
            else if (comboBoxModifcar_groupBoxModificar_PanelModificar.Text == "Contraseña")
            {

                //Ya me dió paja escribir de qué es cada sección espaciada.
                labNombre_groupBoxModificar_PanelModificar.Visible = false;
                labNombre_groupBoxModificar_PanelModificar.Location = new Point(3, 66);
                txtNombre_groupboxModificar_PanelModificar.Visible = false;
                txtNombre_groupboxModificar_PanelModificar.Location = new Point(6, 81);


                labelContraseña_groupboxModificar_PanelModificar.Visible = true;
                labelContraseña_groupboxModificar_PanelModificar.Location = new Point(3, 66);
                txtContraseña_groupboxModificar_PanelModificar.Visible = true;
                txtContraseña_groupboxModificar_PanelModificar.Location = new Point(3, 81);
                picMostrar_groupBoxModificar_PanelModificar.Visible = true;
                picMostrar_groupBoxModificar_PanelModificar.Location = new Point(353, 85);
                chbOcultarContraseña_groupboxModificar_PanelModificar.Location = new Point(353, 85);
                chbOcultarContraseña_groupboxModificar_PanelModificar.Visible = true;

                labelCorreoElectronico_groupBoxModificar_PanelModificar.Visible = false;
                labelCorreoElectronico_groupBoxModificar_PanelModificar.Location = new Point(3, 153);
                txtCorreoElectronico_groupBoxModificar_PanelModificar.Visible = false;
                txtCorreoElectronico_groupBoxModificar_PanelModificar.Location = new Point(6, 168);

                labelTelefono_groupBoxModificar_PanelModificar.Visible = false;
                labelTelefono_groupBoxModificar_PanelModificar.Location = new Point(3, 201);
                txtTelefono_groupBoxModificar_PanelModificar.Visible = false;
                txtTelefono_groupBoxModificar_PanelModificar.Location = new Point(6, 215);

                labelCelular_groupBoxModificar_PanelModificar.Visible = false;
                labelCelular_groupBoxModificar_PanelModificar.Location = new Point(3, 249);
                txtCelular_groupBoxModificar_PanelModificar.Visible = false;
                txtCelular_groupBoxModificar_PanelModificar.Location = new Point(6, 263);

            }
            else if (comboBoxModifcar_groupBoxModificar_PanelModificar.Text == "Correo")
            {
                labNombre_groupBoxModificar_PanelModificar.Visible = false;
                labNombre_groupBoxModificar_PanelModificar.Location = new Point(3, 66);
                txtNombre_groupboxModificar_PanelModificar.Visible = false;
                txtNombre_groupboxModificar_PanelModificar.Location = new Point(6, 81);


                labelContraseña_groupboxModificar_PanelModificar.Visible = false;
                labelContraseña_groupboxModificar_PanelModificar.Location = new Point(3, 109);
                txtContraseña_groupboxModificar_PanelModificar.Visible = false;
                txtContraseña_groupboxModificar_PanelModificar.Location = new Point(3, 109);
                picMostrar_groupBoxModificar_PanelModificar.Visible = false;
                chbOcultarContraseña_groupboxModificar_PanelModificar.Visible = false;

                labelCorreoElectronico_groupBoxModificar_PanelModificar.Visible = true;
                labelCorreoElectronico_groupBoxModificar_PanelModificar.Location = new Point(3, 66);
                txtCorreoElectronico_groupBoxModificar_PanelModificar.Visible = true;
                txtCorreoElectronico_groupBoxModificar_PanelModificar.Location = new Point(6, 81);

                labelTelefono_groupBoxModificar_PanelModificar.Visible = false;
                labelTelefono_groupBoxModificar_PanelModificar.Location = new Point(3, 201);
                txtTelefono_groupBoxModificar_PanelModificar.Visible = false;
                txtTelefono_groupBoxModificar_PanelModificar.Location = new Point(6, 215);

                labelCelular_groupBoxModificar_PanelModificar.Visible = false;
                labelCelular_groupBoxModificar_PanelModificar.Location = new Point(3, 249);
                txtCelular_groupBoxModificar_PanelModificar.Visible = false;
                txtCelular_groupBoxModificar_PanelModificar.Location = new Point(6, 263);
            }
            else if (comboBoxModifcar_groupBoxModificar_PanelModificar.Text == "Teléfono")
            {
                labNombre_groupBoxModificar_PanelModificar.Visible = false;
                labNombre_groupBoxModificar_PanelModificar.Location = new Point(3, 66);
                txtNombre_groupboxModificar_PanelModificar.Visible = false;
                txtNombre_groupboxModificar_PanelModificar.Location = new Point(6, 81);


                labelContraseña_groupboxModificar_PanelModificar.Visible = false;
                labelContraseña_groupboxModificar_PanelModificar.Location = new Point(3, 109);
                txtContraseña_groupboxModificar_PanelModificar.Visible = false;
                txtContraseña_groupboxModificar_PanelModificar.Location = new Point(3, 109);
                picMostrar_groupBoxModificar_PanelModificar.Visible = false;
                chbOcultarContraseña_groupboxModificar_PanelModificar.Visible = false;

                labelCorreoElectronico_groupBoxModificar_PanelModificar.Visible = false;
                labelCorreoElectronico_groupBoxModificar_PanelModificar.Location = new Point(3, 66);
                txtCorreoElectronico_groupBoxModificar_PanelModificar.Visible = false;
                txtCorreoElectronico_groupBoxModificar_PanelModificar.Location = new Point(6, 81);

                labelTelefono_groupBoxModificar_PanelModificar.Visible = true;
                labelTelefono_groupBoxModificar_PanelModificar.Location = new Point(3, 66);
                txtTelefono_groupBoxModificar_PanelModificar.Visible = true;
                txtTelefono_groupBoxModificar_PanelModificar.Location = new Point(6, 81);

                labelCelular_groupBoxModificar_PanelModificar.Visible = false;
                labelCelular_groupBoxModificar_PanelModificar.Location = new Point(3, 249);
                txtCelular_groupBoxModificar_PanelModificar.Visible = false;
                txtCelular_groupBoxModificar_PanelModificar.Location = new Point(6, 263);
            }
            else if (comboBoxModifcar_groupBoxModificar_PanelModificar.Text == "Celular")
            {
                labNombre_groupBoxModificar_PanelModificar.Visible = false;
                labNombre_groupBoxModificar_PanelModificar.Location = new Point(3, 66);
                txtNombre_groupboxModificar_PanelModificar.Visible = false;
                txtNombre_groupboxModificar_PanelModificar.Location = new Point(6, 81);


                labelContraseña_groupboxModificar_PanelModificar.Visible = false;
                labelContraseña_groupboxModificar_PanelModificar.Location = new Point(3, 109);
                txtContraseña_groupboxModificar_PanelModificar.Visible = false;
                txtContraseña_groupboxModificar_PanelModificar.Location = new Point(3, 109);
                picMostrar_groupBoxModificar_PanelModificar.Visible = false;
                chbOcultarContraseña_groupboxModificar_PanelModificar.Visible = false;

                labelCorreoElectronico_groupBoxModificar_PanelModificar.Visible = false;
                labelCorreoElectronico_groupBoxModificar_PanelModificar.Location = new Point(3, 66);
                txtCorreoElectronico_groupBoxModificar_PanelModificar.Visible = false;
                txtCorreoElectronico_groupBoxModificar_PanelModificar.Location = new Point(6, 81);

                labelTelefono_groupBoxModificar_PanelModificar.Visible = false;
                labelTelefono_groupBoxModificar_PanelModificar.Location = new Point(3, 66);
                txtTelefono_groupBoxModificar_PanelModificar.Visible = false;
                txtTelefono_groupBoxModificar_PanelModificar.Location = new Point(6, 81);

                labelCelular_groupBoxModificar_PanelModificar.Visible = true;
                labelCelular_groupBoxModificar_PanelModificar.Location = new Point(3, 66);
                txtCelular_groupBoxModificar_PanelModificar.Visible = true;
                txtCelular_groupBoxModificar_PanelModificar.Location = new Point(6, 81);
            }

            //Esto es muy caótico para leer sin duda.

        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            DialogResult siono = MessageBox.Show("¿Estás seguro de Cerrar Sesión?", "Hmm...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (siono == DialogResult.Yes)
            {
                Application.Restart();
            }
            else
            {

            }
        }

        private void btnTaller_PanelMenu_Click(object sender, EventArgs e)
        {
            if (ApareceLaContraseñaMaestra)
            {
                MessageBox.Show("Debe de cerrar todas las ventanas emergentes antes de cambiar de pantalla", "Cuidado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Principal mostrar = new Principal();
                this.Hide();
                mostrar.Show();
            }
        }

        private void btnModificar_groupBoxModificar_PanelModificar_Click(object sender, EventArgs e)
        {
            //People will be modified... starting tonight... i'm a man of my word.

            Confirmacion_Con_ContraseñaMaestro confirmacion = new Confirmacion_Con_ContraseñaMaestro();


            if (comboBoxModifcar_groupBoxModificar_PanelModificar.Text == "Todos")
            {
                if (txtNombre_groupboxModificar_PanelModificar.Text == "" && txtContraseña_groupboxModificar_PanelModificar.Text == "" &&
                    txtCorreoElectronico_groupBoxModificar_PanelModificar.Text == "" && txtCelular_groupBoxModificar_PanelModificar.Text == "" && txtIDseleccionado_groupBoxModificar_PanelModificar.Text == "")
                {
                    MessageBox.Show("No deje ningun campo obligatorio en blanco", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int idUsuario = int.Parse(txtIDseleccionado_groupBoxModificar_PanelModificar.Text);

                    DialogResult siono = MessageBox.Show("¿Estás seguro de modificar estos atributos?", "Hmm...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (siono == DialogResult.Yes)
                    {
                        confirmacion.Show();
                        ApareceLaContraseñaMaestra = true;

                        confirmacion.FormClosing += (s, args) =>
                        {

                            //Código/query de la modificación para todos los campos:

                            if (confirmacion.PassBien == true)
                            {

                                try
                                {
                                    conn.Open();
                                    modificarAtributosDeUsuarios = $"UPDATE usuarios SET Nombre='{txtNombre_groupboxModificar_PanelModificar.Text}', Contraseña='{txtContraseña_groupboxModificar_PanelModificar.Text}', Telefono='{txtTelefono_groupBoxModificar_PanelModificar.Text}', CorreoElectronico='{txtCorreoElectronico_groupBoxModificar_PanelModificar.Text}', Celular='{txtCelular_groupBoxModificar_PanelModificar.Text}' WHERE ID={idUsuario}";
                                    cmd = new MySqlCommand(modificarAtributosDeUsuarios, conn);

                                    try
                                    {
                                        cmd.ExecuteNonQuery();
                                        MessageBox.Show("Usuario modificado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("No se pudo modificar el usuario.\n\nCompruebe la existencia del Usuario y el ID del mismo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        MessageBox.Show(ex.Message, "Información técnica", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }

                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("No se puedo conectar con la Base de Datos\n\n¿Alguien puso mala mano en la configuración interna de la Base de Datos?", "FATAL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    MessageBox.Show(ex.Message, "Información técnica", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                finally
                                {
                                    conn.Close();
                                }
                            }
                            else
                            {
                                //nada, nada.
                            }
                            ApareceLaContraseñaMaestra = false;

                        };

                    }
                    else
                    {
                        MessageBox.Show("Okay, esto si que es raro\n\nHay algo mal con esta parte del programa, contacte con el soporte de Prisma", "Error Raro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                }
            }


            else if (comboBoxModifcar_groupBoxModificar_PanelModificar.Text == "Nombre")
            {
                if (txtNombre_groupboxModificar_PanelModificar.Text == "")
                {
                    MessageBox.Show("No deje el campo del Nombre en blanco", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    DialogResult siono = MessageBox.Show("¿Estás seguro de modificar estos atributos?", "Hmm...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    int idUsuario = int.Parse(txtIDseleccionado_groupBoxModificar_PanelModificar.Text);

                    if (siono == DialogResult.Yes)
                    {

                        confirmacion.Show();
                        ApareceLaContraseñaMaestra = true;
                        confirmacion.FormClosing += (s, args) =>
                    {
                        //Código/query de la modificación del campo de Nombre

                        try
                        {
                            conn.Open();
                            modificarAtributosDeUsuarios = $"UPDATE usuarios SET Nombre ='{txtNombre_groupboxModificar_PanelModificar.Text}' WHERE ID ={idUsuario};";
                            cmd = new MySqlCommand(modificarAtributosDeUsuarios, conn);
                            try
                            {
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Nombre de usuario modificado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("No se pudo modificar el usuario.\n\nCompruebe la existencia del Usuario y el ID del mismo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                MessageBox.Show(ex.Message, "Información técnica", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }

                        catch (Exception ex)
                        {

                            MessageBox.Show("No se puedo conectar con la Base de Datos", "FATAL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            MessageBox.Show(ex.Message, "Información técnica", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        finally
                        {
                            conn.Close();
                        }




                    };
                        ApareceLaContraseñaMaestra = false;


                    }
                    else
                    {
                        //Nada.
                    }
                }


            }
            else if (comboBoxModifcar_groupBoxModificar_PanelModificar.Text == "Contraseña")
            {
                if (txtContraseña_groupboxModificar_PanelModificar.Text == "" && txtIDseleccionado_groupBoxModificar_PanelModificar.Text == "")
                {
                    MessageBox.Show("No deje el campo de Contraseña en blanco", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    DialogResult siono = MessageBox.Show("¿Está Seguro de modificar la contraseña de este Usuario?.", "Hmm...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    int idUsuario = int.Parse(txtIDseleccionado_groupBoxModificar_PanelModificar.Text);

                    if (siono == DialogResult.Yes)
                    {

                        confirmacion.Show();
                        ApareceLaContraseñaMaestra = true;

                        confirmacion.FormClosing += (s, args) =>
                        {
                            //Código/query de modificación de la contraseña:

                            try
                            {
                                conn.Open();
                                modificarAtributosDeUsuarios = $"UPDATE usuarios SET contraseña='{txtContraseña_groupboxModificar_PanelModificar.Text}' WHERE ID={idUsuario}";
                                cmd = new MySqlCommand(modificarAtributosDeUsuarios, conn);
                                try
                                {
                                    cmd.ExecuteNonQuery();
                                    MessageBox.Show("Contraseña del usuario cambiada correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("No se pudo modificar la contraseña del Usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    MessageBox.Show(ex.Message, "Información Técnica", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }


                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error al conectar con la Base de Datos, contacte al soporte Prisma.", "FATAL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                MessageBox.Show(ex.Message, "Información Técnica", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            finally
                            {
                                conn.Close();
                            }


                        };
                        ApareceLaContraseñaMaestra = false;
                    }
                    else
                    {
                        //Queda en nada.
                    }
                }

            }
            else if (comboBoxModifcar_groupBoxModificar_PanelModificar.Text == "Correo")
            {
                if (txtCorreoElectronico_groupBoxModificar_PanelModificar.Text == "")
                {
                    MessageBox.Show("No deje el campo del Correo Electrónico en blanco", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DialogResult siono = MessageBox.Show("¿Está seguro que quiere modificar el Correo del usuario?", "Hmm...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    int idUsuario = int.Parse(txtIDseleccionado_groupBoxModificar_PanelModificar.Text);

                    if (siono == DialogResult.Yes)
                    {
                        confirmacion.Show();
                        ApareceLaContraseñaMaestra = true;
                        confirmacion.FormClosing += (s, args) =>
                        {
                            //Código/query de modificación del correo:

                            try
                            {
                                conn.Open();
                                modificarAtributosDeUsuarios = $"UPDATE usuarios SET CorreoElectronico='{txtCorreoElectronico_groupBoxModificar_PanelModificar.Text}' WHERE ID={idUsuario}";
                                cmd = new MySqlCommand(modificarAtributosDeUsuarios, conn);
                                try
                                {
                                    cmd.ExecuteNonQuery();
                                    MessageBox.Show("E-Mail cambiado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("No se pudo modificar el correo del usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    MessageBox.Show(ex.Message, "Información técnica", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("No se pudo conectar con la Base de Datos", "FATAL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                MessageBox.Show(ex.Message, "Información técnica", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            finally
                            {
                                conn.Close();
                            }




                        };
                        ApareceLaContraseñaMaestra = false;
                    }
                    else
                    {
                        //Queda en nada... otra vez.
                    }

                }

            }
            else if (comboBoxModifcar_groupBoxModificar_PanelModificar.Text == "Teléfono")
            {
                if (txtTelefono_groupBoxModificar_PanelModificar.Text == "")
                {
                    MessageBox.Show("No deje el campo de Teléfono en blanco", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DialogResult siono = MessageBox.Show("¿Está seguro de modificar el Teléfono de este usuario?", "Hmm...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    int idUsuario = int.Parse(txtIDseleccionado_groupBoxModificar_PanelModificar.Text);

                    if (siono == DialogResult.Yes)
                    {
                        confirmacion.Show();
                        ApareceLaContraseñaMaestra = true;
                        confirmacion.FormClosing += (s, args) =>
                        {
                            //Código/query de la modificación del Teléfono Microondas (Nombre provicional).

                            try
                            {
                                conn.Open();
                                modificarAtributosDeUsuarios = $"UPDATE usuarios SET Telefono='{txtTelefono_groupBoxModificar_PanelModificar.Text}' WHERE ID={idUsuario}";
                                cmd = new MySqlCommand(modificarAtributosDeUsuarios, conn);
                                try
                                {
                                    cmd.ExecuteNonQuery();
                                    MessageBox.Show("Teléfono cambiado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("No se pudo modificar el Teléfono del usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    MessageBox.Show(ex.Message, "Información técnica", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("No se pudo conectar con la Base de Datos", "FATAL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                MessageBox.Show(ex.Message, "Informacion técnica", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            finally
                            {
                                conn.Close();
                            }



                        };
                        ApareceLaContraseñaMaestra = false;
                    }
                    else
                    {
                        //Queda en nada... si... una vez más.
                    }

                }
            }
            else if (comboBoxModifcar_groupBoxModificar_PanelModificar.Text == "Celular")
            {
                if (txtCelular_groupBoxModificar_PanelModificar.Text == "")
                {
                    MessageBox.Show("No deje el campo de Celular en blanco", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DialogResult siono = MessageBox.Show("¿Está seguro de modificar el Celular de este usuario?", "Hmm...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    
                    int idUsuario = int.Parse(txtIDseleccionado_groupBoxModificar_PanelModificar.Text);

                    if (siono == DialogResult.Yes)
                    {
                        confirmacion.Show();
                        ApareceLaContraseñaMaestra = true;
                        confirmacion.FormClosing += (s, args) =>
                        {
                            //Código/query de la modificacion del celular:   

                            try
                            {
                                conn.Open();
                                modificarAtributosDeUsuarios = $"UPDATE usuarios SET celular='{txtCelular_groupBoxModificar_PanelModificar.Text}' WHERE ID={idUsuario}";
                                cmd = new MySqlCommand(modificarAtributosDeUsuarios, conn);
                                try
                                {
                                    cmd.ExecuteNonQuery();
                                    MessageBox.Show("Número de celular cambiado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("No se pudo modificar el Celular de este usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    MessageBox.Show(ex.Message, "Información técnica", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("No se pudo conectar con la Base de Datos", "FATAL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                MessageBox.Show(ex.Message, "Información técnica", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            finally
                            {
                                conn.Close();
                            }
                        };
                        ApareceLaContraseñaMaestra = false;
                    }
                    else
                    {
                        //No preguntes... ya sabemos lo que pasa acá.
                    }
                }
            }
            else
            {
                //Por las dudas... no vaya a ser que salga un error de windows inesperado y que se cierre el programa.
            }
        }

        private void Usuarios_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void btnClientes_groupBoxMenu_PanelMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            Clientes show = new Clientes();
            show.Show();
        }
    }
}
