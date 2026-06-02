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
    public partial class ImprimeConsultaRol : Form
    {
        string QuePeriodo = "";
        Boolean EsConcepto = false;
        string ConsultaDelFormato = "";
        string versionTekform = "";
        private string FormaImpresionDocumento;
        GenDatos GenDato;

        DataTable Consulta = new DataTable();
        DataTable rsEmpleados = new DataTable();
        //int ConsultaStatus = 0;  // 0 tabla no leida 1 tabla leida y con datos 2 tabla leida sin datos

        int Currenty = 0;
        int Currentx = 0;
        Int32 Largoimprimible = 0;
        Int32 Anchoimprimible = 0;
        string[] FormasAimprimir;

        propiedadesForma propiedForma = new propiedadesForma();
        camposForma camposFormato = new camposForma();
        DataTable datosForma = new DataTable();

        Font Ffont = new Font("Arial", Convert.ToSingle(9.75), FontStyle.Regular);
        Font Nfont = new Font("Arial", Convert.ToSingle(9.75), FontStyle.Bold);

        private bool[] SaltaTitulosLinea = new bool[2];
        //private string codAnteriorTitulosLinea = "";
        //Int32 IniciaBorrado = 0;
        //Int32 UltimaLinea = 0;
        //Int32 BorraLineas = 1;

        private int NroDeRegistroImprimiendo = 0;
        private bool impresionIniciada = false;
        private int nroHoja = 0;
        public ImprimeConsultaRol(string TituloImpresion, string Consulta, string BaseDatos, string Formato, string elPeriodo, Boolean ImprimeDirecto, Boolean esConcepto = false)
        {
            InitializeComponent();
            MensajeImpresora();
            GenDato = new GenDatos(datosEmpresa.strConIniSis);
            Label1.Text = "Imprimiendo " + TituloImpresion + " - " + Formato;
            FormasAimprimir = new string[2];
            FormasAimprimir[0] = Formato;
            EsConcepto = esConcepto;
            ConsultaDelFormato = Consulta;
            QuePeriodo = elPeriodo;
            if (ImprimeDirecto == true)
            {
                ImprimirDocumento(false);
                Close();
            }
            else
            {
                this.ShowDialog();
            }
        }
        private bool leerPropiedadesFormato()
        {
            bool resp = true;

            string ssql = "select * from sysforms where l0='" + FormaImpresionDocumento.Trim() + "' and s1 = 'A'";
            DataTable dt = DattCom.SqlDatos.leerTablaAdcom(ssql);

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

            try
            {
                //rsEmpleados = DattCom.SqlDatos.leerTablaAdcom("SELECT idempleado from tmpdaxrol ");
                //string ssql = "select distinct (IdEmpleado),*  from Rolliq where liq_periodo = 1900 and Liq_CodigoConcepto = 69";
                rsEmpleados = DattCom.SqlDatos.leerTablaAdcom("SELECT idempleado from tmpdaxrol ");
                if (rsEmpleados.Rows.Count < 1) return "ERROR: No existen datos para imprimir";
            }
            catch (Exception ee)
            {
                return "ERROR: no se puede efectuar la impresiòn \n" + ee.Message;
            }
            NroDeRegistroImprimiendo = 0;

            if (leerPropiedadesFormato() == false) return "ERROR: NO EXISTE LA PLANTILLA PARA IMPRESION " + FormaImpresionDocumento;

            string SSQQL = "select * from sysforms where s1 <> 'A' and l0='" + FormaImpresionDocumento.Trim() + "' order by L1 ";
            datosForma = DattCom.SqlDatos.leerTablaAdcom(SSQQL);
            try
            {
                versionTekform = datosForma.Rows[0]["version"].ToString();
            }
            catch { }

            //PrepararBasesDeLineas();
            bool esAcordeon = (propiedForma.Acordeon == 1);
            LimitesForma.CalcularLimites(0, 0, Consulta.Rows.Count, 0, datosForma, esAcordeon);

            if (EsPrevisual == false) { PrintDocument1.DefaultPageSettings.PrinterSettings.Copies = Convert.ToInt16(propiedForma.NroCopias); }

            Anchoimprimible = System.Convert.ToInt32(((propiedForma.APapel / (double)567) / 2.54) * 100);            //  /567) / 2.54) * 100);
            if (propiedForma.Acordeon == 1)
            {

                Largoimprimible = LimitesForma.LongitudPagina;
            }
            else
            {
                Largoimprimible = System.Convert.ToInt32(((propiedForma.Lpapel / (double)567) / 2.54) * 100);
            }
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
            //UltimaLinea = 0;
            //BorraLineas = 1;
            //IniciaBorrado = 0;
            return "OKK";
        }

        //private void PrepararBasesDeLineas()
        //{
        //    ClassDoc.idDocumento IdDocumento = new ClassDoc.idDocumento();
        //    leerBasesDatos lectorDatos = new leerBasesDatos();
        //    ConsultaStatus = lectorDatos.leerConsulta(queBaseConsulta(propiedForma.BaseConsulta), null, ref Consulta, propiedForma.NombreConsulta);
        //}


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
        private void BtnImpresora_Click(object sender, EventArgs e)
        {
            DialogResult opcion = printDialog1.ShowDialog();
            if (opcion == DialogResult.Cancel) return;
            PrintDocument1.DefaultPageSettings.PrinterSettings = printDialog1.PrinterSettings;
            PrintDocument1.PrinterSettings = printDialog1.PrinterSettings;
            MensajeImpresora();
            if (opcion == DialogResult.OK || opcion == DialogResult.Yes) ImprimirDocumento(false);
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
                string[] queForma = (FormasAimprimir[imp]+",,,").Split(Convert.ToChar(","));
                if (queForma[0].Length > 0)
                {
                    FormaImpresionDocumento = queForma[0];
                    try
                    {
                        if (queForma[1].Length > 0)
                        {
                            PrintDocument1.DefaultPageSettings.PrinterSettings.PrinterName = queForma[1];
                        }
                    }
                    catch { }
                    string auxx = PrepararGeneracion(EsPrevisual);
                    if (auxx.Substring(0, 3) == "ERR") { return; }

                    if (EsPrevisual == true)
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
                        catch { MensajeImpresora(); }
                    }
                }
            }
            Close();
        }
        private void MensajeImpresora()
        {
            QueImpresora.Text = " Impresora :   " + PrintDocument1.PrinterSettings.PrinterName;
        }

        private void printDocument1_PrintPage(System.Object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (impresionIniciada == false)
            {
                impresionIniciada = true;

                NroDeRegistroImprimiendo = 0;
            }
            if (leerRegistroDeEmpleado(NroDeRegistroImprimiendo).Length > 0)
            {
                nroHoja = 0;
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
                            else if (camposFormato.Tipo == "E") { TipoDeLetra(); ImprimeEtiqueta(camposFormato.Valor, Currentx, Currenty, e.Graphics, Ffont); }
                            else if (camposFormato.Tipo == "11") { TipoDeLetra(); ImprimirDatos.ImprimeDato(ref Currenty, Largoimprimible, DatoGeneral(camposFormato.Valor), camposFormato.ALineacion, camposFormato.formato, camposFormato.FWidth, Currentx, e.Graphics, camposFormato.FHeight, Ffont); }
                            else { TipoDeLetra(); manejarDatosBases(nroHoja, camposFormato.Valor, camposFormato.ALineacion, camposFormato.formato, camposFormato.FWidth, Currentx, e.Graphics, camposFormato.FHeight, Ffont); }
                        }
                    }
                }
            }
   //         nroHoja++;
            NroDeRegistroImprimiendo++;
            if (NroDeRegistroImprimiendo < rsEmpleados.Rows.Count)
                e.HasMorePages = true;
            else
                e.HasMorePages = false;
        }
        private string leerRegistroDeEmpleado(Int32 NroRegistroAleer)
        {

            string codigoEmpleado = "";
            string ssql = "";
            try
            {
                codigoEmpleado = rsEmpleados.Rows[NroRegistroAleer]["idEmpleado"].ToString();
            }
            catch { }

            //ConsultaStatus = 2;
            if (ConsultaDelFormato.Substring(0, 1) == "&")
            {
                ssql = ConsultaDelFormato.Substring(1) + " '" + codigoEmpleado + "'," + QuePeriodo.ToString();
                Consulta = SqlDatos.leerTablaAdcom(ssql);
            }
            else
            {
                Consulta = SqlDatos.leerTablaAdcom("SELECT * FROM " + ConsultaDelFormato + " where idEmpleado = '" + codigoEmpleado + "' ");
            }
            if (Consulta.Rows.Count == 0) { codigoEmpleado = ""; } //else { ConsultaStatus = 1; }
            return codigoEmpleado;
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
            Nfont = new System.Drawing.Font(camposFormato.FontNombre, camposFormato.FontSize, st);
        }
        private void manejarDatosBases(int nroPagina, string Campo, Int32 Alineacion, string FORMATO, Int32 Ancho, Int32 Posicion, Graphics e, Int32 alto, Font fuente)
        {
            if (Campo == "") return;
            //string nomCampoDato = GenDato.QueCampo(Campo);
            string nomCampoDato = Campo;
            string AuxImp = "";
            //Boolean esDatoUnico = false ;
            //if (nomCampoDato == "") return;

            leerBasesDatos lectorDatos = new leerBasesDatos();
            DataTable tablaDatos = new DataTable();
            tablaDatos = Consulta;
            //esDatoUnico = false;
            //if (esDatoUnico)
            //{
            //    AuxImp = tablaDatos.Rows[0][nomCampoDato].ToString();
            //    ImprimirDatos.ImprimeDato(ref Currenty, Largoimprimible, AuxImp, camposFormato.ALineacion, camposFormato.formato, camposFormato.FWidth, Currentx, e, camposFormato.FHeight, fuente);
            //}
            //else
            {
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
                    if (NumlineasAimprimir > 1) NumlineasAimprimir = LimitesForma.linPorHoja;
                    Int32 lineaInicial = (NumlineasAimprimir * nroPagina);
                    for (int i = lineaInicial; i < tablaDatos.Rows.Count; i++)
                    {
                        if (NumlineasAimprimir > 0 && Currenty + alto <= Largoimprimible)
                        {
                            try { AuxImp = tablaDatos.Rows[i][nomCampoDato].ToString(); }
                            catch { AuxImp = ""; }
                            if (AuxImp != "")
                            {
                                //if (AuxImp == "Detalle::") { AuxImp = DetDocAmpliado(IdDocumento); Alineacion = 9; }
                                //else
                                //{
                                //    string auxVal = esTituloLinea(camposFormato.formato, AuxImp, camposFormato.FHeight, camposFormato.Numlineas);
                                //    if (auxVal != "")
                                //    { ImprimirDatos.ImprimeDato(ref Currenty, Largoimprimible, auxVal, camposFormato.ALineacion, camposFormato.formato, 400, camposFormato.FLeft, e, camposFormato.FHeight, Nfont); }
                                //}
                                ImprimirDatos.ImprimeDato(ref Currenty, Largoimprimible, AuxImp, camposFormato.ALineacion, camposFormato.formato, camposFormato.FWidth, Currentx, e, camposFormato.FHeight, fuente);
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

        private void ImprimeLinea(Int32 PuntoX1, Int32 PuntoY1, Int32 PuntoX2, Int32 PuntoY2, Int32 AnchoLinea, Graphics e)
        {
            if (AnchoLinea < 1) AnchoLinea = 1;
            Pen Penn = new Pen(Color.Black, AnchoLinea);
            e.DrawLine(Penn, PuntoX1, PuntoY1, PuntoX2, PuntoY2);
        }
        private void ImprimeCuadrado(Int32 PuntoX, Int32 PuntoY, Int32 AnchoCuadrado, Int32 AltoCuadrado, Int32 AnchoLinea, Graphics e)
        {
            if (AnchoLinea < 1) AnchoLinea = 1;
            Pen Penn = new Pen(Color.Black, AnchoLinea);
            e.DrawRectangle(Penn, PuntoX, PuntoY, AnchoCuadrado, AltoCuadrado);
        }
        private void ImprimeImagen(string nomImagen, Int32 PuntoX, Int32 PuntoY, Int32 AnchoImagen, Int32 AltoImagen, Graphics e)
        {
            try
            {
                e.DrawImage(System.Drawing.Image.FromFile(datosEmpresa.pathServer + "bin\\imagenes\\" + nomImagen), PuntoX, PuntoY, AnchoImagen, AltoImagen);
            }
            catch { }
        }


        private void ImprimeEtiqueta(string Aimprimir, Int32 Posicion, Int32 Currenty, Graphics e, System.Drawing.Font fuente)
        {
            e.DrawString(Aimprimir, fuente, Brushes.Black, Posicion, Currenty);
        }
        private string DatoGeneral(string dato)
        {
            if (dato == null) return "";
            if (dato.Length < 2) return "";
            string datGen = dato.Substring(1);
            Int32 datNum = 0;

            if (datGen == "DOC_fechaHoy" || datGen == "9001") { return DateTime.Now.ToShortDateString(); }
            else if (datGen == "DOC_HoraActual" || datGen == "9002") { return DateTime.Now.ToShortTimeString(); }

            try { datNum = Convert.ToInt32(datGen); }
            catch { datNum = 0; }
            // if (datNum < 9821 && datNum > 9800) return ImpText[datNum - 9801];
            return "";
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
    }
}
