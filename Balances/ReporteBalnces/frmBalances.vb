Imports System.Data.SqlClient
Imports DattCom
Imports Microsoft.Reporting.WinForms
Imports Microsoft.VisualBasic.ApplicationServices

Public Class frmBalances
    Dim BotonOp As Boolean = False
    Dim titulo As String = "Balance"
    Dim cad As String = "" ' "exec DaxCtbsal '01/01/2008','28/10/2011',1999,0"
    Dim fechaBal As Date = Now.Date
    Dim FechaEmi As Date = Now.Date
    Dim empr As String = datosEmpresa.Emp_Nombre
    Dim fechaHasta As Date = Now.Date
    Dim opciones As Integer = 0
    Dim balances As Integer = 0
    Dim ampliados As Integer = 0
    Dim imprimir As Integer = 0
    Dim añoCierre As Integer = 0
    Dim mov As Integer = 0
    Dim firmas As Boolean = False

#Region "Reporte"
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Actualizar.Enabled = False
        conectarBDD()
        If datosEmpresa.Emp_codigo = 0 Then MsgBox("No se ha conectado al servidor ADCOMdx", MsgBoxStyle.Critical) : End
        añoCierre = Year(datosEmpresa.UltimoCierreAnual)
        txtFechaFin.Text = Now.Date
        txtFechaInicio.Text = DateSerial(añoCierre + 1, 1, 1)
        fechaHasta = txtFechaFin.Text
        cboNivel.Text = 3
        bloquearDesbloquear(1)
        labelMensaje()
    End Sub

    Private Sub labelMensaje()
        ' Configuración del Label de estado
        lblEstado.Text = ""
        lblEstado.Visible = False
        lblEstado.Dock = DockStyle.Bottom ' Se queda pegado abajo
        lblEstado.BackColor = Color.Orange ' Color llamativo (naranja)
        lblEstado.ForeColor = Color.White ' Letra blanca
        lblEstado.Font = New Font("Arial", 12, FontStyle.Bold) ' Letra grande y negrita
        lblEstado.TextAlign = ContentAlignment.MiddleCenter
        lblEstado.Height = 40 ' Altura fija para que se vea bien
        lblEstado.BringToFront() ' IMPORTANTE: Lo pone encima de todo

        Me.Controls.Add(lblEstado) ' Lo agrega al formulario
    End Sub

    Private Sub reporte()
        Try
            ' INDICADOR DE PROCESO - Inicio
            Me.Cursor = Cursors.WaitCursor
            lblEstado.Text = "Procesando reporte... espere por favor"
            lblEstado.Visible = True
            Application.DoEvents() ' Fuerza la actualización de la UI

            If ValidarFechas() = False Then
                MsgBox("Las fechas para el balance estan erradas", MsgBoxStyle.Critical)
                Me.Cursor = Cursors.Default
                lblEstado.Visible = False
                Exit Sub
            End If

            LeerOpciones()
            If Val(cboNivel.Text) = 0 Then cboNivel.Text = 4

            Dim cad As String = ""
            Dim titulo As String = ""

            If balances < 1 Or balances > 4 Then
                MsgBox("Error: Tipo de balance no válido. balances = " & balances, MsgBoxStyle.Critical)
                Me.Cursor = Cursors.Default
                lblEstado.Visible = False
                Exit Sub
            End If

            Select Case balances
                Case 1
                    titulo = "BALANCE DE COMPROBACIÓN"
                    Dim añoCierre As Integer = 0
                    cad = "exec DaxCB024_12 '" & txtFechaInicio.Text & "','" & txtFechaFin.Text & "'," & añoCierre & "," & mov & ",0,1," & cboNivel.Text
                Case 2
                    titulo = "BALANCE GENERAL "
                    If optMovimiento.Checked Then
                        cad = "exec DaxCtbMov " & cboNivel.Text & ",'" & txtFechaInicio.Text & "','" & txtFechaFin.Text & "','" & txtFechaInicio.Text & "','" & txtFechaFin.Text & "'," & IIf(CheckNiifs.Checked, 1, 0) & ",1"
                    Else
                        cad = "exec DaxCtbSal " & cboNivel.Text & ",'" & txtFechaFin.Text & "'," & IIf(CheckNiifs.Checked, 1, 0) & ",2"
                    End If
                Case 3
                    titulo = "BALANCE DE RESULTADOS "
                    If optMovimiento.Checked Then
                        cad = "exec DaxCtbMov " & cboNivel.Text & ",'" & txtFechaInicio.Text & "','" & txtFechaFin.Text & "','" & txtFechaInicio.Text & "','" & txtFechaFin.Text & "'," & IIf(CheckNiifs.Checked, 1, 0) & ",2"
                    Else
                        cad = "exec DaxCtbSal " & cboNivel.Text & ",'" & txtFechaFin.Text & "'," & IIf(CheckNiifs.Checked, 1, 0) & ",2"
                    End If
                Case 4
                    If ampliados = 1 Then
                        titulo = " BALANCE AMPLIADO DE PATRIMONIO "
                        If optMovimiento.Checked Then
                            cad = "exec DaxCtbAmpMv " & cboNivel.Text & ",'" & txtFechaInicio.Text & "','" & txtFechaFin.Text & "'," & IIf(CheckNiifs.Checked, 1, 0) & ",1," & IIf(optMovimiento.Checked, 1, 0)
                        Else
                            cad = "exec DaxCtbAmp " & cboNivel.Text & ",'" & txtFechaInicio.Text & "','" & txtFechaFin.Text & "'," & IIf(CheckNiifs.Checked, 1, 0) & ",1," & IIf(optMovimiento.Checked, 1, 0)
                        End If
                    Else
                        titulo = "BALANCE AMPLIADO DE RESULTADOS "
                        If optMovimiento.Checked Then
                            cad = "exec DaxCtbAmpMv " & cboNivel.Text & ",'" & txtFechaInicio.Text & "','" & txtFechaFin.Text & "'," & IIf(CheckNiifs.Checked, 1, 0) & ",2," & IIf(optMovimiento.Checked, 1, 0)
                        Else
                            cad = "exec DaxCtbAmp " & cboNivel.Text & ",'" & txtFechaInicio.Text & "','" & txtFechaFin.Text & "'," & IIf(CheckNiifs.Checked, 1, 0) & ",2," & IIf(optMovimiento.Checked, 1, 0)
                        End If
                    End If
            End Select

            If String.IsNullOrEmpty(cad) Then
                MsgBox("Error: No se pudo generar la consulta SQL.", MsgBoxStyle.Critical)
                Exit Sub
            End If

            titulo &= IIf(optSaldos.Checked, " (saldos al " & txtFechaFin.Text & ") ", "(movimientos del " & txtFechaInicio.Text & " al " & txtFechaFin.Text & ")")

            ' EJECUTAR CONSULTA
            Dim ds As DataSet = CalcularDataSet(cad)

            lblEstado.Text = "Generando reporte..."
            Application.DoEvents()

            ' VERIFICACIONES CRÍTICAS
            If ds Is Nothing Then
                MsgBox("Error: DataSet es Nothing", MsgBoxStyle.Critical)
                Me.Cursor = Cursors.Default
                lblEstado.Visible = False
                Exit Sub
            End If

            If ds.Tables.Count = 0 Then
                MsgBox("Error: No hay tablas en el DataSet", MsgBoxStyle.Critical)
                Me.Cursor = Cursors.Default
                lblEstado.Visible = False
                Exit Sub
            End If

            ' DEBUG: Mostrar información del DataSet
            Dim debugInfo As String = "Tablas: " & ds.Tables.Count & vbCrLf
            For i As Integer = 0 To ds.Tables.Count - 1
                debugInfo &= "Tabla " & i & ": " & ds.Tables(i).TableName & " (" & ds.Tables(i).Rows.Count & " filas)" & vbCrLf
                If ds.Tables(i).Columns.Count > 0 Then
                    debugInfo &= "  Columnas: "
                    For Each col As DataColumn In ds.Tables(i).Columns
                        debugInfo &= col.ColumnName & ", "
                    Next
                    debugInfo &= vbCrLf
                End If
            Next

            ' Descomenta esta línea para ver el debug:
            ' MsgBox(debugInfo)

            ' CONFIGURAR DATASOURCE
            Dim rds As New ReportDataSource()
            rds.Name = "DataSet1" ' ESTE NOMBRE DEBE COINCIDIR CON EL RDLC

            ' USAR LA PRIMERA TABLA (índice 0, no por nombre)
            rds.Value = ds.Tables(0)

            ReportViewer1.Visible = True
            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.DataSources.Add(rds)

            ' RUTA DEL REPORTE
            Dim rutaReporte As String = ""
            Select Case balances
                Case 1
                    rutaReporte = datosEmpresa.pathAppl & "Rep\BalancesComprobacion.rdlc"
                Case 2, 3
                    rutaReporte = datosEmpresa.pathAppl & "Rep\BalanceGeneral.rdlc"
                Case 4
                    rutaReporte = datosEmpresa.pathAppl & "Rep\BalAmpl.rdlc"
            End Select

            If Not IO.File.Exists(rutaReporte) Then
                MsgBox("Error: No existe: " & rutaReporte, MsgBoxStyle.Critical)
                Exit Sub
            End If

            ReportViewer1.LocalReport.ReportPath = rutaReporte

            ' PARÁMETROS
            Dim params() As ReportParameter = {
            New ReportParameter("Empresa", empr),
            New ReportParameter("Titulo", titulo),
            New ReportParameter("Fecha", txtFechaInicio.Text),
            New ReportParameter("FechaEmi", Now.Date.ToString()),
            New ReportParameter("FechaHasta", txtFechaFin.Text),
            New ReportParameter("Firmas", firmas)
        }

            ReportViewer1.LocalReport.SetParameters(params)

            lblEstado.Text = "Mostrando reporte..."
            Application.DoEvents()

            ReportViewer1.LocalReport.Refresh()
            Me.ReportViewer1.RefreshReport()

        Catch ex As Exception
            Dim errorMsg As String = "Error: " & ex.Message & vbCrLf & vbCrLf

            If ex.InnerException IsNot Nothing Then
                errorMsg &= "Inner Exception: " & ex.InnerException.Message & vbCrLf
            End If

            errorMsg &= vbCrLf & "Stack Trace: " & ex.StackTrace

            MsgBox(errorMsg, MsgBoxStyle.Critical)
        Finally
            ' INDICADOR DE PROCESO - Fin (SIEMPRE se ejecuta)
            Me.Cursor = Cursors.Default
            lblEstado.Visible = False
            lblEstado.Text = ""
        End Try
    End Sub
    Public Function CalcularDataSet(ByVal cadena As String) As DataSet
        Dim datS As New DataSet()

        Try
            Using cmd As New SqlCommand(cadena, conectar)
                cmd.CommandTimeout = 600
                ' CORRECCIÓN: Usar Text porque la cadena contiene "exec ..."
                cmd.CommandType = System.Data.CommandType.Text

                Using sqlAdap As New SqlDataAdapter(cmd)
                    If conectar.State = ConnectionState.Closed Then
                        conectar.Open()
                    End If

                    ' Llena el DataSet con los resultados
                    sqlAdap.Fill(datS)

                    ' Opcional: Renombrar la primera tabla para coincidir con el RDLC si es necesario
                    If datS.Tables.Count > 0 Then
                        datS.Tables(0).TableName = "DataSet1"
                    End If

                End Using
            End Using

        Catch ex As Exception
            MsgBox("Error SQL: " & ex.Message & vbCrLf & vbCrLf & "Query: " & cadena, MsgBoxStyle.Critical)
            Throw
        Finally
            If conectar.State = ConnectionState.Open Then
                conectar.Close()
            End If
        End Try

        Return datS
    End Function

