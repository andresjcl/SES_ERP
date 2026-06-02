using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace daxEmiFacPv
{
    public partial class formCtbDia : Form
    {
        public formCtbDia()
        {
            InitializeComponent();
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override Boolean ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (malla.Focused == false && malla.IsCurrentCellInEditMode == false) return false;
            if (malla.IsCurrentCellInEditMode && keyData == Keys.Return) { malla.EndEdit(); return true; }
            if (!(keyData == Keys.Return || (keyData > Keys.F1 && keyData < Keys.F13))) return false;

            DataGridViewCell cell = malla.CurrentCell;
//            if (cell.RowIndex > malla.Rows.Count - 3) { datos.Rows.Add(datos.NewRow()); }

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
            string datoNvo = "";

            string nombreCelda = malla.Columns[cell.ColumnIndex].Name;

            //switch (keyData)
            //{
            //    case Keys.F2:
            //        {
            //            switch (nombreCelda)
            //            {
            //                case "Color":
            //                case "Talla":
            //            }
            //        }
            //        break;
            //}

            if (datoNvo != "")
            {
                cell.Value = datoNvo;
                keyData = Keys.Return;
            }
            return true;
        }

        private void btnCierra_Click(object sender, EventArgs e)
        {

        }
    }
}
