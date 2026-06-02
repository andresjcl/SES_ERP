using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using ClassDoc;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using SysEmpDatt;
using WebService;

namespace DaxDocElectronicos
{
    public partial class frmMntDocElectrncos
    {
        public frmMntDocElectrncos()
        {
            InitializeComponent();
            _btnSalir.Name = "btnSalir";
            _btnGenerar.Name = "btnGenerar";
            _btnAutorizar.Name = "btnAutorizar";
            _btnCorreoXml.Name = "btnCorreoXml";
            _btnEnviar.Name = "btnEnviar";
            _ToolStrip5.Name = "ToolStrip5";
            _btnGenerarGrupo.Name = "btnGenerarGrupo";
            _btn.Name = "btn";
            chkOnLine.Name = "chkOnLine";
        }

        private idDocumento IdDocumento = new idDocumento();
        private string queClaveSRI = "";
        private string queCodigoCliente = "";
        private DateTime queFecha = DateTime.Now;
        private string queClase;
        private string String3 = "";
        private string PathFile = "";
        private string strConxadcom = "";
        private string strConxIvaret = "";
        private string strConxDaxsys = "";
        private string strConxDaxpro = "";
        private string correoElectronico = "";
        private string correoElectronico2 = "";
        private string correoElectronicoDefecto = "";
        private short tipoEmision = 0;
        private string Errores = "";
        private List<string> colecError = new List<string>();
        private bool EsOnLine = false;
        private AdcFelec fel;

        private string getXML()
        {
            string getXMLRet = default;
            var open = new OpenFileDialog();
            string retVal = string.Empty;
            // --------------------------------------------------------------------------------------------
            open.Filter = "Archivos XML(*.xml)|*.xml";
            // --------------------------------------------------------------------------------------------
            if (open.ShowDialog(this) == DialogResult.OK)
            {
                PathFile = open.FileName;
                retVal = open.SafeFileName;
            }
            // --------------------------------------------------------------------------------------------
            getXMLRet = retVal;
            // --------------------------------------------------------------------------------------------
            open = null;
            return getXMLRet;
        }

        // Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        // Dim fileName As String = getXML()
        // '--------------------------------------------------------------------------------------------
        // If fileName <> String.Empty Then
        // Dim prog As New EnviarComprobanteSri
        // prog.sendComprobanteSRI(fileName, queClaveSRI)
        // End If
        // End Sub

        private void btnAbre_Click(object sender, EventArgs e)
        {
            var progBus = new BuscadorDocumentos.buscadorDoc();
            // MsgBox(Application.StartupPath())        
            progBus.IniciaBusqueda("ELE", "", "", queFecha, ref IdDocumento.Sucursal, ref IdDocumento.Tipo, ref IdDocumento.numero, ref IdDocumento.idClave, false, "", "", "", "ADCDOC");
            mensaje.Text = "";
            leerDocumentoAdcom();
        }

