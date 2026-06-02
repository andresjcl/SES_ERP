using System;
using System.Windows.Forms;
using DattCom;


namespace BuscadorDocumentos
{
    public partial class frmBuscarDoc : Form
    {
        public frmBuscarDoc()
        {
            InitializeComponent();
        }
        private bool cargar = false;
        private string numero = "";
        internal string docSucursal = "";
        internal string LisTipoDocu = "";
        internal string opc_d = "";
        internal string tabla = "";
        internal double idClaveDoc = 0d;
        internal string Solodoc = "";
        internal string DocInicial = "";
        internal string Codigo = "";
        internal string claseDoctosPermitidos = ""; // ES LA CLASE DE DOCUMENTOS QUE QUEREMOS BUSCAR (viene un solo string string  de  cdigos de doctos de tres en tres seguidos "FACEGRFAPPRO...etc")
        internal DateTime InicFec = new DateTime(1900, 1, 1);
        internal string DocRet;
        internal double NumRet;
        internal string SucRet;
        internal string Lista;
        internal bool sinArt;
        internal bool estaConsolidando = false;
        bool saltarCarga = true;
        sesSys.OpcDoc opcDoc = new sesSys.OpcDoc();
        #region Consulta

        private void frmBuscarDoc_Load(object sender, EventArgs e)
        {
            
        //}
        //private void IniciarValores()
        //{ 
            if (sinArt)
            {
                Label4.Visible = false;
                btnArticuloCod.Visible = false;
                btnServicioCod.Visible = false;
                txtArtCodigo.Visible = false;
                txtArticuloNombre.Visible = false;
            }

            txtFechaIn.Value  = new DateTime(DateTime.Now.Year,DateTime.Now.Month,1);
            txtFechaFin.Value  = DateTime.Now;
            DaxCombobx.CargCmbBox llcbo = new DaxCombobx.CargCmbBox();
            //llcbo.DaxCombosSuc(datosEmpresa.codEmpresa.ToString(), true, datosEmpresa.strConxSyscod, ref cboSucursal);

            llcbo.DaxCombosSuc(datosEmpresa.codEmpresa.ToString(), true, datosEmpresa.strConxSyscod, ref cboSucursal);

            if (docSucursal != null && !string.IsNullOrWhiteSpace(docSucursal.ToString()))
            {
                cboSucursal.SelectedValue = docSucursal;
            }
            cboSucursal.SelectedValue = docSucursal;
            llcbo.DaxCombosBods(docSucursal, true, datosEmpresa.strConIniSis , ref cboBodega );
            llcbo.DaxCombosDoc(claseDoctosPermitidos, DocInicial, false, datosEmpresa.strConxAdcom, ref cboTipoDoc);
            llcbo.DaxCombosPtoVta(datosEmpresa.strConxAdcom, ref cboPtoVenta, true);
            try
            {
                cboPtoVenta.SelectedValue = Environment.MachineName;
            }
            catch
            {
                cboPtoVenta.SelectedValue = "0";
            }

            if (cboPtoVenta.SelectedValue == null)
                cboPtoVenta.SelectedValue = "0";
            try
            {
                cboSucursal.SelectedValue = datosEmpresa.suc;
            }
            catch 
            {
            }

            string aux = DocInicial.Replace("'", "");

            if (aux.Length > 2)
                cboTipoDoc.SelectedValue = aux.Substring(0, 3);

            if (Codigo.Length > 0)
            {
                txtClienteCod.Text = Codigo;
                var prog = new EmpNomR.AdcNomb();
                txtClienteNombre.Text = prog.RetornaNombreDirectorio(Codigo, datosEmpresa.strConxAdcom);
            }
            saltarCarga = false;
            CargarMalla();
            //cargainicial = false;
            txtFechaIn.Focus();
            cargar = true;
        }
        private void CargarMalla()
        {
            if (saltarCarga) return;
            if (cboTipoDoc.SelectedValue == null)  return;
            if (opcDoc.tablaDatosDoc == "") opcDoc.Cargar(cboTipoDoc.SelectedValue.ToString());
            string tip = cboTipoDoc.SelectedValue.ToString();
            //string lug = "";
            string Bus_PtoVta = "";
            string Bus_tipDoc = "";
            string Bus_suc = "";
            string Bus_bod = "";
            string Bus_client = "";
            string Bus_art = "";
            string Bus_det = "";
            string Bus_valor = "";
            //malla.DataSource = null;
            //if (tabla.ToUpper() == "ADCDOCPRO")
            //{
            //    Bus_tablaDoc = "AdcDocpro";
            //    Bus_tablaTra = "AdcTraPro";
            //}

           // string campo = camp;

            if (estaConsolidando & DocInicial.Length > 3)
            {
                Bus_tipDoc = " and opc_documento in (" + DocInicial + ")";
            }
            else
            {
                Bus_tipDoc = " and opc_documento ='" + cboTipoDoc.SelectedValue.ToString() + "' ";
            }

            try
            {
                if (cboSucursal.SelectedValue.ToString() != "0" & !string.IsNullOrEmpty(cboSucursal.SelectedValue.ToString()))
                {
                    Bus_suc = " and doc_sucursal = '" + cboSucursal.SelectedValue.ToString() + "' ";
                }
            }
            catch
            {
            }

            try
            {
                if ( !string.IsNullOrEmpty(cboPtoVenta.SelectedValue.ToString()) && cboPtoVenta.SelectedValue.ToString() != "0")
                {
                    Bus_PtoVta = " and puntovta ='" + cboPtoVenta.SelectedValue.ToString() + "' ";
                }
            }
            catch
            {
            }

            if (!string.IsNullOrEmpty(cboBodega.SelectedValue.ToString()) && cboBodega.SelectedValue.ToString() != "0" )
            {
                Bus_bod = " and doc_bodega ='" + cboBodega.SelectedValue.ToString() + "' ";
            }

            if (!string.IsNullOrEmpty(txtClienteCod.Text))
            {
                Bus_client = " and (doc_codper ='" + txtClienteCod.Text + "' or Doc_CiRuc ='" + txtClienteCod.Text + "') ";
            }

            if (!string.IsNullOrEmpty(txtDetalle.Text))
            {
                Bus_det = " and doc_detalle like '%" + txtDetalle.Text + "%'";
            }

            if (!string.IsNullOrEmpty(txtArtCodigo.Text))
            {
                Bus_art = " and idClaveDoc in(select DISTINCT idclaveDoc from " + opcDoc.tablaDatosTra + " where tra_codigo ='" + txtArtCodigo.Text + "') ";
            }

            //if (!string.IsNullOrEmpty(txtvalor.Text))
            //{
            //    Bus_valor = " and doc_valor like '%" + txtvalor.Text + "%'";
            //}

            if (!string.IsNullOrEmpty(txtNumDoc.Text))
            {
                numero = " and Doc_NroLoteDoc ='" + txtNumDoc.Text + "'";
            }

            string ssql = "select doc_sucursal as SUC, opc_documento as TIP";
            ssql += ",doc_fecha as FECHA,doc_numero as NUM,Doc_NombreImp as NOMBRE, doc_valor as VALOR";
            ssql += ",Doc_detalle as DETALLE,doc_codper, idClaveDoc,isnull(estadosri,'') as EstadoSri  from " + opcDoc.tablaDatosDoc + "";
            ssql += " where doc_fecha>= '" + txtFechaIn.Text + "' and doc_fecha<= '" + txtFechaFin.Text + " 23:59:59' ";
            ssql += Bus_tipDoc + Bus_suc + Bus_bod + Bus_PtoVta + Bus_client + Bus_art + Bus_det + Bus_valor + numero;

            if (opcDoc.EsElectronico == 1)
            {
                if (!(chkAutorizados.Checked && chkNoAutirizados.Checked))
                {
                    if (chkAutorizados.Checked)
                    {
                        ssql += " and (isnull(EstadoSri,'') = 'Autorizado')";
                    }
                    if (chkNoAutirizados.Checked)
                    {
                        ssql += " and (isnull(EstadoSri,'') <> 'Autorizado')";
                    }
                }
            }
            if (!(chkActivos.Checked && chkAnulados.Checked))
            {
                if (chkActivos.Checked)
                {
                    ssql += " and (isnull(doc_estado,0) = 1)";
                }
                if (chkAnulados.Checked)
                {
                    ssql += " and (isnull(doc_estado,0) = 0)";
                }
            }
            malla.DataSource = SqlDatos.leerTablaAdcom(ssql);
            malla.ClearSelection();
            malla.Columns["doc_codper"].Visible = false;
            malla.Columns["idclavedoc"].Visible = false;
            malla.Columns["fecha"].DefaultCellStyle.Format = "dd/MMM/yyyy";
            malla.Columns["Valor"].DefaultCellStyle.Format = "###,###,###,##0.00";
            malla.Columns["Detalle"].Visible = false;            
        }

