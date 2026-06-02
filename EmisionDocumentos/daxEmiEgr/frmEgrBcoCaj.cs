using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassDoc;
using DattCom;
using static DaxClasificadores.ClasificadorMalla;

namespace DctosEmi
{
    public partial class frmEgrBcoCaj : Form
    {

        internal sesSys.OpcDoc propiedadesDoc = new sesSys.OpcDoc();
        directMnt.DirectorioAlex opalex = new directMnt.DirectorioAlex();
        internal AdcDoc datADCDOC;
        internal daxAccs.propiedadesDaxAuto accesosLocalizados = new daxAccs.propiedadesDaxAuto();
        DataTable dtDetalleDocumento = new DataTable();
        DatosDocBancos datosBanco = new DatosDocBancos();
        string claseDocDefault = "EGR";
        string tipoDocDefault = "EGR";
        string tipoDeCtaBancaria = "";
        bool iniciaConNuevoDOc = false;
        internal Boolean esSoloConsulta = false;
        internal Boolean CambiaAbancos = false;
        private static readonly idDocumento idDocumento = new idDocumento();
        internal idDocumento idDocumentoActual = idDocumento;
        idDocumento idDocumentoSoporte = idDocumento;
        idDocumento idDocumentoParaGenerar = idDocumento;
        DocPendientes.ListDocAplican listaDocAplicados = new DocPendientes.ListDocAplican();
        daxContaDoc.AsientosContables asientosContables = new daxContaDoc.AsientosContables();  
        //Boolean saltarEventoNumero = false;
        //Boolean saltaEventosMalla = false;

        internal int operacionEnCurso = 0; // 0 sin operacion delcarada, 1 nuevo registro, 2 modificando registro
        internal int sinOperacion = 0;
        internal int nuevoRegistro = 1;
        internal int modificandoRegistro = 2;

        string memTipoDoc = "";
        string memVendedor = "";

        internal Boolean EsIngreso = false;
        internal bool EsCliente = false;
        internal bool EsProveedor = false;
        internal bool Estransferencia = false;
        internal string TipoConcptoBusca = "";
        public frmEgrBcoCaj(string clasdef, string tipdef, bool nuevo = false, Boolean esConsulta = false, Boolean generarFactura = false, Boolean desdeEstdoCta = false, idDocumento idDocViene = null)
        {
            InitializeComponent();
            iniciaConNuevoDOc = nuevo;
            if (idDocViene == null) idDocViene = idDocumento;
            if (idDocViene.idClave > 0 && esConsulta)
            {
                idDocumentoActual = idDocViene;
            }
            else
            {
                idDocumentoActual.Sucursal = datosEmpresa.sucursal;
                idDocumentoActual.Tipo = tipoDocDefault;
                idDocumentoActual.familia = claseDocDefault;
            }
            CargarValoresIniciales();
        }

        private void CargarValoresIniciales()
        {
            recordarOpciones();
            txtfecha.Value = DctosEmi.docUtils.DaxNow();
            LlenarCombos();
            CargarPredefinidosDocumento();
            if (idDocumentoActual.idClave != 0)
            {
                cargarDatosEgreso(idDocumentoActual);
            }
            else if (idDocumentoParaGenerar.idClave > 0)
            {
                iniciarNuevoDocumento();
                //copiarDocumento(idDocumentoParaGenerar, true);
            }
            else
            {
                if (iniciaConNuevoDOc) iniciarNuevoDocumento();
            }
            AutorizacionesDoc.prepararBotones(this);
        }

        private void LlenarCombos()
        {
            DaxCombobx.CargCmbBox cmb = new DaxCombobx.CargCmbBox();
            cmb.DaxCombosDoc("EGRINGVICVECNDBNCB", "", false, datosEmpresa.strConxAdcom, ref cmbDocumento);
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
            if (cmbVendedor.Items.Count > 0)
            {
                if (memVendedor.Length > 0) { cmbVendedor.SelectedValue = memVendedor; } else { cmbVendedor.SelectedIndex = 0; }
            }
        }

