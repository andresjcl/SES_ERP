using System;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DtosMall;
using DaxComercia;
using classMenSistem;
//using ctrlReferencia;
using ClassDoc;
using System.Drawing;
using DattCom;
using DctosEmi;

namespace adcDocumentos
{
    public partial class FormFacPVTA : Form
    {
        DataTable dt = new DataTable();
        internal sesSys.OpcDoc propiedadesDoc;
        directMnt.DirectorioAlex opalex = new directMnt.DirectorioAlex();
        AdcDoc datADCDOC;
        AdcDocComp datADCDOCComp;
        DaxComercia.classPagosDoc clasePagos = new DaxComercia.classPagosDoc();
        adcDescto.descDocumento claseDescuentos = new adcDescto.descDocumento();
        internal IvaRett.docImpuestos claseImpuestos = new IvaRett.docImpuestos();
        daxAccs.propiedadesDaxAuto accesosLocalizados = new daxAccs.propiedadesDaxAuto();
        docMallaArticulo mallaArticulo = new docMallaArticulo();
        Int32 PrecioActivo = 1;
        string FormaPagoObligatoria = "";
        DataTable dtDetalleDocumento = new DataTable();
        string numeroEgreso = "";
        bool existeC;
        string compExi;
        string codigoC;

        DctosEmi.docTotals totalesDocumento = new DctosEmi.docTotals();
        string claseDocDefault = "FAC";
        string tipoDocDefault = "FAC";

        bool iniciaConNuevoDOc = false;
        Boolean esSoloConsulta = false;
        //Boolean entregasPendientes = false;
        Boolean esDeLiquidacion = false;
        Boolean debeActualizarContacto = false;

        idDocumento idDocumentoActual = new idDocumento();
        idDocumento idDocumentoCompuesto = new idDocumento();
        idDocumento idDocumentoSoporte = new idDocumento();
        idDocumento idDocumentoParaGenerar = new idDocumento();
        //bool ingresandoCantidad = false;

        string codCliente = "";
        Boolean saltarEventoNumero = false;
        Boolean saltaEventosMalla = false;
        Boolean CMDNbakUn = true;
        Boolean CMDNbakPv = true;
        string CMDNbakCod = "";
        //Boolean saltaEventosPagos = false;

        int operacionEnCurso = 0; // 0 sin operacion delcarada, 1 nuevo registro, 2 modificando registro
        int sinOperacion = 0;
        int nuevoRegistro = 1;
        int modificandoRegistro = 2;

        string memTipoDoc = "";
        string memVendedor = "";
        string memBodega = "";

        string tipoItemEnCurso = "";
        string claseItemEnCurso = "";
        string codigoArt = "";
        CierreDeCaja.DaxCiecaj datosCierre = new CierreDeCaja.DaxCiecaj();

        public FormFacPVTA(string clasdef, string tipdef, bool nuevo = false, Boolean esConsulta = false, Boolean generarFactura = false, Boolean desdeEstdoCta = false, idDocumento idDocViene = null)
        {
            InitializeComponent();
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
                //MessageBox.Show("decision");
                idDocumentoParaGenerar = idDocViene;
                cmbDocumento.SelectedValue = idDocViene.Tipo;
            }

            IniciarDatosPuntoDeventa();

        }
        private void CargarValoresIniciales()
        {
            this.txtfecha.ValueChanged -= new System.EventHandler(this.txtfecha_ValueChanged);
            //txtfecha.Value = docUtils.DaxNow();
            malla.RowTemplate.Height = 28;
            malla.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            idDocumentoActual.Tipo = tipoDocDefault;
            idDocumentoActual.familia = claseDocDefault;
            idDocumentoActual.Sucursal = datosEmpresa.suc;
            claseImpuestos.cargar(datosEmpresa.strConxIvaret, txtfecha.Value);
            valoresPredefinidosEmpresa.codemp = 0;
            valoresPredefinidosEmpresa.cargaValores();
            valoresPredefinidosSucursal.cargarValores();
            txtNroID.Text = valoresPredefinidosSucursal.idtributario;
            txtNroID.Enabled = (valoresPredefinidosSucursal.autCambiaPtoVta || datosEmpresa.usr.ToUpper() == "ADMINISTRADOR");
            //ptoVenta.Visible = txtNroID.Enabled;
            //usuariosPuntoVenta.Visible = (datosEmpresa.usr.ToUpper() == "ADMINISTRADOR");
            btnCOnfigurar.Visible = (datosEmpresa.usr.ToUpper() == "ADMINISTRADOR");
            LlenarCombos();
            CargarPredefinidosDocumento();
            this.txtfecha.ValueChanged += new System.EventHandler(this.txtfecha_ValueChanged);
            FormaPagoObligatoria = "";
            cambiarBotonDePago(btnLocal, 1, true);
        }
        private void formFacPv_Load(object sender, EventArgs e)
        {
//            CargarPredefinidosDocumento();

            cargarImagenesArticulos();
            if (idDocumentoActual.idClave != 0)
            {
                cargarDatosFactura(idDocumentoActual.Sucursal, idDocumentoActual.Tipo, idDocumentoActual.idClave);
            }
            else
            {
                if (iniciaConNuevoDOc) iniciarNuevoDocumento();
                else { operacionEnCurso = 0; prepararBotones(); }
            }
        }
        private void LlenarCombos()
        {
            recordarOpciones();
            DaxCombobx.CargCmbBox cmb = new DaxCombobx.CargCmbBox();
            cmb.DaxCombosDoc(claseDocDefault, "", false, datosEmpresa.strConxAdcom, ref cmbDocumento);
            cmb.DaxCombosBods(datosEmpresa.suc, false, datosEmpresa.strConxSyscod, ref cmbBodega);
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
            if (cmbBodega.Items.Count > 0)
            {
                if (memBodega.Length > 0) { cmbBodega.SelectedValue = memBodega; } else { cmbBodega.SelectedIndex = 0; }
            }
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

            cmbVendedor.Visible = (datosAuxiliares.tieneDatoDocumento("Vendedor", propiedadesDoc));
            lbVendedor.Visible = cmbVendedor.Visible;

            //labNroLote.Visible = (datosAuxiliares.tieneDatoDocumento("NúmeroLote", propiedadesDoc));
            //txtNroLote.Visible = labNroLote.Visible;

            btnDescuentos.Visible = (datosAuxiliares.tieneDatoDocumento("DescuentoDocumento", propiedadesDoc));

            // chequear lectura de parametros en varbl
            //btnContabiliza.Visible = (datosEmpresa.auto.Substring(3, 1) == "1" && propiedadesDoc.noCtbLinea != "X" && propiedadesDoc.SNContabilizar != 0);
            cmbBodega.Visible = (datosAuxiliares.tieneDatoDocumento("Bodega", propiedadesDoc));
            lbBodega.Visible = cmbBodega.Visible;

            if (accesosLocalizados.sinRegistro == false) registrarAccesosLocalizadosDocumento();

            mallaArticulo.digCostos = valoresPredefinidosEmpresa.nroDigitosEnCostos;
            mallaArticulo.digPrecios = valoresPredefinidosEmpresa.nroDigitosEnPrecios;
            mallaArticulo.fechaDoc = txtfecha.Value;
            mallaArticulo.impIva = claseImpuestos.impstoPorcentaje1;
            mallaArticulo.sucursal = datosEmpresa.suc;
            mallaArticulo.tipoDoc = cmbDocumento.SelectedValue.ToString();

        }
        private void prepararBotones()
        {
            Boolean inicio = (operacionEnCurso == sinOperacion);
            Boolean nuevo = (operacionEnCurso == nuevoRegistro);
            Boolean modificando = (operacionEnCurso == modificandoRegistro);
            Boolean docAnulado = false;

            panelExpress.Enabled = inicio;
            //btnUber.Enabled = inicio;
            //btnGlove.Enabled = inicio;
            //btnLocal.Enabled = inicio;
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
            btnEnviar.Enabled = modificando;
            btnComanda.Enabled = modificando;
            btnGraba.Enabled = (!inicio && !docAnulado);
            btnRegistra.Enabled = btnGraba.Enabled;
            btnListo.Enabled = btnRegistra.Enabled;
            btnEnviar.Enabled = (modificando && !docAnulado);
            btnCierra.Enabled = !inicio;
                btnComanda.Enabled = btnEnviar.Enabled;
            //btnConsolida.Enabled = nuevo;
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

            cmbDocumento.Enabled = (inicio);
            txtcedula.Enabled = (!docAnulado);

            if (datosCierre.FechaIni.Year == 1900) // esta fuera de horario permitido para grabacion de documentos
            {
                btnNuevo.Enabled = false;
                btnGraba.Enabled = false;
            }

            if (datosEmpresa.usr.ToUpper() == "ADMINISTRADOR") return;
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
                btnAbre.Enabled = (btnAbre.Enabled && (accesosLocalizados.Modificar || accesosLocalizados.Consultar));
                btnListo.Enabled = btnRegistra.Enabled;
                btnEnviar.Enabled = (btnEnviar.Enabled && accesosLocalizados.Imprimir); //(accesosLocalizados.Imprimir && !inicio);
                btnNuevo.Enabled = (accesosLocalizados.Crear && btnNuevo.Enabled);
                btnElimina.Enabled = (accesosLocalizados.Eliminar && btnElimina.Enabled);
                btnAnula.Enabled = (accesosLocalizados.Anular && btnAnula.Enabled);
                btnComanda.Enabled = btnEnviar.Enabled;


                //btnCopia.Enabled = (accesosLocalizados.Crear && btnCopia.Enabled);
                //btnConsolida.Enabled = (accesosLocalizados.Crear && btnConsolida.Enabled);

            }
            registrarAccesosLocalizadosDocumento();
            //if (inicio) return;

