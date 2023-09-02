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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Usuarios));
            this.panelE = new System.Windows.Forms.Panel();
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
            this.panelE.SuspendLayout();
            this.panelD.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelE
            // 
            this.panelE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
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
            // btnMenu
            // 
            this.btnMenu.Cursor = System.Windows.Forms.Cursors.PanSE;
            this.btnMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.btnMenu.Image = ((System.Drawing.Image)(resources.GetObject("btnMenu.Image")));
            this.btnMenu.Location = new System.Drawing.Point(0, 18);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(45, 41);
            this.btnMenu.TabIndex = 11;
            this.btnMenu.UseVisualStyleBackColor = true;
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
            "Dueño",
            "Marca",
            "Modelo",
            "Estanteria"});
            this.MenuOpciones.Location = new System.Drawing.Point(144, 20);
            this.MenuOpciones.Name = "MenuOpciones";
            this.MenuOpciones.Size = new System.Drawing.Size(121, 21);
            this.MenuOpciones.TabIndex = 7;
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
            // Usuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 689);
            this.Controls.Add(this.panelE);
            this.Controls.Add(this.panelD);
            this.Name = "Usuarios";
            this.Text = "Usuarios";
            this.panelE.ResumeLayout(false);
            this.panelE.PerformLayout();
            this.panelD.ResumeLayout(false);
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
    }
}