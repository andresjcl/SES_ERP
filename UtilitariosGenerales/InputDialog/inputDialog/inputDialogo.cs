using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace inputDialogo
{
    static public class inputDialogo
    {
        static public string ingresar(string Titulo,string Mensaje, string Default)
        {
            Form1 frm = new Form1();
            frm.label2.Text = Titulo;
            string elIngreso = frm.inicio(Mensaje, Default);
            frm.Dispose();
            return elIngreso;
        }
    }
}
