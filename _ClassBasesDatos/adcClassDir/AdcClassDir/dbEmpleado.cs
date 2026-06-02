
//------------------------------------------------------------------------------
using System;
using System.Data;
using System.Data.SqlClient;
//
    public class dbEmpleado
    {
        // Las variables privadas
        // TODO: Revisar los tipos de los campos
        private System.String _CodigoEmpleado="";
        private System.String _Carnetseguro="";
        private System.String _Libretamilitar = "";
        private System.String _Sucursalrol = "";
        private System.String _Departamento = "";
        private System.String _Cargorol = "";
        private System.DateTime _FechaIngreso= new DateTime(1900,1,1);
        private System.DateTime _FechaSalida = new DateTime(1900, 1, 1);
        private System.DateTime _FechaJubilacion = new DateTime(1900, 1, 1);
        private System.Byte _NivelRol = 0;
        private System.String _TipoPago = "";
        private System.String _TipoSalario = "";
        private System.Boolean _AcreditarBanco;
        private System.String _BancoRol = "";
        private System.Decimal _ValorSueldo = 0;
        private System.Decimal _HorSemanaParcial = 0;
        private System.String _NroCtaBancoRol = "";
        private System.String _TipoCuentaBanco = "";
        private System.String _Grupo_1 = "";
        private System.String _Grupo_2 = "";
        private System.String _Grupo_3 = "";
        private System.String _Grupo_4 = "";
        private System.String _Grupo_5 = "";
        private System.String _Grupo_6 = "";
        private System.String _EstadoRol = "";
        private System.String _CtbRol_0_ = "";
        private System.String _CtbRol_1_ = "";
        private System.String _CtbRol_2_ = "";
        private System.String _Idusuario = "";
        private System.Int32 _Adicional1 = 0;
        private System.String _Adicional2 = "";
        private System.Int32 _turnolaboral=0;
        private System.String _centroCosto = "";
        private System.String _codigoBiometrico = "";
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
        public System.String CodigoEmpleado
        {
            get
            {
                return ajustarAncho(_CodigoEmpleado, 15);
            }
            set
            {
                _CodigoEmpleado = value;
            }
        }
        public System.String Carnetseguro
        {
            get
            {
                return ajustarAncho(_Carnetseguro, 50);
            }
            set
            {
                _Carnetseguro = value;
            }
        }
        public System.String Libretamilitar
        {
            get
            {
                return ajustarAncho(_Libretamilitar, 50);
            }
            set
            {
                _Libretamilitar = value;
            }
        }
        public System.String Sucursalrol
        {
            get
            {
                return ajustarAncho(_Sucursalrol, 50);
            }
            set
            {
                _Sucursalrol = value;
            }
        }
        public System.String Departamento
        {
            get
            {
                return ajustarAncho(_Departamento, 50);
            }
            set
            {
                _Departamento = value;
            }
        }
        public System.String Cargorol
        {
            get
            {
                return ajustarAncho(_Cargorol, 80);
            }
            set
            {
                _Cargorol = value;
            }
        }
        public System.DateTime FechaIngreso
        {
            get
            {
                return _FechaIngreso;
            }
            set
            {
                _FechaIngreso = value;
            }
        }
        public System.DateTime FechaSalida
        {
            get
            {
                return _FechaSalida;
            }
            set
            {
                _FechaSalida = value;
            }
        }
        public System.DateTime FechaJubilacion
        {
            get
            {
                return _FechaJubilacion;
            }
            set
            {
                _FechaJubilacion = value;
            }
        }
        public System.Byte NivelRol
        {
            get
            {
                return _NivelRol;
            }
            set
            {
                _NivelRol = value;
            }
        }
        public System.String TipoPago
        {
            get
            {
                return ajustarAncho(_TipoPago, 50);
            }
            set
            {
                _TipoPago = value;
            }
        }
        public System.String TipoSalario
        {
            get
            {
                return ajustarAncho(_TipoSalario, 50);
            }
            set
            {
                _TipoSalario = value;
            }
        }
        public System.Boolean AcreditarBanco
        {
            get
            {
                return _AcreditarBanco;
            }
            set
            {
                _AcreditarBanco = value;
            }
        }
        public System.String BancoRol
        {
            get
            {
                return ajustarAncho(_BancoRol, 50);
            }
            set
            {
                _BancoRol = value;
            }
        }
        public System.Decimal ValorSueldo
        {
            get
            {
                return _ValorSueldo;
            }
            set
            {
                _ValorSueldo = value;
            }
        }
        public System.Decimal HorSemanaParcial
        {
            get
            {
                return _HorSemanaParcial;
            }
            set
            {
                _HorSemanaParcial = value;
            }
        }
        public System.String NroCtaBancoRol
        {
            get
            {
                return ajustarAncho(_NroCtaBancoRol, 50);
            }
            set
            {
                _NroCtaBancoRol = value;
            }
        }
        public System.String TipoCuentaBanco
        {
            get
            {
                return ajustarAncho(_TipoCuentaBanco, 50);
            }
            set
            {
                _TipoCuentaBanco = value;
            }
        }
        public System.String Grupo_1
        {
            get
            {
                return ajustarAncho(_Grupo_1, 50);
            }
            set
            {
                _Grupo_1 = value;
            }
        }
        public System.String Grupo_2
        {
            get
            {
                return ajustarAncho(_Grupo_2, 50);
            }
            set
            {
                _Grupo_2 = value;
            }
        }
        public System.String Grupo_3
        {
            get
            {
                return ajustarAncho(_Grupo_3, 50);
            }
            set
            {
                _Grupo_3 = value;
            }
        }
        public System.String Grupo_4
        {
            get
            {
                return ajustarAncho(_Grupo_4, 50);
            }
            set
            {
                _Grupo_4 = value;
            }
        }
        public System.String Grupo_5
        {
            get
            {
                return ajustarAncho(_Grupo_5, 50);
            }
            set
            {
                _Grupo_5 = value;
            }
        }
        public System.String Grupo_6
        {
            get
            {
                return ajustarAncho(_Grupo_6, 50);
            }
            set
            {
                _Grupo_6 = value;
            }
        }
        public System.String EstadoRol
        {
            get
            {
                return ajustarAncho(_EstadoRol, 50);
            }
            set
            {
                _EstadoRol = value;
            }
        }
        public System.String CtbRol_0_
        {
            get
            {
                return ajustarAncho(_CtbRol_0_, 50);
            }
            set
            {
                _CtbRol_0_ = value;
            }
        }
        public System.String CtbRol_1_
        {
            get
            {
                return ajustarAncho(_CtbRol_1_, 50);
            }
            set
            {
                _CtbRol_1_ = value;
            }
        }
        public System.String CtbRol_2_
        {
            get
            {
                return ajustarAncho(_CtbRol_2_, 50);
            }
            set
            {
                _CtbRol_2_ = value;
            }
        }
        public System.String Idusuario
        {
            get
            {
                return ajustarAncho(_Idusuario, 50);
            }
            set
            {
                _Idusuario = value;
            }
        }
        public System.Int32 Adicional1
        {
            get
            {
                return _Adicional1;
            }
            set
            {
                _Adicional1 = value;
            }
        }
        public System.String Adicional2
        {
            get
            {
                return ajustarAncho(_Adicional2, 50);
            }
            set
            {
                _Adicional2 = value;
            }
        }
        public System.Int32 turnolaboral
        {
            get
            {
                return _turnolaboral;
            }
            set
            {
                _turnolaboral = value;
            }
        }
        public System.String centroCosto
        {
            get
            {
                return ajustarAncho(_centroCosto, 50);
            }
            set
            {
                _centroCosto = value;
            }
        }
        public System.String codigoBiometrico
        {
            get
            {
                return ajustarAncho(_codigoBiometrico, 50);
            }
            set
            {
                _codigoBiometrico = value;
            }
        }
        //
        //
        // Campos y métodos compartidos (estáticos) para gestionar la base de datos
        //
        // La cadena de conexión a la base de datos
        private static string cadenaConexion = @"";
        // La cadena de selección
        public static string CadenaSelect = "SELECT * FROM EMPLEADO";
        //
        public dbEmpleado()
        {
        }
        public dbEmpleado(string conex)
        {
            cadenaConexion = conex;
        }
        //
        // Métodos compartidos (estáticos) privados
        //
        // asigna una fila de la tabla a un objeto EMPLEADO
        private static dbEmpleado row2EMPLEADO(DataRow r)
        {
            // asigna a un objeto EMPLEADO los datos del dataRow indicado
            dbEmpleado oEMPLEADO = new dbEmpleado();
            //
            oEMPLEADO.CodigoEmpleado = r["CodigoEmpleado"].ToString();
            oEMPLEADO.Carnetseguro = r["Carnetseguro"].ToString();
            oEMPLEADO.Libretamilitar = r["Libretamilitar"].ToString();
            oEMPLEADO.Sucursalrol = r["Sucursalrol"].ToString();
            oEMPLEADO.Departamento = r["Departamento"].ToString();
            oEMPLEADO.Cargorol = r["Cargorol"].ToString();
            try
            {
                oEMPLEADO.FechaIngreso = DateTime.Parse(r["FechaIngreso"].ToString());
            }
            catch
            {
                oEMPLEADO.FechaIngreso = new DateTime(1900, 1, 1);
            }
            try
            {
                oEMPLEADO.FechaSalida = DateTime.Parse(r["FechaSalida"].ToString());
            }
            catch
            {
                oEMPLEADO.FechaSalida = new DateTime(1900, 1, 1);
            }
            try
            {
                oEMPLEADO.FechaJubilacion = DateTime.Parse(r["FechaJubilacion"].ToString());
            }
            catch
            {
                oEMPLEADO.FechaJubilacion = new DateTime(1900, 1, 1);
            }
            oEMPLEADO.NivelRol = System.Byte.Parse("0" + r["NivelRol"].ToString());
            oEMPLEADO.TipoPago = r["TipoPago"].ToString();
            oEMPLEADO.TipoSalario = r["TipoSalario"].ToString();
            try
            {
                oEMPLEADO.AcreditarBanco = System.Boolean.Parse(r["AcreditarBanco"].ToString());
            }
            catch
            {
                oEMPLEADO.AcreditarBanco = false;
            }
            oEMPLEADO.BancoRol = r["BancoRol"].ToString();
            oEMPLEADO.ValorSueldo = System.Decimal.Parse("0" + r["ValorSueldo"].ToString());
            oEMPLEADO.HorSemanaParcial = System.Decimal.Parse("0" + r["HorSemanaParcial"].ToString());
            oEMPLEADO.NroCtaBancoRol = r["NroCtaBancoRol"].ToString();
            oEMPLEADO.TipoCuentaBanco = r["TipoCuentaBanco"].ToString();
            oEMPLEADO.Grupo_1 = r["Grupo_1"].ToString();
            oEMPLEADO.Grupo_2 = r["Grupo_2"].ToString();
            oEMPLEADO.Grupo_3 = r["Grupo_3"].ToString();
            oEMPLEADO.Grupo_4 = r["Grupo_4"].ToString();
            oEMPLEADO.Grupo_5 = r["Grupo_5"].ToString();
            oEMPLEADO.Grupo_6 = r["Grupo_6"].ToString();
            oEMPLEADO.EstadoRol = r["EstadoRol"].ToString();
            oEMPLEADO.CtbRol_0_ = r["CtbRol(0)"].ToString();
            oEMPLEADO.CtbRol_1_ = r["CtbRol(1)"].ToString();
            oEMPLEADO.CtbRol_2_ = r["CtbRol(2)"].ToString();
            oEMPLEADO.Idusuario = r["Idusuario"].ToString();
            oEMPLEADO.Adicional1 = System.Int32.Parse("0" + r["Adicional1"].ToString());
            oEMPLEADO.Adicional2 = r["Adicional2"].ToString();
            oEMPLEADO.turnolaboral = System.Int32.Parse("0" + r["turnolaboral"].ToString());
            oEMPLEADO.centroCosto = r["centroCosto"].ToString();
            oEMPLEADO.codigoBiometrico = r["codigoBiometrico"].ToString();
            //
            return oEMPLEADO;
        }
        //
        // asigna un objeto EMPLEADO a la fila indicada
        private static void EMPLEADO2Row(dbEmpleado oEMPLEADO, DataRow r)
        {
            // asigna un objeto EMPLEADO al dataRow indicado
            r["CodigoEmpleado"] = oEMPLEADO.CodigoEmpleado;
            r["Carnetseguro"] = oEMPLEADO.Carnetseguro;
            r["Libretamilitar"] = oEMPLEADO.Libretamilitar;
            r["Sucursalrol"] = oEMPLEADO.Sucursalrol;
            r["Departamento"] = oEMPLEADO.Departamento;
            r["Cargorol"] = oEMPLEADO.Cargorol;
            r["FechaIngreso"] = oEMPLEADO.FechaIngreso;
            r["FechaSalida"] = oEMPLEADO.FechaSalida;
            r["FechaJubilacion"] = oEMPLEADO.FechaJubilacion;
            r["NivelRol"] = oEMPLEADO.NivelRol;
            r["TipoPago"] = oEMPLEADO.TipoPago;
            r["TipoSalario"] = oEMPLEADO.TipoSalario;
            r["AcreditarBanco"] = oEMPLEADO.AcreditarBanco;
            r["BancoRol"] = oEMPLEADO.BancoRol;
            r["ValorSueldo"] = oEMPLEADO.ValorSueldo;
            r["HorSemanaParcial"] = oEMPLEADO.HorSemanaParcial;
            r["NroCtaBancoRol"] = oEMPLEADO.NroCtaBancoRol;
            r["TipoCuentaBanco"] = oEMPLEADO.TipoCuentaBanco;
            r["Grupo_1"] = oEMPLEADO.Grupo_1;
            r["Grupo_2"] = oEMPLEADO.Grupo_2;
            r["Grupo_3"] = oEMPLEADO.Grupo_3;
            r["Grupo_4"] = oEMPLEADO.Grupo_4;
            r["Grupo_5"] = oEMPLEADO.Grupo_5;
            r["Grupo_6"] = oEMPLEADO.Grupo_6;
            r["EstadoRol"] = oEMPLEADO.EstadoRol;
            r["CtbRol(0)"] = oEMPLEADO.CtbRol_0_;
            r["CtbRol(1)"] = oEMPLEADO.CtbRol_1_;
            r["CtbRol(2)"] = oEMPLEADO.CtbRol_2_;
            r["Idusuario"] = oEMPLEADO.Idusuario;
            r["Adicional1"] = oEMPLEADO.Adicional1;
            r["Adicional2"] = oEMPLEADO.Adicional2;
            r["turnolaboral"] = oEMPLEADO.turnolaboral;
            r["centroCosto"] = oEMPLEADO.centroCosto;
            r["codigoBiometrico"] = oEMPLEADO.codigoBiometrico;
        }
        //
        // crea una nueva fila y la asigna a un objeto EMPLEADO
        private static void nuevoEMPLEADO(DataTable dt, dbEmpleado oEMPLEADO)
        {
            // Crear un nuevo EMPLEADO
            DataRow dr = dt.NewRow();
            dbEmpleado oE = row2EMPLEADO(dr);
            //
            oE.CodigoEmpleado = oEMPLEADO.CodigoEmpleado;
            oE.Carnetseguro = oEMPLEADO.Carnetseguro;
            oE.Libretamilitar = oEMPLEADO.Libretamilitar;
            oE.Sucursalrol = oEMPLEADO.Sucursalrol;
            oE.Departamento = oEMPLEADO.Departamento;
            oE.Cargorol = oEMPLEADO.Cargorol;
            oE.FechaIngreso = oEMPLEADO.FechaIngreso;
            oE.FechaSalida = oEMPLEADO.FechaSalida;
            oE.FechaJubilacion  = oEMPLEADO.FechaJubilacion;
            oE.NivelRol = oEMPLEADO.NivelRol;
            oE.TipoPago = oEMPLEADO.TipoPago;
            oE.TipoSalario = oEMPLEADO.TipoSalario;
            oE.AcreditarBanco = oEMPLEADO.AcreditarBanco;
            oE.BancoRol = oEMPLEADO.BancoRol;
            oE.ValorSueldo = oEMPLEADO.ValorSueldo;
            oE.HorSemanaParcial = oEMPLEADO.HorSemanaParcial;
            oE.NroCtaBancoRol = oEMPLEADO.NroCtaBancoRol;
            oE.TipoCuentaBanco = oEMPLEADO.TipoCuentaBanco;
            oE.Grupo_1 = oEMPLEADO.Grupo_1;
            oE.Grupo_2 = oEMPLEADO.Grupo_2;
            oE.Grupo_3 = oEMPLEADO.Grupo_3;
            oE.Grupo_4 = oEMPLEADO.Grupo_4;
            oE.Grupo_5 = oEMPLEADO.Grupo_5;
            oE.Grupo_6 = oEMPLEADO.Grupo_6;
            oE.EstadoRol = oEMPLEADO.EstadoRol;
            oE.CtbRol_0_ = oEMPLEADO.CtbRol_0_;
            oE.CtbRol_1_ = oEMPLEADO.CtbRol_1_;
            oE.CtbRol_2_ = oEMPLEADO.CtbRol_2_;
            oE.Idusuario = oEMPLEADO.Idusuario;
            oE.Adicional1 = oEMPLEADO.Adicional1;
            oE.Adicional2 = oEMPLEADO.Adicional2;
            oE.turnolaboral = oEMPLEADO.turnolaboral;
            oE.centroCosto = oEMPLEADO.centroCosto;
            oE.codigoBiometrico = oEMPLEADO.codigoBiometrico;
            //
            EMPLEADO2Row(oE, dr);
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
            // devuelve una tabla con los datos de la tabla EMPLEADO
            SqlDataAdapter da;
            DataTable dt = new DataTable("EMPLEADO");
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
        public static dbEmpleado Buscar(string sWhere)
        {
            // Busca en la tabla los datos indicados en el parámetro
            // el parámetro contendrá lo que se usará después del WHERE
            dbEmpleado oEMPLEADO = null;
            SqlDataAdapter da;
            DataTable dt = new DataTable("EMPLEADO");
            string sel = "SELECT * FROM EMPLEADO WHERE " + sWhere;
            //
            da = new SqlDataAdapter(sel, cadenaConexion);
            da.Fill(dt);
            //
            if (dt.Rows.Count > 0)
            {
                oEMPLEADO = row2EMPLEADO(dt.Rows[0]);
            }
            return oEMPLEADO;
        }
        //
        // Actualizar: Actualiza los datos en la tabla usando la instancia actual
        //             Si la instancia no hace referencia a un registro existente, se creará uno nuevo
        //             Para comprobar si el objeto en memoria coincide con uno existente,
        //             se comprueba si el CodigoEmpleado existe en la tabla.
        public string Actualizar()
        {
            string sel = "SELECT * FROM EMPLEADO WHERE CodigoEmpleado = '" + this.CodigoEmpleado + "'";
            return Actualizar(sel);
        }
        public string Actualizar(string sel)
        {
            SqlConnection cnn;
            SqlDataAdapter da;
            DataTable dt = new DataTable("EMPLEADO");
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
                EMPLEADO2Row(this, dt.Rows[0]);
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
            DataTable dt = new DataTable("EMPLEADO");
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
            nuevoEMPLEADO(dt, this);
            //
            try
            {
                da.Update(dt);
                dt.AcceptChanges();
                return "Se ha creado un nuevo EMPLEADO";
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
        }
        //
        public string Borrar()
        {
            string sel = "SELECT * FROM EMPLEADO WHERE CodigoEmpleado = '" + this.CodigoEmpleado + "'";
            //
            return Borrar(sel);
        }
        public string Borrar(string sel)
        {
            // Borrar el registro al que apunta esta clase
            // En caso de error, devolverá la cadena de error empezando por ERROR:.
            SqlConnection cnn;
            SqlDataAdapter da;
            DataTable dt = new DataTable("EMPLEADO");
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

