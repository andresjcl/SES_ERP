using System;
using System.Data;
using System.Data.SqlClient;

namespace ClassDoc
{
    public class AdcPag
    {
        private System.String _Doc_sucursal;
        private System.String _Opc_documento;
        private System.Decimal _Doc_numero;
        private System.Decimal _Pag_Numero;
        private System.DateTime _Doc_Fecha;
        private System.String _Pag_TipoPago;
        private System.Decimal _Pag_Valor;
        private System.String _Pag_DocInstitucion;
        private System.String _Pag_DocPagoTipo;
        private System.String _Pag_DocPagoNumero;
        private System.String _Pag_NumCtaBanco;
        private System.String _Pag_PlanTarjeta;
        private System.String _Pag_Autoriza;
        private System.Decimal _Pag_ComisionTarjeta;
        private System.Decimal _Pag_Cuotas;
        private System.String _Pag_Descripcion;
        private System.String _Pag_Formapago;
        private System.Decimal _Pag_Interestarjeta;
        private System.String _Pag_Idpago;
        private System.DateTime _Pag_Vence;
        private System.Decimal _Pag_diferidos;
        private System.DateTime _Pag_FechaUltDiferimiento;
        private System.String _pag_Beneficiario;
        private System.String _pag_status;
        private System.String _pag_DocVoucher;
        private System.Decimal _IdClaveDoc;
        private System.Decimal _Pag_Retencion;
        private System.Decimal _Pag_RetIva;
        private System.String _Pag_TipoRet;
        private System.String _Pag_Recap;
        private System.DateTime _Pag_FechRecap;
        private System.Decimal _Pag_NumDocPago;
        private System.DateTime _Pag_FechaPago;
        private System.Decimal _Pag_ValorPago;
        private System.Decimal _Pag_ValorCobrar;
        private System.Decimal _IdclaveDocPag;
        private System.String _pag_docpagosucursal;
        //
        // Este método se usará para ajustar los anchos de las propiedades
        private string ajustarAncho(string cadena, int ancho)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder(new String(' ', ancho));
            return (cadena + sb.ToString()).Substring(0, ancho).Trim();
        }
        //
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
        public System.Decimal Doc_numero
        {
            get
            {
                return _Doc_numero;
            }
            set
            {
                _Doc_numero = value;
            }
        }
        public System.Decimal Pag_Numero
        {
            get
            {
                return _Pag_Numero;
            }
            set
            {
                _Pag_Numero = value;
            }
        }
        public System.DateTime Doc_Fecha
        {
            get
            {
                return _Doc_Fecha;
            }
            set
            {
                _Doc_Fecha = value;
            }
        }
        public System.String Pag_TipoPago
        {
            get
            {
                return ajustarAncho(_Pag_TipoPago, 3);
            }
            set
            {
                _Pag_TipoPago = value;
            }
        }
        public System.Decimal Pag_Valor
        {
            get
            {
                return _Pag_Valor;
            }
            set
            {
                _Pag_Valor = value;
            }
        }
        public System.String Pag_DocInstitucion
        {
            get
            {
                return ajustarAncho(_Pag_DocInstitucion, 150);
            }
            set
            {
                _Pag_DocInstitucion = value;
            }
        }
        public System.String Pag_DocPagoTipo
        {
            get
            {
                return ajustarAncho(_Pag_DocPagoTipo, 3);
            }
            set
            {
                _Pag_DocPagoTipo = value;
            }
        }
        public System.String Pag_DocPagoNumero
        {
            get
            {
                return ajustarAncho(_Pag_DocPagoNumero, 20);
            }
            set
            {
                _Pag_DocPagoNumero = value;
            }
        }
        public System.String Pag_NumCtaBanco
        {
            get
            {
                return ajustarAncho(_Pag_NumCtaBanco, 20);
            }
            set
            {
                _Pag_NumCtaBanco = value;
            }
        }
        public System.String Pag_PlanTarjeta
        {
            get
            {
                return ajustarAncho(_Pag_PlanTarjeta, 5);
            }
            set
            {
                _Pag_PlanTarjeta = value;
            }
        }
        public System.String Pag_Autoriza
        {
            get
            {
                return ajustarAncho(_Pag_Autoriza, 20);
            }
            set
            {
                _Pag_Autoriza = value;
            }
        }
        public System.Decimal Pag_ComisionTarjeta
        {
            get
            {
                return _Pag_ComisionTarjeta;
            }
            set
            {
                _Pag_ComisionTarjeta = value;
            }
        }
        public System.Decimal Pag_Cuotas
        {
            get
            {
                return _Pag_Cuotas;
            }
            set
            {
                _Pag_Cuotas = value;
            }
        }
        public System.String Pag_Descripcion
        {
            get
            {
                return ajustarAncho(_Pag_Descripcion, 50);
            }
            set
            {
                _Pag_Descripcion = value;
            }
        }
        public System.String Pag_Formapago
        {
            get
            {
                return ajustarAncho(_Pag_Formapago, 1);
            }
            set
            {
                _Pag_Formapago = value;
            }
        }
        public System.Decimal Pag_Interestarjeta
        {
            get
            {
                return _Pag_Interestarjeta;
            }
            set
            {
                _Pag_Interestarjeta = value;
            }
        }
        public System.String Pag_Idpago
        {
            get
            {
                return ajustarAncho(_Pag_Idpago, 3);
            }
            set
            {
                _Pag_Idpago = value;
            }
        }
        public System.DateTime Pag_Vence
        {
            get
            {
                return _Pag_Vence;
            }
            set
            {
                _Pag_Vence = value;
            }
        }
        public System.Decimal Pag_diferidos
        {
            get
            {
                return _Pag_diferidos;
            }
            set
            {
                _Pag_diferidos = value;
            }
        }
        public System.DateTime Pag_FechaUltDiferimiento
        {
            get
            {
                return _Pag_FechaUltDiferimiento;
            }
            set
            {
                _Pag_FechaUltDiferimiento = value;
            }
        }
        public System.String pag_Beneficiario
        {
            get
            {
                return ajustarAncho(_pag_Beneficiario, 40);
            }
            set
            {
                _pag_Beneficiario = value;
            }
        }
        public System.String pag_status
        {
            get
            {
                return ajustarAncho(_pag_status, 1);
            }
            set
            {
                _pag_status = value;
            }
        }
        public System.String pag_DocVoucher
        {
            get
            {
                return ajustarAncho(_pag_DocVoucher, 12);
            }
            set
            {
                _pag_DocVoucher = value;
            }
        }
        public System.Decimal IdClaveDoc
        {
            get
            {
                return _IdClaveDoc;
            }
            set
            {
                _IdClaveDoc = value;
            }
        }
        public System.Decimal Pag_Retencion
        {
            get
            {
                return _Pag_Retencion;
            }
            set
            {
                _Pag_Retencion = value;
            }
        }
        public System.Decimal Pag_RetIva
        {
            get
            {
                return _Pag_RetIva;
            }
            set
            {
                _Pag_RetIva = value;
            }
        }
        public System.String Pag_TipoRet
        {
            get
            {
                return ajustarAncho(_Pag_TipoRet, 2);
            }
            set
            {
                _Pag_TipoRet = value;
            }
        }
        public System.String Pag_Recap
        {
            get
            {
                return ajustarAncho(_Pag_Recap, 10);
            }
            set
            {
                _Pag_Recap = value;
            }
        }
        public System.DateTime Pag_FechRecap
        {
            get
            {
                return _Pag_FechRecap;
            }
            set
            {
                _Pag_FechRecap = value;
            }
        }
        public System.Decimal Pag_NumDocPago
        {
            get
            {
                return _Pag_NumDocPago;
            }
            set
            {
                _Pag_NumDocPago = value;
            }
        }
        public System.DateTime Pag_FechaPago
        {
            get
            {
                return _Pag_FechaPago;
            }
            set
            {
                _Pag_FechaPago = value;
            }
        }
        public System.Decimal Pag_ValorPago
        {
            get
            {
                return _Pag_ValorPago;
            }
            set
            {
                _Pag_ValorPago = value;
            }
        }
        public System.Decimal Pag_ValorCobrar
        {
            get
            {
                return _Pag_ValorCobrar;
            }
            set
            {
                _Pag_ValorCobrar = value;
            }
        }
        public System.Decimal IdclaveDocPag
        {
            get
            {
                return _IdclaveDocPag;
            }
            set
            {
                _IdclaveDocPag = value;
            }
        }
        public System.String pag_docpagosucursal
        {
            get
            {
                return ajustarAncho(_pag_docpagosucursal, 50);
            }
            set
            {
                _pag_docpagosucursal = value;
            }
        }
        //
        // La cadena de conexión a la base de datos
        private static string cadenaConexion = "";
        // La cadena de selección
        public static string CadenaSelect = "";
        //
        public AdcPag()
        {
        }
        public AdcPag(string conex)
        {
            cadenaConexion = conex;
        }
        //
        // Métodos compartidos (estáticos) privados
        //
        // asigna una fila de la tabla a un objeto AdcPag
        private static AdcPag row2AdcPag(DataRow r)
        {
            // asigna a un objeto AdcPag los datos del dataRow indicado
            AdcPag oAdcPag = new AdcPag();
            //
            oAdcPag.Doc_sucursal = r["Doc_sucursal"].ToString();
            oAdcPag.Opc_documento = r["Opc_documento"].ToString();
            oAdcPag.Doc_numero = System.Decimal.Parse("0" + r["Doc_numero"].ToString());
            oAdcPag.Pag_Numero = System.Decimal.Parse("0" + r["Pag_Numero"].ToString());
            try
            {
                oAdcPag.Doc_Fecha = DateTime.Parse(r["Doc_Fecha"].ToString());
            }
            catch
            {
                oAdcPag.Doc_Fecha = DateTime.Now;
            }
            oAdcPag.Pag_TipoPago = r["Pag_TipoPago"].ToString();
            oAdcPag.Pag_Valor = System.Decimal.Parse("0" + r["Pag_Valor"].ToString());
            oAdcPag.Pag_DocInstitucion = r["Pag_DocInstitucion"].ToString();
            oAdcPag.Pag_DocPagoTipo = r["Pag_DocPagoTipo"].ToString();
            oAdcPag.Pag_DocPagoNumero = r["Pag_DocPagoNumero"].ToString();
            oAdcPag.Pag_NumCtaBanco = r["Pag_NumCtaBanco"].ToString();
            oAdcPag.Pag_PlanTarjeta = r["Pag_PlanTarjeta"].ToString();
            oAdcPag.Pag_Autoriza = r["Pag_Autoriza"].ToString();
            oAdcPag.Pag_ComisionTarjeta = System.Decimal.Parse("0" + r["Pag_ComisionTarjeta"].ToString());
            oAdcPag.Pag_Cuotas = System.Decimal.Parse("0" + r["Pag_Cuotas"].ToString());
            oAdcPag.Pag_Descripcion = r["Pag_Descripcion"].ToString();
            oAdcPag.Pag_Formapago = r["Pag_Formapago"].ToString();
            oAdcPag.Pag_Interestarjeta = System.Decimal.Parse("0" + r["Pag_Interestarjeta"].ToString());
            oAdcPag.Pag_Idpago = r["Pag_Idpago"].ToString();
            try
            {
                oAdcPag.Pag_Vence = DateTime.Parse(r["Pag_Vence"].ToString());
            }
            catch
            {
                oAdcPag.Pag_Vence = DateTime.Now;
            }
            oAdcPag.Pag_diferidos = System.Decimal.Parse("0" + r["Pag_diferidos"].ToString());
            try
            {
                oAdcPag.Pag_FechaUltDiferimiento = DateTime.Parse(r["Pag_FechaUltDiferimiento"].ToString());
            }
            catch
            {
                oAdcPag.Pag_FechaUltDiferimiento = DateTime.Now;
            }
            oAdcPag.pag_Beneficiario = r["pag_Beneficiario"].ToString();
            oAdcPag.pag_status = r["pag_status"].ToString();
            oAdcPag.pag_DocVoucher = r["pag_DocVoucher"].ToString();
            oAdcPag.IdClaveDoc = System.Decimal.Parse("0" + r["IdClaveDoc"].ToString());
            oAdcPag.Pag_Retencion = System.Decimal.Parse("0" + r["Pag_Retencion"].ToString());
            oAdcPag.Pag_RetIva = System.Decimal.Parse("0" + r["Pag_RetIva"].ToString());
            oAdcPag.Pag_TipoRet = r["Pag_TipoRet"].ToString();
            oAdcPag.Pag_Recap = r["Pag_Recap"].ToString();
            try
            {
                oAdcPag.Pag_FechRecap = DateTime.Parse(r["Pag_FechRecap"].ToString());
            }
            catch
            {
                oAdcPag.Pag_FechRecap = new DateTime(1900, 1, 1);
            }
            oAdcPag.Pag_NumDocPago = System.Decimal.Parse("0" + r["Pag_NumDocPago"].ToString());
            try
            {
                oAdcPag.Pag_FechaPago = DateTime.Parse(r["Pag_FechaPago"].ToString());
            }
            catch
            {
                oAdcPag.Pag_FechaPago = new DateTime(1900, 1, 1);
            }
            oAdcPag.Pag_ValorPago = System.Decimal.Parse("0" + r["Pag_ValorPago"].ToString());
            oAdcPag.Pag_ValorCobrar = System.Decimal.Parse("0" + r["Pag_ValorCobrar"].ToString());
            oAdcPag.IdclaveDocPag = System.Decimal.Parse("0" + r["IdclaveDocPag"].ToString());
            oAdcPag.pag_docpagosucursal = r["pag_docpagosucursal"].ToString();
            //
            return oAdcPag;
        }
        //
        // asigna un objeto AdcPag a la fila indicada
        private static void AdcPag2Row(AdcPag oAdcPag, DataRow r)
        {
            // asigna un objeto AdcPag al dataRow indicado
            r["Doc_sucursal"] = oAdcPag.Doc_sucursal;
            r["Opc_documento"] = oAdcPag.Opc_documento;
            r["Doc_numero"] = oAdcPag.Doc_numero;
            r["Pag_Numero"] = oAdcPag.Pag_Numero;
            r["Doc_Fecha"] = oAdcPag.Doc_Fecha;
            r["Pag_TipoPago"] = oAdcPag.Pag_TipoPago;
            r["Pag_Valor"] = oAdcPag.Pag_Valor;
            r["Pag_DocInstitucion"] = oAdcPag.Pag_DocInstitucion;
            r["Pag_DocPagoTipo"] = oAdcPag.Pag_DocPagoTipo;
            r["Pag_DocPagoNumero"] = oAdcPag.Pag_DocPagoNumero;
            r["Pag_NumCtaBanco"] = oAdcPag.Pag_NumCtaBanco;
            r["Pag_PlanTarjeta"] = oAdcPag.Pag_PlanTarjeta;
            r["Pag_Autoriza"] = oAdcPag.Pag_Autoriza;
            r["Pag_ComisionTarjeta"] = oAdcPag.Pag_ComisionTarjeta;
            r["Pag_Cuotas"] = oAdcPag.Pag_Cuotas;
            r["Pag_Descripcion"] = oAdcPag.Pag_Descripcion;
            r["Pag_Formapago"] = oAdcPag.Pag_Formapago;
            r["Pag_Interestarjeta"] = oAdcPag.Pag_Interestarjeta;
            r["Pag_Idpago"] = oAdcPag.Pag_Idpago;
            r["Pag_Vence"] = oAdcPag.Pag_Vence;
            r["Pag_diferidos"] = oAdcPag.Pag_diferidos;
            r["Pag_FechaUltDiferimiento"] = oAdcPag.Pag_FechaUltDiferimiento;
            r["pag_Beneficiario"] = oAdcPag.pag_Beneficiario;
            r["pag_status"] = oAdcPag.pag_status;
            r["pag_DocVoucher"] = oAdcPag.pag_DocVoucher;
            r["IdClaveDoc"] = oAdcPag.IdClaveDoc;
            r["Pag_Retencion"] = oAdcPag.Pag_Retencion;
            r["Pag_RetIva"] = oAdcPag.Pag_RetIva;
            r["Pag_TipoRet"] = oAdcPag.Pag_TipoRet;
            r["Pag_Recap"] = oAdcPag.Pag_Recap;
            r["Pag_FechRecap"] = oAdcPag.Pag_FechRecap;
            r["Pag_NumDocPago"] = oAdcPag.Pag_NumDocPago;
            r["Pag_FechaPago"] = oAdcPag.Pag_FechaPago;
            r["Pag_ValorPago"] = oAdcPag.Pag_ValorPago;
            r["Pag_ValorCobrar"] = oAdcPag.Pag_ValorCobrar;
            r["IdclaveDocPag"] = oAdcPag.IdclaveDocPag;
            r["pag_docpagosucursal"] = oAdcPag.pag_docpagosucursal;
        }
        //
        // crea una nueva fila y la asigna a un objeto AdcPag
        private static void nuevoAdcPag(DataTable dt, AdcPag oAdcPag)
        {
            // Crear un nuevo AdcPag
            DataRow dr = dt.NewRow();
            AdcPag oA = row2AdcPag(dr);
            //
            oA.Doc_sucursal = oAdcPag.Doc_sucursal;
            oA.Opc_documento = oAdcPag.Opc_documento;
            oA.Doc_numero = oAdcPag.Doc_numero;
            oA.Pag_Numero = oAdcPag.Pag_Numero;
            oA.Doc_Fecha = oAdcPag.Doc_Fecha;
            oA.Pag_TipoPago = oAdcPag.Pag_TipoPago;
            oA.Pag_Valor = oAdcPag.Pag_Valor;
            oA.Pag_DocInstitucion = oAdcPag.Pag_DocInstitucion;
            oA.Pag_DocPagoTipo = oAdcPag.Pag_DocPagoTipo;
            oA.Pag_DocPagoNumero = oAdcPag.Pag_DocPagoNumero;
            oA.Pag_NumCtaBanco = oAdcPag.Pag_NumCtaBanco;
            oA.Pag_PlanTarjeta = oAdcPag.Pag_PlanTarjeta;
            oA.Pag_Autoriza = oAdcPag.Pag_Autoriza;
            oA.Pag_ComisionTarjeta = oAdcPag.Pag_ComisionTarjeta;
            oA.Pag_Cuotas = oAdcPag.Pag_Cuotas;
            oA.Pag_Descripcion = oAdcPag.Pag_Descripcion;
            oA.Pag_Formapago = oAdcPag.Pag_Formapago;
            oA.Pag_Interestarjeta = oAdcPag.Pag_Interestarjeta;
            oA.Pag_Idpago = oAdcPag.Pag_Idpago;
            oA.Pag_Vence = oAdcPag.Pag_Vence;
            oA.Pag_diferidos = oAdcPag.Pag_diferidos;
            oA.Pag_FechaUltDiferimiento = oAdcPag.Pag_FechaUltDiferimiento;
            oA.pag_Beneficiario = oAdcPag.pag_Beneficiario;
            oA.pag_status = oAdcPag.pag_status;
            oA.pag_DocVoucher = oAdcPag.pag_DocVoucher;
            oA.IdClaveDoc = oAdcPag.IdClaveDoc;
            oA.Pag_Retencion = oAdcPag.Pag_Retencion;
            oA.Pag_RetIva = oAdcPag.Pag_RetIva;
            oA.Pag_TipoRet = oAdcPag.Pag_TipoRet;
            oA.Pag_Recap = oAdcPag.Pag_Recap;
            oA.Pag_FechRecap = oAdcPag.Pag_FechRecap;
            oA.Pag_NumDocPago = oAdcPag.Pag_NumDocPago;
            oA.Pag_FechaPago = oAdcPag.Pag_FechaPago;
            oA.Pag_ValorPago = oAdcPag.Pag_ValorPago;
            oA.Pag_ValorCobrar = oAdcPag.Pag_ValorCobrar;
            oA.IdclaveDocPag = oAdcPag.IdclaveDocPag;
            oA.pag_docpagosucursal = oAdcPag.pag_docpagosucursal;
            //
            AdcPag2Row(oA, dr);
            //
            dt.Rows.Add(dr);
        }
        // devuelve una tabla con los datos indicados en la cadena de selección
        public static DataTable Tabla()
        {
            return Tabla(CadenaSelect);
        }
        public static DataTable Tabla(string sel)
        {
            // devuelve una tabla con los datos de la tabla AdcPag
            SqlDataAdapter da;
            DataTable dt = new DataTable("AdcPag");
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
        public static AdcPag Buscar(string sWhere)
        {
            // Busca en la tabla los datos indicados en el parámetro
            // el parámetro contendrá lo que se usará después del WHERE
            AdcPag oAdcPag = null;
            SqlDataAdapter da;
            DataTable dt = new DataTable("AdcPag");
            string sel = "SELECT * FROM AdcPag WHERE " + sWhere;
            //
            da = new SqlDataAdapter(sel, cadenaConexion);
            da.Fill(dt);
            //
            if (dt.Rows.Count > 0)
            {
                oAdcPag = row2AdcPag(dt.Rows[0]);
            }
            return oAdcPag;
        }
        public string Actualizar()
        {
            string sel = "SELECT * FROM AdcPag WHERE doc_sucursal = '" + Doc_sucursal + "' and opc_documento = '" + Opc_documento + "' and idclavedoc =" + IdClaveDoc.ToString();
            return Actualizar(sel);
        }
        public string Actualizar(string sel)
        {
            SqlConnection cnn;
            SqlDataAdapter da;
            DataTable dt = new DataTable("AdcPag");
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
                AdcPag2Row(this, dt.Rows[0]);
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
            DataTable dt = new DataTable("AdcPag");
            //
            CadenaSelect = "SELECT * FROM AdcPag WHERE doc_sucursal = '" + Doc_sucursal + "' and opc_documento = '" + Opc_documento + "' and idclavedoc = " + IdClaveDoc.ToString();

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
            nuevoAdcPag(dt, this);
            //
            try
            {
                da.Update(dt);
                dt.AcceptChanges();
                return "Se ha creado un nuevo AdcPag";
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
        }
        //
        public string Borrar()
        {
            string sel = "SELECT * FROM AdcPag WHERE doc_sucursal = '" + Doc_sucursal + "' and opc_documento = '" + Opc_documento + "' and idclavedoc =" + IdClaveDoc.ToString();
            //
            return Borrar(sel);
        }
        public string Borrar(string sel)
        {
            SqlConnection cnn;
            SqlDataAdapter da;
            DataTable dt = new DataTable("AdcPag");
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
        public void grabarDetallePagosDoc(DataTable pagosDoc)
        {
            string sel = "SELECT * FROM AdcPag WHERE doc_sucursal = '" + Doc_sucursal + "' and opc_documento = '" + Opc_documento + "' and idclavedoc = " + IdClaveDoc.ToString();
            //            using (var con = new SqlConnection(cadenaConexion))
            using (var adapter = new SqlDataAdapter(sel, cadenaConexion))
            using (new SqlCommandBuilder(adapter))
            {
                DataTable table = new DataTable();
                adapter.Fill(table);
                table.Rows.Clear();
                foreach (DataRow row in pagosDoc.Rows)
                {
                    table.Rows.Add(row);
                }
                adapter.Update(table);
            }
        }

    }
}
