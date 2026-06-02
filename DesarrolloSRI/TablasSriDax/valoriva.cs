using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace IvaRett 
{
public class valorIva
    {
        public double ValorIvaAfecha(DateTime fecha, string strSri)
        {
            double valIva = 0;

            string ssql = "select Porcentaje,isnull(FechaInicio,'01/01/1900') as FechaInicio,isnull(FechaFin,'31/12/2999') as FechaFin";
            ssql += " from PorcentajeIva";
            ssql += " where isnull(FechaInicio,'01/01/1900') <= '" + fecha.ToShortDateString() + "' and isnull(FechaFin,'31/12/2999') >= '" + fecha.ToShortDateString() + "'";
            SqlDataAdapter da = new SqlDataAdapter(ssql, strSri);
            DataTable dt = new DataTable();
            try
            {
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                    valIva = Convert.ToDouble(dt.Rows[0]["Porcentaje"]) * 100;
            }
            catch
            {
            }
            return valIva;
        }
    }

    public class valorIce
    {
        public double ValorIceAfecha(DateTime fecha, string strSri)
        {
            double valIce = 0;

            // Dim ssql As String = "select Porcentaje,isnull(FechaInicio,'01/01/1900') as FechaInicio,isnull(FechaFin,'31/12/2999') as FechaFin"
            // ssql += " from PorcentajeIce"
            // ssql += " where isnull(FechaInicio,'01/01/1900') <= '" + fecha.ToShortDateString() + "' and isnull(FechaFin,'31/12/2999') >= '" + fecha.ToShortDateString() + "'"
            // Dim da As New SqlDataAdapter(ssql, strSri)
            // Dim dt As New DataTable
            // Try
            // da.Fill(dt)
            // If dt.Rows.Count > 0 Then
            // valIce = Convert.ToDouble(dt.Rows(0)("Porcentaje")) * 100
            // End If
            // Catch

            // End Try

            return valIce;
        }
    }
}

