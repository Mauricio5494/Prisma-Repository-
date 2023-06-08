namespace Diseño
{
    partial class Agregar_Celular_Form
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
            this.btnAgregarCel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtMarca = new System.Windows.Forms.TextBox();
            this.txtModelo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtProblema = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtContraseña = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnPassAyuda = new System.Windows.Forms.Button();
            this.rbEnReparacion = new System.Windows.Forms.RadioButton();
            this.rbEnEspera = new System.Windows.Forms.RadioButton();
            this.rbExtraEstado = new System.Windows.Forms.RadioButton();
            this.rdContraseña = new System.Windows.Forms.RadioButton();
            this.rbNumerico = new System.Windows.Forms.RadioButton();
            this.rbPatron = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbNoTieneContraseña = new System.Windows.Forms.RadioButton();
            this.rbSiTieneContraseña = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAgregarCel
            // 
            this.btnAgregarCel.Location = new System.Drawing.Point(97, 468);
            this.btnAgregarCel.Name = "btnAgregarCel";
            this.btnAgregarCel.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarCel.TabIndex = 0;
            this.btnAgregarCel.Text = "Agregar";
            this.btnAgregarCel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(92, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Marca";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // txtMarca
            // 
            this.txtMarca.Location = new System.Drawing.Point(95, 54);
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Size = new System.Drawing.Size(247, 20);
            this.txtMarca.TabIndex = 2;
            // 
            // txtModelo
            // 
            this.txtModelo.Location = new System.Drawing.Point(95, 107);
            this.txtModelo.Name = "txtModelo";
            this.txtModelo.Size = new System.Drawing.Size(247, 20);
            this.txtModelo.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(92, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Modelo";
            // 
            // txtProblema
            // 
            this.txtProblema.Location = new System.Drawing.Point(95, 160);
            this.txtProblema.Multiline = true;
            this.txtProblema.Name = "txtProblema";
            this.txtProblema.Size = new System.Drawing.Size(247, 75);
            this.txtProblema.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(92, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(165, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Problema que posee (Descríbalo)";
            // 
            // txtContraseña
            // 
            this.txtContraseña.Location = new System.Drawing.Point(11, 66);
            this.txtContraseña.Name = "txtContraseña";
            this.txtContraseña.Size = new System.Drawing.Size(245, 20);
            this.txtContraseña.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(94, 309);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 13);
            this.label5.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbExtraEstado);
            this.groupBox1.Controls.Add(this.rbEnEspera);
            this.groupBox1.Controls.Add(this.rbEnReparacion);
            this.groupBox1.Location = new System.Drawing.Point(86, 255);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(261, 47);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Estado";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Contraseña";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbPatron);
            this.groupBox2.Controls.Add(this.rbNumerico);
            this.groupBox2.Controls.Add(this.rdContraseña);
            this.groupBox2.Controls.Add(this.btnPassAyuda);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtContraseña);
            this.groupBox2.Location = new System.Drawing.Point(86, 362);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(295, 100);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tipo de contraseña";
            // 
            // btnPassAyuda
            // 
            this.btnPassAyuda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnPassAyuda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPassAyuda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPassAyuda.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.btnPassAyuda.Image = global::Diseño.Properties.Resources.interrogatorio;
            this.btnPassAyuda.Location = new System.Drawing.Point(267, 21);
            this.btnPassAyuda.Name = "btnPassAyuda";
            this.btnPassAyuda.Size = new System.Drawing.Size(25, 21);
            this.btnPassAyuda.TabIndex = 13;
            this.btnPassAyuda.UseVisualStyleBackColor = true;
            this.btnPassAyuda.Click += new System.EventHandler(this.btnPassAyuda_Click);
            // 
            // rbEnReparacion
            // 
            this.rbEnReparacion.AutoSize = true;
            this.rbEnReparacion.Checked = true;
            this.rbEnReparacion.Location = new System.Drawing.Point(9, 19);
            this.rbEnReparacion.Name = "rbEnReparacion";
            this.rbEnReparacion.Size = new System.Drawing.Size(96, 17);
            this.rbEnReparacion.TabIndex = 13;
            this.rbEnReparacion.Text = "En Reparación";
            this.rbEnReparacion.UseVisualStyleBackColor = true;
            // 
            // rbEnEspera
            // 
            this.rbEnEspera.AutoSize = true;
            this.rbEnEspera.Location = new System.Drawing.Point(111, 19);
            this.rbEnEspera.Name = "rbEnEspera";
            this.rbEnEspera.Size = new System.Drawing.Size(74, 17);
            this.rbEnEspera.TabIndex = 14;
            this.rbEnEspera.Text = "En Espera";
            this.rbEnEspera.UseVisualStyleBackColor = true;
            // 
            // rbExtraEstado
            // 
            this.rbExtraEstado.AutoSize = true;
            this.rbExtraEstado.Location = new System.Drawing.Point(191, 19);
            this.rbExtraEstado.Name = "rbExtraEstado";
            this.rbExtraEstado.Size = new System.Drawing.Size(45, 17);
            this.rbExtraEstado.TabIndex = 15;
            this.rbExtraEstado.Text = "Otro";
            this.rbExtraEstado.UseVisualStyleBackColor = true;
            // 
            // rdContraseña
            // 
            this.rdContraseña.AutoSize = true;
            this.rdContraseña.Location = new System.Drawing.Point(12, 21);
            this.rdContraseña.Name = "rdContraseña";
            this.rdContraseña.Size = new System.Drawing.Size(79, 17);
            this.rdContraseña.TabIndex = 16;
            this.rdContraseña.Text = "Contraseña";
            this.rdContraseña.UseVisualStyleBackColor = true;
            // 
            // rbNumerico
            // 
            this.rbNumerico.AutoSize = true;
            this.rbNumerico.Location = new System.Drawing.Point(191, 21);
            this.rbNumerico.Name = "rbNumerico";
            this.rbNumerico.Size = new System.Drawing.Size(70, 17);
            this.rbNumerico.TabIndex = 17;
            this.rbNumerico.Text = "Numérico";
            this.rbNumerico.UseVisualStyleBackColor = true;
            // 
            // rbPatron
            // 
            this.rbPatron.AutoSize = true;
            this.rbPatron.Location = new System.Drawing.Point(111, 21);
            this.rbPatron.Name = "rbPatron";
            this.rbPatron.Size = new System.Drawing.Size(56, 17);
            this.rbPatron.TabIndex = 18;
            this.rbPatron.Text = "Patrón";
            this.rbPatron.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbNoTieneContraseña);
            this.groupBox3.Controls.Add(this.rbSiTieneContraseña);
            this.groupBox3.Location = new System.Drawing.Point(151, 309);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(120, 36);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "¿Tiene Contraseña?";
            // 
            // rbNoTieneContraseña
            // 
            this.rbNoTieneContraseña.AutoSize = true;
            this.rbNoTieneContraseña.Checked = true;
            this.rbNoTieneContraseña.Location = new System.Drawing.Point(57, 19);
            this.rbNoTieneContraseña.Name = "rbNoTieneContraseña";
            this.rbNoTieneContraseña.Size = new System.Drawing.Size(39, 17);
            this.rbNoTieneContraseña.TabIndex = 19;
            this.rbNoTieneContraseña.TabStop = true;
            this.rbNoTieneContraseña.Text = "No";
            this.rbNoTieneContraseña.UseVisualStyleBackColor = true;
            // 
            // rbSiTieneContraseña
            // 
            this.rbSiTieneContraseña.AutoSize = true;
            this.rbSiTieneContraseña.Location = new System.Drawing.Point(6, 19);
            this.rbSiTieneContraseña.Name = "rbSiTieneContraseña";
            this.rbSiTieneContraseña.Size = new System.Drawing.Size(34, 17);
            this.rbSiTieneContraseña.TabIndex = 20;
            this.rbSiTieneContraseña.Text = "Si";
            this.rbSiTieneContraseña.UseVisualStyleBackColor = true;
            // 
            // Agregar_Celular_Form
            // 
            this.AcceptButton = this.btnAgregarCel;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.ClientSize = new System.Drawing.Size(488, 527);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtProblema);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtModelo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMarca);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAgregarCel);
            this.Name = "Agregar_Celular_Form";
            this.Text = "Agregar Celular";
            this.Load += new System.EventHandler(this.Agregar_Celular_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAgregarCel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TextBox txtMarca;
        private System.Windows.Forms.TextBox txtContraseña;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtProblema;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtModelo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnPassAyuda;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbPatron;
        private System.Windows.Forms.RadioButton rbNumerico;
        private System.Windows.Forms.RadioButton rdContraseña;
        private System.Windows.Forms.RadioButton rbExtraEstado;
        private System.Windows.Forms.RadioButton rbEnEspera;
        private System.Windows.Forms.RadioButton rbEnReparacion;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rbNoTieneContraseña;
        private System.Windows.Forms.RadioButton rbSiTieneContraseña;
    }
}