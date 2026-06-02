using System;
using System.Data;
using System.Data.SqlClient;

namespace DaxMedic
{
    public class MedAntPer
    {
        // Las variables privadas
        // TODO: Revisar los tipos de los campos
        private System.String _HistClinica="";
        private System.Boolean _PartoNormal=false;
        private System.Boolean _Cesarea=false;
        private System.String _SitioParto = "";
        private System.String _HoraParto = "";
        private System.Int32 _NroGestacion=0;
        private System.Int32 _EdadGestacionaria=0;
        private System.Decimal _Peso=0;
        private System.Decimal _Talla=0;
        private System.Decimal _PerCefalico=0;
        private System.Decimal _PerToraxico=0;
        private System.Decimal _PerAbdominal;
        private System.String _TipoAnastesia="";
        private System.Boolean _AppneaNeonatal=false ;
        private System.Boolean _Hemorragia=false;
        private System.Boolean _Convulsiones=false;
        private System.Boolean _Cianosis=false;
        private System.Boolean _Icterisia=false ;
        private System.String _PerinatalObs = "";
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
        public System.Boolean PartoNormal
        {
            get
            {
                return _PartoNormal;
            }
            set
            {
                _PartoNormal = value;
            }
        }
        public System.Boolean Cesarea
        {
            get
            {
                return _Cesarea;
            }
            set
            {
                _Cesarea = value;
            }
        }
        public System.String SitioParto
        {
            get
            {
                return ajustarAncho(_SitioParto, 50);
            }
            set
            {
                _SitioParto = value;
            }
        }
        public System.String HoraParto
        {
            get
            {
                return ajustarAncho(_HoraParto, 10);
            }
            set
            {
                _HoraParto = value;
            }
        }
        public System.Int32 NroGestacion
        {
            get
            {
                return _NroGestacion;
            }
            set
            {
                _NroGestacion = value;
            }
        }
        public System.Int32 EdadGestacionaria
        {
            get
            {
                return _EdadGestacionaria;
            }
            set
            {
                _EdadGestacionaria = value;
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
        public System.Decimal Talla
        {
            get
            {
                return _Talla;
            }
            set
            {
                _Talla = value;
            }
        }
        public System.Decimal PerCefalico
        {
            get
            {
                return _PerCefalico;
            }
            set
            {
                _PerCefalico = value;
            }
        }
        public System.Decimal PerToraxico
        {
            get
            {
                return _PerToraxico;
            }
            set
            {
                _PerToraxico = value;
            }
        }
        public System.Decimal PerAbdominal
        {
            get
            {
                return _PerAbdominal;
            }
            set
            {
                _PerAbdominal = value;
            }
        }
        public System.String TipoAnastesia
        {
            get
            {
                return ajustarAncho(_TipoAnastesia, 50);
            }
            set
            {
                _TipoAnastesia = value;
            }
        }
        public System.Boolean AppneaNeonatal
        {
            get
            {
                return _AppneaNeonatal;
            }
            set
            {
                _AppneaNeonatal = value;
            }
        }
        public System.Boolean Hemorragia
        {
            get
            {
                return _Hemorragia;
            }
            set
            {
                _Hemorragia = value;
            }
        }
        public System.Boolean Convulsiones
        {
            get
            {
                return _Convulsiones;
            }
            set
            {
                _Convulsiones = value;
            }
        }
        public System.Boolean Cianosis
        {
            get
            {
                return _Cianosis;
            }
            set
            {
                _Cianosis = value;
            }
        }
        public System.Boolean Icterisia
        {
            get
            {
                return _Icterisia;
            }
            set
            {
                _Icterisia = value;
            }
        }
        public System.String PerinatalObs
        {
            get
            {
                // Seguramente sería mejor sin ajustar el ancho...
                //return ajustarAncho(_PerinatalObs,2147483647);
                return _PerinatalObs;
            }
            set
            {
                _PerinatalObs = value;
            }
        }
        //
        //
        // Campos y métodos compartidos (estáticos) para gestionar la base de datos
        //
        // La cadena de conexión a la base de datos
        private static string cadenaConexion = @"Data Source=daxserver; Initial Catalog=BdAdcomDx14CLeones; user id=sa; password=1234qwerASDFZXCV";
        // La cadena de selección
        public static string CadenaSelect = "SELECT * FROM MedAntPer";
        //
        public MedAntPer()
        {
        }
        public MedAntPer(string conex)
        {
            cadenaConexion = conex;
        }
        //
        // Métodos compartidos (estáticos) privados
        //
        // asigna una fila de la tabla a un objeto MedAntPer
        private static MedAntPer row2MedAntPer(DataRow r)
        {
            // asigna a un objeto MedAntPer los datos del dataRow indicado
            MedAntPer oMedAntPer = new MedAntPer();
            //
            oMedAntPer.HistClinica = r["HistClinica"].ToString();
            try
            {
                oMedAntPer.PartoNormal = System.Boolean.Parse(r["PartoNormal"].ToString());
            }
            catch
            {
                oMedAntPer.PartoNormal = false;
            }
            try
            {
                oMedAntPer.Cesarea = System.Boolean.Parse(r["Cesarea"].ToString());
            }
            catch
            {
                oMedAntPer.Cesarea = false;
            }
            oMedAntPer.SitioParto = r["SitioParto"].ToString();
            oMedAntPer.HoraParto = r["HoraParto"].ToString();
            oMedAntPer.NroGestacion = System.Int32.Parse("0" + r["NroGestacion"].ToString());
            oMedAntPer.EdadGestacionaria = System.Int32.Parse("0" + r["EdadGestacionaria"].ToString());
            oMedAntPer.Peso = System.Decimal.Parse("0" + r["Peso"].ToString());
            oMedAntPer.Talla = System.Decimal.Parse("0" + r["Talla"].ToString());
            oMedAntPer.PerCefalico = System.Decimal.Parse("0" + r["PerCefalico"].ToString());
            oMedAntPer.PerToraxico = System.Decimal.Parse("0" + r["PerToraxico"].ToString());
            oMedAntPer.PerAbdominal = System.Decimal.Parse("0" + r["PerAbdominal"].ToString());
            oMedAntPer.TipoAnastesia = r["TipoAnastesia"].ToString();
            try
            {
                oMedAntPer.AppneaNeonatal = System.Boolean.Parse(r["AppneaNeonatal"].ToString());
            }
            catch
            {
                oMedAntPer.AppneaNeonatal = false;
            }
            try
            {
                oMedAntPer.Hemorragia = System.Boolean.Parse(r["Hemorragia"].ToString());
            }
            catch
            {
                oMedAntPer.Hemorragia = false;
            }
            try
            {
                oMedAntPer.Convulsiones = System.Boolean.Parse(r["Convulsiones"].ToString());
            }
            catch
            {
                oMedAntPer.Convulsiones = false;
            }
            try
            {
                oMedAntPer.Cianosis = System.Boolean.Parse(r["Cianosis"].ToString());
            }
            catch
            {
                oMedAntPer.Cianosis = false;
            }
            try
            {
                oMedAntPer.Icterisia = System.Boolean.Parse(r["Icterisia"].ToString());
            }
            catch
            {
                oMedAntPer.Icterisia = false;
            }
            oMedAntPer.PerinatalObs = r["PerinatalObs"].ToString();
            //
            return oMedAntPer;
        }
        //
        // asigna un objeto MedAntPer a la fila indicada
        private static void MedAntPer2Row(MedAntPer oMedAntPer, DataRow r)
        {
            // asigna un objeto MedAntPer al dataRow indicado
            r["HistClinica"] = oMedAntPer.HistClinica;
            r["PartoNormal"] = oMedAntPer.PartoNormal;
            r["Cesarea"] = oMedAntPer.Cesarea;
            r["SitioParto"] = oMedAntPer.SitioParto;
            r["HoraParto"] = oMedAntPer.HoraParto;
            r["NroGestacion"] = oMedAntPer.NroGestacion;
            r["EdadGestacionaria"] = oMedAntPer.EdadGestacionaria;
            r["Peso"] = oMedAntPer.Peso;
            r["Talla"] = oMedAntPer.Talla;
            r["PerCefalico"] = oMedAntPer.PerCefalico;
            r["PerToraxico"] = oMedAntPer.PerToraxico;
            r["PerAbdominal"] = oMedAntPer.PerAbdominal;
            r["TipoAnastesia"] = oMedAntPer.TipoAnastesia;
            r["AppneaNeonatal"] = oMedAntPer.AppneaNeonatal;
            r["Hemorragia"] = oMedAntPer.Hemorragia;
            r["Convulsiones"] = oMedAntPer.Convulsiones;
            r["Cianosis"] = oMedAntPer.Cianosis;
            r["Icterisia"] = oMedAntPer.Icterisia;
            r["PerinatalObs"] = oMedAntPer.PerinatalObs;
        }
        //
        // crea una nueva fila y la asigna a un objeto MedAntPer
        private static void nuevoMedAntPer(DataTable dt, MedAntPer oMedAntPer)
        {
            // Crear un nuevo MedAntPer
            DataRow dr = dt.NewRow();
            MedAntPer oD = row2MedAntPer(dr);
            //
            oD.HistClinica = oMedAntPer.HistClinica;
            oD.PartoNormal = oMedAntPer.PartoNormal;
            oD.Cesarea = oMedAntPer.Cesarea;
            oD.SitioParto = oMedAntPer.SitioParto;
            oD.HoraParto = oMedAntPer.HoraParto;
            oD.NroGestacion = oMedAntPer.NroGestacion;
            oD.EdadGestacionaria = oMedAntPer.EdadGestacionaria;
            oD.Peso = oMedAntPer.Peso;
            oD.Talla = oMedAntPer.Talla;
            oD.PerCefalico = oMedAntPer.PerCefalico;
            oD.PerToraxico = oMedAntPer.PerToraxico;
            oD.PerAbdominal = oMedAntPer.PerAbdominal;
            oD.TipoAnastesia = oMedAntPer.TipoAnastesia;
            oD.AppneaNeonatal = oMedAntPer.AppneaNeonatal;
            oD.Hemorragia = oMedAntPer.Hemorragia;
            oD.Convulsiones = oMedAntPer.Convulsiones;
            oD.Cianosis = oMedAntPer.Cianosis;
            oD.Icterisia = oMedAntPer.Icterisia;
            oD.PerinatalObs = oMedAntPer.PerinatalObs;
            //
            MedAntPer2Row(oD, dr);
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
            // devuelve una tabla con los datos de la tabla MedAntPer
            SqlDataAdapter da;
            DataTable dt = new DataTable("MedAntPer");
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
        public static MedAntPer Buscar(string sWhere)
        {
            MedAntPer oMedAntPer = null;
            SqlDataAdapter da;
            DataTable dt = new DataTable("MedAntPer");
            string sel = "SELECT * FROM MedAntPer WHERE " + sWhere;
            //
            da = new SqlDataAdapter(sel, cadenaConexion);
            da.Fill(dt);
            //
            if (dt.Rows.Count > 0)
            {
                oMedAntPer = row2MedAntPer(dt.Rows[0]);
            }
            return oMedAntPer;
        }
        public string Actualizar()
        {
            string sel = "SELECT * FROM MedAntPer WHERE HistClinica = '" + this.HistClinica + "'";
            return Actualizar(sel);
        }
        public string Actualizar(string sel)
        {
            SqlConnection cnn;
            SqlDataAdapter da;
            DataTable dt = new DataTable("MedAntPer");
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
                CadenaSelect = sel;
                return Crear();
            }
            else
            {
                MedAntPer2Row(this, dt.Rows[0]);
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
            DataTable dt = new DataTable("MedAntPer");
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
            nuevoMedAntPer(dt, this);
            //
            try
            {
                da.Update(dt);
                dt.AcceptChanges();
                return "Se ha creado un nuevo MedAntPer";
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
        }
        //
        public string Borrar()
        {
            string sel = "SELECT * FROM MedAntPer WHERE HistClinica = '" + this.HistClinica + "'";
            //
            return Borrar(sel);
        }
        public string Borrar(string sel)
        {
            SqlConnection cnn;
            SqlDataAdapter da;
            DataTable dt = new DataTable("MedAntPer");
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
