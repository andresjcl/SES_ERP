using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolicitarAutorizacionSRI
{
    public class daxDatos
    {
        public static DataTable leerDatos(string ssql, string strConxadcom)
        {
            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(ssql, strConxadcom))
            {
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                return dataTable;
            }
        }

        public static DataTable leerReembolsos(
          string suc_comprobante,
          string tipo_comprobante,
          double idclaveDoc,
          string strConxadcom)
        {
            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("daxCrgReem " + idclaveDoc.ToString() + ",'" + suc_comprobante + "','" + tipo_comprobante + "'", strConxadcom))
            {
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                return dataTable;
            }
        }
    }
}
