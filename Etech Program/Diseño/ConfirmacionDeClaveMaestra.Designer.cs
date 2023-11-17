namespace Diseño
{
    partial class Confirmacion_Con_ContraseñaMaestro
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
            this.btnAceptar = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.labelContraseñaMaestra_Text = new System.Windows.Forms.Label();
            this.txtClaveMaestra = new System.Windows.Forms.TextBox();
            this.chbOcultarContraseña = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.Snow;
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAceptar.Location = new System.Drawing.Point(239, 88);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(71, 23);
            this.btnAceptar.TabIndex = 0;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Black;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.ForeColor = System.Drawing.SystemColors.Control;
            this.button2.Location = new System.Drawing.Point(12, 88);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(63, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Cancelar";
            this.button2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // labelContraseñaMaestra_Text
            // 
            this.labelContraseñaMaestra_Text.AutoSize = true;
            this.labelContraseñaMaestra_Text.Cursor = System.Windows.Forms.Cursors.Default;
            this.labelContraseñaMaestra_Text.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelContraseñaMaestra_Text.ForeColor = System.Drawing.SystemColors.Control;
            this.labelContraseñaMaestra_Text.Location = new System.Drawing.Point(9, 9);
            this.labelContraseñaMaestra_Text.Name = "labelContraseñaMaestra_Text";
            this.labelContraseñaMaestra_Text.Size = new System.Drawing.Size(89, 15);
            this.labelContraseñaMaestra_Text.TabIndex = 2;
            this.labelContraseñaMaestra_Text.Text = "Clave Maestra";
            // 
            // txtClaveMaestra
            // 
            this.txtClaveMaestra.Location = new System.Drawing.Point(12, 27);
            this.txtClaveMaestra.Name = "txtClaveMaestra";
            this.txtClaveMaestra.Size = new System.Drawing.Size(298, 21);
            this.txtClaveMaestra.TabIndex = 3;
            // 
            // chbOcultarContraseña
            // 
            this.chbOcultarContraseña.AutoSize = true;
            this.chbOcultarContraseña.CausesValidation = false;
            this.chbOcultarContraseña.Checked = true;
            this.chbOcultarContraseña.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbOcultarContraseña.Cursor = System.Windows.Forms.Cursors.Default;
            this.chbOcultarContraseña.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chbOcultarContraseña.Location = new System.Drawing.Point(12, 54);
            this.chbOcultarContraseña.Name = "chbOcultarContraseña";
            this.chbOcultarContraseña.Size = new System.Drawing.Size(13, 12);
            this.chbOcultarContraseña.TabIndex = 4;
            this.chbOcultarContraseña.UseVisualStyleBackColor = true;
            this.chbOcultarContraseña.Visible = false;
            // 
            // Confirmacion_Con_ContraseñaMaestro
            // 
            this.AcceptButton = this.btnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.CancelButton = this.button2;
            this.ClientSize = new System.Drawing.Size(325, 120);
            this.ControlBox = false;
            this.Controls.Add(this.chbOcultarContraseña);
            this.Controls.Add(this.txtClaveMaestra);
            this.Controls.Add(this.labelContraseñaMaestra_Text);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnAceptar);
            this.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.HelpButton = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Confirmacion_Con_ContraseñaMaestro";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Confirmacion_Con_ContraseñaMaestro_FormClosing);
            this.Load += new System.EventHandler(this.Confirmacion_Con_ContraseñaMaestro_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Confirmacion_Con_ContraseñaMaestro_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Confirmacion_Con_ContraseñaMaestro_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Confirmacion_Con_ContraseñaMaestro_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label labelContraseñaMaestra_Text;
        private System.Windows.Forms.TextBox txtClaveMaestra;
        private System.Windows.Forms.CheckBox chbOcultarContraseña;
    }
}