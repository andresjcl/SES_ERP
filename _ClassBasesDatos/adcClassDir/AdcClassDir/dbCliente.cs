using System;
using System.Data;
using System.Data.SqlClient;
//
public class dbCliente{
    // Las variables privadas
    // TODO: Revisar los tipos de los campos
    private System.String _CodigoCli;
    private System.String _TipoCli;
    private System.String _ZonaVentas;
    private System.String _VendedorInterno;
    private System.String _Operador;
    private System.String _ZonaCobranza;
    private System.String _CobradorInterno;
    private System.String _PrecioVenta;
    private System.Decimal _PorcDescuento;
    private System.String _FormaPago;
    private System.Decimal _LimiteCredito;
    private System.Decimal _DescuentoAso;
    private System.String _Observaciones;
    private System.String _CtbCobrar;
    private System.String _Entregarmercaderia;
    private System.String _Contacto;
    private System.String _CtbCobrar2;
    private System.Decimal _NroCtrbuyteEspecial;
    private System.Boolean _ObligLlevarConta;
    private System.Boolean _esRise;
    private System.String _PaisEmbarque;
    private System.String _PuertoEmbarque;
    private System.String _Transportadora;
    //
    // Este método se usará para ajustar los anchos de las propiedades
    private string ajustarAncho(string cadena, int ancho){
        System.Text.StringBuilder sb = new System.Text.StringBuilder(new String(' ', ancho));
        // devolver la cadena quitando los espacios en blanco
        // esto asegura que no se devolverá un tamaño mayor ni espacios "extras"
        return (cadena + sb.ToString()).Substring(0, ancho).Trim();
    }
    public System.String CodigoCli{
        get{
            return ajustarAncho(_CodigoCli,15);
        }
        set{
            _CodigoCli = value;
        }
    }
    public System.String TipoCli{
        get{
            return ajustarAncho(_TipoCli,5);
        }
        set{
            _TipoCli = value;
        }
    }
    public System.String ZonaVentas{
        get{
            return ajustarAncho(_ZonaVentas,5);
        }
        set{
            _ZonaVentas = value;
        }
    }
    public System.String VendedorInterno{
        get{
            return ajustarAncho(_VendedorInterno,15);
        }
        set{
            _VendedorInterno = value;
        }
    }
    public System.String Operador
    {
        get
        {
            return ajustarAncho(_Operador, 15);
        }
        set
        {
            _Operador = value;
        }
    }
    public System.String ZonaCobranza
    {
        get{
            return ajustarAncho(_ZonaCobranza,5);
        }
        set{
            _ZonaCobranza = value;
        }
    }
    public System.String CobradorInterno{
        get{
            return ajustarAncho(_CobradorInterno,15);
        }
        set{
            _CobradorInterno = value;
        }
    }
    public System.String PrecioVenta{
        get{
            return ajustarAncho(_PrecioVenta,5);
        }
        set{
            _PrecioVenta = value;
        }
    }
    public System.Decimal PorcDescuento{
        get{
            return  _PorcDescuento;
        }
        set{
            _PorcDescuento = value;
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
    public System.Decimal LimiteCredito{
        get{
            return  _LimiteCredito;
        }
        set{
            _LimiteCredito = value;
        }
    }
    public System.Decimal DescuentoAso{
        get{
            return  _DescuentoAso;
        }
        set{
            _DescuentoAso = value;
        }
    }
    public System.String Observaciones{
        get{
            return ajustarAncho(_Observaciones,128);
        }
        set{
            _Observaciones = value;
        }
    }
    public System.String CtbCobrar{
        get{
            return ajustarAncho(_CtbCobrar,15);
        }
        set{
            _CtbCobrar = value;
        }
    }
    public System.String Entregarmercaderia{
        get{
            return ajustarAncho(_Entregarmercaderia,50);
        }
        set{
            _Entregarmercaderia = value;
        }
    }
    public System.String Contacto{
        get{
            return ajustarAncho(_Contacto,50);
        }
        set{
            _Contacto = value;
        }
    }
    public System.String CtbCobrar2{
        get{
            return ajustarAncho(_CtbCobrar2,15);
        }
        set{
            _CtbCobrar2 = value;
        }
    }
    public System.Decimal NroCtrbuyteEspecial{
        get{
            return  _NroCtrbuyteEspecial;
        }
        set{
            _NroCtrbuyteEspecial = value;
        }
    }
    public System.Boolean ObligLlevarConta{
        get{
            return  _ObligLlevarConta;
        }
        set{
            _ObligLlevarConta = value;
        }
    }
    public System.Boolean esRise{
        get{
            return  _esRise;
        }
        set{
            _esRise = value;
        }
    }
    public System.String PaisEmbarque{
        get{
            return ajustarAncho(_PaisEmbarque,50);
        }
        set{
            _PaisEmbarque = value;
        }
    }
    public System.String PuertoEmbarque{
        get{
            return ajustarAncho(_PuertoEmbarque,50);
        }
        set{
            _PuertoEmbarque = value;
        }
    }
    public System.String Transportadora
    {
        get
        {
            return ajustarAncho(_Transportadora, 50);
        }
        set
        {
            _Transportadora = value;
        }
    }
    //
    // Campos y métodos compartidos (estáticos) para gestionar la base de datos
    //
    // La cadena de conexión a la base de datos
    private static string cadenaConexion = @"";
    // La cadena de selección
    public static string CadenaSelect = "";
    //
    public dbCliente(){
    }
    public dbCliente(string conex){
        cadenaConexion = conex;
    }
    //
    // Métodos compartidos (estáticos) privados
    //
    // asigna una fila de la tabla a un objeto CLIENTE
    private static dbCliente row2CLIENTE(DataRow r){
        // asigna a un objeto CLIENTE los datos del dataRow indicado
        dbCliente oCLIENTE = new dbCliente();
        //
        oCLIENTE.CodigoCli = r["CodigoCli"].ToString();
        oCLIENTE.TipoCli = r["TipoCli"].ToString();
        oCLIENTE.ZonaVentas = r["ZonaVentas"].ToString();
        oCLIENTE.VendedorInterno = r["VendedorInterno"].ToString();
        oCLIENTE.Operador = r["Operador"].ToString();
        oCLIENTE.ZonaCobranza = r["ZonaCobranza"].ToString();
        oCLIENTE.CobradorInterno = r["CobradorInterno"].ToString();
        oCLIENTE.PrecioVenta = r["PrecioVenta"].ToString();
        oCLIENTE.PorcDescuento = System.Decimal.Parse("0" + r["PorcDescuento"].ToString());
        oCLIENTE.FormaPago = r["FormaPago"].ToString();
        oCLIENTE.LimiteCredito = System.Decimal.Parse("0" + r["LimiteCredito"].ToString());
        oCLIENTE.DescuentoAso = System.Decimal.Parse("0" + r["DescuentoAso"].ToString());
        oCLIENTE.Observaciones = r["Observaciones"].ToString();
        oCLIENTE.CtbCobrar = r["CtbCobrar"].ToString();
        oCLIENTE.Entregarmercaderia = r["Entregarmercaderia"].ToString();
        oCLIENTE.Contacto = r["Contacto"].ToString();
        oCLIENTE.CtbCobrar2 = r["CtbCobrar2"].ToString();
        oCLIENTE.NroCtrbuyteEspecial = System.Decimal.Parse("0" + r["NroCtrbuyteEspecial"].ToString());
        try{
            oCLIENTE.ObligLlevarConta = System.Boolean.Parse(r["ObligLlevarConta"].ToString());
        }catch{
            oCLIENTE.ObligLlevarConta = false;
        }
        try{
            oCLIENTE.esRise = System.Boolean.Parse(r["esRise"].ToString());
        }catch{
            oCLIENTE.esRise = false;
        }
        oCLIENTE.PaisEmbarque = r["PaisEmbarque"].ToString();
        oCLIENTE.PuertoEmbarque = r["PuertoEmbarque"].ToString();
        oCLIENTE.Transportadora = r["Transportadora"].ToString();
        //
        return oCLIENTE;
    }
    //
    // asigna un objeto CLIENTE a la fila indicada
    private static void CLIENTE2Row(dbCliente oCLIENTE, DataRow r){
        // asigna un objeto CLIENTE al dataRow indicado
        r["CodigoCli"] = oCLIENTE.CodigoCli;
        r["TipoCli"] = oCLIENTE.TipoCli;
        r["ZonaVentas"] = oCLIENTE.ZonaVentas;
        r["VendedorInterno"] = oCLIENTE.VendedorInterno;
        r["Operador"] = oCLIENTE.Operador;
        r["ZonaCobranza"] = oCLIENTE.ZonaCobranza;
        r["CobradorInterno"] = oCLIENTE.CobradorInterno;
        r["PrecioVenta"] = oCLIENTE.PrecioVenta;
        r["PorcDescuento"] = oCLIENTE.PorcDescuento;
        r["FormaPago"] = oCLIENTE.FormaPago;
        r["LimiteCredito"] = oCLIENTE.LimiteCredito;
        r["DescuentoAso"] = oCLIENTE.DescuentoAso;
        r["Observaciones"] = oCLIENTE.Observaciones;
        r["CtbCobrar"] = oCLIENTE.CtbCobrar;
        r["Entregarmercaderia"] = oCLIENTE.Entregarmercaderia;
        r["Contacto"] = oCLIENTE.Contacto;
        r["CtbCobrar2"] = oCLIENTE.CtbCobrar2;
        r["NroCtrbuyteEspecial"] = oCLIENTE.NroCtrbuyteEspecial;
        r["ObligLlevarConta"] = oCLIENTE.ObligLlevarConta;
        r["esRise"] = oCLIENTE.esRise;
        r["PaisEmbarque"] = oCLIENTE.PaisEmbarque;
        r["PuertoEmbarque"] = oCLIENTE.PuertoEmbarque;
        r["Transportadora"] = oCLIENTE.Transportadora;
    }
    //
    // crea una nueva fila y la asigna a un objeto CLIENTE
    private static void nuevoCLIENTE(DataTable dt, dbCliente oCLIENTE){
        // Crear un nuevo CLIENTE
        DataRow dr = dt.NewRow();
        dbCliente oC = row2CLIENTE(dr);
        //
        oC.CodigoCli = oCLIENTE.CodigoCli;
        oC.TipoCli = oCLIENTE.TipoCli;
        oC.ZonaVentas = oCLIENTE.ZonaVentas;
        oC.VendedorInterno = oCLIENTE.VendedorInterno;
        oC.Operador = oCLIENTE.Operador;
        oC.ZonaCobranza = oCLIENTE.ZonaCobranza;
        oC.CobradorInterno = oCLIENTE.CobradorInterno;
        oC.PrecioVenta = oCLIENTE.PrecioVenta;
        oC.PorcDescuento = oCLIENTE.PorcDescuento;
        oC.FormaPago = oCLIENTE.FormaPago;
        oC.LimiteCredito = oCLIENTE.LimiteCredito;
        oC.DescuentoAso = oCLIENTE.DescuentoAso;
        oC.Observaciones = oCLIENTE.Observaciones;
        oC.CtbCobrar = oCLIENTE.CtbCobrar;
        oC.Entregarmercaderia = oCLIENTE.Entregarmercaderia;
        oC.Contacto = oCLIENTE.Contacto;
        oC.CtbCobrar2 = oCLIENTE.CtbCobrar2;
        oC.NroCtrbuyteEspecial = oCLIENTE.NroCtrbuyteEspecial;
        oC.ObligLlevarConta = oCLIENTE.ObligLlevarConta;
        oC.esRise = oCLIENTE.esRise;
        oC.PaisEmbarque = oCLIENTE.PaisEmbarque;
        oC.PuertoEmbarque = oCLIENTE.PuertoEmbarque;
        oC.Transportadora = oCLIENTE.Transportadora;
        //
        CLIENTE2Row(oC, dr);
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
        // devuelve una tabla con los datos de la tabla CLIENTE
        SqlDataAdapter da;
        DataTable dt = new DataTable("CLIENTE");
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
    public static dbCliente Buscar(string sWhere){
        // Busca en la tabla los datos indicados en el parámetro
        // el parámetro contendrá lo que se usará después del WHERE
        dbCliente oCLIENTE = null;
        SqlDataAdapter da;
        DataTable dt = new DataTable("CLIENTE");
        string sel = "SELECT * FROM CLIENTE WHERE " + sWhere;
        //
        da = new SqlDataAdapter(sel, cadenaConexion);
        da.Fill(dt);
        //
        if(dt.Rows.Count > 0){
            oCLIENTE = row2CLIENTE(dt.Rows[0]);
        }
        return oCLIENTE;
    }
    //
    public string Actualizar(){
        string sel = "SELECT * FROM CLIENTE WHERE CodigoCli = '" + this.CodigoCli + "'";
        return Actualizar(sel);
    }
    public string Actualizar(string sel){
        // Actualiza los datos indicados
        // El parámetro, que es una cadena de selección, indicará el criterio de actualización
        //
        // En caso de error, devolverá la cadena empezando por ERROR.
        SqlConnection cnn;
        SqlDataAdapter da;
        DataTable dt = new DataTable("CLIENTE");
        //
        CadenaSelect = sel;
        cnn = new SqlConnection(cadenaConexion);
        //da = new SqlDataAdapter(CadenaSelect, cnn);
        da = new SqlDataAdapter(sel, cnn);
        da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
        SqlCommandBuilder cb = new SqlCommandBuilder(da);
        da.UpdateCommand = cb.GetUpdateCommand();
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
            CLIENTE2Row(this, dt.Rows[0]);
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
        DataTable dt = new DataTable("CLIENTE");
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
        nuevoCLIENTE(dt, this);
        //
        try{
            da.Update(dt);
            dt.AcceptChanges();
            return "Se ha creado un nuevo CLIENTE";
        }catch(Exception ex){
            return "ERROR: " + ex.Message;
        }
    }
    //
    public string Borrar(){
        string sel = "SELECT * FROM CLIENTE WHERE CodigoCli = '" + this.CodigoCli + "'";
        //
        return Borrar(sel);
    }
    public string Borrar(string sel){
        SqlConnection cnn;
        SqlDataAdapter da;
        DataTable dt = new DataTable("CLIENTE");
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
}
