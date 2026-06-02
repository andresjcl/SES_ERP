Imports System.Data
Imports System.Data.SqlClient

Public Class medidasArticulos
    Public Function MulMedida(DeMed As String, AMed As String, strsys As String) As Double
        If DeMed = AMed Or DeMed = "" Or AMed = "" Then Return 1
        Dim Medida As New DataTable
        Dim da As New SqlDataAdapter("select isnull(Cnv_Multiplo,1) as Cnv_Multiplo from conversion where Cnv_DeMedida = '" + DeMed + "' and Cnv_Amedida = '" + AMed + "'", strsys)
        Using (Medida)
            Using (da)
                da.Fill(Medida)
                If Medida.Rows.Count = 0 Then Return 1
                Return CDbl(Medida.Rows(0)("Cnv_Multiplo"))
            End Using
        End Using
    End Function

    Public Function CambiaEmpaque(AMed As String, strdax As String, strsys As String, Optional codigo As String = "") As Double
        Dim rs As New DataTable
        Dim ssql As String
        On Error Resume Next
        CambiaEmpaque = 0
        ssql = "SELECT Art_codigo, isnull(Art_unimed,'') as art_unimed"
        ssql = ssql & ", isnull(CodEmpaque1,'') as CodEmpaque1, isnull(ValEmpaque1,0) as ValEmpaque1, isnull(CodEmpaque2,'') as CodEmpaque2, isnull(ValEmpaque2,0) as ValEmpaque2 "
        ssql = ssql & ", isnull(CodEmpaque3,'') as CodEmpaque3, isnull(ValEmpaque3,0) as ValEmpaque3, isnull(CodEmpaque4,'') as CodEmpaque4, isnull(ValEmpaque4,0) as ValEmpaque4"
        ssql = ssql & ", isnull(CodEmpaque5,'')as CodEmpaque5, isnull(ValEmpaque5,0) as ValEmpaque5"
        ssql = ssql & " From AdcArt "
        ssql = ssql & " where art_codigo = '" + codigo + "' "
        Dim da As New SqlDataAdapter(ssql, strdax)
        da.Fill(rs)
        If rs.Rows.Count > 0 Then
            If rs.Rows(0)("art_unimed").ToString() = AMed Then rs.Dispose() : Return 1
            With rs.Rows(0)
                Select Case AMed
                    Case .Item("codempaque1").ToString()
                        CambiaEmpaque = CDbl(.Item("valempaque1"))
                    Case .Item("codempaque2").ToString()
                        CambiaEmpaque = CDbl(.Item("valempaque2"))
                    Case .Item("codempaque3").ToString()
                        CambiaEmpaque = CDbl(.Item("valempaque3"))
                    Case .Item("codempaque4").ToString()
                        CambiaEmpaque = CDbl(.Item("valempaque4"))
                    Case .Item("codempaque5").ToString()
                        CambiaEmpaque = CDbl(.Item("valempaque5"))
                End Select
            End With
        End If
        rs.Dispose()
        If CambiaEmpaque = 0 Then
            da = New SqlDataAdapter("select isnull(caracteristica1,0) as valor from syscod where tiporeferencia = 'empaque' and Abreviación = '" & AMed & "' ", strsys)
            If rs.Rows.Count > 0 Then
                CambiaEmpaque = Val(rs.Rows(0)("Valor"))
            End If
            rs = Nothing
        End If
    End Function
End Class
