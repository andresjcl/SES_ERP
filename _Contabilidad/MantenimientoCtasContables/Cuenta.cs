using System;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using SysEmpDatt;

namespace MantCtb
{
    public class Cuenta
    {
        // *******************
        public string codigo; // copia local
        public string Nombre; // copia local
        public string Grupo; // copia local
        public bool Agrupacion; // copia local
        public short Nivel;
        public string TipoPresu; // copia local
        public string ClaveSeg; // copia local
        public string ClaveAux1; // copia local balance resultados
        public string ClaveAux2; // copia local agrupacion
        public string ClaveAux3; // copia local flujo de caja
        public string ClaveAux4; // copia local dsri f 101
        public bool Ccosto;
        public bool EsGasto;
        public short ConceptoCompras;
        public short ConceptoVentas;
        public short ConceptoBcoEgreso;
        public short ConceptoBcoIngreso;
        public string CodigoAlterno;
        public bool escosDirecto;
        public bool esCosIndirecto;
        public string ModuloAuxiliar;
        public DaxClasificadores.ClasificadoresCtb colclassif;
        public string Clasificadores;
        public string CuentaPadre;
        public string usuario;
        public string Detalle;
        public DateTime FechaCierre;
        public string Estado;
        public bool Gasto;
        public bool CosDirecto;
        public bool CosIndirecto;
        public string tipoCosto;
        public static DataTable DatEmp;

        public bool Eliminar(ref string cod)
        {
            bool EliminarRet = default;
            short Largo;
            EliminarRet = false;
            Largo = (short)Strings.Len(cod);
            string ssql = "select top( 1) * from adcdia where Cta_codigo  ='" + cod + "' ";
            var rs = SqlDatos.leerBase(ssql, datosEmpresa.strConxAdcom);
            if (rs.Read() == false)
            {
                rs.Close();
                ssql = "select top( 1) * from adccta where substring(Cta_codigo,1," + Largo + ") ='" + cod + "' and cta_codigo <> '" + cod + "'";
                rs = SqlDatos.leerBase(ssql, datosEmpresa.strConxAdcom);
                if (rs.Read() == false)
                {
                    SqlDatos.ejecutarComando("DELETE FROM AdcCta WHERE Cta_codigo='" + cod + "' ", datosEmpresa.strConxAdcom);
                    EliminarRet = true;
                }
                else
                {
                    Interaction.MsgBox("ERROR, No puede eliminarse la cuenta," + Constants.vbCr + " Existen cuentas auxiliares");
                }
            }
            else
            {
                Interaction.MsgBox("ERROR, No puede eliminarse la cuenta," + Constants.vbCr + " Existen movimientos contables");
            }

            return EliminarRet;
        }

        public void EliminarCtaBco(ref string cod)
        {
            string CODSQL = "DELETE FROM AdcCtaBco WHERE Bco_codigo='" + cod + "' ";
            SqlDatos.ejecutarComando(CODSQL, datosEmpresa.strConxAdcom);
        }

