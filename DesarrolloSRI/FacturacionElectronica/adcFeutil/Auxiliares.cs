using DattCom;
using IvaRett;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;

namespace DaxDocElectronicos
{
    public class Auxiliares
    {

		//public ResultadoCpbtFac EjecutarProcedimientoCabeceraYDetalle(int id, string sucursal, string tipoDoc, decimal numero)
		//{
		//	var resultado = new ResultadoCpbtFac();
		//	resultado.Detalles = new List<DetalleCpbtFac>();

		//	using (var conn = new SqlConnection(datosEmpresa.strConxAdcom))
		//	{
		//		var cmd = new SqlCommand("ses_CpbtFac", conn);
		//		cmd.CommandType = CommandType.StoredProcedure;

		//		cmd.Parameters.AddWithValue("@idclavedoc", id);
		//		cmd.Parameters.AddWithValue("@docsuc", sucursal);
		//		cmd.Parameters.AddWithValue("@doctip", tipoDoc);
		//		cmd.Parameters.AddWithValue("@numero", numero);

		//		conn.Open();

		//		using (var reader = cmd.ExecuteReader())
		//		{
		//			bool isFirstRow = true;

		//			while (reader.Read())
		//			{
		//				if (isFirstRow)
		//				{
		//					resultado._Doc_TipoDoc = reader["Doc_TipoDoc"].ToString();
		//					resultado._Opc_documento = reader["Opc_documento"].ToString();
		//					resultado._Doc_numero = Convert.ToInt32(reader["Doc_numero"]);
		//					resultado._Doc_sucursal = reader["Doc_sucursal"].ToString();
		//					resultado._Doc_fecha = Convert.ToDateTime(reader["Doc_fecha"]);									
		//					resultado._Doc_totciva = Convert.ToDouble(reader["Doc_totciva"]);
		//					resultado._Doc_totsiva = Convert.ToDouble(reader["Doc_totsiva"]);
		//					resultado._subtotal = Convert.ToDouble(reader["subtotal"]);
		//					resultado._totalDescuento = Convert.ToDouble(reader["totDescUnitario"]);
		//					resultado._Doc_valor = Convert.ToDouble(reader["Doc_valor"]);
		//					resultado._Doc_NombreImp = reader["Doc_NombreImp"].ToString();
		//					resultado._Doc_NumSop = reader["Doc_NumSop"].ToString();
		//					resultado._doc_detalle = reader["doc_detalle"].ToString();
		//					resultado._tipEmision = reader["tipEmision"].ToString();
		//					if (reader["fechaAutorizacion"] != DBNull.Value && !string.IsNullOrWhiteSpace(reader["fechaAutorizacion"].ToString()))
		//					{
		//						resultado._fechaAutorizacion = Convert.ToDateTime(reader["fechaAutorizacion"]);
		//					}
		//					else
		//					{
		//						resultado._fechaAutorizacion = null; // o DateTime.MinValue, según tu lógica
		//					}

		//					if (reader["Doc_porceniva"] != DBNull.Value)
		//					{
		//						resultado._Doc_porceniva = Convert.ToDecimal(reader["Doc_porceniva"]);
		//					}
		//					else
		//					{
		//						resultado._Doc_porceniva = 0;
		//					}

		//					resultado._NroAutorizacionSri = reader["NroAutorizacionSri"].ToString();
		//					resultado._guiaRemision = reader["guiaRemision"].ToString();
		//					resultado._PreEntrada = reader["PreEntrada"].ToString();
		//					resultado._Idclavedoc = Convert.ToInt32(reader["Idclavedoc"]);
		//					resultado._tipAmbiente = reader["tipAmbiente"].ToString();
		//					resultado._Doc_CiRuc = reader["Doc_CiRuc"].ToString();
		//					resultado._Doc_Direccion = reader["Doc_Direccion"].ToString();
		//					resultado._Doc_Telefono1 = reader["Doc_Telefono1"].ToString();
		//					resultado._Doc_NroIdDoc = reader["Doc_NroIdDoc"].ToString();
		//					resultado._Adi_TipoDocSri = reader["Adi_TipoDocSri"].ToString();
		//					resultado._claveAcceso = reader["claveAcceso"].ToString();
		//					resultado._TipoIdentificacion = reader["TipoIdentificacion"].ToString();
		//					resultado._CorreoElectrónico = reader["CorreoElectrónico"].ToString();							
		//					resultado._Tra_NroLote = reader["Tra_NroLote"].ToString();
		//					resultado._AuxVar1 = reader["AuxVar1"].ToString();							
		//					resultado._totDescUnitario = Convert.ToDouble(reader["totDescUnitario"].ToString());				
		//					isFirstRow = false;
		//				}

