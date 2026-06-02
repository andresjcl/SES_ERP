namespace adcEnvmail
{
    partial class Form1
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
            this.txtPuerto = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.Button2 = new System.Windows.Forms.Button();
            this.Button1 = new System.Windows.Forms.Button();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.txtSmtp = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtPuerto
            // 
            this.txtPuerto.Location = new System.Drawing.Point(80, 70);
            this.txtPuerto.Name = "txtPuerto";
            this.txtPuerto.Size = new System.Drawing.Size(90, 20);
            this.txtPuerto.TabIndex = 23;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(7, 112);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(47, 13);
            this.Label5.TabIndex = 22;
            this.Label5.Text = "usuario :";
            // 
            // Button2
            // 
            this.Button2.BackColor = System.Drawing.Color.SteelBlue;
            this.Button2.ForeColor = System.Drawing.Color.White;
            this.Button2.Location = new System.Drawing.Point(472, 179);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(84, 25);
            this.Button2.TabIndex = 21;
            this.Button2.Text = "Cancelar";
            this.Button2.UseVisualStyleBackColor = false;
            this.Button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // Button1
            // 
            this.Button1.BackColor = System.Drawing.Color.SteelBlue;
            this.Button1.ForeColor = System.Drawing.Color.White;
            this.Button1.Location = new System.Drawing.Point(373, 179);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(84, 25);
            this.Button1.TabIndex = 20;
            this.Button1.Text = "Aceptar";
            this.Button1.UseVisualStyleBackColor = false;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // txtClave
            // 
            this.txtClave.Location = new System.Drawing.Point(91, 133);
            this.txtClave.Name = "txtClave";
            this.txtClave.Size = new System.Drawing.Size(379, 20);
            this.txtClave.TabIndex = 19;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(7, 137);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(75, 13);
            this.Label4.TabIndex = 18;
            this.Label4.Text = "Clave secreta:";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(62, 109);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(379, 20);
            this.txtUsuario.TabIndex = 17;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(7, 74);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(64, 13);
            this.Label3.TabIndex = 16;
            this.Label3.Text = "Nro Puerto :";
            // 
            // txtSmtp
            // 
            this.txtSmtp.Location = new System.Drawing.Point(106, 45);
            this.txtSmtp.Name = "txtSmtp";
            this.txtSmtp.Size = new System.Drawing.Size(379, 20);
            this.txtSmtp.TabIndex = 15;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(7, 49);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(94, 13);
            this.Label2.TabIndex = 14;
            this.Label2.Text = "Servidor de correo";
            // 
            // txtCorreo
            // 
            this.txtCorreo.Location = new System.Drawing.Point(131, 10);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(421, 20);
            this.txtCorreo.TabIndex = 13;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(7, 14);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(118, 13);
            this.Label1.TabIndex = 12;
            this.Label1.Text = "Correo electrónico local";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(569, 208);
            this.ControlBox = false;
            this.Controls.Add(this.txtPuerto);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.Button2);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.txtClave);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.txtSmtp);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.txtCorreo);
            this.Controls.Add(this.Label1);
            this.Name = "Form1";
            this.Text = "Registrar datos para envío de correo electrónico";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox txtPuerto;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Button Button2;
        internal System.Windows.Forms.Button Button1;
        internal System.Windows.Forms.TextBox txtClave;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.TextBox txtUsuario;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TextBox txtSmtp;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox txtCorreo;
        internal System.Windows.Forms.Label Label1;
    }
}