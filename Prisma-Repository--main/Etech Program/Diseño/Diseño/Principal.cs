using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Diseño
{
    public partial class Principal : Form
    {
        //variables/atributos de la clase:
        private bool invitado;

        //instancias:
        MySqlConnection conn = DataBaseConnect.conectarse();
        MySqlCommand cmd = new MySqlCommand();

        //Constructor
        public Principal()
        {
            InitializeComponent();
            invitado = true;
        }
        public bool Invitado
        {
            set { invitado = value; }
        } 

        private void MenuOpciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Método activador de el campo de busqueda y el botón de buscar si una opcion de filtro está seleccionada:
            txtCampo_Bsuqeda.Enabled = true;
            btnBuscar.Enabled = true;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            // Salta error para no crashear el programa:
            if (MenuOpciones.Text.Equals("") || txtCampo_Bsuqeda.Text == "")
            {
                MessageBox.Show("Antes de buscar seleccione una opción de filtro y escribe algo en el campo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Acá va la operación de búsqueda:
            }
        }

        //Método necesario para cerrar el programa si se cierra el Formulario, sino, solo se cierra y no termina el proceso.
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Conexion con la base de datos:
            try
            {
                conn.Open();
                cmd.Connection = conn;
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message + x.StackTrace);
            }
            finally 
            { 
                conn.Close(); 
            }
        }
        //Codigo referente al menu
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (invitado == false)
            {
               
            }
            else 
            {
                MessageBox.Show("Si quiere realizar cualquer cambio sobre la informacion debe ingresar como un usuario", "Un momento!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (panelD.Size.Width == 45)
            {
                panelD.Width = 120;
                btnAgregar.ForeColor = Color.White;
                btnModificar.ForeColor = Color.White;
                btnEliminar.ForeColor = Color.White;
                btnCerrarSesion.ForeColor = Color.White;
                btnAgregar.BackColor = Color.DarkRed;
                btnModificar.BackColor = Color.DarkRed;
                btnEliminar.BackColor = Color.DarkRed;
                btnCerrarSesion.BackColor = Color.DarkRed;

                btnAgregar.FlatStyle = FlatStyle.Popup;
                btnModificar.FlatStyle = FlatStyle.Popup;
                btnEliminar.FlatStyle = FlatStyle.Popup;
                btnCerrarSesion.FlatStyle = FlatStyle.Popup;
            }
            else
            {
                panelD.Width = 45;
                btnAgregar.ForeColor = Color.Firebrick;
                btnModificar.ForeColor = Color.Firebrick;
                btnEliminar.ForeColor = Color.Firebrick;
                btnCerrarSesion.ForeColor = Color.Firebrick;
                btnAgregar.BackColor = Color.Firebrick;
                btnCerrarSesion.BackColor = Color.Firebrick;
                btnEliminar.BackColor = Color.Firebrick;
                btnModificar.BackColor = Color.Firebrick;

                btnAgregar.FlatStyle = FlatStyle.Flat;
                btnModificar.FlatStyle = FlatStyle.Flat;
                btnEliminar.FlatStyle = FlatStyle.Flat;
                btnCerrarSesion.FlatStyle = FlatStyle.Flat;
            }
        }

        private void panelD_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            invitado = true;
            conn.Close();
            MessageBox.Show("Cerrando Sesión", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.Restart();
        }

        private void tableLayoutPanel1_MouseEnter(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            Utilidades utilidades = new Utilidades();
            utilidades.MostrarTest();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (invitado == false)
            {

            }
            else
            {
                MessageBox.Show("Si quiere realizar cualquer cambio sobre la informacion debe ingresar como un usuario", "Un momento!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (invitado == false)
            {

            }
            else
            {
                MessageBox.Show("Si quiere realizar cualquer cambio sobre la informacion debe ingresar como un usuario", "Un momento!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
    }
}
