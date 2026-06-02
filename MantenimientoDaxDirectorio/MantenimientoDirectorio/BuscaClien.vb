Imports System.Data.SqlClient
Imports DattCom
Imports directMnt.datosIng

Public Class BuscaClien
    Inherits System.Windows.Forms.Form
    Dim Seleccion2 As String = ""
    Dim Seleccion As String = ""
    Dim Selección3 As String = ""
    Dim CodNom As String = ""
    Dim ClioPro As String = ""
    Dim CodigoRet As String = ""
    Dim Sw As Short = 1
    Dim Alias_Renamed As String = ""
    Dim SinNuevo As Boolean = False
    Dim fila As Integer
    Dim esmedical As Boolean
    Dim conHistoria As String
    Dim conTelefono As String
    Dim Inicia As Boolean = False
    Dim SueldoAnterior As Double = 0
    Dim IngresoAnterior As Date
    Dim SalidaAnterior As Date
    Private Sub btnbuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnbuscar.Click
        Retorna()
    End Sub

    Private Sub btncancelarbusca_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancelarbusca.Click
        Me.Close()
    End Sub

    Private Sub btNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btNuevo.Click
        'Dim PROG As New CreaCliAlex
        'Dim elcodigo As String = ""
        ''PROG.ShowDialog()
        'CodigoRet = PROG.IniCrearAlex(ClioPro, elcodigo)
        'PROG.Dispose()
        'Me.Close()
        Dim validacion As Boolean
        Dim dt As DataTable = DattCom.datosEmpresa.leeParametrosEmp("par_ValiDir")

        Try
            If Convert.ToBoolean(dt.Rows(0)("par_ValiDir")) = False Then
                validacion = False
            Else
                validacion = True
            End If
        Catch ex As Exception
            validacion = False
        End Try

        If validacion = False Then
            If Not AutorizarLlamadas.VerificaAutorización("DGRegistros") Then Exit Sub

            '' --- Aquí tu primer caso ---
            'Dim prog As New directMnt.BusDirectorio()
            'Dim codigo As String = ""
            'prog.ManDir(codigo)
            'prog = Nothing

            Dim PROG As New CreaCliAlex()
            Dim elcodigo As String = ""
            Dim CodigoRet As String = prog.IniCrearAlex(ClioPro, elcodigo)
            prog.Dispose()
            Me.Close()

        Else
            'If Not AutorizarLlamadas.VerificaAutorización("DGRegistros") Then Exit Sub

            '' --- Aquí tu segundo caso, combinando con CreaCliAlex ---
            '' Si igual quieres llamar al directorio online:
            'Dim prog As New MantenimientoDirectorioOnline.BusDirectorio()
            'Dim codigo As String = ""
            'prog.ManDir(codigo)
            'prog = Nothing
        End If

    End Sub

    Private Sub ListNombre_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ListNombre.CellEnter
        fila = e.RowIndex
    End Sub

    Private Sub ListNombre_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListNombre.DoubleClick
        Retorna()
    End Sub

    Private Sub ListNombre_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ListNombre.KeyDown
        Dim PROG As New BuscaAlias
        With (ListNombre)
            If e.KeyCode = System.Windows.Forms.Keys.Return Then
                Retorna()
            ElseIf e.KeyCode = System.Windows.Forms.Keys.F3 Then
                Alias_Renamed = PROG.Buscando(ListNombre.Rows(fila).Cells(0).Value.ToString)
                Retorna()
            End If
        End With
        PROG.Dispose()
    End Sub

    Public Function IniBuscaCliOPro(ByRef CliOProv As String, ByRef CodigoNombre As String, Optional ByRef ConAlias As String = "", Optional ByRef ConNuevo As String = "", Optional ByVal medical As Boolean = False, Optional ByVal histClin As String = "", Optional ByVal telf As String = "") As String
        Inicia = True
        ClioPro = CliOProv
        CodNom = CodigoNombre
        SinNuevo = (ConNuevo <> "S")
        Label1.Visible = medical
        TextBox1.Visible = medical
        esmedical = medical
        Me.ShowDialog()
        IniBuscaCliOPro = CodigoRet
        CodigoNombre = CodNom
        ConAlias = Alias_Renamed
        Me.Close()
        Me.Dispose()
    End Function
    Public Function IniBuscaCliOPro(CliOProv As String, medical As Boolean, ByRef CodigoNombre As String) As String
        Inicia = True
        ClioPro = CliOProv
        CodNom = CodigoNombre
        SinNuevo = False
        Label1.Visible = medical
        TextBox1.Visible = medical
        esmedical = medical
        Me.ShowDialog()
        IniBuscaCliOPro = CodigoRet
        CodigoNombre = CodNom
        Me.Close()
        Me.Dispose()
    End Function

    Public Function IniBuscaCliOProVacio(ByRef CliOProv As String, ByRef CodigoNombre As String, Optional ByRef ConAlias As String = "", Optional ByRef ConNuevo As String = "", Optional ByVal medical As Boolean = False, Optional ByVal histClin As String = "", Optional ByVal telf As String = "") As String
        Inicia = False
        ClioPro = CliOProv
        CodNom = CodigoNombre
        SinNuevo = (ConNuevo <> "S")
        Label1.Visible = medical
        TextBox1.Visible = medical
        esmedical = medical
        Me.ShowDialog()
        IniBuscaCliOProVacio = CodigoRet
        CodigoNombre = CodNom
        ConAlias = Alias_Renamed
        Me.Close()
        Me.Dispose()
    End Function

    Private Sub BuscaClien_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        On Error Resume Next
        If TxtNombre.Text > "" Then
            If ListNombre.RowCount > 2 Then
            Else
                TxtNombre.Focus()
            End If
        Else
            TxtNombre.Focus()
        End If
    End Sub

    Private Sub BuscaClien_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'On Error Resume Next
        Mainn()
        'Dim prog As New daaxLib.DaxLibMalla
        btNuevo.Visible = False
        chkTodos.Checked = False
        chkCliente.Checked = False
        chkProveedor.Checked = False
        chkFinanciera.Checked = False
        chkEmpleado.Checked = False
        chkVendedor.Checked = False

        If ClioPro > "" And ClioPro <> "T" Then
            Select Case ClioPro
                Case "C"
                    chkCliente.Checked = True
                Case "P"
                    chkProveedor.Checked = True
                Case "F"
                    chkFinanciera.Checked = True
                Case "E"
                    chkEmpleado.Checked = True
                Case "V"
                    chkVendedor.Checked = True
                Case "O"
                    chkOperador.Checked = True
                Case "D"
                    chkMedico.Checked = True
                Case Else
                    chkTodos.Checked = True
            End Select
        End If
        'btNuevo.Visible = Not (SinNuevo)
        Sw = 1
        TxtNombre.Text = CodNom
        TextBox1.Text = conHistoria
        TextBox2.Text = conTelefono
        Sw = 0
        If Inicia = True Then LLenarLista()
    End Sub

    Private Sub LLenarLista()
        If Sw = 1 Then Exit Sub
        Dim sqlaux As String
        Dim seleccion3 As String
        Dim Buscod As New Syscod.ManSysnetClass
        Dim busca As String
        Dim bConInicio As String
        If ConInicio.Checked Then bConInicio = "S" Else bConInicio = "N"
        If Orden = Nothing Then Orden = "A"
        seleccion3 = ""
        busca = TxtNombre.Text
        Try
            sqlaux = "EXEC Adc_CNSALX '" & Orden & "'," & NombImpresion.CheckState & ",'" & Seleccion2 & "','" & Seleccion & "','" & bConInicio & "','" & busca & "','" & TextBox1.Text & "','" & TextBox2.Text & "'"
            Dim conectar As New SqlClient.SqlConnection(datosEmpresa.strConxAdcom)
            Dim dats As New DataSet()
            Dim dat As New SqlDataAdapter(sqlaux, conectar)
            conectar.Open()
            dat.Fill(dats, "Datos")
            ListNombre.DataSource = dats.Tables("Datos")
            ListNombre.ClearSelection()
            ListNombre.Columns("Nombre").Width = 300
        Catch ee As Exception
            MsgBox("excepción:llenarLista " & ee.Message)
        End Try
    End Sub

    Private Sub Retorna()
        'On Error Resume Next
        If Not ListNombre.CurrentCell Is Nothing Then
            With ListNombre
                'If .SelectedCells.Count > 0 Then
                fila = .CurrentCell.RowIndex
                CodigoRet = CStr(.Rows(fila).Cells(0).Value)
                CodNom = CStr(.Rows(fila).Cells(1).Value)
                'End If
            End With
        End If
        Me.Dispose()
    End Sub

    Private Sub NombImpresion_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles NombImpresion.CheckStateChanged
        LLenarLista()
    End Sub
    Private Sub Options(ByVal Index As Integer)

        On Error Resume Next
        Select Case Index
            Case Is = 0
                Seleccion2 = ""
            Case Is = 1
                Seleccion2 = "N"
            Case Is = 2
                Seleccion2 = "J"
        End Select
        LLenarLista()

    End Sub

    'Private Sub Option0_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If sender.Checked Then Options(0)
    'End Sub

    'Private Sub Option1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Option1.CheckedChanged
    '    If sender.Checked Then Options(1)
    'End Sub

    'Private Sub Option2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Option2.CheckedChanged
    '    If sender.Checked Then Options(2)
    'End Sub
    Private Sub Options1(ByVal Index As Integer)
        On Error Resume Next
        Select Case Index
            Case Is = 0
                Seleccion = ""
            Case Is = 1
                Seleccion = "C"
            Case Is = 2
                Seleccion = "P"
            Case Is = 3
                Seleccion = "B"
            Case Is = 4
                Seleccion = "E"
            Case Is = 5
                Seleccion = "V"
            Case Is = 6
                Seleccion = "O"
            Case Is = 7
                Seleccion = "A"
            Case Is = 8
                Seleccion = "R"
            Case Is = 9
                Seleccion = "D"
        End Select
        LLenarLista()
    End Sub

    Private Sub Option10_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkTodos.CheckedChanged
        If chkTodos.Checked Then Options1(0)
    End Sub

    Private Sub Option11_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkCliente.CheckedChanged
        If chkCliente.Checked Then Options1(1)
    End Sub

    Private Sub Option12_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkProveedor.CheckedChanged
        If chkProveedor.Checked Then Options1(2)
    End Sub

    Private Sub Option13_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkFinanciera.CheckedChanged
        If chkFinanciera.Checked Then Options1(3)
    End Sub

    Private Sub Option14_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkEmpleado.CheckedChanged
        If chkEmpleado.Checked Then Options1(4)
    End Sub

    Private Sub Option15_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkVendedor.CheckedChanged
        If chkVendedor.Checked Then Options1(5)
    End Sub

    Private Sub TxtNombre_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNombre.KeyDown, TextBox2.KeyDown, TextBox1.KeyDown
        Dim KeyCode As Short = CShort(e.KeyCode)
        Dim Shift As Short = CShort(e.KeyData \ &H10000)
        If KeyCode = System.Windows.Forms.Keys.Return Then LLenarLista()
    End Sub

    Private Sub TxtNombre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNombre.TextChanged
        If CBool(ConInicio.CheckState) Then LLenarLista()
    End Sub

    Private Sub Option16_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkOperador.CheckedChanged
        If chkOperador.Checked Then Options1(6)
    End Sub

    Private Sub Option17_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAsociacion.CheckedChanged
        If chkAsociacion.Checked Then Options1(7)
    End Sub

    Private Sub Option18_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkTransporte.CheckedChanged
        If chkTransporte.Checked Then Options1(8)
    End Sub

    Private Sub chkMedico_CheckedChanged(sender As Object, e As EventArgs) Handles chkMedico.CheckedChanged
        If chkMedico.Checked Then Options1(9)
    End Sub
End Class