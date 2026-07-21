using System;
using System.Data;
using System.Data.SqlClient;
using DattCom;

namespace DctosEmi
{
    public static class valoresPredefinidosEmpresa
    {
        public static Int16 codemp = 0;
        public static Int16 nroDigitosEnPrecios = 6;
        public static Int16 nroDigitosEnCostos = 6;
        public static string formaPagoPredefinidaVtas = "EFE";
        public static Boolean permiteCruceDocOtraSucursal = false;
        public static int nroDescuentosMaximosDocto = 1;
        public static Boolean existenciaEnLineas = false;
        public static Boolean tieneComprobantesElectronicos = false;
        public static string correoElectronicoDefecto = "";
        public static string PathImagenes = "";
        public static int AmbienteFactElctronica = 2;
        public static string Par_ClvDsc = "";
        public static string Par_ClvIVA = "";
        public static DateTime Par_FecDes = DateTime.Now;
        public static int Par_LimAtrasoEntrada = 0;
        public static int Par_LimExtraSalida = 0;
        public static int Par_LimExtraEntrada = 0;
        public static string Par_DocPrincipalVta = "";
        public static string Par_Cheques = "";
        public static string Par_RolCodMay = "";
        public static int Par_RolTur = 0;
        public static string Par_SucPri = "";
        public static string Par_InvTipCierre = "";
        public static string Par_VenIVA = "";
        public static string Par_VenSNEmp = "";
        public static string Par_VenSNAcuDoc = "";
        public static string Par_ComIVA = "";
        public static string Par_ComSNEmp = "";
        public static string Par_ComSNAcuDoc = "";
        public static string Par_AcumHis = "";
        public static int Par_NumeroDigitos = 0;
        public static int Par_AcfNumNiv = 0;
        public static int DefCta_NumNiveles = 0;
        public static int DefCta_NumGrupos = 0;
        public static string DefCta_NumDigNivel = "";
        public static int DefCtaV = 0;
        public static int Emp_DiasMensualesAcf = 0;
        public static string path_tmpServer = "";
        public static string CtaLocalEmail = "";
        public static int Prspto_NumNiveles = 0;
        public static int Prspto_NumGrupos = 0;
        public static string Prspto_NumDigNivel = "";
        public static string par_PathImagenes = "";
        public static int LongCodDirectorio = 0;
        public static int par_ValiDir = 0;
        public static int par_ValiSRI = 0;
        public static string par_UrlSRI = "";
        public static int par_EnvioCorreo = 0;
        public static DateTime par_FechaInicioContrato = DateTime.Now;
        public static int par_DiasContrato = 0;
        public static int par_DiasMensualesAcf = 0;
        public static string Par_ConTipCierre = "";
        public static string Par_TipoCierre = "";

        #region Métodos auxiliares para obtener valores seguros (manejo de DBNull)

        private static T ObtenerValor<T>(SqlDataReader reader, string campo, T valorDefecto)
        {
            try
            {
                object valor = reader[campo];
                if (valor == null || valor == DBNull.Value)
                    return valorDefecto;
                return (T)Convert.ChangeType(valor, typeof(T));
            }
            catch
            {
                return valorDefecto;
            }
        }

        private static string ObtenerString(SqlDataReader reader, string campo, string valorDefecto = "")
        {
            try
            {
                object valor = reader[campo];
                if (valor == null || valor == DBNull.Value)
                    return valorDefecto;
                return valor.ToString();
            }
            catch
            {
                return valorDefecto;
            }
        }

        private static int ObtenerInt(SqlDataReader reader, string campo, int valorDefecto = 0)
        {
            try
            {
                object valor = reader[campo];
                if (valor == null || valor == DBNull.Value)
                    return valorDefecto;
                return Convert.ToInt32(valor);
            }
            catch
            {
                return valorDefecto;
            }
        }

        private static Int16 ObtenerInt16(SqlDataReader reader, string campo, Int16 valorDefecto = 0)
        {
            try
            {
                object valor = reader[campo];
                if (valor == null || valor == DBNull.Value)
                    return valorDefecto;
                return Convert.ToInt16(valor);
            }
            catch
            {
                return valorDefecto;
            }
        }

