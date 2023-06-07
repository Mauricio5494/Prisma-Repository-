﻿using System;
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
            }
            else
            {
                panelD.Width = 45;
                btnAgregar.ForeColor = Color.DarkRed;
                btnModificar.ForeColor = Color.DarkRed;
                btnEliminar.ForeColor = Color.DarkRed;
                btnCerrarSesion.ForeColor = Color.DarkRed;
            }
        }

        private void panelD_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            DataBaseConnect dataBaseConnectSesion = new DataBaseConnect();
            dataBaseConnectSesion.desconectarse();
        }
    }
}
