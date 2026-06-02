Option Strict On
Imports System.Data.SqlClient
Public Class frmBuscar
    Dim conectar As New SqlConnection()
    Dim nomTabla As String = ""
    Dim strConxIvaret As String = ""
    Dim strConxAdcom As String = ""
    Dim codigo As String = ""
    Dim codRetorno As String = ""
    Dim nomRetorno As String = ""
    Dim nombre As String = ""
    Dim formato As String = ""
    Dim NombreBusca As String = ""
    Dim pathArchivo As String = ""
    Dim clasTab As New nombreTablas()
    Dim tipoTransac As Int16 = 0
    Private Sub frmBuscar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            consulta(nomTabla, False)
            NombreBusca = Malla.Columns(1).HeaderCell.Value.ToString
            txtNombre.Focus()
            'txtNombre.Select(0, 0)
        Catch

        End Try
    End Sub

    Private Sub consulta(ByVal consultaSrt As String, Optional ByVal ConCambio As Boolean = True, Optional ByVal strInicio As String = "")

        Dim dt As New DataTable

        Dim ssql As String = clasTab.armarConsulta(nomTabla, DateTime.Now.ToShortDateString, tipoTransac, 0, 0)
        Malla.Columns.Clear()
        Try
            Dim da As New SqlDataAdapter(ssql, strConxIvaret)
            da.Fill(dt)
            Malla.DataSource = dt
        Catch
        End Try
        Malla.ShowCellToolTips = False
        dt.Dispose()
    End Sub

    Private Function Camponombre(ByVal cons As String) As String
        Dim contenga As String = ""
        Dim i As Integer = InStr(cons.ToUpper, "ORDER BY")
        If i > 0 Then
            cons = cons.Substring(0, i - 1)
        End If
        Dim aux As String = ""
        Dim nom As String = ""
        aux = "select * from (" & cons & ") r1 where [" & NombreBusca & "] like '%" & txtNombre.Text & "%' order by [" & NombreBusca & "]"
        Return aux
    End Function

    Private Sub txtAbrevia_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAbrevia.KeyDown
        If e.KeyCode = Keys.Enter Then
            consulta(nomTabla)
        End If
    End Sub

    Private Sub txtAbrevia_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAbrevia.TextChanged
        consulta(nomTabla)
    End Sub

    Private Sub gridDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Malla.DoubleClick
        Dim fila As Integer = 0
        Dim Col As Integer = 0
        Dim nombre As String = ""
        'For i = 0 To gridDatos.ColumnCount - 1
        '    nombre = gridDatos.Columns(i).Name.ToUpper
        '    If nombre = "DESCRIPCIÓN" Or nombre = "DESCRIPCION" Or nombre = "NOMBRE" Then Col = i
        'Next
        'If Col = 0 Then Col = 1
        Try
            If Malla.RowCount() > 0 Then
                fila = CInt(Malla.SelectedCells(0).RowIndex.ToString())
                codRetorno = Malla.Rows(CInt(fila)).Cells(0).Value.ToString()
                nomRetorno = Malla.Rows(CInt(fila)).Cells(1).Value.ToString()
            Else
                codRetorno = ""
                nomRetorno = ""
            End If
        Catch
        End Try
        Me.Close()
    End Sub

    Public Function Buscar(ByVal tipTransacion As Int16, ByVal strcon As String, ByVal striva As String, ByVal tabla As String, ByVal campoCod As String, ByVal campoNom As String, ByVal titulo As String, ByRef nombre As String, Optional ByVal inicio As String = "") As String
        tipoTransac = tipTransacion
        strConxAdcom = strcon
        strConxIvaret = striva
        nomTabla = tabla
        codigo = campoCod
        nombre = campoNom
        lblTitulo.Text = titulo
        If inicio > "" Then txtNombre.Text = inicio
        Me.ShowDialog()
        Buscar = codRetorno
    End Function

    Private Sub txtNombre_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNombre.KeyDown
        If e.KeyCode = Keys.Enter Then
            consulta(nomTabla)
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
        If Malla.SelectedCells.Count > 0 Then
            gridDatos_DoubleClick(sender, e)
        Else
            MsgBox("Es necesario que seleccione algun registro", MsgBoxStyle.Information)
        End If
    End Sub

End Class
