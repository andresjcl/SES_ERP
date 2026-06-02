using System;
using System.Data;
using System.Data.SqlClient;

namespace mntUsrs
{
    //
    public class sys_Usuario
    {
        // Las variables privadas
        private System.String _IdUsuario="";
        private System.String _CodUsuario="";
        private System.DateTime _FechaInicio = DateTime.Now ;
        private System.DateTime _FechaCaduca = new DateTime(9998, 12, 31);
        private System.String _Contraseña="";
        private System.DateTime _FechaCambioContra = DateTime.Now ;
        private System.Int32 _DíasDuraContraseña=0;
        //
        private string ajustarAncho(string cadena, int ancho)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder(new String(' ', ancho));
            return (cadena + sb.ToString()).Substring(0, ancho).Trim();
        }
        //
        public System.String IdUsuario
        {
            get
            {
                return ajustarAncho(_IdUsuario, 15);
            }
            set
            {
                _IdUsuario = value;
            }
        }
        public System.String CodUsuario
        {
            get
            {
                return ajustarAncho(_CodUsuario, 15);
            }
            set
            {
                _CodUsuario = value;
            }
        }
        public System.DateTime FechaInicio
        {
            get
            {
                return _FechaInicio;
            }
            set
            {
                _FechaInicio = value;
            }
        }
        public System.DateTime FechaCaduca
        {
            get
            {
                return _FechaCaduca;
            }
            set
            {
                _FechaCaduca = value;
            }
        }
        public System.String Contraseña
        {
            get
            {
                return ajustarAncho(_Contraseña, 15);
            }
            set
            {
                _Contraseña = value;
            }
        }
        public System.DateTime FechaCambioContra
        {
            get
            {
                return _FechaCambioContra;
            }
            set
            {
                _FechaCambioContra = value;
            }
        }
        public System.Int32 DíasDuraContraseña
        {
            get
            {
                return _DíasDuraContraseña;
            }
            set
            {
                _DíasDuraContraseña = value;
            }
        }
        //
        private static string cadenaConexion = @"";
        // La cadena de selección
        public static string CadenaSelect = "";
        //
        public sys_Usuario()
        {
        }
        public sys_Usuario(string conex)
        {
            cadenaConexion = conex;
        }

        private static sys_Usuario row2sys_Usuario(DataRow r)
        {
            // asigna a un objeto sys_Usuario los datos del dataRow indicado
            sys_Usuario osys_Usuario = new sys_Usuario();
            //
            osys_Usuario.IdUsuario = r["IdUsuario"].ToString();
            osys_Usuario.CodUsuario = r["CodUsuario"].ToString();
            try
            {
                osys_Usuario.FechaInicio = DateTime.Parse(r["FechaInicio"].ToString());
            }
            catch
            {
                osys_Usuario.FechaInicio = DateTime.Now;
            }
            try
            {
                osys_Usuario.FechaCaduca = DateTime.Parse(r["FechaCaduca"].ToString());
            }
            catch
            {
                osys_Usuario.FechaCaduca = new DateTime(9998, 12, 31);
            }
            osys_Usuario.Contraseña = r["Contraseña"].ToString();
            try
            {
                osys_Usuario.FechaCambioContra = DateTime.Parse(r["FechaCambioContra"].ToString());
            }
            catch
            {
                osys_Usuario.FechaCambioContra = DateTime.Now;
            }
            osys_Usuario.DíasDuraContraseña = System.Int32.Parse("0" + r["DíasDuraContraseña"].ToString());
            //
            return osys_Usuario;
        }

        private static void sys_Usuario2Row(sys_Usuario osys_Usuario, DataRow r)
        {
            // asigna un objeto sys_Usuario al dataRow indicado
            r["IdUsuario"] = osys_Usuario.IdUsuario;
            r["CodUsuario"] = osys_Usuario.CodUsuario;
            r["FechaInicio"] = osys_Usuario.FechaInicio;
            r["FechaCaduca"] = osys_Usuario.FechaCaduca;
            r["Contraseña"] = osys_Usuario.Contraseña;
            r["FechaCambioContra"] = osys_Usuario.FechaCambioContra;
            r["DíasDuraContraseña"] = osys_Usuario.DíasDuraContraseña;
        }
        //
        // crea una nueva fila y la asigna a un objeto sys_Usuario
        private static void nuevosys_Usuario(DataTable dt, sys_Usuario osys_Usuario)
        {
            // Crear un nuevo sys_Usuario
            DataRow dr = dt.NewRow();
            sys_Usuario os = row2sys_Usuario(dr);
            //
            os.IdUsuario = osys_Usuario.IdUsuario;
            os.CodUsuario = osys_Usuario.CodUsuario;
            os.FechaInicio = osys_Usuario.FechaInicio;
            os.FechaCaduca = osys_Usuario.FechaCaduca;
            os.Contraseña = osys_Usuario.Contraseña;
            os.FechaCambioContra = osys_Usuario.FechaCambioContra;
            os.DíasDuraContraseña = osys_Usuario.DíasDuraContraseña;
            //
            sys_Usuario2Row(os, dr);
            //
            dt.Rows.Add(dr);
        }

        public static DataTable Tabla()
        {
            return Tabla(CadenaSelect);
        }
        public static DataTable Tabla(string sel)
        {
            // devuelve una tabla con los datos de la tabla sys_Usuario
            SqlDataAdapter da;
            DataTable dt = new DataTable("sys_Usuario");
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
        public static sys_Usuario Buscar(string sWhere)
        {
            sys_Usuario osys_Usuario = null;
            SqlDataAdapter da;
            DataTable dt = new DataTable("sys_Usuario");
            string sel = "SELECT * FROM sys_Usuario WHERE " + sWhere;
            //
            da = new SqlDataAdapter(sel, cadenaConexion);
            da.Fill(dt);
            //
            if (dt.Rows.Count > 0)
            {
                osys_Usuario = row2sys_Usuario(dt.Rows[0]);
            }
            return osys_Usuario;
        }
        public string Actualizar()
        {
            string sel = "SELECT * FROM sys_Usuario WHERE IdUsuario = '" + this.IdUsuario + "'";
            return Actualizar(sel);
        }
        public string Actualizar(string sel)
        {
            CadenaSelect = sel;
            SqlConnection cnn;
            SqlDataAdapter da;
            DataTable dt = new DataTable("sys_Usuario");
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
            if (dt.Rows.Count == 0)
            {
                return Crear();
            }
            else
            {
                sys_Usuario2Row(this, dt.Rows[0]);
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
            DataTable dt = new DataTable("sys_Usuario");
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
            nuevosys_Usuario(dt, this);
            //
            try
            {
                da.Update(dt);
                dt.AcceptChanges();
                return "Se ha creado un nuevo sys_Usuario";
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
        }
        //
        public string Borrar()
        {
            string sel = "SELECT * FROM sys_Usuario WHERE IdUsuario = '" + this.IdUsuario + "'";
            //
            return Borrar(sel);
        }
        public string Borrar(string sel)
        {
            SqlConnection cnn;
            SqlDataAdapter da;
            DataTable dt = new DataTable("sys_Usuario");
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
    }
}