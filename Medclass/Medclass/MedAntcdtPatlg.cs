using System;
using System.Data;
using System.Data.SqlClient;
//

namespace DaxMedic
{
    public class MedAntPat
    {
        // Las variables privadas
        // TODO: Revisar los tipos de los campos
        private string _HistClinica ="";
        private System.String _AntHer_Patologicos = "";
        private System.String _AntHer_Alcoholismo = "";
        private System.String _AntHer_Tabaquismo = "";
        private System.String _Ant_PatologicosObs = "";
        private System.String _AntPat_CreadoPor = "";
        private System.String _AntPat_ModificadoPor = "";
        //
        // Este método se usará para ajustar los anchos de las propiedades
        private string ajustarAncho(string cadena, int ancho)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder(new String(' ', ancho));
            return (cadena + sb.ToString()).Substring(0, ancho).Trim();
        }
        //
        public System.String HistClinica
        {
            get
            {
                return ajustarAncho(_HistClinica, 20);
            }
            set
            {
                _HistClinica = value;
            }
        }
        public System.String AntHer_Patologicos
        {
            get
            {
                return _AntHer_Patologicos;
            }
            set
            {
                _AntHer_Patologicos = value;
            }
        }
        public System.String AntHer_Alcoholismo
        {
            get
            {
                return ajustarAncho(_AntHer_Alcoholismo, 50);
            }
            set
            {
                _AntHer_Alcoholismo = value;
            }
        }
        public System.String AntHer_Tabaquismo
        {
            get
            {
                return ajustarAncho(_AntHer_Tabaquismo, 50);
            }
            set
            {
                _AntHer_Tabaquismo = value;
            }
        }
        public System.String Ant_PatologicosObs
        {
            get
            {
                return _Ant_PatologicosObs;
            }
            set
            {
                _Ant_PatologicosObs = value;
            }
        }
        public System.String AntPat_CreadoPor
        {
            get
            {
                return ajustarAncho(_AntPat_CreadoPor, 100);
            }
            set
            {
                _AntPat_CreadoPor = value;
            }
        }
        public System.String AntPat_ModificadoPor
        {
            get
            {
                return ajustarAncho(_AntPat_ModificadoPor, 100);
            }
            set
            {
                _AntPat_ModificadoPor = value;
            }
        }
        //
        // La cadena de conexión a la base de datos
        private static string cadenaConexion = @"Data Source=daxserver; Initial Catalog=BdAdcomDx14CLeones; user id=sa; password=1234qwerASDFZXCV";
        // La cadena de selección
        public static string CadenaSelect = "SELECT * FROM MedAntPat";
        //
        public MedAntPat()
        {
        }
        public MedAntPat(string conex)
        {
            cadenaConexion = conex;
        }
        //
        private static MedAntPat row2MedAntPat(DataRow r)
        {
            // asigna a un objeto MedAntPat los datos del dataRow indicado
            MedAntPat oMedAntPat = new MedAntPat();
            //
            oMedAntPat.HistClinica = r["HistClinica"].ToString();
            oMedAntPat.AntHer_Patologicos = r["AntHer_Patologicos"].ToString();
            oMedAntPat.AntHer_Alcoholismo = r["AntHer_Alcoholismo"].ToString();
            oMedAntPat.AntHer_Tabaquismo = r["AntHer_Tabaquismo"].ToString();
            oMedAntPat.Ant_PatologicosObs = r["Ant_PatologicosObs"].ToString();
            oMedAntPat.AntPat_CreadoPor = r["AntPat_CreadoPor"].ToString();
            oMedAntPat.AntPat_ModificadoPor = r["AntPat_ModificadoPor"].ToString();
            //
            return oMedAntPat;
        }
        //
        // asigna un objeto MedAntPat a la fila indicada
        private static void MedAntPat2Row(MedAntPat oMedAntPat, DataRow r)
        {
            // asigna un objeto MedAntPat al dataRow indicado
            r["HistClinica"] = oMedAntPat.HistClinica;
            r["AntHer_Patologicos"] = oMedAntPat.AntHer_Patologicos;
            r["AntHer_Alcoholismo"] = oMedAntPat.AntHer_Alcoholismo;
            r["AntHer_Tabaquismo"] = oMedAntPat.AntHer_Tabaquismo;
            r["Ant_PatologicosObs"] = oMedAntPat.Ant_PatologicosObs;
            r["AntPat_CreadoPor"] = oMedAntPat.AntPat_CreadoPor;
            r["AntPat_ModificadoPor"] = oMedAntPat.AntPat_ModificadoPor;
        }
        //
        // crea una nueva fila y la asigna a un objeto MedAntPat
        private static void nuevoMedAntPat(DataTable dt, MedAntPat oMedAntPat)
        {
            // Crear un nuevo MedAntPat
            DataRow dr = dt.NewRow();
            MedAntPat oD = row2MedAntPat(dr);
            //
            oD.HistClinica = oMedAntPat.HistClinica;
            oD.AntHer_Patologicos = oMedAntPat.AntHer_Patologicos;
            oD.AntHer_Alcoholismo = oMedAntPat.AntHer_Alcoholismo;
            oD.AntHer_Tabaquismo = oMedAntPat.AntHer_Tabaquismo;
            oD.Ant_PatologicosObs = oMedAntPat.Ant_PatologicosObs;
            oD.AntPat_CreadoPor = oMedAntPat.AntPat_CreadoPor;
            oD.AntPat_ModificadoPor = oMedAntPat.AntPat_ModificadoPor;
            //
            MedAntPat2Row(oD, dr);
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
            // devuelve una tabla con los datos de la tabla MedAntPat
            SqlDataAdapter da;
            DataTable dt = new DataTable("MedAntPat");
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
        public static MedAntPat Buscar(string sWhere)
        {
            // Busca en la tabla los datos indicados en el parámetro
            // el parámetro contendrá lo que se usará después del WHERE
            MedAntPat oMedAntPat = null;
            SqlDataAdapter da;
            DataTable dt = new DataTable("MedAntPat");
            string sel = "SELECT * FROM MedAntPat WHERE " + sWhere;
            //
            da = new SqlDataAdapter(sel, cadenaConexion);
            da.Fill(dt);
            //
            if (dt.Rows.Count > 0)
            {
                oMedAntPat = row2MedAntPat(dt.Rows[0]);
            }
            return oMedAntPat;
        }
        //
        public string Actualizar()
        {
            string sel = "SELECT * FROM MedAntPat WHERE HistClinica = '" + this.HistClinica + "'";
            return Actualizar(sel);
        }
        public string Actualizar(string sel)
        {
            // En caso de error, devolverá la cadena empezando por ERROR.
            SqlConnection cnn;
            SqlDataAdapter da;
            DataTable dt = new DataTable("MedAntPat");
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
                MedAntPat2Row(this, dt.Rows[0]);
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
            DataTable dt = new DataTable("MedAntPat");
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
            nuevoMedAntPat(dt, this);
            //
            try
            {
                da.Update(dt);
                dt.AcceptChanges();
                return "Se ha creado un nuevo MedAntPat";
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
        }
        //
        public string Borrar()
        {
            string sel = "SELECT * FROM MedAntPat WHERE HistClinica = '" + this.HistClinica + "'";
            //
            return Borrar(sel);
        }
        public string Borrar(string sel)
        {
            SqlConnection cnn;
            SqlDataAdapter da;
            DataTable dt = new DataTable("MedAntPat");
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
}

