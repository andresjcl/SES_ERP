using System;
using System.Data;
using System.Data.SqlClient;

namespace DaxDocElectronicos
{
    public class Contingencia
    {
        public string ultimaClaveContingente(string ambiente,string strConxAdcom, ref string claveContingente)
        {
            string clave = "";
            DataTable sr = new DataTable();
            string ssql = "select min(clavecontigencia) as proximaClave from adcclavcontg  where isnull(utidocnumero,'') = '' and substring(clavecontigencia,14,1)='" + ambiente + "'";
            SqlDataAdapter da = new SqlDataAdapter(ssql, strConxAdcom);
            clave = "9999999999999999999999999999999999999";
            da.Fill(sr);
            try { if (sr.Rows.Count > 0) { clave = sr.Rows[0]["proximaClave"].ToString(); } }
            catch { }
            if (clave.Length > 37) clave = clave.Substring(0, 37);
            sr.Dispose();
            da.Dispose();
            claveContingente = clave;
            return clave;
        }
        public void registrarClave(string clave, string SUC, string DOC, string Num,string strConxadcom)
        {
            string SsqL = "UPDATE adcclavcontg SET utidocsucursal = '" + SUC + "', utidoctipo = '" + DOC + "', UTIDOCNUMERO = '" + Num + "'";
            SsqL += " where substring(claveContigencia,1," + clave.Length.ToString() + ") = '" + clave +"' ";
            using (SqlDataAdapter da = new SqlDataAdapter(SsqL, strConxadcom))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                dt.Dispose();
                da.Dispose();
            }
        }


    }
}
