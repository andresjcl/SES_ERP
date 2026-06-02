using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SysEmpDatt;

namespace adcArticulosPrecios
{
    public class Datos
    {
        static public string probarConsultaSql(string consulta, string articulo)
        {
            string resp = "";
            string ssql = "select top 1 ISNULL( " + consulta + ",0) as valor FROM ";
            ssql += "( select *,19.37 as precioCompraDoc from DaxInvDatCalPrecios where art_codigo = '" + articulo + "' ) as PR";
            try
            {
                using (SqlDataAdapter da =  new SqlDataAdapter (ssql,datosEmpresa.strConxAdcom))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if(dt.Rows.Count  > 0)
                    {
                        resp = dt.Rows[0][0].ToString();
                    }
                    else
                    {
                        resp = " No se ha producido ningún valor revise la consulta ";
                    }
                }
            }
            catch(Exception EX)
            {
                resp = " ERROR : " + EX.Message ;
            }            
            return resp;
        }
        static public string CalcularPrecioConsultaSql(string consulta, string articulo)
        {
            string resp = "";
            string ssql = "select top 1 ISNULL( " + consulta + ",0) as valor FROM ";
            ssql += "( select *,19.37 as precioCompraDoc from DaxInvDatCalPrecios where art_codigo = '" + articulo + "' ) as PR";
            try
            {
                using (SqlDataAdapter da = new SqlDataAdapter(ssql, datosEmpresa.strConxAdcom))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        resp = dt.Rows[0][0].ToString();
                    }
                    else
                    {
                        resp = " No se ha producido ningún valor revise la consulta ";
                    }
                }
            }
            catch (Exception EX)
            {
                resp = " ERROR : " + EX.Message;
            }
            return resp;
        }

    }
}
