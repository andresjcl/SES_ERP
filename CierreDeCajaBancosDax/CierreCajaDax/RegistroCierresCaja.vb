Imports System.Data.SqlClient
Imports DattCom

Public Class RegistroCierresCaja
    Public Shared Function RegistrarcierreCaja(DatosCierre As DaxCiecaj) As Boolean
        'If MessageBox.Show("Confirma registrar el cierre de caja ? " + vbCr + "No podrá realizar el cierre nuevamente ", "Cierre de caja", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Return False
        With DatosCierre
            .IdUserCierre = datosEmpresa.usr
            .FechaFin = DateAndTime.Now
            ' DatosCierre.Sucursal = datosEmpresa.suc
            .RecibidoCheques = ValoresRecibidos.valorCheques
            .RecibidoEfectivo = ValoresRecibidos.valorEfectivo
            .RecibidoNroCheques = ValoresRecibidos.nroCheques
            .RecibidoNroTarjetas = ValoresRecibidos.nroTarjetas
            .RecibidoTarjetas = ValoresRecibidos.valorTarjetas

            .RecibidoDeUna = ValoresRecibidos.valorDeUna
            .RecibidoTransferencia = ValoresRecibidos.valorTransferencia

            Dim resp As String = .Actualizar()
            If (Left(resp, 5).ToUpper() = "ERROR") Then Return False
        End With
        Return True
    End Function
    Public Shared Function iniciarCaja(PuntoVta As String, sucursal As String, usuario As String, Optional esgeneral As Boolean = True) As DaxCiecaj
        Dim horaentrada As Date = DateAndTime.Now
        Dim InicioCaja As DateTime = New DateTime(1900, 1, 1, 0, 0, 0)
        Dim FinalizaCaja As DateTime = New DateTime(1900, 1, 1, 0, 0, 0)
        Dim DatosCierre = New DaxCiecaj(datosEmpresa.strConxAdcom)

        Dim ssql As String = "ptoVtaHorCaja '" + horaentrada.ToString() + "','" + sucursal.Trim() + "','" + PuntoVta.Trim() + "'"
        'Dim conn As New SqlConnection(datosEmpresa.strConxAdcom)
        'conn.Open()
        'Dim comm As New SqlCommand(ssql, conn)
        Dim dr As SqlDataReader = SqlDatos.leerBaseAdcom(ssql)
        Try
            If (dr.Read) Then
                InicioCaja = Convert.ToDateTime(dr.Item("FechaInicial"))
                FinalizaCaja = Convert.ToDateTime(dr.Item("FechaFinal"))
            End If
        Catch
            InicioCaja = New DateTime(1900, 1, 1, 0, 0, 0)
            FinalizaCaja = New DateTime(1900, 1, 1, 0, 0, 0)
        End Try

        If Year(InicioCaja) = 1900 Then
            MsgBox("No se ha definido los horarios de atención en cajas")
            Return DatosCierre
        End If
        dr.Close()
        '        comm.Dispose()
        ssql = "ptoVtaAptCaja '" + sucursal.Trim() + "','" + PuntoVta.Trim() + "','" + horaentrada.ToString() + "','" + InicioCaja.ToString() + "','" + FinalizaCaja.ToString() + "'"
        '       comm = New SqlCommand(ssql, conn)
        dr = SqlDatos.leerBaseAdcom(ssql) 'comm.ExecuteReader()
        Dim idClave As Int32 = 0
        Try
            If (dr.Read) Then idClave = Convert.ToInt32(dr.Item("IdClave"))
        Catch
        End Try
        If (idClave = 0 And esgeneral = False) Then
            MessageBox.Show("Se encuentra fuera del período de atención del punto de ventas \n no podrá emitir documentos")
            With DatosCierre
                .FechaIni = New DateTime(1900, 1, 1, 0, 0, 0)
                .FechaFin = New DateTime(1900, 1, 1, 0, 0, 0)
                .IdUserInicio = usuario
                .PuntoDeVenta = PuntoVta
                .Sucursal = sucursal
            End With
        Else
            ssql = " idclave = " + idClave.ToString() + " and PuntodeVenta = '" + PuntoVta + "'"
            DatosCierre = DaxCiecaj.Buscar(ssql)
            If DatosCierre Is Nothing Then
                DatosCierre = New DaxCiecaj(datosEmpresa.strConxAdcom)
                With DatosCierre
                    .FechaIni = New DateTime(1900, 1, 1, 0, 0, 0)
                    .FechaFin = New DateTime(1900, 1, 1, 0, 0, 0)
                    .IdUserInicio = usuario
                    .PuntoDeVenta = PuntoVta
                    .Sucursal = sucursal
                End With
            End If
        End If
        DatosCierre.fechaIniciaCaja = InicioCaja
        DatosCierre.fechaFinalizaCaja = FinalizaCaja
        'comm.Dispose()
        dr.Close()
        'conn.Close()
        'conn.Dispose()
        Return DatosCierre
    End Function
    Public Shared Function CargarDatosCaja(sucursal As String, ptoventa As String, idclave As Decimal) As DaxCiecaj
        Dim ssql As String = " sucursal = '" + sucursal + "' and puntodeventa = '" + ptoventa + "' and  idclave = " + idclave.ToString()
        Dim DatosCierre As DaxCiecaj
        DatosCierre = New DaxCiecaj(datosEmpresa.strConxAdcom)
        DatosCierre = DaxCiecaj.Buscar(ssql)
        If DatosCierre Is Nothing Then
            DatosCierre = New DaxCiecaj(datosEmpresa.strConxAdcom)
        End If
        Return DatosCierre
    End Function
    Public Shared Function CargarDatosCaja(sucursal As String, ptoventa As String, FechaIniCaja As DateTime, fechafinCaja As DateTime) As DaxCiecaj
        Dim ssql As String = " sucursal = '" + sucursal + "' and puntodeventa = '" + ptoventa + "' and  year(fechafin) =  1900 "
        ssql += " And fechaini >= '" + FechaIniCaja.ToString() + "'"
        ssql += " and fechafin <= '" + fechafinCaja.ToString() + "'"

        Dim DatosCierre As DaxCiecaj
        DatosCierre = New DaxCiecaj(datosEmpresa.strConxAdcom)
        DatosCierre = DaxCiecaj.Buscar(ssql)
        If DatosCierre Is Nothing Then
            DatosCierre = New DaxCiecaj(datosEmpresa.strConxAdcom)
        End If
        Return DatosCierre
    End Function

End Class

