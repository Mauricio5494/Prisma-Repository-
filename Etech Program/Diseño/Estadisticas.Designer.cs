namespace Diseño
{
    partial class Estadisticas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Estadisticas));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panelE = new System.Windows.Forms.Panel();
            this.txtMeses = new System.Windows.Forms.TextBox();
            this.labelMeses = new System.Windows.Forms.Label();
            this.pictureBox_Taller = new System.Windows.Forms.PictureBox();
            this.label_Name_Form = new System.Windows.Forms.Label();
            this.btnMenu = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.panelD = new System.Windows.Forms.Panel();
            this.btnMenuPrincipal_Panel = new System.Windows.Forms.Button();
            this.btnInformacion = new System.Windows.Forms.Button();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.tabIndex_Pestañas = new System.Windows.Forms.TabControl();
            this.tab_Celulares = new System.Windows.Forms.TabPage();
            this.checkBoxCelularesBaja = new System.Windows.Forms.CheckBox();
            this.graficoCelulares = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel_Menu = new System.Windows.Forms.Panel();
            this.pictureBox_EtechLogo_PanelMenu = new System.Windows.Forms.PictureBox();
            this.groupBox_Menu = new System.Windows.Forms.GroupBox();
            this.btnClientes = new System.Windows.Forms.Button();
            this.btnTaller = new System.Windows.Forms.Button();
            this.btnUsuarios = new System.Windows.Forms.Button();
            this.timer_Agrandar_Menu = new System.Windows.Forms.Timer(this.components);
            this.timer_Reducir_Menu = new System.Windows.Forms.Timer(this.components);
            this.panel_Informacion = new System.Windows.Forms.Panel();
            this.groupBox_InformacionTecnicos = new System.Windows.Forms.GroupBox();
            this.labelAveriados_Porcentaje = new System.Windows.Forms.Label();
            this.labelEspera_Porcentaje = new System.Windows.Forms.Label();
            this.labelProceso_Porcentaje = new System.Windows.Forms.Label();
            this.labelArreglados_Porcentaje = new System.Windows.Forms.Label();
            this.groupBox_InformacionCelulares = new System.Windows.Forms.GroupBox();
            this.label_CelularesEnEspera = new System.Windows.Forms.Label();
            this.label_CelularesAveriados = new System.Windows.Forms.Label();
            this.label_CelularesEnProceso = new System.Windows.Forms.Label();
            this.label_CelularesArreglados = new System.Windows.Forms.Label();
            this.timer_Agrandar_Informacion = new System.Windows.Forms.Timer(this.components);
            this.timer_Reducir_Informacion = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label21 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnMinimizar = new System.Windows.Forms.Button();
            this.btnMaximizar = new System.Windows.Forms.Button();
            this.btnCerrarPrograma = new System.Windows.Forms.Button();
            this.timer_Transicion = new System.Windows.Forms.Timer(this.components);
            this.panelE.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Taller)).BeginInit();
            this.panelD.SuspendLayout();
            this.tabIndex_Pestañas.SuspendLayout();
            this.tab_Celulares.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.graficoCelulares)).BeginInit();
            this.panel_Menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_EtechLogo_PanelMenu)).BeginInit();
            this.groupBox_Menu.SuspendLayout();
            this.panel_Informacion.SuspendLayout();
            this.groupBox_InformacionTecnicos.SuspendLayout();
            this.groupBox_InformacionCelulares.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panelE
            // 
            this.panelE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.panelE.Controls.Add(this.txtMeses);
            this.panelE.Controls.Add(this.labelMeses);
            this.panelE.Controls.Add(this.pictureBox_Taller);
            this.panelE.Controls.Add(this.label_Name_Form);
            this.panelE.Controls.Add(this.btnMenu);
            this.panelE.Controls.Add(this.btnCerrar);
            this.panelE.Location = new System.Drawing.Point(-2, 22);
            this.panelE.Name = "panelE";
            this.panelE.Size = new System.Drawing.Size(2000, 74);
            this.panelE.TabIndex = 14;
            // 
            // txtMeses
            // 
            this.txtMeses.Location = new System.Drawing.Point(602, 22);
            this.txtMeses.Name = "txtMeses";
            this.txtMeses.Size = new System.Drawing.Size(100, 20);
            this.txtMeses.TabIndex = 27;
            this.txtMeses.Text = "3";
            this.txtMeses.TextChanged += new System.EventHandler(this.txtMeses_TextChanged);
            // 
            // labelMeses
            // 
            this.labelMeses.AutoSize = true;
            this.labelMeses.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F);
            this.labelMeses.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelMeses.Location = new System.Drawing.Point(483, 22);
            this.labelMeses.Name = "labelMeses";
            this.labelMeses.Size = new System.Drawing.Size(113, 15);
            this.labelMeses.TabIndex = 26;
            this.labelMeses.Text = "Intervalo de meses:";
            // 
            // pictureBox_Taller
            // 
            this.pictureBox_Taller.Image = global::Diseño.Properties.Resources.vigilancia__1_;
            this.pictureBox_Taller.Location = new System.Drawing.Point(87, 14);
            this.pictureBox_Taller.Name = "pictureBox_Taller";
            this.pictureBox_Taller.Size = new System.Drawing.Size(53, 51);
            this.pictureBox_Taller.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_Taller.TabIndex = 21;
            this.pictureBox_Taller.TabStop = false;
            // 
            // label_Name_Form
            // 
            this.label_Name_Form.AutoSize = true;
            this.label_Name_Form.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.label_Name_Form.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_Name_Form.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Name_Form.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label_Name_Form.Location = new System.Drawing.Point(146, 28);
            this.label_Name_Form.Name = "label_Name_Form";
            this.label_Name_Form.Size = new System.Drawing.Size(224, 31);
            this.label_Name_Form.TabIndex = 14;
            this.label_Name_Form.Text = "ESTADÍSTICAS";
            // 
            // btnMenu
            // 
            this.btnMenu.Cursor = System.Windows.Forms.Cursors.PanSE;
            this.btnMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.btnMenu.Image = global::Diseño.Properties.Resources.contexto__1_;
            this.btnMenu.Location = new System.Drawing.Point(0, 18);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(45, 41);
            this.btnMenu.TabIndex = 11;
            this.btnMenu.UseVisualStyleBackColor = true;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCerrar.Location = new System.Drawing.Point(276, 36);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(10, 10);
            this.btnCerrar.TabIndex = 24;
            this.btnCerrar.Text = "cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            // 
            // panelD
            // 
            this.panelD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panelD.Controls.Add(this.btnMenuPrincipal_Panel);
            this.panelD.Controls.Add(this.btnInformacion);
            this.panelD.Controls.Add(this.btnCerrarSesion);
            this.panelD.Location = new System.Drawing.Point(-2, 22);
            this.panelD.Name = "panelD";
            this.panelD.Size = new System.Drawing.Size(45, 1060);
            this.panelD.TabIndex = 15;
            // 
            // btnMenuPrincipal_Panel
            // 
            this.btnMenuPrincipal_Panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnMenuPrincipal_Panel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenuPrincipal_Panel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuPrincipal_Panel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuPrincipal_Panel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnMenuPrincipal_Panel.Image = global::Diseño.Properties.Resources.menu;
            this.btnMenuPrincipal_Panel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuPrincipal_Panel.Location = new System.Drawing.Point(0, 132);
            this.btnMenuPrincipal_Panel.Name = "btnMenuPrincipal_Panel";
            this.btnMenuPrincipal_Panel.Size = new System.Drawing.Size(120, 46);
            this.btnMenuPrincipal_Panel.TabIndex = 14;
            this.btnMenuPrincipal_Panel.Text = "Menu";
            this.btnMenuPrincipal_Panel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMenuPrincipal_Panel.UseVisualStyleBackColor = false;
            this.btnMenuPrincipal_Panel.Click += new System.EventHandler(this.btnMenu_Principal_Click);
            // 
            // btnInformacion
            // 
            this.btnInformacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnInformacion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInformacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInformacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInformacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnInformacion.Image = ((System.Drawing.Image)(resources.GetObject("btnInformacion.Image")));
            this.btnInformacion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInformacion.Location = new System.Drawing.Point(0, 80);
            this.btnInformacion.Name = "btnInformacion";
            this.btnInformacion.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnInformacion.Size = new System.Drawing.Size(120, 46);
            this.btnInformacion.TabIndex = 1;
            this.btnInformacion.Text = "Datos";
            this.btnInformacion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInformacion.UseVisualStyleBackColor = false;
            this.btnInformacion.Click += new System.EventHandler(this.btnInformacion_Click);
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrarSesion.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCerrarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarSesion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrarSesion.ForeColor = System.Drawing.Color.Firebrick;
            this.btnCerrarSesion.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrarSesion.Image")));
            this.btnCerrarSesion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrarSesion.Location = new System.Drawing.Point(0, 607);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(120, 46);
            this.btnCerrarSesion.TabIndex = 3;
            this.btnCerrarSesion.Text = "Salir";
            this.btnCerrarSesion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCerrarSesion.UseVisualStyleBackColor = true;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // tabIndex_Pestañas
            // 
            this.tabIndex_Pestañas.Controls.Add(this.tab_Celulares);
            this.tabIndex_Pestañas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabIndex_Pestañas.Location = new System.Drawing.Point(474, 102);
            this.tabIndex_Pestañas.Name = "tabIndex_Pestañas";
            this.tabIndex_Pestañas.SelectedIndex = 0;
            this.tabIndex_Pestañas.Size = new System.Drawing.Size(880, 604);
            this.tabIndex_Pestañas.TabIndex = 22;
            // 
            // tab_Celulares
            // 
            this.tab_Celulares.Controls.Add(this.checkBoxCelularesBaja);
            this.tab_Celulares.Controls.Add(this.graficoCelulares);
            this.tab_Celulares.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tab_Celulares.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab_Celulares.Location = new System.Drawing.Point(4, 22);
            this.tab_Celulares.Name = "tab_Celulares";
            this.tab_Celulares.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Celulares.Size = new System.Drawing.Size(872, 578);
            this.tab_Celulares.TabIndex = 0;
            this.tab_Celulares.Text = "Celulares";
            this.tab_Celulares.UseVisualStyleBackColor = true;
            // 
            // checkBoxCelularesBaja
            // 
            this.checkBoxCelularesBaja.AutoSize = true;
            this.checkBoxCelularesBaja.Location = new System.Drawing.Point(6, 7);
            this.checkBoxCelularesBaja.Name = "checkBoxCelularesBaja";
            this.checkBoxCelularesBaja.Size = new System.Drawing.Size(169, 17);
            this.checkBoxCelularesBaja.TabIndex = 25;
            this.checkBoxCelularesBaja.Text = "Incluir celulares dados de baja";
            this.checkBoxCelularesBaja.UseVisualStyleBackColor = true;
            this.checkBoxCelularesBaja.CheckedChanged += new System.EventHandler(this.checkBoxCelularesBaja_CheckedChanged);
            // 
            // graficoCelulares
            // 
            chartArea1.Name = "ChartArea1";
            this.graficoCelulares.ChartAreas.Add(chartArea1);
            this.graficoCelulares.Cursor = System.Windows.Forms.Cursors.Default;
            legend1.Name = "Legend1";
            this.graficoCelulares.Legends.Add(legend1);
            this.graficoCelulares.Location = new System.Drawing.Point(6, 3);
            this.graficoCelulares.Name = "graficoCelulares";
            this.graficoCelulares.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.graficoCelulares.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.PaleGreen,
        System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.Navy,
        System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))))};
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.graficoCelulares.Series.Add(series1);
            this.graficoCelulares.Size = new System.Drawing.Size(854, 569);
            this.graficoCelulares.TabIndex = 0;
            this.graficoCelulares.Text = "Estadísticas de Celulares";
            // 
            // panel_Menu
            // 
            this.panel_Menu.BackColor = System.Drawing.Color.White;
            this.panel_Menu.Controls.Add(this.pictureBox_EtechLogo_PanelMenu);
            this.panel_Menu.Controls.Add(this.groupBox_Menu);
            this.panel_Menu.Location = new System.Drawing.Point(49, 102);
            this.panel_Menu.Name = "panel_Menu";
            this.panel_Menu.Size = new System.Drawing.Size(419, 600);
            this.panel_Menu.TabIndex = 23;
            this.panel_Menu.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Menu_Paint);
            // 
            // pictureBox_EtechLogo_PanelMenu
            // 
            this.pictureBox_EtechLogo_PanelMenu.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_EtechLogo_PanelMenu.Image")));
            this.pictureBox_EtechLogo_PanelMenu.Location = new System.Drawing.Point(122, 6);
            this.pictureBox_EtechLogo_PanelMenu.Name = "pictureBox_EtechLogo_PanelMenu";
            this.pictureBox_EtechLogo_PanelMenu.Size = new System.Drawing.Size(161, 71);
            this.pictureBox_EtechLogo_PanelMenu.TabIndex = 1;
            this.pictureBox_EtechLogo_PanelMenu.TabStop = false;
            // 
            // groupBox_Menu
            // 
            this.groupBox_Menu.BackColor = System.Drawing.Color.White;
            this.groupBox_Menu.Controls.Add(this.btnClientes);
            this.groupBox_Menu.Controls.Add(this.btnTaller);
            this.groupBox_Menu.Controls.Add(this.btnUsuarios);
            this.groupBox_Menu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_Menu.Location = new System.Drawing.Point(3, 83);
            this.groupBox_Menu.Name = "groupBox_Menu";
            this.groupBox_Menu.Size = new System.Drawing.Size(413, 514);
            this.groupBox_Menu.TabIndex = 0;
            this.groupBox_Menu.TabStop = false;
            this.groupBox_Menu.Text = "Menú";
            // 
            // btnClientes
            // 
            this.btnClientes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClientes.Image = global::Diseño.Properties.Resources.cliente;
            this.btnClientes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClientes.Location = new System.Drawing.Point(6, 119);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(401, 91);
            this.btnClientes.TabIndex = 2;
            this.btnClientes.Text = "CLIENTES";
            this.btnClientes.UseVisualStyleBackColor = true;
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // btnTaller
            // 
            this.btnTaller.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTaller.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTaller.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaller.Image = global::Diseño.Properties.Resources.telefono_inteligente__2_;
            this.btnTaller.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTaller.Location = new System.Drawing.Point(6, 25);
            this.btnTaller.Name = "btnTaller";
            this.btnTaller.Size = new System.Drawing.Size(401, 91);
            this.btnTaller.TabIndex = 1;
            this.btnTaller.Text = "TALLER";
            this.btnTaller.UseVisualStyleBackColor = true;
            this.btnTaller.Click += new System.EventHandler(this.btnTaller_Click);
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUsuarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsuarios.Image = global::Diseño.Properties.Resources.work_from_home;
            this.btnUsuarios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsuarios.Location = new System.Drawing.Point(6, 216);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Size = new System.Drawing.Size(401, 91);
            this.btnUsuarios.TabIndex = 0;
            this.btnUsuarios.Text = "USUARIOS";
            this.btnUsuarios.UseVisualStyleBackColor = true;
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click);
            // 
            // timer_Agrandar_Menu
            // 
            this.timer_Agrandar_Menu.Tick += new System.EventHandler(this.timer_Agrandar_Menu_Tick);
            // 
            // timer_Reducir_Menu
            // 
            this.timer_Reducir_Menu.Tick += new System.EventHandler(this.timer_Reducir_Menu_Tick);
            // 
            // panel_Informacion
            // 
            this.panel_Informacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panel_Informacion.Controls.Add(this.groupBox_InformacionTecnicos);
            this.panel_Informacion.Controls.Add(this.groupBox_InformacionCelulares);
            this.panel_Informacion.Location = new System.Drawing.Point(49, 102);
            this.panel_Informacion.Name = "panel_Informacion";
            this.panel_Informacion.Size = new System.Drawing.Size(419, 600);
            this.panel_Informacion.TabIndex = 24;
            // 
            // groupBox_InformacionTecnicos
            // 
            this.groupBox_InformacionTecnicos.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox_InformacionTecnicos.Controls.Add(this.labelAveriados_Porcentaje);
            this.groupBox_InformacionTecnicos.Controls.Add(this.labelEspera_Porcentaje);
            this.groupBox_InformacionTecnicos.Controls.Add(this.labelProceso_Porcentaje);
            this.groupBox_InformacionTecnicos.Controls.Add(this.labelArreglados_Porcentaje);
            this.groupBox_InformacionTecnicos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_InformacionTecnicos.Location = new System.Drawing.Point(3, 284);
            this.groupBox_InformacionTecnicos.Name = "groupBox_InformacionTecnicos";
            this.groupBox_InformacionTecnicos.Size = new System.Drawing.Size(413, 313);
            this.groupBox_InformacionTecnicos.TabIndex = 4;
            this.groupBox_InformacionTecnicos.TabStop = false;
            this.groupBox_InformacionTecnicos.Text = "Datos de celulares a porcentaje";
            // 
            // labelAveriados_Porcentaje
            // 
            this.labelAveriados_Porcentaje.AutoSize = true;
            this.labelAveriados_Porcentaje.Location = new System.Drawing.Point(15, 105);
            this.labelAveriados_Porcentaje.Name = "labelAveriados_Porcentaje";
            this.labelAveriados_Porcentaje.Size = new System.Drawing.Size(51, 20);
            this.labelAveriados_Porcentaje.TabIndex = 3;
            this.labelAveriados_Porcentaje.Text = "label4";
            // 
            // labelEspera_Porcentaje
            // 
            this.labelEspera_Porcentaje.AutoSize = true;
            this.labelEspera_Porcentaje.Location = new System.Drawing.Point(15, 212);
            this.labelEspera_Porcentaje.Name = "labelEspera_Porcentaje";
            this.labelEspera_Porcentaje.Size = new System.Drawing.Size(51, 20);
            this.labelEspera_Porcentaje.TabIndex = 2;
            this.labelEspera_Porcentaje.Text = "label3";
            // 
            // labelProceso_Porcentaje
            // 
            this.labelProceso_Porcentaje.AutoSize = true;
            this.labelProceso_Porcentaje.Location = new System.Drawing.Point(15, 161);
            this.labelProceso_Porcentaje.Name = "labelProceso_Porcentaje";
            this.labelProceso_Porcentaje.Size = new System.Drawing.Size(51, 20);
            this.labelProceso_Porcentaje.TabIndex = 1;
            this.labelProceso_Porcentaje.Text = "label2";
            // 
            // labelArreglados_Porcentaje
            // 
            this.labelArreglados_Porcentaje.AutoSize = true;
            this.labelArreglados_Porcentaje.Location = new System.Drawing.Point(15, 50);
            this.labelArreglados_Porcentaje.Name = "labelArreglados_Porcentaje";
            this.labelArreglados_Porcentaje.Size = new System.Drawing.Size(51, 20);
            this.labelArreglados_Porcentaje.TabIndex = 0;
            this.labelArreglados_Porcentaje.Text = "label1";
            // 
            // groupBox_InformacionCelulares
            // 
            this.groupBox_InformacionCelulares.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox_InformacionCelulares.Controls.Add(this.label_CelularesEnEspera);
            this.groupBox_InformacionCelulares.Controls.Add(this.label_CelularesAveriados);
            this.groupBox_InformacionCelulares.Controls.Add(this.label_CelularesEnProceso);
            this.groupBox_InformacionCelulares.Controls.Add(this.label_CelularesArreglados);
            this.groupBox_InformacionCelulares.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_InformacionCelulares.Location = new System.Drawing.Point(3, 3);
            this.groupBox_InformacionCelulares.Name = "groupBox_InformacionCelulares";
            this.groupBox_InformacionCelulares.Size = new System.Drawing.Size(413, 275);
            this.groupBox_InformacionCelulares.TabIndex = 1;
            this.groupBox_InformacionCelulares.TabStop = false;
            this.groupBox_InformacionCelulares.Text = "Datos de celulares";
            // 
            // label_CelularesEnEspera
            // 
            this.label_CelularesEnEspera.AutoSize = true;
            this.label_CelularesEnEspera.Location = new System.Drawing.Point(6, 183);
            this.label_CelularesEnEspera.Name = "label_CelularesEnEspera";
            this.label_CelularesEnEspera.Size = new System.Drawing.Size(154, 20);
            this.label_CelularesEnEspera.TabIndex = 3;
            this.label_CelularesEnEspera.Text = "Celulares en espera:";
            // 
            // label_CelularesAveriados
            // 
            this.label_CelularesAveriados.AutoSize = true;
            this.label_CelularesAveriados.Location = new System.Drawing.Point(6, 90);
            this.label_CelularesAveriados.Name = "label_CelularesAveriados";
            this.label_CelularesAveriados.Size = new System.Drawing.Size(151, 20);
            this.label_CelularesAveriados.TabIndex = 2;
            this.label_CelularesAveriados.Text = "Celulares averiados:";
            // 
            // label_CelularesEnProceso
            // 
            this.label_CelularesEnProceso.AutoSize = true;
            this.label_CelularesEnProceso.Location = new System.Drawing.Point(6, 134);
            this.label_CelularesEnProceso.Name = "label_CelularesEnProceso";
            this.label_CelularesEnProceso.Size = new System.Drawing.Size(162, 20);
            this.label_CelularesEnProceso.TabIndex = 1;
            this.label_CelularesEnProceso.Text = "Celulares en proceso:";
            // 
            // label_CelularesArreglados
            // 
            this.label_CelularesArreglados.AutoSize = true;
            this.label_CelularesArreglados.Location = new System.Drawing.Point(6, 46);
            this.label_CelularesArreglados.Name = "label_CelularesArreglados";
            this.label_CelularesArreglados.Size = new System.Drawing.Size(158, 20);
            this.label_CelularesArreglados.TabIndex = 0;
            this.label_CelularesArreglados.Text = "Celulares arreglados:";
            // 
            // timer_Agrandar_Informacion
            // 
            this.timer_Agrandar_Informacion.Tick += new System.EventHandler(this.timer_Agrandar_Informacion_Tick);
            // 
            // timer_Reducir_Informacion
            // 
            this.timer_Reducir_Informacion.Tick += new System.EventHandler(this.timer_Reducir_Informacion_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.panel1.Controls.Add(this.label21);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.btnMinimizar);
            this.panel1.Controls.Add(this.btnMaximizar);
            this.panel1.Controls.Add(this.btnCerrarPrograma);
            this.panel1.Location = new System.Drawing.Point(-2, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1369, 25);
            this.panel1.TabIndex = 25;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(31, 6);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(101, 13);
            this.label21.TabIndex = 4;
            this.label21.Text = "Etech | Estadísticas";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Enabled = false;
            this.pictureBox2.Image = global::Diseño.Properties.Resources.logo_etech_uruguay_220_e1654881097513__1_;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(25, 25);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnMinimizar.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnMinimizar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMinimizar.Image = global::Diseño.Properties.Resources.menos__1_;
            this.btnMinimizar.Location = new System.Drawing.Point(1227, 0);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(48, 25);
            this.btnMinimizar.TabIndex = 2;
            this.btnMinimizar.UseVisualStyleBackColor = false;
            this.btnMinimizar.Click += new System.EventHandler(this.btnMinimizar_Click);
            // 
            // btnMaximizar
            // 
            this.btnMaximizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnMaximizar.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnMaximizar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMaximizar.Image = global::Diseño.Properties.Resources.cuadricula;
            this.btnMaximizar.Location = new System.Drawing.Point(1274, 0);
            this.btnMaximizar.Name = "btnMaximizar";
            this.btnMaximizar.Size = new System.Drawing.Size(48, 25);
            this.btnMaximizar.TabIndex = 1;
            this.btnMaximizar.UseVisualStyleBackColor = false;
            this.btnMaximizar.Click += new System.EventHandler(this.btnMaximizar_Click);
            // 
            // btnCerrarPrograma
            // 
            this.btnCerrarPrograma.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnCerrarPrograma.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnCerrarPrograma.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCerrarPrograma.Image = global::Diseño.Properties.Resources.cruzado__1_;
            this.btnCerrarPrograma.Location = new System.Drawing.Point(1321, 0);
            this.btnCerrarPrograma.Name = "btnCerrarPrograma";
            this.btnCerrarPrograma.Size = new System.Drawing.Size(48, 25);
            this.btnCerrarPrograma.TabIndex = 0;
            this.btnCerrarPrograma.UseVisualStyleBackColor = false;
            this.btnCerrarPrograma.Click += new System.EventHandler(this.btnCerrarPrograma_Click);
            // 
            // timer_Transicion
            // 
            this.timer_Transicion.Enabled = true;
            this.timer_Transicion.Interval = 20;
            this.timer_Transicion.Tick += new System.EventHandler(this.timer_Transicion_Tick);
            // 
            // Estadisticas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1366, 728);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabIndex_Pestañas);
            this.Controls.Add(this.panelE);
            this.Controls.Add(this.panelD);
            this.Controls.Add(this.panel_Menu);
            this.Controls.Add(this.panel_Informacion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Estadisticas";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Etech | Estadisticas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Estadisticas_Load);
            this.panelE.ResumeLayout(false);
            this.panelE.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Taller)).EndInit();
            this.panelD.ResumeLayout(false);
            this.tabIndex_Pestañas.ResumeLayout(false);
            this.tab_Celulares.ResumeLayout(false);
            this.tab_Celulares.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.graficoCelulares)).EndInit();
            this.panel_Menu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_EtechLogo_PanelMenu)).EndInit();
            this.groupBox_Menu.ResumeLayout(false);
            this.panel_Informacion.ResumeLayout(false);
            this.groupBox_InformacionTecnicos.ResumeLayout(false);
            this.groupBox_InformacionTecnicos.PerformLayout();
            this.groupBox_InformacionCelulares.ResumeLayout(false);
            this.groupBox_InformacionCelulares.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelE;
        private System.Windows.Forms.PictureBox pictureBox_Taller;
        private System.Windows.Forms.Label label_Name_Form;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Panel panelD;
        private System.Windows.Forms.Button btnMenuPrincipal_Panel;
        private System.Windows.Forms.Button btnInformacion;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.TabControl tabIndex_Pestañas;
        private System.Windows.Forms.TabPage tab_Celulares;
        private System.Windows.Forms.Panel panel_Menu;
        private System.Windows.Forms.PictureBox pictureBox_EtechLogo_PanelMenu;
        private System.Windows.Forms.GroupBox groupBox_Menu;
        private System.Windows.Forms.Button btnClientes;
        private System.Windows.Forms.Button btnTaller;
        private System.Windows.Forms.Button btnUsuarios;
        private System.Windows.Forms.Timer timer_Agrandar_Menu;
        private System.Windows.Forms.Timer timer_Reducir_Menu;
        private System.Windows.Forms.Panel panel_Informacion;
        private System.Windows.Forms.Timer timer_Agrandar_Informacion;
        private System.Windows.Forms.Timer timer_Reducir_Informacion;
        private System.Windows.Forms.GroupBox groupBox_InformacionCelulares;
        private System.Windows.Forms.Label label_CelularesArreglados;
        private System.Windows.Forms.Label label_CelularesEnEspera;
        private System.Windows.Forms.Label label_CelularesAveriados;
        private System.Windows.Forms.Label label_CelularesEnProceso;
        private System.Windows.Forms.GroupBox groupBox_InformacionTecnicos;
        private System.Windows.Forms.DataVisualization.Charting.Chart graficoCelulares;
        private System.Windows.Forms.Label labelAveriados_Porcentaje;
        private System.Windows.Forms.Label labelEspera_Porcentaje;
        private System.Windows.Forms.Label labelProceso_Porcentaje;
        private System.Windows.Forms.Label labelArreglados_Porcentaje;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnMinimizar;
        private System.Windows.Forms.Button btnMaximizar;
        private System.Windows.Forms.Button btnCerrarPrograma;
        private System.Windows.Forms.Timer timer_Transicion;
        private System.Windows.Forms.CheckBox checkBoxCelularesBaja;
        private System.Windows.Forms.Label labelMeses;
        private System.Windows.Forms.TextBox txtMeses;
    }
}