using System;
using System.Windows.Forms ;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mntUsrs
{
    class marcarMalla
    {
        public void marcaKeys(DataGridView malla, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2 || e.KeyCode == Keys.X) marcaCelda(malla);
            else if (e.KeyCode == Keys.F3) marcaTodo(malla);
            else if (e.KeyCode == Keys.F4) marcaColumna(malla);
            else if (e.KeyCode == Keys.F5) marcaLinea(malla);
        }
        public void marcaCelda(DataGridView malla)
        {
            foreach (DataGridViewCell celda in malla.SelectedCells)
            {
                if (malla.Columns[celda.ColumnIndex].Name != "modulo" && malla.Columns[celda.ColumnIndex].Name != "opcion" && malla.Columns[celda.ColumnIndex].Visible == true)
                {
                    if (celda.Value == null) { celda.Value = "X"; }
                    else if (celda.Value.ToString() == "X") celda.Value = ""; else celda.Value = "X";
                }
            }
        }
        public void marcaLinea(DataGridView malla)
        {
            DataGridViewCell celda = malla.CurrentCell;
            if (malla.Columns[celda.ColumnIndex].Name == "modulo" || malla.Columns[celda.ColumnIndex].Name == "opcion" || malla.Columns[celda.ColumnIndex].Visible == false ) return;
            DataGridViewRow row = malla.CurrentRow;



            string aux = "";
            if (celda.Value == null) { celda.Value = "X"; }
            else if (celda.Value.ToString() == "") { aux = "X"; };
            for (int i=2;i<row.Cells.Count-1;i++)
            {
                if (malla.Columns[row.Cells[i].ColumnIndex].Name != "modulo" && malla.Columns[row.Cells[i].ColumnIndex].Name != "opcion" && malla.Columns[row.Cells[i].ColumnIndex].Visible == true)
                {
                    row.Cells[i].Value = aux;
                }
            }
        }
        public void marcaColumna(DataGridView malla)
        {
            DataGridViewCell celda = malla.CurrentCell;
            if (malla.Columns[celda.ColumnIndex].Name == "modulo" || malla.Columns[celda.ColumnIndex].Name == "opcion") return;
            Int32 col = celda.ColumnIndex ;
            string aux = "";
            if (celda.Value == null) { celda.Value = "X"; }
            else if (celda.Value.ToString() == "") { aux = "X"; }; 
            for (int i = 0; i < malla.Rows.Count; i++)
            {
                if (malla.Columns[col].Name != "modulo" && malla.Columns[col].Name != "opcion" && malla.Columns[col].Visible == true)
                {

                    malla.Rows[i].Cells[col].Value = aux;
                }
            }
        }
        public void marcaTodo(DataGridView malla)
        {
            DataGridViewCell celda = malla.CurrentCell;
            if (malla.Columns[celda.ColumnIndex].Name == "modulo" || malla.Columns[celda.ColumnIndex].Name == "opcion") return;            
            string aux = "";
            if (celda.Value == null) { celda.Value = "X"; }
            else if (celda.Value.ToString() == "") { aux = "X"; }; 
            foreach (DataGridViewRow row in malla.Rows)
            {
                for (int i = 2; i < row.Cells.Count - 1; i++)
                {
                    if (malla.Columns[i].Name != "modulo" && malla.Columns[i].Name != "opcion" && malla.Columns[i].Visible == true)
                    {
                        row.Cells[i].Value = aux;
                    }
                }
            }
        }

    }
}
