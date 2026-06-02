using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DaxMallaLib
{
    static public class classBuscMalla
    {
        static public double sumarMalla(DataGridView malla)
        {
            double total=0;
            Int32 cant = 0;
            double valor = 0;
            if (malla.SelectedCells.Count > 1)
            {
                foreach (DataGridViewCell cell in malla.SelectedCells)
                {
                    valor = 0;
                    Double.TryParse(cell.Value.ToString(), out valor);
                    total += valor; cant++; }
                }
            MessageBox.Show(cant.ToString() + " Sumatoria  : " + string.Format("{0,12:D2}",total.ToString()));
            return total;
        }
        static public void ocultarColumnas(DataGridView malla)
        {
            Boolean valorEncol = true;
            for (Int32 i = 0; i < malla.Columns.Count; i++)
            {
                valorEncol = false;
                for (Int32 j = 0;j < malla.Rows.Count;j++)
                {
                    if (malla.Rows[j].Cells[i] == null) { valorEncol = true; break; }
                    if (malla.Rows[j].Cells[i].Value.ToString() != string.Empty) { valorEncol = true; break; }
                }
                malla.Columns[i].Visible = valorEncol;
            }
        }
        static public void ocultarColumnasEscojidas(DataGridView malla)
        {
            foreach (DataGridViewCell cell in malla.SelectedCells)
            {
                malla.Columns[cell.ColumnIndex].Visible = false;
            }
        }
        static public void verColumnas(DataGridView malla)
        {
            Boolean valorEncol = true;
            for (Int32 i = 0; i < malla.Columns.Count; i++)
            {
                malla.Columns[i].Visible = valorEncol;
            }
        }
        static internal Boolean compararFecha(DateTime fecha1, DateTime fecha2, int tipo)
        {
            if (tipo < 2) return (fecha1 == fecha2);
            //if (tipo == 2) return (fecha1 > fecha2);
            //if (tipo == 3) return (fecha1 < fecha2);
            //return (fecha1 != fecha2);
            return false;
        }
        static internal Boolean compararString(string campo1, string campo2, int tipo)
        {
            if (tipo == 0) return (campo1.ToUpper()  == campo2.ToUpper() );
            return (campo1.ToUpper().IndexOf(campo2.ToUpper()) > -1);
            //return (campo1.ToUpper() != campo2.ToUpper());
        }

    }
}
                                                                                                                