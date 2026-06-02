Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports DattCom
Friend Class BuscaAlias
    Dim Seleccion2 As String = ""
    Dim Seleccion As String = ""
    Dim Selección3 As String = ""
    Dim CodNom As String = ""
    Dim ClioPro As String
    Dim CodigoRet As String
    Dim Buscod As New Syscod.ManSysnetClass
    Dim Alias_Renamed As String
    Dim Codigo As String
    Dim fila As Integer
    Public Function Buscando(ByRef CodigoEmpresa As String) As String
        Codigo = CodigoEmpresa
        Me.ShowDialog()
        Buscando = Alias_Renamed
    End Function

    Private Sub btnbuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnbuscar.Click
        Retorna()
    End Sub

    Private Sub btncancelarbusca_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancelarbusca.Click
        Me.Close()
    End Sub

    Private Sub BuscaAlias_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
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

    Private Sub ListNombre_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ListNombre.CellClick
        fila = e.RowIndex
    End Sub

    Private Sub ListNombre_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListNombre.DoubleClick
        Retorna()
    End Sub

    Private Sub ListNombre_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ListNombre.KeyDown
        With ListNombre
            If e.KeyCode = System.Windows.Forms.Keys.Return Then
                Retorna()
            End If
        End With
    End Sub

    Private Sub BuscaAlias_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        On Error Resume Next
        LLenarLista()
    End Sub
    Private Sub LLenarLista()
        Dim sqlaux As String
        sqlaux = "SELECT * From identificacionalias  WHERE codigoempresa ='" & Codigo & "' order by  NombreAlias "
        Dim Conectar As New SqlClient.SqlConnection(datosEmpresa.strConxAdcom)
        Dim datt As New DataTable
        Dim dataAd As New SqlDataAdapter(sqlaux, Conectar)
        Conectar.Open()
        dataAd.Fill(datt)
        ListNombre.DataSource = datt
        ListNombre.ClearSelection()
        Conectar.Close()
        Conectar.Dispose()
        datt.Dispose()
        dataAd.Dispose()
        Exit Sub
hayerrores:
        'ControlaErrores
    End Sub

    Private Sub Retorna()
        On Error Resume Next
        CodigoRet = ListNombre.Rows(fila).Cells(0).Value.ToString
        CodNom = ListNombre.Rows(fila).Cells(1).Value.ToString
        With ListNombre.Rows(fila)
            Alias_Renamed = .Cells(1).Value.ToString & "," & .Cells(2).Value.ToString & "," & .Cells(3).Value.ToString & "," & .Cells(4).Value.ToString
        End With
        Me.Close()
    End Sub
    Private Sub NombImpresion_Click()
        LLenarLista()
    End Sub

    Private Sub Option_Click(ByRef Index As Short)
        On Error Resume Next
        Select Case Index
            Case Is = 0
                Seleccion2 = ""
            Case Is = 1
                Seleccion2 = " AND tipopersona = 'N' "
            Case Is = 2
                Seleccion2 = " AND TIPOPERSONA = 'J' "
        End Select
        LLenarLista()

    End Sub

    Private Sub Option1_Click(ByRef Index As Short)
        On Error Resume Next
        Select Case Index
            Case Is = 0
                Seleccion = ""
            Case Is = 1
                Seleccion = " AND ESCLIENTE <> 0 "
            Case Is = 2
                Seleccion = " AND ESPROVEEDOR <> 0 "
            Case Is = 3
                Seleccion = " AND ESBANCO <> 0 "
            Case Is = 4
                Seleccion = " AND ESEMPLEADO <> 0 "
        End Select
        LLenarLista()
    End Sub

    Private Sub TxtNombre_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNombre.KeyDown
        Dim KeyCode As Short = CShort(e.KeyCode)
        Dim Shift As Short = CShort(e.KeyData \ &H10000)
        If KeyCode = System.Windows.Forms.Keys.Return Then LLenarLista()
    End Sub

End Class