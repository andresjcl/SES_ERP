using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace daxMallaDatos
{
    public class saldosMalla
    {
        public double SaldoMalla(string codigo,ref DataGridView Malla,int lineaActual)
        {
            double Saldo = 0;
            //Int32 lineaActual = Malla.CurrentRow.Index;
            foreach (DataGridViewRow row in Malla.Rows)
            {
                if (row.Cells["TRA_CODIGO"].Value.ToString() == codigo && lineaActual != row.Index)
                {
                    Saldo += Convert.ToDouble("0" + row.Cells["tra_Cantidad"].Value) * Convert.ToDouble("0" + row.Cells["tra_Multiplo"].Value);
                }
            }
            return Saldo;
        }
    }
}
