using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;
namespace DaxMallaLib
{
    public class Sumatoria
    {
        static internal void SumatoriaMalla(DataGridView malla,bool horizontal = false)
        {
            malla.Rows.Add();
            DataGridViewRow rowTot = malla.Rows[malla.Rows.Count - 1];
            foreach (DataGridViewColumn column in malla.Columns)
            {
                if (column.ValueType == Type.GetType("System.Decimal"))
                {
                    Decimal totalColumna = 0;
                    Int32 ind = 0;
                    foreach (DataGridViewRow row in malla.Rows)
                    {
                        totalColumna += Convert.ToDecimal(row.Cells[ind].Value);
                    }
                    rowTot.Cells[column.Index].Value = totalColumna;
                }
            }
            malla.Rows[malla.Rows.Count - 1].HeaderCell.ToolTipText = "Total";

            if (horizontal == true)
            {
                malla.Columns.Add("TotHorizontal", "TotHorizontal"); 
                foreach (DataGridViewRow row in malla.Rows)
                {
                    Decimal totalLinea = 0;
                    foreach (DataGridViewColumn column in malla.Columns)
                    {
                        Int32 ind = column.Index;
                        if (column.CellType == Type.GetType("System.Decimal") && column.Name != "TotHorizontal")
                        {
                            try { totalLinea += Convert.ToDecimal(row.Cells[ind].Value); }
                            catch { }
                        }
                    }
                    row.Cells["TotHorizontal"].Value = totalLinea;
                }
            }

        }
        static internal void SumatoriaMallaDat(DataGridView malla, bool horizontal = true)
        {
            DataTable data = (DataTable)malla.DataSource;
            DataRow rowTot = data.NewRow();
            foreach (DataColumn column in data.Columns)
            {
                if (column.DataType == Type.GetType("System.Decimal"))
                {
                    Decimal totalColumna = 0;
                    Int32 ind = column.Ordinal;
                    foreach (DataRow row in data.Rows)
                    {
                        totalColumna += Convert.ToDecimal(row[ind]);
                    }
                    rowTot[ind] = totalColumna;
                }
            }
            data.Rows.Add(rowTot);
            malla.Rows[malla.Rows.Count - 1].HeaderCell.ToolTipText = "Total";


            if (horizontal == true)
            {
                data.Columns.Add("TotHorizontal", typeof(Decimal));
                foreach (DataRow row in data.Rows)
                {
                    Decimal totalLinea = 0;
                    foreach (DataColumn column in data.Columns)
                    {
                        Int32 ind = column.Ordinal;
                        if (column.DataType == Type.GetType("System.Decimal") && column.ColumnName != "TotHorizontal")
                        {
                            try { totalLinea += Convert.ToDecimal(row[ind]); }
                            catch { }
                        }
                    }
                    row["TotHorizontal"] = totalLinea;
                }
            }
        }





    }
}
