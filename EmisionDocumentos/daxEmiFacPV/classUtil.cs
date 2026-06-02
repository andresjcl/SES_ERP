using System;
using System.Data;
using System.Linq;
using System.Text;

namespace adcDocumentos
{
    class classUtil
    {
        static internal string LeerPatDeImagenes()
        {
            string pathImagenes = "";
            DataTable dt = DattCom.datosEmpresa.leeParametrosEmp("Emp_PathImagenes");
            if (dt.Rows.Count > 0)
            {
                pathImagenes = "" + dt.Rows[0]["Emp_PathImagenes"].ToString();
            }
            return pathImagenes;
        }
    }
}
