using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using SysEmpDatt;

namespace BuscadorDocumentos
{
    public partial class frmBuscarDoc
    {
        public frmBuscarDoc()
        {
            InitializeComponent();
            _btnAceptar.Name = "btnAceptar";
            _btnBuscar.Name = "btnBuscar";
            _btnSalir.Name = "btnSalir";
            _txtvalor.Name = "txtvalor";
            _txtDetalle.Name = "txtDetalle";
            _btnArticuloCod.Name = "btnArticuloCod";
            _txtArtCodigo.Name = "txtArtCodigo";
            _txtFechaFin.Name = "txtFechaFin";
            _txtFechaIn.Name = "txtFechaIn";
            _btnServicioCod.Name = "btnServicioCod";
            _txtClienteCod.Name = "txtClienteCod";
            _btnClienteCod.Name = "btnClienteCod";
            _malla.Name = "malla";
        }

        private SqlConnection conexion = new SqlConnection();
        private int botonOpc = 0;
        private string opciones;
        private bool cargainicial = true;
        private string camp;
        private bool cargar = false;
        private string numero = "";

        // Dim adcdax As New AdcDax.DaxSofSys
        // Dim emp As AdcDax.Empresa

        public string docSucursal = "";
        public string LisTipoDocu = "";
        public string opc_d = "";
        public string tabla = "";
        public double idClaveDoc = 0d;
        public string Solodoc = "";
        public string LiquidacionTip = "";
        public string LiquidacionNum = "";
        public string DocInicial = "";
        public string Codigo = "";
        public string claseDoctosPermitidos = ""; // ES LA CLASE DE DOCUMENTOS QUE QUEREMOS BUSCAR (viene un solo string string  de  cdigos de doctos de tres en tres seguidos "FACEGRFAPPRO...etc")
        public DateTime InicFec = new DateTime(1900,1,1);
        public string DocRet;
        public double NumRet;
        public string TipoDoc;
        public string SucRet;
        public string Lista;
        public bool sinArt;
        public int laEmpresa;
        public bool estaConsolidando = false;
        private bool saltar = true;
        #region Consulta

        private void frmBuscarDoc_Load(object sender, EventArgs e)
        {
            if (sinArt)
            {
                Label4.Visible = false;
                btnArticuloCod.Visible = false;
                btnServicioCod.Visible = false;
                txtArtCodigo.Visible = false;
                txtArticuloNombre.Visible = false;
            }

            // emp = adcdax.EmpresaAct
            string fec;
            int mes = DateTime.Now.Month;
            int año = 0;
            if (mes == 1)
                año = DateTime.Now.Year  - 1;
            else
                año = DateTime.Now.Year;
            if (mes == 1)
                fec = "01/12/" + año;
            else
                fec = "01/" + (mes - 1) + "/" + año;
            txtFechaIn.Text = fec;
            txtFechaFin.Text = DateTime.Now.ToShortDateString();
            conectarBDD();
            var llcbo = new DaxCombobx.CargCmbBox();
            var argPasCombo = cboSucursal;
            llcbo.DaxCombosSuc(datosEmpresa.codEmpresa.ToString(), true, datosEmpresa.strConxSyscod, ref argPasCombo);
            cboSucursal = argPasCombo;
            cboSucursal.SelectedValue = docSucursal;
            var argPasCombo1 = cboBodega;
            llcbo.DaxCombosBods(docSucursal, true, buscadorDoc.strConxDaxsys, ref argPasCombo1);
            cboBodega = argPasCombo1;
            var argPasCombo2 = cboTipoDoc;
            llcbo.DaxCombosDoc(claseDoctosPermitidos, DocInicial, false, buscadorDoc.strConxAdcom, ref argPasCombo2);
            cboTipoDoc = argPasCombo2;
            var argPasCombo3 = cboPtoVenta;
            llcbo.DaxCombosPtoVta(buscadorDoc.strConxAdcom, ref argPasCombo3, true);
            cboPtoVenta = argPasCombo3;
            try
            {
                cboPtoVenta.SelectedValue = Environment.MachineName;
            }
            catch
            {
                cboPtoVenta.SelectedValue = "0";
            }

            if (cboPtoVenta.SelectedValue is null)
                cboPtoVenta.SelectedValue = "0";
            try
            {
                cboSucursal.SelectedValue = datosEmpresa.suc;
            }
            catch (Exception ex)
            {
            }

            string aux = DocInicial.Replace("'", "");
            if (aux.Length > 2)
                cboTipoDoc.SelectedValue = aux.Substring(0, 3);
            cmbActivos.SelectedIndex = 1;
            cmbAutorizaciones.SelectedIndex = 1;

            // llenarBodegaSucurasal("select Abreviación,Descripcion from  syscod where tiporeferencia ='sucursales' and Abreviación <>'#'", cboSucursal)
            // llenarBodegaSucurasal("select Abreviación,Descripcion from  syscod where tiporeferencia = 'bodegas' and Abreviación <>'#'", cboBodega)

            if (Codigo.Length  > 0)
            {
                txtClienteCod.Text = Codigo;
                var prog = new RetNombre.AdcNomb();
                txtClienteNombre.Text = prog.RetornaNombreDirectorio(Codigo, buscadorDoc.strConxAdcom);
            }

            CargarMalla();
            cargainicial = false;
            txtFechaIn.Focus();
            cargar = true;
            saltar = false;
            // If cboTipoDoc.Items.Count > 0 Then cboTipoDoc.SelectedIndex = 1
        }

