using System;
using System.Data;
using System.Data.SqlClient;

namespace DaxMedic
{//

    public class MedPedImg
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

        //
        private static string cadenaConexion = "";
        // La cadena de selección
        public static string CadenaSelect = "";
        //
        public MedPedImg()
        {
        }
        public MedPedImg(string conex)
        {
            cadenaConexion = conex;
        }
        private static MedPedImg row2MedPedImg(DataRow r)
        {
            // asigna a un objeto MedPedImg los datos del dataRow indicado
            MedPedImg oMedPedImg = new MedPedImg();
            //
            oMedPedImg.NroPedido = System.Decimal.Parse("0" + r["NroPedido"].ToString());
            oMedPedImg.IdPaciente = r["IdPaciente"].ToString();
            try
            {
                oMedPedImg.EsPedidoExterno = System.Boolean.Parse(r["EsPedidoExterno"].ToString());
            }
            catch
            {
                oMedPedImg.EsPedidoExterno = false;
            }
            oMedPedImg.IdConsulta = System.Decimal.Parse("0" + r["IdConsulta"].ToString());
            oMedPedImg.DrSolicita = r["DrSolicita"].ToString();
            oMedPedImg.DrRealiza = r["DrRealiza"].ToString();
            try
            {
                oMedPedImg.FechaSolicitud = DateTime.Parse(r["FechaSolicitud"].ToString());
            }
            catch
            {
                oMedPedImg.FechaSolicitud = DateTime.Now;
            }
            try
            {
                oMedPedImg.FechaRealiza = DateTime.Parse(r["FechaRealiza"].ToString());
            }
            catch
            {
                oMedPedImg.FechaRealiza = DateTime.Now;
            }
            oMedPedImg.Observaciones = r["Observaciones"].ToString();
            oMedPedImg.CreadoPor  = r["CreadoPor"].ToString();
            oMedPedImg.ModificadoPor = r["ModificadoPor"].ToString();
            oMedPedImg.EvaluacionResultados = r["EvaluacionResultados"].ToString();
            oMedPedImg.Factura = r["Factura"].ToString();
            //
            return oMedPedImg;
        }
        //
        // asigna un objeto MedPedImg a la fila indicada
        private static void MedPedImg2Row(MedPedImg oMedPedImg, DataRow r)
        {
            // asigna un objeto MedPedImg al dataRow indicado
            r["NroPedido"] = oMedPedImg.NroPedido;
            r["IdPaciente"] = oMedPedImg.IdPaciente;
            r["EsPedidoExterno"] = oMedPedImg.EsPedidoExterno;
            r["IdConsulta"] = oMedPedImg.IdConsulta;
            r["DrSolicita"] = oMedPedImg.DrSolicita;
            r["DrRealiza"] = oMedPedImg.DrRealiza;
            r["FechaSolicitud"] = oMedPedImg.FechaSolicitud;
            r["FechaRealiza"] = oMedPedImg.FechaRealiza;
            r["Observaciones"] = oMedPedImg.Observaciones;
            r["CreadoPor"] = oMedPedImg.CreadoPor;
            r["ModificadoPor"] = oMedPedImg.ModificadoPor;
            r["EvaluacionResultados"] = oMedPedImg.EvaluacionResultados;
            r["Factura"] = oMedPedImg.Factura;
        }
        //
        // crea una nueva fila y la asigna a un objeto MedPedImg
        private static void nuevoMedPedImg(DataTable dt, MedPedImg oMedPedImg)
        {
            // Crear un nuevo MedPedImg
            DataRow dr = dt.NewRow();
            MedPedImg oM = row2MedPedImg(dr);
            //
            oM.NroPedido = oMedPedImg.NroPedido;
            oM.IdPaciente = oMedPedImg.IdPaciente;
            oM.EsPedidoExterno = oMedPedImg.EsPedidoExterno;
            oM.IdConsulta = oMedPedImg.IdConsulta;
            oM.DrSolicita = oMedPedImg.DrSolicita;
            oM.DrRealiza = oMedPedImg.DrRealiza;
            oM.FechaSolicitud = oMedPedImg.FechaSolicitud;
            oM.FechaRealiza = oMedPedImg.FechaRealiza;
            oM.Observaciones = oMedPedImg.Observaciones;
            oM.CreadoPor = oMedPedImg.CreadoPor;
            oM.ModificadoPor = oMedPedImg.ModificadoPor;
            oM.EvaluacionResultados = oMedPedImg.EvaluacionResultados;
            oM.Factura = oMedPedImg.Factura;
            //
            MedPedImg2Row(oM, dr);
            //
            dt.Rows.Add(dr);
        }
        public static DataTable Tabla()
        {
            return Tabla(CadenaSelect);
        }
        public static DataTable Tabla(string sel)
        {
            // devuelve una tabla con los datos de la tabla MedPedImg
            SqlDataAdapter da;
            DataTable dt = new DataTable("MedPedImg");
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
        public static MedPedImg Buscar(string sWhere)
        {
            // Busca en la tabla los datos indicados en el parámetro
            // el parámetro contendrá lo que se usará después del WHERE
            MedPedImg oMedPedImg = null;
            SqlDataAdapter da;
            DataTable dt = new DataTable("MedPedImg");
            string sel = "SELECT * FROM MedPedImg WHERE " + sWhere;
            //
            da = new SqlDataAdapter(sel, cadenaConexion);
            da.Fill(dt);
            //
            if (dt.Rows.Count > 0)
            {
                oMedPedImg = row2MedPedImg(dt.Rows[0]);
            }
            return oMedPedImg;
        }
        //
        // Actualizar: Actualiza los datos en la tabla usando la instancia actual
        //             Si la instancia no hace referencia a un registro existente, se creará uno nuevo
        //             Para comprobar si el objeto en memoria coincide con uno existente,
        //             se comprueba si el NroPedido existe en la tabla.
        public string Actualizar()
        {
            string sel = "SELECT * FROM MedPedImg WHERE NroPedido = " + this.NroPedido.ToString();
            return Actualizar(sel);
        }
        public string Actualizar(string sel)
        {
            CadenaSelect = sel;
            if (NroPedido == 0) return Crear();
            SqlConnection cnn;
            SqlDataAdapter da;
            DataTable dt = new DataTable("MedPedImg");
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
                MedPedImg2Row(this, dt.Rows[0]);
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
            string ssql = "Select max(NroPedido) as Valor from MedPedImg";
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
            CadenaSelect = "SELECT * FROM MedPedImg WHERE NroPedido = " + this.NroPedido.ToString();
            SqlConnection cnn;
            SqlDataAdapter da;
            DataTable dt = new DataTable("MedPedImg");
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
            nuevoMedPedImg(dt, this);
            //
            try
            {
                da.Update(dt);
                dt.AcceptChanges();
                return "Se ha creado un nuevo MedPedImg";
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
        }
        //
        public string Borrar()
        {
            string sel = "SELECT * FROM MedPedImg WHERE NroPedido = " + this.NroPedido.ToString();
            //
            return Borrar(sel);
        }
        public string Borrar(string sel)
        {
            SqlConnection cnn;
            SqlDataAdapter da;
            DataTable dt = new DataTable("MedPedImg");
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
                string ssql = "SELECT max(NroPedido) as maxNro FROM MedPedImg";
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
