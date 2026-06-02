using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

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

		private static bool _configuracionCargada = false;

		private static bool _parametroCargado = false;



		public static bool ParametroCargado => _parametroCargado;
		public static byte parametro; // variable para almacenar el valor leído
		private static string _urlSRI;
		private static string _parUrlSRI;
		public static string UrlSRI => _urlSRI;

		//public static void CargarConfiguracion(string cadenaConexion)
		//{
		//	if (_configuracionCargada) return;

		//	using (SqlConnection conexion = new SqlConnection(cadenaConexion))
		//	{
		//		conexion.Open();
		//		string query = "SELECT sys4, valor FROM sysopc WHERE sys3 = 'mail'";

		//		using (SqlCommand cmd = new SqlCommand(query, conexion))
		//		using (SqlDataReader reader = cmd.ExecuteReader())
		//		{
		//			while (reader.Read())
		//			{
		//				string claveCampo = reader.GetString(0).Trim().ToLower();
		//				string valorCampo = reader.GetString(1).Trim();

		//				switch (claveCampo)
		//				{
		//					case "correo": CorreoDesde = valorCampo; break;
		//					case "smtp": Smtp = valorCampo; break;
		//					case "user": Usuario = valorCampo; break;
		//					case "clave": Clave = valorCampo; break;
		//					case "puerto": int.TryParse(valorCampo, out int puerto); Puerto = puerto; break;
		//					case "ssl": HabilitarSSL = (valorCampo.ToUpper() == "S"); break;
		//				}
		//			}
		//		}
		//	}

		//	_configuracionCargada = true;
		//}

		public static bool CargarConfiguracion(string cadenaConexion)
		{
			if (_configuracionCargada)
				return true;

			bool datosEncontrados = false;

			try
			{
				using (SqlConnection conexion = new SqlConnection(cadenaConexion))
				{
					conexion.Open();
					string query = "SELECT sys4, valor FROM sysopc WHERE sys3 = 'mail'";

					using (SqlCommand cmd = new SqlCommand(query, conexion))
					using (SqlDataReader reader = cmd.ExecuteReader())
					{
						while (reader.Read())
						{
							datosEncontrados = true;

							string claveCampo = reader.GetString(0).Trim().ToLower();
							string valorCampo = reader.GetString(1).Trim();

							switch (claveCampo)
							{
								case "correo": CorreoDesde = valorCampo; break;
								case "smtp": Smtp = valorCampo; break;
								case "user": Usuario = valorCampo; break;
								case "clave": Clave = valorCampo; break;
								case "puerto":
									if (int.TryParse(valorCampo, out int puerto))
										Puerto = puerto;
									break;
								case "ssl":
									HabilitarSSL = valorCampo.Equals("S", StringComparison.OrdinalIgnoreCase);
									break;
							}
						}
					}
				}

				// Validación mínima
				if (!datosEncontrados || string.IsNullOrEmpty(Smtp) || string.IsNullOrEmpty(CorreoDesde))
					return false;

				_configuracionCargada = true;
				return true;
			}
			catch
			{
				_configuracionCargada = false;
				return false;
			}
		}


		//public static void CargarParametroSRI(string cadenaConexion, int codempresa)
		//{
		//	if (_parametroCargado) return;

		//	using (SqlConnection conexion = new SqlConnection(cadenaConexion))
		//	{
		//		conexion.Open();

		//		string query = "SELECT par_ValiSRI,par_UrlSRI FROM emp_par WHERE EMP_CODIGO = @codEmpresa";

		//		using (SqlCommand cmd = new SqlCommand(query, conexion))
		//		{
		//			cmd.Parameters.AddWithValue("@codEmpresa", codempresa);

		//			using (SqlDataReader reader = cmd.ExecuteReader())
		//			{
		//				if (reader.Read())
		//				{
		//					// par_ValiSRI es tinyint
		//					parametro = reader.IsDBNull(0) ? (byte)0 : reader.GetByte(0);

		//					// par_UrlSRI es VARCHAR(80)
		//					_urlSRI = reader.IsDBNull(1) ? string.Empty : reader.GetString(1).Trim();
		//				}
		//			}
		//		}
		//	}

		//	_parametroCargado = true;
		//}


		public static bool CargarParametroSRI(string cadenaConexion, int codempresa)
		{
			if (_parametroCargado)
				return true;

			try
			{
				bool datosEncontrados = false;

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
								datosEncontrados = true;

								// par_ValiSRI es tinyint
								parametro = reader.IsDBNull(0) ? (byte)0 : reader.GetByte(0);

								// par_UrlSRI es VARCHAR(80)
								_urlSRI = reader.IsDBNull(1) ? string.Empty : reader.GetString(1).Trim();
							}
						}
					}
				}

				// Validación mínima
				if (!datosEncontrados)
					return false;

				_parametroCargado = true;
				return true;
			}
			catch
			{
				_parametroCargado = false;
				return false;
			}
		}



	}


}
