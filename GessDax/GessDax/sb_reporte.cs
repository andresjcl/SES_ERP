using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace GessDax
{
    static internal class sb_reporte
    {
       internal static Int32 idTipoDato=0;
       internal static string descripción = "";
       internal static string procedInicial = "";
       internal static string consultaFinal = "";
       internal static string baseDatos = "";
       internal static Boolean esRol = false;
        internal static void cargar(Int32 tipo)
        {
            string ssql = "Select * from sysdatgess where idTipoDato = " + tipo.ToString();
            using (SqlDataAdapter da = new SqlDataAdapter(ssql,DattCom.datosEmpresa.strConxAdcom))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    idTipoDato = Convert.ToInt32( row["idTipoDato"].ToString());
                    descripción = row["descripción"].ToString();
                    procedInicial = row["procedInicial"].ToString();
                    consultaFinal = row["consultaFinal"].ToString();
                    baseDatos = row["baseDatos"].ToString();
                    try
                    {
                        esRol = Convert.ToBoolean(row["esRol"]);
                    }
                    catch { esRol = false; }
                }
            }
        }

    }
}
