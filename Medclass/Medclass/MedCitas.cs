using System;
using System.Data;
using System.Data.SqlClient;

namespace DaxMedic
{
    //------------------------------------------------------------------------------
    public class AdcCit
    {
        // Las variables privadas
        // TODO: Revisar los tipos de los campos
        private System.String _codEsp = "";
        private System.String _CodMed = "";
        private System.String _CodPaciente = "";
        private System.String _CodConcepto = "";
        private System.String _Detalle = "";
        private System.String _HClinica = "";
        private System.Decimal _NroTurno = 0;
        private System.DateTime _Fecha = new DateTime(1900, 1, 1);
        private System.String _Hora = "";
        private System.String _Estado = "";
        private System.String _Ubicacion = "";
        private System.Decimal _Valor = 0;
        private System.Decimal _IdClave;
        private System.Int32 _Secuencial = 0;
        private System.Boolean _SignVit = false;
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
        public System.String codEsp
        {
            get
            {
                return ajustarAncho(_codEsp, 10);
            }
            set
            {
                _codEsp = value;
            }
        }
        public System.String CodMed
        {
            get
            {
                return ajustarAncho(_CodMed, 13);
            }
            set
            {
                _CodMed = value;
            }
        }
        public System.String CodPaciente
        {
            get
            {
                return ajustarAncho(_CodPaciente, 13);
            }
            set
            {
                _CodPaciente = value;
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
        public System.String Detalle
        {
            get
            {
                // Seguramente sería mejor sin ajustar el ancho...
                //return ajustarAncho(_Detalle,256);
                return _Detalle;
            }
            set
            {
                _Detalle = value;
            }
        }
        public System.String HClinica
        {
            get
            {
                return ajustarAncho(_HClinica, 50);
            }
            set
            {
                _HClinica = value;
            }
        }
        public System.Decimal NroTurno
        {
            get
            {
                return _NroTurno;
            }
            set
            {
                _NroTurno = value;
            }
        }
        public System.DateTime Fecha
        {
            get
            {
                return _Fecha;
            }
            set
            {
                _Fecha = value;
            }
        }
        public System.String Hora
        {
            get
            {
                return ajustarAncho(_Hora, 10);
            }
            set
            {
                _Hora = value;
            }
        }
        public System.String Estado
        {
            get
            {
                return ajustarAncho(_Estado, 20);
            }
            set
            {
                _Estado = value;
            }
        }
        public System.String Ubicacion
        {
            get
            {
                return ajustarAncho(_Ubicacion, 20);
            }
            set
            {
                _Ubicacion = value;
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
        public System.Decimal IdClave
        {
            get
            {
                return _IdClave;
            }
            set
            {
                _IdClave = value;
            }
        }
        public System.Int32 Secuencial
        {
            get
            {
                return _Secuencial;
            }
            set
            {
                _Secuencial = value;
            }
        }
        public System.Boolean SignVit
        {
            get
            {
                return _SignVit;
            }
            set
            {
                _SignVit = value;
            }
        }

        //
        //
        // Campos y métodos compartidos (estáticos) para gestionar la base de datos
        //
        // La cadena de conexión a la base de datos
        private static string cadenaConexion = @"";
        // La cadena de selección
        public static string CadenaSelect = "";
        //
        public AdcCit()
        {
        }
        public AdcCit(string conex)
        {
            cadenaConexion = conex;
        }
        //
        // Métodos compartidos (estáticos) privados
        //
        // asigna una fila de la tabla a un objeto AdcCit
        private static AdcCit row2AdcCit(DataRow r)
        {
            // asigna a un objeto AdcCit los datos del dataRow indicado
            AdcCit oAdcCit = new AdcCit();
            //
            oAdcCit.codEsp = r["codEsp"].ToString();
            oAdcCit.CodMed = r["CodMed"].ToString();
            oAdcCit.CodPaciente = r["CodPaciente"].ToString();
            oAdcCit.CodConcepto = r["CodConcepto"].ToString();
            oAdcCit.Detalle = r["Detalle"].ToString();
            oAdcCit.HClinica = r["HClinica"].ToString();
            oAdcCit.NroTurno = System.Decimal.Parse("0" + r["NroTurno"].ToString());
            try
            {
                oAdcCit.Fecha = DateTime.Parse(r["Fecha"].ToString());
            }
            catch
            {
                // TODO: Usa el valor de fecha qu
                oAdcCit.Fecha = DateTime.Now;
            }
            oAdcCit.Hora = r["Hora"].ToString();
            oAdcCit.Estado = r["Estado"].ToString();
            oAdcCit.Ubicacion = r["Ubicacion"].ToString();
            oAdcCit.Valor = System.Decimal.Parse("0" + r["Valor"].ToString());
            oAdcCit.IdClave = System.Decimal.Parse("0" + r["IdClave"].ToString());
            oAdcCit.Secuencial = System.Int32.Parse("0" + r["Secuencial"].ToString());
            try
            {
                oAdcCit.SignVit = Convert.ToBoolean(r["SignVit"]);
            }
            catch { oAdcCit.SignVit = false; }

            //
            return oAdcCit;
        }
        //
        // asigna un objeto AdcCit a la fila indicada
        private static void AdcCit2Row(AdcCit oAdcCit, DataRow r)
        {
            // asigna un objeto AdcCit al dataRow indicado
            r["codEsp"] = oAdcCit.codEsp;
            r["CodMed"] = oAdcCit.CodMed;
            r["CodPaciente"] = oAdcCit.CodPaciente;
            r["CodConcepto"] = oAdcCit.CodConcepto;
            r["Detalle"] = oAdcCit.Detalle;
            r["HClinica"] = oAdcCit.HClinica;
            r["NroTurno"] = oAdcCit.NroTurno;
            r["Fecha"] = oAdcCit.Fecha;
            r["Hora"] = oAdcCit.Hora;
            r["Estado"] = oAdcCit.Estado;
            r["Ubicacion"] = oAdcCit.Ubicacion;
            r["Valor"] = oAdcCit.Valor;
            //r["IdClave"] = oAdcCit.IdClave;
            r["Secuencial"] = oAdcCit.Secuencial;
            if (oAdcCit.SignVit) { r["SignVit"] = 1;} else { r["SignVit"] = 0;}
        }
        //
        // crea una nueva fila y la asigna a un objeto AdcCit
        private static void nuevoAdcCit(DataTable dt, AdcCit oAdcCit)
        {
            // Crear un nuevo AdcCit
            DataRow dr = dt.NewRow();
            AdcCit oA = row2AdcCit(dr);
            //
            oA.codEsp = oAdcCit.codEsp;
            oA.CodMed = oAdcCit.CodMed;
            oA.CodPaciente = oAdcCit.CodPaciente;
            oA.CodConcepto = oAdcCit.CodConcepto;
            oA.Detalle = oAdcCit.Detalle;
            oA.HClinica = oAdcCit.HClinica;
            oA.NroTurno = oAdcCit.NroTurno;
            oA.Fecha = oAdcCit.Fecha;
            oA.Hora = oAdcCit.Hora;
            oA.Estado = oAdcCit.Estado;
            oA.Ubicacion = oAdcCit.Ubicacion;
            oA.Valor = oAdcCit.Valor;
            oA.IdClave = oAdcCit.IdClave;
            oA.Secuencial = oAdcCit.Secuencial;
            oA.SignVit = oAdcCit.SignVit;
            //
            AdcCit2Row(oA, dr);
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
            // devuelve una tabla con los datos de la tabla AdcCit
            SqlDataAdapter da;
            DataTable dt = new DataTable("AdcCit");
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
        public static AdcCit Buscar(string sWhere)
        {
            // Busca en la tabla los datos indicados en el parámetro
            // el parámetro contendrá lo que se usará después del WHERE
            AdcCit oAdcCit = null;
            SqlDataAdapter da;
            DataTable dt = new DataTable("AdcCit");
            string sel = "SELECT * FROM MedCitas WHERE " + sWhere;
            //
            da = new SqlDataAdapter(sel, cadenaConexion);
            da.Fill(dt);
            //
            if (dt.Rows.Count > 0)
            {
                oAdcCit = row2AdcCit(dt.Rows[0]);
            }
            return oAdcCit;
        }
        public string Actualizar()
        {
            string sel = "SELECT * FROM MedCitas WHERE IdClave = " + this.IdClave.ToString();
            return Actualizar(sel);
        }
        public string Actualizar(string sel)
        {
            // Actualiza los datos indicados
            // El parámetro, que es una cadena de selección, indicará el criterio de actualización
            //
            // En caso de error, devolverá la cadena empezando por ERROR.
            SqlDataAdapter da;
            DataTable dt = new DataTable("AdcCit");
            CadenaSelect = sel;

            //cnn = new SqlConnection();
            da = new SqlDataAdapter(sel, cadenaConexion);
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
                CadenaSelect = sel;
                return Crear();
            }
            else
            {
                AdcCit2Row(this, dt.Rows[0]);
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
            //SqlConnection cnn;
            SqlDataAdapter da;
            DataTable dt = new DataTable("AdcCit");
            //
            da = new SqlDataAdapter(CadenaSelect, cadenaConexion);
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
            nuevoAdcCit(dt, this);
            //
            try
            {
                da.Update(dt);
                dt.AcceptChanges();
                return "Se ha creado un nuevo AdcCit";
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
        }
        //
        public string Borrar()
        {
            string sel = "SELECT * FROM MedCitas WHERE IdClave = " + this.IdClave.ToString();
            //
            return Borrar(sel);
        }
        public string Borrar(string sel)
        {
            //SqlConnection cnn;
            SqlDataAdapter da;
            DataTable dt = new DataTable("AdcCit");
            //
            //cnn = new SqlConnection(cadenaConexion);
            da = new SqlDataAdapter(sel, cadenaConexion);
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
    //}
}