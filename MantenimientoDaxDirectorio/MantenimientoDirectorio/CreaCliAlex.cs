using System;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using DattCom;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace directMnt
{

	public partial class CreaCliAlex
	{
		// Dim RsAlex As New ADODB.Recordset
		private string ClienteProve, CodigoCli;
		private object EsNuevo;
		private short Salir;
		private string TipCod;
		// Dim Act1 As Boolean
		private string IniciarConCodigo;

		public CreaCliAlex()
		{
			InitializeComponent();
			CBuscador = _CBuscador;
			email = _email;
			btncontinuar = _btncontinuar;
			telefono2 = _telefono2;
			direccion = _direccion;
			ruc = _ruc;
			apellidos = _apellidos;
			nombres = _nombres;
			fprincipal = _fprincipal;
			telefono1 = _telefono1;
			codigo = _codigo;
			NombreImpresion = _NombreImpresion;
			Label7 = _Label7;
			Label10 = _Label10;
			Lcod = _Lcod;
			Label9 = _Label9;
			Label5 = _Label5;
			Label2 = _Label2;
			Label1 = _Label1;
			Label6 = _Label6;
			rr = _rr;
			Label4 = _Label4;
			Label3 = _Label3;
			btncancelar = _btncancelar;
			fprincipal1 = _fprincipal1;
			TipoIdent = _TipoIdent;
			fTipo = _fTipo;
			OpE = _OpE;
			OpP = _OpP;
			Label75 = _Label75;
			_CBuscador.Name = "CBuscador";
			_email.Name = "email";
			_btncontinuar.Name = "btncontinuar";
			_telefono2.Name = "telefono2";
			_direccion.Name = "direccion";
			_ruc.Name = "ruc";
			_apellidos.Name = "apellidos";
			_nombres.Name = "nombres";
			_fprincipal.Name = "fprincipal";
			_telefono1.Name = "telefono1";
			_codigo.Name = "codigo";
			_NombreImpresion.Name = "NombreImpresion";
			_Label7.Name = "Label7";
			_Label10.Name = "Label10";
			_Lcod.Name = "Lcod";
			_Label9.Name = "Label9";
			_Label5.Name = "Label5";
			_Label2.Name = "Label2";
			_Label1.Name = "Label1";
			_Label6.Name = "Label6";
			_rr.Name = "rr";
			_Label4.Name = "Label4";
			_Label3.Name = "Label3";
			_btncancelar.Name = "btncancelar";
			_fprincipal1.Name = "fprincipal1";
			_TipoIdent.Name = "TipoIdent";
			_fTipo.Name = "fTipo";
			_OpE.Name = "OpE";
			_OpP.Name = "OpP";
			_Label75.Name = "Label75";
		}

		private void limpia()
		{
			string telefono3 = "";
			try
			{
				nombres.Text = "";
				apellidos.Text = 0.ToString();
				NombreImpresion.Text = "";
				telefono1.Text = "";
				telefono2.Text = "";
				telefono3 = "";
				codigo.Text = "";
				ruc.Text = "";
				codigo.ReadOnly = false;
				return;
			}
			catch
			{
			}

			// ControlaErrores
		}

		private void apellidos_TextChanged(object sender, EventArgs e)
		{

			if (Emp.OrdenaPorApellidos == false)
			{
				NombreImpresion.Text = Strings.Trim(nombres.Text + " " + apellidos.Text);
			}
			else
			{
				NombreImpresion.Text = Strings.Trim(apellidos.Text + " " + nombres.Text);
			}

		}

		private void btncontinuar_Click(object sender, EventArgs e)
		{
			Grabar();
		}

		private void btncancelar_Click(object sender, EventArgs e)
		{
			try
			{
				Close();
				return;
			}
			catch
			{
			}

			// ControlaErrores
		}
		private void btnsalir_Click()
		{
			Salir = 1;
			Close();
			Dispose();
		}
		public string IniCrearAlex(ref string Tipo, [Optional, DefaultParameterValue("")] ref string CodigoInicia)
		{
			// Try
			ClienteProve = Tipo;
			IniciarConCodigo = CodigoInicia;
			ShowDialog();
			// Catch ee As Exception
			// MsgBox("Excepción iniCrAlex: " & ee.Message)
			// End Try
			return CodigoCli;
		}

		private void CBuscador_Click(object sender, EventArgs e)
		{
			UseWaitCursor = true;
			Cursor = Cursors.WaitCursor;
			string ElNombre = "";
			string ElCodigo = "";
			var Buscod = new Syscod.ManSysnetClass();
			string argTipoReferencia = "Ciudades";
			TipCod = Buscod.BuscarReferencia(ref argTipoReferencia, ref ElCodigo, ref ElNombre);
			Lcod.Text = ElNombre;
			UseWaitCursor = false;
			Cursor = Cursors.Default;
		}

		private void codigo_KeyDown(object sender, KeyEventArgs e)
		{
			short KeyCode = (short)e.KeyCode;
			short Shift = (short)((int)e.KeyData / 0x10000);
			if (KeyCode == (int)Keys.F2)
				codigo.Text = ruc.Text;
		}

		// Private Sub CreaCliAlex_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
		// Dim Seleccion As String = ""
		// If Act1 = False Then

		// RsAlex.CursorType = ADODB.CursorTypeEnum.adOpenKeyset
		// RsAlex.Open("select * from identificacion  " & Seleccion & "  order by codigo ", ConxAdcom, , ADODB.CommandTypeEnum.adCmdText)
		// If RsAlex.State = 0 Then
		// MsgBox("La configuración del sistema no acepta esta opción", MsgBoxStyle.Critical) : Me.Close()
		// End If
		// If IniciarConCodigo > "" Then codigo.Text = IniciarConCodigo : ruc.Text = codigo.Text : nombres.Focus()
		// Act1 = True
		// End If
		// End Sub

		private void CreaCliAlex_FormClosed(object sender, FormClosedEventArgs e)
		{
			Dispose();
		}

		private void CreaCliAlex_Load(object sender, EventArgs e)
		{
			// Dim i As Short
			object Seleccion;
			;
#error Cannot convert OnErrorResumeNextStatementSyntax - see comment for details
			/* Cannot convert OnErrorResumeNextStatementSyntax, CONVERSION ERROR: Conversion for OnErrorResumeNextStatement not implemented, please report this issue in 'On Error Resume Next' at character 4265


						Input:
								'Dim i As Short
								On Error Resume Next

						 */
			Module1.Mainn();
			Seleccion = "";
			switch (Strings.UCase(ClienteProve) ?? "")
			{
				case "C":
					{
						Text = "Cliente";
						Seleccion = "escliente <> 0";
						break;
					}
				case "P":
					{
						Text = "Proveedor";
						Seleccion = "esproveedor<> 0";
						break;
					}
				case "E":
					{
						Text = "Empleado";
						Seleccion = "esempleado<> 0";
						break;
					}
				case "V":
					{
						Text = "Vendedor";
						Seleccion = "esvendedor<> 0";
						break;
					}
				case "F":
					{
						Text = "Institución Financiera";
						Seleccion = "esbanco <> 0";
						break;
					}
			}
			TipoIdent.SelectedIndex = 2;
			Application.DoEvents();
			if (Operators.CompareString(IniciarConCodigo, "", false) > 0)
			{
				codigo.Text = IniciarConCodigo;
				ruc.Text = codigo.Text;
				nombres.Focus();
			}

			// fprincipal1.Caption = CreaCliAlex.Caption
			return;
			HayErrores:
			;

			// ControlaErrores
		}
		private void Grabar()
		{
			// On Error Resume Next
			string cod;

			// Dim ConxAdcom As New ADODB.Connection
			// ConxAdcom.ConnectionString = datosEmpresa.strConxAdcom_6
			// ConxAdcom.Open()

			// Dim RECIDE As New ADODB.Recordset
			// RECIDE = New ADODB.Recordset
			string Tip;
			if (string.IsNullOrEmpty(codigo.Text))
			{
				Interaction.MsgBox("Debe ingresar un código", MsgBoxStyle.Information);
				codigo.Focus();
				return;
			}
			if (datosEmpresa.LongCodDirectorio > 0 & codigo.Text.Length != datosEmpresa.LongCodDirectorio)
			{
				Interaction.MsgBox("El código debe tener la longitud correcta (" + datosEmpresa.LongCodDirectorio.ToString() + ")", MsgBoxStyle.Critical);
				return;
			}

			if (string.IsNullOrEmpty(ruc.Text))
			{
				Interaction.MsgBox("Debe ingesar el Ruc o la cédula");
				ruc.Focus();
				return;
			}
			if (string.IsNullOrEmpty(nombres.Text))
			{
				Interaction.MsgBox("Debe ingresar el nombre ", MsgBoxStyle.Information);
				nombres.Focus();
				return;
			}
			cod = codigo.Text;
			if (ValidaNumeroId() == false)
			{
				Interaction.MsgBox("El numero del documento de identificacion está errado ", MsgBoxStyle.Critical);
				ruc.Focus();
				return;
			}

			string sqlaux = "Select codigo from Identificacion where cedulaidentidadruc='" + ruc.Text + "' and codigo <> '" + codigo.Text + "' ";
			var Conectar = new SqlConnection(datosEmpresa.strConxAdcom);
			SqlDataReader dataAd;
			var comm = new SqlCommand(sqlaux, Conectar);
			Conectar.Open();
			dataAd = comm.ExecuteReader();
			if (dataAd.Read())
			{
				ruc.Text = "";
				Interaction.MsgBox("La cédula o ruc ya existe ", MsgBoxStyle.Critical);
				ruc.Focus();
				dataAd.Close();
				Conectar.Close();
				comm.Dispose();
				Conectar.Dispose();
				return;
			}
			var rsalex = new Identificacion(datosEmpresa.strConxAdcom);
			Identificacion.CadenaSelect = "select * from identificacion where Codigo = '" + codigo.Text + "'  ";
			rsalex = Identificacion.Buscar(" Codigo = '" + codigo.Text + "'  ");

			if (rsalex == null == false)
			{
				if (Operators.CompareString(rsalex.Codigo, "", false) > 0)
				{
					Interaction.MsgBox("El código ya existe , debe ingresar otro código ", MsgBoxStyle.Information);
					codigo.Focus();
					return;
				}
			}
			else
			{
				rsalex = new Identificacion(datosEmpresa.strConxAdcom);
			}

			if (OpP.Checked == true)
			{
				Tip = "N";
			}
			else
			{
				Tip = "J";
			}
			rsalex.TipoPersona = Tip;
			rsalex.Codigo = codigo.Text;
			rsalex.CedulaIdentidadRuc = ruc.Text;
			if (!(nombres.Text is DBNull))
				rsalex.Nombres = nombres.Text;
			if (!(apellidos.Text is DBNull))
				rsalex.Apellidos = apellidos.Text;
			rsalex.NombreImpresion = NombreImpresion.Text;
			rsalex.EsBanco = false;
			rsalex.EsEmpleado = false;
			rsalex.EsVendedor = false;
			rsalex.EsAsociado = false;
			rsalex.EsCliente = false;
			rsalex.EsProveedor = false;
			switch (Strings.UCase(ClienteProve) ?? "")
			{
				case "P":
					{
						rsalex.EsProveedor = true;
						break;
					}
				case "E":
					{
						rsalex.EsEmpleado = true;
						break;
					}
				case "V":
					{
						rsalex.EsVendedor = true;
						break;
					}
				case "F":
					{
						rsalex.EsBanco = true;
						rsalex.EsProveedor = true;
						break;
					}

				default:
					{
						rsalex.EsCliente = true;
						break;
					}
			}

			rsalex.Telefono1 = telefono1.Text;
			rsalex.Telefono2 = telefono2.Text;
			rsalex.Telefono3 = "";
			rsalex.CorreoElectrónico = email.Text;

			if (!(direccion.Text is DBNull))
				rsalex.Domicilio = direccion.Text;
			if (!(TipCod is DBNull))
				rsalex.Ciudad = TipCod;

			string argIdent = TipoIdent.SelectedIndex.ToString();
			rsalex.TipoIdentificacion = TipoIdGeneral(ref argIdent);
			rsalex.HistoriaClinica = ruc.Text;
			rsalex.Actualizar();

			CodigoCli = codigo.Text;
			if (rsalex.EsCliente)
			{
				var datcli = new dbCliente(datosEmpresa.strConxAdcom);
				datcli.CodigoCli = CodigoCli;
				datcli.LimiteCredito = 0m;
				datcli.Actualizar("select * from cliente where CodigoCli = '" + codigo.Text + "'  ");
			}

			Close();
			// Me.Dispose()
			return;
			HayErrores:
			;

			// ControlaErrores
		}

		private void nombres_TextChanged(object sender, EventArgs e)
		{
			NombreImpresion.Text = nombres.Text + " " + apellidos.Text;
		}

		private void OpE_CheckedChanged(object sender, EventArgs e)
		{
			if (OpE.Checked)
			{
				TipoIdent.SelectedIndex = 1;
			}
		}

		private void ruc_KeyDown(object sender, KeyEventArgs e)
		{
			short KeyCode = (short)e.KeyCode;
			if (KeyCode == (int)Keys.F2)
				ruc.Text = codigo.Text;
		}
		// ''''''Private Sub ruc_KeyPress(KeyAscii As Integer)
		// ''''''KeyAscii = SoloNumeros(KeyAscii)
		// ''''''End Sub
		// ''''''Private Sub telefono1_KeyPress(KeyAscii As Integer)
		// ''''''KeyAscii = SoloNumeros(KeyAscii)
		// ''''''End Sub
		// ''''''Private Sub telefono2_KeyPress(KeyAscii As Integer)
		// ''''''KeyAscii = SoloNumeros(KeyAscii)
		// ''''''End Sub
		// ''''''Private Sub telefono3_KeyPress(KeyAscii As Integer)
		// ''''''KeyAscii = SoloNumeros(KeyAscii)
		// ''''''End Sub
		private bool ValidaNumeroId()
		{
			bool ValidaNumeroIdRet = default;
			// Dim i As Integer
			string j = "";
			string Persona = "P";
			;

#error Cannot convert OnErrorResumeNextStatementSyntax - see comment for details
			/* Cannot convert OnErrorResumeNextStatementSyntax, CONVERSION ERROR: Conversion for OnErrorResumeNextStatement not implemented, please report this issue in 'On Error Resume Next' at character 12386


						Input:
								On Error Resume Next

						 */
			switch (TipoIdent.SelectedIndex)
			{
				case 0:
					{
						j = "O";
						break;
					}
				case 1:
					{
						j = "R";
						break;
					}
				case 2:
					{
						j = "C";
						break;
					}
				case 3:
					{
						j = "P";
						break;
					}
				case 4:
					{
						j = "F";
						break;
					}
			}
			if (OpE.Checked)
				Persona = "E";
			if (j == "O" | j == "P")
			{
				ValidaNumeroIdRet = true;
				return ValidaNumeroIdRet;
			}
			var prog = new valIdcedru.valcedruc();
			ValidaNumeroIdRet = prog.valCr(ruc.Text, j, Persona);  // ValidaId((ruc.Text), j, Persona)
			return ValidaNumeroIdRet;
		}

		private string ArreglaId(ref string Ident)
		{
			string ArreglaIdRet = default;
			ArreglaIdRet = Ident;
			switch (Ident ?? "")
			{
				case "O":
					{
						ArreglaIdRet = 0.ToString();
						break;
					}
				case "R":
					{
						ArreglaIdRet = 1.ToString();
						break;
					}
				case "C":
					{
						ArreglaIdRet = 2.ToString();
						break;
					}
				case "P":
					{
						ArreglaIdRet = 3.ToString();
						break;
					}
				case "F":
					{
						ArreglaIdRet = 4.ToString();
						break;
					}
			}

			return ArreglaIdRet;
		}

		private void email_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.F2)
			{
				string ssql = "select CorreoDefecto from adcfelec";
				using (SqlDataReader dr = SqlDatos.leerBaseAdcom(ssql))
				{
					if (dr.Read())
						email.Text = dr[0].ToString();
					else
						email.Text = "";
				}
			}
		}
		// Private Function BuscarEmailDefecto() As String


		// End Function

		private void TipoIdent_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (TipoIdent.SelectedIndex == 0)
				TipoIdent.SelectedIndex = 1;
		}

		private void codigo_TextChanged(object sender, EventArgs e)
		{

		}

		private string TipoIdGeneral(ref string Ident)
		{
			string TipoIdGeneralRet = default;
			TipoIdGeneralRet = "O";
			switch (Ident ?? "")
			{
				case "O":
				case "0":
					{
						TipoIdGeneralRet = "O";
						break;
					}
				case "R":
				case "1":
					{
						TipoIdGeneralRet = "R";
						break;
					}
				case "C":
				case "2":
					{
						TipoIdGeneralRet = "C";
						break;
					}
				case "P":
				case "3":
					{
						TipoIdGeneralRet = "P";
						break;
					}
				case "F":
				case "4":
					{
						TipoIdGeneralRet = "F";
						break;
					}
			}

			return TipoIdGeneralRet;
		}

	}
}