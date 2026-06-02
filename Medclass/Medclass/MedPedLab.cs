using System;
using System.Data;
using System.Data.SqlClient;

namespace DaxMedic
{//

    public class MedPedLab
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
        private string _Factura = "";
        private string _Muestras = "";
        //
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
        public System.String IdPaciente
        {
            get
            {
                return ajustarAncho(_IdPaciente, 15);
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
                return _EvaluacionResultados;
            }
            set
            {
                _EvaluacionResultados = value;
            }
        }
        public System.String Factura
        {
            get
            {
                return ajustarAncho(_Factura, 50);
            }
            set
            {
                _Factura = value;
            }
        }
        public System.String Muestras
        {
            get
            {
                return ajustarAncho(_Muestras, 200);
            }
            set
            {
                _Muestras = value;
            }
        }

        //
        private static string cadenaConexion = "";
        // La cadena de selección
        public static string CadenaSelect = "";
        //
        public MedPedLab()
        {
        }
        public MedPedLab(string conex)
        {
            cadenaConexion = conex;
        }
        private static MedPedLab row2MedPedLab(DataRow r)
        {
            // asigna a un objeto MedPedLab los datos del dataRow indicado
            MedPedLab oMedPedLab = new MedPedLab();
            //
            oMedPedLab.NroPedido = System.Decimal.Parse("0" + r["NroPedido"].ToString());
            oMedPedLab.IdPaciente = r["IdPaciente"].ToString();
            try
            {
                oMedPedLab.EsPedidoExterno = System.Boolean.Parse(r["EsPedidoExterno"].ToString());
            }
            catch
            {
                oMedPedLab.EsPedidoExterno = false;
            }
            oMedPedLab.IdConsulta = System.Decimal.Parse("0" + r["IdConsulta"].ToString());
            oMedPedLab.DrSolicita = r["DrSolicita"].ToString();
            oMedPedLab.DrRealiza = r["DrRealiza"].ToString();
            try
            {
                oMedPedLab.FechaSolicitud = DateTime.Parse(r["FechaSolicitud"].ToString());
            }
            catch
            {
                oMedPedLab.FechaSolicitud = DateTime.Now;
            }
            try
            {
                oMedPedLab.FechaRealiza = DateTime.Parse(r["FechaRealiza"].ToString());
            }
            catch
            {
                oMedPedLab.FechaRealiza = DateTime.Now;
            }
            oMedPedLab.Observaciones = r["Observaciones"].ToString();
            oMedPedLab.CreadoPor  = r["CreadoPor"].ToString();
            oMedPedLab.ModificadoPor = r["ModificadoPor"].ToString();
            oMedPedLab.EvaluacionResultados = r["EvaluacionResultados"].ToString();
            oMedPedLab.Factura = r["Factura"].ToString();
            oMedPedLab.Muestras = r["MUESTRAS"].ToString();
            //
            return oMedPedLab;
        }
        //
        // asigna un objeto MedPedLab a la fila indicada
        private static void MedPedLab2Row(MedPedLab oMedPedLab, DataRow r)
        {
            // asigna un objeto MedPedLab al dataRow indicado
            r["NroPedido"] = oMedPedLab.NroPedido;
            r["IdPaciente"] = oMedPedLab.IdPaciente;
            r["EsPedidoExterno"] = oMedPedLab.EsPedidoExterno;
            r["IdConsulta"] = oMedPedLab.IdConsulta;
            r["DrSolicita"] = oMedPedLab.DrSolicita;
            r["DrRealiza"] = oMedPedLab.DrRealiza;
            r["FechaSolicitud"] = oMedPedLab.FechaSolicitud;
            r["FechaRealiza"] = oMedPedLab.FechaRealiza;
            r["Observaciones"] = oMedPedLab.Observaciones;
            r["CreadoPor"] = oMedPedLab.CreadoPor;
            r["ModificadoPor"] = oMedPedLab.ModificadoPor;
            r["EvaluacionResultados"] = oMedPedLab.EvaluacionResultados;
            r["Factura"] = oMedPedLab.Factura;
        }
        //
        // crea una nueva fila y la asigna a un objeto MedPedLab
        private static void nuevoMedPedLab(DataTable dt, MedPedLab oMedPedLab)
        {
            // Crear un nuevo MedPedLab
            DataRow dr = dt.NewRow();
            MedPedLab oM = row2MedPedLab(dr);
            //
            oM.NroPedido = oMedPedLab.NroPedido;
            oM.IdPaciente = oMedPedLab.IdPaciente;
            oM.EsPedidoExterno = oMedPedLab.EsPedidoExterno;
            oM.IdConsulta = oMedPedLab.IdConsulta;
            oM.DrSolicita = oMedPedLab.DrSolicita;
            oM.DrRealiza = oMedPedLab.DrRealiza;
            oM.FechaSolicitud = oMedPedLab.FechaSolicitud;
            oM.FechaRealiza = oMedPedLab.FechaRealiza;
            oM.Observaciones = oMedPedLab.Observaciones;
            oM.CreadoPor = oMedPedLab.CreadoPor;
            oM.ModificadoPor = oMedPedLab.ModificadoPor;
            oM.EvaluacionResultados = oMedPedLab.EvaluacionResultados;
            oM.Factura = oMedPedLab.Factura;
            oM.Muestras = oMedPedLab.Muestras;
            //
            MedPedLab2Row(oM, dr);
            //
            dt.Rows.Add(dr);
        }
        public static DataTable Tabla()
        {
            return Tabla(CadenaSelect);
        }
        public static DataTable Tabla(string sel)
        {
            // devuelve una tabla con los datos de la tabla MedPedLab
            SqlDataAdapter da;
            DataTable dt = new DataTable("MedPedLab");
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
        public static MedPedLab Buscar(string sWhere)
        {
            // Busca en la tabla los datos indicados en el parámetro
            // el parámetro contendrá lo que se usará después del WHERE
            MedPedLab oMedPedLab = null;
            SqlDataAdapter da;
            DataTable dt = new DataTable("MedPedLab");
            string sel = "SELECT * FROM MedPedLab WHERE " + sWhere;
            //
            da = new SqlDataAdapter(sel, cadenaConexion);
            da.Fill(dt);
            //
            if (dt.Rows.Count > 0)
            {
                oMedPedLab = row2MedPedLab(dt.Rows[0]);
            }
            return oMedPedLab;
        }
        //
        // Actualizar: Actualiza los datos en la tabla usando la instancia actual
        //             Si la instancia no hace referencia a un registro existente, se creará uno nuevo
        //             Para comprobar si el objeto en memoria coincide con uno existente,
        //             se comprueba si el NroPedido existe en la tabla.
        public string Actualizar()
        {
            string sel = "SELECT * FROM MedPedLab WHERE NroPedido = " + this.NroPedido.ToString();
            return Actualizar(sel);
        }
        public string Actualizar(string sel)
        {
            CadenaSelect = sel;
            if (NroPedido == 0) return Crear();
            SqlConnection cnn;
            SqlDataAdapter da;
            DataTable dt = new DataTable("MedPedLab");
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
                MedPedLab2Row(this, dt.Rows[0]);
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
            string ssql = "Select max(NroPedido) as Valor from MedPedLab";
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
            CadenaSelect = "SELECT * FROM MedPedLab WHERE NroPedido = " + this.NroPedido.ToString();
            SqlConnection cnn;
            SqlDataAdapter da;
            DataTable dt = new DataTable("MedPedLab");
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
            nuevoMedPedLab(dt, this);
            //
            try
            {
                da.Update(dt);
                dt.AcceptChanges();
                return "Se ha creado un nuevo MedPedLab";
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
        }
        //
        public string Borrar()
        {
            string sel = "SELECT * FROM MedPedLab WHERE NroPedido = " + this.NroPedido.ToString();
            //
            return Borrar(sel);
        }
        public string Borrar(string sel)
        {
            SqlConnection cnn;
            SqlDataAdapter da;
            DataTable dt = new DataTable("MedPedLab");
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
                string ssql = "SELECT max(NroPedido) as maxNro FROM MedPedLab";
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
