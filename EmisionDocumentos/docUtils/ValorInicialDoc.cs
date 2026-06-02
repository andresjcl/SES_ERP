using System;
using System.Data;
using System.Data.SqlClient;

namespace adcDocumentos
{
    public class valoresPredefinidosSucursal
    {
        public string idtributario = "001-001";
        public string idtributarioSucursal = "001";
        public string idtributarioPtoVta = "001";
        public Int32 precioSucursal = 0;
        public Boolean autCambiaPtoVta = true;
        public string idPuntoVta = "";
        public string nomPuntoVta = "";
    }

    static public class predefinidosSUC
    {
        internal static valoresPredefinidosSucursal valsuc = new adcDocumentos.valoresPredefinidosSucursal();

        static public valoresPredefinidosSucursal cargarValores(string empresa, string sucursal, string usuario, string strsys)
        {
            valsuc = new adcDocumentos.valoresPredefinidosSucursal();
            valsuc.idPuntoVta = puntoDeVentas(empresa, sucursal, usuario, strsys);
            valsuc.idtributario = idTributario(empresa, sucursal, valsuc.idPuntoVta, strsys);
            return valsuc;
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
                    if (dt.Rows[0]["CodPtoVta"].ToString()=="SI") valsuc.autCambiaPtoVta = true; else valsuc.autCambiaPtoVta = false;
                }
                da.Dispose();
            }


            // obtenemos datos del punto de venta anterior o leemos todos los puntos de venta de la sucursal y escojemos el primero en orden alfabetico

            {
                ssql = "select Pto_codigo , Pto_nombre  from emp_ptovta where emp_codigo = '" + empresa + "' and suc_codigo = '" + sucursal + "' ";
                if (ptoVta.Length != 0)
                {
                    ssql += " and pto_codigo = '" + ptoVta + "' ";
                }
                else
                {
                    ssql += " order by Pto_Nombre";
                    valsuc.autCambiaPtoVta  = true;
                }

                using (SqlDataAdapter da = new SqlDataAdapter(ssql, strsys))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count == 0)
                    {
                        ptoVta = Environment.MachineName;
                        valsuc.autCambiaPtoVta = true;
                        valsuc.nomPuntoVta = ptoVta;
                    }
                    else
                    {
                        ptoVta = dt.Rows[0]["Pto_Codigo"].ToString();
                        valsuc.nomPuntoVta = dt.Rows[0]["Pto_nombre"].ToString();
                    }
                    da.Dispose();
                }
                return ptoVta;
            }
        }
        static internal string idTributario(string empresa, string sucursal, string puntoVtas, string strsys)
        {
            string idTvta = "";
            string idTSuc = "";
            string ssql = "select isnull(Suc_IdTributario,'') as Suc_IdTributario,isnull(Pto_IDTributario,'') as Pto_IDTributario  from Emp_Suc left join Emp_PtoVta ";
            ssql += " on emp_suc.Emp_Codigo = Emp_PtoVta.Emp_Codigo and emp_suc.Suc_Codigo = Emp_PtoVta.Suc_Codigo ";
            ssql += " where emp_suc.Emp_Codigo = '" + empresa + "' and emp_suc.Suc_Codigo = '" + sucursal + "' and Pto_codigo = '" + puntoVtas + "' ";

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

            valsuc.idtributarioPtoVta = idTvta;
            valsuc.idtributarioSucursal = idTSuc;

            if (idTvta.Length == 3 && idTSuc.Length == 3) valsuc.idtributario = idTSuc + "-" + idTvta;
            if (idTvta.Length > 3 && idTvta.IndexOf("-") == 3) valsuc.idtributario = idTvta;
            if (idTSuc.Length > 3 && idTSuc.IndexOf("-") == 3) valsuc.idtributario = idTSuc;

            return valsuc.idtributario;
        }
        //public predefinidosSUC(string strsys, string sucursal, Int32 empresa)
        //{         
        //    string ssql = "select isnull(suc_idtributario,'') as suc_idtributario,isnull(precioVta,0) as precioVta from emp_suc where suc_codigo = '" + sucursal + "' and emp_codigo = " + empresa.ToString();
        //    using (SqlDataAdapter da = new SqlDataAdapter(ssql ,strsys))
        //    {
        //        using (DataTable dt = new DataTable())
        //        {
        //            da.Fill(dt);
        //            if (dt.Rows.Count > 0)
        //            {
        //                idtributarioSucursal = dt.Rows[0]["suc_idtributario"].ToString();
        //                precioSucursal = Convert.ToInt32(dt.Rows[0]["precioVta"]);
        //            }
        //        }
        //    }
        //    if (buscarIdTributarioPorNombreMaquina(strsys,sucursal,empresa) == false)
        //    {
        //        if (buscarIdTributarioPorNombreSucursal(strsys,sucursal,empresa) == false)
        //        {
        //            if (buscarPrimerIdTributarioPorPtoExistente(strsys,sucursal,empresa) == false)
        //            {idtributarioPtoVta = "001";}
        //        }
        //    }
        //    idtributario = idtributarioSucursal + "-" + idtributarioPtoVta;
        //}   
        //private Boolean buscarIdTributarioPorNombreSucursal(string strsys, string sucursal, Int32 empresa)
        //{
        //    Boolean resp=false;
        //    using (SqlDataAdapter da2 = new SqlDataAdapter("select isnull(pto_idtributario,'') as pto_idtributario from Emp_PtoVta where pto_codigo = '" + sucursal + "' and suc_codigo = '" + sucursal + "' and emp_codigo = " + empresa.ToString(), strsys))
        //    {
        //        using (DataTable dt = new DataTable())                
        //        {
        //            da2.Fill(dt);                   
        //            if (dt.Rows.Count > 0)
        //            {
        //                idtributarioPtoVta = dt.Rows[0]["pto_idtributario"].ToString();
        //                resp = true;
        //            }
        //        }
        //    }
        //    return resp;
        // }
        //private Boolean buscarPrimerIdTributarioPorPtoExistente(string strsys, string sucursal, Int32 empresa)
        //{
        //    Boolean resp = false;
        //    using (SqlDataAdapter da2 = new SqlDataAdapter("select isnull(pto_idtributario,'') as pto_idtributario from Emp_PtoVta where pto_codigo = '" + sucursal + "' and suc_codigo = '" + sucursal + "' and emp_codigo = " + empresa.ToString(), strsys))
        //    {
        //        using (DataTable dt = new DataTable())
        //        {
        //            da2.Fill(dt);
        //            if (dt.Rows.Count > 0)
        //            {
        //                idtributarioPtoVta = dt.Rows[0]["pto_idtributario"].ToString();
        //                resp = true;
        //            }
        //        }
        //    }
        //    return resp;
        //}        
    }
}
