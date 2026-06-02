
using System.Net.Mail;
using System.Net.Mime;
using System.Data;
using System.Data.SqlClient;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;
using System;
using System.Drawing;
using libreriasTekform;

namespace documentosPdf
{
    public class generacionPdfCons
    { 
        string strConxAdcom ="";
        string strConxIvaret="";        
        string strConxDaxsys="";
        string strConxDaxpro="";
        string PathServer = "";
        GenDatos GenDato;
        Int32 codEmpresa = 0;
                
        DataTable Consulta = new DataTable();
        DataTable Syscod = new DataTable();


       //int ConsultaStatus = 0;  // 0 tabla no leida 1 tabla leida y con datos 2 tabla leida sin datos
        string[] ImpText;
        int Currenty = 0;
        int Currentx = 0;
        Int32 Largoimprimible = 0;
        Int32 Anchoimprimible = 0;

        string FormaImpresionDocumento = "";
        propiedadesForma propiedForma = new propiedadesForma();
        camposForma campForma = new camposForma();
        DataTable datosForma = new DataTable();

        Document docmtoPdf;
        PdfWriter grabadorPdf;
        PdfContentByte contenedorPdf;
        int paginaActual=0;
         //int nroMaximoLineasConsecutivas = 0; // nromáximo de lineas consecutivas a imprimir en datos con varias lineas de impresion seguidas

