using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace daxenlCorr
{
    class Program
    {
        static void Main(string[] args)
        {
            string par = "";
            try
            {
                par = args[0];
            }
            catch {}                
            varbleComun.cargar.iniciar(par,"");

            FrmRepInv frmprog = new FrmRepInv();
            frmprog.ShowDialog ();
        }
     }    
}
