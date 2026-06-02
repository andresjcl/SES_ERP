using System;
using System.Data;
using System.Data.SqlClient;

namespace DattCom
{
	public class ManejoDatosEmpresa
    {
        public static void LeerDatosEmpresa(string strConIniSis, string usrBd, string claveBd, string servidor)
        {
            if (datosEmpresa.Emp_codigo == 0) { leerCodigoRegistrado(); }
            string ssql = "SELECT Emp_Datos.Emp_codigo,   Emp_Nombre,   Emp_Ciudad,   Emp_Telefono_1,   Emp_Email,   Emp_RUC,  ";
            ssql += "Emp_RepLegal,   Emp_Logotipo,Emp_Conta,Emp_AgeRet,Emp_ContrBuyEsp,Emp_Regimen, Par_RolCodMay,Par_SucPri,   Par_Numerodigitos, isnull(Par_CruceDocSucursal,0) as Par_CruceDocSucursal, ";
            ssql += "Par_DigitosCostos,   Par_DigitosPrecios,   par_PathImagenes,  Emp_Par.Emp_PathImagenes, path_tmpServer, isnull(LongCodDirectorio,0) as LongCodDirectorio, ";
            ssql += "Emp_Dirección,   Emp_Contador,   CtaLocalEmail, Arch_tipo, Arch_Nom ";
            ssql += "FROM Emp_Datos LEFT OUTER JOIN Emp_Par ON Emp_Datos.Emp_codigo = emp_par.emp_codigo ";
            ssql += " left outer join Emp_arch on emp_datos.emp_codigo = emp_arch.emp_codigo ";
            //if (Emp_codigo == 0) { ssql += " WHERE Emp_Datos.Emp_RUC = '" + Emp_RUC + "' "; }
            ssql += " WHERE Emp_Datos.Emp_Codigo = " + datosEmpresa._codigoEmpresa.ToString();
            ssql += " order by Emp_Datos.emp_codigo desc ";
            DataTable dt = new DataTable();
            try
            {
                using (SqlDataAdapter da = new SqlDataAdapter(ssql, strConIniSis))
                {
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                dt = null;
                string msj = ex.Message;
                if (msj.Length > 250) msj = msj.Substring(0, 250);
                AuditSis.registrar.registraEventoMail(strConIniSis, "0", "sys", "SysEmpDat", "SERVIDOR", "LeerDatosEmp", msj);
            }
            int ind = 0;
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    if (ind == 0)
                    {
                        //            Emp_codigo = Convert.ToInt32(dt.Rows[0]["Emp_codigo"]);
                        datosEmpresa._Emp_Nombre = dt.Rows[0]["Emp_Nombre"].ToString();
                        datosEmpresa._Emp_Ciudad = dt.Rows[0]["Emp_Ciudad"].ToString();
                        datosEmpresa._Emp_Telefono_1 = dt.Rows[0]["Emp_Telefono_1"].ToString();
                        datosEmpresa._Emp_Email = dt.Rows[0]["Emp_Email"].ToString();
                        datosEmpresa._Emp_RUC = dt.Rows[0]["Emp_RUC"].ToString();
                        datosEmpresa._Emp_Logotipo = dt.Rows[0]["Emp_Logotipo"].ToString();

                        int longitud = dt.Rows[0]["Emp_PathImagenes"].ToString().Length;

                        if (longitud > 0)
                        {
                            datosEmpresa._Emp_PathImagenes = dt.Rows[0]["Emp_PathImagenes"].ToString();
                            if (datosEmpresa._Emp_PathImagenes.Substring(longitud - 1, 1) != "\\") datosEmpresa._Emp_PathImagenes += "\\";
                        }
                        datosEmpresa._Par_RolCodMay = dt.Rows[0]["Par_RolCodMay"].ToString();
                        datosEmpresa._Par_Numerodigitos = Convert.ToInt16(dt.Rows[0]["Par_Numerodigitos"].ToString());
                        datosEmpresa._Par_DigitosCostos = Convert.ToInt16(dt.Rows[0]["Par_DigitosCostos"].ToString());
                        datosEmpresa._Par_DigitosPrecios = Convert.ToInt16(dt.Rows[0]["Par_DigitosPrecios"].ToString());
                        datosEmpresa._path_tmpServer = dt.Rows[0]["path_tmpServer"].ToString();
                        datosEmpresa._Emp_Dirección = dt.Rows[0]["Emp_Dirección"].ToString();
                        datosEmpresa._CtaLocalEmail = dt.Rows[0]["CtaLocalEmail"].ToString();
                        datosEmpresa._Par_SucPri = dt.Rows[0]["Par_SucPri"].ToString();
                        datosEmpresa._LongCodDirectorio = Convert.ToInt16(dt.Rows[0]["LongCodDirectorio"].ToString());
                        datosEmpresa._Par_CruceDocSucursal = Convert.ToBoolean(dt.Rows[0]["Par_CruceDocSucursal"]);
                        //datosEmpresa._Emp_Conta = Convert.ToBoolean(dt.Rows[0]["Emp_Conta"]);
                        datosEmpresa._Emp_Conta = dt.Rows[0]["Emp_Conta"] != DBNull.Value ? Convert.ToBoolean(dt.Rows[0]["Emp_Conta"]): false;
                        datosEmpresa._Emp_AgeRet= dt.Rows[0]["Emp_AgeRet"].ToString();
                        datosEmpresa._Emp_ContrBuyEsp=dt.Rows[0]["Emp_ContrBuyEsp"].ToString();
                        datosEmpresa._Emp_Regimen = dt.Rows[0]["Emp_Regimen"].ToString();

                        ind = 1;
                    }
                    if (row["Arch_tipo"].ToString().ToUpper() == "ADC") datosEmpresa.nombreBaseAdcom = row["Arch_Nom"].ToString();
                    if (row["Arch_tipo"].ToString().ToUpper() == "SRI") datosEmpresa.nombreBaseIvaret = row["Arch_Nom"].ToString();
                    if (row["Arch_tipo"].ToString().ToUpper() == "PRO") datosEmpresa.nombreBaseDaxpro = row["Arch_Nom"].ToString();


                }
                datosEmpresa._servidor = servidor;
                datosEmpresa.ClaveBd = claveBd;
                datosEmpresa._UsuarioBd = usrBd;
                datosEmpresa._strConxAdcom = SqlDatos.ArmStr(datosEmpresa.nombreBaseAdcom, servidor, "10", claveBd, usrBd);
                datosEmpresa.strConxDaxpro = SqlDatos.ArmStr(datosEmpresa.nombreBaseDaxpro, servidor, "10", claveBd, usrBd);
                datosEmpresa._strConxIvaret = SqlDatos.ArmStr(datosEmpresa.nombreBaseIvaret, servidor, "10", claveBd, usrBd);
                datosEmpresa.strConxAdcom6 = SqlDatos.ArmStr(datosEmpresa.nombreBaseAdcom, servidor, "6", claveBd, usrBd);
                datosEmpresa.strConIniSis6 = SqlDatos.ArmStr(strConIniSis, servidor, "6", claveBd, usrBd);
                datosEmpresa.strConIniSis = strConIniSis;
                //string aa= VarCom.strConxAdcom.Replace("AAAA", VarCom.nombreBaseAdcom);
                //VarCom.strConxAdcom = reemplazoNombreBase(VarCom.strConxAdcom, VarCom.nombreBaseAdcom);
                //aa = VarCom.strConxIvaret.Replace("AAAA", VarCom.nombreBaseIvaret);
                //VarCom.strConxIvaret = reemplazoNombreBase(VarCom.strConxIvaret, VarCom.nombreBaseIvaret); ;
            }
            dt.Dispose();
            cargarSucursalYbodegaDefaul(strConIniSis);
            datoscierre(datosEmpresa.strConxAdcom);
        }
        static string reemplazoNombreBase(string cadena, string nvoValor)
        {
            string aa = cadena.Replace("AAAA", nvoValor);
            return aa;
        }
        static private void datoscierre(string StrConxAdcom)
        {
            string ssql = "SELECT Cie_ConUltAnu from adccie  ";
            DataTable dt = new DataTable();
            try
            {
                using (SqlDataAdapter da = new SqlDataAdapter(ssql, StrConxAdcom))
                {
                    da.Fill(dt);
                }
            }
            catch
            {
                dt = null;
            }
            if (dt != null)
            {
                {
                    try
                    {
                        datosEmpresa._ultimoCierre = Convert.ToDateTime(dt.Rows[0]["Cie_ConUltAnu"].ToString());
                    }
                    catch { }
                }
            }
        }

