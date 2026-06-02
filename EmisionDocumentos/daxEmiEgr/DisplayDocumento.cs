using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;

namespace DctosEmi
{
    static public class DisplayClaseDoc
    {
        static public int EsIngreso = -1;
        static public bool EsCliente;
        static public bool EsProveeedor;
        static public bool ConCheque;
        static public bool ConFechaVence;
        static public bool Estransferencia;
    }
    internal class DisplayDocumento
    {
        internal string VisibilidadControles(string ClaseDoc)
        {
            DisplayClaseDoc.EsIngreso = -1;
            DisplayClaseDoc.EsCliente = false;
            DisplayClaseDoc.EsProveeedor = false;
            DisplayClaseDoc.Estransferencia = false;
            DisplayClaseDoc.ConCheque = false;
            DisplayClaseDoc.ConFechaVence = false;

            string TIT = "";
            switch (ClaseDoc)
            {
                case "ING":
                    TIT = "MANTENIMIENTO INGRESOS A CAJA O BANCOS";
                    DisplayClaseDoc.EsIngreso = -1;
                    DisplayClaseDoc.Estransferencia = true;
                    DisplayClaseDoc.ConCheque = true;
                    DisplayClaseDoc.ConFechaVence = true;
                    break;
                case "EGR":
                    TIT = "MANTENIMIENTO EGRESOS A CAJA O BANCOS";
                    DisplayClaseDoc.EsIngreso = -1;
                    DisplayClaseDoc.Estransferencia = true;
                    DisplayClaseDoc.ConCheque = true;
                    DisplayClaseDoc.ConFechaVence = true;
                    break;
            }

            return TIT;
        } 



    }
}
