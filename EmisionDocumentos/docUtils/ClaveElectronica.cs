using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace adcDocumentos
{
    public class ClaveElectronica
    {
        public static void actualizarClaveElectronica(ClassDoc.AdcDoc datosDoc)
        {
            datosDoc.claveSri = generarClaveElectronica(datosDoc);
            datosDoc.Adi_NroAutSri = datosDoc.claveSri;
            datosDoc.NroAutorizacionSri = datosDoc.claveSri;
            datosDoc.Actualizar();
        }
        public static string generarClaveElectronica(ClassDoc.AdcDoc datosDoc)
        {
            string tipoEmision="1";
            //string ambiente="2";    // produccion
            string rucEmpresa = "";
            adcFeutil.Feutilidad util = new adcFeutil.Feutilidad();
            string TipoDocSri = util.tipoComprobanteSri(datosDoc.Doc_TipoDoc);
            util = null;
            if (rucEmpresa == "")
            {
                using (SqlConnection conn = new SqlConnection(varbleComun.VarCom.strConxAdcom))
                {
                    conn.Open();
                    using (SqlCommand comm = new SqlCommand("select emp_ruc from  daxsys.dbo.Emp_Datos where emp_codigo = " + varbleComun.VarCom.codEmpresa,conn))
                    {
                        SqlDataReader dr = comm.ExecuteReader();
                        if (dr.Read())
                        {
                            rucEmpresa = dr["emp_ruc"].ToString();
                        }
                        dr.Close();                        
                    }
                }
            }
            return AdcGenxml.genearClaveDocumentoElct.generar_clave_FueraDeLinea(datosDoc.Doc_fecha,TipoDocSri ,tipoEmision,datosDoc.Doc_numero.ToString(),valoresPredefinidosEmpresa.AmbienteFactElctronica.ToString(),datosDoc.Doc_CiRuc,datosDoc.Doc_NroIdDoc,Convert.ToDouble(datosDoc.IdClaveDoc),rucEmpresa);
        }

    }
}