#End Region


#Region "Verificar Fechas"
    Private Function ValidarFechas() As Boolean
        BorrarReporte()
        ValidarFechas = False
        If Not IsDate(txtFechaFin.Text) Then Exit Function
        txtFechaFin.Text = CDate(txtFechaFin.Text)
        If txtFechaInicio.Visible Then
            If Not IsDate(txtFechaInicio.Text) Then Exit Function
            If Year(txtFechaInicio.Text) <= añoCierre And balances = 1 Then
                MsgBox("No existen movimientos antes o durante el año de cierre ultimo " & añoCierre, MsgBoxStyle.Critical)
                Exit Function
            End If
            If CDate(txtFechaInicio.Text) > CDate(txtFechaFin.Text) Then Exit Function
            txtFechaInicio.Text = CDate(txtFechaInicio.Text)
        End If
        ValidarFechas = True
    End Function

#End Region

#Region "Opciones - Balances"

    Private Sub bloquearTodo()
        Dim Control1 As System.Windows.Forms.Control
        Dim a As String
        For Each Control1 In SplitContainer1.Panel1.Controls
            a = TypeName(Control1)
            If a = "CheckBox" Then Control1.Enabled = False
            If a = "GroupBox" Then Control1.Enabled = False
            If a = "ComboBox" Then Control1.Enabled = False
            If a = "MaskedTextBox" Then Control1.Enabled = False
        Next
    End Sub
    Private Sub bloquearDesbloquear(ByVal nom As Integer)
        Select Case nom
            Case 1
                lblFechaInicio.Visible = True
                txtFechaInicio.Visible = True
                'GroupBox2.Visible = False
                'Label2.Visible = False
                cboNivel.Visible = False
            Case Else
                lblFechaInicio.Visible = optMovimiento.Checked
                txtFechaInicio.Visible = optMovimiento.Checked
                'lblFechaInicio.Visible = False
                'txtFechaInicio.Visible = False
                'GroupBox2.Visible = True
                'Label2.Visible = True
                cboNivel.Visible = True
        End Select
    End Sub
    Private Sub btnOpciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpciones.Click
        If BotonOp = 0 Then
            btnOpciones.Checked = False
            BotonOp = 1
        Else
            btnOpciones.Checked = True
            BotonOp = 0
        End If
        SplitContainer1.Panel1Collapsed = Not btnOpciones.Checked
    End Sub
