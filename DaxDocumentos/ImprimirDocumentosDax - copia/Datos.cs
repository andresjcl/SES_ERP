using System;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ImpresionDocumentosDax
{
    class Datos
    {
        internal static Int32 LeerNroImpresiones(ClassDoc.idDocumento iddoc, string strConxAdcom)
        {
            string ssql = "select isnull(doc_adicional1,0) as impresiones from adcdoc where doc_sucursal = '" + iddoc.Sucursal  + "' and opc_documento = '" + iddoc.Tipo  + "' and idclavedoc = " + iddoc.idClave.ToString();
            SqlDataReader dr = DattCom.SqlDatos.leerBase(ssql,strConxAdcom);
            Int32 impre = 0;
            if (dr.Read()) { impre = Convert.ToInt16(dr["impresiones"]); }
            dr.Close();
            return impre;
    }
    }
}
