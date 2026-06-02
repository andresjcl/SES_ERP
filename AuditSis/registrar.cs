using System;
using System.Data;
using System.Data.SqlClient;

namespace AuditSis
{
	public class registrar
    {
        public static string EvntCrear = "CREAR";
        public static string EvntModifica = "MODIFICCAR";
        public static string EvntElimina = "ELIMINAR";
        public static string EvntAnula = "ANULAR";
        static public void registraEventoUser(string strConIniSis, string Empresa, string IdUsuario, string Sistema, string Maquina, string idOpcion, string Valor, string Rfecha = "1900/01/01")
        {
            if (strConIniSis == "") return;
            ClassEvnts datosSys = new ClassEvnts(strConIniSis);
            datosSys.Empresa = Convert.ToInt64("0" + Empresa);
            datosSys.Equipo = Maquina;

            datosSys.Fecha = lahora(strConIniSis);
            datosSys.Sistema = Sistema;
            datosSys.Tipo = "US";
            datosSys.Usuario = IdUsuario;
            datosSys.Valor = Valor;
            datosSys.Sys1 = idOpcion;
            datosSys.Crear();
            datosSys = null;
        }
        static public void registraEventoDoc(string strConIniSis, string Empresa, string IdUsuario, string Sistema, string Maquina, string Evento, string docSucursal, string docTipo, string docNumero, string Valor, string Rfecha = "1900/01/01")
        {
            if (strConIniSis == "") return;
            ClassEvnts datosSys = new ClassEvnts(strConIniSis);
            datosSys.Fecha = lahora(strConIniSis);
            string Documento = docSucursal + "--" + docTipo + "--" + docNumero;
            datosSys.Empresa = Convert.ToInt64("0" + Empresa);
            datosSys.Equipo = Maquina;
            datosSys.Fecha = Convert.ToDateTime(DateTime.Now);
            datosSys.Sistema = Sistema;
            datosSys.Tipo = "DO";
            datosSys.Usuario = IdUsuario;
            datosSys.Valor = Valor;
            datosSys.DocSucursal = docSucursal;
            datosSys.DocTipo = docTipo;
            datosSys.DocNumero = docNumero;
            datosSys.Sys1 = Evento;
            datosSys.Crear();
            datosSys = null;
        }
        static public void registraEventoMail(string strConIniSis, string Empresa, string IdUsuario, string Sistema, string Maquina, string Modulo, string Valor, string Rfecha = "1900/01/01")
        {
            if (strConIniSis == "") return;
            ClassEvnts datosSys = new ClassEvnts(strConIniSis);
            datosSys.Fecha = lahora(strConIniSis);
            datosSys.Empresa = Convert.ToInt64("0" + Empresa);
            datosSys.Equipo = Maquina;
            datosSys.Fecha = Convert.ToDateTime(Rfecha);
            datosSys.Sistema = Sistema;
            datosSys.Tipo = "ML";
            datosSys.Usuario = IdUsuario;
            datosSys.Valor = Valor;
            datosSys.Crear();
            datosSys.Sys1 = Modulo;
            datosSys = null;
        }
        static public void registraPreferencia(string strConIniSis, string Empresa, string IdUsuario, string Sistema, string Sucursal, string Modulo, string Opcion, string Valor, string Rfecha = "1900/01/01")
        {
            if (strConIniSis == "") return;
            ClassEvnts datosSys = new ClassEvnts(strConIniSis);
            datosSys.Fecha = lahora(strConIniSis);
            string ssql = " select * from sysEvnts where empresa = '" + Empresa + "' and  Tipo = 'PR' and Usuario = '" + IdUsuario + "'";
            ssql += " and Sistema = '" + Sistema + "'";
            ssql += " and Sys1 ='" + Modulo + "' and Sys2 ='" + Opcion + "'";
            datosSys.Empresa = Convert.ToInt64("0" + Empresa);
            datosSys.Fecha = Convert.ToDateTime(Rfecha);
            datosSys.Sistema = Sistema;
            datosSys.Tipo = "PR";
            datosSys.Usuario = IdUsuario;
            datosSys.Valor = Valor;
            datosSys.Sys1 = Modulo;
            datosSys.Sys2 = Opcion;
            datosSys.Actualizar(ssql);
            datosSys = null;
        }


        static public string obtenerPreferencia(string strConIniSis, string Empresa, string IdUsuario, string Sistema, string Sucursal, string Modulo, string Opcion)
        {
            if (strConIniSis == "") return "";
            string ssql = " select isnull(Valor,'') as Valor from sysEvnts where empresa = '" + Empresa + "' and  Tipo = 'PR' and Usuario = '" + IdUsuario + "'";
            ssql += " and Sistema = '" + Sistema + "' ";
            ssql += " and Sys1 ='" + Modulo + "' and Sys2 ='" + Opcion + "'";
            using (SqlDataAdapter da = new SqlDataAdapter(ssql, strConIniSis))
            {
                using (DataTable dt = new DataTable())
                {
                    da.Fill(dt);
                    if (dt.Rows.Count == 0) { return ""; }
                    else { return dt.Rows[0]["Valor"].ToString(); }
                }
            }
        }
        static DateTime lahora(string strConIniSis)
        {
            string ssqlHora = "select GETDATE()";
            using (SqlConnection conn = new SqlConnection(strConIniSis))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand(ssqlHora, conn))
                {
                    SqlDataReader dr = comm.ExecuteReader();
                    if (dr.Read()) { return Convert.ToDateTime(dr[0]); }
                    else { return DateTime.Now; }
                }
            }
        }
    }
}
