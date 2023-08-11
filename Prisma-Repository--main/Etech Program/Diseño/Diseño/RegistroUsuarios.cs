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
    public partial class RegistroUsuarios : Form
    {
        //Atributos:
        string Nombre;
        string Password;
        string Correo;
        string NumCelular;
        string Telefono;
        public RegistroUsuarios()
        {
            InitializeComponent();
        }

        private void Registro_Load(object sender, EventArgs e)
        {

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
    }
}
