using System;
using System.Data;
using System.Data.SqlClient ;
using System.Text;

namespace daxConta
{

    public class reglCtb
    {
        public string strConxAdcom = "";
        public string strConxSyscod = "";
        public string empCodigo = "0";

        public string VerificarComodines(string CtaContable, string QueSucursal, string QueBeneficiario, string QueBodBan, string QueArtiServi, string BancoFin, string CXC, string Depar = "", string dESCUENTO = "", string CodSri = "")
        {
            string Verificado = CtaContable;
            Boolean esNumero = false;
            do
            {
                if (Verificado == "") break;
                Verificado = VerificacionDoble(Verificado, QueSucursal, QueBeneficiario, QueBodBan, QueArtiServi, BancoFin, CXC, Depar, dESCUENTO, CodSri);
                esNumero = IsNumeric(Verificado);
            } while (esNumero == false);
            return Verificado;
        }

        private string VerificacionDoble(string CtaContable, string QueSucursal, string QueBeneficiario, string QueBodBan, string QueArtiServi, string BancoFin, string CXC, string Depar = "", string dESCUENTO = "", string CodSri = "")
        {
            if (CtaContable == "") {return "";}
            
            string Cuenta = "";
            DataTable RecAux = new DataTable();
            Int32 j = 0;
            string par ="";
            string COMD ="";
            string Aux ="";
            string EsExcepcion ="";
            Int32 Y = CtaContable.IndexOf(";");
            if (Y > 0)
                {
                    EsExcepcion = CtaContable.Substring( Y + 1);
                    CtaContable = CtaContable.Substring(0, Y - 1);
                }
            do
            {
                    if (CtaContable.Substring (0, 1) == "&" )   // es comodin y verifica que cmodin es
                    {
                       COMD = CtaContable.Substring(1).ToUpper();
                       switch ( COMD)
                       {
 	 	 	 	 	 	case   "BANCO":
                              Cuenta = CtaBanco(QueBodBan);
                        break; 
 	 	 	 	 	 	case  "BANCOD":
                              Cuenta = CtaBanco(BancoFin);
                        break; 
 	 	 	 	 	 	case  "SUCURSAL":
                              Cuenta = CtaSucursal(QueSucursal);
                        break; 
 	 	 	 	 	 	case  "BODEGA":
                              Cuenta = CtaBodega(QueBodBan);
                        break; 
 	 	 	 	 	 	case  "BODEGAD":
                              Cuenta = CtaBodega(BancoFin);
                        break; 
 	 	 	 	 	 	case  "BENEFICIARIO":
                              if (CXC == "C") {
                                    Cuenta = CtasXcobrar(QueBeneficiario);}
                              else if (CXC == "P") {
                                    Cuenta = CtasXpagar(QueBeneficiario);}
                              else if (CXC == "T") {
                                    Cuenta = CtaBanco(BancoFin);}
                              else {Cuenta = "";}                              

                        break; 
 	 	 	 	 	 	case  "BENEFICIARIO2":
                              if (CXC == "C") {
                                    Cuenta = CtasXcobrar2(QueBeneficiario);}
                              else if (CXC == "P") {
                                    Cuenta = CtasXpagar2(QueBeneficiario);}
                              else if (CXC == "T") {
                                    Cuenta = CtaBanco(BancoFin);}
                              else {Cuenta = "";}                              
                        break; 
 	 	 	 	 	 	case  "CTAXCOBRAR":
                              Cuenta = CtasXcobrar(QueBeneficiario);
                           break; 
 	 	 	 	 	 	case  "CTAXCOBRAR2":
                              Cuenta = CtasXcobrar2(QueBeneficiario);
                           break; 
 	 	 	 	 	 	case  "CTAXPAGAR":
                              Cuenta = CtasXpagar(QueBeneficiario);
                           break; 
 	 	 	 	 	 	case  "CTAXPAGAR2":
                              Cuenta = CtasXpagar2(QueBeneficiario);
                           break; 
 	 	 	 	 	 	case  "EMPLEADO1":
                           break; 
 	 	 	 	 	 	case  "EMPLEADO":
                              Cuenta = CtasEmpleado1(QueBeneficiario);
                           break; 
 	 	 	 	 	 	case  "EMPLEADO2":
                              Cuenta = CtasEmpleado2(QueBeneficiario);
                         break; 
                        case  "EMPLEADO3":
                              Cuenta = CtasEmpleado3(QueBeneficiario);
                           break; 
 	 	 	 	 	 	case  "CATEGORIA":
                              Cuenta = CtaCategoria(QueArtiServi, 1);
                           break; 
 	 	 	 	 	 	case  "CATEGORIA2":
                              Cuenta = CtaCategoria(QueArtiServi, 2);
                           break; 
 	 	 	 	 	 	case  "CATEGORIA3":
                              Cuenta = CtaCategoria(QueArtiServi, 3);
                           break; 
 	 	 	 	 	 	case  "CATEGORIA4":
                              Cuenta = CtaCategoria(QueArtiServi, 4);
                           break;
                        case "ACFCATEGORIA":
                           Cuenta = CtaCategoriaAcf(QueArtiServi, 1);
                           break;
                        case "ACFCATEGORIA2":
                           Cuenta = CtaCategoriaAcf(QueArtiServi, 2);
                           break;
                        case "ACFCATEGORIA3":
                           Cuenta = CtaCategoriaAcf(QueArtiServi, 3);
                           break;
                        case "ACFCATEGORIA4":
                           Cuenta = CtaCategoriaAcf(QueArtiServi, 4);
                           break;
                        case "SERV-OTROS":
                              Cuenta = CtaServicios(QueArtiServi, 1);
                           break; 
 	 	 	 	 	 	case  "SERV-OTRO2":
                              Cuenta = CtaServicios(QueArtiServi, 2);
                           break; 
 	 	 	 	 	 	case  "SERV-OTRO3":
                              Cuenta = CtaServicios(QueArtiServi, 3);
                           break; 
 	 	 	 	 	 	case  "SERV-OTRO4":
                              Cuenta = CtaServicios(QueArtiServi, 4);
                           break; 
 	 	 	 	 	 	case  "DEPARTAMENTO":
                              Cuenta = CtaDepartamento(Depar, 1);
                           break; 
 	 	 	 	 	 	case  "DEPARTAMENTO2":
                              Cuenta = CtaDepartamento(Depar, 2);
                           break; 
 	 	 	 	 	 	case  "DEPARTAMENTO3":
                              Cuenta = CtaDepartamento(Depar, 3);
                           break; 
 	 	 	 	 	 	case  "DEPARTAMENTO4":
                              Cuenta = CtaDepartamento(Depar, 4);
                           break; 
 	 	 	 	 	 	case  "DESCUENTO1":
                              Cuenta = CtaDescuentos(dESCUENTO, 1);
                           break; 
 	 	 	 	 	 	case  "DESCUENTO2":
                              Cuenta = CtaDescuentos(dESCUENTO, 2);
                           break; 
 	 	 	 	 	 	case  "RETENCIONFTE1":
                              Cuenta = CtaRetencionFte(CodSri, 1);
                           break; 
 	 	 	 	 	 	case  "RETENCIONFTE2":
                              Cuenta = CtaRetencionFte(CodSri, 2);
                           break; 
 	 	 	 	 	 	case  "RETENIVABIEN1":
                              Cuenta = CtaRetencionIvaBien(CodSri, 1);
                           break; 
 	 	 	 	 	 	case  "RETENIVABIEN2":
                              Cuenta = CtaRetencionIvaBien(CodSri, 2);
                           break; 
 	 	 	 	 	 	case  "RETENIVASERV1":
                              Cuenta = CtaRetencionIvaServ(CodSri, 1);
                           break; 
 	 	 	 	 	 	case  "RETENIVASERV2":
                              Cuenta = CtaRetencionIvaServ(CodSri, 2);
                           break; 
                        default:
                              Cuenta = "999";
                               break;
                       }
                   }
                   else
                    {
                         Cuenta = CtaContable;
                    }
                if (Cuenta == "") return "9999";
                    if (IsNumeric(Cuenta) || Cuenta.Substring(0, 1) == "&") return  Cuenta;
                    
                    string AuxAnt="";
                    j = -1;
                    for (int I = Cuenta.Length - 1 ;I>-1 ;I--)
                    {
                        Aux = Cuenta.Substring( I, 1);
 	 	 	 	 	 	switch ( Aux )
                        {
                            case  "S":
                                  if (j == -1 || Aux != AuxAnt) 
                                  { 
                                    par = CtaSucursal(QueSucursal); 
                                    if (par == "") {par = "99999";}
                                    j = par.Length - 1;
                                    AuxAnt=Aux;
                                  }
                                  if (j > -1) 
                                  { 
                                    Cuenta = Cuenta.Substring(0,I) + par.Substring( j, 1) + Cuenta.Substring(I+1);
                                    j = j - 1;
                                  }
                            break; 
                            case  "B":
                                  if (j == -1 || Aux != AuxAnt ) 
                                  { 
                                    par = CtaBodega(QueBodBan);
                                    if (par == "") {par = "99999";}
                                    j = par.Length - 1;
                                    AuxAnt=Aux;
                                  }
                                  if (j > -1) 
                                  { 
                                    Cuenta = Cuenta.Substring(0,I) + par.Substring( j, 1) + Cuenta.Substring(I+1);
                                    j = j - 1;
                                  }
                                  break; 
                            case  "C":
                                  if (j == -1 || Aux != AuxAnt ) 
                                  { 
                                    par = CtasXcobrar(QueBeneficiario);
                                    if (par == "") {par = "99999";}
                                    j = par.Length - 1;
                                    AuxAnt=Aux;
                                  }
                                  if (j > -1) 
                                  { 
                                    Cuenta = Cuenta.Substring(0,I) + par.Substring( j, 1) + Cuenta.Substring(I+1);
                                    j = j - 1;
                                  }
                                  break; 
                            case  "F":
                                  if (j == -1 || Aux != AuxAnt ) 
                                  { 
                                    par = CtasXcobrar(QueBeneficiario);
                                    if (par == "") {par = "99999";}
                                    j = par.Length - 1;
                                    AuxAnt=Aux;
                                  }
                                  if (j > -1) 
                                  { 
                                    Cuenta = Cuenta.Substring(0,I) + par.Substring( j, 1) + Cuenta.Substring(I+1);
                                    j = j - 1;
                                  }
                                  break; 
                            case  "P":
                                  if (j == -1 || Aux != AuxAnt ) 
                                  { 
                                    par = CtasXpagar(QueBeneficiario);
                                    if (par == "") {par = "99999";}
                                    j = par.Length - 1;
                                    AuxAnt=Aux;
                                  }
                                  if (j > -1) 
                                  { 
                                    Cuenta = Cuenta.Substring(0,I) + par.Substring( j, 1) + Cuenta.Substring(I+1);
                                    j = j - 1;
                                  }
                                  break; 
                            case  "T":
                                  if (j == -1 || Aux != AuxAnt ) 
                                  { 
                                    par = CtaCategoria(QueArtiServi);
                                    if (par == "") {par = "99999";}
                                    j = par.Length - 1;
                                    AuxAnt=Aux;
                                  }
                                  if (j > -1) 
                                  { 
                                    Cuenta = Cuenta.Substring(0,I) + par.Substring( j, 1) + Cuenta.Substring(I+1);
                                    j = j - 1;
                                  }
                                  break; 
                            case  "O":
                                  if (j == -1 || Aux != AuxAnt ) 
                                  { 
                                    par = CtaServicios(QueArtiServi);
                                    if (par == "") {par = "99999";}
                                    j = par.Length - 1;
                                    AuxAnt=Aux;
                                  }
                                  if (j > -1) 
                                  { 
                                    Cuenta = Cuenta.Substring(0,I) + par.Substring( j, 1) + Cuenta.Substring(I+1);
                                    j = j - 1;
                                  }
                                  break; 
                            case  "D":
                                  if (j == -1 || Aux != AuxAnt ) 
                                  { 
                                    par = CtaDepartamento(Depar);
                                    if (par == "") {par = "99999";}
                                    j = par.Length - 1;
                                    AuxAnt=Aux;
                                  }
                                  if (j > -1) 
                                  { 
                                    Cuenta = Cuenta.Substring(0,I) + par.Substring( j, 1) + Cuenta.Substring(I+1);
                                    j = j - 1;
                                  }
                                  break; 
                        }
                    }
                    if (Cuenta != "" && !IsNumeric(Cuenta)) { Cuenta = ""; }
                    if (EsExcepcion != "" && Cuenta == "") { Y = 0; CtaContable = EsExcepcion; } else { Y = 999; }
            } while (Y != 999);
            return Cuenta;
        }