        private void leerDocumentoAdcom()
        {
            var progdoc = new AdcDoc(strConxadcom);
            var dt = new DataTable();
            string ssql = "SELECT AdcDoc.*, Identificacion.CorreoElectrónico as correo1, Identificacion.Paginaweb as correo2 FROM Adcdoc ";
            ssql += " LEFT OUTER JOIN Identificacion ON AdcDoc.Doc_codper = Identificacion.Codigo ";
            if (IdDocumento.idClave == 0d & Operators.CompareString(queClaveSRI, "", false) > 0)
            {
                ssql += " WHERE clavesri = '" + queClaveSRI + "' ";
            }
            else
            {
                ssql += " WHERE doc_sucursal = '" + IdDocumento.Sucursal + "' and opc_documento = '" + IdDocumento.Tipo + "' and idclavedoc = " + IdDocumento.idClave.ToString();
            }

            dt = AdcDoc.Tabla(ssql);
            if (dt.Rows.Count < 1)
            {
                Interaction.MsgBox("No existe el documento seleccionado");
                return;
            }

            IdDocumento.Sucursal = dt.Rows[0]["Doc_sucursal"].ToString();
            IdDocumento.Tipo = dt.Rows[0]["opc_documento"].ToString();
            IdDocumento.idClave = Conversions.ToDouble(dt.Rows[0]["IdclaveDoc"]);
            IdDocumento.numero = Conversions.ToDouble(dt.Rows[0]["Doc_numero"].ToString());
            queClase = dt.Rows[0]["doc_tipodoc"].ToString();
            queClaveSRI = dt.Rows[0]["claveSri"].ToString();
            LabCiRuc.Text = dt.Rows[0]["Doc_CiRuc"].ToString();
            LabClave.Text = dt.Rows[0]["claveSri"].ToString();
            LabEstado.Text = dt.Rows[0]["estadoSri"].ToString();
            LabFechaAutoriza.Text = dt.Rows[0]["fechaAutorizacion"].ToString();
            LabId.Text = dt.Rows[0]["Doc_nroiddoc"].ToString();
            LabNombre.Text = dt.Rows[0]["Doc_nombreImp"].ToString();
            LabNumero.Text = dt.Rows[0]["Doc_numero"].ToString();
            LabNumeroAutoriza.Text = dt.Rows[0]["nroAutorizacionSri"].ToString();
            LabTipo.Text = dt.Rows[0]["opc_documento"].ToString();
            queCodigoCliente = dt.Rows[0]["Doc_codper"].ToString();
            correoElectronico = dt.Rows[0]["Correo1"].ToString();
            correoElectronico2 = dt.Rows[0]["Correo2"].ToString();
            dt.Dispose();
            progdoc = null;
            configurarBotones();
        }
        // Private Sub leerCorreoCliente(codigo As String)
        // Dim prog As New MantenimientoDirectorio.DirectorioAlex
        // If prog.CargarAlex(codigo, True) = True Then
        // correoElectronico = prog.correoElectronico
        // Else
        // correoElectronico = ""
        // End If
        // prog = Nothing
        // End Sub
        // Private Sub leerCorreosClienteConDoc(iddoc As ClassDoc.idDocumento)

        // Dim ssql As String = "SELECT AdcDoc.Doc_codper, Identificacion.CorreoElectrónico as correo1, Identificacion.Paginaweb as correo2 FROM " & tablaDoc
        // ssql += " LEFT OUTER JOIN Identificacion ON AdcDoc.Doc_codper = Identificacion.Codigo "
        // ssql += " WHERE doc_sucursal = '" & iddoc.Sucursal & "' and opc_documento = '" & iddoc.Tipo & "' and idclavedoc = " & iddoc.idClave.ToString()


        // Dim dr = New SqlDataAdapter(ssql, strConxadcom)
        // Dim dt As New DataTable
        // dr.fill(dt)

        // If dt.Rows.Count < 1 Then Errores = "No existe el documento seleccionado"
        // IdDocumento.Sucursal = dt.Rows(0)("Doc_sucursal").ToString()
        // IdDocumento.Tipo = dt.Rows(0)("opc_documento").ToString()
        // IdClaveDoc = CDbl(dt.Rows(0)("IdclaveDoc"))
        // IdDocumento.Numero = CDbl(dt.Rows(0)("Doc_numero").ToString())
        // queClase = dt.Rows(0)("doc_tipodoc").ToString()
        // queClaveSRI = dt.Rows(0)("claveSri").ToString()
        // correoElectronico = dt.Rows(0)("Correo1").ToString()
        // correoElectronico2 = dt.Rows(0)("Correo2").ToString()
        // dt.Dispose()
        // dr.Dispose()

        // End Sub
        private void Form1_Load(object sender, EventArgs e)
        {
            strConxadcom = datosEmpresa.strConxAdcom;
            strConxIvaret = datosEmpresa.strConxIvaret;
            strConxDaxsys = datosEmpresa.strConxDaxsys;
            strConxDaxpro = datosEmpresa.strConxDaxpro;
            if (datosEmpresa.Emp_codigo == 0)
                Close();
            fel = new AdcFelec(strConxadcom);
            fel = AdcFelec.Buscar("");
            IdDocumento.Sucursal = datosEmpresa.suc;
            revisarFacturas(strConxadcom);
            configurarBotones();
        }

        private void revisarFacturas(string strAdcom)
        {
            using (var conn = new SqlConnection(strAdcom))
            {
                conn.Open();
                using (var comm = new SqlCommand("dax_setIdSri " + datosEmpresa.Emp_codigo.ToString() + ",'" + datosEmpresa.suc + "'", conn))
                {
                    comm.ExecuteNonQuery();
                }
            }
        }

