using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
//using DtosMall;
using DaxComercia;
using classMenSistem;
using ctrlReferencia;
using ClassDoc;
using System.Drawing;
using DattCom;
using IvaRett;
using comercP;
using DtosMall;
using DctosEmi;
using SolicitudAutSRI;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Net;
using DaxValDocElec;
using System.Linq;
using DaxDocElectronicos;
using System.ComponentModel;
using ImpresionDoc;

namespace adcDocumentos
{
	public partial class FormFacPV : Form
	{
		internal sesSys.OpcDoc propiedadesDoc;
		directMnt.DirectorioAlex opalex = new directMnt.DirectorioAlex();
		AdcDoc datADCDOC;
		DaxComercia.classPagosDoc clasePagos = new DaxComercia.classPagosDoc();
		adcDescto.descDocumento claseDescuentos = new adcDescto.descDocumento();
		docImpuestos claseImpuestos = new docImpuestos();
		daxAccs.propiedadesDaxAuto accesosLocalizados = new daxAccs.propiedadesDaxAuto();

		ctrlReferencia.controlReferencial clasref = new controlReferencial();
		DataTable dtDetalleDocumento = new DataTable();

		 DctosEmi.docTotals totalesDocumento = new DctosEmi.docTotals();
		string claseDocDefault = "FAC";
		string tipoDocDefault = "FAC";

		bool iniciaConNuevoDOc = false;
		Boolean esSoloConsulta = false;
		Boolean entregasPendientes = false;
		Boolean esDeLiquidacion = false;
		Boolean debeActualizarContacto = false;

		idDocumento idDocumentoActual = new idDocumento();
		idDocumento idDocumentoSoporte = new idDocumento();
		idDocumento idDocumentoParaGenerar = new idDocumento();

		string codCliente = "";
		Boolean saltarEventoNumero = false;
		Boolean saltaEventosMalla = false;

		int operacionEnCurso = 0; // 0 sin operacion delcarada, 1 nuevo registro, 2 modificando registro
		int sinOperacion = 0;
		int nuevoRegistro = 1;
		int modificandoRegistro = 2;

		string memTipoDoc = "";
		string memVendedor = "";
		string memBodega = "";

		public string urlE = "";
		string PathFile = "";
		short tipoEmision = 0;

		/// <summary>
		/// variables de solicitar autorizacion eln linea
		/// </summary>
		
		//string PathFileE = "";
		string queSucE = "";
		string queDocE = "";
		decimal queNumE = 0;
		//short tipoEmisionE = 0;
		string queClaveSRIE = "";
		double IdClaveDocFE = 0;
		string ErroresE = "";
		string correoElectronicoDefectoE = "";
		List<string> colecError = new List<string>();
		string queCodigoCliente = "";
		string correoElectronico = "";
		Auxiliares aux = new Auxiliares();
		public FormFacPV(string clasdef, string tipdef, bool nuevo = false, Boolean esConsulta = false, Boolean generarFactura = false, Boolean desdeEstdoCta = false, idDocumento idDocViene = null, string sisMedico = "")
		{
			InitializeComponent();
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
			ptoVenta.Visible = valoresPredefinidosSucursal.autCambiaPtoVta;
			LlenarCombos();
			CargarPredefinidosDocumento();
			this.txtfecha.ValueChanged += new System.EventHandler(this.txtfecha_ValueChanged);
			this.Text = "MANTENIMIENTO DOCUMENTOS FACTURACION A CLIENTES : " + datosEmpresa.nomEmpresa + " PUNTO DE VENTA: " + valoresPredefinidosSucursal.nomPuntoVta;
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
			prepararBotones();
			ConfiguracionCorreo.CargarConfiguracion(datosEmpresa.strConxAdcom,datosEmpresa.Emp_codigo.ToString());
			ConfiguracionCorreo.CargarParametroSRI(datosEmpresa.strConIniSis, datosEmpresa.Emp_codigo);
		}

		private void LlenarCombos()
		{
			recordarOpciones();
			DaxCombobx.CargCmbBox cmb = new DaxCombobx.CargCmbBox();
			cmb.DaxCombosDoc(claseDocDefault, "", false, datosEmpresa.strConxAdcom, ref cmbDocumento);
			cmb.DaxCombosBods(datosEmpresa.suc, false, datosEmpresa.strConIniSis, ref cmbBodega);
			cmb.DaxCombosVend(datosEmpresa.strConxAdcom, ref cmbVendedor, false);
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
			if (cmbVendedor.Items.Count > 0)
			{
				if (memVendedor.Length > 0) { cmbVendedor.SelectedValue = memVendedor; } else { cmbVendedor.SelectedIndex = 0; }
			}
		}
		private void CargarPredefinidosDocumento()
		{
			propiedadesDoc = new sesSys.OpcDoc();
			propiedadesDoc.Cargar(ref idDocumentoActual.Tipo, ref idDocumentoActual.Sucursal);
			accesosLocalizados.iniciar(datosEmpresa.codEmpresa, datosEmpresa.usr, datosEmpresa.strConxSyscod);
			accesosLocalizados.cargarAccesoDoc(idDocumentoActual.Tipo);        
			HabilitarOpcionesDocumento();
		}
		private void HabilitarOpcionesDocumento()
		{
			HabilitarSoporte((propiedadesDoc.TipoSoporteObligatorio.Length > 0 && propiedadesDoc.TipoSoporteObligatorio != "ORP") || datosAuxiliares.tieneDatoDocumento("DocumentoReferencia", propiedadesDoc));

			cmbVendedor.Visible = (datosAuxiliares.tieneDatoDocumento("Vendedor", propiedadesDoc));
			lbVendedor.Visible = cmbVendedor.Visible;

			labNroLote.Visible = (datosAuxiliares.tieneDatoDocumento("NúmeroLote", propiedadesDoc));
			txtNroLote.Visible = labNroLote.Visible;

			btnDescuentos.Visible = (datosAuxiliares.tieneDatoDocumento("DescuentoDocumento", propiedadesDoc));

			btnExportacion.Visible = (datosAuxiliares.tieneDatoDocumento("Transporte", propiedadesDoc));

			btnPendientes.Visible = true;
			// chequear lectura de parametros en varbl
			//btnContabiliza.Visible = (datosEmpresa.auto.Substring(3, 1) == "1" && propiedadesDoc.noCtbLinea != "X" && propiedadesDoc.SNContabilizar != 0);
			cmbBodega.Visible = (datosAuxiliares.tieneDatoDocumento("Bodega", propiedadesDoc));
			lbBodega.Visible = cmbBodega.Visible;

			if (accesosLocalizados.sinRegistro==false) registrarAccesosLocalizadosDocumento();
		}
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

