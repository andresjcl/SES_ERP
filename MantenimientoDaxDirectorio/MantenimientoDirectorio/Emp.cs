using System;
using System.Data;
using DattCom;

namespace directMnt
{
	public class Emp
	{
		public static string PathImagenes;
		public static bool rol;
		public static bool OrdenaPorApellidos;  // esta en emp.Acumhis
		public static void CargarValores()
		{
			DataTable dt = datosEmpresa.leeParametrosEmp("EMP_PathImagenes,PAR_AcumHis");
			if (dt.Rows.Count > 0)
			{
				OrdenaPorApellidos = Convert.ToBoolean(dt.Rows[0]["PAR_AcumHis"]);
				PathImagenes = dt.Rows[0]["EMP_PathImagenes"].ToString();
			}
			dt.Dispose();
			try
			{
				if (datosEmpresa.auto.Length > 8)
					rol = datosEmpresa.auto.Substring(7, 1) == "1";
			}
			catch
			{
			}

		}

	}
}