        private void iniciarNuevoDocumento()
        {
            limpiarDatos();
            llenarMalla("", "", 0);
            txtfecha.Value = DctosEmi.docUtils.DaxNow();
            controlNumeracion cnum = new controlNumeracion();
            idDocumentoActual = new idDocumento
            {
                familia = propiedadesDoc.TipoDoc,
                fecha = txtfecha.Value,
                numero = Convert.ToDouble("0" + txtnumero.Text),
                Serie = "",
                Sucursal = datosEmpresa.suc,
                Tipo = cmbDocumento.SelectedValue.ToString()
            };
            txtnumero.Text = cnum.NumeroMayor(idDocumentoActual, "", "", "", datosEmpresa.strConxAdcom).ToString();
            idDocumentoActual.numero = Convert.ToDouble("0" + txtnumero.Text);
            operacionEnCurso = 1;
            AutorizacionesDoc.prepararBotones(this);
        }
        private void llenarMalla(string sucursal, string opcDoc, double idclaveDoc)
        {
            dtDetalleDocumento = SqlDatos.leerTablaAdcom(datosBanco.armarSqlLecturaEgreBco(sucursal, opcDoc, idclaveDoc));
            if (dtDetalleDocumento == null) return;
            malla.DataSource = dtDetalleDocumento;
            dtDetalleDocumento.Rows.Add(dtDetalleDocumento.NewRow());
            OperacionesMallaEgr dcut2 = new OperacionesMallaEgr();
            dcut2.DiseñarMallaEgresoBancos(malla, propiedadesDoc);
            dcut2 = null;


            daxConta.reglCtb dxCtb = new daxConta.reglCtb();
            ClassDoc.Servicios OpServicio = new Servicios(datosEmpresa.strConxAdcom);
            string servicioAnterior = "";
            string servicioActual = "";
            string bancoDestino = "";
            //try { bancoDestino = cmbCtasBacoDestino.SelectedValue.ToString(); } catch { }
            if (cmbCtasBacoDestino.SelectedValue != null)
            {
                bancoDestino = cmbCtasBacoDestino.SelectedValue.ToString();
            }
            else
            {
                bancoDestino = ""; // o algún valor por defecto
            }

            foreach (DataGridViewRow row in malla.Rows)
            {
                servicioActual = row.Cells["CodConcepto"].Value.ToString();
                //foreach (DataGridViewRow row in malla.Rows)
                //{
                    if (servicioAnterior != servicioActual)
                    {
                        OpServicio = ClassDoc.Servicios.Buscar(" sev_codigo = '" + servicioActual + "'");
                    }
                    if (OpServicio != null)
                    {
                        servicioAnterior = servicioActual;
                        dxCtb.VerificarClasificadoresContablesServicios("T", row.Cells["CodConcepto"].Value.ToString(), row, OpServicio, propiedadesDoc, txtCodper.Text, bancoDestino);
                    }
                //}
            }
        }

        private void limpiarDatos()
        {
            txtnumero.Enabled = true;
            datADCDOC = new AdcDoc(datosEmpresa.strConxAdcom);
            txtCodper.Text = "";
            txtDetalle.Text = "";
            txtnombrecliente.Text = "";
            txtnumero.Text = "";
            mensajesDocumento.Text = "";
            idDocumentoActual.idClave = 0;
            idDocumentoActual.fecha = txtfecha.Value;
            idDocumentoActual.numero = 0;
            txtCodBanco.Text = "";
            txtCtaBanco.Text = "";
            txtNombreBanco.Text = "";
            TxtNroCheque.Text = "";
            txtNroLote.Text = "";
            TxtNroCobranza.Text = "";

            idDocumentoSoporte = idDocumento;
            dtDetalleDocumento = new DataTable();
            malla.DataSource = null;
            edTotal.Text = "0.00";
            QuitarCuentasDestino(false);
            operacionEnCurso = 0;
            AutorizacionesDoc.prepararBotones(this);
        }
        private void CargarPredefinidosDocumento()
        {
            idDocumentoActual.Tipo = cmbDocumento.SelectedValue.ToString();
            propiedadesDoc = new sesSys.OpcDoc();
            propiedadesDoc.Cargar(ref idDocumentoActual.Tipo, ref idDocumentoActual.Sucursal);
            idDocumentoActual.familia = propiedadesDoc.TipoDoc;
            accesosLocalizados.iniciar(datosEmpresa.codEmpresa, DatosUsuario.codigo, datosEmpresa.strConIniSis);
            accesosLocalizados.cargarAccesoDoc(idDocumentoActual.Tipo);
            AutorizacionesDoc.HabilitarOpcionesDocumento(this);
            QuitarCuentasDestino(false);
        }

