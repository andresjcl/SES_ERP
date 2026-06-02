using System;
using System.Data;
using System.Data.SqlClient;
using DattCom;
namespace DaxConceptos
{
    public class Servicios
    {
        // Las variables privadas
        // TODO: Revisar los tipos de los campos
        private System.String _Sev_codigo = "";
        private System.String _Sev_nombre = "";
        private System.String _Sev_unimed = "";
        private System.Decimal _Sev_precvta = 0;
        private System.Decimal _Sev_descuen = 0;
        private System.DateTime _Sev_fecinides = new DateTime(1900, 1, 1);
        private System.DateTime _Sev_fecfindes = new DateTime(1900, 1, 1);
        private System.Boolean _Sev_sniva = false;
        private System.String _Sev_usuario = "";
        private System.String _Sev_idcta = "";
        private System.Boolean _Sev_SnPropina = false;
        private System.String _Sev_TipoCos = "";
        private System.Int16 _Sev_SriBien = 0;
        private System.String _Sev_idcta2 = "";
        private System.String _Sev_idcta3 = "";
        private System.String _Sev_idcta4 = "";
        private System.Byte _Sev_IncIva = 0;
        private System.String _Sev_TipoSerSri = "";
        private System.String _Sev_Grupo = "";
        private System.Boolean _Sev_Hotel = false;
        private System.Boolean _sev_escontable = false;
        private System.Boolean _sev_compras = false;
        private System.Boolean _sev_ventas = false;
        private System.Boolean _sev_ingbanco = false;
        private System.Boolean _sev_egrbanco = false;
        private System.Boolean _sev_cruceclientes = false;
        private System.Boolean _sev_cruceproveedores = false;
        private System.String _Sev_Categoria = "";
        private System.String _Sev_Clase = "";
        private System.Decimal _Sev_PorctjComision = 0;
        private string ajustarAncho(string cadena, int ancho)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder(new String(' ', ancho));
            return (cadena + sb.ToString()).Substring(0, ancho).Trim();
        }
        //
        public System.String Sev_codigo
        {
            get
            {
                return ajustarAncho(_Sev_codigo, 15);
            }
            set
            {
                _Sev_codigo = value;
            }
        }
        public System.String Sev_nombre
        {
            get
            {
                return ajustarAncho(_Sev_nombre, 80);
            }
            set
            {
                _Sev_nombre = value;
            }
        }
        public System.String Sev_unimed
        {
            get
            {
                return ajustarAncho(_Sev_unimed, 5);
            }
            set
            {
                _Sev_unimed = value;
            }
        }
        public System.Decimal Sev_precvta
        {
            get
            {
                return _Sev_precvta;
            }
            set
            {
                _Sev_precvta = value;
            }
        }
        public System.Decimal Sev_descuen
        {
            get
            {
                return _Sev_descuen;
            }
            set
            {
                _Sev_descuen = value;
            }
        }
        public System.DateTime Sev_fecinides
        {
            get
            {
                return _Sev_fecinides;
            }
            set
            {
                _Sev_fecinides = value;
            }
        }
        public System.DateTime Sev_fecfindes
        {
            get
            {
                return _Sev_fecfindes;
            }
            set
            {
                _Sev_fecfindes = value;
            }
        }
        public System.Boolean Sev_sniva
        {
            get
            {
                return _Sev_sniva;
            }
            set
            {
                _Sev_sniva = value;
            }
        }
        public System.String Sev_usuario
        {
            get
            {
                return ajustarAncho(_Sev_usuario, 12);
            }
            set
            {
                _Sev_usuario = value;
            }
        }
        public System.String Sev_idcta
        {
            get
            {
                return ajustarAncho(_Sev_idcta, 15);
            }
            set
            {
                _Sev_idcta = value;
            }
        }
        public System.Boolean Sev_SnPropina
        {
            get
            {
                return _Sev_SnPropina;
            }
            set
            {
                _Sev_SnPropina = value;
            }
        }
        public System.String Sev_TipoCos
        {
            get
            {
                return ajustarAncho(_Sev_TipoCos, 1);
            }
            set
            {
                _Sev_TipoCos = value;
            }
        }
        public System.Int16 Sev_SriBien
        {
            get
            {
                return _Sev_SriBien;
            }
            set
            {
                _Sev_SriBien = value;
            }
        }
        public System.String Sev_idcta2
        {
            get
            {
                return ajustarAncho(_Sev_idcta2, 15);
            }
            set
            {
                _Sev_idcta2 = value;
            }
        }
        public System.String Sev_idcta3
        {
            get
            {
                return ajustarAncho(_Sev_idcta3, 15);
            }
            set
            {
                _Sev_idcta3 = value;
            }
        }
        public System.String Sev_idcta4
        {
            get
            {
                return ajustarAncho(_Sev_idcta4, 15);
            }
            set
            {
                _Sev_idcta4 = value;
            }
        }
        public System.Byte Sev_IncIva
        {
            get
            {
                return _Sev_IncIva;
            }
            set
            {
                _Sev_IncIva = value;
            }
        }
        public System.String Sev_TipoSerSri
        {
            get
            {
                return ajustarAncho(_Sev_TipoSerSri, 10);
            }
            set
            {
                _Sev_TipoSerSri = value;
            }
        }
        public System.String Sev_Grupo
        {
            get
            {
                return ajustarAncho(_Sev_Grupo, 50);
            }
            set
            {
                _Sev_Grupo = value;
            }
        }
        public System.Boolean Sev_Hotel
        {
            get
            {
                return _Sev_Hotel;
            }
            set
            {
                _Sev_Hotel = value;
            }
        }
        public System.Boolean sev_escontable
        {
            get
            {
                return _sev_escontable;
            }
            set
            {
                _sev_escontable = value;
            }
        }
        public System.Boolean sev_compras
        {
            get
            {
                return _sev_compras;
            }
            set
            {
                _sev_compras = value;
            }
        }
        public System.Boolean sev_ventas
        {
            get
            {
                return _sev_ventas;
            }
            set
            {
                _sev_ventas = value;
            }
        }
        public System.Boolean sev_ingbanco
        {
            get
            {
                return _sev_ingbanco;
            }
            set
            {
                _sev_ingbanco = value;
            }
        }
        public System.Boolean sev_egrbanco
        {
            get
            {
                return _sev_egrbanco;
            }
            set
            {
                _sev_egrbanco = value;
            }
        }
        public System.Boolean sev_cruceclientes
        {
            get
            {
                return _sev_cruceclientes;
            }
            set
            {
                _sev_cruceclientes = value;
            }
        }
        public System.Boolean sev_cruceproveedores
        {
            get
            {
                return _sev_cruceproveedores;
            }
            set
            {
                _sev_cruceproveedores = value;
            }
        }
        public System.String Sev_Categoria
        {
            get
            {
                return ajustarAncho(_Sev_Categoria, 3);
            }
            set
            {
                _Sev_Categoria = value;
            }
        }
        public System.String Sev_Clase
        {
            get
            {
                return ajustarAncho(_Sev_Clase, 3);
            }
            set
            {
                _Sev_Clase = value;
            }
        }
        public System.Decimal Sev_PorctjComision
        {
            get
            {
                return _Sev_PorctjComision;
            }
            set
            {
                _Sev_PorctjComision = value;
            }
        }
        //
        // La cadena de conexión a la base de datos
        private static string cadenaConexion = @"";
        // La cadena de selección
        public static string CadenaSelect = "SELECT * FROM AdcServ";
        //
        public Servicios()
        {
        }
        public Servicios(string conex)
        {
            cadenaConexion = conex;
        }
        //
        // Métodos compartidos (estáticos) privados
        //
        // asigna una fila de la tabla a un objeto AdcServ
        private static Servicios row2AdcServ(DataRow r)
        {
            // asigna a un objeto AdcServ los datos del dataRow indicado
            Servicios oAdcServ = new Servicios();
            //
            oAdcServ.Sev_codigo = r["Sev_codigo"].ToString();
            oAdcServ.Sev_nombre = r["Sev_nombre"].ToString();
            oAdcServ.Sev_unimed = r["Sev_unimed"].ToString();
            oAdcServ.Sev_precvta = System.Decimal.Parse("0" + r["Sev_precvta"].ToString());
            oAdcServ.Sev_descuen = System.Decimal.Parse("0" + r["Sev_descuen"].ToString());
            try
            {
                oAdcServ.Sev_fecinides = DateTime.Parse(r["Sev_fecinides"].ToString());
            }
            catch
            {
                oAdcServ.Sev_fecinides = new DateTime(1900, 1, 1);
            }
            try
            {
                oAdcServ.Sev_fecfindes = DateTime.Parse(r["Sev_fecfindes"].ToString());
            }
            catch
            {
                oAdcServ.Sev_fecfindes = new DateTime(1900, 1, 1);
            }
            try
            {
                oAdcServ.Sev_sniva = System.Boolean.Parse(r["Sev_sniva"].ToString());
            }
            catch
            {
                oAdcServ.Sev_sniva = false;
            }
            oAdcServ.Sev_usuario = r["Sev_usuario"].ToString();
            oAdcServ.Sev_idcta = r["Sev_idcta"].ToString();
            try
            {
                oAdcServ.Sev_SnPropina = System.Boolean.Parse(r["Sev_SnPropina"].ToString());
            }
            catch
            {
                oAdcServ.Sev_SnPropina = false;
            }
            oAdcServ.Sev_TipoCos = r["Sev_TipoCos"].ToString();
            oAdcServ.Sev_SriBien = System.Int16.Parse("0" + r["Sev_SriBien"].ToString());
            oAdcServ.Sev_idcta2 = r["Sev_idcta2"].ToString();
            oAdcServ.Sev_idcta3 = r["Sev_idcta3"].ToString();
            oAdcServ.Sev_idcta4 = r["Sev_idcta4"].ToString();
            oAdcServ.Sev_IncIva = System.Byte.Parse("0" + r["Sev_IncIva"].ToString());
            oAdcServ.Sev_TipoSerSri = r["Sev_TipoSerSri"].ToString();
            oAdcServ.Sev_Grupo = r["Sev_Grupo"].ToString();
            try
            {
                oAdcServ.Sev_Hotel = System.Boolean.Parse(r["Sev_Hotel"].ToString());
            }
            catch
            {
                oAdcServ.Sev_Hotel = false;
            }
            try
            {
                oAdcServ.sev_escontable = System.Boolean.Parse(r["sev_escontable"].ToString());
            }
            catch
            {
                oAdcServ.sev_escontable = false;
            }
            try
            {
                oAdcServ.sev_compras = System.Boolean.Parse(r["sev_compras"].ToString());
            }
            catch
            {
                oAdcServ.sev_compras = false;
            }
            try
            {
                oAdcServ.sev_ventas = System.Boolean.Parse(r["sev_ventas"].ToString());
            }
            catch
            {
                oAdcServ.sev_ventas = false;
            }
            try
            {
                oAdcServ.sev_ingbanco = System.Boolean.Parse(r["sev_ingbanco"].ToString());
            }
            catch
            {
                oAdcServ.sev_ingbanco = false;
            }
            try
            {
                oAdcServ.sev_egrbanco = System.Boolean.Parse(r["sev_egrbanco"].ToString());
            }
            catch
            {
                oAdcServ.sev_egrbanco = false;
            }
            try
            {
                oAdcServ.sev_cruceclientes = System.Boolean.Parse(r["sev_cruceclientes"].ToString());
            }
            catch
            {
                oAdcServ.sev_cruceclientes = false;
            }
            try
            {
                oAdcServ.sev_cruceproveedores = System.Boolean.Parse(r["sev_cruceproveedores"].ToString());
            }
            catch
            {
                oAdcServ.sev_cruceproveedores = false;
            }
            oAdcServ.Sev_Categoria = r["Sev_Categoria"].ToString();
            oAdcServ.Sev_Clase = r["Sev_Clase"].ToString();
            oAdcServ.Sev_PorctjComision = System.Decimal.Parse("0" + r["Sev_PorctjComision"].ToString());
            //
            return oAdcServ;
        }
        //
        // asigna un objeto AdcServ a la fila indicada
        private static void AdcServ2Row(Servicios oAdcServ, DataRow r)
        {
            // asigna un objeto AdcServ al dataRow indicado
            r["Sev_codigo"] = oAdcServ.Sev_codigo;
            r["Sev_nombre"] = oAdcServ.Sev_nombre;
            r["Sev_unimed"] = oAdcServ.Sev_unimed;
            r["Sev_precvta"] = oAdcServ.Sev_precvta;
            r["Sev_descuen"] = oAdcServ.Sev_descuen;
            r["Sev_fecinides"] = oAdcServ.Sev_fecinides;
            r["Sev_fecfindes"] = oAdcServ.Sev_fecfindes;
            r["Sev_sniva"] = oAdcServ.Sev_sniva;
            r["Sev_usuario"] = oAdcServ.Sev_usuario;
            r["Sev_idcta"] = oAdcServ.Sev_idcta;
            r["Sev_SnPropina"] = oAdcServ.Sev_SnPropina;
            r["Sev_TipoCos"] = oAdcServ.Sev_TipoCos;
            r["Sev_SriBien"] = oAdcServ.Sev_SriBien;
            r["Sev_idcta2"] = oAdcServ.Sev_idcta2;
            r["Sev_idcta3"] = oAdcServ.Sev_idcta3;
            r["Sev_idcta4"] = oAdcServ.Sev_idcta4;
            r["Sev_IncIva"] = oAdcServ.Sev_IncIva;
            r["Sev_TipoSerSri"] = oAdcServ.Sev_TipoSerSri;
            r["Sev_Grupo"] = oAdcServ.Sev_Grupo;
            r["Sev_Hotel"] = oAdcServ.Sev_Hotel;
            r["sev_escontable"] = oAdcServ.sev_escontable;
            r["sev_compras"] = oAdcServ.sev_compras;
            r["sev_ventas"] = oAdcServ.sev_ventas;
            r["sev_ingbanco"] = oAdcServ.sev_ingbanco;
            r["sev_egrbanco"] = oAdcServ.sev_egrbanco;
            r["sev_cruceclientes"] = oAdcServ.sev_cruceclientes;
            r["sev_cruceproveedores"] = oAdcServ.sev_cruceproveedores;
            r["Sev_Categoria"] = oAdcServ.Sev_Categoria;
            r["Sev_Clase"] = oAdcServ.Sev_Clase;
            r["Sev_PorctjComision"] = oAdcServ.Sev_PorctjComision;
        }
        //
        // crea una nueva fila y la asigna a un objeto AdcServ
        private static void nuevoAdcServ(DataTable dt, Servicios oAdcServ)
        {
            // Crear un nuevo AdcServ
            DataRow dr = dt.NewRow();
            Servicios oA = row2AdcServ(dr);
            //
            oA.Sev_codigo = oAdcServ.Sev_codigo;
            oA.Sev_nombre = oAdcServ.Sev_nombre;
            oA.Sev_unimed = oAdcServ.Sev_unimed;
            oA.Sev_precvta = oAdcServ.Sev_precvta;
            oA.Sev_descuen = oAdcServ.Sev_descuen;
            oA.Sev_fecinides = oAdcServ.Sev_fecinides;
            oA.Sev_fecfindes = oAdcServ.Sev_fecfindes;
            oA.Sev_sniva = oAdcServ.Sev_sniva;
            oA.Sev_usuario = oAdcServ.Sev_usuario;
            oA.Sev_idcta = oAdcServ.Sev_idcta;
            oA.Sev_SnPropina = oAdcServ.Sev_SnPropina;
            oA.Sev_TipoCos = oAdcServ.Sev_TipoCos;
            oA.Sev_SriBien = oAdcServ.Sev_SriBien;
            oA.Sev_idcta2 = oAdcServ.Sev_idcta2;
            oA.Sev_idcta3 = oAdcServ.Sev_idcta3;
            oA.Sev_idcta4 = oAdcServ.Sev_idcta4;
            oA.Sev_IncIva = oAdcServ.Sev_IncIva;
            oA.Sev_TipoSerSri = oAdcServ.Sev_TipoSerSri;
            oA.Sev_Grupo = oAdcServ.Sev_Grupo;
            oA.Sev_Hotel = oAdcServ.Sev_Hotel;
            oA.sev_escontable = oAdcServ.sev_escontable;
            oA.sev_compras = oAdcServ.sev_compras;
            oA.sev_ventas = oAdcServ.sev_ventas;
            oA.sev_ingbanco = oAdcServ.sev_ingbanco;
            oA.sev_egrbanco = oAdcServ.sev_egrbanco;
            oA.sev_cruceclientes = oAdcServ.sev_cruceclientes;
            oA.sev_cruceproveedores = oAdcServ.sev_cruceproveedores;
            oA.Sev_Categoria = oAdcServ.Sev_Categoria;
            oA.Sev_Clase = oAdcServ.Sev_Clase;
            oA.Sev_PorctjComision = oAdcServ.Sev_PorctjComision;
            //
            AdcServ2Row(oA, dr);
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
            // devuelve una tabla con los datos de la tabla AdcServ
            SqlDataAdapter da;
            DataTable dt = new DataTable("AdcServ");
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
        public static Servicios Buscar(string sWhere)
        {
            // Busca en la tabla los datos indicados en el parámetro
            // el parámetro contendrá lo que se usará después del WHERE
            Servicios oAdcServ = null;
            SqlDataAdapter da;
            DataTable dt = new DataTable("AdcServ");
            string sel = "SELECT * FROM AdcServ WHERE " + sWhere;
            //
            da = new SqlDataAdapter(sel, cadenaConexion);
            da.Fill(dt);
            //
            if (dt.Rows.Count > 0)
            {
                oAdcServ = row2AdcServ(dt.Rows[0]);
            }
            return oAdcServ;
        }
        public string Actualizar()
        {
            string sel = "SELECT * FROM AdcServ WHERE Sev_codigo = '" + this.Sev_codigo + "'";
            return Actualizar(sel);
        }
        public string Actualizar(string sel)
        {
            SqlConnection cnn;
            SqlDataAdapter da;
            DataTable dt = new DataTable("AdcServ");
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
                AdcServ2Row(this, dt.Rows[0]);
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
            DataTable dt = new DataTable("AdcServ");
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
            nuevoAdcServ(dt, this);
            //
            try
            {
                da.Update(dt);
                dt.AcceptChanges();
                return "Se ha creado un nuevo AdcServ";
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
        }
        //
        public string Borrar()
        {
            string sel = "SELECT * FROM AdcServ WHERE Sev_codigo = '" + this.Sev_codigo + "'";
            //
            return Borrar(sel);
        }
        public string Borrar(string sel)
        {
            SqlConnection cnn;
            SqlDataAdapter da;
            DataTable dt = new DataTable("AdcServ");
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
        // utilidades para manejo de servicios
        public bool ServUsado(string cod)
        {
            string sSQL = ("SELECT top(1) tra_codigo FROM AdcTra WHERE Tra_Codigo='"
                        + (cod + " ' and tra_quetipo = 'S' "));
            bool resp = false;
            SqlConnection conn = new SqlConnection(datosEmpresa.strConxAdcom);
            conn.Open();
            SqlCommand comm = new SqlCommand(sSQL, conn);
            SqlDataReader rstemp = comm.ExecuteReader();
            resp = rstemp.HasRows;
            
            sSQL = ("SELECT TOP(1) * FROM ADCAPL WHERE CODCONCEPTO = '"
                            + (cod + "'"));
            comm.Dispose();
            rstemp.Close();

            SqlCommand comm2 = new SqlCommand(sSQL, conn);
            SqlDataReader rstemp2 = comm2.ExecuteReader();
            if (rstemp.HasRows) resp = true;
            return resp;
        }

        public string Clasificadores(string Tipodoc)
        {
            string lacuenta="";
            return ClasificadorYcuenta(Tipodoc, ref lacuenta);
        }

        public string ClasificadorYcuenta(string Tipodoc, ref string CtaCont, sesSys.OpcDoc opopc = null)
        {
            string cuentaa="";
            string CuentaDocDeb="";
            string CuentaDocHab="";
            bool esBanco=false;
            string lugar = "";
            string CYC = "";
            if (sev_escontable )
            {
                cuentaa = Sev_codigo;
            }
            else if ((Tipodoc == ""))
            {
                return CYC;
            }
            else
            {
                if (opopc == null) { opopc = new sesSys.OpcDoc(); opopc.Cargar(ref Tipodoc, ref lugar);}
                if (opopc.nombre == "") return "";

                switch (opopc.TipoDoc)
                {
                    case "EGR":
                    case "ING":
                    case "NCB":
                    case "NDB":
                        esBanco = true;
                        break;
                }
                CuentaDocDeb = (esBanco ? opopc.VarCtaRetBieD : opopc.CtaSubTConIvaD);
                if ((CuentaDocDeb != ""))
                {
                    if ((CuentaDocDeb.Substring(0, 1) == "&"))
                    {
                        CuentaDocDeb = CuentaDocDeb.Substring(1);
                        switch (CuentaDocDeb)
                        {
                            case "SERV-OTROS":
                                cuentaa = Sev_idcta;
                                break;
                            case "SERV-OTRO2":
                                cuentaa = Sev_idcta2;
                                break;
                            case "SERV-OTRO3":
                                cuentaa = Sev_idcta3;
                                break;
                            case "SERV-OTRO4":
                                cuentaa = Sev_idcta4;
                                break;
                        }
                    }
                    else
                    {
                        cuentaa = CuentaDocDeb;
                    }

                }

                CuentaDocHab = (esBanco ? opopc.VarCtaRetBieH : opopc.CtaSubTConIvaH);
                if (((CuentaDocHab.Length > 0) && (cuentaa == "")))
                {
                    if ((CuentaDocHab.Substring(0, 1) == "&"))
                    {
                        CuentaDocHab = CuentaDocHab.Substring(1);
                        switch (CuentaDocHab)
                        {
                            case "SERV-OTROS":
                                cuentaa = Sev_idcta;
                                break;
                            case "SERV-OTRO2":
                                cuentaa = Sev_idcta2;
                                break;
                            case "SERV-OTRO3":
                                cuentaa = Sev_idcta3;
                                break;
                            case "SERV-OTRO4":
                                cuentaa = Sev_idcta4;
                                break;
                        }
                    }
                    else
                    {
                        cuentaa = CuentaDocHab;
                    }

                }

            }

            if ((cuentaa.Length > 0))
            {
                CtaCont = cuentaa;

                string sSql = "SELECT isnull(CLASIFICADORES,'') as CLASIFICADORES FROM ADCCTA WHERE CTA_CODIGO = '" + (cuentaa + "' ");
                SqlDataReader RS = DattCom.SqlDatos.leerBaseAdcom(sSql);

                if (RS.Read())
                {
                   CYC = RS["Clasificadores"].ToString();
                }
                RS.Close();
            }
            return CYC;
        }

    }
}
