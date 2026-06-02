using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using DaxComercia;
using DattCom;
using System.Windows.Forms;
using ClassDoc;

namespace daxContaDoc
{
    public partial class frmVisContab : Form
    {
        //Boolean salto = false;      
        AdcDoc ValoresDocumento;
        sesSys.OpcDoc propiedadesDocumento;
        DataTable ItemsDelDocumento;
        DaxComercia. classPagosDoc pagosDocto;
        string queDetalle;
        AsientosContables ListaAsientosCtb = new AsientosContables();
        AsientosContables ListaAsientosCtbBak = new AsientosContables();

        DataTable dtDetalleContable = new DataTable();

        public frmVisContab(AsientosContables asientosContables,AdcDoc oidDocto,  DataTable mallaart, sesSys.OpcDoc oopcDoc, classPagosDoc opagosDocto = null, string oqueDetalle = "")
        {
            InitializeComponent();
            ValoresDocumento = oidDocto;
            propiedadesDocumento = oopcDoc;
            ListaAsientosCtb = asientosContables;
            ListaAsientosCtbBak.copiarAsientosContables(ListaAsientosCtb);
            pagosDocto = opagosDocto;
            queDetalle = oqueDetalle;
            ItemsDelDocumento = mallaart;
            CargarAsientosContables();
        }
        private void frmVisContab_Load(object sender, EventArgs e)
        {
            if (malla.Rows.Count < 1) ejecutarContabilizacionAutomatica();
        }
        public AsientosContables IniciarRevisionContable()
        {
            this.ShowDialog();
            return ListaAsientosCtb;
        }

        private void CargarAsientosContables()
        {
            string resp = "Contabilización generada del proceso";
            contabilizaDocumento cc = new contabilizaDocumento();
            if (ListaAsientosCtb != null && ListaAsientosCtb.ListDetalleContab.Count > 0)
            {
                ListaAsientosCtb.cargarAmalla(malla);
            }
            else
            {
                resp = "Contabilización registrada ";
                if (!leerContabilidad())
                {
                    ListaAsientosCtb = cc.GenerarContabilidadDocumento(ValoresDocumento,ItemsDelDocumento, propiedadesDocumento, pagosDocto, queDetalle); 
                    resp = "Contabilizacion generada este momento ";
                    ListaAsientosCtb.cargarAmalla(malla);
                }
            }
            labMensaje.Text = resp;
            cc.arreglarMallaCtb(malla);
            Totalizar();
        }
        private Boolean leerContabilidad()
        {
            Boolean resp = true;
            string ssql = "DaxCtbDia '" + ValoresDocumento.Doc_sucursal + "' ,'" + ValoresDocumento.Opc_documento + "'," + ValoresDocumento.IdClaveDoc.ToString();
            dtDetalleContable = SqlDatos.leerTablaAdcom(ssql);
            malla.DataSource = dtDetalleContable;
            if (dtDetalleContable.Rows.Count < 1) resp = false;
            return resp;
        }
        #region manejo malla
        private void malla_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            //salto = true;
            foreach (DataGridViewRow rr in malla.Rows)
            {
                rr.HeaderCell.Value = (rr.Index + 1).ToString();
            }
            //salto = false;
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
            return false;
        }

        private void moverCeldaMalla(DataGridViewCell cell)
        {
            Int32 columnIndex = cell.ColumnIndex;
            Int32 rowIndex = cell.RowIndex;
            Int32 col = columnIndex;
            Int32 row = rowIndex;
            Int32 colOk = 0;


            if (col < malla.Columns.Count)
            {
                for (int i = col + 1; i < malla.Columns.Count - 1; i++)
                {
                    if (malla.Columns[i].Visible == true && malla.Columns[i].ReadOnly == false && malla.Columns[i].Name.ToUpper() != "DESCRIPCIÓN") { colOk = i; break; }
                }
            }

            if (colOk == 0)
            {
                col = 1;
                if (row == malla.Rows.Count - 1)
                {
                    dtDetalleContable.Rows.InsertAt(dtDetalleContable.NewRow(), malla.Rows.Count);
                    row = malla.Rows.Count - 1;
                }
                else
                {
                    row++;
                }
            }
            else
            {
                col = colOk;
            }
            malla.CurrentCell = malla.Rows[row].Cells[col];
        }

