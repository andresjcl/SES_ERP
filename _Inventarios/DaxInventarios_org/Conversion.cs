using System;
using System.Data.SqlClient;

namespace DaxInvent
{
    public class Conversion
    {
        public string Cnv_DeMedida = "";
        public string Cnv_Amedida = "";
        public double Cnv_Multiplo = 0.0d;
        private string ssql = "";
        private SqlConnection conectaSys = new SqlConnection();

        public void Guardar(string strSysc)
        {
            ssql = "insert into conversion(";
            ssql += "Cnv_DeMedida ,";
            ssql += "Cnv_Amedida ,";
            ssql += "Cnv_Multiplo )";
            ssql += " values ( ";
            ssql += "'" + Cnv_DeMedida + "',";
            ssql += "'" + Cnv_Amedida + "',";
            ssql += " " + Cnv_Multiplo + ")";
            EjecutarComandos(ssql, strSysc);
        }

        public void Actualizar(string cod, string strSysc)
        {
            ssql = "update conversion set ";
            ssql += "Cnv_Amedida ='" + Cnv_Amedida + "',";
            ssql += "Cnv_Multiplo ='" + Cnv_Multiplo + "'";
            ssql += " where Cnv_DeMedida ='" + cod + "'";
            EjecutarComandos(ssql, strSysc);
        }

        public void Eliminar(string cod, string strSysc)
        {
            ssql = "delete from conversion";
            ssql += " where Cnv_DeMedida ='" + cod + "'";
            EjecutarComandos(ssql, strSysc);
        }

        private void EjecutarComandos(string sql, string strSys)
        {
            conectaSys.ConnectionString = strSys;
            var cmd = new SqlCommand(sql, conectaSys);
            conectaSys.Open();
            cmd.ExecuteNonQuery();
            conectaSys.Close();
        }
    }
}