        static private void datosElectronicos(string strConxAdcom)
        {
            string ssql = "SELECT ambienteEnProduccion,   pathFirmaElectronica,   pathCpbGenerados,   pathCpbFirmados,  ";
            ssql += "pathCpbAutorizados,   pathpbNoAutorizados,   claveFirma,   CorreoDefecto,   consumidorFinal ";
            ssql += "FROM AdcFelec";
            DataTable dt = new DataTable();
            try
            {
                using (SqlDataAdapter da = new SqlDataAdapter(ssql, strConxAdcom))
                {
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                dt = null;
                AuditSis.registrar.registraEventoMail(datosEmpresa._strConIniSis, "0", "sys", "SysEmpDat", "SERVIDOR", "LeerDatosElectronicos", ex.Message.Substring(0, 250));
            }

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    datosEmpresa._ambienteEnProduccion = Convert.ToInt16(dt.Rows[0]["ambienteEnProduccion"]);
                    datosEmpresa._pathFirmaElectronica = dt.Rows[0]["pathFirmaElectronica"].ToString();
                    datosEmpresa._pathCpbGenerados = dt.Rows[0]["pathCpbGenerados"].ToString();
                    datosEmpresa._pathCpbFirmados = dt.Rows[0]["pathCpbFirmados"].ToString();
                    datosEmpresa._pathCpbAutorizados = dt.Rows[0]["pathCpbAutorizados"].ToString();
                    datosEmpresa._pathpbNoAutorizados = dt.Rows[0]["pathpbNoAutorizados"].ToString();
                    datosEmpresa._claveFirma = dt.Rows[0]["claveFirma"].ToString();
                    datosEmpresa._CorreoDefecto = dt.Rows[0]["CorreoDefecto"].ToString();
                    datosEmpresa._consumidorFinal = dt.Rows[0]["consumidorFinal"].ToString();
                }
            }
            dt.Dispose();
        }
        private static void leerCodigoRegistrado()
        {
            try
            {
                var dt = new DataSet();
                dt.ReadXml("empcdg.xml");
                datosEmpresa._codigoEmpresa = Convert.ToInt16(dt.Tables[0].Rows[0]["cdg"].ToString());
                DatosUsuario._codigo = dt.Tables[0].Rows[0]["rsu"].ToString();
                dt.Dispose();
            }
            catch { Environment.Exit(0); }
        }
        public static void grabarEmpresaRegistrada(string CodEmp, string CodUsr)
        {
            var dt = new DataTable();
            dt.Columns.Add("cdg");
            dt.Columns.Add("rsu");
            dt.TableName = "empcdg";
            DataRow row = dt.NewRow();
            row["cdg"] = CodEmp;
            row["rsu"] = CodUsr;
            dt.Rows.Add(row);
            dt.WriteXml("empcdg.xml");
            dt.Dispose();
        }
        public static void ResetearEmpresaRegistrada()
        {
            var dt = new DataTable();
            dt.Columns.Add("cdg");
            dt.Columns.Add("rsu");
            dt.TableName = "empcdg";
            DataRow row = dt.NewRow();
            row["cdg"] = "";
            row["rsu"] = "";
            dt.Rows.Add(row);
            dt.WriteXml("empcdg.xml");
            dt.Dispose();
        }
        private static void cargarSucursalYbodegaDefaul(string StrConxSyscod)
        {
            string Aux = "";
            if (datosEmpresa.sucursal.Length > 0) Aux = " and Suc_Codigo='" + datosEmpresa.sucursal + "' ";
            Aux = "SELECT Suc_codigo,Suc_nombre FROM EMP_Suc WHERE Emp_Codigo=" + datosEmpresa.Emp_codigo + Aux;
            SqlDataReader dr = DattCom.SqlDatos.leerBase(Aux, StrConxSyscod);
            if (dr.Read())
            {
                datosEmpresa._Par_SucPri = dr["Suc_Codigo"].ToString();
                datosEmpresa._Par_SucPriNom = dr["Suc_Nombre"].ToString();
                datosEmpresa.suc = datosEmpresa._Par_SucPri;
                datosEmpresa.sucNom = datosEmpresa._Par_SucPriNom;

                //VarCom.suc = datosEmpresa._Par_SucPri;
                //VarCom.sucNom = datosEmpresa._Par_SucPriNom;
            }
            Aux = "SELECT bod_codigo, bod_nombre FROM EMP_Bod WHERE Suc_Codigo='" + datosEmpresa.sucursal + "'  AND Emp_Codigo=" + datosEmpresa.Emp_codigo;
            dr.Close();
            dr = SqlDatos.leerBase(Aux, StrConxSyscod);
            if (dr.Read())
            {
                datosEmpresa._bodPri = dr["bod_codigo"].ToString();
                datosEmpresa._bodPriNom = dr["bod_nombre"].ToString();
            }
            dr.Close();
        }
        private static void cargarSucursalYbodegaCambio(string NvSucursal)
        {

            string Aux = "SELECT Suc_codigo,Suc_nombre FROM EMP_Suc WHERE Emp_Codigo=" + datosEmpresa.Emp_codigo;
            Aux += " and Suc_Codigo='" + NvSucursal + "' ";
            SqlDataReader dr = DattCom.SqlDatos.leerBaseIniSis(Aux);
            if (dr.Read())
            {
                datosEmpresa._Par_SucPri = dr["Suc_Codigo"].ToString();
                datosEmpresa._Par_SucPriNom = dr["Suc_Nombre"].ToString();
                datosEmpresa.suc = datosEmpresa._Par_SucPri;
                datosEmpresa.sucNom = datosEmpresa._Par_SucPriNom;
            }
            Aux = "SELECT bod_codigo, bod_nombre FROM EMP_Bod WHERE Suc_Codigo='" + datosEmpresa.sucursal + "'  AND Emp_Codigo=" + datosEmpresa.Emp_codigo;
            dr.Close();
            dr = SqlDatos.leerBaseIniSis(Aux);
            if (dr.Read())
            {
                datosEmpresa._bodPri = dr["bod_codigo"].ToString();
                datosEmpresa._bodPriNom = dr["bod_nombre"].ToString();
            }
            dr.Close();
        }
    }
}
