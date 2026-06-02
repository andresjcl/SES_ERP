using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DaxEnvDocElec
{
    class conexionDatos
    {
        static public string strConxDaxsys
        {
            get { return "Persist Security Info=False; Trusted_Connection=True; database = Daxsys; Server = (local)"; }
    }

        static private string _strConxAdcom;
        static public string strConxAdcom
        {
            get { return "Persist Security Info=False; Trusted_Connection=True; database = " + _strConxAdcom + "; Server = (local)"; }
            set { _strConxAdcom = value; }
        }
        static private string _strConxIvaret;
        static public string strConxIvaret
        {
            get { return "Persist Security Info=False; Trusted_Connection=True; database = " + _strConxIvaret + "; Server = (local)"; }
            set { _strConxIvaret = value; }
        }
        static public DataTable listaDocumentos()
        {
            string ssql = "select IdclaveDoc,Doc_fecha,Doc_Numero,Doc_Sucursal,Opc_documento,Doc_TipoDoc,Doc_CodPer,estadoSri from adcdoc ";
            ssql += "where doc_tipodoc in ('FAC','RTC','REM','NDC','NCC','DEV') ";
            ssql += "AND isnull(Adi_TipoDocSri,0)>0 and  isnull(estadoSri,'') <> 'Autorizado'";
            DataTable dt = new DataTable();
            try
            {
                using (SqlDataAdapter da = new SqlDataAdapter(ssql, strConxAdcom))
                {
                    da.Fill(dt);
                }
            }
            catch (Exception ex) 
            { Console.Write ( ex.Message) ;             
                dt = null;
                int lon = ex.Message.Length;
                if (lon > 250) lon = 250;
                registraEvntos.registrar.registraEventoMail(strConxDaxsys, "0", "sys", "EnvDocElec", "SERVIDOR", "LeerDocumentos", ex.Message.Substring(0, lon));
            }
            return dt;
        }
        public static DataTable leerDatos(string ssql, string strConxadcom)
        {
            using (SqlDataAdapter adp = new SqlDataAdapter(ssql, strConxadcom))
            {
                DataTable ds = new DataTable();
                adp.Fill(ds);
                return ds;
            }
        }
    }
}
