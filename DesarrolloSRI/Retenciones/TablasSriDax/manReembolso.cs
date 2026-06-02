using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace IvaRett 
{
    public class manReembolso
    {
        public string suc; 
        public string doc; 
        public string estab; 
        public string ptovta; 
        public string num; 
        public double idclavedoc; 
        public string strConx; 
        public string strSys; 

        public void ingresarReembolso()
        {
            if (strConx == "" || strSys == "") return;
            MntReembolso frmReem = new MntReembolso();
            frmReem.sucursal = suc;
            frmReem.tipoDoc = doc;
            frmReem.estab = estab;
            frmReem.ptovta = ptovta;
            frmReem.num = num;
            frmReem.idClaveDoc = idclavedoc;
            frmReem.strConxAdcom = strConx;
            frmReem.strConxIvaret = strSys;
            frmReem.btnCerrar.Visible = true;
            frmReem.btnContinuar.Visible = false;
            frmReem.btnGraba.Visible = true;
            frmReem.ShowDialog();
            frmReem.Dispose();
        }
        //public void newReembolso(string Rsuc, string Rdoc, string Restab, string Rptovta, string Rnum, double Ridclavedoc, string RstrConx, string RstrSys)
        //{
        //    detalleReembolso = new DataTable();
        //    suc = Rsuc;
        //    doc = Rdoc;
        //    estab = Restab;
        //    ptovta = Rptovta;
        //    num = Rnum;
        //    idclavedoc = Ridclavedoc;
        //    strConx = RstrConx;
        //    strSys = RstrSys;
        //}
        //public void grabarReembolsos()
        //{
        //    if (revisarData())
        //    {
        //        try
        //        {
        //            string ssql = " select * from adcdocreemb where doc_sucursal = '" + suc + "' and opc_documento = '" + doc + "' ";
        //            ssql += " and idclavedoc = " + idclavedoc.ToString();
        //         //   DataTable dtb = new DataTable();
        //            SqlDataAdapter da = new SqlDataAdapter(ssql, strConx);
        //           // da.Fill(dtb);
        //           // dtb.Rows.Clear();
        //           // foreach (DataRow row in detalleReembolso.Rows)
        //           // {
        //           //     dtb.Rows.Add(row);
        //            //}
        //            SqlCommandBuilder cb = new SqlCommandBuilder(da);
        //            da.Update(detalleReembolso);
        //            cb.Dispose();
        //            da.Dispose();
        //        }
        //        catch (Exception ee) { MessageBox.Show(ee.Message ); }
        //    }            
        //}

        //private Boolean revisarData()
        //{
        //    if (idclavedoc == 0 || detalleReembolso.Rows.Count  == 0) return false;
        //    if (detalleReembolso.Rows[0]["idProvReemb"] == null) return false;

        //    foreach (DataRow row in detalleReembolso.Rows)
        //    {
        //        row["Doc_sucursal"] = suc;
        //        row["idClaveDoc"] = idclavedoc;
        //        row["Opc_documento"] = doc;
        //        row["estado"] = 0;
        //    }
        //    return true;
        //}

    }
}
