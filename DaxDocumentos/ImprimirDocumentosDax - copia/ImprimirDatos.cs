using System;
using System.Drawing;

namespace ImpresionDocumentosDax
{
    class ImprimirDatos
    {
        public static void ImprimeDato(ref int Currenty,Int32 LargoImprimible, string ValorDato, byte Alineacion, string FormatoImpresion, int Ancho, int Posicion, Graphics Hojagraphics = null, int alto = 0, Font TipoFont = null)
        {
            if (ValorDato == "."){Currenty += alto; return;}
            bool tieneBarras = false;
            SizeF SizeCampo = Hojagraphics.MeasureString(ValorDato, TipoFont);
            int Wlet = System.Convert.ToInt32(SizeCampo.Width);
            int Wheight = System.Convert.ToInt32(SizeCampo.Height);
            int AnchoRelleno = ValorDato.Length;
            string Aimprimir = ValorDato;

            if (Wlet > Ancho) AnchoRelleno = Ancho * 2;   // si la longitud del campo a imprimir es mas ancha que el rectangulo de impresion el relleno sera de acuerdo al tamaño del rectangulo
            if (alto == 0) alto = Wheight;
            
            int longFormato = FormatoImpresion.Length;
            if (longFormato > 0)
            {
                if (FormatoImpresion.IndexOf("Barra_") >= 0)
                {
                    tieneBarras = true;
                }
                else if (FormatoImpresion.IndexOf("ValorEnLetras") >= 0)
                {
                    Aimprimir = libreriasTekform.NumLetra.Cnl(System.Convert.ToDecimal(ValorDato), "S");
                    if (longFormato > 13) Aimprimir += FormatoImpresion.Substring(13);
                }
                else
                {
                    string TipoFormato = FormatoImpresion.Substring(longFormato-1, 1);
                    if (TipoFormato == "B")
                    {
                        decimal valor = 0;
                        try { valor = Convert.ToDecimal(ValorDato); } catch { };
                        if (valor == 0) { Aimprimir = ""; } 
                        else { Aimprimir = AplicarFormato(ValorDato, FormatoImpresion.Substring(0,longFormato-1)); }
                    }
                    else if (TipoFormato == "*" | TipoFormato == "=")
                    {
                        Aimprimir = AplicarFormato(ValorDato, FormatoImpresion.Substring(0,longFormato-1));
                        if (Alineacion == 9) Aimprimir = Aimprimir.PadRight(AnchoRelleno, Convert.ToChar(TipoFormato));
                        if (Alineacion == 1) Aimprimir = Aimprimir.PadLeft(AnchoRelleno, Convert.ToChar(TipoFormato));
                    }
                    else
                    {
                        Aimprimir = AplicarFormato(ValorDato, FormatoImpresion);
                    }
                }
            }

            try
            {
                if (Currenty + alto < LargoImprimible)
                {
                    StringFormat ST = new StringFormat();
                    ST.Alignment = StringAlignment.Near;
                    if (Alineacion == 1)
                        ST.Alignment = StringAlignment.Far;
                    if (Alineacion == 2)
                        ST.Alignment = StringAlignment.Center;
                    if (Alineacion == 9)
                    {
                        if (Wlet > Ancho & alto < Wheight * 2)
                            Ancho = Wlet + 1;
                    }
                    RectangleF R = new RectangleF(Posicion, Currenty, Ancho, alto);
                    if (tieneBarras)
                    {
                        libreriasTekform.codBarras.registraBarras(Aimprimir, FormatoImpresion, Ancho, alto, Currenty, Posicion, LargoImprimible, ref Hojagraphics);
                    }
                    else
                    {
                        Hojagraphics.DrawString(Aimprimir, TipoFont, Brushes.Black, R, ST);
                    }
                }
                else
                { }
            }
            catch
            {
                //Interaction.MsgBox("No se puede imprimir el campo " + Aimprimir + " formato " + FormatoImpresion);
            }
            Currenty += alto;
        }
        static public string AplicarFormato(string ValorDato, string Formato)
        {
            if (Formato.IndexOf("#") >= 0 || Formato.IndexOf("0") >= 0)
            {
                Formato = RegresaForma(Formato);
                try
                {
                    Double campoNum = Convert.ToDouble(ValorDato);
                    return campoNum.ToString(Formato);
                }
                catch { }
            }
            if (Formato.ToUpper().IndexOf("DD") >= 0 || Formato.ToUpper().IndexOf("MM") >= 0 || Formato.ToUpper().IndexOf("YY") >= 0)
            {
                try
                {
                    DateTime campoFec = Convert.ToDateTime(ValorDato);
                    {
                        Formato = Formato.Replace("D", "d");
                        Formato = Formato.Replace("Y", "y");
                        return campoFec.ToString(Formato);
                    }
                }
                catch { }
            }
            return ValorDato;
        }
        static private string RegresaForma(string forma)
        {
                if (forma.Length == 0) return "";
                int i;
                string Formax = "";
            try
            {
                if (forma.Substring(0, 1) == "&" | forma.IndexOf("Barra_") >= 0) return forma;
                for (i = 0; i < forma.Length; i++)
                {
                    if (Formax.Substring(i, 1) == "C") { Formax += Formax + ","; }
                    else { Formax += forma.Substring(i, 1); }
                }
            }
            catch { Formax = forma; }
            return Formax;
        }

    }
}