        private static bool ObtenerBoolean(SqlDataReader reader, string campo, bool valorDefecto = false)
        {
            try
            {
                object valor = reader[campo];
                if (valor == null || valor == DBNull.Value)
                    return valorDefecto;
                return Convert.ToBoolean(valor);
            }
            catch
            {
                return valorDefecto;
            }
        }

        private static DateTime ObtenerDateTime(SqlDataReader reader, string campo, DateTime valorDefecto)
        {
            try
            {
                object valor = reader[campo];
                if (valor == null || valor == DBNull.Value)
                    return valorDefecto;

                // Si es DateTime
                if (valor is DateTime)
                    return (DateTime)valor;

                // Si es string
                if (valor is string)
                {
                    string fechaStr = valor.ToString();
                    if (DateTime.TryParse(fechaStr, out DateTime fecha))
                        return fecha;
                }

                // Si es número (INT)
                if (valor is int || valor is Int32 || valor is Int16 || valor is Int64)
                {
                    long fechaInt = Convert.ToInt64(valor);
                    string fechaStr = fechaInt.ToString();

                    // Formato AAAAMMDD (8 dígitos) - ej: 20260101
                    if (fechaStr.Length == 8)
                    {
                        int año = Convert.ToInt32(fechaStr.Substring(0, 4));
                        int mes = Convert.ToInt32(fechaStr.Substring(4, 2));
                        int dia = Convert.ToInt32(fechaStr.Substring(6, 2));
                        return new DateTime(año, mes, dia);
                    }
                    // Formato AAMMDD (6 dígitos) - ej: 260101
                    else if (fechaStr.Length == 6)
                    {
                        int año = 2000 + Convert.ToInt32(fechaStr.Substring(0, 2));
                        int mes = Convert.ToInt32(fechaStr.Substring(2, 2));
                        int dia = Convert.ToInt32(fechaStr.Substring(4, 2));
                        return new DateTime(año, mes, dia);
                    }
                    // Formato DDMMAAAA (8 dígitos) - ej: 01012026
                    else if (fechaStr.Length == 8)
                    {
                        try
                        {
                            int dia = Convert.ToInt32(fechaStr.Substring(0, 2));
                            int mes = Convert.ToInt32(fechaStr.Substring(2, 2));
                            int año = Convert.ToInt32(fechaStr.Substring(4, 4));
                            return new DateTime(año, mes, dia);
                        }
                        catch { }
                    }
                }

                return valorDefecto;
            }
            catch
            {
                return valorDefecto;
            }
        }

        #endregion

