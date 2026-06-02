using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using daxMallaDatos;
using FormasPagoDax;
using classMenSistem;
using ctrlReferencia;
using adcArticulosPrecios;
using ClassDoc;
using adcDocumentos;
using System.IO;
using System.Drawing;
using System.Reflection;
namespace adcDocumentos
{
	public partial class FormFacPVT : Form
	{
        Control[] botones;
        PrySysp13.OpcDoc propiedadesDoc;
		DaxMantDirectorio.DirectorioAlex opalex = new DaxMantDirectorio.DirectorioAlex();
		AdcDoc datADCDOC;
		pagosDocumento.classPagosDoc clasePagos = new pagosDocumento.classPagosDoc();
		adcDescto.descDocumento claseDescuentos = new adcDescto.descDocumento();
		TablasSRI.docImpuestos claseImpuestos = new TablasSRI.docImpuestos();
		//impresionVerificacion dcu = new impresionVerificacion();
		daxAccs.propiedadesDaxAuto accesosLocalizados = new daxAccs.propiedadesDaxAuto();

		// adcArticulo.AdcArt propiedadesArticulo = new adcArticulo.AdcArt();
		ctrlReferencia.controlReferencial clasref = new controlReferencial();
		DataTable dtDetalleDocumento = new DataTable();

		adcDocumentos.docTotals totalesDocumento = new adcDocumentos.docTotals();
		string claseDocDefault = "FAC";
		string tipoDocDefault = "FAC";

		bool iniciaConNuevoDOc = false;
		Boolean esSoloConsulta = false;
		Boolean tieneComprobantesElectronicos = false;
		Boolean entregasPendientes = false;
		Boolean esDeLiquidacion = false;
		Boolean debeActualizarContacto = false;

		idDocumento idDocumentoActual = new idDocumento();
		idDocumento idDocumentoSoporte = new idDocumento();
		idDocumento idDocumentoParaGenerar = new idDocumento();

		string claveSri = "";
		string codCliente = "";
		Boolean saltarEventoNumero = false;
		Boolean saltaEventosMalla = false;

		// valores predefinidos en la empresa
		Int16 nroDigitosEnPrecios = 0;
		Int16 nroDigitosEnCostos = 0;
		string formaPagoPredefinidaVtas = "";
		bool permiteCruceDocOtraSucursal = false;
		Int16 nroDescuentosMaximosDocto = 0;

//        valoresPredefinidosSucursal PredefinidosSucursal = new valoresPredefinidosSucursal();
		Boolean existenciaEnLineas = false;

		int operacionEnCurso = 0; // 0 sin operacion delcarada, 1 nuevo registro, 2 modificando registro
		int sinOperacion = 0;
		int nuevoRegistro = 1;
		int modificandoRegistro = 2;

//        string[] ValoresSistemaMedico;
		 
		public FormFacPVT(string clasdef, string tipdef, bool nuevo = false, Boolean esConsulta = false, Boolean generarFactura = false, Boolean desdeEstdoCta = false, idDocumento idDocViene = null, string sisMedico = "")
		{
			InitializeComponent();
			CargarValoresIniciales(tipdef);
			LlenarCombos();
			iniciaConNuevoDOc = nuevo;
			if (idDocViene == null) idDocViene = new idDocumento();
			if (idDocViene.idClave > 0 && esConsulta)
			{
				idDocumentoActual = idDocViene;
			}
			else if (idDocViene.idClave > 0 && generarFactura)
			{
				MessageBox.Show("decision");
				idDocumentoParaGenerar = idDocViene;
			}
			else
			{
				idDocumentoActual.Sucursal = varbleComun.VarCom.suc;
				idDocumentoActual.Tipo = tipoDocDefault;
				idDocumentoActual.familia = claseDocDefault;
			}
			cargarImagenes();            
		}
		private void ArmarTabsDeArticulos()
		{

		}
		private void cargarImagenes()
		{       

			DirectoryInfo dir = new DirectoryInfo (@"E:\Daxsof\ArchivosDePrograma\prog\Bin\Imagenes");
			int i = 0;
			foreach (FileInfo file in dir.GetFiles())
			{
				
				try
				{
					i++;
					this.imageList1.Images.Add("clave " + i.ToString(),Image.FromFile(file.FullName));
				}
				catch
				{
					Console.WriteLine("No es un archivo de imagen");
				}
			}

			this.listView1.View = View.LargeIcon;
			this.imageList1.ImageSize = new Size(50,50);
			this.listView1.LargeImageList = this.imageList1;

			for (int j = 0; j < this.imageList1.Images.Count; j++)
			{
				ListViewItem item = new ListViewItem();
				item.ImageIndex = j;
                // item.ImageKey = imageList1.Images.Keys[j];  
                item.Name = "codigo " + j.ToString();                                                                                             
				item.Text="nombre articulo corto".ToString()  + (j * 100).ToString();
                item.SubItems.Add("valor 99999 ");
                item.UseItemStyleForSubItems = true;
                
                this.listView1.Items.Add(item);
			}
            PonerBotonesClases();

        }
        private void PonerBotonesClases()
        {
            string ssql = "select * from AdcNiv where Niv_categor=1";
            using (SqlDataAdapter da = new SqlDataAdapter(ssql,varbleComun.VarCom.strConxAdcom))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                int i = 0;
                foreach (DataRow row in dt.Rows)
                {                    
                    Button Boton1 = new Button();
                    Boton1.FlatStyle = FlatStyle.Standard;
                    Boton1.BackColor = Color.SteelBlue;
                    Boton1.ForeColor = Color.White;
                    Boton1.Top = 7;
                    Boton1.Left = i * 75+8;
                    Boton1.Height = 35;
                    Boton1.Width = 75;
                    Boton1.Name = row["niv_Abrevia"].ToString();
                    Boton1.Text = row["niv_nombre"].ToString();
                    Boton1.Click += new System.EventHandler(this.Boton_Click);
                    if (PanelControles.Width < Boton1.Left + 80) PanelControles.Width += Boton1.Left + 80;
                    PanelControles.Controls.Add(Boton1);
                    i++;
                }
            }
        }
        private void Boton_Click(object sender, System.EventArgs e)
        {
            Button text = (Button)sender;
            MessageBox.Show("boton "+ text.Name);
        }

        private void Clonar(object src, object tgt)
        {
            PropertyInfo[] props = src.GetType().GetProperties();
            foreach (PropertyInfo pi in props)
            {
                if (pi.CanWrite)
                    pi.SetValue(tgt, pi.GetValue(src, null), null);
            }
        }
        private void CargarValoresIniciales(string tipdef)
		{
			this.txtfecha.ValueChanged -= new System.EventHandler(this.txtfecha_ValueChanged);
			this.Text = "MANTENIMIENTO DOCUMENTOS FACTURACION A CLIENTES : " + varbleComun.VarCom.nomEmpresa;

			if (tipdef.Length > 0) tipoDocDefault = tipdef; else tipoDocDefault = "FAC";
			txtfecha.Value = DateTime.Now;
			idDocumentoActual.Tipo = tipoDocDefault;

			claseImpuestos.cargar(varbleComun.VarCom.strConxIvaret, txtfecha.Value);

			cargaValoresPredefinidosEmpresa();
			valoresPredefinidosSucursal.cargarValores();
			txtNroID.Text = valoresPredefinidosSucursal.idtributario;
			txtNroID.Enabled = valoresPredefinidosSucursal.autCambiaPtoVta;
			ptoVenta.Visible = valoresPredefinidosSucursal.autCambiaPtoVta;
			CargarPredefinidosDocumento();
			this.txtfecha.ValueChanged += new System.EventHandler(this.txtfecha_ValueChanged);
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
			//else if (ValoresSistemaMedico.Length > 0)
			//{
			//    iniciarNuevoDocumento();
			//    FacturarAtencionMedicaExterna(ValoresSistemaMedico);
			//}
			else
			{
				if (iniciaConNuevoDOc) iniciarNuevoDocumento();
			}
			prepararBotones();
		}
		//private void FacturarAtencionMedicaExterna(string[] infoCitasMedicas)
		//{
		//    decimal IdClaveCita = 0;
		//    string FacturarConceptos = "";
		//    int TurnoMedico = 0;
		//    string[] SistemaMedico = (infoCitasMedicas[0] + ";;;;;;;;").Split(Convert.ToChar(";"));
		//    if (infoCitasMedicas.Length > 1) FacturarConceptos = infoCitasMedicas[1];

