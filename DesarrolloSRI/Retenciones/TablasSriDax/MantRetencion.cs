using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using SysEmpDatt;
using ClassDoc;
using classMenSistem;
namespace IvaRett
{
    public partial class MantRetencion : Form
    {
        Boolean esSoloConsulta = false;
        int tipoTransaccion = 2; // 1 compras 2 ventas
        internal ClassDoc.AdcDoc DatosDocumento;
        internal idDocumento idDocumentoActual;
        internal DataTable dtDetalleDocumento;
        internal PrySysp13.OpcDoc propiedadesDoc;
        int operacionEnCurso = 0;
        DaxMantDirectorio.DirectorioAlex opalex = new DaxMantDirectorio.DirectorioAlex();
        internal string codCliente = "";
        string TipoDocumentoSoporte;
        daxAccs.propiedadesDaxAuto accesosLocalizados = new daxAccs.propiedadesDaxAuto();
        string UltTipoRetencion = "";
        Boolean esDeLiquidacion = false;
        daxContaDoc.AsientosContables mallaContable = new daxContaDoc.AsientosContables();

        public MantRetencion(int tipoTra, ClassDoc.idDocumento idDocumento, bool esConsulta = false)
        {
            InitializeComponent();
            if (tipoTra == 1)
            {
                tipoTransaccion = tipoTra;
                esSoloConsulta = esConsulta;
                groupBox1.Text = "DATOS PROVEEDOR";
                groupBox1.Text = "DATOS PROVEEDOR";
            }
            else
            {
                groupBox1.Text = "DATOS CLIENTE";
            }
            txtfecha.Value = DateTime.Now;
            llenarCombos();
            CargarValoresIniciales();
        }
        private void CargarValoresIniciales()
        {
            //this.txtfecha.ValueChanged -= new System.EventHandler(this.txtfecha_ValueChanged);

            txtfecha.Value = DateTime.Now;
            propiedadesDoc = new PrySysp13.OpcDoc();
            idDocumentoActual = new idDocumento();
            idDocumentoActual.Tipo = cmbDocumento.SelectedValue.ToString();
            idDocumentoActual.Sucursal = datosEmpresa.suc;
            propiedadesDoc.Cargar(ref idDocumentoActual.Tipo, ref idDocumentoActual.Sucursal);
            idDocumentoActual.familia = propiedadesDoc.TipoDoc;
            txtNroID.Text = "001-001";
            esDeLiquidacion = Convert.ToBoolean(propiedadesDoc.SNLiquidacionGas);
            

            //this.txtfecha.ValueChanged += new System.EventHandler(this.txtfecha_ValueChanged);
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            iniciarNuevoDocumento();
        }
        private void iniciarNuevoDocumento()
        {
            InicializarMalla();
            idDocumentoActual = new idDocumento()
            {
                familia = propiedadesDoc.TipoDoc,
                fecha = txtfecha.Value,
                numero = Convert.ToDouble("0" + txtnumero.Text),
                Serie = txtNroID.Text,
                Sucursal = datosEmpresa.suc,
                Tipo = cmbDocumento.SelectedValue.ToString()
            };
            DatosDocumento = new AdcDoc(datosEmpresa.strConxAdcom);
            ClassDoc.controlNumeracion cnum = new controlNumeracion();
            txtnumero.Text = cnum.NumeroMayor(idDocumentoActual, "", "", "", datosEmpresa.strConxAdcom).ToString();
            operacionEnCurso = 1;
            prepararBotones();
        }
        private void InicializarMalla()
        {
            //this.malla.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.malla_CellValueChanged);
            dtDetalleDocumento = SqlDatos.leerTablaAdcom("select top 1 * from daxsriret where SRI_Sucursal = '' and SRI_Documento = ''  and SRI_IdClaveDoc = 0 order by Doc_Linea ");
            if (dtDetalleDocumento == null) return;
            malla.DataSource = dtDetalleDocumento;
            dtDetalleDocumento.Rows.Add(dtDetalleDocumento.NewRow());
            DiseñarMalla();
            //this.malla.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.malla_CellValueChanged);
        }

