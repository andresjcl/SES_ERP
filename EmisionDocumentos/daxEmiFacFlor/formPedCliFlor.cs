using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using daxMallaDatos;
using classMenSistem;
using ctrlReferencia;
using adcArticulosPrecios;
using ClassDoc;
using FormasPagoDax;

namespace adcDocumentos
{
	public partial class formPedcliFlor : Form
	{
		AdcDax.DaxSofSys CONEMP = new AdcDax.DaxSofSys();
		DaxUsr.DaxsofUsr CONUSER = new DaxUsr.DaxsofUsr();
		DaxUsr.CtrlUsuario ControlUsuario;
		PrySysp13.OpcDoc propiedadesDoc;
		DaxMantDirectorio.DirectorioAlex opalex = new DaxMantDirectorio.DirectorioAlex();
		AdcDocPro datAdcDocPro;
		pagosDocumento.classPagosDoc clasePagos = new pagosDocumento.classPagosDoc();
		adcDescto.descDocumento claseDescuentos = new adcDescto.descDocumento();
		TablasSRI.docImpuestos claseImpuestos = new TablasSRI.docImpuestos();
//		adcDocumentos.valoresPredefinidosSucursal predefinidosSucursal;
		//impresionVerificacion dcu = new adcDocumentos.impresionVerificacion();
		ctrlReferencia.controlReferencial clasref = new controlReferencial();
		DataTable dtDetalleDocumento = new DataTable();
		DataTable dtDetalleContabilidad = new DataTable();

		docMallaArticulo mallaArticulo = new docMallaArticulo();
		adcDocumentos.docTotals totalesDocumento = new adcDocumentos.docTotals();

		Boolean documentoMultiNumeracion = false;
		string claseDocDefault = "PEC";
		string tipoDocDefault = "PED";


		bool iniciarConNuevoDoc = false;
		Boolean esSoloConsulta = false;
		Boolean consultaDeEstadoDecta = false;
		//Boolean tieneComprobantesElectronicos = false;
		Boolean entregasPendientes = false;

        Boolean esDeLiquidacion = false;
		bool debeActualizarContacto = false;

		idDocumento idDocumentoActual = new idDocumento();
		idDocumento idDocumentoSoporte = new idDocumento();
		idDocumento idDocumentoParaGenerar = new idDocumento();

		string claveSri = "";
		string codCliente = "";
		string codClienteFinal = "";
		Boolean saltar = false;

		Boolean salto = false;
		int operacion = 0; // 0 sin operacion delcarada, 1 nuevo registro, 2 modificando registro

		utilDoc Putil; // = new utilDoc(varbleComun.VarCom.strConxAdcom, varbleComun.VarCom.suc, cmbDocumento.SelectedValue.ToString(), "", "", varbleComun.VarCom.usr);

		public formPedcliFlor(bool nuevo = false, bool esConsulta = false, bool generarFactura = false, bool desdeEstdoCta = false, idDocumento idDocViene = null)
		{
			InitializeComponent();
			//daaxLib.DaxLibBases datlib;
			this.txtfecha.ValueChanged -= new System.EventHandler(this.txtfecha_ValueChanged);
			txtfecha.Value = DateTime.Now;
			splitContainer1.Panel2Collapsed = !(splitContainer1.Panel2Collapsed);
			ControlUsuario = CONUSER.UsuarioAct;
			propiedadesDoc = new PrySysp13.OpcDoc();
			llenarCombos();

            valoresPredefinidosSucursal.cargarValores ();
			
			if (idDocViene == null) idDocViene = new idDocumento();
			if (idDocViene.idClave > 0)
			{
				idDocumentoActual = idDocViene;
			}
			else
			{
				idDocumentoActual.Sucursal = varbleComun.VarCom.suc;
				idDocumentoActual.Tipo = tipoDocDefault;
				idDocumentoActual.familia = claseDocDefault;
			}
			llenarComboDocReferencia();
			iniciarConNuevoDoc = nuevo;
			this.Text = "MANTENIMIENTO PEDIDOS A FLORICOLA DE CLIENTES - SUCURSAL : " + varbleComun.VarCom.sucNom;
			this.txtfecha.ValueChanged += new System.EventHandler(this.txtfecha_ValueChanged);
		}
		private void formFacCli_Load(object sender, EventArgs e)
		{
			if (idDocumentoActual.idClave != 0)
			{
				cargarDatosDocumento(idDocumentoActual.Sucursal, idDocumentoActual.Tipo, idDocumentoActual.idClave);
			}
			else
			{
				if (iniciarConNuevoDoc) iniciarNuevoDocumento();
			}
			prepararBotones();
		}

		private void llenarCombos()
		{
			DaxCombobx.CargCmbBox cmb = new DaxCombobx.CargCmbBox();
			cmb.DaxCombosDoc(claseDocDefault, tipoDocDefault, false, varbleComun.VarCom.strConxAdcom, ref cmbDocumento);
			//cmb.DaxCombosBods(varbleComun.VarCom.suc, false, varbleComun.VarCom.strConxSyscod, ref cmbBodega);
			cmb.DaxCombosVend(varbleComun.VarCom.strConxAdcom, ref cmbVendedor, false);
			cmbDocumento.SelectedValue = tipoDocDefault;
		}
		private void llenarComboDocReferencia()
		{
			if (cmbDocumento.SelectedValue == null) return;
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

			//using (DataTable dtt = utilBasDatos.utilBasDatos.leerTablas(Ssql, varbleComun.VarCom.strConxAdcom))
			//{
			//    cmbDocumentoSustento.DataSource = dtt;
			//    cmbDocumentoSustento.DisplayMember = "opc_nombre";
			//    cmbDocumentoSustento.ValueMember = "opc_documento";
			//}
		}

