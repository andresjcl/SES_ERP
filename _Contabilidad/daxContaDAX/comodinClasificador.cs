using System;
using System.Data;
using System.Data.SqlClient ;
using System.Windows.Forms;
using sesClasif;
using DattCom;
using DaxClasificadores;

namespace daxConta
{

    public class reglCtb
    {
        //public string strConxAdcom = "";
        //public string strConxSyscod = "";
        public string empCodigo = "0";
       
        public string VerificarComodines(string CtaContable, string QueSucursal,string PuntoVta, string QueBeneficiario, string QueBodBan, string QueArtiServi, string BancoFin, string CXC, string Depar = "", string dESCUENTO = "", string CodSri = "", string codPago = "")
        {
            string Verificado = CtaContable;
            Boolean esNumero = false;
            do
            {

                if (Verificado == "") break;
                Verificado = VerificacionDoble(Verificado, QueSucursal, PuntoVta ,QueBeneficiario, QueBodBan, QueArtiServi, BancoFin, CXC, Depar, dESCUENTO, CodSri,codPago);
                esNumero = IsNumeric(Verificado);

            } while (esNumero == false);
            return Verificado;
        }

        private string VerificacionDoble(string CtaContable, string QueSucursal,string QuePuntoVta, string QueBeneficiario, string QueBodBan, string QueArtiServi, string BancoFin, string CXC, string Depar = "", string dESCUENTO = "", string CodSri = "",string codPago="")
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
                        case "PTOVTA":
                            Cuenta = CtaPuntoDeVenta(QueSucursal,QuePuntoVta);
                        break;
                        case "BODEGA":
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
                        case "PAGOS":
                            Cuenta = ctaPago(CodSri, 1);
                            break;
                        case "PAGOS2":
                            Cuenta = ctaPago(CodSri, 2);
                            break;
                        default:
                              Cuenta = "999999";
                               break;
                       }
                   }
                   else
                    {
                         Cuenta = CtaContable;
                    }
                if (Cuenta == "") return "999999";
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
                                    if (par == "") {par = "999999";}
                                    j = par.Length - 1;
                                    AuxAnt=Aux;
                                  }
                                  if (j > -1) 
                                  { 
                                    Cuenta = Cuenta.Substring(0,I) + par.Substring( j, 1) + Cuenta.Substring(I+1);
                                    j = j - 1;
                                  }
                            break;
                        case "V":
                            if (j == -1 || Aux != AuxAnt)
                            {
                                par = CtaPuntoDeVenta(QueSucursal,QuePuntoVta);
                                if (par == "") { par = "999999"; }
                                j = par.Length - 1;
                                AuxAnt = Aux;
                            }
                            if (j > -1)
                            {
                                Cuenta = Cuenta.Substring(0, I) + par.Substring(j, 1) + Cuenta.Substring(I + 1);
                                j = j - 1;
                            }
                            break;
                        case "B":
                                  if (j == -1 || Aux != AuxAnt ) 
                                  { 
                                    par = CtaBodega(QueBodBan);
                                    if (par == "") {par = "999999";}
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
                                    if (par == "") {par = "999999";}
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
                                    if (par == "") {par = "999999";}
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
                                    if (par == "") {par = "999999";}
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
                                    if (par == "") {par = "999999";}
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
                                    if (par == "") {par = "999999";}
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
                                    if (par == "") {par = "999999";}
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
                EsExcepcion = "";
            } while (Y != 999);
            return Cuenta;
        }

        private string CtaBanco(string Banco)
        {
            DataTable RecAux = new DataTable();
            string aux = "";
            RecAux = SqlDatos.leerTablaAdcom("Select CTA_CODIGO from adcctabco where bco_codigo = '" + Banco + "'");
            if (RecAux.Rows.Count > 0) { aux = RecAux.Rows[0]["CTA_CODIGO"].ToString(); }
            return aux;
        }

        private string CtaSucursal(string Suc)
        {
            DataTable RecAux = new DataTable();
            string aux = "";
            RecAux = SqlDatos.leerTablaIniSis("Select Suc_IdCta from emp_suc where suc_codigo = '" + Suc + "' AND emp_Codigo = " + empCodigo);
            if (RecAux.Rows.Count > 0) { aux = RecAux.Rows[0]["Suc_IdCta"].ToString(); }
            return aux;
        }

        private string CtaPuntoDeVenta(string Suc,string PtoVta)
        {
            DataTable RecAux = new DataTable();
            string aux = "";
            RecAux = SqlDatos.leerTablaIniSis("Select Pto_IdCta from emp_ptovta where pto_Nombre = '" + PtoVta + "' and SucCodigo = '"+ Suc + "' AND emp_Codigo = " + empCodigo);
            if (RecAux.Rows.Count > 0) { aux = RecAux.Rows[0]["Pto_IdCta"].ToString(); }
            return aux;
        }
        private string CtaBodega(string Bod)
        {
            DataTable RecAux = new DataTable();
            string aux = "";
            RecAux = SqlDatos.leerTablaIniSis("Select Bod_IdCta from EMP_bod where bod_codigo = '" + Bod + "' and emp_Codigo = " + empCodigo);
            if (RecAux.Rows.Count > 0) { aux = RecAux.Rows[0]["Bod_IdCta"].ToString(); }
            return aux;
        }

        private string CtasXcobrar(string codigo)
        {
            DataTable RecAux = new DataTable();
            string aux = "";
            RecAux = SqlDatos.leerTablaAdcom("Select ctbcobrar from cliente where codigocli = '" + codigo + "' ");
            if (RecAux.Rows.Count > 0) { aux = RecAux.Rows[0]["ctbcobrar"].ToString(); }
            return aux;
        }

        private string CtasXcobrar2(string codigo)
        {
            DataTable RecAux = new DataTable();
            string aux = "";
            RecAux = SqlDatos.leerTablaAdcom("Select ctbcobrar2 from cliente where codigocli = '" + codigo + "' ");
            if (RecAux.Rows.Count > 0) { aux = RecAux.Rows[0]["ctbcobrar2"].ToString(); }
            return aux;
        }

        private string CtasEmpleado1(string codigo)
        {
            DataTable RecAux = new DataTable();
            string aux = "";
            RecAux = SqlDatos.leerTablaAdcom("Select [CtbRol(0)] from Empleado where codigoempleado = '" + codigo + "' ");
            if (RecAux.Rows.Count > 0) { aux = RecAux.Rows[0][0].ToString(); }
            return aux;
        }

        private string CtasEmpleado2(string codigo)
        {
            DataTable RecAux = new DataTable();
            string aux = "";
            RecAux = SqlDatos.leerTablaAdcom("Select [CtbRol(2)] from Empleado where codigoempleado = '" + codigo + "' ");
            if (RecAux.Rows.Count > 0) { aux = RecAux.Rows[0][0].ToString(); }
            return aux;
        }

        private string CtasEmpleado3(string codigo)
        {
            DataTable RecAux = new DataTable();
            string aux = "";
            RecAux = SqlDatos.leerTablaAdcom("Select [CtbRol(3)] from Empleado where codigoempleado = '" + codigo + "' ");
            if (RecAux.Rows.Count > 0) { aux = RecAux.Rows[0][0].ToString(); }
            return aux;
        }

        private string CtasXpagar(string codigo)
        {
            DataTable RecAux = new DataTable();
            string aux = "";
            RecAux = SqlDatos.leerTablaAdcom("Select ctbproveedor from proveedor where codigoproveedor = '" + codigo + "' ");
            if (RecAux.Rows.Count > 0) { aux = RecAux.Rows[0][0].ToString(); }
            return aux;
        }

        private string CtasXpagar2(string codigo)
        {
            DataTable RecAux = new DataTable();
            string aux = "";
            RecAux = SqlDatos.leerTablaAdcom("Select ctbproveedor2 from proveedor where codigoproveedor = '" + codigo + "' ");
            if (RecAux.Rows.Count > 0) { aux = RecAux.Rows[0][0].ToString(); }
            return aux;
        }

        private string CtaCategoria(string codigo, int Cual = 0)
        {
            DataTable RecAux = new DataTable();
            string aux = "";
            string ssql = "SELECT AdcNiv.Niv_IdCta, AdcNiv.Niv_Idcta2, AdcNiv.Niv_Idcta3";
            ssql += " FROM AdcArt LEFT OUTER JOIN AdcNiv ";
             ssql += "   ON AdcArt.Art_categor = AdcNiv.Niv_abrevia and Niv_categor = 1";
             ssql += " where art_codigo  = '" + codigo + "'";
            RecAux = SqlDatos.leerTablaAdcom(ssql);
            if (RecAux.Rows.Count > 0)
            {
                if (Cual == 2) { aux = RecAux.Rows[0]["Niv_IdCta2"].ToString(); }
                else if (Cual == 3) { aux = RecAux.Rows[0]["Niv_IdCta3"].ToString(); }
                else if (Cual == 4) { aux = RecAux.Rows[0]["Niv_IdCta4"].ToString(); }
                else { aux = RecAux.Rows[0]["Niv_IdCta"].ToString(); }
            }
            else { aux = "999999"; }
            return aux;
        }
        private string CtaCategoriaAcf(string codigo, int Cual = 0)
        {
            DataTable RecAux = new DataTable();
            string aux = "";
            string ssql = "SELECT AdcNivAcf.Niv_IdCta, AdcNivAcf.Niv_Idcta2, AdcNivAcf.Niv_Idcta3";
            ssql += " from AdcACF left join AdcNivAcf ON AdcAcf.categoria = AdcNivAcf.Niv_abrevia  ";
            ssql += "where adcacf.codigo = '" + codigo + "' ";
            RecAux = SqlDatos.leerTablaAdcom(ssql);
            if (RecAux.Rows.Count > 0)
            {
                if (Cual == 2) { aux = RecAux.Rows[0]["Niv_IdCta2"].ToString(); }
                else if (Cual == 3) { aux = RecAux.Rows[0]["Niv_IdCta3"].ToString(); }
                else if (Cual == 4) { aux = RecAux.Rows[0]["Niv_IdCta4"].ToString(); }
                else { aux = RecAux.Rows[0]["Niv_IdCta"].ToString(); }
            }
            else { aux = "999999"; }
            return aux;
        }
        private string CtaDescuentos(string codigo, int Cual = 0)
        {
            DataTable RecAux = new DataTable();
            string aux = "";
            string ssql = "Select * from descpromo where DES_NOMBRE = '" + codigo + "' ";
            RecAux = SqlDatos.leerTablaAdcom(ssql);
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
            RecAux = SqlDatos.leerTablaAdcom(ssql);
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

            RecAux = SqlDatos.leerTablaAdcom(ssql);

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
            RecAux = SqlDatos.leerTablaIniSis("Select * from syscod where TipoReferencia = 'Departamento' and Abreviación = '" + codigo + "' ");
            if (RecAux.Rows.Count > 0)
            {
                if (Cual == 2) { aux = RecAux.Rows[0]["Caracteristica2"].ToString(); }
                else if (Cual == 3) { aux = RecAux.Rows[0]["Caracteristica3"].ToString(); }
                else if (Cual == 4) { aux = RecAux.Rows[0]["Caracteristica4"].ToString(); }
                else { aux = RecAux.Rows[0]["Caracteristica1"].ToString(); }
            }
            return aux;
        }
        private string ctaPago(string CodId, int Cual =0)
        {
            string ssql = "SELECT Id_Contable, Id_Contable2 from FormasDePago wheRE IdFormasdePago = '" + CodId + "'";
            using (SqlDataAdapter da = new SqlDataAdapter(ssql, datosEmpresa.strConxAdcom))
            {
                using (DataTable rs = new DataTable())
                {
                    da.Fill(rs);
                    if (rs.Rows.Count == 0) return "999999";
                    if (Cual == 2) return rs.Rows[0]["Id_Contable2"].ToString();
                    return rs.Rows[0]["Id_Contable"].ToString();
                }
            }
        }
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


        public void VerificarClasificadoresContablesServicios(string traOctb, string concepto,  DataGridViewRow Mrow,  ClassDoc.Servicios OpServicio,  sesSys.OpcDoc opcDoc, string QueBeneficiario, string BancoFin)
        {
            string[] Clasificadores;
			DaxClasificadores.ClasificadorCtb clasifica = new ClasificadorCtb();
            string ctaContable = "";
            Clasificadores = OpServicio.ClasificadorYcuenta(opcDoc, ref ctaContable).Split(Convert.ToChar(";"));
            if (Clasificadores.Length > 0)
            {
                for (int I = 0; I < Clasificadores.Length; I++)
                {
                    if (Clasificadores[I] != "")
                    {
                        clasifica.Cargar(Clasificadores[I]);
                        if (clasifica.Nombre != "")
                        {
                            if (traOctb == "T")  Mrow.Cells[clasifica.campotra].OwningColumn.Visible = true;
                            if (traOctb == "C") Mrow.Cells[clasifica.campodia].OwningColumn.Visible = true;
                        }
                    }
                }
            }

            //Mrow.Cells["tra_ventas"].Value = 0;
            //Mrow.Cells["tra_esAnticipo"].Value = 0;
            //Mrow.Cells["tra_compras"].Value = 0;
            //Mrow.Cells["tra_esAnticipo"].Value = 0;
            //Mrow.Cells["tra_banco"].Value = 0;
            //Mrow.Cells["tra_CtasCobrar"].Value = 0;
            //Mrow.Cells["tra_CtasPagar"].Value = 0;

            if (ctaContable.Length > 0)
            {
                if (ctaContable.Substring(0, 1) == "&" && ctaContable.Substring(1, 4) != "CONC" && ctaContable.Substring(1, 4) != "SERV")
                {
                    ctaContable = VerificarComodines(ctaContable, DattCom.datosEmpresa.sucursal,"", QueBeneficiario, "", "", BancoFin, "");
                }

                CtaMtn.Cuenta ctactb = new CtaMtn.Cuenta();
                ctactb.Cargar(ref ctaContable);
                int TIPODOC = 1;
                if (opcDoc.TipoDoc == "ING") TIPODOC = -1;

                if (ctactb.ModuloAuxiliar == "Cuentas Cobrar Clientes")
                {
                    Mrow.Cells["tra_ventas"].Value = TIPODOC;
                }
                else if (ctactb.ModuloAuxiliar == "Cuentas Pagar Proveedores")
                {
                    Mrow.Cells["tra_compras"].Value = TIPODOC;
                }
                else if (ctactb.ModuloAuxiliar == "Anticipos Clientes")
                {
                    Mrow.Cells["tra_ventas"].Value = TIPODOC;
                    Mrow.Cells["tra_esAnticipo"].Value = 1;
                }
                else if (ctactb.ModuloAuxiliar == "Anticipos Proveedores")
                {
                    Mrow.Cells["tra_compras"].Value = TIPODOC;
                    Mrow.Cells["tra_esAnticipo"].Value = 1;
                }
                else if (ctactb.ModuloAuxiliar == "CajaBancos")
                {
                    Mrow.Cells["tra_banco"].Value = TIPODOC;
                }
                else if (ctactb.ModuloAuxiliar == "OtrasCuentasCobrar")
                {
                    Mrow.Cells["tra_CtasCobrar"].Value = TIPODOC;
                }
                else if (ctactb.ModuloAuxiliar == "OtrasCuentasPagar")
                {
                    Mrow.Cells["tra_CtasPagar"].Value = TIPODOC;
                }
            }
            if (OpServicio.sev_compras || OpServicio.sev_ventas) return;
             {
                if (OpServicio.sev_cruceclientes || OpServicio.sev_cruceproveedores) { habilitarAplicacionDoc(Mrow); } else { iniciarAplicacionDoc(Mrow); }
            }
        }
        private void habilitarAplicacionDoc(DataGridViewRow Mrow)
        {
            Mrow.Cells["Apl_codBenef"].OwningColumn.Visible = true;
            Mrow.Cells["NombreImpresion"].OwningColumn.Visible = true;
            Mrow.Cells["Apl_SucApli"].OwningColumn.Visible = true;
            Mrow.Cells["Apl_Docapli"].OwningColumn.Visible = true;
            Mrow.Cells["Apl_Numapli"].OwningColumn.Visible = true;
            Mrow.Cells["TieneAplicacion"].Value = 1;
        }
        private void iniciarAplicacionDoc(DataGridViewRow Mrow)
        {
            Mrow.Cells["Apl_codBenef"].Value = "";
            Mrow.Cells["NombreImpresion"].Value = "";
            Mrow.Cells["Apl_SucApli"].Value = "";
            Mrow.Cells["Apl_Docapli"].Value = "";
            Mrow.Cells["Apl_Numapli"].Value = 0;
            Mrow.Cells["TieneAplicacion"].Value = 0;
        }

        //Private Sub VerificarClasificadoresContablesArticulo(Articulo As String)
        //Dim Clasificadores() As String
        //Dim clasifica As New MantCtb.clasificador
        //Dim I As Integer
        //Dim indice As Integer
        //Dim elerror As String
        //elerror = "Verificar Clasificador articulo"
        //On Error GoTo HayErrores
        //Clasificadores = Split(opArt.Clasificadores(dcTipDoc.BoundText), ";")
        //elerror = elerror & "1"
        //If UBound(Clasificadores) <> -1 Then
        //    For I = 0 To UBound(Clasificadores) - 1
        //        If Clasificadores(I) > "" Then
        //            elerror = "Verificar Clasificador existente"
        //           Set clasifica = NomClasifica.Item("C" & Clasificadores(I))
        //            elerror = elerror & "2"
        //            With clasifica
        //            If .Nombre > "" Then
        //'                If .regPorConcepto Then
        //                    indice = .idclave + 20
        //                    Malla.TextMatrix(0, indice) = .Nombre
        //                    Malla.ColWidth(indice) = 1200
        //                    Malla.ColData(indice) = 0
        //                    'malla.ColLock(indice) = True
        //'                Else
        //'                    MallaDatos.RowHeight(.idclave) = 300
        //'                    MallaDatos.TextMatrix(.idclave, 0) = .Nombre
        //'                End If
        //            End If
        //            End With
        //        End If
        //    Next I
        //End If
        //Exit Sub
        //HayErrores:
        //ControlaErrores elerror
        //End Sub

        //Private Function ClasificadorPertenece(TipoDoc As String, concepto As String, Queclasificador As String, QueTipo As String) As Boolean
        //Dim opserv As New Servicios
        //Dim ART As New Articulo
        //Dim Clasificadores() As String
        //Dim clasifica As New MantCtb.clasificador
        //Dim I As Integer

        //ClasificadorPertenece = False

        //If QueTipo = "S" Then
        //    If opserv.Cargar(concepto) = False Then Exit Function
        //    Clasificadores = Split(opserv.Clasificadores(TipoDoc), ";")
        //Else
        //    If ART.Cargar(concepto) = False Then Exit Function
        //    Clasificadores = Split(ART.Clasificadores(TipoDoc), ";")
        //End If
        //If UBound(Clasificadores) <> -1 Then
        //    For I = 0 To UBound(Clasificadores) - 1
        //        If Clasificadores(I) = Queclasificador Then ClasificadorPertenece = True: Set clasifica = Nothing: Exit Function
        //    Next I
        //End If
        //Set clasifica = Nothing
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

        //private DataTable tabla(string ssql, string strconx)
        //{
        //    using (SqlDataAdapter da = new SqlDataAdapter(ssql, strconx))
        //    {
        //        DataTable dt = new DataTable();
        //        da.Fill(dt);
        //        return dt;
        //    }
        //}
    }
}
