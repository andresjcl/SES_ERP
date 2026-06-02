using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using classMenSistem;
using ClassPresp;
using ClassDoc;
using adcDocumentos;

namespace adcDocumentos
{
    public partial class FormMovPrep : Form
    {        
        PrySysp13.OpcDoc propiedadesDoc;
        DaxMantDirectorio.DirectorioAlex opalex = new DaxMantDirectorio.DirectorioAlex();
        ClassDoc.AdcDocPro datDocPresp;
        //impresionVerificacion dcu = new impresionVerificacion();
        daxAccs.propiedadesDaxAuto accesosLocalizados = new daxAccs.propiedadesDaxAuto();
        string claseDocDefault = "CMP";
        string tipoDocDefault = "CMP";

        // adcArticulo.AdcArt propiedadesArticulo = new adcArticulo.AdcArt();
        DataTable dtDetalleDocumento = new DataTable();

        adcDocumentos.docTotals totalesDocumento = new adcDocumentos.docTotals();        

        bool iniciaConNuevoDOc = false;
        Boolean esSoloConsulta = false;

        idDocumento idDocumentoActual = new idDocumento();
        idDocumento idDocumentoSoporte = new idDocumento();
        idDocumento idDocumentoParaGenerar = new idDocumento();
        
        string claveSri = "";
        string codCliente = "";
        Boolean saltarEventoNumero = false;
        Boolean saltaEventosMalla = false;

        // valores predefinidos en la empresa

//        valoresPredefinidosSucursal PredefinidosSucursal = new valoresPredefinidosSucursal();
//        Boolean existenciaEnLineas = false;

        int operacionEnCurso = 0; // 0 sin operacion delcarada, 1 nuevo registro, 2 modificando registro
        int sinOperacion = 0;
        int nuevoRegistro = 1;
        int modificandoRegistro = 2;

        public FormMovPrep(string clasdef,string tipdef,bool nuevo=false, Boolean esConsulta=false,Boolean generarFactura = false, Boolean desdeEstdoCta = false, idDocumento idDocViene=null)
        {
            InitializeComponent();
            try
            {
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
                    idDocumentoParaGenerar = idDocViene;
                }
                else
                {
                    idDocumentoActual.Sucursal = varbleComun.VarCom.suc;
                    idDocumentoActual.Tipo = tipoDocDefault;
                    idDocumentoActual.familia = claseDocDefault;
                }
            }catch(Exception ee) { MessageBox.Show(ee.Message); }
        }
        private void CargarValoresIniciales(string tipdef)
        {
            this.txtfecha.ValueChanged -= new System.EventHandler(this.txtfecha_ValueChanged);
            this.Text = "MANTENIMIENTO DOCUMENTOS PARA CAMBIO DE PRESUPUESTOS : " + varbleComun.VarCom.nomEmpresa;

            if (tipdef.Length > 0) tipoDocDefault = tipdef; else tipoDocDefault = "CMP";
            txtfecha.Value = DateTime.Now;
            idDocumentoActual.Tipo = tipoDocDefault;

            //cargaValoresPredefinidosEmpresa();
            valoresPredefinidosSucursal.cargarValores();
            CargarPredefinidosDocumento();
            this.txtfecha.ValueChanged += new System.EventHandler(this.txtfecha_ValueChanged);
        }
        private void formFacPv_Load(object sender, EventArgs e)
        {
            if (idDocumentoActual.idClave != 0)
            {
                CargarDatosDocumento(idDocumentoActual.Sucursal,idDocumentoActual.Tipo,idDocumentoActual.idClave);
            }
            else if (idDocumentoParaGenerar.idClave > 0)
            {
                iniciarNuevoDocumento();
                copiarDocumento ( idDocumentoParaGenerar,true);
            }
            else
            {
                if (iniciaConNuevoDOc) iniciarNuevoDocumento();
            }
            prepararBotones();
        }

