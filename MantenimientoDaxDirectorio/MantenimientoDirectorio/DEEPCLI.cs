using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DattCom;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace directMnt
{
	public partial class DEEPCLI
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
		private string ImgDirectorio = @"\Directorio";

		public DEEPCLI()
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

		private void Apellidos_TextChanged(object sender, EventArgs e)
		{

			DataTable dt = datosEmpresa.leeParametrosEmp("par_acumhis");
			try
			{
				if (Convert.ToBoolean(dt.Rows[0]["par_AcumHis"]) == false)
				{
					impresion.Text = Strings.Trim(Datox1.Text + " " + Apellidos.Text);
				}
				else
				{
					impresion.Text = Strings.Trim(Apellidos.Text + " " + Datox1.Text);
				}
			}
			catch
			{
				impresion.Text = Strings.Trim(Apellidos.Text + " " + Datox1.Text);
			}
		}

		private bool leerIdentificacion()
		{
			var Buscod = new Syscod.ManSysnetClass();
			;
#error Cannot convert OnErrorResumeNextStatementSyntax - see comment for details
			/* Cannot convert OnErrorResumeNextStatementSyntax, CONVERSION ERROR: Conversion for OnErrorResumeNextStatement not implemented, please report this issue in 'On Error Resume Next' at character 2398


						Input:
								On Error Resume Next

						 */
			var ConxAdcom = new SqlConnection(datosEmpresa.strConxAdcom);
			SqlDataReader rs;
			string Ssql = "Select * from Identificacion " + " where identificacion.codigo = '" + QUECODIGO + "' ";
			var comm = new SqlCommand(Ssql, ConxAdcom);
			ConxAdcom.Open();
			rs = comm.ExecuteReader();

			if (rs.Read() == false)
			{
				rs.Close();
				return false;
				return default;
			}

			Codigo.Text = rs["codigo"].ToString();
			if (!(rs["TipoPersona"] is DBNull))
				tipoper = rs["TipoPersona"].ToString();

			if (tipoper == "J")
			{
				Juridica.Checked = true;
			}
			else
			{
				tipoper = "N";
				Natural.Checked = true;
			}

			if (tipoper == "J")
			{
				Juridica.Checked = true;
				Natural.Checked = false;
			}
			if (tipoper == "N")
			{
				Juridica.Checked = false;
				Natural.Checked = true;
			}

			string localArreglaId() { string argIdent = Valores.CorrijeNulo(rs["TipoIdentificacion"]); var ret = ArreglaId(ref argIdent); return ret; }

			string localArreglaId1() { string argIdent1 = Valores.CorrijeNulo(rs["TipoIdentificacion"]); var ret = ArreglaId(ref argIdent1); return ret; }

			TipoIdent.SelectedIndex = (int)Math.Round(Conversion.Val(localArreglaId1())); // : TIPID = CStr(TipoIdent.SelectedIndex)
			if (!(rs["CedulaIdentidadRuc"] is DBNull))
				Datox0.Text = rs["CedulaIdentidadRuc"].ToString();
			if (!(rs["nombres"] is DBNull))
				Datox1.Text = rs["nombres"].ToString();
			if (!(rs["apellidos"] is DBNull))
				Apellidos.Text = rs["apellidos"].ToString();
			if (!(rs["NombreImpresion"] is DBNull))
				impresion.Text = rs["NombreImpresion"].ToString();

			if (!(rs["NumeroDomicilio"] is DBNull))
				TxtData2.Text = rs["NumeroDomicilio"].ToString();
			if (!(rs["País"] is DBNull))
				txtNomPais.Text = Buscod.QueNombre(rs["País"].ToString(), TipCodSyscod[12]);
			if (!(rs["Provincia"] is DBNull))
				txtNomProvincia.Text = Buscod.QueNombre(rs["Provincia"].ToString(), TipCodSyscod[13]);
			if (!(rs["Ciudad"] is DBNull))
				txtNomCiudad.Text = Buscod.QueNombre(rs["Ciudad"].ToString(), TipCodSyscod[14]);
			if (!(rs["Domicilio"] is DBNull))
				txtnomDireccion.Text = rs["Domicilio"].ToString();
			if (!(rs["telefono1"] is DBNull))
				txtTelefono1.Text = rs["telefono1"].ToString();
			if (!(rs["telefono2"] is DBNull))
				txtTelefono2.Text = rs["telefono2"].ToString();
			if (!(rs["telefono3"] is DBNull))
				txtTelefono3.Text = rs["telefono3"].ToString();
			if (!(rs["NúmeroFax"] is DBNull))
				TxtData6.Text = rs["NúmeroFax"].ToString();
			if (!(rs["Casilla"] is DBNull))
				txtNomParroquia.Text = Buscod.QueNombre(rs["Casilla"].ToString(), TipCodSyscod[24]);
			// !correoelectrónico = TxtData8.Text
			if (!(rs["CorreoElectrónico"] is DBNull))
				TxtData8.Text = rs["CorreoElectrónico"].ToString();
			if (!(rs["Paginaweb"] is DBNull))
				TxtData9.Text = rs["Paginaweb"].ToString();
			if (!(rs["Sector"] is DBNull))
				TxtNomCanton.Text = Buscod.QueNombre(rs["Sector"].ToString(), TipCodSyscod[23]);
			if (!(rs["Grupo1"] is DBNull))
				txtGrupo1.Text = rs["Grupo1"].ToString();
			if (!(rs["Grupo2"] is DBNull))
				txtGrupo2.Text = rs["Grupo2"].ToString();
			if (!(rs["Grupo3"] is DBNull))
				txtGrupo3.Text = rs["Grupo3"].ToString();
			if (!(rs["HistoriaClinica"] is DBNull))
				txtHistoriaclinica.Text = rs["HistoriaClinica"].ToString();
			if (!(rs["Logotipo"] is DBNull))
				CodigoFoto = rs["Logotipo"].ToString();
			// -----------------------------If Not IsDbNull(.ITEM("ComisionVenta")) Then PorComision.Text = .ITEM("ComisionVenta")
			// -----------------------------If Not IsDbNull(.ITEM("CtaCobrarComisiones")) Then Text1.Text = .ITEM("CtaCobrarComisiones")
			if (!(rs["CodGrabo"] is DBNull))
			{
				if (datosEmpresa.usr != rs["CodGrabo"].ToString() & Operators.CompareString(rs["CodGrabo"].ToString(), "", false) > 0)
					propio = false;
			}
			if (!(rs["ExoneradoIva"] is DBNull))
				ExoneradoIva.Checked = Conversions.ToBoolean(rs["ExoneradoIva"]);
			if (!(rs["esRise"] is DBNull))
				chkRise.Checked = Conversions.ToBoolean(rs["esRise"]);
			if (!(rs["NroCtrbuyteEspecial"] is DBNull))
				txtContribuyenteEspecial.Text = rs["NroCtrbuyteEspecial"].ToString();
			if (!(rs["ObligLlevarConta"] is DBNull))
				chkObligaContabilidad.Checked = Conversions.ToBoolean(rs["ObligLlevarConta"]);
			if (!(rs["regionDomicilio"] is DBNull))
				txtRegion.Text = rs["regionDomicilio"].ToString();
			if (!(rs["SectorDomicilio"] is DBNull))

				txtSector.Text = rs["SectorDomicilio"].ToString();

			rs.Close();
			comm.Dispose();
			ConxAdcom.Close();
			ConxAdcom.Dispose();
			return true;
		}

		private bool leerPersonal()
		{
			var Buscod = new Syscod.ManSysnetClass();
			;
#error Cannot convert OnErrorResumeNextStatementSyntax - see comment for details
			/* Cannot convert OnErrorResumeNextStatementSyntax, CONVERSION ERROR: Conversion for OnErrorResumeNextStatement not implemented, please report this issue in 'On Error Resume Next' at character 8967


						Input:
								On Error Resume Next

						 */
			var ConxAdcom = new SqlConnection(datosEmpresa.strConxAdcom);
			SqlDataReader rs;
			string Ssql = "select * from Personal where codigoper = '" + QUECODIGO + "'";
			var comm = new SqlCommand(Ssql, ConxAdcom);
			ConxAdcom.Open();
			rs = comm.ExecuteReader();

			if (rs.Read() == false)
			{
				rs.Close();
				return false;
				return default;
			}

			// tabla personal
			// If .Read Then
			if (!(rs["FechaNacimiento"] is DBNull))
				fechanaci.Text = "" + rs["FechaNacimiento"].ToString();
			if (!(rs["LugarNacimiento"] is DBNull))
				Lugarnaci.Text = "" + rs["LugarNacimiento"].ToString();
			if (!(rs["Sexo"] is DBNull))
				Sexo = "" + rs["Sexo"].ToString();
			if (!(rs["EstadoCivil"] is DBNull))
				CBOestadocivil.Text = "" + rs["EstadoCivil"].ToString();
			if (!(rs["Nacionalidad"] is DBNull))
				Lcod2.Text = Buscod.QueNombre(rs["Nacionalidad"].ToString(), TipCodSyscod[2]);
			if (!(rs["hobbys"] is DBNull))
				hobbys.Text = "" + rs["hobbys"].ToString();


			if (!(rs["codigotarjrta"] is DBNull))
				txtCodTar.Text = "" + rs["codigotarjrta"].ToString();
			if (!(rs["numerotarjrta"] is DBNull))
				txtNumTar.Text = "" + rs["numerotarjrta"].ToString();


			if (!(rs["Profesión"] is DBNull))
				txtProfesion.Text = Buscod.QueNombre(rs["Profesión"].ToString(), "Profesion");
			if (!(rs["Especialidad"] is DBNull))
				txtEspecialidad.Text = Buscod.QueNombre(rs["Especialidad"].ToString(), "Especialidad");
			if (!(rs["Especialidad2"] is DBNull))
				txtEspecialidad2.Text = Buscod.QueNombre(rs["Especialidad2"].ToString(), "Especialidad");
			if (!(rs["Referirsecomo"] is DBNull))
				Combo1.Text = rs["Referirsecomo"].ToString();
			if (!(rs["TipoSangre"] is DBNull))
				txtTipoSangre.Text = rs["TipoSangre"].ToString();
			if (!(rs["DirecciónTrabajo"] is DBNull))
				txtLugTra.Text = rs["DirecciónTrabajo"].ToString();
			if (!(rs["ciudadNacimto"] is DBNull))
				txtCiudadNace.Text = rs["ciudadNacimto"].ToString();
			if (!(rs["paisNacimto"] is DBNull))
				txtPaisNace.Text = rs["paisNacimto"].ToString();
			if (!(rs["provNacimto"] is DBNull))
				txtProvNace.Text = rs["provNacimto"].ToString();


			if (Sexo == "M")
			{
				mujer.Checked = true;
			}
			else
			{
				hombre.Checked = true;
				Sexo = "H";

			}
			rs.Close();
			comm.Dispose();
			ConxAdcom.Close();
			ConxAdcom.Dispose();
			return true;
		}

		private bool leerCliente()
		{
			var Buscod = new Syscod.ManSysnetClass();
			;
#error Cannot convert OnErrorResumeNextStatementSyntax - see comment for details
			/* Cannot convert OnErrorResumeNextStatementSyntax, CONVERSION ERROR: Conversion for OnErrorResumeNextStatement not implemented, please report this issue in 'On Error Resume Next' at character 12756


						Input:
								On Error Resume Next

						 */
			var ConxAdcom = new SqlConnection(datosEmpresa.strConxAdcom);
			SqlDataReader rs;
			string Ssql = "select * from cliente where codigocli = '" + QUECODIGO + "' ";
			var comm = new SqlCommand(Ssql, ConxAdcom);
			ConxAdcom.Open();
			rs = comm.ExecuteReader();
			if (rs.Read() == false)
			{
				rs.Close();
				return false;
				return default;
			}
			// If rs.Read Then
			if (!(rs["VendedorInterno"] is DBNull))
			{
				if (rs["VendedorInterno"].ToString() != datosEmpresa.usr & rs["CobradorInterno"].ToString() != datosEmpresa.usr)
					propio = false;
			}
			// End If
			else
			{
			}

			// tabla cliente
			// If .Read Then
			if (!(rs["TipoCli"] is DBNull))
				txtTipoCliente.Text = Buscod.QueNombre(rs["TipoCli"].ToString(), TipCodSyscod[3]);
			if (!(rs["ZonaVentas"] is DBNull))
				txtZonaVentas.Text = Buscod.QueNombre(rs["ZonaVentas"].ToString(), TipCodSyscod[4]);
			if (!(rs["VendedorInterno"] is DBNull))
			{
				txtVendedor.Text = QueNombre(rs["VendedorInterno"].ToString());
				codigoDirectorio[0] = rs["VendedorInterno"].ToString();
			}
			if (!(rs["Operador"] is DBNull))
			{
				txtOperador.Text = QueNombre(rs["Operador"].ToString());
				codigoDirectorio[5] = rs["Operador"].ToString();
			}
			if (!(rs["Transportadora"] is DBNull))
			{
				txtTransportadora.Text = QueNombre(rs["Transportadora"].ToString());
				codigoDirectorio[6] = rs["Transportadora"].ToString();
			}
			if (!(rs["ZonaCobranza"] is DBNull))
				txtZonaCobranzas.Text = Buscod.QueNombre(rs["ZonaCobranza"].ToString(), TipCodSyscod[5]);
			if (!(rs["CobradorInterno"] is DBNull))
			{
				txtCobrador.Text = QueNombre(rs["CobradorInterno"].ToString());
				codigoDirectorio[1] = rs["CobradorInterno"].ToString();
			}
			if (!(rs["PrecioVenta"] is DBNull))
				txtPrecioVenta.Text = Buscod.QueNombre(rs["PrecioVenta"].ToString(), TipCodSyscod[6]);
			if (!(rs["FormaPago"] is DBNull))
				txtFormaPago.Text = RetornaNombre.RetornaNombrePago(rs["FormaPago"].ToString(), datosEmpresa.strConxAdcom);
			if (!(rs["PorcDescuento"] is DBNull))
				txtPorcDescuento.Text = rs["PorcDescuento"].ToString();
			if (!(rs["limitecredito"] is DBNull))
				txtLimiteCredito.Text = rs["limitecredito"].ToString();
			if (!(rs["descuentoaso"] is DBNull))
				txtDescuentoAsociacion.Text = rs["descuentoaso"].ToString();
			if (!(rs["Observaciones"] is DBNull))
				observacli.Text = rs["Observaciones"].ToString();
			if (!(rs["contacto"] is DBNull))
				txtContacto.Text = rs["contacto"].ToString();
			if (!(rs["Entregarmercaderia"].ToString() is DBNull))
				entregarmer.Text = rs["Entregarmercaderia"].ToString();
			if (!(rs["ctbcobrar"] is DBNull))
				Cuenta0.Text = rs["ctbcobrar"].ToString();
			if (!(rs["ctbcobrar2"] is DBNull))
				Cuenta4.Text = rs["ctbcobrar2"].ToString();
			// End If
			if (!(rs["PuertoEmbarque"].ToString() is DBNull))
				entregarmer.Text = rs["PuertoEmbarque"].ToString();
			if (!(rs["PaisEmbarque"].ToString() is DBNull))

				txtPaisEntrega.Text = rs["PaisEmbarque"].ToString();
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
			/* Cannot convert OnErrorResumeNextStatementSyntax, CONVERSION ERROR: Conversion for OnErrorResumeNextStatement not implemented, please report this issue in 'On Error Resume Next' at character 17760


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
			if (Natural.Checked == false)
			{
				tabDatosPer.Parent = null;
			}
			else
			{
				tabDatosPer.Parent = DatosDirectorio;
			}
			tabCliente.Parent = DatosDirectorio; // .TabPages.Add(tabCliente)

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

		private void CBuscador12_Click(object sender, EventArgs e)
		{
			var arglcod = txtNomPais;
			CBuscador(ref arglcod, 12);
			txtNomPais = arglcod;
		}

		private void CBuscador13_Click(object sender, EventArgs e)
		{
			var arglcod = txtNomProvincia;
			CBuscador(ref arglcod, 13);
			txtNomProvincia = arglcod;
		}

		private void CBuscador14_Click(object sender, EventArgs e)
		{
			UseWaitCursor = true;
			Cursor = Cursors.WaitCursor;
			var arglcod = txtNomCiudad;
			CBuscador(ref arglcod, 14);
			txtNomCiudad = arglcod;
			UseWaitCursor = false;
			Cursor = Cursors.Default;
		}

		private void CBuscador2_Click(object sender, EventArgs e)
		{
			var arglcod = Lcod2;
			CBuscador(ref arglcod, 2);
			Lcod2 = arglcod;
		}

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

		private void CBuscador(ref TextBox lcod, int indice)
		{
			string ElNombre = "";
			string ElCodigo = "";
			var Buscod = new Syscod.ManSysnetClass();
			ElCodigo = Buscod.BuscarReferencia(ref TipCodSyscod[indice], ref ElCodigo, ref ElNombre);
			lcod.Text = ElNombre;
			Buscod = null;
		}

		private void CBuscador(ref Label lcod, int indice)
		{
			string ElNombre = "";
			string ElCodigo = "";
			var Buscod = new Syscod.ManSysnetClass();
			ElCodigo = Buscod.BuscarReferencia(ref TipCodSyscod[indice], ref ElCodigo, ref ElNombre);
			lcod.Text = ElNombre;
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

		private void Cuenta0_KeyDown(object sender, KeyEventArgs e)
		{
			var argcuenta = Cuenta0;
			cuenta(ref argcuenta, (int)e.KeyCode, (int)e.KeyData / 0x10000);
			Cuenta0 = argcuenta;
		}

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
				Datox0.Text = Codigo.Text;
		}

		private void Datox1_TextChanged(object sender, EventArgs e)
		{
			if (Emp.OrdenaPorApellidos == false)
			{
				impresion.Text = Strings.Trim(Datox1.Text + " " + Apellidos.Text);
			}
			else
			{
				impresion.Text = Strings.Trim(Apellidos.Text + " " + Datox1.Text);
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

		public void Directorio(string cod)
		{
			try
			{
				if (string.IsNullOrEmpty(cod))
				{
					LimpiezaFormulario();
					QUECODIGO = "";
					Juridica.Checked = true;
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

		private void DEEP01_FormClosing(object sender, FormClosingEventArgs e)
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

			}
		}


		private void btnGuardar_Click(object sender, EventArgs e)
		{
			var Buscod = new Syscod.ManSysnetClass();
			try
			{
				if (string.IsNullOrEmpty(Codigo.Text))
				{
					Interaction.MsgBox("Digite un Código Válido", MsgBoxStyle.Critical);
					return;
				}
				if (datosEmpresa.LongCodDirectorio > 0 & Codigo.Text.Length != datosEmpresa.LongCodDirectorio)
				{
					Interaction.MsgBox("El código debe tener la longitud correcta (" + datosEmpresa.LongCodDirectorio.ToString() + ")", MsgBoxStyle.Critical);
					return;
				}

				if (string.IsNullOrEmpty(TipoIdent.Text))
				{
					Interaction.MsgBox("Falta el tipo de identificación", MsgBoxStyle.Critical);
					return;
				}
				if (string.IsNullOrEmpty(Datox0.Text))
				{
					Interaction.MsgBox("Debe ingresar el RUC o CI", MsgBoxStyle.Information);
					Datox0.Focus();
					return;
				}

				if (ValidaNumeroId() == false)
				{
					Interaction.MsgBox("El numero del documento de identificacion está errado ", MsgBoxStyle.Critical);
					Datox0.Focus();
					return;
				}

				if (string.IsNullOrEmpty(Datox1.Text))
				{
					Interaction.MsgBox("Debe ingresar el nombre", MsgBoxStyle.Information);
					Datox1.Focus();
					return;
				}
				if (Natural.Checked == true)
				{
					if (string.IsNullOrEmpty(Apellidos.Text))
					{
						Apellidos.Focus();
						Interaction.MsgBox("Debe ingresar el apellido", MsgBoxStyle.Information);
						return;
					}
				}
				if (string.IsNullOrEmpty(impresion.Text))
				{
					impresion.Focus();
					Interaction.MsgBox("Debe ingresar el nombre de impresión", MsgBoxStyle.Information);
					return;
				}

				CodigoBusca = Codigo.Text;
				cedulabusca = Datox0.Text;

				var recide = new Identificacion(datosEmpresa.strConxAdcom);

				// If IsDBNull(CodigoBusca) Then CodigoBusca = ""
				// recide = Identificacion.Buscar("cedulaidentidadruc='" & cedulabusca & "' and codigo <> '" & CodigoBusca & "' ")
				// If Not recide Is Nothing Then
				if (LeerEmpleado.ExisteCedula(CodigoBusca, cedulabusca))
				{
					Datox0.Text = "";
					Interaction.MsgBox("El Nro. ID (cédula o ruc) ya existe ", MsgBoxStyle.Critical);
					Datox0.Focus();
					return;
				}
				recide = Identificacion.Buscar(" codigo = '" + CodigoBusca + "'");
				if (recide is null)
					recide = new Identificacion(datosEmpresa.strConxAdcom);
				var movdatId = new moverDatosIdentificacion();
				movdatId.movDatIdentificacionCli(this, recide, codigoDirectorio);
				movdatId = null;

				{
					ref var withBlock = ref recide;
					if (withBlock.Actualizar("Select * from Identificacion " + " where identificacion.codigo = '" + QUECODIGO + "' ").Substring(0, 5) == "ERROR")
					{
						Interaction.MsgBox("El registro de identificacion no puede grabarse ", MsgBoxStyle.Exclamation);
						return;
					}
				}
				recide = null;

				Interaction.SaveSetting("Alex", "Codigos", "Ultimo", Codigo.Text);

				// tabla personal
				if (Natural.Checked == true)
				{
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
						withBlock1.EstadoCivil = CBOestadocivil.Text;
						withBlock1.Nacionalidad = Buscod.QueCodigo(Lcod2.Text, TipCodSyscod[2]);
						withBlock1.Hobbys = hobbys.Text;

						withBlock1.codigotarjrta = txtCodTar.Text;
						withBlock1.numerotarjrta = txtNumTar.Text;

						withBlock1.Profesión = Buscod.QueCodigo(txtProfesion.Text, "Profesion");
						withBlock1.Especialidad = Buscod.QueCodigo(txtEspecialidad.Text, "Especialidad");
						withBlock1.Especialidad2 = Buscod.QueCodigo(txtEspecialidad2.Text, "Especialidad");
						withBlock1.Referirsecomo = Combo1.Text;
						withBlock1.AsociadoAEmpresa = Conversions.ToInteger("0" + codigoDirectorio[3]);
						withBlock1.TipoSangre = txtTipoSangre.Text;
						withBlock1.DirecciónTrabajo = txtLugTra.Text;

						withBlock1.ciudadNacimto = txtCiudadNace.Text;
						withBlock1.paisNacimto = txtPaisNace.Text;
						withBlock1.provNacimto = txtProvNace.Text;
						withBlock1.Discapacidad = txtDiscapacidad.Text;
						withBlock1.PorcentajeDiscapacidad = Convert.ToDecimal("0" + txtPorcDiscapacidad.Text);


						if (withBlock1.Actualizar("select * from Personal where codigoper = '" + Codigo.Text + "'").Substring(0, 5) == "ERROR")
						{
							Interaction.MsgBox("El registro personal no puede grabarse", MsgBoxStyle.Exclamation);
						}
					}
					tablaper = null;
				}

				// 'tabla cliente
				var tablacli = new dbCliente(datosEmpresa.strConxAdcom);
				{
					ref var withBlock2 = ref tablacli;
					withBlock2.CodigoCli = Codigo.Text;
					withBlock2.TipoCli = Buscod.QueCodigo(txtTipoCliente.Text, TipCodSyscod[3]);
					withBlock2.ZonaVentas = Buscod.QueCodigo(txtZonaVentas.Text, TipCodSyscod[4]);
					withBlock2.VendedorInterno = codigoDirectorio[0];
					withBlock2.Operador = codigoDirectorio[5];
					withBlock2.Transportadora = codigoDirectorio[6];
					withBlock2.ZonaCobranza = Buscod.QueCodigo(txtZonaCobranzas.Text, TipCodSyscod[5]);
					withBlock2.CobradorInterno = codigoDirectorio[1];
					withBlock2.PrecioVenta = Buscod.QueCodigo(txtPrecioVenta.Text, TipCodSyscod[6]);
					withBlock2.FormaPago = RetornaNombre.RetornaCodigoPago(txtFormaPago.Text, datosEmpresa.strConxAdcom);
					withBlock2.PorcDescuento = (decimal)Conversion.Val(txtPorcDescuento.Text);
					withBlock2.LimiteCredito = (decimal)Conversion.Val(txtLimiteCredito.Text);
					withBlock2.DescuentoAso = (decimal)Conversion.Val(txtDescuentoAsociacion.Text);
					withBlock2.Observaciones = observacli.Text;
					withBlock2.Contacto = txtContacto.Text;
					withBlock2.Entregarmercaderia = entregarmer.Text;
					withBlock2.CtbCobrar = Cuenta0.Text;
					withBlock2.CtbCobrar2 = Cuenta4.Text;
					withBlock2.PaisEmbarque = txtPaisEntrega.Text;
					withBlock2.PuertoEmbarque = entregarmer.Text;

					if (withBlock2.Actualizar("select * from cliente where codigocli = '" + Codigo.Text + "' ").Substring(0, 5) == "ERROR")
					{
						Interaction.MsgBox("El registro cliente no puede grabarse", MsgBoxStyle.Exclamation);
					}
				}
				tablacli = null;
				// tabla empleado

				var tablacon = new dbContactos(datosEmpresa.strConxAdcom);

				var ConxAdcom = new SqlConnection(datosEmpresa.strConxAdcom);
				ConxAdcom.Open();
				string Ssql = "delete from contactos where codcontacto='" + QUECODIGO + "' ";
				var comm = new SqlCommand(Ssql, ConxAdcom);
				comm.ExecuteNonQuery();


				tablacon = null;

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


		private void btnNuevo_Click(object sender, EventArgs e)
		{
			CrearNuevo();
		}
		private void CrearNuevo()
		{
			LimpiezaFormulario();
			QUECODIGO = "";
			Juridica.Checked = true;
			// PonerDatosTipo()
			EsNuevo = 1;
			PonerBotonesFormulario();
			accion = "guardar";
			ChequearAutorizacion("T");
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

		private void DEEP01_Load(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(Codigo.Text))
			{
				EsNuevo = 0;
				PonerBotonesFormulario();
			}
			Module1.Mainn();
			Valores.iniciaValores(TipCodSyscod);
			Operacion[0] = "";
			Operacion[1] = " CREANDO NUEVO REGISTRO ";
			Operacion[2] = " MODIFICANDO REGISTRO EXISTENTE ";

			Juridica.Checked = true;
			DatosDirectorio.SelectedIndex = 0;
			saltar = false;
			PonerDatosTipo();
			ControlarAutorizaciones();
			cargarAutorizacionOpcion();
			if (IniNvo)
				CrearNuevo();
			if (Emp.PathImagenes.Length > 0)
				ImgDirectorio = Emp.PathImagenes + ImgDirectorio;
			else
				ImgDirectorio = "";

		}

		private void ControlarAutorizaciones()
		{
			if (datosEmpresa.usr.ToUpper == " ADMINISTRADOR")
				return;
			var autorizaciones = new mntUsrs.autorizaUserDirectorio(datosEmpresa.usr, datosEmpresa.strConxSyscod, datosEmpresa.codEmpresa.ToString());
			if (autorizaciones.autUsrIdentificacion.existe == false)
				return;
			if (autorizaciones.autUsrCliente.visible == false)
				tabCliente.Parent = null;
			if (autorizaciones.autUsrDatoPersonal.visible == false)
				tabDatosPer.Parent = null;

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
					leerCliente();
					EsNuevo = 2;
				}
				PonerDatosTipo();
				CargaFoto();
				Cambio = false;
				// '''''''''''''''''''''''''''''''''ChequearAutorizacion(Emp.)
				PonerBotonesFormulario();
			}
			catch (Exception ee)
			{
				Interaction.MsgBox("excepción cargaDir: " + ee.Message);
			}
			CambioAdicionales = false;
		}

		private void Juridica_CheckedChanged(object sender, EventArgs e)
		{
			if (Juridica.Checked)
			{
				Natural_CheckedChanged(Natural, new EventArgs());
			}
		}

		private void Natural_CheckedChanged(object sender, EventArgs e)
		{
			if (saltar)
				return;
			;
#error Cannot convert OnErrorResumeNextStatementSyntax - see comment for details
			/* Cannot convert OnErrorResumeNextStatementSyntax, CONVERSION ERROR: Conversion for OnErrorResumeNextStatement not implemented, please report this issue in 'On Error Resume Next' at character 45378


						Input:
								On Error Resume Next

						 */
			if (Juridica.Checked == true)
			{
				tipoper = "J";
				asociadoa.Visible = false;
				Label34.Visible = false;
				Apellidos.Visible = false;
				Apellidos.Enabled = false;
				Apellidos.Text = "";
			}
			else
			{
				Label34.Visible = true;
				Apellidos.Visible = true;
				Apellidos.Enabled = true;
				tipoper = "N";
				Natural.Checked = true;
			}
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
				}
				else
				{
					Interaction.MsgBox("La Fotografía asignada a este contacto no existe " + Constants.vbCr + Constants.vbCr + ImgDirectorio + CodigoFoto, MsgBoxStyle.Information);
				}
			}
		}

		private void PonerBotonesFormulario()
		{
			btnNuevo.Visible = EsNuevo == 0;
			btnAbrir.Visible = EsNuevo == 0;
			btnCerrar.Visible = EsNuevo > 0;
			btnGuardar.Visible = EsNuevo == 2 | EsNuevo == 1;
			btnEliminar.Visible = EsNuevo == 2 | EsNuevo == 1;
			Text = "ADCOM - Mantenimiento DIRECTORIO CLIENTES -  " + Operacion[EsNuevo];
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
			// limpiarGrid(Grid)
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
				// If a = "ComboBox" Then Control1.SelectedIndex = 0)
				if (a == "MaskedTextBox")
					Control1.Text = "  /  /";
				chkObligaContabilidad.Checked = false;
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
				// If a = "ComboBox" Then Control1.SelectedIndex = 0)
				if (a == "MaskedTextBox")
					Control1.Text = "  /  /";
			}
		}

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
			if (Juridica.Checked)
				Persona = "E";
			if (j == "P")
			{
				ValidaNumeroIdRet = true;
			}
			else if (j == "F" & Datox0.Text == "9999999999999")
			{
				ValidaNumeroIdRet = true;
			}
			else
			{
				var prog = new valIdcedru.valcedruc();
				ValidaNumeroIdRet = prog.valCr(Datox0.Text, j, Persona);
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

		private void CbuscaDir2_Click(object sender, EventArgs e)
		{
			var dat = new string[3];
			dat = CbuscaDir("F", 0);
			codigoDirectorio[2] = dat[0];
		}

		private void CbuscaDir3_Click(object sender, EventArgs e)
		{
			var dat = new string[3];
			dat = CbuscaDir("F", 0);
			LDir3.Text = dat[1];
			codigoDirectorio[3] = dat[0];
		}

		private void Cliente_CheckedChanged(object sender, EventArgs e)
		{
			PonerDatosTipo();
		}

		private void Proveedor_CheckedChanged(object sender, EventArgs e)
		{
			PonerDatosTipo();
		}

		private void Banco_CheckedChanged(object sender, EventArgs e)
		{
			PonerDatosTipo();
		}

		private void Empleado_CheckedChanged(object sender, EventArgs e)
		{
			PonerDatosTipo();
		}

		private void EsVendedor_CheckedChanged(object sender, EventArgs e)
		{
			PonerDatosTipo();
		}

		private void Directa_CheckedChanged(object sender, EventArgs e)
		{
			PonerDatosTipo();
		}

		private void Asociacion_CheckedChanged(object sender, EventArgs e)
		{
			PonerDatosTipo();
		}

		private void ToolStripButton1_Click(object sender, EventArgs e)
		{
			CerrarRegistro();
			accion = "";
		}

		#region Embarque


		#endregion
		private void Codigo_Leave(object sender, EventArgs e)
		{
			SaliendoCodigo();
		}

		private void CbBuscador12_Click(object sender, EventArgs e)
		{
			var arglcod = txtProfesion;
			CBuscador(ref arglcod, 15);
			txtProfesion = arglcod;
		}

		private void CbBuscador13_Click(object sender, EventArgs e)
		{
			var arglcod = txtEspecialidad;
			CBuscador(ref arglcod, 16);
			txtEspecialidad = arglcod;
		}
		private void CbBuscador132_Click(object sender, EventArgs e)
		{
			var arglcod = txtEspecialidad2;
			CBuscador(ref arglcod, 16);
			txtEspecialidad2 = arglcod;
		}

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
				txtHistoriaclinica.Text = ProximoNumeroHistoriaClinica();
			}
			else if (e.KeyCode == Keys.F3 & Operators.CompareString(txtHistoriaclinica.Text, "", false) > 0)
			{
				BuscarPorHistoriaClinica(txtHistoriaclinica.Text);
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
		}

		private void ComCargarCapacitacion_Click(object sender, EventArgs e)
		{
			var prog = new frmCapacitacion();
			prog.NombreEmpleado = impresion.Text;
			prog.CodigoEmpleado = Codigo.Text;
			prog.ShowDialog();
		}



		private void Button5_Click(object sender, EventArgs e)
		{
			var arglcod = txtNomParroquia;
			CBuscador(ref arglcod, 24);
			txtNomParroquia = arglcod;
		}

		private void BtnCanton_Click(object sender, EventArgs e)
		{
			var arglcod = TxtNomCanton;
			CBuscador(ref arglcod, 23);
			TxtNomCanton = arglcod;
		}

		private void DEEP01_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.F2 & e.Alt == true & Codigo.Text.Length > 0)
			{
				try
				{
					var prog = new daxNota.ClassNota();
					prog.verNotaReferencia("EMP", Codigo.Text, datosEmpresa.usr, datosEmpresa.strConxAdcom);
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
		private void btnPaisNace_Click(object sender, EventArgs e)
		{
			var arglcod = txtPaisNace;
			CBuscador(ref arglcod, 12);
			txtPaisNace = arglcod;
		}

		private void btnProvNace_Click(object sender, EventArgs e)
		{
			var arglcod = txtProvNace;
			CBuscador(ref arglcod, 13);
			txtProvNace = arglcod;
		}

		private void btnCiudadNace_Click(object sender, EventArgs e)
		{
			var arglcod = txtCiudadNace;
			CBuscador(ref arglcod, 14);
			txtCiudadNace = arglcod;
		}

		private void btnRegionNace_Click(object sender, EventArgs e)
		{
			var arglcod = txtRegionNace;
			CBuscador(ref arglcod, 25);
			txtRegionNace = arglcod;
		}

		private void btnRegion_Click(object sender, EventArgs e)
		{
			var arglcod = txtRegion;
			CBuscador(ref arglcod, 25);
			txtRegion = arglcod;
		}

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

		private void Button7_Click(object sender, EventArgs e)
		{
			var progRet = new DaxNomReten.frmRetencion(Codigo.Text, impresion.Text);
			progRet.ShowDialog();
			progRet.Dispose();
		}

		private void TipoIdent_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (TipoIdent.SelectedIndex == 0)
				TipoIdent.SelectedIndex = 1;
		}

	}
}