        // Metodo para conectar el programa con la base de datos
        private void conectarBDD()
        {
            // Dim coneccion As New DaxLib.DaxLibBases
            // coneccion.TipoBase = "10"
            try
            {
                conexion.ConnectionString = buscadorDoc.strConxAdcom;
            }
            catch
            {
                MessageBox.Show ("No existe conección a la base de datos del AdcomDX_ERP");
            }
        }
        // Metodo para cargar la malla de busqueda
        private void CargarMalla()
        {
            string Bus_PtoVta = "";
            string Bus_tipDoc = "";
            string Bus_suc = "";
            string Bus_bod = "";
            string Bus_client = "";
            string Bus_art = "";
            string Bus_det = "";
            string Bus_valor = "";
            string Bus_tablaDoc = "ADCDOC";
            string Bus_tablaTra = "ADCTRA";
            malla.DataSource = null;
            if (tabla.ToUpper() == "ADCDOCPRO")
            {
                Bus_tablaDoc = "AdcDocpro";
                Bus_tablaTra = "AdcTraPro";
            }

            if (cboTipoDoc.SelectedValue is null)
                return;
            string campo = camp;
            // Dim cls As New ClassDoc.utilDoc(buscadorDoc.strConxAdcom)
            // lassDoc.utilDoc()

            if (estaConsolidando & DocInicial.Length > 3)
            {
                Bus_tipDoc = " and opc_documento in (" + DocInicial + ")";
            }
            else
            {
                Bus_tipDoc = " and opc_documento ='" + cboTipoDoc.SelectedValue.ToString() + "' ";
            }


            // ClassDoc.utilDoc.cadenaConexion = buscadorDoc.strConxAdcom
            // ClassDoc.utilDoc.tablasDeDatos(cboTipoDoc.SelectedValue.ToString(), Bus_tablaDoc, Bus_tablaTra)
            // cls = Nothing
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
                if (cboPtoVenta.SelectedValue.ToString() != "0" & !string.IsNullOrEmpty(cboPtoVenta.SelectedValue.ToString()))
                {
                    Bus_PtoVta = " and puntovta ='" + cboPtoVenta.SelectedValue.ToString() + "' ";
                }
            }
            catch
            {
            }

            if (cboBodega.SelectedValue.ToString() != "0" & !string.IsNullOrEmpty(cboBodega.SelectedValue.ToString()))
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
                Bus_art = " and idClaveDoc in(select DISTINCT idclaveDoc from " + Bus_tablaTra + " where tra_codigo ='" + txtArtCodigo.Text + "') ";
            }

