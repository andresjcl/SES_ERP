Option Strict Off
Option Explicit On
<System.Runtime.InteropServices.ProgId("SriDax10_NET.SriDax10")> Public Class SriDax10
	Public Sub Inicio(ByRef string1 As String, ByRef string2 As String)
		Dim DocSinRetenciones As Object
		Dim frmAdcSri As Object
		Dim SRITABA As Object
		Dim CONUSR As Object
		'UPGRADE_ISSUE: SRIRETENDx objeto no se actualizó. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
		Dim prog As New SRIRETENDx
		'UPGRADE_ISSUE: SRITABA objeto no se actualizó. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
		Dim PROG2 As New SRITABA
		Dim Campos() As String
		'cambiar on error Resume Next
		CONEMP = AdcDaxDaxSofSys_definst
		Emp = CONEMP.EmpresaAct
		CONUSR = New DaxUsr.DaxsofUsr
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CONUSR.UsuarioAct. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		ControlUsuario = CONUSR.UsuarioAct
		Sistema.Value = Emp.Sistema
		Autorizacion.Value = string1
		If StrConxSysemp = "" Then
			StrConxSri = ConexionBaseDeDatos.ArmStr((Emp.NombreBaseIvaret), Emp.servidor, "SQL", Emp.ClaveBD, Emp.UsuarioBd)
			StrConxSysemp = ConexionBaseDeDatos.ArmStr("DAXSYS", Emp.servidor, "SQL", Emp.ClaveBD, Emp.UsuarioBd)
			StrConxAdcom = ConexionBaseDeDatos.ArmStr((Emp.NombreBaseAdcom), Emp.servidor, "SQL", Emp.ClaveBD, Emp.UsuarioBd)
			StrConxAlex = ConexionBaseDeDatos.ArmStr((Emp.NombreBaseAlex), Emp.servidor, "SQL", Emp.ClaveBD, Emp.UsuarioBd)
			
			ConxSri.ConnectionString = StrConxSri
			ConxSysemp.ConnectionString = StrConxSysemp
			ConxAdcom.ConnectionString = StrConxAdcom
			ConxAlex.ConnectionString = StrConxAlex
			
			ConxSri.Open()
			ConxAlex.Open()
			ConxSysemp.Open()
			ConxAdcom.Open()
			ConxSyscod = ConxSysemp
			PathServidor = Emp.PatServidor
		End If
		
		If StrConxSysemp > "" Then
			If Emp.Sri = False Then MsgBox("No tiene acceso a esta opción, su configuración no lo permite", MsgBoxStyle.Critical) : Exit Sub
			PathAppl = Emp.PatAppl
			Sistema.Value = Emp.Sistema
			ArreglaPeriodo(Year(Today), Month(Today))
			If string2 = "T" Then
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto SRITABA.Show. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				SRITABA.Show(VB6.FormShowConstants.Modal)
			ElseIf string2 = "L" Then 
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto frmAdcSri.Show. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				frmAdcSri.Show(VB6.FormShowConstants.Modal)
			ElseIf string2 = "S" Then 
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto DocSinRetenciones.Show. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DocSinRetenciones.Show(VB6.FormShowConstants.Modal)
			ElseIf string2 = "A" Then 
				AdcAutorizacionesSri.ShowDialog()
			ElseIf string2 = "C" Or string2 = "V" Then 
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto prog.CompraVenta. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				prog.CompraVenta = string2
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto prog.Show. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				prog.Show(VB6.FormShowConstants.Modal)
			ElseIf string2 = "1" Then 
				SRIP01.ShowDialog()
			ElseIf string2 = "2" Then 
				SRIP02.ShowDialog()
			Else
				Campos = Split(string2, ";")
				ReDim Preserve Campos(15)
				With prog
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto prog.idClaveDocapl. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.idClaveDocapl = Val(Campos(1))
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto prog.CompraVenta. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.CompraVenta = Mid(Campos(0), 1, 1)
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto prog.ClienteApl. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.ClienteApl = Campos(2)
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto prog.fecha. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.fecha = Campos(5)
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto prog.DocumentoAp. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.DocumentoAp = Campos(9)
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto prog.NumeroAp. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.NumeroAp = Val(Campos(10))
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto prog.EntraIni. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.EntraIni = True
				End With
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto prog.Show. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				prog.Show(VB6.FormShowConstants.Modal)
			End If
		End If
	End Sub
End Class