using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DaxMovCaja
{
//
public class DaxAdcPto
    {
        private System.Decimal _idclave=0;
        private System.String _Sucursal="";
        private System.String _PuntoVta="";
        private System.String _TipoMov=""; //  I ingreso G gasto L nro de lote de vauchers tarjetas de crédito
        private System.DateTime _FechaMov=new DateTime(1900,1,1);
        private System.String _Responsable="";
        private System.String _Descripción="";
        private System.Decimal _Valor=0;
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
        public System.Decimal idclave
        {
            get
            {
                return _idclave;
            }
            set
            {
                _idclave = value;
            }
        }
        public System.String Sucursal
        {
            get
            {
                return ajustarAncho(_Sucursal, 3);
            }
            set
            {
                _Sucursal = value;
            }
        }
        public System.String PuntoVta
        {
            get
            {
                return ajustarAncho(_PuntoVta, 100);
            }
            set
            {
                _PuntoVta = value;
            }
        }
        public System.String TipoMov
        {
            get
            {
                return ajustarAncho(_TipoMov, 5);
            }
            set
            {
                _TipoMov = value;
            }
        }
        public System.DateTime FechaMov
        {
            get
            {
                return _FechaMov;
            }
            set
            {
                _FechaMov = value;
            }
        }
        public System.String Responsable
        {
            get
            {
                return ajustarAncho(_Responsable, 80);
            }
            set
            {
                _Responsable = value;
            }
        }
        public System.String Descripción
        {
            get
            {
                return ajustarAncho(_Descripción, 150);
            }
            set
            {
                _Descripción = value;
            }
        }
        public System.Decimal Valor
        {
            get
            {
                return _Valor;
            }
            set
            {
                _Valor = value;
            }
        }
        // La cadena de conexión a la base de datos
        private static string cadenaConexion = @"Data Source=daxserver; Initial Catalog=BdAdcomDx14Ecuaviche; user id=sa; password=1234qwerASDFZXCV";
        // La cadena de selección
        public static string CadenaSelect = "";
        //
        public DaxAdcPto()
        {
        }
        public DaxAdcPto(string conex)
        {
            cadenaConexion = conex;
        }
        private static DaxAdcPto row2DaxAdcPto(DataRow r)
        {
            // asigna a un objeto DaxAdcPto los datos del dataRow indicado
            DaxAdcPto oDaxAdcPto = new DaxAdcPto();
            //
            oDaxAdcPto.idclave = System.Decimal.Parse("0" + r["idclave"].ToString());
            oDaxAdcPto.Sucursal = r["Sucursal"].ToString();
            oDaxAdcPto.PuntoVta = r["PuntoVta"].ToString();
            oDaxAdcPto.TipoMov = r["TipoMov"].ToString();
            try
            {
                oDaxAdcPto.FechaMov = DateTime.Parse(r["FechaMov"].ToString());
            }
            catch
            {
                oDaxAdcPto.FechaMov = DateTime.Now;
            }
            oDaxAdcPto.Responsable = r["Responsable"].ToString();
            oDaxAdcPto.Descripción = r["Descripción"].ToString();
            oDaxAdcPto.Valor = System.Decimal.Parse("0" + r["Valor"].ToString());
            //
            return oDaxAdcPto;
        }
        private static void DaxAdcPto2Row(DaxAdcPto oDaxAdcPto, DataRow r)
        {
            // asigna un objeto DaxAdcPto al dataRow indicado
            //r["idclave"] = oDaxAdcPto.idclave;
            r["Sucursal"] = oDaxAdcPto.Sucursal;
            r["PuntoVta"] = oDaxAdcPto.PuntoVta;
            r["TipoMov"] = oDaxAdcPto.TipoMov;
            r["FechaMov"] = oDaxAdcPto.FechaMov;
            r["Responsable"] = oDaxAdcPto.Responsable;
            r["Descripción"] = oDaxAdcPto.Descripción;
            r["Valor"] = oDaxAdcPto.Valor;
        }
        //
        // crea una nueva fila y la asigna a un objeto DaxAdcPto
        private static void nuevoDaxAdcPto(DataTable dt, DaxAdcPto oDaxAdcPto)
        {
            // Crear un nuevo DaxAdcPto
            DataRow dr = dt.NewRow();
            DaxAdcPto oD = row2DaxAdcPto(dr);
            //
            oD.idclave = oDaxAdcPto.idclave;
            oD.Sucursal = oDaxAdcPto.Sucursal;
            oD.PuntoVta = oDaxAdcPto.PuntoVta;
            oD.TipoMov = oDaxAdcPto.TipoMov;
            oD.FechaMov = oDaxAdcPto.FechaMov;
            oD.Responsable = oDaxAdcPto.Responsable;
            oD.Descripción = oDaxAdcPto.Descripción;
            oD.Valor = oDaxAdcPto.Valor;
            //
            DaxAdcPto2Row(oD, dr);
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
            // devuelve una tabla con los datos de la tabla DaxAdcPto
            SqlDataAdapter da;
            DataTable dt = new DataTable("DaxAdcPto");
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
        public static DaxAdcPto Buscar(string sWhere)
        {
            // Busca en la tabla los datos indicados en el parámetro
            // el parámetro contendrá lo que se usará después del WHERE
            DaxAdcPto oDaxAdcPto = null;
            SqlDataAdapter da;
            DataTable dt = new DataTable("DaxAdcPto");
            string sel = "SELECT * FROM DaxAdcPto WHERE " + sWhere;
            //
            da = new SqlDataAdapter(sel, cadenaConexion);
            da.Fill(dt);
            //
            if (dt.Rows.Count > 0)
            {
                oDaxAdcPto = row2DaxAdcPto(dt.Rows[0]);
            }
            return oDaxAdcPto;
        }
        //
        // Actualizar: Actualiza los datos en la tabla usando la instancia actual
        //             Si la instancia no hace referencia a un registro existente, se creará uno nuevo
        //             Para comprobar si el objeto en memoria coincide con uno existente,
        //             se comprueba si el idclave existe en la tabla.
        public string Actualizar()
        {
            // TODO: Poner aquí la selección a realizar para acceder a este registro
            //       yo uso el idclave que es el identificador único de cada registro
            string sel = "SELECT * FROM DaxAdcPto WHERE idclave = " + this.idclave.ToString();
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
            DataTable dt = new DataTable("DaxAdcPto");
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
                DaxAdcPto2Row(this, dt.Rows[0]);
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
            DataTable dt = new DataTable("DaxAdcPto");
            //
            cnn = new SqlConnection(cadenaConexion);
            da = new SqlDataAdapter("select * from DaxAdcPto where idclave = 0", cnn);
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
            nuevoDaxAdcPto(dt, this);
            //
            try
            {
                da.Update(dt);
                dt.AcceptChanges();
                return "Se ha creado un nuevo DaxAdcPto";
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
        }
        //
        public string Borrar()
        {
            // TODO: Poner aquí la selección a realizar para acceder a este registro
            //       yo uso el idclave que es el identificador único de cada registro
            string sel = "SELECT * FROM DaxAdcPto WHERE idclave = " + this.idclave.ToString();
            //
            return Borrar(sel);
        }
        public string Borrar(string sel)
        {
            // Borrar el registro al que apunta esta clase
            // En caso de error, devolverá la cadena de error empezando por ERROR:.
            SqlConnection cnn;
            SqlDataAdapter da;
            DataTable dt = new DataTable("DaxAdcPto");
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
    }


}
