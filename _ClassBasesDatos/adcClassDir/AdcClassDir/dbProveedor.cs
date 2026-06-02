using System;
using System.Data;
using System.Data.SqlClient;
//
public class dbProveedor{
    // Las variables privadas
    // TODO: Revisar los tipos de los campos
    private System.String _CodigoProveedor;
    private System.String _FormaPago;
    private System.Decimal _PorceDescuent;
    private System.Boolean _IncluyeTranspo;
    private System.Decimal _LimCreditoPrv;
    private System.String _Producto1;
    private System.String _Servicios1;
    private System.Boolean _EntregaNuestraOficina;
    private System.Boolean _RetirarMercaderia;
    private System.Boolean _EnvioATransporte;
    private System.String _Observaciones;
    private System.String _CtbProveedor;
    private System.String _CtbProveedor2;
    private System.Decimal _limitecreditoprv;
    private System.Boolean _placa;
    private System.Boolean _transMaritimo;
    private System.Boolean _transTerrestre;
    private System.Boolean _transAereo;
    //
    // Este método se usará para ajustar los anchos de las propiedades
    private string ajustarAncho(string cadena, int ancho){
        System.Text.StringBuilder sb = new System.Text.StringBuilder(new String(' ', ancho));
        // devolver la cadena quitando los espacios en blanco
        // esto asegura que no se devolverá un tamaño mayor ni espacios "extras"
        return (cadena + sb.ToString()).Substring(0, ancho).Trim();
    }
    //
    public System.String CodigoProveedor{
        get{
            return ajustarAncho(_CodigoProveedor,15);
        }
        set{
            _CodigoProveedor = value;
        }
    }
    public System.String FormaPago{
        get{
            return ajustarAncho(_FormaPago,5);
        }
        set{
            _FormaPago = value;
        }
    }
    public System.Decimal PorceDescuent{
        get{
            return  _PorceDescuent;
        }
        set{
            _PorceDescuent = value;
        }
    }
    public System.Boolean IncluyeTranspo{
        get{
            return  _IncluyeTranspo;
        }
        set{
            _IncluyeTranspo = value;
        }
    }
    public System.Decimal LimCreditoPrv{
        get{
            return  _LimCreditoPrv;
        }
        set{
            _LimCreditoPrv = value;
        }
    }
    public System.String Producto1{
        get{
            return ajustarAncho(_Producto1,128);
        }
        set{
            _Producto1 = value;
        }
    }
    public System.String Servicios1{
        get{
            return ajustarAncho(_Servicios1,128);
        }
        set{
            _Servicios1 = value;
        }
    }
    public System.Boolean EntregaNuestraOficina{
        get{
            return  _EntregaNuestraOficina;
        }
        set{
            _EntregaNuestraOficina = value;
        }
    }
    public System.Boolean RetirarMercaderia{
        get{
            return  _RetirarMercaderia;
        }
        set{
            _RetirarMercaderia = value;
        }
    }
    public System.Boolean EnvioATransporte{
        get{
            return  _EnvioATransporte;
        }
        set{
            _EnvioATransporte = value;
        }
    }
    public System.String Observaciones{
        get{
            return ajustarAncho(_Observaciones,50);
        }
        set{
            _Observaciones = value;
        }
    }
    public System.String CtbProveedor{
        get{
            return ajustarAncho(_CtbProveedor,15);
        }
        set{
            _CtbProveedor = value;
        }
    }
    public System.String CtbProveedor2{
        get{
            return ajustarAncho(_CtbProveedor2,15);
        }
        set{
            _CtbProveedor2 = value;
        }
    }
    public System.Decimal limitecreditoprv{
        get{
            return  _limitecreditoprv;
        }
        set{
            _limitecreditoprv = value;
        }
    }
    public System.Boolean placa{
        get{
            return  _placa;
        }
        set{
            _placa = value;
        }
    }
    public System.Boolean transMaritimo{
        get{
            return  _transMaritimo;
        }
        set{
            _transMaritimo = value;
        }
    }
    public System.Boolean transTerrestre{
        get{
            return  _transTerrestre;
        }
        set{
            _transTerrestre = value;
        }
    }
    public System.Boolean transAereo{
        get{
            return  _transAereo;
        }
        set{
            _transAereo = value;
        }
    }
    //
    // La cadena de conexión a la base de datos
    private static string cadenaConexion = @"";
    // La cadena de selección
    public static string CadenaSelect = "";
    //
    public dbProveedor(){
    }
    public dbProveedor(string conex){
        cadenaConexion = conex;
    }
    //
    // Métodos compartidos (estáticos) privados
    //
    // asigna una fila de la tabla a un objeto PROVEEDOR
    private static dbProveedor row2PROVEEDOR(DataRow r){
        // asigna a un objeto PROVEEDOR los datos del dataRow indicado
        dbProveedor oPROVEEDOR = new dbProveedor();
        //
        oPROVEEDOR.CodigoProveedor = r["CodigoProveedor"].ToString();
        oPROVEEDOR.FormaPago = r["FormaPago"].ToString();
        oPROVEEDOR.PorceDescuent = System.Decimal.Parse("0" + r["PorceDescuent"].ToString());
        try{
            oPROVEEDOR.IncluyeTranspo = System.Boolean.Parse(r["IncluyeTranspo"].ToString());
        }catch{
            oPROVEEDOR.IncluyeTranspo = false;
        }
        oPROVEEDOR.LimCreditoPrv = System.Decimal.Parse("0" + r["LimCreditoPrv"].ToString());
        oPROVEEDOR.Producto1 = r["Producto1"].ToString();
        oPROVEEDOR.Servicios1 = r["Servicios1"].ToString();
        try{
            oPROVEEDOR.EntregaNuestraOficina = System.Boolean.Parse(r["EntregaNuestraOficina"].ToString());
        }catch{
            oPROVEEDOR.EntregaNuestraOficina = false;
        }
        try{
            oPROVEEDOR.RetirarMercaderia = System.Boolean.Parse(r["RetirarMercaderia"].ToString());
        }catch{
            oPROVEEDOR.RetirarMercaderia = false;
        }
        try{
            oPROVEEDOR.EnvioATransporte = System.Boolean.Parse(r["EnvioATransporte"].ToString());
        }catch{
            oPROVEEDOR.EnvioATransporte = false;
        }
        oPROVEEDOR.Observaciones = r["Observaciones"].ToString();
        oPROVEEDOR.CtbProveedor = r["CtbProveedor"].ToString();
        oPROVEEDOR.CtbProveedor2 = r["CtbProveedor2"].ToString();
        oPROVEEDOR.limitecreditoprv = System.Decimal.Parse("0" + r["limitecreditoprv"].ToString());
        try{
            oPROVEEDOR.placa = System.Boolean.Parse(r["placa"].ToString());
        }catch{
            oPROVEEDOR.placa = false;
        }
        try{
            oPROVEEDOR.transMaritimo = System.Boolean.Parse(r["transMaritimo"].ToString());
        }catch{
            oPROVEEDOR.transMaritimo = false;
        }
        try{
            oPROVEEDOR.transTerrestre = System.Boolean.Parse(r["transTerrestre"].ToString());
        }catch{
            oPROVEEDOR.transTerrestre = false;
        }
        try{
            oPROVEEDOR.transAereo = System.Boolean.Parse(r["transAereo"].ToString());
        }catch{
            oPROVEEDOR.transAereo = false;
        }
        //
        return oPROVEEDOR;
    }
    //
    // asigna un objeto PROVEEDOR a la fila indicada
    private static void PROVEEDOR2Row(dbProveedor oPROVEEDOR, DataRow r){
        // asigna un objeto PROVEEDOR al dataRow indicado
        r["CodigoProveedor"] = oPROVEEDOR.CodigoProveedor;
        r["FormaPago"] = oPROVEEDOR.FormaPago;
        r["PorceDescuent"] = oPROVEEDOR.PorceDescuent;
        r["IncluyeTranspo"] = oPROVEEDOR.IncluyeTranspo;
        r["LimCreditoPrv"] = oPROVEEDOR.LimCreditoPrv;
        r["Producto1"] = oPROVEEDOR.Producto1;
        r["Servicios1"] = oPROVEEDOR.Servicios1;
        r["EntregaNuestraOficina"] = oPROVEEDOR.EntregaNuestraOficina;
        r["RetirarMercaderia"] = oPROVEEDOR.RetirarMercaderia;
        r["EnvioATransporte"] = oPROVEEDOR.EnvioATransporte;
        r["Observaciones"] = oPROVEEDOR.Observaciones;
        r["CtbProveedor"] = oPROVEEDOR.CtbProveedor;
        r["CtbProveedor2"] = oPROVEEDOR.CtbProveedor2;
        r["limitecreditoprv"] = oPROVEEDOR.limitecreditoprv;
        r["placa"] = oPROVEEDOR.placa;
        r["transMaritimo"] = oPROVEEDOR.transMaritimo;
        r["transTerrestre"] = oPROVEEDOR.transTerrestre;
        r["transAereo"] = oPROVEEDOR.transAereo;
    }
    //
    // crea una nueva fila y la asigna a un objeto PROVEEDOR
    private static void nuevoPROVEEDOR(DataTable dt, dbProveedor oPROVEEDOR){
        // Crear un nuevo PROVEEDOR
        DataRow dr = dt.NewRow();
        dbProveedor oP = row2PROVEEDOR(dr);
        //
        oP.CodigoProveedor = oPROVEEDOR.CodigoProveedor;
        oP.FormaPago = oPROVEEDOR.FormaPago;
        oP.PorceDescuent = oPROVEEDOR.PorceDescuent;
        oP.IncluyeTranspo = oPROVEEDOR.IncluyeTranspo;
        oP.LimCreditoPrv = oPROVEEDOR.LimCreditoPrv;
        oP.Producto1 = oPROVEEDOR.Producto1;
        oP.Servicios1 = oPROVEEDOR.Servicios1;
        oP.EntregaNuestraOficina = oPROVEEDOR.EntregaNuestraOficina;
        oP.RetirarMercaderia = oPROVEEDOR.RetirarMercaderia;
        oP.EnvioATransporte = oPROVEEDOR.EnvioATransporte;
        oP.Observaciones = oPROVEEDOR.Observaciones;
        oP.CtbProveedor = oPROVEEDOR.CtbProveedor;
        oP.CtbProveedor2 = oPROVEEDOR.CtbProveedor2;
        oP.limitecreditoprv = oPROVEEDOR.limitecreditoprv;
        oP.placa = oPROVEEDOR.placa;
        oP.transMaritimo = oPROVEEDOR.transMaritimo;
        oP.transTerrestre = oPROVEEDOR.transTerrestre;
        oP.transAereo = oPROVEEDOR.transAereo;
        //
        PROVEEDOR2Row(oP, dr);
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
        // devuelve una tabla con los datos de la tabla PROVEEDOR
        SqlDataAdapter da;
        DataTable dt = new DataTable("PROVEEDOR");
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
    public static dbProveedor Buscar(string sWhere){
        // Busca en la tabla los datos indicados en el parámetro
        // el parámetro contendrá lo que se usará después del WHERE
        dbProveedor oPROVEEDOR = null;
        SqlDataAdapter da;
        DataTable dt = new DataTable("PROVEEDOR");
        string sel = "SELECT * FROM PROVEEDOR WHERE " + sWhere;
        //
        da = new SqlDataAdapter(sel, cadenaConexion);
        da.Fill(dt);
        //
        if(dt.Rows.Count > 0){
            oPROVEEDOR = row2PROVEEDOR(dt.Rows[0]);
        }
        return oPROVEEDOR;
    }
    //
    public string Actualizar(){
        string sel = "SELECT * FROM PROVEEDOR WHERE CodigoProveedor = '" + this.CodigoProveedor + "'";
        return Actualizar(sel);
    }
    public string Actualizar(string sel){
        // Actualiza los datos indicados
        // El parámetro, que es una cadena de selección, indicará el criterio de actualización
        //
        // En caso de error, devolverá la cadena empezando por ERROR.
        CadenaSelect = sel;
        SqlConnection cnn;
        SqlDataAdapter da;
        DataTable dt = new DataTable("PROVEEDOR");
        //
        cnn = new SqlConnection(cadenaConexion);
        da = new SqlDataAdapter(sel, cnn);
        da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
        SqlCommandBuilder cb = new SqlCommandBuilder(da);
        da.UpdateCommand = cb.GetUpdateCommand();
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
            PROVEEDOR2Row(this, dt.Rows[0]);
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
        // Crear un nuevo registro
        // En caso de error, devolverá la cadena de error empezando por ERROR:.
        SqlConnection cnn;
        SqlDataAdapter da;
        DataTable dt = new DataTable("PROVEEDOR");
        //
        cnn = new SqlConnection(cadenaConexion);
        da = new SqlDataAdapter(CadenaSelect, cnn);
        da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
        SqlCommandBuilder cb = new SqlCommandBuilder(da);
        da.InsertCommand = cb.GetInsertCommand();
        try{
            da.Fill(dt);
        }catch(Exception ex){
            return "ERROR: " + ex.Message;
        }
        //
        nuevoPROVEEDOR(dt, this);
        //
        try{
            da.Update(dt);
            dt.AcceptChanges();
            return "Se ha creado un nuevo PROVEEDOR";
        }catch(Exception ex){
            return "ERROR: " + ex.Message;
        }
    }
    //
    public string Borrar(){
        string sel = "SELECT * FROM PROVEEDOR WHERE CodigoProveedor = '" + this.CodigoProveedor + "'";
        //
        return Borrar(sel);
    }
    public string Borrar(string sel){
        // Borrar el registro al que apunta esta clase
        // En caso de error, devolverá la cadena de error empezando por ERROR:.
        SqlConnection cnn;
        SqlDataAdapter da;
        DataTable dt = new DataTable("PROVEEDOR");
        //
        cnn = new SqlConnection(cadenaConexion);
        da = new SqlDataAdapter(sel, cnn);
        da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
        SqlCommandBuilder cb = new SqlCommandBuilder(da);
        da.DeleteCommand = cb.GetDeleteCommand();
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
    //
}
