using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DattCom;

namespace IngSis
{
    public partial class EmpresaInicio
    {
        internal static int EmpresaDeInicio(string usuario)
        {
            int empresa = 0;
            if ((usuario.ToUpper() ?? "") == "ADMINISTRADOR" | (usuario.ToUpper() ?? "") == "CONTROL")
            {
                var ConxDaxSys = new SqlConnection(datosEmpresa.strConxSyscod);
                ConxDaxSys.Open();
                var comm = new SqlCommand("Select emp_codigo from emp_datos where emp_defecto <> 0 ", ConxDaxSys);
                SqlDataReader Rs = comm.ExecuteReader();
                if (Rs.Read())
                    empresa = Convert.ToInt16(Rs["Emp_Codigo"]);
                else
                    empresa = 0;
                if (Rs.IsClosed == false)
                    Rs.Close();
                comm.Dispose();
                Rs.Close();
                ConxDaxSys.Close();
                ConxDaxSys.Dispose();
            }
            return empresa;
        }
        internal static void cargarEmpresasUsuario(int empresa, string usuario, ComboBox cmbEmp)
        {
            if (string.IsNullOrEmpty(usuario))
                return;

            string ssql = "SELECT emp_nombre,emp_codigo FROM Emp_datos WHERE Emp_Codigo > 0 ";
            if ((usuario.ToUpper() ?? "") != "ADMINISTRADOR" & (usuario.ToUpper() ?? "") != "CONTROL")
            {
                ssql += " and emp_codigo in (";
                ssql += "select distinct( idempresa) from sys_Accesos where idusuario = '" + usuario + "')";
            }
            ssql += " order by emp_nombre";
            var da = new SqlDataAdapter(ssql, datosEmpresa.strConxSyscod);
            var rs = new DataTable();
            da.Fill(rs);
            cmbEmp.DataSource = rs;
            cmbEmp.DisplayMember = "emp_nombre";
            cmbEmp.ValueMember = "emp_codigo";
            da.Dispose();
            if (rs.Rows.Count > 0)
            {
                if (empresa > 0)
                    cmbEmp.SelectedValue = empresa;
                else
                    cmbEmp.SelectedIndex = 0;
            }
        }
        internal static bool IniciaEmpresa()
        {
            SqlCommand comm = new SqlCommand();
            SqlConnection conn = new SqlConnection(datosEmpresa.strConxAdcom);
            EmpNomR.AdcNomb UtilRetorna = new EmpNomR.AdcNomb();
            bool conError = false;
            if (datosEmpresa.Emp_codigo == 0) return false;
            if (datosEmpresa.sistema == "") return false;
            try
            {
                conn.Open();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo conectar a base de datos del sistema \n" + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conError = true;
            }

            if (datosEmpresa.Produccion)
            {
                try
                {
                    conn = new SqlConnection(datosEmpresa.strConxDaxpro);
                    conn.Open();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo conectar a base de datos del sistema de producción \n" + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    conError = true;
                }
            }

            if (datosEmpresa.Ivaret || datosEmpresa.AnexoTransaccional)
            {
                try
                {
                    conn = new SqlConnection(datosEmpresa.strConxIvaret);
                    conn.Open();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo conectar a base de datos para el módulo del SRI \n" + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    conError = true;
                }
            }

            if (datosEmpresa.sistema == "DXA" || datosEmpresa.sistema == "ERP" || datosEmpresa.sistema == "MDD" || datosEmpresa.sistema == "CNX")
            {
                if (DatosUsuario.Identifica.ToUpper() != "ADMINISTRADOR" && DatosUsuario.Identifica.ToUpper() != "CONTROL")
                {
                    if (DatosUsuario.Sucs == "")
                    {
                        MessageBox.Show("El usuario no tiene acceso a ninguna sucursal de esta Empresa, no puede ingresar al sistema");
                        conError = true;
                    }
                    else if (DatosUsuario.Bods == "")
                    {
                        MessageBox.Show("El usuario no tiene acceso a ninguna bodega de esta Empresa, no puede ingresar al sistema");
                        conError = true;
                    }
                    if (!conError)
                    {
                        if (datosEmpresa.suc.Length == 0) datosEmpresa.suc = DatosUsuario.SucDef;
                    }
                }
            }
            if (conError) Environment.Exit(0);
            return !conError;
        }
    }
}
