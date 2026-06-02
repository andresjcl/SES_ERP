using System;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using DattCom;
using Microsoft.VisualBasic;

namespace directMnt
{
	public partial class frmActualDat
	{
		private string ClienteProve, CodigoCli;
		private object EsNuevo;
		private short Salir;
		private string TipCod;
		// Dim Act1 As Boolean
		private string IniciarConCodigo;
		private string NombreImpresion;
		private string Codigo;

		public frmActualDat()
		{
			InitializeComponent();
			Label75 = _Label75;
			OpE = _OpE;
			TipoIdent = _TipoIdent;
			fTipo = _fTipo;
			OpP = _OpP;
			btncancelar = _btncancelar;
			fprincipal1 = _fprincipal1;
			fprincipal = _fprincipal;
			email = _email;
			telefono2 = _telefono2;
			direccion = _direccion;
			apellidos = _apellidos;
			nombres = _nombres;
			telefono1 = _telefono1;
			Label9 = _Label9;
			Label5 = _Label5;
			Label2 = _Label2;
			Label6 = _Label6;
			rr = _rr;
			Label4 = _Label4;
			ruc = _ruc;
			Label1 = _Label1;
			btncontinuar = _btncontinuar;
			Label8 = _Label8;
			_Label75.Name = "Label75";
			_OpE.Name = "OpE";
			_TipoIdent.Name = "TipoIdent";
			_fTipo.Name = "fTipo";
			_OpP.Name = "OpP";
			_btncancelar.Name = "btncancelar";
			_fprincipal1.Name = "fprincipal1";
			_fprincipal.Name = "fprincipal";
			_email.Name = "email";
			_telefono2.Name = "telefono2";
			_direccion.Name = "direccion";
			_apellidos.Name = "apellidos";
			_nombres.Name = "nombres";
			_telefono1.Name = "telefono1";
			_Label9.Name = "Label9";
			_Label5.Name = "Label5";
			_Label2.Name = "Label2";
			_Label6.Name = "Label6";
			_rr.Name = "rr";
			_Label4.Name = "Label4";
			_ruc.Name = "ruc";
			_Label1.Name = "Label1";
			_btncontinuar.Name = "btncontinuar";
			_Label8.Name = "Label8";
		}

