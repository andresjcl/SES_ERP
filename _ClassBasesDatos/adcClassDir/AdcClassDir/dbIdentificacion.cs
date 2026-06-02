using System;
using System.Data;
using System.Data.SqlClient;
//
public class Identificacion{
    private System.String _TipoPersona;
    private System.Boolean _EsCliente;
    private System.Boolean _EsProveedor;
    private System.Boolean _EsEmpleado;
    private System.Boolean _EsBanco;
    private System.Boolean _EsAsociado;
    private System.Boolean _EsVendedor;
    private System.String _Codigo;
    private System.String _TipoIdentificacion;
    private System.String _CedulaIdentidadRuc;
    private System.String _Nombres;
    private System.String _Apellidos;
    private System.String _NombreImpresion;
    private System.String _País;
    private System.String _Provincia;
    private System.String _Ciudad;
    private System.String _Domicilio;
    private System.String _NumeroDomicilio;
    private System.String _Sector;
    private System.String _Telefono1;
    private System.String _Telefono2;
    private System.String _Telefono3;
    private System.String _NúmeroFax;
    private System.String _Casilla;
    private System.String _CorreoElectrónico;
    private System.String _Paginaweb;
    private System.String _Logotipo;
    private System.String _CodGrabo;
    private System.Decimal _ComisionVenta;
    private System.String _CtaCobrarComisiones;
    private System.String _FichaDental;
    private System.Boolean _ExoneradoIva;
    private System.String _EsDirecta;
    private System.String _Grupo1;
    private System.String _Grupo2;
    private System.String _Grupo3;
    private System.String _HistoriaClinica;
    private System.String _CodAsociacion;
    private System.String _RegistroMunicp;
    private System.Boolean _esRise;
    private System.String _NroCtrbuyteEspecial;
    private System.Boolean _ObligLlevarConta;
    private System.Boolean _RegimenMicroempresas;
    private System.String _regionDomicilio;
    private System.String _SectorDomicilio;
    private System.String _NroAcdoAgntRetencion;
    

    private System.Boolean _CtrbuyteEspecial;
    private System.String _TipoRegimen;

