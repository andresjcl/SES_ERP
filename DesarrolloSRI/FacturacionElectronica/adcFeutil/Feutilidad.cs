using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
namespace DaxDocElectronicos
{
    public class Feutilidad
    {
        public string tipoId(string tipo, int ambito)
        {
            if (ambito == 0)    // compras
            {
                if (tipo == "R") { return "01"; }  // RUC
                if (tipo == "C") { return "02"; }  // CEDULA 
                if (tipo == "P") { return "03"; }  // PASAPORTE
                if (tipo == "E") { return "03"; }  // IDENTIFICACION DEL EXTERIOR
                return "04";
            }
            else if (ambito == 1)    // ventas
            {
                if (tipo == "R") { return "04"; }  // RUC
                if (tipo == "C") { return "05"; }  // CEDULA 
                if (tipo == "P") { return "06"; }  // PASAPORTE
                if (tipo == "F") { return "07"; }  // CONSUMIDOR FINAL
                if (tipo == "E") { return "06"; }  // IDENTIFICACION DEL EXTERIOR
                if (tipo == "L") { return "19"; }  // PLACA
                return "04";
            }
            else if (ambito == 2)    // exportaciones
            {
                if (tipo == "P") { return "21"; }  // PASAPORTE
                if (tipo == "E") { return "21"; }  // IDENTIFICACION DEL EXTERIOR
                return "09";
            }
            else if (ambito == 3)    // anulaciones
            {
                return "18"; 
            }
            return "00";
        }        
        public string codigoRetencionIva(double valorPorc)
        {
            string resp = string.Empty;
            if (valorPorc == 30) { resp = "1";}
            if (valorPorc == 70) { resp = "2"; }
            if (valorPorc == 100) { resp = "3"; }
            if (valorPorc == 10) { resp = "9"; }
            if (valorPorc == 20) { resp = "10"; }

            return resp;
        }
        public string ObligadoLlevarContabilidad(Boolean tipo)
        {
            if (tipo == true) { return "SI"; }
            else { return "NO"; }
        }

        public string tipoId(string tipo)
        {
            if (tipo == "R") { return "04"; }  // RUC
            if (tipo == "C") { return "05"; }  // CEDULA 
            if (tipo == "P") { return "06"; }  // PASAPORTE
            if (tipo == "F") { return "07"; }  // CONSUMIDOR FINAL
            if (tipo == "E") { return "08"; }  // IDENTIFICACION DEL EXTERIOR
            if (tipo == "L") { return "09"; }  // PLACA
            return "04";
        }
        public string tipoIdRol(string tipo)
        {
            if (tipo == "04") { return "R"; }  // RUC
            if (tipo == "05") { return "C"; }  // CEDULA 
            if (tipo == "06") { return "P"; }  // PASAPORTE
            if (tipo == "07") { return "F"; }  // CONSUMIDOR FINAL
            if (tipo == "08") { return "E"; }  // IDENTIFICACION DEL EXTERIOR
            if (tipo == "09") { return "L"; }  // PLACA
            return "R";
        }
 
        public string nombreCliente(Int16 ambiente, string nombre)
        {
            if (ambiente == 1) nombre = "PRUEBAS SERVICIO DE RENTAS INTERNAS";

            return formatoString(nombre, 300);
        }

        public string formatoNumero(string numero, int longitud)
        {
            string valor = "";
            if (numero.Length > longitud) { valor = numero.Substring(numero.Length - longitud, longitud); }
            else
            {
                Char cc = Convert.ToChar("0");
                valor = numero.PadLeft(longitud, cc);
            }
            return valor;
        }

        public string formatoDecimal(string strVal, int longitud, int decimales)
        {
            decimal numero = 0;
            try
            {
                numero = Math.Abs(Convert.ToDecimal( strVal ));
            }catch { }

            string ff = "{0:0}";
            string valor = "";
            if (!(decimales == 0))
            {
                ff = "{0:0." + "0000000000".Substring(0, decimales) + "}";
            }
            valor = string.Format(ff, numero);
            if (valor.Length > longitud) valor = valor.Substring(valor.Length - longitud, longitud);
            return valor;
        }

        public string formatoDecimal(double numero, int longitud, int decimales)
        {
            numero = Math.Abs(numero);
            string ff = "{0:0}";
            string valor = "";
            if (!(decimales == 0))
            {
                ff = "{0:0." + "0000000000".Substring(0, decimales) + "}";
            }
            valor = string.Format(ff, numero);
            if (valor.Length > longitud) valor = valor.Substring(valor.Length - longitud, longitud);
            return valor;
        }

        public string formatoDecimal(double numero, int longitud, int decimales, Boolean signo)
        {
            if (signo == false ) numero = Math.Abs(numero);
            string ff = "{0:0}";
            string valor = "";
            if (!(decimales == 0))
            {
                ff = "{0:0." + "0000000000".Substring(0, decimales) + "}";
            }
            valor = string.Format(ff, numero);
            if (valor.Length > longitud) valor = valor.Substring(valor.Length - longitud, longitud);
            return valor;
        }
        public string formatoString(string str, int longitud)
        {
            if (str.Length > longitud) { str = str.Substring(0, longitud); }
            return str;
        }

