using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace ClassDoc
{
    public class controlNumeracion
    {
        public bool FijarNroDeDocumento(string laTabla, Boolean autoNumeracion, string codProveedor, ClassDoc.idDocumento idDoc, string strDax)  // regresa el numero del documento 
        {
            Boolean creoClave = false;
            string generadorClave = "genIdDocProp";
            if (laTabla.ToUpper() == "ADCDOCPRO") generadorClave = "genIdDocProPpr";
            Int32 veces = 0;
            using (SqlConnection conn = new SqlConnection(strDax))
            {
                conn.Open();
                do
                {
                    string sel = generadorClave + " '" + idDoc.Sucursal + "','" + idDoc.Tipo + "','" + idDoc.Serie + "'," + idDoc.numero.ToString() + ",'" + codProveedor + "'";
                    SqlCommand comm = new SqlCommand(sel, conn);
                    using (SqlDataReader dr = comm.ExecuteReader())
                    {
                        if (dr.Read() == true)
                        {
                            idDoc.idClave = Convert.ToDouble(dr["IdClaveDoc"].ToString());
                        }
                    }
                    if (idDoc.idClave < 1)
                    {
                        if (autoNumeracion == false || codProveedor .Length == 0)
                        {
							if (idDoc.Tipo=="FAP")
							{
                                MessageBox.Show("El documento " + idDoc.Tipo + "-" + idDoc.numero + " ya existe!!", "Grabación de documentos", MessageBoxButtons.OK, MessageBoxIcon.Question);
                                return false;
                            }
							else
							{
                                if (MessageBox.Show("El documento " + idDoc.Tipo + "-" + idDoc.numero + " ya existe, desea que se guarde con otro número ?", "Grabación de documentos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                                {
                                    return false;
                                }
                            }
                            
                        }
                        else
                        {
                            veces++;
                            if (veces > 30 || codProveedor.Length > 0)
                            {
                                MessageBox.Show("El documento no se puede guardar con el número escojido \n" + "Inténte nuevamente con otro número", "Grabacion documentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }
                        }
                        idDoc.idClave = 0;
                        idDoc.numero = OtroNumero(laTabla, idDoc, codProveedor, strDax);
                    }
                    else
                    {
                        creoClave = true;
                    }
                } while (creoClave == false);
                return true;
            }
        }
        private double OtroNumero(string LaTabla, ClassDoc.idDocumento iddoc, string Proveedor, String StrConx)
        {

            double numero = 1;
            string CodSql = "SELECT max(DOC_NUMERO) as doc_numero FROM  " + LaTabla + " ";
            CodSql += " WHERE doc_sucursal='" + iddoc.Sucursal + "' and opc_documento='" + iddoc.Tipo + "'";
            CodSql += " and Doc_NroIdDoc = '" + iddoc.Serie + "'";
            using (SqlConnection conn = new SqlConnection(StrConx))
            {

                conn.Open();
                SqlCommand comm = new SqlCommand(CodSql, conn);
                SqlDataReader drr = comm.ExecuteReader();

                if (drr.Read())
                {
                    double.TryParse(drr["Doc_numero"].ToString(), out numero);
                    numero++;
                }
                drr.Close();
                comm.Dispose();

            }
            return numero;
        }
        public double NumeroMayor(ClassDoc.idDocumento iddoc,string CodBan, string idProveedor, string idEmisor, String StrConx)
        {
            double numero = 0;
            string lugarEmiteDoc;
            if (CodBan.Length > 0) { lugarEmiteDoc = CodBan; }
            else { lugarEmiteDoc = establecerLugar(iddoc.Tipo , iddoc.Sucursal, CodBan, iddoc.Serie, idProveedor, idEmisor); }
            string ssql = "SELECT *  FROM Adcdocnum WHERE id_Documento='" + iddoc.Tipo  + "' and id_lugar = '" + lugarEmiteDoc + "'";
            using (SqlConnection conn = new SqlConnection(StrConx))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand(ssql, conn);
                SqlDataReader dat = comm.ExecuteReader();
                numero = 0;
                if (dat.Read())
                {
                    try
                    {
                        numero = System.Convert.ToDouble(dat["ultimonumero"]);
                    }
                    catch { }
                }
            }
            numero++;
            return numero;
        }
        public void guardarNumeroDocumento(ClassDoc.idDocumento iddoc, string StrDax, string lugarEmision, string proveedor)
        {
            //            
            if (lugarEmision.Length == 0)
            {
                lugarEmision = establecerLugar(iddoc.Tipo, iddoc.Sucursal, lugarEmision, iddoc.Serie, proveedor, "");
            }

            string sel = "SELECT *  FROM Adcdocnum WHERE id_Documento='" + iddoc.Tipo  + "' and id_lugar = '" + lugarEmision  + "'";
            using (SqlDataAdapter da = new SqlDataAdapter(sel, StrDax))
            {
                DataTable dtt = new DataTable();
                da.Fill(dtt);
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                if (dtt.Rows.Count > 0)
                {
                    if (Convert.ToDouble(dtt.Rows[0]["UltimoNumero"]) < iddoc.numero)
                    {
                        dtt.Rows[0]["UltimoNumero"] = iddoc.numero;
                        dtt.Rows[0]["UltimaFecha"] = iddoc.fecha;
                    }
                    else
                    {
                        dtt.Dispose();
                        return;
                    }
                }
                else
                {
                    DataRow dtr = dtt.NewRow();
                    dtr["UltimoNumero"] = iddoc.numero;
                    dtr["Id_Lugar"] = lugarEmision;
                    dtr["id_Documento"] = iddoc.Tipo;
                    dtr["UltimaFecha"] = iddoc.fecha.ToShortDateString();
                    dtt.Rows.Add(dtr);
                }
                da.Update(dtt);
                dtt.AcceptChanges();
                dtt.Dispose();
                cb.Dispose();
            }
        }
        public string establecerLugar(string tipoDoc, string sucursal, string banco, string Idsri, string idProveedor, string idEmisor)
        {
            string lugar = sucursal+Idsri;

            if (banco.Length > 0) lugar = banco;
            else if (idProveedor.Length > 0) lugar += idProveedor;
            return lugar;
        }
    }
}

