using Diseño.Properties;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System;
using System.Security.Cryptography;

namespace Diseño
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

        }
        ToolTip toolTip1 = new ToolTip();

        //Atributos de la clase:
        string ID = null;
        string password = null;

        //Instancias:
        MySqlConnection conn = DataBaseConnect.conectarse();
        MySqlCommand cmd = new MySqlCommand();
        Form1 Form1 = new Form1();

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

        private void btnIngreso_Click(object sender, System.EventArgs e)
        {
            //Conexion con la base de datos:
            try
            {
                conn.Open();
                cmd.Connection = conn;
                Form1.Invitado = false;
            }
            catch (Exception b)
            {
                MessageBox.Show(b.Message + b.StackTrace);
            } 
            finally
            {
                conn.Close();
            }
        }
        private void btnInvitado_Click(object sender, EventArgs e)
        {
            Form1.Invitado = true;
            Form1 mostrar = new Form1();
            mostrar.Show();
            this.Hide();
        }

        //Métodos relacionados con el apartado visual del programa que lo hacen mas intuitivo (no afectan las funcionalidades):
        private void Form2_Load(object sender, System.EventArgs e)
        {
            txtNombre.Text = "ID de Empleado...";
            txtNombre.ForeColor = Color.Gray;
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
            if (txtNombre.Text == "ID de Empleado...")
            {
                txtNombre.Text = "";

            }
        }

        private void txtNombre_Leave(object sender, System.EventArgs e)
        {
            if (txtNombre.Text == "")
            {
                txtNombre.Text = "ID de Empleado...";
                txtNombre.ForeColor = Color.Gray;
            }
        }

        private void button1_MouseEnter(object sender, System.EventArgs e)
        {
            toolTip1.SetToolTip(btnInvitado, "Entra como invitado, solo tienes permiso de ver.");
        }

        private void txtPass_MouseEnter(object sender, System.EventArgs e)
        {
            toolTip1.SetToolTip(txtPass, "La contraseña que ustéd ha elegido, o que \nsu Jefe o Empleador le ha proporcionado.");
        }

        private void txtNombre_MouseEnter(object sender, System.EventArgs e)
        {
            toolTip1.SetToolTip(txtNombre, "Acá va el ID que le proporcionó su Jefe o Empleador.");
        }
    }
}