        static public void cargaValores()
        {
            if (codemp == datosEmpresa.codEmpresa) return;

            codemp = datosEmpresa.codEmpresa;

            try
            {
                string baseDatosSis = datosEmpresa.nombreBaseSis ?? "DaxsysAsofarmadis";

                string sql = @"
                    SELECT 
                        Emp_PathImagenes,
                        par_DigitosPrecios,
                        par_DigitosCostos,
                        Par_PagoCompras,
                        par_CruceDocSucursal,
                        Par_AcfNumNiv,
                        Par_roltur,
                        Par_ClvDsc,
                        Par_ClvIVA,
                        Par_FecDes,
                        Par_LimAtrasoEntrada,
                        Par_LimExtraSalida,
                        Par_LimExtraEntrada,
                        Par_DocPrincipalVta,
                        Par_Cheques,
                        Par_RolCodMay,
                        Par_SucPri,
                        Par_InvTipCierre,
                        Par_VenIVA,
                        Par_VenSNEmp,
                        Par_VenSNAcuDoc,
                        Par_ComIVA,
                        Par_ComSNEmp,
                        Par_ComSNAcuDoc,
                        Par_AcumHis,
                        Par_NumeroDigitos,
                        DefCta_NumNiveles,
                        DefCta_NumGrupos,
                        DefCta_NumDigNivel,
                        DefCtaV,
                        Emp_DiasMensualesAcf,
                        path_tmpServer,
                        CtaLocalEmail,
                        Prspto_NumNiveles,
                        Prspto_NumGrupos,
                        Prspto_NumDigNivel,
                        par_PathImagenes,
                        LongCodDirectorio,
                        par_ValiDir,
                        par_ValiSRI,
                        par_UrlSRI,
                        par_EnvioCorreo,
                        par_FechaInicioContrato,
                        par_DiasContrato,
                        par_DiasMensualesAcf,
                        Par_ConTipCierre
                    FROM " + baseDatosSis + @".dbo.Emp_Par 
                    WHERE Emp_Codigo = @codEmp";

                using (SqlConnection conn = new SqlConnection(datosEmpresa.strConxAdcom))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@codEmp", datosEmpresa.codEmpresa);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // ============================================
                                // CAMPOS PRINCIPALES
                                // ============================================
                                nroDigitosEnPrecios = ObtenerInt16(reader, "par_DigitosPrecios", 6);
                                nroDigitosEnCostos = ObtenerInt16(reader, "par_DigitosCostos", 6);
                                formaPagoPredefinidaVtas = ObtenerString(reader, "Par_PagoCompras", "EFE");
                                permiteCruceDocOtraSucursal = ObtenerBoolean(reader, "par_CruceDocSucursal", false);
                                nroDescuentosMaximosDocto = ObtenerInt(reader, "Par_AcfNumNiv", 1);
                                PathImagenes = ObtenerString(reader, "Emp_PathImagenes", "");

                                int rolTur = ObtenerInt(reader, "Par_roltur", 0);
                                existenciaEnLineas = (rolTur == 99);

                                // ============================================
                                // CAMPOS DE TEXTO
                                // ============================================
                                Par_ClvDsc = ObtenerString(reader, "Par_ClvDsc", "");
                                Par_ClvIVA = ObtenerString(reader, "Par_ClvIVA", "");
                                Par_DocPrincipalVta = ObtenerString(reader, "Par_DocPrincipalVta", "");
                                Par_Cheques = ObtenerString(reader, "Par_Cheques", "");
                                Par_RolCodMay = ObtenerString(reader, "Par_RolCodMay", "");
                                Par_SucPri = ObtenerString(reader, "Par_SucPri", "");
                                Par_InvTipCierre = ObtenerString(reader, "Par_InvTipCierre", "");
                                Par_VenIVA = ObtenerString(reader, "Par_VenIVA", "");
                                Par_VenSNEmp = ObtenerString(reader, "Par_VenSNEmp", "");
                                Par_VenSNAcuDoc = ObtenerString(reader, "Par_VenSNAcuDoc", "");
                                Par_ComIVA = ObtenerString(reader, "Par_ComIVA", "");
                                Par_ComSNEmp = ObtenerString(reader, "Par_ComSNEmp", "");
                                Par_ComSNAcuDoc = ObtenerString(reader, "Par_ComSNAcuDoc", "");
                                Par_AcumHis = ObtenerString(reader, "Par_AcumHis", "");
                                DefCta_NumDigNivel = ObtenerString(reader, "DefCta_NumDigNivel", "");
                                Prspto_NumDigNivel = ObtenerString(reader, "Prspto_NumDigNivel", "");
                                par_PathImagenes = ObtenerString(reader, "par_PathImagenes", "");
                                par_UrlSRI = ObtenerString(reader, "par_UrlSRI", "");
                                Par_ConTipCierre = ObtenerString(reader, "Par_ConTipCierre", "");
                                path_tmpServer = ObtenerString(reader, "path_tmpServer", "");
                                CtaLocalEmail = ObtenerString(reader, "CtaLocalEmail", "");

                                // ============================================
                                // CAMPOS NUMÉRICOS
                                // ============================================
                                Par_LimAtrasoEntrada = ObtenerInt(reader, "Par_LimAtrasoEntrada", 0);
                                Par_LimExtraSalida = ObtenerInt(reader, "Par_LimExtraSalida", 0);
                                Par_LimExtraEntrada = ObtenerInt(reader, "Par_LimExtraEntrada", 0);
                                Par_RolTur = ObtenerInt(reader, "Par_roltur", 0);
                                Par_NumeroDigitos = ObtenerInt(reader, "Par_NumeroDigitos", 0);
                                Par_AcfNumNiv = ObtenerInt(reader, "Par_AcfNumNiv", 0);
                                DefCta_NumNiveles = ObtenerInt(reader, "DefCta_NumNiveles", 0);
                                DefCta_NumGrupos = ObtenerInt(reader, "DefCta_NumGrupos", 0);
                                DefCtaV = ObtenerInt(reader, "DefCtaV", 0);
                                Emp_DiasMensualesAcf = ObtenerInt(reader, "Emp_DiasMensualesAcf", 0);
                                Prspto_NumNiveles = ObtenerInt(reader, "Prspto_NumNiveles", 0);
                                Prspto_NumGrupos = ObtenerInt(reader, "Prspto_NumGrupos", 0);
                                LongCodDirectorio = ObtenerInt(reader, "LongCodDirectorio", 0);
                                par_ValiDir = ObtenerInt(reader, "par_ValiDir", 0);
                                par_ValiSRI = ObtenerInt(reader, "par_ValiSRI", 0);
                                par_EnvioCorreo = ObtenerInt(reader, "par_EnvioCorreo", 0);
                                par_DiasContrato = ObtenerInt(reader, "par_DiasContrato", 0);
                                par_DiasMensualesAcf = ObtenerInt(reader, "par_DiasMensualesAcf", 0);

                                // ============================================
                                // CAMPOS DE FECHA
                                // ============================================
                                Par_FecDes = ObtenerDateTime(reader, "Par_FecDes", DateTime.Now);
                                par_FechaInicioContrato = ObtenerDateTime(reader, "par_FechaInicioContrato", DateTime.Now);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error cargando parámetros: " + ex.Message);
                nroDigitosEnPrecios = 6;
                nroDigitosEnCostos = 6;
            }

            // ============================================
            // OBTENER DATOS DE COMPROBANTES ELECTRÓNICOS
            // ============================================
            try
            {
                using (SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT ISNULL(pathFirmaElectronica,'') as pathFirmaElectronica, " +
                    "ISNULL(claveFirma,'') as ClaveFirma, " +
                    "ISNULL(CorreoDefecto,'') as CorreoDefecto, " +
                    "ISNULL(ambienteEnProduccion,0) as ambienteEnProduccion " +
                    "FROM adcfelec",
                    datosEmpresa.strConxAdcom))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0 && !string.IsNullOrEmpty(dt.Rows[0]["ClaveFirma"].ToString()))
                    {
                        tieneComprobantesElectronicos = impresionVerificacion.validaComprobantesElectronicos(
                            dt.Rows[0]["pathFirmaElectronica"].ToString());

                        if (tieneComprobantesElectronicos)
                            correoElectronicoDefecto = dt.Rows[0]["CorreoDefecto"].ToString();

                        AmbienteFactElctronica = Convert.ToInt32(dt.Rows[0]["ambienteEnProduccion"]) == 0 ? 1 : 2;
                    }
                }
            }
            catch
            {
                tieneComprobantesElectronicos = false;
                correoElectronicoDefecto = "";
            }
        }
    }

    public static class valoresPredefinidosSucursal
    {
        public static string idtributario = "001-001";
        public static string idtributarioSucursal = "001";
        public static string idtributarioPtoVta = "001";
        public static Int32 precioSucursal = 0;
        public static Boolean autCambiaPtoVta = true;
        public static string idPuntoVta = "";
        public static string nomPuntoVta = "";
        public static string tipoPunto = "";
        private static int empresa = 0;
        private static string sucursal = "";
        private static string usuario = "";

        static public void cargarValores()
        {
            if (datosEmpresa.codEmpresa == empresa && datosEmpresa.suc == sucursal && datosEmpresa.usr == usuario) return;

            empresa = datosEmpresa.codEmpresa;
            sucursal = datosEmpresa.suc;
            usuario = datosEmpresa.usr;

            idPuntoVta = puntoDeVentas(datosEmpresa.codEmpresa.ToString(), datosEmpresa.suc, datosEmpresa.usr, datosEmpresa.strConIniSis);
            idtributario = idTributario(datosEmpresa.codEmpresa.ToString(), datosEmpresa.suc, idPuntoVta, datosEmpresa.strConIniSis);
        }

        static public string puntoDeVentas(string empresa, string sucursal, string usuario, string strsys)
        {
            string ptoVta = "";
            bool esAdmin = usuario.ToUpper() == "ADMINISTRADOR";

            // ==================================================
            // PRIMERO: OBTENER LA CONFIGURACIÓN NORMAL
            // ==================================================

            string ssql = "select CodptoVta, AutorizaPtoVta from sys_ptoVta " +
                          "where idempresa = '" + empresa + "' and codSucursal = '" + sucursal + "' and idUsuario = '" + usuario + "' ";

            using (SqlDataAdapter da = new SqlDataAdapter(ssql, strsys))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    ptoVta = dt.Rows[0]["CodPtoVta"].ToString();
                    autCambiaPtoVta = dt.Rows[0]["autorizaPtoVta"].ToString() == "SI";
                }
                da.Dispose();
            }

            // Si no está asignado un punto de ventas obligatorio, probamos con el nombre del computador
            if (string.IsNullOrEmpty(ptoVta))
            {
                ssql = "select Pto_codigo, Pto_nombre from emp_ptovta " +
                       "where emp_codigo = '" + empresa + "' and suc_codigo = '" + sucursal + "' " +
                       "and pto_nombre = '" + Environment.MachineName + "' ";

                using (SqlDataAdapter da = new SqlDataAdapter(ssql, strsys))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        ptoVta = dt.Rows[0]["Pto_codigo"].ToString();
                        autCambiaPtoVta = false;
                    }
                    da.Dispose();
                }
            }

            // Obtenemos datos del punto de venta
            {
                ssql = "select Pto_codigo, Pto_nombre, TipoPunto, pto_IdTributario from emp_ptovta " +
                       "where emp_codigo = '" + empresa + "' and suc_codigo = '" + sucursal + "' ";

                if (!string.IsNullOrEmpty(ptoVta))
                {
                    ssql += " and pto_codigo = '" + ptoVta + "' ";
                }
                else
                {
                    ssql += " order by Pto_Nombre";
                    autCambiaPtoVta = true;
                }

                using (SqlDataAdapter da = new SqlDataAdapter(ssql, strsys))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count == 0)
                    {
                        ptoVta = Environment.MachineName;
                        autCambiaPtoVta = true;
                        nomPuntoVta = ptoVta;
                        tipoPunto = "";
                    }
                    else
                    {
                        ptoVta = dt.Rows[0]["Pto_codigo"].ToString();
                        nomPuntoVta = dt.Rows[0]["Pto_nombre"].ToString();
                        tipoPunto = dt.Rows[0]["TipoPunto"].ToString();
                    }
                    da.Dispose();
                }

                idPuntoVta = ptoVta;

                // Si es administrador, permitir cambiar punto de venta
                if (esAdmin)
                {
                    autCambiaPtoVta = true;
                }
            }

            return ptoVta;
        }

        static public string idTributario(string empresa, string sucursal, string puntoVtas, string strsys)
        {
            string idTvta = "";
            string idTSuc = "";

            string ssql = "SELECT ISNULL(Suc_IdTributario,'') as Suc_IdTributario, " +
                         "ISNULL(Pto_IDTributario,'') as Pto_IDTributario " +
                         "FROM Emp_Suc " +
                         "LEFT JOIN Emp_PtoVta ON emp_suc.Emp_Codigo = Emp_PtoVta.Emp_Codigo " +
                         "AND emp_suc.Suc_Codigo = Emp_PtoVta.Suc_Codigo " +
                         "WHERE emp_suc.Emp_Codigo = '" + empresa + "' " +
                         "AND emp_suc.Suc_Codigo = '" + sucursal + "' " +
                         "AND (Pto_nombre = '" + puntoVtas + "' OR pto_codigo = '" + puntoVtas + "')";

            using (SqlDataAdapter da = new SqlDataAdapter(ssql, strsys))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    idTvta = dt.Rows[0]["pto_idtributario"].ToString();
                    idTSuc = dt.Rows[0]["Suc_IdTributario"].ToString();
                }
                da.Dispose();
            }

            idtributarioPtoVta = idTvta;
            idtributarioSucursal = idTSuc;

            if (idTvta.Length == 3 && idTSuc.Length == 3)
                idtributario = idTSuc + "-" + idTvta;
            else if (idTvta.Length > 3 && idTvta.IndexOf("-") == 3)
                idtributario = idTvta;
            else if (idTSuc.Length > 3 && idTSuc.IndexOf("-") == 3)
                idtributario = idTSuc;

            return idtributario;
        }
    }
}