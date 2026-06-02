Public Class docImpuestos
    Public cambiadoManual As Boolean = False
    Public impstoPorcentaje1 As Double = 0   'iva
    Public impstoPorcentaje2 As Double = 0   'ice
    Public impstoPorcentaje3 As Double = 0
    Public impstoPorcentaje4 As Double = 0
    Public impstoNombre1 As String = ""
    Public impstoNombre2 As String = ""
    Public impstoNombre3 As String = ""
    Public impstoNombre4 As String = ""
    Public impstoFechaIni1 As Date = New Date(1900, 1, 1)
    Public impstoFechaFin1 As Date = New Date(1900, 1, 1)
    Public impstoFechaIni2 As Date = New Date(1900, 1, 1)
    Public impstoFechaFin2 As Date = New Date(1900, 1, 1)
    Public impstoFechaIni3 As Date = New Date(1900, 1, 1)
    Public impstoFechaFin3 As Date = New Date(1900, 1, 1)
    Public impstoFechaIni4 As Date = New Date(1900, 1, 1)
    Public impstoFechaFin4 As Date = New Date(1900, 1, 1)
    Public Sub cargar(strSri As String, fecha As Date)
        Dim nm As New nombreTablas()
        Dim dt As New DataTable()
        Dim ssql As String = "select Porcentaje,isnull(FechaInicio ,'01/01/1900') as FechaInicio,isnull(fechaFin,'31/12/2999') as FechaFin  from " + nm.PorcentajeIva
        ssql += " where isnull(FechaInicio ,'01/01/1900') <= '" + fecha.ToShortDateString + "' and isnull(fechaFin,'31/12/2999') >= '" + fecha.ToShortDateString + "'"
        Dim da As New SqlClient.SqlDataAdapter(ssql, strSri)
        da.Fill(dt)
        impstoNombre1 = "IVA"
        If dt.Rows.Count > 0 Then
            impstoPorcentaje1 = Convert.ToDouble(dt.Rows(0).Item("Porcentaje")) * 100
            impstoFechaIni1 = Convert.ToDateTime(dt.Rows(0).Item("FechaInicio"))
            impstoFechaFin1 = Convert.ToDateTime(dt.Rows(0).Item("FechaFin"))
        Else
            impstoPorcentaje1 = 0
            impstoFechaIni1 = New Date(1900, 1, 1)
            impstoFechaFin1 = New Date(1900, 1, 1)
        End If

        'ssql = "select Porcentaje,isnull(FechaInicio ,'01/01/1900') as FechaInicio,isnull(fechaFin,'31/12/2999') as FechaFin  from " + nm.PorcentajeIce
        'ssql += " where isnull(FechaInicio ,'01/01/1900') <= '" + fecha.ToShortDateString + "' and isnull(fechaFin,'31/12/2999') >= '" + fecha.ToShortDateString + "'"
        'da = New SqlClient.SqlDataAdapter(ssql, strSri)
        'da.Fill(dt)
        'impstoNombre2 = "ICE"
        'If dt.Rows.Count > 0 Then
        '    impstoPorcentaje2 = Convert.ToDouble(dt.Rows(0).Item("Porcentaje")) * 100
        '    impstoFechaIni2 = Convert.ToDateTime(dt.Rows(0).Item("FechaInicio"))
        '    impstoFechaFin2 = Convert.ToDateTime(dt.Rows(0).Item("FechaFin"))
        'Else
        '    impstoPorcentaje2 = 0
        '    impstoFechaIni2 = New Date(1900, 1, 1)
        '    impstoFechaFin2 = New Date(1900, 1, 1)
        'End If

        nm = Nothing
        dt.Dispose()
        da.Dispose()
    End Sub
End Class