        public void Cargar(ref string cod)
        {
            // Dim libdat As New DaxLib.DaxLibDigDato
            // Dim LIBBD As New DaxLib.DaxLibBases
            // Dim linkdat As New DaxData.DaxLibDatos
            codigo = "";
            Nombre = "";
            Grupo = "";
            Agrupacion = false;
            TipoPresu = "";
            ClaveSeg = "";
            ClaveAux1 = "";
            ClaveAux2 = "";
            ClaveAux3 = "";
            ClaveAux4 = "";
            ConceptoCompras = 0;
            ConceptoVentas = 0;
            ConceptoBcoEgreso = 0;
            ConceptoBcoIngreso = 0;
            CodigoAlterno = "";
            Clasificadores = "";
            usuario = "";
            CuentaPadre = "";
            escosDirecto = false;
            esCosIndirecto = false;
            Ccosto = false;
            EsGasto = false;
            tipoCosto = "";
            Detalle = "";
            FechaCierre = DateTime.FromOADate((double)VariantType.Null);
            Estado = "";
            Nivel = 0;
            // Dim conxadcom As New ADODB.Connection
            // LIBBD.TipoBase = "SQL"
            // conxadcom.ConnectionString = LIBBD.StrAdcom
            // conxadcom.Open()
            var rs = SqlDatos.leerBase("SELECT * FROM AdcCta WHERE Cta_Codigo='" + cod + "'", datosEmpresa.strConxAdcom);
            if (rs.Read())
            {
                codigo = Conversions.ToString(rs["CTA_CODIGO"]);
                Nombre = Conversions.ToString(rs["CTA_NOMBRE"]);
                if (!Information.IsDBNull(rs["cta_grupo"]))
                    Grupo = Conversions.ToString(rs["cta_grupo"]);
                if (!Information.IsDBNull(rs["cta_agrupacion"]))
                    Agrupacion = Convert.ToBoolean(rs["cta_agrupacion"]);
                if (!Information.IsDBNull(rs["cta_tipopresu"]))
                    TipoPresu = Conversions.ToString(rs["cta_tipopresu"]);
                if (!Information.IsDBNull(rs["cta_claveseg"]))
                    ClaveSeg = Conversions.ToString(rs["cta_claveseg"]);
                if (!Information.IsDBNull(rs["cta_claveaux1"]))
                    ClaveAux1 = Conversions.ToString(rs["cta_claveaux1"]);
                if (!Information.IsDBNull(rs["cta_claveaux2"]))
                    ClaveAux2 = Conversions.ToString(rs["cta_claveaux2"]);
                if (!Information.IsDBNull(rs["cta_claveaux3"]))
                    ClaveAux3 = Conversions.ToString(rs["cta_claveaux3"]);
                if (!Information.IsDBNull(rs["cta_claveaux4"]))
                    ClaveAux4 = Conversions.ToString(rs["cta_claveaux4"]);
                if (!Information.IsDBNull(rs["ConceptoCompras"]))
                    ConceptoCompras = Conversions.ToShort(rs["ConceptoCompras"]);
                if (!Information.IsDBNull(rs["ConceptoVentas"]))
                    ConceptoVentas = Conversions.ToShort(rs["ConceptoVentas"]);
                if (!Information.IsDBNull(rs["ConceptoBcoEgreso"]))
                    ConceptoBcoEgreso = Conversions.ToShort(rs["ConceptoBcoEgreso"]);
                if (!Information.IsDBNull(rs["ConceptoBcoIngreso"]))
                    ConceptoBcoIngreso = Conversions.ToShort(rs["ConceptoBcoIngreso"]);
                if (!Information.IsDBNull(rs["CodigoAlterno"]))
                    CodigoAlterno = Conversions.ToString(rs["CodigoAlterno"]);
                if (!Information.IsDBNull(rs["Clasificadores"]))
                    Clasificadores = Conversions.ToString(rs["Clasificadores"]);
                if (!Information.IsDBNull(rs["cta_usuario"]))
                    usuario = Conversions.ToString(rs["cta_usuario"]);
                if (!Information.IsDBNull(rs["CuentaPadre"]))
                    CuentaPadre = Conversions.ToString(rs["CuentaPadre"]);
                if (!Information.IsDBNull(rs["Detalle"]))
                    Detalle = Conversions.ToString(rs["Detalle"]);
                if (!Information.IsDBNull(rs["FechaCierre"]))
                    FechaCierre = Conversions.ToDate(rs["FechaCierre"]);
                if (!Information.IsDBNull(rs["Estado"]))
                    Estado = Conversions.ToString(rs["Estado"]);
                if (!Information.IsDBNull(rs["Cta_Nivel"]))
                    Nivel = Conversions.ToShort(rs["Cta_Nivel"]);
                if (!Information.IsDBNull(rs["ModuloAuxiliar"]))
                    ModuloAuxiliar = Conversions.ToString(rs["ModuloAuxiliar"]);
                if (!Information.IsDBNull(rs["tipoCosto"]))
                    tipoCosto = Conversions.ToString(rs["tipoCosto"]);

                // Ccosto = (libdat.CorrijeNulo(.Fields("Cta_CCosto")) = "S")
                // EsGasto = libdat.CorrijeNuloN(.Fields("Cta_Gasto").Value = 1)
                // escosDirecto = libdat.CorrijeNuloN(.Fields("Cta_CostosDir").Value = 1)
                // esCosIndirecto = libdat.CorrijeNuloN(.Fields("Cta_CostosInDir").Value = 1)

            }

            rs.Close();
        }

