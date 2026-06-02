using System;
using System.Data;
using System.Data.SqlClient;
//

namespace ClassDoc
{
    public class AdcApl
    {
        private System.String _Doc_sucursal = "";
        private System.String _Opc_documento = "";
        private System.Decimal _Doc_numero = 0;
        private System.String _Apl_sucapli = "";
        private System.String _Apl_docapli = "";
        private System.Decimal _Apl_numapli = 0;
        private System.DateTime _Apl_docfecha = new DateTime(1900, 1, 1);
        private System.DateTime _Apl_fecha = new DateTime(1900, 1, 1);
        private System.Decimal _Apl_valorapl = 0;
        private System.String _Apl_codbenef = "";
        private System.String _Apl_DocGar = "";
        private System.Decimal _Apl_NumGar = 0;
        private System.Boolean _Apl_SNContado = false;
        private System.Decimal _IdClaveDoc = 0;
        private System.Decimal _IdClaveDocApl = 0;
        private System.Decimal _IdClaveDocGar = 0;
        private System.String _CodConcepto = "";
        private System.String _DescripcionConcepto = "";
        private System.String _Pag_DocPagoSucursal = "";
        private System.Int32 _tra_Ventas = 0;
        private System.Int32 _tra_Compras = 0;
        private System.String _espago = "";
        private System.Int32 _tra_Banco = 0;
        private System.Boolean _tra_CtasCobrar = false;
        private System.Int32 _tra_CtasPagar = 0;
        private System.Boolean _tra_esanticipo = false;
        private System.String _tra_costo = "";
        private System.String _tra_centroproduccion = "";
        private System.String _tra_centrodistribucion = "";
        private System.String _tra_empleado = "";
        private System.String _Tra_Proyecto = "";
        private System.String _tra_directorio = "";
        private System.Boolean _tra_escontable = false;
        private System.Decimal _apl_valorcierre = 0;
        private System.Decimal _Idclaveapl = 0;
        private System.Decimal _Idclaveaplapl = 0;
        private System.Int32 _numLinApl = 0;

