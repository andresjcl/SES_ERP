using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DattCom;

namespace SES_ERP24
{
    //public class AutorizarLlamadas
    //    {
    //        public static bool VerificaAutorización(string idOpcion, Boolean SuprimeMensaje = false)
    //        {
    //            string resp = DatosUsuario.AutorizaIngreso(idOpcion);
    //            if (resp == "")
    //            {
    //                if (SuprimeMensaje == false) MessageBox.Show("No tiene acceso a esta funcion \nConsulte con el Administrador del sistema","Acceso Denegado",MessageBoxButtons.OK,MessageBoxIcon.Error);
    //                return false;
    //            }
    //            return true;
    //        }
    //    }

    public static class AutorizarLlamadas
    {
        public static bool VerificaAutorización(string claveOpcion)
        {
            // El usuario ADMINISTRADOR tiene acceso a todo
            string usuarioActual = DattCom.datosEmpresa.usr;
            if (usuarioActual.ToUpper() == "ADMINISTRADOR" || usuarioActual.ToUpper() == "ADMIN")
            {
                return true;
            }

            // Para los demás usuarios, verificar permisos
            HashSet<string> permisos = ObtenerPermisosUsuario();

            if (permisos.Contains(claveOpcion))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Acceso Denegado\n\nNo tiene acceso a esta función\nConsulte con el Administrador del sistema",
                    "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        private static HashSet<string> ObtenerPermisosUsuario()
        {
            HashSet<string> permisos = new HashSet<string>();

            try
            {
                string usuario = DattCom.datosEmpresa.usr;

                // Limpiar nombre de usuario
                if (!string.IsNullOrEmpty(usuario) && usuario.Contains(" "))
                {
                    usuario = usuario.Split(' ')[0];
                }

                int empresa = Convert.ToInt32(DattCom.datosEmpresa.Emp_codigo);
                string sistema = "CNX";
                string strConx = DattCom.datosEmpresa.strConIniSis;

                string ssql = $@"SELECT DISTINCT IdOpcion FROM sys_Accesos 
                           WHERE UPPER(LTRIM(RTRIM(IdUsuario))) = '{usuario.ToUpper().Trim()}' 
                           AND IdEmpresa = {empresa} 
                           AND IdSistema = '{sistema}' 
                           AND Accesos = 'T'";

                DataTable dtPermisos = DattCom.SqlDatos.leerTabla(ssql, strConx);

                if (dtPermisos != null)
                {
                    foreach (DataRow row in dtPermisos.Rows)
                    {
                        string opcion = row["IdOpcion"].ToString().Trim();
                        if (!string.IsNullOrEmpty(opcion))
                        {
                            permisos.Add(opcion);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener permisos: " + ex.Message);
            }

            return permisos;
        }
    }

}
