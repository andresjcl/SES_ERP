using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using classMenSistem;
using System.Windows.Forms;
using System.Data.SqlClient;
using ClassDoc;
using DattCom;

namespace DctosEmi
{
    public partial class FormRemision : Form
    {
        //Form1 forma1 = new Form1();

        string claseDocDefault = "REM";
        string tipoDocDefault = "REM";
        string memTipoDoc = "";
        //string memVendedor = "";
        string memBodega = "";
        int operacionEnCurso = 0; // 0 sin operacion delcarada, 1 nuevo registro, 2 modificando registro
        internal int sinOperacion = 0;
        internal int nuevoRegistro = 1;
        internal int modificandoRegistro = 2;
        bool esSoloConsulta = false;
        bool iniciaConNuevoDOc = false;
       // Boolean documentoMultiNumeracion = false;
       // string lugarNumeracionDocumento = "";
       // Boolean tieneComprobantesElectronicos = false;
        Boolean saltar = false;

        DataTable dtDetalleDocumento = new DataTable();

        internal idDocumento idDocumentoActual = new idDocumento();
        internal idDocumento idDocumentoSoporte = new idDocumento();
        internal idDocumento idDocumentoParaGenerar = new idDocumento();

        internal daxAccs.propiedadesDaxAuto accesosLocalizados = new daxAccs.propiedadesDaxAuto();

        //        fespecialRemision especialRemision = new fespecialRemision();
        daxMallaDatos. docMallaArticulo mallaArticulo = new daxMallaDatos. docMallaArticulo();
        
        
        string docActualSucursal = "";
        string docActualTipo = "";
        //double docActualNumero = 0;
        double idClaveDoc = 0;
        string codDestinatario = "";
        string codTransportista = "";
    
        string docSustentoSucursal = "";
        string docSustentoTipo = "";
        double docSustentoNumero = 0;
        double IdClaveDocSustento = 0;
        DateTime docSustentoFecha = new DateTime(1900, 1, 1);
        string docSustentoNumId = "";
        
        string formatoNumero = "##0.00";
//        DaxLib.DaxLibBases datlib = new DaxLib.DaxLibBases();
        //stringdatosEmpresa.strConxAdcom = datosEmpresa.strConxAdcom;
        //string strDaxsys = datosEmpresa.strConIniSis;
        //AdcDax.DaxSofSys CONEMP = new AdcDax.DaxSofSys();
        //DaxUsr.DaxsofUsr CONUSER = new DaxUsr.DaxsofUsr();
        //AdcDax.Empresa Emp;
        //DaxUsr.CtrlUsuario ControlUsuario;
        internal sesSys.OpcDoc propiedadesDoc = new sesSys.OpcDoc();
        AdcDoc datADCDOC;
        //ClassDoc.utilDoc Putil;
        

        //string claveSri="";
        //string correoElectronico="";

        public FormRemision(string clasdef, string tipdef, bool nuevo = false, Boolean esConsulta = false, Boolean generarFactura = false, Boolean desdeEstdoCta = false, idDocumento idDocViene = null, string sisMedico = "")
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

