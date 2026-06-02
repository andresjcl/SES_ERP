Option Strict Off
Option Explicit On
Module ConfiguracionRegional
	'para cambiara la configuración regional para la utilizacion en el programa
	
	
	Declare Function SetLocaleInfo Lib "kernel32"  Alias "SetLocaleInfoA"(ByVal Locale As Integer, ByVal LCType As Integer, ByVal lpLCData As String) As Integer
	Declare Function GetLocaleInfo Lib "kernel32"  Alias "GetLocaleInfoA"(ByVal Locale As Integer, ByVal LCType As Integer, ByVal lpLCData As String, ByVal cchData As Integer) As Integer
	
	Structure NUMBERFMT
		Dim NumDigits As Integer ' número de dígitos decimales
		Dim LeadingZero As Integer ' si hay ceros iniciales en los campos decimales
		Dim Grouping As Integer ' tamaño del grupo a la izquierda del decimal
		Dim lpDecimalSep As String ' puntero a la cadena del separador de decimales
		Dim lpThousandSep As String ' puntero a la cadena del separador de miles
		Dim NegativeOrder As Integer ' orden de números negativos
	End Structure
	
	'UPGRADE_WARNING: La estructura NUMBERFMT puede requerir que se pasen atributos de cálculo de referencia como argumento en esta instrucción Declare. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
	Declare Function GetNumberFormat Lib "kernel32"  Alias "GetNumberFormatA"(ByVal Locale As Integer, ByVal dwFlags As Integer, ByVal lpValue As String, ByRef lpFormat As NUMBERFMT, ByVal lpNumberStr As String, ByVal cchNumber As Integer) As Integer
	
	Public Const LOCAL_DEFAULT As Integer = &H2C0A
	Public Const LOCALE_SDECIMAL As Integer = &HE
	Public Const LOCALE_STHOUSAND As Integer = &HF
	Public Const LOCALE_IDIGITS As Integer = &H11
	Public Const LOCALE_STIMEFORMAT As Integer = &H1003
	Public Const LOCALE_SSHORTDATE As Integer = &H1F
	Public Const LOCALE_SLONGDATE As Integer = &H20
	Public Const LOCALE_SCURRENCY As Integer = &H14
	Public Const LOCALE_SMONDECIMALSEP As Integer = &H16
	Public Const LOCALE_SMONTHOUSANDSEP As Integer = &H17
	
	Public Const FMT_FECHA_CORTA As String = "dd/MM/yyyy"
	Public Const FMT_FECHA_LARGA As String = "dddd, d' de 'MMMM' de 'yyyy"
	Public Const FMT_HORA As String = "HH:mm:ss"
	Public Const SIMB_MONEDA As String = "$"
	Public Const SEP_DEC As String = "."
	Public Const SEP_MILES As String = ","
	
	Public Function EstablecerConfguracionRegional(Optional ByRef strError As String = "") As Boolean
		Dim lngResu As Integer
		Dim buffer As New VB6.FixedLengthString(255)
		
		'cambiar on error GoTo Errores
		
		lngResu = SetLocaleInfo(LOCAL_DEFAULT, LOCALE_SSHORTDATE, FMT_FECHA_CORTA)
		If lngResu = 0 Then strError = "No se pudo registrar formato de  fecha corta."
		
		lngResu = SetLocaleInfo(LOCAL_DEFAULT, LOCALE_SLONGDATE, FMT_FECHA_LARGA)
		If lngResu = 0 Then strError = "No se pudo registrar formato de  fecha larga."
		
		lngResu = SetLocaleInfo(LOCAL_DEFAULT, LOCALE_SDECIMAL, SEP_DEC)
		If lngResu = 0 Then strError = "No se pudo registrar formato de  separador de decimales."
		
		lngResu = SetLocaleInfo(LOCAL_DEFAULT, LOCALE_STHOUSAND, SEP_MILES)
		If lngResu = 0 Then strError = "No se pudo registrar formato de  separador de miles."
		
		lngResu = SetLocaleInfo(LOCAL_DEFAULT, LOCALE_STIMEFORMAT, FMT_HORA)
		If lngResu = 0 Then strError = "No se pudo registrar formato de  formato de hora."
		
		lngResu = SetLocaleInfo(LOCAL_DEFAULT, LOCALE_SMONDECIMALSEP, SEP_DEC)
		If lngResu = 0 Then strError = "No se pudo registrar formato de  separador de decimales de moneda."
		
		lngResu = SetLocaleInfo(LOCAL_DEFAULT, LOCALE_SMONTHOUSANDSEP, SEP_MILES)
		If lngResu = 0 Then strError = "No se pudo registrar formato de  separador de miles de moneda."
		
		lngResu = SetLocaleInfo(LOCAL_DEFAULT, LOCALE_SCURRENCY, SIMB_MONEDA)
		If lngResu = 0 Then strError = "No se pudo registrar formato de  símbolo de moneda."
		
		'    lngResu = GetLocaleInfo(LOCAL_DEFAULT, LOCALE_SDECIMAL, buffer, Len(buffer))
		'    If left(buffer, 1) = SEP_DEC Then
		'    lngResu = GetLocaleInfo(LOCAL_DEFAULT, LOCALE_SMONDECIMALSEP, buffer, Len(buffer))
		'    If left(buffer, 1) = SEP_DEC Then
		'    lngResu = GetLocaleInfo(LOCAL_DEFAULT, LOCALE_STHOUSAND, buffer, Len(buffer))
		'    If left(buffer, 1) = SEP_MILES Then
		'    lngResu = GetLocaleInfo(LOCAL_DEFAULT, LOCALE_SMONTHOUSANDSEP, buffer, Len(buffer))
		'    If left(buffer, 1) = SEP_MILES Then
		'    CambiarCR = (strError = vbNullString)
		'    End If
		'    End If
		'    End If
		'    End If
		
		Exit Function
Errores: 
		EstablecerConfguracionRegional = False
	End Function
End Module