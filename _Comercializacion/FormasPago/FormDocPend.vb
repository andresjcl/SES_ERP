'Option Strict On
'Option Explicit On
'Imports System.Data.SqlClient

'Friend Class FormDocPend
'    Public QueSuc As String
'    Public TipDoc As String
'    Public QueIdclavedoc As Double
'    Public QueCliente As String
'    Public NombreCli As String
'    Public DocsPending() As String
'    Public QueTipoCta As String
'    Public SoloConsulta As Boolean
'    Dim cambiado As Boolean
'    Dim QueFecha As String
'    Public QueLote As String
'    Public ValorParaAplicar As Double
'    Public ValorAbonado As Double
'    Public cruceSucursales As Boolean
'    Dim ConCliente As Boolean
'    Dim ConProveedor As Boolean
'    Dim ConAnticipo As Boolean
'    Dim OpOpc As New sesSysp.OpcDoc()
'    Dim Saltar As Boolean

'    'Dim SYSEMP As New AdcDax.DaxSofSys '= AdcDaxx.DaxSofSys.Instance
'    'Dim EMP As AdcDax.Empresa

'    Private Sub FormDocPend_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
'        'EMP = SYSEMP.EmpresaAct
'        Saltar = True
'        OpOpc.Cargar(TipDoc)
'        ValorARepartir.Text = ValorParaAplicar.ToString
'        If ValorParaAplicar > 0 Then ValorARepartir.Enabled = False
'        Saltar = False
'        CargarDocumentos()
'        Dim coll As Integer = 6
'        If SoloConsulta = False Then coll = 7
'        MallaCorr.Focus()
'    End Sub

'    Private Sub TotalizarAplicacion()
'        Dim i As Integer
'        Dim TotAbonos As Double, TotSaldo As Double
'        Dim Tforma As String
'        Tforma = "#########0.00"
'        TotAbonos = 0
'        TotSaldo = 0
'        With MallaCorr
'            If .ColumnCount < 8 Then .ColumnCount = 11
'            For i = 0 To .Rows.Count - 1
'                If Not Val(.Rows(i).Cells("SaldoAct").Value) = Nothing Then TotSaldo += Val(.Rows(i).Cells("SaldoAct").Value.ToString)
'                If Not Val(.Rows(i).Cells("Abono").Value) = Nothing Then TotAbonos += Val(.Rows(i).Cells("Abono").Value.ToString)
'            Next
'            TotalDocumento.Text = Strings.Format(TotSaldo, Tforma)
'            TotalAbono.Text = Strings.Format(TotAbonos, Tforma)
'        End With
'        ValorAbonado = CDbl(TotalAbono.Text)
'    End Sub

