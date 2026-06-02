using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DattCom;
using ClassFelec;
using DaxDocElectronicos;

namespace SolicitarAutorizacionSRI
{
    public class enviarDocumentoS
    {
        public short TipoDeAmbiente = Convert.ToInt16((object)enviarDocumentoS.TiposAmbiente.PRODUCCION);
        public short tipoDeEmision = Convert.ToInt16((object)enviarDocumentoS.TiposEmisión.NORMAL);
        private string codigo_numerico = "";
        //private string strConxadcom = datosEmpresa.strConxAdcom;
        private string strConxDaxpro = "";
        private string strConxIvaret = "";
        private string strConxDaxsys = "";
        public string pathFile = "";
        private string pathBmp = "";
        private string claveContingente = "";
        private Feutilidad util = new Feutilidad();
        //private DaxSofSys sysEmp = new DaxSofSys();

        public string documentoAenviar(string suc_comprobante,string tipo_comprobante,string numero_comrpobante,double idclaveDoc,ref string PathCpbte,string claseDoc,string empRuc,short empDigitosPrecios,string empPatAppl,short EmisionTipo,bool esOnLine)
        {
            string rucempresAct = Convert.ToString(datosEmpresa.Emp_RUC);
            classDatEmp.cargarDatosDeNuestraEmpresa(rucempresAct, datosEmpresa.strConxAdcom);
            string str1 = "";
            this.claveContingente = "";
            try
            {
                //this.iniciarConexion();
                string ssql = this.util.strLeerDocumento(suc_comprobante, tipo_comprobante, idclaveDoc.ToString(), claseDoc);
                daxDatos daxDatos = new daxDatos();
                DataTable dtra = daxDatos.leerDatos(ssql, datosEmpresa.strConxAdcom);
                if (dtra.Rows.Count == 0)
                    return "ERROR: NO EXISTE EL DOCUMENTO";
                if (!this.iniciarVariablesExternas())
                    return "ERROR: NO SE HA CONFIGURADO LA EMISION DE COMPROBANTES ELECTRONICOS";
                this.tipoDeEmision = EmisionTipo;
                DataRow row = dtra.Rows[0];
                string str2 = "";
                string tipoDocAdc = row["Doc_TipoDoc"].ToString();
                str1 = !esOnLine ? genearClaveDocumentoElct.generar_clave_FueraDeLinea(Convert.ToDateTime(row["Doc_fecha"]), this.util.tipoComprobanteSri(tipoDocAdc), this.tipoDeEmision.ToString(), row["Doc_Numero"].ToString(), this.TipoDeAmbiente.ToString(), row["Doc_ciruc"].ToString(), row["Doc_NroIdDoc"].ToString(), idclaveDoc, empRuc) : genearClaveDocumentoElct.generar_clave_accesoNormal(Convert.ToDateTime(row["Doc_fecha"]), this.util.tipoComprobanteSri(tipoDocAdc), empRuc, this.TipoDeAmbiente, row["Doc_NroIdDoc"].ToString(), numero_comrpobante, this.codigo_numerico, this.tipoDeEmision, datosEmpresa.strConxAdcom);
                
                enviarDocumentoS enviarDocumentoS = this;
                enviarDocumentoS.pathFile = enviarDocumentoS.pathFile + str1 + ".XML";
                if (tipoDocAdc == "FAC")
                {
                    generarDocXml generarDocXml = new generarDocXml();
                    str2 = "factura.xsd";
                    generarDocXml.crear_factura_xml_sri(ref row, ref dtra, this.pathFile, str1, this.TipoDeAmbiente, this.tipoDeEmision, empDigitosPrecios,datosEmpresa.Emp_Nombre,datosEmpresa.Emp_RUC,datosEmpresa.Emp_Dirección,datosEmpresa.nombreBaseIvaret,datosEmpresa.strConxAdcom);
                }                
                if (str1.Length < 3 || str1.Substring(0, 3).ToUpper() == "ERR")
                    return str1;
                PathCpbte = this.pathFile;
                this.util.ActualizarDocumentoAdcom("Generado", suc_comprobante, tipo_comprobante, idclaveDoc, str1, "", (int)this.tipoDeEmision, (string)null, (int)this.TipoDeAmbiente, datosEmpresa.strConxAdcom);
                this.util = (Feutilidad)null;
                return str1;
            }
            catch (Exception ex)
            {
                return "ERROR: \n" + str1 + "\n" + ex.Message + " ENVIAR DOCUMENTOS";
            }
        }

        private string tipoDocSri(string tipoAdc, string str)
        {
            string str1 = "";
            daxDatos daxDatos = new daxDatos();
            DataTable dataTable = daxDatos.leerDatos("select opc_tiposri from adcopc where opc_documento ='" + tipoAdc + "'", str);
            if (dataTable.Rows.Count > 0)
                str1 = dataTable.Rows[0]["opc_tiposri"].ToString();
            return str1.PadLeft(2, Convert.ToChar("0"));
        }

        private bool iniciarVariablesExternas()
        {
            AdcFelec adcFelec1 = new AdcFelec(datosEmpresa.strConxAdcom);
            AdcFelec adcFelec2 = AdcFelec.Buscar("");
            if (adcFelec2 == null)
                return false;
            this.pathFile = adcFelec2.pathCpbGenerados;
            this.pathBmp = adcFelec2.pathCpbAutorizados;
            if (!adcFelec2.ambienteEnProduccion)
                this.TipoDeAmbiente = Convert.ToInt16((object)enviarDocumentoS.TiposAmbiente.PRUEBA);
            adcFelec1 = (AdcFelec)null;
            return true;
        }

       
        private enum TiposAmbiente
        {
            PRUEBA = 1,
            PRODUCCION = 2,
        }

        private enum TiposAcción
        {
            RECEPCION = 1,
            AUTORIZACION = 2,
        }

        private enum TiposEnvío
        {
            NORMAL = 1,
            LOTE = 2,
            LOTE_MASIVO = 3,
        }

        private enum TiposEmisión
        {
            NORMAL = 1,
            NODISPONIBLE = 2,
        }
    }

}