        private string CtaBanco(string Banco)
        {
            DataTable RecAux = new DataTable();
            string aux = "";
            RecAux = tabla("Select CTA_CODIGO from adcctabco where bco_codigo = '" + Banco + "'", strConxAdcom);
            if (RecAux.Rows.Count > 0) { aux = RecAux.Rows[0]["CTA_CODIGO"].ToString(); }
            return aux;
        }

        private string CtaSucursal(string Suc)
        {
            DataTable RecAux = new DataTable();
            string aux = "";
            RecAux = tabla("Select Suc_IdCta from emp_suc where suc_codigo = '" + Suc + "' AND emp_Codigo = " + empCodigo, strConxSyscod);
            if (RecAux.Rows.Count > 0) { aux = RecAux.Rows[0]["Suc_IdCta"].ToString(); }
            return aux;
        }

        private string CtaBodega(string Bod)
        {
            DataTable RecAux = new DataTable();
            string aux = "";
            RecAux = tabla("Select Bod_IdCta from EMP_bod where bod_codigo = '" + Bod + "' and emp_Codigo = " + empCodigo, strConxSyscod);
            if (RecAux.Rows.Count > 0) { aux = RecAux.Rows[0]["Bod_IdCta"].ToString(); }
            return aux;
        }

        private string CtasXcobrar(string codigo)
        {
            DataTable RecAux = new DataTable();
            string aux = "";
            RecAux = tabla("Select ctbcobrar from cliente where codigocli = '" + codigo + "' ", strConxAdcom);
            if (RecAux.Rows.Count > 0) { aux = RecAux.Rows[0]["ctbcobrar"].ToString(); }
            return aux;
        }

