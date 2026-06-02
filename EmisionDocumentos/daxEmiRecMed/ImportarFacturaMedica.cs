using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace SesMedic
{
    internal class ImportarFacturaMedica
    {
        internal void ImportarServiciosMedicos(DataTable dtDetalleDocumento, DataGridView malla,DaxMedic.DatosFacturaCitaMedica datosFacturacionMedica)
        {
            int ind = 0;
            string codigo = "";
            for (int l = 0; l < datosFacturacionMedica.ConceptoCodigo.Length; l++)
            {
                try { codigo = datosFacturacionMedica.ConceptoCodigo[l]; } catch { codigo = ""; }
                if (codigo != null && codigo.Length > 0)
                {
                    dtDetalleDocumento.Rows.Add();
                    DataGridViewRow row = malla.Rows[ind];
                    malla.CurrentCell = row.Cells["tra_codigo"];

                    row.Cells["TRA_NUMLINEA"].Value = ind + 1;
                    row.Cells["tra_codigo"].Value = datosFacturacionMedica.ConceptoCodigo[l];
                    //daxMallaDatos.docMallaArticulo mallaArticulo = new docMallaArticulo();
                    //mallaArticulo.CargarServicios(datosFacturacionMedica.ConceptoCodigo[l], ref malla, claseImpuestos.impstoPorcentaje1, valoresPredefinidosEmpresa.nroDigitosEnPrecios, Convert.ToDateTime(txtfecha.Text), ref propiedadesDoc);
                    //mallaArticulo = null;
                    row.Cells["tra_nombre"].Value = datosFacturacionMedica.ConceptoDetalle[l];
                    row.Cells["tra_cantidad"].Value = datosFacturacionMedica.ConceptoCantidad[l];
                    row.Cells["tra_medida"].Value = "";
                    row.Cells["Tra_precuni"].Value = datosFacturacionMedica.ConceptoPVunitario[l];
                    row.Cells["tra_porcendes"].Value = 0;
                    row.Cells["tra_valordes"].Value = 0;
                    row.Cells["Tra_prectot"].Value = datosFacturacionMedica.ConceptoCantidad[l] * datosFacturacionMedica.ConceptoPVunitario[l];
                    row.Cells["TRA_SNIVA"].Value = false;

                    row.Cells["tra_quetipo"].Value = "S";
                    row.Cells["tra_esCuenta"].Value = 0;
                    row.Cells["Tra_individual"].Value = "N";
                    row.Cells["tra_costuni"].Value = 0;
                    row.Cells["Tra_CostTot"].Value = 0;
                    row.Cells["tra_multiplo"].Value = 1;
                    //row.Cells["Despacho"].Value = 0;
                    row.Cells["tra_numprecio"].Value = 1;
                    row.Cells["AuxVar3"].Value = datosFacturacionMedica.AuxVar3[l];
                    ind++;
                }
            }
//            dtDetalleDocumento.Rows.Add();
            malla.Refresh();
        }
    }
}
