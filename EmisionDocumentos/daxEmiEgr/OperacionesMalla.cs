using System;
using System.Windows.Forms;
using System.Drawing;
using System.Text;

namespace adcDocumentos
{
    internal class OperacionesMalla
    {
        internal void DocumentosEscojidosAcoleccion(DataGridView malla, DocPendientes.ListDocAplican listaDocumentos, string CodConcepto)
        {
            listaDocumentos.ListaDocAplican.Clear();
            foreach (DataGridViewRow mrow in malla.Rows)
            {
                if (mrow.Cells["CodConcepto"].Value.ToString() == CodConcepto && Convert.ToDouble("0" + mrow.Cells["Apl_docapli"].Value.ToString()) > 0)
                {
                    DocPendientes.DocAplica docapl = new DocPendientes.DocAplica();
                    docapl.IdClaveDoc = Convert.ToDouble(mrow.Cells["IdClaveDocApl"].Value.ToString());
                    docapl.CodigoCliente = mrow.Cells["Apl_codbenef"].Value.ToString();
                    docapl.fechaDocumento = mrow.Cells["Apl_docfecha"].Value.ToString();
                    docapl.Nombre = mrow.Cells["nombreImpresion"].Value.ToString();
                    docapl.Numero = mrow.Cells["Apl_numapli"].Value.ToString();
                    docapl.Sucursal = mrow.Cells["Apl_sucapli"].Value.ToString();
                    docapl.TipoDoc = mrow.Cells["Apl_docapli"].Value.ToString();
                    docapl.ValorCruce = Convert.ToDouble(mrow.Cells["Apl_Valorapl"].Value);
                    docapl.sriFormaPagoSriDocumentos = "";
                    docapl.formaDePagoDocumento = "";
                    listaDocumentos.ListaDocAplican.Add(docapl);
                }
            }
        }
        internal void DocumentosEscojidosDeColeccionAmalla(DataGridView malla, DocPendientes.ListDocAplican listaDocumentos, string CodConcepto)
        {
            if (listaDocumentos.ListaDocAplican.Count == 0) return;
            Int32 indRowBase = -1;
            System.Data.DataTable Mdata = (System.Data.DataTable)malla.DataSource;
            foreach (DataGridViewRow DgvRow in malla.Rows)
            {
                if (DgvRow.Cells["CodConcepto"].Value.ToString() == CodConcepto)
                {
                    if (indRowBase == -1) indRowBase = DgvRow.Index;
                    DgvRow.Cells["Apl_Valorapl"].Value = 0;
                }
            }
            if (indRowBase == -1) return;
            Int32 newInd = 0;
            foreach (DocPendientes.DocAplica docapl in listaDocumentos.ListaDocAplican)
            {
                DataGridViewRow newrow;
                newInd = AplicacionExisteEnMalla(malla, CodConcepto, docapl.CodigoCliente, docapl.Sucursal, docapl.TipoDoc, docapl.IdClaveDoc);
                if (newInd == -1)
                {
                    Mdata.Rows.Add();
                    newrow = malla.Rows[malla.Rows.Count - 1];
                    copiarLineaMalla(malla.Rows[indRowBase], newrow);
                }
                else
                {
                    newrow = malla.Rows[newInd];
                }
                newrow.Cells["CodConcepto"].Value = CodConcepto;
                newrow.Cells["IdClaveDocApl"].Value = docapl.IdClaveDoc;
                newrow.Cells["Apl_codbenef"].Value = docapl.CodigoCliente;
                newrow.Cells["Apl_docfecha"].Value = docapl.fechaDocumento;
                newrow.Cells["nombreImpresion"].Value = docapl.Nombre;
                newrow.Cells["Apl_numapli"].Value = docapl.Numero;
                newrow.Cells["Apl_sucapli"].Value = docapl.Sucursal;
                newrow.Cells["Apl_docapli"].Value = docapl.TipoDoc;
                newrow.Cells["Apl_Valorapl"].Value = docapl.ValorCruce;
            }
            EliminaValoresVacios(malla, CodConcepto);
        }
        internal void ClasificadoresEscojidosAcoleccion(DataGridView malla, DaxClasificadores.ClasificadoresMallas  listaClasificadores, string CodConcepto,string CampoTra)
        {
            listaClasificadores.ColClasificadoresMalla.Clear();
            foreach (DataGridViewRow mrow in malla.Rows)
            {
                if (mrow.Cells["CodConcepto"].Value.ToString() == CodConcepto && mrow.Cells[CampoTra].Value.ToString().Length > 0)
                {
                    DaxClasificadores.ClasificadorMalla ClasfdM = new DaxClasificadores.ClasificadorMalla();
                    ClasfdM.Costo = Convert.ToDouble(mrow.Cells["Apl_Valorapl"].Value);
                    ClasfdM.IdClas = mrow.Cells[CampoTra].Value.ToString();
                    listaClasificadores.ColClasificadoresMalla.Add(ClasfdM);
                }
            }
        }
        internal void ClasificadoresEscojidosDeColeccionAmalla(DataGridView malla, DaxClasificadores.ClasificadoresMallas listaClasificadores, string CodConcepto, string CampoTra)
        {
            if (listaClasificadores.ColClasificadoresMalla.Count == 0) return;
            Int32 indRowBase = -1;
            System.Data.DataTable Mdata = (System.Data.DataTable)malla.DataSource;
            foreach (DataGridViewRow DgvRow in malla.Rows)
            {
                if (DgvRow.Cells["CodConcepto"].Value.ToString() == CodConcepto)
                {
                    if (indRowBase == -1) indRowBase = DgvRow.Index;
                    DgvRow.Cells["Apl_Valorapl"].Value = 0;
                }
            }
            if (indRowBase == -1) return;
            Int32 newInd = 0;
            foreach (DaxClasificadores.ClasificadorMalla ClasfM in listaClasificadores.ColClasificadoresMalla)
            {
                DataGridViewRow newrow;
                newInd = ClasificadorExisteEnMalla(malla, CodConcepto, CampoTra, ClasfM.IdClas);
                if (newInd == -1)
                {
                    Mdata.Rows.Add();
                    newrow = malla.Rows[malla.Rows.Count - 1];
                    copiarLineaMalla(malla.Rows[indRowBase], newrow);
                }
                else
                {
                    newrow = malla.Rows[newInd];
                }
                newrow.Cells["CodConcepto"].Value = CodConcepto;
                newrow.Cells[CampoTra].Value = ClasfM.IdClas;
                newrow.Cells["Apl_Valorapl"].Value = ClasfM.Costo;
            }
            EliminaValoresVacios(malla,CodConcepto);
        }
        private void copiarLineaMalla(DataGridViewRow OldRow, DataGridViewRow NewRow)
        {
            for (int i = 0;i < OldRow.Cells.Count;i++)
            {
                NewRow.Cells[i].Value = OldRow.Cells[i].Value;
            }
        }