		//    if (SistemaMedico[0] == "CITMED")
		//    {
		//        cmbDocumento.SelectedValue = SistemaMedico[1];
		//        txtcedula.Text = SistemaMedico[2];
		//        IdClaveCita = Convert.ToDecimal(SistemaMedico[8]);
		//        TurnoMedico = Convert.ToInt16(SistemaMedico[9]);
		//        cmbVendedor.SelectedValue = SistemaMedico[10];
		//        if (txtcedula.Text.Length > 0) ingresaCodigoClienteDirecto();
		//        FacturarCitasMedicas(SistemaMedico[3], SistemaMedico[4], SistemaMedico[5], Convert.ToInt16(SistemaMedico[6]), Convert.ToDouble(SistemaMedico[7]), FacturarConceptos);  
		//    }
		//}
		//private void FacturarCitasMedicas(string TipoConcepto,string NombreConcepto,string NombreConcepto2, int Cantidad, Double PrecioUnitario,string Conceptos )
		//{
		//    int ind = 0;
		//    dtDetalleDocumento.Rows.Add();
		//    malla.Refresh();           
		//    DataGridViewRow row = malla.Rows[ind];
		//    row.Cells["TRA_NUMLINEA"].Value = ind+1;
		//    row.Cells["tra_codigo"].Value = TipoConcepto ;
		//    daxMallaDatos.docMallaArticulo mallaArticulo = new docMallaArticulo();
		//    mallaArticulo.CargarServicios(TipoConcepto, ref malla, claseImpuestos.impstoPorcentaje1, nroDigitosEnPrecios, Convert.ToDateTime(txtfecha.Text), ref propiedadesDoc);
		//    mallaArticulo = null;
		//    row.Cells["tra_nombre"].Value = NombreConcepto ;
		//    row.Cells["tra_cantidad"].Value = Cantidad ;
		//    row.Cells["tra_medida"].Value = "";
		//    row.Cells["Tra_precuni"].Value = PrecioUnitario;
		//    row.Cells["tra_porcendes"].Value = 0;
		//    row.Cells["tra_valordes"].Value = 0;
		//    row.Cells["Tra_prectot"].Value = Cantidad * PrecioUnitario;
		//    row.Cells["TRA_SNIVA"].Value = false ;

		//    row.Cells["tra_quetipo"].Value = "S";
		//    row.Cells["tra_esCuenta"].Value = 0;
		//    row.Cells["Tra_individual"].Value = "N";
		//    row.Cells["tra_costuni"].Value = 0;
		//    row.Cells["Tra_CostTot"].Value = 0;
		//    row.Cells["tra_multiplo"].Value = 1;
		//    row.Cells["Despacho"].Value = 0;
		//    row.Cells["tra_numprecio"].Value = 1;

		//    if (NombreConcepto2.Length > 0)
		//    {
		//        dtDetalleDocumento.Rows.Add();
		//        malla.Refresh();
		//        ind++;
		//        row = malla.Rows[ind];
		//        row.Cells["TRA_NUMLINEA"].Value = ind+1;
		//        row.Cells["tra_codigo"].Value = ".";
		//        row.Cells["tra_nombre"].Value = NombreConcepto2;
		//        row.Cells["tra_cantidad"].Value = 0;
		//        row.Cells["tra_medida"].Value = "";
		//        row.Cells["Tra_precuni"].Value = 0;
		//        row.Cells["tra_porcendes"].Value = 0;
		//        row.Cells["tra_valordes"].Value = 0;
		//        row.Cells["Tra_prectot"].Value = 0;
		//        row.Cells["TRA_SNIVA"].Value = false ;

		//        row.Cells["tra_quetipo"].Value = "";
		//        row.Cells["tra_esCuenta"].Value = 0;
		//        row.Cells["Tra_individual"].Value = "";
		//        row.Cells["tra_costuni"].Value = 0;
		//        row.Cells["Tra_CostTot"].Value = 0;
		//        row.Cells["tra_multiplo"].Value = 0;
		//        row.Cells["Despacho"].Value = 0;
		//        row.Cells["tra_numprecio"].Value = 0;
		//    }
		//    if (Conceptos.Length > 0) FacturarConceptosMedicos(Conceptos.Split(Convert.ToChar(";")), ind);
		//    dtDetalleDocumento.Rows.Add();
		//    malla.Refresh();
		//}

		//private void FacturarConceptosMedicos(string[] Conceptos, int Linea)
		//{
		//    string TipoConcepto = "";
		//    for (int l = 3; l < Conceptos.Length; l=l+4)
		//    {
		//        TipoConcepto = Conceptos[l];
		//        if (TipoConcepto.Length > 0)
		//        {
		//            dtDetalleDocumento.Rows.Add();
		//            malla.Refresh();
		//            Linea++;
		//            DataGridViewRow row = malla.Rows[Linea];
		//            row.Cells["TRA_NUMLINEA"].Value = Linea +1;
		//            row.Cells["tra_codigo"].Value = TipoConcepto;
		//            daxMallaDatos.docMallaArticulo mallaArticulo = new docMallaArticulo();
		//            mallaArticulo.CargarServicios(TipoConcepto, ref malla, claseImpuestos.impstoPorcentaje1, nroDigitosEnPrecios, Convert.ToDateTime(txtfecha.Text), ref propiedadesDoc);
		//            mallaArticulo = null;
		//            row.Cells["tra_nombre"].Value = Conceptos[l+1];
		//            row.Cells["tra_cantidad"].Value = Conceptos[l + 2];
		//            row.Cells["tra_medida"].Value = "";
		//            row.Cells["Tra_precuni"].Value = Conceptos[l + 3];
		//            row.Cells["tra_porcendes"].Value = 0;
		//            row.Cells["tra_valordes"].Value = 0;
		//            row.Cells["Tra_prectot"].Value = Convert.ToDouble(row.Cells["tra_cantidad"].Value) * Convert.ToDouble(row.Cells["Tra_precuni"].Value );
		//            row.Cells["TRA_SNIVA"].Value = false ;

		//            row.Cells["tra_quetipo"].Value = "S";
		//            row.Cells["tra_esCuenta"].Value = 0;
		//            row.Cells["Tra_individual"].Value = "N";
		//            row.Cells["tra_costuni"].Value = 0;
		//            row.Cells["Tra_CostTot"].Value = 0;
		//            row.Cells["tra_multiplo"].Value = 1;
		//            row.Cells["Despacho"].Value = 0;
		//            row.Cells["tra_numprecio"].Value = 1;
				//}
		//    }
		//}

