
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
    public class generacionPdf
    {
        string strConxAdcom ="";
        string strConxIvaret="";        
        string strConxDaxsys="";
        string strConxDaxpro="";
        string PathServer = "";
        sesSys.OpcDoc opDoc;
        GenDatos GenDato;
        Int32 codEmpresa = 0;
                
        DataTable Consulta = new DataTable();
        DataTable Documento = new DataTable();
        DataTable Beneficiario = new DataTable();
        DataTable SucursalR = new DataTable();
        DataTable Bodega = new DataTable();
        DataTable Banco = new DataTable();
        DataTable Retenciones = new DataTable();
        DataTable Renglones = new DataTable();
        DataTable Sumatorias = new DataTable();
        DataTable pagos = new DataTable();
        DataTable RsCuotas = new DataTable();
        DataTable Vendedor = new DataTable();
        DataTable Contabilidad = new DataTable();
        DataTable Tallas = new DataTable();
        DataTable Series = new DataTable();
        DataTable Syscod = new DataTable();


        int ConsultaStatus = 0;  // 0 tabla no leida 1 tabla leida y con datos 2 tabla leida sin datos
        int DocumentoStatus = 0;
        int BeneficiarioStatus = 0;
        int SucursalRStatus = 0;
        int BodegaStatus = 0;
        int BancoStatus = 0;
        int RetencionesStatus = 0;
        int RenglonesStatus = 0;
        int SumatoriasStatus = 0;
        int pagosStatus = 0;
        int RsCuotasStatus = 0;
        int VendedorStatus = 0;
        int ContabilidadStatus = 0;
        int TallasStatus = 0;
        int SeriesStatus = 0;
        int SyscodStatus = 0;

        int datosConsultaLinImpresa = 0;  // Nro de linea impresa
        int DocumentoLinImpresa = 0;
        int BeneficiarioLinImpresa = 0;
        int SucursalRLinImpresa = 0;
        int BodegaLinImpresa = 0;
        int BancoLinImpresa = 0;
        int RetencionesLinImpresa = 0;
        int RenglonesLinImpresa = 0;
        int SumatoriasLinImpresa = 0;
        int pagosLinImpresa = 0;
        int RsCuotasLinImpresa = 0;
        int VendedorLinImpresa = 0;
        int ContabilidadLinImpresa = 0;
        int TallasLinImpresa = 0;
        int SeriesLinImpresa = 0;
        int SyscodLinImpresa = 0;
                
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
        string NombreBaseIvaret = "";
        ClassDoc.idDocumento idDocumento = new ClassDoc.idDocumento();
        //string docSuc="";
        //string docTip="";
        //string docNUm="";
        //double idClaveDoc=0;

         int paginaActual=0;
         int nroMaximoLineasConsecutivas = 0; // nromácsimo de lineas consecutivas a imprimir en datos con varias lineas de impresion seguidas

        public generacionPdf(string NomBasIvaret,string strAdc, string strSri, string strSys, string strPro, int codEmp, string pathServer)
        {
            NombreBaseIvaret = NomBasIvaret;
            strConxAdcom = strAdc;
            strConxDaxpro = strPro;
            strConxDaxsys = strSys;
            strConxIvaret = strSri;
            GenDato = new GenDatos(strConxDaxsys);
            PathServer = pathServer;
            codEmpresa = codEmp;
        }
        public string GeneraDocPdf( ClassDoc.idDocumento idDoc, string nombreDocumento = "", string QueSystema = "", string formatoImprime="", string AuxManual = "")
        {            
         
            opDoc = new sesSys.OpcDoc();
            opDoc.Cargar(ref idDoc.familia, ref idDoc.Sucursal);
            if (formatoImprime.Length > 0) { FormaImpresionDocumento = formatoImprime; } else { FormaImpresionDocumento = opDoc.ImprimirForm; }
            if ((prepararGeneracion() + "   ").Substring(0, 3) == "ERR") return "";
            idDocumento = idDoc;
            
            if (AuxManual.Length > 0) ImpText = AuxManual.Split(Convert.ToChar(";"));
           
            docmtoPdf = new Document(new iTextSharp.text.Rectangle(Anchoimprimible, Largoimprimible));            
//            Largoimprimible = Convert.ToInt32(docmtoPdf.PageSize.Height);
//            Anchoimprimible = Convert.ToInt32(docmtoPdf.PageSize.Width);
            grabadorPdf = PdfWriter.GetInstance(docmtoPdf, new FileStream(nombreDocumento, FileMode.Create, FileAccess.Write, FileShare.None));
            grabadorPdf.AddViewerPreference(PdfName.PICKTRAYBYPDFSIZE, PdfBoolean.PDFTRUE);
            contenedorPdf = new PdfContentByte(grabadorPdf);
            docmtoPdf.Open();
            contenedorPdf = grabadorPdf.DirectContent;
            paginaActual = 1;
            
            //iTextSharp.text.Font fuenteSserif;
            //try
            //{
            //    fuenteSserif = new iTextSharp.text.Font(BaseFont.CreateFont("c:/windows/fonts/micross.ttf", BaseFont.WINANSI, BaseFont.EMBEDDED));
            //}
            //catch {fuenteSserif = null; };
            string fontAnt = "";

            for (int nroPagina = 0; nroPagina < paginaActual; nroPagina++)
            {
                docmtoPdf.NewPage();

                //  iTextSharp.text.pdf.BaseFont Ffont = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE).BaseFont; 

                iTextSharp.text.pdf.BaseFont Ffont = FontFactory.GetFont(FontFactory.HELVETICA, campForma.FontSize).BaseFont;
                foreach (DataRow row in datosForma.Rows)
                {
                    if (row["S1"].ToString() != "A")
                    {
                        leerDefinicionFormato.LeerLineaPdf(row["l1"].ToString(), ref campForma);

                        Currenty = campForma.Ftop;
                        Currentx = campForma.FLeft;
                        fontAnt = campForma.FontNombre;

                        if (campForma.FHeight != 0)
                        {
                            if (campForma.FontNombre != "0" && fontAnt != campForma.FontNombre)
                            {
                                try
                                {
                                    string nombreFont = campForma.FontNombre ;
                                    if (campForma.FontNombre == "MS Sans Serif") nombreFont = "micross";
                                    iTextSharp.text.Font fuenteArial = new iTextSharp.text.Font(BaseFont.CreateFont("c:/windows/fonts/" + nombreFont + ".ttf", BaseFont.WINANSI, BaseFont.EMBEDDED), campForma.FontSize);
                                    Ffont = fuenteArial.BaseFont;
                                }
                                catch
                                {
                                    Ffont = FontFactory.GetFont(FontFactory.HELVETICA, campForma.FontSize).BaseFont;
                                }
                                fontAnt = campForma.FontTipo ;

                                //Ffont = FontFactory.GetFont(campForma.FN, campForma.FontSize, BaseColor.BLACK).BaseFont;
                                //if (Ffont == null) Ffont = FontFactory.GetFont(FontFactory.HELVETICA, campForma.FontSize).BaseFont;
                            }
                            //campForma.FHeight -= 2;

                            iTextSharp.text.Font ff = new iTextSharp.text.Font(Ffont, Convert.ToSingle(campForma.FontSize));
                            ff.SetStyle(iTextSharp.text.Font.NORMAL); ;
                            if (campForma.FontSubrayada  == 1) ff.SetStyle(iTextSharp.text.Font.UNDERLINE);
                            if (campForma.FontItalica  == 1) ff.SetStyle(iTextSharp.text.Font.ITALIC);
                            if (campForma.FontEnNegrita  == 1) ff.SetStyle(iTextSharp.text.Font.BOLD);
                            Ffont = ff.BaseFont;

                            if (campForma.Tipo == "L") { ImprimeLinea(Currentx, campForma.Ftop, campForma.FWidth, campForma.FHeight, campForma.ALineacion, contenedorPdf); }
                            else if (campForma.Tipo == "I") { ImprimeImagen(campForma.Valor, Currentx, campForma.Ftop, campForma.FWidth, campForma.FHeight, contenedorPdf); }
                            else if (campForma.Tipo == "C") { ImprimeCuadrado(Currentx, campForma.Ftop, campForma.FWidth, campForma.FHeight, campForma.ALineacion, contenedorPdf); }
                            else if (campForma.Tipo == "E") { ImprimeEtiqueta(campForma.Valor, Currentx, contenedorPdf, Ffont); }
                            else if (campForma.Tipo == "11") { ImprimeDato(DatoGeneral(campForma.Valor), campForma.ALineacion, campForma.formato, campForma.FWidth, Currentx, contenedorPdf, campForma.FHeight, Ffont); }
                            else { manejarDatosBases(nroPagina, campForma.Valor, campForma.ALineacion, campForma.formato, campForma.FWidth, Currentx, contenedorPdf, campForma.FHeight, Ffont); }
                        }
                    }
                }                
            }
            grabadorPdf.Flush();
            //grabadorPdf.Close();
            docmtoPdf.CloseDocument();
            docmtoPdf.Close();
            return nombreDocumento;
        }
        private void manejarDatosBases(int nroPagina,string Campo, Int32 Alineacion, string FORMATO, Int32 Ancho, Int32 Posicion, PdfContentByte cb, Int32 alto , iTextSharp.text.pdf.BaseFont fuente)
        {
            leerBasesDatos lectorDatos = new leerBasesDatos();
            DataTable tablaDatos = new DataTable();
            string nomCampoDato = GenDato.QueCampo(Campo);
            string AuxImp =""; 
            Boolean esDatoUnico=true;
            
            if (nomCampoDato=="") return;

            if (DocumentoStatus == 0)
            {
                lectorDatos.leerDocumento(strConxAdcom, idDocumento , "", "", ref Documento);
                if (Documento.Rows.Count < 1)
                {
                    DocumentoStatus = 2;
                    return;
                }
                DocumentoStatus = 1;
            }

            if (campForma.Tipo == "0")
            {
                if (BeneficiarioStatus == 0)
                {
                    lectorDatos.leerBeneficiario (strConxAdcom, Documento.Rows[0]["doc_codper"].ToString(), ref Beneficiario);
                    if (Beneficiario.Rows.Count < 1)
                    {
                        BeneficiarioStatus = 2;
                        return;
                    }
                    BeneficiarioStatus = 1;
                }
                esDatoUnico = true;
                tablaDatos = Beneficiario;
            }
            else if (campForma.Tipo == "1") 
            {
                if (DocumentoStatus == 0) 
                {
                    lectorDatos.leerDocumento(strConxAdcom, idDocumento, "", "", ref Documento);
                    if (Documento.Rows.Count < 1) 
                    {
                        DocumentoStatus=2;
                        return;
                    }
                    DocumentoStatus=1;
                }
                tablaDatos = Documento;
            }
            else if (campForma.Tipo == "2")
            {
                if (RenglonesStatus == 0)
                {
                    lectorDatos.leerRenglones(strConxAdcom, idDocumento, "", "", ref Renglones);
                    if (Renglones.Rows.Count == 0)
                    {
                        RenglonesStatus = 2;
                        return;
                    }
                    paginaActual = CalcularMultihoja(FormaImpresionDocumento, strConxAdcom);            
                    RenglonesStatus = 1;
                }
                tablaDatos = Renglones;
                esDatoUnico = false;
            }
            else if (campForma.Tipo == "3")
            {
                if (pagosStatus == 0)
                {
                    lectorDatos.leerPagos(strConxAdcom, NombreBaseIvaret, idDocumento, "", "", ref pagos);
                    if (pagos.Rows.Count == 0)
                    {
                        pagosStatus = 2;
                        return;
                    }
                    pagosStatus = 1;
                    esDatoUnico = false;
                }
                tablaDatos = pagos;
            }
            else if (campForma.Tipo == "4")
            {
                if (ContabilidadStatus == 0)
                {
                    lectorDatos.leerContabilidad(strConxAdcom, idDocumento, "", "", ref Contabilidad);
                    if (Contabilidad.Rows.Count == 0)
                    {
                        ContabilidadStatus = 2;
                        return;
                    }
                    paginaActual = CalcularMultihoja(FormaImpresionDocumento, strConxAdcom);
                    esDatoUnico = false;
                    ContabilidadStatus = 1;
                }
                esDatoUnico = false;
                tablaDatos = Contabilidad;
            }
            else if (campForma.Tipo == "7")
            {
                if (RetencionesStatus == 0)
                {
                    lectorDatos.leerRetenciones(strConxAdcom, idDocumento, "", "", ref Retenciones);
                    if (Retenciones.Rows.Count == 0)
                    {
                        RetencionesStatus = 2;
                        return;
                    }
                    paginaActual = CalcularMultihoja(FormaImpresionDocumento, strConxAdcom);            
                    RetencionesStatus = 1;
                }
                esDatoUnico = false;
                tablaDatos = Retenciones;
            }
            else if (campForma.Tipo == "8")
            {
                if (SucursalRStatus == 0)
                {
                    lectorDatos.leerSucursalR(strConxDaxsys, codEmpresa.ToString(), idDocumento.Sucursal , ref SucursalR);
                    if (SucursalR.Rows.Count == 0)
                    {
                        SucursalRStatus = 2;
                        return;
                    }
                    SucursalRStatus = 1;
                }
                tablaDatos = SucursalR;
            }
            else if (campForma.Tipo == "10")
            {
                if (BancoStatus == 0)
                {
                    lectorDatos.leerBanco(strConxAdcom, idDocumento,  Banco);
                    if (Banco.Rows.Count == 0)
                    {
                        BancoStatus = 2;
                        return;
                    }
                    BancoStatus = 1;
                }
                tablaDatos = Banco;
            }
            else if (campForma.Tipo == "12")
            {
                if (VendedorStatus == 0)
                {
                    lectorDatos.leerVendedor(strConxAdcom, Documento.Rows[0]["Doc_venabre"].ToString(), ref Vendedor);
                    if (Vendedor.Rows.Count == 0)
                    {   
                        VendedorStatus = 2;
                        return;
                    }
                    VendedorStatus = 1;
                }
                tablaDatos = Vendedor;
            }
            else if (campForma.Tipo == "14")
            {
                if (ConsultaStatus == 0)
                {
                    lectorDatos.leerConsulta(queBaseConsulta(propiedForma.BaseConsulta), idDocumento, ref Consulta, propiedForma.NombreConsulta);
                    if (Consulta.Rows.Count == 0)
                    {
                        ConsultaStatus = 2;
                        return;
                    }
                    paginaActual = CalcularMultihoja(FormaImpresionDocumento, strConxAdcom);            
                    ConsultaStatus = 1;
                }
                tablaDatos = Consulta;
                esDatoUnico = false;
            }
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
            
                    // craeación de fuentes arial, calibri y verdana
            //iTextSharp.text.Font Arial = new iTextSharp.text.Font(BaseFont.CreateFont("c:/windows/fonts/arial.ttf", BaseFont.WINANSI, BaseFont.EMBEDDED), 12);
            //iTextSharp.text.Font Calibri = new iTextSharp.text.Font(BaseFont.CreateFont("c:/windows/fonts/calibri.ttf", BaseFont.WINANSI, BaseFont.EMBEDDED), 12);
            //iTextSharp.text.Font Verdana = new iTextSharp.text.Font(BaseFont.CreateFont("c:/windows/fonts/verdana.ttf", BaseFont.WINANSI, BaseFont.EMBEDDED), 12);
            
            
            if (FormaImpresionDocumento.Length == 0) FormaImpresionDocumento  = opDoc.ImprimirForm;
            string SSQQL = "select * from sysforms where l0='" + FormaImpresionDocumento.Trim() + "' order by S1, L1 ";
            SqlDataAdapter da = new SqlDataAdapter(SSQQL, strConxAdcom);
            da.Fill(datosForma);
            if (datosForma.Rows.Count == 0) return "ERROR: NO EXISTE EL FORMATO DEL FORMULARIO " + FormaImpresionDocumento;
            leerDefinicionFormato.LeerPropiedades(datosForma.Rows[0]["l1"].ToString(), ref propiedForma);

               Anchoimprimible = Convert.ToInt32 ( libreriasTekform.leerDefinicionFormato.twipsAptos( propiedForma.APapel ));            //  /567) / 2.54) * 100);
               Largoimprimible = Convert.ToInt32(libreriasTekform.leerDefinicionFormato.twipsAptos(propiedForma.Lpapel)); // / 567) / 2.54) * 100);

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
            catch (Exception ex) { }
        }

        public void ImprimeDato(string Campo, Int32 Alineacion, string FORMATO, Int32 Ancho, Int32 Posicion, PdfContentByte contenedorPdf, Int32 alto, iTextSharp.text.pdf.BaseFont fuente)
        {
            
            leerBasesDatos leeVal = new leerBasesDatos();
            string Aimprimir = Campo;
            Boolean tieneBarras = false;
            Int32 LineaInicial = Currenty;
            string conDecimal = "S";
            decimal valorDecimal = 0;
            string TipoFormato = "";
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
                        Aimprimir = NumLetra.Cnl( valorDecimal, conDecimal);
                        if (FORMATO.Trim().Length > 13) Aimprimir = Aimprimir +  FORMATO.Substring(13, 1);
                    }
                    else
                    {
                        Largo = FORMATO.Length;
                        TipoFormato = FORMATO.Substring(Largo - 1, 1);
                        if (TipoFormato != "")
                        {
                            if (TipoFormato == "B")
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
                            else if (TipoFormato == "*" || TipoFormato == "=")
                            {
                                FORMATO = FORMATO.Substring(0, Largo - 1);
                                Aimprimir = aplicarFormato(Campo, FORMATO);
                                if (Alineacion == 0)   // left
                                {
                                    Aimprimir += new string(Convert.ToChar(TipoFormato), AnchoCar - Aimprimir.Length);
                                }
                                else if (Alineacion == 2)    //right
                                {
                                    Aimprimir = new String(Convert.ToChar(TipoFormato), AnchoCar - (Aimprimir.Trim().Length)) + Aimprimir;
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

                //contenedorPdf.BeginText();
                //contenedorPdf.SetFontAndSize(fuente, campForma.FontSize);
                //contenedorPdf.SetColorFill = (iTextSharp.text.BaseColor.BLUE)
                //contenedorPdf.ShowTextAligned(PdfContentByte.ALIGN_LEFT, Aimprimir, campForma.FLeft, Largoimprimible - (Currenty + campForma.FHeight - 2), 0); //, Largoimprimible - Currenty);
                //contenedorPdf.EndText();

                iTextSharp.text.Font fff = new iTextSharp.text.Font(fuente);
                fff.Size = campForma.FontSize;
                if (campForma.FontSubrayada == 1) fff.SetStyle(iTextSharp.text.Font.UNDERLINE);
                if (campForma.FontItalica == 1) fff.SetStyle(iTextSharp.text.Font.ITALIC);
                if (campForma.FontEnNegrita == 1) fff.SetStyle(iTextSharp.text.Font.BOLD);
                Paragraph parrafo = new Paragraph( 0,Aimprimir, fff);               
                
                //iTextSharp.text.Rectangle rectglo = new iTextShrp.text.Rectangle(campForma.FLeft, Largoimprimible - (Currenty + campForma.FHeight), campForma.FLeft + campForma.FWidth,  Largoimprimible - (Currenty )); //  x1,y1   x2,y2
                
                ColumnText colum = new ColumnText(contenedorPdf);
                colum.AdjustFirstLine = true;
                //colum.FilledWidth = campForma.FWidth;
                colum.SetLeading(6f,0.3f);
                colum.SetSimpleColumn(campForma.FLeft, Largoimprimible - (Currenty + campForma.FHeight * 2), campForma.FLeft + campForma.FWidth, Largoimprimible - (Currenty));
                if (Alineacion == 0) colum.Alignment = 0;
                else if (Alineacion == 1) colum.Alignment = 2;
                else if (Alineacion == 2) colum.Alignment = 1;
                colum.SetText(parrafo);
                colum.Go();
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
                if (Renglones.Rows.Count > nroRenglones) nroRenglones = Renglones.Rows.Count;
            }
            catch {}
            try
            {
                if (Contabilidad.Rows.Count > nroRenglones) nroRenglones = Contabilidad.Rows.Count;
            }
            catch {}
            try
            {
                if (Consulta.Rows.Count > nroRenglones) nroRenglones = Consulta.Rows.Count;
            }
            catch {}
            try
            {
                if (Retenciones.Rows.Count > nroRenglones) nroRenglones = Retenciones.Rows.Count;
            }
            catch { }
        
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