        private void EliminaValoresVacios(DataGridView malla,string codConcepto)
        { 
            bool elimino = true;
            do
            {
                elimino = false;
                foreach (DataGridViewRow DgvRow in malla.Rows)
                {
                    if (DgvRow.Cells["CodConcepto"].Value.ToString() == codConcepto)
                    {
                        if (Convert.ToDouble(DgvRow.Cells["Apl_Valorapl"].Value) == 0)
                        {
                            malla.Rows.Remove(DgvRow);
                            elimino = true;
                        }
                    }
                }
            }
            while (elimino);
        }
        static public string Totalizar(DataGridView malla)
        {
            double  total = 0;
            foreach (DataGridViewRow DgvRow in malla.Rows)
            {
                try
                {
                    total += Convert.ToDouble(DgvRow.Cells["Apl_Valorapl"].Value);
                }catch { }
            }
            return total.ToString("##0.00");
        }

        private Int32 AplicacionExisteEnMalla(DataGridView malla, string tipoConcepto,string CodigoCliente, string sucursal, string tipoDoc, double Idclavedoc)
        {
            Int32 indice = -1;
            foreach (DataGridViewRow DgvRow in malla.Rows)
            {
                if (DgvRow.Cells["CodConcepto"].Value.ToString() == tipoConcepto
                    && DgvRow.Cells["apl_codbenef"].Value.ToString() == CodigoCliente
                    && DgvRow.Cells["apl_sucapli"].Value.ToString() == sucursal
                    && DgvRow.Cells["apl_docapli"].Value.ToString() == tipoDoc
                    && Convert.ToDouble(DgvRow.Cells["IdClaveDocApl"].Value) == Idclavedoc)
                { indice = DgvRow.Index; break; }
            }
            return indice;
        }
        private Int32 ClasificadorExisteEnMalla(DataGridView malla, string tipoConcepto,string CampoTra, string Clasificador)
        {
            Int32 indice = -1;
            foreach (DataGridViewRow DgvRow in malla.Rows)
            {
                if (DgvRow.Cells["CodConcepto"].Value.ToString() == tipoConcepto
                    && DgvRow.Cells[CampoTra].Value.ToString() == Clasificador)
                { indice = DgvRow.Index; break; }
            }
            return indice;
        }

