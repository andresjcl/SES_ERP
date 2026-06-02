using System.Windows.Forms;
using System;


namespace CtasCorrientes
{
    public class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        public  void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmAnalisisIndCta());
            //Form1 prog = new Form1();
            //prog.Show();
        }
    }
}
