using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace docUtility
{
    public class docUtils
    {

        public string correoElectronico=string.Empty;
        public string claveSri = string.Empty ;

        public void ImpDoc(double IdClaveDocC , string Sucursal ,string TipoDocumento , double NumeroDocumento, string QueSystema ="A", string FacturaProforma ="F", string AuxManual ="", string otraimp ="",string ImpCtb = "")
        {
            string pasar="";
            ImprDoct.ImprimirDoc prog = new ImprDoct.ImprimirDoc();
            if (claveSri.Length > 0 ) 
            {
                prog.CorreoElectronico = correoElectronico;
                prog.claveSri = claveSri;
            }
            pasar = QueSystema + "," + FacturaProforma + "," + AuxManual + "," + otraimp + "," + ImpCtb;
            prog.ImprimeDoc(ref IdClaveDocC, ref Sucursal,ref TipoDocumento, ref NumeroDocumento, ref pasar);
            prog=null;
        }

        public Boolean ExisteDocumentoGrabado(ref adcDocumentos.AdcDoc adcdoc,ref PrySysp13.OpcDoc opcdoc, string cadenaConexion,double idclavedoc)
        {
            Boolean resp = false;
            string ssql = " select idclavedoc from adcdoc where Doc_sucursal = '" + adcdoc.Doc_sucursal + "' and Opc_documento = '" + adcdoc.Opc_documento + "' and Doc_numero =" + adcdoc.Doc_numero;
            if (opcdoc.Opc_Propietario != 0) { ssql += " and doc_codper = '" + adcdoc.Doc_codper + "' "; }
            if (opcdoc.Opc_Bodega != 0) { ssql += " and doc_Bodega = '" + adcdoc.Doc_Bodega + "' "; }
            if (opcdoc.Opc_IdSri   != 0) { ssql += " and Doc_NroIdDoc = '" + adcdoc.Doc_NroIdDoc + "' "; }

            //SqlConnection cnn = new SqlConnection(cadenaConexion);
            DataTable dtt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(ssql, cadenaConexion);
            da.Fill(dtt);
            if (dtt.Rows.Count != 0)
            {
                if (idclavedoc == 0)
                {
                    resp = true;
                }
                else
                {
                    for (int i = 0; i < dtt.Rows.Count; i++)
                    {
                      if (Convert.ToDouble(dtt.Rows[0]["idclavedoc"]) != idclavedoc) resp = true;
                    }
                }
            }
            da.Dispose();
            dtt.Dispose();
            //cnn.Close();
            //cnn.Dispose();
            return resp;
        }
                
    }
}
