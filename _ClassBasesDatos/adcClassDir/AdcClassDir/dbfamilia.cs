using System;
using System.Data;
using System.Data.SqlClient;
//
public class dbFamilia
{
    // Las variables privadas
    // TODO: Revisar los tipos de los campos
    private System.String _CodEmpleado;
    private System.String _CEDULA;
    private System.String _Nombres;
    private System.String _Parentesco;
    private System.DateTime _FechaNacimiento;
    private System.String _Sexo;
    private System.String _EstadoCivil;
    private System.String _Direccion;
    private System.String _Teléfono_1;
    private System.String _Teléfono_2;
    private System.String _Ocupacion;
    private System.String _EsDependiente;
    private System.String _EsMinusvalido;
    private System.Decimal _IdClave;
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
    public System.String CodEmpleado
    {
        get
        {
            return ajustarAncho(_CodEmpleado, 15);
        }
        set
        {
            _CodEmpleado = value;
        }
    }
    public System.String CEDULA
    {
        get
        {
            return ajustarAncho(_CEDULA, 15);
        }
        set
        {
            _CEDULA = value;
        }
    }
    public System.String Nombres
    {
        get
        {
            return ajustarAncho(_Nombres, 50);
        }
        set
        {
            _Nombres = value;
        }
    }
    public System.String Parentesco
    {
        get
        {
            return ajustarAncho(_Parentesco, 40);
        }
        set
        {
            _Parentesco = value;
        }
    }
    public System.DateTime FechaNacimiento
    {
        get
        {
            return _FechaNacimiento;
        }
        set
        {
            _FechaNacimiento = value;
        }
    }
    public System.String Sexo
    {
        get
        {
            return ajustarAncho(_Sexo, 15);
        }
        set
        {
            _Sexo = value;
        }
    }
    public System.String EstadoCivil
    {
        get
        {
            return ajustarAncho(_EstadoCivil, 20);
        }
        set
        {
            _EstadoCivil = value;
        }
    }
    public System.String Direccion
    {
        get
        {
            return ajustarAncho(_Direccion, 50);
        }
        set
        {
            _Direccion = value;
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
    public System.String Ocupacion
    {
        get
        {
            return ajustarAncho(_Ocupacion, 50);
        }
        set
        {
            _Ocupacion = value;
        }
    }
    public System.String EsDependiente
    {
        get
        {
            return ajustarAncho(_EsDependiente, 2);
        }
        set
        {
            _EsDependiente = value;
        }
    }
    public System.String EsMinusvalido
    {
        get
        {
            return ajustarAncho(_EsMinusvalido, 2);
        }
        set
        {
            _EsMinusvalido = value;
        }
    }
    public System.Decimal IdClave
    {
        get
        {
            return _IdClave;
        }
        set
        {
            _IdClave = value;
        }
    }
    //
    // La cadena de conexión a la base de datos
    private static string cadenaConexion = @"";
    // La cadena de selección
    public static string CadenaSelect = "";
    //
    public dbFamilia()
    {
    }
    public dbFamilia(string conex)
    {
        cadenaConexion = conex;
    }
    //
    // Métodos compartidos (estáticos) privados
    //
    // asigna una fila de la tabla a un objeto RolFam
    private static dbFamilia row2RolFam(DataRow r)
    {
        // asigna a un objeto RolFam los datos del dataRow indicado
        dbFamilia oRolFam = new dbFamilia();
        //
        oRolFam.CodEmpleado = r["CodEmpleado"].ToString();
        oRolFam.CEDULA = r["CEDULA"].ToString();
        oRolFam.Nombres = r["Nombres"].ToString();
        oRolFam.Parentesco = r["Parentesco"].ToString();
        try
        {
            oRolFam.FechaNacimiento = DateTime.Parse(r["FechaNacimiento"].ToString());
        }
        catch
        {
            oRolFam.FechaNacimiento = new DateTime(1900, 1, 1);
        }
        oRolFam.Sexo = r["Sexo"].ToString();
        oRolFam.EstadoCivil = r["EstadoCivil"].ToString();
        oRolFam.Direccion = r["Direccion"].ToString();
        oRolFam.Teléfono_1 = r["Teléfono_1"].ToString();
        oRolFam.Teléfono_2 = r["Teléfono_2"].ToString();
        oRolFam.Ocupacion = r["Ocupacion"].ToString();
        oRolFam.EsDependiente = r["EsDependiente"].ToString();
        oRolFam.EsMinusvalido = r["EsMinusvalido"].ToString();
        oRolFam.IdClave = System.Decimal.Parse("0" + r["IdClave"].ToString());
        //
        return oRolFam;
    }
    //
    // asigna un objeto RolFam a la fila indicada
    private static void RolFam2Row(dbFamilia oRolFam, DataRow r)
    {
        // asigna un objeto RolFam al dataRow indicado
        r["CodEmpleado"] = oRolFam.CodEmpleado;
        r["CEDULA"] = oRolFam.CEDULA;
        r["Nombres"] = oRolFam.Nombres;
        r["Parentesco"] = oRolFam.Parentesco;
        r["FechaNacimiento"] = oRolFam.FechaNacimiento;
        r["Sexo"] = oRolFam.Sexo;
        r["EstadoCivil"] = oRolFam.EstadoCivil;
        r["Direccion"] = oRolFam.Direccion;
        r["Teléfono_1"] = oRolFam.Teléfono_1;
        r["Teléfono_2"] = oRolFam.Teléfono_2;
        r["Ocupacion"] = oRolFam.Ocupacion;
        r["EsDependiente"] = oRolFam.EsDependiente;
        r["EsMinusvalido"] = oRolFam.EsMinusvalido;
        // TODO: Comprueba si esta asignación debe hacerse
        //       pero mejor lo dejas comentado ya que es un campo autoincremental o único
        //r["IdClave"] = oRolFam.IdClave;
    }
    //
    // crea una nueva fila y la asigna a un objeto RolFam
    private static void nuevoRolFam(DataTable dt, dbFamilia oRolFam)
    {
        // Crear un nuevo RolFam
        DataRow dr = dt.NewRow();
        dbFamilia oR = row2RolFam(dr);
        //
        oR.CodEmpleado = oRolFam.CodEmpleado;
        oR.CEDULA = oRolFam.CEDULA;
        oR.Nombres = oRolFam.Nombres;
        oR.Parentesco = oRolFam.Parentesco;
        oR.FechaNacimiento = oRolFam.FechaNacimiento;
        oR.Sexo = oRolFam.Sexo;
        oR.EstadoCivil = oRolFam.EstadoCivil;
        oR.Direccion = oRolFam.Direccion;
        oR.Teléfono_1 = oRolFam.Teléfono_1;
        oR.Teléfono_2 = oRolFam.Teléfono_2;
        oR.Ocupacion = oRolFam.Ocupacion;
        oR.EsDependiente = oRolFam.EsDependiente;
        oR.EsMinusvalido = oRolFam.EsMinusvalido;
        oR.IdClave = oRolFam.IdClave;
        //
        RolFam2Row(oR, dr);
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
        // devuelve una tabla con los datos de la tabla RolFam
        SqlDataAdapter da;
        DataTable dt = new DataTable("RolFam");
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
    public static dbFamilia Buscar(string sWhere)
    {
        // Busca en la tabla los datos indicados en el parámetro
        // el parámetro contendrá lo que se usará después del WHERE
        dbFamilia oRolFam = null;
        SqlDataAdapter da;
        DataTable dt = new DataTable("RolFam");
        string sel = "SELECT * FROM RolFam WHERE " + sWhere;
        //
        da = new SqlDataAdapter(sel, cadenaConexion);
        da.Fill(dt);
        //
        if (dt.Rows.Count > 0)
        {
            oRolFam = row2RolFam(dt.Rows[0]);
        }
        return oRolFam;
    }
    //
    public string Actualizar()
    {
        string sel = "SELECT * FROM RolFam WHERE codEmpleado = '" + this.CodEmpleado + "' and cedula = '" + this.CEDULA +"' ";
        return Actualizar(sel);
    }
    public string Actualizar(string sel)
    {
        SqlConnection cnn;
        SqlDataAdapter da;
        DataTable dt = new DataTable("RolFam");
        CadenaSelect = sel;
        //
        cnn = new SqlConnection(cadenaConexion);
        da = new SqlDataAdapter(sel, cnn);
        da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
        string sCommand;
        //
        // El comando UPDATE
        sCommand = "UPDATE RolFam SET CodEmpleado = @CodEmpleado, CEDULA = @CEDULA, Nombres = @Nombres, Parentesco = @Parentesco, FechaNacimiento = @FechaNacimiento, Sexo = @Sexo, EstadoCivil = @EstadoCivil, Direccion = @Direccion, Teléfono_1 = @Teléfono_1, Teléfono_2 = @Teléfono_2, Ocupacion = @Ocupacion, EsDependiente = @EsDependiente, EsMinusvalido = @EsMinusvalido  WHERE (codEmpleado = @codEmpleado and cedula = @CEDULA)";
        da.UpdateCommand = new SqlCommand(sCommand, cnn);
        da.UpdateCommand.Parameters.Add("@CodEmpleado", SqlDbType.NVarChar, 15, "CodEmpleado");
        da.UpdateCommand.Parameters.Add("@CEDULA", SqlDbType.NVarChar, 15, "CEDULA");
        da.UpdateCommand.Parameters.Add("@Nombres", SqlDbType.NVarChar, 50, "Nombres");
        da.UpdateCommand.Parameters.Add("@Parentesco", SqlDbType.NVarChar, 40, "Parentesco");
        da.UpdateCommand.Parameters.Add("@FechaNacimiento", SqlDbType.DateTime, 0, "FechaNacimiento");
        da.UpdateCommand.Parameters.Add("@Sexo", SqlDbType.NVarChar, 15, "Sexo");
        da.UpdateCommand.Parameters.Add("@EstadoCivil", SqlDbType.NVarChar, 20, "EstadoCivil");
        da.UpdateCommand.Parameters.Add("@Direccion", SqlDbType.NVarChar, 50, "Direccion");
        da.UpdateCommand.Parameters.Add("@Teléfono_1", SqlDbType.NVarChar, 15, "Teléfono_1");
        da.UpdateCommand.Parameters.Add("@Teléfono_2", SqlDbType.NVarChar, 15, "Teléfono_2");
        da.UpdateCommand.Parameters.Add("@Ocupacion", SqlDbType.NVarChar, 50, "Ocupacion");
        da.UpdateCommand.Parameters.Add("@EsDependiente", SqlDbType.NVarChar, 2, "EsDependiente");
        da.UpdateCommand.Parameters.Add("@EsMinusvalido", SqlDbType.NVarChar, 2, "EsMinusvalido");
        da.UpdateCommand.Parameters.Add("@IdClave", SqlDbType.Decimal, 0, "IdClave");
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
            RolFam2Row(this, dt.Rows[0]);
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
        DataTable dt = new DataTable("RolFam");
        //
        cnn = new SqlConnection(cadenaConexion);
        da = new SqlDataAdapter(CadenaSelect, cnn);
        //da = new SqlDataAdapter(CadenaSelect, cadenaConexion);
        da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
        //--------------------------------------------------------------------
        string sCommand;
        //
        sCommand = "INSERT INTO RolFam (CodEmpleado, CEDULA, Nombres, Parentesco, FechaNacimiento, Sexo, EstadoCivil, Direccion, Teléfono_1, Teléfono_2, Ocupacion, EsDependiente, EsMinusvalido)  VALUES(@CodEmpleado, @CEDULA, @Nombres, @Parentesco, @FechaNacimiento, @Sexo, @EstadoCivil, @Direccion, @Teléfono_1, @Teléfono_2, @Ocupacion, @EsDependiente, @EsMinusvalido)";
        da.InsertCommand = new SqlCommand(sCommand, cnn);
        da.InsertCommand.Parameters.Add("@CodEmpleado", SqlDbType.NVarChar, 15, "CodEmpleado");
        da.InsertCommand.Parameters.Add("@CEDULA", SqlDbType.NVarChar, 15, "CEDULA");
        da.InsertCommand.Parameters.Add("@Nombres", SqlDbType.NVarChar, 50, "Nombres");
        da.InsertCommand.Parameters.Add("@Parentesco", SqlDbType.NVarChar, 40, "Parentesco");
        da.InsertCommand.Parameters.Add("@FechaNacimiento", SqlDbType.DateTime, 0, "FechaNacimiento");
        da.InsertCommand.Parameters.Add("@Sexo", SqlDbType.NVarChar, 15, "Sexo");
        da.InsertCommand.Parameters.Add("@EstadoCivil", SqlDbType.NVarChar, 20, "EstadoCivil");
        da.InsertCommand.Parameters.Add("@Direccion", SqlDbType.NVarChar, 50, "Direccion");
        da.InsertCommand.Parameters.Add("@Teléfono_1", SqlDbType.NVarChar, 15, "Teléfono_1");
        da.InsertCommand.Parameters.Add("@Teléfono_2", SqlDbType.NVarChar, 15, "Teléfono_2");
        da.InsertCommand.Parameters.Add("@Ocupacion", SqlDbType.NVarChar, 50, "Ocupacion");
        da.InsertCommand.Parameters.Add("@EsDependiente", SqlDbType.NVarChar, 2, "EsDependiente");
        da.InsertCommand.Parameters.Add("@EsMinusvalido", SqlDbType.NVarChar, 2, "EsMinusvalido");
        // TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@IdClave", SqlDbType.Decimal, 0, "IdClave");
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
        nuevoRolFam(dt, this);
        //
        try
        {
            da.Update(dt);
            dt.AcceptChanges();
            return "Se ha creado un nuevo RolFam";
        }
        catch (Exception ex)
        {
            return "ERROR: " + ex.Message;
        }
    }
    //
    public string Borrar()
    {
        string sel = "SELECT * FROM RolFam WHERE IdClave = " + this.IdClave.ToString();
        //
        return Borrar(sel);
    }
    public string Borrar(string sel)
    {
        SqlConnection cnn;
        SqlDataAdapter da;
        DataTable dt = new DataTable("RolFam");
        //
        cnn = new SqlConnection(cadenaConexion);
        da = new SqlDataAdapter(sel, cnn);
        da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
        //
        string sCommand;
        //
        sCommand = "DELETE FROM RolFam WHERE (IdClave = @p1)";
        da.DeleteCommand = new SqlCommand(sCommand, cnn);
        da.DeleteCommand.Parameters.Add("@p1", SqlDbType.Decimal, 0, "IdClave");
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
