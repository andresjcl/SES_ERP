using System.Data;
using System.Data.SqlClient;

namespace libreriasTekform
{
    public class leerBasesDatos
    {
        public int  leerDocumento(string strConxAdcom, ClassDoc.idDocumento idDoc, string produccion, string proforma, ref DataTable data)
        {
            string ssql = "Dax_tekLeeAdcdoc '" + idDoc.Sucursal + "','" + idDoc.Tipo + "','" + idDoc.numero  + "'," + idDoc.idClave .ToString() + ",'" + produccion + "','" + proforma + "'";
            return leerBase(ssql, strConxAdcom, ref data);
        }
        public int leerConsulta(string strConxAdcom, ClassDoc.idDocumento idDoc, ref DataTable data, string NombreConsulta)
        {
            string ssql = "";
            if (NombreConsulta.Substring( 0, 1) == "&")
                ssql = NombreConsulta.Substring(1) + " " + idDoc.idClave  + ",'" + idDoc.Sucursal + "','" + idDoc.Tipo  + "'," + idDoc.numero.ToString();
            else
                ssql = "SELECT * FROM " + NombreConsulta;
            return leerBase(ssql, strConxAdcom, ref data);
        }
        public int leerRenglones(string strConxAdcom, ClassDoc.idDocumento idDoc, string produccion, string proforma, ref DataTable data)
        {
            string ssql = "Dax_tekLeeAdcTra '" + idDoc.Sucursal + "','" + idDoc.Tipo + "'," + idDoc.idClave.ToString() + ",'" + produccion + "','" + proforma + "'";
            return leerBase(ssql, strConxAdcom, ref data);
        }
        public int leerBeneficiario(string strConxAdcom, string codBeneficiario, ref DataTable data)
        {
            string ssql = "Dax_tekLeeIdent '" + codBeneficiario + "'";
            return leerBase(ssql, strConxAdcom, ref data);
        }
        public int leerSucursalR(string strConxDaxsys, string codEmpresa, string codSucursal, ref DataTable data)
        {
            string ssql = "select * from emp_suc where suc_codigo = '" + codSucursal + "' and emp_codigo = " + codEmpresa;
            return leerBase(ssql, strConxDaxsys, ref data);
        }
        public int leerPagos(string strConxAdcom, string NombreBaseIvaret, ClassDoc.idDocumento idDoc, string produccion, string proforma, ref DataTable data)
        {
            string ssql = "DAX_LEEPAGO '" + NombreBaseIvaret + "','" + idDoc.Sucursal + "','" + idDoc.Tipo + "'," + idDoc.idClave.ToString() + ",'" + proforma + "'";
            return leerBase(ssql, strConxAdcom, ref data);
        }
        public int leerRetenciones(string strConxAdcom, ClassDoc.idDocumento idDoc, string produccion, string proforma, ref DataTable data)
        {
            string ssql = "Dax_tekLeeAdcsri '" + idDoc.Sucursal + "','" + idDoc.Tipo + "'," + idDoc.idClave.ToString();
            return leerBase(ssql, strConxAdcom, ref data);
        }
        public int leerContabilidad(string strConxAdcom, ClassDoc.idDocumento idDoc, string produccion, string proforma, ref DataTable data)
        {
            string ssql = "Dax_tekLeeAdcCtb '" + idDoc.Sucursal + "','" + idDoc.Tipo + "'," + idDoc.idClave.ToString();
            return leerBase(ssql, strConxAdcom, ref data);
        }
        public int leerBanco(string strConxAdcom, ClassDoc.idDocumento idDoc,  DataTable data)
        {
            string ssql = "Dax_tekLeeBcos '" + idDoc.Sucursal + "','" + idDoc.Tipo + "'," + idDoc.idClave.ToString();
            return leerBase(ssql, strConxAdcom, ref data);
        }
        public int leerVendedor(string strConxAdcom, string docVendedor, ref DataTable data)
        {
            string ssql = "Dax_tekLeeVendor '" + docVendedor + "'";
            return leerBase(ssql, strConxAdcom, ref data);
        }
        private int leerBase(string ssql, string strConxData, ref DataTable data)
        {
            int stat = 2;
            data = new DataTable() ;
            using (SqlDataAdapter da = new SqlDataAdapter(ssql, strConxData))
            {
                da.Fill(data);
                if (data.Rows.Count > 0) stat = 1;
            }
            return stat;
        }
    }

}
