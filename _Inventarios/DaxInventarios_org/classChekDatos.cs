using System;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace adcArticulo
{
    static internal class classChekDatos
    {
        static internal bool chekCodBarras(string codigoArt,string codBarr,string strConxAdcom)
        {
            using (SqlConnection conn = new SqlConnection(strConxAdcom))
            {
                bool resp = false;
                conn.Open();
                SqlCommand comm = new SqlCommand("select tik_numero,tik_artcodi from adctik where tik_numero = '" + codBarr + "' or tik_artcodi = '" + codBarr + "'",conn);
                SqlDataReader dr = comm.ExecuteReader();
                if(dr.HasRows)
                {
                    dr.Read();
                    classMenSistem.mensajesErrorDocumento.articuloCodBarrasExiste(codBarr, dr["tik_artcodi"].ToString(), dr["tik_numero"].ToString());
                    resp = true;
                }
                dr.Close();
                dr.Dispose();
                comm.Dispose();
                return resp;
            }
        }
    }
}
