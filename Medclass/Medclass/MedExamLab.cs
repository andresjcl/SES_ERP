using System;
using System.Data;
using System.Data.SqlClient;
//

namespace DaxMedic
{
    public class MedExamLab
    {
        private System.String _IdExamen = "";
        private System.String _NombreExamen = "";
        private System.Boolean _ExamenCompuesto = false;
        private System.Boolean _ExamenComercial = false;
        private System.String _GrupoLaboratorio = "";
        private System.String _Metodo = "";
        private System.String _ValorReferencial1 = "";
        private System.String _ValorReferencial2 = "";
        private System.String _UnidadMedida = "";

        private string ajustarAncho(string cadena, int ancho)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder(new String(' ', ancho));
            return (cadena + sb.ToString()).Substring(0, ancho).Trim();
        }
        public System.String IdExamen
        {
            get
            {
                return ajustarAncho(_IdExamen, 20);
            }
            set
            {
                _IdExamen = value;
            }
        }
        public System.String NombreExamen
        {
            get
            {
                return ajustarAncho(_NombreExamen, 250);
            }
            set
            {
                _NombreExamen = value;
            }
        }
        public System.Boolean ExamenCompuesto
        {
            get
            {
                return _ExamenCompuesto;
            }
            set
            {
                _ExamenCompuesto = value;
            }
        }
        public System.Boolean ExamenComercial
        {
            get
            {
                return _ExamenComercial;
            }
            set
            {
                _ExamenComercial = value;
            }
        }
        public System.String GrupoLaboratorio
        {
            get
            {
                return ajustarAncho(_GrupoLaboratorio, 5);
            }
            set
            {
                _GrupoLaboratorio = value;
            }
        }
        public System.String Metodo
        {
            get
            {
                return ajustarAncho(_Metodo, 10);
            }
            set
            {
                _Metodo = value;
            }
        }
        public System.String ValorReferencial1
        {
            get
            {
                return ajustarAncho(_ValorReferencial1, 150);
            }
            set
            {
                _ValorReferencial1 = value;
            }
        }
        public System.String ValorReferencial2
        {
            get
            {
                return ajustarAncho(_ValorReferencial2, 150);
            }
            set
            {
                _ValorReferencial2 = value;
            }
        }
        public System.String UnidadMedida
        {
            get
            {
                return ajustarAncho(_UnidadMedida, 50);
            }
            set
            {
                _UnidadMedida = value;
            }
        }
        //
        // La cadena de conexión a la base de datos
        private static string cadenaConexion = @"Data Source=patoodax; Initial Catalog=BdAdcomDx14CLeones; Integrated Security=yes;";
        // La cadena de selección
        public static string CadenaSelect = "SELECT * FROM MedExamLab";
        //
        public MedExamLab()
        {
        }
        public MedExamLab(string conex)
        {
            cadenaConexion = conex;
        }
        //
        // Métodos compartidos (estáticos) privados
        //
        // asigna una fila de la tabla a un objeto MedExamLab
        private static MedExamLab row2MedExamLab(DataRow r)
        {
            // asigna a un objeto MedExamLab los datos del dataRow indicado
            MedExamLab oMedExamLab = new MedExamLab();
            //
            oMedExamLab.IdExamen = r["IdExamen"].ToString();
            oMedExamLab.NombreExamen = r["NombreExamen"].ToString();
            try
            {
                oMedExamLab.ExamenCompuesto = System.Boolean.Parse(r["ExamenCompuesto"].ToString());
            }
            catch
            {
                oMedExamLab.ExamenCompuesto = false;
            }
            try
            {
                oMedExamLab.ExamenComercial = System.Boolean.Parse(r["ExamenComercial"].ToString());
            }
            catch
            {
                oMedExamLab.ExamenComercial = false;
            }
            oMedExamLab.GrupoLaboratorio = r["GrupoLaboratorio"].ToString();
            oMedExamLab.Metodo = r["Metodo"].ToString();
            oMedExamLab.ValorReferencial1 = r["ValorReferencial1"].ToString();
            oMedExamLab.ValorReferencial2 = r["ValorReferencial2"].ToString();
            oMedExamLab.UnidadMedida = r["UnidadMedida"].ToString();
            //
            return oMedExamLab;
        }
        //
        // asigna un objeto MedExamLab a la fila indicada
        private static void MedExamLab2Row(MedExamLab oMedExamLab, DataRow r)
        {
            // asigna un objeto MedExamLab al dataRow indicado
            r["IdExamen"] = oMedExamLab.IdExamen;
            r["NombreExamen"] = oMedExamLab.NombreExamen;
            r["ExamenCompuesto"] = oMedExamLab.ExamenCompuesto;
            r["ExamenComercial"] = oMedExamLab.ExamenComercial;
            r["GrupoLaboratorio"] = oMedExamLab.GrupoLaboratorio;
            r["Metodo"] = oMedExamLab.Metodo;
            r["ValorReferencial1"] = oMedExamLab.ValorReferencial1;
            r["ValorReferencial2"] = oMedExamLab.ValorReferencial2;
            r["UnidadMedida"] = oMedExamLab.UnidadMedida;
        }
        //
        // crea una nueva fila y la asigna a un objeto MedExamLab
        private static void nuevoMedExamLab(DataTable dt, MedExamLab oMedExamLab)
        {
            // Crear un nuevo MedExamLab
            DataRow dr = dt.NewRow();
            MedExamLab oM = row2MedExamLab(dr);
            //
            oM.IdExamen = oMedExamLab.IdExamen;
            oM.NombreExamen = oMedExamLab.NombreExamen;
            oM.ExamenCompuesto = oMedExamLab.ExamenCompuesto;
            oM.ExamenComercial = oMedExamLab.ExamenComercial;
            oM.GrupoLaboratorio = oMedExamLab.GrupoLaboratorio;
            oM.Metodo = oMedExamLab.Metodo;
            oM.ValorReferencial1 = oMedExamLab.ValorReferencial1;
            oM.ValorReferencial2 = oMedExamLab.ValorReferencial2;
            oM.UnidadMedida = oMedExamLab.UnidadMedida;
            //
            MedExamLab2Row(oM, dr);
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
            // devuelve una tabla con los datos de la tabla MedExamLab
            SqlDataAdapter da;
            DataTable dt = new DataTable("MedExamLab");
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
        public static MedExamLab Buscar(string sWhere)
        {
            // Busca en la tabla los datos indicados en el parámetro
            // el parámetro contendrá lo que se usará después del WHERE
            MedExamLab oMedExamLab = null;
            SqlDataAdapter da;
            DataTable dt = new DataTable("MedExamLab");
            string sel = "SELECT * FROM MedExamLab WHERE " + sWhere;
            //
            da = new SqlDataAdapter(sel, cadenaConexion);
            da.Fill(dt);
            //
            if (dt.Rows.Count > 0)
            {
                oMedExamLab = row2MedExamLab(dt.Rows[0]);
            }
            return oMedExamLab;
        }
        public string Actualizar()
        {
            string sel = "SELECT * FROM MedExamLab WHERE IdExamen = '" + this.IdExamen + "'";
            return Actualizar(sel);
        }
        public string Actualizar(string sel)
        {
            SqlConnection cnn;
            SqlDataAdapter da;
            DataTable dt = new DataTable("MedExamLab");
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
                CadenaSelect = sel;            // crear uno nuevo
                return Crear();
            }
            else
            {
                MedExamLab2Row(this, dt.Rows[0]);
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
            DataTable dt = new DataTable("MedExamLab");
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
            nuevoMedExamLab(dt, this);
            //
            try
            {
                da.Update(dt);
                dt.AcceptChanges();
                return "Se ha creado un nuevo MedExamLab";
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
        }
        //
        public string Borrar()
        {
            string sel = "SELECT * FROM MedExamLab WHERE IdExamen = '" + this.IdExamen + "'";
            //
            return Borrar(sel);
        }
        public string Borrar(string sel)
        {
            SqlConnection cnn;
            SqlDataAdapter da;
            DataTable dt = new DataTable("MedExamLab");
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
    }
}
