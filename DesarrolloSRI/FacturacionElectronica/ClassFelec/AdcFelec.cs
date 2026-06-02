using System;
using System.Data;
using System.Data.SqlClient;
//
namespace DaxDocElectronicos
{
    public class AdcFelec
    {
        private System.Boolean _ambienteEnProduccion;
        private System.String _pathFirmaElectronica;
        private System.String _pathCpbGenerados;
        private System.String _pathCpbFirmados;
        private System.String _pathCpbAutorizados;
        private System.String _pathpbNoAutorizados;
        private System.String _claveFirma;
        private System.String _correoDefecto;
        private System.String _consumidorFinal;
        private System.String _utilizarCtaCorreo;
        private string ajustarAncho(string cadena, int ancho)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder(new String(' ', ancho));
            return (cadena + sb.ToString()).Substring(0, ancho).Trim();
        }
        public System.Boolean ambienteEnProduccion
        {
            get
            {
                return _ambienteEnProduccion;
            }
            set
            {
                _ambienteEnProduccion = value;
            }
        }

        public System.String pathFirmaElectronica
        {
            get
            {
                return ajustarAncho(_pathFirmaElectronica,350);
            }
            set
            {
                _pathFirmaElectronica = value;
            }
        }
        public System.String claveFirma
        {
            get
            {
                return ajustarAncho(_claveFirma, 256);
            }
            set
            {
                _claveFirma = value;
            }
        }

