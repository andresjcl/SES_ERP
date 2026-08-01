using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DattCom
{
    public static class datosEmpresa
    {
        static string val = "1";
        static internal int _codigoEmpresa = 0;
        static internal string _Emp_RUC = "";
        static internal string _Emp_Nombre = "";
        static internal string _Emp_Ciudad = "";
        static internal string _Emp_Dirección = "";
        static internal string _Emp_Telefono_1 = "";
        static internal string _Emp_Email = "";
        static internal string _Emp_Logotipo;
        static internal string _Emp_PathImagenes = "";
        static internal string _Par_RolCodMay = "";
        static internal Int16 _Par_Numerodigitos = 2;
        static internal Int16 _Par_DigitosCostos = 2;
        static internal Int16 _Par_DigitosPrecios = 2;
        static internal string _path_tmpServer = "";
        static internal string _CtaLocalEmail = "";
        static internal string _Par_SucPri = "";
        static internal string _bodPri = "";
        static internal string _Par_SucPriNom = "";
        static internal string _bodPriNom = "";
        static internal bool _Par_CruceDocSucursal = false;
        static internal string _servidor = "";
        static internal string _ClaveBd = "";
        static internal string _UsuarioBd = "";

        static internal int _LongCodDirectorio = 0;
        static internal bool _Emp_Conta = false;
        static internal string _Emp_AgeRet = "";
        static internal string _Emp_ContrBuyEsp = "";
        static internal string _Emp_Regimen = "";
        static internal string _Emp_NombreCom = "";

        static public string auto = "";
        public static string sistema = "";
        public static string suc = "";
        public static string sucNom = "";
        public static string usr = "";
        public static string nombreBaseIvaret = "";
        public static string nombreBaseAdcom = "";
        public static string nombreBaseDaxpro = "";
        public static string strConxDaxpro = "";
        public static string nombreBaseSis = "";

        public static string strConxAdcom6 = "";
        public static string strConIniSis6 = "";
        public static string pathAppl = "";
        public static string pathServer = "";
        public static int Major = 0;
        public static string opcion = "";
        public static string marca = "";

        // ============================================================
        // PROPIEDADES DE LICENCIA
        // ============================================================
        public static int TipoLicencia { get; set; } = 0;
        public static string OpcionesLicencia { get; set; } = "";
        public static string ModulosActivos { get; set; } = "";
        public static string GruposActivos { get; set; } = "";
        public static int MaxUsuarios { get; set; } = 1;
        public static DateTime FechaExpiracion { get; set; } = DateTime.MaxValue;

        static internal int _ambienteEnProduccion = 0;
        static internal string _pathFirmaElectronica = "";
        static internal string _pathCpbGenerados = "";
        static internal string _pathCpbFirmados = "";
        static internal string _pathCpbAutorizados = "";
        static internal string _pathpbNoAutorizados = "";
        static internal string _claveFirma = "";
        static internal string _CorreoDefecto = "";
        static internal string _consumidorFinal = "";
        static internal string _strConxAdcom = "";
        static internal string _strConxIvaret = "";
        static internal string _strConIniSis = "";
        static internal DateTime _ultimoCierre = new DateTime(1900, 1, 1);
        static private string aux = "00000000000000000000000000000000000";

        // ============================================================
        // PROPIEDADES - POSICIONES CORREGIDAS
        // ============================================================

        // ADMINISTRACIÓN (Posición 0)
        static public bool FormasPago
        { get { return ((auto + aux).Substring(0, 1) == val); } }

        // VENTAS (Posición 1)
        static public bool Comercial
        { get { return ((auto + aux).Substring(1, 1) == val); } }

        // BANCOS (Posición 2)
        static public bool Bancos
        { get { return ((auto + aux).Substring(2, 1) == val); } }

        // COMPRAS (Posición 3)
        // No tiene propiedad específica

        // CONTABILIDAD (Posición 4)
        static public bool Contabilidad
        { get { return ((auto + aux).Substring(4, 1) == val); } }

        // SRI (Posición 5) - INCLUYE IVARET Y ANEXO TRANSACCIONAL
        static public bool Ivaret
        { get { return ((auto + aux).Substring(5, 1) == val); } }

        static public bool SRI
        { get { return ((auto + aux).Substring(5, 1) == val); } }

        // DIRECTORIO (Posición 6)
        // No tiene propiedad específica

        // IMPORTACIONES (Posición 7)
        // No tiene propiedad específica

        // INVENTARIOS (Posición 8)
        static public bool Inventario
        { get { return ((auto + aux).Substring(8, 1) == val); } }

        // REPORTES (Posición 10)
        // No tiene propiedad específica

        // CUENTAS CORRIENTES (Posición 9)
        static public bool CtasCorrientes
        { get { return ((auto + aux).Substring(9, 1) == val); } }

        // AYUDAS (Posición 11)
        // No tiene propiedad específica

        // ANEXO TRANSACCIONAL (Posición 12) ← CORREGIDO
        static public bool AnexoTransaccional
        { get { return ((auto + aux).Substring(12, 1) == val); } }

        // OTRAS POSICIONES (Compatibilidad con código existente)
        static public bool RolDePagos
        { get { return ((auto + aux).Substring(6, 1) == val); } }

        static public bool Floricola
        { get { return ((auto + aux).Substring(7, 1) == val); } }

        static public bool DaxTime
        { get { return ((auto + aux).Substring(8, 1) == val); } }

        static public bool ActivosFijos
        { get { return ((auto + aux).Substring(9, 1) == val); } }

        static public bool ControlClientes
        { get { return ((auto + aux).Substring(10, 1) == val); } }

        static public bool ControlMedico
        { get { return ((auto + aux).Substring(11, 1) == val); } }

        static public bool Produccion
        { get { return ((auto + aux).Substring(12, 1) == val); } }

        static public bool Restaurante
        { get { return ((auto + aux).Substring(13, 1) == val); } }

        static public bool Hotel
        { get { return ((auto + aux).Substring(14, 1) == val); } }

        static public bool Gestion
        { get { return ((auto + aux).Substring(15, 1) == val); } }

        static public bool Consultor
        { get { return ((auto + aux).Substring(16, 1) == val); } }

        static public bool CpbtesElectrónicos
        { get { return ((auto + aux).Substring(17, 1) == val); } }

        static public bool PuntoDeVenta
        { get { return ((auto + aux).Substring(19, 1) == val); } }

        static public bool Presupuestos
        { get { return ((auto + aux).Substring(20, 1) == val); } }

        // ============================================================
        // PROPIEDADES EXISTENTES (NO TOCAR)
        // ============================================================
        static public string nomEmpresa
        {
            get { return Emp_Nombre; }
        }

        static public string Servidor
        {
            get { return _servidor; }
            set { _servidor = value; }
        }
        static public string ClaveBd
        {
            get { return _ClaveBd; }
            set { _ClaveBd = value; }
        }
        static public string UsuarioBd
        {
            get { return _UsuarioBd; }
            set { _UsuarioBd = value; }
        }
        static public int Emp_codigo
        {
            get { return _codigoEmpresa; }
            set { _codigoEmpresa = value; }
        }

        static public Int16 codEmpresa
        {
            get { return Convert.ToInt16(_codigoEmpresa); }
            set { _codigoEmpresa = value; }
        }
        static public string Emp_RUC
        {
            get { return _Emp_RUC; }
            set { _Emp_RUC = value; }
        }

        static public string sucursal
        {
            get { return _Par_SucPri; }
        }

        static public string Bodega
        {
            get { return _bodPri; }
        }

        static public string SucursalNombre
        {
            get { return _Par_SucPriNom; }
        }

        static public Boolean PermiteCruceDocSucursal
        {
            get { return _Par_CruceDocSucursal; }
        }

        static public string BodegaNombre
        {
            get { return _bodPriNom; }
        }

        public static readonly string fechaProceso = DateTime.Now.ToShortDateString();
        static public string Emp_Nombre
        {
            get { return _Emp_Nombre; }
        }
        static public string Emp_Ciudad
        {
            get { return _Emp_Ciudad; }
        }
        static public string Emp_Telefono_1
        {
            get { return _Emp_Telefono_1; }
        }

        static public int LongCodDirectorio
        {
            get { return _LongCodDirectorio; }
        }

        static public Boolean Emp_Conta
        {
            get { return _Emp_Conta; }
        }
        static public string Emp_AgeRet
        {
            get { return _Emp_AgeRet; }
        }
        static public string Emp_ContrBuyEsp
        {
            get { return _Emp_ContrBuyEsp; }
        }

        static public string Emp_Regimen
        {
            get { return _Emp_Regimen; }
        }

        static public string Emp_NombreCom
        {
            get { return _Emp_NombreCom; }
        }

        static public string Emp_Email
        {
            get { return _Emp_Email; }
        }

        static public string Emp_Logotipo
        {
            get { return _Emp_Logotipo; }
        }

        static public string Emp_PathImagenes
        {
            get { return _Emp_PathImagenes; }
        }

        static public DateTime UltimoCierreAnual
        { get { return _ultimoCierre; } }

        static public string Par_RolCodMay
        {
            get { return _Par_RolCodMay; }
        }

        static public DateTime FechaLimiteDocumentos
        {
            get
            {
                DateTime fecha = new DateTime(1900, 1, 1);
                try
                {
                    if (!string.IsNullOrEmpty(_Par_RolCodMay))
                    {
                        if (DateTime.TryParseExact(_Par_RolCodMay, "dd/MM/yyyy",
                            CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fechaParseada))
                        {
                            fecha = fechaParseada;
                        }
                        else
                        {
                            string[] formatos = { "dd/MM/yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "dd-MM-yyyy" };
                            if (DateTime.TryParseExact(_Par_RolCodMay, formatos,
                                CultureInfo.InvariantCulture, DateTimeStyles.None, out fechaParseada))
                            {
                                fecha = fechaParseada;
                            }
                        }
                    }
                }
                catch (Exception)
                {
                }
                return fecha;
            }
        }

        static public Int16 Par_Numerodigitos
        {
            get { return _Par_Numerodigitos; }
        }

        static public Int16 Par_DigitosCostos
        {
            get { return _Par_DigitosCostos; }
        }

        static public Int16 Par_DigitosPrecios
        {
            get { return _Par_DigitosPrecios; }
        }

        static public string path_tmpServer
        {
            get { return _path_tmpServer; }
        }

        static public string Emp_Dirección
        {
            get { return _Emp_Dirección; }
        }

        static public string CtaLocalEmail
        {
            get { return _CtaLocalEmail; }
        }

        static public int ambienteEnProduccion
        {
            get { return _ambienteEnProduccion; }
        }

        static public string pathFirmaElectronica
        {
            get { return _pathFirmaElectronica; }
        }

        static public string pathCpbGenerados
        {
            get { return _pathCpbGenerados; }
        }

        static public string pathCpbFirmados
        {
            get { return _pathCpbFirmados; }
        }

        static public string pathCpbAutorizados
        {
            get { return _pathCpbAutorizados; }
        }

        static public string pathpbNoAutorizados
        {
            get { return _pathpbNoAutorizados; }
        }

        static public string claveFirma
        {
            get { return _claveFirma; }
        }
        static public string CorreoDefecto
        {
            get { return _CorreoDefecto; }
        }

        static public string consumidorFinal
        {
            get { return _consumidorFinal; }
        }

        static public string strConxAdcom
        {
            get { return _strConxAdcom; }
        }

        static public string strConxIvaret
        {
            get { return _strConxIvaret; }
        }

        static public string strConIniSis
        {
            get { return _strConIniSis; }
            set { _strConIniSis = value; }
        }

        static public string strConxSyscod
        { get { return strConIniSis; } }

        // ============================================================
        // MÉTODOS
        // ============================================================
        public static DataTable leeParametrosEmp(string camposSelect)
        {
            DataTable dt = new DataTable();
            try
            {
                String ssql = "Select " + camposSelect + " from DaxDatEmp where Emp_Codigo = @codEmp and Suc_Codigo = @codSuc ";
                using (SqlDataAdapter da = new SqlDataAdapter(ssql, strConxAdcom))
                {
                    da.SelectCommand.Parameters.AddWithValue("@codEmp", Emp_codigo.ToString());
                    da.SelectCommand.Parameters.AddWithValue("@codSuc", sucursal.ToString());
                    da.Fill(dt);
                }
            }
            catch (Exception ex) { string a = ex.Message; }
            return dt;
        }

        public static bool TienePermiso(string claveModulo)
        {
            if (usr.ToUpper() == "ADMINISTRADOR" || usr.ToUpper() == "ADMIN")
                return true;

            if (TipoLicencia == 1)
                return true;

            if (TipoLicencia == 98 || TipoLicencia >= 99)
            {
                int posicion = ObtenerPosicionModulo(claveModulo);

                if (posicion >= 0 && posicion < ModulosActivos.Length)
                {
                    return ModulosActivos[posicion] == '1';
                }
            }

            return false;
        }

        private static int ObtenerPosicionModulo(string claveModulo)
        {
            // MAPEO FIJO (DEBE COINCIDIR CON EL GENERADOR)
            var mapaClaves = new Dictionary<string, int>()
            {
                // ADMINISTRACIÓN (Posición 0)
                {"MntDocumentos", 0},
                {"MntServiciosBco", 0},
                {"MntServiciosCprasVta", 0},
                {"MtnUsers", 0},
                {"MtnEmpresa", 0},
                {"MntFormaPago", 0},
                {"Auditoria", 0},
                
                // VENTAS (Posición 1)
                {"PEDEmitir", 1},
                {"FACEmitirPed", 1},
                {"FACEmitir", 1},
                {"FACEmitirPto", 1},
                {"ProfEmitir", 1},
                
                // COMPRAS (Posición 2)
                {"FAPEmitir", 2},
                {"NCPEmitir", 2},
                
                // INVENTARIOS (Posición 3)
                {"MntArticulos", 3},
                {"IngInventario", 3},
                {"EgrInventario", 3},
                {"MovtArticulos", 3},
                {"ExisBod", 3},
                {"MntMedidas", 3},
                {"Recostear", 3},
                {"TransferenciaInventarios", 3},
                {"REMEmitir", 3},
                
                // BANCOS (Posición 4)
                {"DocBancos", 4},
                {"MnConciliacionBancos", 4},
                {"MnCrearBancos", 4},
                
                // SRI (Posición 5)
                {"SolicAutorizaSRI", 5},
                {"RTPEmitir", 5},
                {"RTCEmitir", 5},
                {"MntTablasSRI", 5},
                {"importarXML", 5},
                
                // DIRECTORIO (Posición 6)
                {"DGRegistros", 6},
                {"DGReporteG", 6},
                
                // IMPORTACIONES (Posición 7)
                {"IMPEmitir", 7},
                
                // REPORTES (Posición 8)
                {"RepListadoDoc", 8},
                
                // CUENTAS CORRIENTES (Posición 9)
                {"CtaCorrListaGen", 9},
                {"CtaCorrAnalisInd", 9},
                
                // CONTABILIDAD (Posición 10)
                {"mnplanCuentas", 10},
                {"MntBalances", 10},
                
                // AYUDAS (Posición 11)
                {"importarDataCli", 11},
                {"importarDataCuentas", 11},
                {"importarDataProd", 11},
                
                // ANEXO TRANSACCIONAL (Posición 12)
                {"AnexoTransaccional", 12},
            };

            if (mapaClaves.ContainsKey(claveModulo))
                return mapaClaves[claveModulo];

            return -1;
        }


        public static void CargarLicenciaActiva()
        {
            try
            {
                if (string.IsNullOrEmpty(Emp_RUC))
                    return;

                string ruc = Emp_RUC;
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

                using (var conn = new SqlConnection(strConxSyscod))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@RucEmpresa", ruc);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                TipoLicencia = Convert.ToInt32(reader["TipoLicencia"]);
                                MaxUsuarios = Convert.ToInt32(reader["MaxUsuarios"]);
                                FechaExpiracion = Convert.ToDateTime(reader["FechaExpiracion"]);
                                ModulosActivos = reader["ModulosActivos"].ToString();
                                GruposActivos = reader["GruposActivos"].ToString();

                                // ============================================================
                                // ⭐ IMPORTANTE: ASIGNAR auto CON LOS MÓDULOS ACTIVOS
                                // ============================================================
                                auto = ModulosActivos;

                                System.Diagnostics.Debug.WriteLine($"✅ Licencia cargada en datosEmpresa");
                                System.Diagnostics.Debug.WriteLine($"📌 auto: {auto}");
                                System.Diagnostics.Debug.WriteLine($"📌 AnexoTransaccional: {AnexoTransaccional}");
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
    }
}