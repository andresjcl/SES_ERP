using DattCom;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace importarData
{
    public partial class ImportarDirectorio : Form
    {
        private DataTable excelData;
        private List<RegistroValidado> registrosValidadas;
        private int totalValidos = 0;
        private int totalInvalidos = 0;

        public ImportarDirectorio()
        {
            InitializeComponent();
            ConfigurarGrids();
            CargarDatosBD();
        }

        private void ConfigurarGrids()
        {
            if (mallaValidacion != null)
            {
                mallaValidacion.AutoGenerateColumns = false;
                mallaValidacion.AllowUserToAddRows = false;
                mallaValidacion.ReadOnly = true;
                mallaValidacion.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                mallaValidacion.Columns.Clear();

                mallaValidacion.Columns.Add("RUC", "RUC/Cédula/Pasaporte");
                mallaValidacion.Columns.Add("RazonSocial", "Razón Social");
                mallaValidacion.Columns.Add("Telefonos", "Teléfonos");
                mallaValidacion.Columns.Add("Direccion", "Dirección");
                mallaValidacion.Columns.Add("Email", "Email");
                mallaValidacion.Columns.Add("EsCliente", "Es Cliente");
                mallaValidacion.Columns.Add("EsProveedor", "Es Proveedor");
                mallaValidacion.Columns.Add("TipoIdentificacion", "Tipo ID");
                mallaValidacion.Columns.Add("TipoPersona", "Tipo Persona");
                mallaValidacion.Columns.Add("Estado", "Estado");
                mallaValidacion.Columns.Add("Error", "Error");
                mallaValidacion.Columns.Add("Codigo", "Código (PK)");

                if (mallaValidacion.Columns["RUC"] != null)
                    mallaValidacion.Columns["RUC"].Width = 130;
                if (mallaValidacion.Columns["RazonSocial"] != null)
                    mallaValidacion.Columns["RazonSocial"].Width = 250;
                if (mallaValidacion.Columns["Telefonos"] != null)
                    mallaValidacion.Columns["Telefonos"].Width = 120;
                if (mallaValidacion.Columns["Direccion"] != null)
                    mallaValidacion.Columns["Direccion"].Width = 200;
                if (mallaValidacion.Columns["Email"] != null)
                    mallaValidacion.Columns["Email"].Width = 180;
                if (mallaValidacion.Columns["EsCliente"] != null)
                    mallaValidacion.Columns["EsCliente"].Width = 80;
                if (mallaValidacion.Columns["EsProveedor"] != null)
                    mallaValidacion.Columns["EsProveedor"].Width = 90;
                if (mallaValidacion.Columns["TipoIdentificacion"] != null)
                    mallaValidacion.Columns["TipoIdentificacion"].Width = 80;
                if (mallaValidacion.Columns["TipoPersona"] != null)
                    mallaValidacion.Columns["TipoPersona"].Width = 80;
                if (mallaValidacion.Columns["Estado"] != null)
                    mallaValidacion.Columns["Estado"].Width = 80;
                if (mallaValidacion.Columns["Error"] != null)
                    mallaValidacion.Columns["Error"].Width = 300;
                if (mallaValidacion.Columns["Codigo"] != null)
                    mallaValidacion.Columns["Codigo"].Width = 120;
            }
        }

        private void btnIdentificacionCargar_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Archivos Excel|*.xls;*.xlsx|Archivos CSV|*.csv";
                openFileDialog.Title = "Seleccionar archivo de Directorio";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string extension = Path.GetExtension(openFileDialog.FileName).ToLower();

                    if (extension == ".csv")
                        CargarCSV(openFileDialog.FileName);
                    else
                        CargarExcel(openFileDialog.FileName);
                }
            }
        }

        private void CargarCSV(string path)
        {
            try
            {
                MostrarProgreso(true, "Cargando archivo CSV...");

                DataTable dt = new DataTable();
                dt.Columns.Add("RUC");
                dt.Columns.Add("RazonSocial");
                dt.Columns.Add("Telefonos");
                dt.Columns.Add("Direccion");
                dt.Columns.Add("Email");
                dt.Columns.Add("EsCliente");
                dt.Columns.Add("EsProveedor");

                using (StreamReader reader = new StreamReader(path, Encoding.UTF8))
                {
                    string line;
                    bool isFirstLine = true;

                    while ((line = reader.ReadLine()) != null)
                    {
                        if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#"))
                            continue;

                        char separador = line.Contains(";") ? ';' : ',';
                        string[] values = line.Split(separador);

                        if (isFirstLine)
                        {
                            isFirstLine = false;
                            continue;
                        }

                        if (values.Length >= 7)
                        {
                            DataRow row = dt.NewRow();
                            row[0] = values[0].Trim();
                            row[1] = values[1].Trim();
                            row[2] = values[2].Trim();
                            row[3] = values[3].Trim();
                            row[4] = values[4].Trim();
                            row[5] = values[5].Trim();
                            row[6] = values[6].Trim();
                            dt.Rows.Add(row);
                        }
                    }
                }

                DataTable filteredDt = dt.Clone();
                foreach (DataRow row in dt.Rows)
                {
                    bool hasData = row.ItemArray.Any(field => field != DBNull.Value && field.ToString().Trim() != string.Empty);
                    if (hasData)
                        filteredDt.ImportRow(row);
                }

                excelData = filteredDt;
                mallaIdentificacion.DataSource = excelData;
                txtArchivo.Text = path;
                lblTotalRegistros.Text = $"Total registros: {excelData.Rows.Count}";
                btnValidarDirectorio.Enabled = true;

                if (tabControl1 != null)
                    tabControl1.SelectedIndex = 0;

                MostrarProgreso(false, $"Archivo cargado: {excelData.Rows.Count} registros");
                toolStripStatusLabel.Text = $"Archivo cargado: {excelData.Rows.Count} registros";

                MessageBox.Show($"Archivo CSV cargado correctamente.\n{excelData.Rows.Count} registros encontrados.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MostrarProgreso(false, "Error al cargar");
                MessageBox.Show($"Error al cargar CSV: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarExcel(string path)
        {
            try
            {
                MostrarProgreso(true, "Cargando archivo Excel...");

                string connString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={path};Extended Properties='Excel 12.0;HDR=YES;IMEX=1'";

                using (OleDbConnection conn = new OleDbConnection(connString))
                {
                    conn.Open();
                    DataTable schemaTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    string sheetName = schemaTable.Rows[0]["TABLE_NAME"].ToString();
                    sheetName = sheetName.Replace("'", "").Replace("$", "").Trim();

                    string query = $"SELECT * FROM [{sheetName}$]";
                    OleDbDataAdapter da = new OleDbDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count == 0)
                        throw new Exception("El archivo Excel no contiene datos");

                    DataTable filteredDt = dt.Clone();
                    foreach (DataRow row in dt.Rows)
                    {
                        bool hasData = row.ItemArray.Any(field => field != DBNull.Value && field.ToString().Trim() != string.Empty);
                        if (hasData)
                            filteredDt.ImportRow(row);
                    }

                    excelData = filteredDt;
                }

                mallaIdentificacion.DataSource = excelData;
                txtArchivo.Text = path;
                lblTotalRegistros.Text = $"Total registros: {excelData.Rows.Count}";
                btnValidarDirectorio.Enabled = true;

                if (tabControl1 != null)
                    tabControl1.SelectedIndex = 0;

                MostrarProgreso(false, $"Archivo cargado: {excelData.Rows.Count} registros");
                toolStripStatusLabel.Text = $"Archivo cargado: {excelData.Rows.Count} registros";

                MessageBox.Show($"Archivo Excel cargado correctamente.\n{excelData.Rows.Count} registros encontrados.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MostrarProgreso(false, "Error al cargar");
                MessageBox.Show($"Error al cargar Excel: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnValidarDirectorio_Click(object sender, EventArgs e)
        {
            if (excelData == null)
            {
                MessageBox.Show("Primero debe cargar un archivo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                MostrarProgreso(true, "Validando datos del directorio...");
                registrosValidadas = ValidarRegistros(excelData);
                MostrarResultadosValidacion();

                totalValidos = registrosValidadas.Count(r => r.EsValido);
                totalInvalidos = registrosValidadas.Count(r => !r.EsValido);

                lblResumen.Text = string.Format("✅ Válidos: {0} | ❌ Inválidos: {1}", totalValidos, totalInvalidos);
                btnCargarDirectorio.Enabled = totalValidos > 0;
                btnExportarErrores.Enabled = totalInvalidos > 0;

                if (tabControl1 != null)
                    tabControl1.SelectedIndex = 1;

                MostrarProgreso(false, string.Format("Validación completada - Válidos: {0}, Inválidos: {1}", totalValidos, totalInvalidos));
                if (toolStripStatusLabel != null)
                    toolStripStatusLabel.Text = string.Format("Validación completada - Válidos: {0}, Inválidos: {1}", totalValidos, totalInvalidos);

                MessageBox.Show(string.Format("Validación completada.\n\n✅ Registros válidos: {0}\n❌ Registros inválidos: {1}", totalValidos, totalInvalidos),
                    "Resultado de Validación", MessageBoxButtons.OK, totalInvalidos > 0 ? MessageBoxIcon.Warning : MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MostrarProgreso(false, "Error en validación");
                if (toolStripStatusLabel != null)
                    toolStripStatusLabel.Text = "Error en validación";
                MessageBox.Show($"Error durante la validación: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string DeterminarTipoIdentificacion(string identificacion)
        {
            if (string.IsNullOrEmpty(identificacion))
                return "N";

            identificacion = identificacion.Trim();
            bool soloNumeros = identificacion.All(c => char.IsDigit(c));

            if (soloNumeros)
            {
                switch (identificacion.Length)
                {
                    case 10: return "C";
                    case 13: return "R";
                    default:
                        if (identificacion.Length >= 6 && identificacion.Length <= 20)
                            return "P";
                        else
                            return "N";
                }
            }
            else
            {
                if (identificacion.Length >= 6 && identificacion.Length <= 20)
                    return "P";
                else
                    return "N";
            }
        }

        private string GenerarCodigoUnico(string identificacion, string tipoIdentificacion)
        {
            if (string.IsNullOrEmpty(identificacion))
                return "";

            identificacion = identificacion.Trim();

            switch (tipoIdentificacion)
            {
                case "C":
                    return "C" + identificacion;
                case "R":
                    string rucBase = identificacion.Length >= 10 ? identificacion.Substring(0, 10) : identificacion;
                    return "R" + rucBase;
                case "P":
                    string pasaporte = identificacion.Length > 14 ? identificacion.Substring(0, 14) : identificacion;
                    return "P" + pasaporte;
                default:
                    return identificacion;
            }
        }

        private bool ValidarEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return true;

            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }

        private List<RegistroValidado> ValidarRegistros(DataTable dt)
        {
            List<RegistroValidado> resultados = new List<RegistroValidado>();
            HashSet<string> documentosExistentes = new HashSet<string>();
            HashSet<string> codigosExistentes = new HashSet<string>();

            try
            {
                using (SqlConnection conn = new SqlConnection(datosEmpresa.strConxAdcom))
                {
                    conn.Open();
                    string query = "SELECT CedulaIdentidadRuc, Codigo FROM Identificacion";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string doc = reader["CedulaIdentidadRuc"]?.ToString().Trim();
                        string cod = reader["Codigo"]?.ToString().Trim();
                        if (!string.IsNullOrEmpty(doc))
                            documentosExistentes.Add(doc);
                        if (!string.IsNullOrEmpty(cod))
                            codigosExistentes.Add(cod);
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error al cargar datos existentes: {ex.Message}");
            }

            foreach (DataRow row in dt.Rows)
            {
                RegistroValidado registro = new RegistroValidado();
                registro.EsValido = true;
                registro.Error = "";

                string identificacion = ObtenerValorColumna(row, "RUC");
                string razonSocial = ObtenerValorColumna(row, "RazonSocial");
                string telefonos = ObtenerValorColumna(row, "Telefonos");
                string direccion = ObtenerValorColumna(row, "Direccion");
                string email = ObtenerValorColumna(row, "Email");
                string esCliente = ObtenerValorColumna(row, "EsCliente");
                string esProveedor = ObtenerValorColumna(row, "EsProveedor");

                // Saltar filas vacías
                if (string.IsNullOrEmpty(identificacion) && string.IsNullOrEmpty(razonSocial))
                    continue;

                registro.RUC = identificacion;
                registro.RazonSocial = razonSocial;
                registro.Telefonos = telefonos;
                registro.Direccion = direccion;
                registro.Email = email;

                // Validación de Email
                if (!string.IsNullOrEmpty(email))
                {
                    if (email.Length > 350)
                    {
                        registro.EsValido = false;
                        registro.Error += (string.IsNullOrEmpty(registro.Error) ? "" : " | ") + "Email excede los 350 caracteres";
                    }
                    else if (!ValidarEmail(email))
                    {
                        registro.EsValido = false;
                        registro.Error += (string.IsNullOrEmpty(registro.Error) ? "" : " | ") + "Formato de email inválido";
                    }
                }

                // Validación de Identificación
                if (string.IsNullOrEmpty(identificacion))
                {
                    registro.EsValido = false;
                    registro.Error += (string.IsNullOrEmpty(registro.Error) ? "" : " | ") + "Identificación está vacía";
                }
                else
                {
                    string tipoId = DeterminarTipoIdentificacion(identificacion);

                    switch (tipoId)
                    {
                        case "C":
                            if (identificacion.Length != 10)
                                registro.EsValido = false;
                            else if (!identificacion.All(char.IsDigit))
                                registro.EsValido = false;
                            else
                            {
                                registro.TipoIdentificacion = "C";
                                registro.TipoPersona = "N";
                            }
                            break;
                        case "R":
                            if (identificacion.Length != 13)
                                registro.EsValido = false;
                            else if (!identificacion.All(char.IsDigit))
                                registro.EsValido = false;
                            else
                            {
                                registro.TipoIdentificacion = "R";
                                registro.TipoPersona = "J";
                            }
                            break;
                        case "P":
                            if (identificacion.Length < 6 || identificacion.Length > 20)
                                registro.EsValido = false;
                            else
                            {
                                registro.TipoIdentificacion = "P";
                                registro.TipoPersona = "N";
                            }
                            break;
                        default:
                            registro.EsValido = false;
                            break;
                    }

                    if (!registro.EsValido)
                        registro.Error += (string.IsNullOrEmpty(registro.Error) ? "" : " | ") + "Identificación inválida";

                    if (registro.EsValido && !string.IsNullOrEmpty(registro.TipoIdentificacion))
                    {
                        string codigo = GenerarCodigoUnico(identificacion, registro.TipoIdentificacion);
                        registro.Codigo = codigo;

                        if (codigosExistentes.Contains(codigo))
                        {
                            registro.EsValido = false;
                            registro.Error += (string.IsNullOrEmpty(registro.Error) ? "" : " | ") + $"El código '{codigo}' ya existe";
                        }
                        else if (documentosExistentes.Contains(identificacion))
                        {
                            registro.EsValido = false;
                            registro.Error += (string.IsNullOrEmpty(registro.Error) ? "" : " | ") + $"La identificación '{identificacion}' ya existe";
                        }
                    }
                }

                // Validación de Razón Social
                if (string.IsNullOrEmpty(razonSocial))
                {
                    registro.EsValido = false;
                    registro.Error += (string.IsNullOrEmpty(registro.Error) ? "" : " | ") + "Razón Social está vacía";
                }
                else if (razonSocial.Length > 128)
                {
                    registro.EsValido = false;
                    registro.Error += (string.IsNullOrEmpty(registro.Error) ? "" : " | ") + "Razón Social excede los 128 caracteres";
                }

                // Validación de Teléfonos
                if (!string.IsNullOrEmpty(telefonos) && telefonos.Length > 128)
                {
                    registro.EsValido = false;
                    registro.Error += (string.IsNullOrEmpty(registro.Error) ? "" : " | ") + "Teléfonos excede los 128 caracteres";
                }

                // Validación de Dirección
                if (!string.IsNullOrEmpty(direccion) && direccion.Length > 350)
                {
                    registro.EsValido = false;
                    registro.Error += (string.IsNullOrEmpty(registro.Error) ? "" : " | ") + "Dirección excede los 350 caracteres";
                }

                // Validación de Cliente/Proveedor
                registro.EsCliente = esCliente.ToUpper() == "SI" || esCliente == "1";
                registro.EsProveedor = esProveedor.ToUpper() == "SI" || esProveedor == "1";

                if (!registro.EsCliente && !registro.EsProveedor)
                {
                    registro.EsValido = false;
                    registro.Error += (string.IsNullOrEmpty(registro.Error) ? "" : " | ") + "Debe ser Cliente o Proveedor";
                }

                resultados.Add(registro);
            }

            return resultados;
        }

        private string ObtenerValorColumna(DataRow row, string nombreColumna)
        {
            if (row.Table.Columns.Contains(nombreColumna))
                return row[nombreColumna]?.ToString().Trim() ?? "";
            return "";
        }

        private void MostrarResultadosValidacion()
        {
            if (mallaValidacion == null) return;
            mallaValidacion.Rows.Clear();

            foreach (var registro in registrosValidadas)
            {
                int rowIndex = mallaValidacion.Rows.Add();
                var row = mallaValidacion.Rows[rowIndex];

                row.Cells["RUC"].Value = registro.RUC;
                row.Cells["RazonSocial"].Value = registro.RazonSocial;
                row.Cells["Telefonos"].Value = registro.Telefonos;
                row.Cells["Direccion"].Value = registro.Direccion;
                row.Cells["Email"].Value = registro.Email;
                row.Cells["EsCliente"].Value = registro.EsCliente ? "Sí" : "No";
                row.Cells["EsProveedor"].Value = registro.EsProveedor ? "Sí" : "No";
                row.Cells["TipoIdentificacion"].Value = registro.TipoIdentificacion == "C" ? "Cédula" : (registro.TipoIdentificacion == "R" ? "RUC" : (registro.TipoIdentificacion == "P" ? "Pasaporte" : ""));
                row.Cells["TipoPersona"].Value = registro.TipoPersona == "N" ? "Natural" : (registro.TipoPersona == "J" ? "Jurídica" : "");
                row.Cells["Estado"].Value = registro.EsValido ? "VÁLIDO" : "INVÁLIDO";
                row.Cells["Error"].Value = registro.Error;
                row.Cells["Codigo"].Value = registro.Codigo;

                if (registro.EsValido)
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                else
                    row.DefaultCellStyle.BackColor = Color.LightCoral;
            }
        }

        private void btnCargarDirectorio_Click(object sender, EventArgs e)
        {
            if (registrosValidadas == null || !registrosValidadas.Any())
            {
                MessageBox.Show("Primero debe validar los datos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var registrosValidos = registrosValidadas.Where(r => r.EsValido).ToList();

            if (!registrosValidos.Any())
            {
                MessageBox.Show("No hay registros válidos para guardar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                string.Format("⚠️ ADVERTENCIA: Esta acción guardará {0} registros en la base de datos.\n\n¿Desea continuar?", registrosValidos.Count),
                "Confirmar Guardado", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.No)
                return;

            try
            {
                MostrarProgreso(true, "Guardando registros en la base de datos...");
                int guardados = GuardarEnBD(registrosValidos);

                MostrarProgreso(false, string.Format("{0} registros guardados correctamente", guardados));
                if (toolStripStatusLabel != null)
                    toolStripStatusLabel.Text = string.Format("{0} registros guardados en BD", guardados);

                MessageBox.Show(string.Format("✓ Operación completada exitosamente.\n\nSe GUARDARON {0} registros en la base de datos.", guardados),
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarDespuesDeGuardar();

                if (tabControl1 != null)
                    tabControl1.SelectedIndex = 2;
            }
            catch (Exception ex)
            {
                MostrarProgreso(false, "Error al guardar");
                if (toolStripStatusLabel != null)
                    toolStripStatusLabel.Text = "Error al guardar en BD";
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int GuardarEnBD(List<RegistroValidado> registros)
        {
            int contador = 0;

            using (SqlConnection conn = new SqlConnection(datosEmpresa.strConxAdcom))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    string insertQuery = @"INSERT INTO Identificacion (
                        Codigo, TipoPersona, TipoIdentificacion, CedulaIdentidadRuc,
                        Nombres, Apellidos, NombreImpresion,
                        Telefono1, Telefono2, Telefono3,
                        Domicilio, NumeroDomicilio, Sector,
                        CorreoElectrónico, País, Provincia, Ciudad,
                        EsCliente, EsProveedor, EsEmpleado, EsBanco,
                        EsAsociado, EsVendedor, NúmeroFax, Casilla,
                        Paginaweb, Logotipo, CodGrabo, ComisionVenta,
                        CtaCobrarComisiones, FichaDental, ExoneradoIva,
                        CodAsociacion, EsDirecta, RegistroMunicp,
                        Grupo1, Grupo2, Grupo3, HistoriaClinica,
                        esRise, NroCtrbuyteEspecial, ObligLlevarConta,
                        regionDomicilio, SectorDomicilio, NroAcdoAgntRetencion,
                        RegimenMicroempresas, CtrbuyteEspecial, TipoRegimen)
                    VALUES (
                        @Codigo, @TipoPersona, @TipoIdentificacion, @CedulaIdentidadRuc,
                        @Nombres, @Apellidos, @NombreImpresion,
                        @Telefono1, @Telefono2, @Telefono3,
                        @Domicilio, @NumeroDomicilio, @Sector,
                        @CorreoElectrónico, @País, @Provincia, @Ciudad,
                        @EsCliente, @EsProveedor, @EsEmpleado, @EsBanco,
                        @EsAsociado, @EsVendedor, @NúmeroFax, @Casilla,
                        @Paginaweb, @Logotipo, @CodGrabo, @ComisionVenta,
                        @CtaCobrarComisiones, @FichaDental, @ExoneradoIva,
                        @CodAsociacion, @EsDirecta, @RegistroMunicp,
                        @Grupo1, @Grupo2, @Grupo3, @HistoriaClinica,
                        @esRise, @NroCtrbuyteEspecial, @ObligLlevarConta,
                        @regionDomicilio, @SectorDomicilio, @NroAcdoAgntRetencion,
                        @RegimenMicroempresas, @CtrbuyteEspecial, @TipoRegimen)";

                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn, transaction))
                    {
                        // Parámetros principales
                        cmd.Parameters.Add("@Codigo", SqlDbType.VarChar, 15);
                        cmd.Parameters.Add("@TipoPersona", SqlDbType.VarChar, 10);
                        cmd.Parameters.Add("@TipoIdentificacion", SqlDbType.Char, 1);
                        cmd.Parameters.Add("@CedulaIdentidadRuc", SqlDbType.VarChar, 16);
                        cmd.Parameters.Add("@Nombres", SqlDbType.VarChar, 128);
                        cmd.Parameters.Add("@Apellidos", SqlDbType.VarChar, 80);
                        cmd.Parameters.Add("@NombreImpresion", SqlDbType.VarChar, 256);
                        cmd.Parameters.Add("@Telefono1", SqlDbType.VarChar, 128);
                        cmd.Parameters.Add("@Telefono2", SqlDbType.VarChar, 25);
                        cmd.Parameters.Add("@Telefono3", SqlDbType.VarChar, 25);
                        cmd.Parameters.Add("@Domicilio", SqlDbType.VarChar, 350);
                        cmd.Parameters.Add("@NumeroDomicilio", SqlDbType.VarChar, 50);
                        cmd.Parameters.Add("@Sector", SqlDbType.VarChar, 350);
                        cmd.Parameters.Add("@CorreoElectrónico", SqlDbType.VarChar, 350);
                        cmd.Parameters.Add("@País", SqlDbType.VarChar, 15);
                        cmd.Parameters.Add("@Provincia", SqlDbType.VarChar, 15);
                        cmd.Parameters.Add("@Ciudad", SqlDbType.VarChar, 15);

                        // Flags
                        cmd.Parameters.Add("@EsCliente", SqlDbType.Bit);
                        cmd.Parameters.Add("@EsProveedor", SqlDbType.Bit);
                        cmd.Parameters.Add("@EsEmpleado", SqlDbType.Bit);
                        cmd.Parameters.Add("@EsBanco", SqlDbType.Bit);
                        cmd.Parameters.Add("@EsAsociado", SqlDbType.Bit);
                        cmd.Parameters.Add("@EsVendedor", SqlDbType.Bit);
                        cmd.Parameters.Add("@ExoneradoIva", SqlDbType.Bit);
                        cmd.Parameters.Add("@esRise", SqlDbType.Bit);
                        cmd.Parameters.Add("@ObligLlevarConta", SqlDbType.Bit);
                        cmd.Parameters.Add("@RegimenMicroempresas", SqlDbType.Bit);
                        cmd.Parameters.Add("@CtrbuyteEspecial", SqlDbType.Bit);

                        // Otros campos
                        cmd.Parameters.Add("@NúmeroFax", SqlDbType.VarChar, 150);
                        cmd.Parameters.Add("@Casilla", SqlDbType.VarChar, 25);
                        cmd.Parameters.Add("@Paginaweb", SqlDbType.VarChar, 150);
                        cmd.Parameters.Add("@Logotipo", SqlDbType.VarChar, 600);
                        cmd.Parameters.Add("@CodGrabo", SqlDbType.VarChar, 20);
                        cmd.Parameters.Add("@ComisionVenta", SqlDbType.Money);
                        cmd.Parameters.Add("@CtaCobrarComisiones", SqlDbType.VarChar, 20);
                        cmd.Parameters.Add("@FichaDental", SqlDbType.VarChar, 15);
                        cmd.Parameters.Add("@CodAsociacion", SqlDbType.VarChar, 20);
                        cmd.Parameters.Add("@EsDirecta", SqlDbType.VarChar, 2);
                        cmd.Parameters.Add("@RegistroMunicp", SqlDbType.VarChar, 20);
                        cmd.Parameters.Add("@Grupo1", SqlDbType.VarChar, 128);
                        cmd.Parameters.Add("@Grupo2", SqlDbType.VarChar, 128);
                        cmd.Parameters.Add("@Grupo3", SqlDbType.VarChar, 128);
                        cmd.Parameters.Add("@HistoriaClinica", SqlDbType.VarChar, 50);
                        cmd.Parameters.Add("@NroCtrbuyteEspecial", SqlDbType.VarChar, 20);
                        cmd.Parameters.Add("@regionDomicilio", SqlDbType.VarChar, 30);
                        cmd.Parameters.Add("@SectorDomicilio", SqlDbType.VarChar, 30);
                        cmd.Parameters.Add("@NroAcdoAgntRetencion", SqlDbType.VarChar, 20);
                        cmd.Parameters.Add("@TipoRegimen", SqlDbType.VarChar, 50);

                        foreach (var reg in registros)
                        {
                            cmd.Parameters["@Codigo"].Value = TruncateString(reg.Codigo, 15);
                            cmd.Parameters["@TipoPersona"].Value = reg.TipoPersona;
                            cmd.Parameters["@TipoIdentificacion"].Value = reg.TipoIdentificacion;
                            cmd.Parameters["@CedulaIdentidadRuc"].Value = TruncateString(reg.RUC, 16);
                            cmd.Parameters["@Nombres"].Value = TruncateString(reg.RazonSocial, 128);
                            cmd.Parameters["@Apellidos"].Value = "";
                            cmd.Parameters["@NombreImpresion"].Value = TruncateString(reg.RazonSocial, 256);
                            cmd.Parameters["@Telefono1"].Value = TruncateString(reg.Telefonos, 128);
                            cmd.Parameters["@Telefono2"].Value = "";
                            cmd.Parameters["@Telefono3"].Value = "";
                            cmd.Parameters["@Domicilio"].Value = TruncateString(reg.Direccion, 350);
                            cmd.Parameters["@NumeroDomicilio"].Value = "";
                            cmd.Parameters["@Sector"].Value = "";
                            cmd.Parameters["@CorreoElectrónico"].Value = TruncateString(reg.Email, 350);
                            cmd.Parameters["@País"].Value = "593";
                            cmd.Parameters["@Provincia"].Value = "";
                            cmd.Parameters["@Ciudad"].Value = "";

                            cmd.Parameters["@EsCliente"].Value = reg.EsCliente;
                            cmd.Parameters["@EsProveedor"].Value = reg.EsProveedor;
                            cmd.Parameters["@EsEmpleado"].Value = false;
                            cmd.Parameters["@EsBanco"].Value = false;
                            cmd.Parameters["@EsAsociado"].Value = false;
                            cmd.Parameters["@EsVendedor"].Value = false;
                            cmd.Parameters["@ExoneradoIva"].Value = false;
                            cmd.Parameters["@esRise"].Value = false;
                            cmd.Parameters["@ObligLlevarConta"].Value = false;
                            cmd.Parameters["@RegimenMicroempresas"].Value = false;
                            cmd.Parameters["@CtrbuyteEspecial"].Value = false;

                            cmd.Parameters["@NúmeroFax"].Value = "";
                            cmd.Parameters["@Casilla"].Value = "";
                            cmd.Parameters["@Paginaweb"].Value = "";
                            cmd.Parameters["@Logotipo"].Value = "";
                            cmd.Parameters["@CodGrabo"].Value = "";
                            cmd.Parameters["@ComisionVenta"].Value = 0;
                            cmd.Parameters["@CtaCobrarComisiones"].Value = "";
                            cmd.Parameters["@FichaDental"].Value = "";
                            cmd.Parameters["@CodAsociacion"].Value = "";
                            cmd.Parameters["@EsDirecta"].Value = "NO";
                            cmd.Parameters["@RegistroMunicp"].Value = "";
                            cmd.Parameters["@Grupo1"].Value = "";
                            cmd.Parameters["@Grupo2"].Value = "";
                            cmd.Parameters["@Grupo3"].Value = "";
                            cmd.Parameters["@HistoriaClinica"].Value = "";
                            cmd.Parameters["@NroCtrbuyteEspecial"].Value = "";
                            cmd.Parameters["@regionDomicilio"].Value = "";
                            cmd.Parameters["@SectorDomicilio"].Value = "";
                            cmd.Parameters["@NroAcdoAgntRetencion"].Value = "";
                            cmd.Parameters["@TipoRegimen"].Value = "";

                            contador += cmd.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception($"Error al guardar en BD: {ex.Message}");
                }
            }

            return contador;
        }

        private string TruncateString(string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return value.Length > maxLength ? value.Substring(0, maxLength) : value;
        }

        private void LimpiarDespuesDeGuardar()
        {
            if (mallaIdentificacion != null)
                mallaIdentificacion.DataSource = null;
            if (mallaValidacion != null)
                mallaValidacion.Rows.Clear();

            excelData = null;
            registrosValidadas = null;
            totalValidos = 0;
            totalInvalidos = 0;
            txtArchivo.Text = "";
            lblTotalRegistros.Text = "Total registros: 0";
            lblResumen.Text = "✅ Válidos: 0 | ❌ Inválidos: 0";
            btnValidarDirectorio.Enabled = false;
            btnCargarDirectorio.Enabled = false;
            btnExportarErrores.Enabled = false;

            if (toolStripStatusLabel != null)
                toolStripStatusLabel.Text = "✅ Registros guardados. Listo para nuevo archivo.";
            if (lblParametros != null)
            {
                lblParametros.Text = "📋 Esperando carga de archivo...";
                lblParametros.ForeColor = Color.Gray;
            }
        }


        /// <summary>
        /// Descarga la plantilla desde el servidor
        /// </summary>
        private void btnDescargarPlantilla_Click(object sender, EventArgs e)
        {
            MostrarProgreso(true, "Preparando plantilla...");

            try
            {
                string rutaPlantilla = Path.Combine(datosEmpresa.pathAppl, "bin", "directorio.xlsx");

                if (!File.Exists(rutaPlantilla))
                {
                    MostrarProgreso(false, "Plantilla no encontrada");
                    MessageBox.Show("No se encontró la plantilla en el servidor.\n" +
                        "Contacte al administrador del sistema.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (SaveFileDialog saveDialog = new SaveFileDialog())
                {
                    saveDialog.Filter = "Archivo XLSX|*.xlsx";
                    saveDialog.Title = "Guardar Plantilla";
                    saveDialog.FileName = $"Plantilla_Directorio_{DateTime.Now:yyyyMMdd}.xlsx";

                    // Mostrar el diálogo y verificar si el usuario presionó OK
                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Copiar la plantilla del servidor a la ubicación seleccionada
                        File.Copy(rutaPlantilla, saveDialog.FileName, true);

                        MostrarProgreso(false, "Plantilla descargada");

                        MessageBox.Show(
                            "✅ Plantilla descargada correctamente.\n\n" +
                            $"📁 Archivo guardado en:\n{saveDialog.FileName}",
                            "Plantilla Descargada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // Usuario canceló la operación
                        MostrarProgreso(false, "Descarga cancelada");
                        if (toolStripStatusLabel != null)
                            toolStripStatusLabel.Text = "Descarga cancelada por el usuario";
                    }
                }
            }
            catch (Exception ex)
            {
                MostrarProgreso(false, "Error al descargar plantilla");
                MessageBox.Show($"Error al descargar plantilla: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefrescarBD_Click(object sender, EventArgs e) => CargarDatosBD();

        private void CargarDatosBD()
        {
            try
            {
                MostrarProgreso(true, "Cargando datos desde BD...");
                DataTable dt = new DataTable();

                using (SqlConnection conn = new SqlConnection(datosEmpresa.strConxAdcom))
                {
                    string query = @"
                        SELECT 
                            CedulaIdentidadRuc as RUC, Nombres as RazonSocial, Telefono1 as Telefonos, 
                            Domicilio as Direccion, CorreoElectrónico as Email,
                            CASE WHEN EsCliente = 1 THEN 'Sí' ELSE 'No' END as EsCliente,
                            CASE WHEN EsProveedor = 1 THEN 'Sí' ELSE 'No' END as EsProveedor,
                            CASE WHEN TipoIdentificacion = 'C' THEN 'Cédula' WHEN TipoIdentificacion = 'R' THEN 'RUC' ELSE 'Pasaporte' END as TipoIdentificacion,
                            CASE WHEN TipoPersona = 'N' THEN 'Natural' ELSE 'Jurídica' END as TipoPersona,
                            Codigo
                        FROM Identificacion 
                        WHERE EsCliente = 1 OR EsProveedor = 1
                        ORDER BY Nombres";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.Fill(dt);
                }

                mallaBD.DataSource = dt;
                lblTotalBD.Text = $"Total en BD: {dt.Rows.Count} registros";
                CargarEstadisticas();
                MostrarProgreso(false, $"BD cargada: {dt.Rows.Count} registros");
                toolStripStatusLabel.Text = $"BD: {dt.Rows.Count} registros cargados";
            }
            catch (Exception ex)
            {
                MostrarProgreso(false, "Error al cargar BD");
                toolStripStatusLabel.Text = "Error al cargar datos de BD";
                MessageBox.Show($"Error al cargar datos de BD: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarEstadisticas()
        {
            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection conn = new SqlConnection(datosEmpresa.strConxAdcom))
                {
                    string query = @"
                        SELECT 
                            COUNT(*) as Total,
                            SUM(CASE WHEN EsCliente = 1 THEN 1 ELSE 0 END) as Clientes,
                            SUM(CASE WHEN EsProveedor = 1 THEN 1 ELSE 0 END) as Proveedores,
                            SUM(CASE WHEN TipoIdentificacion = 'R' THEN 1 ELSE 0 END) as RUCs,
                            SUM(CASE WHEN TipoIdentificacion = 'C' THEN 1 ELSE 0 END) as Cedulas,
                            SUM(CASE WHEN TipoIdentificacion = 'P' THEN 1 ELSE 0 END) as Pasaportes
                        FROM Identificacion 
                        WHERE EsCliente = 1 OR EsProveedor = 1";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.Fill(dt);
                }

                if (dt.Rows.Count > 0 && lblEstadisticas != null)
                {
                    DataRow row = dt.Rows[0];
                    lblEstadisticas.Text = string.Format("📊 Total:{0} | Clientes:{1} | Proveedores:{2} | RUCs:{3} | Cédulas:{4} | Pasaportes:{5}",
                        row["Total"], row["Clientes"], row["Proveedores"], row["RUCs"], row["Cedulas"], row["Pasaportes"]);
                }
            }
            catch (Exception)
            {
                lblEstadisticas.Text = "Estadísticas no disponibles";
            }
        }

        private void btnExportarErrores_Click(object sender, EventArgs e)
        {
            if (registrosValidadas == null || !registrosValidadas.Any())
            {
                MessageBox.Show("No hay datos para exportar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var errores = registrosValidadas.Where(r => !r.EsValido).ToList();
            if (!errores.Any())
            {
                MessageBox.Show("No hay registros con errores.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Archivos CSV|*.csv";
                saveDialog.Title = "Exportar errores";
                saveDialog.FileName = $"errores_directorio_{DateTime.Now:yyyyMMdd_HHmmss}.csv";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter writer = new StreamWriter(saveDialog.FileName, false, Encoding.UTF8))
                    {
                        writer.WriteLine("Identificación,Razón Social,Teléfonos,Dirección,Email,EsCliente,EsProveedor,Error");
                        foreach (var reg in errores)
                        {
                            writer.WriteLine($"\"{reg.RUC}\",\"{reg.RazonSocial}\",\"{reg.Telefonos}\",\"{reg.Direccion}\",\"{reg.Email}\",\"{(reg.EsCliente ? "Sí" : "No")}\",\"{(reg.EsProveedor ? "Sí" : "No")}\",\"{reg.Error}\"");
                        }
                    }
                    MessageBox.Show($"Se exportaron {errores.Count} errores.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            mallaIdentificacion.DataSource = null;
            mallaValidacion.Rows.Clear();
            mallaBD.DataSource = null;
            excelData = null;
            registrosValidadas = null;
            totalValidos = 0;
            totalInvalidos = 0;
            txtArchivo.Text = "";
            lblTotalRegistros.Text = "Total registros: 0";
            lblResumen.Text = "✅ Válidos: 0 | ❌ Inválidos: 0";
            btnValidarDirectorio.Enabled = false;
            btnCargarDirectorio.Enabled = false;
            btnExportarErrores.Enabled = false;
            toolStripStatusLabel.Text = "Listo para cargar archivo";
            lblParametros.Text = "📋 Esperando carga de archivo...";
            tabControl1.SelectedIndex = 0;
        }

        private void MostrarProgreso(bool visible, string mensaje)
        {
            if (progressBar1 != null)
            {
                progressBar1.Visible = visible;
                if (visible) progressBar1.Style = ProgressBarStyle.Marquee;
            }
            if (toolStripStatusLabel != null)
                toolStripStatusLabel.Text = visible ? $"⏳ {mensaje}" : mensaje;
            Application.DoEvents();
        }
    }

    
}