using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DattCom;
namespace DaxComercia
{
    public class classPagosDoc
    {
        public string DocSucursal = "";
        public string Doctipo = "";
        public double DocNumero = 0;
        public double idClaveDoc=0;
        public DateTime DocFecha; 
        public double DocValor = 0;
        public double totalContado = 0;
        public string strConx="";

        public List<pagoDoc> pagosDelDocumento = new List<pagoDoc>();
        
        public void add(pagoDoc pago)
        {
            pagosDelDocumento.Add(pago);
        }
        public void cargarPagosDocumento(string tabla)
        {
            if (idClaveDoc == 0) return;
            ClassDoc.AdcPag dbPagos = new ClassDoc.AdcPag(datosEmpresa.strConxAdcom);                         
            string sSql= "Select * from "+tabla+" where doc_sucursal = '" + DocSucursal + "' AND opc_documento='" + Doctipo + "' AND idclavedoc =" + idClaveDoc.ToString(); 
            DataTable dt = ClassDoc.AdcPag.Tabla(sSql);
            foreach (DataRow row in dt.Rows)
            {
                pagoDoc XPago = new pagoDoc();

                XPago.TipoPag = row["PAG_TIPOPAGO"].ToString();
                XPago.Valor = Convert.ToDouble("0" + row["Pag_Valor"].ToString());
                XPago.Descripcion = row["Pag_descripcion"].ToString();
                XPago.autoriza = row["pag_Autoriza"].ToString();
                XPago.DocInstitucion = row["pag_Docinstitucion"].ToString();
                XPago.NumCtaBanco = row["pag_NumCtaBanco"].ToString();
                XPago.DocPagoTipo = row["pag_docpagotipo"].ToString();
                XPago.DocPagoNumero = row["pag_DocPagoNumero"].ToString();
                XPago.PlanTarjeta = row["pag_plantarjeta"].ToString();
                XPago.NroCuotas = Convert.ToInt32("0" + row["pag_cuotas"].ToString());
                XPago.PagoACredito = Convert.ToInt32("0" + row["pag_formapago"].ToString());
                XPago.IdFormaDePago = row["Pag_Idpago"].ToString();
                XPago.FechaVence = row["Pag_Vence"].ToString();
                XPago.Beneficiario = row["pag_Beneficiario"].ToString();
                XPago.IdclavedocPago = Convert.ToDouble("0" + row["IdclaveDocPag"].ToString());
                XPago.DocPagoSucursal = row["pag_docpagosucursal"].ToString();

                if (XPago.TipoPag == "4" && tabla.ToUpper() =="ADCPAG")
                {
                    string cod = "SELECT * from ADCCUOTAS  Where cuo_docsuc='" + DocSucursal + "' AND Cuo_DocTipo='" + Doctipo + "' and idClaveDoc =" + idClaveDoc;
                    DataTable dtCuota = new DataTable ();
                    SqlDataAdapter da = new SqlDataAdapter(cod, strConx);
                    da.Fill(dtCuota);
                    if (dtCuota.Rows.Count < 1)
                    {
                        dtCuota = null;
                        da.Dispose();
                    }
                    else
                    {

                        foreach (DataRow rowC in dtCuota.Rows)
                        {
                            cuotaPag cuota = new cuotaPag();
                            cuota.FechaVence = Convert.ToDateTime(rowC["cuo_fechavence"].ToString());
                            cuota.Valor = Convert.ToDouble(rowC["cuo_valor"].ToString());
                            XPago.cuotasPago.Add(cuota);
                        }
                    }
                }
                pagosDelDocumento.Add(XPago);                
            }    
        }
        public void guardarPagosDocumento(string tabla)
        {
            if (idClaveDoc == 0 ) return;
            DataTable dt = new DataTable();
            string sSql = "Select * from " + tabla + " where doc_sucursal = '" + DocSucursal + "' AND opc_documento='" + Doctipo + "' AND idclavedoc =" + idClaveDoc.ToString();
            SqlDataAdapter dadt = new SqlDataAdapter(sSql, datosEmpresa.strConxAdcom);
            dadt.Fill(dt);
            
            sSql = "SELECT * from ADCCUOTAS  Where cuo_docsuc='" + DocSucursal + "' AND Cuo_DocTipo='" + Doctipo + "' and idClaveDoc =" + idClaveDoc;
            DataTable dtCuota = new DataTable();
            SqlDataAdapter dadtCuota = new SqlDataAdapter(sSql, datosEmpresa.strConxAdcom);
            dadtCuota.Fill(dtCuota);

            sSql = "SELECT * from ADCapl Where doc_sucursal ='" + DocSucursal + "' AND opc_documento ='" + Doctipo + "' and idClaveDoc =" + idClaveDoc;
            DataTable dtApl = new DataTable();
            SqlDataAdapter dadtApl = new SqlDataAdapter(sSql, datosEmpresa.strConxAdcom);
            dadtApl.Fill(dtApl);

            foreach (DataRow row in dt.Rows)
            {
                row.Delete();
            }
            foreach (DataRow row in dtCuota.Rows)
            {
                row.Delete();
            }

            foreach (DataRow row in dtApl.Rows)
            {
                row.Delete();
            }

            int NumPag = 0;
            foreach (pagoDoc XPago in pagosDelDocumento)
            {
                DataRow row = dt.NewRow();
                NumPag++;
                row["Doc_Sucursal"] = DocSucursal ;
                row["Opc_Documento"] = Doctipo;
                row["Doc_Numero"] = DocNumero;
                row["IdClaveDoc"] = idClaveDoc;
                row["Pag_numero"] = NumPag;
                row["Doc_Fecha"] = DocFecha.Date ;

                row["Pag_Idpago"] = XPago.IdFormaDePago;
                row["PAG_TIPOPAGO"] = XPago.TipoPag;
                row["Pag_Valor"] = XPago.Valor;
                row["Pag_descripcion"] = XPago.Descripcion;
                row["pag_Autoriza"] = XPago.autoriza;
                row["pag_Docinstitucion"] = XPago.DocInstitucion;
                row["pag_NumCtaBanco"] = XPago.NumCtaBanco;
                row["pag_docpagotipo"] = XPago.DocPagoTipo;
                row["pag_DocPagoNumero"] = XPago.DocPagoNumero;
                row["pag_plantarjeta"] = XPago.PlanTarjeta;
                row["pag_cuotas"] = XPago.NroCuotas;
                row["pag_formapago"] = XPago.PagoACredito;
                try
                {
                    row["Pag_Vence"] = XPago.FechaVence;
                }
                catch { row["Pag_Vence"] = DocFecha.Date; }
                row["pag_Beneficiario"] = XPago.Beneficiario;
                row["IdclaveDocPag"] = XPago.IdclavedocPago;
                row["pag_docpagosucursal"] = XPago.DocPagoSucursal;
                dt.Rows.Add(row);
                if (tabla.ToUpper() == "ADCPAG")
                {
                    if (XPago.cuotasPago.Count > 0)
                    {
                        foreach (cuotaPag cuota in XPago.cuotasPago)
                        {

                            DataRow rowC = dtCuota.NewRow();
                            rowC["cuo_fechavence"] = cuota.FechaVence;
                            rowC["cuo_valor"] = cuota.Valor;
                            dtCuota.Rows.Add(rowC);
                        }
                    }

                    if (XPago.TipoPag == "2")
                    {
                        DataRow rowApl = dtApl.NewRow();
                        rowApl["Doc_Sucursal"] = DocSucursal;
                        rowApl["Opc_Documento"] = Doctipo;
                        rowApl["Doc_Numero"] = DocNumero;
                        rowApl["IdClaveDoc"] = idClaveDoc;
                        rowApl["apl_sucapli"] = XPago.DocPagoSucursal;
                        rowApl["apl_docapli"] = XPago.DocPagoTipo;
                        rowApl["apl_numapli"] = XPago.DocPagoNumero;
                        rowApl["idclaveDocApl"] = XPago.IdclavedocPago;
                        rowApl["apl_docFecha"] = DocFecha.Date;
                        rowApl["apl_Fecha"] = DocFecha.Date ;
                        rowApl["apl_valorapl"] = XPago.Valor;
                        rowApl["apl_codbenef"] = XPago.Beneficiario;
                        rowApl["apl_SNcontado"] = false;
                        rowApl["ESPAGO"] = "S";
                        rowApl["numLinApl"] = XPago.DocPagoNumero;
                        rowApl["codConcepto"] = "";
                        dtApl.Rows.Add(rowApl);
                    }
                }
            }
            SqlCommandBuilder cb = new SqlCommandBuilder(dadt);
            SqlCommandBuilder cbCu = new SqlCommandBuilder(dadtCuota);
            SqlCommandBuilder cbApl = new SqlCommandBuilder(dadtApl);

            dadt.Update(dt);
            dt.AcceptChanges();
            dadtCuota.Update(dtCuota);
            dtCuota.AcceptChanges();
            dadtApl.Update(dtApl);
            dtApl.AcceptChanges();

            dt.Dispose();
            dtCuota.Dispose();
            dtApl.Dispose();
            dadtCuota.Dispose();
            dadt.Dispose();
            dadtApl.Dispose();
            cb.Dispose();
            cbCu.Dispose();
            cbApl.Dispose();
        }

    }
}
