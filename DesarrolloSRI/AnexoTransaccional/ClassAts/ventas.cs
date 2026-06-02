using System;
using System.Data;
using System.Data.SqlClient;

namespace ClassAts
{
    public class Ventas
    {
        private System.String _CL_ExportaciónDe = "";
        private System.String _Cl_TipoComprobante = "";
        private System.String _CL_ReferendoDistrito = "";
        private System.String _CL_ReferendoAño = "";
        private System.String _CL_ReferendoRegimen = "";
        private System.String _CL_ReferendoCorrelativo = "";
        private System.String _CL_ReferendoVerificador = "";
        private System.String _CL_NroDocTransporte = "";
        private System.DateTime _CL_FechaTransaccion = new DateTime(1900, 1, 1);
        private System.String _CL_NroFUE = "";
        private System.Decimal _CL_ValorFOB = 0;
        private System.Decimal _CL_ValorComprobante = 0;
        private System.String _CL_NroSerieCpbteEstablec = "";
        private System.String _CL_NroSerieCpbteEmision = "";
        private System.String _CL_NroSecuencialCpbte = "";
        private System.String _CL_NroAutorizacion = "";
        private System.DateTime _CL_FechaEmision = new DateTime(1900, 1, 1);
        private System.Decimal _Clave = 0;
        private System.Int32 _CL_mes = 0;
        private System.Int32 _CL_anio = 0;
        private System.String _suc = "";
        private System.String _doc = "";
        private System.String _Cl_TipoId = "";
        private System.String _Cl_CodigoCliente = "";
        private System.String _Cl_NombreCliente = "";
        private System.Int64 _CL_NroDeComprobantes = 0;
        private System.Decimal _CL_BaseNoGrabaIva = 0;
        private System.Decimal _CL_BaseImpTarCero = 0;
        private System.Decimal _CL_BaseImpGravadaIva = 0;
        private System.Decimal _CL_MontoIva = 0;
        private System.Decimal _CL_ValorRetIva = 0;
        private System.Decimal _CL_ValorRetRenta = 0;
        private System.Decimal _montoIce = 0;
        private System.Int32  _tipoEmision = 0;
        private System.String _parteRelVtas = "";
        private string ajustarAncho(string cadena, int ancho)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder(new String(' ', ancho));
            return (cadena + sb.ToString()).Substring(0, ancho).Trim();
        }
        public System.String CL_ExportaciónDe
        {
            get
            {
                return ajustarAncho(_CL_ExportaciónDe, 50);
            }
            set
            {
                _CL_ExportaciónDe = value;
            }
        }
        public System.String Cl_TipoComprobante
        {
            get
            {
                return ajustarAncho(_Cl_TipoComprobante, 50);
            }
            set
            {
                _Cl_TipoComprobante = value;
            }
        }
        public System.String CL_ReferendoDistrito
        {
            get
            {
                return ajustarAncho(_CL_ReferendoDistrito, 50);
            }
            set
            {
                _CL_ReferendoDistrito = value;
            }
        }
        public System.String CL_ReferendoAño
        {
            get
            {
                return ajustarAncho(_CL_ReferendoAño, 50);
            }
            set
            {
                _CL_ReferendoAño = value;
            }
        }
        public System.String CL_ReferendoRegimen
        {
            get
            {
                return ajustarAncho(_CL_ReferendoRegimen, 50);
            }
            set
            {
                _CL_ReferendoRegimen = value;
            }
        }
        public System.String CL_ReferendoCorrelativo
        {
            get
            {
                return ajustarAncho(_CL_ReferendoCorrelativo, 50);
            }
            set
            {
                _CL_ReferendoCorrelativo = value;
            }
        }
        public System.String CL_ReferendoVerificador
        {
            get
            {
                return ajustarAncho(_CL_ReferendoVerificador, 50);
            }
            set
            {
                _CL_ReferendoVerificador = value;
            }
        }
        public System.String CL_NroDocTransporte
        {
            get
            {
                return ajustarAncho(_CL_NroDocTransporte, 50);
            }
            set
            {
                _CL_NroDocTransporte = value;
            }
        }
        public System.DateTime CL_FechaTransaccion
        {
            get
            {
                return _CL_FechaTransaccion;
            }
            set
            {
                _CL_FechaTransaccion = value;
            }
        }
        public System.String CL_NroFUE
        {
            get
            {
                return ajustarAncho(_CL_NroFUE, 50);
            }
            set
            {
                _CL_NroFUE = value;
            }
        }
        public System.Decimal CL_ValorFOB
        {
            get
            {
                return _CL_ValorFOB;
            }
            set
            {
                _CL_ValorFOB = value;
            }
        }
        public System.Decimal CL_ValorComprobante
        {
            get
            {
                return _CL_ValorComprobante;
            }
            set
            {
                _CL_ValorComprobante = value;
            }
        }
        public System.String CL_NroSerieCpbteEstablec
        {
            get
            {
                return ajustarAncho(_CL_NroSerieCpbteEstablec, 50);
            }
            set
            {
                _CL_NroSerieCpbteEstablec = value;
            }
        }
        public System.String CL_NroSerieCpbteEmision
        {
            get
            {
                return ajustarAncho(_CL_NroSerieCpbteEmision, 50);
            }
            set
            {
                _CL_NroSerieCpbteEmision = value;
            }
        }
        public System.String CL_NroSecuencialCpbte
        {
            get
            {
                return ajustarAncho(_CL_NroSecuencialCpbte, 50);
            }
            set
            {
                _CL_NroSecuencialCpbte = value;
            }
        }
        public System.String CL_NroAutorizacion
        {
            get
            {
                return ajustarAncho(_CL_NroAutorizacion, 50);
            }
            set
            {
                _CL_NroAutorizacion = value;
            }
        }
        public System.DateTime CL_FechaEmision
        {
            get
            {
                return _CL_FechaEmision;
            }
            set
            {
                _CL_FechaEmision = value;
            }
        }
        public System.Decimal Clave
        {
            get
            {
                return _Clave;
            }
            set
            {
                _Clave = value;
            }
        }
        public System.Int32 CL_mes
        {
            get
            {
                return _CL_mes;
            }
            set
            {
                _CL_mes = value;
            }
        }
        public System.Int32 CL_anio
        {
            get
            {
                return _CL_anio;
            }
            set
            {
                _CL_anio = value;
            }
        }
        public System.String suc
        {
            get
            {
                return ajustarAncho(_suc, 3);
            }
            set
            {
                _suc = value;
            }
        }
        public System.String doc
        {
            get
            {
                return ajustarAncho(_doc, 3);
            }
            set
            {
                _doc = value;
            }
        }
        public System.String Cl_TipoId
        {
            get
            {
                return ajustarAncho(_Cl_TipoId, 50);
            }
            set
            {
                _Cl_TipoId = value;
            }
        }
        public System.String Cl_CodigoCliente
        {
            get
            {
                return ajustarAncho(_Cl_CodigoCliente, 50);
            }
            set
            {
                _Cl_CodigoCliente = value;
            }
        }
        public System.String Cl_NombreCliente
        {
            get
            {
                return ajustarAncho(_Cl_NombreCliente , 150);
            }
            set
            {
                _Cl_NombreCliente = value;
            }
        }
        public System.Int64 CL_NroDeComprobantes
        {
            get
            {
                return _CL_NroDeComprobantes;
            }
            set
            {
                _CL_NroDeComprobantes = value;
            }
        }
        public System.Decimal CL_BaseNoGrabaIva
        {
            get
            {
                return _CL_BaseNoGrabaIva;
            }
            set
            {
                _CL_BaseNoGrabaIva = value;
            }
        }
        public System.Decimal CL_BaseImpTarCero
        {
            get
            {
                return _CL_BaseImpTarCero;
            }
            set
            {
                _CL_BaseImpTarCero = value;
            }
        }
        public System.Decimal CL_BaseImpGravadaIva
        {
            get
            {
                return _CL_BaseImpGravadaIva;
            }
            set
            {
                _CL_BaseImpGravadaIva = value;
            }
        }
        public System.Decimal CL_MontoIva
        {
            get
            {
                return _CL_MontoIva;
            }
            set
            {
                _CL_MontoIva = value;
            }
        }
        public System.Decimal CL_ValorRetIva
        {
            get
            {
                return _CL_ValorRetIva;
            }
            set
            {
                _CL_ValorRetIva = value;
            }
        }
        public System.Decimal CL_ValorRetRenta
        {
            get
            {
                return _CL_ValorRetRenta;
            }
            set
            {
                _CL_ValorRetRenta = value;
            }
        }
        public System.Decimal montoIce
        {
            get
            {
                return _montoIce;
            }
            set
            {
                _montoIce = value;
            }
        }
        public System.Int32 tipoEmision
        {
            get
            {
                return _tipoEmision;
            }
            set
            {
                _tipoEmision = value;
            }
        }
        public System.String parteRelVtas
        {
            get
            {
                return ajustarAncho(_parteRelVtas, 2);
            }
            set
            {
                _parteRelVtas = value;
            }
        }
        //
        private static string cadenaConexion = @"";
        // La cadena de selección
        public static string CadenaSelect = "SELECT * FROM Ventas";
        //
        public Ventas()
        {
        }
        public Ventas(string conex)
        {
            cadenaConexion = conex;
        }
        //
        // Métodos compartidos (estáticos) privados
        //
        // asigna una fila de la tabla a un objeto Ventas
        private static Ventas row2Ventas(DataRow r)
        {
            // asigna a un objeto Ventas los datos del dataRow indicado
            Ventas oVentas = new Ventas();
            //
            oVentas.CL_ExportaciónDe = r["CL_ExportaciónDe"].ToString();
            oVentas.Cl_TipoComprobante = r["Cl_TipoComprobante"].ToString();
            oVentas.CL_ReferendoDistrito = r["CL_ReferendoDistrito"].ToString();
            oVentas.CL_ReferendoAño = r["CL_ReferendoAño"].ToString();
            oVentas.CL_ReferendoRegimen = r["CL_ReferendoRegimen"].ToString();
            oVentas.CL_ReferendoCorrelativo = r["CL_ReferendoCorrelativo"].ToString();
            oVentas.CL_ReferendoVerificador = r["CL_ReferendoVerificador"].ToString();
            oVentas.CL_NroDocTransporte = r["CL_NroDocTransporte"].ToString();
            try
            {
                oVentas.CL_FechaTransaccion = DateTime.Parse(r["CL_FechaTransaccion"].ToString());
            }
            catch
            {
                oVentas.CL_FechaTransaccion = DateTime.Now;
            }
            oVentas.CL_NroFUE = r["CL_NroFUE"].ToString();
            oVentas.CL_ValorFOB = System.Decimal.Parse("0" + r["CL_ValorFOB"].ToString());
            oVentas.CL_ValorComprobante = System.Decimal.Parse("0" + r["CL_ValorComprobante"].ToString());
            oVentas.CL_NroSerieCpbteEstablec = r["CL_NroSerieCpbteEstablec"].ToString();
            oVentas.CL_NroSerieCpbteEmision = r["CL_NroSerieCpbteEmision"].ToString();
            oVentas.CL_NroSecuencialCpbte = r["CL_NroSecuencialCpbte"].ToString();
            oVentas.CL_NroAutorizacion = r["CL_NroAutorizacion"].ToString();
            try
            {
                oVentas.CL_FechaEmision = DateTime.Parse(r["CL_FechaEmision"].ToString());
            }
            catch
            {
                oVentas.CL_FechaEmision = DateTime.Now;
            }
            oVentas.Clave = System.Decimal.Parse("0" + r["Clave"].ToString());
            oVentas.CL_mes = System.Int32.Parse("0" + r["CL_mes"].ToString());
            oVentas.CL_anio = System.Int32.Parse("0" + r["CL_anio"].ToString());
            oVentas.suc = r["suc"].ToString();
            oVentas.doc = r["doc"].ToString();
            oVentas.Cl_TipoId = r["Cl_TipoId"].ToString();
            oVentas.Cl_CodigoCliente = r["Cl_CodigoCliente"].ToString();
            oVentas.Cl_NombreCliente = r["Cl_NombreCliente"].ToString();
            oVentas.CL_NroDeComprobantes = System.Int64.Parse("0" + r["CL_NroDeComprobantes"].ToString());
            oVentas.CL_BaseNoGrabaIva = System.Decimal.Parse("0" + r["CL_BaseNoGrabaIva"].ToString());
            oVentas.CL_BaseImpTarCero = System.Decimal.Parse("0" + r["CL_BaseImpTarCero"].ToString());
            oVentas.CL_BaseImpGravadaIva = System.Decimal.Parse("0" + r["CL_BaseImpGravadaIva"].ToString());
            oVentas.CL_MontoIva = System.Decimal.Parse("0" + r["CL_MontoIva"].ToString());
            oVentas.CL_ValorRetIva = System.Decimal.Parse("0" + r["CL_ValorRetIva"].ToString());
            oVentas.CL_ValorRetRenta = System.Decimal.Parse("0" + r["CL_ValorRetRenta"].ToString());
            oVentas.montoIce = System.Decimal.Parse("0" + r["montoIce"].ToString());
            oVentas.tipoEmision = System.Int32.Parse("0" + r["tipoEmision"].ToString());
            oVentas.parteRelVtas = r["parteRelVtas"].ToString();
            //
            return oVentas;
        }
        //
        // asigna un objeto Ventas a la fila indicada
        private static void Ventas2Row(Ventas oVentas, DataRow r)
        {
            // asigna un objeto Ventas al dataRow indicado
            r["CL_ExportaciónDe"] = oVentas.CL_ExportaciónDe;
            r["Cl_TipoComprobante"] = oVentas.Cl_TipoComprobante;
            r["CL_ReferendoDistrito"] = oVentas.CL_ReferendoDistrito;
            r["CL_ReferendoAño"] = oVentas.CL_ReferendoAño;
            r["CL_ReferendoRegimen"] = oVentas.CL_ReferendoRegimen;
            r["CL_ReferendoCorrelativo"] = oVentas.CL_ReferendoCorrelativo;
            r["CL_ReferendoVerificador"] = oVentas.CL_ReferendoVerificador;
            r["CL_NroDocTransporte"] = oVentas.CL_NroDocTransporte;
            r["CL_FechaTransaccion"] = oVentas.CL_FechaTransaccion;
            r["CL_NroFUE"] = oVentas.CL_NroFUE;
            r["CL_ValorFOB"] = oVentas.CL_ValorFOB;
            r["CL_ValorComprobante"] = oVentas.CL_ValorComprobante;
            r["CL_NroSerieCpbteEstablec"] = oVentas.CL_NroSerieCpbteEstablec;
            r["CL_NroSerieCpbteEmision"] = oVentas.CL_NroSerieCpbteEmision;
            r["CL_NroSecuencialCpbte"] = oVentas.CL_NroSecuencialCpbte;
            r["CL_NroAutorizacion"] = oVentas.CL_NroAutorizacion;
            r["CL_FechaEmision"] = oVentas.CL_FechaEmision;
            //r["Clave"] = oVentas.Clave;
            r["CL_mes"] = oVentas.CL_mes;
            r["CL_anio"] = oVentas.CL_anio;
            r["suc"] = oVentas.suc;
            r["doc"] = oVentas.doc;
            r["Cl_TipoId"] = oVentas.Cl_TipoId;
            r["Cl_CodigoCliente"] = oVentas.Cl_CodigoCliente;
            r["Cl_NombreCliente"] = oVentas.Cl_NombreCliente;
            r["CL_NroDeComprobantes"] = oVentas.CL_NroDeComprobantes;
            r["CL_BaseNoGrabaIva"] = oVentas.CL_BaseNoGrabaIva;
            r["CL_BaseImpTarCero"] = oVentas.CL_BaseImpTarCero;
            r["CL_BaseImpGravadaIva"] = oVentas.CL_BaseImpGravadaIva;
            r["CL_MontoIva"] = oVentas.CL_MontoIva;
            r["CL_ValorRetIva"] = oVentas.CL_ValorRetIva;
            r["CL_ValorRetRenta"] = oVentas.CL_ValorRetRenta;
            r["montoIce"] = oVentas.montoIce;
            r["tipoEmision"] = oVentas.tipoEmision;
            r["parteRelVtas"] = oVentas.parteRelVtas;
        }
        //
        // crea una nueva fila y la asigna a un objeto Ventas
        private static void nuevoVentas(DataTable dt, Ventas oVentas)
        {
            // Crear un nuevo Ventas
            DataRow dr = dt.NewRow();
            Ventas oV = row2Ventas(dr);
            //
            oV.CL_ExportaciónDe = oVentas.CL_ExportaciónDe;
            oV.Cl_TipoComprobante = oVentas.Cl_TipoComprobante;
            oV.CL_ReferendoDistrito = oVentas.CL_ReferendoDistrito;
            oV.CL_ReferendoAño = oVentas.CL_ReferendoAño;
            oV.CL_ReferendoRegimen = oVentas.CL_ReferendoRegimen;
            oV.CL_ReferendoCorrelativo = oVentas.CL_ReferendoCorrelativo;
            oV.CL_ReferendoVerificador = oVentas.CL_ReferendoVerificador;
            oV.CL_NroDocTransporte = oVentas.CL_NroDocTransporte;
            oV.CL_FechaTransaccion = oVentas.CL_FechaTransaccion;
            oV.CL_NroFUE = oVentas.CL_NroFUE;
            oV.CL_ValorFOB = oVentas.CL_ValorFOB;
            oV.CL_ValorComprobante = oVentas.CL_ValorComprobante;
            oV.CL_NroSerieCpbteEstablec = oVentas.CL_NroSerieCpbteEstablec;
            oV.CL_NroSerieCpbteEmision = oVentas.CL_NroSerieCpbteEmision;
            oV.CL_NroSecuencialCpbte = oVentas.CL_NroSecuencialCpbte;
            oV.CL_NroAutorizacion = oVentas.CL_NroAutorizacion;
            oV.CL_FechaEmision = oVentas.CL_FechaEmision;
            oV.Clave = oVentas.Clave;
            oV.CL_mes = oVentas.CL_mes;
            oV.CL_anio = oVentas.CL_anio;
            oV.suc = oVentas.suc;
            oV.doc = oVentas.doc;
            oV.Cl_TipoId = oVentas.Cl_TipoId;
            oV.Cl_CodigoCliente = oVentas.Cl_CodigoCliente;
            oV.Cl_NombreCliente = oVentas.Cl_NombreCliente;
            oV.CL_NroDeComprobantes = oVentas.CL_NroDeComprobantes;
            oV.CL_BaseNoGrabaIva = oVentas.CL_BaseNoGrabaIva;
            oV.CL_BaseImpTarCero = oVentas.CL_BaseImpTarCero;
            oV.CL_BaseImpGravadaIva = oVentas.CL_BaseImpGravadaIva;
            oV.CL_MontoIva = oVentas.CL_MontoIva;
            oV.CL_ValorRetIva = oVentas.CL_ValorRetIva;
            oV.CL_ValorRetRenta = oVentas.CL_ValorRetRenta;
            oV.montoIce = oVentas.montoIce;
            oV.tipoEmision = oVentas.tipoEmision;
            oV.parteRelVtas = oVentas.parteRelVtas;
            //
            Ventas2Row(oV, dr);
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
            // devuelve una tabla con los datos de la tabla Ventas
            SqlDataAdapter da;
            DataTable dt = new DataTable("Ventas");
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
        public static Ventas Buscar(string sWhere)
        {
            // Busca en la tabla los datos indicados en el parámetro
            // el parámetro contendrá lo que se usará después del WHERE
            Ventas oVentas = null;
            SqlDataAdapter da;
            DataTable dt = new DataTable("Ventas");
            string sel = "SELECT * FROM Ventas WHERE " + sWhere;
            //
            da = new SqlDataAdapter(sel, cadenaConexion);
            da.Fill(dt);
            //
            if (dt.Rows.Count > 0)
            {
                oVentas = row2Ventas(dt.Rows[0]);
            }
            return oVentas;
        }
        //
        public string Actualizar()
        {
            string sel = "SELECT * FROM Ventas WHERE Clave = " + this.Clave.ToString();
            return Actualizar(sel);
        }
        public string Actualizar(string sel)
        {
            SqlConnection cnn;
            SqlDataAdapter da;
            DataTable dt = new DataTable("Ventas");
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
                Ventas2Row(this, dt.Rows[0]);
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
            DataTable dt = new DataTable("Ventas");
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
            nuevoVentas(dt, this);
            //
            try
            {
                da.Update(dt);
                dt.AcceptChanges();
                return "Se ha creado un nuevo Ventas";
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
        }
        //
        public string Borrar()
        {
            string sel = "SELECT * FROM Ventas WHERE Clave = " + this.Clave.ToString();
            //
            return Borrar(sel);
        }
        public string Borrar(string sel)
        {
            SqlConnection cnn;
            SqlDataAdapter da;
            DataTable dt = new DataTable("Ventas");
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
