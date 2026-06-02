
using System.Drawing;
using System.Windows.Forms;

namespace ClassDaxMail
{
	partial class frmRegistraDatosEmail
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
        //private void InitializeComponent()
        //{
        //	this.SuspendLayout();
        //	// 
        //	// frmRegistraDatosEmail
        //	// 
        //	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        //	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        //	this.ClientSize = new System.Drawing.Size(800, 450);
        //	this.Name = "frmRegistraDatosEmail";
        //	this.Text = "frmRegistraDatosEmail";
        //	this.ResumeLayout(false);
        //}

        private void InitializeComponent()
        {
			this.ChkSSL = new System.Windows.Forms.CheckBox();
			this.txtPuerto = new System.Windows.Forms.TextBox();
			this.txtClave = new System.Windows.Forms.TextBox();
			this.txtUsuario = new System.Windows.Forms.TextBox();
			this.txtSmtp = new System.Windows.Forms.TextBox();
			this.txtCorreo = new System.Windows.Forms.TextBox();
			this.lblCorreo = new System.Windows.Forms.Label();
			this.lblUsuario = new System.Windows.Forms.Label();
			this.lblClave = new System.Windows.Forms.Label();
			this.lblSmtp = new System.Windows.Forms.Label();
			this.lblPuerto = new System.Windows.Forms.Label();
			this.btnAceptar = new System.Windows.Forms.Button();
			this.btnCancelar = new System.Windows.Forms.Button();
			this.btnProbar = new System.Windows.Forms.Button();
			this.groupCuenta = new System.Windows.Forms.GroupBox();
			this.groupTipo = new System.Windows.Forms.GroupBox();
			this.chkMailSmtp = new System.Windows.Forms.RadioButton();
			this.chkMailOutlook = new System.Windows.Forms.RadioButton();
			this.groupCuenta.SuspendLayout();
			this.groupTipo.SuspendLayout();
			this.SuspendLayout();
			// 
			// ChkSSL
			// 
			this.ChkSSL.ForeColor = System.Drawing.Color.SteelBlue;
			this.ChkSSL.Location = new System.Drawing.Point(132, 226);
			this.ChkSSL.Name = "ChkSSL";
			this.ChkSSL.Size = new System.Drawing.Size(104, 24);
			this.ChkSSL.TabIndex = 10;
			this.ChkSSL.Text = "Usa conexión encriptada SSL";
			// 
			// txtPuerto
			// 
			this.txtPuerto.Location = new System.Drawing.Point(19, 225);
			this.txtPuerto.Name = "txtPuerto";
			this.txtPuerto.Size = new System.Drawing.Size(73, 20);
			this.txtPuerto.TabIndex = 9;
			// 
			// txtClave
			// 
			this.txtClave.Location = new System.Drawing.Point(19, 134);
			this.txtClave.Name = "txtClave";
			this.txtClave.PasswordChar = '*';
			this.txtClave.Size = new System.Drawing.Size(421, 20);
			this.txtClave.TabIndex = 5;
			// 
			// txtUsuario
			// 
			this.txtUsuario.Location = new System.Drawing.Point(20, 91);
			this.txtUsuario.Name = "txtUsuario";
			this.txtUsuario.Size = new System.Drawing.Size(421, 20);
			this.txtUsuario.TabIndex = 3;
			// 
			// txtSmtp
			// 
			this.txtSmtp.Location = new System.Drawing.Point(19, 182);
			this.txtSmtp.Name = "txtSmtp";
			this.txtSmtp.Size = new System.Drawing.Size(422, 20);
			this.txtSmtp.TabIndex = 7;
			// 
			// txtCorreo
			// 
			this.txtCorreo.Location = new System.Drawing.Point(20, 48);
			this.txtCorreo.Name = "txtCorreo";
			this.txtCorreo.Size = new System.Drawing.Size(517, 20);
			this.txtCorreo.TabIndex = 1;
			// 
			// lblCorreo
			// 
			this.lblCorreo.ForeColor = System.Drawing.Color.SteelBlue;
			this.lblCorreo.Location = new System.Drawing.Point(17, 31);
			this.lblCorreo.Name = "lblCorreo";
			this.lblCorreo.Size = new System.Drawing.Size(100, 23);
			this.lblCorreo.TabIndex = 0;
			this.lblCorreo.Text = "Correo electrónico de la cuenta";
			// 
			// lblUsuario
			// 
			this.lblUsuario.ForeColor = System.Drawing.Color.SteelBlue;
			this.lblUsuario.Location = new System.Drawing.Point(20, 74);
			this.lblUsuario.Name = "lblUsuario";
			this.lblUsuario.Size = new System.Drawing.Size(100, 23);
			this.lblUsuario.TabIndex = 2;
			this.lblUsuario.Text = "Id. usuario de la cuenta:";
			// 
			// lblClave
			// 
			this.lblClave.ForeColor = System.Drawing.Color.SteelBlue;
			this.lblClave.Location = new System.Drawing.Point(19, 117);
			this.lblClave.Name = "lblClave";
			this.lblClave.Size = new System.Drawing.Size(100, 23);
			this.lblClave.TabIndex = 4;
			this.lblClave.Text = "Clave secreta:";
			// 
			// lblSmtp
			// 
			this.lblSmtp.ForeColor = System.Drawing.Color.SteelBlue;
			this.lblSmtp.Location = new System.Drawing.Point(16, 165);
			this.lblSmtp.Name = "lblSmtp";
			this.lblSmtp.Size = new System.Drawing.Size(100, 23);
			this.lblSmtp.TabIndex = 6;
			this.lblSmtp.Text = "Servidor de correo smtp";
			// 
			// lblPuerto
			// 
			this.lblPuerto.ForeColor = System.Drawing.Color.SteelBlue;
			this.lblPuerto.Location = new System.Drawing.Point(16, 208);
			this.lblPuerto.Name = "lblPuerto";
			this.lblPuerto.Size = new System.Drawing.Size(100, 23);
			this.lblPuerto.TabIndex = 8;
			this.lblPuerto.Text = "Nro Puerto:";
			// 
			// btnAceptar
			// 
			this.btnAceptar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnAceptar.ForeColor = System.Drawing.Color.White;
			this.btnAceptar.Location = new System.Drawing.Point(61, 401);
			this.btnAceptar.Name = "btnAceptar";
			this.btnAceptar.Size = new System.Drawing.Size(75, 23);
			this.btnAceptar.TabIndex = 2;
			this.btnAceptar.Text = "Aceptar";
			this.btnAceptar.UseVisualStyleBackColor = false;
			this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
			// 
			// btnCancelar
			// 
			this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnCancelar.ForeColor = System.Drawing.Color.White;
			this.btnCancelar.Location = new System.Drawing.Point(192, 401);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(75, 23);
			this.btnCancelar.TabIndex = 3;
			this.btnCancelar.Text = "Cancelar";
			this.btnCancelar.UseVisualStyleBackColor = false;
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			// 
			// btnProbar
			// 
			this.btnProbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.btnProbar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnProbar.ForeColor = System.Drawing.Color.White;
			this.btnProbar.Location = new System.Drawing.Point(582, 401);
			this.btnProbar.Name = "btnProbar";
			this.btnProbar.Size = new System.Drawing.Size(75, 23);
			this.btnProbar.TabIndex = 4;
			this.btnProbar.Text = "Probar";
			this.btnProbar.UseVisualStyleBackColor = false;
			this.btnProbar.Click += new System.EventHandler(this.btnProbar_Click);
			// 
			// groupCuenta
			// 
			this.groupCuenta.Controls.Add(this.lblCorreo);
			this.groupCuenta.Controls.Add(this.txtCorreo);
			this.groupCuenta.Controls.Add(this.lblUsuario);
			this.groupCuenta.Controls.Add(this.txtUsuario);
			this.groupCuenta.Controls.Add(this.lblClave);
			this.groupCuenta.Controls.Add(this.txtClave);
			this.groupCuenta.Controls.Add(this.lblSmtp);
			this.groupCuenta.Controls.Add(this.txtSmtp);
			this.groupCuenta.Controls.Add(this.lblPuerto);
			this.groupCuenta.Controls.Add(this.txtPuerto);
			this.groupCuenta.Controls.Add(this.ChkSSL);
			this.groupCuenta.Location = new System.Drawing.Point(60, 111);
			this.groupCuenta.Name = "groupCuenta";
			this.groupCuenta.Size = new System.Drawing.Size(633, 262);
			this.groupCuenta.TabIndex = 1;
			this.groupCuenta.TabStop = false;
			this.groupCuenta.Text = "Cuenta personalizada";
			// 
			// groupTipo
			// 
			this.groupTipo.Controls.Add(this.chkMailSmtp);
			this.groupTipo.Controls.Add(this.chkMailOutlook);
			this.groupTipo.Location = new System.Drawing.Point(60, 35);
			this.groupTipo.Name = "groupTipo";
			this.groupTipo.Size = new System.Drawing.Size(633, 60);
			this.groupTipo.TabIndex = 0;
			this.groupTipo.TabStop = false;
			this.groupTipo.Text = "Utilizar cuenta tipo:";
			// 
			// chkMailSmtp
			// 
			this.chkMailSmtp.ForeColor = System.Drawing.Color.SteelBlue;
			this.chkMailSmtp.Location = new System.Drawing.Point(37, 28);
			this.chkMailSmtp.Name = "chkMailSmtp";
			this.chkMailSmtp.Size = new System.Drawing.Size(104, 24);
			this.chkMailSmtp.TabIndex = 0;
			this.chkMailSmtp.Text = "Personalizada";
			// 
			// chkMailOutlook
			// 
			this.chkMailOutlook.ForeColor = System.Drawing.Color.SteelBlue;
			this.chkMailOutlook.Location = new System.Drawing.Point(189, 28);
			this.chkMailOutlook.Name = "chkMailOutlook";
			this.chkMailOutlook.Size = new System.Drawing.Size(104, 24);
			this.chkMailOutlook.TabIndex = 1;
			this.chkMailOutlook.Text = "Outlook";
			// 
			// frmRegistraDatosEmail
			// 
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(746, 460);
			this.ControlBox = false;
			this.Controls.Add(this.groupTipo);
			this.Controls.Add(this.groupCuenta);
			this.Controls.Add(this.btnAceptar);
			this.Controls.Add(this.btnCancelar);
			this.Controls.Add(this.btnProbar);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "frmRegistraDatosEmail";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "REGISTRAR CUENTA PARA ENVÍO DE CORREO ELECTRÓNICO";
			this.groupCuenta.ResumeLayout(false);
			this.groupCuenta.PerformLayout();
			this.groupTipo.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        private TextBox txtCorreo, txtUsuario, txtClave, txtSmtp, txtPuerto;
        private CheckBox ChkSSL;

        private Label lblCorreo, lblUsuario, lblClave, lblSmtp, lblPuerto;

        private Button btnAceptar, btnCancelar, btnProbar;

        private GroupBox groupCuenta, groupTipo;

        private RadioButton chkMailSmtp, chkMailOutlook;


        #endregion
    }
}