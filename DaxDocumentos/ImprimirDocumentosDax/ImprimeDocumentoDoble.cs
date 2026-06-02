using libreriasTekform;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Collections.Generic;
using DaxDocElectronicos;
using System.IO;
using SolicitudAutSRI;
using ClassFelec;
using DattCom;

namespace ImpresionDocumentosDax
{
    public partial class ImprimeDocumentoDoble : Form
    {
        private string FormaImpresionDocumento;
        string strConxAdcom = "";
        string strConxIvaret = "";
        string strConIniSis = "";
        string strConxDaxpro = "";
        string PathServer = "";
        string versionTekform = "";

        sesSys.OpcDoc PropiedadesDoc = new sesSys.OpcDoc();
        GenDatos GenDato;

        DataTable Beneficiario = new DataTable();
        DataTable Consulta = new DataTable();
        DataTable Documento = new DataTable();
        DataTable Retenciones = new DataTable();
        DataTable Renglones = new DataTable();
        DataTable Banco = new DataTable();
        DataTable Sumatorias = new DataTable();
        DataTable pagos = new DataTable();
        DataTable RsCuotas = new DataTable();
        DataTable Contabilidad = new DataTable();

        int ConsultaStatus = 0;
        int DocumentoStatus = 0;
        int RetencionesStatus = 0;
        int RenglonesStatus = 0;
        int pagosStatus = 0;
        int ContabilidadStatus = 0;
        int BeneficiarioStatus = 0;

        int Currenty = 0;
        int Currentx = 0;
        Int32 Largoimprimible = 0;
        Int32 Anchoimprimible = 0;
        string[] FormasAimprimir;

        propiedadesForma propiedForma = new propiedadesForma();
        camposForma camposFormato = new camposForma();
        DataTable datosForma = new DataTable();
        string NombreBaseIvaret = "";
        ClassDoc.idDocumento IdDocumento = new ClassDoc.idDocumento();
        int NroDeimpresiones = 0;
        Font Ffont = new Font("Arial", Convert.ToSingle(9.75), FontStyle.Regular);
        Font Nfont = new Font("Arial", Convert.ToSingle(9.75), FontStyle.Bold);

        private bool[] SaltaTitulosLinea = new bool[2];
        private string codAnteriorTitulosLinea = "";

        List<ClassDoc.idDocumento> coleccionDocs;
        Boolean esMultiple = false;
        Boolean ImprimeFormatoContable = false;
        String ImprimeOtroFormato = "";

        private bool impresionIniciada = false;
        private string TablaTra = "ADCTRA";
        private string TablaDoc = "ADCDOC";
        private int nroHoja = 0;

        // Variables para el PDF - estos valores vienen del formulario principal
        private string queClaveSRI;
        private string urlE;
        private string pathCpbGenerados;

        // Delegado para la generación del RIDE (se asigna desde la clase principal)
        public Func<ClassDoc.idDocumento, string, string, string> FuncionGenerarRide { get; set; }

        public ImprimeDocumentoDoble(string NomBasIvaret, string strAdc, string strSri, string strSys, string strPro, int codEmp, string pathServer, sesSys.OpcDoc propDoc = null)
        {
            InitializeComponent();

            NombreBaseIvaret = NomBasIvaret;
            strConxAdcom = strAdc;
            strConxDaxpro = strPro;
            strConIniSis = strSys;
            strConxIvaret = strSri;
            GenDato = new GenDatos(strConIniSis);
            PathServer = pathServer;
            PropiedadesDoc = propDoc;
        }

        // Método original
        public int ImpDoc(ClassDoc.idDocumento IdDoc, string QueSystema = "A", string OtroFormato = "", bool ImpCtb = false, bool ImprimeDirecto = false)
        {
            ImprimeFormatoContable = ImpCtb;
            ImprimeOtroFormato = OtroFormato;
            esMultiple = false;
            IdDocumento = IdDoc;

            Label1.Text = IdDocumento.Tipo + "-" + IdDocumento.numero;
            NroDeimpresiones = Datos.LeerNroImpresiones(IdDocumento, strConxAdcom);
            inicializacion(ImpCtb, OtroFormato);
            MensajeImpresora();

            if (ImprimeDirecto == true)
            {
                ImprimirDocumento(false);
                Close();
            }
            else
            {
                this.ShowDialog();
            }
            return Datos.LeerNroImpresiones(IdDocumento, strConxAdcom);
        }

