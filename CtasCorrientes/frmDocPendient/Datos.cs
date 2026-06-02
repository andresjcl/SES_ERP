using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using ClassDoc;
using DattCom;
namespace DocPendientes
{
    public class Datos
    {
        static public void CargarDocumentos(ListDocAplican listDocAplicados, DataGridView Malla, Boolean esProveedor,string QueCliente, ClassDoc.idDocumento QueIdDocumento, string txtNroLote, Boolean chkCliente,Boolean chkProveedor, Boolean chkAnticipo)
        {
            {
                ClassCtaCartera.ctasCorrientes.CargarMallaSaldos2(Malla, !esProveedor, QueCliente, QueIdDocumento, txtNroLote, chkCliente, chkProveedor, chkAnticipo);
                if (Malla.Rows.Count > 1)
                {
                    if (listDocAplicados != null)
                    {
                        if (listDocAplicados.ListaDocAplican.Count > 0)
                        {
                            foreach (DocAplica Campos in listDocAplicados.ListaDocAplican)
                            {
                                double valor = Convert.ToDouble(Campos.ValorCruce);
                                if (valor != 0)
                                {
                                    foreach (DataGridViewRow mrow in Malla.Rows)
                                    {
                                        mrow.Cells["Abono"].Value = 0;
                                        if (Campos.Sucursal == mrow.Cells["SUC"].Value.ToString() & Campos.TipoDoc == mrow.Cells["TIP"].Value.ToString() & Campos.IdClaveDoc == Convert.ToDouble("0" + mrow.Cells["IdClaveDoc"].Value))
                                        {
                                            mrow.Cells["Abono"].Value = valor;
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        static public void RepartirValor(double porRepartir,DataGridView Malla)
        {
            double Poner;
            double actual;
            {
                foreach (DataGridViewRow mrow in Malla.Rows)
                {
                    if (mrow.Cells["SUC"].Value != null)
                    {
                        if (mrow.Cells["SUC"].Value.ToString() == DattCom.datosEmpresa.sucursal | DattCom.datosEmpresa.PermiteCruceDocSucursal)
                        {
                            actual = Math.Abs(System.Convert.ToDouble(mrow.Cells["SaldoAct"].Value));
                            if (actual >= porRepartir)
                            {
                                Poner = porRepartir;
                                porRepartir = 0;
                            }
                            else
                            {
                                Poner = actual;
                                porRepartir = porRepartir - Poner;
                            }
                            mrow.Cells["Abono"].Value = Poner;
                        }
                        if (porRepartir == 0)
                            break;
                    }
                }
            }
        }
        public static void GuardarAplicacionSimple(idDocumento docOrg, idDocumento docApl, string CodPer, double ValoApli, bool SNContado, string ESPAGO = "", int numlin = 0)
        {
            string codsql;
            DataTable Rs1doc = new DataTable();
            Random Rnd = new Random();
            if (numlin == 0) numlin = System.Convert.ToInt32(Rnd.NextDouble() * 1 + 1);
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
                aplData.Apl_fecha = docOrg.fecha;
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
        public static void GuardarAplicaciones(idDocumento docOrg, string CodPer, ListDocAplican listDocAplicados)
        {
            string codsql;
            DataTable Rs1doc = new DataTable();
            //Random Rnd = new Random();
            //if (numlin == 0) numlin = System.Convert.ToInt32(Rnd.NextDouble() * 1 + 1);
            Int16 numlin = 0;
            SqlConnection conectarAdcomDx = new SqlConnection(datosEmpresa.strConxAdcom);

            codsql = " FROM AdcApl WHERE doc_sucursal='" + docOrg.Sucursal + "' and opc_documento='" + docOrg.Tipo + "' and idclavedoc =" + docOrg.idClave ;
            conectarAdcomDx.Open();
            SqlCommand cmd = new SqlCommand("delete" + codsql, conectarAdcomDx);
            cmd.ExecuteNonQuery();
            codsql = " FROM AdcApl WHERE apl_sucapli='" + docOrg.Sucursal + "' and apl_docapli='" + docOrg.Tipo + "' and idclavedocapl =" + docOrg.idClave ;
            cmd = new SqlCommand("delete" + codsql, conectarAdcomDx);
            cmd.ExecuteNonQuery();
            
            if (listDocAplicados != null)
            {
                if (listDocAplicados.ListaDocAplican.Count > 0)
                {
                    AdcApl aplData = new AdcApl();
                    string ssql = " select * FROM AdcApl WHERE doc_sucursal='" + docOrg.Sucursal + "' and opc_documento='" + docOrg.Tipo + "' and idclavedoc =" + docOrg.idClave;
                    DataTable dt = new DataTable ();
                    SqlDataAdapter da = new SqlDataAdapter(ssql, datosEmpresa.strConxAdcom);
                    da.Fill(dt);

                    aplData.Doc_sucursal = docOrg.Sucursal;
                    aplData.Opc_documento = docOrg.Tipo;
                    aplData.Doc_numero = System.Convert.ToDecimal(docOrg.numero);
                    aplData.Apl_docfecha = docOrg.fecha;
                    aplData.Apl_codbenef = CodPer;
                    aplData.Apl_DocGar = "";
                    aplData.Apl_NumGar = 0;
                    aplData.Apl_SNContado = false;
                    aplData.IdClaveDoc = System.Convert.ToDecimal(docOrg.idClave);
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
                    aplData.espago = "";
                    aplData.tra_escontable = false;
                    aplData.apl_valorcierre = 0;
                    aplData.Idclaveapl = 0;
                    aplData.Idclaveaplapl = 0;
                    aplData.CodConcepto = "";

                    foreach (DocAplica Campos in listDocAplicados.ListaDocAplican)
                    {
                        double valor = Convert.ToDouble(Campos.ValorCruce);
                        if (valor != 0)
                        {
                            numlin++;
                            aplData.Apl_numapli = System.Convert.ToDecimal(Campos.Numero);
                            aplData.Apl_fecha = Convert.ToDateTime(Campos.fechaDocumento);
                            aplData.Apl_valorapl = System.Convert.ToDecimal(Campos.ValorCruce);
                            aplData.IdClaveDocApl = System.Convert.ToDecimal(Campos.IdClaveDoc);
                            aplData.Apl_sucapli = Campos.Sucursal;
                            aplData.Apl_docapli = Campos.TipoDoc;
                            aplData.numLinApl = numlin;
                            DataRow dtrow = dt.NewRow();
                            AdcApl.AdcApl2Row(aplData, dtrow);
                            dt.Rows.Add(dtrow);
                        }
                    }
                    SqlCommandBuilder cb = new SqlCommandBuilder(da);
                    da.Update(dt);
                }
            }            
        }
    }
}
