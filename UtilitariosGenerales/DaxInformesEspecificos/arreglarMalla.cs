using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;

namespace DaxInfDefinidos
{
    class arreglarMalla
    {
        static internal void ArreglaMalla(DataGridView Malla)
        {
            Malla.DefaultCellStyle.Format = "##0.00;##0.00;''";
            Malla.Columns["st"].Visible = false;
            Malla.Columns["codigo"].ReadOnly = true;
            Malla.Columns["NombreImpresion"].ReadOnly = true;

            Malla.Columns["codigo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            Malla.Columns["NombreImpresion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            Malla.Columns["NombreImpresion"].HeaderText = "NombreTrabajador";
            Malla.Columns["IngresoPatronoAnterior"].HeaderText = "IngPatronoAnt";
            Malla.Columns["AportesIessPatronoAnterior"].HeaderText = "IessPatronoAnt";
            Malla.Columns["IngresosAdicionales"].HeaderText = "OtrosIngresos";
        }
    }
}
