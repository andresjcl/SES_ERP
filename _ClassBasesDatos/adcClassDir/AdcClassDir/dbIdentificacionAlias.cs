//------------------------------------------------------------------------------
using System;
using System.Data;
using System.Data.SqlClient;
//
public class dbIdentificacionAlias
{
    // Las variables privadas
    private System.String _CodigoEmpresa;
    private System.String _NombreAlias;
    private System.String _DirecciónAlterna;
    private System.String _Teléfono_1;
    private System.String _Teléfono_2;
    private System.String _Id_Sri;
    private System.String _Observaciones;
    //
    private string ajustarAncho(string cadena, int ancho)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder(new String(' ', ancho));
        return (cadena + sb.ToString()).Substring(0, ancho).Trim();
    }
    //
    public System.String CodigoEmpresa
    {
        get
        {
            return ajustarAncho(_CodigoEmpresa, 15);
        }
        set
        {
            _CodigoEmpresa = value;
        }
    }
    public System.String NombreAlias
    {
        get
        {
            return ajustarAncho(_NombreAlias, 80);
        }
        set
        {
            _NombreAlias = value;
        }
    }
    public System.String DirecciónAlterna
    {
        get
        {
            return ajustarAncho(_DirecciónAlterna, 80);
        }
        set
        {
            _DirecciónAlterna = value;
        }
    }
    public System.String Teléfono_1
    {
        get
        {
            return ajustarAncho(_Teléfono_1, 15);
        }
        set
        {
            _Teléfono_1 = value;
        }
    }
    public System.String Teléfono_2
    {
        get
        {
            return ajustarAncho(_Teléfono_2, 15);
        }
        set
        {
            _Teléfono_2 = value;
        }
    }
    public System.String Id_Sri
    {
        get
        {
            return ajustarAncho(_Id_Sri, 7);
        }
        set
        {
            _Id_Sri = value;
        }
    }
    public System.String Observaciones
    {
        get
        {
            return ajustarAncho(_Observaciones, 80);
        }
        set
        {
            _Observaciones = value;
        }
    }
    //
    // La cadena de conexión a la base de datos
    private static string cadenaConexion = @"";
    public static string CadenaSelect = "";
    //
    public dbIdentificacionAlias()
    {
    }
    public dbIdentificacionAlias(string conex)
    {
        cadenaConexion = conex;
    }
    //
    private static dbIdentificacionAlias row2IdentificacionAlias(DataRow r)
    {
        // asigna a un objeto IdentificacionAlias los datos del dataRow indicado
        dbIdentificacionAlias oIdentificacionAlias = new dbIdentificacionAlias();
        //
        oIdentificacionAlias.CodigoEmpresa = r["CodigoEmpresa"].ToString();
        oIdentificacionAlias.NombreAlias = r["NombreAlias"].ToString();
        oIdentificacionAlias.DirecciónAlterna = r["DirecciónAlterna"].ToString();
        oIdentificacionAlias.Teléfono_1 = r["Teléfono_1"].ToString();
        oIdentificacionAlias.Teléfono_2 = r["Teléfono_2"].ToString();
        oIdentificacionAlias.Id_Sri = r["Id_Sri"].ToString();
        oIdentificacionAlias.Observaciones = r["Observaciones"].ToString();
        //
        return oIdentificacionAlias;
    }
    //
    // asigna un objeto IdentificacionAlias a la fila indicada
    private static void IdentificacionAlias2Row(dbIdentificacionAlias oIdentificacionAlias, DataRow r)
    {
        // asigna un objeto IdentificacionAlias al dataRow indicado
        r["CodigoEmpresa"] = oIdentificacionAlias.CodigoEmpresa;
        r["NombreAlias"] = oIdentificacionAlias.NombreAlias;
        r["DirecciónAlterna"] = oIdentificacionAlias.DirecciónAlterna;
        r["Teléfono_1"] = oIdentificacionAlias.Teléfono_1;
        r["Teléfono_2"] = oIdentificacionAlias.Teléfono_2;
        r["Id_Sri"] = oIdentificacionAlias.Id_Sri;
        r["Observaciones"] = oIdentificacionAlias.Observaciones;
    }
    //
    // crea una nueva fila y la asigna a un objeto IdentificacionAlias
    private static void nuevoIdentificacionAlias(DataTable dt, dbIdentificacionAlias oIdentificacionAlias)
    {
        // Crear un nuevo IdentificacionAlias
        DataRow dr = dt.NewRow();
        dbIdentificacionAlias oI = row2IdentificacionAlias(dr);
        //
        oI.CodigoEmpresa = oIdentificacionAlias.CodigoEmpresa;
        oI.NombreAlias = oIdentificacionAlias.NombreAlias;
        oI.DirecciónAlterna = oIdentificacionAlias.DirecciónAlterna;
        oI.Teléfono_1 = oIdentificacionAlias.Teléfono_1;
        oI.Teléfono_2 = oIdentificacionAlias.Teléfono_2;
        oI.Id_Sri = oIdentificacionAlias.Id_Sri;
        oI.Observaciones = oIdentificacionAlias.Observaciones;
        //
        IdentificacionAlias2Row(oI, dr);
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
        // devuelve una tabla con los datos de la tabla IdentificacionAlias
        SqlDataAdapter da;
        DataTable dt = new DataTable("IdentificacionAlias");
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
    public static dbIdentificacionAlias Buscar(string sWhere)
    {
        // Busca en la tabla los datos indicados en el parámetro
        // el parámetro contendrá lo que se usará después del WHERE
        dbIdentificacionAlias oIdentificacionAlias = null;
        SqlDataAdapter da;
        DataTable dt = new DataTable("IdentificacionAlias");
        string sel = "SELECT * FROM IdentificacionAlias WHERE " + sWhere;
        //
        da = new SqlDataAdapter(sel, cadenaConexion);
        da.Fill(dt);
        //
        if (dt.Rows.Count > 0)
        {
            oIdentificacionAlias = row2IdentificacionAlias(dt.Rows[0]);
        }
        return oIdentificacionAlias;
    }
    //
    public string Actualizar()
    {
        string sel = "SELECT * FROM IdentificacionAlias WHERE CodigoEmpresa = '" + this.CodigoEmpresa + "' and NombreAlias = '" + this.NombreAlias + "' ";
        return Actualizar(sel);
    }
    public string Actualizar(string sel)
    {
        SqlConnection cnn;
        SqlDataAdapter da;
        DataTable dt = new DataTable("IdentificacionAlias");
        CadenaSelect = sel;
        //
        cnn = new SqlConnection(cadenaConexion);
        da = new SqlDataAdapter(sel, cnn);
        da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
        string sCommand;
        //
        sCommand = "UPDATE IdentificacionAlias SET CodigoEmpresa = @CodigoEmpresa, NombreAlias = @NombreAlias, DirecciónAlterna = @DirecciónAlterna, Teléfono_1 = @Teléfono_1, Teléfono_2 = @Teléfono_2, Id_Sri = @Id_Sri, Observaciones = @Observaciones  WHERE (CodigoEmpresa = @CodigoEmpresa and Id_Sri = @Id_Sri)";
        da.UpdateCommand = new SqlCommand(sCommand, cnn);
        da.UpdateCommand.Parameters.Add("@CodigoEmpresa", SqlDbType.VarChar, 15, "CodigoEmpresa");
        da.UpdateCommand.Parameters.Add("@NombreAlias", SqlDbType.VarChar, 80, "NombreAlias");
        da.UpdateCommand.Parameters.Add("@DirecciónAlterna", SqlDbType.VarChar, 80, "DirecciónAlterna");
        da.UpdateCommand.Parameters.Add("@Teléfono_1", SqlDbType.VarChar, 15, "Teléfono_1");
        da.UpdateCommand.Parameters.Add("@Teléfono_2", SqlDbType.VarChar, 15, "Teléfono_2");
        da.UpdateCommand.Parameters.Add("@Id_Sri", SqlDbType.VarChar, 7, "Id_Sri");
        da.UpdateCommand.Parameters.Add("@Observaciones", SqlDbType.VarChar, 80, "Observaciones");
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
            IdentificacionAlias2Row(this, dt.Rows[0]);
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
        DataTable dt = new DataTable("IdentificacionAlias");
        //
        cnn = new SqlConnection(cadenaConexion);
        da = new SqlDataAdapter(CadenaSelect, cnn);
        //da = new SqlDataAdapter(CadenaSelect, cadenaConexion);
        da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
        //
        //--------------------------------------------------------------------
        string sCommand;
        //
        sCommand = "INSERT INTO IdentificacionAlias (CodigoEmpresa, NombreAlias, DirecciónAlterna, Teléfono_1, Teléfono_2, Id_Sri, Observaciones)  VALUES(@CodigoEmpresa, @NombreAlias, @DirecciónAlterna, @Teléfono_1, @Teléfono_2, @Id_Sri, @Observaciones)";
        da.InsertCommand = new SqlCommand(sCommand, cnn);
        da.InsertCommand.Parameters.Add("@CodigoEmpresa", SqlDbType.VarChar, 15, "CodigoEmpresa");
        da.InsertCommand.Parameters.Add("@NombreAlias", SqlDbType.VarChar, 80, "NombreAlias");
        da.InsertCommand.Parameters.Add("@DirecciónAlterna", SqlDbType.VarChar, 80, "DirecciónAlterna");
        da.InsertCommand.Parameters.Add("@Teléfono_1", SqlDbType.VarChar, 15, "Teléfono_1");
        da.InsertCommand.Parameters.Add("@Teléfono_2", SqlDbType.VarChar, 15, "Teléfono_2");
        da.InsertCommand.Parameters.Add("@Id_Sri", SqlDbType.VarChar, 7, "Id_Sri");
        da.InsertCommand.Parameters.Add("@Observaciones", SqlDbType.VarChar, 80, "Observaciones");
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
        nuevoIdentificacionAlias(dt, this);
        //
        try
        {
            da.Update(dt);
            dt.AcceptChanges();
            return "Se ha creado un nuevo IdentificacionAlias";
        }
        catch (Exception ex)
        {
            return "ERROR: " + ex.Message;
        }
    }
    //
    public string Borrar()
    {
        string sel = "SELECT * FROM IdentificacionAlias WHERE CodigoEmpresa = '" + this.CodigoEmpresa + "' and Id_Sri =" + this.Id_Sri;
        //
        return Borrar(sel);
    }
    public string Borrar(string sel)
    {
        // Borrar el registro al que apunta esta clase
        // En caso de error, devolverá la cadena de error empezando por ERROR:.
        SqlConnection cnn;
        SqlDataAdapter da;
        DataTable dt = new DataTable("IdentificacionAlias");
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
        //       Yo compruebo que sea un campo llamado IdClave, pero en tu caso puede ser otro
        sCommand = "DELETE FROM IdentificacionAlias WHERE (CodigoEmpresa = @CodigoEmpresa and Id_sri = @Id_sri)";
        da.DeleteCommand = new SqlCommand(sCommand, cnn);
        // TODO: Comprobar el tipo de datos a usar...
        da.DeleteCommand.Parameters.Add("@CodigoEmpresa", SqlDbType.Decimal, 0, "CodigoEmpresa");
        da.DeleteCommand.Parameters.Add("@Id_Sri", SqlDbType.VarChar , 7, Id_Sri );
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
