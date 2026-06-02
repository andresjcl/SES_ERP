using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaxInvent
{
    public class MntClassArt
    {
        //public static string strConxAdcom = "";
        //public static string strConxSyscod = "";
        public MntClassArt()
        {

        }
        public void mantenimientoArt(string strconx, string strconxsys,string codigoArt)
        {
            MantArticulo prog = new MantArticulo();
            prog.Show();            
        }
        //dato, StrConxAdcom_10, strConIniSis_10, "", "", "", "", CDate(TxtFecha)
        public string BuscaArticuloSimple(string valInicalBuscar, string strconx, string strconxsys, string sucursal, string cliente, string numDoc, string tipDoc, DateTime fecha)
        {
            DateTime laFecha = DateTime.Now;
            try { laFecha = fecha; }
            catch { };
            frmBuscaArticuloSimple formbusca = new frmBuscaArticuloSimple(sucursal, cliente,numDoc, tipDoc);
            string codigoArt = formbusca.IniciaBuscaArt(valInicalBuscar, "", "", laFecha.ToShortTimeString(), "");
            formbusca.Dispose();
            return codigoArt;            
        }
    }
}
