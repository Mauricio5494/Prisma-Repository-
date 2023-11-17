using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diseño
{
    public partial class Confirmacion_Con_ContraseñaMaestro : Form
    {


        public Confirmacion_Con_ContraseñaMaestro()
        {
            InitializeComponent();
            this.FormClosing += Confirmacion_Con_ContraseñaMaestro_FormClosing;

        }

        //Constantes:
        private const char PassOUT = '*';

        //Variables:
        bool dragTrue;
        int mouseStartX;
        int mouseStartY;

        string contraseñaCorrecta = "eaa4cf3e46c2e825c9debc72e1a0bb299319836dbbc0837781496cc822f54429";
        public bool PassBien = false;
        private DialogResult dialogo = new DialogResult();

        //Métodos:
        Usuarios PassOK = new Usuarios();

        private static string SHA256EncriptarContraseña(string teclado)
        {
            using (SHA256 cripto = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(teclado);
                byte[] hashbytes = cripto.ComputeHash(bytes);

                return BitConverter.ToString(hashbytes).Replace("-", "").ToLower();
            }
        }

        private void OcultarContraseña()
        {
            if (chbOcultarContraseña.Checked)
            {
                txtClaveMaestra.PasswordChar = PassOUT;
            }
        }


        private void btnAceptar_Click(object sender, EventArgs e)
        {
            dialogo = DialogResult.OK;
            this.Close();
        }

        private void Confirmacion_Con_ContraseñaMaestro_Load(object sender, EventArgs e)
        {
            OcultarContraseña();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult siono = MessageBox.Show("¿Está seguro que quiere cancelar la operación?", "Hmm...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (siono == DialogResult.Yes)
            {
                dialogo = DialogResult.Cancel;
                this.Close();
                PassBien = false; 
            }
        }
        public void ConfirmarContraseña()
        {

            if (SHA256EncriptarContraseña(txtClaveMaestra.Text) == contraseñaCorrecta)
            {
                PassBien = true;
            }
            else
            {
                PassBien = false;
            }
        }

        private void Confirmacion_Con_ContraseñaMaestro_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dialogo == DialogResult.OK)
            {
                ConfirmarContraseña();
            }

            if (dialogo == DialogResult.OK && PassBien == false)
            {
                MessageBox.Show("Contraseña Incorrecta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void Confirmacion_Con_ContraseñaMaestro_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dragTrue = true;

                mouseStartX = e.X;
                mouseStartY = e.Y;
            }
        }

        private void Confirmacion_Con_ContraseñaMaestro_MouseUp(object sender, MouseEventArgs e)
        {
            dragTrue = false;
        }

        private void Confirmacion_Con_ContraseñaMaestro_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragTrue)
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
    }
}