            CargarValoresIniciales();
            validaComprobantesElectronicos();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                docActualSucursal = datosEmpresa.suc;
                docActualTipo = cmbDocumento.SelectedValue.ToString();
                propiedadesDoc.Cargar(ref docActualTipo, ref docActualSucursal);
                limpiarDatos();
            }
            catch (Exception ee)
            {
                MessageBox.Show("No se ha definido un doumento de Remisión"+ee.Message, "Emision de documentos Remisiones", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        #region ConfigurarMalla
        private void CargarValoresIniciales()
        {          
            this.txtfecha.ValueChanged -= new System.EventHandler(this.txtfecha_ValueChanged);

            txtfecha.Value = docUtils.DaxNow();

            idDocumentoActual.Tipo = tipoDocDefault;
            idDocumentoActual.familia = claseDocDefault;
            idDocumentoActual.Sucursal = datosEmpresa.suc;
            valoresPredefinidosEmpresa.cargaValores();
            valoresPredefinidosSucursal.cargarValores();
            txtNroID.Text = "";// valoresPredefinidosSucursal.idtributario;
            txtNroID.Enabled = false;// valoresPredefinidosSucursal.autCambiaPtoVta;
            ptoVenta.Visible = false;// valoresPredefinidosSucursal.autCambiaPtoVta;
            LlenarCombos();
            CargarPredefinidosDocumento();
            this.txtfecha.ValueChanged += new System.EventHandler(this.txtfecha_ValueChanged);
            this.Text += "  " + datosEmpresa.nomEmpresa + " PUNTO DE VENTA: " + valoresPredefinidosSucursal.nomPuntoVta;
            InicializarMalla();
            llenarDatosEmpresa();
        }

        private void InicializarMalla()
        {
            string ssql = "select tra_codigo , tra_nombre , tra_cantidad , tra_medida,tra_queTipo,tra_sucdestino,tra_boddestino,Tra_piezas,Tra_peso";
            ssql += ", Tra_Individual,Tra_snIva,Tra_multiplo,Tra_NroLote "; 
            ssql += " from adctra where doc_sucursal = 'f'";
            DataTable dtt = leerTablas(ssql);
            if (dtt == null) return;
            malla.DataSource = dtt;
            dtt.Dispose();
            diseñarMalla();
        }

        private void diseñarMalla()
        {

            malla.RowHeadersWidth = 20;

            malla.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
            malla.RowHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
            malla.RowHeadersDefaultCellStyle.ForeColor = Color.White;
            malla.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            malla.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //select tra_codigo as codigo, tra_nombre as Descripción, tra_cantidad as Cantidad, tra_medida as Medida

            malla.Columns["tra_Codigo"].HeaderText ="Código";
            malla.Columns["tra_nombre"].HeaderText = "Descripción";
            malla.Columns["tra_Cantidad"].HeaderText = "Cantidad";
            malla.Columns["tra_Medida"].HeaderText = "Medida";

            
            malla.Columns["tra_Codigo"].Width = 105;
            malla.Columns["tra_nombre"].Width = 320;
            malla.Columns["tra_Cantidad"].Width = 60;
            malla.Columns["tra_Medida"].Width = 40;

            malla.Columns["tra_Cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            malla.Columns["tra_Medida"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            malla.Columns["tra_Cantidad"].DefaultCellStyle.Format = formatoNumero;

            malla.Columns["tra_queTipo"].Visible=false;
            malla.Columns["tra_sucdestino"].Visible = false;
            malla.Columns["Tra_Individual"].Visible = false;
            malla.Columns["Tra_snIva"].Visible = false;
            malla.Columns["tra_boddestino"].Visible = false;
            malla.Columns["Tra_piezas"].Visible = false;
            malla.Columns["Tra_peso"].Visible = false;
            malla.Columns["Tra_multiplo"].Visible = false;
            malla.Columns["Tra_NroLote"].Visible = false;


            malla.RowHeadersWidth = 50;
        }
        #endregion configura malla
        #region eventos de controles de operaciones
       
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

        private void btnCierra_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma cerrar el documento actual ?", "Cerrar documento sin grabar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No) return;
            limpiarDatos();
        }

        private void btnAbre_Click(object sender, EventArgs e)
        {
            BuscadorDocumentos.buscadorDoc progBus = new BuscadorDocumentos.buscadorDoc();
            idDocumentoActual.Sucursal = datosEmpresa.suc;
            DateTime queFecha = docUtils.DaxNow();
            progBus.IniciaBusqueda(claseDocDefault, "", cmbDocumento.SelectedValue.ToString(), queFecha, ref idDocumentoActual.Sucursal, ref idDocumentoActual.Tipo, ref idDocumentoActual.numero, ref idDocumentoActual.idClave, false, cmbDocumento.SelectedValue.ToString(), "", "", "ADCDOCPRO");
            if (idDocumentoActual.idClave == 0)
            {
                idDocumentoActual.Sucursal = datosEmpresa.suc; return;
            }
            if (idDocumentoActual.Sucursal.ToUpper() != datosEmpresa.suc.ToUpper()) { mensajesErrorDocumento.documentosNoDeOtraSucursal(datosEmpresa.sucNom); return; }
            if (idDocumentoActual.idClave != 0) cargarDatosRemision(idDocumentoActual.Sucursal, idDocumentoActual.Tipo, idDocumentoActual.idClave);
        }

        private void btnAnula_Click(object sender, EventArgs e)
        {
            DctosEmi.anulaElimina classAnular = new DctosEmi.anulaElimina();
            if (classAnular.anularDocumento(datosEmpresa.strConxAdcom, datosEmpresa.strConxSyscod, idDocumentoActual, datosEmpresa.usr, false , datosEmpresa.nomEmpresa, datosEmpresa.codEmpresa.ToString(), "0", "ADCDOCPRO", propiedadesDoc.ComandoExterno)) limpiarDatos();
        }

        private void btnElimina_Click(object sender, EventArgs e)
        {
            DctosEmi.anulaElimina classAnular = new DctosEmi.anulaElimina();
            if (classAnular.eliminarDocumento(datosEmpresa.strConxAdcom, datosEmpresa.strConxSyscod, idDocumentoActual, datosEmpresa.usr, false , datosEmpresa.nomEmpresa, datosEmpresa.codEmpresa.ToString(), "", "ADCDOCPRO", propiedadesDoc.ComandoExterno)) limpiarDatos();
        }

        private void txtNumeroRemision_KeyDown(object sender, KeyEventArgs e)
        {
//            saltarEventoNumero = true;
            if (e.KeyCode == Keys.Return)
            {
                verificaNroDocumentoDigitado();
            }
        }
        private void verificaNroDocumentoDigitado()
        {
            LlenarIdDocumento(ref idDocumentoActual);
            impresionVerificacion.verificarExistenciaDocumento(ref idDocumentoActual, datosEmpresa.strConxAdcom, false, "ADCDOC", "");
            if (idDocumentoActual.idClave > 0) cargarDatosRemision(idDocumentoActual.Sucursal, idDocumentoActual.Tipo, idDocumentoActual.idClave);
        }

        private void cmbDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tipoDoc = cmbDocumento.SelectedValue.ToString();
            string suc = datosEmpresa.suc;
            if (tipoDoc.Length > 3) return;
            propiedadesDoc.Cargar(ref tipoDoc, ref suc);
        }
        private Boolean verificaSalida()
        {
            return true;
        }

        private void btnRegistra_Click(object sender, EventArgs e)
        {

            if (validarRemision() == true)
            {
                if (grabarDocumento() == false) return;
                //if (tieneComprobantesElectronicos == true) { solicitarAutorizacionElectronica(); } else 
                { imprimirDocumento(); }
                limpiarDatos();
            }
        }

