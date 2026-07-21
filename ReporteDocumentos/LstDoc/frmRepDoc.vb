Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Imports DattCom

Public Class frmRepDoc
    Dim botonOp As Boolean = False
    Dim fecHasta As Date = Date.Now
    Dim fecDesde As Date = New Date(fecHasta.Year, fecHasta.Month, 1)
    Dim opSoloTot As Boolean = False
    Dim codClienteIni As String = ""
    Dim codClienteFin As String = ""
    Dim tipo As String = "V"
    Dim suc As String = ""
    Dim bod As String = ""
    Dim doc As String = ""
    Dim vend As String = ""
    Dim det As String = ""
    Dim tipoDoc As String = "VENTAS"
    Dim ImprimeRenglones As Boolean = False

#Region "Datos Iniciales"
    Private Sub frmRepDoc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DatosIniciales()
        optVentas.Checked = True
    End Sub

    Private Sub DatosIniciales()
        ImprimeRenglones = False
        DocDetalle.Text = ImpDocumento.Text
        LlenarCombos()
        txtFechaAl.Text = fecHasta.ToShortDateString
        txtFechaDel.Text = fecDesde.ToShortDateString
        Ocultar("V")
    End Sub

    Private Sub LlenarCombos()
        Dim c As New DaxCombobx.CargCmbBox
        c.DaxCombosDoc("", "", True, datosEmpresa.strConxAdcom, cboDoc)
        c.DaxCombosSuc(CStr(datosEmpresa.Emp_codigo), True, datosEmpresa.strConIniSis, cboSucursal)
        cboSucursal.SelectedValue = "0"
        c.DaxCombosBods(datosEmpresa.suc, True, datosEmpresa.strConIniSis, cboBodega)
        cboBodega.SelectedValue = "0"
        c.DaxCombosVend(datosEmpresa.strConxAdcom, cboVendedor, True)
        cboVendedor.SelectedValue = "0"
    End Sub

    Private Sub txtFechaDel_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFechaDel.LostFocus
        If txtFechaDel.Text <> "  /  /" Then
            If Not IsDate(txtFechaDel.Text) Then
                MsgBox("Ingrese una fecha válida", MsgBoxStyle.Information)
                txtFechaDel.Text = ""
                txtFechaDel.Focus()
            End If
        End If
    End Sub

    Private Sub txtFechaAl_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFechaAl.LostFocus
        If txtFechaAl.Text <> "  /  /" Then
            If Not IsDate(txtFechaAl.Text) Then
                MsgBox("Ingrese una fecha válida", MsgBoxStyle.Information)
                txtFechaAl.Text = ""
                txtFechaAl.Focus()
            ElseIf IsDate(txtFechaDel.Text) AndAlso txtFechaDel.Text <> "  /  /" Then
                If CDate(txtFechaDel.Text) > CDate(txtFechaAl.Text) Then
                    MsgBox("La fecha final debe ser mayor a la inicial", MsgBoxStyle.Information)
                    txtFechaAl.Text = ""
                    txtFechaAl.Focus()
                End If
            End If
        End If
    End Sub
#End Region

