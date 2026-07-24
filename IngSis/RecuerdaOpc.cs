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
            // ============================================
            // DEPURACIÓN
            // ============================================
            //System.Diagnostics.Debug.WriteLine("=== guardarOpciones ===");
            //System.Diagnostics.Debug.WriteLine("clave recibida: '" + clave + "'");
            //System.Diagnostics.Debug.WriteLine("clave length: " + (clave ?? "").Length);

            string claveCodificada = Seguridad.Codificar(clave);
            //System.Diagnostics.Debug.WriteLine("clave codificada: '" + claveCodificada + "'");
            //System.Diagnostics.Debug.WriteLine("clave codificada length: " + (claveCodificada ?? "").Length);

            // Primera preferencia
            AuditSis.registrar.registraPreferencia(StrConxDaxSys, "0", Environment.MachineName, Environment.MachineName, datosEmpresa.sistema, "", "INGRESO", "IDENTIFICA", DattCom.DatosUsuario.codigo, DateTime.Now.ToString());

            // Segunda preferencia
            AuditSis.registrar.registraPreferencia(StrConxDaxSys, "0", Environment.MachineName, Environment.MachineName, datosEmpresa.sistema, "", "INGRESO", "EMPRESA", DattCom.datosEmpresa.Emp_codigo.ToString(), DateTime.Now.ToString());

            // Tercera preferencia - LA CLAVE
            AuditSis.registrar.registraPreferencia(StrConxDaxSys, "0", Environment.MachineName, Environment.MachineName, datosEmpresa.sistema, "", "INGRESO", "CLAVE", claveCodificada, DateTime.Now.ToString());

            System.Diagnostics.Debug.WriteLine("=== FIN guardarOpciones ===");
        }
        internal static void leerOpciones(string StrConxDaxSys)
        {
            usuario = AuditSis.registrar.obtenerPreferencia(StrConxDaxSys, "0", Environment.MachineName, datosEmpresa.sistema, "", "INGRESO", "IDENTIFICA");
            clave = Seguridad.DeCodificar(AuditSis.registrar.obtenerPreferencia(StrConxDaxSys, "0", Environment.MachineName, datosEmpresa.sistema, "", "INGRESO", "CLAVE"));
            empresa = "0" + AuditSis.registrar.obtenerPreferencia(StrConxDaxSys, "0", Environment.MachineName, datosEmpresa.sistema, "", "INGRESO", "EMPRESA");
        }
    }
}

