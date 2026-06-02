using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using DattCom;

namespace ctrlReferencia
{
    public class controlReferencial
    {        
        public DataTable docSoporte = new DataTable();
        public DataTable traSoporte = new DataTable();

        public Boolean LeerDocumentoReferencial(string Suc , string Tip , string numero , ClassDoc.idDocumento DocmtoOriginal ) 
        {
        Boolean resp=true;
        string ssql = "";
        string Lugar="";
        sesSys.OpcDoc opOpcRef = new sesSys.OpcDoc();
        SqlDataAdapter da = new SqlDataAdapter(ssql,datosEmpresa.strConxAdcom);
        opOpcRef.Cargar (ref Tip,ref Lugar);
        string TipoDoc = opOpcRef.TipoDoc;
        opOpcRef=null;

        string tabla = opOpcRef.tablaDatosDoc;

        if (TipoDoc == "ORP")
        {
            tabla = "PRO_DOCORD";
            ssql = "select * from " + tabla + " where ORD_TIPO = '" + Tip + "' and ORD_numero = " + numero;
        } 
        else
        {
            //            ssql = "select isnull(caracteristica1,'000000') as aa,isnull(caracteristica2,'D') as ff from SYSCOD where TIPOREFERENCIA = 'DOCUMENTOS' AND ABREVIACIÓN ='" + opopcref.TipoDoc + "'";
            //            da.Fill(docSoporte);            
            //            if (docSoporte.Rows.Count > 0) { if (docSoporte.Rows[0]["ff"].ToString() == "P" ){tabla = "adcdocpro";}}
            //            docSoporte.Dispose();

            ssql = "select * from " + tabla + " where doc_sucursal = '" + Suc + "' and opc_documento = '" + Tip + "' and doc_numero = " + numero;
        }
            docSoporte = new DataTable();
            traSoporte = new DataTable();
            if (TipoDoc == "ORP")
            {
                da = new SqlDataAdapter(ssql,  datosEmpresa.strConxDaxpro);
                da.Fill(docSoporte) ;
                if (docSoporte.Rows.Count == 0) resp = false;
            }
            else
            {
                da = new SqlDataAdapter(ssql, datosEmpresa.strConxAdcom);
                da.Fill(docSoporte) ;
                if (docSoporte.Rows.Count == 0) 
                {
                    resp = false;
                }
                else 
                {
                    ssql = "prodPendDoc '" + Tip + "','" + DocmtoOriginal.Sucursal  + "'," + numero + ",'" + DocmtoOriginal.Tipo  + "'," + DocmtoOriginal.numero;
                    da=new SqlDataAdapter(ssql, datosEmpresa.strConxAdcom);
                    da.Fill(traSoporte);
                }
            }
            return resp;
        }
    }
}
