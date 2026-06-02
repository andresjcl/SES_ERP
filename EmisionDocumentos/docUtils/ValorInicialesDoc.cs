using System;
using System.Data;
using System.Data.SqlClient;
using SysEmpDatt;

namespace adcDocumentos
{
    public static class valoresPredefinidosEmpresa
    {
        public static Int16 codemp = 0;
        public static Int16 nroDigitosEnPrecios = 0;
        public static Int16 nroDigitosEnCostos = 0;
        public static string formaPagoPredefinidaVtas = "EFE";
        public static Boolean permiteCruceDocOtraSucursal = false;
        public static int nroDescuentosMaximosDocto = 1;
        public static Boolean existenciaEnLineas = false;
        public static Boolean tieneComprobantesElectronicos = false;
        public static string correoElectronicoDefecto = "";
        public static string PathImagenes = "";
        public static int AmbienteFactElctronica = 2;
        static public void cargaValores()
        {
            if (codemp == datosEmpresa.codEmpresa) return;
            DataTable dt = new DataTable();
            codemp = datosEmpresa.codEmpresa;
            dt = datosEmpresa.leeParametrosEmp("Emp_PathImagenes,par_DigitosPrecios,par_DigitosCostos,Par_DocPrincipalVta,par_CruceDocSucursal,Par_AcfNumNiv,Par_roltur");
            if (dt.Rows.Count > 0)
            {
                nroDigitosEnPrecios = Convert.ToInt16("0" + dt.Rows[0]["par_DigitosPrecios"].ToString());
                nroDigitosEnCostos = Convert.ToInt16(dt.Rows[0]["par_DigitosCostos"].ToString());
                formaPagoPredefinidaVtas = dt.Rows[0]["Par_DocPrincipalVta"].ToString();
                permiteCruceDocOtraSucursal = Convert.ToBoolean(dt.Rows[0]["par_CruceDocSucursal"]);
                nroDescuentosMaximosDocto = Convert.ToInt16(dt.Rows[0]["Par_AcfNumNiv"].ToString());
                PathImagenes = dt.Rows[0]["Emp_PathImagenes"].ToString();
                if (Convert.ToInt16(dt.Rows[0]["Par_roltur"]) == 99)
                {
                    existenciaEnLineas = true;
                }
                else
                {
                    existenciaEnLineas = false;
                }
            }
            dt.Dispose();
            dt = new DataTable();
            try
            {
                using (SqlDataAdapter da = new SqlDataAdapter("select isnull(pathFirmaElectronica,'') as pathFirmaElectronica, isnull(claveFirma,'') as ClaveFirma, isnull(CorreoDefecto,'') as CorreoDefecto,isnull(ambienteEnProduccion,0) as ambienteEnProduccion  from adcfelec", datosEmpresa.strConxAdcom))
                {
                    da.Fill(dt);
                    if (dt.Rows.Count > 0 && dt.Rows[0]["ClaveFirma"].ToString().Length > 0)
                    {
                        tieneComprobantesElectronicos = impresionVerificacion.validaComprobantesElectronicos(dt.Rows[0]["pathFirmaElectronica"].ToString());
                        if (tieneComprobantesElectronicos)
                        correoElectronicoDefecto = dt.Rows[0]["CorreoDefecto"].ToString();
                        if (Convert.ToInt16(dt.Rows[0]["ambienteEnProduccion"]) == 0) AmbienteFactElctronica = 1;
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
            idPuntoVta = puntoDeVentas(datosEmpresa.codEmpresa.ToString(), datosEmpresa.suc, datosEmpresa.usr, datosEmpresa.strConxDaxsys);
            idtributario = idTributario(datosEmpresa.codEmpresa.ToString(), datosEmpresa.suc, idPuntoVta,datosEmpresa.strConxDaxsys);
        }
        static internal string puntoDeVentas(string empresa, string sucursal, string usuario, string strsys)
        {
            string ptoVta = "";
            string ssql = "select CodptoVta,AutorizaPtoVta  from sys_ptoVta where idempresa = '" + empresa + "' and codSucursal = '" + sucursal + "' and idUsuario = '" + usuario + "' ";

            // obtener punto de ventas al que esta asignado un usuario obligatoriamente

            using (SqlDataAdapter da = new SqlDataAdapter(ssql, strsys))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    ptoVta = dt.Rows[0]["CodPtoVta"].ToString();
                    if (dt.Rows[0]["autorizaPtoVta"].ToString()=="SI") autCambiaPtoVta = true; else autCambiaPtoVta = false;
                }
                da.Dispose();
            }

            //si no esta asignado un punto de ventas obligatorio probamos con el nombre del computador
            if (ptoVta.Length == 0)
            {
                ssql = "select Pto_codigo , Pto_nombre  from emp_ptovta where emp_codigo = '" + empresa + "' and suc_codigo = '" + sucursal + "' ";
                ssql += " and pto_nombre = '" + Environment.MachineName + "' ";
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

            //  obtenemos datos del punto de venta anterior o leemos todos los puntos de venta de la sucursal y escojemos el primero en orden alfabetico

            {
                ssql = "select Pto_codigo , Pto_nombre, TipoPunto, pto_IdTributario from emp_ptovta where emp_codigo = '" + empresa + "' and suc_codigo = '" + sucursal + "' ";
                if (ptoVta.Length != 0)
                {
                    ssql += " and pto_codigo = '" + ptoVta + "' ";
                }
                else
                {
                    ssql += " order by Pto_Nombre";
                    autCambiaPtoVta  = true;
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
                        ptoVta = dt.Rows[0]["Pto_Codigo"].ToString();
                        nomPuntoVta = dt.Rows[0]["Pto_nombre"].ToString();
                        tipoPunto = dt.Rows[0]["TipoPunto"].ToString();
                    }
                    da.Dispose();
                }
                idPuntoVta = ptoVta;
                return ptoVta;
            }
        }
        static public string idTributario(string empresa, string sucursal, string puntoVtas, string strsys)
        {
            string idTvta = "";
            string idTSuc = "";
            string ssql = "select isnull(Suc_IdTributario,'') as Suc_IdTributario,isnull(Pto_IDTributario,'') as Pto_IDTributario  from Emp_Suc left join Emp_PtoVta ";
            ssql += " on emp_suc.Emp_Codigo = Emp_PtoVta.Emp_Codigo and emp_suc.Suc_Codigo = Emp_PtoVta.Suc_Codigo ";
            ssql += " where emp_suc.Emp_Codigo = '" + empresa + "' and emp_suc.Suc_Codigo = '" + sucursal + "' and (Pto_nombre = '" + puntoVtas + "' or pto_codigo = '" + puntoVtas + "')";

            using (SqlDataAdapter da = new SqlDataAdapter(ssql, strsys))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count != 0)
                {
                    idTvta = dt.Rows[0]["pto_idtributario"].ToString();
                    idTSuc = dt.Rows[0]["Suc_IdTributario"].ToString();
                }
                da.Dispose();
            }           

            idtributarioPtoVta = idTvta;
            idtributarioSucursal = idTSuc;

            if (idTvta.Length == 3 && idTSuc.Length == 3) idtributario = idTSuc + "-" + idTvta;
            if (idTvta.Length > 3 && idTvta.IndexOf("-") == 3) idtributario = idTvta;
            if (idTSuc.Length > 3 && idTSuc.IndexOf("-") == 3) idtributario = idTSuc;

            return idtributario;
        }
    }
}
