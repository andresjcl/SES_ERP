using System;
using System.Runtime.InteropServices;
using DattCom;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace directMnt
{
	public class DirectorioAlex
	{
		// variables locales para almacenar los valores de las propiedades
		public string codigo; // copia local
		public string nombres; // copia local
		public string apellidos; // copia local
		public string NombreImpresion; // copia local
		public string CiRuc; // copia local
		public string telefono1; // copia local
		public string telefono2; // copia local
		public string direccion; // copia local
		public string CodVendedor; // copia local
		public string CodCobrador; // copia local
		public string ZonaVentas; // copia local
		public string ZonaCobranzas; // copia local
		public string TipoCliente;
		public bool EsProveedor;
		public bool EsCliente;
		public bool EsEmpleado;
		public bool EsBanco;
		public bool EsVendedor;
		public string Ciudad;
		public short PrecioVenta;
		public double dESCUENTO;
		public double dESCUENTO_prov;
		public string FormaPago;
		public string FormaPago_prov;
		public double limitecredito;
		public double limitecredito_prov;
		public int PorcComision;
		public string CtaCobComision;
		public string TipoId;
		public string NombreCli;
		public string TipoPersona;
		public bool ExoneradoIva;
		public string correoElectronico;
		public string sector;

		public bool CargarAlex(ref string CodigoAlex, ref bool ClioPro, [Optional, DefaultParameterValue("")] ref string SoloCodigo)
		{
			bool CargarAlexRet = default;
			CargarAlexRet = false;
			Module1.Mainn();
			string Seleccion = "";
			try
			{
				var RsCli = new Identificacion(datosEmpresa.strConxAdcom);
				RsCli = Identificacion.Buscar(" codigo='" + CodigoAlex + "' or cedulaidentidadruc ='" + CodigoAlex + "'  " + Seleccion + "");
				if (RsCli is null)
					return CargarAlexRet;
				Seleccion = "";

				codigo = RsCli.Codigo;
				nombres = RsCli.Nombres;
				apellidos = RsCli.Apellidos;
				NombreImpresion = RsCli.NombreImpresion;
				CiRuc = RsCli.CedulaIdentidadRuc;
				telefono1 = RsCli.Telefono1;
				telefono2 = RsCli.Telefono2;
				direccion = RsCli.Domicilio;
				EsCliente = RsCli.EsCliente;
				EsProveedor = RsCli.EsProveedor;
				EsEmpleado = RsCli.EsEmpleado;
				EsBanco = RsCli.EsBanco;
				Ciudad = RsCli.Ciudad;
				EsVendedor = RsCli.EsVendedor;
				PorcComision = (int)Math.Round(RsCli.ComisionVenta);
				CtaCobComision = RsCli.CtaCobrarComisiones;
				TipoId = RsCli.TipoIdentificacion;
				TipoPersona = RsCli.TipoPersona;
				ExoneradoIva = RsCli.ExoneradoIva;
				NombreCli = nombres + " " + apellidos;
				correoElectronico = RsCli.CorreoElectrónico;
				sector = RsCli.Sector;
				CargarAlexRet = true;
			}
			catch (Exception exx)
			{
				Interaction.MsgBox("excepcion en lectura de datos Alex identificacion" + Constants.vbCr + exx.Message);
			}

			try
			{
				var ConxAdcom = new System.Data.SqlClient.SqlConnection(datosEmpresa.strConxAdcom);
				ConxAdcom.Open();
				string Ssql = "SELECT * FROM Cliente WHERE codigocli='" + CodigoAlex + "'";
				var comm = new System.Data.SqlClient.SqlCommand(Ssql, ConxAdcom);
				var rs = comm.ExecuteReader();
				if (rs.Read())
				{
					if (!(rs["VendedorInterno"].ToString() is DBNull))
						CodVendedor = rs["VendedorInterno"].ToString();
					if (!(rs["TipoCli"].ToString() is DBNull))
						TipoCliente = rs["TipoCli"].ToString();
					if (!(rs["ZonaVentas"].ToString() is DBNull))
						ZonaVentas = rs["ZonaVentas"].ToString();
					if (!(rs["ZonaCobranza"].ToString() is DBNull))
						ZonaCobranzas = rs["ZonaCobranza"].ToString();
					if (!(rs["CobradorInterno"].ToString() is DBNull))
						CodCobrador = rs["CobradorInterno"].ToString();
					if (!(rs["PrecioVenta"] is DBNull))
						PrecioVenta = (short)Math.Round(Valores.CorrijeNuloN(rs["PrecioVenta"]));
					if (!(rs["PorcDescuento"] is DBNull))
						dESCUENTO = Conversions.ToDouble(rs["PorcDescuento"]);
					if (!(rs["FormaPago"].ToString() is DBNull))
						FormaPago = rs["FormaPago"].ToString();
					if (!(rs["limitecredito"] is DBNull))
						limitecredito = Conversions.ToDouble("0" + rs["limitecredito"].ToString());
				}
				rs.Close();
			}
			catch (Exception exx)
			{
				Interaction.MsgBox("excepcion en lectura de datos Alex cliente" + Constants.vbCr + exx.Message);
			}

			try
			{
				var ConxAdcom = new System.Data.SqlClient.SqlConnection(datosEmpresa.strConxAdcom);
				ConxAdcom.Open();
				string Ssql = "SELECT isnull(FormaPago,'') as FormaPago,isnull(PorceDescuent,0) as PorceDescuent,isnull(LimCreditoPrv,0) as LimCreditoPrv FROM proveedor WHERE codigoproveedor='" + CodigoAlex + "'";
				var comm = new System.Data.SqlClient.SqlCommand(Ssql, ConxAdcom);
				var rs = comm.ExecuteReader();
				if (rs.Read())
				{
					if (!(rs["PorceDescuent"] is DBNull))
						dESCUENTO_prov = Conversions.ToDouble(rs["PorceDescuent"]);
					if (!(rs["FormaPago"] is DBNull))
						FormaPago_prov = rs["FormaPago"].ToString();
					if (!(rs["LimCreditoPrv"] is DBNull))
						limitecredito_prov = Conversion.Val(rs["LimCreditoPrv"].ToString());
				}
				rs.Close();
			}
			catch (Exception exx)
			{
				Interaction.MsgBox("excepcion en lectura de datos Alex proveedor" + Constants.vbCr + exx.Message);
			}

			return CargarAlexRet;

		}
	}
}