#Region "Reporte"
    Private Function leerOpciones() As Boolean
        Try
            det = ""
            bod = ""
            doc = ""
            vend = ""
            suc = ""
            codClienteIni = txtCodIni.Text.Trim()
            codClienteFin = txtCodFin.Text.Trim()

            If Not IsDate(txtFechaDel.Text) OrElse Not IsDate(txtFechaAl.Text) Then
                MsgBox("Ingrese fechas válidas", MsgBoxStyle.Exclamation)
                Return False
            End If

            fecDesde = CDate(txtFechaDel.Text)
            fecHasta = CDate(txtFechaAl.Text)

            If cboSucursal.SelectedValue IsNot Nothing Then
                Dim valorSuc As String = cboSucursal.SelectedValue.ToString()
                If valorSuc <> "0" Then suc = valorSuc
            End If

            If cboDoc.SelectedValue IsNot Nothing Then
                Dim valorDoc As String = cboDoc.SelectedValue.ToString()
                If valorDoc <> "0" Then
                    doc = valorDoc
                    det += "DOCUMENTO:" & cboDoc.Text.Trim()
                End If
            End If

            Select Case tipo
                Case "C", "CC", "V", "CP"
                    If cboVendedor.SelectedValue IsNot Nothing Then
                        Dim valorVend As String = cboVendedor.SelectedValue.ToString()
                        If valorVend <> "0" Then
                            vend = valorVend
                            If det <> "" Then det += "    "
                            det += "VENDEDOR:" & cboVendedor.Text.Trim()
                        End If
                    End If
                Case "I"
                    If cboBodega.SelectedValue IsNot Nothing Then
                        Dim valorBod As Integer
                        If Integer.TryParse(cboBodega.SelectedValue.ToString(), valorBod) Then
                            If valorBod > 0 Then
                                bod = cboBodega.SelectedValue.ToString()
                                If det <> "" Then det += "    "
                                det += "BODEGA:" & cboBodega.Text.Trim()
                            End If
                        End If
                    End If
                Case "T"
                    det += "TODOS LOS DOCUMENTOS"
                Case "A"
                    det += "DOCUMENTOS ANULADOS"
                Case "B"
                    det += "DOCUMENTOS BANCARIOS"
                Case Else
                    det += "TIPO NO ESPECIFICADO"
            End Select

            If det <> "" Then det += "    "
            det += "DESDE: " & fecDesde.ToString("dd/MM/yyyy") & " HASTA: " & fecHasta.ToString("dd/MM/yyyy")

            If codClienteIni <> "" OrElse codClienteFin <> "" Then
                det += "    CLIENTE: " & codClienteIni & " - " & codClienteFin
            End If

            Return True

        Catch ex As Exception
            MsgBox("Error al leer opciones: " & ex.Message, MsgBoxStyle.Critical)
            Return False
        End Try
    End Function

    Private Sub Ocultar(ByVal op As String)
        cboBodega.Visible = False
        cboVendedor.Visible = False
        Label2.Visible = False
        Label4.Visible = False

        Select Case op
            Case "I"
                cboBodega.Visible = True
                Label2.Visible = True
            Case "C", "CC", "V", "CP", "B", "T", "A"
                cboVendedor.Visible = True
                Label4.Visible = True
            Case Else
                cboVendedor.Visible = True
                Label4.Visible = True
        End Select
    End Sub

    Private Sub LimpiarReportViewer()
        ' ============================================================
        ' LIMPIAR COMPLETAMENTE EL REPORT VIEWER PARA EVITAR CACHÉ
        ' ============================================================
        Try
            ' Reiniciar el control
            ReportViewer1.Reset()

            ' Limpiar fuentes de datos
            ReportViewer1.LocalReport.DataSources.Clear()

            ' Limpiar la ruta del reporte
            ReportViewer1.LocalReport.ReportPath = ""

            ' Limpiar parámetros
            ReportViewer1.LocalReport.SetParameters(New ReportParameter() {})

            ' Liberar el dominio de aplicación
            Try
                ReportViewer1.LocalReport.ReleaseSandboxAppDomain()
            Catch
                ' Ignorar errores
            End Try

            ' Ocultar el control
            ReportViewer1.Visible = False

        Catch ex As Exception
            ' Ignorar errores de limpieza
        End Try
    End Sub

    Private Sub Reporte()
        Try
            Me.Cursor = Cursors.WaitCursor

            If Not leerOpciones() Then
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            If String.IsNullOrEmpty(tipo) Then
                MsgBox("Seleccione un tipo de reporte", MsgBoxStyle.Exclamation)
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            Dim iDetalle As String = "N"
            If ImprimeRenglones Then iDetalle = "S"

            ' ============================================================
            ' LIMPIAR COMPLETAMENTE EL REPORT VIEWER ANTES DE CARGAR
            ' ============================================================
            LimpiarReportViewer()

            ' Construir la cadena SQL
            Dim cad As String = "exec Adc_ReptDocIva '" & fecDesde.ToString("yyyyMMdd") & "','" & fecHasta.ToString("yyyyMMdd") & "','" & tipo & "','" & codClienteIni & "','" & codClienteFin & "','" & suc & "','" & bod & "','" & doc & "','" & vend & "','" & iDetalle & "'"

            ' Obtener los datos
            Dim resultado As Object = SqlDatos.leerTablaAdcom(cad)
            Dim dtDatos As DataTable = Nothing

            If TypeOf resultado Is DataTable Then
                dtDatos = CType(resultado, DataTable)
            ElseIf TypeOf resultado Is DataSet Then
                Dim ds As DataSet = CType(resultado, DataSet)
                If ds.Tables.Count > 0 Then
                    dtDatos = ds.Tables(0)
                End If
            End If

            ' ============================================================
            ' SI HAY DATOS, USARLOS; SI NO, DATATABLE VACÍO
            ' ============================================================
            If dtDatos Is Nothing OrElse dtDatos.Rows.Count = 0 Then
                dtDatos = New DataTable()
                dtDatos.TableName = "DataSet1"
                dtDatos.Columns.Add("Columna1", GetType(String))
                dtDatos.Rows.Add("")
            End If

            ' ============================================================
            ' CONFIGURAR EL REPORTE
            ' ============================================================
            ' Seleccionar el reporte
            Dim rutaReporte As String = ""
            If ImprimeRenglones = False Then
                rutaReporte = datosEmpresa.pathAppl & "Rep\RepDocIva.rdlc"
            Else
                rutaReporte = datosEmpresa.pathAppl & "Rep\RepDocDet.rdlc"
            End If

            ReportViewer1.LocalReport.ReportPath = rutaReporte

            ' Crear y agregar el DataSource
            Dim rds As New ReportDataSource()
            rds.Name = "DataSet1"
            rds.Value = dtDatos
            ReportViewer1.LocalReport.DataSources.Add(rds)

            ' ============================================================
            ' CREAR PARÁMETROS - SOLO LOS QUE EXISTEN EN EL REPORTE ACTUAL
            ' ============================================================
            Dim params As New List(Of ReportParameter)

            ' Parámetros básicos que existen en ambos reportes
            params.Add(New ReportParameter("Empresa", If(datosEmpresa.nomEmpresa, "")))
            params.Add(New ReportParameter("Titulo", "REPORTE DE " & tipoDoc))
            params.Add(New ReportParameter("FecDesde", txtFechaDel.Text))
            params.Add(New ReportParameter("FecHasta", txtFechaAl.Text))
            params.Add(New ReportParameter("FecEmision", Now.ToString("dd/MM/yyyy HH:mm")))
            params.Add(New ReportParameter("DetalleRep", det))
            params.Add(New ReportParameter("SoloTot", CStr(opSoloTot)))

            ' ============================================================
            ' OBTENER PARÁMETROS DEL REPORTE Y AGREGAR SOLO LOS QUE EXISTEN
            ' ============================================================
            Try
                Dim parametrosExistentes As ReportParameterInfoCollection = ReportViewer1.LocalReport.GetParameters()

                If parametrosExistentes IsNot Nothing Then
                    For Each p As ReportParameterInfo In parametrosExistentes
                        Select Case p.Name
                            Case "Tipor"
                                If Not params.Exists(Function(x) x.Name = "Tipor") Then
                                    params.Add(New ReportParameter("Tipor", tipo))
                                End If
                            Case "ConDetalle"
                                If Not params.Exists(Function(x) x.Name = "ConDetalle") Then
                                    params.Add(New ReportParameter("ConDetalle", CStr(chkDetalle.Checked)))
                                End If
                        End Select
                    Next
                End If
            Catch ex As Exception
                ' Si hay error al obtener parámetros, continuamos con los básicos
            End Try

            ' Establecer parámetros
            ReportViewer1.LocalReport.SetParameters(params)

            ' Mostrar el reporte
            ReportViewer1.Visible = True

            ' Refrescar el reporte
            Me.ReportViewer1.RefreshReport()

            Me.Cursor = Cursors.Default

        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox("Error al generar el reporte: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    ' ========== EVENTOS DE SELECCIÓN DE TIPO ==========
    Private Sub optInv_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optInv.CheckedChanged
        If optInv.Checked Then
            tipo = "I"
            tipoDoc = "INVENTARIO"
            Ocultar(tipo)
            LimpiarReportViewer()
            ReportViewer1.Clear()
        End If
    End Sub

    Private Sub optVentas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optVentas.CheckedChanged
        If optVentas.Checked Then
            tipo = "V"
            tipoDoc = "VENTAS"
            Ocultar(tipo)
            LimpiarReportViewer()
            ReportViewer1.Clear()
        End If
    End Sub

    Private Sub optCompras_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optCompras.CheckedChanged
        If optCompras.Checked Then
            tipo = "C"
            tipoDoc = "COMPRAS"
            Ocultar(tipo)
            LimpiarReportViewer()
            ReportViewer1.Clear()
        End If
    End Sub

    Private Sub optBancos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optBancos.CheckedChanged
        If optBancos.Checked Then
            tipo = "B"
            tipoDoc = "BANCOS"
            Ocultar(tipo)
            LimpiarReportViewer()
            ReportViewer1.Clear()
        End If
    End Sub

    Private Sub optCtasCob_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optCtasCob.CheckedChanged
        If optCtasCob.Checked Then
            tipo = "CC"
            tipoDoc = "CUENTAS POR COBRAR"
            Ocultar(tipo)
            LimpiarReportViewer()
            ReportViewer1.Clear()
        End If
    End Sub

    Private Sub optCtaPag_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optCtaPag.CheckedChanged
        If optCtaPag.Checked Then
            tipo = "CP"
            tipoDoc = "CUENTAS POR PAGAR"
            Ocultar(tipo)
            LimpiarReportViewer()
            ReportViewer1.Clear()
        End If
    End Sub

    Private Sub optTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optTodos.CheckedChanged
        If optTodos.Checked Then
            tipo = "T"
            tipoDoc = "TODOS LOS DOCUMENTOS"
            Ocultar(tipo)
            LimpiarReportViewer()
            ReportViewer1.Clear()
        End If
    End Sub

    Private Sub optAnulados_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optAnulados.CheckedChanged
        If optAnulados.Checked Then
            tipo = "A"
            tipoDoc = "ANULADOS"
            Ocultar(tipo)
            LimpiarReportViewer()
            ReportViewer1.Clear()
        End If
    End Sub

    ' ========== EVENTOS DE CAMBIO QUE LIMPIAN EL REPORTE ==========
    Private Sub txtFechaDel_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFechaDel.TextChanged
        LimpiarReportViewer()
        ReportViewer1.Clear()
    End Sub

    Private Sub txtFechaAl_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFechaAl.TextChanged
        LimpiarReportViewer()
        ReportViewer1.Clear()
    End Sub

    Private Sub chkSoloTotal_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSoloTotal.CheckedChanged
        opSoloTot = chkSoloTotal.Checked
        LimpiarReportViewer()
        ReportViewer1.Clear()
    End Sub

    Private Sub txtCodIni_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodIni.TextChanged
        LimpiarReportViewer()
        ReportViewer1.Clear()
    End Sub

    Private Sub txtCodFin_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodFin.TextChanged
        LimpiarReportViewer()
        ReportViewer1.Clear()
    End Sub

    Private Sub cboSucursal_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSucursal.SelectedIndexChanged
        LimpiarReportViewer()
        ReportViewer1.Clear()
    End Sub

    Private Sub cboBodega_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBodega.SelectedIndexChanged
        LimpiarReportViewer()
        ReportViewer1.Clear()
    End Sub

    Private Sub cboDoc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDoc.SelectedIndexChanged
        LimpiarReportViewer()
        ReportViewer1.Clear()
    End Sub

    Private Sub cboVendedor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVendedor.SelectedIndexChanged
        LimpiarReportViewer()
        ReportViewer1.Clear()
    End Sub

    Private Sub chkDetalle_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkDetalle.CheckedChanged
        LimpiarReportViewer()
        ReportViewer1.Clear()
    End Sub

    Private Sub chkConsignatario_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkConsignatario.CheckedChanged
        LimpiarReportViewer()
        ReportViewer1.Clear()
    End Sub
#End Region

#Region "Actualizar"
    Private Sub btnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizar.Click
        If String.IsNullOrEmpty(tipo) Then
            MsgBox("Por favor seleccione un tipo de reporte", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If Not IsDate(txtFechaDel.Text) OrElse Not IsDate(txtFechaAl.Text) Then
            MsgBox("Por favor ingrese fechas válidas", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Reporte()
    End Sub
#End Region

#Region "Tipo de Impresión"
    Private Sub ImpDocumento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImpDocumento.Click
        ImprimeRenglones = False
        DocDetalle.Text = ImpDocumento.Text
        LimpiarReportViewer()
        ReportViewer1.Clear()
    End Sub

    Private Sub ImpDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImpDetalle.Click
        ImprimeRenglones = True
        DocDetalle.Text = ImpDetalle.Text
        LimpiarReportViewer()
        ReportViewer1.Clear()
    End Sub
#End Region

#Region "Opciones y Botones"
    Private Sub btnOpciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpciones.Click
        botonOp = Not botonOp
        btnOpciones.Checked = botonOp
        SplitContainer1.Panel1Collapsed = Not botonOp
    End Sub

    Private Function BuscaCliente(ByVal nom As String) As String
        Dim cod As String = ""
        Dim b As New directMnt.BusDirectorio
        cod = b.BusDirect(cod, "", nom, "", "T", "")
        Return cod
    End Function

    Private Sub btnCodIni_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCodIni.Click
        txtCodIni.Text = BuscaCliente(txtCodIni.Text)
    End Sub

    Private Sub btnCodFin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCodFin.Click
        txtCodFin.Text = BuscaCliente(txtCodFin.Text)
    End Sub

    Private Sub txtCodIni_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodIni.KeyDown
        If e.KeyCode = Keys.F2 Then
            txtCodIni.Text = BuscaCliente(txtCodIni.Text)
        End If
    End Sub

    Private Sub txtCodFin_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodFin.KeyDown
        If e.KeyCode = Keys.F2 Then
            txtCodFin.Text = BuscaCliente(txtCodFin.Text)
        End If
    End Sub
#End Region

#Region "Salir"
    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        LimpiarReportViewer()
        Me.Close()
        Me.Dispose()
    End Sub
#End Region

End Class