using System;
using System.Data;
using System.Data.SqlClient;

namespace AuditSis
{
	public class ClassEvnts
    {
        private System.String _Tipo = "";
        private System.Int64 _Empresa = 0;
        private System.String _Equipo = "";
        private System.String _Sistema = "";
        private System.String _Usuario = "";
        private System.DateTime _Fecha = new DateTime(1900, 1, 1);
        private System.String _DocSucursal = "";
        private System.String _DocTipo = "";
        private System.String _DocNumero = "";
        private System.String _Sys1 = "";
        private System.String _Sys2 = "";
        private System.String _Sys3 = "";
        private System.String _Valor = "";
        private System.Decimal _idClave = 0;
        //
        // Este método se usará para ajustar los anchos de las propiedades
        private string ajustarAncho(string cadena, int ancho)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder(new String(' ', ancho));
            return (cadena + sb.ToString()).Substring(0, ancho).Trim();
        }
        public System.String Tipo
        {
            get
            {
                return ajustarAncho(_Tipo, 2);
            }
            set
            {
                _Tipo = value;
            }
        }
        public System.Int64 Empresa
        {
            get
            {
                return _Empresa;
            }
            set
            {
                _Empresa = value;
            }
        }
        public System.String Equipo
        {
            get
            {
                return ajustarAncho(_Equipo, 50);
            }
            set
            {
                _Equipo = value;
            }
        }
        public System.String Sistema
        {
            get
            {
                return ajustarAncho(_Sistema, 5);
            }
            set
            {
                _Sistema = value;
            }
        }
        public System.String Usuario
        {
            get
            {
                return ajustarAncho(_Usuario, 50);
            }
            set
            {
                _Usuario = value;
            }
        }
        public System.DateTime Fecha
        {
            get
            {
                return _Fecha;
            }
            set
            {
                _Fecha = value;
            }
        }
        public System.String DocSucursal
        {
            get
            {
                return ajustarAncho(_DocSucursal, 5);
            }
            set
            {
                _DocSucursal = value;
            }
        }
        public System.String DocTipo
        {
            get
            {
                return ajustarAncho(_DocTipo, 5);
            }
            set
            {
                _DocTipo = value;
            }
        }
        public System.String DocNumero
        {
            get
            {
                return ajustarAncho(_DocNumero, 50);
            }
            set
            {
                _DocNumero = value;
            }
        }
        public System.String Sys1
        {
            get
            {
                return ajustarAncho(_Sys1, 50);
            }
            set
            {
                _Sys1 = value;
            }
        }
        public System.String Sys2
        {
            get
            {
                return ajustarAncho(_Sys2, 50);
            }
            set
            {
                _Sys2 = value;
            }
        }
        public System.String Sys3
        {
            get
            {
                return ajustarAncho(_Sys3, 50);
            }
            set
            {
                _Sys3 = value;
            }
        }
        public System.String Valor
        {
            get
            {
                return ajustarAncho(_Valor, 300);
            }
            set
            {
                _Valor = value;
            }
        }
        public System.Decimal idClave
        {
            get
            {
                return _idClave;
            }
            set
            {
                _idClave = value;
            }
        }
        //
        // Campos y métodos compartidos (estáticos) para gestionar la base de datos
        //
        // La cadena de conexión a la base de datos
        private static string cadenaConexion = @"";
        // La cadena de selección
        public static string CadenaSelect = "SELECT * FROM sysEvnts";
        //
        public ClassEvnts()
        {
        }
        public ClassEvnts(string conex)
        {
            cadenaConexion = conex;
        }
        //
        // Métodos compartidos (estáticos) privados
        //
        // asigna una fila de la tabla a un objeto sysEvnts
        private static ClassEvnts row2sysEvnts(DataRow r)
        {
            // asigna a un objeto sysEvnts los datos del dataRow indicado
            ClassEvnts osysEvnts = new ClassEvnts();
            //
            osysEvnts.Tipo = r["Tipo"].ToString();
            osysEvnts.Empresa = System.Int64.Parse("0" + r["Empresa"].ToString());
            osysEvnts.Equipo = r["Equipo"].ToString();
            osysEvnts.Sistema = r["Sistema"].ToString();
            osysEvnts.Usuario = r["Usuario"].ToString();
            try
            {
                osysEvnts.Fecha = DateTime.Parse(r["Fecha"].ToString());
            }
            catch
            {
                // TODO: Usa el valor de fecha que quieras predeterminar
                //       Una fecha ficticia:
                //osysEvnts.Fecha = new DateTime(1900, 1, 1);
                //       o la fecha de hoy:
                osysEvnts.Fecha = DateTime.Now;
            }
            osysEvnts.DocSucursal = r["DocSucursal"].ToString();
            osysEvnts.DocTipo = r["DocTipo"].ToString();
            osysEvnts.DocNumero = r["DocNumero"].ToString();

            osysEvnts.Sys1 = r["Sys1"].ToString();
            osysEvnts.Sys2 = r["Sys2"].ToString();
            osysEvnts.Sys3 = r["Sys3"].ToString();
            osysEvnts.Valor = r["Valor"].ToString();
            osysEvnts.idClave = System.Decimal.Parse("0" + r["idClave"].ToString());
            //
            return osysEvnts;
        }
        //
        // asigna un objeto sysEvnts a la fila indicada
        private static void sysEvnts2Row(ClassEvnts osysEvnts, DataRow r)
        {
            // asigna un objeto sysEvnts al dataRow indicado
            r["Tipo"] = osysEvnts.Tipo;
            r["Empresa"] = osysEvnts.Empresa;
            r["Equipo"] = osysEvnts.Equipo;
            r["Sistema"] = osysEvnts.Sistema;
            r["Usuario"] = osysEvnts.Usuario;
            r["Fecha"] = osysEvnts.Fecha;
            r["DocSucursal"] = osysEvnts.DocSucursal;
            r["DocTipo"] = osysEvnts.DocTipo;
            r["DocNumero"] = osysEvnts.DocNumero;
            r["Sys1"] = osysEvnts.Sys1;
            r["Sys2"] = osysEvnts.Sys2;
            r["Sys3"] = osysEvnts.Sys3;
            r["Valor"] = osysEvnts.Valor;
            // TODO: Comprueba si esta asignación debe hacerse
            //       pero mejor lo dejas comentado ya que es un campo autoincremental o único
            //r["idClave"] = osysEvnts.idClave;
        }
        //
        // crea una nueva fila y la asigna a un objeto sysEvnts
        private static void nuevosysEvnts(DataTable dt, ClassEvnts osysEvnts)
        {
            // Crear un nuevo sysEvnts
            DataRow dr = dt.NewRow();
            ClassEvnts os = row2sysEvnts(dr);
            //
            os.Tipo = osysEvnts.Tipo;
            os.Empresa = osysEvnts.Empresa;
            os.Equipo = osysEvnts.Equipo;
            os.Sistema = osysEvnts.Sistema;
            os.Usuario = osysEvnts.Usuario;
            os.Fecha = osysEvnts.Fecha;
            os.DocSucursal = osysEvnts.DocSucursal;
            os.DocTipo = osysEvnts.DocTipo;
            os.DocNumero = osysEvnts.DocNumero;
            os.Sys1 = osysEvnts.Sys1;
            os.Sys2 = osysEvnts.Sys2;
            os.Sys3 = osysEvnts.Sys3;
            os.Valor = osysEvnts.Valor;
            os.idClave = osysEvnts.idClave;
            //
            sysEvnts2Row(os, dr);
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
            // devuelve una tabla con los datos de la tabla sysEvnts
            SqlDataAdapter da;
            DataTable dt = new DataTable("sysEvnts");
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
        public static ClassEvnts Buscar(string sWhere)
        {
            // Busca en la tabla los datos indicados en el parámetro
            // el parámetro contendrá lo que se usará después del WHERE
            ClassEvnts osysEvnts = null;
            SqlDataAdapter da;
            DataTable dt = new DataTable("sysEvnts");
            string sel = "SELECT * FROM sysEvnts WHERE " + sWhere;
            //
            da = new SqlDataAdapter(sel, cadenaConexion);
            da.Fill(dt);
            //
            if (dt.Rows.Count > 0)
            {
                osysEvnts = row2sysEvnts(dt.Rows[0]);
            }
            return osysEvnts;
        }
        //
        public string Actualizar()
        {
            string sel = "SELECT * FROM sysEvnts WHERE idClave = " + this.idClave.ToString();
            return Actualizar(sel);
        }
        public string Actualizar(string sel)
        {
            SqlConnection cnn;
            SqlDataAdapter da;
            DataTable dt = new DataTable();
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
                return Crear();
            }
            else
            {
                sysEvnts2Row(this, dt.Rows[0]);
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
            DataTable dt = new DataTable("sysEvnts");
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
            nuevosysEvnts(dt, this);
            //
            try
            {
                da.Update(dt);
                dt.AcceptChanges();
                return "Se ha creado un nuevo sysEvnts";
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
        }
        //
        public string Borrar()
        {
            string sel = "SELECT * FROM sysEvnts WHERE idClave = " + this.idClave.ToString();
            //
            return Borrar(sel);
        }
        public string Borrar(string sel)
        {
            SqlConnection cnn;
            SqlDataAdapter da;
            DataTable dt = new DataTable("sysEvnts");
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
