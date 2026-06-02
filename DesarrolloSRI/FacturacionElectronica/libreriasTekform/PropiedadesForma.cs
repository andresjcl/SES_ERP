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

namespace libreriasTekform
{
    public class propiedadesForma
    {
        public Int32 APapel = 0;
        public Int32 Lpapel = 0;
        public Int32 NroCopias = 0;
        public Int32 Acordeon = 0;
        public Int32[] CEsp = new Int32[5];
        public byte MaqDin = 0;
        public string DeSys = "";
        public string NombreConsulta = "";
        public bool SiImprimeRegistros = false;
        public Int32 BaseConsulta;
        public string DescripcionArchivo = "";
        public Int32 EsMultihoja = 0;
    }
public class camposForma
{
    public string Tipo = "";
    public Int32 Ftop = 0;
    public Int32 FLeft = 0;
    public Int32 FHeight = 0;
    public Int32 FWidth = 0;
    public string Valor = "";
    public Single FontSize = 0;
    public string FontTipo = "";
    public string FontNombre = "";
    public byte FontEnNegrita = 0;
    public byte FontItalica = 0;
    public byte FontSubrayada = 0;
    public string formato = "";
    public Int32 Numlineas = 0;
    public byte ALineacion = 0;
    public Int32 NumColumnas = 0;
    public byte ImpSoloUltimaPag = 0;
}

public class leerDefinicionFormato
{
    public static void LeerPropiedades(string TEXTO, ref propiedadesForma propForma)
    {        
        int i;
        TEXTO += ";0;0;0;0;0;0;0;0;0;0";
        string[] TextVal = TEXTO.Split(Convert.ToChar(";"));
        if (TextVal.Length == 0) return;
        propForma.APapel = System.Convert.ToInt32((TextVal[0]));
        propForma.Lpapel = System.Convert.ToInt32((TextVal[1]));
        try
        {
            propForma.NroCopias = System.Convert.ToInt32(TextVal[2]);
        }
        catch { propForma.NroCopias = 1; }
        if (propForma.NroCopias == 0) propForma.NroCopias = 1; 
        
        propForma.Acordeon = System.Convert.ToInt32((TextVal[8]));

        for (i = 0; i <= 3; i++)
        {
            propForma.CEsp[i] = System.Convert.ToInt32((TextVal[i + 3]));
        }
        propForma.MaqDin = System.Convert.ToByte((TextVal[7]));
        propForma.DeSys = TextVal[9].ToString();

        if (TextVal.Length > 9)
        {
            propForma.NombreConsulta = TextVal[10].ToString();
            try
            {
                propForma.SiImprimeRegistros = System.Convert.ToBoolean(Convert.ToInt16 (TextVal[11]));
            }
            catch { }
            propForma.BaseConsulta = System.Convert.ToInt32((TextVal[12]));
        }
        else
        {
            propForma.NombreConsulta = "";
            propForma.SiImprimeRegistros = System.Convert.ToBoolean(0);
            propForma.BaseConsulta = 0;
        }

        if (TextVal.Length > 13)
        {
            propForma.DescripcionArchivo = TextVal[13];
            propForma.EsMultihoja = System.Convert.ToInt32(TextVal[14]);
        }
        else
        {
            propForma.DescripcionArchivo = "";
            propForma.EsMultihoja = 0;
        }
    }

    public static void LeerLinea(string TEXTO, ref camposForma campForma, double DPI)
    {
        TEXTO += ";0;0;0;0;0;0;0;0;0;0";
        string[] TextVal = TEXTO.Split(Convert.ToChar(";"));
        if (Convert.ToInt32(TextVal[0]) < 10)
        {
            campForma.Tipo = TextVal[0];
            campForma.Ftop = twipsApixel(System.Convert.ToDouble((TextVal[1])), DPI);
        }
        else
        {
            campForma.Ftop = twipsApixel(System.Convert.ToDouble((TextVal[0])), DPI);
            campForma.Tipo = TextVal[1];
        }
        campForma.FLeft = twipsApixel(System.Convert.ToDouble((TextVal[2])), DPI);
        campForma.FHeight = twipsApixel(System.Convert.ToDouble((TextVal[3])), DPI);
        campForma.FWidth = twipsApixel(System.Convert.ToDouble((TextVal[4])), DPI);
        campForma.Valor = TextVal[5];
        campForma.FontSize = System.Convert.ToSingle (TextVal[6]);
        campForma.FontTipo = TextVal[7];
        campForma.FontNombre = TextVal[8];
        try
        {
            campForma.FontEnNegrita = System.Convert.ToByte((TextVal[9]));
        }
        catch { }
        try
        {
            campForma.FontItalica = System.Convert.ToByte((TextVal[10]));
        }
        catch { }
        try
        {
            campForma.FontSubrayada = System.Convert.ToByte((TextVal[11]));
        }
        catch { }
        campForma.formato = RegresaForma(TextVal[12]);
        campForma.Numlineas = System.Convert.ToInt32((TextVal[13]));
        try
        {
            campForma.ALineacion = System.Convert.ToByte((TextVal[14]));
        }catch{ }
        campForma.NumColumnas = System.Convert.ToInt32((TextVal[15]));
        if (TextVal.Length < 17) return;
        campForma.ImpSoloUltimaPag = System.Convert.ToByte("0" + TextVal[16].ToString());
    }

