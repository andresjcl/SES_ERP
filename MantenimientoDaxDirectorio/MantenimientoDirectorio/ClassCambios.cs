using System;
using DattCom;

namespace directMnt
{
	public class ClassCambios
	{
		public DateTime AntFechaIngreso;
		public DateTime AntFechaSalida;
		public string AntSucursal;
		public string AntDepartamento;
		public string AntCentroCosto;
		public string AntModulos;
		public string AntCargo;
		public string AntSeccion;
		public double AntSueldo;


	}

	public class verificaCambiosType
	{
		public static string verificaCambios(ClassCambios LosCambios, dbEmpleado datEmple, bool esCreacion)
		{
			string cmb = "";
			var datMovPer = new BeeDat.AdcMovPer(datosEmpresa.strConxAdcom);
			bool cambiaSueldo = false;

			if (LosCambios.AntFechaIngreso != datEmple.FechaIngreso)
			{
				cambiaSueldo = true;
				cmb += "Fecha de Ingreso, ";
				datMovPer.FechaIngreso = datEmple.FechaIngreso;
			}
			if (LosCambios.AntFechaSalida != datEmple.FechaSalida)
			{
				cmb += "Fecha de Salida, ";
				datMovPer.FechaSalida = datEmple.FechaSalida;
			}
			if (LosCambios.AntSueldo != (double)datEmple.ValorSueldo)
			{
				cmb += "Sueldo, ";
				datMovPer.Sueldo = datEmple.ValorSueldo;
			}

			if (esCreacion == false)
			{
				if ((LosCambios.AntCargo ?? "") != (datEmple.Cargorol ?? ""))
				{
					cmb += "Cargo, ";
					datMovPer.Cargo = datEmple.Cargorol;
				}
				if ((LosCambios.AntCentroCosto ?? "") != (datEmple.centroCosto ?? ""))
				{
					cmb += "Centro de costo, ";
					datMovPer.CentroCosto = datEmple.centroCosto;
				}
				if ((LosCambios.AntDepartamento ?? "") != (datEmple.Departamento ?? ""))
				{
					cmb += "Departamento, ";
					datMovPer.Departamento = datEmple.Departamento;
				}
				if ((LosCambios.AntSucursal ?? "") != (datEmple.Sucursalrol ?? ""))
				{
					cmb += "Sucursal, ";
					datMovPer.Sucursal = datEmple.Sucursalrol;
				}
			}

			if (cmb.Length > 3)
			{
				datMovPer.CodigoEmpleado = datEmple.CodigoEmpleado;
				datMovPer.RegistroEquipo = Environment.MachineName;
				datMovPer.RegistroOpcion = "Mant.Directorio";
				datMovPer.RegistroUsuario = datosEmpresa.usr;
				datMovPer.TipoMovimiento = "CAMBIOS";
				if (datEmple.FechaIngreso > new DateTime(1900, 1, 1) & cambiaSueldo)
				{
					datMovPer.FechaRegistro = datEmple.FechaIngreso;
				}
				else
				{
					datMovPer.FechaRegistro = DateTime.Now;
				}

				if (esCreacion)
					datMovPer.Observaciones = "Se registraron " + cmb;
				else
					datMovPer.Observaciones = "Se cambiaron " + cmb;

				datMovPer.Actualizar();


			}


			return cmb;


		}

		private void guardarMovimiento()
		{

		}
	}
}