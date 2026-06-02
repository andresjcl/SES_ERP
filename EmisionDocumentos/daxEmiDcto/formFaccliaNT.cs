using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient ;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using daxMallaDatos;
using docUtility;
using MantenimientoDirectorio;

namespace daxEmiFacPv
{
    public partial class formFaccliAnt : Form
    {
        Form1 forma1 = new Form1();

        Boolean documentoMultiNumeracion = false;
        string lugarNumeracionDocumento = "";

        string claseDocDefault = "";
        string tipoDocDefault = "";
        
        Boolean esSoloConsulta = false;
        Boolean consultaDeEstadoDecta = false;

        Boolean tieneComprobantesElectronicos = false;
        docMallaArticulo mallaArticulo = new docMallaArticulo();
        
        string docActualSucursal = "";
        string docActualOpc = "";
        double docActualNumero = 0;
                
        double idClaveDoc = 0;
        string claveSri = "";
        string codCliente = "";

        double IdClaveDocSustento = 0;
        DataTable dtDetalleDocumento = new DataTable();
        //'daaxLib.DaxLibBases datlib;
        string strConxAdcom = "";
        string strDaxsys = "";
        AdcDax.DaxSofSys CONEMP = new AdcDax.DaxSofSys() ;
        DaxUsr.DaxsofUsr CONUSER = new DaxUsr.DaxsofUsr();
        //AdcDax.Empresa Emp;
        DaxUsr.CtrlUsuario ControlUsuario;        
        PrySysp13.OpcDoc propiedadesDoc = new PrySysp13.OpcDoc("","");
        MantenimientoDirectorio.DirectorioAlex opalex = new MantenimientoDirectorio.DirectorioAlex();
        adcDocumentos.AdcDoc datADCDOC;
        pagosDocumento.classPagosDoc  clasePagos = new pagosDocumento.classPagosDoc();        

        classExporta datosExportacion = new classExporta();

        int operacion = 0; // 0 sin operacion delcarada, 1 nuevo registro, 2 modificando registro

        public formFaccliAnt(string clasdef,string tipdef, Boolean soloConsulta = false, Boolean desdeEstdoCta = false, string sucursalDocumento = "", string tipoDocumento ="", double idclavedocDocumento = 0)
        {
            InitializeComponent();
            claseDocDefault = clasdef;
            tipoDocDefault = tipdef;
            splitContainer1.Panel2Collapsed = !(splitContainer1.Panel2Collapsed);
            //Emp = CONEMP.EmpresaAct.EmpresaAct;
            ControlUsuario = CONUSER.UsuarioAct;
            //daaxLib.DaxLibBases datlib = new daaxLib.DaxLibBases(CONEMP.EmpresaAct.codigo,CONEMP.EmpresaAct.Sistema,CONEMP.EmpresaAct.PatAppl);
            //strConxAdcom = datlib.StrAdcom();
            //strDaxsys = datlib.StrDaxsys();
            mallaArticulo.strConxAdcom = strConxAdcom;
            validaComprobantesElectronicos();
            llenarCombos();
            llenarDatosEmpresa();
            prepararBotones();
            //formaPago = new FormasPago.MntPago();
        }
        private void formFaccli_Load(object sender, EventArgs e)
        {
            cmbDocumento.SelectedValue = "";
            cmbDocumento.SelectedValue = tipoDocDefault;
            docActualSucursal = CONEMP.EmpresaAct.SucActual;
            llenarComboDocReferencia();
        }

