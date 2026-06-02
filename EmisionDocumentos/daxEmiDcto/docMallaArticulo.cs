using System;
using System.Windows.Forms;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace daxEmiDcto
{
    class docMallaArticulo
    {
        public string strConxAdcom = string.Empty;
        public void buscarArticulo(DataGridView malla)
        {
            malla.EndEdit();
            DataGridViewCell celda = malla.CurrentCell;
            string dato = "" + celda.Value.ToString();
            Buscar.frmBuscar busk = new Buscar.frmBuscar();
            string ssql = "select art_codigo as codigo, art_nombre as Descripción from adcart order by art_nombre";
            dato = busk.Buscar(strConxAdcom, ssql, "codigo", "Descripción", "", "BUSQUEDA DE ARTÍCULOS", dato);
            cargarArticulo(dato, ref malla);
            celda.Dispose();
            busk.Dispose();
            malla.CurrentCell = malla.CurrentRow.Cells["Cantidad"];
        }
        public Boolean cargarArticulo(string codigo, ref DataGridView malla)
        {
            if (malla.CurrentCell == null) return false;
            DataGridViewCell celda = malla.CurrentCell;
            if (codigo == string.Empty) return false;
            string ssql = "select art_nombre, art_unimed from adcart where art_codigo = '" + codigo + "' ";
            DataTable dtt = leerTablas(ssql);
            if (dtt == null || dtt.Rows.Count == 0)
            {
                MessageBox.Show("No existe el artículo registrado");
                return false;
            }
            malla.Rows[celda.RowIndex].Cells["Codigo"].Value = codigo;
            malla.Rows[celda.RowIndex].Cells["Descripción"].Value = dtt.Rows[0]["art_nombre"].ToString();
            malla.Rows[celda.RowIndex].Cells["Medida"].Value = dtt.Rows[0]["art_unimed"].ToString();
            dtt.Dispose();
            celda.Dispose();
            return true;
        }
        private DataTable leerTablas(string ssql)
        {
            // devuelve un datatable con los datos leidos
            SqlDataAdapter da;
            DataTable dt = new DataTable();
            try
            {
                da = new SqlDataAdapter(ssql, strConxAdcom);
                da.Fill(dt);
            }
            catch
            {
                return null;
            }
            return dt;
        }

        public void AcumularLineasMalla(ref DataGridView Malla, Int32 Col1, Int32 Col2, Boolean ConSigno = false)
        {
            Int32 I = 0;
            Int32 j = 0;
            Int32 S = 0;
            Int32 SS = 0;
            Int32 QueSigno = 0;
            Double valor = 0;
            if (Malla.RowCount < 2) return;

            SS = Malla.Columns.Count - 1;
            //Malla.Columns.Count = Col1;
            Malla.Sort(Malla.Columns["Codigo"], System.ComponentModel.ListSortDirection.Ascending);
            j = 1;
            S = 0;
            do
            {
                try { valor = Convert.ToDouble(Malla.Rows[I].Cells[Col2].Value) * Convert.ToDouble(Malla.Rows[I].Cells[SS].Value); }
                catch { valor = 0; }

                if (ConSigno) { Malla.Rows[I].Cells[Col2].Value = valor; }

                if (Malla.Rows[I].Cells[Col1].Value.ToString() == "")
                { Malla.Rows.RemoveAt(I); }
                else if (Malla.Rows[I].Cells[Col1].Value.ToString() == Malla.Rows[j].Cells[Col1].Value.ToString())
                {
                    if (Malla.Rows[I].Cells[Col2].Value.ToString() == "") { Malla.Rows[I].Cells[Col2].Value = 0; }
                    if (Malla.Rows[j].Cells[Col2].Value.ToString() == "") { Malla.Rows[j].Cells[Col2].Value = 0; }
                    if (ConSigno)
                    {
                        QueSigno = Convert.ToInt32(Malla.Rows[j].Cells[SS].Value);
                        if (QueSigno == 0) QueSigno = 1;
                        Malla.Rows[I].Cells[Col2].Value = Convert.ToDouble(Malla.Rows[I].Cells[Col2].Value) + Convert.ToDouble(Malla.Rows[j].Cells[Col2].Value) * QueSigno;
                    }
                    else
                    {
                        Malla.Rows[I].Cells[Col2].Value = Convert.ToDouble(Malla.Rows[I].Cells[Col2].Value) + Convert.ToDouble(Malla.Rows[j].Cells[Col2].Value);
                        Malla.Rows.RemoveAt(j);
                    }
                }
                else
                {
                    I = I + 1;
                    j = I + 1;
                }
                if (j > Malla.Rows.Count - 2) S = 1;
            } while (S != 1);
        }    
    }
}