        #endregion manejo malla

        private Boolean funcionesEspeciales(ref Keys keyData, DataGridView malla)
        {
            Boolean resp = true;
            malla.EndEdit();
            DataGridViewCell cell = malla.CurrentCell;
            string dato = cell.Value.ToString();
            string nombreCelda = cell.OwningColumn.Name;
            if (nombreCelda == "Cta_codigo")
            {
                if (keyData == Keys.F2)
                {
                    string nombre = "";
                    string tipo = "S";
                    CtaMtn.BuscaCta busCta = new CtaMtn.BuscaCta();
                    dato = busCta.BuscaCtaCtb(ref nombre, ref tipo);
                    if (dato != "") { cell.Value = dato;malla.CurrentRow.Cells["Dia_ctanombre"].Value = nombre; }
                }
                else if (keyData == Keys.Return && cell.Value.ToString().Length > 0) 
                {

                }
                else if (keyData == Keys.F3)
                {
                }
            }
            if (cell.Value.ToString() != "") keyData = Keys.Return; else keyData = Keys.Cancel;

            return resp;
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (classMenSistem.mensajesErrorDocumento.ConfirmaCancelar() == false) return;
            dtDetalleContable = new DataTable();
            malla.Columns.Clear();
            ListaAsientosCtb = ListaAsientosCtbBak;
            Close();
        }
        private void Totalizar()
        {
        decimal totDeb = 0;
        decimal totHab = 0;
        string formato = "N2";
            foreach (DataGridViewRow dgRow in malla.Rows)
            {
                totDeb += Convert.ToDecimal("0"+dgRow.Cells["valDebe"].Value);
                totHab += Convert.ToDecimal("0"+dgRow.Cells["valHaber"].Value);
            }
            label2.Text = "Total Debe : " + totDeb.ToString(formato) + "           Total Haber : " + totHab.ToString(formato);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            malla.EndEdit();
           if ( ListaAsientosCtb.cargarDeMalla(malla) == false ) return;

            idDocumento idDoc = new idDocumento();
            idDoc.Sucursal = ValoresDocumento.Doc_sucursal;
            idDoc.Tipo = ValoresDocumento.Opc_documento;
            idDoc.idClave = Convert.ToDouble(ValoresDocumento.IdClaveDoc);
            idDoc.numero = Convert.ToDouble(ValoresDocumento.Doc_numero);
            idDoc.fecha = ValoresDocumento.Doc_fecha;

            ListaAsientosCtb.GrabarDetalleContable(idDoc);
            
            Close();
        }

        private void btnRecontabiliza_Click(object sender, EventArgs e)
        {
            //malla = new DataGridView();6
            ejecutarContabilizacionAutomatica(true);
        }
        private void ejecutarContabilizacionAutomatica(Boolean recCtb = false )
        {
            dtDetalleContable.Rows.Clear();
            daxContaDoc.contabilizaDocumento progCtb = new daxContaDoc.contabilizaDocumento();
            ListaAsientosCtb = progCtb.GenerarContabilidadDocumento(ValoresDocumento, ItemsDelDocumento, propiedadesDocumento, pagosDocto, queDetalle);
            ListaAsientosCtb.cargarAmalla(malla);
            Totalizar();
            progCtb = null;
        }

        private void malla_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            labMensaje.Text = "Contabilidad modificada manualmente";
        }

        private void malla_KeyDown(object sender, KeyEventArgs e)
        {
            string nombre = "";
            string tipoMov = "";
            if (e.KeyCode == Keys.F2 && malla.CurrentCell.OwningColumn.Name == "Cta_Codigo")
            {
                CtaMtn.BuscaCta buscaCta = new CtaMtn.BuscaCta();
                string cta = buscaCta.BuscaCtaCtb(ref nombre, ref tipoMov);
                malla.CurrentCell.Value = cta;
                malla.Rows[malla.CurrentCell.RowIndex].Cells["Dia_ctanombre"].Value = nombre;

            }

        }

        
    }
}