		private void btnSalir_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void buscaCliente(string buscador)
		{
			DaxMantDirectorio.BuscaClien directorio = new DaxMantDirectorio.BuscaClien();
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
				opalex = new DaxMantDirectorio.DirectorioAlex();
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
				opalex = new DaxMantDirectorio.DirectorioAlex();
			}
			totalizar();
		}
		private void cargarDatosClienteFinal(string codigo = "")
		{
			if (codigo != "")
			{
				string solocodigo = "";
				Boolean x = false;
				RetNombre.AdcNomb syscd = new RetNombre.AdcNomb();
				DaxMantDirectorio.DirectorioAlex opalexFin = new DaxMantDirectorio.DirectorioAlex();
				opalexFin.CargarAlex(ref codigo, ref x, ref solocodigo);
				if (opalexFin.codigo == null) codigo = ""; else codigo = opalexFin.codigo;

				if (codigo.Length > 0)
				{
					codClienteFinal = opalexFin.codigo;
					txtCedulaClienteFinal.Text = opalexFin.CiRuc;
					txtNombreClienteFinal.Text = opalexFin.NombreImpresion;
					docExpor.dataExporta.CiudadConsig = opalexFin.Ciudad;
					docExpor.dataExporta.ClienteConsig = opalexFin.codigo;
					docExpor.dataExporta.consignarNom = opalexFin.NombreImpresion;

					dbCliente dbc = new dbCliente(varbleComun.VarCom.strConxAdcom);
					dbc = dbCliente.Buscar(" CodigoCli = '" + opalexFin.codigo + "'");

					docExpor.dataExporta.EstadoConsig = dbc.PaisEmbarque;
					docExpor.dataExporta.embarque = dbc.PuertoEmbarque;

					docExpor.dataExporta.nomAgencia = syscd.RetornaNombreDirectorio(dbc.Transportadora, varbleComun.VarCom.strConxAdcom);
					docExpor.dataExporta.codAgencia = dbc.Transportadora;

					docExpor.dataExporta.paisAdquisicion = "Ecuador";
					docExpor.dataExporta.OrigProducto = "Ecuador";

					//docExpor.dataExporta.transportarNom = 
					//docExpor.dataExporta.Transporte = 
					// completar esto poniendo un get de guardado

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
		}
		private Boolean cargarDatosDocumento(string SUC, string TIPO, double IDCLAVE)
		{
			Boolean resp = false;
			if (IDCLAVE != 0)
			{
				datAdcDocPro = new AdcDocPro(varbleComun.VarCom.strConxAdcom);
				datAdcDocPro = AdcDocPro.Buscar("doc_sucursal = '" + SUC + "' and opc_documento ='" + TIPO + "' and idclavedoc = " + IDCLAVE.ToString());
				if (datAdcDocPro != null)
				{
					malla.CellValueChanged -= new DataGridViewCellEventHandler(malla_CellValueChanged);
					cargarDatosCliente(datAdcDocPro.Doc_codper);

					moverClaseAcontroles();

					if (Convert.ToInt32(datAdcDocPro.Doc_Estado) == 0) mensajesDocumento.Text = "DOCUMENTO ANULADO : " + datAdcDocPro.MotivoAnulacion;
					if (Convert.ToInt32(datAdcDocPro.Doc_Oculto) == 1) mensajesDocumento.Text = "PEDIDO MATRIZ-FIJO : " + datAdcDocPro.MotivoAnulacion;
					if (Convert.ToInt32(datAdcDocPro.tipoEmision) == 1) mensajesDocumento.Text = "PEDIDO FIJO : " + datAdcDocPro.MotivoAnulacion;


					cargarDetalleArticulos(idDocumentoActual.Sucursal, idDocumentoActual.Tipo, idDocumentoActual.idClave, "ADCTRAPRO");
					malla.CellValueChanged += new DataGridViewCellEventHandler(malla_CellValueChanged);
					cargarFormaDePago(idDocumentoActual.Sucursal, idDocumentoActual.Tipo, idDocumentoActual.idClave, "ADCPAGPRO");
					//inicializarUtilidadDocumentos();
					totalizar();

					docExpor.dataExporta = classExporta.Buscar(" doc_sucursal = '" + idDocumentoActual.Sucursal + "' and  opc_documento = '" + idDocumentoActual.Tipo + "' and idclavedoc = " + idDocumentoActual.idClave.ToString());
					if (docExpor.dataExporta == null) docExpor.dataExporta = new classExporta(varbleComun.VarCom.strConxAdcom);
					classPedPerid.periodoPedFijo.tipo = 0;
					if (datAdcDocPro.Doc_Oculto == 1)
					{
						classPedPerid.grabaLeeDatos.leer(idDocumentoActual.idClave, idDocumentoActual.Sucursal, idDocumentoActual.Tipo);
					}
					txtPO.Text = docExpor.dataExporta.pedido;

					operacion = 2;
					prepararBotones();
					resp = true;
					txtnumero.Enabled = false;
				}
			}
			else { }
			return resp;
		}

		private void cargarDetalleArticulos(string suc, string tip, double idClave, string tablatra)
		{
			adcDocumentos.armarConsTra dcut = new adcDocumentos.armarConsTra();
			int inicioLineaOculta = 0;

			dtDetalleDocumento = utilBasDatos.utilBasDatos.leerTablas(dcut.armarSqlLecturaTraPedCliFlor(tablatra, suc, tip, idClave, ref inicioLineaOculta), varbleComun.VarCom.strConxAdcom);
			dcut = null;
			if (dtDetalleDocumento != null)
			{
				malla.DataSource = dtDetalleDocumento;
				dtDetalleDocumento.Rows.Add(dtDetalleDocumento.NewRow());
				diseñarMalla dcut2 = new diseñarMalla();
				malla.CellValueChanged -= new DataGridViewCellEventHandler(malla_CellValueChanged);
				dcut2.diseñarMallaPedCliFlor(ref malla, ref propiedadesDoc);
				malla.CellValueChanged += new DataGridViewCellEventHandler(malla_CellValueChanged);
			}
		}
		private void cargarDetalleArticulosConsolidacion(string listaDocumentos)
		{
			adcDocumentos.armarConsTra dcut = new adcDocumentos.armarConsTra();
			adcDocumentos.diseñarMalla dcut2 = new adcDocumentos.diseñarMalla();

			dtDetalleDocumento = utilBasDatos.utilBasDatos.leerTablas(dcut.armarSqlLecturaTraFacConsolida("ADCTRA", listaDocumentos), varbleComun.VarCom.strConxAdcom);
			dcut = null;
			if (dtDetalleDocumento == null) return;
			malla.DataSource = dtDetalleDocumento;
			if (malla.Rows.Count > 0) dcut2.diseñarMallaPedCliFlor(ref malla, ref propiedadesDoc);

			dcut = null;
			dcut2 = null;
		}
		private void cargarFormaDePago(string suc, string tip, double idClave, string tabla)
		{
			clasePagos = new pagosDocumento.classPagosDoc
			{
				strConx = varbleComun.VarCom.strConxAdcom,
				DocSucursal = suc,
				Doctipo = tip,
				idClaveDoc = idClave,
				DocNumero = Convert.ToDouble("0" + txtnumero.Text)
			};
			clasePagos.cargarPagosDocumento (tabla);
		}
		private void moverClaseAcontroles()
		{
			moverCabezera();
			moverOtrosValores();
		}
		private void moverCabezera()
		{

			idDocumentoActual.idClave = Convert.ToDouble(datAdcDocPro.IdClaveDoc);
			codCliente = datAdcDocPro.Doc_codper;

			txtnumero.Text = datAdcDocPro.Doc_numero.ToString();
			if (datAdcDocPro.Doc_NroIdDoc.ToString() != "") txtNroID.Text = datAdcDocPro.Doc_NroIdDoc.ToString();
			txtfecha.Text = datAdcDocPro.Doc_fecha.ToShortDateString();
			txtcedula.Text = datAdcDocPro.Doc_CiRuc;
			txtnombrecliente.Text = datAdcDocPro.Doc_NombreImp;
			txtdireccion.Text = datAdcDocPro.Doc_Direccion;

			txtDetalle.Text = datAdcDocPro.Doc_detalle;
			cmbVendedor.SelectedValue = datAdcDocPro.Doc_venabre;

			txtCedulaClienteFinal.Text = datAdcDocPro.RucDestinatario;
			txtNombreClienteFinal.Text = datAdcDocPro.nomClienteFinal;
			codClienteFinal = datAdcDocPro.codClienteFinal;

		}
		private void moverOtrosValores()
		{
			claseDescuentos = new adcDescto.descDocumento();
			claseImpuestos = new TablasSRI.docImpuestos();
			claseDescuentos.nombreDes[0] = datAdcDocPro.Doc_nombredes1;
			claseDescuentos.nombreDes[1] = datAdcDocPro.Doc_nombredes2;
			claseDescuentos.nombreDes[2] = datAdcDocPro.Doc_nombredes3;

			claseDescuentos.porcentajeDes[0] = Convert.ToDouble(datAdcDocPro.Doc_porcendes1);
			claseDescuentos.porcentajeDes[1] = Convert.ToDouble(datAdcDocPro.Doc_porcendes2);
			claseDescuentos.porcentajeDes[2] = Convert.ToDouble(datAdcDocPro.Doc_porcendes3);

			claseDescuentos.valorDes[0] = Convert.ToDouble(datAdcDocPro.Doc_valordes1);
			claseDescuentos.valorDes[1] = Convert.ToDouble(datAdcDocPro.Doc_valordes2);
			claseDescuentos.valorDes[2] = Convert.ToDouble(datAdcDocPro.Doc_valordes3);

			claseImpuestos.impstoPorcentaje1 = Convert.ToDouble(datAdcDocPro.Doc_porceniva);
			claseImpuestos.impstoNombre1 = "IVA";

			//          txtCedulaClienteFinal.Text  = docExpor.dataExporta.ClienteConsig;
			//          txtNombreClienteFinal.Text  = docExpor.dataExporta.consignarNom;        
		}
		private void MoverControlesAClase()
		{
			datAdcDocPro.Doc_sucursal = varbleComun.VarCom.suc;
			datAdcDocPro.Doc_Bodega = ""; //cmbBodega.SelectedValue.ToString();
			datAdcDocPro.Opc_documento = cmbDocumento.SelectedValue.ToString();
			datAdcDocPro.Doc_numero = Convert.ToDecimal(txtnumero.Text);
			datAdcDocPro.Doc_fecha = Convert.ToDateTime(txtfecha.Text);
			datAdcDocPro.Doc_codper = codCliente;
			datAdcDocPro.Doc_CiRuc = txtcedula.Text;
			datAdcDocPro.Doc_NombreImp = txtnombrecliente.Text;
			datAdcDocPro.Doc_Direccion = txtdireccion.Text;
			datAdcDocPro.Doc_Telefono1 = txttelefono.Text;
			datAdcDocPro.Doc_detalle = txtDetalle.Text;
			datAdcDocPro.nomClienteFinal = txtNombreClienteFinal.Text;
			datAdcDocPro.codClienteFinal = codClienteFinal;
			datAdcDocPro.RucDestinatario = txtCedulaClienteFinal.Text;
			try
			{
				datAdcDocPro.Doc_venabre = cmbVendedor.SelectedValue.ToString();
			}
			catch { }
			datAdcDocPro.Doc_DocSop = "";
			datAdcDocPro.Doc_NumSop = 0;
			datAdcDocPro.Doc_valor = Convert.ToDecimal(edTotal.Text);
			datAdcDocPro.AuxVar9 = txtCorreElectronico.Text;

			datAdcDocPro.Doc_nombredes1 = claseDescuentos.nombreDes[0];
			datAdcDocPro.Doc_nombredes2 = claseDescuentos.nombreDes[1];
			datAdcDocPro.Doc_nombredes3 = claseDescuentos.nombreDes[2];

			datAdcDocPro.Doc_porcendes1 = Convert.ToDecimal(claseDescuentos.porcentajeDes[0]);
			datAdcDocPro.Doc_porcendes2 = Convert.ToDecimal(claseDescuentos.porcentajeDes[1]);
			datAdcDocPro.Doc_porcendes3 = Convert.ToDecimal(claseDescuentos.porcentajeDes[2]);

			datAdcDocPro.Doc_valordes1 = Convert.ToDecimal(claseDescuentos.valorDes[0]); ;
			datAdcDocPro.Doc_valordes2 = Convert.ToDecimal(claseDescuentos.valorDes[1]);
			datAdcDocPro.Doc_valordes3 = Convert.ToDecimal(claseDescuentos.valorDes[2]);

			datAdcDocPro.Doc_porceniva = Convert.ToDecimal(claseImpuestos.impstoPorcentaje1);

			//datADCDOC.Doc_NroLoteDoc = TexLote.Text
			datAdcDocPro.Doc_NroIdDoc = txtNroID.Text;
			datAdcDocPro.Adi_TipoDocSri = propiedadesDoc.TipoSri;
			//datADCDOC.Adi_FechContab = IIf(FechaContab < TxtFecha, TxtFecha, FechaContab)
			//datADCDOC.Adi_CodigoNSR = TexCodigoExoneraRetencion.Text
			//datADCDOC.Adi_SustTrib = DatSustento.BoundText
			//datADCDOC'.Adi_SNDevIva = IIf(DerechoIva.Value = 1, "S", "N")
			datAdcDocPro.IdClaveDoc = Convert.ToDecimal(idDocumentoActual.idClave);
			datAdcDocPro.IdClaveDocSop = 0;
			datAdcDocPro.Doc_docnombre = "";
			datAdcDocPro.Doc_TipoDoc = propiedadesDoc.TipoDoc;
			datAdcDocPro.Doc_FechaEfe = Convert.ToDateTime(txtfecha.Text);     //FechaVence.Value
			datAdcDocPro.Doc_Hora = Convert.ToDateTime(txtfecha.Text);
			datAdcDocPro.Doc_extension = "";
			datAdcDocPro.Doc_codusu = ControlUsuario.Identifica;
			datAdcDocPro.Doc_valoriva = totalesDocumento.TotIva;
			datAdcDocPro.Doc_totciva = totalesDocumento.TotCiva;
			datAdcDocPro.Doc_totsiva = totalesDocumento.TotSiva;
			datAdcDocPro.Doc_valorabon = totalesDocumento.ValorCon;
			datAdcDocPro.Doc_DepDes = "";
			datAdcDocPro.Doc_TotDesArt = totalesDocumento.TotDesArt;
			datAdcDocPro.Doc_TotDesSer = totalesDocumento.TotDesSer;
			datAdcDocPro.Doc_TotArtCIva = totalesDocumento.TotArtCIva;
			datAdcDocPro.Doc_TotArtSIva = totalesDocumento.TotArtSIva;
			datAdcDocPro.Doc_TotSerCIva = totalesDocumento.TotSerCIva;
			datAdcDocPro.Doc_TotSerSIva = totalesDocumento.TotSerSIva;
			datAdcDocPro.Doc_TotAcf = totalesDocumento.TotAcf;
			datAdcDocPro.Doc_Contado = totalesDocumento.ValorEfec;
			datAdcDocPro.Doc_Estado = 1;
			datAdcDocPro.Doc_Oculto = Convert.ToInt16(propiedadesDoc.ClaveOculto);
			datAdcDocPro.Doc_Contabilidad = Convert.ToInt16(propiedadesDoc.ClaveContable);
			datAdcDocPro.Doc_Banco = Convert.ToInt16(propiedadesDoc.ClaveBanco);
			datAdcDocPro.Doc_Inventario = Convert.ToInt16(propiedadesDoc.ClaveInventario);
			datAdcDocPro.Doc_Ventas = Convert.ToInt16(propiedadesDoc.ClaveVentas);
			datAdcDocPro.Doc_Compras = Convert.ToInt16(propiedadesDoc.ClaveCompras);
			datAdcDocPro.Doc_Activo = Convert.ToInt16(propiedadesDoc.ClaveActivo);
			datAdcDocPro.Doc_Adicional2 = 0;
			datAdcDocPro.Doc_NumeroExterno = 0;
			datAdcDocPro.IdClaveDocSop = 0;
			datAdcDocPro.Doc_FechaModifica = DateTime.Now;
			datAdcDocPro.doc_TotDesSiva = totalesDocumento.totdessiva;
			datAdcDocPro.doc_TotDesCIva = totalesDocumento.totdesciva;
			datAdcDocPro.Adi_NroAutSri = "";                   //TextNroAutSri
			datAdcDocPro.ProductoProduccion = "";             //ProductoProduccion.Text
			//datADCDOC.FacDesde = FDesde.Value;
			//datADCDOC.FacHasta = FHasta.Value;
			//datADCDOC.TipoPeriodo = "";            

		}

		private void prepararBotones()
		{
			Boolean inicio = (operacion == 0);
			Boolean nuevo = (operacion == 1);
			Boolean modificando = (operacion == 2);
			Boolean docAnulado = false;
			try
			{
				docAnulado = (datAdcDocPro.Doc_Estado == 0 && modificando);
			} catch { }

			btnAbre.Enabled = inicio;
			btnNuevo.Enabled = inicio;

			btnCopia.Enabled = nuevo;

			btnAnula.Enabled = (modificando && !docAnulado);
			btnElimina.Enabled = modificando;
			btnGraba.Enabled = (!inicio && !docAnulado);
			btnRegistra.Enabled = (!inicio && !docAnulado);
			btnImprime.Enabled = (modificando && !docAnulado);
			btnCierra.Enabled = !inicio;

			btnEstadoCta.Enabled = (!inicio && codCliente.Length > 0);
			btnPagos.Enabled = !inicio && !docAnulado;
			btnDescuentos.Enabled = !inicio && !docAnulado;
			btnExportacion.Enabled = !inicio;
			btnPorcentajeIva.Enabled = btnDescuentos.Enabled;

			btnBarras.Enabled = (!inicio) && !docAnulado;
			btnAgrupa.Enabled = (btnBarras.Enabled && btnBarras.Checked);

			panel1.Enabled = (!inicio);
			malla.Enabled = (!inicio);

			cmbDocumento.Enabled = (!modificando);
			txtcedula.Enabled = (!docAnulado);

			btnPeriodico.Enabled = (!inicio && !docAnulado);


			if (inicio) return;

			btnEstadoCta.Enabled = !consultaDeEstadoDecta;

			if (esSoloConsulta == true)  //|| propiedadesDoc.ClaveEstado == 0)
			{
				btnGraba.Enabled = false;
				btnRegistra.Enabled = false;
				btnElimina.Enabled = false;
				btnAnula.Enabled = false;
				//                if (propiedadesDoc.ClaveEstado == 0) btnElimina.Enabled = (ControlUsuario.Identifica.ToUpper() == "ADMINISTRADOR");
			}
		}

		private void btnCierra_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Confirma cerrar el documento actual ?", "Cerrar documento sin grabar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No) return;
			limpiarDatos();
		}
		private void limpiarDatos()
		{
			txtnumero.Enabled = true;
			datAdcDocPro = new AdcDocPro(varbleComun.VarCom.strConxAdcom);
			clasePagos = new pagosDocumento.classPagosDoc();
			claseDescuentos = new adcDescto.descDocumento();
			totalesDocumento = new adcDocumentos.docTotals();
			clasref = new controlReferencial();
			txtcedula.Text = "";
			txtCorreElectronico.Text = "";
			txtDetalle.Text = "";
			txtdireccion.Text = "";
			txtnombrecliente.Text = "";
			txtnumero.Text = "";
			txttelefono.Text = "";
			mensajesDocumento.Text = "";
			operacion = 0;
			prepararBotones();
			malla.DataSource = null;
			presentarTotales();
			edTotal.Text = totalesDocumento.TotVta.ToString("#,0.00");
			esDeLiquidacion = false;
			debeActualizarContacto = false;
			idDocumentoActual.idClave = 0;
			idDocumentoActual.fecha = txtfecha.Value;
			idDocumentoSoporte = new idDocumento();
			txtNroID.Text = valoresPredefinidosSucursal.idtributario;
			docExpor.dataExporta = new classExporta(varbleComun.VarCom.strConxAdcom);
			dtDetalleContabilidad = new DataTable();
			dtDetalleDocumento = new DataTable();
			classPedPerid.periodoPedFijo.tipo = 0;
			classPedPerid.periodoPedFijo.mesDia1 = 0;
			txtPO.Text = "";
			EliminarComposicionSinPedido();
		}
		private void InicializarMalla()
		{

			cargarDetalleArticulos(varbleComun.VarCom.suc, cmbDocumento.SelectedValue.ToString(), 0, "AdcTraPro");

		}
		private void malla_CellValueChanged(object sender, DataGridViewCellEventArgs e)

