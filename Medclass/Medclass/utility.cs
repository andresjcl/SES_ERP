using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace DaxMedic
{
    public static class utility
    {
        //public static void CargaComboGrupoMedico(ComboBox combo,string strConxAdcom)
        //{
        //    string ssql = "";

        //    //If todos Then ssql = "select ' Todos' as Descripcion, '0' as Abreviación union all "
        //    ssql += "select abreviación,Descripcion from syscod where TipoReferencia  = 'GrupoConceptos' and caracteristica1 = 'D'";
        //    ssql += " order by Descripcion ";
        //    DataTable dat = new DataTable();
        //    SqlDataAdapter da = new SqlDataAdapter(ssql, strConxAdcom);
        //    da.Fill(dat);
        //    combo.DataSource = dat;
        //    combo.DisplayMember = "Descripcion";
        //    combo.ValueMember = "Abreviación";            
        //}
        public static string EdadExacta(this DateTime fechaNacimiento)
        {
            DateTime hoy = DateTime.Today;

            int meses = hoy.Month - fechaNacimiento.Month;
            int años = hoy.Year - fechaNacimiento.Year;

            if (hoy.Day < fechaNacimiento.Day)
            {
                meses--;
            }

            if (meses < 0)
            {
                años--;
                meses += 12;
            }

            int dias = (hoy - fechaNacimiento.AddMonths((años * 12) + meses)).Days;

            return string.Format("{0} año{1}, {2} mes{3} y {4} dia{5}",
                                    años, (años == 1) ? "" : "s",
                                    meses, (meses == 1) ? "" : "es",
                                    dias, (dias == 1) ? "" : "s");
        }
        public static string EdadAñoMes(this DateTime fechaNacimiento)
        {
            DateTime hoy = DateTime.Today;

            int meses = hoy.Month - fechaNacimiento.Month;
            int años = hoy.Year - fechaNacimiento.Year;

            if (hoy.Day < fechaNacimiento.Day)
            {
                meses--;
            }

            if (meses < 0)
            {
                años--;
                meses += 12;
            }

            int dias = (hoy - fechaNacimiento.AddMonths((años * 12) + meses)).Days;

            return string.Format("{0}a {1}m",años,meses);
        }
        public static void CargaComboMedicos(ComboBox combo, string strConxAdcom, Boolean todos = false)
        {
            string ssql = "select * from (";
            if (todos) ssql += " select '0' as Codigo, ' Todos' as NombreIMpresion union all ";
            ssql += " select  Codigo, NombreImpresion  from adclisDr ";
            ssql += " Group by Codigo, NombreImpresion ";
            ssql += ") r1 order by nombreImpresion ";
            DataTable dat = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(ssql, strConxAdcom);
            da.Fill(dat);
            combo.DataSource = dat;
            combo.DisplayMember = "NombreImpresion";
            combo.ValueMember = "Codigo";
        }

        public static void CargaComboMedicoEspecialidad(ComboBox combo, string strConxAdcom,string citaMedica ="N",Boolean todos = false)
        {
            string ssql = "";
            if (todos) ssql = "select '0;;'AS idDoctor,' Todos' as NombreYEspecialidad union all ";
            ssql += "select idDoctor,NombreYEspecialidad from adclisdr";
            if (citaMedica == "S") ssql += " where TieneCitaMedica = 'S'";
            ssql += " order by NombreYEspecialidad ";
            DataTable dat = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(ssql, strConxAdcom);
            da.Fill(dat);
            combo.DataSource = dat;
            combo.DisplayMember = "NombreYEspecialidad";
            combo.ValueMember = "idDoctor";
        }
        public static void CargaComboEspecialidad(ComboBox combo, string strConxAdcom, string citaMedica = "N", Boolean todos = false)
        {
            string ssql = "";
            if (todos) ssql = "select '0' AS id,' Todos' as Descripción union all ";
            ssql += "select Abreviación as ID ,Descripcion   ";
            ssql += " from Syscod";
            ssql += " where TipoReferencia = 'especialidad' and Abreviación <> '#' ";
            if (citaMedica == "S") ssql += " and Caracteristica3 = 'S'";
            ssql += " order by Descripción ";
            DataTable dat = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(ssql, strConxAdcom);
            da.Fill(dat);
            combo.DataSource = dat;
            combo.DisplayMember = "Descripción";
            combo.ValueMember = "id";
        }
        public static void CargaComboMedicoCitas(ComboBox combo, string strConxAdcom, string diaCitas, string especialidad)
        {
            string ssql = "SELECT distinct (t.CODIGO + ';' + t.Especialidad) as Codigo, r.Nombre + ' - ' + r.NomEspecialidad as NombreDoctor";
            ssql += " FROM MedTurnDoc t  left join DaxLstDrRub r on t.Codigo = r.Codigo and t.Especialidad = r.Especialidad";
            ssql += " where TipServMedico = 'CON'";
            if (especialidad != "") ssql += " and t.especialidad = '" + especialidad + "' ";
            ssql += " order by NombreDoctor";
            DataTable dat = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(ssql, strConxAdcom);
          da.Fill(dat);
            combo.DataSource = dat;
            combo.DisplayMember = "NombreDoctor";
            combo.ValueMember = "Codigo";
        }
        public static void CargaComboGruposServicios(ComboBox combo, string strConxAdcom, string Nivel, Boolean todos)
        {
            string ssql = "";
            string cat = "1";
            if (Nivel == "CL") cat = "2";
            else if (Nivel == "G") cat = "3";
            else if (Nivel == "S") cat = "4";

            if (todos) ssql += "select ' Todo' as Niv_nombre, '0' as Niv_abrevia union all ";

            ssql += "select Niv_nombre, Niv_abrevia from AdcNivSERV where Niv_categor = '" + cat + "' and niv_abrevia <> '#'";
            ssql += " order by niv_Nombre ";
            DataTable dat = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(ssql, strConxAdcom);
            da.Fill(dat);
            combo.DataSource = dat;
            combo.DisplayMember = "Niv_nombre";
            combo.ValueMember = "Niv_abrevia";
        }
        public static string CodMedicoEspeciald(string CodMedico, string strConxAdcom)
        {
            string ssql = "select idDoctor from adclisdr where codigo = '"+CodMedico +"'";
            SqlDataReader dr = DattCom.SqlDatos.leerBase(ssql, strConxAdcom);
            ssql = "";
            if (dr.Read()) ssql = dr["idDoctor"].ToString();
            return ssql;            
        }
        public static void ActualizarUbicacionCitas(string ubicacion, string strConxAdcom, decimal IdClaveCit)
        {
            string ssql = "update medCitas set Ubicacion = '" + ubicacion + "' where idclave = " + IdClaveCit.ToString();
            DattCom.SqlDatos.ejecutarComando(ssql, strConxAdcom);
        }
    }
}
