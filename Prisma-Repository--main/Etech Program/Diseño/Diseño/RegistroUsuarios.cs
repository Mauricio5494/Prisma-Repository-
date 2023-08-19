using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Diseño
{
    public partial class RegistroUsuarios : Form
    {
        //Atributos:
        string sql_registro;
        string sql_Seguridad;
        string Nombre;
        string Password;
        string Correo;
        string Celular;
        string Telefono;

        //Instancias:
        MySqlConnection conn = DataBaseConnect.conectarse();
        MySqlCommand cmd_conn = new MySqlCommand();
        MySqlCommand cmd_registro;
        MySqlCommand cmd_Seguridad;
        MySqlDataReader reader;

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
            Nombre = txtNombre.Text;
            Password = txtPassword.Text;
            Telefono = txtTelefono.Text;
            Correo = txtCorreo.Text;
            Celular = txtCelular.Text;
            if (txtNombre.Text.Equals("") || txtPassword.Text.Equals("") || txtCorreo.Text.Equals("") || txtCelular.Text.Equals(""))
            {
                MessageBox.Show("No deje campos de texto obligatorios en blanco", "CUIDADO!!!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                try
                {
                    conn.Open();
                    sql_registro = "INSERT INTO usuarios(Nombre, Contraseña, Telefono, CorreoElectronico, Celular) VALUE('" + Nombre + "', '" + Password + "', '" + Telefono + "', '" + Correo + "', '" + Celular + "')";
                    sql_Seguridad = "SELECT Nombre, Contraseña from usuarios where nombre = '" + Nombre + "' and Contraseña = '" + Password + "' ";
                    cmd_Seguridad = new MySqlCommand(sql_Seguridad, conn);
                    cmd_registro = new MySqlCommand(sql_registro, conn);
                    reader = cmd_registro.ExecuteReader();

                    if (reader.Read())
                    {
                        MessageBox.Show("Los datos que ingreso coinciden con otras cuentas", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        try
                        {
                            cmd_registro.ExecuteNonQuery();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("No se puedo registrar el usuario", "UPS...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch
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
}
