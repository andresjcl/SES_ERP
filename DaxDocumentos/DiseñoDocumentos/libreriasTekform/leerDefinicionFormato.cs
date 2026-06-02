using libreriasTekform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace formatoImp
{
	public class leerDefinicionFormato
	{
        public static void LeerPropiedades(string TEXTO, ref propiedadesForma propForma)
        {
            TEXTO += ";0;0;0;0;0;0;0;0;0;0";
            string[] strArray = TEXTO.Split(Convert.ToChar(";"));
            if (strArray.Length == 0)
                return;
            propForma.APapel = Convert.ToInt32(strArray[0]);
            propForma.Lpapel = Convert.ToInt32(strArray[1]);
            try
            {
                propForma.NroCopias = Convert.ToInt32(strArray[2]);
            }
            catch
            {
                propForma.NroCopias = 1;
            }
            if (propForma.NroCopias == 0)
                propForma.NroCopias = 1;
            propForma.Acordeon = Convert.ToInt32(strArray[8]);
            for (int index = 0; index <= 3; ++index)
                propForma.CEsp[index] = Convert.ToInt32(strArray[index + 3]);
            propForma.MaqDin = Convert.ToByte(strArray[7]);
            propForma.DeSys = strArray[9].ToString();
            if (strArray.Length > 9)
            {
                propForma.NombreConsulta = strArray[10].ToString();
                try
                {
                    propForma.SiImprimeRegistros = Convert.ToBoolean(Convert.ToInt16(strArray[11]));
                }
                catch
                {
                }
                propForma.BaseConsulta = Convert.ToInt32(strArray[12]);
            }
            else
            {
                propForma.NombreConsulta = "";
                propForma.SiImprimeRegistros = Convert.ToBoolean(0);
                propForma.BaseConsulta = 0;
            }
            if (strArray.Length > 13)
            {
                propForma.DescripcionArchivo = strArray[13];
                propForma.EsMultihoja = Convert.ToInt32(strArray[14]);
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
            string[] strArray = TEXTO.Split(Convert.ToChar(";"));
            if (Convert.ToInt32(strArray[0]) < 10)
            {
                campForma.Tipo = strArray[0];
                campForma.Ftop = leerDefinicionFormato.twipsApixel(Convert.ToDouble(strArray[1]), DPI);
            }
            else
            {
                campForma.Ftop = leerDefinicionFormato.twipsApixel(Convert.ToDouble(strArray[0]), DPI);
                campForma.Tipo = strArray[1];
            }
            campForma.FLeft = leerDefinicionFormato.twipsApixel(Convert.ToDouble(strArray[2]), DPI);
            campForma.FHeight = leerDefinicionFormato.twipsApixel(Convert.ToDouble(strArray[3]), DPI);
            campForma.FWidth = leerDefinicionFormato.twipsApixel(Convert.ToDouble(strArray[4]), DPI);
            campForma.Valor = strArray[5];
            campForma.FontSize = Convert.ToSingle(strArray[6]);
            campForma.FontTipo = strArray[7];
            campForma.FontNombre = strArray[8];
            try
            {
                campForma.FontEnNegrita = Convert.ToByte(strArray[9]);
            }
            catch
            {
            }
            try
            {
                campForma.FontItalica = Convert.ToByte(strArray[10]);
            }
            catch
            {
            }
            try
            {
                campForma.FontSubrayada = Convert.ToByte(strArray[11]);
            }
            catch
            {
            }
            campForma.formato = leerDefinicionFormato.RegresaForma(strArray[12]);
            campForma.Numlineas = Convert.ToInt32(strArray[13]);
            try
            {
                campForma.ALineacion = Convert.ToByte(strArray[14]);
            }
            catch
            {
            }
            campForma.NumColumnas = Convert.ToInt32(strArray[15]);
            if (strArray.Length < 17)
                return;
            campForma.ImpSoloUltimaPag = Convert.ToByte("0" + strArray[16].ToString());
        }

        public static void LeerLineaPdf(string TEXTO, ref camposForma campForma)
        {
            TEXTO += ";;;;;";
            string[] strArray = TEXTO.Split(Convert.ToChar(";"));
            if (Convert.ToInt32(strArray[0]) < 10)
            {
                campForma.Tipo = strArray[0];
                campForma.Ftop = leerDefinicionFormato.twipsAptos((double)Convert.ToInt32(strArray[1]));
            }
            else
            {
                campForma.Ftop = leerDefinicionFormato.twipsAptos((double)Convert.ToInt32(strArray[0]));
                campForma.Tipo = strArray[1];
            }
            campForma.FLeft = leerDefinicionFormato.twipsAptos((double)Convert.ToInt32(strArray[2]));
            campForma.FHeight = leerDefinicionFormato.twipsAptos((double)Convert.ToInt32(strArray[3]));
            campForma.FWidth = leerDefinicionFormato.twipsAptos((double)Convert.ToInt32(strArray[4]));
            campForma.Valor = strArray[5];
            campForma.FontSize = Convert.ToSingle(strArray[6]);
            campForma.FontTipo = strArray[7];
            campForma.FontNombre = strArray[8];
            try
            {
                campForma.FontEnNegrita = Convert.ToByte(strArray[9]);
            }
            catch
            {
            }
            try
            {
                campForma.FontItalica = Convert.ToByte(strArray[10]);
            }
            catch
            {
            }
            try
            {
                campForma.FontSubrayada = Convert.ToByte(strArray[11]);
            }
            catch
            {
            }
            campForma.formato = leerDefinicionFormato.RegresaForma(strArray[12]);
            campForma.Numlineas = Convert.ToInt32("0" + strArray[13]);
            try
            {
                campForma.ALineacion = Convert.ToByte(strArray[14]);
            }
            catch
            {
            }
            campForma.NumColumnas = Convert.ToInt32("0" + strArray[15]);
            if (strArray.Length < 17)
                return;
            campForma.ImpSoloUltimaPag = Convert.ToByte("0" + strArray[16].ToString());
        }

        private static int twipsApixel(double tw, double DPI) => DPI != 0.0 ? Convert.ToInt32(tw / 1440.0 * DPI) : Convert.ToInt32(tw / 15.0);

        private static string RegresaForma(string forma)
        {
            string str1 = "";
            string str2 = forma;
            for (int startIndex = 0; startIndex < str2.Length; ++startIndex)
                str1 = !(str2.Substring(startIndex, 1) == "C") ? str1 + str2.Substring(startIndex, 1) : str1 + ",";
            return str1;
        }

        public static string[] SepararImpAuxiliar(ref string TEXTO) => TEXTO.Split(Convert.ToChar(";"));

        public static int cmAptos(double cm) => Convert.ToInt32(cm * 28.3465);

        public static int twipsAptos(double twip) => Convert.ToInt32(twip / 20.0);

        public static int PixelAptos(double Pixl) => Convert.ToInt32(Pixl / 1.3333);
    }
}

