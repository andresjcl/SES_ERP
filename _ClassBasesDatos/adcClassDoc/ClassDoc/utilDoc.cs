using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace ClassDoc
{
    public class utilDoc
    {
        //public string Doc_sucursal = string.Empty;
        //public string Opc_documento = string.Empty;
        //public string propietario = string.Empty;
        //public string bodega = string.Empty;
        //public string idsri = string.Empty;
        //public Boolean esNroMultiple = false;
        //public string elEmisor = string.Empty;
        //static public string cadenaConexion = string.Empty;

        //private string controlDuplicacion = string.Empty;

        //private controlNumeracion ctrlNumera = new controlNumeracion();

        //public utilDoc(string conx, string sucursal = "", string tipDoc = "", string codCliProov = "", string Bodega = "", string IdSri = "", string emisor = "")
        //{
        //    cadenaConexion = conx;
        //    Doc_sucursal = sucursal;
        //    Opc_documento = tipDoc;
        //    propietario = codCliProov;
        //    Bodega = bodega;
        //    idsri = IdSri;
        //    armarControlNumeracion();
        //}
        //public double nuevoIdclave(string Doc_sucursal, string Opc_Documento, string tabla)
        //{
        //    double clave = 0;
        //    using (SqlConnection cnn = new SqlConnection(cadenaConexion))
        //    {
        //        cnn.Open();
        //        string sel = "select isnull(max(idclavedoc),0) as idclavedoc from " + tabla + " where doc_sucursal = '" + Doc_sucursal + "' and opc_documento ='" + Opc_documento + "'";
        //        SqlCommand comm = new SqlCommand(sel, cnn);
        //        SqlDataReader dr = comm.ExecuteReader();
        //        if (dr.Read()) clave = Convert.ToDouble(dr["idclavedoc"].ToString());
        //        dr.Dispose();
        //        comm.Dispose();
        //    }
        //    return clave + 1;
        //}

        //public double nuevoIdclaveDax(ClassDoc.idDocumento idDoc, string tabla, string Bodega = "")
        //{
        //    double clave = 0;
        //    using (SqlConnection cnn = new SqlConnection(cadenaConexion))
        //    {
        //        cnn.Open();
        //        string sel = "genIdDocProp '" + idDoc.Sucursal + "','" + idDoc.Tipo + "','" + idDoc.Serie + "'," + idDoc.numero.ToString() + "','" + Bodega;
        //        SqlCommand comm = new SqlCommand(sel, cnn);
        //        SqlDataReader dr = comm.ExecuteReader();
        //        if (dr.Read()) clave = Convert.ToDouble(dr["idclavedoc"].ToString());
        //        dr.Dispose();
        //        comm.Dispose();
        //    }
        //    return clave;
        //}

        //public double nuevoNumeroDocumento(string tablaDocto, string lugarEmision = "", string clavMultiNro = "")
        //{
        //    double numeroDoc = 0;
        //    if (controlDuplicacion.Length == 0) { controlDuplicacion = establecerLugar(ref esNroMultiple); }
        //    //
        //    string sel = "select isnull(UltimoNumero,0) as ultimoNumero from adcdocnum where id_lugar = '" + controlDuplicacion + "' ";
        //    sel += " and id_Documento ='" + Opc_documento + "'";
        //    SqlConnection cnn = new SqlConnection(cadenaConexion);
        //    cnn.Open();
        //    SqlCommand comm = new SqlCommand(sel, cnn);
        //    SqlDataReader dr = comm.ExecuteReader();
        //    if (dr.Read()) numeroDoc = Convert.ToDouble(dr["ultimoNumero"].ToString());
        //    comm.Dispose();
        //    dr.Close();
        //    dr.Dispose();

        //    if (numeroDoc > 0)  // verifica que el numero no exista falta controlar por los campos de duplicidad
        //    {
        //        if (documentoExiste(numeroDoc, tablaDocto)) numeroDoc = nuevoNumero(tablaDocto);
        //    }
        //    return numeroDoc + 1;
        //}
        //private bool documentoExiste(double numeroDoc, string tablaDocto)
        //{
        //    bool resp = false;
        //    using (SqlConnection cnn = new SqlConnection(cadenaConexion))
        //    {
        //        cnn.Open();
        //        string sel = "select idclavedoc from " + tablaDocto + " where doc_sucursal = '" + Doc_sucursal + "' ";
        //        sel += " and opc_documento = '" + Opc_documento + "' and doc_numero = " + numeroDoc.ToString();
        //        if (ctrlNumera.porBodega && bodega.Length > 0) { sel = " AND DOC_BODEGA = '" + bodega + "' "; }
        //        if (ctrlNumera.porPropietario && propietario.Length > 0) { sel += " AND Doc_codper = '" + propietario + "' "; }
        //        if (ctrlNumera.porIdSri && idsri.Length > 0) { sel += " AND Doc_NroIdDoc = '" + idsri + "' "; }

        //        using (SqlCommand comm2 = new SqlCommand(sel, cnn))
        //        {
        //            SqlDataReader dr2 = comm2.ExecuteReader();
        //            resp = dr2.HasRows;
        //            dr2.Close();
        //            dr2.Dispose();
        //        }
        //    }
        //    return resp;
        //}
        //private double nuevoNumero(string tablaDocmto)
        //{
        //    string sel = "select max(isnull(doc_numero,0)) as numero from " + tablaDocmto + " where doc_sucursal = '" + Doc_sucursal + "' ";
        //    sel += " and opc_documento = '" + Opc_documento + "' ";
        //    if (ctrlNumera.porBodega && bodega.Length > 0) { sel = " AND DOC_BODEGA = '" + bodega + "' "; }
        //    if (ctrlNumera.porPropietario && propietario.Length > 0) { sel += " AND Doc_codper = '" + propietario + "' "; }
        //    if (ctrlNumera.porIdSri && idsri.Length > 0) { sel += " AND Doc_NroIdDoc = '" + idsri + "' "; }

        //    double clave = 0;
        //    using (SqlConnection cnn = new SqlConnection(cadenaConexion))
        //    {
        //        cnn.Open();
        //        using (SqlCommand comm = new SqlCommand(sel, cnn))
        //        {
        //            SqlDataReader dr = comm.ExecuteReader();
        //            if (dr.Read())
        //            {
        //                try
        //                {
        //                    clave = Convert.ToDouble("0" + dr["numero"].ToString());
        //                }
        //                catch (Exception ee) { MessageBox.Show("no se puede obtener un nuevo numero para el documento \n" + ee.Message); }
        //            }
        //            dr.Close();
        //            dr.Dispose();
        //        }
        //    }
        //    return clave;
        //}

            //private void armarControlNumeracion()
            //{
            //    string sel = "SELECT isnull(Opc_Propietario,0) propietario, isnull(Opc_Bodega,0) bodega, isnull(Opc_IdSri,0) sri, isnull(numeraPoremisor,0) as emisor FROM AdcOpc where opc_documento = '" + Opc_documento + "' ";
            //    using (SqlDataAdapter da = new SqlDataAdapter(sel, cadenaConexion))
            //    {
            //        DataTable dtt = new DataTable();
            //        da.Fill(dtt);
            //        ctrlNumera = new controlNumeracion();
            //        if (dtt.Rows.Count != 0)
            //        {
            //            DataRow dttRow = dtt.Rows[0];
            //            try { ctrlNumera.porEmisor = (Convert.ToInt32(dttRow["emisor"]) == 1); }
            //            catch { }
            //            try { ctrlNumera.porPropietario = (Convert.ToInt32(dttRow["propietario"]) == 1); }
            //            catch { }
            //            try { ctrlNumera.porBodega = (Convert.ToInt32(dttRow["bodega"]) == 1); }
            //            catch { }
            //            try { ctrlNumera.porIdSri = (Convert.ToInt32(dttRow["sri"]) == 1); }
            //            catch { }
            //        }
            //        dtt.Dispose();
            //        esNroMultiple = (ctrlNumera.porBodega || ctrlNumera.porEmisor || ctrlNumera.porIdSri || ctrlNumera.porPropietario);
            //    }
            //}
            //public string establecerLugar(ref Boolean esMultiNumero)
            //{
            //    esMultiNumero = false;
            //    //SqlConnection cnn = new SqlConnection(cadenaConexion);
            //    //DataTable dtt = new DataTable();
            //    //string sel = "SELECT isnull(Opc_Propietario,0) propietario, isnull(Opc_Bodega,0) bodega, isnull(Opc_IdSri,0) sri, isnull(numeraPoremisor,0) as emisor FROM AdcOpc where opc_documento = '" + Opc_documento + "' ";
            //    //SqlDataAdapter da = new SqlDataAdapter(sel, cnn);
            //    //da.Fill(dtt);
            //    string lugar = Doc_sucursal;
            //    //if (dtt.Rows.Count != 0)
            //    //{
            //    //    DataRow dttRow = dtt.Rows[0];
            //    //    try { aux = Convert.ToInt32( dttRow["emisor"]); }
            //    //    catch { aux = 0; }
            //    //    if (aux == 1)
            //    //    {
            //    //        lugar += Environment.MachineName;
            //    //        esMultiNumero = true;
            //    //    }
            //    //    else
            //    //    {
            //    //        try { aux = Convert.ToInt32(dttRow["propietario"]); }
            //    //        catch { aux = 0; }
            //    //        if (aux == 1)
            //    //        {
            //    //            lugar += propietario;
            //    //            esMultiNumero = true;
            //    //        }
            //    //        try { aux = Convert.ToInt32( dttRow["bodega"]); }
            //    //        catch { aux = 0; }
            //    //        if (aux == 1)
            //    //        {
            //    //            lugar += bodega;
            //    //            esMultiNumero = true;
            //    //        }
            //    //        try { aux = Convert.ToInt32( dttRow["sri"]); }
            //    //        catch { aux = 0; }
            //    //        if (aux == 1)
            //    //        {
            //    //            lugar += idsri;
            //    //            esMultiNumero = true;
            //    //        }
            //    //    }
            //    //}
            //    //dtt.Dispose();
            //    //cnn.Dispose();
            //    //da.Dispose();
            //    if (ctrlNumera.porEmisor) { lugar += elEmisor; }
            //    if (ctrlNumera.porBodega) { lugar += bodega; }
            //    if (ctrlNumera.porPropietario) { lugar += propietario; }
            //    if (ctrlNumera.porIdSri) { lugar += idsri; }

            //    return lugar;
            //}

            //public double VerificaNumeroDocumento(string LaTabla, Double docNumero)
            //{
            //    string CodSql = "SELECT idclavedoc FROM " + LaTabla + " WHERE doc_sucursal='" + Doc_sucursal + "' and opc_documento='" + Opc_documento + "' ";
            //    if (ctrlNumera.porBodega && bodega.Length > 0) { CodSql += " AND DOC_BODEGA = '" + bodega + "' "; }
            //    if (ctrlNumera.porPropietario && propietario.Length > 0) { CodSql += " AND Doc_codper = '" + propietario + "' "; }
            //    if (ctrlNumera.porIdSri && idsri.Length > 0) { CodSql += " AND Doc_NroIdDoc = '" + idsri + "' "; }

            //    using (SqlConnection conn = new SqlConnection(cadenaConexion))
            //    {
            //        bool resp = true;
            //        conn.Open();
            //        int veces = 0;
            //        do
            //        {
            //            using (SqlCommand comm = new SqlCommand(CodSql + " and doc_numero = " + docNumero.ToString(), conn))
            //            {
            //                SqlDataReader dr = comm.ExecuteReader();
            //                if (dr.HasRows == false) return docNumero;
            //                if (veces == 0)
            //                {
            //                    if (MessageBox.Show("El documento " + Opc_documento + "-" + docNumero + " ya existe, desea que se guarde con otro número ?", "Grabación de documentos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return 0;
            //                }
            //                veces++;
            //                if (veces > 15)
            //                {
            //                    if (MessageBox.Show("El documento no se puede guardar con el número escojido \n" + "Inténte nuevamente con otro número", "Grabacion documentos", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.No) return 0;
            //                }
            //                dr.Close();
            //            }
            //            docNumero = nuevoNumero(LaTabla) + 1;
            //            veces++;

            //        } while (resp == true);
            //        return docNumero;
            //    }
            //}


        //static public void tablasDeDatos(string docTipo, string cadenaConexion,ref string tablaDoc, ref string tablaTra)
        //{
        //    string ssql = "select * from adcopc where opc_documento = '" + docTipo + "' ";
        //    DataTable dats = new DataTable();
        //    SqlDataAdapter datAd = new SqlDataAdapter(ssql, cadenaConexion);
        //    datAd.Fill(dats);
        //    string tipdoc = dats.Rows[0]["opc_tipo"].ToString().ToUpper();
        //    if (tipdoc == "PEP" || tipdoc == "PRC" || tipdoc == "PRP" || tipdoc == "REQ" || tipdoc == "PEC")
        //    {
        //        tablaDoc = "ADCDOCPRO";
        //        tablaTra = "ADCTRAPRO";
        //    }
        //    else
        //    {
        //        tablaDoc = "ADCDOC";
        //        tablaTra = "ADCTRA";
        //    }
        //    datAd.Dispose();
        //    dats.Dispose();
        //}

        
    }
}