        private void activarContingencia()
        {
            var rs = new DataTable();
            string ssql = "select top(1) clavecontigencia from adcclavcontg where utidoctipo = '' and clavecontigencia > '' ";
            var da = new SqlDataAdapter(ssql, strConxadcom);
            da.Fill(rs);
            if (rs.Rows.Count == 0)
                chkOnLine.Visible = false;
            else
                chkOnLine.Visible = true;
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (IdDocumento.idClave == 0d)
            {
                Interaction.MsgBox("Debe escojer un documento para enviar");
                return;
            }

            verificaCorreoElectronico(ref correoElectronico);
            ImpDoc(IdDocumento.idClave, datosEmpresa.suc, IdDocumento.Tipo, IdDocumento.numero, "A", "F", "", "FEL" + queClase, "");
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void firmarDocumento()
        {
            // firmar comprobante
            if (string.IsNullOrEmpty(queClaveSRI))
            {
                queClaveSRI = getXML().ToUpper();
                queClaveSRI = queClaveSRI.Replace(".XML", "");
            }

            if (string.IsNullOrEmpty(queClaveSRI))
                return;
            mensaje.Text = "";
            leerDocumentoAdcom();
            var FM = new Firma();
            FM.strFileXml = queClaveSRI;
            string resp = FM.FirmarArchivoXML(strConxadcom);
            Interaction.MsgBox(resp);
            FM = null;
            leerDocumentoAdcom();
        }
        // Private Sub EjecutarProgramaExterno(ByVal programa As String, ByVal NombreOpcion As String)
        // Try
        // Dim existe As Integer
        // Dim OPCION As String = ""
        // emp.String2 = ""
        // existe = Len(Dir(emp.PatAppl & programa))
        // If existe > 0 Then
        // Dim pi As New System.Diagnostics.ProcessStartInfo()
        // pi.FileName = programa
        // pi.Arguments = NombreOpcion
        // pi.WorkingDirectory = emp.PatAppl
        // pi.WindowStyle = ProcessWindowStyle.Normal
        // System.Diagnostics.Process.Start(pi)
        // End If
        // Catch ee As Exception
        // MsgBox("excepción ProgExt: " & ee.Message)
        // End Try
        // End Sub

        private bool valida()
        {
            bool resp = true;
            if (IdDocumento.idClave == 0d | string.IsNullOrEmpty(IdDocumento.Tipo))
            {
                Interaction.MsgBox("Debe abrir un documento para utilizar esta opción", MsgBoxStyle.Information, "Operación con factura electronica");
                resp = false;
            }

            return resp;
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            classDatEmp.cargarDatosDeNuestraEmpresa(datosEmpresa.Emp_RUC, strConxadcom);
            if (!valida())
                return;
            var genxml = new GenerarDocumentoXML();
            tipoEmision = 1;
            if (chkOnLine.Checked == true)
                EsOnLine = true;
            string queClave = genxml.documentoAenviar(IdDocumento.Sucursal, IdDocumento.Tipo, IdDocumento.numero.ToString(), IdDocumento.idClave, ref PathFile, queClase, datosEmpresa.Emp_RUC, datosEmpresa.Par_DigitosPrecios, datosEmpresa.pathAppl, tipoEmision, chkOnLine.Checked);
            if (queClave.Substring(0, 5).ToUpper() == "ERROR")
            {
                MessageBox.Show("EXISTEN ERRORES EN EL DOCUMENTO: " + queClave.Substring(5));
                publicarMensaje(PathFile.Replace("XML", "ERR"));
            }
            else
            {
                queClaveSRI = queClave;
                PrepararEnvios(queClase);
            }

            mensaje.Text = "";
            leerDocumentoAdcom();
            genxml = null;
        }

        private void PrepararEnvios(string TipoDoc)
        {
            string nombrePdf = Feutilidad.PathDocumntosPdf(fel.pathCpbGenerados) + queClaveSRI + ".PDF";
            string FormaImpresionDocumento = "FEL" + TipoDoc;
            var PROG = new documentosPdf.generacionPdf(datosEmpresa.nombreBaseIvaret, strConxadcom, strConxIvaret, strConxDaxsys, strConxDaxpro, datosEmpresa.Emp_codigo, datosEmpresa.pathServer);
            PROG.GeneraDocPdf(IdDocumento, nombrePdf, "", FormaImpresionDocumento);
            PROG = null;
        }

        // Private Sub LeerDocumentoAdcom(clave As String)
        // Dim ssql As String = "update adcdoc set claveSri='" & clave & "' "
        // Dim daxlib As New DaxLib.DaxLibBases()
        // daxlib.TipoBase = "10"
        // Dim conn As New SqlConnection(daxlib.StrAdcom())
        // conn.Open()
        // daxlib = Nothing
        // Dim comm As New SqlCommand(ssql, conn)
        // comm.ExecuteNonQuery()
        // comm.Dispose()
        // conn.Close()
        // conn.Dispose()
        // End Sub

        private void btnAutorizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(queClaveSRI))
            {
                queClaveSRI = getXML().ToUpper();
                queClaveSRI = queClaveSRI.Replace(".XML", "");
            }

