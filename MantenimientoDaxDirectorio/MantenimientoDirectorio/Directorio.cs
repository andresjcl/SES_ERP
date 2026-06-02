using System;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using DattCom;
using Microsoft.VisualBasic;

namespace directMnt
{
	public class Directorio
	{
		// 'Esta Clase sirve para cargar directorios en produccion o sistemas que  permito que no usen el adcomdx
		public string codigo; // copia local
		public string NombreImpresion; // copia local
		public string CiRuc; // copia local
		public string telefono1; // copia local
		public string telefono2; // copia local
		public string direccion; // copia local
		public string CodVendedor; // copia local
		public string ZonaVentas; // copia local
		public string TipoCliente;
		public string Ciudad;
		public string TipoId;
		public string NombreCli;
		public string TipoPersona;
		// variables locales para almacenar los valores de las propiedades

		public bool CargarAlex(ref string CodigoAlex, ref bool ClioPro, [Optional, DefaultParameterValue("")] ref string SoloCodigo)
		{
			bool CargarAlexRet = default;

			string apellidos = "";
			string nombres = "";
			string seleccion = "";

			var ConxAdcom = new SqlConnection(datosEmpresa.strConxAdcom);
			SqlDataReader rs;
			string Ssql = "SELECT * FROM DirectorioList " + " WHERE codigo='" + CodigoAlex + "' or cedulaidentidadruc ='" + CodigoAlex + "'  " + seleccion + "";
			var comm = new SqlCommand(Ssql, ConxAdcom);
			ConxAdcom.Open();
			rs = comm.ExecuteReader();

			if (rs.Read() == false)
			{
				rs.Close();
				CargarAlexRet = false;
				return CargarAlexRet;
			}

			codigo = rs["codigo"].ToString();
			if (!(rs["nombres"] is DBNull))
				nombres = rs["nombres"].ToString();
			if (!(rs["apellidos"] is DBNull))
				apellidos = rs["apellidos"].ToString();
			if (!(rs["NombreImpresion"] is DBNull))
				NombreImpresion = rs["NombreImpresion"].ToString();
			if (!(rs["CedulaIdentidadRuc"] is DBNull))
				CiRuc = rs["CedulaIdentidadRuc"].ToString();
			if (!(rs["telefono1"] is DBNull))
				telefono1 = rs["telefono1"].ToString();
			if (!(rs["Domicilio"] is DBNull))
				direccion = rs["Domicilio"].ToString();
			if (!(rs["Ciudad"] is DBNull))
				Ciudad = rs["Ciudad"].ToString();
			if (!(rs["TipoIdentificacion"] is DBNull))
				TipoId = rs["TipoIdentificacion"].ToString();
			if (!(rs["TipoPersona"] is DBNull))
				TipoPersona = Interaction.IIf(rs["TipoPersona"].ToString() == "N", "1", "2").ToString();
			if (!(rs["VendedorInterno"] is DBNull))
				CodVendedor = rs["VendedorInterno"].ToString();
			if (!(rs["ZonaVentas"] is DBNull))
				ZonaVentas = rs["ZonaVentas"].ToString();
			if (!(rs["TipoCli"] is DBNull))
				TipoCliente = rs["TipoCli"].ToString();
			NombreCli = Valores.CorrijeNulo(rs["NombreCli"]);
			rs.Close();
			CargarAlexRet = true;
			ConxAdcom.Close();
			ConxAdcom.Dispose();
			rs.Close();
			comm.Dispose();
			return CargarAlexRet;
		}
		public static void actualizarDirectorio(string txtcedula, string txtCorreoElectronico, string txtnombrecliente, string txtApellido, string txttelefono2, string txttelefono, string txtdireccion, string txtSector)
		{
			string insertar = "update identificacion set HistoriaClinica = '" + txtcedula + "'";
			insertar += ", correoElectrónico = '" + txtCorreoElectronico + "'";
			insertar += ", NombreImpresion = '" + txtnombrecliente + "'";
			insertar += ", Telefono1 = '" + txttelefono + "'";
			insertar += ", Telefono2 = '" + txttelefono2 + "'";
			insertar += ", Domicilio = '" + txtdireccion + "'";
			insertar += ", sector = '" + txtSector + "'";
			insertar += " where Codigo = '" + txtcedula + "' or CedulaIdentidadRuc = '" + txtcedula + "' ";

			using (var conn = new SqlConnection(datosEmpresa.strConxAdcom))
			{
				conn.Open();
				using (var comm = new SqlCommand(insertar, conn))
				{
					comm.ExecuteNonQuery();
				}
			}

		}

	}
}