using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace DaxMallaLib
{
   public class Documentos
    {
        static public void MoverCelda(DataGridView malla,bool barras)
        {
            DataGridViewCell cell = malla.CurrentCell;
            Int32 columnIndex = cell.ColumnIndex;
            Int32 rowIndex = cell.RowIndex;
            Int32 col = columnIndex;
            Int32 row = rowIndex;
            Int32 colOk = 0;
            if (barras == false  &&  col < malla.Columns.Count)
            {
                for (int i = col + 1; i < malla.Columns.Count - 1; i++)
                {
                    if (malla.Columns[i].Visible == true && malla.Columns[i].ReadOnly == false && (malla.Columns[i].Name.ToUpper() != "DESCRIPCIÓN" || malla.Columns[i].Name.ToUpper() != "NOMBRE")) 
                    { colOk = i + 1; break; }
                }
            }

            if (colOk == 0)
            {
                col = 0;
                if (row == malla.Rows.Count - 1)
                {
                    //dtDetalleDocumento.Rows.InsertAt(dtDetalleDocumento.NewRow(), malla.Rows.Count);
                    ((DataTable)malla.DataSource).Rows.Add();
                    row = malla.Rows.Count - 1;
                    for (int i = 0; i < malla.Columns.Count - 1; i++)
                    {
                        if (malla.Columns[i].Visible == true && malla.Columns[i].ReadOnly == false && (malla.Columns[i].Name.ToUpper() != "DESCRIPCIÓN" || malla.Columns[i].Name.ToUpper() != "NOMBRE")) { colOk = i + 1; break; }
                    }

                }
                else
                {
                    row++;
                    for (int i = 0; i < malla.Columns.Count - 1; i++)
                    {
                        if (malla.Columns[i].Visible == true && malla.Columns[i].ReadOnly == false && (malla.Columns[i].Name.ToUpper() != "DESCRIPCIÓN" || malla.Columns[i].Name.ToUpper() != "NOMBRE")) { colOk = i + 1; break; }
                    }
                }
            }
            col = colOk - 1;
            if (row != malla.CurrentCell.RowIndex || col != malla.CurrentCell.ColumnIndex)
            { try { malla.CurrentCell = malla.Rows[row].Cells[col]; } catch { } }
        }
    }
}
