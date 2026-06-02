using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using SysEmpDatt;

namespace DaxInvent
{
    class LibTallasColores
    {
        static public double NumeroMayorTiket()
        {
            double numeroTiket = 0;
            DataTable Rs = new DataTable();
            string Aux = "Select max(ISNULL(TIK_NUMERO,0)) AS TiketMayor from adctik";
            Rs = SqlDatos.leerTablaAdcom(Aux);
            if (Rs.Rows.Count == 0) { numeroTiket = 1; }
            else
            {
                Aux = Rs.Rows[0]["tiketmayor"].ToString();
                if (Aux.Length > 12) { Aux = Aux.Substring(0, 12); }
                numeroTiket = Convert.ToDouble("0" + Aux) + 1;
            }
            Rs.Dispose();
            return numeroTiket;
        }
        static public void cargaInicial(ref DataTable datosTallas, string codigoBase)
        {               
            if (datosTallas.Columns.Count > 0) return;
            
            string Ssql = "SELECT AdcTik.TIK_COLOR,TIK_SERIE,TIK_ALTERNO";
            Ssql += " , (select top 1 Descripcion from syscod where TipoReferencia = N'Color' and tik_color = abreviación) AS nombreColor";
            Ssql += " , AdcTik.TIK_TALLA";
            Ssql += " , (select top 1 Descripcion from syscod where TipoReferencia = N'Talla' and tik_talla = abreviación) AS nombreTalla";
            Ssql += " , AdcTik.TIK_ARTCODI ";
            Ssql += ", AdcTik.TIK_NUMERO ";
            Ssql += " FROM AdcTik where tik_artcodi LIKE '" + codigoBase + "%'";
            using (SqlDataAdapter da = new SqlDataAdapter(Ssql, datosEmpresa.strConxAdcom))
            {
                da.Fill(datosTallas);
            }
        }


    }
}
