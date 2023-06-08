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

        private void btnPassAyuda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Si el teléfono tiene un tipo de contraseña como:\n\nContraseña:\nEste tipo de contraseña se caracteriza por tener\ntanto letras" +
                " como números y/o símbolos\n\nPatrón:\nEste tipo de contraseña es de la que tiene que unir puntos en una matríz de 3x3\nen este caso va a necesitar" +
                " poner el patrón de forma numérica contando como el punto número uno, el primero de arriba a la izquierda y el punto 9\n como el último" +
                " de abajo a la derecha.\nPor ejemplo, si mi patrón empieza por" +
                " el punto del medio, entonces tendría que dijitar primero el 5, luego" +
                " el siguiente y así.\n\nNumérico:\n ete tipo de contraseña es la típica de solo números.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
