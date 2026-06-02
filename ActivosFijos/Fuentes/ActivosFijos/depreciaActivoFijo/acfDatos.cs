using System;
using System.Collections.Generic;
using System.Data ;
using System.Data.SqlClient;
using System.Text;

namespace depreciaActivoFijo
{
    class acfDatos
    {
        private string strConxAdcom="";
        private string codigo = "";
        private long año = 0;
        private long mes = 0;
        private long periodo = 0;

        public double DeterioroMes = 0;
        public double RevalorizacionMes = 0;
        public double ProduccionMes = 0;
        public double NuevaVidaUtil = 0;
        public double NuevoValorResidual = 0;
        public double valDepreciacionAcuF;
        public double valDeterioroAcuF;
        public double valRevalorizaAcuF;
        public double valDepreciacionAcuT;
        public double valDeterioroAcuT;
        public double valRevalorizaAcuT;   

        public acfDatos(string strconx, long mesPro, long añoPro, string codAcf)
        {
            strConxAdcom = strconx;
            año = añoPro;
            mes = mesPro;
            periodo = añoPro*100+mesPro ;
            consultaNov();
            UnidadesProducidas();

            calcularAcumulados(codAcf, periodo.ToString(), "T", ref valDepreciacionAcuT, ref valDeterioroAcuT, ref valRevalorizaAcuT);
            calcularAcumulados(codAcf, periodo.ToString(), "F", ref valDepreciacionAcuF, ref valDeterioroAcuF, ref valRevalorizaAcuF);
        }
        
        private void consultaNov()
        {
            string sSql = "select NVdeterioro,NVrevalorizacion,NVvidautil,NVvalorresidual from adcAcfNov where Codigo ='" + codigo + "' and (YEAR(FechaNovedad)*100+MONTH(FechaNovedad))=" + (año * 100 + mes);
            using (SqlConnection conectarBDD =  new SqlConnection(strConxAdcom))
            {
            conectarBDD.Open ();
            SqlCommand com = new SqlCommand(sSql, conectarBDD);
            SqlDataReader dat = com.ExecuteReader();
        
            if( dat.Read()) 
            {
                if (dat["NVdeterioro"] != null) DeterioroMes = Convert.ToDouble(dat["NVdeterioro"]);
                if (dat["NVrevalorizacion"] != null) RevalorizacionMes = Convert.ToDouble(dat["NVrevalorizacion"]);
                if (dat["NVvidautil"] != null) NuevaVidaUtil = Convert.ToDouble(dat["NVvidautil"]);
                if (dat["NVvalorresidual"] != null) NuevoValorResidual = Convert.ToDouble(dat["NVvalorresidual"]);
            } 
            conectarBDD.Close();
            dat.Close();
            dat.Dispose();
            com.Dispose();
            UnidadesProducidas();
            }
        }

        private void UnidadesProducidas()
        {
            string ssql = "select sum(NVvalorproduccionmes) as NVvalorproduccionmes from adcAcfNov where Codigo ='" + codigo + "' and (YEAR(FechaProduccion)*100+MONTH(FechaProduccion))=" + (año * 100 + mes);
            using (SqlConnection conectarBDD =  new SqlConnection(strConxAdcom))
            {
                conectarBDD.Open();
                SqlCommand  cmd = new SqlCommand(ssql, conectarBDD);
                SqlDataReader dat = cmd.ExecuteReader();
                if (dat.Read())
                {
                    if (dat["NVvalorproduccionmes"] != null) ProduccionMes = Convert.ToDouble("0"+dat["NVvalorproduccionmes"].ToString());
                }
                dat.Close();
                dat.Dispose();
                cmd.Dispose();
                conectarBDD.Close();
            }
        }

        private void calcularAcumulados(string codigo,string periodo, string tipoDep, ref double valDepr, ref double valDet, ref double valRev)
        {
            string ssql = "select  SUM(DepreciacionMes) AS DepAcu,sum(DeterioroMes) as DetAcu,sum(RevalorizacionMes) as RevAcu from adcacfdep where codigo = '" + codigo + "' and claseDepreciacion = '" + tipoDep + "' ";
            ssql += " and (   año * 100 + mes  < " + periodo + ")";
            using (SqlConnection conn = new SqlConnection(strConxAdcom))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand(ssql, conn))
                {
                    using (SqlDataReader dr = comm.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            valDepr = Convert.ToDouble("0" + dr["DepAcu"]);
                            valDet = Convert.ToDouble("0" + dr["DetAcu"]);
                            valRev = Convert.ToDouble("0" + dr["RevAcu"]);
                        }
                        dr.Close();
                    }
                }
            }
        }

    }
}