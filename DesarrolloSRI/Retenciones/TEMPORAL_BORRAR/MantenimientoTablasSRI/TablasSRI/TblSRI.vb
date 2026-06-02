
Public Class TblSRI
    Public Sub TablasSRI()
        Dim tb As New frmTablasSri
        tb.Show()
    End Sub

    '    Public Function Consultar(ByVal Tabla As String, ByVal codigo As String, ByVal fecIni As Date, patappl As String) As String
    '        Dim id As String = ""
    '        Dim id1 = "", id2 As String = ""
    '        Dim tb As New frmTablasSri
    '        Dim num As Integer = 0
    '        Dim path As String = patappl & "XML\SRI\"
    '        Dim dst As New DataSet()
    '        Dim Datos As DataRow
    '        Dim numcol As Integer = 0
    '        dst.ReadXml(path & Tabla & ".xml")
    '        numcol = dst.Tables(0).Columns.Count - 1
    '        For j = 0 To dst.Tables(0).Rows.Count - 1
    '            Datos = dst.Tables(0).Rows(j)
    '            If Datos("codigo").ToString = codigo And CDate(Datos("fechaInicio").ToString) = fecIni Then
    '                If dst.Tables(0).Columns(numcol).ToString = "IdCta1" Or dst.Tables(0).Columns(numcol - 1).ToString = "IdCta1" Then
    '                    If Not IsDBNull(Datos("IdCta1")) Then id1 = CStr(Datos("IdCta1"))
    '                End If
    '                If dst.Tables(0).Columns(numcol).ToString = "IdCta2" Or dst.Tables(0).Columns(numcol - 1).ToString = "IdCta2" Then
    '                    If Not IsDBNull(Datos("IdCta2")) Then id2 = CStr(Datos("IdCta2"))
    '                End If
    '            End If
    '        Next
    '        If id1 <> "" And id2 <> "" Then
    '            id = id1 & ";" & id2
    '        ElseIf id1 <> "" And id2 = "" Then
    '            id = id1
    '        ElseIf id1 = "" And id2 <> "" Then
    '            id = " ;" & id2
    '        End If
    '        dst.Dispose()
    '        Return id
    '    End Function
End Class
