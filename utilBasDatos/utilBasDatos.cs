using System;
using System.Data;
using System.Data.SqlClient;

namespace utilBasDatos
{
    static public class utilBasDatos
    {
        static public DataTable leerTablas(string ssql, string strConeccion)
        {
            // devuelve una tabla con los datos leidos
            try
            {
                using (SqlDataAdapter da = new SqlDataAdapter(ssql, strConeccion))
                {
                    using (DataTable dt = new DataTable())
                    {
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
            catch
            {
                return new DataTable();
            }
        }
        static public void ejecutarComandoSql(string ssql,string strConeccion)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection (strConeccion))
                {
                    conn.Open();
                    using (SqlCommand comm = new SqlCommand (ssql,conn))
                    {
                        comm.ExecuteNonQuery();
                    }
                }
            }
            catch {}
        }
    }
}
