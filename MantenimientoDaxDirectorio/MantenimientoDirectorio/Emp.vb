Imports DattCom
Public Class Emp
    Public Shared PathImagenes As String
    Public Shared rol As Boolean
    Public Shared OrdenaPorApellidos As Boolean  ' esta en emp.Acumhis
    Public Shared Sub CargarValores()
        Dim dt As DataTable = DattCom.datosEmpresa.leeParametrosEmp("EMP_PathImagenes,PAR_AcumHis")
        If dt.Rows.Count > 0 Then
            OrdenaPorApellidos = Convert.ToBoolean(dt.Rows(0)("PAR_AcumHis"))
            PathImagenes = dt.Rows(0)("EMP_PathImagenes").ToString()
        End If
        dt.Dispose()
        Try
            If (datosEmpresa.auto.Length > 8) Then rol = (datosEmpresa.auto.Substring(7, 1) = "1")
        Catch
        End Try

    End Sub

End Class
