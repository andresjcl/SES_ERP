using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace leeDocXml
{
    public class DaxDocProov
    {
        private System.String _idProveedor;
        private System.String _idDocProveedor;
        private System.String _opcDocAdcom;
        private System.String _AgruparIguales;
        private System.String _unCodigo;
        //
        // Este método se usará para ajustar los anchos de las propiedades
        private string ajustarAncho(string cadena, int ancho)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder(new String(' ', ancho));
            return (cadena + sb.ToString()).Substring(0, ancho).Trim();
        }
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
        public System.String idDocProveedor
        {
            get
            {
                return ajustarAncho(_idDocProveedor, 5);
            }
            set
            {
                _idDocProveedor = value;
            }
        }
        public System.String opcDocAdcom
        {
            get
            {
                return ajustarAncho(_opcDocAdcom, 5);
            }
            set
            {
                _opcDocAdcom = value;
            }
        }
        public System.String AgruparIguales
        {
            get
            {
                return ajustarAncho(_AgruparIguales, 5);
            }
            set
            {
                _AgruparIguales = value;
            }
        }
        public System.String unCodigo
        {
            get
            {
                return ajustarAncho(_unCodigo, 2);
            }
            set
            {
                _unCodigo = value;
            }
        }
        //
        private static string cadenaConexion = "";
        // La cadena de selección
        public static string CadenaSelect = "SELECT * FROM DaxDocProov";
        //
        public DaxDocProov()
        {
        }
        public DaxDocProov(string conex)
        {
            cadenaConexion = conex;
        }
        //
        // Métodos compartidos (estáticos) privados
        //
        // asigna una fila de la tabla a un objeto DaxDocProov
        private static DaxDocProov row2DaxDocProov(DataRow r)
        {
            // asigna a un objeto DaxDocProov los datos del dataRow indicado
            DaxDocProov oDaxDocProov = new DaxDocProov();
            //
            oDaxDocProov.idProveedor = r["idProveedor"].ToString();
            oDaxDocProov.idDocProveedor = r["idDocProveedor"].ToString();
            oDaxDocProov.opcDocAdcom = r["opcDocAdcom"].ToString();
            oDaxDocProov.AgruparIguales = r["AgruparIguales"].ToString();
            oDaxDocProov.unCodigo = r["unCodigo"].ToString();
            //
            return oDaxDocProov;
        }
        //
        // asigna un objeto DaxDocProov a la fila indicada
        private static void DaxDocProov2Row(DaxDocProov oDaxDocProov, DataRow r)
        {
            // asigna un objeto DaxDocProov al dataRow indicado
            r["idProveedor"] = oDaxDocProov.idProveedor;
            r["idDocProveedor"] = oDaxDocProov.idDocProveedor;
            r["opcDocAdcom"] = oDaxDocProov.opcDocAdcom;
            r["AgruparIguales"] = oDaxDocProov.AgruparIguales;
            r["unCodigo"] = oDaxDocProov.unCodigo;
        }
        //
        // crea una nueva fila y la asigna a un objeto DaxDocProov
        private static void nuevoDaxDocProov(DataTable dt, DaxDocProov oDaxDocProov)
        {
            // Crear un nuevo DaxDocProov
            DataRow dr = dt.NewRow();
            DaxDocProov oD = row2DaxDocProov(dr);
            //
            oD.idProveedor = oDaxDocProov.idProveedor;
            oD.idDocProveedor = oDaxDocProov.idDocProveedor;
            oD.opcDocAdcom = oDaxDocProov.opcDocAdcom;
            oD.AgruparIguales = oDaxDocProov.AgruparIguales;
            oD.unCodigo = oDaxDocProov.unCodigo;
            //
            DaxDocProov2Row(oD, dr);
            //
            dt.Rows.Add(dr);
        }
        //
        // Métodos públicos
        //
        // devuelve una tabla con los datos indicados en la cadena de selección
        public static DataTable Tabla()
        {
            return Tabla(CadenaSelect);
        }
        public static DataTable Tabla(string sel)
        {
            // devuelve una tabla con los datos de la tabla DaxDocProov
            SqlDataAdapter da;
            DataTable dt = new DataTable("DaxDocProov");
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
        public static DaxDocProov Buscar(string sWhere)
        {
            // Busca en la tabla los datos indicados en el parámetro
            // el parámetro contendrá lo que se usará después del WHERE
            DaxDocProov oDaxDocProov = null;
            SqlDataAdapter da;
            DataTable dt = new DataTable("DaxDocProov");
            string sel = "SELECT * FROM DaxDocProov WHERE " + sWhere;
            //
            da = new SqlDataAdapter(sel, cadenaConexion);
            da.Fill(dt);
            //
            if (dt.Rows.Count > 0)
            {
                oDaxDocProov = row2DaxDocProov(dt.Rows[0]);
            }
            return oDaxDocProov;
        }
        //
        public string Actualizar()
        {
            string sel = "SELECT * FROM DaxDocProov WHERE idProveedor = '" + idProveedor + "' and idDocProveedor = '" + idDocProveedor + "'";
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
            DataTable dt = new DataTable("DaxDocProov");
            //
            cnn = new SqlConnection(cadenaConexion);
            //da = new SqlDataAdapter(CadenaSelect, cnn);
            da = new SqlDataAdapter(sel, cnn);
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            //
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
                return Crear();
            }
            else
            {
                DaxDocProov2Row(this, dt.Rows[0]);
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
            // Crear un nuevo registro
            // En caso de error, devolverá la cadena de error empezando por ERROR:.
            SqlConnection cnn;
            SqlDataAdapter da;
            DataTable dt = new DataTable("DaxDocProov");
            //
            cnn = new SqlConnection(cadenaConexion);
            da = new SqlDataAdapter(CadenaSelect, cnn);
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
            nuevoDaxDocProov(dt, this);
            //
            try
            {
                da.Update(dt);
                dt.AcceptChanges();
                return "Se ha creado un nuevo DaxDocProov";
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
        }
        //
        public string Borrar()
        {
            string sel = "SELECT * FROM DaxDocProov WHERE  idProveedor = '" + idProveedor + "' and idDocProveedor = '" + idDocProveedor + "'";
            //
            return Borrar(sel);
        }
        public string Borrar(string sel)
        {
            SqlConnection cnn;
            SqlDataAdapter da;
            DataTable dt = new DataTable("DaxDocProov");
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
