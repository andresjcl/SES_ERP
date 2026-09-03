using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DattCom;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace IngSis
{
    public partial class Acceso : Form
    {
        // ============================================================
        // VARIABLES ORIGINALES (MANTENIDAS)
        // ============================================================
        private Int32 Validaciones = 0;
        private const int MAX_INTENTOS = 5;
        private DateTime? bloqueoHasta = null;
        private bool mostrarPassword = false;
        private string placeholderUsuario = "usuario@empresa.com";
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
            this.KeyDown += Acceso_KeyDown;
            this.FormClosing += Acceso_FormClosing;
            this.Load += Acceso_Load;

            ConfigurarEstiloBotones();
            ConfigurarEventosTeclado();
            CrearLabelFuerza();
        }

        // ============================================================
        // CREAR LABEL DE FUERZA
        // ============================================================
        private void CrearLabelFuerza()
        {
            if (!this.Controls.ContainsKey("lblFuerza"))
            {
                Label lblFuerza = new Label
                {
                    Name = "lblFuerza",
                    Font = new Font("Segoe UI", 8F),
                    AutoSize = true,
                    Location = new Point(
                        this.panelPassword.Location.X + 5,
                        this.panelPassword.Location.Y + this.panelPassword.Height + 5
                    ),
                    ForeColor = Color.Gray,
                    Visible = false
                };
                this.Controls.Add(lblFuerza);
                lblFuerza.BringToFront();
            }
        }

        // ============================================================
        // EVENTO LOAD
        // ============================================================
        private void Acceso_Load(object sender, EventArgs e)
        {
            iniciaAplicación();

            if (!string.IsNullOrWhiteSpace(IdIngreso.Text) && IdIngreso.Text != placeholderUsuario)
            {
                ClaveSecreta.Focus();
            }
            else
            {
                IdIngreso.Focus();
            }
        }

        // ============================================================
        // CONFIGURACIÓN DE ESTILOS
        // ============================================================
        private void ConfigurarEstiloBotones()
        {
            BtnContinuar.MouseEnter += (s, ev) =>
                BtnContinuar.BackColor = Color.FromArgb(0, 80, 140);
            BtnContinuar.MouseLeave += (s, ev) =>
                BtnContinuar.BackColor = Color.FromArgb(0, 115, 181);

            btnSalir.MouseEnter += (s, ev) =>
                btnSalir.ForeColor = Color.FromArgb(0, 50, 120);
            btnSalir.MouseLeave += (s, ev) =>
                btnSalir.ForeColor = Color.FromArgb(0, 115, 181);
        }

        private void ConfigurarEventosTeclado()
        {
            IdIngreso.KeyDown += (s, ev) =>
            {
                if (ev.KeyCode == Keys.Enter)
                {
                    ClaveSecreta.Focus();
                    ev.SuppressKeyPress = true;
                }
            };

            ClaveSecreta.KeyDown += (s, ev) =>
            {
                if (ev.KeyCode == Keys.Enter)
                {
                    BtnContinuar.PerformClick();
                    ev.SuppressKeyPress = true;
                }
            };
        }

        // ============================================================
        // INICIALIZACIÓN (TAL CUAL ESTABA)
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
                    chkGuardarClaves.Checked = true;
                }
                else
                {
                    chkGuardarClaves.Checked = false;
                }

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
                            if (DcEmp.SelectedValue == null && DcEmp.Items.Count > 0)
                            {
                                DcEmp.SelectedIndex = 0;
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
        // PLACEHOLDER USUARIO
        // ============================================================
        private void IdIngreso_Enter(object sender, EventArgs e)
        {
            if (IdIngreso.Text == placeholderUsuario && IdIngreso.ForeColor == Color.Gray)
            {
                IdIngreso.Text = "";
                IdIngreso.ForeColor = Color.Black;
            }
        }

        private void IdIngreso_Leave(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(IdIngreso.Text))
                {
                    IdIngreso.Text = placeholderUsuario;
                    IdIngreso.ForeColor = Color.Gray;
                    return;
                }

                if (DcEmp.Items.Count == 0 && IdIngreso.Text != placeholderUsuario)
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
                    RegistrarLog($"Empresas cargadas: {DcEmp.Items.Count}");
                }
            }
            catch (Exception ex)
            {
                RegistrarLog($"Error en IdIngreso_Leave: {ex.Message}");
                MessageBox.Show($"Error al cargar empresas: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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

                if (!string.IsNullOrWhiteSpace(IdIngreso.Text) && IdIngreso.Text != placeholderUsuario)
                {
                    if (IdIngreso.Text.Contains("@"))
                    {
                        try
                        {
                            var addr = new System.Net.Mail.MailAddress(IdIngreso.Text);
                            IdIngreso.BackColor = Color.FromArgb(220, 255, 220);
                        }
                        catch
                        {
                            IdIngreso.BackColor = Color.FromArgb(255, 220, 220);
                        }
                    }
                    else
                    {
                        IdIngreso.BackColor = Color.FromArgb(248, 249, 250);
                    }
                }
                else
                {
                    IdIngreso.BackColor = Color.FromArgb(248, 249, 250);
                }
            }
            catch (Exception ex)
            {
                RegistrarLog($"Error en IdIngreso_TextChanged: {ex.Message}");
            }
        }

        // ============================================================
        // INDICADOR DE FUERZA DE CONTRASEÑA
        // ============================================================
        private void ClaveSecreta_TextChanged(object sender, EventArgs e)
        {
            //string pass = ClaveSecreta.Text;
            //int fuerza = CalcularFuerzaPassword(pass);

            //if (!this.Controls.ContainsKey("lblFuerza"))
            //{
            //    CrearLabelFuerza();
            //}

            //Label lbl = (Label)this.Controls["lblFuerza"];

            //if (string.IsNullOrEmpty(pass))
            //{
            //    lbl.Visible = false;
            //    lbl.Text = "";
            //}
            //else if (fuerza < 3)
            //{
            //    lbl.Visible = true;
            //    lbl.Text = "🔴 Contraseña débil - Usa mayúsculas, números y símbolos";
            //    lbl.ForeColor = Color.Red;
            //}
            //else if (fuerza < 5)
            //{
            //    lbl.Visible = true;
            //    lbl.Text = "🟡 Contraseña media - Agrega más caracteres especiales";
            //    lbl.ForeColor = Color.Orange;
            //}
            //else
            //{
            //    lbl.Visible = true;
            //    lbl.Text = "🟢 Contraseña fuerte";
            //    lbl.ForeColor = Color.Green;
            //}
        }

        private int CalcularFuerzaPassword(string password)
        {
            int puntos = 0;
            if (password.Length >= 6) puntos++;
            if (password.Length >= 10) puntos++;
            if (Regex.IsMatch(password, "[A-Z]")) puntos++;
            if (Regex.IsMatch(password, "[a-z]")) puntos++;
            if (Regex.IsMatch(password, "[0-9]")) puntos++;
            if (Regex.IsMatch(password, "[^a-zA-Z0-9]")) puntos++;
            return puntos;
        }

        // ============================================================
        // MOSTRAR/OCULTAR CONTRASEÑA
        // ============================================================
        private void btnMostrarPass_Click(object sender, EventArgs e)
        {
            try
            {
                mostrarPassword = !mostrarPassword;
                ClaveSecreta.PasswordChar = mostrarPassword ? '\0' : '●';
                btnMostrarPass.Text = mostrarPassword ? "🙈" : "👁️";
                btnMostrarPass.BackColor = mostrarPassword ?
                    Color.FromArgb(200, 230, 255) : Color.Transparent;
            }
            catch (Exception ex)
            {
                RegistrarLog($"Error al mostrar/ocultar contraseña: {ex.Message}");
            }
        }

        // ============================================================
        // CHECKBOX RECORDARME
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
        // BOTÓN LOGIN (VERSIÓN ORIGINAL CORREGIDA)
        // ============================================================
        private void BtnContinuar_Click(object sender, EventArgs e)
        {
            // Evitar ejecución múltiple
            if (procesoEnCurso) return;

            try
            {
                // Verificar bloqueo por fuerza bruta (mejora de seguridad)
                if (bloqueoHasta.HasValue && DateTime.Now < bloqueoHasta.Value)
                {
                    TimeSpan restante = bloqueoHasta.Value - DateTime.Now;
                    MessageBox.Show($"🔒 Demasiados intentos fallidos.\nEspera {restante.Minutes} minutos.",
                        "Sistema bloqueado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // ============================================================
                // LLAMAR AL MÉTODO ORIGINAL verificacionDeSalida()
                // ============================================================
                if (verificacionDeSalida())
                {
                    // Resetear contador de intentos
                    Validaciones = 0;
                    bloqueoHasta = null;

                    // Guardar configuración "Recordarme"
                    if (chkGuardarClaves.Checked)
                    {
                        RecuerdaOpciones.guardarOpciones(datosEmpresa.strConxSyscod, ClaveSecreta.Text);
                    }

                    RegistrarLog($"✅ LOGIN EXITOSO - Usuario: {IdIngreso.Text}");
                    //MessageBox.Show($"✅ ¡Bienvenido {IdIngreso.Text} al sistema!",
                    //    "Acceso exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    RegistrarAcceso();
                    Close();
                }
                // Si falla, el método verificacionDeSalida() ya muestra los mensajes
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Error al validar credenciales:\n{ex.Message}",
                    "Error del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                RegistrarLog($"🔥 ERROR CRÍTICO: {ex.Message}");
            }
        }

        // ============================================================
        // VERIFICACIÓN DE SALIDA (MÉTODO ORIGINAL - SIN CAMBIOS)
        // ============================================================
        private Boolean verificacionDeSalida()
        {
            // Incrementar contador de intentos
            Validaciones++;

            // Bloquear después de 3 intentos (manteniendo tu lógica original)
            if (Validaciones > 3)
            {
                MessageBox.Show("Ha llegado al máximo número de intentos el sistema se cerrará");
                Environment.Exit(0);
            }

            // Validar contraseña
            if (ClaveSecreta.Text == "")
            {
                MessageBox.Show("Debe digitar su clave secreta");
                ClaveSecreta.Focus();
                return false;
            }

            // Validar usuario
            if (IdIngreso.Text == "")
            {
                MessageBox.Show("Debe digitar su identificación de acceso");
                IdIngreso.Focus();
                return false;
            }

            // Validar empresa
            if (DcEmp.Items.Count < 1 || DcEmp.SelectedValue == null)
            {
                MessageBox.Show("No existe una empresa definida o seleccionada para procesar");
                return false;
            }

            // Asignar empresa
            datosEmpresa.Emp_codigo = Convert.ToInt16(DcEmp.SelectedValue);
            ManejoDatosEmpresa.LeerDatosEmpresa(
                datosEmpresa.strConxSyscod,
                datosEmpresa.UsuarioBd,
                datosEmpresa.ClaveBd,
                datosEmpresa.Servidor);

            if (datosEmpresa.Emp_codigo == 0)
            {
                MessageBox.Show("Existe error al cargar la empresa seleccionada");
                return false;
            }

            // ============================================================
            // VERIFICAR CLAVE DEL USUARIO (USANDO TU CLASE DelUsuario)
            // ============================================================
            string resultado = DelUsuario.VerificarClave(ClaveSecreta.Text, IdIngreso.Text);

            if (resultado.Length > 0)
            {
                // Si hay empresas asignadas, la validación fue exitosa
                return true;
            }
            else
            {
                // La validación falló (DelUsuario ya muestra los mensajes de error)
                return false;
            }
        }

        // ============================================================
        // REGISTRAR ACCESO (TAL CUAL ESTABA)
        // ============================================================
        private void RegistrarAcceso()
        {
            if (IdIngreso.Text.ToUpper() == "ADMINISTRADOR")
            {
                DattCom.ManejoDatosEmpresa.grabarEmpresaRegistrada(DcEmp.SelectedValue.ToString(), IdIngreso.Text);

                datosEmpresa.usr = IdIngreso.Text;
                datosEmpresa.codEmpresa = Convert.ToInt16(DcEmp.SelectedValue);
                datosEmpresa.usr = IdIngreso.Text;

                IngSis.EmpresaInicio.IniciaEmpresa();
            }
            else
            {
                DattCom.ManejoDatosUsuario.LeerDatosUsuarioDirectorio();
                DattCom.ManejoDatosEmpresa.grabarEmpresaRegistrada(DcEmp.SelectedValue.ToString(), IdIngreso.Text);

                datosEmpresa.usr = IdIngreso.Text;
                datosEmpresa.codEmpresa = Convert.ToInt16(DcEmp.SelectedValue);
                datosEmpresa.usr = IdIngreso.Text;

                IngSis.EmpresaInicio.IniciaEmpresa();
            }
        }

        // ============================================================
        // LOGS DE SEGURIDAD
        // ============================================================

        // ============================================================
        // LOGS DE SEGURIDAD (RUTA EN SERVIDOR USANDO datosEmpresa.Servidor)
        // ============================================================
        private void RegistrarLog(string mensaje)
        {
            try
            {
                // ============================================================
                // CONSTRUIR RUTA CON datosEmpresa.Servidor
                // ============================================================
                string logPath = $@"\\{datosEmpresa.Servidor}\logs";

                // Si no existe el directorio, crearlo
                if (!Directory.Exists(logPath))
                {
                    Directory.CreateDirectory(logPath);
                }

                // Crear el archivo de log con fecha
                string logFile = Path.Combine(logPath, $"login_{DateTime.Now:yyyy-MM-dd}.log");
                string linea = $"{DateTime.Now:HH:mm:ss} | {mensaje}";

                // Escribir en el archivo
                File.AppendAllText(logFile, linea + Environment.NewLine);
            }
            catch (Exception ex)
            {
                // ============================================================
                // SI FALLA, GUARDAR LOCALMENTE COMO RESPALDO
                // ============================================================
                try
                {
                    string fallbackPath = Path.Combine(Application.StartupPath, "Logs");
                    if (!Directory.Exists(fallbackPath))
                        Directory.CreateDirectory(fallbackPath);

                    string fallbackFile = Path.Combine(fallbackPath, $"login_fallback_{DateTime.Now:yyyy-MM-dd}.log");
                    string linea = $"{DateTime.Now:HH:mm:ss} | ERROR RED: {ex.Message} | {mensaje}";
                    File.AppendAllText(fallbackFile, linea + Environment.NewLine);
                }
                catch { /* Silencioso para no afectar al usuario */ }
            }
        }
        // ============================================================
        // BOTÓN SALIR (CORREGIDO)
        // ============================================================
        private void btnSalir_Click(object sender, EventArgs e)
        {
            // Si hay un proceso en curso, no permitir salir
            if (procesoEnCurso)
            {
                MessageBox.Show("⏳ Espere a que termine el proceso actual antes de salir.",
                    "Proceso en curso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult resultado = MessageBox.Show(
                "¿Estás seguro de que deseas salir del sistema?\n\n" +
                "Todos los cambios no guardados se perderán.",
                "Confirmar salida",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2
            );

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    RegistrarLog("SALIDA - Usuario cerró sesión");
                    DattCom.ManejoDatosEmpresa.ResetearEmpresaRegistrada();

                    // Guardar configuración
                    RecuerdaOpciones.guardarOpciones(datosEmpresa.strConxSyscod,
                        chkGuardarClaves.Checked ? ClaveSecreta.Text : "");

                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                }
                catch (Exception ex)
                {
                    RegistrarLog($"ERROR al salir: {ex.Message}");
                    MessageBox.Show($"Error al cerrar la aplicación:\n{ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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
            }
            catch (Exception ex)
            {
                RegistrarLog($"ERROR en FormClosing: {ex.Message}");
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