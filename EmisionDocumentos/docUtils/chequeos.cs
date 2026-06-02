using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ClassDoc;

namespace adcDocumentos
{
    class chequeos
    {
        static public Boolean ChequeaDocAplicado(idDocumento docOriginal, ref idDocumento docAplica, string strConxAdcom)
        {

            Boolean resp=false;
            string cod = " SELECT Doc_sucursal,Opc_documento,Doc_numero FROM AdcApl ";
            cod += " WHERE Apl_SucApli = '" + docOriginal.Sucursal  + "' AND Apl_DocApli ='" + docOriginal.Tipo + "' AND idclavedocapl = " + docOriginal.idClave.ToString(); 
            using (SqlDataAdapter da = new SqlDataAdapter (cod,strConxAdcom))
            {
                using (DataTable rs = new DataTable())
                {
                    da.Fill(rs);
                    if (rs.Rows.Count > 0) 
                    {
                        docAplica.Sucursal = rs.Rows[0]["Doc_sucursal"].ToString();
                        docAplica.Tipo = rs.Rows[0]["Opc_documento"].ToString();
                        docAplica.numero = Convert.ToDouble(rs.Rows[0]["Doc_numero"]);
                        resp = true;
                    }
                }
            }
            return resp;
        }
        static public string[] ChequeaDocumentoCitasMédicas(idDocumento docOriginal)
        {
            string iddoc =  docOriginal.Sucursal + "-" + docOriginal.Serie + "-" + docOriginal.numero.ToString() + "";

            string[] resp = new string [2] ;
            string cod = " SELECT isnull(Ubicacion,'') as Ubicacion, idclave FROM Medcitas WHERE factura  = '" + iddoc + "'" ;
            try
            {
                DataTable rs = SysEmpDatt.SqlDatos.leerTablaAdcom(cod);
                if (rs.Rows.Count > 0)
                {
                    resp[0] = rs.Rows[0]["Ubicacion"].ToString();
                    resp[1] = rs.Rows[0]["idclave"].ToString();
                }
                else
                { resp [0]= "NO"; }
            }catch{ resp[0] = "NO"; }
            return resp;
        }

        static public Boolean ChequeaSoporteObligado(idDocumento docOriginal, ref idDocumento docAplica, string strConxAdcom)
        {

            Boolean resp=false;
            string cod = " SELECT Doc_sucursal,Opc_documento,Doc_numero from adcdoc where opc_documento in (";
            cod += " select opc_documento from adcopc where tiposoporteobligatorio='" + docOriginal.Tipo + "' )";
            cod +=  " and doc_docsop = '" + docOriginal.Tipo + "' and idclavedocsop = " + docOriginal.idClave.ToString();
            
            using (SqlDataAdapter da = new SqlDataAdapter (cod,strConxAdcom))
            {
                using (DataTable rs = new DataTable())
                {
                    da.Fill(rs);
                    if (rs.Rows.Count > 0) 
                    {
                        docAplica.Sucursal = rs.Rows[0]["Doc_sucursal"].ToString();
                        docAplica.Tipo = rs.Rows[0]["Opc_documento"].ToString();
                        docAplica.numero = Convert.ToDouble(rs.Rows[0]["Doc_numero"]);
                        resp = true;
                    }
                }
            }
            return resp;
        }
    
    }
}
//Public Function ChequeaDocAdjuntos(DocSuc As String, DocTip As String, DocNumero As String, IdClaveDoc As Double) As Boolean
//Dim rs As New ADODB.Recordset
//Dim ssql As String
//ssql = "SELECT  Doc_sucursal, Opc_documento, Doc_numero, Doc_fecha, Doc_NombreImp, Doc_valor,idclavedoc From dbo.AdcDoc"
//ssql = ssql & " WHERE  Doc_DocSop = '" & DocTip & "' AND Doc_NumSop = " & DocNumero
//rs.CursorLocation = adUseClient
//rs.Open ssql, ConxAdcom, adOpenForwardOnly, adLockReadOnly
//If rs.EOF Then ChequeaDocAdjuntos = False Else ChequeaDocAdjuntos = True
//If rs.State Then rs.Close
//End Function

