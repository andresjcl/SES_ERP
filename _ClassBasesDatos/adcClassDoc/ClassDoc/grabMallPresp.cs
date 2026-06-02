using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ClassDoc
{
    public class grabMallPresp
    {
        static public void grabarMallaAdcdia(DataGridView malla, AdcDocPro datDoc, string strConx)
        {
            Int32[] campos;
            string[] tipos;
            string sel = "SELECT * FROM AdcDiaPresp WHERE doc_sucursal = '" + datDoc.Doc_sucursal + "' and opc_documento = '" + datDoc.Opc_documento + "' and idclavedoc = " + datDoc.IdClaveDoc.ToString();
            using (var adapter = new SqlDataAdapter(sel, strConx))
            using (new SqlCommandBuilder(adapter))
            {
                DataTable Dtable = new DataTable();
                adapter.Fill(Dtable);
                campos = new Int32[Dtable.Columns.Count + 1];
                tipos = new string[Dtable.Columns.Count + 1];
                Int32 nroRowNew = 0;
                encontrarDatosTipos(ref campos, ref tipos, Dtable, malla);
                Boolean esNuevo = true;
                if (Dtable.Rows.Count > 0) nroRowNew = verificaDataEnMalla(Dtable, malla);

                Int32 cmpo = 0;
                DataRow dataRowGrabar = Dtable.NewRow();
                foreach (DataGridViewRow MallaRow in malla.Rows)
                {
                    if (MallaRow.Cells["Cta_codigo"].Value != null && (MallaRow.Cells["Cta_codigo"].Value).ToString() != string.Empty)
                    {
                        nroRowNew++;
                        dataRowGrabar = existeData(Dtable, MallaRow, ref esNuevo);


                        for (int i = 0; i < Dtable.Columns.Count; i++)
                        {
                            // mover campos dela malla al datatable de acuerdo al tipo de dato
                            cmpo = campos[i];
                            if (cmpo != 0) moverMallaData(MallaRow.Cells[cmpo], dataRowGrabar, i, tipos[i]);
                        }

                        if (esNuevo)
                        {
                            dataRowGrabar["Doc_sucursal"] = datDoc.Doc_sucursal;
                            //dataRowGrabar["Doc_Bodega"] = datDoc.Doc_Bodega;
                            dataRowGrabar["Opc_documento"] = datDoc.Opc_documento;
                            dataRowGrabar["Doc_numero"] = datDoc.Doc_numero;
                            dataRowGrabar["IdClaveDoc"] = datDoc.IdClaveDoc;
                            dataRowGrabar["Dia_fecha"] = datDoc.Doc_fecha;
                            dataRowGrabar["Dia_linea"] = nroRowNew;

                            Dtable.Rows.Add(dataRowGrabar);
                        }
                    }
                }
                adapter.Update(Dtable);
            }
        }
        static private Int32 verificaDataEnMalla(DataTable dt, DataGridView malla)
        {
            Int32 nroRow = 0;
            Int32 auxNro = 0;
            foreach (DataRow dtRow in dt.Rows)
            {
                try { auxNro = Convert.ToInt32("0" + dtRow["dia_linea"].ToString()); }
                catch { }
                if (nroRow < auxNro) nroRow = auxNro;
                if (datExisteEnMalla(dtRow, malla) == false) dtRow.Delete();
            }
            return nroRow;
        }
        static private bool datExisteEnMalla(DataRow dtRow, DataGridView malla)
        {
            foreach (DataGridViewRow mrow in malla.Rows)
            {
                if (Convert.ToInt32("0" + dtRow["Dia_linea"].ToString()) == Convert.ToInt32("0" + mrow.Cells["Dia_linea"].Value.ToString())
                     && mrow.Cells["Cta_codigo"].Value.ToString().Length > 0) return true;
            }
            return false;
        }
        static private DataRow existeData(DataTable datTab, DataGridViewRow mrow, ref bool esNuevo)
        {
            esNuevo = true;
            Int32 mallaLinea = Convert.ToInt32("0" + mrow.Cells["Dia_linea"].Value.ToString());

            foreach (DataRow dRow in datTab.Rows)
            {
                if (Convert.ToInt32("0" + dRow["Dia_linea"].ToString()) == mallaLinea)
                {
                    esNuevo = false;
                    return dRow;
                }
            }
            return datTab.NewRow();

        }
        static private void encontrarDatosTipos(ref Int32[] campos, ref string[] tipos, DataTable table, DataGridView malla)
        {
            for (int i = 0; i < malla.Columns.Count; i++)
            {
                for (int j = 0; j < table.Columns.Count; j++)
                {
                    if (table.Columns[j].ColumnName.ToUpper() == malla.Columns[i].Name.ToUpper())
                    {
                        campos[j] = i;
                        tipos[j] = table.Columns[j].DataType.Name;
                    }
                }
            }
        }
        static private void moverMallaData(DataGridViewCell cell, DataRow drow, Int32 campo, string tipo)
        {
            if (tipo.ToUpper() == "STRING")
            {
                try
                {
                    drow[campo] = cell.Value;
                }
                catch { drow[campo] = ""; }
            }
            else if (tipo.ToUpper() == "DECIMAL")
            {
                try
                {
                    drow[campo] = Convert.ToDecimal(cell.Value);
                }
                catch { drow[campo] = 0.00; }
            }
            else if (tipo.ToUpper() == "DATETIME")
            {
                try
                {
                    drow[campo] = Convert.ToDateTime(cell.Value);
                }
                catch { drow[campo] = new DateTime(1900, 1, 1); }
            }
            else if (tipo.ToUpper() == "INT32")
            {
                try
                {
                    drow[campo] = Convert.ToInt32(cell.Value);
                }
                catch { drow[campo] = 0; }
            }
            else if (tipo.ToUpper() == "INT64")
            {
                try
                {
                    drow[campo] = Convert.ToInt64(cell.Value);
                }
                catch { drow[campo] = 0; }
            }
            else if (tipo.ToUpper() == "INT16")
            {
                try
                {
                    drow[campo] = Convert.ToInt16(cell.Value);
                }
                catch { drow[campo] = 0; }
            }
            else drow[campo] = cell.Value;
        }

    }
}