        public string formatoFecha(DateTime fecha)
        {
            string forma = "";
            try
            {
                forma = string.Format("{0:dd/MM/yyyy}", fecha);
            }
            catch
            {
                forma = "01/01/1900";
            }
            return forma;
        }
        public double calcularValorIva(double tarifa, double valor)
        {
            valor = valor * tarifa / 100;
            return valor;
        }
        public string tipoComprobanteSri(string tipoDocAdc)
        { 
            string tipo="01";
            if (tipoDocAdc == "FAC") { tipo = "01"; }
            if (tipoDocAdc == "FAP") { tipo = "03"; }
            if (tipoDocAdc == "NCC") { tipo = "04"; }
            if (tipoDocAdc == "DEV") { tipo = "04"; }
            if (tipoDocAdc == "NDC") { tipo = "05"; }
            if (tipoDocAdc == "REM" || tipoDocAdc == "PRC") { tipo = "06"; }
            if (tipoDocAdc == "RTP") { tipo = "07"; }
            return tipo;        
        }
        public void ActualizarDocumentoAdcom( string estado, string queSuc, string queDoc, double IdClaveDoc, string clave, string NroAutorizacion, int emision, string FechaAutoriza, int ambiente, string strConxAdcom)
        {
            string queTabla = "ADCDOC";
            string ssql = "update " + queTabla + " set estadosri='" + estado + "' ";
        
            if (estado == "Generado")
            {
                ssql += ",claveSri='" + clave + "' ";
                ssql += ",tipoEmision = '" + emision + "' ";
                ssql += ",auxnum1 = " + ambiente.ToString();
            }
            if (estado == "Autorizado")
            {
                ssql += ",NroAutorizacionSri = '" + NroAutorizacion + "',adi_nroautsri = '" + NroAutorizacion + "' ";
                //FechaAutoriza = FechaAutoriza.Replace("T", " ");
                ssql += ",fechaAutorizacion = '" + FechaAutoriza + "' ";
            }
            if (IdClaveDoc == 0)
            {
                ssql += " where claveSri = '" + clave + "' ";
            }
            else
            {
                ssql += " where doc_sucursal = '" + queSuc + "' and opc_documento = '" + queDoc + "' and idclavedoc = " + Convert.ToString(IdClaveDoc);
            }
            //DaxLib.DaxLibBases daxlib = new DaxLib.DaxLibBases();
            //daxlib.TipoBase = "10";
            using (SqlConnection conn = new SqlConnection(strConxAdcom))
            {
                conn.Open();
                //            daxlib = null ;
                SqlCommand comm = new SqlCommand(ssql, conn);
                comm.ExecuteNonQuery();
                comm.Dispose();
                conn.Close();
            }
        }
        public string strLeerDocumento(ClassDoc.idDocumento idDoc)
        {
            return strLeerDocumento(idDoc.Sucursal, idDoc.Tipo, idDoc.idClave.ToString(), idDoc.familia);
        }
        public string strLeerDocumento(string suc_comprobante, string tipo_comprobante,string idclaveDoc,string claseDoc)
        {
            
            string strProceso = "ses_CpbtFac ";
            if (claseDoc == "NCC" || claseDoc == "NDC" || claseDoc == "DEV")
                strProceso = "ses_CpbtNcc ";
            else if (claseDoc =="REM")
                strProceso = "ses_CpbtRem ";
            else if (claseDoc == "RTP")
                strProceso = "ses_CpbtRet ";
            else if (claseDoc == "FAP")
                strProceso = "ses_CpbtLiq ";

            string ssqlDoc = strProceso  + idclaveDoc.ToString() + ",'" + suc_comprobante + "','" + tipo_comprobante + "'" ;
            return ssqlDoc;
        }

        static public string PathDocumntosPdf(string pathCpbGenerados)
        {
            string resp = "";
            if (pathCpbGenerados.Substring(pathCpbGenerados.Length - 1,1)=="\\")
            {
                resp = pathCpbGenerados.Substring(0, pathCpbGenerados.Length - 1)+"PDF\\";
            }
            return resp;
        }
        //public void strLeerDocumentoNcc(ref string adcdoc, ref string adctra, string suc_comprobante, string tipo_comprobante, string idclaveDoc)
        //{
        //    string ssqlDoc = "adc_CpbtNcc " + idclaveDoc.ToString() + ",'" + suc_comprobante + "','" + tipo_comprobante + "'";

        //    adcdoc = ssqlDoc;
        //    //adctra = ssqlTra;
        //}
        //public void strLeerDocumentoRem(ref string adcdoc, ref string adctra, string suc_comprobante, string tipo_comprobante, string idclaveDoc)
        //{
        //    string ssqlDoc = "adc_CpbtRem " + idclaveDoc.ToString() + ",'" + suc_comprobante + "','" + tipo_comprobante + "'";

        //    adcdoc = ssqlDoc;
        //    //adctra = ssqlTra;

        //}
        //public void strLeerDocumentoRet(ref string adcdoc, ref string adctra, string suc_comprobante, string tipo_comprobante, string idclaveDoc)
        //{
        //    string ssqlDoc = "adc_CpbtRet " + idclaveDoc.ToString() + ",'" + suc_comprobante + "','" + tipo_comprobante + "'";
        //    adcdoc = ssqlDoc;
        //}

    }
}