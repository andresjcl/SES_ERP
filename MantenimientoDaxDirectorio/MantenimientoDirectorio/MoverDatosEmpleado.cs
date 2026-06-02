using System;
using Microsoft.VisualBasic;

namespace directMnt
{
	public class MoverDatosEmpleado
	{
		public static void moverDatos(DEEP01 frmId, dbEmpleado recide, string[] TipCodSyscod, string CodBanco, string codSuc)
		{
			var Buscod = new Syscod.ManSysnetClass();
			recide.CodigoEmpleado = frmId.Codigo.Text;
			if (!(frmId.cmbCentroCostoRol.SelectedValue == null))
				recide.centroCosto = frmId.cmbCentroCostoRol.SelectedValue.ToString();
			recide.Libretamilitar = frmId.cmbSeccionRol.Text; // seccion
			if (!(frmId.cmbSucursalRol.SelectedValue == null))
				recide.Sucursalrol = frmId.cmbSucursalRol.SelectedValue.ToString();
			if (!(frmId.cmbDepartamentoRol.SelectedValue == null))
				recide.Departamento = frmId.cmbDepartamentoRol.SelectedValue.ToString();
			if (!(frmId.cmbCargoRol.SelectedValue == null))
				recide.Cargorol = frmId.cmbCargoRol.SelectedValue.ToString();
			recide.codigoBiometrico = frmId.CodBimetrico.Text;


			recide.FechaJubilacion = frmId.fJubilacion.Value;

			recide.NivelRol = (byte)Math.Round(Conversion.Val(frmId.nivelrol.Text));
			if (frmId.rolproduccion.Checked == true)
			{
				recide.TipoPago = "P";
			}
			else if (frmId.roldiario.Checked == true)
			{
				recide.TipoPago = "J";
			}
			else
			{
				recide.TipoPago = "S";
			}
			if (frmId.RolHoras.Checked == true)
				recide.TipoPago = "H";
			if (frmId.AcreditaBanco.Checked)
				recide.AcreditarBanco = true;
			else
				recide.AcreditarBanco = false;
			recide.BancoRol = CodBanco;
			recide.HorSemanaParcial = (decimal)Conversion.Val(frmId.txtHorasJornadaSemanal.Text);
			recide.TipoSalario = Buscod.QueCodigo(frmId.Lcod11.Text, TipCodSyscod[11]);

			recide.ValorSueldo = (decimal)Conversion.Val(frmId.valorsueldo.Text);
			recide.FechaIngreso = frmId.fingreso.Value;
			recide.FechaSalida = frmId.fsalida.Value;

			recide.NroCtaBancoRol = frmId.Nroctabancorol.Text;
			if (frmId.ctaahorrosrol.Checked == true)
				recide.TipoCuentaBanco = "A";
			if (frmId.ctacorrienterol.Checked == true)
				recide.TipoCuentaBanco = "C";
			recide.Grupo_1 = frmId.Grupo1.Text;
			recide.Grupo_2 = frmId.Grupo2.Text;
			recide.Grupo_3 = frmId.Grupo3.Text;
			recide.Grupo_4 = frmId.Grupo4.Text;
			recide.Grupo_5 = frmId.Grupo5.Text;
			recide.Grupo_6 = frmId.Grupo6.Text;

			if (frmId.activorol.Checked == true)
			{
				recide.EstadoRol = "A";
			}
			else if (frmId.Cesanterol.Checked == true)
			{
				recide.EstadoRol = "C";
			}
			else if (frmId.Eliminadorol.Checked == true)
			{
				recide.EstadoRol = "E";
			}
			else if (frmId.Jubilado.Checked == true)
			{
				recide.EstadoRol = "J";
			}

			recide.Idusuario = frmId.cmbModuloRol.Text;    // modulo
			recide.CtbRol_0_ = frmId.Cuenta2.Text;
			recide.CtbRol_1_ = frmId.Cuenta3.Text;

		}
	}
}