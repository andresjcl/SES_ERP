using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using ClassDoc;
using DattCom;

namespace DctosEmi
{
    class CopiarDocumento
    {
        public void CopiarElDocumento(idDocumento IdDocOrigen,string tablaOrg, ref ClassDoc.AdcDoc DocDestino, ref DataTable dtTransacc,bool CopyTransacc=true)
        {

            string where = " doc_sucursal = '" + IdDocOrigen.Sucursal + "' and opc_documento = '" + IdDocOrigen.Tipo + "' and idclavedoc = " + IdDocOrigen.idClave.ToString();
            string tablatra = "ADCTRA";
            if (tablaOrg.ToUpper() == "ADCDOC")
            {
                DocDestino = AdcDoc.Buscar(where);
                tablatra = "ADCTRA";
            }
            else
            {
                AdcDocPro docPro = new AdcDocPro(datosEmpresa.strConxAdcom);
                docPro = AdcDocPro.Buscar(where);
                CambiarDocumentos.AdcdocProTOadcDoc(docPro, DocDestino);
                tablatra = "ADCTRAPRO";
            }
            if (CopyTransacc == true)   cargarDetalleArticulos(IdDocOrigen.Sucursal, IdDocOrigen.Tipo, IdDocOrigen.idClave, tablatra, dtTransacc);
        }
        public void CopiarElDocumento(idDocumento IdDocOrigen, string tablaOrg, ref ClassDoc.AdcDocPro DocDestino, ref DataTable dtTransacc, bool CopyTransacc = true)
        {

            string where = " doc_sucursal = '" + IdDocOrigen.Sucursal + "' and opc_documento = '" + IdDocOrigen.Tipo + "' and idclavedoc = " + IdDocOrigen.idClave.ToString();
            string tablatra = "ADCTRAPRO";
            if (tablaOrg.ToUpper() == "ADCDOCPRO")
            {
                DocDestino = AdcDocPro.Buscar(where);
            }
            else
            {
                AdcDoc docAdc = new AdcDoc(datosEmpresa.strConxAdcom);
                docAdc = AdcDoc.Buscar(where);

                CambiarDocumentos.AdcdocTOadcDocPro(docAdc, DocDestino);
                tablatra = "ADCTRA";
            }
            if (CopyTransacc == true) cargarDetalleArticulos(IdDocOrigen.Sucursal, IdDocOrigen.Tipo, IdDocOrigen.idClave, tablatra, dtTransacc);
        }

        private void cargarDetalleArticulos(string suc, string tip, double idClave, string tablatra, DataTable DbTransacc)
        {
            DatosDocFacturacion dcut = new DatosDocFacturacion();
            DataTable dtAux = SqlDatos.leerTablaAdcom(" select * from "+ tablatra +" where doc_sucursal = '" + suc + "' and opc_documento = '" + tip + "' and idclavedoc = " + idClave.ToString() + " order by tra_NumLinea ");
            if (dtAux == null) { return; }
            foreach (DataRow dtAuxrow in dtAux.Rows)
            {
                
                DataRow nrow = DbTransacc.NewRow();
                for (int i = 0;i< DbTransacc.Columns.Count;i++)
                {
                    //if (dtAux.Columns[i].ColumnName.ToUpper() == DbTransacc.Columns[i].ColumnName.ToUpper())
                    //{ nrow[i] = dtAuxrow[i]; }
                    //else
                    //{
                        for (int l = 0; l < dtAux.Columns.Count; l++)
                        {
                            if (dtAux.Columns[l].ColumnName.ToUpper() == DbTransacc.Columns[i].ColumnName.ToUpper())
                            { nrow[i] = dtAuxrow[l]; }
                        }
                    //}
                }
                DbTransacc.Rows.Add(nrow);
            }
        }

        private void copiarDataAdcdocproAdcdoc(DataTable AdcDocPro, DataTable AdcDoc)
        {
            DataRow DocRow = AdcDoc.NewRow();
            for (int i = 0; i < AdcDocPro.Columns.Count; i++)
            {
                for (int l = 0; l < AdcDoc.Columns.Count; l++)
                {
                    if (AdcDocPro.Columns[i].ColumnName.ToUpper() == AdcDoc.Columns[l].ColumnName.ToUpper())
                    {
                        DocRow[l] = AdcDocPro.Rows[0][i];
                        break;
                    }
                }
            }
            AdcDoc.Rows.Add(DocRow);
        }
        private void copiarDataAdcdocAdcdocPro(DataTable AdcDoc, DataTable AdcDocPro)
        {
            if (AdcDoc.Rows.Count == 0) return;
            DataRow drow = AdcDocPro.NewRow();
            for (int i = 0; i < AdcDoc.Columns.Count; i++)
            {
                for (int l = 0; l < AdcDocPro.Columns.Count; l++)
                {
                    if (AdcDoc.Columns[i].ColumnName.ToUpper() == AdcDocPro.Columns[l].ColumnName.ToUpper())
                    {
                        drow[l] = AdcDoc.Rows[0][i];
                        break;
                    }
                }
            }
            AdcDocPro.Rows.Add(drow);
        }
    }
}
