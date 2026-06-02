Imports System.Data.SqlClient
Imports System.Windows.Forms
Public Class Depreciacion
    Public fechaD, fechaH As Date
    Dim cod As String = ""
    Dim tipoDep As String = ""
    Dim mesIniDepr As Int32
    Dim añoIniDepr As Int32
    Dim mesFinDepr As Int32
    Dim añoFinDepr As Int32
    Dim fec1 As String
    Dim fec2 As String
    Dim nombreMes As String
    Dim conectarBDD As New SqlConnection()
    Dim strConxAdcom As String = ""
    Private Sub btnDepreciar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDepreciar.Click
        Dim valor As Integer = 0
        Dim dep As New depreciaActivoFijo.depreciaActivoFijo()
        Dim depAnt = 0, depAct = 0, depMayor As Integer = 0
        ' este metodo verifica que se hayan ingresado correctamente las fechas para poder depreciar
        Fechas()
        If (verificarInformacion() = False) Then Return
        cod = txtCod.Text
        ' se verifica si existen depreciaciones anteriores a las fechas ingresadas


        Me.UseWaitCursor = True
        Me.Cursor = Cursors.WaitCursor
        Timer1.Enabled = True

        Dim ssql As String = "Select codigo from adcacf "
        If txtCod.Text.Trim() > "" Then ssql += " where codigo = '" + txtCod.Text + "'"
        Dim cmd As New SqlCommand(ssql, conectarBDD)
        Dim dat As SqlDataReader

        Dim usrclv As New DaxUsr.DaxsofUsr
        Dim ussr As DaxUsr.CtrlUsuario = usrclv.UsuarioAct
        If conectarBDD.State = ConnectionState.Open Then conectarBDD.Close()
        conectarBDD.Open()
        dat = cmd.ExecuteReader()
        Do While (dat.Read)
            valDepreciacion.validar(False, dat("Codigo").ToString(), añoIniDepr, mesIniDepr, añoFinDepr, mesFinDepr, strConxAdcom)
            dep.calcularDepreciaciones(strConxAdcom, dat("Codigo").ToString(), fechaD, fechaH, ussr.Identifica)
            If valDepreciacion.depMayor Then valDepreciacion.eliminarDepreciaciones(mesIniDepr, añoIniDepr, mesFinDepr, añoFinDepr, dat("Codigo").ToString(), strConxAdcom)
        Loop
        conectarBDD.Close()
        dat.Close()
        dat = Nothing

        Dim conf As Integer
        Me.UseWaitCursor = False
        Me.Cursor = Cursors.Default
        conf = MsgBox("Proceso Realizado con Exito !!", MsgBoxStyle.OkOnly)
        If conf = vbOK Then
            txtCod.Text = ""
        End If
    End Sub

    Private Sub Fechas()
        Dim ms As Integer = Convert.ToInt32(cmbMesFinaliza.SelectedIndex) + 1
        Dim añ As Integer = Convert.ToInt32(txtAñoFinaliza.Text)

        fechaD = New DateTime(Convert.ToInt16(txtAñoInicia.Text), Convert.ToInt32(cmbMesInicial.SelectedIndex) + 1, 1)
        fechaH = New DateTime(Convert.ToInt16(txtAñoFinaliza.Text), Convert.ToInt32(cmbMesFinaliza.SelectedIndex) + 1, 1)
        fechaH = DateAdd(DateInterval.Month, 1, fechaH)
        fechaH = DateAdd(DateInterval.Day, -1, fechaH)
        mesIniDepr = Convert.ToInt16(cmbMesInicial.SelectedIndex) + 1
        añoIniDepr = CInt(txtAñoInicia.Text)
        mesFinDepr = Convert.ToInt16(cmbMesFinaliza.SelectedIndex) + 1
        añoFinDepr = CInt(txtAñoFinaliza.Text)
        'txtFechaDesde = fechaD
        'txtFechaHasta = fechaH

        ''------- comprueba si tiene acumulados y envia la fecha a la que se ingreso los acumulados
        'Dim mss, aññ As Integer
        'Dim ssql As String = "Select mes, año from AdcAcfDep where Acumulados=1"
        'Dim cmd As New SqlCommand(ssql, conectarBDD)
        'Dim dat As SqlDataReader
        'If conectarBDD.State = ConnectionState.Open Then conectarBDD.Close()
        'conectarBDD.Open()
        'dat = cmd.ExecuteReader()
        'If dat.Read Then
        '    If Convert.ToInt16(dat(0)) = 12 Then mss = 1 : aññ = (Convert.ToInt16(dat(1)) + 1) Else mss = Convert.ToInt16(dat(0)) : aññ = Convert.ToInt16(dat(1))
        '    fechaD = CDate("01/" & mss & "/" & aññ)
        'End If
        'conectarBDD.Close()
        ''-------------------------------------------------------------------------------------
    End Sub


    ' verifica que se hayan ingresado las fechas para la depreciación
    Public Function verificarInformacion() As Boolean
        If Val(txtAñoInicia.Text) = 0 Then
            MsgBox("Es Necesario Ingresar la Fecha de Inicio de la Depreciación", MsgBoxStyle.Information)
            Return False
        ElseIf Val(txtAñoFinaliza.Text) = 0 Then
            MsgBox("Es Necesario Ingresar la Fecha Final de la Depreciación", MsgBoxStyle.Information)
            Return False
        End If
        Return True
    End Function


    'Public Sub Nombre(ByVal mes As Long)
    '    If mes = 1 Then
    '        nombreMes = "Enero"
    '    ElseIf mes = 2 Then
    '        nombreMes = "Febrero"
    '    ElseIf mes = 3 Then
    '        nombreMes = "Marzo"
    '    ElseIf mes = 4 Then
    '        nombreMes = "Abril"
    '    ElseIf mes = 5 Then
    '        nombreMes = "Mayo"
    '    ElseIf mes = 6 Then
    '        nombreMes = "Junio"
    '    ElseIf mes = 7 Then
    '        nombreMes = "Julio"
    '    ElseIf mes = 8 Then
    '        nombreMes = "Agosto"
    '    ElseIf mes = 9 Then
    '        nombreMes = "Septiembre"
    '    ElseIf mes = 10 Then
    '        nombreMes = "Octubre"
    '    ElseIf mes = 11 Then
    '        nombreMes = "Noviembre"
    '    Else
    '        nombreMes = "Diciembre"
    '    End If
    'End Sub

    'elimina las depreciaciones existentes
    Public Sub EliminarDepreciacion(Año As Int32, mes As Int32)
        Dim fecF As Long = 0
        fecF = año * 100 + mes
        Dim consulta As String = ""
        If txtCod.Text <> "" Then
            consulta = "delete from adcacfdep where año*100+Mes > " & fecF & " and codigo='" & cod & "' and Acumulados=0"
        Else
            consulta = "delete from adcacfdep where año*100+Mes > " & fecF & " and Acumulados=0"
        End If
        Dim com As New SqlCommand(consulta, conectarBDD)
        Try
            conectarBDD.Open()
            com.ExecuteNonQuery()
            conectarBDD.Close()
        Catch ex As Exception
            MsgBox("Error al Eliminar la Depreciación")
        End Try
    End Sub
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Dispose()
    End Sub

    'Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
    '    If ProgressBar1.Value < 1000 Then
    '        ProgressBar1.Value = ProgressBar1.Value + 200
    '    ElseIf ProgressBar1.Value = 10000 Then
    '        Timer1.Enabled = False
    '    End If
    'End Sub

    Private Sub Depreciacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim coneccion As New DaxLib.DaxLibBases
        coneccion.TipoBase = "10"
        Try
            conectarBDD.ConnectionString = coneccion.StrAdcom
            strConxAdcom = coneccion.StrAdcom
        Catch
            MsgBox("No se puede conectar al servidor virtual del ADCOM")
            Me.Close()
        End Try
        'FechasDep()
        cmbMesFinaliza.SelectedIndex = 11
        cmbMesInicial.SelectedIndex = 0
        txtAñoInicia.Text = DateTime.Now.Year.ToString()
        txtAñoFinaliza.Text = DateTime.Now.Year.ToString()
        Me.UseWaitCursor = False
    End Sub
    Private Sub btnActivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActivo.Click
        If HayActivos("A") = False Then MsgBox("No existen Activos", MsgBoxStyle.Information)
        Dim busk As New Buscar.frmBuscar
        Dim cod As String = ""
        cod = busk.Buscar(strConxAdcom, "select codigo,nombre from adcacf where codigo <> ''", "codigo", "nombre", "Consulta", "Consulta de Activos Fijos:")
        If (cod <> "") Then
            txtCod.Text = cod
            ConsDescrip(cod)
        End If
    End Sub
    Public Function HayActivos(ByVal op As String) As Boolean
        Dim res As Integer = 0
        Dim ssql As String = ""
        Dim condax As New DaxLib.DaxLibBases
        HayActivos = True
        ssql = "Select * from AdcAcf "
        If op = "P" Then ssql = ssql & " where EsActivoCompuesto = 1"
        Dim com As New SqlCommand(ssql, conectarBDD)
        Dim dat As SqlDataReader
        If conectarBDD.State = ConnectionState.Open Then conectarBDD.Close()
        conectarBDD.Open()
        dat = com.ExecuteReader()
        HayActivos = dat.Read()
        conectarBDD.Close()
    End Function
    Private Sub ConsDescrip(ByVal codAcf As String)
        Dim ssql As String = "Select nombre from adcacf where codigo='" & codAcf & "'"
        Dim cmd As New SqlCommand(ssql, conectarBDD)
        Dim dat As SqlDataReader = Nothing
        If conectarBDD.State = ConnectionState.Open Then conectarBDD.Close()
        conectarBDD.Open()
        dat = cmd.ExecuteReader
        If dat.Read Then
            If Not IsDBNull(dat(0)) Then txtDesc.Text = dat(0).ToString()
        End If
        conectarBDD.Close()
    End Sub

End Class