        private void txtFechaIn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                CargarMalla();
                return;
            }
        }

        private void txtFechaFin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                CargarMalla();
                return;
            }
        }

        #endregion

        #region Panel Opciones

        // Metodo para mostrar u ocultar el panel de opciones
        // Metodo para inicializar las cajas de texto del panel de opciones
        private void limpiar()
        {
            txtArtCodigo.Text = "";
            txtArticuloNombre.Text = "";
            txtClienteCod.Text = "";
            txtClienteNombre.Text = "";
            txtDetalle.Text = "";
            chkActivos.Checked = true;
            chkAnulados.Checked = false;
            chkAutorizados.Checked = true;
            chkNoAutirizados.Checked = true;
            cboSucursal.SelectedValue = datosEmpresa.sucursal;
            cboPtoVenta.SelectedValue = "0";
            CargarMalla();
            //txtvalor.Text = "";
        }
        private void cboTipoDoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargar == true)
            {
                opcDoc.Cargar(cboTipoDoc.SelectedValue.ToString());
                chkAutorizados.Visible = (opcDoc.EsElectronico == 1);
                chkNoAutirizados.Visible = chkAutorizados.Visible;
                CargarMalla();
            }
        }

        private void cboSucursal_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarMalla();
        }

        private void cboBodega_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarMalla();
        }

        private void txtDetalle_TextChanged(object sender, EventArgs e)
        {
            CargarMalla();
        }

        private void txtArtCodigo_TextChanged(object sender, EventArgs e)
        {
            CargarMalla();
        }

        private void txtvalor_TextChanged(object sender, EventArgs e)
        {
            CargarMalla();
        }
        #endregion


        private void btnBorrar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarMalla();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Lista = "";
            DocRet = "";
            SucRet = "";
            NumRet = 0d;
            idClaveDoc = 0d;
            if (estaConsolidando)
            {
                if (malla.SelectedRows.Count > 0)
                {
                    string aux = "";
                    foreach (DataGridViewRow row in malla.SelectedRows)
                    {
                        if (idClaveDoc == 0d)
                        {
                            DocRet = row.Cells["TIP"].Value.ToString();
                            SucRet = row.Cells["SUC"].Value.ToString();
                            NumRet = 0d;
                            idClaveDoc = Convert.ToDouble(row.Cells["idClaveDoc"].Value.ToString());
                        }

                        Lista += aux + "'" + row.Cells["SUC"].Value.ToString() + row.Cells["TIP"].Value.ToString() + row.Cells["idClaveDoc"].Value.ToString() + "'";
                        aux = ",";
                    }
                }
            }
            else
            {
                malla_DoubleClick(sender, e);
            }

            Close();
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void malla_DoubleClick(object sender, EventArgs e)
        {
            SucRet = "";
            DocRet = "";
            Lista = "";
            NumRet = 0d;
            idClaveDoc = 0d;
            try
            {
                if (malla.CurrentRow == null) return;
                var row = malla.CurrentRow;
                SucRet = row.Cells["SUC"].Value.ToString();
                DocRet = row.Cells["TIP"].Value.ToString();
                idClaveDoc = Convert.ToDouble(row.Cells["idClaveDoc"].Value.ToString());
                NumRet = Convert.ToDouble(row.Cells["NUM"].Value.ToString());
                row.Dispose();
            }
            catch
            {
            }

            Close();
            Dispose();
        }

        private void txtNumDoc_KeyPress(object sender, KeyPressEventArgs e)
        {

            if ("0123456789".IndexOf((e.KeyChar).ToString()) == -1)
                e.KeyChar = Convert.ToChar("");
        }

        private void txtNumDoc_TextChanged(object sender, EventArgs e)
        {
            CargarMalla();
        }

        private void btnClienteCod_Click(object sender, EventArgs e)
        {
            var prog = new directMnt.BusDirectorio();
            string nombre = "";
            string argcodigo = "";
            string argCEDULA = "";
            string argNombreAlias = "";
            string argTipo = "";
            string argConNuevo = "";
            txtClienteCod.Text = prog.BusDirect(ref argcodigo, ref argCEDULA, ref nombre, ref argNombreAlias, ref argTipo, ref argConNuevo);
            txtClienteNombre.Text = nombre;
        }

        private void btnArticuloCod_Click(object sender, EventArgs e)
        {
            var progbus = new Buscar.frmBuscar();
            var nombrar = new EmpNomR.AdcNomb();
            txtArtCodigo.Text = progbus.Buscar(datosEmpresa.strConxAdcom, "select art_codigo,art_nombre from adcart", "art_codigo", "art_nombre", "", "Busca Artículos");
            txtArticuloNombre.Text = nombrar.RetornaNombreArticulo(txtArtCodigo.Text, datosEmpresa.strConxAdcom);
        }

        private void btnServicioCod_Click(object sender, EventArgs e)
        {
            var progbus = new Buscar.frmBuscar();
            var nombrar = new EmpNomR.AdcNomb();
            txtArtCodigo.Text = progbus.Buscar(datosEmpresa.strConxAdcom, "select sev_codigo,sev_nombre from adcserv", "sev_codigo", "sev_nombre", "", "Busca Servicios");
            txtArticuloNombre.Text = nombrar.RetornaNombreServicio(txtArtCodigo.Text, datosEmpresa.strConxAdcom);
        }

        private void txtClienteCod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return & txtClienteCod.TextLength > 0)
                CargarMalla();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            panel3.Visible = !panel3.Visible; 
        }

        private void chkActivos_CheckedChanged(object sender, EventArgs e)
        {
            CargarMalla();
        }
    }
}
