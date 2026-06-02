using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using daxMallaDatos;
using DaxComercia;
using classMenSistem;
using ctrlReferencia;
using ClassDoc;
using System.Drawing;
using DattCom;


namespace DctosEmi
{
	public partial class FormTransferenciaInv : Form
	{
        DatosDocFacturacion DatosFacturacion = new DatosDocFacturacion();
        internal sesSys.OpcDoc propiedadesDoc;
		directMnt.DirectorioAlex opalex = new directMnt.DirectorioAlex();
		internal AdcDoc datADCDOC;
//		internal DaxComercia.classPagosDoc clasePagos = new DaxComercia.classPagosDoc();
//		internal adcDescto.descDocumento claseDescuentos = new adcDescto.descDocumento();
//		internal IvaRett.docImpuestos claseImpuestos = new IvaRett.docImpuestos();
		internal daxAccs.propiedadesDaxAuto accesosLocalizados = new daxAccs.propiedadesDaxAuto();

		ctrlReferencia.controlReferencial clasref = new controlReferencial();
		DataTable dtDetalleDocumento = new DataTable();

		internal DctosEmi.docTotals totalesDocumento = new DctosEmi.docTotals();
        daxContaDoc.AsientosContables asientosContables = new daxContaDoc.AsientosContables();
        string claseDocDefault = "TRF";
		string tipoDocDefault = "";

		bool iniciaConNuevoDOc = false;
		internal Boolean esSoloConsulta = false;
		Boolean entregasPendientes = false;
		internal Boolean esDeLiquidacion = false;
		//Boolean debeActualizarContacto = false;

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
		internal bool DocumentoProtegido = false;
		string memTipoDoc = "";
		//string memVendedor = "";
		string memBodega = "";
		public FormTransferenciaInv(string clasdef, string tipdef, bool nuevo = false, Boolean esConsulta = false, Boolean generarFactura = false, Boolean desdeEstdoCta = false, idDocumento idDocViene = null, string sisMedico = "")
		{
			InitializeComponent();
			esSoloConsulta = esConsulta;
			if (clasdef.Length > 0) claseDocDefault = clasdef;
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
			//else
			//{
			//    idDocumentoActual.Sucursal = datosEmpresa.suc;
			//    idDocumentoActual.Tipo = tipoDocDefault;
			//    idDocumentoActual.familia = claseDocDefault;
			//}
			//ValoresSistemaMedico = sisMedico.Split(Convert.ToChar("|"));
		}
		private void CargarValoresIniciales()
		{
			this.txtfecha.ValueChanged -= new System.EventHandler(this.txtfecha_ValueChanged);
			
			txtfecha.Value = docUtils.DaxNow();

			idDocumentoActual.Tipo = tipoDocDefault;
			idDocumentoActual.familia = claseDocDefault;
			idDocumentoActual.Sucursal = datosEmpresa.suc;
			//claseImpuestos.cargar(datosEmpresa.strConxIvaret, txtfecha.Value);
			valoresPredefinidosEmpresa.cargaValores();
			valoresPredefinidosSucursal.cargarValores();
            txtNroID.Text = "";// valoresPredefinidosSucursal.idtributario;
			//txtNroID.Enabled = valoresPredefinidosSucursal.autCambiaPtoVta;
//			ptoVenta.Visible = valoresPredefinidosSucursal.autCambiaPtoVta;
			LlenarCombos();
			CargarPredefinidosDocumento();
			this.txtfecha.ValueChanged += new System.EventHandler(this.txtfecha_ValueChanged);
			this.Text += "  " + datosEmpresa.nomEmpresa + "  Sucursal: " + datosEmpresa.SucursalNombre;
		}
		private void formFacPv_Load(object sender, EventArgs e)
		{
			if (idDocumentoActual.idClave != 0)
			{
				cargarDatosDocumento(idDocumentoActual.Sucursal, idDocumentoActual.Tipo, idDocumentoActual.idClave);
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
			prepararBotones();
		}

		private void LlenarCombos()
		{
			recordarOpciones();
			DaxCombobx.CargCmbBox cmb = new DaxCombobx.CargCmbBox();
			cmb.DaxCombosDoc(claseDocDefault, "", false, datosEmpresa.strConxAdcom, ref cmbDocumento);
			cmb.DaxCombosBods(datosEmpresa.suc, false, datosEmpresa.strConIniSis, ref cmbBodega);
			cmb.DaxCombosSuc(datosEmpresa.codEmpresa.ToString(), false, datosEmpresa.strConIniSis, ref CmbSucDestino,true);
			cargarBodegaDestino();
			//cmb.DaxCombosVend(datosEmpresa.strConxAdcom, ref cmbVendedor, false);

			try
			{
				if (memTipoDoc.Length > 0)
				{
					cmbDocumento.SelectedValue = memTipoDoc;
				}
				else
				{
					cmbDocumento.SelectedValue = tipoDocDefault;
				}
			}
			catch { };
			if (cmbDocumento.SelectedValue == null) cmbDocumento.SelectedIndex = 0;
			idDocumentoActual.Tipo = cmbDocumento.SelectedValue.ToString();
			if (memBodega.Length > 0) { cmbBodega.SelectedValue = memBodega; } else { cmbBodega.SelectedIndex = 0; }
			//if (cmbVendedor.Items.Count > 0)
			//{
			//	if (memVendedor.Length > 0) { cmbVendedor.SelectedValue = memVendedor; } else { cmbVendedor.SelectedIndex = 0; }
			//}
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
				docAnulado = (datADCDOC.Doc_Estado == 0 && modificando);
			}
			catch { }

			btnAbre.Enabled = inicio;
			btnNuevo.Enabled = inicio;

			//btnCopia.Enabled = nuevo;

			btnAnula.Enabled = (modificando && !docAnulado);
			btnElimina.Enabled = modificando;
			btnEnviar.Enabled  = modificando;
			btnGraba.Enabled = (!inicio && !docAnulado);
			btnRegistra.Enabled = btnGraba.Enabled;
			btnEnviar.Enabled = (modificando && !docAnulado);
			btnCierra.Enabled = !inicio;
			//btnConsolida.Enabled = nuevo;

			//btnPagos.Enabled = btnGraba.Enabled;
			//btnDescuentos.Enabled = btnGraba.Enabled;
			//ptoVenta.Enabled = inicio;
			//btnPorcentajeIva.Enabled = btnDescuentos.Enabled;
			btnContabiliza.Enabled = btnGraba.Enabled;
			//btnExportacion.Enabled = btnGraba.Enabled;
			//btnPendientes.Enabled = btnGraba.Enabled;
			BtnVerificarIngreso.Enabled = modificando;
			btnBarras.Enabled = (!inicio) && !docAnulado;
			btnAgrupa.Enabled = (btnBarras.Enabled && btnBarras.Checked);

			panel1.Enabled = (!inicio);
			malla.Enabled = (!inicio);

			cmbDocumento.Enabled = (inicio);
			//txtcedula.Enabled = (!docAnulado);
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
				//btnCopia.Enabled  = (accesosLocalizados.Crear && btnCopia.Enabled) ;
				//btnConsolida.Enabled  = (accesosLocalizados.Crear && btnConsolida.Enabled);

			}

			//if (inicio) return;

			if (esSoloConsulta == true || docAnulado || DocumentoProtegido)
			{
				btnGraba.Enabled = false;
				btnRegistra.Enabled = false;
				btnElimina.Enabled = false;
				btnAnula.Enabled = false;
				if (datADCDOC.Doc_Estado == 1) btnElimina.Enabled = (datosEmpresa.usr.ToUpper() == "ADMINISTRADOR");
			}
			if (propiedadesDoc.ImprimirDoc == "N") btnEnviar.Visible = false;
		}

