using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Adcmvart
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main(string [] cod)
        {
            string codigo = "";
            try
            {
                codigo = cod[0];
            }catch{}
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMovArt(codigo));
        }
    }
}
