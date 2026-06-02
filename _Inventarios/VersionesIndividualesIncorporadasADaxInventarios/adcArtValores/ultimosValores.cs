using System;
using System.Data;
using System.Data.SqlClient;

namespace DaxInvent
{ 
    public class ultimosValor
    {
        public double UltimoPrecioVenta(string Sucursal,string Cliente,string Articulo,Boolean Pantalla,string EnMedida,string TipoDoc, DateTime AlaFecha, string strConxAdcom,string strDaxsys)
        {
            adcArticulos.medidasArticulos medidas = new adcArticulos.medidasArticulos();
            DataTable RsCosUlt = new DataTable();
            double Auxnum = 0;
            double elPrecio=0;
            DateTime fecha;
            try { fecha = AlaFecha; }
            catch { AlaFecha = DateTime.Now ; }
            string sSql = "Adc_SpUltPrv '" + Sucursal + "', '" + Cliente + "', '" + Articulo + "', '" + AlaFecha + "' ";
            SqlDataAdapter da = new SqlDataAdapter(sSql,strConxAdcom);
            da.Fill(RsCosUlt);
            if (RsCosUlt.Rows.Count > 0)
            {
                elPrecio = Convert.ToDouble(RsCosUlt.Rows[0]["PrecioUnitario"]);
                if (EnMedida != RsCosUlt.Rows[0]["Medida"].ToString() && EnMedida != "") 
                {
                    Auxnum = medidas.MulMedida(RsCosUlt.Rows[0]["Medida"].ToString(), EnMedida, strDaxsys);
                    if (Auxnum != 0 )
                    {
                        elPrecio  = Convert.ToDouble(RsCosUlt.Rows[0]["PrecioUnitario"]) / Auxnum;
                    }
                }
            } 
            return elPrecio;
        }
        public double UltimoCostoCompra(string Sucursal, string Proveedor, string Articulo, Boolean Pantalla, string EnMedida, string TipoDoc, DateTime AlaFecha, string strConxAdcom, string strDaxsys)
        {
            adcArticulos.medidasArticulos medidas = new adcArticulos.medidasArticulos();
            DataTable RsCosUlt = new DataTable();
            double Auxnum = 0;
            double elCosto = 0;
            DateTime fecha;
            try { fecha = AlaFecha; }
            catch { AlaFecha = DateTime.Now; }
            string sSql = "Adc_SpUltCst '" + Sucursal + "', '" + TipoDoc + "', '" + Proveedor + "', '" + Articulo + "', '" + AlaFecha + "' ";
            SqlDataAdapter da = new SqlDataAdapter(sSql, strConxAdcom);
            da.Fill(RsCosUlt);
            if (RsCosUlt.Rows.Count > 0)
            {
                elCosto = Convert.ToDouble(RsCosUlt.Rows[0]["PrecioUnitario"]);
                if (EnMedida != RsCosUlt.Rows[0]["Medida"].ToString() && EnMedida != "")
                {
                    Auxnum = medidas.MulMedida(RsCosUlt.Rows[0]["Medida"].ToString(), EnMedida, strDaxsys);
                    if (Auxnum != 0)
                    {
                        elCosto = Convert.ToDouble(RsCosUlt.Rows[0]["PrecioUnitario"]) / Auxnum;
                    }
                }
            }
            return elCosto;
        }

        public double SaldoFecha(string strConxAdcom, string Articulo, string FechaFin = "",string EnMedida = "", string SucDoc = "", string TipoDoc = "", Double IdClaveDoc = 0, string bodega = "")
        {
            double Promedio = 0;
            double cantidad = 0;
            double cantidadBod = 0;
            double Costo = 0;
            if (FechaFin == "" ) FechaFin = DateTime.Now.ToShortDateString ();
            string sel = "DaxInvcstProm '" + FechaFin + "','" + Articulo + "','" + bodega + "'";
            using (DataTable dt = new DataTable())    
            {
                using (SqlDataAdapter da = new SqlDataAdapter(sel,strConxAdcom))
                {
                    da.Fill(dt);
                    if (dt.Rows.Count > 0) 
                    { 
                        cantidad = Convert.ToDouble(dt.Rows[0]["traCanti"]); 
                        Costo = Convert.ToDouble(dt.Rows[0]["traCosto"]);
                        cantidadBod = Convert.ToDouble(dt.Rows[0]["traCantiBod"]); 
                    }
                }
                if (cantidad != 0) Promedio = Costo/cantidad;
            }        
            return Promedio;
        }
        public double SaldoPorEntregar(string AlaFecha, string codigo, string DocSucSoporte, string DocTipSoporte, string DocNumSoporte, string DocSucOM, string DocTipOM,string DocNumOM,string strConxAdcom) 
        {
            double saldo=0;
            DataTable rs = new DataTable();
            string ssql = "ADC_SALNTRG '" + AlaFecha + "','" + codigo + "','" + DocSucSoporte + "','" + DocTipSoporte + "'," + DocNumSoporte + ",'" + DocSucOM + "','" + DocTipOM + "'," + DocNumOM;
            SqlDataAdapter da = new SqlDataAdapter (ssql,strConxAdcom);
            da.Fill(rs);
            if (rs.Rows.Count > 0)
            {
                saldo = Convert.ToDouble(rs.Rows[0]["Pendiente"].ToString());
            }
            rs.Dispose();
            da.Dispose();
            return saldo;
        }

    }
}