#End Region

#Region "Limpiar/Aceptar"
    Private Sub LeerOpciones()
        fechaBal = Now
        fechaHasta = txtFechaFin.Text
        mov = 1 'IIf(chkCtasMov.Checked = True, 1, 0)
        ' If opciones = 3 Then firmas = True Else firmas = False
    End Sub
#End Region

#Region "Salir"
    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Dispose()
    End Sub
#End Region

#Region "Opciones"

    'Opciones 1- Cuentas de orden
    '         2- Cuentas con saldo 0
    '         3- Firmas
    '         4- Solo cuentas de movimiento
    Private Sub chkCtasOrden_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If chkCtasOrden.Checked = True Then opciones = 1 Else opciones = 0
        BorrarReporte()
    End Sub
    Private Sub chkConSaldo0_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If chkConSaldo0.Checked = True Then opciones = 2 Else opciones = 0
        BorrarReporte()
    End Sub
    Private Sub chkFirmas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If chkFirmas.Checked = True Then firmas = True Else firmas = False
        BorrarReporte()
    End Sub
    'Private Sub chkCtasMov_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If chkCtasMov.Checked = True Then mov = 1 Else mov = 0
    '    BorrarReporte()
    'End Sub

    'imprimir 1- Saldo
    '         2- Movimiento
    Private Sub optSaldos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optSaldos.CheckedChanged
        imprimir = 1
        BorrarReporte()
    End Sub
    Private Sub optMovimiento_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optMovimiento.CheckedChanged
        imprimir = 2
        BorrarReporte()
        If optMovimiento.Checked Then
            lblFechaInicio.Visible = True
            txtFechaInicio.Visible = True
        Else
            lblFechaInicio.Visible = False
            txtFechaInicio.Visible = False
            txtFechaInicio.Text = "01/01/1900"
        End If
    End Sub
