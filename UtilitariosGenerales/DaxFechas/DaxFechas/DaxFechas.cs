using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DaxFechas
{
    public class DaxFechas
    {
        public string DaxFecha(string laFecha)
        {
            FormFecha prog = new FormFecha();
            prog.laFecha = laFecha;
            prog.ShowDialog();
            laFecha = prog.laFecha;
            return laFecha;
        }
    }
}
