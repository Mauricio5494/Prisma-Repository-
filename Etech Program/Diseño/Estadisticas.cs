using System;
using System.Collections.Generic;
using System.Windows.Forms.DataVisualization.Charting;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace Diseño
{
    public partial class Estadisticas : Form
    {
        public Estadisticas()
        {
            InitializeComponent();

            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

        }
        //atributos:
        int celularesArreglados;
        string celularesArregladosConversion;
        int celularesAveriados;
        string celularesAveriadosConversion;
        int celularesProceso;
        string celularesProcesoConversion;
        int celularesEspera;
        string celularesEsperaConversion;
        string celularesArregladosConsulta = "SELECT COUNT(*) FROM celulares WHERE Estado = 'Arreglado'";
        string celularesAveriadosConsulta = "SELECT COUNT(*) FROM celulares WHERE Estado = 'Averiado'";
        string celularesProcesoConsulta = "SELECT COUNT(*) FROM celulares WHERE Estado = 'En espera'";
        string celularesEsperaConsulta = "SELECT COUNT(*) FROM celulares WHERE Estado = 'En proceso'";


        //instancias:
        MySqlConnection conn = DataBaseConnect.Conectarse();
        MySqlCommand cmd = new MySqlCommand();
        Series serie;

        //Arreglos y atributos:
        string[] seriesCelulares = {"C. Arreglados", "C. Averiados", "C. en proceso", "C. en espera"};

        //Codigo de lo graficos:
        private void mostrarGraficoCelulares()
        {
            try
            {
                conn.Open();
                cmd = new MySqlCommand(celularesArregladosConsulta, conn);
                celularesArregladosConversion = cmd.ExecuteScalar().ToString();
                celularesArreglados = int.Parse(celularesArregladosConversion);

                cmd = new MySqlCommand(celularesAveriadosConsulta, conn);
                celularesAveriadosConversion = cmd.ExecuteScalar().ToString();
                celularesAveriados = int.Parse(celularesAveriadosConversion);

                cmd = new MySqlCommand(celularesEsperaConsulta, conn);
                celularesEsperaConversion = cmd.ExecuteScalar().ToString();
                celularesEspera = int.Parse(celularesEsperaConversion);

                cmd = new MySqlCommand(celularesProcesoConsulta, conn);
                celularesProcesoConversion = cmd.ExecuteScalar().ToString();
                celularesProceso = int.Parse(celularesProcesoConversion);


                for (int i = 0; i < seriesCelulares.Length; i++)
                {
                    serie = graficoCelulares.Series.Add(seriesCelulares[i]);
                }
            }
            catch 
            {

            }
            finally
            {
                conn.Close();
                label_CelularesArreglados.Text = "Celulares arreglados: " + celularesArreglados.ToString();
                label_CelularesAveriados.Text = "Celulares averiados: " + celularesAveriados.ToString();
                label_CelularesEnEspera.Text = "celulares en espera: " + celularesEspera.ToString();
                label_CelularesEnProceso.Text = "celulares en proceso: " + celularesProceso.ToString();
            }
        }

        private void Estadisticas_Load(object sender, EventArgs e)
        {
            mostrarGraficoCelulares();
        }

        //Botones del Menu latera:
        private void btnMenu_Click(object sender, EventArgs e)
        {
            if (panelD.Size.Width == 45)
            {
                panelD.Width = 119;
                btnInformacion.ForeColor = Color.Black;
                btnMenuPrincipal_Panel.ForeColor = Color.Black;
                btnCerrarSesion.ForeColor = Color.Black;

                btnInformacion.BackColor = Color.FromArgb(255, 40, 40);
                btnMenuPrincipal_Panel.BackColor = Color.FromArgb(255, 40, 40);
                btnCerrarSesion.BackColor = Color.FromArgb(255, 40, 40);

                panel_Informacion.Location = new Point(122, 78);
                panel_Menu.Location = new Point(122, 78);
                tabIndex_Pestañas.Location = new Point(548, 78);
            }
            else
            {
                panelD.Width = 45;
                btnInformacion.ForeColor = Color.FromArgb(255, 40, 40);
                btnMenuPrincipal_Panel.ForeColor = Color.FromArgb(255, 40, 40);
                btnCerrarSesion.ForeColor = Color.FromArgb(255, 40, 40);

                btnInformacion.BackColor = Color.FromArgb(255, 40, 40);
                btnMenuPrincipal_Panel.BackColor = Color.FromArgb(255, 40, 40);
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

        private void btnTaller_Click(object sender, EventArgs e)
        {
            Principal show = new Principal();
            this.Hide();
            show.Show();

        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            Usuarios show = new Usuarios();
            this.Hide();
            show.Show();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            Clientes show = new Clientes();
            this.Hide();
            show.Show();
        }
    }
}
