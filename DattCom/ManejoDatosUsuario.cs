using System;
using System.Data;
using System.Data.SqlClient;

namespace DattCom
{
	public class ManejoDatosUsuario
    {
        public static void LeerDatosUsuario(string codigoUsuario)
        {
            string ssql = "SELECT IdUsuario, CodUsuario, FechaInicio, FechaCaduca, Contraseña, FechaCambioContra, DíasDuraContraseña ";
            ssql += " FROM dbo.sys_Usuario ";
            ssql += " WHERE Idusuario = '" + codigoUsuario + "'";
            DataTable recuser = SqlDatos.leerTabla(ssql, datosEmpresa.strConIniSis);
            if (recuser.Rows.Count > 0)
            {
                DataRow row = recuser.Rows[0];
                DatosUsuario._codigo = row["IdUsuario"].ToString();
                DatosUsuario._CodAlex = row["CodUsuario"].ToString();
                DatosUsuario._NumSuc = 0;
                DatosUsuario._NumBod = 0;
                DatosUsuario._Numdoc = 0;
                DatosUsuario._BodDef = "";
                DatosUsuario._SucDef = "";
                DatosUsuario._NumSuc = 0;
                DatosUsuario._Sucs = SucsUsr();
                DatosUsuario._Bods = BodsUsr();
            }
            recuser.Dispose();
        }
        public static void LeerDatosUsuarioDirectorio()
        {
            string ssql = "SELECT Profesión,NombreImpresion ";
            ssql += " FROM " + datosEmpresa.nombreBaseSis + ".dbo.sys_Usuario left join identificacion on CodUsuario = codigo ";
            ssql += " left join personal on CodigoPer = codigo ";
            ssql += " WHERE Idusuario = '" + DatosUsuario.codigo + "'";
            DataTable recuser = SqlDatos.leerTabla(ssql, datosEmpresa.strConxAdcom);
            if (recuser.Rows.Count > 0)
            {
                DataRow row = recuser.Rows[0];
                DatosUsuario._nombre = row["NombreImpresion"].ToString();
                DatosUsuario._Profesion = row["Profesión"].ToString();
                if (DatosUsuario._nombre.Trim().Length == 0) DatosUsuario._nombre = DatosUsuario._codigo;
            }
            recuser.Dispose();
        }
        public static int VerificaClave()
        {
            DateTime fecha = DateTime.Now;
            int Dias = 0;
            string auxiliar = "";
            int bakVerificaClave = 0;

            auxiliar = "SELECT IdUsuario,codUsuario,FechaInicio, FechaCaduca, Contraseña, FechaCambioContra, DíasDuraContraseña";
            auxiliar += " FROM sys_Usuario WHERE Idusuario = '" + DatosUsuario._codigo + "'";
            DataTable recuser = SqlDatos.leerTabla(auxiliar, datosEmpresa.strConIniSis);
            if (recuser.Rows.Count == 0) { bakVerificaClave = 1; }
            else
            {
                DataRow row = recuser.Rows[0];
                if (row["Contraseña"] == null) { bakVerificaClave = 9; }
                else if (row["Contraseña"].ToString().Length == 0) { bakVerificaClave = 9; }
                else if (row["Contraseña"].ToString() != DatosUsuario.ClaveSecreta) { bakVerificaClave = 2; }

                if (DatosUsuario._codigo.ToUpper() != "ADMINISTRADOR" && DatosUsuario._codigo.ToUpper() != "CONTROL")
                {

                    if (fecha > Convert.ToDateTime(row["FechaCaduca"].ToString())) { bakVerificaClave = 3; }
                    else
                    {
                        TimeSpan tiempo = DateTime.Now - Convert.ToDateTime(row["FechaCambioContra"].ToString());
                        Dias = tiempo.Days;
                        try
                        {
                            if (Dias > Convert.ToInt16(row["DíasDuraContraseña"].ToString())) { bakVerificaClave = 4; }
                        }
                        catch { }
                    }
                }
                if (bakVerificaClave == 0)
                {
                    LeerDatosUsuario(row["IdUsuario"].ToString());
                }

            }
            recuser.Dispose();
            return bakVerificaClave;
        }


