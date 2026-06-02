Public Class MoverDatosEmpleado
    Public Shared Sub moverDatos(frmId As DEEP01, recide As dbEmpleado, TipCodSyscod() As String, CodBanco As String, codSuc As String)
        Dim Buscod As New Syscod.ManSysnetClass
        With recide
            .CodigoEmpleado = frmId.Codigo.Text
            If Not (IsNothing(frmId.cmbCentroCostoRol.SelectedValue)) Then .centroCosto = frmId.cmbCentroCostoRol.SelectedValue.ToString()
            .Libretamilitar = frmId.cmbSeccionRol.Text 'seccion
            If Not (IsNothing(frmId.cmbSucursalRol.SelectedValue)) Then .Sucursalrol = frmId.cmbSucursalRol.SelectedValue.ToString()
            If Not (IsNothing(frmId.cmbDepartamentoRol.SelectedValue)) Then .Departamento = frmId.cmbDepartamentoRol.SelectedValue.ToString()
            If Not (IsNothing(frmId.cmbCargoRol.SelectedValue)) Then .Cargorol = frmId.cmbCargoRol.SelectedValue.ToString()
            .codigoBiometrico = frmId.CodBimetrico.Text


            .FechaJubilacion = frmId.fJubilacion.Value

            .NivelRol = CByte(Val(frmId.nivelrol.Text))
            If frmId.rolproduccion.Checked = True Then
                .TipoPago = "P"
            ElseIf frmId.roldiario.Checked = True Then
                .TipoPago = "J"
            Else
                .TipoPago = "S"
            End If
            If frmId.RolHoras.Checked = True Then .TipoPago = "H"
            If frmId.AcreditaBanco.Checked Then .AcreditarBanco = True Else .AcreditarBanco = False
            .BancoRol = CodBanco
            .HorSemanaParcial = CDec(Val(frmId.txtHorasJornadaSemanal.Text))
            .TipoSalario = Buscod.QueCodigo(frmId.Lcod11.Text, TipCodSyscod(11))

            .ValorSueldo = CDec(Val(frmId.valorsueldo.Text))
            .FechaIngreso = frmId.fingreso.Value
            .FechaSalida = frmId.fsalida.Value

            .NroCtaBancoRol = frmId.Nroctabancorol.Text
            If frmId.ctaahorrosrol.Checked = True Then .TipoCuentaBanco = "A"
            If frmId.ctacorrienterol.Checked = True Then .TipoCuentaBanco = "C"
            .Grupo_1 = frmId.Grupo1.Text
            .Grupo_2 = frmId.Grupo2.Text
            .Grupo_3 = frmId.Grupo3.Text
            .Grupo_4 = frmId.Grupo4.Text
            .Grupo_5 = frmId.Grupo5.Text
            .Grupo_6 = frmId.Grupo6.Text

            If frmId.activorol.Checked = True Then
                .EstadoRol = "A"
            ElseIf frmId.Cesanterol.Checked = True Then
                .EstadoRol = "C"
            ElseIf frmId.Eliminadorol.Checked = True Then
                .EstadoRol = "E"
            ElseIf frmId.Jubilado.Checked = True Then
                .EstadoRol = "J"
            End If

            .Idusuario = frmId.cmbModuloRol.Text    ' modulo
            .CtbRol_0_ = frmId.Cuenta2.Text
            .CtbRol_1_ = frmId.Cuenta3.Text
        End With

    End Sub
End Class
