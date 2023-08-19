using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Diseño
{
    public partial class RegistroUsuarios : Form
    {
        //Atributos:
        private bool existe_otra_cuenta;
        private string sql_Registro;
        private string sql_Seguridad;
        private string Nombre;
        private string Password;
        private string Correo;
        private string Celular;
        private string Telefono;

        //Instancias:
        MySqlConnection conn = DataBaseConnect.conectarse();
        MySqlCommand cmd_conn = new MySqlCommand();
        MySqlCommand cmd_Registro;
        MySqlCommand cmd_Seguridad;
        MySqlDataReader reader;
        MySqlDataReader comprobacion;

        public RegistroUsuarios()
        {
            InitializeComponent();
        }

        private void labelRegresar_MouseEnter(object sender, EventArgs e)
        {
            labelRegresar.ForeColor = Color.Black;
        }

        private void labelRegresar_MouseLeave(object sender, EventArgs e)
        {
            labelRegresar.ForeColor = Color.Gray;
        }

        private void labelRegresar_Click(object sender, EventArgs e)
        {
            Login mostrar = new Login();
            mostrar.Show();
            this.Hide();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
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
                    existe_otra_cuenta= false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Fallo la conexion con el servidor o la base de datos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally 
            { 
                conn.Close(); 
            }   
        }
    }
}
