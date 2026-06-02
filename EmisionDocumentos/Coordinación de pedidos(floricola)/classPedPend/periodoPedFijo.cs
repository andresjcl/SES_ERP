using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classPedPend
{
    static public class periodoPedFijo
    {
        static public Int16 tipo = 0; // 1 semanal,2 quncenal, 3 mensual
        static public DateTime fechaInicia = new DateTime(1900, 01, 01);
        static public DateTime fechaFin = new DateTime(1900, 01, 01);
        static public string diaSemana = "";
        static public Int16 diaQuincena1 = 0;
        static public Int16 diaQuincena2 = 0;
        static public Int16 diaMes = 0;
    }
}
