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
    public partial class Form2 : Form
    {
        public string StrConxSysemp10 = string.Empty;
        public string strDe;
        public string strA;
        public string strAsunto;
        public string strDetalle;
        private AdcHisOpc.AdcHistOpc AdcSettings = new AdcHisOpc.AdcHistOpc();
        public Form2()
        {
            InitializeComponent();

        }
        private void Form2_Load()
        {
            txtAsunto.Text = strAsunto;
            txtDestino.Text = strA;
            txtDetalle.Text = strDetalle;
            txtOrigen.Text = strDe;
        }

        private void btnConfigurar_Click(object sender, EventArgs e)
        {
            string strSmtp = AdcSettings.CargarOpcionHis(StrConxSysemp10, "", "ADC", "", "mail", "smtp");
            string strUser = AdcSettings.CargarOpcionHis(StrConxSysemp10, "", "ADC", "", "mail", "user");
            string strClave = AdcSettings.CargarOpcionHis(StrConxSysemp10, "", "ADC", "", "mail", "clave");
            string strCorreo = AdcSettings.CargarOpcionHis(StrConxSysemp10, "", "ADC", "", "mail", "correo");

            Form1  prog = new Form1();

            prog.strClave = strClave;
            prog.strCorreo = strCorreo;
            prog.strSmtp = strSmtp;
            prog.strUsuario = strUser;
            prog.ShowDialog();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            strA = "";
            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            strAsunto = txtAsunto.Text;
            strA = txtDestino.Text;
            strDetalle = txtDetalle.Text;
            strDe = txtOrigen.Text;
            this.Close();
        }

    }
    }
