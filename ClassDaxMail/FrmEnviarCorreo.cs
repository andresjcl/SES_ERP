using DattCom;
using directMnt;
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
	public partial class FrmEnviarCorreo : Form
	{
        private string[] pathfilesAdjuntos = new string[2];
        private string StrConxSysemp = "";
        public FrmEnviarCorreo(string strAsunto,string strTo,string strDetalle,string strCC,string strconxsys,string strAdjuntos)
        {
            this.InitializeComponent();
            this.txtAsunto.Text = strAsunto;
            this.txtEnviarA.Text = strTo;
            this.txtConCopiaA.Text = strCC;
            this.txtDetalle.Text = strDetalle;
            this.txtAdjuntos.Text = strAdjuntos;
            this.StrConxSysemp = strconxsys;
            this.CargarAdjuntos();
        }

        private void CargarAdjuntos()
        {
            if (string.IsNullOrEmpty(this.txtAdjuntos.Text))
                return;
            this.pathfilesAdjuntos = (this.txtAdjuntos.Text + ";;;;;").Split(Convert.ToChar(";"));
        }

		private void btnBuscaDirectorio_Click(object sender, EventArgs e)
		{
            string CodigoAlex = new directMnt.BusDirectorio().BusDirect("", "", "", "");
            DirectorioAlex directorioAlex = new DirectorioAlex();
            string SoloCodigo = "";
            bool ClioPro = false;
            directorioAlex.CargarAlex(ref CodigoAlex, ref ClioPro, ref SoloCodigo);
            if (directorioAlex.correoElectronico.Length > 0)
            {
                if (this.txtEnviarA.Text.Length > 0)
                    this.txtEnviarA.Text += ";";
                this.txtEnviarA.Text += directorioAlex.correoElectronico;
            }
        }

		private void btnAdjuntos_Click(object sender, EventArgs e)
		{
            string str = string.Empty;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = "";
            openFileDialog1.Filter = "Archivos electrónicos (*.pdf)|*.pdf|Documentos electrónicos (*.xml)|*.xml|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            OpenFileDialog openFileDialog2 = openFileDialog1;
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
                str = openFileDialog2.FileName;
            if (str.Length > 0 && this.txtAdjuntos.Text.Length > 0)
                this.txtAdjuntos.Text += ";";
            this.txtAdjuntos.Text += str;
        }

		private void btnEnviarCorreo_Click(object sender, EventArgs e)
		{
            EnvCorreoSmtp envCorreoSmtp = new EnvCorreoSmtp(this.StrConxSysemp);
            this.CargarAdjuntos();
            this.Close();
        }

		private void btnCancelar_Click(object sender, EventArgs e) => this.Close();

		private void btnConfigurar_Click(object sender, EventArgs e)
		{
            frmRegistraDatosEmail registraDatosEmail = new frmRegistraDatosEmail(this.StrConxSysemp, datosEmpresa.codEmpresa.ToString());
            int num = (int)registraDatosEmail.ShowDialog();
            registraDatosEmail.Dispose();
        }
	}
}
