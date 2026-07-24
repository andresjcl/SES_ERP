using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DtosMall;
using DaxComercia;
using classMenSistem;
using ctrlReferencia;
using ClassDoc;
using System.Drawing;
using DattCom;
using DaxInvent;
using adcArticulo;
using ImpresionDoc;

namespace DctosEmi
{
	public partial class FormDocInventario : Form
	{
        DatosDocFacturacion DatosFacturacion = new DatosDocFacturacion();
        internal sesSys.OpcDoc propiedadesDoc;
		directMnt.DirectorioAlex opalex = new directMnt.DirectorioAlex();
		internal AdcDoc datADCDOC;
		internal DaxComercia.classPagosDoc clasePagos = new DaxComercia.classPagosDoc();
		internal adcDescto.descDocumento claseDescuentos = new adcDescto.descDocumento();
		//		internal IvaRett.docImpuestos claseImpuestos = new IvaRett.docImpuestos();
		internal daxAccs.propiedadesDaxAuto accesosLocalizados = new daxAccs.propiedadesDaxAuto();

		ctrlReferencia.controlReferencial clasref = new controlReferencial();
		DataTable dtDetalleDocumento = new DataTable();

		internal DctosEmi.docTotals totalesDocumento = new DctosEmi.docTotals();
        daxContaDoc.AsientosContables asientosContables = new daxContaDoc.AsientosContables();
        string claseDocDefault = "EBGIBGAJIAJE";
		string tipoDocDefault = "EBGIBGAJIAJE";

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

		string memTipoDoc = "";
		//string memVendedor = "";
		string memBodega = "";
		decimal ivaM = 0;
		public FormDocInventario(string clasdef, string tipdef, bool nuevo = false, Boolean esConsulta = false, Boolean generarFactura = false, Boolean desdeEstdoCta = false, idDocumento idDocViene = null, string sisMedico = "")
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
		//private void CargarPredefinidosDocumento()
		//{
		//	propiedadesDoc = new sesSys.OpcDoc();
		//	propiedadesDoc.Cargar(ref idDocumentoActual.Tipo, ref idDocumentoActual.Sucursal);
		//	accesosLocalizados.iniciar(datosEmpresa.codEmpresa, datosEmpresa.usr, datosEmpresa.strConxSyscod);
		//	accesosLocalizados.cargarAccesoDoc(idDocumentoActual.Tipo);
			
		//	AutorizacionesFac.HabilitarOpcionesDocumento(this);

		//	//HabilitarOpcionesDocumento();
		//}


