using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace adcArticulosPrecios
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
            //if (arg.Length > 0)
            //{
            //    string var = arg[0];
            //    varbleComun.cargar.iniciar(var, "");
            //}
            Application.Run(new frmAdmPrecio());
        }
    }
}
