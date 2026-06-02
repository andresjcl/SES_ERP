using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using SysEmpDatt;

namespace DaxInvent
{
    internal partial class frmTallasColore : Form
    {
        //string ClassArt.strConxAdcom = "";
        string codigoBase = "";
        DataTable datos = new DataTable();
        internal frmTallasColore(string codigoBas, string Nombre,string strconx, ref DataTable datosTallas)
        {
            InitializeComponent();
            codigoBase = codigoBas;
            lblCodigoBase.Text = "Código Base: " + codigoBas + " - " + Nombre;
            //datosEmpresa.strConxAdcom = strconx;
            LibTallasColores.cargaInicial(ref datosTallas,codigoBas);
            malla.DataSource = datosTallas;
            diseñarMalla();
            datos = datosTallas;
            datos.Rows.Add(datos.NewRow());
        }
        private void diseñarMalla()
        {
            try
            {
                malla.Columns["nombreColor"].ReadOnly = true;
                malla.Columns["nombreTalla"].ReadOnly = true;

                malla.Columns["TIK_COLOR"].HeaderText = "Color";
                malla.Columns["TIK_TALLA"].HeaderText = "Talla";
                malla.Columns["TIK_ARTCODI"].HeaderText = "CodigoArticulo";
                malla.Columns["TIK_NUMERO"].HeaderText = "CodBarrasEAN13";
                malla.Columns["TIK_SERIE"].Visible = false;
                malla.Columns["TIK_ALTERNO"].Visible = false;
            }
            catch (Exception EX) { MessageBox.Show("error :" + EX.Message); }
        }

        protected override Boolean ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (malla.Focused == false && malla.IsCurrentCellInEditMode == false) return false;
            if (malla.IsCurrentCellInEditMode && keyData == Keys.Return) { malla.EndEdit(); return true;}
            if (!(keyData == Keys.Return || (keyData > Keys.F1 && keyData < Keys.F13))) return false;

