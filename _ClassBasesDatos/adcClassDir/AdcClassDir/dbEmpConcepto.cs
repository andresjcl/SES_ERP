// Fecha: 28/ago/2013 23:14:26
//
//------------------------------------------------------------------------------
using System;
using System.Data;
using System.Data.SqlClient;
//
public class AdcEmplCon
{
    // Las variables privadas
    // TODO: Revisar los tipos de los campos
    private System.String _IdEmpleado;
    private System.Int32 _idConcepto;
    private System.DateTime _FechaAsignacion;
    private System.String _UsuarioAsigna;
    private System.String _EquipoAsigna;
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

    public System.String IdEmpleado
    {
        get
        {
            return ajustarAncho(_IdEmpleado, 20);
        }
        set
        {
            _IdEmpleado = value;
        }
    }
    public System.Int32 idConcepto
    {
        get
        {
            return _idConcepto;
        }
        set
        {
            _idConcepto = value;
        }
    }
    public System.DateTime FechaAsignacion
    {
        get
        {
            return _FechaAsignacion;
        }
        set
        {
            _FechaAsignacion = value;
        }
    }
    public System.String UsuarioAsigna
    {
        get
        {
            return ajustarAncho(_UsuarioAsigna, 50);
        }
        set
        {
            _UsuarioAsigna = value;
        }
    }
    public System.String EquipoAsigna
    {
        get
        {
            return ajustarAncho(_EquipoAsigna, 50);
        }
        set
        {
            _EquipoAsigna = value;
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
                return this.IdEmpleado.ToString();
            }
            else if (index == 1)
            {
                return this.idConcepto.ToString();
            }
            else if (index == 2)
            {
                return this.FechaAsignacion.ToString();
            }
            else if (index == 3)
            {
                return this.UsuarioAsigna.ToString();
            }
            else if (index == 4)
            {
                return this.EquipoAsigna.ToString();
            }
            // Para que no de error el compilador de C#
            return "";
        }
        set
        {
            if (index == 0)
            {
                this.IdEmpleado = value;
            }
            else if (index == 1)
            {
                try
                {
                    this.idConcepto = System.Int32.Parse("0" + value);
                }
                catch
                {
                    this.idConcepto = System.Int32.Parse("0");
                }
            }
            else if (index == 2)
            {
                try
                {
                    this.FechaAsignacion = System.DateTime.Parse(value);
                }
                catch
                {
                    this.FechaAsignacion = System.DateTime.Now;
                }
            }
            else if (index == 3)
            {
                this.UsuarioAsigna = value;
            }
            else if (index == 4)
            {
                this.EquipoAsigna = value;
            }
        }
    }
    public string this[string index]
    {
        // Devuelve el contenido del campo indicado en index
        // (el índice corresponde al nombre de la columna)
        get
        {
            if (index == "IdEmpleado")
            {
                return this.IdEmpleado.ToString();
            }
            else if (index == "idConcepto")
            {
                return this.idConcepto.ToString();
            }
            else if (index == "FechaAsignacion")
            {
                return this.FechaAsignacion.ToString();
            }
            else if (index == "UsuarioAsigna")
            {
                return this.UsuarioAsigna.ToString();
            }
            else if (index == "EquipoAsigna")
            {
                return this.EquipoAsigna.ToString();
            }
            // Para que no de error el compilador de C#
            return "";
        }
        set
        {
            if (index == "IdEmpleado")
            {
                this.IdEmpleado = value;
            }
            else if (index == "idConcepto")
            {
                try
                {
                    this.idConcepto = System.Int32.Parse("0" + value);
                }
                catch
                {
                    this.idConcepto = System.Int32.Parse("0");
                }
            }
            else if (index == "FechaAsignacion")
            {
                try
                {
                    this.FechaAsignacion = System.DateTime.Parse(value);
                }
                catch
                {
                    this.FechaAsignacion = System.DateTime.Now;
                }
            }
            else if (index == "UsuarioAsigna")
            {
                this.UsuarioAsigna = value;
            }
            else if (index == "EquipoAsigna")
            {
                this.EquipoAsigna = value;
            }
        }
    }
    //
    // Campos y métodos compartidos (estáticos) para gestionar la base de datos
    //
    // La cadena de conexión a la base de datos
    private static string cadenaConexion = @"";
    // La cadena de selección
    public static string CadenaSelect = "SELECT * FROM AdcEmplCon";
    //
    public AdcEmplCon()
    {
    }
    public AdcEmplCon(string conex)
    {
        cadenaConexion = conex;
    }
    //
    // Métodos compartidos (estáticos) privados
    //
    // asigna una fila de la tabla a un objeto AdcEmplCon
    private static AdcEmplCon row2AdcEmplCon(DataRow r)
    {
        // asigna a un objeto AdcEmplCon los datos del dataRow indicado
        AdcEmplCon oAdcEmplCon = new AdcEmplCon();
        //
        oAdcEmplCon.IdEmpleado = r["IdEmpleado"].ToString();
        oAdcEmplCon.idConcepto = System.Int32.Parse("0" + r["idConcepto"].ToString());
        try
        {
            oAdcEmplCon.FechaAsignacion = DateTime.Parse(r["FechaAsignacion"].ToString());
        }
        catch
        {
            oAdcEmplCon.FechaAsignacion = DateTime.Now;
        }
        oAdcEmplCon.UsuarioAsigna = r["UsuarioAsigna"].ToString();
        oAdcEmplCon.EquipoAsigna = r["EquipoAsigna"].ToString();
        //
        return oAdcEmplCon;
    }
    //
    // asigna un objeto AdcEmplCon a la fila indicada
    private static void AdcEmplCon2Row(AdcEmplCon oAdcEmplCon, DataRow r)
    {
        // asigna un objeto AdcEmplCon al dataRow indicado
        r["IdEmpleado"] = oAdcEmplCon.IdEmpleado;
        r["idConcepto"] = oAdcEmplCon.idConcepto;
        r["FechaAsignacion"] = oAdcEmplCon.FechaAsignacion;
        r["UsuarioAsigna"] = oAdcEmplCon.UsuarioAsigna;
        r["EquipoAsigna"] = oAdcEmplCon.EquipoAsigna;
    }
    //
    // crea una nueva fila y la asigna a un objeto AdcEmplCon
    private static void nuevoAdcEmplCon(DataTable dt, AdcEmplCon oAdcEmplCon)
    {
        // Crear un nuevo AdcEmplCon
        DataRow dr = dt.NewRow();
        AdcEmplCon oA = row2AdcEmplCon(dr);
        //
        oA.IdEmpleado = oAdcEmplCon.IdEmpleado;
        oA.idConcepto = oAdcEmplCon.idConcepto;
        oA.FechaAsignacion = oAdcEmplCon.FechaAsignacion;
        oA.UsuarioAsigna = oAdcEmplCon.UsuarioAsigna;
        oA.EquipoAsigna = oAdcEmplCon.EquipoAsigna;
        //
        AdcEmplCon2Row(oA, dr);
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
        // devuelve una tabla con los datos de la tabla AdcEmplCon
        SqlDataAdapter da;
        DataTable dt = new DataTable("AdcEmplCon");
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
    public static AdcEmplCon Buscar(string sWhere)
    {
        // Busca en la tabla los datos indicados en el parámetro
        // el parámetro contendrá lo que se usará después del WHERE
        AdcEmplCon oAdcEmplCon = null;
        SqlDataAdapter da;
        DataTable dt = new DataTable("AdcEmplCon");
        string sel = "SELECT * FROM AdcEmplCon WHERE " + sWhere;
        //
        da = new SqlDataAdapter(sel, cadenaConexion);
        da.Fill(dt);
        //
        if (dt.Rows.Count > 0)
        {
            oAdcEmplCon = row2AdcEmplCon(dt.Rows[0]);
        }
        return oAdcEmplCon;
    }
    //
    //                   También puedes usar la sobrecarga en la que se indica la cadena SELECT a usar
    public string Actualizar()
    {
        string sel = "SELECT * FROM AdcEmplCon WHERE IdEmpleado = '" + IdEmpleado + "' and IdConcepto = '" + idConcepto + "' ";
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
        DataTable dt = new DataTable("AdcEmplCon");
        CadenaSelect = sel;
        //
        cnn = new SqlConnection(cadenaConexion);
        da = new SqlDataAdapter(sel, cnn);
        da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
        //
        //--------------------------------------------------------------------
        string sCommand;
        //
        // El comando UPDATE
        sCommand = "UPDATE AdcEmplCon SET IdEmpleado = @IdEmpleado, idConcepto = @idConcepto, FechaAsignacion = @FechaAsignacion, UsuarioAsigna = @UsuarioAsigna, EquipoAsigna = @EquipoAsigna  WHERE (IdEmpleado = @IdEmpleado and IdConcepto = @IdConcepto)";
        da.UpdateCommand = new SqlCommand(sCommand, cnn);
        da.UpdateCommand.Parameters.Add("@IdEmpleado", SqlDbType.VarChar, 20, "IdEmpleado");
        da.UpdateCommand.Parameters.Add("@idConcepto", SqlDbType.Int, 0, "idConcepto");
        da.UpdateCommand.Parameters.Add("@FechaAsignacion", SqlDbType.DateTime, 0, "FechaAsignacion");
        da.UpdateCommand.Parameters.Add("@UsuarioAsigna", SqlDbType.VarChar, 50, "UsuarioAsigna");
        da.UpdateCommand.Parameters.Add("@EquipoAsigna", SqlDbType.VarChar, 50, "EquipoAsigna");
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
            AdcEmplCon2Row(this, dt.Rows[0]);
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
        DataTable dt = new DataTable("AdcEmplCon");
        //
        cnn = new SqlConnection(cadenaConexion);
        da = new SqlDataAdapter(CadenaSelect, cnn);
        //da = new SqlDataAdapter(CadenaSelect, cadenaConexion);
        da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
        //
        //--------------------------------------------------------------------
        string sCommand;
        //
        // El comando INSERT
        sCommand = "INSERT INTO AdcEmplCon (IdEmpleado, idConcepto, FechaAsignacion, UsuarioAsigna, EquipoAsigna)  VALUES(@IdEmpleado, @idConcepto, @FechaAsignacion, @UsuarioAsigna, @EquipoAsigna)";
        da.InsertCommand = new SqlCommand(sCommand, cnn);
        da.InsertCommand.Parameters.Add("@IdEmpleado", SqlDbType.VarChar, 20, "IdEmpleado");
        da.InsertCommand.Parameters.Add("@idConcepto", SqlDbType.Int, 0, "idConcepto");
        da.InsertCommand.Parameters.Add("@FechaAsignacion", SqlDbType.DateTime, 0, "FechaAsignacion");
        da.InsertCommand.Parameters.Add("@UsuarioAsigna", SqlDbType.VarChar, 50, "UsuarioAsigna");
        da.InsertCommand.Parameters.Add("@EquipoAsigna", SqlDbType.VarChar, 50, "EquipoAsigna");
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
        nuevoAdcEmplCon(dt, this);
        //
        try
        {
            da.Update(dt);
            dt.AcceptChanges();
            return "Se ha creado un nuevo AdcEmplCon";
        }
        catch (Exception ex)
        {
            return "ERROR: " + ex.Message;
        }
    }
    //
    public string Borrar()
    {
        string sel = "SELECT * FROM AdcEmplCon WHERE IdEmpleado = '" + IdEmpleado + "' AND IdConcepto = '" + idConcepto + "' ";
        //
        return Borrar(sel);
    }
    public string Borrar(string sel)
    {
        // En caso de error, devolverá la cadena de error empezando por ERROR:.
        SqlConnection cnn;
        SqlDataAdapter da;
        DataTable dt = new DataTable("AdcEmplCon");
        //
        cnn = new SqlConnection(cadenaConexion);
        da = new SqlDataAdapter(sel, cnn);
        da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
        //
        //--------------------------------------------------------------------
        string sCommand;
        //
        // El comando DELETE
        // TODO: Sólo incluir el campo de clave primaria incremental
        sCommand = "DELETE FROM AdcEmplCon WHERE (@IdEmpleado=IdEmpleado AND @idConcepto=idConcepto);";
        da.DeleteCommand = new SqlCommand(sCommand, cnn);
        da.DeleteCommand.Parameters.Add("@IdEmpleado", SqlDbType.VarChar, 20, "IdEmpleado");
        da.DeleteCommand.Parameters.Add("@idConcepto", SqlDbType.Int, 0, "idConcepto");
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