   //     private void cargaValoresPredefinidosEmpresa()
   //     {
   //         DataTable dt = new DataTable();
   //         dt = varbleComun.VarCom.leeParametrosEmp("par_DigitosPrecios,par_DigitosCostos,Par_DocPrincipalVta,par_CruceDocSucursal,Par_AcfNumNiv,Par_roltur");
   //         nroDigitosEnPrecios = Convert.ToInt16(dt.Rows[0]["par_DigitosPrecios"].ToString());
   //         nroDigitosEnCostos = Convert.ToInt16(dt.Rows[0]["par_DigitosCostos"].ToString());
   //         formaPagoPredefinidaVtas = dt.Rows[0]["Par_DocPrincipalVta"].ToString();
   //         permiteCruceDocOtraSucursal = Convert.ToBoolean(dt.Rows[0]["par_CruceDocSucursal"]);
   //         nroDescuentosMaximosDocto = Convert.ToInt16(dt.Rows[0]["Par_AcfNumNiv"].ToString());
   //         if (Convert.ToInt16(dt.Rows[0]["Par_roltur"]) == 99)
			//{
			//	existenciaEnLineas = true;
			//} else
			//{
			//	existenciaEnLineas = false;
			//}

			//dt.Dispose();
   //         tieneComprobantesElectronicos = impresionVerificacion.validaComprobantesElectronicos(varbleComun.VarCom.pathAppl);
            
