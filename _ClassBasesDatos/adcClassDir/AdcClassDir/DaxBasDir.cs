//------------------------------------------------------------------------------
// Clase AdcAdicEmp generada automáticamente con CrearClaseSQL
// de la tabla 'AdcAdicEmp' de la base 'bdadcomdxmanamer'
// Fecha: 27/ago/2013 15:40:51
//------------------------------------------------------------------------------
using System;
using System.Data;
using System.Data.SqlClient;
//
public class AdcAdicEmp
{
    private System.String _CodEmpleado;
    private System.String _CodAdicional;
    private System.String _NomAdicional;
    private System.String _ValorAdicional;
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

    public System.String CodEmpleado
    {
        get
        {
            return ajustarAncho(_CodEmpleado, 20);
        }
        set
        {
            _CodEmpleado = value;
        }
    }
    public System.String CodAdicional
    {
        get
        {
            return ajustarAncho(_CodAdicional, 50);
        }
        set
        {
            _CodAdicional = value;
        }
    }
    public System.String NomAdicional
    {
        get
        {
            return ajustarAncho(_NomAdicional, 50);
        }
        set
        {
            _NomAdicional = value;
        }
    }
    public System.String ValorAdicional
    {
        get
        {
            return ajustarAncho(_ValorAdicional, 50);
        }
        set
        {
            _ValorAdicional = value;
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
                return this.CodEmpleado.ToString();
            }
            else if (index == 1)
            {
                return this.CodAdicional.ToString();
            }
            else if (index == 2)
            {
                return this.NomAdicional.ToString();
            }
            else if (index == 3)
            {
                return this.ValorAdicional.ToString();
            }
            // Para que no de error el compilador de C#
            return "";
        }
        set
        {
            if (index == 0)
            {
                this.CodEmpleado = value;
            }
            else if (index == 1)
            {
                this.CodAdicional = value;
            }
            else if (index == 2)
            {
                this.NomAdicional = value;
            }
            else if (index == 3)
            {
                this.ValorAdicional = value;
            }
        }
    }
    public string this[string index]
    {
        // Devuelve el contenido del campo indicado en index
        // (el índice corresponde al nombre de la columna)
        get
        {
            if (index == "CodEmpleado")
            {
                return this.CodEmpleado.ToString();
            }
            else if (index == "CodAdicional")
            {
                return this.CodAdicional.ToString();
            }
            else if (index == "NomAdicional")
            {
                return this.NomAdicional.ToString();
            }
            else if (index == "ValorAdicional")
            {
                return this.ValorAdicional.ToString();
            }
            // Para que no de error el compilador de C#
            return "";
        }
        set
        {
            if (index == "CodEmpleado")
            {
                this.CodEmpleado = value;
            }
            else if (index == "CodAdicional")
            {
                this.CodAdicional = value;
            }
            else if (index == "NomAdicional")
            {
                this.NomAdicional = value;
            }
            else if (index == "ValorAdicional")
            {
                this.ValorAdicional = value;
            }
        }
    }
    //
    // Campos y métodos compartidos (estáticos) para gestionar la base de datos
    //
    // La cadena de conexión a la base de datos
    private static string cadenaConexion = @";";
    // La cadena de selección
    public static string CadenaSelect = "SELECT * FROM AdcAdicEmp";
    //
    public AdcAdicEmp()
    {
    }
    public AdcAdicEmp(string conex)
    {
        cadenaConexion = conex;
    }
    //
    // Métodos compartidos (estáticos) privados
    //
    // asigna una fila de la tabla a un objeto AdcAdicEmp
    private static AdcAdicEmp row2AdcAdicEmp(DataRow r)
    {
        // asigna a un objeto AdcAdicEmp los datos del dataRow indicado
        AdcAdicEmp oAdcAdicEmp = new AdcAdicEmp();
        //
        oAdcAdicEmp.CodEmpleado = r["CodEmpleado"].ToString();
        oAdcAdicEmp.CodAdicional = r["CodAdicional"].ToString();
        oAdcAdicEmp.NomAdicional = r["NomAdicional"].ToString();
        oAdcAdicEmp.ValorAdicional = r["ValorAdicional"].ToString();
        //
        return oAdcAdicEmp;
    }
    //
    // asigna un objeto AdcAdicEmp a la fila indicada
    private static void AdcAdicEmp2Row(AdcAdicEmp oAdcAdicEmp, DataRow r)
    {
        // asigna un objeto AdcAdicEmp al dataRow indicado
        r["CodEmpleado"] = oAdcAdicEmp.CodEmpleado;
        r["CodAdicional"] = oAdcAdicEmp.CodAdicional;
        r["NomAdicional"] = oAdcAdicEmp.NomAdicional;
        r["ValorAdicional"] = oAdcAdicEmp.ValorAdicional;
    }
    //
    // crea una nueva fila y la asigna a un objeto AdcAdicEmp
    private static void nuevoAdcAdicEmp(DataTable dt, AdcAdicEmp oAdcAdicEmp)
    {
        // Crear un nuevo AdcAdicEmp
        DataRow dr = dt.NewRow();
        AdcAdicEmp oA = row2AdcAdicEmp(dr);
        //
        oA.CodEmpleado = oAdcAdicEmp.CodEmpleado;
        oA.CodAdicional = oAdcAdicEmp.CodAdicional;
        oA.NomAdicional = oAdcAdicEmp.NomAdicional;
        oA.ValorAdicional = oAdcAdicEmp.ValorAdicional;
        //
        AdcAdicEmp2Row(oA, dr);
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
        // devuelve una tabla con los datos de la tabla AdcAdicEmp
        SqlDataAdapter da;
        DataTable dt = new DataTable("AdcAdicEmp");
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
    public static AdcAdicEmp Buscar(string sWhere)
    {
        // Busca en la tabla los datos indicados en el parámetro
        // el parámetro contendrá lo que se usará después del WHERE
        AdcAdicEmp oAdcAdicEmp = null;
        SqlDataAdapter da;
        DataTable dt = new DataTable("AdcAdicEmp");
        string sel = "SELECT * FROM AdcAdicEmp WHERE " + sWhere;
        //
        da = new SqlDataAdapter(sel, cadenaConexion);
        da.Fill(dt);
        //
        if (dt.Rows.Count > 0)
        {
            oAdcAdicEmp = row2AdcAdicEmp(dt.Rows[0]);
        }
        return oAdcAdicEmp;
    }

    public string Actualizar()
    {
        // TODO: Poner aquí la selección a realizar para acceder a este registro
        //       yo uso el ID que es el identificador único de cada registro
        string sel = "SELECT * FROM AdcAdicEmp WHERE CodEmpleado = '" + CodEmpleado + "' and CodAdicional = '" + CodAdicional + "' ";
        return Actualizar(sel);
    }
    public string Actualizar(string sel)
    {
        // Actualiza los datos indicados
        // El parámetro, que es una cadena de selección, indicará el criterio de actualización
        //
        // En caso de error, devolverá la cadena empezando por ERROR.
        CadenaSelect = sel;
        SqlConnection cnn;
        SqlDataAdapter da;
        DataTable dt = new DataTable("AdcAdicEmp");
        //
        cnn = new SqlConnection(cadenaConexion);
        //da = new SqlDataAdapter(CadenaSelect, cnn);
        da = new SqlDataAdapter(sel, cnn);
        da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
        //
        string sCommand;
        //
        // El comando UPDATE
        sCommand = "UPDATE AdcAdicEmp SET CodEmpleado = @CodEmpleado, CodAdicional = @CodAdicional, NomAdicional = @NomAdicional, ValorAdicional = @ValorAdicional  WHERE (CodEmpleado = @CodEmpleado and CodAdicional = @CodAdicional)";
        da.UpdateCommand = new SqlCommand(sCommand, cnn);
        da.UpdateCommand.Parameters.Add("@CodEmpleado", SqlDbType.VarChar, 20, "CodEmpleado");
        da.UpdateCommand.Parameters.Add("@CodAdicional", SqlDbType.VarChar, 50, "CodAdicional");
        da.UpdateCommand.Parameters.Add("@NomAdicional", SqlDbType.VarChar, 50, "NomAdicional");
        da.UpdateCommand.Parameters.Add("@ValorAdicional", SqlDbType.VarChar, 50, "ValorAdicional");
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
            AdcAdicEmp2Row(this, dt.Rows[0]);
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
        DataTable dt = new DataTable("AdcAdicEmp");
        //
        cnn = new SqlConnection(cadenaConexion);
        da = new SqlDataAdapter(CadenaSelect, cnn);
        //da = new SqlDataAdapter(CadenaSelect, cadenaConexion);
        da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
        //--------------------------------------------------------------------
        string sCommand;
        //
        // El comando INSERT
        sCommand = "INSERT INTO AdcAdicEmp (CodEmpleado, CodAdicional, NomAdicional, ValorAdicional)  VALUES(@CodEmpleado, @CodAdicional, @NomAdicional, @ValorAdicional)";
        da.InsertCommand = new SqlCommand(sCommand, cnn);
        da.InsertCommand.Parameters.Add("@CodEmpleado", SqlDbType.VarChar, 20, "CodEmpleado");
        da.InsertCommand.Parameters.Add("@CodAdicional", SqlDbType.VarChar, 50, "CodAdicional");
        da.InsertCommand.Parameters.Add("@NomAdicional", SqlDbType.VarChar, 50, "NomAdicional");
        da.InsertCommand.Parameters.Add("@ValorAdicional", SqlDbType.VarChar, 50, "ValorAdicional");
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
        nuevoAdcAdicEmp(dt, this);
        //
        try
        {
            da.Update(dt);
            dt.AcceptChanges();
            return "Se ha creado un nuevo AdcAdicEmp";
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
        string sel = "SELECT * FROM AdcAdicEmp WHERE CodEmpleado ='" + CodEmpleado + "' and CodAdicional = '" + CodAdicional + "' ";
        //
        return Borrar(sel);
    }
    public string Borrar(string sel)
    {
        // Borrar el registro al que apunta esta clase
        // En caso de error, devolverá la cadena de error empezando por ERROR:.
        SqlConnection cnn;
        SqlDataAdapter da;
        DataTable dt = new DataTable("AdcAdicEmp");
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
        //       Yo compruebo que sea un campo llamado ID, pero en tu caso puede ser otro
        sCommand = "DELETE FROM AdcAdicEmp WHERE (CodEmpleado = @CodEmpleado and CodAdicional = @CodAdicional)";
        da.DeleteCommand = new SqlCommand(sCommand, cnn);
        da.DeleteCommand.Parameters.Add("@CodEmpleado", SqlDbType.VarChar, 20, "CodEmpleado");
        da.DeleteCommand.Parameters.Add("@CodAdicional", SqlDbType.VarChar, 50, "CodAdicional");
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