			btnCopia.Enabled = nuevo;

			btnAnula.Enabled = (modificando && !docAnulado);
			btnElimina.Enabled = modificando;
			btnImprimir.Enabled  = modificando;
			btnGraba.Enabled = (!inicio && !docAnulado);
			btnRegistra.Enabled = btnGraba.Enabled;
			btnEnviar.Enabled = (modificando && !docAnulado);
			btnCierra.Enabled = !inicio;
			btnConsolida.Enabled = nuevo;

			btnPagos.Enabled = btnGraba.Enabled;
			btnDescuentos.Enabled = btnGraba.Enabled;
			ptoVenta.Enabled = inicio;
			btnPorcentajeIva.Enabled = btnDescuentos.Enabled;
			btnContabiliza.Enabled = btnGraba.Enabled;
			btnExportacion.Enabled = btnGraba.Enabled;
			btnPendientes.Enabled = btnGraba.Enabled;

			btnBarras.Enabled = (!inicio) && !docAnulado;
			btnAgrupa.Enabled = (btnBarras.Enabled && btnBarras.Checked);

			panel1.Enabled = (!inicio);
			malla.Enabled = (!inicio);

			cmbDocumento.Enabled = (inicio);
			txtcedula.Enabled = (!docAnulado);
			if (datosEmpresa.usr.ToUpper() == "ADMINISTRADOR" || inicio ) return;
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
				btnImprimir.Enabled = (btnImprimir.Enabled && accesosLocalizados.Imprimir); //(accesosLocalizados.Imprimir && !inicio);
				btnNuevo.Enabled = (accesosLocalizados.Crear && btnNuevo.Enabled);
				btnElimina.Enabled = (accesosLocalizados.Eliminar && btnElimina.Enabled);
				btnAnula.Enabled = (accesosLocalizados.Anular && btnAnula.Enabled);
				btnCopia.Enabled  = (accesosLocalizados.Crear && btnCopia.Enabled) ;
				btnConsolida.Enabled  = (accesosLocalizados.Crear && btnConsolida.Enabled);

			}

			if (inicio) return;

			if (esSoloConsulta == true || docAnulado)
			{
				btnGraba.Enabled = false;
				btnRegistra.Enabled = false;
				btnElimina.Enabled = false;
				btnAnula.Enabled = false;
				if (datADCDOC.Doc_Estado == 1) btnElimina.Enabled = (datosEmpresa.usr.ToUpper() == "ADMINISTRADOR");
			}
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