        private string CtasXcobrar2(string codigo)
        {
            DataTable RecAux = new DataTable();
            string aux = "";
            RecAux = tabla("Select ctbcobrar2 from cliente where codigocli = '" + codigo + "' ", strConxAdcom);
            if (RecAux.Rows.Count > 0) { aux = RecAux.Rows[0]["ctbcobrar2"].ToString(); }
            return aux;
        }

        private string CtasEmpleado1(string codigo)
        {
            DataTable RecAux = new DataTable();
            string aux = "";
            RecAux = tabla("Select [CtbRol(0)] from Empleado where codigoempleado = '" + codigo + "' ", strConxAdcom);
            if (RecAux.Rows.Count > 0) { aux = RecAux.Rows[0][0].ToString(); }
            return aux;
        }

        private string CtasEmpleado2(string codigo)
        {
            DataTable RecAux = new DataTable();
            string aux = "";
            RecAux = tabla("Select [CtbRol(2)] from Empleado where codigoempleado = '" + codigo + "' ", strConxAdcom);
            if (RecAux.Rows.Count > 0) { aux = RecAux.Rows[0][0].ToString(); }
            return aux;
        }

        private string CtasEmpleado3(string codigo)
        {
            DataTable RecAux = new DataTable();
            string aux = "";
            RecAux = tabla("Select [CtbRol(3)] from Empleado where codigoempleado = '" + codigo + "' ", strConxAdcom);
            if (RecAux.Rows.Count > 0) { aux = RecAux.Rows[0][0].ToString(); }
            return aux;
        }

