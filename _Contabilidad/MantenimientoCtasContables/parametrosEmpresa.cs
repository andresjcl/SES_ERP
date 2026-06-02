using System;

namespace MantCtb
{
    public static class emp
    {
        internal static DateTime InvUltAnu = new DateTime(1900, 1, 1);
        internal static DateTime RolCodMay = new DateTime(1900, 1, 1);
        internal static string CtaNumDigNivel = 0;
        internal static int CtaNumNiveles = 0;
        internal static int NumeroDigitos = 0;
        internal static bool Acf = false;
        internal static bool inv = false;
        internal static bool rol = false;
        internal static string autorizacion = "";

        public static void cargar()
        {
            var DatEmp = SysEmpDatt.datosEmpresa.leeParametrosEmp(" InvUltAnu, RolCodMay,CtaNumDigNivel,CtaNumNiveles,NumeroDigitos");
            if (DatEmp.Rows.Count > 0)
            {
                InvUltAnu = Convert.ToDateTime(DatEmp.Rows[0]["InvUltAnu"]);
                RolCodMay = Convert.ToDateTime(DatEmp.Rows[0]["RolCodMay"]);
                CtaNumDigNivel = DatEmp.Rows[0]["CtaNumDigNivel"].ToString();
                CtaNumNiveles = Convert.ToInt32(DatEmp.Rows[0]["CtaNumNiveles"]);
                NumeroDigitos = Convert.ToInt32(DatEmp.Rows[0]["NumeroDigitos"]);
            }
        }
    }
}