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
    public partial class Estadisticas : Form
    {
        public Estadisticas()
        {
            InitializeComponent();
        }

        //Botones del Menu latera:
        private void btnMenu_Click(object sender, EventArgs e)
        {
            if (panelD.Size.Width == 45)
            {
                panelD.Width = 119;
                btnInformacion.ForeColor = Color.Black;
                btnMenuPrincipal.ForeColor = Color.Black;
                btnCerrarSesion.ForeColor = Color.Black;

                btnInformacion.BackColor = Color.FromArgb(255, 40, 40);
                btnMenuPrincipal.BackColor = Color.FromArgb(255, 40, 40);
                btnCerrarSesion.BackColor = Color.FromArgb(255, 40, 40);

                panel_Informacion.Location = new Point(122, 78);
                panel_Menu.Location = new Point(122, 78);
                tabIndex_Pestañas.Location = new Point(548, 78);
            }
            else
            {
                panelD.Width = 45;
                btnInformacion.ForeColor = Color.FromArgb(255, 40, 40);
                btnMenuPrincipal.ForeColor = Color.FromArgb(255, 40, 40);
                btnCerrarSesion.ForeColor = Color.FromArgb(255, 40, 40);

                btnInformacion.BackColor = Color.FromArgb(255, 40, 40);
                btnMenuPrincipal.BackColor = Color.FromArgb(255, 40, 40);
                btnCerrarSesion.BackColor = Color.FromArgb(255, 40, 40);
                btnCerrarSesion.FlatStyle = FlatStyle.Flat;

                panel_Informacion.Location = new Point(49, 78);
                panel_Menu.Location = new Point(49, 78);
                tabIndex_Pestañas.Location = new Point(474, 78);
            }
        }

        private void btnInformacion_Click(object sender, EventArgs e)
        {
            if (panel_Informacion.Height < 600)
            {
                //Panel Informacion:
                panel_Informacion.Enabled = true;
                panel_Informacion.BringToFront();
                timer_Reducir_Informacion.Enabled = false;
                timer_Agrandar_Informacion.Enabled = true;

                //Panel Menu:
                panel_Menu.Enabled = false;
                panel_Menu.SendToBack();
                timer_Agrandar_Menu.Enabled = false;
                timer_Reducir_Menu.Enabled = true;
            }
            else
            {
                panel_Informacion.Enabled = false;
                panel_Informacion.SendToBack();
                timer_Agrandar_Informacion.Enabled = false;
                timer_Reducir_Informacion.Enabled = true;
            }
        }

        private void btnMenu_Principal_Click(object sender, EventArgs e)
        {
            if (panel_Menu.Height < 600)
            {
                //Panel Menu:
                panel_Menu.Enabled = true;
                panel_Menu.BringToFront();
                timer_Reducir_Menu.Enabled = false;
                timer_Agrandar_Menu.Enabled = true;

                //Panel Informacion:
                panel_Informacion.Enabled = false;
                panel_Informacion.SendToBack();
                timer_Agrandar_Informacion.Enabled = false;
                timer_Reducir_Informacion.Enabled = true;
            }
            else
            {
                panel_Menu.Enabled = false;
                panel_Menu.SendToBack();
                timer_Agrandar_Menu.Enabled = false;
                timer_Reducir_Menu.Enabled = true;
            }
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            DialogResult siono = MessageBox.Show("¿Estás seguro de Cerrar Sesión?", "Hmm...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (siono == DialogResult.Yes)
            {
                Application.Restart();
            }
        }

        //timers:
        private void timer_Agrandar_Menu_Tick(object sender, EventArgs e)
        {
            panel_Menu.Height = 600;
        }

        private void timer_Reducir_Menu_Tick(object sender, EventArgs e)
        {
            panel_Menu.Height = 0;
        }

        private void timer_Agrandar_Informacion_Tick(object sender, EventArgs e)
        {
            panel_Informacion.Height = 600;
        }
        private void timer_Reducir_Informacion_Tick(object sender, EventArgs e)
        {
            panel_Informacion.Height = 0;
        }
    }
}
