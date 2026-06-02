using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImpresionDocumentosDax
{
    class Reglas
    {
        static internal string[] QueFormatoImprime(sesSys.OpcDoc PropiedadesDoc, bool ImprimeCtb, string OtraImpresion)
        {
            string FormaToAImprimir = "";
            if (ImprimeCtb)
            {
                FormaToAImprimir = PropiedadesDoc.FormatoCtb;
            }
            else if (OtraImpresion != "")
            {
                if (OtraImpresion == "1")
                    FormaToAImprimir = PropiedadesDoc.FormatoAux_1 + "," + PropiedadesDoc.Impresora_1;
                else if (OtraImpresion == "2")
                    FormaToAImprimir = PropiedadesDoc.FormatoAux_2 + "," + PropiedadesDoc.Impresora_2;
                else if (OtraImpresion == "3")
                    FormaToAImprimir = PropiedadesDoc.FormatoAux_3 + "," + PropiedadesDoc.Impresora_3;
                else
                    FormaToAImprimir = OtraImpresion;
            }
            if (FormaToAImprimir == "") FormaToAImprimir = PropiedadesDoc.ImprimirForm;
            FormaToAImprimir += ",";
            if (PropiedadesDoc.FormatoAux_1.Length > 0) FormaToAImprimir += ";" + PropiedadesDoc.FormatoAux_1 + "," + PropiedadesDoc.Impresora_1;
            if (PropiedadesDoc.FormatoAux_2.Length > 0) FormaToAImprimir += ";" + PropiedadesDoc.FormatoAux_2 + "," + PropiedadesDoc.Impresora_2;
            if (PropiedadesDoc.FormatoAux_3.Length > 0) FormaToAImprimir += ";" + PropiedadesDoc.FormatoAux_3 + "," + PropiedadesDoc.Impresora_3;
            return FormaToAImprimir.Split(Convert.ToChar(";"));
        }
    }
}