        public generacionPdfCons(string strSys,string strConxdax, int codEmp, string pathServer)
        {
            strConxDaxsys = strSys;
            strConxAdcom = strConxdax;
            GenDato = new GenDatos(strConxDaxsys);
            PathServer = pathServer;
            codEmpresa = codEmp;
        }
        public string GeneraConPdf(DataTable ConsultaOrg, string nombreDocumento = "", string QueSystema = "", string formatoImprime="", string AuxManual = "")
        {
            if (ConsultaOrg.Rows.Count == 0) return "ERROR : NO EXISTEN DATOS PARA GENERAR PDF";
            nombreDocumento = ExtensionDocumento.NombrePdf(nombreDocumento);
            Consulta = ConsultaOrg;
            FormaImpresionDocumento = formatoImprime;
            string resp = prepararGeneracion();
            if (( resp + "   ").Substring(0, 3) == "ERR") return resp;
            if (AuxManual.Length > 0) ImpText = AuxManual.Split(Convert.ToChar(";"));

            iTextSharp.text.Rectangle rectanglo = new iTextSharp.text.Rectangle(Anchoimprimible,Largoimprimible);
            docmtoPdf = new Document(rectanglo ,0,0,0,0);
            grabadorPdf = PdfWriter.GetInstance(docmtoPdf, new FileStream(nombreDocumento, FileMode.Create, FileAccess.Write, FileShare.None));
            grabadorPdf.AddViewerPreference(PdfName.PICKTRAYBYPDFSIZE, PdfBoolean.PDFTRUE);
            contenedorPdf = new PdfContentByte(grabadorPdf);
            Largoimprimible = Convert.ToInt32(docmtoPdf.PageSize.Height);
            Anchoimprimible = Convert.ToInt32(docmtoPdf.PageSize.Width);
            docmtoPdf.Open();
            contenedorPdf = grabadorPdf.DirectContent;
            paginaActual = 1;
            string fontAnt = "";

            for (int nroPagina = 0; nroPagina < paginaActual; nroPagina++)
            {
                docmtoPdf.NewPage();

                //  iTextSharp.text.pdf.BaseFont Ffont = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE).BaseFont; 

                iTextSharp.text.pdf.BaseFont Ffont = FontFactory.GetFont(FontFactory.HELVETICA, campForma.FontSize).BaseFont;
                foreach (DataRow row in datosForma.Rows)
                {
                    leerDefinicionFormato.LeerLinea(row["l1"].ToString(), ref campForma,2.0,"");

                    Currenty = campForma.Ftop;
                    Currentx = campForma.FLeft;
                    fontAnt = campForma.FontNombre;

                    if (campForma.FHeight != 0 )
                    {
                        if (campForma.FontNombre != "0" && fontAnt != campForma.FontNombre)
                        {
                            try
                            {
                                string nombreFont=campForma.FontNombre;
                                if (campForma.FontNombre == "MS Sans Serif") nombreFont = "micross";
                                iTextSharp.text.Font fuenteArial = new iTextSharp.text.Font(BaseFont.CreateFont("c:/windows/fonts/"+nombreFont+".ttf", BaseFont.WINANSI, BaseFont.EMBEDDED), campForma.FontSize);
                                Ffont = fuenteArial.BaseFont;
                            }
                            catch
                            {
                                Ffont = FontFactory.GetFont(FontFactory.HELVETICA, campForma.FontSize).BaseFont;
                            }
                            fontAnt = campForma.FontNombre;

                            //Ffont = FontFactory.GetFont(campForma.FontNombre, campForma.FontSize, BaseColor.BLACK).BaseFont;
                            //if (Ffont == null) Ffont = FontFactory.GetFont(FontFactory.HELVETICA, campForma.FontSize).BaseFont;
                        }
                        //campForma.FHeight -= 2;

                        iTextSharp.text.Font ff = new iTextSharp.text.Font(Ffont, campForma.FontSize);
                        ff.SetStyle(iTextSharp.text.Font.NORMAL); ;
                        if (campForma.FontSubrayada == 1) ff.SetStyle(iTextSharp.text.Font.UNDERLINE); 
                        if (campForma.FontItalica == 1) ff.SetStyle(iTextSharp.text.Font.ITALIC); 
                        if (campForma.FontEnNegrita == 1) ff.SetStyle(iTextSharp.text.Font.BOLD);
                        Ffont = ff.BaseFont;

                        if (campForma.Tipo == "E") { ImprimeEtiqueta(campForma.Valor, Currentx, contenedorPdf, Ffont); }
                        else if (campForma.Tipo == "11") { ImprimeDato(DatoGeneral(campForma.Valor), campForma.ALineacion, campForma.formato, campForma.FWidth, Currentx, contenedorPdf, campForma.FHeight, Ffont); }
                        else if (campForma.Tipo == "L") { ImprimeLinea(Currentx, campForma.Ftop, campForma.FWidth, campForma.FHeight, campForma.ALineacion, contenedorPdf); }
                        else if (campForma.Tipo == "I") { ImprimeImagen(campForma.Valor, Currentx, campForma.Ftop, campForma.FWidth, campForma.FHeight, contenedorPdf); }
                        else if (campForma.Tipo == "C") { ImprimeCuadrado(Currentx, campForma.Ftop, campForma.FWidth, campForma.FHeight, campForma.ALineacion, contenedorPdf); }
                        else { manejarDatosBases(nroPagina,campForma.Valor, campForma.ALineacion, campForma.formato, campForma.FWidth, Currentx, contenedorPdf, campForma.FHeight, Ffont); }
                    }                }                
            }
            grabadorPdf.Flush();
            //grabadorPdf.Close();
            docmtoPdf.CloseDocument();
            docmtoPdf.Close();
            return nombreDocumento;
        }
        private void manejarDatosBases(int nroPagina,string Campo, Int32 Alineacion, string FORMATO, Int32 Ancho, Int32 Posicion, PdfContentByte cb, Int32 alto , iTextSharp.text.pdf.BaseFont fuente)
        {
            libreriasTekform.leerBasesDatos lectorDatos = new leerBasesDatos();
            DataTable tablaDatos = new DataTable();
            string nomCampoDato = GenDato.QueCampo(Campo);
            string AuxImp =""; 
            Boolean esDatoUnico=true;
            
            if (nomCampoDato=="") return;

            if (Consulta.Rows.Count == 0)
            {
                //ConsultaStatus = 2;
                return;
            }
            paginaActual = CalcularMultihoja(FormaImpresionDocumento, strConxAdcom);            
            //ConsultaStatus = 1;
            tablaDatos = Consulta;
            esDatoUnico = false;
            if (tablaDatos.Rows.Count == 0) return;

            Currenty = campForma.Ftop;
            Currentx = campForma.FLeft;                        

            if (esDatoUnico)
                {
                    AuxImp = tablaDatos.Rows[0][nomCampoDato].ToString();
                    ImprimeDato(AuxImp, campForma.ALineacion, campForma.formato, campForma.FWidth, Currentx, cb, campForma.FHeight, fuente); 
                }
            else
            {
                if (campForma.Numlineas == 0 && campForma.NumColumnas == 0)
                {
                    double TotalCampo = 0;
                    foreach(DataRow row in tablaDatos.Rows)
                    {                        
                        try { TotalCampo += Convert.ToDouble(row[nomCampoDato]); }
                        catch { TotalCampo += 0;};
                    }
                    ImprimeDato(TotalCampo.ToString(), campForma.ALineacion, campForma.formato, campForma.FWidth, Currentx, cb, campForma.FHeight, fuente);
                }
                else
                {
                    Int32 NumlineasAimprimir = campForma.Numlineas;
                    Int32 lineaInicial = (NumlineasAimprimir * nroPagina) ;
                    for (int i = lineaInicial; i < tablaDatos.Rows.Count;i++)
                    {
                        if (NumlineasAimprimir > 0 && Currenty + alto <= Largoimprimible)
                        {
                            try { AuxImp = tablaDatos.Rows[i][nomCampoDato].ToString(); }
                            catch { AuxImp = ""; }
                            if (AuxImp != "")
                            {
                                ImprimeDato(AuxImp, campForma.ALineacion, campForma.formato, campForma.FWidth, Currentx, cb, campForma.FHeight, fuente);
                            }
                            else
                            {
                                Currenty += alto;
                            }

                            NumlineasAimprimir -= 1;
                        }
                        else { break; }
                    }
                }            
            }
        }                                      
        private string prepararGeneracion()
        {
                       
            if (FormaImpresionDocumento.Length == 0) return "ERROR: SIN FORMATO DEFINIDO";
            string SSQQL = "select * from sysforms where l0='" + FormaImpresionDocumento.Trim() + "' order by S1, L1 ";
            SqlDataAdapter da = new SqlDataAdapter(SSQQL, strConxAdcom);
            da.Fill(datosForma);
            if (datosForma.Rows.Count == 0) return "ERROR: NO EXISTE EL FORMATO DEL FORMULARIO " + FormaImpresionDocumento;
            leerDefinicionFormato.LeerPropiedades(datosForma.Rows[0]["l1"].ToString(), ref propiedForma);

               Int32 AnchoHoja = Convert.ToInt32 (((propiedForma.APapel / 567) / 2.54) * 100);
               Int32 AltoHoja = Convert.ToInt32(((propiedForma.Lpapel / 567) / 2.54) * 100);

               Largoimprimible = AltoHoja; // - .Margins.Top - .Margins.Bottom
               Anchoimprimible = AnchoHoja;//.PaperSize.Width - .Margins.Left - .Margins.Right               
            return "";
        }

