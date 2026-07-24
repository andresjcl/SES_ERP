using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using DattCom;
using DaxDocElectronicos;

namespace DctosEmi
{
    public class ClaveElectronica
    {
        public static void actualizarClaveElectronica(ClassDoc.AdcDoc datosDoc)
        {
            if (datosDoc.IdClaveDoc == 0) return;
            datosDoc.claveSri = generarClaveElectronica(datosDoc);
            //datosDoc.Adi_NroAutSri = datosDoc.claveSri;
            //datosDoc.NroAutorizacionSri = datosDoc.claveSri;
            datosDoc.Actualizar();
        }
        public static string generarClaveElectronica(ClassDoc.AdcDoc datosDoc)
        {
            string tipoEmision="1";
            //string ambiente="2";    // produccion
            string rucEmpresa = "";
            Feutilidad util = new Feutilidad();
            string TipoDocSri = util.tipoComprobanteSri(datosDoc.Doc_TipoDoc);
            util = null;
            if (rucEmpresa == "")
            {
                using (SqlConnection conn = new SqlConnection(datosEmpresa.strConxAdcom))
                {
                    conn.Open();
                    using (SqlCommand comm = new SqlCommand("select emp_ruc from  SysBd.dbo.Emp_Datos where emp_codigo = " + datosEmpresa.codEmpresa,conn))
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
            return DaxDocElectronicos.genearClaveDocumentoElct.generar_clave_FueraDeLinea(datosDoc.Doc_fecha,TipoDocSri ,tipoEmision,datosDoc.Doc_numero.ToString(),valoresPredefinidosEmpresa.AmbienteFactElctronica.ToString(),datosDoc.Doc_CiRuc,datosDoc.Doc_NroIdDoc,Convert.ToDouble(datosDoc.IdClaveDoc),rucEmpresa);
        }

    }
}