        private void llenarCombos()
        {
            DaxCbos.DaxCombobx cmb = new DaxCbos.DaxCombobx();
            cmb.DaxCombosDoc(claseDocDefault , tipoDocDefault , false, strConxAdcom, ref cmbDocumento);
            ////////cmb.DaxCombosBods(CONEMP.EmpresaAct.SucActual, false, strDaxsys, ref cmbBodega);
            cmb.DaxCombosVend(strConxAdcom, ref cmbVendedor,false);
        }
        private void llenarComboDocReferencia()
        {

            docActualOpc = cmbDocumento.SelectedValue.ToString();
            propiedadesDoc.Cargar(ref docActualOpc, ref docActualSucursal);
            string Ssql="";
            
            if (propiedadesDoc.TipoSoporteObligatorio != null && propiedadesDoc.TipoSoporteObligatorio.Length > 0) {
                Ssql = "SELECT opc_nombre, opc_documento, opc_tipo FROM adcopc WHERE OPC_DOCUMENTO = '"  + propiedadesDoc.TipoSoporteObligatorio + "' order by opc_documento ";}
            else {
                Ssql = "SELECT opc_nombre, opc_documento, opc_tipo FROM adcopc  WHERE OPC_DOCUMENTO > '' order by opc_documento ";}
            utilBasDatos ubd = new utilBasDatos();
            DataTable dtt = ubd.leerTablas(Ssql,strConxAdcom);
            cmbDocumentoSustento.DataSource = dtt;
            cmbDocumentoSustento.DisplayMember = "opc_nombre";
            cmbDocumentoSustento.ValueMember = "opc_documento";            
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void validaComprobantesElectronicos()
        {
            string curFile = CONEMP.EmpresaAct.PatAppl + @"AdcGenxml.dll";
            tieneComprobantesElectronicos = File.Exists(curFile);
            if (tieneComprobantesElectronicos == true)
            {
                curFile = CONEMP.EmpresaAct.PatAppl + @"AdcFirelec.dll";
            }
            tieneComprobantesElectronicos = File.Exists(curFile);
            if (tieneComprobantesElectronicos == true)
            {
                curFile = CONEMP.EmpresaAct.PatAppl + @"Daxconxfe.dll";
            }
            tieneComprobantesElectronicos = File.Exists(curFile);
        }

        private void btnBuscaCliente_Click(object sender, EventArgs e)
        {
            buscaCliente(txtnombrecliente.Text);
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
                 opalex.CargarAlex(ref codigo, ref x, ref solocodigo);
//                DataTable dt = datt.leerTablas("select codigo,cedulaidentidadruc,nombreimpresion,domicilio,correoElectrónico,telefono1 from identificacion where codigo ='" + codigo + "'", strConxAdcom);
                //if (dt != null)
                if (opalex.codigo.Length > 0 )
                {
                    codCliente = opalex.codigo ;
                    txtcedula.Text = opalex.CiRuc ;
                    txtnombrecliente.Text = opalex.NombreImpresion ;
                    txtdireccion.Text = opalex.direccion ;
                    txtCorreElectronico.Text = opalex.correoElectronico  ;
                    txttelefono.Text = opalex.telefono1;
                }
            }
            else
            {
                codCliente = "";
                txtcedula.Text = "";
                txtnombrecliente.Text = "";
                txtdireccion.Text = "";
                txtCorreElectronico.Text = "";
                txttelefono.Text = "";
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
                txtNroID.Text = dr["suc_idtributario"].ToString();
                dr.Close();
                dr.Dispose();
                conn.Close();
                conn.Dispose();
                comm.Dispose();
            }
        }