		//				// ✅ Detalle: se llena en cada fila
		//				resultado.Detalles.Add(new DetalleCpbtFac
		//				{
		//					_Tra_Codigo = reader["Tra_Codigo"].ToString(),
		//					_Tra_nombre = reader["Tra_nombre"].ToString(),
		//					_Tra_cantidad = Convert.ToDecimal(reader["Tra_cantidad"]),
		//					_Tra_precuni = Convert.ToDecimal(reader["Tra_precuni"]),
		//					_Tra_prectot = Convert.ToDecimal(reader["Tra_prectot"]),
		//					_desctoUni = Convert.ToDecimal(reader["desctoUni"]),
		//					_Tra_porcendes = Convert.ToDecimal(reader["Tra_porcendes"]),
		//					//_Tra_porceniva = reader["Tra_porceniva"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["Tra_porceniva"]),
		//					_Tra_porceniva = reader["Tra_porceniva"] != DBNull.Value? Convert.ToDecimal(reader["Tra_porceniva"]): resultado._Doc_porceniva,
		//					_Tra_valoriva = reader["Tra_valoriva"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["Tra_valoriva"])
		//				});
		//			}
		//		}
		//	}
		//	CalcularBases(resultado);

		//	return resultado;
		//}

		public ResultadoCpbtFac EjecutarProcedimientoCabeceraYDetalle(int id, string sucursal, string tipoDoc, decimal numero)
		{
			var resultado = new ResultadoCpbtFac();
			resultado.Detalles = new List<DetalleCpbtFac>();

			using (var conn = new SqlConnection(datosEmpresa.strConxAdcom))
			{
				var cmd = new SqlCommand("ses_CpbtFac", conn);
				cmd.CommandType = CommandType.StoredProcedure;

				cmd.Parameters.AddWithValue("@idclavedoc", id);
				cmd.Parameters.AddWithValue("@docsuc", sucursal);
				cmd.Parameters.AddWithValue("@doctip", tipoDoc);
				cmd.Parameters.AddWithValue("@numero", numero);

				conn.Open();

				using (var reader = cmd.ExecuteReader())
				{
					bool isFirstRow = true;

					while (reader.Read())
					{
						if (isFirstRow)
						{
							// ✅ MÉTODO AUXILIAR PARA OBTENER VALORES SEGUROS
							resultado._Doc_TipoDoc = ObtenerValor<string>(reader, "Doc_TipoDoc", "");
							resultado._Opc_documento = ObtenerValor<string>(reader, "Opc_documento", "");
							resultado._Doc_numero = ObtenerValor<int>(reader, "Doc_numero", 0);
							resultado._Doc_sucursal = ObtenerValor<string>(reader, "Doc_sucursal", "");
							resultado._Doc_fecha = ObtenerValor<DateTime>(reader, "Doc_fecha", DateTime.Now);
							resultado._Doc_totciva = ObtenerValor<double>(reader, "Doc_totciva", 0);
							resultado._Doc_totsiva = ObtenerValor<double>(reader, "Doc_totsiva", 0);
							resultado._subtotal = ObtenerValor<double>(reader, "subtotal", 0);
							resultado._totalDescuento = ObtenerValor<double>(reader, "totDescUnitario", 0);
							resultado._Doc_valor = ObtenerValor<double>(reader, "Doc_valor", 0);
							resultado._Doc_NombreImp = ObtenerValor<string>(reader, "Doc_NombreImp", "");
							resultado._Doc_NumSop = ObtenerValor<string>(reader, "Doc_NumSop", "");
							resultado._doc_detalle = ObtenerValor<string>(reader, "doc_detalle", "");
							resultado._tipEmision = ObtenerValor<string>(reader, "tipEmision", "");

							// ✅ FECHA CON MANEJO DE NULL
							resultado._fechaAutorizacion = ObtenerValor<DateTime?>(reader, "fechaAutorizacion", null);

							resultado._Doc_porceniva = ObtenerValor<decimal>(reader, "Doc_porceniva", 0);
							resultado._NroAutorizacionSri = ObtenerValor<string>(reader, "NroAutorizacionSri", "");
							resultado._guiaRemision = ObtenerValor<string>(reader, "guiaRemision", "");
							resultado._PreEntrada = ObtenerValor<string>(reader, "PreEntrada", "");
							resultado._Idclavedoc = ObtenerValor<int>(reader, "Idclavedoc", 0);
							resultado._tipAmbiente = ObtenerValor<string>(reader, "tipAmbiente", "");
							resultado._Doc_CiRuc = ObtenerValor<string>(reader, "Doc_CiRuc", "");
							resultado._Doc_Direccion = ObtenerValor<string>(reader, "Doc_Direccion", "");
							resultado._Doc_Telefono1 = ObtenerValor<string>(reader, "Doc_Telefono1", "");
							resultado._Doc_NroIdDoc = ObtenerValor<string>(reader, "Doc_NroIdDoc", "");
							resultado._Adi_TipoDocSri = ObtenerValor<string>(reader, "Adi_TipoDocSri", "");
							resultado._claveAcceso = ObtenerValor<string>(reader, "claveAcceso", "");
							resultado._TipoIdentificacion = ObtenerValor<string>(reader, "TipoIdentificacion", "");
							resultado._CorreoElectrónico = ObtenerValor<string>(reader, "CorreoElectrónico", "");
							resultado._Tra_NroLote = ObtenerValor<string>(reader, "Tra_NroLote", "");
							resultado._AuxVar1 = ObtenerValor<string>(reader, "AuxVar1", "");
							resultado._totDescUnitario = ObtenerValor<double>(reader, "totDescUnitario", 0);

							isFirstRow = false;
						}

						// ✅ DETALLE CON MANEJO DE DBNull
						resultado.Detalles.Add(new DetalleCpbtFac
						{
							_Tra_Codigo = ObtenerValor<string>(reader, "Tra_Codigo", ""),
							_Tra_nombre = ObtenerValor<string>(reader, "Tra_nombre", ""),
							_Tra_cantidad = ObtenerValor<decimal>(reader, "Tra_cantidad", 0),
							_Tra_precuni = ObtenerValor<decimal>(reader, "Tra_precuni", 0),
							_Tra_prectot = ObtenerValor<decimal>(reader, "Tra_prectot", 0),
							_desctoUni = ObtenerValor<decimal>(reader, "desctoUni", 0),
							_Tra_porcendes = ObtenerValor<decimal>(reader, "Tra_porcendes", 0),
							_Tra_porceniva = ObtenerValor<decimal>(reader, "Tra_porceniva", resultado._Doc_porceniva),
							_Tra_valoriva = ObtenerValor<decimal>(reader, "Tra_valoriva", 0)
						});
					}
				}
			}

			CalcularBases(resultado);
			return resultado;
		}

