using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace ClassDaxMail
{
    public partial class frmRegistraDatosEmail : Form
    {
        private string _cadenaConexion;
        private string _codEmpresa;
        private bool _esEdicion = false;
        private int _configuracionId = 0;

        public frmRegistraDatosEmail(string cadenaConexion, string codEmpresa)
        {
            InitializeComponent();
            _cadenaConexion = cadenaConexion;
            _codEmpresa = codEmpresa;

            ConfigurarEventos();
            CargarConfiguracion();
        }

        private void ConfigurarEventos()
        {
            // Evento para cuando cambia el tipo de cuenta
            chkMailSmtp.CheckedChanged += (s, e) =>
            {
                if (chkMailSmtp.Checked)
                {
                    chkMailOutlook.Checked = false;
                    groupCuenta.Enabled = true;
                    txtSmtp.Enabled = true;
                    txtPuerto.Enabled = true;
                    ChkSSL.Enabled = true;
                    txtSmtp.BackColor = Color.White;
                    txtPuerto.BackColor = Color.White;
                    lblTipoCuenta.Text = "Configuración SMTP Personalizada";
                    lblTipoCuenta.ForeColor = Color.SteelBlue;
                    groupCuenta.Text = "Cuenta SMTP Personalizada";
                    groupCuenta.ForeColor = Color.FromArgb(52, 73, 94);
                }
            };

            chkMailOutlook.CheckedChanged += (s, e) =>
            {
                if (chkMailOutlook.Checked)
                {
                    chkMailSmtp.Checked = false;
                    groupCuenta.Enabled = true;
                    txtSmtp.Enabled = false;
                    txtPuerto.Enabled = false;
                    ChkSSL.Enabled = false;
                    CargarConfiguracionOutlook();
                    lblTipoCuenta.Text = "Configuración Outlook 365";
                    lblTipoCuenta.ForeColor = Color.DarkOrange;
                    groupCuenta.Text = "Cuenta Outlook 365";
                    groupCuenta.ForeColor = Color.FromArgb(231, 76, 60);
                }
            };

            // Evento para validar mientras se escribe
            txtCorreo.TextChanged += (s, e) => ValidarCampo(txtCorreo, lblCorreo);
            txtUsuario.TextChanged += (s, e) => ValidarCampo(txtUsuario, lblUsuario);
            txtClave.TextChanged += (s, e) => ValidarCampo(txtClave, lblClave);
            txtSmtp.TextChanged += (s, e) => ValidarCampo(txtSmtp, lblSmtp);
            txtPuerto.TextChanged += (s, e) => ValidarPuerto();

            // Evento Enter para seleccionar todo el texto al hacer foco
            foreach (Control control in groupCuenta.Controls)
            {
                if (control is TextBox txt)
                {
                    txt.Enter += (s, e) => txt.SelectAll();
                }
            }

            // Seleccionar SMTP por defecto
            chkMailSmtp.Checked = true;
            groupCuenta.Enabled = true;
        }

        private void ValidarCampo(TextBox txt, Label lbl)
        {
            try
            {
                if (txt != null && !txt.IsDisposed)
                {
                    if (string.IsNullOrWhiteSpace(txt.Text))
                    {
                        lbl.ForeColor = Color.Red;
                    }
                    else
                    {
                        lbl.ForeColor = Color.SteelBlue;
                    }
                }
            }
            catch
            {
                // Ignorar errores
            }
        }

        private void ValidarPuerto()
        {
            try
            {
                if (txtPuerto == null || txtPuerto.IsDisposed) return;

                if (string.IsNullOrWhiteSpace(txtPuerto.Text))
                {
                    lblPuerto.ForeColor = Color.Red;
                    txtPuerto.BackColor = Color.LightPink;
                    return;
                }

                if (int.TryParse(txtPuerto.Text, out int puerto) && puerto > 0 && puerto <= 65535)
                {
                    lblPuerto.ForeColor = Color.SteelBlue;
                    txtPuerto.BackColor = Color.White;
                }
                else
                {
                    lblPuerto.ForeColor = Color.Red;
                    txtPuerto.BackColor = Color.LightPink;
                }
            }
            catch
            {
                // Ignorar errores
            }
        }

        private void CargarConfiguracionOutlook()
        {
            try
            {
                txtSmtp.Text = "smtp.office365.com";
                txtPuerto.Text = "587";
                ChkSSL.Checked = true;
                txtSmtp.BackColor = Color.LightGray;
                txtPuerto.BackColor = Color.LightGray;
            }
            catch { }
        }

        private void CargarConfiguracion()
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(_cadenaConexion))
                {
                    conexion.Open();

                    if (!TablaCorreoConfigExiste(conexion))
                    {
                        CrearTablaCorreoConfig(conexion);
                        return;
                    }

                    string query = @"
                        SELECT TOP 1 Id, CorreoDesde, Smtp, Usuario, Clave, Puerto, HabilitarSSL, Tipo 
                        FROM CorreoConfig 
                        WHERE EmpresaCodigo = @CodEmpresa 
                        ORDER BY Id DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@CodEmpresa", _codEmpresa);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                _configuracionId = reader.GetInt32(0);
                                txtCorreo.Text = reader.GetString(1);
                                txtSmtp.Text = reader.GetString(2);
                                txtUsuario.Text = reader.GetString(3);
                                txtClave.Text = reader.GetString(4);
                                txtPuerto.Text = reader.GetInt32(5).ToString();
                                ChkSSL.Checked = reader.GetBoolean(6);

                                string tipo = reader.GetString(7);
                                if (tipo.ToUpper() == "OUTLOOK")
                                {
                                    chkMailOutlook.Checked = true;
                                    txtSmtp.Enabled = false;
                                    txtPuerto.Enabled = false;
                                    ChkSSL.Enabled = false;
                                    txtSmtp.BackColor = Color.LightGray;
                                    txtPuerto.BackColor = Color.LightGray;
                                    lblTipoCuenta.Text = "Configuración Outlook 365";
                                    lblTipoCuenta.ForeColor = Color.DarkOrange;
                                    groupCuenta.Text = "Cuenta Outlook 365";
                                    groupCuenta.ForeColor = Color.FromArgb(231, 76, 60);
                                }
                                else
                                {
                                    chkMailSmtp.Checked = true;
                                    lblTipoCuenta.Text = "Configuración SMTP Personalizada";
                                    lblTipoCuenta.ForeColor = Color.SteelBlue;
                                    groupCuenta.Text = "Cuenta SMTP Personalizada";
                                    groupCuenta.ForeColor = Color.FromArgb(52, 73, 94);
                                }

                                _esEdicion = true;
                                btnAceptar.Text = "Actualizar";
                                btnAceptar.BackColor = Color.DarkOrange;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar configuración: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool TablaCorreoConfigExiste(SqlConnection conexion)
        {
            string query = @"
                SELECT COUNT(*) 
                FROM INFORMATION_SCHEMA.TABLES 
                WHERE TABLE_NAME = 'CorreoConfig'";

            using (SqlCommand cmd = new SqlCommand(query, conexion))
            {
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        private void CrearTablaCorreoConfig(SqlConnection conexion)
        {
            string createTableQuery = @"
                CREATE TABLE CorreoConfig (
                    Id INT IDENTITY(1,1) PRIMARY KEY,
                    EmpresaCodigo VARCHAR(10) NOT NULL,
                    CorreoDesde VARCHAR(100) NOT NULL,
                    Smtp VARCHAR(100) NOT NULL,
                    Usuario VARCHAR(100) NOT NULL,
                    Clave VARCHAR(200) NOT NULL,
                    Puerto INT NOT NULL,
                    HabilitarSSL BIT NOT NULL DEFAULT 0,
                    Tipo VARCHAR(20) DEFAULT 'SMTP',
                    FechaRegistro DATETIME DEFAULT GETDATE(),
                    CONSTRAINT UQ_CorreoConfig_Empresa UNIQUE (EmpresaCodigo)
                )";

            using (SqlCommand cmd = new SqlCommand(createTableQuery, conexion))
            {
                cmd.ExecuteNonQuery();
            }
        }

        private bool ValidarCampos()
        {
            try
            {
                // Validar correo
                if (string.IsNullOrWhiteSpace(txtCorreo.Text))
                {
                    MessageBox.Show("El correo electrónico es obligatorio", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCorreo.Focus();
                    txtCorreo.BackColor = Color.LightPink;
                    return false;
                }

                // Validar formato de correo
                if (!IsValidEmail(txtCorreo.Text))
                {
                    MessageBox.Show("El formato del correo electrónico no es válido", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCorreo.Focus();
                    txtCorreo.BackColor = Color.LightPink;
                    return false;
                }

                // Validar usuario
                if (string.IsNullOrWhiteSpace(txtUsuario.Text))
                {
                    MessageBox.Show("El usuario es obligatorio", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUsuario.Focus();
                    txtUsuario.BackColor = Color.LightPink;
                    return false;
                }

                // Validar clave
                if (string.IsNullOrWhiteSpace(txtClave.Text))
                {
                    MessageBox.Show("La clave es obligatoria", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtClave.Focus();
                    txtClave.BackColor = Color.LightPink;
                    return false;
                }

                if (txtClave.Text.Length < 6)
                {
                    MessageBox.Show("La clave debe tener al menos 6 caracteres", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtClave.Focus();
                    txtClave.BackColor = Color.LightPink;
                    return false;
                }

                // Validar SMTP solo si está configurado
                if (chkMailSmtp.Checked)
                {
                    if (string.IsNullOrWhiteSpace(txtSmtp.Text))
                    {
                        MessageBox.Show("El servidor SMTP es obligatorio", "Validación",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtSmtp.Focus();
                        txtSmtp.BackColor = Color.LightPink;
                        return false;
                    }

                    if (string.IsNullOrWhiteSpace(txtPuerto.Text))
                    {
                        MessageBox.Show("El puerto es obligatorio", "Validación",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtPuerto.Focus();
                        txtPuerto.BackColor = Color.LightPink;
                        return false;
                    }

                    if (!int.TryParse(txtPuerto.Text, out int puerto) || puerto <= 0 || puerto > 65535)
                    {
                        MessageBox.Show("El puerto debe ser un número válido entre 1 y 65535", "Validación",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtPuerto.Focus();
                        txtPuerto.BackColor = Color.LightPink;
                        return false;
                    }
                }

                // Restaurar colores
                RestaurarColores();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en validación: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void RestaurarColores()
        {
            try
            {
                // Verificar que los controles existan
                if (txtCorreo != null && !txtCorreo.IsDisposed)
                    txtCorreo.BackColor = txtCorreo.Enabled ? Color.White : SystemColors.Control;

                if (txtUsuario != null && !txtUsuario.IsDisposed)
                    txtUsuario.BackColor = txtUsuario.Enabled ? Color.White : SystemColors.Control;

                if (txtClave != null && !txtClave.IsDisposed)
                    txtClave.BackColor = txtClave.Enabled ? Color.White : SystemColors.Control;

                if (txtSmtp != null && !txtSmtp.IsDisposed)
                    txtSmtp.BackColor = txtSmtp.Enabled ? Color.White : SystemColors.Control;

                if (txtPuerto != null && !txtPuerto.IsDisposed)
                    txtPuerto.BackColor = txtPuerto.Enabled ? Color.White : SystemColors.Control;
            }
            catch
            {
                // Si algo falla, ignorar
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void GuardarConfiguracion()
        {
            using (SqlConnection conexion = new SqlConnection(_cadenaConexion))
            {
                conexion.Open();

                if (!TablaCorreoConfigExiste(conexion))
                {
                    CrearTablaCorreoConfig(conexion);
                }

                string tipo = chkMailOutlook.Checked ? "OUTLOOK" : "SMTP";
                string smtp = chkMailOutlook.Checked ? "smtp.office365.com" : txtSmtp.Text.Trim();
                int puerto = chkMailOutlook.Checked ? 587 : int.Parse(txtPuerto.Text.Trim());
                bool ssl = chkMailOutlook.Checked ? true : ChkSSL.Checked;

                string query;
                if (_esEdicion && _configuracionId > 0)
                {
                    query = @"
                        UPDATE CorreoConfig 
                        SET CorreoDesde = @Correo,
                            Smtp = @Smtp,
                            Usuario = @Usuario,
                            Clave = @Clave,
                            Puerto = @Puerto,
                            HabilitarSSL = @SSL,
                            Tipo = @Tipo
                        WHERE Id = @Id AND EmpresaCodigo = @CodEmpresa";
                }
                else
                {
                    // Eliminar configuración anterior si existe
                    string deleteQuery = "DELETE FROM CorreoConfig WHERE EmpresaCodigo = @CodEmpresa";
                    using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, conexion))
                    {
                        deleteCmd.Parameters.AddWithValue("@CodEmpresa", _codEmpresa);
                        deleteCmd.ExecuteNonQuery();
                    }

                    query = @"
                        INSERT INTO CorreoConfig (EmpresaCodigo, CorreoDesde, Smtp, Usuario, Clave, Puerto, HabilitarSSL, Tipo)
                        VALUES (@CodEmpresa, @Correo, @Smtp, @Usuario, @Clave, @Puerto, @SSL, @Tipo)";
                }

                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@CodEmpresa", _codEmpresa);
                    cmd.Parameters.AddWithValue("@Correo", txtCorreo.Text.Trim());
                    cmd.Parameters.AddWithValue("@Smtp", smtp);
                    cmd.Parameters.AddWithValue("@Usuario", txtUsuario.Text.Trim());
                    cmd.Parameters.AddWithValue("@Clave", txtClave.Text.Trim());
                    cmd.Parameters.AddWithValue("@Puerto", puerto);
                    cmd.Parameters.AddWithValue("@SSL", ssl);
                    cmd.Parameters.AddWithValue("@Tipo", tipo);

                    if (_esEdicion && _configuracionId > 0)
                    {
                        cmd.Parameters.AddWithValue("@Id", _configuracionId);
                    }

                    int resultado = cmd.ExecuteNonQuery();

                    if (resultado > 0)
                    {
                        string mensaje = _esEdicion ? "Configuración actualizada exitosamente." : "Configuración guardada exitosamente.";
                        MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = DialogResult.OK;
                    }
                }
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            try
            {
                GuardarConfiguracion();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar configuración: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (HayCambios())
            {
                DialogResult result = MessageBox.Show("¿Desea salir sin guardar los cambios?",
                    "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    DialogResult = DialogResult.Cancel;
                    Close();
                }
            }
            else
            {
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }

        private bool HayCambios()
        {
            return !string.IsNullOrWhiteSpace(txtCorreo.Text) ||
                   !string.IsNullOrWhiteSpace(txtUsuario.Text) ||
                   !string.IsNullOrWhiteSpace(txtClave.Text);
        }

        private void btnProbar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            try
            {
                btnProbar.Enabled = false;
                btnProbar.Text = "Enviando prueba...";
                Application.DoEvents();

                GuardarConfiguracion();

                string correoDesde = txtCorreo.Text.Trim();
                string usuario = txtUsuario.Text.Trim();
                string clave = txtClave.Text.Trim();
                string smtp = txtSmtp.Text.Trim();
                int puerto = int.Parse(txtPuerto.Text.Trim());
                bool ssl = ChkSSL.Checked;
                string correoDestino = "asistenciadax2022@gmail.com";

                string asunto = "PRUEBA DE CONFIGURACIÓN SMTP - " + DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                string mensaje = $@"
            <html>
            <body style='font-family: Arial, sans-serif;'>
                <div style='background-color: #2c3e50; color: white; padding: 15px;'>
                    <h2>✅ PRUEBA DE CONFIGURACIÓN SMTP</h2>
                </div>
                <div style='padding: 20px;'>
                    <p>Estimado usuario,</p>
                    <p>Esta es una prueba de envío de correo electrónico.</p>
                    <p>Si está recibiendo este mensaje, significa que la <b style='color: green;'>configuración es correcta</b>.</p>
                    
                    <h3>Detalles de la configuración:</h3>
                    <table style='border-collapse: collapse; width: 100%;'>
                        <tr>
                            <td style='padding: 8px; border: 1px solid #ddd; font-weight: bold; background-color: #f2f2f2;'>Correo desde</td>
                            <td style='padding: 8px; border: 1px solid #ddd;'>{correoDesde}</td>
                        </tr>
                        <tr>
                            <td style='padding: 8px; border: 1px solid #ddd; font-weight: bold; background-color: #f2f2f2;'>Correo destino</td>
                            <td style='padding: 8px; border: 1px solid #ddd;'>{correoDestino}</td>
                        </tr>
                        <tr>
                            <td style='padding: 8px; border: 1px solid #ddd; font-weight: bold; background-color: #f2f2f2;'>Servidor SMTP</td>
                            <td style='padding: 8px; border: 1px solid #ddd;'>{smtp}</td>
                        </tr>
                        <tr>
                            <td style='padding: 8px; border: 1px solid #ddd; font-weight: bold; background-color: #f2f2f2;'>Puerto</td>
                            <td style='padding: 8px; border: 1px solid #ddd;'>{puerto}</td>
                        </tr>
                        <tr>
                            <td style='padding: 8px; border: 1px solid #ddd; font-weight: bold; background-color: #f2f2f2;'>SSL</td>
                            <td style='padding: 8px; border: 1px solid #ddd;'>{(ssl ? "Activado" : "Desactivado")}</td>
                        </tr>
                        <tr>
                            <td style='padding: 8px; border: 1px solid #ddd; font-weight: bold; background-color: #f2f2f2;'>Usuario</td>
                            <td style='padding: 8px; border: 1px solid #ddd;'>{usuario}</td>
                        </tr>
                        <tr>
                            <td style='padding: 8px; border: 1px solid #ddd; font-weight: bold; background-color: #f2f2f2;'>Fecha prueba</td>
                            <td style='padding: 8px; border: 1px solid #ddd;'>{DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}</td>
                        </tr>
                    </table>
                    
                    <p style='margin-top: 20px; color: #666; font-size: 12px;'>
                        Este mensaje fue enviado automáticamente por el sistema de configuración de correo.
                    </p>
                </div>
            </body>
            </html>
        ";

                string resultado = "";
                bool exito = false;

                try
                {
                    using (System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient(smtp, puerto))
                    {
                        cliente.EnableSsl = ssl;
                        cliente.UseDefaultCredentials = false;
                        cliente.Credentials = new System.Net.NetworkCredential(usuario, clave);
                        cliente.Timeout = 30000;

                        using (System.Net.Mail.MailMessage mensajeCorreo = new System.Net.Mail.MailMessage())
                        {
                            mensajeCorreo.From = new System.Net.Mail.MailAddress(correoDesde);
                            mensajeCorreo.To.Add(correoDestino);
                            mensajeCorreo.Subject = asunto;
                            mensajeCorreo.Body = mensaje;
                            mensajeCorreo.IsBodyHtml = true;

                            cliente.Send(mensajeCorreo);
                            exito = true;
                            resultado = "Correo de prueba enviado exitosamente.";
                        }
                    }
                }
                catch (System.Net.Mail.SmtpException ex)
                {
                    exito = false;
                    switch (ex.StatusCode)
                    {
                        case System.Net.Mail.SmtpStatusCode.GeneralFailure:
                            resultado = "❌ Error general. Verifique conexión y configuración.";
                            break;
                        case System.Net.Mail.SmtpStatusCode.ServiceNotAvailable:
                            resultado = "❌ Servicio no disponible. El servidor SMTP no responde.";
                            break;
                        case System.Net.Mail.SmtpStatusCode.MailboxNameNotAllowed:
                            resultado = "❌ Nombre de buzón no permitido. Verifique el correo.";
                            break;
                        case System.Net.Mail.SmtpStatusCode.TransactionFailed:
                            resultado = "❌ Falló la transacción. Verifique los datos.";
                            break;
                        default:
                            resultado = $"❌ Error SMTP: {ex.Message}";
                            break;
                    }
                }
                catch (System.Net.Sockets.SocketException ex)
                {
                    exito = false;
                    resultado = $"❌ No se puede conectar al servidor.\n{ex.Message}\n\nVerifique:\n• Servidor SMTP\n• Puerto\n• Conexión a internet";
                }
                catch (System.Security.Authentication.AuthenticationException)
                {
                    exito = false;
                    resultado = "❌ Error de autenticación SSL/TLS.\nVerifique:\n• Usuario y clave\n• Configuración SSL";
                }
                catch (Exception ex)
                {
                    exito = false;
                    resultado = $"❌ Error: {ex.Message}";
                }

                btnProbar.Enabled = true;
                btnProbar.Text = "Probar";

                if (exito)
                {
                    MessageBox.Show(
                        $"✅ {resultado}\n\n" +
                        $"Se ha enviado un correo de prueba a: {correoDestino}\n\n" +
                        "📧 Verifique la bandeja de entrada de asistenciadax2022@gmail.com",
                        "PRUEBA EXITOSA",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
                else
                {
                    MessageBox.Show(
                        $"{resultado}\n\n" +
                        "🔧 Sugerencias:\n" +
                        "• Verifique usuario y clave\n" +
                        "• Confirme servidor SMTP correcto\n" +
                        "• Revise puerto (25, 465, 587, etc.)\n" +
                        "• Verifique SSL activado/desactivado según corresponda\n" +
                        "• Asegure conexión a internet\n" +
                        "• Para Gmail: use 'Contraseña de aplicación'\n" +
                        "• Para Office 365: use puerto 587 con SSL",
                        "PRUEBA FALLIDA",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
            catch (Exception ex)
            {
                btnProbar.Enabled = true;
                btnProbar.Text = "Probar";

                MessageBox.Show(
                    $"❌ Error inesperado: {ex.Message}\n\n" +
                    "Verifique que todos los campos estén correctamente llenos.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnMostrarClave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtClave.PasswordChar == '*')
                {
                    txtClave.PasswordChar = '\0';
                    btnMostrarClave.Text = "Ocultar";
                    btnMostrarClave.BackColor = Color.LightYellow;
                }
                else
                {
                    txtClave.PasswordChar = '*';
                    btnMostrarClave.Text = "Mostrar";
                    // Usar SystemColors para colores estándar del sistema
                    btnMostrarClave.BackColor = SystemColors.Control;
                }
            }
            catch { }
        }
        private void frmRegistraDatosEmail_Load(object sender, EventArgs e)
        {

        }
    }
}