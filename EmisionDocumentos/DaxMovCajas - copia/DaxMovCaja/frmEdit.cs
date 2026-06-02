using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DaxMovCaja
{
    public partial class frmEdit : Form
    {
        public frmEdit()
        {
            InitializeComponent();
            DaxCombobx.CargCmbBox llcbo = new DaxCombobx.CargCmbBox();
            llcbo.DaxCombosSuc(varbleComun.VarCom.codEmpresa.ToString(), true, varbleComun.VarCom.strConxSyscod, ref cboSucursal);
            cboSucursal.SelectedValue = varbleComun.VarCom.suc;
            llcbo.DaxCombosPtoVta(varbleComun.VarCom.strConxAdcom, ref cboPtoVenta, true);
        }
        string tit1 = "";
        string tit2 = "";
        DataTable dt = new DataTable();
        SqlDataAdapter DaRec2 = new SqlDataAdapter();
        //bool datosCambiados = false;
        private void ImprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Malla.RowCount == 0) return;
            DataGridViewPrinterApplication1.frmMain imp = new DataGridViewPrinterApplication1.frmMain();
            preparaTitulo();
            imp.imprimir(Malla, tit1, tit2, varbleComun.VarCom.nomEmpresa);
        }

        private void WordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Malla.RowCount == 0) return;
            ExportarGrid.Form1 exp = new ExportarGrid.Form1();
            preparaTitulo();
            exp.Exportar(Malla, "W", varbleComun.VarCom.nomEmpresa, tit1 + "\r\n" + tit2);
        }

        private void ExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Malla.RowCount == 0) return;
            ExportarGrid.Form1 exp = new ExportarGrid.Form1();
            preparaTitulo();
            exp.Exportar(Malla, "E", varbleComun.VarCom.nomEmpresa, tit1 + "\r\n" + tit2);
        }

        private void PDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Malla.RowCount == 0) return;
            ExportarGrid.Form1 exp = new ExportarGrid.Form1();
            preparaTitulo();
            exp.Exportar(Malla, "P", varbleComun.VarCom.nomEmpresa, tit1 + "\r\n" + tit2);
        }

        private void preparaTitulo()
        {
            tit2 = "Del: " + txtFechaIni.Text + " Al: " + txtFechaFin.Text;
            tit1 = "Lista de movimientos de caja SUC: " + cboSucursal.Text + " ptoVta: " + cboPtoVenta.Text;
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        { ejecutarConsulta(); }
        private void ejecutarConsulta()
        {
            this.Cursor = Cursors.WaitCursor;

            SqlConnection conexion = new SqlConnection
            {
                ConnectionString = varbleComun.VarCom.strConxAdcom
            };
            conexion.Open();

            string fecha1 = txtFechaIni.Text + " 01:01";
            string fecha2 = txtFechaFin.Text + " 23:59";

            string ssql = "SELECT idclave, Sucursal, PuntoVta, TipoMov, FechaMov, Responsable, Descripción, Valor FROM DaxAdcPto ";
            ssql  += " where fechamov >= '" + fecha1  + "' and fechamov <= '" + fecha2 + "'";
            if (cboPtoVenta.SelectedValue.ToString() != "0") ssql += " and sucursal = '" + cboSucursal.SelectedValue.ToString() + "' ";
            if (cboPtoVenta.SelectedValue.ToString() != "0") ssql += " and puntovta = '" + cboPtoVenta.Text + "' ";
            if (chkIngresos.Checked) ssql += " and tipoMov = 'I' ";
            if (chkGastos.Checked) ssql += " and tipoMov = 'G' ";

            SqlCommand cmd3 = new SqlCommand(ssql, conexion);
            DaRec2 = new SqlDataAdapter(cmd3);
            dt = new DataTable();
            DaRec2.Fill(dt);
            diseñarMalla();
            this.Cursor = Cursors.Default;
        }
        private void diseñarMalla()
        {
            string formaGrid = "#,##0.00;(#,##0.00);#";
            Malla.DataSource = dt;
            Malla.RowHeadersWidth = 20;
            Malla.ReadOnly = true;
            Malla.Columns["Idclave"].Visible = false;
            Malla.Columns["Valor"].DefaultCellStyle.Format = formaGrid;
            Malla.Columns["Valor"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void txtFechaIni_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            limpiar();
        }

        private void txtFechaFin_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            limpiar();

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
        private void limpiar()
        {
            Malla.Columns.Clear();
        }

        private void Malla_KeyDown(object sender, KeyEventArgs e)
        {
            if (Malla.CurrentCell == null) return;
            if (e.KeyCode == Keys.Delete)
            {
                if (MessageBox.Show("Confirma eliminar el registro actual ? ", "Eliminar movimientos de caja", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
                Int32 indRow = Malla.CurrentCell.RowIndex;
                decimal idclave = Convert.ToDecimal(Malla.Rows[indRow].Cells["idclave"].Value);
                dt.Rows.RemoveAt(indRow);
                eliminarRegistro(idclave);
                //datosCambiados = true;
            }
        }
        private void eliminarRegistro(decimal idclave)
        {
            using (SqlConnection conn = new SqlConnection(varbleComun.VarCom.strConxAdcom))
            {
                string ssql = "delete DaxAdcPto where idclave = " + idclave.ToString();
                conn.Open();
                SqlCommand comm = new SqlCommand(ssql, conn);
                comm.ExecuteNonQuery();
                conn.Close();
                comm.Dispose();
            }
        }

        private void frmEdit_FormClosed(object sender, FormClosedEventArgs e)
        {
            //if (datosCambiados)
            //{
            //    SqlCommandBuilder cb = new SqlCommandBuilder(DaRec2);
            //    DaRec2.DeleteCommand = cb.GetDeleteCommand();
            //    DaRec2.Update(dt);
            //    dt.AcceptChanges();
            //}
        }
    }
}