		// ============================================
		// ✅ MÉTODO AUXILIAR PARA OBTENER VALORES SEGUROS
		// ============================================
		private T ObtenerValor<T>(SqlDataReader reader, string nombreColumna, T valorDefecto)
		{
			try
			{
				object valor = reader[nombreColumna];
				if (valor == null || valor == DBNull.Value)
					return valorDefecto;

				// Manejar tipos anulables
				Type tipoDestino = typeof(T);
				if (tipoDestino.IsGenericType && tipoDestino.GetGenericTypeDefinition() == typeof(Nullable<>))
				{
					tipoDestino = Nullable.GetUnderlyingType(tipoDestino);
				}

				if (tipoDestino == typeof(string))
					return (T)(object)valor.ToString();

				if (tipoDestino == typeof(decimal))
					return (T)Convert.ChangeType(Convert.ToDecimal(valor), tipoDestino);

				if (tipoDestino == typeof(double))
					return (T)Convert.ChangeType(Convert.ToDouble(valor), tipoDestino);

				if (tipoDestino == typeof(int))
					return (T)Convert.ChangeType(Convert.ToInt32(valor), tipoDestino);

				if (tipoDestino == typeof(DateTime))
					return (T)Convert.ChangeType(Convert.ToDateTime(valor), tipoDestino);

				if (tipoDestino == typeof(bool))
					return (T)Convert.ChangeType(Convert.ToBoolean(valor), tipoDestino);

				return (T)Convert.ChangeType(valor, tipoDestino);
			}
			catch
			{
				return valorDefecto;
			}
		}

