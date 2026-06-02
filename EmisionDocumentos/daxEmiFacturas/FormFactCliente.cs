using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using classMenSistem;
using ctrlReferencia;
using ClassDoc;
using DattCom;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;
//using iTextSharp.tool.xml;
using DtosMall;
using DaxComercia;
using SolicitudAutSRI;
using System.Collections.Generic;
using DaxValDocElec;
//using System.Linq;
using System.Net.Mail;
using System.Net;
using DaxDocElectronicos;
using System.Linq;
using static DaxDocElectronicos.Auxiliares;
using ClassFelec;

namespace DctosEmi
{
	public partial class FormFactCliente: Form
	{
        DatosDocFacturacion DatosFacturacion = new DatosDocFacturacion();
        internal sesSys.OpcDoc propiedadesDoc;
		directMnt.DirectorioAlex opalex = new directMnt.DirectorioAlex();
		internal AdcDoc datADCDOC;
		internal DaxComercia.classPagosDoc clasePagos = new DaxComercia.classPagosDoc();
		internal adcDescto.descDocumento claseDescuentos = new adcDescto.descDocumento();
		internal IvaRett.docImpuestos claseImpuestos = new IvaRett.docImpuestos();
		internal daxAccs.propiedadesDaxAuto accesosLocalizados = new daxAccs.propiedadesDaxAuto();

		docMallaArticulo mallaArticulo = new docMallaArticulo();

		ctrlReferencia.controlReferencial clasref = new controlReferencial();
		DataTable dtDetalleDocumento = new DataTable();

		internal DctosEmi.docTotals totalesDocumento = new DctosEmi.docTotals();
        daxContaDoc.AsientosContables asientosContables = new daxContaDoc.AsientosContables();
        string claseDocDefault = "FAC";
		string tipoDocDefault = "FAC";
		decimal ivaM = 0;

		bool iniciaConNuevoDOc = false;
		internal Boolean esSoloConsulta = false;
		Boolean entregasPendientes = false;
		internal Boolean esDeLiquidacion = false;
		Boolean debeActualizarContacto = false;

		internal idDocumento idDocumentoActual = new idDocumento();
		internal idDocumento idDocumentoSoporte = new idDocumento();
		idDocumento idDocumentoParaGenerar = new idDocumento();

		internal string codCliente = "";
		Boolean saltarEventoNumero = false;
		Boolean saltaEventosMalla = false;

		internal int operacionEnCurso = 0; // 0 sin operacion delcarada, 1 nuevo registro, 2 modificando registro
		internal int sinOperacion = 0;
		internal int nuevoRegistro = 1;
		internal int modificandoRegistro = 2;

		string memTipoDoc = "";
		string memVendedor = "";
		string memBodega = "";

		string queSucF = "";
		string queDocF = "";
		decimal queNumF = 0;
		decimal IdClaveDocF = 0;

		string PathFile = "";
		short tipoEmision = 0;

		public string urlE = "";
		string PathFileE = "";
		string queSucE = "";
		string queDocE = "";
		decimal queNumE = 0;
		short tipoEmisionE = 0;
		string queClaveSRIE = "";
		double IdClaveDocFE = 0;
		string ErroresE = "";
		string correoElectronicoDefectoE = "";
		List<string> colecError = new List<string>();
		string queCodigoCliente = "";
		string correoElectronico = "";
		Auxiliares aux = new Auxiliares();
		private AdcFelec fel;

