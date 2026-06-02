using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using DattCom;
namespace Syscod
{
    public class ManSysnetClass
    {
        public void ManSyscodd(string Nombre, bool fijo = false)
        {
            try
            {
                frmSyscod progm = new frmSyscod();
                progm.Referencias(Nombre, fijo);
                progm.Dispose();
            }
            catch (Exception ee)
            {
                MessageBox.Show("Excepcion en mantenimiento Syscod \n" +  ee.Message);
            }
        }

        public string BuscarReferencia(ref string TipoReferencia, ref string Codigo, ref string Descripcion)
        {
            string Referencia = "";
            if (TipoReferencia == "")  return "";
            try
            {
                frmBuscarTipoRef prog = new frmBuscarTipoRef();
                Referencia = prog.BuscarTipoRef(TipoReferencia, ref Codigo, ref Descripcion);
                prog.Dispose();
            }
            catch (Exception E)
            {
                MessageBox.Show ("EXCEPCION BUSCANDO REFERENCIA REF: \n" + E.Message);
            }
            return Referencia;
        }

        public string NvoTipoReferencia(string Ref)
        {
            if (Ref == "") return "";
            frmNuevoTipo prog = new frmNuevoTipo(Ref);
            prog.TipoReferencia(Ref);
            prog.Dispose();
            return Ref;
        }

        public string QueNombre(string Codigo, string Tipo)
        {
            if (Codigo == "" | Tipo == "")
                return "";
            string descripcion = "";
            SqlConnection conectar = new SqlConnection(datosEmpresa.strConxSyscod);
            conectar.Open();
            string ssql = "Select Descripcion from syscod where TipoReferencia='" + Tipo + "' and Abreviación='" + Codigo + "'";
            SqlCommand cmd = new SqlCommand(ssql, conectar);
            SqlDataReader dat;
            //conectar.Open();
            dat = cmd.ExecuteReader();
            if (dat.Read())
            {
                if (dat[0]==null)
                    descripcion = "";
                else
                    descripcion = dat[0].ToString();
            }
            else
                descripcion = "";
            conectar.Close();
            return descripcion;
        }

        public string QueCodigo(string Nombre, string Tipo)
        {
            if (Nombre == "" | Tipo == "") return "";
            string descripcion = "";
            SqlConnection conectar = new SqlConnection(datosEmpresa.strConxSyscod);
            conectar.Open();
            string ssql = "Select Abreviación from syscod where TipoReferencia='" + Tipo + "' and Descripcion ='" + Nombre + "'";
            SqlCommand cmd = new SqlCommand(ssql, conectar);
            SqlDataReader dat;
            dat = cmd.ExecuteReader();
            if (dat.Read())
            {
                if (dat[0]==null) descripcion = "";
                else
                    descripcion = dat[0].ToString();
            }
            else
                descripcion = "";
            conectar.Close();
            return descripcion;
        }
    }
}