        private string CtasXpagar(string codigo)
        {
            DataTable RecAux = new DataTable();
            string aux = "";
            RecAux = tabla("Select ctbproveedor from proveedor where codigoproveedor = '" + codigo + "' ", strConxAdcom);
            if (RecAux.Rows.Count > 0) { aux = RecAux.Rows[0][0].ToString(); }
            return aux;
        }

        private string CtasXpagar2(string codigo)
        {
            DataTable RecAux = new DataTable();
            string aux = "";
            RecAux = tabla("Select ctbproveedor2 from proveedor where codigoproveedor = '" + codigo + "' ", strConxAdcom);
            if (RecAux.Rows.Count > 0) { aux = RecAux.Rows[0][0].ToString(); }
            return aux;
        }

        private string CtaCategoria(string codigo, int Cual = 0)
        {
            DataTable RecAux = new DataTable();
            string aux = "";
            string ssql = "SELECT AdcNiv.Niv_IdCta, AdcNiv.Niv_Idcta2, AdcNiv.Niv_Idcta3";
            ssql += " FROM AdcArt LEFT OUTER JOIN AdcNiv ON AdcArt.Art_categor = AdcNiv.Niv_categor ";
            ssql += "where art_codigo = '" + codigo + "' ";
            RecAux = tabla(ssql, strConxAdcom);
            if (RecAux.Rows.Count > 0)
            {
                if (Cual == 2) { aux = RecAux.Rows[0]["Niv_IdCta2"].ToString(); }
                else if (Cual == 3) { aux = RecAux.Rows[0]["Niv_IdCta3"].ToString(); }
                else if (Cual == 4) { aux = RecAux.Rows[0]["Niv_IdCta4"].ToString(); }
                else { aux = RecAux.Rows[0]["Niv_IdCta"].ToString(); }
            }
            else { aux = "9999"; }
            return aux;
        }
        private string CtaCategoriaAcf(string codigo, int Cual = 0)
        {
            DataTable RecAux = new DataTable();
            string aux = "";
            string ssql = "SELECT AdcNivAcf.Niv_IdCta, AdcNivAcf.Niv_Idcta2, AdcNivAcf.Niv_Idcta3";
            ssql += " from AdcACF left join AdcNivAcf ON AdcAcf.categoria = AdcNivAcf.Niv_abrevia  ";
            ssql += "where adcacf.codigo = '" + codigo + "' ";
            RecAux = tabla(ssql, strConxAdcom);
            if (RecAux.Rows.Count > 0)
            {
                if (Cual == 2) { aux = RecAux.Rows[0]["Niv_IdCta2"].ToString(); }
                else if (Cual == 3) { aux = RecAux.Rows[0]["Niv_IdCta3"].ToString(); }
                else if (Cual == 4) { aux = RecAux.Rows[0]["Niv_IdCta4"].ToString(); }
                else { aux = RecAux.Rows[0]["Niv_IdCta"].ToString(); }
            }
            else { aux = "9999"; }
            return aux;
        }

