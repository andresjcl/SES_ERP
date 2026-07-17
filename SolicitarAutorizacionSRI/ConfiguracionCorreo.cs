using System;
using System.Data;
using System.Data.SqlClient;

namespace SolicitudAutSRI
{
    public static class ConfiguracionCorreo
    {
        public static string CorreoDesde { get; private set; }
        public static string Smtp { get; private set; }
        public static string Usuario { get; private set; }
        public static string Clave { get; private set; }
        public static int Puerto { get; private set; }
        public static bool HabilitarSSL { get; private set; }
        public static string TipoCuenta { get; private set; } // "SMTP" o "OUTLOOK"

        private static bool _configuracionCargada = false;

        private static bool _parametroCargado = false;

        public static bool ParametroCargado => _parametroCargado;
        public static byte parametro; // variable para almacenar el valor leído
        private static string _urlSRI;
        public static string UrlSRI => _urlSRI;

        /// <summary>
        /// Carga la configuración de correo desde la tabla CorreoConfig
        /// </summary>
        /// <param name="cadenaConexion">Cadena de conexión a la base de datos</param>
        /// <param name="codEmpresa">Código de la empresa</param>
        /// <returns>True si la configuración se cargó correctamente</returns>
        public static bool CargarConfiguracion(string cadenaConexion, string codEmpresa)
        {
            if (_configuracionCargada)
                return true;

            try
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();

                    // Verificar si existe la tabla CorreoConfig
                    if (!TablaCorreoConfigExiste(conexion))
                    {
                        return false;
                    }

                    // Consultar la tabla CorreoConfig
                    string query = @"
                        SELECT TOP 1 CorreoDesde, Smtp, Usuario, Clave, Puerto, HabilitarSSL, Tipo 
                        FROM CorreoConfig 
                        WHERE EmpresaCodigo = @CodEmpresa";

                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@CodEmpresa", codEmpresa);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                CorreoDesde = reader.GetString(0);
                                Smtp = reader.GetString(1);
                                Usuario = reader.GetString(2);
                                Clave = reader.GetString(3);
                                Puerto = reader.GetInt32(4);
                                HabilitarSSL = reader.GetBoolean(5);
                                TipoCuenta = reader.GetString(6);

                                _configuracionCargada = true;
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error al cargar configuración de correo: {ex.Message}");
                _configuracionCargada = false;
                return false;
            }
        }
        /// <summary>
        /// Verifica si la tabla CorreoConfig existe en la base de datos
        /// </summary>
        private static bool TablaCorreoConfigExiste(SqlConnection conexion)
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

        /// <summary>
        /// Crea la tabla CorreoConfig si no existe
        /// </summary>
        public static bool CrearTablaCorreoConfig(string cadenaConexion)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();

                    string createTableQuery = @"
                        IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'CorreoConfig')
                        BEGIN
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
                            )
                        END";

                    using (SqlCommand cmd = new SqlCommand(createTableQuery, conexion))
                    {
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        public static bool CargarParametroSRI(string cadenaConexion, int codempresa)
        {
            if (_parametroCargado)
                return true;

            try
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();

                    string query = @"SELECT par_ValiSRI, par_UrlSRI 
                             FROM emp_par 
                             WHERE EMP_CODIGO = @codEmpresa";

                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        cmd.Parameters.Add("@codEmpresa", SqlDbType.Int).Value = codempresa;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                parametro = reader.IsDBNull(0) ? (byte)0 : reader.GetByte(0);
                                _urlSRI = reader.IsDBNull(1) ? string.Empty : reader.GetString(1).Trim();

                                _parametroCargado = true;
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            catch
            {
                _parametroCargado = false;
                return false;
            }
        }
    }
}