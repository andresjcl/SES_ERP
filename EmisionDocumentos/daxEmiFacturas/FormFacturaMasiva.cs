using System;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Windows.Forms;
using DattCom;
using ClassDoc;

namespace DctosEmi
{
    public partial class FormFacMasivva : Form
    {
        
        idDocumento idDocumentoActual = new idDocumento();
        bool RegistradoNroFactura = false;
        DataTable data = new DataTable();
        SqlDataAdapter DatAdapter;
        internal DaxComercia.classPagosDoc clasePagos = new DaxComercia.classPagosDoc();
        internal adcDescto.descDocumento claseDescuentos = new adcDescto.descDocumento();
        internal IvaRett.docImpuestos claseImpuestos = new IvaRett.docImpuestos();

        public FormFacMasivva()
        {
            InitializeComponent(); 
            iniciarValores(); 
            CargarNumeroInicialDeFactura(); 
        }
        private void iniciarValores() 
        {
            Text = " SES -" + datosEmpresa.nomEmpresa + " - EMISION MASIVA DE FACTURAS DESDE OTROS DOCUMENTOS " ;
            DaxCombobx.CargCmbBox cmb = new DaxCombobx.CargCmbBox();
            cmb.DaxCombosDoc("FAC", "", false, datosEmpresa.strConxAdcom, ref cmbDocumento);
            cmbDocumento.SelectedIndex = 0;
            dtFechaLiquidaIni.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtFechaLiquidaFin.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
            dtFechaFactura.Value = DateTime.Now;
        }
        private void CargarNumeroInicialDeFactura()
        {
            RecargarClaveDocumento();
            ClassDoc.controlNumeracion cnum = new controlNumeracion();           
            txtnumero.Text = cnum.NumeroMayor(idDocumentoActual, "", "", "", datosEmpresa.strConxAdcom).ToString();
            idDocumentoActual.numero = Convert.ToDouble(txtnumero.Text);
        }

        private void RecargarClaveDocumento()
        {
            try
            {
                idDocumentoActual = new idDocumento
                {
                    familia = "FAC",
                    fecha = dtFechaFactura.Value,
                    numero = Convert.ToDouble(txtnumero.Text),
                    Serie = txtNroID.Text,
                    Sucursal = datosEmpresa.suc,
                    Tipo = cmbDocumento.SelectedValue.ToString(),
                };

            }
            catch { }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            panel4.Visible = !panel4.Visible;
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
           mallExp.exportarDataGridView expor = new mallExp.exportarDataGridView();
            expor.Exportar(ListaDocPorFacturar, "I", datosEmpresa.Emp_Nombre, "LISTA DE DOCUENTOS PARA GENERAR FACTURAS");                       
        }

        private void btnAbre_Click(object sender, EventArgs e)
        {
            cargarMalla();
        }
        private void cargarMalla()
        { 
            string ssql = "FacMasDoc '" + dtFechaLiquidaIni.Value.ToShortDateString() + "','" + dtFechaLiquidaFin.Value.ToShortDateString() + "'";
            SqlDatos.ejecutarComandoAdcom(ssql);

            ssql = "select * from DaxGenMasFac";
            DatAdapter = new SqlDataAdapter(ssql, datosEmpresa.strConxAdcom);
            data = SqlDatos.leerTablaAdcom(ssql);
            ListaDocPorFacturar.DataSource = data;
            diseñaMalla();

        }
        private void diseñaMalla()
        {
            ListaDocPorFacturar.Columns["Doc_codper"].HeaderText = "IdCliente";
            ListaDocPorFacturar.Columns["Doc_NombreImp"].HeaderText = "Nombre Cliente";
            ListaDocPorFacturar.Columns["Doc_sucursal"].HeaderText = "SUC";
            ListaDocPorFacturar.Columns["OPC_DOCUMENTO"].HeaderText = "DOC";
            ListaDocPorFacturar.Columns["DOC_NUMERO"].HeaderText = "Numero";
            ListaDocPorFacturar.Columns["DOC_FECHA"].HeaderText = "Fecha";
            ListaDocPorFacturar.Columns["IdClaveDoc"].Visible = false;
            ListaDocPorFacturar.Columns["doc_venabre"].Visible = false;
            ListaDocPorFacturar.Columns["doc_ciruc"].Visible = false;
            ListaDocPorFacturar.Columns["doc_direccion"].Visible = false;
            ListaDocPorFacturar.Columns["IdRegistro"].Visible = false;
        }

