using System;
using DattCom;

namespace directMnt
{
	internal class LeerEmpleado
	{
		internal static bool leerEmpleado(DEEP01 Form, string QueCodigo, string[] TipCodSyscod, ClassCambios LosCambios, string[] codigoDirectorio)
		{
			var Buscod = new Syscod.ManSysnetClass();
			var Busnom = new EmpNomR.AdcNomb();
			var classEmpleado = new dbEmpleado(datosEmpresa.strConxAdcom);
			classEmpleado = dbEmpleado.Buscar(" codigoempleado = '" + QueCodigo + "' ");
			if (classEmpleado is DBNull)
				return false;
			if (classEmpleado == null)
				return false;

			Form.cmbCentroCostoRol.Text = classEmpleado.centroCosto;
			LosCambios.AntCentroCosto = classEmpleado.centroCosto;

			Form.cmbSeccionRol.Text = classEmpleado.Libretamilitar;
			LosCambios.AntSeccion = classEmpleado.Libretamilitar;

			Form.CodSuc = classEmpleado.Sucursalrol;
			LosCambios.AntSucursal = Form.CodSuc;
			Form.cmbSucursalRol.SelectedValue = classEmpleado.Sucursalrol;

			Form.cmbDepartamentoRol.SelectedValue = classEmpleado.Departamento;
			LosCambios.AntDepartamento = classEmpleado.Departamento;

			Form.cmbCargoRol.SelectedValue = classEmpleado.Cargorol;
			LosCambios.AntCargo = classEmpleado.Cargorol;

			Form.fingreso.Value = classEmpleado.FechaIngreso;
			LosCambios.AntFechaIngreso = classEmpleado.FechaIngreso;

			Form.fsalida.Value = classEmpleado.FechaSalida;
			LosCambios.AntFechaSalida = classEmpleado.FechaSalida;

			Form.fJubilacion.Value = classEmpleado.FechaJubilacion;

			Form.nivelrol.Text = classEmpleado.NivelRol.ToString();
			Form.Cuenta2.Text = classEmpleado.CtbRol_0_;
			Form.Cuenta3.Text = classEmpleado.CtbRol_1_;

			string tp = classEmpleado.TipoPago;
			if (tp == "P")
			{
				Form.rolproduccion.Checked = true;
			}
			else if (tp == "J")
			{
				Form.roldiario.Checked = true;
			}
			else if (tp == "S")
			{
				Form.rolmensual.Checked = true;
			}
			else if (tp == "H")
			{
				Form.RolHoras.Checked = true;
			}

			if (classEmpleado.AcreditarBanco)
				Form.AcreditaBanco.CheckState = System.Windows.Forms.CheckState.Checked;
			else
				Form.AcreditaBanco.CheckState = System.Windows.Forms.CheckState.Unchecked;
			codigoDirectorio[2] = classEmpleado.BancoRol;
			Form.txtNomBanco.Text = Busnom.RetornaNombreDirectorio(codigoDirectorio[2], datosEmpresa.strConxAdcom);

			Form.Lcod11.Text = Buscod.QueNombre(classEmpleado.TipoSalario, TipCodSyscod[11]);
			Form.txtHorasJornadaSemanal.Text = classEmpleado.HorSemanaParcial.ToString();
			Form.valorsueldo.Text = classEmpleado.ValorSueldo.ToString();
			LosCambios.AntSueldo = (double)classEmpleado.ValorSueldo;
			Form.txtHorasJornadaSemanal.Text = classEmpleado.HorSemanaParcial.ToString();
			Form.Nroctabancorol.Text = classEmpleado.NroCtaBancoRol;
			if (classEmpleado.TipoCuentaBanco == "A")
			{
				Form.ctaahorrosrol.Checked = true;
			}
			else
			{
				Form.ctaahorrosrol.Checked = false;
			}
			if (classEmpleado.TipoCuentaBanco == "C")
			{
				Form.ctacorrienterol.Checked = true;
			}
			else
			{
				Form.ctacorrienterol.Checked = false;
			}

			Form.Grupo1.Text = classEmpleado.Grupo_1;
			Form.Grupo2.Text = classEmpleado.Grupo_2;
			Form.Grupo3.Text = classEmpleado.Grupo_3;
			Form.Grupo4.Text = classEmpleado.Grupo_4;
			Form.Grupo5.Text = classEmpleado.Grupo_5;
			Form.Grupo6.Text = classEmpleado.Grupo_6;

			switch (classEmpleado.EstadoRol ?? "")
			{
				case "A":
					{
						Form.activorol.Checked = true;
						break;
					}
				case "C":
					{
						Form.Cesanterol.Checked = true;
						break;
					}
				case "E":
					{
						Form.Eliminadorol.Checked = true;
						break;
					}
				case "J":
					{
						Form.Jubilado.Checked = true;
						break;
					}
			}

			Form.cmbModuloRol.Text = classEmpleado.Idusuario;
			Form.CodBimetrico.Text = classEmpleado.codigoBiometrico;

			return true;
		}
		public static bool ExisteCodigo(string codigo)
		{
			bool resp = false;
			using (var conn = new System.Data.SqlClient.SqlConnection(datosEmpresa.strConxAdcom))
			{
				conn.Open();
				var comm = new System.Data.SqlClient.SqlCommand("select codigo from identificacion where codigo = '" + codigo + "'", conn);
				var dr = comm.ExecuteReader();
				if (dr.Read())
					resp = true;
				return resp;
				dr.Close();
				comm.Dispose();
				conn.Close();
			}

		}
		public static bool ExisteCedula(string codigo, string cedula)
		{
			bool resp = false;
			using (var conn = new System.Data.SqlClient.SqlConnection(datosEmpresa.strConxAdcom))
			{
				conn.Open();
				var comm = new System.Data.SqlClient.SqlCommand("select codigo from identificacion where cedulaidentidadruc='" + cedula + "' and codigo <> '" + codigo + "' ", conn);
				var dr = comm.ExecuteReader();
				if (dr.Read())
					resp = true;
				return resp;
				dr.Close();
				comm.Dispose();
				conn.Close();
			}
		}


	}
}