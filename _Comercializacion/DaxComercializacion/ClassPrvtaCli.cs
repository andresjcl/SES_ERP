using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DaxComercia
{
//
    public class AdcPrvtaLis
    {
        // Las variables privadas
        // TODO: Revisar los tipos de los campos
        private System.String _Lista = "";
        private System.Int32 _Temporada = 0;
        private System.String _Descripción = "";
        private System.String _Calendario = "";
        private System.DateTime _FechaDesde = new DateTime(1900, 1, 1);
        private System.DateTime _FechaHasta = new DateTime(1900, 1, 1);
        private System.String _Moneda = "";
        private System.Boolean _IncluyeIva = false;
        private System.String _Procedimiento = "";
        private System.DateTime _FechaModifica = new DateTime(1900, 1, 1);
        private System.String _UsuarioModifica = "";
        private System.String _TipoPrecio = "";
        private System.String _Pais = "";
        private System.String _TipoCliente = "";
        private System.String _Cliente = "";
        private System.String _SQLPrecio = "";
        //
        // Este método se usará para ajustar los anchos de las propiedades
        private string ajustarAncho(string cadena, int ancho)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder(new String(' ', ancho));
            // devolver la cadena quitando los espacios en blanco
            // esto asegura que no se devolverá un tamaño mayor ni espacios "extras"
            return (cadena + sb.ToString()).Substring(0, ancho).Trim();
        }
        //
        // Las propiedades públicas
        // TODO: Revisar los tipos de las propiedades
        public System.String Lista
        {
            get
            {
                return ajustarAncho(_Lista, 20);
            }
            set
            {
                _Lista = value;
            }
        }
        public System.Int32 Temporada
        {
            get
            {
                return _Temporada;
            }
            set
            {
                _Temporada = value;
            }
        }
        public System.String Descripción
        {
            get
            {
                return ajustarAncho(_Descripción, 100);
            }
            set
            {
                _Descripción = value;
            }
        }
        public System.String Calendario
        {
            get
            {
                return ajustarAncho(_Calendario, 50);
            }
            set
            {
                _Calendario = value;
            }
        }
        public System.DateTime FechaDesde
        {
            get
            {
                return _FechaDesde;
            }
            set
            {
                _FechaDesde = value;
            }
        }
        public System.DateTime FechaHasta
        {
            get
            {
                return _FechaHasta;
            }
            set
            {
                _FechaHasta = value;
            }
        }
        public System.String Moneda
        {
            get
            {
                return ajustarAncho(_Moneda, 3);
            }
            set
            {
                _Moneda = value;
            }
        }
        public System.Boolean IncluyeIva
        {
            get
            {
                return _IncluyeIva;
            }
            set
            {
                _IncluyeIva = value;
            }
        }
        public System.String Procedimiento
        {
            get
            {
                return ajustarAncho(_Procedimiento, 50);
            }
            set
            {
                _Procedimiento = value;
            }
        }
        public System.DateTime FechaModifica
        {
            get
            {
                return _FechaModifica;
            }
            set
            {
                _FechaModifica = value;
            }
        }
        public System.String UsuarioModifica
        {
            get
            {
                return ajustarAncho(_UsuarioModifica, 20);
            }
            set
            {
                _UsuarioModifica = value;
            }
        }
        public System.String TipoPrecio
        {
            get
            {
                return ajustarAncho(_TipoPrecio, 20);
            }
            set
            {
                _TipoPrecio = value;
            }
        }
        public System.String Pais
        {
            get
            {
                return ajustarAncho(_Pais, 10);
            }
            set
            {
                _Pais = value;
            }
        }
        public System.String TipoCliente
        {
            get
            {
                return ajustarAncho(_TipoCliente, 10);
            }
            set
            {
                _TipoCliente = value;
            }
        }
        public System.String Cliente
        {
            get
            {
                return ajustarAncho(_Cliente, 30);
            }
            set
            {
                _Cliente = value;
            }
        }
        public System.String SQLPrecio
        {
            get
            {
                // Seguramente sería mejor sin ajustar el ancho...
                //return ajustarAncho(_SQLPrecio,512);
                return _SQLPrecio;
            }
            set
            {
                _SQLPrecio = value;
            }
        }
        //
        //
        // Campos y métodos compartidos (estáticos) para gestionar la base de datos
        //
        // La cadena de conexión a la base de datos
        private static string cadenaConexion = @"Data Source=192.168.131.5; Initial Catalog=bdadcomdxforestek2014; user id=sa; password=123qweASDZXC";
        // La cadena de selección
        public static string CadenaSelect = "SELECT * FROM AdcPrvtaLis";
        //
        public AdcPrvtaLis()
        {
        }
        public AdcPrvtaLis(string conex)
        {
            cadenaConexion = conex;
        }
        // asigna una fila de la tabla a un objeto AdcPrvtaLis
        private static AdcPrvtaLis row2AdcPrvtaLis(DataRow r)
        {
            // asigna a un objeto AdcPrvtaLis los datos del dataRow indicado
            AdcPrvtaLis oAdcPrvtaLis = new AdcPrvtaLis();
            //
            oAdcPrvtaLis.Lista = r["Lista"].ToString();
            oAdcPrvtaLis.Temporada = System.Int32.Parse("0" + r["Temporada"].ToString());
            oAdcPrvtaLis.Descripción = r["Descripción"].ToString();
            oAdcPrvtaLis.Calendario = r["Calendario"].ToString();
            try
            {
                oAdcPrvtaLis.FechaDesde = DateTime.Parse(r["FechaDesde"].ToString());
            }
            catch
            {
                oAdcPrvtaLis.FechaDesde = new DateTime(1900, 1, 1);
            }
            try
            {
                oAdcPrvtaLis.FechaHasta = DateTime.Parse(r["FechaHasta"].ToString());
            }
            catch
            {
                oAdcPrvtaLis.FechaHasta = new DateTime(1900, 1, 1);
            }
            oAdcPrvtaLis.Moneda = r["Moneda"].ToString();
            try
            {
                oAdcPrvtaLis.IncluyeIva = System.Boolean.Parse(r["IncluyeIva"].ToString());
            }
            catch
            {
                oAdcPrvtaLis.IncluyeIva = false;
            }
            oAdcPrvtaLis.Procedimiento = r["Procedimiento"].ToString();
            try
            {
                oAdcPrvtaLis.FechaModifica = DateTime.Parse(r["FechaModifica"].ToString());
            }
            catch
            {
                oAdcPrvtaLis.FechaModifica = DateTime.Now;
            }
            oAdcPrvtaLis.UsuarioModifica = r["UsuarioModifica"].ToString();
            oAdcPrvtaLis.TipoPrecio = r["TipoPrecio"].ToString();
            oAdcPrvtaLis.Pais = r["Pais"].ToString();
            oAdcPrvtaLis.TipoCliente = r["TipoCliente"].ToString();
            oAdcPrvtaLis.Cliente = r["Cliente"].ToString();
            oAdcPrvtaLis.SQLPrecio = r["SQLPrecio"].ToString();
            //
            return oAdcPrvtaLis;
        }
        //
        // asigna un objeto AdcPrvtaLis a la fila indicada
        private static void AdcPrvtaLis2Row(AdcPrvtaLis oAdcPrvtaLis, DataRow r)
        {
            // asigna un objeto AdcPrvtaLis al dataRow indicado
            r["Lista"] = oAdcPrvtaLis.Lista;
            r["Temporada"] = oAdcPrvtaLis.Temporada;
            r["Descripción"] = oAdcPrvtaLis.Descripción;
            r["Calendario"] = oAdcPrvtaLis.Calendario;
            r["FechaDesde"] = oAdcPrvtaLis.FechaDesde;
            r["FechaHasta"] = oAdcPrvtaLis.FechaHasta;
            r["Moneda"] = oAdcPrvtaLis.Moneda;
            r["IncluyeIva"] = oAdcPrvtaLis.IncluyeIva;
            r["Procedimiento"] = oAdcPrvtaLis.Procedimiento;
            r["FechaModifica"] = oAdcPrvtaLis.FechaModifica;
            r["UsuarioModifica"] = oAdcPrvtaLis.UsuarioModifica;
            r["TipoPrecio"] = oAdcPrvtaLis.TipoPrecio;
            r["Pais"] = oAdcPrvtaLis.Pais;
            r["TipoCliente"] = oAdcPrvtaLis.TipoCliente;
            r["Cliente"] = oAdcPrvtaLis.Cliente;
            r["SQLPrecio"] = oAdcPrvtaLis.SQLPrecio;
        }
        //
        // crea una nueva fila y la asigna a un objeto AdcPrvtaLis
        private static void nuevoAdcPrvtaLis(DataTable dt, AdcPrvtaLis oAdcPrvtaLis)
        {
            // Crear un nuevo AdcPrvtaLis
            DataRow dr = dt.NewRow();
            AdcPrvtaLis oA = row2AdcPrvtaLis(dr);
            //
            oA.Lista = oAdcPrvtaLis.Lista;
            oA.Temporada = oAdcPrvtaLis.Temporada;
            oA.Descripción = oAdcPrvtaLis.Descripción;
            oA.Calendario = oAdcPrvtaLis.Calendario;
            oA.FechaDesde = oAdcPrvtaLis.FechaDesde;
            oA.FechaHasta = oAdcPrvtaLis.FechaHasta;
            oA.Moneda = oAdcPrvtaLis.Moneda;
            oA.IncluyeIva = oAdcPrvtaLis.IncluyeIva;
            oA.Procedimiento = oAdcPrvtaLis.Procedimiento;
            oA.FechaModifica = oAdcPrvtaLis.FechaModifica;
            oA.UsuarioModifica = oAdcPrvtaLis.UsuarioModifica;
            oA.TipoPrecio = oAdcPrvtaLis.TipoPrecio;
            oA.Pais = oAdcPrvtaLis.Pais;
            oA.TipoCliente = oAdcPrvtaLis.TipoCliente;
            oA.Cliente = oAdcPrvtaLis.Cliente;
            oA.SQLPrecio = oAdcPrvtaLis.SQLPrecio;
            //
            AdcPrvtaLis2Row(oA, dr);
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
            // devuelve una tabla con los datos de la tabla AdcPrvtaLis
            SqlDataAdapter da;
            DataTable dt = new DataTable("AdcPrvtaLis");
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
        public static AdcPrvtaLis Buscar(string sWhere)
        {
            // Busca en la tabla los datos indicados en el parámetro
            // el parámetro contendrá lo que se usará después del WHERE
            AdcPrvtaLis oAdcPrvtaLis = null;
            SqlDataAdapter da;
            DataTable dt = new DataTable("AdcPrvtaLis");
            string sel = "SELECT * FROM AdcPrvtaLis WHERE " + sWhere;
            //
            da = new SqlDataAdapter(sel, cadenaConexion);
            da.Fill(dt);
            //
            if (dt.Rows.Count > 0)
            {
                oAdcPrvtaLis = row2AdcPrvtaLis(dt.Rows[0]);
            }
            return oAdcPrvtaLis;
        }
        public string Actualizar()
        {
            string sel = "SELECT * FROM AdcPrvtaLis WHERE lista = " + Lista.ToString();
            return Actualizar(sel);
        }
        public string Actualizar(string sel)
        {
            // En caso de error, devolverá la cadena empezando por ERROR.
            SqlConnection cnn;
            SqlDataAdapter da;
            DataTable dt = new DataTable("AdcPrvtaLis");
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
                return Crear();
            }
            else
            {
                AdcPrvtaLis2Row(this, dt.Rows[0]);
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
            DataTable dt = new DataTable("AdcPrvtaLis");
            //
            cnn = new SqlConnection(cadenaConexion);
            da = new SqlDataAdapter(CadenaSelect, cnn);
            //da = new SqlDataAdapter(CadenaSelect, cadenaConexion);
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
            nuevoAdcPrvtaLis(dt, this);
            //
            try
            {
                da.Update(dt);
                dt.AcceptChanges();
                return "Se ha creado un nuevo AdcPrvtaLis";
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
        }
        //
        public string Borrar()
        {
            string sel = "SELECT * FROM AdcPrvtaLis WHERE  lista = " + Lista.ToString();
            //
            return Borrar(sel);
        }
        public string Borrar(string sel)
        {
            SqlConnection cnn;
            SqlDataAdapter da;
            DataTable dt = new DataTable("AdcPrvtaLis");
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
    }  //
}
