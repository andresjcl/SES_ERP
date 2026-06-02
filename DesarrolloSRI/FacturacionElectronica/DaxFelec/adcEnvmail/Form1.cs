using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace adcEnvmail
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string strSmtp = string.Empty ;
        public string strCorreo = string.Empty ;
        public string strUsuario = string.Empty ;
        public string strClave = string.Empty ;
        public string strPuerto = string.Empty ;
        public string StrConxSysemp10 = string.Empty;
        
        private AdcHisOpc.AdcHistOpc AdcSettings = new AdcHisOpc.AdcHistOpc();

        private void Button1_Click(object sender, EventArgs e)
        {
            strClave = txtClave.Text;
            strCorreo = txtCorreo.Text;
            strSmtp = txtSmtp.Text;
            strUsuario = txtUsuario.Text;
            AdcSettings.GrabarOpcionHis(StrConxSysemp10, "", "ADC", "", "mail", "smtp", strSmtp,DateTime.Now );
            AdcSettings.GrabarOpcionHis(StrConxSysemp10, "", "ADC", "", "mail", "user", strUsuario, DateTime.Now);
            AdcSettings.GrabarOpcionHis(StrConxSysemp10, "", "ADC", "", "mail", "clave", strClave, DateTime.Now);
            AdcSettings.GrabarOpcionHis(StrConxSysemp10, "", "ADC", "", "mail", "correo", strCorreo, DateTime.Now);
            AdcSettings.GrabarOpcionHis(StrConxSysemp10, "", "ADC", "", "mail", "puerto", strPuerto, DateTime.Now);
            this.Close();        
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            strSmtp = "";
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtClave.Text = strClave;
            txtCorreo.Text = strCorreo;
            txtSmtp.Text = strSmtp;
            txtUsuario.Text = strUsuario;
            txtPuerto.Text = strPuerto;
        }
    }
}