        private void ImprimeLinea(Int32 PuntoX1, Int32 PuntoY1, Int32 PuntoX2, Int32 PuntoY2, Int32 AnchoLinea, PdfContentByte cb)
        {            
            cb.SetLineWidth(Convert.ToInt64(AnchoLinea));
            cb.MoveTo(PuntoX1, Largoimprimible - PuntoY1);
            cb.LineTo(PuntoX2, Largoimprimible - PuntoY2);
            cb.Stroke();
        }
        private void ImprimeCuadrado(Int32 PuntoX, Int32 PuntoY, Int32 AnchoCuadrado, Int32 AltoCuadrado,Int32 AnchoLinea, PdfContentByte cb)
        {
            cb.SetLineWidth(Convert.ToInt64 (AnchoLinea));
            cb.Rectangle(PuntoX, Largoimprimible - PuntoY - AltoCuadrado , AnchoCuadrado, AltoCuadrado);
            cb.Stroke();
        }
        private void ImprimeImagen(string nomImagen, Int32 PuntoX, Int32 PuntoY, Int32 AnchoImagen, Int32 AltoImagen, PdfContentByte cb)
        {
            try
            {
                iTextSharp.text.Image imagen = iTextSharp.text.Image.GetInstance(PathServer + "bin\\imagenes\\" + nomImagen);       //'nombre y ruta de la imagen a insertar
                imagen.ScaleToFit(AnchoImagen, AltoImagen);                                                     //'escala al tamaño de la imagen
                imagen.SetAbsolutePosition(PuntoX,  Largoimprimible - PuntoY - AltoImagen);                                        //'posición en la que se inserta. 40 (de izquierda a derecha). 500 (de abajo hacia arriba)
                docmtoPdf.Add(imagen);
            }
            catch { }
        }