        private string CtaDescuentos(string codigo, int Cual = 0)
        {
            DataTable RecAux = new DataTable();
            string aux = "";
            string ssql = "Select * from descpromo where DES_NOMBRE = '" + codigo + "' ";
            RecAux = tabla(ssql, strConxAdcom);
            if (RecAux.Rows.Count > 0)
            {
                if (Cual == 2) { aux = RecAux.Rows[0]["Des_IdCta2"].ToString(); }
                else { aux = RecAux.Rows[0]["Des_IdCta"].ToString(); }
            }
            return aux;
        }

        private string CtaServicios(string codigo, int Cual = 0)
        {
            DataTable RecAux = new DataTable();
            string aux = "";
            string ssql = "Select * from adcserv where sev_codigo = '" + codigo + "' ";
            RecAux = tabla(ssql, strConxAdcom);
            if (RecAux.Rows.Count > 0)
            {
                if (Cual == 2) { aux = RecAux.Rows[0]["seV_idcta2"].ToString(); }
                else if (Cual == 3) { aux = RecAux.Rows[0]["seV_idcta3"].ToString(); }
                else if (Cual == 4) { aux = RecAux.Rows[0]["seV_idcta4"].ToString(); }
                else { aux = RecAux.Rows[0]["seV_idcta"].ToString(); }
            }
            return aux;
        }

        private string CtaRetencionFte(string CodSri, int Cual)
        {
            return CargarCuentasRetencion(CodSri, Cual, "CONCEPTOSRETENCION");
        }

        private string CtaRetencionIvaBien(string CodSri, int Cual)
        {
            return CargarCuentasRetencion(CodSri, Cual, "RETENCIONIVABIENES");
        }

        private string CtaRetencionIvaServ(string CodSri, int Cual)
        {
            return CargarCuentasRetencion(CodSri, Cual, "RETENCIONIVASERVICIOS");
        }

        private string CargarCuentasRetencion(string CodSri, int Cual, string qtabla)
        {
            DataTable RecAux = new DataTable();
            string aux = "";

            string codigo = CodSri;
            //long Porcentaje = 0;
            string ssql = "Select idcontable1,idcontable2 from ADCSRICTB where ";
            ssql += " tabla = '" + qtabla + "'";
            ssql += " and codigo = '" + codigo + "'";
            ssql += " and (idcontable1 > '' or idcontable2 > '') ";

            RecAux = tabla(ssql, strConxAdcom);

            if (RecAux.Rows.Count > 0)
            {
                if (Cual == 2) { aux = RecAux.Rows[0]["idContable2"].ToString(); }
                else { aux = RecAux.Rows[0]["idcontable1"].ToString(); }
            }
            return aux;
        }

        private string CtaDepartamento(string codigo, int Cual = 0)
        {
            DataTable RecAux = new DataTable();
            string aux = "";
            RecAux = tabla("Select * from syscod where TipoReferencia = 'Departamento' and Abreviación = '" + codigo + "' ", strConxSyscod);
            if (RecAux.Rows.Count > 0)
            {
                if (Cual == 2) { aux = RecAux.Rows[0]["Caracteristica2"].ToString(); }
                else if (Cual == 3) { aux = RecAux.Rows[0]["Caracteristica3"].ToString(); }
                else if (Cual == 4) { aux = RecAux.Rows[0]["Caracteristica4"].ToString(); }
                else { aux = RecAux.Rows[0]["Caracteristica1"].ToString(); }
            }
            return aux;
        }

