using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DattCom;
using System.Data.SqlClient;
using System.Diagnostics;

namespace IngSis
{
    public partial class Acceso : Form
    {
        // ============================================================
        // VARIABLES
        // ============================================================
        private Int32 intentosFallidos = 0;
        private const int MAX_INTENTOS = 5;
        private DateTime? bloqueoHasta = null;
        private bool mostrarPassword = false;
        private string placeholderUsuario = "ejemplo@empresa.com";
        private string aplicativo = "SISTEMA-AC16";
        private bool procesoEnCurso = false;

        // ============================================================
        // CONSTRUCTOR
        // ============================================================
        public Acceso(string Aplicativo = "SISTEMA-AC16")
        {
            InitializeComponent();
            aplicativo = Aplicativo;
            Text = "REGISTRAR INGRESO AL SISTEMA " + Aplicativo;
            this.KeyPreview = true;
            this.KeyDown += Acceso_KeyDown;
            this.FormClosing += Acceso_FormClosing;

            iniciaAplicación();
            ConfigurarEstiloBotones();
            ConfigurarEventosTeclado();
        }

        // ============================================================
        // CONFIGURACIÓN DE ESTILOS Y EVENTOS
        // ============================================================
        private void ConfigurarEstiloBotones()
        {
            BtnContinuar.MouseEnter += (s, e) =>
                BtnContinuar.BackColor = Color.FromArgb(0, 80, 140);
            BtnContinuar.MouseLeave += (s, e) =>
                BtnContinuar.BackColor = Color.FromArgb(0, 115, 181);

            btnSalir.MouseEnter += (s, e) =>
                btnSalir.ForeColor = Color.FromArgb(0, 50, 120);
            btnSalir.MouseLeave += (s, e) =>
                btnSalir.ForeColor = Color.FromArgb(0, 115, 181);
        }

        private void ConfigurarEventosTeclado()
        {
            IdIngreso.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    ClaveSecreta.Focus();
                    e.SuppressKeyPress = true;
                }
            };

