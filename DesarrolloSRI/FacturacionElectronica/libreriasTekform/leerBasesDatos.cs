using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace libreriasTekform
{
    public class leerBasesDatos
    {
        public void leerDocumento(string strConxAdcom, ClassDoc.idDocumento idDoc, string produccion, string proforma, ref DataTable data)
        {
            string ssql = "Dax_tekLeeAdcdoc '" + idDoc.Sucursal + "','" + idDoc.Tipo + "','" + idDoc.numero  + "'," + idDoc.idClave .ToString() + ",'" + produccion + "','" + proforma + "'";
            SqlDataAdapter da;
            da = new SqlDataAdapter(ssql, strConxAdcom);
            da.Fill(data);
            da.Dispose();
        }
        public void leerConsulta(string strConxDatos, ClassDoc.idDocumento idDoc, ref DataTable data, string NombreConsulta)
        {
            string ssql = "";
            if (NombreConsulta.Substring( 0, 1) == "&")
                ssql = NombreConsulta.Substring(1) + " " + idDoc.idClave  + ",'" + idDoc.Sucursal + "','" + idDoc.Tipo  + "'," + idDoc.numero.ToString();
            else
                ssql = "SELECT * FROM " + NombreConsulta;
            SqlDataAdapter da;
            da = new SqlDataAdapter(ssql, strConxDatos);
            da.Fill(data);
            da.Dispose();
        }
        public void leerRenglones(string strConxAdcom, ClassDoc.idDocumento idDoc, string produccion, string proforma, ref DataTable data)
        {
            string ssql = "Dax_tekLeeAdcTra '" + idDoc.Sucursal + "','" + idDoc.Tipo + "'," + idDoc.idClave.ToString() + ",'" + produccion + "','" + proforma + "'";
            SqlDataAdapter da;
            da = new SqlDataAdapter(ssql, strConxAdcom);
            da.Fill(data);
            da.Dispose();
        }
        public void leerBeneficiario(string strConxAdcom, string codBeneficiario, ref DataTable data)
        {
            string ssql = "Dax_tekLeeIdent '" + codBeneficiario + "'";
            SqlDataAdapter da;
            da = new SqlDataAdapter(ssql, strConxAdcom);
            da.Fill(data);
            da.Dispose();
        }
        public void leerSucursalR(string strConxDaxsys, string codEmpresa, string codSucursal, ref DataTable data)
        {
            string ssql = "select * from emp_suc where suc_codigo = '" + codSucursal + "' and emp_codigo = " + codEmpresa;
            SqlDataAdapter da;
            da = new SqlDataAdapter(ssql, strConxDaxsys);
            da.Fill(data);
            da.Dispose();
        }
        // Public Sub leerBodega(strConxDaxsys As String, codEmpresa As String, codBodega As String, ByRef data As DataTable)
        // Dim ssql As String = "select * from emp_suc where suc_codigo = '" + codSucursal + "' and emp_codigo = " + codEmpresa
        // Dim da As SqlDataAdapter
        // da = New SqlDataAdapter(ssql, strConxDaxsys)
        // da.Fill(data)
        // da.Dispose()
        // End Sub
        public void leerPagos(string strConxAdcom, string NombreBaseIvaret, ClassDoc.idDocumento idDoc, string produccion, string proforma, ref DataTable data)
        {
            string ssql = "DAX_LEEPAGO '" + NombreBaseIvaret + "','" + idDoc.Sucursal + "','" + idDoc.Tipo + "'," + idDoc.idClave.ToString() + ",'" + proforma + "'";
            SqlDataAdapter da;
            da = new SqlDataAdapter(ssql, strConxAdcom);
            da.Fill(data);
            da.Dispose();
        }
        // Public Sub leerCuotas(strConxAdcom As String, docSucursal As String, tipDocumento As String, idclavedoc As Double, produccion As String, proforma As String, ByRef data As DataTable)
        // 'Dim ssql As String = "DAX_LEEPAGO '" + NombreBaseIvaret + "','" + docSucursal + "','" + tipDocumento + "'," + idclavedoc.ToString() + ",'" + proforma + "'"
        // Dim da As SqlDataAdapter
        // da = New SqlDataAdapter(ssql, strConxAdcom)
        // da.Fill(data)
        // da.Dispose()
        // End Sub
        public void leerRetenciones(string strConxAdcom, ClassDoc.idDocumento idDoc, string produccion, string proforma, ref DataTable data)
        {
            string ssql = "Dax_tekLeeAdcsri '" + idDoc.Sucursal + "','" + idDoc.Tipo + "'," + idDoc.idClave.ToString();
            // Dim ssql As String = "SELECT * FROM adcsri WHERE sri_sucursal = '" + docSucursal + "' AND sri_DOCUMENTO = '" + tipDocumento + "' AND idclavedoc = " + idclavedoc.ToString() + " order by SRI_TIPORET "
            SqlDataAdapter da;
            da = new SqlDataAdapter(ssql, strConxAdcom);
            da.Fill(data);
            da.Dispose();
        }
        public void leerContabilidad(string strConxAdcom, ClassDoc.idDocumento idDoc, string produccion, string proforma, ref DataTable data)
        {
            string ssql = "Dax_tekLeeAdcCtb '" + idDoc.Sucursal + "','" + idDoc.Tipo + "'," + idDoc.idClave.ToString();
            SqlDataAdapter da;
            da = new SqlDataAdapter(ssql, strConxAdcom);
            da.Fill(data);
            da.Dispose();
        }
        public void leerBanco(string strConxAdcom, ClassDoc.idDocumento idDoc,  DataTable data)
        {
            string ssql = "Dax_tekLeeBcos '" + idDoc.Sucursal + "','" + idDoc.Tipo + "'," + idDoc.idClave.ToString();
            SqlDataAdapter da;
            da = new SqlDataAdapter(ssql, strConxAdcom);
            da.Fill(data);
            da.Dispose();
        }
        public void leerVendedor(string strConxAdcom, string docVendedor, ref DataTable data)
        {
            string ssql = "Dax_tekLeeVendor '" + docVendedor + "'";
            SqlDataAdapter da;
            da = new SqlDataAdapter(ssql, strConxAdcom);
            da.Fill(data);
            da.Dispose();
        }
    }

}
