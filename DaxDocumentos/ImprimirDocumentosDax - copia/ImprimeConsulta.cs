using libreriasTekform;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Collections.Generic;
using DattCom;
namespace ImpresionDocumentosDax
{
    public partial class ImprimeConsulta : Form
    {
        private string FormaImpresionDocumento;
        //sesSys.OpcDoc PropiedadesDoc = new sesSys.OpcDoc();
        GenDatos GenDato;
        DataTable Consulta = new DataTable();
        string versionTekform = "";
        int ConsultaStatus = 0;  // 0 tabla no leida 1 tabla leida y con datos 2 tabla leida sin datos

        int Currenty = 0;
        int Currentx = 0;
        Int32 Largoimprimible = 0;
        Int32 Anchoimprimible = 0;
        string[] FormasAimprimir;

        propiedadesForma propiedForma = new propiedadesForma();
        camposForma camposFormato = new camposForma();
        DataTable datosForma = new DataTable();
        //string NombreBaseIvaret = "";
        ClassDoc.idDocumento IdDocumento = new ClassDoc.idDocumento();

        Font Ffont = new Font("Arial", Convert.ToSingle(9.75), FontStyle.Regular);

        //private bool[] SaltaTitulosLinea = new bool[2];
        //private string codAnteriorTitulosLinea = "";
        Int32 IniciaBorrado = 0;
        Int32 UltimaLinea = 0;
        //Int32 BorraLineas = 1;

        //List<ClassDoc.idDocumento> coleccionDocs;
        //Boolean esMultiple = false;
        //Boolean ImprimeFormatoContable = false;
        //String ImprimeOtroFormato = "";

        private bool impresionIniciada = false;
        //private string TablaTra = "ADCTRA";
        //private string TablaDoc = "ADCDOC";
        private int nroHoja=0;        

        public ImprimeConsulta(string Consulta, string BaseDatos, string Formato )
        {
            InitializeComponent();
            GenDato = new GenDatos(datosEmpresa.strConIniSis);
            FormasAimprimir = new string[2];
            FormasAimprimir[0]= Formato;
        }
        //private void inicializacion(Boolean IMprimeCtb, string OtraImpresion)
        //{
        //    string lugar = "";
        //    try
        //    {
        //        if (PropiedadesDoc == null)
        //        {
        //            PropiedadesDoc = new sesSys.OpcDoc();
        //            PropiedadesDoc.Cargar(ref IdDocumento.Tipo, ref lugar);
        //        }
        //    }
        //    catch
        //    {
        //        PropiedadesDoc = new sesSys.OpcDoc();
        //        PropiedadesDoc.Cargar(ref IdDocumento.Tipo, ref lugar);

        //    }
        //    TablaDoc = PropiedadesDoc.tablaDatosDoc;
        //    TablaTra = PropiedadesDoc.tablaDatosTra;
        //    FormasAimprimir = Reglas.QueFormatoImprime(PropiedadesDoc, IMprimeCtb, OtraImpresion);
        //}
        private bool leerPropiedadesFormato()
        {
            bool resp = true;

            string ssql = "select * from sysforms where l0='" + FormaImpresionDocumento.Trim() + "' and s1 = 'A'";
            DataTable dt =  DattCom.SqlDatos.leerTablaAdcom(ssql);

            if (dt.Rows.Count == 0)
            {
                resp = false;
            }
            else
            {
                leerDefinicionFormato.LeerPropiedades(dt.Rows[0]["l1"].ToString(), ref propiedForma);
            }
            return resp;
        }
        private string PrepararGeneracion(bool EsPrevisual)
        {
            if (leerPropiedadesFormato() == false) return "ERROR: NO EXISTE LA PLANTILLA PARA IMPRESION " + FormaImpresionDocumento;

            string SSQQL = "select * from sysforms where s1 <> 'A' and l0='" + FormaImpresionDocumento.Trim() + "' order by L1 ";
            datosForma = DattCom.SqlDatos.leerTablaAdcom(SSQQL);
            try
            {
                versionTekform = datosForma.Rows[0]["version"].ToString();
            }
            catch { }

            PrepararBasesDeLineas();
            LimitesForma.CalcularLimites(0, 0, Consulta.Rows.Count, 0, datosForma,(propiedForma.Acordeon==1));



            if (EsPrevisual == false) { PrintDocument1.DefaultPageSettings.PrinterSettings.Copies = Convert.ToInt16(propiedForma.NroCopias); }
            Anchoimprimible = System.Convert.ToInt32(((propiedForma.APapel / (double)567) / 2.54) * 100);            //  /567) / 2.54) * 100);
            Largoimprimible = System.Convert.ToInt32(((propiedForma.Lpapel / (double)567) / 2.54) * 100);
            PaperSize TamañoPapel = new PaperSize();
            TamañoPapel = new PaperSize("A4", Anchoimprimible, Largoimprimible);
            TamañoPapel.PaperName = System.Convert.ToString(System.Drawing.Printing.PaperKind.A4);
            TamañoPapel.Width = Anchoimprimible;
            TamañoPapel.Height = Largoimprimible;
            {
                PrintDocument1.DefaultPageSettings.PaperSize = TamañoPapel;
                PrintDocument1.DefaultPageSettings.Margins.Bottom = 0;
                PrintDocument1.DefaultPageSettings.Margins.Top = 0;
                PrintDocument1.DefaultPageSettings.Margins.Left = 0;
                PrintDocument1.DefaultPageSettings.Margins.Right = 0;
            }

            nroHoja = 0;
            UltimaLinea = 0;
            //BorraLineas = 1;
            IniciaBorrado = 0;
            return "OKK";
        }