'    Private Sub CargarDocumentos()
'        Dim i As Integer
'        Dim m As Integer
'        Dim Campos() As String
'        If Saltar Then Exit Sub
'        '        .rows(0, 0) = ""
'        '        .rows(0, 1) = "Nombre"
'        '        .rows(0, 2) = "Fecha"
'        '        .rows(0, 3) = "SUC"
'        '        .rows(0, 4) = "TIP"
'        '        .rows(0, 5) = "Número"
'        '        .rows(0, 6) = "SaldoAct."
'        '        .rows(0, 7) = "Abono"
'        '        .rows(0, 8) = ""
'        '        .rows(0, 9) = "codcliente"
'        '        .rows(0, 10) = "idclave"
'        'coleccion:
'        '        '''   7,3,4,5,10,9,2
'        '              0 1 2 3  4 5 6
'        With MallaCorr
'            CargarMallaSaldos2(True, MallaCorr, QueCliente, QueFecha, QueSuc, TipDoc, "", QueIdclavedoc, QueLote, chkCentasCobrar.Checked, (chkCuentasPagar.Checked), True, OpOpc.TipoDoc)
'            establecerOpciones()
'            If MallaCorr.Rows.Count > 1 And SoloConsulta = False Then
'                If Not DocsPending Is Nothing Then
'                    If DocsPending.Length > 0 Then
'                        For i = 0 To DocsPending.Length - 1
'                            Campos = Split(DocsPending(i), ";")
'                            If Val(Campos(0)) <> 0 Then
'                                ReDim Preserve Campos(12)
'                                For m = 0 To .Rows.Count - 1
'                                    .Rows(m).Cells("Abono").Value = 0
'                                    'MsgBox(Campos(1) & "-" & .Rows(m).Cells(3).Value.ToString & "-" & Campos(2) & "-" & .Rows(m).Cells(4).Value.ToString & "-" & Val(Campos(4)) & "-" & Val(.Rows(m).Cells(10).Value.ToString))
'                                    If Trim(Campos(1)) = Trim(.Rows(m).Cells("SUC").Value.ToString) And Trim(Campos(2)) = Trim(.Rows(m).Cells("TIP").Value.ToString) And Val(Campos(4)) = Val(.Rows(m).Cells("IdClaveDoc").Value.ToString) Then
'                                        .Rows(m).Cells("Abono").Value = Campos(0)
'                                        Exit For
'                                    End If
'                                Next m
'                            End If
'                        Next i
'                    End If
'                End If
'            End If
'        End With

'        TotalizarAplicacion()
'    End Sub

'    Private Sub RepartirValor(ByVal dato As String, ByVal CruceDocSucursal As Boolean)

'        Dim repartido As Double, Poner As Double, actual As Double
'        dato = ""
'        repartido = Val(ValorARepartir.Text)
'        Dim i As Integer
'        With MallaCorr
'            For i = 0 To .Rows.Count - 1
'                If .Rows(i).Cells("SUC").Value.ToString = datosEmpresa.suc Or CruceDocSucursal Then
'                    actual = Math.Abs(CDbl(.Rows(i).Cells("SaldoAct").Value))
'                    If actual >= repartido Then
'                        Poner = repartido
'                        repartido = 0
'                    Else
'                        Poner = actual
'                        repartido = repartido - Poner
'                    End If
'                    .Rows(i).Cells("Abono").Value = Poner
'                    'If dato = "" Then dato = Poner
'                End If
'                If repartido = 0 Then Exit For
'            Next
'        End With
'    End Sub

'    Private Sub MallaCorr_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles MallaCorr.CellEndEdit
'        Dim row As Integer = e.RowIndex
'        Dim col As Integer = e.ColumnIndex
'        With MallaCorr
'            If Trim(.Rows(row).Cells("SUC").ToString) <> datosEmpresa.suc And Val(.Rows(row).Cells("Abono").ToString) > 0 And cruceSucursales = False Then
'                MsgBox("No se puede afectar a un documento de otra sucursal", vbCritical)
'                .Rows(row).Cells("Abono").Value = 0
'            Else
'                cambiado = True
'            End If
'            TotalizarAplicacion()
'        End With
'    End Sub

'    Private Sub MallaCorr_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MallaCorr.KeyDown
'        Try
'            Dim roww As Integer = MallaCorr.CurrentCell.RowIndex
'            Dim coll As Integer = MallaCorr.CurrentCell.ColumnIndex
'            If e.KeyCode = Keys.F2 And Len(MallaCorr.Rows(roww).Cells("SaldoAct").ToString) > 0 Then
'                MallaCorr.Rows(roww).Cells("Abono").Value = Format(Math.Abs(CDbl(MallaCorr.Rows(roww).Cells("SaldoAct").Value)), "########0.00")
'            ElseIf e.KeyCode = Keys.F8 Then
'                Dim calculadora As New daxcalc.Calcula
'                MallaCorr.Rows(roww).Cells("Abono").Value = CStr(calculadora.valor)
'            End If
'        Catch
'        End Try
'    End Sub

'    Private Sub TxtValort_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ValorARepartir.KeyDown
'        Dim dato As String = ""
'        Dim calculadora As New daxcalc.Calcula
'        If e.KeyCode = Keys.F8 Then
'            dato = CStr(calculadora.valor)
'        ElseIf e.KeyCode = Keys.F3 And Val(ValorARepartir.Text) <> 0 Then
'            RepartirValor(ValorARepartir.Text, cruceSucursales)
'        End If
'        TotalizarAplicacion()
'    End Sub

'    Private Function Abs(ByVal dataGridViewCell As DataGridViewCell) As Object
'        Throw New NotImplementedException
'    End Function

'    Private Sub Check1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCentasCobrar.CheckedChanged
'        CargarDocumentos()
'    End Sub

'    Private Sub Check2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCuentasPagar.CheckedChanged
'        CargarDocumentos()
'    End Sub

'    Private Sub anticipo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
'        CargarDocumentos()
'    End Sub

'    Private Sub anticipoprov_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
'        CargarDocumentos()
'    End Sub

'    Private Sub CheckBox5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSoloAutorizados.CheckedChanged
'        CargarDocumentos()
'    End Sub

'    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
'        Dim i As Integer
'        Dim r As Integer
'        MallaCorr.EndEdit()
'        TotalizarAplicacion()
'        If Val(TotalAbono.Text) > Val(ValorARepartir.Text) And ValorARepartir.Enabled = False Then
'            MsgBox("El valor de las aplicaciones es mayor al valor disponible" & vbCr & "No puede registrarse el movimiento", vbCritical)
'            Exit Sub
'        End If
'        r = 0
'        With MallaCorr
'            For i = 0 To .RowCount - 1
'                If Val(.Rows(i).Cells("Abono").Value) <> 0 Then
'                    ReDim Preserve DocsPending(r + 1)
'                    DocsPending(r) = .Rows(i).Cells("Abono").Value.ToString & ";" & Trim(.Rows(i).Cells("SUC").Value.ToString) & ";" & .Rows(i).Cells("TIP").Value.ToString & ";" & .Rows(i).Cells("Numero").Value.ToString & ";" & .Rows(i).Cells("IdClaveDoc").Value.ToString & ";" & .Rows(i).Cells("doc_codper").Value.ToString & ";" & .Rows(i).Cells("Fecha").Value.ToString & ";" & .Rows(i).Cells("Nombre").Value.ToString
'                    r += 1
'                End If
'            Next i
'        End With
'        OpOpc = Nothing
'        Me.Close()
'    End Sub

'    Private Sub MallaCorr_CellLeave(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles MallaCorr.CellLeave
'        MallaCorr.EndEdit()
'    End Sub

'    Private Sub establecerOpciones()
'        If SoloConsulta Then
'            btnAceptar.Visible = False
'            chkSoloAutorizados.Visible = False
'            Label2.Visible = False
'            ValorARepartir.Visible = False
'            TotalAbono.Visible = False
'            MallaCorr.Columns(7).Visible = False
'            Label3.Visible = False
'        End If
'    End Sub

'    Private Sub btnContinuar_Click(sender As System.Object, e As System.EventArgs)
'        Me.Close()
'    End Sub

'    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
'        MallaCorr.EndEdit()
'        If cambiado Then If MsgBox("Los cambios realizados se perderán, confirma salir ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then Return
'        Me.Close()
'    End Sub

'    Private Sub MallaCorr_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles MallaCorr.DataError
'        MessageBox.Show("Dato registrado erróneo, digite nuevamente")
'    End Sub

'    Private Sub WordToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WordToolStripMenuItem.Click

'    End Sub

'    Private Sub btnAplicaciones_Click(sender As Object, e As EventArgs) Handles btnAplicaciones.Click

'    End Sub
'End Class
