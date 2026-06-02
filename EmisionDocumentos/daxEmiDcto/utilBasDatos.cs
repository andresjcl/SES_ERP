using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace daxEmiFacPv
{
    class utilBasDatos
    {

        public DataTable leerTablas(string ssql, string strConeccion)
        {

            // devuelve una tabla con los datos leidos

            SqlDataAdapter da;
            DataTable dt = new DataTable();
            try
            {
                da = new SqlDataAdapter(ssql, strConeccion);
                da.Fill(dt);
            }
            catch
            {
                return null;
            }
            return dt;
        }
    }
}
