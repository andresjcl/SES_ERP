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

namespace adcDocumentos
{
    public partial class formFacCli : Form
    {        
        AdcDax.DaxSofSys CONEMP = new AdcDax.DaxSofSys();
        DaxUsr.DaxsofUsr CONUSER = new DaxUsr.DaxsofUsr();
        DaxUsr.CtrlUsuario ControlUsuario;
        //daaxLib.DaxLibBases datlib;
        PrySysp13.OpcDoc propiedadesDoc;        
        MantenimientoDirectorio.DirectorioAlex opalex = new MantenimientoDirectorio.DirectorioAlex();
        AdcDoc datADCDOC;
        pagosDocumento.classPagosDoc clasePagos = new pagosDocumento.classPagosDoc();
        adcDescto.descDocumento claseDescuentos = new adcDescto.descDocumento();
        TablasSRI.docImpuestos claseImpuestos = new TablasSRI.docImpuestos();
        predefinidosSUC predefinidosSucursal;
        adcDocumentos.impresionVerificacion dcu = new adcDocumentos.impresionVerificacion();
        adcArticulo.AdcArt propiedadesArticulo = new adcArticulo.AdcArt();
        ctrlReferencia.controlReferencial clasref = new controlReferencial();
        DataTable dtDetalleDocumento = new DataTable();
        DataTable dtDetalleContabilidad = new DataTable();
        classExporta datosExportacion = new classExporta();       
 
        docMallaArticulo mallaArticulo = new docMallaArticulo();
        adcDocumentos.docTotals totalesDocumento = new adcDocumentos.docTotals();        
        Boolean documentoMultiNumeracion = false;
        string lugarNumeracionDocumento = "";

        string claseDocDefault = "";
        string tipoDocDefault = "";
        

        Boolean esSoloConsulta = false;
        Boolean consultaDeEstadoDecta = false;
        Boolean tieneComprobantesElectronicos = false;
        Boolean entregasPendientes = false;
        Boolean esDeLiquidacion = false;
        Boolean debeActualizarContacto = false;

        idDocumento idDocumentoActual = new idDocumento();
        idDocumento idDocumentoSoporte = new idDocumento();
        idDocumento idDocumentoParaGenerar = new idDocumento();
        
        string claveSri = "";
        string codCliente = "";
        Boolean saltar = false;

        string strConxAdcom = "";
        string strDaxsys = "";
        string strSri = "";

        Boolean salto = false;
        int operacion = 0; // 0 sin operacion delcarada, 1 nuevo registro, 2 modificando registro

        public formFacCli(string clasdef,string tipdef, Boolean esConsulta=false,Boolean generarFactura = false, Boolean desdeEstdoCta = false, idDocumento idDocViene=null)
        {
            InitializeComponent();
            claseDocDefault = "FAC";
            if (tipdef.Length > 0) tipoDocDefault = tipdef; else tipoDocDefault = "FAC";           
            splitContainer1.Panel2Collapsed = !(splitContainer1.Panel2Collapsed);
            ControlUsuario = CONUSER.UsuarioAct;
            //datlib = new daaxLib.DaxLibBases(CONEMP.EmpresaAct.codigo,"DXA",CONEMP.EmpresaAct.PatAppl);
            strConxAdcom = varbleComun.VarCom.strConxAdcom;
            strDaxsys = varbleComun.VarCom.strConxSyscod;
            strSri = varbleComun.VarCom.strConxIvaret;
            propiedadesDoc = new PrySysp13.OpcDoc();
            tieneComprobantesElectronicos = dcu.validaComprobantesElectronicos(CONEMP.EmpresaAct.PatAppl);
            llenarCombos();
            claseImpuestos.cargar(strSri, txtfecha.Value);

            predefinidosSucursal = new predefinidosSUC(strDaxsys, idDocumentoActual.Sucursal, CONEMP.EmpresaAct.codigo);
            if (idDocViene == null) idDocViene = new idDocumento();
            // tipoMov
            if (idDocViene.idClave > 0 && esConsulta)
            {
                idDocumentoActual = idDocViene;}
            else if (idDocViene.idClave > 0 && generarFactura)
            {
                MessageBox.Show("decision");
                idDocumentoParaGenerar = idDocViene;                
            }
            else
            {
                idDocumentoActual.Sucursal = CONEMP.EmpresaAct.SucActual;
            }
                        
            this.Text = "MANTENIMIENTO FACTURACION CLIENTES - SUCURSAL : " + CONEMP.EmpresaAct.SucNomActual;
        }
        private void formFacCli_Load(object sender, EventArgs e)
        {
            cmbDocumento.SelectedValue = tipoDocDefault;
            llenarComboDocReferencia();
            if (idDocumentoActual.idClave != 0)
            {
                cargarDatosFactura(idDocumentoActual.Sucursal,idDocumentoActual.Tipo,idDocumentoActual.idClave);
            }
            else if (idDocumentoParaGenerar.idClave > 0)
            {
                iniciarNuevoDocumento();
                copiarDocumento ( idDocumentoParaGenerar,true);
            }
            prepararBotones();
        }

