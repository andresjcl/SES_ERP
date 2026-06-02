using System;
using System.Data.SqlClient;

namespace DattCom
{
	public static class DatosUsuario
    {
        internal static string _codigo = "";
        internal static string _nombre = "";
        internal static Int32 _Estado = 0;
        internal static string _FechaIngreso = DateTime.Now.ToShortDateString();
        internal static string _ClaveSecreta = "";
        internal static string _SucDef = "";  // sucursal por default
        internal static string _BodDef = "";   // bodega por default
        internal static Int32 _NumSuc = 0;     // numero de sucursales que accesa
        internal static string _Bods = "";     // string con bodegas a las que tiene acceso el usuario
        internal static Int32 _NumBod = 0;    // numero de bodegas
        internal static Int32 _Numdoc = 0;    // numero de documentos
        internal static string _CodAlex = "";
        internal static string _Profesion = "";
        internal static string _Sucs = "";
        public static string codigo
        {
            get { return _codigo; }
            set
            {
                _codigo = value;
                _Estado = ManejoDatosUsuario.VerificaClave();
            }
        }

        public static string nombre
        {
            get { return _nombre; }
        }

        public static Int32 Estado
        {
            get { return _Estado; }
        }

        public static string Sucs // compatibilidad version 6
        {
            get { return _Sucs; }
        }
        public static string SucsUsr()
        {
            return _Sucs;
        }

        public static string FechaIngreso
        {
            get { return _FechaIngreso; }
        }

        public static string ClaveSecreta
        {
            get { return _ClaveSecreta; }
            set { _ClaveSecreta = value; }
        }
        public static string SucDef
        {
            get { return _SucDef; }
        }

        public static string BodDef
        {
            get { return _BodDef; }
        }

        public static Int32 NumSuc
        {
            get { return _NumSuc; }
        }

        public static string Bods
        {
            get { return _Bods; }
        }

        public static Int32 NumBod
        {
            get { return _NumBod; }
        }

        public static Int32 Numdoc
        {
            get { return _Numdoc; }
        }

        public static string CodAlex
        {
            get { return _CodAlex; }
        }
        public static string Profesion
        {
            get { return _Profesion; }
        }

        // documentos a los que el usuario tiene acceso
        public static string DocsUsr(string tipodoc1)
        {
            return ManejoDatosUsuario.DocsUsr(tipodoc1);
        }
        public static string Docs(string tipodoc1, string tipodoc2, string tipodoc3, string tipodoc4, string tipodoc5, string tipodoc6)   // compatibilidad version 6
        {
            return ManejoDatosUsuario.DocsUsr(tipodoc1 + ";" + tipodoc2 + ";" + tipodoc3 + ";" + tipodoc4 + ";" + tipodoc5 + ";" + tipodoc6);
        }

        // sucursales a las que tiene acceso el usuario

        public static string Identifica
        {
            set
            {
                _codigo = value;
                //_Estado = ManejoDatosUsuario.VerificaClave();
            }
            get
            {
                return _codigo;
            }
        }
        public static string AutorizaIngreso(string NombreOpcion)
        {
            string resp = "";
            if (DatosUsuario.codigo.ToUpper() == "ADMINISTRADOR" || DatosUsuario.codigo.ToUpper() == "CONTROL") { return "T"; }
            string auxiliar = "SELECT * FROM sys_Accesos WHERE IdUsuario = '" + DatosUsuario.codigo.ToUpper() + "'" + " AND IdEmpresa = " + datosEmpresa.Emp_codigo.ToString() + " AND Idopcion = '" + NombreOpcion + "' and idsistema = '" + datosEmpresa.sistema + "' ";
            SqlDataReader RecClv = SqlDatos.leerBaseIniSis(auxiliar);
            try
            {
                if (RecClv.Read())
                {
                    resp = RecClv["Accesos"].ToString();
                }
            }
            catch { }
            RecClv.Close();
            return resp;
        }
    }

}