		public FormFactCliente(string clasdef, string tipdef, bool nuevo = false, Boolean esConsulta = false, Boolean generarFactura = false, Boolean desdeEstdoCta = false, idDocumento idDocViene = null, string sisMedico = "")
		{
			InitializeComponent();
			esSoloConsulta = esConsulta;
			if (clasdef.Length>0) claseDocDefault = clasdef;
			if (tipdef.Length > 0) tipoDocDefault = tipdef;
			CargarValoresIniciales();
			iniciaConNuevoDOc = nuevo;

			if (idDocViene == null) idDocViene = new idDocumento();
			if (idDocViene.idClave > 0 && esConsulta)
			{
				idDocumentoActual = idDocViene;
				cmbDocumento.SelectedValue = idDocViene.Tipo;
			}
			else if (idDocViene.idClave > 0 && generarFactura)
			{
				MessageBox.Show("decision");
				idDocumentoParaGenerar = idDocViene;
				cmbDocumento.SelectedValue = idDocViene.Tipo;
			}
		}
		private void CargarValoresIniciales()
		{
			// Configuración del DataGridView
			malla.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
			malla.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
			
			this.txtfecha.ValueChanged -= new System.EventHandler(this.txtfecha_ValueChanged);
			
			txtfecha.Value = docUtils.DaxNow();

			idDocumentoActual.Tipo = tipoDocDefault;
			idDocumentoActual.familia = claseDocDefault;
			idDocumentoActual.Sucursal = datosEmpresa.suc;
			claseImpuestos.cargar(datosEmpresa.strConxIvaret, txtfecha.Value);
			valoresPredefinidosEmpresa.cargaValores();
			valoresPredefinidosSucursal.cargarValores();
			txtNroID.Text = valoresPredefinidosSucursal.idtributario;
			txtNroID.Enabled = valoresPredefinidosSucursal.autCambiaPtoVta;			
			LlenarCombos();
			CargarPredefinidosDocumento();
			this.txtfecha.ValueChanged += new System.EventHandler(this.txtfecha_ValueChanged);
			this.Text += "  " + datosEmpresa.nomEmpresa + " EQUIPO: " + valoresPredefinidosSucursal.nomPuntoVta;

			// 👇 Suscribirse a eventos para TRA_SNIVA (compatible con .NET Framework 4)
			this.malla.CellFormatting += new DataGridViewCellFormattingEventHandler(malla_CellFormatting);
			this.malla.CellParsing += new DataGridViewCellParsingEventHandler(malla_CellParsing);

			// Opcional: configurar valor por defecto visual
			if (malla.Columns.Contains("TRA_SNIVA"))
			{
				malla.Columns["TRA_SNIVA"].DefaultCellStyle.NullValue = "NO";
			}

			// En CargarValoresIniciales o después de configurar la malla:
			if (malla.Columns.Contains("TRA_SNIVA"))
			{
				malla.Columns["TRA_SNIVA"].ReadOnly = false; // Permitir edición
				malla.Columns["TRA_SNIVA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			}

		}
		private void formFacPv_Load(object sender, EventArgs e)
		{
			if (idDocumentoActual.idClave != 0)
			{
				cargarDatosFactura(idDocumentoActual.Sucursal, idDocumentoActual.Tipo, idDocumentoActual.idClave);
			}
			else if (idDocumentoParaGenerar.idClave > 0)
			{
				iniciarNuevoDocumento();
				copiarDocumento(idDocumentoParaGenerar, true);
			}
			else
			{
				if (iniciaConNuevoDOc) iniciarNuevoDocumento();
			}
			ConfiguracionCorreo.CargarConfiguracion(datosEmpresa.strConIniSis);
			ConfiguracionCorreo.CargarParametroSRI(datosEmpresa.strConIniSis, datosEmpresa.Emp_codigo);
			prepararBotones();
			fel = new AdcFelec(datosEmpresa.strConxAdcom);
			fel = AdcFelec.Buscar("");
		}

		//private void LlenarCombos()
		//{
		//    recordarOpciones();
		//    DaxCombobx.CargCmbBox cmb = new DaxCombobx.CargCmbBox();
		//    cmb.DaxCombosDoc(claseDocDefault, "", false, datosEmpresa.strConxAdcom, ref cmbDocumento);
		//    cmb.DaxCombosBods(datosEmpresa.suc, false, datosEmpresa.strConIniSis, ref cmbBodega);
		//    cmb.DaxCombosVend(datosEmpresa.strConxAdcom, ref cmbVendedor, false);

		//    try
		//    {
		//        if (memTipoDoc.Length > 0)
		//        {
		//            cmbDocumento.SelectedValue = memTipoDoc;
		//        }
		//        else
		//        {
		//            cmbDocumento.SelectedValue = tipoDocDefault;
		//        }
		//    }
		//    catch { };
		//    if (cmbDocumento.SelectedValue == null) cmbDocumento.SelectedIndex = 0;
		//    idDocumentoActual.Tipo = cmbDocumento.SelectedValue.ToString();
		//    if (memBodega.Length > 0) { cmbBodega.SelectedValue = memBodega; } else { cmbBodega.SelectedIndex = 0; }
		//    if (cmbVendedor.Items.Count > 0)
		//    {
		//        if (memVendedor.Length > 0) { cmbVendedor.SelectedValue = memVendedor; } else { cmbVendedor.SelectedIndex = 0; }
		//    }
		//}

		private void LlenarCombos()
		{
			recordarOpciones();
			DaxCombobx.CargCmbBox cmb = new DaxCombobx.CargCmbBox();
			cmb.DaxCombosDoc(claseDocDefault, "", false, datosEmpresa.strConxAdcom, ref cmbDocumento);

			// Intentar llenar bodegas, si falla ocultar el combo
			try
			{
				cmb.DaxCombosBods(datosEmpresa.suc, false, datosEmpresa.strConIniSis, ref cmbBodega);

				if (cmbBodega.Items.Count == 0)
				{
					cmbBodega.Visible = false;
					lbBodega.Visible = false;
				}
			}
			catch (Exception ex)
			{
				// Si hay error, ocultar el combo de bodega
				cmbBodega.Visible = false;
				lbBodega.Visible = false;
				System.Diagnostics.Debug.WriteLine($"Error cargando bodegas: {ex.Message}");
			}

			cmb.DaxCombosVend(datosEmpresa.strConxAdcom, ref cmbVendedor, false);

			// Configurar Documento
			try
			{
				if (memTipoDoc.Length > 0)
				{
					if (ValorExisteEnCombo(cmbDocumento, memTipoDoc))
						cmbDocumento.SelectedValue = memTipoDoc;
					else if (cmbDocumento.Items.Count > 0)
						cmbDocumento.SelectedIndex = 0;
				}
				else
				{
					if (cmbDocumento.Items.Count > 0)
						cmbDocumento.SelectedValue = tipoDocDefault;
				}
			}
			catch { }

			if (cmbDocumento.SelectedValue == null && cmbDocumento.Items.Count > 0)
				cmbDocumento.SelectedIndex = 0;

			if (cmbDocumento.SelectedValue != null)
				idDocumentoActual.Tipo = cmbDocumento.SelectedValue.ToString();

			// Configurar Bodega - CON VALIDACIÓN SIN ContainsKey
			if (cmbBodega.Visible && cmbBodega.Items.Count > 0)
			{
				if (memBodega.Length > 0)
				{
					try
					{
						if (ValorExisteEnCombo(cmbBodega, memBodega))
							cmbBodega.SelectedValue = memBodega;
						else
							cmbBodega.SelectedIndex = 0;
					}
					catch { cmbBodega.SelectedIndex = 0; }
				}
				else
				{
					cmbBodega.SelectedIndex = 0;
				}
			}

			// Configurar Vendedor - CON VALIDACIÓN SIN ContainsKey
			if (cmbVendedor.Items.Count > 0)
			{
				if (memVendedor.Length > 0)
				{
					try
					{
						if (ValorExisteEnCombo(cmbVendedor, memVendedor))
							cmbVendedor.SelectedValue = memVendedor;
						else
							cmbVendedor.SelectedIndex = 0;
					}
					catch { cmbVendedor.SelectedIndex = 0; }
				}
				else
				{
					cmbVendedor.SelectedIndex = 0;
				}
			}
		}

		// Método auxiliar para verificar si un valor existe en el ComboBox
		private bool ValorExisteEnCombo(ComboBox combo, string valor)
		{
			if (combo == null || combo.Items.Count == 0 || string.IsNullOrEmpty(valor))
				return false;

			try
			{
				// Intentar buscar por SelectedValue (si está en modo DataSource)
				foreach (var item in combo.Items)
				{
					// Si está en modo DataSource con ValueMember
					if (combo.ValueMember != null && combo.ValueMember != "")
					{
						var row = item as DataRowView;
						if (row != null)
						{
							string valorItem = row[combo.ValueMember]?.ToString();
							if (valorItem == valor)
								return true;
						}
					}
					else
					{
						// Si es un ComboBox simple
						string textoItem = item.ToString();
						if (textoItem == valor)
							return true;
					}
				}

				// También intentar encontrar por SelectedItem
				object itemEncontrado = null;
				try { itemEncontrado = combo.Items.Cast<object>().FirstOrDefault(x => x.ToString() == valor); }
				catch { }

				return itemEncontrado != null;
			}
			catch
			{
				return false;
			}
		}


		private void CargarPredefinidosDocumento()
{
			propiedadesDoc = new sesSys.OpcDoc();
			propiedadesDoc.Cargar(ref idDocumentoActual.Tipo, ref idDocumentoActual.Sucursal);
			accesosLocalizados.iniciar(datosEmpresa.codEmpresa, datosEmpresa.usr, datosEmpresa.strConxSyscod);
			accesosLocalizados.cargarAccesoDoc(idDocumentoActual.Tipo);

			
			AutorizacionesFac.HabilitarOpcionesDocumento(this);

			//HabilitarOpcionesDocumento();
		}
		//private void HabilitarOpcionesDocumento()
		//{
		//	HabilitarSoporte((propiedadesDoc.TipoSoporteObligatorio.Length > 0 && propiedadesDoc.TipoSoporteObligatorio != "ORP") || datosAuxiliares.tieneDatoDocumento("DocumentoReferencia", propiedadesDoc));

		//	cmbVendedor.Visible = (datosAuxiliares.tieneDatoDocumento("Vendedor", propiedadesDoc));
		//	lbVendedor.Visible = cmbVendedor.Visible;

		//	labNroLote.Visible = (datosAuxiliares.tieneDatoDocumento("NúmeroLote", propiedadesDoc));
		//	txtNroLote.Visible = labNroLote.Visible;

		//	btnDescuentos.Visible = (datosAuxiliares.tieneDatoDocumento("DescuentoDocumento", propiedadesDoc));

		//	btnExportacion.Visible = (datosAuxiliares.tieneDatoDocumento("Transporte", propiedadesDoc));

		//	btnPendientes.Visible = true;
		//	// chequear lectura de parametros en varbl
		//	//btnContabiliza.Visible = (datosEmpresa.auto.Substring(3, 1) == "1" && propiedadesDoc.noCtbLinea != "X" && propiedadesDoc.SNContabilizar != 0);
		//	cmbBodega.Visible = (datosAuxiliares.tieneDatoDocumento("Bodega", propiedadesDoc));
		//	lbBodega.Visible = cmbBodega.Visible;

		//	if (accesosLocalizados.sinRegistro==false) registrarAccesosLocalizadosDocumento();
		//}
		private void prepararBotones()
		{
			Boolean inicio = (operacionEnCurso == sinOperacion);
			Boolean nuevo = (operacionEnCurso == nuevoRegistro);
			Boolean modificando = (operacionEnCurso == modificandoRegistro);
			Boolean docAnulado = false;
			try
			{
				//docAnulado = (datADCDOC.Doc_Estado == 0 && modificando);
			}
			catch { }

			btnAbre.Enabled = inicio;
			btnNuevo.Enabled = inicio;
			btnSubir.Enabled= (!inicio && !docAnulado);
			btnBajar.Enabled = (!inicio && !docAnulado);

			btnCopia.Enabled = nuevo;

			btnAnula.Enabled = (modificando && !docAnulado);
			btnElimina.Enabled = modificando;
			btnEnviar.Enabled  = modificando;
			btnGraba.Enabled = (!inicio && !docAnulado);
			btnRegistra.Enabled = btnGraba.Enabled;
			btnEnviar.Enabled = (modificando && !docAnulado);
			btnCierra.Enabled = !inicio;
			btnConsolida.Enabled = nuevo;

			btnPagos.Enabled = btnGraba.Enabled;
			btnDescuentos.Enabled = btnGraba.Enabled;
			//OJO
			//ptoVenta.Enabled = inicio;
			//OJO
			btnPorcentajeIva.Enabled = btnDescuentos.Enabled;
			btnContabiliza.Enabled = btnGraba.Enabled;
			//btnExportacion.Enabled = btnGraba.Enabled;
			btnPendientes.Enabled = btnGraba.Enabled;

			btnBarras.Enabled = (!inicio) && !docAnulado;
			btnAgrupa.Enabled = (btnBarras.Enabled && btnBarras.Checked);

			panel1.Enabled = (!inicio);
			malla.Enabled = (!inicio);

			cmbDocumento.Enabled = (inicio);
			txtcedula.Enabled = (!docAnulado);
			//if (datosEmpresa.usr.ToUpper() == "ADMINISTRADOR" || inicio ) return;
			if (accesosLocalizados.sinRegistro == false)
			{
				if (nuevo)
				{
					btnGraba.Enabled = (btnGraba.Enabled && (accesosLocalizados.Crear)); //|| (accesosLocalizados.Modificar && modificando));
					btnRegistra.Enabled = (btnRegistra.Enabled && (btnGraba.Enabled && accesosLocalizados.Imprimir));
				}
				else if (modificando)
				{
					btnGraba.Enabled = (btnGraba.Enabled && (accesosLocalizados.Modificar)); //|| (accesosLocalizados.Modificar && modificando));
					btnRegistra.Enabled = (btnRegistra.Enabled && (btnGraba.Enabled && accesosLocalizados.Modificar && accesosLocalizados.Imprimir));
				}
				btnEnviar.Enabled = (btnEnviar.Enabled && accesosLocalizados.Imprimir); //(accesosLocalizados.Imprimir && !inicio);
				btnNuevo.Enabled = (accesosLocalizados.Crear && btnNuevo.Enabled);
				btnElimina.Enabled = (accesosLocalizados.Eliminar && btnElimina.Enabled);
				btnAnula.Enabled = (accesosLocalizados.Anular && btnAnula.Enabled);
				btnCopia.Enabled  = (accesosLocalizados.Crear && btnCopia.Enabled) ;
				btnConsolida.Enabled  = (accesosLocalizados.Crear && btnConsolida.Enabled);

			}

			//if (inicio) return;

			if (esSoloConsulta == true || docAnulado)
			{
				btnGraba.Enabled = false;
				btnRegistra.Enabled = false;
				btnElimina.Enabled = false;
				btnAnula.Enabled = false;
				//SALE QUE ES CONSULTA Y ES ERRROR
				//if (datADCDOC.Doc_Estado == 1) btnElimina.Enabled = (datosEmpresa.usr.ToUpper() == "ADMINISTRADOR");
				if (datADCDOC != null && datADCDOC.Doc_Estado == 1)
				{
					btnElimina.Enabled = (datosEmpresa.usr.ToUpper() == "ADMINISTRADOR");
				}
				else
				{
					btnElimina.Enabled = false; // o lo que tenga sentido en tu lógica
				}
			}
			if (propiedadesDoc.ImprimirDoc == "N") btnEnviar.Visible = false;

		}

		private void prepararBotonesM()
		{
			Boolean inicio = (operacionEnCurso == sinOperacion);
			Boolean nuevo = (operacionEnCurso == nuevoRegistro);
			Boolean modificando = (operacionEnCurso == modificandoRegistro);
			Boolean docAnulado = false;
			try
			{
				//docAnulado = (datADCDOC.Doc_Estado == 0 && modificando);
			}
			catch { }

			btnAbre.Enabled = inicio;
			btnNuevo.Enabled = inicio;
			btnSubir.Enabled = (!inicio && !docAnulado);
			btnBajar.Enabled = (!inicio && !docAnulado);

			btnCopia.Enabled = nuevo;

			btnAnula.Enabled = inicio;
			btnElimina.Enabled = inicio;
			btnEnviar.Enabled = modificando;
			btnGraba.Enabled = (inicio);
			btnRegistra.Enabled = btnGraba.Enabled;
			btnEnviar.Enabled = (modificando && !docAnulado);
			btnCierra.Enabled = !inicio;
			btnConsolida.Enabled = nuevo;

			btnPagos.Enabled = btnGraba.Enabled;
			btnDescuentos.Enabled = btnGraba.Enabled;
			//OJO
			//ptoVenta.Enabled = inicio;
			//OJO
			btnPorcentajeIva.Enabled = btnDescuentos.Enabled;
			btnContabiliza.Enabled = btnGraba.Enabled;
			//btnExportacion.Enabled = btnGraba.Enabled;
			btnPendientes.Enabled = btnGraba.Enabled;

			btnBarras.Enabled = (!inicio) && !docAnulado;
			btnAgrupa.Enabled = (btnBarras.Enabled && btnBarras.Checked);

			panel1.Enabled = (!inicio);
			malla.Enabled = (!inicio);

			cmbDocumento.Enabled = (inicio);
			txtcedula.Enabled = (!docAnulado);
			//if (datosEmpresa.usr.ToUpper() == "ADMINISTRADOR" || inicio ) return;
			if (accesosLocalizados.sinRegistro == false)
			{
				if (nuevo)
				{
					btnGraba.Enabled = (btnGraba.Enabled && (accesosLocalizados.Crear)); //|| (accesosLocalizados.Modificar && modificando));
					btnRegistra.Enabled = (btnRegistra.Enabled && (btnGraba.Enabled && accesosLocalizados.Imprimir));
				}
				else if (modificando)
				{
					btnGraba.Enabled = (btnGraba.Enabled && (accesosLocalizados.Modificar)); //|| (accesosLocalizados.Modificar && modificando));
					btnRegistra.Enabled = (btnRegistra.Enabled && (btnGraba.Enabled && accesosLocalizados.Modificar && accesosLocalizados.Imprimir));
				}
				btnEnviar.Enabled = (btnEnviar.Enabled && accesosLocalizados.Imprimir); //(accesosLocalizados.Imprimir && !inicio);
				btnNuevo.Enabled = (accesosLocalizados.Crear && btnNuevo.Enabled);
				btnElimina.Enabled = (accesosLocalizados.Eliminar && btnElimina.Enabled);
				btnAnula.Enabled = (accesosLocalizados.Anular && btnAnula.Enabled);
				btnCopia.Enabled = (accesosLocalizados.Crear && btnCopia.Enabled);
				btnConsolida.Enabled = (accesosLocalizados.Crear && btnConsolida.Enabled);

			}

			//if (inicio) return;

			if (esSoloConsulta == true || docAnulado)
			{
				btnGraba.Enabled = false;
				btnRegistra.Enabled = false;
				btnElimina.Enabled = false;
				btnAnula.Enabled = false;
				//SALE QUE ES CONSULTA Y ES ERRROR
				//if (datADCDOC.Doc_Estado == 1) btnElimina.Enabled = (datosEmpresa.usr.ToUpper() == "ADMINISTRADOR");
				if (datADCDOC != null && datADCDOC.Doc_Estado == 1)
				{
					btnElimina.Enabled = (datosEmpresa.usr.ToUpper() == "ADMINISTRADOR");
				}
				else
				{
					btnElimina.Enabled = false; // o lo que tenga sentido en tu lógica
				}
			}
			if (propiedadesDoc.ImprimirDoc == "N") btnEnviar.Visible = false;

		}

		private void registrarAccesosLocalizadosDocumento()
		{
			if (accesosLocalizados.sinRegistro) return;

			txtnumero.Enabled = accesosLocalizados.NúmeroDocumento;
			txtNroID.Enabled = txtnumero.Enabled;
			txtfecha.Enabled = accesosLocalizados.FechaDocumento;

			cmbBodega.Enabled = accesosLocalizados.Bodega;
			if (accesosLocalizados.BodegaFija.Length > 0)
			{
				cmbBodega.SelectedValue = accesosLocalizados.BodegaFija;
				cmbBodega.Enabled = false;
			}

			cmbVendedor.Enabled = accesosLocalizados.Vendedor;
			if (accesosLocalizados.VendedorFijo.Length > 0)
			{
				cmbVendedor.SelectedValue = accesosLocalizados.VendedorFijo;
				cmbVendedor.Enabled = false;
			}

			btnPagos.Visible = (accesosLocalizados.FormaDePago || accesosLocalizados.FormaDePagoFijo.Length > 0);
			btnContabiliza.Visible = accesosLocalizados.Contabilidad;
			btnPorcentajeIva.Visible = accesosLocalizados.Impuestos;
			btnDescuentos.Visible = accesosLocalizados.DescuentoDocumento;
		}

		

		private void LlenarComboDocReferencia()
		{
			idDocumentoActual.Tipo = cmbDocumento.SelectedValue.ToString();
			propiedadesDoc.Cargar(ref idDocumentoActual.Tipo, ref idDocumentoActual.Sucursal);
			string Ssql = "";

			if (propiedadesDoc.TipoSoporteObligatorio != null && propiedadesDoc.TipoSoporteObligatorio.Length > 0)
			{
				Ssql = "SELECT opc_nombre, opc_documento, opc_tipo FROM adcopc WHERE OPC_DOCUMENTO = '" + propiedadesDoc.TipoSoporteObligatorio + "' order by opc_documento ";
				entregasPendientes = true;
			}
			else
			{
				Ssql = "SELECT opc_nombre, opc_documento, opc_tipo FROM adcopc  WHERE OPC_DOCUMENTO > '' order by opc_documento ";
				entregasPendientes = false;
			}

			using (DataTable dtt = utilBasDatos.utilBasDatos.leerTablas(Ssql, datosEmpresa.strConxAdcom))
			{
				cmbDocumentoSustento.DataSource = dtt;
				cmbDocumentoSustento.DisplayMember = "opc_nombre";
				cmbDocumentoSustento.ValueMember = "opc_documento";
			}
		}

		private void BtnSalir_Click(object sender, EventArgs e)
		{
			if (classMenSistem.mensajesErrorDocumento.ConfirmaCerrar()) this.Close();
		}

		private void BuscaCliente(string buscador)
		{
			directMnt.BuscaClien directorio = new directMnt.BuscaClien();
			string cliente = "C";
			string codigo = "";
			string nombre = "";
			string conalias = "N";
			string connuevo = "N";
			codigo = directorio.IniBuscaCliOPro(ref cliente, ref nombre, ref conalias, ref connuevo);
			if ((codigo + "").Length > 0) cargarDatosCliente(codigo);
			directorio.Dispose();
		}
		private void cargarDatosCliente(string codigo = "")
		{
			// utilBasDatos datt = new utilBasDatos();
			if (codigo != "")
			{
				string solocodigo = "";
				Boolean x = false;
				opalex = new directMnt.DirectorioAlex();
				opalex.CargarAlex(ref codigo, ref x, ref solocodigo);
				if (opalex.codigo == null) codigo = ""; else codigo = opalex.codigo;
				if (codigo.Length > 0)
				{
					codCliente = opalex.codigo;
					txtcedula.Text = opalex.CiRuc;
					txtnombrecliente.Text = opalex.NombreImpresion;
					txtdireccion.Text = opalex.direccion;
					txtCorreElectronico.Text = opalex.correoElectronico;
					txttelefono.Text = opalex.telefono1;
				}
			}
			if (codigo == "")
			{
				codCliente = "";
				txtcedula.Text = "";
				txtnombrecliente.Text = "";
				txtdireccion.Text = "";
				txtCorreElectronico.Text = "";
				txttelefono.Text = "";
				opalex = null;
			}
			debeActualizarContacto = false;
		}
        private Boolean cargarDatosFactura(string SUC, string TIPO, double IDCLAVE)
		{
			Boolean resp = false;
			if (IDCLAVE != 0)
			{
				datADCDOC = new AdcDoc(datosEmpresa.strConxAdcom);
				datADCDOC = AdcDoc.Buscar(" doc_sucursal = '" + SUC + "' and opc_documento ='" + TIPO + "' and idclavedoc = " + IDCLAVE.ToString());
				if (datADCDOC != null)
				{
					cargarDatosCliente(datADCDOC.Doc_codper);
					moverClaseAcontroles();
					if (Convert.ToInt32(datADCDOC.Doc_Estado) == 0) mensajesDocumento.Text = "DOCUMENTO ANULADO : " + datADCDOC.MotivoAnulacion;
					cargarDetalleArticulos(idDocumentoActual.Sucursal, idDocumentoActual.Tipo, idDocumentoActual.idClave, "ADCTRA");
					cargarFormaDePago(idDocumentoActual, "ADCPAG");
					totalizar();
					operacionEnCurso = modificandoRegistro;
					if (datADCDOC.estadoSri=="Autorizado" && datADCDOC.fechaAutorizacion!="")
					{
						prepararBotonesM();
					}
					else
					{
						prepararBotones();
					}
					
					resp = true;
					txtnumero.Enabled = false;
					debeActualizarContacto = false;
				}
			}
			else { }
			return resp;
		}

		private void cargarDetalleArticulos(string suc, string tip, double idClave, string tablatra)
		{
			DatosDocFacturacion dcut = new DatosDocFacturacion();
			ModelaMalla  dcut2 = new ModelaMalla();

			dtDetalleDocumento = utilBasDatos.utilBasDatos.leerTablas(dcut.armarSqlLecturaTransFacturas( tablatra, suc, tip, idClave), datosEmpresa.strConxAdcom);
			if (dtDetalleDocumento == null) return;
			malla.DataSource = dtDetalleDocumento;
			dcut2.diseñarMallaFacturas(ref malla, ref propiedadesDoc,accesosLocalizados);
			malla.Columns["Existencia"].Visible = valoresPredefinidosEmpresa.existenciaEnLineas;
		}
		private void cargarDetalleArticulosConsolidacion(string listaDocumentos)
		{
			DctosEmi.armarConsTra dcut = new DctosEmi.armarConsTra();
			DctosEmi.diseñarMalla dcut2 = new DctosEmi.diseñarMalla();

			dtDetalleDocumento = utilBasDatos.utilBasDatos.leerTablas(dcut.armarSqlLecturaTraFacConsolida("ADCTRA", listaDocumentos), datosEmpresa.strConxAdcom);
			dcut = null;
			if (dtDetalleDocumento == null) return;
			malla.DataSource = dtDetalleDocumento;
			if (malla.Rows.Count > 0) dcut2.diseñarMallaFacCli(ref malla, ref propiedadesDoc);

			dcut = null;
			dcut2 = null;
		}
		private void cargarFormaDePago(idDocumento iddoc, string tabla)
		{
			clasePagos = new DaxComercia.classPagosDoc
			{
				strConx = datosEmpresa.strConxAdcom,
				DocSucursal = iddoc.Sucursal,
				Doctipo = iddoc.Tipo,
				idClaveDoc = iddoc.idClave,
				DocNumero = iddoc.numero,
				DocFecha = iddoc.fecha
			};
			clasePagos.cargarPagosDocumento(tabla);
		}
		private void moverClaseAcontroles()
		{
			moverCabezera();
			moverOtrosValores();
		}
		private void moverCabezera()
		{

			idDocumentoActual.idClave = Convert.ToDouble(datADCDOC.IdClaveDoc);
			codCliente = datADCDOC.Doc_codper;

			txtnumero.Text = datADCDOC.Doc_numero.ToString();
			if (datADCDOC.Doc_NroIdDoc.ToString() != "") txtNroID.Text = datADCDOC.Doc_NroIdDoc.ToString();
			txtfecha.Text = datADCDOC.Doc_fecha.ToShortDateString();
			txtcedula.Text = datADCDOC.Doc_CiRuc;
			txtnombrecliente.Text = datADCDOC.Doc_NombreImp;
			txtdireccion.Text = datADCDOC.Doc_Direccion;

			txtDetalle.Text = datADCDOC.Doc_detalle;
			cmbVendedor.SelectedValue = datADCDOC.Doc_venabre;
		}
		private void moverOtrosValores()
		{
			claseDescuentos = new adcDescto.descDocumento();
			claseImpuestos = new IvaRett.docImpuestos();
			claseDescuentos.nombreDes[0] = datADCDOC.Doc_nombredes1;
			claseDescuentos.nombreDes[1] = datADCDOC.Doc_nombredes2;
			claseDescuentos.nombreDes[2] = datADCDOC.Doc_nombredes3;

			claseDescuentos.porcentajeDes[0] = Convert.ToDouble(datADCDOC.Doc_porcendes1);
			claseDescuentos.porcentajeDes[1] = Convert.ToDouble(datADCDOC.Doc_porcendes2);
			claseDescuentos.porcentajeDes[2] = Convert.ToDouble(datADCDOC.Doc_porcendes3);

			claseDescuentos.valorDes[0] = Convert.ToDouble(datADCDOC.Doc_valordes1);
			claseDescuentos.valorDes[1] = Convert.ToDouble(datADCDOC.Doc_valordes2);
			claseDescuentos.valorDes[2] = Convert.ToDouble(datADCDOC.Doc_valordes3);

			claseImpuestos.impstoPorcentaje1 = Convert.ToDouble(datADCDOC.Doc_porceniva);
			claseImpuestos.impstoNombre1 = "IVA";

		}
	

		private void btnCierra_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Confirma cerrar el documento actual ?", "Cerrar documento sin grabar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No) return;
			if (esSoloConsulta) Close();
			limpiarDatos();
		}
		private void limpiarDatos()
		{
			//txtnumero.Enabled = true;
			datADCDOC = new AdcDoc(datosEmpresa.strConxAdcom);
			clasePagos = new DaxComercia.classPagosDoc();
			claseDescuentos = new adcDescto.descDocumento();
			totalesDocumento = new DctosEmi.docTotals();
			clasref = new controlReferencial();
			txtcedula.Text = "";
			txtCorreElectronico.Text = "";
			txtDetalle.Text = "";
			txtdireccion.Text = "";
			txtnombrecliente.Text = "";
			txtnumero.Text = "";
			txttelefono.Text = "";
			mensajesDocumento.Text = "";
			idDocumentoActual.idClave = 0;
			esDeLiquidacion = false;
			debeActualizarContacto = false;
			idDocumentoActual = new idDocumento
			{
				fecha = txtfecha.Value
			};
			idDocumentoSoporte = new idDocumento();
			dtDetalleDocumento = new DataTable();
			malla.DataSource = null;
			presentarTotales();
			edTotal.Text = totalesDocumento.TotVta.ToString("#,0.00");
			clasePagos = new DaxComercia.classPagosDoc();
			txtNroID.Text = valoresPredefinidosSucursal.idtributario ;
			txtfecha.Value = docUtils.DaxNow();
			operacionEnCurso = 0;
			prepararBotones();
			//            InicializarMalla();
		}
		private void InicializarMalla()
		{
			//  this.malla.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.malla_CellValueChanged);
			DatosDocFacturacion dcut = new DatosDocFacturacion();
			ModelaMalla dcut2 = new ModelaMalla();

			dtDetalleDocumento = utilBasDatos.utilBasDatos.leerTablas(dcut.armarSqlLecturaTransFacturas("ADCTRA", datosEmpresa.suc , idDocumentoActual.Tipo , idDocumentoActual.idClave ), datosEmpresa.strConxAdcom);

//			DctosEmi.armarConsTra dcut = new DctosEmi.armarConsTra();
	//		dtDetalleDocumento = utilBasDatos.utilBasDatos.leerTablas(dcut.(propiedadesDoc, "adctra", "", "", 0), datosEmpresa.strConxAdcom);
			if (dtDetalleDocumento == null) return;
			


			malla.DataSource = dtDetalleDocumento;
			dtDetalleDocumento.Rows.Add(dtDetalleDocumento.NewRow());
//			DctosEmi.diseñarMalla dcut2 = new DctosEmi.diseñarMalla();
			dcut2.diseñarMallaFacturas (ref malla, ref propiedadesDoc,accesosLocalizados);
			dcut2 = null;
			}
		
