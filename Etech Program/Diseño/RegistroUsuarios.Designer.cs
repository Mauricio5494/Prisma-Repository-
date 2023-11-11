namespace Diseño
{
    partial class RegistroUsuarios
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelRegresar = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
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
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.checkBox_MostrarContraseña = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer_transicion = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.labelRegresar);
            this.groupBox1.Controls.Add(this.btnAgregar);
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
            this.groupBox1.Controls.Add(this.pictureBox2);
            this.groupBox1.Controls.Add(this.checkBox_MostrarContraseña);
            this.groupBox1.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox1.Location = new System.Drawing.Point(5, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(394, 417);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Regístrate";
            // 
            // labelRegresar
            // 
            this.labelRegresar.AutoSize = true;
            this.labelRegresar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelRegresar.Font = new System.Drawing.Font("Montserrat", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRegresar.ForeColor = System.Drawing.Color.Gray;
            this.labelRegresar.Location = new System.Drawing.Point(17, 344);
            this.labelRegresar.Name = "labelRegresar";
            this.labelRegresar.Size = new System.Drawing.Size(76, 16);
            this.labelRegresar.TabIndex = 13;
            this.labelRegresar.Text = "REGRESAR";
            this.labelRegresar.Click += new System.EventHandler(this.labelRegresar_Click);
            this.labelRegresar.MouseEnter += new System.EventHandler(this.labelRegresar_MouseEnter);
            this.labelRegresar.MouseLeave += new System.EventHandler(this.labelRegresar_MouseLeave);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAgregar.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.btnAgregar.Location = new System.Drawing.Point(303, 338);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 31);
            this.btnAgregar.TabIndex = 12;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(7, 246);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(382, 21);
            this.txtTelefono.TabIndex = 11;
            // 
            // label_Telefono
            // 
            this.label_Telefono.AutoSize = true;
            this.label_Telefono.Location = new System.Drawing.Point(7, 230);
            this.label_Telefono.Name = "label_Telefono";
            this.label_Telefono.Size = new System.Drawing.Size(138, 15);
            this.label_Telefono.TabIndex = 10;
            this.label_Telefono.Text = "Telefono Fijo (Opcional):";
            // 
            // label_Celular
            // 
            this.label_Celular.AutoSize = true;
            this.label_Celular.Location = new System.Drawing.Point(7, 180);
            this.label_Celular.Name = "label_Celular";
            this.label_Celular.Size = new System.Drawing.Size(47, 15);
            this.label_Celular.TabIndex = 8;
            this.label_Celular.Text = "Celular:";
            // 
            // label_Correo
            // 
            this.label_Correo.AutoSize = true;
            this.label_Correo.Location = new System.Drawing.Point(4, 132);
            this.label_Correo.Name = "label_Correo";
            this.label_Correo.Size = new System.Drawing.Size(46, 15);
            this.label_Correo.TabIndex = 7;
            this.label_Correo.Text = "Correo:";
            // 
            // label_Password
            // 
            this.label_Password.AutoSize = true;
            this.label_Password.Location = new System.Drawing.Point(4, 83);
            this.label_Password.Name = "label_Password";
            this.label_Password.Size = new System.Drawing.Size(69, 15);
            this.label_Password.TabIndex = 6;
            this.label_Password.Text = "Contraseña:";
            // 
            // label_Nombre
            // 
            this.label_Nombre.AutoSize = true;
            this.label_Nombre.Location = new System.Drawing.Point(4, 34);
            this.label_Nombre.Name = "label_Nombre";
            this.label_Nombre.Size = new System.Drawing.Size(55, 15);
            this.label_Nombre.TabIndex = 5;
            this.label_Nombre.Text = "Nombre:";
            // 
            // txtCelular
            // 
            this.txtCelular.Location = new System.Drawing.Point(7, 196);
            this.txtCelular.Name = "txtCelular";
            this.txtCelular.Size = new System.Drawing.Size(382, 21);
            this.txtCelular.TabIndex = 3;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(7, 99);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(351, 21);
            this.txtPassword.TabIndex = 2;
            // 
            // txtCorreo
            // 
            this.txtCorreo.Location = new System.Drawing.Point(7, 148);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(382, 21);
            this.txtCorreo.TabIndex = 1;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(7, 50);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(382, 21);
            this.txtNombre.TabIndex = 0;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Enabled = false;
            this.pictureBox2.Image = global::Diseño.Properties.Resources.ojo_tapado;
            this.pictureBox2.Location = new System.Drawing.Point(363, 101);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(16, 16);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 14;
            this.pictureBox2.TabStop = false;
            // 
            // checkBox_MostrarContraseña
            // 
            this.checkBox_MostrarContraseña.AutoSize = true;
            this.checkBox_MostrarContraseña.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBox_MostrarContraseña.Location = new System.Drawing.Point(364, 103);
            this.checkBox_MostrarContraseña.Name = "checkBox_MostrarContraseña";
            this.checkBox_MostrarContraseña.Size = new System.Drawing.Size(15, 14);
            this.checkBox_MostrarContraseña.TabIndex = 15;
            this.checkBox_MostrarContraseña.UseVisualStyleBackColor = true;
            this.checkBox_MostrarContraseña.CheckedChanged += new System.EventHandler(this.checkBox_MostrarContraseña_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Diseño.Properties.Resources.logo_etech_uruguay_220_e1654881097513;
            this.pictureBox1.Location = new System.Drawing.Point(122, -6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(164, 64);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // timer_transicion
            // 
            this.timer_transicion.Enabled = true;
            this.timer_transicion.Interval = 20;
            this.timer_transicion.Tick += new System.EventHandler(this.timer_transicion_Tick);
            // 
            // RegistroUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(404, 485);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "RegistroUsuarios";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Etech | Registro Rápido";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RegistroUsuarios_FormClosed);
            this.Load += new System.EventHandler(this.RegistroUsuarios_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label_Celular;
        private System.Windows.Forms.Label label_Correo;
        private System.Windows.Forms.Label label_Password;
        private System.Windows.Forms.Label label_Nombre;
        private System.Windows.Forms.TextBox txtCelular;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label label_Telefono;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label labelRegresar;
        private System.Windows.Forms.CheckBox checkBox_MostrarContraseña;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Timer timer_transicion;
    }
}