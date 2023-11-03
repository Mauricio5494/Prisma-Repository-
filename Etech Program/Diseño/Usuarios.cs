using Diseño.Properties;
using Microsoft.ReportingServices.Diagnostics.Internal;
using MySql.Data.MySqlClient;
using MySql.Utility.Classes;
using MySql.Utility.Enums;
using MySql.Utility.Structs;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Diseño
{
    public partial class Usuarios : Form
    {
        //Variables:
        string trasnsicion;
        string clavePrimariaDelTecnico;
        private int idTecnico;
        public bool PassSucess;
        private string modificarAtributosDeUsuarios;


        DataBaseConnect connect = new DataBaseConnect();

        //Instancias
        DataTable dataTableUsuarios = new DataTable();
        MySqlConnection conn = DataBaseConnect.Conectarse();
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

            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

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
                    cmd = new MySqlCommand("SELECT ID, Nombre, Celular, CorreoElectronico, Telefono FROM usuarios WHERE Baja = 0 ", conn);
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
                cmd = new MySqlCommand("SELECT ID, Nombre, Celular, CorreoElectronico, Telefono FROM usuarios WHERE Baja = 0 ", conn);
                cmd.CommandType = System.Data.CommandType.Text;
                reader = cmd.ExecuteReader();
                dataTableUsuarios.Load(reader);
                label_BD_Mostrada.Text = "Mostrando Usuarios";
                label_BD_Mostrada.ForeColor = Color.ForestGreen;
            }
            catch
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
                                eliminarTecnico = $"UPDATE trabajos SET Baja = 0 WHERE ID_Tecnico = {idTecnico}; UPDATE celulares SET Baja = 0 WHERE ID_Usuario = {idTecnico}; DELETE FROM usuarios WHERE ID ={clavePrimariaDelTecnico};";
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
            trasnsicion = "FadeIn";
            timerTransicion.Start();

            MostrarBaseDeDatosDeLaTablaUsuarios();

            labelNota_panelBorrarTecnico.Text = "Nota:\n\nSi eliminas un técnico, se eliminarán\ntodos los celulares que se le \nasignaron al técnico en cuestión.";
            ayudaVisual.SetToolTip(btnEliminar_panelBorrarTecnico, "¿Estás Seguro?");
            ayudaVisual.SetToolTip(chbMostrarContraseña_PanelRegistro, "Ocultar o Mostrar contraseña");
            ayudaVisual.SetToolTip(chbOcultarContraseña_groupboxModificar_PanelModificar, "Ocultar o Mostrar contraseña");



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
                panel_Registro.Height = 600;
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

        //Finalmente, algo de seguridad en nuestro programa.
        private static string SHA256EncriptarContraseña(string teclado)
        {
            using (SHA256 cripto = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(teclado);
                byte[] hashbytes = cripto.ComputeHash(bytes);

                return BitConverter.ToString(hashbytes).Replace("-", "").ToLower();
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

            if (txtNombre.Text.Equals("") || txtPassword.Text.Equals("") || txtRepitaLaContraseña.Text.Equals("") || txtCorreo.Text.Equals("") || txtCelular.Text.Equals(""))
            {
                MessageBox.Show("No deje un campo de texto obligatorio en blanco", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                if (txtPassword.Text == txtRepitaLaContraseña.Text)
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

                                    sql_Registro = $"INSERT INTO usuarios(Nombre, Contraseña, Telefono, CorreoElectronico, Celular) VALUES (@Nombre, SHA2(@Contraseña, 256), @Telefono, @CorreoElectronico, @Celular)";
                                    cmd_Registro = new MySqlCommand(sql_Registro, conn);

                                    cmd_Registro.Parameters.AddWithValue("@Nombre", Nombre);
                                    cmd_Registro.Parameters.AddWithValue("@Contraseña", Password);
                                    cmd_Registro.Parameters.AddWithValue("@Telefono", Telefono);
                                    cmd_Registro.Parameters.AddWithValue("@CorreoElectronico", Correo);
                                    cmd_Registro.Parameters.AddWithValue("@Celular", Celular);

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
                                    MessageBox.Show("Fallo la conexion con el servidor o la base de datos\n\n" + E.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                                txtRepitaLaContraseña.Text = "";
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
                else
                {
                    MessageBox.Show("Las contraseñas no coinciden\n\nEscriba la misma contraseña arriba y abajo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        }

        private void Comprobacion()
        {
            try
            {
                conn.Open();


                sql_Seguridad = "SELECT Nombre, Contraseña FROM usuarios WHERE nombre ='@Nombre' AND contraseña ='@Contraseña'";
                cmd_Seguridad = new MySqlCommand(sql_Seguridad, conn);

                string contraseñaHash = SHA256EncriptarContraseña(txtPassword.Text);

                cmd_Seguridad.Parameters.AddWithValue("@Nombre", Nombre);
                cmd_Seguridad.Parameters.AddWithValue("@Contraseña", contraseñaHash);

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
            catch (Exception ex)
            {
                MessageBox.Show("Falló la conexion con el servidor o la base de datos\n\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                tabla_Usuarios.Columns["CorreoElectronico"].Width = 330;
                tabla_Usuarios.Columns["Celular"].Width = 79;

                //Renombres del texto descriptivo de las columnas necesarias.
                tabla_Usuarios.Columns["CorreoElectronico"].HeaderText = "Correo Electrónico";
                tabla_Usuarios.Columns["Nombre"].HeaderText = "Nombre de Usuario";

                //Tooltips
                tabla_Usuarios.Columns["ID"].ToolTipText = "El Identificador (ID) de cada usuario, este es único y no hay 2 iguales.";
                tabla_Usuarios.Columns["Nombre"].ToolTipText = "El nombre de usuario de cada cuenta creada.";
                tabla_Usuarios.Columns["CorreoElectronico"].ToolTipText = "El Correo Electrónico, este solo funciona como una forma de intentar contactar con dicho empleado";
                tabla_Usuarios.Columns["Telefono"].ToolTipText = "¡Hola! ¡Si, soy yo! Resulta que la Organización tiene teléfonos fijos... si... si... ¡Pero!.. Está bien... Te mantendré informado. El, Psy, Kongroo";
                tabla_Usuarios.Columns["Celular"].ToolTipText = "El número de teléfono, otra vía por donde contactar al empleado";
            }
            else
            {
                MessageBox.Show("Parece que cambió algo en las tablas\nasí que no se pudo cargarlas como es debido", "Algo salió mal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MessageBox.Show("¿Acaso alguien tocó la base de datos?\nEn cualquier caso, contacte con el Soporte Prisma", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        private void chbMostrarContraseña_PanelRegistro_CheckedChanged(object sender, EventArgs e)
        {
            if (chbMostrarContraseña_PanelRegistro.Checked == false)
            {
                //Se cambia la imagen y la sintaxis cambia a Asteriscos " * "
                picMostrar.Image = Resources.ojo_tapado;
                txtPassword.PasswordChar = '*';
                txtRepitaLaContraseña.PasswordChar = '*';
            }
            else
            {
                //Se cambia la imagen y la sintaxis cambia a letras y números
                picMostrar.Image = Resources.ojo;
                txtPassword.PasswordChar = '\0';
                txtRepitaLaContraseña.PasswordChar = '\0';
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




        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            DialogResult siono = MessageBox.Show("¿Estás seguro de Cerrar Sesión?", "Hmm...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (siono == DialogResult.Yes)
            {
                trasnsicion = "FadeOutRestart";
                timerTransicion.Start();
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
                trasnsicion = "FadeOut";
                timerTransicion.Start();
                mostrar.Show();
            }
        }

        private void btnClientes_groupBoxMenu_PanelMenu_Click(object sender, EventArgs e)
        {
            if (!ApareceLaContraseñaMaestra)
            {
                Clientes show = new Clientes();
                trasnsicion = "FadeOut";
                timerTransicion.Start();
                show.Show();
            }
            else
            {
                MessageBox.Show("Debe de cerrar todas las ventanas emergentes antes de cambiar de pantalla", "Cuidado", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void btnEstadisticas_groupboxManu_PanelMenu_Click(object sender, EventArgs e)
        {
            if (!ApareceLaContraseñaMaestra)
            {
                Estadisticas mostrar = new Estadisticas();
                trasnsicion = "FadeOut";
                timerTransicion.Start();
                mostrar.Show();
            }
            else
            {
                MessageBox.Show("Debe de cerrar todas las ventanas emergentes antes de cambiar de pantalla", "Cuidado", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void btnEstadisticas_Click(object sender, EventArgs e)
        {

        }

        private void btnModificar_groupBoxModificar_PanelModificar_Click(object sender, EventArgs e)
        {
            //People will be modified... starting tonight... i'm a man of my word.

            Confirmacion_Con_ContraseñaMaestro confirmacion = new Confirmacion_Con_ContraseñaMaestro();

            if (txtNombre_groupboxModificar_PanelModificar.Text != "" && txtContraseña_groupboxModificar_PanelModificar.Text != "" && txtCorreoElectronico_groupBoxModificar_PanelModificar.Text != "" && txtCelular_groupBoxModificar_PanelModificar.Text != "")
            {
                DialogResult siono = MessageBox.Show("¿Está seguro que desea modificar este usuario?", "Hmm...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (siono == DialogResult.Yes)
                {
                    confirmacion.Show();

                    confirmacion.FormClosing += (s, args) =>
                    {
                        if (confirmacion.PassBien)
                        {
                            try
                            {
                                conn.Open();
                                string query = $"UPDATE usuarios SET Nombre ='{txtNombre_groupboxModificar_PanelModificar.Text}', Contraseña ='{txtContraseña_groupboxModificar_PanelModificar.Text}', Telefono ='{txtTelefono_groupBoxModificar_PanelModificar.Text}', CorreoElectronico ='{txtCorreoElectronico_groupBoxModificar_PanelModificar.Text}', Celular ='{txtCelular_groupBoxModificar_PanelModificar.Text}' WHERE ID ={clavePrimariaDelTecnico}";
                                cmd = new MySqlCommand(query, conn);

                                try
                                {
                                    cmd.ExecuteNonQuery();
                                    MessageBox.Show("Los cambios se realizaron con éxito", "Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Error en la Base de Datos:\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("No se pudo realizar los cambios\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            finally
                            {
                                conn.Close();
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
                    MessageBox.Show("No se realizarán lo cambios", "Entendido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("No deje un campo de texto obligatorio vacío", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void Usuarios_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void tabla_Usuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow filaSeleccionada = tabla_Usuarios.Rows[e.RowIndex];

                string seleccion = filaSeleccionada.Cells["ID"].Value.ToString();

                try
                {
                    conn.Open();
                    string query = $"SELECT contraseña FROM Usuarios WHERE ID ={seleccion}";
                    cmd = new MySqlCommand(query, conn);
                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        string contraseña = reader["Contraseña"].ToString();
                        txtContraseña_groupboxModificar_PanelModificar.Text = contraseña;
                    }
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


                clavePrimariaDelTecnico = filaSeleccionada.Cells["ID"].Value.ToString();
                txtID_panelBorrarUsuarios.Text = clavePrimariaDelTecnico;

                string nombre = filaSeleccionada.Cells["Nombre"].Value.ToString();
                string correoElectronico = filaSeleccionada.Cells["CorreoElectronico"].Value.ToString();
                string telefonoOpcional = filaSeleccionada.Cells["Telefono"].Value.ToString();
                string celular = filaSeleccionada.Cells["Celular"].Value.ToString();

                labelDelID_groupBoxModificar_PanelModificar.Text = $"Selección: {clavePrimariaDelTecnico}";
                txtNombre_groupboxModificar_PanelModificar.Text = nombre;
                txtCorreoElectronico_groupBoxModificar_PanelModificar.Text = correoElectronico;
                txtTelefono_groupBoxModificar_PanelModificar.Text = telefonoOpcional;
                txtCelular_groupBoxModificar_PanelModificar.Text = celular;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
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

        private void txtCampo_Busqueda_TextChanged(object sender, EventArgs e)
        {
            string campoBusqueda = txtCampo_Busqueda.Text;

            if (txtCampo_Busqueda.Text != "")
            {
                string option = MenuOpciones.Text;
                switch (option)
                {
                    case "Nombre":

                        dataTableUsuarios.Rows.Clear();

                        try
                        {
                            conn.Open();
                            string query = $"SELECT ID, Nombre, Celular, CorreoElectronico, Telefono FROM Usuarios WHERE Nombre LIKE '%{campoBusqueda}%' AND Baja = 0";
                            cmd = new MySqlCommand(query, conn);
                            cmd.ExecuteNonQuery();
                            reader = cmd.ExecuteReader();
                            dataTableUsuarios.Load(reader);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al intentar buscar:\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            conn.Close();
                        }
                        tabla_Usuarios.DataSource = dataTableUsuarios;
                        break;

                    case "Celular":

                        dataTableUsuarios.Rows.Clear();
                        try
                        {
                            conn.Open();
                            string query = $"SELECT ID, Nombre, Celular, CorreoElectronico, Telefono FROM Usuarios WHERE Celular LIKE '%{campoBusqueda}%' AND Baja = 0";
                            cmd = new MySqlCommand(query, conn);
                            cmd.ExecuteNonQuery();
                            reader = cmd.ExecuteReader();
                            dataTableUsuarios.Load(reader);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al intentar buscar:\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                        finally
                        {
                            conn.Close();
                        }
                        tabla_Usuarios.DataSource = dataTableUsuarios;

                        break;

                    case "Correo Electrónico":

                        dataTableUsuarios.Rows.Clear();
                        try
                        {
                            conn.Open();
                            string query = $"SELECT ID, Nombre, Celular, CorreoElectronico, Telefono FROM Usuarios WHERE CorreoElectronico LIKE '%{campoBusqueda}%' AND Baja = 0";
                            cmd = new MySqlCommand(query, conn);
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al intentar buscar:\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                        finally
                        {
                            conn.Close();
                        }

                        tabla_Usuarios.DataSource = dataTableUsuarios;
                        break;

                    case "Telefono":

                        dataTableUsuarios.Rows.Clear();
                        try
                        {
                            conn.Open();
                            string query = $"SELECT ID, Nombre, Celular, CorreoElectronico, Telefono FROM Usuarios WHERE Telefono LIKE '%{campoBusqueda}%' AND Baja = 0";
                            cmd = new MySqlCommand(query, conn);
                            cmd.ExecuteNonQuery();
                            reader = cmd.ExecuteReader();
                            dataTableUsuarios.Load(reader);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al intentar buscar:\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                        finally
                        {
                            conn.Close();
                        }
                        tabla_Usuarios.DataSource = dataTableUsuarios;

                        break;

                    default:

                        break;
                }
            }
            else
            {
                MostrarBaseDeDatosDeLaTablaUsuariosd_SinMensajeDeError();
            }
        }
        private void MenuOpciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtCampo_Busqueda.Enabled == false)
            {
                txtCampo_Busqueda.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            trasnsicion = "FadeOutExit";
            timerTransicion.Start();
        }

        private void timerTransicion_Tick(object sender, EventArgs e)
        {
            if (trasnsicion == "FadeIn")
            {
                if (this.Opacity == 1)
                {
                    timerTransicion.Stop();
                }
                else
                {
                    this.Opacity += .15;
                }
            }
            else if (trasnsicion == "FadeOut")
            {
                if (this.Opacity == 0)
                {
                    timerTransicion.Stop();
                    this.Hide();
                }
                else
                {
                    if (this.WindowState == FormWindowState.Normal)
                    {
                        this.Opacity -= .15;
                        this.Left += 15;
                    }
                    else
                    {
                        this.Opacity -= .15;
                    }
                }
            }
            else if (trasnsicion == "FadeOutExit")
            {
                if (this.Opacity == 0)
                {
                    timerTransicion.Stop();
                    Application.Exit();
                }
                else
                {
                    if (this.WindowState == FormWindowState.Normal)
                    {
                        this.Opacity -= .15;
                        this.Left += 15;
                    }
                    else
                    {
                        this.Opacity -= .15;
                    }
                }
            }
            else if (trasnsicion == "FadeOutRestart")
            {
                if (this.Opacity == 0)
                {
                    timerTransicion.Stop();
                    Application.Restart();
                }
                else
                {
                    if (this.WindowState == FormWindowState.Normal)
                    {
                        this.Opacity -= .15;
                        this.Left += 15;
                    }
                    else
                    {
                        this.Opacity -= .15;
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(this.WindowState == FormWindowState.Normal) 
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