        private void btnAbre_Click(object sender, EventArgs e)
        {
            BuscadorDocumentos.buscadorDoc progBus = new BuscadorDocumentos.buscadorDoc(strConxAdcom,strDaxsys);
            docActualSucursal = CONEMP.EmpresaAct.SucActual;
            DateTime queFecha = DateTime.Now;
            progBus.IniciaBusqueda(claseDocDefault  , "", cmbDocumento.SelectedValue.ToString(), queFecha, ref docActualSucursal, ref docActualOpc, ref docActualNumero, ref idClaveDoc, false, cmbDocumento.SelectedValue.ToString(), "", "", "ADCDOC");
            if (idClaveDoc == 0)
            {
                docActualSucursal = CONEMP.EmpresaAct.SucActual; return;
            }
            if (docActualSucursal.ToUpper() != CONEMP.EmpresaAct.SucActual.ToUpper()) { MessageBox.Show("No puede accesar a un documento de una sucursal diferente a (" + CONEMP.EmpresaAct.SucNomActual + ")"); return; }
            if (idClaveDoc != 0) cargarDatosFactura(docActualSucursal,docActualOpc,idClaveDoc);
        }
        private Boolean cargarDatosFactura(string SUC, string TIPO, double IDCLAVE )
        {
            Boolean resp = false;
            if (IDCLAVE != 0)
            {
                datADCDOC = new adcDocumentos.AdcDoc(strConxAdcom);
                datADCDOC = adcDocumentos.AdcDoc.Buscar("doc_sucursal = '" + SUC + "' and opc_documento ='" + TIPO + "' and idclavedoc = " + IDCLAVE.ToString());
                if (datADCDOC != null)
                {
                    cargarDatosCliente(datADCDOC.Doc_codper);
                    moverClaseAcontroles();
                    cargarDetalleArticulos(docActualSucursal, docActualOpc, idClaveDoc, "ADCTRA");
                    cargarFormaDePago(docActualSucursal, docActualOpc, idClaveDoc);
                    totalizar();
                    //inicializarUtilidadDocumentos();
                    operacion = 2;
                    prepararBotones();
                    resp = true;
                }
            }
            else { }
            return resp;        
        }
        private void cargarDetalleArticulos(string suc, string tip, double idClave,string tablatra)
        {
            utilBasDatos ubd = new utilBasDatos();
            dtDetalleDocumento = ubd.leerTablas(armarSqlLecturaTra(tablatra,suc,tip,idClave),strConxAdcom);
            if (dtDetalleDocumento == null) return;
            malla.DataSource = dtDetalleDocumento;
            diseñarMalla();
        }
        private void cargarFormaDePago(string suc, string tip, double idClave)
        { 
          clasePagos =  new pagosDocumento.classPagosDoc();
          clasePagos.strConx = strConxAdcom;
          clasePagos.DocSucursal = suc;
          clasePagos.Doctipo = tip;
          clasePagos.idClaveDoc = idClave;
          clasePagos.DocNumero = Convert.ToDouble("0" + txtnumero.Text);
          clasePagos.cargarPagosDocumento();

        //                         Set ClasePagos = New DocPagos
        //      If BtnPago.Visible = True Then
        //    ClasePagos.DocFecha = TxtFecha
        //    ClasePagos.Doctipo = dcTipDoc.BoundText
        //    ClasePagos.DocNumero = txtNumero
        //    ClasePagos.CargarPagosDocumentoClass IdClaveDoc, "adcpag", CONEMP.EmpresaAct.SucActual, dcTipDoc.BoundText, txtNumero
        //End If

        }