        // Sobrecarga del método ImpDoc que recibe los parámetros del SRI
        public int ImpDocConSRI(ClassDoc.idDocumento IdDoc, string QueSystema = "A", string OtroFormato = "", bool ImpCtb = false, bool ImprimeDirecto = false, string queClaveSRI = "", string urlSRI = "", string pathCpbGenerados = "")
        {
            // Estos valores vienen del formulario principal (datADCDOC.clavesri, urlE, fel.pathCpbGenerados)
            this.queClaveSRI = queClaveSRI;
            this.urlE = urlSRI;
            this.pathCpbGenerados = pathCpbGenerados;

            return ImpDoc(IdDoc, QueSystema, OtroFormato, ImpCtb, ImprimeDirecto);
        }

        private void MensajeImpresora()
        {
            QueImpresora.Text = " Impresora :   " + PrintDocument1.PrinterSettings.PrinterName;
        }

        private string ObtenerRutaPDF()
        {
            // Validar que tengamos un documento
            if (IdDocumento == null || IdDocumento.idClave == 0)
            {
                MessageBox.Show("Debe escoger un documento para previsualizar", "Previsualizar",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            // Validar que tengamos la clave SRI (debe venir del formulario principal)
            if (string.IsNullOrEmpty(queClaveSRI))
            {
                MessageBox.Show("No se ha encontrado la clave SRI del documento.\nNo es posible generar la previsualización del PDF.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            try
            {
                // Usar la ruta de PDFs que viene del formulario principal
                string carpetaPdf;
                if (!string.IsNullOrEmpty(pathCpbGenerados))
                {
                    carpetaPdf = Feutilidad.PathDocumntosPdf(pathCpbGenerados);
                }
                else
                {
                    // Ruta por defecto si no viene del formulario
                    carpetaPdf = Feutilidad.PathDocumntosPdf(@"C:\CPBGenerados\");
                }

                // Usar la clave SRI que viene del formulario principal (datADCDOC.clavesri)
                string pathPdf = Path.Combine(carpetaPdf, queClaveSRI + ".PDF");

                // Generar el PDF solo si no existe
                if (!File.Exists(pathPdf))
                {
                    if (string.IsNullOrEmpty(urlE))
                    {
                        urlE = ConfiguracionCorreo.UrlSRI;
                    }

                    GenerarRide(urlE);

                    if (!File.Exists(pathPdf))
                    {
                        MessageBox.Show("No se pudo generar el PDF del documento.", "Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return null;
                    }
                }

                return pathPdf;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar/obtener PDF: {ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void GenerarRide(string urlEs)
        {
            try
            {
                if (IdDocumento == null || IdDocumento.idClave == 0)
                {
                    MessageBox.Show("No hay documento seleccionado para generar el RIDE.");
                    return;
                }

                if (string.IsNullOrEmpty(queClaveSRI))
                {
                    MessageBox.Show("No se ha especificado la clave SRI del documento.");
                    return;
                }

                // Usar la función delegate si está asignada (desde el formulario principal)
                if (FuncionGenerarRide != null)
                {
                    string pdfPath = FuncionGenerarRide(IdDocumento, queClaveSRI, urlEs);
                    if (!string.IsNullOrEmpty(pdfPath) && File.Exists(pdfPath))
                    {
                        System.Diagnostics.Debug.WriteLine($"PDF generado correctamente: {pdfPath}");
                    }
                }
                else
                {
                    MessageBox.Show("No se ha configurado la función de generación de RIDE.\nLa previsualización de PDF no estará disponible.",
                                    "Configuración requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error al generar PDF: {ex.Message}");
                MessageBox.Show($"Error al generar el RIDE: {ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ImpDocMultiple(List<ClassDoc.idDocumento> coleccDocs, string QueSystema = "A", string OtroFormato = "", bool ImpCtb = false, bool ImprimeDirecto = false)
        {
            esMultiple = true;
            ImprimeFormatoContable = ImpCtb;
            ImprimeOtroFormato = OtroFormato;
            coleccionDocs = coleccDocs;
            Label1.Text = "IMPRESIÓN DE " + coleccDocs.Count.ToString() + " DOCUMENTOS ";
            MensajeImpresora();
            if (coleccDocs.Count == 0) return;
            this.ShowDialog();
        }

        public int ImpDocFast(ClassDoc.idDocumento IdDoc, string QueSystema = "A", string OtroFormato = "", Boolean ImpCtb = false, bool ImprimeDirecto = false)
        {
            NroDeimpresiones = Datos.LeerNroImpresiones(IdDoc, strConxAdcom);
            esMultiple = false;
            ImprimeFormatoContable = ImpCtb;
            ImprimeOtroFormato = OtroFormato;
            IdDocumento = IdDoc;
            inicializacion(ImpCtb, OtroFormato);
            ImprimirDocumento(false);
            return Datos.LeerNroImpresiones(IdDocumento, strConxAdcom);
        }

        private void inicializacion(Boolean IMprimeCtb, string OtraImpresion)
        {
            string lugar = "";
            try
            {
                if (PropiedadesDoc == null && IdDocumento.Tipo.Length > 0)
                {
                    PropiedadesDoc = new sesSys.OpcDoc();
                    PropiedadesDoc.Cargar(ref IdDocumento.Tipo, ref lugar);
                }
            }
            catch
            {
                PropiedadesDoc = new sesSys.OpcDoc();
                PropiedadesDoc.Cargar(ref IdDocumento.Tipo, ref lugar);
            }
            TablaDoc = PropiedadesDoc.tablaDatosDoc;
            TablaTra = PropiedadesDoc.tablaDatosTra;
            FormasAimprimir = Reglas.QueFormatoImprime(PropiedadesDoc, IMprimeCtb, OtraImpresion);
        }

        private void inicializacionMultiple(ClassDoc.idDocumento IdDocumento)
        {
            string lugar = "";
            try
            {
                if (PropiedadesDoc == null || IdDocumento.Tipo != PropiedadesDoc.TipoDoc)
                {
                    PropiedadesDoc = new sesSys.OpcDoc();
                    PropiedadesDoc.Cargar(ref IdDocumento.Tipo, ref lugar);
                }
            }
            catch
            {
                PropiedadesDoc = new sesSys.OpcDoc();
                PropiedadesDoc.Cargar(ref IdDocumento.Tipo, ref lugar);
            }
            TablaDoc = PropiedadesDoc.tablaDatosDoc;
            TablaTra = PropiedadesDoc.tablaDatosTra;
            FormasAimprimir = Reglas.QueFormatoImprime(PropiedadesDoc, ImprimeFormatoContable, ImprimeOtroFormato);
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
            if (leerPropiedadesFormato() == false) return "ERROR: NO EXISTE LA PLANTILLA PARA IMPRESION DEL DOCUMENTO " + FormaImpresionDocumento;

            string SSQQL = "select * from sysforms where s1 <> 'A' and l0='" + FormaImpresionDocumento.Trim() + "' order by L1 ";
            datosForma = DattCom.SqlDatos.leerTablaAdcom(SSQQL);
            try
            {
                versionTekform = datosForma.Rows[0]["version"].ToString();
            }
            catch { }

            PrepararBasesDeLineas();
            bool esAcordeon = (propiedForma.Acordeon == 1);
            LimitesForma.CalcularLimites(Renglones.Rows.Count, Contabilidad.Rows.Count, Consulta.Rows.Count, Retenciones.Rows.Count, datosForma, esAcordeon);

            if (EsPrevisual == false) { PrintDocument1.DefaultPageSettings.PrinterSettings.Copies = Convert.ToInt16(propiedForma.NroCopias); }

            Anchoimprimible = System.Convert.ToInt32(((propiedForma.APapel / (double)567) / 2.54) * 100);
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
            return "OKK";
        }

        private void PrepararBasesDeLineas()
        {
            bool tiene2 = false;
            bool tiene4 = false;
            bool tiene14 = false;
            bool tiene7 = false;
            string version = "";
            try
            {
                version = datosForma.Rows[0]["version"].ToString();
            }
            catch { }

            foreach (DataRow row in datosForma.Rows)
            {
                if (row["S1"].ToString() == "D")
                {
                    leerDefinicionFormato.LeerLinea(row["l1"].ToString(), ref camposFormato, 0, version);
                    if (camposFormato.Tipo == "2") tiene2 = true;
                    if (camposFormato.Tipo == "4") tiene4 = true;
                    if (camposFormato.Tipo == "7") tiene7 = true;
                    if (camposFormato.Tipo == "14") tiene14 = true;
                }
            }
            leerBasesDatos lectorDatos = new leerBasesDatos();
            DocumentoStatus = lectorDatos.leerDocumento(strConxAdcom, IdDocumento, "", "", ref Documento);
            if (tiene2) RenglonesStatus = lectorDatos.leerRenglones(strConxAdcom, IdDocumento, "", "", ref Renglones);
            if (tiene4) ContabilidadStatus = lectorDatos.leerContabilidad(strConxAdcom, IdDocumento, "", "", ref Contabilidad);
            if (tiene7) RetencionesStatus = lectorDatos.leerRetenciones(strConxAdcom, IdDocumento, "", "", ref Retenciones);
            if (tiene14) ConsultaStatus = lectorDatos.leerConsulta(queBaseConsulta(propiedForma.BaseConsulta), IdDocumento, ref Consulta, propiedForma.NombreConsulta);
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
            if (esMultiple)
            {
                coleccionDocs.ForEach(delegate (ClassDoc.idDocumento iddoc) { impresionDocMultiple(iddoc); });
            }
            else
            {
                ImprimirDocumento(false);
            }
        }

        // Botón Previsual - Genera y muestra el PDF
        private void BtnPrevisual_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string pathPdf = ObtenerRutaPDF();

                if (pathPdf != null)
                {
                    Cursor.Current = Cursors.Default;

                    // Abrir el visor de PDF
                    using (frmPreviewPdf frm = new frmPreviewPdf(pathPdf))
                    {
                        frm.ShowDialog();
                    }
                }
                else
                {
                    Cursor.Current = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Error al previsualizar el documento:\n" + ex.Message);
            }
        }

        private void impresionDocMultiple(ClassDoc.idDocumento docid)
        {
            inicializacionMultiple(docid);
            ImprimirDocumento(false);
        }

        private void ImprimirDocumento(bool EsPrevisual)
        {
            int NroFormatos = 1;
            if (NroDeimpresiones == 0) NroFormatos = FormasAimprimir.Length;

            for (int imp = 0; imp < NroFormatos; imp++)
            {
                impresionIniciada = false;
                string[] queForma = FormasAimprimir[imp].Split(Convert.ToChar(","));
                if (queForma.Length > 0 && queForma[0].Length > 0)
                {
                    FormaImpresionDocumento = queForma[0];
                    if (queForma.Length > 1 && queForma[1].Length > 0)
                    {
                        PrintDocument1.DefaultPageSettings.PrinterSettings.PrinterName = queForma[1];
                    }
                    string auxx = PrepararGeneracion(EsPrevisual);
                    if (auxx.Substring(0, 3) == "ERR") { return; }

                    if (EsPrevisual == true)
                    {
                        PrintPreviewDialog1.Document = PrintDocument1;
                        PrintPreviewDialog1.ShowDialog();
                    }
                    else
                    {
                        PrintDocument1.DefaultPageSettings.PrinterSettings.Copies = Convert.ToInt16(propiedForma.NroCopias);
                        try
                        {
                            PrintDocument1.Print();
                        }
                        catch { MensajeImpresora(); }
                    }
                }
            }
            // Actualizamos nro de impresiones
            string aux = "update " + TablaDoc + " set doc_adicional1 = isnull(doc_adicional1,0) + 1 where Doc_sucursal = '" + IdDocumento.Sucursal + "' and opc_documento = '" + IdDocumento.Tipo + "' and idclavedoc = " + IdDocumento.idClave.ToString();
            DattCom.SqlDatos.ejecutarComando(aux, strConxAdcom);
            Close();
        }

        private void printDocument1_PrintPage(System.Object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (impresionIniciada == false)
            {
                impresionIniciada = true;
            }

            foreach (DataRow row in datosForma.Rows)
            {
                leerDefinicionFormato.LeerLinea(row["l1"].ToString(), ref camposFormato, 0, versionTekform);

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
                    else if (camposFormato.Tipo == "O") { ImprimeCirculo(Currentx, Currenty, camposFormato.FWidth, camposFormato.FHeight, camposFormato.ALineacion, e.Graphics); }
                    else if (camposFormato.Tipo == "I") { ImprimeImagen(camposFormato.Valor, Currentx, Currenty, camposFormato.FWidth, camposFormato.FHeight, e.Graphics); }
                    else if (camposFormato.Tipo == "E") { TipoDeLetra(); ImprimeEtiqueta(camposFormato.Valor, Currentx, Currenty, e.Graphics, Ffont); }
                    else if (camposFormato.Tipo == "11") { TipoDeLetra(); ImprimirDatos.ImprimeDato(ref Currenty, Largoimprimible, DatoGeneral(camposFormato.Valor), camposFormato.ALineacion, camposFormato.formato, camposFormato.FWidth, Currentx, e.Graphics, camposFormato.FHeight, Ffont); }
                    else { TipoDeLetra(); manejarDatosBases(nroHoja, camposFormato.Valor, camposFormato.ALineacion, camposFormato.formato, camposFormato.FWidth, Currentx, e.Graphics, camposFormato.FHeight, Ffont); }
                }
            }

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
            Ffont = new System.Drawing.Font(camposFormato.FontNombre, camposFormato.FontSize, st);
            st = FontStyle.Bold;
            Nfont = new System.Drawing.Font(camposFormato.FontNombre, camposFormato.FontSize, st);
        }

        private void manejarDatosBases(int nroPagina, string Campo, Int32 Alineacion, string FORMATO, Int32 Ancho, Int32 Posicion, Graphics e, Int32 alto, Font fuente)
        {
            if (Campo == "") return;
            string nomCampoDato = GenDato.QueCampo(Campo);
            string AuxImp = "";
            Boolean esDatoUnico = true;
            if (nomCampoDato == "") return;

            leerBasesDatos lectorDatos = new leerBasesDatos();
            DataTable tablaDatos = new DataTable();

            if (camposFormato.Tipo == "1" | camposFormato.Tipo == "8" | camposFormato.Tipo == "10")
            {
                if (DocumentoStatus == 0) DocumentoStatus = lectorDatos.leerDocumento(strConxAdcom, IdDocumento, "", "", ref Documento);
                tablaDatos = Documento;
            }
            else if (camposFormato.Tipo == "0")
            {
                if (BeneficiarioStatus == 0 && DocumentoStatus == 1) BeneficiarioStatus = lectorDatos.leerBeneficiario(strConxAdcom, Documento.Rows[0]["Doc_codper"].ToString(), ref Beneficiario);
                tablaDatos = Beneficiario;
                esDatoUnico = true;
            }
            else if (camposFormato.Tipo == "2")
            {
                tablaDatos = Renglones;
                esDatoUnico = false;
            }
            else if (camposFormato.Tipo == "3")
            {
                if (pagosStatus == 0)
                {
                    pagosStatus = lectorDatos.leerPagos(strConxAdcom, NombreBaseIvaret, IdDocumento, "", "", ref pagos);
                }
                tablaDatos = pagos;
                esDatoUnico = false;
            }
            else if (camposFormato.Tipo == "4")
            {
                esDatoUnico = false;
                tablaDatos = Contabilidad;
            }
            else if (camposFormato.Tipo == "7")
            {
                esDatoUnico = false;
                tablaDatos = Retenciones;
            }
            else if (camposFormato.Tipo == "14")
            {
                tablaDatos = Consulta;
                esDatoUnico = false;
            }
            if (tablaDatos.Rows.Count == 0) return;

            if (esDatoUnico)
            {
                AuxImp = ObtenerValorSeguro(tablaDatos, nomCampoDato, "");

                if (AuxImp == "Detalle::")
                {
                    AuxImp = DetDocAmpliado(IdDocumento);
                    camposFormato.ALineacion = 9;
                }

                ImprimirDatos.ImprimeDato(
                    ref Currenty,
                    Largoimprimible,
                    AuxImp,
                    camposFormato.ALineacion,
                    camposFormato.formato,
                    camposFormato.FWidth,
                    Currentx,
                    e,
                    camposFormato.FHeight,
                    fuente);
            }
            else
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
                            try
                            {
                                AuxImp = ObtenerValorSeguro(tablaDatos, nomCampoDato, "");
                            }
                            catch { AuxImp = ""; }
                            if (AuxImp != "")
                            {
                                if (AuxImp == "Detalle::") { AuxImp = DetDocAmpliado(IdDocumento); camposFormato.ALineacion = 9; }
                                else
                                {
                                    string auxVal = esTituloLinea(camposFormato.formato, AuxImp, camposFormato.FHeight, camposFormato.Numlineas);
                                    if (auxVal != "")
                                    {
                                        ImprimirDatos.ImprimeDato(ref Currenty, Largoimprimible, auxVal, camposFormato.ALineacion, camposFormato.formato, 400, camposFormato.FLeft, e, camposFormato.FHeight, Nfont);
                                    }
                                }
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

        private string ObtenerValorSeguro(DataTable tabla, string nombreColumna, string valorPorDefecto)
        {
            if (tabla == null || tabla.Rows.Count == 0)
                return valorPorDefecto;

            if (!tabla.Columns.Contains(nombreColumna))
            {
                System.Diagnostics.Debug.WriteLine(string.Format("⚠️ Columna '{0}' no encontrada en tabla '{1}'", nombreColumna, tabla.TableName));
                return valorPorDefecto;
            }

            object valor = tabla.Rows[0][nombreColumna];
            if (valor == null || valor == DBNull.Value)
                return valorPorDefecto;

            return valor.ToString();
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

        private void ImprimeCirculo(Int32 PuntoX, Int32 PuntoY, Int32 AnchoCuadrado, Int32 AltoCuadrado, Int32 AnchoLinea, Graphics e)
        {
            if (AnchoLinea < 1) AnchoLinea = 1;
            Pen Penn = new Pen(Color.Black, AnchoLinea);
            e.DrawEllipse(Penn, PuntoX, PuntoY, AnchoCuadrado, AltoCuadrado);
        }

        private void ImprimeImagen(string nomImagen, Int32 PuntoX, Int32 PuntoY, Int32 AnchoImagen, Int32 AltoImagen, Graphics e)
        {
            try
            {
                e.DrawImage(System.Drawing.Image.FromFile(PathServer + "bin\\imagenes\\" + nomImagen), PuntoX, PuntoY, AnchoImagen, AltoImagen);
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
            return "";
        }

        private string queBaseConsulta(Int32 tipoBase)
        {
            if (tipoBase == 4) return strConxDaxpro;
            else if (tipoBase == 3) return strConxIvaret;
            return strConxAdcom;
        }

        private double Val(string valor)
        {
            double aux = 0;
            try { aux = Convert.ToDouble(valor); } catch { }
            return aux;
        }

        private string DetDocAmpliado(ClassDoc.idDocumento iddoc)
        {
            System.Windows.Forms.RichTextBox Rtfdata = new System.Windows.Forms.RichTextBox();
            string Ssql = "select * from AdcDocTex where Doc_Sucursal = '" + iddoc.Sucursal + "' and opc_documento = '" + iddoc.Tipo + "' and idclavedoc = " + iddoc.idClave;
            SqlDataReader rsd = DattCom.SqlDatos.leerBase(Ssql, DattCom.datosEmpresa.strConxAdcom);
            if (rsd.Read()) { Rtfdata.Rtf = rsd["TEXTO"].ToString(); return Rtfdata.Text; }
            else { return ""; }
        }

        private string esTituloLinea(string Formato, string Valor, double alto, Int32 Linea)
        {
            string CARATULA = "";
            EmpNomR.AdcNomb retNom = new EmpNomR.AdcNomb();
            switch (Formato.ToUpper())
            {
                case "&CAT":
                    {
                        CARATULA += retNom.RetornaNombreCategoria(Valor, DattCom.datosEmpresa.strConxAdcom);
                        break;
                    }
                case "&CLA":
                    {
                        CARATULA += retNom.RetornaNombreClase(Valor, DattCom.datosEmpresa.strConxAdcom);
                        break;
                    }
                case "&GRU":
                    {
                        CARATULA += retNom.RetornaNombreGrupo(Valor, DattCom.datosEmpresa.strConxAdcom);
                        break;
                    }
                case "&SUB":
                    {
                        CARATULA += retNom.RetornaNombreSubGrupo(Valor, DattCom.datosEmpresa.strConxAdcom);
                        break;
                    }
                default:
                    {
                        if (SaltaTitulosLinea.Length > Linea)
                        {
                            if (SaltaTitulosLinea[Linea]) Currenty += System.Convert.ToInt32(alto);
                        }
                        break;
                    }
            }
            if (CARATULA != "")
            {
                if (CARATULA != codAnteriorTitulosLinea | codAnteriorTitulosLinea == "")
                {
                    codAnteriorTitulosLinea = CARATULA;
                    if (Linea < SaltaTitulosLinea.Length)
                    {
                    }
                    else
                    {
                        bool[] oldSaltaTitulosLinea = SaltaTitulosLinea;
                        SaltaTitulosLinea = new bool[Linea + 2];
                        if (oldSaltaTitulosLinea != null) Array.Copy(oldSaltaTitulosLinea, SaltaTitulosLinea, Math.Min(Linea + 2, oldSaltaTitulosLinea.Length));
                    }
                    SaltaTitulosLinea[Linea] = true;
                }
                else
                    CARATULA = "";
            }
            return CARATULA;
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

        // Evento Load del formulario
        private void ImprimeDocumentoDoble_Load(object sender, EventArgs e)
        {
            try
            {
                MensajeImpresora();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error en Load: {ex.Message}");
            }
        }
    }
}