		{
			if (salto == false)
			{
				try
				{
					string nombCol = malla.Columns[malla.CurrentCell.ColumnIndex].Name.ToUpper();
					if (nombCol == "NROCAJA") disMallFlor.diseñoMallaFlor.colorCaja(malla, "NroCaja");
					//                    if (nombCol == "CANTCAJAS" || nombCol == "RAMXCAJA") calcularCantidad();
				}
				catch { }
			}
		}

		private void calcularCantidad()
		{
			malla.CellValueChanged -= new DataGridViewCellEventHandler(malla_CellValueChanged);
			DataGridViewRow row = malla.Rows[malla.CurrentCell.RowIndex];
			try
			{
				row.Cells["tra_cantidad"].Value = Convert.ToDouble(row.Cells["CantCajas"].Value) * Convert.ToDouble(row.Cells["RamXcaja"].Value);
			}
			catch { }
			malla.CellValueChanged += new DataGridViewCellEventHandler(malla_CellValueChanged);

		}
		//    ssqlTra += ", CantCajas";
		//    ssqlTra += ", TipCaja";
		//    ssqlTra += ", Tra_Codigo";
		//    ssqlTra += ", Tra_nombre";
		//    ssqlTra += ", RamXcaja";
		//    ssqlTra += ", Tra_cantidad";

