using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leeDocXml
{
    static internal class diseñaMalla
    {
        static internal void construirMalla(System.Windows.Forms.DataGridView malla)
        {
              malla.Columns.Add("ProductoProveedor", "ProductoProveedor");
              malla.Columns.Add("DetalleProveedor", "DetalleProveedor");
              malla.Columns.Add("codProductoPropio", "ProductoPropio"); 
              malla.Columns.Add("ConceptoProducto", "Tipo");
              malla.Columns.Add("usarDetalle", "usaDetalle");
              malla.Columns.Add("DetalleAutilizar", "DetalleARegistrar");
              malla.Columns.Add("DetalleCatalogo","");
              malla.Columns.Add("DetalleOtro","");
              malla.Columns.Add("Cantidad", "Cantidad");
              malla.Columns.Add("PvUni", "PvUni");
              malla.Columns.Add("PorcDes", "PorcDes");
              malla.Columns.Add("iva", "Iva");

              malla.Columns.Add("Lote", "Lote");
              malla.Columns.Add("Vence", "Vence");
              malla.Columns.Add("CodAlterno", "CodAlterno");

            // NUEVAS COLUMNAS PARA IVA Y COSTOS
            malla.Columns.Add("Tra_porceniva", "%IVA");
            malla.Columns.Add("Tra_valoriva", "ValorIVA");

            // NUEVAS COLUMNAS para clasificación
            malla.Columns.Add("EsArticulo", "EsArticulo"); // "A" = Artículo, "S" = Servicio
            malla.Columns.Add("EsProducto", "EsProducto"); // "P" = Producto, "C" = Concepto

            malla.Columns["EsArticulo"].Visible = false;
            malla.Columns["EsProducto"].Visible = false;


            malla.Columns["ProductoProveedor"].ReadOnly = true;
              malla.Columns["DetalleProveedor"].ReadOnly = true;
              malla.Columns["ConceptoProducto"].ReadOnly = true;
              malla.Columns["usarDetalle"].ReadOnly = true;

              malla.Columns["ProductoProveedor"].Width = 100;
              malla.Columns["DetalleProveedor"].Width = 300;
              malla.Columns["codProductoPropio"].Width = 100;
              malla.Columns["ConceptoProducto"].Width = 60;
              malla.Columns["usarDetalle"].Width = 60;
              malla.Columns["DetalleAutilizar"].Width = 300;

              malla.Columns["DetalleCatalogo"].Visible=false;
              malla.Columns["DetalleOtro"].Visible=false;
              malla.Columns["Cantidad"].Visible = false; ;
              malla.Columns["PvUni"].Visible = false; ;
              malla.Columns["PorcDes"].Visible = false;
              malla.Columns["iva"].Visible = false;
              malla.Columns["Lote"].Visible = false;
              malla.Columns["Vence"].Visible = false;
              malla.Columns["CodAlterno"].Visible = false;
            // Configurar las nuevas columnas
            malla.Columns["Tra_porceniva"].Visible = false;
            malla.Columns["Tra_valoriva"].Visible = false;
        }
        static internal void construirMallaRtc(System.Windows.Forms.DataGridView malla)
        { 
            
            malla.Columns.Add("tipoRetencion", "tipRetencion");
            malla.Columns.Add("codigoRetencion", "codRet");
            malla.Columns.Add("baseImponible", "baseImponible");
            malla.Columns.Add("PorcentajeRetener", "%");
            malla.Columns.Add("valorRetenido", "ValRetenido");
            malla.Columns.Add("codDocSustento", "TipDocRetSri");
            malla.Columns.Add("tipoDocumentAdcom", "TipDocRetAdcom");
            malla.Columns.Add("numDocSustento", "NroDocmtoRet");
            malla.Columns.Add("fechaEmisionDocSustento", "FechaDocRet");

            malla.ReadOnly=true;
            malla.AutoResizeColumns( System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells);
        }
        static internal void AgruparCodigosIgualesFap()
        {




        }
    }
}