            AutorizarDocumento();
        }

        private void AutorizarDocumento()
        {
            if (string.IsNullOrEmpty(queClaveSRI))
                return;
            mensaje.Text = "";
            leerDocumentoAdcom();
            string pathAutorizados = fel.pathCpbAutorizados + queClaveSRI + ".xml";
            string pathNoAutorizados = fel.pathpbNoAutorizados + queClaveSRI + ".xml";
            string pathErrores = pathNoAutorizados.Replace("xml", "ERR");
            correoElectronicoDefecto = fel.correoDefecto;
            string ambiente = "2";
            if (fel.ambienteEnProduccion == false)
                ambiente = "1";
            var prog = new EnviarComprobanteSri();
            if (prog.sendComprobanteSRI(PathFile, queClaveSRI, pathAutorizados, pathNoAutorizados, chkOnLine.Checked, ambiente, strConxadcom) == true)
            {
                PrepararEnvios(queClase);
                Interaction.MsgBox("Documento autorizado sin novedades");
            }
            else
            {
                Interaction.MsgBox("documento no autorizado");
                mensaje.Text = publicarMensaje(pathErrores);
            }

            leerDocumentoAdcom();

            // fel = Nothing
        }
        // Private Sub tablasDeDatos(ByVal docTipo As String, ByRef tablaDoc As String, ByRef tablaTra As String)
        // Dim ssql As String = "select * from adcopc where opc_documento = '" & docTipo & "' "
        // Dim progdoc = New AdcDoc(strConxadcom)
        // Dim dats = AdcDoc.Tabla(ssql)
        // Select Case dats.Rows(0)("opc_tipo").ToString().ToUpper()
        // Case "PEP", "PRC", "PRP", "REQ"
        // tablaDoc = "ADCDOCPRO"
        // tablaTra = "ADCTRAPRO"
        // Case Else
        // tablaDoc = "ADCDOC"
        // tablaTra = "ADCTRA"
        // End Select
        // dats.Dispose()
        // progdoc = Nothing
        // End Sub

        public void ImpDoc(double IdClaveDocC, string Sucursal, string TipoDocumento, double NumeroDocumento, string QueSystema = "A", string FacturaProforma = "F", string AuxManual = "", string otraimp = "", string ImpCtb = "")
        {
            // Try
            // Dim pasar As String = ""
            // Dim prog As New ImprDoct.ImprimirDoc
            // prog.CorreoElectronico = correoElectronico
            // prog.claveSri = queClaveSRI
            // pasar = QueSystema & "," & FacturaProforma & "," & AuxManual & "," & otraimp & "," & ImpCtb
            // prog.ImprimeDocMail(IdClaveDocC, Sucursal, TipoDocumento, NumeroDocumento, pasar)
            // prog = Nothing
            // Catch
            // End Try
        }

        private string publicarMensaje(string file)
        {
            string STR = "";
            try
            {
                var Rfile = new StreamReader(file);
                STR = Rfile.ReadToEnd();
            }
            catch
            {
            }

            return STR;
        }

