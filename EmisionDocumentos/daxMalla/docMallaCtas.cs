using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Text;
using System.Data;
using adcArticulo;
//using adcArticulosValores;

namespace DtosMall
{
    public class docMallaCtas
    {
        public string sucursal = string.Empty;
        public string bodega = "";
        public string strConxAdcom = string.Empty;
        public string strConxDaxsys = string.Empty;
        public double impIva = 0;
        public string codCliente = string.Empty;
        public Int32 digPrecios = 2;
        public Int32 digCostos = 2;
        public DateTime fechaDoc;
        public string tipoDoc = "";
        public string numDoc = "";
        
        public string buscarCuenta(string buscador)
        {
            string nombre = "";
            string tipMov = "M";
            CtaMtn.BuscaCta busk = new CtaMtn.BuscaCta();
            string dato = busk.BuscaCtaCtb(ref nombre,ref tipMov );
            busk = null;
            return dato;
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