		public class ResultadoCpbtFac
		{
			public string _Doc_TipoDoc { get; set; }
			public string _Opc_documento { get; set; }
			public int _Doc_numero { get; set; }

			public string _Doc_sucursal { get; set; }
			public DateTime _Doc_fecha { get; set; }
			
			public double _Doc_valoriva { get; set; }
			public double _Doc_totciva { get; set; }
			public double _Doc_totsiva { get; set; }
			public double _subtotal { get; set; }
			public double _totalDescuento { get; set; }

			public decimal _Doc_porceniva { get; set; }
			public double _Doc_valor { get; set; }
			public string _Doc_NombreImp { get; set; }
			public string _Doc_NumSop { get; set; }
			public string _doc_detalle { get; set; }
			public string _tipEmision { get; set; }
			public DateTime? _fechaAutorizacion { get; set; }
			public string _NroAutorizacionSri { get; set; }
			public string _guiaRemision { get; set; }
			public string _PreEntrada { get; set; }
			public int _Idclavedoc { get; set; }
			public string _tipAmbiente { get; set; }
			public string _Doc_CiRuc { get; set; }
			public string _Doc_Direccion { get; set; }
			public string _Doc_Telefono1 { get; set; }
			public string _Doc_NroIdDoc { get; set; }
			public string _Adi_TipoDocSri { get; set; }
			public string _claveAcceso { get; set; }
			public string _TipoIdentificacion { get; set; }
			public string _CorreoElectrónico { get; set; }			
			public string _Tra_NroLote { get; set; }
			public string _AuxVar1 { get; set; }
			public string _Pag_Descripcion { get; set; }
			public string _Pag_Cuotas { get; set; }
			public string _Pag_Autoriza { get; set; }

			public double _totDescUnitario { get; set; }
			public double _Base5 { get; set; }
			public double _Base15 { get; set; }
			public double _Iva5 { get; set; }
			public double _Iva15 { get; set; }
			public List<DetalleCpbtFac> Detalles { get; set; }
		}

		public List<DetalleCpbtFac> Detalles { get; set; }

		public class DetalleCpbtFac
		{
			public string _Tra_Codigo { get; set; }
			public decimal _Tra_cantidad { get; set; }
			public string _Tra_nombre { get; set; }
			public decimal _Tra_precuni { get; set; }
			public decimal _desctoUni { get; set; }
			public decimal _Tra_prectot { get; set; }
			public decimal _Tra_porcendes { get; set; }
			public decimal _Tra_porceniva { get; set; }
			public decimal _Tra_valoriva { get; set; }
		}


		public string ObtenerCorreoDesdeIdentificacion(string queCodigoCliente)
		{
			string correo = "";

			try
			{
				using (SqlConnection conexion = new SqlConnection(datosEmpresa.strConxAdcom))
				{
					conexion.Open();
					string query = "SELECT CorreoElectrónico FROM Identificacion WHERE codigo = @CodPer";

					using (SqlCommand cmd = new SqlCommand(query, conexion))
					{
						cmd.Parameters.AddWithValue("@CodPer", queCodigoCliente);

						using (SqlDataReader reader = cmd.ExecuteReader())
						{
							if (reader.Read())
							{
								correo = reader["CorreoElectrónico"].ToString().Trim();
							}
						}
					}
				}
			}
			catch (Exception)
			{
				// Puedes loguear el error si deseas
				correo = "";
			}

			return correo;
		}

		public class IvaInfo
		{
			public decimal Porcentaje { get; set; } // Ej: 5, 12, 15
			public decimal Subtotal { get; set; }   // Base imponible
			public decimal Iva { get; set; }        // Valor del IVA
		}

