using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaitMensaje
{
    public class WMensaje
    {
        private static frmWMensaje frm1;
        public static void verMensaje(string mensaje)
        {
            frm1 = new frmWMensaje();
            frm1.VerMensaje(mensaje);
        }
        public static void cierraMensaje()
        {
            frm1.Close();
        }

    }
}
