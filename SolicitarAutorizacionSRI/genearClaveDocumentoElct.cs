
using DaxDocElectronicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolicitarAutorizacionSRI
{
    public class genearClaveDocumentoElct
    {
        private static Feutilidad util = new Feutilidad();

        public static string generar_clave_accesoNormal(
          DateTime fecha_emision,
          string tipo_comprobante,
          string ruc,
          short ambiente,
          string serie,
          string numero_comrpobante,
          string codigo_numerico,
          short tipo_emision,
          string str)
        {
            serie = genearClaveDocumentoElct.util.formatoNumero(serie, 7);
            string numero = string.Format("{0:ddMMyyyy}", (object)fecha_emision) + tipo_comprobante + genearClaveDocumentoElct.util.formatoNumero(ruc, 13) + (object)ambiente + genearClaveDocumentoElct.util.formatoNumero(serie.Substring(0, 3), 3) + genearClaveDocumentoElct.util.formatoNumero(serie.Substring(4, 3), 3) + genearClaveDocumentoElct.util.formatoNumero(numero_comrpobante, 9) + genearClaveDocumentoElct.util.formatoNumero(codigo_numerico, 8) + (object)tipo_emision;
            string str1 = genearClaveDocumentoElct.crear_digito_mod11(numero);
            return numero + str1;
        }

        public static string generar_clave_FueraDeLinea(
          DateTime fecha_emision,
          string tipo_comprobante,
          string tipo_emision,
          string numeroDoc,
          string ambiente,
          string rucCliente,
          string SerieSri,
          double idclaveDoc,
          string rucEmpresa)
        {
            Convert.ToChar("0");
            string numero = string.Format("{0:ddMMyyyy}", (object)fecha_emision) + genearClaveDocumentoElct.util.formatoNumero(tipo_comprobante, 2) + genearClaveDocumentoElct.util.formatoNumero(rucEmpresa, 13) + genearClaveDocumentoElct.util.formatoNumero(ambiente.ToString(), 1) + genearClaveDocumentoElct.util.formatoNumero(SerieSri.Substring(0, 3), 3) + genearClaveDocumentoElct.util.formatoNumero(SerieSri.Substring(4, 3), 3) + genearClaveDocumentoElct.util.formatoNumero(numeroDoc, 9) + genearClaveDocumentoElct.controlarIdclave(idclaveDoc) + "1";
            string str = genearClaveDocumentoElct.crear_digito_mod11(numero);
            return numero + str;
        }

        private static string controlarIdclave(double idclave)
        {
            string numero = idclave.ToString();
            int length = numero.Length;
            if (length > 8)
                numero = numero.Substring(length - 8);
            return genearClaveDocumentoElct.util.formatoNumero(numero, 8);
        }

        private static string crear_digito_mod11(string numero)
        {
            int num1 = 0;
            int num2 = 2;
            for (int startIndex = numero.Length - 1; startIndex > -1; --startIndex)
            {
                num1 += Convert.ToInt32(numero.Substring(startIndex, 1)) * num2;
                ++num2;
                if (num2 == 8)
                    num2 = 2;
            }
            int num3 = 11 - num1 % 11;
            if (num3 == 11)
                num3 = 0;
            if (num3 == 10)
                num3 = 1;
            return num3.ToString();
        }
    }
}