        public bool Guardar()
        {
            var rs = new DataTable();
            string ssql = "";
            var da = new SqlDataAdapter("SELECT * FROM AdcCta WHERE Cta_codigo ='" + codigo + "'", datosEmpresa.strConxAdcom);
            da.Fill(rs);
            if (rs.Rows.Count == 0)
                rs.Rows.Add(rs.NewRow());
            var row = rs.Rows[0];
            row["CTA_CODIGO"] = Strings.Trim(codigo);
            row["CTA_NOMBRE"] = Strings.Trim(Nombre);
            row["cta_grupo"] = Grupo;
            row["cta_agrupacion"] = Agrupacion;
            row["cta_tipopresu"] = Strings.Trim(TipoPresu);
            row["cta_claveseg"] = Strings.Trim(ClaveSeg);
            row["cta_claveaux1"] = Strings.Trim(ClaveAux1);
            row["cta_claveaux2"] = Strings.Trim(ClaveAux2);
            row["cta_claveaux3"] = Strings.Trim(ClaveAux3);
            row["cta_claveaux4"] = Strings.Trim(ClaveAux4);
            row["Cta_Nivel"] = Nivel;
            row["cta_usuario"] = usuario;
            // !Cta_CCosto = (Ccosto)
            row["Cta_Gasto"] = EsGasto;
            row["Cta_CostosDir"] = escosDirecto;
            row["Cta_CostosInDir"] = esCosIndirecto;
            row["ConceptoCompras"] = ConceptoCompras;
            row["ConceptoVentas"] = ConceptoVentas;
            row["ConceptoBcoEgreso"] = ConceptoBcoEgreso;
            row["ConceptoBcoIngreso"] = ConceptoBcoIngreso;
            row["CodigoAlterno"] = CodigoAlterno;
            row["Clasificadores"] = Clasificadores;
            row["CuentaPadre"] = CuentaPadre;
            row["Detalle"] = Detalle;
            row["Estado"] = Estado;
            row["FechaCierre"] = "31/12/1900"; // FechaCierre
            row["ModuloAuxiliar"] = ModuloAuxiliar;
            row["tipoCosto"] = tipoCosto;
            var db = new SqlCommandBuilder(da);
            da.Update(rs);
            db.Dispose();
            da.Dispose();
            rs.Dispose();
            return default;
        }

        public bool BuscarCta(ref string cta)
        {
            bool BuscarCtaRet = default;
            SqlDataReader rs;
            rs = SqlDatos.leerBase("SELECT * FROM AdcCta WHERE Cta_Codigo='" + cta + "'", datosEmpresa.strConxAdcom);
            BuscarCtaRet = rs.Read();
            rs.Close();
            return BuscarCtaRet;
        }

        public bool GuardarCtaBco(ref string CodCta, ref string CodBco, ref string CodAlex, ref string nom, ref string numCta, ref string TipoCta, ref double Saldo, ref string fecha)
        {
            var rs = new DataTable();
            string ssql = "";
            var da = new SqlDataAdapter("SELECT * FROM AdcCtaBco WHERE Bco_Codigo='" + CodBco + "'", datosEmpresa.strConxAdcom);
            da.Fill(rs);
            if (rs.Rows.Count == 0)
                rs.Rows.Add(rs.NewRow());
            var row = rs.Rows[0];
            row["Bco_Codigo"] = Strings.Trim(CodBco);
            row["CTA_CODIGO"] = Strings.Trim(CodCta);
            row["Bco_CodAlex"] = Strings.Trim(CodAlex);
            row["Bco_Nombre"] = Strings.Trim(nom);
            row["Bco_NumCta"] = Strings.Trim(numCta);
            row["Bco_TipoCta"] = Strings.Trim(TipoCta);
            row["Bco_Saldo"] = Saldo;
            if (Information.IsDate(fecha))
                row["Bco_Fecha"] = fecha;
            var db = new SqlCommandBuilder(da);
            da.Update(rs);
            db.Dispose();
            da.Dispose();
            rs.Dispose();
            return default;
        }

