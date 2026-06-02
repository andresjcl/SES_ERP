using DattCom;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace importarData
{
    public partial class ImportarPlanDeCuentas : Form
    {
        private DataTable excelData;
        private List<CuentaValidada> cuentasValidadas;
        private ParametrosPlanCuentas parametrosActuales;

        public ImportarPlanDeCuentas()
        {
            InitializeComponent();
            ConfigurarGrids();
            CargarDatosBD();

            if (lblParametros != null)
            {
                lblParametros.Text = "📊 Esperando carga de Excel...";
                lblParametros.ForeColor = Color.Gray;
            }
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

                mallaValidacion.Columns.Add("CodigoOriginal", "Código Original");
                mallaValidacion.Columns.Add("Codigo", "Código BD");
                mallaValidacion.Columns.Add("Nombre", "Nombre");
                mallaValidacion.Columns.Add("Nivel", "Nivel");
                mallaValidacion.Columns.Add("Grupo", "Grupo");
                mallaValidacion.Columns.Add("Agrupacion", "Agrupación");
                mallaValidacion.Columns.Add("CuentaPadre", "Cuenta Padre");
                mallaValidacion.Columns.Add("Cniv1", "CNIV1");
                mallaValidacion.Columns.Add("Cniv2", "CNIV2");
                mallaValidacion.Columns.Add("Cniv3", "CNIV3");
                mallaValidacion.Columns.Add("Cniv4", "CNIV4");
                mallaValidacion.Columns.Add("NomNiv1", "Nivel 1");
                mallaValidacion.Columns.Add("NomNiv2", "Nivel 2");
                mallaValidacion.Columns.Add("Tipo", "Tipo");
                mallaValidacion.Columns.Add("Estado", "Estado");
                mallaValidacion.Columns.Add("Error", "Error");

                if (mallaValidacion.Columns["CodigoOriginal"] != null)
                    mallaValidacion.Columns["CodigoOriginal"].Width = 100;
                if (mallaValidacion.Columns["Codigo"] != null)
                    mallaValidacion.Columns["Codigo"].Width = 100;
                if (mallaValidacion.Columns["Nombre"] != null)
                    mallaValidacion.Columns["Nombre"].Width = 250;
                if (mallaValidacion.Columns["Nivel"] != null)
                    mallaValidacion.Columns["Nivel"].Width = 50;
                if (mallaValidacion.Columns["Grupo"] != null)
                    mallaValidacion.Columns["Grupo"].Width = 50;
                if (mallaValidacion.Columns["Agrupacion"] != null)
                    mallaValidacion.Columns["Agrupacion"].Width = 80;
                if (mallaValidacion.Columns["CuentaPadre"] != null)
                    mallaValidacion.Columns["CuentaPadre"].Width = 120;
                if (mallaValidacion.Columns["Cniv1"] != null)
                    mallaValidacion.Columns["Cniv1"].Width = 60;
                if (mallaValidacion.Columns["Cniv2"] != null)
                    mallaValidacion.Columns["Cniv2"].Width = 60;
                if (mallaValidacion.Columns["Cniv3"] != null)
                    mallaValidacion.Columns["Cniv3"].Width = 60;
                if (mallaValidacion.Columns["Cniv4"] != null)
                    mallaValidacion.Columns["Cniv4"].Width = 60;
                if (mallaValidacion.Columns["NomNiv1"] != null)
                    mallaValidacion.Columns["NomNiv1"].Width = 200;
                if (mallaValidacion.Columns["NomNiv2"] != null)
                    mallaValidacion.Columns["NomNiv2"].Width = 200;
                if (mallaValidacion.Columns["Tipo"] != null)
                    mallaValidacion.Columns["Tipo"].Width = 100;
                if (mallaValidacion.Columns["Estado"] != null)
                    mallaValidacion.Columns["Estado"].Width = 80;
                if (mallaValidacion.Columns["Error"] != null)
                    mallaValidacion.Columns["Error"].Width = 300;
            }
        }

        private void btnCuentasCargar_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Excel Files|*.xls;*.xlsx";
                openFileDialog.Title = "Seleccionar archivo de Plan de Cuentas";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    CargarExcel(openFileDialog.FileName);
                }
            }
        }

        private void CargarExcel(string path)
        {
            try
            {
                MostrarProgreso(true, "Cargando archivo Excel...");

                string connString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={path};Extended Properties='Excel 12.0 Xml;HDR=YES;'";

                using (OleDbConnection conn = new OleDbConnection(connString))
                {
                    conn.Open();
                    DataTable schemaTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    string sheetName = schemaTable.Rows[0]["TABLE_NAME"].ToString();

                    OleDbDataAdapter da = new OleDbDataAdapter($"SELECT * FROM [{sheetName}]", conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    DataTable filteredDt = dt.Clone();
                    foreach (DataRow row in dt.Rows)
                    {
                        bool hasData = row.ItemArray.Any(field => field != DBNull.Value && field.ToString().Trim() != string.Empty);
                        if (hasData)
                        {
                            filteredDt.ImportRow(row);
                        }
                    }

                    excelData = filteredDt;
                }

                parametrosActuales = AnalizarEstructuraDesdeExcel(excelData);
                MostrarEstructuraDetectada(parametrosActuales);

                mallaIdentificacion.DataSource = excelData;
                txtArchivo.Text = path;
                lblTotalRegistros.Text = $"Total registros: {excelData.Rows.Count}";
                btnValidarCuentas.Enabled = true;

                if (tabControl1 != null)
                    tabControl1.SelectedIndex = 0;

                MostrarProgreso(false, $"Archivo cargado: {excelData.Rows.Count} registros");
                if (toolStripStatusLabel != null)
                    toolStripStatusLabel.Text = $"Archivo cargado: {excelData.Rows.Count} registros";

                MessageBox.Show($"Archivo cargado correctamente.\n{excelData.Rows.Count} registros encontrados.\n\n📊 Estructura detectada:\n• Niveles: {parametrosActuales.NumNiveles}\n• Dígitos por nivel: {string.Join("-", parametrosActuales.DigitosPorNivel)}",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MostrarProgreso(false, "Error al cargar");
                if (toolStripStatusLabel != null)
                    toolStripStatusLabel.Text = "Error al cargar archivo";
                MessageBox.Show($"Error al cargar el archivo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private ParametrosPlanCuentas AnalizarEstructuraDesdeExcel(DataTable dt)
        {
            ParametrosPlanCuentas parametros = new ParametrosPlanCuentas();

            if (dt == null || dt.Rows.Count == 0)
            {
                throw new Exception("No hay datos para analizar la estructura");
            }

            Dictionary<int, int> longitudPorNivel = new Dictionary<int, int>();
            int maxNivel = 0;

            foreach (DataRow row in dt.Rows)
            {
                string codigoOriginal = row["codcta"]?.ToString().Trim();
                if (string.IsNullOrEmpty(codigoOriginal) || codigoOriginal == "codcta")
                    continue;

                string codigoLimpio = codigoOriginal.Trim().TrimEnd('.');
                string[] segmentos = codigoLimpio.Split('.');

                int nivel = segmentos.Length;
                if (nivel > maxNivel)
                    maxNivel = nivel;

                for (int i = 0; i < segmentos.Length; i++)
                {
                    int longitud = segmentos[i].Length;
                    int nivelActual = i + 1;

                    if (!longitudPorNivel.ContainsKey(nivelActual))
                    {
                        longitudPorNivel[nivelActual] = longitud;
                    }
                }
            }

            parametros.NumNiveles = maxNivel;
            for (int i = 1; i <= maxNivel; i++)
            {
                if (longitudPorNivel.ContainsKey(i))
                    parametros.DigitosPorNivel.Add(longitudPorNivel[i]);
                else
                    parametros.DigitosPorNivel.Add(2);
            }

            return parametros;
        }

        private string NormalizarCodigo(string codigoOriginal)
        {
            if (string.IsNullOrEmpty(codigoOriginal))
                return "";

            string codigoLimpio = codigoOriginal.Trim().TrimEnd('.');
            string[] partes = codigoLimpio.Split('.');
            return string.Join("", partes);
        }

        private List<string> ObtenerSegmentos(string codigoOriginal)
        {
            List<string> segmentos = new List<string>();

            if (string.IsNullOrEmpty(codigoOriginal))
                return segmentos;

            string codigoLimpio = codigoOriginal.Trim().TrimEnd('.');
            segmentos = codigoLimpio.Split('.').ToList();

            return segmentos;
        }

        private int CalcularNivel(string codigoOriginal)
        {
            List<string> segmentos = ObtenerSegmentos(codigoOriginal);
            return segmentos.Count;
        }

        private string ObtenerSegmentoPorNivel(string codigoOriginal, int nivel)
        {
            List<string> segmentos = ObtenerSegmentos(codigoOriginal);
            if (segmentos.Count >= nivel)
                return segmentos[nivel - 1];
            return "";
        }

        private string ConstruirCodigoPadre(string codigoOriginal)
        {
            List<string> segmentos = ObtenerSegmentos(codigoOriginal);
            if (segmentos.Count <= 1)
                return "";

            segmentos.RemoveAt(segmentos.Count - 1);
            return string.Join("", segmentos);
        }

        private string ObtenerGrupo(string primerSegmento)
        {
            switch (primerSegmento)
            {
                case "1": return "1";
                case "2": return "2";
                case "3": return "3";
                case "4": return "4";
                case "5": return "5";
                case "6": return "6";
                default: return "0";
            }
        }

        private void MostrarEstructuraDetectada(ParametrosPlanCuentas parametros)
        {
            if (lblParametros != null)
            {
                string estructura = string.Join("-", parametros.DigitosPorNivel.Select(d => d.ToString()));
                lblParametros.Text = $"📊 Estructura: {parametros.NumNiveles} niveles | Dígitos: {estructura}";
                lblParametros.ForeColor = Color.Blue;
                lblParametros.Font = new Font(lblParametros.Font, FontStyle.Bold);
            }
        }

        private void btnValidarCuentas_Click(object sender, EventArgs e)
        {
            if (excelData == null)
            {
                MessageBox.Show("Primero debe cargar un archivo Excel.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (parametrosActuales == null)
            {
                MessageBox.Show("No se pudo detectar la estructura del archivo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                MostrarProgreso(true, "Validando estructura del plan de cuentas...");
                cuentasValidadas = ValidarEstructura(excelData);
                MostrarResultadosValidacion();

                int validas = cuentasValidadas.Count(c => c.EsValido);
                int invalidas = cuentasValidadas.Count(c => !c.EsValido);

                lblResumen.Text = string.Format("Válidas: {0} | Inválidas: {1}", validas, invalidas);
                btnCargarCuentas.Enabled = validas > 0;
                if (btnExportarErrores != null)
                    btnExportarErrores.Enabled = invalidas > 0;

                if (tabControl1 != null)
                    tabControl1.SelectedIndex = 1;

                MostrarProgreso(false, string.Format("Validación completada - Válidas: {0}, Inválidas: {1}", validas, invalidas));
                if (toolStripStatusLabel != null)
                    toolStripStatusLabel.Text = string.Format("Validación completada - Válidas: {0}, Inválidas: {1}", validas, invalidas);

                MessageBox.Show(string.Format("Validación completada.\n\n✅ Cuentas válidas: {0}\n❌ Cuentas inválidas: {1}", validas, invalidas),
                    "Resultado de Validación", MessageBoxButtons.OK, invalidas > 0 ? MessageBoxIcon.Warning : MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MostrarProgreso(false, "Error en validación");
                if (toolStripStatusLabel != null)
                    toolStripStatusLabel.Text = "Error en validación";
                MessageBox.Show($"Error durante la validación: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<CuentaValidada> ValidarEstructura(DataTable dt)
        {
            List<CuentaValidada> resultados = new List<CuentaValidada>();
            HashSet<string> todosLosCodigos = new HashSet<string>();
            Dictionary<string, string> nombrePorCodigo = new Dictionary<string, string>();

            // PRIMERA PASADA: Recolectar todos los códigos y nombres
            foreach (DataRow row in dt.Rows)
            {
                string codigoOriginal = row["codcta"]?.ToString().Trim();
                string nombre = row["nomcta"]?.ToString().Trim();

                if (!string.IsNullOrEmpty(codigoOriginal) && codigoOriginal != "codcta")
                {
                    string codigoNormalizado = NormalizarCodigo(codigoOriginal);
                    todosLosCodigos.Add(codigoNormalizado);
                    nombrePorCodigo[codigoNormalizado] = nombre;
                }
            }

            // SEGUNDA PASADA: Validar cada cuenta
            foreach (DataRow row in dt.Rows)
            {
                string codigoOriginal = row["codcta"]?.ToString().Trim();
                string nombre = row["nomcta"]?.ToString().Trim();

                if (string.IsNullOrEmpty(codigoOriginal) || codigoOriginal == "codcta")
                    continue;

                CuentaValidada cuenta = new CuentaValidada();
                cuenta.CodigoOriginal = codigoOriginal;
                cuenta.CodigoNormalizado = NormalizarCodigo(codigoOriginal);
                cuenta.Nombre = nombre;
                cuenta.EsValido = true;
                cuenta.Error = "";

                // Obtener segmentos y nivel
                List<string> segmentos = ObtenerSegmentos(codigoOriginal);
                int nivel = segmentos.Count;
                cuenta.Nivel = nivel;

                if (nivel == 0)
                {
                    cuenta.EsValido = false;
                    cuenta.Error = "No se pudo determinar el nivel del código";
                }

                // Validar longitud según parámetros
                if (parametrosActuales != null && nivel > 0 && nivel <= parametrosActuales.DigitosPorNivel.Count)
                {
                    int longitudEsperada = 0;
                    for (int i = 0; i < nivel; i++)
                    {
                        longitudEsperada += parametrosActuales.DigitosPorNivel[i];
                    }

                    if (cuenta.CodigoNormalizado.Length != longitudEsperada)
                    {
                        cuenta.EsValido = false;
                        cuenta.Error = $"El código debe tener {longitudEsperada} dígitos para nivel {nivel} (tiene {cuenta.CodigoNormalizado.Length})";
                    }
                }

                if (cuenta.EsValido && segmentos.Count > 0)
                {
                    cuenta.Grupo = ObtenerGrupo(segmentos[0]);
                    cuenta.Cniv1 = segmentos.Count >= 1 ? segmentos[0] : "";
                    cuenta.Cniv2 = segmentos.Count >= 2 ? segmentos[1] : "";
                    cuenta.Cniv3 = segmentos.Count >= 3 ? segmentos[2] : "";
                    cuenta.Cniv4 = segmentos.Count >= 4 ? segmentos[3] : "";

                    // Nombres de niveles
                    if (segmentos.Count >= 1)
                    {
                        string codigoNivel1 = segmentos[0];
                        if (nombrePorCodigo.ContainsKey(codigoNivel1))
                            cuenta.NomNiv1 = nombrePorCodigo[codigoNivel1];
                    }

                    if (segmentos.Count >= 2)
                    {
                        string codigoNivel2 = segmentos[0] + segmentos[1];
                        if (nombrePorCodigo.ContainsKey(codigoNivel2))
                            cuenta.NomNiv2 = nombrePorCodigo[codigoNivel2];
                    }

                    // Validar padre
                    if (nivel > 1)
                    {
                        string codigoPadre = ConstruirCodigoPadre(codigoOriginal);
                        cuenta.CuentaPadre = codigoPadre;

                        if (!todosLosCodigos.Contains(codigoPadre))
                        {
                            cuenta.EsValido = false;
                            cuenta.Error = (string.IsNullOrEmpty(cuenta.Error) ? "" : cuenta.Error + " | ") + $"No existe la cuenta padre: {codigoPadre}";
                        }
                    }

                    if (nivel == 1)
                    {
                        cuenta.Agrupacion = true;
                    }
                }

                resultados.Add(cuenta);
            }

            // TERCERA PASADA: Identificar cuentas agrupadoras vs de detalle
            IdentificarCuentasDeDetalle(resultados);

            return resultados;
        }

        
        private void IdentificarCuentasDeDetalle(List<CuentaValidada> cuentas)
        {
            // Primero, identificar todos los códigos que son padres (tienen hijos)
            HashSet<string> codigosQueSonPadres = new HashSet<string>();

            foreach (var cuenta in cuentas)
            {
                if (!string.IsNullOrEmpty(cuenta.CuentaPadre))
                {
                    codigosQueSonPadres.Add(cuenta.CuentaPadre);
                }
            }

            // Segundo, marcar cada cuenta
            foreach (var cuenta in cuentas)
            {
                // Si la cuenta NO es padre de ninguna otra, es cuenta de detalle
                bool esCuentaDetalle = !codigosQueSonPadres.Contains(cuenta.CodigoNormalizado);

                cuenta.EsAgrupadora = !esCuentaDetalle;
                cuenta.PermiteMovimiento = esCuentaDetalle;
                cuenta.Tipo = esCuentaDetalle ? "DETALLE" : "AGRUPADORA";

                // IMPORTANTE: 
                // - Cuentas AGRUPADORAS -> Agrupacion = SÍ
                // - Cuentas de DETALLE -> Agrupacion = NO
                cuenta.Agrupacion = !esCuentaDetalle;  // TRUE para agrupadoras, FALSE para detalle

                // Asignar flags de movimiento según el tipo
                if (esCuentaDetalle)
                {
                    // Cuentas de detalle: permiten movimientos
                    cuenta.Cta_Gasto = 1;
                    cuenta.Cta_CostosDir = 1;
                    cuenta.Cta_CostosInDir = 1;
                }
                else
                {
                    // Cuentas agrupadoras: NO permiten movimientos
                    cuenta.Cta_Gasto = 0;
                    cuenta.Cta_CostosDir = 0;
                    cuenta.Cta_CostosInDir = 0;
                }
            }
        }
        private void MostrarResultadosValidacion()
        {
            if (mallaValidacion == null) return;
            mallaValidacion.Rows.Clear();

            foreach (var cuenta in cuentasValidadas)
            {
                int rowIndex = mallaValidacion.Rows.Add();
                var row = mallaValidacion.Rows[rowIndex];

                row.Cells["CodigoOriginal"].Value = cuenta.CodigoOriginal;
                row.Cells["Codigo"].Value = cuenta.CodigoNormalizado;
                row.Cells["Nombre"].Value = cuenta.Nombre;
                row.Cells["Nivel"].Value = cuenta.Nivel;
                row.Cells["Grupo"].Value = cuenta.Grupo;
                row.Cells["Agrupacion"].Value = cuenta.Agrupacion ? "Sí" : "No";
                row.Cells["CuentaPadre"].Value = cuenta.CuentaPadre;
                row.Cells["Cniv1"].Value = cuenta.Cniv1;
                row.Cells["Cniv2"].Value = cuenta.Cniv2;
                row.Cells["Cniv3"].Value = cuenta.Cniv3;
                row.Cells["Cniv4"].Value = cuenta.Cniv4;
                row.Cells["NomNiv1"].Value = cuenta.NomNiv1;
                row.Cells["NomNiv2"].Value = cuenta.NomNiv2;
                row.Cells["Tipo"].Value = cuenta.Tipo;
                row.Cells["Estado"].Value = cuenta.EsValido ? "VÁLIDA" : "INVÁLIDA";
                row.Cells["Error"].Value = cuenta.Error;

                if (cuenta.EsValido)
                {
                    row.DefaultCellStyle.BackColor = cuenta.EsAgrupadora ? Color.LightBlue : Color.LightGreen;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.LightCoral;
                }
            }
        }

        private void btnCargarCuentas_Click(object sender, EventArgs e)
        {
            if (cuentasValidadas == null || !cuentasValidadas.Any())
            {
                MessageBox.Show("Primero debe validar los datos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var cuentasValidas = cuentasValidadas.Where(c => c.EsValido).ToList();

            if (!cuentasValidas.Any())
            {
                MessageBox.Show("No hay cuentas válidas para guardar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int agrupadoras = cuentasValidas.Count(c => c.EsAgrupadora);
            int detalle = cuentasValidas.Count(c => !c.EsAgrupadora);

            DialogResult result = MessageBox.Show(
                string.Format("⚠️ ADVERTENCIA: Esta acción:\n\n1. ELIMINARÁ TODOS los registros actuales de AdcCta\n2. ACTUALIZARÁ los parámetros en emp_par\n3. GUARDARÁ:\n   • {0} cuentas AGRUPADORAS (sin movimiento)\n   • {1} cuentas de DETALLE (con movimiento)\n\n¿Desea continuar?", agrupadoras, detalle),
                "Confirmar Guardado", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.No)
                return;

            try
            {
                MostrarProgreso(true, "Actualizando parámetros y guardando plan de cuentas...");
                string usuario = txtUsuario.Text.Trim();
                if (string.IsNullOrEmpty(usuario)) usuario = Environment.UserName;

                ActualizarParametrosEnEmpresa(parametrosActuales);
                int guardadas = GuardarEnBD(cuentasValidas, usuario);

                MostrarProgreso(false, string.Format("{0} cuentas guardadas correctamente", guardadas));
                if (toolStripStatusLabel != null)
                    toolStripStatusLabel.Text = string.Format("{0} cuentas guardadas en BD", guardadas);

                MessageBox.Show(string.Format("✓ Operación completada exitosamente.\n\n• Parámetros actualizados en emp_par\n• Se ELIMINARON registros anteriores de AdcCta\n• Se GUARDARON:\n  • {0} cuentas AGRUPADORAS\n  • {1} cuentas de DETALLE", agrupadoras, detalle),
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarDatosBD();
                if (tabControl1 != null) tabControl1.SelectedIndex = 2;
            }
            catch (Exception ex)
            {
                MostrarProgreso(false, "Error al guardar");
                if (toolStripStatusLabel != null) toolStripStatusLabel.Text = "Error al guardar en BD";
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarParametrosEnEmpresa(ParametrosPlanCuentas parametros)
        {
            string digitosPorNivel = string.Join("", parametros.DigitosPorNivel.Select(d => d.ToString()));

            using (SqlConnection conn = new SqlConnection(datosEmpresa.strConIniSis))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    string updateQuery = @"
                        UPDATE emp_par 
                        SET DefCta_NumDigNivel = @digitosPorNivel, 
                            DefCta_NumNiveles = @numNiveles
                        WHERE Emp_Codigo = @codigo";

                    using (SqlCommand cmd = new SqlCommand(updateQuery, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@digitosPorNivel", digitosPorNivel);
                        cmd.Parameters.AddWithValue("@numNiveles", parametros.NumNiveles);
                        cmd.Parameters.AddWithValue("@codigo", datosEmpresa.Emp_codigo);

                        int filasActualizadas = cmd.ExecuteNonQuery();

                        if (filasActualizadas == 0)
                        {
                            string insertQuery = @"
                                INSERT INTO emp_par (Emp_Codigo, DefCta_NumDigNivel, DefCta_NumNiveles)
                                VALUES (@codigo, @digitosPorNivel, @numNiveles)";

                            using (SqlCommand cmdInsert = new SqlCommand(insertQuery, conn, transaction))
                            {
                                cmdInsert.Parameters.AddWithValue("@codigo", datosEmpresa.Emp_codigo);
                                cmdInsert.Parameters.AddWithValue("@digitosPorNivel", digitosPorNivel);
                                cmdInsert.Parameters.AddWithValue("@numNiveles", parametros.NumNiveles);
                                cmdInsert.ExecuteNonQuery();
                            }
                        }
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception($"Error al actualizar parámetros en emp_par: {ex.Message}");
                }
            }
        }

        private int GuardarEnBD(List<CuentaValidada> cuentas, string usuario)
        {
            int contador = 0;

            using (SqlConnection conn = new SqlConnection(datosEmpresa.strConxAdcom))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    string deleteQuery = "DELETE FROM AdcCta";
                    using (SqlCommand cmd = new SqlCommand(deleteQuery, conn, transaction))
                    {
                        int eliminados = cmd.ExecuteNonQuery();
                        System.Diagnostics.Debug.WriteLine($"Registros eliminados de AdcCta: {eliminados}");
                    }

                    string insertQuery = @"
                        INSERT INTO AdcCta (
                            Cta_codigo, Cta_nombre, Cta_grupo, Cta_agrupacion, Cta_Nivel,
                            CuentaPadre, Cniv1, Cniv2, Cniv3, Cniv4, NomNiv1, NomNiv2,
                            Cta_Gasto, Cta_CostosDir, Cta_CostosInDir,
                            FechaCierre, Estado, Cta_usuario
                        ) VALUES (
                            @codigo, @nombre, @grupo, @agrupacion, @nivel,
                            @cuentaPadre, @cniv1, @cniv2, @cniv3, @cniv4, @nomNiv1, @nomNiv2,
                            @ctaGasto, @ctaCostosDir, @ctaCostosInDir,
                            @fechaCierre, @estado, @usuario
                        )";

                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn, transaction))
                    {
                        cmd.Parameters.Add("@codigo", SqlDbType.VarChar, 15);
                        cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 80);
                        cmd.Parameters.Add("@grupo", SqlDbType.VarChar, 1);
                        cmd.Parameters.Add("@agrupacion", SqlDbType.Bit);
                        cmd.Parameters.Add("@nivel", SqlDbType.Decimal);
                        cmd.Parameters.Add("@cuentaPadre", SqlDbType.VarChar, 50);
                        cmd.Parameters.Add("@cniv1", SqlDbType.VarChar, 15);
                        cmd.Parameters.Add("@cniv2", SqlDbType.VarChar, 15);
                        cmd.Parameters.Add("@cniv3", SqlDbType.VarChar, 15);
                        cmd.Parameters.Add("@cniv4", SqlDbType.VarChar, 15);
                        cmd.Parameters.Add("@nomNiv1", SqlDbType.VarChar, 128);
                        cmd.Parameters.Add("@nomNiv2", SqlDbType.VarChar, 128);
                        cmd.Parameters.Add("@ctaGasto", SqlDbType.SmallInt);
                        cmd.Parameters.Add("@ctaCostosDir", SqlDbType.SmallInt);
                        cmd.Parameters.Add("@ctaCostosInDir", SqlDbType.SmallInt);
                        cmd.Parameters.Add("@fechaCierre", SqlDbType.Date);
                        cmd.Parameters.Add("@estado", SqlDbType.Char, 1);
                        cmd.Parameters.Add("@usuario", SqlDbType.VarChar, 15);

                        foreach (var cuenta in cuentas)
                        {
                            cmd.Parameters["@codigo"].Value = TruncateString(cuenta.CodigoNormalizado, 15);
                            cmd.Parameters["@nombre"].Value = TruncateString(cuenta.Nombre, 80);
                            cmd.Parameters["@grupo"].Value = cuenta.Grupo;
                            cmd.Parameters["@agrupacion"].Value = cuenta.Agrupacion;
                            cmd.Parameters["@nivel"].Value = cuenta.Nivel;
                            cmd.Parameters["@cuentaPadre"].Value = string.IsNullOrEmpty(cuenta.CuentaPadre) ? (object)DBNull.Value : TruncateString(cuenta.CuentaPadre, 50);
                            cmd.Parameters["@cniv1"].Value = string.IsNullOrEmpty(cuenta.Cniv1) ? (object)DBNull.Value : TruncateString(cuenta.Cniv1, 15);
                            cmd.Parameters["@cniv2"].Value = string.IsNullOrEmpty(cuenta.Cniv2) ? (object)DBNull.Value : TruncateString(cuenta.Cniv2, 15);
                            cmd.Parameters["@cniv3"].Value = string.IsNullOrEmpty(cuenta.Cniv3) ? (object)DBNull.Value : TruncateString(cuenta.Cniv3, 15);
                            cmd.Parameters["@cniv4"].Value = string.IsNullOrEmpty(cuenta.Cniv4) ? (object)DBNull.Value : TruncateString(cuenta.Cniv4, 15);
                            cmd.Parameters["@nomNiv1"].Value = string.IsNullOrEmpty(cuenta.NomNiv1) ? (object)DBNull.Value : TruncateString(cuenta.NomNiv1, 128);
                            cmd.Parameters["@nomNiv2"].Value = string.IsNullOrEmpty(cuenta.NomNiv2) ? (object)DBNull.Value : TruncateString(cuenta.NomNiv2, 128);

                            // Asignar flags según el tipo de cuenta
                            cmd.Parameters["@ctaGasto"].Value = cuenta.Cta_Gasto;
                            cmd.Parameters["@ctaCostosDir"].Value = cuenta.Cta_CostosDir;
                            cmd.Parameters["@ctaCostosInDir"].Value = cuenta.Cta_CostosInDir;

                            cmd.Parameters["@fechaCierre"].Value = DateTime.Now;
                            cmd.Parameters["@estado"].Value = "A";
                            cmd.Parameters["@usuario"].Value = TruncateString(usuario, 15);

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

        private void btnRefrescarBD_Click(object sender, EventArgs e) { CargarDatosBD(); }

        private void CargarDatosBD()
        {
            try
            {
                MostrarProgreso(true, "Cargando datos desde BD...");
                DataTable dt = new DataTable();

                using (SqlConnection conn = new SqlConnection(datosEmpresa.strConxAdcom))
                {
                    string query = @"
                        SELECT Cta_codigo, Cta_nombre, Cta_grupo, Cta_Nivel, 
                               CuentaPadre, Cniv1, Cniv2, Cniv3, Cniv4, NomNiv1, NomNiv2,
                               Cta_Gasto, Estado, Cta_usuario, FechaCierre
                        FROM AdcCta 
                        ORDER BY Cta_codigo";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.Fill(dt);
                }

                if (mallaBD != null) mallaBD.DataSource = dt;
                if (lblTotalBD != null) lblTotalBD.Text = string.Format("Total en BD: {0} registros", dt.Rows.Count);
                CargarEstadisticas();

                MostrarProgreso(false, string.Format("BD cargada: {0} registros", dt.Rows.Count));
                if (toolStripStatusLabel != null) toolStripStatusLabel.Text = string.Format("BD: {0} cuentas cargadas", dt.Rows.Count);
            }
            catch (Exception ex)
            {
                MostrarProgreso(false, "Error al cargar BD");
                if (toolStripStatusLabel != null) toolStripStatusLabel.Text = "Error al cargar datos de BD";
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
                            COUNT(*) as TotalCuentas,
                            SUM(CASE WHEN Cta_Nivel = 1 THEN 1 ELSE 0 END) as Nivel1,
                            SUM(CASE WHEN Cta_Nivel = 2 THEN 1 ELSE 0 END) as Nivel2,
                            SUM(CASE WHEN Cta_Nivel = 3 THEN 1 ELSE 0 END) as Nivel3,
                            SUM(CASE WHEN Cta_Nivel = 4 THEN 1 ELSE 0 END) as Nivel4,
                            SUM(CASE WHEN Cta_Nivel = 5 THEN 1 ELSE 0 END) as Nivel5,
                            SUM(CASE WHEN Cta_grupo = '1' THEN 1 ELSE 0 END) as Activos,
                            SUM(CASE WHEN Cta_grupo = '2' THEN 1 ELSE 0 END) as Pasivos,
                            SUM(CASE WHEN Cta_grupo = '3' THEN 1 ELSE 0 END) as Patrimonio,
                            SUM(CASE WHEN Cta_grupo = '4' THEN 1 ELSE 0 END) as Ingresos,
                            SUM(CASE WHEN Cta_grupo = '5' THEN 1 ELSE 0 END) as Egresos,
                            SUM(CASE WHEN Cta_Gasto = 1 THEN 1 ELSE 0 END) as CuentasConMovimiento
                        FROM AdcCta WHERE Estado = 'A'";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.Fill(dt);
                }

                if (dt.Rows.Count > 0 && lblEstadisticas != null)
                {
                    DataRow row = dt.Rows[0];
                    lblEstadisticas.Text = string.Format("Total:{0} | N1:{1} N2:{2} N3:{3} N4:{4} N5:{5} | Mov:{6} | Act:{7} Pas:{8} Pat:{9} Ing:{10} Egr:{11}",
                        row["TotalCuentas"], row["Nivel1"], row["Nivel2"], row["Nivel3"], row["Nivel4"], row["Nivel5"],
                        row["CuentasConMovimiento"], row["Activos"], row["Pasivos"], row["Patrimonio"], row["Ingresos"], row["Egresos"]);
                }
            }
            catch (Exception ex)
            {
                if (lblEstadisticas != null) lblEstadisticas.Text = "Estadísticas no disponibles";
            }
        }

        private void btnExportarErrores_Click(object sender, EventArgs e)
        {
            if (cuentasValidadas == null || !cuentasValidadas.Any())
            {
                MessageBox.Show("No hay datos para exportar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var errores = cuentasValidadas.Where(c => !c.EsValido).ToList();
            if (!errores.Any())
            {
                MessageBox.Show("No hay cuentas con errores para exportar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Archivos CSV|*.csv|Archivos de Texto|*.txt";
                saveDialog.Title = "Exportar errores";
                saveDialog.FileName = $"errores_plan_cuentas_{DateTime.Now:yyyyMMdd_HHmmss}.csv";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (System.IO.StreamWriter writer = new System.IO.StreamWriter(saveDialog.FileName, false, Encoding.UTF8))
                        {
                            writer.WriteLine("Código Original,Código BD,Nombre,Nivel,Tipo,Error");
                            foreach (var cuenta in errores)
                            {
                                writer.WriteLine($"\"{cuenta.CodigoOriginal}\",\"{cuenta.CodigoNormalizado}\",\"{cuenta.Nombre}\",{cuenta.Nivel},\"{cuenta.Tipo}\",\"{cuenta.Error}\"");
                            }
                        }
                        MessageBox.Show($"Se exportaron {errores.Count} errores a:\n{saveDialog.FileName}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al exportar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            if (mallaIdentificacion != null) mallaIdentificacion.DataSource = null;
            if (mallaValidacion != null) mallaValidacion.Rows.Clear();
            if (mallaBD != null) mallaBD.DataSource = null;

            excelData = null;
            cuentasValidadas = null;
            parametrosActuales = null;
            txtArchivo.Text = "";
            lblTotalRegistros.Text = "Total registros: 0";
            lblResumen.Text = "Válidas: 0 | Inválidas: 0";
            btnValidarCuentas.Enabled = false;
            btnCargarCuentas.Enabled = false;
            if (btnExportarErrores != null) btnExportarErrores.Enabled = false;
            if (toolStripStatusLabel != null) toolStripStatusLabel.Text = "Listo para cargar archivo";
            if (lblParametros != null)
            {
                lblParametros.Text = "📊 Esperando carga de Excel...";
                lblParametros.ForeColor = Color.Gray;
            }
            if (tabControl1 != null) tabControl1.SelectedIndex = 0;
        }

        private void MostrarProgreso(bool visible, string mensaje)
        {
            if (progressBar1 != null)
            {
                progressBar1.Visible = visible;
                if (visible) progressBar1.Style = ProgressBarStyle.Marquee;
            }
            if (toolStripStatusLabel != null) toolStripStatusLabel.Text = visible ? $"⏳ {mensaje}" : mensaje;
            Application.DoEvents();
        }
    }

    

    
}