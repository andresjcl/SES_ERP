using AuditSis;
using DattCom;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClassDaxMail
{	
	public partial class frmRegistraDatosEmail : Form
	{
        private string StrConxSysemp = "";
        private string CodEmpresa = "0";
        public frmRegistraDatosEmail(string strconxsys, string codempresa)
		{
			InitializeComponent();
			this.StrConxSysemp = strconxsys;
			this.CodEmpresa = codempresa;
			this.cargarParametros();
		}

        private void GuardarParámetros()
        {
            string Valor = "";
            registrar.registraPreferencia(this.StrConxSysemp, this.CodEmpresa, "sys", "ADC", "", "mail", "correo", this.txtCorreo.Text);
            registrar.registraPreferencia(this.StrConxSysemp, this.CodEmpresa, "sys", "ADC", "", "mail", "smtp", this.txtSmtp.Text);
            registrar.registraPreferencia(this.StrConxSysemp, this.CodEmpresa, "sys", "ADC", "", "mail", "user", this.txtUsuario.Text);
            registrar.registraPreferencia(this.StrConxSysemp, this.CodEmpresa, "sys", "ADC", "", "mail", "clave", this.txtClave.Text);
            registrar.registraPreferencia(this.StrConxSysemp, this.CodEmpresa, "sys", "ADC", "", "mail", "puerto", this.txtPuerto.Text);
            if (this.ChkSSL.Checked)
                Valor = "S";
            registrar.registraPreferencia(this.StrConxSysemp, this.CodEmpresa, "sys", "ADC", "", "mail", "SSL", Valor);
            if (this.chkMailOutlook.Checked)
                Valor = "outlook";
            if (this.chkMailSmtp.Checked)
                Valor = "smtp";
            registrar.registraPreferencia(this.StrConxSysemp, this.CodEmpresa, "sys", "ADC", "", "mail", "TipoCta", Valor);
        }

        private void cargarParametros()
        {
            this.txtCorreo.Text = registrar.obtenerPreferencia(this.StrConxSysemp, this.CodEmpresa, "sys", "ADC", "", "mail", "correo");
            this.txtSmtp.Text = registrar.obtenerPreferencia(this.StrConxSysemp, this.CodEmpresa, "sys", "ADC", "", "mail", "smtp");
            this.txtUsuario.Text = registrar.obtenerPreferencia(this.StrConxSysemp, this.CodEmpresa, "sys", "ADC", "", "mail", "user");
            this.txtClave.Text = registrar.obtenerPreferencia(this.StrConxSysemp, this.CodEmpresa, "sys", "ADC", "", "mail", "clave");
            this.txtPuerto.Text = registrar.obtenerPreferencia(this.StrConxSysemp, this.CodEmpresa, "sys", "ADC", "", "mail", "puerto");
            if (registrar.obtenerPreferencia(this.StrConxSysemp, this.CodEmpresa, "sys", "ADC", "", "mail", "SSL") == "S")
                this.ChkSSL.Checked = true;
            string str = registrar.obtenerPreferencia(this.StrConxSysemp, this.CodEmpresa, "sys", "ADC", "", "mail", "TipoCta");
            if (str == "smtp")
                this.chkMailSmtp.Checked = true;
            if (!(str == "outlook"))
                return;
            this.chkMailSmtp.Checked = true;
        }

		private void btnAceptar_Click(object sender, EventArgs e)
		{
            this.GuardarParámetros();
            this.Close();
        }

		private void btnCancelar_Click(object sender, EventArgs e) => this.Close();

		private void btnProbar_Click(object sender, EventArgs e)
		{
            this.GuardarParámetros();
            EnvCorreoSmtp envCorreoSmtp = new EnvCorreoSmtp(datosEmpresa.strConIniSis, datosEmpresa.Emp_codigo);
            string ToCorreos = "asistenciadax2022@gmail.com";
            string text = this.txtCorreo.Text;
            string str = "Prueba corrreo " + datosEmpresa.nomEmpresa;
            string Mensaje = " Mensaje de prueba de funcionamiento correo smtp";
            if (!this.chkMailOutlook.Checked)
            {
                int num1 = (int)MessageBox.Show(envCorreoSmtp.EnviarCorreoSmpt(ToCorreos, text, str, Mensaje, ""));
            }
            else
            {
                string mailAdjuntos = " Mensaje de prueba de funcionamiento correo via Outlook ";
                int num2 = (int)MessageBox.Show(EnvCorreoOutlook.EnviarCorreoConOutlook(ToCorreos, text, str, mailAdjuntos, ""));
            }
        }
	}
}
