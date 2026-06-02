Public Class nombreTablas
    Public CodigosDistritoAduanero As String = "CodigosDistritoAduanero"
    Public CodigosRegimen As String = "CodigosRegimen"
    Public ComprobantesAutorizados As String = "ComprobantesAutorizados"
    Public ConceptosRetencion As String = "ConceptosRetencion"
    Public FormasDePago As String = "FormasDePago"
    Public IdentificacionProveedor As String = "IdentificacionProveedor"
    Public Paises As String = "Paises"
    Public PorcentajeIva As String = "PorcentajeIva"
    Public PorcentajeIce As String = "PorcentajeIce"
    Public RetencionIvaBienes As String = "RetencionIvaBienes"
    Public RetencionIvaServicios As String = "RetencionIvaServicios"
    Public SustentoComprobante As String = "SustentoComprobante"
    Public TarjetasCredito As String = "TarjetasCredito"
    Public TipoDeIdentificacion As String = "TipoIdentificacion"
    Public TipoExportacion As String = "TipoExportacion"
    Public TiposFideicomisos As String = "TiposFideicomisos"
    Public TiposPago As String = "TiposPago"
    'Public TiposTransacciones As String = "TiposTransacciones    "
    Public RefTiposIdentificacion As String = "RefTiposIdentificacion"
    Public RefTiposTransacciones As String = "RefTiposTransacciones"
    Public ImpRentaPersonasNaturales As String = "ImpRentaPersonasNaturales"

    Public Function armarConsulta(tipo As String, Fecha As String, tipoTransaccion As Int16, sustento As Int16, tipComprobante As Int16) As String
        Dim ssql As String = ""
        Select Case tipo
            Case CodigosDistritoAduanero
                ssql = "select * from CodigosDistritoAduanero"
            Case CodigosRegimen
                ssql = "select Código,Descripción,isnull(FechaInicio,'01/01/1900') as FechaInicio,isnull(FechaFin,'31/12/2999') as FechaFin"
                ssql += " from CodigosRegimen"
                ssql += " where isnull(FechaInicio,'01/01/1900') <= '" + Fecha + "' and isnull(FechaFin,'31/12/2999') >='" + Fecha + "'"

            Case ComprobantesAutorizados
                ssql = "select Código,Descripción,isnull(FechaFin,'31/12/2999') as FechaFin,*"
                ssql += " from ComprobantesAutorizados"
                ssql += " where  isnull(FechaFin,'31/12/2999') >= '" + Fecha + "'"
                If tipoTransaccion > 0 Then ssql += " and patindex('%" + tipoTransaccion.ToString() + "%',SecuencialTransaccion) > 0 "
                If sustento > 0 Then ssql += " and patindex('%" + sustento.ToString() + "%',SustentoTributario) > 0 "
            Case ConceptosRetencion
                ssql = "select Código,Descripción"
                ssql += " ,case when isnull(porcentaje,'-') = '-' then '0' else porcentaje end as porcentaje"
                ssql += " ,isnull(FechaInicio,'01/01/1900') as FechaInicio,isnull(FechaFin,'31/12/2999') as FechaFin"
                ssql += " from ConceptosRetencion"
                ssql += " where isnull(FechaInicio,'01/01/1900') <= '" + Fecha + "' and isnull(FechaFin,'31/12/2999') >= '" + Fecha + "'"
            Case FormasDePago
                ssql = "select Código,Descripción from FormasDePago"
            Case IdentificacionProveedor
                ssql = "select Código,Descripción from IdentificacionProveedor"
            Case Paises
                ssql = "select Código,Descripción from Paises"
            Case PorcentajeIva
                ssql = "select Porcentaje,isnull(FechaInicio,'01/01/1900') as FechaInicio,isnull(FechaFin,'31/12/2999') as FechaFin"
                ssql += " from PorcentajeIva"
                ssql += " where isnull(FechaInicio,'01/01/1900') <= '" + Fecha + "' and isnull(FechaFin,'31/12/2999') >= '" + Fecha + "'"
            Case PorcentajeIce
                ssql = "select Porcentaje,isnull(FechaInicio,'01/01/1900') as FechaInicio,isnull(FechaFin,'31/12/2999') as FechaFin"
                ssql += " from PorcentajeIce"
                ssql += " where isnull(FechaInicio,'01/01/1900') <= '" + Fecha + "' and isnull(FechaFin,'31/12/2999') >= '" + Fecha + "'"
            Case RetencionIvaBienes
                ssql = "select Código,Código + ' - ' + cast(Descripción as varchar(10)) + '%' as Descripción,isnull(FechaInicio,'01/01/1900') as FechaInicio,isnull(FechaFin,'31/12/2999') as FechaFin"
                ssql += " from RetencionIvaBienes"
                ssql += " where isnull(FechaInicio,'01/01/1900') <= '" + Fecha + "' and isnull(FechaFin,'31/12/2999') >= '" + Fecha + "'"

            Case RetencionIvaServicios
                ssql = "select Código,Código + ' - ' + cast(Descripción as varchar(10)) + '%' as Descripción,isnull(FechaInicio,'01/01/1900') as FechaInicio,isnull(FechaFin,'31/12/2999') as FechaFin"
                ssql += " from RetencionIvaServicios"
                ssql += " where isnull(FechaInicio,'01/01/1900') <= '" + Fecha + "' and isnull(FechaFin,'31/12/2999') >= '" + Fecha + "'"
            Case SustentoComprobante
                ssql = "select Código,Descripción,tipoComprobante,isnull(FechaInicio,'01/01/1900') as FechaInicio,isnull(FechaFin,'31/12/2999') as FechaFin"
                ssql += " from SustentoComprobante"
                ssql += " where isnull(FechaInicio,'01/01/1900') <= '" + Fecha + "' and isnull(FechaFin,'31/12/2999') >= '" + Fecha + "'"
                If tipComprobante > 0 Then ssql += " and patindex('%" + tipComprobante.ToString() + "%',tipoComprobante) > 0 "
            Case TarjetasCredito

            Case TipoDeIdentificacion
                ssql = "select Código,Descripción,TipoTransaccion from TipoDeIdentificacion "
                If tipoTransaccion > 0 Then ssql += " and patindex('%" + tipoTransaccion.ToString() + "%',SecuencialTransaccion) > 0 "
            Case TipoExportacion
                ssql = "select Código,Descripción from TipoExportacion "
            Case TiposFideicomisos
                ssql = "select Código,Descripción from TipoFidecomisos "
            Case TiposPago
                ssql = "select Código,Descripción from TiposPago"
            Case ImpRentaPersonasNaturales
                ssql = "select *from ImpRentaPersonasNaturales"
        End Select
        Return ssql
    End Function

    Public Function listaTablas() As String()
        Dim resp As String =
        CodigosDistritoAduanero + ";" +
        CodigosRegimen + ";" +
        ComprobantesAutorizados + ";" +
        ConceptosRetencion + ";" +
        FormasDePago + ";" +
        IdentificacionProveedor + ";" +
        Paises + ";" +
        PorcentajeIva + ";" +
        PorcentajeIce + ";" +
        RetencionIvaBienes + ";" +
        RetencionIvaServicios + ";" +
        SustentoComprobante + ";" +
        TarjetasCredito + ";" +
        TipoDeIdentificacion + ";" +
        TipoExportacion + ";" +
        TiposFideicomisos + ";" +
        TiposPago + ";" +
        RefTiposIdentificacion + ";" +
        RefTiposTransacciones + ";" +
        ImpRentaPersonasNaturales
        Return Split(resp, ";")
    End Function
End Class
