using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace documentosPdf
{
    static class ExtensionDocumento
    {
        static public string NombrePdf(string nombreDocumento)
        {
            int indPto = nombreDocumento.IndexOf(".");
            if (indPto > -1)
            {
                nombreDocumento = nombreDocumento.Substring(0, indPto) + "PDF";
            }
            if (nombreDocumento.Substring(nombreDocumento.Length - 3) != ".PDF") nombreDocumento += ".PDF";
            return nombreDocumento;
        }
    }
}