        private string armarSqlLecturaTra(string TablaTra,string suc, string tip, double idClave)
        {
            string ssqlTra = "select ";
            ssqlTra += "TRA_NUMLINEA as Nro";
            ssqlTra += ",tra_codigo as codigo";
            ssqlTra += ",tra_nombre as Descripción";
            ssqlTra += ",FacDesde as FecDesde";
            ssqlTra += ",FacHasta as FecHasta";
            ssqlTra += ",tra_cantidad as Cantidad";
            ssqlTra += ",tra_medida as Medida";
            ssqlTra += ",Tra_precuni as PreVtaUni";
            ssqlTra += ",tra_porcendes as PorDscto";
            ssqlTra += ",tra_valordes as ValDesCto";
            ssqlTra += ",Tra_prectot as PreVtaTot";
            ssqlTra += ",tra_quetipo as Tipo";

            ssqlTra += ",Tra_individual as Individual";
            ssqlTra += ",TRA_SNIVA as SnIva";
            ssqlTra += ",tra_costuni as CostoUnit";
            ssqlTra += ",Tra_CostTot as CostoTot";
            ssqlTra += ",tra_piezas as Piezas";
            ssqlTra += ",tra_peso as Peso";
            ssqlTra += ",tra_multiplo as Multi";
            ssqlTra += ",tra_nrolote as NroLote";
            ssqlTra += ",Doc_Bodega as Bodega";
            ssqlTra += ",Despacho as Despacho";
            ssqlTra += " from " + TablaTra + " where doc_sucursal = '" + suc + "' and opc_documento ='" + tip + "' and idclavedoc = " + idClave.ToString();

            return ssqlTra;        
        }
        private void diseñarMalla()
        {

            malla.RowHeadersWidth = 20;


            
            malla.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
            malla.RowHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
            malla.RowHeadersDefaultCellStyle.ForeColor = Color.White;
            malla.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            malla.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            malla.RowHeadersWidth = 50;

            
            
            malla.Columns["Codigo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            malla.Columns["Descripción"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            malla.Columns["Medida"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            malla.Columns["Nro"].Visible = false;
            //malla.Columns["Descripción"].ReadOnly = true;
            malla.Columns["PorDscto"].Visible = false;
            malla.Columns["ValDesCto"].Visible = false;
            malla.Columns["Tipo"].Visible = false;
            malla.Columns["Individual"].Visible = false;
            malla.Columns["CostoUnit"].Visible = false;
            malla.Columns["CostoTot"].Visible = false;
            malla.Columns["Piezas"].Visible = false;
            malla.Columns["Peso"].Visible = false;
            malla.Columns["Multi"].Visible = false;
            malla.Columns["NroLote"].Visible = false;
            malla.Columns["Bodega"].Visible = false;
            malla.Columns["FecDesde"].Visible = false;
            malla.Columns["FecHasta"].Visible = false;
            malla.Columns["Despacho"].Visible = false;

        }
        private void moverClaseAcontroles()
        {
            idClaveDoc = Convert.ToDouble(datADCDOC.IdClaveDoc);
            codCliente = datADCDOC.Doc_codper;

            txtnumero.Text = datADCDOC.Doc_numero.ToString();
            txtNroID.Text = datADCDOC.Doc_NroIdDoc.ToString();
            txtfecha.Text = datADCDOC.Doc_fecha.ToShortDateString();

            cargarDatosCliente(codCliente);
            if (txtcedula.Text.ToUpper() != datADCDOC.Doc_CiRuc.ToUpper()) txtcedula.Text = datADCDOC.Doc_CiRuc;
            if (txtnombrecliente.Text != datADCDOC.Doc_NombreImp) txtnombrecliente.Text = datADCDOC.Doc_NombreImp;
            if (txtdireccion.Text != datADCDOC.Doc_Direccion) txtdireccion.Text = datADCDOC.Doc_Direccion;

            try
            {
                txtNumeroSoporte.Text = datADCDOC.Doc_NumSop.ToString();
                cmbDocumentoSustento.SelectedValue = datADCDOC.Doc_DocSop;
                IdClaveDocSustento = Convert.ToDouble(datADCDOC.IdClaveDocSop);
            }
            catch { }

            txtDetalle.Text  = datADCDOC.Doc_detalle ;
            cmbVendedor.SelectedValue = datADCDOC.Doc_venabre;
            
            if (Convert.ToInt32(datADCDOC.Doc_Estado) == 0) mensajesDocumento.Text = "DOCUMENTO ANULADO";
        }

        private void prepararBotones()
        {
            Boolean inicio = (operacion == 0);
            Boolean nuevo = (operacion == 1);
            Boolean modificando = (operacion == 2);


            btnAbre.Enabled   = inicio;
            btnNuevo.Enabled  = inicio;

            btnCopia.Enabled = nuevo;
            btnConsolida.Enabled = nuevo;

            btnAnula.Enabled = modificando;
            btnElimina.Enabled = modificando;
            btnGraba.Enabled = !inicio;
            btnRegistra.Enabled = !inicio;
            btnEnviar.Enabled = modificando;
            btnCierra.Enabled = !inicio;

            btnExportacion.Enabled = !inicio;
            btnContabiliza.Enabled = !inicio;
            btnAplicaciones.Enabled = modificando;
            btnEstadoCta.Enabled = !inicio;
            btnPendientes.Enabled = !inicio;
            btnPagos.Enabled = !inicio;
            btnDescuentos.Enabled = !inicio;

            btnAgrupa.Enabled = (btnBarras.Visible && btnBarras.Checked);
            btnBarras.Enabled = (operacion != 0);
           
            panel1.Enabled = (operacion != 0);
            malla.Enabled = (operacion != 0);

            cmbDocumento.Enabled  = (operacion != 2);
            txtcedula.Enabled =(operacion != 2);

            if (esSoloConsulta == true || consultaDeEstadoDecta == true)
            {
                btnGraba.Enabled = false;
                btnRegistra.Enabled = false;
                if (consultaDeEstadoDecta == true) btnEstadoCta.Enabled = false;
            }
        }

        private void btnCierra_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma cerrar el documento actual ?", "Cerrar documento sin grabar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No) return;
            limpiarDatos();
        }
        private void limpiarDatos()
        {
            datADCDOC = new adcDocumentos.AdcDoc(strConxAdcom);
            datosExportacion = new classExporta(strConxAdcom);
            clasePagos = new pagosDocumento.classPagosDoc();

            txtcedula.Text  = "";
            txtCorreElectronico.Text  = "";
            txtDetalle.Text  = "";
            txtdireccion.Text  = "";
            txtLote.Text  = "";
            txtnombrecliente.Text  = "";
            txtnumero.Text = "";
            txtNumeroSoporte.Text = "";
            txtProducto.Text = "";
            txttelefono.Text  = "";
            cmbDocumentoSustento.SelectedValue = "";
            mensajesDocumento.Text = "";
            operacion = 0;
            prepararBotones();
            InicializarMalla();
            idClaveDoc = 0;
            IdClaveDocSustento = 0;
        }
        private void InicializarMalla()
        {
            utilBasDatos ubd = new utilBasDatos();
            DataTable dtt =  ubd.leerTablas(armarSqlLecturaTra("adctra","","",0),strConxAdcom);
            if (dtt == null) return;
            malla.DataSource = dtt;
            dtt.Dispose();
            diseñarMalla();
        }

