//------------------------------------------------------------------------------
// Clase Exportacion generada automáticamente con CrearClaseSQL
// de la tabla 'Exportacion' de la base 'IVARETDAX'
// Fecha: 07/nov/2016 14:03:37
//
//------------------------------------------------------------------------------
using System;
using System.Data;
using System.Data.SqlClient;
//, '01' as tipoRegi
//, isnull((select país from identificacion where codigo = clienteConsig),'') as paisEfecPagoGen
//, '' as paisEfecPagoParFi
//, 'NO' as pagoRegFis

public class Exportacion
{
    // Las variables privadas
    // TODO: Revisar los tipos de los campos
    private System.String _CL_ExportaciónDe="";
    private System.String _Cl_TipoComprobante="";
    private System.String _CL_ReferendoDistrito="";
    private System.String _CL_ReferendoAño="";
    private System.String _CL_ReferendoRegimen="";
    private System.String _CL_ReferendoCorrelativo="";
    private System.String _CL_ReferendoVerificador="";
    private System.String _CL_NroDocTransporte="";
    private System.DateTime _CL_FechaTransaccion =  new DateTime(1900,01,01);
    private System.String _CL_NroFUE="";
    private System.Decimal _CL_ValorFOB=0;
    private System.Decimal _CL_ValorComprobante=0;
    private System.String _CL_NroSerieCpbteEstablec="";
    private System.String _CL_NroSerieCpbteEmision="";
    private System.String _CL_NroSecuencialCpbte="";
    private System.String _CL_NroAutorizacion="";
    private System.DateTime _CL_FechaEmision = new DateTime(1900, 01, 01);
    private System.Decimal _Clave=0;
    private System.Int32 _CL_mes=0;
    private System.Int32 _CL_anio=0;
    private System.String _suc="";
    private System.String _doc="";
    private System.Decimal _idclavedoc=0;
    private System.String _tpIdClienteEx="";
    private System.String _idClienteEx="";
    private System.String _parteRel="";
    private System.String _paisEfecExp="";
    private System.String _tipoCli="";
    private System.String _paisEfecPagoGen="";
    private System.String _denopagoRegFis="";
    private System.String _denoExpCli="";
    private System.String _tipoRegi="";
    private System.String _paisEfecPagoParFi="";
    private System.String _pagoRegFis="";
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
    public System.String CL_ExportaciónDe
    {
        get
        {
            return ajustarAncho(_CL_ExportaciónDe, 50);
        }
        set
        {
            _CL_ExportaciónDe = value;
        }
    }
    public System.String Cl_TipoComprobante
    {
        get
        {
            return ajustarAncho(_Cl_TipoComprobante, 50);
        }
        set
        {
            _Cl_TipoComprobante = value;
        }
    }
    public System.String CL_ReferendoDistrito
    {
        get
        {
            return ajustarAncho(_CL_ReferendoDistrito, 50);
        }
        set
        {
            _CL_ReferendoDistrito = value;
        }
    }
    public System.String CL_ReferendoAño
    {
        get
        {
            return ajustarAncho(_CL_ReferendoAño, 50);
        }
        set
        {
            _CL_ReferendoAño = value;
        }
    }
    public System.String CL_ReferendoRegimen
    {
        get
        {
            return ajustarAncho(_CL_ReferendoRegimen, 50);
        }
        set
        {
            _CL_ReferendoRegimen = value;
        }
    }
    public System.String CL_ReferendoCorrelativo
    {
        get
        {
            return ajustarAncho(_CL_ReferendoCorrelativo, 50);
        }
        set
        {
            _CL_ReferendoCorrelativo = value;
        }
    }
    public System.String CL_ReferendoVerificador
    {
        get
        {
            return ajustarAncho(_CL_ReferendoVerificador, 50);
        }
        set
        {
            _CL_ReferendoVerificador = value;
        }
    }
    public System.String CL_NroDocTransporte
    {
        get
        {
            return ajustarAncho(_CL_NroDocTransporte, 50);
        }
        set
        {
            _CL_NroDocTransporte = value;
        }
    }
    public System.DateTime CL_FechaTransaccion
    {
        get
        {
            return _CL_FechaTransaccion;
        }
        set
        {
            _CL_FechaTransaccion = value;
        }
    }
    public System.String CL_NroFUE
    {
        get
        {
            return ajustarAncho(_CL_NroFUE, 50);
        }
        set
        {
            _CL_NroFUE = value;
        }
    }
    public System.Decimal CL_ValorFOB
    {
        get
        {
            return _CL_ValorFOB;
        }
        set
        {
            _CL_ValorFOB = value;
        }
    }
    public System.Decimal CL_ValorComprobante
    {
        get
        {
            return _CL_ValorComprobante;
        }
        set
        {
            _CL_ValorComprobante = value;
        }
    }
    public System.String CL_NroSerieCpbteEstablec
    {
        get
        {
            return ajustarAncho(_CL_NroSerieCpbteEstablec, 50);
        }
        set
        {
            _CL_NroSerieCpbteEstablec = value;
        }
    }
    public System.String CL_NroSerieCpbteEmision
    {
        get
        {
            return ajustarAncho(_CL_NroSerieCpbteEmision, 50);
        }
        set
        {
            _CL_NroSerieCpbteEmision = value;
        }
    }
    public System.String CL_NroSecuencialCpbte
    {
        get
        {
            return ajustarAncho(_CL_NroSecuencialCpbte, 50);
        }
        set
        {
            _CL_NroSecuencialCpbte = value;
        }
    }
    public System.String CL_NroAutorizacion
    {
        get
        {
            return ajustarAncho(_CL_NroAutorizacion, 50);
        }
        set
        {
            _CL_NroAutorizacion = value;
        }
    }
    public System.DateTime CL_FechaEmision
    {
        get
        {
            return _CL_FechaEmision;
        }
        set
        {
            _CL_FechaEmision = value;
        }
    }
    public System.Decimal Clave
    {
        get
        {
            return _Clave;
        }
        set
        {
            _Clave = value;
        }
    }
    public System.Int32 CL_mes
    {
        get
        {
            return _CL_mes;
        }
        set
        {
            _CL_mes = value;
        }
    }
    public System.Int32 CL_anio
    {
        get
        {
            return _CL_anio;
        }
        set
        {
            _CL_anio = value;
        }
    }
    public System.String suc
    {
        get
        {
            return ajustarAncho(_suc, 3);
        }
        set
        {
            _suc = value;
        }
    }
    public System.String doc
    {
        get
        {
            return ajustarAncho(_doc, 3);
        }
        set
        {
            _doc = value;
        }
    }
    public System.Decimal idclavedoc
    {
        get
        {
            return _idclavedoc;
        }
        set
        {
            _idclavedoc = value;
        }
    }
    public System.String tpIdClienteEx
    {
        get
        {
            return ajustarAncho(_tpIdClienteEx, 3);
        }
        set
        {
            _tpIdClienteEx = value;
        }
    }
    public System.String idClienteEx
    {
        get
        {
            return ajustarAncho(_idClienteEx, 13);
        }
        set
        {
            _idClienteEx = value;
        }
    }
    public System.String parteRel
    {
        get
        {
            return ajustarAncho(_parteRel, 2);
        }
        set
        {
            _parteRel = value;
        }
    }
    public System.String paisEfecExp
    {
        get
        {
            return ajustarAncho(_paisEfecExp, 4);
        }
        set
        {
            _paisEfecExp = value;
        }
    }
    public System.String tipoCli
    {
        get
        {
            return ajustarAncho(_tipoCli, 3);
        }
        set
        {
            _tipoCli = value;
        }
    }
    public System.String paisEfecPagoGen
    {
        get
        {
            return ajustarAncho(_paisEfecPagoGen, 5);
        }
        set
        {
            _paisEfecPagoGen = value;
        }
    }
    public System.String denopagoRegFis
    {
        get
        {
            // Seguramente sería mejor sin ajustar el ancho...
            //return ajustarAncho(_denopagoRegFis,350);
            return _denopagoRegFis;
        }
        set
        {
            _denopagoRegFis = value;
        }
    }
    public System.String denoExpCli
    {
        get
        {
            // Seguramente sería mejor sin ajustar el ancho...
            //return ajustarAncho(_denoExpCli,350);
            return _denoExpCli;
        }
        set
        {
            _denoExpCli = value;
        }
    }
    public System.String tipoRegi
    {
        get
        {
            return ajustarAncho(_tipoRegi, 3);
        }
        set
        {
            _tipoRegi = value;
        }
    }
    public System.String paisEfecPagoParFi
    {
        get
        {
            return ajustarAncho(_paisEfecPagoParFi, 4);
        }
        set
        {
            _paisEfecPagoParFi = value;
        }
    }
    public System.String pagoRegFis
    {
        get
        {
            return ajustarAncho(_pagoRegFis, 4);
        }
        set
        {
            _pagoRegFis = value;
        }
    }
    //pagoRegFis
    // Campos y métodos compartidos (estáticos) para gestionar la base de datos
    //
    // La cadena de conexión a la base de datos
    private static string cadenaConexion = @"";
    // La cadena de selección
    public static string CadenaSelect = "";
    //
    public Exportacion()
    {
    }
    public Exportacion(string conex)
    {
        cadenaConexion = conex;
    }
    //
    // Métodos compartidos (estáticos) privados
    //
    // asigna una fila de la tabla a un objeto Exportacion
    private static Exportacion row2Exportacion(DataRow r)
    {
        // asigna a un objeto Exportacion los datos del dataRow indicado
        Exportacion oExportacion = new Exportacion();
        //
        oExportacion.CL_ExportaciónDe = r["CL_ExportaciónDe"].ToString();
        oExportacion.Cl_TipoComprobante = r["Cl_TipoComprobante"].ToString();
        oExportacion.CL_ReferendoDistrito = r["CL_ReferendoDistrito"].ToString();
        oExportacion.CL_ReferendoAño = r["CL_ReferendoAño"].ToString();
        oExportacion.CL_ReferendoRegimen = r["CL_ReferendoRegimen"].ToString();
        oExportacion.CL_ReferendoCorrelativo = r["CL_ReferendoCorrelativo"].ToString();
        oExportacion.CL_ReferendoVerificador = r["CL_ReferendoVerificador"].ToString();
        oExportacion.CL_NroDocTransporte = r["CL_NroDocTransporte"].ToString();
        try
        {
            oExportacion.CL_FechaTransaccion = DateTime.Parse(r["CL_FechaTransaccion"].ToString());
        }
        catch
        {
            // TODO: Usa el valor de fecha que quieras predeterminar
            //       Una fecha ficticia:
            //oExportacion.CL_FechaTransaccion = new DateTime(1900, 1, 1);
            //       o la fecha de hoy:
            oExportacion.CL_FechaTransaccion = DateTime.Now;
        }
        oExportacion.CL_NroFUE = r["CL_NroFUE"].ToString();
        oExportacion.CL_ValorFOB = System.Decimal.Parse("0" + r["CL_ValorFOB"].ToString());
        oExportacion.CL_ValorComprobante = System.Decimal.Parse("0" + r["CL_ValorComprobante"].ToString());
        oExportacion.CL_NroSerieCpbteEstablec = r["CL_NroSerieCpbteEstablec"].ToString();
        oExportacion.CL_NroSerieCpbteEmision = r["CL_NroSerieCpbteEmision"].ToString();
        oExportacion.CL_NroSecuencialCpbte = r["CL_NroSecuencialCpbte"].ToString();
        oExportacion.CL_NroAutorizacion = r["CL_NroAutorizacion"].ToString();
        try
        {
            oExportacion.CL_FechaEmision = DateTime.Parse(r["CL_FechaEmision"].ToString());
        }
        catch
        {
            // TODO: Usa el valor de fecha que quieras predeterminar
            //       Una fecha ficticia:
            //oExportacion.CL_FechaEmision = new DateTime(1900, 1, 1);
            //       o la fecha de hoy:
            oExportacion.CL_FechaEmision = DateTime.Now;
        }
        oExportacion.Clave = System.Decimal.Parse("0" + r["Clave"].ToString());
        oExportacion.CL_mes = System.Int32.Parse("0" + r["CL_mes"].ToString());
        oExportacion.CL_anio = System.Int32.Parse("0" + r["CL_anio"].ToString());
        oExportacion.suc = r["suc"].ToString();
        oExportacion.doc = r["doc"].ToString();
        oExportacion.idclavedoc = System.Decimal.Parse("0" + r["idclavedoc"].ToString());
        oExportacion.tpIdClienteEx = r["tpIdClienteEx"].ToString();
        oExportacion.idClienteEx = r["idClienteEx"].ToString();
        oExportacion.parteRel = r["parteRel"].ToString();
        oExportacion.paisEfecExp = r["paisEfecExp"].ToString();
        oExportacion.tipoCli = r["tipoCli"].ToString();
        oExportacion.paisEfecPagoGen = r["paisEfecPagoGen"].ToString();
        oExportacion.denopagoRegFis = r["denopagoRegFis"].ToString();
        oExportacion.denoExpCli = r["denoExpCli"].ToString();
        oExportacion.tipoRegi = r["tipoRegi"].ToString();
        oExportacion.paisEfecPagoParFi = r["paisEfecPagoParFi"].ToString();
        oExportacion.pagoRegFis = r["pagoRegFis"].ToString();
        //pagoRegFis
        return oExportacion;
    }
    //
    // asigna un objeto Exportacion a la fila indicada
    private static void Exportacion2Row(Exportacion oExportacion, DataRow r)
    {
        // asigna un objeto Exportacion al dataRow indicado
        r["CL_ExportaciónDe"] = oExportacion.CL_ExportaciónDe;
        r["Cl_TipoComprobante"] = oExportacion.Cl_TipoComprobante;
        r["CL_ReferendoDistrito"] = oExportacion.CL_ReferendoDistrito;
        r["CL_ReferendoAño"] = oExportacion.CL_ReferendoAño;
        r["CL_ReferendoRegimen"] = oExportacion.CL_ReferendoRegimen;
        r["CL_ReferendoCorrelativo"] = oExportacion.CL_ReferendoCorrelativo;
        r["CL_ReferendoVerificador"] = oExportacion.CL_ReferendoVerificador;
        r["CL_NroDocTransporte"] = oExportacion.CL_NroDocTransporte;
        r["CL_FechaTransaccion"] = oExportacion.CL_FechaTransaccion;
        r["CL_NroFUE"] = oExportacion.CL_NroFUE;
        r["CL_ValorFOB"] = oExportacion.CL_ValorFOB;
        r["CL_ValorComprobante"] = oExportacion.CL_ValorComprobante;
        r["CL_NroSerieCpbteEstablec"] = oExportacion.CL_NroSerieCpbteEstablec;
        r["CL_NroSerieCpbteEmision"] = oExportacion.CL_NroSerieCpbteEmision;
        r["CL_NroSecuencialCpbte"] = oExportacion.CL_NroSecuencialCpbte;
        r["CL_NroAutorizacion"] = oExportacion.CL_NroAutorizacion;
        r["CL_FechaEmision"] = oExportacion.CL_FechaEmision;
        // TODO: Comprueba si esta asignación debe hacerse
        //       pero mejor lo dejas comentado ya que es un campo autoincremental o único
        //r["Clave"] = oExportacion.Clave;
        r["CL_mes"] = oExportacion.CL_mes;
        r["CL_anio"] = oExportacion.CL_anio;
        r["suc"] = oExportacion.suc;
        r["doc"] = oExportacion.doc;
        r["idclavedoc"] = oExportacion.idclavedoc;
        r["tpIdClienteEx"] = oExportacion.tpIdClienteEx;
        r["idClienteEx"] = oExportacion.idClienteEx;
        r["parteRel"] = oExportacion.parteRel;
        r["paisEfecExp"] = oExportacion.paisEfecExp;
        r["tipoCli"] = oExportacion.tipoCli;
        r["paisEfecPagoGen"] = oExportacion.paisEfecPagoGen;
        r["denopagoRegFis"] = oExportacion.denopagoRegFis;
        r["denoExpCli"] = oExportacion.denoExpCli;
        r["tipoRegi"] = oExportacion.tipoRegi;
        r["paisEfecPagoParFi"] = oExportacion.paisEfecPagoParFi;
        r["pagoRegFis"] = oExportacion.pagoRegFis;
    }
    //
    // crea una nueva fila y la asigna a un objeto Exportacion
    private static void nuevoExportacion(DataTable dt, Exportacion oExportacion)
    {
        // Crear un nuevo Exportacion
        DataRow dr = dt.NewRow();
        Exportacion oE = row2Exportacion(dr);
        //
        oE.CL_ExportaciónDe = oExportacion.CL_ExportaciónDe;
        oE.Cl_TipoComprobante = oExportacion.Cl_TipoComprobante;
        oE.CL_ReferendoDistrito = oExportacion.CL_ReferendoDistrito;
        oE.CL_ReferendoAño = oExportacion.CL_ReferendoAño;
        oE.CL_ReferendoRegimen = oExportacion.CL_ReferendoRegimen;
        oE.CL_ReferendoCorrelativo = oExportacion.CL_ReferendoCorrelativo;
        oE.CL_ReferendoVerificador = oExportacion.CL_ReferendoVerificador;
        oE.CL_NroDocTransporte = oExportacion.CL_NroDocTransporte;
        oE.CL_FechaTransaccion = oExportacion.CL_FechaTransaccion;
        oE.CL_NroFUE = oExportacion.CL_NroFUE;
        oE.CL_ValorFOB = oExportacion.CL_ValorFOB;
        oE.CL_ValorComprobante = oExportacion.CL_ValorComprobante;
        oE.CL_NroSerieCpbteEstablec = oExportacion.CL_NroSerieCpbteEstablec;
        oE.CL_NroSerieCpbteEmision = oExportacion.CL_NroSerieCpbteEmision;
        oE.CL_NroSecuencialCpbte = oExportacion.CL_NroSecuencialCpbte;
        oE.CL_NroAutorizacion = oExportacion.CL_NroAutorizacion;
        oE.CL_FechaEmision = oExportacion.CL_FechaEmision;
        oE.Clave = oExportacion.Clave;
        oE.CL_mes = oExportacion.CL_mes;
        oE.CL_anio = oExportacion.CL_anio;
        oE.suc = oExportacion.suc;
        oE.doc = oExportacion.doc;
        oE.idclavedoc = oExportacion.idclavedoc;
        oE.tpIdClienteEx = oExportacion.tpIdClienteEx;
        oE.idClienteEx = oExportacion.idClienteEx;
        oE.parteRel = oExportacion.parteRel;
        oE.paisEfecExp = oExportacion.paisEfecExp;
        oE.tipoCli = oExportacion.tipoCli;
        oE.paisEfecPagoGen = oExportacion.paisEfecPagoGen;
        oE.denopagoRegFis = oExportacion.denopagoRegFis;
        oE.pagoRegFis = oExportacion.pagoRegFis;
        oE.denoExpCli = oExportacion.denoExpCli;
        oE.tipoRegi = oExportacion.tipoRegi;
        oE.paisEfecPagoParFi = oExportacion.paisEfecPagoParFi;
        //pagoRegFis
        Exportacion2Row(oE, dr);
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
        // devuelve una tabla con los datos de la tabla Exportacion
        SqlDataAdapter da;
        DataTable dt = new DataTable("Exportacion");
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
    public static Exportacion Buscar(string sWhere)
    {
        // Busca en la tabla los datos indicados en el parámetro
        // el parámetro contendrá lo que se usará después del WHERE
        Exportacion oExportacion = null;
        SqlDataAdapter da;
        DataTable dt = new DataTable("Exportacion");
        string sel = "SELECT * FROM Exportacion WHERE " + sWhere;
        //
        da = new SqlDataAdapter(sel, cadenaConexion);
        da.Fill(dt);
        //
        if (dt.Rows.Count > 0)
        {
            oExportacion = row2Exportacion(dt.Rows[0]);
        }
        return oExportacion;
    }
    //
    // Actualizar: Actualiza los datos en la tabla usando la instancia actual
    //             Si la instancia no hace referencia a un registro existente, se creará uno nuevo
    //             Para comprobar si el objeto en memoria coincide con uno existente,
    //             se comprueba si el Clave existe en la tabla.
    //             TODO: Si en lugar de Clave usas otro campo, indicalo en la cadena SELECT
    //                   También puedes usar la sobrecarga en la que se indica la cadena SELECT a usar
    public string Actualizar()
    {
        // TODO: Poner aquí la selección a realizar para acceder a este registro
        //       yo uso el Clave que es el identificador único de cada registro
        string sel = "SELECT * FROM Exportacion WHERE Clave = " + this.Clave.ToString();
        return Actualizar(sel);
    }
    public string Actualizar(string sel)
    {
        // Actualiza los datos indicados
        // El parámetro, que es una cadena de selección, indicará el criterio de actualización
        //
        // En caso de error, devolverá la cadena empezando por ERROR.
        SqlConnection cnn;
        SqlDataAdapter da;
        DataTable dt = new DataTable("Exportacion");
        //
        cnn = new SqlConnection(cadenaConexion);
        //da = new SqlDataAdapter(CadenaSelect, cnn);
        da = new SqlDataAdapter(sel, cnn);
        da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
        //
        //-------------------------------------------
        // Esta no es la más óptima, pero funcionará
        //-------------------------------------------
        SqlCommandBuilder cb = new SqlCommandBuilder(da);
        da.UpdateCommand = cb.GetUpdateCommand();
        //
        //--------------------------------------------------------------------
        // Esta está más optimizada pero debes comprobar que funciona bien...
        //--------------------------------------------------------------------
        //string sCommand;
        ////
        //// El comando UPDATE
        //// TODO: Comprobar cual es el campo de índice principal (sin duplicados)
        ////       Yo compruebo que sea un campo llamado Clave, pero en tu caso puede ser otro
        ////       Ese campo, (en mi caso Clave) será el que hay que poner al final junto al WHERE.
        //sCommand = "UPDATE Exportacion SET CL_ExportaciónDe = @CL_ExportaciónDe, Cl_TipoComprobante = @Cl_TipoComprobante, CL_ReferendoDistrito = @CL_ReferendoDistrito, CL_ReferendoAño = @CL_ReferendoAño, CL_ReferendoRegimen = @CL_ReferendoRegimen, CL_ReferendoCorrelativo = @CL_ReferendoCorrelativo, CL_ReferendoVerificador = @CL_ReferendoVerificador, CL_NroDocTransporte = @CL_NroDocTransporte, CL_FechaTransaccion = @CL_FechaTransaccion, CL_NroFUE = @CL_NroFUE, CL_ValorFOB = @CL_ValorFOB, CL_ValorComprobante = @CL_ValorComprobante, CL_NroSerieCpbteEstablec = @CL_NroSerieCpbteEstablec, CL_NroSerieCpbteEmision = @CL_NroSerieCpbteEmision, CL_NroSecuencialCpbte = @CL_NroSecuencialCpbte, CL_NroAutorizacion = @CL_NroAutorizacion, CL_FechaEmision = @CL_FechaEmision, CL_mes = @CL_mes, CL_anio = @CL_anio, suc = @suc, doc = @doc, idclavedoc = @idclavedoc, tpIdClienteEx = @tpIdClienteEx, idClienteEx = @idClienteEx, parteRel = @parteRel, paisEfecExp = @paisEfecExp, tipoCli = @tipoCli, paisEfecPagoGen = @paisEfecPagoGen, denopagoRegFis = @denopagoRegFis, denoExpCli = @denoExpCli, tipoRegi = @tipoRegi, paisEfecPagoParFi = @paisEfecPagoParFi  WHERE (Clave = @Clave)";
        //da.UpdateCommand = new SqlCommand(sCommand, cnn);
        //da.UpdateCommand.Parameters.Add("@CL_ExportaciónDe", SqlDbType.NVarChar, 50, "CL_ExportaciónDe");
        //da.UpdateCommand.Parameters.Add("@Cl_TipoComprobante", SqlDbType.NVarChar, 50, "Cl_TipoComprobante");
        //da.UpdateCommand.Parameters.Add("@CL_ReferendoDistrito", SqlDbType.NVarChar, 50, "CL_ReferendoDistrito");
        //da.UpdateCommand.Parameters.Add("@CL_ReferendoAño", SqlDbType.NVarChar, 50, "CL_ReferendoAño");
        //da.UpdateCommand.Parameters.Add("@CL_ReferendoRegimen", SqlDbType.NVarChar, 50, "CL_ReferendoRegimen");
        //da.UpdateCommand.Parameters.Add("@CL_ReferendoCorrelativo", SqlDbType.NVarChar, 50, "CL_ReferendoCorrelativo");
        //da.UpdateCommand.Parameters.Add("@CL_ReferendoVerificador", SqlDbType.NVarChar, 50, "CL_ReferendoVerificador");
        //da.UpdateCommand.Parameters.Add("@CL_NroDocTransporte", SqlDbType.NVarChar, 50, "CL_NroDocTransporte");
        //// TODO: Comprobar el tipo de datos a usar...
        //da.UpdateCommand.Parameters.Add("@CL_FechaTransaccion", SqlDbType.DateTime, 0, "CL_FechaTransaccion");
        //da.UpdateCommand.Parameters.Add("@CL_NroFUE", SqlDbType.NVarChar, 50, "CL_NroFUE");
        //// TODO: Comprobar el tipo de datos a usar...
        //da.UpdateCommand.Parameters.Add("@CL_ValorFOB", SqlDbType.Decimal, 0, "CL_ValorFOB");
        //// TODO: Comprobar el tipo de datos a usar...
        //da.UpdateCommand.Parameters.Add("@CL_ValorComprobante", SqlDbType.Decimal, 0, "CL_ValorComprobante");
        //da.UpdateCommand.Parameters.Add("@CL_NroSerieCpbteEstablec", SqlDbType.NVarChar, 50, "CL_NroSerieCpbteEstablec");
        //da.UpdateCommand.Parameters.Add("@CL_NroSerieCpbteEmision", SqlDbType.NVarChar, 50, "CL_NroSerieCpbteEmision");
        //da.UpdateCommand.Parameters.Add("@CL_NroSecuencialCpbte", SqlDbType.NVarChar, 50, "CL_NroSecuencialCpbte");
        //da.UpdateCommand.Parameters.Add("@CL_NroAutorizacion", SqlDbType.NVarChar, 50, "CL_NroAutorizacion");
        //// TODO: Comprobar el tipo de datos a usar...
        //da.UpdateCommand.Parameters.Add("@CL_FechaEmision", SqlDbType.DateTime, 0, "CL_FechaEmision");
        //// TODO: Comprobar el tipo de datos a usar...
        //da.UpdateCommand.Parameters.Add("@Clave", SqlDbType.Decimal, 0, "Clave");
        //// TODO: Comprobar el tipo de datos a usar...
        //da.UpdateCommand.Parameters.Add("@CL_mes", SqlDbType.Int, 0, "CL_mes");
        //// TODO: Comprobar el tipo de datos a usar...
        //da.UpdateCommand.Parameters.Add("@CL_anio", SqlDbType.Int, 0, "CL_anio");
        //da.UpdateCommand.Parameters.Add("@suc", SqlDbType.NVarChar, 3, "suc");
        //da.UpdateCommand.Parameters.Add("@doc", SqlDbType.NVarChar, 3, "doc");
        //// TODO: Comprobar el tipo de datos a usar...
        //da.UpdateCommand.Parameters.Add("@idclavedoc", SqlDbType.Decimal, 0, "idclavedoc");
        //da.UpdateCommand.Parameters.Add("@tpIdClienteEx", SqlDbType.NVarChar, 3, "tpIdClienteEx");
        //da.UpdateCommand.Parameters.Add("@idClienteEx", SqlDbType.NVarChar, 13, "idClienteEx");
        //da.UpdateCommand.Parameters.Add("@parteRel", SqlDbType.NVarChar, 2, "parteRel");
        //da.UpdateCommand.Parameters.Add("@paisEfecExp", SqlDbType.NVarChar, 4, "paisEfecExp");
        //da.UpdateCommand.Parameters.Add("@tipoCli", SqlDbType.NVarChar, 3, "tipoCli");
        //da.UpdateCommand.Parameters.Add("@paisEfecPagoGen", SqlDbType.NVarChar, 5, "paisEfecPagoGen");
        //// TODO: Este campo seguramente es MEMO y el valor debería ser cero en lugar de 350
        ////da.UpdateCommand.Parameters.Add("@denopagoRegFis", SqlDbType.NText, 350, "denopagoRegFis");
        //da.UpdateCommand.Parameters.Add("@denopagoRegFis", SqlDbType.NText, 0, "denopagoRegFis");
        //// TODO: Este campo seguramente es MEMO y el valor debería ser cero en lugar de 350
        ////da.UpdateCommand.Parameters.Add("@denoExpCli", SqlDbType.NText, 350, "denoExpCli");
        //da.UpdateCommand.Parameters.Add("@denoExpCli", SqlDbType.NText, 0, "denoExpCli");
        //da.UpdateCommand.Parameters.Add("@tipoRegi", SqlDbType.NVarChar, 3, "tipoRegi");
        //da.UpdateCommand.Parameters.Add("@paisEfecPagoParFi", SqlDbType.NVarChar, 4, "paisEfecPagoParFi");
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
            Exportacion2Row(this, dt.Rows[0]);
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
        DataTable dt = new DataTable("Exportacion");
        //
        cnn = new SqlConnection(cadenaConexion);
        da = new SqlDataAdapter(CadenaSelect, cnn);
        //da = new SqlDataAdapter(CadenaSelect, cadenaConexion);
        da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
        //
        //-------------------------------------------
        // Esta no es la más óptima, pero funcionará
        //-------------------------------------------
        SqlCommandBuilder cb = new SqlCommandBuilder(da);
        da.InsertCommand = cb.GetInsertCommand();
        //
        //--------------------------------------------------------------------
        // Esta está más optimizada pero debes comprobar que funciona bien...
        //--------------------------------------------------------------------
        //string sCommand;
        ////
        //// El comando INSERT
        //// TODO: No incluir el campo de clave primaria incremental
        ////       Yo compruebo que sea un campo llamado Clave, pero en tu caso puede ser otro
        //sCommand = "INSERT INTO Exportacion (CL_ExportaciónDe, Cl_TipoComprobante, CL_ReferendoDistrito, CL_ReferendoAño, CL_ReferendoRegimen, CL_ReferendoCorrelativo, CL_ReferendoVerificador, CL_NroDocTransporte, CL_FechaTransaccion, CL_NroFUE, CL_ValorFOB, CL_ValorComprobante, CL_NroSerieCpbteEstablec, CL_NroSerieCpbteEmision, CL_NroSecuencialCpbte, CL_NroAutorizacion, CL_FechaEmision, CL_mes, CL_anio, suc, doc, idclavedoc, tpIdClienteEx, idClienteEx, parteRel, paisEfecExp, tipoCli, paisEfecPagoGen, denopagoRegFis, denoExpCli, tipoRegi, paisEfecPagoParFi)  VALUES(@CL_ExportaciónDe, @Cl_TipoComprobante, @CL_ReferendoDistrito, @CL_ReferendoAño, @CL_ReferendoRegimen, @CL_ReferendoCorrelativo, @CL_ReferendoVerificador, @CL_NroDocTransporte, @CL_FechaTransaccion, @CL_NroFUE, @CL_ValorFOB, @CL_ValorComprobante, @CL_NroSerieCpbteEstablec, @CL_NroSerieCpbteEmision, @CL_NroSecuencialCpbte, @CL_NroAutorizacion, @CL_FechaEmision, @CL_mes, @CL_anio, @suc, @doc, @idclavedoc, @tpIdClienteEx, @idClienteEx, @parteRel, @paisEfecExp, @tipoCli, @paisEfecPagoGen, @denopagoRegFis, @denoExpCli, @tipoRegi, @paisEfecPagoParFi)";
        //da.InsertCommand = new SqlCommand(sCommand, cnn);
        //da.InsertCommand.Parameters.Add("@CL_ExportaciónDe", SqlDbType.NVarChar, 50, "CL_ExportaciónDe");
        //da.InsertCommand.Parameters.Add("@Cl_TipoComprobante", SqlDbType.NVarChar, 50, "Cl_TipoComprobante");
        //da.InsertCommand.Parameters.Add("@CL_ReferendoDistrito", SqlDbType.NVarChar, 50, "CL_ReferendoDistrito");
        //da.InsertCommand.Parameters.Add("@CL_ReferendoAño", SqlDbType.NVarChar, 50, "CL_ReferendoAño");
        //da.InsertCommand.Parameters.Add("@CL_ReferendoRegimen", SqlDbType.NVarChar, 50, "CL_ReferendoRegimen");
        //da.InsertCommand.Parameters.Add("@CL_ReferendoCorrelativo", SqlDbType.NVarChar, 50, "CL_ReferendoCorrelativo");
        //da.InsertCommand.Parameters.Add("@CL_ReferendoVerificador", SqlDbType.NVarChar, 50, "CL_ReferendoVerificador");
        //da.InsertCommand.Parameters.Add("@CL_NroDocTransporte", SqlDbType.NVarChar, 50, "CL_NroDocTransporte");
        //// TODO: Comprobar el tipo de datos a usar...
        //da.InsertCommand.Parameters.Add("@CL_FechaTransaccion", SqlDbType.DateTime, 0, "CL_FechaTransaccion");
        //da.InsertCommand.Parameters.Add("@CL_NroFUE", SqlDbType.NVarChar, 50, "CL_NroFUE");
        //// TODO: Comprobar el tipo de datos a usar...
        //da.InsertCommand.Parameters.Add("@CL_ValorFOB", SqlDbType.Decimal, 0, "CL_ValorFOB");
        //// TODO: Comprobar el tipo de datos a usar...
        //da.InsertCommand.Parameters.Add("@CL_ValorComprobante", SqlDbType.Decimal, 0, "CL_ValorComprobante");
        //da.InsertCommand.Parameters.Add("@CL_NroSerieCpbteEstablec", SqlDbType.NVarChar, 50, "CL_NroSerieCpbteEstablec");
        //da.InsertCommand.Parameters.Add("@CL_NroSerieCpbteEmision", SqlDbType.NVarChar, 50, "CL_NroSerieCpbteEmision");
        //da.InsertCommand.Parameters.Add("@CL_NroSecuencialCpbte", SqlDbType.NVarChar, 50, "CL_NroSecuencialCpbte");
        //da.InsertCommand.Parameters.Add("@CL_NroAutorizacion", SqlDbType.NVarChar, 50, "CL_NroAutorizacion");
        //// TODO: Comprobar el tipo de datos a usar...
        //da.InsertCommand.Parameters.Add("@CL_FechaEmision", SqlDbType.DateTime, 0, "CL_FechaEmision");
        //// TODO: Comprobar el tipo de datos a usar...
        //da.InsertCommand.Parameters.Add("@Clave", SqlDbType.Decimal, 0, "Clave");
        //// TODO: Comprobar el tipo de datos a usar...
        //da.InsertCommand.Parameters.Add("@CL_mes", SqlDbType.Int, 0, "CL_mes");
        //// TODO: Comprobar el tipo de datos a usar...
        //da.InsertCommand.Parameters.Add("@CL_anio", SqlDbType.Int, 0, "CL_anio");
        //da.InsertCommand.Parameters.Add("@suc", SqlDbType.NVarChar, 3, "suc");
        //da.InsertCommand.Parameters.Add("@doc", SqlDbType.NVarChar, 3, "doc");
        //// TODO: Comprobar el tipo de datos a usar...
        //da.InsertCommand.Parameters.Add("@idclavedoc", SqlDbType.Decimal, 0, "idclavedoc");
        //da.InsertCommand.Parameters.Add("@tpIdClienteEx", SqlDbType.NVarChar, 3, "tpIdClienteEx");
        //da.InsertCommand.Parameters.Add("@idClienteEx", SqlDbType.NVarChar, 13, "idClienteEx");
        //da.InsertCommand.Parameters.Add("@parteRel", SqlDbType.NVarChar, 2, "parteRel");
        //da.InsertCommand.Parameters.Add("@paisEfecExp", SqlDbType.NVarChar, 4, "paisEfecExp");
        //da.InsertCommand.Parameters.Add("@tipoCli", SqlDbType.NVarChar, 3, "tipoCli");
        //da.InsertCommand.Parameters.Add("@paisEfecPagoGen", SqlDbType.NVarChar, 5, "paisEfecPagoGen");
        //// TODO: Este campo seguramente es MEMO y el valor debería ser cero en lugar de 350
        ////da.InsertCommand.Parameters.Add("@denopagoRegFis", SqlDbType.NText, 350, "denopagoRegFis");
        //da.InsertCommand.Parameters.Add("@denopagoRegFis", SqlDbType.NText, 0, "denopagoRegFis");
        //// TODO: Este campo seguramente es MEMO y el valor debería ser cero en lugar de 350
        ////da.InsertCommand.Parameters.Add("@denoExpCli", SqlDbType.NText, 350, "denoExpCli");
        //da.InsertCommand.Parameters.Add("@denoExpCli", SqlDbType.NText, 0, "denoExpCli");
        //da.InsertCommand.Parameters.Add("@tipoRegi", SqlDbType.NVarChar, 3, "tipoRegi");
        //da.InsertCommand.Parameters.Add("@paisEfecPagoParFi", SqlDbType.NVarChar, 4, "paisEfecPagoParFi");
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
        nuevoExportacion(dt, this);
        //
        try
        {
            da.Update(dt);
            dt.AcceptChanges();
            return "Se ha creado un nuevo Exportacion";
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
        //       yo uso el Clave que es el identificador único de cada registro
        string sel = "SELECT * FROM Exportacion WHERE Clave = " + this.Clave.ToString();
        //
        return Borrar(sel);
    }
    public string Borrar(string sel)
    {
        // Borrar el registro al que apunta esta clase
        // En caso de error, devolverá la cadena de error empezando por ERROR:.
        SqlConnection cnn;
        SqlDataAdapter da;
        DataTable dt = new DataTable("Exportacion");
        //
        cnn = new SqlConnection(cadenaConexion);
        da = new SqlDataAdapter(sel, cnn);
        da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
        //
        //-------------------------------------------
        // Esta no es la más óptima, pero funcionará
        //-------------------------------------------
        SqlCommandBuilder cb = new SqlCommandBuilder(da);
        da.DeleteCommand = cb.GetDeleteCommand();
        //
        //
        //--------------------------------------------------------------------
        // Esta está más optimizada pero debes comprobar que funciona bien...
        //--------------------------------------------------------------------
        //string sCommand;
        ////
        //// El comando DELETE
        //// TODO: Sólo incluir el campo de clave primaria incremental
        ////       Yo compruebo que sea un campo llamado Clave, pero en tu caso puede ser otro
        //sCommand = "DELETE FROM Exportacion WHERE (Clave = @p1)";
        //da.DeleteCommand = new SqlCommand(sCommand, cnn);
        //// TODO: Comprobar el tipo de datos a usar...
        //da.DeleteCommand.Parameters.Add("@p1", SqlDbType.Decimal, 0, "Clave");
        //da.DeleteCommand.Parameters.Add("@p2", SqlDbType.Int, 0, "");
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
