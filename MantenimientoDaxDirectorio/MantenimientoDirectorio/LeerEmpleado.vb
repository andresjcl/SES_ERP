Imports DattCom
Friend Class LeerEmpleado
    Friend Shared Function leerEmpleado(Form As DEEP01, QueCodigo As String, TipCodSyscod() As String, LosCambios As ClassCambios, codigoDirectorio() As String) As Boolean
        Dim Buscod As New Syscod.ManSysnetClass
        Dim Busnom As New EmpNomR.AdcNomb()
        Dim classEmpleado As New dbEmpleado(datosEmpresa.strConxAdcom)
        classEmpleado = dbEmpleado.Buscar(" codigoempleado = '" & QueCodigo & "' ")
        If IsDBNull(classEmpleado) Then Return False
        If IsNothing(classEmpleado) Then Return False

        With classEmpleado
            Form.cmbCentroCostoRol.Text = .centroCosto
            LosCambios.AntCentroCosto = .centroCosto

            Form.cmbSeccionRol.Text = .Libretamilitar
            LosCambios.AntSeccion = .Libretamilitar

            Form.CodSuc = .Sucursalrol
            LosCambios.AntSucursal = Form.CodSuc
            Form.cmbSucursalRol.SelectedValue = .Sucursalrol

            Form.cmbDepartamentoRol.SelectedValue = .Departamento
            LosCambios.AntDepartamento = .Departamento

            Form.cmbCargoRol.SelectedValue = .Cargorol
            LosCambios.AntCargo = .Cargorol

            Form.fingreso.Value = .FechaIngreso
            LosCambios.AntFechaIngreso = .FechaIngreso

            Form.fsalida.Value = .FechaSalida
            LosCambios.AntFechaSalida = .FechaSalida

            Form.fJubilacion.Value = .FechaJubilacion

            Form.nivelrol.Text = .NivelRol.ToString()
            Form.Cuenta2.Text = .CtbRol_0_
            Form.Cuenta3.Text = .CtbRol_1_

            Dim tp As String = .TipoPago
            If tp = "P" Then
                Form.rolproduccion.Checked = True
            ElseIf tp = "J" Then
                Form.roldiario.Checked = True
            ElseIf tp = "S" Then
                Form.rolmensual.Checked = True
            ElseIf tp = "H" Then
                Form.RolHoras.Checked = True
            End If

            If .AcreditarBanco Then Form.AcreditaBanco.CheckState = Windows.Forms.CheckState.Checked Else Form.AcreditaBanco.CheckState = Windows.Forms.CheckState.Unchecked
            codigoDirectorio(2) = .BancoRol : Form.txtNomBanco.Text = Busnom.RetornaNombreDirectorio(codigoDirectorio(2), datosEmpresa.strConxAdcom)

            Form.Lcod11.Text = Buscod.QueNombre(.TipoSalario, TipCodSyscod(11))
            Form.txtHorasJornadaSemanal.Text = .HorSemanaParcial.ToString()
            Form.valorsueldo.Text = .ValorSueldo.ToString()
            LosCambios.AntSueldo = .ValorSueldo
            Form.txtHorasJornadaSemanal.Text = CStr(.HorSemanaParcial)
            Form.Nroctabancorol.Text = CStr(.NroCtaBancoRol)
            If .TipoCuentaBanco = "A" Then
                Form.ctaahorrosrol.Checked = True
            Else
                Form.ctaahorrosrol.Checked = False
            End If
            If .TipoCuentaBanco = "C" Then
                Form.ctacorrienterol.Checked = True
            Else
                Form.ctacorrienterol.Checked = False
            End If

            Form.Grupo1.Text = classEmpleado.Grupo_1
            Form.Grupo2.Text = classEmpleado.Grupo_2
            Form.Grupo3.Text = classEmpleado.Grupo_3
            Form.Grupo4.Text = classEmpleado.Grupo_4
            Form.Grupo5.Text = classEmpleado.Grupo_5
            Form.Grupo6.Text = classEmpleado.Grupo_6

            Select Case .EstadoRol
                Case "A"
                    Form.activorol.Checked = True
                Case "C"
                    Form.Cesanterol.Checked = True
                Case "E"
                    Form.Eliminadorol.Checked = True
                Case "J"
                    Form.Jubilado.Checked = True
            End Select

            Form.cmbModuloRol.Text = .Idusuario
            Form.CodBimetrico.Text = .codigoBiometrico
        End With

        Return True
    End Function
    Public Shared Function ExisteCodigo(codigo As String) As Boolean
        Dim resp As Boolean = False
        Using conn As New SqlClient.SqlConnection(datosEmpresa.strConxAdcom)
            conn.Open()
            Dim comm As New SqlClient.SqlCommand("select codigo from identificacion where codigo = '" + codigo + "'", conn)
            Dim dr As SqlClient.SqlDataReader = comm.ExecuteReader()
            If dr.Read Then resp = True
            Return resp
            dr.Close()
            comm.Dispose()
            conn.Close()
        End Using

    End Function
    Public Shared Function ExisteCedula(codigo As String, cedula As String) As Boolean
        Dim resp As Boolean = False
        Using conn As New SqlClient.SqlConnection(datosEmpresa.strConxAdcom)
            conn.Open()
            Dim comm As New SqlClient.SqlCommand("select codigo from identificacion where cedulaidentidadruc='" + cedula & "' and codigo <> '" & codigo & "' ", conn)
            Dim dr As SqlClient.SqlDataReader = comm.ExecuteReader()
            If dr.Read Then resp = True
            Return resp
            dr.Close()
            comm.Dispose()
            conn.Close()
        End Using
    End Function


End Class