        #region manejo malla

        //private void malla_CellLeave(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (malla.IsCurrentCellInEditMode == true)
        //    {
        //        DataGridViewCell cell = malla.CurrentCell;
        //        funcionesEspeciales(ref Keys.Enter, ref cell);
        //    }
        //}

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
            if (malla.IsCurrentCellInEditMode && keyData == Keys.Return) { malla.EndEdit(); return true; }
            if (!(keyData == Keys.Return || (keyData > Keys.F1 && keyData < Keys.F13))) return false;

            DataGridViewCell cell = malla.CurrentCell;
            if (cell.RowIndex > malla.Rows.Count - 3) { dtDetalleDocumento.Rows.Add(dtDetalleDocumento.NewRow()); }

            funcionesEspeciales(ref keyData, ref cell);

            if (keyData != Keys.Return) return true;
            moverCeldaMalla(cell);
            return true;
        }
        private void moverCeldaMalla(DataGridViewCell cell)
        {

            Int32 columnIndex = cell.ColumnIndex;
            Int32 rowIndex = cell.RowIndex;
            Int32 col = columnIndex;
            Int32 row = rowIndex;

            Boolean esVisible = false;
            do
            {
                if (col == malla.Columns.Count - 1)
                {
                    if (row == malla.Rows.Count - 1)
                    {
                        col = 0;
                        row = 0;
                    }
                    else
                    {
                        col = 0;
                        row++;
                    }
                }
                else
                {
                    col++;
                }
                cell = malla.Rows[row].Cells[col];
                esVisible = (cell.Visible && !cell.ReadOnly);
            } while (esVisible == false);
            malla.CurrentCell = cell;
        }
        private void malla_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell cell = malla.CurrentCell;
            string nombreCelda = malla.Columns[cell.ColumnIndex].Name;
            string datoNvo = "";
            switch (nombreCelda)
            {
                case "Color":
                case "Talla":
                    malla.CurrentRow.Cells["nombre" + nombreCelda].Value = datoNvo;
                    moverCeldaMalla(cell);
                    break;
            }
        }

        private Boolean funcionesEspeciales(ref Keys keyData, ref DataGridViewCell cell)
        {
            Boolean resp = true;
            //malla.EndEdit();
            string dato = cell.Value.ToString();
            string nombreCelda = malla.Columns[cell.ColumnIndex].Name.ToUpper();
            if (keyData == Keys.Enter)
            {
                if (nombreCelda == "CODIGO")
                {
                    //return (mallaArticulo.cargarArticuloVta(cell.Value.ToString(), malla.CurrentRow,propiedadesDoc,dato,opalex.TipoCliente,txtfecha.Text,propiedadesDoc.TipoDoc ,idClaveDoc));
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

        private void malla_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            totalizar ();
        }

        #endregion manejo malla

        private void totalizar()
        {
            this.malla.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.malla_CellValueChanged);
            double porDescuento = 0;
            double valDescuento = 0;
            double valUni = 0;
            double cantidad = 0;
            double subtotal = 0;

            double total = 0;
            try
            {
                foreach (DataGridViewRow row in malla.Rows)
                {
                    if (row.Cells["Codigo"].Value != null)
                    {
                        if (row.Cells["Codigo"].Value.ToString().Length > 0)
                        {
                            porDescuento = 0;
                            valDescuento = 0;
                            valUni = 0;
                            cantidad = 0;
                            porDescuento = Convert.ToDouble("0" + row.Cells["PorDscto"].Value);
                            valUni = Convert.ToDouble("0" + row.Cells["PreVtaUni"].Value);
                            cantidad = Convert.ToDouble("0" + row.Cells["Cantidad"].Value);

                            subtotal = valUni * cantidad;
                            valDescuento = subtotal * porDescuento / 100;
                            subtotal -= valDescuento;

                            row.Cells["PreVtaTot"].Value = subtotal;
                            total += subtotal;
                        }
                    }
                }
                edTotal.Text = string.Format ("{0:0.00}",total);
            }
            catch { }
            this.malla.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.malla_CellValueChanged);
        }

        private void btnPromocion_Click(object sender, EventArgs e)
        {

        }

        private void btnPagos_Click(object sender, EventArgs e)
        {
            ingresarFormaDePago();
        }
        private void ingresarFormaDePago()
        {
            string pagoPredefinido = "EFE";
            FormasPagoDax.MntPago  PagosDoc = new FormasPagoDax.MntPago();
            if (clasePagos.pagosDelDocumento.Count < 1)
            {
                if (opalex.FormaPago.Length > 0) { pagoPredefinido = opalex.FormaPago; }
                else { if (CONEMP.EmpresaAct.DocPrincipalVtas.Length > 0) pagoPredefinido = CONEMP.EmpresaAct.DocPrincipalVtas; }
            }
        //    PagosDoc.INIPagos(idClaveDoc, ref clasePagos, opalex.codigo, docActualSucursal, propiedadesDoc.TipoDoc, txtfecha.Text, false, docActualOpc, Convert.ToDouble("0" + txtnumero.Text), pagoPredefinido, Convert.ToDouble(edTotal.Text), false);
        }

        private void cmbDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (docActualSucursal == "") return;
            llenarComboDocReferencia();
        }

        private void btnBarras_Click(object sender, EventArgs e)
        {
            btnAgrupa.Enabled = btnBarras.Checked;
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            imprimirDocumento();
        }

        private void imprimirDocumento()
        {
            ImprDoct.ImprimirDoc progimp = new ImprDoct.ImprimirDoc();
            docUtils FImprimeDocumento = new docUtils();
            FImprimeDocumento.ImpDoc(idClaveDoc, CONEMP.EmpresaAct.SucActual, cmbDocumento.SelectedValue.ToString(), Convert.ToDouble(txtnumero.Text), "A", "F", propiedadesDoc.TipoDoc, "FELFAC");
            progimp.claveSri = claveSri;
            progimp.CorreoElectronico = txtCorreElectronico.Text;
        }

        private void btnExportacion_Click(object sender, EventArgs e)
        {
            docExpor progex = new docExpor();
            datosExportacion.conexiondata = strConxAdcom;
            datosExportacion.Opc_documento = cmbDocumento.SelectedValue.ToString();
            datosExportacion.Doc_numero = Convert.ToDecimal("0" + txtnumero.Text);
            datosExportacion.Doc_Sucursal = CONEMP.EmpresaAct.SucActual;
            datosExportacion.IdClaveDoc = Convert.ToDecimal(idClaveDoc);
            progex.iniciaDocumento (ref datosExportacion);
            progex = null;
        }

        private void btnPendientes_Click(object sender, EventArgs e)
        {
            porEntregar.frmPorEntregar  PorEntregar = new porEntregar.frmPorEntregar();
            PorEntregar.fecha = DateTime.Now;
            PorEntregar.Cliente = codCliente ;
            PorEntregar.NomCliente = txtnombrecliente.Text ;
            PorEntregar.strConxAdcom = strConxAdcom;
            PorEntregar.ShowDialog();
        }

        private void btnEstadoCta_Click(object sender, EventArgs e)
        {
           if (codCliente.Length == 0) return;
           FormasPagoDax.MntPago  progG = new FormasPagoDax.MntPago();
           string lasfacturas = "";
           double abonos = 0;
           progG.DocsPendientes (CONEMP.EmpresaAct.CruceDocSucursal , ref lasfacturas, CONEMP.EmpresaAct.SucActual, docActualOpc , idClaveDoc, codCliente ,txtnombrecliente.Text, txtLote.Text , Convert.ToDouble(edTotal.Text ), ref abonos,"", true);
           progG = null;
        }

        private void btnAplicaciones_Click(object sender, EventArgs e)
        {
             //Dim Posision As Integer, Signo As Integer
             //Posision = 7
             //'If opFac.Value Then Posision = 6
             //Signo = 1
             //If TipoDocumento = "FAP" Or TipoDocumento = "DEV" Then Signo = -1
             //VENP09.IniMovimientoDoc IdClaveDoc, dcTipDoc.BoundText, txtNumero, val(Edit) * Signo, Date, "1", Posision, CONEMP.EmpresaAct.SucActual
             //Unload VENP09
             //Set VENP09 = Nothing
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
            if (Idclave != 0) { copiarDocumento(SUC, TIP, Idclave); }
            progBus = null;
        }

        private void copiarDocumento(string suc, string tip, double idClave)
        {
            adcDocumentos.utilDoc.cadenaConexion = strConxAdcom;
            string tabladoc = "";
            string tablatra = "";
            adcDocumentos.utilDoc.tablasDeDatos(tip, ref tabladoc, ref tablatra);

            if (MessageBox.Show("Desea copiar la cabezera del documento ? ", "Copiar datos documento", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                //cargarDatosCliente (suc, tip, idClave, tabladoc);
            }
            cargarDetalleArticulos(suc, tip, idClave, tablatra);
        }

        private void btnConsolida_Click(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiarDatos();
            inicializarUtilidadDocumentos();
            double num = datADCDOC.Putil.nuevoNumeroDocumento();
            txtnumero.Text = num.ToString();
            operacion = 1;
            prepararBotones();
        }
        private void inicializarUtilidadDocumentos()
        {
            adcDocumentos.utilDoc.cadenaConexion = strConxAdcom;
            datADCDOC.Putil.Doc_sucursal = CONEMP.EmpresaAct.SucActual;
            datADCDOC.Putil.Opc_documento = cmbDocumento.SelectedValue.ToString();
            datADCDOC.Putil.idsri = txtNroID.Text;
            datADCDOC.Putil.propietario = "";           
            lugarNumeracionDocumento = datADCDOC.Putil.establecerLugar(ref documentoMultiNumeracion);
            datADCDOC.Putil.esNroMultiple = documentoMultiNumeracion;
        }

    }
}




