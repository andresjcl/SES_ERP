Option Strict Off
Option Explicit On

Imports System.Data
Imports System.Data.SqlClient
Imports DattCom

Friend Class BuscaFormasDoc
    Inherits System.Windows.Forms.Form
    Dim CodigoArt, Dedonde, CodigoRet As String
    Dim Sw As Boolean
    Dim SoloEspeciales As Boolean
    '    Dim conectar As New SqlConnection()
    Dim fila As Integer = 0


    Public Function IniciaBuscaClase(ByRef codigo As String, Optional ByRef Especial As Boolean = False) As String
        Dim DeDon As String = ""
        Dedonde = DeDon
        CodigoArt = codigo
        SoloEspeciales = Especial
        Me.ShowDialog()
        IniciaBuscaClase = CodigoRet
    End Function

    'Private Sub btNuevo_Click()
    'Pro_Clases.Show vbModal
    'End Sub

    Private Sub optcodigo_Click()
        txtnombre.Text = ""
        ArreglaMalla()
        txtnombre.Focus()
    End Sub

    Private Sub OptNombre_Click()
        On Error Resume Next
        txtnombre.Text = ""
        ArreglaMalla()
        txtnombre.Focus()
    End Sub

    'Private Sub ArreglaMalla()
    '    'Dim ConxAdcom As New ADODB.Connection
    '    Dim Seleccion As String = ""
    '    Dim busca As String = ""
    '    Dim Dsubgrupo As String = ""
    '    Dim Dcatego As String = ""
    '    Dim Categorias As String = ""
    '    Dim Dgrupo As String = ""
    '    Dim Dclase As String = ""
    '    Dim NomCod, codsql As String
    '    Dim I As Integer
    '    Dim nN() As String
    '    '        on error resume next
    '    busca = txtnombre.Text 'almaceno lo que tiene la caja de textto
    '    Seleccion = "  l0 AS CODIGO, ISNULL(L1, '') AS DESCRIPCION "
    '    If SoloEspeciales Then Categorias = " AND ISNULL(S2,'') = 'E' "
    '    NomCod = ""
    '    codsql = "SELECT " & Seleccion & " From sysforms WHERE l0 LIKE '%" & Trim(busca) & "%' and s1 = 'A' " & Categorias & " ORDER BY l0 "
    '    Dim dats As New DataSet()
    '    Dim dat As New SqlDataAdapter(codsql, DattCom.datosEmpresa.strConxAdcom)
    '    dat.Fill(dats, "Datos")
    '    ListNombre.DataSource = dats.Tables("Datos")
    '    With ListNombre
    '        For I = 0 To .RowCount - 1
    '            nN = Split(.Rows(I).Cells(1).Value.ToString, ";")
    '            If UBound(nN) > 12 Then .Rows(I).Cells(1).Value = nN(13) Else .Rows(I).Cells(1).Value = ""
    '        Next I
    '    End With
    'End Sub


    Private Sub ArreglaMalla()
        Try
            Dim busca As String = Trim(txtnombre.Text)
            Dim Categorias As String = ""

            If SoloEspeciales Then
                Categorias = " AND ISNULL(S2, '') = 'E'"
            End If

            Dim codsql As String = "SELECT l0 AS CODIGO, ISNULL(L1, '') AS DESCRIPCION " &
                               "FROM sysforms " &
                               "WHERE l0 LIKE '%" & busca & "%' AND s1 = 'A' " & Categorias &
                               " ORDER BY l0"

            Dim dats As New DataSet()
            Using dat As New SqlDataAdapter(codsql, DattCom.datosEmpresa.strConxAdcom)
                dat.Fill(dats, "Datos")
            End Using

            ' Asignar datos al DataGridView
            ListNombre.DataSource = dats.Tables("Datos")

            ' Procesar las descripciones
            For I As Integer = 0 To ListNombre.RowCount - 1
                If ListNombre.Rows(I).Cells(1).Value IsNot Nothing Then
                    Dim descripcion As String = ListNombre.Rows(I).Cells(1).Value.ToString()
                    Dim nN() As String = descripcion.Split(";"c)

                    If nN.Length > 13 Then
                        ListNombre.Rows(I).Cells(1).Value = nN(13)
                    Else
                        ListNombre.Rows(I).Cells(1).Value = ""
                    End If
                End If
            Next I

            ' Configurar el DataGridView
            With ListNombre
                .Columns(0).HeaderText = "Código"
                .Columns(0).Width = 100
                .Columns(1).HeaderText = "Descripción"
                .Columns(1).Width = 300
                .ReadOnly = True
                .AllowUserToAddRows = False
                .ClearSelection()
            End With

        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub



    Private Sub Retorna()
        If txtnombre.Text > "" Then
            CodigoRet = txtnombre.Text
        Else
            CodigoRet = ListNombre.Rows(fila).Cells(0).Value
        End If
        Me.Close()
    End Sub

    Private Sub txtnombre_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txtnombre.KeyDown
        Dim KeyCode As integer = eventArgs.KeyCode
        Dim Shift As integer = eventArgs.KeyData \ &H10000
        If KeyCode = System.Windows.Forms.Keys.Return Then ArreglaMalla()
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub BuscaFormasDoc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.Caption = "Buscar Clases Productos"
        'Dim coneccion As New DaxLib.DaxLibBases
        'coneccion.TipoBase = "10"
        'conectar.ConnectionString = coneccion.StrAdcom
        'Dim prog As New DaxLib.DaxLibMalla
        'prog = Nothing
        Sw = False
        txtnombre.Text = CodigoArt
        ArreglaMalla()
    End Sub

    Private Sub ListNombre_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ListNombre.CellDoubleClick
        If ListNombre.RowCount = 0 Then Exit Sub
        With ListNombre
            If .Rows(e.RowIndex).Cells(0).Value > "" Then Retorna()
        End With
    End Sub

    Private Sub ListNombre_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ListNombre.CellEnter
        fila = e.RowIndex
    End Sub

    Private Sub ListNombre_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ListNombre.KeyDown
        If e.KeyCode = System.Windows.Forms.Keys.Return Then ListNombre_CellDoubleClick(ListNombre, New System.EventArgs())
        If ListNombre.RowCount = 0 Then Exit Sub
    End Sub

    Private Sub btncancelarbusca_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancelarbusca.Click
        CodigoRet = CodigoArt
        Me.Close()
    End Sub

    Private Sub btnbuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnbuscar.Click
        Retorna()
    End Sub
End Class