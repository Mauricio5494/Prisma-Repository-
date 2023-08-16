﻿using Diseño.Properties;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System;
using System.Security.Cryptography;

namespace Diseño
{
    public partial class Login : Form
    {
        //Atributos de la clase:
        private bool Invitado;
        private string nombre;
        private string password;
        string sql;

        public Login()
        {
            InitializeComponent();

        }

        //Instancias:
        ToolTip toolTip1 = new ToolTip();
        Utilidades Seguridad = new Utilidades();
        MySqlConnection conn = DataBaseConnect.conectarse();
        MySqlCommand cmd_conn = new MySqlCommand();
        MySqlCommand cmd_sql;
        MySqlDataReader reader;
        Principal Taller = new Principal();
        

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
            nombre = txtNombre.Text;
            password = txtPass.Text;

            //Conexion con la base de datos:
            try
            {
                conn.Open();
                cmd_conn.Connection = conn;
                sql = "select Nombre, Contraseña from usuarios where nombre = '" + nombre + "' and Contraseña = '" + password + "' ";
                cmd_sql = new MySqlCommand(sql, conn);
                reader = cmd_sql.ExecuteReader();
                if (reader.Read())
                {
                    Seguridad.SetInvitado = false;
                    Taller.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("No encontramos ninguna cuenta que coincida exactamente con los datos que ingresaste", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception b)
            {
                MessageBox.Show("Fallo la conexion con el servidor o la base de datos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
            finally
            {
                conn.Close();
            }
        }
        private void btnInvitado_Click(object sender, EventArgs e)
        {
            //Menu mostrar = new Menu();
            Taller.Show();
            Seguridad.SetInvitado = true;
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

        private void LabelRegistrarse_MouseEnter(object sender, EventArgs e)
        {
            LabelRegistrarse.ForeColor = Color.DodgerBlue;
        }

        private void LabelRegistrarse_MouseLeave(object sender, EventArgs e)
        {
            LabelRegistrarse.ForeColor = Color.Blue;
        }

        private void LabelRegistrarse_Click(object sender, EventArgs e)
        {
            RegistroUsuarios mostrar = new RegistroUsuarios();
            mostrar.Show();
            this.Hide();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
