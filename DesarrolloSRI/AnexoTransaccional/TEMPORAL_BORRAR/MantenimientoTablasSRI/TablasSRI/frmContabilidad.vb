Imports System.Data
Imports System.Data.SqlClient

Public Class frmContabilidad
    'Public Campos() As String
    Dim tabla As String
    Dim mallaSri As DataGridView
    Dim dt As New DataTable
    Dim da As New SqlDataAdapter
    Dim ssql As String = ""
    Dim strConxAdcom As String = ""

    Private Sub frmContabilidad_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim i As Integer = 0
        Me.Text = "Registrar identificatvos contables para " & tabla
        tabla = UCase(tabla)
        Arreglarmalla()
    End Sub

    Private Sub Arreglarmalla()
        Me.Cursor = Cursors.WaitCursor
        Dim prog As New DaxLib.DaxLibBases
        ssql = "Select codigo,porcentaje,idcontable1,idcontable2 from adcsrictb where tabla = '" & tabla & "'"
        prog.TipoBase = "10"
        strConxAdcom = prog.StrAdcom
        da = New SqlDataAdapter(ssql, strConxAdcom)
        da.Fill(dt)
        malla.DataSource = dt
        Dim reg As Integer = dt.Rows.Count
        Dim existe As Boolean = False
        Dim valido As Boolean = True
        Dim porcentaje As String
        Dim hoy As Date = DateTime.Now
        Dim fechaDato As Date
        For i As Integer = 0 To mallaSri.Rows.Count - 2
            existe = False
            Dim rowSri As DataGridViewRow = mallaSri.Rows(i)
            Try
                fechaDato = Convert.ToDateTime(rowSri.Cells("fechaFin").Value)
            Catch
                fechaDato = New Date(2999, 12, 31)
            End Try
            If fechaDato.Year = 1900 Then fechaDato = New Date(2999, 12, 31)
            If ((chkValidos.Checked And fechaDato >= hoy) Or chkValidos.Checked = False) Then
                If reg > 0 Then
                    If tabla.Substring(0, 12).ToUpper = "RETENCIONIVA" Then
                        porcentaje = rowSri.Cells("Descripción").Value.ToString()
                    Else
                        porcentaje = rowSri.Cells("porcentaje").Value.ToString()
                    End If
                    For j As Integer = 0 To reg - 1
                        If malla.Rows(j).Cells("codigo").Value.ToString() = rowSri.Cells("código").Value.ToString() Then
                            If malla.Rows(j).Cells("porcentaje").Value.ToString() = porcentaje Then
                                'malla.Rows(j).Cells("IdContable1").Value = rowSri.Cells("IdContable1").Value.ToString()
                                'malla.Rows(j).Cells("IdContable2").Value = rowSri.Cells("IdContable2").Value.ToString()
                                existe = True
                            End If
                        End If
                    Next
                End If
                If existe = False Then insertarMallaData(rowSri, dt, "", "")
            End If
        Next
        prog = Nothing


        '    Do While rs.Read
        '        codigo = CStr(rs.Item("codigo"))
        '        porcentaje = CLng(rs.Item("porcentaje"))

        '        For Each rr As DataGridViewRow In malla.Rows
        '            codigom = CStr(rr.Cells("codigo").Value)
        '            porcentajem = CLng(rr.Cells("porcentaje").Value)
        '            If codigo = codigom And porcentaje = porcentajem Then
        '                rr.Cells("IdContable1").Value = rs.Item("IdContable1").ToString
        '                rr.Cells("IdContable2").Value = rs.Item("IdContable2").ToString
        '            End If
        '        Next
        '    Loop


        'If IsDBNull(Campos) Then Exit Sub
        'Dim linea() As String
        'Dim i As Integer = 0
        'If Campos.Length = 0 Then Exit Sub
        'With malla
        '    .Columns.Add("codigo", "codigo")
        '    .Columns.Add("concepto", "concepto")
        '    .Columns.Add("porcentaje", "porcentaje")
        '    .Columns.Add("IdContable1", "IdContable1")
        '    .Columns.Add("IdContable2", "IdContable2")

        '    .Columns("codigo").ReadOnly = True
        '    .Columns("concepto").ReadOnly = True
        '    .Columns("porcentaje").ReadOnly = True
        '    For i = 0 To Campos.Length - 1
        '        linea = Split(Campos(i), ",")
        '        .Rows.Add(linea)
        '    Next
        '    Dim prog As New DaxLib.DaxLibBases
        '    prog.TipoBase = "10"
        '    Dim conxAdcomdx As New SqlClient.SqlConnection(prog.StrAdcom)
        '    conxAdcomdx.Open()
        '    Dim ssql As String = "Select codigo,porcentaje,idcontable1,idcontable2 from adcsrictb where tabla = '" & tabla & "'"
        '    Dim comando As New SqlClient.SqlCommand(ssql, conxAdcomdx)
        '    Dim rs As SqlClient.SqlDataReader
        '    Dim codigo As String
        '    Dim porcentaje As Long
        '    Dim codigom As String
        '    Dim porcentajem As Long
        '    rs = comando.ExecuteReader

        '    Do While rs.Read
        '        codigo = CStr(rs.Item("codigo"))
        '        porcentaje = CLng(rs.Item("porcentaje"))

        '        For Each rr As DataGridViewRow In malla.Rows
        '            codigom = CStr(rr.Cells("codigo").Value)
        '            porcentajem = CLng(rr.Cells("porcentaje").Value)
        '            If codigo = codigom And porcentaje = porcentajem Then
        '                rr.Cells("IdContable1").Value = rs.Item("IdContable1").ToString
        '                rr.Cells("IdContable2").Value = rs.Item("IdContable2").ToString
        '            End If
        '        Next
        '    Loop

        'End With
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub insertarMallaData(row As DataGridViewRow, dt As DataTable, idctb1 As String, idctb2 As String)
        Dim drow As New DataGridViewRow
        Dim valor As Double = 0
        Dim porc As String
        If Not IsDBNull(row.Cells("código").Value) Then
            If Not row.Cells("código").Value.ToString() = "" Then
                dt.Rows.Add()
                drow = malla.Rows(dt.Rows.Count - 1)
                drow.Cells("codigo").Value = row.Cells("código").Value
                If tabla.Substring(0, 12).ToUpper = "RETENCIONIVA" Then
                    porc = row.Cells("Descripción").Value.ToString()
                Else
                    porc = row.Cells("porcentaje").Value.ToString()
                End If
                Try
                    valor = Convert.ToDouble(porc)
                Catch
                    valor = 0
                End Try
                drow.Cells("porcentaje").Value = valor
                drow.Cells("IdContable1").Value = idctb1
                drow.Cells("IdContable2").Value = idctb2
            End If
        End If
    End Sub
    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        malla.EndEdit()
        Dim ssql As String = ""
        Dim prog As New DaxLib.DaxLibBases
        prog.TipoBase = "10"
        Dim conectar As New SqlClient.SqlConnection(prog.StrAdcom)
        conectar.Open()
        Dim rs As SqlClient.SqlCommand
        rs = New SqlClient.SqlCommand("delete from Adcsrictb where tabla = '" & tabla & "'", conectar)
        rs.ExecuteNonQuery()

        For Each rr As DataGridViewRow In malla.Rows
            Try
                If rr.Cells("codigo").Value.ToString() > "" And (rr.Cells("IdContable1").Value.ToString() > "" Or rr.Cells("IdContable2").Value.ToString() > "") Then

                    ssql = "INSERT INTO [Adcsrictb] ([tabla], [codigo],[porcentaje],[IdContable1],[IdContable2]) VALUES ("
                    ssql &= "'" & tabla & "'"
                    ssql &= ",'" & rr.Cells("codigo").Value.ToString() & "'"
                    'ssql &= ",'" & Replace(CStr(rr.Cells("concepto").Value), "'", " ") & "'"
                    ssql &= "," & rr.Cells("porcentaje").Value.ToString()
                    ssql &= ",'" & rr.Cells("IdContable1").Value.ToString() & "'"
                    ssql &= ",'" & rr.Cells("IdContable2").Value.ToString() & "'"
                    ssql &= ")"
                    rs = New SqlClient.SqlCommand(ssql, conectar)
                    rs.ExecuteNonQuery()
                End If
            Catch
                MsgBox(Err.Description)
            End Try
        Next
        rs.Dispose()
        conectar.Close()
        conectar.Dispose()
        prog = Nothing
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        malla.EndEdit()
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub DataGridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles malla.KeyDown
        Dim prog As New MantCtb.BuscaCta
        Dim nombre As String = ""
        If (e.KeyCode = Keys.F2) Then
            Dim codigo As String = prog.BuscaCtaCtb(nombre, "I")
            With malla
                .Rows(.CurrentCell.RowIndex).Cells(.CurrentCell.ColumnIndex).Value = codigo
            End With
        End If
    End Sub

    Public Sub New(malla As DataGridView, laTabla As String)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        mallaSri = malla
        tabla = laTabla
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub chkValidos_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkValidos.CheckedChanged
        If IsNothing(mallaSri) = False Then Arreglarmalla()
    End Sub

    Private Sub bntCancelar_Click(sender As Object, e As EventArgs) Handles bntCancelar.Click

    End Sub
End Class
