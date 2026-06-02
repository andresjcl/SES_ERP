using System;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace anexoTransaccional
{
    public partial class frmDetDocVta : Form
    {
        string ssql = "";
        public frmDetDocVta(string conx,string ciruc,DateTime fechaini, DateTime fechafin,string tipoSri)
        {
            InitializeComponent();

            ssql = "SELECT adi_tipoDocSri as DocSri, Doc_sucursal AS SUC, Opc_documento AS DOC,doc_NroIdDoc as IdNum, Doc_numero as Número, Doc_fecha as Fecha, Doc_NombreImp as Nombre, Doc_detalle as Detalle, Doc_totciva as BaseConIva, Doc_totsiva BaseSinIva";
            ssql += " FROM AdcDoc";
            ssql += " WHERE (Doc_Ventas <> 0) AND (Doc_Banco = 0) AND (Doc_CiRuc = '" + ciruc + "') AND (Doc_fecha <= '" + fechafin.ToShortDateString()  + "') AND (Doc_fecha >= '"+fechaini.ToShortDateString()+"') AND (Doc_TipoDoc <> 'rtc')";
			ssql += " and isnull(adi_tipodocsri,'') = '"+tipoSri+"' ";
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(ssql, conx);
            da.Fill(dt);
            malla.DataSource = dt;
            da.Dispose();
            dt.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
