using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using Microsoft.Reporting.WinForms;
using varbleComun;
using Newtonsoft.Json;
using System.Data.SqlClient;

namespace ClienteReporteInventario
{
    public partial class CatalogoGeneral : Form
    {
        // ==========================================
        // VARIABLES GLOBALES
        // ==========================================
        private string titulo = "Reporte";
        private string bodega = "";
        private string Ordenar = "";
        private string CCat = "";
        private string CCla = "";
        private string CGru = "";
        private string CSub = "";
        private string categoria = "";
        private string clase = "";
        private string grupo = "";
        private string subg = "";
        private string codIni = "";
        private string codFin = "";
        private string costeo = "P";
        private string NomCosteo = "Promedio";
        private int articulosExiten = 0;
        ////private const string API_URL = "https://localhost:7190";
        private readonly string API_URL;
        private BackgroundWorker _backgroundWorker;
        private List<EmpresaInfo> _empresasList;
        private string _empresaSeleccionada = "";
        private string _servidorSeleccionado = "";
        private string _sucursalSeleccionada = "";
        private string _bodegaSeleccionada = "";
        private List<ServidorInfo> _servidoresList;

        public CatalogoGeneral()
        {
            try
            {
                InitializeComponent();
                cargar.iniciar("", "");
                API_URL = Configuracion.ApiUrl;
                Inicializar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al inicializar: " + ex.Message);
                Environment.Exit(0);
            }
        }

