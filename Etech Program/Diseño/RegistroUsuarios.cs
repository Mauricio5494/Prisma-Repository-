using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
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
        private bool ApareceLaContraseñaMaestra;
        private string transicion;

        //Instancias:
        MySqlConnection conn = DataBaseConnect.Conectarse();
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
            transicion = "FadeOut";
            timer_transicion.Start();
            mostrar.Show();
        }



        private static string EncoderDelHash(string teclado)
        {
            SHA256 sha = SHA256.Create();

            byte[] byteTeclado = Encoding.UTF8.GetBytes(teclado);
            byte[] bytesHash = sha.ComputeHash(byteTeclado);

            return BitConverter.ToString(bytesHash).Replace("-", "").ToLower();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
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

                                string contraseñaHash = EncoderDelHash(Password);


                                sql_Registro = $"INSERT INTO usuarios(Nombre, Contraseña, Telefono, CorreoElectronico, Celular) VALUES (@Nombre, @Contraseña, @Telefono, @CorreoElectronico, @Celular)";
                                cmd_Registro = new MySqlCommand(sql_Registro, conn);

                                cmd_Registro.Parameters.AddWithValue("@Nombre", Nombre);
                                cmd_Registro.Parameters.AddWithValue("@Contraseña", contraseñaHash);
                                cmd_Registro.Parameters.AddWithValue("@Telefono", Telefono);
                                cmd_Registro.Parameters.AddWithValue("@CorreoElectronico", Correo);
                                cmd_Registro.Parameters.AddWithValue("@Celular", Celular);

                                Console.WriteLine(contraseñaHash);

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
                sql_Seguridad = "SELECT Nombre, Contraseña FROM usuarios WHERE nombre = '" + Nombre + "' and Contraseña = '" + Password + "' ";
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

        private void RegistroUsuarios_FormClosed(object sender, FormClosedEventArgs e)
        {
            transicion = "FadeOutExit";
            timer_transicion.Start();
        }

        private void checkBox_MostrarContraseña_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox_MostrarContraseña.Checked)
            {
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '*';
            }
        }
        private void RegistroUsuarios_Load(object sender, EventArgs e)
        {
            transicion = "FadeIn";
            timer_transicion.Start();
        }

        private void timer_transicion_Tick(object sender, EventArgs e)
        {
            if (transicion == "FadeIn")
            {
                if (this.Opacity == 1)
                {
                    timer_transicion.Stop();
                }
                else
                {
                    this.Opacity = this.Opacity + .15;
                }
            }
            else if (transicion == "FadeOut")
            {
                if (this.Opacity == 1)
                {
                    timer_transicion.Stop();
                    this.Hide();
                }
                else
                {
                    this.Opacity = this.Opacity - .15;
                }
            }
            else if (transicion == "FadeOutExit")
            {
                if (this.Opacity == 0)
                {
                    timer_transicion.Stop();
                    Application.Restart();
                }
                else
                {
                    this.Opacity -= .15;
                    this.Top += 15;
                }
            }
        }

    }
}
