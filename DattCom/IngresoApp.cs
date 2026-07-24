using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DattCom
{
    public static class IngresoApp
    {
        public static void iniciar(string strCampo)
        {
            // esta clase ebe corresrse siempre antes de iniciar una aplicacion desde el adcom o  una aplicacion que se ejecuta directamente para controlar la empresa y el UsuarioBd que ingresa
            //strcampos viene desde adcom   15 campos separados por ^ para llenar la clase
            //                desde aplicacion en modo debug el path de la aplicacion en este formato #1E:\ArchivosDePrograma\Prog\  
            //                desde aplicacion cuando se ejecuta viene unicamente la opción a correr dentro de la aplicacion
            //                desde la aplicacion cuando se ejecuta simplemente viene vacio

            int nroCampos = 0;
            string BakOpcion = "";
            String Pathappl = "";
            if (strCampo.Length > 1)
            { if (strCampo.Substring(0, 2) == "#1") { Pathappl = strCampo.Substring(2); strCampo = ""; datosEmpresa.pathAppl = Pathappl; } }

            if (Pathappl.Length == 0)
            {
                datosEmpresa.pathAppl = Environment.CurrentDirectory + @"\";
            }
            try
            {
                if (strCampo.Length > 0)
                {
                    string[] mat = (strCampo).Split(Convert.ToChar("^"));
                    nroCampos = mat.Length;
                    if (nroCampos == 1) { BakOpcion = strCampo; strCampo = ""; }
                }
            }
            catch { }

            if (strCampo.Length == 0)
            {
                strCampo = Class3.cargarValoresIniciales();
            }
            if (strCampo.Length > 2 && strCampo.Substring(0, 3) != "ERR")
            {
                string aux = strCampo.Replace(" ", "|");
                string[] matriz = (aux + "^^^^^").Split(Convert.ToChar("^"));

                datosEmpresa.codEmpresa = Convert.ToInt16(comPar(matriz[0]));
                datosEmpresa._Emp_Nombre = comPar(matriz[1]);
                datosEmpresa.pathAppl = comPar(matriz[2]);
                datosEmpresa.pathServer = comPar(matriz[3]);
                datosEmpresa.usr = comPar(matriz[4]);
                datosEmpresa.auto = comPar(matriz[5]);

                datosEmpresa.Servidor = comPar(matriz[6]);
                datosEmpresa.UsuarioBd = comPar(matriz[7]);
                datosEmpresa.ClaveBd = comPar(matriz[8]);

                datosEmpresa.nombreBaseAdcom = comPar(matriz[9]);
                datosEmpresa.nombreBaseDaxpro = comPar(matriz[10]);
                datosEmpresa.nombreBaseIvaret = comPar(matriz[11]);
                datosEmpresa.nombreBaseSis = comPar(matriz[12]);
                datosEmpresa.sistema = matriz[12];
                datosEmpresa.suc = comPar(matriz[13]);
                datosEmpresa.sucNom = comPar(matriz[14]);
                datosEmpresa.opcion = comPar(matriz[15]);
                
                datosEmpresa._strConIniSis = ArmStr("SysBD", datosEmpresa.Servidor, "10", datosEmpresa.ClaveBd, datosEmpresa.UsuarioBd);
                datosEmpresa._strConxAdcom = ArmStr(datosEmpresa.nombreBaseAdcom, datosEmpresa.Servidor, "10", datosEmpresa.ClaveBd, datosEmpresa.UsuarioBd);                
                datosEmpresa._strConxIvaret = ArmStr(datosEmpresa.nombreBaseIvaret, datosEmpresa.Servidor, "10", datosEmpresa.ClaveBd, datosEmpresa.UsuarioBd);              
                datosEmpresa.strConIniSis6 = ArmStr("SysBD", datosEmpresa.Servidor, "6", datosEmpresa.ClaveBd, datosEmpresa.UsuarioBd);
                datosEmpresa.strConxAdcom6 = ArmStr(datosEmpresa.nombreBaseAdcom, datosEmpresa.Servidor, "6", datosEmpresa.ClaveBd, datosEmpresa.UsuarioBd);
                try
                {
                    datosEmpresa.auto = DecimalBinario(Convert.ToInt64("0" + datosEmpresa.auto.ToString().Trim()) / 3);
                }
                catch { }
                if (Pathappl.Length > 0) datosEmpresa.pathAppl = Pathappl;
            }

        }
        public static string ArmStr(string Path, string Serv = "", string tipo = "", string PasswBd = "", string UsuarioBd = "", Int32 Version = 0)
        {
            string cadena = "";
            if (tipo == "ACC")
            {
                cadena = "DRIVER={Microsoft Access Driver (*.mdb)};";
                cadena += " DBQ=" + Path + ";";
                cadena += " UID=" + UsuarioBd + ";PWD=" + PasswBd + ";";
            }
            else if (tipo == "6")
            {
                cadena = "Provider=MSDASQL;DRIVER=SQL Server;";
                cadena = cadena + "SERVER=" + Serv + ";";
                cadena = cadena + "UID=" + UsuarioBd.Trim() + ";";
                cadena = cadena + "PWD=" + PasswBd + ";";
                cadena = cadena + "APP=AdcomDx;";
                cadena = cadena + "WSID=" + Serv.ToUpper() + ";";
                cadena = cadena + "DATABASE=" + Path + ";";
            }
            else
            {
                cadena = "server=" + Serv + ";";
                cadena = cadena + "user id=" + UsuarioBd.Trim() + ";";
                cadena = cadena + "password=" + PasswBd + ";";
                cadena = cadena + "database=" + Path + ";";
                cadena = cadena + "pooling=false";
            }

            return cadena;
        }

        private static string comPar(string campo)
        {
            return campo.Replace("|", " ");
        }
        private static string DecimalBinario(long numDec)
        {
            string TOTAL = "";
            long X = 0;
            while (numDec > 0)
            {
                X = Convert.ToInt64(numDec / 2);
                if (numDec != (X * 2)) TOTAL = "1" + TOTAL; else TOTAL = "0" + TOTAL;
                numDec = X;
            }
            return TOTAL;
        }
    }
}
