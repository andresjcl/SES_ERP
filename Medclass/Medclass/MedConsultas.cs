using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;

public class MedConslt
{
    private System.String _HisClínica;
    private System.Decimal _NroConsulta;
    private System.Decimal _IdClaveCita;
    private System.DateTime _Fecha;
    private System.String _RegistradoPor;
    private System.String _ModificadoPor;
    private System.DateTime _FechaRegistro;
    private System.DateTime _FechaModifica;
    private System.String _IdMedico;
    private System.String _Motivo;
    private System.String _Sintomas;
    private System.String _OrgSentidos;
    private System.String _OrgRespiratorio;
    private System.String _OrgCardioVas;
    private System.String _OrgDigestivo;
    private System.String _OrgGenital;
    private System.String _OrgUrinario;
    private System.String _OrgMuscEsque;
    private System.String _OrgEndocrino;
    private System.String _OrgLinfatico;
    private System.String _OrgNervioso;
    private System.String _OrgObservacion;
    private System.String _FisCabeza;
    private System.String _FisCuello;
    private System.String _FisTorax;
    private System.String _FisAbdomen;
    private System.String _FisPelvis;
    private System.String _FisExtremidades;
    private System.String _FisObservaciones;
    private System.String _Diagnostico;
    private System.String _Diagnostico2;
    private System.String _Diagnostico3;
    private System.String _Diagnostico4;
    private System.String _Tratamiento;
    private System.String _CodCie;
    private System.String _CodCie2;
    private System.String _CodCie3;
    private System.String _CodCie4;
    private System.String _Tipo;
    private System.String _Tipo2;
    private System.String _Tipo3;
    private System.String _Tipo4;
    //
    // Este método se usará para ajustar los anchos de las propiedades
    private string ajustarAncho(string cadena, int ancho)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder(new String(' ', ancho));
        return (cadena + sb.ToString()).Substring(0, ancho).Trim();
    }
    public System.String HisClínica
    {
        get
        {
            return ajustarAncho(_HisClínica, 20);
        }
        set
        {
            _HisClínica = value;
        }
    }
    public System.Decimal NroConsulta
    {
        get
        {
            return _NroConsulta;
        }
        set
        {
            _NroConsulta = value;
        }
    }
    public System.Decimal IdClaveCita
    {
        get
        {
            return _IdClaveCita;
        }
        set
        {
            _IdClaveCita = value;
        }
    }
    public System.DateTime Fecha
    {
        get
        {
            return _Fecha;
        }
        set
        {
            _Fecha = value;
        }
    }
    public System.String RegistradoPor
    {
        get
        {
            return ajustarAncho(_RegistradoPor, 20);
        }
        set
        {
            _RegistradoPor = value;
        }
    }
    public System.String ModificadoPor
    {
        get
        {
            return ajustarAncho(_ModificadoPor, 20);
        }
        set
        {
            _ModificadoPor = value;
        }
    }
    public System.DateTime FechaRegistro
    {
        get
        {
            return _FechaRegistro;
        }
        set
        {
            _FechaRegistro = value;
        }
    }
    public System.DateTime FechaModifica
    {
        get
        {
            return _FechaModifica;
        }
        set
        {
            _FechaModifica = value;
        }
    }
    public System.String IdMedico
    {
        get
        {
            return ajustarAncho(_IdMedico, 200);
        }
        set
        {
            _IdMedico = value;
        }
    }
    public System.String Motivo
    {
        get
        {
            // Seguramente sería mejor sin ajustar el ancho...
            //return ajustarAncho(_Motivo,512);
            return _Motivo;
        }
        set
        {
            _Motivo = value;
        }
    }
    public System.String Sintomas
    {
        get
        {
            // Seguramente sería mejor sin ajustar el ancho...
            //return ajustarAncho(_Sintomas,512);
            return _Sintomas;
        }
        set
        {
            _Sintomas = value;
        }
    }
    public System.String OrgSentidos
    {
        get
        {
            // Seguramente sería mejor sin ajustar el ancho...
            //return ajustarAncho(_OrgSentidos,512);
            return _OrgSentidos;
        }
        set
        {
            _OrgSentidos = value;
        }
    }
    public System.String OrgRespiratorio
    {
        get
        {
            // Seguramente sería mejor sin ajustar el ancho...
            //return ajustarAncho(_OrgRespiratorio,512);
            return _OrgRespiratorio;
        }
        set
        {
            _OrgRespiratorio = value;
        }
    }
    public System.String OrgCardioVas
    {
        get
        {
            // Seguramente sería mejor sin ajustar el ancho...
            //return ajustarAncho(_OrgCardioVas,512);
            return _OrgCardioVas;
        }
        set
        {
            _OrgCardioVas = value;
        }
    }
    public System.String OrgDigestivo
    {
        get
        {
            // Seguramente sería mejor sin ajustar el ancho...
            //return ajustarAncho(_OrgDigestivo,512);
            return _OrgDigestivo;
        }
        set
        {
            _OrgDigestivo = value;
        }
    }
    public System.String OrgGenital
    {
        get
        {
            // Seguramente sería mejor sin ajustar el ancho...
            //return ajustarAncho(_OrgGenital,512);
            return _OrgGenital;
        }
        set
        {
            _OrgGenital = value;
        }
    }
    public System.String OrgUrinario
    {
        get
        {
            // Seguramente sería mejor sin ajustar el ancho...
            //return ajustarAncho(_OrgUrinario,512);
            return _OrgUrinario;
        }
        set
        {
            _OrgUrinario = value;
        }
    }
    public System.String OrgMuscEsque
    {
        get
        {
            // Seguramente sería mejor sin ajustar el ancho...
            //return ajustarAncho(_OrgMuscEsque,512);
            return _OrgMuscEsque;
        }
        set
        {
            _OrgMuscEsque = value;
        }
    }
    public System.String OrgEndocrino
    {
        get
        {
            // Seguramente sería mejor sin ajustar el ancho...
            //return ajustarAncho(_OrgEndocrino,512);
            return _OrgEndocrino;
        }
        set
        {
            _OrgEndocrino = value;
        }
    }
    public System.String OrgLinfatico
    {
        get
        {
            // Seguramente sería mejor sin ajustar el ancho...
            //return ajustarAncho(_OrgLinfatico,512);
            return _OrgLinfatico;
        }
        set
        {
            _OrgLinfatico = value;
        }
    }
    public System.String OrgNervioso
    {
        get
        {
            // Seguramente sería mejor sin ajustar el ancho...
            //return ajustarAncho(_OrgNervioso,512);
            return _OrgNervioso;
        }
        set
        {
            _OrgNervioso = value;
        }
    }
    public System.String OrgObservacion
    {
        get
        {
            // Seguramente sería mejor sin ajustar el ancho...
            //return ajustarAncho(_OrgObservacion,512);
            return _OrgObservacion;
        }
        set
        {
            _OrgObservacion = value;
        }
    }
    public System.String FisCabeza
    {
        get
        {
            // Seguramente sería mejor sin ajustar el ancho...
            //return ajustarAncho(_FisCabeza,512);
            return _FisCabeza;
        }
        set
        {
            _FisCabeza = value;
        }
    }
    public System.String FisCuello
    {
        get
        {
            // Seguramente sería mejor sin ajustar el ancho...
            //return ajustarAncho(_FisCuello,512);
            return _FisCuello;
        }
        set
        {
            _FisCuello = value;
        }
    }
    public System.String FisTorax
    {
        get
        {
            // Seguramente sería mejor sin ajustar el ancho...
            //return ajustarAncho(_FisTorax,512);
            return _FisTorax;
        }
        set
        {
            _FisTorax = value;
        }
    }
    public System.String FisAbdomen
    {
        get
        {
            // Seguramente sería mejor sin ajustar el ancho...
            //return ajustarAncho(_FisAbdomen,512);
            return _FisAbdomen;
        }
        set
        {
            _FisAbdomen = value;
        }
    }
    public System.String FisPelvis
    {
        get
        {
            // Seguramente sería mejor sin ajustar el ancho...
            //return ajustarAncho(_FisPelvis,512);
            return _FisPelvis;
        }
        set
        {
            _FisPelvis = value;
        }
    }
    public System.String FisExtremidades
    {
        get
        {
            // Seguramente sería mejor sin ajustar el ancho...
            //return ajustarAncho(_FisExtremidades,512);
            return _FisExtremidades;
        }
        set
        {
            _FisExtremidades = value;
        }
    }
    public System.String FisObservaciones
    {
        get
        {
            // Seguramente sería mejor sin ajustar el ancho...
            //return ajustarAncho(_FisObservaciones,512);
            return _FisObservaciones;
        }
        set
        {
            _FisObservaciones = value;
        }
    }
    public System.String Diagnostico
    {
        get
        {
            // Seguramente sería mejor sin ajustar el ancho...
            //return ajustarAncho(_Diagnostico,512);
            return _Diagnostico;
        }
        set
        {
            _Diagnostico = value;
        }
    }
    public System.String Diagnostico2
    {
        get
        {
            // Seguramente sería mejor sin ajustar el ancho...
            //return ajustarAncho(_Diagnostico2,512);
            return _Diagnostico2;
        }
        set
        {
            _Diagnostico2 = value;
        }
    }
    public System.String Diagnostico3
    {
        get
        {
            // Seguramente sería mejor sin ajustar el ancho...
            //return ajustarAncho(_Diagnostico3,512);
            return _Diagnostico3;
        }
        set
        {
            _Diagnostico3 = value;
        }
    }
    public System.String Diagnostico4
    {
        get
        {
            // Seguramente sería mejor sin ajustar el ancho...
            //return ajustarAncho(_Diagnostico4,512);
            return _Diagnostico4;
        }
        set
        {
            _Diagnostico4 = value;
        }
    }
    public System.String Tratamiento
    {
        get
        {
            // Seguramente sería mejor sin ajustar el ancho...
            //return ajustarAncho(_Tratamiento,512);
            return _Tratamiento;
        }
        set
        {
            _Tratamiento = value;
        }
    }
    public System.String CodCie
    {
        get
        {
            return ajustarAncho(_CodCie, 50);
        }
        set
        {
            _CodCie = value;
        }
    }
    public System.String CodCie2
    {
        get
        {
            return ajustarAncho(_CodCie2, 50);
        }
        set
        {
            _CodCie2 = value;
        }
    }
    public System.String CodCie3
    {
        get
        {
            return ajustarAncho(_CodCie3, 50);
        }
        set
        {
            _CodCie3 = value;
        }
    }
    public System.String CodCie4
    {
        get
        {
            return ajustarAncho(_CodCie4, 50);
        }
        set
        {
            _CodCie4 = value;
        }
    }
    public System.String Tipo
    {
        get
        {
            return ajustarAncho(_Tipo, 3);
        }
        set
        {
            _Tipo = value;
        }
    }
    public System.String Tipo2
    {
        get
        {
            return ajustarAncho(_Tipo2, 3);
        }
        set
        {
            _Tipo2 = value;
        }
    }
    public System.String Tipo3
    {
        get
        {
            return ajustarAncho(_Tipo3, 3);
        }
        set
        {
            _Tipo3 = value;
        }
    }
    public System.String Tipo4
    {
        get
        {
            return ajustarAncho(_Tipo4, 3);
        }
        set
        {
            _Tipo4 = value;
        }
    }
    //
    //
    // La cadena de conexión a la base de datos
    private static string cadenaConexion = @"";
    // La cadena de selección
    public static string CadenaSelect = "SELECT * FROM MedConslt";
    //
    public MedConslt()
    {
    }
    public MedConslt(string conex)
    {
        cadenaConexion = conex;
    }
    //
    // Métodos compartidos (estáticos) privados
    //
    // asigna una fila de la tabla a un objeto MedConslt
    public static MedConslt row2MedConslt(DataRow r)
    {
        // asigna a un objeto MedConslt los datos del dataRow indicado
        MedConslt oMedConslt = new MedConslt();
        //
        oMedConslt.HisClínica = r["HisClínica"].ToString();
        oMedConslt.NroConsulta = System.Decimal.Parse("0" + r["NroConsulta"].ToString());
        oMedConslt.IdClaveCita = System.Decimal.Parse("0" + r["IdClaveCita"].ToString());
        try
        {
            oMedConslt.Fecha = DateTime.Parse(r["Fecha"].ToString());
        }
        catch
        {
            oMedConslt.Fecha = DateTime.Now;
        }
        oMedConslt.RegistradoPor = r["RegistradoPor"].ToString();
        oMedConslt.ModificadoPor = r["ModificadoPor"].ToString();
        try
        {
            oMedConslt.FechaRegistro = DateTime.Parse(r["FechaRegistro"].ToString());
        }
        catch
        {
            oMedConslt.FechaRegistro = DateTime.Now;
        }
        try
        {
            oMedConslt.FechaModifica = DateTime.Parse(r["FechaModifica"].ToString());
        }
        catch
        {
            oMedConslt.FechaModifica = DateTime.Now;
        }
        oMedConslt.IdMedico = r["IdMedico"].ToString();
        oMedConslt.Motivo = r["Motivo"].ToString();
        oMedConslt.Sintomas = r["Sintomas"].ToString();
        oMedConslt.OrgSentidos = r["OrgSentidos"].ToString();
        oMedConslt.OrgRespiratorio = r["OrgRespiratorio"].ToString();
        oMedConslt.OrgCardioVas = r["OrgCardioVas"].ToString();
        oMedConslt.OrgDigestivo = r["OrgDigestivo"].ToString();
        oMedConslt.OrgGenital = r["OrgGenital"].ToString();
        oMedConslt.OrgUrinario = r["OrgUrinario"].ToString();
        oMedConslt.OrgMuscEsque = r["OrgMuscEsque"].ToString();
        oMedConslt.OrgEndocrino = r["OrgEndocrino"].ToString();
        oMedConslt.OrgLinfatico = r["OrgLinfatico"].ToString();
        oMedConslt.OrgNervioso = r["OrgNervioso"].ToString();
        oMedConslt.OrgObservacion = r["OrgObservacion"].ToString();
        oMedConslt.FisCabeza = r["FisCabeza"].ToString();
        oMedConslt.FisCuello = r["FisCuello"].ToString();
        oMedConslt.FisTorax = r["FisTorax"].ToString();
        oMedConslt.FisAbdomen = r["FisAbdomen"].ToString();
        oMedConslt.FisPelvis = r["FisPelvis"].ToString();
        oMedConslt.FisExtremidades = r["FisExtremidades"].ToString();
        oMedConslt.FisObservaciones = r["FisObservaciones"].ToString();
        oMedConslt.Diagnostico = r["Diagnostico"].ToString();
        oMedConslt.Diagnostico2 = r["Diagnostico2"].ToString();
        oMedConslt.Diagnostico3 = r["Diagnostico3"].ToString();
        oMedConslt.Diagnostico4 = r["Diagnostico4"].ToString();
        oMedConslt.Tratamiento = r["Tratamiento"].ToString();
        oMedConslt.CodCie = r["CodCie"].ToString();
        oMedConslt.CodCie2 = r["CodCie2"].ToString();
        oMedConslt.CodCie3 = r["CodCie3"].ToString();
        oMedConslt.CodCie4 = r["CodCie4"].ToString();
        oMedConslt.Tipo = r["Tipo"].ToString();
        oMedConslt.Tipo2 = r["Tipo2"].ToString();
        oMedConslt.Tipo3 = r["Tipo3"].ToString();
        oMedConslt.Tipo4 = r["Tipo4"].ToString();
        //
        return oMedConslt;
    }
    //
    // asigna un objeto MedConslt a la fila indicada
    private static void MedConslt2Row(MedConslt oMedConslt, DataRow r)
    {
        // asigna un objeto MedConslt al dataRow indicado
        r["HisClínica"] = oMedConslt.HisClínica;
        r["NroConsulta"] = oMedConslt.NroConsulta;
        r["IdClaveCita"] = oMedConslt.IdClaveCita;
        r["Fecha"] = oMedConslt.Fecha;
        r["RegistradoPor"] = oMedConslt.RegistradoPor;
        r["ModificadoPor"] = oMedConslt.ModificadoPor;
        r["FechaRegistro"] = oMedConslt.FechaRegistro;
        r["FechaModifica"] = oMedConslt.FechaModifica;
        r["IdMedico"] = oMedConslt.IdMedico;
        r["Motivo"] = oMedConslt.Motivo;
        r["Sintomas"] = oMedConslt.Sintomas;
        r["OrgSentidos"] = oMedConslt.OrgSentidos;
        r["OrgRespiratorio"] = oMedConslt.OrgRespiratorio;
        r["OrgCardioVas"] = oMedConslt.OrgCardioVas;
        r["OrgDigestivo"] = oMedConslt.OrgDigestivo;
        r["OrgGenital"] = oMedConslt.OrgGenital;
        r["OrgUrinario"] = oMedConslt.OrgUrinario;
        r["OrgMuscEsque"] = oMedConslt.OrgMuscEsque;
        r["OrgEndocrino"] = oMedConslt.OrgEndocrino;
        r["OrgLinfatico"] = oMedConslt.OrgLinfatico;
        r["OrgNervioso"] = oMedConslt.OrgNervioso;
        r["OrgObservacion"] = oMedConslt.OrgObservacion;
        r["FisCabeza"] = oMedConslt.FisCabeza;
        r["FisCuello"] = oMedConslt.FisCuello;
        r["FisTorax"] = oMedConslt.FisTorax;
        r["FisAbdomen"] = oMedConslt.FisAbdomen;
        r["FisPelvis"] = oMedConslt.FisPelvis;
        r["FisExtremidades"] = oMedConslt.FisExtremidades;
        r["FisObservaciones"] = oMedConslt.FisObservaciones;
        r["Diagnostico"] = oMedConslt.Diagnostico;
        r["Diagnostico2"] = oMedConslt.Diagnostico2;
        r["Diagnostico3"] = oMedConslt.Diagnostico3;
        r["Diagnostico4"] = oMedConslt.Diagnostico4;
        r["Tratamiento"] = oMedConslt.Tratamiento;
        r["CodCie"] = oMedConslt.CodCie;
        r["CodCie2"] = oMedConslt.CodCie2;
        r["CodCie3"] = oMedConslt.CodCie3;
        r["CodCie4"] = oMedConslt.CodCie4;
        r["Tipo"] = oMedConslt.Tipo;
        r["Tipo2"] = oMedConslt.Tipo2;
        r["Tipo3"] = oMedConslt.Tipo3;
        r["Tipo4"] = oMedConslt.Tipo4;
    }
    //
    // crea una nueva fila y la asigna a un objeto MedConslt
    private static void nuevoMedConslt(DataTable dt, MedConslt oMedConslt)
    {
        // Crear un nuevo MedConslt
        DataRow dr = dt.NewRow();
        MedConslt oM = row2MedConslt(dr);
        //
        oM.HisClínica = oMedConslt.HisClínica;
        oM.NroConsulta = oMedConslt.NroConsulta;
        oM.IdClaveCita = oMedConslt.IdClaveCita;
        oM.Fecha = oMedConslt.Fecha;
        oM.RegistradoPor = oMedConslt.RegistradoPor;
        oM.ModificadoPor = oMedConslt.ModificadoPor;
        oM.FechaRegistro = oMedConslt.FechaRegistro;
        oM.FechaModifica = oMedConslt.FechaModifica;
        oM.IdMedico = oMedConslt.IdMedico;
        oM.Motivo = oMedConslt.Motivo;
        oM.Sintomas = oMedConslt.Sintomas;
        oM.OrgSentidos = oMedConslt.OrgSentidos;
        oM.OrgRespiratorio = oMedConslt.OrgRespiratorio;
        oM.OrgCardioVas = oMedConslt.OrgCardioVas;
        oM.OrgDigestivo = oMedConslt.OrgDigestivo;
        oM.OrgGenital = oMedConslt.OrgGenital;
        oM.OrgUrinario = oMedConslt.OrgUrinario;
        oM.OrgMuscEsque = oMedConslt.OrgMuscEsque;
        oM.OrgEndocrino = oMedConslt.OrgEndocrino;
        oM.OrgLinfatico = oMedConslt.OrgLinfatico;
        oM.OrgNervioso = oMedConslt.OrgNervioso;
        oM.OrgObservacion = oMedConslt.OrgObservacion;
        oM.FisCabeza = oMedConslt.FisCabeza;
        oM.FisCuello = oMedConslt.FisCuello;
        oM.FisTorax = oMedConslt.FisTorax;
        oM.FisAbdomen = oMedConslt.FisAbdomen;
        oM.FisPelvis = oMedConslt.FisPelvis;
        oM.FisExtremidades = oMedConslt.FisExtremidades;
        oM.FisObservaciones = oMedConslt.FisObservaciones;
        oM.Diagnostico = oMedConslt.Diagnostico;
        oM.Diagnostico2 = oMedConslt.Diagnostico2;
        oM.Diagnostico3 = oMedConslt.Diagnostico3;
        oM.Diagnostico4 = oMedConslt.Diagnostico4;
        oM.Tratamiento = oMedConslt.Tratamiento;
        oM.CodCie = oMedConslt.CodCie;
        oM.CodCie2 = oMedConslt.CodCie2;
        oM.CodCie3 = oMedConslt.CodCie3;
        oM.CodCie4 = oMedConslt.CodCie4;
        oM.Tipo = oMedConslt.Tipo;
        oM.Tipo2 = oMedConslt.Tipo2;
        oM.Tipo3 = oMedConslt.Tipo3;
        oM.Tipo4 = oMedConslt.Tipo4;
        //
        MedConslt2Row(oM, dr);
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
        // devuelve una tabla con los datos de la tabla MedConslt
        SqlDataAdapter da;
        DataTable dt = new DataTable("MedConslt");
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
    public static MedConslt Buscar(string sWhere)
    {
        // Busca en la tabla los datos indicados en el parámetro
        // el parámetro contendrá lo que se usará después del WHERE
        MedConslt oMedConslt = null;
        SqlDataAdapter da;
        DataTable dt = new DataTable("MedConslt");
        string sel = "SELECT * FROM MedConslt WHERE " + sWhere;
        //
        da = new SqlDataAdapter(sel, cadenaConexion);
        da.Fill(dt);
        //
        if (dt.Rows.Count > 0)
        {
            oMedConslt = row2MedConslt(dt.Rows[0]);
        }
        return oMedConslt;
    }
    //
    // Actualizar: Actualiza los datos en la tabla usando la instancia actual
    //             Si la instancia no hace referencia a un registro existente, se creará uno nuevo
    //             Para comprobar si el objeto en memoria coincide con uno existente,
    //             se comprueba si el ID existe en la tabla.
    //             TODO: Si en lugar de ID usas otro campo, indicalo en la cadena SELECT
    //                   También puedes usar la sobrecarga en la que se indica la cadena SELECT a usar
    public string Actualizar()
    {
        string sel = "SELECT * FROM MedConslt WHERE HisClínica = '" + this.HisClínica + "' and NroConsulta = " + this.NroConsulta.ToString();
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
        DataTable dt = new DataTable("MedConslt");
        CadenaSelect = sel;
        //
        cnn = new SqlConnection(cadenaConexion);
        da = new SqlDataAdapter(sel, cnn);
        da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
        SqlCommandBuilder cb = new SqlCommandBuilder(da);
        da.UpdateCommand = cb.GetUpdateCommand();
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
            MedConslt2Row(this, dt.Rows[0]);
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
        DataTable dt = new DataTable("MedConslt");
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
        nuevoMedConslt(dt, this);
        //
        try
        {
            da.Update(dt);
            dt.AcceptChanges();
            return "Se ha creado un nuevo MedConslt";
        }
        catch (Exception ex)
        {
            return "ERROR: " + ex.Message;
        }
    }
    //
    public string Borrar()
    {
        string sel = "SELECT * FROM MedConslt WHERE HisClínica = '" + this.HisClínica + "' and NroConsulta = " + this.NroConsulta.ToString();
        //
        return Borrar(sel);
    }
    public string Borrar(string sel)
    {
        SqlConnection cnn;
        SqlDataAdapter da;
        DataTable dt = new DataTable("MedConslt");
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
    //
}