        internal void DiseñarMallaEgresoBancos(DataGridView malla, PrySysp13.OpcDoc propiedadesDocmto, daxAccs.propiedadesDaxAuto accesosLocalizados = null)
        {
            malla.BackgroundColor = Color.White;
            malla.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
            malla.RowHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
            malla.RowHeadersDefaultCellStyle.ForeColor = Color.White;
            malla.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            malla.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            malla.RowHeadersWidth = 20;

            foreach (DataGridViewColumn clm in malla.Columns)
            {
                clm.Visible = false;
                clm.SortMode = DataGridViewColumnSortMode.NotSortable;
                if (clm.ValueType.Name.ToUpper() == "DATETIME") clm.DefaultCellStyle.Format = "dd/MMM/yyyy";
            }
            malla.Columns["CodConcepto"].HeaderText = "ID";
            malla.Columns["DescripcionConcepto"].HeaderText = "Descripción del concepto";
            malla.Columns["Apl_valorapl"].HeaderText = "Valor";
            malla.Columns["Apl_codBenef"].HeaderText = "IdBeneficiario";
            malla.Columns["NombreImpresion"].HeaderText = "Nombre del beneficiario";
            malla.Columns["Apl_SucApli"].HeaderText = "Suc";
            malla.Columns["Apl_Docapli"].HeaderText = "Doc";
            malla.Columns["Apl_Numapli"].HeaderText = "Número";

            malla.Columns["CodConcepto"].Visible = true;
            malla.Columns["DescripcionConcepto"].Visible = true;
            malla.Columns["Apl_valorapl"].Visible = true;
            
            if (propiedadesDocmto.TipoDoc == "ING")  malla.Columns["EsPago"].Visible = true;

            malla.Columns["tra_Costo"].HeaderText = "Centro Costo";
            malla.Columns["tra_empleado"].HeaderText = "Empleado";
            malla.Columns["tra_centroProduccion"].HeaderText = "C.Producción";
            malla.Columns["tra_centroDistribucion"].HeaderText = "C.Distribución";
            malla.Columns["tra_Proyecto"].HeaderText = "Proyecto";
            malla.Columns["EsPago"].HeaderText = "Cheque";

            malla.Columns["Apl_valorapl"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            malla.Columns["Apl_valorapl"].DefaultCellStyle.Format = "###0.00";


            if (datosAuxiliares.tieneDatoDetalle("Centro Costo", propiedadesDocmto))
            {
                malla.Columns["tra_Costo"].Visible = true;
            }
            if (datosAuxiliares.tieneDatoDetalle("Empleado", propiedadesDocmto))
            {
                malla.Columns["tra_empleado"].Visible = true;
            }
            if (datosAuxiliares.tieneDatoDetalle("Centro Producción", propiedadesDocmto))
            {
                malla.Columns["tra_centroProduccion"].Visible = true;
            }
            if (datosAuxiliares.tieneDatoDetalle("Centro Distribución", propiedadesDocmto))
            {
                malla.Columns["tra_centroDistribucion"].Visible = true;
            }
            if (datosAuxiliares.tieneDatoDetalle("Proyecto", propiedadesDocmto))
            {
                malla.Columns["tra_Proyecto"].Visible = true;
            }
        }
    }
}
