using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace SES_ERP24
{
    public static class PermisosUsuario
    {
        private static HashSet<string> _permisos = null;
        private static string _usuarioActual = "";
        private static int _empresaActual = 0;
        private static string _sistemaActual = "";

        public static void Inicializar(string strConxDaxsys, string usuario, int empresa, string sistema)
        {
            _usuarioActual = usuario;
            _empresaActual = empresa;
            _sistemaActual = sistema;
            _permisos = null; // Forzar recarga
            CargarPermisos(strConxDaxsys);
        }

        private static void CargarPermisos(string strConxDaxsys)
        {
            _permisos = new HashSet<string>();

            try
            {
                string ssql = @"SELECT IdOpcion FROM sys_Accesos 
                               WHERE IdUsuario = '" + _usuarioActual.Replace("'", "''") + @"' 
                               AND IdEmpresa = " + _empresaActual + @" 
                               AND IdSistema = '" + _sistemaActual.Replace("'", "''") + @"' 
                               AND Accesos = '1'";

                DataTable dtPermisos = DattCom.SqlDatos.leerTabla(ssql, strConxDaxsys);

                if (dtPermisos != null && dtPermisos.Rows.Count > 0)
                {
                    foreach (DataRow row in dtPermisos.Rows)
                    {
                        string opcion = row["IdOpcion"].ToString().Trim();
                        if (!string.IsNullOrEmpty(opcion))
                        {
                            _permisos.Add(opcion);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error al cargar permisos: " + ex.Message, "Error",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        public static bool TienePermiso(string claveOpcion)
        {
            if (_permisos == null) return false;
            return _permisos.Contains(claveOpcion);
        }

        // Método para verificar si un menú principal debe mostrarse
        // Recibe una lista de las claves de los submenús que contiene
        public static bool DebeMostrarMenu(params string[] clavesSubmenus)
        {
            if (_permisos == null) return false;
            return clavesSubmenus.Any(clave => _permisos.Contains(clave));
        }
    }
}