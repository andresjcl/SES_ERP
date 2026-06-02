using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IvaRett 
{
    public class LibMalla
    {
        static internal void copiarLinea(DataGridViewRow FilaOrigen, DataGridViewRow FilaDestino)
        {
            for (int i =0;i < FilaOrigen.Cells.Count;i++)
            {
                FilaDestino.Cells[i].Value = FilaOrigen.Cells[i].Value;
            }
        }
    }
}
