using System;
using System.Data;
using System.Data.SqlClient;

namespace ClassDoc
{
public class DescPromo
    {
        private System.String _DES_NOMBRE="";
        private System.String _DES_ALMACENes1="";
        private System.Decimal _DES_PORCEN=0;
        private System.String _DES_SNIVA="";
        private System.Boolean _DES_SN=false ;
        private System.String _Des_IdCta="";
        private System.Decimal _DES_Valor=0;
        private System.Decimal _Desc_ClaveId=0;
        private System.String _Des_IdCta2="";
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
        public System.String DES_NOMBRE
        {
            get
            {
                return ajustarAncho(_DES_NOMBRE, 50);
            }
            set
            {
                _DES_NOMBRE = value;
            }
        }
        public System.String DES_ALMACENes1
        {
            get
            {
                return _DES_ALMACENes1;
            }
            set
            {
                _DES_ALMACENes1 = value;
            }
        }
        public System.Decimal DES_PORCEN
        {
            get
            {
                return _DES_PORCEN;
            }
            set
            {
                _DES_PORCEN = value;
            }
        }
        public System.String DES_SNIVA
        {
            get
            {
                return ajustarAncho(_DES_SNIVA, 50);
            }
            set
            {
                _DES_SNIVA = value;
            }
        }
        public System.Boolean DES_SN
        {
            get
            {
                return _DES_SN;
            }
            set
            {
                _DES_SN = value;
            }
        }
        public System.String Des_IdCta
        {
            get
            {
                return ajustarAncho(_Des_IdCta, 15);
            }
            set
            {
                _Des_IdCta = value;
            }
        }
        public System.Decimal DES_Valor
        {
            get
            {
                return _DES_Valor;
            }
            set
            {
                _DES_Valor = value;
            }
        }
        public System.Decimal Desc_ClaveId
        {
            get
            {
                return _Desc_ClaveId;
            }
            set
            {
                _Desc_ClaveId = value;
            }
        }
        public System.String Des_IdCta2
        {
            get
            {
                return ajustarAncho(_Des_IdCta2, 50);
            }
            set
            {
                _Des_IdCta2 = value;
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
        public DescPromo()
        {
        }
        public DescPromo(string conex)
        {
            cadenaConexion = conex;
        }
        //
        // Métodos compartidos (estáticos) privados
        //
        // asigna una fila de la tabla a un objeto DescPromo
        private static DescPromo row2DescPromo(DataRow r)
        {
            // asigna a un objeto DescPromo los datos del dataRow indicado
            DescPromo oDescPromo = new DescPromo();
            //
            oDescPromo.DES_NOMBRE = r["DES_NOMBRE"].ToString();
            oDescPromo.DES_ALMACENes1 = r["DES_ALMACENes1"].ToString();
            oDescPromo.DES_PORCEN = System.Decimal.Parse("0" + r["DES_PORCEN"].ToString());
            oDescPromo.DES_SNIVA = r["DES_SNIVA"].ToString();
            try
            {
                oDescPromo.DES_SN = System.Boolean.Parse(r["DES_SN"].ToString());
            }
            catch
            {
                oDescPromo.DES_SN = false;
            }
            oDescPromo.Des_IdCta = r["Des_IdCta"].ToString();
            oDescPromo.DES_Valor = System.Decimal.Parse("0" + r["DES_Valor"].ToString());
            oDescPromo.Desc_ClaveId = System.Decimal.Parse("0" + r["Desc_ClaveId"].ToString());
            oDescPromo.Des_IdCta2 = r["Des_IdCta2"].ToString();
            //
            return oDescPromo;
        }
        //
        // asigna un objeto DescPromo a la fila indicada
        private static void DescPromo2Row(DescPromo oDescPromo, DataRow r)
        {
            // asigna un objeto DescPromo al dataRow indicado
            r["DES_NOMBRE"] = oDescPromo.DES_NOMBRE;
            r["DES_ALMACENes1"] = oDescPromo.DES_ALMACENes1;
            r["DES_PORCEN"] = oDescPromo.DES_PORCEN;
            r["DES_SNIVA"] = oDescPromo.DES_SNIVA;
            r["DES_SN"] = oDescPromo.DES_SN;
            r["Des_IdCta"] = oDescPromo.Des_IdCta;
            r["DES_Valor"] = oDescPromo.DES_Valor;
            r["Des_IdCta2"] = oDescPromo.Des_IdCta2;
        }
        //
        // crea una nueva fila y la asigna a un objeto DescPromo
        private static void nuevoDescPromo(DataTable dt, DescPromo oDescPromo)
        {
            // Crear un nuevo DescPromo
            DataRow dr = dt.NewRow();
            DescPromo oD = row2DescPromo(dr);
            //
            oD.DES_NOMBRE = oDescPromo.DES_NOMBRE;
            oD.DES_ALMACENes1 = oDescPromo.DES_ALMACENes1;
            oD.DES_PORCEN = oDescPromo.DES_PORCEN;
            oD.DES_SNIVA = oDescPromo.DES_SNIVA;
            oD.DES_SN = oDescPromo.DES_SN;
            oD.Des_IdCta = oDescPromo.Des_IdCta;
            oD.DES_Valor = oDescPromo.DES_Valor;
            oD.Desc_ClaveId = oDescPromo.Desc_ClaveId;
            oD.Des_IdCta2 = oDescPromo.Des_IdCta2;
            //
            DescPromo2Row(oD, dr);
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
            // devuelve una tabla con los datos de la tabla DescPromo
            SqlDataAdapter da;
            DataTable dt = new DataTable("DescPromo");
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
        public static DescPromo Buscar(string sWhere)
        {
            // Busca en la tabla los datos indicados en el parámetro
            // el parámetro contendrá lo que se usará después del WHERE
            DescPromo oDescPromo = null;
            SqlDataAdapter da;
            DataTable dt = new DataTable("DescPromo");
            string sel = "SELECT * FROM DescPromo WHERE " + sWhere;
            //
            da = new SqlDataAdapter(sel, cadenaConexion);
            da.Fill(dt);
            //
            if (dt.Rows.Count > 0)
            {
                oDescPromo = row2DescPromo(dt.Rows[0]);
            }
            return oDescPromo;
        }
        //
        public string Actualizar()
        {
            string sel = "SELECT * FROM DescPromo WHERE Desc_ClaveId = " + this.Desc_ClaveId.ToString();
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
            DataTable dt = new DataTable("DescPromo");
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
                CadenaSelect = sel;
                return Crear();
            }
            else
            {
                DescPromo2Row(this, dt.Rows[0]);
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
            DataTable dt = new DataTable("DescPromo");
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
            nuevoDescPromo(dt, this);
            //
            try
            {
                da.Update(dt);
                dt.AcceptChanges();
                return "Se ha creado un nuevo DescPromo";
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
        }
        //
        public string Borrar()
        {
            string sel = "SELECT * FROM DescPromo WHERE Desc_ClaveId = " + this.Desc_ClaveId.ToString();
            //
            return Borrar(sel);
        }
        public string Borrar(string sel)
        {
            SqlConnection cnn;
            SqlDataAdapter da;
            DataTable dt = new DataTable("DescPromo");
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
