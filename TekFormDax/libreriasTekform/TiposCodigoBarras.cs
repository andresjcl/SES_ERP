using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BarcodeLib;

namespace libreriasTekform
{
    public class TiposCodigoBarras
    {
        public static BarcodeLib.TYPE Type(string NombreTipo)
        {
            if(NombreTipo.Substring(0,6)=="Barra_") NombreTipo = NombreTipo.Substring(6);
            TYPE ibarcode;
            switch (NombreTipo)
            {
                case "UCC12":
                case "UPCA": //Encode_UPCA();
                    ibarcode = TYPE.UPCA;
                    break;
                case "UCC13":
                case "EAN13": //Encode_EAN13();
                    ibarcode = TYPE.EAN13;
                    break;
                case "Interleaved2of5": //Encode_Interleaved2of5();
                    ibarcode = TYPE.Interleaved2of5;
                    break;
                case "Industrial2of5":
                case "Standard2of5": //Encode_Standard2of5();
                    ibarcode = TYPE.Standard2of5;
                    break;
                case "LOGMARS":
                case "CODE39": //Encode_Code39();
                    ibarcode = TYPE.CODE39;
                    break;
                case "CODE39Extended":
                    ibarcode = TYPE.CODE39;
                    break;
                case "CODE39_Mod43":
                    ibarcode = TYPE.CODE39;
                    break;
                case "Codabar": //Encode_Codabar();
                    ibarcode = TYPE.Codabar;
                    break;
                case "PostNet": //Encode_PostNet();
                    ibarcode = TYPE.PostNet;
                    break;
                case "ISBN":
                case "BOOKLAND": //Encode_ISBN_Bookland();
                    ibarcode = TYPE.ISBN;
                    break;
                case "JAN13": //Encode_JAN13();
                    ibarcode = TYPE.JAN13;
                    break;
                case "UPC_SUPPLEMENTAL_2DIGIT": //Encode_UPCSupplemental_2();
                    ibarcode = TYPE.UPC_SUPPLEMENTAL_2DIGIT;
                    break;
                case "MSI_Mod10":
                    ibarcode = TYPE.MSI_Mod10;
                    break;
                case "MSI_2Mod10":
                    ibarcode = TYPE.MSI_2Mod10;
                    break;
                case "MSI_Mod11":
                    ibarcode = TYPE.MSI_Mod11;
                    break;
                case "MSI_Mod11_Mod10":
                    ibarcode = TYPE.MSI_Mod11_Mod10;
                    break;
                case "Modified_Plessey": //Encode_MSI();
                    ibarcode = TYPE.Modified_Plessey;
                    break;
                case "UPC_SUPPLEMENTAL_5DIGIT": //Encode_UPCSupplemental_5();
                    ibarcode = TYPE.UPC_SUPPLEMENTAL_5DIGIT;
                    break;
                case "UPCE": //Encode_UPCE();
                    ibarcode = TYPE.UPCE;
                    break;
                case "EAN8": //Encode_EAN8();
                    ibarcode = TYPE.EAN8;
                    break;
                case "USD8":
                case "CODE11": //Encode_Code11();
                    ibarcode = TYPE.CODE11;
                    break;
                case "CODE128": //Encode_Code128();
                    ibarcode = TYPE.CODE128;
                    break;
                case "CODE128A":
                    ibarcode = TYPE.CODE128A;
                    break;
                case "CODE128B":
                    ibarcode = TYPE.CODE128B;
                    break;
                case "CODE128C":
                    ibarcode = TYPE.CODE128C;
                    break;
                case "ITF14":
                    ibarcode = TYPE.ITF14;
                    break;
                case "CODE93":
                    ibarcode = TYPE.CODE93;
                    break;
                case "TELEPEN":
                    ibarcode = TYPE.TELEPEN;
                    break;
                case "FIM":
                    ibarcode = TYPE.FIM;
                    break;
                case "PHARMACODE":
                    ibarcode = TYPE.PHARMACODE;
                    break;

                default:
                    ibarcode = TYPE.CODE128;
                    break;
            }//switch
            return ibarcode;
        }
    }
}
