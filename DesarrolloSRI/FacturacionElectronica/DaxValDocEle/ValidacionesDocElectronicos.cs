using System;
using System.Text.RegularExpressions;

namespace DaxValDocElec
{
    public static class ValidacionesDocElectronicos
    {
        public static Boolean ValidarEmail(String email)
        {
            if (email.IndexOf("@") < 0) return false;
            if (email.IndexOf(".") < 0) return false;
            return true;

            //String expresion;
            //expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            //if (Regex.IsMatch(email, expresion))
            //{
            //    if (Regex.Replace(email, expresion, String.Empty).Length == 0)
            //    {
            //        return true;
            //    }
            //    else
            //    {
            //        return false;
            //    }
            //}
            //else
            //{
            //    return false;
            //}

        }
    }
}
