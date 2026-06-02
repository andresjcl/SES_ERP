using System;
using System.Data;
using System.Data.SqlClient;

namespace Syscod
{
    public class ClassSyscod
    {
//
        private System.String _TipoReferencia="";
        private System.String _Abreviación = "";
        private System.String _Descripcion = "";
        private System.String _Caracteristica1 = "";
        private System.String _Caracteristica2 = "";
        private System.String _Caracteristica3 = "";
        private System.String _Caracteristica4 = "";
        private System.String _Caracteristica5 = "";
        private System.Decimal _Clave=0;
        private System.String _Tipo1 = "";
        private System.String _Tipo2 = "";
        private System.String _Tipo3 = "";
        private System.String _Tipo4 = "";
        private System.String _Tipo5 = "";
        private System.Int32 _longitud1=0;
        private System.Int32 _longitud2 = 0;
        private System.Int32 _longitud3 = 0;
        private System.Int32 _longitud4 = 0;
        private System.Int32 _longitud5 = 0;
        private System.Int32 _decimales1 = 0;
        private System.Int32 _decimales2 = 0;
        private System.Int32 _decimales3 = 0;
        private System.Int32 _decimales4 = 0;
        private System.Int32 _decimales5 = 0;
        private System.DateTime _modificado=new DateTime(1900,1,1);

