Option Strict Off
Option Explicit On
Imports System.Data
Imports System.Data.SqlClient
Imports DattCom
Friend Class ControlPeriodo
    Inherits System.Windows.Forms.Form
	Public Sub iniciaPermisos()
        Toolbar1.Items.Item(6).Enabled = False
        CargarPeriodos()
		Me.Show()
	End Sub

    Private Sub CargarPeriodos()
        Dim ssql As String = "Select año,mes,Contabilidad,OtrosModulos,ExcContabilidad,ExcOtrosModulos,idclave from AdcPeriodo  order by año,mes"
        Malla.DataSource = DattCom.SqlDatos.leerTablaAdcom(ssql)
        Malla.Columns("idclave").Visible = False

        'Dim rs As SqlDataReader
        'Dim i As Short

        'Dim Conxadcom As New SqlConnection(datosEmpresa.strConxAdcom)
        'Conxadcom.Open()
        'Dim ssql As String = ""
        'ssql = "Select año,mes,Contabilidad,OtrosModulos,ExcContabilidad,ExcOtrosModulos,idclave from AdcPeriodo  order by año,mes"
        'Dim comm As New SqlCommand(ssql, Conxadcom)
        'rs = comm.ExecuteReader
        'With Malla
        '    .ColumnCount = 7
        '    .RowCount = 0
        '    .RowHeadersVisible = True
        '    .RowHeadersWidth = 30
        '    .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

        '    .Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        '    .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        '    .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        '    .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        '    .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        '    .Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        '    .Columns(6).Width = 50
        '    .Columns(0).Name = "AÑO"
        '    .Columns(1).Name = "MES"
        '    .Columns(2).Name = "Contabilidad"
        '    .Columns(3).Name = "OtrosMódulos"
        '    .Columns(4).Name = "Excepto para contabilidad"
        '    .Columns(5).Name = "Excepto para otros módulos"
        '    .Columns(6).Name = "ID.Clv."
        '    .Columns(6).Visible = False
        'End With
        'i = 0
        'With Me.Malla.Rows
        '    Do Until rs.Read = False
        '        .Add({rs.Item("Año").Value, rs.Item("Mes").Value, rs.Item("contabilidad").Value,
        '                  rs.Item("otrosmodulos").Value, rs.Item("exccontabilidad").Value,
        '                  rs.Item("excotrosmodulos").Value, rs.Item("Idclave").Value})
        '    Loop
        'End With
        'rs.Close()
    End Sub


    Private Sub Malla_EnterCell(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Malla.CellEnter
        CambiarEstado()
    End Sub

    Private Sub CambiarEstado()
        With Malla

            If .CurrentCell.ColumnIndex = 2 Or .CurrentCell.ColumnIndex = 3 Then
                If .CurrentCell.Value.ToString = "Cerrado" Then
                    Toolbar1.Items.Item("keyactivar").Enabled = True
                    Toolbar1.Items.Item("keycerrar").Enabled = False
                Else
                    Toolbar1.Items.Item("keycerrar").Enabled = True
                    Toolbar1.Items.Item("keyactivar").Enabled = False
                End If
            End If

        End With

    End Sub

    Private Sub Toolbar1_ButtonClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles keycrear.Click, keygrabar.Click, keycancelar.Click, keyeliminar.Click, keyimprimir.Click, _Toolbar1_Button6.Click, keyactivar.Click, keycerrar.Click, btnExcepto.Click, _Toolbar1_Button10.Click, btnsalir.Click
        Dim Button As System.Windows.Forms.ToolStripItem = CType(eventSender, System.Windows.Forms.ToolStripItem)
        On Error Resume Next
        Dim progim As New DataGridViewPrinterApplication1.frmMain

        Select Case Button.Name
            Case "keycrear"
                CrearPeriodo(0)
            Case "keyeliminar"
                EliminarPeriodos()
            Case "keyactivar"
                ActivarPeriodos()
            Case "keycerrar"
                CerrarPeriodos()
            Case "keygrabar"
                GuardarPeriodos()
            Case "btnsalir"
                GuardarPeriodos()
                Me.Close()
                Exit Sub
            Case "keycancelar"
                Me.Close()
                Exit Sub
            Case "btnExcepto"
                If Malla.CurrentCell.ColumnIndex = 4 Or Malla.CurrentCell.ColumnIndex = 5 Then Malla.CurrentCell.Value = selectUser()
            Case "bnimprimir"
                progim.imprimir(Malla, "Planificacion de control de períodos", , DattCom.datosEmpresa.Emp_Nombre)
                progim = Nothing
        End Select
    End Sub

    Private Function selectUser() As String
        Dim frm As New frmUsuarios
        On Error Resume Next
        With Malla
            selectUser = frm.iniciaUsuario(.CurrentCell.Value.ToString)
        End With
    End Function

    Private Sub GuardarPeriodos()
        Dim i As Short
        Dim sSql As String
        With Malla
            For i = 0 To .RowCount - 1
                If .Rows(i).Cells(0).Value > 0 And .Rows(i).Cells(1).Value > 0 Then
                    If .Rows(i).Cells(6).Value = 0 Then
                        sSql = "INSERT INTO [AdcPeriodo]"
                        sSql = sSql & " ([Año],[Mes],[Contabilidad],[OtrosModulos],[ExcContabilidad],[ExcOtrosModulos]) "
                        sSql = sSql & " Values ("
                        sSql = sSql & .Rows(i).Cells(0).Value
                        sSql = sSql & "," & .Rows(i).Cells(1).Value
                        sSql = sSql & ",'" & .Rows(i).Cells(2).Value & "' "
                        sSql = sSql & ",'" & .Rows(i).Cells(3).Value & "'"
                        sSql = sSql & ",'" & .Rows(i).Cells(4).Value & "' "
                        sSql = sSql & ",'" & .Rows(i).Cells(5).Value & "') "
                    Else
                        sSql = "Update [AdcPeriodo]"
                        sSql = sSql & " Set "
                        sSql = sSql & "[Contabilidad] = '" & .Rows(i).Cells(2).Value & "'"
                        sSql = sSql & ",[OtrosModulos] = '" & .Rows(i).Cells(3).Value & "'"
                        sSql = sSql & ",[ExcContabilidad] = '" & .Rows(i).Cells(4).Value & "'"
                        sSql = sSql & ",[ExcOtrosModulos] = '" & .Rows(i).Cells(5).Value & "'"
                        sSql = sSql & " WHERE año = " & .Rows(i).Cells(0).Value & " and mes = " & .Rows(i).Cells(1).Value
                        '                        sSql = sSql & " and idclave = " & .Rows(i).Cells(5).Value
                    End If
                    '            linkdat.Adcom = True
                    DattCom.SqlDatos.ejecutarComando(sSql, datosEmpresa.strConxAdcom)
                End If
            Next i
        End With
        Malla.Rows.Clear()
        CargarPeriodos()
    End Sub

    Private Sub CrearPeriodo(ByRef Año As Integer)
        Dim Inicio As Short
        Dim TotalRegistros As Double = 0
        'Dim rs As New ADODB.Recordset
        Dim i As Integer
        With Malla
            If Año = 0 Then
                Año = Val(InputBox("Digite al año en que desea crear los períodos", "Año para crear períodos", CStr(Year(Today))))
                If Año <= Year(datosEmpresa.UltimoCierreAnual) Then MsgBox("No puede crear períodos menores a la última fecha de cierre anual") : Exit Sub
                For i = 0 To .Rows.Count - 1
                    If .Rows(i).Cells(1).Value = Año Then MsgBox("El año para crear períodos ya existe ", MsgBoxStyle.Critical) : Exit Sub
                Next i
            End If
            Inicio = 0
            For i = 0 To .Rows.Count - 1
                If .Rows(i).Cells(1).Value = 0 Then Inicio = i
            Next i
            If Inicio = 0 Then Inicio = 1
            For i = 1 To 12
                Malla.Rows.Add({Año, i, "Abierto", "Abierto", "", "", 0})
            Next i
        End With
    End Sub

    Private Sub EliminarPeriodos()
        Dim Existe As Boolean
        Dim TotalRegistros As Double
        Dim Año As Integer
        Dim i As Integer
        Dim Conxadcom As New SqlConnection(datosEmpresa.strConxAdcom)
        Dim rs As SqlDataReader
        Conxadcom.Open()
        Año = Val(InputBox("Digite al año en que desea ELIMINAR los períodos", "Año para eliminar períodos", CStr(Year(Today))))
        If Año > Year(datosEmpresa.UltimoCierreAnual) Then MsgBox("No se puede eliminar períodos mayores a la fecha de cierre anual") : Exit Sub
        Dim comm As SqlCommand = New SqlCommand("select count(*) as total from  adcdoc where year(doc_fecha) = " & Año)
        rs = comm.ExecuteReader
        If rs.Read Then TotalRegistros = rs.Item("Total").Value
        rs.Close()
        If TotalRegistros > 0 Then MsgBox("No se puede eliminar un período utilizado actualmente", MsgBoxStyle.Critical) : Exit Sub
        With Malla
            Existe = True
            i = 0
            Do Until Existe = False
                If Año = Malla.Rows(i).Cells(1).Value Then Malla.Rows(i).Dispose() Else i = i + 1
                If i > Malla.RowCount - 1 Then Existe = False : Exit Do
            Loop
        End With
        Conxadcom.Dispose()
    End Sub

    Private Sub ActivarPeriodos()
        Dim i As Integer
        Dim col As Integer
        col = Malla.CurrentCell.ColumnIndex
        If Not (col = 2 Or col = 3) Then Exit Sub
        If MsgBox("Confirma Activar los períodos seleccionados ? ", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        With Malla
            For i = 0 To .RowCount - 1
                If .Rows(i).Cells(col).Selected Then
                    If col = 3 And .Rows(i).Cells(2).Value.ToString = "Cerrado" Then MsgBox("No se puede abrir 'OtrosModulos' cuando 'Contabilidad' está cerrado") : Exit Sub
                End If
            Next i
            For i = 0 To .RowCount - 1
                If .Rows(i).Cells(col).Selected Then
                    .Rows(i).Cells(col).Value = "Abierto"
                    .Rows(i).Cells(col + 2).Value = ""
                End If
            Next i
        End With
        CambiarEstado()
    End Sub

    Private Sub CerrarPeriodos()
        Dim i As Integer
        Dim col As Integer
        col = Malla.CurrentCell.ColumnIndex
        If Not (col = 2 Or col = 3) Then Exit Sub
        If MsgBox("Confirma cerrar los períodos seleccionados ? ", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        With Malla
            For i = 0 To .RowCount - 1
                If .Rows(i).Cells(col).Selected Then
                    If col = 2 And .Rows(i).Cells(3).Value.ToString = "Abierto" Then MsgBox("No se puede cerrar 'contabilidad' cuando 'OtrosModulos' está abierto") : Exit Sub
                End If
            Next i
            For i = 0 To .RowCount - 1
                If .Rows(i).Cells(col).Selected Then
                    .Rows(i).Cells(col).Value = "Cerrado"
                    .Rows(i).Cells(col + 2).Value = ""
                End If
            Next i
        End With
        CambiarEstado()
    End Sub

End Class