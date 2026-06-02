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
using IvaRett;

namespace DctosEmi
{
	public partial class FormFactProveedor : Form
	{
        DatosDocFacturacion DatosFacturacion = new DatosDocFacturacion();
        internal sesSys.OpcDoc propiedadesDoc;
		directMnt.DirectorioAlex opalex = new directMnt.DirectorioAlex();
		internal AdcDoc datADCDOC;
		internal DaxComercia.classPagosDoc clasePagos = new DaxComercia.classPagosDoc();
		internal adcDescto.descDocumento claseDescuentos = new adcDescto.descDocumento();
		internal docImpuestos claseImpuestos = new docImpuestos();
		internal daxAccs.propiedadesDaxAuto accesosLocalizados = new daxAccs.propiedadesDaxAuto();

		ctrlReferencia.controlReferencial clasref = new controlReferencial();
		DataTable dtDetalleDocumento = new DataTable();

		internal DctosEmi.docTotals totalesDocumento = new DctosEmi.docTotals();
        daxContaDoc.AsientosContables asientosContables = new daxContaDoc.AsientosContables();
        string claseDocDefault = "FAP";
		string tipoDocDefault = "FAP";
		decimal ivaM = 0;

		bool iniciaConNuevoDOc = false;
		internal Boolean esSoloConsulta = false;
		Boolean entregasPendientes = false;
		internal Boolean esDeLiquidacion = false;
		Boolean debeActualizarContacto = false;

		internal idDocumento idDocumentoActual = new idDocumento();
		internal idDocumento idDocumentoSoporte = new idDocumento();
		idDocumento idDocumentoParaGenerar = new idDocumento();

		internal string codProveedor = "";
		Boolean saltarEventoNumero = false;
		Boolean saltaEventosMalla = false;

		internal int operacionEnCurso = 0; // 0 sin operacion delcarada, 1 nuevo registro, 2 modificando registro
		internal int sinOperacion = 0;
		internal int nuevoRegistro = 1;
		internal int modificandoRegistro = 2;

