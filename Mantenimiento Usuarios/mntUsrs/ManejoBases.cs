using System;
using System.Windows.Forms;
using System.Data.SqlClient ;
using System.Data ;
using System.Linq;
using System.Text;

namespace mntUsrs
{
    class ManejoBases
    {
        public DataTable leerAccesosActuales(string strConxDaxsys,string usr,string emp, string sis)
        {
            string ssql = "select * from sys_accesos where idUsuario = '" + usr + "' and idempresa = " + emp + " and idSistema = '" + sis + "' ";
            DataTable dt = leerTablas(strConxDaxsys, ssql);
            return dt;
        }

        public DataTable leerSucursalesActuales(string strConxDaxsys, string usr, string emp, string sis)
        {
            string ssql = "select isnull(CodSucursal,'') as CodSucursal, isnull(AutorizaSuc,'') as AutorizaSuc from sys_sucursales where idUsuario = '" + usr + "' and idempresa = " + emp  ;
            DataTable dt = leerTablas(strConxDaxsys, ssql);
            return dt;
        }

        public DataTable leerBodegasActuales(string strConxDaxsys, string usr, string emp, string sis)
        {
            string ssql = "select CodSucursal, isnull(CodBodega,'') as CodBodega, isnull(AutorizaBod ,'') as AutorizaBod from sys_Bodegas where idUsuario = '" + usr + "' and idempresa = " + emp;
            DataTable dt = leerTablas(strConxDaxsys, ssql);
            return dt;
        }
        public DataTable leerDocumentosActuales(string strConxDaxsys, string usr, string emp, string sis)
        {
            string ssql = "SELECT IdUsuario, IdEmpresa, CodDocumento, cambios FROM sys_documentos where idUsuario = '" + usr + "' and idempresa = " + emp;
            DataTable dt = leerTablas(strConxDaxsys, ssql);
            return dt;
        }


        public void guardarRegistros(string strConxDaxsys, string usuario,string empresa, string sistema, DataGridView mallaDir)
        {
            string ssql = " where idUsuario = '" + usuario + "' and idempresa = " + empresa + " and idSistema = '" + sistema + "' ";
            ejecutarComando(strConxDaxsys, "delete sys_accesos " + ssql);            

            //ManejoBases manBas = new ManejoBases();
            DataRow nvoRow;
            DataTable dtAccesos = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from  sys_accesos " + ssql, strConxDaxsys);
            da.Fill(dtAccesos);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            string AUX;
            foreach (DataGridViewRow row in mallaDir.Rows)
            {
                string clave="";
                try
                {
                 clave = row.Cells["clave"].Value.ToString();
                }
                catch {};

                AUX = armarAccesoNuevo(mallaDir,row);
                if (AUX.Trim() != "")
                {
                    nvoRow = dtAccesos.NewRow();
                    nvoRow["accnvo"] = AUX;
                    nvoRow["IdEmpresa"] = empresa;
                    nvoRow["IdSistema"] = sistema;
                    nvoRow["IdOpcion"] = row.Cells["clave"].Value;
                    nvoRow["IdNomOpcion"] = row.Cells["opcion"].Value;
                    nvoRow["IdUsuario"] = usuario;
                    if ((AUX + " ").Substring(0, 1) == "X")
                    { nvoRow["Accesos"] = "T"; }
                    else {nvoRow["Accesos"] = "R";}
                    dtAccesos.Rows.Add(nvoRow);
                }
            }
            da.Update(dtAccesos);
            dtAccesos.AcceptChanges();
            dtAccesos.Dispose();
        }

