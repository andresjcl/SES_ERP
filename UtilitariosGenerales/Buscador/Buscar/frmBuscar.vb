Option Strict On
Imports System.Data.SqlClient
Public Class frmBuscar
    Dim cadena As String = ""
    Dim conecStr As String = ""
    Dim codigo As String = ""
    Dim codRetorno As String = ""
    Dim nombre As String = ""
    Dim formato As String = ""
    Dim NombreBusca As String = ""
    Dim CodigoBusca As String = ""

    Private Sub frmBuscar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            consulta()
            'NombreBusca = gridDatos.Columns(1).HeaderCell.Value.ToString
            'CodigoBusca = gridDatos.Columns(0).HeaderCell.Value.ToString
            txtNombre.Focus()
            'txtNombre.Select(0, 0)
        Catch

        End Try
    End Sub

    Private Sub consulta()
        Dim dats As New DataTable()
        Dim datAd As New SqlDataAdapter()
        Try
            datAd = New SqlDataAdapter(Camponombre(cadena), conecStr)
            datAd.Fill(dats)
        Catch
            datAd = New SqlDataAdapter(cadena, conecStr)
            datAd.Fill(dats)
        End Try
        If IsNothing(dats) Then MsgBox("No se puede procesar la consulta" + vbCr + cadena) : Return
        If dats.Rows.Count > 0 Then
            With gridDatos
                .DataSource = dats
                .ClearSelection()
            End With
        Else
            MsgBox("No existen datos para escojer", MsgBoxStyle.Exclamation)
        End If

        dats.Dispose()
        datAd.Dispose()
    End Sub
    Private Function Camponombre(ByVal cons As String) As String
        Dim contenga As String = ""
        Dim i As Integer = InStr(cons.ToUpper, "ORDER BY")
        If i > 0 Then
            cons = cons.Substring(0, i - 1)
        End If
        If chkInicial.Checked Then
            Return "select * from (" & cons & ") r1 where ([" & NombreBusca & "] like '" & txtNombre.Text & "%'  AND [" & CodigoBusca & "] like '" & txtAbrevia.Text & "%') order by [" & NombreBusca & "]"
        Else
            Return "select * from (" & cons & ") r1 where ([" & NombreBusca & "] like '%" & txtNombre.Text & "%'  and [" & CodigoBusca & "] like '%" & txtAbrevia.Text & "%') order by [" & NombreBusca & "]"
        End If

    End Function

    Private Sub txtAbrevia_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAbrevia.KeyDown
        If e.KeyCode = Keys.Enter Then
            consulta()
        End If
    End Sub
    Private Sub gridDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridDatos.DoubleClick
        Dim fila As Long
        Try
            If gridDatos.RowCount() > 0 Then
                fila = CLng(gridDatos.SelectedCells(0).RowIndex.ToString())
                codRetorno = gridDatos.Rows(CInt(fila)).Cells(0).Value.ToString()
            Else
                codRetorno = ""
            End If
        Catch
        End Try
        Me.Close()
    End Sub

    Public Function Buscar(ByVal strcon As String, ByVal cad As String, ByVal campoCod As String, ByVal campoNom As String, ByVal formatoGrid As String, ByVal titulo As String, Optional ByVal inicio As String = "") As String
        conecStr = strcon
        cadena = cad
        codigo = campoCod
        nombre = campoNom
        NombreBusca = campoNom
        CodigoBusca = campoCod
        formato = formatoGrid
        lblTitulo.Text = titulo
        If inicio > "" Then txtNombre.Text = inicio
        Me.ShowDialog()
        Buscar = codRetorno
    End Function

    Private Sub txtNombre_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNombre.KeyDown
        If e.KeyCode = Keys.Enter Then
            consulta()
            txtNombre.Select(txtNombre.Text.Length, 0)
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        codRetorno = ""
        Me.Dispose()
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        codRetorno = ""
        Me.Dispose()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If gridDatos.SelectedCells.Count > 0 Then
            gridDatos_DoubleClick(sender, e)
        Else
            MsgBox("Es necesario que seleccione algun registro", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub btnActualiza_Click(sender As Object, e As EventArgs) Handles btnActualiza.Click
        consulta()
    End Sub

    Private Sub txtNombre_TextChanged(sender As Object, e As EventArgs) Handles txtNombre.TextChanged, txtAbrevia.TextChanged
        If chkInicial.Checked Then
            consulta()
        End If
    End Sub

End Class
