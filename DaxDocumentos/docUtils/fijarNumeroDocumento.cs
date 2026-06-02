using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace adcDocumentos
{
    public class fijarNumeroDocumento
    {
        //public double nroDeDocumento( string laTabla,string reglaDuplicacion, Boolean autoNumeracion, ClassDoc.idDocumento idDoc, string strDax, string bod,string codper)  // regresa el numero del documento 
        //{
        //    double nroDocumento =  numeroDoc;
        //    string[] Campos;
        //    string VerificaDuplicado = "";
        //    Boolean existe = true;
        //    Int32 veces = 0;
        //    if (reglaDuplicacion != "")
        //    {
        //        Campos = reglaDuplicacion.Split(Convert.ToChar (","));
        //        try
        //        {
        //            if (Campos[0] == "S") VerificaDuplicado = " AND DOC_BODEGA = '" + bod + "' ";
        //            if (Campos[1] == "S") VerificaDuplicado += " AND Doc_codper = '" + codper + "' ";
        //            if (Campos[2] == "S") VerificaDuplicado += " AND Doc_NroIdDoc = '" + nroIdDoc + "' ";
        //        }
        //        catch { }
        //    }

        //    string CodSql = "";
        //    SqlDataReader dr ;
        //    SqlCommand comm = new SqlCommand();
        //    SqlConnection conn = new SqlConnection(strDax);
        //    conn.Open();

        //    do
        //    {
        //        CodSql = "SELECT  idclavedoc FROM  " + laTabla + "  WHERE doc_sucursal='" + suc + "' and opc_documento='" + tipoDoc + "' and doc_numero=" + nroDocumento + VerificaDuplicado;
        //        comm = new SqlCommand(CodSql,conn);
        //        dr = comm.ExecuteReader();
        //        if (dr.HasRows == true)
        //        {
        //            if (autoNumeracion == false) 
        //            {
        //                comm.Dispose();
        //                dr.Close();
        //                dr.Dispose();

        //                if (MessageBox.Show("El documento " + tipoDoc  + "-" + nroDocumento   + " ya existe, desea que se guarde con otro número ?","Grabación de documentos",  MessageBoxButtons.YesNo ,  MessageBoxIcon.Question ) == DialogResult.No)  
        //                {
        //                    return 0;
        //                }
        //            }
        //            nroDocumento = OtroNumero(laTabla, suc ,tipoDoc , VerificaDuplicado,strDax);
        //        }
        //        else
        //        {
        //                    existe = false;
        //        }
        //        veces++;
        //        if (veces > 80) 
        //        {
        //            MessageBox.Show ("El documento no se puede guardar con el número escojido \n" + "Inténte nuevamente con otro número","Grabacion documentos", MessageBoxButtons.OK , MessageBoxIcon.Error);
        //            return 0;
        //        }
        //    } while (existe == true);
        //    return nroDocumento;
        //}

        //private double OtroNumero(string LaTabla, string Suc, string Tip, string Adicional, string conx)
        //{
        //    double numero = 1;
        //    string CodSql = "SELECT max(DOC_NUMERO) as doc_numero FROM  " + LaTabla + "  WHERE doc_sucursal='" + Suc + "' and opc_documento='" + Tip + "' " + Adicional;
        //    DataTable rs = new DataTable();
        //    SqlDataAdapter da = new SqlDataAdapter(CodSql,conx);
        //    da.Fill(rs);
        //    if (rs.Rows.Count > 0)
        //    {
        //        double.TryParse(rs.Rows[0]["Doc_numero"].ToString(), out numero);
        //        numero++;
        //    }
        //    rs.Dispose();
        //    da.Dispose();
        //    return numero;
        //}
    }
}
