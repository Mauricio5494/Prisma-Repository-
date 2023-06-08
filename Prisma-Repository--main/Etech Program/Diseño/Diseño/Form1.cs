using System;
using System.Drawing;
using System.Windows.Forms;

namespace Diseño
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
            DataBaseConnect dataBaseConnect = new DataBaseConnect();
            dataBaseConnect.conectarse();
        }
        //Codigo referente al menu
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Agregar_Celular_Form mostrar = new Agregar_Celular_Form();
            mostrar.Show();
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

            }
        }

        private void panelD_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            DataBaseConnect dataBaseConnectSesion = new DataBaseConnect();
            dataBaseConnectSesion.desconectarse();
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
    }
}