        private void llenarCombos()
        {
            DaxCbos.DaxCombobx cmb = new DaxCbos.DaxCombobx();
            cmb.DaxCombosDoc(claseDocDefault , tipoDocDefault , false, strConxAdcom, ref cmbDocumento);
            cmb.DaxCombosBods( varbleComun.VarCom.suc, false, strDaxsys, ref cmbBodega);
            cmb.DaxCombosVend(strConxAdcom, ref cmbVendedor,false);
        }
        private void llenarComboDocReferencia()
        {
            idDocumentoActual.Tipo = cmbDocumento.SelectedValue.ToString();
            propiedadesDoc.Cargar(ref idDocumentoActual.Tipo, ref idDocumentoActual.Sucursal);            
            string Ssql="";
            
            if (propiedadesDoc.TipoSoporteObligatorio != null && propiedadesDoc.TipoSoporteObligatorio.Length > 0) 
            {
                Ssql = "SELECT opc_nombre, opc_documento, opc_tipo FROM adcopc WHERE OPC_DOCUMENTO = '"  + propiedadesDoc.TipoSoporteObligatorio + "' order by opc_documento ";
                entregasPendientes = true;
            }
            else 
            {
                Ssql = "SELECT opc_nombre, opc_documento, opc_tipo FROM adcopc  WHERE OPC_DOCUMENTO > '' order by opc_documento ";
                entregasPendientes = false;
            }
                        
            using (DataTable dtt = utilBasDatos.utilBasDatos.leerTablas(Ssql, strConxAdcom))
            {
                cmbDocumentoSustento.DataSource = dtt;
                cmbDocumentoSustento.DisplayMember = "opc_nombre";
                cmbDocumentoSustento.ValueMember = "opc_documento";
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buscaCliente(string buscador)
        {
            MantenimientoDirectorio.BuscaClien directorio = new MantenimientoDirectorio.BuscaClien();
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
                opalex = new MantenimientoDirectorio.DirectorioAlex();
                opalex.CargarAlex(ref codigo, ref x, ref solocodigo);
                if (opalex.codigo == null) codigo = ""; else codigo = opalex.codigo;
                if (codigo.Length > 0 )
                {
                    codCliente = opalex.codigo ;
                    txtcedula.Text = opalex.CiRuc ;
                    txtnombrecliente.Text = opalex.NombreImpresion ;
                    txtdireccion.Text = opalex.direccion ;
                    txtCorreElectronico.Text = opalex.correoElectronico  ;
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
        private Boolean cargarDatosFactura(string SUC, string TIPO, double IDCLAVE )
        {            
            Boolean resp = false;
            if (IDCLAVE != 0)
            {
                datADCDOC = new AdcDoc(strConxAdcom);
                datADCDOC = AdcDoc.Buscar("doc_sucursal = '" + SUC + "' and opc_documento ='" + TIPO + "' and idclavedoc = " + IDCLAVE.ToString());
                if (datADCDOC != null)
                {
                    this.malla.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.malla_CellValueChanged);
                    cargarDatosCliente(datADCDOC.Doc_codper);
                    moverClaseAcontroles();
                    if (Convert.ToInt32(datADCDOC.Doc_Estado) == 0) mensajesDocumento.Text = "DOCUMENTO ANULADO : " + datADCDOC.MotivoAnulacion ;
                    cargarDetalleArticulos(idDocumentoActual.Sucursal, idDocumentoActual.Tipo, idDocumentoActual.idClave, "ADCTRA");
                    cargarFormaDePago(idDocumentoActual.Sucursal, idDocumentoActual.Tipo, idDocumentoActual.idClave,"ADCPAG");
                    inicializarUtilidadDocumentos();
                    totalizar();
                    operacion = 2;
                    prepararBotones();
                    resp = true;
                    txtnumero.Enabled = false;
                    this.malla.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.malla_CellValueChanged);
                }
            }
            else { }
            return resp;        
        }

        private void cargarDetalleArticulos(string suc, string tip, double idClave,string tablatra)
        {
            this.malla.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.malla_CellValueChanged);
            adcDocumentos.armarConsTra  dcut = new adcDocumentos.armarConsTra ();
            adcDocumentos.diseñarMalla dcut2 = new adcDocumentos.diseñarMalla();

            dtDetalleDocumento = utilBasDatos.utilBasDatos.leerTablas(dcut.armarSqlLecturaTraFac(tablatra, suc, tip, idClave), strConxAdcom);
            dcut = null;
            if (dtDetalleDocumento == null) return;
            malla.DataSource = dtDetalleDocumento;
            dcut2.diseñarMallaFacCli(ref malla,ref propiedadesDoc);
            this.malla.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.malla_CellValueChanged);

            dcut = null;
            dcut2 = null;
        }
        private void cargarDetalleArticulosConsolidacion(string listaDocumentos)
        {
            adcDocumentos.armarConsTra dcut = new adcDocumentos.armarConsTra();
            adcDocumentos.diseñarMalla dcut2 = new adcDocumentos.diseñarMalla();

            dtDetalleDocumento = utilBasDatos.utilBasDatos.leerTablas(dcut.armarSqlLecturaTraFacConsolida("ADCTRA",listaDocumentos), strConxAdcom);
            dcut = null;
            if (dtDetalleDocumento == null) return;
            malla.DataSource = dtDetalleDocumento;
            if (malla.Rows.Count > 0)  dcut2.diseñarMallaFacCli(ref malla, ref propiedadesDoc);

            dcut = null;
            dcut2 = null;
        }
        private void cargarFormaDePago(string suc, string tip, double idClave, string tabla)
        { 
          clasePagos =  new pagosDocumento.classPagosDoc();
          clasePagos.strConx = strConxAdcom;
          clasePagos.DocSucursal = suc;
          clasePagos.Doctipo = tip;
          clasePagos.idClaveDoc = idClave;
          clasePagos.DocNumero = Convert.ToDouble("0" + txtnumero.Text);
          clasePagos.cargarPagosDocumento();
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

            txtDetalle.Text  = datADCDOC.Doc_detalle ;
            cmbVendedor.SelectedValue = datADCDOC.Doc_venabre;
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

            claseImpuestos.impstoPorcentaje1= Convert.ToDouble(datADCDOC.Doc_porceniva);
            claseImpuestos.impstoNombre1 = "IVA";
            
        }
        private void moverDatosClase()
        {
            datADCDOC.Doc_sucursal =  CONEMP.EmpresaAct. SucActual;
            datADCDOC.Doc_Bodega = cmbBodega.SelectedValue.ToString();
            datADCDOC.Opc_documento = cmbDocumento.SelectedValue.ToString();
            datADCDOC.Doc_numero = Convert.ToDecimal( txtnumero.Text);
            datADCDOC.Doc_fecha = Convert.ToDateTime(txtfecha.Text) ;           
            datADCDOC.Doc_codper = codCliente ;
            datADCDOC.Doc_CiRuc = txtcedula.Text ;
            datADCDOC.Doc_NombreImp = txtnombrecliente.Text;
            datADCDOC.Doc_Direccion = txtdireccion.Text;
            datADCDOC.Doc_Telefono1 = txttelefono.Text;
            datADCDOC.Doc_detalle = txtDetalle.Text ;
            datADCDOC.Doc_venabre = cmbVendedor.SelectedValue.ToString();
            datADCDOC.Doc_DocSop = "";
            datADCDOC.Doc_NumSop = 0;
            datADCDOC.Doc_valor = Convert.ToDecimal(edTotal.Text);
            datADCDOC.AuxVar9 = txtCorreElectronico.Text ;

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
            datADCDOC.Doc_NroIdDoc = txtNroID.Text ;
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
            datADCDOC.Doc_codusu = ControlUsuario.Identifica;
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
            datADCDOC.Doc_FechaModifica = DateTime.Now ;
            datADCDOC.doc_TotDesSiva = totalesDocumento.totdessiva;
            datADCDOC.doc_TotDesCIva = totalesDocumento.totdesciva;
            datADCDOC.Adi_NroAutSri = "";                   //TextNroAutSri
            datADCDOC.ProductoProduccion = "";             //ProductoProduccion.Text
            //datADCDOC.FacDesde = FDesde.Value;
            //datADCDOC.FacHasta = FHasta.Value;
            //datADCDOC.TipoPeriodo = "";
        }

