Option Strict Off
Option Explicit On
Module VariablesPublicas
	Public moduloActual As String
	'UPGRADE_ISSUE: No se admite la declaración de un parámetro 'As Any'. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"'
	Private Declare Function GetPrivateProfileString Lib "kernel32"  Alias "GetPrivateProfileStringA"(ByVal lpSectionName As String, ByVal lpKeyName As Any, ByVal lpDefault As String, ByVal lpbuffurnedString As String, ByVal nBuffSize As Integer, ByVal lpFileName As String) As Integer
	
	'UPGRADE_ISSUE: No se admite la declaración de un parámetro 'As Any'. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"'
	'UPGRADE_ISSUE: No se admite la declaración de un parámetro 'As Any'. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"'
	Private Declare Function WritePrivateProfileString Lib "kernel32"  Alias "WritePrivateProfileStringA"(ByVal lpSectionName As String, ByVal lpKeyName As Any, ByVal lpString As Any, ByVal lpFileName As String) As Integer
	
	Public Sistema As New VB6.FixedLengthString(3) ' ERP =  ADCOM ERP ADC = ADCOMDX ADS=ADCOM EXPRESS  ALE = ALEX PTO=PUNTTO PRO = ANTPRO
	Public Autorizacion As New VB6.FixedLengthString(1)
	Public AutorizaAlex As New VB6.FixedLengthString(25)
	Public PathAppl As String
	Public PathServidor As String
	Public auxvec1(10) As Object
	Public NumeroDeDigitos As Short
	Public NumeroDecimales As String
	
	Public CONEMP As New AdcDax.DaxSofSys
	Public Emp As AdcDax.Empresa
	Public CONUSER As New DaxUsr.DaxsofUsr
	Public ControlUsuario As DaxUsr.CtrlUsuario
	
	Public Licencias As Integer
	
	' Todos los Conx.... son conecciones abiertas desde la selección de la empresa
	
	Public ConxSysemp As New ADODB.Connection
	Public ConxSyscod As New ADODB.Connection
	Public ConxAlex As New ADODB.Connection
	Public ConxAdcom As New ADODB.Connection
	Public ConxRolpag As New ADODB.Connection
	Public ConxSri As New ADODB.Connection
	Public ConxDaxPro As New ADODB.Connection
	Public EsNuevo As Short
	
	Public StrConxAdcom As String
	Public StrConxDaxSys As String
	Public StrConxSysemp As String
	Public StrConxAlex As String
	Public StrConxSri As String
	Public StrConxDaxPro As String
	Public StrConxRolpag As String
	Public LibDigDat As New DaxLib.DaxLibDigDato
	Public LibBasDat As New DaxLib.DaxLibBases
	'Public LosTitulos As New ColTitulos
	'EsNuevo=1 cuano es nuevo
	'EsNuevo=2 cuando es modificar
	
	Public Const MODF As String = "Modificado:"
	Public Const BORR As String = "Borrado:"
	Public Const CREA As String = "Creado:"
	Public Const ANUL As String = "Anulado:"
	
	Public Function ProfileGetItem(ByRef sSection As String, ByRef sKeyName As String, ByRef sDefValue As String, ByRef sIniFile As String) As String
		
		'retrieves a value from an ini file
		'corresponding to the section and
		'key name passed.
		
		Dim dwSize As Integer
		Dim nBuffSize As Integer
		Dim buff As String
		
		'Call the API with the parameters passed.
		'nBuffSize is the length of the string
		'in buff, including the terminating null.
		'If a default value was passed, and the
		'section or key name are not in the file,
		'that value is returned. If no default
		'value was passed (""), then dwSize
		'will = 0 if not found.
		'
		'pad a string large enough to hold the data
		buff = Space(2048)
		nBuffSize = Len(buff)
		dwSize = GetPrivateProfileString(sSection, sKeyName, sDefValue, buff, nBuffSize, sIniFile)
		
		If dwSize > 0 Then
			ProfileGetItem = Left(buff, dwSize)
		End If
	End Function
	
	
	Public Sub ProfileSaveItem(ByRef sSection As String, ByRef sKeyName As String, ByRef sValue As String, ByRef sIniFile As String)
		
		'This function saves the passed value to the file,
		'under the section and key name specified.
		'
		'If the ini file does not exist, it is created.
		'If the section does not exist, it is created within the file.
		'If the key name does not exist, it is created under the section.
		'If the key name exists, it's value is replaced.
		
		Call WritePrivateProfileString(sSection, sKeyName, sValue, sIniFile)
		
	End Sub
	
	
	Public Sub ProfileDeleteItem(ByRef sSection As String, ByRef sKeyName As String, ByRef sIniFile As String)
		
		'this call will remove the keyname and its
		'corresponding value from the section sepcified
		'in sSection. This is accomplished by passing
		'vbNullString as the sValue parameter. For example,
		'assuming that an ini file had:
		' [Colours]
		'  Colour1=Red
		'  Colour2=Blue
		'  Colour3=Green
		'
		'and this sub was called passing "Colour2"
		'as sKeyName, the resulting ini file
		'would contain:
		' [Colours]
		'  Colour1=Red
		'  Colour3=Green
		
		Call WritePrivateProfileString(sSection, sKeyName, vbNullString, sIniFile)
		
	End Sub
	
	Public Sub ProfileDeleteSection(ByRef sSection As String, ByRef sIniFile As String)
		
		'this call will remove the entire section
		'corresponding to sSection in the file.
		'This is accomplished by passing
		'vbNullString as both the sKeyName and
		'sValue parameters. For example, assuming
		'that an ini file had:
		' [Colours]
		'  Colour1=Red
		'  Colour2=Blue
		'  Colour3=Green
		'
		'and this sub was called passing "Colours"
		'as sSection, the entire Colours
		'section and all keys and values in
		'the section would be deleted.
		
		Call WritePrivateProfileString(sSection, vbNullString, vbNullString, sIniFile)
		
	End Sub
	
	Public Function roundd(ByVal numero As Double, ByVal par As Short) As Double
		roundd = System.Math.Round(numero + 0.00000001, par)
	End Function
End Module