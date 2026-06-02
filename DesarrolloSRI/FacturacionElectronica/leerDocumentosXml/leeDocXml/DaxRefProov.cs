using System;
using System.Data;
using System.Data.SqlClient;

namespace leeDocXml
{
    public class DaxRefProov
    {
        private System.String _idProveedor;
        private System.String _idProductoProveedor;
        private System.String _productoConcepto;
        private System.String _codigoAdcomDax;
        private System.String _utilizarDetalleProveedor;
        private System.String _detalleAutilizar;
        //
        private string ajustarAncho(string cadena, int ancho)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder(new String(' ', ancho));
            return (cadena + sb.ToString()).Substring(0, ancho).Trim();
        }
        //
        public System.String idProveedor
        {
            get
            {
                return ajustarAncho(_idProveedor, 20);
            }
            set
            {
                _idProveedor = value;
            }
        }
        public System.String idProductoProveedor
        {
            get
            {
                return ajustarAncho(_idProductoProveedor, 20);
            }
            set
            {
                _idProductoProveedor = value;
            }
        }
        public System.String productoConcepto
        {
            get
            {
                return ajustarAncho(_productoConcepto, 20);
            }
            set
            {
                _productoConcepto = value;
            }
        }
        public System.String codigoAdcomDax
        {
            get
            {
                return ajustarAncho(_codigoAdcomDax, 20);
            }
            set
            {
                _codigoAdcomDax = value;
            }
        }
        public System.String utilizarDetalleProveedor
        {
            get
            {
                return ajustarAncho(_utilizarDetalleProveedor, 20);
            }
            set
            {
                _utilizarDetalleProveedor = value;
            }
        }
        public System.String detalleAutilizar
        {
            get
            {
                return ajustarAncho(_detalleAutilizar, 100);
            }
            set
            {
                _detalleAutilizar = value;
            }
        }
        //
        private static string cadenaConexion = @"Data Source=192.168.131.5; Initial Catalog=BdAdcomDx14GrupoAcercons; user id=sa; password=123qweASDZXC";
        // La cadena de selección
        public static string CadenaSelect = "SELECT * FROM DaxRefProov";
        //
        public DaxRefProov()
        {
        }
        public DaxRefProov(string conex)
        {
            cadenaConexion = conex;
        }
        private static DaxRefProov row2DaxRefProov(DataRow r)
        {
            // asigna a un objeto DaxRefProov los datos del dataRow indicado
            DaxRefProov oDaxRefProov = new DaxRefProov();
            //
            oDaxRefProov.idProveedor = r["idProveedor"].ToString();
            oDaxRefProov.idProductoProveedor = r["idProductoProveedor"].ToString();
            oDaxRefProov.productoConcepto = r["productoConcepto"].ToString();
            oDaxRefProov.codigoAdcomDax = r["codigoAdcomDax"].ToString();
            oDaxRefProov.utilizarDetalleProveedor = r["utilizarDetalleProveedor"].ToString();
            oDaxRefProov.detalleAutilizar = r["detalleAutilizar"].ToString();
            //
            return oDaxRefProov;
        }
        //
        // asigna un objeto DaxRefProov a la fila indicada
        private static void DaxRefProov2Row(DaxRefProov oDaxRefProov, DataRow r)
        {
            // asigna un objeto DaxRefProov al dataRow indicado
            r["idProveedor"] = oDaxRefProov.idProveedor;
            r["idProductoProveedor"] = oDaxRefProov.idProductoProveedor;
            r["productoConcepto"] = oDaxRefProov.productoConcepto;
            r["codigoAdcomDax"] = oDaxRefProov.codigoAdcomDax;
            r["utilizarDetalleProveedor"] = oDaxRefProov.utilizarDetalleProveedor;
            r["detalleAutilizar"] = oDaxRefProov.detalleAutilizar;
        }
        private static void nuevoDaxRefProov(DataTable dt, DaxRefProov oDaxRefProov)
        {
            // Crear un nuevo DaxRefProov
            DataRow dr = dt.NewRow();
            DaxRefProov oD = row2DaxRefProov(dr);
            //
            oD.idProveedor = oDaxRefProov.idProveedor;
            oD.idProductoProveedor = oDaxRefProov.idProductoProveedor;
            oD.productoConcepto = oDaxRefProov.productoConcepto;
            oD.codigoAdcomDax = oDaxRefProov.codigoAdcomDax;
            oD.utilizarDetalleProveedor = oDaxRefProov.utilizarDetalleProveedor;
            oD.detalleAutilizar = oDaxRefProov.detalleAutilizar;
            //
            DaxRefProov2Row(oD, dr);
            //
            dt.Rows.Add(dr);
        }
        public static DataTable Tabla()
        {
            return Tabla(CadenaSelect);
        }
        public static DataTable Tabla(string sel)
        {
            // devuelve una tabla con los datos de la tabla DaxRefProov
            SqlDataAdapter da;
            DataTable dt = new DataTable("DaxRefProov");
            //
            try
            {
                da = new SqlDataAdapter(sel, cadenaConexion);
                da.Fill(dt);
            }
            catch
            {
                return null;
            }
            //
            return dt;
        }
        //
        public static DaxRefProov Buscar(string sWhere)
        {
            DaxRefProov oDaxRefProov = null;
            SqlDataAdapter da;
            DataTable dt = new DataTable("DaxRefProov");
            string sel = "SELECT * FROM DaxRefProov WHERE " + sWhere;
            //
            da = new SqlDataAdapter(sel, cadenaConexion);
            da.Fill(dt);
            //
            if (dt.Rows.Count > 0)
            {
                oDaxRefProov = row2DaxRefProov(dt.Rows[0]);
            }
            return oDaxRefProov;
        }
        public string Actualizar()
        {
            // TODO: Poner aquí la selección a realizar para acceder a este registro
            //       yo uso el ID que es el identificador único de cada registro
            string sel = "SELECT * FROM DaxRefProov WHERE idProveedor = '" + idProveedor + "' and idProductoProveedor '" + idProductoProveedor + "' and productoConcepto = '" + productoConcepto + "'";
            return Actualizar(sel);
        }
        public string Actualizar(string sel)
        {
            // Actualiza los datos indicados
            // El parámetro, que es una cadena de selección, indicará el criterio de actualización
            //
            // En caso de error, devolverá la cadena empezando por ERROR.
            SqlConnection cnn;
            SqlDataAdapter da;
            DataTable dt = new DataTable("DaxRefProov");
            //
            cnn = new SqlConnection(cadenaConexion);
            da = new SqlDataAdapter(sel, cnn);
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            da.UpdateCommand = cb.GetUpdateCommand();
            try
            {
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
            //
            if (dt.Rows.Count == 0)
            {
                // crear uno nuevo
                return Crear();
            }
            else
            {
                DaxRefProov2Row(this, dt.Rows[0]);
            }
            //
            try
            {
                da.Update(dt);
                dt.AcceptChanges();
                return "Actualizado correctamente";
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
        }
        //
        public string Crear()
        {
            SqlConnection cnn;
            SqlDataAdapter da;
            DataTable dt = new DataTable("DaxRefProov");
            //
            cnn = new SqlConnection(cadenaConexion);
            da = new SqlDataAdapter(CadenaSelect, cnn);
            //da = new SqlDataAdapter(CadenaSelect, cadenaConexion);
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            da.InsertCommand = cb.GetInsertCommand();
            try
            {
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
            //
            nuevoDaxRefProov(dt, this);
            //
            try
            {
                da.Update(dt);
                dt.AcceptChanges();
                return "Se ha creado un nuevo DaxRefProov";
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
        }
        //
        public string Borrar()
        {
            string sel = "SELECT * FROM DaxRefProov WHERE idProveedor = '" + idProveedor + "' and idProductoProveedor '" + idProductoProveedor + "' and productoConcepto = '" + productoConcepto + "'";
            //
            return Borrar(sel);
        }
        public string Borrar(string sel)
        {
            SqlConnection cnn;
            SqlDataAdapter da;
            DataTable dt = new DataTable("DaxRefProov");
            //
            cnn = new SqlConnection(cadenaConexion);
            da = new SqlDataAdapter(sel, cnn);
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            da.DeleteCommand = cb.GetDeleteCommand();
            da.Fill(dt);
            //
            if (dt.Rows.Count == 0)
            {
                return "ERROR: No hay datos";
            }
            else
            {
                dt.Rows[0].Delete();
            }
            //
            try
            {
                da.Update(dt);
                dt.AcceptChanges();
                return "Borrado satisfactoriamente";
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
        }
        //
    }
}
