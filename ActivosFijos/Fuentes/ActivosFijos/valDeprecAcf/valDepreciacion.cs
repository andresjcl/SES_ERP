using System;
using System.Data.SqlClient ;
using System.Collections.Generic;
using System.Text;

namespace DepreActivos
{
    static public class valDepreciacion
    {
        static public Boolean depAnt= false;
        static public Boolean depAct= false;
        static public Boolean depMayor= false;
        static public void validar(Boolean eliminar,string Codigo, Int32 añoIniDepr, Int32 mesIniDepr, Int32 añoFinDepr,Int32 mesFinDepr,string strconx)
        {
           VerificarDepreciaciones( mesIniDepr, añoIniDepr, mesFinDepr, añoFinDepr, Codigo,strconx);
        }

        private static void VerificarDepreciaciones( int mes1 , int año1 , int mes2 , int año2 , string codigo, string strConxAdcom)
        {                
            string comandoAct = "";
            string comandoMay = "";
            string comandoAnt = "";
            Int32 fecI = 0;
            Int32 fecF = 0;
            Int32 fec1 = 0;
            fecI = año1 * 100 + mes1;
            fecF =año2 * 100 + mes2;
            if (codigo != "") 
            {
                comandoMay = "Select año,mes from AdcAcfDep where año*100+Mes >" + fecF + " and Codigo='" + codigo + "' and acumulados = 0";
                comandoAct = "Select año,mes from AdcAcfDep where año*100+Mes >=" + fecI  + " and año*100+Mes <=" + fecF + " and Codigo='" + codigo + "' and acumulados = 0";
                comandoAnt = "Select año,mes from AdcAcfDep where año*100+Mes <" + fecI + " and Codigo='" + codigo + "'  and acumulados = 0";
            }
            else
            {
                comandoMay = "Select año,mes from AdcAcfDep where año*100+Mes >" + fecF + " and acumulados = 0 group by año,mes";
                comandoAct = "Select año,mes from AdcAcfDep where año*100+Mes =" + fecF + " and año*100+Mes <=" + fecF + " and acumulados = 0 group by año,mes";
                comandoAnt = "Select año,mes from AdcAcfDep where año*100+Mes <" + fecI + "  and acumulados = 0 group by año,mes";
            }

            SqlConnection conn = new SqlConnection(strConxAdcom);
            SqlDataReader  datos;
            conn.Open() ;
            SqlCommand comm = new SqlCommand(comandoMay,conn);
            datos = comm.ExecuteReader();
            depMayor = datos.HasRows;        
        
            comm = new SqlCommand(comandoAct,conn);
            datos.Close();
            datos = comm.ExecuteReader();
            depAct = datos.HasRows;        

            comm = new SqlCommand(comandoAnt,conn);
            datos.Close();
            datos = comm.ExecuteReader();
            depAnt = datos.HasRows;        

            conn.Close();
            conn.Dispose();
            datos.Close();
            datos.Dispose();
            comm.Dispose();
        }

        public static void eliminarDepreciaciones(int mes1, int año1, int mes2, int año2, string codigo, string strConxAdcom)
        {
            string comando = "";
            Int32 fecI = 0;
            Int32 fecF = 0;
            fecI = año1 * 100 + mes1;
            fecF = año2 * 100 + mes2;
            if (codigo != "")
            {
                comando = "Delete AdcAcfDep where año*100+Mes >" + fecF + " and Codigo='" + codigo + "'  and acumulados = 0";
            }
            else
            {
                comando = "Delete AdcAcfDep where año*100+Mes >" + fecF + " and Codigo='" + codigo + "'  and acumulados = 0";
            }

            SqlConnection conn = new SqlConnection(strConxAdcom);
            Int32 datos=0;
            conn.Open();
            SqlCommand comm = new SqlCommand(comando, conn);
            datos = comm.ExecuteNonQuery();
        }
    }
}
