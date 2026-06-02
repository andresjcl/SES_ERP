using System;
using System.Data;
using System.Data.SqlClient;

namespace DaxMedic
{
    public class MedAntEsti
    {
        private System.String _HistClinica= "";
        private System.Int32 _MinutosEjercicios= 0;
        private System.Int32 _HorasDuermeDia= 0;
        private System.String _DeportesPractica= "";
        private System.String _FrecuenciaDeportes= "";
        private System.Boolean _Desayuna= false;
        private System.Boolean _TomaRefrescos= false;
        private System.Int32 _ComidasDia= 0;
        private System.Int32 _TazasCafe= 0;
        private System.String _DietaPractica= "";
        private System.Boolean _ConsumeAlcohol= false;
        private System.Int32 _EdadIniciaConsAlcohol= 0;
        private System.Int32 _CopasVino= 0;
        private System.Int32 _VasosLicor= 0;
        private System.Int32 _CopasLicor= 0;
        private System.Boolean _ExAlcohol= false;
        private System.Int32 _EdadDejoAlcohol= 0;
        private System.Boolean _Fuma= false;
        private System.Int32 _EdadInicioFumar= 0;
        private System.Int32 _NroCigarrilloDiario= 0;
        private System.Boolean _ExFumador= false;
        private System.Int32 _EdadDejaFumar= 0;
        private System.Boolean _ConsumeDrogas= false;
        private System.Int32 _EdadInicioDrogas= 0;
        private System.Boolean _UsaDrogaIntravenosa= false;
        private System.Boolean _ExConsumidorDrogas= false;
        private System.Int32 _EdadDejoDrogas= 0;
        private System.String _EstiloVidaObs= "";
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
        public System.Int32 MinutosEjercicios
        {
            get
            {
                return _MinutosEjercicios;
            }
            set
            {
                _MinutosEjercicios = value;
            }
        }
        public System.Int32 HorasDuermeDia
        {
            get
            {
                return _HorasDuermeDia;
            }
            set
            {
                _HorasDuermeDia = value;
            }
        }
        public System.String DeportesPractica
        {
            get
            {
                return ajustarAncho(_DeportesPractica, 200);
            }
            set
            {
                _DeportesPractica = value;
            }
        }
        public System.String FrecuenciaDeportes
        {
            get
            {
                return ajustarAncho(_FrecuenciaDeportes, 100);
            }
            set
            {
                _FrecuenciaDeportes = value;
            }
        }
        public System.Boolean Desayuna
        {
            get
            {
                return _Desayuna;
            }
            set
            {
                _Desayuna = value;
            }
        }
        public System.Boolean TomaRefrescos
        {
            get
            {
                return _TomaRefrescos;
            }
            set
            {
                _TomaRefrescos = value;
            }
        }
        public System.Int32 ComidasDia
        {
            get
            {
                return _ComidasDia;
            }
            set
            {
                _ComidasDia = value;
            }
        }
        public System.Int32 TazasCafe
        {
            get
            {
                return _TazasCafe;
            }
            set
            {
                _TazasCafe = value;
            }
        }
        public System.String DietaPractica
        {
            get
            {
                return ajustarAncho(_DietaPractica, 250);
            }
            set
            {
                _DietaPractica = value;
            }
        }
        public System.Boolean ConsumeAlcohol
        {
            get
            {
                return _ConsumeAlcohol;
            }
            set
            {
                _ConsumeAlcohol = value;
            }
        }
        public System.Int32 EdadIniciaConsAlcohol
        {
            get
            {
                return _EdadIniciaConsAlcohol;
            }
            set
            {
                _EdadIniciaConsAlcohol = value;
            }
        }
        public System.Int32 CopasVino
        {
            get
            {
                return _CopasVino;
            }
            set
            {
                _CopasVino = value;
            }
        }
        public System.Int32 VasosLicor
        {
            get
            {
                return _VasosLicor;
            }
            set
            {
                _VasosLicor = value;
            }
        }
        public System.Int32 CopasLicor
        {
            get
            {
                return _CopasLicor;
            }
            set
            {
                _CopasLicor = value;
            }
        }
        public System.Boolean ExAlcohol
        {
            get
            {
                return _ExAlcohol;
            }
            set
            {
                _ExAlcohol = value;
            }
        }
        public System.Int32 EdadDejoAlcohol
        {
            get
            {
                return _EdadDejoAlcohol;
            }
            set
            {
                _EdadDejoAlcohol = value;
            }
        }
        public System.Boolean Fuma
        {
            get
            {
                return _Fuma;
            }
            set
            {
                _Fuma = value;
            }
        }
        public System.Int32 EdadInicioFumar
        {
            get
            {
                return _EdadInicioFumar;
            }
            set
            {
                _EdadInicioFumar = value;
            }
        }
        public System.Int32 NroCigarrilloDiario
        {
            get
            {
                return _NroCigarrilloDiario;
            }
            set
            {
                _NroCigarrilloDiario = value;
            }
        }
        public System.Boolean ExFumador
        {
            get
            {
                return _ExFumador;
            }
            set
            {
                _ExFumador = value;
            }
        }
        public System.Int32 EdadDejaFumar
        {
            get
            {
                return _EdadDejaFumar;
            }
            set
            {
                _EdadDejaFumar = value;
            }
        }
        public System.Boolean ConsumeDrogas
        {
            get
            {
                return _ConsumeDrogas;
            }
            set
            {
                _ConsumeDrogas = value;
            }
        }
        public System.Int32 EdadInicioDrogas
        {
            get
            {
                return _EdadInicioDrogas;
            }
            set
            {
                _EdadInicioDrogas = value;
            }
        }
        public System.Boolean UsaDrogaIntravenosa
        {
            get
            {
                return _UsaDrogaIntravenosa;
            }
            set
            {
                _UsaDrogaIntravenosa = value;
            }
        }
        public System.Boolean ExConsumidorDrogas
        {
            get
            {
                return _ExConsumidorDrogas;
            }
            set
            {
                _ExConsumidorDrogas = value;
            }
        }
        public System.Int32 EdadDejoDrogas
        {
            get
            {
                return _EdadDejoDrogas;
            }
            set
            {
                _EdadDejoDrogas = value;
            }
        }
        public System.String EstiloVidaObs
        {
            get
            {
                // Seguramente sería mejor sin ajustar el ancho...
                //return ajustarAncho(_EstiloVidaObs,2147483647);
                return _EstiloVidaObs;
            }
            set
            {
                _EstiloVidaObs = value;
            }
        }
        //
        //
        // Campos y métodos compartidos (estáticos) para gestionar la base de datos
        //
        // La cadena de conexión a la base de datos
        private static string cadenaConexion = @"Data Source=daxserver; Initial Catalog=BdAdcomDx14CLeones; user id=sa; password=1234qwerASDFZXCV";
        // La cadena de selección
        public static string CadenaSelect = "SELECT * FROM MedAntEsti";
        //
        public MedAntEsti()
        {
        }
        public MedAntEsti(string conex)
        {
            cadenaConexion = conex;
        }
        //
        // Métodos compartidos (estáticos) privados
        //
        // asigna una fila de la tabla a un objeto MedAntEsti
        private static MedAntEsti row2MedAntEsti(DataRow r)
        {
            // asigna a un objeto MedAntEsti los datos del dataRow indicado
            MedAntEsti oMedAntEsti = new MedAntEsti();
            //
            oMedAntEsti.HistClinica = r["HistClinica"].ToString();
            oMedAntEsti.MinutosEjercicios = System.Int32.Parse("0" + r["MinutosEjercicios"].ToString());
            oMedAntEsti.HorasDuermeDia = System.Int32.Parse("0" + r["HorasDuermeDia"].ToString());
            oMedAntEsti.DeportesPractica = r["DeportesPractica"].ToString();
            oMedAntEsti.FrecuenciaDeportes = r["FrecuenciaDeportes"].ToString();
            try
            {
                oMedAntEsti.Desayuna = System.Boolean.Parse(r["Desayuna"].ToString());
            }
            catch
            {
                oMedAntEsti.Desayuna = false;
            }
            try
            {
                oMedAntEsti.TomaRefrescos = System.Boolean.Parse(r["TomaRefrescos"].ToString());
            }
            catch
            {
                oMedAntEsti.TomaRefrescos = false;
            }
            oMedAntEsti.ComidasDia = System.Int32.Parse("0" + r["ComidasDia"].ToString());
            oMedAntEsti.TazasCafe = System.Int32.Parse("0" + r["TazasCafe"].ToString());
            oMedAntEsti.DietaPractica = r["DietaPractica"].ToString();
            try
            {
                oMedAntEsti.ConsumeAlcohol = System.Boolean.Parse(r["ConsumeAlcohol"].ToString());
            }
            catch
            {
                oMedAntEsti.ConsumeAlcohol = false;
            }
            oMedAntEsti.EdadIniciaConsAlcohol = System.Int32.Parse("0" + r["EdadIniciaConsAlcohol"].ToString());
            oMedAntEsti.CopasVino = System.Int32.Parse("0" + r["CopasVino"].ToString());
            oMedAntEsti.VasosLicor = System.Int32.Parse("0" + r["VasosLicor"].ToString());
            oMedAntEsti.CopasLicor = System.Int32.Parse("0" + r["CopasLicor"].ToString());
            try
            {
                oMedAntEsti.ExAlcohol = System.Boolean.Parse(r["ExAlcohol"].ToString());
            }
            catch
            {
                oMedAntEsti.ExAlcohol = false;
            }
            oMedAntEsti.EdadDejoAlcohol = System.Int32.Parse("0" + r["EdadDejoAlcohol"].ToString());
            try
            {
                oMedAntEsti.Fuma = System.Boolean.Parse(r["Fuma"].ToString());
            }
            catch
            {
                oMedAntEsti.Fuma = false;
            }
            oMedAntEsti.EdadInicioFumar = System.Int32.Parse("0" + r["EdadInicioFumar"].ToString());
            oMedAntEsti.NroCigarrilloDiario = System.Int32.Parse("0" + r["NroCigarrilloDiario"].ToString());
            try
            {
                oMedAntEsti.ExFumador = System.Boolean.Parse(r["ExFumador"].ToString());
            }
            catch
            {
                oMedAntEsti.ExFumador = false;
            }
            oMedAntEsti.EdadDejaFumar = System.Int32.Parse("0" + r["EdadDejaFumar"].ToString());
            try
            {
                oMedAntEsti.ConsumeDrogas = System.Boolean.Parse(r["ConsumeDrogas"].ToString());
            }
            catch
            {
                oMedAntEsti.ConsumeDrogas = false;
            }
            oMedAntEsti.EdadInicioDrogas = System.Int32.Parse("0" + r["EdadInicioDrogas"].ToString());
            try
            {
                oMedAntEsti.UsaDrogaIntravenosa = System.Boolean.Parse(r["UsaDrogaIntravenosa"].ToString());
            }
            catch
            {
                oMedAntEsti.UsaDrogaIntravenosa = false;
            }
            try
            {
                oMedAntEsti.ExConsumidorDrogas = System.Boolean.Parse(r["ExConsumidorDrogas"].ToString());
            }
            catch
            {
                oMedAntEsti.ExConsumidorDrogas = false;
            }
            oMedAntEsti.EdadDejoDrogas = System.Int32.Parse("0" + r["EdadDejoDrogas"].ToString());
            oMedAntEsti.EstiloVidaObs = r["EstiloVidaObs"].ToString();
            //
            return oMedAntEsti;
        }
        //
        // asigna un objeto MedAntEsti a la fila indicada
        private static void MedAntEsti2Row(MedAntEsti oMedAntEsti, DataRow r)
        {
            // asigna un objeto MedAntEsti al dataRow indicado
            r["HistClinica"] = oMedAntEsti.HistClinica;
            r["MinutosEjercicios"] = oMedAntEsti.MinutosEjercicios;
            r["HorasDuermeDia"] = oMedAntEsti.HorasDuermeDia;
            r["DeportesPractica"] = oMedAntEsti.DeportesPractica;
            r["FrecuenciaDeportes"] = oMedAntEsti.FrecuenciaDeportes;
            r["Desayuna"] = oMedAntEsti.Desayuna;
            r["TomaRefrescos"] = oMedAntEsti.TomaRefrescos;
            r["ComidasDia"] = oMedAntEsti.ComidasDia;
            r["TazasCafe"] = oMedAntEsti.TazasCafe;
            r["DietaPractica"] = oMedAntEsti.DietaPractica;
            r["ConsumeAlcohol"] = oMedAntEsti.ConsumeAlcohol;
            r["EdadIniciaConsAlcohol"] = oMedAntEsti.EdadIniciaConsAlcohol;
            r["CopasVino"] = oMedAntEsti.CopasVino;
            r["VasosLicor"] = oMedAntEsti.VasosLicor;
            r["CopasLicor"] = oMedAntEsti.CopasLicor;
            r["ExAlcohol"] = oMedAntEsti.ExAlcohol;
            r["EdadDejoAlcohol"] = oMedAntEsti.EdadDejoAlcohol;
            r["Fuma"] = oMedAntEsti.Fuma;
            r["EdadInicioFumar"] = oMedAntEsti.EdadInicioFumar;
            r["NroCigarrilloDiario"] = oMedAntEsti.NroCigarrilloDiario;
            r["ExFumador"] = oMedAntEsti.ExFumador;
            r["EdadDejaFumar"] = oMedAntEsti.EdadDejaFumar;
            r["ConsumeDrogas"] = oMedAntEsti.ConsumeDrogas;
            r["EdadInicioDrogas"] = oMedAntEsti.EdadInicioDrogas;
            r["UsaDrogaIntravenosa"] = oMedAntEsti.UsaDrogaIntravenosa;
            r["ExConsumidorDrogas"] = oMedAntEsti.ExConsumidorDrogas;
            r["EdadDejoDrogas"] = oMedAntEsti.EdadDejoDrogas;
            r["EstiloVidaObs"] = oMedAntEsti.EstiloVidaObs;
        }
        //
        // crea una nueva fila y la asigna a un objeto MedAntEsti
        private static void nuevoMedAntEsti(DataTable dt, MedAntEsti oMedAntEsti)
        {
            // Crear un nuevo MedAntEsti
            DataRow dr = dt.NewRow();
            MedAntEsti oD = row2MedAntEsti(dr);
            //
            oD.HistClinica = oMedAntEsti.HistClinica;
            oD.MinutosEjercicios = oMedAntEsti.MinutosEjercicios;
            oD.HorasDuermeDia = oMedAntEsti.HorasDuermeDia;
            oD.DeportesPractica = oMedAntEsti.DeportesPractica;
            oD.FrecuenciaDeportes = oMedAntEsti.FrecuenciaDeportes;
            oD.Desayuna = oMedAntEsti.Desayuna;
            oD.TomaRefrescos = oMedAntEsti.TomaRefrescos;
            oD.ComidasDia = oMedAntEsti.ComidasDia;
            oD.TazasCafe = oMedAntEsti.TazasCafe;
            oD.DietaPractica = oMedAntEsti.DietaPractica;
            oD.ConsumeAlcohol = oMedAntEsti.ConsumeAlcohol;
            oD.EdadIniciaConsAlcohol = oMedAntEsti.EdadIniciaConsAlcohol;
            oD.CopasVino = oMedAntEsti.CopasVino;
            oD.VasosLicor = oMedAntEsti.VasosLicor;
            oD.CopasLicor = oMedAntEsti.CopasLicor;
            oD.ExAlcohol = oMedAntEsti.ExAlcohol;
            oD.EdadDejoAlcohol = oMedAntEsti.EdadDejoAlcohol;
            oD.Fuma = oMedAntEsti.Fuma;
            oD.EdadInicioFumar = oMedAntEsti.EdadInicioFumar;
            oD.NroCigarrilloDiario = oMedAntEsti.NroCigarrilloDiario;
            oD.ExFumador = oMedAntEsti.ExFumador;
            oD.EdadDejaFumar = oMedAntEsti.EdadDejaFumar;
            oD.ConsumeDrogas = oMedAntEsti.ConsumeDrogas;
            oD.EdadInicioDrogas = oMedAntEsti.EdadInicioDrogas;
            oD.UsaDrogaIntravenosa = oMedAntEsti.UsaDrogaIntravenosa;
            oD.ExConsumidorDrogas = oMedAntEsti.ExConsumidorDrogas;
            oD.EdadDejoDrogas = oMedAntEsti.EdadDejoDrogas;
            oD.EstiloVidaObs = oMedAntEsti.EstiloVidaObs;
            //
            MedAntEsti2Row(oD, dr);
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
            // devuelve una tabla con los datos de la tabla MedAntEsti
            SqlDataAdapter da;
            DataTable dt = new DataTable("MedAntEsti");
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
        public static MedAntEsti Buscar(string sWhere)
        {
            // Busca en la tabla los datos indicados en el parámetro
            // el parámetro contendrá lo que se usará después del WHERE
            MedAntEsti oMedAntEsti = null;
            SqlDataAdapter da;
            DataTable dt = new DataTable("MedAntEsti");
            string sel = "SELECT * FROM MedAntEsti WHERE " + sWhere;
            //
            da = new SqlDataAdapter(sel, cadenaConexion);
            da.Fill(dt);
            //
            if (dt.Rows.Count > 0)
            {
                oMedAntEsti = row2MedAntEsti(dt.Rows[0]);
            }
            return oMedAntEsti;
        }
        public string Actualizar()
        {
            string sel = "SELECT * FROM MedAntEsti WHERE HistClinica = '" + this.HistClinica + "'";
            return Actualizar(sel);

        }
        public string Actualizar(string sel)
        {
            SqlConnection cnn;
            SqlDataAdapter da;
            DataTable dt = new DataTable("MedAntEsti");
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
                MedAntEsti2Row(this, dt.Rows[0]);
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
            DataTable dt = new DataTable("MedAntEsti");
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
            nuevoMedAntEsti(dt, this);
            //
            try
            {
                da.Update(dt);
                dt.AcceptChanges();
                return "Se ha creado un nuevo MedAntEsti";
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
        }
        //
        public string Borrar()
        {
            string sel = "SELECT * FROM MedAntEsti WHERE HistClinica = '" + this.HistClinica + "'";
            //
            return Borrar(sel);
        }
        public string Borrar(string sel)
        {
            // Borrar el registro al que apunta esta clase
            // En caso de error, devolverá la cadena de error empezando por ERROR:.
            SqlConnection cnn;
            SqlDataAdapter da;
            DataTable dt = new DataTable("MedAntEsti");
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
