using System;
using System.Data;
using System.Data.SqlClient;

namespace DaxMedic
{
    public class MedAntGin
    {
        // Las variables privadas
        // TODO: Revisar los tipos de los campos
        private System.String _HistClinica="";
        private System.Int32 _Menarca=0;
        private System.Int32 _Menopausia=0;
        private System.DateTime _UltMenstruacion= new DateTime(1900,1,1);
        private System.DateTime _UltCitoligia= new DateTime(1900,1,1);
        private System.Int32 _InicioVidaSexual=0;
        private System.Int32 _NumeroParejas=0;
        private System.String _AlMensFrecuencia = "";
        private System.String _AlMensDuracion = "";
        private System.String _AlMensCantidad = "";
        private System.String _AnticoncepcionTipo = "";
        private System.DateTime _AnticoncepcionInicio=new DateTime(1900,1,1);
        private System.DateTime _AnticoncepcionSuspencion=new DateTime(1900,1,1);
        private System.String _GinecologicosObs = "";
        private System.String _EnfermedadesV = "";
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
        public System.Int32 Menarca
        {
            get
            {
                return _Menarca;
            }
            set
            {
                _Menarca = value;
            }
        }
        public System.Int32 Menopausia
        {
            get
            {
                return _Menopausia;
            }
            set
            {
                _Menopausia = value;
            }
        }
        public System.DateTime UltMenstruacion
        {
            get
            {
                return _UltMenstruacion;
            }
            set
            {
                _UltMenstruacion = value;
            }
        }
        public System.DateTime UltCitoligia
        {
            get
            {
                return _UltCitoligia;
            }
            set
            {
                _UltCitoligia = value;
            }
        }
        public System.Int32 InicioVidaSexual
        {
            get
            {
                return _InicioVidaSexual;
            }
            set
            {
                _InicioVidaSexual = value;
            }
        }
        public System.Int32 NumeroParejas
        {
            get
            {
                return _NumeroParejas;
            }
            set
            {
                _NumeroParejas = value;
            }
        }
        public System.String AlMensFrecuencia
        {
            get
            {
                return ajustarAncho(_AlMensFrecuencia, 30);
            }
            set
            {
                _AlMensFrecuencia = value;
            }
        }
        public System.String AlMensDuracion
        {
            get
            {
                return ajustarAncho(_AlMensDuracion, 30);
            }
            set
            {
                _AlMensDuracion = value;
            }
        }
        public System.String AlMensCantidad
        {
            get
            {
                return ajustarAncho(_AlMensCantidad, 30);
            }
            set
            {
                _AlMensCantidad = value;
            }
        }
        public System.String AnticoncepcionTipo
        {
            get
            {
                return ajustarAncho(_AnticoncepcionTipo, 150);
            }
            set
            {
                _AnticoncepcionTipo = value;
            }
        }
        public System.DateTime AnticoncepcionInicio
        {
            get
            {
                return _AnticoncepcionInicio;
            }
            set
            {
                _AnticoncepcionInicio = value;
            }
        }
        public System.DateTime AnticoncepcionSuspencion
        {
            get
            {
                return _AnticoncepcionSuspencion;
            }
            set
            {
                _AnticoncepcionSuspencion = value;
            }
        }
        public System.String GinecologicosObs
        {
            get
            {
                // Seguramente sería mejor sin ajustar el ancho...
                //return ajustarAncho(_GinecologicosObs,2147483647);
                return _GinecologicosObs;
            }
            set
            {
                _GinecologicosObs = value;
            }
        }
        public System.String EnfermedadesV
        {
            get
            {
                // Seguramente sería mejor sin ajustar el ancho...
                //return ajustarAncho(_EnfermedadesV,300);
                return _EnfermedadesV;
            }
            set
            {
                _EnfermedadesV = value;
            }
        }
        //
        //
        // Campos y métodos compartidos (estáticos) para gestionar la base de datos
        //
        // La cadena de conexión a la base de datos
        private static string cadenaConexion = @"Data Source=daxserver; Initial Catalog=BdAdcomDx14CLeones; user id=sa; password=1234qwerASDFZXCV";
        // La cadena de selección
        public static string CadenaSelect = "SELECT * FROM MedAntGin";
        //
        public MedAntGin()
        {
        }
        public MedAntGin(string conex)
        {
            cadenaConexion = conex;
        }
        //
        // Métodos compartidos (estáticos) privados
        //
        // asigna una fila de la tabla a un objeto MedAntGin
        private static MedAntGin row2MedAntGin(DataRow r)
        {
            // asigna a un objeto MedAntGin los datos del dataRow indicado
            MedAntGin oMedAntGin = new MedAntGin();
            //
            oMedAntGin.HistClinica = r["HistClinica"].ToString();
            oMedAntGin.Menarca = System.Int32.Parse("0" + r["Menarca"].ToString());
            oMedAntGin.Menopausia = System.Int32.Parse("0" + r["Menopausia"].ToString());
            try
            {
                oMedAntGin.UltMenstruacion = DateTime.Parse(r["UltMenstruacion"].ToString());
            }
            catch
            {
                // TODO: Usa el valor de fecha que quieras predeterminar
                //       Una fecha ficticia:
                //oMedAntGin.UltMenstruacion = new DateTime(1900, 1, 1);
                //       o la fecha de hoy:
                oMedAntGin.UltMenstruacion = DateTime.Now;
            }
            try
            {
                oMedAntGin.UltCitoligia = DateTime.Parse(r["UltCitoligia"].ToString());
            }
            catch
            {
                // TODO: Usa el valor de fecha que quieras predeterminar
                //       Una fecha ficticia:
                //oMedAntGin.UltCitoligia = new DateTime(1900, 1, 1);
                //       o la fecha de hoy:
                oMedAntGin.UltCitoligia = DateTime.Now;
            }
            oMedAntGin.InicioVidaSexual = System.Int32.Parse("0" + r["InicioVidaSexual"].ToString());
            oMedAntGin.NumeroParejas = System.Int32.Parse("0" + r["NumeroParejas"].ToString());
            oMedAntGin.AlMensFrecuencia = r["AlMensFrecuencia"].ToString();
            oMedAntGin.AlMensDuracion = r["AlMensDuracion"].ToString();
            oMedAntGin.AlMensCantidad = r["AlMensCantidad"].ToString();
            oMedAntGin.AnticoncepcionTipo = r["AnticoncepcionTipo"].ToString();
            try
            {
                oMedAntGin.AnticoncepcionInicio = DateTime.Parse(r["AnticoncepcionInicio"].ToString());
            }
            catch
            {
                // TODO: Usa el valor de fecha que quieras predeterminar
                //       Una fecha ficticia:
                //oMedAntGin.AnticoncepcionInicio = new DateTime(1900, 1, 1);
                //       o la fecha de hoy:
                oMedAntGin.AnticoncepcionInicio = DateTime.Now;
            }
            try
            {
                oMedAntGin.AnticoncepcionSuspencion = DateTime.Parse(r["AnticoncepcionSuspencion"].ToString());
            }
            catch
            {
                // TODO: Usa el valor de fecha que quieras predeterminar
                //       Una fecha ficticia:
                //oMedAntGin.AnticoncepcionSuspencion = new DateTime(1900, 1, 1);
                //       o la fecha de hoy:
                oMedAntGin.AnticoncepcionSuspencion = DateTime.Now;
            }
            oMedAntGin.GinecologicosObs = r["GinecologicosObs"].ToString();
            //oMedAntGin.EnfermedadesV = r["EnfermedadesV"].ToString();
            //
            return oMedAntGin;
        }
        //
        // asigna un objeto MedAntGin a la fila indicada
        private static void MedAntGin2Row(MedAntGin oMedAntGin, DataRow r)
        {
            // asigna un objeto MedAntGin al dataRow indicado
            r["HistClinica"] = oMedAntGin.HistClinica;
            r["Menarca"] = oMedAntGin.Menarca;
            r["Menopausia"] = oMedAntGin.Menopausia;
            r["UltMenstruacion"] = oMedAntGin.UltMenstruacion;
            r["UltCitoligia"] = oMedAntGin.UltCitoligia;
            r["InicioVidaSexual"] = oMedAntGin.InicioVidaSexual;
            r["NumeroParejas"] = oMedAntGin.NumeroParejas;
            r["AlMensFrecuencia"] = oMedAntGin.AlMensFrecuencia;
            r["AlMensDuracion"] = oMedAntGin.AlMensDuracion;
            r["AlMensCantidad"] = oMedAntGin.AlMensCantidad;
            r["AnticoncepcionTipo"] = oMedAntGin.AnticoncepcionTipo;
            r["AnticoncepcionInicio"] = oMedAntGin.AnticoncepcionInicio;
            r["AnticoncepcionSuspencion"] = oMedAntGin.AnticoncepcionSuspencion;
            r["GinecologicosObs"] = oMedAntGin.GinecologicosObs;
           // r["EnfermedadesV"] = oMedAntGin.EnfermedadesV;
        }
        //
        // crea una nueva fila y la asigna a un objeto MedAntGin
        private static void nuevoMedAntGin(DataTable dt, MedAntGin oMedAntGin)
        {
            // Crear un nuevo MedAntGin
            DataRow dr = dt.NewRow();
            MedAntGin oD = row2MedAntGin(dr);
            //
            oD.HistClinica = oMedAntGin.HistClinica;
            oD.Menarca = oMedAntGin.Menarca;
            oD.Menopausia = oMedAntGin.Menopausia;
            oD.UltMenstruacion = oMedAntGin.UltMenstruacion;
            oD.UltCitoligia = oMedAntGin.UltCitoligia;
            oD.InicioVidaSexual = oMedAntGin.InicioVidaSexual;
            oD.NumeroParejas = oMedAntGin.NumeroParejas;
            oD.AlMensFrecuencia = oMedAntGin.AlMensFrecuencia;
            oD.AlMensDuracion = oMedAntGin.AlMensDuracion;
            oD.AlMensCantidad = oMedAntGin.AlMensCantidad;
            oD.AnticoncepcionTipo = oMedAntGin.AnticoncepcionTipo;
            oD.AnticoncepcionInicio = oMedAntGin.AnticoncepcionInicio;
            oD.AnticoncepcionSuspencion = oMedAntGin.AnticoncepcionSuspencion;
            oD.GinecologicosObs = oMedAntGin.GinecologicosObs;
            oD.EnfermedadesV = oMedAntGin.EnfermedadesV;
            //
            MedAntGin2Row(oD, dr);
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
            // devuelve una tabla con los datos de la tabla MedAntGin
            SqlDataAdapter da;
            DataTable dt = new DataTable("MedAntGin");
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
        public static MedAntGin Buscar(string sWhere)
        {
            // Busca en la tabla los datos indicados en el parámetro
            // el parámetro contendrá lo que se usará después del WHERE
            MedAntGin oMedAntGin = null;
            SqlDataAdapter da;
            DataTable dt = new DataTable("MedAntGin");
            string sel = "SELECT * FROM MedAntGin WHERE " + sWhere;
            //
            da = new SqlDataAdapter(sel, cadenaConexion);
            da.Fill(dt);
            //
            if (dt.Rows.Count > 0)
            {
                oMedAntGin = row2MedAntGin(dt.Rows[0]);
            }
            return oMedAntGin;
        }
        //
        // Actualizar: Actualiza los datos en la tabla usando la instancia actual
        //             Si la instancia no hace referencia a un registro existente, se creará uno nuevo
        //             Para comprobar si el objeto en memoria coincide con uno existente,
        //             se comprueba si el HistClinica existe en la tabla.
        //             TODO: Si en lugar de HistClinica usas otro campo, indicalo en la cadena SELECT
        //                   También puedes usar la sobrecarga en la que se indica la cadena SELECT a usar
        public string Actualizar()
        {
            // TODO: Poner aquí la selección a realizar para acceder a este registro
            //       yo uso el HistClinica que es el identificador único de cada registro
            string sel = "SELECT * FROM MedAntGin WHERE HistClinica = '" + this.HistClinica + "'";
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
            DataTable dt = new DataTable("MedAntGin");
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
            ////       Yo compruebo que sea un campo llamado HistClinica, pero en tu caso puede ser otro
            ////       Ese campo, (en mi caso HistClinica) será el que hay que poner al final junto al WHERE.
            //sCommand = "UPDATE MedAntGin SET Menarca = @Menarca, thisnopausia = @Menopausia, UltMenstruacion = @UltMenstruacion, UltCitoligia = @UltCitoligia, InicioVidaSexual = @InicioVidaSexual, NumeroParejas = @NumeroParejas, AlMensFrecuencia = @AlMensFrecuencia, AlMensDuracion = @AlMensDuracion, AlMensCantidad = @AlMensCantidad, AnticoncepcionTipo = @AnticoncepcionTipo, AnticoncepcionInicio = @AnticoncepcionInicio, AnticoncepcionSuspencion = @AnticoncepcionSuspencion, GinecologicosObs = @GinecologicosObs, EnfermedadesV = @EnfermedadesV  WHERE (HistClinica = @HistClinica)";
            //da.UpdateCommand = new SqlCommand(sCommand, cnn);
            //da.UpdateCommand.Parameters.Add("@HistClinica", SqlDbType.NVarChar, 20, "HistClinica");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@Menarca", SqlDbType.Int, 0, "Menarca");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@Menopausia", SqlDbType.Int, 0, "Menopausia");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@UltMenstruacion", SqlDbType.DateTime, 0, "UltMenstruacion");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@UltCitoligia", SqlDbType.DateTime, 0, "UltCitoligia");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@InicioVidaSexual", SqlDbType.Int, 0, "InicioVidaSexual");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@NumeroParejas", SqlDbType.Int, 0, "NumeroParejas");
            //da.UpdateCommand.Parameters.Add("@AlMensFrecuencia", SqlDbType.NVarChar, 30, "AlMensFrecuencia");
            //da.UpdateCommand.Parameters.Add("@AlMensDuracion", SqlDbType.NVarChar, 30, "AlMensDuracion");
            //da.UpdateCommand.Parameters.Add("@AlMensCantidad", SqlDbType.NVarChar, 30, "AlMensCantidad");
            //da.UpdateCommand.Parameters.Add("@AnticoncepcionTipo", SqlDbType.NVarChar, 150, "AnticoncepcionTipo");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@AnticoncepcionInicio", SqlDbType.DateTime, 0, "AnticoncepcionInicio");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@AnticoncepcionSuspencion", SqlDbType.DateTime, 0, "AnticoncepcionSuspencion");
            //// TODO: Este campo seguramente es MEMO y el valor debería ser cero en lugar de 2147483647
            ////da.UpdateCommand.Parameters.Add("@GinecologicosObs", SqlDbType.NText, 2147483647, "GinecologicosObs");
            //da.UpdateCommand.Parameters.Add("@GinecologicosObs", SqlDbType.NText, 0, "GinecologicosObs");
            //// TODO: Este campo seguramente es MEMO y el valor debería ser cero en lugar de 300
            ////da.UpdateCommand.Parameters.Add("@EnfermedadesV", SqlDbType.NText, 300, "EnfermedadesV");
            //da.UpdateCommand.Parameters.Add("@EnfermedadesV", SqlDbType.NText, 0, "EnfermedadesV");
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
                MedAntGin2Row(this, dt.Rows[0]);
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
            DataTable dt = new DataTable("MedAntGin");
            //
            cnn = new SqlConnection(cadenaConexion);
            da = new SqlDataAdapter(CadenaSelect, cnn);
            //da = new SqlDataAdapter(CadenaSelect, cadenaConexion);
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            //
            //-------------------------------------------
            // Esta no es la más óptima, pero funcionará
            //-------------------------------------------
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            da.InsertCommand = cb.GetInsertCommand();
            //
            //--------------------------------------------------------------------
            // Esta está más optimizada pero debes comprobar que funciona bien...
            //--------------------------------------------------------------------
            //string sCommand;
            ////
            //// El comando INSERT
            //// TODO: No incluir el campo de clave primaria incremental
            ////       Yo compruebo que sea un campo llamado HistClinica, pero en tu caso puede ser otro
            //sCommand = "INSERT INTO MedAntGin (HistClinica, thisnarca, thisnopausia, UltMenstruacion, UltCitoligia, InicioVidaSexual, NumeroParejas, AlMensFrecuencia, AlMensDuracion, AlMensCantidad, AnticoncepcionTipo, AnticoncepcionInicio, AnticoncepcionSuspencion, GinecologicosObs, EnfermedadesV)  VALUES(@HistClinica, @Menarca, @Menopausia, @UltMenstruacion, @UltCitoligia, @InicioVidaSexual, @NumeroParejas, @AlMensFrecuencia, @AlMensDuracion, @AlMensCantidad, @AnticoncepcionTipo, @AnticoncepcionInicio, @AnticoncepcionSuspencion, @GinecologicosObs, @EnfermedadesV)";
            //da.InsertCommand = new SqlCommand(sCommand, cnn);
            //da.InsertCommand.Parameters.Add("@HistClinica", SqlDbType.NVarChar, 20, "HistClinica");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@Menarca", SqlDbType.Int, 0, "Menarca");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@Menopausia", SqlDbType.Int, 0, "Menopausia");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@UltMenstruacion", SqlDbType.DateTime, 0, "UltMenstruacion");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@UltCitoligia", SqlDbType.DateTime, 0, "UltCitoligia");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@InicioVidaSexual", SqlDbType.Int, 0, "InicioVidaSexual");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@NumeroParejas", SqlDbType.Int, 0, "NumeroParejas");
            //da.InsertCommand.Parameters.Add("@AlMensFrecuencia", SqlDbType.NVarChar, 30, "AlMensFrecuencia");
            //da.InsertCommand.Parameters.Add("@AlMensDuracion", SqlDbType.NVarChar, 30, "AlMensDuracion");
            //da.InsertCommand.Parameters.Add("@AlMensCantidad", SqlDbType.NVarChar, 30, "AlMensCantidad");
            //da.InsertCommand.Parameters.Add("@AnticoncepcionTipo", SqlDbType.NVarChar, 150, "AnticoncepcionTipo");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@AnticoncepcionInicio", SqlDbType.DateTime, 0, "AnticoncepcionInicio");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@AnticoncepcionSuspencion", SqlDbType.DateTime, 0, "AnticoncepcionSuspencion");
            //// TODO: Este campo seguramente es MEMO y el valor debería ser cero en lugar de 2147483647
            ////da.InsertCommand.Parameters.Add("@GinecologicosObs", SqlDbType.NText, 2147483647, "GinecologicosObs");
            //da.InsertCommand.Parameters.Add("@GinecologicosObs", SqlDbType.NText, 0, "GinecologicosObs");
            //// TODO: Este campo seguramente es MEMO y el valor debería ser cero en lugar de 300
            ////da.InsertCommand.Parameters.Add("@EnfermedadesV", SqlDbType.NText, 300, "EnfermedadesV");
            //da.InsertCommand.Parameters.Add("@EnfermedadesV", SqlDbType.NText, 0, "EnfermedadesV");
            //
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
            nuevoMedAntGin(dt, this);
            //
            try
            {
                da.Update(dt);
                dt.AcceptChanges();
                return "Se ha creado un nuevo MedAntGin";
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
            //       yo uso el HistClinica que es el identificador único de cada registro
            string sel = "SELECT * FROM MedAntGin WHERE HistClinica = '" + this.HistClinica + "'";
            //
            return Borrar(sel);
        }
        public string Borrar(string sel)
        {
            // Borrar el registro al que apunta esta clase
            // En caso de error, devolverá la cadena de error empezando por ERROR:.
            SqlConnection cnn;
            SqlDataAdapter da;
            DataTable dt = new DataTable("MedAntGin");
            //
            cnn = new SqlConnection(cadenaConexion);
            da = new SqlDataAdapter(sel, cnn);
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            //
            //-------------------------------------------
            // Esta no es la más óptima, pero funcionará
            //-------------------------------------------
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            da.DeleteCommand = cb.GetDeleteCommand();
            //
            //
            //--------------------------------------------------------------------
            // Esta está más optimizada pero debes comprobar que funciona bien...
            //--------------------------------------------------------------------
            //string sCommand;
            ////
            //// El comando DELETE
            //// TODO: Sólo incluir el campo de clave primaria incremental
            ////       Yo compruebo que sea un campo llamado HistClinica, pero en tu caso puede ser otro
            //sCommand = "DELETE FROM MedAntGin WHERE (HistClinica = @p1)";
            //da.DeleteCommand = new SqlCommand(sCommand, cnn);
            //da.DeleteCommand.Parameters.Add("@p1", SqlDbType.NVarChar, 20, "HistClinica");
            //da.DeleteCommand.Parameters.Add("@p2", SqlDbType.Int, 0, "");
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