        private string ajustarAncho(string cadena, int ancho)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder(new String(' ', ancho));
            // devolver la cadena quitando los espacios en blanco
            // esto asegura que no se devolverá un tamaño mayor ni espacios "extras"
            return (cadena + sb.ToString()).Substring(0, ancho).Trim();
        }
        //
        // Las propiedades públicas
        public System.String TipoReferencia
        {
            get
            {
                return ajustarAncho(_TipoReferencia, 30);
            }
            set
            {
                _TipoReferencia = value;
            }
        }
        public System.String Abreviación
        {
            get
            {
                return ajustarAncho(_Abreviación, 15);
            }
            set
            {
                _Abreviación = value;
            }
        }
        public System.String Descripcion
        {
            get
            {
                return ajustarAncho(_Descripcion, 100);
            }
            set
            {
                _Descripcion = value;
            }
        }
        public System.String Caracteristica1
        {
            get
            {
                return ajustarAncho(_Caracteristica1, 80);
            }
            set
            {
                _Caracteristica1 = value;
            }
        }
        public System.String Caracteristica2
        {
            get
            {
                return ajustarAncho(_Caracteristica2, 80);
            }
            set
            {
                _Caracteristica2 = value;
            }
        }
        public System.String Caracteristica3
        {
            get
            {
                return ajustarAncho(_Caracteristica3, 80);
            }
            set
            {
                _Caracteristica3 = value;
            }
        }
        public System.String Caracteristica4
        {
            get
            {
                return ajustarAncho(_Caracteristica4, 80);
            }
            set
            {
                _Caracteristica4 = value;
            }
        }
        public System.String Caracteristica5
        {
            get
            {
                return ajustarAncho(_Caracteristica5, 80);
            }
            set
            {
                _Caracteristica5 = value;
            }
        }
        public System.Decimal Clave
        {
            get
            {
                return _Clave;
            }
            set
            {
                _Clave = value;
            }
        }
        public System.String Tipo1
        {
            get
            {
                return ajustarAncho(_Tipo1, 50);
            }
            set
            {
                _Tipo1 = value;
            }
        }
        public System.String Tipo2
        {
            get
            {
                return ajustarAncho(_Tipo2, 50);
            }
            set
            {
                _Tipo2 = value;
            }
        }
        public System.String Tipo3
        {
            get
            {
                return ajustarAncho(_Tipo3, 50);
            }
            set
            {
                _Tipo3 = value;
            }
        }
        public System.String Tipo4
        {
            get
            {
                return ajustarAncho(_Tipo4, 50);
            }
            set
            {
                _Tipo4 = value;
            }
        }
        public System.String Tipo5
        {
            get
            {
                return ajustarAncho(_Tipo5, 50);
            }
            set
            {
                _Tipo5 = value;
            }
        }
        public System.Int32 longitud1
        {
            get
            {
                return _longitud1;
            }
            set
            {
                _longitud1 = value;
            }
        }
        public System.Int32 longitud2
        {
            get
            {
                return _longitud2;
            }
            set
            {
                _longitud2 = value;
            }
        }
        public System.Int32 longitud3
        {
            get
            {
                return _longitud3;
            }
            set
            {
                _longitud3 = value;
            }
        }
        public System.Int32 longitud4
        {
            get
            {
                return _longitud4;
            }
            set
            {
                _longitud4 = value;
            }
        }
        public System.Int32 longitud5
        {
            get
            {
                return _longitud5;
            }
            set
            {
                _longitud5 = value;
            }
        }
        public System.Int32 decimales1
        {
            get
            {
                return _decimales1;
            }
            set
            {
                _decimales1 = value;
            }
        }
        public System.Int32 decimales2
        {
            get
            {
                return _decimales2;
            }
            set
            {
                _decimales2 = value;
            }
        }
        public System.Int32 decimales3
        {
            get
            {
                return _decimales3;
            }
            set
            {
                _decimales3 = value;
            }
        }
        public System.Int32 decimales4
        {
            get
            {
                return _decimales4;
            }
            set
            {
                _decimales4 = value;
            }
        }
        public System.Int32 decimales5
        {
            get
            {
                return _decimales5;
            }
            set
            {
                _decimales5 = value;
            }
        }
        public System.DateTime modificado
        {
            get
            {
                return _modificado;
            }
            set
            {
                _modificado = value;
            }
        }
        //
        //
        // Campos y métodos compartidos (estáticos) para gestionar la base de datos
        //
        // La cadena de conexión a la base de datos
        private static string cadenaConexion = @"Data Source=patoodax; Initial Catalog=daxsys; Integrated Security=yes;";
        // La cadena de selección
        public static string CadenaSelect = "SELECT * FROM Syscod";
        //
        public ClassSyscod ()
        {
        }
        public ClassSyscod(string conex)
        {
            cadenaConexion = conex;
        }
        //
        // Métodos compartidos (estáticos) privados
        //
        // asigna una fila de la tabla a un objeto Syscod
        private static ClassSyscod row2Syscod(DataRow r)
        {
            // asigna a un objeto Syscod los datos del dataRow indicado
            ClassSyscod oSyscod = new ClassSyscod();
            //
            oSyscod.TipoReferencia = r["TipoReferencia"].ToString();
            oSyscod.Abreviación = r["Abreviación"].ToString();
            oSyscod.Descripcion = r["Descripcion"].ToString();
            oSyscod.Caracteristica1 = r["Caracteristica1"].ToString();
            oSyscod.Caracteristica2 = r["Caracteristica2"].ToString();
            oSyscod.Caracteristica3 = r["Caracteristica3"].ToString();
            oSyscod.Caracteristica4 = r["Caracteristica4"].ToString();
            oSyscod.Caracteristica5 = r["Caracteristica5"].ToString();
            oSyscod.Clave = System.Decimal.Parse("0" + r["Clave"].ToString());
            oSyscod.Tipo1 = r["Tipo1"].ToString();
            oSyscod.Tipo2 = r["Tipo2"].ToString();
            oSyscod.Tipo3 = r["Tipo3"].ToString();
            oSyscod.Tipo4 = r["Tipo4"].ToString();
            oSyscod.Tipo5 = r["Tipo5"].ToString();
            oSyscod.longitud1 = System.Int32.Parse("0" + r["longitud1"].ToString());
            oSyscod.longitud2 = System.Int32.Parse("0" + r["longitud2"].ToString());
            oSyscod.longitud3 = System.Int32.Parse("0" + r["longitud3"].ToString());
            oSyscod.longitud4 = System.Int32.Parse("0" + r["longitud4"].ToString());
            oSyscod.longitud5 = System.Int32.Parse("0" + r["longitud5"].ToString());
            oSyscod.decimales1 = System.Int32.Parse("0" + r["decimales1"].ToString());
            oSyscod.decimales2 = System.Int32.Parse("0" + r["decimales2"].ToString());
            oSyscod.decimales3 = System.Int32.Parse("0" + r["decimales3"].ToString());
            oSyscod.decimales4 = System.Int32.Parse("0" + r["decimales4"].ToString());
            oSyscod.decimales5 = System.Int32.Parse("0" + r["decimales5"].ToString());
            try
            {
                oSyscod.modificado = DateTime.Parse(r["modificado"].ToString());
            }
            catch
            {
                // TODO: Usa el valor de fecha que quieras predeterminar
                //       Una fecha ficticia:
                //oSyscod.modificado = new DateTime(1900, 1, 1);
                //       o la fecha de hoy:
                oSyscod.modificado = DateTime.Now;
            }
            //
            return oSyscod;
        }
        //
        // asigna un objeto Syscod a la fila indicada
        private static void Syscod2Row(ClassSyscod oSyscod, DataRow r)
        {
            // asigna un objeto Syscod al dataRow indicado
            r["TipoReferencia"] = oSyscod.TipoReferencia;
            r["Abreviación"] = oSyscod.Abreviación;
            r["Descripcion"] = oSyscod.Descripcion;
            r["Caracteristica1"] = oSyscod.Caracteristica1;
            r["Caracteristica2"] = oSyscod.Caracteristica2;
            r["Caracteristica3"] = oSyscod.Caracteristica3;
            r["Caracteristica4"] = oSyscod.Caracteristica4;
            r["Caracteristica5"] = oSyscod.Caracteristica5;
            // TODO: Comprueba si esta asignación debe hacerse
            //       pero mejor lo dejas comentado ya que es un campo autoincremental o único
            //r["Clave"] = oSyscod.Clave;
            r["Tipo1"] = oSyscod.Tipo1;
            r["Tipo2"] = oSyscod.Tipo2;
            r["Tipo3"] = oSyscod.Tipo3;
            r["Tipo4"] = oSyscod.Tipo4;
            r["Tipo5"] = oSyscod.Tipo5;
            r["longitud1"] = oSyscod.longitud1;
            r["longitud2"] = oSyscod.longitud2;
            r["longitud3"] = oSyscod.longitud3;
            r["longitud4"] = oSyscod.longitud4;
            r["longitud5"] = oSyscod.longitud5;
            r["decimales1"] = oSyscod.decimales1;
            r["decimales2"] = oSyscod.decimales2;
            r["decimales3"] = oSyscod.decimales3;
            r["decimales4"] = oSyscod.decimales4;
            r["decimales5"] = oSyscod.decimales5;
            r["modificado"] = oSyscod.modificado;
        }
        //
        // crea una nueva fila y la asigna a un objeto Syscod
        private static void nuevoSyscod(DataTable dt, ClassSyscod oSyscod)
        {
            // Crear un nuevo Syscod
            DataRow dr = dt.NewRow();
            ClassSyscod oS = row2Syscod(dr);
            //
            oS.TipoReferencia = oSyscod.TipoReferencia;
            oS.Abreviación = oSyscod.Abreviación;
            oS.Descripcion = oSyscod.Descripcion;
            oS.Caracteristica1 = oSyscod.Caracteristica1;
            oS.Caracteristica2 = oSyscod.Caracteristica2;
            oS.Caracteristica3 = oSyscod.Caracteristica3;
            oS.Caracteristica4 = oSyscod.Caracteristica4;
            oS.Caracteristica5 = oSyscod.Caracteristica5;
            oS.Clave = oSyscod.Clave;
            oS.Tipo1 = oSyscod.Tipo1;
            oS.Tipo2 = oSyscod.Tipo2;
            oS.Tipo3 = oSyscod.Tipo3;
            oS.Tipo4 = oSyscod.Tipo4;
            oS.Tipo5 = oSyscod.Tipo5;
            oS.longitud1 = oSyscod.longitud1;
            oS.longitud2 = oSyscod.longitud2;
            oS.longitud3 = oSyscod.longitud3;
            oS.longitud4 = oSyscod.longitud4;
            oS.longitud5 = oSyscod.longitud5;
            oS.decimales1 = oSyscod.decimales1;
            oS.decimales2 = oSyscod.decimales2;
            oS.decimales3 = oSyscod.decimales3;
            oS.decimales4 = oSyscod.decimales4;
            oS.decimales5 = oSyscod.decimales5;
            oS.modificado = oSyscod.modificado;
            //
            Syscod2Row(oS, dr);
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
            // devuelve una tabla con los datos de la tabla Syscod
            SqlDataAdapter da;
            DataTable dt = new DataTable("Syscod");
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
        public static ClassSyscod Buscar(string sWhere)
        {
            // Busca en la tabla los datos indicados en el parámetro
            // el parámetro contendrá lo que se usará después del WHERE
            ClassSyscod oSyscod = null;
            SqlDataAdapter da;
            DataTable dt = new DataTable("Syscod");
            string sel = "SELECT * FROM Syscod WHERE " + sWhere;
            //
            da = new SqlDataAdapter(sel, cadenaConexion);
            da.Fill(dt);
            //
            if (dt.Rows.Count > 0)
            {
                oSyscod = row2Syscod(dt.Rows[0]);
            }
            return oSyscod;
        }
        public string Actualizar()
        {
            // TODO: Poner aquí la selección a realizar para acceder a este registro
            //       yo uso el Clave que es el identificador único de cada registro
            string sel = "SELECT * FROM Syscod WHERE Abreviación = '" + this.Abreviación + "' and TipoReferencia  = '" + this.TipoReferencia + "' ";
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
            DataTable dt = new DataTable();
            CadenaSelect = sel;
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
                Syscod2Row(this, dt.Rows[0]);
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
            DataTable dt = new DataTable("Syscod");
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
            nuevoSyscod(dt, this);
            //
            try
            {
                da.Update(dt);
                dt.AcceptChanges();
                return "Se ha creado un nuevo Syscod";
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
        }
        //
        public string Borrar()
        {
            // TODO: Poner aquí la selección a realizar para acceder a este registro
            //       yo uso el Clave que es el identificador único de cada registro
            string sel = "SELECT * FROM Syscod WHERE Abreviación = '" + this.Abreviación + "' and TipoReferencia  = '" + this.TipoReferencia + "' ";
            //
            return Borrar(sel);
        }
        public string Borrar(string sel)
        {
            // Borrar el registro al que apunta esta clase
            // En caso de error, devolverá la cadena de error empezando por ERROR:.
            SqlConnection cnn;
            SqlDataAdapter da;
            DataTable dt = new DataTable("Syscod");
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
    }


}

