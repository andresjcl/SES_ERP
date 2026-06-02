using System;
using System.Data;
using System.Data.SqlClient;
//
public class DrTurno
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
    public string this[int index]
    {
        // Devuelve el contenido del campo indicado en index
        // (el índice corresponde con la columna de la tabla)
        get
        {
            if (index == 0)
            {
                return this.Codigo.ToString();
            }
            else if (index == 1)
            {
                return this.Especialidad.ToString();
            }
            else if (index == 2)
            {
                return this.Hor1Desde.ToString();
            }
            else if (index == 3)
            {
                return this.Hor1Hasta.ToString();
            }
            else if (index == 4)
            {
                return this.Hor2Desde.ToString();
            }
            else if (index == 5)
            {
                return this.Hor2Hasta.ToString();
            }
            else if (index == 6)
            {
                return this.MinTurno.ToString();
            }
            else if (index == 7)
            {
                return this.NumAt.ToString();
            }
            else if (index == 8)
            {
                return this.Fecha.ToString();
            }
            else if (index == 9)
            {
                return this.ValorConsulta.ToString();
            }
            // Para que no de error el compilador de C#
            return "";
        }
        set
        {
            if (index == 0)
            {
                this.Codigo = value;
            }
            else if (index == 1)
            {
                this.Especialidad = value;
            }
            else if (index == 2)
            {
                if (value == null ) {this.Hor1Desde = "00:00";} else { this.Hor1Desde = value;}
            }
            else if (index == 3)
            {
                if (value == null ) {this.Hor1Hasta = "00:00";} else { this.Hor1Hasta = value;}                
            }
            else if (index == 4)
            {
                if (value == null ) {this.Hor2Desde = "00:00";} else { this.Hor2Desde = value;}
            }
            else if (index == 5)
            {
                if (value == null) { this.Hor2Hasta = "00:00"; } else { this.Hor2Hasta = value; }                
            }
            else if (index == 6)
            {
                try
                {
                    this.MinTurno = System.Decimal.Parse("0" + value);
                }
                catch
                {
                    this.MinTurno = System.Decimal.Parse("0");
                }
            }
            else if (index == 7)
            {
                try
                {
                    this.NumAt = System.Decimal.Parse("0" + value);
                }
                catch
                {
                    this.NumAt = System.Decimal.Parse("0");
                }
            }
            else if (index == 8)
            {
                try
                {
                    this.Fecha = System.DateTime.Parse(value);
                }
                catch
                {
                    this.Fecha = new System.DateTime(1900, 1, 1);
                }
            }
            else if (index == 9)
            {
                try
                {
                    this.ValorConsulta = System.Decimal.Parse("0" + value);
                }
                catch
                {
                    this.ValorConsulta = System.Decimal.Parse("0");
                }
            }
        }
    }
    public string this[string index]
    {
        // Devuelve el contenido del campo indicado en index
        // (el índice corresponde al nombre de la columna)
        get
        {
            if (index == "Codigo")
            {
                return this.Codigo.ToString();
            }
            else if (index == "Especialidad")
            {
                return this.Especialidad.ToString();
            }
            else if (index == "Hor1Desde")
            {
                return this.Hor1Desde.ToString();
            }
            else if (index == "Hor1Hasta")
            {
                return this.Hor1Hasta.ToString();
            }
            else if (index == "Hor2Desde")
            {
                return this.Hor2Desde.ToString();
            }
            else if (index == "Hor2Hasta")
            {
                return this.Hor2Hasta.ToString();
            }
            else if (index == "MinTurno")
            {
                return this.MinTurno.ToString();
            }
            else if (index == "NumAt")
            {
                return this.NumAt.ToString();
            }
            else if (index == "Fecha")
            {
                return this.Fecha.ToString();
            }
            else if (index == "ValorConsulta")
            {
                return this.ValorConsulta.ToString();
            }
            // Para que no de error el compilador de C#
            return "";
        }
        set
        {
            if (index == "Codigo")
            {
                this.Codigo = value;
            }
            else if (index == "Especialidad")
            {
                this.Especialidad = value;
            }
            else if (index == "Hor1Desde")
            {
                if (value == null ) {this.Hor1Desde = "00:00";} else { this.Hor1Desde = value;}
            }
            else if (index == "Hor1Hasta")
            {
                if (value == null ) {this.Hor1Hasta = "00:00";} else { this.Hor1Hasta = value;}                
            }
            else if (index == "Hor2Desde")
            {
                if (value == null ) {this.Hor2Desde = "00:00";} else { this.Hor2Desde = value;}
            }
            else if (index == "Hor2Hasta")
            {
                if (value == null) { this.Hor2Hasta = "00:00"; } else { this.Hor2Hasta = value; }                
            }
            else if (index == "MinTurno")
            {
                try
                {
                    this.MinTurno = System.Decimal.Parse("0" + value);
                }
                catch
                {
                    this.MinTurno = System.Decimal.Parse("0");
                }
            }
            else if (index == "NumAt")
            {
                try
                {
                    this.NumAt = System.Decimal.Parse("0" + value);
                }
                catch
                {
                    this.NumAt = System.Decimal.Parse("0");
                }
            }
            else if (index == "Fecha")
            {
                try
                {
                    this.Fecha = System.DateTime.Parse(value);
                }
                catch
                {
                    this.Fecha = new System.DateTime(1900, 1, 1);
                }
            }
            else if (index == "ValorConsulta")
            {
                try
                {
                    this.ValorConsulta = System.Decimal.Parse("0" + value);
                }
                catch
                {
                    this.ValorConsulta = System.Decimal.Parse("0");
                }
            }
        }
    }
    //
    // Campos y métodos compartidos (estáticos) para gestionar la base de datos
    //
    // La cadena de conexión a la base de datos
    private static string cadenaConexion = @"Data Source=serverdes; Initial Catalog=bdadcomdxfscp; user id=sa; password=123qweASDZXC";
    // La cadena de selección
    public static string CadenaSelect = "SELECT * FROM DrTurno";
    //
    public DrTurno()
    {
    }
    public DrTurno(string conex)
    {
        cadenaConexion = conex;
    }
    //
    // Métodos compartidos (estáticos) privados
    //
    // asigna una fila de la tabla a un objeto DrTurno
    private static DrTurno row2DrTurno(DataRow r)
    {
        // asigna a un objeto DrTurno los datos del dataRow indicado
        DrTurno oDrTurno = new DrTurno();
        //
        oDrTurno.Codigo = r["Codigo"].ToString();
        oDrTurno.Especialidad = r["Especialidad"].ToString();
        oDrTurno.Hor1Desde = r["Hor1Desde"].ToString();
        oDrTurno.Hor1Hasta = r["Hor1Hasta"].ToString();
        oDrTurno.Hor2Desde = r["Hor2Desde"].ToString();
        oDrTurno.Hor2Hasta = r["Hor2Hasta"].ToString();
        oDrTurno.MinTurno = System.Decimal.Parse("0" + r["MinTurno"].ToString());
        oDrTurno.NumAt = System.Decimal.Parse("0" + r["NumAt"].ToString());
        try
        {
            oDrTurno.Fecha = DateTime.Parse(r["Fecha"].ToString());
        }
        catch
        {
            oDrTurno.Fecha = new DateTime(1900, 1, 1);
        }
        oDrTurno.ValorConsulta = System.Decimal.Parse("0" + r["ValorConsulta"].ToString());
        //
        return oDrTurno;
    }
    //
    // asigna un objeto DrTurno a la fila indicada
    private static void DrTurno2Row(DrTurno oDrTurno, DataRow r)
    {
        // asigna un objeto DrTurno al dataRow indicado
        r["Codigo"] = oDrTurno.Codigo;
        r["Especialidad"] = oDrTurno.Especialidad;
        r["Hor1Desde"] = oDrTurno.Hor1Desde;
        r["Hor1Hasta"] = oDrTurno.Hor1Hasta;
        r["Hor2Desde"] = oDrTurno.Hor2Desde;
        r["Hor2Hasta"] = oDrTurno.Hor2Hasta;
        r["MinTurno"] = oDrTurno.MinTurno;
        r["NumAt"] = oDrTurno.NumAt;
        r["Fecha"] = oDrTurno.Fecha;
        r["ValorConsulta"] = oDrTurno.ValorConsulta;
    }
    //
    // crea una nueva fila y la asigna a un objeto DrTurno
    private static void nuevoDrTurno(DataTable dt, DrTurno oDrTurno)
    {
        // Crear un nuevo DrTurno
        DataRow dr = dt.NewRow();
        DrTurno oD = row2DrTurno(dr);
        //
        oD.Codigo = oDrTurno.Codigo;
        oD.Especialidad = oDrTurno.Especialidad;
        oD.Hor1Desde = oDrTurno.Hor1Desde;
        oD.Hor1Hasta = oDrTurno.Hor1Hasta;
        oD.Hor2Desde = oDrTurno.Hor2Desde;
        oD.Hor2Hasta = oDrTurno.Hor2Hasta;
        oD.MinTurno = oDrTurno.MinTurno;
        oD.NumAt = oDrTurno.NumAt;
        oD.Fecha = oDrTurno.Fecha;
        oD.ValorConsulta = oDrTurno.ValorConsulta;
        //
        DrTurno2Row(oD, dr);
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
        // devuelve una tabla con los datos de la tabla DrTurno
        SqlDataAdapter da;
        DataTable dt = new DataTable("DrTurno");
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
    public static DrTurno Buscar(string sWhere)
    {
        // Busca en la tabla los datos indicados en el parámetro
        // el parámetro contendrá lo que se usará después del WHERE
        DrTurno oDrTurno = null;
        SqlDataAdapter da;
        DataTable dt = new DataTable("DrTurno");
        string sel = "SELECT * FROM DrTurno WHERE " + sWhere;
        //
        da = new SqlDataAdapter(sel, cadenaConexion);
        da.Fill(dt);
        //
        if (dt.Rows.Count > 0)
        {
            oDrTurno = row2DrTurno(dt.Rows[0]);
        }
        return oDrTurno;
    }
    //
    // Actualizar: Actualiza los datos en la tabla usando la instancia actual
    //             Si la instancia no hace referencia a un registro existente, se creará uno nuevo
    //             Para comprobar si el objeto en memoria coincide con uno existente,
    //             se comprueba si el ID existe en la tabla.
    //             TODO: Si en lugar de ID usas otro campo, indicalo en la cadena SELECT
    //                   También puedes usar la sobrecarga en la que se indica la cadena SELECT a usar
    public string Actualizar()
    {
        // TODO: Poner aquí la selección a realizar para acceder a este registro
        //       yo uso el ID que es el identificador único de cada registro
        string sel = "SELECT * FROM DrTurno WHERE codigo = '" + this.Codigo  + "' and especialidad = '" + this.Especialidad + "' and fecha = '" + this.Fecha + "' ";
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
        DataTable dt = new DataTable("DrTurno");
        CadenaSelect = sel;

        cnn = new SqlConnection(cadenaConexion);
        //da = new SqlDataAdapter(CadenaSelect, cnn);
        da = new SqlDataAdapter(sel, cnn);
        da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
        //
        //-------------------------------------------
        // Esta no es la más óptima, pero funcionará
        //-------------------------------------------
        //SqlCommandBuilder cb = new SqlCommandBuilder(da);
        //da.UpdateCommand = cb.GetUpdateCommand();
        //
        //--------------------------------------------------------------------
        // Esta está más optimizada pero debes comprobar que funciona bien...
        //--------------------------------------------------------------------
        string sCommand;
        //
        // El comando UPDATE
        // TODO: Comprobar cual es el campo de índice principal (sin duplicados)
        //       Yo compruebo que sea un campo llamado ID, pero en tu caso puede ser otro
        //       Ese campo, (en mi caso ID) será el que hay que poner al final junto al WHERE.
        sCommand = "UPDATE DrTurno SET Codigo = @Codigo, Especialidad = @Especialidad, Hor1Desde = @Hor1Desde, Hor1Hasta = @Hor1Hasta, Hor2Desde = @Hor2Desde, Hor2Hasta = @Hor2Hasta, MinTurno = @MinTurno, NumAt = @NumAt, Fecha = @Fecha, ValorConsulta = @ValorConsulta  WHERE (Codigo = @Codigo and Especialidad = @Especialidad and Fecha = @Fecha)";
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
            DrTurno2Row(this, dt.Rows[0]);
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
        DataTable dt = new DataTable("DrTurno");
        //
        cnn = new SqlConnection(cadenaConexion);
        da = new SqlDataAdapter(CadenaSelect, cnn);
        //da = new SqlDataAdapter(CadenaSelect, cadenaConexion);
        da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
        //
        //-------------------------------------------
        // Esta no es la más óptima, pero funcionará
        //-------------------------------------------
        //SqlCommandBuilder cb = new SqlCommandBuilder(da);
        //da.InsertCommand = cb.GetInsertCommand();
        //
        //--------------------------------------------------------------------
        // Esta está más optimizada pero debes comprobar que funciona bien...
        //--------------------------------------------------------------------
        string sCommand;
        //
        // El comando INSERT
        // TODO: No incluir el campo de clave primaria incremental
        //       Yo compruebo que sea un campo llamado ID, pero en tu caso puede ser otro
        sCommand = "INSERT INTO DrTurno (Codigo, Especialidad, Hor1Desde, Hor1Hasta, Hor2Desde, Hor2Hasta, MinTurno, NumAt, Fecha, ValorConsulta)  VALUES(@Codigo, @Especialidad, @Hor1Desde, @Hor1Hasta, @Hor2Desde, @Hor2Hasta, @MinTurno, @NumAt, @Fecha, @ValorConsulta)";
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
        nuevoDrTurno(dt, this);
        //
        try
        {
            da.Update(dt);
            dt.AcceptChanges();
            return "Se ha creado un nuevo DrTurno";
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
        //       yo uso el ID que es el identificador único de cada registro
        string sel = "SELECT * FROM DrTurno WHERE codigo = '" + this.Codigo + "' and especialidad = '" + this.Especialidad + "' and Fecha = '" + this.Fecha + "' ";
        //
        return Borrar(sel);
    }
    public string Borrar(string sel)
    {
        // Borrar el registro al que apunta esta clase
        // En caso de error, devolverá la cadena de error empezando por ERROR:.
        SqlConnection cnn;
        SqlDataAdapter da;
        DataTable dt = new DataTable("DrTurno");
        //
        cnn = new SqlConnection(cadenaConexion);
        da = new SqlDataAdapter(sel, cnn);
        da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
        //
        //-------------------------------------------
        // Esta no es la más óptima, pero funcionará
        //-------------------------------------------
        //SqlCommandBuilder cb = new SqlCommandBuilder(da);
        //da.DeleteCommand = cb.GetDeleteCommand();
        //
        //
        //--------------------------------------------------------------------
        // Esta está más optimizada pero debes comprobar que funciona bien...
        //--------------------------------------------------------------------
        string sCommand;
        //
        // El comando DELETE
        // TODO: Sólo incluir el campo de clave primaria incremental
        //       Yo compruebo que sea un campo llamado ID, pero en tu caso puede ser otro
        sCommand = "DELETE FROM DrTurno WHERE (Codigo = @Codigo and Especialidad = @Especialidad and Fecha = @Fecha)";
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