    public static void LeerLineaPdf(string TEXTO, ref camposForma campForma)
    {
        TEXTO += ";;;;;";
        string[] TextVal = TEXTO.Split(Convert.ToChar(";"));
        if (Convert.ToInt32(TextVal[0]) < 10)
        {
            campForma.Tipo = TextVal[0];
            campForma.Ftop = twipsAptos(Convert.ToInt32(TextVal[1]));
        }
        else
        {
            campForma.Ftop = twipsAptos(System.Convert.ToInt32(TextVal[0]));
            campForma.Tipo = TextVal[1];
        }
        campForma.FLeft = twipsAptos(System.Convert.ToInt32(TextVal[2]));
        campForma.FHeight = twipsAptos(System.Convert.ToInt32(TextVal[3]));
        campForma.FWidth = twipsAptos(System.Convert.ToInt32(TextVal[4]));
        campForma.Valor = TextVal[5];
        campForma.FontSize = System.Convert.ToSingle(TextVal[6]);
        campForma.FontTipo = TextVal[7];
        campForma.FontNombre = TextVal[8];
        try
        {
            campForma.FontEnNegrita = System.Convert.ToByte((TextVal[9]));
        }
        catch { }
        try
        {
            campForma.FontItalica = System.Convert.ToByte((TextVal[10]));
        }
        catch { }
        try
        {
            campForma.FontSubrayada = System.Convert.ToByte((TextVal[11]));
        }
        catch { }
        
        campForma.formato = RegresaForma(TextVal[12]);
        campForma.Numlineas = System.Convert.ToInt32(("0"+TextVal[13]));
        try
        {
            campForma.ALineacion = System.Convert.ToByte((TextVal[14]));
        }
        catch { }
        campForma.NumColumnas = System.Convert.ToInt32(("0"+TextVal[15]));
        if (TextVal.Length < 17) return;
        campForma.ImpSoloUltimaPag = System.Convert.ToByte("0" + TextVal[16].ToString());
    }
    private static int twipsApixel(double tw, double DPI)
    {
        Int32 resul = 0;
        if ((DPI == 0))
            resul = System.Convert.ToInt32(tw / 15);
        else
            resul = System.Convert.ToInt32((tw / 1440) * DPI);
        return resul;
    }

    // Private Shared Function twipsApixel(ByVal tw As Integer) As Integer 'transformar medidas de vb6 a vbnet
    // twipsApixel = CInt(tw / 512)
    // End Function

    private static string RegresaForma(string forma)
    {
        string resp = "";
        int i;
        string Formax = forma;        
        for (i = 0; i < Formax.Length; i++)
        {
            if (Formax.Substring(i, 1) == "C")
                resp +=  ",";
            else
                resp += Formax.Substring(i, 1);
        }
        return resp;
    }
    public static string[] SepararImpAuxiliar(ref string TEXTO)
    {
        return TEXTO.Split (Convert.ToChar( ";"));
    }

    public static Int32 cmAptos(double cm) 
    {
        return  Convert.ToInt32 (cm * 28.3465);
    }
    public static Int32 twipsAptos(double twip )
    {
        return Convert.ToInt32 ( twip / 20);  // aumento5para ajustar al formato del tekform
    }
    public static Int32 PixelAptos(double Pixl)
    {
        return Convert.ToInt32(Pixl / 1.3333);
    }
        
    //'1 ptos 1.3333 pix
    //'72 ptos  1 pulg
    //'1 cm 37.7953 pix
    //'1 twip   0.05 puntos
    //'1 punto = 20 twips
    //'1 twip 0.0667 pixels
    //'1 cm  28.3465 ptos
    //'1 cm  566.9291 twips



}

}
