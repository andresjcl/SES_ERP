using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ClassDoc
{
    public class AdcDia
    {
        private System.String _Doc_sucursal = "";
        private System.String _Opc_documento = "";
        private System.Decimal _Doc_numero = 0;
        private System.Decimal _Dia_linea = 0;
        private System.String _Cta_codigo = "";
        private System.DateTime _Dia_fecha = new DateTime(1900, 1, 1);
        private System.String _Dia_ctanombre = "";
        private System.String _Dia_detalle = "";
        private System.Decimal _Dia_valor = 0;
        private System.Int16 _Dia_signo = 0;
        private System.String _Dia_Costo = "";
        private System.Decimal _IdClaveDoc = 0;
        private System.String _Dia_Status = "";
        private System.Decimal _Dia_PorCosto = 0;
        private System.String _Dia_empleado = "";
        private System.String _Dia_Cliente = "";
        private System.String _Dia_Proveedor = "";
        private System.String _Dia_departamento = "";
        private System.String _Dia_zona = "";
        private System.String _Dia_Producto = "";
        private System.String _Dia_Proyecto;
        private System.String _Dia_Relacionado = "";
        private System.String _Dia_Sucursal = "";
        private System.String _Dia_Rubros = "";
        private System.String _dia_centroproduccion = "";
        private System.String _dia_centroDistribucion = "";
        private System.String _dia_directorio = "";
        private System.Boolean _Nifs = false;
        //
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
        public System.Decimal Dia_linea
        {
            get
            {
                return _Dia_linea;
            }
            set
            {
                _Dia_linea = value;
            }
        }
        public System.String Cta_codigo
        {
            get
            {
                return ajustarAncho(_Cta_codigo, 15);
            }
            set
            {
                _Cta_codigo = value;
            }
        }
        public System.DateTime Dia_fecha
        {
            get
            {
                return _Dia_fecha;
            }
            set
            {
                _Dia_fecha = value;
            }
        }
        public System.String Dia_ctanombre
        {
            get
            {
                return ajustarAncho(_Dia_ctanombre, 120);
            }
            set
            {
                _Dia_ctanombre = value;
            }
        }
        public System.String Dia_detalle
        {
            get
            {
                return ajustarAncho(_Dia_detalle, 250);
            }
            set
            {
                _Dia_detalle = value;
            }
        }
        public System.Decimal Dia_valor
        {
            get
            {
                return _Dia_valor;
            }
            set
            {
                _Dia_valor = value;
            }
        }
        public System.Int16 Dia_signo
        {
            get
            {
                return _Dia_signo;
            }
            set
            {
                _Dia_signo = value;
            }
        }
        public System.String Dia_Costo
        {
            get
            {
                return ajustarAncho(_Dia_Costo, 50);
            }
            set
            {
                _Dia_Costo = value;
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
        public System.String Dia_Status
        {
            get
            {
                return ajustarAncho(_Dia_Status, 1);
            }
            set
            {
                _Dia_Status = value;
            }
        }
        public System.Decimal Dia_PorCosto
        {
            get
            {
                return _Dia_PorCosto;
            }
            set
            {
                _Dia_PorCosto = value;
            }
        }
        public System.String Dia_empleado
        {
            get
            {
                return ajustarAncho(_Dia_empleado, 50);
            }
            set
            {
                _Dia_empleado = value;
            }
        }
        public System.String Dia_Cliente
        {
            get
            {
                return ajustarAncho(_Dia_Cliente, 50);
            }
            set
            {
                _Dia_Cliente = value;
            }
        }
        public System.String Dia_Proveedor
        {
            get
            {
                return ajustarAncho(_Dia_Proveedor, 50);
            }
            set
            {
                _Dia_Proveedor = value;
            }
        }
        public System.String Dia_departamento
        {
            get
            {
                return ajustarAncho(_Dia_departamento, 50);
            }
            set
            {
                _Dia_departamento = value;
            }
        }
        public System.String Dia_zona
        {
            get
            {
                return ajustarAncho(_Dia_zona, 50);
            }
            set
            {
                _Dia_zona = value;
            }
        }
        public System.String Dia_Producto
        {
            get
            {
                return ajustarAncho(_Dia_Producto, 50);
            }
            set
            {
                _Dia_Producto = value;
            }
        }
        public System.String Dia_Proyecto
        {
            get
            {
                return ajustarAncho(_Dia_Proyecto, 50);
            }
            set
            {
                _Dia_Proyecto = value;
            }
        }
        public System.String Dia_Relacionado
        {
            get
            {
                return ajustarAncho(_Dia_Relacionado, 50);
            }
            set
            {
                _Dia_Relacionado = value;
            }
        }
        public System.String Dia_Sucursal
        {
            get
            {
                return ajustarAncho(_Dia_Sucursal, 50);
            }
            set
            {
                _Dia_Sucursal = value;
            }
        }
        public System.String Dia_Rubros
        {
            get
            {
                return ajustarAncho(_Dia_Rubros, 50);
            }
            set
            {
                _Dia_Rubros = value;
            }
        }
        public System.String dia_centroproduccion
        {
            get
            {
                return ajustarAncho(_dia_centroproduccion, 50);
            }
            set
            {
                _dia_centroproduccion = value;
            }
        }
        public System.String dia_centroDistribucion
        {
            get
            {
                return ajustarAncho(_dia_centroDistribucion, 50);
            }
            set
            {
                _dia_centroDistribucion = value;
            }
        }
        public System.String dia_directorio
        {
            get
            {
                return ajustarAncho(_dia_directorio, 50);
            }
            set
            {
                _dia_directorio = value;
            }
        }
        public System.Boolean Nifs
        {
            get
            {
                return _Nifs;
            }
            set
            {
                _Nifs = value;
            }
        }
        //
        // La cadena de conexión a la base de datos
        private static string cadenaConexion = @"";
        // La cadena de selección
        public static string CadenaSelect = "";
        //
        public AdcDia()
        {
        }
        public AdcDia(string conex)
        {
            cadenaConexion = conex;
        }
        //
        private static AdcDia row2AdcDia(DataRow r)
        {
            // asigna a un objeto AdcDia los datos del dataRow indicado
            AdcDia oAdcDia = new AdcDia();
            //
            oAdcDia.Doc_sucursal = r["Doc_sucursal"].ToString();
            oAdcDia.Opc_documento = r["Opc_documento"].ToString();
            oAdcDia.Doc_numero = System.Decimal.Parse("0" + r["Doc_numero"].ToString());
            oAdcDia.Dia_linea = System.Decimal.Parse("0" + r["Dia_linea"].ToString());
            oAdcDia.Cta_codigo = r["Cta_codigo"].ToString();
            try
            {
                oAdcDia.Dia_fecha = DateTime.Parse(r["Dia_fecha"].ToString());
            }
            catch
            {
                oAdcDia.Dia_fecha = DateTime.Now;
            }
            oAdcDia.Dia_ctanombre = r["Dia_ctanombre"].ToString();
            oAdcDia.Dia_detalle = r["Dia_detalle"].ToString();
            oAdcDia.Dia_valor = System.Decimal.Parse("0" + r["Dia_valor"].ToString());
            oAdcDia.Dia_signo = System.Int16.Parse("0" + r["Dia_signo"].ToString());
            oAdcDia.Dia_Costo = r["Dia_Costo"].ToString();
            oAdcDia.IdClaveDoc = System.Decimal.Parse("0" + r["IdClaveDoc"].ToString());
            oAdcDia.Dia_Status = r["Dia_Status"].ToString();
            oAdcDia.Dia_PorCosto = System.Decimal.Parse("0" + r["Dia_PorCosto"].ToString());
            oAdcDia.Dia_empleado = r["Dia_empleado"].ToString();
            oAdcDia.Dia_Cliente = r["Dia_Cliente"].ToString();
            oAdcDia.Dia_Proveedor = r["Dia_Proveedor"].ToString();
            oAdcDia.Dia_departamento = r["Dia_departamento"].ToString();
            oAdcDia.Dia_zona = r["Dia_zona"].ToString();
            oAdcDia.Dia_Producto = r["Dia_Producto"].ToString();
            oAdcDia.Dia_Proyecto = r["Dia_Proyecto"].ToString();
            oAdcDia.Dia_Relacionado = r["Dia_Relacionado"].ToString();
            oAdcDia.Dia_Sucursal = r["Dia_Sucursal"].ToString();
            oAdcDia.Dia_Rubros = r["Dia_Rubros"].ToString();
            oAdcDia.dia_centroproduccion = r["dia_centroproduccion"].ToString();
            oAdcDia.dia_centroDistribucion = r["dia_centroDistribucion"].ToString();
            oAdcDia.dia_directorio = r["dia_directorio"].ToString();
            try
            {
                oAdcDia.Nifs = System.Boolean.Parse(r["Nifs"].ToString());
            }
            catch
            {
                oAdcDia.Nifs = false;
            }
            //
            return oAdcDia;
        }
        //
        // asigna un objeto AdcDia a la fila indicada
        private static void AdcDia2Row(AdcDia oAdcDia, DataRow r)
        {
            // asigna un objeto AdcDia al dataRow indicado
            r["Doc_sucursal"] = oAdcDia.Doc_sucursal;
            r["Opc_documento"] = oAdcDia.Opc_documento;
            r["Doc_numero"] = oAdcDia.Doc_numero;
            r["Dia_linea"] = oAdcDia.Dia_linea;
            r["Cta_codigo"] = oAdcDia.Cta_codigo;
            r["Dia_fecha"] = oAdcDia.Dia_fecha;
            r["Dia_ctanombre"] = oAdcDia.Dia_ctanombre;
            r["Dia_detalle"] = oAdcDia.Dia_detalle;
            r["Dia_valor"] = oAdcDia.Dia_valor;
            r["Dia_signo"] = oAdcDia.Dia_signo;
            r["Dia_Costo"] = oAdcDia.Dia_Costo;
            r["IdClaveDoc"] = oAdcDia.IdClaveDoc;
            r["Dia_Status"] = oAdcDia.Dia_Status;
            r["Dia_PorCosto"] = oAdcDia.Dia_PorCosto;
            r["Dia_empleado"] = oAdcDia.Dia_empleado;
            r["Dia_Cliente"] = oAdcDia.Dia_Cliente;
            r["Dia_Proveedor"] = oAdcDia.Dia_Proveedor;
            r["Dia_departamento"] = oAdcDia.Dia_departamento;
            r["Dia_zona"] = oAdcDia.Dia_zona;
            r["Dia_Producto"] = oAdcDia.Dia_Producto;
            r["Dia_Proyecto"] = oAdcDia.Dia_Proyecto;
            r["Dia_Relacionado"] = oAdcDia.Dia_Relacionado;
            r["Dia_Sucursal"] = oAdcDia.Dia_Sucursal;
            r["Dia_Rubros"] = oAdcDia.Dia_Rubros;
            r["dia_centroproduccion"] = oAdcDia.dia_centroproduccion;
            r["dia_centroDistribucion"] = oAdcDia.dia_centroDistribucion;
            r["dia_directorio"] = oAdcDia.dia_directorio;
            r["Nifs"] = oAdcDia.Nifs;
        }
        //
        // crea una nueva fila y la asigna a un objeto AdcDia
        private static void nuevoAdcDia(DataTable dt, AdcDia oAdcDia)
        {
            // Crear un nuevo AdcDia
            DataRow dr = dt.NewRow();
            AdcDia oA = row2AdcDia(dr);
            //
            oA.Doc_sucursal = oAdcDia.Doc_sucursal;
            oA.Opc_documento = oAdcDia.Opc_documento;
            oA.Doc_numero = oAdcDia.Doc_numero;
            oA.Dia_linea = oAdcDia.Dia_linea;
            oA.Cta_codigo = oAdcDia.Cta_codigo;
            oA.Dia_fecha = oAdcDia.Dia_fecha;
            oA.Dia_ctanombre = oAdcDia.Dia_ctanombre;
            oA.Dia_detalle = oAdcDia.Dia_detalle;
            oA.Dia_valor = oAdcDia.Dia_valor;
            oA.Dia_signo = oAdcDia.Dia_signo;
            oA.Dia_Costo = oAdcDia.Dia_Costo;
            oA.IdClaveDoc = oAdcDia.IdClaveDoc;
            oA.Dia_Status = oAdcDia.Dia_Status;
            oA.Dia_PorCosto = oAdcDia.Dia_PorCosto;
            oA.Dia_empleado = oAdcDia.Dia_empleado;
            oA.Dia_Cliente = oAdcDia.Dia_Cliente;
            oA.Dia_Proveedor = oAdcDia.Dia_Proveedor;
            oA.Dia_departamento = oAdcDia.Dia_departamento;
            oA.Dia_zona = oAdcDia.Dia_zona;
            oA.Dia_Producto = oAdcDia.Dia_Producto;
            oA.Dia_Proyecto = oAdcDia.Dia_Proyecto;
            oA.Dia_Relacionado = oAdcDia.Dia_Relacionado;
            oA.Dia_Sucursal = oAdcDia.Dia_Sucursal;
            oA.Dia_Rubros = oAdcDia.Dia_Rubros;
            oA.dia_centroproduccion = oAdcDia.dia_centroproduccion;
            oA.dia_centroDistribucion = oAdcDia.dia_centroDistribucion;
            oA.dia_directorio = oAdcDia.dia_directorio;
            oA.Nifs = oAdcDia.Nifs;
            //
            AdcDia2Row(oA, dr);
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
            // devuelve una tabla con los datos de la tabla AdcDia
            SqlDataAdapter da;
            DataTable dt = new DataTable("AdcDia");
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
        public static AdcDia Buscar(string sWhere)
        {
            AdcDia oAdcDia = null;
            SqlDataAdapter da;
            DataTable dt = new DataTable("AdcDia");
            string sel = "SELECT * FROM AdcDia WHERE " + sWhere;
            //
            da = new SqlDataAdapter(sel, cadenaConexion);
            da.Fill(dt);
            //
            if (dt.Rows.Count > 0)
            {
                oAdcDia = row2AdcDia(dt.Rows[0]);
            }
            return oAdcDia;
        }
        public string Actualizar()
        {
            string sel = "SELECT * FROM AdcDia WHERE doc_sucursal = '" + Doc_sucursal + "' and opc_documento = '" + Opc_documento + "' and idclavedoc =" + IdClaveDoc.ToString();
            return Actualizar(sel);
        }
        public string Actualizar(string sel)
        {
            SqlConnection cnn;
            SqlDataAdapter da;
            DataTable dt = new DataTable("AdcDia");
            CadenaSelect = sel;
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
                AdcDia2Row(this, dt.Rows[0]);
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
            // En caso de error, devolverá la cadena de error empezando por ERROR:.
            SqlConnection cnn;
            SqlDataAdapter da;
            DataTable dt = new DataTable("AdcDia");
            //
            CadenaSelect = "SELECT * FROM AdcDia WHERE doc_sucursal = '" + Doc_sucursal + "' and opc_documento = '" + Opc_documento + "' and idclavedoc = " + IdClaveDoc.ToString();
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
            nuevoAdcDia(dt, this);
            //
            try
            {
                da.Update(dt);
                dt.AcceptChanges();
                return "Se ha creado un nuevo AdcDia";
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
        }
        //
        public string Borrar()
        {
            string sel = "SELECT * FROM AdcDia WHERE doc_sucursal = '" + Doc_sucursal + "' and opc_documento = '" + Opc_documento + "' and idclavedoc =" + IdClaveDoc.ToString();
            //
            return Borrar(sel);
        }
        public string Borrar(string sel)
        {
            // En caso de error, devolverá la cadena de error empezando por ERROR:.
            SqlConnection cnn;
            SqlDataAdapter da;
            DataTable dt = new DataTable("AdcDia");
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
        public void grabarDetalleAdcDia(DataGridView malla)
        {
            string sel = "SELECT * FROM AdcDia WHERE doc_sucursal = '" + Doc_sucursal + "' and opc_documento = '" + Opc_documento + "' and idclavedoc = " + IdClaveDoc.ToString();
            using (var con = new SqlConnection(cadenaConexion))
            using (var adapter = new SqlDataAdapter(sel, cadenaConexion))
            using (new SqlCommandBuilder(adapter))
            {
                DataTable table = new DataTable();
                adapter.Fill(table);
                DataRow dr;
                ClassDoc.AdcDia adcdia = new ClassDoc.AdcDia();

                adcdia.Doc_sucursal = Doc_sucursal;
                adcdia.Opc_documento = Opc_documento;
                adcdia.Doc_numero = Doc_numero;
                adcdia.IdClaveDoc = IdClaveDoc;
                adcdia.Dia_fecha = Dia_fecha;
                adcdia.Dia_Status = "";

                Int32 i = 0;
                foreach (DataGridViewRow rrow in malla.Rows)
                {
                    if (rrow.Cells["Codigo"].Value != null && (rrow.Cells["Codigo"].Value).ToString() != string.Empty)
                    {
                        if (i <= table.Rows.Count - 1) { dr = table.Rows[i]; } else { dr = table.NewRow(); }
                        adcdia.Cta_codigo = rrow.Cells["Codigo"].Value.ToString();
                        adcdia.Dia_ctanombre = rrow.Cells["NombreCuenta"].Value.ToString();
                        adcdia.dia_centroDistribucion = rrow.Cells["CDistribución"].Value.ToString();
                        adcdia.dia_centroproduccion = rrow.Cells["CProducción"].Value.ToString();
                        adcdia.Dia_Cliente = rrow.Cells["Cliente"].Value.ToString();
                        adcdia.Dia_Costo = rrow.Cells["CCosto"].Value.ToString();
                        adcdia.Dia_departamento = rrow.Cells["Departamento"].Value.ToString();
                        adcdia.Dia_detalle = rrow.Cells["Detalle"].Value.ToString();
                        adcdia.dia_directorio = rrow.Cells["Directorio"].Value.ToString();
                        adcdia.Dia_empleado = rrow.Cells["Empleado"].Value.ToString();
                        adcdia.Dia_linea = i;
                        adcdia.Dia_PorCosto = Convert.ToDecimal(rrow.Cells["PorCosto"].Value.ToString());
                        adcdia.Dia_Producto = rrow.Cells["Producto"].Value.ToString();
                        adcdia.Dia_Proveedor = rrow.Cells["Proveedor"].Value.ToString();
                        adcdia.Dia_Proyecto = rrow.Cells["Proyecto"].Value.ToString();
                        adcdia.Dia_Relacionado = rrow.Cells["Relacionado"].Value.ToString();
                        adcdia.Dia_Rubros = rrow.Cells["Rubros"].Value.ToString();
                        adcdia.Dia_signo = Convert.ToInt16(rrow.Cells["Signo"].Value.ToString());
                        adcdia.Dia_valor = Convert.ToDecimal(rrow.Cells["Valor"].Value.ToString());
                        adcdia.Dia_zona = rrow.Cells["Zona"].Value.ToString();
                        adcdia.Nifs = Convert.ToBoolean(rrow.Cells["Nifs"].Value.ToString());

                        adcdia.moverAdcDiaDatarow(adcdia, ref dr);
                        if (i > table.Rows.Count - 1) table.Rows.Add(dr);
                        i++;
                    }
                }
                if (malla.RowCount - 1 < table.Rows.Count)
                {
                    for (int j = table.Rows.Count - 1; j > malla.RowCount - 2; j--)
                    {
                        table.Rows[j].Delete();
                    }
                }
                adapter.Update(table);
            }
        }

        public void moverAdcDiaDatarow(AdcDia oAdcDia, ref DataRow r)
        {
            // asigna un objeto AdcDia al dataRow indicado
            r["Doc_sucursal"] = oAdcDia.Doc_sucursal;
            r["Opc_documento"] = oAdcDia.Opc_documento;
            r["Doc_numero"] = oAdcDia.Doc_numero;
            r["Dia_linea"] = oAdcDia.Dia_linea;
            r["Cta_codigo"] = oAdcDia.Cta_codigo;
            r["Dia_fecha"] = oAdcDia.Dia_fecha;
            r["Dia_ctanombre"] = oAdcDia.Dia_ctanombre;
            r["Dia_detalle"] = oAdcDia.Dia_detalle;
            r["Dia_valor"] = oAdcDia.Dia_valor;
            r["Dia_signo"] = oAdcDia.Dia_signo;
            r["Dia_Costo"] = oAdcDia.Dia_Costo;
            r["IdClaveDoc"] = oAdcDia.IdClaveDoc;
            r["Dia_Status"] = oAdcDia.Dia_Status;
            r["Dia_PorCosto"] = oAdcDia.Dia_PorCosto;
            r["Dia_empleado"] = oAdcDia.Dia_empleado;
            r["Dia_Cliente"] = oAdcDia.Dia_Cliente;
            r["Dia_Proveedor"] = oAdcDia.Dia_Proveedor;
            r["Dia_departamento"] = oAdcDia.Dia_departamento;
            r["Dia_zona"] = oAdcDia.Dia_zona;
            r["Dia_Producto"] = oAdcDia.Dia_Producto;
            r["Dia_Proyecto"] = oAdcDia.Dia_Proyecto;
            r["Dia_Relacionado"] = oAdcDia.Dia_Relacionado;
            r["Dia_Sucursal"] = oAdcDia.Dia_Sucursal;
            r["Dia_Rubros"] = oAdcDia.Dia_Rubros;
            r["dia_centroproduccion"] = oAdcDia.dia_centroproduccion;
            r["dia_centroDistribucion"] = oAdcDia.dia_centroDistribucion;
            r["dia_directorio"] = oAdcDia.dia_directorio;
            r["Nifs"] = oAdcDia.Nifs;
        }
    }
}
