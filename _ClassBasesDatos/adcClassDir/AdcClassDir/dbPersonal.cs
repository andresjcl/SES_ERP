
using System;
using System.Data;
using System.Data.SqlClient;
//
public class dbPersonal{
    // Las variables privadas
    // TODO: Revisar los tipos de los campos
    private System.String _CodigoPer;
    private System.Int32 _AsociadoAEmpresa;
    private System.DateTime _FechaNacimiento;
    private System.String _LugarNacimiento;
    private System.String _Sexo;
    private System.String _EstadoCivil;
    private System.String _Nacionalidad;
    private System.String _Hobbys;
    private System.String _Profesión;
    private System.String _Referirsecomo;
    private System.String _Especialidad;
    private System.String _Especialidad2;
    private System.String _TipoSangre;
    private System.String _DirecciónTrabajo;
    private System.String _codigotarjrta;
    private System.String _numerotarjrta;
    private System.String _paisNacimto;
    private System.String _ciudadNacimto;
    private System.String _provNacimto;
    private System.String _regionNacimto;
    private System.String _Discapacidad;
    private System.Decimal _PorcentajeDiscapacidad;

    //
    // Este método se usará para ajustar los anchos de las propiedades
    private string ajustarAncho(string cadena, int ancho){
        System.Text.StringBuilder sb = new System.Text.StringBuilder(new String(' ', ancho));
        // devolver la cadena quitando los espacios en blanco
        // esto asegura que no se devolverá un tamaño mayor ni espacios "extras"
        return (cadena + sb.ToString()).Substring(0, ancho).Trim();
    }
    //
    public System.String CodigoPer{
        get{
            return ajustarAncho(_CodigoPer,15);
        }
        set{
            _CodigoPer = value;
        }
    }
    public System.Int32 AsociadoAEmpresa{
        get{
            return  _AsociadoAEmpresa;
        }
        set{
            _AsociadoAEmpresa = value;
        }
    }
    public System.DateTime FechaNacimiento{
        get{
            return  _FechaNacimiento;
        }
        set{
            _FechaNacimiento = value;
        }
    }
    public System.String LugarNacimiento{
        get{
            return ajustarAncho(_LugarNacimiento,35);
        }
        set{
            _LugarNacimiento = value;
        }
    }
    public System.String Sexo{
        get{
            return ajustarAncho(_Sexo,1);
        }
        set{
            _Sexo = value;
        }
    }
    public System.String EstadoCivil{
        get{
            return ajustarAncho(_EstadoCivil,12);
        }
        set{
            _EstadoCivil = value;
        }
    }
    public System.String Nacionalidad{
        get{
            return ajustarAncho(_Nacionalidad,128);
        }
        set{
            _Nacionalidad = value;
        }
    }
    public System.String Hobbys{
        get{
            return ajustarAncho(_Hobbys,40);
        }
        set{
            _Hobbys = value;
        }
    }
    public System.String Profesión{
        get{
            return ajustarAncho(_Profesión,128);
        }
        set{
            _Profesión = value;
        }
    }
    public System.String Referirsecomo{
        get{
            return ajustarAncho(_Referirsecomo,5);
        }
        set{
            _Referirsecomo = value;
        }
    }
    public System.String Especialidad{
        get{
            return ajustarAncho(_Especialidad,128);
        }
        set{
            _Especialidad = value;
        }
    }
    public System.String Especialidad2
    {
        get
        {
            return ajustarAncho(_Especialidad2, 128);
        }
        set
        {
            _Especialidad2 = value;
        }
    }
    public System.String TipoSangre{
        get{
            return ajustarAncho(_TipoSangre,20);
        }
        set{
            _TipoSangre = value;
        }
    }
    public System.String DirecciónTrabajo{
        get{
            return ajustarAncho(_DirecciónTrabajo,128);
        }
        set{
            _DirecciónTrabajo = value;
        }
    }
    public System.String codigotarjrta{
        get{
            return ajustarAncho(_codigotarjrta,50);
        }
        set{
            _codigotarjrta = value;
        }
    }
    public System.String numerotarjrta{
        get{
            return ajustarAncho(_numerotarjrta,50);
        }
        set{
            _numerotarjrta = value;
        }
    }
    public System.String paisNacimto{
        get{
            return ajustarAncho(_paisNacimto,50);
        }
        set{
            _paisNacimto = value;
        }
    }
    public System.String ciudadNacimto{
        get{
            return ajustarAncho(_ciudadNacimto,50);
        }
        set{
            _ciudadNacimto = value;
        }
    }
    public System.String provNacimto{
        get{
            return ajustarAncho(_provNacimto,50);
        }
        set{
            _provNacimto = value;
        }
    }
    public System.String regionNacimto{
        get{
            return ajustarAncho(_regionNacimto,50);
        }
        set{
            _regionNacimto = value;
        }
    }
    public System.String Discapacidad
    {
        get
        {
            return ajustarAncho(_Discapacidad, 50);
        }
        set
        {
            _Discapacidad = value;
        }
    }
    public System.Decimal PorcentajeDiscapacidad
    {
        get
        {
            return _PorcentajeDiscapacidad;
        }
        set
        {
            _PorcentajeDiscapacidad = value;
        }
    }

