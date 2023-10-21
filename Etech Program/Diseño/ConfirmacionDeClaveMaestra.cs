using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
        string contraseñaCorrecta = "123";
        public bool PassBien = false;
        private DialogResult dialogo = new DialogResult();

        //Métodos:
        Usuarios PassOK = new Usuarios();

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
            dialogo = DialogResult.Cancel;
            this.Close();
            PassBien = false;
        }
        public void ConfirmarContraseña()
        {

            if (txtClaveMaestra.Text == contraseñaCorrecta)
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
            else
            {

            }
            if (dialogo == DialogResult.OK && PassBien == false)
            {
                MessageBox.Show("Contraseña Incorrecta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
