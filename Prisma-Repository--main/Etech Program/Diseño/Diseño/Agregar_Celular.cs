using System;
using System.Windows.Forms;

namespace Diseño
{
    public partial class Agregar_Celular_Form : Form
    {
        public Agregar_Celular_Form()
        {
            InitializeComponent();
        }

        private void Agregar_Celular_Form_Load(object sender, EventArgs e)
        {
            DataBaseConnect dataBaseConnect = new DataBaseConnect();
            dataBaseConnect.conectarse();
        }
    }
}
