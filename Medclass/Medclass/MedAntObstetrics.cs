using System;
using System.Data;
using System.Data.SqlClient;

namespace DaxMedic
{
    public class MedAntObst
    {
        private System.String _HistClinica="";
        private System.DateTime _FechaProbParto=new DateTime(1900,1,1);
        private System.Int32 _Gestaciones=0;
        private System.Int32 _Abortos=0;
        private System.Int32 _Partos=0;
        private System.Int32 _Cesareas=0;
        private System.Int32 _NacidosVivos=0;
        private System.Int32 _NacidosMuertos=0;
        private System.Int32 _VIvenActual=0;
        private System.Int32 _Muertos1eraSemana=0;
        private System.Int32 _MuertosMas1Semana=0;
        private System.Boolean _Intergenencia=false;
        private System.Boolean _PartoPrematuro=false;
        private System.Boolean _Malformaciones=false;
        private System.Boolean _Isoinmunizacion=false;
        private System.Boolean _AtencionPrenatal=false;
        private System.Int32  _NroConsultas=0;
        private System.String _MedicacionGestacional="";
        private System.String _ExamenesComplementarios="";
        private System.String _ObstetricosObs="";
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
        public System.String HistClinica
        {
            get
            {
                return ajustarAncho(_HistClinica, 20);
            }
            set
            {
                _HistClinica = value;
            }
        }
        public System.DateTime FechaProbParto
        {
            get
            {
                return _FechaProbParto;
            }
            set
            {
                _FechaProbParto = value;
            }
        }
        public System.Int32 Gestaciones
        {
            get
            {
                return _Gestaciones;
            }
            set
            {
                _Gestaciones = value;
            }
        }
        public System.Int32 Abortos
        {
            get
            {
                return _Abortos;
            }
            set
            {
                _Abortos = value;
            }
        }
        public System.Int32 Partos
        {
            get
            {
                return _Partos;
            }
            set
            {
                _Partos = value;
            }
        }
        public System.Int32 Cesareas
        {
            get
            {
                return _Cesareas;
            }
            set
            {
                _Cesareas = value;
            }
        }
        public System.Int32 NacidosVivos
        {
            get
            {
                return _NacidosVivos;
            }
            set
            {
                _NacidosVivos = value;
            }
        }
        public System.Int32 NacidosMuertos
        {
            get
            {
                return _NacidosMuertos;
            }
            set
            {
                _NacidosMuertos = value;
            }
        }
        public System.Int32 VIvenActual
        {
            get
            {
                return _VIvenActual;
            }
            set
            {
                _VIvenActual = value;
            }
        }
        public System.Int32 Muertos1eraSemana
        {
            get
            {
                return _Muertos1eraSemana;
            }
            set
            {
                _Muertos1eraSemana = value;
            }
        }
        public System.Int32 MuertosMas1Semana
        {
            get
            {
                return _MuertosMas1Semana;
            }
            set
            {
                _MuertosMas1Semana = value;
            }
        }
        public System.Boolean Intergenencia
        {
            get
            {
                return _Intergenencia;
            }
            set
            {
                _Intergenencia = value;
            }
        }
        public System.Boolean PartoPrematuro
        {
            get
            {
                return _PartoPrematuro;
            }
            set
            {
                _PartoPrematuro = value;
            }
        }
        public System.Boolean Malformaciones
        {
            get
            {
                return _Malformaciones;
            }
            set
            {
                _Malformaciones = value;
            }
        }
        public System.Boolean Isoinmunizacion
        {
            get
            {
                return _Isoinmunizacion;
            }
            set
            {
                _Isoinmunizacion = value;
            }
        }
        public System.Boolean AtencionPrenatal
        {
            get
            {
                return _AtencionPrenatal;
            }
            set
            {
                _AtencionPrenatal = value;
            }
        }
        public System.Int32 NroConsultas
        {
            get
            {
                return _NroConsultas;
            }
            set
            {
                _NroConsultas = value;
            }
        }
        public System.String MedicacionGestacional
        {
            get
            {
                // Seguramente sería mejor sin ajustar el ancho...
                //return ajustarAncho(_MedicacionGestacional,350);
                return _MedicacionGestacional;
            }
            set
            {
                _MedicacionGestacional = value;
            }
        }
        public System.String ExamenesComplementarios
        {
            get
            {
                // Seguramente sería mejor sin ajustar el ancho...
                //return ajustarAncho(_ExamenesComplementarios,2147483647);
                return _ExamenesComplementarios;
            }
            set
            {
                _ExamenesComplementarios = value;
            }
        }
        public System.String ObstetricosObs
        {
            get
            {
                // Seguramente sería mejor sin ajustar el ancho...
                //return ajustarAncho(_ObstetricosObs,2147483647);
                return _ObstetricosObs;
            }
            set
            {
                _ObstetricosObs = value;
            }
        }
        //
        //
        // Campos y métodos compartidos (estáticos) para gestionar la base de datos
        //
        // La cadena de conexión a la base de datos
        private static string cadenaConexion = @"Data Source=daxserver; Initial Catalog=BdAdcomDx14CLeones; user id=sa; password=1234qwerASDFZXCV";
        // La cadena de selección
        public static string CadenaSelect = "SELECT * FROM MedAntObst";
        //
        public MedAntObst()
        {
        }
        public MedAntObst(string conex)
        {
            cadenaConexion = conex;
        }
        //
        // Métodos compartidos (estáticos) privados
        //
        // asigna una fila de la tabla a un objeto MedAntObst
        private static MedAntObst row2MedAntObst(DataRow r)
        {
            // asigna a un objeto MedAntObst los datos del dataRow indicado
            MedAntObst oMedAntObst = new MedAntObst();
            //
            oMedAntObst.HistClinica = r["HistClinica"].ToString();
            try
            {
                oMedAntObst.FechaProbParto = DateTime.Parse(r["FechaProbParto"].ToString());
            }
            catch
            {
                // TODO: Usa el valor de fecha que quieras predeterminar
                //       Una fecha ficticia:
                //oMedAntObst.FechaProbParto = new DateTime(1900, 1, 1);
                //       o la fecha de hoy:
                oMedAntObst.FechaProbParto = DateTime.Now;
            }
            oMedAntObst.Gestaciones = System.Int32.Parse("0" + r["Gestaciones"].ToString());
            oMedAntObst.Abortos = System.Int32.Parse("0" + r["Abortos"].ToString());
            oMedAntObst.Partos = System.Int32.Parse("0" + r["Partos"].ToString());
            oMedAntObst.Cesareas = System.Int32.Parse("0" + r["Cesareas"].ToString());
            oMedAntObst.NacidosVivos = System.Int32.Parse("0" + r["NacidosVivos"].ToString());
            oMedAntObst.NacidosMuertos = System.Int32.Parse("0" + r["NacidosMuertos"].ToString());
            oMedAntObst.VIvenActual = System.Int32.Parse("0" + r["VIvenActual"].ToString());
            oMedAntObst.Muertos1eraSemana = System.Int32.Parse("0" + r["Muertos1eraSemana"].ToString());
            oMedAntObst.MuertosMas1Semana = System.Int32.Parse("0" + r["MuertosMas1Semana"].ToString());
            try
            {
                oMedAntObst.Intergenencia = System.Boolean.Parse(r["Intergenencia"].ToString());
            }
            catch
            {
                oMedAntObst.Intergenencia = false;
            }
            try
            {
                oMedAntObst.PartoPrematuro = System.Boolean.Parse(r["PartoPrematuro"].ToString());
            }
            catch
            {
                oMedAntObst.PartoPrematuro = false;
            }
            try
            {
                oMedAntObst.Malformaciones = System.Boolean.Parse(r["Malformaciones"].ToString());
            }
            catch
            {
                oMedAntObst.Malformaciones = false;
            }
            try
            {
                oMedAntObst.Isoinmunizacion = System.Boolean.Parse(r["Isoinmunizacion"].ToString());
            }
            catch
            {
                oMedAntObst.Isoinmunizacion = false;
            }
            try
            {
                oMedAntObst.AtencionPrenatal = System.Boolean.Parse(r["AtencionPrenatal"].ToString());
            }
            catch
            {
                oMedAntObst.AtencionPrenatal = false;
            }
            try
            {
                oMedAntObst.NroConsultas = System.Int32.Parse("0" + r["NroConsultas"].ToString());
            }
            catch { }
            oMedAntObst.MedicacionGestacional = r["MedicacionGestacional"].ToString();
            oMedAntObst.ExamenesComplementarios = r["ExamenesComplementarios"].ToString();
            oMedAntObst.ObstetricosObs = r["ObstetricosObs"].ToString();
            //
            return oMedAntObst;
        }
        //
        // asigna un objeto MedAntObst a la fila indicada
        private static void MedAntObst2Row(MedAntObst oMedAntObst, DataRow r)
        {
            // asigna un objeto MedAntObst al dataRow indicado
            r["HistClinica"] = oMedAntObst.HistClinica;
            r["FechaProbParto"] = oMedAntObst.FechaProbParto;
            r["Gestaciones"] = oMedAntObst.Gestaciones;
            r["Abortos"] = oMedAntObst.Abortos;
            r["Partos"] = oMedAntObst.Partos;
            r["Cesareas"] = oMedAntObst.Cesareas;
            r["NacidosVivos"] = oMedAntObst.NacidosVivos;
            r["NacidosMuertos"] = oMedAntObst.NacidosMuertos;
            r["VIvenActual"] = oMedAntObst.VIvenActual;
            r["Muertos1eraSemana"] = oMedAntObst.Muertos1eraSemana;
            r["MuertosMas1Semana"] = oMedAntObst.MuertosMas1Semana;
            r["Intergenencia"] = oMedAntObst.Intergenencia;
            r["PartoPrematuro"] = oMedAntObst.PartoPrematuro;
            r["Malformaciones"] = oMedAntObst.Malformaciones;
            r["Isoinmunizacion"] = oMedAntObst.Isoinmunizacion;
            r["AtencionPrenatal"] = oMedAntObst.AtencionPrenatal;
            r["NroConsultas"] = oMedAntObst.NroConsultas;
            r["MedicacionGestacional"] = oMedAntObst.MedicacionGestacional;
            r["ExamenesComplementarios"] = oMedAntObst.ExamenesComplementarios;
            r["ObstetricosObs"] = oMedAntObst.ObstetricosObs;
        }
        //
        // crea una nueva fila y la asigna a un objeto MedAntObst
        private static void nuevoMedAntObst(DataTable dt, MedAntObst oMedAntObst)
        {
            // Crear un nuevo MedAntObst
            DataRow dr = dt.NewRow();
            MedAntObst oD = row2MedAntObst(dr);
            //
            oD.HistClinica = oMedAntObst.HistClinica;
            oD.FechaProbParto = oMedAntObst.FechaProbParto;
            oD.Gestaciones = oMedAntObst.Gestaciones;
            oD.Abortos = oMedAntObst.Abortos;
            oD.Partos = oMedAntObst.Partos;
            oD.Cesareas = oMedAntObst.Cesareas;
            oD.NacidosVivos = oMedAntObst.NacidosVivos;
            oD.NacidosMuertos = oMedAntObst.NacidosMuertos;
            oD.VIvenActual = oMedAntObst.VIvenActual;
            oD.Muertos1eraSemana = oMedAntObst.Muertos1eraSemana;
            oD.MuertosMas1Semana = oMedAntObst.MuertosMas1Semana;
            oD.Intergenencia = oMedAntObst.Intergenencia;
            oD.PartoPrematuro = oMedAntObst.PartoPrematuro;
            oD.Malformaciones = oMedAntObst.Malformaciones;
            oD.Isoinmunizacion = oMedAntObst.Isoinmunizacion;
            oD.AtencionPrenatal = oMedAntObst.AtencionPrenatal;
            oD.NroConsultas = oMedAntObst.NroConsultas;
            oD.MedicacionGestacional = oMedAntObst.MedicacionGestacional;
            oD.ExamenesComplementarios = oMedAntObst.ExamenesComplementarios;
            oD.ObstetricosObs = oMedAntObst.ObstetricosObs;
            //
            MedAntObst2Row(oD, dr);
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
            // devuelve una tabla con los datos de la tabla MedAntObst
            SqlDataAdapter da;
            DataTable dt = new DataTable("MedAntObst");
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
        public static MedAntObst Buscar(string sWhere)
        {
            // Busca en la tabla los datos indicados en el parámetro
            // el parámetro contendrá lo que se usará después del WHERE
            MedAntObst oMedAntObst = null;
            SqlDataAdapter da;
            DataTable dt = new DataTable("MedAntObst");
            string sel = "SELECT * FROM MedAntObst WHERE " + sWhere;
            //
            da = new SqlDataAdapter(sel, cadenaConexion);
            da.Fill(dt);
            //
            if (dt.Rows.Count > 0)
            {
                oMedAntObst = row2MedAntObst(dt.Rows[0]);
            }
            return oMedAntObst;
        }
        //
        // Actualizar: Actualiza los datos en la tabla usando la instancia actual
        //             Si la instancia no hace referencia a un registro existente, se creará uno nuevo
        //             Para comprobar si el objeto en memoria coincide con uno existente,
        //             se comprueba si el ID existe en la tabla.
        //             TODO: Si en lugar de ID usas otro campo, indicalo en la cadena SELECT
        //                   También puedes usar la sobrecarga en la que se indica la cadena SELECT a usar
        public string Actualizar()
        {
            string sel = "SELECT * FROM MedAntObst WHERE HistClinica = '" + this.HistClinica + "'";
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
            DataTable dt = new DataTable("MedAntObst");
            CadenaSelect = sel;

            cnn = new SqlConnection(cadenaConexion);
            //da = new SqlDataAdapter(CadenaSelect, cnn);
            da = new SqlDataAdapter(sel, cnn);
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            //
            //-------------------------------------------
            // Esta no es la más óptima, pero funcionará
            //-------------------------------------------
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            da.UpdateCommand = cb.GetUpdateCommand();
            //
            //--------------------------------------------------------------------
            // Esta está más optimizada pero debes comprobar que funciona bien...
            //--------------------------------------------------------------------
            //string sCommand;
            ////
            //// El comando UPDATE
            //// TODO: Comprobar cual es el campo de índice principal (sin duplicados)
            ////       Yo compruebo que sea un campo llamado ID, pero en tu caso puede ser otro
            ////       Ese campo, (en mi caso ID) será el que hay que poner al final junto al WHERE.
            //sCommand = "UPDATE MedAntObst SET HistClinica = @HistClinica, FechaProbParto = @FechaProbParto, Gestaciones = @Gestaciones, Abortos = @Abortos, Partos = @Partos, Cesareas = @Cesareas, NacidosVivos = @NacidosVivos, NacidosMuertos = @NacidosMuertos, VIvenActual = @VIvenActual, Muertos1eraSemana = @Muertos1eraSemana, MuertosMas1Semana = @MuertosMas1Semana, Intergenencia = @Intergenencia, PartoPrematuro = @PartoPrematuro, Malformaciones = @Malformaciones, Isoinmunizacion = @Isoinmunizacion, AtencionPrenatal = @AtencionPrenatal, NroConsultas = @NroConsultas, thisdicacionGestacional = @MedicacionGestacional, ExamenesComplementarios = @ExamenesComplementarios, ObstetricosObs = @ObstetricosObs  WHERE (ID = @ID)";
            //da.UpdateCommand = new SqlCommand(sCommand, cnn);
            //da.UpdateCommand.Parameters.Add("@HistClinica", SqlDbType.NVarChar, 20, "HistClinica");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@FechaProbParto", SqlDbType.DateTime, 0, "FechaProbParto");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@Gestaciones", SqlDbType.Int, 0, "Gestaciones");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@Abortos", SqlDbType.Int, 0, "Abortos");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@Partos", SqlDbType.Int, 0, "Partos");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@Cesareas", SqlDbType.Int, 0, "Cesareas");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@NacidosVivos", SqlDbType.Int, 0, "NacidosVivos");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@NacidosMuertos", SqlDbType.Int, 0, "NacidosMuertos");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@VIvenActual", SqlDbType.Int, 0, "VIvenActual");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@Muertos1eraSemana", SqlDbType.Int, 0, "Muertos1eraSemana");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@MuertosMas1Semana", SqlDbType.Int, 0, "MuertosMas1Semana");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@Intergenencia", SqlDbType.Bit, 0, "Intergenencia");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@PartoPrematuro", SqlDbType.Bit, 0, "PartoPrematuro");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@Malformaciones", SqlDbType.Bit, 0, "Malformaciones");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@Isoinmunizacion", SqlDbType.Bit, 0, "Isoinmunizacion");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@AtencionPrenatal", SqlDbType.Bit, 0, "AtencionPrenatal");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@NroConsultas", SqlDbType.Bit, 0, "NroConsultas");
            //// TODO: Este campo seguramente es MEMO y el valor debería ser cero en lugar de 350
            ////da.UpdateCommand.Parameters.Add("@MedicacionGestacional", SqlDbType.NText, 350, "MedicacionGestacional");
            //da.UpdateCommand.Parameters.Add("@MedicacionGestacional", SqlDbType.NText, 0, "MedicacionGestacional");
            //// TODO: Este campo seguramente es MEMO y el valor debería ser cero en lugar de 2147483647
            ////da.UpdateCommand.Parameters.Add("@ExamenesComplementarios", SqlDbType.NText, 2147483647, "ExamenesComplementarios");
            //da.UpdateCommand.Parameters.Add("@ExamenesComplementarios", SqlDbType.NText, 0, "ExamenesComplementarios");
            //// TODO: Este campo seguramente es MEMO y el valor debería ser cero en lugar de 2147483647
            ////da.UpdateCommand.Parameters.Add("@ObstetricosObs", SqlDbType.NText, 2147483647, "ObstetricosObs");
            //da.UpdateCommand.Parameters.Add("@ObstetricosObs", SqlDbType.NText, 0, "ObstetricosObs");
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
                MedAntObst2Row(this, dt.Rows[0]);
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
            DataTable dt = new DataTable("MedAntObst");
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
            nuevoMedAntObst(dt, this);
            //
            try
            {
                da.Update(dt);
                dt.AcceptChanges();
                return "Se ha creado un nuevo MedAntObst";
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
            //       yo uso el ID que es el identificador único de cada registro
            string sel = "SELECT * FROM MedAntObst WHERE HistClinica = '" + this.HistClinica+"'";
            //
            return Borrar(sel);
        }
        public string Borrar(string sel)
        {
            // Borrar el registro al que apunta esta clase
            // En caso de error, devolverá la cadena de error empezando por ERROR:.
            SqlConnection cnn;
            SqlDataAdapter da;
            DataTable dt = new DataTable("MedAntObst");
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
