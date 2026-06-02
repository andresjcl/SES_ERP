using System;
using System.Data;
using System.Data.SqlClient;

namespace DaxInvent
{
    public class medidasArticulos
    {
        public double MulMedida(string DeMed, string AMed, string strsys)
        {
            if ((DeMed ?? "") == (AMed ?? "") | string.IsNullOrEmpty(DeMed) | string.IsNullOrEmpty(AMed))
                return 1d;
            var Medida = new DataTable();
            var da = new SqlDataAdapter("select isnull(Cnv_Multiplo,1) as Cnv_Multiplo from conversion where Cnv_DeMedida = '" + DeMed + "' and Cnv_Amedida = '" + AMed + "'", strsys);
            using (Medida)
            using (da)
            {
                da.Fill(Medida);
                if (Medida.Rows.Count == 0)
                    return 1d;
                return Convert.ToDouble(Medida.Rows[0]["Cnv_Multiplo"]);
            }
        }

        public double CambiaEmpaque(string AMed, string strdax, string strsys, string codigo = "")
        {
            if (AMed.Length == 0 || codigo.Length == 0) return 1;
            double CambiaEmpaqueRet = 0;
            string ssql;

            CambiaEmpaqueRet = 0d;
            ssql = "SELECT Art_codigo, isnull(Art_unimed,'') as art_unimed";
            ssql = ssql + ", isnull(CodEmpaque1,'') as CodEmpaque1, isnull(ValEmpaque1,0) as ValEmpaque1, isnull(CodEmpaque2,'') as CodEmpaque2, isnull(ValEmpaque2,0) as ValEmpaque2 ";
            ssql = ssql + ", isnull(CodEmpaque3,'') as CodEmpaque3, isnull(ValEmpaque3,0) as ValEmpaque3, isnull(CodEmpaque4,'') as CodEmpaque4, isnull(ValEmpaque4,0) as ValEmpaque4";
            ssql = ssql + ", isnull(CodEmpaque5,'')as CodEmpaque5, isnull(ValEmpaque5,0) as ValEmpaque5";
            ssql = ssql + " From AdcArt ";
            ssql = ssql + " where art_codigo = '" + codigo + "' ";

            using (SqlDataAdapter da = new SqlDataAdapter(ssql, strdax))
            {
                var rs = new DataTable();
                da.Fill(rs);
                if (rs.Rows.Count > 0)
                {
                    DataRow Drow = rs.Rows[0];
                    if (Drow["art_unimed"].ToString() == AMed) return 1;

                    try
                    {
                        if (AMed == Drow["codempaque1"].ToString()) CambiaEmpaqueRet = Convert.ToDouble(Drow["valempaque1"]);
                        else
                        if (AMed == Drow["codempaque2"].ToString()) CambiaEmpaqueRet = Convert.ToDouble(Drow["valempaque2"]);
                        else
                        if (AMed == Drow["codempaque3"].ToString()) CambiaEmpaqueRet = Convert.ToDouble(Drow["valempaque3"]);
                        else
                        if (AMed == Drow["codempaque4"].ToString()) CambiaEmpaqueRet = Convert.ToDouble(Drow["valempaque4"]);
                        else
                        if (AMed == Drow["codempaque5"].ToString()) CambiaEmpaqueRet = Convert.ToDouble(Drow["valempaque5"]);
                    }catch { }
                }
            }
            if (CambiaEmpaqueRet == 0)
            {
                using (SqlDataAdapter da = new SqlDataAdapter("select isnull(caracteristica1,0) as valor from syscod where tiporeferencia = 'empaque' and Abreviación = '" + AMed + "' ", strsys))
                {
                    DataTable rs = new DataTable();
                    da.Fill(rs);
                    if (rs.Rows.Count > 0)
                    {
                        CambiaEmpaqueRet = Convert.ToDouble(rs.Rows[0]["Valor"]);
                    }
                    rs = null;
                }
            }
            return CambiaEmpaqueRet;
        }
    }
}