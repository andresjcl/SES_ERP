using System.Drawing;
using System.Windows.Forms;

namespace ClassDaxMail
{
    partial class frmRegistraDatosEmail
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

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
            this.btnMostrarClave = new System.Windows.Forms.Button();
            this.groupTipo = new System.Windows.Forms.GroupBox();
            this.chkMailSmtp = new System.Windows.Forms.RadioButton();
            this.chkMailOutlook = new System.Windows.Forms.RadioButton();
            this.lblTipoCuenta = new System.Windows.Forms.Label();
            this.groupCuenta.SuspendLayout();
            this.groupTipo.SuspendLayout();
            this.SuspendLayout();
            // 
            // ChkSSL
            // 
            this.ChkSSL.ForeColor = System.Drawing.Color.SteelBlue;
            this.ChkSSL.Location = new System.Drawing.Point(132, 232);
            this.ChkSSL.Name = "ChkSSL";
            this.ChkSSL.Size = new System.Drawing.Size(294, 24);
            this.ChkSSL.TabIndex = 10;
            this.ChkSSL.Text = "Usa conexión encriptada SSL";
            // 
            // txtPuerto
            // 
            this.txtPuerto.Location = new System.Drawing.Point(19, 229);
            this.txtPuerto.Name = "txtPuerto";
            this.txtPuerto.Size = new System.Drawing.Size(73, 22);
            this.txtPuerto.TabIndex = 9;
            // 
            // txtClave
            // 
            this.txtClave.Location = new System.Drawing.Point(19, 134);
            this.txtClave.Name = "txtClave";
            this.txtClave.PasswordChar = '*';
            this.txtClave.Size = new System.Drawing.Size(421, 22);
            this.txtClave.TabIndex = 5;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(20, 91);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(517, 22);
            this.txtUsuario.TabIndex = 3;
            // 
            // txtSmtp
            // 
            this.txtSmtp.Location = new System.Drawing.Point(19, 181);
            this.txtSmtp.Name = "txtSmtp";
            this.txtSmtp.Size = new System.Drawing.Size(518, 22);
            this.txtSmtp.TabIndex = 7;
            // 
            // txtCorreo
            // 
            this.txtCorreo.Location = new System.Drawing.Point(20, 43);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(517, 22);
            this.txtCorreo.TabIndex = 1;
            // 
            // lblCorreo
            // 
            this.lblCorreo.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblCorreo.Location = new System.Drawing.Point(17, 21);
            this.lblCorreo.Name = "lblCorreo";
            this.lblCorreo.Size = new System.Drawing.Size(150, 23);
            this.lblCorreo.TabIndex = 0;
            this.lblCorreo.Text = "Correo electrónico de la cuenta";
            // 
            // lblUsuario
            // 
            this.lblUsuario.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblUsuario.Location = new System.Drawing.Point(20, 73);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(226, 23);
            this.lblUsuario.TabIndex = 2;
            this.lblUsuario.Text = "Id. usuario de la cuenta:";
            // 
            // lblClave
            // 
            this.lblClave.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblClave.Location = new System.Drawing.Point(19, 116);
            this.lblClave.Name = "lblClave";
            this.lblClave.Size = new System.Drawing.Size(150, 23);
            this.lblClave.TabIndex = 4;
            this.lblClave.Text = "Clave secreta:";
            // 
            // lblSmtp
            // 
            this.lblSmtp.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblSmtp.Location = new System.Drawing.Point(16, 160);
            this.lblSmtp.Name = "lblSmtp";
            this.lblSmtp.Size = new System.Drawing.Size(199, 23);
            this.lblSmtp.TabIndex = 6;
            this.lblSmtp.Text = "Servidor de correo smtp";
            // 
            // lblPuerto
            // 
            this.lblPuerto.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblPuerto.Location = new System.Drawing.Point(16, 211);
            this.lblPuerto.Name = "lblPuerto";
            this.lblPuerto.Size = new System.Drawing.Size(100, 23);
            this.lblPuerto.TabIndex = 8;
            this.lblPuerto.Text = "Nro Puerto:";
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptar.ForeColor = System.Drawing.Color.White;
            this.btnAceptar.Location = new System.Drawing.Point(190, 401);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(100, 30);
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "Guardar";
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(192, 57, 43);
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(320, 401);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 30);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnProbar
            // 
            this.btnProbar.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this.btnProbar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProbar.ForeColor = System.Drawing.Color.White;
            this.btnProbar.Location = new System.Drawing.Point(570, 401);
            this.btnProbar.Name = "btnProbar";
            this.btnProbar.Size = new System.Drawing.Size(100, 30);
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
            this.groupCuenta.Controls.Add(this.btnMostrarClave);
            this.groupCuenta.Controls.Add(this.lblSmtp);
            this.groupCuenta.Controls.Add(this.txtSmtp);
            this.groupCuenta.Controls.Add(this.lblPuerto);
            this.groupCuenta.Controls.Add(this.txtPuerto);
            this.groupCuenta.Controls.Add(this.ChkSSL);
            this.groupCuenta.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupCuenta.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.groupCuenta.Location = new System.Drawing.Point(60, 86);
            this.groupCuenta.Name = "groupCuenta";
            this.groupCuenta.Size = new System.Drawing.Size(633, 280);
            this.groupCuenta.TabIndex = 1;
            this.groupCuenta.TabStop = false;
            this.groupCuenta.Text = "Cuenta SMTP Personalizada";
            // 
            // btnMostrarClave
            // 
            this.btnMostrarClave.BackColor = System.Drawing.Color.Gainsboro;
            this.btnMostrarClave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMostrarClave.ForeColor = System.Drawing.Color.Black;
            this.btnMostrarClave.Location = new System.Drawing.Point(446, 133);
            this.btnMostrarClave.Name = "btnMostrarClave";
            this.btnMostrarClave.Size = new System.Drawing.Size(116, 23);
            this.btnMostrarClave.TabIndex = 6;
            this.btnMostrarClave.Text = "Mostrar";
            this.btnMostrarClave.UseVisualStyleBackColor = false;
            this.btnMostrarClave.Click += new System.EventHandler(this.btnMostrarClave_Click);
            // 
            // groupTipo
            // 
            this.groupTipo.Controls.Add(this.chkMailSmtp);
            this.groupTipo.Controls.Add(this.chkMailOutlook);
            this.groupTipo.Controls.Add(this.lblTipoCuenta);
            this.groupTipo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupTipo.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.groupTipo.Location = new System.Drawing.Point(60, 12);
            this.groupTipo.Name = "groupTipo";
            this.groupTipo.Size = new System.Drawing.Size(633, 57);
            this.groupTipo.TabIndex = 0;
            this.groupTipo.TabStop = false;
            this.groupTipo.Text = "Utilizar cuenta tipo:";
            // 
            // chkMailSmtp
            // 
            this.chkMailSmtp.Checked = true;
            this.chkMailSmtp.ForeColor = System.Drawing.Color.SteelBlue;
            this.chkMailSmtp.Location = new System.Drawing.Point(338, 24);
            this.chkMailSmtp.Name = "chkMailSmtp";
            this.chkMailSmtp.Size = new System.Drawing.Size(146, 24);
            this.chkMailSmtp.TabIndex = 0;
            this.chkMailSmtp.TabStop = true;
            this.chkMailSmtp.Text = "Personalizada";
            this.chkMailSmtp.Visible = true;  // CAMBIADO a true
            // 
            // chkMailOutlook
            // 
            this.chkMailOutlook.ForeColor = System.Drawing.Color.SteelBlue;
            this.chkMailOutlook.Location = new System.Drawing.Point(490, 25);
            this.chkMailOutlook.Name = "chkMailOutlook";
            this.chkMailOutlook.Size = new System.Drawing.Size(120, 24);
            this.chkMailOutlook.TabIndex = 1;
            this.chkMailOutlook.Text = "Outlook";
            this.chkMailOutlook.Visible = true;  // CAMBIADO a true
            // 
            // lblTipoCuenta
            // 
            this.lblTipoCuenta.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTipoCuenta.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblTipoCuenta.Location = new System.Drawing.Point(32, 24);
            this.lblTipoCuenta.Name = "lblTipoCuenta";
            this.lblTipoCuenta.Size = new System.Drawing.Size(300, 25);
            this.lblTipoCuenta.TabIndex = 0;
            this.lblTipoCuenta.Text = "Configuración SMTP Personalizada";
            this.lblTipoCuenta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmRegistraDatosEmail
            // 
            this.BackColor = System.Drawing.Color.FromArgb(236, 240, 241);
            this.ClientSize = new System.Drawing.Size(746, 460);
            this.ControlBox = false;
            this.Controls.Add(this.groupTipo);
            this.Controls.Add(this.groupCuenta);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnProbar);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmRegistraDatosEmail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "REGISTRAR CUENTA PARA ENVÍO DE CORREO ELECTRÓNICO";
            this.groupCuenta.ResumeLayout(false);
            this.groupCuenta.PerformLayout();
            this.groupTipo.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        // Controles
        private TextBox txtCorreo, txtUsuario, txtClave, txtSmtp, txtPuerto;
        private CheckBox ChkSSL;
        private Label lblCorreo, lblUsuario, lblClave, lblSmtp, lblPuerto;
        private Label lblTipoCuenta;
        private Button btnAceptar, btnCancelar, btnProbar;
        private Button btnMostrarClave;
        private GroupBox groupCuenta, groupTipo;
        private RadioButton chkMailSmtp, chkMailOutlook;
    }
}