Imports DattCom
Public Class ClassCambios
    Public AntFechaIngreso As Date
    Public AntFechaSalida As Date
    Public AntSucursal As String
    Public AntDepartamento As String
    Public AntCentroCosto As String
    Public AntModulos As String
    Public AntCargo As String
    Public AntSeccion As String
    Public AntSueldo As Double


End Class
Public Class verificaCambios
    Public Shared Function verificaCambios(LosCambios As ClassCambios, datEmple As dbEmpleado, esCreacion As Boolean) As String
        Dim cmb As String = ""
        Dim datMovPer As New BeeDat.AdcMovPer(datosEmpresa.strConxAdcom)
        Dim cambiaSueldo As Boolean = False

        With datEmple
            If LosCambios.AntFechaIngreso <> .FechaIngreso Then
                cambiaSueldo = True
                cmb += "Fecha de Ingreso, "
                datMovPer.FechaIngreso = .FechaIngreso
            End If
            If LosCambios.AntFechaSalida <> .FechaSalida Then
                cmb += "Fecha de Salida, "
                datMovPer.FechaSalida = .FechaSalida
            End If
            If LosCambios.AntSueldo <> .ValorSueldo Then
                cmb += "Sueldo, "
                datMovPer.Sueldo = .ValorSueldo
            End If

            If esCreacion = False Then
                If LosCambios.AntCargo <> .Cargorol Then
                    cmb += "Cargo, "
                    datMovPer.Cargo = .Cargorol
                End If
                If LosCambios.AntCentroCosto <> .centroCosto Then
                    cmb += "Centro de costo, "
                    datMovPer.CentroCosto = .centroCosto
                End If
                If LosCambios.AntDepartamento <> .Departamento Then
                    cmb += "Departamento, "
                    datMovPer.Departamento = .Departamento
                End If
                If LosCambios.AntSucursal <> .Sucursalrol Then
                    cmb += "Sucursal, "
                    datMovPer.Sucursal = .Sucursalrol
                End If
            End If

            If cmb.Length > 3 Then
                datMovPer.CodigoEmpleado = datEmple.CodigoEmpleado
                datMovPer.RegistroEquipo = Environment.MachineName
                datMovPer.RegistroOpcion = "Mant.Directorio"
                datMovPer.RegistroUsuario = datosEmpresa.usr
                datMovPer.TipoMovimiento = "CAMBIOS"
                If (.FechaIngreso > New DateTime(1900, 1, 1) And cambiaSueldo) Then
                    datMovPer.FechaRegistro = .FechaIngreso
                Else
                    datMovPer.FechaRegistro = DateTime.Now()
                End If

                If esCreacion Then datMovPer.Observaciones = "Se registraron " + cmb Else datMovPer.Observaciones = "Se cambiaron " + cmb

                datMovPer.Actualizar()

            End If

        End With


        Return cmb


    End Function

    Private Sub guardarMovimiento()

    End Sub
End Class