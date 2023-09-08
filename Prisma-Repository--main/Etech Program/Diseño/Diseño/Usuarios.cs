using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Diseño
{
    public partial class Usuarios : Form
    {

        //Instancias:
        DataTable dataTableUsuarios = new DataTable();
        MySqlConnection conn = DataBaseConnect.conectarse();
        MySqlCommand cmd = new MySqlCommand();
        MySqlCommand cmd_Registro;
        MySqlCommand cmd_Seguridad;
        MySqlDataReader reader;
        ToolTip ayudaVisual = new ToolTip();
        //Utilidades:


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

        private void mostrarBaseDeDatosDeLaTablaUsuarios()
        {
            try
            {
                /*tabla_Usuarios.Rows.Clear();*/   /*<-- Ésta línea era la que estaba dando problemas, como un bug porque se recargaba y funciona, pero terminaba en catch.*/
                conn.Open();
                cmd = new MySqlCommand("SELECT * FROM usuarios", conn);
                cmd.CommandType = System.Data.CommandType.Text;
                reader = cmd.ExecuteReader();
                dataTableUsuarios.Load(reader);
                label_BD_Mostrada.Text = "Mostrando Usuarios";  
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo contectar con la Base de Datos", "FATAL ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(ex.Message, "Información acerca del Error", MessageBoxButtons.OK,MessageBoxIcon.Information);
                label_BD_Mostrada.Text = "No se pudo mostrar la Tabla";
                label_BD_Mostrada.ForeColor = System.Drawing.Color.Red;
            }
            finally
            {
                conn.Close();
            }
            tabla_Usuarios.DataSource = dataTableUsuarios;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }
        private void btnRecargar_Click(object sender, EventArgs e)
        {
            
            mostrarBaseDeDatosDeLaTablaUsuarios();

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
                btnAgregar.BackColor = Color.DarkRed;
                btnModificar.BackColor = Color.DarkRed;
                btnEliminar.BackColor = Color.DarkRed;
                btnCerrarSesion.BackColor = Color.DarkRed;
                btnMenuPrincipal.BackColor = Color.DarkRed;

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
            mostrarBaseDeDatosDeLaTablaUsuarios();

            panel_Registro.Height = 0;
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
            mostrarBaseDeDatosDeLaTablaUsuarios();
        }
    }
}
