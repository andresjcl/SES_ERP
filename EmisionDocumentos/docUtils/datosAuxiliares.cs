using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace adcDocumentos
{
    public class datosAuxiliares
    {
        public static bool tieneDatoDetalle(string dato, PrySysp13.OpcDoc propiedadesDoc)
        {
            int i = propiedadesDoc.DatosAuxiliaresDet.IndexOf(dato);
            if (i >= 0) return true;
            return false;
        }
        public static bool tieneDatoDocumento(string dato, PrySysp13.OpcDoc propiedadesDoc)
        {
            int i = propiedadesDoc.DatosAuxiliares.IndexOf(dato);
            if (i >= 0) return true;
            return false;
        }


    }
}
