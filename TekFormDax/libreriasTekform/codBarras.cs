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
            Font ffont = new Font("Arial", 7);
            Color fcolor = Color.Black;
            byte[] bytes = (byte[])(new ImageConverter().ConvertTo(GenerarCodigoBarras(Aimprimir, FORMATO, Ancho, alto, Currenty, Posicion, Largoimprimible,ffont ,fcolor ), typeof(byte[])));
            iTextSharp.text.Rectangle rr = new iTextSharp.text.Rectangle(libreriasTekform.leerDefinicionFormato.PixelAptos(Ancho), libreriasTekform.leerDefinicionFormato.PixelAptos(alto));
            iTextSharp.text.Image imagen = iTextSharp.text.Image.GetInstance(bytes,false);
            imagen.ScaleAbsoluteWidth(libreriasTekform.leerDefinicionFormato.PixelAptos(Ancho));
            imagen.ScaleAbsoluteHeight(libreriasTekform.leerDefinicionFormato.PixelAptos(alto));//'escala al tamaño de la imagen
            imagen.SetAbsolutePosition(Posicion, Largoimprimible - Currenty - alto);                                        //'posición en la que se inserta. 40 (de izquierda a derecha). 500 (de abajo hacia arriba)
            docmtoPdf.Add(imagen);
        }
        public static void registraBarras(string Aimprimir, string FORMATO, Int32 Ancho, Int32 alto, Int32 Currenty, Int32 Posicion, Int32 Largoimprimible, ref Graphics e)
        {
            Font ffont = new Font("Arial", 7);
            Color fcolor = Color.Black;
            Image imagen = GenerarCodigoBarras(Aimprimir, FORMATO, Ancho, alto, Currenty, Posicion, Largoimprimible,ffont,fcolor );
            e.DrawImage(imagen ,Posicion,Currenty,Ancho,alto);
        }
        public static void registraBarras(string Aimprimir, string FORMATO, Int32 Ancho, Int32 alto, Int32 Currenty, Int32 Posicion, Int32 Largoimprimible, ref Graphics e, Font ffont, Color FColor)
        {
            Image imagen = GenerarCodigoBarras(Aimprimir, FORMATO, Ancho, alto, Currenty, Posicion, Largoimprimible,ffont,Color.Black);
            e.DrawImage(imagen, Posicion, Currenty, Ancho, alto);
        }
        private static Image GenerarCodigoBarras(string Aimprimir, string FORMATO, Int32 Ancho, Int32 alto, Int32 Currenty, Int32 Posicion, Int32 Largoimprimible,Font ffont,Color Fcolor)
        {
            Image imagen=null;
            BarcodeLib.Barcode codBarras = new BarcodeLib.Barcode();            
            
            codBarras.Alignment = BarcodeLib.AlignmentPositions.CENTER;
            BarcodeLib.TYPE type = TiposCodigoBarras.Type(FORMATO);

            try
            {
                if (type != BarcodeLib.TYPE.UNSPECIFIED)
                {
                    try
                    {
                        codBarras.BarWidth = Ancho;//0 < 1 ? null : (int?)Convert.ToInt32(textBoxBarWidth.Text.Trim());
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

                    codBarras.LabelFont = ffont;
                    codBarras.ForeColor = Fcolor;
                    codBarras.IncludeLabel = false; // this.chkGenerateLabel.Checked;
                    codBarras.LabelPosition = BarcodeLib.LabelPositions.BOTTOMCENTER;
                    
                    imagen = codBarras.Encode(type, Aimprimir, Ancho, alto);                    
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo generar el codigo de barras: " + ex.Message, ex);
            }
            return imagen;
        }
    }
}
