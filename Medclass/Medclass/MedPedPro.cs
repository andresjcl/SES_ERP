using System;
using System.Data;
using System.Data.SqlClient;

namespace DaxMedic
{//

    public class MedPedPro
    {
        private decimal _NroPedido =0;
        private System.String _IdPaciente="";
        private System.Boolean _EsPedidoExterno=false;
        private System.Decimal  _IdConsulta=0;
        private System.String _DrSolicita="";
        private string _DrRealiza ="";
        private System.DateTime _FechaSolicitud=new DateTime(1900,1,1);
        private System.DateTime _FechaRealiza = new DateTime(1900, 1, 1);
        private System.String _Observaciones="";
        private string _CreadoPor = "";
        private string _ModificadoPor = "";
        private string _EvaluacionResultados = "";
        //
        private string ajustarAncho(string cadena, int ancho)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder(new String(' ', ancho));
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
        public System.String IdPaciente
        {
            get
            {
                return ajustarAncho(_IdPaciente, 10);
            }
            set
            {
                _IdPaciente = value;
            }
        }
        public System.Boolean EsPedidoExterno
        {
            get
            {
                return _EsPedidoExterno;
            }
            set
            {
                _EsPedidoExterno = value;
            }
        }
        public System.Decimal IdConsulta
        {
            get
            {
                return _IdConsulta;
            }
            set
            {
                _IdConsulta = value;
            }
        }
        public System.String DrSolicita
        {
            get
            {
                return ajustarAncho(_DrSolicita, 20);
            }
            set
            {
                _DrSolicita = value;
            }
        }
        public System.String DrRealiza
        {
            get
            {
                return ajustarAncho(_DrRealiza, 20);
            }
            set
            {
                _DrRealiza = value;
            }
        }
        public System.DateTime FechaSolicitud
        {
            get
            {
                return _FechaSolicitud;
            }
            set
            {
                _FechaSolicitud = value;
            }
        }
        public System.DateTime FechaRealiza
        {
            get
            {
                return _FechaRealiza;
            }
            set
            {
                _FechaRealiza = value;
            }
        }
        public System.String Observaciones
        {
            get
            {
                return ajustarAncho(_Observaciones,350);
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
                return ajustarAncho(_CreadoPor,50);
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
                return ajustarAncho(_ModificadoPor,50);
            }
            set
            {
                _ModificadoPor = value;
            }
        }
        public System.String EvaluacionResultados
        {
            get
            {
                return ajustarAncho(_EvaluacionResultados, 50);
            }
            set
            {
                _EvaluacionResultados = value;
            }
        }

