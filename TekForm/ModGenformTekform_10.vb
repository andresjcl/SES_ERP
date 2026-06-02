Option Strict Off
Option Explicit On
Module ModGenform
	
	Public NroCopias As Short
	Public APapel As Short
	Public LPapel As Integer
	Public MaqDin As Byte
	Public DeSys As New VB6.FixedLengthString(1)
	Public CEsp(3) As Integer
	Public Acordeon As Single
	Public Tipo As String
	Public TextVal() As String
	Public NombreConsulta As String
	Public SiImprimeRegistros As Boolean
	Public BaseConsulta As Short
	Public NombreArchivo As String
	Public DescripcionArchivo As String
	Public EsMultihoja As Short
	Public PorGrabar As Boolean
	Public Pasar As String
	Public PathServidor As String ', PathPdv As String, PathDir As String
	
	'Public PathAdc As String, Pathsys As String, PathArt As String
	
	'Public ConxSysEmp As New ADODB.Connection
	Public ConxAdcom As New ADODB.Connection
	Public QueSistema As String
	Public GenDatox As DaxLib.GenDatos
	Public TotPintados As Short
	Public NumeroDeDigitos As Short
	Public NumeroDecimales As Short
	Public Emp As AdcDax.Empresa
	Public CONEMP As New AdcDax.DaxSofSys
	Public ControlUsuario As DaxUsr.CtrlUsuario
	Public CONUSR As New DaxUsr.DaxsofUsr
	Public StrConxAdcom As String
	
	Public Sub Main()
		Dim prog3 As New AcercaDe
		Dim prog2 As New DisForma
		prog3.Show()
		Dim prog As New DaxLib.DaxLibBases
		CONEMP = New AdcDax.DaxSofSys
		Emp = CONEMP.EmpresaAct
		CONUSR = New DaxUsr.DaxsofUsr
		ControlUsuario = CONUSR.UsuarioAct
		QueSistema = "A"
		If Emp.PatServidor = "" Then End
		If Emp.NombreBaseAdcom = "" Then End
		If Emp.Sistema = "" Then End
		StrConxAdcom = prog.StrAdcom 'ConexionBaseDeDatos.ArmStr(Emp.NombreBaseAdcom, Emp.servidor, "SQL", Emp.ClaveBD, Emp.UsuarioBd)
		PathServidor = Emp.PatServidor
		ConxAdcom.ConnectionString = StrConxAdcom
		ConxAdcom.Open()
		prog2 = DisForma
		System.Windows.Forms.Application.Run(DisForma)
		prog3.Close()
		'UPGRADE_NOTE: Object prog3 may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		prog3 = Nothing
	End Sub
End Module