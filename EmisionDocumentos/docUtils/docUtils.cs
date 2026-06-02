using System;
using System.Data;
using System.Data.SqlClient;
using ClassDoc;

namespace adcDocumentos
{
    public class docUtils
    {
         
        public string correoElectronico=string.Empty;
        public string claveSri = string.Empty ;

        public Boolean ExisteDocumentoGrabado(ref AdcDoc adcdoc,ref PrySysp13.OpcDoc opcdoc, string cadenaConexion,double idclavedoc)
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
        static public Boolean ExisteDocumentoUnico(string docTip, string docSuc, double docNum, string cadenaConexion)
        {

            Boolean resp = false;
            string ssql = " select idclavedoc from adcdoc where Doc_sucursal = '" + docSuc + "' and Opc_documento = '" + docTip  + "' and Doc_numero =" + docNum ;
            using (SqlDataAdapter da = new SqlDataAdapter(ssql, cadenaConexion))
            {
                DataTable dtt = new DataTable();
                da.Fill(dtt);
                if (dtt.Rows.Count != 0) resp = true;
                dtt.Dispose();
            }
            return resp;
        }
        static internal Int32 MaximoDeLineasPorDocumento(string FormatoImpresion)
        {
            Int32 numlin = 0;
            using (SqlConnection conn = new SqlConnection(varbleComun.VarCom.strConxAdcom))
            {
                string[] cadena;
                conn.Open();
                SqlCommand comm = new SqlCommand("select * from sysforms where l0 ='" + FormatoImpresion.Trim() + "' order by S1",conn);
                SqlDataReader dr = comm.ExecuteReader();
                while (dr.Read())
                {
                    cadena = dr["l1"].ToString().Split(Convert.ToChar(";"));
                    if (cadena.Length >12){ numlin += Convert.ToInt32(cadena[12]);}
                } 
            }
            if (numlin == 0) numlin = 9999;    
            return numlin;
        }
        static public DateTime DaxNow()
        {
            DateTime dn = DateTime.Now;
            using (SqlConnection conn = new SqlConnection(varbleComun.VarCom.strConxSyscod))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand("select GETDATE ()",conn);
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.Read())
                {
                    dn = Convert.ToDateTime(dr[0]);
                }
                dr.Close();                
            }
            return dn;

        }

    }
}
