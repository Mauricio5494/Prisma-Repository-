using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Diseño
{
    public partial class Agregar_Celular_Form : Form
    {
        public Agregar_Celular_Form()
        {
            InitializeComponent();
        }

        //variables/atributos de la clase:
        string marca;
        string modelo;
        string problema;
        string estado;
        bool tiene_password;
        string tipoPassword;
        string password;

        //Instancias:
        MySqlConnection conn = DataBaseConnect.conectarse();
        MySqlCommand cmd = new MySqlCommand();

        private void Agregar_Celular_Form_Load(object sender, EventArgs e)
        {
            
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

        private void btnAgregarCel_Click(object sender, EventArgs e)
        {
            try
            {
                //Conexion con la base de datos:
                conn.Open();
                cmd.Connection = conn;

                //inicializacion de los atributos:
                marca = txtMarca.Text;
                modelo = txtModelo.Text;
                problema = txtProblema.Text;

                if (rbEnReparacion.Checked)
                {
                    estado = "En reparacion";
                }
                else if (rbEnEspera.Checked)
                {
                    estado = "En espera";
                }
                else
                {
                    estado = "otro...";
                }

                if (rbNoTieneContraseña.Checked)
                {
                    tiene_password = false;
                }
                else
                {
                    tiene_password = true;
                }

                if (rdContraseña.Checked)
                {
                    password = txtContraseña.Text;
                }
                else
                {
                    password = "";
                }

                //consulta Sql:
                cmd.CommandText = ($"(insert into celular() values())");
                cmd.ExecuteNonQuery();
            }
            catch (Exception x)
            {
                MessageBox.Show("Ocurrio un error al hacer la consulta Sql necesarias", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(x.Message, x.StackTrace);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
