using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.IO;
using ClassDoc;
namespace DctosEmi
{
    static public class impresionVerificacion
    {

        static public string correoElectronico=string.Empty;
        static public string claveSri = string.Empty ;

        static public double verificarExistenciaDocumento(ref idDocumento IDdcto, string strConxAdcom, Boolean documentoMultiNumeracion,string TablaBd,string proveedor = "")
        {
            if (IDdcto.numero == 0) return 0;

            double clavedoc = 0;
            if (documentoMultiNumeracion == true && proveedor.Length == 0 )
            {
                DctosEmi.frmVerDupli forma1 = new DctosEmi.frmVerDupli();
                clavedoc = forma1.SeleccionaDoc(IDdcto.Sucursal , IDdcto.Tipo , IDdcto.numero.ToString(), strConxAdcom,TablaBd);
                forma1.Close();
                forma1.Dispose();
            }
            else
            {
                try
                {
                    DataTable dt = new DataTable();
                    string ssql = "select idclavedoc from "+TablaBd+" where doc_sucursal = '" + IDdcto.Sucursal  + "' and opc_documento ='" + IDdcto.Tipo  + "' and doc_numero = " + IDdcto.numero ;
                    if (IDdcto.Serie.Length > 0) ssql += " and doc_nroiddoc = '" + IDdcto.Serie + "' ";
                    if (proveedor.Length > 0) ssql += " and Doc_codper = '" + proveedor + "' ";
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
        //static public double verificarExistenciaDocumentoFac(ref idDocumento IDdcto, string strConxAdcom, string TablaBd)
        //{
        //    double clavedoc = 0;
        //    if (IdTrib.Length == 0)
        //    {
        //        DctosEmi.frmVerDupli forma1 = new frmVerDupli();
        //        clavedoc = forma1.SeleccionaDoc(IDdcto.Sucursal, IDdcto.Tipo, IDdcto.numero.ToString(), strConxAdcom, TablaBd);
        //        forma1.Close();
        //        forma1.Dispose();
        //        if (clavedoc < 1) clavedoc = 0;
        //    }
        //    else
        //    {
        //        try
        //        {
        //            DataTable dt = new DataTable();
        //            string ssql = "select idclavedoc from " + TablaBd + " where doc_sucursal = '" + IDdcto.Sucursal + "' and opc_documento ='" + IDdcto.Tipo + "' and doc_numero = " + IDdcto.numero + " and doc_NroIdDoc = '" + IdTrib + "'";
        //            SqlDataAdapter da = new SqlDataAdapter(ssql, strConxAdcom);
        //            da.Fill(dt);
        //            if (dt.Rows.Count > 0)
        //            {
        //                clavedoc = Convert.ToDouble(dt.Rows[0]["IdClaveDoc"]);
        //            }
        //        }
        //        catch { }
        //    }
        //    IDdcto.idClave = clavedoc;
        //    return clavedoc;
        //}


        //public Boolean ExisteDocumentoGrabado(ref ClassDoc.AdcDoc adcdoc,ref sesSys.OpcDoc opcdoc, string cadenaConexion,double idclavedoc)
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
                                                          
