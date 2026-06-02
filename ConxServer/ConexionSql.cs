using System;

namespace ConxServer
{
	class ConexionSql
    {
        public static string ArmStr(string Path, string Serv = "", string tipo = "", string Passw = "", string Usuario = "", Int32 Version = 0)
        {
            string cadena = "";
            string Clave = "";
            string User = "";
            if (tipo == "ACC")
            {
                cadena = "DRIVER={Microsoft Access Driver (*.mdb)};";
                cadena += " DBQ=" + Path + ";";
                cadena += " UID=" + Usuario + ";PWD=" + Passw + ";";
            }
            else if (tipo == "6")
            {
                Clave = Passw;
                User = Passw;
                if (Passw.ToUpper() == "ADCOM") { Clave = ""; User = ""; }

                cadena = "Provider=MSDASQL;DRIVER=SQL Server;";
                cadena = cadena + "SERVER=" + Serv + ";";
                cadena = cadena + "UID=" + Usuario.Trim() + ";";
                cadena = cadena + "PWD=" + Passw + ";";
                cadena = cadena + "APP=AdcomDx;";
                cadena = cadena + "WSID=" + Serv.ToUpper() + ";";
                cadena = cadena + "DATABASE=" + Path + ";";

            }
            else
            {
                Clave = Passw;
                User = Passw;
                if (Passw.ToUpper() == "ADCOM") { Clave = ""; User = ""; }

                cadena = "server=" + Serv + ";";
                cadena = cadena + "user id=" + Usuario.Trim() + ";";
                cadena = cadena + "password=" + Passw + ";";
                cadena = cadena + "database=" + Path + ";";
                cadena = cadena + "pooling=false";
            }

            return cadena;
        }
    }
}