		private void cargaValoresPredefinidosEmpresa()
		{
			DataTable dt = new DataTable();
			dt = varbleComun.VarCom.leeParametrosEmp("par_DigitosPrecios,par_DigitosCostos,Par_DocPrincipalVta,par_CruceDocSucursal,Par_AcfNumNiv,Par_roltur");
			nroDigitosEnPrecios = Convert.ToInt16(dt.Rows[0]["par_DigitosPrecios"].ToString());
			nroDigitosEnCostos = Convert.ToInt16(dt.Rows[0]["par_DigitosCostos"].ToString());
			formaPagoPredefinidaVtas = dt.Rows[0]["Par_DocPrincipalVta"].ToString();
			permiteCruceDocOtraSucursal = Convert.ToBoolean(dt.Rows[0]["par_CruceDocSucursal"]);
			nroDescuentosMaximosDocto = Convert.ToInt16(dt.Rows[0]["Par_AcfNumNiv"].ToString());
			if (Convert.ToInt16(dt.Rows[0]["Par_roltur"]) == 99)
			{
				existenciaEnLineas = true;
			} else
			{
				existenciaEnLineas = false;
			}

			dt.Dispose();
			tieneComprobantesElectronicos = impresionVerificacion.validaComprobantesElectronicos(varbleComun.VarCom.pathAppl);

		}
		private void LlenarCombos()
		{
			DaxCombobx.CargCmbBox cmb = new DaxCombobx.CargCmbBox();
			cmb.DaxCombosDoc(claseDocDefault, tipoDocDefault, false, varbleComun.VarCom.strConxAdcom, ref cmbDocumento);
			cmb.DaxCombosBods(varbleComun.VarCom.suc, false, varbleComun.VarCom.strConxSyscod, ref cmbBodega);
			cmb.DaxCombosVend(varbleComun.VarCom.strConxAdcom, ref cmbVendedor, false);
			cmbDocumento.SelectedValue = tipoDocDefault;
		}
		private void CargarPredefinidosDocumento()
		{
			propiedadesDoc = new PrySysp13.OpcDoc();
			propiedadesDoc.Cargar(ref idDocumentoActual.Tipo, ref idDocumentoActual.Sucursal);
			accesosLocalizados.iniciar(varbleComun.VarCom.codEmpresa, varbleComun.VarCom.usr, varbleComun.VarCom.strConxSyscod);
			HabilitarOpcionesDocumento();
		}
		private void HabilitarOpcionesDocumento()
		{
//            HabilitarSoporte((propiedadesDoc.TipoSoporteObligatorio.Length > 0 && propiedadesDoc.TipoSoporteObligatorio != "ORP") || datosAuxiliares.tieneDatoDocumento("DocumentoReferencia", propiedadesDoc));

			cmbVendedor.Visible = (datosAuxiliares.tieneDatoDocumento("Vendedor", propiedadesDoc));
			lbVendedor.Visible = cmbVendedor.Visible;

			labNroLote.Visible = (datosAuxiliares.tieneDatoDocumento("NúmeroLote", propiedadesDoc));
			txtNroLote.Visible = labNroLote.Visible;

			btnDescuentos.Visible = (datosAuxiliares.tieneDatoDocumento("DescuentoDocumento", propiedadesDoc));

  //          btnExportacion.Visible = (datosAuxiliares.tieneDatoDocumento("Transporte", propiedadesDoc));

	//        btnPendientes.Visible = true;
			// chequear lectura de parametros en varbl
			//btnContabiliza.Visible = (varbleComun.VarCom.auto.Substring(3, 1) == "1" && propiedadesDoc.noCtbLinea != "X" && propiedadesDoc.SNContabilizar != 0);

			if (!accesosLocalizados.sinRegistro) registrarAccesosLocalizadosDocumento();

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
			btnGraba.Enabled = (!inicio && !docAnulado);
			btnRegistra.Enabled = (!inicio && !docAnulado);
			btnEnviar.Enabled = (modificando && !docAnulado);
			btnCierra.Enabled = !inicio;
			btnConsolida.Enabled = nuevo;

			btnPagos.Enabled = btnGraba.Enabled;
			btnDescuentos.Enabled = btnGraba.Enabled;
			ptoVenta.Enabled = inicio;
			btnPorcentajeIva.Enabled = btnDescuentos.Enabled;
			//btnContabiliza.Enabled = btnGraba.Enabled;
			//btnExportacion.Enabled = btnGraba.Enabled;
			//btnPendientes.Enabled = btnGraba.Enabled;

			btnBarras.Enabled = (!inicio) && !docAnulado;
			btnAgrupa.Enabled = (btnBarras.Enabled && btnBarras.Checked);

			panel1.Enabled = (!inicio);
			malla.Enabled = (!inicio);

			cmbDocumento.Enabled = (!modificando);
			txtcedula.Enabled = (!docAnulado);

			if (!accesosLocalizados.sinRegistro)
			{
				btnGraba.Enabled = ((accesosLocalizados.Crear && operacionEnCurso == 1) || (accesosLocalizados.Modificar && operacionEnCurso == 2));
				btnRegistra.Enabled = (btnGraba.Enabled && btnImprimir.Enabled);
			}

			if (inicio) return;

			if (esSoloConsulta == true)  //|| propiedadesDoc.ClaveEstado == 0)
			{
				btnGraba.Enabled = false;
				btnRegistra.Enabled = false;
				btnElimina.Enabled = false;
				btnAnula.Enabled = false;
				//                if (propiedadesDoc.ClaveEstado == 0) btnElimina.Enabled = (ControlUsuario.Identifica.ToUpper() == "ADMINISTRADOR");
			}
		}

		private void registrarAccesosLocalizadosDocumento()
		{
			accesosLocalizados.cargarAccesoDoc(idDocumentoActual.Tipo);
			if (accesosLocalizados.sinRegistro) return;
			btnNuevo.Visible = accesosLocalizados.Crear;
			btnCopia.Visible = accesosLocalizados.Crear;
			btnConsolida.Visible = accesosLocalizados.Crear;
			btnElimina.Visible = accesosLocalizados.Eliminar;
			btnImprimir.Visible = accesosLocalizados.Imprimir;
			btnAnula.Visible = accesosLocalizados.Anular;

			btnGraba.Visible = (accesosLocalizados.Crear || accesosLocalizados.Modificar);
			btnRegistra.Visible = (btnGraba.Visible && btnImprimir.Visible);


			txtnumero.Enabled = accesosLocalizados.NúmeroDocumento;
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
			//btnContabiliza.Visible = accesosLocalizados.Contabilidad;
			btnPorcentajeIva.Visible = accesosLocalizados.Impuestos;
			btnDescuentos.Visible = accesosLocalizados.DescuentoDocumento;
		}

		//private void HabilitarSoporte(bool tieneSoporte)
		//{
		//    cmbDocumentoSustento.Visible = tieneSoporte;
		//    labSoporteNumero.Visible = tieneSoporte;
		//    labSoporteTipo.Visible = tieneSoporte;
		//    nroDocSoporte.Visible = tieneSoporte;
		//    btnBuscaDocumentoSoporte.Visible = tieneSoporte;
		//    if (propiedadesDoc.TipoSoporteObligatorio.Length > 0)
		//    {
		//        cmbDocumentoSustento.SelectedValue = propiedadesDoc.TipoSoporteObligatorio;
		//        cmbDocumentoSustento.Enabled = false;
		//    }

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