        public static string DocsUsr(string tiposDocumento) //tipos de documentos varios entra separados por ";"
        {

            string cod = "";
            SqlDataAdapter da = new SqlDataAdapter();
            string separador = "";

            if (DatosUsuario._codigo.ToUpper() == "ADMINISTRADOR" || DatosUsuario._codigo.ToUpper() == "CONTROL")
            {
                cod = "SELECT opc_documento as CodDocumento FROM AdcOpc where opc_documento > '' ";
                //cod += " and IdEmpresa = " + datosEmpresa.Emp_codigo;
                da = new SqlDataAdapter(cod, datosEmpresa.strConxAdcom);
            }
            else
            {
                cod = "SELECT codDocumento FROM  " + datosEmpresa.nombreBaseSis + ".dbo.sys_Documentos LEFT JOIN AdcOpc on CodDocumento = adcopc.Opc_documento ";
                cod += " WHERE IdUsuario= @codUsr AND IdEmpresa = @codEmp ";
                da = new SqlDataAdapter(cod, datosEmpresa.strConxAdcom);
                da.SelectCommand.Parameters.AddWithValue("@codEmp", datosEmpresa.Emp_codigo);
                da.SelectCommand.Parameters.AddWithValue("@codUsr", DatosUsuario.codigo);

            }
            if (tiposDocumento.Length > 0)
            {
                string[] tipDoc;
                tipDoc = tiposDocumento.Split(Convert.ToChar(";"));
                string selecTipo = "";
                for (Int16 i = 0; i < tipDoc.Length; i++)
                {
                    selecTipo += "'" + tipDoc[i] + "'" + separador;
                    separador = ",";
                }
                if (selecTipo.Length > 0) cod += " and opc_tipo in (" + selecTipo + ")";
            }
            DataTable dt = new DataTable();
            da.Fill(dt);
            cod = "";
            separador = "";
            foreach (DataRow row in dt.Rows)
            {
                cod += separador + row["codDocumento"].ToString();
                separador = " ";
            }
            dt.Dispose();
            da.Dispose();

            return cod;
        }

        public static string SucsUsr()
        {
            string cod = "";
            SqlDataAdapter da = new SqlDataAdapter();
            string separador = "";

            if (DatosUsuario._codigo.ToUpper() == "ADMINISTRADOR" || DatosUsuario._codigo.ToUpper() == "CONTROL")
            {
                cod = "SELECT 'S' AS AutorizaSuc, suc_codigo as CodSucursal FROM emp_suc where emp_codigo = @codEmp";
                da = new SqlDataAdapter(cod, datosEmpresa.strConIniSis);
                da.SelectCommand.Parameters.AddWithValue("@codEmp", datosEmpresa.Emp_codigo);
            }
            else
            {
                cod = "SELECT AutorizaSuc, codSucursal FROM sys_Sucursales WHERE IdUsuario=@codUsr AND IdEmpresa = @codEmp";
                da = new SqlDataAdapter(cod, datosEmpresa.strConIniSis);
                da.SelectCommand.Parameters.AddWithValue("@codEmp", datosEmpresa.Emp_codigo);
                da.SelectCommand.Parameters.AddWithValue("@codUsr", DatosUsuario.codigo);
            }
            DataTable dt = new DataTable();

            da.Fill(dt);
            cod = "";
            separador = "";
            foreach (DataRow row in dt.Rows)
            {
                cod += separador + row["CodSucursal"].ToString();
                separador = " ";
                if (DatosUsuario._codigo.ToUpper() != "ADMINISTRADOR" && DatosUsuario._codigo.ToUpper() != "CONTROL")
                    if (row["AutorizaSuc"].ToString() == "S" || DatosUsuario.SucDef == "") { DatosUsuario._SucDef = row["CODSUCURSAL"].ToString(); }

                DatosUsuario._NumSuc++;
            }
            dt.Dispose();
            da.Dispose();
            return cod;

        }

