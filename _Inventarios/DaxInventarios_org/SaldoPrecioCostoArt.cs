using System;
using System.Data;
using System.Data.SqlClient;
using SysEmpDatt;
namespace DaxInvent
{ 
    public class SaldoArticulo
    {
        public double CantidadTotal = 0;
        public double CostoTotal = 0;
        public double CostoPromedio = 0;
        public double CantidadBodega = 0;
    }
    public class ultimosValor
    {
        static public double UltimoPrecioVenta(string Sucursal,string Cliente,string Articulo,Boolean Pantalla,string EnMedida,string TipoDoc, DateTime AlaFecha, string strConxAdcom,string strDaxsys)
        {
            DaxInvent.medidasArticulos medidas = new medidasArticulos();
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
        static public double UltimoCostoCompra(string Sucursal, string Proveedor, string Articulo, Boolean Pantalla, string EnMedida, string TipoDoc, DateTime AlaFecha, string strConxAdcom, string strDaxsys)
        {
            medidasArticulos medidas = new medidasArticulos();
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

        static public SaldoArticulo SaldoFecha(string strConxAdcom, string Articulo, string FechaFin = "",string EnMedida = "", string SucDoc = "", string TipoDoc = "", Double IdClaveDoc = 0, string bodega = "")
        {
            SaldoArticulo SalArt = new SaldoArticulo();
            if (FechaFin == "" ) FechaFin = DateTime.Now.ToShortDateString ();
            string sel = "DaxInvcstProm '" + FechaFin + "','" + Articulo + "','" + bodega + "'";
            using (DataTable dt = new DataTable())    
            {
                using (SqlDataAdapter da = new SqlDataAdapter(sel,strConxAdcom))
                {
                    da.Fill(dt);
                    if (dt.Rows.Count > 0) 
                    { 
                        SalArt.CantidadTotal = Convert.ToDouble(dt.Rows[0]["traCanti"]); 
                        SalArt.CostoTotal = Convert.ToDouble(dt.Rows[0]["traCosto"]);
                        SalArt.CantidadBodega = Convert.ToDouble(dt.Rows[0]["traCantiBod"]); 
                    }
                }
                if (SalArt.CantidadTotal != 0) SalArt.CostoPromedio = SalArt.CostoTotal/ SalArt.CantidadTotal;
            }        
            return SalArt;
        }
        static public double SaldoPorEntregar(string AlaFecha, string codigo, string DocSucSoporte, string DocTipSoporte, string DocNumSoporte, string DocSucOM, string DocTipOM,string DocNumOM,string strConxAdcom) 
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
        static public double CargarPromedioHistorico (string ArticuloAnt, DateTime tra_fecha)
        {
            double costo = 0;
            string ssql = "SELECT top(1) * ";
            ssql += " From AdcCstProm Where tra_codigo = '" + ArticuloAnt + "' ";
            ssql += " and (año * 100 + mes ) <= " + tra_fecha.Year  * 100 + tra_fecha.Month ;
            ssql += " order by año desc, mes desc ";
            SqlDataReader dr = SqlDatos.leerBaseAdcom(ssql);
            try
            {
                costo = Convert.ToDouble(dr["costoProm"].ToString());
            }catch{ }
            dr.Close();
            return costo;
        }
    }
}
