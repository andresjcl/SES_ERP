using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DattCom;
namespace leeDocXml
{
    class validacion
    {
       internal string validarFactura(DataGridView mallaRef, DaxDocProov docProv)
        {
            if (docProv == null) return "";
           string resp="";           
           DaxRefProov refProv = new DaxRefProov(datosEmpresa.strConxAdcom);
           foreach (DataGridViewRow row in mallaRef.Rows)
           {
               if (row.Cells["ProductoProveedor"].Value != null)
               {
                   if (docProv.unCodigo != null && docProv.unCodigo == "S")
                   {
                       if (refProv.idProductoProveedor != "_todos_") refProv = DaxRefProov.Buscar(" idProveedor = '" + docProv.idProveedor + "' and idProductoProveedor = '_todos_'");
                   }
                   else
                   {
                       refProv = DaxRefProov.Buscar(" idProveedor = '" + docProv.idProveedor + "' and idProductoProveedor = '" + row.Cells["ProductoProveedor"].Value.ToString() + "'");
                   }
                   if (refProv != null)
                   {
                       row.Cells["codProductoPropio"].Value = refProv.codigoAdcomDax;
                       row.Cells["ConceptoProducto"].Value = refProv.productoConcepto;
                       row.Cells["usarDetalle"].Value = refProv.utilizarDetalleProveedor;
                       row.Cells["DetalleOtro"].Value = refProv.detalleAutilizar;
                   }
                   else { refProv = new DaxRefProov(datosEmpresa.strConxAdcom);}

                   if (row.Cells["DetalleCatalogo"].Value == null || row.Cells["DetalleCatalogo"].Value.ToString() == "")
                   {
                       EmpNomR.AdcNomb retn = new EmpNomR.AdcNomb();
                       if (refProv.productoConcepto.ToUpper()  == "PRODUCTO") row.Cells["DetalleCatalogo"].Value = retn.RetornaNombreArticulo(refProv.codigoAdcomDax, datosEmpresa.strConxAdcom);
                       else row.Cells["DetalleCatalogo"].Value = retn.RetornaNombreServicio(refProv.codigoAdcomDax, datosEmpresa.strConxAdcom);
                       retn = null;
                   }

                   if (refProv.utilizarDetalleProveedor == "Proveedor") row.Cells["detalleAutilizar"].Value = row.Cells["DetalleProveedor"].Value;
                   else if (refProv.utilizarDetalleProveedor == "Catálogo")
                   {
                       row.Cells["detalleAutilizar"].Value = row.Cells["DetalleCatalogo"].Value;
                   }
                   else row.Cells["detalleAutilizar"].Value = row.Cells["DetalleOtro"].Value;
                   if (row.Cells["detalleAutilizar"] == null || ("" + row.Cells["detalleAutilizar"].Value).ToString() == "") row.Cells["detalleAutilizar"].Value = row.Cells["DetalleProveedor"].Value;
               }
           }
            return resp;
        }
       internal string validarRetencion(DataGridView mallaRef, DaxDocProov docProv)
       {
           if (docProv == null) return "";
           string resp = "";
           DaxRefProov refProv = new DaxRefProov(datosEmpresa.strConxAdcom);
           foreach (DataGridViewRow row in mallaRef.Rows)
           {
               if (row.Cells["valorRetenido"].Value != null)
               {
                   refProv = DaxRefProov.Buscar(" idProveedor = '" + docProv.idProveedor + "' and idProductoProveedor = '" + row.Cells["codigoRetencion"].Value.ToString()+row.Cells["porcentajeRetener"].Value.ToString() + "'");
                   
                   if (refProv != null)
                   {
                       row.Cells["tipoRetencion"].Value = refProv.codigoAdcomDax;
                   }
               }
           }
           return resp;
       }
    }
}
