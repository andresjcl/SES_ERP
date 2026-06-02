using System;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using DattCom;
namespace DaxComercia
{
	static public class utility
	{
        public static pagoDoc CrearPagoDocumento(string IdformasDePago, double valor)
        {
            if (IdformasDePago == "EFE") return CrearEfectivo(valor);
            return CrearPagoCliente(IdformasDePago, valor);
        }
        public static pagoDoc CrearEfectivo(double valor)
		{
			string IdformasDePago = "EFE";
            DaxComercia.pagoDoc elPago = new pagoDoc();
            elPago.IdFormaDePago = IdformasDePago;
            elPago.Valor = valor;
            registrarDatosFormaDePago(elPago);
            return elPago;
		}
		public static DaxComercia.pagoDoc CrearPagoCliente(string IdformasDePago,double valor)
		{
            DaxComercia.pagoDoc elPago = new pagoDoc();
            elPago.IdFormaDePago = IdformasDePago;
            elPago.Valor = valor;
            registrarDatosFormaDePago(elPago);
            return elPago;
		}

		public static string codigoSri(string idFormasDePago,ref string GrupoDelPago,ref int PagoCredito, ref string concepto, ref Int32 diasCuota)
		{
			
			string ssql = "select isnull(diasCuotaFijas,0) as diasCuota, isnull(SRI_formaDePago,'0') as SRI_formaDePago,formaDepago,tipoformapago,Descripcion from FormasDePago where idFormasDePago = '" + idFormasDePago + "'";
			try
            {
				DataTable dato = new DataTable();
				SqlDataAdapter misqlDa = new SqlDataAdapter(ssql, datosEmpresa.strConxAdcom);
				misqlDa.Fill(dato);
				if (dato.Rows.Count > 0 )
				{
					ssql = dato.Rows[0]["sri_formaDePago"].ToString();
					GrupoDelPago = dato.Rows[0]["TipoformaPago"].ToString();
					PagoCredito = Convert.ToInt32("0"+dato.Rows[0]["formaDePago"].ToString());
					concepto = dato.Rows[0]["Descripcion"].ToString();
					diasCuota = Convert.ToInt32(dato.Rows[0]["diasCuota"].ToString());

                    if (PagoCredito != 2) { PagoCredito = 1; }
				}
			}
			catch 
			{
				ssql = "20";
			}
			return ssql;
		}
        public static void registrarDatosFormaDePago(pagoDoc elPago)
        {
            string ssql = "select * from FormasDePago where idFormasDePago = '" + elPago.IdFormaDePago + "'";
            try
            {
                using (SqlDataAdapter misqlDa = new SqlDataAdapter(ssql, datosEmpresa.strConxAdcom))
                {
                    DataTable dato = new DataTable();
                    misqlDa.Fill(dato);
                    if (dato.Rows.Count > 0)
                    {
                        elPago.autoriza = dato.Rows[0]["sri_formaDePago"].ToString();
                        elPago.CancelaFactura = Convert.ToInt32("0" + dato.Rows[0]["CancelaFactura"].ToString());
                        elPago.TipoPag = dato.Rows[0]["TipoformaPago"].ToString();
                        elPago.PagoACredito = Convert.ToInt32("0" + dato.Rows[0]["formaDePago"].ToString());
                        elPago.Descripcion = dato.Rows[0]["Descripcion"].ToString();
                        int diasCuota = Convert.ToInt32(dato.Rows[0]["diasCuotaFijas"].ToString());
                    }
                }
            }
            catch { }
        } 
    }

}
