using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DaxGesvta
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //MessageBox.Show("ingreso");
            //try
            //{
            //    string OPCION = args[0];
            //}
            //catch { }
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new DaxGesvta());
            }
            catch (InvalidCastException e) 
            {
                MessageBox.Show(e.Message);
            }

        }
    }
}
