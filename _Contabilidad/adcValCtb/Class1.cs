using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace adcValCtb
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            frmValidacionDia prog = new frmValidacionDia();
            prog.ShowDialog();
        }
    }
}