		private void malla_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex < 0 || e.ColumnIndex < 0 || saltaEventosMalla)
				return;

			string nomCol = malla.Columns[e.ColumnIndex].Name.ToUpper();

			// Recalcular si se modificó una columna relevante
			if (nomCol == "TRA_CANTIDAD" || nomCol == "TRA_PRECUNI" ||
				nomCol == "TRA_PORCENDES" || nomCol == "TRA_SNIVA" ||
				nomCol == "TRA_PORCENIVA")
			{
				totalizar();
			}
		}


		#region EVENTOS DE CONTROLES
		#region EVENTOS DE BOTONES
		private void btnBarras_Click(object sender, EventArgs e)
		{
			btnAgrupa.Enabled = btnBarras.Checked;
		}

		private void btnEnviar_Click(object sender, EventArgs e)
		{
			imprimirDocumento();
		}
		//private void imprimirDocumento()
		//{
		//	if (accesosLocalizados.NroImpresiones > 0 && accesosLocalizados.NroImpresiones <= datADCDOC.Doc_Adicional1)
		//	{ MessageBox.Show("Ha llegado al límite de impresiones permitidas", "Imprimir documentos", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
		//	ImpresionDocumentosDax.ImprimeDocumentoDoble impProg = new ImpresionDocumentosDax.ImprimeDocumentoDoble(datosEmpresa.nombreBaseIvaret, datosEmpresa.strConxAdcom, datosEmpresa.strConxIvaret, datosEmpresa.strConxSyscod, datosEmpresa.strConxDaxpro, datosEmpresa.codEmpresa, datosEmpresa.pathServer);
		//	int imp = impProg.ImpDoc(idDocumentoActual, "A", "", false, false);
		//	datADCDOC.Doc_Adicional1 = imp;
		//}

		private void imprimirDocumento()
		{
			if (accesosLocalizados.NroImpresiones > 0 && accesosLocalizados.NroImpresiones <= datADCDOC.Doc_Adicional1)
			{
				MessageBox.Show("Ha llegado al límite de impresiones permitidas", "Imprimir documentos",
								MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			// ============================================================
			// SOLO generar el comprobante si la clave SRI está vacía
			// ============================================================
			if (string.IsNullOrEmpty(datADCDOC.claveSri))
			{
				try
				{
					Cursor.Current = Cursors.WaitCursor;

					// CORREGIDO: Usar generarClaveElectronica que retorna string, no actualizarClaveElectronica (void)
					string claveGenerada = ClaveElectronica.generarClaveElectronica(datADCDOC);

					if (string.IsNullOrEmpty(claveGenerada))
					{
						Cursor.Current = Cursors.Default;
						MessageBox.Show("No se pudo generar el comprobante electrónico.\nNo es posible continuar con la impresión.",
										"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}

					// Actualizar datADCDOC con la nueva clave
					datADCDOC.claveSri = claveGenerada;

					// También actualizar el registro en la base de datos
					ClaveElectronica.actualizarClaveElectronica(datADCDOC);

					Cursor.Current = Cursors.Default;
				}
				catch (Exception ex)
				{
					Cursor.Current = Cursors.Default;
					MessageBox.Show($"Error al generar el comprobante: {ex.Message}", "Error",
									MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
			}

			// ============================================================
			// Continuar con la impresión/previsualización
			// ============================================================

			// Crear la instancia
			ImpresionDocumentosDax.ImprimeDocumentoDoble impProg = new ImpresionDocumentosDax.ImprimeDocumentoDoble(
				datosEmpresa.nombreBaseIvaret,
				datosEmpresa.strConxAdcom,
				datosEmpresa.strConxIvaret,
				datosEmpresa.strConxSyscod,
				datosEmpresa.strConxDaxpro,
				datosEmpresa.codEmpresa,
				datosEmpresa.pathServer);

			// Asegurar que fel esté actualizado
			if (fel == null)
			{
				fel = new AdcFelec(datosEmpresa.strConxAdcom);
			}

			// Buscar el documento electrónico actualizado
			fel = AdcFelec.Buscar("");

			string rutaBase = fel != null ? fel.pathCpbGenerados : @"C:\CPBGenerados\";
			string clave = datADCDOC.claveSri;  // Ahora ya debería tener la clave SRI
			string url = ConfiguracionCorreo.UrlSRI;

			// Asignar la función de generación del RIDE (PDF)
			impProg.FuncionGenerarRide = (doc, cclave, urlSRI) => {
				string carpetaPdf = Feutilidad.PathDocumntosPdf(rutaBase);
				string pathPdf = Path.Combine(carpetaPdf, cclave + ".PDF");

				if (!File.Exists(pathPdf))
				{
					try
					{
						RideService rideService = new RideService();
						string resultado = rideService.GenerarRide(doc, cclave, urlSRI);
					}
					catch (Exception ex)
					{
						System.Diagnostics.Debug.WriteLine($"Error al generar RIDE: {ex.Message}");
					}
				}

				return pathPdf;
			};

			// Llamar al método con los parámetros SRI
			int imp = impProg.ImpDocConSRI(
				idDocumentoActual,
				"A",
				"",
				false,
				false,
				clave,      // datADCDOC.claveSri
				url,        // ConfiguracionCorreo.UrlSRI
				rutaBase    // fel.pathCpbGenerados
			);

			datADCDOC.Doc_Adicional1 = imp;
		}

		// Método para generar el comprobante electrónico (solo se ejecuta si la clave SRI está vacía)
		private string GenerarComprobanteElectronico()
		{
			try
			{
				// Aquí va tu lógica existente para generar el XML y obtener la clave SRI
				// Esto solo se ejecutará cuando el campo esté vacío,
				// es decir, cuando el proceso normal de registro no lo haya hecho

				// Ejemplo:
				// 1. Generar el XML del comprobante
				// 2. Firmarlo electrónicamente
				// 3. Obtener la clave de acceso
				// 4. Guardar en datADCDOC.claveSri

				// Retornar la clave SRI generada
				return datADCDOC.claveSri;
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error generando comprobante: {ex.Message}");
				return "";
			}
		}


		private void btnCopia_Click(object sender, EventArgs e)
		{
			string SUC = datosEmpresa.suc;
			string TIP = "";
			double Idclave = 0;
			double Numero = 0;
			BuscadorDocumentos.buscadorDoc progBus = new BuscadorDocumentos.buscadorDoc();
			DateTime queFecha = docUtils.DaxNow();
			progBus.IniciaBusqueda("FACPROPEC", "", "", queFecha, ref SUC, ref TIP, ref Numero, ref Idclave, false, "", "", "", "ADCDOC");
			if (Idclave != 0)
			{
				idDocumentoParaGenerar.Sucursal = SUC;
				idDocumentoParaGenerar.Tipo = TIP;
				idDocumentoParaGenerar.idClave = Idclave;
				copiarDocumento(idDocumentoParaGenerar, false);
			}
			progBus = null;
		}
		private void btnConsolida_Click(object sender, EventArgs e)
		{
			string SUC = datosEmpresa.suc;
			string TIP = "";
			double Idclave = 0;
			double Numero = 0;
			BuscadorDocumentos.buscadorDoc progBus = new BuscadorDocumentos.buscadorDoc();
			DateTime queFecha = docUtils.DaxNow();
			idDocumentoParaGenerar = new idDocumento
			{
				Lista = progBus.IniciaConsolidacion(DctosEmi.ConsolidaDoc.tiposDoctsConsolidaSql(datosEmpresa.strConxAdcom), codCliente, "", queFecha, ref SUC, ref TIP, ref Numero, ref Idclave, false, "", "", "", "ADCDOC")
			};
			if (Idclave != 0 && idDocumentoParaGenerar.Lista.Length > 0)
			{
				idDocumentoParaGenerar.Sucursal = SUC;
				idDocumentoParaGenerar.Tipo = TIP;
				idDocumentoParaGenerar.idClave = Idclave;
				consolidarDocumentos(idDocumentoParaGenerar);
			}
			progBus = null;
		}
		private void btnBuscaCliente_Click(object sender, EventArgs e)
		{
			BuscaCliente(txtnombrecliente.Text);
		}
		private void BtnAbre_Click(object sender, EventArgs e)
		{
			BuscadorDocumentos.buscadorDoc progBus = new BuscadorDocumentos.buscadorDoc();
			idDocumentoActual.Sucursal = datosEmpresa.suc;
			DateTime queFecha = docUtils.DaxNow();
			progBus.IniciaBusqueda(claseDocDefault, "", cmbDocumento.SelectedValue.ToString(), queFecha, ref idDocumentoActual.Sucursal, ref idDocumentoActual.Tipo, ref idDocumentoActual.numero, ref idDocumentoActual.idClave, false, cmbDocumento.SelectedValue.ToString(), "", "", "ADCDOC");
			if (idDocumentoActual.idClave == 0)
			{
				idDocumentoActual.Sucursal = datosEmpresa.suc; return;
			}
			if (idDocumentoActual.Sucursal.ToUpper() != datosEmpresa.suc.ToUpper()) { mensajesErrorDocumento.documentosNoDeOtraSucursal(datosEmpresa.sucNom); return; }
			if (idDocumentoActual.idClave != 0) cargarDatosFactura(idDocumentoActual.Sucursal, idDocumentoActual.Tipo, idDocumentoActual.idClave);
		}
		private void btnGraba_Click(object sender, EventArgs e)
		{
			if (validarDocumento() == true)
			{
				if (grabarDocumento() == true)
					{
					//if (ConfiguracionCorreo.ParametroCargado && ConfiguracionCorreo.parametro == 1)
					//if (ConfiguracionCorreo.parametro == 1)
					//{
						//urlE = ConfiguracionCorreo.UrlSRI; // Aquí obtienes la URL desde la BD
						//solicitarAutorizacionSRI(urlE);
					//}

					limpiarDatos();
				}
			}

		}
		
		private void solicitarAutorizacionSRI(string urlsri, ref ClassDoc.AdcDoc datADCDOC)
		{
			var fel = new ClassFelec.AdcFelec(datosEmpresa.strConxAdcom);
			fel = ClassFelec.AdcFelec.Buscar("");

			string queClave = "";
			tipoEmision = 1;
			string ambiente = fel.ambienteEnProduccion ? "2" : "1";

			queSucE = datADCDOC.Doc_sucursal;
			queDocE = datADCDOC.Doc_TipoDoc;
			queNumE = datADCDOC.Doc_numero;
			IdClaveDocFE = Convert.ToDouble(datADCDOC.IdClaveDoc);

			var genxml = new SolicitarAutorizacionSRI.enviarDocumentoS();
			queClave = genxml.documentoAenviar(queSucE, datADCDOC.Opc_documento, queNumE.ToString(), IdClaveDocFE, ref PathFile, queDocE, datosEmpresa.Emp_RUC, datosEmpresa.Par_DigitosPrecios, datosEmpresa.pathAppl, tipoEmision, false);

			if (queClave.Substring(0, 5).ToUpper() == "ERROR")
			{
				ErroresE = $"{queSucE}-{datADCDOC.Opc_documento}-{queNumE}  {queClave} Genera XML ";
			}
			else
			{
				queClaveSRIE = queClave.ToUpper();

				datADCDOC.claveSri = queClaveSRIE;

				var FM = new SolicitudAutSRI.Firma();
				FM.strFileXml = queClaveSRIE;
				string resp = FM.FirmarArchivoXML(datosEmpresa.strConxAdcom);
				FM = null;

				if (resp.Substring(0, 5).ToUpper() != "ERROR")
				{

					PathFile = fel.pathCpbFirmados + queClaveSRIE + ".xml";
					string pathAutorizados = fel.pathCpbAutorizados + queClaveSRIE + ".xml";
					string pathNoAutorizados = fel.pathpbNoAutorizados + queClaveSRIE + ".xml";
					string pathErrores = pathNoAutorizados.Replace("xml", "ERR");
					correoElectronicoDefectoE = fel.correoDefecto;

					//var prog = new enviarDocumentoSri.EnviarComprobanteSri();
					var prog = new EnviarComprobanteSri();
					if (prog.sendComprobanteSRI(PathFile, queClaveSRIE, pathAutorizados, pathNoAutorizados, false, ambiente, datosEmpresa.strConxAdcom))
					{
						string archivoXML = pathAutorizados;
						string nombrePdf = archivoXML.Replace("xml", "PDF");
						string rutaNombre = Feutilidad.PathDocumntosPdf(fel.pathCpbGenerados) + queClaveSRIE + ".PDF";

						int IDCLAV = Convert.ToInt32(datADCDOC.IdClaveDoc);
						// Convertir imagen a Base64
						//string imageBase64 = Convert.ToBase64String(File.ReadAllBytes(@"\\Server-fspc\DAXSOF\ArchivosDePrograma\AdcomDx_12\Bin\Imagenes\LOGOFSPC.jpg"));
						string imageBase64 = Convert.ToBase64String(File.ReadAllBytes(datosEmpresa.Emp_PathImagenes + "logoempresa.jpg"));
						// 1. Ejecutar el procedimiento para obtener los datos
						var resultado = aux.EjecutarProcedimientoCabeceraYDetalle(IDCLAV, datADCDOC.Doc_sucursal, datADCDOC.Opc_documento, datADCDOC.Doc_numero);
						GenerarRide(urlsri);

						try
						{
							//MessageBox.Show(pdfPath+" genero el pdf de la api" );
							if (string.IsNullOrWhiteSpace(ConfiguracionCorreo.CorreoDesde) || string.IsNullOrWhiteSpace(ConfiguracionCorreo.Smtp) || string.IsNullOrWhiteSpace(ConfiguracionCorreo.Usuario) || string.IsNullOrWhiteSpace(ConfiguracionCorreo.Clave) || ConfiguracionCorreo.Puerto <= 0)
							{
								ErroresE = $"{queSucE}-{queDocE}-{queNumE}  {queClaveSRIE} configuración de correo incompleta o no cargada.";
								return;
							}
							else
							{
								queCodigoCliente = datADCDOC.Doc_codper;

								correoElectronico = aux.ObtenerCorreoDesdeIdentificacion(queCodigoCliente);

								if (verificaCorreoElectronico(ref correoElectronico))
								{
									if (correoElectronico.Equals(correoElectronicoDefectoE, StringComparison.OrdinalIgnoreCase))
									{
										ErroresE = $"{queSucE}-{queDocE}-{queNumE}  {queClaveSRIE} correo no enviado para evitar saturar el correo.";
										return; // omite el envío
									}
									// Rutas base
									string rutaXML = fel.pathCpbAutorizados;
									string rutaPDF = fel.pathCpbGenerados;
									//MessageBox.Show(rutaXML + "" + rutaPDF);

									// Quitar barra final si existe
									string rutaPdfSinBarra = rutaPDF.TrimEnd('\\');

									string rutaPadre = Path.GetDirectoryName(rutaPdfSinBarra);
									string rutaF = Path.Combine(rutaPadre, "GeneradosPDF");

									// Archivos por clave SRI
									string xmlPath = Path.Combine(rutaXML, $"{queClaveSRIE}.xml");
									string pdfPathCompleto = Path.Combine(rutaF, $"{queClaveSRIE}.pdf");

									//MessageBox.Show(pdfPathCompleto);

									if (File.Exists(xmlPath) && File.Exists(pdfPathCompleto))
									{
										try
										{
											using (var mensaje = new MailMessage())
											{
												string displayName = datosEmpresa.Emp_Nombre;
												mensaje.From = new MailAddress(ConfiguracionCorreo.CorreoDesde, displayName);
												mensaje.To.Add(correoElectronico);
												mensaje.Subject = $"Ha recibido su documento electronico: {queDocE}- {datADCDOC.Doc_NroIdDoc}- {queNumE}";
												mensaje.Body = $"Estimado cliente {datADCDOC.Doc_NombreImp}.\n\nAdjunto encontrará su comprobante electrónico.\n\nGracias por su preferencia.\n\n\n.";
												mensaje.IsBodyHtml = false;

												mensaje.Attachments.Add(new Attachment(pdfPathCompleto));
												mensaje.Attachments.Add(new Attachment(xmlPath));

												using (var smtpClient = new SmtpClient(ConfiguracionCorreo.Smtp, ConfiguracionCorreo.Puerto))
												{
													smtpClient.Credentials = new NetworkCredential(ConfiguracionCorreo.Usuario, ConfiguracionCorreo.Clave);
													smtpClient.EnableSsl = ConfiguracionCorreo.HabilitarSSL;
													smtpClient.Send(mensaje);
												}
											}
										}
										catch (Exception ex)
										{
											ErroresE = $"{queSucE}-{queDocE}-{queNumE}  {queClaveSRIE} error al enviar correo: {ex.Message}";
										}
									}
									else
									{
										ErroresE = $"{queSucE}-{queDocE}-{queNumE}  {queClaveSRIE} faltan archivos XML o PDF";
									}
								}
							}


						}
						catch (Exception ex)
						{
							MessageBox.Show($"Error al generar PDF: {ex.Message}");
							// Almacenar errores si es necesario
							ErroresE = $"Error al generar PDF: {ex.Message}";
							almacenarErrores(ErroresE);
						}
					
					}
					else
					{
						ErroresE = $"{queSucE}-{queDocE}-{queNumE}  {queClaveSRIE} autorizando ";
						//Errores += publicarMensaje(pathErrores);
					}
				}
				else
				{
					ErroresE = $"{queNumE}-{queDocE}-{queNumE}  {queClave} Firmando";
				}
			}

			if (!string.IsNullOrEmpty(ErroresE))
			{
				almacenarErrores(ErroresE);
			}

		}


		private void GenerarRide(string urlEs)
		{
			try
			{
				RideService rideService = new RideService();

				string pdfPath = rideService.GenerarRide(this.datADCDOC.IdClaveDoc, datADCDOC.Doc_sucursal, datADCDOC.Opc_documento, datADCDOC.Doc_numero, queClaveSRIE, urlEs);
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error al generar PDF: {ex.Message}");
			}
		}



		private bool verificaCorreoElectronico(ref string correoElectronico)
		{
			if (correoElectronico.Length == 0)
				correoElectronico = this.correoElectronicoDefectoE;
			return correoElectronico.Length != 0 && ValidacionesDocElectronicos.ValidarEmail(correoElectronico);
		}

		private void almacenarErrores(string err) => this.colecError.Add(err);


		private void btnPagos_Click(object sender, EventArgs e)
		{
			string pagoPredefinido = "";
			if (clasePagos.pagosDelDocumento.Count == 0)
			{
				pagoPredefinido = registrarFormaDePagoPredefinida();
				crearPagoPredefinido(pagoPredefinido);
			}
			comercP.MntPago PagosDoc = new comercP.MntPago();
			PagosDoc.INIPagos(idDocumentoActual.idClave, ref clasePagos, opalex.codigo, datosEmpresa.suc, propiedadesDoc.TipoDoc, txtfecha.Text, false, cmbDocumento.SelectedValue.ToString(), Convert.ToDouble("0" + txtnumero.Text), pagoPredefinido, Convert.ToDouble("0" + edTotal.Text), false);
			PagosDoc = null;
		}

		private void btnNuevo_Click(object sender, EventArgs e)
		{
			iniciarNuevoDocumento();
		}
		private void iniciarNuevoDocumento()
		{
			limpiarDatos();
			datADCDOC = new AdcDoc(datosEmpresa.strConxAdcom);
			InicializarMalla();
			idDocumentoActual = new idDocumento
			{
				familia = propiedadesDoc.TipoDoc,
				fecha = txtfecha.Value,
				numero = Convert.ToDouble("0" + txtnumero.Text),
				Serie = txtNroID.Text,
				Sucursal = datosEmpresa.suc,
				Tipo = cmbDocumento.SelectedValue.ToString()
			};
			string bod = "";
			if (cmbBodega.SelectedValue != null) bod = cmbBodega.SelectedValue.ToString();
			txtfecha.Value = docUtils.DaxNow();
			ClassDoc.controlNumeracion cnum = new controlNumeracion();
			txtnumero.Text = cnum.NumeroMayor(idDocumentoActual, "", "", "", datosEmpresa.strConxAdcom).ToString();
			operacionEnCurso = 1;
			prepararBotones();
		}

		//private void btnPendientes_Click(object sender, EventArgs e)
		//{
		//	porEntregar.frmPorEntregar PorEntregar = new porEntregar.frmPorEntregar
		//	{
		//		fecha = docUtils.DaxNow(),
		//		Cliente = codCliente,
		//		NomCliente = txtnombrecliente.Text,
		//		strConxAdcom = datosEmpresa.strConxAdcom
		//	};
		//	PorEntregar.ShowDialog();
		//}
		private void btnDescuentos_Click(object sender, EventArgs e)
		{            
            adcDescto.ingDescDoc ingdesc = new adcDescto.ingDescDoc();
			ingdesc.ingresarDescuentos(ref claseDescuentos, datosEmpresa.strConxAdcom, datosEmpresa.suc, valoresPredefinidosEmpresa.nroDescuentosMaximosDocto);
			ingdesc.Dispose();
			totalizar();
		}

		private void btnRegistra_Click(object sender, EventArgs e)
		{
			if (validarDocumento() == true)
			{
				if (grabarDocumento() == true)
				{					
					if (ConfiguracionCorreo.ParametroCargado && ConfiguracionCorreo.parametro == 1)
					{
						urlE = ConfiguracionCorreo.UrlSRI; // Aquí obtienes la URL desde la BD
						solicitarAutorizacionSRI(urlE, ref datADCDOC);
					}

					//EnviarAimpresora.imprimirDocumentoDirectamente(datADCDOC, accesosLocalizados, idDocumentoActual);
					//limpiarDatos();
					// ✅ 2. Imprimir y ESPERAR a que termine
					bool impresionExitosa = EnviarAimpresora.imprimirDocumentoDirectamente(datADCDOC, accesosLocalizados, idDocumentoActual);

					// ✅ 3. SOLO limpiar si la impresión fue exitosa
					if (impresionExitosa)
					{
						limpiarDatos();
						//MessageBox.Show("Documento registrado e impreso correctamente", "Éxito",MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					else
					{
						MessageBox.Show("El documento se grabó pero hubo un problema con la impresión.\n\nPuede volver a imprimir desde el historial.",
							"Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					}
				}
			}
		}
		private void btnAnula_Click(object sender, EventArgs e)
		{
			DctosEmi.anulaElimina classAnular = new DctosEmi.anulaElimina();
			if (classAnular.anularDocumento(datosEmpresa.strConxAdcom, datosEmpresa.strConxSyscod, idDocumentoActual, datosEmpresa.usr, esDeLiquidacion, datosEmpresa.nomEmpresa, datosEmpresa.codEmpresa.ToString(), edTotal.Text, "ADCDOC", propiedadesDoc.ComandoExterno)) limpiarDatos();
			classAnular = null;
		}
		private void btnElimina_Click(object sender, EventArgs e)
		{
			DctosEmi.anulaElimina classAnular = new DctosEmi.anulaElimina();
			if (classAnular.eliminarDocumento(datosEmpresa.strConxAdcom, datosEmpresa.strConxSyscod, idDocumentoActual, datosEmpresa.usr, esDeLiquidacion, datosEmpresa.nomEmpresa, datosEmpresa.codEmpresa.ToString(), edTotal.Text, "ADCDOC", propiedadesDoc.ComandoExterno)) limpiarDatos();
			classAnular = null;
		}


		#endregion EVENTOS DE BOTONES
		#region EVENTOS DE CAJAS DE TEXTO
		private void txtCorreElectronico_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.F2)
			{
				txtCorreElectronico.Text = valoresPredefinidosEmpresa.correoElectronicoDefecto;
			}
		}
		private void txtfecha_ValueChanged(object sender, EventArgs e)
		{
			idDocumentoActual.fecha = txtfecha.Value;
			ChequearCambioValoresPoFecha();
		}
		//private void txtRecibido_TextChanged(object sender, EventArgs e)
		//{
		//	try
		//	{
		//		decimal cambio = Convert.ToDecimal(txtRecibido.Text) - Convert.ToDecimal(edTotal.Text);
		//		if (cambio < 0)
		//		{
		//			txtCambio.BackColor = System.Drawing.Color.Red;
		//			labCambio.Text = "FALTA";
		//		}
		//		else
		//		{
		//			txtCambio.BackColor = System.Drawing.Color.White;
		//			labCambio.Text = "CAMBIO";
		//		}
		//		txtCambio.Text = cambio.ToString();

		//	}
		//	catch { txtCambio.Text = ""; }
		//}


		private void Txtcedula_Leave(object sender, EventArgs e)
		{
			KeyEventArgs ee = new KeyEventArgs(Keys.Return);
			txtcedula_KeyDown(sender, ee);
		}

		private void txtcedula_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return && txtcedula.Text.Length > 0) ingresaCodigoClienteDirecto();
		}
		private void ingresaCodigoClienteDirecto()
		{
			string codigo = txtcedula.Text;
			string tipo = "C";
			cargarDatosCliente(codigo);
			if (txtcedula.Text == "")
			{
				if (MessageBox.Show("El cliente no existe desea registarlo ? ", "Creacion de cliente nuevo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
				{

					directMnt.CreaCliAlex express = new directMnt.CreaCliAlex();
					express.IniCrearAlex(ref tipo, ref codigo);
				}
			}
			if ((codigo + "").Length > 0) cargarDatosCliente(codigo);
		}
		private void cmbDocumento_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (idDocumentoActual.Sucursal == "") return;
			if (idDocumentoActual.Tipo == cmbDocumento.SelectedValue.ToString()) return;
			idDocumentoActual.Tipo = cmbDocumento.SelectedValue.ToString();
			CargarPredefinidosDocumento();
			//llenarComboDocReferencia();
		}

		private void txtnumero_Leave(object sender, EventArgs e)
		{
			if (saltarEventoNumero == true) { saltarEventoNumero = false; return; }
			if (operacionEnCurso != 2)
			{
				verificaNroDocumentoDigitado();
			}
		}
		private void txtnumero_KeyDown(object sender, KeyEventArgs e)
		{
			saltarEventoNumero = true;
			if (e.KeyCode == Keys.Return)
			{
				verificaNroDocumentoDigitado();
			}
		}
		private void verificaNroDocumentoDigitado()
		{
			LlenarIdDocumento(ref idDocumentoActual);
			impresionVerificacion.verificarExistenciaDocumento(ref idDocumentoActual, datosEmpresa.strConxAdcom,false, "ADCDOC", codCliente);
			if (idDocumentoActual.idClave > 0) cargarDatosFactura(idDocumentoActual.Sucursal, idDocumentoActual.Tipo, idDocumentoActual.idClave);
		}


		#endregion EVENTOS DE CAJAS DE TEXTO

		#endregion EVENTOS DE CONTROLES
		#region manejo malla
		private void malla_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
		{
			saltaEventosMalla = true;
			foreach (DataGridViewRow rr in malla.Rows)
			{
				rr.HeaderCell.Value = (rr.Index + 1).ToString();
			}
			saltaEventosMalla = false;
		}
		protected override Boolean ProcessCmdKey(ref Message msg, Keys keyData)
		{
			if (malla.Focused == false && malla.IsCurrentCellInEditMode == false) return false;
			if (malla.IsCurrentCellInEditMode && (keyData == Keys.Up || keyData == Keys.Down || keyData == Keys.Right || keyData == Keys.Left))
			{ keyData = Keys.Return; }

			if (keyData == Keys.Return || (keyData >= Keys.F1 && keyData < Keys.F13))
			{
				//DataGridViewCell cell = malla.CurrentCell;
				if (!(malla.IsCurrentCellInEditMode == false && keyData == Keys.Return)) funcionesEspeciales(ref keyData, malla);
				if (keyData != Keys.Return) return true;
				DaxMallaLib.Documentos.MoverCelda(malla,btnBarras.Enabled);
				return true;
			}
			return false;
		}

		#endregion manejo malla
		//private Boolean funcionesEspeciales(ref Keys keyData, DataGridView malla)
		//{

		//          docMallaArticulo mallaArticulo = new docMallaArticulo();
		//          Boolean resp = true;
		//          malla.EndEdit();
		//          DataGridViewCell cell = malla.CurrentCell;
		//          string dato = cell.Value.ToString();
		//          string nombreCelda = cell.OwningColumn.Name.ToUpper();

		//          if (keyData == Keys.F8 && cell.ReadOnly == false && malla.Columns[cell.ColumnIndex].Name.ToUpper() != "TRA_CODIGO")
		//          {
		//              if (cell.RowIndex > 0) cell.Value = malla.Rows[cell.RowIndex - 1].Cells[cell.ColumnIndex].Value;
		//          }
		//          else if (keyData == Keys.F3 && cell.ValueType.Name.ToUpper() == "DATETIME")
		//          {
		//              cell.Value = docUtils.DaxNow().ToShortDateString();
		//          }
		//          else
		//          {
		//              switch (nombreCelda)
		//              {
		//                  case "TRA_PRECUNI":
		//                      if (keyData >= Keys.F2 && keyData <= Keys.F6)
		//                      {
		//                          DataGridViewRow row = malla.CurrentRow;
		//                          DtosMall.docMallaArticulo preVta = new docMallaArticulo();
		//                          Int32 quePrecio = 0;
		//                          cell.Value = cargarPrecios.CargarPrecioVta(Convert.ToInt16(keyData), malla.CurrentRow.Cells["tra_Codigo"].Value.ToString(), claseImpuestos.impstoPorcentaje1, ref quePrecio, "", row.Cells["tra_Medida"].Value.ToString(), "", valoresPredefinidosEmpresa.nroDigitosEnPrecios);
		//                          //	totalizar();
		//                      }
		//                      break;
		//                  case "TRA_CODIGO":
		//                      if (dato != ".")
		//                      {
		//                          try
		//                          {
		//                              mallaArticulo.bodega = ""; //cmbBodega.SelectedValue.ToString();
		//                          }
		//                          catch { }
		//                          saltaEventosMalla = true;
		//                          mallaArticulo.digCostos = valoresPredefinidosEmpresa.nroDigitosEnCostos;
		//                          mallaArticulo.digPrecios = valoresPredefinidosEmpresa.nroDigitosEnPrecios;
		//                          mallaArticulo.fechaDoc = Convert.ToDateTime(txtfecha.Text);
		//                          mallaArticulo.impIva = claseImpuestos.impstoPorcentaje1;
		//                          mallaArticulo.codCliente = codCliente;
		//                          mallaArticulo.sucursal = datosEmpresa.suc;
		//                          mallaArticulo.tipoDoc = cmbDocumento.SelectedValue.ToString();
		//                          mallaArticulo.numDoc = txtnumero.Text;

		//                          if (keyData == Keys.F2)
		//                          {
		//                              dato = mallaArticulo.BuscarArticuloSimple(malla.CurrentCell.Value.ToString());
		//                              if (mallaArticulo.CargarArticulo(malla, ref propiedadesDoc, dato, opalex.TipoCliente, txtfecha.Text, propiedadesDoc.Documento, idDocumentoActual.idClave) == false) { cell.Value = ""; keyData = Keys.Cancel; }
		//                          }
		//                          else if (keyData == Keys.F3)
		//                          {
		//                              DaxConceptos.classConceptos buscserv = new DaxConceptos.classConceptos();
		//                              dato = buscserv.iniciaBuscador(datosEmpresa.strConxAdcom, "", "V", false, false);
		//                              if (dato != "") mallaArticulo.CargarServicios(dato, ref malla, claseImpuestos.impstoPorcentaje1, valoresPredefinidosEmpresa.nroDigitosEnPrecios, Convert.ToDateTime(txtfecha.Text), ref propiedadesDoc);
		//                          }
		//                          else if (keyData == Keys.Return && dato.Length > 0)
		//                          {
		//                              if (mallaArticulo.CargarConDesicion(malla, ref propiedadesDoc, dato, opalex.TipoCliente, txtfecha.Text, propiedadesDoc.Documento, idDocumentoActual.idClave) == false) { cell.Value = ""; keyData = Keys.Cancel; }								
		//                          }
		//                          else if (keyData == Keys.F11)
		//                          {
		//                              dato = mallaArticulo.BuscarArticulo(malla.CurrentCell.Value.ToString());
		//                              if (mallaArticulo.CargarArticulo(malla, ref propiedadesDoc, dato, opalex.TipoCliente, txtfecha.Text, propiedadesDoc.Documento, idDocumentoActual.idClave) == false) { cell.Value = ""; keyData = Keys.Cancel; }
		//                          }

		//                          //        VerificarClasificadoresContablesArticulo dato
		//                      }
		//                      break;
		//                  case "DOC_BODEGA":
		//                  case "TRA_EMPLEADO":
		//                  case "TRA_VENCE":
		//                  case "FACDESDE":
		//                  case "FACHASTA":
		//                      if (keyData == Keys.F2)
		//                      {
		//                          BusquedasDetalleDocumentos.BuscarValor(cell, nombreCelda);
		//                      }
		//                      break;
		//                  case "TRA_COSTO":
		//                  case "TRA_CENTROPRODUCCION":
		//                  case "TRA_CENTRODISTRIBUCION":
		//                  case "TRA_PROYECTO":
		//                      if (keyData == Keys.F2)
		//                      {
		//                          BusquedasDetalleDocumentos.BuscarValor(cell, nombreCelda);
		//                      }
		//                      break;
		//              }
		//          }
		//          if (cell.Value.ToString() != "") { keyData = Keys.Return; } else { keyData = Keys.Cancel; }
		//          saltaEventosMalla = false;
		//          totalizar();
		//          mallaArticulo = null;
		//          return resp;
		//}      

		private Boolean funcionesEspeciales(ref Keys keyData, DataGridView malla)
		{
			docMallaArticulo mallaArticulo = new docMallaArticulo();
			Boolean resp = true;
			malla.EndEdit();
			DataGridViewCell cell = malla.CurrentCell;
			string dato = cell.Value != null ? cell.Value.ToString() : "";
			string nombreCelda = cell.OwningColumn.Name.ToUpper();

			if (keyData == Keys.F8 && cell.ReadOnly == false && malla.Columns[cell.ColumnIndex].Name.ToUpper() != "TRA_CODIGO")
			{
				if (cell.RowIndex > 0) cell.Value = malla.Rows[cell.RowIndex - 1].Cells[cell.ColumnIndex].Value;
			}
			else if (keyData == Keys.F3 && cell.ValueType != null && cell.ValueType.Name.ToUpper() == "DATETIME")
			{
				cell.Value = docUtils.DaxNow().ToShortDateString();
			}
			// ========================================================================
			// 👇 NUEVO: Manejo de F2 en columna TRA_SNIVA (IVA)
			// ========================================================================
			else if (keyData == Keys.F2 && nombreCelda == "TRA_SNIVA")
			{
				DataGridViewRow row = malla.CurrentRow;

				// Verificar que la fila tenga código (no está vacía)
				if (row.Cells["tra_codigo"].Value == null ||
					row.Cells["tra_codigo"].Value == DBNull.Value ||
					row.Cells["tra_codigo"].Value.ToString().Trim() == "")
				{
					MessageBox.Show("Primero debe ingresar un código de artículo o servicio",
								  "Información",
								  MessageBoxButtons.OK,
								  MessageBoxIcon.Information);
					keyData = Keys.Cancel; // Evitar comportamiento default
					saltaEventosMalla = false;
					mallaArticulo = null;
					return resp;
				}

				// 👇 Obtener valor actual como número (1 o 0)
				int valorActual = 0;
				if (row.Cells["TRA_SNIVA"].Value != null && row.Cells["TRA_SNIVA"].Value != DBNull.Value)
				{
					int.TryParse(row.Cells["TRA_SNIVA"].Value.ToString(), out valorActual);

					// Si no es número, verificar si es texto "SI"/"NO"
					if (valorActual == 0)
					{
						string texto = row.Cells["TRA_SNIVA"].Value.ToString().Trim().ToUpper();
						if (texto == "SI" || texto == "S" || texto == "1" || texto == "TRUE")
							valorActual = 1;
					}
				}

				// 👇 Alternar: SI(1) → NO(0), NO(0) → SI(1)
				int nuevoValor = (valorActual == 1) ? 0 : 1;
				row.Cells["TRA_SNIVA"].Value = nuevoValor;

				// 👇 Actualizar porcentaje de IVA
				if (nuevoValor == 1)
				{
					// CAMBIÓ A SI → Poner porcentaje por defecto del sistema
					row.Cells["Tra_porceniva"].Value = claseImpuestos.impstoPorcentaje1;
				}
				else
				{
					// CAMBIÓ A NO → Poner 0
					row.Cells["Tra_porceniva"].Value = 0;
				}

				// 👇 Recalcular IVA de la fila
				CalcularValorIvaFila(row);

				// 👇 Recalcular totales del documento
				totalizar();

				// 👇 Forzar actualización visual
				malla.RefreshEdit();
				malla.UpdateCellValue(cell.ColumnIndex, cell.RowIndex);

				keyData = Keys.Cancel; // ✅ Evitar que F2 active modo edición
			}
			// ========================================================================
			// 👆 FIN NUEVO CASO TRA_SNIVA
			// ========================================================================
			else
			{
				switch (nombreCelda)
				{
					case "TRA_PRECUNI":
						if (keyData >= Keys.F2 && keyData <= Keys.F6)
						{
							DataGridViewRow row = malla.CurrentRow;
							DtosMall.docMallaArticulo preVta = new docMallaArticulo();
							Int32 quePrecio = 0;
							cell.Value = cargarPrecios.CargarPrecioVta(Convert.ToInt16(keyData), malla.CurrentRow.Cells["tra_Codigo"].Value.ToString(), claseImpuestos.impstoPorcentaje1, ref quePrecio, "", row.Cells["tra_Medida"].Value.ToString(), "", valoresPredefinidosEmpresa.nroDigitosEnPrecios);
						}
						break;
					case "TRA_CODIGO":
						if (dato != ".")
						{
							try { mallaArticulo.bodega = ""; } catch { }
							saltaEventosMalla = true;
							mallaArticulo.digCostos = valoresPredefinidosEmpresa.nroDigitosEnCostos;
							mallaArticulo.digPrecios = valoresPredefinidosEmpresa.nroDigitosEnPrecios;
							mallaArticulo.fechaDoc = Convert.ToDateTime(txtfecha.Text);
							mallaArticulo.impIva = claseImpuestos.impstoPorcentaje1;
							mallaArticulo.codCliente = codCliente;
							mallaArticulo.sucursal = datosEmpresa.suc;
							mallaArticulo.tipoDoc = cmbDocumento.SelectedValue.ToString();
							mallaArticulo.numDoc = txtnumero.Text;

							if (keyData == Keys.F2)
							{
								dato = mallaArticulo.BuscarArticuloSimple(malla.CurrentCell.Value.ToString());
								if (mallaArticulo.CargarArticulo(malla, ref propiedadesDoc, dato, opalex.TipoCliente, txtfecha.Text, propiedadesDoc.Documento, idDocumentoActual.idClave) == false) { cell.Value = ""; keyData = Keys.Cancel; }
							}
							else if (keyData == Keys.F3)
							{
								DaxConceptos.classConceptos buscserv = new DaxConceptos.classConceptos();
								dato = buscserv.iniciaBuscador(datosEmpresa.strConxAdcom, "", "V", false, false);
								if (dato != "") mallaArticulo.CargarServicios(dato, ref malla, claseImpuestos.impstoPorcentaje1, valoresPredefinidosEmpresa.nroDigitosEnPrecios, Convert.ToDateTime(txtfecha.Text), ref propiedadesDoc);
							}
							else if (keyData == Keys.Return && dato.Length > 0)
							{
								if (mallaArticulo.CargarConDesicion(malla, ref propiedadesDoc, dato, opalex.TipoCliente, txtfecha.Text, propiedadesDoc.Documento, idDocumentoActual.idClave) == false) { cell.Value = ""; keyData = Keys.Cancel; }
							}
							else if (keyData == Keys.F11)
							{
								dato = mallaArticulo.BuscarArticulo(malla.CurrentCell.Value.ToString());
								if (mallaArticulo.CargarArticulo(malla, ref propiedadesDoc, dato, opalex.TipoCliente, txtfecha.Text, propiedadesDoc.Documento, idDocumentoActual.idClave) == false) { cell.Value = ""; keyData = Keys.Cancel; }
							}
						}
						break;
					case "DOC_BODEGA":
					case "TRA_EMPLEADO":
					case "TRA_VENCE":
					case "FACDESDE":
					case "FACHASTA":
						if (keyData == Keys.F2)
						{
							BusquedasDetalleDocumentos.BuscarValor(cell, nombreCelda);
						}
						break;
					case "TRA_COSTO":
					case "TRA_CENTROPRODUCCION":
					case "TRA_CENTRODISTRIBUCION":
					case "TRA_PROYECTO":
						if (keyData == Keys.F2)
						{
							BusquedasDetalleDocumentos.BuscarValor(cell, nombreCelda);
						}
						break;
				}
			}

			if (cell.Value != null && cell.Value.ToString() != "") { keyData = Keys.Return; } else { keyData = Keys.Cancel; }
			saltaEventosMalla = false;
			totalizar();
			mallaArticulo = null;
			return resp;
		}

		private string registrarFormaDePagoPredefinida()
		{
				if (opalex.FormaPago != null && opalex.FormaPago.Length > 0) return opalex.FormaPago;
				if (valoresPredefinidosEmpresa.formaPagoPredefinidaVtas.Length > 0) return valoresPredefinidosEmpresa.formaPagoPredefinidaVtas;
				return "EFE";
		}

		private void crearPagoPredefinido(string IdPago)
		{
			if (IdPago == "") IdPago = "EFE";
			clasePagos.DocValor = Convert.ToDouble(edTotal.Text);
			clasePagos.DocFecha = txtfecha.Value;
			clasePagos.DocNumero = Convert.ToDouble(txtnumero.Text);
			clasePagos.DocSucursal = datosEmpresa.suc;
			clasePagos.Doctipo = cmbDocumento.SelectedValue.ToString();
			clasePagos.pagosDelDocumento.Add(DaxComercia.utility.CrearPagoDocumento (IdPago, clasePagos.DocValor));
		}
		
		
		private void btnEstadoCta_Click(object sender, EventArgs e)
		{
			//if (codCliente == "") return;
			//DocPendientes.frmDocPndt progG = new DocPendientes.frmDocPndt(,);
			//string lasfacturas = "";
			//double ValorAplicaciones = 0;
			//progG DocsPendientes(valoresPredefinidosEmpresa. permiteCruceDocOtraSucursal, ref lasfacturas, idDocumentoActual.Sucursal, idDocumentoActual.Tipo, idDocumentoActual.idClave, codCliente, txtnombrecliente.Text, "", Convert.ToDouble(edTotal.Text), ref ValorAplicaciones, "", true);
			//progG = null;
		}

		private void btnAplicaciones_Click(object sender, EventArgs e)
		{
			DataGridViewRow row = new DataGridViewRow();
			try
			{
				row = malla.CurrentRow;
			}
			catch
			{
				MessageBox.Show("Seleccione una fila en la malla para la consulta");
				return;
			}

			//string controlaSig = Convert.ToString(row.Cells["SIGNO"].Value);
			int posicion = 6;

			//if (Convert.ToInt32(controlaSig) == -1) controlaSig = "0"; else controlaSig = "1";

			adcCtasCorrientes.frmAplicacionesDcto prog = new adcCtasCorrientes.frmAplicacionesDcto(datosEmpresa.strConxAdcom, idDocumentoActual.idClave, idDocumentoActual.Tipo, Convert.ToInt64(idDocumentoActual.numero), 0, txtfecha.Text, "", posicion, idDocumentoActual.Sucursal);
			prog.ShowDialog();
		}

		private void copiarDocumento(idDocumento idDocCopiar, Boolean esGenerar = false)
		{
			sesSys.OpcDoc opcp = new sesSys.OpcDoc();
			opcp.Cargar(idDocCopiar.Tipo);
			DataTable dttr = new DataTable();
			CopiarDocumento copia = new CopiarDocumento();
			copia.CopiarElDocumento(idDocCopiar, opcp.tablaDatosDoc, ref datADCDOC, ref dtDetalleDocumento);
			if (datADCDOC != null && datADCDOC.Doc_codper.Length > 0)
			{
				datADCDOC.IdClaveDoc = 0;
				datADCDOC.Doc_numero = Convert.ToDecimal(txtnumero.Text);
				datADCDOC.Doc_fecha = txtfecha.Value;
				if (esGenerar == false)
				{
					if (MessageBox.Show("Desea copiar la cabezera del documento ? ", "Copiar datos documento", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
					{
						cargarDatosCliente(datADCDOC.Doc_codper);
						moverCabezera();
					}
				}
				moverClaseAcontroles();
				malla.DataSource = dtDetalleDocumento;
				ModelaMalla dcut2 = new ModelaMalla();
				dcut2.diseñarMallaFacturas(ref malla, ref propiedadesDoc,accesosLocalizados);
				malla.Columns["Existencia"].Visible = valoresPredefinidosEmpresa.existenciaEnLineas;
				string tablaPagos = "ADCPAG";
				if (opcp.tablaDatosDoc.ToUpper() == "ADCDOCPRO") tablaPagos = "AdcPagPro";
				cargarFormaDePago(idDocCopiar, tablaPagos);
				LlenarIdDocumento(ref idDocumentoActual);
				idDocumentoActual.idClave = 0;
				totalizar();
				prepararBotones();
			}
			else
			{
				MessageBox.Show("No se pudo copiar el documentos requerido");
			}
		}
		private void consolidarDocumentos(idDocumento idDocCopiar)
		{
			datADCDOC = new AdcDoc(datosEmpresa.strConxAdcom);
			string tablapagos = "ADCPAG";
			string Ssql = "doc_sucursal = '" + idDocCopiar.Sucursal + "' and opc_documento ='" + idDocCopiar.Tipo + "' and idclavedoc = " + idDocCopiar.idClave.ToString();

			datADCDOC = AdcDoc.Buscar(Ssql);
			if (datADCDOC != null)
			{
				datADCDOC.IdClaveDoc = 0;
				datADCDOC.Doc_numero = Convert.ToDecimal(txtnumero.Text);

  //              this.malla.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.malla_CellValueChanged);
				if (MessageBox.Show("Desea copiar la cabezera del documento ? ", "Copiar datos documento", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
				{
					cargarDatosCliente(datADCDOC.Doc_codper);
					moverCabezera();
				}
				moverOtrosValores();
				cargarDetalleArticulosConsolidacion(idDocCopiar.Lista);
				cargarFormaDePago(idDocCopiar, tablapagos);
				LlenarIdDocumento(ref idDocumentoActual);
				idDocumentoActual.idClave = 0;
				//inicializarUtilidadDocumentos();
				totalizar();
				prepararBotones();
//                this.malla.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.malla_CellValueChanged);
			}

		}
		private void malla_DataError(object sender, DataGridViewDataErrorEventArgs e)
		{
			// Evita que el DataGridView lance excepción
			e.ThrowException = false;

			// Cancela el error temporal mientras el usuario escribe
			e.Cancel = true;
		}

		private Boolean validarDocumento()
		{
			string docsustento = "";
			//DctosEmi.impresionVerificacion util = new DctosEmi.impresionVerificacion();
			if (Convert.ToDouble("0" + txtnumero.Text) == 0) { mensajesErrorDocumento.MensajeNumeroDoc(); txtnumero.Focus(); return false; }
			if (ValidacionDocumentos.ValidacionGeneral.validarFecha(txtfecha.Text, datosEmpresa.usr) == false) { return false; };
			if (opalex.codigo == "" || codCliente == "" || txtcedula.Text == "") { mensajesErrorDocumento.ElCodigoNoExiste("C"); return false; }

			if (propiedadesDoc.TipoSoporteObligatorio != "")
			{
				if (cmbDocumentoSustento.Text == "" || nroDocSoporte.Text == "")
				{
					mensajesErrorDocumento.SinDocumentoReferencia(); return false;
				}
				else
				{
					if (clasref.LeerDocumentoReferencial(datosEmpresa.suc, cmbDocumentoSustento.SelectedValue.ToString(), nroDocSoporte.Text, idDocumentoActual) == false)
					{ clasref = null; mensajesErrorDocumento.SinDocumentoReferencia(); return false; }
				}
			}
			if (ValidacionDocumentos.ValidacionGeneral.validarIngresoDetalle(malla) == false) { mensajesErrorDocumento.sinArtículosOservicios(); return false; }
			if (ValidacionDocumentos.ValidacionGeneral.ControlValidacionFacCli(ref malla, ref propiedadesDoc, clasref, txtfecha.Text, datosEmpresa.suc, datosEmpresa.strConxAdcom, datosEmpresa.strConxSyscod, idDocumentoActual.idClave, cmbBodega.SelectedValue.ToString(), txtnumero.Text, entregasPendientes, datosEmpresa.suc, docsustento, "") == false) return false;
			if (verificarFormaDePago() == false) {return false; }
            DatosFacturacion.moverDatosAclase(this,datADCDOC);
			return true;
		}

		private Boolean grabarDocumento()
		{
            malla.EndEdit();
            Boolean RESP = true;

            string res = "";
            if (debeActualizarContacto)
            {
                if (MessageBox.Show("Se han cambiado datos del cliente, confirma Actualizar el registro ?", "Actualizar datos de Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    debeActualizarContacto = false;
                    ActualizarDatosCliente();
                }
            }
            try
            {
                if (idDocumentoActual.idClave == 0)
                {
                    res = datADCDOC.Crear();
                    idDocumentoActual.idClave = Convert.ToDouble(datADCDOC.IdClaveDoc);
                    idDocumentoActual.numero = Convert.ToDouble(datADCDOC.Doc_numero);
                    idDocumentoActual.Sucursal = datADCDOC.Doc_sucursal;
                    idDocumentoActual.Tipo = datADCDOC.Opc_documento;
					txtnumero.Text = datADCDOC.Doc_numero.ToString();
					actualizaDatosPagos();
                    if (res.Substring(0, 3) != "ERR") { grabarAdctra(); }
                    string tipDoc = cmbDocumento.SelectedValue.ToString();
                    //string tipBan = "";
                    //					if (idDocumentoActual.idClave != 0) propiedadesDoc.GuardarNumero(ref datosEmpresa.suc, ref tipDoc, ref tipBan, txtNroID.Text, "", datosEmpresa.usr, cmbBodega.SelectedValue.ToString());
                    clasePagos.guardarPagosDocumento("ADCPAG");	

					AuditSis.registrar.registraEventoDoc(datosEmpresa.strConIniSis, datosEmpresa.codEmpresa.ToString(), datosEmpresa.usr, "MDD", Environment.MachineName, AuditSis.registrar.EvntCrear, idDocumentoActual.Sucursal, idDocumentoActual.Tipo, idDocumentoActual.numero.ToString(), datADCDOC.Doc_valor.ToString());
                }
                else
                {
                    res = datADCDOC.Actualizar();
                    if (res.Substring(0, 3) != "ERR") { grabarAdctra(); }
                    actualizaDatosPagos();
                    clasePagos.guardarPagosDocumento("ADCPAG");
                    AuditSis.registrar.registraEventoDoc(datosEmpresa.strConIniSis, datosEmpresa.codEmpresa.ToString(), datosEmpresa.usr, "MDD", Environment.MachineName, AuditSis.registrar.EvntModifica, idDocumentoActual.Sucursal, idDocumentoActual.Tipo, idDocumentoActual.numero.ToString(), datADCDOC.Doc_valor.ToString());
                }
            }
            catch (Exception ee)
            {
                res = "ERR " + ee.Message;
            }
            if (res.Substring(0, 3) == "ERR")
            {
                MessageBox.Show("EL DOCUMENTO NO FUE GRABADO CORRECTAMENTE \n" + res);
                RESP = false;
            }
            return RESP;
		}
		private bool verificarFormaDePago()
		{
			double valorCredito = 0;
			double valorContado = 0;
			double valorEfectivo = 0;
			bool tieneLiq = false;

			if (clasePagos.pagosDelDocumento.Count == 0)
			{
				crearPagoPredefinido(registrarFormaDePagoPredefinida());
			}

			comercP.MntPago dp = new comercP.MntPago();
			tieneLiq = false;
			double TotalPago = 0;

			foreach (DaxComercia.pagoDoc elPago in clasePagos.pagosDelDocumento)
			{
				TotalPago += elPago.Valor;
				if (!tieneLiq) tieneLiq = (elPago.Descripcion.Contains("RETENCI"));
				if (elPago.PagoACredito == 2) { valorCredito += elPago.Valor; }
				else { valorContado += elPago.Valor; }
				if (elPago.TipoPag == "0") {valorEfectivo += elPago.Valor; }
			}
			if (Math.Round(TotalPago, 2) != Math.Round(Convert.ToDouble(totalesDocumento.TotVta), 2))
			{
                mensajesErrorDocumento.pagoDifiereTotalDoc();
                clasePagos.pagosDelDocumento.Clear();
                return false;
			}

			if (opalex.limitecredito > 0)
			{
				double saldoCliente = 0;
				string cod = "exec ADC_CCINDU '" + opalex.codigo + "','" + "01/01/1901" + "','" + txtfecha.Text + "'," + 0 + ",0,0,'C','',0,'" + datosEmpresa.suc + "','" + propiedadesDoc.Documento + "'," + idDocumentoActual.idClave.ToString();
				DataTable dt = utilBasDatos.utilBasDatos.leerTablas(cod, datosEmpresa.strConxAdcom);
				if (dt.Rows.Count > 0) saldoCliente = Convert.ToDouble(dt.Rows[0]["Saldo"].ToString());
				if (saldoCliente + valorCredito > opalex.limitecredito)
				{
					mensajesErrorDocumento.ventaExcedeCredito();
					return false;
				}
			}
			clasePagos.totalContado = valorContado;
			return true;
		}

		private void grabarAdctra()
		{
			grabMallTra.grabarMallaAdctra(malla, datADCDOC,datosEmpresa.strConxAdcom);
		}

		private void totalizar()
		{
			//ivaM = Convert.ToDecimal(malla.CurrentRow.Cells["Tra_porceniva"].Value.ToString());

			if (malla.Rows.Count < 1) return;
//			this.malla.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.malla_CellValueChanged);
			if (claseImpuestos.cambiadoManual == false)
			{
				if (claseImpuestos.impstoPorcentaje1 == 0 || claseImpuestos.impstoFechaIni1 > txtfecha.Value || claseImpuestos.impstoFechaFin1 < txtfecha.Value) claseImpuestos.cargar(datosEmpresa.strConxIvaret , txtfecha.Value);
			}
			totalesDocumento = new DctosEmi.docTotals();
			edTotal.Text = Convert.ToString(totalesDocumento.totalizar(malla, ivaM, claseDescuentos, clasePagos,propiedadesDoc, valoresPredefinidosEmpresa.nroDigitosEnPrecios , valoresPredefinidosEmpresa.nroDigitosEnCostos ));
			presentarTotales();
//			this.malla.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.malla_CellValueChanged);
			btnPagos.Enabled = (totalesDocumento.TotVta > 0) ;
			//sumarPartePago();
		}
		private void presentarTotales()
		{
			string formato = "#,0.00";
			labTotDescuentoIva.Text = totalesDocumento.totdesciva.ToString(formato);
			labTotdescuentoSinIva.Text = totalesDocumento.totdessiva.ToString(formato);
			labTotIva.Text = totalesDocumento.TotIva.ToString(formato);
			//labTotPorcIva.Text = (claseImpuestos.impstoPorcentaje1 * 100).ToString() + "% IVA";
			labTotPorcIva.Text = "Valor Iva";

			label7.Text= ("IVA "+ claseImpuestos.impstoPorcentaje1).ToString()+ "%";
			label13.Text= ("Sub.Iva "+ claseImpuestos.impstoPorcentaje1).ToString() + "%";

			labTotSubConIva5.Text = totalesDocumento.TotVta5.ToString(formato);
			labTotSubConIva15.Text = totalesDocumento.TotVta15.ToString(formato);
			labTotIva5.Text = totalesDocumento.TotIva5.ToString(formato);
			labTotIva15.Text= totalesDocumento.TotIva15.ToString(formato);


			labTotSubConIva.Text = totalesDocumento.Subtotalciva.ToString(formato);
			labTotSubSinIva.Text = totalesDocumento.SubTotalSIva.ToString(formato);
			labTotVtaConIva.Text = totalesDocumento.TotCiva.ToString(formato);
			labTotVtaSinIva.Text = totalesDocumento.TotSiva.ToString(formato);
			labTotalDescuento.Text = totalesDocumento.TotDescuentos.ToString(formato);
			labTotalVenta.Text = (totalesDocumento.TotCiva + totalesDocumento.TotSiva).ToString(formato);
			labSubtotal.Text = (totalesDocumento.Subtotalciva + totalesDocumento.SubTotalSIva ) .ToString(formato);
			labTotalFactura.Text = edTotal.Text;
		}

		private void ActualizarDatosCliente()
		{
			string insertar = "update identificacion set HistoriaClinica = '" + txtcedula.Text + "'";
			insertar += ", correoElectrónico = '" + txtCorreElectronico.Text + "'";
			insertar += ", Telefono1 = '" + txttelefono.Text + "'";
			insertar += ", Domicilio = '" + txtdireccion.Text + "'";
			insertar += " where Codigo = '" + txtcedula.Text + "' or CedulaIdentidadRuc = '" + txtcedula.Text + "' ";
			using (SqlConnection conn = new SqlConnection (datosEmpresa.strConxAdcom))
			{
				conn.Open();
				using (SqlCommand comm = new SqlCommand (insertar,conn))
				{
					comm.ExecuteNonQuery();
				}
			}
		}
		private void LlenarIdDocumento(ref idDocumento docmtoActual)
		{
			docmtoActual.Sucursal=datosEmpresa.suc ;
			docmtoActual.Tipo =cmbDocumento.SelectedValue.ToString();
			docmtoActual.fecha = txtfecha.Value;
			try
			{
				docmtoActual.numero = Convert.ToDouble(txtnumero.Text);
			}
			catch { docmtoActual.numero = 0;}
		}

		private void ChequearCambioValoresPoFecha()
		{
			//if (malla.Rows.Count > 1) totalizar();            
		}
		private void CmbDocumentoSustento_SelectedIndexChanged(object sender, EventArgs e)
		{
//            Private Sub DcDocRef_Change()
//cambiado = True
//'If TieneDatoSoporte(DcDocRef.BoundText, "DespachoInmediato", 2) Then
//If OpOpc.TipoSoporteObligatorio > "" And OpOpc.TipoSoporteObligatorio <> "ORP" Then
//    btnEntregasPendientes.Visible = True
//    EsEntregasPendientes = True
//Else
//    btnEntregasPendientes.Visible = False
//    EsEntregasPendientes = False
//End If
//End Sub

		}

		private void btnPorcentajeIva_Click(object sender, EventArgs e)
		{
			Buscar.frmBuscar progBus = new Buscar.frmBuscar();
			string ssql = "select  Porcentaje, isnull(fechaInicio,'01/01/1900') as ValidoDesde";
				ssql += ", isnull(FechaFin,'31/12/2078') as ValidoHasta from porcentajeiva";
			string nvoIva = progBus.Buscar(datosEmpresa.strConxIvaret , ssql, "porcentaje", "porcentaje", "", "Seleccionar porcentaje IVA", "");
			if (MessageBox.Show("Confirma cambiar el porcentaje del IVA en el documento ?", "Cambiar porcentaje del IVA", MessageBoxButtons.YesNo, MessageBoxIcon.Question  ) == DialogResult.No) return;
			claseImpuestos.cambiadoManual = true;
			claseImpuestos.impstoPorcentaje1 = Convert.ToDouble("0" + nvoIva) * 100;
			totalizar();
		}

		private void ptoVenta_Click(object sender, EventArgs e)
		{
            if (datosEmpresa.usr.ToUpper() == "ADMINISTRADOR")
            {
                EmpNomR.AdcNomb Retnom = new EmpNomR.AdcNomb();
                string ssql = " select Pto_codigo as Id, Pto_nombre as NombrePuntoVta from emp_ptovta where emp_codigo = '" + datosEmpresa.codEmpresa + "' and suc_codigo = '" + datosEmpresa.suc + "'";
                Buscar.frmBuscar busca = new Buscar.frmBuscar();
                string pv = busca.Buscar(datosEmpresa.strConxSyscod, ssql, "Id", "NombrePuntoVta", "", "PUNTOS DE VENTA");
                valoresPredefinidosSucursal.idPuntoVta = pv;
            }
		}

		private void txtCorreElectronico_TextChanged(object sender, EventArgs e)
		{
			debeActualizarContacto = true;
		}

		private void txtdireccion_TextChanged(object sender, EventArgs e)
		{
			debeActualizarContacto = true;
		}

		private void txttelefono_TextChanged(object sender, EventArgs e)
		{
			debeActualizarContacto = true;
		}

		//private void registraOpciones()
		//{
		//	AuditSis.registrar.registraPreferencia(datosEmpresa.strConxSyscod, datosEmpresa.codEmpresa.ToString(), datosEmpresa.usr, "CNX", datosEmpresa.suc, "Facturacion", "TipoDoc", cmbDocumento.SelectedValue.ToString());
		//	AuditSis.registrar.registraPreferencia(datosEmpresa.strConxSyscod, datosEmpresa.codEmpresa.ToString(), datosEmpresa.usr, "CNX", datosEmpresa.suc, "Facturacion", "Bodega", cmbBodega.SelectedValue.ToString());
		//	if (cmbVendedor.SelectedValue != null ) AuditSis.registrar.registraPreferencia(datosEmpresa.strConxSyscod, datosEmpresa.codEmpresa.ToString(), datosEmpresa.usr, "ADX", datosEmpresa.suc, "Facturacion", "Vendedor", cmbVendedor.SelectedValue.ToString());
		//}

		private void registraOpciones()
		{
			try
			{
				// Registrar Tipo de Documento
				if (cmbDocumento != null && cmbDocumento.SelectedValue != null)
				{
					AuditSis.registrar.registraPreferencia(datosEmpresa.strConxSyscod,
						datosEmpresa.codEmpresa.ToString(), datosEmpresa.usr, "CNX",
						datosEmpresa.suc, "Facturacion", "TipoDoc",
						cmbDocumento.SelectedValue.ToString());
				}

				// Registrar Bodega - CON VALIDACIÓN
				if (cmbBodega != null && cmbBodega.Items.Count > 0 && cmbBodega.SelectedValue != null)
				{
					AuditSis.registrar.registraPreferencia(datosEmpresa.strConxSyscod,
						datosEmpresa.codEmpresa.ToString(), datosEmpresa.usr, "CNX",
						datosEmpresa.suc, "Facturacion", "Bodega",
						cmbBodega.SelectedValue.ToString());
				}

				// Registrar Vendedor
				if (cmbVendedor != null && cmbVendedor.SelectedValue != null)
				{
					AuditSis.registrar.registraPreferencia(datosEmpresa.strConxSyscod,
						datosEmpresa.codEmpresa.ToString(), datosEmpresa.usr, "ADX",
						datosEmpresa.suc, "Facturacion", "Vendedor",
						cmbVendedor.SelectedValue.ToString());
				}
			}
			catch (Exception ex)
			{
				// Silenciosamente ignorar errores al registrar preferencias
				System.Diagnostics.Debug.WriteLine($"Error registrando preferencias: {ex.Message}");
			}
		}
		private void recordarOpciones()
		{
		   memTipoDoc = AuditSis.registrar.obtenerPreferencia (datosEmpresa.strConxSyscod, datosEmpresa.codEmpresa.ToString(), datosEmpresa.usr, "CNX", datosEmpresa.suc, "Facturacion", "TipoDoc");
		   //memBodega = AuditSis.registrar.obtenerPreferencia(datosEmpresa.strConxSyscod, datosEmpresa.codEmpresa.ToString(), datosEmpresa.usr, "ADX", datosEmpresa.suc, "Facturacion", "Bodega");
		   memVendedor = AuditSis.registrar.obtenerPreferencia(datosEmpresa.strConxSyscod, datosEmpresa.codEmpresa.ToString(), datosEmpresa.usr, "CNX", datosEmpresa.suc, "Facturacion", "Vendedor");
		}

		private void FormFacPV_FormClosed(object sender, FormClosedEventArgs e)
		{
			registraOpciones();
		}

		private void malla_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
		{
			if (malla.Rows.Count  == 0) dtDetalleDocumento.Rows.Add(dtDetalleDocumento.NewRow());
            totalizar();
		}
		private void actualizaDatosPagos()
		{
			clasePagos.DocFecha = idDocumentoActual.fecha;
			clasePagos.DocNumero = idDocumentoActual.numero;
			clasePagos.DocSucursal = idDocumentoActual.Sucursal;
			clasePagos.Doctipo = idDocumentoActual.Tipo;
			clasePagos.idClaveDoc = idDocumentoActual.idClave;

		}

		private void mensajesDocumento_Click(object sender, EventArgs e)
        {

        }

        private void btnPendientes_Click_1(object sender, EventArgs e)
        {
			DaxInvent.EntregasPendientesClienteProv prog = new  DaxInvent.EntregasPendientesClienteProv (datosEmpresa.strConxAdcom,"C",codCliente,txtnombrecliente.Text );
			prog.ShowDialog();
        }

        private void btnContabiliza_Click(object sender, EventArgs e)
        {
            DatosFacturacion.moverDatosAclase(this,datADCDOC);
            daxContaDoc.frmVisContab progCtb = new daxContaDoc.frmVisContab(asientosContables, datADCDOC, (DataTable)malla.DataSource, propiedadesDoc,clasePagos);
            asientosContables = progCtb.IniciarRevisionContable();
            progCtb.Dispose();
        }

		private void btnExportaExcel_Click(object sender, EventArgs e)
		{
			string archivoExel = EnviarAimpresora.archivoAExcell();
			if (archivoExel.Length == 0) return;
			documentosExcell.documentosExcell.generacionExcell genexcell = new documentosExcell.documentosExcell.generacionExcell(datosEmpresa.nombreBaseIvaret, datosEmpresa.strConxAdcom, datosEmpresa.strConxIvaret, datosEmpresa.strConIniSis, datosEmpresa.strConxDaxpro, datosEmpresa.Emp_codigo, datosEmpresa.pathServer);
			genexcell.GeneraDocExcell(idDocumentoActual, archivoExel);
		}

		private void btnEnviarCorreo_Click(object sender, EventArgs e)
		{
			CorreoElectronico.EnviarCorreoElectronico(idDocumentoActual, propiedadesDoc.EsElectronico);
		}

        private void btnAgrupa_Click(object sender, EventArgs e)
        {
			if (malla.Rows.Count < 2) return;
			AgruparMalla docut = new AgruparMalla();
			docut.AcumularLineasMalla(malla, "tra_cantidad", "tra_codigo", "tra_precuni");
		}

        
		private void btnSubir_Click(object sender, EventArgs e)
		{			
			MoverFilaArriba();
		}		

		private void btnBajar_Click(object sender, EventArgs e)
		{
			MoverFilaAbajo();
		}

		private void MoverFilaArriba()
		{
			if (malla.CurrentRow == null || malla.CurrentRow.Index == 0)
				return;

			int currentIndex = malla.CurrentRow.Index;
			DataRow currentRow = ((DataRowView)malla.Rows[currentIndex].DataBoundItem).Row;
			DataRow previousRow = ((DataRowView)malla.Rows[currentIndex - 1].DataBoundItem).Row;

			// Intercambiar valores entre la fila actual y la anterior
			IntercambiarFilas(currentRow, previousRow);

			// Seleccionar la nueva posición
			malla.ClearSelection();
			malla.Rows[currentIndex - 1].Selected = true;
			malla.CurrentCell = malla.Rows[currentIndex - 1].Cells[1];
		}

		private void MoverFilaAbajo()
		{
			if (malla.CurrentRow == null || malla.CurrentRow.Index == malla.Rows.Count - 2)
				return;

			int currentIndex = malla.CurrentRow.Index;
			DataRow currentRow = ((DataRowView)malla.Rows[currentIndex].DataBoundItem).Row;
			DataRow nextRow = ((DataRowView)malla.Rows[currentIndex + 1].DataBoundItem).Row;

			// Intercambiar valores entre la fila actual y la siguiente
			IntercambiarFilas(currentRow, nextRow);

			// Seleccionar la nueva posición
			malla.ClearSelection();
			malla.Rows[currentIndex + 1].Selected = true;
			malla.CurrentCell = malla.Rows[currentIndex + 1].Cells[1];
		}

		private void IntercambiarFilas(DataRow fila1, DataRow fila2)
		{
			for (int i = 0; i < fila1.Table.Columns.Count; i++)
			{
				object temp = fila1[i];
				fila1[i] = fila2[i];
				fila2[i] = temp;
			}
		}
		
		private void imprimirRToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//SaveFileDialog savefile = new SaveFileDialog();
			//savefile.FileName = string.Format("{0}.pdf", DateTime.Now.ToString("ddMMyyyyHHmmss"));

			////string PaginaHTML_Texto = "<table border=\"1\"><tr><td>HOLA MUNDO</td></tr></table>";
			//string PaginaHTML_Texto = Properties.Resources.Plantilla.ToString();
			//PaginaHTML_Texto = PaginaHTML_Texto.Replace("@EMPRESA", datosEmpresa.Emp_Nombre);
			//PaginaHTML_Texto = PaginaHTML_Texto.Replace("@DIRECCIONEMPRESA", datosEmpresa.Emp_Dirección);
			//PaginaHTML_Texto = PaginaHTML_Texto.Replace("@TELEFONOSEMPRESA", datosEmpresa.Emp_Telefono_1);
			//PaginaHTML_Texto = PaginaHTML_Texto.Replace("@RUC", datosEmpresa.Emp_RUC);
			//PaginaHTML_Texto = PaginaHTML_Texto.Replace("@NUMEROFAC", txtNroID.Text+'-'+ txtnumero.Text);
			//PaginaHTML_Texto = PaginaHTML_Texto.Replace("@NUMAUTORIZACION", "1232131231232");

			//PaginaHTML_Texto = PaginaHTML_Texto.Replace("@CLIENTE", txtnombrecliente.Text);
			//PaginaHTML_Texto = PaginaHTML_Texto.Replace("@CEDULARUC", txtcedula.Text);
			//PaginaHTML_Texto = PaginaHTML_Texto.Replace("@FECHA", txtfecha.Text);


			//if (savefile.ShowDialog() == DialogResult.OK)
			//{
			//	using (FileStream stream = new FileStream(savefile.FileName, FileMode.Create))
			//	{
			//		//Creamos un nuevo documento y lo definimos como PDF
			//		Document pdfDoc = new Document(PageSize.A4_LANDSCAPE, 20, 20, 20, 20);

			//		PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
			//		pdfDoc.Open();
			//		pdfDoc.Add(new Phrase(""));

			//		//Agregamos la imagen del banner al documento
			//		iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(Properties.Resources.shop, System.Drawing.Imaging.ImageFormat.Png);
			//		img.ScaleToFit(60, 60);
			//		img.Alignment = iTextSharp.text.Image.UNDERLYING;

			//		//img.SetAbsolutePosition(10,100);
			//		img.SetAbsolutePosition(pdfDoc.LeftMargin, pdfDoc.Top - 130);
			//		pdfDoc.Add(img);


			//		//pdfDoc.Add(new Phrase("Hola Mundo"));
			//		using (StringReader sr = new StringReader(PaginaHTML_Texto))
			//		{
			//			XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
			//		}

			//		pdfDoc.Close();
			//		stream.Close();
			//	}

			//}

		}

		private void toolStripButton2_Click(object sender, EventArgs e)
		{
			btnAgrupa.Enabled = btnBarras.Checked;
		}

		private void toolStripButton1_Click(object sender, EventArgs e)
		{
			urlE = ConfiguracionCorreo.UrlSRI;
			generarpdf(urlE);
		}

		private void generarpdf(string urlsri)
		{
			var fel = new ClassFelec.AdcFelec(datosEmpresa.strConxAdcom);
			fel = ClassFelec.AdcFelec.Buscar("");

			PathFile = fel.pathCpbFirmados + queClaveSRIE + ".xml";
			string pathAutorizados = fel.pathCpbAutorizados + queClaveSRIE + ".xml";
			string pathNoAutorizados = fel.pathpbNoAutorizados + queClaveSRIE + ".xml";
			string pathErrores = pathNoAutorizados.Replace("xml", "ERR");

			string archivoXML = pathAutorizados;
			string nombrePdf = archivoXML.Replace("xml", "PDF");
			string rutaNombre = Feutilidad.PathDocumntosPdf(fel.pathCpbGenerados) + queClaveSRIE + ".PDF";

			int IDCLAV = Convert.ToInt32(datADCDOC.IdClaveDoc);

			GenerarRide(urlsri);


			try
			{
				//MessageBox.Show(pdfPath+" genero el pdf de la api" );
				if (string.IsNullOrWhiteSpace(ConfiguracionCorreo.CorreoDesde) || string.IsNullOrWhiteSpace(ConfiguracionCorreo.Smtp) || string.IsNullOrWhiteSpace(ConfiguracionCorreo.Usuario) || string.IsNullOrWhiteSpace(ConfiguracionCorreo.Clave) || ConfiguracionCorreo.Puerto <= 0)
				{
					ErroresE = $"{queSucE}-{queDocE}-{queNumE}  {queClaveSRIE} configuración de correo incompleta o no cargada.";
					return;
				}
				else
				{
					queCodigoCliente = datADCDOC.Doc_codper;

					correoElectronico = aux.ObtenerCorreoDesdeIdentificacion(queCodigoCliente);

					if (verificaCorreoElectronico(ref correoElectronico))
					{
						if (correoElectronico.Equals(correoElectronicoDefectoE, StringComparison.OrdinalIgnoreCase))
						{
							ErroresE = $"{queSucE}-{queDocE}-{queNumE}  {queClaveSRIE} correo no enviado para evitar saturar el correo.";
							return; // omite el envío
						}
						// Rutas base
						string rutaXML = fel.pathCpbAutorizados;
						string rutaPDF = fel.pathCpbGenerados;
						//MessageBox.Show(rutaXML + "" + rutaPDF);

						// Quitar barra final si existe
						string rutaPdfSinBarra = rutaPDF.TrimEnd('\\');

						string rutaPadre = Path.GetDirectoryName(rutaPdfSinBarra);
						string rutaF = Path.Combine(rutaPadre, "GeneradosPDF");

						// Archivos por clave SRI
						string xmlPath = Path.Combine(rutaXML, $"{queClaveSRIE}.xml");
						string pdfPathCompleto = Path.Combine(rutaF, $"{queClaveSRIE}.pdf");

						//MessageBox.Show(pdfPathCompleto);

						if (File.Exists(xmlPath) && File.Exists(pdfPathCompleto))
						{
							try
							{
								using (var mensaje = new MailMessage())
								{
									string displayName = datosEmpresa.Emp_Nombre;
									mensaje.From = new MailAddress(ConfiguracionCorreo.CorreoDesde, displayName);
									mensaje.To.Add(correoElectronico);
									mensaje.Subject = $"Ha recibido su documento electronico: {queDocE}- {datADCDOC.Doc_NroIdDoc}- {queNumE}";
									mensaje.Body = $"Estimado cliente {datADCDOC.Doc_NombreImp}.\n\nAdjunto encontrará su comprobante electrónico.\n\nGracias por su preferencia.\n\n\n.";
									mensaje.IsBodyHtml = false;

									mensaje.Attachments.Add(new Attachment(pdfPathCompleto));
									mensaje.Attachments.Add(new Attachment(xmlPath));

									using (var smtpClient = new SmtpClient(ConfiguracionCorreo.Smtp, ConfiguracionCorreo.Puerto))
									{
										smtpClient.Credentials = new NetworkCredential(ConfiguracionCorreo.Usuario, ConfiguracionCorreo.Clave);
										smtpClient.EnableSsl = ConfiguracionCorreo.HabilitarSSL;
										smtpClient.Send(mensaje);
									}
								}
							}
							catch (Exception ex)
							{
								ErroresE = $"{queSucE}-{queDocE}-{queNumE}  {queClaveSRIE} error al enviar correo: {ex.Message}";
							}
						}
						else
						{
							ErroresE = $"{queSucE}-{queDocE}-{queNumE}  {queClaveSRIE} faltan archivos XML o PDF";
						}
					}
				}


			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error al generar PDF: {ex.Message}");
				// Almacenar errores si es necesario
				ErroresE = $"Error al generar PDF: {ex.Message}";
				almacenarErrores(ErroresE);
			}

		}

		private void malla_CurrentCellDirtyStateChanged(object sender, EventArgs e)
		{
			if (malla.IsCurrentCellDirty)
			{
				// Forzar commit del valor editado cuando el usuario hace clic fuera de la celda
				malla.CommitEdit(DataGridViewDataErrorContexts.Commit);
			}
		}

		private void ToolStrip3_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{

		}

		// ============================================================================
		// EVENTOS PARA MOSTRAR "SI/NO" EN TRA_SNIVA PERO GUARDAR 1/0
		// ============================================================================

		// ============================================================================
		// EVENTOS PARA MOSTRAR "SI/NO" EN TRA_SNIVA
		// ============================================================================


		private void malla_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (malla.Columns[e.ColumnIndex].Name == "TRA_SNIVA")
			{
				DataGridViewRow row = malla.Rows[e.RowIndex];

				// Filas vacías: dejar vacío
				if (row.Cells["tra_codigo"].Value == null ||
					row.Cells["tra_codigo"].Value == DBNull.Value ||
					row.Cells["tra_codigo"].Value.ToString().Trim() == "")
				{
					e.Value = "";
					e.FormattingApplied = true;
					return;
				}

				// Convertir 1/0 a SI/NO para mostrar
				if (e.Value == null || e.Value == DBNull.Value)
				{
					e.Value = "NO";
					e.FormattingApplied = true;
					return;
				}

				string valorTexto;
				if (e.Value is bool)
					valorTexto = ((bool)e.Value) ? "SI" : "NO";
				else if (e.Value is int || e.Value is short || e.Value is byte)
					valorTexto = (Convert.ToInt32(e.Value) == 1) ? "SI" : "NO";
				else
				{
					string texto = e.Value.ToString().Trim().ToUpper();
					valorTexto = (texto == "1" || texto == "TRUE" || texto == "SI" || texto == "S") ? "SI" : "NO";
				}

				e.Value = valorTexto;
				e.FormattingApplied = true;
			}
		}

		private void malla_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
		{
			if (malla.Columns[e.ColumnIndex].Name == "TRA_SNIVA")
			{
				if (e.Value == null)
				{
					e.Value = 0;
					e.ParsingApplied = true;
					return;
				}

				string texto = e.Value.ToString().Trim().ToUpper();
				e.Value = (texto == "SI" || texto == "S" || texto == "1" || texto == "TRUE") ? 1 : 0;
				e.ParsingApplied = true;
			}
		}

		private void malla_KeyDown(object sender, KeyEventArgs e)
		{

        }

        private void CalcularValorIvaFila(DataGridViewRow row)
		{
			try
			{
				double precio = 0, cantidad = 0, porcIva = 0;
				double.TryParse(row.Cells["Tra_precuni"].Value?.ToString() ?? "0", out precio);
				double.TryParse(row.Cells["tra_cantidad"].Value?.ToString() ?? "0", out cantidad);
				double.TryParse(row.Cells["Tra_porceniva"].Value?.ToString() ?? "0", out porcIva);

				double subtotal = precio * cantidad;
				double valorIva = Math.Round((subtotal * porcIva) / 100, valoresPredefinidosEmpresa.nroDigitosEnPrecios);

				row.Cells["Tra_valoriva"].Value = valorIva;
				row.Cells["Tra_prectot"].Value = Math.Round(subtotal, valoresPredefinidosEmpresa.nroDigitosEnPrecios);
			}
			catch { }
		}
		

	}
}