		private void registrarAccesosLocalizadosDocumento()
		{
			if (accesosLocalizados.sinRegistro) return;

			txtnumero.Enabled = accesosLocalizados.NúmeroDocumento;
			//txtNroID.Enabled = txtnumero.Enabled;
			txtfecha.Enabled = accesosLocalizados.FechaDocumento;

			cmbBodega.Enabled = accesosLocalizados.Bodega;
			if (accesosLocalizados.BodegaFija.Length > 0)
			{
				cmbBodega.SelectedValue = accesosLocalizados.BodegaFija;
				cmbBodega.Enabled = false;
			}

			//cmbVendedor.Enabled = accesosLocalizados.Vendedor;
			//if (accesosLocalizados.VendedorFijo.Length > 0)
			//{
			//	cmbVendedor.SelectedValue = accesosLocalizados.VendedorFijo;
			//	cmbVendedor.Enabled = false;
			//}

			//btnPagos.Visible = (accesosLocalizados.FormaDePago || accesosLocalizados.FormaDePagoFijo.Length > 0);
			btnContabiliza.Visible = accesosLocalizados.Contabilidad;
			//btnPorcentajeIva.Visible = accesosLocalizados.Impuestos;
			//btnDescuentos.Visible = accesosLocalizados.DescuentoDocumento;
		}

		//private void HabilitarSoporte(bool tieneSoporte)
		//{
		//	cmbDocumentoSustento.Visible = tieneSoporte;
		//	labSoporteNumero.Visible = tieneSoporte;
		//	labSoporteTipo.Visible = tieneSoporte;
		//	nroDocSoporte.Visible = tieneSoporte;
		//	btnBuscaDocumentoSoporte.Visible = tieneSoporte;
		//	if (tieneSoporte) LlenarComboDocReferencia();
		//	//if (propiedadesDoc.TipoSoporteObligatorio.Length > 0)
		//	//{
		//	//	cmbDocumentoSustento.SelectedValue = propiedadesDoc.TipoSoporteObligatorio;
		//	//	cmbDocumentoSustento.Enabled = false;
		//	//}
		//}

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
				//cmbDocumentoSustento.DataSource = dtt;
				//cmbDocumentoSustento.DisplayMember = "opc_nombre";
				//cmbDocumentoSustento.ValueMember = "opc_documento";
			}
		}

		private void BtnSalir_Click(object sender, EventArgs e)
		{
			if (classMenSistem.mensajesErrorDocumento.ConfirmaCerrar()) this.Close();
		}

		//private void BuscaCliente(string buscador)
		//{
		//	directMnt.BuscaClien directorio = new directMnt.BuscaClien();
		//	string cliente = "C";
		//	string codigo = "";
		//	string nombre = "";
		//	string conalias = "N";
		//	string connuevo = "N";
		//	codigo = directorio.IniBuscaCliOPro(ref cliente, ref nombre, ref conalias, ref connuevo);
		//	if ((codigo + "").Length > 0) cargarDatosCliente(codigo);
		//	directorio.Dispose();
		//}