        public void guardarSucursales(string strConxDaxsys, string usuario, string empresa, DataGridView mallaSuc,DataGridView mallaBod)
        { 
            string ssql = " where idUsuario = '" + usuario + "' and idempresa = " + empresa ;
            ManejoBases manBas = new ManejoBases();
            DataRow nvoRow;
            DataTable dtAccesos = new DataTable();
            SqlCommandBuilder cb;
            SqlDataAdapter da;
            string AUX="";
            da = new SqlDataAdapter("select * from  sys_sucursales " + ssql, strConxDaxsys);
            dtAccesos = new DataTable();
            da.Fill(dtAccesos);
            foreach (DataRow dr in dtAccesos.Rows)
            {
                dr.Delete();
            }
            
            eliminarBodegas(strConxDaxsys , usuario, Convert.ToInt16(empresa));
            
            foreach (DataGridViewRow row in mallaSuc.Rows)
            {
                AUX = "";
                if (row.Cells["conAcceso"].Value.ToString() == "X") AUX = "S";
                if (AUX.Trim() != "")
                {
                    nvoRow = dtAccesos.NewRow();
                    nvoRow["IdUsuario"] = usuario;
                    nvoRow["IdEmpresa"] = empresa;
                    nvoRow["autorizaSuc"] = AUX;
                    nvoRow["CodSucursal"] = row.Cells["modulo"].Value;
                    dtAccesos.Rows.Add(nvoRow);
                }
            }
            cb = new SqlCommandBuilder(da);
            da.Update(dtAccesos);
            guardarBodegas(strConxDaxsys, Convert.ToInt16(empresa), usuario, mallaBod);
        }
        public void guardarBodegas(string strConxDaxsys, Int32 empresa, string usuario, DataGridView mallaBod)
        {
            string ssql = " where idUsuario = '" + usuario + "' and idempresa = " + empresa;
            ejecutarComando(strConxDaxsys, "delete from sys_bodegas " + ssql);
            ManejoBases manBas = new ManejoBases();
            DataRow nvoRow;
            DataTable dtAccesos = new DataTable();
            SqlCommandBuilder cb;
            SqlDataAdapter da;
            string AUX = "";
            da = new SqlDataAdapter("select * from sys_Bodegas " + ssql, strConxDaxsys);
            dtAccesos = new DataTable();
            da.Fill(dtAccesos);

            foreach (DataGridViewRow row in mallaBod.Rows)
            {
                AUX = "";
                if (row.Cells["conAcceso"].Value.ToString() == "X") AUX = "S";
                if (AUX.Trim() != "")
                {
                    nvoRow = dtAccesos.NewRow();
                    nvoRow["IdUsuario"] = usuario;
                    nvoRow["IdEmpresa"] = empresa;
                    nvoRow["autorizaBod"] = AUX;
                    nvoRow["CodBodega"] = row.Cells["modulo"].Value;
                    nvoRow["CodSucursal"] = row.Cells["suc_codigo"].Value;
                    dtAccesos.Rows.Add(nvoRow);
                }
            }
            cb = new SqlCommandBuilder(da);
            da.Update(dtAccesos);
            dtAccesos.AcceptChanges();

            //string SSQL = "insert  into sys_bodegas";
            //SSQL += " select '" + usuario + "'," + empresa.ToString() + ",'" + sucursal + "',Bod_Codigo,'T' as AutorizaBod ";
            //SSQL += " from emp_bod where emp_codigo = " + empresa.ToString() + " and suc_codigo = '" + sucursal + "'";
            //ManejoBases mb = new ManejoBases();
            //mb.ejecutarComando(strConxDaxsys, SSQL);
            //mb = null;
        }
        private void eliminarBodegas(string strConxDaxsys, string usuario, Int32 empresa)
        {
            string SSQL = "delete from sys_bodegas where idusuario = '" + usuario + "' and idempresa = " + empresa.ToString();
            ManejoBases mb = new ManejoBases();
            mb.ejecutarComando(strConxDaxsys, SSQL);
            mb = null;
        }