		public PagoDocumento ObtenerPrimerPago(string bdivaret, string sucursal, string tipoDoc, double numero)
		{
			PagoDocumento pago = null;

			using (SqlConnection cn = new SqlConnection(datosEmpresa.strConxAdcom))
			{
				using (SqlCommand cmd = new SqlCommand("DAX_LEEPAGO", cn))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.AddWithValue("@nombreIvaret", bdivaret);
					cmd.Parameters.AddWithValue("@sucursal", sucursal);
					cmd.Parameters.AddWithValue("@tipoDoc", tipoDoc);
					cmd.Parameters.AddWithValue("@idClaveDoc", numero);

					cn.Open();

					using (SqlDataReader dr = cmd.ExecuteReader())
					{
						if (dr.Read()) // SOLO EL PRIMERO
						{
							pago = new PagoDocumento()
							{
								Doc_sucursal = dr["Doc_sucursal"].ToString(),
								Opc_documento = dr["Opc_documento"].ToString(),
								Doc_numero = Convert.ToInt32(dr["Doc_numero"]),
								Pag_Numero = Convert.ToInt32(dr["Pag_Numero"]),
								Doc_Fecha = Convert.ToDateTime(dr["Doc_Fecha"]),
								Pag_TipoPago = Convert.ToInt32(dr["Pag_TipoPago"]),
								Pag_Valor = Convert.ToDecimal(dr["Pag_Valor"]),
								Pag_Formapago = Convert.ToInt32(dr["Pag_Formapago"]),
								Pag_Autoriza = dr["Pag_Autoriza"].ToString(),
								Pag_Descripcion = dr["Pag_Descripcion"].ToString(),
								nombreFpagoSri = dr["nombreFpagoSri"].ToString(),
								diasPlazo = Convert.ToInt32(dr["diasPlazo"]),
								NumeroDeCuotas = Convert.ToInt32(dr["NumeroDeCuotas"]),
								pagEfectivo = Convert.ToDecimal(dr["pagEfectivo"]),
								pagElectronico = Convert.ToDecimal(dr["pagElectronico"]),
								pagCreditoDebito = Convert.ToDecimal(dr["pagCreditoDebito"]),
								pagOtros = Convert.ToDecimal(dr["pagOtros"])
							};
						}
					}
				}
			}

			return pago;
		}

		//public string ObtenerLogoBase64(string pathImagenes)
		//{
		//	try
		//	{
		//		string rutaLogo = Path.Combine(pathImagenes, "logoempresa.jpg");

		//		if (File.Exists(rutaLogo))
		//		{
		//			byte[] bytes = File.ReadAllBytes(rutaLogo);
		//			return Convert.ToBase64String(bytes);
		//		}
		//	}
		//	catch
		//	{
		//		// Si falla por red o permisos
		//	}

		//	return "";
		//}
		public string ObtenerLogoBase64(string pathImagenes)
		{
			try
			{
				// Lista de extensiones a probar (en orden de preferencia)
				string[] extensiones = { ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".webp" };

				foreach (string ext in extensiones)
				{
					string rutaLogo = Path.Combine(pathImagenes, "logoempresa" + ext);

					if (File.Exists(rutaLogo))
					{
						byte[] bytes = File.ReadAllBytes(rutaLogo);
						return Convert.ToBase64String(bytes);
					}
				}
			}
			catch
			{
				// Si falla por red o permisos
			}

			return "";
		}

		public void CalcularBases(ResultadoCpbtFac resultado)
		{
			double base15 = 0;
			double base5 = 0;
			double iva15 = 0;
			double iva5 = 0;

			// Obtener IVA vigente
			docImpuestos claseImpuestos = new docImpuestos();
			claseImpuestos.cargar(datosEmpresa.strConxIvaret, resultado._Doc_fecha);
			double ivaActual = claseImpuestos.impstoPorcentaje1;

			foreach (var det in resultado.Detalles)
			{
				decimal porcentaje = det._Tra_porceniva;

				if (porcentaje == 0)
					porcentaje = (decimal)ivaActual;

				if (porcentaje == 15)
				{
					base15 += (double)det._Tra_prectot;
					iva15 += (double)det._Tra_valoriva;
				}
				else if (porcentaje == 5)
				{
					base5 += (double)det._Tra_prectot;
					iva5 += (double)det._Tra_valoriva;
				}
			}

			resultado._Base15 = base15;
			resultado._Base5 = base5;
			resultado._Iva15 = iva15;
			resultado._Iva5 = iva5;
		}

	}
}
