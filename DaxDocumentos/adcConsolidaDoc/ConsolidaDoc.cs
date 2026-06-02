using System;
using System.Data;
using System.Data.SqlClient;
using ClassDoc;

namespace DctosEmi

{
    public class ConsolidaDoc      
    {
        static public string tiposDoctsConsolidaSql(string strConx) // arma un string formado para usar buscando doumentos en instruccion sql con "where opc_documento IN"
        {
            string docs = "";
            string separador = "'";
            DataTable rs= DattCom.SqlDatos.leerTabla("SELECT Opc_documento From dbo.AdcOpc WHERE isnull(opc_consolidar,0) = 1 ", strConx);
            if (rs.Rows.Count > 0)
            {
                foreach (DataRow row in rs.Rows)
                {
                    if (docs.Length > 0) { docs += ","; }
                    docs += separador + row["opc_documento"].ToString() + separador;
                }
            }
            return docs;
        }

        static public string tiposDoctsConsolida(string strConx) // arma un string formado por lo tipos dedocumentos de tres cara acteres para la busqueda de documentos
        {
            string docs = "";
            string SSQL ="select Opc_documento from AdcOpc left join Syscod on adcopc.opc_tipo = syscod.Abreviación and tiporeferencia = 'Documentos' ";
            SSQL += " where Caracteristica2='D' AND isnull(Opc_consolidar,0) = 1 ";
            DataTable rs = DattCom.SqlDatos.leerTabla(SSQL, strConx);

            if (rs.Rows.Count > 0)
            {
                foreach (DataRow row in rs.Rows)
                {
                    docs +=  (row["opc_documento"].ToString() + "   ").Substring(0,3);
                }
            }
            return docs;
        }
        static public void RegistrarDocumentosConsolidados(idDocumento idDocConsolidador, string docConsolidados, string strConx, string LaTablaDoc)
        {
            string ssql =" update " + LaTablaDoc + " set Consolidar = 1, TipDocConsolida ='" + idDocConsolidador.Tipo + "', NroDocConsolida = " + idDocConsolidador.idClave.ToString();
            ssql +=" where doc_sucursal + opc_documento + cast(idclavedoc as string(20)) in " + docConsolidados;
            DattCom.SqlDatos.ejecutarComando(ssql, strConx);
        }
    }
}
