
namespace directMnt
{
	static class Valores
	{

		internal static void iniciaValores(string[] TipCod)
		{
			TipCod[0] = "Sucursales";
			TipCod[1] = "TiposIdentificacion";
			TipCod[2] = "Nacionalidad";
			TipCod[3] = "TipoCliente";
			TipCod[4] = "ZonaVentas";
			TipCod[5] = "ZonaCobranzas";
			TipCod[6] = "PrecioVenta";
			TipCod[7] = "FormasDePago";
			TipCod[8] = "FormasDePago";
			TipCod[9] = "Departamento";
			TipCod[10] = "Cargos";
			TipCod[11] = "TipoPagoPersonal";
			TipCod[12] = "Paises";
			TipCod[13] = "Provincias";
			TipCod[14] = "Ciudades";
			TipCod[15] = "Profesion";
			TipCod[16] = "Especialidad";
			TipCod[17] = "Grupo1";
			TipCod[18] = "Grupo2";
			TipCod[19] = "Grupo3";
			TipCod[20] = "Centro Costo";
			TipCod[21] = "Sección";
			TipCod[22] = "Módulo";
			TipCod[23] = "Cantones";
			TipCod[24] = "Parroquias";
			TipCod[25] = "Regiones";
			TipCod[26] = "Puertos";
			TipCod[27] = "Transportador";
		}
		internal static string CorrijeNulo(object obj)
		{
			if (obj is null)
				return "";
			return obj.ToString();
		}
		internal static double CorrijeNuloN(object obj)
		{
			double aux = 0d;
			double.TryParse(obj.ToString(), out aux);
			return aux;
		}

	}
}