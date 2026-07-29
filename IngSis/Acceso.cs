using System;
using System.Windows.Forms;
using DattCom;
using System.Data.SqlClient;

namespace IngSis
{
    public partial class Acceso : Form
    {
        Int32 Validaciones = 0;

        public Acceso(string Aplicativo = "SISTEMA-AC16")
        {
            InitializeComponent();
            iniciaAplicación();
            Text = "REGISTRAR INGRESO AL SISTEMA " + Aplicativo;
        }

        private void iniciaAplicación()
        {
            // ============================================================
            // VALIDAR LICENCIA (SOLO VALIDA, NO CARGA)
            // ============================================================
            double Licencias = LicDefAct.ChequeoLicencias.ChequearLicencias(
                datosEmpresa.Major,
                datosEmpresa.pathServer,
                datosEmpresa.pathAppl,
                datosEmpresa.sistema,
                datosEmpresa.auto,
                "23031957");

            if (Licencias == 0)
            {
                MessageBox.Show("Error 1112 - No existen licencias activadas para el sistema");
                Environment.Exit(0);
            }

            // ============================================================
            // NO CARGAR LICENCIA AQUÍ PORQUE EMP_RUC ESTÁ VACÍO
            // ============================================================

            RecuerdaOpciones.leerOpciones(datosEmpresa.strConIniSis);
            if (RecuerdaOpciones.usuario.Length > 0 && RecuerdaOpciones.clave.Length > 0)
            {
                IdIngreso.Text = RecuerdaOpciones.usuario;
                ClaveSecreta.Text = RecuerdaOpciones.clave;
            }

            chkGuardarClaves.Checked = (ClaveSecreta.Text != "");

            if (IdIngreso.Text == "")
            {
                IdIngreso.Text = System.Environment.UserName.ToString();
            }

            if (ClaveSecreta.Text != "" && IdIngreso.Text != "")
            {
                EmpresaInicio.cargarEmpresasUsuario(Convert.ToInt32(RecuerdaOpciones.empresa), IdIngreso.Text, DcEmp);
                if (Convert.ToInt32(RecuerdaOpciones.empresa) == 0)
                {
                    DcEmp.SelectedValue = EmpresaInicio.EmpresaDeInicio(IdIngreso.Text);
                }

                if (DatosUsuario.Estado == 0 && DcEmp.Items.Count > 0)
                {
                    if (DcEmp.SelectedValue == null)
                    {
                        DcEmp.SelectedIndex = 0;
                        BtnContinuar.Focus();
                    }
                    else
                    {
                        IdIngreso.Focus();
                    }
                }
            }
            BtnContinuar.Enabled = true;
        }

        // ============================================================
        // CARGAR LICENCIA ACTIVA DESDE LA BASE DE DATOS
        // ============================================================
        private void CargarLicenciaActiva()
        {
            try
            {
                if (string.IsNullOrEmpty(datosEmpresa.Emp_RUC))
                {
                    System.Diagnostics.Debug.WriteLine("Emp_RUC vacío, no se puede cargar licencia");
                    return;
                }

                string ruc = datosEmpresa.Emp_RUC;
                System.Diagnostics.Debug.WriteLine($"Buscando licencia para RUC: {ruc}");

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

                                System.Diagnostics.Debug.WriteLine($"Licencia cargada: Tipo={datosEmpresa.TipoLicencia}, Modulos={datosEmpresa.ModulosActivos}");
                            }
                            else
                            {
                                System.Diagnostics.Debug.WriteLine($"No se encontró licencia para RUC: {ruc}");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error cargando licencia: {ex.Message}");
            }
        }

        private void chkGuardarClaves_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void BtnContinuar_Click(object sender, EventArgs e)
        {
            if (verificacionDeSalida())
            {
                RegistrarAcceso();
                Close();
            }
        }

        private Boolean verificacionDeSalida()
        {
            Validaciones++;
            if (Validaciones > 3)
            {
                MessageBox.Show("Ha llegado al máximo número de intentos el sistema se cerrará");
                Environment.Exit(0);
            }
            if (ClaveSecreta.Text == "")
            {
                MessageBox.Show("Debe digitar su clave secreta");
                ClaveSecreta.Focus();
                return false;
            }
            if (IdIngreso.Text == "")
            {
                MessageBox.Show("Debe digitar su identificación de acceso");
                IdIngreso.Focus();
                return false;
            }
            if (DcEmp.Items.Count < 1 || DcEmp.SelectedValue == null)
            {
                MessageBox.Show("No existe una empresa definida o seleccionada para procesar");
                return false;
            }

            datosEmpresa.Emp_codigo = Convert.ToInt16(DcEmp.SelectedValue);
            ManejoDatosEmpresa.LeerDatosEmpresa(datosEmpresa.strConxSyscod, datosEmpresa.UsuarioBd, datosEmpresa.ClaveBd, datosEmpresa.Servidor);

            if (datosEmpresa.Emp_codigo == 0)
            {
                MessageBox.Show("Existe error al cargar la empresa seleccionada");
                return false;
            }

            // ============================================================
            // CARGAR LICENCIA DESPUÉS DE SELECCIONAR LA EMPRESA
            // ============================================================
            CargarLicenciaActiva();

            if (DelUsuario.VerificarClave(ClaveSecreta.Text, IdIngreso.Text).Length > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void DcEmp_Click(object sender, EventArgs e)
        {
            datosEmpresa.Emp_codigo = Convert.ToInt16(DcEmp.SelectedValue);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DattCom.ManejoDatosEmpresa.ResetearEmpresaRegistrada();
            Environment.Exit(0);
        }

        private void IdIngreso_TextChanged(object sender, EventArgs e)
        {
            DcEmp.DataSource = null;
            BtnContinuar.Enabled = false;
        }

        private void IdIngreso_Leave(object sender, EventArgs e)
        {
            if (DcEmp.Items.Count == 0 && IdIngreso.Text.Length > 0)
            {
                if (IdIngreso.Text == RecuerdaOpciones.usuario)
                {
                    EmpresaInicio.cargarEmpresasUsuario(Convert.ToInt16(RecuerdaOpciones.empresa), IdIngreso.Text, DcEmp);
                }
                else
                {
                    EmpresaInicio.cargarEmpresasUsuario(0, IdIngreso.Text, DcEmp);
                }
                BtnContinuar.Enabled = true;
            }
        }

        private void Acceso_FormClosing(object sender, FormClosingEventArgs e)
        {
            string conclave = ClaveSecreta.Text;

            if (!chkGuardarClaves.Checked)
            {
                conclave = "";
            }

            RecuerdaOpciones.guardarOpciones(datosEmpresa.strConxSyscod, conclave);

            if (e.CloseReason != CloseReason.ApplicationExitCall)
            {
                DattCom.ManejoDatosEmpresa.ResetearEmpresaRegistrada();
            }
        }

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

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}