using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using DattCom;

namespace DaxInvent
{
    public class MultMedida
    {
        // retorna el valor del factor de conversion de una medida a otra
        public static Double MulMedida(string DesdeMed, string AMed)
        {
            if (DesdeMed == AMed || DesdeMed == "" || AMed == "") return 1;
            Double Multiplo = 0;
            using (SqlConnection conn = new SqlConnection(datosEmpresa.strConxAdcom))
            {
                conn.Open();
                string ssql = "Select isnull(Cnv_Multiplo,0) as Cnv_Multiplo from conversion where Cnv_DeMedida = '" + DesdeMed+"' and Cnv_Amedida = '"+AMed+"'";
                SqlCommand comm = new SqlCommand(ssql, conn);
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.Read())
                {
                    Multiplo = Convert.ToDouble ("0"+dr["Cnv_Multiplo"].ToString());
                }
                dr.Close();
                comm.Dispose();
            }
                return Multiplo;
        }

        // retorna el factor para cambiar la unidad de medida de un empaque a otro
        public static double CambiaEmpaque(string AMed,string CodigoArticulo)
        {
            Double Multiplo = 0;
            using (SqlConnection conn = new SqlConnection(datosEmpresa.strConxAdcom))
            {
                conn.Open();
                string ssql = "Select art_codigo,isnull(Art_unimed,'') as Art_unimed";
                ssql += ", isnull(CodEmpaque1, '') as CodEmpaque1, isnull(ValEmpaque1, 0) as ValEmpaque1";
                ssql += ", isnull(CodEmpaque2, '') as CodEmpaque2, isnull(ValEmpaque2, 0) as ValEmpaque2";
                ssql += ", isnull(CodEmpaque3, '') as CodEmpaque3, isnull(ValEmpaque3, 0) as ValEmpaque3";
                ssql += ", isnull(CodEmpaque4, '') as CodEmpaque4, isnull(ValEmpaque4, 0) as ValEmpaque4";
                ssql += ", isnull(CodEmpaque5, '') as CodEmpaque5, isnull(ValEmpaque5, 0) as ValEmpaque5";
                ssql += " from adcart where Art_codigo = '"+CodigoArticulo+"'";
                SqlCommand comm = new SqlCommand(ssql, conn);
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.Read())
                {
                    if (AMed == dr["CodEmpaque1"].ToString()) Multiplo = Convert.ToDouble(dr["ValEmpaque1"]);
                    else if (AMed == dr["CodEmpaque2"].ToString()) Multiplo = Convert.ToDouble(dr["ValEmpaque2"]);
                    else if (AMed == dr["CodEmpaque3"].ToString()) Multiplo = Convert.ToDouble(dr["ValEmpaque3"]);
                    else if (AMed == dr["CodEmpaque4"].ToString()) Multiplo = Convert.ToDouble(dr["ValEmpaque4"]);
                    else if (AMed == dr["CodEmpaque5"].ToString()) Multiplo = Convert.ToDouble(dr["ValEmpaque5"]);
                }
                dr.Close();
                comm.Dispose();
            }
            if (Multiplo==0)
            {
                using (SqlConnection conn = new SqlConnection(datosEmpresa.strConxSyscod))
                {
                    conn.Open();
                    string ssql = "Select isnull(caracteristica1,0) as valor from syscod where tiporeferencia = 'empaque' adn abreviacion = '"+AMed +"'";
                    SqlCommand comm = new SqlCommand(ssql, conn);
                    SqlDataReader dr = comm.ExecuteReader();
                    if (dr.Read())
                    {
                        Multiplo = Convert.ToDouble("0" + dr["valor"].ToString());
                    }
                    dr.Close();
                    comm.Dispose();
                }
            }
            return Multiplo;
        }
    }
}