   //     }
        private void LlenarCombos()
        {
            DaxCombobx.CargCmbBox cmb = new DaxCombobx.CargCmbBox();
            cmb.DaxCombosDoc(claseDocDefault , tipoDocDefault , false,varbleComun.VarCom.strConxAdcom, ref cmbDocumento);
            cmbDocumento.SelectedValue = tipoDocDefault;
        }
        private void CargarPredefinidosDocumento()
        {
            propiedadesDoc = new PrySysp13.OpcDoc();
            propiedadesDoc.Cargar(ref idDocumentoActual.Tipo, ref idDocumentoActual.Sucursal);
            accesosLocalizados.iniciar(varbleComun.VarCom.codEmpresa, varbleComun.VarCom.usr, varbleComun.VarCom.strConxSyscod);
        }
		private void prepararBotones()
		{
			Boolean inicio = (operacionEnCurso == sinOperacion);
			Boolean nuevo = (operacionEnCurso == nuevoRegistro);
			Boolean modificando = (operacionEnCurso == modificandoRegistro);
			Boolean docAnulado = false;
			try
			{
				docAnulado = (datDocPresp.Doc_Estado == 0 && modificando);
			}
			catch { }

			btnAbre.Enabled = inicio;
			btnNuevo.Enabled = inicio;

			btnCopia.Enabled = nuevo;

			btnElimina.Enabled = modificando;
			btnGraba.Enabled = (!inicio && !docAnulado);
			btnRegistra.Enabled = (!inicio && !docAnulado);
			btnEnviar.Enabled = (modificando && !docAnulado);
			btnCierra.Enabled = !inicio;
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
				//                if (propiedadesDoc.ClaveEstado == 0) btnElimina.Enabled = (ControlUsuario.Identifica.ToUpper() == "ADMINISTRADOR");
			}
		}

		private void registrarAccesosLocalizadosDocumento()
        {                    
            accesosLocalizados.cargarAccesoDoc(idDocumentoActual.Tipo);
			if (accesosLocalizados.sinRegistro) return;
            btnNuevo.Visible = accesosLocalizados.Crear;
            btnCopia.Visible = accesosLocalizados.Crear;
			btnElimina.Visible = accesosLocalizados.Eliminar;
			btnImprimir.Visible = accesosLocalizados.Imprimir;

			btnGraba.Visible = (accesosLocalizados.Crear || accesosLocalizados.Modificar);
			btnRegistra.Visible = (btnGraba.Visible && btnImprimir.Visible);


			txtnumero.Enabled = accesosLocalizados.NúmeroDocumento;
            txtfecha.Enabled = accesosLocalizados.FechaDocumento;
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
                if (codigo.Length > 0 )
                {
                    codCliente = opalex.codigo ;
                    txtcedula.Text = opalex.CiRuc ;
                    txtnombrecliente.Text = opalex.NombreImpresion ;
                }
            }
            if (codigo == "")
            {
                codCliente = "";
                txtcedula.Text = "";
                txtnombrecliente.Text = "";
                opalex = null;
            }
            
        }
        private Boolean CargarDatosDocumento(string SUC, string TIPO, double IDCLAVE )
        {            
            Boolean resp = false;
            if (IDCLAVE != 0)
            {
                datDocPresp = new AdcDocPro (varbleComun.VarCom.strConxAdcom);
                datDocPresp = AdcDocPro.Buscar (" doc_sucursal = '" + SUC + "' and opc_documento ='" + TIPO + "' and idclavedoc = " + IDCLAVE.ToString());
                if (datDocPresp != null)
                {
                    this.malla.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.malla_CellValueChanged);
                    cargarDatosCliente(datDocPresp.Doc_codper);
                    moverClaseAcontroles();
                    if (Convert.ToInt32(datDocPresp.Doc_Estado) == 0) mensajesDocumento.Text = "DOCUMENTO ANULADO : " + datDocPresp.MotivoAnulacion ;
                    cargarDetallePresupuestos(idDocumentoActual.Sucursal, idDocumentoActual.Tipo, idDocumentoActual.idClave, "ADCDIAPResp");
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

        private void cargarDetallePresupuestos(string suc, string tip, double idClave,string tablatra)
        {
            this.malla.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.malla_CellValueChanged);
            adcDocumentos.armarConsTra  dcut = new adcDocumentos.armarConsTra ();
            adcDocumentos.diseñarMalla dcut2 = new adcDocumentos.diseñarMalla();
            dtDetalleDocumento = utilBasDatos.utilBasDatos.leerTablas(dcut.armarSqlLecturaMovPrep(propiedadesDoc, "AdcDiaPresp", suc , tip, idClave), varbleComun.VarCom.strConxAdcom);
            dcut = null;
            if (dtDetalleDocumento == null) return;
            malla.DataSource = dtDetalleDocumento;
            dcut2.diseñarMallaMovPrep(ref malla, ref propiedadesDoc);
            this.malla.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.malla_CellValueChanged);

            dcut = null;
            dcut2 = null;
        }
        private void moverClaseAcontroles()
        {
            moverCabezera();
            //moverOtrosValores();
        }
        private void moverCabezera()
        {

            idDocumentoActual.idClave = Convert.ToDouble(datDocPresp.IdClaveDoc);
            codCliente = datDocPresp.Doc_codper;

            txtnumero.Text = datDocPresp.Doc_numero.ToString();
            txtfecha.Text = datDocPresp.Doc_fecha.ToShortDateString();
            txtcedula.Text = datDocPresp.Doc_CiRuc;
            txtnombrecliente.Text = datDocPresp.Doc_NombreImp;
            txtDetalle.Text  = datDocPresp.Doc_detalle ;
        }
        private void moverDatosClase()
        {
            datDocPresp.Doc_sucursal =  varbleComun.VarCom.suc;
            datDocPresp.Opc_documento = cmbDocumento.SelectedValue.ToString();
            datDocPresp.Doc_numero = Convert.ToDecimal( txtnumero.Text);
            datDocPresp.Doc_fecha = Convert.ToDateTime(txtfecha.Text) ;           
            datDocPresp.Doc_codper = codCliente ;
            datDocPresp.Doc_CiRuc = txtcedula.Text ;
            datDocPresp.Doc_NombreImp = txtnombrecliente.Text;
            datDocPresp.Doc_detalle = txtDetalle.Text ;
            datDocPresp.Doc_DocSop = "";
            datDocPresp.Doc_NumSop = 0;
            datDocPresp.Doc_valor = Convert.ToDecimal(edTotal.Text);

            datDocPresp.IdClaveDoc = Convert.ToDecimal(idDocumentoActual.idClave);
            datDocPresp.IdClaveDocSop = 0;
            datDocPresp.Doc_docnombre = propiedadesDoc.nombre;
            datDocPresp.Doc_TipoDoc = propiedadesDoc.TipoDoc;
            datDocPresp.Doc_FechaEfe = Convert.ToDateTime(txtfecha.Text);     //FechaVence.Value
            datDocPresp.Doc_Hora = DateTime.Now;
            datDocPresp.Doc_codusu = varbleComun.VarCom.usr;
            datDocPresp.Doc_Estado = 1;
            datDocPresp.Doc_Oculto = propiedadesDoc.ClaveOculto;
            datDocPresp.Doc_Contabilidad = propiedadesDoc.ClaveContable;
            datDocPresp.Doc_Banco = Convert.ToInt16(propiedadesDoc.ClaveBanco);
            datDocPresp.Doc_Inventario = Convert.ToInt16(propiedadesDoc.ClaveInventario);
            datDocPresp.Doc_Ventas = Convert.ToInt16(propiedadesDoc.ClaveVentas);
            datDocPresp.Doc_Compras = Convert.ToInt16(propiedadesDoc.ClaveCompras);
            datDocPresp.Doc_NumeroExterno = 0;
            datDocPresp.IdClaveDocSop = 0;
            datDocPresp.Doc_FechaModifica = DateTime.Now ;
			datDocPresp.TipoPeriodo = "";
		}


        private void btnCierra_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma cerrar el documento actual ?", "Cerrar documento sin grabar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No) return;
            limpiarDatos();
        }
        private void limpiarDatos()
        {
            txtnumero.Enabled = true;
			datDocPresp = new AdcDocPro(varbleComun.VarCom.strConxAdcom);
            totalesDocumento = new adcDocumentos.docTotals();
            txtcedula.Text  = "";
            txtDetalle.Text  = "";
            txtnombrecliente.Text  = "";
            txtnumero.Text = "";
            mensajesDocumento.Text = "";
            idDocumentoActual.idClave = 0;
			idDocumentoActual = new idDocumento
			{
				fecha = txtfecha.Value
			};
			idDocumentoSoporte = new idDocumento();
            //txtNroID.Text = valoresPredefinidosSucursal.idtributario;
            dtDetalleDocumento = new DataTable();
            malla.DataSource = null;
            //malla.Columns.Clear();
            edTotal.Text = totalesDocumento.TotVta.ToString("#,0.00");
            operacionEnCurso = 0;
            prepararBotones();
//            InicializarMalla();
        }
        private void InicializarMalla()
        {
            this.malla.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.malla_CellValueChanged);
            adcDocumentos.armarConsTra  dcut = new adcDocumentos.armarConsTra();
            dtDetalleDocumento = utilBasDatos.utilBasDatos.leerTablas(dcut.armarSqlLecturaMovPrep(propiedadesDoc ,"AdcDiaPresp", "", "", 0), varbleComun.VarCom.strConxAdcom);
            if (dtDetalleDocumento == null) return;
            malla.DataSource = dtDetalleDocumento;
            dtDetalleDocumento.Rows.Add(dtDetalleDocumento.NewRow());
            //dtt.Dispose();
            adcDocumentos.diseñarMalla dcut2 = new adcDocumentos.diseñarMalla();
            dcut2.diseñarMallaMovPrep(ref malla,ref propiedadesDoc);
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
            totalizar();
        }

        #region EVENTOS DE CONTROLES
        #region EVENTOS DE BOTONES

        private void btnBuscaCliente_Click(object sender, EventArgs e)
        {
            BuscaCliente(txtnombrecliente.Text);
        }
        private void txtfecha_ValueChanged(object sender, EventArgs e)
        {
            idDocumentoActual.fecha = txtfecha.Value;
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            iniciarNuevoDocumento ();
        }
        private void iniciarNuevoDocumento()            
        {
            limpiarDatos();
            //inicializarUtilidadDocumentos();
            InicializarMalla();
            string tipDoc = cmbDocumento.SelectedValue.ToString();
            string tipBan = "";
            ClassDoc.controlNumeracion cnum = new controlNumeracion();
            txtnumero.Text = cnum.NumeroMayor(idDocumentoActual, "", "", "", datosEmpresa.strConxAdcom).ToString();
            operacionEnCurso = 1;
            prepararBotones();
        }

        private void BtnRegistra_Click(object sender, EventArgs e)
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
        private void btnElimina_Click(object sender, EventArgs e)
        {
            adcDocumentos.anulaElimina classAnular = new adcDocumentos.anulaElimina();
            if (classAnular.eliminarDocumento(varbleComun.VarCom.strConxAdcom, varbleComun.VarCom.strConxSyscod, idDocumentoActual, varbleComun.VarCom.usr, false, varbleComun.VarCom.nomEmpresa, varbleComun.VarCom.codEmpresa.ToString(), edTotal.Text, "ADCDOC", propiedadesDoc.ComandoExterno)) limpiarDatos();
            classAnular = null;
        }


        #endregion EVENTOS DE BOTONES
        #region EVENTOS DE CAJAS DE TEXTO
        private void btnGraba_Click(object sender, EventArgs e)
        {
            if (validarDocumento() == true)
            {                
                if (grabarDocumento() == true) { limpiarDatos(); }
            }

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
                cargarDatosCliente(codigo);
                if (txtcedula.Text == "")
                {
                    MessageBox.Show("El responsable no existe ", "Registro cambio Presupuesto", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                }
                if ((codigo + "").Length > 0) cargarDatosCliente(codigo);
            }
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
            progBus.IniciaBusqueda( claseDocDefault, "", cmbDocumento.SelectedValue.ToString(), queFecha, ref idDocumentoActual.Sucursal, ref idDocumentoActual.Tipo, ref idDocumentoActual.numero, ref idDocumentoActual.idClave, false, cmbDocumento.SelectedValue.ToString(), "", "", "AdcDocPro");
            if (idDocumentoActual.idClave == 0)
            {
                idDocumentoActual.Sucursal = varbleComun.VarCom.suc; return;
            }
            if (idDocumentoActual.Sucursal.ToUpper() != varbleComun.VarCom.suc.ToUpper()) { mensajesErrorDocumento.documentosNoDeOtraSucursal(varbleComun.VarCom.sucNom); return; }
            if (idDocumentoActual.idClave != 0) CargarDatosDocumento(idDocumentoActual.Sucursal, idDocumentoActual.Tipo, idDocumentoActual.idClave);
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
             impresionVerificacion.verificarExistenciaDocumentoFac(ref idDocumentoActual, varbleComun.VarCom.strConxAdcom, "DaxDocPresp", "");
            if (idDocumentoActual.idClave > 0) CargarDatosDocumento(idDocumentoActual.Sucursal ,idDocumentoActual.Tipo, idDocumentoActual.idClave);
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
                    if (malla.Columns[i].Visible == true && malla.Columns[i].ReadOnly == false && malla.Columns[i].Name.ToUpper() != "nombreCta") { colOk = i; break; }
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

            Boolean resp = true;
			malla.EndEdit();
			string nombreCelda = malla.CurrentCell.OwningColumn.Name.ToUpper();
            FuncionesEspeciales FF = new FuncionesEspeciales();
         
            if (nombreCelda == "CTA_CODIGO")
            { 
                  FF.CtaPresupuestos(keyData, malla);
            }
            else if (malla.CurrentRow.Cells["cta_codigo"].Value.ToString().Length == 0) { keyData = Keys.Cancel; return false; }
			        {

			        }    //        VerificarClasificadoresContablesArticulo dato

			if ( malla.CurrentCell.Value.ToString() != "") keyData = Keys.Return; else keyData = Keys.Cancel;
			saltaEventosMalla = false;
			totalizar();
			return resp;
		}

        private void imprimirDocumento()
        {
            ImprDoct.ImprimirDoc progimp = new ImprDoct.ImprimirDoc();
            //adcDocumentos.impresionVerificacion  FImprimeDocumento = new adcDocumentos.impresionVerificacion ();
            impresionVerificacion.ImpDoc(idDocumentoActual.idClave, varbleComun.VarCom.suc, cmbDocumento.SelectedValue.ToString(), Convert.ToDouble(txtnumero.Text), "A", "F", propiedadesDoc.TipoDoc, "FELFAC");
            progimp.claveSri = claveSri;
        }


        private void copiarDocumento(idDocumento idDocCopiar, Boolean esGenerar = false)
        {
            utilDoc.cadenaConexion = varbleComun.VarCom.strConxAdcom;
            datDocPresp = new AdcDocPro(varbleComun.VarCom.strConxAdcom);
            string tabladoc = "";
            string tablatra = "";
			utilDoc.tablasDeDatos ( idDocCopiar.Tipo, ref tabladoc, ref tablatra);
            string Ssql = "doc_sucursal = '" + idDocCopiar.Sucursal + "' and opc_documento ='" + idDocCopiar.Tipo + "' and idclavedoc = " + idDocCopiar.idClave.ToString();
            
                datDocPresp = AdcDocPro.Buscar(Ssql);
                if (datDocPresp != null)
                {
                    datDocPresp.IdClaveDoc = 0;
                    datDocPresp.Doc_numero = Convert.ToDecimal(txtnumero.Text);

                    this.malla.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.malla_CellValueChanged);
                    if (esGenerar == false)
                    {
                        if (MessageBox.Show("Desea copiar la cabezera del documento ? ", "Copiar datos documento", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                        {
                            cargarDatosCliente(datDocPresp.Doc_codper);
                            moverCabezera();
                        }
                    }
                    else
                    {
                        cargarDatosCliente(datDocPresp.Doc_codper);
                        moverCabezera();
                    }
                    //moverOtrosValores();
                    cargarDetallePresupuestos(idDocCopiar.Sucursal, idDocCopiar.Tipo, idDocCopiar.idClave, tablatra);
                    LlenarIdDocumento(ref idDocumentoActual);
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
            //adcDocumentos.impresionVerificacion  util = new adcDocumentos.impresionVerificacion();

            if (Convert.ToDouble("0" + txtnumero.Text) == 0) { mensajesErrorDocumento.MensajeNumeroDoc(); txtnumero.Focus(); return false; }
            ValidacionDocumentos.ValidacionGeneral.validarFecha(txtfecha.Text,varbleComun.VarCom.usr);
            //if (opalex.codigo == "" || codCliente == "" || txtcedula.Text == "") { mensajesErrorDocumento.ElCodigoNoExiste("C"); return false;}

            if (ValidacionDocumentos.ValidacionGeneral.validarIngresoDetalle(malla, "cta_codigo") ==false) {mensajesErrorDocumento.sinArtículosOservicios(); return false;}
            
            moverDatosClase();
            //daxMallaDatos.validacionDocumento  valdoc = new daxMallaDatos.validacionDocumento ();
            //string docsustento = "";
            //try
            //{
            //    docsustento = cmbDocumentoSustento.SelectedValue.ToString();
            //}
            //catch { }
            //if ( ValidacionDocumentos.ValidacionGeneral.ControlValidacionFacCli (ref malla, ref propiedadesDoc, clasref, txtfecha.Text, varbleComun.VarCom.suc, varbleComun.VarCom.strConxAdcom, varbleComun.VarCom.strConxSyscod, idDocumentoActual.idClave, "", txtnumero.Text,false, varbleComun.VarCom.suc,docsustento, "") == false) return false;            


            return true;            
        }                                            

        private Boolean grabarDocumento()
        {
            malla.EndEdit();
            Boolean RESP = true;

            string res = "";
            try
            {
                if (idDocumentoActual.idClave == 0)
                {
                    //adcDocumentos.fijarNumeroDocumento fijnum = new adcDocumentos.fijarNumeroDocumento();
                    //datDocPresp.Doc_numero = Convert.ToDecimal( fijnum.nroDeDocumento(propiedadesDoc.tablaDatosDoc, propiedadesDoc.CodDuplica, Convert.ToBoolean(propiedadesDoc.NroAutomatico), Convert.ToDouble(txtnumero.Text), varbleComun.VarCom.strConxAdcom, varbleComun.VarCom.suc, cmbDocumento.SelectedValue.ToString(),txtnumero.Text, "", codCliente, ""));
                    //if (datDocPresp.Doc_numero == 0) return false;

                    res = datDocPresp.Crear();
                    idDocumentoActual.idClave = Convert.ToDouble(datDocPresp.IdClaveDoc);
                    idDocumentoActual.numero = Convert.ToDouble(datDocPresp.Doc_numero);
                    idDocumentoActual.Sucursal = datDocPresp.Doc_sucursal;
                    idDocumentoActual.Tipo = datDocPresp.Opc_documento;
                    txtnumero.Text = datDocPresp.Doc_numero.ToString();

                    if (res.Substring(0, 3) != "ERR") { grabarAdcDiaPresp(); }
                    string tipDoc = cmbDocumento.SelectedValue.ToString();
  //                  string tipBan = "";

//                    if (idDocumentoActual.idClave != 0) propiedadesDoc.GuardarNumero (ref varbleComun.VarCom.suc, ref tipDoc, ref tipBan, "", "", varbleComun.VarCom.usr, ""); ;
                }
                else
                {
                    res = datDocPresp.Actualizar();
                    if (res.Substring(0, 3) != "ERR") { grabarAdcDiaPresp(); }
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
        private void grabarAdcDiaPresp()
        {
           grabMallPresp.grabarMallaAdcdia (malla,datDocPresp,varbleComun.VarCom.strConxAdcom);
        }

        private void totalizar()
        {
            this.malla.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.malla_CellValueChanged);
            totalesDocumento = new adcDocumentos.docTotals();
            edTotal.Text = "0";
            this.malla.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.malla_CellValueChanged);
            //sumarPartePago();
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

        private void txtnumero_TextChanged(object sender, EventArgs e)
        {

        }

        private void malla_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string nomCol = malla.Columns[e.ColumnIndex].Name;
            double valor = 0;
            if (nomCol== "valordebito")
            {
                try { valor = Convert.ToDouble(malla.Rows[e.RowIndex].Cells["valordebito"].Value);} catch { }

                if (valor != 0)
                {
                    malla.Rows[e.RowIndex].Cells["dia_signo"].Value = 1;
                    malla.Rows[e.RowIndex].Cells["dia_valor"].Value = malla.CurrentCell.Value;
                    malla.Rows[e.RowIndex].Cells["valorcredito"].Value = 0;
                }

                return;
            }
            if (nomCol == "valorcredito")
            {
                try { valor = Convert.ToDouble(malla.Rows[e.RowIndex].Cells["valorcredito"].Value); } catch { }

                if (valor != 0)
                {
                malla.Rows[e.RowIndex].Cells["dia_signo"].Value = -1;
                malla.Rows[e.RowIndex].Cells["dia_valor"].Value = malla.CurrentCell.Value;
                malla.Rows[e.RowIndex].Cells["valordebito"].Value = 0;
                }
            }
        }

    }
}