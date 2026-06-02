using System;
using System.Data;
using System.Data.SqlClient;
namespace IvaRett
{
    //
    public class AdcDocReemb
    {
        private System.String _Doc_sucursal;
        private System.String _Opc_documento;
        private System.Decimal _idClaveDoc;
        private System.String _tipoComprobanteReemb;
        private System.String _tpIdProvReemb;
        private System.String _idProvReemb;
        private System.String _establecimientoReemb;
        private System.String _puntoEmisionReemb;
        private System.Decimal _secuencialReemb;
        private System.String _autorizacionReemb;
        private System.Decimal _baseImponibleReemb;
        private System.Decimal _baseImpGravReemb;
        private System.Decimal _baseNoGraIvaReemb;
        private System.Decimal _baseImpExeReemb;
        private System.Decimal _montoIvaRemb;
        private System.Decimal _totbasesImpReemb;
        private System.DateTime _fechaEmisionReemb;
        private System.Decimal _montoIceRemb;
        private System.Int32 _estado;
        private System.Decimal _porcIva;
        //
        // Este método se usará para ajustar los anchos de las propiedades
        private string ajustarAncho(string cadena, int ancho)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder(new String(' ', ancho));
            return (cadena + sb.ToString()).Substring(0, ancho).Trim();
        }
        public System.String Doc_sucursal
        {
            get
            {
                return ajustarAncho(_Doc_sucursal, 3);
            }
            set
            {
                _Doc_sucursal = value;
            }
        }
        public System.String Opc_documento
        {
            get
            {
                return ajustarAncho(_Opc_documento, 3);
            }
            set
            {
                _Opc_documento = value;
            }
        }
        public System.Decimal idClaveDoc
        {
            get
            {
                return _idClaveDoc;
            }
            set
            {
                _idClaveDoc = value;
            }
        }
        public System.String tipoComprobanteReemb
        {
            get
            {
                return ajustarAncho(_tipoComprobanteReemb, 5);
            }
            set
            {
                _tipoComprobanteReemb = value;
            }
        }
        public System.String tpIdProvReemb
        {
            get
            {
                return ajustarAncho(_tpIdProvReemb, 5);
            }
            set
            {
                _tpIdProvReemb = value;
            }
        }
        public System.String idProvReemb
        {
            get
            {
                return ajustarAncho(_idProvReemb, 20);
            }
            set
            {
                _idProvReemb = value;
            }
        }
        public System.String establecimientoReemb
        {
            get
            {
                return ajustarAncho(_establecimientoReemb, 5);
            }
            set
            {
                _establecimientoReemb = value;
            }
        }
        public System.String puntoEmisionReemb
        {
            get
            {
                return ajustarAncho(_puntoEmisionReemb, 5);
            }
            set
            {
                _puntoEmisionReemb = value;
            }
        }
        public System.Decimal secuencialReemb
        {
            get
            {
                return _secuencialReemb;
            }
            set
            {
                _secuencialReemb = value;
            }
        }
        public System.String autorizacionReemb
        {
            get
            {
                return ajustarAncho(_autorizacionReemb, 50);
            }
            set
            {
                _autorizacionReemb = value;
            }
        }
        public System.Decimal baseImponibleReemb
        {
            get
            {
                return _baseImponibleReemb;
            }
            set
            {
                _baseImponibleReemb = value;
            }
        }
        public System.Decimal baseImpGravReemb
        {
            get
            {
                return _baseImpGravReemb;
            }
            set
            {
                _baseImpGravReemb = value;
            }
        }
        public System.Decimal baseNoGraIvaReemb
        {
            get
            {
                return _baseNoGraIvaReemb;
            }
            set
            {
                _baseNoGraIvaReemb = value;
            }
        }
        public System.Decimal baseImpExeReemb
        {
            get
            {
                return _baseImpExeReemb;
            }
            set
            {
                _baseImpExeReemb = value;
            }
        }
        public System.Decimal montoIvaRemb
        {
            get
            {
                return _montoIvaRemb;
            }
            set
            {
                _montoIvaRemb = value;
            }
        }
        public System.Decimal totbasesImpReemb
        {
            get
            {
                return _totbasesImpReemb;
            }
            set
            {
                _totbasesImpReemb = value;
            }
        }
        public System.DateTime fechaEmisionReemb
        {
            get
            {
                return _fechaEmisionReemb;
            }
            set
            {
                _fechaEmisionReemb = value;
            }
        }
        public System.Decimal montoIceRemb
        {
            get
            {
                return _montoIceRemb;
            }
            set
            {
                _montoIceRemb = value;
            }
        }
        public System.Int32 estado
        {
            get
            {
                return _estado;
            }
            set
            {
                _estado = value;
            }
        }
        public System.Decimal porcIva
        {
            get
            {
                return _porcIva;
            }
            set
            {
                _porcIva = value;
            }
        }
        //
        private static string cadenaConexion = @"";
        // La cadena de selección
        public static string CadenaSelect = "SELECT * FROM AdcDocReemb";
        //
        public AdcDocReemb()
        {
        }
        public AdcDocReemb(string conex)
        {
            cadenaConexion = conex;
        }
        private static AdcDocReemb row2AdcDocReemb(DataRow r)
        {
            // asigna a un objeto AdcDocReemb los datos del dataRow indicado
            AdcDocReemb oAdcDocReemb = new AdcDocReemb();
            //
            oAdcDocReemb.Doc_sucursal = r["Doc_sucursal"].ToString();
            oAdcDocReemb.Opc_documento = r["Opc_documento"].ToString();
            oAdcDocReemb.idClaveDoc = System.Decimal.Parse("0" + r["idClaveDoc"].ToString());
            oAdcDocReemb.tipoComprobanteReemb = r["tipoComprobanteReemb"].ToString();
            oAdcDocReemb.tpIdProvReemb = r["tpIdProvReemb"].ToString();
            oAdcDocReemb.idProvReemb = r["idProvReemb"].ToString();
            oAdcDocReemb.establecimientoReemb = r["establecimientoReemb"].ToString();
            oAdcDocReemb.puntoEmisionReemb = r["puntoEmisionReemb"].ToString();
            oAdcDocReemb.secuencialReemb = System.Decimal.Parse("0" + r["secuencialReemb"].ToString());
            oAdcDocReemb.autorizacionReemb = r["autorizacionReemb"].ToString();
            oAdcDocReemb.baseImponibleReemb = System.Decimal.Parse("0" + r["baseImponibleReemb"].ToString());
            oAdcDocReemb.baseImpGravReemb = System.Decimal.Parse("0" + r["baseImpGravReemb"].ToString());
            oAdcDocReemb.baseNoGraIvaReemb = System.Decimal.Parse("0" + r["baseNoGraIvaReemb"].ToString());
            oAdcDocReemb.baseImpExeReemb = System.Decimal.Parse("0" + r["baseImpExeReemb"].ToString());
            oAdcDocReemb.montoIvaRemb = System.Decimal.Parse("0" + r["montoIvaRemb"].ToString());
            oAdcDocReemb.totbasesImpReemb = System.Decimal.Parse("0" + r["totbasesImpReemb"].ToString());
            try
            {
                oAdcDocReemb.fechaEmisionReemb = DateTime.Parse(r["fechaEmisionReemb"].ToString());
            }
            catch
            {
                oAdcDocReemb.fechaEmisionReemb = DateTime.Now;
            }
            oAdcDocReemb.montoIceRemb = System.Decimal.Parse("0" + r["montoIceRemb"].ToString());
            oAdcDocReemb.estado = System.Int32.Parse("0" + r["estado"].ToString());
            oAdcDocReemb.porcIva = System.Decimal.Parse("0" + r["porcIva"].ToString());
            //
            return oAdcDocReemb;
        }
        //
        // asigna un objeto AdcDocReemb a la fila indicada
        private static void AdcDocReemb2Row(AdcDocReemb oAdcDocReemb, DataRow r)
        {
            // asigna un objeto AdcDocReemb al dataRow indicado
            r["Doc_sucursal"] = oAdcDocReemb.Doc_sucursal;
            r["Opc_documento"] = oAdcDocReemb.Opc_documento;
            r["idClaveDoc"] = oAdcDocReemb.idClaveDoc;
            r["tipoComprobanteReemb"] = oAdcDocReemb.tipoComprobanteReemb;
            r["tpIdProvReemb"] = oAdcDocReemb.tpIdProvReemb;
            r["idProvReemb"] = oAdcDocReemb.idProvReemb;
            r["establecimientoReemb"] = oAdcDocReemb.establecimientoReemb;
            r["puntoEmisionReemb"] = oAdcDocReemb.puntoEmisionReemb;
            r["secuencialReemb"] = oAdcDocReemb.secuencialReemb;
            r["autorizacionReemb"] = oAdcDocReemb.autorizacionReemb;
            r["baseImponibleReemb"] = oAdcDocReemb.baseImponibleReemb;
            r["baseImpGravReemb"] = oAdcDocReemb.baseImpGravReemb;
            r["baseNoGraIvaReemb"] = oAdcDocReemb.baseNoGraIvaReemb;
            r["baseImpExeReemb"] = oAdcDocReemb.baseImpExeReemb;
            r["montoIvaRemb"] = oAdcDocReemb.montoIvaRemb;
            r["totbasesImpReemb"] = oAdcDocReemb.totbasesImpReemb;
            r["fechaEmisionReemb"] = oAdcDocReemb.fechaEmisionReemb;
            r["montoIceRemb"] = oAdcDocReemb.montoIceRemb;
            r["estado"] = oAdcDocReemb.estado;
            r["porcIva"] = oAdcDocReemb.porcIva;
        }
        //
        // crea una nueva fila y la asigna a un objeto AdcDocReemb
        private static void nuevoAdcDocReemb(DataTable dt, AdcDocReemb oAdcDocReemb)
        {
            // Crear un nuevo AdcDocReemb
            DataRow dr = dt.NewRow();
            AdcDocReemb oA = row2AdcDocReemb(dr);
            //
            oA.Doc_sucursal = oAdcDocReemb.Doc_sucursal;
            oA.Opc_documento = oAdcDocReemb.Opc_documento;
            oA.idClaveDoc = oAdcDocReemb.idClaveDoc;
            oA.tipoComprobanteReemb = oAdcDocReemb.tipoComprobanteReemb;
            oA.tpIdProvReemb = oAdcDocReemb.tpIdProvReemb;
            oA.idProvReemb = oAdcDocReemb.idProvReemb;
            oA.establecimientoReemb = oAdcDocReemb.establecimientoReemb;
            oA.puntoEmisionReemb = oAdcDocReemb.puntoEmisionReemb;
            oA.secuencialReemb = oAdcDocReemb.secuencialReemb;
            oA.autorizacionReemb = oAdcDocReemb.autorizacionReemb;
            oA.baseImponibleReemb = oAdcDocReemb.baseImponibleReemb;
            oA.baseImpGravReemb = oAdcDocReemb.baseImpGravReemb;
            oA.baseNoGraIvaReemb = oAdcDocReemb.baseNoGraIvaReemb;
            oA.baseImpExeReemb = oAdcDocReemb.baseImpExeReemb;
            oA.montoIvaRemb = oAdcDocReemb.montoIvaRemb;
            oA.totbasesImpReemb = oAdcDocReemb.totbasesImpReemb;
            oA.fechaEmisionReemb = oAdcDocReemb.fechaEmisionReemb;
            oA.montoIceRemb = oAdcDocReemb.montoIceRemb;
            oA.estado = oAdcDocReemb.estado;
            oA.porcIva = oAdcDocReemb.porcIva;
            //
            AdcDocReemb2Row(oA, dr);
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
            // devuelve una tabla con los datos de la tabla AdcDocReemb
            SqlDataAdapter da;
            DataTable dt = new DataTable("AdcDocReemb");
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
        public static AdcDocReemb Buscar(string sWhere)
        {
            // Busca en la tabla los datos indicados en el parámetro
            // el parámetro contendrá lo que se usará después del WHERE
            AdcDocReemb oAdcDocReemb = null;
            SqlDataAdapter da;
            DataTable dt = new DataTable("AdcDocReemb");
            string sel = "SELECT * FROM AdcDocReemb WHERE " + sWhere;
            //
            da = new SqlDataAdapter(sel, cadenaConexion);
            da.Fill(dt);
            //
            if (dt.Rows.Count > 0)
            {
                oAdcDocReemb = row2AdcDocReemb(dt.Rows[0]);
            }
            return oAdcDocReemb;
        }
        public string Actualizar()
        {
            string sel = "SELECT * FROM AdcDocReemb WHERE doc_sucursal = '" + Doc_sucursal + "' and opc_documento = '" + Opc_documento + "' and idclavedoc = " + idClaveDoc.ToString();
            return Actualizar(sel);
        }
        public string Actualizar(string sel)
        {
            SqlConnection cnn;
            SqlDataAdapter da;
            DataTable dt = new DataTable("AdcDocReemb");
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
                return Crear();
            }
            else
            {
                AdcDocReemb2Row(this, dt.Rows[0]);
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
            DataTable dt = new DataTable("AdcDocReemb");
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
            nuevoAdcDocReemb(dt, this);
            //
            try
            {
                da.Update(dt);
                dt.AcceptChanges();
                return "Se ha creado un nuevo AdcDocReemb";
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
        }
        //
        public string Borrar()
        {
            string sel = "SELECT * FROM AdcDocReemb WHERE doc_sucursal = '" + Doc_sucursal + "' and opc_documento = '" + Opc_documento + "' and idclavedoc = " + idClaveDoc.ToString();
            //
            return Borrar(sel);
        }
        public string Borrar(string sel)
        {
            SqlConnection cnn;
            SqlDataAdapter da;
            DataTable dt = new DataTable("AdcDocReemb");
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