Imports System.Data.SqlClient
Imports DattCom
Public Class BuscaClientFin
    Dim Seleccion2 As String = ""
    Dim Seleccion As String = ""
    Dim Selección3 As String = ""
    Dim NombreRetorna As String = ""
    Dim ClioPro As String = ""
    Dim CodigoRetorna As String = ""
    Dim Sw As Short = 1
    Dim Alias_Renamed As String = ""
    Dim SinNuevo As Boolean = False
    Dim fila As Integer
    Dim esmedical As Boolean
    Dim conHistoria As String
    Dim conTelefono As String
    Dim Inicia As Boolean = False
    Dim BuscaInicio As String = ""
    Private Sub btnbuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnbuscar.Click
        Retorna()
    End Sub

    Private Sub btncancelarbusca_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancelarbusca.Click
        Me.Close()
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

    Public Function IniBuscaCliFinal(BuscarIni As String, CodPrincipal As String, ByRef NombrePrincipal As String, Optional ConAlias As String = "", Optional ConNuevo As String = "", Optional ByVal medical As Boolean = False, Optional ByVal histClin As String = "", Optional ByVal telf As String = "") As String
        Inicia = True
        ClioPro = CodPrincipal
        TxtNombre.Text = BuscarIni
        SinNuevo = (ConNuevo <> "S")
        esmedical = medical
        NomClienePrincipal.Text = CodPrincipal + " - " + NombrePrincipal
        Me.ShowDialog()
        IniBuscaCliFinal = CodigoRetorna
        NombrePrincipal = NombreRetorna
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

    Private Sub BuscaClienFin_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'On Error Resume Next
        Mainn()
        'Dim prog As New DaxLib.DaxLibMalla
        chkTodos.Checked = False
        btNuevo.Visible = Not (SinNuevo)
        'Sw = 1
        'TxtNombre.Text = BuscaInicio
        Sw = 0
        If Inicia = True Then LLenarLista()
    End Sub
    Private Sub LLenarLista()
        If Sw = 1 Then Exit Sub
        Dim sqlaux As String = ""
        Dim seleccion3 As String = ""
        Dim busca As String = ""
        Dim bConInicio As String = ""
        Dim TipoCliente = "F"
        If ConInicio.Checked Then bConInicio = "S" Else bConInicio = "N"
        If Orden = Nothing Then Orden = "A"
        If chkTodos.Checked Then TipoCliente = "T"
        busca = TxtNombre.Text
        Try
            ' @clientePrincipal varchar(50)= ''
            ' ,@apellido char(1) = 'A'
            ',@connombreimpresion INTEGER = 0
            ',@tipopersona char(1)= ''  
            ',@relacion char(1)=''
            ',@coninicio char(1)='N'
            ',@busca varchar(256)= ''
            ',@historiaclinica varchar(20)=''
            ',@telefono varchar(20)=''

            sqlaux = "EXEC Adc_CNSALXF '" & ClioPro & "','" & Orden & "',0,'" + TipoCliente + "','','" & bConInicio & "','" & busca & "','',''"
            Dim dats As New DataTable
            Dim dat As New SqlDataAdapter(sqlaux, datosEmpresa.strConxAdcom)
            dat.Fill(dats)
            ListNombre.DataSource = dats
            ListNombre.Columns("Nombre").Width = 300
        Catch ee As Exception
            MsgBox("excepción: llenarLista " & ee.Message)
        End Try
    End Sub

    Private Sub Retorna()
        'On Error Resume Next
        If Not ListNombre.CurrentCell Is Nothing Then
            With ListNombre
                'If .SelectedCells.Count > 0 Then
                fila = .CurrentCell.RowIndex
                CodigoRetorna = CStr(.Rows(fila).Cells(0).Value)
                NombreRetorna = CStr(.Rows(fila).Cells(1).Value)
                'End If
            End With
        End If
        Me.Dispose()
    End Sub

    Private Sub NombImpresion_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs)
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
                Seleccion = "D"
            Case Is = 7
                Seleccion = "A"
            Case Is = 8
                Seleccion = "R"
        End Select
        LLenarLista()
    End Sub

    Private Sub Option10_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkTodos.CheckedChanged
        If chkTodos.Checked Then Options1(0)
    End Sub


    Private Sub TxtNombre_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNombre.KeyDown
        Dim KeyCode As Short = CShort(e.KeyCode)
        Dim Shift As Short = CShort(e.KeyData \ &H10000)
        If KeyCode = System.Windows.Forms.Keys.Return Then LLenarLista()
    End Sub

    Private Sub TxtNombre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNombre.TextChanged
        If CBool(ConInicio.CheckState) Then LLenarLista()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        LLenarLista()
    End Sub
End Class