using System;
using System.Data;
using System.Data.SqlClient;

namespace libreriasTekform
{
    public class GenDatos
    {
        private DataTable ColData = new DataTable();
//        private string Sistema;

        public GenDatos(string strSys)
        {
            string ssql = "select * from sys_data";
            SqlDataAdapter da = new SqlDataAdapter(ssql, strSys);
            da.Fill(ColData);
        }

        public DatVariable QueDato(string NumeroDato)
        {
            DatVariable eldato = new DatVariable();
            if (NumeroDato.Substring(0, 1) == "D")
                NumeroDato = NumeroDato.Substring (1);
            DataRow[] dt;
            dt = ColData.Select("dat_numero = " + NumeroDato);
            if (dt.Length == 0)
                return eldato;
            eldato.DatArch = System.Convert.ToDecimal(dt[0]["tabla"]);
            eldato.DatNombre = dt[0]["dat_Nombre"].ToString();
            eldato.DatNumero = System.Convert.ToDecimal(dt[0]["dat_Numero"]);
            eldato.DattVariable = dt[0]["dat_Variable"].ToString();
            return eldato;
        }
        public string QueCampo(string NumeroDato)
        {
            if (NumeroDato.Substring(0, 1) != "D")
                return NumeroDato;
            string campo = NumeroDato.Substring(1);
            try
            {
                double datoNum = Convert.ToDouble(campo);
            }
            catch
            {
                return NumeroDato;
            }
            DataRow[] dt;
            dt = ColData.Select("dat_numero = " + campo);
            if (dt.Length == 0) return "";
            return dt[0]["dat_Variable"].ToString();
        }
    }


}