        // Este método se usará para ajustar los anchos de las propiedades
        private string ajustarAncho(string cadena, int ancho)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder(new String(' ', ancho));
            // devolver la cadena quitando los espacios en blanco
            // esto asegura que no se devolverá un tamaño mayor ni espacios "extras"
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
        public System.String Apl_sucapli
        {
            get
            {
                return ajustarAncho(_Apl_sucapli, 3);
            }
            set
            {
                _Apl_sucapli = value;
            }
        }
        public System.String Apl_docapli
        {
            get
            {
                return ajustarAncho(_Apl_docapli, 3);
            }
            set
            {
                _Apl_docapli = value;
            }
        }
        public System.Decimal Apl_numapli
        {
            get
            {
                return _Apl_numapli;
            }
            set
            {
                _Apl_numapli = value;
            }
        }
        public System.DateTime Apl_docfecha
        {
            get
            {
                return _Apl_docfecha;
            }
            set
            {
                _Apl_docfecha = value;
            }
        }
        public System.DateTime Apl_fecha
        {
            get
            {
                return _Apl_fecha;
            }
            set
            {
                _Apl_fecha = value;
            }
        }
        public System.Decimal Apl_valorapl
        {
            get
            {
                return _Apl_valorapl;
            }
            set
            {
                _Apl_valorapl = value;
            }
        }
        public System.String Apl_codbenef
        {
            get
            {
                return ajustarAncho(_Apl_codbenef, 20);
            }
            set
            {
                _Apl_codbenef = value;
            }
        }
        public System.String Apl_DocGar
        {
            get
            {
                return ajustarAncho(_Apl_DocGar, 3);
            }
            set
            {
                _Apl_DocGar = value;
            }
        }
        public System.Decimal Apl_NumGar
        {
            get
            {
                return _Apl_NumGar;
            }
            set
            {
                _Apl_NumGar = value;
            }
        }
        public System.Boolean Apl_SNContado
        {
            get
            {
                return _Apl_SNContado;
            }
            set
            {
                _Apl_SNContado = value;
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
        public System.Decimal IdClaveDocApl
        {
            get
            {
                return _IdClaveDocApl;
            }
            set
            {
                _IdClaveDocApl = value;
            }
        }
        public System.Decimal IdClaveDocGar
        {
            get
            {
                return _IdClaveDocGar;
            }
            set
            {
                _IdClaveDocGar = value;
            }
        }
        public System.String CodConcepto
        {
            get
            {
                return ajustarAncho(_CodConcepto, 20);
            }
            set
            {
                _CodConcepto = value;
            }
        }
        public System.String DescripcionConcepto
        {
            get
            {
                // Seguramente sería mejor sin ajustar el ancho...
                //return ajustarAncho(_DescripcionConcepto,256);
                return _DescripcionConcepto;
            }
            set
            {
                _DescripcionConcepto = value;
            }
        }
        public System.String Pag_DocPagoSucursal
        {
            get
            {
                return ajustarAncho(_Pag_DocPagoSucursal, 3);
            }
            set
            {
                _Pag_DocPagoSucursal = value;
            }
        }
        public System.Int32 tra_Ventas
        {
            get
            {
                return _tra_Ventas;
            }
            set
            {
                _tra_Ventas = value;
            }
        }
        public System.Int32 tra_Compras
        {
            get
            {
                return _tra_Compras;
            }
            set
            {
                _tra_Compras = value;
            }
        }
        public System.String espago
        {
            get
            {
                return ajustarAncho(_espago, 1);
            }
            set
            {
                _espago = value;
            }
        }
        public System.Int32 tra_Banco
        {
            get
            {
                return _tra_Banco;
            }
            set
            {
                _tra_Banco = value;
            }
        }
        public System.Boolean tra_CtasCobrar
        {
            get
            {
                return _tra_CtasCobrar;
            }
            set
            {
                _tra_CtasCobrar = value;
            }
        }
        public System.Int32 tra_CtasPagar
        {
            get
            {
                return _tra_CtasPagar;
            }
            set
            {
                _tra_CtasPagar = value;
            }
        }
        public System.Boolean tra_esanticipo
        {
            get
            {
                return _tra_esanticipo;
            }
            set
            {
                _tra_esanticipo = value;
            }
        }
        public System.String tra_costo
        {
            get
            {
                return _tra_costo;
            }
            set
            {
                _tra_costo = value;
            }
        }
        public System.String tra_centroproduccion
        {
            get
            {
                return _tra_centroproduccion;
            }
            set
            {
                _tra_centroproduccion = value;
            }
        }
        public System.String tra_centrodistribucion
        {
            get
            {
                return _tra_centrodistribucion;
            }
            set
            {
                _tra_centrodistribucion = value;
            }
        }
        public System.String tra_empleado
        {
            get
            {
                return _tra_empleado;
            }
            set
            {
                _tra_empleado = value;
            }
        }
        public System.String Tra_Proyecto
        {
            get
            {
                return _Tra_Proyecto;
            }
            set
            {
                _Tra_Proyecto = value;
            }
        }
        public System.String tra_directorio
        {
            get
            {
                return _tra_directorio;
            }
            set
            {
                _tra_directorio = value;
            }
        }
        public System.Boolean tra_escontable
        {
            get
            {
                return _tra_escontable;
            }
            set
            {
                _tra_escontable = value;
            }
        }
        public System.Decimal apl_valorcierre
        {
            get
            {
                return _apl_valorcierre;
            }
            set
            {
                _apl_valorcierre = value;
            }
        }
        public System.Decimal Idclaveapl
        {
            get
            {
                return _Idclaveapl;
            }
            set
            {
                _Idclaveapl = value;
            }
        }
        public System.Decimal Idclaveaplapl
        {
            get
            {
                return _Idclaveaplapl;
            }
            set
            {
                _Idclaveaplapl = value;
            }
        }
        public System.Int32 numLinApl
        {
            get
            {
                return _numLinApl;
            }
            set
            {
                _numLinApl = value;
            }
        }
        //
        // La cadena de conexión a la base de datos
        private static string cadenaConexion = @"";
        // La cadena de selección
        public static string CadenaSelect = "SELECT * FROM AdcApl";
        //
        public AdcApl()
        {
        }
        public AdcApl(string conex)
        {
            cadenaConexion = conex;
        }
        //
        // asigna una fila de la tabla a un objeto AdcApl
        private static AdcApl row2AdcApl(DataRow r)
        {
            // asigna a un objeto AdcApl los datos del dataRow indicado
            AdcApl oAdcApl = new AdcApl();
            //
            oAdcApl.Doc_sucursal = r["Doc_sucursal"].ToString();
            oAdcApl.Opc_documento = r["Opc_documento"].ToString();
            oAdcApl.Doc_numero = System.Decimal.Parse("0" + r["Doc_numero"].ToString());
            oAdcApl.Apl_sucapli = r["Apl_sucapli"].ToString();
            oAdcApl.Apl_docapli = r["Apl_docapli"].ToString();
            oAdcApl.Apl_numapli = System.Decimal.Parse("0" + r["Apl_numapli"].ToString());
            try
            {
                oAdcApl.Apl_docfecha = DateTime.Parse(r["Apl_docfecha"].ToString());
            }
            catch
            {
                oAdcApl.Apl_docfecha = DateTime.Now;
            }
            try
            {
                oAdcApl.Apl_fecha = DateTime.Parse(r["Apl_fecha"].ToString());
            }
            catch
            {
                oAdcApl.Apl_fecha = DateTime.Now;
            }
            oAdcApl.Apl_valorapl = System.Decimal.Parse("0" + r["Apl_valorapl"].ToString());
            oAdcApl.Apl_codbenef = r["Apl_codbenef"].ToString();
            oAdcApl.Apl_DocGar = r["Apl_DocGar"].ToString();
            oAdcApl.Apl_NumGar = System.Decimal.Parse("0" + r["Apl_NumGar"].ToString());
            try
            {
                oAdcApl.Apl_SNContado = System.Boolean.Parse(r["Apl_SNContado"].ToString());
            }
            catch
            {
                oAdcApl.Apl_SNContado = false;
            }
            oAdcApl.IdClaveDoc = System.Decimal.Parse("0" + r["IdClaveDoc"].ToString());
            oAdcApl.IdClaveDocApl = System.Decimal.Parse("0" + r["IdClaveDocApl"].ToString());
            oAdcApl.IdClaveDocGar = System.Decimal.Parse("0" + r["IdClaveDocGar"].ToString());
            oAdcApl.CodConcepto = r["CodConcepto"].ToString();
            oAdcApl.DescripcionConcepto = r["DescripcionConcepto"].ToString();
            oAdcApl.Pag_DocPagoSucursal = r["Pag_DocPagoSucursal"].ToString();
            oAdcApl.tra_Ventas = System.Int32.Parse("0" + r["tra_Ventas"].ToString());
            oAdcApl.tra_Compras = System.Int32.Parse("0" + r["tra_Compras"].ToString());
            oAdcApl.espago = r["espago"].ToString();
            oAdcApl.tra_Banco = System.Int32.Parse("0" + r["tra_Banco"].ToString());
            try
            {
                oAdcApl.tra_CtasCobrar = System.Boolean.Parse(r["tra_CtasCobrar"].ToString());
            }
            catch
            {
                oAdcApl.tra_CtasCobrar = false;
            }
            oAdcApl.tra_CtasPagar = System.Int32.Parse("0" + r["tra_CtasPagar"].ToString());
            try
            {
                oAdcApl.tra_esanticipo = System.Boolean.Parse(r["tra_esanticipo"].ToString());
            }
            catch
            {
                oAdcApl.tra_esanticipo = false;
            }
            oAdcApl.tra_costo = r["tra_costo"].ToString();
            oAdcApl.tra_centroproduccion = r["tra_centroproduccion"].ToString();
            oAdcApl.tra_centrodistribucion = r["tra_centrodistribucion"].ToString();
            oAdcApl.tra_empleado = r["tra_empleado"].ToString();
            oAdcApl.Tra_Proyecto = r["Tra_Proyecto"].ToString();
            oAdcApl.tra_directorio = r["tra_directorio"].ToString();
            try
            {
                oAdcApl.tra_escontable = System.Boolean.Parse(r["tra_escontable"].ToString());
            }
            catch
            {
                oAdcApl.tra_escontable = false;
            }
            oAdcApl.apl_valorcierre = System.Decimal.Parse("0" + r["apl_valorcierre"].ToString());
            oAdcApl.Idclaveapl = System.Decimal.Parse("0" + r["Idclaveapl"].ToString());
            oAdcApl.Idclaveaplapl = System.Decimal.Parse("0" + r["Idclaveaplapl"].ToString());
            oAdcApl.numLinApl = System.Int32.Parse("0" + r["numLinApl"].ToString());
            //
            return oAdcApl;
        }
        //
        // asigna un objeto AdcApl a la fila indicada
        public static void AdcApl2Row(AdcApl oAdcApl, DataRow r)
        {
            // asigna un objeto AdcApl al dataRow indicado
            r["Doc_sucursal"] = oAdcApl.Doc_sucursal;
            r["Opc_documento"] = oAdcApl.Opc_documento;
            r["Doc_numero"] = oAdcApl.Doc_numero;
            r["Apl_sucapli"] = oAdcApl.Apl_sucapli;
            r["Apl_docapli"] = oAdcApl.Apl_docapli;
            r["Apl_numapli"] = oAdcApl.Apl_numapli;
            r["Apl_docfecha"] = oAdcApl.Apl_docfecha;
            r["Apl_fecha"] = oAdcApl.Apl_fecha;
            r["Apl_valorapl"] = oAdcApl.Apl_valorapl;
            r["Apl_codbenef"] = oAdcApl.Apl_codbenef;
            r["Apl_DocGar"] = oAdcApl.Apl_DocGar;
            r["Apl_NumGar"] = oAdcApl.Apl_NumGar;
            r["Apl_SNContado"] = oAdcApl.Apl_SNContado;
            r["IdClaveDoc"] = oAdcApl.IdClaveDoc;
            r["IdClaveDocApl"] = oAdcApl.IdClaveDocApl;
            r["IdClaveDocGar"] = oAdcApl.IdClaveDocGar;
            r["CodConcepto"] = oAdcApl.CodConcepto;
            r["DescripcionConcepto"] = oAdcApl.DescripcionConcepto;
            r["Pag_DocPagoSucursal"] = oAdcApl.Pag_DocPagoSucursal;
            r["tra_Ventas"] = oAdcApl.tra_Ventas;
            r["tra_Compras"] = oAdcApl.tra_Compras;
            r["espago"] = oAdcApl.espago;
            r["tra_Banco"] = oAdcApl.tra_Banco;
            r["tra_CtasCobrar"] = oAdcApl.tra_CtasCobrar;
            r["tra_CtasPagar"] = oAdcApl.tra_CtasPagar;
            r["tra_esanticipo"] = oAdcApl.tra_esanticipo;
            r["tra_costo"] = oAdcApl.tra_costo;
            r["tra_centroproduccion"] = oAdcApl.tra_centroproduccion;
            r["tra_centrodistribucion"] = oAdcApl.tra_centrodistribucion;
            r["tra_empleado"] = oAdcApl.tra_empleado;
            r["Tra_Proyecto"] = oAdcApl.Tra_Proyecto;
            r["tra_directorio"] = oAdcApl.tra_directorio;
            r["tra_escontable"] = oAdcApl.tra_escontable;
            r["apl_valorcierre"] = oAdcApl.apl_valorcierre;
            r["Idclaveapl"] = oAdcApl.Idclaveapl;
            r["Idclaveaplapl"] = oAdcApl.Idclaveaplapl;
            r["numLinApl"] = oAdcApl.numLinApl;
        }
        //
        // crea una nueva fila y la asigna a un objeto AdcApl
        private static void nuevoAdcApl(DataTable dt, AdcApl oAdcApl)
        {
            // Crear un nuevo AdcApl
            DataRow dr = dt.NewRow();
            AdcApl oA = row2AdcApl(dr);
            //
            oA.Doc_sucursal = oAdcApl.Doc_sucursal;
            oA.Opc_documento = oAdcApl.Opc_documento;
            oA.Doc_numero = oAdcApl.Doc_numero;
            oA.Apl_sucapli = oAdcApl.Apl_sucapli;
            oA.Apl_docapli = oAdcApl.Apl_docapli;
            oA.Apl_numapli = oAdcApl.Apl_numapli;
            oA.Apl_docfecha = oAdcApl.Apl_docfecha;
            oA.Apl_fecha = oAdcApl.Apl_fecha;
            oA.Apl_valorapl = oAdcApl.Apl_valorapl;
            oA.Apl_codbenef = oAdcApl.Apl_codbenef;
            oA.Apl_DocGar = oAdcApl.Apl_DocGar;
            oA.Apl_NumGar = oAdcApl.Apl_NumGar;
            oA.Apl_SNContado = oAdcApl.Apl_SNContado;
            oA.IdClaveDoc = oAdcApl.IdClaveDoc;
            oA.IdClaveDocApl = oAdcApl.IdClaveDocApl;
            oA.IdClaveDocGar = oAdcApl.IdClaveDocGar;
            oA.CodConcepto = oAdcApl.CodConcepto;
            oA.DescripcionConcepto = oAdcApl.DescripcionConcepto;
            oA.Pag_DocPagoSucursal = oAdcApl.Pag_DocPagoSucursal;
            oA.tra_Ventas = oAdcApl.tra_Ventas;
            oA.tra_Compras = oAdcApl.tra_Compras;
            oA.espago = oAdcApl.espago;
            oA.tra_Banco = oAdcApl.tra_Banco;
            oA.tra_CtasCobrar = oAdcApl.tra_CtasCobrar;
            oA.tra_CtasPagar = oAdcApl.tra_CtasPagar;
            oA.tra_esanticipo = oAdcApl.tra_esanticipo;
            oA.tra_costo = oAdcApl.tra_costo;
            oA.tra_centroproduccion = oAdcApl.tra_centroproduccion;
            oA.tra_centrodistribucion = oAdcApl.tra_centrodistribucion;
            oA.tra_empleado = oAdcApl.tra_empleado;
            oA.Tra_Proyecto = oAdcApl.Tra_Proyecto;
            oA.tra_directorio = oAdcApl.tra_directorio;
            oA.tra_escontable = oAdcApl.tra_escontable;
            oA.apl_valorcierre = oAdcApl.apl_valorcierre;
            oA.Idclaveapl = oAdcApl.Idclaveapl;
            oA.Idclaveaplapl = oAdcApl.Idclaveaplapl;
            oA.numLinApl = oAdcApl.numLinApl;
            //
            AdcApl2Row(oA, dr);
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
            SqlDataAdapter da;
            DataTable dt = new DataTable("AdcApl");
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
        public static AdcApl Buscar(string sWhere)
        {
            // Busca en la tabla los datos indicados en el parámetro
            // el parámetro contendrá lo que se usará después del WHERE
            AdcApl oAdcApl = null;
            SqlDataAdapter da;
            DataTable dt = new DataTable("AdcApl");
            string sel = "SELECT * FROM AdcApl WHERE " + sWhere;
            //
            da = new SqlDataAdapter(sel, cadenaConexion);
            da.Fill(dt);
            //
            if (dt.Rows.Count > 0)
            {
                oAdcApl = row2AdcApl(dt.Rows[0]);
            }
            return oAdcApl;
        }
        //
        public string Actualizar()
        {
            string sel = "SELECT * FROM AdcApl WHERE doc_sucursal =  '" + Doc_sucursal + "' and opc_documento = '" + Opc_documento + "' and idclavedoc = " + IdClaveDoc.ToString();
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
            DataTable dt = new DataTable("AdcApl");
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
                AdcApl2Row(this, dt.Rows[0]);
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
            DataTable dt = new DataTable("AdcApl");
            CadenaSelect = "SELECT * FROM AdcApl WHERE doc_sucursal = '" + Doc_sucursal + "' and opc_documento = '" + Opc_documento + "' and idclavedoc = " + IdClaveDoc.ToString();
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
            nuevoAdcApl(dt, this);
            //
            try
            {
                da.Update(dt);
                dt.AcceptChanges();
                return "Se ha creado un nuevo AdcApl";
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
        }
        //
        public string Borrar()
        {
            string sel = "SELECT * FROM AdcApl WHERE doc_sucursal =  '" + Doc_sucursal + "' and opc_documento = '" + Opc_documento + "' and idclavedoc = " + IdClaveDoc.ToString();
            //
            return Borrar(sel);
        }
        public string Borrar(string sel)
        {
            // Borrar el registro al que apunta esta clase
            // En caso de error, devolverá la cadena de error empezando por ERROR:.
            SqlConnection cnn;
            SqlDataAdapter da;
            DataTable dt = new DataTable("AdcApl");
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
        //public void GuardarAplicacionSimple(Double IdClaveDoc, Double  idClaveDocapl , string  Doc , Double  Num , DateTime  Fec, string  CodPer
        //    ,string DocApli,long NumApli,string FecApli, double ValoApli, Boolean SNContado, string SucDoc = "", string SucApl = ""
        //    ,string ESPAGO = "", Int32 numlin = 0)
        //{
        //    string codsql = "";
        //    string QSUCDOC ="";
        //    string QSUCAPL = "";
        //    DataTable Rs1doc = new DataTable();
        //    //Dim SYSEMP As New AdcDaxx.DaxSofSys()
        //    //Dim EMP As AdcDaxx.Empresa
        //    Random r = new Random(DateTime.Now.Millisecond);
        //    if (numlin == 0) numlin = r.Next(100);
        //    //EMP = SYSEMP.EmpresaAct
        //    //if (SucDoc.Length  == 0 ) Then QSUCDOC = EMP.SucActual Else QSUCDOC = SucDoc
        //    //If Len(SucApl) = 0 Then QSUCAPL = EMP.SucActual Else QSUCAPL = SucApl

        //    codsql = " FROM AdcApl WHERE doc_sucursal='" + QSUCDOC + "' and opc_documento='" + Doc + "' and idclavedoc =" + IdClaveDoc;
        //    codsql += " and apl_docapli = '" + DocApli + "' and idclavedocapl = " + idClaveDocapl + " and apl_sucapli = '" + QSUCAPL + "'";

        //    //Dim cmd As New SqlCommand("delete" & codsql, conectarAdcomDx)
        //    //cmd.ExecuteNonQuery()
        //    //codsql = " FROM AdcApl WHERE apl_sucapli='" & QSUCDOC & "' and apl_docapli='" & Doc & "' and idclavedocapl =" & IdClaveDoc & _
        //    //        " and opc_documento = '" & DocApli & "' and idclavedoc = " & idClaveDocapl & " and doc_sucursal = '" & QSUCAPL & "'"
        //    //cmd = New SqlCommand("delete" & codsql, conectarAdcomDx)
        //    //cmd.ExecuteNonQuery()
        //    //codsql = "INSERT INTO [AdcApl] ("
        //    //codsql += "[Doc_sucursal]"
        //    //codsql += ",[Opc_documento]"
        //    //codsql += ",[Doc_numero]"
        //    //codsql += ",[Apl_sucapli]"
        //    //codsql += ",[Apl_docapli]"
        //    //codsql += ",[Apl_numapli]"
        //    //codsql += ",[Apl_docfecha]"
        //    //codsql += ",[Apl_fecha]"
        //    //codsql += ",[Apl_valorapl]"
        //    //codsql += ",[Apl_codbenef]"
        //    //codsql += ",[Apl_DocGar]"
        //    //codsql += ",[Apl_NumGar]"
        //    //codsql += ",[Apl_SNContado]"
        //    //codsql += ",[IdClaveDoc]"
        //    //codsql += ",[IdClaveDocApl]"
        //    //codsql += ",[IdClaveDocGar]"
        //    //codsql += ",[CodConcepto]"
        //    //codsql += ",[DescripcionConcepto]"
        //    //codsql += ",[tra_Ventas]"
        //    //codsql += ",[tra_Compras]"
        //    //codsql += ",[tra_Banco]"
        //    //codsql += ",[tra_CtasCobrar]"
        //    //codsql += ",[tra_CtasPagar]"
        //    //codsql += ",[tra_esanticipo]"
        //    //codsql += ",[tra_costo]"
        //    //codsql += ",[tra_centroproduccion]"
        //    //codsql += ",[tra_centrodistribucion]"
        //    //codsql += ",[tra_empleado]"
        //    //codsql += ",[Tra_Proyecto]"
        //    //codsql += ",[tra_directorio]"
        //    //codsql += ",[Pag_DocPagoSucursal]"
        //    //codsql += ",[espago]"
        //    //codsql += ",[tra_escontable]"
        //    //codsql += ",[apl_valorcierre]"
        //    //codsql += ",[Idclaveapl]"
        //    //codsql += ",[Idclaveaplapl]"
        //    //codsql += ",[CodConcepto]"
        //    //codsql += ",[numLinApl]"
        //    //codsql += ")"
        //    //codsql += " VALUES("
        //    //codsql += " '" & Trim$(QSUCDOC) & "' "
        //    //codsql += ",'" & Trim$(Doc) & "' "
        //    //codsql += "," & Num
        //    //codsql += ",'" & Trim$(QSUCAPL) & "' "
        //    //codsql += ",'" & Trim$(DocApli) & "' "
        //    //codsql += ",'" & Trim$(CStr(NumApli)) & "' "
        //    //If Not IsDate(FecApli) Then FecApli = CStr(IIf(IsDate(Fec), Fec, Now.Date))
        //    //If Not IsDate(Fec) Then Fec = CDate(FecApli)
        //    //codsql += ",'" & Fec & "' "
        //    //codsql += ",'" & FecApli & "' "
        //    //codsql += ",'" & ValoApli & "' "
        //    //codsql += ",'" & CodPer & "' "
        //    //codsql += ",'' "
        //    //codsql += ",0"
        //    //If SNContado = True Then codsql += "," & "1" Else codsql += "," & "0"
        //    //codsql += "," & IdClaveDoc
        //    //codsql += "," & idClaveDocapl
        //    //codsql += ",0"
        //    //codsql += ",'' "
        //    //codsql += ",'' "
        //    //codsql += ",0"
        //    //codsql += ",0"
        //    //codsql += ",0"
        //    //codsql += ",0"
        //    //codsql += ",0"
        //    //codsql += ",0"
        //    //codsql += ",'' "
        //    //codsql += ",'' "
        //    //codsql += ",'' "
        //    //codsql += ",'' "
        //    //codsql += ",'' "
        //    //codsql += ",'' "
        //    //codsql += ",'' "
        //    //codsql += ",'" & ESPAGO & "'"
        //    //codsql += ",0"
        //    //codsql += ",0"
        //    //codsql += ",0"
        //    //codsql += ",0"
        //    //codsql += ",''"
        //    //codsql += "," & numlin.ToString()
        //    //codsql += " )"
        //    //cmd = New SqlCommand(codsql, conectarAdcomDx)
        //    //cmd.ExecuteNonQuery()
        //    //EMP = Nothing
        //}
    }

}