        public double Saldo(ref string cta, ref bool SNSaldo, ref string QueTipoEs,  ref string Hasta,  ref string Desde,  ref short anioAnt)
        {
            double SaldoRet = default;
            // EL CAMPO SNSALDO ES CUANDO SEA SALDO O MOVIMIENTO, MOVIMIENTO DEVUELVE EL SALDO DE UN PERIODO
            // DETERMINADO
            // QueTipoEs, ESTA VARIABLE ES PARA SABER QUE TIPO DE DOCUMENTOS SE USARAN PARA EL SALDO
            // O OCULTOS
            // N NO OCULTOS
            // T TODOS
            // Dim daxlib As New DaxLib.DaxLibBases
            string cod;
            int Anio;
            short Mes;
            var fechaci = default(DateTime);
            double sal1;
            // Dim RsAux As ADODB.Recordset
            var ProCta = new Cuenta();
            short DeResultados;
            short anioAct;
            // Dim linkdat As New DaxData.DaxLibDatos
            var fechaIni = new DateTime();

            ProCta = new Cuenta();
            ProCta.Cargar(ref cta);
            DeResultados = (short)Math.Round(Conversion.Val(ProCta.Grupo));
            if (string.IsNullOrEmpty(Hasta))
                Hasta = Strings.FormatDateTime(DateAndTime.Today, (DateFormat)Convert.ToInt32("dd/mm/yyyy"));
            anioAct = (short)DateAndTime.Year(Conversions.ToDate(Hasta));
            if (anioAct > DateAndTime.Year(fechaci))
                Anio = DateAndTime.Year(fechaci);
            else
                Anio = anioAct;
            Mes = (short)DateAndTime.Month(fechaci);
            sal1 = 0d;
            try
            {
                fechaIni = Convert.ToDateTime(Desde);
            }
            catch (Exception ex)
            {
                fechaIni = DateAndTime.DateAdd(DateInterval.Day, 1d, fechaci);
            }

            if (SNSaldo == true)
            {
                if (DeResultados != 4)
                {
                    var RsAux = SqlDatos.leerBase("SELECT isnull(mov_saldebe,0) as debito, isnull(mov_salhaber,0) as credito FROM AdcCtaMov WHERE Cta_Codigo='" + cta + "' AND Mov_Fecha=" + Anio, datosEmpresa.strConxAdcom);
                    if (RsAux.Read())
                    {
                        sal1 = Convert.ToDouble(RsAux["debito"]) - Convert.ToDouble(RsAux["credito"]);
                    }

                    RsAux.Close();
                }
                else if (DateAndTime.Year(fechaIni) > DateAndTime.Year(fechaci))
                {
                    fechaIni = new DateTime(DateAndTime.Year(Conversions.ToDate(Hasta)), 1, 1);
                }
            }

            if (!Information.IsNothing(Hasta) & Conversions.ToDate(Hasta) > fechaci)
            {
                cod = "SELECT SUM(Dia_Valor * Dia_Signo) AS Val FROM AdcDia ";
                if (string.IsNullOrEmpty(Desde))
                {
                    cod += " WHERE Dia_Fecha<=" + Hasta;
                }
                else
                {
                    cod += " WHERE Dia_Fecha<=" + Hasta + " AND Dia_Fecha>=" + fechaIni.ToShortTimeString();
                }

                cod += " AND Left(Cta_Codigo," + Strings.Len(cta) + ")='" + cta + "'";
                var RsAux = SqlDatos.leerBase("SELECT isnull(mov_saldebe,0) as debito, isnull(mov_salhaber,0) as credito FROM AdcCtaMov WHERE Cta_Codigo='" + cta + "' AND Mov_Fecha=" + Anio, datosEmpresa.strConxAdcom);
                double valor = Conversion.Val(RsAux["Val"]);
                if (RsAux.Read())
                {
                    if (SNSaldo == true)
                    {
                        sal1 = sal1 + valor;
                    }
                    else
                    {
                        sal1 = valor;
                    }
                }

                RsAux.Close();
                RsAux.Dispose();
            }

            SaldoRet = sal1;
            return SaldoRet;
        }

