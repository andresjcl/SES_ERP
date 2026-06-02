using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MantenimientoDirectorioOnline
{
    using System;

    public static class MoverDatosEmpleado
    {
        public static void moverDatos(DEEP01 frmId, dbEmpleado recide, string[] TipCodSyscod, string CodBanco, string codSuc)
        {
            Syscod.ManSysnetClass Buscod = new Syscod.ManSysnetClass();

            recide.CodigoEmpleado = frmId.Codigo.Text;
            if (frmId.cmbCentroCostoRol.SelectedValue != null)
                recide.centroCosto = frmId.cmbCentroCostoRol.SelectedValue.ToString();

            recide.Libretamilitar = frmId.cmbSeccionRol.Text; // seccion

            if (frmId.cmbSucursalRol.SelectedValue != null)
                recide.Sucursalrol = frmId.cmbSucursalRol.SelectedValue.ToString();

            if (frmId.cmbDepartamentoRol.SelectedValue != null)
                recide.Departamento = frmId.cmbDepartamentoRol.SelectedValue.ToString();

            if (frmId.cmbCargoRol.SelectedValue != null)
                recide.Cargorol = frmId.cmbCargoRol.SelectedValue.ToString();

            recide.codigoBiometrico = frmId.CodBimetrico.Text;
            recide.FechaJubilacion = frmId.fJubilacion.Value;
            recide.NivelRol = Convert.ToByte(Convert.ToDouble(frmId.nivelrol.Text));

            if (frmId.rolproduccion.Checked)
            {
                recide.TipoPago = "P";
            }
            else if (frmId.roldiario.Checked)
            {
                recide.TipoPago = "J";
            }
            else
            {
                recide.TipoPago = "S";
            }

            if (frmId.RolHoras.Checked)
                recide.TipoPago = "H";

            recide.AcreditarBanco = frmId.AcreditaBanco.Checked;
            recide.BancoRol = CodBanco;
            recide.HorSemanaParcial = Convert.ToDecimal(Convert.ToDouble(frmId.txtHorasJornadaSemanal.Text));
            recide.TipoSalario = Buscod.QueCodigo(frmId.Lcod11.Text, TipCodSyscod[11]);
            recide.ValorSueldo = Convert.ToDecimal(Convert.ToDouble(frmId.valorsueldo.Text));
            recide.FechaIngreso = frmId.fingreso.Value;
            recide.FechaSalida = frmId.fsalida.Value;
            recide.NroCtaBancoRol = frmId.Nroctabancorol.Text;

            if (frmId.ctaahorrosrol.Checked)
                recide.TipoCuentaBanco = "A";
            if (frmId.ctacorrienterol.Checked)
                recide.TipoCuentaBanco = "C";

            recide.Grupo_1 = frmId.Grupo1.Text;
            recide.Grupo_2 = frmId.Grupo2.Text;
            recide.Grupo_3 = frmId.Grupo3.Text;
            recide.Grupo_4 = frmId.Grupo4.Text;
            recide.Grupo_5 = frmId.Grupo5.Text;
            recide.Grupo_6 = frmId.Grupo6.Text;

            if (frmId.activorol.Checked)
            {
                recide.EstadoRol = "A";
            }
            else if (frmId.Cesanterol.Checked)
            {
                recide.EstadoRol = "C";
            }
            else if (frmId.Eliminadorol.Checked)
            {
                recide.EstadoRol = "E";
            }
            else if (frmId.Jubilado.Checked)
            {
                recide.EstadoRol = "J";
            }

            recide.Idusuario = frmId.cmbModuloRol.Text; // modulo
            recide.CtbRol_0_ = frmId.Cuenta2.Text;
            recide.CtbRol_1_ = frmId.Cuenta3.Text;
        }
    }
}
