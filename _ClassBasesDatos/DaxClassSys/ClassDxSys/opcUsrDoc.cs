using System;
using System.Data;
using System.Data.SqlClient;
namespace ClassDxSys
{
    public class sysdocaccs
    {

    // Las variables privadas
    private System.Int32 _empresa;
    private System.String _idUsuario;
    private System.String _opc_documento;
    private System.String _opcion;
    private System.Boolean _Abierto;
    private System.Int32 _Cantidad;
    private System.Decimal _Minimo;
    private System.Decimal _Maximo;
    private System.String _ValorFijo;
    private System.Decimal _AuxVal1;
    private System.Decimal _AuxVal2;
    private System.String _AuxStr1;
    private System.String _AuxStr2;
    //
    // Este método se usará para ajustar los anchos de las propiedades
    private string ajustarAncho(string cadena, int ancho){
        System.Text.StringBuilder sb = new System.Text.StringBuilder(new String(' ', ancho));
        return (cadena + sb.ToString()).Substring(0, ancho).Trim();
    }
    //
    public System.Int32 empresa{
        get{
            return  _empresa;
        }
        set{
            _empresa = value;
        }
    }
    public System.String idUsuario{
        get{
            return ajustarAncho(_idUsuario,15);
        }
        set{
            _idUsuario = value;
        }
    }
    public System.String opc_documento{
        get{
            return ajustarAncho(_opc_documento,3);
        }
        set{
            _opc_documento = value;
        }
    }
    public System.String opcion{
        get{
            return ajustarAncho(_opcion,50);
        }
        set{
            _opcion = value;
        }
    }
    public System.Boolean Abierto{
        get{
            return  _Abierto;
        }
        set{
            _Abierto = value;
        }
    }
    public System.Int32 Cantidad{
        get{
            return  _Cantidad;
        }
        set{
            _Cantidad = value;
        }
    }
    public System.Decimal Minimo{
        get{
            return  _Minimo;
        }
        set{
            _Minimo = value;
        }
    }
    public System.Decimal Maximo{
        get{
            return  _Maximo;
        }
        set{
            _Maximo = value;
        }
    }
    public System.String ValorFijo{
        get{
            return ajustarAncho(_ValorFijo,50);
        }
        set{
            _ValorFijo = value;
        }
    }
    public System.Decimal AuxVal1{
        get{
            return  _AuxVal1;
        }
        set{
            _AuxVal1 = value;
        }
    }
    public System.Decimal AuxVal2{
        get{
            return  _AuxVal2;
        }
        set{
            _AuxVal2 = value;
        }
    }
    public System.String AuxStr1{
        get{
            return ajustarAncho(_AuxStr1,100);
        }
        set{
            _AuxStr1 = value;
        }
    }
    public System.String AuxStr2{
        get{
            return ajustarAncho(_AuxStr2,100);
        }
        set{
            _AuxStr2 = value;
        }
    }
    // Campos y métodos compartidos (estáticos) para gestionar la base de datos
    //
    // La cadena de conexión a la base de datos
    private static string cadenaConexion = @"";
    // La cadena de selección
    public static string CadenaSelect = "";
    //
    public sysdocaccs(){
    }
    public sysdocaccs(string conex){
        cadenaConexion = conex;
    }
    // asigna una fila de la tabla a un objeto sysdocaccs
    private static sysdocaccs row2sysdocaccs(DataRow r){
        // asigna a un objeto sysdocaccs los datos del dataRow indicado
        sysdocaccs osysdocaccs = new sysdocaccs();
        //
        osysdocaccs.empresa = System.Int32.Parse("0" + r["empresa"].ToString());
        osysdocaccs.idUsuario = r["idUsuario"].ToString();
        osysdocaccs.opc_documento = r["opc_documento"].ToString();
        osysdocaccs.opcion = r["opcion"].ToString();
        try{
            osysdocaccs.Abierto = System.Boolean.Parse(r["Abierto"].ToString());
        }catch{
            osysdocaccs.Abierto = false;
        }
        osysdocaccs.Cantidad = System.Int32.Parse("0" + r["Cantidad"].ToString());
        osysdocaccs.Minimo = System.Decimal.Parse("0" + r["Minimo"].ToString());
        osysdocaccs.Maximo = System.Decimal.Parse("0" + r["Maximo"].ToString());
        osysdocaccs.ValorFijo = r["ValorFijo"].ToString();
        osysdocaccs.AuxVal1 = System.Decimal.Parse("0" + r["AuxVal1"].ToString());
        osysdocaccs.AuxVal2 = System.Decimal.Parse("0" + r["AuxVal2"].ToString());
        osysdocaccs.AuxStr1 = r["AuxStr1"].ToString();
        osysdocaccs.AuxStr2 = r["AuxStr2"].ToString();
        //
        return osysdocaccs;
    }
    //
    // asigna un objeto sysdocaccs a la fila indicada
    private static void sysdocaccs2Row(sysdocaccs osysdocaccs, DataRow r){
        // asigna un objeto sysdocaccs al dataRow indicado
        r["empresa"] = osysdocaccs.empresa;
        r["idUsuario"] = osysdocaccs.idUsuario;
        r["opc_documento"] = osysdocaccs.opc_documento;
        r["opcion"] = osysdocaccs.opcion;
        r["Abierto"] = osysdocaccs.Abierto;
        r["Cantidad"] = osysdocaccs.Cantidad;
        r["Minimo"] = osysdocaccs.Minimo;
        r["Maximo"] = osysdocaccs.Maximo;
        r["ValorFijo"] = osysdocaccs.ValorFijo;
        r["AuxVal1"] = osysdocaccs.AuxVal1;
        r["AuxVal2"] = osysdocaccs.AuxVal2;
        r["AuxStr1"] = osysdocaccs.AuxStr1;
        r["AuxStr2"] = osysdocaccs.AuxStr2;
    }
    //
    // crea una nueva fila y la asigna a un objeto sysdocaccs
    private static void nuevosysdocaccs(DataTable dt, sysdocaccs osysdocaccs){
        // Crear un nuevo sysdocaccs
        DataRow dr = dt.NewRow();
        sysdocaccs os = row2sysdocaccs(dr);
        //
        os.empresa = osysdocaccs.empresa;
        os.idUsuario = osysdocaccs.idUsuario;
        os.opc_documento = osysdocaccs.opc_documento;
        os.opcion = osysdocaccs.opcion;
        os.Abierto = osysdocaccs.Abierto;
        os.Cantidad = osysdocaccs.Cantidad;
        os.Minimo = osysdocaccs.Minimo;
        os.Maximo = osysdocaccs.Maximo;
        os.ValorFijo = osysdocaccs.ValorFijo;
        os.AuxVal1 = osysdocaccs.AuxVal1;
        os.AuxVal2 = osysdocaccs.AuxVal2;
        os.AuxStr1 = osysdocaccs.AuxStr1;
        os.AuxStr2 = osysdocaccs.AuxStr2;
        //
        sysdocaccs2Row(os, dr);
        //
        dt.Rows.Add(dr);
    }
    //
    // Métodos públicos
    //
    // devuelve una tabla con los datos indicados en la cadena de selección
    public static DataTable Tabla(){
        return Tabla(CadenaSelect);
    }
    public static DataTable Tabla(string sel){
        // devuelve una tabla con los datos de la tabla sysdocaccs
        SqlDataAdapter da;
        DataTable dt = new DataTable("sysdocaccs");
        //
        try{
            da = new SqlDataAdapter(sel, cadenaConexion);
            da.Fill(dt);
        }catch{
            return null;
        }
        //
        return dt;
    }
    //
    public static sysdocaccs Buscar(string sWhere){
        // Busca en la tabla los datos indicados en el parámetro
        // el parámetro contendrá lo que se usará después del WHERE
        sysdocaccs osysdocaccs = null;
        try
        {
            SqlDataAdapter da;
            DataTable dt = new DataTable("sysdocaccs");
            string sel = "SELECT * FROM sysdocaccs WHERE " + sWhere;
            //
            da = new SqlDataAdapter(sel, cadenaConexion);
            da.Fill(dt);
            //
            if (dt.Rows.Count > 0)
            {
                osysdocaccs = row2sysdocaccs(dt.Rows[0]);
            }
        }
        catch {}
        return osysdocaccs;
    }
    //

