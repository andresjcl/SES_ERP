using System;
using System.Data;
using System.Data.SqlClient;

namespace DaxMedic
{

    public class MedPedLabDet
    {
        private System.Decimal _NroPedido=0;
        private System.String _CodigoExamen="";
//        private System.String _Valor1="";
  //      private System.String _Valor2="";
//        private System.String _observacion="";
        private string ajustarAncho(string cadena, int ancho)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder(new String(' ', ancho));
            // devolver la cadena quitando los espacios en blanco
            // esto asegura que no se devolverá un tamaño mayor ni espacios "extras"
            return (cadena + sb.ToString()).Substring(0, ancho).Trim();
        }
        public System.Decimal NroPedido
        {
            get
            {
                return _NroPedido;
            }
            set
            {
                _NroPedido = value;
            }
        }
        public System.String CodigoExamen
        {
            get
            {
                return ajustarAncho(_CodigoExamen, 50);
            }
            set
            {
                _CodigoExamen = value;
            }
        }
        //public System.String Valor1
        //{
        //    get
        //    {
        //        return ajustarAncho(_Valor1, 150);
        //    }
        //    set
        //    {
        //        _Valor1 = value;
        //    }
        //}
        //public System.String Valor2
        //{
        //    get
        //    {
        //        return ajustarAncho(_Valor2, 150);
        //    }
        //    set
        //    {
        //        _Valor2 = value;
        //    }
        //}
        //public System.String observacion
        //{
        //    get
        //    {
        //        return ajustarAncho(_observacion, 200);
        //    }
        //    set
        //    {
        //        _observacion = value;
        //    }
        //}
        //
        private static string cadenaConexion = "";
        // La cadena de selección
        public static string CadenaSelect = "";
        //
        public MedPedLabDet()
        {
        }
        public MedPedLabDet(string conex)
        {
            cadenaConexion = conex;
        }
        private static MedPedLabDet row2MedPedLabDet(DataRow r)
        {
            // asigna a un objeto MedPedLabDet los datos del dataRow indicado
            MedPedLabDet oMedPedLabDet = new MedPedLabDet();
            //
            oMedPedLabDet.NroPedido = System.Decimal.Parse("0" + r["NroPedido"].ToString());
            oMedPedLabDet.CodigoExamen = r["CodigoExamen"].ToString();
            //oMedPedLabDet.Valor1 = r["Valor1"].ToString();
            //oMedPedLabDet.Valor2 = r["Valor2"].ToString();
//            oMedPedLabDet.observacion = r["observacion"].ToString();
            //
            return oMedPedLabDet;
        }
        //
        // asigna un objeto MedPedLabDet a la fila indicada
        private static void MedPedLabDet2Row(MedPedLabDet oMedPedLabDet, DataRow r)
        {
            // asigna un objeto MedPedLabDet al dataRow indicado
            r["NroPedido"] = oMedPedLabDet.NroPedido;
            r["CodigoExamen"] = oMedPedLabDet.CodigoExamen;
            //r["Valor1"] = oMedPedLabDet.Valor1;
            //r["Valor2"] = oMedPedLabDet.Valor2;
//            r["observacion"] = oMedPedLabDet.observacion;
        }

        //
        // crea una nueva fila y la asigna a un objeto MedPedLabDet
        private static void nuevoMedPedLabDet(DataTable dt, MedPedLabDet oMedPedLabDet)
        {
            // Crear un nuevo MedPedLabDet
            DataRow dr = dt.NewRow();
            MedPedLabDet oM = row2MedPedLabDet(dr);
            //
            oM.NroPedido = oMedPedLabDet.NroPedido;
            oM.CodigoExamen = oMedPedLabDet.CodigoExamen;
            //oM.Valor1 = oMedPedLabDet.Valor1;
            //oM.Valor2 = oMedPedLabDet.Valor2;
//            oM.observacion  = oMedPedLabDet.observacion;
            //
            MedPedLabDet2Row(oM, dr);
            //
            dt.Rows.Add(dr);
        }
        //
        public static DataTable Tabla()
        {
            return Tabla(CadenaSelect);
        }
        public static DataTable Tabla(string sel)
        {
            // devuelve una tabla con los datos de la tabla MedPedLabDet
            SqlDataAdapter da;
            DataTable dt = new DataTable("MedPedLabDet");
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
        public static MedPedLabDet Buscar(string sWhere)
        {
            // Busca en la tabla los datos indicados en el parámetro
            // el parámetro contendrá lo que se usará después del WHERE
            MedPedLabDet oMedPedLabDet = null;
            SqlDataAdapter da;
            DataTable dt = new DataTable("MedPedLabDet");
            string sel = "SELECT * FROM MedPedLabDet WHERE " + sWhere;
            //
            da = new SqlDataAdapter(sel, cadenaConexion);
            da.Fill(dt);
            //
            if (dt.Rows.Count > 0)
            {
                oMedPedLabDet = row2MedPedLabDet(dt.Rows[0]);
            }
            return oMedPedLabDet;
        }
        //
        public string Actualizar()
        {
            string sel = "SELECT * FROM MedPedLabDet WHERE NroPedido = " + this.NroPedido.ToString() + " and CodigoExamen ='" + this.CodigoExamen + "'";      
            return Actualizar(sel);
        }
        public string Actualizar(string sel)
        {
            CadenaSelect = sel;
            SqlConnection cnn;
            SqlDataAdapter da;
            DataTable dt = new DataTable("MedPedLabDet");
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
                MedPedLabDet2Row(this, dt.Rows[0]);
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
            SqlConnection cnn;
            SqlDataAdapter da;
            DataTable dt = new DataTable("MedPedLabDet");
            //
            cnn = new SqlConnection(cadenaConexion);
            cnn.Open();
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
            nuevoMedPedLabDet(dt, this);
            try
            {
                da.Update(dt);
                dt.AcceptChanges();
                return "Se ha creado un nuevo MedPedLabDet";
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
        }
        //
        public string Borrar()
        {
            string sel = "SELECT * FROM MedPedLabDet WHERE NroPedido = " + this.NroPedido.ToString() + " and CodigoExamen ='" + this.CodigoExamen + "'";
            //
            return Borrar(sel);
        }
        public string Borrar(string sel)
        {
            SqlConnection cnn;
            SqlDataAdapter da;
            DataTable dt = new DataTable("MedPedLabDet");
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
        static public void eliminarDatos(decimal nroPedido)
        {
            using (SqlConnection cnn = new SqlConnection(cadenaConexion))
            {
                cnn.Open();
                string ssql = "delete from MedPedLabDet where NroPedido = " + nroPedido.ToString();
                SqlCommand comm = new SqlCommand(ssql, cnn);
                comm.ExecuteNonQuery();
                comm.Dispose();
            }

        }
    }
}
