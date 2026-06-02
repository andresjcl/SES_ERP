using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using adcArticulo;
using DattCom;
using DaxInvent;
namespace DaxComercia
{
    public static class cargarPrecios
    {
		public static double CargarPrecioVta(Int32 KeyCode, ref adcArticulo.AdcArt OpArticulo, double porciva, ref int QuePrecio, string Aut = "T", string EnMedida = "", string CodCliente = "", Int32 digitosPrecios = 2)
		{
			double elprecio = 0;

			if (OpArticulo == null) return 0;
			if (porciva == 0) porciva = 1;
			if (EnMedida == "") EnMedida = OpArticulo.Art_unimed;
			if (Aut == "") Aut = "T";

			if (CodCliente != "" && OpArticulo.Art_codigo != "")
			{
				elprecio = precioPorCliente(OpArticulo, CodCliente, porciva, datosEmpresa.strConxAdcom, digitosPrecios);
				if (elprecio != 0) return elprecio;
			}

			if (KeyCode == Convert.ToInt32(Keys.F2)) elprecio = calculaPrecio(OpArticulo.Art_IncluyeIvaP1, OpArticulo.Art_precvta1, porciva, digitosPrecios);       //  F2 para cargar primer precio
			else if (KeyCode == Convert.ToInt32(Keys.F3)) elprecio = calculaPrecio(OpArticulo.Art_IncluyeIvaP2, OpArticulo.Art_precvta2, porciva, digitosPrecios);   //  F3 para cargar segundo precio
			else if (KeyCode == Convert.ToInt32(Keys.F4)) elprecio = calculaPrecio(OpArticulo.Art_IncluyeIvaP3, OpArticulo.Art_precvta3, porciva, digitosPrecios);   //   F4 para cargar tercero precio
			else if (KeyCode == Convert.ToInt32(Keys.F5)) elprecio = calculaPrecio(OpArticulo.Art_IncluyeIvaP4, OpArticulo.Art_precvta4, porciva, digitosPrecios);   //  F5 para cargar cuarto precio
			else if (KeyCode == Convert.ToInt32(Keys.F6)) elprecio = calculaPrecio(OpArticulo.Art_IncluyeIvaP5, OpArticulo.Art_precvta5, porciva, digitosPrecios);   //  F6 para cargar quinto precio

			if (OpArticulo.Art_unimed != EnMedida && OpArticulo.Art_unimed != "" && EnMedida != "") elprecio = Math.Round((elprecio * DaxInvent.MultMedida.MulMedida (EnMedida, OpArticulo.Art_unimed)), digitosPrecios);

			return elprecio;
		}
		public static double CargarPrecioVta(Int32 KeyCode, string codArticulo, double porciva, ref int QuePrecio, string Aut = "T", string EnMedida = "", string CodCliente = "", Int32 digitosPrecios = 2)
		{
			AdcArt OpArticulo = new AdcArt(datosEmpresa.strConxAdcom);
			OpArticulo = AdcArt.Buscar("Art_codigo = '" + codArticulo + "'");
			if (OpArticulo == null) return 0;
			double precioVenta = CargarPrecioVta(KeyCode, ref OpArticulo, porciva, ref QuePrecio, Aut, EnMedida, CodCliente , digitosPrecios);
			OpArticulo = null;
			return precioVenta;
		}
		public static double CargarPrecio(string strDax, string strsys, Int32 KeyCode, ref adcArticulo.AdcArt  OpArticulo, double porciva ,string  Aut="T", double QuePrecio = 0, string EnMedida = "", string CodCliente= "", Int32 digitosPrecios = 2)
        {
            double elprecio = 0;

            if (OpArticulo == null) return 0;
            if (porciva == 0) porciva = 1;
            if (EnMedida == "") EnMedida = OpArticulo.Art_unimed;
            if (Aut == "") Aut = "T";

            if (CodCliente != "" && OpArticulo.Art_categor != "")
            {
                elprecio = precioPorCliente(OpArticulo, CodCliente, porciva,strDax, digitosPrecios);
                if (elprecio != 0) return elprecio;
            }

            if (KeyCode == Convert.ToInt32(Keys.F2)) elprecio = calculaPrecio(OpArticulo.Art_IncluyeIvaP1, OpArticulo.Art_precvta1, porciva, digitosPrecios);       //  F2 para cargar primer precio
            else if (KeyCode == Convert.ToInt32(Keys.F3)) elprecio = calculaPrecio(OpArticulo.Art_IncluyeIvaP2, OpArticulo.Art_precvta2, porciva, digitosPrecios);   //  F3 para cargar segundo precio
            else if (KeyCode == Convert.ToInt32(Keys.F4)) elprecio = calculaPrecio(OpArticulo.Art_IncluyeIvaP3, OpArticulo.Art_precvta3, porciva, digitosPrecios);   //   F4 para cargar tercero precio
            else if (KeyCode == Convert.ToInt32(Keys.F5)) elprecio = calculaPrecio(OpArticulo.Art_IncluyeIvaP4, OpArticulo.Art_precvta4, porciva, digitosPrecios);   //  F5 para cargar cuarto precio
            else if (KeyCode == Convert.ToInt32(Keys.F6)) elprecio = calculaPrecio(OpArticulo.Art_IncluyeIvaP5, OpArticulo.Art_precvta5, porciva, digitosPrecios);   //  F6 para cargar quinto precio
            if (OpArticulo.Art_unimed != EnMedida && OpArticulo.Art_unimed != "" && EnMedida != "") elprecio = Math.Round((elprecio * MultMedida.MulMedida(EnMedida, OpArticulo.Art_unimed)), digitosPrecios);
            return elprecio;
        }
        public static double CargarPrecio(string strDax, string strsys, Int32 KeyCode, string Codigo, double porciva, string Aut = "T", double QuePrecio = 0, string EnMedida = "", string CodCliente = "", Int32 digitosPrecios = 2)
        {
            AdcArt OpArticulo = new AdcArt(strDax);
            OpArticulo = AdcArt.Buscar("Art_codigo = '" + Codigo + "'");

            return CargarPrecio(strDax, strsys, KeyCode, ref OpArticulo, porciva, Aut, QuePrecio, EnMedida, CodCliente, digitosPrecios);
        }
        private static double calculaPrecio(Boolean IncluyeIva, decimal precvta, double porciva, Int32 digitosPrecios)
        {
            if (IncluyeIva == true)
            {
                return Math.Round(Convert.ToDouble(precvta) / ((porciva/100) + 1), digitosPrecios);
            }
            else
            {
                return Math.Round(Convert.ToDouble(precvta), digitosPrecios);
            }
        }

