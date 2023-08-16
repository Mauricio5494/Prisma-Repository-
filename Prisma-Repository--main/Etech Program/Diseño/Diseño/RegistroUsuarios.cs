using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            Correo = txtCorreo.Text;
            Telefono = txtTelefono.Text;
            Correo = txtCorreo.Text;
            Celular = txtCelular.Text;

            try
            {
                conn.Open();
                sql_Seguridad = "select Nombre, Contraseña from usuarios where nombre = '" + Nombre + "' and Contraseña = '" + Password + "' ";
                cmd_Seguridad = new MySqlCommand(sql_Seguridad, conn);
                reader = cmd_Seguridad.ExecuteReader();

                if (reader.Read())
                {
                    MessageBox.Show("Ya existe un usuario con esa informacion", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    if (txtNombre.Text != "" || txtPassword.Text != "" || txtCorreo.Text != "" || txtCorreo.Text != "" || txtCelular.Text != "")
                    {
                        sql_registro = "INSERT INTO usuarios (Nombre, Contraseña, Telefono, CorreoElectronico, Celular) values('" + Nombre + "', '" + Password + "', '" + Telefono + "', '" + Correo + "', '" + Celular + "')";
                        cmd_registro = new MySqlCommand(sql_registro, conn);
                        try
                        {
                            cmd_registro.ExecuteNonQuery();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("No pudo registrar el usuario", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No deje los campos obligatorios en blanco", "CUIDADO!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
            }
            catch 
            {
                MessageBox.Show("Fallo la conexion con la BD", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally 
            { 
                conn.Close();
            }
        }
    }
}