        private void PrepararBasesDeLineas()
        {
            leerBasesDatos lectorDatos = new leerBasesDatos();
            try
            {
                ConsultaStatus = lectorDatos.leerConsulta(queBaseConsulta(propiedForma.BaseConsulta), IdDocumento, ref Consulta, propiedForma.NombreConsulta);
            }catch {}
        }


        private void FImprimeDocumento_FormClosed(System.Object eventSender, System.Windows.Forms.FormClosedEventArgs eventArgs)
        {
            this.Dispose();
        }

        private void CancelButton_Renamed_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            this.Close();
        }
        private void BtnPropiedadesImpresora_Click(System.Object sender, System.EventArgs e)
        {
            PageSetupDialog1.PageSettings = PrintDocument1.DefaultPageSettings;
            PageSetupDialog1.ShowDialog();
            PrintDocument1.DefaultPageSettings = PageSetupDialog1.PageSettings;
        }
        private void BtnImprimir_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
                ImprimirDocumento(false);
        }
        private void BtnPrevisual_Click(System.Object sender, System.EventArgs e)
        {
            ImprimirDocumento(true);
        }

        private void ImprimirDocumento(bool EsPrevisual)
        {
            impresionIniciada = false;
            for (int imp = 0; imp < FormasAimprimir.Length; imp++)
            {
                string[] queForma = FormasAimprimir[imp].Split(Convert.ToChar(","));
                if (queForma.Length > 0 && queForma[0].Length > 0)
                {
                    FormaImpresionDocumento = queForma[0];
                    if (queForma.Length > 1)
                    {
                        if (queForma[1].Length > 0)
                        {
                            PrintDocument1.DefaultPageSettings.PrinterSettings.PrinterName = queForma[1];
                        }
                    }
                    string auxx = PrepararGeneracion(EsPrevisual);
                    if (auxx.Substring(0, 3) == "ERR") { return; }

                    if (EsPrevisual == true )
                    {
                        PrintPreviewDialog1.Document = PrintDocument1;
                        PrintPreviewDialog1.ShowDialog();
                    }
                    else
                    {
                        PrintDocument1.DefaultPageSettings.PrinterSettings.Copies = System.Convert.ToInt16(propiedForma.NroCopias);
                        try
                        {
                            PrintDocument1.Print();
                        }
                        catch { MensajeImpresora();}
                    }
                }
            }
            Close();
        }

        private void printDocument1_PrintPage(System.Object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (impresionIniciada == false)
            {
                impresionIniciada = true;
                //ActivarCajaDinero(ref propiedForma.CajaDinero, propiedForma.MaqDin, propiedForma.CEsp);
            }            

            //for (int nroPagina = 0; nroPagina < PaginasAimprimir; nroPagina++)
            //{
                foreach (DataRow row in datosForma.Rows)
                {
                    if (row["S1"].ToString() != "A")
                    {
                        leerDefinicionFormato.LeerLinea(row["l1"].ToString(), ref camposFormato, 0,versionTekform);
                    
                        if (camposFormato.FHeight != 0)
                        {
                            Currenty = camposFormato.Ftop;
                            Currentx = camposFormato.FLeft;

                            if (propiedForma.Acordeon > 0 && LimitesForma.LinIniciaRenglones > 0 && camposFormato.Ftop > LimitesForma.LinIniciaRenglones)
                            {
                                Currenty += LimitesForma.EspacioDeRenglones;
                            }

                        if (camposFormato.Tipo == "L") { ImprimeLinea(Currentx, Currenty, camposFormato.FWidth, camposFormato.FHeight, camposFormato.ALineacion, e.Graphics); }
                            else if (camposFormato.Tipo == "C") { ImprimeCuadrado(Currentx, Currenty, camposFormato.FWidth, camposFormato.FHeight, camposFormato.ALineacion, e.Graphics); }
                            else if (camposFormato.Tipo == "I") { ImprimeImagen(camposFormato.Valor, Currentx, Currenty, camposFormato.FWidth, camposFormato.FHeight, e.Graphics); }
                            else if (camposFormato.Tipo == "E") { TipoDeLetra(); ImprimeEtiqueta(camposFormato.Valor, Currentx,Currenty, e.Graphics, Ffont); }
                            else { TipoDeLetra(); manejarDatosBases(nroHoja, camposFormato.Valor, camposFormato.ALineacion, camposFormato.formato, camposFormato.FWidth, Currentx, e.Graphics, camposFormato.FHeight, Ffont); }
                        }
                    }
                }
            //}
            //if (((propiedForma.EsMultihoja == 1) & (lineasTotal * nroHoja < nroRenglones)))
            nroHoja++;
            if (propiedForma.EsMultihoja == 1 & nroHoja < LimitesForma.cuantasPáginas)
                e.HasMorePages = true;
            else
                e.HasMorePages = false;
        }
        private void TipoDeLetra()
        {
            FontStyle st = FontStyle.Regular;
            if (camposFormato.FontSize == 0) camposFormato.FontSize = 9;
            if (camposFormato.FontEnNegrita == 1) st = FontStyle.Bold;
            if (camposFormato.FontItalica == 1) st = FontStyle.Italic;
            if (camposFormato.FontSubrayada == 1) st = FontStyle.Underline;
            Ffont = new System.Drawing.Font(camposFormato.FontNombre, camposFormato.FontSize, st); // System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic Or System.Drawing.FontStyle.Underline Or System.Drawing.FontStyle.Regular)
            st = FontStyle.Bold;
            //Nfont = new System.Drawing.Font(camposFormato.FontNombre, camposFormato.FontSize, st);
        }
        private void manejarDatosBases(int nroPagina, string Campo, Int32 Alineacion, string FORMATO, Int32 Ancho, Int32 Posicion, Graphics e, Int32 alto, Font fuente)
        {
            if (Campo == "") return;
            string nomCampoDato = GenDato.QueCampo(Campo);
            string AuxImp = "";
            //Boolean esDatoUnico = true;
            if (nomCampoDato == "") return;

            leerBasesDatos lectorDatos = new leerBasesDatos();
            DataTable tablaDatos = new DataTable();

                //if (ConsultaStatus == 0) ConsultaStatus = lectorDatos.leerConsulta(queBaseConsulta(propiedForma.BaseConsulta), IdDocumento, ref Consulta, propiedForma.NombreConsulta);
                //{
                //    if (ConsultaStatus == 2) return;
                //    PaginasAimprimir = CalcularMultihoja(FormaImpresionDocumento, strConxAdcom);
                //}
                tablaDatos = Consulta;
                //esDatoUnico = false;
                //esLinea = true;
                if (tablaDatos.Rows.Count == 0) return;
                if (camposFormato.Numlineas == 0 && camposFormato.NumColumnas == 0)
                {
                    double TotalCampo = 0;
                    foreach (DataRow row in tablaDatos.Rows)
                    {
                        try { TotalCampo += Convert.ToDouble(row[nomCampoDato]); }
                        catch { TotalCampo += 0; };
                    }
                    ImprimirDatos.ImprimeDato(ref Currenty, Largoimprimible, TotalCampo.ToString(), camposFormato.ALineacion, camposFormato.formato, camposFormato.FWidth, Currentx, e, camposFormato.FHeight, fuente);
                }
                else
                {
                    Int32 NumlineasAimprimir = camposFormato.Numlineas;
                    Int32 lineaInicial = (NumlineasAimprimir * nroPagina);
                    for (int i = lineaInicial; i < tablaDatos.Rows.Count; i++)
                    {
                        if (NumlineasAimprimir > 0 && Currenty + alto <= Largoimprimible)
                        {
                            if (propiedForma.Acordeon == 1 && IniciaBorrado == 0) IniciaBorrado = Currenty;
                            try { AuxImp = tablaDatos.Rows[i][nomCampoDato].ToString(); }
                            catch { AuxImp = ""; }
                            if (AuxImp != "")
                            {
                                ImprimirDatos.ImprimeDato(ref Currenty, Largoimprimible, AuxImp, camposFormato.ALineacion, camposFormato.formato, camposFormato.FWidth, Currentx, e, camposFormato.FHeight, fuente);
                            }
                            else
                            {
                                Currenty += alto;
                            }
                            NumlineasAimprimir -= 1;
                            if (propiedForma.Acordeon == 1 && Currenty > UltimaLinea) UltimaLinea = Currenty;
                        }
                        else { break; }
                    }
            }
        }

        private void ImprimeLinea(Int32 PuntoX1, Int32 PuntoY1, Int32 PuntoX2, Int32 PuntoY2, Int32 AnchoLinea, Graphics e)
        {
            if (AnchoLinea < 1) AnchoLinea = 1;
            Pen Penn = new Pen(Color.Black , AnchoLinea);
            e.DrawLine(Penn, PuntoX1, PuntoY1, PuntoX2, PuntoY2);
        }
        private void ImprimeCuadrado(Int32 PuntoX, Int32 PuntoY, Int32 AnchoCuadrado, Int32 AltoCuadrado, Int32 AnchoLinea, Graphics e)
        {
            if (AnchoLinea < 1) AnchoLinea = 1;
            Pen Penn = new Pen(Color.Black , AnchoLinea);
            e.DrawRectangle(Penn, PuntoX, PuntoY, AnchoCuadrado, AltoCuadrado);
        }
        private void ImprimeImagen(string nomImagen, Int32 PuntoX, Int32 PuntoY, Int32 AnchoImagen, Int32 AltoImagen, Graphics e)
        {
            try
            {
                e.DrawImage(System.Drawing.Image.FromFile(datosEmpresa.pathServer  + "bin\\imagenes\\" + nomImagen), PuntoX, PuntoY, AnchoImagen, AltoImagen);
            }
            catch { }
        }


        private void ImprimeEtiqueta(string Aimprimir, Int32 Posicion,Int32 Currenty, Graphics e, System.Drawing.Font fuente)
        {
            e.DrawString(Aimprimir, fuente,Brushes.Black, Posicion, Currenty);
        }
        private string aplicarFormato(string Campo, string Formato)
        {
            //string tipo  = "";
            double campoNum = 0;
            DateTime campoFec = new DateTime(1900, 1, 1);
            try
            {
                campoNum = Convert.ToDouble(Campo);
                if (Formato.IndexOf("##") >= 0 || Formato.IndexOf("00") >= 0) return campoNum.ToString(Formato);
            }
            catch { }
            try
            {
                campoFec = Convert.ToDateTime(Campo);
                if (Formato.ToUpper().IndexOf("DD") >= 0 || Formato.ToUpper().IndexOf("MM") >= 0 || Formato.ToUpper().IndexOf("YY") >= 0)
                {
                    Formato = Formato.Replace("D", "d");
                    Formato = Formato.Replace("Y", "y");
                    return campoFec.ToString(Formato);
                }
            }
            catch { }
            return "";
            //     AdcSettings.GrabarOpcionHis(StrConxSysemp10, "Impresiondocumentos", "Aplicar formato a campos", CONEMP.EmpresaAct.Sistema, Err.Description, Campo, Formato)
        }
        private String RegresaForma(string forma)
        {
            string aux = "";
            for (int i = 0; i < forma.Length; i++)
            {
                if (forma.Substring(i, 1) == "C") aux += ",";
                else aux += forma.Substring(i, 1);
            }
            return aux;
        }
        private string queBaseConsulta(Int32 tipoBase)
        {
            if (tipoBase == 4) return datosEmpresa.strConxDaxpro;
            else if (tipoBase == 3) return datosEmpresa.strConxIvaret;
            return datosEmpresa.strConxAdcom;
        }
        private double Val(string valor)
        {
            double aux = 0;
            try { aux = Convert.ToDouble(valor); } catch { }
            return aux;
        }
        private void BtnImpresora_Click(object sender, EventArgs e)
        {
            DialogResult opcion = printDialog1.ShowDialog();
            if (opcion == DialogResult.Cancel) return;
            PrintDocument1.DefaultPageSettings.PrinterSettings = printDialog1.PrinterSettings;
            PrintDocument1.PrinterSettings = printDialog1.PrinterSettings;
            MensajeImpresora();
            if (opcion == DialogResult.OK || opcion == DialogResult.Yes )  ImprimirDocumento(false);
        }
        private void MensajeImpresora()
        {
            QueImpresora.Text = " Impresora :   " + PrintDocument1.PrinterSettings.PrinterName;
        }
    }
}
