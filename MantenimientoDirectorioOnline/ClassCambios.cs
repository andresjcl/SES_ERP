using DattCom;
using System;


namespace MantenimientoDirectorioOnline
{
	public class ClassCambios
    {
        public DateTime AntFechaIngreso { get; set; }
        public DateTime AntFechaSalida { get; set; }
        public string AntSucursal { get; set; }
        public string AntDepartamento { get; set; }
        public string AntCentroCosto { get; set; }
        public string AntModulos { get; set; }
        public string AntCargo { get; set; }
        public string AntSeccion { get; set; }
        public double AntSueldo { get; set; }
    }

    public class verificaCambios
    {
        public static string VerificaCambios(ClassCambios LosCambios, dbEmpleado datEmple, bool esCreacion)
        {
            string cmb = "";
            BeeDat.AdcMovPer datMovPer = new BeeDat.AdcMovPer(datosEmpresa.strConxAdcom);
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
			//if (LosCambios.AntSueldo != datEmple.ValorSueldo)
			//{
			//	cmb += "Sueldo, ";
			//	datMovPer.Sueldo = datEmple.ValorSueldo;
			//}

			if (esCreacion == false)
            {
                if (LosCambios.AntCargo != datEmple.Cargorol)
                {
                    cmb += "Cargo, ";
                    datMovPer.Cargo = datEmple.Cargorol;
                }
                if (LosCambios.AntCentroCosto != datEmple.centroCosto)
                {
                    cmb += "Centro de costo, ";
                    datMovPer.CentroCosto = datEmple.centroCosto;
                }
                if (LosCambios.AntDepartamento != datEmple.Departamento)
                {
                    cmb += "Departamento, ";
                    datMovPer.Departamento = datEmple.Departamento;
                }
                if (LosCambios.AntSucursal != datEmple.Sucursalrol)
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

                if (datEmple.FechaIngreso > new DateTime(1900, 1, 1) && cambiaSueldo)
                {
                    datMovPer.FechaRegistro = datEmple.FechaIngreso;
                }
                else
                {
                    datMovPer.FechaRegistro = DateTime.Now;
                }

                datMovPer.Observaciones = esCreacion ?
                    "Se registraron " + cmb :
                    "Se cambiaron " + cmb;

                datMovPer.Actualizar();
            }

            return cmb;
        }

        private void guardarMovimiento()
        {
            // Implementation goes here
        }
    }
}