        public static string BodsUsr()
        {
            string cod = "";
            string bods = "";
            SqlDataAdapter da = new SqlDataAdapter();
            string separador = "";

            if (DatosUsuario._codigo.ToUpper() == "ADMINISTRADOR" || DatosUsuario._codigo.ToUpper() == "CONTROL")
            {
                cod = "SELECT bod_codigo as CodBodega, 'S' AS Autorizabod FROM emp_bod where emp_codigo = @codEmp";
            }
            else
            {
                cod = "SELECT CodBodega, Autorizabod FROM sys_Bodegas WHERE IdUsuario= @codUsr AND IdEmpresa= @codEmp";
            }
            da = new SqlDataAdapter(cod, datosEmpresa.strConIniSis);
            da.SelectCommand.Parameters.AddWithValue("@codEmp", datosEmpresa.Emp_codigo);
            da.SelectCommand.Parameters.AddWithValue("@codUsr", DatosUsuario.codigo);
            DataTable dt = new DataTable();
            da.Fill(dt);
            separador = "";
            foreach (DataRow row in dt.Rows)
            {
                bods += separador + row["CodBodega"].ToString();
                separador = " ";
                if (DatosUsuario._codigo.ToUpper() != "ADMINISTRADOR" && DatosUsuario._codigo.ToUpper() != "CONTROL")
                    if (row["Autorizabod"].ToString() == "S" || row["Autorizabod"].ToString() == "T" || DatosUsuario.SucDef == "") { DatosUsuario._SucDef = row["CODBodega"].ToString(); }
                DatosUsuario._NumBod++;
            }
            dt.Dispose();
            da.Dispose();

            cod = "SELECT * FROM emp_Bod WHERE emp_codigo =" + datosEmpresa.Emp_codigo + " and suc_codigo ='" + DatosUsuario._SucDef + "' ";
            SqlDataReader recuser = SqlDatos.leerBase(cod, datosEmpresa.strConIniSis);
            if (recuser.Read()) { DatosUsuario._BodDef = recuser["Bod_Codigo"].ToString(); }
            else { DatosUsuario._BodDef = ""; }
            recuser.Close();
            return bods;
        }
        public static string TipoAccDoc(string opcDoc)
        {
            if (DatosUsuario._codigo.ToUpper() == "ADMINISTRADOR" || DatosUsuario._codigo.ToUpper() == "CONTROL") return "T";
            string cod = "";
            SqlDataAdapter da = new SqlDataAdapter();
            cod = "SELECT Cambios FROM sys_documentos WHERE IdUsuario= @codUsr AND IdEmpresa= @codEmp and CodDocumento = @opcDoc ";
            da = new SqlDataAdapter(cod, datosEmpresa.strConIniSis);
            da.SelectCommand.Parameters.AddWithValue("@codEmp", datosEmpresa.Emp_codigo.ToString());
            da.SelectCommand.Parameters.AddWithValue("@codUsr", DatosUsuario.codigo);
            da.SelectCommand.Parameters.AddWithValue("@opcDoc", opcDoc);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0) cod = dt.Rows[0]["Cambios"].ToString();
            dt.Dispose();
            da.Dispose();
            return cod;
        }
        public static string TipoAccOp(string IdNomOpcion)
        {
            if (DatosUsuario._codigo.ToUpper() == "ADMINISTRADOR" || DatosUsuario._codigo.ToUpper() == "CONTROL") return "T";
            string cod = "";
            SqlDataAdapter da = new SqlDataAdapter();
            cod = "SELECT Accesos FROM sys_Accesos WHERE IdUsuario= @codUsr AND IdEmpresa= @codEmp and IdNomOpcion = @IdNomOpcion ";
            da = new SqlDataAdapter(cod, datosEmpresa.strConIniSis);
            da.SelectCommand.Parameters.AddWithValue("@codEmp", datosEmpresa.Emp_codigo);
            da.SelectCommand.Parameters.AddWithValue("@codUsr", DatosUsuario.codigo);
            da.SelectCommand.Parameters.AddWithValue("@idNom", IdNomOpcion);

            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0) cod = dt.Rows[0]["Accesos"].ToString();
            dt.Dispose();
            da.Dispose();
            return cod;
        }
    }
}
