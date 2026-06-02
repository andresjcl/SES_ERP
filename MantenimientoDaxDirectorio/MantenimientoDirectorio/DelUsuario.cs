using System;
using DattCom;
using Microsoft.VisualBasic;

namespace directMnt
{
	static class DelUsuario
	{
		public static string AutorizarIngreso(string NombreOpcion, string CodUsu = "", int codemp = 0)
		{
			string AutorizarIngresoRet = default;
			string auxiliar;
			var ConxDaxSys = new System.Data.SqlClient.SqlConnection(datosEmpresa.strConxSyscod);
			ConxDaxSys.Open();
			System.Data.SqlClient.SqlDataReader RecClv;
			;

#error Cannot convert OnErrorResumeNextStatementSyntax - see comment for details
			/* Cannot convert OnErrorResumeNextStatementSyntax, CONVERSION ERROR: Conversion for OnErrorResumeNextStatement not implemented, please report this issue in 'On Error Resume Next' at character 425


						Input:
								On Error Resume Next

						 */
			if (string.IsNullOrEmpty(CodUsu))
				CodUsu = datosEmpresa.usr;
			if (codemp == 0)
				codemp = datosEmpresa.codEmpresa;

			if (Strings.UCase(CodUsu) == "ADMINISTRADOR" | UCase(datosEmpresa.usr) == "CONTROL")
			{
				AutorizarIngresoRet = "T";
				return AutorizarIngresoRet;
			}
			auxiliar = "SELECT * FROM sys_Accesos WHERE IdUsuario = '" + CodUsu + "'" + " AND IdEmpresa = " + codemp + " AND Idopcion = '" + NombreOpcion + "'";
			AutorizarIngresoRet = "";
			var Comm = new System.Data.SqlClient.SqlCommand(auxiliar, ConxDaxSys);
			RecClv = Comm.ExecuteReader();
			{
				ref var withBlock = ref RecClv;
				if (withBlock.Read() == false)
				{
					withBlock.Close();
					RecClv = null;
					return AutorizarIngresoRet;
				}
				if (!(withBlock["Accesos"] is DBNull))
					AutorizarIngresoRet = withBlock["Accesos"].ToString();
				else
					AutorizarIngresoRet = "";
				withBlock.Close();
			}
			RecClv = null;
			Comm.Dispose();
			return AutorizarIngresoRet;
			// ConxDaxSys.Dispose()
		}

		// Public Sub GuardarUsuSuc(IdUsu As String, codemp As Integer, codSuc As String, Optional Aut As String)
		// Dim cod As String
		// ON ERROR Resume Next
		// Dim ConxDaxSys As New SqlClient.SqlConnection(datosEmpresa.strConxSyscod)
		// ConxDaxSys.Open()
		// Dim RecUser As SqlClient.SqlDataReader
		// cod = "delete FROM sys_Sucursales WHERE IdUsuario='" & IdUsu & "' AND IdEmpresa=" & codemp & " and codsucursal = '" & codSuc & "' "
		// Dim Comm As New SqlClient.SqlCommand(cod, ConxDaxSys)
		// Comm.ExecuteNonQuery()
		// With RecUser
		// !idusuario = Trim(IdUsu)
		// !idempresa = codemp
		// !CODSUCURSAL = Trim(codSuc)
		// If Not IsMissing(Aut) Then !AutorizaSuc = Trim(Aut)
		// .Update()
		// .Close()
		// End With
		// End Sub

		// Public Sub GuardarUsuBod(IdUsu As String, codemp As Integer, codSuc As String, codBod As String, Optional Aut As String)
		// Dim cod As String
		// Dim recuser As New ADODB.Recordset
		// ON ERROR Resume Next
		// cod = "SELECT * FROM sys_Bodegas WHERE IdUsuario='" & IdUsu & "' AND CodBodega='" & codBod & "' AND CodSucursal='" & codSuc & "' AND IdEmpresa=" & codemp
		// recuser.Open(cod, ConxDaxSys, adOpenKeyset, adLockOptimistic)
		// With recuser
		// If .RecordCount = 0 Then .AddNew()
		// !idusuario = Trim(IdUsu)
		// !idempresa = codemp
		// !CODSUCURSAL = Trim(codSuc)
		// !CODbodega = Trim(codBod)
		// If Not IsMissing(Aut) Then !Autorizabod = Trim(Aut)
		// .Update()
		// .Close()
		// End With
		// End Sub

		// Public Sub GuardarUsuDoc(IdUsu As String, codemp As Integer, codDoc As String, Optional Cam As String)
		// Dim cod As String
		// Dim recuser As New ADODB.Recordset
		// ' aqui reemplazo *****************************
		// cod = "SELECT * FROM sys_Documentos WHERE IdUsuario='" & IdUsu & "' AND CodDocumento='" & codDoc & "' AND IdEmpresa=" & codemp
		// recuser.Open(cod, ConxDaxSys, adOpenKeyset, adLockOptimistic)
		// With recuser
		// If .RecordCount = 0 Then .AddNew()
		// !idusuario = Trim(IdUsu)
		// !idempresa = codemp
		// !CodDocumento = Trim(codDoc)
		// If Not IsMissing(Cam) Then !Cambios = Trim(Cam)
		// .Update()
		// .Close()
		// End With
		// End Sub
	}
}