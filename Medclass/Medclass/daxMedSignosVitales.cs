using System;
using System.Data;
using System.Data.SqlClient;

namespace DaxMedic
{
public class MedSigVit
    {
        // Las variables privadas
        // TODO: Revisar los tipos de los campos
        private System.DateTime _FechaRegistro = new DateTime(1900,1,1);
        private System.String _HistClinica="";
        private System.Decimal _IdCitaMedica=0;
        private System.Decimal _Estatura = 0;
        private System.Decimal _Peso = 0;
        private System.Decimal _Temperatura = 0;
        private System.Decimal _PresionArterial1 = 0;
        private System.Decimal _PresionArterial2 = 0;
        private System.Decimal _FrecuenciaCardiaca = 0;
        private System.Decimal _FrecuenciaRespiratoria = 0;
        private System.Decimal _Oximetria = 0;
        private System.String _Observaciones = "";
        private System.String _CreadoPor = "";
        private System.String _ModificadoPor = "";
        //
        // Este método se usará para ajustar los anchos de las propiedades
        private string ajustarAncho(string cadena, int ancho)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder(new String(' ', ancho));
            return (cadena + sb.ToString()).Substring(0, ancho).Trim();
        }
        //
        // Las propiedades públicas
        public System.String HistClinica
        {
            get
            {
                return ajustarAncho(_HistClinica, 50);
            }
            set
            {
                _HistClinica = value;
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
                try
                {
                    _FechaRegistro = value;
                }
                catch { _FechaRegistro = new DateTime(1900,1,1); }
            }
        }
        public System.Decimal IdCitaMedica
        {
            get
            {
                return _IdCitaMedica;
            }
            set
            {
                _IdCitaMedica = value;
            }
        }
        public System.Decimal Estatura
        {
            get
            {
                return _Estatura;
            }
            set
            {
                _Estatura = value;
            }
        }
        public System.Decimal Peso
        {
            get
            {
                return _Peso;
            }
            set
            {
                _Peso = value;
            }
        }
        public System.Decimal Temperatura
        {
            get
            {
                return _Temperatura;
            }
            set
            {
                _Temperatura = value;
            }
        }
        public System.Decimal PresionArterial1
        {
            get
            {
                return _PresionArterial1;
            }
            set
            {
                _PresionArterial1 = value;
            }
        }
        public System.Decimal PresionArterial2
        {
            get
            {
                return _PresionArterial2;
            }
            set
            {
                _PresionArterial2 = value;
            }
        }
        public System.Decimal FrecuenciaCardiaca
        {
            get
            {
                return _FrecuenciaCardiaca;
            }
            set
            {
                _FrecuenciaCardiaca = value;
            }
        }
        public System.Decimal FrecuenciaRespiratoria
        {
            get
            {
                return _FrecuenciaRespiratoria;
            }
            set
            {
                _FrecuenciaRespiratoria = value;
            }
        }
        public System.Decimal Oximetria
        {
            get
            {
                return _Oximetria;
            }
            set
            {
                _Oximetria = value;
            }
        }
        public System.String  Observaciones
        {
            get
            {
                return _Observaciones;
            }
            set
            {
                _Observaciones = value;
            }
        }
        public System.String CreadoPor
        {
            get
            {
                return _CreadoPor;
            }
            set
            {
                _CreadoPor = value;
            }
        }
        public System.String ModificadoPor
        {
            get
            {
                return _ModificadoPor;
            }
            set
            {
                _ModificadoPor = value;
            }
        }
        //
        //
        // Campos y métodos compartidos (estáticos) para gestionar la base de datos
        //
        // La cadena de conexión a la base de datos
        private static string cadenaConexion = "";
        // La cadena de selección
        public static string CadenaSelect = "SELECT * FROM MedSigVit";
        //
        public MedSigVit()
        {
        }
        public MedSigVit(string conex)
        {
            cadenaConexion = conex;
        }
        //
        // Métodos compartidos (estáticos) privados
        //
        // asigna una fila de la tabla a un objeto MedSigVit
        private static MedSigVit row2MedSigVit(DataRow r)
        {
            // asigna a un objeto MedSigVit los datos del dataRow indicado
            MedSigVit oMedSigVit = new MedSigVit();
            //
            oMedSigVit.HistClinica = r["HistClinica"].ToString();
            oMedSigVit.FechaRegistro = DateTime.Now;
            oMedSigVit.IdCitaMedica = System.Decimal.Parse("0" + r["IdCitaMedica"].ToString());
            oMedSigVit.Estatura = System.Decimal.Parse("0" + r["Estatura"].ToString());
            oMedSigVit.Peso = System.Decimal.Parse("0" + r["Peso"].ToString());
            oMedSigVit.Temperatura = System.Decimal.Parse("0" + r["Temperatura"].ToString());
            oMedSigVit.PresionArterial1 = System.Decimal.Parse("0" + r["PresionArterial1"].ToString());
            oMedSigVit.PresionArterial2 = System.Decimal.Parse("0" + r["PresionArterial2"].ToString());
            oMedSigVit.FrecuenciaCardiaca = System.Decimal.Parse("0" + r["FrecuenciaCardiaca"].ToString());
            oMedSigVit.FrecuenciaRespiratoria = System.Decimal.Parse("0" + r["FrecuenciaRespiratoria"].ToString());
            oMedSigVit.Oximetria = System.Decimal.Parse("0" + r["Oximetria"].ToString());
            oMedSigVit.Observaciones = r["Observaciones"].ToString();
            oMedSigVit.CreadoPor = r["CreadoPor"].ToString();
            oMedSigVit.ModificadoPor = r["ModificadoPor"].ToString();
            //
            return oMedSigVit;
        }
        //
        // asigna un objeto MedSigVit a la fila indicada
        private static void MedSigVit2Row(MedSigVit oMedSigVit, DataRow r)
        {
            // asigna un objeto MedSigVit al dataRow indicado
            r["HistClinica"] = oMedSigVit.HistClinica;
            r["FechaRegistro"] = oMedSigVit.FechaRegistro ;
            r["IdCitaMedica"] = oMedSigVit.IdCitaMedica;
            r["Estatura"] = oMedSigVit.Estatura;
            r["Peso"] = oMedSigVit.Peso;
            r["Temperatura"] = oMedSigVit.Temperatura;
            r["PresionArterial1"] = oMedSigVit.PresionArterial1;
            r["PresionArterial2"] = oMedSigVit.PresionArterial2;
            r["FrecuenciaCardiaca"] = oMedSigVit.FrecuenciaCardiaca;
            r["FrecuenciaRespiratoria"] = oMedSigVit.FrecuenciaRespiratoria;
            r["Oximetria"] = oMedSigVit.Oximetria;
            r["Observaciones"] = oMedSigVit.Observaciones;
            r["CreadoPor"] = oMedSigVit.CreadoPor ;
            r["ModificadoPor"] = oMedSigVit.ModificadoPor;
        }
        //
        // crea una nueva fila y la asigna a un objeto MedSigVit
        private static void nuevoMedSigVit(DataTable dt, MedSigVit oMedSigVit)
        {
            // Crear un nuevo MedSigVit
            DataRow dr = dt.NewRow();
            MedSigVit oD = row2MedSigVit(dr);
            //
            oD.HistClinica = oMedSigVit.HistClinica;
            oD.FechaRegistro = oMedSigVit.FechaRegistro;
            oD.IdCitaMedica = oMedSigVit.IdCitaMedica;
            oD.Estatura = oMedSigVit.Estatura;
            oD.Peso = oMedSigVit.Peso;
            oD.Temperatura = oMedSigVit.Temperatura;
            oD.PresionArterial1 = oMedSigVit.PresionArterial1;
            oD.PresionArterial2 = oMedSigVit.PresionArterial2;
            oD.FrecuenciaCardiaca = oMedSigVit.FrecuenciaCardiaca;
            oD.FrecuenciaRespiratoria = oMedSigVit.FrecuenciaRespiratoria;
            oD.Oximetria = oMedSigVit.Oximetria;
            oD.Observaciones = oMedSigVit.Observaciones;
            oD.CreadoPor  = oMedSigVit.CreadoPor;
            oD.ModificadoPor = oMedSigVit.ModificadoPor;
            //
            MedSigVit2Row(oD, dr);
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
            // devuelve una tabla con los datos de la tabla MedSigVit
            SqlDataAdapter da;
            DataTable dt = new DataTable("MedSigVit");
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
        public static MedSigVit Buscar(string sWhere)
        {
            // Busca en la tabla los datos indicados en el parámetro
            // el parámetro contendrá lo que se usará después del WHERE
            MedSigVit oMedSigVit = null;
            SqlDataAdapter da;
            DataTable dt = new DataTable("MedSigVit");
            string sel = "SELECT * FROM MedSigVit WHERE " + sWhere;
            //
            da = new SqlDataAdapter(sel, cadenaConexion);
            da.Fill(dt);
            //
            if (dt.Rows.Count > 0)
            {
                oMedSigVit = row2MedSigVit(dt.Rows[0]);
            }
            return oMedSigVit;
        }
        //
        public string Actualizar()
        {
            string sel = "SELECT * FROM MedSigVit WHERE IdCitaMedica = " + this.IdCitaMedica.ToString();            
            return Actualizar(sel);
        }
        public string Actualizar(string sel)
        {
            // En caso de error, devolverá la cadena empezando por ERROR.
            SqlConnection cnn;
            SqlDataAdapter da;
            DataTable dt = new DataTable("MedSigVit");
            //
            CadenaSelect = sel;

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
                MedSigVit2Row(this, dt.Rows[0]);
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
            // En caso de error, devolverá la cadena de error empezando por ERROR:.
            SqlConnection cnn;
            SqlDataAdapter da;
            DataTable dt = new DataTable("MedSigVit");
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
            nuevoMedSigVit(dt, this);
            //
            try
            {
                da.Update(dt);
                dt.AcceptChanges();
                return "Se ha creado un nuevo MedSigVit";
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
        }
        //
        public string Borrar()
        {
            string sel = "SELECT * FROM MedSigVit WHERE IdCitaMedica = " + this.IdCitaMedica.ToString();
            //
            return Borrar(sel);
        }
        public string Borrar(string sel)
        {
            SqlConnection cnn;
            SqlDataAdapter da;
            DataTable dt = new DataTable("MedSigVit");
            //
            cnn = new SqlConnection(cadenaConexion);
            da = new SqlDataAdapter(sel, cnn);
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            //-------------------------------------------
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
}

