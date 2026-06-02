using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DaxInvent
{
    public partial class frmDatosComerciales : Form
    {
        public frmDatosComerciales(string codArt, string strx,string suc,string cliente,string fecha,string tipDoc, string numDoc, string bodega)
        {
            InitializeComponent();
            registrarDatos(codArt, strx,suc,cliente,fecha,tipDoc,numDoc,bodega);
        }
        private void registrarDatos(string Codigo,string strConxAdcom,string suc,string codCliente,string aFecha, string tipoDocumento, string numeroDoc,string bodega)
        {
            string formato = "#,#0.0";
            DateTime laFecha = DateTime.Now;
            try { laFecha = Convert.ToDateTime(aFecha); }catch { };
            string ssql = "select art_codigo,art_nombre, isnull(Art_Precvta1,0) Art_Precvta1 , isnull(Art_Precvta2,0) Art_Precvta2, isnull(Art_Precvta3,0) Art_Precvta3, isnull(Art_Precvta4,0) Art_Precvta4, isnull(Art_Precvta5,0) Art_Precvta5,isnull(Art_descuen,0) Art_descuen,Art_fecinides,Art_fecfindes, isnull(art_limDescuento,0) art_limDescuento from adcart where art_codigo = '" + Codigo + "'";
            SqlDataAdapter da = new SqlDataAdapter(ssql, strConxAdcom);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                DataRow row=dt.Rows[0];
                txtPrecio1.Text = Convert.ToDouble(row["Art_Precvta1"]).ToString(formato);
                txtPrecio2.Text = Convert.ToDouble(row["Art_Precvta2"]).ToString(formato);
                txtPrecio3.Text = Convert.ToDouble(row["Art_Precvta3"]).ToString(formato);
                txtPrecio4.Text = Convert.ToDouble(row["Art_Precvta4"]).ToString(formato);
                txtPrecio5.Text = Convert.ToDouble(row["Art_Precvta5"]).ToString(formato);
                txtPorcentajeDescuento.Text = Convert.ToDouble(row["Art_descuen"]).ToString(formato) + "%" ;
                txtLimiteDescuento.Text = Convert.ToDouble(row["art_limDescuento"]).ToString(formato) + "%";
                this.Text = "DATOS COMERCIALES DEL ARTICULO: " + Codigo +" - " + row["Art_nombre"].ToString();
                try
                {
                    txtDesde.Text = Convert.ToDateTime(row["Art_fecinides"]).ToShortDateString();
                }
                catch { }
                try
                {
                    txtHasta.Text = Convert.ToDateTime(row["Art_fecfindes"]).ToShortDateString ();
                }

                catch { }
            }
            ssql = "Adc_SpUltPrv '" + suc + "','','" + Codigo + "','" + laFecha.ToShortDateString() + "'";
            da = new SqlDataAdapter(ssql, strConxAdcom);
            dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                txtVentaFecha.Text = Convert.ToDateTime(row["FechaVenta"]).ToShortDateString();
                txtVentaCantidad.Text = Convert.ToDouble(row["cantidad"]).ToString(formato);
                txtVentaPrecioUnitario.Text = Convert.ToDouble(row["PrecioUnitario"]).ToString(formato);
                txtVentaCliente.Text = row["NomCliente"].ToString();
            }            
            ssql = "Adc_SpUltPrec '" + Codigo + "','" + laFecha + "'";
            da = new SqlDataAdapter(ssql, strConxAdcom);
            dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                txtCompraFecha.Text = Convert.ToDateTime(row["FechaCompra"]).ToShortDateString();
                txtCompraCantidad.Text = Convert.ToDouble(row["cantidad"]).ToString(formato);
                txtCompraValorUnitario.Text = Convert.ToDouble(row["PrecioUnitario"]).ToString(formato);
                txtCompraProveedor.Text = row["Proveedor"].ToString();
            }

            //MessageBox.Show(Codigo + " " + laFecha.ToString());
            ssql = "DaxCnsArt '" + laFecha.ToString() + "','" + Codigo + "'";//,'" + suc + "'"; //"','" + tipoDocumento + "','" + numeroDoc + "'";

            da = new SqlDataAdapter(ssql, strConxAdcom);
            dt = new DataTable();
            da.Fill(dt);
            mallaSaldos.DataSource = dt;
            //if (dt.Rows.Count > 0)
            //{
            //    DataRow row = dt.Rows[0];
            //    txtPendientes.Text  = Convert.ToDouble(row["Pendiente"]).ToString(formato);
            //}

            //ssql = "DaxSalArt '" + aFecha + "','" + bodega + "','" + Codigo + "'" ;
            //da = new SqlDataAdapter(ssql, ClassArt.strConxAdcom);
            //dt = new DataTable();
            //da.Fill(dt);
            //if (dt.Rows.Count > 0)
            //{
            //    DataRow row = dt.Rows[0];
            //    txtExistencia.Text = Convert.ToDouble(row["SaldoCantidad"]).ToString(formato);
            //} 	
                
            dt.Dispose();
            da.Dispose();
        }
        private void frmDatosComerciales_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) this.Close();
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label22_Click(object sender, EventArgs e)
        {

        }
    }
}
