using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using SysEmpDatt;

namespace IvaRett
{
    public partial class frmReten : Form
    {
        int tipoTransaccion = 1; // 1 compras 2 ventas
        string TipoRetencion = "";  // IB iva bienes   IS  iva servicios   RF retencion en la fuente
       
        string sucursal = "";
        string docAplica = "";
        double idClaveDoc = 0;
        public frmReten(int tipoTra , ClassDoc.idDocumento idDocumento )
        {
            if (tipoTra == 2) tipoTransaccion = tipoTra;
            InitializeComponent();
            txtfecha.Value = DateTime.Now;
            llenarCombos();
        }


        private void btnNuevo_Click(object sender, EventArgs e)
        {
            iniciarNuevoDocumento();
        }
        private void iniciarNuevoDocumento()
        {
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

        private void llenarCombos()
        {
            string tipoRetencion = "RTP";
            string tipoDocSoporte = "FAPNCPNDP";
            if (tipoTransaccion == 2) { tipoRetencion = "RTC"; tipoDocSoporte = "FACNCCNDC"; }
            DaxCombobx.CargCmbBox  dcombo = new DaxCombobx.CargCmbBox();
            dcombo.DaxCombosDoc(tipoRetencion, "RTC", false, datosEmpresa.strConxAdcom, ref cmbDocumento);            
            IvaRett .nombreTablas nt = new TablasSRI.nombreTablas();
            DataTable dt = leerDatos(nt.armarConsulta(nt.RetencionIvaBienes, dtFechaRetencion.Value.ToShortDateString(), 0, 0, 0), strConxIvaret);
            cmbRetenIvaBien.DataSource = dt;
            cmbRetenIvaBien.DisplayMember = "Descripción";
            cmbRetenIvaBien.ValueMember = "Código";
            cmbRetenIvaBien.SelectedValue = "";

            dt = leerDatos(nt.armarConsulta(nt.RetencionIvaServicios, dtFechaRetencion.Value.ToShortDateString(), 0, 0, 0), strConxIvaret);
            cmbRetIvaServicio.DataSource = dt;
            cmbRetIvaServicio.DisplayMember = "Descripción";
            cmbRetIvaServicio.ValueMember = "Código";
            cmbRetIvaServicio.SelectedValue = "";
        }






        //        MantenimientoDirectorio.DirectorioAlex opalex = new MantenimientoDirectorio.DirectorioAlex();


        //        private void configurarMallaRetFuente()
        //        {            
        //            malla.Rows.Add(5);
        //            malla.Columns["Código"].Width = 50;
        //            malla.Columns["Descripción"].Width = 300;
        //            malla.Columns["BaseNoIva"].Width = 80;
        //            malla.Columns["BaseExIva"].Width = 80;
        //            malla.Columns["Porcentaje"].Width = 30;
        //            malla.Columns["BaseConIva"].Width = 80;
        //            malla.Columns["BaseIvaCero"].Width = 80;
        //            malla.Columns["ValorRetenido"].Width = 90;

        //            malla.Columns["Código"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft ;
        //            malla.Columns["Descripción"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        //            malla.Columns["Porcentaje"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        //            malla.Columns["Descripción"].ReadOnly = true;
        //            malla.Columns["ValorRetenido"].ReadOnly = true;

        ////            malla.Rows[4].Height = 2;
        //            malla.Rows[4].Cells["Descripción"].Value  = "Totales:";
        //            malla.ForeColor = Color.Black;

        //        }

        //        private DataTable leerDatos(string ssql, string strConx)
        //        { 
        //            DataTable dt = new DataTable();
        //            SqlDataAdapter da = new SqlDataAdapter(ssql, strConx);
        //            da.Fill(dt);
        //            da.Dispose();
        //            return dt;
        //        }


        //        private void btnBuscaCliente_Click_1(object sender, EventArgs e)
        //        {
        //            buscaCliente(lblNombreCliente.Text);
        //        }
        //        private void buscaCliente(string buscador)
        //        {
        //            MantenimientoDirectorio.BuscaClien directorio = new MantenimientoDirectorio.BuscaClien();
        //            string cliente = "C";
        //            string codigo = "";
        //            string nombre = "";
        //            string conalias = "N";
        //            string connuevo = "N";
        //            codigo = directorio.IniBuscaCliOPro(ref cliente, ref nombre, ref conalias, ref connuevo);
        //            if ((codigo + "").Length > 0) cargarDatosCliente(codigo);
        //            directorio.Dispose();
        //        }
        //        private void cargarDatosCliente(string codigo = "")
        //        {
        //            if (codigo != "")
        //            {
        //                string solocodigo = "";
        //                Boolean x = false;
        //                opalex.CargarAlex(ref codigo, ref x, ref solocodigo);
        //                if (opalex.codigo.Length > 0)
        //                {
        //                    txtcedula.Text = opalex.CiRuc;
        //                    lblNombreCliente.Text = opalex.NombreImpresion;
        //                }
        //            }
        //            else
        //            {
        //                txtcedula.Text = "";
        //                lblNombreCliente.Text = "";
        //            }
        //        }

        //        private void txtcedula_Validating(object sender, CancelEventArgs e)
        //        {
        //            if (txtcedula.Text != "") cargarDatosCliente(txtcedula.Text);
        //        }

        //        #region manejo malla
        //        private void malla_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        //        {
        //            foreach (DataGridViewRow rr in malla.Rows)
        //            {
        //                rr.HeaderCell.Value = (rr.Index + 1).ToString();
        //            }
        //        }

        //        protected override Boolean ProcessCmdKey(ref Message msg, Keys keyData)
        //        {

        //            if (malla.Focused == false && malla.IsCurrentCellInEditMode == false) return false;
        //            if (malla.IsCurrentCellInEditMode && keyData == Keys.Return) { malla.EndEdit(); return true; }
        //            if (!(keyData == Keys.Return || (keyData > Keys.F1 && keyData < Keys.F13))) return false;

        //            DataGridViewCell cell = malla.CurrentCell;
        //            //if (cell.RowIndex > malla.Rows.Count - 3) { dtDetalleDocumento.Rows.Add(dtDetalleDocumento.NewRow()); }

        //            funcionesEspeciales(ref keyData, ref cell);

        //            if (keyData != Keys.Return) return true;
        //            moverCeldaMalla(cell);
        //            return true;
        //        }
        //        private void moverCeldaMalla(DataGridViewCell cell)
        //        {

        //            Int32 columnIndex = cell.ColumnIndex;
        //            Int32 rowIndex = cell.RowIndex;
        //            Int32 col = columnIndex;
        //            Int32 row = rowIndex;

        //            Boolean esVisible = false;
        //            do
        //            {
        //                if (col == malla.Columns.Count - 1)
        //                {
        //                    if (row == malla.Rows.Count - 1)
        //                    {
        //                        col = 0;
        //                        row = 0;
        //                    }
        //                    else
        //                    {
        //                        col = 0;
        //                        row++;
        //                    }
        //                }
        //                else
        //                {
        //                    col++;
        //                }
        //                cell = malla.Rows[row].Cells[col];
        //                esVisible = (cell.Visible && !cell.ReadOnly);
        //            } while (esVisible == false);
        //            malla.CurrentCell = cell;
        //        }

        //        private void malla_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        //        {
        //            DataGridViewCell cell = malla.CurrentCell;
        //            string nombreCelda = malla.Columns[cell.ColumnIndex].Name;
        //            switch (nombreCelda)
        //            {
        //                case "BaseConIva":
        //                case "Porcentaje":
        //                      //totalizar();
        //                        break;
        //                case "Código":
        //                        if (cell.Value != null) ponerDatosRtencionFuente(cell.Value.ToString(), malla.CurrentRow, strConxIvaret);
        //                        break;
        //            }
        //        }

        //        private Boolean funcionesEspeciales(ref Keys keyData, ref DataGridViewCell cell)
        //        {        
        //            Boolean resp = true;
        //            malla.EndEdit();
        //            string dato = "";
        //            try
        //            {
        //                dato = cell.Value.ToString();
        //            }
        //            catch { }

        //            string nombreCelda = malla.Columns[cell.ColumnIndex].Name;
        //            if (keyData == Keys.F2)
        //            {
        //                if (nombreCelda == "Código")
        //                {
        //                    dato=buscarCodigoRetencion();
        //                    if (dato != "") ponerDatosRtencionFuente(dato, malla.Rows[cell.RowIndex], strConxIvaret);
        //                }
        //            }
        //            cell.Value = dato;
        //            return resp;
        //        }

        //        private void malla_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        //        {            
        //            totalizar();
        //        }

        //        #endregion manejo malla

        //        private string buscarCodigoRetencion()
        //        {
        //            string dato = "";
        //            TablasSRI.frmBuscar tabSri = new TablasSRI.frmBuscar();
        //            TablasSRI.nombreTablas tabNom = new TablasSRI.nombreTablas();
        //            string nombre = "";
        //            dato = tabSri.Buscar(0, strConxAdcom, strConxIvaret, tabNom.ConceptosRetencion, "código", "descripción", "Busquedas", ref nombre);
        //            string ssql = tabNom.armarConsulta(tabNom.ConceptosRetencion, dtFechaRetencion.Value.ToShortDateString(), 0, 0, 0);
        //            tabSri.Dispose();
        //            tabNom = null;
        //            return dato;
        //        }

        //        private void ponerDatosRtencionFuente(string codRetencion, DataGridViewRow row, string strConxIvaret)
        //        {
        //            malla.EndEdit();
        //            if (codRetencion.Length == 0) return;
        //            TablasSRI.nombreTablas tabNom = new TablasSRI.nombreTablas();
        //            string ssql = tabNom.armarConsulta(tabNom.ConceptosRetencion, dtFechaRetencion.Value.ToShortDateString(), 0, 0, 0);
        //            ssql += " and Código = '" + codRetencion + "'";
        //            DataTable dt = leerDatos(ssql, strConxIvaret);
        //            if (dt.Rows.Count > 0)
        //            {
        //                row.Cells["Descripción"].Value = dt.Rows[0]["Descripción"].ToString();
        //                row.Cells["Porcentaje"].Value = dt.Rows[0]["Porcentaje"].ToString();
        //                //totalizar();
        //            }
        //            else
        //            {
        //                MessageBox.Show("El código digitado no existe", "Valida codigo retención", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            }
        //            tabNom = null;
        //            dt.Dispose();
        //        }
        //        private void ponerValoresIvaBienes(string codigo)
        //        {
        //            if (codigo.Length == 0) return;
        //            TablasSRI.nombreTablas tabNom = new TablasSRI.nombreTablas();
        //            string ssql = tabNom.armarConsulta(tabNom.RetencionIvaBienes, dtFechaRetencion.Value.ToShortDateString(), 0, 0, 0);
        //            ssql += " and Código = '" + codigo + "'";
        //            DataTable dt = leerDatos(ssql, strConxIvaret);
        //            if (dt.Rows.Count > 0)
        //            {
        //                txtPorcentajeBienes.Text  = dt.Rows[0]["Descripción"].ToString();
        //                //totalizar();
        //            }
        //            else
        //            {
        //                MessageBox.Show("El código digitado no existe", "Valida codigo retención ", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            }
        //            tabNom = null;
        //            dt.Dispose();
        //        }
        //        private void totalizar()
        //        {
        //            Double totalizar = 0;
        //            double retenido = 0;
        //            foreach (DataGridViewRow row in malla.Rows)
        //            {
        //                if (row.Cells["Porcentaje"].Value == null || row.Cells["Código"].Value == null) { }
        //                else
        //                {
        //                    if (row.Cells["BaseConIva"].Value == null) row.Cells["BaseConIva"].Value = "0";
        //                    retenido = Convert.ToDouble("0" + row.Cells["BaseConIva"].Value.ToString()) * Convert.ToDouble("0" + row.Cells["Porcentaje"].Value.ToString()) / 100;
        //                    row.Cells["ValorRetenido"].Value = retenido.ToString();
        //                    totalizar += retenido;
        //                }

        //                retenido = Convert.ToDouble("0" + txtBaseBienes.Text ) * Convert.ToDouble("0" + txtPorcentajeBienes.Text) / 100;
        //                txtRetenidoBienes.Text = retenido.ToString();
        //                totalizar += retenido;
        //                retenido = Convert.ToDouble("0" + txtBaseServicios.Text) * Convert.ToDouble("0" + txtPorcentajeServicios.Text) / 100;
        //                txtRetenidoServicios.Text = retenido.ToString("0.00");
        //                totalizar += retenido;

        //                lblTotalRetenciones.Text = totalizar.ToString("0.00");
        //            }           
        //        }

        //        private void btnBuscarDocumentSoporte_Click(object sender, EventArgs e)
        //        {
        //            BuscadorDocumentos.frmBuscarDoc prog = new BuscadorDocumentos.frmBuscarDoc();
        //        }

        //        private void cmbRetenIvaBien_SelectedIndexChanged(object sender, EventArgs e)
        //        {
        //            ponerValoresIvaBienes(cmbRetenIvaBien.SelectedValue.ToString());
        //        }

        //        private void txtnumeroRetencion_TextChanged(object sender, EventArgs e)
        //        {
        //            // chequear numeacion con anulaciones 
        //        }

    }
}
