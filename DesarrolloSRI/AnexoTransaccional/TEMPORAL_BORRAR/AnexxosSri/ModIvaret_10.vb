Option Strict Off
Option Explicit On
Module ModIvaret
	
	Public CONUSR As New DaxUsr.DaxsofUsr
	Public ControlUsuario As DaxUsr.CtrlUsuario
	Public Emp As AdcDax.Empresa
	Public CONEMP As New AdcDax.DaxSofSys
	
	Public ConxSysemp As New ADODB.Connection
	Public ConxSyscod As New ADODB.Connection
	Public ConxAlex As New ADODB.Connection
	Public ConxAdcom As New ADODB.Connection
	Public ConxSri As New ADODB.Connection
	
	Public StrConxsysemp As String
	Public StrConxAlex As String
	Public StrConxAdcom As String
	Public StrConxSri As String
	
	Public Pathappl As String
	Public Sistema As String
	'UPGRADE_WARNING: La aplicación terminará cuando Sub Main() finalice. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="E08DDC71-66BA-424F-A612-80AF11498FF8"'
	Public Sub Main()
		Dim prog As New MdTransacciones
		'EstablecerConfguracionRegional
		'cambiar on error Resume Next
		CONEMP = New AdcDax.DaxSofSys
		Emp = CONEMP.EmpresaAct
		CONUSR = New DaxUsr.DaxsofUsr
		ControlUsuario = CONUSR.UsuarioAct
		If Emp.SnAnexoTransaccional = False Then MsgBox("No tiene acceso a esta opción, su configuración no lo permite", MsgBoxStyle.Critical) : Exit Sub
		Pathappl = Emp.PatAppl
		Sistema = Emp.Sistema
		
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto ConexionBaseDeDatos.ArmStr(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		StrConxSri = ConexionBaseDeDatos.ArmStr((Emp.NombreBaseIvaret), Emp.servidor, "SQL", Emp.ClaveBD, Emp.UsuarioBd)
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto ConexionBaseDeDatos.ArmStr(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		StrConxsysemp = ConexionBaseDeDatos.ArmStr("DAXSYS", Emp.servidor, "SQL", Emp.ClaveBD, Emp.UsuarioBd)
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto ConexionBaseDeDatos.ArmStr(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		StrConxAdcom = ConexionBaseDeDatos.ArmStr((Emp.NombreBaseAdcom), Emp.servidor, "SQL", Emp.ClaveBD, Emp.UsuarioBd)
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto ConexionBaseDeDatos.ArmStr(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		StrConxAlex = ConexionBaseDeDatos.ArmStr((Emp.NombreBaseAlex), Emp.servidor, "SQL", Emp.ClaveBD, Emp.UsuarioBd)
		
		ConxSri.ConnectionString = StrConxSri
		ConxSysemp.ConnectionString = StrConxsysemp
		ConxAdcom.ConnectionString = StrConxAdcom
		ConxAlex.ConnectionString = StrConxAlex
		
		ConxSri.Open()
		ConxAlex.Open()
		ConxSysemp.Open()
		ConxAdcom.Open()
		ConxSyscod = ConxSysemp
		
		ArreglaPeriodo(Year(Today), Month(Today))
		prog.Text = "EDICION DE ANEXO TRANSACCIONAL PARA EL SRI"
		prog.Show()
	End Sub
	
	
	Public Sub CargarMallaDatos(ByRef TIPOTRA As Short, ByRef Malla As Object)
		Dim sSQL As String
		Dim rs As New ADODB.Recordset
		Dim i As Integer
		Dim fechass As String
		Dim fechasi As String
		
		With Malla
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.Cols. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			For i = 0 To .Cols - 1
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.ColWidth. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.ColWidth(i) = GetSetting("Ivaret", CStr(TIPOTRA), CStr(i), CStr(-1))
			Next i
		End With
		
		If TIPOTRA = 1 Then
			sSQL = "SELECT * " & "FROM Compras  where Cl_mes = " & PerMes & " and cl_anio = " & PerAnio
		ElseIf TIPOTRA = 2 Then 
			sSQL = "SELECT * " & " FROM Ventas where CL_mes = " & PerMes & " and CL_Anio= " & PerAnio
		ElseIf TIPOTRA = 3 Then 
			sSQL = "SELECT * " & " FROM importacion where month(CL_FechaLiquidacion) = " & PerMes & " and year(CL_FechaLiquidacion)= " & PerAnio
		ElseIf TIPOTRA = 4 Then 
			sSQL = "SELECT * " & " FROM exportacion where mes = " & PerMes & " and anio= " & PerAnio
		ElseIf TIPOTRA = 5 Then 
			sSQL = "SELECT * " & " FROM ANULADOS where mes= " & PerMes & " and anio = " & PerAnio
		End If
		
		With Malla
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.Rows. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.Rows = 0
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.FixedCols. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.FixedCols = 1
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.Rows. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.Rows = 4
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.ColWidth. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.ColWidth(0) = 360
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.FixedRows. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.FixedRows = 2
		End With
		rs = New ADODB.Recordset
		If ConxSri.State = 0 Then ConxSri.Open()
		ConxSri.CursorLocation = ADOR.CursorLocationEnum.adUseClient
		
		If sSQL > "" Then
			rs.Open(sSQL, ConxSri, ADOR.CursorTypeEnum.adOpenForwardOnly, ADOR.LockTypeEnum.adLockOptimistic)
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.DataSource. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If rs.EOF = False Then Malla.DataSource = rs
		End If
		If rs.State = 1 Then rs.Close()
		'ArreglaMalla Malla, TIPOTRA
		
	End Sub
	
	Public Sub GrabarMallaDatos(ByRef TIPOTRA As Short, ByRef Malla As Object)
		Dim rs As New ADODB.Recordset
		Dim sSQL As String
		Dim i As Integer
		Dim menos As Short
		menos = 1
		On Error Resume Next
		'If ConSumatoria = 0 Then menos = 1 Else menos = 3
		'For i = Malla.FixedRows To Malla.Rows - 1
		'GrabarLinea Malla, TIPOTRA, i
		'Next i
		''cambiar on error Resume Next
		'fechass = FechaFinMes(CLng(PerAnio), PerMes)
		'fechasi = "01/" & PerMes & "/" & PerAnio
		
		If TIPOTRA = 1 Then
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.Rows. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.FixedRows. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			For i = Malla.FixedRows To Malla.Rows - menos
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If Month(Malla.TextMatrix(i, 11)) <> PerMes Or Year(Malla.TextMatrix(i, 11)) <> PerAnio Then
					If MsgBox("Existen registros con fecha de comprobante diferente al período escojido " & vbCr & "Confirma efectuar la grabación ? ", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
					Exit For
				End If
			Next 
			sSQL = "DELETE " & "FROM Compras  where Cl_Mes = " & PerMes & " and Cl_Anio = " & PerAnio
		ElseIf TIPOTRA = 2 Then 
			sSQL = "DELETE " & " FROM Ventas where cl_mes= " & PerMes & " and CL_anio= " & PerAnio
		ElseIf TIPOTRA = 3 Then 
			sSQL = "DELETE " & " FROM importacion where month(CL_FechaLiquidacion) = " & PerMes & " and year(CL_FechaLiquidacion)= " & PerAnio
		ElseIf TIPOTRA = 4 Then 
			sSQL = "DELETE " & " FROM exportacion where mes = " & PerMes & " and anio = " & PerAnio
		ElseIf TIPOTRA = 5 Then 
			sSQL = "DELETE " & " FROM ANULADOS where mes= " & PerMes & " and anio= " & PerAnio
		End If
		'ConxSri.CursorLocation = adUseServer
		If ConxSri.State = 1 Then ConxSri.Close()
		ConxSri.Open()
		ConxSri.Execute(sSQL)
		
		'UltimoDato = Malla.Cols - 1
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.Rows. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If Malla.Rows > 1 Then
			If TIPOTRA = 1 Then
				rs = New ADODB.Recordset
				rs.Open("COMPRAS", ConxSri, ADOR.CursorTypeEnum.adOpenKeyset, ADOR.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdTable)
				With Malla
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.Rows. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.FixedRows. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					For i = .FixedRows To .Rows - menos
						If VerificaDatos(i, Malla) Then
							rs.AddNew()
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_SusTributario").Value = CorrijeNuloN(.TextMatrix(i, 1))
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_TipoIdProveedor").Value = .TextMatrix(i, 2)
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_CodigoProveedor").Value = CorrijeNulo(.TextMatrix(i, 3))
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("Cl_TipoComprobante").Value = Mid(.TextMatrix(i, 4), 1, 2)
							
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_TipoProveedor").Value = Mid(.TextMatrix(i, 5), 1, 2)
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_ParteRelacionada").Value = Mid(.TextMatrix(i, 6), 1, 2)
							
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_FechaRegContable").Value = CorrijeNuloF(.TextMatrix(i, 7))
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_NroSerieEstablec").Value = .TextMatrix(i, 8)
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_NroSeriePtoEmision").Value = .TextMatrix(i, 9)
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_NroSecuencial").Value = CorrijeNuloN(.TextMatrix(i, 10))
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_FechaComprobante").Value = CorrijeNuloF(.TextMatrix(i, 11))
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_NroAutorizacion").Value = CorrijeNulo(.TextMatrix(i, 12))
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_BaseNoGrabaIva").Value = CorrijeNuloN(.TextMatrix(i, 13))
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_BaseImpTarCero").Value = CorrijeNuloN(CorrijeNuloN(.TextMatrix(i, 14)))
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_BaseImpGravadaIva").Value = CorrijeNuloN(.TextMatrix(i, 15))
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_MontoICE").Value = CorrijeNuloN(.TextMatrix(i, 16))
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_MontoIva").Value = Val(.TextMatrix(i, 17))
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_MontoRetIvaBienes").Value = CorrijeNuloN(.TextMatrix(i, 18))
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_MontoRetIvaServicios").Value = CorrijeNuloN(.TextMatrix(i, 19))
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_MontoRetIva100").Value = CorrijeNuloN(.TextMatrix(i, 20))
							
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_pagoLocExt").Value = CorrijeNuloN(.TextMatrix(i, 21))
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_pagoPais").Value = CorrijeNulo(.TextMatrix(i, 22))
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_dobleTributacion").Value = CorrijeNulo(.TextMatrix(i, 23))
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_pagoSujetoRetencion").Value = CorrijeNulo(.TextMatrix(i, 24))
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_formaDePago").Value = CorrijeNulo(.TextMatrix(i, 25))
							
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_CodRetFteImpRenta0").Value = CorrijeNulo(.TextMatrix(i, 26))
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_BaseImponibleIR0").Value = CorrijeNuloN(CorrijeNuloN(.TextMatrix(i, 27)))
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_CodPorcRetIR0").Value = CorrijeNuloN(.TextMatrix(i, 28))
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_MontoRetIR0").Value = CorrijeNuloN(.TextMatrix(i, 29))
							
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_CodRetFteImpRenta1").Value = CorrijeNulo(.TextMatrix(i, 30))
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_BaseImponibleIR1").Value = CorrijeNuloN(.TextMatrix(i, 31))
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_CodPorcRetIR1").Value = CorrijeNuloN(.TextMatrix(i, 32))
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_MontoRetIR1").Value = CorrijeNuloN(.TextMatrix(i, 33))
							
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_NroSerieCpbteRetEstable").Value = .TextMatrix(i, 34)
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_NroSerieCpbteRetEmision").Value = .TextMatrix(i, 35)
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_NroSecuencialCpbteRet").Value = CorrijeNuloN(.TextMatrix(i, 36))
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_NroAutorizaCpbteRete").Value = CorrijeNulo(.TextMatrix(i, 37))
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_FechaEmisionCpbteRete").Value = CorrijeNuloF(.TextMatrix(i, 38))
							
							
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_CodigoTipoModificado").Value = .TextMatrix(i, 39)
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_NroSerieModificadoEstab").Value = Left(.TextMatrix(i, 40), 3)
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_NroSerieModificadoEmision").Value = Left(.TextMatrix(i, 41), 3)
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_NroSecuencialModificado").Value = .TextMatrix(i, 42)
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_NroAutorizaModificado").Value = .TextMatrix(i, 43)
							
							rs.Fields("Cl_Anio").Value = PerAnio
							rs.Fields("Cl_Mes").Value = PerMes
							
							rs.Update()
						End If
					Next i
				End With
			ElseIf TIPOTRA = 2 Then 
				rs = New ADODB.Recordset
				rs.Open("ventas", ConxSri, ADOR.CursorTypeEnum.adOpenKeyset, ADOR.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdTable)
				With Malla
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.Rows. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.FixedRows. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					For i = .FixedRows To .Rows - menos
						If VerificaDatos(i, Malla) Then
							rs.AddNew()
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_TipoId").Value = .TextMatrix(i, 1)
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_CodigoCliente").Value = CorrijeNulo(.TextMatrix(i, 2))
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("Cl_TipoComprobante").Value = Mid(.TextMatrix(i, 3), 1, 2)
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_NroDeComprobantes").Value = CorrijeNuloN(.TextMatrix(i, 4))
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_BaseNoGrabaIva").Value = CorrijeNuloN(.TextMatrix(i, 5))
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_BaseImpTarCero").Value = CorrijeNuloN(.TextMatrix(i, 6))
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_BaseImpGravadaIva").Value = CorrijeNuloN(.TextMatrix(i, 7))
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_MontoIva").Value = CorrijeNuloN(.TextMatrix(i, 8))
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_ValorRetIva").Value = CorrijeNuloN(.TextMatrix(i, 9))
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_ValorRetRenta").Value = CorrijeNuloN(.TextMatrix(i, 10))
							rs.Fields("Cl_Anio").Value = PerAnio
							rs.Fields("Cl_Mes").Value = PerMes
							rs.Update()
						End If
					Next i
				End With
			ElseIf TIPOTRA = 3 Then 
				rs = New ADODB.Recordset
				rs.Open("importacion", ConxSri, ADOR.CursorTypeEnum.adOpenKeyset, ADOR.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdTable)
				With Malla
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.Rows. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.FixedRows. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					For i = .FixedRows To .Rows - menos
						If VerificaDatos(i, Malla) Then
							rs.AddNew()
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("Cl_TipoComprobante").Value = Mid(.TextMatrix(i, 4), 1, 2)
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_ReferendoDistrito").Value = .TextMatrix(i, 5)
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_ReferendoAño").Value = .TextMatrix(i, 6)
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_ReferendoRegimen").Value = .TextMatrix(i, 7)
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_ReferendoCorrelativo").Value = .TextMatrix(i, 8)
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_ReferendoVerificador").Value = .TextMatrix(i, 9)
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_SusTributario").Value = .TextMatrix(i, 1)
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_ImportacionDe").Value = .TextMatrix(i, 2)
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_FechaLiquidacion").Value = .TextMatrix(i, 3)
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_CodigoProveedor").Value = .TextMatrix(i, 10)
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_ValorCIF").Value = .TextMatrix(i, 11)
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_RazonSocialProveedor").Value = .TextMatrix(i, 12)
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_TipoSujetoProveedor").Value = .TextMatrix(i, 13)
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_BaseImpTarifaCero").Value = CorrijeNuloN(.TextMatrix(i, 14))
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_BaseImpGravadaIva").Value = CorrijeNuloN(.TextMatrix(i, 15))
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_CodPorcIVA").Value = CorrijeNuloN(.TextMatrix(i, 16))
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_MontoIva").Value = CorrijeNuloN(.TextMatrix(i, 17))
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_BaseImponibleICE").Value = CorrijeNuloN(.TextMatrix(i, 18))
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_CodPorcICE").Value = CorrijeNuloN(.TextMatrix(i, 19))
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_MontoICE").Value = CorrijeNuloN(.TextMatrix(i, 20))
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_ConcRetFuenteRenta").Value = .TextMatrix(i, 21)
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_BaseImponibleRenta").Value = CorrijeNuloN(.TextMatrix(i, 22))
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_CodigoPorcRenta").Value = .TextMatrix(i, 23)
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_MontoRetencionRenta").Value = CorrijeNuloN(.TextMatrix(i, 24))
							rs.Update()
						End If
					Next i
				End With
			ElseIf TIPOTRA = 4 Then 
				With Malla
					rs = New ADODB.Recordset
					rs.Open(" exportacion", ConxSri, ADOR.CursorTypeEnum.adOpenKeyset, ADOR.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdTable)
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.Rows. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.FixedRows. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					For i = .FixedRows To .Rows - menos
						If VerificaDatos(i, Malla) Then
							rs.AddNew()
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_ExportaciónDe").Value = CorrijeNulo(.TextMatrix(i, 1))
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("Cl_TipoComprobante").Value = CorrijeNulo(.TextMatrix(i, 2))
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_ReferendoDistrito").Value = CorrijeNulo(.TextMatrix(i, 3))
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_ReferendoAño").Value = CorrijeNulo(.TextMatrix(i, 4))
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_ReferendoRegimen").Value = CorrijeNulo(.TextMatrix(i, 5))
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_ReferendoCorrelativo").Value = CorrijeNulo(.TextMatrix(i, 6))
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_ReferendoVerificador").Value = CorrijeNulo(.TextMatrix(i, 7))
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_NroDocTransporte").Value = CorrijeNulo(.TextMatrix(i, 8))
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_FechaTransaccion").Value = CorrijeNuloF(.TextMatrix(i, 9))
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_NroFue").Value = CorrijeNulo(.TextMatrix(i, 10))
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_ValorFOB").Value = CorrijeNuloN(.TextMatrix(i, 11))
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_ValorComprobante").Value = CorrijeNuloN(.TextMatrix(i, 12))
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_NroSerieCpbteEstablec").Value = CorrijeNulo(.TextMatrix(i, 13))
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_NroSerieCpbteEmision").Value = CorrijeNulo(.TextMatrix(i, 14))
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_NroSecuencialCpbte").Value = CorrijeNuloN(.TextMatrix(i, 15))
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_NroAutorizacion").Value = CorrijeNulo(.TextMatrix(i, 16))
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_FechaEmision").Value = CorrijeNuloF(.TextMatrix(i, 17))
							rs.Fields("mes").Value = PerMes
							rs.Fields("Anio").Value = PerAnio
							rs.Update()
						End If
					Next i
				End With
			ElseIf TIPOTRA = 5 Then 
				With Malla
					rs = New ADODB.Recordset
					rs.Open(" anulados", ConxSri, ADOR.CursorTypeEnum.adOpenKeyset, ADOR.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdTable)
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.Rows. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.FixedRows. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					For i = .FixedRows To .Rows - menos
						If VerificaDatos(i, Malla) Then
							rs.AddNew()
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("Cl_TipoComprobante").Value = CorrijeNulo(.TextMatrix(i, 1))
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_NroSerieEstableci").Value = CorrijeNulo(.TextMatrix(i, 2))
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_NroSerieEmision").Value = CorrijeNulo(.TextMatrix(i, 3))
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_NroSecuencialDesde").Value = CorrijeNulo(.TextMatrix(i, 4))
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_NroSecuencialHasta").Value = CorrijeNulo(.TextMatrix(i, 5))
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rs.Fields("CL_NroAutorizacion").Value = CorrijeNulo(.TextMatrix(i, 6))
							rs.Fields("mes").Value = PerMes
							rs.Fields("Anio").Value = PerAnio
							rs.Update()
						End If
					Next i
				End With
			End If
		End If
		If rs.State = 1 Then rs.Close()
		
	End Sub
	
	Private Function VerificaDatos(ByRef Registro As Integer, ByRef Malla As Object) As Boolean
		Dim i As Integer
		VerificaDatos = False
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.Cols. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		For i = 1 To Malla.Cols - 1
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If Malla.TextMatrix(Registro, i) > "" Then VerificaDatos = True
		Next i
	End Function
	
	'Public Sub GrabarLinea(Malla As MSHFlexGrid, TIPOTRA As Integer, Optional ii As Long)
	'Dim rs As New ADODB.Recordset, i As Long, UltimoDato As Long
	'Dim LaClave As Double
	'If ii <> 0 Then i = ii Else i = Malla.Row
	'UltimoDato = Malla.Cols - 1
	'LaClave = CorrijeNuloN(Malla.TextMatrix(i, UltimoDato))
	'With Malla
	'If TIPOTRA = 1 Then
	'    If VerificaDatos(i, Malla) Then
	'        Set rs = New ADODB.Recordset
	'        rs.Open " SELECT * FROM COMPRAS WHERE " & _
	''            "CLAVE = " & LaClave, ConxSri, adOpenKeyset, adLockOptimistic
	'        If rs.EOF Then LaClave = 0
	'        If LaClave = 0 Then rs.AddNew
	'        rs!CL_CodigoProveedor = CorrijeNulo(.TextMatrix(i, 4))
	'        rs!Cl_TipoComprobante = Mid(.TextMatrix(i, 5), 1, 2)
	'        rs!CL_NroSerieEstablec = .TextMatrix(i, 7)
	'        rs!CL_NroSeriePtoEmision = Malla.TextMatrix(i, 8)
	'        rs!CL_NroSecuencial = CorrijeNuloN(Malla.TextMatrix(i, 9))
	'        rs!CL_TipoIdProveedor = .TextMatrix(i, 3)
	'        rs!CL_SusTributario = CorrijeNuloN(.TextMatrix(i, 1))
	'        rs!CL_TransDevIva = CorrijeNulo(.TextMatrix(i, 2))
	'        rs!CL_FechaComprobante = CorrijeNuloF(Malla.TextMatrix(i, 10))
	'        rs!CL_FechaRegContable = CorrijeNuloF(Malla.TextMatrix(i, 6))
	'        rs!CL_NroAutorizacion = CorrijeNuloN(Malla.TextMatrix(i, 11))
	'        rs!CL_FechaCaducidad = CorrijeNuloF(Malla.TextMatrix(i, 12))
	'        rs!CL_BaseImpTarCero = CorrijeNuloN(CorrijeNuloN(Malla.TextMatrix(i, 13)))
	'        rs!CL_BaseImpGravadaIva = CorrijeNuloN(Malla.TextMatrix(i, 14))
	'        rs!CL_CodigoPorcIva = CorrijeNuloN(Malla.TextMatrix(i, 15))
	'        rs!CL_MontoIva = Val(Malla.TextMatrix(i, 16))
	'        rs!CL_BaseImpICE = CorrijeNuloN(Malla.TextMatrix(i, 17))
	'        rs!CL_CodigoPorcICE = CorrijeNuloN(CorrijeNuloN(Malla.TextMatrix(i, 18)))
	'        rs!CL_MontoICE = CorrijeNuloN(Malla.TextMatrix(i, 19))
	'        rs!CL_MontoIvaBienes = CorrijeNuloN(Malla.TextMatrix(i, 20))
	'        rs!CL_CodPorcRetIvaBienes = CorrijeNuloN(Malla.TextMatrix(i, 21))
	'        rs!CL_MontoRetIvaBienes = CorrijeNuloN(Malla.TextMatrix(i, 22))
	'        rs!CL_MontoIvaServ = CorrijeNuloN(Malla.TextMatrix(i, 23))
	'        rs!CL_CodPorRetIvaServicios = CorrijeNuloN(Malla.TextMatrix(i, 24))
	'        rs!CL_MontoRetIvaServicios = CorrijeNuloN(Malla.TextMatrix(i, 25))
	'        rs!CL_CodRetFteImpRenta0 = CorrijeNuloN(Malla.TextMatrix(i, 26))
	'        rs!CL_BaseImponibleIR0 = CorrijeNuloN(CorrijeNuloN(Malla.TextMatrix(i, 27)))
	'        rs!CL_CodPorcRetIR0 = CorrijeNuloN(Malla.TextMatrix(i, 28))
	'        rs!CL_MontoRetIR0 = CorrijeNuloN(Malla.TextMatrix(i, 29))
	'
	'        rs!CL_CodRetFteImpRenta1 = CorrijeNuloN(Malla.TextMatrix(i, 30))
	'        rs!CL_BaseImponibleIR1 = CorrijeNuloN(Malla.TextMatrix(i, 31))
	'        rs!CL_CodPorcRetIR1 = CorrijeNuloN(Malla.TextMatrix(i, 32))
	'        rs!CL_MontoRetIR1 = CorrijeNuloN(Malla.TextMatrix(i, 33))
	'
	'        rs!CL_NroSerieCpbteRetEstable = Left(Malla.TextMatrix(i, 34), 3)
	'        rs!CL_NroSerieCpbteRetEmision = Left(Malla.TextMatrix(i, 35), 3)
	'        rs!CL_NroSecuencialCpbteRet = CorrijeNuloN(Malla.TextMatrix(i, 36))
	'        rs!CL_NroAutorizaCpbteRete = CorrijeNuloN(Malla.TextMatrix(i, 37))
	'        rs!CL_FechaEmisionCpbteRete = CorrijeNuloF(Malla.TextMatrix(i, 38))
	'
	'        rs!CL_CodigoTipoModificado = Malla.TextMatrix(i, 39)
	'        rs!CL_NroSerieModificadoEstab = Left(Malla.TextMatrix(i, 40), 3)
	'        rs!CL_NroSerieModificadoEmision = Left(Malla.TextMatrix(i, 41), 3)
	'        rs!CL_NroSecuencialModificado = Malla.TextMatrix(i, 42)
	'        rs!CL_FechaEmisionModificado = CorrijeNuloF(Malla.TextMatrix(i, 43))
	'        rs!CL_NroAutorizaModificado = Malla.TextMatrix(i, 44)
	'
	'
	'        rs!CL_NroContrato = Malla.TextMatrix(i, 45)
	'        rs!CL_MontoOneroso = Val(Malla.TextMatrix(i, 46))
	'        rs!CL_MontoGratutito = Val(Malla.TextMatrix(i, 47))
	'        rs.Update
	'        If LaClave = 0 Then Malla.TextMatrix(i, UltimoDato) = ProximaClave("Compras")
	'    End If
	'ElseIf TIPOTRA = 2 Then
	'    If VerificaDatos(i, Malla) Then
	'        Set rs = New ADODB.Recordset
	'        rs.Open " SELECT * FROM VENTAS WHERE " & _
	''            "CLAVE = " & LaClave, ConxSri, adOpenKeyset, adLockOptimistic
	'        If rs.EOF Then LaClave = 0
	'        If LaClave = 0 Then rs.AddNew
	'        rs!CL_TipoId = Malla.TextMatrix(i, 1)
	'        rs!CL_CodigoCliente = CorrijeNulo(Malla.TextMatrix(i, 2))
	'        rs!Cl_TipoComprobante = Mid(Malla.TextMatrix(i, 3), 1, 2)
	'        rs!CL_FechaRegContable = CorrijeNuloF(Malla.TextMatrix(i, 4))
	'        rs!CL_NroDeComprobantes = CorrijeNuloN(Malla.TextMatrix(i, 5))
	'        rs!CL_FechaComprobante = CorrijeNuloF(Malla.TextMatrix(i, 6))
	'        rs!CL_BaseImpTarCero = CorrijeNuloN(Malla.TextMatrix(i, 7))
	'        rs!CL_IvaPresuntivo = CorrijeNulo(Malla.TextMatrix(i, 8))
	'        rs!CL_BaseImpGravadaIva = CorrijeNuloN(Malla.TextMatrix(i, 9))
	'        rs!CL_CodigoPorIva = CorrijeNuloN(Malla.TextMatrix(i, 10))
	'        rs!CL_MontoIva = CorrijeNuloN(Malla.TextMatrix(i, 11))
	'        rs!CL_BaseImpICE = CorrijeNuloN(Malla.TextMatrix(i, 12))
	'        rs!CL_CodigoPorcICE = CorrijeNuloN(Malla.TextMatrix(i, 13))
	'        rs!CL_MontoICE = CorrijeNuloN(Malla.TextMatrix(i, 14))
	'        rs!CL_MontoIvaBienes = CorrijeNuloN(Malla.TextMatrix(i, 15))
	'        rs!CL_CodPorcRetIvaBienes = CorrijeNuloN(Malla.TextMatrix(i, 16))
	'        rs!CL_MontoRetIvaBienes = CorrijeNuloN(Malla.TextMatrix(i, 17))
	'        rs!CL_MontoIvaServ = CorrijeNuloN(Malla.TextMatrix(i, 18))
	'        rs!CL_CodPorRetIvaServicios = CorrijeNuloN(Malla.TextMatrix(i, 19))
	'        rs!CL_MontoRetIvaServicios = CorrijeNuloN(Malla.TextMatrix(i, 20))
	'        rs!CL_RetencionPresuntiva = Malla.TextMatrix(i, 21)
	'        rs!CL_CodRetFteImpRenta1 = CorrijeNuloN(Malla.TextMatrix(i, 22))
	'        rs!CL_BaseImponibleIR1 = CorrijeNuloN(Malla.TextMatrix(i, 23))
	'        rs!CL_CodPorcRetIR1 = CorrijeNuloN(Malla.TextMatrix(i, 24))
	'        rs!CL_MontoRetIR1 = CorrijeNuloN(Malla.TextMatrix(i, 25))
	'        rs!CL_CodRetFteImpRenta2 = CorrijeNuloN(Malla.TextMatrix(i, 26))
	'        rs!CL_BaseImponibleIR2 = CorrijeNuloN(Malla.TextMatrix(i, 27))
	'        rs!CL_CodPorcRetIR2 = CorrijeNuloN(Malla.TextMatrix(i, 28))
	'        rs!CL_MontoRetIR2 = CorrijeNuloN(Malla.TextMatrix(i, 29))
	'        rs.Update
	'        If LaClave = 0 Then Malla.TextMatrix(i, UltimoDato) = ProximaClave("Ventas")
	'    End If
	'ElseIf TIPOTRA = 3 Then
	'    If VerificaDatos(i, Malla) Then
	'        Set rs = New ADODB.Recordset
	'        rs.Open " SELECT * FROM Importacion WHERE " & _
	''            "CLAVE = " & LaClave, ConxSri, adOpenKeyset, adLockOptimistic
	'        If rs.EOF Then LaClave = 0
	'        If LaClave = 0 Then rs.AddNew
	'        rs!Cl_TipoComprobante = Mid(Malla.TextMatrix(i, 4), 1, 2)
	'        rs!CL_ReferendoDistrito = Malla.TextMatrix(i, 5)
	'        rs!CL_ReferendoAño = Malla.TextMatrix(i, 6)
	'        rs!CL_ReferendoRegimen = Malla.TextMatrix(i, 7)
	'        rs!CL_ReferendoCorrelativo = Malla.TextMatrix(i, 8)
	'        rs!CL_ReferendoVerificador = Malla.TextMatrix(i, 9)
	'        rs!CL_SusTributario = Malla.TextMatrix(i, 1)
	'        rs!CL_ImportacionDe = Malla.TextMatrix(i, 2)
	'        rs!CL_FechaLiquidacion = Malla.TextMatrix(i, 3)
	'        rs!CL_CodigoProveedor = Malla.TextMatrix(i, 10)
	'        rs!CL_ValorCIF = Malla.TextMatrix(i, 11)
	'        rs!CL_RazonSocialProveedor = Malla.TextMatrix(i, 12)
	'        rs!CL_TipoSujetoProveedor = Malla.TextMatrix(i, 13)
	'        rs!CL_BaseImpTarifaCero = CorrijeNuloN(Malla.TextMatrix(i, 14))
	'        rs!CL_BaseImpGravadaIva = CorrijeNuloN(Malla.TextMatrix(i, 15))
	'        rs!CL_CodPorcIVA = CorrijeNuloN(Malla.TextMatrix(i, 16))
	'        rs!CL_MontoIva = CorrijeNuloN(Malla.TextMatrix(i, 17))
	'        rs!CL_BaseImponibleICE = CorrijeNuloN(Malla.TextMatrix(i, 18))
	'        rs!CL_CodPorcICE = CorrijeNuloN(Malla.TextMatrix(i, 19))
	'        rs!CL_MontoICE = CorrijeNuloN(Malla.TextMatrix(i, 20))
	'        rs!CL_ConcRetFuenteRenta = Malla.TextMatrix(i, 21)
	'        rs!CL_BaseImponibleRenta = CorrijeNuloN(Malla.TextMatrix(i, 22))
	'        rs!CL_CodigoPorcRenta = Malla.TextMatrix(i, 23)
	'        rs!CL_MontoRetencionRenta = CorrijeNuloN(Malla.TextMatrix(i, 24))
	'        If LaClave = 0 Then Malla.TextMatrix(i, UltimoDato) = ProximaClave("importacion")
	'        rs.Update
	'    End If
	'ElseIf TIPOTRA = 5 Then
	'    If VerificaDatos(i, Malla) Then
	'        Set rs = New ADODB.Recordset
	'        rs.Open " anulados", ConxSri, adOpenKeyset, adLockOptimistic, adCmdTable
	'        If rs.EOF Then LaClave = 0
	'        If LaClave = 0 Then rs.AddNew
	'        rs!Cl_TipoComprobante = CorrijeNulo(Malla.TextMatrix(i, 1))
	'        rs!CL_NroSerieEstableci = CorrijeNulo(Malla.TextMatrix(i, 2))
	'        rs!CL_NroSerieEmision = CorrijeNulo(Malla.TextMatrix(i, 3))
	'        rs!CL_NroSecuencialDesde = CorrijeNulo(Malla.TextMatrix(i, 4))
	'        rs!CL_NroSecuencialHasta = CorrijeNulo(Malla.TextMatrix(i, 4))
	'        rs!CL_NroAutorizacion = CorrijeNulo(Malla.TextMatrix(i, 5))
	'        rs!CL_FechaAnulacion = CorrijeNuloF(Malla.TextMatrix(i, 6))
	'        If LaClave = 0 Then Malla.TextMatrix(i, UltimoDato) = ProximaClave("Anulados")
	'        rs.Update
	'    End If
	'End If
	'End With
	'
	'End Sub
	
	'Private Function ProximaClave(tabla As String) As String
	'Dim rs As New ADODB.Recordset
	'ProximaClave = "1"
	'rs.Open "Select @@IDENTITY as ProxClav from " & tabla, ConxSri, adOpenForwardOnly, adLockReadOnly
	'If rs.State = 0 Then Exit Function
	'If rs.EOF Then rs.Close: Exit Function
	'ProximaClave = rs!ProxClav
	'rs.Close
	'End Function
End Module