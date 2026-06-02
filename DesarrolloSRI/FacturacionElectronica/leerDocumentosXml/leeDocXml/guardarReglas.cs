using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DattCom;
namespace leeDocXml
{
    internal static class guardarReglas
    {
        internal static void guardarFap(Boolean agrupar,string DocTip,string CodDirectorio,string docAdcom, DataGridView mallaReferencia, Boolean todosConMismoCodigo)
        {
               DaxDocProov docprov = new DaxDocProov(datosEmpresa.strConxAdcom);
               docprov.AgruparIguales = "S";
               if (agrupar == false) docprov.AgruparIguales = "N";
               docprov.idDocProveedor = DocTip;
               docprov.idProveedor = CodDirectorio;
               docprov.opcDocAdcom = docAdcom;
               if (todosConMismoCodigo) docprov.unCodigo ="S"; else docprov.unCodigo ="N";
               docprov.Actualizar("select * from DaxDocProov where idProveedor = '" + CodDirectorio + "' and idDocProveedor = '" + DocTip + "' ");
               docprov = null;

               DaxRefProov refprov = new DaxRefProov(datosEmpresa.strConxAdcom);

               if (todosConMismoCodigo == true)
               {
                   DataGridViewRow row = mallaReferencia.Rows[0];
                   refprov.idProveedor = CodDirectorio;
                   refprov.idProductoProveedor = "_todos_";
                   refprov.codigoAdcomDax = row.Cells["codProductoPropio"].Value.ToString();
                   refprov.productoConcepto = row.Cells["ConceptoProducto"].Value.ToString();
                   refprov.utilizarDetalleProveedor = row.Cells["usarDetalle"].Value.ToString();
                   refprov.detalleAutilizar = ("" + row.Cells["DetalleOtro"].Value).ToString();
                   refprov.Actualizar("select * from DaxRefProov where idProveedor = '" + CodDirectorio + "' and idProductoProveedor = '" + refprov.idProductoProveedor + "'");
               }
               else
               {
                   foreach (DataGridViewRow row in mallaReferencia.Rows)
                   {
                       refprov.idProveedor = CodDirectorio;
                       refprov.idProductoProveedor = row.Cells["ProductoProveedor"].Value.ToString();
                       if (row.Cells["codProductoPropio"].Value != null) refprov.codigoAdcomDax = row.Cells["codProductoPropio"].Value.ToString();
                       if (row.Cells["ConceptoProducto"].Value != null) refprov.productoConcepto = row.Cells["ConceptoProducto"].Value.ToString();
                       if (row.Cells["usarDetalle"].Value != null) refprov.utilizarDetalleProveedor = row.Cells["usarDetalle"].Value.ToString();
                       refprov.detalleAutilizar = ("" + row.Cells["DetalleOtro"].Value).ToString();
                       refprov.Actualizar("select * from DaxRefProov where idProveedor = '" + CodDirectorio + "' and idProductoProveedor = '" + refprov.idProductoProveedor + "'");
                   }
               }
            }
        internal static void guardarRtc(Boolean agrupar, string DocTip, string CodDirectorio, string docAdcom, DataGridView mallaReferencia, Boolean todos)
        {
            DaxDocProov docprov = new DaxDocProov(datosEmpresa.strConxAdcom);
            docprov.AgruparIguales = "S";
            if (agrupar == false) docprov.AgruparIguales = "N";
            docprov.idDocProveedor = DocTip;
            docprov.idProveedor = CodDirectorio;
            docprov.opcDocAdcom = docAdcom;
            docprov.unCodigo = "N";
            docprov.Actualizar("select * from DaxDocProov where idProveedor = '" + CodDirectorio + "' and idDocProveedor = '" + DocTip + "' ");
            docprov = null;
             
            DaxRefProov refprov = new DaxRefProov(datosEmpresa.strConxAdcom);

            foreach (DataGridViewRow row in mallaReferencia.Rows)
            {
                refprov.idProveedor = CodDirectorio;
                refprov.idProductoProveedor = row.Cells["codigoRetencion"].Value.ToString()+row.Cells["PorcentajeRetener"].Value.ToString();
                refprov.codigoAdcomDax = row.Cells["tipoRetencion"].Value.ToString();                
                refprov.Actualizar("select * from DaxRefProov where idProveedor = '" + CodDirectorio + "' and idProductoProveedor = '" + refprov.idProductoProveedor + "'");
            }
        }

    }
}
