using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DattCom;
using System.Data.SqlClient;

namespace SES_ERP24
{
    public partial class frmGestionLicencia : Form
    {
        private DataTable _licenciaActual;
        private string _rucEmpresa;

        public frmGestionLicencia()
        {
            InitializeComponent();
            _rucEmpresa = datosEmpresa.Emp_RUC;
            CargarLicenciaActual();
        }

        // ============================================================
        // CARGAR LICENCIA ACTUAL
        // ============================================================
        private void CargarLicenciaActual()
        {
            try
            {
                if (string.IsNullOrEmpty(_rucEmpresa))
                {
                    lblInfoLicencia.Text = "⚠️ No se encontró RUC de la empresa";
                    lblInfoLicencia.ForeColor = Color.Red;
                    btnResetear.Enabled = false;
                    return;
                }

                string sql = @"
                    SELECT TOP 1 
                        Id,
                        RucEmpresa,
                        NombreEmpresa,
                        TipoLicencia,
                        MaxUsuarios,
                        FechaExpiracion,
                        ModulosActivos,
                        GruposActivos,
                        ClaveCliente,
                        ClaveActivacion,
                        Estado,
                        FechaGeneracion
                    FROM Licencias 
                    WHERE RucEmpresa = @RucEmpresa 
                      AND Estado = 'ACTIVA'
                    ORDER BY Id DESC";

                using (var conn = new SqlConnection(datosEmpresa.strConxSyscod))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@RucEmpresa", _rucEmpresa);
                        using (var reader = cmd.ExecuteReader())
                        {
                            _licenciaActual = new DataTable();
                            _licenciaActual.Load(reader);

                            if (_licenciaActual.Rows.Count > 0)
                            {
                                MostrarInformacionLicencia();
                            }
                            else
                            {
                                // Buscar licencia INACTIVA
                                string sqlInactiva = @"
                                    SELECT TOP 1 
                                        Id,
                                        RucEmpresa,
                                        NombreEmpresa,
                                        TipoLicencia,
                                        MaxUsuarios,
                                        FechaExpiracion,
                                        ModulosActivos,
                                        GruposActivos,
                                        ClaveCliente,
                                        ClaveActivacion,
                                        Estado,
                                        FechaGeneracion
                                    FROM Licencias 
                                    WHERE RucEmpresa = @RucEmpresa 
                                    ORDER BY Id DESC";

                                using (var cmdInactiva = new SqlCommand(sqlInactiva, conn))
                                {
                                    cmdInactiva.Parameters.AddWithValue("@RucEmpresa", _rucEmpresa);
                                    using (var readerInactiva = cmdInactiva.ExecuteReader())
                                    {
                                        _licenciaActual = new DataTable();
                                        _licenciaActual.Load(readerInactiva);

                                        if (_licenciaActual.Rows.Count > 0)
                                        {
                                            lblInfoLicencia.Text = "⚠️ Licencia INACTIVA (no vigente)";
                                            lblInfoLicencia.ForeColor = Color.Orange;
                                            MostrarInformacionLicencia();
                                            btnResetear.Enabled = false;
                                        }
                                        else
                                        {
                                            lblInfoLicencia.Text = "❌ No se encontró licencia";
                                            lblInfoLicencia.ForeColor = Color.Red;
                                            btnResetear.Enabled = false;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando licencia: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblInfoLicencia.Text = $"❌ Error: {ex.Message}";
                lblInfoLicencia.ForeColor = Color.Red;
            }
        }

        // ============================================================
        // MOSTRAR INFORMACIÓN DE LA LICENCIA
        // ============================================================
        private void MostrarInformacionLicencia()
        {
            if (_licenciaActual == null || _licenciaActual.Rows.Count == 0) return;

            try
            {
                var row = _licenciaActual.Rows[0];

                // Tipo de licencia
                int tipo = Convert.ToInt32(row["TipoLicencia"]);
                string tipoNombre = tipo == 1 ? "MONOUSUARIO" :
                                    tipo == 98 ? "DEMOSTRACIÓN" : "MULTIUSUARIO";

                lblTipoLicencia.Text = $"{tipoNombre} ({tipo})";

                // Usuarios
                lblUsuarios.Text = row["MaxUsuarios"].ToString();

                // Fecha expiración
                DateTime fechaExp = Convert.ToDateTime(row["FechaExpiracion"]);
                lblFechaExpiracion.Text = fechaExp.ToString("dd/MM/yyyy");
                int diasRestantes = (int)(fechaExp - DateTime.Now).TotalDays;
                lblDiasRestantes.Text = $"{diasRestantes} días";
                lblDiasRestantes.ForeColor = diasRestantes < 0 ? Color.Red :
                                             diasRestantes < 30 ? Color.Orange : Color.Green;

                // Estado
                string estado = row["Estado"].ToString();
                lblEstado.Text = estado;
                lblEstado.ForeColor = estado == "ACTIVA" ? Color.Green : Color.Red;

                // Claves
                txtClaveCliente.Text = row["ClaveCliente"].ToString();
                txtClaveActivacion.Text = row["ClaveActivacion"].ToString();

                // Módulos activos (solo mostrar, no editar)
                string modulosActivos = row["ModulosActivos"].ToString();
                txtModulosActivos.Text = modulosActivos;

                // Grupos activos
                txtGruposActivos.Text = row["GruposActivos"].ToString();

                // ID y Fecha
                lblIdLicencia.Text = $"ID: {row["Id"]}";
                lblFechaGeneracion.Text = $"Generada: {Convert.ToDateTime(row["FechaGeneracion"]):dd/MM/yyyy HH:mm}";

                // Mostrar módulos en el CheckedListBox (solo lectura)
                CargarModulosEnCheckList(modulosActivos);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error MostrarInformacionLicencia: {ex.Message}");
            }
        }

        // ============================================================
        // CARGAR MÓDULOS EN CHECKLIST (SOLO LECTURA)
        // ============================================================
        private void CargarModulosEnCheckList(string modulosActivos)
        {
            try
            {
                chkModulos.Items.Clear();

                if (string.IsNullOrEmpty(modulosActivos) || modulosActivos.Length < 35)
                {
                    chkModulos.Items.Add("⚠️ No hay módulos activos");
                    return;
                }

                // Obtener todos los módulos desde MenuSES
                string sql = @"
                    SELECT Menuprincipal, Clave, Descripcion
                    FROM MenuSES 
                    WHERE Clave IS NOT NULL AND Clave != '' AND Menuprincipal IS NOT NULL
                    ORDER BY Menuprincipal, orden";

                DataTable dt = SqlDatos.leerTabla(sql, datosEmpresa.strConIniSis);

                if (dt == null || dt.Rows.Count == 0)
                {
                    chkModulos.Items.Add("⚠️ No hay módulos en MenuSES");
                    return;
                }

                string grupoActual = "";
                foreach (DataRow row in dt.Rows)
                {
                    string grupo = row["Menuprincipal"].ToString();
                    string clave = row["Clave"].ToString();

                    // Mostrar grupo como encabezado
                    if (grupo != grupoActual)
                    {
                        grupoActual = grupo;
                        chkModulos.Items.Add($"📁 {grupo}", false);
                    }

                    // Verificar si el módulo está activo
                    int posicion = ObtenerPosicionModulo(clave);
                    bool activo = posicion >= 0 && posicion < modulosActivos.Length &&
                                  modulosActivos[posicion] == '1';

                    chkModulos.Items.Add($"   {(activo ? "✅" : "❌")} {clave}", false);
                }

                // Deshabilitar el CheckedListBox para que no se pueda editar
                chkModulos.Enabled = false;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error CargarModulosEnCheckList: {ex.Message}");
                chkModulos.Items.Clear();
                chkModulos.Items.Add($"❌ Error: {ex.Message}");
            }
        }

        // ============================================================
        // OBTENER POSICIÓN DE UN MÓDULO
        // ============================================================
        private int ObtenerPosicionModulo(string claveModulo)
        {
            var mapa = new Dictionary<string, int>()
            {
                {"PEDEmitir", 12}, {"FACEmitirPed", 12}, {"FACEmitir", 12},
                {"FACEmitirPto", 12}, {"ProfEmitir", 12},
                {"FAPEmitir", 3}, {"NCPEmitir", 3},
                {"MntArticulos", 8}, {"IngInventario", 8}, {"EgrInventario", 8},
                {"MovtArticulos", 8}, {"ExisBod", 8}, {"MntMedidas", 8},
                {"Recostear", 8}, {"TransferenciaInventarios", 8}, {"REMEmitir", 8},
                {"DGRegistros", 6}, {"DGReporteG", 6},
                {"SolicAutorizaSRI", 11}, {"RTPEmitir", 11}, {"RTCEmitir", 11},
                {"MntTablasSRI", 11}, {"importarXML", 11},
                {"MntDocumentos", 0}, {"MntServiciosBco", 0}, {"MntServiciosCprasVta", 0},
                {"MtnUsers", 0}, {"MtnEmpresa", 0}, {"MntFormaPago", 0},
                {"DocBancos", 2}, {"MnConciliacionBancos", 2}, {"MnCrearBancos", 2},
                {"CtaCorrListaGen", 5}, {"CtaCorrAnalisInd", 5},
                {"mnplanCuentas", 4}, {"MntBalances", 4},
                {"IMPEmitir", 7},
                {"RepListadoDoc", 10},
                {"importarDataCli", 1}, {"importarDataCuentas", 1}, {"importarDataProd", 1},
                {"Auditoria", 0}
            };

            return mapa.ContainsKey(claveModulo) ? mapa[claveModulo] : -1;
        }

        // ============================================================
        // BOTÓN: RESETEAR LICENCIA
        // ============================================================
        //private void btnResetear_Click(object sender, EventArgs e)
        //{
        //    if (MessageBox.Show("¿Está seguro de que desea resetear la licencia?\n\n" +
        //                      "Esto desactivará la licencia actual.\n" +
        //                      "El sistema deberá ser reactivado con una nueva clave.",
        //                      "Confirmar Reset",
        //                      MessageBoxButtons.YesNo,
        //                      MessageBoxIcon.Warning) == DialogResult.No)
        //        return;

        //    try
        //    {
        //        // 1. Desactivar licencia actual
        //        string sql = @"
        //            UPDATE Licencias 
        //            SET Estado = 'INACTIVA' 
        //            WHERE RucEmpresa = @RucEmpresa 
        //              AND Estado = 'ACTIVA'";

        //        using (var conn = new SqlConnection(datosEmpresa.strConxSyscod))
        //        {
        //            conn.Open();
        //            using (var cmd = new SqlCommand(sql, conn))
        //            {
        //                cmd.Parameters.AddWithValue("@RucEmpresa", _rucEmpresa);
        //                int rows = cmd.ExecuteNonQuery();

        //                if (rows > 0)
        //                {
        //                    MessageBox.Show("✅ Licencia reseteada exitosamente.\n\n" +
        //                                  "El sistema debe ser reactivado con una nueva clave.\n" +
        //                                  "Por favor, reinicie la aplicación.",
        //                                  "Reset Exitoso",
        //                                  MessageBoxButtons.OK,
        //                                  MessageBoxIcon.Information);

        //                    // Limpiar datos en memoria
        //                    datosEmpresa.TipoLicencia = 0;
        //                    datosEmpresa.ModulosActivos = "";
        //                    datosEmpresa.GruposActivos = "";
        //                    datosEmpresa.OpcionesLicencia = "";

        //                    this.DialogResult = DialogResult.OK;
        //                    this.Close();
        //                }
        //                else
        //                {
        //                    MessageBox.Show("No se encontró licencia activa para resetear", "Información",
        //                        MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Error al resetear licencia: {ex.Message}", "Error",
        //            MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}


        private void btnResetear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de que desea resetear la licencia?\n\n" +
                                "Esto desactivará la licencia actual y eliminará los accesos.\n" +
                                "El sistema se cerrará y deberá ser reactivado.",
                                "Confirmar Reset",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Warning) == DialogResult.No)
                return;

            try
            {
                using (var conn = new SqlConnection(datosEmpresa.strConxSyscod))
                {
                    conn.Open();

                    // ============================================================
                    // 1. DESACTIVAR LICENCIA EN TABLA Licencias
                    // ============================================================
                    string sqlLicencias = @"
                UPDATE Licencias 
                SET Estado = 'INACTIVA' 
                WHERE RucEmpresa = @RucEmpresa 
                  AND Estado = 'ACTIVA'";

                    using (var cmd = new SqlCommand(sqlLicencias, conn))
                    {
                        cmd.Parameters.AddWithValue("@RucEmpresa", _rucEmpresa);
                        int rowsLic = cmd.ExecuteNonQuery();
                        System.Diagnostics.Debug.WriteLine($"Licencias desactivadas: {rowsLic}");
                    }

                    // ============================================================
                    // 2. ELIMINAR REGISTROS DE SYS_ACCESOS (IMPORTANTE)
                    // ============================================================
                    string sqlSys = @"
                DELETE FROM sys_Accesos 
                WHERE IdUsuario IN ('Adm', 'Ctrl', 'System')
                  AND IdEmpresa = 0 
                  AND IdSistema = 'SES'";

                    using (var cmd = new SqlCommand(sqlSys, conn))
                    {
                        int rowsSys = cmd.ExecuteNonQuery();
                        System.Diagnostics.Debug.WriteLine($"sys_Accesos eliminados: {rowsSys}");
                    }

                    // ============================================================
                    // 3. LIMPIAR sys_Accesos ADICIONAL (por si quedan otros)
                    // ============================================================
                    string sqlSysExtra = @"
                DELETE FROM sys_Accesos 
                WHERE IdSistema = 'SES' 
                  AND IdEmpresa = 0 
                  AND (IdUsuario LIKE '%Adm%' OR IdUsuario LIKE '%Ctrl%' OR IdUsuario LIKE '%Sys%')";

                    using (var cmd = new SqlCommand(sqlSysExtra, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }

                // ============================================================
                // 4. LIMPIAR DATOS EN MEMORIA
                // ============================================================
                datosEmpresa.TipoLicencia = 0;
                datosEmpresa.ModulosActivos = "";
                datosEmpresa.GruposActivos = "";
                datosEmpresa.OpcionesLicencia = "";

                MessageBox.Show("✅ Licencia reseteada exitosamente.\n\n" +
                              "Se han eliminado los accesos del sistema.\n" +
                              "El sistema se cerrará. Reinicie y reactive con una nueva clave.",
                              "Reset Exitoso",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Information);

                // ============================================================
                // 5. CERRAR LA APLICACIÓN
                // ============================================================
                this.DialogResult = DialogResult.OK;
                this.Close();
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al resetear licencia: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // BOTÓN: COPIAR CLAVES
        // ============================================================
        private void btnCopiarClaves_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtClaveCliente.Text) && string.IsNullOrEmpty(txtClaveActivacion.Text))
            {
                MessageBox.Show("No hay claves para copiar", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string texto = $"Clave Cliente: {txtClaveCliente.Text}\n" +
                          $"Clave Activación: {txtClaveActivacion.Text}";
            Clipboard.SetText(texto);
            MessageBox.Show("Claves copiadas al portapapeles", "Éxito",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ============================================================
        // BOTÓN: CERRAR
        // ============================================================
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}