using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using DattCom;

namespace MantenimientoDirectorioOnline
{
    internal static class LeerEmpleado
    {
        
        internal static bool leerEmpleado(DEEP01 form, string queCodigo, string[] tipCodSyscod, ClassCambios losCambios, string[] codigoDirectorio)
        {
            dbEmpleado classEmpleado = new dbEmpleado(datosEmpresa.strConxAdcom);
            var buscNom = new EmpNomR.AdcNomb();
            classEmpleado = dbEmpleado.Buscar($"codigoempleado = '{queCodigo}'");

            if (classEmpleado == null || Convert.IsDBNull(classEmpleado))
                return false;

            // Employee data assignment
            form.cmbCentroCostoRol.Text = classEmpleado.centroCosto;
            losCambios.AntCentroCosto = classEmpleado.centroCosto;

            form.cmbSeccionRol.Text = classEmpleado.Libretamilitar;
            losCambios.AntSeccion = classEmpleado.Libretamilitar;

            form.CodSuc = classEmpleado.Sucursalrol;
            losCambios.AntSucursal = form.CodSuc;
            form.cmbSucursalRol.SelectedValue = classEmpleado.Sucursalrol;

            form.cmbDepartamentoRol.SelectedValue = classEmpleado.Departamento;
            losCambios.AntDepartamento = classEmpleado.Departamento;

            form.cmbCargoRol.SelectedValue = classEmpleado.Cargorol;
            losCambios.AntCargo = classEmpleado.Cargorol;

            // Date handling
            form.fingreso.Value = classEmpleado.FechaIngreso;
            losCambios.AntFechaIngreso = classEmpleado.FechaIngreso;

            form.fsalida.Value = classEmpleado.FechaSalida;
            losCambios.AntFechaSalida = classEmpleado.FechaSalida;

            form.fJubilacion.Value = classEmpleado.FechaJubilacion;

            // Financial data
            form.nivelrol.Text = classEmpleado.NivelRol.ToString();
            form.Cuenta2.Text = classEmpleado.CtbRol_0_;
            form.Cuenta3.Text = classEmpleado.CtbRol_1_;

            // Payment type
            switch (classEmpleado.TipoPago)
            {
                case "P":
                    form.rolproduccion.Checked = true;
                    break;
                case "J":
                    form.roldiario.Checked = true;
                    break;
                case "S":
                    form.rolmensual.Checked = true;
                    break;
                case "H":
                    form.RolHoras.Checked = true;
                    break;
            }

            // Bank information
            form.AcreditaBanco.Checked = classEmpleado.AcreditarBanco;
            codigoDirectorio[2] = classEmpleado.BancoRol;
            form.txtNomBanco.Text = buscNom.RetornaNombreDirectorio(codigoDirectorio[2], datosEmpresa.strConxAdcom);

            // Salary information
            form.Lcod11.Text = new Syscod.ManSysnetClass().QueNombre(classEmpleado.TipoSalario, tipCodSyscod[11]);
            form.txtHorasJornadaSemanal.Text = classEmpleado.HorSemanaParcial.ToString();
            form.valorsueldo.Text = classEmpleado.ValorSueldo.ToString();
            losCambios.AntSueldo = (double)classEmpleado.ValorSueldo;

            // Bank account
            form.Nroctabancorol.Text = classEmpleado.NroCtaBancoRol.ToString();
            form.ctaahorrosrol.Checked = classEmpleado.TipoCuentaBanco == "A";
            form.ctacorrienterol.Checked = classEmpleado.TipoCuentaBanco == "C";

            // Groups
            form.Grupo1.Text = classEmpleado.Grupo_1;
            form.Grupo2.Text = classEmpleado.Grupo_2;
            form.Grupo3.Text = classEmpleado.Grupo_3;
            form.Grupo4.Text = classEmpleado.Grupo_4;
            form.Grupo5.Text = classEmpleado.Grupo_5;
            form.Grupo6.Text = classEmpleado.Grupo_6;

            // Employment status
            switch (classEmpleado.EstadoRol)
            {
                case "A":
                    form.activorol.Checked = true;
                    break;
                case "C":
                    form.Cesanterol.Checked = true;
                    break;
                case "E":
                    form.Eliminadorol.Checked = true;
                    break;
                case "J":
                    form.Jubilado.Checked = true;
                    break;
            }

            // Additional info
            form.cmbModuloRol.Text = classEmpleado.Idusuario;
            form.CodBimetrico.Text = classEmpleado.codigoBiometrico;

            return true;
        }

        public static bool ExisteCodigo(string codigo)
        {
            using (var conn = new SqlConnection(datosEmpresa.strConxAdcom))
            using (var comm = new SqlCommand("SELECT codigo FROM identificacion WHERE codigo = @codigo", conn))
            {
                comm.Parameters.AddWithValue("@codigo", codigo);
                conn.Open();
                using (var dr = comm.ExecuteReader())
                {
                    return dr.HasRows;
                }
            }
        }

        public static bool ExisteCedula(string codigo, string cedula)
        {
            using (var conn = new SqlConnection(datosEmpresa.strConxAdcom))
            using (var comm = new SqlCommand(
                "SELECT codigo FROM identificacion WHERE cedulaidentidadruc = @cedula AND codigo <> @codigo",
                conn))
            {
                comm.Parameters.AddWithValue("@cedula", cedula);
                comm.Parameters.AddWithValue("@codigo", codigo);
                conn.Open();
                using (var dr = comm.ExecuteReader())
                {
                    return dr.HasRows;
                }
            }
        }
    }

}
