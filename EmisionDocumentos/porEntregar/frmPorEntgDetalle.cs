using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace porEntregar
{
    public partial class frmPorEntgDetalle : Form
    {
        public string Doctipo = "";
        public double DocNumero = 0;
        public string DocSuc = "";
        public string strConxAdcom;

        public frmPorEntgDetalle()
        {
            InitializeComponent();
        }

        private void frmPorEntgDetalle_Load(object sender, EventArgs e)
        {
            //ModuloActual = Me.Name

            this.Text = "Detalle de entregas documento :" + DocSuc + " - " + Doctipo + " - " + DocNumero;
            string ssql = "ADC_CNENTRG '','','','" + DocSuc + "','" + Doctipo + "'," + DocNumero.ToString();
            SqlDataAdapter da = new SqlDataAdapter(ssql, strConxAdcom);
            DataTable rs = new DataTable();
            da.Fill(rs);
            malla.DataSource = rs;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

 