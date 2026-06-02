using System;
using System.Data.SqlClient;
using DattCom;
namespace DaxConceptos
{
    public class classConceptos
    {
        public string iniciaBuscador(string strconx, string codigo, string Tipo = "", Boolean Hotel = false, Boolean ctacont = false)
        {
            if (Tipo == "CC") Tipo = "C";
            BuscServ frm = new BuscServ(codigo,"S",Tipo,"","",false,false,false);
            string var = frm.IniServicio();
            return var;
        }
        public void iniciaMantenimientoGastos(string strconx, string strconsys)
        {
            frmMntServicios frmGas = new frmMntServicios(false);
            frmGas.ShowDialog();
        }
        internal static bool conceptoUtilizado(string codServ)
        {
            bool resp = false;
            using (SqlConnection conn = new SqlConnection(datosEmpresa.strConxAdcom))
            {
                conn.Open();
                string ssql = "select top 1 doc_numero from adctra where tra_quetipo = 'S' and tra_codigo ='"+codServ+"'";
                ssql += " union all ";
                ssql += "select top 1 doc_numero from adcapl where CodConcepto ='"+codServ+"'";
                SqlCommand comm = new SqlCommand(ssql, conn);
                SqlDataReader dr = comm.ExecuteReader();
                resp = dr.HasRows;
                dr.Close();
                comm.Dispose();
            }
                return resp;
        }
    }
}
