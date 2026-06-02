using System;
using DattCom;
using System.Data;
using System.Data.SqlClient;
using ClassDoc;
using System.Windows.Forms;

namespace ClassCtaCartera
{
    public class ctasCorrientes
    {
        public static void GuardarAplicacionSimple(idDocumento docOrg, idDocumento docApl, string CodPer, double ValoApli, bool SNContado, string ESPAGO = "", int numlin = 0)
        {
            string codsql;
            DataTable Rs1doc = new DataTable();
            Random Rnd = new Random();
            if (numlin == 0) numlin = System.Convert.ToInt32(Rnd.NextDouble()*1+ 1);
            SqlConnection conectarAdcomDx = new SqlConnection(datosEmpresa.strConxAdcom);

            codsql = " FROM AdcApl WHERE doc_sucursal='" + docOrg.Sucursal + "' and opc_documento='" + docOrg.Tipo + "' and idclavedoc =" + docOrg.idClave + " and apl_docapli = '" + docApl.Tipo + "' and idclavedocapl = " + docApl.idClave + " and apl_sucapli = '" + docApl.Sucursal + "'";
            conectarAdcomDx.Open();
            SqlCommand cmd = new SqlCommand("delete" + codsql, conectarAdcomDx);
            cmd.ExecuteNonQuery();
            codsql = " FROM AdcApl WHERE apl_sucapli='" + docOrg.Sucursal + "' and apl_docapli='" + docOrg.Tipo + "' and idclavedocapl =" + docOrg.idClave + " and opc_documento = '" + docApl.Tipo + "' and idclavedoc = " + docApl.idClave + " and doc_sucursal = '" + docApl.Sucursal + "'";
            cmd = new SqlCommand("delete" + codsql, conectarAdcomDx);
            cmd.ExecuteNonQuery();
            AdcApl aplData = new AdcApl(datosEmpresa.strConxAdcom);
            AdcApl.CadenaSelect = " select * FROM AdcApl WHERE doc_sucursal='" + docOrg.Sucursal + "' and opc_documento='" + docOrg.Tipo + "' and idclavedoc =" + docOrg.idClave;
            {
                aplData.Doc_sucursal = docOrg.Sucursal;
                aplData.Opc_documento = docOrg.Tipo;
                aplData.Doc_numero = System.Convert.ToDecimal(docOrg.numero);
                aplData.Apl_sucapli = docApl.Sucursal;
                aplData.Apl_docapli = docApl.Tipo;
                aplData.Apl_numapli = System.Convert.ToDecimal(docApl.numero);
                aplData.Apl_docfecha = docOrg.fecha;
                aplData.Apl_fecha = docApl.fecha;
                aplData.Apl_valorapl = System.Convert.ToDecimal(ValoApli);
                aplData.Apl_codbenef = CodPer;
                aplData.Apl_DocGar = "";
                aplData.Apl_NumGar = 0;
                if (SNContado == true)
                    aplData.Apl_SNContado = true;
                else
                    aplData.Apl_SNContado = false;
                aplData.IdClaveDoc = System.Convert.ToDecimal(docOrg.idClave);
                aplData.IdClaveDocApl = System.Convert.ToDecimal(docApl.idClave);
                aplData.IdClaveDocGar = 0;
                aplData.CodConcepto = "";
                aplData.DescripcionConcepto = "";
                aplData.tra_Ventas = 0;
                aplData.tra_Compras = 0;
                aplData.tra_Banco = 0;
                aplData.tra_CtasCobrar = false;
                aplData.tra_CtasPagar = 0;
                aplData.tra_esanticipo = false;
                aplData.tra_costo = "";
                aplData.tra_centroproduccion = "";
                aplData.tra_centrodistribucion = "";
                aplData.tra_empleado = "";
                aplData.Tra_Proyecto = "";
                aplData.tra_directorio = "";
                aplData.Pag_DocPagoSucursal = "";
                aplData.espago = ESPAGO;
                aplData.tra_escontable = false;
                aplData.apl_valorcierre = 0;
                aplData.Idclaveapl = 0;
                aplData.Idclaveaplapl = 0;
                aplData.CodConcepto = "";
                aplData.numLinApl = numlin;
                aplData.Crear();
            }
            aplData = null;
        }
        public static string codigoSri(string idFormasDePago, ref string GrupoDelPago, ref string pagoCreditoContado, ref string NomPlan)
        {
            string ssql = "select isnull(SRI_formaDePago,'0') as SRI_formaDePago,formaDepago,tipoformapago,Descripcion from FormasDePago where idFormasDePago = '" + idFormasDePago + "'";
            DataTable dato = SqlDatos.leerTablaAdcom (ssql);
            if (dato.Rows.Count == 0)
            {
                ssql = "";
                pagoCreditoContado = "";
                NomPlan = "";
                GrupoDelPago = "";
            }
            else
            {
                ssql = dato.Rows[0]["sri_formaDePago"].ToString();
                GrupoDelPago = dato.Rows[0]["TipoformaPago"].ToString();
                pagoCreditoContado = dato.Rows[0]["formaDePago"].ToString();
                NomPlan = dato.Rows[0]["Descripcion"].ToString();
            }
            dato.Dispose();
            return ssql;
        }
        public static void CargarMallaSaldos2(DataGridView malla, Boolean EsCliente, string codPer, ClassDoc.idDocumento IDdOC, string NroLote, Boolean conCliente = false, Boolean conProveedor = false, Boolean conAnticipo = false)
        {
            DateTime fecval = new DateTime(1900, 1, 1);

            if (IDdOC.fecha == fecval) IDdOC.fecha = DateTime.Now;
            string StrSigno = "C";
            if (conCliente && conProveedor) { StrSigno = ""; }
            else if (conProveedor) { StrSigno = "P"; }
            string FechaSaldo = datosEmpresa.UltimoCierreAnual.AddDays(1).ToShortDateString();
            string FechaHasta = IDdOC.fecha.ToShortDateString();
            int ConAnticipo = 0;
            if (conAnticipo) ConAnticipo = 1;

            SqlConnection Conn = new SqlConnection(datosEmpresa.strConxAdcom);
            SqlCommand comm = new SqlCommand("ADC_PENDI", Conn);
            comm.CommandType = CommandType.StoredProcedure;
            using (SqlDataAdapter da = new SqlDataAdapter(comm))
            {
                comm.Parameters.AddWithValue("@Cliente", codPer);
                comm.Parameters.AddWithValue("@desde", FechaSaldo);
                comm.Parameters.AddWithValue("@hasta", FechaHasta);
                comm.Parameters.AddWithValue("@anticipos", ConAnticipo);
                comm.Parameters.AddWithValue("@garantias", 0);
                comm.Parameters.AddWithValue("@movimiento", 0);
                comm.Parameters.AddWithValue("@ventas", StrSigno);
                comm.Parameters.AddWithValue("@lotedoc", NroLote);
                comm.Parameters.AddWithValue("@cheques", 0);
                comm.Parameters.AddWithValue("@SUC", IDdOC.Sucursal);
                comm.Parameters.AddWithValue("@DOC", IDdOC.Tipo);
                comm.Parameters.AddWithValue("@IDCLAVEDOC", IDdOC.idClave);
                comm.Parameters.AddWithValue("@ConEmpleado", 1);
                comm.Parameters.AddWithValue("@sinTipo", "");
                DataTable dt = new DataTable();
                da.Fill(dt);
                malla.DataSource = dt;
            }
            if (malla.RowCount == 0)
                return;
            {
                foreach (DataGridViewColumn coll in malla.Columns)
                {
                    coll.ReadOnly = true;
                    coll.Visible = false;
                }

                malla.Columns["Abono"].ReadOnly = false;

                malla.Columns["Nombre"].Visible = true;
                malla.Columns["SUC"].Visible = true;
                malla.Columns["TIP"].Visible = true;
                malla.Columns["Numero"].Visible = true;
                malla.Columns["Fecha"].Visible = true;
                malla.Columns["Valor"].Visible = true;
                malla.Columns["SaldoAct"].Visible = true;
                malla.Columns["Abono"].Visible = true;

                malla.Columns["Nombre"].Width = 250;
                malla.Columns["SUC"].Width = 40;
                malla.Columns["TIP"].Width = 40;
                malla.Columns["Numero"].Width = 80;
                malla.Columns["Fecha"].Width = 80;
                malla.Columns["Valor"].Width = 95;
                malla.Columns["SaldoAct"].Width = 95;
                malla.Columns["Abono"].Width = 95;

                malla.Columns["Valor"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                malla.Columns["SaldoAct"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                malla.Columns["Abono"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                malla.Columns["Fecha"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                malla.Columns["Nombre"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                malla.Columns["Numero"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                malla.Columns["Valor"].DefaultCellStyle.Format = @"#0.00;;\";
                malla.Columns["SaldoAct"].DefaultCellStyle.Format = @"#0.00;;\";
                malla.Columns["Abono"].DefaultCellStyle.Format = @"#0.00;;\";

                if (IDdOC.Sucursal != "" & IDdOC.Tipo != "" & IDdOC.idClave > 0)
                {
                    string ssql = "select apl_sucapli,apl_docapli,idClaveDocApl,Apl_valorapl from adcdocabonos2 where ";
                    ssql += " doc_sucursal = '" + IDdOC.Sucursal + "' and opc_documento = '" + IDdOC.Tipo + "' and idclavedoc = " + IDdOC.idClave;
                    DataTable RA = SqlDatos.leerTablaAdcom(ssql);
                    if (RA.Rows.Count > 0)
                    {
                        foreach (DataRow Drow in RA.Rows)
                        {
                            foreach (DataGridViewRow Mrow in malla.Rows)
                            {
                                if (Mrow.Cells["SUC"].Value.ToString() == Drow["apl_sucapli"].ToString()
                                    && Mrow.Cells["TIP"].Value.ToString() == Drow["apl_docapli"].ToString()
                                    && Convert.ToDouble("0" + Mrow.Cells["idClaveDoc"].Value) == Convert.ToDouble("0" + Drow["idclavedocapl"]))
                                {
                                    try
                                    {
                                        Mrow.Cells["Abono"].Value = Convert.ToDouble(Drow["apl_valorapl"]);
                                    }catch { Mrow.Cells["Abono"].Value = 0; }
                                }
                            }
                        }
                    }
                    RA.Dispose();
                }
            }
            
        }

    }
}