        private void btnGraba_Click(object sender, EventArgs e)
        {
            if (validarRemision() == true)
            {
                if (grabarDocumento() == true) { limpiarDatos(); }
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            imprimirDocumento();
        }

        private void btnBuscaDocSustento_Click(object sender, EventArgs e)
        {
            if (docSustentoSucursal == null || docSustentoSucursal == string.Empty ) docSustentoSucursal = datosEmpresa.suc;

            if (cmbDocumentoSustento.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar el tipo de documento sustento antes de escojer", "Buscar Documento Sustento", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            BuscadorDocumentos.buscadorDoc progBus = new BuscadorDocumentos.buscadorDoc();
            idDocumentoSoporte.Sucursal = datosEmpresa.suc;
            DateTime queFecha = docUtils.DaxNow();
            progBus.IniciaBusqueda("FACINVPRC", "", cmbDocumentoSustento.SelectedValue.ToString(), queFecha, ref idDocumentoSoporte.Sucursal, ref idDocumentoSoporte.Tipo, ref idDocumentoSoporte.numero, ref idDocumentoSoporte.idClave, false, cmbDocumentoSustento.SelectedValue.ToString(), "", "", "ADCDOC");

            if (idDocumentoSoporte.idClave != 0)
            {
                if (MessageBox.Show("Desea copiar todos los datos del documento soporte escojido  ?","Copiar documento soporte de remisión", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;                
                copiarDocumento(idDocumentoSoporte, true);
            }
            //docActualSucursal = datosEmpresa.suc;
            //if (idDocumentoSoporte.idClave != 0) { cargarDatosDocumentoSustento(); }
            //progBus = null;
        }

        private void btnBuscaDestinatario_Click(object sender, EventArgs e)
        {
            buscaCliente(txtNombreDestinatario.Text);
        }

        private void buscaTransportista_Click(object sender, EventArgs e)
        {
            buscaTransportista(txtnombreTransportista.Text);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (verificaSalida() == true) this.Close();
        }

        #endregion

        #region Busquedas

        private void buscaCliente(string buscador)
        {
            directMnt.BuscaClien directorio = new directMnt.BuscaClien();
            string cliente = "C";
            string codigo = "";
            string nombre = "";
            string conalias = "N";
            string connuevo = "N";
            codigo = directorio.IniBuscaCliOPro(ref cliente, ref nombre, ref conalias, ref connuevo);
            if ((codigo + "").Length > 0) cargarDatosCliente(codigo);
        }

        private void buscaTransportista(string buscador)
        {
            directMnt.BuscaClien directorio = new directMnt.BuscaClien();
            string cliente = "R";
            string codigo = "";
            string nombre = "";
            string conalias = "N";
            string connuevo = "S";
            codigo = directorio.IniBuscaCliOPro(ref cliente, ref nombre, ref conalias, ref connuevo);
            if ((codigo + "").Length > 0) cargarDatosTransportista(codigo);
        }
        
        #endregion busquedas
        #region Carga de Datos
        private void cargarDatosTransportista(string codigo = "")
        {
            if (codigo != "")
            {
                DataTable dt = leerTablas("select codigo,cedulaidentidadruc,nombreimpresion from identificacion where codigo ='" + codigo + "'");
                if (dt != null)
                {
                    txtcedulaTransportista.Text = dt.Rows[0]["cedulaidentidadruc"].ToString();
                    txtnombreTransportista.Text = dt.Rows[0]["nombreimpresion"].ToString();
                    codTransportista = codigo;
                }
            }
            else
            {
                txtcedulaTransportista.Text = "";
                txtnombreTransportista.Text = "";
                codTransportista = "";
            }
        }

        private void LlenarCombos()
        {
            recordarOpciones();
            DaxCombobx.CargCmbBox cmb = new DaxCombobx.CargCmbBox();
            cmb.DaxCombosDoc(claseDocDefault, tipoDocDefault , false, datosEmpresa.strConxAdcom, ref cmbDocumento);
            cmb.DaxCombosBods(datosEmpresa.suc, false, datosEmpresa.strConIniSis, ref cmbBodega);
            cmb.DaxCombosDoc("FACINVPRO", "", false, datosEmpresa.strConxAdcom, ref cmbDocumentoSustento);
            //            cmb.DaxCombosVend(datosEmpresa.strConxAdcom, ref cmbVendedor, false);

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
            //    if (memVendedor.Length > 0) { cmbVendedor.SelectedValue = memVendedor; } else { cmbVendedor.SelectedIndex = 0; }
            //}
        }

        //private double verificarExistenciaDocumento(string suc, string tipDoc,string numero)
        //{
        //    double clavedoc = 0;
        //    if (documentoMultiNumeracion == true)
        //    {
        //        forma1 = new Form1();
        //        clavedoc = forma1.SeleccionaDoc(suc, tipDoc , numero,strConxAdcom);
        //        forma1.Close();
        //        forma1.Dispose();
        //        if (clavedoc < 1) return 0;
        //    }
        //    else
        //    {
        //        DataTable dt = leerTablas("select idclavedoc from adcdoc where doc_sucursal = '" + suc + "' and opc_documento ='" + tipDoc + "' and doc_numero = " + numero);
        //        if (dt.Rows.Count > 0)
        //        {
        //            clavedoc= Convert.ToDouble(dt.Rows[0]["IdClaveDoc"]);
        //        }
        //    }            
        //        return mensajeDocumentoExiste(clavedoc ) ;
        //}
        private Boolean cargarDatosRemision(string SUC, string TIPO, double idclaveDoc)
        {
            Boolean resp = false;
            if (idclaveDoc != 0)
            {
                datADCDOC = new AdcDoc(datosEmpresa.strConxAdcom);
                datADCDOC = AdcDoc.Buscar(" doc_sucursal = '" + SUC + "' and opc_documento ='" + TIPO + "' and idclavedoc = " + idclaveDoc.ToString());
                if (datADCDOC != null)
                {
                    moverClaseDatos();
                    cargarDetalleArticulos(docActualSucursal, docActualTipo , idClaveDoc,"ADCTRA");
                    txtnumero.Enabled = false;
                    operacionEnCurso = 2;
                    prepararBotones();
                    resp = true;
                }
            }
            else
            {
                txtcedulaTransportista.Text = "";
                txtnombreTransportista.Text = "";
                txtDireccionDestinatario.Text = "";
                codTransportista = "";
            }
            return resp;
        }

        private double mensajeDocumentoExiste(double laClaveDoc)
        {
            if (laClaveDoc != 0)
            {
                if (operacionEnCurso == 2)
                {
                    if (MessageBox.Show("Confirma visualizar los datos de otro documento ? ", "Busqueda de documentos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No) { laClaveDoc = 0; }
                }
                else 
                {
                    if (MessageBox.Show("El documento ya existe, confirma reemplazar los datos actuales ? ", "Busqueda de documentos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No) { laClaveDoc = 0; }
                }
            }
            else
            {
                if (operacionEnCurso == 2)
                {
                    MessageBox.Show("El documento no existe, digite otro numero ", "Busqueda de documentos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ; laClaveDoc = 0; 
                }
            }
            return laClaveDoc;               
        }

        private void cargarDatosCliente(string codigo = "")
        {
            if (codigo != "")
            {
                DataTable dt = leerTablas("select codigo,cedulaidentidadruc,nombreimpresion,domicilio from identificacion where codigo ='" + codigo + "'");
                if (dt != null)
                {
                    codDestinatario = dt.Rows[0]["Codigo"].ToString();
                    txtCedDestinatario.Text = dt.Rows[0]["cedulaidentidadruc"].ToString();
                    txtNombreDestinatario.Text = dt.Rows[0]["nombreimpresion"].ToString();
                    txtDireccionDestinatario.Text = dt.Rows[0]["domicilio"].ToString();
                }
            }
            else
            {
                codDestinatario = "";
                txtCedDestinatario.Text = "";
                txtNombreDestinatario.Text = "";
                txtDireccionDestinatario.Text = "";
            }
        }
        private void llenarDatosEmpresa()
        {
            SqlDataReader dr = SqlDatos.leerBaseIniSis("select * from emp_suc where suc_codigo = '" + datosEmpresa.suc + "' and emp_codigo = " + datosEmpresa.codEmpresa);
            if (dr.Read() == true)
            {
                txtNroID.Text = dr["suc_idtributario"].ToString();
                txtdireccionPartida.Text = dr["suc_direccion"].ToString();
            }
            dr.Close();
        }
        private void copiarDocumento(idDocumento idDocCopiar, Boolean esGenerar = false)
        {
            sesSys.OpcDoc opcp = new sesSys.OpcDoc();
            opcp.Cargar(idDocCopiar.Tipo);
            DataTable dttr = new DataTable();
            CopiarDocumento copia = new CopiarDocumento();
            dtDetalleDocumento = (DataTable) malla.DataSource;
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
                            moverClaseDatos();
                            txtnumero.Enabled = false;
                            operacionEnCurso = 2;
                            prepararBotones();
                    }
                }
                DatosDocFacturacion dcut = new DatosDocFacturacion();
                ModelaMalla dcut2 = new ModelaMalla();
                if (dtDetalleDocumento == null) return;
                malla.DataSource = dtDetalleDocumento;
                diseñarMalla();
                //malla.Columns["Existencia"].Visible = valoresPredefinidosEmpresa.existenciaEnLineas;
                LlenarIdDocumento(ref idDocumentoActual);
                idDocumentoActual.idClave = 0;
                prepararBotones();
            }
            else
            {
                MessageBox.Show("No se pudo copiar el documentos requerido");
            }
        }
        private void cargarDatosDocumentoSustento()
        {

            sesSys.OpcDoc opdoc = new sesSys.OpcDoc();
            opdoc.Cargar(docSustentoTipo);
            string tabladoc = opdoc.tablaDatosDoc;
            string tablatra = opdoc.tablaDatosTra;

            txtnumeroSustento.Text = "";
            txtCedDestinatario.Text = "";
            txtNombreDestinatario.Text = "";
            txtDireccionDestinatario.Text = "";
            codDestinatario = "";
            docSustentoNumId = "";

            if (IdClaveDocSustento != 0)
            {
                cargarCabezeraDocumento (docSustentoSucursal, docSustentoTipo, IdClaveDocSustento,tabladoc);
                if (MessageBox.Show("Desea cargar el detalle de artículos del documento ? ", "Copiar datos documento", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    cargarDetalleArticulos(docSustentoSucursal, docSustentoTipo, IdClaveDocSustento,tablatra);
                }
            }
        }
        private void cargarCabezeraDocumento(string suc, string tip, double idClave, string tabladoc)
        {
                DataTable dt = leerTablas("select * from " + tabladoc + " where doc_sucursal = '" + suc + "' and opc_documento ='" + tip  + "' and idclavedoc = " + idClave.ToString());
                if (dt != null)
                {
                    txtnumeroSustento.Text = dt.Rows[0]["doc_numero"].ToString();
                    txtCedDestinatario.Text = dt.Rows[0]["doc_ciruc"].ToString();
                    txtNombreDestinatario.Text = dt.Rows[0]["doc_nombreImp"].ToString();
                    txtDireccionDestinatario.Text = dt.Rows[0]["doc_direccion"].ToString();
                    codDestinatario = dt.Rows[0]["doc_codper"].ToString();
                    docSustentoFecha = Convert.ToDateTime(dt.Rows[0]["doc_fecha"].ToString());
                    docSustentoNumId = dt.Rows[0]["doc_NroIdDoc"].ToString();

                }
        }
        private void cargarDetalleArticulos(string suc, string tip, double idClave,string tablatra)
        {            
            string ssql = "select tra_codigo , tra_nombre , tra_cantidad , tra_medida,tra_queTipo,tra_sucdestino,tra_boddestino,Tra_piezas,Tra_peso";
            ssql += ", Tra_Individual,Tra_snIva,Tra_multiplo,Tra_NroLote ";
            ssql += " from " + tablatra + " where doc_sucursal = '" + suc + "' and opc_documento ='" + tip + "' and idclavedoc = " + idClave.ToString();
            DataTable dtt = leerTablas(ssql);
            if (dtt == null) return;
            malla.DataSource = dtt;
            diseñarMalla();
        }

        private DataTable leerTablas(string ssql)
        {
            // devuelve una tabla con los datos leidos
            SqlDataAdapter da;
            DataTable dt = new DataTable();
            try
            {
                da = new SqlDataAdapter(ssql,datosEmpresa.strConxAdcom);
                da.Fill(dt);
            }
            catch
            {
                return null;
            }
            return dt;
        }

        #endregion carga de datos

        private void imprimirDocumento()
        {
            if (accesosLocalizados.NroImpresiones > 0 && accesosLocalizados.NroImpresiones <= datADCDOC.Doc_Adicional1)
            { MessageBox.Show("Ha llegado al límite de impresiones permitidas", "Imprimir documentos", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            ImpresionDocumentosDax.ImprimeDocumentoDoble impProg = new ImpresionDocumentosDax.ImprimeDocumentoDoble(datosEmpresa.nombreBaseIvaret, datosEmpresa.strConxAdcom, datosEmpresa.strConxIvaret, datosEmpresa.strConxSyscod, datosEmpresa.strConxDaxpro, datosEmpresa.codEmpresa, datosEmpresa.pathServer);
            int imp = impProg.ImpDoc(idDocumentoActual, "A", "", false, false);
            datADCDOC.Doc_Adicional1 = imp;
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
            //try
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
                    //ClaveElectronica.actualizarClaveElectronica(datADCDOC);
                    AuditSis.registrar.registraEventoDoc(datosEmpresa.strConIniSis, datosEmpresa.codEmpresa.ToString(), datosEmpresa.usr, "MDD", Environment.MachineName, AuditSis.registrar.EvntCrear, idDocumentoActual.Sucursal, idDocumentoActual.Tipo, idDocumentoActual.numero.ToString(), datADCDOC.Doc_valor.ToString());
                }
                else
                {
                    res = datADCDOC.Actualizar();
                    if (res.Substring(0, 3) != "ERR") { grabarAdctra(); }
                    AuditSis.registrar.registraEventoDoc(datosEmpresa.strConIniSis, datosEmpresa.codEmpresa.ToString(), datosEmpresa.usr, "MDD", Environment.MachineName, AuditSis.registrar.EvntModifica, idDocumentoActual.Sucursal, idDocumentoActual.Tipo, idDocumentoActual.numero.ToString(), datADCDOC.Doc_valor.ToString());
                }
            }
            //catch (Exception ee)
            {
                //res = "ERR " + ee.Message;
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
                ClassDoc.grabMallTra.grabarDetalleAdctra (malla,datADCDOC, datosEmpresa.strConxAdcom);
        }
        
        private void eliminarDetalle()
        {
            SqlConnection con = new SqlConnection(datosEmpresa.strConxAdcom);
            con.Open();
            string del = "delete FROM AdcTra WHERE doc_sucursal = '" + datosEmpresa.suc + "' and opc_documento = '" + cmbDocumento.SelectedValue.ToString() + "' and idclavedoc = " + idClaveDoc.ToString();
            SqlCommand comm = new SqlCommand(del,con);
            comm.ExecuteNonQuery();
            con.Close();
            comm.Dispose();
            con.Dispose();
        }
        private void moverDatosClase()
        {
            if (idClaveDoc == 0)           
            {
                datADCDOC.Doc_fecha = Convert.ToDateTime(txtfecha.Text);
                datADCDOC.Doc_FechaEfe = datADCDOC.Doc_fecha;
                datADCDOC.Doc_FecGraba =DateTime.Now;
                datADCDOC.Doc_numero = Convert.ToDecimal( txtnumero.Text );
            }

            datADCDOC.Doc_FechaModifica = DateTime.Now;
            datADCDOC.Doc_Hora = DateTime.Now;
            datADCDOC.Doc_codusu = DatosUsuario.Identifica;
            datADCDOC.Doc_codper = codDestinatario;
            datADCDOC.Doc_sucursal = datosEmpresa.suc;
            datADCDOC.Opc_documento = cmbDocumento.SelectedValue.ToString();
            datADCDOC.IdClaveDoc =Convert.ToDecimal( idClaveDoc);
            datADCDOC.Doc_TipoDoc = propiedadesDoc.TipoDoc ;
            datADCDOC.Doc_CiRuc = txtCedDestinatario.Text;
            datADCDOC.RucTransportista = txtcedulaTransportista.Text;
            datADCDOC.Destinatario = txtNroID.Text;
            datADCDOC.Doc_Direccion = txtDireccionDestinatario.Text;
            datADCDOC.dirPartida = txtdireccionPartida.Text;
            datADCDOC.docAduaneroUnico = txtDocAduaneroUnico.Text;
            datADCDOC.FecFinTransporte = Convert.ToDateTime( txtFechafin.Text);
            datADCDOC.FecIniTransporte = Convert.ToDateTime( txtfechaini.Text);
            datADCDOC.Doc_NombreImp = txtNombreDestinatario.Text;
            datADCDOC.Transportista = codTransportista ;
            datADCDOC.TipoTransporte = txtMotivoTransporte.Text;
            datADCDOC.AuxVar10 = txtPlaca.Text;
            datADCDOC.rutaTransporte = txtRuta.Text;
            datADCDOC.codEstabDestino = txtCodigoEstabDestino.Text;
            datADCDOC.Doc_detalle = txtDescripcion.Text;
            try
            {
            datADCDOC.Doc_DocSop = cmbDocumentoSustento.SelectedValue.ToString();
            }
            catch
            {
                datADCDOC.Doc_DocSop = "";
            }
            datADCDOC.Doc_NumSop = Convert.ToDecimal("0" + txtnumeroSustento.Text);
            datADCDOC.IdClaveDocSop = Convert.ToDecimal(IdClaveDocSustento);
            datADCDOC.AuxFec1 = docSustentoFecha;
            datADCDOC.AuxVar11 = docSustentoNumId;
            datADCDOC.Doc_NroIdDoc = txtNroID.Text;
            datADCDOC.Doc_Estado = 1;
        }
        private void moverClaseDatos()
        {
            idClaveDoc = Convert.ToDouble(datADCDOC.IdClaveDoc);
            txtnumero.Text = datADCDOC.Doc_numero.ToString();
            txtfecha.Text = datADCDOC.Doc_fecha.ToShortDateString ();
            codDestinatario = datADCDOC.Doc_codper;
            txtCedDestinatario.Text  = datADCDOC.Doc_CiRuc;
            txtcedulaTransportista.Text = datADCDOC.RucTransportista;
            txtNroID.Text = datADCDOC.Destinatario;
            txtDireccionDestinatario.Text = datADCDOC.Doc_Direccion;
            txtdireccionPartida.Text = datADCDOC.dirPartida;
            txtDocAduaneroUnico.Text = datADCDOC.docAduaneroUnico;
            txtFechafin.Text = datADCDOC.FecFinTransporte.ToShortDateString();
            txtfechaini.Text = datADCDOC.FecIniTransporte.ToShortDateString();
            txtNombreDestinatario.Text = datADCDOC.Doc_NombreImp;
            
            codTransportista  = datADCDOC.Transportista;
            cargarDatosTransportista(codTransportista);

            txtnumeroSustento.Text = datADCDOC.Doc_NumSop.ToString();
            txtPlaca.Text = datADCDOC.AuxVar10;
            txtRuta.Text = datADCDOC.rutaTransporte;
            cmbDocumentoSustento.SelectedValue = datADCDOC.Doc_DocSop;
            txtMotivoTransporte.Text = datADCDOC.TipoTransporte;
            txtCodigoEstabDestino.Text = datADCDOC.codEstabDestino;

            IdClaveDocSustento = Convert.ToDouble(datADCDOC.IdClaveDocSop);
            docSustentoTipo = datADCDOC.Doc_DocSop;
            docSustentoNumero = Convert.ToDouble(datADCDOC.Doc_NumSop);
            docSustentoFecha = datADCDOC.AuxFec1;
            docSustentoSucursal = datADCDOC.Doc_sucursal;
            docSustentoNumId = datADCDOC.AuxVar11;
            txtDescripcion.Text = datADCDOC.Doc_detalle ;

            if (Convert.ToInt32(datADCDOC.Doc_Estado) == 0) mensajesDocumento.Text = "DOCUMENTO ANULADO";
        }
        private void limpiarDatos()
        {
            datADCDOC = new AdcDoc(datosEmpresa.strConxAdcom);
            txtnumero.Text = "";
            codDestinatario = "";
            txtCedDestinatario.Text = "";
            txtcedulaTransportista.Text = "";
            txtDireccionDestinatario.Text = "";
            txtDocAduaneroUnico.Text = "";
            txtfecha.Text = DateTime.Now.ToShortDateString();
            txtFechafin.Text = DateTime.Now.ToShortDateString();
            txtfechaini.Text = DateTime.Now.ToShortDateString();
            txtNombreDestinatario.Text = "";
            txtnombreTransportista.Text = "";
            txtnumeroSustento.Text = "";
            txtPlaca.Text = "";
            txtRuta.Text = "";
            cmbDocumentoSustento.SelectedValue  = "";
            txtMotivoTransporte.Text = "";
            txtCodigoEstabDestino.Text = "";
            txtDescripcion.Text = "";
            mensajesDocumento.Text = "";
            operacionEnCurso = 0;
            prepararBotones();
            InicializarMalla();
            idClaveDoc = 0;
            IdClaveDocSustento = 0;
            
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
            btnRegistra.Enabled = btnGraba.Enabled;
            BtnEnviar.Enabled = (modificando && !docAnulado);
            btnCierra.Enabled = !inicio;
            //btnConsolida.Enabled = nuevo;

            //btnPagos.Enabled = btnGraba.Enabled;
            //btnDescuentos.Enabled = btnGraba.Enabled;
            ptoVenta.Enabled = inicio;
            //btnPorcentajeIva.Enabled = btnDescuentos.Enabled;
            //btnContabiliza.Enabled = btnGraba.Enabled;
            //btnExportacion.Enabled = btnGraba.Enabled;
            //btnPendientes.Enabled = btnGraba.Enabled;

            btnBarras.Enabled = (!inicio) && !docAnulado;
            btnAgrupa.Enabled = (btnBarras.Enabled && btnBarras.Checked);

            //panel1.Enabled = (!inicio);
            malla.Enabled = (!inicio);

            cmbDocumento.Enabled = (inicio);
            //txtcedula.Enabled = (!docAnulado);

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
                BtnEnviar.Enabled = (BtnEnviar.Enabled && accesosLocalizados.Imprimir); //(accesosLocalizados.Imprimir && !inicio);
                btnNuevo.Enabled = (accesosLocalizados.Crear && btnNuevo.Enabled);
                btnElimina.Enabled = (accesosLocalizados.Eliminar && btnElimina.Enabled);
                btnAnula.Enabled = (accesosLocalizados.Anular && btnAnula.Enabled);
                btnCopia.Enabled = (accesosLocalizados.Crear && btnCopia.Enabled);
                //btnConsolida.Enabled = (accesosLocalizados.Crear && btnConsolida.Enabled);
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
            if (propiedadesDoc.ImprimirDoc == "N") BtnEnviar.Visible = false;
        }


        private Boolean validarRemision()
        {
            string mensaje ="";
            docUtils util = new docUtils();
            moverDatosClase();
            try 
            {
                if (Convert.ToDateTime(txtFechafin.Text) < Convert.ToDateTime(txtfechaini.Text))
                    mensaje = "La fecha final de transporte es menor que la fecha inicial \n" ;
            }
            catch 
            {
                mensaje = "Existen errores en las fechas de transporte";
            }
            if (txtNroID.Text.Length < 7) { mensaje += " Falta el código de ubicacion \n"; }
            if (txtMotivoTransporte.Text.Length < 1) {mensaje += " Falta el motivo de transporte \n";}
            if (txtCodigoEstabDestino.Text.Length < 1) { mensaje += " Falta el código de identificación del establecimiento destino \n"; }
            if (txtdireccionPartida.Text.Length < 1) {mensaje += "Falta la dirección de partida \n";}
            if (mensaje.Length > 0){ MessageBox.Show("Excepción en el documento: " + mensaje); return false;}
            if (malla.Rows.Count < 2) { MessageBox.Show( " No se ha registrado artículos válidos " + mensaje); return false;}
            if (util.ExisteDocumentoGrabado(ref datADCDOC, ref propiedadesDoc ,datosEmpresa.strConxAdcom,idClaveDoc ) == true)
            {
                MessageBox.Show("ERROR: Ya existe un documento igual registrado", "Grabar documento", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;            
        }
        private void validaComprobantesElectronicos()
        {
            //tieneComprobantesElectronicos = File.Exists(Emp.PatAppl + @"DaxFelec.exe");
            //if (tieneComprobantesElectronicos == false)
            //{
            //    tieneComprobantesElectronicos = File.Exists(Emp.PatAppl + @"DaxFelec.exe"); 
            //}
            //if (tieneComprobantesElectronicos == false) 
            //{
            //    tieneComprobantesElectronicos = File.Exists(Emp.PatAppl + @"AdcGenxml.dll");
            //}
        }
        //private void solicitarAutorizacionElectronica()
        //{
        //    Int16 tipo = 1;
        //    try
        //    {
        //        WebService.WebServicesSRI ws = new WebService.WebServicesSRI();
        //        if (ws.IsOnLine == false) { tipo = 2; }
        //    }
        //    catch { tipo = 2; }

        //    if (tipo == 2)
        //    {
        //        if (MessageBox.Show("Los servicios Web del SRI no están disponibles \n Desea emitir el comprobante con claves de contingencia ?", "Emisión comprobantes electrónicos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No) return;
        //    }

        //    Daxconxfe.Adcconxfe factElec = new Daxconxfe.Adcconxfe();
        //    claveSri = factElec.pedirAutorizacionSri (datADCDOC.Doc_sucursal, datADCDOC.Opc_documento, Convert.ToDouble(datADCDOC.IdClaveDoc), datADCDOC.Doc_numero.ToString(), propiedadesDoc.TipoDoc, Emp.ruc, Emp.DigitosPrecios, Emp.PatAppl,tipo,false,strConxAdcom);
        //    if (claveSri.Substring(0, 3).ToUpper() != "ERR" && claveSri.Length > 0)
        //    {
        //        MessageBox.Show("autorización SRI EXITOSA \n" + claveSri, "Autorización SRI");
        //        imprimirDocumento();
        //    }
        //    else
        //    {
        //        MessageBox.Show("COMPROBANTE CON ERRORES NO FUE AUTORIZADO \n" + claveSri);
        //    }
        //}

        #region manejo malla

        private void malla_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (malla.IsCurrentCellInEditMode == true)
            {
                DataGridViewCell cell = malla.CurrentCell;
                funcionesEspeciales(Keys.Enter, ref cell);
            }
        }
        
        private void malla_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            foreach (DataGridViewRow rr in malla.Rows)
            {
                rr.HeaderCell.Value = (rr.Index + 1).ToString();
            }
        }


       protected override Boolean ProcessCmdKey(ref Message msg , Keys keyData) 
       {

        if (malla.Focused == false &&  malla.IsCurrentCellInEditMode == false ) return false ;
        if (!(keyData == Keys.Return || keyData == Keys.F2 || keyData == Keys.F3)) return false;        //       
       
        DataGridViewCell cell = malla.CurrentCell;
        if (funcionesEspeciales(keyData, ref cell) == false) { malla.BeginEdit(true); return true; }
        
        if  (keyData != Keys.Return) return false;

        Int32 columnIndex = cell.ColumnIndex;
        Int32  rowIndex =  cell.RowIndex;

           if (columnIndex == malla.Columns.Count - 1) 
        {
            if (rowIndex == malla.Rows.Count - 1) 
            {
                cell = malla.Rows[0].Cells[0];
            } else {
                    cell = malla.Rows[rowIndex + 1].Cells[0];
                    }
        } else {
            cell = malla.Rows[rowIndex].Cells[columnIndex + 1];
        }
           try
           {
               malla.CurrentCell = cell;
           }
           catch { }
        return true;
       }

       private Boolean funcionesEspeciales(Keys keyData, ref DataGridViewCell cell)
       {
           Boolean resp = true;
           malla.EndEdit();
           string dato = cell.Value.ToString();
           string nombreCelda = malla.Columns[cell.ColumnIndex].Name.ToUpper();
           if (keyData == Keys.Enter)
           {
               if (nombreCelda == "tra_Codigo".ToUpper ())
               {
                   return mallaArticulo.CargarArticulo (malla,ref propiedadesDoc , cell.Value.ToString(),"",txtfecha.Value.ToShortDateString(),propiedadesDoc.TipoDoc,idClaveDoc,1);
               }
           }
           else if (keyData == Keys.F2)
           {
               if (nombreCelda == "tra_Codigo".ToUpper())
               {
                   mallaArticulo.BuscarArticuloSimple ("");
               }
           }
           
           return resp;
       }
#endregion manejo malla

       private void txtMotivoTransporte_KeyDown(object sender, KeyEventArgs e)
       {
           if (e.KeyCode == Keys.F2) { CBuscador(ref txtMotivoTransporte,"MotivoTraslado"); }
       }
        private void CBuscador(ref TextBox lcod, string tipo)
        {
            string ElNombre = "";
            string ElCodigo = "";
            Syscod.ManSysnetClass  Buscod = new  Syscod.ManSysnetClass();
            ElCodigo = Buscod.BuscarReferencia (ref tipo, ref ElCodigo, ref ElNombre);
            lcod.Text = ElNombre;
            Buscod = null;
        }

        private void txtDireccionDestinatario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2) { CBuscador(ref txtDireccionDestinatario, "DireccionDestino"); }
        }

        private void txtdireccionPartida_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2) { CBuscador(ref txtdireccionPartida, "DireccionPartida"); }
        }

        private void txtRuta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2) { CBuscador(ref txtRuta, "Rutas"); }
        }

        private void btnBarras_Click(object sender, EventArgs e)
        {
            btnAgrupa.Enabled = btnBarras.Checked ;
        }

        private void btnAgrupa_Click(object sender, EventArgs e)
        {
             mallaArticulo.AcumularLineasMalla(ref malla, "tra_codigo","tra_Cantidad","");
        }

        private void txtNumeroRemision_Leave(object sender, EventArgs e)
        {
            if (saltar == true) { saltar = false; return; }
            if (operacionEnCurso != 2)
            {
                verificaNroDocumentoDigitado();
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
            progBus.IniciaBusqueda("FACPRCREM", "", "REM", queFecha, ref SUC, ref TIP, ref Numero, ref Idclave, false, "", "", "", "ADCDOCPRO");
            if (Idclave != 0)
            {
                    idDocumentoParaGenerar.Sucursal = SUC;
                    idDocumentoParaGenerar.Tipo = TIP;
                    idDocumentoParaGenerar.idClave = Idclave;
                    copiarDocumento(idDocumentoParaGenerar, false);
            }
        }

        private void registraOpciones()
        {
            AuditSis.registrar.registraPreferencia(datosEmpresa.strConxSyscod, datosEmpresa.codEmpresa.ToString(), datosEmpresa.usr, "ADX", datosEmpresa.suc, "Facturacion", "TipoDoc", cmbDocumento.SelectedValue.ToString());
            AuditSis.registrar.registraPreferencia(datosEmpresa.strConxSyscod, datosEmpresa.codEmpresa.ToString(), datosEmpresa.usr, "ADX", datosEmpresa.suc, "Facturacion", "Bodega", cmbBodega.SelectedValue.ToString());
//            if (cmbVendedor.SelectedValue != null) AuditSis.registrar.registraPreferencia(datosEmpresa.strConxSyscod, datosEmpresa.codEmpresa.ToString(), datosEmpresa.usr, "ADX", datosEmpresa.suc, "Facturacion", "Vendedor", cmbVendedor.SelectedValue.ToString());
        }
        private void recordarOpciones()
        {
            memTipoDoc = AuditSis.registrar.obtenerPreferencia(datosEmpresa.strConxSyscod, datosEmpresa.codEmpresa.ToString(), datosEmpresa.usr, "ADX", datosEmpresa.suc, "Facturacion", "TipoDoc");
            memBodega = AuditSis.registrar.obtenerPreferencia(datosEmpresa.strConxSyscod, datosEmpresa.codEmpresa.ToString(), datosEmpresa.usr, "ADX", datosEmpresa.suc, "Facturacion", "Bodega");
  //          memVendedor = AuditSis.registrar.obtenerPreferencia(datosEmpresa.strConxSyscod, datosEmpresa.codEmpresa.ToString(), datosEmpresa.usr, "ADX", datosEmpresa.suc, "Facturacion", "Vendedor");
        }
        private void CargarPredefinidosDocumento()
        {
            propiedadesDoc = new sesSys.OpcDoc();
            propiedadesDoc.Cargar(ref idDocumentoActual.Tipo, ref idDocumentoActual.Sucursal);
            accesosLocalizados.iniciar(datosEmpresa.codEmpresa, datosEmpresa.usr, datosEmpresa.strConxSyscod);
            accesosLocalizados.cargarAccesoDoc(idDocumentoActual.Tipo);

//            AutorizacionesFac.HabilitarOpcionesDocumento(this);

            //HabilitarOpcionesDocumento();
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

        private void txtfecha_ValueChanged(object sender, EventArgs e)
        {

        }

        private void mensajesDocumento_Click(object sender, EventArgs e)
        {

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
    }
}