        public double Utilidad(ref DateTime Hasta, ref bool SNSaldo, ref string QueTipoEs,  ref string Desde,  ref short anioAnt)
        {
            double UtilidadRet = default;
            string cod = "SELECT SUM(Dia_Valor * Dia_Signo) AS Val FROM AdcDia Left  join AdcCta on adccta.Cta_Codigo=adcdia.Cta_Codigo where Cta_Grupo='4' " + " ";
            if (Information.IsNothing(Desde))
            {
                cod += " AND Dia_Fecha<=" + Hasta.ToShortDateString();
            }
            else
            {
                cod += " AND Dia_Fecha<=" + Hasta.ToShortDateString() + " AND Dia_Fecha>=" + Desde;
            }

            QueTipoEs = "";
            var RsAux = SqlDatos.leerBase(cod, datosEmpresa.strConxAdcom);
            if (RsAux.Read())
            {
                try
                {
                    UtilidadRet = Math.Round(Conversions.ToDouble(RsAux["Val"]), emp.NumeroDigitos);
                }
                catch
                {
                    UtilidadRet = 0d;
                }
            }

            RsAux.Close();
            RsAux.Dispose();
            return UtilidadRet;
        }

        public string NombreCuentaContable(ref string codigo)
        {
            string NombreCuentaContableRet = default;
            string cod = "SELECT Cta_Codigo,Cta_Nombre FROM AdcCta WHERE Cta_Codigo='" + Strings.Trim(codigo) + "'";
            var RsAux = SqlDatos.leerBase(cod, datosEmpresa.strConxAdcom);
            if (RsAux.Read())
            {
                NombreCuentaContableRet = RsAux["CTA_NOMBRE"].ToString();
            }
            else
            {
                NombreCuentaContableRet = "";
            }

            RsAux.Close();
            RsAux.Dispose();
            return NombreCuentaContableRet;
        }

        public bool ValidarCuentaContable()
        {
            return default;
        }

        public short AbrirClasificadores(ref string[] ClasificadoresCol)
        {
            return default;
        }

        public void NombClasi(ref string[] NomClas)
        {
        }

        public string ModulosAuxiliares()
        {
            string ModulosAuxiliaresRet = default;
            string Aux = "";
            if (emp.Acf)
                Aux = "Activos Fijos;";
            Aux = Aux + "Anticipos Clientes";
            Aux = Aux + ";" + "Anticipos Proveedores";
            Aux = Aux + ";" + "CajaBancos";
            Aux = Aux + ";" + "Compras";
            Aux = Aux + ";" + "Cuentas Cobrar Clientes";
            Aux = Aux + ";" + "Cuentas Pagar Proveedores";
            if (emp.inv)
                Aux = Aux + ";" + "Inventarios";
            if (emp.rol)
                Aux = Aux + ";" + "Nómina";
            Aux = Aux + ";" + "Ventas";
            ModulosAuxiliaresRet = Aux;
            return ModulosAuxiliaresRet;
        }

        private void Main()
        {
            // On Error GoTo HayErrores
            // Dim Opcion As Short
            // Dim opc() As String
            // Dim tipo As Short
            // Dim daxlib As New DaxLibBases
            // CONEMP = New AdcDax.DaxSofSys
            // Emp = CONEMP.EmpresaAct
            // CONUSR = New DaxUsr.DaxsofUsr
            // ControlUsuario = CONUSR.UsuarioAct
            // Set ConxAdcom = New ADODB.Connection
            // ConxAdcom.ConnectionString = daxlib.StrAdcom '(Emp.NombreBaseAdcom, Emp.servidor, "", Emp.ClaveBD, Emp.UsuarioBd)
            // If ConxAdcom.State = 0 Then ConxAdcom.Open
            // Set ConxSysemp = New ADODB.Connection
            // ConxSysemp.ConnectionString = daxlib.StrDaxsys '("Daxsys", Emp.servidor, "", Emp.ClaveBD, Emp.UsuarioBd)
            // If ConxSysemp.State = 0 Then ConxSysemp.Open
            emp.autorizacion = emp.autorizacion;
            // Set daxlib = Nothing
            // Exit Sub
            // HayErrores:
            // MsgBox(" No se ha cargado BuscaCta correctamente" + Err.Description)
        }
    }
}