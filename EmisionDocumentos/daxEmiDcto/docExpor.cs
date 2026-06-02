using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace daxEmiFacPv
{
    public class docExpor
    {
        public string conexiondata = "";
        public void iniciaDocumento(ref classExporta exp)
        {
            frmExporta prog = new frmExporta ();
        //    exp = prog.iniciaForm(exp);
            prog.Export = exp;
            prog.ShowDialog();
            exp = prog.Export;
            prog.Dispose();
        }    
    }
}
