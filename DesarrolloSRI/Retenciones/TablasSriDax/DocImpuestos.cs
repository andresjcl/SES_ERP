using System;
using System.Data ;
using System.Data.SqlClient;

namespace IvaRett
{
    public  class docImpuestos
    {
        public bool cambiadoManual = false;
        public double impstoPorcentaje1 = 0d;   // iva
        public double impstoPorcentaje2 = 0d;   // ice
        public double impstoPorcentaje3 = 0d;
        public double impstoPorcentaje4 = 0d;
        public string impstoNombre1 = "";
        public string impstoNombre2 = "";
        public string impstoNombre3 = "";
        public string impstoNombre4 = "";
        public DateTime impstoFechaIni1 = new DateTime(1900, 1, 1);
        public DateTime impstoFechaFin1 = new DateTime(1900, 1, 1);
        public DateTime impstoFechaIni2 = new DateTime(1900, 1, 1);
        public DateTime impstoFechaFin2 = new DateTime(1900, 1, 1);
        public DateTime impstoFechaIni3 = new DateTime(1900, 1, 1);
        public DateTime impstoFechaFin3 = new DateTime(1900, 1, 1);
        public DateTime impstoFechaIni4 = new DateTime(1900, 1, 1);
        public DateTime impstoFechaFin4 = new DateTime(1900, 1, 1);

        public void cargar(string strSri, DateTime fecha)
        {
            var dt = new DataTable();
            string ssql = "select Porcentaje,isnull(FechaInicio ,'01/01/1900') as FechaInicio,isnull(fechaFin,'31/12/2999') as FechaFin  from " + nombreTablas.PorcentajeIva;
            ssql += " where isnull(FechaInicio ,'01/01/1900') <= '" + fecha.ToShortDateString() + "' and isnull(fechaFin,'31/12/2999') >= '" + fecha.ToShortDateString() + "'";
            var da = new SqlDataAdapter(ssql, strSri);
            da.Fill(dt);
            impstoNombre1 = "IVA";
            if (dt.Rows.Count > 0)
            {
                impstoPorcentaje1 = Convert.ToDouble(dt.Rows[0]["Porcentaje"]) * 100;
                impstoFechaIni1 = Convert.ToDateTime(dt.Rows[0]["FechaInicio"]);
                impstoFechaFin1 = Convert.ToDateTime(dt.Rows[0]["FechaFin"]);
            }
            else
            {
                impstoPorcentaje1 = 0;
                impstoFechaIni1 = new DateTime(1900, 1, 1);
                impstoFechaFin1 = new DateTime(1900, 1, 1);
            }
            dt.Dispose();
            da.Dispose();
        }
    }
}