        public void ImprimeDato(string Campo, Int32 Alineacion, string FORMATO, Int32 Ancho, Int32 Posicion, PdfContentByte contenedorPdf, Int32 alto, iTextSharp.text.pdf.BaseFont fuente)
        {
            leerBasesDatos leeVal = new leerBasesDatos();
            string Aimprimir = Campo;
            Boolean tieneBarras = false;
            Int32 LineaInicial = Currenty;
            string conDecimal = "S";
            decimal valorDecimal = 0;
            string Derecha = "";
            Int32 Largo = 0;
            Int32 AnchoCar = FORMATO.Length;
            float width = 0;
            float height = 0;
            try
            {
                width = fuente.GetWidthPoint("M", campForma.FontSize);
                height = fuente.GetAscentPoint("I", campForma.FontSize) - fuente.GetDescentPoint("I", campForma.FontSize);
            }
            catch { }
                
            if (alto == 0) alto = Convert.ToInt32(height);
            if (alto >= height * 2) AnchoCar = AnchoCar * 2;

            if (Campo == "." || Campo.Length == 0) { Currenty += alto; return; }

            try { valorDecimal = Convert.ToDecimal(Campo); }
            catch { };
            if (FORMATO.Length > 0)
            {
                FORMATO=RegresaForma(FORMATO);
                try
                {
                    if ((FORMATO + "       ").Substring(0, 6) == "Barra_")
                    { 
                        tieneBarras = true; 
                    }
                    else if (FORMATO.IndexOf("ValorEnLetras") >= 0) 
                    {
                        Aimprimir = libreriasTekform.NumLetra.Cnl(ref valorDecimal, ref conDecimal);
                        if (FORMATO.Trim().Length > 13) Aimprimir = Aimprimir +  FORMATO.Substring(13, 1);
                    }
                    else
                    {
                        Largo = FORMATO.Length;
                        Derecha = FORMATO.Substring(Largo - 1, 1);
                        if (Derecha != "")
                        {
                            if (Derecha == "B")
                            {
                                FORMATO = FORMATO.Substring(0, Largo - 1);
                                if (valorDecimal == 0)
                                {
                                    Aimprimir = "";
                                }
                                else
                                {
                                    Aimprimir = aplicarFormato(Campo, FORMATO);
                                }
                            }
                            else if (Derecha == "*" || Derecha == "=")
                            {
                                FORMATO = FORMATO.Substring(0, Largo - 1);
                                Aimprimir = aplicarFormato(Campo, FORMATO);
                                if (Alineacion == 0)   // left
                                {
                                    Aimprimir += new string(Convert.ToChar(Derecha), AnchoCar - Aimprimir.Length);
                                }
                                else if (Alineacion == 2)    //right
                                {
                                    Aimprimir = new String(Convert.ToChar(Derecha), AnchoCar - (Aimprimir.Trim().Length)) + Aimprimir;
                                }
                            }
                            else
                            {
                                Aimprimir = aplicarFormato(Campo, FORMATO);
                            }
                        }
                        else
                        {
                            Aimprimir = aplicarFormato(Campo, FORMATO);
                        }
                    }
                }
                catch
                {
                    //("Formato invalido para el dato " & Campo & " formato " & FORMATO & vbCr & ex.Message);
                }
            }
            else
            {
                Aimprimir = Campo;
            }

            if (tieneBarras )
            {
                codBarras.registraBarras(Aimprimir, FORMATO, Ancho, alto, Currenty, Posicion, Largoimprimible,ref docmtoPdf);                
            }
            else if (Aimprimir.Length != 0)
            {
                //iTextSharp.text.Font ff = new iTextSharp.text.Font(fuente, campForma.FontSize);
                //ff.SetStyle(iTextSharp.text.Font.NORMAL); ;
                //if (campForma.FU == 1) ff.SetStyle(iTextSharp.text.Font.UNDERLINE); 
                //if (campForma.FI == 1) ff.SetStyle(iTextSharp.text.Font.ITALIC); 
                //if (campForma.FB == 1) ff.SetStyle(iTextSharp.text.Font.BOLD);

                contenedorPdf.SetFontAndSize(fuente, campForma.FontSize);
                contenedorPdf.BeginText();
                contenedorPdf.ShowTextAligned(PdfContentByte.ALIGN_LEFT, Aimprimir, campForma.FLeft, Largoimprimible - (Currenty + campForma.FHeight - 2), 0); //, Largoimprimible - Currenty);

                //Paragraph parrafo = new Paragraph(1,Aimprimir,ff);
                //iTextSharp.text.Rectangle rectglo = new iTextSharp.text.Rectangle(campForma.FLeft, Largoimprimible - (Currenty + campForma.FHeight), campForma.FLeft + campForma.FWidth,  Largoimprimible - (Currenty )); //  x1,y1   x2,y2
                //ColumnText colum = new ColumnText(contenedorPdf);
                //colum.SetSimpleColumn(rectglo);
                //if (Alineacion == 0) colum.Alignment = 0;
                //else if (Alineacion == 1) colum.Alignment = 2;
                //else if (Alineacion == 2) colum.Alignment = 1;
                //colum.AddText(parrafo);
                //colum.Go();
                contenedorPdf.EndText();
            }        
            Currenty += alto;
        }

