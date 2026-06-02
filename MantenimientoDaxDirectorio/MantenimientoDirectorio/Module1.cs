using System;
using DattCom;
using Microsoft.VisualBasic;

namespace directMnt
{
	static class Module1
	{
		public static string Orden = "";

		public static void Mainn()
		{
			try
			{
				// If datosEmpresa.strConxAdcom = "" Then varbleComun.cargar.iniciar("", "")
				if (Len(Strings.Trim(datosEmpresa.strConxAdcom)) == 0)
					return;
			}
			catch (Exception ee)
			{
				Interaction.MsgBox("excepción mainn: " + ee.Message);
			}
			Emp.CargarValores();
		}

		public static bool ValidaId(ref string NumeroId, ref string TipoId, string Persona)
		{
			bool ValidaIdRet = default;
			short Largo;
			;
#error Cannot convert OnErrorResumeNextStatementSyntax - see comment for details
			/* Cannot convert OnErrorResumeNextStatementSyntax, CONVERSION ERROR: Conversion for OnErrorResumeNextStatement not implemented, please report this issue in 'On Error Resume Next' at character 673


						Input:
								On Error Resume Next

						 */
			ValidaIdRet = false;
			if (TipoId == "P")
			{
				ValidaIdRet = true;
				return ValidaIdRet;
			}
			else if (TipoId == "F")
			{
				if (NumeroId == "9999999999999")
					ValidaIdRet = true;
				return ValidaIdRet;
			}
			Largo = (short)Strings.Len(NumeroId);
			if (!Information.IsNumeric(NumeroId))
				return ValidaIdRet;
			if (TipoId == "R")
			{
				if (Largo != 13 | Strings.Mid(NumeroId, 11) != "001")
					return ValidaIdRet;
			}
			else if (TipoId == "C")
			{
				if (Largo != 10)
					return ValidaIdRet;
			}
			Largo = (short)Math.Round(Conversion.Val(Strings.Mid(NumeroId, 3, 1)));
			ValidaIdRet = true;
			if (TipoId == "C")
			{
			}
			// ValidaId = Validador.validarCedula(NumeroId)
			else if (Largo >= 0 & Largo <= 5)
			{
			}
			// ValidaId = Validador.validarRUCNaturales(NumeroId)
			else if (Largo == 6)
			{
			}
			// ValidaId = Validador.validarRUCPublicas(NumeroId)
			else if (Largo == 9)
			{
				// ValidaId = Validador.validarRUCPrivadas(NumeroId)
			}

			return ValidaIdRet;
			// UPGRADE_NOTE: El objeto Validador no se puede destruir hasta que no se realice la recolección de los elementos no utilizados. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			// Validador = Nothing
		}

		public static bool ClienteMovimiento(ref string codigo)
		{
			bool ClienteMovimientoRet = default;
			string cod;
			var ConxAdcom = new System.Data.SqlClient.SqlConnection(datosEmpresa.strConxAdcom);
			System.Data.SqlClient.SqlDataReader rs;
			ClienteMovimientoRet = false;
			try
			{
				ConxAdcom.Open();
				if ((int)ConxAdcom.State == 1)
				{
					cod = " SELECT Doc_codper " + " From AdcDoc " + " Where Doc_codper = '" + codigo + "' ";
					var comm = new System.Data.SqlClient.SqlCommand(cod, ConxAdcom);
					rs = comm.ExecuteReader();
					if (rs.Read())
						ClienteMovimientoRet = true;
					rs.Close();
					comm.Dispose();
					cod = " SELECT idempleado " + " From rolliq " + " Where idempleado = '" + codigo + "' ";
					comm = new System.Data.SqlClient.SqlCommand(cod, ConxAdcom);
					rs = comm.ExecuteReader();
					if (rs.Read())
						ClienteMovimientoRet = true;
					rs.Close();
					comm.Dispose();
				}
				ConxAdcom.Close();
			}
			catch (Exception ee)
			{
				Interaction.MsgBox("excepción Mandir_Clmov : " + ee.Message);
			}

			return ClienteMovimientoRet;
		}
	}
}