using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DattCom;
using LicDefAct;

namespace IngSis
{
    internal class RecuerdaOpciones
    {
        internal static string empresa = "";
        internal static string usuario = "";
        internal static string clave = "";
        internal static void guardarOpciones(string StrConxDaxSys, string clave)
        {
            AuditSis.registrar.registraPreferencia(StrConxDaxSys, "0", Environment.MachineName, datosEmpresa.sistema, "", "INGRESO", "IDENTIFICA", DattCom.DatosUsuario.codigo, DateTime.Now.ToString());
            AuditSis.registrar.registraPreferencia(StrConxDaxSys, "0", Environment.MachineName, datosEmpresa.sistema, "", "INGRESO", "EMPRESA", DattCom.datosEmpresa.Emp_codigo.ToString(), DateTime.Now.ToString());
            AuditSis.registrar.registraPreferencia(StrConxDaxSys, "0", Environment.MachineName, datosEmpresa.sistema, "", "INGRESO", "CLAVE", Seguridad.Codificar(clave), DateTime.Now.ToString());
        }
        internal static void leerOpciones(string StrConxDaxSys)
        {
            usuario = AuditSis.registrar.obtenerPreferencia(StrConxDaxSys, "0", Environment.MachineName, datosEmpresa.sistema, "", "INGRESO", "IDENTIFICA");
            clave = Seguridad.DeCodificar(AuditSis.registrar.obtenerPreferencia(StrConxDaxSys, "0", Environment.MachineName, datosEmpresa.sistema, "", "INGRESO", "CLAVE"));
            empresa = "0" + AuditSis.registrar.obtenerPreferencia(StrConxDaxSys, "0", Environment.MachineName, datosEmpresa.sistema, "", "INGRESO", "EMPRESA");
        }
    }
}

