using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolicitarAutorizacionSRI
{
    public static class datosSri
    {
        public static string codigoIva(double valor, string strConxIvaret)
        {
            if (valor == 12.0)
                return "2";
            if (valor == 14.0)
                return "3";
            if (valor == 15.0)
                return "4";
            if (valor == 5.0)
                return "5";
            if (valor == 13.0)
                return "10";
            return valor == 8.0 ? "8" : "0";
        }
    }
}
