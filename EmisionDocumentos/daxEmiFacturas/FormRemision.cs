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
using DtosMall;
using ImpresionDoc;

namespace DctosEmi
{
    public partial class FormRemision : Form
    {
        //Form1 forma1 = new Form1();

        string claseDocDefault = "REM";
        string tipoDocDefault = "REM";
        string memTipoDoc = "";
        string memBodega = "";
        int operacionEnCurso = 0; // 0 sin operacion delcarada, 1 nuevo registro, 2 modificando registro
        internal int sinOperacion = 0;
        internal int nuevoRegistro = 1;
        internal int modificandoRegistro = 2;
        bool esSoloConsulta = false;
        bool iniciaConNuevoDOc = false;
        Boolean saltar = false;

        DataTable dtDetalleDocumento = new DataTable();

        internal idDocumento idDocumentoActual = new idDocumento();
        internal idDocumento idDocumentoSoporte = new idDocumento();
        internal idDocumento idDocumentoParaGenerar = new idDocumento();

        internal daxAccs.propiedadesDaxAuto accesosLocalizados = new daxAccs.propiedadesDaxAuto();

        DtosMall.docMallaArticulo mallaArticulo = new DtosMall.docMallaArticulo();

        string docActualSucursal = "";
        string docActualTipo = "";
        double idClaveDoc = 0;
        string codDestinatario = "";
        string codTransportista = "";

        string docSustentoSucursal = "";
        string docSustentoTipo = "";
        double docSustentoNumero = 0;
        double IdClaveDocSustento = 0;
        DateTime docSustentoFecha = new DateTime(1900, 1, 1);
        string docSustentoNumId = "";
        Boolean saltaEventosMalla = false;

        string formatoNumero = "##0.00";

        internal sesSys.OpcDoc propiedadesDoc = new sesSys.OpcDoc();
        AdcDoc datADCDOC;
        internal string codCliente = "";
        directMnt.DirectorioAlex opalex = new directMnt.DirectorioAlex();

        // BindingSource para manejo robusto del DataGridView
        private BindingSource mallaBindingSource = new BindingSource();

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

           
            validaComprobantesElectronicos();

            // Suscribirse al evento DataSourceChanged
            malla.DataSourceChanged += malla_DataSourceChanged;
        }

       
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                docActualSucursal = datosEmpresa.suc;
                docActualTipo = cmbDocumento.SelectedValue.ToString();
                propiedadesDoc.Cargar(ref docActualTipo, ref docActualSucursal);
                limpiarDatos();

