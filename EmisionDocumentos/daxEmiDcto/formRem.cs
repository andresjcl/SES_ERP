using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace daxEmiFacPv
{
    public partial class formRem : Form
    {
        Form1 forma1 = new Form1();

        string tipoDocDefault = "REM";
        
        Boolean documentoMultiNumeracion = false;
        string lugarNumeracionDocumento = "";
        Boolean tieneComprobantesElectronicos = false;
        Boolean saltar = false;
         
        fespecialRemision especialRemision = new fespecialRemision();
        daxMallaDatos. docMallaArticulo mallaArticulo = new daxMallaDatos.docMallaArticulo();
        string docActualSucursal = "";
        string docActualTipo = "";
        double docActualNumero = 0;
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
        string strConxAdcom = "";
        string strDaxsys = "";
        AdcDax.DaxSofSys CONEMP = new AdcDax.DaxSofSys();
        DaxUsr.DaxsofUsr CONUSER = new DaxUsr.DaxsofUsr();
        daaxLib.DaxLibBases datlib ;
        //AdcDax.Empresa Emp;
        DaxUsr.CtrlUsuario ControlUsuario;
        PrySysp13.OpcDoc propiedadesDoc = new PrySysp13.OpcDoc("","");
        
        adcDocumentos.AdcDoc datADCDOC;
        
        int operacion = 0; // 0 sin operacion delcarada, 1 nuevo registro, 2 modificando registro

        string claveSri="";
        string correoElectronico="";

        public formRem()
        {
            InitializeComponent();
            //Emp = CONEMP.EmpresaAct;
            ControlUsuario = CONUSER.UsuarioAct;
            datlib = new daaxLib.DaxLibBases(CONEMP.EmpresaAct.codigo, CONEMP.EmpresaAct.Sistema, CONEMP.EmpresaAct.PatAppl);
            strConxAdcom = datlib.StrAdcom();
            strDaxsys = datlib.StrDaxsys();
            mallaArticulo.strConxAdcom = strConxAdcom;
            especialRemision.strConxAdcom = strConxAdcom;
            validaComprobantesElectronicos();
            cargarComboDocumentos();
            cargarComboDocumentoSustento();
            llenarDatosEmpresa();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {

                docActualSucursal = CONEMP.EmpresaAct.SucActual;
                docActualTipo = cmbDocumento.SelectedValue.ToString();
                propiedadesDoc.Cargar(ref docActualTipo, ref docActualSucursal);
                limpiarDatos();
            }
            catch 
            {
                MessageBox.Show("No se ha definido un doumento de Remisión", "Emision de documentos Remisiones", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        #region ConfigurarMalla
        private void InicializarMalla()
        {
            string ssql = "select tra_codigo as codigo, tra_nombre as Descripción, tra_cantidad as Cantidad, tra_medida as Medida  from adctra where doc_sucursal = 'f'";
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

            malla.Columns["Codigo"].Width = 105;
            malla.Columns["Descripción"].Width = 320;
            malla.Columns["Cantidad"].Width = 60;
            malla.Columns["Medida"].Width = 40;

            malla.Columns["Cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            malla.Columns["Medida"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            malla.Columns["Cantidad"].DefaultCellStyle.Format = formatoNumero;

            malla.RowHeadersWidth = 50;
        }
        #endregion configura malla
        #region eventos de controles de operaciones
       
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiarDatos();
            inicializarUtilidadDocumentos();
            double num = datADCDOC.Putil.nuevoNumeroDocumento();
            txtNumeroRemision.Text = num.ToString();
            operacion = 1;
            prepararBotones();
        }
        
        private void btnCierra_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma cerrar el documento actual ?", "Cerrar documento sin grabar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No) return;
            limpiarDatos();
        }

        private void btnAbre_Click(object sender, EventArgs e)
        {
            BuscadorDocumentos.buscadorDoc progBus = new BuscadorDocumentos.buscadorDoc(strConxAdcom,strDaxsys );
            docActualSucursal = CONEMP.EmpresaAct.SucActual;
            DateTime queFecha = DateTime.Now;
            progBus.IniciaBusqueda(tipoDocDefault, "", cmbDocumento.SelectedValue.ToString(), queFecha, ref docActualSucursal, ref docActualTipo, ref docActualNumero, ref idClaveDoc, false, cmbDocumento.SelectedValue.ToString(), "", "", "ADCDOC");

            if (docActualSucursal == null) return;

            try
            {
                if (docActualSucursal.ToUpper() != CONEMP.EmpresaAct.SucActual.ToUpper()) { MessageBox.Show("No puede accesar a un documento de una sucursal diferente a (" + CONEMP.EmpresaAct.SucNomActual + ")"); return; }
            }
            catch { idClaveDoc = 0;}

            if (idClaveDoc != 0) cargarDatosRemision();

        }

        private void btnAnula_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma anular el documento actual ?", "Anular documento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No) return;
            string ssql = "update adcdoc set doc_estado = 0 where doc_sucursal = '" + docActualSucursal + "' and opc_documento ='" + docActualTipo + "' and idclavedoc = " + idClaveDoc.ToString();
            SqlConnection cnn = new SqlConnection(strConxAdcom);
            cnn.Open();
            SqlCommand comm = new SqlCommand(ssql, cnn);
            comm.ExecuteNonQuery();
            cnn.Close();
            cnn.Dispose();
            comm.Dispose();
            limpiarDatos();
        }

        private void btnElimina_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma ELIMINAR el documento actual ?", "Elimina documento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No) return;
            datADCDOC.Borrar();
        }

        private void txtNumeroRemision_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                saltar = true;
                idClaveDoc = verificarExistenciaDocumento(CONEMP.EmpresaAct.SucActual, cmbDocumento.SelectedValue.ToString(), txtNumeroRemision.Text);
                if (idClaveDoc > 0) cargarDatosRemision();
            }
        }

        private void cmbDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tipoDoc = cmbDocumento.SelectedValue.ToString();
            string suc = CONEMP.EmpresaAct.SucActual;
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
                if (tieneComprobantesElectronicos == true) { solicitarAutorizacionElectronica(); } else { imprimirDocumento(); }
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
            if (docSustentoSucursal == null || docSustentoSucursal == string.Empty ) docSustentoSucursal = CONEMP.EmpresaAct.SucActual;

            BuscadorDocumentos.buscadorDoc progBus = new BuscadorDocumentos.buscadorDoc(strConxAdcom,strDaxsys);
            if (cmbDocumentoSustento.SelectedValue == null) 
            {
                MessageBox.Show("Debe seleccionar el tipo de documento sustento antes de escojer","Buscar Documento Sustento", MessageBoxButtons.OK , MessageBoxIcon.Error  ) ;
                return;
            }
            docActualSucursal = CONEMP.EmpresaAct.SucActual;
            DateTime queFecha = DateTime.Now;
            progBus.IniciaBusqueda( "FAC", "", cmbDocumentoSustento.SelectedValue.ToString(), queFecha, ref docSustentoSucursal, ref docSustentoTipo, ref docSustentoNumero, ref IdClaveDocSustento, false, cmbDocumentoSustento.SelectedValue.ToString(), "", "", "ADCDOC");
            if (IdClaveDocSustento != 0) { cargarDatosDocumentoSustento(); }
            progBus = null;
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
            MantenimientoDirectorio.BuscaClien directorio = new MantenimientoDirectorio.BuscaClien();
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
            MantenimientoDirectorio.BuscaClien directorio = new MantenimientoDirectorio.BuscaClien();
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

        private void cargarComboDocumentos()
        {
            DaxCbos.DaxCombobx combo = new DaxCbos.DaxCombobx();
            string conector = datlib.StrAdcom();
            combo.DaxCombosDoc(tipoDocDefault , "", false, conector, ref cmbDocumento);
        }

        private void cargarComboDocumentoSustento()
        {

            DaxCbos.DaxCombobx combo = new DaxCbos.DaxCombobx();
            string conector = datlib.StrAdcom();
            combo.DaxCombosDoc("FAC","", false, conector, ref cmbDocumentoSustento);        
        }
        private double verificarExistenciaDocumento(string suc, string tipDoc,string numero)
        {
            double clavedoc = 0;
            if (documentoMultiNumeracion == true)
            {
                forma1 = new Form1();
                clavedoc = forma1.SeleccionaDoc(suc, tipDoc , numero,strConxAdcom);
                forma1.Close();
                forma1.Dispose();
                if (clavedoc < 1) return 0;
            }
            else
            {
                DataTable dt = leerTablas("select idclavedoc from adcdoc where doc_sucursal = '" + suc + "' and opc_documento ='" + tipDoc + "' and doc_numero = " + numero);
                if (dt.Rows.Count > 0)
                {
                    clavedoc= Convert.ToDouble(dt.Rows[0]["IdClaveDoc"]);
                }
            }            
                return mensajeDocumentoExiste(clavedoc ) ;
        }
        private Boolean cargarDatosRemision()
        {
            Boolean resp = false;
            if (idClaveDoc != 0)
            {
                datADCDOC = new adcDocumentos.AdcDoc(strConxAdcom);
                datADCDOC = adcDocumentos.AdcDoc.Buscar("doc_sucursal = '" + CONEMP.EmpresaAct.SucActual  + "' and opc_documento ='" + cmbDocumento.SelectedValue.ToString() + "' and idclavedoc = " + idClaveDoc.ToString());
                if (datADCDOC != null)
                {
                    moverClaseDatos();
                    cargarDetalleArticulos(docActualSucursal, docActualTipo , idClaveDoc,"ADCTRA");
                    inicializarUtilidadDocumentos();
                    operacion = 2;
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
                if (operacion == 2)
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
                if (operacion == 2)
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
                    codDestinatario = dt.Rows[0]["codigo"].ToString();
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
            SqlConnection conn = new SqlConnection(strDaxsys);
            conn.Open();
            SqlCommand comm = new SqlCommand("select * from emp_suc where suc_codigo = '" + CONEMP.EmpresaAct.SucActual + "' and emp_codigo = " + CONEMP.EmpresaAct.codigo, conn);
            SqlDataReader dr = comm.ExecuteReader();
            if (dr.Read() == true)
            {
                txtCodUbicacion.Text = dr["suc_idtributario"].ToString();
                txtdireccionPartida.Text = dr["suc_direccion"].ToString();
                dr.Close();
                dr.Dispose();
                conn.Close();
                conn.Dispose();
                comm.Dispose();
            }
        }
        private void copiarDocumento(string suc, string tip, double idClave)
        {
            
            adcDocumentos.utilDoc.cadenaConexion = strConxAdcom;
            string tabladoc="";
            string tablatra="";
            adcDocumentos.utilDoc.tablasDeDatos(tip, ref tabladoc, ref tablatra);

            if (MessageBox.Show("Desea copiar la cabezera del documento ? ", "Copiar datos documento", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                cargarCabezeraDocumento (suc,tip,idClave,tabladoc );
            }
            cargarDetalleArticulos(suc, tip, idClave,tablatra);
        
        }
        private void cargarDatosDocumentoSustento()
        {

            adcDocumentos.utilDoc.cadenaConexion = strConxAdcom;
            string tabladoc = "";
            string tablatra = "";
            adcDocumentos.utilDoc.tablasDeDatos(docSustentoTipo, ref tabladoc, ref tablatra);
            
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
            string ssql = "select tra_codigo as codigo, tra_nombre as Descripción, tra_cantidad as Cantidad, tra_medida as Medida  from " + tablatra + " where doc_sucursal = '" + suc  + "' and opc_documento ='" + tip + "' and idclavedoc = " + idClave.ToString();
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
                da = new SqlDataAdapter(ssql, strConxAdcom);
                da.Fill(dt);
            }
            catch
            {
                return null;
            }
            return dt;
        }

        # endregion carga de datos

        private void imprimirDocumento()
        {
            ImprDoct.ImprimirDoc progimp = new ImprDoct.ImprimirDoc();
            docUtility .docUtils FImprimeDocumento = new docUtility.docUtils ();
            if (tieneComprobantesElectronicos)
            {
                FImprimeDocumento.ImpDoc(idClaveDoc, CONEMP.EmpresaAct.SucActual, cmbDocumento.SelectedValue.ToString(), Convert.ToDouble(txtNumeroRemision.Text), "A", "F", propiedadesDoc.TipoDoc, "FELREM");
            }
            else
            {
                FImprimeDocumento.ImpDoc(idClaveDoc, CONEMP.EmpresaAct.SucActual, cmbDocumento.SelectedValue.ToString(), Convert.ToDouble(txtNumeroRemision.Text), "A", "F", propiedadesDoc.TipoDoc,"");
            }

            progimp.claveSri = claveSri;
            progimp.CorreoElectronico = correoElectronico;
        }

        private void inicializarUtilidadDocumentos()
        {
            datADCDOC.Putil.Doc_sucursal = CONEMP.EmpresaAct.SucActual;
            datADCDOC.Putil.Opc_documento = cmbDocumento.SelectedValue.ToString();
            datADCDOC.Putil.idsri = txtCodUbicacion.Text;
            datADCDOC.Putil.propietario = codDestinatario;
            adcDocumentos.utilDoc.cadenaConexion = strConxAdcom;
            lugarNumeracionDocumento = datADCDOC.Putil.establecerLugar(ref documentoMultiNumeracion);
            datADCDOC.Putil.esNroMultiple = documentoMultiNumeracion;
        }

        private Boolean  grabarDocumento()
        {
            malla.EndEdit();
            Boolean RESP = true ;

            string res = "";
           try 
            {
                if (idClaveDoc == 0)
                {
                    res = datADCDOC.Crear ();
                    idClaveDoc = Convert.ToDouble(datADCDOC.IdClaveDoc);
                    if (res.Substring(0, 3) != "ERR") { grabarAdctra(); }
                    if (idClaveDoc != 0) datADCDOC.Putil.guardarNumeroDocumento("", Convert.ToDouble(txtNumeroRemision.Text));                    
                }
                else
                {
                    res = datADCDOC.Actualizar();
                    if (res.Substring(0, 3) != "ERR") {grabarAdctra();}
                    datADCDOC.Putil.guardarNumeroDocumento("", Convert.ToDouble(txtNumeroRemision.Text));
                }
            }
            catch (Exception ee)
            {
                res="ERR " + ee.Message;
            }
            if (res.Substring(0, 3) == "ERR")
            {
                MessageBox.Show("EL DOCUMENTO NO FUE GRABADO CORRECTAMENTE \n" + res);
                RESP = false;
            }
            return RESP ;
        }
        private void grabarAdctra()
        {
                adcDocumentos.AdcTra adctra = new adcDocumentos.AdcTra(strConxAdcom);

                adctra.Doc_sucursal = CONEMP.EmpresaAct.SucActual;
                adctra.Opc_documento = cmbDocumento.SelectedValue.ToString();
                adctra.Doc_numero = Convert.ToDecimal(txtNumeroRemision.Text);
                adctra.IdClaveDoc = Convert.ToDecimal(idClaveDoc);
                adctra.Tra_DocSop = datADCDOC.Doc_DocSop;
                adctra.Tra_NumSop = datADCDOC.Doc_NumSop;
                adctra.Tra_fecha = DateTime.Now;
                adctra.Tra_quetipo = "A";
                adctra.Tra_TipoDoc = propiedadesDoc.TipoDoc;
                adctra.Tra_Estado = 1;
                adctra.grabarDetalleAdctra(malla);
                adctra = null;
        }
        
        private void eliminarDetalle()
        {
            SqlConnection con = new SqlConnection(strConxAdcom);
            con.Open();
            string del = "delete FROM AdcTra WHERE doc_sucursal = '" + CONEMP.EmpresaAct.SucActual + "' and opc_documento = '" + cmbDocumento.SelectedValue.ToString() + "' and idclavedoc = " + idClaveDoc.ToString();
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
                datADCDOC.Doc_fecha = Convert.ToDateTime(txtFechaDocumento.Text);
                datADCDOC.Doc_FechaEfe = datADCDOC.Doc_fecha;
                datADCDOC.Doc_FecGraba =DateTime.Now;
                datADCDOC.Doc_numero = Convert.ToDecimal( txtNumeroRemision.Text );
            }

            datADCDOC.Doc_FechaModifica = DateTime.Now;
            datADCDOC.Doc_Hora = DateTime.Now;
            datADCDOC.Doc_codusu = CONUSER.UsuarioAct.Identifica;
            datADCDOC.Doc_codper = codDestinatario;
            datADCDOC.Doc_sucursal = CONEMP.EmpresaAct.SucActual;
            datADCDOC.Opc_documento = cmbDocumento.SelectedValue.ToString();
            datADCDOC.IdClaveDoc =Convert.ToDecimal( idClaveDoc);
            datADCDOC.Doc_TipoDoc = propiedadesDoc.TipoDoc ;
            datADCDOC.Doc_CiRuc = txtCedDestinatario.Text;
            datADCDOC.RucTransportista = txtcedulaTransportista.Text;
            datADCDOC.Destinatario = txtCodUbicacion.Text;
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
            datADCDOC.Doc_NroIdDoc = txtCodUbicacion.Text;
            datADCDOC.Doc_Estado = 1;
        }
        private void moverClaseDatos()
        {
            idClaveDoc = Convert.ToDouble(datADCDOC.IdClaveDoc);
            txtNumeroRemision.Text = datADCDOC.Doc_numero.ToString();
            txtFechaDocumento.Text = datADCDOC.Doc_fecha.ToShortDateString ();
            codDestinatario = datADCDOC.Doc_codper;
            txtCedDestinatario.Text  = datADCDOC.Doc_CiRuc;
            txtcedulaTransportista.Text = datADCDOC.RucTransportista;
            txtCodUbicacion.Text = datADCDOC.Destinatario;
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
            datADCDOC = new adcDocumentos.AdcDoc(strConxAdcom);
            txtNumeroRemision.Text = "";
            codDestinatario = "";
            txtCedDestinatario.Text = "";
            txtcedulaTransportista.Text = "";
            txtDireccionDestinatario.Text = "";
            txtDocAduaneroUnico.Text = "";
            txtFechaDocumento.Text = DateTime.Now.ToShortDateString();
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
            operacion = 0;
            prepararBotones();
            InicializarMalla();
            idClaveDoc = 0;
            IdClaveDocSustento = 0;
        }
        private void prepararBotones()
        {
            Boolean inicio = (operacion == 0);
            Boolean nuevo = (operacion == 1);
            Boolean modificando = (operacion == 2);

            btnAbre.Enabled  = inicio;
            btnNuevo.Enabled  = inicio;

            btnAnula.Enabled = modificando ;
            btnCierra.Enabled = !inicio;
            btnCopia.Enabled = nuevo;
            btnElimina.Enabled = modificando;
            btnGraba.Enabled = !inicio;
            btnImprimir.Enabled = modificando;
            btnRegistra.Enabled = !inicio;

            panel4.Enabled = (operacion != 0);
            malla.Enabled = (operacion != 0);

            cmbDocumento.Enabled = (operacion != 2);
            txtNumeroRemision.Enabled=(operacion != 2);
        }


        private Boolean validarRemision()
        {
            string mensaje ="";
           docUtility. docUtils util = new docUtility.docUtils ();
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
            if (txtCodUbicacion.Text.Length < 7) { mensaje += " Falta el código de ubicacion \n"; }
            if (txtMotivoTransporte.Text.Length < 1) {mensaje += " Falta el motivo de transporte \n";}
            if (txtCodigoEstabDestino.Text.Length < 1) { mensaje += " Falta el código de identificación del establecimiento destino \n"; }
            if (txtdireccionPartida.Text.Length < 1) {mensaje += "Falta la dirección de partida \n";}
            if (mensaje.Length > 0){ MessageBox.Show("Excepción en el documento: " + mensaje); return false;}
            if (malla.Rows.Count < 2) { MessageBox.Show( " No se ha registrado artículos válidos " + mensaje); return false;}
            if (util.ExisteDocumentoGrabado(ref datADCDOC, ref propiedadesDoc , strConxAdcom,idClaveDoc ) == true)
            {
                MessageBox.Show("ERROR: Ya existe un documento igual registrado", "Grabar documento", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;            
        }
        private void validaComprobantesElectronicos()
        {
            tieneComprobantesElectronicos = File.Exists(CONEMP.EmpresaAct.PatAppl + @"DaxFelec.exe");
            //if (tieneComprobantesElectronicos == false)
            //{
            //    tieneComprobantesElectronicos = File.Exists(Emp.PatAppl + @"DaxFelec.exe"); 
            //}
            //if (tieneComprobantesElectronicos == false) 
            //{
            //    tieneComprobantesElectronicos = File.Exists(Emp.PatAppl + @"AdcGenxml.dll");
            //}
        }
        private void solicitarAutorizacionElectronica()
        {
            Int16 tipo = 1;
            try
            {
                WebService.WebServicesSRI ws = new WebService.WebServicesSRI();
                if (ws.IsOnLine == false) { tipo = 2; }
            }
            catch { tipo = 2; }

            if (tipo == 2)
            {
                if (MessageBox.Show("Los servicios Web del SRI no están disponibles \n Desea emitir el comprobante con claves de contingencia ?", "Emisión comprobantes electrónicos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No) return;
            }

            Daxconxfe.Adcconxfe factElec = new Daxconxfe.Adcconxfe();
            claveSri = factElec.pedirAutorizacionSri (datADCDOC.Doc_sucursal, datADCDOC.Opc_documento, Convert.ToDouble(datADCDOC.IdClaveDoc), datADCDOC.Doc_numero.ToString(), propiedadesDoc.TipoDoc, CONEMP.EmpresaAct.ruc, CONEMP.EmpresaAct.DigitosPrecios, CONEMP.EmpresaAct.PatAppl,tipo);
            if (claveSri.Substring(0, 3).ToUpper() != "ERR" && claveSri.Length > 0)
            {
                MessageBox.Show("autorización SRI EXITOSA \n" + claveSri, "Autorización SRI");
                imprimirDocumento();
            }
            else
            {
                MessageBox.Show("COMPROBANTE CON ERRORES NO FUE AUTORIZADO \n" + claveSri);
            }
        }

        #region manejo malla

        private void malla_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (malla.IsCurrentCellInEditMode == true)
            {
                DataGridViewCell cell = malla.CurrentCell;
                funcionesEspeciales(Keys.Enter, ref cell,"");
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
        if (funcionesEspeciales(keyData, ref cell,"") == false) { malla.BeginEdit(true); return true; }
        
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

        malla.CurrentCell = cell;
        return true;
       }

       private Boolean funcionesEspeciales(Keys keyData, ref DataGridViewCell cell,string tipoCliente)
       {
           Boolean resp = true;
           malla.EndEdit();
           string dato = cell.Value.ToString();
           string nombreCelda = malla.Columns[cell.ColumnIndex].Name.ToUpper();
           if (keyData == Keys.Enter)
           {
               if (nombreCelda == "CODIGO")
               {
                   //return (mallaArticulo.cargarArticuloVta(ref opArt  cell.Value.ToString(), malla,propiedadesDoc,tipoCliente, txtFechaDocumento.Text,cmbDocumento.SelectedValue.ToString(), idClaveDoc));
               }
           }
           else if (keyData == Keys.F2)
           {
               if (nombreCelda == "CODIGO")
               {
                   mallaArticulo.buscarArticulo(cell.Value.ToString());
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
             mallaArticulo.AcumularLineasMalla(ref malla, 0, 2);
        }

        private void txtNumeroRemision_Leave(object sender, EventArgs e)
        {
            if (saltar == true) { saltar = false; return; }
            if (operacion != 2)
            {
                idClaveDoc = verificarExistenciaDocumento(CONEMP.EmpresaAct.SucActual, cmbDocumento.SelectedValue.ToString(), txtNumeroRemision.Text);
                if (idClaveDoc > 0) cargarDatosRemision();
            }
        }

        private void btnCopia_Click(object sender, EventArgs e)
        {
            string SUC = CONEMP.EmpresaAct.SucActual;
            string TIP = "";
            double Idclave = 0;
            double Numero = 0;
            BuscadorDocumentos.buscadorDoc progBus = new BuscadorDocumentos.buscadorDoc(strConxAdcom,strDaxsys);
            DateTime queFecha = DateTime.Now;
            progBus.IniciaBusqueda( "", "", "", queFecha, ref SUC, ref TIP, ref Numero, ref Idclave, false, "EGB", "", "", "ADCDOC");
            if (Idclave != 0) { copiarDocumento(SUC,TIP,Idclave); }
            progBus = null;

        }

        private void txtNumeroRemision_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
