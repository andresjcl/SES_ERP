using System;
using System.Windows.Forms;
using DattCom;

namespace SES_ERP24
{
    public static class AutorizarLlamadas
    {
        //public static bool VerificaAutorización(string opcion)
        //{
        //    // ============================================================
        //    // TODOS LOS USUARIOS (INCLUYENDO ADMIN) RESPETAN LA LICENCIA
        //    // ============================================================

        //    // Si es MONO (1), permitir todo
        //    if (DattCom.datosEmpresa.TipoLicencia == 1)
        //        return true;

        //    // Si no hay licencia válida, denegar
        //    if (DattCom.datosEmpresa.TipoLicencia == 0 ||
        //        string.IsNullOrEmpty(DattCom.datosEmpresa.ModulosActivos))
        //    {
        //        MessageBox.Show("Licencia no válida o sin módulos activos", "Error",
        //            MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return false;
        //    }

        //    // Verificar permiso usando la posición en ModulosActivos
        //    return TienePermisoModulo(opcion, DattCom.datosEmpresa.ModulosActivos);
        //}

        public static bool VerificaAutorización(string opcion)
        {
            // ============================================================
            // DIAGNÓSTICO
            // ============================================================
            System.Diagnostics.Debug.WriteLine($"=== VerificaAutorización: {opcion} ===");
            System.Diagnostics.Debug.WriteLine($"TipoLicencia: {DattCom.datosEmpresa.TipoLicencia}");
            System.Diagnostics.Debug.WriteLine($"ModulosActivos: {DattCom.datosEmpresa.ModulosActivos}");
            System.Diagnostics.Debug.WriteLine($"ModulosActivos.Length: {DattCom.datosEmpresa.ModulosActivos?.Length ?? 0}");

            // Si es MONO (1), permitir todo
            if (DattCom.datosEmpresa.TipoLicencia == 1)
            {
                System.Diagnostics.Debug.WriteLine("MONO: Permitiendo todo");
                return true;
            }

            // Si no hay licencia válida, denegar
            if (DattCom.datosEmpresa.TipoLicencia == 0 ||
                string.IsNullOrEmpty(DattCom.datosEmpresa.ModulosActivos))
            {
                System.Diagnostics.Debug.WriteLine("Sin licencia o ModulosActivos vacío");
                return false;
            }

            // Verificar permiso usando la posición en ModulosActivos
            bool resultado = TienePermisoModulo(opcion, DattCom.datosEmpresa.ModulosActivos);
            System.Diagnostics.Debug.WriteLine($"Resultado para {opcion}: {resultado}");
            return resultado;
        }

        private static bool TienePermisoModulo(string claveModulo, string modulosActivos)
        {
            if (string.IsNullOrEmpty(modulosActivos) || modulosActivos.Length < 35)
                return false;

            int posicion = ObtenerPosicionModulo(claveModulo);

            if (posicion >= 0 && posicion < modulosActivos.Length)
            {
                return modulosActivos[posicion] == '1';
            }

            return false;
        }

        private static int ObtenerPosicionModulo(string claveModulo)
        {
            var mapa = new System.Collections.Generic.Dictionary<string, int>()
            {
                // Ventas (Posición 1)
                {"PEDEmitir", 1},
                {"FACEmitirPed", 1},
                {"FACEmitir", 1},
                {"FACEmitirPto", 1},
                {"ProfEmitir", 1},
                
                // Compras (Posición 3)
                {"FAPEmitir", 3},
                {"NCPEmitir", 3},
                
                // Inventarios (Posición 8)
                {"MntArticulos", 8},
                {"IngInventario", 8},
                {"EgrInventario", 8},
                {"MovtArticulos", 8},
                {"ExisBod", 8},
                {"MntMedidas", 8},
                {"Recostear", 8},
                {"TransferenciaInventarios", 8},
                {"REMEmitir", 8},
                
                // Directorio (Posición 6)
                {"DGRegistros", 6},
                {"DGReporteG", 6},
                
                // SRI (Posición 5)
                {"SolicAutorizaSRI", 5},
                {"RTPEmitir", 5},
                {"RTCEmitir", 5},
                {"MntTablasSRI", 5},
                {"importarXML", 5},
                {"AnexoTransaccional", 5},

                
                // Administración (Posición 0)
                {"MntDocumentos", 0},
                {"MntServiciosBco", 0},
                {"MntServiciosCprasVta", 0},
                {"MtnUsers", 0},
                {"MtnEmpresa", 0},
                {"MntFormaPago", 0},
                
                // Bancos (Posición 2)
                {"DocBancos", 2},
                {"MnConciliacionBancos", 2},
                {"MnCrearBancos", 2},
                
                // Cuentas Corrientes (Posición 5)
                {"CtaCorrListaGen", 5},
                {"CtaCorrAnalisInd", 5},
                
                // Contabilidad (Posición 4)
                {"mnplanCuentas", 4},
                {"MntBalances", 4},
                {"menuValidacionAsientos", 4},
                {"menuAnalisiMovCuenta", 4},
                
                // Importaciones (Posición 7)
                {"IMPEmitir", 7},
                
                // Reportes (Posición 10)
                {"RepListadoDoc", 10},
                
                // Ayudas (Posición 1)
                {"importarDataCli", 1},
                {"importarDataCuentas", 1},
                {"importarDataProd", 1},
                
                // Auditoria (Posición 0 - Administración)
                {"Auditoria", 0}
            };

            if (mapa.ContainsKey(claveModulo))
                return mapa[claveModulo];

            return -1;
        }
    }
}