using System;
using System.Data;
using System.Data.SqlClient;

namespace DaxMedic
{
    public class MedDetHist
    {
        private System.String _HistClinica="";
        private decimal _NroConsulta =0;    // este valor siempre sera 0 para losregistros de expediente y el tendra valor para los rgistros de consultas
        private System.String _Accion="";
        private String _Detalle = "";
        private int _orden = 0;
        private string _Tipo = "";     //solo para diagnostico
        private string _CodCie = "";    // solo para diagnostico
        //
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
        public System.String Accion
        {
            get
            {
                return ajustarAncho(_Accion, 20);
            }
            set
            {
                _Accion = value;
            }
        }
        public System.String Detalle
        {
            get
            {
                return _Detalle;
            }
            set
            {
                _Detalle = value;
            }
        }
        public System.String Tipo
        {
            get
            {
                return _Tipo;
            }
            set
            {
                _Tipo = value;
            }
        }
        public System.String CodCie
        {
            get
            {
                return _CodCie;
            }
            set
            {
                _CodCie = value;
            }
        }
        public int orden
        {
            get
            {
                return _orden;
            }
            set
            {
                _orden = value;
            }
        }
        //
        private static string cadenaConexion = @"";
        // La cadena de selección
        public static string CadenaSelect = "";
        //
        public MedDetHist()
        {
        }
        public MedDetHist(string conex)
        {
            cadenaConexion = conex;
        }
        //
        // Métodos compartidos (estáticos) privados
        //
        // asigna una fila de la tabla a un objeto MedDetHist
        private static MedDetHist row2MedDetHist(DataRow r)
        {
            // asigna a un objeto MedDetHist los datos del dataRow indicado
            MedDetHist oMedDetHist = new MedDetHist();
            //
            oMedDetHist.HistClinica = r["HistClinica"].ToString();
            oMedDetHist.NroConsulta = System.Decimal.Parse("0" + r["NroConsulta"].ToString());
            oMedDetHist.Accion = r["Accion"].ToString();
            oMedDetHist.Detalle = r["Detalle"].ToString();
            oMedDetHist.Tipo = r["Tipo"].ToString();
            oMedDetHist.CodCie = r["CodCie"].ToString();
            oMedDetHist.orden = int.Parse("0" + r["orden"].ToString());
            //
            return oMedDetHist;
        }
        //
        // asigna un objeto MedDetHist a la fila indicada
        private static void MedDetHist2Row(MedDetHist oMedDetHist, DataRow r)
        {
            // asigna un objeto MedDetHist al dataRow indicado
            r["HistClinica"] = oMedDetHist.HistClinica;
            r["NroConsulta"] = oMedDetHist.NroConsulta;
            r["Accion"] = oMedDetHist.Accion;
            r["Detalle"] = oMedDetHist.Detalle;
            r["Tipo"] = oMedDetHist.Tipo;
            r["CodCie"] = oMedDetHist.CodCie;
            r["orden"] = oMedDetHist.orden;
        }
        //
        // crea una nueva fila y la asigna a un objeto MedDetHist
        private static void nuevoMedDetHist(DataTable dt, MedDetHist oMedDetHist)
        {
            // Crear un nuevo MedDetHist
            DataRow dr = dt.NewRow();
            MedDetHist oD = row2MedDetHist(dr);
            //
            oD.HistClinica = oMedDetHist.HistClinica;
            oD.NroConsulta = oMedDetHist.NroConsulta;
            oD.Accion = oMedDetHist.Accion;
            oD.Detalle = oMedDetHist.Detalle;
            oD.CodCie = oMedDetHist.CodCie;
            oD.Tipo = oMedDetHist.Tipo;
            oD.orden = oMedDetHist.orden;
            //
            MedDetHist2Row(oD, dr);
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
            // devuelve una tabla con los datos de la tabla MedDetHist
            SqlDataAdapter da;
            DataTable dt = new DataTable("MedDetHist");
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
        public static MedDetHist Buscar(string sWhere)
        {
            // Busca en la tabla los datos indicados en el parámetro
            // el parámetro contendrá lo que se usará después del WHERE
            MedDetHist oMedDetHist = null;
            SqlDataAdapter da;
            DataTable dt = new DataTable("MedDetHist");
            string sel = "SELECT * FROM MedDetHist WHERE " + sWhere;
            //
            da = new SqlDataAdapter(sel, cadenaConexion);
            da.Fill(dt);
            //
            if (dt.Rows.Count > 0)
            {
                oMedDetHist = row2MedDetHist(dt.Rows[0]);
            }
            return oMedDetHist;
        }
        //
        public string Actualizar()
        {
            string sel = "SELECT * FROM MedDetHist WHERE HistClinica = '" + HistClinica + "' and NroConsulta = " + NroConsulta.ToString() + " and Accion = '" + Accion + "' " ;
            return Actualizar(sel);
        }
        public string Actualizar(string sel)
        {
            // Actualiza los datos indicados
            // El parámetro, que es una cadena de selección, indicará el criterio de actualización
            //
            // En caso de error, devolverá la cadena empezando por ERROR.
            CadenaSelect = sel;
            SqlConnection cnn = new SqlConnection(cadenaConexion);
            cnn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sel, cnn);
            DataTable dt = new DataTable("MedDetHist");
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
                MedDetHist2Row(this, dt.Rows[0]);
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
            DataTable dt = new DataTable("MedDetHist");
            //
            cnn = new SqlConnection(cadenaConexion);
            cnn.Open();
            da = new SqlDataAdapter(CadenaSelect, cnn);
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            //da.InsertCommand = cb.GetInsertCommand();
            try
            {
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
            //
            nuevoMedDetHist(dt, this);
            //
            try
            {
                da.Update(dt);
                dt.AcceptChanges();
                return "Se ha creado un nuevo MedDetHist";
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
        }
        //
        public string Borrar()
        {
            string sel = "SELECT * FROM MedDetHist WHERE HistClinica = '" + HistClinica + "' and NroConsulta = " + NroConsulta.ToString() + " and Accion = '" + Accion + "'";
            //
            return Borrar(sel);
        }
        public string Borrar(string sel)
        {
            SqlConnection cnn;
            SqlDataAdapter da;
            DataTable dt = new DataTable("MedDetHist");
            //
            cnn = new SqlConnection(cadenaConexion);
            cnn.Open();
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