		private void HabilitarSoporte(bool tieneSoporte)
		{
			cmbDocumentoSustento.Visible = tieneSoporte;
			labSoporteNumero.Visible = tieneSoporte;
			labSoporteTipo.Visible = tieneSoporte;
			nroDocSoporte.Visible = tieneSoporte;
			btnBuscaDocumentoSoporte.Visible = tieneSoporte;
			if (tieneSoporte) LlenarComboDocReferencia();
			//if (propiedadesDoc.TipoSoporteObligatorio.Length > 0)
			//{
			//	cmbDocumentoSustento.SelectedValue = propiedadesDoc.TipoSoporteObligatorio;
			//	cmbDocumentoSustento.Enabled = false;
			//}
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
					prepararBotones();
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
			DctosEmi.armarConsTra dcut = new DctosEmi.armarConsTra();
			DctosEmi.diseñarMalla dcut2 = new DctosEmi.diseñarMalla();

			dtDetalleDocumento = utilBasDatos.utilBasDatos.leerTablas(dcut.armarSqlLecturaTraFacPv(propiedadesDoc, tablatra, suc, tip, idClave), datosEmpresa.strConxAdcom);
			dcut = null;
			if (dtDetalleDocumento == null) return;
			malla.DataSource = dtDetalleDocumento;
			dcut2.diseñarMallaFacPv(ref malla, ref propiedadesDoc);
			malla.Columns["Existencia"].Visible = valoresPredefinidosEmpresa.existenciaEnLineas;

			dcut = null;
			dcut2 = null;
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
		private void moverDatosClase()
		{
			datADCDOC.Doc_sucursal = datosEmpresa.suc;
			datADCDOC.Doc_Bodega = cmbBodega.SelectedValue.ToString();
			datADCDOC.Opc_documento = cmbDocumento.SelectedValue.ToString();
			datADCDOC.Doc_docnombre = cmbDocumento.Text;
			datADCDOC.Doc_numero = Convert.ToDecimal(txtnumero.Text);
			datADCDOC.Doc_fecha = Convert.ToDateTime(txtfecha.Text);
			datADCDOC.Doc_codper = codCliente;
			datADCDOC.Doc_CiRuc = txtcedula.Text;
			datADCDOC.Doc_NombreImp = txtnombrecliente.Text;
			datADCDOC.Doc_Direccion = txtdireccion.Text;
			datADCDOC.Doc_Telefono1 = txttelefono.Text;
			datADCDOC.Doc_detalle = txtDetalle.Text;

			//datADCDOC.Doc_venabre = cmbVendedor.SelectedValue.ToString();
			if (cmbVendedor.SelectedValue != null)
			{
				datADCDOC.Doc_venabre = cmbVendedor.SelectedValue.ToString();
			}
			else
			{
				datADCDOC.Doc_venabre = "";   // o null, o un valor por defecto
			}

			datADCDOC.Doc_DocSop = "";
			datADCDOC.Doc_NumSop = 0;
			datADCDOC.Doc_valor = Convert.ToDecimal(edTotal.Text);
			datADCDOC.AuxVar9 = txtCorreElectronico.Text;

			if (operacionEnCurso == 1)
			{
				datADCDOC.PuntoVta = valoresPredefinidosSucursal.nomPuntoVta;
				datADCDOC.Doc_Hora = docUtils.DaxNow();
				datADCDOC.Doc_Estado = 1;
			}

			datADCDOC.Doc_nombredes1 = claseDescuentos.nombreDes[0];
			datADCDOC.Doc_nombredes2 = claseDescuentos.nombreDes[1];
			datADCDOC.Doc_nombredes3 = claseDescuentos.nombreDes[2];

			datADCDOC.Doc_porcendes1 = Convert.ToDecimal(claseDescuentos.porcentajeDes[0]);
			datADCDOC.Doc_porcendes2 = Convert.ToDecimal(claseDescuentos.porcentajeDes[1]);
			datADCDOC.Doc_porcendes3 = Convert.ToDecimal(claseDescuentos.porcentajeDes[2]);

			datADCDOC.Doc_valordes1 = Convert.ToDecimal(claseDescuentos.valorDes[0]); ;
			datADCDOC.Doc_valordes2 = Convert.ToDecimal(claseDescuentos.valorDes[1]);
			datADCDOC.Doc_valordes3 = Convert.ToDecimal(claseDescuentos.valorDes[2]);

			datADCDOC.Doc_porceniva = Convert.ToDecimal(claseImpuestos.impstoPorcentaje1);

			datADCDOC.Doc_NroLoteDoc =  txtNroLote.Text;
			datADCDOC.Doc_NroIdDoc = txtNroID.Text;
			datADCDOC.Adi_TipoDocSri = propiedadesDoc.TipoSri;
			//datADCDOC.Adi_FechContab = IIf(FechaContab < TxtFecha, TxtFecha, FechaContab)
			//datADCDOC.Adi_CodigoNSR = TexCodigoExoneraRetencion.Text
			//datADCDOC.Adi_SustTrib = DatSustento.BoundText
			//datADCDOC'.Adi_SNDevIva = IIf(DerechoIva.Value = 1, "S", "N")
			datADCDOC.IdClaveDoc = Convert.ToDecimal(idDocumentoActual.idClave);
			datADCDOC.IdClaveDocSop = 0;
			datADCDOC.Doc_docnombre = cmbDocumento.Text; 
			datADCDOC.Doc_TipoDoc = propiedadesDoc.TipoDoc;
			datADCDOC.Doc_FechaEfe = Convert.ToDateTime(txtfecha.Text);     //FechaVence.Value
			datADCDOC.Doc_extension = "";
			datADCDOC.Doc_codusu = datosEmpresa.usr;
			datADCDOC.Doc_valoriva = totalesDocumento.TotIva;
			datADCDOC.Doc_totciva = totalesDocumento.TotCiva;
			datADCDOC.Doc_totsiva = totalesDocumento.TotSiva;
			datADCDOC.Doc_valorabon = Convert.ToDecimal(clasePagos.totalContado);
			datADCDOC.Doc_DepDes = "";
			datADCDOC.Doc_TotDesArt = totalesDocumento.TotDesArt;
			datADCDOC.Doc_TotDesSer = totalesDocumento.TotDesSer;
			datADCDOC.Doc_TotArtCIva = totalesDocumento.TotArtCIva;
			datADCDOC.Doc_TotArtSIva = totalesDocumento.TotArtSIva;
			datADCDOC.Doc_TotSerCIva = totalesDocumento.TotSerCIva;
			datADCDOC.Doc_TotSerSIva = totalesDocumento.TotSerSIva;
			datADCDOC.Doc_TotAcf = totalesDocumento.TotAcf;
			datADCDOC.Doc_Contado = totalesDocumento.ValorEfec;
			datADCDOC.Doc_Oculto = propiedadesDoc.ClaveOculto;
			datADCDOC.Doc_Contabilidad = propiedadesDoc.ClaveContable;
			datADCDOC.Doc_Banco = Convert.ToInt16(propiedadesDoc.ClaveBanco);
			datADCDOC.Doc_Inventario = Convert.ToInt16(propiedadesDoc.ClaveInventario);
			datADCDOC.Doc_Ventas = Convert.ToInt16(propiedadesDoc.ClaveVentas);
			datADCDOC.Doc_Compras = Convert.ToInt16(propiedadesDoc.ClaveCompras);
			datADCDOC.Doc_Activo = Convert.ToInt16(propiedadesDoc.ClaveActivo);
			datADCDOC.Doc_Adicional2 = 0;
			datADCDOC.Doc_NumeroExterno = 0;
			datADCDOC.IdClaveDocSop = Convert.ToDecimal( idDocumentoSoporte.idClave);
			datADCDOC.Doc_FechaModifica = docUtils.DaxNow();
			datADCDOC.doc_TotDesSiva = totalesDocumento.totdessiva;
			datADCDOC.doc_TotDesCIva = totalesDocumento.totdesciva;
			//datADCDOC.Adi_NroAutSri = "";                   //TextNroAutSri
			datADCDOC.ProductoProduccion = "";            // ProductoProduccion.Text
			datADCDOC.BaseImp1 = totalesDocumento.Subtotalciva;
			datADCDOC.ValorImp1 = totalesDocumento.TotImp1;
			datADCDOC.PorcImp1 = Convert.ToDecimal(claseImpuestos.impstoPorcentaje1);

			//datADCDOC.BaseImp2 = totalesDocumento.Subtotalciva2;
			datADCDOC.ValorImp2 = totalesDocumento.TotImp2;
			datADCDOC.PorcImp2 = Convert.ToDecimal(claseImpuestos.impstoPorcentaje2);

			//datADCDOC.BaseImp3 = totalesDocumento.Subtotalciva3;
			datADCDOC.ValorImp3 = totalesDocumento.TotImp2;
			datADCDOC.PorcImp3 = Convert.ToDecimal(claseImpuestos.impstoPorcentaje2);

			//datADCDOC.FacDesde = FDesde.Value;
			//datADCDOC.FacDesde = FDesde.Value;
			//datADCDOC.FacDesde = FDesde.Value;
			//datADCDOC.FacHasta = FHasta.Value;
			//datADCDOC.TipoPeriodo = "";
		}


		private void btnCierra_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Confirma cerrar el documento actual ?", "Cerrar documento sin grabar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No) return;
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
			txtCambio.Text = "";
			txtRecibido.Text = "";
			prepararBotones();
			//            InicializarMalla();
		}
		private void InicializarMalla()
		{
		  //  this.malla.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.malla_CellValueChanged);
			DctosEmi.armarConsTra dcut = new DctosEmi.armarConsTra();
			dtDetalleDocumento = utilBasDatos.utilBasDatos.leerTablas(dcut.armarSqlLecturaTraFacPv(propiedadesDoc, "adctra", "", "", 0), datosEmpresa.strConxAdcom);
			if (dtDetalleDocumento == null) return;
			malla.DataSource = dtDetalleDocumento;
			dtDetalleDocumento.Rows.Add(dtDetalleDocumento.NewRow());
			DctosEmi.diseñarMalla dcut2 = new DctosEmi.diseñarMalla();
			dcut2.diseñarMallaFacPv(ref malla, ref propiedadesDoc);
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
			if ( DctosEmi.ValidarDatos.ValidarDatosVentas(nomCol,malla.Rows[e.RowIndex], accesosLocalizados) == false) return;
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
				//if (grabarDocumento() == true) { limpiarDatos(); }
				if (grabarDocumento() == true)
				{
					////if (ConfiguracionCorreo.ParametroCargado && ConfiguracionCorreo.parametro == 1)
					//if (ConfiguracionCorreo.parametro == 1)
					//{
					//	urlE = ConfiguracionCorreo.UrlSRI; // Aquí obtienes la URL desde la BD
					//	solicitarAutorizacionSRI(urlE);
					//}

					limpiarDatos();
				}
			}

		}

		public class FormaDePago
		{
			public int Codigo { get; set; }
			public string Descripcion { get; set; }
		}

		// Lista desde la base de datos
		List<FormaDePago> formasDePago = ObtenerFormasDePagoDesdeBD(); // Implementa este método

		private static List<FormaDePago> ObtenerFormasDePagoDesdeBD()
		{
			var lista = new List<FormaDePago>();

			// Cambia esto por tu cadena de conexión real
			//string connectionString = "Data Source=SERVIDOR;Initial Catalog=IvaretDaxFSPC;Integrated Security=True;";

			string query = "SELECT Código, Descripción FROM DBO.FormasDePago";

			using (SqlConnection connection = new SqlConnection(datosEmpresa.strConxIvaret))
			{
				SqlCommand command = new SqlCommand(query, connection);

				try
				{
					connection.Open();
					SqlDataReader reader = command.ExecuteReader();

					while (reader.Read())
					{
						var forma = new FormaDePago
						{
							Codigo = Convert.ToInt32(reader["Código"]),
							Descripcion = reader["Descripción"].ToString()
						};
						lista.Add(forma);
					}

					reader.Close();
				}
				catch (Exception ex)
				{
					// Maneja el error según tus necesidades
					Console.WriteLine("Error al obtener formas de pago: " + ex.Message);
				}
			}
			return lista;
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

				string pdfPath = rideService.GenerarRide(this.datADCDOC.IdClaveDoc, datADCDOC.Doc_sucursal,datADCDOC.Opc_documento,datADCDOC.Doc_numero, queClaveSRIE, urlEs);
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error al generar PDF: {ex.Message}");
			}
		}


		private void almacenarErrores(string err) => this.colecError.Add(err);

		private string ObtenerCorreoDesdeIdentificacion(string queCodigoCliente)
		{
			string correo = "";

			try
			{
				using (SqlConnection conexion = new SqlConnection(datosEmpresa.strConxAdcom))
				{
					conexion.Open();
					string query = "SELECT CorreoElectrónico FROM Identificacion WHERE codigo = @CodPer";

					using (SqlCommand cmd = new SqlCommand(query, conexion))
					{
						cmd.Parameters.AddWithValue("@CodPer", codCliente);

						using (SqlDataReader reader = cmd.ExecuteReader())
						{
							if (reader.Read())
							{
								correo = reader["CorreoElectrónico"].ToString().Trim();
							}
						}
					}
				}
			}
			catch (Exception )
			{
				// Puedes loguear el error si deseas
				correo = "";
			}

			return correo;
		}


		private bool verificaCorreoElectronico(ref string correoElectronico)
		{
			if (correoElectronico.Length == 0)
				correoElectronico = this.correoElectronicoDefectoE;
			return correoElectronico.Length != 0 && ValidacionesDocElectronicos.ValidarEmail(correoElectronico);
		}


		public ResultadoCpbtFac EjecutarProcedimientoCabeceraYDetalle(int id, string sucursal, string tipoDoc, decimal numero)
		{
			var resultado = new ResultadoCpbtFac();
			resultado.Detalles = new List<DetalleCpbtFac>();

			using (var conn = new SqlConnection(datosEmpresa.strConxAdcom))
			{
				var cmd = new SqlCommand("adc_CpbtFac", conn);
				cmd.CommandType = CommandType.StoredProcedure;

				cmd.Parameters.AddWithValue("@idclavedoc", id);
				cmd.Parameters.AddWithValue("@docsuc", sucursal);
				cmd.Parameters.AddWithValue("@doctip", tipoDoc);
				cmd.Parameters.AddWithValue("@numero", numero);

				conn.Open();

				using (var reader = cmd.ExecuteReader())
				{
					bool isFirstRow = true;

					while (reader.Read())
					{
						if (isFirstRow)
						{
							// ✅ Cabecera: solo se llena una vez
							resultado._RegimenMicroempresas = reader["RegimenMicroempresas"].ToString();
							resultado._NroAcdoAgntRetencion = reader["NroAcdoAgntRetencion"].ToString();
							resultado._empObligConta = reader["empObligConta"].ToString();
							resultado._Doc_TipoDoc = reader["Doc_TipoDoc"].ToString();
							resultado._Opc_documento = reader["Opc_documento"].ToString();
							resultado._Doc_numero = Convert.ToInt32(reader["Doc_numero"]);
							resultado._Doc_sucursal = reader["Doc_sucursal"].ToString();
							resultado._Doc_fecha = Convert.ToDateTime(reader["Doc_fecha"]);
							//resultado._Doc_porceniva = Convert.ToDouble(reader["Tra_porceniva"]);			
							resultado._Doc_totciva = Convert.ToDouble(reader["Doc_totciva"]);
							resultado._Doc_totsiva = Convert.ToDouble(reader["Doc_totsiva"]);
							resultado._subtotal = Convert.ToDouble(reader["subtotal"]);
							resultado._totalDescuento = Convert.ToDouble(reader["totDescUnitario"]);
							resultado._Doc_valor = Convert.ToDouble(reader["Doc_valor"]);
							resultado._Doc_NombreImp = reader["Doc_NombreImp"].ToString();
							resultado._Doc_NumSop = reader["Doc_NumSop"].ToString();
							resultado._doc_detalle = reader["doc_detalle"].ToString();
							resultado._tipEmision = reader["tipEmision"].ToString();
							if (reader["fechaAutorizacion"] != DBNull.Value && !string.IsNullOrWhiteSpace(reader["fechaAutorizacion"].ToString()))
							{
								resultado._fechaAutorizacion = Convert.ToDateTime(reader["fechaAutorizacion"]);
							}
							else
							{
								resultado._fechaAutorizacion = null; // o DateTime.MinValue, según tu lógica
							}

							resultado._NroAutorizacionSri = reader["NroAutorizacionSri"].ToString();
							resultado._guiaRemision = reader["guiaRemision"].ToString();
							resultado._PreEntrada = reader["PreEntrada"].ToString();
							resultado._Idclavedoc = Convert.ToInt32(reader["Idclavedoc"]);
							resultado._tipAmbiente = reader["tipAmbiente"].ToString();
							resultado._Doc_CiRuc = reader["Doc_CiRuc"].ToString();
							resultado._Doc_Direccion = reader["Doc_Direccion"].ToString();
							resultado._Doc_Telefono1 = reader["Doc_Telefono1"].ToString();
							resultado._Doc_NroIdDoc = reader["Doc_NroIdDoc"].ToString();
							resultado._Adi_TipoDocSri = reader["Adi_TipoDocSri"].ToString();
							resultado._claveAcceso = reader["claveAcceso"].ToString();
							resultado._TipoIdentificacion = reader["TipoIdentificacion"].ToString();
							resultado._CorreoElectrónico = reader["CorreoElectrónico"].ToString();
							resultado._NroCtrbuyteEspecial = reader["NroCtrbuyteEspecial"].ToString();
							resultado._ObligLlevarConta = reader["ObligLlevarConta"].ToString();
							resultado._Tra_NroLote = reader["Tra_NroLote"].ToString();
							resultado._AuxVar1 = reader["AuxVar1"].ToString();
							resultado._Pag_Descripcion = reader["Pag_Descripcion"].ToString();
							resultado._Pag_Cuotas = reader["Pag_Cuotas"].ToString();
							resultado._Pag_Autoriza = reader["Pag_Autoriza"].ToString();
							resultado._totDescUnitario = Convert.ToDouble(reader["totDescUnitario"].ToString());
							//resultado._Base15 = Convert.ToDouble(reader["Base15"].ToString());

							if (reader["Base15"] != DBNull.Value && !string.IsNullOrWhiteSpace(reader["Base15"].ToString()))
							{
								resultado._Base15 = Convert.ToDouble(reader["Base15"]);
							}
							else
							{
								resultado._Base15 = 0; // o el valor por defecto que tú necesites
							}


							//resultado._Base5 = Convert.ToDouble(reader["Base5"].ToString());

							if (reader["Base5"] != DBNull.Value && !string.IsNullOrWhiteSpace(reader["Base5"].ToString()))
							{
								resultado._Base5 = Convert.ToDouble(reader["Base5"]);
							}
							else
							{
								resultado._Base5 = 0; // o el valor por defecto que tú necesites
							}

							//resultado._Iva5 = Convert.ToDouble(reader["Iva5"].ToString());
							if (reader["Iva5"] != DBNull.Value && !string.IsNullOrWhiteSpace(reader["Iva5"].ToString()))
							{
								resultado._Iva5 = Convert.ToDouble(reader["Iva5"]);
							}
							else
							{
								resultado._Iva5 = 0; // o el valor por defecto que tú necesites
							}
							//resultado._Iva15 = Convert.ToDouble(reader["Iva15"].ToString());

							if (reader["Iva15"] != DBNull.Value && !string.IsNullOrWhiteSpace(reader["Iva15"].ToString()))
							{
								resultado._Iva15 = Convert.ToDouble(reader["Iva15"]);
							}
							else
							{
								resultado._Iva15 = 0; // o el valor por defecto que tú necesites
							}

							isFirstRow = false;
						}

						// ✅ Detalle: se llena en cada fila
						resultado.Detalles.Add(new DetalleCpbtFac
						{
							_Tra_Codigo = reader["Tra_Codigo"].ToString(),
							_Tra_nombre = reader["Tra_nombre"].ToString(),
							_Tra_cantidad = Convert.ToDecimal(reader["Tra_cantidad"]),
							_Tra_precuni = Convert.ToDecimal(reader["Tra_precuni"]),
							_Tra_prectot = Convert.ToDecimal(reader["Tra_prectot"]),
							_desctoUni = Convert.ToDecimal(reader["desctoUni"]),
							_Tra_porcendes = Convert.ToDecimal(reader["Tra_porcendes"])
						});
					}
				}
			}

			return resultado;
		}

		public class ResultadoCpbtFac
		{
			public string _RegimenMicroempresas { get; set; }
			public string _NroAcdoAgntRetencion { get; set; }
			public string _empObligConta { get; set; }
			public string _Doc_TipoDoc { get; set; }
			public string _Opc_documento { get; set; }
			public int _Doc_numero { get; set; }

			public string _Doc_sucursal { get; set; }
			public DateTime _Doc_fecha { get; set; }
			//public double _Doc_porceniva { get; set; }
			public double _Doc_valoriva { get; set; }
			public double _Doc_totciva { get; set; }
			public double _Doc_totsiva { get; set; }
			public double _subtotal { get; set; }
			public double _totalDescuento { get; set; }
			public double _Doc_valor { get; set; }
			public string _Doc_NombreImp { get; set; }
			public string _Doc_NumSop { get; set; }
			public string _doc_detalle { get; set; }
			public string _tipEmision { get; set; }
			public DateTime? _fechaAutorizacion { get; set; }
			public string _NroAutorizacionSri { get; set; }
			public string _guiaRemision { get; set; }
			public string _PreEntrada { get; set; }
			public int _Idclavedoc { get; set; }
			public string _tipAmbiente { get; set; }
			public string _Doc_CiRuc { get; set; }
			public string _Doc_Direccion { get; set; }
			public string _Doc_Telefono1 { get; set; }
			public string _Doc_NroIdDoc { get; set; }
			public string _Adi_TipoDocSri { get; set; }
			public string _claveAcceso { get; set; }
			public string _TipoIdentificacion { get; set; }
			public string _CorreoElectrónico { get; set; }
			public string _NroCtrbuyteEspecial { get; set; }
			public string _ObligLlevarConta { get; set; }
			public string _Tra_NroLote { get; set; }
			public string _AuxVar1 { get; set; }
			public string _Pag_Descripcion { get; set; }
			public string _Pag_Cuotas { get; set; }
			public string _Pag_Autoriza { get; set; }

			public double _totDescUnitario { get; set; }
			public double _Base5 { get; set; }
			public double _Base15 { get; set; }
			public double _Iva5 { get; set; }
			public double _Iva15 { get; set; }
			public List<DetalleCpbtFac> Detalles { get; set; }
		}

		public class DetalleCpbtFac
		{
			public string _Tra_Codigo { get; set; }
			public decimal _Tra_cantidad { get; set; }
			public string _Tra_nombre { get; set; }
			public decimal _Tra_precuni { get; set; }
			public decimal _desctoUni { get; set; }
			public decimal _Tra_prectot { get; set; }
			public decimal _Tra_porcendes { get; set; }
		}


		private void btnPagos_Click(object sender, EventArgs e)
		{
			string pagoPredefinido = "";
			if (clasePagos.pagosDelDocumento.Count == 0)
			{
				pagoPredefinido = registrarFormaDePagoPredefinida();
				crearPagoPredefinido(pagoPredefinido);
			}
			MntPago PagosDoc = new MntPago();
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
		//	string bod = "";
		//	if (cmbBodega.SelectedValue != null) {bod = cmbBodega.SelectedValue.ToString(); } else { bod = datosEmpresa.Bodega; }
			txtfecha.Value = docUtils.DaxNow();
			ClassDoc.controlNumeracion cnum = new controlNumeracion();
			txtnumero.Text = cnum.NumeroMayor(idDocumentoActual, "", "", "", datosEmpresa.strConxAdcom).ToString();
			operacionEnCurso = 1;
			prepararBotones();
		}

		
		private void btnDescuentos_Click(object sender, EventArgs e)
		{            
            adcDescto.ingDescDoc ingdesc = new adcDescto.ingDescDoc();
			ingdesc.ingresarDescuentos(ref claseDescuentos, datosEmpresa.strConxAdcom, datosEmpresa.suc, valoresPredefinidosEmpresa.nroDescuentosMaximosDocto);
			ingdesc.Dispose();
			totalizar();
		}

		//private void btnRegistra_Click(object sender, EventArgs e)
		//{
		//	if (validarDocumento() == true)
		//	{
		//		if (grabarDocumento() == true)
		//		{
		//			EnviarAimpresora.imprimirDocumentoDirectamente(datADCDOC, accesosLocalizados, idDocumentoActual);
		//			//if (ConfiguracionCorreo.ParametroCargado && ConfiguracionCorreo.parametro == 1)
		//			if (ConfiguracionCorreo.parametro == 1)
		//			{
		//				urlE = ConfiguracionCorreo.UrlSRI; // Aquí obtienes la URL desde la BD
		//				solicitarAutorizacionSRI(urlE);
		//			}

		//			limpiarDatos();
		//		}
		//	}
		//}

		private void btnRegistra_Click(object sender, EventArgs e)
		{
			if (validarDocumento() == true)
			{
				if (grabarDocumento() == true)
				{
					if (ConfiguracionCorreo.ParametroCargado && ConfiguracionCorreo.parametro == 1)
					{
						urlE = ConfiguracionCorreo.UrlSRI;
						solicitarAutorizacionSRI(urlE, ref datADCDOC);
					}

					string tipoImpresion = propiedadesDoc.ObtenerTipoImpresion();
					bool impresionExitosa = false;

					// ✅ VERIFICAR SI ES IMPRESORA PDF
					string impresora = propiedadesDoc?.Impresora_1 ?? "";
					bool esImpresoraPDF = impresora.Contains("PDF") ||
										  impresora.Contains("Adobe") ||
										  impresora.Contains("Microsoft Print to PDF");

					if (esImpresoraPDF)
					{
						// ✅ Para .NET Framework 4 usamos BackgroundWorker
						using (BackgroundWorker bw = new BackgroundWorker())
						{
							bw.DoWork += (s, args) =>
							{
								try
								{
									switch (tipoImpresion)
									{
										case "TICKET":
											EnviarAimpresora.ImprimirTicket(datADCDOC, accesosLocalizados, idDocumentoActual, propiedadesDoc);
											break;
										default:
											EnviarAimpresora.imprimirDocumento(datADCDOC, accesosLocalizados, idDocumentoActual);
											break;
									}
								}
								catch (Exception ex)
								{
									// Guardar error para mostrarlo después
									args.Result = ex;
								}
							};

							bw.RunWorkerCompleted += (s, args) =>
							{
								if (args.Result is Exception ex)
								{
									MessageBox.Show($"Error en impresión en segundo plano: {ex.Message}",
										"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
								}
								else
								{
									MessageBox.Show("La impresión del ticket se está procesando en segundo plano.\n\n" +
										"Revise la carpeta de descargas o documentos para el archivo PDF generado.",
										"Imprimiendo...", MessageBoxButtons.OK, MessageBoxIcon.Information);
								}
							};

							bw.RunWorkerAsync();
							impresionExitosa = true;
						}
					}
					else
					{
						// Impresión normal (impresora física)
						switch (tipoImpresion)
						{
							case "RIDE":
								impresionExitosa = EnviarAimpresora.imprimirDocumentoDirectamenteOtros(datADCDOC, accesosLocalizados, idDocumentoActual);
								break;

							case "TICKET":
								impresionExitosa = EnviarAimpresora.ImprimirTicket(datADCDOC, accesosLocalizados, idDocumentoActual, propiedadesDoc);
								break;

							case "SISTEMA":
							default:
								impresionExitosa = EnviarAimpresora.imprimirDocumento(datADCDOC, accesosLocalizados, idDocumentoActual);
								break;
						}
					}

					if (impresionExitosa && !esImpresoraPDF)
					{
						limpiarDatos();
					}
					else if (!impresionExitosa && !esImpresoraPDF)
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
		private void txtRecibido_TextChanged(object sender, EventArgs e)
		{
			try
			{
				decimal cambio = Convert.ToDecimal(txtRecibido.Text) - Convert.ToDecimal(edTotal.Text);
				if (cambio < 0)
				{
					txtCambio.BackColor = System.Drawing.Color.Red;
					labCambio.Text = "FALTA";
				}
				else
				{
					txtCambio.BackColor = System.Drawing.Color.White;
					labCambio.Text = "CAMBIO";
				}
				txtCambio.Text = cambio.ToString();

			}
			catch { txtCambio.Text = ""; }
		}


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
			impresionVerificacion.verificarExistenciaDocumento(ref idDocumentoActual, datosEmpresa.strConxAdcom,false, "ADCDOC", txtNroID.Text);
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
				DaxMallaLib.Documentos.MoverCelda(malla,false);
				return true;
			}
			return false;
		}

		//private void moverCeldaMalla(DataGridViewCell cell)
		//{
		//	Int32 columnIndex = cell.ColumnIndex;
		//	Int32 rowIndex = cell.RowIndex;
		//	Int32 col = columnIndex;
		//	Int32 row = rowIndex;
		//	Int32 colOk = 0;


		//	if (col < malla.Columns.Count)
		//	{
		//		for (int i = col + 1; i < malla.Columns.Count - 1; i++)
		//		{
		//			if (malla.Columns[i].Visible == true && malla.Columns[i].ReadOnly == false && malla.Columns[i].Name.ToUpper() != "DESCRIPCIÓN") { colOk = i; break; }
		//		}
		//	}

		//	if (colOk == 0)
		//	{
		//		col = 1;
		//		if (row == malla.Rows.Count - 1)
		//		{
		//			dtDetalleDocumento.Rows.InsertAt(dtDetalleDocumento.NewRow(), malla.Rows.Count);
		//			row = malla.Rows.Count - 1;
		//		}
		//		else
		//		{
		//			row++;
		//		}
		//	}
		//	else
		//	{
		//		col = colOk;
		//	}
		//	malla.CurrentCell = malla.Rows[row].Cells[col];
		//}

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
					case "TRA_PRECUNI":
						if (keyData >= Keys.F2 && keyData <= Keys.F6)
						{
							DataGridViewRow row = malla.CurrentRow;
							DtosMall.docMallaArticulo preVta = new docMallaArticulo();
							Int32 quePrecio = 0;
							cell.Value = cargarPrecios.CargarPrecioVta(Convert.ToInt16(keyData), malla.CurrentRow.Cells["tra_Codigo"].Value.ToString(), claseImpuestos.impstoPorcentaje1, ref quePrecio, "", row.Cells["tra_Medida"].Value.ToString(), "", valoresPredefinidosEmpresa.nroDigitosEnPrecios);
							//	totalizar();
						}
						break;
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

		private void crearPagoPredefinido(string IdPago)
		{
			if (IdPago == "") IdPago = "EFE";
			clasePagos.DocValor = Convert.ToDouble(edTotal.Text);
			clasePagos.DocFecha = txtfecha.Value;
			clasePagos.DocNumero = Convert.ToDouble(txtnumero.Text);
			clasePagos.DocSucursal = datosEmpresa.suc;
			clasePagos.Doctipo = cmbDocumento.SelectedValue.ToString();
			clasePagos.pagosDelDocumento.Add( DaxComercia.utility.CrearPagoDocumento (IdPago, clasePagos.DocValor));
		}
		
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
			//utilDoc.cadenaConexion = datosEmpresa.strConxAdcom;
			//datADCDOC = new AdcDoc(datosEmpresa.strConxAdcom);
			//string tabladoc = "";
			//string tablatra = "";
			//string tablapagos = "ADCPAG";
			//utilDoc.tablasDeDatos(idDocCopiar.Tipo, ref tabladoc, ref tablatra);
			//string Ssql = "doc_sucursal = '" + idDocCopiar.Sucursal + "' and opc_documento ='" + idDocCopiar.Tipo + "' and idclavedoc = " + idDocCopiar.idClave.ToString();

			//if (tabladoc.ToUpper() == "ADCDOC")
			//{
			//	datADCDOC = AdcDoc.Buscar(Ssql);
			//}
			//else
			//{
			//	tablapagos = "ADCPAGPRO";
			//	DataTable dt = utilBasDatos.utilBasDatos.leerTablas("select * from adcDOCpro where " + Ssql, datosEmpresa.strConxAdcom);

			//	if (dt.Rows.Count > 0) { DataRow DROW = dt.Rows[0]; datADCDOC = AdcDoc.row2AdcDoc(DROW); }
			//}
			//if (datADCDOC != null)
			//{
			//	datADCDOC.IdClaveDoc = 0;
			//	datADCDOC.Doc_numero = Convert.ToDecimal(txtnumero.Text);

		 ////       this.malla.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.malla_CellValueChanged);
			//	if (esGenerar == false)
			//	{
			//		if (MessageBox.Show("Desea copiar la cabezera del documento ? ", "Copiar datos documento", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
			//		{
			//			cargarDatosCliente(datADCDOC.Doc_codper);
			//			moverCabezera();
			//		}
			//	}
			//	else
			//	{
			//		cargarDatosCliente(datADCDOC.Doc_codper);
			//		moverCabezera();
			//	}
			//	moverOtrosValores();
			//	cargarDetalleArticulos(idDocCopiar.Sucursal, idDocCopiar.Tipo, idDocCopiar.idClave, tablatra);
			//	cargarFormaDePago(idDocCopiar, tablapagos);
			//	LlenarIdDocumento(ref idDocumentoActual);
			//	idDocumentoActual.idClave = 0;
			//	//inicializarUtilidadDocumentos();
			//	totalizar();
			//	prepararBotones();
			// //   this.malla.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.malla_CellValueChanged);
			//}
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
			//MessageBox.Show("Error de dato digitado, el valor registrado es inválido");
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
					if ( clasref.LeerDocumentoReferencial(datosEmpresa.suc, cmbDocumentoSustento.SelectedValue.ToString(), nroDocSoporte.Text, idDocumentoActual) == false)
					{ clasref = null; mensajesErrorDocumento.SinDocumentoReferencia(); return false; }
				}
			}
			if (ValidacionDocumentos.ValidacionGeneral.validarIngresoDetalle(malla) == false) { mensajesErrorDocumento.sinArtículosOservicios(); return false; }

			if (ValidacionDocumentos.ValidacionGeneral.ControlValidacionFacCli(ref malla, ref propiedadesDoc, clasref, txtfecha.Text, datosEmpresa.suc, datosEmpresa.strConxAdcom, datosEmpresa.strConxSyscod, idDocumentoActual.idClave, cmbBodega.SelectedValue.ToString(), txtnumero.Text, entregasPendientes, datosEmpresa.suc, docsustento, "") == false) return false;
			if (verificarFormaDePago() == false) {return false; }
			moverDatosClase();

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

					ClaveElectronica.actualizarClaveElectronica(datADCDOC);

					AuditSis.registrar.registraEventoDoc(datosEmpresa.strConxAdcom, datosEmpresa.codEmpresa.ToString(), datosEmpresa.usr, datosEmpresa.sistema, Environment.MachineName, AuditSis.registrar.EvntCrear, idDocumentoActual.Sucursal, idDocumentoActual.Tipo, idDocumentoActual.numero.ToString(), datADCDOC.Doc_valor.ToString());
                }
                else
                {
                    res = datADCDOC.Actualizar();
                    if (res.Substring(0, 3) != "ERR") { grabarAdctra(); }
                    actualizaDatosPagos();
					clasePagos.guardarPagosDocumento("ADCPAG");
					AuditSis.registrar.registraEventoDoc(datosEmpresa.strConxAdcom, datosEmpresa.codEmpresa.ToString(), datosEmpresa.usr, datosEmpresa.sistema, Environment.MachineName, AuditSis.registrar.EvntModifica, idDocumentoActual.Sucursal, idDocumentoActual.Tipo, idDocumentoActual.numero.ToString(), datADCDOC.Doc_valor.ToString());
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

			MntPago dp = new MntPago();
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
            if (malla.Rows.Count < 1) return;
//			this.malla.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.malla_CellValueChanged);
			if (claseImpuestos.cambiadoManual == false)
			{
				if (claseImpuestos.impstoPorcentaje1 == 0 || claseImpuestos.impstoFechaIni1 > txtfecha.Value || claseImpuestos.impstoFechaFin1 < txtfecha.Value) claseImpuestos.cargar(datosEmpresa.strConxIvaret , txtfecha.Value);
			}
			totalesDocumento = new DctosEmi.docTotals();
			edTotal.Text = Convert.ToString(totalesDocumento.totalizar(malla, Convert.ToDecimal(claseImpuestos.impstoPorcentaje1), claseDescuentos, clasePagos,propiedadesDoc, valoresPredefinidosEmpresa.nroDigitosEnPrecios , valoresPredefinidosEmpresa.nroDigitosEnCostos ));
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
			labTotPorcIva.Text = (claseImpuestos.impstoPorcentaje1 * 100).ToString() + "% IVA";
			labTotSubConIva.Text = totalesDocumento.Subtotalciva.ToString(formato);
			labTotSubSinIva.Text = totalesDocumento.SubTotalSIva.ToString(formato);
			labTotVtaConIva.Text = totalesDocumento.TotCiva.ToString(formato);
			labTotVtaSinIva.Text = totalesDocumento.TotSiva.ToString(formato);
			labTotalDescuento.Text = totalesDocumento.TotDescuentos.ToString(formato);
			labTotalVenta.Text = (totalesDocumento.TotCiva + totalesDocumento.TotSiva).ToString(formato);
			labSubtotal.Text = (totalesDocumento.Subtotalciva + totalesDocumento.SubTotalSIva ) .ToString(formato);
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
			claseImpuestos.impstoPorcentaje1 = Convert.ToDouble("0" + nvoIva);
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

		private void registraOpciones()
		{
			AuditSis.registrar.registraPreferencia(datosEmpresa.strConxAdcom, datosEmpresa.codEmpresa.ToString(),Environment.MachineName, datosEmpresa.usr, datosEmpresa.sistema, datosEmpresa.suc, "Facturacion", "TipoDoc", cmbDocumento.SelectedValue.ToString());
			AuditSis.registrar.registraPreferencia(datosEmpresa.strConxAdcom, datosEmpresa.codEmpresa.ToString(),Environment.MachineName, datosEmpresa.usr, datosEmpresa.sistema, datosEmpresa.suc, "Facturacion", "Bodega", cmbBodega.SelectedValue.ToString());
			if (cmbVendedor.SelectedValue != null ) AuditSis.registrar.registraPreferencia(datosEmpresa.strConxAdcom, datosEmpresa.codEmpresa.ToString(),Environment.MachineName, datosEmpresa.usr, datosEmpresa.sistema, datosEmpresa.suc, "Facturacion", "Vendedor", cmbVendedor.SelectedValue.ToString());
		}
		private void recordarOpciones()
		{
		   memTipoDoc = AuditSis.registrar.obtenerPreferencia (datosEmpresa.strConxAdcom, datosEmpresa.codEmpresa.ToString(), datosEmpresa.usr, datosEmpresa.sistema, datosEmpresa.suc, "Facturacion", "TipoDoc");
			//memBodega = AuditSis.registrar.obtenerPreferencia(datosEmpresa.strConxSyscod, datosEmpresa.codEmpresa.ToString(), datosEmpresa.usr, datosEmpresa.sistema, datosEmpresa.suc, "Facturacion", "Bodega");
			memVendedor = AuditSis.registrar.obtenerPreferencia(datosEmpresa.strConxAdcom, datosEmpresa.codEmpresa.ToString(), datosEmpresa.usr, datosEmpresa.sistema, datosEmpresa.suc, "Facturacion", "Vendedor");
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

        }

        private void btnAgrupa_Click(object sender, EventArgs e)
        {

        }

		private void malla_CurrentCellDirtyStateChanged(object sender, EventArgs e)
		{
			if (malla.IsCurrentCellDirty)
			{
				// Forzar commit del valor editado cuando el usuario hace clic fuera de la celda
				malla.CommitEdit(DataGridViewDataErrorContexts.Commit);
			}
		}
	}
}