            DataGridViewCell cell = malla.CurrentCell;
            if (cell.RowIndex > malla.Rows.Count - 3) { datos.Rows.Add(datos.NewRow()); }

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
                case "TIK_COLOR":
                    datoNvo = cargarCodigosColorTalla();
                    malla.CurrentRow.Cells["nombreColor"].Value = datoNvo;
                    moverCeldaMalla(cell);
                    break;
                case "TIK_TALLA":
                    datoNvo = cargarCodigosColorTalla();
                    malla.CurrentRow.Cells["nombreTalla"].Value = datoNvo;
                    moverCeldaMalla(cell);
                    break;
            } 
        }

        private Boolean funcionesEspeciales(ref Keys keyData, ref DataGridViewCell cell)
        {
            string datoNvo = "";

            string nombreCelda = malla.Columns[cell.ColumnIndex].Name;

            switch (keyData)
            {
                case Keys.F2:
                    {
                        switch (nombreCelda)
                        {
                            case "TIK_COLOR":
                                datoNvo = buscarColorTalla("Color", nombreCelda);
                                break;
                            case "TIK_TALLA":
                                datoNvo = buscarColorTalla("Talla" ,nombreCelda);
                                break;
                        }
                    }
                break;
            }

            if (datoNvo != "")
            { 
                cell.Value = datoNvo;
                keyData = Keys.Return;
            }
            return true;
        }
        private string buscarColorTalla(string tipo, string nombre)
        {
            Syscod.ManSysnetClass prog = new Syscod.ManSysnetClass();
            string cod ="";
            string descripcion ="";
            try
            {
                prog.BuscarReferencia(ref tipo, ref cod, ref descripcion);
                malla.CurrentRow.Cells["nombre"+tipo].Value = descripcion;
            }
            catch {cod = "";}
            prog = null;
            return cod;
        }
        private string cargarCodigosColorTalla()
        {
            Syscod.ManSysnetClass sys = new Syscod.ManSysnetClass();
            string datoNvo = "";
            string nombreColumna = malla.Columns[malla.CurrentCell.ColumnIndex].Name;            
            switch (nombreColumna)
            {
                case "TIK_COLOR":
                    datoNvo = sys.QueNombre(malla.CurrentCell.Value.ToString(), "Color");
                    break;
                case "TIK_TALLA":
                    datoNvo = sys.QueNombre(malla.CurrentCell.Value.ToString(), "Talla");
                    break;
            }
            return datoNvo;
        }

        private void malla_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (malla.Columns[e.ColumnIndex].Name == "TIK_COLOR" || malla.Columns[e.ColumnIndex].Name == "TIK_TALLA")
            {
                formarCodigoArticulo(malla.CurrentRow);
            }
        }
        private void btnGenerar_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in malla.Rows)
            {
                try
                {
                    if (row.Cells["TIK-COLOR"].Value.ToString().Length > 0 && row.Cells["TIK-TALLA"].Value.ToString().Length > 0)
                        formarCodigoArticulo(row);
                }
                catch { }
            }
        }
        private void formarCodigoArticulo(DataGridViewRow row)
        {
            string color = "";
            string talla = "";
            int longTalla = Convert.ToInt32("0" + txtNroCaracteresTalla.Text);
            int longColor = Convert.ToInt32("0" + txtNroCaracteresColor.Text);
            if (longColor == 0) { longColor = 2; }
            if (longTalla == 0) { longTalla = 4; }
            try
            {
                color = (row.Cells["TIK_COLOR"].Value.ToString() + "          ").Substring(0,longColor);
            }
            catch { }
            try
            {
                talla = (row.Cells["TIK_TALLA"].Value.ToString() + "          ").Substring(0,longTalla);
            }
            catch { }
            if (color != "" || talla != "")
            {
                string codigo = codigoBase.Trim() + color.Substring(0, longColor).Trim() + talla.Substring(0, longTalla).Trim();
                row.Cells["TIK_ARTCODI"].Value = codigo;
                row.Cells["TIK_NUMERO"].Value = nroTiket(codigo);
            }
        }
        private double nroTiket(string codArticulo)
        {
            if (codArticulo  == "") {return 0;}
            
            double Ultimo = LibTallasColores. NumeroMayorTiket();
            Ultimo += malla.CurrentCell.RowIndex;
            return Ultimo;
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            datos.Rows.Clear();
            malla.CurrentCell = malla.Rows[0].Cells[0];                        
        }

        private void btnCopiar_Click(object sender, EventArgs e)
        {

            string Ssql = "SELECT art_codigobase as CodigoBase,max(art_nombre) as Descripción FROM ADCART group by art_codigoBase order by art_codigobase";
            Buscar.frmBuscar busk = new Buscar.frmBuscar();
            string dato = busk.Buscar(datosEmpresa.strConxAdcom, Ssql, "CodigoBase", "Descripción", "", "BUSQUEDA DE CODIGOS BASE","");
            if (MessageBox.Show("Confirma copiar los COLORES y TALLAS del artículo " + dato + "\n estos reemplazarán a los existentes !", "COPIAR TALLAS COLORES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No) return;

            Ssql = "SELECT AdcTik.TIK_COLOR AS Color";
            Ssql += " , (select top 1 Descripcion from syscod where TipoReferencia = N'Color' and tik_color = abreviación) AS nombreColor";
            Ssql += " , AdcTik.TIK_TALLA AS Talla";
            Ssql += " , (select top 1 Descripcion from syscod where TipoReferencia = N'Talla' and tik_talla = abreviación) AS nombreTalla";
            Ssql += " , '' AS CodigoArticulo, ";
            Ssql += " '' AS CodBarrasEAN13";
            Ssql += " FROM AdcTik where tik_artcodi LIKE '" + dato.Trim()  + "%'";            
                        
            datos = SqlDatos.leerTablaAdcom( Ssql);
            malla.DataSource = datos;            
        }
    }
}