        //
        private static string cadenaConexion = "";
        // La cadena de selección
        public static string CadenaSelect = "";
        //
        public MedPedPro()
        {
        }
        public MedPedPro(string conex)
        {
            cadenaConexion = conex;
        }
        private static MedPedPro row2MedPedPro(DataRow r)
        {
            // asigna a un objeto MedPedPro los datos del dataRow indicado
            MedPedPro oMedPedPro = new MedPedPro();
            //
            oMedPedPro.NroPedido = System.Decimal.Parse("0" + r["NroPedido"].ToString());
            oMedPedPro.IdPaciente = r["IdPaciente"].ToString();
            try
            {
                oMedPedPro.EsPedidoExterno = System.Boolean.Parse(r["EsPedidoExterno"].ToString());
            }
            catch
            {
                oMedPedPro.EsPedidoExterno = false;
            }
            oMedPedPro.IdConsulta = System.Decimal.Parse("0" + r["IdConsulta"].ToString());
            oMedPedPro.DrSolicita = r["DrSolicita"].ToString();
            oMedPedPro.DrRealiza = r["DrRealiza"].ToString();
            try
            {
                oMedPedPro.FechaSolicitud = DateTime.Parse(r["FechaSolicitud"].ToString());
            }
            catch
            {
                oMedPedPro.FechaSolicitud = DateTime.Now;
            }
            try
            {
                oMedPedPro.FechaRealiza = DateTime.Parse(r["FechaRealiza"].ToString());
            }
            catch
            {
                oMedPedPro.FechaRealiza = DateTime.Now;
            }
            oMedPedPro.Observaciones = r["Observaciones"].ToString();
            oMedPedPro.CreadoPor  = r["CreadoPor"].ToString();
            oMedPedPro.ModificadoPor = r["ModificadoPor"].ToString();
            oMedPedPro.EvaluacionResultados = r["EvaluacionResultados"].ToString();
            //
            return oMedPedPro;
        }
        //
        // asigna un objeto MedPedPro a la fila indicada
        private static void MedPedPro2Row(MedPedPro oMedPedPro, DataRow r)
        {
            // asigna un objeto MedPedPro al dataRow indicado
            r["NroPedido"] = oMedPedPro.NroPedido;
            r["IdPaciente"] = oMedPedPro.IdPaciente;
            r["EsPedidoExterno"] = oMedPedPro.EsPedidoExterno;
            r["IdConsulta"] = oMedPedPro.IdConsulta;
            r["DrSolicita"] = oMedPedPro.DrSolicita;
            r["DrRealiza"] = oMedPedPro.DrRealiza;
            r["FechaSolicitud"] = oMedPedPro.FechaSolicitud;
            r["FechaRealiza"] = oMedPedPro.FechaRealiza;
            r["Observaciones"] = oMedPedPro.Observaciones;
            r["CreadoPor"] = oMedPedPro.CreadoPor;
            r["ModificadoPor"] = oMedPedPro.ModificadoPor;
            r["EvaluacionResultados"] = oMedPedPro.EvaluacionResultados;
        }
        //
        // crea una nueva fila y la asigna a un objeto MedPedPro
        private static void nuevoMedPedPro(DataTable dt, MedPedPro oMedPedPro)
        {
            // Crear un nuevo MedPedPro
            DataRow dr = dt.NewRow();
            MedPedPro oM = row2MedPedPro(dr);
            //
            oM.NroPedido = oMedPedPro.NroPedido;
            oM.IdPaciente = oMedPedPro.IdPaciente;
            oM.EsPedidoExterno = oMedPedPro.EsPedidoExterno;
            oM.IdConsulta = oMedPedPro.IdConsulta;
            oM.DrSolicita = oMedPedPro.DrSolicita;
            oM.DrRealiza = oMedPedPro.DrRealiza;
            oM.FechaSolicitud = oMedPedPro.FechaSolicitud;
            oM.FechaRealiza = oMedPedPro.FechaRealiza;
            oM.Observaciones = oMedPedPro.Observaciones;
            oM.CreadoPor = oMedPedPro.CreadoPor;
            oM.ModificadoPor = oMedPedPro.ModificadoPor;
            oM.EvaluacionResultados = oMedPedPro.EvaluacionResultados;
            //
            MedPedPro2Row(oM, dr);
            //
            dt.Rows.Add(dr);
        }
        public static DataTable Tabla()
        {
            return Tabla(CadenaSelect);
        }
        public static DataTable Tabla(string sel)
        {
            // devuelve una tabla con los datos de la tabla MedPedPro
            SqlDataAdapter da;
            DataTable dt = new DataTable("MedPedPro");
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
        public static MedPedPro Buscar(string sWhere)
        {
            // Busca en la tabla los datos indicados en el parámetro
            // el parámetro contendrá lo que se usará después del WHERE
            MedPedPro oMedPedPro = null;
            SqlDataAdapter da;
            DataTable dt = new DataTable("MedPedPro");
            string sel = "SELECT * FROM MedPedPro WHERE " + sWhere;
            //
            da = new SqlDataAdapter(sel, cadenaConexion);
            da.Fill(dt);
            //
            if (dt.Rows.Count > 0)
            {
                oMedPedPro = row2MedPedPro(dt.Rows[0]);
            }
            return oMedPedPro;
        }
        //
        // Actualizar: Actualiza los datos en la tabla usando la instancia actual
        //             Si la instancia no hace referencia a un registro existente, se creará uno nuevo
        //             Para comprobar si el objeto en memoria coincide con uno existente,
        //             se comprueba si el NroPedido existe en la tabla.
        public string Actualizar()
        {
            string sel = "SELECT * FROM MedPedPro WHERE NroPedido = " + this.NroPedido.ToString();
            return Actualizar(sel);
        }
        public string Actualizar(string sel)
        {
            CadenaSelect = sel;
            if (NroPedido == 0) return Crear();
            SqlConnection cnn;
            SqlDataAdapter da;
            DataTable dt = new DataTable("MedPedPro");
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
                MedPedPro2Row(this, dt.Rows[0]);
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
        private Decimal NuevoNumeroPedido()
        {
            decimal nvaClave = 0;
            string ssql = "Select max(NroPedido) as Valor from MedPedPro";
            using (SqlConnection cnn = new SqlConnection(cadenaConexion))
            {
                cnn.Open();
                SqlCommand comm = new SqlCommand(ssql, cnn);
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.Read()) nvaClave = Convert.ToDecimal("0"+dr["Valor"].ToString()) + 1;
                comm.Dispose();
                dr.Close();
                cnn.Dispose();
            }
            return nvaClave;
        }
        public string Crear()
        {
            NroPedido = NuevoNumeroPedido();
            CadenaSelect = "SELECT * FROM MedPedPro WHERE NroPedido = " + this.NroPedido.ToString();
            SqlConnection cnn;
            SqlDataAdapter da;
            DataTable dt = new DataTable("MedPedPro");
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
            nuevoMedPedPro(dt, this);
            //
            try
            {
                da.Update(dt);
                dt.AcceptChanges();
                return "Se ha creado un nuevo MedPedPro";
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
        }
        //
        public string Borrar()
        {
            string sel = "SELECT * FROM MedPedPro WHERE NroPedido = " + this.NroPedido.ToString();
            //
            return Borrar(sel);
        }
        public string Borrar(string sel)
        {
            SqlConnection cnn;
            SqlDataAdapter da;
            DataTable dt = new DataTable("MedPedPro");
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
        public decimal NuevoCodigo()
        {
            decimal nvo = 0;
            using (SqlConnection cnn = new SqlConnection(cadenaConexion))
            {
                cnn.Open();
                string ssql = "SELECT max(NroPedido) as maxNro FROM MedPedPro";
                SqlCommand comm = new SqlCommand(ssql, cnn);
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.Read())
                {
                    try { nvo = Convert.ToDecimal(dr["maxNro"]); }catch { nvo = 0;}
                }
                dr.Close();
                comm.Dispose();
            }
            return nvo+1;
        }
    }
}