        private bool cargarDatosEgreso(idDocumento IdDoc)
        {
            Boolean resp = false;
            datADCDOC = new AdcDoc(datosEmpresa.strConxAdcom);
            if (IdDoc.idClave != 0)
            {
                datADCDOC = AdcDoc.Buscar(" doc_sucursal = '" + IdDoc.Sucursal + "' and opc_documento ='" + IdDoc.Tipo + "' and idclavedoc = " + IdDoc.idClave.ToString());
            }
            else if (IdDoc.numero > 0)
            {
                datADCDOC = AdcDoc.Buscar(" doc_sucursal = '" + IdDoc.Sucursal + "' and opc_documento ='" + IdDoc.Tipo + "' and doc_numero = " + IdDoc.numero);
            }
            if (datADCDOC != null)
            {
                resp = true;
                mostrarDatosBanco(datADCDOC.doc_BancoOrigen);
                datosBanco.MoverDatosAcontroles(this);
                if (CambiaAbancos) { llenarComboCuenta(txtCodper.Text); }
                else { QuitarCuentasDestino(false); }
                llenarMalla(idDocumentoActual.Sucursal, idDocumentoActual.Tipo, idDocumentoActual.idClave);
                if (Convert.ToInt32(datADCDOC.Doc_Estado) == 0) mensajesDocumento.Text = "DOCUMENTO ANULADO : " + datADCDOC.MotivoAnulacion;
                edTotal.Text = OperacionesMallaEgr.Totalizar(malla);
                operacionEnCurso = modificandoRegistro;
                AutorizacionesDoc.prepararBotones(this);
                resp = true;
                txtnumero.Enabled = false;
            }
            return resp;
        }

        public void mostrarDatosBanco(string abreviaturaBanco)
        {
            if (abreviaturaBanco == null) return;
            string consulta = " select *  from AdcCtaBco where Bco_Codigo = '" + abreviaturaBanco.Trim() + "' ";
            DataTable dato = DattCom.SqlDatos.leerTablaAdcom(consulta);
            if (dato.Rows.Count > 0)
            {
                txtCodBanco.Text = Convert.ToString(dato.Rows[0]["Bco_Codigo"]).Trim();
                txtCtaBanco.Text = Convert.ToString(dato.Rows[0]["Bco_NumCta"]).Trim();
                txtNombreBanco.Text = dato.Rows[0]["Bco_Nombre"].ToString().Trim();
                tipoDeCtaBancaria = dato.Rows[0]["Bco_TipoCta"].ToString().Trim();
                if (TxtNroCheque.Visible) PonerNumeroCheque();

            }
            dato.Dispose();
        }
        private void CargarDocmtosAplicar(string codCliente)
        {
            if (codCliente == "") codCliente = "0";
            DateTime fechInicio = datosEmpresa.UltimoCierreAnual.AddDays(1);
            DocPendientes.frmDocPndt prog = new DocPendientes.frmDocPndt(listaDocAplicados, codCliente, txtnombrecliente.Text, idDocumentoActual, "", 0, "C", false, fechInicio, txtfecha.Value);
            prog.ShowDialog();
            if (listaDocAplicados.ListaDocAplican.Count > 0)
            {
                OperacionesMallaEgr opm = new OperacionesMallaEgr();
                opm.DocumentosEscojidosDeColeccionAmalla(malla, listaDocAplicados, malla.CurrentRow.Cells["CodConcepto"].Value.ToString());
                listaDocAplicados.ListaDocAplican.Clear();
            }
        }

        private void DetalleCostos(string codCliente)
        {
            if (codCliente == "") codCliente = "0";
            DateTime fechInicio = datosEmpresa.UltimoCierreAnual.AddDays(1);
            DocPendientes.frmDocPndt prog = new DocPendientes.frmDocPndt(listaDocAplicados, codCliente, txtnombrecliente.Text, idDocumentoActual, "", 0, "C", false, fechInicio, txtfecha.Value);
            prog.ShowDialog();
            if (listaDocAplicados.ListaDocAplican.Count > 0)
            {
                OperacionesMallaEgr opm = new OperacionesMallaEgr();
                opm.DocumentosEscojidosDeColeccionAmalla(malla, listaDocAplicados, malla.CurrentRow.Cells["CodConcepto"].Value.ToString());
                listaDocAplicados.ListaDocAplican.Clear();
            }
        }

