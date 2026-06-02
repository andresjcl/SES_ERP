using System;
using System.Data;
using System.Data.SqlClient;
//
public class DaxFormPv
{
    private System.Decimal _IdFormulaPvta;
    private System.String _Descripción;
    private System.Boolean _snConfirma;
    private System.String _PrecioActualiza;
    private System.String _Categoria;
    private System.String _Clase;
    private System.String _Grupo;
    private System.String _Subgrupo;
    private System.String _ArticuloIni;
    private System.String _ArticuloFin;
    private System.String _FormulaValInicial;
    private System.Decimal _FormulaValMultiplica;   // si es valr 999 multiplica por valor de utilidad por atículo
    private System.Decimal _FormulaValSuma;
    private System.Decimal _FormulaValFijo;
    private System.String _consultaSQL;  

    //
    private string ajustarAncho(string cadena, int ancho)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder(new String(' ', ancho));
        return (cadena + sb.ToString()).Substring(0, ancho).Trim();
    }
    public System.Decimal IdFormulaPvta
    {
        get
        {
            return _IdFormulaPvta;
        }
        set
        {
            _IdFormulaPvta = value;
        }
    }
    public System.String Descripción
    {
        get
        {
            return ajustarAncho(_Descripción, 50);
        }
        set
        {
            _Descripción = value;
        }
    }
    public System.Boolean snConfirma
    {
        get
        {
            return _snConfirma;
        }
        set
        {
            _snConfirma = value;
        }
    }
    public System.String PrecioActualiza
    {
        get
        {
            return ajustarAncho(_PrecioActualiza, 50);
        }
        set
        {
            _PrecioActualiza = value;
        }
    }
    public System.String Categoria
    {
        get
        {
            return ajustarAncho(_Categoria, 10);
        }
        set
        {
            _Categoria = value;
        }
    }
    public System.String Clase
    {
        get
        {
            return ajustarAncho(_Clase, 10);
        }
        set
        {
            _Clase = value;
        }
    }
    public System.String Grupo
    {
        get
        {
            return ajustarAncho(_Grupo, 10);
        }
        set
        {
            _Grupo = value;
        }
    }
    public System.String Subgrupo
    {
        get
        {
            return ajustarAncho(_Subgrupo, 10);
        }
        set
        {
            _Subgrupo = value;
        }
    }
    public System.String ArticuloIni
    {
        get
        {
            return ajustarAncho(_ArticuloIni, 50);
        }
        set
        {
            _ArticuloIni = value;
        }
    }
    public System.String ArticuloFin
    {
        get
        {
            return ajustarAncho(_ArticuloFin, 50);
        }
        set
        {
            _ArticuloFin = value;
        }
    }
    public System.String FormulaValInicial
    {
        get
        {
            return ajustarAncho(_FormulaValInicial, 50);
        }
        set
        {
            _FormulaValInicial = value;
        }
    }
    public System.Decimal FormulaValMultiplica
    {
        get
        {
            return _FormulaValMultiplica;
        }
        set
        {
            _FormulaValMultiplica = value;
        }
    }
    public System.Decimal FormulaValSuma
    {
        get
        {
            return _FormulaValSuma;
        }
        set
        {
            _FormulaValSuma = value;
        }
    }
    public System.Decimal FormulaValFijo
    {
        get
        {
            return _FormulaValFijo;
        }
        set
        {
            _FormulaValFijo = value;
        }
    }
    public System.String consultaSQL
    {
        get
        {
            return _consultaSQL;
        }
        set
        {
            _consultaSQL = value;
        }
    }
    //
    //
    // Campos y métodos compartidos (estáticos) para gestionar la base de datos
    //
    // La cadena de conexión a la base de datos
    private static string cadenaConexion = @"";
    // La cadena de selección
    public static string CadenaSelect = "SELECT * FROM DaxFormPv";
    //
    public DaxFormPv()
    {
    }
    public DaxFormPv(string conex)
    {
        cadenaConexion = conex;
    }
    //
    // Métodos compartidos (estáticos) privados
    //
    // asigna una fila de la tabla a un objeto DaxFormPv
    private static DaxFormPv row2DaxFormPv(DataRow r)
    {
        // asigna a un objeto DaxFormPv los datos del dataRow indicado
        DaxFormPv oDaxFormPv = new DaxFormPv();
        //
        oDaxFormPv.IdFormulaPvta = System.Decimal.Parse("0" + r["IdFormulaPvta"].ToString());
        oDaxFormPv.Descripción = r["Descripción"].ToString();
        try
        {
            oDaxFormPv.snConfirma = System.Boolean.Parse(r["snConfirma"].ToString());
        }
        catch
        {
            oDaxFormPv.snConfirma = false;
        }
        oDaxFormPv.PrecioActualiza = r["PrecioActualiza"].ToString();
        oDaxFormPv.snConfirma = Convert.ToBoolean(r["snConfirma"]);
        oDaxFormPv.Categoria = r["Categoria"].ToString();
        oDaxFormPv.Clase = r["Clase"].ToString();
        oDaxFormPv.Grupo = r["Grupo"].ToString();
        oDaxFormPv.Subgrupo = r["Subgrupo"].ToString();
        oDaxFormPv.ArticuloIni = r["ArticuloIni"].ToString();
        oDaxFormPv.ArticuloFin = r["ArticuloFin"].ToString();
        oDaxFormPv.FormulaValInicial = r["FormulaValInicial"].ToString();
        oDaxFormPv.FormulaValMultiplica = System.Decimal.Parse("0" + r["FormulaValMultiplica"].ToString());
        oDaxFormPv.FormulaValSuma = System.Decimal.Parse("0" + r["FormulaValSuma"].ToString());
        oDaxFormPv.FormulaValFijo = System.Decimal.Parse("0" + r["FormulaValFijo"].ToString());
        oDaxFormPv.consultaSQL =  r["consultaSQL"].ToString();
        //
        return oDaxFormPv;
    }
    //
    // asigna un objeto DaxFormPv a la fila indicada
    private static void DaxFormPv2Row(DaxFormPv oDaxFormPv, DataRow r)
    {
        // asigna un objeto DaxFormPv al dataRow indicado
        // TODO: Comprueba si esta asignación debe hacerse
        //       pero mejor lo dejas comentado ya que es un campo autoincremental o único
        //r["IdFormulaPvta"] = oDaxFormPv.IdFormulaPvta;
        r["Descripción"] = oDaxFormPv.Descripción;
        r["snConfirma"] = oDaxFormPv.snConfirma;
        r["PrecioActualiza"] = oDaxFormPv.PrecioActualiza;
        r["Categoria"] = oDaxFormPv.Categoria;
        r["Clase"] = oDaxFormPv.Clase;
        r["Grupo"] = oDaxFormPv.Grupo;
        r["Subgrupo"] = oDaxFormPv.Subgrupo;
        r["ArticuloIni"] = oDaxFormPv.ArticuloIni;
        r["ArticuloFin"] = oDaxFormPv.ArticuloFin;
        r["FormulaValInicial"] = oDaxFormPv.FormulaValInicial;
        r["FormulaValMultiplica"] = oDaxFormPv.FormulaValMultiplica;
        r["FormulaValSuma"] = oDaxFormPv.FormulaValSuma;
        r["FormulaValFijo"] = oDaxFormPv.FormulaValFijo;
        r["consultaSQL"] = oDaxFormPv.consultaSQL;
    }
    //
    // crea una nueva fila y la asigna a un objeto DaxFormPv
    private static void nuevoDaxFormPv(DataTable dt, DaxFormPv oDaxFormPv)
    {
        // Crear un nuevo DaxFormPv
        DataRow dr = dt.NewRow();
        DaxFormPv oD = row2DaxFormPv(dr);
        //
        oD.IdFormulaPvta = oDaxFormPv.IdFormulaPvta;
        oD.snConfirma = oDaxFormPv.snConfirma;
        oD.Descripción = oDaxFormPv.Descripción;
        oD.PrecioActualiza = oDaxFormPv.PrecioActualiza;
        oD.Categoria = oDaxFormPv.Categoria;
        oD.Clase = oDaxFormPv.Clase;
        oD.Grupo = oDaxFormPv.Grupo;
        oD.Subgrupo = oDaxFormPv.Subgrupo;
        oD.ArticuloIni = oDaxFormPv.ArticuloIni;
        oD.ArticuloFin = oDaxFormPv.ArticuloFin;
        oD.FormulaValInicial = oDaxFormPv.FormulaValInicial;
        oD.FormulaValMultiplica = oDaxFormPv.FormulaValMultiplica;
        oD.FormulaValSuma = oDaxFormPv.FormulaValSuma;
        oD.FormulaValFijo = oDaxFormPv.FormulaValFijo;
        oD.consultaSQL = oDaxFormPv.consultaSQL;
        //
        DaxFormPv2Row(oD, dr);
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
        // devuelve una tabla con los datos de la tabla DaxFormPv
        SqlDataAdapter da;
        DataTable dt = new DataTable("DaxFormPv");
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
    public static DaxFormPv Buscar(string sWhere)
    {
        // Busca en la tabla los datos indicados en el parámetro
        // el parámetro contendrá lo que se usará después del WHERE
        DaxFormPv oDaxFormPv = null;
        SqlDataAdapter da;
        DataTable dt = new DataTable("DaxFormPv");
        string sel = "SELECT * FROM DaxFormPv WHERE " + sWhere;
        //
        da = new SqlDataAdapter(sel, cadenaConexion);
        da.Fill(dt);
        //
        if (dt.Rows.Count > 0)
        {
            oDaxFormPv = row2DaxFormPv(dt.Rows[0]);
        }
        return oDaxFormPv;
    }
    //
    public string Actualizar()
    {
        string sel = "SELECT * FROM DaxFormPv WHERE IdFormulaPvta = " + this.IdFormulaPvta.ToString();
        return Actualizar(sel);
    }
    public string Actualizar(string sel)
    {
        // En caso de error, devolverá la cadena empezando por ERROR.
        SqlConnection cnn;
        SqlDataAdapter da;
        DataTable dt = new DataTable("DaxFormPv");
        //
        cnn = new SqlConnection(cadenaConexion);
        //da = new SqlDataAdapter(CadenaSelect, cnn);
        da = new SqlDataAdapter(sel, cnn);
        da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
        SqlCommandBuilder cb = new SqlCommandBuilder(da);
        da.UpdateCommand = cb.GetUpdateCommand();
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
            DaxFormPv2Row(this, dt.Rows[0]);
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
        DataTable dt = new DataTable("DaxFormPv");
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
        nuevoDaxFormPv(dt, this);
        //
        try
        {
            da.Update(dt);
            dt.AcceptChanges();
            IdFormulaPvta = Convert.ToDecimal(dt.Rows[dt.Rows.Count-1]["IdFormulaPvta"]);
            return "Se ha creado un nuevo DaxFormPv";
        }
        catch (Exception ex)
        {
            return "ERROR: " + ex.Message;
        }
    }
    //
    public string Borrar()
    {
        string sel = "SELECT * FROM DaxFormPv WHERE IdFormulaPvta = " + this.IdFormulaPvta.ToString();
        //
        return Borrar(sel);
    }
    public string Borrar(string sel)
    {
        SqlConnection cnn;
        SqlDataAdapter da;
        DataTable dt = new DataTable("DaxFormPv");
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