		string memTipoDoc = "";
		string memVendedor = "";
		string memBodega = "";
		// ✅ AGREGAR ESTA VARIABLE
		private bool _esDesdeImportadorXml = false;
		private bool _esModoReGrabarImportado = false;
		public FormFactProveedor(string clasdef, string tipdef, bool nuevo = false, Boolean esConsulta = false, Boolean generarFactura = false, Boolean desdeEstdoCta = false, idDocumento idDocViene = null, string sisMedico = "", bool desdeImportadorXml = false)
		{
			InitializeComponent();
			// ✅ ALMACENAR SI VIENE DEL IMPORTADOR XML
			_esDesdeImportadorXml = desdeImportadorXml;

			// ✅ LOGICA PRINCIPAL: SI VIENE DEL IMPORTADOR XML, ES MODIFICACION
			if (_esDesdeImportadorXml && idDocViene != null && idDocViene.idClave > 0)
			{
				_esModoReGrabarImportado = true;
				esSoloConsulta = false;  // Forzar modo NO consulta para permitir modificación
				iniciaConNuevoDOc = false;
				idDocumentoActual = idDocViene;
				operacionEnCurso = modificandoRegistro;  // ✅ ESTABLECER COMO MODIFICACIÓN
			}
			else
			{
				esSoloConsulta = esConsulta;
				iniciaConNuevoDOc = nuevo;
			}


			if (clasdef.Length>0) claseDocDefault = clasdef;
			if (tipdef.Length > 0) tipoDocDefault = tipdef;
			CargarValoresIniciales();
			iniciaConNuevoDOc = nuevo;

			if (idDocViene == null) idDocViene = new idDocumento();
			if (idDocViene.idClave > 0 && esConsulta)
			{
				idDocumentoActual = idDocViene;
				//cmbDocumento.SelectedValue = idDocViene.Tipo;
				// ✅ SI VIENE DEL IMPORTADOR XML, PERMITIR MODIFICACIÓN

				// ✅ ESTABLECER COMO DOCUMENTO EXISTENTE(modificandoRegistro)
		// Esto hará que prepararBotones() habilite el botón Grabar
				operacionEnCurso = modificandoRegistro;

			}
			else if (idDocViene.idClave > 0 && generarFactura)
			{
				//MessageBox.Show("decision");
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
			//ptoVenta.Visible = valoresPredefinidosSucursal.autCambiaPtoVta;
			LlenarCombos();
			CargarPredefinidosDocumento();
			this.txtfecha.ValueChanged += new System.EventHandler(this.txtfecha_ValueChanged);
			this.Text += "  " + datosEmpresa.nomEmpresa + "  Sucursal: " + datosEmpresa.SucursalNombre ; //+ " PUNTO DE VENTA: " + valoresPredefinidosSucursal.nomPuntoVta;

			this.malla.CellFormatting += new DataGridViewCellFormattingEventHandler(malla_CellFormatting);
			this.malla.CellParsing += new DataGridViewCellParsingEventHandler(malla_CellParsing);

		}
		private void formFacPv_Load(object sender, EventArgs e)
		{

			// ✅ SI VIENE DEL IMPORTADOR XML, CARGAR DIRECTAMENTE EN MODO MODIFICACION
			if (_esDesdeImportadorXml && idDocumentoActual.idClave != 0)
			{
				try
				{
					cmbDocumento.SelectedValue = idDocumentoActual.Tipo;
				}
				catch
				{
					cmbDocumento.SelectedIndex = 0;
				}

				// Cargar los datos de la factura existente
				bool cargado = cargarDatosFactura(idDocumentoActual.Sucursal, idDocumentoActual.Tipo, idDocumentoActual.idClave);

				if (cargado)
				{
					// Configurar interfaz para modo re-grabar
					ConfigurarModoReGrabarImportado();
				}
			}
			else if (idDocumentoActual.idClave != 0)
			{
				// Código existente para otros casos...
				try
				{
					cmbDocumento.SelectedValue = idDocumentoActual.Tipo;
				}
				catch
				{
					cmbDocumento.SelectedIndex = 0;
				}
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
		}

		private void ConfigurarModoReGrabarImportado()
		{
			// Cambiar título del formulario
			this.Text = "Factura de Proveedor (Importada desde XML) - " + datosEmpresa.nomEmpresa;

			// Habilitar campos editables pero mantener algunos bloqueados
			txtnumero.Enabled = false;  // No cambiar número
			cmbDocumento.Enabled = false;  // No cambiar tipo
			txtcedula.Enabled = true;  // Permitir cambiar proveedor si es necesario

			// Asegurar que malla esté habilitada para edición
			malla.Enabled = true;
			malla.ReadOnly = false;
		}

		private void LlenarCombos()
		{
			this.cmbDocumento.SelectedIndexChanged -= new System.EventHandler(this.cmbDocumento_SelectedIndexChanged);
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
			this.cmbDocumento.SelectedIndexChanged += new System.EventHandler(this.cmbDocumento_SelectedIndexChanged);
		}
		

		private void cargarSustentoTributario()
		{
			try
			{
				cmbSustentoTributario.DataSource = null;
				int tipoDoc = Convert.ToInt16(propiedadesDoc.TipoSri);
				if (tipoDoc > 0)
				{
					string fecha = txtfecha.Value.ToShortDateString();
					string ssql = "select '' Código,'' Descripción,'' tipoComprobante,'01/01/1900' as FechaInicio,'01/01/1900' as FechaFin union all ";
					ssql += "select RIGHT('00' + Código, 2) as Código, Descripción, tipoComprobante, ";
					ssql += "isnull(FechaInicio,'01/01/1900') as FechaInicio, isnull(FechaFin,'31/12/2999') as FechaFin ";
					ssql += "from SustentoComprobante ";
					ssql += "where isnull(FechaInicio,'01/01/1900') <= '" + fecha + "' ";
					ssql += "and isnull(FechaFin,'31/12/2999') >= '" + fecha + "' ";
					ssql += "and patindex('%" + tipoDoc.ToString() + ",%',tipoComprobante) > 0 ";
					cmbSustentoTributario.DataSource = SqlDatos.leerTablaIvaret(ssql);
					cmbSustentoTributario.DisplayMember = "Descripción";
					cmbSustentoTributario.ValueMember = "Código";
					cmbSustentoTributario.SelectedIndex = 0;
				}
			}
			catch { }
		}

		private string FormatearSustentoTributario(string valor)
		{
			if (string.IsNullOrEmpty(valor))
				return "";

			// Asegurar que tenga 2 dígitos
			return valor.PadLeft(2, '0');
		}
		private void CargarPredefinidosDocumento()
		{			
			propiedadesDoc = new sesSys.OpcDoc();
			propiedadesDoc.Cargar(ref idDocumentoActual.Tipo, ref idDocumentoActual.Sucursal);
			accesosLocalizados.iniciar(datosEmpresa.codEmpresa, datosEmpresa.usr, datosEmpresa.strConxSyscod);
			accesosLocalizados.cargarAccesoDoc(idDocumentoActual.Tipo);
			cargarSustentoTributario();
			AutorizacionesFac.HabilitarOpcionesDocumento(this);

			
		}
		
		private void prepararBotones()
		{
			Boolean inicio = (operacionEnCurso == sinOperacion);
			Boolean nuevo = (operacionEnCurso == nuevoRegistro);
			Boolean modificando = (operacionEnCurso == modificandoRegistro);
			Boolean docAnulado = false;

			try
			{
				// Usar operador ?. para evitar NullReferenceException
				docAnulado = (datADCDOC?.Doc_Estado == 0 && modificando);
			}
			catch
			{
				docAnulado = false;
			}

			btnAbre.Enabled = inicio;
			btnNuevo.Enabled = inicio;
			btnCopia.Enabled = nuevo;
			btnAnula.Enabled = (modificando && !docAnulado);
			btnElimina.Enabled = modificando;
			btnAplicaciones.Enabled = (modificando && !docAnulado);
			btnImprimir.Enabled = modificando;
			btnGraba.Enabled = (!inicio && !docAnulado);
			btnRegistra.Enabled = btnGraba.Enabled;
			btnEnviar.Enabled = (modificando && !docAnulado);
			btnCierra.Enabled = !inicio;
			btnPagos.Enabled = btnGraba.Enabled;
			btnDescuentos.Enabled = btnGraba.Enabled;
			btnPorcentajeIva.Enabled = btnDescuentos.Enabled;
			btnContabiliza.Enabled = btnGraba.Enabled;
			btnPendientes.Enabled = btnGraba.Enabled;

			panel1.Enabled = (!inicio);
			malla.Enabled = (!inicio);
			cmbDocumento.Enabled = (inicio);
			txtcedula.Enabled = (!docAnulado);

			// ✅ MODIFICACION ESPECIAL PARA IMPORTADOR XML
			if (_esModoReGrabarImportado && modificando)
			{
				// Forzar habilitación de botones de grabado
				btnGraba.Enabled = true;
				btnRegistra.Enabled = true;

				// Cambiar textos
				//btnGraba.Text = "Re-grabar Factura";
				//btnRegistra.Text = "Re-grabar e Imprimir";

				// Habilitar controles incluso si es "solo consulta" en teoría
				panel1.Enabled = true;
				malla.Enabled = true;
				txtcedula.Enabled = true;
			}

			if (accesosLocalizados.sinRegistro == false)
			{
				if (nuevo)
				{
					btnGraba.Enabled = (btnGraba.Enabled && (accesosLocalizados.Crear));
					btnRegistra.Enabled = (btnRegistra.Enabled && (btnGraba.Enabled && accesosLocalizados.Imprimir));
				}
				else if (modificando)
				{
					// ✅ PERMITIR MODIFICAR SI ES IMPORTADOR XML, AUN SIN PERMISO DE MODIFICACION
					if (_esModoReGrabarImportado)
					{
						btnGraba.Enabled = true;  // Forzar habilitado
						btnRegistra.Enabled = (btnGraba.Enabled && accesosLocalizados.Imprimir);
					}
					else
					{
						btnGraba.Enabled = (btnGraba.Enabled && (accesosLocalizados.Modificar));
						btnRegistra.Enabled = (btnRegistra.Enabled && (btnGraba.Enabled && accesosLocalizados.Modificar && accesosLocalizados.Imprimir));
					}
				}

				btnImprimir.Enabled = (btnImprimir.Enabled && accesosLocalizados.Imprimir);
				btnNuevo.Enabled = (accesosLocalizados.Crear && btnNuevo.Enabled);
				btnElimina.Enabled = (accesosLocalizados.Eliminar && btnElimina.Enabled);
				btnAnula.Enabled = (accesosLocalizados.Anular && btnAnula.Enabled);
				btnCopia.Enabled = (accesosLocalizados.Crear && btnCopia.Enabled);
			}

			// ✅ ANULAR LA RESTRICCION DE "SOLO CONSULTA" PARA IMPORTADOR XML
			if ((esSoloConsulta == true && !_esModoReGrabarImportado) || docAnulado)
			{
				btnGraba.Enabled = false;
				btnRegistra.Enabled = false;
				btnElimina.Enabled = false;
				btnAnula.Enabled = false;

				if (datADCDOC?.Doc_Estado == 1)
					btnElimina.Enabled = (datosEmpresa.usr.ToUpper() == "ADMINISTRADOR");
			}

			if (propiedadesDoc.ImprimirDoc == "N")
				btnEnviar.Visible = false;
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

		private void BuscaProveedor(string buscador)
		{
			directMnt.BuscaClien directorio = new directMnt.BuscaClien();
			string cliente = "P";
			string codigo = "";
			string nombre = "";
			string conalias = "N";
			string connuevo = "S";
			codigo = directorio.IniBuscaCliOPro(ref cliente, ref nombre, ref conalias, ref connuevo);
			if ((codigo + "").Length > 0) cargarDatosProveedor(codigo);
			directorio.Dispose();
		}
		private void cargarDatosProveedor(string codigo = "")
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
					codProveedor = opalex.codigo;
					txtcedula.Text = opalex.CiRuc;
					txtnombrecliente.Text = opalex.NombreImpresion;
					txtdireccion.Text = opalex.direccion;
					txtCorreElectronico.Text = opalex.correoElectronico;
					txttelefono.Text = opalex.telefono1;
				}
			}
			if (codigo == "")
			{
				codProveedor = "";
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
					cargarDatosProveedor(datADCDOC.Doc_codper);
					DatosFacturacion.MoverDatosAcontroles(this,datADCDOC);
					if (Convert.ToInt32(datADCDOC.Doc_Estado) == 0) mensajesDocumento.Text = "DOCUMENTO ANULADO : " + datADCDOC.MotivoAnulacion;
					cargarDetalleArticulos(idDocumentoActual.Sucursal, idDocumentoActual.Tipo, idDocumentoActual.idClave, "ADCTRA");
					cargarFormaDePago(idDocumentoActual, "ADCPAG");
					totalizar();

					// ✅ ESTABLECER MODO MODIFICACION
					operacionEnCurso = modificandoRegistro;

					// ✅ CONFIGURACION ESPECIAL PARA IMPORTADOR
					if (_esDesdeImportadorXml)
					{
						txtnumero.Enabled = false;  // No permitir cambiar número
						cmbDocumento.Enabled = false;  // No cambiar tipo
													   // Pero mantener otros campos habilitados
						txtDetalle.ReadOnly = false;
						malla.Enabled = true;
						malla.ReadOnly = false;
					}
					else
					{
						txtnumero.Enabled = false;
					}

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
		//private void moverClaseAcontroles()
		//{
		//	moverCabezera();
		//moverOtrosValores();
		//}
		private void moverCabezera()
		{

			idDocumentoActual.idClave = Convert.ToDouble(datADCDOC.IdClaveDoc);
			codProveedor = datADCDOC.Doc_codper;

			txtnumero.Text = datADCDOC.Doc_numero.ToString();
			if (datADCDOC.Doc_NroIdDoc.ToString() != "") txtNroID.Text = datADCDOC.Doc_NroIdDoc.ToString();
			txtfecha.Text = datADCDOC.Doc_fecha.ToShortDateString();
			txtcedula.Text = datADCDOC.Doc_CiRuc;
			txtnombrecliente.Text = datADCDOC.Doc_NombreImp;
			txtdireccion.Text = datADCDOC.Doc_Direccion;

			txtDetalle.Text = datADCDOC.Doc_detalle;
			//cmbVendedor.SelectedValue = datADCDOC.Doc_venabre;
		}
	
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
			TextNroAutSri.Text = "";
			txtCodigoRet.Text = "";
			
			//            InicializarMalla();
		}
		private void InicializarMalla()
		{
			//  this.malla.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.malla_CellValueChanged);
			DatosDocFacturacion dcut = new DatosDocFacturacion();
			ModelaMalla dcut2 = new ModelaMalla();

			dtDetalleDocumento = utilBasDatos.utilBasDatos.leerTablas(dcut.armarSqlLecturaTransFacturas("ADCTRA", datosEmpresa.suc, idDocumentoActual.Tipo, idDocumentoActual.idClave), datosEmpresa.strConxAdcom);

			//DctosEmi.armarConsTra dcut = new DctosEmi.armarConsTra();
			//dtDetalleDocumento = utilBasDatos.utilBasDatos.leerTablas(dcut.armarSqlLecturaTraFacPv(propiedadesDoc, "adctra", "", "", 0), datosEmpresa.strConxAdcom);
			if (dtDetalleDocumento == null) return;
			malla.DataSource = dtDetalleDocumento;
			dtDetalleDocumento.Rows.Add(dtDetalleDocumento.NewRow());
			//DctosEmi.diseñarMalla dcut2 = new DctosEmi.diseñarMalla();
			dcut2.diseñarMallaFacturas (ref malla, ref propiedadesDoc,accesosLocalizados);
			dcut2 = null;
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
			if (nomCol == "TRA_PRECUNI" || nomCol == "TRA_CANTIDAD" || nomCol == "TRA_PORCENDES" || nomCol == "TRA_SNIVA" || nomCol == "TRA_MULTIPLO" || nomCol == "Tra_porceniva" ) totalizar();
		}


		#region EVENTOS DE CONTROLES
		#region EVENTOS DE BOTONES
		//private void btnBarras_Click(object sender, EventArgs e)
		//{
		//	btnAgrupa.Enabled = btnBarras.Checked;
		//}

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
				Lista = progBus.IniciaConsolidacion(DctosEmi.ConsolidaDoc.tiposDoctsConsolidaSql(datosEmpresa.strConxAdcom), codProveedor, "", queFecha, ref SUC, ref TIP, ref Numero, ref Idclave, false, "", "", "", "ADCDOC")
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
			BuscaProveedor(txtnombrecliente.Text);
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
				if (grabarDocumento() == true) { limpiarDatos(); }
			}

		}
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
			string vend = "";
			if (cmbBodega.SelectedValue != null) bod = cmbBodega.SelectedValue.ToString();
			if (cmbVendedor.SelectedValue != null) vend = cmbVendedor.SelectedValue.ToString();
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
            dtFechaContabiliza.Value = txtfecha.Value;
			ChequearCambioValoresPoFecha();
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
			string codigo1 = "";
			cargarDatosProveedor(codigo);
			if (txtcedula.Text == "")
			{
				//MessageBox.Show("El cliente no existe ", "Creacion de cliente nuevo", MessageBoxButtons.OK, MessageBoxIcon.Question);
				if (MessageBox.Show("El cliente no existe, Desea Crearlo? ", "Creacion de cliente nuevo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
				{				
					bool validacion;
					DataTable dt = DattCom.datosEmpresa.leeParametrosEmp("par_ValiDir");
					try
					{
						if (Convert.ToBoolean(dt.Rows[0]["par_ValiDir"]) == false)
						{
							validacion = false;
						}
						else
						{
							validacion = true;
						}
					}
					catch (Exception)
					{
						validacion = false;
					}

					if (validacion == false)
					{
						directMnt.CreaCliAlex express = new directMnt.CreaCliAlex();
						express.IniCrearAlex(ref tipo, ref codigo);
					}
					else
					{
						//MantenimientoDirectorioOnline.BusDirectorio prog = new MantenimientoDirectorioOnline.BusDirectorio();						
						//prog.ManDir(ref codigo1);
						//prog = null;
					}
				}
			}
			if ((codigo + "").Length > 0) cargarDatosProveedor(codigo);
		}
		private void cmbDocumento_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (idDocumentoActual.Sucursal == "") return;
			if (idDocumentoActual.Tipo == cmbDocumento.SelectedValue.ToString()) return;
			idDocumentoActual.Tipo = cmbDocumento.SelectedValue.ToString();
			CargarPredefinidosDocumento();
			cargarSustentoTributario();
			LlenarComboDocReferencia();
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
			impresionVerificacion.verificarExistenciaDocumento(ref idDocumentoActual, datosEmpresa.strConxAdcom,true, "ADCDOC", codProveedor);
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
                            mallaArticulo.codCliente = codProveedor;
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
								//dato = buscserv.iniciaBuscador(datosEmpresa.strConxAdcom, "", "V", false, false);
								dato = buscserv.iniciaBuscador(datosEmpresa.strConxAdcom, "", "C", false, false);
								//if (dato != "") mallaArticulo.CargarServicios(dato, ref malla, claseImpuestos.impstoPorcentaje1, valoresPredefinidosEmpresa.nroDigitosEnPrecios, Convert.ToDateTime(txtfecha.Text), ref propiedadesDoc);
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
						cargarDatosProveedor(datADCDOC.Doc_codper);
						moverCabezera();
					}
				}
				DatosFacturacion.MoverDatosAcontroles(this, datADCDOC);
				malla.DataSource = dtDetalleDocumento;
				ModelaMalla dcut2 = new ModelaMalla();
				dcut2.diseñarMallaFacturas(ref malla, ref propiedadesDoc, accesosLocalizados);
				malla.Columns["Existencia"].Visible = valoresPredefinidosEmpresa.existenciaEnLineas;
				string tablaPagos = "ADCPAG";
				if (opcp.tablaDatosDoc.ToUpper() == "ADCDOC") tablaPagos = "AdcPagPro";
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
					cargarDatosProveedor(datADCDOC.Doc_codper);
					moverCabezera();
				}
				//moverOtrosValores();
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
			if (opalex.codigo == "" || codProveedor == "" || txtcedula.Text == "") { mensajesErrorDocumento.ElCodigoNoExiste("C"); return false; }

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
                    //DctosEmi.fijarNumeroDocumento fijnum = new DctosEmi.fijarNumeroDocumento();
                    //datADCDOC.Doc_numero = Convert.ToDecimal(fijnum.nroDeDocumento(propiedadesDoc.tablaDatosDoc, propiedadesDoc.CodDuplica, Convert.ToBoolean(propiedadesDoc.NroAutomatico), Convert.ToDouble(txtnumero.Text), datosEmpresa.strConxAdcom, datosEmpresa.suc, cmbDocumento.SelectedValue.ToString(), txtnumero.Text, cmbBodega.SelectedValue.ToString(), codCliente, txtNroID.Text));
                    //if (datADCDOC.Doc_numero == 0) return false;
                    res = datADCDOC.Crear();
					
                    idDocumentoActual.idClave = Convert.ToDouble(datADCDOC.IdClaveDoc);
                    idDocumentoActual.numero = Convert.ToDouble(datADCDOC.Doc_numero);
                    idDocumentoActual.Sucursal = datADCDOC.Doc_sucursal;
                    idDocumentoActual.Tipo = datADCDOC.Opc_documento;
					txtnumero.Text = datADCDOC.Doc_numero.ToString();
					
					actualizaDatosPagos();
                    if (res.Substring(0, 3) != "ERR" ) { grabarAdctra(); }
                    string tipDoc = cmbDocumento.SelectedValue.ToString();
					//string tipBan = "";
					//					if (idDocumentoActual.idClave != 0) propiedadesDoc.GuardarNumero(ref datosEmpresa.suc, ref tipDoc, ref tipBan, txtNroID.Text, "", datosEmpresa.usr, cmbBodega.SelectedValue.ToString());
					clasePagos.guardarPagosDocumento("ADCPAG");
                    //ClaveElectronica.actualizarClaveElectronica(datADCDOC);
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
            else
            {
				if (txtCodigoRet.Text!="332" && txtCodigoRet.TextLength ==0)
				{
					if (MessageBox.Show("Desea registrar la retención al proveedor ? ", "Registrar retención por factura", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						IvaRett.MantRetencion prog = new IvaRett.MantRetencion("RTP", "RTP", 1, idDocumentoActual, false);
						prog.ShowDialog();
						prog.Dispose();
					}
				}
				if (txtCodigoRet.Text != "332" && txtCodigoRet.TextLength>1)
				{
					if (MessageBox.Show("El código ingresado en el codigo de retencion no es el 332 desea continuar y registrar la retención al proveedor?", "Registrar retención por factura", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) 
					{
						IvaRett.MantRetencion prog = new IvaRett.MantRetencion("RTP","RTP",1, idDocumentoActual, false);
						prog.ShowDialog();
						prog.Dispose();
					}

				}
				
                
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

		//private void totalizar()
		//{
		//	if (malla.Rows.Count < 1) return;		
		//	totalesDocumento = new DctosEmi.docTotals();			
		//	edTotal.Text = Convert.ToString(totalesDocumento.totalizar(malla, ivaM, claseDescuentos, clasePagos, propiedadesDoc, valoresPredefinidosEmpresa.nroDigitosEnPrecios, valoresPredefinidosEmpresa.nroDigitosEnCostos));
		//	presentarTotales();		
		//	btnPagos.Enabled = (totalesDocumento.TotVta > 0) ;

		//}

		//private void totalizar()
		//{
		//	if (malla.Rows.Count < 1) return;

		//	totalesDocumento = new DctosEmi.docTotals();

		//	edTotal.Text = Convert.ToString(
		//		totalesDocumento.totalizar(
		//			malla,
		//			ivaM,
		//			claseDescuentos,
		//			clasePagos,
		//			propiedadesDoc,
		//			valoresPredefinidosEmpresa.nroDigitosEnPrecios,
		//			valoresPredefinidosEmpresa.nroDigitosEnCostos
		//		)
		//	);

		//	decimal base0 = 0;
		//	decimal base5 = 0;
		//	decimal base8 = 0;
		//	decimal base15 = 0;

		//	foreach (DataGridViewRow row in malla.Rows)
		//	{
		//		if (row.Cells["Tra_PorcenIva"].Value == null) continue;

		//		decimal baseLinea = Convert.ToDecimal(row.Cells["Tra_PrecTot"].Value);
		//		decimal porcIva = Convert.ToDecimal(row.Cells["Tra_PorcenIva"].Value);

		//		if (porcIva == 0)
		//			base0 += baseLinea;

		//		else if (porcIva == 5)
		//			base5 += baseLinea;

		//		else if (porcIva == 8)
		//			base8 += baseLinea;

		//		else if (porcIva == 15)
		//			base15 += baseLinea;
		//	}

		//	decimal iva5 = Math.Round(base5 * 0.05m, 2);
		//	decimal iva8 = Math.Round(base8 * 0.08m, 2);
		//	decimal iva15 = Math.Round(base15 * 0.15m, 2);

		//	totalesDocumento.SubTotalSIva = base0;
		//	totalesDocumento.TotVta5 = base5;
		//	totalesDocumento.TotVta8 = base8;
		//	totalesDocumento.TotVta15 = base15;

		//	totalesDocumento.TotIva5 = iva5;
		//	totalesDocumento.TotIva8 = iva8;
		//	totalesDocumento.TotIva15 = iva15;

		//	presentarTotales();

		//	btnPagos.Enabled = (totalesDocumento.TotVta > 0);
		//}


		private void totalizar()
		{
			if (malla.Rows.Count < 1) return;

			totalesDocumento = new DctosEmi.docTotals();

			edTotal.Text = Convert.ToString(
				totalesDocumento.totalizar(
					malla,
					ivaM,
					claseDescuentos,
					clasePagos,
					propiedadesDoc,
					valoresPredefinidosEmpresa.nroDigitosEnPrecios,
					valoresPredefinidosEmpresa.nroDigitosEnCostos
				)
			);

			decimal base0 = 0;
			decimal base5 = 0;
			decimal base8 = 0;
			decimal base15 = 0;

			foreach (DataGridViewRow row in malla.Rows)
			{
				// Verificar si la fila es nueva o está vacía
				if (row.IsNewRow) continue;

				// Verificar que la celda Tra_PorcenIva no sea null
				if (row.Cells["Tra_PorcenIva"].Value == null ||
					row.Cells["Tra_PorcenIva"].Value == DBNull.Value)
					continue;

				// Verificar que la celda Tra_PrecTot no sea null o DBNull
				if (row.Cells["Tra_PrecTot"].Value == null ||
					row.Cells["Tra_PrecTot"].Value == DBNull.Value)
					continue;

				decimal baseLinea;
				decimal porcIva;

				// Intentar convertir con TryParse para mayor seguridad
				if (!decimal.TryParse(row.Cells["Tra_PrecTot"].Value.ToString(), out baseLinea))
					continue;

				if (!decimal.TryParse(row.Cells["Tra_PorcenIva"].Value.ToString(), out porcIva))
					continue;

				if (porcIva == 0)
					base0 += baseLinea;
				else if (porcIva == 5)
					base5 += baseLinea;
				else if (porcIva == 8)
					base8 += baseLinea;
				else if (porcIva == 15)
					base15 += baseLinea;
			}

			decimal iva5 = Math.Round(base5 * 0.05m, 2);
			decimal iva8 = Math.Round(base8 * 0.08m, 2);
			decimal iva15 = Math.Round(base15 * 0.15m, 2);

			totalesDocumento.SubTotalSIva = base0;
			totalesDocumento.TotVta5 = base5;
			totalesDocumento.TotVta8 = base8;
			totalesDocumento.TotVta15 = base15;

			totalesDocumento.TotIva5 = iva5;
			totalesDocumento.TotIva8 = iva8;
			totalesDocumento.TotIva15 = iva15;

			presentarTotales();

			btnPagos.Enabled = (totalesDocumento.TotVta > 0);
		}


		private void presentarTotales()
		{
			string formato = "#,0.00";
			labTotDescuentoIva.Text = totalesDocumento.totdesciva.ToString(formato);
			labTotdescuentoSinIva.Text = totalesDocumento.totdessiva.ToString(formato);
			labTotIva.Text = totalesDocumento.TotIva.ToString(formato);
			//labTotPorcIva.Text = (claseImpuestos.impstoPorcentaje1 * 100).ToString() + "% IVA";
			labTotPorcIva.Text = "Valor Iva";

			iva15.Text = ("IVA " + claseImpuestos.impstoPorcentaje1).ToString() + "%";
			sub15.Text = ("Sub.Iva " + claseImpuestos.impstoPorcentaje1).ToString() + "%";

			labTotSubConIva5.Text = totalesDocumento.TotVta5.ToString(formato);
			labTotSubConIva15.Text = totalesDocumento.TotVta15.ToString(formato);
			labTotIva5.Text = totalesDocumento.TotIva5.ToString(formato);
			labTotIva15.Text = totalesDocumento.TotIva15.ToString(formato);

			labTotSubConIva.Text = totalesDocumento.Subtotalciva.ToString(formato);
			labTotSubSinIva.Text = totalesDocumento.SubTotalSIva.ToString(formato);
			labTotVtaConIva.Text = totalesDocumento.TotCiva.ToString(formato);
			labTotVtaSinIva.Text = totalesDocumento.TotSiva.ToString(formato);
			labTotalDescuento.Text = totalesDocumento.TotDescuentos.ToString(formato);
			labTotalVenta.Text = (totalesDocumento.TotCiva + totalesDocumento.TotSiva).ToString(formato);
			labSubtotal.Text = (totalesDocumento.Subtotalciva + totalesDocumento.SubTotalSIva ) .ToString(formato);
			labTotalFactura.Text= edTotal.Text;
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


		}

		private void btnPorcentajeIva_Click(object sender, EventArgs e)
		{
			Buscar.frmBuscar progBus = new Buscar.frmBuscar();
			string ssql = "select  Porcentaje, isnull(fechaInicio,'01/01/1900') as ValidoDesde";
				ssql += ", isnull(FechaFin,'31/12/2078') as ValidoHasta from porcentajeiva";
			string nvoIva = progBus.Buscar(datosEmpresa.strConxIvaret , ssql, "porcentaje", "porcentaje", "", "Seleccionar porcentaje IVA", "");
			if (MessageBox.Show("Confirma cambiar el porcentaje del IVA en el documento ?", "Cambiar porcentaje del IVA", MessageBoxButtons.YesNo, MessageBoxIcon.Question  ) == DialogResult.No) return;
			claseImpuestos.cambiadoManual = true;
			claseImpuestos.impstoPorcentaje1 = Convert.ToDouble("0" + nvoIva)*100;
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
			AuditSis.registrar.registraPreferencia(datosEmpresa.strConxSyscod, datosEmpresa.codEmpresa.ToString(), datosEmpresa.usr, "ADX", datosEmpresa.suc, "Facturacion", "TipoDoc", cmbDocumento.SelectedValue.ToString());
			AuditSis.registrar.registraPreferencia(datosEmpresa.strConxSyscod, datosEmpresa.codEmpresa.ToString(), datosEmpresa.usr, "ADX", datosEmpresa.suc, "Facturacion", "Bodega", cmbBodega.SelectedValue.ToString());
			//if (cmbVendedor.SelectedValue != null ) AuditSis.registrar.registraPreferencia(datosEmpresa.strConxSyscod, datosEmpresa.codEmpresa.ToString(), datosEmpresa.usr, "ADX", datosEmpresa.suc, "Facturacion", "Vendedor", cmbVendedor.SelectedValue.ToString());
		}
		private void recordarOpciones()
		{
		   memTipoDoc = AuditSis.registrar.obtenerPreferencia (datosEmpresa.strConxSyscod, datosEmpresa.codEmpresa.ToString(), datosEmpresa.usr, "ADX", datosEmpresa.suc, "Facturacion", "TipoDoc");
		   memBodega = AuditSis.registrar.obtenerPreferencia(datosEmpresa.strConxSyscod, datosEmpresa.codEmpresa.ToString(), datosEmpresa.usr, "ADX", datosEmpresa.suc, "Facturacion", "Bodega");
		   memVendedor = AuditSis.registrar.obtenerPreferencia(datosEmpresa.strConxSyscod, datosEmpresa.codEmpresa.ToString(), datosEmpresa.usr, "ADX", datosEmpresa.suc, "Facturacion", "Vendedor");
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
			DaxInvent.EntregasPendientesClienteProv prog = new  DaxInvent.EntregasPendientesClienteProv (datosEmpresa.strConxAdcom,"C",codProveedor,txtnombrecliente.Text );
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

		private void btnAplicaciones_Click_1(object sender, EventArgs e)
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

		private void btnActualizar_Click(object sender, EventArgs e)
		{
			


			bool validacion;
			DataTable dt = DattCom.datosEmpresa.leeParametrosEmp("par_ValiDir");
			try
			{
				if (Convert.ToBoolean(dt.Rows[0]["par_ValiDir"]) == false)
				{
					validacion = false;
				}
				else
				{
					validacion = true;
				}
			}
			catch (Exception)
			{
				validacion = false;
			}

			if (validacion == false)
			{
				directMnt.BusDirectorio prog = new directMnt.BusDirectorio();
				string codigo = "";
				prog.ManDir(ref codigo);
				prog = null;
			}
			else
			{
				//MantenimientoDirectorioOnline.BusDirectorio prog = new MantenimientoDirectorioOnline.BusDirectorio();
				//string codigo = "";
				//prog.ManDir(ref codigo);
				//prog = null;
			}
		}

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

	}
}