Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports ClassDoc
Imports SysEmpDatt
Imports System.Collections.Generic

Public Class frmMntDocElectrncos

    Dim IdDocumento As New ClassDoc.idDocumento
    Dim queClaveSRI As String = ""
    Dim queCodigoCliente As String = ""
    Dim queFecha As DateTime = DateTime.Now
    Dim queClase As String
    Dim String3 As String = ""
    Dim PathFile As String = ""
    Dim strConxadcom As String = ""
    Dim strConxIvaret As String = ""
    Dim strConxDaxsys As String = ""
    Dim strConxDaxpro As String = ""
    Dim correoElectronico As String = ""
    Dim correoElectronico2 As String = ""
    Dim correoElectronicoDefecto As String = ""
    Dim tipoEmision As Short = 0
    Dim Errores As String = ""
    Dim colecError As New List(Of String)
    Dim EsOnLine As Boolean = False
    Dim fel As DaxDocElectronicos.AdcFelec


    Private Function getXML() As String
        Dim open As New OpenFileDialog
        Dim retVal As String = String.Empty
        '--------------------------------------------------------------------------------------------
        open.Filter = "Archivos XML(*.xml)|*.xml"
        '--------------------------------------------------------------------------------------------
        If open.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            PathFile = open.FileName
            retVal = open.SafeFileName
        End If
        '--------------------------------------------------------------------------------------------
        getXML = retVal
        '--------------------------------------------------------------------------------------------
        open = Nothing
    End Function

    'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim fileName As String = getXML()
    '    '--------------------------------------------------------------------------------------------
    '    If fileName <> String.Empty Then
    '        Dim prog As New EnviarComprobanteSri
    '        prog.sendComprobanteSRI(fileName, queClaveSRI)
    '    End If
    'End Sub

    Private Sub btnAbre_Click(sender As System.Object, e As System.EventArgs)
        Dim progBus As New BuscadorDocumentos.buscadorDoc()
        'MsgBox(Application.StartupPath())        
        progBus.IniciaBusqueda("ELE", "", "", queFecha, IdDocumento.Sucursal, IdDocumento.Tipo, IdDocumento.numero, IdDocumento.idClave, False, "", "", "", "ADCDOC")
        mensaje.Text = ""
        leerDocumentoAdcom()
    End Sub

    Private Sub leerDocumentoAdcom()
        Dim progdoc = New AdcDoc(strConxadcom)
        Dim dt As New DataTable
        Dim ssql As String = "SELECT AdcDoc.*, Identificacion.CorreoElectrónico as correo1, Identificacion.Paginaweb as correo2 FROM Adcdoc "
        ssql += " LEFT OUTER JOIN Identificacion ON AdcDoc.Doc_codper = Identificacion.Codigo "
        If IdDocumento.idClave = 0 And queClaveSRI > "" Then
            ssql += " WHERE clavesri = '" & queClaveSRI & "' "
        Else
            ssql += " WHERE doc_sucursal = '" & IdDocumento.Sucursal & "' and opc_documento = '" & IdDocumento.Tipo & "' and idclavedoc = " & IdDocumento.idClave.ToString()
        End If

        dt = AdcDoc.Tabla(ssql)
        If dt.Rows.Count < 1 Then MsgBox("No existe el documento seleccionado") : Return
        IdDocumento.Sucursal = dt.Rows(0)("Doc_sucursal").ToString()
        IdDocumento.Tipo = dt.Rows(0)("opc_documento").ToString()
        IdDocumento.idClave = CDbl(dt.Rows(0)("IdclaveDoc"))
        IdDocumento.numero = CDbl(dt.Rows(0)("Doc_numero").ToString())
        queClase = dt.Rows(0)("doc_tipodoc").ToString()
        queClaveSRI = dt.Rows(0)("claveSri").ToString()
        LabCiRuc.Text = dt.Rows(0)("Doc_CiRuc").ToString()
        LabClave.Text = dt.Rows(0)("claveSri").ToString()
        LabEstado.Text = dt.Rows(0)("estadoSri").ToString()
        LabFechaAutoriza.Text = dt.Rows(0)("fechaAutorizacion").ToString()
        LabId.Text = dt.Rows(0)("Doc_nroiddoc").ToString()
        LabNombre.Text = dt.Rows(0)("Doc_nombreImp").ToString()
        LabNumero.Text = dt.Rows(0)("Doc_numero").ToString()
        LabNumeroAutoriza.Text = dt.Rows(0)("nroAutorizacionSri").ToString()
        LabTipo.Text = dt.Rows(0)("opc_documento").ToString()
        queCodigoCliente = dt.Rows(0)("Doc_codper").ToString()
        correoElectronico = dt.Rows(0)("Correo1").ToString()
        correoElectronico2 = dt.Rows(0)("Correo2").ToString()
        dt.Dispose()
        progdoc = Nothing
        configurarBotones()
    End Sub
    'Private Sub leerCorreoCliente(codigo As String)
    '    Dim prog As New MantenimientoDirectorio.DirectorioAlex
    '    If prog.CargarAlex(codigo, True) = True Then
    '        correoElectronico = prog.correoElectronico
    '    Else
    '        correoElectronico = ""
    '    End If
    '    prog = Nothing
    'End Sub
    'Private Sub leerCorreosClienteConDoc(iddoc As ClassDoc.idDocumento)

    '    Dim ssql As String = "SELECT AdcDoc.Doc_codper, Identificacion.CorreoElectrónico as correo1, Identificacion.Paginaweb as correo2 FROM " & tablaDoc
    '    ssql += " LEFT OUTER JOIN Identificacion ON AdcDoc.Doc_codper = Identificacion.Codigo "
    '    ssql += " WHERE doc_sucursal = '" & iddoc.Sucursal & "' and opc_documento = '" & iddoc.Tipo & "' and idclavedoc = " & iddoc.idClave.ToString()


    '    Dim dr = New SqlDataAdapter(ssql, strConxadcom)
    '    Dim dt As New DataTable
    '    dr.fill(dt)

    '    If dt.Rows.Count < 1 Then Errores = "No existe el documento seleccionado"
    '    IdDocumento.Sucursal = dt.Rows(0)("Doc_sucursal").ToString()
    '    IdDocumento.Tipo = dt.Rows(0)("opc_documento").ToString()
    '    IdClaveDoc = CDbl(dt.Rows(0)("IdclaveDoc"))
    '    IdDocumento.Numero = CDbl(dt.Rows(0)("Doc_numero").ToString())
    '    queClase = dt.Rows(0)("doc_tipodoc").ToString()
    '    queClaveSRI = dt.Rows(0)("claveSri").ToString()
    '    correoElectronico = dt.Rows(0)("Correo1").ToString()
    '    correoElectronico2 = dt.Rows(0)("Correo2").ToString()
    '    dt.Dispose()
    '    dr.Dispose()

    'End Sub
    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        strConxadcom = datosEmpresa.strConxAdcom
        strConxIvaret = datosEmpresa.strConxIvaret
        strConxDaxsys = datosEmpresa.strConxDaxsys
        strConxDaxpro = datosEmpresa.strConxDaxpro
        If datosEmpresa.Emp_codigo = 0 Then Close()
        fel = New DaxDocElectronicos.AdcFelec(strConxadcom)
        fel = DaxDocElectronicos.AdcFelec.Buscar("")
        IdDocumento.Sucursal = datosEmpresa.suc
        revisarFacturas(strConxadcom)
        configurarBotones()
    End Sub
    Private Sub revisarFacturas(strAdcom As String)
        Using conn As SqlConnection = New SqlConnection(strAdcom)
            conn.Open()
            Using comm As SqlCommand = New SqlCommand("dax_setIdSri " + datosEmpresa.Emp_codigo.ToString() + ",'" + datosEmpresa.suc + "'", conn)
                comm.ExecuteNonQuery()
            End Using
        End Using
    End Sub
    Private Sub activarContingencia()
        Dim rs As New DataTable
        Dim ssql As String = "select top(1) clavecontigencia from adcclavcontg where utidoctipo = '' and clavecontigencia > '' "
        Dim da As New SqlDataAdapter(ssql, strConxadcom)
        da.Fill(rs)
        If rs.Rows.Count = 0 Then chkOnLine.Visible = False Else chkOnLine.Visible = True
    End Sub

    Private Sub btnEnviar_Click(sender As System.Object, e As System.EventArgs) Handles btnEnviar.Click
        If IdDocumento.idClave = 0 Then MsgBox("Debe escojer un documento para enviar") : Exit Sub
        verificaCorreoElectronico(correoElectronico)
        ImpDoc(IdDocumento.idClave, datosEmpresa.suc, IdDocumento.Tipo, IdDocumento.numero, "A", "F", "", "FEL" + queClase, "")
    End Sub

    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Close()
    End Sub

    Private Sub firmarDocumento()
        ' firmar comprobante
        If queClaveSRI = "" Then
            queClaveSRI = getXML().ToUpper()
            queClaveSRI = queClaveSRI.Replace(".XML", "")
        End If
        If queClaveSRI = "" Then Exit Sub
        mensaje.Text = ""
        leerDocumentoAdcom()
        Dim FM = New DaxDocElectronicos.Firma()
        FM.strFileXml = queClaveSRI
        Dim resp As String = FM.FirmarArchivoXML(strConxadcom)
        MsgBox(resp)
        FM = Nothing
        leerDocumentoAdcom()
    End Sub
    'Private Sub EjecutarProgramaExterno(ByVal programa As String, ByVal NombreOpcion As String)
    '    Try
    '        Dim existe As Integer
    '        Dim OPCION As String = ""
    '        emp.String2 = ""
    '        existe = Len(Dir(emp.PatAppl & programa))
    '        If existe > 0 Then
    '            Dim pi As New System.Diagnostics.ProcessStartInfo()
    '            pi.FileName = programa
    '            pi.Arguments = NombreOpcion
    '            pi.WorkingDirectory = emp.PatAppl
    '            pi.WindowStyle = ProcessWindowStyle.Normal
    '            System.Diagnostics.Process.Start(pi)
    '        End If
    '    Catch ee As Exception
    '        MsgBox("excepción ProgExt: " & ee.Message)
    '    End Try
    'End Sub

    Private Function valida() As Boolean
        Dim resp As Boolean = True
        If IdDocumento.idClave = 0 Or IdDocumento.Tipo = "" Then
            MsgBox("Debe abrir un documento para utilizar esta opción", MsgBoxStyle.Information, "Operación con factura electronica")
            resp = False
        End If
        Return resp
    End Function

    Private Sub btnGenerar_Click(sender As System.Object, e As System.EventArgs) Handles btnGenerar.Click
        classDatEmp.cargarDatosDeNuestraEmpresa(datosEmpresa.Emp_RUC, strConxadcom)
        If Not valida() Then Exit Sub
        Dim genxml As New DaxDocElectronicos.GenerarDocumentoXML()
        tipoEmision = 1
        If chkOnLine.Checked = True Then EsOnLine = True
        Dim queClave As String = genxml.documentoAenviar(IdDocumento.Sucursal, IdDocumento.Tipo, CStr(IdDocumento.numero), IdDocumento.idClave, PathFile, queClase, datosEmpresa.Emp_RUC, datosEmpresa.Par_DigitosPrecios, datosEmpresa.pathAppl, tipoEmision, chkOnLine.Checked)
        If queClave.Substring(0, 5).ToUpper() = "ERROR" Then
            MessageBox.Show("EXISTEN ERRORES EN EL DOCUMENTO: " & queClave.Substring(5))
            publicarMensaje(PathFile.Replace("XML", "ERR"))
        Else
            queClaveSRI = queClave
            PrepararEnvios(queClase)
        End If
        mensaje.Text = ""
        leerDocumentoAdcom()
        genxml = Nothing
    End Sub
    Private Sub PrepararEnvios(TipoDoc As String)
        Dim nombrePdf As String = DaxDocElectronicos.Feutilidad.PathDocumntosPdf(fel.pathCpbGenerados) + queClaveSRI + ".PDF"
        Dim FormaImpresionDocumento As String = "FEL" + TipoDoc
        Dim PROG As New documentosPdf.generacionPdf(datosEmpresa.nombreBaseIvaret, strConxadcom, strConxIvaret, strConxDaxsys, strConxDaxpro, datosEmpresa.Emp_codigo, datosEmpresa.pathServer)
        PROG.GeneraDocPdf(IdDocumento, nombrePdf, "", FormaImpresionDocumento)
        PROG = Nothing
    End Sub

    'Private Sub LeerDocumentoAdcom(clave As String)
    '    Dim ssql As String = "update adcdoc set claveSri='" & clave & "' "
    '    Dim daxlib As New DaxLib.DaxLibBases()
    '    daxlib.TipoBase = "10"
    '    Dim conn As New SqlConnection(daxlib.StrAdcom())
    '    conn.Open()
    '    daxlib = Nothing
    '    Dim comm As New SqlCommand(ssql, conn)
    '    comm.ExecuteNonQuery()
    '    comm.Dispose()
    '    conn.Close()
    '    conn.Dispose()
    'End Sub

    Private Sub btnAutorizar_Click(sender As System.Object, e As System.EventArgs) Handles btnAutorizar.Click
        If queClaveSRI = "" Then
            queClaveSRI = getXML().ToUpper()
            queClaveSRI = queClaveSRI.Replace(".XML", "")
        End If
        AutorizarDocumento()
    End Sub
    Private Sub AutorizarDocumento()
        If queClaveSRI = "" Then Exit Sub
        mensaje.Text = ""
        leerDocumentoAdcom()
        Dim pathAutorizados As String = fel.pathCpbAutorizados + queClaveSRI + ".xml"
        Dim pathNoAutorizados As String = fel.pathpbNoAutorizados + queClaveSRI + ".xml"
        Dim pathErrores As String = pathNoAutorizados.Replace("xml", "ERR")
        correoElectronicoDefecto = fel.correoDefecto
        Dim ambiente As String = "2"
        If fel.ambienteEnProduccion = False Then ambiente = "1"
        Dim prog As New DaxDocElectronicos.EnviarComprobanteSri()
        If prog.sendComprobanteSRI(PathFile, queClaveSRI, pathAutorizados, pathNoAutorizados, chkOnLine.Checked, ambiente, strConxadcom) = True Then
            PrepararEnvios(queClase)
            MsgBox("Documento autorizado sin novedades")
        Else
            MsgBox("documento no autorizado")
            mensaje.Text = publicarMensaje(pathErrores)
        End If
        leerDocumentoAdcom()

        '        fel = Nothing
    End Sub
    'Private Sub tablasDeDatos(ByVal docTipo As String, ByRef tablaDoc As String, ByRef tablaTra As String)
    '    Dim ssql As String = "select * from adcopc where opc_documento = '" & docTipo & "' "
    '    Dim progdoc = New AdcDoc(strConxadcom)
    '    Dim dats = AdcDoc.Tabla(ssql)
    '    Select Case dats.Rows(0)("opc_tipo").ToString().ToUpper()
    '        Case "PEP", "PRC", "PRP", "REQ"
    '            tablaDoc = "ADCDOCPRO"
    '            tablaTra = "ADCTRAPRO"
    '        Case Else
    '            tablaDoc = "ADCDOC"
    '            tablaTra = "ADCTRA"
    '    End Select
    '    dats.Dispose()
    '    progdoc = Nothing
    'End Sub

    Public Sub ImpDoc(IdClaveDocC As Double, Sucursal As String, TipoDocumento As String, NumeroDocumento As Double,
            Optional QueSystema As String = "A", Optional FacturaProforma As String = "F", Optional AuxManual As String = "", Optional otraimp As String = "", Optional ImpCtb As String = "")
        '        Try
        'Dim pasar As String = ""
        'Dim prog As New ImprDoct.ImprimirDoc
        'prog.CorreoElectronico = correoElectronico
        'prog.claveSri = queClaveSRI
        'pasar = QueSystema & "," & FacturaProforma & "," & AuxManual & "," & otraimp & "," & ImpCtb
        'prog.ImprimeDocMail(IdClaveDocC, Sucursal, TipoDocumento, NumeroDocumento, pasar)
        'prog = Nothing
        'Catch
        'End Try
    End Sub

    Private Function publicarMensaje(file As String) As String
        Dim STR As String = ""
        Try
            Dim Rfile As New System.IO.StreamReader(file)
            STR = Rfile.ReadToEnd
        Catch
        End Try
        Return STR
    End Function

    Private Sub btnContingencia_Click(sender As System.Object, e As System.EventArgs) Handles btn.Click
        Dim open As New OpenFileDialog
        Dim retVal As String = String.Empty
        '--------------------------------------------------------------------------------------------
        open.Filter = "Archivos TXT(*.TXT)|*.TXT"
        '--------------------------------------------------------------------------------------------
        If open.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            PathFile = open.FileName
            retVal = open.SafeFileName
        End If
        open = Nothing
        If PathFile.Length > 0 Then
            If (MessageBox.Show("Confirma cargar las claves de contingencia registradas en " & vbCr & PathFile, "CARGA DE CLAVES DE CONTINGENCIA", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) = Windows.Forms.DialogResult.Yes Then
                If (MessageBox.Show("Desea eliminar TODAS las claves registradas actualmente ?", "CARGA DE CLAVES DE CONTINGENCIA", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) = Windows.Forms.DialogResult.Yes Then eliminarClavesContingencia()
                Dim file As New System.IO.StreamReader(PathFile)
                Dim strClave As String = file.ReadToEnd
                If strClave.Length > 20 Then guardarClavesContingencia(strClave) : strClave = Nothing
            End If
        End If
    End Sub

    Private Sub cargarClavesContingencia(PathFile As String)
        Dim sr = New StreamReader(PathFile)
        Dim linee(38) As Char
        Dim i As Integer = 0
        Dim j As Integer = 37
        Do While ((sr.ReadBlock(linee, i, j) > 0))
            MessageBox.Show(linee)
            i = +37
        Loop
    End Sub

    Private Sub guardarClavesContingencia(ByRef clave As String)
        Dim conn As New SqlConnection(strConxadcom)
        Dim comm As New SqlCommand()
        Dim ssql As String = ""
        Dim contador As Integer = 0
        conn.Open()
        For i As Integer = 0 To clave.Length - 1 Step 38
            contador += 1
            ssql = "INSERT INTO [AdcClavContg] ([ClaveContigencia],[UtiDocSucursal],[UtiDocTipo],[UtiDocNumero])"
            ssql += " VALUES"
            ssql += " ('" & clave.Substring(i, 38) & "'"
            ssql += " ,''"
            ssql += " ,''"
            ssql += " ,'')"
            comm = New SqlCommand(ssql, conn)
            comm.ExecuteNonQuery()
        Next
        MessageBox.Show("Se almacenaron " & contador.ToString() & " claves de contingencia ")
        conn.Close()
        conn.Dispose()
        comm.Dispose()
    End Sub

    Private Sub eliminarClavesContingencia()
        Dim conn As New SqlConnection(strConxadcom)
        Dim comm As New SqlCommand()
        Dim ssql As String = ""
        Dim contador As Integer = 0
        conn.Open()
        ssql = "Delete from [AdcClavContg] "
        comm = New SqlCommand(ssql, conn)
        contador = comm.ExecuteNonQuery()
        MessageBox.Show("Se eliminaron " & contador.ToString() & " claves de contingencia ")
        conn.Close()
        conn.Dispose()
        comm.Dispose()
    End Sub

    Private Sub btnCorreoXml_Click(sender As System.Object, e As System.EventArgs) Handles btnCorreoXml.Click
        If IdDocumento.idClave = 0 Then MsgBox("Debe escojer un documento para enviar") : Exit Sub

        '        Dim fel = New ClassFelec.AdcFelec(strConxadcom)
        Dim estadoDocElectronico As String = LabEstado.Text.Trim()
        'fel = ClassFelec.AdcFelec.Buscar("")

        Dim pathDocXml As String = ""

        If estadoDocElectronico.ToUpper() = "GENERADO" Then
            pathDocXml = fel.pathCpbGenerados
        ElseIf estadoDocElectronico.ToUpper() = "FIRMADO" Then
            pathDocXml = fel.pathCpbFirmados
        ElseIf estadoDocElectronico.ToUpper() = "AUTORIZADO" Then
            pathDocXml = fel.pathCpbAutorizados
        Else
            MessageBox.Show("No se ha generado el archivo XML del documento ")
            Return
        End If

        Dim pathDocPdf As String = DaxDocElectronicos.Feutilidad.PathDocumntosPdf(fel.pathCpbGenerados) + queClaveSRI + ".PDF"
        pathDocXml += queClaveSRI + ".XML"

        If (Dir(pathDocXml) = "") Then
            MessageBox.Show("No se ha generado el archivo XML del documento ")
            Return
        End If

        If (Dir(pathDocPdf) = "") Then
            Dim PROGP As New documentosPdf.generacionPdf(datosEmpresa.nombreBaseIvaret, strConxadcom, strConxIvaret, strConxDaxsys, strConxDaxpro, datosEmpresa.Emp_codigo, datosEmpresa.pathServer)
            PROGP.GeneraDocPdf(IdDocumento, pathDocPdf, "", "FEL" + queClase)
            PROGP = Nothing
        End If

        correoElectronicoDefecto = fel.correoDefecto
        If (correoElectronico = "") Then
            If correoElectronico2 = "" Then
                correoElectronico = correoElectronicoDefecto
            Else
                correoElectronico = correoElectronico2
            End If
        End If

        If verificaCorreoElectronico(correoElectronico) = False Then
            MessageBox.Show("No existe una dirección de correo electrónico o ´la dirección está errada ")
            Return
        End If

        'Dim PROG As ImprDoct.classEmail = New ImprDoct.classEmail()
        'PROG.enviarMailDoc("", pathDocXml, "", correoElectronico, strConxDaxsys, queClaveSRI, "", pathDocPdf)
        Dim adjuntos As String = pathDocXml + ";" + pathDocPdf

        'Dim PROG As ImprDoct.frmEnvioCorreo = New ImprDoct.frmEnvioCorreo(strConxDaxsys, correoElectronico, correoElectronico2, "Envio documentos electronicos", "Documento: " + queClase + " - " + IdDocumento.numero.ToString() + " ", adjuntos)
        'PROG.ShowDialog()
        'PROG.Dispose()
    End Sub

    Private Sub chkCotingencia_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkOnLine.CheckedChanged
        If chkOnLine.Checked = True Then chkOnLine.BackColor = Drawing.Color.Red Else chkOnLine.BackColor = Drawing.Color.White
    End Sub

    Private Sub btnGenerarGrupo_Click(sender As Object, e As EventArgs) Handles btnGenerarGrupo.Click
        Dim progsel As New BuscadorDocumentos.frmSeleccDoc
        Dim listaDeDocumentos = New BuscadorDocumentos.listaDocumentos()
        listaDeDocumentos = progsel.EscojerVariosDocumentos("ELE")
        colecError.Clear()
        progsel.ShowDialog()
        progsel.Dispose()
        If listaDeDocumentos.IdDocs.Count > 0 Then
            'AdcGenxml.classDatEmp.cargarDatosDeNuestraEmpresa(emp.ruc, strConxadcom)
            'If Not valida() Then Exit Sub
            Dim genxml As DaxDocElectronicos.GenerarDocumentoXML
            tipoEmision = 1
            '            If chkOnLine.Checked = True Then tipoEmision = 2
            'If progsel.filasSelecc.Count = 0 Then Return

            If MessageBox.Show("Se procesarán " + listaDeDocumentos.IdDocs.Count.ToString() + " documentos " + vbCrLf + " CONFIRMA CONTINUAR ?", "Autorización de documentos electrónicos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Return

            Me.Cursor = Cursors.WaitCursor
            Dim iddoc As New ClassDoc.idDocumento
            Dim queClave As String
            'Dim dxlib = New DaxLib.DaxLibBases()
            'dxlib.TipoBase = "10"
            'Dim fel = New ClassFelec.AdcFelec(dxlib.StrAdcom())
            'fel = ClassFelec.AdcFelec.Buscar("")
            'dxlib = Nothing
            Dim ambiente As String = "2"
            If fel.ambienteEnProduccion = False Then ambiente = "1"

            For i = 0 To listaDeDocumentos.IdDocs.Count - 1
                Errores = ""
                iddoc = New ClassDoc.idDocumento
                iddoc = CType(listaDeDocumentos.IdDocs.Item(i), idDocumento)

                IdDocumento = iddoc

                genxml = New DaxDocElectronicos.GenerarDocumentoXML()
                queClave = genxml.documentoAenviar(iddoc.Sucursal, iddoc.Tipo, CStr(iddoc.numero), iddoc.idClave, PathFile, iddoc.familia, datosEmpresa.Emp_RUC, datosEmpresa.Par_DigitosPrecios, datosEmpresa.pathAppl, tipoEmision, chkOnLine.Checked)

                If queClave.Substring(0, 5).ToUpper() = "ERROR" Then
                    Errores = iddoc.Sucursal + "-" + iddoc.Tipo + "-" + iddoc.numero.ToString() + "  " + queClave + " Genera XML "
                Else
                    queClaveSRI = queClave.ToUpper()

                    Dim FM = New DaxDocElectronicos.Firma()
                    FM.strFileXml = queClaveSRI
                    Dim resp As String = FM.FirmarArchivoXML(strConxadcom)
                    FM = Nothing

                    If resp.Substring(0, 5).ToUpper() <> "ERROR" Then
                        leerDocumentoAdcom()
                        PathFile = fel.pathCpbFirmados + queClaveSRI + ".xml"
                        Dim pathAutorizados As String = fel.pathCpbAutorizados + queClaveSRI + ".xml"
                        Dim pathNoAutorizados As String = fel.pathpbNoAutorizados + queClaveSRI + ".xml"
                        Dim pathErrores As String = pathNoAutorizados.Replace("xml", "ERR")
                        correoElectronicoDefecto = fel.correoDefecto
                        Dim prog As New DaxDocElectronicos.EnviarComprobanteSri()
                        If prog.sendComprobanteSRI(PathFile, queClaveSRI, pathAutorizados, pathNoAutorizados, chkOnLine.Checked, ambiente, strConxadcom) = True Then

                            'ImpDoc(IdDocumento.IdClave, emp.SucActual, IdDocumento.Tipo, IdDocumento.Numero, "A", "F", "", "FEL" + queClase, "")

                            Dim ArchivoXML As String = pathAutorizados

                            Dim ProgPdf As New documentosPdf.generacionPdf(datosEmpresa.nombreBaseIvaret, strConxadcom, strConxIvaret, strConxDaxsys, strConxDaxpro, datosEmpresa.Emp_codigo, datosEmpresa.pathServer)
                            Dim nombrePdf As String = DaxDocElectronicos.Feutilidad.PathDocumntosPdf(fel.pathCpbGenerados) + queClaveSRI + ".PDF"
                            ProgPdf.GeneraDocPdf(IdDocumento, nombrePdf, "", "FEL" + iddoc.familia)
                            prog = Nothing

                            If Not (fel.consumidorFinal = "" And fel.consumidorFinal = queCodigoCliente) Then
                                If verificaCorreoElectronico(correoElectronico) = True Then
                                    Dim eMail = New ClassDaxMail.EnvCorreoSmtp(datosEmpresa.strConxDaxsys, datosEmpresa.codEmpresa)
                                    Dim docMensaje As String = "Enviamos documento electrónico  " + vbCrLf + "Favor confirmar su recepción"
                                    eMail.EnviarCorreo(correoElectronico2, correoElectronico, "Envío documentos electrónicos" + iddoc.Tipo + iddoc.numero.ToString(), "", ArchivoXML, nombrePdf, datosEmpresa.Emp_PathImagenes + "firmaElectronica")
                                    eMail = Nothing
                                Else
                                    Errores = iddoc.Sucursal + "-" + iddoc.Tipo + "-" + iddoc.numero.ToString() + "  " + queClaveSRI + " no tiene un correo electrónico valido " + correoElectronico
                                End If

                                Try
                                    System.IO.File.Delete(nombrePdf)
                                Catch
                                End Try
                            Else

                            End If
                        Else
                            Errores = iddoc.Sucursal + "-" + iddoc.Tipo + "-" + iddoc.numero.ToString() + "  " + queClaveSRI + " autorizando "
                            Errores += publicarMensaje(pathErrores)
                        End If
                    Else
                        Errores = iddoc.Sucursal + "-" + iddoc.Tipo + "-" + iddoc.numero.ToString() + "  " + queClave + " Firmando  "
                    End If
                End If
                If Errores.Length > 0 Then almacenarErrores(Errores)
            Next
            '            fel = Nothing
            genxml = Nothing
            Me.Cursor = Cursors.Default

            If colecError.Count > 0 Then
                MsgBox("proceso terminado, existen errores ")
                Dim prog As New DaxValDocElec.frmVisor(colecError, "Errores en autorización de documentos electrónicos")
                prog.Show()
            Else
                MsgBox("proceso terminado exitosamente ")
            End If

        End If
    End Sub
    Private Function verificaCorreoElectronico(ByRef correoElectronico As String) As Boolean
        If correoElectronico.Length = 0 Then correoElectronico = correoElectronicoDefecto
        If correoElectronico.Length = 0 Then Return False
        Return DaxValDocElec.ValidacionesDocElectronicos.ValidarEmail(correoElectronico)
    End Function
    Private Sub almacenarErrores(err As String)
        colecError.Add(err)
    End Sub
    Private Sub configurarBotones()
        'Dim Estado As Boolean = (IdClaveDoc = 0)
        'btnAbre.Enabled = Estado
        'btnGenerarGrupo.Enabled = Estado

        'btnAutorizar.Enabled = Not Estado
        'btnCorreoXml.Enabled = Not Estado
        'btn.Enabled = Not Estado
        'btnFirmar.Enabled = Not Estado
        'btnGenerar.Enabled = Not Estado
    End Sub

    Private Sub ToolStrip5_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStrip5.ItemClicked

    End Sub

    Private Sub btnElimina_Click(sender As Object, e As EventArgs)

    End Sub
End Class