        private void Inicializar()
        {
            try
            {
                cargar.iniciar("", "");
                if (VarCom.codEmpresa == 0)
                {
                    MessageBox.Show("No se ha conectado al servidor ADCOMdx", "",
                        MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    Environment.Exit(0);
                }

                lblConexion.Text = $"✅ Conectado: {VarCom.nomEmpresa} ({VarCom.codEmpresa})";
                lblConexion.ForeColor = Color.Green;

                txtFecha.Text = DateTime.Now.ToShortDateString();
                optCostoPro.Checked = true;

                // ✅ Configurar combos
                ConfigurarCombos();

                // ✅ Cargar categorías (globales)
                LlenarCombos();

                // ✅ Cargar empresas desde TODOS los servidores
                CargarEmpresas();

                VerificarApi();
                ConfigurarBackgroundWorker();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en Inicializar: " + ex.Message);
            }
        }

        // ==========================================
        // CLASE PARA SERVIDOR (DESDE MasterConexiones_Prod)
        // ==========================================
        public class ServidorInfo
        {
            public string ServerName { get; set; }
            public string Alias { get; set; }
            public string UserId { get; set; }
            public string Password { get; set; }
            public List<SucursalInfo> Sucursales { get; set; } = new List<SucursalInfo>();

            public string GetConnectionString()
            {
                return $"Server={ServerName};User Id={UserId};Password={Password};Connection Timeout=30;";
            }

            public override string ToString()
            {
                if (!string.IsNullOrEmpty(Alias))
                {
                    return $"{Alias} ({ServerName})";
                }
                return ServerName;
            }
        }

        // ==========================================
        // CLASE PARA DATOS COMPLETOS (DESDE CADA SERVIDOR)
        // ==========================================
        public class DatosCompletos
        {
            public string EmpCodigo { get; set; }
            public string EmpNombre { get; set; }
            public string EmpDireccion { get; set; }
            public string EmpRUC { get; set; }
            public string SucursalCodigo { get; set; }
            public string SucursalNombre { get; set; }
            public string BodCodigo { get; set; }
            public string BodNombre { get; set; }
            public string DatabaseName { get; set; }
            public string ServerName { get; set; }
        }

        // ==========================================
        // CLASE PARA EMPRESA (AGRUPADA POR RUC)
        // ==========================================
        public class EmpresaInfo
        {
            public string EmpCodigo { get; set; }
            public string EmpNombre { get; set; }
            public string EmpRUC { get; set; }
            public string ClaveRUC { get; set; } // ✅ Clave para agrupar
            public List<ServidorInfo> Servidores { get; set; } = new List<ServidorInfo>();

            public override string ToString()
            {
                if (Servidores != null && Servidores.Count > 0)
                {
                    return $"{EmpNombre} ({Servidores.Count} servidores)";
                }
                return EmpNombre;
            }
        }

        // ==========================================
        // CLASE PARA SUCURSAL
        // ==========================================
        public class SucursalInfo
        {
            public string SucursalCodigo { get; set; }
            public string SucursalNombre { get; set; }
            public string DatabaseName { get; set; }
            public List<BodegaInfo> Bodegas { get; set; } = new List<BodegaInfo>();

            public string GetConnectionString(string serverName, string userId, string password)
            {
                return $"Server={serverName};Database={DatabaseName};User Id={userId};Password={password};Connection Timeout=30;";
            }

            public override string ToString()
            {
                return string.IsNullOrEmpty(SucursalNombre) ? SucursalCodigo : $"{SucursalNombre} ({SucursalCodigo})";
            }
        }

        // ==========================================
        // CLASE PARA BODEGA
        // ==========================================
        public class BodegaInfo
        {
            public string BodCodigo { get; set; }
            public string BodNombre { get; set; }

            public override string ToString()
            {
                return string.IsNullOrEmpty(BodNombre) ? BodCodigo : $"{BodNombre} ({BodCodigo})";
            }
        }

        // ==========================================
        // CONFIGURAR COMBOS JERÁRQUICOS
        // ==========================================
        private void ConfigurarCombos()
        {
            // Buscar controles en el panelCombos
            if (panelCombos != null)
            {
                foreach (Control ctrl in panelCombos.Controls)
                {
                    if (ctrl is ComboBox combo)
                    {
                        if (combo.Name == "cmbEmpresa") cmbEmpresa = (ComboBox)ctrl;
                        if (combo.Name == "cmbServidor") cmbServidor = (ComboBox)ctrl;
                        if (combo.Name == "cmbSucursal") cmbSucursal = (ComboBox)ctrl;
                        if (combo.Name == "cboBodega") cboBodega = (ComboBox)ctrl;
                    }
                }
            }

            // Configurar eventos
            if (cmbEmpresa != null)
            {
                cmbEmpresa.Items.Clear();
                cmbEmpresa.Items.Add("-- Seleccionar Empresa --");
                cmbEmpresa.SelectedIndex = 0;
                cmbEmpresa.SelectedIndexChanged += cmbEmpresa_SelectedIndexChanged;
            }

            if (cmbServidor != null)
            {
                cmbServidor.Items.Clear();
                cmbServidor.Items.Add("-- Seleccionar Empresa Primero --");
                cmbServidor.SelectedIndex = 0;
                cmbServidor.SelectedIndexChanged += cmbServidor_SelectedIndexChanged;
            }

            if (cmbSucursal != null)
            {
                cmbSucursal.Items.Clear();
                cmbSucursal.Items.Add("-- Seleccionar Servidor Primero --");
                cmbSucursal.SelectedIndex = 0;
                cmbSucursal.SelectedIndexChanged += cmbSucursal_SelectedIndexChanged;
            }

            if (cboBodega != null)
            {
                cboBodega.Items.Clear();
                cboBodega.Items.Add("-- Seleccionar Sucursal Primero --");
                cboBodega.SelectedIndex = 0;
            }

            // Forzar visibilidad
            if (cmbEmpresa != null) cmbEmpresa.Visible = true;
            if (cmbServidor != null) cmbServidor.Visible = true;
            if (cmbSucursal != null) cmbSucursal.Visible = true;
            if (cboBodega != null) cboBodega.Visible = true;
        }

        // ==========================================
        // OBTENER SERVIDORES DESDE MasterConexiones_Prod
        // ==========================================

        private List<ServidorInfo> ObtenerServidoresDesdeMaster()
        {
            var servidores = new List<ServidorInfo>();

            try
            {
                string connectionString = $"Server={VarCom.servidor};Database=MasterConexiones_Prod;User Id=api_prod;Password=ApiProd2026!;";

                // ✅ SOLO ServerName, Alias, UserId, Password
                string query = @"
            SELECT DISTINCT ServerName, Alias, UserId, Password
            FROM SucursalesServidores 
            WHERE Activo = 1
            ORDER BY Alias";

                using (var conn = new SqlConnection(connectionString))
                using (var cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            servidores.Add(new ServidorInfo
                            {
                                ServerName = reader["ServerName"]?.ToString() ?? "",
                                Alias = reader["Alias"]?.ToString() ?? "",
                                UserId = reader["UserId"]?.ToString() ?? "",
                                Password = reader["Password"]?.ToString() ?? ""
                            });
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener servidores: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return servidores;
        }


        // ==========================================
        // OBTENER DATOS DE UN SERVIDOR ESPECÍFICO
        // ==========================================
        private List<DatosCompletos> ObtenerDatosDesdeServidor(ServidorInfo servidor)
        {
            var datos = new List<DatosCompletos>();

            try
            {
                string connectionString = servidor.GetConnectionString();

                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (var cmdUse = new SqlCommand("USE Daxsys", conn))
                    {
                        cmdUse.ExecuteNonQuery();
                    }

                    string query = @"
                        SELECT 
                            t1.emp_codigo,
                            t1.emp_nombre,
                            t1.Emp_Dirección,
                            t1.emp_ruc,
                            t2.Suc_Codigo,
                            t2.suc_nombre,
                            t3.Bod_codigo,
                            t3.Bod_nombre,
                            t5.Arch_Nom AS DatabaseName
                        FROM emp_datos t1
                        INNER JOIN emp_suc t2 ON t1.Emp_codigo = t2.emp_codigo
                        RIGHT JOIN emp_bod t3 ON t1.emp_codigo = t3.emp_codigo AND T3.Suc_Codigo = T2.Suc_Codigo
                        INNER JOIN Emp_par t4 ON t1.emp_codigo = t4.emp_codigo
                        INNER JOIN Emp_Arch t5 ON t1.emp_codigo = t5.emp_codigo
                        WHERE t5.Arch_Tipo = 'ADC'
                        ORDER BY t2.Suc_Codigo";

                    using (var cmd = new SqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            datos.Add(new DatosCompletos
                            {
                                EmpCodigo = reader["emp_codigo"]?.ToString() ?? "",
                                EmpNombre = reader["emp_nombre"]?.ToString() ?? "",
                                EmpDireccion = reader["Emp_Dirección"]?.ToString() ?? "",
                                EmpRUC = reader["emp_ruc"]?.ToString() ?? "",
                                SucursalCodigo = reader["Suc_Codigo"]?.ToString() ?? "",
                                SucursalNombre = reader["suc_nombre"]?.ToString() ?? "",
                                BodCodigo = reader["Bod_codigo"]?.ToString() ?? "",
                                BodNombre = reader["Bod_nombre"]?.ToString() ?? "",
                                DatabaseName = reader["DatabaseName"]?.ToString() ?? "",
                                ServerName = servidor.ServerName
                            });
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error en {servidor.ServerName}: {ex.Message}");
            }

            return datos;
        }

        // ==========================================
        // OBTENER DATOS DE TODOS LOS SERVIDORES
        // ==========================================
        private List<DatosCompletos> ObtenerDatosDeTodosLosServidores()
        {
            var todosLosDatos = new List<DatosCompletos>();

            try
            {
                // ✅ Guardar lista de servidores con Alias
                _servidoresList = ObtenerServidoresDesdeMaster();

                if (_servidoresList == null || _servidoresList.Count == 0)
                {
                    MessageBox.Show("No se encontraron servidores configurados", "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return todosLosDatos;
                }

                foreach (var servidor in _servidoresList)
                {
                    try
                    {
                        var datos = ObtenerDatosDesdeServidor(servidor);
                        todosLosDatos.AddRange(datos);
                        System.Diagnostics.Debug.WriteLine($"✅ {datos.Count} registros de {servidor.ServerName} ({servidor.Alias})");
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine($"❌ Error en {servidor.ServerName}: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener datos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return todosLosDatos;
        }

        // ==========================================
        // CARGAR EMPRESAS (AGRUPADAS POR RUC)
        // ==========================================

        private void CargarEmpresas()
        {
            try
            {
                progressBar.Visible = true;
                progressBar.Style = ProgressBarStyle.Marquee;

                var todosLosDatos = ObtenerDatosDeTodosLosServidores();

                progressBar.Visible = false;

                if (todosLosDatos == null || todosLosDatos.Count == 0)
                {
                    MessageBox.Show("No se encontraron datos en ningún servidor", "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // ✅ DICCIONARIO COMPLETO DE EMPRESAS POR RUC (SIN REPETIDOS)
                var empresasManual = new Dictionary<string, string>
        {
            { "1793066070001", "CASTENI CIA LTDA" },
            { "1793218464001", "NORCAS CIA LTDA" },
            { "1713586673001", "CASTILLO BARRAGAN NORMA ERLINDA" },
            { "1708022437001", "SOSA JUAN FRANCISCO" }
        };

                var empresasDict = new Dictionary<string, EmpresaInfo>();

                foreach (var item in todosLosDatos)
                {
                    // ✅ Usar RUC como clave
                    string claveRUC = item.EmpRUC;

                    if (string.IsNullOrEmpty(claveRUC))
                    {
                        claveRUC = NormalizarNombre(item.EmpNombre);
                    }

                    // ✅ Obtener nombre de empresa desde el diccionario
                    string nombreEmpresa = empresasManual.ContainsKey(claveRUC)
                        ? empresasManual[claveRUC]
                        : item.EmpNombre;

                    if (!empresasDict.ContainsKey(claveRUC))
                    {
                        var empresa = new EmpresaInfo
                        {
                            EmpCodigo = item.EmpCodigo,
                            EmpNombre = nombreEmpresa,
                            EmpRUC = item.EmpRUC,
                            ClaveRUC = claveRUC,
                            Servidores = new List<ServidorInfo>()
                        };
                        empresasDict.Add(claveRUC, empresa);
                    }

                    var empresaExistente = empresasDict[claveRUC];

                    // Buscar servidor por ServerName
                    var servidorExistente = empresaExistente.Servidores
                        .FirstOrDefault(s => s.ServerName == item.ServerName);

                    if (servidorExistente == null)
                    {
                        string alias = "";
                        var servidorInfo = _servidoresList?.FirstOrDefault(s => s.ServerName == item.ServerName);
                        if (servidorInfo != null && !string.IsNullOrEmpty(servidorInfo.Alias))
                        {
                            alias = servidorInfo.Alias;
                        }

                        servidorExistente = new ServidorInfo
                        {
                            ServerName = item.ServerName,
                            Alias = alias,
                            UserId = "api_prod",
                            Password = "ApiProd2026!",
                            Sucursales = new List<SucursalInfo>()
                        };
                        empresaExistente.Servidores.Add(servidorExistente);
                    }

                    // Buscar sucursal dentro del servidor
                    var sucursalExistente = servidorExistente.Sucursales
                        .FirstOrDefault(s => s.SucursalCodigo == item.SucursalCodigo);

                    if (sucursalExistente == null)
                    {
                        sucursalExistente = new SucursalInfo
                        {
                            SucursalCodigo = item.SucursalCodigo,
                            SucursalNombre = item.SucursalNombre,
                            DatabaseName = item.DatabaseName,
                            Bodegas = new List<BodegaInfo>()
                        };
                        servidorExistente.Sucursales.Add(sucursalExistente);
                    }

                    // Agregar bodega a la sucursal
                    if (!sucursalExistente.Bodegas.Any(b => b.BodCodigo == item.BodCodigo))
                    {
                        sucursalExistente.Bodegas.Add(new BodegaInfo
                        {
                            BodCodigo = item.BodCodigo,
                            BodNombre = item.BodNombre
                        });
                    }
                }

                _empresasList = empresasDict.Values.ToList();

                // Llenar combo de empresas
                if (cmbEmpresa != null)
                {
                    cmbEmpresa.Items.Clear();
                    cmbEmpresa.Items.Add("-- Seleccionar Empresa --");
                    foreach (var empresa in _empresasList.OrderBy(e => e.EmpNombre))
                    {
                        cmbEmpresa.Items.Add(empresa);
                    }
                    if (_empresasList.Count > 0)
                        cmbEmpresa.SelectedIndex = 0;

                    cmbEmpresa.Visible = true;
                    cmbEmpresa.Refresh();
                }

                string empresasInfo = string.Join(", ", _empresasList.Select(e => e.EmpNombre));
                lblConexion.Text = $"✅ {_empresasList.Count} empresas: {empresasInfo}";
            }
            catch (Exception ex)
            {
                progressBar.Visible = false;
                MessageBox.Show("Error al cargar empresas: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==========================================
        // NORMALIZAR NOMBRE PARA CLAVE
        // ==========================================
        private string NormalizarNombre(string nombre)
        {
            if (string.IsNullOrEmpty(nombre))
                return nombre;

            // Eliminar espacios múltiples
            nombre = System.Text.RegularExpressions.Regex.Replace(nombre, @"\s+", " ");

            // Normalizar "CIA." a "CIA"
            nombre = nombre.Replace("CIA.", "CIA");
            nombre = nombre.Replace("CIA .", "CIA");
            nombre = nombre.Replace("CIA  ", "CIA");

            // Normalizar "LTDA" con puntos
            nombre = nombre.Replace("LTDA.", "LTDA");
            nombre = nombre.Replace("Ltda.", "LTDA");
            nombre = nombre.Replace("Ltda", "LTDA");

            // Eliminar espacios al inicio y final
            nombre = nombre.Trim();

            // Convertir a mayúsculas
            nombre = nombre.ToUpperInvariant();

            return nombre;
        }

        // ==========================================
        // EVENTO: CAMBIO DE EMPRESA
        // ==========================================
        private void cmbEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEmpresa == null || cmbServidor == null || cmbSucursal == null || cboBodega == null)
                return;

            if (cmbEmpresa.SelectedIndex <= 0)
            {
                LimpiarCombosSecundarios();
                return;
            }

            var empresa = cmbEmpresa.SelectedItem as EmpresaInfo;
            if (empresa == null) return;

            _empresaSeleccionada = empresa.EmpCodigo;

            // ✅ Llenar servidores de la empresa
            cmbServidor.Items.Clear();
            cmbServidor.Items.Add("-- Seleccionar Servidor --");

            foreach (var servidor in empresa.Servidores.OrderBy(s => s.ToString()))
            {
                cmbServidor.Items.Add(servidor);
            }

            cmbServidor.SelectedIndex = 0;

            // Limpiar combos secundarios
            cmbSucursal.Items.Clear();
            cmbSucursal.Items.Add("-- Seleccionar Servidor Primero --");
            cmbSucursal.SelectedIndex = 0;

            if (cboBodega.DataSource != null)
            {
                cboBodega.DataSource = null;
            }
            cboBodega.Items.Clear();
            cboBodega.Items.Add("-- Seleccionar Sucursal Primero --");
            cboBodega.SelectedIndex = 0;
        }

        // ==========================================
        // EVENTO: CAMBIO DE SERVIDOR
        // ==========================================
        private void cmbServidor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbServidor == null || cmbSucursal == null || cboBodega == null)
                return;

            if (cmbServidor.SelectedIndex <= 0)
            {
                cmbSucursal.Items.Clear();
                cmbSucursal.Items.Add("-- Seleccionar Servidor Primero --");
                cmbSucursal.SelectedIndex = 0;

                if (cboBodega.DataSource != null)
                {
                    cboBodega.DataSource = null;
                }
                cboBodega.Items.Clear();
                cboBodega.Items.Add("-- Seleccionar Sucursal Primero --");
                cboBodega.SelectedIndex = 0;
                return;
            }

            var servidor = cmbServidor.SelectedItem as ServidorInfo;
            if (servidor == null) return;

            _servidorSeleccionado = servidor.ServerName;

            // ✅ Llenar sucursales del servidor
            cmbSucursal.Items.Clear();
            cmbSucursal.Items.Add("-- Seleccionar Sucursal --");

            foreach (var sucursal in servidor.Sucursales.OrderBy(s => s.SucursalNombre))
            {
                cmbSucursal.Items.Add(sucursal);
            }

            cmbSucursal.SelectedIndex = 0;

            if (cboBodega.DataSource != null)
            {
                cboBodega.DataSource = null;
            }
            cboBodega.Items.Clear();
            cboBodega.Items.Add("-- Seleccionar Sucursal --");
            cboBodega.SelectedIndex = 0;

            lblConexion.Text = $"🖥️ Servidor: {servidor.ToString()}";
            lblConexion.ForeColor = Color.Blue;
        }

        // ==========================================
        // EVENTO: CAMBIO DE SUCURSAL
        // ==========================================
        private void cmbSucursal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSucursal == null || cboBodega == null)
                return;

            if (cmbSucursal.SelectedIndex <= 0)
            {
                if (cboBodega.DataSource != null)
                {
                    cboBodega.DataSource = null;
                }
                cboBodega.Items.Clear();
                cboBodega.Items.Add("-- Seleccionar Sucursal Primero --");
                cboBodega.SelectedIndex = 0;
                return;
            }

            var sucursal = cmbSucursal.SelectedItem as SucursalInfo;
            if (sucursal == null) return;

            _sucursalSeleccionada = sucursal.SucursalCodigo;

            // ✅ Llenar bodegas de la sucursal
            if (cboBodega.DataSource != null)
            {
                cboBodega.DataSource = null;
            }
            cboBodega.Items.Clear();

            cboBodega.Items.Add("Todas las Bodegas");

            foreach (var bodega in sucursal.Bodegas.OrderBy(b => b.BodNombre))
            {
                cboBodega.Items.Add(bodega);
            }

            cboBodega.SelectedIndex = 0;

            string servidor = cmbServidor.SelectedItem?.ToString() ?? "";
            lblConexion.Text = $"📍 {sucursal.SucursalNombre} ({sucursal.SucursalCodigo}) - {servidor}";
            lblConexion.ForeColor = Color.DarkGreen;
        }

        // ==========================================
        // LIMPIAR COMBOS SECUNDARIOS
        // ==========================================
        private void LimpiarCombosSecundarios()
        {
            if (cmbServidor != null)
            {
                cmbServidor.Items.Clear();
                cmbServidor.Items.Add("-- Seleccionar Empresa Primero --");
                cmbServidor.SelectedIndex = 0;
            }

            if (cmbSucursal != null)
            {
                cmbSucursal.Items.Clear();
                cmbSucursal.Items.Add("-- Seleccionar Servidor Primero --");
                cmbSucursal.SelectedIndex = 0;
            }

            if (cboBodega != null)
            {
                if (cboBodega.DataSource != null)
                {
                    cboBodega.DataSource = null;
                }
                cboBodega.Items.Clear();
                cboBodega.Items.Add("-- Seleccionar Sucursal Primero --");
                cboBodega.SelectedIndex = 0;
            }
        }

        // ==========================================
        // VERIFICAR API
        // ==========================================
        
        private void VerificarApi()
        {
            try
            {
                using (var client = new WebClient())
                {
                    client.Headers[HttpRequestHeader.Accept] = "application/json";
                    var response = client.DownloadString($"{API_URL}/api/Reporte/health");
                    var result = JsonConvert.DeserializeObject<dynamic>(response);

                    if (result != null)
                    {
                        lblApi.Text = "✅ API Conectada";
                        lblApi.ForeColor = Color.Green;
                    }
                }
            }
            catch (Exception ex)
            {
                lblApi.Text = "❌ API Desconectada";
                lblApi.ForeColor = Color.Red;
                System.Diagnostics.Debug.WriteLine($"Error API: {ex.Message}");
            }
        }
        // ==========================================
        // LLENAR COMBOS (Categorías, Clases, etc.)
        // ==========================================
        private void LlenarCombos()
        {
            string ssql = @"SELECT Niv_categor, Niv_nombre, Niv_abrevia FROM 
                           (SELECT 2 AS Niv_categor, 'Todas las categorias' AS Niv_nombre, '0' AS Niv_abrevia, 0 AS Orden 
                            UNION ALL 
                            SELECT Niv_categor, Niv_nombre, Niv_abrevia, 1 AS Orden 
                            FROM AdcNiv WHERE Niv_categor = 1) AS Resultado 
                           ORDER BY Orden, Niv_nombre";
            LlenarCategorias(ssql, cboCategoria, "Todas las categorias", "Niv_nombre", "Niv_abrevia", chkCategoria);

            ssql = @"SELECT Niv_categor, Niv_nombre, Niv_abrevia FROM 
                    (SELECT 2 AS Niv_categor, 'Todas las clases' AS Niv_nombre, '0' AS Niv_abrevia, 0 AS Orden 
                     UNION ALL 
                     SELECT Niv_categor, Niv_nombre, Niv_abrevia, 1 AS Orden 
                     FROM AdcNiv WHERE Niv_categor = 2) AS Resultado 
                    ORDER BY Orden, Niv_nombre";
            LlenarCategorias(ssql, cboClase, "Todas las clases", "Niv_nombre", "Niv_abrevia", chkClase);

            ssql = @"SELECT Niv_categor, Niv_nombre, Niv_abrevia FROM 
                    (SELECT 2 AS Niv_categor, 'Todas los grupos' AS Niv_nombre, '0' AS Niv_abrevia, 0 AS Orden 
                     UNION ALL 
                     SELECT Niv_categor, Niv_nombre, Niv_abrevia, 1 AS Orden 
                     FROM AdcNiv WHERE Niv_categor = 3) AS Resultado 
                    ORDER BY Orden, Niv_nombre";
            LlenarCategorias(ssql, cboGrupo, "Todas los grupos", "Niv_nombre", "Niv_abrevia", chkGrupo);

            ssql = @"SELECT Niv_categor, Niv_nombre, Niv_abrevia FROM 
                    (SELECT 2 AS Niv_categor, 'Todos los subgrupos' AS Niv_nombre, '0' AS Niv_abrevia, 0 AS Orden 
                     UNION ALL 
                     SELECT Niv_categor, Niv_nombre, Niv_abrevia, 1 AS Orden 
                     FROM AdcNiv WHERE Niv_categor = 4) AS Resultado 
                    ORDER BY Orden, Niv_nombre";
            LlenarCategorias(ssql, cboSubg, "Todos los subgrupos", "Niv_nombre", "Niv_abrevia", chkSubg);
        }

        private void LlenarCategorias(string ssql, ComboBox cbo, string op, string nombre, string cod, CheckBox chk)
        {
            try
            {
                DataSet dataSet = new DataSet();
                using (var adapter = new SqlDataAdapter(ssql, VarCom.strConxAdcom))
                {
                    adapter.Fill(dataSet, "Datos");
                }

                cbo.DataSource = dataSet.Tables[0];
                cbo.DisplayMember = nombre;
                cbo.ValueMember = cod;

                if (cbo.Items.Count == 0)
                {
                    cbo.Visible = false;
                    chk.Visible = false;
                    chk.Checked = false;
                }
                else
                {
                    cbo.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en LlenarCategorias: " + ex.Message);
            }
        }

        // ==========================================
        // CONFIGURAR BACKGROUNDWORKER
        // ==========================================
        private void ConfigurarBackgroundWorker()
        {
            _backgroundWorker = new BackgroundWorker();
            _backgroundWorker.WorkerSupportsCancellation = true;
            _backgroundWorker.DoWork += BackgroundWorker_DoWork;
            _backgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;
        }

        // ==========================================
        // BOTONES DE BÚSQUEDA
        // ==========================================
        private void btnCodIni_Click(object sender, EventArgs e)
        {
            txtCodIni.Text = ConsultaArt();
        }

        private void btnCodFin_Click(object sender, EventArgs e)
        {
            txtCodFin.Text = ConsultaArt();
        }

        private string ConsultaArt()
        {
            return "";
        }

        private void btnFecha_Click(object sender, EventArgs e)
        {
            using (DateTimePicker dtp = new DateTimePicker())
            {
                dtp.Value = DateTime.Parse(txtFecha.Text);
                dtp.Format = DateTimePickerFormat.Short;

                Form frm = new Form();
                frm.Controls.Add(dtp);
                frm.Text = "Seleccionar Fecha";
                frm.Size = new Size(250, 100);
                dtp.Dock = DockStyle.Fill;

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    txtFecha.Text = dtp.Value.ToShortDateString();
                }
            }
        }

        // ==========================================
        // OPCIONES DE COSTEO
        // ==========================================
        private void optCostoPro_CheckedChanged(object sender, EventArgs e)
        {
            if (optCostoPro.Checked) { costeo = "P"; NomCosteo = "Promedio"; LimpiarReporte(); }
        }
        private void optPvp1_CheckedChanged(object sender, EventArgs e)
        {
            if (optPvp1.Checked) { costeo = "1"; NomCosteo = "Precio 1"; LimpiarReporte(); }
        }
        private void optPvp2_CheckedChanged(object sender, EventArgs e)
        {
            if (optPvp2.Checked) { costeo = "2"; NomCosteo = "Precio 2"; LimpiarReporte(); }
        }
        private void optPvp3_CheckedChanged(object sender, EventArgs e)
        {
            if (optPvp3.Checked) { costeo = "3"; NomCosteo = "Precio 3"; LimpiarReporte(); }
        }
        private void optPvp4_CheckedChanged(object sender, EventArgs e)
        {
            if (optPvp4.Checked) { costeo = "4"; NomCosteo = "Precio 4"; LimpiarReporte(); }
        }
        private void optPvp5_CheckedChanged(object sender, EventArgs e)
        {
            if (optPvp5.Checked) { costeo = "5"; NomCosteo = "Precio 5"; LimpiarReporte(); }
        }
        private void optUltCost_CheckedChanged(object sender, EventArgs e)
        {
            if (optUltCost.Checked) { costeo = "U"; NomCosteo = "Último Costo"; LimpiarReporte(); }
        }
        private void optSinCost_CheckedChanged(object sender, EventArgs e)
        {
            if (optSinCost.Checked) { costeo = "0"; NomCosteo = ""; LimpiarReporte(); }
        }

        // ==========================================
        // BOTONES DE ACCIÓN
        // ==========================================
        private void btnOpciones_Click(object sender, EventArgs e)
        {
            // ✅ ALTERNAR VISIBILIDAD DEL PANEL
            SplitContainer1.Panel1Collapsed = !SplitContainer1.Panel1Collapsed;

            // ✅ CAMBIAR TEXTO DEL BOTÓN
            if (SplitContainer1.Panel1Collapsed)
            {
                btnOpciones.Text = "► Mostrar Opciones";
                btnOpciones.BackColor = Color.LightGray;
            }
            else
            {
                btnOpciones.Text = "◄ Ocultar Opciones";
                btnOpciones.BackColor = Color.FromArgb(240, 240, 240);
            }
        }

        //private void btnActualizar_Click(object sender, EventArgs e)
        //{
        //    if (_backgroundWorker != null && _backgroundWorker.IsBusy)
        //    {
        //        MessageBox.Show("Espere a que termine la operación actual", "Información",
        //            MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        return;
        //    }

        //    if (cmbEmpresa == null || cmbServidor == null || cmbSucursal == null)
        //    {
        //        MessageBox.Show("Error: Controles no inicializados", "Error",
        //            MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }

        //    if (cmbEmpresa.SelectedIndex <= 0)
        //    {
        //        MessageBox.Show("Seleccione una empresa", "Validación",
        //            MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }

        //    if (cmbServidor.SelectedIndex <= 0)
        //    {
        //        MessageBox.Show("Seleccione un servidor", "Validación",
        //            MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }

        //    if (cmbSucursal.SelectedIndex <= 0)
        //    {
        //        MessageBox.Show("Seleccione una sucursal", "Validación",
        //            MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }

        //    var servidor = cmbServidor.SelectedItem as ServidorInfo;
        //    var sucursal = cmbSucursal.SelectedItem as SucursalInfo;

        //    if (servidor == null || sucursal == null) return;

        //    _bodegaSeleccionada = "";
        //    if (cboBodega != null && cboBodega.SelectedIndex > 0)
        //    {
        //        if (cboBodega.SelectedItem is BodegaInfo bodega)
        //        {
        //            _bodegaSeleccionada = bodega.BodCodigo;
        //        }
        //        else if (cboBodega.SelectedItem is string texto && texto != "Todas las Bodegas")
        //        {
        //            _bodegaSeleccionada = texto;
        //        }
        //    }

        //    LeerOpciones();

        //    titulo = "Catálogo de artículos";
        //    if (!string.IsNullOrEmpty(NomCosteo))
        //    {
        //        titulo = titulo + " valorado por: " + NomCosteo;
        //    }

        //    // ✅ Crear conexión con servidor y sucursal
        //    string connectionString = $"Server={servidor.ServerName};Database={sucursal.DatabaseName};User Id={servidor.UserId};Password={servidor.Password};Connection Timeout=30;";

        //    var parametros = new ReporteParametros
        //    {
        //        SucursalCodigo = sucursal.SucursalCodigo,
        //        FechaSaldo = txtFecha.Text,
        //        Bodega = _bodegaSeleccionada,
        //        Codigo1 = codIni,
        //        Codigo2 = codFin,
        //        Costeo = costeo,
        //        Categoria = categoria,
        //        Clase = clase,
        //        Grupo = grupo,
        //        Subgrupo = subg,
        //        Titulo = titulo,
        //        NomCosteo = NomCosteo,
        //        ConnectionString = connectionString
        //    };

        //    progressBar.Visible = true;
        //    progressBar.Style = ProgressBarStyle.Marquee;
        //    btnActualizar.Enabled = false;

        //    _backgroundWorker.RunWorkerAsync(parametros);
        //}

        // ==========================================
        // BACKGROUNDWORKER - DO WORK
        // ==========================================


        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (_backgroundWorker != null && _backgroundWorker.IsBusy)
            {
                MessageBox.Show("Espere a que termine la operación actual", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (cmbEmpresa == null || cmbServidor == null || cmbSucursal == null)
            {
                MessageBox.Show("Error: Controles no inicializados", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cmbEmpresa.SelectedIndex <= 0)
            {
                MessageBox.Show("Seleccione una empresa", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbServidor.SelectedIndex <= 0)
            {
                MessageBox.Show("Seleccione un servidor", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbSucursal.SelectedIndex <= 0)
            {
                MessageBox.Show("Seleccione una sucursal", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var servidor = cmbServidor.SelectedItem as ServidorInfo;
            var sucursal = cmbSucursal.SelectedItem as SucursalInfo;

            if (servidor == null || sucursal == null) return;

            _bodegaSeleccionada = "";
            if (cboBodega != null && cboBodega.SelectedIndex > 0)
            {
                if (cboBodega.SelectedItem is BodegaInfo bodega)
                {
                    _bodegaSeleccionada = bodega.BodCodigo;
                }
                else if (cboBodega.SelectedItem is string texto && texto != "Todas las Bodegas")
                {
                    _bodegaSeleccionada = texto;
                }
            }

            LeerOpciones();

            titulo = "Catálogo de artículos";
            if (!string.IsNullOrEmpty(NomCosteo))
            {
                titulo = titulo + " valorado por: " + NomCosteo;
            }

            // ✅ Crear conexión con servidor y sucursal
            string connectionString = $"Server={servidor.ServerName};Database={sucursal.DatabaseName};User Id={servidor.UserId};Password={servidor.Password};Connection Timeout=30;";

            // ✅ FECHA EN FORMATO CORRECTO
            string fechaSaldo = "";
            try
            {
                DateTime fecha = DateTime.Parse(txtFecha.Text);
                fechaSaldo = fecha.ToString("yyyy-MM-ddTHH:mm:ss");
            }
            catch
            {
                fechaSaldo = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");
            }

            var parametros = new ReporteParametros
            {
                SucursalCodigo = sucursal.SucursalCodigo,
                FechaSaldo = fechaSaldo,
                Bodega = _bodegaSeleccionada,
                Codigo1 = codIni,
                Codigo2 = codFin,
                Costeo = costeo,
                Categoria = categoria,
                Clase = clase,
                Grupo = grupo,
                Subgrupo = subg,
                Titulo = titulo,
                NomCosteo = NomCosteo,
                ConnectionString = connectionString
            };

            // ✅ DEBUG: Mostrar lo que se va a enviar
            //string debugMsg = $"=== DEBUG REQUEST ===\n" +
            //                  $"Sucursal: {sucursal.SucursalCodigo}\n" +
            //                  $"Servidor: {servidor.ServerName}\n" +
            //                  $"Base de Datos: {sucursal.DatabaseName}\n" +
            //                  $"Fecha: {fechaSaldo}\n" +
            //                  $"Bodega: {_bodegaSeleccionada}\n" +
            //                  $"Costeo: {costeo}\n" +
            //                  $"ConnectionString: {connectionString}";

            //MessageBox.Show(debugMsg, "Debug Request", MessageBoxButtons.OK, MessageBoxIcon.Information);

            progressBar.Visible = true;
            progressBar.Style = ProgressBarStyle.Marquee;
            btnActualizar.Enabled = false;

            _backgroundWorker.RunWorkerAsync(parametros);
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var parametros = e.Argument as ReporteParametros;
                if (parametros == null)
                {
                    throw new Exception("No se recibieron parámetros válidos");
                }

                titulo = parametros.Titulo;
                if (string.IsNullOrEmpty(titulo))
                {
                    titulo = "Catálogo de artículos";
                }

                if (!string.IsNullOrEmpty(parametros.NomCosteo))
                {
                    titulo = titulo + " valorado por: " + parametros.NomCosteo;
                }

                // ✅ VERIFICAR FECHA
                string fechaSaldo = parametros.FechaSaldo;
                if (string.IsNullOrEmpty(fechaSaldo))
                {
                    fechaSaldo = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");
                }

                // ✅ VERIFICAR BODEGA
                string bodega = parametros.Bodega ?? "";

                var request = new
                {
                    fechaSaldo = fechaSaldo,
                    bodega = bodega,
                    codigo1 = parametros.Codigo1 ?? "",
                    codigo2 = parametros.Codigo2 ?? "",
                    saldoCero = 0,
                    costeo = parametros.Costeo ?? "P",
                    soloCategoria = parametros.Categoria ?? "",
                    soloClase = parametros.Clase ?? "",
                    soloGrupo = parametros.Grupo ?? "",
                    soloSubgrupo = parametros.Subgrupo ?? "",
                    soloGuardar = "N"
                };

                // ✅ DEBUG: Mostrar el JSON que se envía
                string jsonRequest = Newtonsoft.Json.JsonConvert.SerializeObject(request);
                System.Diagnostics.Debug.WriteLine($"=== REQUEST JSON ===\n{jsonRequest}");

                var resultado = EjecutarReporteApi(parametros.SucursalCodigo, request, parametros.ConnectionString);
                e.Result = resultado;
            }
            catch (Exception ex)
            {
                e.Result = null;
                throw;
            }
        }

        // ==========================================
        // BACKGROUNDWORKER - COMPLETED
        // ==========================================

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar.Visible = false;
            btnActualizar.Enabled = true;

            if (e.Error != null)
            {
                MessageBox.Show("Error al generar reporte: " + e.Error.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                // ✅ LIMPIAR REPORTE EN CASO DE ERROR
                ReportViewer1.Reset();
                ReportViewer1.Clear();
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.Visible = false;
                ReportViewer1.RefreshReport();
                return;
            }

            var resultado = e.Result as ReporteResponse;
            if (resultado != null && resultado.Success && resultado.Data != null && resultado.Data.Count > 0)
            {
                MostrarReporte(resultado);
            }
            else
            {
                // ✅ LIMPIAR REPORTE SI NO HAY DATOS
                ReportViewer1.Reset();
                ReportViewer1.Clear();
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.Visible = false;
                ReportViewer1.RefreshReport();

                string mensaje = resultado?.Message ?? "No existen valores para visualizar";
                MessageBox.Show(mensaje, "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // ==========================================
        // EJECUTAR REPORTE API
        // ==========================================


        private ReporteResponse EjecutarReporteApi(string sucursalCodigo, object request, string connectionString)
        {
            try
            {
                var requestConConexion = new
                {
                    fechaSaldo = GetPropertyValue(request, "fechaSaldo") ?? DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"),
                    bodega = GetPropertyValue(request, "bodega") ?? "",
                    codigo1 = GetPropertyValue(request, "codigo1") ?? "",
                    codigo2 = GetPropertyValue(request, "codigo2") ?? "",
                    saldoCero = GetPropertyValue(request, "saldoCero") ?? 0,
                    costeo = GetPropertyValue(request, "costeo") ?? "P",
                    soloCategoria = GetPropertyValue(request, "soloCategoria") ?? "",
                    soloClase = GetPropertyValue(request, "soloClase") ?? "",
                    soloGrupo = GetPropertyValue(request, "soloGrupo") ?? "",
                    soloSubgrupo = GetPropertyValue(request, "soloSubgrupo") ?? "",
                    soloGuardar = "N",
                    connectionString = connectionString
                };

                using (var client = new WebClient())
                {
                    client.Headers[HttpRequestHeader.ContentType] = "application/json";
                    client.Headers[HttpRequestHeader.Accept] = "application/json";

                    var json = JsonConvert.SerializeObject(requestConConexion);
                    var url = $"{API_URL}/api/Reporte/por-sucursal/{sucursalCodigo}";

                    System.Diagnostics.Debug.WriteLine($"=== URL ===\n{url}");
                    System.Diagnostics.Debug.WriteLine($"=== JSON ===\n{json}");

                    var response = client.UploadString(url, "POST", json);
                    return JsonConvert.DeserializeObject<ReporteResponse>(response);
                }
            }
            catch (WebException ex)
            {
                string errorMsg = $"Error en la API:\n";
                if (ex.Response != null)
                {
                    using (var reader = new StreamReader(ex.Response.GetResponseStream()))
                    {
                        string responseBody = reader.ReadToEnd();
                        errorMsg += $"Response Body: {responseBody}\n";
                    }
                }
                errorMsg += $"Message: {ex.Message}";

                System.Diagnostics.Debug.WriteLine($"=== ERROR ===\n{errorMsg}");
                throw new Exception(errorMsg);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al ejecutar reporte: {ex.Message}");
            }
        }

        //private ReporteResponse EjecutarReporteApi(string sucursalCodigo, object request, string connectionString)
        //{
        //    try
        //    {
        //        // ✅ CREAR UN NUEVO OBJETO CON TODOS LOS PARÁMETROS + CONEXIÓN
        //        var requestConConexion = new
        //        {
        //            fechaSaldo = GetPropertyValue(request, "fechaSaldo") ?? DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"),
        //            bodega = GetPropertyValue(request, "bodega") ?? "",
        //            codigo1 = GetPropertyValue(request, "codigo1") ?? "",
        //            codigo2 = GetPropertyValue(request, "codigo2") ?? "",
        //            saldoCero = GetPropertyValue(request, "saldoCero") ?? 0,
        //            costeo = GetPropertyValue(request, "costeo") ?? "P",
        //            soloCategoria = GetPropertyValue(request, "soloCategoria") ?? "",
        //            soloClase = GetPropertyValue(request, "soloClase") ?? "",
        //            soloGrupo = GetPropertyValue(request, "soloGrupo") ?? "",
        //            soloSubgrupo = GetPropertyValue(request, "soloSubgrupo") ?? "",
        //            soloGuardar = "N",
        //            connectionString = connectionString
        //        };

        //        using (var client = new WebClient())
        //        {
        //            client.Headers[HttpRequestHeader.ContentType] = "application/json";
        //            client.Headers[HttpRequestHeader.Accept] = "application/json";

        //            var json = JsonConvert.SerializeObject(requestConConexion);
        //            var url = $"{API_URL}/api/Reporte/por-sucursal/{sucursalCodigo}";

        //            System.Diagnostics.Debug.WriteLine($"=== URL ===\n{url}");
        //            System.Diagnostics.Debug.WriteLine($"=== JSON ===\n{json}");

        //            var response = client.UploadString(url, "POST", json);
        //            return JsonConvert.DeserializeObject<ReporteResponse>(response);
        //        }
        //    }
        //    catch (WebException ex)
        //    {
        //        string errorMsg = $"Error en la API:\n";
        //        if (ex.Response != null)
        //        {
        //            using (var reader = new StreamReader(ex.Response.GetResponseStream()))
        //            {
        //                string responseBody = reader.ReadToEnd();
        //                errorMsg += $"Response Body: {responseBody}\n";
        //            }
        //        }
        //        errorMsg += $"Message: {ex.Message}";

        //        System.Diagnostics.Debug.WriteLine($"=== ERROR ===\n{errorMsg}");
        //        throw new Exception(errorMsg);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception($"Error al ejecutar reporte: {ex.Message}");
        //    }
        //}

        // ==========================================
        // MÉTODO AUXILIAR PARA OBTENER PROPIEDADES
        // ==========================================
        private object GetPropertyValue(object obj, string propertyName)
        {
            try
            {
                if (obj == null) return null;
                var prop = obj.GetType().GetProperty(propertyName);
                if (prop == null) return null;
                return prop.GetValue(obj, null);
            }
            catch
            {
                return null;
            }
        }

        // ==========================================
        // MOSTRAR REPORTE
        // ==========================================


        private void MostrarReporte(ReporteResponse resultado)
        {
            try
            {
                // ✅ SI NO HAY DATOS, LIMPIAR COMPLETAMENTE EL REPORTE Y SALIR
                if (resultado == null || resultado.Data == null || resultado.Data.Count == 0)
                {
                    // ✅ LIMPIAR COMPLETAMENTE EL REPORTE
                    ReportViewer1.Reset();
                    ReportViewer1.Clear();
                    ReportViewer1.LocalReport.DataSources.Clear();
                    ReportViewer1.Visible = false;
                    ReportViewer1.RefreshReport();

                    lblConexion.Text = "📊 No hay datos para mostrar";
                    lblConexion.ForeColor = Color.Orange;

                    MessageBox.Show("No existen valores para visualizar", "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // ✅ CONVERTIR RESULTADO A DATATABLE
                DataTable dt = new DataTable();
                dt.Columns.Add("Sucursal", typeof(string));
                dt.Columns.Add("Codigo", typeof(string));
                dt.Columns.Add("Nombre", typeof(string));
                dt.Columns.Add("Maximo", typeof(decimal));
                dt.Columns.Add("Minimo", typeof(decimal));
                dt.Columns.Add("SaldoCantidad", typeof(decimal));
                dt.Columns.Add("SaldoPiezas", typeof(decimal));
                dt.Columns.Add("CostoPromedio", typeof(decimal));
                dt.Columns.Add("ValorUnitario", typeof(decimal));
                dt.Columns.Add("SaldoCosto", typeof(decimal));
                dt.Columns.Add("NomCategoria", typeof(string));
                dt.Columns.Add("NomClase", typeof(string));
                dt.Columns.Add("NomGrupo", typeof(string));
                dt.Columns.Add("NomSubgrupo", typeof(string));
                dt.Columns.Add("Medida", typeof(string));
                dt.Columns.Add("Ubicación", typeof(string));

                foreach (var item in resultado.Data)
                {
                    dt.Rows.Add(
                        item.Sucursal, item.Codigo, item.Nombre, item.Maximo, item.Minimo,
                        item.SaldoCantidad, item.SaldoPiezas, item.CostoPromedio,
                        item.ValorUnitario, item.SaldoCosto, item.NomCategoria,
                        item.NomClase, item.NomGrupo, item.NomSubgrupo,
                        item.Medida, item.Ubicación
                    );
                }

                // ✅ LIMPIAR REPORTVIEWER ANTES DE CARGAR NUEVOS DATOS
                ReportViewer1.Reset();
                ReportViewer1.Clear();
                ReportViewer1.Visible = true;
                ReportViewer1.LocalReport.DataSources.Clear();

                // ✅ AGREGAR DATASOURCE
                ReportDataSource rds = new ReportDataSource("DataSet1", dt);
                ReportViewer1.LocalReport.DataSources.Add(rds);

                // ✅ RUTA DEL REPORTE
                string reportPath = VarCom.pathAppl + @"BinNet\Rep\Catalogo.rdlc";

                // Verificar que el archivo existe
                if (!File.Exists(reportPath))
                {
                    MessageBox.Show($"El archivo de reporte no existe:\n{reportPath}",
                        "Error de Reporte", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                ReportViewer1.LocalReport.ReportPath = reportPath;

                // ✅ PARÁMETROS
                string Ubicacion = chkUbicacion.Checked ? "S" : "N";
                string Piezas = "N";

                string nombreEmpresa = "";
                if (cmbEmpresa != null && cmbEmpresa.SelectedItem is EmpresaInfo empresa)
                {
                    nombreEmpresa = empresa.EmpNombre;
                }

                var parametros = new ReportParameter[]
                {
            new ReportParameter("Empresa", nombreEmpresa ?? ""),
            new ReportParameter("Titulo", titulo ?? "Catálogo de artículos"),
            new ReportParameter("FechaR", txtFecha.Text ?? DateTime.Now.ToShortDateString()),
            new ReportParameter("FechaE", DateTime.Now.ToShortDateString()),
            new ReportParameter("ConCategoria", CCat ?? "N"),
            new ReportParameter("ConClase", CCla ?? "N"),
            new ReportParameter("ConGrupo", CGru ?? "N"),
            new ReportParameter("ConSubgrupo", CSub ?? "N"),
            new ReportParameter("ConAlfabetico", Ordenar ?? "C"),
            new ReportParameter("conUbicación", Ubicacion),
            new ReportParameter("conPiezas", Piezas)
                };

                // ✅ ENVIAR PARÁMETROS Y REFRESCAR
                try
                {
                    ReportViewer1.LocalReport.SetParameters(parametros);
                    ReportViewer1.RefreshReport();
                }
                catch (Exception ex)
                {
                    // Si falla con todos los parámetros, intentar con los básicos
                    var parametrosBasicos = new ReportParameter[]
                    {
                new ReportParameter("Empresa", nombreEmpresa ?? ""),
                new ReportParameter("Titulo", titulo ?? "Catálogo de artículos"),
                new ReportParameter("FechaR", txtFecha.Text ?? DateTime.Now.ToShortDateString()),
                new ReportParameter("FechaE", DateTime.Now.ToShortDateString())
                    };
                    ReportViewer1.LocalReport.SetParameters(parametrosBasicos);
                    ReportViewer1.RefreshReport();
                }

                if (ReportViewer1.CanFocus)
                    ReportViewer1.Focus();

                lblConexion.Text = $"✅ Datos cargados: {resultado.Data.Count} registros";
                lblConexion.ForeColor = Color.Green;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al mostrar reporte:\n\n{ex.Message}",
                    "Error de Reporte", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // ==========================================
        // LEER OPCIONES
        // ==========================================
        private void LeerOpciones()
        {
            bodega = _bodegaSeleccionada;

            Ordenar = Orden.Checked ? "A" : "C";
            codIni = txtCodIni.Text.Trim();
            codFin = txtCodFin.Text.Trim();
            articulosExiten = chkArtExis.Checked ? 1 : 0;

            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    categoria = cboCategoria.SelectedValue?.ToString() ?? "";
                    if (categoria == "0") categoria = "";

                    clase = cboClase.SelectedValue?.ToString() ?? "";
                    if (clase == "0") clase = "";

                    grupo = cboGrupo.SelectedValue?.ToString() ?? "";
                    if (grupo == "0") grupo = "";

                    subg = cboSubg.SelectedValue?.ToString() ?? "";
                    if (subg == "0") subg = "";

                    CCat = chkCategoria.Checked ? "S" : "N";
                    CCla = chkClase.Checked ? "S" : "N";
                    CGru = chkGrupo.Checked ? "S" : "N";
                    CSub = chkSubg.Checked ? "S" : "N";
                }));
            }
            else
            {
                categoria = cboCategoria.SelectedValue?.ToString() ?? "";
                if (categoria == "0") categoria = "";

                clase = cboClase.SelectedValue?.ToString() ?? "";
                if (clase == "0") clase = "";

                grupo = cboGrupo.SelectedValue?.ToString() ?? "";
                if (grupo == "0") grupo = "";

                subg = cboSubg.SelectedValue?.ToString() ?? "";
                if (subg == "0") subg = "";

                CCat = chkCategoria.Checked ? "S" : "N";
                CCla = chkClase.Checked ? "S" : "N";
                CGru = chkGrupo.Checked ? "S" : "N";
                CSub = chkSubg.Checked ? "S" : "N";
            }
        }

        private void LimpiarReporte()
        {
            ReportViewer1.Clear();
        }

        // ==========================================
        // BOTONES: LIMPIAR, SALIR, EXPORTAR
        // ==========================================

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtCodIni.Text = "";
            txtCodFin.Text = "";
            txtMedidas.Text = "";
            cboCategoria.SelectedIndex = 0;
            cboClase.SelectedIndex = 0;
            cboGrupo.SelectedIndex = 0;
            cboSubg.SelectedIndex = 0;
            chkArtExis.Checked = false;
            chkUbicacion.Checked = true;
            Orden.Checked = false;
            optCostoPro.Checked = true;

            if (cmbEmpresa != null) cmbEmpresa.SelectedIndex = 0;

            if (cmbServidor != null)
            {
                cmbServidor.Items.Clear();
                cmbServidor.Items.Add("-- Seleccionar Empresa Primero --");
                cmbServidor.SelectedIndex = 0;
            }

            if (cmbSucursal != null)
            {
                cmbSucursal.Items.Clear();
                cmbSucursal.Items.Add("-- Seleccionar Servidor Primero --");
                cmbSucursal.SelectedIndex = 0;
            }

            if (cboBodega != null)
            {
                if (cboBodega.DataSource != null)
                {
                    cboBodega.DataSource = null;
                }
                cboBodega.Items.Clear();
                cboBodega.Items.Add("-- Seleccionar Sucursal Primero --");
                cboBodega.SelectedIndex = 0;
            }

            _bodegaSeleccionada = "";

            // ✅ LIMPIAR COMPLETAMENTE EL REPORTE
            ReportViewer1.Reset();
            ReportViewer1.Clear();
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.Visible = false;
            ReportViewer1.RefreshReport();

            lblConexion.Text = "✅ Reporte limpiado";
            lblConexion.ForeColor = Color.Gray;
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Función de exportación a Excel en desarrollo", "Información",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ==========================================
        // EVENTO LOAD
        // ==========================================
        private void CatalogoGeneral_Load(object sender, EventArgs e)
        {
            SplitContainer1.Panel1Collapsed = false;
            SplitContainer1.SplitterDistance = 380;

            if (cmbEmpresa != null) cmbEmpresa.Visible = true;
            if (cmbServidor != null) cmbServidor.Visible = true;
            if (cmbSucursal != null) cmbSucursal.Visible = true;
            if (cboBodega != null) cboBodega.Visible = true;
            if (lblEmpresa != null) lblEmpresa.Visible = true;
            if (lblServidor != null) lblServidor.Visible = true;
            if (lblSucursal != null) lblSucursal.Visible = true;
            if (lblBodega != null) lblBodega.Visible = true;

            if (panelOpciones != null) panelOpciones.Refresh();
            if (SplitContainer1 != null) SplitContainer1.Refresh();
        }

        // ==========================================
        // CLASES MODELO
        // ==========================================
        public class ReporteResponse
        {
            public bool Success { get; set; }
            public string Message { get; set; }
            public string SucursalCodigo { get; set; }
            public List<InventarioResultado> Data { get; set; }
            public int TotalRegistros { get; set; }
            public TimeSpan TiempoEjecucion { get; set; }
        }

        public class InventarioResultado
        {
            public string Sucursal { get; set; }
            public string Codigo { get; set; }
            public string Nombre { get; set; }
            public decimal Maximo { get; set; }
            public decimal Minimo { get; set; }
            public decimal SaldoCantidad { get; set; }
            public decimal SaldoPiezas { get; set; }
            public decimal CostoPromedio { get; set; }
            public decimal ValorUnitario { get; set; }
            public decimal SaldoCosto { get; set; }
            public string NomCategoria { get; set; }
            public string NomClase { get; set; }
            public string NomGrupo { get; set; }
            public string NomSubgrupo { get; set; }
            public string Medida { get; set; }
            public string Ubicación { get; set; }
        }

        // ==========================================
        // CLASE PARA PARÁMETROS DEL REPORTE
        // ==========================================
        public class ReporteParametros
        {
            public string SucursalCodigo { get; set; }
            public string FechaSaldo { get; set; }
            public string Bodega { get; set; }
            public string Codigo1 { get; set; }
            public string Codigo2 { get; set; }
            public string Costeo { get; set; }
            public string Categoria { get; set; }
            public string Clase { get; set; }
            public string Grupo { get; set; }
            public string Subgrupo { get; set; }
            public string Titulo { get; set; }
            public string NomCosteo { get; set; }
            public string ConnectionString { get; set; }
        }
    }
}