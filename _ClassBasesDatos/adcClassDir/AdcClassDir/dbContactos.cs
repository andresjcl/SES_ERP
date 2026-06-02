using System;
using System.Data;
using System.Data.SqlClient;
//
public class dbContactos
{
    // Las variables privadas
    // TODO: Revisar los tipos de los campos
    private System.String _CodContacto;
    private System.String _Nombre;
    private System.String _Principal;
    private System.String _Cargo;
    private System.String _Extensión;
    private System.String _TelfCelular;
    private System.String _TeléfonoDirecto;
    private System.DateTime _FechaNacimiento;
    private System.String _Actividades;
    private System.String _Preferencias;
    private System.String _Observaciones;
    //
    // Este método se usará para ajustar los anchos de las propiedades
    private string ajustarAncho(string cadena, int ancho)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder(new String(' ', ancho));
        return (cadena + sb.ToString()).Substring(0, ancho).Trim();
    }
    //
    public System.String CodContacto
    {
        get
        {
            return ajustarAncho(_CodContacto, 15);
        }
        set
        {
            _CodContacto = value;
        }
    }
    public System.String Nombre
    {
        get
        {
            return ajustarAncho(_Nombre, 80);
        }
        set
        {
            _Nombre = value;
        }
    }
    public System.String Principal
    {
        get
        {
            return ajustarAncho(_Principal, 1);
        }
        set
        {
            _Principal = value;
        }
    }
    public System.String Cargo
    {
        get
        {
            return ajustarAncho(_Cargo, 50);
        }
        set
        {
            _Cargo = value;
        }
    }
    public System.String Extensión
    {
        get
        {
            return ajustarAncho(_Extensión, 10);
        }
        set
        {
            _Extensión = value;
        }
    }
    public System.String TelfCelular
    {
        get
        {
            return ajustarAncho(_TelfCelular, 15);
        }
        set
        {
            _TelfCelular = value;
        }
    }
    public System.String TeléfonoDirecto
    {
        get
        {
            return ajustarAncho(_TeléfonoDirecto, 12);
        }
        set
        {
            _TeléfonoDirecto = value;
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
    public System.String Actividades
    {
        get
        {
            return ajustarAncho(_Actividades, 128);
        }
        set
        {
            _Actividades = value;
        }
    }
    public System.String Preferencias
    {
        get
        {
            return ajustarAncho(_Preferencias, 128);
        }
        set
        {
            _Preferencias = value;
        }
    }
    public System.String Observaciones
    {
        get
        {
            return ajustarAncho(_Observaciones, 128);
        }
        set
        {
            _Observaciones = value;
        }
    }
    //
    // La cadena de conexión a la base de datos
    private static string cadenaConexion = @"";
    // La cadena de selección
    public static string CadenaSelect = "";
    //
    public dbContactos()
    {
    }
    public dbContactos(string conex)
    {
        cadenaConexion = conex;
    }
    //
    private static dbContactos row2Contactos(DataRow r)
    {
        // asigna a un objeto Contactos los datos del dataRow indicado
        dbContactos oContactos = new dbContactos();
        //
        oContactos.CodContacto = r["CodContacto"].ToString();
        oContactos.Nombre = r["Nombre"].ToString();
        oContactos.Principal = r["Principal"].ToString();
        oContactos.Cargo = r["Cargo"].ToString();
        oContactos.Extensión = r["Extensión"].ToString();
        oContactos.TelfCelular = r["TelfCelular"].ToString();
        oContactos.TeléfonoDirecto = r["TeléfonoDirecto"].ToString();
        try
        {
            oContactos.FechaNacimiento = DateTime.Parse(r["FechaNacimiento"].ToString());
        }
        catch
        {
            oContactos.FechaNacimiento = new DateTime(1900, 1, 1);
        }
        oContactos.Actividades = r["Actividades"].ToString();
        oContactos.Preferencias = r["Preferencias"].ToString();
        oContactos.Observaciones = r["Observaciones"].ToString();
        //
        return oContactos;
    }
    //
    // asigna un objeto Contactos a la fila indicada
    private static void Contactos2Row(dbContactos oContactos, DataRow r)
    {
        // asigna un objeto Contactos al dataRow indicado
        r["CodContacto"] = oContactos.CodContacto;
        r["Nombre"] = oContactos.Nombre;
        r["Principal"] = oContactos.Principal;
        r["Cargo"] = oContactos.Cargo;
        r["Extensión"] = oContactos.Extensión;
        r["TelfCelular"] = oContactos.TelfCelular;
        r["TeléfonoDirecto"] = oContactos.TeléfonoDirecto;
        r["FechaNacimiento"] = oContactos.FechaNacimiento;
        r["Actividades"] = oContactos.Actividades;
        r["Preferencias"] = oContactos.Preferencias;
        r["Observaciones"] = oContactos.Observaciones;
    }
    //
    // crea una nueva fila y la asigna a un objeto Contactos
    private static void nuevoContactos(DataTable dt, dbContactos oContactos)
    {
        // Crear un nuevo Contactos
        DataRow dr = dt.NewRow();
        dbContactos oC = row2Contactos(dr);
        //
        oC.CodContacto = oContactos.CodContacto;
        oC.Nombre = oContactos.Nombre;
        oC.Principal = oContactos.Principal;
        oC.Cargo = oContactos.Cargo;
        oC.Extensión = oContactos.Extensión;
        oC.TelfCelular = oContactos.TelfCelular;
        oC.TeléfonoDirecto = oContactos.TeléfonoDirecto;
        oC.FechaNacimiento = oContactos.FechaNacimiento;
        oC.Actividades = oContactos.Actividades;
        oC.Preferencias = oContactos.Preferencias;
        oC.Observaciones = oContactos.Observaciones;
        //
        Contactos2Row(oC, dr);
        //
        dt.Rows.Add(dr);
    }
    //
    public static DataTable Tabla()
    {
        return Tabla(CadenaSelect);
    }
    public static DataTable Tabla(string sel)
    {
        // devuelve una tabla con los datos de la tabla Contactos
        SqlDataAdapter da;
        DataTable dt = new DataTable("Contactos");
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
    public static dbContactos Buscar(string sWhere)
    {
        dbContactos oContactos = null;
        SqlDataAdapter da;
        DataTable dt = new DataTable("Contactos");
        string sel = "SELECT * FROM Contactos WHERE " + sWhere;
        //
        da = new SqlDataAdapter(sel, cadenaConexion);
        da.Fill(dt);
        //
        if (dt.Rows.Count > 0)
        {
            oContactos = row2Contactos(dt.Rows[0]);
        }
        return oContactos;
    }
    //
    public string Actualizar()
    {
        string sel = "SELECT * FROM Contactos WHERE codContacto = '" + this.CodContacto + "' and nombre='" + this.Nombre + "' " ;
        return Actualizar(sel);
    }
    public string Actualizar(string sel)
    {
        SqlConnection cnn;
        SqlDataAdapter da;
        DataTable dt = new DataTable("Contactos");
        CadenaSelect = sel;
        //
        cnn = new SqlConnection(cadenaConexion);
        da = new SqlDataAdapter(sel, cnn);
        da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
        //
        string sCommand;
        //
        // El comando UPDATE
        sCommand = "UPDATE Contactos SET CodContacto = @CodContacto, Nombre = @Nombre, Principal = @Principal, Cargo = @Cargo, Extensión = @Extensión, TelfCelular = @TelfCelular, TeléfonoDirecto = @TeléfonoDirecto, FechaNacimiento = @FechaNacimiento, Actividades = @Actividades, Preferencias = @Preferencias, Observaciones = @Observaciones  WHERE (codContacto = @codContacto and nombre = @nombre)";
        da.UpdateCommand = new SqlCommand(sCommand, cnn);
        da.UpdateCommand.Parameters.Add("@CodContacto", SqlDbType.VarChar, 15, "CodContacto");
        da.UpdateCommand.Parameters.Add("@Nombre", SqlDbType.VarChar, 80, "Nombre");
        da.UpdateCommand.Parameters.Add("@Principal", SqlDbType.VarChar, 1, "Principal");
        da.UpdateCommand.Parameters.Add("@Cargo", SqlDbType.VarChar, 50, "Cargo");
        da.UpdateCommand.Parameters.Add("@Extensión", SqlDbType.VarChar, 10, "Extensión");
        da.UpdateCommand.Parameters.Add("@TelfCelular", SqlDbType.VarChar, 15, "TelfCelular");
        da.UpdateCommand.Parameters.Add("@TeléfonoDirecto", SqlDbType.VarChar, 12, "TeléfonoDirecto");
        da.UpdateCommand.Parameters.Add("@FechaNacimiento", SqlDbType.DateTime, 0, "FechaNacimiento");
        da.UpdateCommand.Parameters.Add("@Actividades", SqlDbType.VarChar, 128, "Actividades");
        da.UpdateCommand.Parameters.Add("@Preferencias", SqlDbType.VarChar, 128, "Preferencias");
        da.UpdateCommand.Parameters.Add("@Observaciones", SqlDbType.VarChar, 128, "Observaciones");
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
            Contactos2Row(this, dt.Rows[0]);
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
        DataTable dt = new DataTable("Contactos");
        //
        cnn = new SqlConnection(cadenaConexion);
        da = new SqlDataAdapter(CadenaSelect, cnn);
        da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
        string sCommand;
        sCommand = "INSERT INTO Contactos (CodContacto, Nombre, Principal, Cargo, Extensión, TelfCelular, TeléfonoDirecto, FechaNacimiento, Actividades, Preferencias, Observaciones)  VALUES(@CodContacto, @Nombre, @Principal, @Cargo, @Extensión, @TelfCelular, @TeléfonoDirecto, @FechaNacimiento, @Actividades, @Preferencias, @Observaciones)";
        da.InsertCommand = new SqlCommand(sCommand, cnn);
        da.InsertCommand.Parameters.Add("@CodContacto", SqlDbType.VarChar, 15, "CodContacto");
        da.InsertCommand.Parameters.Add("@Nombre", SqlDbType.VarChar, 80, "Nombre");
        da.InsertCommand.Parameters.Add("@Principal", SqlDbType.VarChar, 1, "Principal");
        da.InsertCommand.Parameters.Add("@Cargo", SqlDbType.VarChar, 50, "Cargo");
        da.InsertCommand.Parameters.Add("@Extensión", SqlDbType.VarChar, 10, "Extensión");
        da.InsertCommand.Parameters.Add("@TelfCelular", SqlDbType.VarChar, 15, "TelfCelular");
        da.InsertCommand.Parameters.Add("@TeléfonoDirecto", SqlDbType.VarChar, 12, "TeléfonoDirecto");
        da.InsertCommand.Parameters.Add("@FechaNacimiento", SqlDbType.DateTime, 0, "FechaNacimiento");
        da.InsertCommand.Parameters.Add("@Actividades", SqlDbType.VarChar, 128, "Actividades");
        da.InsertCommand.Parameters.Add("@Preferencias", SqlDbType.VarChar, 128, "Preferencias");
        da.InsertCommand.Parameters.Add("@Observaciones", SqlDbType.VarChar, 128, "Observaciones");
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
        nuevoContactos(dt, this);
        //
        try
        {
            da.Update(dt);
            dt.AcceptChanges();
            return "Se ha creado un nuevo Contactos";
        }
        catch (Exception ex)
        {
            return "ERROR: " + ex.Message;
        }
    }
    //
    public string Borrar()
    {
        string sel = "SELECT * FROM Contactos WHERE codContacto = '" + this.CodContacto + "' and nombre = '" + this.Nombre + "' ";
        //
        return Borrar(sel);
    }
    public string Borrar(string sel)
    {
        SqlConnection cnn;
        SqlDataAdapter da;
        DataTable dt = new DataTable("Contactos");
        //
        cnn = new SqlConnection(cadenaConexion);
        da = new SqlDataAdapter(sel, cnn);
        da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
        //
        //--------------------------------------------------------------------
        string sCommand;
        //
        sCommand = "DELETE FROM Contactos WHERE (ID = @p1)";
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