			//using (DataTable dtt = utilBasDatos.utilBasDatos.leerTablas(Ssql, varbleComun.VarCom.strConxAdcom))
			//{
			//    cmbDocumentoSustento.DataSource = dtt;
			//    cmbDocumentoSustento.DisplayMember = "opc_nombre";
			//    cmbDocumentoSustento.ValueMember = "opc_documento";
			//}
		}

		private void BtnSalir_Click(object sender, EventArgs e)
		{
			if (classMenSistem.mensajesErrorDocumento.ConfirmaCerrar()) this.Close();
		}

		private void BuscaCliente(string buscador)
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
				opalex = null;
			}

		}
		private Boolean cargarDatosFactura(string SUC, string TIPO, double IDCLAVE)
		{
			Boolean resp = false;
			if (IDCLAVE != 0)
			{
				datADCDOC = new AdcDoc(varbleComun.VarCom.strConxAdcom);
				datADCDOC = AdcDoc.Buscar(" doc_sucursal = '" + SUC + "' and opc_documento ='" + TIPO + "' and idclavedoc = " + IDCLAVE.ToString());
				if (datADCDOC != null)
				{
					this.malla.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.malla_CellValueChanged);
					cargarDatosCliente(datADCDOC.Doc_codper);
					moverClaseAcontroles();
					if (Convert.ToInt32(datADCDOC.Doc_Estado) == 0) mensajesDocumento.Text = "DOCUMENTO ANULADO : " + datADCDOC.MotivoAnulacion;
					cargarDetalleArticulos(idDocumentoActual.Sucursal, idDocumentoActual.Tipo, idDocumentoActual.idClave, "ADCTRA");
					cargarFormaDePago(idDocumentoActual.Sucursal, idDocumentoActual.Tipo, idDocumentoActual.idClave, "ADCPAG");
					totalizar();
					operacionEnCurso = modificandoRegistro;
					prepararBotones();
					resp = true;
					txtnumero.Enabled = false;
					this.malla.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.malla_CellValueChanged);
				}
			}
			else { }
			return resp;
		}

		private void cargarDetalleArticulos(string suc, string tip, double idClave, string tablatra)
		{
			this.malla.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.malla_CellValueChanged);
			adcDocumentos.armarConsTra dcut = new adcDocumentos.armarConsTra();
			adcDocumentos.diseñarMalla dcut2 = new adcDocumentos.diseñarMalla();

			dtDetalleDocumento = utilBasDatos.utilBasDatos.leerTablas(dcut.armarSqlLecturaTraFacPv(propiedadesDoc, tablatra, suc, tip, idClave), varbleComun.VarCom.strConxAdcom);
			dcut = null;
			if (dtDetalleDocumento == null) return;
			malla.DataSource = dtDetalleDocumento;
			dcut2.diseñarMallaFacPvT(ref malla, ref propiedadesDoc);
			malla.Columns["Existencia"].Visible = existenciaEnLineas;
			this.malla.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.malla_CellValueChanged);

			dcut = null;
			dcut2 = null;
		}
		private void cargarDetalleArticulosConsolidacion(string listaDocumentos)
		{
			adcDocumentos.armarConsTra dcut = new adcDocumentos.armarConsTra();
			adcDocumentos.diseñarMalla dcut2 = new adcDocumentos.diseñarMalla();

			dtDetalleDocumento = utilBasDatos.utilBasDatos.leerTablas(dcut.armarSqlLecturaTraFacConsolida("ADCTRA", listaDocumentos), varbleComun.VarCom.strConxAdcom);
			dcut = null;
			if (dtDetalleDocumento == null) return;
			malla.DataSource = dtDetalleDocumento;
			if (malla.Rows.Count > 0) dcut2.diseñarMallaFacCli(ref malla, ref propiedadesDoc);

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
//            datADCDOC.PuntoVta = valoresPredefinidosSucursal.idPuntoVta;
		}
		private void moverOtrosValores()
		{
			claseDescuentos = new adcDescto.descDocumento();
			claseImpuestos = new TablasSRI.docImpuestos();
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
			datADCDOC.Doc_sucursal = varbleComun.VarCom.suc;
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
			datADCDOC.Doc_venabre = cmbVendedor.SelectedValue.ToString();
			datADCDOC.Doc_DocSop = "";
			datADCDOC.Doc_NumSop = 0;
			datADCDOC.Doc_valor = Convert.ToDecimal(edTotal.Text);
			datADCDOC.AuxVar9 = txtCorreElectronico.Text;

			if (operacionEnCurso == 1)datADCDOC.PuntoVta = valoresPredefinidosSucursal.idPuntoVta;

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

			//datADCDOC.Doc_NroLoteDoc = TexLote.Text
			datADCDOC.Doc_NroIdDoc = txtNroID.Text;
			datADCDOC.Adi_TipoDocSri = propiedadesDoc.TipoSri;
			//datADCDOC.Adi_FechContab = IIf(FechaContab < TxtFecha, TxtFecha, FechaContab)
			//datADCDOC.Adi_CodigoNSR = TexCodigoExoneraRetencion.Text
			//datADCDOC.Adi_SustTrib = DatSustento.BoundText
			//datADCDOC'.Adi_SNDevIva = IIf(DerechoIva.Value = 1, "S", "N")
			datADCDOC.IdClaveDoc = Convert.ToDecimal(idDocumentoActual.idClave);
			datADCDOC.IdClaveDocSop = 0;
			datADCDOC.Doc_docnombre = "";
			datADCDOC.Doc_TipoDoc = propiedadesDoc.TipoDoc;
			datADCDOC.Doc_FechaEfe = Convert.ToDateTime(txtfecha.Text);     //FechaVence.Value
			datADCDOC.Doc_Hora = Convert.ToDateTime(txtfecha.Text);
			datADCDOC.Doc_extension = "";
			datADCDOC.Doc_codusu = varbleComun.VarCom.usr;
			datADCDOC.Doc_valoriva = totalesDocumento.TotIva;
			datADCDOC.Doc_totciva = totalesDocumento.TotCiva;
			datADCDOC.Doc_totsiva = totalesDocumento.TotSiva;
			datADCDOC.Doc_valorabon = totalesDocumento.ValorCon;
			datADCDOC.Doc_DepDes = "";
			datADCDOC.Doc_TotDesArt = totalesDocumento.TotDesArt;
			datADCDOC.Doc_TotDesSer = totalesDocumento.TotDesSer;
			datADCDOC.Doc_TotArtCIva = totalesDocumento.TotArtCIva;
			datADCDOC.Doc_TotArtSIva = totalesDocumento.TotArtSIva;
			datADCDOC.Doc_TotSerCIva = totalesDocumento.TotSerCIva;
			datADCDOC.Doc_TotSerSIva = totalesDocumento.TotSerSIva;
			datADCDOC.Doc_TotAcf = totalesDocumento.TotAcf;
			datADCDOC.Doc_Contado = totalesDocumento.ValorEfec;
			datADCDOC.Doc_Estado = 1;
			datADCDOC.Doc_Oculto = propiedadesDoc.ClaveOculto;
			datADCDOC.Doc_Contabilidad = propiedadesDoc.ClaveContable;
			datADCDOC.Doc_Banco = Convert.ToInt16(propiedadesDoc.ClaveBanco);
			datADCDOC.Doc_Inventario = Convert.ToInt16(propiedadesDoc.ClaveInventario);
			datADCDOC.Doc_Ventas = Convert.ToInt16(propiedadesDoc.ClaveVentas);
			datADCDOC.Doc_Compras = Convert.ToInt16(propiedadesDoc.ClaveCompras);
			datADCDOC.Doc_Activo = Convert.ToInt16(propiedadesDoc.ClaveActivo);
			datADCDOC.Doc_Adicional2 = 0;
			datADCDOC.Doc_NumeroExterno = 0;
			datADCDOC.IdClaveDocSop = 0;
			datADCDOC.Doc_FechaModifica = DateTime.Now;
			datADCDOC.doc_TotDesSiva = totalesDocumento.totdessiva;
			datADCDOC.doc_TotDesCIva = totalesDocumento.totdesciva;
			datADCDOC.Adi_NroAutSri = "";                   //TextNroAutSri
			datADCDOC.ProductoProduccion = "";             //ProductoProduccion.Text
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
			txtnumero.Enabled = true;
			datADCDOC = new AdcDoc(varbleComun.VarCom.strConxAdcom);
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
			idDocumentoActual.idClave = 0;
			esDeLiquidacion = false;
			debeActualizarContacto = false;
			idDocumentoActual = new idDocumento
			{
				fecha = txtfecha.Value
			};
			idDocumentoSoporte = new idDocumento();
			//txtNroID.Text = valoresPredefinidosSucursal.idtributario;
			dtDetalleDocumento = new DataTable();
			malla.DataSource = null;
			//malla.Columns.Clear();
			presentarTotales();
			edTotal.Text = totalesDocumento.TotVta.ToString("#,0.00");
			operacionEnCurso = 0;
			prepararBotones();
			//            InicializarMalla();
		}
		private void InicializarMalla()
		{
			this.malla.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.malla_CellValueChanged);
			adcDocumentos.armarConsTra dcut = new adcDocumentos.armarConsTra();
			dtDetalleDocumento = utilBasDatos.utilBasDatos.leerTablas(dcut.armarSqlLecturaTraFacPv(propiedadesDoc, "adctra", "", "", 0), varbleComun.VarCom.strConxAdcom);
			if (dtDetalleDocumento == null) return;
			malla.DataSource = dtDetalleDocumento;
			dtDetalleDocumento.Rows.Add(dtDetalleDocumento.NewRow());
			//dtt.Dispose();
			adcDocumentos.diseñarMalla dcut2 = new adcDocumentos.diseñarMalla();
			dcut2.diseñarMallaFacPv(ref malla, ref propiedadesDoc);
			dcut2 = null;
			this.malla.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.malla_CellValueChanged);
		}
		private void malla_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex < 0 || saltaEventosMalla == true)
			{
				return;
			}

			string nomCol = malla.Columns[e.ColumnIndex].Name.ToUpper();
			if (nomCol == "TRA_PRECUNI" || nomCol == "TRA_CANTIDAD" || nomCol == "TRA_PORCENDES" || nomCol == "TRA_SNIVA" || nomCol == "TRA_MULTIPLO") totalizar();
		}

		#region EVENTOS DE CONTROLES
		#region EVENTOS DE BOTONES
		private void btnPromocion_Click(object sender, EventArgs e)
		{

		}
		private void btnAgrupa_Click(object sender, EventArgs e)
		{

		}

		private void btnBuscaCliente_Click(object sender, EventArgs e)
		{
			BuscaCliente(txtnombrecliente.Text);
		}
		private void txtfecha_ValueChanged(object sender, EventArgs e)
		{
			idDocumentoActual.fecha = txtfecha.Value;
			ChequearCambioValoresPoFecha();
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
			string tipDoc = cmbDocumento.SelectedValue.ToString();
			string tipBan = "";
			txtnumero.Text = propiedadesDoc.NumeroMayor(ref varbleComun.VarCom.suc, ref tipDoc, ref tipBan, txtNroID.Text, "", varbleComun.VarCom.usr, cmbBodega.SelectedValue.ToString()).ToString();
			operacionEnCurso = 1;
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
			ingdesc.ingresarDescuentos(ref claseDescuentos, varbleComun.VarCom.strConxAdcom, varbleComun.VarCom.suc, nroDescuentosMaximosDocto);
			ingdesc.Dispose();
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
			adcDocumentos.anulaElimina classAnular = new adcDocumentos.anulaElimina();
			if (classAnular.anularDocumento(varbleComun.VarCom.strConxAdcom, varbleComun.VarCom.strConxSyscod, idDocumentoActual, varbleComun.VarCom.usr, esDeLiquidacion, varbleComun.VarCom.nomEmpresa, varbleComun.VarCom.codEmpresa.ToString(), edTotal.Text, "ADCDOC", propiedadesDoc.ComandoExterno)) limpiarDatos();
			classAnular = null;
		}
		private void btnElimina_Click(object sender, EventArgs e)
		{
			adcDocumentos.anulaElimina classAnular = new adcDocumentos.anulaElimina();
			if (classAnular.eliminarDocumento(varbleComun.VarCom.strConxAdcom, varbleComun.VarCom.strConxSyscod, idDocumentoActual, varbleComun.VarCom.usr, esDeLiquidacion, varbleComun.VarCom.nomEmpresa, varbleComun.VarCom.codEmpresa.ToString(), edTotal.Text, "ADCDOC", propiedadesDoc.ComandoExterno)) limpiarDatos();
			classAnular = null;
		}


		#endregion EVENTOS DE BOTONES
		#region EVENTOS DE CAJAS DE TEXTO
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

		private void btnGraba_Click(object sender, EventArgs e)
		{
			if (validarDocumento() == true)
			{
				if (grabarDocumento() == true) { limpiarDatos(); }
			}

		}
		private void btnPagos_Click(object sender, EventArgs e)
		{
			registrarFormaDePagoPredefinida();
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
					DaxMantDirectorio.CreaCliAlex express = new DaxMantDirectorio.CreaCliAlex();
					express.IniCrearAlex(ref tipo, ref codigo);
				}
			}
			if ((codigo + "").Length > 0) cargarDatosCliente(codigo);
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
			BuscadorDocumentos.buscadorDoc progBus = new BuscadorDocumentos.buscadorDoc(varbleComun.VarCom.strConxAdcom,varbleComun.VarCom.strConxSyscod);
			DateTime queFecha = DateTime.Now;
			progBus.IniciaBusqueda( "FAC", "", "", queFecha, ref SUC, ref TIP, ref Numero, ref Idclave, false, "", "", "", "ADCDOC");
			if (Idclave != 0) 
			{
				idDocumentoParaGenerar.Sucursal = SUC;
				idDocumentoParaGenerar.Tipo = TIP;
				idDocumentoParaGenerar.idClave = Idclave;
				copiarDocumento(idDocumentoParaGenerar,false); 
			}
			progBus = null;
	}
		private void btnConsolida_Click(object sender, EventArgs e)
		{
			string SUC = varbleComun.VarCom.suc;
			string TIP = "";
			double Idclave = 0;
			double Numero = 0;
			BuscadorDocumentos.buscadorDoc progBus = new BuscadorDocumentos.buscadorDoc(varbleComun.VarCom.strConxAdcom,varbleComun.VarCom.strConxSyscod);
			DateTime queFecha = DateTime.Now;
			idDocumentoParaGenerar = new idDocumento
			{
				Lista = progBus.IniciaConsolidacion(adcDocumentos.ConsolidaDoc.tiposDoctsConsolidaSql(varbleComun.VarCom.strConxAdcom), codCliente, "", queFecha, ref SUC, ref TIP, ref Numero, ref Idclave, false, "", "", "", "ADCDOC")
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


		private void cmbDocumento_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (idDocumentoActual.Sucursal == "") return;
			
			//llenarComboDocReferencia();
		}
		private void BtnAbre_Click(object sender, EventArgs e)
		{
			BuscadorDocumentos.buscadorDoc progBus = new BuscadorDocumentos.buscadorDoc(varbleComun.VarCom.strConxAdcom,varbleComun.VarCom.strConxSyscod);
			idDocumentoActual.Sucursal = varbleComun.VarCom.suc;
			DateTime queFecha = DateTime.Now;
			progBus.IniciaBusqueda( claseDocDefault, "", cmbDocumento.SelectedValue.ToString(), queFecha, ref idDocumentoActual.Sucursal, ref idDocumentoActual.Tipo, ref idDocumentoActual.numero, ref idDocumentoActual.idClave, false, cmbDocumento.SelectedValue.ToString(), "", "", "ADCDOC");
			if (idDocumentoActual.idClave == 0)
			{
				idDocumentoActual.Sucursal = varbleComun.VarCom.suc; return;
			}
			if (idDocumentoActual.Sucursal.ToUpper() != varbleComun.VarCom.suc.ToUpper()) { mensajesErrorDocumento.documentosNoDeOtraSucursal(varbleComun.VarCom.sucNom); return; }
			if (idDocumentoActual.idClave != 0) cargarDatosFactura(idDocumentoActual.Sucursal, idDocumentoActual.Tipo, idDocumentoActual.idClave);
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
			 impresionVerificacion.verificarExistenciaDocumentoFac(ref idDocumentoActual, varbleComun.VarCom.strConxAdcom,"ADCDOC",txtNroID.Text);
			if (idDocumentoActual.idClave > 0) cargarDatosFactura(idDocumentoActual.Sucursal ,idDocumentoActual.Tipo, idDocumentoActual.idClave);
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
			Int32 colOk=0;
			

			if  (col < malla.Columns.Count)
			{
				for (int i=col+1;i<malla.Columns.Count -1;i++)
				{
					if (malla.Columns[i].Visible == true && malla.Columns[i].ReadOnly == false && malla.Columns[i].Name.ToUpper() != "DESCRIPCIÓN") { colOk = i; break; }
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
					col=colOk;
				}
				malla.CurrentCell = malla.Rows[row].Cells[col];
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

			if (nombreCelda == "TRA_PRECUNI" && keyData >= Keys.F2 && keyData <= Keys.F6)
			{
				DataGridViewRow row = malla.CurrentRow;
				daxMallaDatos.docMallaArticulo preVta = new docMallaArticulo();
				Int32 quePrecio = 0;
				cell.Value =   cargarPrecios.CargarPrecioVta (Convert.ToInt16(keyData), malla.CurrentRow.Cells["tra_Codigo"].Value.ToString(), claseImpuestos.impstoPorcentaje1,ref quePrecio,"", row.Cells["tra_Medida"].Value.ToString(),"", nroDigitosEnPrecios);
				totalizar();
			}
			else if (nombreCelda == "TRA_CODIGO")
			{
				try
				{
					mallaArticulo.bodega = cmbBodega.SelectedValue.ToString();
				}
				catch { }
				saltaEventosMalla = true;
				
				mallaArticulo.digCostos = nroDigitosEnCostos;
				mallaArticulo.digPrecios = nroDigitosEnPrecios;
				mallaArticulo.fechaDoc = Convert.ToDateTime(txtfecha.Text);
				mallaArticulo.impIva = claseImpuestos.impstoPorcentaje1;
				mallaArticulo.codCliente = codCliente;
				mallaArticulo.sucursal = varbleComun.VarCom.suc;
				mallaArticulo.tipoDoc = cmbDocumento.SelectedValue.ToString();
				mallaArticulo.numDoc = txtnumero.Text;


				if (keyData == Keys.F2)
				{
					dato = mallaArticulo.BuscarArticuloSimple(malla.CurrentCell.Value.ToString());
					if (mallaArticulo.CargarArticulo(malla, ref propiedadesDoc, dato, opalex.TipoCliente, txtfecha.Text, propiedadesDoc.Documento, idDocumentoActual.idClave) == false) cell.Value = ""; keyData = Keys.Cancel;
				}
				else if (keyData == Keys.F11)
				{
					dato = mallaArticulo.BuscarArticulo(malla.CurrentCell.Value.ToString());
					if (mallaArticulo.CargarArticulo(malla, ref propiedadesDoc, dato, opalex.TipoCliente, txtfecha.Text, propiedadesDoc.Documento, idDocumentoActual.idClave) == false) cell.Value = ""; keyData = Keys.Cancel;
				}
				else if (keyData == Keys.Return && dato.Length > 0)
				{
					if (mallaArticulo.CargarArticulo(malla, ref propiedadesDoc, dato, opalex.TipoCliente, txtfecha.Text, propiedadesDoc.Documento, idDocumentoActual.idClave) == false) cell.Value = ""; keyData = Keys.Cancel;
				}
				else if (keyData == Keys.F3)
				{
					DaxConceptos.classConceptos buscserv = new DaxConceptos.classConceptos();
					dato = buscserv.iniciaBuscador(varbleComun.VarCom.strConxAdcom, "", "V", false, false);
					if (dato != "") mallaArticulo.CargarServicios(dato, ref malla, claseImpuestos.impstoPorcentaje1, nroDigitosEnPrecios, Convert.ToDateTime(txtfecha.Text), ref propiedadesDoc);
				}

				//        VerificarClasificadoresContablesArticulo dato
			}
			else if (nombreCelda == "DOC_BODEGA")
			{

			}    //        VerificarClasificadoresContablesArticulo dato

			if (cell.Value.ToString() != "") keyData = Keys.Return; else keyData = Keys.Cancel;
			saltaEventosMalla = false;
			totalizar();
			mallaArticulo = null;
			return resp;
		}

		private void registrarFormaDePagoPredefinida()
		{
			FormasPagoDax.MntPago PagosDoc = new FormasPagoDax.MntPago();
			string pagoPredefinido = "EFE";
			if (clasePagos.pagosDelDocumento.Count < 1)
			{
				if (opalex.FormaPago != null && opalex.FormaPago.Length > 0) { pagoPredefinido = opalex.FormaPago; }
				else
				{
					if (formaPagoPredefinidaVtas.Length > 0) pagoPredefinido = formaPagoPredefinidaVtas;  
				}
			}
			PagosDoc.INIPagos(idDocumentoActual.idClave, ref clasePagos, opalex.codigo, idDocumentoActual.Sucursal, propiedadesDoc.TipoDoc, txtfecha.Text, false, idDocumentoActual.Tipo, Convert.ToDouble("0" + txtnumero.Text), pagoPredefinido, Convert.ToDouble("0"+edTotal.Text), false);
			PagosDoc = null;
		}


		private void imprimirDocumento()
		{
			ImprDoct.ImprimirDoc progimp = new ImprDoct.ImprimirDoc();
			//adcDocumentos.impresionVerificacion  FImprimeDocumento = new adcDocumentos.impresionVerificacion ();
			impresionVerificacion.ImpDoc(idDocumentoActual.idClave, varbleComun.VarCom.suc, cmbDocumento.SelectedValue.ToString(), Convert.ToDouble(txtnumero.Text), "A", "F", propiedadesDoc.TipoDoc, "FELFAC");
			progimp.claveSri = claveSri;
			progimp.CorreoElectronico = txtCorreElectronico.Text;
		}


		private void btnEstadoCta_Click(object sender, EventArgs e)
		{
			if (codCliente =="") return;
			MntPago progG = new MntPago();
			string lasfacturas ="";
			double ValorAplicaciones = 0;
			progG.DocsPendientes ( permiteCruceDocOtraSucursal,ref lasfacturas, idDocumentoActual.Sucursal, idDocumentoActual.Tipo, idDocumentoActual.idClave , codCliente ,txtnombrecliente.Text , "" , Convert.ToDouble(edTotal.Text) ,ref ValorAplicaciones, "", true);
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

			adcCtasCorrientes.frmAplicacionesDcto prog = new adcCtasCorrientes.frmAplicacionesDcto(varbleComun.VarCom.strConxAdcom, idDocumentoActual.idClave ,idDocumentoActual.Tipo,Convert.ToInt64 (idDocumentoActual.numero) , 0,txtfecha.Text, "", posicion, idDocumentoActual.Sucursal);
			prog.ShowDialog();
		}

		private void copiarDocumento(idDocumento idDocCopiar, Boolean esGenerar = false)
		{
			utilDoc.cadenaConexion = varbleComun.VarCom.strConxAdcom;
			datADCDOC = new AdcDoc(varbleComun.VarCom.strConxAdcom);
			string tabladoc = "";
			string tablatra = "";
			string tablapagos = "ADCPAG";
			utilDoc.tablasDeDatos ( idDocCopiar.Tipo, ref tabladoc, ref tablatra);
			string Ssql = "doc_sucursal = '" + idDocCopiar.Sucursal + "' and opc_documento ='" + idDocCopiar.Tipo + "' and idclavedoc = " + idDocCopiar.idClave.ToString();
			
			if (tabladoc.ToUpper() == "ADCDOC")
			{
				datADCDOC = AdcDoc.Buscar(Ssql);
			}
			else
			{
				tablapagos = "ADCPAGPRO";
				DataTable dt = utilBasDatos.utilBasDatos.leerTablas("select * from adcDOCpro where " + Ssql, varbleComun.VarCom.strConxAdcom);

				if (dt.Rows.Count > 0) { DataRow DROW = dt.Rows[0]; datADCDOC = AdcDoc.row2AdcDoc(DROW);}
			}
				if (datADCDOC != null)
				{
					datADCDOC.IdClaveDoc = 0;
					datADCDOC.Doc_numero = Convert.ToDecimal(txtnumero.Text);

					this.malla.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.malla_CellValueChanged);
					if (esGenerar == false)
					{
						if (MessageBox.Show("Desea copiar la cabezera del documento ? ", "Copiar datos documento", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
						{
							cargarDatosCliente(datADCDOC.Doc_codper);
							moverCabezera();
						}
					}
					else
					{
						cargarDatosCliente(datADCDOC.Doc_codper);
						moverCabezera();
					}
					moverOtrosValores();
					cargarDetalleArticulos(idDocCopiar.Sucursal, idDocCopiar.Tipo, idDocCopiar.idClave, tablatra);
					cargarFormaDePago(idDocCopiar.Sucursal, idDocCopiar.Tipo, idDocCopiar.idClave,tablapagos);
					LlenarIdDocumento(ref idDocumentoActual);
					idDocumentoActual.idClave = 0;
					//inicializarUtilidadDocumentos();
					totalizar();
					prepararBotones();
					this.malla.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.malla_CellValueChanged);
				}            
		}
		private void consolidarDocumentos(idDocumento idDocCopiar)
		{
			datADCDOC = new AdcDoc(varbleComun.VarCom.strConxAdcom);
			string tablapagos = "ADCPAG";
			string Ssql = "doc_sucursal = '" + idDocCopiar.Sucursal + "' and opc_documento ='" + idDocCopiar.Tipo + "' and idclavedoc = " + idDocCopiar.idClave.ToString();

			datADCDOC = AdcDoc.Buscar(Ssql);
			if (datADCDOC != null)
			{
				datADCDOC.IdClaveDoc = 0;
				datADCDOC.Doc_numero = Convert.ToDecimal(txtnumero.Text);

				this.malla.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.malla_CellValueChanged);
				if (MessageBox.Show("Desea copiar la cabezera del documento ? ", "Copiar datos documento", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
				{
					cargarDatosCliente(datADCDOC.Doc_codper);
					moverCabezera();
				}
				moverOtrosValores();
				cargarDetalleArticulosConsolidacion (idDocCopiar.Lista);
				cargarFormaDePago(idDocCopiar.Sucursal, idDocCopiar.Tipo, idDocCopiar.idClave, tablapagos);
				LlenarIdDocumento (ref idDocumentoActual);
				idDocumentoActual.idClave = 0;
				//inicializarUtilidadDocumentos();
				totalizar();
				prepararBotones();
				this.malla.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.malla_CellValueChanged);
			}

		}
		private void malla_DataError(object sender, DataGridViewDataErrorEventArgs e)
		{
			MessageBox.Show("Error de dato digitado, el valor registrado es inválido");
		}

		private Boolean validarDocumento ()
		{
			double PagoCredito=0;
			//adcDocumentos.impresionVerificacion  util = new adcDocumentos.impresionVerificacion();
			//daxMallaDatos.validacionDocumento validar = new daxMallaDatos.validacionDocumento();
			if (Convert.ToDouble("0" + txtnumero.Text) == 0) { mensajesErrorDocumento.MensajeNumeroDoc(); txtnumero.Focus(); return false; }
			ValidacionDocumentos.ValidacionGeneral.validarFecha(txtfecha.Text,varbleComun.VarCom.usr);
			if (opalex.codigo == "" || codCliente == "" || txtcedula.Text == "") { mensajesErrorDocumento.ElCodigoNoExiste("C"); return false;}

			//if (propiedadesDoc.TipoSoporteObligatorio != "")
			//{
			//	if (cmbDocumentoSustento.Text  == "" || nroDocSoporte.Text == "")
			//	{
			//		mensajesErrorDocumento.SinDocumentoReferencia(); return false;
			//	}
			//	else
			//	{
			//		if (clasref.LeerDocumentoReferencial(varbleComun.VarCom.suc, cmbDocumentoSustento.SelectedValue.ToString(), nroDocSoporte.Text,  idDocumentoActual) == false)
			//		{ clasref = null; mensajesErrorDocumento.SinDocumentoReferencia(); return false; }
			//	}
			//}
			if (validarIngresoDetalle ()==false) {mensajesErrorDocumento.sinArtículosOservicios(); return false;}
			
			moverDatosClase();
			//daxMallaDatos.validacionDocumento  valdoc = new daxMallaDatos.validacionDocumento ();
			string docsustento = "";
			//try
			//{
			//    docsustento = cmbDocumentoSustento.SelectedValue.ToString();
			//}
			//catch { }
			if (ValidacionDocumentos.ValidacionGeneral.ControlValidacionFacCli (ref malla, ref propiedadesDoc, clasref, txtfecha.Text, varbleComun.VarCom.suc, varbleComun.VarCom.strConxAdcom, varbleComun.VarCom.strConxSyscod, idDocumentoActual.idClave, cmbBodega.SelectedValue.ToString(), txtnumero.Text, entregasPendientes, varbleComun.VarCom.suc,docsustento, "") == false) return false;            

		   if (clasePagos.pagosDelDocumento.Count > 0)
		   {
			   double TotalPago = 0;
			   MntPago dp = new MntPago();
			   foreach (pagosDocumento.pagoDoc Pago in clasePagos.pagosDelDocumento )
				{
					TotalPago += Pago.Valor ;
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

			if (opalex.limitecredito > 0)
			{
				double saldoCliente = 0;
				string cod = "exec ADC_CCINDU '" + opalex.codigo + "','" + "01/01/1901" + "','" + txtfecha.Text + "'," + 0 + ",0,0,'C','',0,'" + varbleComun.VarCom.suc + "','" + propiedadesDoc.Documento + "'," + idDocumentoActual.idClave.ToString();
				DataTable dt = utilBasDatos.utilBasDatos.leerTablas(cod, varbleComun.VarCom.strConxAdcom);
				if (dt.Rows.Count > 0) saldoCliente = Convert.ToDouble(dt.Rows[0]["Saldo"].ToString());
				if (saldoCliente + PagoCredito > opalex.limitecredito)
				{
					mensajesErrorDocumento.ventaExcedeCredito();
					return false;
				}
			}

			return true;            
		}                                            
		private Boolean validarIngresoDetalle()
		{
			Boolean ret = false;
			foreach (DataGridViewRow row in malla.Rows)
			{
				if (row.Cells["Tra_Codigo"].Value.ToString() != "" ) return true;
			}
			return ret;
		}

		private Boolean grabarDocumento()
		{
			malla.EndEdit();
			Boolean RESP = true;

			string res = "";
			if (debeActualizarContacto) 
			{ 
				if(MessageBox.Show("Se han cambiado datos del cliente, confirma Actualizar el registro ?","Actualizar datos de Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
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
					datADCDOC.Doc_numero = Convert.ToDecimal( fijnum.nroDeDocumento(propiedadesDoc.tablaDatosDoc, propiedadesDoc.CodDuplica, Convert.ToBoolean(propiedadesDoc.NroAutomatico), Convert.ToDouble(txtnumero.Text), varbleComun.VarCom.strConxAdcom, varbleComun.VarCom.suc, cmbDocumento.SelectedValue.ToString(),txtnumero.Text, cmbBodega.SelectedValue.ToString(), codCliente, txtNroID.Text));
					if (datADCDOC.Doc_numero == 0) return false;
					txtnumero.Text = datADCDOC.Doc_numero.ToString();
					res = datADCDOC.Crear();
					idDocumentoActual.idClave = Convert.ToDouble(datADCDOC.IdClaveDoc);
					if (res.Substring(0, 3) != "ERR") { grabarAdctra(); }
					string tipDoc = cmbDocumento.SelectedValue.ToString();
					string tipBan = "";
					if (idDocumentoActual.idClave != 0) propiedadesDoc.GuardarNumero (ref varbleComun.VarCom.suc, ref tipDoc, ref tipBan, txtNroID.Text, "", varbleComun.VarCom.usr, cmbBodega.SelectedValue.ToString()); ;
					ClaveElectronica.actualizarClaveElectronica(datADCDOC);
				}
				else
				{
					res = datADCDOC.Actualizar();
					if (res.Substring(0, 3) != "ERR") { grabarAdctra(); }
					//datADCDOC.Putil.guardarNumeroDocumento("", Convert.ToDouble(txtnumero.Text));
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
		private void grabarAdctra()
		{
			grabMallTra.grabarMallaAdctra(malla, datADCDOC,varbleComun.VarCom.strConxAdcom);
		}

		private void totalizar()
		{
			this.malla.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.malla_CellValueChanged);
			if (claseImpuestos.cambiadoManual == false)
			{
				if (claseImpuestos.impstoPorcentaje1 == 0 || claseImpuestos.impstoFechaIni1 > txtfecha.Value || claseImpuestos.impstoFechaFin1 < txtfecha.Value) claseImpuestos.cargar(varbleComun.VarCom.strConxIvaret , txtfecha.Value);
			}
			totalesDocumento = new adcDocumentos.docTotals();
			edTotal.Text = Convert.ToString(totalesDocumento.totalizar(malla,claseImpuestos, claseDescuentos, clasePagos,propiedadesDoc,nroDigitosEnPrecios ,nroDigitosEnCostos ));
			presentarTotales();
			this.malla.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.malla_CellValueChanged);
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
			string ssql = "update identificacion set correoElectrónico = '"+txtCorreElectronico.Text+"' where codigo = '"+codCliente+"'";
			using (SqlConnection conn = new SqlConnection (varbleComun.VarCom.strConxAdcom))
			{
				conn.Open();
				using (SqlCommand comm = new SqlCommand (ssql,conn))
				{
					comm.ExecuteNonQuery();
				}
			}
		}
		private void LlenarIdDocumento(ref idDocumento docmtoActual)
		{
			docmtoActual.Sucursal=varbleComun.VarCom.suc ;
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
			totalizar();            
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
			string nvoIva = progBus.Buscar(varbleComun.VarCom.strConxIvaret , ssql, "porcentaje", "porcentaje", "", "Seleccionar porcentaje IVA", "");
			if (MessageBox.Show("Confirma cambiar el porcentaje del IVA en el documento ?", "Cambiar porcentaje del IVA", MessageBoxButtons.YesNo, MessageBoxIcon.Question  ) == DialogResult.No) return;
			claseImpuestos.cambiadoManual = true;
			claseImpuestos.impstoPorcentaje1 = Convert.ToDouble("0" + nvoIva);
			totalizar();
		}

		private void ptoVenta_Click(object sender, EventArgs e)
		{
			string ssql = " select Pto_codigo as Id, Pto_nombre as NombrePuntoVta from emp_ptovta where emp_codigo = '" + varbleComun.VarCom.codEmpresa + "' and suc_codigo = '" + varbleComun.VarCom.suc + "'";
			Buscar.frmBuscar busca = new Buscar.frmBuscar();
			string pv = busca.Buscar(varbleComun.VarCom.strConxSyscod, ssql, "Id", "NombrePuntoVta", "", "PUNTOS DE VENTA");
		}

		private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
		{
			recuperandoItem();
           
		}
		private void recuperandoItem()
		{
			if (malla.Rows.Count == 0) return;
			if (malla.Rows[0] == null) return;
			if (malla.Rows.Count < 1) malla.Rows.Add();
			if (listView1.SelectedItems.Count < 1) return;
			ListViewItem item = listView1.SelectedItems[0];
			//malla.Rows[0].Cells["CODIGO"].Value = item.ImageIndex;
			malla.Rows[malla.Rows.Count - 1].Cells["tra_CODIGO"].Value = item.Name;
			if(item.Name.Length > 0)
			{
				Message ms=new Message();
				malla.Focus();
				malla.CurrentCell = malla.Rows[malla.Rows.Count - 1].Cells["tra_CODIGO"];
				ProcessCmdKey(ref ms, Keys.Enter);
			}
			//malla.Rows[0].Cells["Descripcion"].Value = item.Text;

			//malla.Rows[0].Cells["CODIGO"].Value = item.SubItems[0];
			//malla.Rows[0].Cells["CODIGO"].Value = item.SubItems[1];
			//malla.Rows[0].Cells["CODIGO"].Value = item.SubItems[2];
		}

		private void cmbBodega_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void listView1_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

        private void listView1_Click(object sender, EventArgs e)
        {
            recuperandoItem();
        }
        //private void toolStripButton1_Click(object sender, EventArgs e)
        //{
        //    if (mallaRecibidos.Rows.Count == 0 && splitContainer1.Panel2Collapsed == true)
        //    {
        //        if (mallaRecibidos.Rows.Count == 0) llenarPartePago();
        //    } 
        //    splitContainer1.Panel2Collapsed = !(splitContainer1.Panel2Collapsed);
        //}
        //private void llenarPartePago()
        //{
        //    string ssql = "select art_codigo, art_nombre as Producto,0.00 as Cantidad,art_precvta1 as valor from AdcArt where art_presentaInmediato = 1 and Art_snmed = 1";
        //    DataTable dt = new DataTable();
        //    SqlDataAdapter da = new SqlDataAdapter(ssql, varbleComun.VarCom.varbleComun.VarCom.strConxAdcom);
        //    da.Fill(dt);
        //    mallaRecibidos.DataSource = dt;
        //    mallaRecibidos.Columns["art_codigo"].Visible = false;
        //}
        //private void sumarPartePago()
        //{
        //    double total = 0;
        //    foreach (DataGridViewRow  row in mallaRecibidos.Rows)
        //    {
        //        try { total += Convert.ToDouble(row.Cells["valor"].Value); }catch { }
        //    }
        //    txtTotalPartePago.Text = total.ToString("######0.00");
        //}

    }
}