        private void txtNroID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtNroID.TextLength > 0) CargarNumeroInicialDeFactura();
        }

        private void btnPonerNroFactura_Click(object sender, EventArgs e)
        {
            ListaDocPorFacturar.EndEdit();
            double NroInicial=0 ;
            Color color = Color.LightGray;
            string clienteAnterior = "";
            Boolean consolidaAnterior = false;
            try
            {
                NroInicial = Convert.ToDouble(txtnumero.Text)-1;
            }
            catch { MessageBox.Show("El numero inicial de Factura no es correcto");return; }            
            double NroAnterior = NroInicial;
            foreach (DataGridViewRow dgvrow in ListaDocPorFacturar.Rows)
            {
                if (dgvrow.Cells["Doc_codper"].Value.ToString() == clienteAnterior)
                {
                    if (!(Convert.ToBoolean(dgvrow.Cells["Consolidafactura"].Value) == true && Convert.ToBoolean(dgvrow.Cells["Consolidafactura"].Value) == consolidaAnterior))
                    {
                        NroAnterior++;
                        if (color == Color.White) color = Color.LightGray; else color = Color.White;
                    }
                }
                else
                {
                    NroAnterior++;
                    if (color == Color.White) color = Color.LightGray; else color = Color.White;
                }
                clienteAnterior=dgvrow.Cells["Doc_codper"].Value.ToString();
                consolidaAnterior = Convert.ToBoolean(dgvrow.Cells["Consolidafactura"].Value);
                dgvrow.DefaultCellStyle.BackColor = color;
                dgvrow.Cells["NroFactura"].Value = NroAnterior;
            }
            RegistradoNroFactura = true;
        }

        private void btnEliminaDocumento_Click(object sender, EventArgs e)
        {
            if (ListaDocPorFacturar.CurrentRow == null) return;
            if (MessageBox.Show("Confirma eliminar los documentos selccionados ? " + verificaNumerado(), "Eliminar documento a facturar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            foreach (DataGridViewRow row in ListaDocPorFacturar.SelectedRows)
            {
                ((DataTable)ListaDocPorFacturar.DataSource).Rows.RemoveAt(row.Index);
            }
            BorrarNroFactura();
        }
        private void BorrarNroFactura()
        {
            foreach (DataGridViewRow dgvrow in ListaDocPorFacturar.Rows)
            {
                dgvrow.DefaultCellStyle.BackColor = Color.White;
                dgvrow.Cells["NroFactura"].Value = 0;
            }
            RegistradoNroFactura = false;
        }
        private string verificaNumerado()
        {
            if (RegistradoNroFactura)
            {
                return  "\nDeberá reasignar los números de factura ";                
            }
            return "";
        }

        private void btnConsultarDoc_Click(object sender, EventArgs e)
        {
            if (ListaDocPorFacturar.CurrentCell == null) return;
            sesSys.OpcDoc opcd = new sesSys.OpcDoc();

            DataGridViewRow dgvRow = ListaDocPorFacturar.CurrentRow;
            opcd.Cargar(dgvRow.Cells["opc_documento"].Value.ToString());
            idDocumento idconsulta = new idDocumento
            {
                idClave = Convert.ToDouble(dgvRow.Cells["idClaveDoc"].Value),
                Sucursal = dgvRow.Cells["doc_sucursal"].Value.ToString(),
                Tipo = dgvRow.Cells["Opc_documento"].Value.ToString()
            };
            if (idconsulta.idClave == 0 || idconsulta.Sucursal.Trim() == "" || idconsulta.Tipo.Trim() == "") return;
            if (opcd.tablaDatosDoc.ToUpper ()=="ADCDOC")
            {
                FormFactCliente prog = new FormFactCliente(opcd.TipoDoc,opcd.Documento,false,true,false,false,idconsulta);
                prog.ShowDialog();
            }
            else
            {
                FormProforma prog = new FormProforma(opcd.TipoDoc, opcd.Documento, false, true, false, false, idconsulta);
                prog.ShowDialog();

            }
        }

        private void cmbDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarNumeroInicialDeFactura();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ListaDocPorFacturar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnGraba_Click(object sender, EventArgs e)
        {
            int i = 0;
            Int32 nro = 0;
            foreach (DataGridViewRow dvrow in ListaDocPorFacturar.Rows )
            {
                try
                {
                    nro = Convert.ToInt32(dvrow.Cells["NroFactura"].Value);
                }catch{ nro = 0; }
                if (nro > 0)
                {
                    i++;
                    string ssql = "update daxgenmasfac set NroFactura = '" + dvrow.Cells["NroFactura"].Value.ToString() + "'";
                    if (Convert.ToBoolean (dvrow.Cells["consolidaFactura"].Value) == true) ssql += " , consolidaFactura = 1 ";
                    if (Convert.ToBoolean(dvrow.Cells["UnirArticulos"].Value) == true) ssql += " , UnirArticulos = 1 ";
                    ssql += " where idRegistro = " + dvrow.Cells["idRegistro"].Value.ToString();
                    SqlDatos.ejecutarComandoAdcom(ssql);
                }
            }
            if (i > 0) 
            { 
                WaitMensaje.WMensaje.verMensaje("GENERANDO FACTURAS DE CLIENTE");
                FacturacionMasiva prog = new FacturacionMasiva();
                prog.GenerarFacturas(cmbDocumento.SelectedValue.ToString (),txtNroID.Text,dtFechaFactura.Value);
                WaitMensaje.WMensaje.cierraMensaje();
            }
            limpiar();
        }
        private void limpiar()
        {
            ListaDocPorFacturar.DataSource = null ;
            CargarNumeroInicialDeFactura();
        }
        private void ToolStrip3_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnFacturas_Click(object sender, EventArgs e)
        {
            FormFactCliente prog = new FormFactCliente("FAC", "FAC", false);
            prog.ShowDialog();
            prog.Dispose();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            FormRemision prog = new FormRemision("REM", "REM", false);
            prog.ShowDialog();
            prog.Dispose();
        }
    }
}
