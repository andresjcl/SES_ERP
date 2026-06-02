using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolicitarAutorizacionSRI
{
    public static class classDatEmp
    {
        public static string nroContribuyenteEspecial = "";
        public static string obligadoContabilidad = "SI";
        public static string esRise = "NO";
        public static string esRIMPE = "NO";
        public static string NroAgenteRetencion = "";
        public static void cargarDatosDeNuestraEmpresa(string codEmpresa, string strConxAdcom)
        {
            string cmdText = "select case when isnull(esRise,0) = 1 then 'SI' else 'NO' END AS esRise" + ",isnull(NroCtrbuyteEspecial,'') as NroCtrbuyteEspecial" + ", case when isnull(RegimenMicroempresas,0) = 1 then 'SI' else 'NO' END AS RegimenMicroempresas" + ",case when isnull(ObligLlevarConta,0) = 1 then 'SI' else 'NO' END AS ObligLlevarConta " + ", isnull(identificacion.NroAcdoAgntRetencion, '') as NroAcdoAgntRetencion" + " from identificacion" + " where CedulaIdentidadRuc = '" + codEmpresa + "' or codigo = '" + codEmpresa + "' ";
            SqlConnection connection = new SqlConnection(strConxAdcom);
            connection.Open();
            SqlDataReader sqlDataReader = new SqlCommand(cmdText, connection).ExecuteReader();
            if (sqlDataReader.Read())
            {
                classDatEmp.esRise = sqlDataReader["esRise"].ToString();
                classDatEmp.nroContribuyenteEspecial = sqlDataReader["NroCtrbuyteEspecial"].ToString();
                classDatEmp.obligadoContabilidad = sqlDataReader["ObligLlevarConta"].ToString();
                classDatEmp.esRIMPE = sqlDataReader["RegimenMicroempresas"].ToString();
                classDatEmp.NroAgenteRetencion = sqlDataReader["NroAcdoAgntRetencion"].ToString();
            }
            sqlDataReader.Close();
            sqlDataReader.Dispose();
        }
    }
}