        private void llenarComboCuenta(string Banco)
        {
            string ssql = "Select * from AdcCtaBco where Bco_CodAlex = '" + Banco + "'";
            cmbCtasBacoDestino.DataSource = SqlDatos.leerTablaAdcom(ssql);
            cmbCtasBacoDestino.ValueMember = "Bco_NumCta";
            cmbCtasBacoDestino.DisplayMember = "Bco_NumCta";
            QuitarCuentasDestino(true);
        }
        private void QuitarCuentasDestino(bool activar)
        {
            cmbCtasBacoDestino.Visible = activar;
            labBancoDestino.Visible = activar;
            CambiaAbancos = activar;
        }
        private void PonerNumeroCheque()
        {
            string cod = "select isnull(ultimonumero,0) as ultimonumero from AdcDocNUM where ID_LUGAR ='" + txtCodBanco.Text + "' and ID_DOCUMENTO='" + cmbDocumento.SelectedValue.ToString() + "'";
            DataTable dt = SqlDatos.leerTablaAdcom(cod);
            if (dt.Rows.Count == 0)
            {
                TxtNroCheque.Text = "1";
            }
            else
            {
                TxtNroCheque.Text = (Convert.ToInt32(dt.Rows[0]["ultimonumero"]) + 1).ToString();
            }
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
                    //DctosEmi.fijarNumeroDocumento fijnum = new DctosEmi.fijarNumeroDocumento();

                    //datADCDOC.Doc_numero = Convert.ToDecimal(fijnum.nroDeDocumento(propiedadesDoc.tablaDatosDoc, propiedadesDoc.CodDuplica, Convert.ToBoolean(propiedadesDoc.NroAutomatico), Convert.ToDouble(txtnumero.Text), datosEmpresa.strConxAdcom, datosEmpresa.suc, cmbDocumento.SelectedValue.ToString(), txtnumero.Text, "", txtCodper.Text, ""));
                    if (datADCDOC.Doc_numero == 0) return false;
                    res = datADCDOC.Crear();
                    if (res.Substring(0, 3) != "ERR")
                    {
                        txtnumero.Text = datADCDOC.Doc_numero.ToString();
                        idDocumentoActual.idClave = Convert.ToDouble(datADCDOC.IdClaveDoc);
                        idDocumentoActual.numero = Convert.ToDouble(datADCDOC.Doc_numero);
                        datosBanco.GuardarDetalleDoc(datADCDOC, malla, "");
                        datosBanco.GuardarNumeroCheque(idDocumentoActual.Tipo, txtCodBanco.Text, TxtNroCheque.Text);
                        string tipDoc = cmbDocumento.SelectedValue.ToString();
//                        string tipBan = "";
                        //if (idDocumentoActual.idClave != 0) propiedadesDoc.GuardarNumero(datosEmpresa.suc, tipDoc, tipBan, "", "", DatosUsuario.codigo, "");
                        datosBanco.GuardarDetalleDoc(datADCDOC, malla, "");
                        if (propiedadesDoc.SNContabilizar != 0)
                        {
                            if (asientosContables.ListDetalleContab.Count > 0)
                            {
                                asientosContables.GrabarDetalleContable(idDocumentoActual);
                            }
                            else
                            {
                                daxContaDoc.contabilizaDocumento ctb = new daxContaDoc.contabilizaDocumento();
                                asientosContables = ctb.GenerarContabilidadDocumento(datADCDOC, (DataTable)malla.DataSource, propiedadesDoc, null, "");
                                asientosContables.GrabarDetalleContable( idDocumentoActual);
                            }                            
                        }
                        AuditSis.registrar.registraEventoDoc(datosEmpresa.strConIniSis, datosEmpresa.codEmpresa.ToString(), datosEmpresa.usr, "MDD", Environment.MachineName, AuditSis.registrar.EvntCrear, idDocumentoActual.Sucursal, idDocumentoActual.Tipo, idDocumentoActual.numero.ToString(), datADCDOC.Doc_valor.ToString());
                    }
                }
                else
                {
                    res = datADCDOC.Actualizar();
                    if (res.Substring(0, 3) != "ERR")
                    {
                        datosBanco.GuardarDetalleDoc(datADCDOC, malla, "");
                        datosBanco.GuardarNumeroCheque(idDocumentoActual.Tipo, txtCodBanco.Text, TxtNroCheque.Text);
                        if (propiedadesDoc.SNContabilizar  != 0)
                        {
                            if (asientosContables.ListDetalleContab.Count > 0)
                            {
                                asientosContables.GrabarDetalleContable(idDocumentoActual);
                            }
                            else
                            {
                                daxContaDoc.contabilizaDocumento ctb = new daxContaDoc.contabilizaDocumento();
                                asientosContables = ctb.GenerarContabilidadDocumento(datADCDOC, (DataTable)malla.DataSource, propiedadesDoc, null, "");
                                asientosContables.GrabarDetalleContable(idDocumentoActual);
                            }
                        }
                        AuditSis.registrar.registraEventoDoc(datosEmpresa.strConIniSis, datosEmpresa.codEmpresa.ToString(), datosEmpresa.usr, "MDD", Environment.MachineName, AuditSis.registrar.EvntModifica, idDocumentoActual.Sucursal, idDocumentoActual.Tipo, idDocumentoActual.numero.ToString(), datADCDOC.Doc_valor.ToString());
                    }

                }
            }
            catch (Exception ee)
            {
                res = "ERR " + ee.Message;
            }
            if ((res + "   ").Substring(0, 3) == "ERR")
            {
                MessageBox.Show("EL DOCUMENTO NO FUE GRABADO CORRECTAMENTE \n" + res);
                RESP = false;
            }
            return RESP;
        }
        private void ImpresionesDeldocumento(string OtroFormato = "", bool ImpresionDirecta = false)
        {
            if (accesosLocalizados.NroImpresiones > 0 && accesosLocalizados.NroImpresiones <= datADCDOC.Doc_Adicional1)
            { MessageBox.Show("Ha llegado al límite de impresiones permitidas", "Imprimir documentos", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            ImpresionDocumentosDax.ImprimeDocumentoDoble impProg = new ImpresionDocumentosDax.ImprimeDocumentoDoble(datosEmpresa.nombreBaseIvaret, datosEmpresa.strConxAdcom, datosEmpresa.strConxIvaret, datosEmpresa.strConIniSis, datosEmpresa.strConxDaxpro, datosEmpresa.codEmpresa, datosEmpresa.pathServer);
            int imp = 0;
            if (ImpresionDirecta)
            {
              imp  = impProg.ImpDocFast(idDocumentoActual, "A", OtroFormato, false, true);
            }
            else
            {
                imp = impProg.ImpDoc(idDocumentoActual, "A", OtroFormato, false, false);
            }
            datADCDOC.Doc_Adicional1 = imp;
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
        private string BuscaBeneficiarioAplicacion(string buscador)
        {
            directMnt.BuscaClien directorio = new directMnt.BuscaClien();
            string nombre = "";
            string codigo = directorio.IniBuscaCliOPro("C", false, ref nombre);
            if ((codigo + "").Length > 0)
            {
                malla.CurrentCell.Value = codigo;
                malla.CurrentRow.Cells["NombreImpresion"].Value = nombre;
            }
            directorio.Dispose();
            return codigo;
        }
        private void cargarDatosCliente(string codigo = "")
        {
            if (codigo != "")
            {
                string solocodigo = "";
                Boolean x = false;
                opalex = new directMnt.DirectorioAlex();
                opalex.CargarAlex(ref codigo, ref x, ref solocodigo);
                if (opalex.codigo == null) codigo = ""; else codigo = opalex.codigo;
                if (codigo.Length > 0)
                {
                    txtCodper.Text = opalex.codigo;
                    txtnombrecliente.Text = opalex.NombreImpresion;
                    if (opalex.EsBanco) { llenarComboCuenta(txtCodper.Text); }
                    else { QuitarCuentasDestino(false); }
                }

            }
            if (codigo == "")
            {
                txtCodper.Text = "";
                txtnombrecliente.Text = "";
                opalex = null;
            }
        }
        private void registraOpciones()
        {
            AuditSis.registrar.registraPreferencia(datosEmpresa.strConIniSis, datosEmpresa.codEmpresa.ToString(), datosEmpresa.usr, "ADX", datosEmpresa.suc, "Facturacion", "TipoDoc", cmbDocumento.SelectedValue.ToString());
            if (cmbVendedor.SelectedValue != null) { AuditSis.registrar.registraPreferencia(datosEmpresa.strConIniSis, datosEmpresa.codEmpresa.ToString(), datosEmpresa.usr, "ADX", datosEmpresa.suc, "Facturacion", "Vendedor", cmbVendedor.SelectedValue.ToString()); }
        }
        private void recordarOpciones()
        {
            memTipoDoc = AuditSis.registrar.obtenerPreferencia(datosEmpresa.strConIniSis, datosEmpresa.codEmpresa.ToString(), datosEmpresa.usr, "ADX", datosEmpresa.suc, "Facturacion", "TipoDoc");
            memVendedor = AuditSis.registrar.obtenerPreferencia(datosEmpresa.strConIniSis, datosEmpresa.codEmpresa.ToString(), datosEmpresa.usr, "ADX", datosEmpresa.suc, "Facturacion", "Vendedor");
        }

        #region manejo malla
        protected override Boolean ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (malla.Focused == false && malla.IsCurrentCellInEditMode == false) return false;
            if (malla.IsCurrentCellInEditMode && (keyData == Keys.Up || keyData == Keys.Down || keyData == Keys.Right || keyData == Keys.Left))
            { keyData = Keys.Return; }

            if (keyData == Keys.Return || (keyData >= Keys.F1 && keyData < Keys.F13))
            {
               // DataGridViewCell cell = malla.CurrentCell;
                if (!(malla.IsCurrentCellInEditMode == false && keyData == Keys.Return)) funcionesEspeciales(ref keyData, malla, propiedadesDoc);
                if (keyData != Keys.Return) return true;
                DaxMallaLib.Documentos .MoverCelda (malla,false);
                return true;
            }
            if (keyData == Keys.Delete && malla.Focused) { EliminarLinea(); return true; };
            return false;
        }
        private void malla_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Keys keyData = Keys.Return;
            //DataGridViewCell cell = malla.CurrentCell;
            funcionesEspeciales(ref keyData, malla, propiedadesDoc);
            if (keyData != Keys.Return) return;
            DaxMallaLib.Documentos.MoverCelda(malla,false);
        }
        private Boolean funcionesEspeciales(ref Keys keyData, DataGridView malla, sesSys.OpcDoc opcDocumento)
        {
            Boolean resp = true;
            malla.EndEdit();
            DataGridViewCell cell = malla.CurrentCell;
            string dato = cell.Value.ToString();
            string nombreCelda = cell.OwningColumn.Name.ToUpper();
            //saltaEventosMalla = true;
            if (nombreCelda == "CODCONCEPTO")
            {
                if (keyData == Keys.F2)
                {
                    DaxConceptos.BuscServ buscserv = new DaxConceptos.BuscServ(dato, "C", TipoConcptoBusca, "", "", false, false);
                    dato = buscserv.IniServicio();
                }
                if (dato != "")
                {
                    string bancoDestino = "";
                    //try { bancoDestino = cmbCtasBacoDestino.SelectedValue.ToString(); } catch { }
                    if (cmbCtasBacoDestino.SelectedValue != null)
                    {
                        bancoDestino = cmbCtasBacoDestino.SelectedValue.ToString();
                    }
                    else
                    {
                        bancoDestino = ""; // o algún valor por defecto
                    }
                    datosBanco.CargarConceptoDoc(dato, malla.CurrentRow, opcDocumento, txtCodper.Text, bancoDestino);
                }
            }
            else if ((nombreCelda == "APL_CODBENEF" || nombreCelda == "NOMBREIMPRESION") && keyData == Keys.F2 && txtCodper.Text == "0")
            {
                if ((Convert.ToInt16(malla.CurrentRow.Cells["tra_Ventas"].Value) != 0 || Convert.ToInt16(malla.CurrentRow.Cells["tra_Compras"].Value) != 0) && Convert.ToBoolean(malla.CurrentRow.Cells["tra_EsAnticipo"].Value) == false)
                {
                    dato = BuscaBeneficiarioAplicacion(dato);
                    if (dato.Length > 0) CargarDocmtosAplicar(dato);
                }
            }
            else if (nombreCelda == "APL_VALORAPL" && keyData == Keys.F2 && txtCodper.Text.Length > 0)
            {
                //if ((Convert.ToInt16(malla.CurrentRow.Cells["tra_Ventas"].Value) != 0 || Convert.ToInt16(malla.CurrentRow.Cells["tra_Compras"].Value) != 0) && Convert.ToBoolean(malla.CurrentRow.Cells["tra_EsAnticipo"].Value) == false)
                var ventasObj = malla.CurrentRow.Cells["tra_Ventas"].Value;
                var comprasObj = malla.CurrentRow.Cells["tra_Compras"].Value;
                var esAnticipoObj = malla.CurrentRow.Cells["tra_EsAnticipo"].Value;
                var esPagoObj = malla.CurrentRow.Cells["esPago"].Value;

                int ventas = (ventasObj == DBNull.Value) ? 0 : Convert.ToInt16(ventasObj);
                int compras = (comprasObj == DBNull.Value) ? 0 : Convert.ToInt16(comprasObj);
                bool esAnticipo = (esAnticipoObj == DBNull.Value) ? false : Convert.ToBoolean(esAnticipoObj);
                bool esPago = (esPagoObj == DBNull.Value) ? false : Convert.ToBoolean(esPagoObj);

                if ((ventas != 0 || compras != 0) && !esAnticipo || esPago)
                { CargarDocmtosAplicar(txtCodper.Text); }
            }
            else if (nombreCelda == "TRA_costo".ToUpper() || nombreCelda == "TRA_centroproduccion".ToUpper() || nombreCelda == "TRA_centrodistribucion".ToUpper() || nombreCelda == "TRA_Proyecto".ToUpper() || nombreCelda == "TRA_directorio".ToUpper() || nombreCelda == "TRA_empleado".ToUpper())
            {
                {
                    DaxClasificadores.ClasificadorMalla cm = new DaxClasificadores.ClasificadorMalla();
                    if (cm.ClasificadorValidoEnConcepto(cmbDocumento.SelectedValue.ToString(), malla.Rows[cell.RowIndex].Cells["CodConcepto"].Value.ToString(), cell.OwningColumn.HeaderText, true) == false)
                    { dato = ""; return false; }

                    string origen = datosBanco.origenClasificador(cell.OwningColumn.HeaderText);
                    if (keyData == Keys.F4)
                    {
                        ClasificadoresMallas clasmalla = new ClasificadoresMallas();
                        DaxClasificadores.FrmDistrbuirCosto prog = new DaxClasificadores.FrmDistrbuirCosto(clasmalla, malla.Columns[nombreCelda].HeaderText, origen, "E", Convert.ToDouble(edTotal.Text), 0, true, false);
                        clasmalla = prog.iniciarDistribucionCostos();
                        prog.Dispose();
                        if (clasmalla.ColClasificadoresMalla.Count > 0)
                        {
                            OperacionesMallaEgr opm = new OperacionesMallaEgr();
                            opm.ClasificadoresEscojidosDeColeccionAmalla(malla, clasmalla, malla.Rows[cell.RowIndex].Cells["CodConcepto"].Value.ToString(), nombreCelda);
                        }
                    }
                    else if (keyData == Keys.F2)
                    {
                        if (origen == "generales")
                        {
                            string nombreRef = "";
                            string CodRef = "";
                            Syscod.frmBuscarTipoRef progg = new Syscod.frmBuscarTipoRef();
                            cell.Value = progg.BuscarTipoRef(malla.Columns[nombreCelda].HeaderText, ref CodRef, ref nombreRef);
                            progg = null;
                        }
                        else if (origen == "directorio")
                        {
                            string nombre = "";
                            directMnt.BusDirectorio PROGdir = new directMnt.BusDirectorio();
                            cell.Value = PROGdir.BusDirect("", "", ref nombre, "", "E", "N");
                            PROGdir = null;
                        }
                    }
                }
            }
            if (cell.Value != null && cell.Value.ToString() != "") { keyData = Keys.Return; } else { keyData = Keys.Cancel; }
            //saltaEventosMalla = false;
            edTotal.Text = OperacionesMallaEgr.Totalizar(malla);
            return resp;
        }

        private void malla_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            //saltaEventosMalla = true;
            foreach (DataGridViewRow rr in malla.Rows)
            {
                rr.HeaderCell.Value = (rr.Index + 1).ToString();
            }
            //saltaEventosMalla = false;
        }
        private void EliminarLinea()
        {
            if (!classMenSistem.mensajesErrorDocumento.ConfirmaEliminar()) return;
            ((DataTable)malla.DataSource).Rows.RemoveAt(malla.CurrentRow.Index);    //    malla.Rows.Remove(malla.CurrentRow);
            if (malla.Rows.Count < 1) { dtDetalleDocumento.Rows.Add(dtDetalleDocumento.NewRow()); }
            edTotal.Text = OperacionesMallaEgr.Totalizar(malla);
        }

        private void malla_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            Boolean aplica = false;
            aplica = (Convert.ToInt16("0" + malla.Rows[e.RowIndex].Cells["TieneAplicacion"].Value) == 0);

            malla.Columns["Apl_codBenef"].ReadOnly = aplica;
            malla.Columns["NombreImpresion"].ReadOnly = aplica;
            malla.Columns["Apl_SucApli"].ReadOnly = aplica;
            malla.Columns["Apl_Docapli"].ReadOnly = aplica;
            malla.Columns["Apl_Numapli"].ReadOnly = aplica;
        }

        #endregion manejo malla
        
        #region CONTROL DE EVENTOS

        private void cmbDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //if (cmbDocumento.SelectedValue.ToString().Length == 3)
                if (cmbDocumento.SelectedValue != null && cmbDocumento.SelectedValue.ToString().Length == 3)
                {
                    CargarPredefinidosDocumento();
                }
            }
            catch { }
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            iniciarNuevoDocumento();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }

        private void txtfecha_ValueChanged(object sender, EventArgs e)
        {
            txtFechaVence.Value = txtfecha.Value;
        }
        private void BtnAbre_Click(object sender, EventArgs e)
        {
            BuscadorDocumentos.buscadorDoc progBus = new BuscadorDocumentos.buscadorDoc();
            idDocumentoActual.Sucursal = datosEmpresa.sucursal;
            DateTime queFecha = DateTime.Now;
            progBus.IniciaBusqueda(propiedadesDoc.TipoDoc, "", cmbDocumento.SelectedValue.ToString(), queFecha, ref idDocumentoActual.Sucursal, ref idDocumentoActual.Tipo, ref idDocumentoActual.numero, ref idDocumentoActual.idClave, false, cmbDocumento.SelectedValue.ToString(), "", "", "ADCDOC");
            if (idDocumentoActual.idClave == 0)
            {
                idDocumentoActual.Sucursal = datosEmpresa.sucursal; return;
            }
            if (idDocumentoActual.Sucursal.ToUpper() != datosEmpresa.sucursal.ToUpper()) { classMenSistem.mensajesErrorDocumento.documentosNoDeOtraSucursal(datosEmpresa.SucursalNombre); return; }
            if (idDocumentoActual.idClave != 0) cargarDatosEgreso(idDocumentoActual);
        }
        private void txtnumero_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtnumero.TextLength > 0 && e.KeyCode == Keys.Return)
            {
                idDocumentoActual.numero = Convert.ToDouble(txtnumero.Text);
                idDocumentoActual.idClave = 0;
                if (cargarDatosEgreso(idDocumentoActual) == false)
                {
                    classMenSistem.mensajesErrorDocumento.neutro("Documento no existe");
                    txtnumero.Text = "";
                    txtnumero.Focus();
                }
            }
        }
        private void btnBuscaCliente_Click(object sender, EventArgs e)
        {
            BuscaCliente(txtnombrecliente.Text);
        }
        private void btnBuscaBanco_Click(object sender, EventArgs e)
        {
            Buscar.frmBuscar buscar = new Buscar.frmBuscar();
            string consulta = "SELECT Bco_Codigo, Bco_Nombre, bco_numcta as NumeroCta FROM AdcCtaBco";
            string abreviaturaBanco = Convert.ToString(buscar.Buscar(DattCom.datosEmpresa.strConxAdcom, consulta, "Bco_Codigo", "Bco_Nombre", "", "BusquedaCuentasBancarias"));//
            if (abreviaturaBanco.Length > 0) mostrarDatosBanco(abreviaturaBanco);
        }

        private void btnCierra_Click(object sender, EventArgs e)
        {
            limpiarDatos();
        }
        private void btnAnula_Click(object sender, EventArgs e)
        {
            DctosEmi.anulaElimina classAnular = new DctosEmi.anulaElimina();
            if (classAnular.anularDocumento(datosEmpresa.strConxAdcom, datosEmpresa.strConIniSis, idDocumentoActual, DatosUsuario.codigo, false, datosEmpresa.Emp_Nombre, datosEmpresa.Emp_codigo.ToString(), edTotal.Text, "ADCDOC", propiedadesDoc.ComandoExterno)) limpiarDatos();
            classAnular = null;
        }
        private void btnElimina_Click(object sender, EventArgs e)
        {
            DctosEmi.anulaElimina classAnular = new DctosEmi.anulaElimina();
            if (classAnular.eliminarDocumento(datosEmpresa.strConxAdcom, datosEmpresa.strConIniSis, idDocumentoActual, DatosUsuario.codigo, false, datosEmpresa.Emp_Nombre, datosEmpresa.Emp_codigo.ToString(), edTotal.Text, "ADCDOC", propiedadesDoc.ComandoExterno)) limpiarDatos();
            classAnular = null;
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            ImpresionesDeldocumento("",false);
        }

        private void btnGraba_Click(object sender, EventArgs e)
        {
            datosBanco.moverDatosAclase(this);
            ValidacionDocmtosBancos valdoc = new ValidacionDocmtosBancos();
            if (valdoc.validaEgresoBanco(datADCDOC, malla, DatosUsuario.codigo) == true) 
            {
                if (grabarDocumento() == true)
                {
                    limpiarDatos();
                }
            }
        }

        private void btnRegistra_Click(object sender, EventArgs e)
        {
            datosBanco.moverDatosAclase(this);
            ValidacionDocmtosBancos valdoc = new ValidacionDocmtosBancos();
            if (valdoc.validaEgresoBanco(datADCDOC, malla, DatosUsuario.codigo) == true) 
            {
                if (grabarDocumento() == true)
                {
                    ImpresionesDeldocumento("", true);
                    limpiarDatos();
                }
            }
        }
        private void txtCodper_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtCodper.Text.Length > 0) { cargarDatosCliente(txtCodper.Text); }
        }


        private void frmEgrBcoCaj_FormClosed(object sender, FormClosedEventArgs e)
        {
            registraOpciones();
        }

        private void BtnImprimeCheque_Click(object sender, EventArgs e)
        {
            ImpresionesDeldocumento("CHE",true);
        }

        #endregion CONTROL DE EVENTOS

        private void malla_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("El valor registrado no es correcto, intente otra vez", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnContabiliza_Click(object sender, EventArgs e)
        {
            if (datADCDOC == null) datADCDOC = new AdcDoc(datosEmpresa.strConxAdcom);
            DatosDocBancos dat = new DatosDocBancos();
            dat.moverDatosAclase(this);
            daxContaDoc.frmVisContab progCtb = new daxContaDoc.frmVisContab(asientosContables,datADCDOC, (DataTable)malla.DataSource,propiedadesDoc);
            asientosContables = progCtb.IniciarRevisionContable();
            //            progCtb.GenerarContabilidadDocumento(datADCDOC, (DataTable)malla.DataSource, propiedadesDoc, null, "");
            progCtb.Dispose();
        }
    }
}

