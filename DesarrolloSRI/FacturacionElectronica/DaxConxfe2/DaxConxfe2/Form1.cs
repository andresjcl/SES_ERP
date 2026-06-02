using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DaxConxfe2
{
    public partial class Form1 : Form
    {
        public Form1(string suc, string tip, string idclv, string num, string clas, string empRuc, string empDigitosPrecios, string empPatAppl,string strConxAdcom)
        {
            InitializeComponent();
            label1.Text = "SOLICITANDO AUTORIZACION DOCUMENTO :" + tip + " - " + num;
            Int16 tipo = 1;
            try
            {
                WebService.WebServicesSRI ws = new WebService.WebServicesSRI();
                if (ws.IsOnLine == false) { tipo = 2; }
            }
            catch { tipo = 2; }

            if (tipo == 2)
            {
                if (MessageBox.Show("Los servicios Web del SRI no están disponibles \n Desea emitir el comprobante con claves de contingencia ?", "Emisión comprobantes electrónicos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No) return;
            }

            string estado = "DOCUMENTO AUTORIZADO CORRECTAMENTE";
            Daxconxfe.Adcconxfe PROG = new Daxconxfe.Adcconxfe();
            string respuesta = PROG.pedirAutorizacionSri(suc, tip, Convert.ToDouble("0" + idclv), num, clas, empRuc, Convert.ToInt16(empDigitosPrecios), empPatAppl,tipo,false,strConxAdcom);
            if (respuesta.Substring(0, 3) == "ERR" && respuesta.Length > 0)
            {
                estado = "DOCUMENTO NO FUE AUTORIZADO";
            }
            label2.Text = estado + "\n" + respuesta;

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Escape) this.Close();               
        }
    }
}
