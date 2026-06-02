using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace DaxMedic
{
    static public class MedDatosPaciente
    {

        public static string nombres = "";
        public static string direccion = "";
        public static string telefono1 = "";
        public static string telefono2 = "";
        public static string CorreoElect = "";
        public static string NroHistoria = "";
        public static string codigoPaciente = "";
        public static string CedulaIdentidad = "";
        public static DateTime FechaNacimiento = new DateTime(1900, 1, 1);
        public static string sexo = "";
        public static string TipoSangre = "";
        public static string CodDoctorEnCurso = "";
        public static string imagen = "";

        //public static string CedulaIdentidad 
        //{ 
        //    get => cedulaIdentidad; 
        //    set 
        //    {
        //        if (value.Length > 10)
        //            cedulaIdentidad = value.Substring(value.Length - 10);
        //        else cedulaIdentidad = value;
        //    }
        //}
        static public void cargarDatos(string codigo,string strConxAdcom)
        {
            string sel = "select codigo, CedulaIdentidadRuc,HistoriaClinica,NombreImpresion,Domicilio,Telefono1,Telefono2,CorreoElectrónico, fechaNacimiento, sexo,TipoSangre,logotipo ";
                   sel += " from identificacion left join Personal on Codigo = CodigoPer ";
                   sel += " where codigo = '"+ codigo + "' or CedulaIdentidadRuc = '"+codigo+"'";
            using (SqlDataAdapter da = new SqlDataAdapter(sel, strConxAdcom))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    nombres = row["NombreImpresion"].ToString();
                    direccion = row["Domicilio"].ToString();
                    telefono1 = row["Telefono1"].ToString();
                    telefono2 = row["Telefono2"].ToString();
                    CorreoElect = row["correoElectrónico"].ToString();
                    NroHistoria = row["HistoriaClinica"].ToString();
                    codigoPaciente = row["codigo"].ToString();
                    CedulaIdentidad = row["CedulaIdentidadRuc"].ToString();
                    imagen = row["Logotipo"].ToString();
                    if (NroHistoria.Length == 0) NroHistoria = CedulaIdentidad;
                    try
                    {
                        FechaNacimiento = Convert.ToDateTime(row["fechaNacimiento"].ToString());
                    }catch { }
                    sexo = row["Sexo"].ToString();
                    TipoSangre = row["TipoSangre"].ToString();
                }
                dt.Dispose();                
            }
        }

       public static DataTable PacientesConTurnoMédico(string codigoMedico,string codigoEspeciald, string fecha,string strConxAdcom)
        {
            string sel = "select NroTurno as Turno,NombreImpresion,Ubicacion,CodPaciente from adccit left join identificacion on CodPaciente = codigo";
            sel += " where fecha = '" + fecha + "' and estado <> 'Consulta' ";
            if (codigoMedico.Length > 0) sel += " and codmed = '" + codigoMedico + "'";
            if (codigoEspeciald.Length > 0) sel += " and isnull(codesp,'') = '" + codigoEspeciald + "'";
            sel += " order by NroTurno ";
            using (SqlDataAdapter da = new SqlDataAdapter(sel,strConxAdcom))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        public static void diseñarMalla(DataGridView malla)
        {
            malla.Columns["CodPaciente"].Visible = false;
            malla.RowHeadersVisible = false;
            malla.Columns["Turno"].Width = 35;
            malla.Columns["NombreImpresion"].Width = 240;
            malla.Columns["Ubicacion"].Width = 90;
        }

    }
}
