Imports System.Windows.Forms
Imports DattCom

<DebuggerDisplay("{GetDebuggerDisplay(),nq}")>
Public Class ResetLic
    Dim Label1 As String
    Dim StrConxAdcom As String
    Dim StrConxDaxsys As String
    Dim Pathappl As String
    Dim sistema As String
    Dim CodEmp As Int32

    Private Sub CancelaButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelaButton.Click
        Me.Close()
    End Sub
    Public Sub New(stradc As String, srtsys As String, patappl As String, sist As String, codemp As Int32)
        InitializeComponent()
        StrConxDaxsys = srtsys
        sistema = sist
        Pathappl = patappl
        StrConxAdcom = stradc
    End Sub
    Private Sub ResLic_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ConxAdcomdx As New SqlClient.SqlConnection(StrConxAdcom)
        Dim Rs As SqlClient.SqlDataReader
        Dim Licencias As Integer
        Dim Aux As String
        Dim servidor As String
        Dim actual As Long
        Dim FechaAct As String
        ' cambiar On Error Resume Next
        FechaAct = "00:00"
        Licencias = CInt(LicDefAct.ChequeoLicencias.ChequearLicencias(datosEmpresa.Major, datosEmpresa.pathServer, datosEmpresa.pathAppl, datosEmpresa.sistema, datosEmpresa.auto, "23031957"))
        If Licencias > 400 Then Licencias = Licencias - 400
        If Licencias > 300 Then Licencias = Licencias - 300
        If Licencias > 200 Then Licencias = Licencias - 200
        If Licencias > 100 Then Licencias = Licencias - 100
        ConxAdcomdx.Open()
        Dim comm As New SqlClient.SqlCommand("Select Cie_TipAct,Cie_FecAct from adccie ", ConxAdcomdx)
        Rs = comm.ExecuteReader

        If Rs.Read Then
            actual = CLng(IIf(IsDBNull(Rs!cie_tipact), 0, Rs!cie_tipact))
            FechaAct = CStr(IIf(IsDBNull(Rs!cie_fecact), "00:00", Rs!cie_fecact))
        End If
        Aux = ""
        servidor = ""
        If CDate(FechaAct) < CDate("31/12/1960") Then FechaAct = ""
        If sistema = "DAX" Then
            Aux = "SES ERP"
            servidor = " Servidor y "
        ElseIf sistema = "ERP" Then
            Aux = "SES ERP"
            servidor = " Servidor y "
        ElseIf sistema = "ADC" Then
            Aux = "SES"
            servidor = " Servidor y "
        ElseIf sistema = "ADS" Then
            Aux = "AdcomDx Express"
        ElseIf sistema = "DXA" Then
            Aux = "SES 16 "
            servidor = " Servidor y "
        End If
        FechaAct = " Ultima actualización " & vbCr & " Nro: " & Format(actual, "0000") & vbCr & " fecha: " & FechaAct

        Label2.Text = vbCr & Aux & vbCr & vbCr & "Licencia autorizada "
        Label2.Text = Label2.Text & servidor & Licencias & " estaciones " & vbCr
        Label2.Text = Label2.Text & vbCr & FechaAct & vbCr & vbCr
        Label2.Text = Label2.Text & "www.daxsof.com.ec "

        Label1 = "Esta opción bloqueará el acceso al sistema." & vbCr & vbCr
        Label1 = Label1 & "Debe reingresar y registrar una licencia de activación," & vbCr
        Label1 = Label1 & "siga las instrucciones que aparecen al reiniciar AdcomDx" & vbCr
        Label1 = Label1 & "o comuníquese con el soporte al cliente de Daxsof" & vbCr
        Label1 = Label1 & "         Tlf: 09-99906974 09-84576776  02-26019988 " & vbCr
        Label1 = Label1 & "mail: daxsof@daxsof.com.ec  daxsoporte@daxsof.com.ec" & vbCr & vbCr
        Label1 = Label1 & "                       www.daxsof.com.ec"

    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click

        ' cambiar On Error Resume Next

        'ConxDaxSys.Open()
        If MessageBox.Show(Label1 & vbCr & vbCr & "Confirma REINICIAR la licencia del sistema ? ", "INGRESARR AL SISTEMA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            reseteeLicencia()
        End If
    End Sub
    Private Sub reseteeLicencia()
        Dim ConxDaxSys As New SqlClient.SqlConnection(StrConxDaxsys)
        Dim Rs As SqlClient.SqlCommand
        ConxDaxSys.Open()
        Rs = New SqlClient.SqlCommand("delete sys_accesos where idusuario = 'Ctrl' and (idempresa = 0 or idempresa = " + CodEmp.ToString() + ") ", ConxDaxSys)
        Rs.ExecuteNonQuery()
        ConxDaxSys.Close()
    End Sub

    Private Function GetDebuggerDisplay() As String
        Return ToString()
    End Function
End Class