//		private void cargarDatosCliente(string codigo = "")
//		{
//			// utilBasDatos datt = new utilBasDatos();
//			if (codigo != "")
//			{
//				string solocodigo = "";
//				Boolean x = false;
//				opalex = new directMnt.DirectorioAlex();
//				opalex.CargarAlex(ref codigo, ref x, ref solocodigo);
//				if (opalex.codigo == null) codigo = ""; else codigo = opalex.codigo;
//				if (codigo.Length > 0)
//				{
//					codCliente = opalex.codigo;
//					//txtcedula.Text = opalex.CiRuc;
//					//txtnombrecliente.Text = opalex.NombreImpresion;
//					//txtdireccion.Text = opalex.direccion;
//					//txtCorreElectronico.Text = opalex.correoElectronico;
//					//txttelefono.Text = opalex.telefono1;
//				}
//			}
//			if (codigo == "")
//			{
//				codCliente = "";
//				txtcedula.Text = "";
//				txtnombrecliente.Text = "";
//				//txtdireccion.Text = "";
//				//txtCorreElectronico.Text = "";
//				//txttelefono.Text = "";
//				opalex = null;
//			}
////			debeActualizarContacto = false;
//		}
        private Boolean cargarDatosDocumento(string SUC, string TIPO, double IDCLAVE, double NUMERO=0)
		{
			Boolean resp = false;
			if (IDCLAVE != 0)
			{
				datADCDOC = new AdcDoc(datosEmpresa.strConxAdcom);
				datADCDOC = AdcDoc.Buscar(" doc_sucursal = '" + SUC + "' and opc_documento ='" + TIPO + "' and idclavedoc = " + IDCLAVE.ToString());
				if (datADCDOC != null)
				{
					if (SUC.ToUpper() != datosEmpresa.suc.ToUpper())
					{
						if (datADCDOC.doc_SucDestino.ToUpper() != datosEmpresa.suc.ToUpper())
						{ mensajesErrorDocumento.documentosNoDeOtraSucursal(datosEmpresa.sucNom); return false; }
						DocumentoProtegido = true;
					}

					//cargarDatosCliente(datADCDOC.Doc_codper);
					moverClaseAcontroles();
					if (Convert.ToInt32(datADCDOC.Doc_Estado) == 0) mensajesDocumento.Text = "DOCUMENTO ANULADO : " + datADCDOC.MotivoAnulacion;
					cargarDetalleArticulos(idDocumentoActual.Sucursal, idDocumentoActual.Tipo, idDocumentoActual.idClave, "ADCTRA");
					//cargarFormaDePago(idDocumentoActual, "ADCPAG");
					totalizar();
					operacionEnCurso = modificandoRegistro;
					prepararBotones();
					resp = true;
					txtnumero.Enabled = false;
					//debeActualizarContacto = false;
				}
			}
			else { }
			return resp;
		}

		private void cargarDetalleArticulos(string suc, string tip, double idClave, string tablatra)
		{
			armarConsTra dcut = new armarConsTra();
			ModelaMalla  dcut2 = new ModelaMalla();

			dtDetalleDocumento = utilBasDatos.utilBasDatos.leerTablas(dcut.armarSqlLecturaTransferencia( propiedadesDoc,"Adctra", suc, tip, idClave), datosEmpresa.strConxAdcom);
			if (dtDetalleDocumento == null) return;
			malla.DataSource = dtDetalleDocumento;
			dcut2.diseñarMallaTransferencias(ref malla, ref propiedadesDoc);
			malla.Columns["Existencia"].Visible = valoresPredefinidosEmpresa.existenciaEnLineas;
		
		}
		//private void cargarDetalleArticulosConsolidacion(string listaDocumentos)
		//{
		//	DctosEmi.armarConsTra dcut = new DctosEmi.armarConsTra();
		//	DctosEmi.diseñarMalla dcut2 = new DctosEmi.diseñarMalla();

		//	dtDetalleDocumento = utilBasDatos.utilBasDatos.leerTablas(dcut.armarSqlLecturaTraFacConsolida("ADCTRA", listaDocumentos), datosEmpresa.strConxAdcom);
		//	dcut = null;
		//	if (dtDetalleDocumento == null) return;
		//	malla.DataSource = dtDetalleDocumento;
		//	if (malla.Rows.Count > 0) dcut2.diseñarMallaFacCli(ref malla, ref propiedadesDoc);

		//	dcut = null;
		//	dcut2 = null;
		//}
		//private void cargarFormaDePago(idDocumento iddoc, string tabla)
		//{
		//	clasePagos = new DaxComercia.classPagosDoc
		//	{
		//		strConx = datosEmpresa.strConxAdcom,
		//		DocSucursal = iddoc.Sucursal,
		//		Doctipo = iddoc.Tipo,
		//		idClaveDoc = iddoc.idClave,
		//		DocNumero = iddoc.numero,
		//		DocFecha = iddoc.fecha
		//	};
		//	clasePagos.cargarPagosDocumento(tabla);
		//}
		private void moverClaseAcontroles()
		{
			moverCabezera();
			//moverOtrosValores();
		}
		private void moverCabezera()
		{

			idDocumentoActual.idClave = Convert.ToDouble(datADCDOC.IdClaveDoc);
			codCliente = datADCDOC.Doc_codper;

			txtnumero.Text = datADCDOC.Doc_numero.ToString();
			//if (datADCDOC.Doc_NroIdDoc.ToString() != "") txtNroID.Text = datADCDOC.Doc_NroIdDoc.ToString();
			txtfecha.Text = datADCDOC.Doc_fecha.ToShortDateString();
			//txtcedula.Text = datADCDOC.Doc_CiRuc;
			//txtnombrecliente.Text = datADCDOC.Doc_NombreImp;
			//txtdireccion.Text = datADCDOC.Doc_Direccion;

			txtDetalle.Text = datADCDOC.Doc_detalle;
			CmbSucDestino.SelectedValue = datADCDOC.doc_SucDestino;
			CmbBodDestino.SelectedValue = datADCDOC.doc_BodDestino;
			//cmbVendedor.SelectedValue = datADCDOC.Doc_venabre;
		}
		//private void moverOtrosValores()
		//{
		//	claseDescuentos = new adcDescto.descDocumento();
		//	//claseImpuestos = new IvaRett.docImpuestos();
		//	claseDescuentos.nombreDes[0] = datADCDOC.Doc_nombredes1;
		//	claseDescuentos.nombreDes[1] = datADCDOC.Doc_nombredes2;
		//	claseDescuentos.nombreDes[2] = datADCDOC.Doc_nombredes3;

		//	claseDescuentos.porcentajeDes[0] = Convert.ToDouble(datADCDOC.Doc_porcendes1);
		//	claseDescuentos.porcentajeDes[1] = Convert.ToDouble(datADCDOC.Doc_porcendes2);
		//	claseDescuentos.porcentajeDes[2] = Convert.ToDouble(datADCDOC.Doc_porcendes3);

		//	claseDescuentos.valorDes[0] = Convert.ToDouble(datADCDOC.Doc_valordes1);
		//	claseDescuentos.valorDes[1] = Convert.ToDouble(datADCDOC.Doc_valordes2);
		//	claseDescuentos.valorDes[2] = Convert.ToDouble(datADCDOC.Doc_valordes3);

		//	//claseImpuestos.impstoPorcentaje1 = Convert.ToDouble(datADCDOC.Doc_porceniva);
		//	//claseImpuestos.impstoNombre1 = "IVA";

		//}
		//private void moverDatosClase()
		//{
		//	datADCDOC.Doc_sucursal = datosEmpresa.suc;
		//	datADCDOC.Doc_Bodega = cmbBodega.SelectedValue.ToString();
		//	datADCDOC.Opc_documento = cmbDocumento.SelectedValue.ToString();
		//	datADCDOC.Doc_docnombre = cmbDocumento.Text;
		//	datADCDOC.Doc_numero = Convert.ToDecimal(txtnumero.Text);
		//	datADCDOC.Doc_fecha = Convert.ToDateTime(txtfecha.Text);
		//	datADCDOC.Doc_codper = codCliente;
		//	datADCDOC.Doc_CiRuc = txtcedula.Text;
		//	datADCDOC.Doc_NombreImp = txtnombrecliente.Text;
		//	datADCDOC.Doc_Direccion = txtdireccion.Text;
		//	datADCDOC.Doc_Telefono1 = txttelefono.Text;
		//	datADCDOC.Doc_detalle = txtDetalle.Text;
		//	datADCDOC.Doc_venabre = cmbVendedor.SelectedValue.ToString();
		//	datADCDOC.Doc_DocSop = "";
		//	datADCDOC.Doc_NumSop = 0;
		//	datADCDOC.Doc_valor = Convert.ToDecimal(edTotal.Text);
		//	datADCDOC.AuxVar9 = txtCorreElectronico.Text;

		//	if (operacionEnCurso == 1)
		//	{
		//		datADCDOC.PuntoVta = valoresPredefinidosSucursal.nomPuntoVta;
		//		datADCDOC.Doc_Hora = docUtils.DaxNow();
		//		datADCDOC.Doc_Estado = 1;
		//	}

		//	datADCDOC.Doc_nombredes1 = claseDescuentos.nombreDes[0];
		//	datADCDOC.Doc_nombredes2 = claseDescuentos.nombreDes[1];
		//	datADCDOC.Doc_nombredes3 = claseDescuentos.nombreDes[2];

		//	datADCDOC.Doc_porcendes1 = Convert.ToDecimal(claseDescuentos.porcentajeDes[0]);
		//	datADCDOC.Doc_porcendes2 = Convert.ToDecimal(claseDescuentos.porcentajeDes[1]);
		//	datADCDOC.Doc_porcendes3 = Convert.ToDecimal(claseDescuentos.porcentajeDes[2]);

		//	datADCDOC.Doc_valordes1 = Convert.ToDecimal(claseDescuentos.valorDes[0]); ;
		//	datADCDOC.Doc_valordes2 = Convert.ToDecimal(claseDescuentos.valorDes[1]);
		//	datADCDOC.Doc_valordes3 = Convert.ToDecimal(claseDescuentos.valorDes[2]);

		//	datADCDOC.Doc_porceniva = Convert.ToDecimal(claseImpuestos.impstoPorcentaje1);

		//	datADCDOC.Doc_NroLoteDoc =  txtNroLote.Text;
		//	datADCDOC.Doc_NroIdDoc = txtNroID.Text;
		//	datADCDOC.Adi_TipoDocSri = propiedadesDoc.TipoSri;
		//	//datADCDOC.Adi_FechContab = IIf(FechaContab < TxtFecha, TxtFecha, FechaContab)
		//	//datADCDOC.Adi_CodigoNSR = TexCodigoExoneraRetencion.Text
		//	//datADCDOC.Adi_SustTrib = DatSustento.BoundText
		//	//datADCDOC'.Adi_SNDevIva = IIf(DerechoIva.Value = 1, "S", "N")
		//	datADCDOC.IdClaveDoc = Convert.ToDecimal(idDocumentoActual.idClave);
		//	datADCDOC.IdClaveDocSop = 0;
		//	datADCDOC.Doc_docnombre = cmbDocumento.Text; 
		//	datADCDOC.Doc_TipoDoc = propiedadesDoc.TipoDoc;
		//	datADCDOC.Doc_FechaEfe = Convert.ToDateTime(txtfecha.Text);     //FechaVence.Value
		//	datADCDOC.Doc_extension = "";
		//	datADCDOC.Doc_codusu = datosEmpresa.usr;
		//	datADCDOC.Doc_valoriva = totalesDocumento.TotIva;
		//	datADCDOC.Doc_totciva = totalesDocumento.TotCiva;
		//	datADCDOC.Doc_totsiva = totalesDocumento.TotSiva;
		//	datADCDOC.Doc_valorabon = Convert.ToDecimal(clasePagos.totalContado);
		//	datADCDOC.Doc_DepDes = "";
		//	datADCDOC.Doc_TotDesArt = totalesDocumento.TotDesArt;
		//	datADCDOC.Doc_TotDesSer = totalesDocumento.TotDesSer;
		//	datADCDOC.Doc_TotArtCIva = totalesDocumento.TotArtCIva;
		//	datADCDOC.Doc_TotArtSIva = totalesDocumento.TotArtSIva;
		//	datADCDOC.Doc_TotSerCIva = totalesDocumento.TotSerCIva;
		//	datADCDOC.Doc_TotSerSIva = totalesDocumento.TotSerSIva;
		//	datADCDOC.Doc_TotAcf = totalesDocumento.TotAcf;
		//	datADCDOC.Doc_Contado = totalesDocumento.ValorEfec;
		//	datADCDOC.Doc_Oculto = propiedadesDoc.ClaveOculto;
		//	datADCDOC.Doc_Contabilidad = propiedadesDoc.ClaveContable;
		//	datADCDOC.Doc_Banco = Convert.ToInt16(propiedadesDoc.ClaveBanco);
		//	datADCDOC.Doc_Inventario = Convert.ToInt16(propiedadesDoc.ClaveInventario);
		//	datADCDOC.Doc_Ventas = Convert.ToInt16(propiedadesDoc.ClaveVentas);
		//	datADCDOC.Doc_Compras = Convert.ToInt16(propiedadesDoc.ClaveCompras);
		//	datADCDOC.Doc_Activo = Convert.ToInt16(propiedadesDoc.ClaveActivo);
		//	datADCDOC.Doc_Adicional2 = 0;
		//	datADCDOC.Doc_NumeroExterno = 0;
		//	datADCDOC.IdClaveDocSop = Convert.ToDecimal( idDocumentoSoporte.idClave);
		//	datADCDOC.Doc_FechaModifica = docUtils.DaxNow();
		//	datADCDOC.doc_TotDesSiva = totalesDocumento.totdessiva;
		//	datADCDOC.doc_TotDesCIva = totalesDocumento.totdesciva;
		//	//datADCDOC.Adi_NroAutSri = "";                   //TextNroAutSri
		//	datADCDOC.ProductoProduccion = "";            // ProductoProduccion.Text
		//	datADCDOC.BaseImp1 = totalesDocumento.Subtotalciva;
		//	datADCDOC.ValorImp1 = totalesDocumento.TotImp1;
		//	datADCDOC.PorcImp1 = Convert.ToDecimal(claseImpuestos.impstoPorcentaje1);

		//	//datADCDOC.BaseImp2 = totalesDocumento.Subtotalciva2;
		//	datADCDOC.ValorImp2 = totalesDocumento.TotImp2;
		//	datADCDOC.PorcImp2 = Convert.ToDecimal(claseImpuestos.impstoPorcentaje2);

		//	//datADCDOC.BaseImp3 = totalesDocumento.Subtotalciva3;
		//	datADCDOC.ValorImp3 = totalesDocumento.TotImp2;
		//	datADCDOC.PorcImp3 = Convert.ToDecimal(claseImpuestos.impstoPorcentaje2);

		//	//datADCDOC.FacDesde = FDesde.Value;
		//	//datADCDOC.FacDesde = FDesde.Value;
		//	//datADCDOC.FacDesde = FDesde.Value;
		//	//datADCDOC.FacHasta = FHasta.Value;
		//	//datADCDOC.TipoPeriodo = "";
		//}


		private void btnCierra_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Confirma cerrar el documento actual ?", "Cerrar documento sin grabar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No) return;
			if (esSoloConsulta) Close();
			limpiarDatos();
		}
		private void limpiarDatos()
		{
			txtnumero.Enabled = true;
			datADCDOC = new AdcDoc(datosEmpresa.strConxAdcom);
			//clasePagos = new DaxComercia.classPagosDoc();
			//claseDescuentos = new adcDescto.descDocumento();
			totalesDocumento = new DctosEmi.docTotals();
			clasref = new controlReferencial();
			//txtcedula.Text = "";
			//txtCorreElectronico.Text = "";
			txtDetalle.Text = "";
			//txtdireccion.Text = "";
			//txtnombrecliente.Text = "";
			txtnumero.Text = "";
			//txttelefono.Text = "";
			mensajesDocumento.Text = "";
			idDocumentoActual.idClave = 0;
			esDeLiquidacion = false;
			//debeActualizarContacto = false;
			idDocumentoActual = new idDocumento
			{
				fecha = txtfecha.Value
			};
			idDocumentoSoporte = new idDocumento();
			dtDetalleDocumento = new DataTable();
			malla.DataSource = null;
			totalizar();
			edTotal.Text = totalesDocumento.TotVta.ToString("#,0.00");
            //clasePagos = new DaxComercia.classPagosDoc();
            txtNroID.Text = ""; //valoresPredefinidosSucursal.idtributario ;
			txtfecha.Value = docUtils.DaxNow();
			operacionEnCurso = 0;
			DocumentoProtegido = false;
			prepararBotones();
		    InicializarMalla();
		}
		private void InicializarMalla()
		{
			//  this.malla.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.malla_CellValueChanged);
			armarConsTra dcut = new armarConsTra();
			ModelaMalla dcut2 = new ModelaMalla();

			dtDetalleDocumento = utilBasDatos.utilBasDatos.leerTablas(dcut.armarSqlLecturaTransferencia(propiedadesDoc, "ADCTRA",datosEmpresa.suc, idDocumentoActual.Tipo , 0), datosEmpresa.strConxAdcom);
			if (dtDetalleDocumento == null) return;
			malla.DataSource = dtDetalleDocumento;
			dtDetalleDocumento.Rows.Add(dtDetalleDocumento.NewRow());
			dcut2.diseñarMallaTransferencias(ref malla, ref propiedadesDoc);
			dcut2 = null;
			}

		//private void malla_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		//{
		//    //if (e.ColumnIndex < 0 || saltaEventosMalla == true)
		//    //{
		//    //    return;
		//    //}

		//    //string nomCol = malla.Columns[e.ColumnIndex].Name.ToUpper();
		//    //if (nomCol == "TRA_PRECUNI" || nomCol == "TRA_CANTIDAD" || nomCol == "TRA_PORCENDES" || nomCol == "TRA_SNIVA" || nomCol == "TRA_MULTIPLO") totalizar();
		//}
		private void malla_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex < 0 || saltaEventosMalla == true)
			{
				return;
			}

			string nomCol = malla.Columns[e.ColumnIndex].Name.ToUpper();
			if (malla.Rows.Count > propiedadesDoc.LineasMaximas && nomCol == "TRA_CODIGO")
			{
				MessageBox.Show("El documento tiene un número máximo de " + propiedadesDoc.LineasMaximas.ToString() + " lineas para su impresión ", "INFORMACION DE DOCUMENTOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			if (DctosEmi.ValidarDatos.ValidarDatosVentas(nomCol,malla.Rows[e.RowIndex], accesosLocalizados) == false) return;
			if (nomCol == "TRA_PRECUNI" || nomCol == "TRA_CANTIDAD" || nomCol == "TRA_PORCENDES" || nomCol == "TRA_SNIVA" || nomCol == "TRA_MULTIPLO") totalizar();
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
		private void btnCopia_Click(object sender, EventArgs e)
		{
			string SUC = datosEmpresa.suc;
			string TIP = "";
			double Idclave = 0;
			double Numero = 0;
			BuscadorDocumentos.buscadorDoc progBus = new BuscadorDocumentos.buscadorDoc();
			DateTime queFecha = docUtils.DaxNow();
			progBus.IniciaBusqueda("FAC", "", "", queFecha, ref SUC, ref TIP, ref Numero, ref Idclave, false, "", "", "", "ADCDOC");
			if (Idclave != 0)
			{
				idDocumentoParaGenerar.Sucursal = SUC;
				idDocumentoParaGenerar.Tipo = TIP;
				idDocumentoParaGenerar.idClave = Idclave;
				copiarDocumento(idDocumentoParaGenerar, false);
			}
			progBus = null;
		}
		//private void btnConsolida_Click(object sender, EventArgs e)
		//{
		//	string SUC = datosEmpresa.suc;
		//	string TIP = "";
		//	double Idclave = 0;
		//	double Numero = 0;
		//	BuscadorDocumentos.buscadorDoc progBus = new BuscadorDocumentos.buscadorDoc();
		//	DateTime queFecha = docUtils.DaxNow();
		//	idDocumentoParaGenerar = new idDocumento
		//	{
		//		Lista = progBus.IniciaConsolidacion(DctosEmi.ConsolidaDoc.tiposDoctsConsolidaSql(datosEmpresa.strConxAdcom), codCliente, "", queFecha, ref SUC, ref TIP, ref Numero, ref Idclave, false, "", "", "", "ADCDOC")
		//	};
		//	if (Idclave != 0 && idDocumentoParaGenerar.Lista.Length > 0)
		//	{
		//		idDocumentoParaGenerar.Sucursal = SUC;
		//		idDocumentoParaGenerar.Tipo = TIP;
		//		idDocumentoParaGenerar.idClave = Idclave;
		//		consolidarDocumentos(idDocumentoParaGenerar);
		//	}
		//	progBus = null;
		//}
		//private void btnBuscaCliente_Click(object sender, EventArgs e)
		//{
		//	BuscaCliente(txtnombrecliente.Text);
		//}
		private void BtnAbre_Click(object sender, EventArgs e)
		{
			BuscadorDocumentos.buscadorDoc progBus = new BuscadorDocumentos.buscadorDoc();
			idDocumentoActual.Sucursal = datosEmpresa.suc;
			DateTime queFecha = docUtils.DaxNow();
			progBus.IniciaBusqueda(claseDocDefault, "", cmbDocumento.SelectedValue.ToString(), queFecha, ref idDocumentoActual.Sucursal, ref idDocumentoActual.Tipo, ref idDocumentoActual.numero, ref idDocumentoActual.idClave, false, cmbDocumento.SelectedValue.ToString(), "", "", "ADCDOC");
			DocumentoProtegido = false;
			if (idDocumentoActual.idClave == 0)
			{
				idDocumentoActual.Sucursal = datosEmpresa.suc; return;
			}

			if (idDocumentoActual.idClave != 0) cargarDatosDocumento(idDocumentoActual.Sucursal, idDocumentoActual.Tipo, idDocumentoActual.idClave);
		}
		private void btnGraba_Click(object sender, EventArgs e)
		{
			if (validarDocumento() == true)
			{
				if (grabarDocumento() == true) { limpiarDatos(); }
			}

		}
		//private void btnPagos_Click(object sender, EventArgs e)
		//{
		//	string pagoPredefinido = "";
		//	if (clasePagos.pagosDelDocumento.Count == 0)
		//	{
		//		pagoPredefinido = registrarFormaDePagoPredefinida();
		//		crearPagoPredefinido(pagoPredefinido);
		//	}
		//	DaxComercia.MntPago PagosDoc = new DaxComercia.MntPago();
		//	PagosDoc.INIPagos(idDocumentoActual.idClave, ref clasePagos, opalex.codigo, datosEmpresa.suc, propiedadesDoc.TipoDoc, txtfecha.Text, false, cmbDocumento.SelectedValue.ToString(), Convert.ToDouble("0" + txtnumero.Text), pagoPredefinido, Convert.ToDouble("0" + edTotal.Text), false);
		//	PagosDoc = null;
		//}

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
		//private void btnDescuentos_Click(object sender, EventArgs e)
		//{            
  //          adcDescto.ingDescDoc ingdesc = new adcDescto.ingDescDoc();
		//	ingdesc.ingresarDescuentos(ref claseDescuentos, datosEmpresa.strConxAdcom, datosEmpresa.suc, valoresPredefinidosEmpresa.nroDescuentosMaximosDocto);
		//	ingdesc.Dispose();
		//	totalizar();
		//}

		private void btnRegistra_Click(object sender, EventArgs e)
		{
			if (validarDocumento() == true)
			{
				if (grabarDocumento() == true)
				{
					EnviarAimpresora.imprimirDocumentoDirectamente(datADCDOC, accesosLocalizados, idDocumentoActual);
					limpiarDatos();
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
		//private void txtCorreElectronico_KeyDown(object sender, KeyEventArgs e)
		//{
		//	if (e.KeyCode == Keys.F2)
		//	{
		//		txtCorreElectronico.Text = valoresPredefinidosEmpresa.correoElectronicoDefecto;
		//	}
		//}
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


		//private void Txtcedula_Leave(object sender, EventArgs e)
		//{
		//	KeyEventArgs ee = new KeyEventArgs(Keys.Return);
		//	//txtcedula_KeyDown(sender, ee);
		//}

		//private void txtcedula_KeyDown(object sender, KeyEventArgs e)
		//{
		//	if (e.KeyCode == Keys.Return && txtcedula.Text.Length > 0) ingresaCodigoClienteDirecto();
		//}
		//private void ingresaCodigoClienteDirecto()
		//{
		//	string codigo = txtcedula.Text;
		//	string tipo = "C";
		//	cargarDatosCliente(codigo);
		//	if (txtcedula.Text == "")
		//	{
		//		if (MessageBox.Show("El cliente no existe desea registarlo ? ", "Creacion de cliente nuevo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
		//		{

		//			directMnt.CreaCliAlex express = new directMnt.CreaCliAlex();
		//			express.IniCrearAlex(ref tipo, ref codigo);
		//		}
		//	}
		//	if ((codigo + "").Length > 0) cargarDatosCliente(codigo);
		//}
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
			if (operacionEnCurso != 2 && txtnumero.TextLength > 0)
			{
				verificaNroDocumentoDigitado();
			}
		}
		private void txtnumero_KeyDown(object sender, KeyEventArgs e)
		{
			saltarEventoNumero = true;
			if (e.KeyCode == Keys.Return && txtnumero.TextLength > 0)
			{
				verificaNroDocumentoDigitado();
			}
		}
		private void verificaNroDocumentoDigitado()
		{
			LlenarIdDocumento(ref idDocumentoActual);
            //idDocumentoActual.numero = Convert.ToDouble(txtnumero.Text);
            impresionVerificacion.verificarExistenciaDocumento(ref idDocumentoActual, datosEmpresa.strConxAdcom,false, "ADCDOC");
			if (idDocumentoActual.idClave > 0) { cargarDatosDocumento(idDocumentoActual.Sucursal, idDocumentoActual.Tipo, idDocumentoActual.idClave);}
            else { MessageBox.Show("El documento digitado no existe");}
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
				DaxMallaLib.Documentos.MoverCelda(malla,btnBarras.Checked);
				return true;
			}
			return false;
		}

		#endregion manejo malla
		private Boolean funcionesEspeciales(ref Keys keyData, DataGridView malla)
		{

            docMallaArticulo mallaArticulo = new docMallaArticulo();
            Boolean resp = true;
            malla.EndEdit();
            DataGridViewCell cell = malla.CurrentCell;
            string dato = cell.Value.ToString();
            string nombreCelda = cell.OwningColumn.Name.ToUpper();

            if (keyData == Keys.F8 && cell.ReadOnly == false && malla.Columns[cell.ColumnIndex].Name.ToUpper() != "TRA_CODIGO")
            {
                if (cell.RowIndex > 0) cell.Value = malla.Rows[cell.RowIndex - 1].Cells[cell.ColumnIndex].Value;
            }
            else if (keyData == Keys.F3 && cell.ValueType.Name.ToUpper() == "DATETIME")
            {
                cell.Value = docUtils.DaxNow().ToShortDateString();
            }
            else
            {
                switch (nombreCelda)
                {
                    //case "TRA_PRECUNI":
                    //    if (keyData >= Keys.F2 && keyData <= Keys.F6)
                    //    {
                    //        DataGridViewRow row = malla.CurrentRow;
                    //        daxMallaDatos.docMallaArticulo preVta = new docMallaArticulo();
                    //        Int32 quePrecio = 0;
                    //        cell.Value = cargarPrecios.CargarPrecioVta(Convert.ToInt16(keyData), malla.CurrentRow.Cells["tra_Codigo"].Value.ToString(), claseImpuestos.impstoPorcentaje1, ref quePrecio, "", row.Cells["tra_Medida"].Value.ToString(), "", valoresPredefinidosEmpresa.nroDigitosEnPrecios);
                    //        //	totalizar();
                    //    }
                    //    break;
                    case "TRA_CODIGO":
                        if (dato != ".")
                        {
                            try
                            {
                                mallaArticulo.bodega = ""; //cmbBodega.SelectedValue.ToString();
                            }
                            catch { }
                            saltaEventosMalla = true;
                            mallaArticulo.digCostos = valoresPredefinidosEmpresa.nroDigitosEnCostos;
                            mallaArticulo.digPrecios = valoresPredefinidosEmpresa.nroDigitosEnPrecios;
                            mallaArticulo.fechaDoc = Convert.ToDateTime(txtfecha.Text);
                            mallaArticulo.impIva = 0;// claseImpuestos.impstoPorcentaje1;
                            mallaArticulo.codCliente = codCliente;
                            mallaArticulo.sucursal = datosEmpresa.suc;
                            mallaArticulo.tipoDoc = cmbDocumento.SelectedValue.ToString();
                            mallaArticulo.numDoc = txtnumero.Text;

                            if (keyData == Keys.F2)
                            {
                                dato = mallaArticulo.BuscarArticuloSimple(malla.CurrentCell.Value.ToString());
                                if (mallaArticulo.CargarArticulo(malla, ref propiedadesDoc, dato, opalex.TipoCliente, txtfecha.Text, propiedadesDoc.Documento, idDocumentoActual.idClave) == false) { cell.Value = ""; keyData = Keys.Cancel; }
                            }
                            //else if (keyData == Keys.F3)
                            //{
                            //    DaxConceptos.classConceptos buscserv = new DaxConceptos.classConceptos();
                            //    dato = buscserv.iniciaBuscador(datosEmpresa.strConxAdcom, "", "V", false, false);
                            //    if (dato != "") mallaArticulo.CargarServicios(dato, ref malla, claseImpuestos.impstoPorcentaje1, valoresPredefinidosEmpresa.nroDigitosEnPrecios, Convert.ToDateTime(txtfecha.Text), ref propiedadesDoc);
                            //}
                            else if (keyData == Keys.Return && dato.Length > 0)
                            {
                                if (mallaArticulo.CargarConDesicion(malla, ref propiedadesDoc, dato, opalex.TipoCliente, txtfecha.Text, propiedadesDoc.Documento, idDocumentoActual.idClave) == false) { cell.Value = ""; keyData = Keys.Cancel; }								
                            }
                            else if (keyData == Keys.F11)
                            {
                                dato = mallaArticulo.BuscarArticulo(malla.CurrentCell.Value.ToString());
                                if (mallaArticulo.CargarArticulo(malla, ref propiedadesDoc, dato, opalex.TipoCliente, txtfecha.Text, propiedadesDoc.Documento, idDocumentoActual.idClave) == false) { cell.Value = ""; keyData = Keys.Cancel; }
                            }

                            //        VerificarClasificadoresContablesArticulo dato
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
            if (cell.Value.ToString() != "") { keyData = Keys.Return; } else { keyData = Keys.Cancel; }
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

		//private void crearPagoPredefinido(string IdPago)
		//{
		//	if (IdPago == "") IdPago = "EFE";
		//	clasePagos.DocValor = Convert.ToDouble(edTotal.Text);
		//	clasePagos.DocFecha = txtfecha.Value;
		//	clasePagos.DocNumero = Convert.ToDouble(txtnumero.Text);
		//	clasePagos.DocSucursal = datosEmpresa.suc;
		//	clasePagos.Doctipo = cmbDocumento.SelectedValue.ToString();
		//	clasePagos.pagosDelDocumento.Add( DaxComercia.utility.CrearPagoDocumento (IdPago, clasePagos.DocValor));
		//}
		
		private void imprimirDocumento()
		{
			if (accesosLocalizados.NroImpresiones > 0 && accesosLocalizados.NroImpresiones <= datADCDOC.Doc_Adicional1)
			{ MessageBox.Show("Ha llegado al límite de impresiones permitidas", "Imprimir documentos", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
			ImpresionDocumentosDax.ImprimeDocumentoDoble impProg = new ImpresionDocumentosDax.ImprimeDocumentoDoble(datosEmpresa.nombreBaseIvaret, datosEmpresa.strConxAdcom, datosEmpresa.strConxIvaret, datosEmpresa.strConxSyscod, datosEmpresa.strConxDaxpro, datosEmpresa.codEmpresa, datosEmpresa.pathServer);
			int imp = impProg.ImpDoc(idDocumentoActual, "A", "", false, false);
			datADCDOC.Doc_Adicional1 = imp;
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
						//cargarDatosCliente(datADCDOC.Doc_codper);
						moverCabezera();
					}
				}
				moverClaseAcontroles();
				malla.DataSource = dtDetalleDocumento;
				ModelaMalla dcut2 = new ModelaMalla();
				dcut2.diseñarMallaFacturas(ref malla, ref propiedadesDoc);
				malla.Columns["Existencia"].Visible = valoresPredefinidosEmpresa.existenciaEnLineas;
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
//		private void consolidarDocumentos(idDocumento idDocCopiar)
//		{
//			datADCDOC = new AdcDoc(datosEmpresa.strConxAdcom);
//			//string tablapagos = "ADCPAG";
//			string Ssql = "doc_sucursal = '" + idDocCopiar.Sucursal + "' and opc_documento ='" + idDocCopiar.Tipo + "' and idclavedoc = " + idDocCopiar.idClave.ToString();

//			datADCDOC = AdcDoc.Buscar(Ssql);
//			if (datADCDOC != null)
//			{
//				datADCDOC.IdClaveDoc = 0;
//				datADCDOC.Doc_numero = Convert.ToDecimal(txtnumero.Text);

//  //              this.malla.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.malla_CellValueChanged);
//				if (MessageBox.Show("Desea copiar la cabezera del documento ? ", "Copiar datos documento", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
//				{
//					//cargarDatosCliente(datADCDOC.Doc_codper);
//					moverCabezera();
//				}
//				//moverOtrosValores();
//				cargarDetalleArticulosConsolidacion(idDocCopiar.Lista);
//				//cargarFormaDePago(idDocCopiar, tablapagos);
//				LlenarIdDocumento(ref idDocumentoActual);
//				idDocumentoActual.idClave = 0;
//				//inicializarUtilidadDocumentos();
//				totalizar();
//				prepararBotones();
////                this.malla.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.malla_CellValueChanged);
//			}

//		}
		private void malla_DataError(object sender, DataGridViewDataErrorEventArgs e)
		{
			MessageBox.Show("Error de dato digitado, el valor registrado es inválido");
		}

		private Boolean validarDocumento()
		{
			string docsustento = "";
			string sucDes = "";
			string boddes = "";
			try
			{
				sucDes = CmbSucDestino.SelectedValue.ToString();
				boddes = CmbBodDestino.SelectedValue.ToString();

            }catch{}
			if (sucDes == "" || boddes == "") { MessageBox.Show("Debe registrarse la sucursal y la bodega destino"); return false;}
			if (sucDes == datosEmpresa.sucursal || boddes == datosEmpresa.Bodega) { MessageBox.Show("No puede transferirse a la misma sucursal o bodega"); return false; }
			if (Convert.ToDouble("0" + txtnumero.Text) == 0) { mensajesErrorDocumento.MensajeNumeroDoc(); txtnumero.Focus(); return false; }
			if (ValidacionDocumentos.ValidacionGeneral.validarFecha(txtfecha.Text, datosEmpresa.usr) == false) { return false; };
			if (ValidacionDocumentos.ValidacionGeneral.validarIngresoDetalle(malla) == false) { mensajesErrorDocumento.sinArtículosOservicios(); return false; }
			if (ValidacionDocumentos.ValidacionGeneral.ControlValidacionFacCli(ref malla, ref propiedadesDoc, clasref, txtfecha.Text, datosEmpresa.suc, datosEmpresa.strConxAdcom, datosEmpresa.strConxSyscod, idDocumentoActual.idClave, cmbBodega.SelectedValue.ToString(), txtnumero.Text, entregasPendientes, datosEmpresa.suc, docsustento, "") == false) return false;
			//if (verificarFormaDePago() == false) {return false; }
            DatosFacturacion.moverDatosAclase(this,datADCDOC);
			return true;
		}

		private Boolean grabarDocumento()
		{
            malla.EndEdit();
            Boolean RESP = true;

            string res = "";
            //if (debeActualizarContacto)
            //{
            //    if (MessageBox.Show("Se han cambiado datos del cliente, confirma Actualizar el registro ?", "Actualizar datos de Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            //    {
            //        debeActualizarContacto = false;
            //        ActualizarDatosCliente();
            //    }
            //}
            try
            {
                if (idDocumentoActual.idClave == 0)
                {
                    //DctosEmi.fijarNumeroDocumento fijnum = new DctosEmi.fijarNumeroDocumento();
                    //datADCDOC.Doc_numero = Convert.ToDecimal(fijnum.nroDeDocumento(propiedadesDoc.tablaDatosDoc, propiedadesDoc.CodDuplica, Convert.ToBoolean(propiedadesDoc.NroAutomatico), Convert.ToDouble(txtnumero.Text), datosEmpresa.strConxAdcom, datosEmpresa.suc, cmbDocumento.SelectedValue.ToString(), txtnumero.Text, cmbBodega.SelectedValue.ToString(), codCliente, txtNroID.Text));
                    //if (datADCDOC.Doc_numero == 0) return false;
                    res = datADCDOC.Crear();
                    idDocumentoActual.idClave = Convert.ToDouble(datADCDOC.IdClaveDoc);
                    idDocumentoActual.numero = Convert.ToDouble(datADCDOC.Doc_numero);
                    idDocumentoActual.Sucursal = datADCDOC.Doc_sucursal;
                    idDocumentoActual.Tipo = datADCDOC.Opc_documento;
					txtnumero.Text = datADCDOC.Doc_numero.ToString();
                    if (res.Substring(0, 3) != "ERR") { grabarAdctra(); }
                    string tipDoc = cmbDocumento.SelectedValue.ToString();
                    AuditSis.registrar.registraEventoDoc(datosEmpresa.strConIniSis, datosEmpresa.codEmpresa.ToString(), datosEmpresa.usr, "MDD", Environment.MachineName, AuditSis.registrar.EvntCrear, idDocumentoActual.Sucursal, idDocumentoActual.Tipo, idDocumentoActual.numero.ToString(), datADCDOC.Doc_valor.ToString());
                }
                else
                {
                    res = datADCDOC.Actualizar();
                    if (res.Substring(0, 3) != "ERR") { grabarAdctra(); }
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
		//private bool verificarFormaDePago()
		//{
		//	double valorCredito = 0;
		//	double valorContado = 0;
		//	double valorEfectivo = 0;
		//	bool tieneLiq = false;

		//	if (clasePagos.pagosDelDocumento.Count == 0)
		//	{
		//		crearPagoPredefinido(registrarFormaDePagoPredefinida());
		//	}

		//	MntPago dp = new MntPago();
		//	tieneLiq = false;
		//	double TotalPago = 0;

		//	foreach (DaxComercia.pagoDoc elPago in clasePagos.pagosDelDocumento)
		//	{
		//		TotalPago += elPago.Valor;
		//		if (!tieneLiq) tieneLiq = (elPago.Descripcion.Contains("RETENCI"));
		//		if (elPago.PagoACredito == 2) { valorCredito += elPago.Valor; }
		//		else { valorContado += elPago.Valor; }
		//		if (elPago.TipoPag == "0") {valorEfectivo += elPago.Valor; }
		//	}
		//	if (Math.Round(TotalPago, 2) != Math.Round(Convert.ToDouble(totalesDocumento.TotVta), 2))
		//	{
  //              mensajesErrorDocumento.pagoDifiereTotalDoc();
  //              clasePagos.pagosDelDocumento.Clear();
  //              return false;
		//	}

		//	if (opalex.limitecredito > 0)
		//	{
		//		double saldoCliente = 0;
		//		string cod = "exec ADC_CCINDU '" + opalex.codigo + "','" + "01/01/1901" + "','" + txtfecha.Text + "'," + 0 + ",0,0,'C','',0,'" + datosEmpresa.suc + "','" + propiedadesDoc.Documento + "'," + idDocumentoActual.idClave.ToString();
		//		DataTable dt = utilBasDatos.utilBasDatos.leerTablas(cod, datosEmpresa.strConxAdcom);
		//		if (dt.Rows.Count > 0) saldoCliente = Convert.ToDouble(dt.Rows[0]["Saldo"].ToString());
		//		if (saldoCliente + valorCredito > opalex.limitecredito)
		//		{
		//			mensajesErrorDocumento.ventaExcedeCredito();
		//			return false;
		//		}
		//	}
		//	clasePagos.totalContado = valorContado;
		//	return true;
		//}

		private void grabarAdctra()
		{
			grabMallTra.grabarMallaAdctra(malla, datADCDOC,datosEmpresa.strConxAdcom);
		}

		private void totalizar()
		{
            if (malla.Rows.Count < 1) return;
//			this.malla.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.malla_CellValueChanged);
			//if (claseImpuestos.cambiadoManual == false)
			//{
			//	if (claseImpuestos.impstoPorcentaje1 == 0 || claseImpuestos.impstoFechaIni1 > txtfecha.Value || claseImpuestos.impstoFechaFin1 < txtfecha.Value) claseImpuestos.cargar(datosEmpresa.strConxIvaret , txtfecha.Value);
			//}
			totalesDocumento = new DctosEmi.docTotals();
			edTotal.Text = totalesDocumento.totalizar(malla,propiedadesDoc, valoresPredefinidosEmpresa.nroDigitosEnPrecios , valoresPredefinidosEmpresa.nroDigitosEnCostos ).ToString("#,0.00");
//			presentarTotales();
//			this.malla.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.malla_CellValueChanged);
//			btnPagos.Enabled = (totalesDocumento.TotVta > 0) ;
			//sumarPartePago();
		}
		//private void presentarTotales()
		//{
		//	string formato = "#,0.00";
		//	labTotDescuentoIva.Text = totalesDocumento.totdesciva.ToString(formato);
		//	labTotdescuentoSinIva.Text = totalesDocumento.totdessiva.ToString(formato);
		//	labTotIva.Text = totalesDocumento.TotIva.ToString(formato);
		//	//labTotPorcIva.Text = (claseImpuestos.impstoPorcentaje1 * 100).ToString() + "% IVA";
		//	labTotSubConIva.Text = totalesDocumento.Subtotalciva.ToString(formato);
		//	labTotSubSinIva.Text = totalesDocumento.SubTotalSIva.ToString(formato);
		//	labTotVtaConIva.Text = totalesDocumento.TotCiva.ToString(formato);
		//	labTotVtaSinIva.Text = totalesDocumento.TotSiva.ToString(formato);
		//	labTotalDescuento.Text = totalesDocumento.TotDescuentos.ToString(formato);
		//	labTotalVenta.Text = (totalesDocumento.TotCiva + totalesDocumento.TotSiva).ToString(formato);
		//	labSubtotal.Text = (totalesDocumento.Subtotalciva + totalesDocumento.SubTotalSIva ) .ToString(formato);
		//}

		//private void ActualizarDatosCliente()
		//{
		//	string insertar = "update identificacion set HistoriaClinica = '" + txtcedula.Text + "'";
		//	insertar += ", correoElectrónico = '" + txtCorreElectronico.Text + "'";
		//	insertar += ", Telefono1 = '" + txttelefono.Text + "'";
		//	insertar += ", Domicilio = '" + txtdireccion.Text + "'";
		//	insertar += " where Codigo = '" + txtcedula.Text + "' or CedulaIdentidadRuc = '" + txtcedula.Text + "' ";
		//	using (SqlConnection conn = new SqlConnection (datosEmpresa.strConxAdcom))
		//	{
		//		conn.Open();
		//		using (SqlCommand comm = new SqlCommand (insertar,conn))
		//		{
		//			comm.ExecuteNonQuery();
		//		}
		//	}
		//}
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

		//private void btnPorcentajeIva_Click(object sender, EventArgs e)
		//{
		//	Buscar.frmBuscar progBus = new Buscar.frmBuscar();
		//	string ssql = "select  Porcentaje, isnull(fechaInicio,'01/01/1900') as ValidoDesde";
		//		ssql += ", isnull(FechaFin,'31/12/2078') as ValidoHasta from porcentajeiva";
		//	string nvoIva = progBus.Buscar(datosEmpresa.strConxIvaret , ssql, "porcentaje", "porcentaje", "", "Seleccionar porcentaje IVA", "");
		//	if (MessageBox.Show("Confirma cambiar el porcentaje del IVA en el documento ?", "Cambiar porcentaje del IVA", MessageBoxButtons.YesNo, MessageBoxIcon.Question  ) == DialogResult.No) return;
		//	claseImpuestos.cambiadoManual = true;
		//	claseImpuestos.impstoPorcentaje1 = Convert.ToDouble("0" + nvoIva)*100;
		//	totalizar();
		//}

		//private void ptoVenta_Click(object sender, EventArgs e)
		//{
		//          if (datosEmpresa.usr.ToUpper() == "ADMINISTRADOR")
		//          {
		//              EmpNomR.AdcNomb Retnom = new EmpNomR.AdcNomb();
		//              string ssql = " select Pto_codigo as Id, Pto_nombre as NombrePuntoVta from emp_ptovta where emp_codigo = '" + datosEmpresa.codEmpresa + "' and suc_codigo = '" + datosEmpresa.suc + "'";
		//              Buscar.frmBuscar busca = new Buscar.frmBuscar();
		//              string pv = busca.Buscar(datosEmpresa.strConxSyscod, ssql, "Id", "NombrePuntoVta", "", "PUNTOS DE VENTA");
		//              valoresPredefinidosSucursal.idPuntoVta = pv;
		//          }
		//}

		//private void txtCorreElectronico_TextChanged(object sender, EventArgs e)
		//{
		//	debeActualizarContacto = true;
		//}

		//private void txtdireccion_TextChanged(object sender, EventArgs e)
		//{
		//	debeActualizarContacto = true;
		//}

		//private void txttelefono_TextChanged(object sender, EventArgs e)
		//{
		//	debeActualizarContacto = true;
		//}

		private void registraOpciones()
		{
			//try{
			//	AuditSis.registrar.registraPreferencia(datosEmpresa.strConxSyscod, datosEmpresa.codEmpresa.ToString(), datosEmpresa.usr, "ADX", datosEmpresa.suc, "Transferencia", "TipoDoc", cmbDocumento.SelectedValue.ToString());
			//	AuditSis.registrar.registraPreferencia(datosEmpresa.strConxSyscod, datosEmpresa.codEmpresa.ToString(), datosEmpresa.usr, "ADX", datosEmpresa.suc, "Transferencia", "Bodega", cmbBodega.SelectedValue.ToString());
			//}
			//catch { }
			//	//if (cmbVendedor.SelectedValue != null ) AuditSis.registrar.registraPreferencia(datosEmpresa.strConxSyscod, datosEmpresa.codEmpresa.ToString(), datosEmpresa.usr, "ADX", datosEmpresa.suc, "Facturacion", "Vendedor", cmbVendedor.SelectedValue.ToString());
		}
		private void recordarOpciones()
		{
		   //memTipoDoc = AuditSis.registrar.obtenerPreferencia (datosEmpresa.strConxSyscod, datosEmpresa.codEmpresa.ToString(), datosEmpresa.usr, "ADX", datosEmpresa.suc, "Transferencia", "TipoDoc");
		   //memBodega = AuditSis.registrar.obtenerPreferencia(datosEmpresa.strConxSyscod, datosEmpresa.codEmpresa.ToString(), datosEmpresa.usr, "ADX", datosEmpresa.suc, "Transferencia", "Bodega");
		   ////memVendedor = AuditSis.registrar.obtenerPreferencia(datosEmpresa.strConxSyscod, datosEmpresa.codEmpresa.ToString(), datosEmpresa.usr, "ADX", datosEmpresa.suc, "Facturacion", "Vendedor");
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
		//private void actualizaDatosPagos()
		//{
		//	clasePagos.DocFecha = idDocumentoActual.fecha;
		//	clasePagos.DocNumero = idDocumentoActual.numero;
		//	clasePagos.DocSucursal = idDocumentoActual.Sucursal;
		//	clasePagos.Doctipo = idDocumentoActual.Tipo;
		//	clasePagos.idClaveDoc = idDocumentoActual.idClave;

		//}

		private void mensajesDocumento_Click(object sender, EventArgs e)
        {

        }

   //     private void btnPendientes_Click_1(object sender, EventArgs e)
   //     {
			//DaxInvent.EntregasPendientesClienteProv prog = new  DaxInvent.EntregasPendientesClienteProv (datosEmpresa.strConxAdcom,"C",codCliente,txtnombrecliente.Text );
			//prog.ShowDialog();
   //     }

        private void btnContabiliza_Click(object sender, EventArgs e)
        {
			if (datADCDOC == null) return;
            DatosFacturacion.moverDatosAclase(this,datADCDOC);
            daxContaDoc.frmVisContab progCtb = new daxContaDoc.frmVisContab(asientosContables, datADCDOC, (DataTable)malla.DataSource, propiedadesDoc,null);
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

        private void CmbSucDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
			cargarBodegaDestino();
        }
		private void cargarBodegaDestino()
        {
			DaxCombobx.CargCmbBox  cmb = new DaxCombobx.CargCmbBox();
			if (CmbSucDestino.SelectedValue == null) return;
			cmb.DaxCombosBods(CmbSucDestino.SelectedValue.ToString(), false, datosEmpresa.strConIniSis, ref CmbBodDestino);
		}

        private void BtnVerificarIngreso_Click(object sender, EventArgs e)
        {
			FormVerificarIng frming = new FormVerificarIng(idDocumentoActual,propiedadesDoc,malla);
			frming.ShowDialog();
			frming.Dispose();
        }

        private void btnAgrupa_Click(object sender, EventArgs e)
        {
			if (malla.Rows.Count < 2) return;
			AgruparMalla docut = new AgruparMalla();
			docut.AcumularLineasMalla(malla, "tra_cantidad", "tra_codigo", "");
		}
    }
}