Imports System.Data.SqlClient
Public Class valorIva
    Public Function ValorIvaAfecha(fecha As DateTime, strSri As String) As Double
        Dim valIva As Double = 0

        Dim ssql As String = "select Porcentaje,isnull(FechaInicio,'01/01/1900') as FechaInicio,isnull(FechaFin,'31/12/2999') as FechaFin"
        ssql += " from PorcentajeIva"
        ssql += " where isnull(FechaInicio,'01/01/1900') <= '" + fecha.ToShortDateString() + "' and isnull(FechaFin,'31/12/2999') >= '" + fecha.ToShortDateString() + "'"
        Dim da As New SqlDataAdapter(ssql, strSri)
        Dim dt As New DataTable
        Try
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                valIva = Convert.ToDouble(dt.Rows(0)("Porcentaje")) * 100
            End If
        Catch
        End Try
        Return valIva
    End Function
End Class
Public Class valorIce
    Public Function ValorIceAfecha(fecha As DateTime, strSri As String) As Double
        Dim valIce As Double = 0

        'Dim ssql As String = "select Porcentaje,isnull(FechaInicio,'01/01/1900') as FechaInicio,isnull(FechaFin,'31/12/2999') as FechaFin"
        'ssql += " from PorcentajeIce"
        'ssql += " where isnull(FechaInicio,'01/01/1900') <= '" + fecha.ToShortDateString() + "' and isnull(FechaFin,'31/12/2999') >= '" + fecha.ToShortDateString() + "'"
        'Dim da As New SqlDataAdapter(ssql, strSri)
        'Dim dt As New DataTable
        'Try
        '    da.Fill(dt)
        '    If dt.Rows.Count > 0 Then
        '        valIce = Convert.ToDouble(dt.Rows(0)("Porcentaje")) * 100
        '    End If
        'Catch

        'End Try

        Return valIce
    End Function
End Class