        public void guardarDocumentos(string strConxDaxsys, string usuario, string empresa, DataGridView mallaDoc)
        {
            string ssql = " where idUsuario = '" + usuario + "' and idempresa = " + empresa;
            ManejoBases manBas = new ManejoBases();
            DataRow nvoRow;
            DataTable dtAccesos = new DataTable();
            SqlCommandBuilder cb;
            SqlDataAdapter da;
            string AUX = "";
            da = new SqlDataAdapter("select * from sys_documentos " + ssql, strConxDaxsys);
            dtAccesos = new DataTable();
            da.Fill(dtAccesos);
            foreach (DataRow dr in dtAccesos.Rows)
            {
                dr.Delete();
            }
            foreach (DataGridViewRow row in mallaDoc.Rows)
            {

                AUX = "";
                if (row.Cells["conAcceso"].Value.ToString() == "X") AUX = "T";
                if (AUX.Trim() != "")
                {
                    nvoRow = dtAccesos.NewRow();
                    nvoRow["IdUsuario"] = usuario;
                    nvoRow["IdEmpresa"] = empresa;
                    nvoRow["cambios"] = AUX;
                    nvoRow["CodDocumento"] = row.Cells["modulo"].Value;
                    dtAccesos.Rows.Add(nvoRow);
                }
            }
            cb = new SqlCommandBuilder(da);
            da.Update(dtAccesos);
        }

        private string armarAccesoNuevo(DataGridViewRow row)
        {
            string aux = (row.Cells["Abierto"].Value.ToString() + " ").Substring(0, 1);
            aux += (row.Cells["Consultar"].Value.ToString() + " ").Substring(0, 1);
            aux += (row.Cells["Imprimir"].Value.ToString() + " ").Substring(0, 1);
            return aux;
        }

        private string armarAccesoNuevo(DataGridView malla, DataGridViewRow row)
        {
            string aux="";
            //string abierto = (row.Cells["Abierto"].Value.ToString()+" ").Substring(0,1);
            //string consultar = (row.Cells["Consultar"].Value.ToString() + " ").Substring(0, 1);
            //string imprimir = (row.Cells["Imprimir"].Value.ToString() + " ").Substring(0, 1);

            //for (int i = 0; i < row.Cells.Count - 1;i++)
            //{
            //    DataGridViewCell celda = row.Cells[i];
            //    if (malla.Columns[i].Name.ToUpper() == "ABIERTO") abierto = celda.Value.ToString();
            //    if (malla.Columns[i].Name.ToUpper() == "CONSULTAR") consultar = celda.Value.ToString();
            //    if (malla.Columns[i].Name.ToUpper() == "IMPRIMIR") imprimir = celda.Value.ToString();
            //}
            //aux = (abierto + " ").Substring(0, 1);
            //aux += (consultar + " ").Substring(0, 1);
            //aux += (imprimir + " ").Substring(0, 1);

            //return aux;
            try
            {
                aux = (row.Cells["conAcceso"].Value.ToString() + " ").Substring(0, 1);
                return aux;
            }
            catch { }

            ////return (row.Cells["Abierto"].Value.ToString() + " ").Substring(0, 1) +(row.Cells["Consultar"].Value.ToString() + " ").Substring(0, 1)+ (row.Cells["Imprimir"].Value.ToString() + " ").Substring(0, 1);
            return (row.Cells["Abierto"].Value.ToString() + " ").Substring(0, 1).Substring(0, 1);
        }

        public DataTable leerTablas(string strconx,string ssql)
        {
            DataTable dt = new DataTable ();
            SqlDataAdapter da = new SqlDataAdapter(ssql, strconx);
            da.Fill(dt);
            return dt;
        }

        public void ejecutarComando(string strconx, string ssql)
        {
            SqlConnection conn = new SqlConnection(strconx);
            conn.Open();
            SqlCommand comm = new SqlCommand(ssql, conn);
            int fil = comm.ExecuteNonQuery();
            conn.Close();
            conn.Dispose();
            comm.Dispose();
        }
    }
}