        private void prepararBotones()
        {
            Boolean inicio = (operacion == 0);
            Boolean nuevo = (operacion == 1);
            Boolean modificando = (operacion == 2);
            Boolean docAnulado = ( (datADCDOC ==null || datADCDOC.Doc_Estado == 0) && modificando);

            btnAbre.Enabled   = inicio;
            btnNuevo.Enabled  = inicio;

            btnCopia.Enabled = nuevo && !docAnulado;
            btnConsolida.Enabled = nuevo && !docAnulado;

            btnAnula.Enabled = modificando && !docAnulado;
            btnElimina.Enabled = modificando;
            btnGraba.Enabled = !inicio && !docAnulado;
            btnRegistra.Enabled = !inicio && !docAnulado;
            btnEnviar.Enabled = modificando && !docAnulado;
            btnCierra.Enabled = !inicio;

            btnAplicaciones.Enabled = modificando && !docAnulado;
            btnEstadoCta.Enabled = !inicio;
            btnPendientes.Enabled = !inicio && !docAnulado && entregasPendientes;
            btnPagos.Enabled = !inicio && !docAnulado;
            btnDescuentos.Enabled = !inicio && !docAnulado;
            btnExportacion.Enabled = !inicio;
            btnPorcentajeIva.Enabled = btnDescuentos.Enabled;

            btnBarras.Enabled = (!inicio) && !docAnulado;
            btnAgrupa.Enabled = (btnBarras.Enabled && btnBarras.Checked);
           
            panel1.Enabled = (!inicio);
            malla.Enabled = (!inicio);

            cmbDocumento.Enabled  = (!modificando);
            txtcedula.Enabled =(!docAnulado);

            btnContabiliza.Enabled = (!inicio && Convert.ToBoolean(propiedadesDoc.SNContabilizar) == true && !docAnulado);

            if (inicio) return;

            btnEstadoCta.Enabled = !consultaDeEstadoDecta;

            if (esSoloConsulta == true || propiedadesDoc.ClaveEstado == 0)
            {
                btnGraba.Enabled = false;
                btnRegistra.Enabled = false;
                btnElimina.Enabled = false;
                btnAnula.Enabled = false;
                if (propiedadesDoc.ClaveEstado == 0) btnElimina.Enabled = (ControlUsuario.Identifica.ToUpper() == "ADMINISTRADOR");
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
            datADCDOC = new AdcDoc(strConxAdcom);
            clasePagos = new pagosDocumento.classPagosDoc();
            claseDescuentos = new adcDescto.descDocumento();
            totalesDocumento = new adcDocumentos.docTotals();
            clasref = new controlReferencial();
            txtcedula.Text  = "";
            txtCorreElectronico.Text  = "";
            txtDetalle.Text  = "";
            txtdireccion.Text  = "";
            txtnombrecliente.Text  = "";
            txtnumero.Text = "";
            txttelefono.Text  = "";
            mensajesDocumento.Text = "";
            operacion = 0;
            prepararBotones();
            InicializarMalla();
            idDocumentoActual.idClave = 0;
            presentarTotales();
            edTotal.Text = totalesDocumento.TotVta.ToString("#,0.00");
            esDeLiquidacion = false;
            debeActualizarContacto = false;
            idDocumentoActual = new idDocumento();
            idDocumentoActual.fecha = txtfecha.Value;
            idDocumentoSoporte = new idDocumento();
            txtNroID.Text = predefinidosSucursal.idtributario;
            datosExportacion = new classExporta();
            dtDetalleContabilidad = new DataTable();
            dtDetalleDocumento = new DataTable();
        }
        private void InicializarMalla()
        {
            this.malla.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.malla_CellValueChanged);
            adcDocumentos.armarConsTra  dcut = new adcDocumentos.armarConsTra();
            dtDetalleDocumento = utilBasDatos.utilBasDatos.leerTablas(dcut.armarSqlLecturaTraFac("adctra", "", "", 0), strConxAdcom);
            if (dtDetalleDocumento == null) return;
            malla.DataSource = dtDetalleDocumento;
            dtDetalleDocumento.Rows.Add(dtDetalleDocumento.NewRow());
            //dtt.Dispose();
            adcDocumentos.diseñarMalla dcut2 = new adcDocumentos.diseñarMalla();
            dcut2.diseñarMallaFacCli(ref malla,ref propiedadesDoc);
            dcut2 = null;
            //recalcularFilas();

            this.malla.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.malla_CellValueChanged);
        }
        private void malla_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (salto == false) totalizar();
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
            iniciarNuevoDocumento ();
        }
        private void iniciarNuevoDocumento()            
        {
            limpiarDatos();
            inicializarUtilidadDocumentos();
            double num = datADCDOC.Putil.nuevoNumeroDocumento("ADCDOC");
            txtnumero.Text = num.ToString();
            operacion = 1;
            prepararBotones();
        }
        private void btnPendientes_Click(object sender, EventArgs e)
        {
            porEntregar.frmPorEntregar  PorEntregar = new porEntregar.frmPorEntregar();
            PorEntregar.fecha = DateTime.Now;
            PorEntregar.Cliente = codCliente;
            PorEntregar.NomCliente = txtnombrecliente.Text;
            PorEntregar.strConxAdcom = strConxAdcom;
            PorEntregar.ShowDialog();
        }
        private void btnDescuentos_Click(object sender, EventArgs e)
        {
            adcDescto.ingDescDoc ingdesc = new adcDescto.ingDescDoc();
            int nrodesc = CONEMP.EmpresaAct.ActNumNiv;
            ingdesc.ingresarDescuentos(ref claseDescuentos, strConxAdcom, CONEMP.EmpresaAct.SucActual, nrodesc);
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
            if(classAnular.anularDocumento(strConxAdcom,strDaxsys,idDocumentoActual,ControlUsuario.Identifica,esDeLiquidacion,CONEMP.EmpresaAct.nombre,CONEMP.EmpresaAct.codigo.ToString(),edTotal.Text,"ADCDOC",propiedadesDoc.ComandoExterno)) limpiarDatos();
            classAnular = null;
        }
        private void btnElimina_Click(object sender, EventArgs e)
        {
            adcDocumentos.anulaElimina classAnular = new adcDocumentos.anulaElimina();
            if (classAnular.eliminarDocumento(strConxAdcom, strDaxsys, idDocumentoActual, ControlUsuario.Identifica, esDeLiquidacion, CONEMP.EmpresaAct.nombre, CONEMP.EmpresaAct.codigo.ToString(), edTotal.Text, "ADCDOC", propiedadesDoc.ComandoExterno)) limpiarDatos();
            classAnular = null;
        }


        #endregion EVENTOS DE BOTONES
        #region EVENTOS DE CAJAS DE TEXTO
        private void txtRecibido_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtCambio.Text = (Convert.ToDouble(txtRecibido.Text) - Convert.ToDouble(edTotal.Text)).ToString();
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
                        MantenimientoDirectorio.CreaCliAlex express = new MantenimientoDirectorio.CreaCliAlex();
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
            string SUC = CONEMP.EmpresaAct.SucActual;
            string TIP = "";
            double Idclave = 0;
            double Numero = 0;
            BuscadorDocumentos.buscadorDoc progBus = new BuscadorDocumentos.buscadorDoc(strConxAdcom,strDaxsys);
            DateTime queFecha = DateTime.Now;
            progBus.IniciaBusqueda( "FACPRCFAPPRPPECDEPDEVEBGIBGNCCNCPNDPNDC", "", "", queFecha, ref SUC, ref TIP, ref Numero, ref Idclave, false, "", "", "", "ADCDOC");
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
            string SUC = CONEMP.EmpresaAct.SucActual;
            string TIP = "";
            double Idclave = 0;
            double Numero = 0;
            BuscadorDocumentos.buscadorDoc progBus = new BuscadorDocumentos.buscadorDoc(strConxAdcom,strDaxsys);
            DateTime queFecha = DateTime.Now;
            idDocumentoParaGenerar = new idDocumento();
            idDocumentoParaGenerar.Lista = progBus.IniciaConsolidacion(adcDocumentos.ConsolidaDoc.tiposDoctsConsolidaSql(strConxAdcom),codCliente, "", queFecha, ref SUC, ref TIP, ref Numero, ref Idclave, false, "", "", "", "ADCDOC");
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
            
            llenarComboDocReferencia();
        }
        private void btnAbre_Click(object sender, EventArgs e)
        {
            BuscadorDocumentos.buscadorDoc progBus = new BuscadorDocumentos.buscadorDoc(strConxAdcom,strDaxsys);
            idDocumentoActual.Sucursal = CONEMP.EmpresaAct.SucActual;
            DateTime queFecha = DateTime.Now;
            progBus.IniciaBusqueda( claseDocDefault, "", cmbDocumento.SelectedValue.ToString(), queFecha, ref idDocumentoActual.Sucursal, ref idDocumentoActual.Tipo, ref idDocumentoActual.numero, ref idDocumentoActual.idClave, false, cmbDocumento.SelectedValue.ToString(), "", "", "ADCDOC");
            if (idDocumentoActual.idClave == 0)
            {
                idDocumentoActual.Sucursal = CONEMP.EmpresaAct.SucActual; return;
            }
            if (idDocumentoActual.Sucursal.ToUpper() != CONEMP.EmpresaAct.SucActual.ToUpper()) { mensajesErrorDocumento.documentosNoDeOtraSucursal(CONEMP.EmpresaAct.SucNomActual); return; }
            if (idDocumentoActual.idClave != 0) cargarDatosFactura(idDocumentoActual.Sucursal, idDocumentoActual.Tipo, idDocumentoActual.idClave);
        }

        private void txtnumero_Leave(object sender, EventArgs e)
        {
            if (saltar == true) { saltar = false; return; }
            if (operacion != 2)
            {
                verificaNroDocumentoDigitado();
                //llenarIdDocumento(ref docmtoActual);
                //docmtoActual.idClave = dcu.verificarExistenciaDocumento(CONEMP.EmpresaAct.SucActual, cmbDocumento.SelectedValue.ToString(), txtnumero.Text, strConxAdcom, documentoMultiNumeracion);
                //if (docmtoActual.idClave > 0) cargarDatosFactura(CONEMP.EmpresaAct.SucActual, cmbDocumento.SelectedValue.ToString(), docmtoActual.idClave);
            }
        }
        private void txtnumero_KeyDown(object sender, KeyEventArgs e)
        {
            saltar = true;
            if (e.KeyCode == Keys.Return)
            {
                verificaNroDocumentoDigitado();
            }
        }
        private void verificaNroDocumentoDigitado()
        {
            llenarIdDocumento(ref idDocumentoActual);
             dcu.verificarExistenciaDocumento(ref idDocumentoActual, strConxAdcom, documentoMultiNumeracion,"ADCDOC");
            if (idDocumentoActual.idClave > 0) cargarDatosFactura(idDocumentoActual.Sucursal ,idDocumentoActual.Tipo, idDocumentoActual.idClave);
        }


        #endregion EVENTOS DE CAJAS DE TEXTO

        #endregion EVENTOS DE CONTROLES
        #region manejo malla
        private void malla_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            salto = true;
            foreach (DataGridViewRow rr in malla.Rows)
            {
                rr.HeaderCell.Value = (rr.Index + 1).ToString();
            }
            salto = false;
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
            Boolean resp = true;
            malla.EndEdit();
            DataGridViewCell cell = malla.CurrentCell;
            string dato = cell.Value.ToString();
            string nombreCelda = cell.OwningColumn.Name.ToUpper();
            if (nombreCelda == "PREVTAUNI" && keyData >= Keys.F2 && keyData <= Keys.F6)
            {
                DataGridViewRow row = malla.CurrentRow;
                daxMallaDatos.docMallaArticulo preVta = new docMallaArticulo();
                
                double elPrecio = cargarPrecios.CargarPrecio(strConxAdcom, strDaxsys, Convert.ToInt32(keyData), malla.CurrentRow.Cells["Codigo"].Value.ToString(), claseImpuestos.impstoPorcentaje1, "", 0, row.Cells["Medida"].Value.ToString(), codCliente, Convert.ToInt32(CONEMP.EmpresaAct.DigitosPrecios));
                cell.Value = elPrecio;
                totalizar();
            }
            else if (nombreCelda == "CODIGO")
            {
                mallaArticulo.bodega = cmbBodega.SelectedValue.ToString();
                mallaArticulo.digCostos = CONEMP.EmpresaAct.DigitosCostos;
                mallaArticulo.digPrecios = CONEMP.EmpresaAct.DigitosPrecios;
                mallaArticulo.fechaDoc = Convert.ToDateTime(txtfecha.Text);
                mallaArticulo.impIva = claseImpuestos.impstoPorcentaje1;
                mallaArticulo.codCliente = codCliente;
                mallaArticulo.sucursal = CONEMP.EmpresaAct.SucActual;
                mallaArticulo.tipoDoc = cmbDocumento.SelectedValue.ToString();
                mallaArticulo.numDoc = txtnumero.Text;

                if (keyData == Keys.F2)
                {
                    dato = mallaArticulo.buscarArticuloSimple(malla.CurrentCell.Value.ToString());
                    if (mallaArticulo.cargarArticuloVta(ref propiedadesArticulo, malla,ref propiedadesDoc,dato, opalex.TipoCliente, txtfecha.Text, propiedadesDoc.Documento, idDocumentoActual.idClave) == false) cell.Value = ""; keyData = Keys.Cancel;
                }
                else if (keyData == Keys.F11)
                {
                    dato = mallaArticulo.buscarArticulo(malla.CurrentCell.Value.ToString());
                    if (mallaArticulo.cargarArticuloVta(ref propiedadesArticulo, malla, ref propiedadesDoc, dato,opalex.TipoCliente, txtfecha.Text, propiedadesDoc.Documento, idDocumentoActual.idClave) == false) cell.Value = ""; keyData = Keys.Cancel;
                }
                else if (keyData == Keys.Return)
                {
                    if (mallaArticulo.cargarArticuloVta(ref propiedadesArticulo, malla, ref propiedadesDoc, dato, opalex.TipoCliente, txtfecha.Text, propiedadesDoc.Documento, idDocumentoActual.idClave) == false) cell.Value = ""; keyData = Keys.Cancel;
                }
                else if (keyData == Keys.F3)
                {
                    DaxConceptos.classConceptos  buscserv = new DaxConceptos.classConceptos();
                    dato = buscserv.iniciaBuscador(strConxAdcom, "","CC",CONEMP.EmpresaAct.Hotel ,true);
                    if (dato != "") mallaArticulo.CargarServicios(dato,ref malla, claseImpuestos.impstoPorcentaje1, CONEMP.EmpresaAct.DigitosPrecios, Convert.ToDateTime(txtfecha.Text),ref propiedadesDoc);
                }

                //        VerificarClasificadoresContablesArticulo dato
            }
            if (cell.Value.ToString() != "") keyData = Keys.Return; else keyData = Keys.Cancel;

            return resp;
        }


         private void ingresarFormaDePago()
        {
            string pagoPredefinido = "EFE";
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
            ImprDoct.ImprimirDoc progimp = new ImprDoct.ImprimirDoc();
            adcDocumentos.impresionVerificacion  FImprimeDocumento = new adcDocumentos.impresionVerificacion ();
            FImprimeDocumento.ImpDoc(idDocumentoActual.idClave, CONEMP.EmpresaAct.SucActual, cmbDocumento.SelectedValue.ToString(), Convert.ToDouble(txtnumero.Text), "A", "F", propiedadesDoc.TipoDoc, "FELFAC");
            progimp.claveSri = claveSri;
            progimp.CorreoElectronico = txtCorreElectronico.Text;
        }


        private void btnEstadoCta_Click(object sender, EventArgs e)
        {
            if (codCliente =="") return;
            MntPago progG = new MntPago();
            string lasfacturas ="";
            double ValorAplicaciones = 0;
            progG.DocsPendientes ( CONEMP.EmpresaAct.CruceDocSucursal,ref lasfacturas, idDocumentoActual.Sucursal, idDocumentoActual.Tipo, idDocumentoActual.idClave , codCliente ,txtnombrecliente.Text , txtLote.Text , Convert.ToDouble(edTotal.Text) ,ref ValorAplicaciones, "", true);
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

            adcCtasCorrientes.frmAplicacionesDcto prog = new adcCtasCorrientes.frmAplicacionesDcto(strConxAdcom, idDocumentoActual.idClave ,idDocumentoActual.Tipo,Convert.ToInt64 (idDocumentoActual.numero) , 0,txtfecha.Text, "", posicion, idDocumentoActual.Sucursal);
            prog.ShowDialog();
        }


        private void copiarDocumento(idDocumento idDocCopiar, Boolean esGenerar = false)
        {
            utilDoc.cadenaConexion = strConxAdcom;
            datADCDOC = new AdcDoc(strConxAdcom);
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
                DataTable dt = utilBasDatos.utilBasDatos.leerTablas("select * from adcDOCpro where " + Ssql, strConxAdcom);

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
                    llenarIdDocumento(ref idDocumentoActual);
                    idDocumentoActual.idClave = 0;
                    inicializarUtilidadDocumentos();
                    totalizar();
                    prepararBotones();
                    this.malla.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.malla_CellValueChanged);
                }            
        }
        private void consolidarDocumentos(idDocumento idDocCopiar)
        {
            datADCDOC = new AdcDoc(strConxAdcom);
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
                llenarIdDocumento (ref idDocumentoActual);
                idDocumentoActual.idClave = 0;
                inicializarUtilidadDocumentos();
                totalizar();
                prepararBotones();
                this.malla.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.malla_CellValueChanged);
            }

        }
        private void inicializarUtilidadDocumentos()
        {
            datADCDOC.Putil.Doc_sucursal = CONEMP.EmpresaAct.SucActual;
            datADCDOC.Putil.Opc_documento = cmbDocumento.SelectedValue.ToString();
            datADCDOC.Putil.idsri = txtNroID.Text;
            datADCDOC.Putil.propietario = "";
            utilDoc.cadenaConexion = strConxAdcom;
            lugarNumeracionDocumento = datADCDOC.Putil.establecerLugar(ref documentoMultiNumeracion);
            datADCDOC.Putil.esNroMultiple = documentoMultiNumeracion;
        }

        private void malla_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Error de datos, el valor del dato registrado es inválido");
        }

        private Boolean validarDocumento ()
        {
            double PagoCredito=0;
            adcDocumentos.impresionVerificacion  util = new adcDocumentos.impresionVerificacion();
            daxMallaDatos.validacionDocumento validar = new daxMallaDatos.validacionDocumento();
            if (Convert.ToDouble("0" + txtnumero.Text) == 0) { mensajesErrorDocumento.MensajeNumeroDoc(); txtnumero.Focus(); return false; }
            validar.validarFecha(txtfecha.Text,ControlUsuario.Identifica);
            if (opalex.codigo == "" || codCliente == "" || txtcedula.Text == "") { mensajesErrorDocumento.ElCodigoNoExiste("C"); return false;}

            if (propiedadesDoc.TipoSoporteObligatorio != "")
            {
                if (txtNumeroSoporte.Text == "" || cmbDocumentoSustento.Text == "")
                {
                    mensajesErrorDocumento.SinDocumentoReferencia(); return false;
                }
                else
                {
                    if (clasref.LeerDocumentoReferencial(CONEMP.EmpresaAct.SucActual, cmbDocumentoSustento.SelectedValue.ToString(), txtNumeroSoporte.Text, CONEMP.EmpresaAct.SucActual, cmbDocumento.SelectedValue.ToString(), txtnumero.Text) == false)
                    { clasref = null; mensajesErrorDocumento.SinDocumentoReferencia(); return false; }
                }
            }
            if (validarIngresoDetalle ()==false) {mensajesErrorDocumento.sinArtículosOservicios(); return false;}
            
            moverDatosClase();
            daxMallaDatos.validacionDocumento  valdoc = new daxMallaDatos.validacionDocumento ();
            string docsustento = "";
            try
            {
                docsustento = cmbDocumentoSustento.SelectedValue.ToString();
            }
            catch { }
            if (valdoc.ControlValidacion(ref malla, ref propiedadesDoc, clasref, txtfecha.Text, CONEMP.EmpresaAct.SucActual, strConxAdcom, strDaxsys, idDocumentoActual.idClave, cmbBodega.SelectedValue.ToString(), txtnumero.Text, entregasPendientes, CONEMP.EmpresaAct.SucActual,docsustento, txtNumeroSoporte.Text) == false) return false;            

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
            if (opalex.limitecredito > 0 )
            {
                double saldoCliente = 0;
                string cod = "exec ADC_CCINDU '" + opalex.codigo + "','" + "01/01/1901" + "','" + txtfecha.Text + "'," + 0 + ",0,0,'C','',0,'" + CONEMP.EmpresaAct.SucActual + "','" + propiedadesDoc.Documento + "'," + idDocumentoActual.idClave.ToString();
                DataTable dt = utilBasDatos.utilBasDatos.leerTablas(cod, strConxAdcom);
                if (dt.Rows.Count > 0) saldoCliente = Convert.ToDouble(dt.Rows[0]["Saldo"].ToString());
                if (saldoCliente + PagoCredito > opalex.limitecredito )
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
                if (row.Cells["Codigo"].Value.ToString() != "" ) return true;
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
                    actualizarDatosCliente();
                }
            }
            try
            {
                if (idDocumentoActual.idClave == 0)
                {
                    adcDocumentos.fijarNumeroDocumento fijnum = new adcDocumentos.fijarNumeroDocumento();
                    datADCDOC.Doc_numero = Convert.ToDecimal( fijnum.nroDeDocumento(propiedadesDoc.tablaDatosDoc, propiedadesDoc.CodDuplica, Convert.ToBoolean(propiedadesDoc.NroAutomatico), Convert.ToDouble(txtnumero.Text), strConxAdcom, CONEMP.EmpresaAct.SucActual, cmbDocumento.SelectedValue.ToString(),txtnumero.Text, cmbBodega.SelectedValue.ToString(), codCliente, txtNroID.Text));
                    if (datADCDOC.Doc_numero == 0) return false;
                    txtnumero.Text = datADCDOC.Doc_numero.ToString();
                    res = datADCDOC.Crear();
                    idDocumentoActual.idClave = Convert.ToDouble(datADCDOC.IdClaveDoc);
                    if (res.Substring(0, 3) != "ERR") { grabarAdctra(); }
                    if (idDocumentoActual.idClave != 0) datADCDOC.Putil.guardarNumeroDocumento("", Convert.ToDouble(txtnumero.Text));
                    grabarDatosExportacion();
                }
                else
                {
                    res = datADCDOC.Actualizar();
                    if (res.Substring(0, 3) != "ERR") { grabarAdctra(); }
                    datADCDOC.Putil.guardarNumeroDocumento("", Convert.ToDouble(txtnumero.Text));
                    grabarDatosExportacion();
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
            //AdcTra adctra = new AdcTra(strConxAdcom);
            //adctra.Doc_sucursal = CONEMP.EmpresaAct.SucActual;
            //adctra.Opc_documento = cmbDocumento.SelectedValue.ToString();
            //adctra.Doc_numero = Convert.ToDecimal(txtnumero.Text);
            //adctra.IdClaveDoc = Convert.ToDecimal(idDocumentoActual.idClave);
            //adctra.Tra_DocSop = datADCDOC.Doc_DocSop;
            //adctra.Tra_NumSop = datADCDOC.Doc_NumSop;
            //adctra.Tra_fecha = DateTime.Now;
            //adctra.Tra_quetipo = "A";
            //adctra.Tra_TipoDoc = propiedadesDoc.TipoDoc;
            //adctra.Tra_Estado = 1;
            //adctra.Tra_Oculto = 0;
            //adctra.Tra_Ventas = Convert.ToInt16(propiedadesDoc.ClaveVentas);
            //adctra.Tra_Inventario = Convert.ToInt16(propiedadesDoc.ClaveInventario);
            //adctra.Tra_Compras = Convert.ToInt16(propiedadesDoc.ClaveCompras);
            //adctra.Tra_Activo = Convert.ToInt16(propiedadesDoc.ClaveActivo);

            ClassDoc.grabMallTra.grabarDetalleAdctra(malla, datADCDOC, varbleComun.VarCom.strConxAdcom);
            //adctra = null;
        }
        private void grabarDatosExportacion()
        {
            if (datosExportacion.ClienteConsig != "" || datosExportacion.TerminosVent != "") 
            {
                datosExportacion.Opc_documento = idDocumentoActual.Tipo;
                datosExportacion.Doc_numero = Convert.ToDecimal( idDocumentoActual.numero);
                datosExportacion.Doc_Sucursal = idDocumentoActual.Sucursal;
                datosExportacion.IdClaveDoc = Convert.ToDecimal(idDocumentoActual.idClave) ;
                datosExportacion.Actualizar();
            }
        }

        private void totalizar()
        {
            this.malla.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.malla_CellValueChanged);
            if (claseImpuestos.cambiadoManual == false)
            {
                if (claseImpuestos.impstoPorcentaje1 == 0 || claseImpuestos.impstoFechaIni1 > txtfecha.Value || claseImpuestos.impstoFechaFin1 < txtfecha.Value) claseImpuestos.cargar(strSri, txtfecha.Value);
            }
            totalesDocumento = new adcDocumentos.docTotals();
            edTotal.Text = Convert.ToString(totalesDocumento.totalizar(malla,claseImpuestos, claseDescuentos, clasePagos,propiedadesDoc,CONEMP.EmpresaAct.DigitosPrecios,CONEMP.EmpresaAct.DigitosCostos));
            presentarTotales();
            this.malla.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.malla_CellValueChanged);
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

        private void actualizarDatosCliente()
        {
            string ssql = "update identificacion set correoElectrónico = '"+txtCorreElectronico.Text+"' where codigo = '"+codCliente+"'";
            using (SqlConnection conn = new SqlConnection (strConxAdcom))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand (ssql,conn))
                {
                    comm.ExecuteNonQuery();
                }
            }
        }
        private void llenarIdDocumento(ref idDocumento docmtoActual)
        {
            docmtoActual.Sucursal=CONEMP.EmpresaAct.SucActual ;
            docmtoActual.Tipo =cmbDocumento.SelectedValue.ToString();
            docmtoActual.fecha = txtfecha.Value;
            try
            {
                docmtoActual.numero = Convert.ToDouble(txtnumero.Text);
            }
            catch { docmtoActual.numero = 0;}
        }

        private void btnExportacion_Click(object sender, EventArgs e)
        {
            adcDocumentos.docExpor progex = new docExpor();
            datosExportacion.conexiondata = strConxAdcom;
            datosExportacion.Opc_documento = cmbDocumento.SelectedValue.ToString();
            datosExportacion.Doc_numero = Convert.ToDecimal("0" + txtnumero.Text);
            datosExportacion.Doc_Sucursal = CONEMP.EmpresaAct.SucActual;
            datosExportacion.IdClaveDoc = Convert.ToDecimal(idDocumentoActual.idClave);
            progex.iniciaDocumento(ref datosExportacion,txtfecha.Value);
            progex = null;
        }

        private void chequearCambioValoresPoFecha()
        {
            totalizar();            
        }
        private void cmbDocumentoSustento_SelectedIndexChanged(object sender, EventArgs e)
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
            string nvoIva = progBus.Buscar(strSri , ssql, "porcentaje", "porcentaje", "", "Seleccionar porcentaje IVA", "");
            if (MessageBox.Show("Confirma cambiar el porcentaje del IVA en el documento ?", "Cambiar porcentaje del IVA", MessageBoxButtons.YesNo, MessageBoxIcon.Question  ) == DialogResult.No) return;
            claseImpuestos.cambiadoManual = true;
            claseImpuestos.impstoPorcentaje1 = Convert.ToDouble("0" + nvoIva);
            totalizar();
        }

        private void btnContabiliza_Click(object sender, EventArgs e)
        {
            daxContaDoc.frmVisContab progCtb = new daxContaDoc.frmVisContab(dtDetalleContabilidad,strConxAdcom,strDaxsys,datADCDOC ,propiedadesDoc,malla,clasePagos,txtDetalle.Text);
            progCtb.ShowDialog();
        }
    }
}