        //Public Function SaldoContable(cta As String, Debe As Double, Haber As Double, Optional Hasta, Optional Desde, Optional anioAnt) As Double
        //    'EL CAMPO SNSALDO ES CUANDO SEA SALDO O MOVIMIENTO, MOVIMIENTO DEVUELVE EL SALDO DE UN PERIODO
        //    'DETERMINADO
        //    'QueTipoEs, ESTA VARIABLE ES PARA SABER QUE TIPO DE DOCUMENTOS SE USARAN PARA EL SALDO
        //    'O OCULTOS
        //    'N NO OCULTOS
        //    'T TODOS
        //    Dim cod As String
        //    Dim Anio As Long
        //    Dim sal1 As Double
        //    Dim RsAux As ADODB.Recordset
        //    Dim Fec As String
        //    Set RsAux = New ADODB.Recordset
        //    'verifico el saldo del año anterior
        //    If cta = "" Then SaldoContable = 0: Exit Function
        //    If Not IsDate(Hasta) Then Hasta = Date
        //    If IsMissing(Desde) Then Desde = DateAdd("d", 1, Emp.ConUltAnu)

        //    If IsMissing(anioAnt) Then
        //        If Desde = "" Then Fec = Hasta Else Fec = Desde
        //        Anio = Year(CDate(Fec)) - 1
        //        cod = "SELECT * FROM AdcCtaMov WHERE Cta_Codigo='" + cta + "' AND Mov_Fecha=" + Anio
        //    Else
        //        cod = "SELECT * FROM AdcCtaMov WHERE Cta_Codigo='" + cta + "' AND Mov_Fecha=" + anioAnt
        //    End If
        //    RsAux.Open cod, ConxAdcom, adOpenKeyset, adLockOptimistic
        //    If RsAux.EOF = False Then
        //        sal1 = libdat.CorrijeNuloN(RsAux!Mov_Saldebe) - libdat.CorrijeNuloN(RsAux!Mov_Salhaber)
        //    Else
        //        sal1 = 0
        //    End If
        //    RsAux.Close
        //    If Not IsMissing(Hasta) Then
        //        'verifico que saldo hasta la fecha de inicio

        //        Set RsAux = New ADODB.Recordset
        //        cod = "SELECT SUM(i.Dia_Valor * i.Dia_Signo) AS Val, SUM(i.Dia_Valor * ((i.dia_signo + 1)/2)) AS TotDebitos,SUM(i.Dia_Valor * ((i.dia_signo - 1)/-2)) AS TotCreditos FROM AdcDia i ,AdcDoc d " + _
        //        "WHERE i.Opc_Documento=d.Opc_Documento AND i.Doc_Sucursal=d.Doc_Sucursal AND i.Doc_Numero=d.Doc_Numero "
        //        If Desde = "" Then
        //            cod = cod + " AND i.Dia_Fecha<=" + libfec.ArmFormatoFecha(CStr(Hasta))
        //        Else
        //            cod = cod + " AND i.Dia_Fecha<=" + libfec.ArmFormatoFecha(CStr(Hasta)) + " AND i.Dia_Fecha>=" + libfec.ArmFormatoFecha(CStr(Desde))
        //        End If

        //        cod = cod + " AND LEFT$(i.Cta_Codigo," + Len(cta) + ")='" + cta + "'"
        //        RsAux.Open cod, ConxAdcom, adOpenKeyset, adLockOptimistic

        //        If RsAux.EOF = False And Not IsNull(RsAux!val) Then
        //                sal1 = sal1 + RsAux!val
        //                Debe = RsAux!TotDebitoS
        //                Haber = RsAux!TotCreditoS
        //        End If
        //        RsAux.Close
        //    End If
        //    SaldoContable = sal1
        //End Function

        public string QuePadreDeCta(string CodCta, int CtaNivel, string ctaNumDigNivel)
        {
            int Lim = 0;
            if (CtaNivel == 1) { return ""; }
            try
            {
                for (int I = 1; I < CtaNivel - 1; I++)
                {
                    Lim += Convert.ToInt16(ctaNumDigNivel.Substring(I - 1, 1));
                }
            }
            catch { };
            return CodCta.Substring(0, Lim);
        }


