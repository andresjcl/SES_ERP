using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace daxEmiFacPv
{
    public class docIngreso
    {
        public void levantaDocumento(string doc = "R")
        {
            doc = doc.ToUpper();
            if (doc == "R")
            {
                formRem prog = new formRem();
                prog.Show();
                //prog = null;
            }
            if (doc == "F")
            {
                formFaccliAnt prog = new formFaccliAnt("FAC","FAC");
                prog.Show();
                //prog = null;
            }
            if (doc == "P")
            {
                formFaccliAnt prog = new formFaccliAnt("PRCPEC", "PRO");
                prog.Show();
                //prog = null;
            }
            if (doc == "D")
            {
                formCtbDia prog = new formCtbDia();
                prog.Show();
                //prog = null;
            }
            if (doc == "V")
            {
//                formCtbDia prog = new formPtoVta();
                //prog.Show();
                //prog = null;
            }
        }
    }
}