        public static double precioPorCliente(AdcArt Articulo, string elcodigoCli, double porciva, string strDax, Int32 DigitosPrecios)
        {
            if (Articulo == null || Articulo.Art_codigo == "" || elcodigoCli == "") return 0;
            double precio = 0;
            string ssql = "SELECT AdcPrvtaLis.Lista, isnull(AdcPrvtaLis.IncluyeIva,0) as IncluyeIva, AdcPrvta.CodigoProducto, isnull(AdcPrvta.PrecioProducto,0) as PrecioProducto";
            ssql += " FROM AdcPrvtaLis left JOIN AdcPrvta ON AdcPrvtaLis.Lista = AdcPrvta.Lista";
            ssql += " where codigoProducto = '" + Articulo.Art_codigo + "' AND cliente = '" + elcodigoCli + "' ";
            using (SqlDataAdapter da = new SqlDataAdapter(ssql, strDax))
            {
                using (DataTable rs = new DataTable())
                {
                    da.Fill(rs);
                    if (rs.Rows.Count > 0)
                    {
                        precio = Convert.ToDouble(rs.Rows[0]["PrecioProducto"]);
                        if (Convert.ToInt32(rs.Rows[0]["IncluyeIva"]) == 1) precio = Math.Round(precio / ((porciva / 100) + 1), DigitosPrecios);
                    }
                }
            }
            return precio;
        }
    }
}
