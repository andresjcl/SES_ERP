using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace DaxDocElectronicos
{
    public class daxDatos
    {
        static public DataTable leerDatos(string ssql, string strConxadcom)
        {
            using (SqlDataAdapter adp = new SqlDataAdapter(ssql, strConxadcom))
            {
                DataTable ds = new DataTable();
                adp.Fill(ds);
                return ds;
            }
        }

        static public DataTable leerReembolsos(string suc_comprobante, string tipo_comprobante, double idclaveDoc, string strConxadcom)
        {
            string strProceso = "daxCrgReem " + idclaveDoc.ToString() + ",'" + suc_comprobante + "','" + tipo_comprobante + "'";
            using (SqlDataAdapter adp = new SqlDataAdapter( strProceso  , strConxadcom))
            {
                DataTable ds = new DataTable();
                adp.Fill(ds);
                return ds;
            }
        }
            
    }
}
