using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DaxBan
{
    public partial class FrmSaldos : Form
    {
        string procedure = "DAX_SALBCO";
        internal FrmSaldos()
        {
            InitializeComponent();
            cargarMalla();
        }
        private void cargarMalla()
        {
            string fechaEfectivizacion = "N";
            string consaldoCero = "N";
            if (chkSaldoCero.Checked) consaldoCero = "S";
            if (chkFechaEfectivizacion.Checked) fechaEfectivizacion = "S"; 
            DataTable dt = DattCom.SqlDatos.leerTablaAdcom(procedure + " '" + dtFechaSaldo.Text  + "','"+consaldoCero + "','" + fechaEfectivizacion+ "'");
            malla.DataSource = dt;
            malla.Columns["Saldo"].DefaultCellStyle.Format = "#0.00";
            malla.Columns["Saldo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (malla.RowCount > 1)
            {
                DataGridViewPrinterApplication1.frmMain imp = new DataGridViewPrinterApplication1.frmMain();
                imp.imprimir(malla, "Saldos de Bancos al " + dtFechaSaldo.Text , "", "");
            }
            else
            {
                MessageBox.Show("No existen datos para imprimir");
            }

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            cargarMalla();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }
    }
}
