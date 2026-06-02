using System;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;

namespace directMnt
{
	public class BusDirectorio
	{

		public string BusDirect(ref string codigo, ref string CEDULA, ref string Nombre, ref string NombreAlias, [Optional, DefaultParameterValue("")] ref string Tipo, [Optional, DefaultParameterValue("")] ref string ConNuevo)
		{
			string ElCodigo = "";
			Module1.Mainn();
			try
			{
				var PROG = new BuscaClien();
				ElCodigo = PROG.IniBuscaCliOPro(ref Tipo, ref Nombre, ref NombreAlias, ref ConNuevo);
				PROG.Dispose();
			}
			catch (Exception ee)
			{
				Interaction.MsgBox("excepción busDirect: " + ee.Message);
			}
			return ElCodigo;
		}
		public string BusDirect(string codigo, string CEDULA, ref string Nombre, string NombreAlias, string Tipo = "", string ConNuevo = "", string neutro = "")
		{
			string ElCodigo = "";
			Module1.Mainn();
			try
			{
				var PROG = new BuscaClien();
				ElCodigo = PROG.IniBuscaCliOPro(ref Tipo, ref Nombre, ref NombreAlias, ref ConNuevo);
				PROG.Dispose();
			}
			catch (Exception ee)
			{
				Interaction.MsgBox("excepción busDirect: " + ee.Message);
			}
			return ElCodigo;
		}
		public string BusDirect(string codigo, string cedula, string nombre, string nomAlias)
		{
			string ElCodigo = "";
			Module1.Mainn();
			try
			{
				var PROG = new BuscaClien();
				string argCliOProv = "";
				string argConNuevo = "";
				ElCodigo = PROG.IniBuscaCliOPro(ref argCliOProv, ref nombre, ref nomAlias, ref argConNuevo);
				PROG.Dispose();
			}
			catch (Exception ee)
			{
				Interaction.MsgBox("excepción busDirect: " + ee.Message);
			}
			return ElCodigo;
		}


		public void ManDir(ref string ConCodigo)
		{
			Module1.Mainn();
			// Try
			// Dim ConxAdcomNet As New SqlClient.SqlConnection(datosEmpresa.strConxAdcom)
			// ConxAdcomNet.Open()
			// Dim rs As SqlClient.SqlDataReader
			// Dim comm As New SqlClient.SqlCommand("select top 1 codigo from identificacion", ConxAdcomNet)
			// rs = comm.ExecuteReader
			// If rs.Read = False Then MsgBox("Esta version del ADCOMDX no admite mantenimiento del DIRECTORIO") : Exit Sub
			// rs.Close()
			// comm.Dispose()
			// ConxAdcomNet.Dispose()
			var PROG = new DEEP01();
			// PROG.Autorizacion = datosEmpresa.auto
			if (ConCodigo == "&&")
			{
				PROG.QUECODIGO = "";
				PROG.IniciaNuevo();
			}
			else
			{
				PROG.QUECODIGO = ConCodigo;
				PROG.Show();
			}
			// PROG.Close()
			// PROG.Dispose()
			// Catch ee As Exception
			// MsgBox("excepción manDir: " & ee.Message)
			// End Try
		}

	}
}