            if (esSoloConsulta == true || docAnulado)
            {
                btnGraba.Enabled = false;
                btnRegistra.Enabled = false;
                btnElimina.Enabled = false;
                btnAnula.Enabled = false;
                if (datADCDOC.Doc_Estado == 1) btnElimina.Enabled = (datosEmpresa.usr.ToUpper() == "ADMINISTRADOR");
            }
            btnListo.Enabled = btnRegistra.Enabled;
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

            btnPagos.Visible = (accesosLocalizados.FormaDePago );
            //btnContabiliza.Visible = accesosLocalizados.Contabilidad;
            btnPorcentajeIva.Visible = accesosLocalizados.Impuestos;
            btnDescuentos.Visible = accesosLocalizados.DescuentoDocumento;
            btnGastPto.Visible = accesosLocalizados.Gastos;
            btnIngPto.Visible = accesosLocalizados.Ingresos;
            btnCierreCaja.Visible = accesosLocalizados.CierreCaja;
            panelExpress.Visible= accesosLocalizados.EntregaExpress;

            //btnUber.Visible = accesosLocalizados.EntregaExpress;
            //btnGlove.Visible = accesosLocalizados.EntregaExpress;
            //btnLocal.Visible = accesosLocalizados.EntregaExpress;
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
                    txtTelefono2.Text = opalex.telefono2;
                    txtSector.Text = opalex.sector;
                    if (FormaPagoObligatoria == "EMP" && opalex.EsEmpleado == false)
                    {
                        MessageBox.Show("Solo puede emitir facturas a empleados de la compañia","Facturación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        codigo = "";
                    }
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
                txtTelefono2.Text = "";
                opalex = null;
                btnActualizar.Enabled = false;
            }
            else
            {
                btnActualizar.Enabled = true;
            }
            debeActualizarContacto = false;
        }
        private Boolean cargarDatosFactura(string SUC, string TIPO, double IDCLAVE)
        {
            Boolean resp = false;
            if (IDCLAVE != 0)
            {
                operacionEnCurso = 0;
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
                    resp = true;
                    txtnumero.Enabled = false;
                    debeActualizarContacto = false;
                }
            }
            else { }
            prepararBotones();
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
            dcut2.diseñarMallaFacPvT(ref malla, ref propiedadesDoc);

            CMDNbakPv = malla.Columns["TRA_NOMBRE"].ReadOnly;
            CMDNbakUn = malla.Columns["TRA_PRECUNI"].ReadOnly;
            

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
            if (clasePagos.pagosDelDocumento.Count > 0)
            {
                foreach (DaxComercia.pagoDoc pag in clasePagos.pagosDelDocumento)
                {
                    if (pag.IdFormaDePago == "EFE") { txtRecibido.Text = pag.Valor.ToString(); }
                    else if (pag.IdFormaDePago == "CHE") { txtCheque.Text = pag.Valor.ToString(); }
                    else if (pag.IdFormaDePago == "TRJ") { txtTarjeta.Text = pag.Valor.ToString(); }
                    else if (pag.IdFormaDePago == "TR2") { txtTarjeta2.Text = pag.Valor.ToString(); }
                }
            }
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
            try
            {
                datADCDOC.Doc_Bodega = cmbBodega.SelectedValue.ToString();
            }
            catch { datADCDOC.Doc_Bodega = datosEmpresa.Bodega;}
            datADCDOC.Opc_documento = cmbDocumento.SelectedValue.ToString();
            datADCDOC.Doc_docnombre = cmbDocumento.Text;
            datADCDOC.Doc_numero = Convert.ToDecimal(txtnumero.Text);
            datADCDOC.Doc_fecha = Convert.ToDateTime(txtfecha.Text);
            datADCDOC.Doc_codper = codCliente;
            datADCDOC.Doc_CiRuc = txtcedula.Text;
            datADCDOC.Doc_NombreImp = txtnombrecliente.Text;
            datADCDOC.Doc_Direccion = txtdireccion.Text;
            datADCDOC.Doc_Telefono1 = txttelefono.Text;
            datADCDOC.Doc_Telefono2 = txtTelefono2.Text;
            datADCDOC.Doc_detalle = txtDetalle.Text;
            if (cmbVendedor.SelectedValue != null) datADCDOC.Doc_venabre = cmbVendedor.SelectedValue.ToString();
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

            datADCDOC.Doc_NroLoteDoc = ""; // txtNroLote.Text;
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
            datADCDOC.IdClaveDocSop = Convert.ToDecimal(idDocumentoSoporte.idClave);
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

        private void moverDatosClaseComp()
        {
            datADCDOCComp.Doc_sucursal = datosEmpresa.suc;
            try
            {
                datADCDOCComp.Doc_Bodega = cmbBodega.SelectedValue.ToString();
            }
            catch { datADCDOCComp.Doc_Bodega = datosEmpresa.Bodega; }
            datADCDOCComp.Opc_documento = "EGC";
            datADCDOCComp.Doc_docnombre = "Egreso Producto Compuesto";

            datADCDOCComp.Doc_numero = Convert.ToDecimal(numeroEgreso);  //VERIFICAR
            datADCDOCComp.Doc_fecha = Convert.ToDateTime(txtfecha.Text);
            datADCDOCComp.Doc_codper = codCliente;
            datADCDOCComp.Doc_CiRuc = txtcedula.Text;
            datADCDOCComp.Doc_NombreImp = txtnombrecliente.Text;
            datADCDOCComp.Doc_Direccion = txtdireccion.Text;
            datADCDOCComp.Doc_Telefono1 = txttelefono.Text;
            datADCDOCComp.Doc_Telefono2 = txtTelefono2.Text;
            datADCDOCComp.Doc_detalle = "EGC-"+ txtNroID.Text +"-"+cmbDocumento.SelectedValue.ToString()+"-"+ txtnumero.Text; ;
            if (cmbVendedor.SelectedValue != null) datADCDOCComp.Doc_venabre = cmbVendedor.SelectedValue.ToString();
            datADCDOCComp.Doc_DocSop = cmbDocumento.SelectedValue.ToString(); 
            datADCDOCComp.Doc_NumSop = Convert.ToDecimal(txtnumero.Text);
            datADCDOCComp.Doc_valor = 0;  ///VERIFICAR
            datADCDOCComp.AuxVar9 = txtCorreElectronico.Text;

            if (operacionEnCurso == 1)
            {
                datADCDOCComp.PuntoVta = valoresPredefinidosSucursal.nomPuntoVta;
                datADCDOCComp.Doc_Hora = docUtils.DaxNow();
                datADCDOCComp.Doc_Estado = 1;
            }

            datADCDOCComp.Doc_nombredes1 = claseDescuentos.nombreDes[0];
            datADCDOCComp.Doc_nombredes2 = claseDescuentos.nombreDes[1];
            datADCDOCComp.Doc_nombredes3 = claseDescuentos.nombreDes[2];

            datADCDOCComp.Doc_porcendes1 = Convert.ToDecimal(claseDescuentos.porcentajeDes[0]);
            datADCDOCComp.Doc_porcendes2 = Convert.ToDecimal(claseDescuentos.porcentajeDes[1]);
            datADCDOCComp.Doc_porcendes3 = Convert.ToDecimal(claseDescuentos.porcentajeDes[2]);

            datADCDOCComp.Doc_valordes1 = Convert.ToDecimal(claseDescuentos.valorDes[0]); ;
            datADCDOCComp.Doc_valordes2 = Convert.ToDecimal(claseDescuentos.valorDes[1]);
            datADCDOCComp.Doc_valordes3 = Convert.ToDecimal(claseDescuentos.valorDes[2]);

            datADCDOCComp.Doc_porceniva = Convert.ToDecimal(claseImpuestos.impstoPorcentaje1);

            datADCDOCComp.Doc_NroLoteDoc = ""; // txtNroLote.Text;
            datADCDOCComp.Doc_NroIdDoc = "";   //VERIFICAR
            datADCDOCComp.Adi_TipoDocSri = "00";   //VERIFICAR 04 O 4 O QUE
            //datADCDOCComp.Adi_FechContab = IIf(FechaContab < TxtFecha, TxtFecha, FechaContab)
            //datADCDOCComp.Adi_CodigoNSR = TexCodigoExoneraRetencion.Text
            //datADCDOCComp.Adi_SustTrib = DatSustento.BoundText
            //datADCDOCComp'.Adi_SNDevIva = IIf(DerechoIva.Value = 1, "S", "N")
            datADCDOCComp.IdClaveDoc = Convert.ToDecimal(idDocumentoActual.idClave);   ////VERIFICAR
            datADCDOCComp.IdClaveDocSop = datADCDOC.IdClaveDoc;
            datADCDOCComp.Doc_docnombre = "Egreso Producto Compuesto";   //VERIFICAR
            datADCDOCComp.Doc_TipoDoc = "EGB";   //TIPO VERIFICAR EGR
            datADCDOCComp.Doc_FechaEfe = Convert.ToDateTime(txtfecha.Text);     //FechaVence.Value
            datADCDOCComp.Doc_extension = "";
            datADCDOCComp.Doc_codusu = datosEmpresa.usr;
            datADCDOCComp.Doc_valoriva = 0;    //VERIFICAR
            datADCDOCComp.Doc_totciva = 0;    //VERIFICAR
            datADCDOCComp.Doc_totsiva = totalesDocumento.TotSiva;
            datADCDOCComp.Doc_valorabon = 0;  //VERIFICAR   0
            datADCDOCComp.Doc_DepDes = "";
            datADCDOCComp.Doc_TotDesArt = 0;
            datADCDOCComp.Doc_TotDesSer = 0;
            datADCDOCComp.Doc_TotArtCIva = 0;  //VERIFICAR
            datADCDOCComp.Doc_TotArtSIva = 0;
            datADCDOCComp.Doc_TotSerCIva = 0;
            datADCDOCComp.Doc_TotSerSIva = 0;
            datADCDOCComp.Doc_TotAcf = totalesDocumento.TotAcf;
            datADCDOCComp.Doc_Contado = totalesDocumento.ValorEfec;
            datADCDOCComp.Doc_Oculto = propiedadesDoc.ClaveOculto;
            datADCDOCComp.Doc_Contabilidad = propiedadesDoc.ClaveContable;
            datADCDOCComp.Doc_Banco = Convert.ToInt16(propiedadesDoc.ClaveBanco);
            datADCDOCComp.Doc_Inventario = Convert.ToInt16(propiedadesDoc.ClaveInventario);
            datADCDOCComp.Doc_Ventas = Convert.ToInt16(propiedadesDoc.ClaveVentas);
            datADCDOCComp.Doc_Compras = Convert.ToInt16(propiedadesDoc.ClaveCompras);
            datADCDOCComp.Doc_Activo = Convert.ToInt16(propiedadesDoc.ClaveActivo);
            datADCDOCComp.Doc_Adicional2 = 0;
            datADCDOCComp.Doc_NumeroExterno = Convert.ToDecimal(idDocumentoActual.idClave); 
            //datADCDOCComp.IdClaveDocSop = Convert.ToDecimal(idDocumentoSoporte.idClave);
            datADCDOCComp.Doc_FechaModifica = docUtils.DaxNow();
            datADCDOCComp.doc_TotDesSiva = totalesDocumento.totdessiva;
            datADCDOCComp.doc_TotDesCIva = totalesDocumento.totdesciva;
            //datADCDOCComp.Adi_NroAutSri = "";                   //TextNroAutSri
            datADCDOCComp.ProductoProduccion = "";            // ProductoProduccion.Text
            datADCDOCComp.BaseImp1 = 0;   //VERIFICAR
            datADCDOCComp.ValorImp1 = 0;
            datADCDOCComp.PorcImp1 = 0;

            //datADCDOCComp.BaseImp2 = totalesDocumento.Subtotalciva2;
            datADCDOCComp.ValorImp2 = totalesDocumento.TotImp2;
            datADCDOCComp.PorcImp2 = Convert.ToDecimal(claseImpuestos.impstoPorcentaje2);

            //datADCDOCComp.BaseImp3 = totalesDocumento.Subtotalciva3;
            datADCDOCComp.ValorImp3 = totalesDocumento.TotImp2;
            datADCDOCComp.PorcImp3 = Convert.ToDecimal(claseImpuestos.impstoPorcentaje2);

            //datADCDOCComp.FacDesde = FDesde.Value;
            //datADCDOCComp.FacDesde = FDesde.Value;
            //datADCDOCComp.FacDesde = FDesde.Value;
            //datADCDOCComp.FacHasta = FHasta.Value;
            //datADCDOCComp.TipoPeriodo = "";
        }


        private void btnCierra_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma cerrar el documento actual ?", "Cerrar documento sin grabar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No) return;
            limpiarDatos();
        }
        private void limpiarDatos()
        {
            operacionEnCurso = 0;
            txtnumero.Enabled = true;
            datADCDOC = new AdcDoc(datosEmpresa.strConxAdcom);
            datADCDOCComp = new AdcDocComp(datosEmpresa.strConxAdcom);
            clasePagos = new DaxComercia.classPagosDoc();
            claseDescuentos = new adcDescto.descDocumento();
            totalesDocumento = new DctosEmi.docTotals();
            //clasref = new controlReferencial();
            txtcedula.Text = "";
            txtCorreElectronico.Text = "";
            txtDetalle.Text = "";
            txtdireccion.Text = "";
            txtSector.Text = "";
            txtnombrecliente.Text = "";
            txtnumero.Text = "";
            txttelefono.Text = "";
            mensajesDocumento.Text = "";
            txtTelefono2.Text = "";
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
            txtNroID.Text = valoresPredefinidosSucursal.idtributario;
            txtfecha.Value = docUtils.DaxNow();
            txtRecibido.Text = "0";
            txtCheque.Text = "0";
            txtTarjeta.Text = "0";
            txtTarjeta2.Text = "0";
            txtCambio.Text = "0";
            btnActualizar.Enabled = false;
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
            dcut2.diseñarMallaFacPvT(ref malla, ref propiedadesDoc,accesosLocalizados);
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
            //ingresandoCantidad = false;
            if (e.ColumnIndex < 0 || saltaEventosMalla == true)
            {
                return;
            }
            string nomCol = malla.Columns[e.ColumnIndex].Name.ToUpper();
            if (malla.Rows.Count > propiedadesDoc.LineasMaximas && nomCol == "TRA_CODIGO")
            {
                MessageBox.Show("El documento tiene un número máximo de " + propiedadesDoc.LineasMaximas.ToString() + " lineas para su impresión ", "INFORMACION DE DOCUMENTOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (DctosEmi.ValidarDatos.ValidarDatosVentas(nomCol, malla.Rows[e.RowIndex], accesosLocalizados) == false) return;
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
            EnviarAimpresora .imprimirDocumento(datADCDOC,accesosLocalizados,idDocumentoActual);
            prepararBotones();
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
                if (grabarDocumento() == true) { limpiarDatos(); }
            }
        }
        private void btnPagos_Click(object sender, EventArgs e)
        {
            string pagoPredefinido = "";
            if (clasePagos.pagosDelDocumento.Count == 0)
            {
                pagoPredefinido = registrarFormaDePagoPredefinida();
                ValidacionDocumentos.ValidacionGeneral.crearPagoPredefinido(idDocumentoActual,clasePagos,"",Convert.ToDouble("0" + edTotal.Text));
            }
            comercP.MntPago PagosDoc = new comercP.MntPago();
            PagosDoc.INIPagos(idDocumentoActual.idClave, ref clasePagos, opalex.codigo, datosEmpresa.suc, propiedadesDoc.TipoDoc, txtfecha.Text, false, cmbDocumento.SelectedValue.ToString(), Convert.ToDouble("0" + txtnumero.Text), pagoPredefinido, Convert.ToDouble("0" + edTotal.Text), false);
            PagosDoc = null;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (RevisarHorario()) iniciarNuevoDocumento();
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
        private Boolean RevisarHorario()
        {
            if (DateTime.Now > datosCierre.fechaFinalizaCaja )
            {
                MessageBox.Show("Está fuera del horario de atención del punto de venta \n No puede emitir un documento nuevo","Control horario documentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;                
            }
            return true;
        }
        //private void btnPendientes_Click(object sender, EventArgs e)
        //{
        //    porEntregar.frmPorEntregar PorEntregar = new porEntregar.frmPorEntregar
        //    {
        //        fecha = docUtils.DaxNow(),
        //        Cliente = codCliente,
        //        NomCliente = txtnombrecliente.Text,
        //        strConxAdcom = datosEmpresa.strConxAdcom
        //    };
        //    PorEntregar.ShowDialog();
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
            //aqui
            if (validarDocumento() == true)
            {
                if (grabarDocumento() == true)
                {
                    EnviarAimpresora.imprimirDocumentoDirectamente(datADCDOC, accesosLocalizados, idDocumentoActual);
                    if (operacionEnCurso == nuevoRegistro) iniciarNuevoDocumento();
                    else limpiarDatos();
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
            if (txtRecibido.TextLength == 0) txtRecibido.Text = "0";
            if (operacionEnCurso == 0) return;
            decimal valorEfectivo = Convert.ToDecimal("0" + txtRecibido.Text);
            decimal valorCheque = Convert.ToDecimal("0" + txtCheque.Text);
            decimal valorTarjeta = Convert.ToDecimal("0" + txtTarjeta.Text);
            decimal valorTarjeta2 = Convert.ToDecimal("0" + txtTarjeta2.Text);
            decimal totPagos = valorCheque + valorTarjeta + valorTarjeta2 + valorEfectivo;

            try
            {
                decimal cambio = totPagos - totalesDocumento.TotVta;  //Convert.ToDecimal(edTotal.Text);
                if (cambio < 0)
                {
                    txtCambio.BackColor = System.Drawing.Color.Red;
                    labCambio.Text = "FALTA";
                }
                else
                {
                    if (cambio > valorEfectivo)
                    {
                        MessageBox.Show("Error: las formas de pago exceden el valor de la factura", "Registro de pagos factura PtoVta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtRecibido.Text = "0";
                    }
                    txtCambio.BackColor = System.Drawing.Color.White;
                    labCambio.Text = "CAMBIO";
                }
                txtCambio.Text = cambio.ToString();
            }
            catch { txtCambio.Text = ""; }
        }
        private void Txtcedula_Leave(object sender, EventArgs e)
        {

            if (dgvBusquedaSequencial.Visible) return;
            KeyEventArgs ee = new KeyEventArgs(Keys.Return);
            txtcedula_KeyDown(sender, ee);
        }

        private void txtcedula_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return && txtcedula.Text.Length > 0)
            {
                if (dgvBusquedaSequencial.Visible)
                {
                    txtcedula.Text = dgvBusquedaSequencial.Rows[dgvBusquedaSequencial.CurrentCell.RowIndex].Cells["codigo"].Value.ToString();
                    ingresaCodigoClienteDirecto();
                }
                else
                { ingresaCodigoClienteDirecto(); }
            }
        }
        private void ingresaCodigoClienteDirecto()
        {
            dgvBusquedaSequencial.Visible = false;
            string codigo = txtcedula.Text;
            string tipo = "C";
            cargarDatosCliente(codigo);
            if (txtcedula.Text == "")
            {
                dgvBusquedaSequencial.Visible = false;
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
            impresionVerificacion.verificarExistenciaDocumento(ref idDocumentoActual, datosEmpresa.strConxAdcom, false,"ADCDOC", txtNroID.Text);
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
           if (keyData == Keys.Delete && malla.Focused) { EliminarLinea(); return true; };
            return false;
        }
        private void EliminarLinea()
        {
//            if (!mensajesErrorDocumento.ConfirmaEliminar()) return;
            malla.Rows.Remove(malla.CurrentRow);
            //           if (malla.Rows.Count < 1) { dtDetalleDocumento.Rows.Add(dtDetalleDocumento.NewRow()); }
            txtCheque.Text = "0";
            txtRecibido.Text = "0";
            txtTarjeta.Text = "0";
            txtTarjeta2.Text = "0";
            totalizar();
        }
        //private void moverCeldaMalla(DataGridViewCell cell)
        //{
        //    Int32 columnIndex = cell.ColumnIndex;
        //    Int32 rowIndex = cell.RowIndex;
        //    Int32 col = columnIndex;
        //    Int32 row = rowIndex;
        //    Int32 colOk = 0;


        //    if (col < malla.Columns.Count)
        //    {
        //        for (int i = col + 1; i < malla.Columns.Count - 1; i++)
        //        {
        //            if (malla.Columns[i].Visible == true && malla.Columns[i].ReadOnly == false && malla.Columns[i].Name.ToUpper() != "DESCRIPCIÓN") { colOk = i; break; }
        //        }
        //    }

        //    if (colOk == 0)
        //    {
        //        col = 1;
        //        if (row == malla.Rows.Count - 1)
        //        {
        //            dtDetalleDocumento.Rows.InsertAt(dtDetalleDocumento.NewRow(), malla.Rows.Count);
        //            row = malla.Rows.Count - 1;
        //        }
        //        else
        //        {
        //            row++;
        //        }
        //    }
        //    else
        //    {
        //        col = colOk;
        //    }
        //    try
        //    {
        //        malla.CurrentCell = malla.Rows[row].Cells[col];
        //    }
        //    catch { }
        //}

        #endregion manejo malla
        private Boolean funcionesEspeciales(ref Keys keyData, DataGridView malla)
        {

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
                            //DtosMall.docMallaArticulo preVta = new docMallaArticulo();
                            Int32 quePrecio = 0;
                            cell.Value = DaxComercia.cargarPrecios.CargarPrecioVta(Convert.ToInt16(keyData), malla.CurrentRow.Cells["tra_Codigo"].Value.ToString(), claseImpuestos.impstoPorcentaje1, ref quePrecio, "", row.Cells["tra_Medida"].Value.ToString(), "", valoresPredefinidosEmpresa.nroDigitosEnPrecios);
                            //totalizar();
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
                            mallaArticulo.numDoc = txtnumero.Text;
                            mallaArticulo.codCliente = codCliente;
                            if (keyData == Keys.F2)
                            {
                                dato = mallaArticulo.BuscarArticuloSimple(malla.CurrentCell.Value.ToString());
                                if (mallaArticulo.CargarArticulo(malla, ref propiedadesDoc, dato, opalex.TipoCliente, txtfecha.Text, propiedadesDoc.Documento, idDocumentoActual.idClave,PrecioActivo) == false) { cell.Value = ""; keyData = Keys.Cancel; }
                            }
                            else if (keyData == Keys.F3)
                            {
                                DaxConceptos.classConceptos buscserv = new DaxConceptos.classConceptos();
                                dato = buscserv.iniciaBuscador(datosEmpresa.strConxAdcom, "", "V", false, false);
                                if (dato != "") mallaArticulo.CargarServicios(dato, ref malla, claseImpuestos.impstoPorcentaje1, valoresPredefinidosEmpresa.nroDigitosEnPrecios, Convert.ToDateTime(txtfecha.Text), ref propiedadesDoc);
                            }
                            else if (keyData == Keys.Return && dato.Length > 0)
                            {
                                if (mallaArticulo.CargarConDesicion(malla, ref propiedadesDoc, dato, opalex.TipoCliente, txtfecha.Text, propiedadesDoc.Documento, idDocumentoActual.idClave,PrecioActivo) == false) { cell.Value = ""; keyData = Keys.Cancel; }
                            }
                            else if (keyData == Keys.F11)
                            {
                                dato = mallaArticulo.BuscarArticulo(malla.CurrentCell.Value.ToString());
                                if (mallaArticulo.CargarArticulo(malla, ref propiedadesDoc, dato, opalex.TipoCliente, txtfecha.Text, propiedadesDoc.Documento, idDocumentoActual.idClave,PrecioActivo ) == false) { cell.Value = ""; keyData = Keys.Cancel; }
                            }

                            //        VerificarClasificadoresContablesArticulo dato
                        }
                        break;
                    case "TRA_NOMBRE":
                        if (dato != ".")
                        {
                            try
                            {
                                mallaArticulo.bodega = ""; //cmbBodega.SelectedValue.ToString();
                            }
                            catch { }
                            saltaEventosMalla = true;
                            mallaArticulo.numDoc = txtnumero.Text;
                            mallaArticulo.codCliente = codCliente;
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
           // mallaArticulo = null;
            return resp;
        }
        private string registrarFormaDePagoPredefinida()
        {
            //aqui servicio
            if (CMDNbakCod == "CMDN") return "CON";
            if (FormaPagoObligatoria != "") return FormaPagoObligatoria;
            if (opalex.FormaPago != null && opalex.FormaPago.Length > 0) return opalex.FormaPago;
            if (valoresPredefinidosEmpresa.formaPagoPredefinidaVtas.Length > 0) return valoresPredefinidosEmpresa.formaPagoPredefinidaVtas;
            return "EFE";
        }

        //private void crearPagoPredefinido(string IdPago, double valor = 0)
        //{
        //    if (IdPago == "") IdPago = "EFE";
        //    if (valor == 0) Convert.ToDouble(edTotal.Text);
        //    clasePagos.DocValor = valor;
        //    clasePagos.DocFecha = txtfecha.Value;
        //    clasePagos.DocNumero = Convert.ToDouble(txtnumero.Text);
        //    clasePagos.DocSucursal = datosEmpresa.suc;
        //    clasePagos.Doctipo = cmbDocumento.SelectedValue.ToString();
        //    clasePagos.pagosDelDocumento.Add(DaxComercia.utility.CrearPagoDocumento(IdPago, clasePagos.DocValor));
        //}


        private void btnEstadoCta_Click(object sender, EventArgs e)
        {
            if (codCliente == "") return;
            CargarDocmtosAplicar(codCliente);
        }
        
        private void CargarDocmtosAplicar(string codCliente)
        {
            DocPendientes.ListDocAplican listaDocAplicados = new DocPendientes.ListDocAplican();
            DateTime fechInicio = new DateTime(1900,1,1);
            DocPendientes.frmDocPndt prog = new DocPendientes.frmDocPndt(listaDocAplicados, codCliente, txtnombrecliente.Text, idDocumentoActual, "", 0, "C", true, fechInicio, txtfecha.Value);
            prog.ShowDialog();
            prog.Dispose();
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

        private void malla_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Error de dato digitado, el valor registrado es inválido");
        }

        private Boolean validarDocumentoCompuesto()
        {

            moverDatosClaseComp();
            return true;
        }


        private Boolean validarDocumento()
        {
            //            string docsustento = "";
            string FormaDePago = FormaPagoObligatoria;
            if (Convert.ToDouble(edTotal.Text) == 0)
            {
                MessageBox.Show("No se puede emitir una factura en valor 0"); return false;
            }
            if (FormaDePago.Length == 0) FormaDePago = registrarFormaDePagoPredefinida();
            if (ValidacionDocumentos.ValidacionGeneral. verificarFormaDePago(idDocumentoActual,clasePagos,FormaDePago ,edTotal.Text ,txtCambio.Text,txtRecibido.Text,txtCheque.Text ,txtTarjeta.Text, txtTarjeta2.Text, codCliente,opalex.limitecredito) == false) { return false; }
            if (Convert.ToDouble("0" + txtnumero.Text) == 0) { mensajesErrorDocumento.MensajeNumeroDoc(); txtnumero.Focus(); return false; }
            if (ValidacionDocumentos.ValidacionGeneral.validarFecha(txtfecha.Text, datosEmpresa.usr) == false) { return false; };
            if (opalex.codigo == "" || codCliente == "" || txtcedula.Text == "") { mensajesErrorDocumento.ElCodigoNoExiste("C"); return false; }
            if (ValidacionDocumentos.ValidacionGeneral.validarIngresoDetalle(malla) == false) { mensajesErrorDocumento.sinArtículosOservicios(); return false; }
//            if (ValidacionDocumentos.ValidacionGeneral.ControlValidacionFacCli(ref malla, ref propiedadesDoc, clasref, txtfecha.Text, datosEmpresa.suc, datosEmpresa.strConxAdcom, datosEmpresa.strConxSyscod, idDocumentoActual.idClave, cmbBodega.SelectedValue.ToString(), txtnumero.Text, entregasPendientes, datosEmpresa.suc, docsustento, "") == false) return false;
            if (ValidacionDocumentos.ValidacionGeneral.ValidarCorreoElectronicoVtas(txtCorreElectronico.Text)==false){ mensajesErrorDocumento.CorreoElectronicoErrado();return false;}
            if (txtnombrecliente.TextLength == 0 || txtdireccion.TextLength == 0 || txttelefono.TextLength == 0 ) { mensajesErrorDocumento.InfDeContactoNoCorrecta();return false;}
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
                    actualizaDatosPagos();
                    if (res.Substring(0, 3) != "ERR") {
                        grabarAdctra(); 
                    }
                    string tipDoc = cmbDocumento.SelectedValue.ToString();
                    //string tipBan = "";
                    //					if (idDocumentoActual.idClave != 0) propiedadesDoc.GuardarNumero(ref datosEmpresa.suc, ref tipDoc, ref tipBan, txtNroID.Text, "", datosEmpresa.usr, cmbBodega.SelectedValue.ToString());
                    clasePagos.guardarPagosDocumento("ADCPAG");
                    ClaveElectronica.actualizarClaveElectronica(datADCDOC);
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
        private void ActualizarDatosCliente()
        {
            string insertar = "update identificacion set HistoriaClinica = '" + txtcedula.Text + "'";
            insertar += ", correoElectrónico = '" + txtCorreElectronico.Text + "'";
            insertar += ", Telefono1 = '" + txttelefono.Text + "'";
            insertar += ", Domicilio = '" + txtdireccion.Text + "'";
            insertar += ", Sector = '" + txtSector.Text + "'";
            insertar += " where Codigo = '" + txtcedula.Text + "' or CedulaIdentidadRuc = '" + txtcedula.Text + "' ";
            using (SqlConnection conn = new SqlConnection(datosEmpresa.strConxAdcom))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand(insertar, conn))
                {
                    comm.ExecuteNonQuery();
                }
            }
        }

        private void actualizaDatosPagos()
        {
            clasePagos.DocFecha = idDocumentoActual.fecha;
            clasePagos.DocNumero = idDocumentoActual.numero;
            clasePagos.DocSucursal = idDocumentoActual.Sucursal;
            clasePagos.Doctipo = idDocumentoActual.Tipo;
            clasePagos.idClaveDoc = idDocumentoActual.idClave;

        }
        //private bool verificarFormaDePago()
        //{
        //    bool tieneLiq = false;

        //    double cambio = 0;
        //    if (txtCambio.Text.Length > 0)
        //    {
        //        cambio = Convert.ToDouble(txtCambio.Text);
        //        if (cambio < 0)
        //        {
        //            MessageBox.Show("Error: El pago registrado no está completo", "Control pagos documentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            return false;
        //        }
        //    }
        //    double valorEfectivo = Convert.ToDouble("0" + txtRecibido.Text) - cambio;
        //    double valorCheque = Convert.ToDouble("0" + txtCheque.Text);
        //    double valorTarjeta = Convert.ToDouble("0" + txtTarjeta.Text);
        //    double totPagos = valorEfectivo + valorCheque + valorTarjeta;


        //    if (clasePagos.pagosDelDocumento.Count == 0)
        //    {
        //        if (totPagos == 0) { crearPagoPredefinido(registrarFormaDePagoPredefinida(), Convert.ToDouble(totalesDocumento.TotVta)); }
        //        else
        //        {
        //            if (valorEfectivo > 0) crearPagoPredefinido("EFE", valorEfectivo);
        //            if (valorCheque > 0) crearPagoPredefinido("CHE", valorCheque);
        //            if (valorTarjeta > 0) crearPagoPredefinido("TRJ", valorTarjeta);
        //        }                
        //    }

        //    MntPago dp = new MntPago();
        //    tieneLiq = false;
        //    double TotalPago = 0;
        //    double valorCredito = 0;
        //    double valorContado = 0;

        //    foreach (DaxComercia.pagoDoc elPago in clasePagos.pagosDelDocumento)
        //    {
        //        TotalPago += elPago.Valor;
        //        if (!tieneLiq) tieneLiq = (elPago.Descripcion.Contains("RETENCI"));
        //        if (elPago.PagoACredito == 2) { valorCredito += elPago.Valor; }
        //        else { valorContado += elPago.Valor; }
        //        if (elPago.TipoPag == "0") { valorEfectivo += elPago.Valor; }
        //    }
        //    if (Math.Round(TotalPago, 2) != Math.Round(Convert.ToDouble(totalesDocumento.TotVta), 2))
        //    {
        //        mensajesErrorDocumento.pagoDifiereTotalDoc();
        //        clasePagos = new DaxComercia.classPagosDoc();
        //        return false;
        //    }

        //    if (opalex.limitecredito > 0)
        //    {
        //        double saldoCliente = 0;
        //        string cod = "exec ADC_CCINDU '" + opalex.codigo + "','" + "01/01/1901" + "','" + txtfecha.Text + "'," + 0 + ",0,0,'C','',0,'" + datosEmpresa.suc + "','" + propiedadesDoc.Documento + "'," + idDocumentoActual.idClave.ToString();
        //        DataTable dt = utilBasDatos.utilBasDatos.leerTablas(cod, datosEmpresa.strConxAdcom);
        //        if (dt.Rows.Count > 0) saldoCliente = Convert.ToDouble(dt.Rows[0]["Saldo"].ToString());
        //        if (saldoCliente + valorCredito > opalex.limitecredito)
        //        {
        //            mensajesErrorDocumento.ventaExcedeCredito();
        //            return false;
        //        }
        //    }
        //    clasePagos.totalContado = valorContado;            
        //    return true;
        //}


        private void iniciarNuevoDocumentoComp()
        {
            datADCDOCComp = new AdcDocComp(datosEmpresa.strConxAdcom);
            idDocumentoCompuesto = new idDocumento
            {
                //familia = propiedadesDoc.TipoDoc,
                familia = "EGR",
                fecha = txtfecha.Value,
                numero = Convert.ToDouble("0"),
                Serie = "",
                Sucursal = datosEmpresa.suc,
                Tipo = "EGC"
            };
            string bod = "";
            if (cmbBodega.SelectedValue != null) bod = cmbBodega.SelectedValue.ToString();
            ClassDoc.controlNumeracion cnum = new controlNumeracion();
            numeroEgreso = cnum.NumeroMayor(idDocumentoCompuesto, "", "", "", datosEmpresa.strConxAdcom).ToString();
            
            
        }
        private void grabarAdctra()
        {
            int cantidadC = 0;
            int existe = 0;
            ;
            DataTable dtn = new DataTable();

            foreach (DataGridViewRow row in malla.Rows)
            {
                if (row.Cells["CMB"].Value.ToString().Length > 0)
                {
                    row.Cells["tra_nombre"].Value += row.Cells["CMB"].Value.ToString();
                }
                if (row.Cells["COMP"].Value.ToString() == "True")
                {
                    existe++;                
                    codigoC = row.Cells["tra_codigo"].Value.ToString();
                    cantidadC =Convert.ToInt32(row.Cells["tra_cantidad"].Value);
                    dtn.Merge(VerificarCompuesto(codigoC, cantidadC));
                    MallaComp.DataSource = dtn;
                }
            }
                if (existe > 0)
                {
                DataTable tabla = new DataTable();
                    double clav = idDocumentoActual.idClave;
                    tabla=verificarCompuestoExiste(txtnumero.Text,"FAC",clav);
				if (tabla.Rows.Count==0)
				{
                    iniciarNuevoDocumentoComp();
                    validarDocumentoCompuesto();                   
                    datADCDOCComp.Crear();
                    grabMallTra.grabarMallaAdctraComp(MallaComp, datADCDOCComp, datosEmpresa.strConxAdcom);
                }
                    
                }
            

            grabMallTra.grabarMallaAdctra(malla, datADCDOC, datosEmpresa.strConxAdcom);
        }

		private DataTable verificarCompuestoExiste(string txtnumero, string text, double idClave)
		{
            //DataTable dt = utilBasDatos.utilBasDatos.leerTablas(cod, datosEmpresa.strConxAdcom);
            string ssql = "SELECT * FROM ADCDOC WHERE OPC_DOCUMENTO='EGC'  and Doc_DocSop='"+text+ "' and Doc_NumSop= "+txtnumero+" AND IdClaveDocSop="+idClave;
            DataTable dt = utilBasDatos.utilBasDatos.leerTablas(ssql, datosEmpresa.strConxAdcom);
            return dt;
            
        }

		private DataTable VerificarCompuesto(string _codigo,int _cantidad)
        {
            string ssql = "select '' AS TRA_NUMLINEA ,a.art_codigo as TRA_CODIGO,a.art_nombre as Tra_nombre,a.Art_unimed as tra_medida, COM_CantidadBase*c.COM_Cantidad*" + _cantidad+" as tra_cantidad,0 tra_precuni,0 tra_porcendes,0 tra_valordes,";
            ssql += "0 Tra_prectot,0 Tra_sniva ,'' tra_piezas,'A' Tra_quetipo,0 tra_esCuenta,'' tra_individual,'' tra_costuni,'' tra_CostTot,1 tra_multiplo,1 tra_numprecio,";
            ssql += "'' Existencia,0 limiteDescuento,'' descuentoArticulo,0 precioArticulo,'' medidaArticulo,'' Serv,'' Cmb,'' Tra_siniva1,";
            ssql += " '' AuxVar3,'' Cort,'' AuxNum1 FROM AdcCompon AS c LEFT OUTER JOIN AdcArt AS a ON c.COM_Codigo = a.Art_codigo  where pro_codigo ='" + _codigo +"'";

           
            dt=utilBasDatos.utilBasDatos.leerTablas(ssql, datosEmpresa.strConxAdcom);
            return dt;
        }

        private void totalizar()
        {
            if (malla.Rows.Count < 1) return;
            //			this.malla.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.malla_CellValueChanged);
            if (claseImpuestos.cambiadoManual == false)
            {
                if (claseImpuestos.impstoPorcentaje1 == 0 || claseImpuestos.impstoFechaIni1 > txtfecha.Value || claseImpuestos.impstoFechaFin1 < txtfecha.Value) claseImpuestos.cargar(datosEmpresa.strConxIvaret, txtfecha.Value);
            }
            totalesDocumento = new DctosEmi.docTotals();
            edTotal.Text = Convert.ToString(totalesDocumento.totalizar(malla, Convert.ToDecimal(claseImpuestos.impstoPorcentaje1), claseDescuentos, clasePagos, propiedadesDoc, valoresPredefinidosEmpresa.nroDigitosEnPrecios, valoresPredefinidosEmpresa.nroDigitosEnCostos));
            presentarTotales();
            //			this.malla.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.malla_CellValueChanged);
            btnPagos.Enabled = (totalesDocumento.TotVta > 0);
            //sumarPartePago();
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

        private void LlenarIdDocumento(ref idDocumento docmtoActual)
        {
            docmtoActual.Sucursal = datosEmpresa.suc;
            docmtoActual.Tipo = cmbDocumento.SelectedValue.ToString();
            docmtoActual.fecha = txtfecha.Value;
            try
            {
                docmtoActual.numero = Convert.ToDouble(txtnumero.Text);
            }
            catch { docmtoActual.numero = 0; }
        }

        private void ChequearCambioValoresPoFecha()
        {
            //totalizar();
        }


        private void btnPorcentajeIva_Click(object sender, EventArgs e)
        {
            Buscar.frmBuscar progBus = new Buscar.frmBuscar();
            string ssql = "select  Porcentaje, isnull(fechaInicio,'01/01/1900') as ValidoDesde";
            ssql += ", isnull(FechaFin,'31/12/2078') as ValidoHasta from porcentajeiva";
            string nvoIva = progBus.Buscar(datosEmpresa.strConxIvaret, ssql, "porcentaje", "porcentaje", "", "Seleccionar porcentaje IVA", "");
            if (MessageBox.Show("Confirma cambiar el porcentaje del IVA en el documento ?", "Cambiar porcentaje del IVA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            claseImpuestos.cambiadoManual = true;
            claseImpuestos.impstoPorcentaje1 = Convert.ToDouble("0" + nvoIva);
            totalizar();
        }
        private void ptoVenta_Click(object sender, EventArgs e)
        {

            string ssql = " select Pto_codigo + ' / ' + Pto_nombre as NombrePuntoVta from emp_ptovta where emp_codigo = '" + datosEmpresa.codEmpresa + "' and suc_codigo = '" + datosEmpresa.suc + "'";
            Buscar.frmBuscar busca = new Buscar.frmBuscar();
            string pv = busca.Buscar(datosEmpresa.strConxSyscod, ssql, "NombrePuntoVta", "NombrePuntoVta", "", "PUNTOS DE VENTA");
            int indx = pv.IndexOf("/");
            if (indx > 0)
            {
                valoresPredefinidosSucursal.idPuntoVta = pv.Substring(0, indx - 1);
                valoresPredefinidosSucursal.nomPuntoVta = pv.Substring(indx + 2);
                IniciarDatosPuntoDeventa();
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
            if (cmbBodega.SelectedValue != null) { AuditSis.registrar.registraPreferencia(datosEmpresa.strConxSyscod, datosEmpresa.codEmpresa.ToString(), datosEmpresa.usr, "ADX", datosEmpresa.suc, "Facturacion", "Bodega", cmbBodega.SelectedValue.ToString()); }
            if (cmbVendedor.SelectedValue != null) { AuditSis.registrar.registraPreferencia(datosEmpresa.strConxSyscod, datosEmpresa.codEmpresa.ToString(), datosEmpresa.usr, "ADX", datosEmpresa.suc, "Facturacion", "Vendedor", cmbVendedor.SelectedValue.ToString()); }
        }
        private void recordarOpciones()
        {
            memTipoDoc = AuditSis.registrar.obtenerPreferencia(datosEmpresa.strConxSyscod, datosEmpresa.codEmpresa.ToString(), datosEmpresa.usr, "ADX", datosEmpresa.suc, "Facturacion", "TipoDoc");
            memBodega = AuditSis.registrar.obtenerPreferencia(datosEmpresa.strConxSyscod, datosEmpresa.codEmpresa.ToString(), datosEmpresa.usr, "ADX", datosEmpresa.suc, "Facturacion", "Bodega");
            memVendedor = AuditSis.registrar.obtenerPreferencia(datosEmpresa.strConxSyscod, datosEmpresa.codEmpresa.ToString(), datosEmpresa.usr, "ADX", datosEmpresa.suc, "Facturacion", "Vendedor");
        }

        private void FormFacPV_FormClosed(object sender, FormClosedEventArgs e)
        {
            registraOpciones();
        }

        private void malla_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (malla.Rows.Count == 0) dtDetalleDocumento.Rows.Add(dtDetalleDocumento.NewRow());
        }

        private void cargarImagenesArticulos()
        {

            string ssql = "select * from DaxLeeImgPtoVtaT ";
            //if (datosEmpresa.Emp_PathImagenes.Length  >0 && datosEmpresa.Emp_PathImagenes.Substring(datosEmpresa.Emp_PathImagenes.Length - 1, 1) != "\\") datosEmpresa.Emp_PathImagenes += "\\";
            this.imageList1.ImageSize = new Size(60, 50);
                
            using (SqlDataAdapter dr = new SqlDataAdapter(ssql, datosEmpresa.strConxAdcom))
            {
                DataTable dt = new DataTable();
                dr.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    try
                    {
                        string logotipo = row["Art_logotipo"].ToString();
                        if (logotipo.Length > 0)
                        {
                            if (File.Exists(datosEmpresa.Emp_PathImagenes + logotipo))
                                this.imageList1.Images.Add(row["art_codigo"].ToString(), Image.FromFile(datosEmpresa.Emp_PathImagenes + logotipo));
                        }
                    }
                    catch  { }
                }
            }
            cargarArticulosPorClase(PonerBotonesClases());
        }
        private void cargarArticulosPorClase(string clase)
        {
            claseItemEnCurso = clase;
            this.listaImagenes.Clear();
            this.listaImagenes.LargeImageList = imageList1;
            //if (tipoItemEnCurso != "S") 
            //{ 
            this.listaImagenes.View = View.LargeIcon;
            //}
            //else { this.listView1.View = View.SmallIcon; }

            string ssql = "DaxLeeProdPtoVtaT '" + clase + "'," + (claseImpuestos.impstoPorcentaje1 / 100).ToString(); // +","+PrecioActivo.ToString();

            using (SqlDataAdapter dr = new SqlDataAdapter(ssql, datosEmpresa.strConxAdcom))
            {
                DataTable dt = new DataTable();
                dr.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    ListViewItem item = new ListViewItem

                    {
                        Name = row["art_codigo"].ToString()
                        
                    };
                    item.ImageKey = item.Name;
                    //        item.UseItemStyleForSubItems = true;
                    double val = 0;
                    if (PrecioActivo == 1) {  val = Convert.ToDouble("0" + row["PrecioConIva"].ToString()); }
                    else if (PrecioActivo == 2) { val = Convert.ToDouble("0" + row["PrecioConIva2"].ToString()); }
                    else if (PrecioActivo == 3) { val = Convert.ToDouble("0" + row["PrecioConIva3"].ToString()); }
                    else if (PrecioActivo == 4) { val = Convert.ToDouble("0" + row["PrecioConIva4"].ToString()); }
                    else if (PrecioActivo == 5) { val = Convert.ToDouble("0" + row["PrecioConIva5"].ToString()); }
                    if (row["art_codigo"].ToString() != "S")
                    {
                        item.Text = row["nombreCorto"].ToString() + " $ " + val.ToString("N2");
                        }
                    else
                    {
                        item.Text = row["ART_NOMBRE"].ToString() + " $ " + val.ToString("N2");
                    }
                    this.listaImagenes.Items.Add(item);
                }
            }
        }
        //private string precioVenta(double precio, int incluyeIva)
        //{
        //    return Math.Round(precio / (1 + (claseImpuestos.impstoPorcentaje1 / 100) * incluyeIva), 2).ToString();
        //}
        private string PonerBotonesClases()
        {
            Int32 tope = 5;
            int tabIzq = 5;
            string primerboton = "";
            string ssql = "DaxLeeLinPtoVtaT";
            using (SqlDataAdapter da = new SqlDataAdapter(ssql, datosEmpresa.strConxAdcom))
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
                    Boton1.Top = tope;                    
                    Boton1.Left =  tabIzq;
                    Boton1.Height = 35;
                    Boton1.Width = 70;
                    Boton1.TextAlign = ContentAlignment.MiddleCenter;
                    Boton1.Name = row["niv_Abrevia"].ToString();
                    Boton1.Text = row["niv_nombre"].ToString();
                    Boton1.Tag = row["tipo"].ToString();
                    Boton1.Click += new System.EventHandler(this.Boton_Click);
                    if (primerboton == "") { primerboton = Boton1.Name; tipoItemEnCurso = Boton1.Tag.ToString(); }
                    PanelControles.Controls.Add(Boton1);
                    i++;
                    tabIzq += Boton1.Width + 5;
                    if ((tabIzq + 75 ) > PanelControles.Width) { PanelControles.Height += 40; tope += 40; tabIzq = 5; }
                }
            }
            return primerboton;
        }
        private void Boton_Click(object sender, System.EventArgs e)
        {
            Button text = (Button)sender;
            cargarArticulosPorClase(text.Name);
            tipoItemEnCurso = text.Tag.ToString();
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            if (listaImagenes.SelectedItems.Count < 1) return;
            ListViewItem item = listaImagenes.SelectedItems[0];
            recuperandoItem(item.Name);
            //recuperandoItem(item.Text);
            clasePagos.pagosDelDocumento.Clear();
        }

        private void recuperandoItem(string codigo)
        {

            if (malla.Rows.Count == 0) dtDetalleDocumento.Rows.Add(dtDetalleDocumento.NewRow());
            if (malla.Rows.Count == 0) return;
            malla.CurrentCell = malla.Rows[malla.Rows.Count - 1].Cells["tra_nombre"];
            if (codigo.Length > 0)
            {
                if (malla.Rows.Count > 0)
                {
                    if (aumentarCantidad(codigo)) return;
                }
                if (tipoItemEnCurso != "S")
                {
                    mallaArticulo.CargarArticuloinmediato(malla.Rows[malla.Rows.Count - 1], ref propiedadesDoc, codigo, "", DateTime.Now.ToShortDateString(), cmbDocumento.SelectedValue.ToString(), 0,PrecioActivo);
                }
                else
                {
                    mallaArticulo.CargarServicios(codigo, ref malla, claseImpuestos.impstoPorcentaje1/100,valoresPredefinidosEmpresa.nroDigitosEnPrecios, txtfecha.Value, ref propiedadesDoc);
                }
                dtDetalleDocumento.Rows.Add(dtDetalleDocumento.NewRow());
                malla.CurrentCell = malla.Rows[malla.Rows.Count - 1].Cells["tra_nombre"];
                totalizar();
            }
        }

        private bool aumentarCantidad(string codArticulo)
        {
            bool resp = false;
            foreach (DataGridViewRow row in malla.Rows)
            {
                double valor = 0;
                    try
                {
                    valor = Convert.ToDouble(row.Cells["auxnum1"].Value);
                }
                catch { }

                if (row.Cells["tra_codigo"].Value.ToString() == codArticulo && valor == 0 )
                {
                    row.Cells["tra_cantidad"].Value = Convert.ToDecimal(row.Cells["tra_cantidad"].Value) + 1;
                    resp = true;
                }
            }
            totalizar();
            return resp;

        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            if (malla.CurrentCell == null) return;
            //			if (malla.Columns[malla.CurrentCell.ColumnIndex].Name.ToUpper()=="TRA_CANTIDAD")
            {
                ToolStripButton boton = sender as ToolStripButton;
                if (boton.Text == "CR")
                {
                    SendKeys.Send("{ENTER}"); return;
                }
                if (boton.Text == "DEL")
                {
                    SendKeys.Send("{DEL}"); return;
                }
                SendKeys.Send(boton.Text);
            }
            clasePagos.pagosDelDocumento.Clear();
        }

        private void txtcedula_TextChanged(object sender, EventArgs e)
        {
            if (txtcedula.Focused == false)
            {
                dgvBusquedaSequencial.Visible = false;
                return;
            }
            if (operacionEnCurso < 2 && txtcedula.Text.Length > 3)
            {
                string ssql = "select codigo, ltrim(apellidos + ' ' + NombreImpresion) as Nombre from Identificacion";
                ssql += " where CedulaIdentidadRuc like('" + txtcedula.Text + "%') ";
                ssql += " order by ltrim(apellidos + ' ' + NombreImpresion)";
                using (SqlDataAdapter da = new SqlDataAdapter(ssql, datosEmpresa.strConxAdcom))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvBusquedaSequencial.DataSource = dt;
                    if (dt.Rows.Count > 0) { dgvBusquedaSequencial.Visible = true; } else { dgvBusquedaSequencial.Visible = false; }
                }
            }
            else
            {
                dgvBusquedaSequencial.Visible = false;
                dgvBusquedaSequencial.DataSource = null;
            }

        }

        private void dgvBusquedaSequencial_DoubleClick(object sender, EventArgs e)
        {
            // CMDN
            txtcedula.Text = dgvBusquedaSequencial.Rows[dgvBusquedaSequencial.CurrentCell.RowIndex].Cells["codigo"].Value.ToString();
            dgvBusquedaSequencial.Visible = false;
            if (txtcedula.Text.Length > 0) ingresaCodigoClienteDirecto();
        }

        private void malla_CellLeave(object sender, DataGridViewCellEventArgs e)
        {

            malla.Columns["TRA_NOMBRE"].ReadOnly= CMDNbakPv;
            malla.Columns["TRA_PRECUNI"].ReadOnly= CMDNbakUn;
            //ingresandoCantidad = false;
        }

        //private void txtRecibido_DoubleClick(object sender, EventArgs e)
        //{
        //	txtRecibido.Text = totalesDocumento.TotVta.ToString();
        //}

        //private void txtCheque_DoubleClick(object sender, EventArgs e)
        //{
        //	txtCheque.Text = totalesDocumento.TotVta.ToString();
        //}

        //private void txtTarjeta_DoubleClick(object sender, EventArgs e)
        //{
        //	txtTarjeta.Text = totalesDocumento.TotVta.ToString();
        //}

        private void txtRecibido_KeyPress(object sender, KeyPressEventArgs e)
        {
           TextBox caja = (TextBox)sender;
            if (char.IsDigit(e.KeyChar))
            { e.Handled = false; }
            else if (char.IsControl(e.KeyChar))
            { e.Handled = false; }
            else if (char.IsSeparator(e.KeyChar))
            { e.Handled = false; }
            else if (e.KeyChar == Convert.ToChar(".") && caja.Text.IndexOf(".") < 0)
            { e.Handled = false; }
            else { e.Handled = true; }
        }

        private void malla_Click(object sender, EventArgs e)
        {
            if (malla.CurrentCell == null) return;
            DataGridViewCell cell = malla.CurrentCell;
            string dato = cell.Value.ToString();
            string nombreCelda = cell.OwningColumn.Name.ToUpper();
           
            switch (nombreCelda)
            {
                case "CMB":
                    frmCambPlto prog = new frmCambPlto(dato);
                    dato = prog.obtenerCambios();
                    prog.Dispose();
                    break;
                case "SERV":
                    if (dato == "Servir") { dato = "Llevar"; }
                    else if (dato == "Llevar") { dato = "Domicilio"; }
                    else { dato = "Servir"; }
                    break;

                case "CORT":
                    if (malla.CurrentRow.Cells["Tra_codigo"].Value == null || malla.CurrentRow.Cells["Tra_codigo"].Value.ToString().Length == 0) return;
                    bool r = false;
                    try { r = Convert.ToBoolean(cell.Value); } catch { }
                    if (r == false) r = AutorizarCortesia();
                    else r = false;
                    cambiarPrecioCortesia(r, malla.CurrentRow);
                    cell.Value = r;
                    listaImagenes.Focus();
                    return;
                    //break;
            }
            //if (cell.ValueType.Name == "Boolean")
            //{
            //    bool r = false;
            //    try { r = Convert.ToBoolean(cell.Value);}catch { }
            //    if (r == false) r = AutorizarCortesia();
            //    else r = false;
            //    cell.Value = !r;
            //}
            //else
            //{
            cell.Value = dato; 
        //}
            
        }
        private void cambiarPrecioCortesia(Boolean cort, DataGridViewRow linea)

        {

            //double descuento = 0;
            double valbak = 0;
            try { valbak = Convert.ToDouble(linea.Cells["Auxnum1"].Value); } catch { }
            if (linea.Cells["Tra_precuni"].Value == null) return;
            if (cort == false && valbak > 0)
            {
               // linea.Cells["Tra_precuni"].Value = linea.Cells["Auxnum1"].Value;
                linea.Cells["Auxnum1"].Value = 0;
                EliminarLinea();
            }
            else if(cort)
            {
                linea.Cells["Auxnum1"].Value = linea.Cells["Tra_precuni"].Value;
                linea.Cells["Tra_precuni"].Value = 0;
            }
            DaxMallaLib.Documentos.MoverCelda(malla,false);
            //foreach (DataGridViewRow dgvrow in malla.Rows)
            //{
            //    try
            //    {
            //        descuento += Convert.ToDouble(dgvrow.Cells["Tra_precuni"].Value) * Convert.ToDouble(dgvrow.Cells["tra_cantidad"].Value);
            //    }
            //    catch { }
            //}

            //claseDescuentos.porcentajeDes[0] = 0;
            //claseDescuentos.descuentoTot[0] = descuento;
            //if (descuento > 0) claseDescuentos.nombreDes[0] = "Descuento por Cortesia :";
            //claseDescuentos.valorDes[0] = descuento;
           
            totalizar();
        }
        private bool AutorizarCortesia()
        {
            FrmClaveCortesia prog = new FrmClaveCortesia(" CORTESIA ");
            bool resp = prog.IngresarClaveCortesia(DatosUsuario.Identifica);
            prog.Dispose();
            return resp;
        }

        private void FormFacPVTA_Resize(object sender, EventArgs e)
        {
            Int32 tope = 5;
            int tabIzq = 5;
            PanelControles.Height = 45;
            foreach (Control cnt in PanelControles.Controls)
            {
                cnt.Top = tope;
                cnt.Left = tabIzq;
                tabIzq += cnt.Width + 5;
                if ((tabIzq + 75) > PanelControles.Width) { PanelControles.Height += 40; tope += 40; tabIzq = 5; }
            }
        }

        private void btnIngPto_Click(object sender, EventArgs e)
        {
             DaxMovCaja.IngMovCaja  frmmov = new DaxMovCaja.IngMovCaja("I", valoresPredefinidosSucursal.nomPuntoVta, datosEmpresa.strConxAdcom);
            frmmov.ShowDialog();
            frmmov.Dispose();
        }

        private void btnGastPto_Click(object sender, EventArgs e)
        {
            DaxMovCaja.IngMovCaja frmmov = new DaxMovCaja.IngMovCaja("G", valoresPredefinidosSucursal.nomPuntoVta, datosEmpresa.strConxAdcom);
            frmmov.ShowDialog();
            frmmov.Dispose();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            CierreDeCaja.frmCierrCaja prog = new CierreDeCaja.frmCierrCaja (datosCierre);
            prog.ShowDialog();
            prog.Dispose();
            if (datosCierre.FechaFin > new DateTime(1900, 12, 31)) {Close();this.Dispose(); }
        }

        private void txtCheque_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                txtCheque.Text = (Math.Round(Convert.ToDouble("0" + edTotal.Text) - Convert.ToDouble("0"+txtTarjeta.Text) - Convert.ToDouble("0" + txtTarjeta2.Text) - Convert.ToDouble("0" + txtRecibido.Text),2)).ToString();
                if (Convert.ToDouble("0" + txtCheque.Text) < 0) txtCheque.Text = "0";
            }
        }

        private void txtRecibido_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)

            {
                txtRecibido.Text = (Math.Round(Convert.ToDouble("0" + edTotal.Text) - Convert.ToDouble("0" + txtTarjeta.Text) - Convert.ToDouble("0" + txtTarjeta2.Text) - Convert.ToDouble("0" + txtCheque.Text),2)).ToString();
                if (Convert.ToDouble("0" + txtRecibido.Text) < 0) txtRecibido.Text = "0";
            }
        }

        private void txtTarjeta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                txtTarjeta.Text = (Math.Round( Convert.ToDouble("0" + edTotal.Text) - Convert.ToDouble("0" + txtRecibido.Text) - Convert.ToDouble("0" + txtCheque.Text),2) - Convert.ToDouble("0" + txtTarjeta2.Text)).ToString();
                if (Convert.ToDouble("0" + txtTarjeta.Text) < 0) txtTarjeta.Text = "0";
            }
        }
        private void txtTarjeta2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                txtTarjeta2.Text = (Math.Round(Convert.ToDouble("0" + edTotal.Text) - Convert.ToDouble("0" + txtRecibido.Text) - Convert.ToDouble("0" + txtCheque.Text), 2) - Convert.ToDouble("0" + txtTarjeta.Text)).ToString();
                if (Convert.ToDouble("0" + txtTarjeta2.Text) < 0) txtTarjeta2.Text = "0";
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            directMnt.ActualizaDirectorio prog = new directMnt.ActualizaDirectorio();
            if (prog.Actualizacion (codCliente, datosEmpresa.strConxAdcom) == true )
            {
                cargarDatosCliente(codCliente);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            directMnt.DEEPCLI prog = new directMnt.DEEPCLI();
            prog.ShowDialog();
            prog.Dispose();
        }

        private void malla_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ////if (malla.Columns[e.ColumnIndex].Name.ToUpper() != "TRA_NOMBRE" || btnWeb.Visible == false ) return;

            //if (malla.Rows[e.RowIndex].Cells["TRA_NOMBRE"].Value.ToString() == "" || malla.Rows[e.RowIndex].Cells["TRA_CODIGO"].Value.ToString() == "CMDN")
            //{
            //    string bak = tipoItemEnCurso;
            //    tipoItemEnCurso = "S";
            //    recuperandoItem("CMDN");
            //    tipoItemEnCurso = bak;
            //    CMDNbakCod = malla.Rows[e.RowIndex].Cells["TRA_CODIGO"].Value.ToString();
            //}
        }

        private void malla_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (malla.Rows[e.RowIndex].Cells["TRA_CODIGO"].Value.ToString() == "CMDN")
            {
                malla.Columns["TRA_NOMBRE"].ReadOnly = false;
                malla.Columns["TRA_PRECUNI"].ReadOnly = false;
            }
        }
        private void IniciarDatosPuntoDeventa()
        {
            datosCierre = CierreDeCaja.RegistroCierresCaja.iniciarCaja(valoresPredefinidosSucursal.nomPuntoVta, datosEmpresa.suc, datosEmpresa.usr);
            this.Text = "MANTENIMIENTO DOCUMENTOS FACTURACION A CLIENTES : " + datosEmpresa.nomEmpresa + " PUNTO DE VENTA: " + valoresPredefinidosSucursal.nomPuntoVta;
            txtNroID.Text = valoresPredefinidosSucursal.idTributario(datosEmpresa.codEmpresa.ToString(), datosEmpresa.suc, valoresPredefinidosSucursal.nomPuntoVta, datosEmpresa.strConxSyscod);
            
            //Application.DoEvents();
        }
 
        private void btnLocal_Click(object sender, EventArgs e)
        {
            FormaPagoObligatoria = "UBE";
            cambiarBotonDePago(btnUber, 2);

            //FormaPagoObligatoria = "UBE";
            //btnLocal.Visible = false;
            //btnUber.Visible = true;
            //btnGlove.Visible = false;
            //btnEmpleado.Visible = false;
            //btnWeb.Visible = false;
            //PrecioActivo = 2;
            //cargarArticulosPorClase(claseItemEnCurso);
            //groupFormaPago.Visible = false;
        }
        private void btnUber_Click(object sender, EventArgs e)
        {
            FormaPagoObligatoria = "GLO";
            cambiarBotonDePago(btnGlove, 2);
            //btnLocal.Visible = false;
            //btnGlove.Visible = true;
            //btnUber.Visible = false;
            //btnWeb.Visible = false;
            //btnEmpleado.Visible = false;
            //PrecioActivo = 2;
            //cargarArticulosPorClase(claseItemEnCurso);
            //groupFormaPago.Visible = false;
        }
        private void btnGlove_Click(object sender, EventArgs e)
        {
            FormaPagoObligatoria = "EMP";
            cambiarBotonDePago(btnEmpleado, 1);

            //btnLocal.Visible = false;
            //btnUber.Visible = false;
            //btnGlove.Visible = false;
            //btnEmpleado.Visible = true;
            //btnWeb.Visible = false;
            //PrecioActivo = 2;
            //groupFormaPago.Visible = false;
            //cargarArticulosPorClase(claseItemEnCurso);
        }
        private void btnEmpleado_Click(object sender, EventArgs e)
        {
            FormaPagoObligatoria = "WEB";
            cambiarBotonDePago(btnWeb, 1);

            //btnLocal.Visible = false ;
            //btnUber.Visible = false;
            //btnGlove.Visible = false;
            //btnEmpleado.Visible = false;
            //btnWeb.Visible = true;
            //PrecioActivo = 2;
            //groupFormaPago.Visible = false;
            //cargarArticulosPorClase(claseItemEnCurso);
        }
        private void btnWeb_Click(object sender, EventArgs e)
        {
            FormaPagoObligatoria = "REC";
            cambiarBotonDePago(btnRecreo, 4);

            //btnLocal.Visible = true;
            //btnUber.Visible = false;
            //btnGlove.Visible = false;
            //btnEmpleado.Visible = false;
            //btnWeb.Visible = false;
            //PrecioActivo = 2;
            //groupFormaPago.Visible = true;
            //cargarArticulosPorClase(claseItemEnCurso);
        }
        private void btnRecreo_Click(object sender, EventArgs e)
        {
            FormaPagoObligatoria = "";
            cambiarBotonDePago(btnLocal, 1, true);
        }

        private void cambiarBotonDePago(Button BtnPago,int precio = 1, bool cambio = false )
        {

            btnLocal.Visible = false;
            btnUber.Visible = false;
            btnGlove.Visible = false;
            btnEmpleado.Visible = false;
            btnWeb.Visible = false;
            btnRecreo.Visible = false;
            BtnPago.Visible = true;
            PrecioActivo = precio;
            groupFormaPago.Visible = cambio;
            cargarArticulosPorClase(claseItemEnCurso);
        }

        private void usuariosPuntoVenta_Click(object sender, EventArgs e)
        {
            mntUsrs.frmUsrPtoVta usr = new mntUsrs.frmUsrPtoVta(datosEmpresa.strConIniSis, datosEmpresa.strConxAdcom,DatosUsuario.codigo  ,datosEmpresa.Emp_codigo , datosEmpresa.nomEmpresa, "PVT");
            usr.ShowDialog();
            usr.Dispose();
        }

        //private void btnFormaDepago_Click(object sender, EventArgs e)
        //{
        //    Syscod.ManSysnetClass frmSyscod = new Syscod.ManSysnetClass();
        //    frmSyscod.ManSyscodd("BotonesPago", true);
        //    frmSyscod = null;
        //}

        private void listaImagenes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnServicios_Click(object sender, EventArgs e)
        {
            DaxConceptos.frmMntServicios prog = new DaxConceptos.frmMntServicios(true);
            prog.ShowDialog();
            prog.Dispose();
        }

        private void agrupacionDeServiciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sesSrv.FrmNivServ frmNivServ = new sesSrv.FrmNivServ();
            frmNivServ.ShowDialog();
            frmNivServ.Dispose();
        }

        private void registrarUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mntUsrs.frmMntUser frmMntUser = new mntUsrs.frmMntUser(datosEmpresa.pathAppl,datosEmpresa.strConIniSis,datosEmpresa.strConxAdcom,Convert.ToInt16(datosEmpresa.Emp_codigo) ,datosEmpresa.Emp_Nombre,"DXA");
            frmMntUser.ShowDialog();
            frmMntUser.Dispose();
        }

        private void btnLoteTarjetas_Click(object sender, EventArgs e)
        {

        }

        private void btnCOnfigurar_ButtonClick(object sender, EventArgs e)
        {

        }

        private void horariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PtoVentaDefinicion.frmHorarios prog = new PtoVentaDefinicion.frmHorarios();
            prog.ShowDialog();
            prog.Dispose(); 
        }

        private void resumenCierreDeCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //datosCierre = CierreDeCaja.RegistroCierresCaja.iniciarCaja(valoresPredefinidosSucursal.nomPuntoVta, datosEmpresa.suc, datosEmpresa.usr);
            CierreDeCaja.frmResumenGeneral prog = new CierreDeCaja.frmResumenGeneral ();
            prog.ShowDialog();
            prog.Dispose();
        }

        private void descuentosInentarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DaxNom.IngDescuentoInventario prog = new DaxNom.IngDescuentoInventario(0,"");
            prog.ShowDialog();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            FrmClaveCortesia prog = new FrmClaveCortesia(" REIMPRESION DE COMANDA ");
            if( prog.IngresarClaveCortesia(DatosUsuario.Identifica)  == false) return;
            EnviarAimpresora.imprimirDocumentoDirectamente(datADCDOC, accesosLocalizados, idDocumentoActual,"1");
            prepararBotones();
        }
    }
}