        //'Private Sub VerificaDistribuirCostos(mallactb As MSFlexGrid, DocSucursal As String, DocTipo As String, DocNumero As Double, aumento As Integer)
        //'Dim rs As New ADODB.Recordset
        //'Dim i As Long, j As Long
        //'Dim CuentaSer As New servicios
        //'Dim CuentaDes As New DirectorioAlex
        //'on error Resume Next
        //'rs.Open "Select * from adcctacos where Cos_DocSuc = '" + DocSucursal + "' and Cos_DocTipo = '" + DocTipo + "' and Cos_DocNum = " + DocNumero + " ", ConxAdcom, adOpenDynamic, adLockOptimistic
        //'If rs.State = 0 Then Exit Sub
        //'If rs.EOF Then rs.Close: Exit Sub
        //'
        //'
        //'With mallactb
        //'Do Until rs.EOF
        //'If mallactb.Cols < 7 Then mallactb.Cols = 7
        //'    CuentaSer.CARGAR rs!cos_servicio
        //'    CuentaDes.CargarAlex rs!cos_destino, True
        //'    .Rows = .Rows + 1
        //'    j = .Rows - 1
        //'    .TextMatrix(j, 0) = j + aumento
        //'    .TextMatrix(j, 1) = CuentaSer.IdContable
        //'    .TextMatrix(j, 2) = BuscarCta(CuentaSer.IdContable)
        //'    .TextMatrix(j, 3) = "Dist.Cst." + DocTipo + "-" + DocNumero + " " + CuentaDes.Nombreimpresion
        //'    .TextMatrix(j, 4) = rs!cos_valor
        //'    .TextMatrix(j, 5) = 0
        //'    .TextMatrix(j, 6) = CuentaDes.codigo
        //'rs.MoveNext
        //'Loop
        //'rs.Close
        //'mallactb.ColWidth(6) = 0
        //'End With
        //'
        //'End Sub

        //Private Function BuscarCta(CtaCtb As String, ByRef CtaCosto As String) As String
        //Dim Rs As New ADODB.Recordset
        // On Error Resume Next
        //CtaCosto = ""
        //Rs.Open "SELECT ISNULL(CTA_NOMBRE,'') AS CTA_NOMBRE,ISNULL(CLASIFICADORES,'') AS CLASIFICADORES FROM AdcCta WHERE Cta_Codigo='" + CtaCtb + "' and cta_agrupacion = 0 ", ConxAdcom, adOpenKeyset, adLockOptimistic
        //If Rs.EOF Then BuscarCta = "No existe la cuenta" Else BuscarCta = Rs!CTA_NOMBRE: CtaCosto = Rs!Clasificadores
        //Rs.Close
        //Set Rs = Nothing
        //End Function

        //Public Function RetornaCta(cta As String, Optional Suc, Optional Bod, Optional ART) As String
        //    Dim cont As Integer: cont = 1
        //    Dim cod As String
        //    Dim RsAux As New ADODB.Recordset
        //    Do While cont <= Len(cta)
        //        If Mid$(cta, cont, 1) = "S" Then
        //            cod = "SELECT Suc_IdCta FROM Suc WHERE Suc_Codigo='" + Suc + "' AND empCodigo=" + empCodigo
        //            RsAux.Open cod, strConxSyscod, adOpenKeyset, adLockOptimistic
        //            cta = PonerEnCta(cta, cont, "S", RsAux!Suc_IdCta)
        //            RsAux.Close
        //        ElseIf Mid$(cta, cont, 1) = "B" Then
        //            cod = "SELECT Bod_IdCta FROM Bod WHERE Suc_Codigo='" + Suc + "' AND Bod_Codigo='" + Bod + "' AND empCodigo=" + empCodigo
        //            RsAux.Open cod, strConxSyscod, adOpenKeyset, adLockOptimistic
        //            cta = PonerEnCta(cta, cont, "B", RsAux!Bod_IdCta)
        //            RsAux.Close
        //        ElseIf Mid$(cta, cont, 1) = "C" Then
        //            cod = "SELECT n.Niv_IdCta FROM AdcArt a,AdcNiv n WHERE n.Niv_Abrevia=a.Art_Categor AND a.Art_Codigo='" + ART + "'"
        //            RsAux.Open cod, ConxAdcom, adOpenKeyset, adLockOptimistic
        //            cta = PonerEnCta(cta, cont, "C", RsAux!Niv_IdCta)
        //            RsAux.Close
        //        End If
        //        cont = cont + 1
        //    Loop
        //    RetornaCta = cta
        //End Function

