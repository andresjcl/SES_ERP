using System;
using System.Data.SqlClient;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using SysEmpDatt;

namespace MantCtb
{
    static class OperacionesBuscaCta
    {
        // Public ConxAdcom As New ADODB.Connection
        // Public ConxSysemp As New ADODB.Connection
        public static string con;
        // Public CONEMP As New AdcDax.DaxsofSys
        // Public Emp As AdcDax.Empresa
        // Public CONUSR As New DaxUsr.DaxsofUsr
        // Public ControlUsuario As DaxUsr.CtrlUsuario
        // Public libdat As New DaxLib.DaxLibDigDato
        // Public libbas As New DaxLib.DaxLibBases
        // Public libmens As New DaxLib.Mensajes
        public static string sSql;
        public static string Resultado;
        public static string NombreCta;
        public static string CodigoCta;
        public static short EsNuevo;
        private static SqlConnection conectar = new SqlConnection();

        public static string NombreCuentaContable(ref string codigo)
        {
            string NombreCuentaContableRet = default;
            var dat = SqlDatos.leerBase("SELECT Cta_Codigo,Cta_Nombre FROM AdcCta WHERE Cta_Codigo='" + Strings.Trim(codigo) + "'", datosEmpresa.strConxAdcom);
            if (dat.Read())
            {
                NombreCuentaContableRet = Conversions.ToString(dat["CTA_NOMBRE"]);
            }
            else
            {
                NombreCuentaContableRet = "";
            }
            // If RsAux.State = 1 Then RsAux.Close
            dat = null;
            return NombreCuentaContableRet;
        }

        public static string QuePadreDeCta(ref string CodCta, ref short CtaNivel)
        {
            string QuePadreDeCtaRet = default;
            float Lim;
            short i;
            if (CtaNivel == 1)
            {
                QuePadreDeCtaRet = "";
                return QuePadreDeCtaRet;
            }

            Lim = 0f;
            var loopTo = (short)(CtaNivel - 1);
            for (i = 1; i <= loopTo; i++)
                Lim = (float)(Lim + Conversion.Val(Strings.Mid(emp.CtaNumDigNivel.ToString(), i, 1)));
            QuePadreDeCtaRet = Strings.Mid(CodCta, 1, (int)Math.Round(Lim));
            return QuePadreDeCtaRet;
        }

        public static string PonerPtosCtas(ref string cta)
        {
            string PonerPtosCtasRet = default;
            int i;
            short[] OrgNiv;
            short cont;
            emp.CtaNumNiveles = 6;
            OrgNiv = new short[emp.CtaNumNiveles + 1];
            var loopTo = emp.CtaNumNiveles;
            for (i = 1; i <= loopTo; i++)
                OrgNiv[i] = (short)Math.Round(Conversion.Val(Strings.Mid(emp.CtaNumDigNivel.ToString(), i, 1)));
            // pongo los valores para saber de que largo debe ser la cadena para cambiar de nivel
            OrgNiv[2] = (short)(OrgNiv[1] + OrgNiv[2]);
            OrgNiv[3] = (short)(OrgNiv[2] + OrgNiv[3]);
            OrgNiv[4] = (short)(OrgNiv[3] + OrgNiv[4]);
            OrgNiv[5] = (short)(OrgNiv[4] + OrgNiv[5]);
            OrgNiv[6] = (short)(OrgNiv[5] + OrgNiv[6]);
            cont = 0;
            var loopTo1 = emp.CtaNumNiveles;
            for (i = 3; i <= loopTo1; i++)
            {
                if (Strings.Len(cta) - cont > OrgNiv[i])
                {
                    cta = Strings.Mid(cta, 1, OrgNiv[i] + cont) + "." + Strings.Mid(cta, OrgNiv[i] + cont + 1);
                    cont = (short)(cont + 1);
                }
            }

            PonerPtosCtasRet = cta;
            return PonerPtosCtasRet;
        }
    }
}