using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.IO;
using ClassDoc;
namespace adcDocumentos
{
    static public class impresionVerificacion
    {

        static public string correoElectronico=string.Empty;
        static public string claveSri = string.Empty ;

        static public double verificarExistenciaDocumento(ref idDocumento IDdcto, string strConxAdcom, Boolean documentoMultiNumeracion,string TABLA)
        {            
            double clavedoc = 0;
            if (documentoMultiNumeracion == true)
            {
                adcDocumentos.Form1 forma1 = new adcDocumentos.Form1();
                clavedoc = forma1.SeleccionaDoc(IDdcto.Sucursal , IDdcto.Tipo , IDdcto.numero.ToString(), strConxAdcom);
                forma1.Close();
                forma1.Dispose();
                if (clavedoc < 1) clavedoc=0;
            }
            else
            {
                try
                {
                    DataTable dt = new DataTable();
                    string ssql = "select idclavedoc from "+TABLA+" where doc_sucursal = '" + IDdcto.Sucursal  + "' and opc_documento ='" + IDdcto.Tipo  + "' and doc_numero = " + IDdcto.numero ;
                    SqlDataAdapter da = new SqlDataAdapter(ssql, strConxAdcom);
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        clavedoc = Convert.ToDouble(dt.Rows[0]["IdClaveDoc"]);
                    }
                }
                catch { }
            }
            IDdcto.idClave = clavedoc;
            return clavedoc;
        }
        static public double verificarExistenciaDocumentoFac(ref idDocumento IDdcto, string strConxAdcom, string TABLA, string IdTrib)
        {
            double clavedoc = 0;
            if (IdTrib.Length == 0)
            {
                adcDocumentos.Form1 forma1 = new adcDocumentos.Form1();
                clavedoc = forma1.SeleccionaDoc(IDdcto.Sucursal, IDdcto.Tipo, IDdcto.numero.ToString(), strConxAdcom);
                forma1.Close();
                forma1.Dispose();
                if (clavedoc < 1) clavedoc = 0;
            }
            else
            {
                try
                {
                    DataTable dt = new DataTable();
                    string ssql = "select idclavedoc from " + TABLA + " where doc_sucursal = '" + IDdcto.Sucursal + "' and opc_documento ='" + IDdcto.Tipo + "' and doc_numero = " + IDdcto.numero + " and doc_NroIdDoc = '" + IdTrib + "'";
                    SqlDataAdapter da = new SqlDataAdapter(ssql, strConxAdcom);
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        clavedoc = Convert.ToDouble(dt.Rows[0]["IdClaveDoc"]);
                    }
                }
                catch { }
            }
            IDdcto.idClave = clavedoc;
            return clavedoc;
        }


        //public Boolean ExisteDocumentoGrabado(ref ClassDoc.AdcDoc adcdoc,ref PrySysp13.OpcDoc opcdoc, string cadenaConexion,double idclavedoc)
        //{
        //    Boolean resp = false;
        //    string ssql = " select idclavedoc from adcdoc where Doc_sucursal = '" + adcdoc.Doc_sucursal + "' and Opc_documento = '" + adcdoc.Opc_documento + "' and Doc_numero =" + adcdoc.Doc_numero;
        //    if (opcdoc.Opc_Propietario != 0) { ssql += " and doc_codper = '" + adcdoc.Doc_codper + "' "; }
        //    if (opcdoc.Opc_Bodega != 0) { ssql += " and doc_Bodega = '" + adcdoc.Doc_Bodega + "' "; }
        //    if (opcdoc.Opc_IdSri   != 0) { ssql += " and Doc_NroIdDoc = '" + adcdoc.Doc_NroIdDoc + "' "; }

        //    //SqlConnection cnn = new SqlConnection(cadenaConexion);
        //    DataTable dtt = new DataTable();
        //    SqlDataAdapter da = new SqlDataAdapter(ssql, cadenaConexion);
        //    da.Fill(dtt);
        //    if (dtt.Rows.Count != 0)
        //    {
        //        if (idclavedoc == 0)
        //        {
        //            resp = true;
        //        }
        //        else
        //        {
        //            for (int i = 0; i < dtt.Rows.Count; i++)
        //            {
        //              if (Convert.ToDouble(dtt.Rows[0]["idclavedoc"]) != idclavedoc) resp = true;
        //            }
        //        }
        //    }
        //    da.Dispose();
        //    dtt.Dispose();
        //    return resp;
        //}
        static public Boolean  validaComprobantesElectronicos(string path)
        {
            Boolean tieneComprobantesElectronicos = true;
            //try
            //{
            //    tieneComprobantesElectronicos = Directory.Exists(path);
            //}
            //catch { tieneComprobantesElectronicos = false; }
            ////string curFile = path + @"AdcGenxml.dll";
            ////tieneComprobantesElectronicos = File.Exists(curFile);
            ////if (tieneComprobantesElectronicos == true)
            ////{
            ////    curFile = path  + @"AdcFirelec.dll";
            ////}
            ////tieneComprobantesElectronicos = File.Exists(curFile);
            ////if (tieneComprobantesElectronicos == true)
            ////{
            ////    curFile = path + @"Daxconxfe.dll";
            ////}
            ////tieneComprobantesElectronicos = File.Exists(curFile);
            return tieneComprobantesElectronicos;
        }

    }
}
                                                          
