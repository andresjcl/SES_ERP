using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DattCom;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace directMnt
{

	public partial class DEEPPCTE
	{
		// Dim DaaxLibNom As New daaxLib.DaxLibNom
		private daaxLib.DaxLibDigDato DaaxLibDat = new daaxLib.DaxLibDigDato();
		private EmpNomR.AdcNomb RetornaNombre = new EmpNomR.AdcNomb();
		internal string CodSuc;
		private string[] codigoDirectorio = new string[8];
		private bool Cambio;
		private string resp;
		private int ii;
		private string CodigoStr;
		private string entrega;
		private string CodigoBusca;
		public string tipoper;
		public string cedulabusca;
		public string Sexo;
		private bool CambioAdicionales;
		public string CodigoFoto = "";
		private int Indice;
		private string[] TipCodSyscod = new string[51];
		private bool IniNvo;
		public string QUECODIGO;
		private bool propio;

		private int EsNuevo;

		private bool Act1;
		private string[] Operacion = new string[4];
		private bool saltar = true;
		private string accion = "";
		private ClassCambios LosCambios = new ClassCambios();

		private mntUsrs.autorizacion autorizaOpcion = new mntUsrs.autorizacion();
		private string claveOpcion = "mnuoDirectorioGeneral";
		private string ImgDirectorio = @"\Directorio\";

		public DEEPPCTE()
		{
			InitializeComponent();
		}
		public void IniciaNuevo()
		{
			try
			{
				IniNvo = true;
				ShowDialog();
			}
			catch (Exception ee)
			{
				Interaction.MsgBox("excepción iniNvo: " + ee.Message);
			}
		}
		private void LlenarCombos()
		{
			var dc = new DaxCombobx.CargCmbBox();
			dc.DaxCombosReferencia("Paises", datosEmpresa.strConxAdcom, cmbPaisDomicilio, "S");
			dc.DaxCombosReferencia("Provincias", datosEmpresa.strConxAdcom, cmbProvinciaDomicilio, "S");
			dc.DaxCombosReferencia("Ciudades", datosEmpresa.strConxAdcom, cmbCiudadDomicilio, "S");
			dc.DaxCombosReferencia("Cantones", datosEmpresa.strConxAdcom, cmbCantonDomicilio, "S");
			dc.DaxCombosReferencia("Parroquias", datosEmpresa.strConxAdcom, cmbParroquiaDomicilio, "S");
			dc.DaxCombosReferencia("Regiones", datosEmpresa.strConxAdcom, cmbRegionDomicilio, "S");

			dc.DaxCombosReferencia("Paises", datosEmpresa.strConxAdcom, cmbPaisNace, "S");
			dc.DaxCombosReferencia("Provincias", datosEmpresa.strConxAdcom, cmbProvinciaNace, "S");
			dc.DaxCombosReferencia("Ciudades", datosEmpresa.strConxAdcom, cmbCiudadNace, "S");
			dc.DaxCombosReferencia("Regiones", datosEmpresa.strConxAdcom, cmbRegionNace, "S");


			dc.DaxCombosReferencia("Nacionalidad", datosEmpresa.strConxAdcom, cmbNacionalidadPersonal, "S");

			dc.DaxCombosReferencia("Profesion", datosEmpresa.strConxAdcom, cmbProfesion, "S");
			dc.DaxCombosReferencia("Especialidad", datosEmpresa.strConxAdcom, cmbEspecialidad, "S");
			dc.DaxCombosReferencia("Especialidad", datosEmpresa.strConxAdcom, cmbEspecialidad2, "S");

		}
		private void Apellidos_TextChanged(object sender, EventArgs e)
		{

			DataTable dt = datosEmpresa.leeParametrosEmp("par_acumhis");
			try
			{
				if (Convert.ToBoolean(dt.Rows[0]["par_AcumHis"]) == false)
				{
					impresion.Text = Strings.Trim(TxtNombres.Text + " " + Apellidos.Text);
				}
				else
				{
					impresion.Text = Strings.Trim(Apellidos.Text + " " + TxtNombres.Text);
				}
			}
			catch
			{
				impresion.Text = Strings.Trim(Apellidos.Text + " " + TxtNombres.Text);
			}
		}

		private bool leerIdentificacion()
		{
			var datosIdentificacion = new Identificacion(datosEmpresa.strConxAdcom);
			datosIdentificacion = Identificacion.Buscar(" codigo = '" + QUECODIGO + "' ");

			if (datosIdentificacion == null)
			{
				return false;
				return default;
			}

			Codigo.Text = datosIdentificacion.Codigo;
			tipoper = datosIdentificacion.TipoPersona;

			// If tipoper = "J" Then
			// Juridica.Checked = True
			// Else
			// tipoper = "N"
			// Natural.Checked = True
			// End If

			// If tipoper = "J" Then Juridica.Checked = True : Natural.Checked = False
			// If tipoper = "N" Then Juridica.Checked = False : Natural.Checked = True

			// Cliente.Checked = .EsCliente
			// Proveedor.Checked = .EsProveedor
			// Empleado.Checked = .EsEmpleado
			// Banco.Checked = .EsBanco
			// EsVendedor.Checked = .EsVendedor
			// Asociacion.Checked = .EsAsociado

			// If CBool(.EsCliente")) = True Then Cliente.CheckState = CheckState.Checked Else Cliente.CheckState = CheckState.Unchecked
			// If CBool(.EsProveedor")) = True Then Proveedor.CheckState = CheckState.Checked Else Proveedor.CheckState = CheckState.Unchecked
			// If CBool(.EsEmpleado")) = True Then Empleado.CheckState = CheckState.Checked Else Empleado.CheckState = CheckState.Unchecked
			// If CBool(.EsBanco")) = True Then Banco.CheckState = CheckState.Checked Else Banco.CheckState = CheckState.Unchecked
			// If CBool(.EsVendedor")) = True Then EsVendedor.CheckState = CheckState.Checked Else EsVendedor.CheckState = CheckState.Unchecked
			// If CBool(.EsAsociado")) = True Then Asociacion.CheckState = CheckState.Checked Else Asociacion.CheckState = CheckState.Unchecked

			// If .EsDirecta = "SI" Then
			// Directa.CheckState = CheckState.Checked
			// Else
			// Directa.CheckState = CheckState.Unchecked
			// End If

			string localArreglaId() { string argIdent = Valores.CorrijeNulo(datosIdentificacion.TipoIdentificacion); var ret = ArreglaId(ref argIdent); return ret; }

			string localArreglaId1() { string argIdent1 = Valores.CorrijeNulo(datosIdentificacion.TipoIdentificacion); var ret = ArreglaId(ref argIdent1); return ret; }

			TipoIdent.SelectedIndex = (int)Math.Round(Conversion.Val(localArreglaId1())); // : TIPID = CStr(TipoIdent.SelectedIndex)
			TxtCedulaRuc.Text = datosIdentificacion.CedulaIdentidadRuc;
			TxtNombres.Text = datosIdentificacion.Nombres;
			Apellidos.Text = datosIdentificacion.Apellidos;
			impresion.Text = datosIdentificacion.NombreImpresion;

			TxtNroDomicilio.Text = datosIdentificacion.NumeroDomicilio;
			cmbPaisDomicilio.SelectedValue = datosIdentificacion.País;
			cmbProvinciaDomicilio.SelectedValue = datosIdentificacion.Provincia;
			cmbCiudadDomicilio.SelectedValue = datosIdentificacion.Ciudad;
			txtnomDireccion.Text = datosIdentificacion.Domicilio;
			txtTelefono1.Text = datosIdentificacion.Telefono1;
			txtTelefono2.Text = datosIdentificacion.Telefono2;
			txtTelefono3.Text = datosIdentificacion.Telefono3;
			TxtData6.Text = datosIdentificacion.NúmeroFax;
			cmbParroquiaDomicilio.SelectedValue = datosIdentificacion.Casilla;
			// !correoelectrónico = TxtData8.Text
			TxtData8.Text = datosIdentificacion.CorreoElectrónico;
			TxtData9.Text = datosIdentificacion.Paginaweb;
			cmbCantonDomicilio.SelectedValue = datosIdentificacion.Sector;
			txtGrupo1.Text = datosIdentificacion.Grupo1;
			txtGrupo2.Text = datosIdentificacion.Grupo2;
			txtGrupo3.Text = datosIdentificacion.Grupo3;
			txtHistoriaclinica.Text = datosIdentificacion.HistoriaClinica;
			CodigoFoto = datosIdentificacion.Logotipo;
			// -----------------------------) Then PorComision.Text = .ComisionVenta")
			// -----------------------------ones Then Text1.Text = .CtaCobrarComisiones")

			if (datosEmpresa.usr != datosIdentificacion.CodGrabo & Operators.CompareString(datosIdentificacion.CodGrabo, "", false) > 0)
				propio = false;
			else
				propio = true;

			ExoneradoIva.Checked = datosIdentificacion.ExoneradoIva;
			chkRise.Checked = datosIdentificacion.esRise;
			txtContribuyenteEspecial.Text = datosIdentificacion.NroCtrbuyteEspecial;
			chkObligaContabilidad.Checked = datosIdentificacion.ObligLlevarConta;
			chkRegimenMicroempresas.Checked = datosIdentificacion.RegimenMicroempresas;

			cmbRegionDomicilio.Text = datosIdentificacion.regionDomicilio;
			txtSector.Text = datosIdentificacion.SectorDomicilio;
			TxtResolucionAR.Text = datosIdentificacion.NroAcdoAgntRetencion;
			return true;
		}

		private bool leerPersonal()
		{
			var datosPersonales = new dbPersonal(datosEmpresa.strConxAdcom);
			datosPersonales = dbPersonal.Buscar(" codigoper = '" + QUECODIGO + "'");
			if (datosPersonales == null)
				return false;
			// Dim Buscod As New Syscod.ManSysnetClass
			// On Error Resume Next
			// Dim ConxAdcom As New SqlClient.SqlConnection(datosEmpresa.strConxAdcom)
			// Dim rs As SqlClient.SqlDataReader
			// Dim Ssql As String = "select * from Personal where codigoper = '" & QUECODIGO & "'"
			// Dim comm As New SqlClient.SqlCommand(Ssql, ConxAdcom)
			// ConxAdcom.Open()
			// rs = comm.ExecuteReader

			// If rs.Read = False Then rs.Close() : Return False : Exit Function

			// tabla personal
			// If .Read Then
			fechanaci.Text = datosPersonales.FechaNacimiento.ToShortDateString();
			Lugarnaci.Text = datosPersonales.LugarNacimiento;
			Sexo = datosPersonales.Sexo;
			cmbEstadoCivil.Text = datosPersonales.EstadoCivil;
			cmbNacionalidadPersonal.SelectedValue = datosPersonales.Nacionalidad;
			hobbys.Text = datosPersonales.Hobbys;


			txtCodTar.Text = datosPersonales.codigotarjrta;
			txtNumTar.Text = datosPersonales.numerotarjrta;


			cmbProfesion.SelectedValue = datosPersonales.Profesión;
			cmbEspecialidad.SelectedValue = datosPersonales.Especialidad;
			cmbEspecialidad2.SelectedValue = datosPersonales.Especialidad2;
			txtReferirseComo.Text = datosPersonales.Referirsecomo;
			cmbTipoSangre.Text = datosPersonales.TipoSangre;
			txtLugTra.Text = datosPersonales.DirecciónTrabajo;
			cmbCiudadNace.Text = datosPersonales.ciudadNacimto;
			cmbRegionNace.Text = datosPersonales.regionNacimto;
			cmbPaisNace.Text = datosPersonales.paisNacimto;
			cmbProvinciaNace.Text = datosPersonales.provNacimto;

			if (Sexo == "M")
			{
				mujer.Checked = true;
			}
			else
			{
				hombre.Checked = true;
				Sexo = "H";
			}
			txtDiscapacidad.Text = datosPersonales.Discapacidad;
			txtPorcDiscapacidad.Text = datosPersonales.PorcentajeDiscapacidad.ToString("#0.00");
			return true;
		}

		private bool leerCliente()
		{
			var datosCliente = new dbCliente(datosEmpresa.strConxAdcom);
			datosCliente = dbCliente.Buscar(" codigocli = '" + QUECODIGO + "' ");
			if (datosCliente == null)
				return false;

			var Buscod = new Syscod.ManSysnetClass();
			// On Error Resume Next
			// Dim ConxAdcom As New SqlClient.SqlConnection(datosEmpresa.strConxAdcom)
			// Dim rs As SqlClient.SqlDataReader
			// Dim Ssql As String = "select * from cliente where codigocli = '" & QUECODIGO & "' "
			// Dim comm As New SqlClient.SqlCommand(Ssql, ConxAdcom)
			// ConxAdcom.Open()
			// rs = comm.ExecuteReader
			// If rs.Read = False Then rs.Close() : Return False : Exit Function
			// 'If rs.Read Then
			// If Not IsDBNull(rs.Item("VendedorInterno")) Then
			if (datosCliente.VendedorInterno != datosEmpresa.usr & datosCliente.CobradorInterno != datosEmpresa.usr)
				propio = false;
			// tabla cliente
			// If .Read Then
			txtTipoCliente.Text = Buscod.QueNombre(datosCliente.TipoCli, TipCodSyscod[3]);
			txtZonaVentas.Text = Buscod.QueNombre(datosCliente.ZonaVentas, TipCodSyscod[4]);
			txtVendedor.Text = QueNombre(datosCliente.VendedorInterno);
			codigoDirectorio[0] = datosCliente.VendedorInterno;
			txtOperador.Text = QueNombre(datosCliente.Operador);
			codigoDirectorio[5] = datosCliente.Operador;
			txtTransportadora.Text = QueNombre(datosCliente.Transportadora);
			codigoDirectorio[6] = datosCliente.Transportadora;
			txtZonaCobranzas.Text = Buscod.QueNombre(datosCliente.ZonaCobranza, TipCodSyscod[5]);
			txtCobrador.Text = QueNombre(datosCliente.CobradorInterno);
			codigoDirectorio[1] = datosCliente.CobradorInterno;
			txtPrecioVenta.Text = Buscod.QueNombre(datosCliente.PrecioVenta, TipCodSyscod[6]);
			txtFormaPago.Text = RetornaNombre.RetornaNombrePago(datosCliente.FormaPago, datosEmpresa.strConxAdcom);
			txtPorcDescuento.Text = datosCliente.PorcDescuento.ToString();
			txtLimiteCredito.Text = datosCliente.LimiteCredito.ToString();
			txtDescuentoAsociacion.Text = datosCliente.DescuentoAso.ToString();
			observacli.Text = datosCliente.Observaciones;
			txtContacto.Text = datosCliente.Contacto;
			entregarmer.Text = datosCliente.Entregarmercaderia;
			Cuenta0.Text = datosCliente.CtbCobrar;
			Cuenta4.Text = datosCliente.CtbCobrar2;
			// End If
			entregarmer.Text = datosCliente.PuertoEmbarque;
			txtPaisEntrega.Text = datosCliente.PaisEmbarque;
			// rs.Close()
			// comm.Dispose()
			// ConxAdcom.Close()
			// ConxAdcom.Dispose()
			return true;
		}
		// Private Function leerProveedor() As Boolean
		// On Error Resume Next
		// Dim ConxAdcom As New SqlClient.SqlConnection(datosEmpresa.strConxAdcom)
		// Dim rs As SqlClient.SqlDataReader
		// On Error Resume Next
		// Dim Ssql As String = "Select * from proveedor where codigoproveedor = '" & QUECODIGO & "'"
		// Dim comm As New SqlClient.SqlCommand(Ssql, ConxAdcom)
		// ConxAdcom.Open()
		// rs = comm.ExecuteReader

		// If rs.Read = False Then rs.Close() : Return False : Exit Function

		// 'tabla proveedor
		// With rs
		// 'If .Read Then
		// If Not IsDBNull(.Item("FormaPago")) Then Lcod8.Text = RetornaNombre.RetornaNombrePago(CStr(.Item("FormaPago")), datosEmpresa.strConxAdcom)
		// If Not IsDBNull(.Item("PorceDescuent")) Then porcedescuentoprv.Text = CStr(.Item("PorceDescuent"))
		// 'If CorrijeNuloN(.Item("IncluyeTranspo")) = 1 Then incluyetransporte.CheckState = CheckState.Checked Else incluyetransporte.CheckState = CheckState.Unchecked
		// incluyetransporte.Checked = Convert.ToBoolean(.Item("IncluyeTranspo"))

		// If Not IsDBNull(.Item("limcreditoprv")) Then limcreditoprv.Text = CStr(.Item("limcreditoprv"))
		// If Not IsDBNull(.Item("Producto1")) Then producto.Text = CStr(.Item("Producto1"))
		// If Not IsDBNull(.Item("Servicios1")) Then servicios.Text = CStr(.Item("Servicios1"))
		// If Not IsDBNull(.Item("Observaciones")) Then observacionesprv.Text = CStr(.Item("Observaciones"))
		// If Not IsDBNull(.Item("ctbproveedor")) Then Cuenta1.Text = CStr(.Item("ctbproveedor"))
		// If Not IsDBNull(.Item("ctbproveedor2")) Then Cuenta5.Text = CStr(.Item("ctbproveedor2"))

		// 'If CorrijeNuloN(.Item("EntregaNuestraOficina")) = 1 Then chkEntregaDirecccion.CheckState = CheckState.Checked Else chkEntregaDirecccion.CheckState = CheckState.Unchecked
		// 'If CorrijeNuloN(.Item("RetirarMercaderia")) = 1 Then chkRetirarProveedor.CheckState = CheckState.Checked Else chkRetirarProveedor.CheckState = CheckState.Unchecked
		// 'If CorrijeNuloN(.Item("EnvioATransporte")) = 1 Then chkRetirarTransporte.CheckState = CheckState.Checked Else chkRetirarTransporte.CheckState = CheckState.Unchecked

		// chkEntregaDirecccion.Checked = CBool(.Item("EntregaNuestraOficina"))
		// chkRetirarTransporte.Checked = CBool(.Item("EnvioATransporte"))
		// chkRetirarProveedor.Checked = CBool(.Item("RetirarMercaderia"))

		// 'chkAereo.Checked = (CorrijeNuloN(.Item("transAereo")) = 1) 'Ten chkAereo.CheckState = CheckState.Checked Else Check4.CheckState = CheckState.Unchecked
		// 'chkMaritimo.Checked = (CorrijeNuloN(.Item("transMaritimo")) = 1) 'Then Check4.CheckState = CheckState.Checked Else Check4.CheckState = CheckState.Unchecked
		// 'chkTerrestre.Checked = (CorrijeNuloN(.Item("transTerrestre")) = 1) 'Then Check4.CheckState = CheckState.Checked Else Check4.CheckState = CheckState.Unchecked

		// chkAereo.Checked = CBool(.Item("transAereo"))
		// chkMaritimo.Checked = CBool(.Item("transMaritimo"))
		// chkTerrestre.Checked = CBool(.Item("transTerrestre"))



		// 'End If
		// End With
		// rs.Close()
		// comm.Dispose()
		// ConxAdcom.Close()
		// ConxAdcom.Dispose()
		// Return True
		// End Function

		// tabla empleado
		// Private Function leerContactos() As Boolean
		// On Error Resume Next
		// 'tabla contacto
		// Dim Buscod As New Syscod.ManSysnetClass
		// Dim i As Integer

		// Dim ConxAdcom As New SqlClient.SqlConnection(datosEmpresa.strConxAdcom)
		// Dim rs As SqlClient.SqlDataReader
		// Dim Ssql As String = "select * from contactos where codcontacto = '" & QUECODIGO & "'"
		// Dim comm As New SqlClient.SqlCommand(Ssql, ConxAdcom)
		// ConxAdcom.Open()
		// rs = comm.ExecuteReader

		// i = 0
		// With rs
		// Do While .Read
		// MallaCtco.Rows.Add()
		// MallaCtco.Rows(i).Cells(0).Value = CorrijeNulo(.Item("Principal"))
		// MallaCtco.Rows(i).Cells(1).Value = CorrijeNulo(.Item("Nombre"))
		// MallaCtco.Rows(i).Cells(2).Value = CorrijeNulo(.Item("Cargo"))
		// MallaCtco.Rows(i).Cells(3).Value = CorrijeNulo(.Item("Extensión"))
		// MallaCtco.Rows(i).Cells(4).Value = CorrijeNulo(.Item("TelfCelular"))
		// MallaCtco.Rows(i).Cells(5).Value = CorrijeNulo(.Item("TeléfonoDirecto"))
		// MallaCtco.Rows(i).Cells(6).Value = CorrijeNulo(.Item("FechaNacimiento"))
		// MallaCtco.Rows(i).Cells(7).Value = CorrijeNulo(.Item("Actividades"))
		// MallaCtco.Rows(i).Cells(8).Value = CorrijeNulo(.Item("Preferencias"))
		// MallaCtco.Rows(i).Cells(9).Value = CorrijeNulo(.Item("Observaciones"))
		// i += 1
		// Loop
		// End With
		// rs.Close()
		// comm.Dispose()
		// ConxAdcom.Close()
		// ConxAdcom.Dispose()
		// Return True
		// End Function

		// Private Function leerAlias() As Boolean
		// On Error Resume Next
		// Dim i As Integer

		// Dim ConxAdcom As New SqlClient.SqlConnection(datosEmpresa.strConxAdcom)
		// Dim rs As SqlClient.SqlDataReader

		// Dim Ssql As String = "select * from identificacionalias where CodigoEmpresa = '" & QUECODIGO & "'"
		// Dim comm As New SqlClient.SqlCommand(Ssql, ConxAdcom)
		// ConxAdcom.Open()
		// rs = comm.ExecuteReader

		// With rs
		// i = 0
		// Do While .Read

		// MallaAlias.Rows.Add()
		// MallaAlias.Rows(i).Cells(0).Value = CorrijeNulo(.Item("NombreAlias"))
		// MallaAlias.Rows(i).Cells(1).Value = CorrijeNulo(.Item("DirecciónAlterna"))
		// MallaAlias.Rows(i).Cells(2).Value = CorrijeNulo(.Item("Teléfono_1"))
		// MallaAlias.Rows(i).Cells(3).Value = CorrijeNulo(.Item("Teléfono_2"))
		// MallaAlias.Rows(i).Cells(4).Value = CorrijeNulo(.Item("Id_Sri"))
		// MallaAlias.Rows(i).Cells(5).Value = CorrijeNulo(.Item("Observaciones"))
		// i += 1
		// Loop
		// End With
		// rs.Close()
		// comm.Dispose()
		// ConxAdcom.Close()
		// ConxAdcom.Dispose()
		// Return True
		// End Function
		private bool leerFamiliares()
		{
			;
#error Cannot convert OnErrorResumeNextStatementSyntax - see comment for details
			/* Cannot convert OnErrorResumeNextStatementSyntax, CONVERSION ERROR: Conversion for OnErrorResumeNextStatement not implemented, please report this issue in 'On Error Resume Next' at character 19780


						Input:
								On Error Resume Next

						 */
			int i = 0;
			var ConxAdcom = new SqlConnection(datosEmpresa.strConxAdcom);
			SqlDataReader rs;

			string Ssql = "select * from ROLFAM where CodEmpleado = '" + QUECODIGO + "'";
			var comm = new SqlCommand(Ssql, ConxAdcom);
			ConxAdcom.Open();
			rs = comm.ExecuteReader();

			// If rs.Read = False Then rs.Close() : Return False : Exit Function

			while (rs.Read())
			{
				malla.Rows.Add();
				// malla.Rows(i).Cells(0) = i + 1
				malla.Rows[i].Cells["CedulaId"].Value = Valores.CorrijeNulo(rs["CEDULA"]);
				malla.Rows[i].Cells["Nombres"].Value = Valores.CorrijeNulo(rs["Nombres"]);
				malla.Rows[i].Cells["Parentesco"].Value = Valores.CorrijeNulo(rs["Parentesco"]);
				malla.Rows[i].Cells["FechaNacim"].Value = Valores.CorrijeNulo(rs["FechaNacimiento"]);
				malla.Rows[i].Cells["Sexo1"].Value = Valores.CorrijeNulo(rs["Sexo"]);
				malla.Rows[i].Cells["EstadoCivil"].Value = Valores.CorrijeNulo(rs["EstadoCivil"]);
				malla.Rows[i].Cells["Direccion"].Value = Valores.CorrijeNulo(rs["Direccion"]);
				malla.Rows[i].Cells["Teléfono_1"].Value = Valores.CorrijeNulo(rs["Teléfono_1"]);
				malla.Rows[i].Cells["Teléfono_2"].Value = Valores.CorrijeNulo(rs["Teléfono_2"]);
				malla.Rows[i].Cells["Ocupación"].Value = Valores.CorrijeNulo(rs["Ocupacion"]);
				if (Valores.CorrijeNulo(rs["EsDependiente"]).ToString() == "Si")
					malla.Rows[i].Cells["Depend"].Value = "Si";
				else
					malla.Rows[i].Cells["Depend"].Value = "No";
				if (Valores.CorrijeNulo(rs["EsMinusvalido"]).ToString() == "Si")
					malla.Rows[i].Cells["Minusv"].Value = "Si";
				else
					malla.Rows[i].Cells["Minusv"].Value = "No";
				i += 1;
			}
			rs.Close();
			comm.Dispose();
			ConxAdcom.Close();
			ConxAdcom.Dispose();
			return true;
		}

		private string QueNombre(string COD)
		{
			string QueNombreRet = default;
			var ConxAdcomNet = new SqlConnection(datosEmpresa.strConxAdcom);
			ConxAdcomNet.Open();
			SqlDataReader RS;
			var Comm = new SqlCommand("select nombreimpresion from identificacion where Codigo = '" + COD + "'", ConxAdcomNet);
			string Nombre;
			;
#error Cannot convert OnErrorResumeNextStatementSyntax - see comment for details
			/* Cannot convert OnErrorResumeNextStatementSyntax, CONVERSION ERROR: Conversion for OnErrorResumeNextStatement not implemented, please report this issue in 'On Error Resume Next' at character 22672


						Input:
								On Error Resume Next

						 */
			RS = Comm.ExecuteReader();
			Nombre = "";
			if (RS.Read())
				Nombre = RS["NOMBREIMPRESION"].ToString();
			RS.Close();
			RS = null;
			Comm.Dispose();
			QueNombreRet = Nombre;
			ConxAdcomNet.Dispose();
			return QueNombreRet;
		}

		private double _PonerDatosTipo_sum = default;

		private void PonerDatosTipo()
		{
			_PonerDatosTipo_sum += 1d;
			// If Natural.Checked = True Then Empleado.Enabled = True : Banco.Enabled = False : Banco.Checked = False Else Empleado.Enabled = False : Banco.Enabled = True

			// If Natural.Checked = False Then
			// tabDatosPer.Parent = Nothing
			// tabFamiliares.Parent = Nothing
			// Else
			// tabDatosPer.Parent = DatosDirectorio
			// tabFamiliares.Parent = DatosDirectorio
			// End If
			// If Empleado.Checked = False Then
			// tabEmpleado.Parent = Nothing
			// Else
			// tabEmpleado.Parent = DatosDirectorio
			// End If

			// If Cliente.Checked = False Then tabCliente.Parent = Nothing Else tabCliente.Parent = DatosDirectorio '.TabPages.Add(tabCliente)
			// If Proveedor.Checked = False Then tabProveedor.Parent = Nothing Else tabProveedor.Parent = DatosDirectorio

			ControlarAutorizaciones();

		}
		private void MoverAArchivo()
		{
			Cambio = false;
			EsNuevo = 0;
		}

		private void Asociacion_CheckStateChanged(object sender, EventArgs e)
		{
			// PonerDatosTipo()
		}

		private void centroCosto_KeyPress(ref int KeyAscii)
		{
			int argKeyAscii = (short)KeyAscii;
			KeyAscii = DaaxLibDat.SoloNumeros(ref argKeyAscii);
		}

		private void ciruc_KeyPress(ref int KeyAscii)
		{
			int argKeyAscii = (short)KeyAscii;
			KeyAscii = DaaxLibDat.SoloNumeros(ref argKeyAscii);
		}

		private void CBuscador7_Click(object sender, EventArgs e)
		{
			string ElCodigo = "";
			var BusPAG = new Buscar.frmBuscar();   // DaxPagos.BuscadorPagos
			string sSql = "select top 100 percent idFormasDePago,Descripcion as Descripción from formasdepago where tipoformapago <> 2 order by Descripcion";
			ElCodigo = BusPAG.Buscar(datosEmpresa.strConxAdcom, sSql, "idFormasDePago", "Descripción", "", "Formas de pago clientes");
			BusPAG = null;
			txtFormaPago.Text = RetornaNombre.RetornaNombrePago(ElCodigo, datosEmpresa.strConxAdcom);
		}

		// Private Sub CBuscador8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
		// Dim ElCodigo As String = ""
		// Dim BusPAG As New Buscar.frmBuscar   'DaxPagos.BuscadorPagos
		// Dim sSql As String = "select top 100 percent idFormasDePago,Descripcion as Descripción from formasdepago where tipoformapago <> 2 order by Descripcion"
		// ElCodigo = BusPAG.Buscar(datosEmpresa.strConxAdcom, sSql, "idFormasDePago", "Descripción", "", "Formas de pago clientes")
		// BusPAG = Nothing
		// Lcod8.Text = RetornaNombre.RetornaNombrePago(ElCodigo, datosEmpresa.strConxAdcom)
		// End Sub

		// Private Sub CBuscador0_Click(ByVal sender As Object, ByVal e As System.EventArgs)
		// CBuscadorSuc()
		// End Sub

		// Private Sub CBuscador10_Click(ByVal sender As Object, ByVal e As System.EventArgs)
		// CBuscador(textNomCargo, 10)
		// End Sub

		// Private Sub CBuscador11_Click(ByVal sender As Object, ByVal e As System.EventArgs)
		// CBuscador(Lcod11, 11)
		// End Sub

		// Private Sub CBuscador12_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CBuscador12.Click
		// CBuscador(txtNomPais, 12)
		// End Sub

		// Private Sub CBuscador13_Click(ByVal sender As Object, ByVal e As System.EventArgs)
		// CBuscador(txtNomProvincia, 13)
		// End Sub

		// Private Sub CBuscador14_Click(ByVal sender As Object, ByVal e As System.EventArgs)
		// Me.UseWaitCursor = True
		// Me.Cursor = Cursors.WaitCursor
		// CBuscador(txtNomCiudad, 14)
		// Me.UseWaitCursor = False
		// Me.Cursor = Cursors.Default
		// End Sub

		// Private Sub CBuscador2_Click(ByVal sender As Object, ByVal e As System.EventArgs)
		// CBuscador(Lcod2, 2)
		// End Sub

		private void CBuscador3_Click(object sender, EventArgs e)
		{
			var arglcod = txtTipoCliente;
			CBuscador(ref arglcod, 3);
			txtTipoCliente = arglcod;
		}

		private void CBuscador4_Click(object sender, EventArgs e)
		{
			var arglcod = txtZonaVentas;
			CBuscador(ref arglcod, 4);
			txtZonaVentas = arglcod;
		}

		private void CBuscador5_Click(object sender, EventArgs e)
		{
			var arglcod = txtZonaCobranzas;
			CBuscador(ref arglcod, 5);
			txtZonaCobranzas = arglcod;
		}

		private void CBuscador6_Click(object sender, EventArgs e)
		{
			var arglcod = txtPrecioVenta;
			CBuscador(ref arglcod, 6);
			txtPrecioVenta = arglcod;
		}

		// Private Sub CBuscador9_Click(ByVal sender As Object, ByVal e As System.EventArgs)
		// CBuscador(textNomDepartamento, 9)
		// End Sub
		private void CBuscador(ref TextBox lcod, int indice)
		{
			string ElNombre = "";
			string ElCodigo = "";
			var Buscod = new Syscod.ManSysnetClass();
			ElCodigo = Buscod.BuscarReferencia(ref TipCodSyscod[indice], ref ElCodigo, ref ElNombre);
			lcod.Text = ElNombre;
			Buscod = null;
		}
		// Private Sub CBuscadorSuc()
		// Dim ssql As String = "select suc_codigo as cod, suc_nombre as Nombre from emp_suc where emp_codigo = " + datosEmpresa.codEmpresa.ToString()
		// Dim BuscaSuc As New Buscar.frmBuscar
		// CodSuc = BuscaSuc.Buscar(datosEmpresa.strConxSyscod, ssql, "cod", "Nombre", "", "Buscar sucursales", "")
		// textNomSucursal.Text = RetornaNombre.RetornaNombreSucursal(datosEmpresa.codEmpresa, CodSuc, datosEmpresa.strConxSyscod)

		// BuscaSuc.Dispose()
		// End Sub

		private void CBuscador(ref Label lcod, int indice)
		{
			string ElNombre = "";
			string ElCodigo = "";
			var Buscod = new Syscod.ManSysnetClass();
			lcod.Text = Buscod.BuscarReferencia(ref TipCodSyscod[indice], ref ElCodigo, ref ElNombre);
			Buscod = null;
		}

		private void Codigo_KeyDown(object sender, KeyEventArgs e)
		{
			int KeyCode = (int)e.KeyCode;
			int Shift = (int)e.KeyData / 0x10000;
			if (KeyCode == (int)Keys.F2)
			{
				BuscarProximoCodigo();
			}
			else if (KeyCode == (int)Keys.Return & Operators.CompareString(Codigo.Text, "", false) > 0)
			{
				SaliendoCodigo();
			}
		}
		private void BuscarPorHistoriaClinica(string historia)
		{

			var prog = new Buscar.frmBuscar();
			string ingCodigo = prog.Buscar(datosEmpresa.strConxAdcom, "select codigo, nombreimpresion,HistoriaClinica from identificacion where ltrim(rtrim(historiaclinica)) = '" + Strings.Trim(historia) + "' ", "Codigo", "nombreImpresion", "", "Busqueda por Historia Clínica");
			if (Operators.CompareString(ingCodigo, "", false) > 0)
			{
				Codigo.Text = ingCodigo;
				SaliendoCodigo();
			}
		}

		private void SaliendoCodigo()
		{
			if (Operators.CompareString(Codigo.Text, "", false) > 0 & Codigo.ReadOnly == false)
				CargarRegistros();
		}

		// Private Sub ComCtb1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
		// cuenta(Cuenta2, Keys.F2, 0 \ &H10000)
		// End Sub

		// Private Sub Comctb2_Click(ByVal sender As Object, ByVal e As System.EventArgs)
		// cuenta(Cuenta3, Keys.F2, 0 \ &H10000)
		// End Sub

		private void Command1_Click(object sender, EventArgs e)
		{
			var argcuenta = Cuenta0;
			cuenta(ref argcuenta, (int)Keys.F2, 0 / 0x10000);
			Cuenta0 = argcuenta;
		}

		private void Command5_Click(object sender, EventArgs e)
		{
			var argcuenta = Cuenta4;
			cuenta(ref argcuenta, (int)Keys.F2, 0 / 0x10000);
			Cuenta4 = argcuenta;
		}

		// Private Sub Command6_Click(ByVal sender As Object, ByVal e As System.EventArgs)
		// cuenta(Cuenta5, Keys.F2, 0 \ &H10000)
		// End Sub

		private void BuscarRegistro()
		{
			var prog = new BuscaClien();
			string argCliOProv = "T";
			string argCodigoNombre = "";
			string argConAlias = "";
			string argConNuevo = "N";
			Codigo.Text = prog.IniBuscaCliOPro(ref argCliOProv, ref argCodigoNombre, ref argConAlias, ref argConNuevo);
			prog.Close();
			prog.Dispose();
			if (Operators.CompareString(Codigo.Text, "", false) > 0)
				SaliendoCodigo();
		}

		// Private Sub Command2_Click(ByVal sender As Object, ByVal e As System.EventArgs)
		// cuenta(Cuenta1, Keys.F2, 0 \ &H10000)
		// End Sub

		private void Cuenta0_KeyDown(object sender, KeyEventArgs e)
		{
			var argcuenta = Cuenta0;
			cuenta(ref argcuenta, (int)e.KeyCode, (int)e.KeyData / 0x10000);
			Cuenta0 = argcuenta;
		}

		// Private Sub Cuenta1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
		// cuenta(Cuenta1, e.KeyCode, e.KeyData \ &H10000)
		// End Sub

		// Private Sub Cuenta2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
		// cuenta(Cuenta2, e.KeyCode, e.KeyData \ &H10000)
		// End Sub

		// Private Sub Cuenta3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
		// cuenta(Cuenta3, e.KeyCode, e.KeyData \ &H10000)
		// End Sub

		// Private Sub Cuenta4_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
		// cuenta(Cuenta3, e.KeyCode, e.KeyData \ &H10000)
		// End Sub

		// Private Sub Cuenta5_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
		// cuenta(Cuenta5, e.KeyCode, e.KeyData \ &H10000)
		// End Sub

		private void cuenta(ref Label cuenta, int KeyCode, int Shift)
		{
			var prog = new global::CtaMtn.BuscaCta();
			string Nombre = "";
			if (KeyCode == (int)Keys.F2)
			{
				string argTipoMovimiento = "I";
				cuenta.Text = prog.BuscaCtaCtb(ref Nombre, ref argTipoMovimiento);
				prog = (global::CtaMtn.BuscaCta)null;
			}
		}

		private void Datox0_KeyDown(object sender, KeyEventArgs e)
		{
			int KeyCode = (int)e.KeyCode;
			int Shift = (int)e.KeyData / 0x10000;
			if (KeyCode == (int)Keys.F2)
				TxtCedulaRuc.Text = Codigo.Text;
		}

		private void Datox1_TextChanged(object sender, EventArgs e)
		{
			if (Emp.OrdenaPorApellidos == false)
			{
				impresion.Text = Strings.Trim(TxtNombres.Text + " " + Apellidos.Text);
			}
			else
			{
				impresion.Text = Strings.Trim(Apellidos.Text + " " + TxtNombres.Text);
			}
		}

		private void descuentoaso_KeyPress(object sender, KeyPressEventArgs e)
		{
			int KeyAscii = Strings.Asc(e.KeyChar);
			int argKeyAscii = (short)KeyAscii;
			KeyAscii = DaaxLibDat.SoloNumeros(ref argKeyAscii);
			e.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0)
			{
				e.Handled = true;
			}
		}

		private void btnEliminar_Click(object sender, EventArgs e)
		{
			try
			{
				var ConxAdcom = new SqlConnection(datosEmpresa.strConxAdcom);
				ConxAdcom.Open();
				string Ssql = "";

				CodigoBusca = Codigo.Text;
				if (Module1.ClienteMovimiento(ref CodigoBusca) == true)
				{
					Interaction.MsgBox("No puede eliminar este Codigo, existen movimientos registrados con este código", MsgBoxStyle.Critical);
					return;
				}
				if (Interaction.MsgBox("Esta seguro que desea eliminar el registro activo", MsgBoxStyle.YesNo) == MsgBoxResult.Yes)
				{
					Ssql = "delete from identificacion  where codigo='" + CodigoBusca + "' ";
					Ssql += "delete from personal  where codigoper='" + CodigoBusca + "' ";
					Ssql += "delete from contactos where codcontacto='" + CodigoBusca + "' ";
					Ssql += "delete from proveedor  where codigoproveedor='" + CodigoBusca + "' ";
					Ssql += "delete from cliente  where codigocli='" + CodigoBusca + "' ";
					Ssql += "delete from empleado  where codigoEmpleado='" + CodigoBusca + "' ";
					Ssql += "delete from rolfam  where codEmpleado='" + CodigoBusca + "' ";
					Ssql += "delete from adccapper  where codEmpleado='" + CodigoBusca + "' ";
					var comm = new SqlCommand(Ssql, ConxAdcom);
					comm.ExecuteNonQuery();

					// EliminarEmbarque()
					comm.Dispose();
				}
				ConxAdcom.Close();
				ConxAdcom.Dispose();
			}
			catch (Exception ee)
			{
				Interaction.MsgBox("excepción eliminaDir: " + ee.Message);
			}
			CodigoBusca = "";
			QUECODIGO = "";
			LimpiezaFormulario();
			DatosDirectorio.SelectedIndex = 0;
			EsNuevo = 0;
			PonerBotonesFormulario();
		}

		// Private Sub Banco_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs)
		// If Natural.Checked = True Then Banco.Checked = False
		// End Sub
		public void Directorio(string cod)
		{
			try
			{
				if (string.IsNullOrEmpty(cod))
				{
					LimpiezaFormulario();
					QUECODIGO = "";
					// Juridica.Checked = True
					EsNuevo = 1;
					PonerBotonesFormulario();
					Codigo.Focus();
				}
				else
				{
					QUECODIGO = cod;
					Codigo.Text = cod;
					CargarRegistros();
				}
				ShowDialog();
			}
			catch (Exception ee)
			{
				Interaction.MsgBox("excepción Directorio: " + ee.Message);
			}
		}

		private void DEEPPCTE_FormClosing(object sender, FormClosingEventArgs e)
		{
			bool Cancel = e.Cancel;
			var UnloadMode = e.CloseReason;
			QUECODIGO = 0.ToString();
			RetornaNombre = (object)null;
			DaaxLibDat = null;
			if (Emp.rol)
				generarTablaAdicionales();
			Dispose();
		}

		private void foto_Click(object sender, EventArgs e)
		{

			try
			{
				if (string.IsNullOrEmpty(ImgDirectorio))
				{
					Interaction.MsgBox("No se ha definido un directorio para registrar las imágenes" + Constants.vbCr + "Definalo en parametros del sistema", Constants.vbCritical);
					return;
				}
				dialogoOpen.Title = "Escojer fotografía para directorio";
				dialogoOpen.Filter = "Imágenes (*.bmp;*.ico;*.jpg)|*.bmp;*.ico;*.jpg";
				dialogoOpen.InitialDirectory = ImgDirectorio;
				dialogoOpen.ShowDialog();
				CodigoFoto = dialogoOpen.SafeFileName;
				Microsoft.VisualBasic.FileIO.FileSystem.CopyFile(dialogoOpen.FileName, ImgDirectorio + CodigoFoto, true);
				CargaFoto();
				Cambio = true;
			}
			catch (Exception ee)
			{
				MessageBox.Show("Excepción : el directorio " + ImgDirectorio + Constants.vbCr + " no es accesible  ");
			}
		}


		private void btnGuardar_Click(object sender, EventArgs e)
		{
			var Buscod = new Syscod.ManSysnetClass();
			try
			{
				malla.EndEdit();
				// mallaConceptos.EndEdit()
				MallaCtco.EndEdit();
				// mallaDatos.EndEdit()
				if (validacionDatos() == false)
					return;

				CodigoBusca = Codigo.Text;
				cedulabusca = TxtCedulaRuc.Text;

				var DatosIdentificacion = new Identificacion(datosEmpresa.strConxAdcom);

				if (CodigoBusca is DBNull)
					CodigoBusca = "";
				DatosIdentificacion = Identificacion.Buscar("cedulaidentidadruc='" + cedulabusca + "' and codigo <> '" + CodigoBusca + "' ");
				if (DatosIdentificacion is not null)
				{
					TxtCedulaRuc.Text = "";
					Interaction.MsgBox("El Nro. ID (cédula o ruc) ya existe ", MsgBoxStyle.Critical);
					TxtCedulaRuc.Focus();
					return;
				}
				DatosIdentificacion = new Identificacion(datosEmpresa.strConxAdcom);
				var movdatId = new moverDatosIdentificacion();
				movdatId.movDatIdentificacion(this, DatosIdentificacion, codigoDirectorio);
				movdatId = null;

				{
					ref var withBlock = ref DatosIdentificacion;
					if (withBlock.Actualizar("Select * from Identificacion " + " where identificacion.codigo = '" + CodigoBusca + "' ").Substring(0, 5) == "ERROR")
					{
						Interaction.MsgBox("El registro de identificacion no puede grabarse ", MsgBoxStyle.Exclamation);
						return;
					}
				}
				DatosIdentificacion = null;

				Interaction.SaveSetting("Alex", "Codigos", "Ultimo", Codigo.Text);

				// tabla personal
				// If Natural.Checked = True Then
				var tablaper = new dbPersonal(datosEmpresa.strConxAdcom);
				{
					ref var withBlock1 = ref tablaper;
					withBlock1.CodigoPer = Codigo.Text;
					if (Information.IsDate(fechanaci.Text))
						withBlock1.FechaNacimiento = Conversions.ToDate(fechanaci.Text);
					else
						withBlock1.FechaNacimiento = Conversions.ToDate("01/01/1900");
					withBlock1.LugarNacimiento = Lugarnaci.Text;
					if (hombre.Checked == true)
						withBlock1.Sexo = "H";
					else
						withBlock1.Sexo = "M";
					withBlock1.EstadoCivil = cmbEstadoCivil.Text;
					if (!(cmbNacionalidadPersonal.SelectedValue == null))
						withBlock1.Nacionalidad = cmbNacionalidadPersonal.SelectedValue.ToString();
					withBlock1.Hobbys = hobbys.Text;

					withBlock1.codigotarjrta = txtCodTar.Text;
					withBlock1.numerotarjrta = txtNumTar.Text;

					withBlock1.Profesión = Valores.CorrijeNulo(cmbProfesion.SelectedValue);
					withBlock1.Especialidad = Valores.CorrijeNulo(cmbEspecialidad.SelectedValue);
					withBlock1.Especialidad2 = Valores.CorrijeNulo(cmbEspecialidad2.SelectedValue);
					withBlock1.Referirsecomo = txtReferirseComo.Text;
					withBlock1.AsociadoAEmpresa = Conversions.ToInteger("0" + codigoDirectorio[3]);
					withBlock1.TipoSangre = cmbTipoSangre.Text;
					withBlock1.DirecciónTrabajo = txtLugTra.Text;

					withBlock1.paisNacimto = cmbPaisNace.Text;
					withBlock1.provNacimto = cmbProvinciaNace.Text;
					withBlock1.ciudadNacimto = cmbCiudadNace.Text;
					withBlock1.regionNacimto = cmbRegionNace.Text;

					withBlock1.Discapacidad = txtDiscapacidad.Text;
					withBlock1.PorcentajeDiscapacidad = Convert.ToDecimal("0" + txtPorcDiscapacidad.Text);


					if (withBlock1.Actualizar("select * from Personal where codigoper = '" + Codigo.Text + "'").Substring(0, 5) == "ERROR")
					{
						Interaction.MsgBox("El registro personal no puede grabarse", MsgBoxStyle.Exclamation);
					}
				}
				tablaper = null;
				// End If

				// tabla cliente
				// If Cliente.CheckState = 1 Then
				// Dim tablacli = New dbCliente(datosEmpresa.strConxAdcom)
				// With tablacli
				// .CodigoCli = Codigo.Text
				// .TipoCli = Buscod.QueCodigo(txtTipoCliente.Text, TipCodSyscod(3))
				// .ZonaVentas = Buscod.QueCodigo(txtZonaVentas.Text, TipCodSyscod(4))
				// .VendedorInterno = codigoDirectorio(0)
				// .Operador = codigoDirectorio(5)
				// .Transportadora = codigoDirectorio(6)
				// .ZonaCobranza = Buscod.QueCodigo(txtZonaCobranzas.Text, TipCodSyscod(5))
				// .CobradorInterno = codigoDirectorio(1)
				// .PrecioVenta = Buscod.QueCodigo(txtPrecioVenta.Text, TipCodSyscod(6))
				// .FormaPago = RetornaNombre.RetornaCodigoPago(txtFormaPago.Text, datosEmpresa.strConxAdcom)
				// .PorcDescuento = CDec(Val(txtPorcDescuento.Text))
				// .LimiteCredito = CDec(Val(txtLimiteCredito.Text))
				// .DescuentoAso = CDec(Val(txtDescuentoAsociacion.Text))
				// .Observaciones = observacli.Text
				// .Contacto = txtContacto.Text
				// .Entregarmercaderia = entregarmer.Text
				// .CtbCobrar = Cuenta0.Text
				// .CtbCobrar2 = Cuenta4.Text
				// .PaisEmbarque = txtPaisEntrega.Text
				// .PuertoEmbarque = entregarmer.Text

				// If .Actualizar("select * from cliente where codigocli = '" & Codigo.Text & "' ").Substring(0, 5) = "ERROR" Then
				// MsgBox("El registro cliente no puede grabarse", MsgBoxStyle.Exclamation)
				// End If
				// End With
				// tablacli = Nothing
				// End If

				// 'PROVEEDOR
				// If Proveedor.Checked Then
				// Dim tablapro As New dbProveedor(datosEmpresa.strConxAdcom)
				// With tablapro
				// .CodigoProveedor = Codigo.Text
				// .FormaPago = RetornaNombre.RetornaCodigoPago(Lcod8.Text, datosEmpresa.strConxAdcom)
				// .PorceDescuent = CDec(Val(porcedescuentoprv.Text))
				// If incluyetransporte.Checked Then .IncluyeTranspo = True Else .IncluyeTranspo = False
				// .LimCreditoPrv = CDec(Val(limcreditoprv.Text))
				// .Producto1 = producto.Text
				// .Servicios1 = servicios.Text
				// .Observaciones = observacionesprv.Text
				// .CtbProveedor = Cuenta1.Text
				// .CtbProveedor2 = Cuenta5.Text

				// If chkEntregaDirecccion.Checked Then .EntregaNuestraOficina = True Else .EntregaNuestraOficina = False
				// If chkRetirarProveedor.Checked Then .RetirarMercaderia = True Else .RetirarMercaderia = False
				// If chkRetirarTransporte.Checked Then .EnvioATransporte = True Else .EnvioATransporte = False

				// If chkAereo.Checked Then .transAereo = True Else .transAereo = False
				// If chkMaritimo.Checked Then .transMaritimo = True Else .transMaritimo = False
				// If chkTerrestre.Checked Then .transTerrestre = True Else .transTerrestre = False


				// If .Actualizar("select * from proveedor where codigoproveedor = '" & Codigo.Text & "'").Substring(0, 5) = "ERROR" Then
				// MsgBox("El registro proveedor no puedo grabarse", MsgBoxStyle.Exclamation)
				// End If


				// End With
				// tablapro = Nothing
				// End If
				// 'tabla empleado


				// Dim tablacon As New dbContactos(datosEmpresa.strConxAdcom)

				// Dim ConxAdcom As New SqlClient.SqlConnection(datosEmpresa.strConxAdcom)
				// ConxAdcom.Open()
				// Dim Ssql As String = "delete from contactos where codcontacto='" & QUECODIGO & "' "
				// Dim comm As New SqlClient.SqlCommand(Ssql, ConxAdcom)
				// comm.ExecuteNonQuery()

				// If MallaCtco.RowCount > 1 Then
				// For i = 0 To MallaCtco.RowCount - 2
				// If Not (MallaCtco.Rows(i).Cells(1).Value Is Nothing) Then
				// tablacon = New dbContactos
				// With tablacon
				// .CodContacto = QUECODIGO
				// .Principal = CStr(MallaCtco.Rows(i).Cells(0).Value)
				// .Nombre = CStr(MallaCtco.Rows(i).Cells(1).Value)
				// .Cargo = CStr(MallaCtco.Rows(i).Cells(2).Value)
				// .Extensión = CStr(MallaCtco.Rows(i).Cells(3).Value)
				// .TelfCelular = CStr(MallaCtco.Rows(i).Cells(4).Value)
				// .TeléfonoDirecto = CStr(MallaCtco.Rows(i).Cells(5).Value)
				// If IsDate(MallaCtco.Rows(i).Cells(6).Value) Then .FechaNacimiento = CDate(MallaCtco.Rows(i).Cells(6).Value) Else .FechaNacimiento = CDate("01/01/1900")
				// .Actividades = CStr(MallaCtco.Rows(i).Cells(7).Value)
				// .Preferencias = CStr(MallaCtco.Rows(i).Cells(8).Value)
				// .Observaciones = CStr(MallaCtco.Rows(i).Cells(9).Value)
				// If .Actualizar("select * from contactos where codcontacto='" & Codigo.Text & "' and nombre = '" + .Nombre + "' ").Substring(0, 5) = "ERROR" Then
				// MsgBox("El registro contactos no se guardó", MsgBoxStyle.Exclamation)
				// End If
				// End With
				// End If
				// Next
				// End If

				// tablacon = Nothing


				// Ssql = "delete from identificacionalias where codigoempresa='" & QUECODIGO & "' "
				// comm = New SqlClient.SqlCommand(Ssql, ConxAdcom)
				// comm.ExecuteNonQuery()

				// Dim tablaAlias As New dbIdentificacionAlias
				// If MallaAlias.RowCount > 1 Then
				// For i = 0 To MallaAlias.RowCount - 2
				// If Not (MallaAlias.Rows(i).Cells(1).Value Is Nothing) Then
				// tablaAlias = New dbIdentificacionAlias(datosEmpresa.strConxAdcom)
				// With tablaAlias
				// .CodigoEmpresa = QUECODIGO
				// .NombreAlias = CStr(MallaAlias.Rows(i).Cells(0).Value)
				// .DirecciónAlterna = CStr(MallaAlias.Rows(i).Cells(1).Value)
				// .Teléfono_1 = CStr(MallaAlias.Rows(i).Cells(2).Value)
				// .Teléfono_2 = CStr(MallaAlias.Rows(i).Cells(3).Value)
				// .Id_Sri = CStr(MallaAlias.Rows(i).Cells(4).Value)
				// .Observaciones = CStr(MallaAlias.Rows(i).Cells(5).Value)
				// If .Actualizar("select * from IdentificacionAlias  where codigoEmpresa = '" & Codigo.Text & "' and nombreAlias = '" + .NombreAlias + "' ").Substring(0, 5) = "ERROR" Then
				// MsgBox("El registro alias no se grabó", MsgBoxStyle.Exclamation)
				// Exit Sub
				// End If
				// End With
				// End If
				// Next
				// End If
				// tablaAlias = Nothing


				// Ssql = "delete from rolfam where CodEmpleado='" & QUECODIGO & "' "
				// comm = New SqlClient.SqlCommand(Ssql, ConxAdcom)
				// comm.ExecuteNonQuery()

				// Dim tablaFam As New dbFamilia(datosEmpresa.strConxAdcom)
				// For Each rr As DataGridViewRow In malla.Rows
				// tablaFam = New dbFamilia(datosEmpresa.strConxAdcom)
				// If Not (rr.Cells(1).Value Is Nothing) Then
				// If rr.Cells(1).Value.ToString() <> "" Then
				// With tablaFam
				// .CodEmpleado = QUECODIGO
				// .CEDULA = CStr(rr.Cells(1).Value)
				// .Nombres = CStr(rr.Cells(2).Value)
				// .Parentesco = CStr(rr.Cells(3).Value)
				// If IsDate(rr.Cells(4).Value) Then .FechaNacimiento = CDate(rr.Cells(4).Value) Else .FechaNacimiento = CDate("01/01/1900")
				// .Sexo = CStr(rr.Cells(5).Value)
				// .EstadoCivil = CStr(rr.Cells(6).Value)
				// .Direccion = CStr(rr.Cells(7).Value)
				// .Teléfono_1 = CStr(rr.Cells(8).Value)
				// .Teléfono_2 = CStr(rr.Cells(9).Value)
				// .Ocupacion = CStr(rr.Cells(10).Value)
				// .EsDependiente = CStr(rr.Cells(11).Value)
				// .EsMinusvalido = CStr(rr.Cells(12).Value)
				// If .Actualizar("select * from ROLFAM where codeMPLEADO = '" & Codigo.Text & "' AND CEDULA = '" + tablaFam.CEDULA + "' ").Substring(0, 5) = "ERROR" Then
				// MsgBox("El registro de familiares no se grabó", MsgBoxStyle.Exclamation)
				// Exit Sub
				// End If
				// End With
				// End If
				// End If
				// Next

				// 'If mallaDatos.RowCount > 0 And Emp.rol = True Then GuardarAdicionales()
				// 'If mallaConceptos.RowCount > 0 And Emp.rol = True Then GuardarConceptos()

				accion = "";
				LimpiezaFormulario();

				PonerBotonesFormulario();
				if (IniNvo == true)
					Close();
				Buscod = null;
				CerrarRegistro();
				accion = "";
			}
			catch (Exception exx)
			{
				MessageBox.Show("Se produjo una excepción al grabar " + exx.Message);
			}

		}
		private bool validacionDatos()
		{
			bool resp = false;
			if (string.IsNullOrEmpty(Codigo.Text))
			{
				Interaction.MsgBox("Digite un Código Válido", MsgBoxStyle.Critical);
				return resp;
			}
			if (datosEmpresa.LongCodDirectorio > 0 & Codigo.Text.Length != datosEmpresa.LongCodDirectorio)
			{
				Interaction.MsgBox("El código debe tener la longitud correcta (" + datosEmpresa.LongCodDirectorio.ToString() + ")", MsgBoxStyle.Critical);
				return resp;
			}
			if (string.IsNullOrEmpty(TipoIdent.Text))
			{
				Interaction.MsgBox("Falta el tipo de identificación", MsgBoxStyle.Critical);
				return resp;
			}
			if (string.IsNullOrEmpty(TxtCedulaRuc.Text))
			{
				Interaction.MsgBox("Debe ingresar el RUC o CI", MsgBoxStyle.Information);
				TxtCedulaRuc.Focus();
				return resp;
			}

			if (ValidaNumeroId() == false)
			{
				Interaction.MsgBox("El numero del documento de identificacion está errado ", MsgBoxStyle.Critical);
				TxtCedulaRuc.Focus();
				return resp;
			}
			if (txtHistoriaclinica.Text.Length == 0)
				txtHistoriaclinica.Text = Codigo.Text;

			if (string.IsNullOrEmpty(TxtNombres.Text))
			{
				Interaction.MsgBox("Debe ingresar el nombre", MsgBoxStyle.Information);
				TxtNombres.Focus();
				return resp;
			}
			// If Natural.Checked = True Then
			if (string.IsNullOrEmpty(Apellidos.Text))
			{
				Interaction.MsgBox("Debe ingresar Los apellidos", MsgBoxStyle.Information);
				TxtNombres.Focus();
				return resp;
			}
			// End If
			if (string.IsNullOrEmpty(impresion.Text))
			{
				impresion.Focus();
				Interaction.MsgBox("Debe ingresar el nombre de impresión", MsgBoxStyle.Information);
				return resp;
			}

			string errado = "";
			// If IsDBNull(cmbCantonDomicilio.SelectedValue) Then errado += " ; Canton de domicilio"
			// If IsDBNull(cmbCargoRol.SelectedValue) Then errado += " ;  Cargo del rol "
			// If IsDBNull(cmbCentroCostoRol.SelectedValue) Then errado += " ;  Centro de costo del rol "
			// If IsDBNull(cmbCiudadDomicilio.SelectedValue) Then errado += " ;  Ciudad del domicilio "
			// If IsDBNull(cmbCiudadNace.SelectedValue) Then errado += " ;  Ciudad de nacimiento "
			// If IsDBNull(cmbDepartamentoRol.SelectedValue) Then errado += " ;  Departamento en rol "
			// If IsDBNull(cmbEspecialidad.SelectedValue) Then errado += " ;  Especialidad "
			// If IsDBNull(cmbEspecialidad2.SelectedValue) Then errado += " ;  Especialidad 2 "
			// If IsDBNull(cmbEstadoCivil.SelectedValue) Then errado += " ;  Estado civil "
			// If IsDBNull(cmbModuloRol.SelectedValue) Then errado += " ;  Módulo del rol "
			// If IsDBNull(cmbNacionalidadPersonal.SelectedValue) Then errado += " ;  Nacionalidad "
			// If IsDBNull(cmbPaisDomicilio.SelectedValue) Then errado += " ;  País de domicilio "
			// If IsDBNull(cmbPaisNace.SelectedValue) Then errado += " ;  País de nacimiento  "
			// If IsDBNull(cmbParroquiaDomicilio.SelectedValue) Then errado += " ;  Parroquia de domicilio "
			// If IsDBNull(cmbProfesion.SelectedValue) Then errado += " ;  Profesión "
			// If IsDBNull(cmbProvinciaDomicilio.SelectedValue) Then errado += " ;  Provincia de domicilio "
			// If IsDBNull(cmbProvinciaNace.SelectedValue) Then errado += " ;  Provincia d nacimiento "
			// If IsDBNull(cmbRegionDomicilio.SelectedValue) Then errado += " ;  Región de domicilio "
			// If IsDBNull(cmbRegionNace.SelectedValue) Then errado += " ;  Región de nacimiento "
			// If IsDBNull(cmbSeccionRol.SelectedValue) Then errado += " ;  Sección del rol "
			// If IsDBNull(cmbSucursalRol.SelectedValue) Then errado += " ;  Sucursal del rol "
			// If IsDBNull(cmbTipoSangre.SelectedValue) Then errado += " ;  Tipo de sangre "

			if (errado.Trim().Length > 0)
			{
				MessageBox.Show("Errores de digitación encontrados : " + Constants.vbCr + errado);
				return resp;
			}

			return true;
		}
		// Private Sub CargarAdicionales(ByVal QueCodigo As String)
		// Dim Adi As New AdcAdicEmp(datosEmpresa.strConxAdcom)
		// Dim i As Int32
		// If mallaDatos.RowCount < 1 Then Return
		// For i = 0 To mallaDatos.RowCount - 1
		// If Not (mallaDatos.Rows(i).HeaderCell.Value Is Nothing) Then
		// Adi = AdcAdicEmp.Buscar("codEmpleado ='" & QueCodigo & "' and nomadicional = '" & mallaDatos.Rows(i).HeaderCell.Value.ToString & "' ")
		// If Not (Adi Is Nothing) Then mallaDatos.Rows(i).Cells(0).Value = Adi.ValorAdicional
		// End If
		// Next i
		// End Sub
		// Private Sub CargarConceptos(ByVal QueCodigo As String)
		// Dim Adi As New AdcEmplCon(datosEmpresa.strConxAdcom)
		// Dim retn As New EmpNomR.AdcNomb
		// Dim i As Int32
		// Try
		// If IsDBNull(mallaConceptos.Rows(0).HeaderCell.Value) Then Return
		// For i = 0 To mallaConceptos.RowCount - 1
		// If Not IsDBNull(mallaConceptos.Rows(i).HeaderCell.Value) And Not IsNothing(mallaConceptos.Rows(i).HeaderCell.Value) Then
		// Adi = AdcEmplCon.Buscar("idEmpleado ='" & QueCodigo & "' and idConcepto = " & retn.RetornaCodigoConceptoRol(mallaConceptos.Rows(i).HeaderCell.Value.ToString, datosEmpresa.strConxAdcom))
		// If Not Adi Is Nothing Then
		// mallaConceptos.Rows(i).Cells(0).Value = "SI"
		// Else
		// mallaConceptos.Rows(i).Cells(0).Value = "NO"
		// End If
		// End If
		// Next i
		// Catch
		// End Try

		// End Sub

		// Private Sub GuardarAdicionales()
		// Dim Adi As New AdcAdicEmp(datosEmpresa.strConxAdcom)
		// Dim retn As New EmpNomR.AdcNomb
		// Dim i As Int32
		// For i = 0 To mallaDatos.RowCount - 1
		// If Not (mallaDatos.Rows(i).HeaderCell.Value Is Nothing) Then
		// Adi.CodEmpleado = QUECODIGO
		// Adi.CodAdicional = retn.RetornaCodigoSyscod("adicionalEmpleado", mallaDatos.Rows(i).HeaderCell.Value.ToString, datosEmpresa.strConxSyscod)
		// Adi.NomAdicional = mallaDatos.Rows(i).HeaderCell.Value.ToString
		// Adi.ValorAdicional = mallaDatos.Rows(i).Cells(0).Value.ToString()
		// Adi.Actualizar()
		// End If
		// Next i
		// End Sub

		// Private Sub GuardarConceptos()
		// Dim Adi As New AdcEmplCon(datosEmpresa.strConxAdcom)
		// Dim retn As New EmpNomR.AdcNomb
		// Dim i As Int32
		// Try
		// For i = 0 To mallaConceptos.RowCount - 1
		// If Not (mallaConceptos.Rows(i).HeaderCell.Value Is Nothing) Then
		// Adi.idConcepto = CInt(retn.RetornaCodigoConceptoRol(mallaConceptos.Rows(i).HeaderCell.Value.ToString, datosEmpresa.strConxAdcom))
		// Adi.IdEmpleado = Codigo.Text
		// Adi.UsuarioAsigna = datosEmpresa.usr
		// Adi.FechaAsignacion = Now
		// If Not mallaConceptos.Rows(i).Cells(0).Value Is Nothing Then
		// If mallaConceptos.Rows(i).Cells(0).Value.ToString() = "SI" Then
		// Adi.Actualizar()
		// Else
		// Adi.Borrar()
		// End If
		// End If
		// End If
		// Next i
		// Catch EX As Exception
		// MsgBox(EX.Message)
		// End Try
		// End Sub

		// Private Sub hombre_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles hombre.CheckedChanged
		// If sender.Checked Then
		// If hombre.Checked = True Then
		// Sexo = "H"
		// Else
		// hombre.Checked = False
		// Sexo = "M"l
		// End If
		// End If
		// End Sub

		private void libretamilitar_KeyPress(ref int KeyAscii)
		{
			KeyAscii = DaaxLibDat.SoloNumeros(ref KeyAscii);
		}

		private void limitecredito_KeyPress(object sender, KeyPressEventArgs e)
		{
			int KeyAscii = Strings.Asc(e.KeyChar);
			KeyAscii = DaaxLibDat.SoloNumeros(ref KeyAscii);
			e.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0)
			{
				e.Handled = true;
			}
		}

		private void nivelrol_KeyPress(object sender, KeyPressEventArgs e)
		{
			int KeyAscii = Strings.Asc(e.KeyChar);
			KeyAscii = DaaxLibDat.SoloNumeros(ref KeyAscii);
			e.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0)
			{
				e.Handled = true;
			}
		}

		private void btnNuevo_Click(object sender, EventArgs e)
		{
			CrearNuevo();
		}
		private void CrearNuevo()
		{
			LimpiezaFormulario();
			QUECODIGO = "";
			// Juridica.Checked = True
			// PonerDatosTipo()
			EsNuevo = 1;
			PonerBotonesFormulario();
			accion = "guardar";
			ChequearAutorizacion("T");
			// btnCargarCapacitacion.Visible = False
			Codigo.Focus();
			CambioAdicionales = false;
		}

		private void Nroctabancorol_KeyPress(object sender, KeyPressEventArgs e)
		{
			int KeyAscii = Strings.Asc(e.KeyChar);
			KeyAscii = DaaxLibDat.SoloNumeros(ref KeyAscii);
			e.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0)
			{
				e.Handled = true;
			}
		}

		private void Porcdescuentocli_KeyPress(object sender, KeyPressEventArgs e)
		{
			int KeyAscii = Strings.Asc(e.KeyChar);
			KeyAscii = DaaxLibDat.SoloNumeros(ref KeyAscii);
			e.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0)
			{
				e.Handled = true;
			}
		}

		private void porcedescuentoprv_KeyPress(object sender, KeyPressEventArgs e)
		{
			int KeyAscii = Strings.Asc(e.KeyChar);
			KeyAscii = DaaxLibDat.SoloNumeros(ref KeyAscii);
			e.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0)
			{
				e.Handled = true;
			}
		}

		// Private Sub Proveedor_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs)
		// ' PonerDatosTipo()
		// Try
		// If Proveedor.Checked Then
		// DatosDirectorio.TabPages.Item("tabProveedor").Enabled = True
		// DatosDirectorio.TabPages.Item("tabProveedor").Visible = True
		// Else : DatosDirectorio.TabPages.Item("tabProveedor").Enabled = False
		// DatosDirectorio.TabPages.Item("tabProveedor").Visible = False
		// End If
		// Catch
		// End Try
		// End Sub

		private void DEEPPCTE_Load(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(Codigo.Text))
			{
				EsNuevo = 0;
				PonerBotonesFormulario();
			}
			Module1.Mainn();
			Valores.iniciaValores(TipCodSyscod);
			// If datosEmpresa.sistema <> "DAX" And datosEmpresa.sistema <> "ERP" Then btnCargarCapacitacion.Visible = False
			malla.Columns[0].Visible = false;
			Operacion[0] = "";
			Operacion[1] = " CREANDO NUEVO REGISTRO ";
			Operacion[2] = " MODIFICANDO REGISTRO EXISTENTE ";

			// Juridica.Checked = True
			DatosDirectorio.SelectedIndex = 0;
			// mallaDatos.ColumnCount = 1
			// mallaDatos.RowCount = 15
			// mallaDatos.RowHeadersWidth = 140
			// mallaDatos.Columns(0).ReadOnly = True
			// mallaDatos.Columns(0).Width = 130
			// mallaConceptos.ColumnCount = 1
			// mallaConceptos.RowCount = 15
			// mallaConceptos.RowHeadersWidth = 150
			// mallaConceptos.Columns(0).ReadOnly = True
			// mallaConceptos.Columns(0).Width = 30

			saltar = false;
			// If Emp.rol = False Then
			// TabDatosEmpleado.Visible = False
			// Else
			// TabDatosEmpleado.Visible = True
			// cargarMallaDatos()
			// cargarMallaConceptos()
			// cargarNombreGrupos()
			// End If
			PonerDatosTipo();
			ControlarAutorizaciones();
			cargarAutorizacionOpcion();
			LlenarCombos();
			if (IniNvo)
				CrearNuevo();
			if (datosEmpresa.Emp_PathImagenes.Length > 0)
				ImgDirectorio = datosEmpresa.Emp_PathImagenes + ImgDirectorio;
			else
				ImgDirectorio = "";

		}

		private void ControlarAutorizaciones()
		{
			if (datosEmpresa.usr.ToUpper == "ADMINISTRADOR")
				return;
			var autorizaciones = new mntUsrs.autorizaUserDirectorio(datosEmpresa.usr, datosEmpresa.strConxSyscod, datosEmpresa.codEmpresa.ToString());
			if (autorizaciones.autUsrIdentificacion.existe == false)
				return;
			if (autorizaciones.autUsrCliente.visible == false)
				tabCliente.Parent = null;
			// If (autorizaciones.autUsrAlias.visible = False) Then tabAlias.Parent = Nothing
			if (autorizaciones.autUsrContactos.visible == false)
				tabContactos.Parent = null;
			// If (autorizaciones.autUsrDatoPersonal.visible = False) Then tabDatosPer.Parent = Nothing
			// If (autorizaciones.autUsrEmpleado.visible = False) Then tabEmpleado.Parent = Nothing
			if (autorizaciones.autUsrFamiliares.visible == false)
				tabFamiliares.Parent = null;
			// If (autorizaciones.autUsrProveedor.visible = False) Then tabProveedor.Parent = Nothing

			if (autorizaciones.autUsrCliente.visible == false)
				tabCliente.Parent = null;




		}
		private void cargarAutorizacionOpcion()
		{
			var opcUser = new mntUsrs.autorizaUserMenu(claveOpcion, datosEmpresa.usr, datosEmpresa.strConxSyscod, datosEmpresa.codEmpresa.ToString(), datosEmpresa.sistema);
			autorizaOpcion = opcUser.autUsrMenuPrincipal;
			opcUser = null;
			if (autorizaOpcion.crearAbierto | autorizaOpcion.existe == false)
				return;
			btnNuevo.Enabled = autorizaOpcion.crearAbierto;
			btnAbrir.Enabled = autorizaOpcion.visible;
			btnGuardar.Visible = autorizaOpcion.crearAbierto | autorizaOpcion.modificar;
			btnEliminar.Visible = autorizaOpcion.eliminar | autorizaOpcion.crearAbierto;

		}
		private void CargarRegistros()
		{
			try
			{

				propio = true;
				QUECODIGO = Codigo.Text;
				if (leerIdentificacion() == false)
				{
					EsNuevo = 1;
				}
				else
				{
					Codigo.ReadOnly = true;
					if (tipoper == "N")
						leerPersonal();
					// leerContactos()
					leerFamiliares();
					EsNuevo = 2;
				}
				// If Emp.rol = True Then CargarAdicionales(QUECODIGO) : CargarConceptos(QUECODIGO)
				PonerDatosTipo();
				CargaFoto();
				Cambio = false;
				// '''''''''''''''''''''''''''''''''ChequearAutorizacion(Emp.)
				PonerBotonesFormulario();
			}
			// btnCargarCapacitacion.Visible = Emp.rol
			catch (Exception ee)
			{
				Interaction.MsgBox("excepción cargaDir: " + ee.Message);
			}
			CambioAdicionales = false;
		}

		// Private Sub Juridica_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
		// If Juridica.Checked Then
		// Natural_CheckedChanged(Natural, New System.EventArgs())
		// End If
		// End Sub

		private void Natural_CheckedChanged(object sender, EventArgs e)
		{
			if (saltar)
				return;
			// On Error Resume Next
			// If Juridica.Checked = True Then
			// Banco.Enabled = True
			// Empleado.Enabled = False
			// tipoper = "J"
			// asociadoa.Visible = False
			// Asociacion.Text = "Asociación"
			// Label34.Visible = False
			// Apellidos.Visible = False
			// Apellidos.Enabled = False
			// Apellidos.Text = ""
			// Else
			// Banco.Enabled = False
			// Empleado.Enabled = True
			Label34.Visible = true;
			Apellidos.Visible = true;
			Apellidos.Enabled = true;
			tipoper = "N";
			// Natural.Checked = True
			// Asociacion.Text = "Asociado"
			// If Asociacion.CheckState = System.Windows.Forms.CheckState.Checked Then
			// asociadoa.Visible = True
			// Else
			// asociadoa.Visible = False
			// End If
			// End If
			PonerDatosTipo();
		}

		private void btnSalir_Click(object sender, EventArgs e)
		{
			if (Interaction.MsgBox("Esta seguro que desea salir ", MsgBoxStyle.YesNo) == MsgBoxResult.Yes)
			{
				Close();
			}
		}

		private void generarTablaAdicionales()
		{
			var conn = new SqlConnection(datosEmpresa.strConxAdcom);
			bool noExiste = false;
			conn.Open();
			string ssql = "set dateformat dmy; exec daxAdicEmp ";
			var rr = new SqlCommand(ssql, conn);
			try
			{
				rr.ExecuteNonQuery();
			}
			catch (Exception ee)
			{
				Interaction.MsgBox("excepción AdicEmp : " + ee.Message);
			}
			try
			{
				SqlDataReader rs;
				ssql = "Select top 1 * from DaxAdiTrabj ";
				var comm = new SqlCommand(ssql, conn);
				rs = comm.ExecuteReader();

				if (rs.Read() == false)
					noExiste = false;
			}
			catch
			{
				noExiste = true;
			}
			if (noExiste)
			{
				ssql = "CREATE TABLE [dbo].[DaxAdiTrabj]([codEmpleado] [varchar](20) NOT NULL ) ON [PRIMARY]";
				rr = new SqlCommand(ssql, conn);
				rr.ExecuteNonQuery();
			}
			conn.Close();
			conn.Dispose();
			rr.Dispose();
		}

		private void CargaFoto()
		{
			if (Operators.CompareString(CodigoFoto, "", false) > 0)
			{
				string resp = FileSystem.Dir(ImgDirectorio + CodigoFoto);
				if (Strings.Len(resp) > 0)
				{
					foto.Image = System.Drawing.Image.FromFile(ImgDirectorio + CodigoFoto);
					foto.SizeMode = PictureBoxSizeMode.Zoom;
				}
				else
				{
					Interaction.MsgBox("La Fotografía asignada a este contacto no existe " + Constants.vbCr + Constants.vbCr + ImgDirectorio + CodigoFoto, MsgBoxStyle.Information);
				}
			}
		}

		// Private Sub Text1_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles Text1.KeyDown
		// Dim KeyCode As Short = eventArgs.KeyCode
		// Dim Shift As Short = eventArgs.KeyData \ &H10000
		// Dim prog As New Busctactb.BuscaCta
		// Dim Nombre As String = ""
		// If KeyCode = System.Windows.Forms.Keys.F2 Then
		// Text1.Text = prog.BuscaCtaCtb(Nombre, "S")
		// prog = Nothing
		// 'Label4 = NombreCuentaContable(Text1)
		// End If
		// End Sub
		private void PonerBotonesFormulario()
		{
			btnNuevo.Visible = EsNuevo == 0;
			btnAbrir.Visible = EsNuevo == 0;
			btnCerrar.Visible = EsNuevo > 0;
			btnGuardar.Visible = EsNuevo == 2 | EsNuevo == 1;
			btnEliminar.Visible = EsNuevo == 2 | EsNuevo == 1;
			Text = "ADCOM - Mantenimiento DIRECTORIO GENERAL -  " + Operacion[EsNuevo];
		}

		private void CerrarRegistro()
		{
			LimpiezaFormulario();
			EsNuevo = 0;
			PonerBotonesFormulario();
		}

		// Private Sub TxtData0_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNomCanton.KeyPress
		// Dim KeyAscii As int32 = Asc(e.KeyChar)
		// e.KeyChar = Chr(KeyAscii)
		// If KeyAscii = 0 Then
		// e.Handled = True
		// End If
		// End Sub

		private void TxtData1_KeyPress(object sender, KeyPressEventArgs e)
		{
			int KeyAscii = Strings.Asc(e.KeyChar);
			e.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0)
			{
				e.Handled = true;
			}
		}

		private void TxtData2_KeyPress(object sender, KeyPressEventArgs e)
		{
			int KeyAscii = Strings.Asc(e.KeyChar);
			e.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0)
			{
				e.Handled = true;
			}
		}

		// Private Sub TxtData7_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNomParroquia.KeyPress
		// Dim KeyAscii As int32 = Asc(e.KeyChar)
		// e.KeyChar = Chr(KeyAscii)
		// If KeyAscii = 0 Then
		// e.Handled = True
		// End If
		// End Sub

		private void TxtData8_KeyPress(object sender, KeyPressEventArgs e)
		{
			int KeyAscii = Strings.Asc(e.KeyChar);
			e.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0)
			{
				e.Handled = true;
			}
		}

		private void TxtData9_KeyPress(object sender, KeyPressEventArgs e)
		{
			int KeyAscii = Strings.Asc(e.KeyChar);
			e.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0)
			{
				e.Handled = true;
			}
		}

		private void TxtData31_KeyPress(object sender, KeyPressEventArgs e)
		{
			int KeyAscii = Strings.Asc(e.KeyChar);
			e.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0)
			{
				e.Handled = true;
			}
		}

		private void TxtData32_KeyPress(object sender, KeyPressEventArgs e)
		{
			int KeyAscii = Strings.Asc(e.KeyChar);
			e.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0)
			{
				e.Handled = true;
			}
		}

		private void TxtData3_KeyPress(object sender, KeyPressEventArgs e)
		{
			int KeyAscii = Strings.Asc(e.KeyChar);
			KeyAscii = DaaxLibDat.SoloNumeros(ref KeyAscii);
		}

		private void TxtData4_KeyPress(object sender, KeyPressEventArgs e)
		{
			int KeyAscii = Strings.Asc(e.KeyChar);
			KeyAscii = DaaxLibDat.SoloNumeros(ref KeyAscii);
		}

		private void TxtData5_KeyPress(object sender, KeyPressEventArgs e)
		{
			int KeyAscii = Strings.Asc(e.KeyChar);
			KeyAscii = DaaxLibDat.SoloNumeros(ref KeyAscii);
		}

		private void TxtData6_KeyPress(object sender, KeyPressEventArgs e)
		{
			int KeyAscii = Strings.Asc(e.KeyChar);
			KeyAscii = DaaxLibDat.SoloNumeros(ref KeyAscii);
		}

		private void valorsueldo_KeyPress(object sender, KeyPressEventArgs e)
		{
			int KeyAscii = Strings.Asc(e.KeyChar);
			KeyAscii = DaaxLibDat.SoloNumeros(ref KeyAscii);
			e.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0)
			{
				e.Handled = true;
			}
		}
		private void BuscarProximoCodigo()
		{
			var ConxAdcom = new SqlConnection(datosEmpresa.strConxAdcom);
			SqlDataReader rs;
			var cod = default(double);
			string C, a, b;
			int i;
			a = "";
			C = "";
			b = "";
			string Ssql = "select top 1 codigo from identificacion order by substring ('0000000000000000000000000' + codigo,len(Codigo)+1 ,25) desc";
			var comm = new SqlCommand(Ssql, ConxAdcom);
			ConxAdcom.Open();
			rs = comm.ExecuteReader();
			if (rs.Read() == false)
			{
				Codigo.Text = "1";
			}
			else
			{
				a = Conversions.ToString(rs["codigo"]);
				if (Information.IsNumeric(a))
				{
					cod = Conversions.ToDouble(a);
				}
				else
				{
					var loopTo = (int)(short)Strings.Len(a);
					for (i = 1; i <= loopTo; i++)
					{
						b = Strings.Mid(a, i, 1);
						if (Operators.CompareString(b, "0", false) < 0 | Operators.CompareString(b, "9", false) > 0)
							C = C + b;
						else
						{
							cod = (float)Conversion.Val(Strings.Mid(a, i));
							i = 9999;
						}
					}
				}
			}
			Codigo.Text = C + Strings.Trim(Conversion.Str(cod + 1d));
			ConxAdcom.Close();
			ConxAdcom = null;
		}

		private string ProximoNumeroHistoriaClinica()
		{
			var ConxAdcomNet = new SqlConnection(datosEmpresa.strConxAdcom);
			string CodigoNvo = "";
			ConxAdcomNet.Open();
			SqlDataReader RS;
			var Comm = new SqlCommand("select max(HistoriaClinica) as HistClinica from identificacion", ConxAdcomNet);
			RS = Comm.ExecuteReader();
			if (RS.Read())
				CodigoNvo = RS["HistClinica"].ToString();
			RS.Close();
			RS = null;
			Comm.Dispose();
			ConxAdcomNet.Dispose();
			if (string.IsNullOrEmpty(CodigoNvo))
			{
				CodigoNvo = "1";
				return CodigoNvo;
				return default;
			}
			if (Information.IsNumeric(CodigoNvo))
			{
				CodigoNvo = (Conversion.Val(CodigoNvo) + 1d).ToString();
				return CodigoNvo;
				return default;
			}

			var cod = default(float);
			string C = "";
			string b;
			short i;
			for (i = (short)Strings.Len(CodigoNvo); i >= 0; i += -1)
			{
				b = Conversions.ToString(CodigoNvo[i]);
				if (Information.IsNumeric(b))
					C = b + C;
				else
				{
					cod = Conversions.ToSingle(Strings.Mid(CodigoNvo, 1, i));
					break;
				}
			}
			CodigoNvo = cod.ToString();
			if (Operators.CompareString(C, "", false) > 0)
				CodigoNvo = CodigoNvo + (Conversion.Val(C) + 1d);
			return CodigoNvo;
		}


		private void LimpiezaFormulario()
		{
			Codigo.ReadOnly = false;
			Limpiar(this);
			// LimpiarCheck()
			// limpiarGrid(Grid)
			// limpiarGrid(MallaAlias)
			limpiarGrid(MallaCtco);
			limpiarGrid(malla);
			foto.Image = foto.InitialImage;
			foto.SizeMode = PictureBoxSizeMode.CenterImage;
			// If Emp.rol = True Then limpiarGrid(mallaDatos) : cargarMallaDatos() : limpiarGrid(mallaConceptos) : cargarMallaConceptos()
			CambioAdicionales = false;
		}

		private void Limpiar(Form oBJ)
		{
			string a;
			foreach (Control Control1 in oBJ.Controls)
			{
				if (Control1.Controls.Count > 0)
					Limpiar(Control1);
				a = Information.TypeName(Control1);
				if (a == "TextBox")
					Control1.Text = "";
				if (a == "Label" & Control1.BackColor == System.Drawing.Color.White)
					Control1.Text = "";
				if (a == "ComboBox")
					((ComboBox)Control1).SelectedValue = "";
				if (a == "MaskedTextBox")
					Control1.Text = "  /  /";
				chkObligaContabilidad.Checked = false;
				chkRegimenMicroempresas.Checked = false;
				chkRise.Checked = false;
				ExoneradoIva.Checked = false;
				txtContribuyenteEspecial.Text = "";
			}
		}
		private void Limpiar(Control oBJ)
		{
			string a;
			foreach (Control Control1 in oBJ.Controls)
			{
				if (Control1.Controls.Count > 0)
					Limpiar(Control1);
				a = Information.TypeName(Control1);
				if (a == "TextBox")
					Control1.Text = "";
				if (a == "Label" & Control1.BackColor == System.Drawing.Color.White)
					Control1.Text = "";
				if (a == "ComboBox")
					((ComboBox)Control1).SelectedValue = "";
				if (a == "MaskedTextBox")
					Control1.Text = "  /  /";
			}
		}

		// Private Sub LimpiarCheck()
		// On Error Resume Next
		// Cliente.Checked = False
		// Proveedor.Checked = False
		// EsVendedor.Checked = False
		// Banco.Checked = False
		// Empleado.Checked = False
		// Directa.Checked = False
		// Asociacion.Checked = False
		// End Sub
		private void limpiarGrid(DataGridView grid)
		{
			for (int i = grid.RowCount - 2; i >= 0; i -= 1)
			{
				if (i <= grid.Rows.Count)
					grid.Rows.RemoveAt(i);
			}
		}

		private bool ValidaNumeroId()
		{
			bool ValidaNumeroIdRet = default;
			string j = "";
			string Persona = "P";
			ValidaNumeroIdRet = false;
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
			if (j == "O")
			{
				ValidaNumeroIdRet = true;
				return ValidaNumeroIdRet;
			}
			// If Juridica.Checked Then Persona = "E"
			if (j == "P")
			{
				ValidaNumeroIdRet = true;
			}
			else if (j == "F" & TxtCedulaRuc.Text == "9999999999999")
			{
				ValidaNumeroIdRet = true;
			}
			else
			{
				var prog = new valIdcedru.valcedruc();
				ValidaNumeroIdRet = prog.valCr(TxtCedulaRuc.Text, j, Persona);
			}

			return ValidaNumeroIdRet;
		}

		private string ArreglaId(ref string Ident)
		{
			string ArreglaIdRet = default;
			if (Ident is DBNull)
			{
				return "1";
				return ArreglaIdRet;
			}
			ArreglaIdRet = Ident;
			switch (Ident ?? "")
			{
				case "O":
					{
						ArreglaIdRet = "0";
						break;
					}
				case "R":
					{
						ArreglaIdRet = "1";
						break;
					}
				case "C":
					{
						ArreglaIdRet = "2";
						break;
					}
				case "P":
					{
						ArreglaIdRet = "3";
						break;
					}
				case "F":
					{
						ArreglaIdRet = "4";
						break;
					}
			}

			return ArreglaIdRet;
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

		private void btnAbrir_Click(object sender, EventArgs e)
		{
			BuscarRegistro();
			accion = "actualizar";
			// CargarEmbarque()
		}
		private string[] CbuscaDir(string tipo, int index)
		{
			var prog = new BuscaClien();
			string cod = "";
			string nom = "";
			var datos = new string[3];
			string argConAlias = "";
			string argConNuevo = "";
			cod = prog.IniBuscaCliOPro(ref tipo, ref nom, ref argConAlias, ref argConNuevo);
			prog.Close();
			prog.Dispose();
			datos[0] = cod;
			datos[1] = nom;
			return datos;
		}
		private void buscaVendedor_Click(object sender, EventArgs e)
		{
			var dat = new string[3];
			dat = CbuscaDir("V", 0);
			txtVendedor.Text = dat[1];
			codigoDirectorio[0] = dat[0];
		}

		private void CbuscaDir1_Click(object sender, EventArgs e)
		{
			var dat = new string[3];
			dat = CbuscaDir("T", 0);
			txtCobrador.Text = dat[1];
			codigoDirectorio[1] = dat[0];
		}

		// Private Sub CbuscaDir2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
		// Dim dat(2) As String
		// dat = CbuscaDir("F", 0)
		// txtNomBanco.Text = dat(1)
		// codigoDirectorio(2) = dat(0)
		// End Sub

		private void CbuscaDir3_Click(object sender, EventArgs e)
		{
			var dat = new string[3];
			dat = CbuscaDir("F", 0);
			LDir3.Text = dat[1];
			codigoDirectorio[3] = dat[0];
		}

		// Private Sub Cliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
		// PonerDatosTipo()
		// End Sub

		// Private Sub Proveedor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
		// PonerDatosTipo()
		// End Sub

		// Private Sub Banco_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
		// PonerDatosTipo()
		// End Sub

		// Private Sub Empleado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
		// PonerDatosTipo()
		// End Sub

		// Private Sub EsVendedor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
		// PonerDatosTipo()
		// End Sub

		// Private Sub Directa_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
		// PonerDatosTipo()
		// End Sub

		// Private Sub Asociacion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
		// PonerDatosTipo()
		// End Sub

		// Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
		// CerrarRegistro()
		// accion = ""
		// End Sub

		#region Embarque

		// Private Sub cargarGrid()
		// With Grid
		// .Columns.Add("CODIGO", "CODIGO")
		// '.Columns(0).ReadOnly = True
		// .Columns.Add("CONTACTO", "CONTACTO")
		// llenarCombos("Embarque", "EMBARQUE", "TIPO EMBARQUE")
		// llenarCombos("TipoTransporte", "EQUIPO", "EQUIPO")
		// llenarCombos("Condiciones pago", "CONDICIONES", "CONDICIONES")
		// llenarCombos("Terminos Venta", "TERMINOS", "TERMINOS")
		// llenarCombos("Puertos", "PUERTOS", "PUERTOS")
		// .Columns.Add("COSTOFLETE", "COSTO FLETE")
		// End With
		// End Sub
		// Private Sub llenarCombos(ByVal referncia As String, ByVal NombreCol As String, ByVal TituloCol As String)
		// Dim coneccion As New DaaxLib.DaxLibBases
		// coneccion.TipoBase = "10"
		// Dim cnnDaxSys As New SqlClient.SqlConnection()
		// cnnDaxSys.ConnectionString = coneccion.StrDaxsys
		// Dim ssql As String = "select Abreviación,Descripcion from syscod where tiporeferencia= '" & referncia & "' and Abreviación <>'#'"
		// Dim dats As New DataSet()
		// Dim datAd As New SqlDataAdapter(ssql, cnnDaxSys)
		// If cnnDaxSys.State = ConnectionState.Open Then cnnDaxSys.Close()
		// cnnDaxSys.Open()
		// datAd.Fill(dats, "Datos")
		// Dim column As New DataGridViewComboBoxColumn
		// With column
		// .Name = NombreCol
		// .HeaderText = TituloCol
		// .DataSource = dats.Tables("Datos")
		// .DisplayMember = "Descripcion"
		// .ValueMember = "Abreviación"
		// End With
		// Grid.Columns.Add(column)
		// cnnDaxSys.Close()
		// cnnDaxSys.Dispose()
		// End Sub

		// Private Sub guaradarEmbarque()
		// EliminarEmbarque()
		// Dim emb As New Embarque
		// With Grid
		// For i = 0 To .RowCount - 2
		// emb.conectar = conectar
		// emb.CODIGO = .Rows(i).Cells(0).Value
		// emb.CLIENTE = Codigo.Text
		// emb.PAÍS = Lcod12.Text
		// emb.CONTACTO = .Rows(i).Cells(1).Value
		// emb.EMBARQUE = .Rows(i).Cells(2).Value
		// emb.EQUIPO = .Rows(i).Cells(3).Value
		// emb.CONDICIONES = .Rows(i).Cells(4).Value
		// emb.TERMINOS = .Rows(i).Cells(5).Value
		// emb.PUERTO = .Rows(i).Cells(6).Value
		// emb.COSTO_FLETE = .Rows(i).Cells(7).Value
		// If Not emb.COSTO_FLETE > 0 Then emb.COSTO_FLETE = 0
		// emb.Guardar()
		// Next
		// End With
		// End Sub
		// Private Sub EliminarEmbarque()
		// Dim emb As New Embarque
		// emb.conectar = conectar
		// emb.Eliminar(Codigo.Text)
		// End Sub

		// Private Sub CargarEmbarque()
		// Dim contador As Long = 0
		// 'Dim cod As String = codigoEmbarque(Codigo.Text)
		// Dim ssql As String = "select * from embarque where cliente='" & Codigo.Text & "'"
		// Dim cmd As New SqlCommand(ssql, conectar)
		// Dim dat As SqlDataReader
		// If conectar.State = ConnectionState.Open Then conectar.Close()
		// conectar.Open()
		// dat = cmd.ExecuteReader()
		// With Grid
		// While dat.Read
		// .Rows.Add()
		// If Not IsDBNull(dat(0)) Then .Rows(contador).Cells(0).Value = dat(0)
		// If Not IsDBNull(dat(3)) Then .Rows(contador).Cells(1).Value = dat(3)
		// If Not IsDBNull(dat(4)) Then .Rows(contador).Cells(2).Value = dat(4)
		// If Not IsDBNull(dat(5)) Then .Rows(contador).Cells(3).Value = dat(5)
		// If Not IsDBNull(dat(6)) Then .Rows(contador).Cells(4).Value = dat(6)
		// If Not IsDBNull(dat(7)) Then .Rows(contador).Cells(5).Value = dat(7)
		// If Not IsDBNull(dat(8)) Then .Rows(contador).Cells(6).Value = dat(8)
		// If Not IsDBNull(dat(9)) Then .Rows(contador).Cells(7).Value = dat(9)
		// contador += 1
		// End While
		// End With
		// conectar.Close()
		// End Sub

		// Private Sub Grid_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
		// Dim fila As Integer = e.RowIndex
		// With Grid
		// If .RowCount > 2 Then
		// If .Rows(fila).Cells(0).Value = Nothing Then .Rows(fila).Cells(0).Value = .Rows(fila - 1).Cells(0).Value + 1
		// Else
		// If .Rows(fila).Cells(0).Value = Nothing Then .Rows(fila).Cells(0).Value = "1"
		// End If
		// End With
		// End Sub

		#endregion
		private void Codigo_Leave(object sender, EventArgs e)
		{
			SaliendoCodigo();
		}

		// Private Sub CbBuscador12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
		// CBuscador(txtProfesion, 15)
		// End Sub

		// Private Sub CbBuscador13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
		// CBuscador(txtEspecialidad, 16)
		// End Sub
		// Private Sub CbBuscador132_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
		// CBuscador(txtEspecialidad2, 16)
		// End Subselectedvalue

		private void Button1_Click(object sender, EventArgs e)
		{
			var arglcod = txtGrupo1;
			CBuscador(ref arglcod, 17);
			txtGrupo1 = arglcod;
		}

		private void Button2_Click(object sender, EventArgs e)
		{
			var arglcod = txtGrupo2;
			CBuscador(ref arglcod, 18);
			txtGrupo2 = arglcod;

		}

		private void Button3_Click(object sender, EventArgs e)
		{
			var arglcod = txtGrupo3;
			CBuscador(ref arglcod, 19);
			txtGrupo3 = arglcod;
		}

		private void txtHistoriaclinica_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.F2)
			{
				txtHistoriaclinica.Text = TxtCedulaRuc.Text;
				// ElseIf e.KeyCode = Keys.F3 And txtHistoriaclinica.Text > "" Then
				// BuscarPorHistoriaClinica(txtHistoriaclinica.Text)
			}
		}
		private void ChequearAutorizacion(string Autorizacion)
		{
			bool Autorizado = Autorizacion == "T";
			btnEliminar.Checked = Autorizado;
			txtLimiteCredito.Enabled = Autorizado;
			tabCliente.Enabled = Autorizado;
			txtFormaPago.Enabled = Autorizado;
			txtPorcDescuento.Enabled = Autorizado;
			txtLimiteCredito.Enabled = Autorizado;
			ExoneradoIva.Enabled = Autorizado;
			// Empleado.Visible = Autorizado
		}

		// Private Sub CBuscador20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBuscador20.Click
		// CBuscador(textNomCentroCosto, 20)
		// End Sub

		private void Button4_Click(object sender, EventArgs e)
		{
			var prog = new ImpresionDocumentosDax.ImprimeConsulta("&DaxDirdir '" + Codigo.Text + "'", "0", "HojDir");
			// Dim pasar As String = datosEmpresa.sistema & "," & "" & "," & "" & "," & "" & "," & ""
			// prog.ImprimeConsulta("&DaxDirdir '" & Codigo.Text & "' ", 0, "HojDir")
			prog.ShowDialog();
		}

		// Private Sub CBuscador21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBuscador21.Click
		// CBuscador(textNomSeccion, 21)
		// End Sub

		// Private Sub CBuscador22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBuscador22.Click
		// CBuscador(textNomModulo, 22)
		// End Sub

		// Private Sub ComCargarCapacitacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
		// Dim prog As New frmCapacitacion
		// prog.NombreEmpleado = impresion.Text
		// prog.CodigoEmpleado = Codigo.Text
		// prog.ShowDialog()
		// End Sub

		// Private Sub mallaDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
		// Dim codigo As String = ""
		// Dim Descripción As String = ""
		// Select Case e.KeyCode
		// Case Keys.F2
		// If mallaDatos.CurrentRow.HeaderCell.Value Is Nothing Then Exit Sub
		// Dim nombreAdicional As String = mallaDatos.CurrentRow.HeaderCell.Value.ToString
		// If Len(nombreAdicional) = 0 Then Exit Sub
		// If mallaDatos.CurrentCell.ColumnIndex = 0 Then
		// Dim progg As New Syscod.ManSysnetClass
		// progg.BuscarReferencia(nombreAdicional, codigo, Descripción)
		// mallaDatos.CurrentCell.Value = Descripción
		// progg = Nothing
		// End If
		// Case Keys.F3
		// Dim progg As New Syscod.ManSysnetClass
		// progg.ManSyscodd("adicionalEmpleado")
		// cargarMallaDatos()
		// progg = Nothing
		// End Select
		// End Sub

		// Private Sub cargarMallaDatos()
		// Dim conn As New SqlClient.SqlConnection(datosEmpresa.strConxSyscod)
		// conn.Open()
		// Dim ssql As String = "select * from syscod where tiporeferencia = 'adicionalEmpleado' and Abreviación <> '#' "
		// Dim dt As New DataTable("datos")
		// Dim rr As New SqlClient.SqlDataAdapter(ssql, conn)
		// rr.Fill(dt)
		// With mallaDatos
		// mallaDatos.Rows.Clear()
		// Dim i As Int32 = 0
		// Dim ro As DataRow
		// For Each ro In dt.Rows
		// mallaDatos.Rows.Add()
		// .Rows(i).Cells(0).Value = ""
		// .Rows(i).HeaderCell.Value = ro("Descripcion").ToString
		// i = i + 1
		// Next
		// End With
		// If mallaDatos.RowCount < 2 Then mallaDatos.RowCount = 2
		// conn.Close()
		// dt.Dispose()
		// rr.Dispose()
		// End Sub

		// Private Sub cargarMallaConceptos()
		// Dim conn As New SqlClient.SqlConnection(datosEmpresa.strConxAdcom)
		// conn.Open()
		// Dim ssql As String = "select CON_TIPO,Con_Descripcion from defcon where isnull(con_conceptoporempleado,'T') ='E' "
		// Dim dt As New DataTable("conceptos")
		// Dim rr As New SqlClient.SqlDataAdapter(ssql, conn)
		// rr.Fill(dt)
		// With mallaConceptos
		// .Rows.Clear()
		// Dim i As Int32 = 0
		// Dim ro As DataRow
		// For Each ro In dt.Rows
		// .Rows.Add()
		// '.Rows(i).Cells(0).Value = 0
		// .Rows(i).HeaderCell.Value = ro("Con_descripcion").ToString
		// i = i + 1
		// Next
		// End With
		// If mallaConceptos.RowCount < 2 Then mallaConceptos.RowCount = 2
		// conn.Close()
		// dt.Dispose()
		// rr.Dispose()
		// End Sub

		// Private Sub Label68_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
		// Dim progg As New Syscod.ManSysnetClass
		// progg.ManSyscodd("nomGrupoRol")
		// cargarNombreGrupos()
		// End Sub

		// Private Sub cargarNombreGrupos()
		// Dim conn As New SqlClient.SqlConnection(datosEmpresa.strConxSyscod)
		// conn.Open()
		// Dim ssql As String = "select Abreviación, Descripcion from syscod where tiporeferencia = 'nomGrupoRol' and Abreviación <> '#' "
		// Dim dt As New DataTable("datos")
		// Dim rr As New SqlClient.SqlDataAdapter(ssql, conn)
		// rr.Fill(dt)
		// With mallaDatos
		// Dim ro As DataRow
		// For Each ro In dt.Rows
		// If ro("Abreviación").ToString = "Grupo-1" Then Label68.Text = ro("Descripcion").ToString
		// If ro("Abreviación").ToString = "Grupo-2" Then Label69.Text = ro("Descripcion").ToString
		// If ro("Abreviación").ToString = "Grupo-3" Then Label70.Text = ro("Descripcion").ToString
		// If ro("Abreviación").ToString = "Grupo-4" Then Label71.Text = ro("Descripcion").ToString
		// If ro("Abreviación").ToString = "Grupo-5" Then Label72.Text = ro("Descripcion").ToString
		// If ro("Abreviación").ToString = "Grupo-6" Then Label73.Text = ro("Descripcion").ToString
		// Next
		// End With
		// conn.Close()
		// dt.Dispose()
		// rr.Dispose()
		// End Sub

		// Private Sub Grupo1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
		// If e.KeyCode = Keys.F2 Then
		// CBuscadorGrupo(Grupo1, Label68.Text)
		// End If

		// End Sub

		// Private Sub CBuscadorGrupo(ByVal lcod As TextBox, ByVal grupo As String)
		// Dim ElNombre As String = ""
		// Dim ElCodigo As String = ""
		// Dim Buscod As New Syscod.ManSysnetClass
		// lcod.Text = Buscod.BuscarReferencia(grupo, ElCodigo, ElNombre)
		// Buscod = Nothing
		// End Sub

		// Private Sub mallaConceptos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
		// Dim codigo As String = ""
		// Dim Descripción As String = ""
		// With mallaConceptos
		// Select Case e.KeyCode
		// Case Keys.F2
		// If .CurrentRow.HeaderCell.Value Is Nothing Then Exit Sub
		// Dim nombreConcepto As String = .CurrentRow.HeaderCell.Value.ToString
		// If Len(nombreConcepto) = 0 Then Exit Sub
		// If .CurrentCell.ColumnIndex = 0 Then
		// If .CurrentCell.Value Is Nothing Then
		// .CurrentCell.Value = "SI"
		// ElseIf .CurrentCell.Value.ToString() = "SI" Then
		// .CurrentCell.Value = "NO"
		// Else
		// .CurrentCell.Value = "SI"
		// End If
		// End If
		// End Select
		// End With
		// End Sub

		private void malla_UserAddedRow(object sender, DataGridViewRowEventArgs e)
		{
			;
#error Cannot convert OnErrorResumeNextStatementSyntax - see comment for details
			/* Cannot convert OnErrorResumeNextStatementSyntax, CONVERSION ERROR: Conversion for OnErrorResumeNextStatement not implemented, please report this issue in 'On Error Resume Next' at character 105112


						Input:
								On Error Resume Next

						 */
			for (int i = 0, loopTo = malla.RowCount - 2; i <= loopTo; i++)
				malla.Rows[i].HeaderCell.Value = (i + 1).ToString();
		}

		private void mallaDatos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			CambioAdicionales = true;
		}

		// Private Sub Grupo2_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs)
		// If e.KeyCode = Keys.F2 Then
		// CBuscadorGrupo(Grupo2, Label69.Text)
		// End If
		// End Sub

		// Private Sub Grupo3_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs)
		// If e.KeyCode = Keys.F2 Then
		// CBuscadorGrupo(Grupo3, Label70.Text)
		// End If
		// End Sub
		// Private Sub Grupo4_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs)
		// If e.KeyCode = Keys.F2 Then
		// CBuscadorGrupo(Grupo4, Label71.Text)
		// End If
		// End Sub
		// Private Sub Grupo5_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs)
		// If e.KeyCode = Keys.F2 Then
		// CBuscadorGrupo(Grupo5, Label72.Text)
		// End If
		// End Sub
		// Private Sub Grupo6_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs)
		// If e.KeyCode = Keys.F2 Then
		// CBuscadorGrupo(Grupo6, Label73.Text)
		// End If
		// End Sub


		// Private Sub Button5_Click(sender As System.Object, e As System.EventArgs)
		// CBuscador(txtNomParroquia, 24)
		// End Sub

		// Private Sub BtnCanton_Click(sender As System.Object, e As System.EventArgs)
		// CBuscador(TxtNomCanton, 23)
		// End Sub

		private void DEEPPCTE_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.F2 & e.Alt == true & Codigo.Text.Length > 0)
			{
				try
				{
					var prog = new daxNota.ClassNota();
					prog.verNotaReferencia("DIR", Codigo.Text, datosEmpresa.usr, datosEmpresa.strConxAdcom);
					return;
				}
				catch
				{
				}
			}
			if (e.KeyCode == Keys.F3 & e.Alt == true & Codigo.Text.Length > 0 & impresion.Text.Length > 0)
			{
				try
				{
					var prog = new daxNota.ClassNota();
					var nnota = new daxNota.DaxNot(datosEmpresa.strConxAdcom);
					nnota.fechaNota = DateTime.Now;
					nnota.idCodigo = Codigo.Text;
					nnota.idNombre = impresion.Text;
					nnota.idTipo = "DIR";
					nnota.UsuarioCreaNota = datosEmpresa.usr;
					prog.nuevaNota(nnota);
					return;
				}
				catch
				{
				}
			}
		}
		// Private Sub btnPaisNace_Click(sender As Object, e As EventArgs)
		// CBuscador(txtPaisNace, 12)
		// End Sub

		// Private Sub btnProvNace_Click(sender As Object, e As EventArgs)
		// CBuscador(txtProvNace, 13)
		// End Sub

		// Private Sub btnCiudadNace_Click(sender As Object, e As EventArgs)
		// CBuscador(TxtCiudadNace, 14)
		// End Sub

		// Private Sub btnRegionNace_Click(sender As Object, e As EventArgs)
		// CBuscador(TxtRegionNace, 25)
		// End Sub

		// Private Sub btnRegion_Click(sender As Object, e As EventArgs)
		// CBuscador(txtRegion, 25)
		// End Sub

		private void btnPaísEntrega_Click(object sender, EventArgs e)
		{
			var arglcod = txtPaisEntrega;
			CBuscador(ref arglcod, 12);
			txtPaisEntrega = arglcod;
		}

		private void btnPuertoEntrega_Click(object sender, EventArgs e)
		{
			var arglcod = entregarmer;
			CBuscador(ref arglcod, 26);
			entregarmer = arglcod;
		}


		private void btnBuscaOperador_Click(object sender, EventArgs e)
		{
			var dat = new string[3];
			dat = CbuscaDir("O", 0);
			txtOperador.Text = dat[1];
			codigoDirectorio[5] = dat[0];
		}

		private void btnTransportadora_Click(object sender, EventArgs e)
		{
			var dat = new string[3];
			dat = CbuscaDir("R", 0);
			txtTransportadora.Text = dat[1];
			codigoDirectorio[6] = dat[0];
		}

		// Private Sub Button6_Click(sender As Object, e As EventArgs)
		// CBuscador(observacionesprv, 27)
		// End Sub

		// Private Sub Button7_Click(sender As Object, e As EventArgs)
		// Dim progRet As New DaxNomReten.frmRetencion(Codigo.Text, impresion.Text)
		// progRet.ShowDialog()
		// progRet.Dispose()
		// End Sub

		// Private Sub GroupBox13_Enter(sender As Object, e As EventArgs) Handles GroupBox13.Enter

		// End Sub

		// Private Sub GroupBox11_Enter(sender As Object, e As EventArgs) Handles GroupBox11.Enter

		// End Sub

		private void cmbPaisDomicilio_Leave(object sender, EventArgs e)
		{
			ComboBox cmb = (ComboBox)sender;
			if (cmb.SelectedValue == null)
				cmb.Text = "";
		}

		private void tabIdentificación_Click(object sender, EventArgs e)
		{

		}
	}
}