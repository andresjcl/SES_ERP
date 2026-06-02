using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace libreriasTekform
{
    using Microsoft.VisualBasic;

    public class NumLetra
    {
        public static string Cnl(decimal Numero, string ConDecimal)
        {
            if (Numero == 0) return "CERO";
            string[] Unidades = new string[20];
            string[] Decenas = new string[10];
            string[] Centenas = new string[10];
            string[] Miles = new string[5];

            int ValorTripleta;
            string Entero = "";
            string Ndecimal = "";
            string Sauxil = "";
            int IndUndSimples = 0;
            int IndUndDobles = 0;
            int IndDecenas = 0;
            int IndUndFinales = 0;
            string Pasar = "";

            Unidades[1] = "UN";
            Unidades[2] = "DOS";
            Unidades[3] = "TRES";
            Unidades[4] = "CUATRO";
            Unidades[5] = "CINCO";
            Unidades[6] = "SEIS";
            Unidades[7] = "SIETE";
            Unidades[8] = "OCHO";
            Unidades[9] = "NUEVE";
            Unidades[10] = "DIEZ";
            Unidades[11] = "ONCE";
            Unidades[12] = "DOCE";
            Unidades[13] = "TRECE";
            Unidades[14] = "CATORCE";
            Unidades[15] = "QUINCE";
            Unidades[16] = "DIECISEIS";
            Unidades[17] = "DIECISIETE";
            Unidades[18] = "DIECIOCHO";
            Unidades[19] = "DIECINUEVE";

            Decenas[1] = "DIEZ";
            Decenas[2] = "VEINTE";
            Decenas[3] = "TREINTA";
            Decenas[4] = "CUARENTA";
            Decenas[5] = "CINCUENTA";
            Decenas[6] = "SESENTA";
            Decenas[7] = "SETENTA";
            Decenas[8] = "OCHENTA";
            Decenas[9] = "NOVENTA";

            Centenas[1] = "CIENTO";
            Centenas[2] = "DOSCIENTOS";
            Centenas[3] = "TRESCIENTOS";
            Centenas[4] = "CUATROCIENTOS";
            Centenas[5] = "QUINIENTOS";
            Centenas[6] = "SEISCIENTOS";
            Centenas[7] = "SETECIENTOS";
            Centenas[8] = "OCHOCIENTOS";
            Centenas[9] = "NOVECIENTOS";

            Miles[1] = "MIL";
            Miles[2] = "MILLON";
            Miles[3] = "MIL";
            Miles[4] = " ";

            Entero = Numero.ToString();
            Ndecimal = "";
            int ind = Entero.IndexOf(".");
            if (ind > -1)
            {
                Ndecimal = Entero.Substring(ind + 1);
                Entero = Entero.Substring(0, ind + 1);
            }

            if (Ndecimal.Length < 2) Ndecimal = "0" + Ndecimal;

            if (Convert.ToInt32(Entero) == 0)
                Pasar = "CERO ";
            else
                for (int j = 0; j <= 3; j++)
                {
                    Sauxil = Entero.Substring( j + 2 * j, 3);
                    ValorTripleta = System.Convert.ToInt32(Sauxil);
                    if (ValorTripleta > 0)
                    {
                        IndUndSimples = System.Convert.ToInt32(Sauxil.Substring( 0, 1));
                        IndUndDobles = System.Convert.ToInt32(Sauxil.Substring(1, 2));
                        IndDecenas = System.Convert.ToInt32(Sauxil.Substring( 1, 1));
                        IndUndFinales = System.Convert.ToInt32(Sauxil.Substring( 2, 1));
                        Centenas[1] =  "CIEN";
                        if (ValorTripleta != 100)Centenas[1] = "CIENTO";
                        if (ValorTripleta > 99) Pasar = Pasar + Centenas[IndUndSimples] + " ";
                        if (IndUndDobles > 19)
                        {
                            Pasar = Pasar + Decenas[IndDecenas];
                            if (IndUndFinales > 0) Pasar = Pasar + " Y " + Unidades[IndUndFinales];
                        }
                        if (IndUndDobles > 0 && IndUndDobles < 20) Pasar = Pasar + Unidades[IndUndDobles];
                        if (j < 3)
                        {
                            Pasar = Pasar + " " + Miles[j];
                            if (j < 2 & ValorTripleta > 1) Pasar = Pasar + "ES";
                        }
                        else if (IndUndFinales == 1 & IndUndDobles != 11)
                            Pasar = Pasar + "O";
                        Pasar = Pasar + " ";
                    }
                }
            if (ConDecimal == "S" || ConDecimal == "Y")
                { return Pasar + Ndecimal + "/".PadRight(Ndecimal.Length+1,Convert.ToChar("0")); }
            else
                { return Pasar; }
        }
    }
}
