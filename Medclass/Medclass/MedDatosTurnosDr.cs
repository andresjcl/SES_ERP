using System;
using System.Data;
using System.Data.SqlClient;
//
namespace DaxMedic
{
    public class MedTurnDoc
    {
        // Las variables privadas
        // TODO: Revisar los tipos de los campos
        private System.String _Codigo;
        private System.String _Especialidad;
        private System.String _Hor1Desde;
        private System.String _Hor1Hasta;
        private System.String _Hor2Desde;
        private System.String _Hor2Hasta;
        private System.Decimal _MinTurno;
        private System.Decimal _NumAt;
        private System.DateTime _Fecha;
        private System.Decimal _ValorConsulta;
        //
        // Este método se usará para ajustar los anchos de las propiedades
        private string ajustarAncho(string cadena, int ancho)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder(new String(' ', ancho));
            // devolver la cadena quitando los espacios en blanco
            // esto asegura que no se devolverá un tamaño mayor ni espacios "extras"
            return (cadena + sb.ToString()).Substring(0, ancho).Trim();
        }
        //
        // Las propiedades públicas
        // TODO: Revisar los tipos de las propiedades
        public System.String Codigo
        {
            get
            {
                return ajustarAncho(_Codigo, 15);
            }
            set
            {
                _Codigo = value;
            }
        }
        public System.String Especialidad
        {
            get
            {
                return ajustarAncho(_Especialidad, 50);
            }
            set
            {
                _Especialidad = value;
            }
        }
        public System.String Hor1Desde
        {
            get
            {
                return ajustarAncho(_Hor1Desde, 10);
            }
            set
            {
                _Hor1Desde = value;
            }
        }
        public System.String Hor1Hasta
        {
            get
            {
                return ajustarAncho(_Hor1Hasta, 10);
            }
            set
            {
                _Hor1Hasta = value;
            }
        }
        public System.String Hor2Desde
        {
            get
            {
                return ajustarAncho(_Hor2Desde, 10);
            }
            set
            {
                _Hor2Desde = value;
            }
        }
        public System.String Hor2Hasta
        {
            get
            {
                return ajustarAncho(_Hor2Hasta, 10);
            }
            set
            {
                _Hor2Hasta = value;
            }
        }
        public System.Decimal MinTurno
        {
            get
            {
                return _MinTurno;
            }
            set
            {
                _MinTurno = value;
            }
        }
        public System.Decimal NumAt
        {
            get
            {
                return _NumAt;
            }
            set
            {
                _NumAt = value;
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
        public System.Decimal ValorConsulta
        {
            get
            {
                return _ValorConsulta;
            }
            set
            {
                _ValorConsulta = value;
            }
        }
        //
        //
        // La cadena de conexión a la base de datos
        private static string cadenaConexion = @"";
        // La cadena de selección
        public static string CadenaSelect = "SELECT * FROM MedTurnDoc";
        //
        public MedTurnDoc()
        {
        }
        public MedTurnDoc(string conex)
        {
            cadenaConexion = conex;
        }
        //
        // Métodos compartidos (estáticos) privados
        //
        // asigna una fila de la tabla a un objeto MedTurnDoc
        private static MedTurnDoc row2MedTurnDoc(DataRow r)
        {
            // asigna a un objeto MedTurnDoc los datos del dataRow indicado
            MedTurnDoc oMedTurnDoc = new MedTurnDoc();
            //
            oMedTurnDoc.Codigo = r["Codigo"].ToString();
            oMedTurnDoc.Especialidad = r["Especialidad"].ToString();
            oMedTurnDoc.Hor1Desde = r["Hor1Desde"].ToString();
            oMedTurnDoc.Hor1Hasta = r["Hor1Hasta"].ToString();
            oMedTurnDoc.Hor2Desde = r["Hor2Desde"].ToString();
            oMedTurnDoc.Hor2Hasta = r["Hor2Hasta"].ToString();
            oMedTurnDoc.MinTurno = System.Decimal.Parse("0" + r["MinTurno"].ToString());
            oMedTurnDoc.NumAt = System.Decimal.Parse("0" + r["NumAt"].ToString());
            try
            {
                oMedTurnDoc.Fecha = DateTime.Parse(r["Fecha"].ToString());
            }
            catch
            {
                oMedTurnDoc.Fecha = new DateTime(1900, 1, 1);
            }
            oMedTurnDoc.ValorConsulta = System.Decimal.Parse("0" + r["ValorConsulta"].ToString());
            //
            return oMedTurnDoc;
        }
        //
        // asigna un objeto MedTurnDoc a la fila indicada
        private static void MedTurnDoc2Row(MedTurnDoc oMedTurnDoc, DataRow r)
        {
            // asigna un objeto MedTurnDoc al dataRow indicado
            r["Codigo"] = oMedTurnDoc.Codigo;
            r["Especialidad"] = oMedTurnDoc.Especialidad;
            r["Hor1Desde"] = oMedTurnDoc.Hor1Desde;
            r["Hor1Hasta"] = oMedTurnDoc.Hor1Hasta;
            r["Hor2Desde"] = oMedTurnDoc.Hor2Desde;
            r["Hor2Hasta"] = oMedTurnDoc.Hor2Hasta;
            r["MinTurno"] = oMedTurnDoc.MinTurno;
            r["NumAt"] = oMedTurnDoc.NumAt;
            r["Fecha"] = oMedTurnDoc.Fecha;
            r["ValorConsulta"] = oMedTurnDoc.ValorConsulta;
        }
        //
        // crea una nueva fila y la asigna a un objeto MedTurnDoc
        private static void nuevoMedTurnDoc(DataTable dt, MedTurnDoc oMedTurnDoc)
        {
            // Crear un nuevo MedTurnDoc
            DataRow dr = dt.NewRow();
            MedTurnDoc oD = row2MedTurnDoc(dr);
            //
            oD.Codigo = oMedTurnDoc.Codigo;
            oD.Especialidad = oMedTurnDoc.Especialidad;
            oD.Hor1Desde = oMedTurnDoc.Hor1Desde;
            oD.Hor1Hasta = oMedTurnDoc.Hor1Hasta;
            oD.Hor2Desde = oMedTurnDoc.Hor2Desde;
            oD.Hor2Hasta = oMedTurnDoc.Hor2Hasta;
            oD.MinTurno = oMedTurnDoc.MinTurno;
            oD.NumAt = oMedTurnDoc.NumAt;
            oD.Fecha = oMedTurnDoc.Fecha;
            oD.ValorConsulta = oMedTurnDoc.ValorConsulta;
            //
            MedTurnDoc2Row(oD, dr);
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
            // devuelve una tabla con los datos de la tabla MedTurnDoc
            SqlDataAdapter da;
            DataTable dt = new DataTable("MedTurnDoc");
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
        public static MedTurnDoc Buscar(string sWhere)
        {
            // Busca en la tabla los datos indicados en el parámetro
            // el parámetro contendrá lo que se usará después del WHERE
            MedTurnDoc oMedTurnDoc = null;
            SqlDataAdapter da;
            DataTable dt = new DataTable("MedTurnDoc");
            string sel = "SELECT * FROM MedTurnDoc WHERE " + sWhere;
            //
            da = new SqlDataAdapter(sel, cadenaConexion);
            da.Fill(dt);
            //
            if (dt.Rows.Count > 0)
            {
                oMedTurnDoc = row2MedTurnDoc(dt.Rows[0]);
            }
            return oMedTurnDoc;
        }
        //
        public string Actualizar()
        {
            // TODO: Poner aquí la selección a realizar para acceder a este registro
            //       yo uso el ID que es el identificador único de cada registro
            string sel = "SELECT * FROM MedTurnDoc WHERE codigo = '" + this.Codigo + "' and especialidad = '" + this.Especialidad + "' and fecha = '" + this.Fecha + "' ";
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
            DataTable dt = new DataTable("MedTurnDoc");
            //
            cnn = new SqlConnection(cadenaConexion);
            da = new SqlDataAdapter(sel, cnn);
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            string sCommand;
            sCommand = "UPDATE MedTurnDoc SET Codigo = @Codigo, Especialidad = @Especialidad, Hor1Desde = @Hor1Desde, Hor1Hasta = @Hor1Hasta, Hor2Desde = @Hor2Desde, Hor2Hasta = @Hor2Hasta, MinTurno = @MinTurno, NumAt = @NumAt, Fecha = @Fecha, ValorConsulta = @ValorConsulta  WHERE (Codigo = @Codigo and Especialidad = @Especialidad and Fecha = @Fecha)";
            da.UpdateCommand = new SqlCommand(sCommand, cnn);
            da.UpdateCommand.Parameters.Add("@Codigo", SqlDbType.NVarChar, 15, "Codigo");
            da.UpdateCommand.Parameters.Add("@Especialidad", SqlDbType.NVarChar, 50, "Especialidad");
            da.UpdateCommand.Parameters.Add("@Hor1Desde", SqlDbType.NVarChar, 10, "Hor1Desde");
            da.UpdateCommand.Parameters.Add("@Hor1Hasta", SqlDbType.NVarChar, 10, "Hor1Hasta");
            da.UpdateCommand.Parameters.Add("@Hor2Desde", SqlDbType.NVarChar, 10, "Hor2Desde");
            da.UpdateCommand.Parameters.Add("@Hor2Hasta", SqlDbType.NVarChar, 10, "Hor2Hasta");
            da.UpdateCommand.Parameters.Add("@MinTurno", SqlDbType.Decimal, 0, "MinTurno");
            da.UpdateCommand.Parameters.Add("@NumAt", SqlDbType.Decimal, 0, "NumAt");
            da.UpdateCommand.Parameters.Add("@Fecha", SqlDbType.DateTime, 0, "Fecha");
            da.UpdateCommand.Parameters.Add("@ValorConsulta", SqlDbType.Decimal, 0, "ValorConsulta");
            //
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
                MedTurnDoc2Row(this, dt.Rows[0]);
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
            DataTable dt = new DataTable("MedTurnDoc");
            //
            cnn = new SqlConnection(cadenaConexion);
            da = new SqlDataAdapter(CadenaSelect, cnn);
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            string sCommand;
            sCommand = "INSERT INTO MedTurnDoc (Codigo, Especialidad, Hor1Desde, Hor1Hasta, Hor2Desde, Hor2Hasta, MinTurno, NumAt, Fecha, ValorConsulta)  VALUES(@Codigo, @Especialidad, @Hor1Desde, @Hor1Hasta, @Hor2Desde, @Hor2Hasta, @MinTurno, @NumAt, @Fecha, @ValorConsulta)";
            da.InsertCommand = new SqlCommand(sCommand, cnn);
            da.InsertCommand.Parameters.Add("@Codigo", SqlDbType.NVarChar, 15, "Codigo");
            da.InsertCommand.Parameters.Add("@Especialidad", SqlDbType.NVarChar, 50, "Especialidad");
            da.InsertCommand.Parameters.Add("@Hor1Desde", SqlDbType.NVarChar, 10, "Hor1Desde");
            da.InsertCommand.Parameters.Add("@Hor1Hasta", SqlDbType.NVarChar, 10, "Hor1Hasta");
            da.InsertCommand.Parameters.Add("@Hor2Desde", SqlDbType.NVarChar, 10, "Hor2Desde");
            da.InsertCommand.Parameters.Add("@Hor2Hasta", SqlDbType.NVarChar, 10, "Hor2Hasta");
            // TODO: Comprobar el tipo de datos a usar...
            da.InsertCommand.Parameters.Add("@MinTurno", SqlDbType.Decimal, 0, "MinTurno");
            // TODO: Comprobar el tipo de datos a usar...
            da.InsertCommand.Parameters.Add("@NumAt", SqlDbType.Decimal, 0, "NumAt");
            // TODO: Comprobar el tipo de datos a usar...
            da.InsertCommand.Parameters.Add("@Fecha", SqlDbType.DateTime, 0, "Fecha");
            // TODO: Comprobar el tipo de datos a usar...
            da.InsertCommand.Parameters.Add("@ValorConsulta", SqlDbType.Decimal, 0, "ValorConsulta");
            //
            //
            try
            {
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
            //
            nuevoMedTurnDoc(dt, this);
            //
            try
            {
                da.Update(dt);
                dt.AcceptChanges();
                return "Se ha creado un nuevo MedTurnDoc";
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
        }
        //
        public string Borrar()
        {
            string sel = "SELECT * FROM MedTurnDoc WHERE codigo = '" + this.Codigo + "' and especialidad = '" + this.Especialidad + "' and Fecha = '" + this.Fecha + "' ";
            //
            return Borrar(sel);
        }
        public string Borrar(string sel)
        {
            // Borrar el registro al que apunta esta clase
            // En caso de error, devolverá la cadena de error empezando por ERROR:.
            SqlConnection cnn;
            SqlDataAdapter da;
            DataTable dt = new DataTable("MedTurnDoc");
            //
            cnn = new SqlConnection(cadenaConexion);
            da = new SqlDataAdapter(sel, cnn);
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            string sCommand;
            sCommand = "DELETE FROM MedTurnDoc WHERE (Codigo = @Codigo and Especialidad = @Especialidad and Fecha = @Fecha)";
            da.DeleteCommand = new SqlCommand(sCommand, cnn);
            da.DeleteCommand.Parameters.Add("@p2", SqlDbType.Int, 0, "");
            //
            //
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