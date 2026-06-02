using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace adcArticulosPrecios
{
    public class classVar
    {
        public static string[] valorOrigen = new string[8];
        public static string[] valorDestino = new string[8];
        public static string[] datoSql = new string[8];

        public static void classVarIni()
        {
            valorDestino[0] = "Precio de venta 1";
            valorDestino[1] = "Precio de venta 2";
            valorDestino[2] = "Precio de venta 3";
            valorDestino[3] = "Precio de venta 4";
            valorDestino[4] = "Precio de venta 5";
            valorDestino[5] = "% Descuento Automático";
            valorDestino[6] = "% Máximo Descuento";

            valorOrigen[0] = "Ultimo precio de compra";
            valorOrigen[1] = "Costo promedio";
            valorOrigen[2] = "Precio de venta 1";
            valorOrigen[3] = "Precio de venta 2";
            valorOrigen[4] = "Precio de venta 3";
            valorOrigen[5] = "Precio de venta 4";
            valorOrigen[6] = "Precio de venta 5";

            datoSql[0] = "UltimoPrecioCompra";
            datoSql[1] = "CostoPromedio";
            datoSql[2] = "PrecioVta1";
            datoSql[3] = "PrecioVta2";
            datoSql[4] = "PrecioVta3";
            datoSql[5] = "PrecioVta4";
            datoSql[6] = "PrecioVta5";
            datoSql[7] = "Coeficiente";
        }
        public static void columnaPrecio(string combPrecio,string txtPActual, ref string cambiarPrecio, ref string precioActual, ref int numPrecio)
        {
            if (combPrecio == classVar.valorDestino[0])
            {
                cambiarPrecio = "Art_precvta1";
                numPrecio = 0;
            }
            if (combPrecio == classVar.valorDestino[1])
            {
                cambiarPrecio = "Art_precvta2";
                numPrecio = 1;
            }
            if (combPrecio == classVar.valorDestino[2])
            {
                cambiarPrecio = "Art_precvta3";
                numPrecio = 2;
            }
            if (combPrecio == classVar.valorDestino[3])
            {
                cambiarPrecio = "Art_precvta4";
                numPrecio = 3;
            }
            if (combPrecio == classVar.valorDestino[4])
            {
                cambiarPrecio = "Art_precvta5";
                numPrecio = 4;
            }
            if (combPrecio == classVar.valorDestino[5])
            {
                cambiarPrecio = "Art_descuen";
                numPrecio = 5;
            }
            if (combPrecio == classVar.valorDestino[6])
            {
                cambiarPrecio = "art_limDescuento";
                numPrecio = 6;
            }


            if (txtPActual == classVar.valorOrigen[0])
            {
                precioActual = "UltimaCompra";
            }
            if (txtPActual == classVar.valorOrigen[1])
            {
                precioActual = "CostoPromedio";
            }
            if (txtPActual == classVar.valorOrigen[2])
            {
                precioActual = "Art_precvta1";
            }
            if (txtPActual == classVar.valorOrigen[3])
            {
                precioActual = "Art_precvta2";
            }
            if (txtPActual == classVar.valorOrigen[4])
            {
                precioActual = "Art_precvta3";
            }
            if (txtPActual == classVar.valorOrigen[5])
            {
                precioActual = "Art_precvta4";
            }
            if (txtPActual == classVar.valorOrigen[6])
            {
                precioActual = "Art_precvta5";
            }
        }
        public static Int64 ultimoCambioProducto(string strConxAdcom)
        {
            Int64 clave = 0;
            string ssql = "select max(claveCambio) as clave from AdcPrvtabk";
            using (SqlDataAdapter da = new SqlDataAdapter(ssql, strConxAdcom))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0) clave = Convert.ToInt64("0" + dt.Rows[0]["clave"].ToString());
                clave = clave + 1;
                dt.Dispose();
            }
            return clave;
        }
    }
}