		#region EVENTOS DE CONTROLES
		#region EVENTOS DE BOTONES

		private void btnBuscaCliente_Click(object sender, EventArgs e)
		{
			buscaCliente(txtnombrecliente.Text);
		}
		private void txtfecha_ValueChanged(object sender, EventArgs e)
		{
			idDocumentoActual.fecha = txtfecha.Value;
			chequearCambioValoresPoFecha();
		}

		private void txtCorreElectronico_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.F5)
			{
				string resp = inputDialogo.inputDialogo.ingresar("Cambiar correo electrónico del contacto", "Nuevo correo electrónico", txtCorreElectronico.Text);
				if (resp != txtCorreElectronico.Text && resp != "") { debeActualizarContacto = true; txtCorreElectronico.Text = resp; }
			}
		}
		private void btnNuevo_Click(object sender, EventArgs e)
		{
			iniciarNuevoDocumento();
		}
		private void iniciarNuevoDocumento()
		{
			limpiarDatos();
			//inicializarUtilidadDocumentos();
			InicializarMalla();
			Putil = new utilDoc(varbleComun.VarCom.strConxAdcom, varbleComun.VarCom.suc, cmbDocumento.SelectedValue.ToString(), "", "", varbleComun.VarCom.usr);
			double num = Putil.nuevoNumeroDocumento("AdcDocPro", "", "");
			txtnumero.Text = num.ToString();
			operacion = 1;
			prepararBotones();
		}
		private void btnPendientes_Click(object sender, EventArgs e)
		{
			porEntregar.frmPorEntregar PorEntregar = new porEntregar.frmPorEntregar
			{
				fecha = DateTime.Now,
				Cliente = codCliente,
				NomCliente = txtnombrecliente.Text,
				strConxAdcom = varbleComun.VarCom.strConxAdcom
			};
			PorEntregar.ShowDialog();
		}
		private void btnDescuentos_Click(object sender, EventArgs e)
		{
			adcDescto.ingDescDoc ingdesc = new adcDescto.ingDescDoc();
			int nrodesc = CONEMP.EmpresaAct.ActNumNiv;
			ingdesc.ingresarDescuentos(ref claseDescuentos, varbleComun.VarCom.strConxAdcom, varbleComun.VarCom.suc, nrodesc);
			totalizar();
		}

		private void btnRegistra_Click(object sender, EventArgs e)
		{
			if (validarDocumento() == true)
			{
				if (grabarDocumento() == true)
				{
					imprimirDocumento();
					limpiarDatos();
				}
			}
		}
		private void btnAnula_Click(object sender, EventArgs e)
		{
			anulaElimina classAnular = new adcDocumentos.anulaElimina();
			if (classAnular.anularDocumento(varbleComun.VarCom.strConxAdcom, varbleComun.VarCom.strConxSyscod, idDocumentoActual, ControlUsuario.Identifica, esDeLiquidacion, varbleComun.VarCom.nomEmpresa, varbleComun.VarCom.codEmpresa.ToString(), edTotal.Text, "ADCDOCPRO", propiedadesDoc.ComandoExterno)) limpiarDatos();
			classAnular = null;
		}
		private void btnElimina_Click(object sender, EventArgs e)
		{
			anulaElimina classAnular = new anulaElimina();
			if (classAnular.eliminarDocumento(varbleComun.VarCom.strConxAdcom, varbleComun.VarCom.strConxSyscod, idDocumentoActual, ControlUsuario.Identifica, esDeLiquidacion, varbleComun.VarCom.nomEmpresa, varbleComun.VarCom.codEmpresa.ToString(), edTotal.Text, "ADCDOCPRO", propiedadesDoc.ComandoExterno)) limpiarDatos();            
			classAnular = null;
		}


		#endregion EVENTOS DE BOTONES
		#region EVENTOS DE CAJAS DE TEXTO
		//private void txtRecibido_TextChanged(object sender, EventArgs e)
		//{
		//    try
		//    {
		//        txtCambio.Text = (Convert.ToDouble(txtRecibido.Text) - Convert.ToDouble(edTotal.Text)).ToString();
		//    }
		//    catch { txtCambio.Text = ""; }
		//}

		private void btnGraba_Click(object sender, EventArgs e)
		{

			if (validarDocumento() == true)
			{
				if (grabarDocumento() == true) {
					limpiarDatos();
					if (iniciarConNuevoDoc) this.Close();
				}
			}

		}
		private void btnPagos_Click(object sender, EventArgs e)
		{
			ingresarFormaDePago();
		}

		private void txtcedula_Leave(object sender, EventArgs e)
		{
			KeyEventArgs ee = new KeyEventArgs(Keys.Return);
			txtcedula_KeyDown(sender, ee);
		}

		private void txtcedula_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return && txtcedula.Text.Length > 0)
			{
				string codigo = txtcedula.Text;
				string tipo = "C";
				cargarDatosCliente(codigo);
				if (txtcedula.Text == "")
				{
					if (MessageBox.Show("El cliente no existe desea registarlo ? ", "Creacion de cliente nuevo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
					{
						DaxMantDirectorio.CreaCliAlex express = new DaxMantDirectorio.CreaCliAlex();
						express.IniCrearAlex(ref tipo, ref codigo);
					}
				}
				if ((codigo + "").Length > 0) cargarDatosCliente(codigo);
			}
		}

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
			string SUC = varbleComun.VarCom.suc;
			string TIP = "";
			double Idclave = 0;
			double Numero = 0;
			BuscadorDocumentos.buscadorDoc progBus = new BuscadorDocumentos.buscadorDoc(varbleComun.VarCom.strConxAdcom, varbleComun.VarCom.strConxSyscod);
			DateTime queFecha = DateTime.Now;
			progBus.IniciaBusqueda("FACPRCPEC", "", "", queFecha, ref SUC, ref TIP, ref Numero, ref Idclave, false, "", "", "", "ADCDOCPRO");
			if (Idclave != 0)
			{
				idDocumentoParaGenerar.Sucursal = SUC;
				idDocumentoParaGenerar.Tipo = TIP;
				idDocumentoParaGenerar.idClave = Idclave;
				copiarDocumento(idDocumentoParaGenerar, false);
				limpiarValoresEnlaces();
			}
			progBus = null;
		}


		private void cmbDocumento_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (idDocumentoActual.Sucursal == "") return;

			llenarComboDocReferencia();
		}
		private void BtnAbre_Click(object sender, EventArgs e)
		{
			if (cmbDocumento.SelectedValue == null) return;
			BuscadorDocumentos.buscadorDoc progBus = new BuscadorDocumentos.buscadorDoc(varbleComun.VarCom.strConxAdcom, varbleComun.VarCom.strConxSyscod);
			idDocumentoActual.Sucursal = varbleComun.VarCom.suc;
			DateTime queFecha = DateTime.Now;
			progBus.IniciaBusqueda(claseDocDefault, "", cmbDocumento.SelectedValue.ToString(), queFecha, ref idDocumentoActual.Sucursal, ref idDocumentoActual.Tipo, ref idDocumentoActual.numero, ref idDocumentoActual.idClave, false, cmbDocumento.SelectedValue.ToString(), "", "", "ADCDOCPRO");
			if (idDocumentoActual.idClave == 0)
			{
				idDocumentoActual.Sucursal = varbleComun.VarCom.suc; return;
			}
			if (idDocumentoActual.Sucursal.ToUpper() != varbleComun.VarCom.suc.ToUpper()) { mensajesErrorDocumento.documentosNoDeOtraSucursal(varbleComun.VarCom.sucNom); return; }
			if (idDocumentoActual.idClave != 0) cargarDatosDocumento(idDocumentoActual.Sucursal, idDocumentoActual.Tipo, idDocumentoActual.idClave);
		}

		private void txtnumero_Leave(object sender, EventArgs e)
		{
			if (saltar == true) { saltar = false; return; }
			if (operacion != 2)
			{
				verificaNroDocumentoDigitado();
				//llenarIdDocumento(ref docmtoActual);
				//docmtoActual.idClave = impresionVerificacion.verificarExistenciaDocumento(varbleComun.VarCom.suc, cmbDocumento.SelectedValue.ToString(), txtnumero.Text, varbleComun.VarCom.strConxAdcom, documentoMultiNumeracion);
				//if (docmtoActual.idClave > 0) cargarDatosFactura(varbleComun.VarCom.suc, cmbDocumento.SelectedValue.ToString(), docmtoActual.idClave);
			}
		}
		private void txtnumero_KeyDown(object sender, KeyEventArgs e)
		{
			saltar = true;
			if (e.KeyCode == Keys.Return && txtnumero.Text.Length > 0)
			{
				verificaNroDocumentoDigitado();
			}
		}
		private void verificaNroDocumentoDigitado()
		{
			llenarIdDocumento(ref idDocumentoActual);
			impresionVerificacion.verificarExistenciaDocumento(ref idDocumentoActual, varbleComun.VarCom.strConxAdcom, documentoMultiNumeracion, "ADCDOCPRO");
			if (idDocumentoActual.idClave > 0) cargarDatosDocumento(idDocumentoActual.Sucursal, idDocumentoActual.Tipo, idDocumentoActual.idClave);
		}


		#endregion EVENTOS DE CAJAS DE TEXTO

		#endregion EVENTOS DE CONTROLES
		#region manejo malla
		private void malla_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
		{
			//salto = true;
			malla.CellValueChanged -= new DataGridViewCellEventHandler(malla_CellValueChanged);
			foreach (DataGridViewRow rr in malla.Rows)
			{
				rr.HeaderCell.Value = (rr.Index + 1).ToString();
			}
			malla.CellValueChanged += new DataGridViewCellEventHandler(malla_CellValueChanged);

			//salto = false;
		}
		protected override Boolean ProcessCmdKey(ref Message msg, Keys keyData)
		{
			if (malla.Focused == false && malla.IsCurrentCellInEditMode == false) return false;
			if (malla.Focused == false  && malla.IsCurrentCellInEditMode && (keyData == Keys.Right || keyData == Keys.Left)) return false;

			if (malla.IsCurrentCellInEditMode && (keyData == Keys.Up || keyData == Keys.Down))
			{ keyData = Keys.Return; }

			if (keyData == Keys.Return || (keyData >= Keys.F1 && keyData < Keys.F13))
			{
				DataGridViewCell cell = malla.CurrentCell;
				if (!(malla.IsCurrentCellInEditMode == false && keyData == Keys.Return)) funcionesEspeciales(ref keyData, malla);
				if (keyData != Keys.Return) return true;
				moverCeldaMalla(cell);
				return true;
			}
			return false;
		}

		private void moverCeldaMalla(DataGridViewCell cell)
		{
			Int32 columnIndex = cell.ColumnIndex;
			Int32 rowIndex = cell.RowIndex;
			Int32 col = columnIndex;
			Int32 row = rowIndex;
			Int32 colOk = 0;


			if (col < malla.Columns.Count)
			{
				for (int i = col + 1; i < malla.Columns.Count - 1; i++)
				{
					if (malla.Columns[i].Visible == true && malla.Columns[i].ReadOnly == false && malla.Columns[i].Name.ToUpper() != "TRA_NOMBRE") { colOk = i; break; }
				}
			}

			if (colOk == 0)
			{
				col = 1;
				if (row == malla.Rows.Count - 1)
				{
					dtDetalleDocumento.Rows.InsertAt(dtDetalleDocumento.NewRow(), malla.Rows.Count);
					row = malla.Rows.Count - 1;
				}
				else
				{
					row++;
				}
			}
			else
			{
				col = colOk;
			}
			malla.CurrentCell = malla.Rows[row].Cells[col];
		}

		#endregion manejo malla
		private Boolean funcionesEspeciales(ref Keys keyData, DataGridView malla)
		{
			Boolean resp = true;
			malla.EndEdit();
			DataGridViewCell cell = malla.CurrentCell;
			string dato = cell.Value.ToString();
			string nombreCelda = cell.OwningColumn.Name.ToUpper();

			if (nombreCelda == "TRA_PRECUNI" && keyData >= Keys.F2 && keyData <= Keys.F6)
			{
				DataGridViewRow row = malla.CurrentRow;
				daxMallaDatos.docMallaArticulo preVta = new docMallaArticulo();

				double elPrecio = cargarPrecios.CargarPrecio(varbleComun.VarCom.strConxAdcom, varbleComun.VarCom.strConxSyscod, Convert.ToInt32(keyData), malla.CurrentRow.Cells["tra_codigo"].Value.ToString(), claseImpuestos.impstoPorcentaje1, "", 0, row.Cells["tra_Medida"].Value.ToString(), codCliente, Convert.ToInt32(CONEMP.EmpresaAct.DigitosPrecios));
				cell.Value = elPrecio;
				totalizar();
			}
			else if (nombreCelda == "NROCAJA")
			{
				if (keyData == Keys.F2) cell.Value = leerDatosDeLinea.nuevoNumeroDeCaja(malla);
				else if (keyData == Keys.Return || keyData == Keys.F3) cell.Value = leerDatosDeLinea.repiteNumeroDeCaja(malla);
			}
			else if (nombreCelda == "TIPCAJA")
			{
				if (keyData == Keys.F2)
				{
					string tipo = busquedasDatosDeLinea.buscarTipoCaja();
					if (tipo != "") leerDatosDeLinea.tipoCaja(tipo, ref malla);
				}
				else if(keyData == Keys.Return && dato.Length>0)
				{
					leerDatosDeLinea.tipoCaja(dato, ref malla);
				}

			}
			else if (nombreCelda == "TRA_CODIGO")
			{
				try
				{
					mallaArticulo.bodega = ""; //cmbBodega.SelectedValue.ToString();
				}
				catch { }
				mallaArticulo.digCostos = CONEMP.EmpresaAct.DigitosCostos;
				mallaArticulo.digPrecios = CONEMP.EmpresaAct.DigitosPrecios;
				mallaArticulo.fechaDoc = Convert.ToDateTime(txtfecha.Text);
				mallaArticulo.impIva = claseImpuestos.impstoPorcentaje1;
				mallaArticulo.codCliente = codCliente;
				mallaArticulo.sucursal = varbleComun.VarCom.suc;
				mallaArticulo.tipoDoc = cmbDocumento.SelectedValue.ToString();
				mallaArticulo.numDoc = txtnumero.Text;

				if (keyData == Keys.F2)
				{
					dato = mallaArticulo.BuscarArticuloSimple(malla.CurrentCell.Value.ToString());
					if (mallaArticulo.CargarArticuloFlores ( malla, ref propiedadesDoc, dato, opalex.TipoCliente, txtfecha.Text, propiedadesDoc.Documento, idDocumentoActual.idClave,Convert.ToDecimal(txtnumero.Text)) == false) cell.Value = ""; keyData = Keys.Cancel;
				}
				else if (keyData == Keys.F11)
				{
					dato = mallaArticulo.BuscarArticulo(malla.CurrentCell.Value.ToString());
					if (mallaArticulo.CargarArticuloFlores( malla, ref propiedadesDoc, dato, opalex.TipoCliente, txtfecha.Text, propiedadesDoc.Documento, idDocumentoActual.idClave, Convert.ToDecimal(txtnumero.Text)) == false) cell.Value = ""; keyData = Keys.Cancel;
				}
				else if (keyData == Keys.Return)
				{
					if (mallaArticulo.CargarArticuloFlores( malla, ref propiedadesDoc, dato, opalex.TipoCliente, txtfecha.Text, propiedadesDoc.Documento, idDocumentoActual.idClave, Convert.ToDecimal(txtnumero.Text)) == false) cell.Value = ""; keyData = Keys.Cancel;
				}
				else if (keyData == Keys.F3)
				{
					DaxConceptos.classConceptos buscserv = new DaxConceptos.classConceptos();
					dato = buscserv.iniciaBuscador(varbleComun.VarCom.strConxAdcom, "", "CC", CONEMP.EmpresaAct.Hotel, true);
					if (dato != "") mallaArticulo.CargarServicios(dato, ref malla, claseImpuestos.impstoPorcentaje1, CONEMP.EmpresaAct.DigitosPrecios, Convert.ToDateTime(txtfecha.Text), ref propiedadesDoc);
				}

			}
			else if (nombreCelda == "DOC_BODEGA")
			{
				if (keyData == Keys.F2)
				{
					cell.Value = busquedasDatosDeLinea.buscarBodega();
				}

				else if (keyData == Keys.Return)
				{
					cell.Value = leerDatosDeLinea.bodega(cell.Value.ToString(), ref malla);
				}
			}
			else if (nombreCelda == "ZONAPRODUCTO")
			{
				if (keyData == Keys.F2)
				{
					cell.Value = busquedasDatosDeLinea.buscarZonaProducto();
				}
				else if (keyData == Keys.Return)
				{
					cell.Value = leerDatosDeLinea.zonaProducto(cell.Value.ToString(), ref malla);
				}
			}
			else if (nombreCelda == "TALLXRAMO")
			{
				if (keyData == Keys.F2)
				{
					DataGridViewRow row = malla.Rows[malla.CurrentCell.RowIndex];
					string codart = row.Cells["Tra_codigo"].Value.ToString();
					string nomart = row.Cells["Tra_nombre"].Value.ToString();
					string variedad = row.Cells["Variedad"].Value.ToString();
					string idCaja = row.Cells["NroCaja"].Value.ToString()+ row.Cells["TipCaja"].Value.ToString();
					DaxCompRamos.frmCompRamo prog = new DaxCompRamos.frmCompRamo(varbleComun.VarCom.strConxAdcom,idDocumentoActual ,codart,nomart,variedad,idCaja);
					prog.ShowDialog();
					DaxCompRamos.CompRamos.cargaDatosComposicionDelProducto(row,codart,idDocumentoActual.Sucursal,idDocumentoActual.Tipo,Convert.ToDecimal(idDocumentoActual.numero),idCaja);
					row = null;
					prog.Dispose();
				}
			}
			
			//        VerificarClasificadoresContablesArticulo dato
			if (cell.Value.ToString() != "") keyData = Keys.Return; else keyData = Keys.Cancel;

			return resp;
		}

		//ssqlTra += " Tra_numlinea";
		//    ssqlTra += ", NroCaja";
		//    ssqlTra += ", CantCajas";
		//    ssqlTra += ", TipCaja";
		//    ssqlTra += ", Tra_Codigo";
		//    ssqlTra += ", Tra_nombre";
		//    ssqlTra += ", RamXcaja";
		//    ssqlTra += ", Tra_cantidad";
		//    ssqlTra += ", Tra_precuni";
		//    ssqlTra += ", Tra_prectot";

		//    ssqlTra += ", TallXramo";
		//    ssqlTra += ", Largo";
		//    ssqlTra += ", tra_peso";
		//    ssqlTra += ", Tallos";
		//    ssqlTra += ", totPeso";6

		private void ingresarFormaDePago()
		{
			string pagoPredefinido = "45";
			FormasPagoDax.MntPago PagosDoc = new FormasPagoDax.MntPago();
			if (clasePagos.pagosDelDocumento.Count < 1)
			{
				if (opalex.FormaPago != null && opalex.FormaPago.Length > 0) { pagoPredefinido = opalex.FormaPago; }
				else { if (CONEMP.EmpresaAct.DocPrincipalVtas.Length > 0) pagoPredefinido = CONEMP.EmpresaAct.DocPrincipalVtas; }
			}
			PagosDoc.INIPagos(idDocumentoActual.idClave, ref clasePagos, opalex.codigo, idDocumentoActual.Sucursal, propiedadesDoc.TipoDoc, txtfecha.Text, false, idDocumentoActual.Tipo, Convert.ToDouble("0" + txtnumero.Text), pagoPredefinido, Convert.ToDouble(edTotal.Text), false);
			PagosDoc = null;
		}


		private void imprimirDocumento()
		{
            EnviarDocumentoDax.ImprimeDocumentoDoble progimp = new EnviarDocumentoDax.ImprimeDocumentoDoble(varbleComun.VarCom.nombreBaseIvaret,varbleComun.VarCom.strConxAdcom,varbleComun.VarCom.strConxIvaret,varbleComun.VarCom.strConxSyscod,varbleComun.VarCom.strConxAdcom,varbleComun.VarCom.codEmpresa,varbleComun.VarCom.pathServer);
            //ImprDoct.ImprimirDoc progimp = new ImprDoct.ImprimirDoc();
            //adcDocumentos.impresionVerificacion FImprimeDocumento = new adcDocumentos.impresionVerificacion();
            //impresionVerificacion.ImpDoc(idDocumentoActual.idClave, varbleComun.VarCom.suc, cmbDocumento.SelectedValue.ToString(), Convert.ToDouble(txtnumero.Text), "A", "F", propiedadesDoc.TipoDoc, propiedadesDoc.ImprimirForm);
            progimp.ImpDoc(idDocumentoActual, "A", "", false, false);
   //         progimp.claveSri = claveSri;
			//progimp.CorreoElectronico = txtCorreElectronico.Text;
		}


		private void btnEstadoCta_Click(object sender, EventArgs e)
		{
			if (codCliente == "") return;
			MntPago progG = new MntPago();
			string lasfacturas = "";
			double ValorAplicaciones = 0;
			progG.DocsPendientes(CONEMP.EmpresaAct.CruceDocSucursal, ref lasfacturas, idDocumentoActual.Sucursal, idDocumentoActual.Tipo, idDocumentoActual.idClave, codCliente, txtnombrecliente.Text, "", Convert.ToDouble(edTotal.Text), ref ValorAplicaciones, "", true);
			//adcCtasCorrientes.frmAnalisisIndCta ctacorr = new adcCtasCorrientes.frmAnalisisIndCta(codCliente,"01/01/1900",txtfecha.Text,"C");
			//ctacorr.ShowDialog();
			progG = null;
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

			adcCtasCorrientes.frmAplicacionesDcto prog = new adcCtasCorrientes.frmAplicacionesDcto(varbleComun.VarCom.strConxAdcom, idDocumentoActual.idClave, idDocumentoActual.Tipo, Convert.ToInt64(idDocumentoActual.numero), 0, txtfecha.Text, "", posicion, idDocumentoActual.Sucursal);
			prog.ShowDialog();
		}

		//
		private void copiarDocumento(idDocumento idDocCopiar, Boolean esGenerar = false)
		{
			utilDoc.cadenaConexion = varbleComun.VarCom.strConxAdcom;
			datAdcDocPro = new AdcDocPro(varbleComun.VarCom.strConxAdcom);
			string tabladoc = "";
			string tablatra = "";
			string tablapagos = "ADCPAG";
			utilDoc.tablasDeDatos(idDocCopiar.Tipo, ref tabladoc, ref tablatra);
			string Ssql = "doc_sucursal = '" + idDocCopiar.Sucursal + "' and opc_documento ='" + idDocCopiar.Tipo + "' and idclavedoc = " + idDocCopiar.idClave.ToString();

			if (tabladoc.ToUpper() == "ADCDOCPRO")
			{
				tablapagos = "ADCPAGPRO";
//                datAdcDocPro = AdcDocPro.Buscar(Ssql);
			}
  //          else
			{
				DataTable dt = utilBasDatos.utilBasDatos.leerTablas("select * from "+ tabladoc + " where " + Ssql, varbleComun.VarCom.strConxAdcom);

				if (dt.Rows.Count > 0) { DataRow DROW = dt.Rows[0]; datAdcDocPro = AdcDocPro.row2AdcDocPro(DROW); }
			}
			if (datAdcDocPro != null)
			{
				datAdcDocPro.IdClaveDoc = 0;
				datAdcDocPro.Doc_numero = Convert.ToDecimal(txtnumero.Text);
				this.malla.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.malla_CellValueChanged);
				if (esGenerar == false)
				{
					if (MessageBox.Show("Desea copiar la cabezera del documento ? ", "Copiar datos documento", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
					{
						cargarDatosCliente(datAdcDocPro.Doc_codper);
						moverCabezera();
					}
				}
				else
				{
					cargarDatosCliente(datAdcDocPro.Doc_codper);
					moverCabezera();
				}
				moverOtrosValores();
				cargarDetalleArticulos(idDocCopiar.Sucursal, idDocCopiar.Tipo, idDocCopiar.idClave, tablatra);
				cargarFormaDePago(idDocCopiar.Sucursal, idDocCopiar.Tipo, idDocCopiar.idClave, tablapagos);
				llenarIdDocumento(ref idDocumentoActual);
				idDocumentoActual.idClave = 0;
				//inicializarUtilidadDocumentos();
				totalizar();
				prepararBotones();
				this.malla.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.malla_CellValueChanged);
			}
		}
	
		private void limpiarValoresEnlaces()
		{
			datAdcDocPro.Doc_docnombre = propiedadesDoc.nombre;
			datAdcDocPro.Doc_DocSop = "";
			datAdcDocPro.Doc_NumSop = 0;
			datAdcDocPro.IdClaveDocSop = 0;
			datAdcDocPro.NroDocConsolida = 0;
			datAdcDocPro.TipDocConsolida = "";
			datAdcDocPro.IdClaveDocDespacho = 0;
			datAdcDocPro.Consolidar = false;
			datAdcDocPro.tipoEmision = 0;
		}
		private void consolidarDocumentos(idDocumento idDocCopiar)
		{
			//datADCDOC = new adcDocumentos.AdcDoc(varbleComun.VarCom.strConxAdcom);
			//string tablapagos = "ADCPAG";
			//string Ssql = "doc_sucursal = '" + idDocCopiar.Sucursal + "' and opc_documento ='" + idDocCopiar.Tipo + "' and idclavedoc = " + idDocCopiar.idClave.ToString();

			//datADCDOC = adcDocumentos.AdcDoc.Buscar(Ssql);
			//if (datADCDOC != null)
			//{
			//    datADCDOC.IdClaveDoc = 0;
			//    datADCDOC.Doc_numero = Convert.ToDecimal(txtnumero.Text);

			//    this.malla.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.malla_CellValueChanged);
			//    if (MessageBox.Show("Desea copiar la cabezera del documento ? ", "Copiar datos documento", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
			//    {
			//        cargarDatosCliente(datADCDOC.Doc_codper);
			//        moverCabezera();
			//    }
			//    moverOtrosValores();
			//    cargarDetalleArticulosConsolidacion (idDocCopiar.Lista);
			//    cargarFormaDePago(idDocCopiar.Sucursal, idDocCopiar.Tipo, idDocCopiar.idClave, tablapagos);
			//    llenarIdDocumento (ref idDocumentoActual);
			//    idDocumentoActual.idClave = 0;
			//    inicializarUtilidadDocumentos();
			//    totalizar();
			//    prepararBotones();
			//    this.malla.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.malla_CellValueChanged);
			//}

		}
		//private void inicializarUtilidadDocumentos()
		//{
		//    datAdcDocPro.Putil.Doc_sucursal = varbleComun.VarCom.suc;
		//    datAdcDocPro.Putil.Opc_documento = cmbDocumento.SelectedValue.ToString();
		//    datAdcDocPro.Putil.idsri = txtNroID.Text;
		//    datAdcDocPro.Putil.propietario = "";
		//    utilDoc.cadenaConexion = varbleComun.VarCom.strConxAdcom;
		//    lugarNumeracionDocumento = datAdcDocPro.Putil.establecerLugar(ref documentoMultiNumeracion);
		//    datAdcDocPro.Putil.esNroMultiple = documentoMultiNumeracion;
		//}

		private void malla_DataError(object sender, DataGridViewDataErrorEventArgs e)
		{
			MessageBox.Show("Error de datos, el valor del dato registrado es inválido");
		}

		private Boolean validarDocumento()
		{
			double PagoCredito = 0;
			//adcDocumentos.impresionVerificacion util = new adcDocumentos.impresionVerificacion();
//            ValidacionDocumentos.ValidacionGeneral   validacionDocumento validar = new daxMallaDatos.validacionDocumento();
			if (Convert.ToDouble("0" + txtnumero.Text) == 0) { mensajesErrorDocumento.MensajeNumeroDoc(); txtnumero.Focus(); return false; }
			if(ValidacionDocumentos.ValidacionGeneral.validarFecha(txtfecha.Text, ControlUsuario.Identifica)==false ) return false;
			if (codCliente == "" || txtcedula.Text == "") { mensajesErrorDocumento.ElCodigoNoExiste("C"); return false; }

			//if (propiedadesDoc.TipoSoporteObligatorio != "")
			//{
			//    if (txtNumeroSoporte.Text == "" || cmbDocumentoSustento.Text == "")
			//    {
			//        mensajesErrorDocumento.SinDocumentoReferencia(); return false;
			//    }
			//    else
			//    {
			//        if (clasref.LeerDocumentoReferencial(varbleComun.VarCom.suc, cmbDocumentoSustento.SelectedValue.ToString(), txtNumeroSoporte.Text, varbleComun.VarCom.suc, cmbDocumento.SelectedValue.ToString(), txtnumero.Text) == false)
			//        { clasref = null; mensajesErrorDocumento.SinDocumentoReferencia(); return false; }
			//    }
			//}
			if (validarIngresoDetalle() == false) { mensajesErrorDocumento.sinArtículosOservicios(); return false; }

			//daxMallaDatos.validacionDocumento valdoc = new daxMallaDatos.validacionDocumento();
			string docsustento = "";
			//try
			//{
			//    docsustento = cmbDocumentoSustento.SelectedValue.ToString();
			//}
			//catch { }
			string laBodega = CONEMP.EmpresaAct.BodSucActual;
			try { laBodega = ""; } catch { }//cmbBodega.SelectedValue.ToString(); } catch { }

			if (ValidacionDocumentos.ValidacionGeneral.ControlValidacionFacCli (ref malla, ref propiedadesDoc, clasref, txtfecha.Text, varbleComun.VarCom.suc, varbleComun.VarCom.strConxAdcom, varbleComun.VarCom.strConxSyscod, idDocumentoActual.idClave, laBodega, "", entregasPendientes, varbleComun.VarCom.suc, docsustento, "") == false) return false;


				if (clasePagos.pagosDelDocumento.Count > 0)
			{
				double TotalPago = 0;
				MntPago dp = new MntPago();
				foreach (pagosDocumento.pagoDoc Pago in clasePagos.pagosDelDocumento)
				{
					TotalPago += Pago.Valor;
					if (Pago.PagoACredito == 2 && dp.DiasPago(Pago.IdFormaDePago) > 3) PagoCredito += Pago.Valor;
				}
				if (Math.Round(TotalPago, 2) != Math.Round(Convert.ToDouble(totalesDocumento.TotVta), 2))
				{
					mensajesErrorDocumento.pagoDifiereTotalDoc();
					return false;
				}
			}
			else
			{
				PagoCredito = Convert.ToDouble(totalesDocumento.TotVta);
			}
			//if (opalex.limitecredito > 0 )
			//{
			//    double saldoCliente = 0;
			//    string cod = "exec ADC_CCINDU '" + opalex.codigo + "','" + "01/01/1901" + "','" + txtfecha.Text + "'," + 0 + ",0,0,'C','',0,'" + varbleComun.VarCom.suc + "','" + propiedadesDoc.Documento + "'," + idDocumentoActual.idClave.ToString();
			//    DataTable dt = utilBasDatos.utilBasDatos.leerTablas(cod, varbleComun.VarCom.strConxAdcom);
			//    if (dt.Rows.Count > 0) saldoCliente = Convert.ToDouble(dt.Rows[0]["Saldo"].ToString());
			//    if (saldoCliente + PagoCredito > opalex.limitecredito )
			//    {
			//        mensajesErrorDocumento.ventaExcedeCredito();
			//        return false;
			//    }
			//}
			return true;
		}
		private Boolean validarIngresoDetalle()
		{
			Boolean ret = false;
			foreach (DataGridViewRow row in malla.Rows)
			{
				if (row.Cells["tra_codigo"].Value.ToString() != "") return true;
			}
			return ret;
		}

		private Boolean grabarDocumento()
		{
			malla.EndEdit();
			Boolean RESP = true;

			string res = "";
			MoverControlesAClase();
			datAdcDocPro.Doc_Oculto = 0;
			if (classPedPerid.periodoPedFijo.tipo != 0 || classPedPerid.periodoPedFijo.mesDia1 > 0)
			{
				if (MessageBox.Show("Confirma guardar como Documento fijo de emisión períodica ?", "Documentos fijos periódicos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
				{
					datAdcDocPro.Doc_Oculto = 1;
				}
			}

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
					adcDocumentos.fijarNumeroDocumento fijnum = new adcDocumentos.fijarNumeroDocumento();
					datAdcDocPro.Doc_numero = Convert.ToDecimal(fijnum.nroDeDocumento(propiedadesDoc.tablaDatosDoc, propiedadesDoc.CodDuplica, Convert.ToBoolean(propiedadesDoc.NroAutomatico), Convert.ToDouble(txtnumero.Text), varbleComun.VarCom.strConxAdcom, varbleComun.VarCom.suc, cmbDocumento.SelectedValue.ToString(), txtnumero.Text,"", codCliente, txtNroID.Text));
					if (datAdcDocPro.Doc_numero == 0) return false;
					txtnumero.Text = datAdcDocPro.Doc_numero.ToString();
					res = datAdcDocPro.Crear();

					idDocumentoActual.idClave = Convert.ToDouble(datAdcDocPro.IdClaveDoc);
					idDocumentoActual.numero = Convert.ToDouble(datAdcDocPro.Doc_numero);

					if (res.Substring(0, 3) != "ERR") { grabarAdctraPro(); } else return false;
					grabarDatosExportacion();
					if (classPedPerid.periodoPedFijo.tipo > 0) classPedPerid.grabaLeeDatos.guardar(idDocumentoActual.idClave, idDocumentoActual.Sucursal, idDocumentoActual.Tipo);
					grabarPagosDocumento(); 
				}
				else
				{
					res = datAdcDocPro.Actualizar();
					if (res.Substring(0, 3) != "ERR") { grabarAdctraPro(); }
					grabarDatosExportacion();
					if (classPedPerid.periodoPedFijo.tipo > 0) classPedPerid.grabaLeeDatos.guardar(idDocumentoActual.idClave, idDocumentoActual.Sucursal, idDocumentoActual.Tipo);
					grabarPagosDocumento();
				}
				TimeSpan ts = new TimeSpan(365, 0, 0, 0);
				classPedPerid.generaracion.generar(datAdcDocPro.Doc_fecha, datAdcDocPro.Doc_fecha.Add(ts),idDocumentoActual);
				DaxCompRamos.CompRamos.EliminarProductosNoEnPedidos(idDocumentoActual.Sucursal,idDocumentoActual.Tipo,Convert.ToDecimal(idDocumentoActual.numero));
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
		private void grabarAdctraPro()
		{
			ClassDoc.grabMallTra.grabarDetalleAdctraPro(malla, datAdcDocPro, varbleComun.VarCom.strConxAdcom);
		}
		private void grabarDatosExportacion()
		{
				docExpor.dataExporta.Opc_documento = idDocumentoActual.Tipo;
				docExpor.dataExporta.Doc_numero = Convert.ToDecimal(idDocumentoActual.numero);
				docExpor.dataExporta.Doc_Sucursal = idDocumentoActual.Sucursal;
				docExpor.dataExporta.IdClaveDoc = Convert.ToDecimal(idDocumentoActual.idClave);
				docExpor.dataExporta.pedido = txtPO.Text;
				docExpor.dataExporta.Actualizar();
		}
		private void grabarDatosPedidosFijos()
		{
			{
				docExpor.dataExporta.Doc_numero = Convert.ToDecimal(idDocumentoActual.numero);
				docExpor.dataExporta.Doc_Sucursal = idDocumentoActual.Sucursal;
				docExpor.dataExporta.IdClaveDoc = Convert.ToDecimal(idDocumentoActual.idClave);
				docExpor.dataExporta.pedido = txtPO.Text;
				docExpor.dataExporta.Actualizar();
			}
		}
		private void grabarPagosDocumento()
		{
			if (clasePagos.pagosDelDocumento.Count == 0)
			{


			}
		}
		private void totalizar()
		{
			if (malla.Rows.Count < 1) return;
			//disMallFlor.diseñoMallaFlor.colorCaja(malla);
			saltar = true;
			VerificarValorImpuestos();
			totalesDocumento = new adcDocumentos.docTotals();
			edTotal.Text = Convert.ToString(totalesDocumento.totalizar(malla, claseImpuestos, claseDescuentos, clasePagos, propiedadesDoc, CONEMP.EmpresaAct.DigitosPrecios, CONEMP.EmpresaAct.DigitosCostos));
			presentarTotales();
			saltar = false;
		}
		private void presentarTotales()
		{
			string formato = "#,0.00";
			labTotDescuentoIva.Text = totalesDocumento.totdesciva.ToString(formato);
			labTotdescuentoSinIva.Text = totalesDocumento.totdessiva.ToString(formato);
			labTotIva.Text = totalesDocumento.TotIva.ToString(formato);
			labTotPorcIva.Text = (claseImpuestos.impstoPorcentaje1).ToString() + "% IVA";
			labTotSubConIva.Text = totalesDocumento.Subtotalciva.ToString(formato);
			labTotSubSinIva.Text = totalesDocumento.SubTotalSIva.ToString(formato);
			labTotVtaConIva.Text = totalesDocumento.TotCiva.ToString(formato);
			labTotVtaSinIva.Text = totalesDocumento.TotSiva.ToString(formato);
			labTotalDescuento.Text = totalesDocumento.TotDescuentos.ToString(formato);
			labTotalVenta.Text = (totalesDocumento.TotCiva + totalesDocumento.TotSiva).ToString(formato);
			labSubtotal.Text = (totalesDocumento.Subtotalciva + totalesDocumento.SubTotalSIva).ToString(formato);
		}

		private void ActualizarDatosCliente()
		{
			string ssql = "update identificacion set correoElectrónico = '" + txtCorreElectronico.Text + "' where codigo = '" + codCliente + "'";
			using (SqlConnection conn = new SqlConnection(varbleComun.VarCom.strConxAdcom))
			{
				conn.Open();
				using (SqlCommand comm = new SqlCommand(ssql, conn))
				{
					comm.ExecuteNonQuery();
				}
			}
		}
		private void EliminarComposicionSinPedido()
		{
			using (SqlConnection conn = new SqlConnection(varbleComun.VarCom.strConxAdcom))
			{
				conn.Open();
				using (SqlCommand comm = new SqlCommand("DaxEliCompDoc", conn))
				{
					comm.ExecuteNonQuery();
				}
			}
		}
		
		private void llenarIdDocumento(ref idDocumento docmtoActual)
		{
			docmtoActual.Sucursal = varbleComun.VarCom.suc;
			docmtoActual.Tipo = cmbDocumento.SelectedValue.ToString();
			docmtoActual.fecha = txtfecha.Value;
			try
			{
				docmtoActual.numero = Convert.ToDouble(txtnumero.Text);
			}
			catch { docmtoActual.numero = 0; }
		}

		private void btnExportacion_Click(object sender, EventArgs e)
		{
			frmExporta progex = new frmExporta(idDocumentoActual);
			docExpor.dataExporta.conexiondata = varbleComun.VarCom.strConxAdcom;
			docExpor.dataExporta.Opc_documento = cmbDocumento.SelectedValue.ToString();
			docExpor.dataExporta.Doc_numero = Convert.ToDecimal("0" + txtnumero.Text);
			docExpor.dataExporta.Doc_Sucursal = varbleComun.VarCom.suc;
			docExpor.dataExporta.IdClaveDoc = Convert.ToDecimal(idDocumentoActual.idClave);
			docExpor.dataExporta.pedido = txtPO.Text;

			progex.ShowDialog();
			progex.Dispose();
		}

		private void chequearCambioValoresPoFecha()
		{
			totalizar();
		}
		private void btnPorcentajeIva_Click(object sender, EventArgs e)
		{
			Buscar.frmBuscar progBus = new Buscar.frmBuscar();
			string ssql = "select  Porcentaje, isnull(fechaInicio,'01/01/1900') as ValidoDesde";
			ssql += ", isnull(FechaFin,'31/12/2078') as ValidoHasta from porcentajeiva";
			string nvoIva = progBus.Buscar(varbleComun.VarCom.strConxIvaret , ssql, "porcentaje", "porcentaje", "", "Seleccionar porcentaje IVA", "");
			if (MessageBox.Show("Confirma cambiar el porcentaje del IVA en el documento ?", "Cambiar porcentaje del IVA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
			claseImpuestos.cambiadoManual = true;
			claseImpuestos.impstoPorcentaje1 = Convert.ToDouble("0" + nvoIva);
			totalizar();
		}

		private void btnPeriodico_Click(object sender, EventArgs e)
		{
			classPedPerid.frmPedPer frmPeriod = new classPedPerid.frmPedPer(txtfecha.Value);
			frmPeriod.ShowDialog();
			frmPeriod.Dispose();
		}

		private void malla_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{          
			totalizar();
		}

		private void btnClienteFinal_Click(object sender, EventArgs e)
		{
			DaxMantDirectorio.BuscaClientFin busccaf = new DaxMantDirectorio.BuscaClientFin();
			string codigo = "";
			string nombre = txtnombrecliente.Text;
			//string conalias = "N";
			codigo = busccaf.IniBuscaCliFinal(txtCedulaClienteFinal.Text , codCliente, ref nombre);
			if ((codigo + "").Length > 0) cargarDatosClienteFinal(codigo);
			busccaf.Dispose();
		}

		private void btnExistenciasProducto_Click(object sender, EventArgs e)
		{
			//try
			//{
			//	daxArticulo.frmDatosComerciales conArt = new daxArticulo.frmDatosComerciales(malla.CurrentRow.Cells["tra_Codigo"].ToString(), varbleComun.VarCom.strConxAdcom, "", codCliente, DateTime.Now.ToShortDateString(), "", "", "");
			//	conArt.ShowDialog();
			//	conArt.Dispose();
			//}
			//catch { }
		}
		private void VerificarValorImpuestos()
		{
			if (claseImpuestos.cambiadoManual == true) return;
			if (propiedadesDoc.DocumentoSinIva == true) { claseImpuestos.impstoPorcentaje1 = 0; return; }
			else if (opalex.ExoneradoIva == true) { claseImpuestos.impstoPorcentaje1 = 0; return;}
			if (claseImpuestos.impstoPorcentaje1 == 0 || claseImpuestos.impstoFechaIni1 > txtfecha.Value || claseImpuestos.impstoFechaFin1 < txtfecha.Value)
			{ claseImpuestos.cargar(varbleComun.VarCom.strConxIvaret, txtfecha.Value);}
		}

		private void Malla_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
		{
			totalizar();
		}

		private void txtnumero_TextChanged(object sender, EventArgs e)
		{
			idDocumentoActual.numero = Convert.ToDouble("0"+txtnumero.Text);
		}
	}
}