		private void CargarPredefinidosDocumento()
		{
			propiedadesDoc = new sesSys.OpcDoc();
			propiedadesDoc.Cargar(ref idDocumentoActual.Tipo, ref idDocumentoActual.Sucursal);

			// ✅ RECARGAR ACCESOS LOCALIZADOS
			accesosLocalizados = new daxAccs.propiedadesDaxAuto();
			accesosLocalizados.iniciar(datosEmpresa.codEmpresa, datosEmpresa.usr, datosEmpresa.strConxSyscod);
			accesosLocalizados.cargarAccesoDoc(idDocumentoActual.Tipo);

			AutorizacionesFac.HabilitarOpcionesDocumento(this);

			// ✅ ACTUALIZAR BOTONES
			prepararBotones();
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
			//try
			//{
			//	docAnulado = (datADCDOC.Doc_Estado == 0 && modificando);
			//}
			//catch { }

			try
			{
				if (datADCDOC != null)
				{
					docAnulado = (datADCDOC.Doc_Estado == 0 && modificando);
				}
			}
			catch { }

			btnAbre.Enabled = inicio;
			btnNuevo.Enabled = inicio;

			btnCopia.Enabled = nuevo;

			btnAnula.Enabled = (modificando && !docAnulado);
			btnElimina.Enabled = modificando;
			btnEnviar.Enabled  = modificando;
			btnGraba.Enabled = (!inicio && !docAnulado);
			btnRegistra.Enabled = btnGraba.Enabled;
			btnEnviar.Enabled = (modificando && !docAnulado);
			btnCierra.Enabled = !inicio;
			btnConsolida.Enabled = nuevo;

			//btnPagos.Enabled = btnGraba.Enabled;
			//btnDescuentos.Enabled = btnGraba.Enabled;
			//ptoVenta.Enabled = inicio;
			//btnPorcentajeIva.Enabled = btnDescuentos.Enabled;
			//btnContabiliza.Enabled = btnGraba.Enabled;
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
					//txtdireccion.Text = opalex.direccion;
					//txtCorreElectronico.Text = opalex.correoElectronico;
					//txttelefono.Text = opalex.telefono1;
				}
			}
			if (codigo == "")
			{
				codCliente = "";
				txtcedula.Text = "";
				txtnombrecliente.Text = "";
				//txtdireccion.Text = "";
				//txtCorreElectronico.Text = "";
				//txttelefono.Text = "";
				opalex = null;
			}
//			debeActualizarContacto = false;
		}

		//private Boolean cargarDatosDocumento(string SUC, string TIPO, double IDCLAVE, double NUMERO = 0)
		//{
		//	Boolean resp = false;
		//	if (IDCLAVE != 0)
		//	{
		//		// ✅ ACTUALIZAR ID DEL DOCUMENTO
		//		idDocumentoActual.Tipo = TIPO;
		//		idDocumentoActual.Sucursal = SUC;
		//		idDocumentoActual.idClave = IDCLAVE;

		//		// ✅ FORZAR RECARGA DE PROPIEDADES
		//		propiedadesDoc = new sesSys.OpcDoc();
		//		propiedadesDoc.Cargar(ref idDocumentoActual.Tipo, ref idDocumentoActual.Sucursal);

		//		// ✅ SELECCIONAR EL DOCUMENTO EN EL COMBOBOX
		//		try { cmbDocumento.SelectedValue = TIPO; } catch { }

		//		datADCDOC = new AdcDoc(datosEmpresa.strConxAdcom);
		//		datADCDOC = AdcDoc.Buscar(" doc_sucursal = '" + SUC + "' and opc_documento ='" + TIPO + "' and idclavedoc = " + IDCLAVE.ToString());

		//		if (datADCDOC != null)
		//		{
		//			cargarDatosCliente(datADCDOC.Doc_codper);
		//			moverClaseAcontroles();
		//			if (Convert.ToInt32(datADCDOC.Doc_Estado) == 0) mensajesDocumento.Text = "DOCUMENTO ANULADO : " + datADCDOC.MotivoAnulacion;
		//			cargarDetalleArticulos(idDocumentoActual.Sucursal, idDocumentoActual.Tipo, idDocumentoActual.idClave, "ADCTRA");
		//			totalizar();
		//			operacionEnCurso = modificandoRegistro;
		//			prepararBotones();
		//			resp = true;
		//			txtnumero.Enabled = false;
		//		}
		//	}
		//	return resp;
		//}

		private Boolean cargarDatosDocumento(string SUC, string TIPO, double IDCLAVE, double NUMERO = 0)
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
					if (Convert.ToInt32(datADCDOC.Doc_Estado) == 0)
						mensajesDocumento.Text = "DOCUMENTO ANULADO : " + datADCDOC.MotivoAnulacion;

					cargarDetalleArticulos(idDocumentoActual.Sucursal, idDocumentoActual.Tipo, idDocumentoActual.idClave, "ADCTRA");

					// ✅ CALCULAR COSTOS PARA TODOS LOS PRODUCTOS
					CalcularCostosParaTodaLaMalla();

					totalizar();
					operacionEnCurso = modificandoRegistro;
					prepararBotones();
					resp = true;
					txtnumero.Enabled = false;
				}
			}
			return resp;
		}

		private void cargarDetalleArticulos(string suc, string tip, double idClave, string tablatra)
		{
			DatosDocFacturacion dcut = new DatosDocFacturacion();
			ModelaMalla dcut2 = new ModelaMalla();

			dtDetalleDocumento = utilBasDatos.utilBasDatos.leerTablas(
				dcut.armarSqlLecturaTransInventario(tablatra, suc, tip, idClave),
				datosEmpresa.strConxAdcom);

			if (dtDetalleDocumento == null) return;

			malla.DataSource = dtDetalleDocumento;
			dcut2.diseñarMallaInventario(ref malla, ref propiedadesDoc, accesosLocalizados);

			// ✅ CALCULAR COSTOS PARA TODOS LOS PRODUCTOS
			CalcularCostosParaTodaLaMalla();

			// ✅ LIMPIAR FECHAS VACÍAS
			LimpiarDatosMalla();

			// ✅ RECALCULAR TOTALES
			totalizar();

			if (malla.Columns.Contains("Existencia"))
				malla.Columns["Existencia"].Visible = valoresPredefinidosEmpresa.existenciaEnLineas;
		}

		private void CalcularCostosParaTodaLaMalla()
		{
			if (malla.Rows.Count == 0) return;

			foreach (DataGridViewRow row in malla.Rows)
			{
				if (row.IsNewRow) continue;

				// Verificar que tenga código
				if (row.Cells["tra_Codigo"]?.Value == null ||
					row.Cells["tra_Codigo"].Value == DBNull.Value ||
					string.IsNullOrEmpty(row.Cells["tra_Codigo"].Value.ToString()))
					continue;

				string codigo = row.Cells["tra_Codigo"].Value.ToString().Trim();
				if (string.IsNullOrEmpty(codigo) || codigo == ".")
					continue;

				// ✅ OBTENER COSTO PROMEDIO DESDE AdcArt
				decimal costoPromedio = 0;
				try
				{
					// Buscar el artículo en la base de datos
					AdcArt opArt = new adcArticulo.AdcArt(datosEmpresa.strConxAdcom);
					opArt = adcArticulo.AdcArt.Buscar(" art_codigo = '" + codigo + "' ");

					if (opArt != null)
					{
						// Obtener el costo de compra del artículo
						costoPromedio = Convert.ToDecimal(opArt.Art_costucom);

						// Si el costo de compra es 0, intentar con otro método
						if (costoPromedio == 0)
						{
							// Intentar obtener el último costo de compra
							try
							{
								// Usar el método que ya tienes en tu código
								costoPromedio = Convert.ToDecimal(
									ultimosValor.UltimoCostoCompra("", "", codigo, false, "", "",
									Convert.ToDateTime(txtfecha.Text),
									datosEmpresa.strConxAdcom,
									datosEmpresa.strConxSyscod)
								);
							}
							catch { }
						}

						// Si aún es 0, usar Art_precvta1 como referencia
						if (costoPromedio == 0)
						{
							costoPromedio = Convert.ToDecimal(opArt.Art_precvta1);
						}
					}
				}
				catch (Exception ex)
				{
					// Si hay error, intentar con el método alternativo
					try
					{
						costoPromedio = Convert.ToDecimal(
							ultimosValor.UltimoCostoCompra("", "", codigo, false, "", "",
							Convert.ToDateTime(txtfecha.Text),
							datosEmpresa.strConxAdcom,
							datosEmpresa.strConxSyscod)
						);
					}
					catch { costoPromedio = 0; }
				}

				// ✅ OBTENER CANTIDAD
				decimal cantidad = 1;
				if (row.Cells["tra_Cantidad"]?.Value != null && row.Cells["tra_Cantidad"].Value != DBNull.Value)
					decimal.TryParse(row.Cells["tra_Cantidad"].Value.ToString(), out cantidad);

				if (cantidad <= 0) cantidad = 1;

				// ✅ ASIGNAR COSTO UNITARIO (Tra_costuni)
				if (malla.Columns.Contains("Tra_costuni"))
				{
					if (row.Cells["Tra_costuni"]?.Value == null ||
						row.Cells["Tra_costuni"].Value == DBNull.Value ||
						Convert.ToDecimal(row.Cells["Tra_costuni"].Value) == 0)
					{
						row.Cells["Tra_costuni"].Value = Math.Round(costoPromedio, 4);
					}
				}

				// ✅ ASIGNAR COSTO TOTAL (Tra_costtot)
				if (malla.Columns.Contains("Tra_costtot"))
				{
					if (row.Cells["Tra_costtot"]?.Value == null ||
						row.Cells["Tra_costtot"].Value == DBNull.Value ||
						Convert.ToDecimal(row.Cells["Tra_costtot"].Value) == 0)
					{
						row.Cells["Tra_costtot"].Value = Math.Round(costoPromedio * cantidad, 2);
					}
				}

				// ✅ ASIGNAR PRECIO UNITARIO (Tra_precuni) - COLUMNA VISIBLE
				if (malla.Columns.Contains("Tra_precuni"))
				{
					if (row.Cells["Tra_precuni"]?.Value == null ||
						row.Cells["Tra_precuni"].Value == DBNull.Value ||
						Convert.ToDecimal(row.Cells["Tra_precuni"].Value) == 0)
					{
						row.Cells["Tra_precuni"].Value = Math.Round(costoPromedio, 4);
					}
				}

				// ✅ ASIGNAR PRECIO TOTAL (Tra_prectot)
				if (malla.Columns.Contains("Tra_prectot"))
				{
					if (row.Cells["Tra_prectot"]?.Value == null ||
						row.Cells["Tra_prectot"].Value == DBNull.Value ||
						Convert.ToDecimal(row.Cells["Tra_prectot"].Value) == 0)
					{
						row.Cells["Tra_prectot"].Value = Math.Round(costoPromedio * cantidad, 2);
					}
				}
			}
		}

		private void LimpiarDatosMalla()
		{
			if (malla.Rows.Count == 0) return;

			foreach (DataGridViewRow row in malla.Rows)
			{
				if (row.IsNewRow) continue;

				// ✅ 1. LIMPIAR FECHA DE CADUCIDAD
				if (malla.Columns.Contains("Tra_vence"))
				{
					if (row.Cells["Tra_vence"]?.Value != null && row.Cells["Tra_vence"].Value != DBNull.Value)
					{
						DateTime fecha;
						if (DateTime.TryParse(row.Cells["Tra_vence"].Value.ToString(), out fecha))
						{
							// Si es 01/01/1900 o fecha mínima, dejarlo en blanco
							if (fecha.Year == 1900 && fecha.Month == 1 && fecha.Day == 1)
							{
								row.Cells["Tra_vence"].Value = DBNull.Value;
							}
						}
						else
						{
							row.Cells["Tra_vence"].Value = DBNull.Value;
						}
					}
				}

				// ✅ 2. LIMPIAR NRO LOTE SI ESTÁ VACÍO
				if (malla.Columns.Contains("tra_nrolote"))
				{
					if (row.Cells["tra_nrolote"]?.Value != null && row.Cells["tra_nrolote"].Value != DBNull.Value)
					{
						string lote = row.Cells["tra_nrolote"].Value.ToString().Trim();
						if (string.IsNullOrEmpty(lote) || lote == "0")
						{
							row.Cells["tra_nrolote"].Value = DBNull.Value;
						}
					}
				}

				// ✅ 3. LIMPIAR COSTO UNITARIO SI ES 0
				if (malla.Columns.Contains("Tra_costuni"))
				{
					if (row.Cells["Tra_costuni"]?.Value != null && row.Cells["Tra_costuni"].Value != DBNull.Value)
					{
						string valorStr = row.Cells["Tra_costuni"].Value.ToString().Trim();
						if (!string.IsNullOrEmpty(valorStr))
						{
							decimal valor;
							if (decimal.TryParse(valorStr, out valor))
							{
								if (valor == 0)
								{
									row.Cells["Tra_costuni"].Value = DBNull.Value;
								}
							}
						}
					}
				}

				// ✅ 4. LIMPIAR COSTO TOTAL SI ES 0
				if (malla.Columns.Contains("Tra_costtot"))
				{
					if (row.Cells["Tra_costtot"]?.Value != null && row.Cells["Tra_costtot"].Value != DBNull.Value)
					{
						string valorStr = row.Cells["Tra_costtot"].Value.ToString().Trim();
						if (!string.IsNullOrEmpty(valorStr))
						{
							decimal valor;
							if (decimal.TryParse(valorStr, out valor))
							{
								if (valor == 0)
								{
									row.Cells["Tra_costtot"].Value = DBNull.Value;
								}
							}
						}
					}
				}

				// ✅ 5. LIMPIAR PRECIO UNITARIO SI ES 0 (para documentos de inventario)
				if (malla.Columns.Contains("Tra_precuni"))
				{
					if (row.Cells["Tra_precuni"]?.Value != null && row.Cells["Tra_precuni"].Value != DBNull.Value)
					{
						string valorStr = row.Cells["Tra_precuni"].Value.ToString().Trim();
						if (!string.IsNullOrEmpty(valorStr))
						{
							decimal valor;
							if (decimal.TryParse(valorStr, out valor))
							{
								if (valor == 0)
								{
									row.Cells["Tra_precuni"].Value = DBNull.Value;
								}
							}
						}
					}
				}
			}
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

		
		private void moverClaseAcontroles()
		{
			moverCabezera();			
		}
		private void moverCabezera()
		{

			idDocumentoActual.idClave = Convert.ToDouble(datADCDOC.IdClaveDoc);
			codCliente = datADCDOC.Doc_codper;

			txtnumero.Text = datADCDOC.Doc_numero.ToString();
			//if (datADCDOC.Doc_NroIdDoc.ToString() != "") txtNroID.Text = datADCDOC.Doc_NroIdDoc.ToString();
			txtfecha.Text = datADCDOC.Doc_fecha.ToShortDateString();
			txtcedula.Text = datADCDOC.Doc_CiRuc;
			txtnombrecliente.Text = datADCDOC.Doc_NombreImp;
			//txtdireccion.Text = datADCDOC.Doc_Direccion;

			txtDetalle.Text = datADCDOC.Doc_detalle;
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
			txtcedula.Text = "";
			//txtCorreElectronico.Text = "";
			txtDetalle.Text = "";
			//txtdireccion.Text = "";
			txtnombrecliente.Text = "";
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
			prepararBotones();
		    InicializarMalla();
		}


		//private void InicializarMalla()
		//{
		//	DatosDocFacturacion dcut = new DatosDocFacturacion();
		//	ModelaMalla dcut2 = new ModelaMalla();

		//	dtDetalleDocumento = utilBasDatos.utilBasDatos.leerTablas(
		//		dcut.armarSqlLecturaTransInventario("ADCTRA", datosEmpresa.suc, idDocumentoActual.Tipo, 0),
		//		datosEmpresa.strConxAdcom);

		//	if (dtDetalleDocumento == null) return;

		//	malla.DataSource = dtDetalleDocumento;
		//	dtDetalleDocumento.Rows.Add(dtDetalleDocumento.NewRow());
		//	dcut2.diseñarMallaInventario(ref malla, ref propiedadesDoc);

		//	// ✅ LIMPIAR FECHAS VACÍAS
		//	LimpiarFechasVacias();
		//	CalcularCostosParaTodaLaMalla();

		//	dcut2 = null;
		//}

		private void InicializarMalla()
		{
			DatosDocFacturacion dcut = new DatosDocFacturacion();
			ModelaMalla dcut2 = new ModelaMalla();

			dtDetalleDocumento = utilBasDatos.utilBasDatos.leerTablas(
				dcut.armarSqlLecturaTransInventario("ADCTRA", datosEmpresa.suc, idDocumentoActual.Tipo, 0),
				datosEmpresa.strConxAdcom);

			if (dtDetalleDocumento == null) return;

			malla.DataSource = dtDetalleDocumento;
			dtDetalleDocumento.Rows.Add(dtDetalleDocumento.NewRow());
			dcut2.diseñarMallaInventario(ref malla, ref propiedadesDoc);

			// ✅ CALCULAR COSTOS PARA TODOS LOS PRODUCTOS
			CalcularCostosParaTodaLaMalla();

			// ✅ LIMPIAR FECHAS VACÍAS
			LimpiarDatosMalla();

			// ✅ TOTALIZAR
			totalizar();

			dcut2 = null;
		}


		private void LimpiarFechasVacias()
		{
			if (malla.Rows.Count == 0) return;

			foreach (DataGridViewRow row in malla.Rows)
			{
				if (row.IsNewRow) continue;

				// ✅ Limpiar fecha de caducidad
				if (malla.Columns.Contains("Tra_vence"))
				{
					if (row.Cells["Tra_vence"]?.Value != null && row.Cells["Tra_vence"].Value != DBNull.Value)
					{
						DateTime fecha;
						if (DateTime.TryParse(row.Cells["Tra_vence"].Value.ToString(), out fecha))
						{
							// Si es 01/01/1900, dejarlo en blanco
							if (fecha.Year == 1900 && fecha.Month == 1 && fecha.Day == 1)
							{
								row.Cells["Tra_vence"].Value = DBNull.Value;
							}
						}
						else
						{
							row.Cells["Tra_vence"].Value = DBNull.Value;
						}
					}
				}

				// ✅ Limpiar Nro Lote si está vacío
				if (malla.Columns.Contains("tra_nrolote"))
				{
					if (row.Cells["tra_nrolote"]?.Value != null && row.Cells["tra_nrolote"].Value != DBNull.Value)
					{
						string lote = row.Cells["tra_nrolote"].Value.ToString().Trim();
						if (string.IsNullOrEmpty(lote) || lote == "0")
						{
							row.Cells["tra_nrolote"].Value = DBNull.Value;
						}
					}
				}

				// ✅ Limpiar Costo Total si es 0 - CON MANEJO DE DBNull
				if (malla.Columns.Contains("Tra_costtot"))
				{
					if (row.Cells["Tra_costtot"]?.Value != null && row.Cells["Tra_costtot"].Value != DBNull.Value)
					{
						// ✅ Verificar que el valor sea un número válido antes de convertir
						string valorStr = row.Cells["Tra_costtot"].Value.ToString().Trim();
						if (!string.IsNullOrEmpty(valorStr))
						{
							decimal costoTotal;
							if (decimal.TryParse(valorStr, out costoTotal))
							{
								if (costoTotal == 0)
								{
									row.Cells["Tra_costtot"].Value = DBNull.Value;
								}
							}
						}
					}
				}
			}
		}

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
			progBus.IniciaBusqueda("", "", "", queFecha, ref SUC, ref TIP, ref Numero, ref Idclave, false, "", "", "", "ADCDOC");
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
			if (idDocumentoActual.idClave != 0) cargarDatosDocumento(idDocumentoActual.Sucursal, idDocumentoActual.Tipo, idDocumentoActual.idClave);
		}
		private void btnGraba_Click(object sender, EventArgs e)
		{
			if (validarDocumento() == true)
			{
				if (grabarDocumento() == true) { limpiarDatos(); }
			}

		}
		

		private void btnNuevo_Click(object sender, EventArgs e)
		{
			iniciarNuevoDocumento();
		}
		private void iniciarNuevoDocumento()
		{
			limpiarDatos();
			// ✅ ASEGURAR QUE datADCDOC ESTÉ INICIALIZADO
			if (datADCDOC == null)
				datADCDOC = new AdcDoc(datosEmpresa.strConxAdcom);

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
		//private void cmbDocumento_SelectedIndexChanged(object sender, EventArgs e)
		//{
		//	if (idDocumentoActual.Sucursal == "") return;
		//	if (idDocumentoActual.Tipo == cmbDocumento.SelectedValue.ToString()) return;
		//	idDocumentoActual.Tipo = cmbDocumento.SelectedValue.ToString();
		//	CargarPredefinidosDocumento();
		//	//llenarComboDocReferencia();
		//}

		private void cmbDocumento_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (idDocumentoActual.Sucursal == "") return;
			if (idDocumentoActual.Tipo == cmbDocumento.SelectedValue.ToString()) return;

			// ✅ ACTUALIZAR EL TIPO DE DOCUMENTO
			idDocumentoActual.Tipo = cmbDocumento.SelectedValue.ToString();

			// ✅ FORZAR RECARGA DE PROPIEDADES
			CargarPredefinidosDocumento();

			// ✅ SI EL DOCUMENTO ESTÁ EN MODO NUEVO, ACTUALIZAR EL NÚMERO
			if (operacionEnCurso == nuevoRegistro || operacionEnCurso == sinOperacion)
			{
				ClassDoc.controlNumeracion cnum = new controlNumeracion();
				txtnumero.Text = cnum.NumeroMayor(idDocumentoActual, "", "", "", datosEmpresa.strConxAdcom).ToString();
			}

			// ✅ ACTUALIZAR LA MALLA CON EL NUEVO TIPO DE DOCUMENTO
			if (operacionEnCurso == sinOperacion || operacionEnCurso == nuevoRegistro)
			{
				InicializarMalla();
			}

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
		//private void verificaNroDocumentoDigitado()
		//{
		//	LlenarIdDocumento(ref idDocumentoActual);
		//          //idDocumentoActual.numero = Convert.ToDouble(txtnumero.Text);
		//          impresionVerificacion.verificarExistenciaDocumento(ref idDocumentoActual, datosEmpresa.strConxAdcom,false, "ADCDOC");
		//	if (idDocumentoActual.idClave > 0) { cargarDatosDocumento(idDocumentoActual.Sucursal, idDocumentoActual.Tipo, idDocumentoActual.idClave);}
		//          else { MessageBox.Show("El documento digitado no existe");}
		//}

		private void verificaNroDocumentoDigitado()
		{
			// ✅ ACTUALIZAR EL TIPO DE DOCUMENTO DESDE EL COMBOBOX
			idDocumentoActual.Tipo = cmbDocumento.SelectedValue.ToString();
			idDocumentoActual.Sucursal = datosEmpresa.suc;

			LlenarIdDocumento(ref idDocumentoActual);

			// ✅ FORZAR RECARGA DE PROPIEDADES ANTES DE BUSCAR
			propiedadesDoc = new sesSys.OpcDoc();
			propiedadesDoc.Cargar(ref idDocumentoActual.Tipo, ref idDocumentoActual.Sucursal);

			impresionVerificacion.verificarExistenciaDocumento(ref idDocumentoActual, datosEmpresa.strConxAdcom, false, "ADCDOC");

			if (idDocumentoActual.idClave > 0)
			{
				cargarDatosDocumento(idDocumentoActual.Sucursal, idDocumentoActual.Tipo, idDocumentoActual.idClave);
			}
			else
			{
				MessageBox.Show("El documento digitado no existe");
			}
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
                    //        DtosMall.docMallaArticulo preVta = new docMallaArticulo();
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

			CtasCorrientes.frmAplicacionesDcto prog = new CtasCorrientes.frmAplicacionesDcto(datosEmpresa.strConxAdcom, idDocumentoActual.idClave, idDocumentoActual.Tipo, Convert.ToInt64(idDocumentoActual.numero), 0, txtfecha.Text, "", posicion, idDocumentoActual.Sucursal);
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
		private void consolidarDocumentos(idDocumento idDocCopiar)
		{
			datADCDOC = new AdcDoc(datosEmpresa.strConxAdcom);
			//string tablapagos = "ADCPAG";
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
				//moverOtrosValores();
				cargarDetalleArticulosConsolidacion(idDocCopiar.Lista);
				//cargarFormaDePago(idDocCopiar, tablapagos);
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

		//private Boolean validarDocumento()
		//{
		//	string docsustento = "";
		//	//DctosEmi.impresionVerificacion util = new DctosEmi.impresionVerificacion();
		//	if (Convert.ToDouble("0" + txtnumero.Text) == 0) { mensajesErrorDocumento.MensajeNumeroDoc(); txtnumero.Focus(); return false; }
		//	if (ValidacionDocumentos.ValidacionGeneral.validarFecha(txtfecha.Text, datosEmpresa.usr) == false) { return false; };
		//	if (opalex.codigo == "" || codCliente == "" || txtcedula.Text == "") { mensajesErrorDocumento.ElCodigoNoExiste("C"); return false; }

		//	if (propiedadesDoc.TipoSoporteObligatorio != "")
		//	{
		//		if (cmbDocumentoSustento.Text == "" || nroDocSoporte.Text == "")
		//		{
		//			mensajesErrorDocumento.SinDocumentoReferencia(); return false;
		//		}
		//		else
		//		{
		//			if (clasref.LeerDocumentoReferencial(datosEmpresa.suc, cmbDocumentoSustento.SelectedValue.ToString(), nroDocSoporte.Text, idDocumentoActual) == false)
		//			{ clasref = null; mensajesErrorDocumento.SinDocumentoReferencia(); return false; }
		//		}
		//	}
		//	if (ValidacionDocumentos.ValidacionGeneral.validarIngresoDetalle(malla) == false) { mensajesErrorDocumento.sinArtículosOservicios(); return false; }
		//	if (ValidacionDocumentos.ValidacionGeneral.ControlValidacionFacCli(ref malla, ref propiedadesDoc, clasref, txtfecha.Text, datosEmpresa.suc, datosEmpresa.strConxAdcom, datosEmpresa.strConxSyscod, idDocumentoActual.idClave, cmbBodega.SelectedValue.ToString(), txtnumero.Text, entregasPendientes, datosEmpresa.suc, docsustento, "") == false) return false;
		//	//if (verificarFormaDePago() == false) {return false; }
		//          DatosFacturacion.moverDatosAclase(this,datADCDOC);
		//	return true;
		//}

		private Boolean validarDocumento()
		{
			string docsustento = "";

			// ✅ FORZAR RECARGA DE PROPIEDADES DEL DOCUMENTO ACTUAL
			propiedadesDoc = new sesSys.OpcDoc();
			propiedadesDoc.Cargar(ref idDocumentoActual.Tipo, ref idDocumentoActual.Sucursal);

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

			DatosFacturacion.moverDatosAclase(this, datADCDOC);
			return true;
		}


		private Boolean grabarDocumento()
		{
            malla.EndEdit();
            Boolean RESP = true;

            string res = "";
           
            try
            {
				ForzarCalculoDeCostosAntesDeGrabar();
				// ✅ VERIFICAR QUE TODAS LAS FILAS TENGAN COSTOS
				VerificarCostosEnMalla();

				// ✅ FORZAR QUE LA MALLA TERMINE LA EDICIÓN
				malla.EndEdit();

				if (idDocumentoActual.idClave == 0)
                {                    
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

		private void ForzarCalculoDeCostosAntesDeGrabar()
		{
			if (malla.Rows.Count == 0) return;

			foreach (DataGridViewRow row in malla.Rows)
			{
				if (row.IsNewRow) continue;

				if (row.Cells["tra_Codigo"]?.Value == null ||
					row.Cells["tra_Codigo"].Value == DBNull.Value ||
					string.IsNullOrEmpty(row.Cells["tra_Codigo"].Value.ToString()))
					continue;

				string codigo = row.Cells["tra_Codigo"].Value.ToString().Trim();
				if (string.IsNullOrEmpty(codigo) || codigo == ".")
					continue;

				// ✅ OBTENER COSTO UNITARIO ACTUAL
				decimal costoUnitario = 0;
				if (row.Cells["Tra_costuni"]?.Value != null && row.Cells["Tra_costuni"].Value != DBNull.Value)
					decimal.TryParse(row.Cells["Tra_costuni"].Value.ToString(), out costoUnitario);

				// ✅ SI EL COSTO ES 0, BUSCARLO
				if (costoUnitario == 0)
				{
					try
					{
						AdcArt opArt = new adcArticulo.AdcArt(datosEmpresa.strConxAdcom);
						opArt = adcArticulo.AdcArt.Buscar(" art_codigo = '" + codigo + "' ");
						if (opArt != null)
						{
							costoUnitario = Convert.ToDecimal(opArt.Art_costucom);
							if (costoUnitario == 0)
								costoUnitario = Convert.ToDecimal(opArt.Art_precvta1);
						}
					}
					catch { costoUnitario = 0; }
				}

				// ✅ ASIGNAR COSTOS
				if (costoUnitario > 0)
				{
					decimal cantidad = 1;
					if (row.Cells["tra_Cantidad"]?.Value != null && row.Cells["tra_Cantidad"].Value != DBNull.Value)
						decimal.TryParse(row.Cells["tra_Cantidad"].Value.ToString(), out cantidad);

					if (row.Cells["Tra_costuni"] != null)
						row.Cells["Tra_costuni"].Value = Math.Round(costoUnitario, 4);

					if (row.Cells["Tra_costtot"] != null)
						row.Cells["Tra_costtot"].Value = Math.Round(costoUnitario * cantidad, 2);

					if (row.Cells["Tra_precuni"] != null)
						row.Cells["Tra_precuni"].Value = Math.Round(costoUnitario, 4);

					if (row.Cells["Tra_prectot"] != null)
						row.Cells["Tra_prectot"].Value = Math.Round(costoUnitario * cantidad, 2);
				}
			}
		}

		private void grabarAdctra()
		{
			grabMallTra.grabarMallaAdctra(malla, datADCDOC,datosEmpresa.strConxAdcom);
		}

		private void VerificarCostosEnMalla()
		{
			if (malla.Rows.Count == 0) return;

			foreach (DataGridViewRow row in malla.Rows)
			{
				if (row.IsNewRow) continue;

				// ✅ Verificar si tiene costo unitario
				if (malla.Columns.Contains("Tra_costuni"))
				{
					if (row.Cells["Tra_costuni"]?.Value == null || row.Cells["Tra_costuni"].Value == DBNull.Value)
					{
						// Si no tiene costo, calcularlo de Tra_precuni
						if (malla.Columns.Contains("Tra_precuni") && row.Cells["Tra_precuni"]?.Value != null)
						{
							decimal costo = 0;
							decimal.TryParse(row.Cells["Tra_precuni"].Value.ToString(), out costo);
							row.Cells["Tra_costuni"].Value = Math.Round(costo, 4);
						}
					}
				}

				// ✅ Verificar si tiene costo total
				if (malla.Columns.Contains("Tra_costtot"))
				{
					if (row.Cells["Tra_costtot"]?.Value == null || row.Cells["Tra_costtot"].Value == DBNull.Value)
					{
						// Si no tiene costo total, calcularlo de Tra_costuni * cantidad
						if (malla.Columns.Contains("Tra_costuni") && row.Cells["Tra_costuni"]?.Value != null)
						{
							decimal costoUnitario = 0;
							decimal.TryParse(row.Cells["Tra_costuni"].Value.ToString(), out costoUnitario);

							decimal cantidad = 0;
							if (row.Cells["Tra_cantidad"]?.Value != null)
								decimal.TryParse(row.Cells["Tra_cantidad"].Value.ToString(), out cantidad);

							row.Cells["Tra_costtot"].Value = Math.Round(costoUnitario * cantidad, 2);
						}
					}
				}
			}
		}

		private decimal ObtenerValorDecimal(DataGridViewRow row, string columna)
		{
			if (row == null) return 0;

			try
			{
				// Verificar que la columna existe en el DataGridView
				if (!malla.Columns.Contains(columna))
					return 0;

				// Obtener la celda
				DataGridViewCell cell = row.Cells[columna];
				if (cell == null || cell.Value == null)
					return 0;

				// Intentar convertir a decimal
				if (decimal.TryParse(cell.Value.ToString(), out decimal valor))
					return valor;
			}
			catch
			{
				// Ignorar errores
			}
			return 0;
		}

		private void totalizar()
		{
			if (malla.Rows.Count < 1) return;

			decimal total = 0;

			foreach (DataGridViewRow row in malla.Rows)
			{
				// Saltar la fila nueva (en blanco)
				if (row.IsNewRow) continue;

				// Verificar que la fila tenga código
				if (row.Cells["tra_Codigo"].Value == null ||
					row.Cells["tra_Codigo"].Value.ToString().Length == 0 ||
					row.Cells["tra_Codigo"].Value.ToString() == ".")
					continue;

				try
				{
					// Obtener cantidad - USAR row.Cells["nombre"] 
					decimal cantidad = 0;
					if (row.Cells["tra_Cantidad"].Value != null)
					{
						decimal.TryParse(row.Cells["tra_Cantidad"].Value.ToString(), out cantidad);
					}

					// Obtener costo unitario - USAR row.Cells["nombre"]
					decimal costoUnitario = 0;
					if (row.Cells["Tra_precuni"].Value != null)
					{
						decimal.TryParse(row.Cells["Tra_precuni"].Value.ToString(), out costoUnitario);
					}

					// Calcular total de línea
					decimal totalLinea = cantidad * costoUnitario;
					total += totalLinea;

					// Actualizar la columna de total de línea - USAR row.Cells["nombre"]
					if (row.Cells["Tra_prectot"] != null)
					{
						row.Cells["Tra_prectot"].Value = Math.Round(totalLinea, valoresPredefinidosEmpresa.nroDigitosEnPrecios);
					}
				}
				catch (Exception ex)
				{
					// Si hay error en la línea, la ignoramos
					continue;
				}
			}

			// Mostrar el total (SIN IVA)
			edTotal.Text = total.ToString("#,0.00");

			// Actualizar el documento si existe
			if (datADCDOC != null)
			{
				datADCDOC.Doc_valor = Convert.ToDecimal(total);
				datADCDOC.Doc_valoriva = 0;
				datADCDOC.Doc_totciva = 0;
				datADCDOC.Doc_totsiva = 0;
				datADCDOC.Doc_TotDesArt = 0;
				datADCDOC.Doc_TotDesSer = 0;
				datADCDOC.BaseImp1 = 0;
				datADCDOC.ValorImp1 = 0;
				datADCDOC.ValorImp2 = 0;
				datADCDOC.ValorImp3 = 0;
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
			AuditSis.registrar.registraPreferencia(datosEmpresa.strConxAdcom, datosEmpresa.codEmpresa.ToString(),Environment.MachineName, datosEmpresa.usr, datosEmpresa.sistema, datosEmpresa.suc, "Facturacion", "TipoDoc", cmbDocumento.SelectedValue.ToString());
			AuditSis.registrar.registraPreferencia(datosEmpresa.strConxAdcom, datosEmpresa.codEmpresa.ToString(),Environment.MachineName, datosEmpresa.usr, datosEmpresa.sistema, datosEmpresa.suc, "Facturacion", "Bodega", cmbBodega.SelectedValue.ToString());
			//if (cmbVendedor.SelectedValue != null ) AuditSis.registrar.registraPreferencia(datosEmpresa.strConxSyscod, datosEmpresa.codEmpresa.ToString(), datosEmpresa.usr, "ADX", datosEmpresa.suc, "Facturacion", "Vendedor", cmbVendedor.SelectedValue.ToString());
		}
		private void recordarOpciones()
		{
		   memTipoDoc = AuditSis.registrar.obtenerPreferencia (datosEmpresa.strConxAdcom, datosEmpresa.codEmpresa.ToString(), datosEmpresa.usr, datosEmpresa.sistema, datosEmpresa.suc, "Facturacion", "TipoDoc");
		   memBodega = AuditSis.registrar.obtenerPreferencia(datosEmpresa.strConxAdcom, datosEmpresa.codEmpresa.ToString(), datosEmpresa.usr, datosEmpresa.sistema, datosEmpresa.suc, "Facturacion", "Bodega");
		   //memVendedor = AuditSis.registrar.obtenerPreferencia(datosEmpresa.strConxSyscod, datosEmpresa.codEmpresa.ToString(), datosEmpresa.usr, "ADX", datosEmpresa.suc, "Facturacion", "Vendedor");
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

        private void btnPendientes_Click_1(object sender, EventArgs e)
        {
			DaxInvent.EntregasPendientesClienteProv prog = new  DaxInvent.EntregasPendientesClienteProv (datosEmpresa.strConxAdcom,"C",codCliente,txtnombrecliente.Text );
			prog.ShowDialog();
        }

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

        private void btnAgrupa_Click(object sender, EventArgs e)
        {
			if (malla.Rows.Count < 2) return;
			AgruparMalla docut = new AgruparMalla();
			docut.AcumularLineasMalla(malla, "tra_cantidad", "tra_codigo", "");
		}
    }
}