        public void ImprimeEtiqueta(string Aimprimir, Int32 Posicion, PdfContentByte contenedorPdf, iTextSharp.text.pdf.BaseFont fuente)
        {            

                contenedorPdf.SetFontAndSize(fuente , campForma.FontSize);
                contenedorPdf.BeginText();
                contenedorPdf.ShowTextAligned(PdfContentByte.ALIGN_LEFT, Aimprimir, campForma.FLeft, Largoimprimible - (Currenty + campForma.FHeight-2), 0); //, Largoimprimible - Currenty);

                //ColumnText colum = new ColumnText(contenedorPdf);
                //colum.SetSimpleColumn(campForma.FLeft, Largoimprimible - (Currenty + campForma.FHeight), campForma.FLeft + campForma.FWidth, Largoimprimible - Currenty);
                //Paragraph parrafo = new Paragraph(new Phrase(20, Aimprimir, ff));                
                ////colum.Alignment = 0;
                //colum.AddText(parrafo);
                //colum.Go();
                contenedorPdf.EndText();
        }

        private string DatoGeneral( string dato) 
        {
            if (dato == null) return "";
            if (dato.Length < 2) return "";
            string datGen = dato.Substring(1);
            Int32 datNum = 0;

            if (datGen == "DOC_fechaHoy" || datGen == "9001") { return DateTime.Now.ToShortDateString(); }
            else if (datGen == "DOC_HoraActual" || datGen == "9002") { return DateTime.Now.ToShortTimeString(); }

            try { datNum = Convert.ToInt32(datGen); }
            catch{datNum=0;}
            if( datNum < 9821 && datNum > 9800) return  ImpText[datNum - 9801];
            return "";
        }

