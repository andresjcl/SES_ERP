using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DctosEmi
{
    public class AgruparMalla
    {
        public void AcumularLineasMalla(DataGridView malla, string Cantidad, string Parametro1, string Parametro2)
        {
            if (Parametro1.Length == 0 && Parametro2.Length > 0) { Parametro1 = Parametro2; Parametro2 = ""; }
            if (Cantidad.Length == 0 || Parametro1.Length == 0) return;
            foreach (DataGridViewRow dgvrow in malla.Rows)
            {
                double cantidad = 0;
                string codigo1 = "";
                try
                {
                    cantidad = Convert.ToDouble(dgvrow.Cells[Cantidad].Value);
                    codigo1 = dgvrow.Cells[Parametro1].Value.ToString();
                }
                catch { }
                if (cantidad > 0 && codigo1.Length > 0)
                {
                    for (int i = dgvrow.Index + 1; i < malla.Rows.Count; i++)
                    {
                        if (Parametro2.Length == 0)
                        {
                            if (codigo1 == malla.Rows[i].Cells[Parametro1].Value.ToString())
                            {
                                cantidad += Convert.ToDouble(malla.Rows[i].Cells[Cantidad].Value);
                                malla.Rows[i].Cells[Cantidad].Value = 0;
                            }
                        }
                        else
                        {
                            if (codigo1 == malla.Rows[i].Cells[Parametro1].Value.ToString()
                                && ComparaCeldas( dgvrow.Cells[Parametro2], malla.Rows[i].Cells[Parametro2]))
                            {
                                cantidad += Convert.ToDouble(malla.Rows[i].Cells[Cantidad].Value);
                                malla.Rows[i].Cells[Cantidad].Value = 0;
                            }
                        }
                    }
                    dgvrow.Cells[Cantidad].Value = cantidad;
                }
            }
            int I = 1;
            do
            {
                bool HuboCero = false;
                foreach (DataGridViewRow dgvrow in malla.Rows)
                {
                    try
                    {
                        if (Convert.ToDouble(dgvrow.Cells[Cantidad].Value) == 0) { malla.Rows.Remove(dgvrow); HuboCero = true; }
                    }
                    catch { }
                }
                if (!HuboCero) I = 0;

            } while (I == 1);
        }

        private bool ComparaCeldas(DataGridViewCell celda1, DataGridViewCell celda2)
        {
            try
            {
                if (Convert.ToDecimal(celda1.Value) == Convert.ToDecimal(celda2.Value)) return true;
            }
            catch { };
            try
            {
                if (celda1.Value == celda2.Value) return true;
            }
            catch { };
            return false;
        }
    }

}