#End Region

    Private Sub BorrarReporte()
        ReportViewer1.Clear()
    End Sub

    Private Sub Actualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Actualizar.Click
        reporte()
    End Sub

    Private Sub BalanceDeComprobaciónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BalanceDeComprobaciónToolStripMenuItem.Click
        Actualizar.Enabled = True
        Label1.Text = "Balance de Comprobacion "
        balances = 1
        CargarNiveles(balances)
        bloquearDesbloquear(balances)
        reporte()
    End Sub

    Private Sub BalanceGeneralToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BalanceGeneralToolStripMenuItem.Click
        Actualizar.Enabled = True
        balances = 2
        Label1.Text = "Balance General"
        CargarNiveles(balances)
        bloquearDesbloquear(balances)
        reporte()
    End Sub

    Private Sub BalanceResultadosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BalanceResultadosToolStripMenuItem.Click
        Actualizar.Enabled = True
        Label1.Text = "Balance de Resultados"
        balances = 3
        CargarNiveles(balances)
        bloquearDesbloquear(balances)
        reporte()
    End Sub

    Private Sub BalancesAmpliadosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BalancesAmpliadosToolStripMenuItem.Click
        Actualizar.Enabled = True
        balances = 4
        Label1.Text = "Balance Ampliado de "
        CargarNiveles(balances)
        bloquearDesbloquear(balances)
        'reporte()
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        Actualizar.Enabled = True
        balances = 4
        Label1.Text = "Balance Ampliado de Patrimonio"
        ampliados = 1
        bloquearDesbloquear(balances)
        reporte()
    End Sub

    Private Sub ResultadosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResultadosToolStripMenuItem.Click
        Actualizar.Enabled = True
        balances = 4
        Label1.Text = "Balance Ampliado de Resultados"
        ampliados = 2
        bloquearDesbloquear(balances)
        reporte()
    End Sub

    Private Sub cboNivel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        BorrarReporte()
    End Sub

    Private Sub cboNivel_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        BorrarReporte()
    End Sub

    Private Sub CargarNiveles(ByVal TipoBal As Integer)
        With cboNivel
            .Items.Clear()
            Select Case TipoBal
                Case 1, 4
                    cboNivel.Items.Add("2")
                    cboNivel.Items.Add("3")
                    cboNivel.Items.Add("4")
                    cboNivel.Items.Add("5")
                    cboNivel.Items.Add("6")
                Case 2, 3
                    .Items.Add("3")
                    .Items.Add("4")
            End Select
            .Text = "4"
        End With
    End Sub
End Class
