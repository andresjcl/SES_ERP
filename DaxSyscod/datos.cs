using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DattCom;
namespace Syscod
{
    class datos
    {
        static internal void ComandoSqlSys(string Ssql)
        {
            using (SqlConnection conectar = new SqlConnection(datosEmpresa.strConxSyscod))
            {
                SqlCommand cmd = new SqlCommand(Ssql, conectar);
                conectar.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }
}