        public string aplicarFormato(string Campo, string Formato) 
        {
               //string tipo  = "";
                double campoNum = 0;
                DateTime campoFec=new DateTime(1900,1,1);
                try {
                        campoNum = Convert.ToDouble(Campo);
                        if ( Formato.IndexOf("##") >= 0 || Formato.IndexOf("00") >= 0) return campoNum.ToString(Formato);                        
                    }catch{}
                try {
                        campoFec = Convert.ToDateTime(Campo);
                        if (Formato.ToUpper().IndexOf("DD") >= 0 || Formato.ToUpper().IndexOf("MM") >= 0 || Formato.ToUpper().IndexOf("YY") >= 0) 
                        {
                            Formato = Formato.Replace("D", "d");
                            Formato = Formato.Replace("Y", "y");
                            return campoFec.ToString(Formato);
                        }
                    }catch {}
                return "";                
                //     AdcSettings.GrabarOpcionHis(StrConxSysemp10, "Impresiondocumentos", "Aplicar formato a campos", CONEMP.EmpresaAct.Sistema, Err.Description, Campo, Formato)
        }
        private String RegresaForma(string forma)
        {
            string aux="";
            for (int i = 0;i<forma.Length;i++)
            {
                if (forma.Substring(i, 1) == "C") aux += ",";
                else aux += forma.Substring(i, 1);
            }
            return aux;
        }
        private string queBaseConsulta(Int32  tipoBase )
        {
            if (tipoBase == 4) return strConxDaxpro;
            else if (tipoBase == 3) return strConxIvaret;
            return strConxAdcom;
        }
        private Int32 CalcularMultihoja(string Formatoimprime,string StrConxAdcom10)
        {
            int nroRenglones=0;
            int cuantasPaginas = 1;
            string SSQQL = "select * from sysforms where l0='" + FormaImpresionDocumento.Trim()  + "' and S1 = 'D' order BY L1 ";
            string[] campos;
            int numlin = 0;
            int Tipo = 0;
            try
            {
                if (Consulta.Rows.Count > nroRenglones) nroRenglones = Consulta.Rows.Count;
            }
            catch {}
            SqlConnection  conn = new SqlConnection(StrConxAdcom10);
            conn.Open();
            SqlDataReader rs;
            SqlCommand comm = new SqlCommand(SSQQL, conn);
            rs = comm.ExecuteReader();

            if (rs.Read()) 
            {
                while (rs.Read())
                {
                    campos = rs["l1"].ToString().Split ( Convert.ToChar(";"));
                    if (Val(campos[0]) < 10){Tipo = Convert.ToInt16 (Val(campos[0]));}
                    else {Tipo = Convert.ToInt16 (Val(campos[1]));}                    
                    if (Tipo == 2 | Tipo == 4 |Tipo == 14 | Tipo == 7) if (Val(campos[13]) > numlin) numlin = Convert.ToInt16 (Val(campos[13]));
                } 
            }
        
            if (numlin > 0) 
            {
                cuantasPaginas = nroRenglones / numlin;
                if (nroRenglones > (cuantasPaginas * numlin)) cuantasPaginas += 1;
            }
            if (cuantasPaginas == 0 ) cuantasPaginas = 1;
            return cuantasPaginas;
        }
        private double Val(string valor)
        {
            double aux =0;
            try{ aux= Convert.ToDouble (valor);}catch{}
            return aux;
        }
   }
}
