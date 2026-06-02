using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DaxConxfe2
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string val=";;;;;;;";
            string[] pass = Environment.GetCommandLineArgs ();
            if (pass.Length > 5)
            {
                char sep = Convert.ToChar(";");
                if (pass.Length < 9) pass = val.Split(sep);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1(pass[1], pass[2], pass[3], pass[4], pass[5],pass[6],pass[7],pass[8],pass[9]));
            }
        }
    }
}