    public string Actualizar(){

        string sel = "SELECT * FROM sysdocaccs WHERE empresa = " +  empresa + " and idusuario = '" + idUsuario + "' and opc_documento = '" + opc_documento + "' and opcion = '" + opcion + "' " ;
        return Actualizar(sel);
    }
    public string Actualizar(string sel){
        SqlConnection cnn;
        SqlDataAdapter da;
        DataTable dt = new DataTable("sysdocaccs");
        //
        cnn = new SqlConnection(cadenaConexion);
        CadenaSelect = sel;
        da = new SqlDataAdapter(sel, cnn);
        da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
        //
        string sCommand;
        //
        sCommand = "UPDATE sysdocaccs SET empresa = @empresa, idUsuario = @idUsuario, opc_documento = @opc_documento, opcion = @opcion, Abierto = @Abierto, Cantidad = @Cantidad, Minimo = @Minimo, Maximo = @Maximo, ValorFijo = @ValorFijo, AuxVal1 = @AuxVal1, AuxVal2 = @AuxVal2, AuxStr1 = @AuxStr1, AuxStr2 = @AuxStr2  ";
        sCommand += " WHERE (empresa = @empresa and idusuario = @idUsuario and opc_documento = @opc_documento and opcion = @opcion )";
        da.UpdateCommand = new SqlCommand(sCommand, cnn);
        da.UpdateCommand.Parameters.Add("@empresa", SqlDbType.Int, 0, "empresa");
        da.UpdateCommand.Parameters.Add("@idUsuario", SqlDbType.NVarChar, 15, "idUsuario");
        da.UpdateCommand.Parameters.Add("@opc_documento", SqlDbType.NVarChar, 3, "opc_documento");
        da.UpdateCommand.Parameters.Add("@opcion", SqlDbType.NVarChar, 50, "opcion");
        da.UpdateCommand.Parameters.Add("@Abierto", SqlDbType.Bit, 0, "Abierto");
        da.UpdateCommand.Parameters.Add("@Cantidad", SqlDbType.Int, 0, "Cantidad");
        da.UpdateCommand.Parameters.Add("@Minimo", SqlDbType.Decimal, 0, "Minimo");
        da.UpdateCommand.Parameters.Add("@Maximo", SqlDbType.Decimal, 0, "Maximo");
        da.UpdateCommand.Parameters.Add("@ValorFijo", SqlDbType.NVarChar, 50, "ValorFijo");
        da.UpdateCommand.Parameters.Add("@AuxVal1", SqlDbType.Decimal, 0, "AuxVal1");
        da.UpdateCommand.Parameters.Add("@AuxVal2", SqlDbType.Decimal, 0, "AuxVal2");
        da.UpdateCommand.Parameters.Add("@AuxStr1", SqlDbType.NVarChar, 100, "AuxStr1");
        da.UpdateCommand.Parameters.Add("@AuxStr2", SqlDbType.NVarChar, 100, "AuxStr2");
        //
        try{
            da.Fill(dt);
        }catch(Exception ex){
            return "ERROR: " + ex.Message;
        }
        //
        if(dt.Rows.Count == 0){
            // crear uno nuevo
            return Crear();
        }else{
            sysdocaccs2Row(this, dt.Rows[0]);
        }
        //
        try{
            da.Update(dt);
            dt.AcceptChanges();
            return "Actualizado correctamente";
        }catch(Exception ex){
            return "ERROR: " + ex.Message;
        }
    }
    //
    public string Crear(){
        // En caso de error, devolverá la cadena de error empezando por ERROR:.
        SqlConnection cnn;
        SqlDataAdapter da;
        DataTable dt = new DataTable("sysdocaccs");
        //
        cnn = new SqlConnection(cadenaConexion);
        da = new SqlDataAdapter(CadenaSelect, cnn);
        da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
        string sCommand;
        //
        sCommand = "INSERT INTO sysdocaccs (empresa, idUsuario, opc_documento, opcion, Abierto, Cantidad, Minimo, Maximo, ValorFijo, AuxVal1, AuxVal2, AuxStr1, AuxStr2)  VALUES(@empresa, @idUsuario, @opc_documento, @opcion, @Abierto, @Cantidad, @Minimo, @Maximo, @ValorFijo, @AuxVal1, @AuxVal2, @AuxStr1, @AuxStr2)";
        da.InsertCommand = new SqlCommand(sCommand, cnn);
        da.InsertCommand.Parameters.Add("@empresa", SqlDbType.Int, 0, "empresa");
        da.InsertCommand.Parameters.Add("@idUsuario", SqlDbType.NVarChar, 15, "idUsuario");
        da.InsertCommand.Parameters.Add("@opc_documento", SqlDbType.NVarChar, 3, "opc_documento");
        da.InsertCommand.Parameters.Add("@opcion", SqlDbType.NVarChar, 50, "opcion");
        da.InsertCommand.Parameters.Add("@Abierto", SqlDbType.Bit, 0, "Abierto");
        da.InsertCommand.Parameters.Add("@Cantidad", SqlDbType.Int, 0, "Cantidad");
        da.InsertCommand.Parameters.Add("@Minimo", SqlDbType.Decimal, 0, "Minimo");
        da.InsertCommand.Parameters.Add("@Maximo", SqlDbType.Decimal, 0, "Maximo");
        da.InsertCommand.Parameters.Add("@ValorFijo", SqlDbType.NVarChar, 50, "ValorFijo");
        da.InsertCommand.Parameters.Add("@AuxVal1", SqlDbType.Decimal, 0, "AuxVal1");
        da.InsertCommand.Parameters.Add("@AuxVal2", SqlDbType.Decimal, 0, "AuxVal2");
        da.InsertCommand.Parameters.Add("@AuxStr1", SqlDbType.NVarChar, 100, "AuxStr1");
        da.InsertCommand.Parameters.Add("@AuxStr2", SqlDbType.NVarChar, 100, "AuxStr2");
        try{
            da.Fill(dt);
        }catch(Exception ex){
            return "ERROR: " + ex.Message;
        }
        //
        nuevosysdocaccs(dt, this);
        //
        try{
            da.Update(dt);
            dt.AcceptChanges();
            return "Se ha creado un nuevo sysdocaccs";
        }catch(Exception ex){
            return "ERROR: " + ex.Message;
        }
    }
    //
    public string Borrar(){
        string sel = "SELECT * FROM sysdocaccs WHERE empresa = " + empresa + " and idusuario = '" + idUsuario + "' and opc_documento = '" + opc_documento + "' and opcion = '" + opcion + "' ";
        //
        return Borrar(sel);
    }
    public string Borrar(string sel){
        // Borrar el registro al que apunta esta clase
        // En caso de error, devolverá la cadena de error empezando por ERROR:.
        SqlConnection cnn;
        SqlDataAdapter da;
        DataTable dt = new DataTable("sysdocaccs");
        //
        cnn = new SqlConnection(cadenaConexion);
        da = new SqlDataAdapter(sel, cnn);
        da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
        string sCommand;
        //
        sCommand = "DELETE FROM sysdocaccs WHERE (empresa = @empresa and idusuario = @idUsuario and opc_documento = @opc_documento and opcion = @opcion )";
        da.DeleteCommand = new SqlCommand(sCommand, cnn);
        da.DeleteCommand.Parameters.Add("@empresa", SqlDbType.Int, 0, "empresa");
        da.DeleteCommand.Parameters.Add("@idUsuario", SqlDbType.NVarChar, 15, "idUsuario");
        da.DeleteCommand.Parameters.Add("@opc_documento", SqlDbType.NVarChar, 3, "opc_documento");
        da.DeleteCommand.Parameters.Add("@opcion", SqlDbType.NVarChar, 50, "opcion");
        //
        //
        da.Fill(dt);
        //
        if(dt.Rows.Count == 0){
            return "ERROR: No hay datos";
        }else{
            dt.Rows[0].Delete();
        }
        //
        try{
            da.Update(dt);
            dt.AcceptChanges();
            return "Borrado satisfactoriamente";
        }catch(Exception ex){
            return "ERROR: " + ex.Message;
        }
    }
    }
}
