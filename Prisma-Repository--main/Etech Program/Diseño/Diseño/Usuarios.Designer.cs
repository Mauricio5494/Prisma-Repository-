namespace Diseño
{
    partial class Usuarios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Usuarios));
            this.panelE = new System.Windows.Forms.Panel();
            this.label_BD_Mostrada = new System.Windows.Forms.Label();
            this.btnMenu = new System.Windows.Forms.Button();
            this.label_Filtrar = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.MenuOpciones = new System.Windows.Forms.ComboBox();
            this.txtCampo_Busqueda = new System.Windows.Forms.TextBox();
            this.panelD = new System.Windows.Forms.Panel();
            this.btnMenuPrincipal = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.tabla_Usuarios = new System.Windows.Forms.DataGridView();
            this.panel_Registro = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panelAgregarUsuario_btnAgregar = new System.Windows.Forms.Button();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.label_Telefono = new System.Windows.Forms.Label();
            this.label_Celular = new System.Windows.Forms.Label();
            this.label_Correo = new System.Windows.Forms.Label();
            this.label_Password = new System.Windows.Forms.Label();
            this.label_Nombre = new System.Windows.Forms.Label();
            this.txtCelular = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.timer_Agrandar = new System.Windows.Forms.Timer(this.components);
            this.timer_Encoger = new System.Windows.Forms.Timer(this.components);
            this.btnRecargar = new System.Windows.Forms.PictureBox();
            this.panelE.SuspendLayout();
            this.panelD.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabla_Usuarios)).BeginInit();
            this.panel_Registro.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnRecargar)).BeginInit();
            this.SuspendLayout();
            // 
            // panelE
            // 
            this.panelE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.panelE.Controls.Add(this.label_BD_Mostrada);
            this.panelE.Controls.Add(this.btnMenu);
            this.panelE.Controls.Add(this.label_Filtrar);
            this.panelE.Controls.Add(this.btnBuscar);
            this.panelE.Controls.Add(this.MenuOpciones);
            this.panelE.Controls.Add(this.txtCampo_Busqueda);
            this.panelE.Location = new System.Drawing.Point(-2, -2);
            this.panelE.Name = "panelE";
            this.panelE.Size = new System.Drawing.Size(2000, 74);
            this.panelE.TabIndex = 13;
            // 
            // label_BD_Mostrada
            // 
            this.label_BD_Mostrada.AutoSize = true;
            this.label_BD_Mostrada.BackColor = System.Drawing.Color.Transparent;
            this.label_BD_Mostrada.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_BD_Mostrada.ForeColor = System.Drawing.Color.ForestGreen;
            this.label_BD_Mostrada.Location = new System.Drawing.Point(731, 22);
            this.label_BD_Mostrada.Name = "label_BD_Mostrada";
            this.label_BD_Mostrada.Size = new System.Drawing.Size(16, 15);
            this.label_BD_Mostrada.TabIndex = 12;
            this.label_BD_Mostrada.Text = "...";
            // 
            // btnMenu
            // 
            this.btnMenu.Cursor = System.Windows.Forms.Cursors.PanSE;
            this.btnMenu.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.btnMenu.Image = ((System.Drawing.Image)(resources.GetObject("btnMenu.Image")));
            this.btnMenu.Location = new System.Drawing.Point(0, 18);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(45, 41);
            this.btnMenu.TabIndex = 11;
            this.btnMenu.UseVisualStyleBackColor = true;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // label_Filtrar
            // 
            this.label_Filtrar.AutoSize = true;
            this.label_Filtrar.BackColor = System.Drawing.Color.Transparent;
            this.label_Filtrar.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Filtrar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label_Filtrar.Location = new System.Drawing.Point(74, 27);
            this.label_Filtrar.Name = "label_Filtrar";
            this.label_Filtrar.Size = new System.Drawing.Size(64, 14);
            this.label_Filtrar.TabIndex = 6;
            this.label_Filtrar.Text = "Filtrar por:";
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.White;
            this.btnBuscar.Enabled = false;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Arial Black", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(600, 19);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(77, 22);
            this.btnBuscar.TabIndex = 9;
            this.btnBuscar.Text = "BUSCAR";
            this.btnBuscar.UseVisualStyleBackColor = false;
            // 
            // MenuOpciones
            // 
            this.MenuOpciones.FormattingEnabled = true;
            this.MenuOpciones.Items.AddRange(new object[] {
            "ID",
            "Nombre",
            "Telefono",
            "Correo Electrónico",
            "Celular"});
            this.MenuOpciones.Location = new System.Drawing.Point(144, 20);
            this.MenuOpciones.Name = "MenuOpciones";
            this.MenuOpciones.Size = new System.Drawing.Size(121, 21);
            this.MenuOpciones.TabIndex = 7;
            this.MenuOpciones.VisibleChanged += new System.EventHandler(this.MenuOpciones_VisibleChanged);
            // 
            // txtCampo_Busqueda
            // 
            this.txtCampo_Busqueda.Enabled = false;
            this.txtCampo_Busqueda.Location = new System.Drawing.Point(271, 20);
            this.txtCampo_Busqueda.Name = "txtCampo_Busqueda";
            this.txtCampo_Busqueda.Size = new System.Drawing.Size(323, 20);
            this.txtCampo_Busqueda.TabIndex = 8;
            // 
            // panelD
            // 
            this.panelD.BackColor = System.Drawing.Color.Firebrick;
            this.panelD.Controls.Add(this.btnMenuPrincipal);
            this.panelD.Controls.Add(this.btnEliminar);
            this.panelD.Controls.Add(this.btnModificar);
            this.panelD.Controls.Add(this.btnAgregar);
            this.panelD.Controls.Add(this.btnCerrarSesion);
            this.panelD.Location = new System.Drawing.Point(-2, -2);
            this.panelD.Name = "panelD";
            this.panelD.Size = new System.Drawing.Size(45, 1060);
            this.panelD.TabIndex = 14;
            // 
            // btnMenuPrincipal
            // 
            this.btnMenuPrincipal.BackColor = System.Drawing.Color.Firebrick;
            this.btnMenuPrincipal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenuPrincipal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuPrincipal.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnMenuPrincipal.ForeColor = System.Drawing.Color.Firebrick;
            this.btnMenuPrincipal.Image = global::Diseño.Properties.Resources.casa;
            this.btnMenuPrincipal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuPrincipal.Location = new System.Drawing.Point(0, 236);
            this.btnMenuPrincipal.Name = "btnMenuPrincipal";
            this.btnMenuPrincipal.Size = new System.Drawing.Size(120, 46);
            this.btnMenuPrincipal.TabIndex = 16;
            this.btnMenuPrincipal.Text = "Menu";
            this.btnMenuPrincipal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMenuPrincipal.UseVisualStyleBackColor = false;
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.Firebrick;
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.Color.Firebrick;
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.Location = new System.Drawing.Point(0, 184);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(120, 46);
            this.btnEliminar.TabIndex = 14;
            this.btnEliminar.Text = "Quitar";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.Color.Firebrick;
            this.btnModificar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.ForeColor = System.Drawing.Color.Firebrick;
            this.btnModificar.Image = ((System.Drawing.Image)(resources.GetObject("btnModificar.Image")));
            this.btnModificar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModificar.Location = new System.Drawing.Point(0, 132);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(120, 46);
            this.btnModificar.TabIndex = 14;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnModificar.UseVisualStyleBackColor = false;
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.Firebrick;
            this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.Color.Firebrick;
            this.btnAgregar.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregar.Image")));
            this.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregar.Location = new System.Drawing.Point(0, 80);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnAgregar.Size = new System.Drawing.Size(120, 46);
            this.btnAgregar.TabIndex = 1;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarSesion.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrarSesion.ForeColor = System.Drawing.Color.Firebrick;
            this.btnCerrarSesion.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrarSesion.Image")));
            this.btnCerrarSesion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrarSesion.Location = new System.Drawing.Point(0, 638);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(120, 46);
            this.btnCerrarSesion.TabIndex = 3;
            this.btnCerrarSesion.Text = "Salir";
            this.btnCerrarSesion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCerrarSesion.UseVisualStyleBackColor = true;
            // 
            // tabla_Usuarios
            // 
            this.tabla_Usuarios.AllowUserToAddRows = false;
            this.tabla_Usuarios.AllowUserToDeleteRows = false;
            this.tabla_Usuarios.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(255)))), ((int)(((byte)(240)))));
            this.tabla_Usuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabla_Usuarios.Location = new System.Drawing.Point(49, 76);
            this.tabla_Usuarios.Name = "tabla_Usuarios";
            this.tabla_Usuarios.ReadOnly = true;
            this.tabla_Usuarios.Size = new System.Drawing.Size(786, 599);
            this.tabla_Usuarios.TabIndex = 15;
            // 
            // panel_Registro
            // 
            this.panel_Registro.BackColor = System.Drawing.Color.Firebrick;
            this.panel_Registro.Controls.Add(this.groupBox1);
            this.panel_Registro.Location = new System.Drawing.Point(929, 76);
            this.panel_Registro.Name = "panel_Registro";
            this.panel_Registro.Size = new System.Drawing.Size(419, 599);
            this.panel_Registro.TabIndex = 16;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox1.Controls.Add(this.panelAgregarUsuario_btnAgregar);
            this.groupBox1.Controls.Add(this.txtTelefono);
            this.groupBox1.Controls.Add(this.label_Telefono);
            this.groupBox1.Controls.Add(this.label_Celular);
            this.groupBox1.Controls.Add(this.label_Correo);
            this.groupBox1.Controls.Add(this.label_Password);
            this.groupBox1.Controls.Add(this.label_Nombre);
            this.groupBox1.Controls.Add(this.txtCelular);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.txtCorreo);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox1.Location = new System.Drawing.Point(20, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(377, 556);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Resgistro";
            // 
            // panelAgregarUsuario_btnAgregar
            // 
            this.panelAgregarUsuario_btnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.panelAgregarUsuario_btnAgregar.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.panelAgregarUsuario_btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.panelAgregarUsuario_btnAgregar.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelAgregarUsuario_btnAgregar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.panelAgregarUsuario_btnAgregar.Location = new System.Drawing.Point(6, 300);
            this.panelAgregarUsuario_btnAgregar.Name = "panelAgregarUsuario_btnAgregar";
            this.panelAgregarUsuario_btnAgregar.Size = new System.Drawing.Size(75, 31);
            this.panelAgregarUsuario_btnAgregar.TabIndex = 12;
            this.panelAgregarUsuario_btnAgregar.Text = "Agregar";
            this.panelAgregarUsuario_btnAgregar.UseVisualStyleBackColor = false;
            this.panelAgregarUsuario_btnAgregar.Click += new System.EventHandler(this.panelAgregarUsuario_btnAgregar_Click);
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(6, 238);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(299, 20);
            this.txtTelefono.TabIndex = 11;
            // 
            // label_Telefono
            // 
            this.label_Telefono.AutoSize = true;
            this.label_Telefono.Location = new System.Drawing.Point(6, 222);
            this.label_Telefono.Name = "label_Telefono";
            this.label_Telefono.Size = new System.Drawing.Size(147, 13);
            this.label_Telefono.TabIndex = 10;
            this.label_Telefono.Text = "Telefono Fijo (Opcional):";
            // 
            // label_Celular
            // 
            this.label_Celular.AutoSize = true;
            this.label_Celular.Location = new System.Drawing.Point(6, 172);
            this.label_Celular.Name = "label_Celular";
            this.label_Celular.Size = new System.Drawing.Size(50, 13);
            this.label_Celular.TabIndex = 8;
            this.label_Celular.Text = "Celular:";
            // 
            // label_Correo
            // 
            this.label_Correo.AutoSize = true;
            this.label_Correo.Location = new System.Drawing.Point(6, 75);
            this.label_Correo.Name = "label_Correo";
            this.label_Correo.Size = new System.Drawing.Size(48, 13);
            this.label_Correo.TabIndex = 7;
            this.label_Correo.Text = "Correo:";
            // 
            // label_Password
            // 
            this.label_Password.AutoSize = true;
            this.label_Password.Location = new System.Drawing.Point(3, 124);
            this.label_Password.Name = "label_Password";
            this.label_Password.Size = new System.Drawing.Size(75, 13);
            this.label_Password.TabIndex = 6;
            this.label_Password.Text = "Contraseña:";
            // 
            // label_Nombre
            // 
            this.label_Nombre.AutoSize = true;
            this.label_Nombre.Location = new System.Drawing.Point(3, 26);
            this.label_Nombre.Name = "label_Nombre";
            this.label_Nombre.Size = new System.Drawing.Size(54, 13);
            this.label_Nombre.TabIndex = 5;
            this.label_Nombre.Text = "Nombre:";
            // 
            // txtCelular
            // 
            this.txtCelular.Location = new System.Drawing.Point(6, 188);
            this.txtCelular.Name = "txtCelular";
            this.txtCelular.Size = new System.Drawing.Size(299, 20);
            this.txtCelular.TabIndex = 3;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(6, 140);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(299, 20);
            this.txtPassword.TabIndex = 2;
            // 
            // txtCorreo
            // 
            this.txtCorreo.Location = new System.Drawing.Point(6, 91);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(299, 20);
            this.txtCorreo.TabIndex = 1;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(6, 42);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(299, 20);
            this.txtNombre.TabIndex = 0;
            // 
            // btnRecargar
            // 
            this.btnRecargar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRecargar.Image = ((System.Drawing.Image)(resources.GetObject("btnRecargar.Image")));
            this.btnRecargar.Location = new System.Drawing.Point(841, 76);
            this.btnRecargar.Name = "btnRecargar";
            this.btnRecargar.Size = new System.Drawing.Size(25, 25);
            this.btnRecargar.TabIndex = 22;
            this.btnRecargar.TabStop = false;
            this.btnRecargar.Click += new System.EventHandler(this.btnRecargar_Click);
            // 
            // Usuarios
            // 
            this.AcceptButton = this.btnAgregar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CancelButton = this.btnMenu;
            this.ClientSize = new System.Drawing.Size(1350, 689);
            this.Controls.Add(this.btnRecargar);
            this.Controls.Add(this.panel_Registro);
            this.Controls.Add(this.tabla_Usuarios);
            this.Controls.Add(this.panelE);
            this.Controls.Add(this.panelD);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Usuarios";
            this.Text = "Usuarios";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Usuarios_FormClosed);
            this.Load += new System.EventHandler(this.Usuarios_Load);
            this.panelE.ResumeLayout(false);
            this.panelE.PerformLayout();
            this.panelD.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabla_Usuarios)).EndInit();
            this.panel_Registro.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnRecargar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelE;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.Label label_Filtrar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ComboBox MenuOpciones;
        private System.Windows.Forms.TextBox txtCampo_Busqueda;
        private System.Windows.Forms.Panel panelD;
        private System.Windows.Forms.Button btnMenuPrincipal;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.DataGridView tabla_Usuarios;
        private System.Windows.Forms.Panel panel_Registro;
        private System.Windows.Forms.Label label_BD_Mostrada;
        private System.Windows.Forms.Timer timer_Agrandar;
        private System.Windows.Forms.Timer timer_Encoger;
        private System.Windows.Forms.PictureBox btnRecargar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button panelAgregarUsuario_btnAgregar;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label label_Telefono;
        private System.Windows.Forms.Label label_Celular;
        private System.Windows.Forms.Label label_Correo;
        private System.Windows.Forms.Label label_Password;
        private System.Windows.Forms.Label label_Nombre;
        private System.Windows.Forms.TextBox txtCelular;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.TextBox txtNombre;
    }
}