                // Re-suscribir evento por seguridad
                malla.DataSourceChanged -= malla_DataSourceChanged;
                malla.DataSourceChanged += malla_DataSourceChanged;
            }
            catch (Exception ee)
            {
                MessageBox.Show("No se ha definido un documento de Remisión: " + ee.Message, "Emision de documentos Remisiones", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            llenarDatosEmpresa();

            txtNroID.Text = valoresPredefinidosSucursal.idtributario;
            txtNroID.Enabled = (valoresPredefinidosSucursal.autCambiaPtoVta || datosEmpresa.usr.ToUpper() == "ADMINISTRADOR");

            ptoVenta.Visible = false;

            LlenarCombos();
            CargarPredefinidosDocumento();

            this.txtfecha.ValueChanged += new System.EventHandler(this.txtfecha_ValueChanged);
            this.Text += "  " + datosEmpresa.nomEmpresa + " PUNTO DE VENTA: " + valoresPredefinidosSucursal.nomPuntoVta;
            //InicializarMalla();
        }

        private void InicializarMalla()
        {
            string ssql = "select tra_codigo , tra_nombre , tra_cantidad , tra_medida,tra_queTipo,tra_sucdestino,tra_boddestino,Tra_piezas,Tra_peso";
            ssql += ", Tra_Individual,Tra_snIva,Tra_multiplo,Tra_NroLote ";
            ssql += " from adctra where doc_sucursal = 'f'";

            DataTable dtt = leerTablas(ssql);

            // Si no hay datos, crear estructura mínima con columnas definidas
            if (dtt == null || dtt.Rows.Count == 0)
            {
                dtt = new DataTable();
                dtt.Columns.Add("tra_codigo", typeof(string));
                dtt.Columns.Add("tra_nombre", typeof(string));
                dtt.Columns.Add("tra_cantidad", typeof(decimal));
                dtt.Columns.Add("tra_medida", typeof(string));
                dtt.Columns.Add("tra_queTipo", typeof(string));
                dtt.Columns.Add("tra_sucdestino", typeof(string));
                dtt.Columns.Add("tra_boddestino", typeof(string));
                dtt.Columns.Add("Tra_piezas", typeof(decimal));
                dtt.Columns.Add("Tra_peso", typeof(decimal));
                dtt.Columns.Add("Tra_Individual", typeof(string));
                dtt.Columns.Add("Tra_snIva", typeof(string));
                dtt.Columns.Add("Tra_multiplo", typeof(decimal));
                dtt.Columns.Add("Tra_NroLote", typeof(string));
            }

            // Asegurar que siempre haya al menos una fila editable vacía
            if (dtt.Rows.Count == 0 || !HayFilaVacia(dtt))
            {
                dtt.Rows.Add(dtt.NewRow());
            }

            // Usar BindingSource para manejo robusto del DataSource
            mallaBindingSource.DataSource = dtt;
            malla.DataSource = mallaBindingSource;

            diseñarMalla();
        }

        // Método auxiliar para verificar si hay fila con código vacío
        private bool HayFilaVacia(DataTable dt)
        {
            if (dt == null) return false;
            foreach (DataRow row in dt.Rows)
            {
                var codigo = row["tra_codigo"];
                if (codigo == DBNull.Value || string.IsNullOrWhiteSpace(codigo.ToString()))
                    return true;
            }
            return false;
        }

        private void diseñarMalla()
        {
            malla.RowHeadersWidth = 20;
            malla.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
            malla.RowHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
            malla.RowHeadersDefaultCellStyle.ForeColor = Color.White;
            malla.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            malla.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Verificar que las columnas existan antes de asignar propiedades
            if (malla.Columns["tra_codigo"] != null)
            {
                malla.Columns["tra_codigo"].HeaderText = "Código";
                malla.Columns["tra_codigo"].Width = 105;
            }

            if (malla.Columns["tra_nombre"] != null)
            {
                malla.Columns["tra_nombre"].HeaderText = "Descripción";
                malla.Columns["tra_nombre"].Width = 320;
            }

            if (malla.Columns["tra_cantidad"] != null)
            {
                malla.Columns["tra_cantidad"].HeaderText = "Cantidad";
                malla.Columns["tra_cantidad"].Width = 60;
                malla.Columns["tra_cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                malla.Columns["tra_cantidad"].DefaultCellStyle.Format = formatoNumero;
            }

            if (malla.Columns["tra_medida"] != null)
            {
                malla.Columns["tra_medida"].HeaderText = "Medida";
                malla.Columns["tra_medida"].Width = 40;
                malla.Columns["tra_medida"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            // Ocultar columnas no necesarias
            string[] columnasOcultar = { "tra_queTipo", "tra_sucdestino", "Tra_Individual", "Tra_snIva",
                                           "tra_boddestino", "Tra_piezas", "Tra_peso", "Tra_multiplo", "Tra_NroLote" };
            foreach (string columna in columnasOcultar)
            {
                if (malla.Columns[columna] != null)
                    malla.Columns[columna].Visible = false;
            }

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
            if (classAnular.anularDocumento(datosEmpresa.strConxAdcom, datosEmpresa.strConxSyscod, idDocumentoActual, datosEmpresa.usr, false, datosEmpresa.nomEmpresa, datosEmpresa.codEmpresa.ToString(), "0", "ADCDOCPRO", propiedadesDoc.ComandoExterno)) limpiarDatos();
        }

        private void btnElimina_Click(object sender, EventArgs e)
        {
            DctosEmi.anulaElimina classAnular = new DctosEmi.anulaElimina();
            if (classAnular.eliminarDocumento(datosEmpresa.strConxAdcom, datosEmpresa.strConxSyscod, idDocumentoActual, datosEmpresa.usr, false, datosEmpresa.nomEmpresa, datosEmpresa.codEmpresa.ToString(), "", "ADCDOCPRO", propiedadesDoc.ComandoExterno)) limpiarDatos();
        }

        private void txtNumeroRemision_KeyDown(object sender, KeyEventArgs e)
        {
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
            if (cmbDocumento.SelectedValue == null) return;
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
            if (docSustentoSucursal == null || docSustentoSucursal == string.Empty) docSustentoSucursal = datosEmpresa.suc;

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
                if (MessageBox.Show("Desea copiar todos los datos del documento soporte escojido  ?", "Copiar documento soporte de remisión", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
                copiarDocumento(idDocumentoSoporte, true);
            }
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
                if (dt != null && dt.Rows.Count > 0)
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
            try
            {
                recordarOpciones();

                if (string.IsNullOrEmpty(datosEmpresa.strConxAdcom))
                {
                    MessageBox.Show("Error: Cadena de conexión vacía", "Diagnóstico");
                    return;
                }

                DaxCombobx.CargCmbBox cmb = new DaxCombobx.CargCmbBox();

                try { cmb.DaxCombosDoc(claseDocDefault, tipoDocDefault, false, datosEmpresa.strConxAdcom, ref cmbDocumento); }
                catch (Exception ex) { MessageBox.Show($"Error en DaxCombosDoc: {ex.Message}", "Error de permisos", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                try { cmb.DaxCombosBods(datosEmpresa.suc, false, datosEmpresa.strConIniSis, ref cmbBodega); }
                catch (Exception ex) { MessageBox.Show($"Error en DaxCombosBods: {ex.Message}", "Error de permisos", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                try { cmb.DaxCombosDoc("FACINVPRO", "", false, datosEmpresa.strConxAdcom, ref cmbDocumentoSustento); }
                catch (Exception ex) { MessageBox.Show($"Error en DaxCombosDoc (FACINVPRO): {ex.Message}", "Error de permisos", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error general en LlenarCombos: {ex.Message}\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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
                    cargarDetalleArticulos(docActualSucursal, docActualTipo, idClaveDoc, "ADCTRA");
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
                    MessageBox.Show("El documento no existe, digite otro numero ", "Busqueda de documentos", MessageBoxButtons.YesNo, MessageBoxIcon.Question); laClaveDoc = 0;
                }
            }
            return laClaveDoc;
        }

        private void cargarDatosCliente(string codigo = "")
        {
            if (codigo != "")
            {
                DataTable dt = leerTablas("select codigo,cedulaidentidadruc,nombreimpresion,domicilio from identificacion where codigo ='" + codigo + "'");
                if (dt != null && dt.Rows.Count > 0)
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
                //txtNroID.Text = dr["suc_idtributario"].ToString();
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

            //dtDetalleDocumento = (DataTable)malla.DataSource;

            if (malla.DataSource is BindingSource bindingSource)
            {
                dtDetalleDocumento = bindingSource.DataSource as DataTable;
            }
            else if (malla.DataSource is DataTable dataTable)
            {
                dtDetalleDocumento = dataTable;
            }
            else
            {
                dtDetalleDocumento = new DataTable(); // Crear uno nuevo si es null
            }
            copia.CopiarElDocumento(idDocCopiar, opcp.tablaDatosDoc, ref datADCDOC, ref dtDetalleDocumento);
            if (datADCDOC != null && datADCDOC.Doc_codper.Length > 0)
            {
                datADCDOC.IdClaveDoc = 0;
                datADCDOC.Doc_numero = Convert.ToDecimal(txtnumero.Text);
                datADCDOC.Doc_fecha = txtfecha.Value;

                docSustentoSucursal = idDocCopiar.Sucursal;
                docSustentoTipo = idDocCopiar.Tipo;
                IdClaveDocSustento = (double)idDocCopiar.idClave; // Asegúrate del cast correcto

                cargarCabezeraDocumento(idDocCopiar.Sucursal, idDocCopiar.Tipo, (double)idDocCopiar.idClave, opcp.tablaDatosDoc);

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

                // Usar BindingSource al asignar nuevo DataSource
                mallaBindingSource.DataSource = dtDetalleDocumento;
                malla.DataSource = mallaBindingSource;

                diseñarMalla();
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
                cargarCabezeraDocumento(docSustentoSucursal, docSustentoTipo, IdClaveDocSustento, tabladoc);
                if (MessageBox.Show("Desea cargar el detalle de artículos del documento ? ", "Copiar datos documento", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    cargarDetalleArticulos(docSustentoSucursal, docSustentoTipo, IdClaveDocSustento, tablatra);
                }
            }
        }

        private void cargarCabezeraDocumento(string suc, string tip, double idClave, string tabladoc)
        {
            DataTable dt = leerTablas("select * from " + tabladoc + " where doc_sucursal = '" + suc + "' and opc_documento ='" + tip + "' and idclavedoc = " + idClave.ToString());
            if (dt != null && dt.Rows.Count > 0)
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

        private void cargarDetalleArticulos(string suc, string tip, double idClave, string tablatra)
        {
            string ssql = "select tra_codigo , tra_nombre , tra_cantidad , tra_medida,tra_queTipo,tra_sucdestino,tra_boddestino,Tra_piezas,Tra_peso";
            ssql += ", Tra_Individual,Tra_snIva,Tra_multiplo,Tra_NroLote ";
            ssql += " from " + tablatra + " where doc_sucursal = '" + suc + "' and opc_documento ='" + tip + "' and idclavedoc = " + idClave.ToString();
            DataTable dtt = leerTablas(ssql);
            if (dtt == null) return;

            // Usar BindingSource
            mallaBindingSource.DataSource = dtt;
            malla.DataSource = mallaBindingSource;

            diseñarMalla();
        }

        private DataTable leerTablas(string ssql)
        {
            SqlDataAdapter da;
            DataTable dt = new DataTable();
            try
            {
                da = new SqlDataAdapter(ssql, datosEmpresa.strConxAdcom);
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

            {
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

            if (res.Substring(0, 3) == "ERR")
            {
                MessageBox.Show("EL DOCUMENTO NO FUE GRABADO CORRECTAMENTE \n" + res);
                RESP = false;
            }
            return RESP;
        }

        private void grabarAdctra()
        {
            ClassDoc.grabMallTra.grabarDetalleAdctra(malla, datADCDOC, datosEmpresa.strConxAdcom);
        }

        private void eliminarDetalle()
        {
            SqlConnection con = new SqlConnection(datosEmpresa.strConxAdcom);
            con.Open();
            string del = "delete FROM AdcTra WHERE doc_sucursal = '" + datosEmpresa.suc + "' and opc_documento = '" + cmbDocumento.SelectedValue.ToString() + "' and idclavedoc = " + idClaveDoc.ToString();
            SqlCommand comm = new SqlCommand(del, con);
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
                datADCDOC.Doc_FecGraba = DateTime.Now;
                datADCDOC.Doc_numero = Convert.ToDecimal(txtnumero.Text);
            }

            datADCDOC.Doc_FechaModifica = DateTime.Now;
            datADCDOC.Doc_Hora = DateTime.Now;
            datADCDOC.Doc_codusu = DatosUsuario.Identifica;
            datADCDOC.Doc_codper = codDestinatario;
            datADCDOC.Doc_sucursal = datosEmpresa.suc;
            datADCDOC.Opc_documento = cmbDocumento.SelectedValue.ToString();
            datADCDOC.IdClaveDoc = Convert.ToDecimal(idClaveDoc);
            datADCDOC.Doc_TipoDoc = propiedadesDoc.TipoDoc;
            datADCDOC.Doc_CiRuc = txtCedDestinatario.Text;
            datADCDOC.RucTransportista = txtcedulaTransportista.Text;
            datADCDOC.Destinatario = txtNroID.Text;
            datADCDOC.Doc_Direccion = txtDireccionDestinatario.Text;
            datADCDOC.dirPartida = txtdireccionPartida.Text;
            datADCDOC.docAduaneroUnico = txtDocAduaneroUnico.Text;
            datADCDOC.FecFinTransporte = Convert.ToDateTime(txtFechafin.Text);
            datADCDOC.FecIniTransporte = Convert.ToDateTime(txtfechaini.Text);
            datADCDOC.Doc_NombreImp = txtNombreDestinatario.Text;
            datADCDOC.Transportista = codTransportista;
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
            txtfecha.Text = datADCDOC.Doc_fecha.ToShortDateString();
            codDestinatario = datADCDOC.Doc_codper;
            txtCedDestinatario.Text = datADCDOC.Doc_CiRuc;
            txtcedulaTransportista.Text = datADCDOC.RucTransportista;
            txtNroID.Text = datADCDOC.Destinatario;
            txtDireccionDestinatario.Text = datADCDOC.Doc_Direccion;
            txtdireccionPartida.Text = datADCDOC.dirPartida;
            txtDocAduaneroUnico.Text = datADCDOC.docAduaneroUnico;
            txtFechafin.Text = datADCDOC.FecFinTransporte.ToShortDateString();
            txtfechaini.Text = datADCDOC.FecIniTransporte.ToShortDateString();
            txtNombreDestinatario.Text = datADCDOC.Doc_NombreImp;

            codTransportista = datADCDOC.Transportista;
            cargarDatosTransportista(codTransportista);

            txtnumeroSustento.Text = datADCDOC.Doc_NumSop.ToString();
            txtPlaca.Text = datADCDOC.AuxVar10;
            txtRuta.Text = datADCDOC.rutaTransporte;
            if (cmbDocumentoSustento != null && datADCDOC.Doc_DocSop != null)
            {
                try { cmbDocumentoSustento.SelectedValue = datADCDOC.Doc_DocSop; }
                catch { }
            }
            txtMotivoTransporte.Text = datADCDOC.TipoTransporte;
            txtCodigoEstabDestino.Text = datADCDOC.codEstabDestino;

            IdClaveDocSustento = Convert.ToDouble(datADCDOC.IdClaveDocSop);
            docSustentoTipo = datADCDOC.Doc_DocSop;
            docSustentoNumero = Convert.ToDouble(datADCDOC.Doc_NumSop);
            docSustentoFecha = datADCDOC.AuxFec1;
            docSustentoSucursal = datADCDOC.Doc_sucursal;
            docSustentoNumId = datADCDOC.AuxVar11;
            txtDescripcion.Text = datADCDOC.Doc_detalle;

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
            if (cmbDocumentoSustento != null)
                cmbDocumentoSustento.SelectedValue = "";
            txtMotivoTransporte.Text = "";
            txtCodigoEstabDestino.Text = "";
            txtDescripcion.Text = "";
            txtNroID.Text = valoresPredefinidosSucursal.idtributario;
            mensajesDocumento.Text = "";
            operacionEnCurso = 0;
            prepararBotones();
            //InicializarMalla();
            idClaveDoc = 0;
            IdClaveDocSustento = 0;
            malla.DataSource = null;
        }

        private void prepararBotones()
        {
            Boolean inicio = (operacionEnCurso == sinOperacion);
            Boolean nuevo = (operacionEnCurso == nuevoRegistro);
            Boolean modificando = (operacionEnCurso == modificandoRegistro);
            Boolean docAnulado = false;

            try { docAnulado = (datADCDOC != null && datADCDOC.Doc_Estado == 0 && modificando); }
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
            ptoVenta.Enabled = inicio;

            btnBarras.Enabled = (!inicio) && !docAnulado;
            btnAgrupa.Enabled = (btnBarras.Enabled && btnBarras.Checked);

            malla.Enabled = (!inicio && !docAnulado);
            cmbDocumento.Enabled = inicio;

            if (!accesosLocalizados.sinRegistro)
            {
                bool puedeEditar = (!inicio && accesosLocalizados.NúmeroDocumento && !docAnulado);
                txtnumero.Enabled = puedeEditar;
                txtNroID.Enabled = puedeEditar;
                txtfecha.Enabled = (!inicio && accesosLocalizados.FechaDocumento && !docAnulado);
            }
            else
            {
                txtnumero.Enabled = (!inicio && !docAnulado);
                txtNroID.Enabled = (!inicio && !docAnulado);
                txtfecha.Enabled = (!inicio && !docAnulado);
            }

            if (accesosLocalizados.sinRegistro == false)
            {
                if (nuevo)
                {
                    btnGraba.Enabled = (btnGraba.Enabled && accesosLocalizados.Crear);
                    btnRegistra.Enabled = (btnRegistra.Enabled && btnGraba.Enabled && accesosLocalizados.Imprimir);
                }
                else if (modificando)
                {
                    btnGraba.Enabled = (btnGraba.Enabled && accesosLocalizados.Modificar);
                    btnRegistra.Enabled = (btnRegistra.Enabled && btnGraba.Enabled && accesosLocalizados.Modificar && accesosLocalizados.Imprimir);
                }

                BtnEnviar.Enabled = (BtnEnviar.Enabled && accesosLocalizados.Imprimir);
                btnNuevo.Enabled = (accesosLocalizados.Crear && btnNuevo.Enabled);
                btnElimina.Enabled = (accesosLocalizados.Eliminar && btnElimina.Enabled);
                btnAnula.Enabled = (accesosLocalizados.Anular && btnAnula.Enabled);
                btnCopia.Enabled = (accesosLocalizados.Crear && btnCopia.Enabled);

                cmbBodega.Enabled = (accesosLocalizados.Bodega && !inicio && !docAnulado);
                if (!string.IsNullOrEmpty(accesosLocalizados.BodegaFija) && cmbBodega != null)
                {
                    try { cmbBodega.SelectedValue = accesosLocalizados.BodegaFija; }
                    catch { }
                    cmbBodega.Enabled = false;
                }
            }

            if (esSoloConsulta == true || docAnulado)
            {
                DeshabilitarTodoParaConsulta();
                if (datADCDOC != null && datADCDOC.Doc_Estado == 1 && datosEmpresa.usr.ToUpper() == "ADMINISTRADOR" && !esSoloConsulta)
                {
                    btnElimina.Enabled = true;
                }
            }

            if (propiedadesDoc != null && propiedadesDoc.ImprimirDoc == "N")
                BtnEnviar.Visible = false;
        }

        private bool ValidarPuntoVenta()
        {
            if (string.IsNullOrEmpty(txtNroID.Text))
            {
                MessageBox.Show("Debe seleccionar/ingresar un punto de venta/establecimiento", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNroID.Focus();
                return false;
            }
            if (txtNroID.Text.Length < 3)
            {
                MessageBox.Show("El punto de venta debe tener un formato válido (ejemplo: 001-001)", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNroID.Focus();
                return false;
            }
            return true;
        }

        private Boolean validarRemision()
        {
            string mensaje = "";
            docUtils util = new docUtils();
            moverDatosClase();

            if (!ValidarPuntoVenta()) return false;

            try
            {
                if (Convert.ToDateTime(txtFechafin.Text) < Convert.ToDateTime(txtfechaini.Text))
                    mensaje = "La fecha final de transporte es menor que la fecha inicial \n";
            }
            catch { mensaje = "Existen errores en las fechas de transporte"; }

            if (txtMotivoTransporte.Text.Length < 1) mensaje += " Falta el motivo de transporte \n";
            if (txtCodigoEstabDestino.Text.Length < 1) mensaje += " Falta el código de identificación del establecimiento destino \n";
            if (txtdireccionPartida.Text.Length < 1) mensaje += "Falta la dirección de partida \n";

            if (mensaje.Length > 0)
            {
                MessageBox.Show("Excepción en el documento: " + mensaje);
                return false;
            }

            if (malla.IsCurrentCellDirty)
            {
                malla.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }

            // Forzar que el BindingSource termine la edición actual
            mallaBindingSource.EndEdit();

            // Contar filas con productos reales
            int filasConProductos = 0;
            DataTable dtMalla = mallaBindingSource.DataSource as DataTable;

            if (dtMalla == null)
            {
                MessageBox.Show("Error: No se ha inicializado la tabla de productos");
                return false;
            }

            // Buscar la columna de código (sin importar mayúsculas/minúsculas)
            DataColumn columnaCodigo = null;
            foreach (DataColumn col in dtMalla.Columns)
            {
                if (col.ColumnName.ToLower() == "tra_codigo")
                {
                    columnaCodigo = col;
                    break;
                }
            }

            if (columnaCodigo == null)
            {
                string columnas = "";
                foreach (DataColumn col in dtMalla.Columns)
                {
                    columnas += col.ColumnName + ", ";
                }
                MessageBox.Show("Error: No se encontró la columna de código. Columnas disponibles: " + columnas);
                return false;
            }

            // Contar productos válidos
            for (int i = 0; i < dtMalla.Rows.Count; i++)
            {
                DataRow row = dtMalla.Rows[i];
                object codigo = row[columnaCodigo];

                // Ignorar filas vacías (sin código)
                if (codigo != DBNull.Value && codigo != null && !string.IsNullOrWhiteSpace(codigo.ToString().Trim()))
                {
                    filasConProductos++;
                }
            }

            if (filasConProductos < 1)
            {
                MessageBox.Show("No se ha registrado ningún producto válido.\n\n" +
                               "Total filas: " + dtMalla.Rows.Count + "\n" +
                               "Productos válidos: " + filasConProductos + "\n\n" +
                               "Presione F2 en la columna Código para buscar un producto.",
                               "Validación de productos",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Warning);
                return false;
            }

            if (util.ExisteDocumentoGrabado(ref datADCDOC, ref propiedadesDoc, datosEmpresa.strConxAdcom, idClaveDoc) == true)
            {
                MessageBox.Show("ERROR: Ya existe un documento igual registrado", "Grabar documento", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void validaComprobantesElectronicos()
        {
            //tieneComprobantesElectronicos = File.Exists(Emp.PatAppl + @"DaxFelec.exe");
        }

        #region manejo malla

        private void malla_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            foreach (DataGridViewRow rr in malla.Rows)
            {
                rr.HeaderCell.Value = (rr.Index + 1).ToString();
            }
        }

        protected override Boolean ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (malla.Focused == false && malla.IsCurrentCellInEditMode == false) return false;

            if (keyData == Keys.F2 || keyData == Keys.F3 || keyData == Keys.F8 || keyData == Keys.F11 || keyData == Keys.Return)
            {
                funcionesEspeciales(ref keyData, malla);
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private Boolean funcionesEspeciales(ref Keys keyData, DataGridView malla)
        {
            Boolean resp = true;
            malla.EndEdit();
            DataGridViewCell cell = malla.CurrentCell;
            string dato = cell.Value != null ? cell.Value.ToString() : "";
            string nombreCelda = cell.OwningColumn.Name.ToUpper();

            if (keyData == Keys.F8 && cell.ReadOnly == false && malla.Columns[cell.ColumnIndex].Name.ToUpper() != "TRA_CODIGO")
            {
                if (cell.RowIndex > 0) cell.Value = malla.Rows[cell.RowIndex - 1].Cells[cell.ColumnIndex].Value;
            }
            else if (keyData == Keys.F3 && cell.ValueType != null && cell.ValueType.Name.ToUpper() == "DATETIME")
            {
                cell.Value = docUtils.DaxNow().ToShortDateString();
            }
            else
            {
                switch (nombreCelda)
                {
                    case "TRA_CODIGO":
                        if (dato != ".")
                        {
                            try { this.mallaArticulo.bodega = cmbBodega.SelectedValue != null ? cmbBodega.SelectedValue.ToString() : ""; } catch { }
                            this.mallaArticulo.digCostos = valoresPredefinidosEmpresa.nroDigitosEnCostos;
                            this.mallaArticulo.digPrecios = valoresPredefinidosEmpresa.nroDigitosEnPrecios;
                            this.mallaArticulo.fechaDoc = Convert.ToDateTime(txtfecha.Text);
                            this.mallaArticulo.impIva = 0;
                            this.mallaArticulo.codCliente = codDestinatario;
                            this.mallaArticulo.sucursal = datosEmpresa.suc;
                            this.mallaArticulo.tipoDoc = cmbDocumento.SelectedValue.ToString();
                            this.mallaArticulo.numDoc = txtnumero.Text;

                            if (keyData == Keys.F2)
                            {
                                dato = this.mallaArticulo.BuscarArticuloSimple(cell.Value.ToString());
                                if (!string.IsNullOrEmpty(dato))
                                {
                                    DataGridViewRow currentRow = malla.CurrentRow;
                                    bool cargado = this.mallaArticulo.CargarArticuloRem(dato, currentRow);

                                    if (cargado)
                                    {
                                        malla.CommitEdit(DataGridViewDataErrorContexts.Commit);

                                        // Obtener DataTable desde BindingSource
                                        DataTable dt = mallaBindingSource.DataSource as DataTable;
                                        if (dt == null) return true;

                                        // Buscar fila vacía EXCLUYENDO la fila actual
                                        int nextRow = -1;
                                        for (int i = 0; i < dt.Rows.Count; i++)
                                        {
                                            if (i == currentRow.Index) continue;
                                            var valor = dt.Rows[i]["tra_codigo"];
                                            if (valor == DBNull.Value || string.IsNullOrWhiteSpace(valor.ToString()))
                                            {
                                                nextRow = i;
                                                break;
                                            }
                                        }

                                        // Si no hay fila vacía, usar BindingSource.AddNew() para mantener estado
                                        if (nextRow == -1)
                                        {
                                            mallaBindingSource.AddNew();
                                            nextRow = mallaBindingSource.Count - 1;
                                            malla.Refresh();
                                        }

                                        // Mover cursor con validación robusta
                                        if (nextRow != -1 && nextRow < malla.Rows.Count)
                                        {
                                            try
                                            {
                                                malla.ClearSelection();
                                                if (malla.Rows[nextRow].Cells["tra_codigo"] != null)
                                                {
                                                    malla.CurrentCell = malla.Rows[nextRow].Cells["tra_codigo"];
                                                    System.Threading.Thread.Sleep(30);
                                                    Application.DoEvents();
                                                    malla.BeginEdit(true);
                                                }
                                            }
                                            catch (Exception ex)
                                            {
                                                malla.Focus();
                                                SendKeys.SendWait("{TAB}");
                                            }
                                        }

                                        keyData = Keys.Cancel;
                                        return true;
                                    }
                                    else
                                    {
                                        cell.Value = "";
                                        keyData = Keys.Cancel;
                                    }
                                }
                                else
                                {
                                    keyData = Keys.Cancel;
                                }
                            }
                        }
                        break;
                    default:
                        if (keyData == Keys.F2)
                        {
                            BusquedasDetalleDocumentos.BuscarValor(cell, nombreCelda);
                        }
                        break;
                }
            }

            if (cell.Value == null || cell.Value.ToString() == "")
            {
                keyData = Keys.Cancel;
            }
            return resp;
        }
        #endregion manejo malla

        private void txtMotivoTransporte_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2) { CBuscador(ref txtMotivoTransporte, "MotivoTraslado"); }
        }

        private void CBuscador(ref TextBox lcod, string tipo)
        {
            string ElNombre = "";
            string ElCodigo = "";
            Syscod.ManSysnetClass Buscod = new Syscod.ManSysnetClass();
            ElCodigo = Buscod.BuscarReferencia(ref tipo, ref ElCodigo, ref ElNombre);
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
            btnAgrupa.Enabled = btnBarras.Checked;
        }

        private void btnAgrupa_Click(object sender, EventArgs e)
        {
            mallaArticulo.AcumularLineasMalla(ref malla, "tra_codigo", "tra_Cantidad", "");
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
            AuditSis.registrar.registraPreferencia(datosEmpresa.strConxAdcom, datosEmpresa.codEmpresa.ToString(), Environment.MachineName, datosEmpresa.usr, datosEmpresa.sistema, datosEmpresa.suc, "Facturacion", "TipoDoc", cmbDocumento.SelectedValue.ToString());
            AuditSis.registrar.registraPreferencia(datosEmpresa.strConxAdcom, datosEmpresa.codEmpresa.ToString(), Environment.MachineName, datosEmpresa.usr, datosEmpresa.sistema, datosEmpresa.suc, "Facturacion", "Bodega", cmbBodega.SelectedValue.ToString());
        }

        private void recordarOpciones()
        {
            memTipoDoc = AuditSis.registrar.obtenerPreferencia(datosEmpresa.strConxAdcom, datosEmpresa.codEmpresa.ToString(), datosEmpresa.usr, datosEmpresa.sistema, datosEmpresa.suc, "Facturacion", "TipoDoc");
            memBodega = AuditSis.registrar.obtenerPreferencia(datosEmpresa.strConxAdcom, datosEmpresa.codEmpresa.ToString(), datosEmpresa.usr, datosEmpresa.sistema, datosEmpresa.suc, "Facturacion", "Bodega");
        }

        private void CargarPredefinidosDocumento()
        {
            propiedadesDoc = new sesSys.OpcDoc();
            propiedadesDoc.Cargar(ref idDocumentoActual.Tipo, ref idDocumentoActual.Sucursal);
            accesosLocalizados.iniciar(datosEmpresa.codEmpresa, datosEmpresa.usr, datosEmpresa.strConxSyscod);
            accesosLocalizados.cargarAccesoDoc(idDocumentoActual.Tipo);
            RegistrarAccesosLocalizadosDocumento();
        }

        private void RegistrarAccesosLocalizadosDocumento()
        {
            if (accesosLocalizados.sinRegistro) return;

            btnNuevo.Enabled = accesosLocalizados.Crear;
            btnAbre.Enabled = accesosLocalizados.Consultar;
            btnGraba.Enabled = (operacionEnCurso == nuevoRegistro ? accesosLocalizados.Crear : accesosLocalizados.Modificar);
            btnRegistra.Enabled = btnGraba.Enabled && accesosLocalizados.Imprimir;
            btnElimina.Enabled = accesosLocalizados.Eliminar;
            btnAnula.Enabled = accesosLocalizados.Anular;
            btnCopia.Enabled = accesosLocalizados.Crear;
            BtnEnviar.Enabled = accesosLocalizados.Imprimir;
            btnImprimir.Enabled = accesosLocalizados.Imprimir;
            btnExportaExcel.Enabled = accesosLocalizados.Imprimir;
            btnEnviarCorreo.Enabled = accesosLocalizados.Imprimir;

            btnBarras.Enabled = accesosLocalizados.DetalleProducto;
            btnAgrupa.Enabled = false;

            txtnumero.Enabled = accesosLocalizados.NúmeroDocumento;
            txtNroID.Enabled = accesosLocalizados.NúmeroDocumento;
            txtfecha.Enabled = accesosLocalizados.FechaDocumento;

            cmbBodega.Enabled = accesosLocalizados.Bodega;
            if (!string.IsNullOrEmpty(accesosLocalizados.BodegaFija) && cmbBodega != null)
            {
                try { cmbBodega.SelectedValue = accesosLocalizados.BodegaFija; }
                catch { }
                cmbBodega.Enabled = false;
            }

            cmbDocumento.Enabled = (operacionEnCurso == sinOperacion);
            malla.Enabled = (operacionEnCurso != sinOperacion);

            if (!accesosLocalizados.Modificar && operacionEnCurso == modificandoRegistro)
            {
                txtMotivoTransporte.Enabled = false;
                txtdireccionPartida.Enabled = false;
                txtRuta.Enabled = false;
                txtPlaca.Enabled = false;
                txtDescripcion.Enabled = false;
                txtCodigoEstabDestino.Enabled = false;
                txtDocAduaneroUnico.Enabled = false;
                txtnumeroSustento.Enabled = false;
                cmbDocumentoSustento.Enabled = false;
                btnBuscaDocSustento.Enabled = false;
                txtCedDestinatario.Enabled = false;
                txtNombreDestinatario.Enabled = false;
                txtDireccionDestinatario.Enabled = false;
                btnBuscaDestinatario.Enabled = false;
                txtcedulaTransportista.Enabled = false;
                txtnombreTransportista.Enabled = false;
                btnBuscaTransportista.Enabled = false;
                txtfechaini.Enabled = false;
                txtFechafin.Enabled = false;
            }

            if (esSoloConsulta)
            {
                DeshabilitarTodoParaConsulta();
            }

            if (datADCDOC != null && datADCDOC.Doc_Estado == 0 && operacionEnCurso == modificandoRegistro)
            {
                btnGraba.Enabled = false;
                btnRegistra.Enabled = false;
                btnElimina.Enabled = false;
                btnCopia.Enabled = false;
                malla.Enabled = false;
                txtnumero.Enabled = false;
                txtNroID.Enabled = false;
                txtfecha.Enabled = false;
            }
        }

        private void DeshabilitarTodoParaConsulta()
        {
            btnNuevo.Enabled = false;
            btnGraba.Enabled = false;
            btnRegistra.Enabled = false;
            btnElimina.Enabled = false;
            btnAnula.Enabled = false;
            btnCopia.Enabled = false;
            BtnEnviar.Enabled = false;
            btnBarras.Enabled = false;
            btnAgrupa.Enabled = false;
            txtnumero.Enabled = false;
            txtNroID.Enabled = false;
            txtfecha.Enabled = false;
            cmbDocumento.Enabled = false;
            cmbBodega.Enabled = false;
            malla.Enabled = false;
            txtMotivoTransporte.Enabled = false;
            txtdireccionPartida.Enabled = false;
            txtRuta.Enabled = false;
            txtPlaca.Enabled = false;
            txtDescripcion.Enabled = false;
            txtCodigoEstabDestino.Enabled = false;
            txtDocAduaneroUnico.Enabled = false;
            txtnumeroSustento.Enabled = false;
            cmbDocumentoSustento.Enabled = false;
            btnBuscaDocSustento.Enabled = false;
            txtCedDestinatario.Enabled = false;
            txtNombreDestinatario.Enabled = false;
            txtDireccionDestinatario.Enabled = false;
            btnBuscaDestinatario.Enabled = false;
            txtcedulaTransportista.Enabled = false;
            txtnombreTransportista.Enabled = false;
            btnBuscaTransportista.Enabled = false;
            txtfechaini.Enabled = false;
            txtFechafin.Enabled = false;
        }

        private void LlenarIdDocumento(ref idDocumento docmtoActual)
        {
            docmtoActual.Sucursal = datosEmpresa.suc;
            docmtoActual.Tipo = cmbDocumento.SelectedValue.ToString();
            docmtoActual.fecha = txtfecha.Value;
            try { docmtoActual.numero = Convert.ToDouble(txtnumero.Text); }
            catch { docmtoActual.numero = 0; }
        }

        private void txtfecha_ValueChanged(object sender, EventArgs e) { }
        private void mensajesDocumento_Click(object sender, EventArgs e) { }

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

        // Evento DataSourceChanged optimizado
        private void malla_DataSourceChanged(object sender, EventArgs e)
        {
            if (malla.DataSource is DataTable dt &&
                dt.Rows.Count > 0 &&
                !malla.IsCurrentCellInEditMode)
            {
                DataRow ultimaFila = dt.Rows[dt.Rows.Count - 1];
                var ultimoCodigo = ultimaFila["tra_codigo"];

                if (ultimoCodigo != DBNull.Value && !string.IsNullOrWhiteSpace(ultimoCodigo.ToString()))
                {
                    bool hayFilaVaciaFinal = false;
                    if (dt.Rows.Count > 1)
                    {
                        var penultimo = dt.Rows[dt.Rows.Count - 1]["tra_codigo"];
                        hayFilaVaciaFinal = (penultimo == DBNull.Value || string.IsNullOrWhiteSpace(penultimo.ToString()));
                    }

                    if (!hayFilaVaciaFinal)
                    {
                        dt.Rows.Add(dt.NewRow());
                        malla.Refresh();
                    }
                }
            }
        }
    }
}