        public System.String correoDefecto
        {
            get
            {
                return ajustarAncho(_correoDefecto, 256);
            }
            set
            {
                _correoDefecto = value;
            }
        }
        public System.String consumidorFinal
        {
            get
            {
                return ajustarAncho(_consumidorFinal, 20);
            }
            set
            {
                _consumidorFinal = value;
            }
        }
        public System.String utilizarCtaCorreo
        {
            get
            {
                return ajustarAncho(_utilizarCtaCorreo , 2);
            }
            set
            {
                _utilizarCtaCorreo = value;
            }
        }
        public System.String pathCpbGenerados
        {
            get
            {
                return ajustarAncho(_pathCpbGenerados,350);
            }
            set
            {
                _pathCpbGenerados = value;
            }
        }
        public System.String pathCpbFirmados
        {
            get
            {
                return ajustarAncho(_pathCpbFirmados, 350);
            }
            set
            {
                _pathCpbFirmados = value;
            }
        }
        public System.String pathCpbAutorizados
        {
            get
            {
                return ajustarAncho(_pathCpbAutorizados, 350);
            }
            set
            {
                _pathCpbAutorizados = value;
            }
        }
        public System.String pathpbNoAutorizados
        {
            get
            {
                return ajustarAncho(_pathpbNoAutorizados,350);
            }
            set
            {
                _pathpbNoAutorizados = value;
            }
        }
        //
        private static string cadenaConexion = "";
        // La cadena de selección
        public static string CadenaSelect = "SELECT * FROM AdcFelec";
        //
        public AdcFelec()
        {
        }
        public AdcFelec(string conex)
        {
            cadenaConexion = conex;
        }
        //
        private static AdcFelec row2AdcFelec(DataRow r)
        {
            // asigna a un objeto AdcFelec los datos del dataRow indicado
            AdcFelec oAdcFelec = new AdcFelec();
            //
            try
            {
                oAdcFelec.ambienteEnProduccion = System.Boolean.Parse(r["ambienteEnProduccion"].ToString());
            }
            catch
            {
                oAdcFelec.ambienteEnProduccion = false;
            }
            oAdcFelec.pathFirmaElectronica = r["pathFirmaElectronica"].ToString();
            oAdcFelec.pathCpbGenerados = r["pathCpbGenerados"].ToString();
            oAdcFelec.pathCpbFirmados = r["pathCpbFirmados"].ToString();
            oAdcFelec.pathCpbAutorizados = r["pathCpbAutorizados"].ToString();
            oAdcFelec.pathpbNoAutorizados = r["pathpbNoAutorizados"].ToString();
            oAdcFelec.claveFirma = r["claveFirma"].ToString();
            oAdcFelec.correoDefecto = r["correoDefecto"].ToString();
            oAdcFelec.consumidorFinal = r["consumidorFinal"].ToString();
            oAdcFelec.utilizarCtaCorreo = r["utilizarCtaCorreo"].ToString();
            
            //
            return oAdcFelec;
        }
        //
        // asigna un objeto AdcFelec a la fila indicada
        private static void AdcFelec2Row(AdcFelec oAdcFelec, DataRow r)
        {
            // asigna un objeto AdcFelec al dataRow indicado
            r["ambienteEnProduccion"] = oAdcFelec.ambienteEnProduccion;
            r["pathFirmaElectronica"] = oAdcFelec.pathFirmaElectronica;
            r["pathCpbGenerados"] = oAdcFelec.pathCpbGenerados;
            r["pathCpbFirmados"] = oAdcFelec.pathCpbFirmados;
            r["pathCpbAutorizados"] = oAdcFelec.pathCpbAutorizados;
            r["pathpbNoAutorizados"] = oAdcFelec.pathpbNoAutorizados;
            r["claveFirma"] = oAdcFelec._claveFirma ;
            r["correoDefecto"] = oAdcFelec._correoDefecto;
            r["consumidorFinal"] = oAdcFelec._consumidorFinal;
            r["utilizarCtaCorreo"] = oAdcFelec._utilizarCtaCorreo;
            
        }
        //
        private static void nuevoAdcFelec(DataTable dt, AdcFelec oAdcFelec)
        {
            DataRow dr = dt.NewRow();
            AdcFelec oA = row2AdcFelec(dr);
            //
            oA.ambienteEnProduccion = oAdcFelec.ambienteEnProduccion;
            oA.pathFirmaElectronica = oAdcFelec.pathFirmaElectronica;
            oA.pathCpbGenerados = oAdcFelec.pathCpbGenerados;
            oA.pathCpbFirmados = oAdcFelec.pathCpbFirmados;
            oA.pathCpbAutorizados = oAdcFelec.pathCpbAutorizados;
            oA.pathpbNoAutorizados = oAdcFelec.pathpbNoAutorizados;
            oA.claveFirma = oAdcFelec.claveFirma;
            oA.correoDefecto = oAdcFelec.correoDefecto;
            oA.consumidorFinal = oAdcFelec.consumidorFinal;
            oA.utilizarCtaCorreo = oAdcFelec.utilizarCtaCorreo;

            //
            AdcFelec2Row(oA, dr);
            //
            dt.Rows.Add(dr);
        }
        public static DataTable Tabla()
        {
            return Tabla(CadenaSelect);
        }
        public static DataTable Tabla(string sel)
        {
            SqlDataAdapter da;
            DataTable dt = new DataTable("AdcFelec");
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
        public static AdcFelec Buscar(string sWhere)
        {
            AdcFelec oAdcFelec = null;
            SqlDataAdapter da;
            DataTable dt = new DataTable("AdcFelec");
            string sel = "SELECT * FROM AdcFelec  ";
            //
            da = new SqlDataAdapter(sel, cadenaConexion);
            da.Fill(dt);
            //
            if (dt.Rows.Count > 0)
            {
                oAdcFelec = row2AdcFelec(dt.Rows[0]);
            }
            return oAdcFelec;
        }
        public string Actualizar()
        {
            string sel = "SELECT * FROM AdcFelec " ;
            return Actualizar(sel);
        }
        public string Actualizar(string sel)
        {
            SqlConnection cnn;
            SqlDataAdapter da;
            DataTable dt = new DataTable("AdcFelec");
            //
            cnn = new SqlConnection(cadenaConexion);
            da = new SqlDataAdapter(sel, cnn);
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            string sCommand = "UPDATE AdcFelec SET ambienteEnProduccion = @ambienteEnProduccion, pathFirmaElectronica = @pathFirmaElectronica";              
            sCommand += ", pathCpbGenerados = @pathCpbGenerados, pathCpbFirmados = @pathCpbFirmados, pathCpbAutorizados = @pathCpbAutorizados";
            sCommand += ", pathpbNoAutorizados = @pathpbNoAutorizados, claveFirma = @claveFirma, correoDefecto = @correoDefecto,consumidorFinal = @consumidorFinal,utilizarCtaCorreo = @utilizarCtaCorreo";
            da.UpdateCommand = new SqlCommand(sCommand, cnn);
            da.UpdateCommand.Parameters.Add("@ambienteEnProduccion", SqlDbType.Bit, 0, "ambienteEnProduccion");
            da.UpdateCommand.Parameters.Add("@pathFirmaElectronica", SqlDbType.NText, 350, "pathFirmaElectronica");
            da.UpdateCommand.Parameters.Add("@pathCpbGenerados", SqlDbType.NText, 350, "pathCpbGenerados");
            da.UpdateCommand.Parameters.Add("@pathCpbFirmados", SqlDbType.NText, 350, "pathCpbFirmados");
            da.UpdateCommand.Parameters.Add("@pathCpbAutorizados", SqlDbType.NText, 350, "pathCpbAutorizados");
            da.UpdateCommand.Parameters.Add("@pathpbNoAutorizados", SqlDbType.NText, 350, "pathpbNoAutorizados");
            da.UpdateCommand.Parameters.Add("@claveFirma", SqlDbType.NText, 256, "claveFirma");
            da.UpdateCommand.Parameters.Add("@correoDefecto", SqlDbType.NText, 256, "correoDefecto");
            da.UpdateCommand.Parameters.Add("@consumidorFinal", SqlDbType.NText, 20, "consumidorFinal");
            da.UpdateCommand.Parameters.Add("@utilizarCtaCorreo", SqlDbType.NText, 2, "utilizarCtaCorreo");            
            //
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
                AdcFelec2Row(this, dt.Rows[0]);
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
            DataTable dt = new DataTable("AdcFelec");
            //
            cnn = new SqlConnection(cadenaConexion);
            da = new SqlDataAdapter(CadenaSelect, cnn);
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            string sCommand;
            sCommand = "INSERT INTO AdcFelec (ambienteEnProduccion, pathFirmaElectronica, pathCpbGenerados, pathCpbFirmados, pathCpbAutorizados, pathpbNoAutorizados,claveFirma,correoDefecto,consumidorFinal, utilizarCtaCorreo)  VALUES(@ambienteEnProduccion, @pathFirmaElectronica, @pathCpbGenerados, @pathCpbFirmados, @pathCpbAutorizados, @pathpbNoAutorizados,@claveFirma,@correoDefecto,@consumidorFinal,@utilizarCtaCorreo)";
            da.InsertCommand = new SqlCommand(sCommand, cnn);
            da.InsertCommand.Parameters.Add("@ambienteEnProduccion", SqlDbType.Bit, 0, "ambienteEnProduccion");
            da.InsertCommand.Parameters.Add("@pathFirmaElectronica", SqlDbType.NText, 350, "pathFirmaElectronica");
            da.InsertCommand.Parameters.Add("@pathCpbGenerados", SqlDbType.NText, 350, "pathCpbGenerados");
            da.InsertCommand.Parameters.Add("@pathCpbFirmados", SqlDbType.NText, 350, "pathCpbFirmados");
            da.InsertCommand.Parameters.Add("@pathCpbAutorizados", SqlDbType.NText, 350, "pathCpbAutorizados");
            da.InsertCommand.Parameters.Add("@pathpbNoAutorizados", SqlDbType.NText, 350, "pathpbNoAutorizados");
            da.InsertCommand.Parameters.Add("@claveFirma", SqlDbType.NText, 350, "claveFirma");
            da.InsertCommand.Parameters.Add("@correoDefecto", SqlDbType.NText, 350, "correoDefecto");
            da.InsertCommand.Parameters.Add("@consumidorFinal", SqlDbType.NText, 20, "consumidorFinal");
            da.InsertCommand.Parameters.Add("@utilizarCtaCorreo", SqlDbType.NText, 2, "utilizarCtaCorreo");            
            try
            {
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
            //
            nuevoAdcFelec(dt, this);
            //
            try
            {
                da.Update(dt);
                dt.AcceptChanges();
                return "Se ha creado un nuevo AdcFelec";
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
        }
        //
        public string Borrar()
        {
            string sel = "SELECT * FROM AdcFelec ";
            //
            return Borrar(sel);
        }
        public string Borrar(string sel)
        {
            SqlConnection cnn;
            SqlDataAdapter da;
            DataTable dt = new DataTable("AdcFelec");
            //
            cnn = new SqlConnection(cadenaConexion);
            da = new SqlDataAdapter(sel, cnn);
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            string sCommand;
            sCommand = "DELETE FROM AdcFelec ";
            da.DeleteCommand = new SqlCommand(sCommand, cnn);
            da.DeleteCommand.Parameters.Add("@p2", SqlDbType.Int, 0, "");
            //
            //
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