        private void limpiarDatos()
        {
            codCliente = "";
            txtnumero.Enabled = true;
            txtcedula.Text = "";
            txtCorreElectronico.Text = "";
            txtDetalle.Text = "";
            txtdireccion.Text = "";
            txtnombrecliente.Text = "";
            txtnumero.Text = "";
            txttelefono.Text = "";
            mensajesDocumento.Text = "";
            idDocumentoActual = new idDocumento();
            ActualizarIdDocumento();
            dtDetalleDocumento = new DataTable();
            malla.DataSource = null;
            edTotal.Text = "0.00";
            operacionEnCurso = 0;
            prepararBotones();
        }
        private void ActualizarIdDocumento()
        { 
            try
            {
                if (idDocumentoActual == null) idDocumentoActual = new idDocumento();
                idDocumentoActual.fecha = txtfecha.Value;
                idDocumentoActual.Sucursal = datosEmpresa.suc;
                idDocumentoActual.Tipo = cmbDocumento.SelectedValue.ToString();
                idDocumentoActual.Serie = txtNroID.Text;
                idDocumentoActual.familia = propiedadesDoc.TipoDoc;
            }catch{}
        }
        
        private void prepararBotones()
        {
            Boolean inicio = (operacionEnCurso == 0);
            Boolean nuevo = (operacionEnCurso == 1);
            Boolean modificando = (operacionEnCurso == 2);
            Boolean docAnulado = false;

            try
            {
                docAnulado = (DatosDocumento.Doc_Estado == 0 && modificando);
            }
            catch { }

            btnAbre.Enabled = inicio;
            btnNuevo.Enabled = inicio;

            btnAnula.Enabled = (modificando && !docAnulado);
            btnElimina.Enabled = modificando;
            btnEnviar.Enabled = modificando;
            btnGraba.Enabled = (!inicio && !docAnulado);
            btnRegistra.Enabled = btnGraba.Enabled;
            btnEnviar.Enabled = (modificando && !docAnulado);
            btnCierra.Enabled = !inicio;
            btnContabiliza.Enabled = btnGraba.Enabled;
            panel1.Enabled = (!inicio);
            malla.Enabled = (!inicio);

            cmbDocumento.Enabled = (inicio);
            txtcedula.Enabled = (!docAnulado);

            if (DatosUsuario.Identifica.ToUpper() == "ADMINISTRADOR") return;
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
                btnEnviar.Enabled = (btnEnviar.Enabled && accesosLocalizados.Imprimir); //(accesosLocalizados.Imprimir && !inicio);
                btnNuevo.Enabled = (accesosLocalizados.Crear && btnNuevo.Enabled);
                btnElimina.Enabled = (accesosLocalizados.Eliminar && btnElimina.Enabled);
                btnAnula.Enabled = (accesosLocalizados.Anular && btnAnula.Enabled);


            }
            registrarAccesosLocalizadosDocumento();

            if (esSoloConsulta == true || docAnulado)
            {
                btnGraba.Enabled = false;
                btnRegistra.Enabled = false;
                btnElimina.Enabled = false;
                btnAnula.Enabled = false;
                if (DatosDocumento.Doc_Estado == 1) btnElimina.Enabled = (DatosUsuario.Identifica.ToUpper() == "ADMINISTRADOR");
            }
        }

        private void registrarAccesosLocalizadosDocumento()
        {
            if (accesosLocalizados.sinRegistro) return;

            txtnumero.Enabled = accesosLocalizados.NúmeroDocumento;
            txtNroID.Enabled = txtnumero.Enabled;
            txtfecha.Enabled = accesosLocalizados.FechaDocumento;
        }

