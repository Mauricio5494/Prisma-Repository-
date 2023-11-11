using Diseño.Properties;
using K4os.Compression.LZ4.Streams;
using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Diseño
{
    public partial class Login : Form
    {
        //Atributos de la clase:
        private bool Invitado;
        private string Nombre;
        private string Password;
        string sql;
        string transicion;
        bool drag;
        int mouseStartX, mouseStartY;

        public Login()
        {
            InitializeComponent();

        }

        //Instancias:
        Principal Taller;
        ToolTip toolTip1 = new ToolTip();
        Utilidades Seguridad = new Utilidades();
        MySqlConnection conn = DataBaseConnect.Conectarse();
        MySqlCommand cmd_sql;
        MySqlDataReader reader;

        //Utilidades:
        bool userRootOk = false;
        bool passRootOK = false;

        //Método para cambiar la imágen del ojo y la sintaxis de ingreso de caracteres al TextBox de la Contraseña:
        private void checkBox1_CheckedChanged(object sender, System.EventArgs e)
        {
            if (checkBox1.Checked)
            {
                //Se cambia la imagen y la sintaxis cambia a letras y números
                picMostrar.Image = Resources.ojo;
                txtPass.PasswordChar = '\0';
            }
            else
            {
                //Se cambia la imagen y la sintaxis cambia a Asteriscos " * "
                picMostrar.Image = Resources.ojo_tapado;
                txtPass.PasswordChar = '*';
            }
        }

        //                       Un intento de hacer un decodificador y condificador de SHA256.
        //      ----------------------------------------------------------------------------------------------
        private static string DecoderDelHash(string teclado)
        {
            SHA256 sHA256 = SHA256.Create();

            byte[] bytesIngresados = Encoding.UTF8.GetBytes(teclado);
            byte[] bytesHash = sHA256.ComputeHash(bytesIngresados);

            StringBuilder uruguayo = new StringBuilder();

            for (int i = 0; i < bytesHash.Length; i++)
            {
                uruguayo.Append(bytesHash[i].ToString("x2"));
            }
            return uruguayo.ToString();
        }

        private static string EncoderDelHash(string teclado)
        {
            SHA256 sha256 = SHA256.Create();

            byte[] bytesIngresados = Encoding.UTF8.GetBytes(teclado);
            byte[] bytesHash = sha256.ComputeHash(bytesIngresados);

            return BitConverter.ToString(bytesHash).Replace("-", "").ToLower();
        }

        //      ----------------------------------------------------------------------------------------------

        private void btnIngreso_Click(object sender, System.EventArgs e)
        {
            Taller = new Principal();
            Nombre = txtNombre.Text;
            Password = txtPass.Text;

            //Conexion con la base de datos:
            try
            {
                conn.Open();

                sql = $"SELECT Nombre, Contraseña FROM usuarios WHERE Nombre = @Nombre AND Contraseña = SHA2(@Password, 256)";
                cmd_sql = new MySqlCommand(sql, conn);

                cmd_sql.Parameters.AddWithValue("@Nombre", Nombre);
                cmd_sql.Parameters.AddWithValue("@Password", Password);

                reader = cmd_sql.ExecuteReader();

                try
                {
                    try
                    {
                        if (reader.Read())
                        {
                            Seguridad.SetInvitado = false;
                            transicion = "FadeOut";
                            timer_AparecerSuavemente.Start();
                            Taller.Show();
                        }
                        else
                        {
                            MessageBox.Show("Usuario o contraseña incorrectos\n\nVerifique los datos y vuelva a intentar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error\n\n" + ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("El lector no puede leer\n\n" + ex.Message);
                }
            }
            catch (Exception b)
            {
                MessageBox.Show("Fallo la conexion con la base de datos.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(b.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        private void btnInvitado_Click(object sender, EventArgs e)
        {
            //Menu mostrar = new Menu();
            Principal Taller = new Principal();
            Taller.Show();
            Seguridad.SetInvitado = true;
            this.Hide();
        }

        //Métodos relacionados con el apartado visual del programa que lo hacen mas intuitivo (no afectan las funcionalidades):
        private void Form2_Load(object sender, System.EventArgs e)
        {
            txtNombre.Text = "Nombre del Empleado...";
            txtNombre.ForeColor = Color.Black;

            transicion = "FadeIn";
            this.Top = this.Top + 20;
            timer_AparecerSuavemente.Start();

        }

        private void checkBox1_MouseEnter(object sender, System.EventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                toolTip1.SetToolTip(checkBox1, "Mostrar Constraseña");

            }
            else if (checkBox1.Checked)
            {
                toolTip1.SetToolTip(checkBox1, "Ocultar Contraseña");
            }
            else
            {

            }
        }

        private void txtNombre_Enter(object sender, System.EventArgs e)
        {
            txtNombre.ForeColor = Color.Black;
            if (txtNombre.Text == "Nombre del Empleado...")
            {

            }
        }

        private void txtNombre_Leave(object sender, System.EventArgs e)
        {
            if (txtNombre.Text == "")
            {
                txtNombre.Text = "Nombre del Empleado...";
                txtNombre.ForeColor = Color.Gray;
            }
        }


        private void LabelRegistrarse_MouseEnter(object sender, EventArgs e)
        {
            LabelRegistrarse.ForeColor = Color.DodgerBlue;
            toolTip1.SetToolTip(LabelRegistrarse, "Ingrese el usuario y contraseña que el equipo\nPrisma le ha proporcionado, luego podrá registar usuarios");
        }

        private void LabelRegistrarse_MouseLeave(object sender, EventArgs e)
        {
            LabelRegistrarse.ForeColor = Color.Blue;
        }

        private void LabelRegistrarse_Click(object sender, EventArgs e)
        {

            //Se supone que igual esto es un ejemplo para poder hacer que el programa sea más seguro, sino cualquiera entra, mete un usuario y ve la BD.

            //if (txtNombre.Text.Equals("etech"))
            //{
                ////userRootOk = true;
            //}
            //else
            //{
                //MessageBox.Show("Usuario Incorrecto", "Dato Erroneo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //}

            //if (txtPass.Text.Equals("123"))
            //{
                //passRootOK = true;
            //}
            //else
            //{
                //MessageBox.Show("Contraseña Incorrecta", "Dato Erroneo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //}

            ////if (userRootOk && passRootOK)
            //{
                RegistroUsuarios mostrar = new RegistroUsuarios();
                transicion = "FadeOut";
                timer_AparecerSuavemente.Start();
                mostrar.Show();
            //}

            //Si, ya se que se puede acortar el código, pero es solo un ejemplo... de momento.

        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        //Tooltips:

        private void button1_MouseEnter(object sender, System.EventArgs e)
        {
            toolTip1.SetToolTip(btnInvitado, "Entra como invitado, solo tienes permiso de ver.");
        }

        private void txtPass_MouseEnter(object sender, System.EventArgs e)
        {
            toolTip1.SetToolTip(txtPass, "La contraseña!.");
        }

        private void txtNombre_MouseEnter(object sender, System.EventArgs e)
        {
            toolTip1.SetToolTip(txtNombre, "Acá va su nombre de Usuario.");
        }

        private void timer_AparecerSuavemente_Tick(object sender, EventArgs e)
        {
            if (transicion == "FadeOut")
            {
                if (this.Opacity == 0)
                {
                    timer_AparecerSuavemente.Stop();
                    this.Hide();
                }
                else
                {
                    this.Opacity = this.Opacity - .15;
                    this.Top = this.Top - 3;
                }
            }
            else if (transicion == "FadeIn")
            {
                if (this.Opacity == 1)
                {
                    timer_AparecerSuavemente.Stop();
                }
                else
                {
                    this.Opacity = this.Opacity + .15;
                    this.Top = this.Top + 3;
                }
            }
            else if (transicion == "FadeOutExit")
            {
                if (this.Opacity == 0)
                {
                    timer_AparecerSuavemente.Stop();
                    Application.Exit();
                }
                else
                {
                    this.Opacity = this.Opacity - .15;
                    this.Left = this.Left + 3;
                }
            }
            
        }

        private void btn_Cerrar_Click(object sender, EventArgs e)
        {
            transicion = "FadeOutExit";
            timer_AparecerSuavemente.Start();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            if (txtNombre.Text == "Nombre del Empleado...")
            {
                txtNombre.SelectionStart = txtNombre.Text.Length;
                txtNombre.SelectionLength = 0;
                txtNombre.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Minimized;
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
        }
    }
}
