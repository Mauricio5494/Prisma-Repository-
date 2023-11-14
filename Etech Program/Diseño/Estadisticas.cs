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
        double TotalDeCelulares;
        double celularesArreglados;
        double celularesArregladosPorcentaje;
        double celularesArregladosSinDecimales;
        string celularesArregladosConversion;
        double celularesAveriados;
        double celularesAveriadosPorcentaje;
        double celularesAveriadosSinDecimales;
        string celularesAveriadosConversion;
        double celularesProceso;
        double celularesProcesoPorcentaje;
        double celularesProcesoSinDecimales;
        string celularesProcesoConversion;
        double celularesEspera;
        double celularesEsperaPorcentaje;
        double celularesEsperaSinDecimales;
        string celularesEsperaConversion;
        bool dragTrue = false;
        bool maxim;
        int mouseStartX, mouseStartY;
        string transicion;

        string celularesArregladosConsulta;
        string celularesAveriadosConsulta;
        string celularesProcesoConsulta;
        string celularesEsperaConsulta;

        string celularesArregladosDeBaja;
        string celularesAveriadosDeBaja;
        string celularesProcesoDeBaja; 
        string celularesEsperaDeBaja;
        int intervaloMeses;


        //instancias:
        MySqlConnection conn = DataBaseConnect.Conectarse();
        MySqlCommand cmd = new MySqlCommand();
        Series serie;

        //Arreglos y atributos:
        string[] seriesCelulares = { "Celulares arreglados", "Celulares averiados", "Celulares en proceso", "Celulares en espera" };
        double[] PointsCelulares = new double[4];

        //Codigo de lo graficos:
        private void mostrarGraficoCelulares()
        {
            graficoCelulares.Series["Series1"].Points.Clear();
            if (!checkBoxCelularesBaja.Checked)
            {
                try
                {
                    conn.Open();
                    cmd = new MySqlCommand(celularesArregladosConsulta, conn);

                    celularesArregladosConversion = cmd.ExecuteScalar().ToString();
                    celularesArreglados = double.Parse(celularesArregladosConversion);
                    PointsCelulares[0] = celularesArreglados;


                    cmd = new MySqlCommand(celularesAveriadosConsulta, conn);

                    celularesAveriadosConversion = cmd.ExecuteScalar().ToString();
                    celularesAveriados = double.Parse(celularesAveriadosConversion);
                    PointsCelulares[1] = celularesAveriados;


                    cmd = new MySqlCommand(celularesEsperaConsulta, conn);

                    celularesEsperaConversion = cmd.ExecuteScalar().ToString();
                    celularesEspera = double.Parse(celularesEsperaConversion);
                    PointsCelulares[2] = celularesEspera;


                    cmd = new MySqlCommand(celularesProcesoConsulta, conn);

                    celularesProcesoConversion = cmd.ExecuteScalar().ToString();
                    celularesProceso = double.Parse(celularesProcesoConversion);
                    PointsCelulares[3] = celularesProceso;


                    for (int i = 0; i < seriesCelulares.Length; i++)
                    {
                        graficoCelulares.Series["Series1"].Points.AddXY(seriesCelulares[i], PointsCelulares[i]);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error inesperado" + ex.Message);
                }
                finally
                {
                    conn.Close();
                    label_CelularesArreglados.Text = "Celulares arreglados: " + celularesArreglados.ToString();
                    label_CelularesAveriados.Text = "Celulares averiados: " + celularesAveriados.ToString();
                    label_CelularesEnEspera.Text = "celulares en espera: " + celularesEspera.ToString();
                    label_CelularesEnProceso.Text = "celulares en proceso: " + celularesProceso.ToString();
                    conn.Close();
                }

                TotalDeCelulares = celularesArreglados + celularesAveriados + celularesEspera + celularesProceso;

                celularesArregladosPorcentaje = (celularesArreglados / TotalDeCelulares) * 100;
                celularesArregladosSinDecimales = Math.Floor(celularesArregladosPorcentaje);
                celularesAveriadosPorcentaje = (celularesAveriados / TotalDeCelulares) * 100;
                celularesAveriadosSinDecimales = Math.Floor(celularesAveriadosPorcentaje);
                celularesEsperaPorcentaje = (celularesEspera / TotalDeCelulares) * 100;
                celularesEsperaSinDecimales = Math.Floor(celularesEsperaPorcentaje);
                celularesProcesoPorcentaje = (celularesProceso / TotalDeCelulares) * 100;
                celularesProcesoSinDecimales = Math.Floor(celularesProcesoPorcentaje);

                labelArreglados_Porcentaje.Text = "El " + celularesArregladosSinDecimales + "% de los celulares estan arreglados";
                labelAveriados_Porcentaje.Text = "El " + celularesAveriadosSinDecimales + "% de los celulares estan averiados";
                labelEspera_Porcentaje.Text = "El " + celularesEsperaSinDecimales + "% de los celulares estan en espera";
                labelProceso_Porcentaje.Text = "El " + celularesEsperaSinDecimales + "% de los celulares estan en espera"; 
            }
            else if (checkBoxCelularesBaja.Checked)
            {
                try
                {
                    conn.Open();
                    cmd = new MySqlCommand(celularesArregladosDeBaja, conn);

                    celularesArregladosConversion = cmd.ExecuteScalar().ToString();
                    celularesArreglados = double.Parse(celularesArregladosConversion);
                    PointsCelulares[0] = celularesArreglados;


                    cmd = new MySqlCommand(celularesAveriadosDeBaja, conn);

                    celularesAveriadosConversion = cmd.ExecuteScalar().ToString();
                    celularesAveriados = double.Parse(celularesAveriadosConversion);
                    PointsCelulares[1] = celularesAveriados;


                    cmd = new MySqlCommand(celularesEsperaDeBaja, conn);

                    celularesEsperaConversion = cmd.ExecuteScalar().ToString();
                    celularesEspera = double.Parse(celularesEsperaConversion);
                    PointsCelulares[2] = celularesEspera;


                    cmd = new MySqlCommand(celularesProcesoDeBaja, conn);

                    celularesProcesoConversion = cmd.ExecuteScalar().ToString();
                    celularesProceso = double.Parse(celularesProcesoConversion);
                    PointsCelulares[3] = celularesProceso;


                    for (int i = 0; i < seriesCelulares.Length; i++)
                    {
                        graficoCelulares.Series["Series1"].Points.AddXY(seriesCelulares[i], PointsCelulares[i]);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error inesperado" + ex.Message);
                }
                finally
                {
                    conn.Close();
                    label_CelularesArreglados.Text = "Celulares arreglados: " + celularesArreglados.ToString();
                    label_CelularesAveriados.Text = "Celulares averiados: " + celularesAveriados.ToString();
                    label_CelularesEnEspera.Text = "celulares en espera: " + celularesEspera.ToString();
                    label_CelularesEnProceso.Text = "celulares en proceso: " + celularesProceso.ToString();
                    conn.Close();
                }

                TotalDeCelulares = celularesArreglados + celularesAveriados + celularesEspera + celularesProceso;

                celularesArregladosPorcentaje = (celularesArreglados / TotalDeCelulares) * 100;
                celularesArregladosSinDecimales = Math.Floor(celularesArregladosPorcentaje);
                celularesAveriadosPorcentaje = (celularesAveriados / TotalDeCelulares) * 100;
                celularesAveriadosSinDecimales = Math.Floor(celularesAveriadosPorcentaje);
                celularesEsperaPorcentaje = (celularesEspera / TotalDeCelulares) * 100;
                celularesEsperaSinDecimales = Math.Floor(celularesEsperaPorcentaje);
                celularesProcesoPorcentaje = (celularesProceso / TotalDeCelulares) * 100;
                celularesProcesoSinDecimales = Math.Floor(celularesProcesoPorcentaje);

                labelArreglados_Porcentaje.Text = "El " + celularesArregladosSinDecimales + "% de los celulares estan arreglados";
                labelAveriados_Porcentaje.Text = "El " + celularesAveriadosSinDecimales + "% de los celulares estan averiados";
                labelEspera_Porcentaje.Text = "El " + celularesEsperaSinDecimales + "% de los celulares estan en espera";
                labelProceso_Porcentaje.Text = "El " + celularesEsperaSinDecimales + "% de los celulares estan en espera";
            }
        }

        private void Estadisticas_Load(object sender, EventArgs e)
        {

            celularesArregladosConsulta = $"SELECT COUNT(*) FROM celulares WHERE Estado = 'Arreglado' AND Ingreso >= DATE_SUB(CURDATE(), INTERVAL {intervaloMeses} MONTH) AND Baja = 0";
            celularesAveriadosConsulta = $"SELECT COUNT(*) FROM celulares WHERE Estado = 'Averiado' AND Ingreso >= DATE_SUB(CURDATE(), INTERVAL {intervaloMeses} MONTH) AND Baja = 0";
            celularesProcesoConsulta = $"SELECT COUNT(*) FROM celulares WHERE Estado = 'En Proceso' AND Ingreso >= DATE_SUB(CURDATE(), INTERVAL {intervaloMeses} MONTH) AND Baja = 0";
            celularesEsperaConsulta = $"SELECT COUNT(*) FROM celulares WHERE Estado = 'En espera' AND Ingreso >= DATE_SUB(CURDATE(), INTERVAL {intervaloMeses} MONTH) AND Baja = 0";

            celularesArregladosDeBaja = $"SELECT COUNT(*) FROM celulares WHERE Estado = 'Arreglado' AND Ingreso >= DATE_SUB(CURDATE(), INTERVAL {intervaloMeses} MONTH)";
            celularesAveriadosDeBaja = $"SELECT COUNT(*) FROM celulares WHERE Estado = 'Averiado' AND Ingreso >= DATE_SUB(CURDATE(), INTERVAL {intervaloMeses} MONTH)";
            celularesProcesoDeBaja = $"SELECT COUNT(*) FROM celulares WHERE Estado = 'En proceso' AND Ingreso >= DATE_SUB(CURDATE(), INTERVAL {intervaloMeses} MONTH)";
            celularesEsperaDeBaja = $"SELECT COUNT(*) FROM celulares WHERE Estado = 'En Espera' AND Ingreso >= DATE_SUB(CURDATE(), INTERVAL {intervaloMeses} MONTH)";
            mostrarGraficoCelulares();
            transicion = "FadeIn";
            timer_Transicion.Start();
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
            //Principal show = new Principal();
            //this.Hide();
            //show.Show();
            transicion = "FadeOutTaller";
            timer_Transicion.Start();

        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            //Usuarios show = new Usuarios();
            //this.Hide();
            //show.Show();

            transicion = "FadeOutUsuarios";
            timer_Transicion.Start();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            //Clientes show = new Clientes();
            //this.Hide();
            //show.Show();

            transicion = "FadeOutClientes";
            timer_Transicion.Start();
        }

        private void panel_Menu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dragTrue = true;

                mouseStartX = e.X;
                mouseStartY = e.Y;
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragTrue)
            {
                if (this.WindowState == FormWindowState.Maximized)
                {
                    this.WindowState = FormWindowState.Normal;


                }

                if (this.WindowState == FormWindowState.Normal)
                {
                    int mouseX = MousePosition.X;
                    int mouseY = MousePosition.Y;

                    this.SetDesktopLocation(mouseX - mouseStartX, mouseY - mouseStartY);

                }
            }
        }

        private void btnCerrarPrograma_Click(object sender, EventArgs e)
        {
            transicion = "FadeOutExit";
            timer_Transicion.Start();
        }

        private void timer_Transicion_Tick(object sender, EventArgs e)
        {
            if (transicion == "FadeOut")
            {
                if (this.Opacity == 0)
                {
                    timer_Transicion.Stop();
                    this.Hide();
                }
                else
                {
                    if (this.WindowState == FormWindowState.Normal)
                    {
                        this.Opacity -= .15;
                        this.Left += 12;
                    }
                    else
                    {
                        this.Opacity -= .15;
                    }
                }
            }
            else if (transicion == "FadeIn")
            {
                if (this.Opacity == 1)
                {
                    timer_Transicion.Stop();
                }
                else
                {
                    this.Opacity += .15;
                }
            }
            else if (transicion == "FadeOutExit")
            {
                if (this.Opacity == 0)
                {
                    timer_Transicion.Stop();
                    Application.Exit();
                }
                else
                {
                    if (this.WindowState == FormWindowState.Normal)
                    {
                        this.Opacity -= .15;
                        this.Left += 12;
                    }
                    else
                    {
                        this.Opacity -= .15;
                    }

                }
            }
            else if (transicion == "FadeOutTaller")
            {
                if (this.Opacity == 0)
                {
                    timer_Transicion.Stop();
                    Principal show = new Principal();
                    this.Hide();
                    show.Show();
                }
                else
                {
                    if (this.WindowState == FormWindowState.Normal)
                    {
                        this.Opacity -= .15;
                        this.Top -= 12;
                    }
                    else
                    {
                        this.Opacity -= .15;
                    }

                }
            }
            else if (transicion == "FadeOutClientes")
            {
                if (this.Opacity == 0)
                {
                    timer_Transicion.Stop();
                    Clientes show = new Clientes();
                    this.Hide();
                    show.Show();
                }
                else
                {
                    if (this.WindowState == FormWindowState.Normal)
                    {
                        this.Opacity -= .15;
                        this.Top -= 12;
                    }
                    else
                    {
                        this.Opacity -= .15;
                    }

                }
            }
            else if (transicion == "FadeOutUsuarios")
            {
                if (this.Opacity == 0)
                {
                    timer_Transicion.Stop();
                    Usuarios show = new Usuarios();
                    this.Hide();
                    show.Show();
                }
                else
                {
                    if (this.WindowState == FormWindowState.Normal)
                    {
                        this.Opacity -= .15;
                        this.Top -= 12;
                    }
                    else
                    {
                        this.Opacity -= .15;
                    }

                }
            }
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void checkBoxCelularesBaja_CheckedChanged(object sender, EventArgs e)
        {
            mostrarGraficoCelulares();
        }

        private void txtMeses_TextChanged(object sender, EventArgs e)
        {
            if (txtMeses.TextLength.Equals(0))
            {
                
            }
            else
            {
                try
                {
                    intervaloMeses = int.Parse(txtMeses.Text);
                }
                catch
                {
                    MessageBox.Show("Ingrese un valor valido!");
                }
            }

            celularesArregladosConsulta = $"SELECT COUNT(*) FROM celulares WHERE Estado = 'Arreglado' AND Ingreso >= DATE_SUB(CURDATE(), INTERVAL {intervaloMeses} MONTH) AND Baja = 0";
            celularesAveriadosConsulta = $"SELECT COUNT(*) FROM celulares WHERE Estado = 'Averiado' AND Ingreso >= DATE_SUB(CURDATE(), INTERVAL {intervaloMeses} MONTH) AND Baja = 0";
            celularesProcesoConsulta = $"SELECT COUNT(*) FROM celulares WHERE Estado = 'En Proceso' AND Ingreso >= DATE_SUB(CURDATE(), INTERVAL {intervaloMeses} MONTH) AND Baja = 0";
            celularesEsperaConsulta = $"SELECT COUNT(*) FROM celulares WHERE Estado = 'En espera' AND Ingreso >= DATE_SUB(CURDATE(), INTERVAL {intervaloMeses} MONTH) AND Baja = 0";

            celularesArregladosDeBaja = $"SELECT COUNT(*) FROM celulares WHERE Estado = 'Arreglado' AND Ingreso >= DATE_SUB(CURDATE(), INTERVAL {intervaloMeses}";
            celularesAveriadosDeBaja = $"SELECT COUNT(*) FROM celulares WHERE Estado = 'Averiado' AND Ingreso >= DATE_SUB(CURDATE(), INTERVAL {intervaloMeses} MONTH)";
            celularesProcesoDeBaja = $"SELECT COUNT(*) FROM celulares WHERE Estado = 'En proceso' AND Ingreso >= DATE_SUB(CURDATE(), INTERVAL {intervaloMeses} MONTH)";
            celularesEsperaDeBaja = $"SELECT COUNT(*) FROM celulares WHERE Estado = 'En Espera' AND Ingreso >= DATE_SUB(CURDATE(), INTERVAL {intervaloMeses} MONTH)";

            mostrarGraficoCelulares();
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            dragTrue = false;

            if (this.Top <= 0)
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }
    }
}
