namespace Diseño
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.labName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.LabelRegistrarse = new System.Windows.Forms.Label();
            this.btnIngreso = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnInvitado = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.picMostrar = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMostrar)).BeginInit();
            this.SuspendLayout();
            // 
            // labName
            // 
            this.labName.AutoSize = true;
            this.labName.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labName.Location = new System.Drawing.Point(65, 102);
            this.labName.Name = "labName";
            this.labName.Size = new System.Drawing.Size(55, 15);
            this.labName.TabIndex = 1;
            this.labName.Text = "Nombre:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(65, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Contraseña:";
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(68, 119);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(156, 21);
            this.txtNombre.TabIndex = 4;
            this.txtNombre.Enter += new System.EventHandler(this.txtNombre_Enter);
            this.txtNombre.Leave += new System.EventHandler(this.txtNombre_Leave);
            this.txtNombre.MouseEnter += new System.EventHandler(this.txtNombre_MouseEnter);
            // 
            // txtPass
            // 
            this.txtPass.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPass.Location = new System.Drawing.Point(68, 171);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(156, 21);
            this.txtPass.TabIndex = 5;
            this.txtPass.MouseEnter += new System.EventHandler(this.txtPass_MouseEnter);
            // 
            // checkBox1
            // 
            this.checkBox1.BackColor = System.Drawing.Color.Transparent;
            this.checkBox1.CausesValidation = false;
            this.checkBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBox1.ForeColor = System.Drawing.Color.Transparent;
            this.checkBox1.Location = new System.Drawing.Point(231, 173);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBox1.Size = new System.Drawing.Size(16, 18);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.TabStop = false;
            this.checkBox1.UseVisualStyleBackColor = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            this.checkBox1.MouseEnter += new System.EventHandler(this.checkBox1_MouseEnter);
            // 
            // LabelRegistrarse
            // 
            this.LabelRegistrarse.AutoSize = true;
            this.LabelRegistrarse.BackColor = System.Drawing.Color.Transparent;
            this.LabelRegistrarse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LabelRegistrarse.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelRegistrarse.ForeColor = System.Drawing.Color.Blue;
            this.LabelRegistrarse.Location = new System.Drawing.Point(12, 259);
            this.LabelRegistrarse.Name = "LabelRegistrarse";
            this.LabelRegistrarse.Size = new System.Drawing.Size(73, 15);
            this.LabelRegistrarse.TabIndex = 9;
            this.LabelRegistrarse.Text = "Registrarse";
            this.LabelRegistrarse.Click += new System.EventHandler(this.LabelRegistrarse_Click);
            this.LabelRegistrarse.MouseEnter += new System.EventHandler(this.LabelRegistrarse_MouseEnter);
            this.LabelRegistrarse.MouseLeave += new System.EventHandler(this.LabelRegistrarse_MouseLeave);
            // 
            // btnIngreso
            // 
            this.btnIngreso.BackColor = System.Drawing.Color.DarkRed;
            this.btnIngreso.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnIngreso.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnIngreso.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIngreso.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.btnIngreso.Image = global::Diseño.Properties.Resources.usuario;
            this.btnIngreso.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIngreso.Location = new System.Drawing.Point(68, 212);
            this.btnIngreso.Name = "btnIngreso";
            this.btnIngreso.Size = new System.Drawing.Size(77, 31);
            this.btnIngreso.TabIndex = 0;
            this.btnIngreso.Text = "Ingresar";
            this.btnIngreso.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIngreso.UseVisualStyleBackColor = false;
            this.btnIngreso.Click += new System.EventHandler(this.btnIngreso_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(22)))), ((int)(((byte)(109)))));
            this.pictureBox3.BackgroundImage = global::Diseño.Properties.Resources.Logo_Catalina_Harriague_de_Castaños___UTU;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Location = new System.Drawing.Point(303, 219);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(62, 50);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 11;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Diseño.Properties.Resources._20230313_234416_0000;
            this.pictureBox2.Location = new System.Drawing.Point(284, -1);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(286, 283);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 10;
            this.pictureBox2.TabStop = false;
            // 
            // btnInvitado
            // 
            this.btnInvitado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.btnInvitado.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnInvitado.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnInvitado.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInvitado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.btnInvitado.Image = global::Diseño.Properties.Resources.alt_de_inicio_de_sesion;
            this.btnInvitado.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInvitado.Location = new System.Drawing.Point(149, 212);
            this.btnInvitado.Name = "btnInvitado";
            this.btnInvitado.Size = new System.Drawing.Size(75, 31);
            this.btnInvitado.TabIndex = 6;
            this.btnInvitado.Text = "Dev";
            this.btnInvitado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInvitado.UseVisualStyleBackColor = false;
            this.btnInvitado.Click += new System.EventHandler(this.btnInvitado_Click);
            this.btnInvitado.MouseEnter += new System.EventHandler(this.button1_MouseEnter);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Diseño.Properties.Resources.logo_etech_uruguay_220_e1654881097513_LARGE_Edited;
            this.pictureBox1.Location = new System.Drawing.Point(68, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(156, 75);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // picMostrar
            // 
            this.picMostrar.Enabled = false;
            this.picMostrar.Image = global::Diseño.Properties.Resources.ojo_tapado;
            this.picMostrar.Location = new System.Drawing.Point(231, 175);
            this.picMostrar.Name = "picMostrar";
            this.picMostrar.Size = new System.Drawing.Size(16, 16);
            this.picMostrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picMostrar.TabIndex = 7;
            this.picMostrar.TabStop = false;
            // 
            // Login
            // 
            this.AcceptButton = this.btnIngreso;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(569, 281);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.LabelRegistrarse);
            this.Controls.Add(this.btnInvitado);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labName);
            this.Controls.Add(this.btnIngreso);
            this.Controls.Add(this.picMostrar);
            this.Controls.Add(this.checkBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Etech | Iniciar Sesión";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Login_FormClosed);
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMostrar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnIngreso;
        private System.Windows.Forms.Label labName;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Button btnInvitado;
        private System.Windows.Forms.PictureBox picMostrar;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label LabelRegistrarse;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}