    //
    // Este método se usará para ajustar los anchos de las propiedades
    private string ajustarAncho(string cadena, int ancho){
        System.Text.StringBuilder sb = new System.Text.StringBuilder(new String(' ', ancho));
        // devolver la cadena quitando los espacios en blanco
        // esto asegura que no se devolverá un tamaño mayor ni espacios "extras"
        return (cadena + sb.ToString()).Substring(0, ancho).Trim();
    }
    //
    public System.String TipoPersona{
        get{
            return ajustarAncho(_TipoPersona,10);
        }
        set{
            _TipoPersona = value;
        }
    }
    public System.Boolean EsCliente{
        get{
            return  _EsCliente;
        }
        set{
            _EsCliente = value;
        }
    }
    public System.Boolean EsProveedor{
        get{
            return  _EsProveedor;
        }
        set{
            _EsProveedor = value;
        }
    }
    public System.Boolean EsEmpleado{
        get{
            return  _EsEmpleado;
        }
        set{
            _EsEmpleado = value;
        }
    }
    public System.Boolean EsBanco{
        get{
            return  _EsBanco;
        }
        set{
            _EsBanco = value;
        }
    }
    public System.Boolean EsAsociado{
        get{
            return  _EsAsociado;
        }
        set{
            _EsAsociado = value;
        }
    }
    public System.Boolean EsVendedor{
        get{
            return  _EsVendedor;
        }
        set{
            _EsVendedor = value;
        }
    }
    public System.String Codigo{
        get{
            return ajustarAncho(_Codigo,15);
        }
        set{
            _Codigo = value;
        }
    }
    public System.String TipoIdentificacion{
        get{
            return ajustarAncho(_TipoIdentificacion,1);
        }
        set{
            _TipoIdentificacion = value;
        }
    }
    public System.String CedulaIdentidadRuc{
        get{
            return ajustarAncho(_CedulaIdentidadRuc,16);
        }
        set{
            _CedulaIdentidadRuc = value;
        }
    }
    public System.String Nombres{
        get{
            return ajustarAncho(_Nombres,128);
        }
        set{
            _Nombres = value;
        }
    }
    public System.String Apellidos{
        get{
            return ajustarAncho(_Apellidos,80);
        }
        set{
            _Apellidos = value;
        }
    }
    public System.String NombreImpresion{
        get{
            return ajustarAncho(_NombreImpresion,256);
        }
        set{
            _NombreImpresion = value;
        }
    }
    public System.String País{
        get{
            return ajustarAncho(_País,15);
        }
        set{
            _País = value;
        }
    }
    public System.String Provincia{
        get{
            return ajustarAncho(_Provincia,15);
        }
        set{
            _Provincia = value;
        }
    }
    public System.String Ciudad{
        get{
            return ajustarAncho(_Ciudad,15);
        }
        set{
            _Ciudad = value;
        }
    }
    public System.String Domicilio{
        get{
            return ajustarAncho(_Domicilio,300);
        }
        set{
            _Domicilio = value;
        }
    }
    public System.String NumeroDomicilio{
        get{
            return ajustarAncho(_NumeroDomicilio,50);
        }
        set{
            _NumeroDomicilio = value;
        }
    }
    public System.String Sector{
        get{
            return ajustarAncho(_Sector,300);
        }
        set{
            _Sector = value;
        }
    }
    public System.String Telefono1{
        get{
            return ajustarAncho(_Telefono1,128);
        }
        set{
            _Telefono1 = value;
        }
    }
    public System.String Telefono2{
        get{
            return ajustarAncho(_Telefono2,25);
        }
        set{
            _Telefono2 = value;
        }
    }
    public System.String Telefono3{
        get{
            return ajustarAncho(_Telefono3,25);
        }
        set{
            _Telefono3 = value;
        }
    }
    public System.String NúmeroFax{
        get{
            return ajustarAncho(_NúmeroFax,150);
        }
        set{
            _NúmeroFax = value;
        }
    }
    public System.String Casilla{
        get{
            return ajustarAncho(_Casilla,25);
        }
        set{
            _Casilla = value;
        }
    }
    public System.String CorreoElectrónico{
        get{
            return ajustarAncho(_CorreoElectrónico,150);
        }
        set{
            _CorreoElectrónico = value;
        }
    }
    public System.String Paginaweb{
        get{
            return ajustarAncho(_Paginaweb,150);
        }
        set{
            _Paginaweb = value;
        }
    }
    public System.String Logotipo{
        get{
            return ajustarAncho(_Logotipo,600);
        }
        set{
            _Logotipo = value;
        }
    }
    public System.String CodGrabo{
        get{
            return ajustarAncho(_CodGrabo,20);
        }
        set{
            _CodGrabo = value;
        }
    }
    public System.Decimal ComisionVenta{
        get{
            return  _ComisionVenta;
        }
        set{
            _ComisionVenta = value;
        }
    }
    public System.String CtaCobrarComisiones{
        get{
            return ajustarAncho(_CtaCobrarComisiones,20);
        }
        set{
            _CtaCobrarComisiones = value;
        }
    }
    public System.String FichaDental{
        get{
            return ajustarAncho(_FichaDental,15);
        }
        set{
            _FichaDental = value;
        }
    }
    public System.Boolean ExoneradoIva{
        get{
            return  _ExoneradoIva;
        }
        set{
            _ExoneradoIva = value;
        }
    }
    public System.String EsDirecta{
        get{
            return ajustarAncho(_EsDirecta,2);
        }
        set{
            _EsDirecta = value;
        }
    }
    public System.String Grupo1{
        get{
            return ajustarAncho(_Grupo1,128);
        }
        set{
            _Grupo1 = value;
        }
    }
    public System.String Grupo2{
        get{
            return ajustarAncho(_Grupo2,128);
        }
        set{
            _Grupo2 = value;
        }
    }
    public System.String Grupo3{
        get{
            return ajustarAncho(_Grupo3,128);
        }
        set{
            _Grupo3 = value;
        }
    }
    public System.String HistoriaClinica{
        get{
            return ajustarAncho(_HistoriaClinica,50);
        }
        set{
            _HistoriaClinica = value;
        }
    }
    public System.String CodAsociacion{
        get{
            return ajustarAncho(_CodAsociacion,20);
        }
        set{
            _CodAsociacion = value;
        }
    }
    public System.String RegistroMunicp{
        get{
            return ajustarAncho(_RegistroMunicp,50);
        }
        set{
            _RegistroMunicp = value;
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
    public System.String NroCtrbuyteEspecial{
        get{
            return ajustarAncho(_NroCtrbuyteEspecial,20);
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

    public System.Boolean RegimenMicroempresas{
        get{
            return _RegimenMicroempresas;
        }
        set{
            _RegimenMicroempresas = value;
        }
    }
    public System.String regionDomicilio{
        get{
            return ajustarAncho(_regionDomicilio,30);
        }
        set{
            _regionDomicilio = value;
        }
    }
    public System.String SectorDomicilio
    {
        get
        {
            return ajustarAncho(_SectorDomicilio, 30);
        }
        set
        {
            _SectorDomicilio = value;
        }
    }
    public System.String NroAcdoAgntRetencion{
        get{
            return ajustarAncho(_NroAcdoAgntRetencion,20);
        }
        set{
            _NroAcdoAgntRetencion = value;
        }
    }

    public System.Boolean CtrbuyteEspecial
    {
        get
        {
            return _CtrbuyteEspecial;
        }
        set
        {
            _CtrbuyteEspecial = value;
        }
    }

    public System.String TipoRegimen
    {
        get
        {
            return ajustarAncho(_TipoRegimen, 50);
        }
        set
        {
            _TipoRegimen = value;
        }
    }

    

    //
    // Campos y métodos compartidos (estáticos) para gestionar la base de datos
    //
    // La cadena de conexión a la base de datos
    private static string cadenaConexion = @"";
    // La cadena de selección
    public static string CadenaSelect = "SELECT * FROM Identificacion";
    //
    public Identificacion(){
    }
    public Identificacion(string conex){
        cadenaConexion = conex;
    }
    //
    // Métodos compartidos (estáticos) privados
    //
    // asigna una fila de la tabla a un objeto Identificacion
    private static Identificacion row2Identificacion(DataRow r){
        // asigna a un objeto Identificacion los datos del dataRow indicado
        Identificacion oIdentificacion = new Identificacion();
        //
        oIdentificacion.TipoPersona = r["TipoPersona"].ToString();
        try{
            oIdentificacion.EsCliente = System.Boolean.Parse(r["EsCliente"].ToString());
        }catch{
            oIdentificacion.EsCliente = false;
        }
        try{
            oIdentificacion.EsProveedor = System.Boolean.Parse(r["EsProveedor"].ToString());
        }catch{
            oIdentificacion.EsProveedor = false;
        }
        try{
            oIdentificacion.EsEmpleado = System.Boolean.Parse(r["EsEmpleado"].ToString());
        }catch{
            oIdentificacion.EsEmpleado = false;
        }
        try{
            oIdentificacion.EsBanco = System.Boolean.Parse(r["EsBanco"].ToString());
        }catch{
            oIdentificacion.EsBanco = false;
        }
        try{
            oIdentificacion.EsAsociado = System.Boolean.Parse(r["EsAsociado"].ToString());
        }catch{
            oIdentificacion.EsAsociado = false;
        }
        try{
            oIdentificacion.EsVendedor = System.Boolean.Parse(r["EsVendedor"].ToString());
        }catch{
            oIdentificacion.EsVendedor = false;
        }
        oIdentificacion.Codigo = r["Codigo"].ToString();
        oIdentificacion.TipoIdentificacion = r["TipoIdentificacion"].ToString();
        oIdentificacion.CedulaIdentidadRuc = r["CedulaIdentidadRuc"].ToString();
        oIdentificacion.Nombres = r["Nombres"].ToString();
        oIdentificacion.Apellidos = r["Apellidos"].ToString();
        oIdentificacion.NombreImpresion = r["NombreImpresion"].ToString();
        oIdentificacion.País = r["País"].ToString();
        oIdentificacion.Provincia = r["Provincia"].ToString();
        oIdentificacion.Ciudad = r["Ciudad"].ToString();
        oIdentificacion.Domicilio = r["Domicilio"].ToString();
        oIdentificacion.NumeroDomicilio = r["NumeroDomicilio"].ToString();
        oIdentificacion.Sector = r["Sector"].ToString();
        oIdentificacion.Telefono1 = r["Telefono1"].ToString();
        oIdentificacion.Telefono2 = r["Telefono2"].ToString();
        oIdentificacion.Telefono3 = r["Telefono3"].ToString();
        oIdentificacion.NúmeroFax = r["NúmeroFax"].ToString();
        oIdentificacion.Casilla = r["Casilla"].ToString();
        oIdentificacion.CorreoElectrónico = r["CorreoElectrónico"].ToString();
        oIdentificacion.Paginaweb = r["Paginaweb"].ToString();
        oIdentificacion.Logotipo = r["Logotipo"].ToString();
        oIdentificacion.CodGrabo = r["CodGrabo"].ToString();
        oIdentificacion.ComisionVenta = System.Decimal.Parse("0" + r["ComisionVenta"].ToString());
        oIdentificacion.CtaCobrarComisiones = r["CtaCobrarComisiones"].ToString();
        oIdentificacion.FichaDental = r["FichaDental"].ToString();
        try{
            oIdentificacion.ExoneradoIva = System.Boolean.Parse(r["ExoneradoIva"].ToString());
        }catch{
            oIdentificacion.ExoneradoIva = false;
        }
        oIdentificacion.EsDirecta = r["EsDirecta"].ToString();
        oIdentificacion.Grupo1 = r["Grupo1"].ToString();
        oIdentificacion.Grupo2 = r["Grupo2"].ToString();
        oIdentificacion.Grupo3 = r["Grupo3"].ToString();
        oIdentificacion.HistoriaClinica = r["HistoriaClinica"].ToString();
        oIdentificacion.CodAsociacion = r["CodAsociacion"].ToString();
        oIdentificacion.RegistroMunicp = r["RegistroMunicp"].ToString();
        try{
            oIdentificacion.esRise = System.Boolean.Parse(r["esRise"].ToString());
        }catch{
            oIdentificacion.esRise = false;
        }
        try
        {
            oIdentificacion.CtrbuyteEspecial = System.Boolean.Parse(r["CtrbuyteEspecial"].ToString());
        }
        catch
        {
            oIdentificacion.CtrbuyteEspecial = false;
        }


        oIdentificacion.NroCtrbuyteEspecial = r["NroCtrbuyteEspecial"].ToString();

        try{
            oIdentificacion.ObligLlevarConta = System.Boolean.Parse(r["ObligLlevarConta"].ToString());
        }catch{
            oIdentificacion.ObligLlevarConta = false;
        }
        try{
            oIdentificacion.RegimenMicroempresas = System.Boolean.Parse(r["RegimenMicroempresas"].ToString());
        }catch{
            oIdentificacion.RegimenMicroempresas = false;
        }
        
        oIdentificacion.regionDomicilio = r["regionDomicilio"].ToString();
        oIdentificacion.SectorDomicilio = r["SectorDomicilio"].ToString();
        oIdentificacion.NroAcdoAgntRetencion = r["NroAcdoAgntRetencion"].ToString();

       
        oIdentificacion.TipoRegimen = r["TipoRegimen"].ToString();

        
        //
        return oIdentificacion;
    }
    //
    // asigna un objeto Identificacion a la fila indicada
    private static void Identificacion2Row(Identificacion oIdentificacion, DataRow r){
        // asigna un objeto Identificacion al dataRow indicado
        r["TipoPersona"] = oIdentificacion.TipoPersona;
        r["EsCliente"] = oIdentificacion.EsCliente;
        r["EsProveedor"] = oIdentificacion.EsProveedor;
        r["EsEmpleado"] = oIdentificacion.EsEmpleado;
        r["EsBanco"] = oIdentificacion.EsBanco;
        r["EsAsociado"] = oIdentificacion.EsAsociado;
        r["EsVendedor"] = oIdentificacion.EsVendedor;
        r["Codigo"] = oIdentificacion.Codigo;
        r["TipoIdentificacion"] = oIdentificacion.TipoIdentificacion;
        r["CedulaIdentidadRuc"] = oIdentificacion.CedulaIdentidadRuc;
        r["Nombres"] = oIdentificacion.Nombres;
        r["Apellidos"] = oIdentificacion.Apellidos;
        r["NombreImpresion"] = oIdentificacion.NombreImpresion;
        r["País"] = oIdentificacion.País;
        r["Provincia"] = oIdentificacion.Provincia;
        r["Ciudad"] = oIdentificacion.Ciudad;
        r["Domicilio"] = oIdentificacion.Domicilio;
        r["NumeroDomicilio"] = oIdentificacion.NumeroDomicilio;
        r["Sector"] = oIdentificacion.Sector;
        r["Telefono1"] = oIdentificacion.Telefono1;
        r["Telefono2"] = oIdentificacion.Telefono2;
        r["Telefono3"] = oIdentificacion.Telefono3;
        r["NúmeroFax"] = oIdentificacion.NúmeroFax;
        r["Casilla"] = oIdentificacion.Casilla;
        r["CorreoElectrónico"] = oIdentificacion.CorreoElectrónico;
        r["Paginaweb"] = oIdentificacion.Paginaweb;
        r["Logotipo"] = oIdentificacion.Logotipo;
        r["CodGrabo"] = oIdentificacion.CodGrabo;
        r["ComisionVenta"] = oIdentificacion.ComisionVenta;
        r["CtaCobrarComisiones"] = oIdentificacion.CtaCobrarComisiones;
        r["FichaDental"] = oIdentificacion.FichaDental;
        r["ExoneradoIva"] = oIdentificacion.ExoneradoIva;
        r["EsDirecta"] = oIdentificacion.EsDirecta;
        r["Grupo1"] = oIdentificacion.Grupo1;
        r["Grupo2"] = oIdentificacion.Grupo2;
        r["Grupo3"] = oIdentificacion.Grupo3;
        r["HistoriaClinica"] = oIdentificacion.HistoriaClinica;
        r["CodAsociacion"] = oIdentificacion.CodAsociacion;
        r["RegistroMunicp"] = oIdentificacion.RegistroMunicp;
        r["esRise"] = oIdentificacion.esRise;
        r["NroCtrbuyteEspecial"] = oIdentificacion.NroCtrbuyteEspecial;
        r["ObligLlevarConta"] = oIdentificacion.ObligLlevarConta;
        r["RegimenMicroempresas"] = oIdentificacion.RegimenMicroempresas;
        r["regionDomicilio"] = oIdentificacion.regionDomicilio;
        r["SectorDomicilio"] = oIdentificacion.SectorDomicilio;
        r["NroAcdoAgntRetencion"] = oIdentificacion.NroAcdoAgntRetencion;

        r["CtrbuyteEspecial"] = oIdentificacion.CtrbuyteEspecial;
        r["TipoRegimen"] = oIdentificacion.TipoRegimen;
        
    }
    //
    // crea una nueva fila y la asigna a un objeto Identificacion
    private static void nuevoIdentificacion(DataTable dt, Identificacion oIdentificacion){
        // Crear un nuevo Identificacion
        DataRow dr = dt.NewRow();
        Identificacion oI = row2Identificacion(dr);
        //
        oI.TipoPersona = oIdentificacion.TipoPersona;
        oI.EsCliente = oIdentificacion.EsCliente;
        oI.EsProveedor = oIdentificacion.EsProveedor;
        oI.EsEmpleado = oIdentificacion.EsEmpleado;
        oI.EsBanco = oIdentificacion.EsBanco;
        oI.EsAsociado = oIdentificacion.EsAsociado;
        oI.EsVendedor = oIdentificacion.EsVendedor;
        oI.Codigo = oIdentificacion.Codigo;
        oI.TipoIdentificacion = oIdentificacion.TipoIdentificacion;
        oI.CedulaIdentidadRuc = oIdentificacion.CedulaIdentidadRuc;
        oI.Nombres = oIdentificacion.Nombres;
        oI.Apellidos = oIdentificacion.Apellidos;
        oI.NombreImpresion = oIdentificacion.NombreImpresion;
        oI.País = oIdentificacion.País;
        oI.Provincia = oIdentificacion.Provincia;
        oI.Ciudad = oIdentificacion.Ciudad;
        oI.Domicilio = oIdentificacion.Domicilio;
        oI.NumeroDomicilio = oIdentificacion.NumeroDomicilio;
        oI.Sector = oIdentificacion.Sector;
        oI.Telefono1 = oIdentificacion.Telefono1;
        oI.Telefono2 = oIdentificacion.Telefono2;
        oI.Telefono3 = oIdentificacion.Telefono3;
        oI.NúmeroFax = oIdentificacion.NúmeroFax;
        oI.Casilla = oIdentificacion.Casilla;
        oI.CorreoElectrónico = oIdentificacion.CorreoElectrónico;
        oI.Paginaweb = oIdentificacion.Paginaweb;
        oI.Logotipo = oIdentificacion.Logotipo;
        oI.CodGrabo = oIdentificacion.CodGrabo;
        oI.ComisionVenta = oIdentificacion.ComisionVenta;
        oI.CtaCobrarComisiones = oIdentificacion.CtaCobrarComisiones;
        oI.FichaDental = oIdentificacion.FichaDental;
        oI.ExoneradoIva = oIdentificacion.ExoneradoIva;
        oI.EsDirecta = oIdentificacion.EsDirecta;
        oI.Grupo1 = oIdentificacion.Grupo1;
        oI.Grupo2 = oIdentificacion.Grupo2;
        oI.Grupo3 = oIdentificacion.Grupo3;
        oI.HistoriaClinica = oIdentificacion.HistoriaClinica;
        oI.CodAsociacion = oIdentificacion.CodAsociacion;
        oI.RegistroMunicp = oIdentificacion.RegistroMunicp;
        oI.esRise = oIdentificacion.esRise;
        oI.NroCtrbuyteEspecial = oIdentificacion.NroCtrbuyteEspecial;
        oI.ObligLlevarConta = oIdentificacion.ObligLlevarConta;
        oI.RegimenMicroempresas = oIdentificacion.RegimenMicroempresas;
        oI.regionDomicilio = oIdentificacion.regionDomicilio;
        oI.SectorDomicilio = oIdentificacion.SectorDomicilio;
        oI.NroAcdoAgntRetencion = oIdentificacion.NroAcdoAgntRetencion;

        oI.CtrbuyteEspecial = oIdentificacion.CtrbuyteEspecial;
        oI.TipoRegimen = oIdentificacion.TipoRegimen;
        

        
        //
        Identificacion2Row(oI, dr);
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
        // devuelve una tabla con los datos de la tabla Identificacion
        SqlDataAdapter da;
        DataTable dt = new DataTable("Identificacion");
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
    public static Identificacion Buscar(string sWhere){
        // Busca en la tabla los datos indicados en el parámetro
        // el parámetro contendrá lo que se usará después del WHERE
        Identificacion oIdentificacion = null;
        SqlDataAdapter da;
        DataTable dt = new DataTable("Identificacion");
        string sel = "SELECT * FROM Identificacion WHERE " + sWhere;
        //
        da = new SqlDataAdapter(sel, cadenaConexion);
        da.Fill(dt);
        //
        if(dt.Rows.Count > 0){
            oIdentificacion = row2Identificacion(dt.Rows[0]);
        }
        return oIdentificacion;
    }
    public string Actualizar(){
        string sel = "SELECT * FROM Identificacion WHERE Codigo = '" + this.Codigo + "'";
        return Actualizar(sel);
    }
    public string Actualizar(string sel){
        // En caso de error, devolverá la cadena empezando por ERROR.
        SqlConnection cnn;
        SqlDataAdapter da;
        DataTable dt = new DataTable("Identificacion");
        //
        CadenaSelect = sel;
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
            Identificacion2Row(this, dt.Rows[0]);
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
        DataTable dt = new DataTable("Identificacion");
        //
        cnn = new SqlConnection(cadenaConexion);
        da = new SqlDataAdapter(CadenaSelect, cnn);
        da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
        SqlCommandBuilder cb = new SqlCommandBuilder(da);
        da.InsertCommand = cb.GetInsertCommand();
        //
        try{
            da.Fill(dt);
        }catch(Exception ex){
            return "ERROR: " + ex.Message;
        }
        //
        nuevoIdentificacion(dt, this);
        //
        try{
            da.Update(dt);
            dt.AcceptChanges();
            return "Se ha creado un nuevo Identificacion";
        }catch(Exception ex){
            return "ERROR: " + ex.Message;
        }
    }
    //
    public string Borrar(){
        string sel = "SELECT * FROM Identificacion WHERE Codigo = '" + this.Codigo + "'";
        //
        return Borrar(sel);
    }
    public string Borrar(string sel){
        SqlConnection cnn;
        SqlDataAdapter da;
        DataTable dt = new DataTable("Identificacion");
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