        private void llenarCombos()
        {
            string tipoRetencion = "RTP";
            TipoDocumentoSoporte = "FAPNCPNDP";
            if (tipoTransaccion == 2) { tipoRetencion = "RTC";  TipoDocumentoSoporte = "FACNCCNDC"; }
            DaxCombobx.CargCmbBox  dcombo = new DaxCombobx.CargCmbBox();
            dcombo.DaxCombosDoc(tipoRetencion , "" , false, datosEmpresa.strConxAdcom, ref cmbDocumento);
            cmbDocumento.SelectedIndex = 0;
        }
        private void DiseñarMalla()
        {

            malla.Columns["SRI_Sucursal"].Visible = false;
            malla.Columns["SRI_Documento"].Visible = false;
            malla.Columns["SRI_IdClaveDoc"].Visible = false;
            malla.Columns["SRI_NumeroRetencion"].Visible = false;
            malla.Columns["Doc_IdClave"].Visible = false;
            malla.Columns["Doc_Linea"].Visible = false;
            malla.Columns["Doc_CodSri"].Visible = false;
            malla.Columns["DOC_Sucursal"].Visible = false;

            malla.Columns["TipoRetencion"].HeaderText = "TipoRet";
            malla.Columns["Doc_OpcDocumento"].HeaderText = "Doc";
            malla.Columns["Doc_Numero"].HeaderText = "Número";
            malla.Columns["CodigoRetencion"].HeaderText = "CodReten";
            malla.Columns["PorcRetencion"].HeaderText = "Porc";
            malla.Columns["BaseExcentaIva"].HeaderText = "BaExeIva";
            malla.Columns["BaseIvaCero"].HeaderText  = "BaIvaCero";

            malla.Columns["TipoRetencion"].ReadOnly = true;

            malla.Columns["Doc_OpcDocumento"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            malla.Columns["Doc_Numero"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            malla.Columns["TipoRetencion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            malla.Columns["CodigoRetencion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }

        private void btnBuscaCliente_Click(object sender, EventArgs e)
        {
            BuscaCliente(txtnombrecliente.Text);

        }
        private void BuscaCliente(string buscador)
        {
            DaxMantDirectorio.BusDirectorio  directorio = new DaxMantDirectorio.BusDirectorio();
            string cliente = "C";
            if (tipoTransaccion == 1) cliente = "P";
            string nombre = "";
            string codigo = directorio.BusDirect ("", "",ref nombre ,"",cliente);
            if ((codigo + "").Length > 0) cargarDatosCliente(codigo);
        }
        private void cargarDatosCliente(string codigo = "")
        {
            if (codigo != "")
            {
                string solocodigo = "";
                Boolean x = false;
                opalex = new DaxMantDirectorio.DirectorioAlex();
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


        #region manejo malla
        private void malla_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            foreach (DataGridViewRow rr in malla.Rows)
            {
                rr.HeaderCell.Value = (rr.Index + 1).ToString();
            }
        }
        private String TipoRetencion()
        {
            if (UltTipoRetencion == NomTipoRetencion.RetFuente || UltTipoRetencion.Length == 0)
            { UltTipoRetencion = NomTipoRetencion.IvaBienes; }
            else if (UltTipoRetencion == NomTipoRetencion.IvaBienes)
            { UltTipoRetencion = NomTipoRetencion.IvaServicios; }
            else { UltTipoRetencion = NomTipoRetencion.RetFuente; }
            return UltTipoRetencion;
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
            if (keyData == Keys.Delete && malla.Focused) { EliminarLinea(); return true; };
            return false;
        }
        private void EliminarLinea()
        {
            malla.Rows.Remove(malla.CurrentRow);
            totalizar();
        }

        private void moverCeldaMalla(DataGridViewCell cell)
        {
            Int32 columnIndex = cell.ColumnIndex;
            Int32 rowIndex = cell.RowIndex;
            Int32 col = columnIndex;
            Int32 row = rowIndex;
            Int32 colOk = -1;


            if (col < malla.Columns.Count)
            {
                for (int i = col + 1; i < malla.Columns.Count - 1; i++)
                {
                    if (malla.Columns[i].Visible == true && malla.Columns[i].ReadOnly == false && malla.Columns[i].Name.ToUpper() != "DESCRIPCIÓN") { colOk = i; break; }
                }
            }

            if (colOk == -1)
            {                
                for (int i = 0 + 1; i < malla.Columns.Count - 1; i++)
                {
                    if (malla.Columns[i].Visible == true && malla.Columns[i].ReadOnly == false ) { colOk = i; break; }
                }

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
            col = colOk;
            malla.CurrentCell = malla.Rows[row].Cells[col];
        }

        #endregion manejo malla
        private Boolean funcionesEspeciales(ref Keys keyData, DataGridView malla)
        {
            Boolean resp = true;
            malla.EndEdit();
            DataGridViewCell cell = malla.CurrentCell;
            DataGridViewRow row = malla.CurrentRow;
            string dato = cell.Value.ToString();
            string nombreCelda = cell.OwningColumn.Name;
            string TipoDeRetencion = row.Cells["TipoRetencion"].Value.ToString();
            if (nombreCelda.ToUpper() == "DOC_OPCDOCUMENTO" || nombreCelda.ToUpper() == "DOC_NUMERO" )
            {
                if (keyData == Keys.F2)
                {
                    dato = cell.Value.ToString();
                    BuscadorDocumentos.BuscDocSoporte buscDoc = new BuscadorDocumentos.BuscDocSoporte(TipoDocumentoSoporte, codCliente);
                    idDocumento idclavsop = buscDoc.BuscarDocParaRetencion();
                    keyData = Keys.Return;
                    if (idclavsop.numero > 0 )  SubirDatosDocumentoSustento(idclavsop);
                }
            }
            else if (nombreCelda == "TipoRetencion")
            {
                if (keyData == Keys.F2) dato = TipoRetencion();
            }
            else if (nombreCelda == "CodigoRetencion" || nombreCelda == "PorcRetencion")
            {
                if (keyData == Keys.F2)
                {
                    if (TipoDeRetencion == "RetFuente") 
                    { 
                        dato = buscarCodigoRetencion(row, nombreTablas.ConceptosRetencion); 
                    }
                    else if (TipoDeRetencion == "IvaBienes")
                    {
                        dato = buscarCodigoRetencion(row, nombreTablas.RetencionIvaBienes);
                    }
                    else if (TipoDeRetencion == "IvaServicios")
                    {
                        dato = buscarCodigoRetencion(row, nombreTablas.RetencionIvaServicios);
                    }
                }
            }

            if (cell.Value.ToString() != "") { keyData = Keys.Return; } else { keyData = Keys.Cancel; }
            totalizar();
            return resp;
        }

        private string buscarCodigoRetencion(DataGridViewRow row,string nombreTabla)
        {
            string dato = "";
            double valor = 0;
            FrmBuscar tabSri = new FrmBuscar();
//            nombreTablas tabNom = new nombreTablas();
            string nombre = "";
            dato = tabSri.Buscar(Convert.ToInt16( tipoTransaccion) , nombreTabla, ref nombre, ref valor);
         //   string ssql = tabNom.armarConsulta(nombreTablas. ConceptosRetencion, txtfecha.Value.ToShortDateString(), 0, 0, 0);
            tabSri.Dispose();
            if (dato.Length > 0)
            {
                row.Cells["CodigoRetencion"].Value = dato;
                row.Cells["PorcRetencion"].Value = valor;
            }
            totalizar();
            return dato;
        }
        private void SubirDatosDocumentoSustento(idDocumento IdDocSustento)
        {
            decimal MontoIvaBienes = 0;
            decimal MontoIvaServicios = 0;
            decimal MontoBienes = 0;
            decimal MontoServicios = 0;
            decimal DescuentosIva = 0;
            decimal DescuentosSinIva = 0;
            decimal Auxnum = 0;
            decimal Descuento = 0;
            decimal TotDescCiva = 0;
            decimal porceniva = 0;
//            string TipoRetencion="";
            using (SqlConnection conn = new SqlConnection(datosEmpresa.strConxAdcom))
            {
                //string ssql = "SriDocSus " + IdDocSustento.Sucursal + "','" + IdDocSustento.Tipo + "'," + IdDocSustento.idClave.ToString() + "'";// @SUC AS VARCHAR(3), @OPC AS VARCHAR(3), @IDCLAVEDOC AS decimal"
                SqlDataReader rs;
                using (SqlCommand comm = new SqlCommand("SriDocSus", conn))
                {         
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.Parameters.AddWithValue("@SUC", IdDocSustento.Sucursal);
                    comm.Parameters.AddWithValue("@OPC", IdDocSustento.Tipo);
                    comm.Parameters.AddWithValue("@IDCLAVEDOC", IdDocSustento.idClave);
                    conn.Open();
                    rs = comm.ExecuteReader ();
                    if (rs.Read())
                    {
                        MontoIvaBienes = Convert.ToDecimal(rs["MontoIvaBienes"]);
                        MontoIvaServicios = Convert.ToDecimal(rs["MontoIvaServicios"]);
                        MontoBienes = Convert.ToDecimal(rs["MontoBienes"]);
                        MontoServicios = Convert.ToDecimal(rs["MontoServicios"]);
                        DescuentosIva = Convert.ToDecimal(rs["doc_TotDesCIva"]);
                        DescuentosSinIva = Convert.ToDecimal(rs["doc_TotDesSiva"]);
                        Descuento = Convert.ToDecimal(rs["descuento"]);
                        Auxnum = MontoBienes + MontoServicios;
                        TotDescCiva = Convert.ToDecimal(rs["doc_TotDesCIva"]);
                        porceniva = Convert.ToDecimal(rs["Doc_porceniva"]);
                    }
                    conn.Close();
                }
            }


            if (Auxnum > 0 && Descuento > 0)
            {
                MontoBienes = Math.Round((MontoBienes - (MontoBienes / Auxnum) * Descuento), 2);
                MontoServicios = Math.Round((MontoServicios - (MontoServicios / Auxnum) * Descuento), 2);
            }
            else
            {
                MontoBienes = Math.Round(MontoBienes, 2);
                MontoServicios = Math.Round (MontoServicios, 2);
            }

            decimal MontoBienesIva;
            decimal MontoServiciosIva;
            decimal MontoBienesIvaCero;
            decimal MontoServiciosIvaCero; 

            if (Auxnum > 0 && TotDescCiva  > 0)
            {
                MontoBienesIva = Math.Round ((MontoIvaBienes - (MontoIvaBienes / Auxnum) * TotDescCiva), 2);
                MontoServiciosIva = Math.Round ((MontoIvaServicios - (MontoIvaServicios / Auxnum) * TotDescCiva), 2);
            }
            else
            {
                MontoBienesIva = Math.Round(MontoIvaBienes, 2);
                MontoServiciosIva = Math.Round(MontoIvaServicios, 2);
            }
            MontoIvaBienes = Math.Round (MontoBienesIva * porceniva / 100, 2);
            MontoIvaServicios = Math.Round(MontoServiciosIva * porceniva / 100, 2);
            MontoBienesIvaCero = MontoBienes - MontoBienesIva;
            MontoServiciosIvaCero = MontoServicios - MontoServiciosIva;
            //                                      
            DataGridViewRow rowrf = malla.CurrentRow;
           if(rowrf.Cells["Doc_OpcDocumento"].Value.ToString () != "" && Convert.ToDouble ("0"+rowrf.Cells["Doc_IdClave"].Value.ToString())>0 )
            {
                if (MessageBox.Show("Desea reemplazar los valores existentes por el nuevo documento ? ", "Registro de retenciones ", MessageBoxButtons.YesNo) == DialogResult.No) return;
            }

            rowrf.Cells["Doc_Sucursal"].Value = IdDocSustento.Sucursal;
            rowrf.Cells["Doc_OpcDocumento"].Value = IdDocSustento.Tipo;
            rowrf.Cells["Doc_Numero"].Value = IdDocSustento.numero;
            rowrf.Cells["Doc_IdClave"].Value = Convert.ToDecimal(IdDocSustento.idClave);
            rowrf.Cells["Doc_CodSri"].Value = ""; //buscar codigo sri en adcopc
            rowrf.Cells["CodigoRetencion"].Value ="";

            rowrf.Cells["TipoRetencion"].Value = "RetFuente";
            rowrf.Cells["BaseRetencion"].Value = Convert.ToDecimal (MontoBienesIva + MontoServiciosIva);
            rowrf.Cells["BaseConIva"].Value = Convert.ToDecimal(MontoBienesIva + MontoServiciosIva);
            rowrf.Cells["BaseExcentaIva"].Value = Convert.ToDecimal(MontoBienesIvaCero + MontoServiciosIvaCero);
            rowrf.Cells["BaseIvaCero"].Value = 0;

            if (MontoIvaBienes > 0)
            {
                ((DataTable)malla.DataSource).Rows.Add();
                DataGridViewRow rowib = malla.Rows[malla.Rows.Count - 1];
                LibMalla.copiarLinea(rowrf, rowib);

                rowib.Cells["TipoRetencion"].Value = "IvaBienes";
                rowib.Cells["BaseRetencion"].Value = MontoIvaBienes;
                rowib.Cells["BaseConIva"].Value = MontoIvaBienes;
                rowib.Cells["BaseExcentaIva"].Value = 0;
                rowib.Cells["BaseIvaCero"].Value = 0;
            }

            if (MontoIvaServicios > 0)
            {
                ((DataTable)malla.DataSource).Rows.Add();
                DataGridViewRow rowis = malla.Rows[malla.Rows.Count - 1];
                LibMalla.copiarLinea(rowrf, rowis);

                rowis.Cells["TipoRetencion"].Value = "IvaServicios";
                rowis.Cells["BaseRetencion"].Value = MontoIvaServicios;
                rowis.Cells["BaseConIva"].Value = MontoIvaServicios;
                rowis.Cells["BaseExcentaIva"].Value = 0;
                rowis.Cells["BaseIvaCero"].Value = 0;
            }
        }
        private void ponerDatosRtencionFuente(string codRetencion, DataGridViewRow row, string strConxIvaret)
        {
            malla.EndEdit();
            if (codRetencion.Length == 0) return;
            nombreTablas tabNom = new nombreTablas();
            string ssql = tabNom.armarConsulta(nombreTablas.ConceptosRetencion, txtfecha.Value.ToShortDateString(), 0, 0, 0);
            ssql += " and Código = '" + codRetencion + "'";
            DataTable dt = SqlDatos.leerTablaIvaret(ssql);
            if (dt.Rows.Count > 0)
            {
                row.Cells["Descripción"].Value = dt.Rows[0]["Descripción"].ToString();
                row.Cells["Porcentaje"].Value = dt.Rows[0]["Porcentaje"].ToString();
                //totalizar();
            }
            else
            {
                MessageBox.Show("El código digitado no existe", "Valida codigo retención", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            tabNom = null;
            dt.Dispose();
        }
        private void totalizar()
        {
            Double totalizar = 0;
            double retenido = 0;
            if (malla.CurrentCell != null)
            {
                double ValReten = 0;
                DataGridViewRow row = malla.Rows[malla.CurrentCell.RowIndex ];
                ValReten = Convert.ToDouble(row.Cells["BaseRetencion"].Value) * Convert.ToDouble(row.Cells["PorcRetencion"].Value)/100;
                row.Cells["ValorRetencion"].Value = ValReten;
            }
            foreach (DataGridViewRow row in malla.Rows)
            {
                retenido = Convert.ToDouble("0" + row.Cells["ValorRetencion"].Value);
                totalizar += retenido;
            }
            edTotal.Text = totalizar.ToString("0.00");
        }

        private void btnAbre_Click(object sender, EventArgs e)
        {
            BuscadorDocumentos.buscadorDoc progBus = new BuscadorDocumentos.buscadorDoc();
//            idDocumentoActual.Sucursal = datosEmpresa.suc;
            progBus.IniciaBusqueda(propiedadesDoc.TipoDoc, "", cmbDocumento.SelectedValue.ToString(), DateTime.Now, ref idDocumentoActual.Sucursal, ref idDocumentoActual.Tipo, ref idDocumentoActual.numero, ref idDocumentoActual.idClave, false, cmbDocumento.SelectedValue.ToString(), "", "", "ADCDOC");
            if (idDocumentoActual.idClave == 0) { ActualizarIdDocumento(); return; }
            if (idDocumentoActual.Sucursal.ToUpper() != datosEmpresa.suc.ToUpper()) { mensajesErrorDocumento.documentosNoDeOtraSucursal(datosEmpresa.sucNom); return; }
            if (idDocumentoActual.idClave != 0) CargarDatosRetencion(idDocumentoActual);
        }
        private bool CargarDatosRetencion(idDocumento id)
        {
            string ssql = " DOC_Sucursal = '" + idDocumentoActual.Sucursal + "' and opc_Documento = '" + idDocumentoActual.Tipo + "' ";
            if (id.idClave == 0) { ssql += " and Doc_NroIdDoc = '" + txtNroID.Text + "' and doc_numero = " + id.numero.ToString(); }
            else { ssql += " and IdClaveDoc = " + idDocumentoActual.idClave.ToString(); }
         
            DatosDocumento = new AdcDoc(datosEmpresa.strConxAdcom);
            DatosDocumento = AdcDoc.Buscar(ssql);

            if (DatosDocumento == null)
            { 
                MessageBox.Show("El documento "+idDocumentoActual.Sucursal+"/"+idDocumentoActual.Tipo +"/"+idDocumentoActual.Serie +"/"+idDocumentoActual.numero.ToString() + " no existe");
                return false;
            }

            idDocumentoActual.idClave = Convert.ToDouble(DatosDocumento.IdClaveDoc);
            idDocumentoActual.numero = Convert.ToDouble(DatosDocumento.Doc_numero);
            idDocumentoActual.Serie = DatosDocumento.Doc_NroIdDoc;

            txtNroID.Text = DatosDocumento.Doc_NroIdDoc;
            txtnumero.Text = DatosDocumento.Doc_numero.ToString();
            txtNroAutorizacion.Text = DatosDocumento.NroAutorizacionSri;
            txtfecha.Value = DatosDocumento.Doc_fecha;
            cargarDatosCliente(DatosDocumento.Doc_codper);
            ssql = "select * from daxsriret where SRI_Sucursal = '" + idDocumentoActual.Sucursal + "' and SRI_Documento = '" + idDocumentoActual.Tipo + "'  and SRI_IdClaveDoc = " + idDocumentoActual.idClave.ToString() + " order by Doc_Linea ";
            dtDetalleDocumento = SqlDatos.leerTablaAdcom(ssql);
            malla.DataSource = dtDetalleDocumento;
            DiseñarMalla();
            totalizar();
            return true;
        }
        private void malla_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (malla.Columns[e.ColumnIndex].Name == "TipoRetencion") malla.CurrentCell.Value = TipoRetencion();
        }

        private void btnElimina_Click(object sender, EventArgs e)
        {
             adcDocumentos.anulaElimina classAnular = new adcDocumentos.anulaElimina();
            if (classAnular.eliminarDocumento(datosEmpresa.strConxAdcom, datosEmpresa.strConxDaxsys, idDocumentoActual, DatosUsuario.Identifica,esDeLiquidacion, datosEmpresa.Emp_Nombre, datosEmpresa.Emp_codigo.ToString(), edTotal.Text, "ADCDOC", propiedadesDoc.ComandoExterno)) limpiarDatos();
            classAnular = null;
            limpiarDatos();
        }

        private void btnAnula_Click(object sender, EventArgs e)
        {
            adcDocumentos.anulaElimina classAnular = new adcDocumentos.anulaElimina();
            if (classAnular.anularDocumento(datosEmpresa.strConxAdcom, datosEmpresa.strConxDaxsys, idDocumentoActual, DatosUsuario.Identifica, esDeLiquidacion , datosEmpresa.Emp_Nombre, datosEmpresa.Emp_codigo.ToString(), edTotal.Text, "ADCDOC", propiedadesDoc.ComandoExterno)) limpiarDatos();
            classAnular = null;
            limpiarDatos();
        }

        private void btnCierra_Click(object sender, EventArgs e)
        {
            limpiarDatos();           
        }

        private void btnContabiliza_Click(object sender, EventArgs e)
        {            
            DatosRetencion.moverDatosAclase(this);
            daxContaDoc.frmVisContab progCtb = new daxContaDoc.frmVisContab(mallaContable, DatosDocumento, (DataTable)malla.DataSource, propiedadesDoc);
            mallaContable = progCtb.IniciarRevisionContable();
            //            progCtb.GenerarContabilidadDocumento(DatosDocumento, (DataTable)malla.DataSource, propiedadesDoc, null, "");
            progCtb.Dispose();
        }

        private void btnGraba_Click(object sender, EventArgs e)
        {
            DatosRetencion.moverDatosAclase(this);
            //ValidacionDocmtosBancos valdoc = new ValidacionDocmtosBancos();
           // if (valdoc.validaEgresoBanco(DatosDocumento, malla, DatosUsuario.codigo) == true)
            {
                if (grabarDocumento() == true)
                {
                    limpiarDatos();
                }
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
                    if (DatosDocumento.Doc_numero == 0) return false;
                    res = DatosDocumento.Crear();
                    if (res.Substring(0, 3) != "ERR")
                    {
                        txtnumero.Text = DatosDocumento.Doc_numero.ToString();
                        idDocumentoActual.idClave = Convert.ToDouble(DatosDocumento.IdClaveDoc);
                        idDocumentoActual.numero = Convert.ToDouble(DatosDocumento.Doc_numero);
                        DatosRetencion.GuardarDetalleDoc(DatosDocumento,malla);
                        if (propiedadesDoc.SNContabilizar > 0)
                        {
                            if (mallaContable.ListDetalleContab.Count > 0)
                            {
                                mallaContable.GrabarDetalleContable(malla, idDocumentoActual);
                            }
                            else
                            {
                                daxContaDoc.contabilizaDocumento ctb = new daxContaDoc.contabilizaDocumento();
                                mallaContable = ctb.GenerarContabilidadDocumento(DatosDocumento, (DataTable)malla.DataSource, propiedadesDoc, null, "");
                                mallaContable.GrabarDetalleContable(idDocumentoActual);
                            }
                        }
                        registraEvntos.registrar.registraEventoDoc(datosEmpresa.strConxDaxsys, datosEmpresa.codEmpresa.ToString(), datosEmpresa.usr, "MDD", Environment.MachineName, registraEvntos.registrar.EvntCrear, idDocumentoActual.Sucursal, idDocumentoActual.Tipo, idDocumentoActual.numero.ToString(), DatosDocumento.Doc_valor.ToString());
                    }
                    else { DatosDocumento.Borrar();}
                }
                else
                {
                    res = DatosDocumento.Actualizar();
                    if (res.Substring(0, 3) != "ERR")
                    {
                        DatosRetencion.GuardarDetalleDoc(DatosDocumento, malla);
                        registraEvntos.registrar.registraEventoDoc(datosEmpresa.strConxDaxsys, datosEmpresa.codEmpresa.ToString(), datosEmpresa.usr, "MDD", Environment.MachineName, registraEvntos.registrar.EvntModifica, idDocumentoActual.Sucursal, idDocumentoActual.Tipo, idDocumentoActual.numero.ToString(), DatosDocumento.Doc_valor.ToString());
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

        private void btnRegistra_Click(object sender, EventArgs e)
        {
            DatosRetencion.moverDatosAclase(this);
            //ValidacionDocmtosBancos valdoc = new ValidacionDocmtosBancos();
            //if (valdoc.validaEgresoBanco(DatosDocumento, malla, DatosUsuario.codigo) == true)
            //{
                if (grabarDocumento() == true)
                {
                    ImpresionesDeldocumento("", true);
                    limpiarDatos();
                }
            //}

        }
        private void ImpresionesDeldocumento(string OtroFormato = "", bool ImpresionDirecta = false)
        {
            if (accesosLocalizados.NroImpresiones > 0 && accesosLocalizados.NroImpresiones <= DatosDocumento.Doc_Adicional1)
            { MessageBox.Show("Ha llegado al límite de impresiones permitidas", "Imprimir documentos", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            ImpresionDocumentosDax.ImprimeDocumentoDoble impProg = new ImpresionDocumentosDax.ImprimeDocumentoDoble(datosEmpresa.nombreBaseIvaret, datosEmpresa.strConxAdcom, datosEmpresa.strConxIvaret, datosEmpresa.strConxDaxsys, datosEmpresa.strConxDaxpro, datosEmpresa.codEmpresa, datosEmpresa.pathServer);
            int imp = 0;
            if (ImpresionDirecta)
            {
                imp = impProg.ImpDocFast(idDocumentoActual, "A", OtroFormato, false, true);
            }
            else
            {
                imp = impProg.ImpDoc(idDocumentoActual, "A", OtroFormato, false, false);
            }
            DatosDocumento.Doc_Adicional1 = imp;
        }


        private void btnEnviar_Click(object sender, EventArgs e)
        {
            ImpresionesDeldocumento("");
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void txtnumero_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return && txtnumero.TextLength > 0)
            {
                idDocumentoActual.numero = Convert.ToDouble(txtnumero.Text);
                idDocumentoActual.Serie = txtNroID.Text;
                CargarDatosRetencion(idDocumentoActual);
            }
        }

        private void cmbDocumento_SelectedValueChanged(object sender, EventArgs e)
        {
            ActualizarIdDocumento();
        }
    }
}