        //Public Function PonerPtosCtas(cta As String) As String
        //    Dim I As Long
        //    Dim OrgNiv() As Integer
        //    Dim cont As Integer
        //    Emp.CtaNumNiveles = 6
        //    ReDim OrgNiv(Emp.CtaNumNiveles)

        //    For I = 1 To Emp.CtaNumNiveles
        //        OrgNiv(I) = val(Mid$(Emp.CtaNumDigNivel, I, 1))
        //    Next
        //    'pongo los valores para saber de que largo debe ser la cadena para cambiar de nivel
        //    OrgNiv(2) = OrgNiv(1) + OrgNiv(2)
        //    OrgNiv(3) = OrgNiv(2) + OrgNiv(3)
        //    OrgNiv(4) = OrgNiv(3) + OrgNiv(4)
        //    OrgNiv(5) = OrgNiv(4) + OrgNiv(5)
        //    OrgNiv(6) = OrgNiv(5) + OrgNiv(6)
        //    cont = 0
        //    For I = 3 To Emp.CtaNumNiveles
        //        If Len(cta) - cont > OrgNiv(I) Then
        //            cta = Mid$(cta, 1, OrgNiv(I) + cont) + "." + Mid$(cta, OrgNiv(I) + cont + 1)
        //            cont = cont + 1

        //        End If
        //    Next
        //    PonerPtosCtas = cta
        //End Function

        //Private Function PonerEnCta(cta As String, Ini As Integer, Tipo As String, val As String) As String
        //    Dim cont As Integer
        //    Dim Temp As String
        //    Dim Aux As Integer, I As Integer
        //    cont = Ini
        //    Do While Mid$(cta, cont, 1) = Tipo
        //        cont = cont + 1
        //    Loop
        //    'esto es para cuando las letras en la cta es mas grande o menor que el IdCta
        //    If cont - Ini < Len(val) Then
        //        Aux = Len(val) - cont
        //        'le agrando al IdCta aliniandole a la derecha
        //        For I = 1 To Aux
        //            val = "0" + val
        //        Next
        //    ElseIf cont - Ini > Len(val) Then
        //        Aux = cont - Len(val)
        //        val = Mid$(val, Len(val) - Aux + 1, Aux)
        //    End If
        //    PonerEnCta = Mid$(cta, 1, Ini - 1) + val + Mid$(cta, cont, Len(cta) - cont + 1)
        //End Function

        //Private Function EsClasificador(ByVal Cuenta As String, ByRef clasificador As String, Optional ByVal ValClasificador As String) As Boolean
        //Dim Rs As New ADODB.Recordset
        //Dim a As Integer
        //Dim ssql As String
        //EsClasificador = False
        //If Cuenta = "" Then Exit Function
        //If clasificador = "" And ValClasificador > "" Then
        //    If ValClasificador = ValclasAnt Then EsClasificador = True: clasificador = ClasAnt: Exit Function
        //    ssql = "select isnull(tiporeferencia,'') as Clasificad from syscod"
        //    ssql = ssql + " left join AdcClasfctb"
        //    ssql = ssql + " on syscod.TipoReferencia = adcclasfctb.nombre"
        //    ssql = ssql + " where abreviación = '" + ValClasificador + "' or descripcion = '" + ValClasificador + "' and esclasificador =1"
        //    Rs.Open ssql, ConxAdcom, adOpenForwardOnly, adLockReadOnly
        //    If Rs.EOF = False Then
        //        clasificador = Rs!Clasificad
        //    End If
        //    Rs.Close
        //End If
        //If clasificador = "" Then Exit Function
        //Set Rs = New ADODB.Recordset
        //Rs.Open "SELECT isnull(CLASIFICADORES,'') as clasificadores FROM ADCCTA WHERE CTA_CODIGO = '" + Cuenta + "' ", ConxAdcom, adOpenForwardOnly, adLockReadOnly
        //If Rs!Clasificadores > "" Then
        //    a = InStr(1, Rs!Clasificadores, clasificador)
        //Else
        //    a = 0
        //End If
        //If a > 0 Then EsClasificador = True Else EsClasificador = False
        //Rs.Close
        //Set Rs = Nothing
        //End Function


        private Boolean IsNumeric(string valor)
        {
            try
            {
                Int64 numero = Convert.ToInt64(valor);
                return true;
            }
            catch { return false; }
        }

        private DataTable tabla(string ssql, string strconx)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(ssql, strconx);
            da.Fill(dt);
            return dt;
        }
    }
}