        private void btnContingencia_Click(object sender, EventArgs e)
        {
            var open = new OpenFileDialog();
            string retVal = string.Empty;
            // --------------------------------------------------------------------------------------------
            open.Filter = "Archivos TXT(*.TXT)|*.TXT";
            // --------------------------------------------------------------------------------------------
            if (open.ShowDialog(this) == DialogResult.OK)
            {
                PathFile = open.FileName;
                retVal = open.SafeFileName;
            }

            open = null;
            if (PathFile.Length > 0)
            {
                if (MessageBox.Show("Confirma cargar las claves de contingencia registradas en " + Constants.vbCr + PathFile, "CARGA DE CLAVES DE CONTINGENCIA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (MessageBox.Show("Desea eliminar TODAS las claves registradas actualmente ?", "CARGA DE CLAVES DE CONTINGENCIA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        eliminarClavesContingencia();
                    var file = new StreamReader(PathFile);
                    string strClave = file.ReadToEnd();
                    if (strClave.Length > 20)
                    {
                        guardarClavesContingencia(ref strClave);
                        strClave = null;
                    }
                }
            }
        }

        private void cargarClavesContingencia(string PathFile)
        {
            var sr = new StreamReader(PathFile);
            var linee = new char[39];
            int i = 0;
            int j = 37;
            while (sr.ReadBlock(linee, i, j) > 0)
            {
                MessageBox.Show(Conversions.ToString(linee));
                i = +37;
            }
        }

        private void guardarClavesContingencia(ref string clave)
        {
            var conn = new SqlConnection(strConxadcom);
            var comm = new SqlCommand();
            string ssql = "";
            int contador = 0;
            conn.Open();
            for (int i = 0, loopTo = clave.Length - 1; i <= loopTo; i += 38)
            {
                contador += 1;
                ssql = "INSERT INTO [AdcClavContg] ([ClaveContigencia],[UtiDocSucursal],[UtiDocTipo],[UtiDocNumero])";
                ssql += " VALUES";
                ssql += " ('" + clave.Substring(i, 38) + "'";
                ssql += " ,''";
                ssql += " ,''";
                ssql += " ,'')";
                comm = new SqlCommand(ssql, conn);
                comm.ExecuteNonQuery();
            }

            MessageBox.Show("Se almacenaron " + contador.ToString() + " claves de contingencia ");
            conn.Close();
            conn.Dispose();
            comm.Dispose();
        }

        private void eliminarClavesContingencia()
        {
            var conn = new SqlConnection(strConxadcom);
            var comm = new SqlCommand();
            string ssql = "";
            int contador = 0;
            conn.Open();
            ssql = "Delete from [AdcClavContg] ";
            comm = new SqlCommand(ssql, conn);
            contador = comm.ExecuteNonQuery();
            MessageBox.Show("Se eliminaron " + contador.ToString() + " claves de contingencia ");
            conn.Close();
            conn.Dispose();
            comm.Dispose();
        }

        private void btnCorreoXml_Click(object sender, EventArgs e)
        {
            if (IdDocumento.idClave == 0d)
            {
                Interaction.MsgBox("Debe escojer un documento para enviar");
                return;
            }

            // Dim fel = New ClassFelec.AdcFelec(strConxadcom)
            string estadoDocElectronico = LabEstado.Text.Trim();
            // fel = ClassFelec.AdcFelec.Buscar("")

            string pathDocXml = "";
            if (estadoDocElectronico.ToUpper() == "GENERADO")
            {
                pathDocXml = fel.pathCpbGenerados;
            }
            else if (estadoDocElectronico.ToUpper() == "FIRMADO")
            {
                pathDocXml = fel.pathCpbFirmados;
            }
            else if (estadoDocElectronico.ToUpper() == "AUTORIZADO")
            {
                pathDocXml = fel.pathCpbAutorizados;
            }
            else
            {
                MessageBox.Show("No se ha generado el archivo XML del documento ");
                return;
            }

            string pathDocPdf = Feutilidad.PathDocumntosPdf(fel.pathCpbGenerados) + queClaveSRI + ".PDF";
            pathDocXml += queClaveSRI + ".XML";
            if (string.IsNullOrEmpty(FileSystem.Dir(pathDocXml)))
            {
                MessageBox.Show("No se ha generado el archivo XML del documento ");
                return;
            }

            if (string.IsNullOrEmpty(FileSystem.Dir(pathDocPdf)))
            {
                var PROGP = new documentosPdf.generacionPdf(datosEmpresa.nombreBaseIvaret, strConxadcom, strConxIvaret, strConxDaxsys, strConxDaxpro, datosEmpresa.Emp_codigo, datosEmpresa.pathServer);
                PROGP.GeneraDocPdf(IdDocumento, pathDocPdf, "", "FEL" + queClase);
                PROGP = null;
            }

            correoElectronicoDefecto = fel.correoDefecto;
            if (string.IsNullOrEmpty(correoElectronico))
            {
                if (string.IsNullOrEmpty(correoElectronico2))
                {
                    correoElectronico = correoElectronicoDefecto;
                }
                else
                {
                    correoElectronico = correoElectronico2;
                }
            }

            if (verificaCorreoElectronico(ref correoElectronico) == false)
            {
                MessageBox.Show("No existe una dirección de correo electrónico o ´la dirección está errada ");
                return;
            }

            // Dim PROG As ImprDoct.classEmail = New ImprDoct.classEmail()
            // PROG.enviarMailDoc("", pathDocXml, "", correoElectronico, strConxDaxsys, queClaveSRI, "", pathDocPdf)
            string adjuntos = pathDocXml + ";" + pathDocPdf;

            // Dim PROG As ImprDoct.frmEnvioCorreo = New ImprDoct.frmEnvioCorreo(strConxDaxsys, correoElectronico, correoElectronico2, "Envio documentos electronicos", "Documento: " + queClase + " - " + IdDocumento.numero.ToString() + " ", adjuntos)
            // PROG.ShowDialog()
            // PROG.Dispose()
        }

        private void chkCotingencia_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOnLine.Checked == true)
                chkOnLine.BackColor = System.Drawing.Color.Red;
            else
                chkOnLine.BackColor = System.Drawing.Color.White;
        }

        private void btnGenerarGrupo_Click(object sender, EventArgs e)
        {
            var progsel = new BuscadorDocumentos.frmSeleccDoc();
            var listaDeDocumentos = new BuscadorDocumentos.listaDocumentos();
            listaDeDocumentos = progsel.EscojerVariosDocumentos("ELE");
            colecError.Clear();
            progsel.ShowDialog();
            progsel.Dispose();
            if (listaDeDocumentos.IdDocs.Count > 0)
            {
                // AdcGenxml.classDatEmp.cargarDatosDeNuestraEmpresa(emp.ruc, strConxadcom)
                // If Not valida() Then Exit Sub
                GenerarDocumentoXML genxml;
                tipoEmision = 1;
                // If chkOnLine.Checked = True Then tipoEmision = 2
                // If progsel.filasSelecc.Count = 0 Then Return

                if (MessageBox.Show("Se procesarán " + listaDeDocumentos.IdDocs.Count.ToString() + " documentos " + Constants.vbCrLf + " CONFIRMA CONTINUAR ?", "Autorización de documentos electrónicos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
                Cursor = Cursors.WaitCursor;
                var iddoc = new idDocumento();
                string queClave;
                // Dim dxlib = New DaxLib.DaxLibBases()
                // dxlib.TipoBase = "10"
                // Dim fel = New ClassFelec.AdcFelec(dxlib.StrAdcom())
                // fel = ClassFelec.AdcFelec.Buscar("")
                // dxlib = Nothing
                string ambiente = "2";
                if (fel.ambienteEnProduccion == false)
                    ambiente = "1";
                for (int i = 0, loopTo = listaDeDocumentos.IdDocs.Count - 1; i <= loopTo; i++)
                {
                    Errores = "";
                    iddoc = new idDocumento();
                    iddoc = listaDeDocumentos.IdDocs[i];
                    IdDocumento = iddoc;
                    genxml = new GenerarDocumentoXML();
                    queClave = genxml.documentoAenviar(iddoc.Sucursal, iddoc.Tipo, iddoc.numero.ToString(), iddoc.idClave, ref PathFile, iddoc.familia, datosEmpresa.Emp_RUC, datosEmpresa.Par_DigitosPrecios, datosEmpresa.pathAppl, tipoEmision, chkOnLine.Checked);
                    if (queClave.Substring(0, 5).ToUpper() == "ERROR")
                    {
                        Errores = iddoc.Sucursal + "-" + iddoc.Tipo + "-" + iddoc.numero.ToString() + "  " + queClave + " Genera XML ";
                    }
                    else
                    {
                        queClaveSRI = queClave.ToUpper();
                        var FM = new Firma();
                        FM.strFileXml = queClaveSRI;
                        string resp = FM.FirmarArchivoXML(strConxadcom);
                        FM = null;
                        if (resp.Substring(0, 5).ToUpper() != "ERROR")
                        {
                            leerDocumentoAdcom();
                            PathFile = fel.pathCpbFirmados + queClaveSRI + ".xml";
                            string pathAutorizados = fel.pathCpbAutorizados + queClaveSRI + ".xml";
                            string pathNoAutorizados = fel.pathpbNoAutorizados + queClaveSRI + ".xml";
                            string pathErrores = pathNoAutorizados.Replace("xml", "ERR");
                            correoElectronicoDefecto = fel.correoDefecto;
                            var prog = new EnviarComprobanteSri();
                            if (prog.sendComprobanteSRI(PathFile, queClaveSRI, pathAutorizados, pathNoAutorizados, chkOnLine.Checked, ambiente, strConxadcom) == true)
                            {

                                // ImpDoc(IdDocumento.IdClave, emp.SucActual, IdDocumento.Tipo, IdDocumento.Numero, "A", "F", "", "FEL" + queClase, "")

                                string ArchivoXML = pathAutorizados;
                                var ProgPdf = new documentosPdf.generacionPdf(datosEmpresa.nombreBaseIvaret, strConxadcom, strConxIvaret, strConxDaxsys, strConxDaxpro, datosEmpresa.Emp_codigo, datosEmpresa.pathServer);
                                string nombrePdf = Feutilidad.PathDocumntosPdf(fel.pathCpbGenerados) + queClaveSRI + ".PDF";
                                ProgPdf.GeneraDocPdf(IdDocumento, nombrePdf, "", "FEL" + iddoc.familia);
                                prog = null;
                                if (!(string.IsNullOrEmpty(fel.consumidorFinal) & (fel.consumidorFinal ?? "") == (queCodigoCliente ?? "")))
                                {
                                    if (verificaCorreoElectronico(ref correoElectronico) == true)
                                    {
                                        var eMail = new ClassDaxMail.EnvCorreoSmtp(datosEmpresa.strConxDaxsys, datosEmpresa.codEmpresa);
                                        string docMensaje = "Enviamos documento electrónico  " + Constants.vbCrLf + "Favor confirmar su recepción";
                                        eMail.EnviarCorreo(correoElectronico2, correoElectronico, "Envío documentos electrónicos" + iddoc.Tipo + iddoc.numero.ToString(), "", ArchivoXML, nombrePdf, datosEmpresa.Emp_PathImagenes + "firmaElectronica");
                                        eMail = null;
                                    }
                                    else
                                    {
                                        Errores = iddoc.Sucursal + "-" + iddoc.Tipo + "-" + iddoc.numero.ToString() + "  " + queClaveSRI + " no tiene un correo electrónico valido " + correoElectronico;
                                    }

                                    try
                                    {
                                        File.Delete(nombrePdf);
                                    }
                                    catch
                                    {
                                    }
                                }
                                else
                                {
                                }
                            }
                            else
                            {
                                Errores = iddoc.Sucursal + "-" + iddoc.Tipo + "-" + iddoc.numero.ToString() + "  " + queClaveSRI + " autorizando ";
                                Errores += publicarMensaje(pathErrores);
                            }
                        }
                        else
                        {
                            Errores = iddoc.Sucursal + "-" + iddoc.Tipo + "-" + iddoc.numero.ToString() + "  " + queClave + " Firmando  ";
                        }
                    }

                    if (Errores.Length > 0)
                        almacenarErrores(Errores);
                }
                // fel = Nothing
                genxml = null;
                Cursor = Cursors.Default;
                if (colecError.Count > 0)
                {
                    Interaction.MsgBox("proceso terminado, existen errores ");
                    var prog = new DaxValDocElec.frmVisor(colecError, "Errores en autorización de documentos electrónicos");
                    prog.Show();
                }
                else
                {
                    Interaction.MsgBox("proceso terminado exitosamente ");
                }
            }
        }

        private bool verificaCorreoElectronico(ref string correoElectronico)
        {
            if (correoElectronico.Length == 0)
                correoElectronico = correoElectronicoDefecto;
            if (correoElectronico.Length == 0)
                return false;
            return DaxValDocElec.ValidacionesDocElectronicos.ValidarEmail(correoElectronico);
        }

        private void almacenarErrores(string err)
        {
            colecError.Add(err);
        }

        private void configurarBotones()
        {
            // Dim Estado As Boolean = (IdClaveDoc = 0)
            // btnAbre.Enabled = Estado
            // btnGenerarGrupo.Enabled = Estado

            // btnAutorizar.Enabled = Not Estado
            // btnCorreoXml.Enabled = Not Estado
            // btn.Enabled = Not Estado
            // btnFirmar.Enabled = Not Estado
            // btnGenerar.Enabled = Not Estado
        }

        private void ToolStrip5_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
        }

        private void btnElimina_Click(object sender, EventArgs e)
        {
        }
    }
}