    //
    // La cadena de conexión a la base de datos
    private static string cadenaConexion = @"";
    // La cadena de selección
    public static string CadenaSelect = "SELECT * FROM Personal";
    //
    public dbPersonal(){
    }
    public dbPersonal(string conex){
        cadenaConexion = conex;
    }
    //
    // Métodos compartidos (estáticos) privados
    //
    // asigna una fila de la tabla a un objeto Personal
    private static dbPersonal row2Personal(DataRow r){
        // asigna a un objeto Personal los datos del dataRow indicado
        dbPersonal oPersonal = new dbPersonal();
        //
        oPersonal.CodigoPer = r["CodigoPer"].ToString();
        oPersonal.AsociadoAEmpresa = System.Int32.Parse("0" + r["AsociadoAEmpresa"].ToString());
        //try{
        //    oPersonal.FechaNacimiento = DateTime.Parse(r["FechaNacimiento"].ToString());
        //}catch{
        //    oPersonal.FechaNacimiento = new DateTime(1900, 1, 1);
        //}
        object valor = r["FechaNacimiento"];

        if (valor != DBNull.Value && DateTime.TryParse(valor.ToString(), out DateTime fechaNac))
        {
            oPersonal.FechaNacimiento = fechaNac;
        }
        else
        {
            oPersonal.FechaNacimiento = new DateTime(1900, 1, 1);
        }

        oPersonal.LugarNacimiento = r["LugarNacimiento"].ToString();
        oPersonal.Sexo = r["Sexo"].ToString();
        oPersonal.EstadoCivil = r["EstadoCivil"].ToString();
        oPersonal.Nacionalidad = r["Nacionalidad"].ToString();
        oPersonal.Hobbys = r["Hobbys"].ToString();
        oPersonal.Profesión = r["Profesión"].ToString();
        oPersonal.Referirsecomo = r["Referirsecomo"].ToString();
        oPersonal.Especialidad = r["Especialidad"].ToString();
        oPersonal.Especialidad2 = r["Especialidad2"].ToString();
        oPersonal.TipoSangre = r["TipoSangre"].ToString();
        oPersonal.DirecciónTrabajo = r["DirecciónTrabajo"].ToString();
        oPersonal.codigotarjrta = r["codigotarjrta"].ToString();
        oPersonal.numerotarjrta = r["numerotarjrta"].ToString();
        oPersonal.paisNacimto = r["paisNacimto"].ToString();
        oPersonal.ciudadNacimto = r["ciudadNacimto"].ToString();
        oPersonal.provNacimto = r["provNacimto"].ToString();
        oPersonal.regionNacimto = r["regionNacimto"].ToString();
        oPersonal.Discapacidad = r["Discapacidad"].ToString();
        oPersonal.PorcentajeDiscapacidad = System.Decimal.Parse("0"+r["PorcentajeDiscapacidad"]);
        //
        return oPersonal;
    }
    //
    // asigna un objeto Personal a la fila indicada
    private static void Personal2Row(dbPersonal oPersonal, DataRow r){
        // asigna un objeto Personal al dataRow indicado
        r["CodigoPer"] = oPersonal.CodigoPer;
        r["AsociadoAEmpresa"] = oPersonal.AsociadoAEmpresa;
        r["FechaNacimiento"] = oPersonal.FechaNacimiento;
        r["LugarNacimiento"] = oPersonal.LugarNacimiento;
        r["Sexo"] = oPersonal.Sexo;
        r["EstadoCivil"] = oPersonal.EstadoCivil;
        r["Nacionalidad"] = oPersonal.Nacionalidad;
        r["Hobbys"] = oPersonal.Hobbys;
        r["Profesión"] = oPersonal.Profesión;
        r["Referirsecomo"] = oPersonal.Referirsecomo;
        r["Especialidad"] = oPersonal.Especialidad;
        r["Especialidad2"] = oPersonal.Especialidad2;
        r["TipoSangre"] = oPersonal.TipoSangre;
        r["DirecciónTrabajo"] = oPersonal.DirecciónTrabajo;
        r["codigotarjrta"] = oPersonal.codigotarjrta;
        r["numerotarjrta"] = oPersonal.numerotarjrta;
        r["paisNacimto"] = oPersonal.paisNacimto;
        r["ciudadNacimto"] = oPersonal.ciudadNacimto;
        r["provNacimto"] = oPersonal.provNacimto;
        r["regionNacimto"] = oPersonal.regionNacimto;
        r["Discapacidad"] = oPersonal.Discapacidad;
        r["PorcentajeDiscapacidad"] = oPersonal.PorcentajeDiscapacidad;
    
    }
    //
    // crea una nueva fila y la asigna a un objeto Personal
    private static void nuevoPersonal(DataTable dt, dbPersonal oPersonal){
        // Crear un nuevo Personal
        DataRow dr = dt.NewRow();
        dbPersonal oP = row2Personal(dr);
        //
        oP.CodigoPer = oPersonal.CodigoPer;
        oP.AsociadoAEmpresa = oPersonal.AsociadoAEmpresa;
        oP.FechaNacimiento = oPersonal.FechaNacimiento;
        oP.LugarNacimiento = oPersonal.LugarNacimiento;
        oP.Sexo = oPersonal.Sexo;
        oP.EstadoCivil = oPersonal.EstadoCivil;
        oP.Nacionalidad = oPersonal.Nacionalidad;
        oP.Hobbys = oPersonal.Hobbys;
        oP.Profesión = oPersonal.Profesión;
        oP.Referirsecomo = oPersonal.Referirsecomo;
        oP.Especialidad = oPersonal.Especialidad;
        oP.Especialidad2 = oPersonal.Especialidad2;
        oP.TipoSangre = oPersonal.TipoSangre;
        oP.DirecciónTrabajo = oPersonal.DirecciónTrabajo;
        oP.codigotarjrta = oPersonal.codigotarjrta;
        oP.numerotarjrta = oPersonal.numerotarjrta;
        oP.paisNacimto = oPersonal.paisNacimto;
        oP.ciudadNacimto = oPersonal.ciudadNacimto;
        oP.provNacimto = oPersonal.provNacimto;
        oP.regionNacimto = oPersonal.regionNacimto;
        oP.Discapacidad = oPersonal.Discapacidad;
        oP.PorcentajeDiscapacidad = oPersonal.PorcentajeDiscapacidad;
        //
        Personal2Row(oP, dr);
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
        // devuelve una tabla con los datos de la tabla Personal
        SqlDataAdapter da;
        DataTable dt = new DataTable("Personal");
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
    public static dbPersonal Buscar(string sWhere){
        // Busca en la tabla los datos indicados en el parámetro
        // el parámetro contendrá lo que se usará después del WHERE
        dbPersonal oPersonal = null;
        SqlDataAdapter da;
        DataTable dt = new DataTable("Personal");
        string sel = "SELECT * FROM Personal WHERE " + sWhere;
        //
        da = new SqlDataAdapter(sel, cadenaConexion);
        da.Fill(dt);
        //
        if(dt.Rows.Count > 0){
            oPersonal = row2Personal(dt.Rows[0]);
        }
        return oPersonal;
    }
    //
    public string Actualizar(){
        string sel = "SELECT * FROM Personal WHERE CodigoPer = '" + this.CodigoPer + "'";
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
        DataTable dt = new DataTable("Personal");
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
            Personal2Row(this, dt.Rows[0]);
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
        DataTable dt = new DataTable("Personal");
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
        nuevoPersonal(dt, this);
        //
        try{
            da.Update(dt);
            dt.AcceptChanges();
            return "Se ha creado un nuevo Personal";
        }catch(Exception ex){
            return "ERROR: " + ex.Message;
        }
    }
    //
    public string Borrar(){
        string sel = "SELECT * FROM Personal WHERE CodigoPer = '" + this.CodigoPer + "'";
        //
        return Borrar(sel);
    }
    public string Borrar(string sel){
        // Borrar el registro al que apunta esta clase
        // En caso de error, devolverá la cadena de error empezando por ERROR:.
        SqlConnection cnn;
        SqlDataAdapter da;
        DataTable dt = new DataTable("Personal");
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