            ClaveSecreta.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    BtnContinuar.PerformClick();
                    e.SuppressKeyPress = true;
                }
            };
        }

        // ============================================================
        // INICIALIZACIÓN
        // ============================================================
        private void iniciaAplicación()
        {
            try
            {
                RegistrarLog("INICIO - Validando licencias...");

                double Licencias = LicDefAct.ChequeoLicencias.ChequearLicencias(
                    datosEmpresa.Major,
                    datosEmpresa.pathServer,
                    datosEmpresa.pathAppl,
                    datosEmpresa.sistema,
                    datosEmpresa.auto,
                    "23031957");

                if (Licencias == 0)
                {
                    MessageBox.Show("Error 1112 - No existen licencias activadas para el sistema",
                        "Error de licencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    RegistrarLog("ERROR - No existen licencias activadas");
                    Environment.Exit(0);
                }

                RegistrarLog($"Licencias validadas: {Licencias}");

                RecuerdaOpciones.leerOpciones(datosEmpresa.strConIniSis);

                if (RecuerdaOpciones.usuario.Length > 0 && RecuerdaOpciones.clave.Length > 0)
                {
                    IdIngreso.Text = RecuerdaOpciones.usuario;
                    IdIngreso.ForeColor = Color.Black;
                    ClaveSecreta.Text = RecuerdaOpciones.clave;
                    ClaveSecreta.PasswordChar = '●';
                }

                chkGuardarClaves.Checked = (ClaveSecreta.Text != "");

                if (string.IsNullOrWhiteSpace(IdIngreso.Text))
                {
                    IdIngreso.Text = System.Environment.UserName.ToString();
                    IdIngreso.ForeColor = Color.Black;
                }

                if (!string.IsNullOrWhiteSpace(ClaveSecreta.Text) && !string.IsNullOrWhiteSpace(IdIngreso.Text))
                {
                    try
                    {
                        int empresaId = 0;
                        if (!string.IsNullOrEmpty(RecuerdaOpciones.empresa))
                        {
                            int.TryParse(RecuerdaOpciones.empresa, out empresaId);
                        }

                        EmpresaInicio.cargarEmpresasUsuario(empresaId, IdIngreso.Text, DcEmp);

                        if (empresaId == 0)
                        {
                            DcEmp.SelectedValue = EmpresaInicio.EmpresaDeInicio(IdIngreso.Text);
                        }

                        if (DatosUsuario.Estado == 0 && DcEmp.Items.Count > 0)
                        {
                            if (DcEmp.SelectedValue == null)
                            {
                                if (DcEmp.Items.Count > 0)
                                    DcEmp.SelectedIndex = 0;
                                BtnContinuar.Focus();
                            }
                            else
                            {
                                IdIngreso.Focus();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        RegistrarLog($"Error cargando empresas: {ex.Message}");
                    }
                }

                BtnContinuar.Enabled = true;
                RegistrarLog("INICIO - Aplicación inicializada correctamente");
            }
            catch (Exception ex)
            {
                RegistrarLog($"ERROR CRÍTICO en iniciaAplicación: {ex.Message}");
                MessageBox.Show($"Error al inicializar la aplicación: {ex.Message}",
                    "Error crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // EVENTO MOSTRAR/OCULTAR CONTRASEÑA
        // ============================================================
        private void btnMostrarPass_Click(object sender, EventArgs e)
        {
            try
            {
                mostrarPassword = !mostrarPassword;
                ClaveSecreta.PasswordChar = mostrarPassword ? '\0' : '●';
                btnMostrarPass.Text = mostrarPassword ? "🙈" : "👁️";
                btnMostrarPass.BackColor = mostrarPassword ?
                    Color.FromArgb(220, 240, 255) : Color.Transparent;
            }
            catch (Exception ex)
            {
                RegistrarLog($"Error al mostrar/ocultar contraseña: {ex.Message}");
            }
        }

        // ============================================================
        // EVENTO CHECKBOX RECORDARME
        // ============================================================
        private void chkGuardarClaves_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (!chkGuardarClaves.Checked)
                {
                    ClaveSecreta.Text = "";
                }
                RegistrarLog($"Recordarme: {(chkGuardarClaves.Checked ? "Activado" : "Desactivado")}");
            }
            catch (Exception ex)
            {
                RegistrarLog($"Error en chkGuardarClaves: {ex.Message}");
            }
        }

        // ============================================================
        // EVENTO IDINGRESO_ENTER (Placeholder)
        // ============================================================
        private void IdIngreso_Enter(object sender, EventArgs e)
        {
            if (IdIngreso.Text == placeholderUsuario && IdIngreso.ForeColor == Color.Gray)
            {
                IdIngreso.Text = "";
                IdIngreso.ForeColor = Color.Black;
            }
        }

        // ============================================================
        // EVENTO IDINGRESO_LEAVE (Placeholder + Carga empresas)
        // ============================================================
        private void IdIngreso_Leave(object sender, EventArgs e)
        {
            try
            {
                // Placeholder
                if (string.IsNullOrWhiteSpace(IdIngreso.Text))
                {
                    IdIngreso.Text = placeholderUsuario;
                    IdIngreso.ForeColor = Color.Gray;
                    return;
                }

                // Cargar empresas si no hay
                if (DcEmp.Items.Count == 0 && IdIngreso.Text.Length > 0 && IdIngreso.Text != placeholderUsuario)
                {
                    int empresaId = 0;
                    if (!string.IsNullOrEmpty(RecuerdaOpciones.empresa))
                    {
                        int.TryParse(RecuerdaOpciones.empresa, out empresaId);
                    }

                    if (IdIngreso.Text == RecuerdaOpciones.usuario)
                    {
                        EmpresaInicio.cargarEmpresasUsuario(empresaId, IdIngreso.Text, DcEmp);
                    }
                    else
                    {
                        EmpresaInicio.cargarEmpresasUsuario(0, IdIngreso.Text, DcEmp);
                    }

                    if (DcEmp.Items.Count > 0 && DcEmp.SelectedIndex == -1)
                    {
                        DcEmp.SelectedIndex = 0;
                    }

                    BtnContinuar.Enabled = (DcEmp.Items.Count > 0);
                    RegistrarLog($"Empresas cargadas para usuario: {IdIngreso.Text}, Total: {DcEmp.Items.Count}");
                }
            }
            catch (Exception ex)
            {
                RegistrarLog($"Error en IdIngreso_Leave: {ex.Message}");
                MessageBox.Show($"Error al cargar empresas: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // EVENTO IDINGRESO_TEXTCHANGED
        // ============================================================
        private void IdIngreso_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (DcEmp.DataSource != null)
                {
                    DcEmp.DataSource = null;
                    DcEmp.Items.Clear();
                }
                BtnContinuar.Enabled = false;

                // Validación visual de email
                if (!string.IsNullOrWhiteSpace(IdIngreso.Text) && IdIngreso.Text != placeholderUsuario)
                {
                    if (IdIngreso.Text.Contains("@"))
                    {
                        try
                        {
                            var addr = new System.Net.Mail.MailAddress(IdIngreso.Text);
                            IdIngreso.BackColor = Color.FromArgb(240, 255, 240);
                        }
                        catch
                        {
                            IdIngreso.BackColor = Color.FromArgb(255, 240, 240);
                        }
                    }
                    else
                    {
                        IdIngreso.BackColor = Color.FromArgb(248, 249, 250);
                    }
                }
            }
            catch (Exception ex)
            {
                RegistrarLog($"Error en IdIngreso_TextChanged: {ex.Message}");
            }
        }

        // ============================================================
        // BOTÓN LOGIN
        // ============================================================
        private void BtnContinuar_Click(object sender, EventArgs e)
        {
            if (procesoEnCurso) return;

            try
            {
                if (bloqueoHasta.HasValue && DateTime.Now < bloqueoHasta.Value)
                {
                    TimeSpan restante = bloqueoHasta.Value - DateTime.Now;
                    MessageBox.Show($"🔒 Demasiados intentos fallidos.\nEspera {restante.Minutes} minutos.",
                        "Sistema bloqueado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string usuario = IdIngreso.Text.Trim();
                string password = ClaveSecreta.Text.Trim();

                if (string.IsNullOrWhiteSpace(usuario) || usuario == placeholderUsuario)
                {
                    MessageBox.Show("⚠️ Debe digitar su identificación de acceso",
                        "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    IdIngreso.Focus();
                    IdIngreso.SelectAll();
                    return;
                }

                if (string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show("⚠️ Debe digitar su clave secreta",
                        "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ClaveSecreta.Focus();
                    ClaveSecreta.SelectAll();
                    return;
                }

                if (DcEmp.Items.Count < 1 || DcEmp.SelectedValue == null)
                {
                    MessageBox.Show("⚠️ No existe una empresa definida o seleccionada",
                        "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    DcEmp.Focus();
                    return;
                }

                procesoEnCurso = true;
                BtnContinuar.Enabled = false;
                BtnContinuar.Text = "⏳ Validando...";
                IdIngreso.Enabled = false;
                ClaveSecreta.Enabled = false;
                DcEmp.Enabled = false;
                chkGuardarClaves.Enabled = false;
                btnSalir.Enabled = false;

                using (var worker = new System.ComponentModel.BackgroundWorker())
                {
                    bool loginExitoso = false;
                    Exception error = null;

                    worker.DoWork += (s, ev) =>
                    {
                        try
                        {
                            ev.Result = verificacionDeSalidaMejorada(usuario, password);
                        }
                        catch (Exception ex)
                        {
                            ev.Result = false;
                            error = ex;
                        }
                    };

                    worker.RunWorkerCompleted += (s, ev) =>
                    {
                        try
                        {
                            loginExitoso = (bool)ev.Result;

                            if (loginExitoso)
                            {
                                intentosFallidos = 0;
                                bloqueoHasta = null;

                                if (chkGuardarClaves.Checked)
                                {
                                    RecuerdaOpciones.guardarOpciones(datosEmpresa.strConxSyscod, ClaveSecreta.Text);
                                }

                                RegistrarLog($"✅ LOGIN EXITOSO - Usuario: {usuario}");
                                MessageBox.Show($"✅ ¡Bienvenido {usuario}!", "Acceso exitoso",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                                RegistrarAcceso();
                                Close();
                            }
                            else
                            {
                                intentosFallidos++;
                                RegistrarLog($"❌ LOGIN FALLIDO - Usuario: {usuario}, Intentos: {intentosFallidos}");

                                if (intentosFallidos >= MAX_INTENTOS)
                                {
                                    bloqueoHasta = DateTime.Now.AddMinutes(15);
                                    MessageBox.Show($"🔒 Bloqueado por 15 minutos.",
                                        "Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                                else
                                {
                                    MessageBox.Show($"❌ Usuario o contraseña incorrectos.\nIntentos restantes: {MAX_INTENTOS - intentosFallidos}",
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                                ClaveSecreta.Text = "";
                                ClaveSecreta.Focus();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"❌ Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            RegistrarLog($"🔥 ERROR: {ex.Message}");
                        }
                        finally
                        {
                            procesoEnCurso = false;
                            BtnContinuar.Enabled = true;
                            BtnContinuar.Text = "INICIAR SESIÓN";
                            IdIngreso.Enabled = true;
                            ClaveSecreta.Enabled = true;
                            DcEmp.Enabled = true;
                            chkGuardarClaves.Enabled = true;
                            btnSalir.Enabled = true;
                        }
                    };

                    worker.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                RegistrarLog($"🔥 ERROR CRÍTICO: {ex.Message}");

                procesoEnCurso = false;
                BtnContinuar.Enabled = true;
                BtnContinuar.Text = "INICIAR SESIÓN";
                IdIngreso.Enabled = true;
                ClaveSecreta.Enabled = true;
                DcEmp.Enabled = true;
                chkGuardarClaves.Enabled = true;
                btnSalir.Enabled = true;
            }
        }

        // ============================================================
        // VALIDACIÓN DE SALIDA
        // ============================================================
        private Boolean verificacionDeSalidaMejorada(string usuario, string password)
        {
            try
            {
                datosEmpresa.Emp_codigo = Convert.ToInt16(DcEmp.SelectedValue);
                ManejoDatosEmpresa.LeerDatosEmpresa(
                    datosEmpresa.strConxSyscod,
                    datosEmpresa.UsuarioBd,
                    datosEmpresa.ClaveBd,
                    datosEmpresa.Servidor);

                if (datosEmpresa.Emp_codigo == 0)
                {
                    RegistrarLog("Error al cargar la empresa seleccionada");
                    return false;
                }

                CargarLicenciaActiva();

                string resultado = DelUsuario.VerificarClave(password, usuario);

                if (!string.IsNullOrEmpty(resultado))
                {
                    return true;
                }
                else
                {
                    RegistrarLog($"⚠️ Verificación fallida para usuario: {usuario}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                RegistrarLog($"ERROR en verificacionDeSalidaMejorada: {ex.Message}");
                throw;
            }
        }

        // ============================================================
        // CARGAR LICENCIA
        // ============================================================
        private void CargarLicenciaActiva()
        {
            try
            {
                if (string.IsNullOrEmpty(datosEmpresa.Emp_RUC))
                {
                    RegistrarLog("ADVERTENCIA: Emp_RUC vacío");
                    return;
                }

                string ruc = datosEmpresa.Emp_RUC;
                RegistrarLog($"Buscando licencia para RUC: {ruc}");

                string sql = @"
                    SELECT TOP 1 
                        TipoLicencia,
                        MaxUsuarios,
                        FechaExpiracion,
                        ModulosActivos,
                        GruposActivos
                    FROM Licencias 
                    WHERE RucEmpresa = @RucEmpresa 
                      AND Estado = 'ACTIVA' 
                      AND FechaExpiracion >= GETDATE()
                    ORDER BY Id DESC";

                using (var conn = new SqlConnection(datosEmpresa.strConxSyscod))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@RucEmpresa", ruc);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                datosEmpresa.TipoLicencia = Convert.ToInt32(reader["TipoLicencia"]);
                                datosEmpresa.MaxUsuarios = Convert.ToInt32(reader["MaxUsuarios"]);
                                datosEmpresa.FechaExpiracion = Convert.ToDateTime(reader["FechaExpiracion"]);
                                datosEmpresa.ModulosActivos = reader["ModulosActivos"].ToString();
                                datosEmpresa.GruposActivos = reader["GruposActivos"].ToString();

                                RegistrarLog($"Licencia cargada: Tipo={datosEmpresa.TipoLicencia}");
                            }
                            else
                            {
                                RegistrarLog($"No se encontró licencia para RUC: {ruc}");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                RegistrarLog($"Error cargando licencia: {ex.Message}");
            }
        }

        // ============================================================
        // REGISTRAR ACCESO
        // ============================================================
        private void RegistrarAcceso()
        {
            try
            {
                string usuario = IdIngreso.Text.ToUpper();
                string empresa = DcEmp.SelectedValue?.ToString() ?? "";
                int empresaId = Convert.ToInt16(empresa);

                DattCom.ManejoDatosEmpresa.grabarEmpresaRegistrada(empresa, usuario);

                datosEmpresa.usr = usuario;
                datosEmpresa.codEmpresa = Convert.ToInt16(empresaId);
                datosEmpresa.usr = usuario;

                RegistrarLog($"Registrando acceso - Usuario: {usuario}, Empresa: {empresaId}");

                if (usuario == "ADMINISTRADOR")
                {
                    IngSis.EmpresaInicio.IniciaEmpresa();
                }
                else
                {
                    DattCom.ManejoDatosUsuario.LeerDatosUsuarioDirectorio();
                    IngSis.EmpresaInicio.IniciaEmpresa();
                }

                RegistrarLog($"✅ Acceso registrado para {usuario}");
            }
            catch (Exception ex)
            {
                RegistrarLog($"ERROR en RegistrarAcceso: {ex.Message}");
                throw;
            }
        }

        // ============================================================
        // LOGS
        // ============================================================
        private void RegistrarLog(string mensaje)
        {
            try
            {
                string logPath = Path.Combine(Application.StartupPath, "Logs");
                if (!Directory.Exists(logPath))
                    Directory.CreateDirectory(logPath);

                string logFile = Path.Combine(logPath, $"login_{DateTime.Now:yyyy-MM-dd}.log");
                string linea = $"{DateTime.Now:HH:mm:ss} | {mensaje}";
                File.AppendAllText(logFile, linea + Environment.NewLine);
            }
            catch { }
        }

        // ============================================================
        // EVENTOS ADICIONALES
        // ============================================================
        private void Acceso_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                IdIngreso.Text = "";
                ClaveSecreta.Text = "";
                IdIngreso.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void Acceso_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                string conclave = chkGuardarClaves.Checked ? ClaveSecreta.Text : "";
                RecuerdaOpciones.guardarOpciones(datosEmpresa.strConxSyscod, conclave);

                if (e.CloseReason != CloseReason.ApplicationExitCall)
                {
                    DattCom.ManejoDatosEmpresa.ResetearEmpresaRegistrada();
                }

                RegistrarLog($"Formulario cerrado - Recordarme: {chkGuardarClaves.Checked}");
            }
            catch (Exception ex)
            {
                RegistrarLog($"ERROR en FormClosing: {ex.Message}");
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Estás seguro de que deseas salir?",
                "Confirmar salida",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                RegistrarLog("SALIDA - Usuario cerró sesión");
                DattCom.ManejoDatosEmpresa.ResetearEmpresaRegistrada();
                Environment.Exit(0);
            }
        }

        private void DcEmp_Click(object sender, EventArgs e)
        {
            try
            {
                if (DcEmp.SelectedValue != null)
                {
                    datosEmpresa.Emp_codigo = Convert.ToInt16(DcEmp.SelectedValue);
                    RegistrarLog($"Empresa seleccionada: {DcEmp.SelectedValue}");
                }
            }
            catch (Exception ex)
            {
                RegistrarLog($"Error en DcEmp_Click: {ex.Message}");
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            // Evento existente
        }
    }
}