            if (!string.IsNullOrEmpty(txtvalor.Text))
            {
                Bus_valor = " and doc_valor like '%" + txtvalor.Text + "%'";
            }

            if (!string.IsNullOrEmpty(txtNumDoc.Text))
            {
                numero = " and Doc_NroLoteDoc ='" + txtNumDoc.Text + "'";
            }

            string ssql = "select doc_sucursal as SUC, opc_documento as TIP";
            ssql += ",doc_fecha as FECHA,doc_numero as NUM,Doc_NombreImp as NOMBRE, doc_valor as VALOR";
            ssql += ",Doc_detalle as DETALLE,doc_codper, idClaveDoc,isnull(estadosri,'') as EstadoSri  from " + Bus_tablaDoc + "";
            ssql += " where doc_fecha>= '" + txtFechaIn.Text + "' and doc_fecha<= '" + txtFechaFin.Text + " 23:59:59' ";
            ssql += Bus_tipDoc + Bus_suc + Bus_bod + Bus_PtoVta + Bus_client + Bus_art + Bus_det + Bus_valor + numero;
            if (cmbAutorizaciones.SelectedIndex == 2)
            {
                ssql += " and (isnull(EstadoSri,'') = 'Autorizado')";
            }
            else if (cmbAutorizaciones.SelectedIndex == 1)
            {
                ssql += " and (isnull(EstadoSri,'') <> 'Autorizado')";
            }

            if (cmbActivos.SelectedIndex == 2)
            {
                ssql += " and (isnull(doc_estado,0) = 0)";
            }
            else if (cmbAutorizaciones.SelectedIndex == 1)
            {
                ssql += " and (isnull(doc_estado,0) = 1)";
            }

            var dats = new DataSet();
            var datAd = new SqlDataAdapter(ssql, conexion);
            if (conexion.State == ConnectionState.Closed)
                conexion.Open();
            datAd.Fill(dats, "Datos");
            {
                var withBlock = malla;
                withBlock.DataSource = dats.Tables["Datos"];
                withBlock.ClearSelection();
                withBlock.Columns["doc_codper"].Visible = false;
                withBlock.Columns["idclavedoc"].Visible = false;
                withBlock.Columns["fecha"].DefaultCellStyle.Format = "dd/MMM/yyyy";
                withBlock.Columns["Valor"].DefaultCellStyle.Format = "###,###,###,##0.00";
                withBlock.Columns["Detalle"].Visible = false;
            }

