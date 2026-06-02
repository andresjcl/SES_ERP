using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace PruebaFirmaV01
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //try
            //{
                Firma FM = new Firma();
                FM.strFileXml = args[0];
                FM.FirmarArchivoXML();
            //}
            //catch (Exception ee)
            //{
            //    MessageBox.Show("excepción firma: " + ee.Message);
            //}
            //            Application.Run(new Form1());
        }
    }
}