		private void limpia()
		{
			string telefono3 = "";
			try
			{
				nombres.Text = "";
				apellidos.Text = 0.ToString();
				NombreImpresion = "";
				telefono1.Text = "";
				telefono2.Text = "";
				telefono3 = "";
				Codigo = "";
				ruc.Text = "";
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
				NombreImpresion = Strings.Trim(nombres.Text + " " + apellidos.Text);
			}
			else
			{
				NombreImpresion = Strings.Trim(apellidos.Text + " " + nombres.Text);
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
		public string ActualizarAlex(ref string Tipo, [Optional, DefaultParameterValue("")] ref string CodigoInicia)
		{
			ClienteProve = Tipo;
			IniciarConCodigo = CodigoInicia;
			ShowDialog();
			return CodigoCli;
		}
		private void visualizarDatos(string codigo)
		{
			var conn = new SqlConnection(datosEmpresa.strConxAdcom);
			conn.Open();
			var comm = new SqlCommand("select * from identificacion where codigo = '" + codigo + "'", conn);
			var dr = comm.ExecuteReader();
			if (dr.Read())
			{
				TipoIdent.SelectedValue = dr[""];
			}



		}
		// Private Sub CBuscador_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CBuscador.Click
		// Me.UseWaitCursor = True
		// Dim ElNombre As String = ""
		// Dim ElCodigo As String = ""
		// Dim Buscod As New Syscod.ManSysnetClass
		// TipCod = Buscod.BuscarReferencia("Ciudades", ElCodigo, ElNombre)
		// Lcod.Text = ElNombre
		// Me.UseWaitCursor = False
		// End Sub

		// Private Sub codigo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Codigo.KeyDown
		// Dim KeyCode As Short = CShort(e.KeyCode)
		// Dim Shift As Short = CShort(e.KeyData \ &H10000)
		// If KeyCode = System.Windows.Forms.Keys.F2 Then Codigo.Text = ruc.Text
		// End Sub

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
			/* Cannot convert OnErrorResumeNextStatementSyntax, CONVERSION ERROR: Conversion for OnErrorResumeNextStatement not implemented, please report this issue in 'On Error Resume Next' at character 4450


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
			return;
			HayErrores:
			;

			// ControlaErrores
		}
		private void Grabar()
		{
			// On Error Resume Next
			// Dim cod As String

			// Dim ConxAdcom As New ADODB.Connection
			// ConxAdcom.ConnectionString = datosEmpresa.strConxAdcom_6
			// ConxAdcom.Open()

			// Dim RECIDE As New ADODB.Recordset
			// RECIDE = New ADODB.Recordset
			// Dim Tip As String
			// If Codigo.Text = "" Then
			// MsgBox("Debe ingresar un código", MsgBoxStyle.Information)
			// Codigo.Focus()
			// Exit Sub
			// End If
			// If ruc.Text = "" Then
			// MsgBox("Debe ingesar el Ruc o la cédula")
			// ruc.Focus()
			// Exit Sub
			// End If
			// If nombres.Text = "" Then
			// MsgBox("Debe ingresar el nombre ", MsgBoxStyle.Information)
			// nombres.Focus()
			// Exit Sub
			// End If
			// cod = Codigo.Text
			// If ValidaNumeroId() = False Then
			// MsgBox("El numero del documento de identificacion está errado ", MsgBoxStyle.Critical)
			// ruc.Focus()
			// Return
			// End If

			// Dim sqlaux As String = "Select codigo from Identificacion where cedulaidentidadruc='" & ruc.Text & "' and codigo <> '" & Codigo.Text & "' "
			// Dim Conectar As New SqlClient.SqlConnection(datosEmpresa.strConxAdcom)
			// Dim dataAd As SqlDataReader
			// Dim comm As New SqlClient.SqlCommand(sqlaux, Conectar)
			// Conectar.Open()
			// dataAd = comm.ExecuteReader
			// If dataAd.Read Then
			// ruc.Text = ""
			// MsgBox("La cédula o ruc ya existe ", MsgBoxStyle.Critical)
			// ruc.Focus()
			// dataAd.Close()
			// Conectar.Close()
			// comm.Dispose()
			// Conectar.Dispose()
			// Exit Sub
			// End If
			// Dim rsalex = New Identificacion(datosEmpresa.strConxAdcom)
			// Identificacion.CadenaSelect = "select * from identificacion where Codigo = '" & Codigo.Text & "'  "
			// rsalex = Identificacion.Buscar(" Codigo = '" & Codigo.Text & "'  ")

			// If IsNothing(rsalex) = False Then
			// If rsalex.Codigo > "" Then
			// MsgBox("El código ya existe , debe ingresar otro código ", MsgBoxStyle.Information)
			// Codigo.Focus()
			// Exit Sub
			// End If
			// Else
			// rsalex = New Identificacion(datosEmpresa.strConxAdcom)
			// End If

			// If OpP.Checked = True Then
			// Tip = "N"
			// Else
			// Tip = "J"
			// End If
			// With rsalex
			// .TipoPersona = Tip
			// .Codigo = Codigo.Text
			// .CedulaIdentidadRuc = ruc.Text
			// If Not IsDBNull(nombres.Text) Then .Nombres = nombres.Text
			// If Not IsDBNull(apellidos.Text) Then .Apellidos = apellidos.Text
			// .NombreImpresion = NombreImpresion.Text
			// .EsBanco = False
			// .EsEmpleado = False
			// .EsVendedor = False
			// .EsAsociado = False
			// .EsCliente = False
			// .EsProveedor = False
			// Select Case UCase(ClienteProve)
			// Case "P"
			// .EsProveedor = True
			// Case "E"
			// .EsEmpleado = True
			// Case "V"
			// .EsVendedor = True
			// Case "F"
			// .EsBanco = True
			// .EsProveedor = True
			// Case Else
			// .EsCliente = True
			// End Select

			// .Telefono1 = telefono1.Text
			// .Telefono2 = telefono2.Text
			// .Telefono3 = ""
			// .CorreoElectrónico = email.Text

			// If Not IsDBNull(direccion.Text) Then .Domicilio = direccion.Text
			// If Not IsDBNull(TipCod) Then .Ciudad = TipCod

			// .TipoIdentificacion = TipoIdGeneral(TipoIdent.SelectedIndex.ToString())
			// rsalex.HistoriaClinica = ruc.Text
			// rsalex.Actualizar()

			// CodigoCli = Codigo.Text
			// If .EsCliente Then
			// Dim datcli = New dbCliente(datosEmpresa.strConxAdcom)
			// datcli.CodigoCli = CodigoCli
			// datcli.LimiteCredito = 0
			// datcli.Actualizar("select * from cliente where CodigoCli = '" & Codigo.Text & "'  ")
			// End If
			// End With

			Close();
			// Me.Dispose()
			return;
			HayErrores:
			;

			// ControlaErrores
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
			// If KeyCode = System.Windows.Forms.Keys.F2 Then ruc.Text = Codigo.Text
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
			/* Cannot convert OnErrorResumeNextStatementSyntax, CONVERSION ERROR: Conversion for OnErrorResumeNextStatement not implemented, please report this issue in 'On Error Resume Next' at character 11042


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