            conexion.Close();
        }
        // Metodo para llenar el combo tipo documento
        // Private Sub llenarTipoDoc(ByVal LisTipoDocu As String, ByVal LisOpcDoc As String)
        // Dim ssql As String = ""
        // ' Dim opc(), tipo() As String
        // If tabla = "" Then Exit Sub

        // If LisTipoDocu = "" Then
        // ssql = "select opc_documento,Doc_docnombre from ADCOPC where opc_documento in (" & LisOpcDoc & ") "
        // camp = "opc_documento"
        // Else
        // ssql = "select doc_TipoDoc,Doc_docnombre from ADCOPC  where Doc_TipoDoc in (" & LisTipoDocu & ") group by doc_TipoDoc,doc_docnombre"
        // camp = "doc_TipoDoc"
        // End If

        // Dim dats As New DataSet()
        // Dim datA As New SqlDataAdapter(ssql, conexion)
        // If conexion.State = ConnectionState.Closed Then conexion.Open()
        // datA.Fill(dats, "Datos")
        // cboTipoDoc.DataSource = dats.Tables("Datos")
        // cboTipoDoc.DisplayMember = "Doc_docnombre"
        // If LisTipoDocu = "" Then cboTipoDoc.ValueMember = "opc_documento" Else cboTipoDoc.ValueMember = "Doc_TipoDoc"
        // conexion.Close()
        // End Sub
        // Metodo para llenar los combos Bodega y Sucursal
        // Private Sub llenarBodegaSucurasal(ByVal ssql As String, ByVal cbo As ComboBox)
        // Dim con As New SqlConnection()
        // Dim coneccion As New DaxLib.DaxLibBases
        // coneccion.TipoBase = "10"
        // con.ConnectionString = coneccion.StrDaxsys
        // Dim datS As New DataSet()
        // Dim datA As New SqlDataAdapter(ssql, con)
        // If con.State = ConnectionState.Closed Then con.Open()
        // datA.Fill(datS, "Datos")
        // cbo.DataSource = datS.Tables("Datos")
        // cbo.ValueMember = "Abreviación"
        // cbo.DisplayMember = "Descripcion"
        // con.Close()
        // End Sub

        private void txtFechaIn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                CargarMalla();
                return;
            }
            // If e.KeyCode <> Keys.F2 Then Return
            // Dim progfec As New DaxFechas.DaxFechas
            // Dim lafecha As String = ""
            // txtFechaIn.Text = progfec.DaxFecha(lafecha)
        }

        private void txtFechaFin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                CargarMalla();
                return;
            }
            // If e.KeyCode <> Keys.F2 Then Return
            // Dim progfec As New DaxFechas.DaxFechas
            // Dim lafecha As String = ""
            // txtFechaFin.Text = progfec.DaxFecha(lafecha)
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
            txtvalor.Text = "";
        }
        // Metodo para limpiar la malla
        private void limpiarGrid()
        {
            {
                var withBlock = malla;
                for (int i = withBlock.RowCount - 2; i >= 0; i -= 1)
                {
                    if (i <= withBlock.Rows.Count)
                        withBlock.Rows.RemoveAt(i);
                }
            }
        }

        private void opcionPanel()
        {
        }

        private void cboTipoDoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargar == true)
                CargarMalla();
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
                idClaveDoc = Convert.ToDouble (row.Cells["idClaveDoc"].Value.ToString());
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

            if ("0123456789".IndexOf ((e.KeyChar).ToString()) == -1)
                e.KeyChar = Convert.ToChar ("");
        }

        private void txtNumDoc_TextChanged(object sender, EventArgs e)
        {
            CargarMalla();
        }

        private void btnClienteCod_Click(object sender, EventArgs e)
        {
            var prog = new DaxMantDirectorio.BusDirectorio();
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
            var nombrar = new RetNombre.AdcNomb();
            string nombre = "";
            txtArtCodigo.Text = progbus.Buscar(buscadorDoc.strConxAdcom, "select art_codigo,art_nombre from adcart", "art_codigo", "art_nombre", "", "Busca Artículos");
            txtArticuloNombre.Text = nombrar.RetornaNombreArticulo(txtArtCodigo.Text, buscadorDoc.strConxAdcom);
        }

        private void btnServicioCod_Click(object sender, EventArgs e)
        {
            var progbus = new Buscar.frmBuscar();
            var nombrar = new RetNombre.AdcNomb();
            string nombre = "";
            txtArtCodigo.Text = progbus.Buscar(buscadorDoc.strConxAdcom, "select sev_codigo,sev_nombre from adcserv", "sev_codigo", "sev_nombre", "", "Busca Servicios");
            txtArticuloNombre.Text = nombrar.RetornaNombreServicio(txtArtCodigo.Text, buscadorDoc.strConxAdcom);
        }

        private void txtClienteCod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return & txtClienteCod.TextLength > 0)
                CargarMalla();
        }


        // Private Sub malla_KeyDown(sender As Object, e As KeyEventArgs) Handles malla.KeyDown
        // Dim row As New DataGridViewRow
        // If (e.KeyCode = Keys.F2 Or e.KeyCode = Keys.Space) Then
        // row = malla.CurrentRow
        // If IsNothing(row.HeaderCell.Value) Then row.HeaderCell.Value = "X" : Return
        // If row.HeaderCell.Value.ToString() = "" Then row.HeaderCell.Value = "X" Else row.HeaderCell.Value = ""

        // End If
        // End Sub
    }
}