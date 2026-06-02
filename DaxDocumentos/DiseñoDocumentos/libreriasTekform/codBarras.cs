using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace libreriasTekform
{
    public class codBarras
    {
        public static void registraBarras(string Aimprimir, string FORMATO, Int32 Ancho, Int32 alto, Int32 Currenty, Int32 Posicion, Int32 Largoimprimible, ref iTextSharp.text.Document docmtoPdf)
        {
            byte[] bytes = (byte[])(new ImageConverter()).ConvertTo(GenerarCodigoBarras(Aimprimir, FORMATO, Ancho, alto, Currenty, Posicion, Largoimprimible), typeof(byte[]));
            iTextSharp.text.Rectangle rr = new iTextSharp.text.Rectangle(libreriasTekform.leerDefinicionFormato.PixelAptos(Ancho), libreriasTekform.leerDefinicionFormato.PixelAptos(alto));
            iTextSharp.text.Image imagen = iTextSharp.text.Image.GetInstance(bytes);
            imagen.ScaleAbsoluteWidth(libreriasTekform.leerDefinicionFormato.PixelAptos(Ancho));
            imagen.ScaleAbsoluteHeight(libreriasTekform.leerDefinicionFormato.PixelAptos(alto));//'escala al tamaño de la imagen
            imagen.SetAbsolutePosition(Posicion, Largoimprimible - Currenty - alto);                                        //'posición en la que se inserta. 40 (de izquierda a derecha). 500 (de abajo hacia arriba)
            docmtoPdf.Add(imagen);

        }
        public static void registraBarras(string Aimprimir, string FORMATO, Int32 Ancho, Int32 alto, Int32 Currenty, Int32 Posicion, Int32 Largoimprimible, ref Graphics e)
        {
            Image imagen = GenerarCodigoBarras(Aimprimir, FORMATO, Ancho, alto, Currenty, Posicion, Largoimprimible);
            e.DrawImage(imagen ,Posicion,Currenty,Ancho,alto);
        }
        private static Image GenerarCodigoBarras(string Aimprimir, string FORMATO, Int32 Ancho, Int32 alto, Int32 Currenty, Int32 Posicion, Int32 Largoimprimible)
        {
            Image imagen=null;
            BarcodeLib.Barcode codBarras = new BarcodeLib.Barcode();
            int W = Ancho/15;
            int H = alto/15;

            codBarras.Alignment = BarcodeLib.AlignmentPositions.CENTER;

            BarcodeLib.TYPE type = BarcodeLib.TYPE.UNSPECIFIED;
            switch (FORMATO)
            {
                case "UPC-A": type = BarcodeLib.TYPE.UPCA; break;
                case "UPC-E": type = BarcodeLib.TYPE.UPCE; break;
                case "UPC 2 Digit Ext.": type = BarcodeLib.TYPE.UPC_SUPPLEMENTAL_2DIGIT; break;
                case "UPC 5 Digit Ext.": type = BarcodeLib.TYPE.UPC_SUPPLEMENTAL_5DIGIT; break;
                case "Barra_Ean-13": type = BarcodeLib.TYPE.EAN13; break;
                case "JAN-13": type = BarcodeLib.TYPE.JAN13; break;
                case "Barra_Ean-8": type = BarcodeLib.TYPE.EAN8; break;
                case "ITF-14": type = BarcodeLib.TYPE.ITF14; break;
                case "Codabar": type = BarcodeLib.TYPE.Codabar; break;
                case "PostNet": type = BarcodeLib.TYPE.PostNet; break;
                case "Bookland/ISBN": type = BarcodeLib.TYPE.BOOKLAND; break;
                case "Code 11": type = BarcodeLib.TYPE.CODE11; break;
                case "Barra_Code39": type = BarcodeLib.TYPE.CODE39; break;
                case "Code 39 Extended": type = BarcodeLib.TYPE.CODE39Extended; break;
                case "Code 39 Mod 43": type = BarcodeLib.TYPE.CODE39_Mod43; break;
                case "Code 93": type = BarcodeLib.TYPE.CODE93; break;
                case "LOGMARS": type = BarcodeLib.TYPE.LOGMARS; break;
                case "MSI": type = BarcodeLib.TYPE.MSI_Mod10; break;
                case "Interleaved 2 of 5": type = BarcodeLib.TYPE.Interleaved2of5; break;
                case "Standard 2 of 5": type = BarcodeLib.TYPE.Standard2of5; break;
                case "Barra_Ean-128": type = BarcodeLib.TYPE.CODE128; break;
                case "Code 128-A": type = BarcodeLib.TYPE.CODE128A; break;
                case "Code 128-B": type = BarcodeLib.TYPE.CODE128B; break;
                case "Code 128-C": type = BarcodeLib.TYPE.CODE128C; break;
                case "Telepen": type = BarcodeLib.TYPE.TELEPEN; break;
                case "FIM": type = BarcodeLib.TYPE.FIM; break;
                case "Pharmacode": type = BarcodeLib.TYPE.PHARMACODE; break;
                default: type = BarcodeLib.TYPE.CODE39; break;
            }

            try
            {
                if (type != BarcodeLib.TYPE.UNSPECIFIED)
                {
                    try
                    {
                        codBarras.BarWidth = 20;//0 < 1 ? null : (int?)Convert.ToInt32(textBoxBarWidth.Text.Trim());
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Unable to parse BarWidth: " + ex.Message, ex);
                    }
                    try
                    {
                        codBarras.AspectRatio = 20; // textBoxAspectRatio.Text.Trim().Length < 1 ? null : (double?)Convert.ToDouble(textBoxAspectRatio.Text.Trim());
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Unable to parse AspectRatio: " + ex.Message, ex);
                    }

                    codBarras.IncludeLabel = false; // this.chkGenerateLabel.Checked;
                    codBarras.LabelPosition = BarcodeLib.LabelPositions.BOTTOMCENTER;
                    imagen = codBarras.Encode(type, Aimprimir, Color.Black, Color.White, Ancho, alto);
                    
                    //===== Encoding performed here =====
                    //byte[] bytes = (byte[])(new ImageConverter()).ConvertTo(codBarras.Encode(type, Aimprimir, Color.Black, Color.White, Ancho , alto ), typeof(byte[]));
                    //iTextSharp.text.Rectangle rr = new iTextSharp.text.Rectangle(libreriasTekform.leerDefinicionFormato.PixelAptos(Ancho), libreriasTekform.leerDefinicionFormato.PixelAptos(alto));
                    //iTextSharp.text.Image imagen = iTextSharp.text.Image.GetInstance(bytes);
                    //imagen.ScaleAbsoluteWidth(libreriasTekform.leerDefinicionFormato.PixelAptos(Ancho));
                    //imagen.ScaleAbsoluteHeight(libreriasTekform.leerDefinicionFormato.PixelAptos(alto));//'escala al tamaño de la imagen
                    //imagen.SetAbsolutePosition(Posicion, Largoimprimible - Currenty - alto);                                        //'posición en la que se inserta. 40 (de izquierda a derecha). 500 (de abajo hacia arriba)
                    //docmtoPdf.Add(imagen);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo genrar el codigo de barras: " + ex.Message, ex);
            }
            return imagen;
        }
    }
}
