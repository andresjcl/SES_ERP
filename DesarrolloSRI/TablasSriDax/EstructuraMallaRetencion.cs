using System;
using System.Data;
using System.Windows.Forms;

namespace IvaRett
{
    public static class EstructuraMallaRetencion
    {
        /// <summary>
        /// Crea el DataTable con la estructura completa de la malla
        /// </summary>
        public static DataTable CrearDataTable()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("SRI_Sucursal", typeof(string));
            dt.Columns.Add("SRI_Documento", typeof(string));
            dt.Columns.Add("SRI_IdClaveDoc", typeof(decimal));
            dt.Columns.Add("SRI_NumeroRetencion", typeof(decimal));
            dt.Columns.Add("Doc_Sucursal", typeof(string));
            dt.Columns.Add("Doc_OpcDocumento", typeof(string));
            dt.Columns.Add("Doc_Numero", typeof(string));
            dt.Columns.Add("Doc_IdClave", typeof(decimal));
            dt.Columns.Add("Doc_Linea", typeof(int));
            dt.Columns.Add("Doc_CodSri", typeof(string));
            dt.Columns.Add("TipoRetencion", typeof(string));
            dt.Columns.Add("CodigoRetencion", typeof(string));
            dt.Columns.Add("BaseRetencion", typeof(decimal));
            dt.Columns.Add("PorcRetencion", typeof(decimal));
            dt.Columns.Add("ValorRetencion", typeof(decimal));
            dt.Columns.Add("BaseConIva", typeof(decimal));
            dt.Columns.Add("BaseExcentaIva", typeof(decimal));
            dt.Columns.Add("BaseIvaCero", typeof(decimal));

            return dt;
        }

        /// <summary>
        /// Configura el diseño del DataGridView
        /// </summary>
        public static void DiseñarMalla(DataGridView malla)
        {
            // Ocultar columnas
            OcultarColumna(malla, "SRI_Sucursal");
            OcultarColumna(malla, "SRI_Documento");
            OcultarColumna(malla, "SRI_IdClaveDoc");
            OcultarColumna(malla, "SRI_NumeroRetencion");
            OcultarColumna(malla, "Doc_IdClave");
            OcultarColumna(malla, "Doc_Linea");
            OcultarColumna(malla, "Doc_CodSri");
            OcultarColumna(malla, "Doc_Sucursal");

            // Configurar columnas visibles
            ConfigurarColumna(malla, "Doc_OpcDocumento", "Doc", true, DataGridViewContentAlignment.MiddleLeft);
            ConfigurarColumna(malla, "Doc_Numero", "Número", true, DataGridViewContentAlignment.MiddleRight, "F0");
            ConfigurarColumna(malla, "TipoRetencion", "TipoRet", true, DataGridViewContentAlignment.MiddleLeft);
            ConfigurarColumna(malla, "CodigoRetencion", "CodReten", false, DataGridViewContentAlignment.MiddleLeft);
            ConfigurarColumna(malla, "BaseRetencion", "BaseRet", false, DataGridViewContentAlignment.MiddleRight, "F2");
            ConfigurarColumna(malla, "PorcRetencion", "Porc", false, DataGridViewContentAlignment.MiddleRight, "F2");
            ConfigurarColumna(malla, "ValorRetencion", "ValorRet", false, DataGridViewContentAlignment.MiddleRight, "F2");
            ConfigurarColumna(malla, "BaseConIva", "BaseConIva", false, DataGridViewContentAlignment.MiddleRight, "F2");
            ConfigurarColumna(malla, "BaseExcentaIva", "BaExeIva", false, DataGridViewContentAlignment.MiddleRight, "F2");
            ConfigurarColumna(malla, "BaseIvaCero", "BaIvaCero", false, DataGridViewContentAlignment.MiddleRight, "F2");
        }

        private static void OcultarColumna(DataGridView malla, string nombreColumna)
        {
            if (malla.Columns.Contains(nombreColumna))
            {
                malla.Columns[nombreColumna].Visible = false;
            }
        }

        private static void ConfigurarColumna(DataGridView malla, string nombreColumna, string headerText, bool readOnly,
                                              DataGridViewContentAlignment alignment, string format = "")
        {
            if (malla.Columns.Contains(nombreColumna))
            {
                var columna = malla.Columns[nombreColumna];
                columna.HeaderText = headerText;
                columna.ReadOnly = readOnly;
                columna.DefaultCellStyle.Alignment = alignment;

                if (!string.IsNullOrEmpty(format))
                {
                    columna.DefaultCellStyle.Format = format;
                }
            }
        }
    }
}