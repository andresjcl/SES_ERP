using DattCom;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using utilBasDatos;

namespace ClassDoc
{
    [System.Runtime.InteropServices.Guid("C8E9BEF3-4611-4EBF-BB71-02D25EF8761B")]
    public class grabMallTra
    {
        static public void grabarMallaAdctra(DataGridView malla, AdcDoc datDoc, string strConx)
        {
            Int32[] campos;
            string[] tipos;
            string sel = "SELECT * FROM AdcTra WHERE doc_sucursal = '" + datDoc.Doc_sucursal + "' and opc_documento = '" + datDoc.Opc_documento + "' and idclavedoc = " + datDoc.IdClaveDoc.ToString();

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
                    if (MallaRow.IsNewRow)
                        continue;

                    var codigoValue = MallaRow.Cells["TRA_Codigo"]?.Value;
                    if (codigoValue == null || codigoValue == DBNull.Value)
                        continue;

                    string codigo = codigoValue.ToString().Trim();
                    if (string.IsNullOrEmpty(codigo))
                        continue;

                    nroRowNew++;
                    dataRowGrabar = existeData(Dtable, MallaRow, ref esNuevo);

                    // ✅ MOVER TODOS LOS CAMPOS DE LA MALLA AL DATATABLE
                    for (int i = 0; i < Dtable.Columns.Count; i++)
                    {
                        cmpo = campos[i];
                        if (cmpo != 0)
                            moverMallaData(MallaRow.Cells[cmpo], dataRowGrabar, i, tipos[i]);
                    }

                    // ✅ VERIFICAR QUE LOS COSTOS SE ESTÉN MOVIENDO CORRECTAMENTE
                    // Si las columnas no se mapearon automáticamente, asignarlas manualmente
                    if (Dtable.Columns.Contains("Tra_costuni"))
                    {
                        if (MallaRow.Cells["Tra_costuni"]?.Value != null && MallaRow.Cells["Tra_costuni"].Value != DBNull.Value)
                        {
                            decimal costo = 0;
                            decimal.TryParse(MallaRow.Cells["Tra_costuni"].Value.ToString(), out costo);
                            dataRowGrabar["Tra_costuni"] = Math.Round(costo, 4);
                        }
                        else
                        {
                            dataRowGrabar["Tra_costuni"] = 0;
                        }
                    }

                    if (Dtable.Columns.Contains("Tra_costtot"))
                    {
                        if (MallaRow.Cells["Tra_costtot"]?.Value != null && MallaRow.Cells["Tra_costtot"].Value != DBNull.Value)
                        {
                            decimal costo = 0;
                            decimal.TryParse(MallaRow.Cells["Tra_costtot"].Value.ToString(), out costo);
                            dataRowGrabar["Tra_costtot"] = Math.Round(costo, 2);
                        }
                        else
                        {
                            // Si no hay costo total, calcularlo de Tra_costuni * cantidad
                            decimal costoUnitario = 0;
                            if (Dtable.Columns.Contains("Tra_costuni") && dataRowGrabar["Tra_costuni"] != DBNull.Value)
                                decimal.TryParse(dataRowGrabar["Tra_costuni"].ToString(), out costoUnitario);

                            decimal cantidad = 0;
                            if (MallaRow.Cells["Tra_cantidad"]?.Value != null && MallaRow.Cells["Tra_cantidad"].Value != DBNull.Value)
                                decimal.TryParse(MallaRow.Cells["Tra_cantidad"].Value.ToString(), out cantidad);

                            dataRowGrabar["Tra_costtot"] = Math.Round(costoUnitario * cantidad, 2);
                        }
                    }

                    if (esNuevo)
                    {
                        dataRowGrabar["Doc_sucursal"] = datDoc.Doc_sucursal;
                        dataRowGrabar["Doc_Bodega"] = datDoc.Doc_Bodega;
                        dataRowGrabar["Opc_documento"] = datDoc.Opc_documento;
                        dataRowGrabar["Doc_numero"] = datDoc.Doc_numero;
                        dataRowGrabar["IdClaveDoc"] = datDoc.IdClaveDoc;
                        dataRowGrabar["Tra_valor"] = datDoc.Doc_valor;
                        dataRowGrabar["Tra_DocSop"] = datDoc.Doc_DocSop;
                        dataRowGrabar["Tra_NumSop"] = datDoc.Doc_NumSop;
                        dataRowGrabar["Tra_fecha"] = datDoc.Doc_fecha;
                        dataRowGrabar["Tra_TipoDoc"] = datDoc.Doc_TipoDoc;
                        dataRowGrabar["tra_numprecio"] = 1;
                        dataRowGrabar["tra_multiplo"] = 1.00000000m;
                        dataRowGrabar["Tra_Estado"] = 1;
                        dataRowGrabar["Tra_Oculto"] = Convert.ToInt16(datDoc.Doc_Oculto);
                        dataRowGrabar["Tra_Ventas"] = datDoc.Doc_Ventas;
                        dataRowGrabar["Tra_Inventario"] = datDoc.Doc_Inventario;
                        dataRowGrabar["Tra_Compras"] = datDoc.Doc_Compras;
                        dataRowGrabar["Tra_Activo"] = datDoc.Doc_Activo;
                        dataRowGrabar["Tra_NroLoteDoc"] = datDoc.Doc_NroLoteDoc;
                        dataRowGrabar["tra_anio"] = datDoc.Doc_fecha.Year;
                        dataRowGrabar["tra_mes"] = datDoc.Doc_fecha.Month;
                        dataRowGrabar["tra_dia"] = datDoc.Doc_fecha.Day;
                        dataRowGrabar["Tra_numlinea"] = nroRowNew;

                        Dtable.Rows.Add(dataRowGrabar);
                    }
                }

                adapter.Update(Dtable);
                adapter.Dispose();
                Dtable.Dispose();
            }
        }

        private static DataTable VerificarCompuesto(string _codigo)
        {
            DataTable dt = new DataTable();
            string ssql = "select * from adcart where Art_codigo='" + _codigo + "' and Art_sncomp = 1";

            dt = utilBasDatos.utilBasDatos.leerTablas(ssql, datosEmpresa.strConxAdcom);
            return dt;
        }


        static public void grabarMallaAdctraComp(DataGridView mallaComp, AdcDocComp datDocComp, string strConx)
        {
            Int32[] campos;
            string[] tipos;
            string sel = "SELECT * FROM AdcTra WHERE doc_sucursal = '" + datDocComp.Doc_sucursal + "' and opc_documento = '" + datDocComp.Opc_documento + "' and idclavedoc = " + datDocComp.IdClaveDoc.ToString();
            using (var adapter = new SqlDataAdapter(sel, strConx))
            using (new SqlCommandBuilder(adapter))
            {
                DataTable Dtable = new DataTable();
                adapter.Fill(Dtable);
                campos = new Int32[Dtable.Columns.Count + 1];
                tipos = new string[Dtable.Columns.Count + 1];
                Int32 nroRowNew = 0;
                encontrarDatosTipos(ref campos, ref tipos, Dtable, mallaComp);
                Boolean esNuevo = true;
                if (Dtable.Rows.Count > 0) nroRowNew = verificaDataEnMalla(Dtable, mallaComp);

                Int32 cmpo = 0;
                DataRow dataRowGrabar = Dtable.NewRow();
                //ANDRES
                foreach (DataGridViewRow MallaRow in mallaComp.Rows)
                {
                    if (MallaRow.Cells["TRA_CODIGO"].Value != null && (MallaRow.Cells["TRA_CODIGO"].Value).ToString() != string.Empty)
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
                            dataRowGrabar["Doc_sucursal"] = datDocComp.Doc_sucursal;
                            dataRowGrabar["Doc_Bodega"] = datDocComp.Doc_Bodega;
                            dataRowGrabar["Opc_documento"] = datDocComp.Opc_documento;
                            dataRowGrabar["Doc_numero"] = datDocComp.Doc_numero;
                            dataRowGrabar["IdClaveDoc"] = datDocComp.IdClaveDoc;
                            dataRowGrabar["Tra_DocSop"] = datDocComp.Doc_DocSop;
                            dataRowGrabar["Tra_NumSop"] = datDocComp.Doc_NumSop;

                            dataRowGrabar["Tra_valor"] =0;

                            dataRowGrabar["Tra_fecha"] = datDocComp.Doc_fecha;
                            dataRowGrabar["Tra_TipoDoc"] = datDocComp.Doc_TipoDoc;
                            dataRowGrabar["Tra_Estado"] = 1;
                            dataRowGrabar["Tra_Oculto"] = Convert.ToInt16(datDocComp.Doc_Oculto);
                            dataRowGrabar["Tra_Ventas"] = 0; 
                            dataRowGrabar["Tra_Inventario"] = datDocComp.Doc_Inventario;
                            dataRowGrabar["Tra_Compras"] = datDocComp.Doc_Compras;
                            dataRowGrabar["Tra_Activo"] = datDocComp.Doc_Activo;
                            dataRowGrabar["Tra_NroLoteDoc"] = datDocComp.Doc_NroLoteDoc;
                            dataRowGrabar["tra_anio"] = datDocComp.Doc_fecha.Year;
                            dataRowGrabar["tra_mes"] = datDocComp.Doc_fecha.Month;
                            dataRowGrabar["tra_dia"] = datDocComp.Doc_fecha.Day;
                            dataRowGrabar["Tra_numlinea"] = nroRowNew;
                            
                            Dtable.Rows.Add(dataRowGrabar);
                        }
                    }
                }
                sel = "";
                adapter.Update(Dtable);
                adapter.Dispose();
                Dtable.Dispose();
            }
        }
        static public void grabarMallaAdctraPro(DataGridView malla, AdcDocPro datDoc, string strConx)
        {
            Int32[] campos;
            string[] tipos;
            string sel = "SELECT * FROM AdcTraPro WHERE doc_sucursal = '" + datDoc.Doc_sucursal + "' and opc_documento = '" + datDoc.Opc_documento + "' and idclavedoc = " + datDoc.IdClaveDoc.ToString();
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
                    if (MallaRow.Cells["Tra_codigo"].Value != null && (MallaRow.Cells["Tra_codigo"].Value).ToString() != string.Empty)
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
                            dataRowGrabar["Tra_DocSop"] = datDoc.Doc_DocSop;
                            dataRowGrabar["Tra_NumSop"] = datDoc.Doc_NumSop;
                            dataRowGrabar["Tra_fecha"] = datDoc.Doc_fecha;
                            dataRowGrabar["Tra_TipoDoc"] = datDoc.Doc_TipoDoc;
                            dataRowGrabar["Tra_Estado"] = 1;
                            dataRowGrabar["Tra_Oculto"] = Convert.ToInt16(datDoc.Doc_Oculto);
                            dataRowGrabar["Tra_Ventas"] = datDoc.Doc_Ventas;
                            dataRowGrabar["Tra_Inventario"] = datDoc.Doc_Inventario;
                            dataRowGrabar["Tra_Compras"] = datDoc.Doc_Compras;
                            dataRowGrabar["Tra_Activo"] = datDoc.Doc_Activo;
                            dataRowGrabar["Tra_NroLoteDoc"] = datDoc.Doc_NroLoteDoc;
                            dataRowGrabar["tra_anio"] = datDoc.Doc_fecha.Year;
                            dataRowGrabar["tra_mes"] = datDoc.Doc_fecha.Month;
                            dataRowGrabar["tra_dia"] = datDoc.Doc_fecha.Day;
                            dataRowGrabar["Tra_numlinea"] = nroRowNew;
                            Dtable.Rows.Add(dataRowGrabar);
                        }
                    }
                }
                sel = "";
                adapter.Update(Dtable);
                adapter.Dispose();
                Dtable.Dispose();
            }
        }

        static private Int32 verificaDataEnMalla(DataTable dt, DataGridView malla)
        {
            Int32 nroRow = 0;
            Int32 auxNro = 0;

            foreach (DataRow dtRow in dt.Rows)
            {
                try
                {
                    auxNro = Convert.ToInt32("0" + dtRow["Tra_numlinea"].ToString());
                }
                catch { continue; }

                if (nroRow < auxNro) nroRow = auxNro;

                if (datExisteEnMalla(dtRow, malla) == false)
                {
                    dtRow.Delete();
                }
            }
            return nroRow;
        }



        static private bool datExisteEnMalla(DataRow dtRow, DataGridView malla)
        {
            int numLineaDB = 0;
            try { numLineaDB = Convert.ToInt32("0" + dtRow["Tra_numlinea"].ToString()); }
            catch { return false; }

            foreach (DataGridViewRow mrow in malla.Rows)
            {
                if (mrow.IsNewRow) continue;

                int numLineaMalla = 0;
                try
                {
                    numLineaMalla = Convert.ToInt32("0" + mrow.Cells["Tra_numlinea"]?.Value?.ToString());
                }
                catch { continue; }

                if (numLineaDB != numLineaMalla) continue;

                var codigoValue = mrow.Cells["TRA_Codigo"]?.Value;
                if (codigoValue == null || codigoValue == DBNull.Value)
                    continue;

                string codigo = codigoValue.ToString().Trim();
                if (string.IsNullOrEmpty(codigo))
                    continue;

                return true;
            }
            return false;
        }

        static private DataRow existeData(DataTable datTab, DataGridViewRow mrow, ref bool esNuevo)
        {
            esNuevo = true;
            Int32 mallaLinea = Convert.ToInt32("0" + mrow.Cells["Tra_numlinea"].Value.ToString());

            foreach (DataRow dRow in datTab.Rows)
            {
                if (Convert.ToInt32("0" + dRow["Tra_numlinea"].ToString()) == mallaLinea)
                {
                    esNuevo = false;
                    return dRow;
                }
            }
            return datTab.NewRow();

        }
        //static private void encontrarDatosTipos(ref Int32[] campos, ref string[] tipos, DataTable table, DataGridView malla)
        //{
        //    for (int i = 0; i < malla.Columns.Count; i++)
        //    {
        //        for (int j = 0; j < table.Columns.Count; j++)
        //        {
        //            if (table.Columns[j].ColumnName.ToUpper() == malla.Columns[i].Name.ToUpper())
        //            {
        //                campos[j] = i;
        //                tipos[j] = table.Columns[j].DataType.Name;
        //            }
        //        }
        //    }
        //}

        static private void encontrarDatosTipos(ref Int32[] campos, ref string[] tipos, DataTable table, DataGridView malla)
        {
            for (int i = 0; i < malla.Columns.Count; i++)
            {
                for (int j = 0; j < table.Columns.Count; j++)
                {
                    // ✅ COMPARAR SIN DISTINGUIR MAYÚSCULAS/MINÚSCULAS
                    if (table.Columns[j].ColumnName.ToUpper() == malla.Columns[i].Name.ToUpper())
                    {
                        campos[j] = i;
                        tipos[j] = table.Columns[j].DataType.Name;

                        // ✅ DEBUG: Verificar qué columnas se están mapeando
                        System.Diagnostics.Debug.WriteLine($"Mapeando: {table.Columns[j].ColumnName} -> {malla.Columns[i].Name}");
                    }
                }
            }
        }


        static private void moverMallaData(DataGridViewCell cell, DataRow drow, Int32 campo, string tipo)
        {
            // ✅ VERIFICAR QUE LA CELDA NO SEA NULL Y TENGA VALOR
            if (cell == null || cell.Value == null || cell.Value == DBNull.Value)
            {
                drow[campo] = DBNull.Value;
                return;
            }

            string valorStr = cell.Value.ToString().Trim();
            if (string.IsNullOrEmpty(valorStr))
            {
                drow[campo] = DBNull.Value;
                return;
            }

            switch (tipo.ToUpper())
            {
                case "STRING":
                    drow[campo] = valorStr;
                    break;

                case "DECIMAL":
                case "NUMERIC":
                case "MONEY":
                case "SMALLMONEY":
                    // ✅ USAR CultureInfo.InvariantCulture para evitar errores de formato
                    decimal decValor;
                    if (decimal.TryParse(valorStr, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out decValor))
                        drow[campo] = decValor;
                    else
                        drow[campo] = 0.00m;
                    break;

                case "DATETIME":
                case "DATE":
                case "SMALLDATETIME":
                    DateTime dateValor;
                    if (DateTime.TryParse(valorStr, out dateValor))
                    {
                        // ✅ Si es 01/01/1900, guardar como NULL
                        if (dateValor.Year == 1900 && dateValor.Month == 1 && dateValor.Day == 1)
                            drow[campo] = DBNull.Value;
                        else
                            drow[campo] = dateValor;
                    }
                    else
                        drow[campo] = DBNull.Value;
                    break;

                case "INT32":
                case "INT":
                    int intValor;
                    if (int.TryParse(valorStr, out intValor))
                        drow[campo] = intValor;
                    else
                        drow[campo] = 0;
                    break;

                case "INT64":
                case "BIGINT":
                    long longValor;
                    if (long.TryParse(valorStr, out longValor))
                        drow[campo] = longValor;
                    else
                        drow[campo] = 0;
                    break;

                case "INT16":
                case "SMALLINT":
                    short shortValor;
                    if (short.TryParse(valorStr, out shortValor))
                        drow[campo] = shortValor;
                    else
                        drow[campo] = 0;
                    break;

                case "BIT":
                case "BOOLEAN":
                    bool boolValor;
                    if (bool.TryParse(valorStr, out boolValor))
                        drow[campo] = boolValor;
                    else if (valorStr == "1" || valorStr.ToUpper() == "TRUE" || valorStr.ToUpper() == "S")
                        drow[campo] = true;
                    else if (valorStr == "0" || valorStr.ToUpper() == "FALSE" || valorStr.ToUpper() == "N")
                        drow[campo] = false;
                    else
                        drow[campo] = false;
                    break;

                default:
                    drow[campo] = cell.Value;
                    break;
            }
        }

        static public void grabarDetalleAdctra(DataGridView malla, AdcDoc datDoc, string strConx)
        {
            string sel = "SELECT * FROM AdcTra WHERE doc_sucursal = '" + datDoc.Doc_sucursal + "' and opc_documento = '" + datDoc.Opc_documento + "' and idclavedoc = " + datDoc.IdClaveDoc.ToString();
            using (var adapter = new SqlDataAdapter(sel, strConx))
            using (new SqlCommandBuilder(adapter))
            {
                DataTable table = new DataTable();
                adapter.Fill(table);
                DataRow dr;
                ClassDoc.AdcTra adctra = new ClassDoc.AdcTra();
                adctra.Doc_sucursal = datDoc.Doc_sucursal;
                adctra.Doc_Bodega = datDoc.Doc_Bodega;
                adctra.Opc_documento = datDoc.Opc_documento;
                adctra.Doc_numero = datDoc.Doc_numero;
                adctra.IdClaveDoc = datDoc.IdClaveDoc;
                adctra.Tra_DocSop = datDoc.Doc_DocSop;
                adctra.Tra_NumSop = datDoc.Doc_NumSop;
                adctra.Tra_fecha = datDoc.Doc_fecha;
                adctra.Tra_TipoDoc = datDoc.Doc_TipoDoc;
                adctra.Tra_Estado = 1;
                adctra.Tra_Oculto = Convert.ToInt16(datDoc.Doc_Oculto);
                adctra.Tra_Ventas = datDoc.Doc_Ventas;
                adctra.Tra_Inventario = datDoc.Doc_Inventario;
                adctra.Tra_Compras = datDoc.Doc_Compras;
                adctra.Tra_Activo = datDoc.Doc_Activo;
                adctra.Tra_NroLoteDoc = datDoc.Doc_NroLoteDoc;

                adctra.tra_anio = adctra.Tra_fecha.Year;
                adctra.tra_mes = adctra.Tra_fecha.Month;
                adctra.tra_dia = adctra.Tra_fecha.Day;

                foreach (DataRow drow in table.Rows)
                {
                    drow.Delete();
                }

                Int32 i = 0;
                foreach (DataGridViewRow rrow in malla.Rows)
                {
                    if (rrow.Cells["TRA_Codigo"].Value != null && (rrow.Cells["TRA_Codigo"].Value).ToString() != string.Empty)
                    {
                        //if (i <= table.Rows.Count - 1) { dr = table.Rows[i]; } else { dr = table.NewRow(); }
                        dr = table.NewRow();
                        //campos obligatorios en todo programa de documentos con detalle
                        adctra.Tra_Codigo = rrow.Cells["Tra_Codigo"].Value.ToString();
                        adctra.Tra_nombre = rrow.Cells["Tra_nombre"].Value.ToString();
                        adctra.Tra_cantidad = Convert.ToDecimal(rrow.Cells["Tra_cantidad"].Value);
                        adctra.Tra_medida = rrow.Cells["Tra_medida"].Value.ToString();
                        adctra.Tra_quetipo = rrow.Cells["tra_queTipo"].Value.ToString();  // Articulo, Servicio, Activo fijo
                        adctra.Tra_Individual = rrow.Cells["Tra_Individual"].Value.ToString(); // con Serie, Talla , Compuesto o Ninguno
                        //adctra.Tra_sniva = false;
                        try
                        {
                            if (rrow.Cells["Tra_snIva"].Value != null) adctra.Tra_sniva = Convert.ToBoolean(rrow.Cells["Tra_snIva"].Value);
                        }
                        catch { }
                        adctra.Tra_multiplo = Convert.ToDecimal("0" + rrow.Cells["Tra_multiplo"].Value);
                        adctra.Tra_NroLote = rrow.Cells["Tra_NroLote"].Value.ToString();
                        adctra.tra_sucdestino = rrow.Cells["tra_sucdestino"].Value.ToString();    // transferencias
                        adctra.tra_boddestino = rrow.Cells["tra_boddestino"].Value.ToString();     //
                        adctra.Tra_piezas = Convert.ToDecimal("0" + rrow.Cells["Tra_piezas"].Value);
                        adctra.tra_peso = Convert.ToDecimal("0" + rrow.Cells["Tra_peso"].Value);
                        try
                        {
                            adctra.AuxVar3 = rrow.Cells["AuxVar3"].Value.ToString();
                        }
                        catch { }

                        //Tra_docotro	varchar(3)	Checked
                        //Tra_numotro	numeric(18, 0)	Checked
                        //Tra_descdes	varchar(40)	Checked
                        //Tra_valor	numeric(19, 4)	Checked
                        //Tra_extension	varchar(15)	Checked
                        //Tra_DepDes	varchar(50)	Checked

                        //Tra_Adicional1	numeric(19, 4)	Checked
                        //Tra_Adicional2	numeric(19, 4)	Checked
                        //Periodo1	datetime	Checked
                        //Periodo2	datetime	Checked
                        //FacDesde	datetime	Checked
                        //FacHasta	datetime	Checked
                        //Habitacion	varchar(15)	Checked
                        //Mesa	varchar(15)	Checked
                        //TipoPeriodo	varchar(20)	Checked
                        //AuxVar1	varchar(128)	Checked
                        //TipoCosto	char(1)	Checked
                        //Recosteo	bit	Checked

                        adctra.Tra_numlinea = i + 1;

                        // campos solo para progrmas con precios y costos
                        try
                        {
                            adctra.Tra_numprecio = rrow.Cells["Tra_numprecio"].Value.ToString();
                            adctra.Tra_precuni = Convert.ToDecimal("0" + rrow.Cells["Tra_precuni"].Value);
                            adctra.Tra_porcendes = Convert.ToDecimal("0" + rrow.Cells["Tra_porcendes"].Value);
                            adctra.Tra_valordes = Convert.ToDecimal("0" + rrow.Cells["Tra_valordes"].Value);
                            adctra.Tra_prectot = Convert.ToDecimal("0" + rrow.Cells["Tra_prectot"].Value);
                            //' 09 en esta columna se guradra  si es Talla, Serie o Ninguno
                            adctra.Tra_costuni = Convert.ToDecimal("0" + rrow.Cells["Tra_costouni"].Value);
                            adctra.Tra_costtot = Convert.ToDecimal("0" + rrow.Cells["Tra_costtot"].Value);
                            adctra.Despacho = Convert.ToDecimal("0" + rrow.Cells["Despacho"].Value.ToString());
                        }
                        catch { }

                        try
                        {
                            adctra.FacDesde = Convert.ToDateTime(rrow.Cells["FecDesde"].Value);
                            adctra.FacHasta = Convert.ToDateTime(rrow.Cells["FecHasta"].Value);
                            adctra.tra_Serie = rrow.Cells["Tra_Serie"].Value.ToString();
                        }
                        catch { }

                        try { adctra.Tra_vence = Convert.ToDateTime(rrow.Cells["Tra_vence"].Value); } catch { }


                        // con centros de costo
                        try
                        {
                            adctra.tra_costo = rrow.Cells["tra_costo"].Value.ToString();
                            adctra.tra_empleado = rrow.Cells["tra_empleado"].Value.ToString();
                            adctra.tra_centroproduccion = rrow.Cells["tra_centroproduccion"].Value.ToString();
                            adctra.tra_centroDistribucion = rrow.Cells["tra_centroDistribucion"].Value.ToString();
                            adctra.tra_proyecto = rrow.Cells["Tra_proyecto"].Value.ToString();
                            adctra.Tra_numprecio = rrow.Cells["Tra_numprecio"].Value.ToString();
                        }
                        catch { }
                        // solo floricolas
                        try
                        {
                            if (Convert.ToInt64("0" + rrow.Cells["Tallos"].Value) != 0)
                            {
                                adctra.Ramos = Convert.ToInt64("0" + rrow.Cells["Tra_Cantidad"].Value);
                                adctra.Largo = Convert.ToInt64("0" + rrow.Cells["Largo"].Value);
                                adctra.TallXramo = Convert.ToInt64("0" + rrow.Cells["TallXramo"].Value);
                                adctra.RamXcaja = Convert.ToInt64("0" + rrow.Cells["RamXcaja"].Value);
                                adctra.NroCaja = rrow.Cells["NroCaja"].Value.ToString();
                                adctra.TipCaja = rrow.Cells["TipCaja"].Value.ToString();
                                adctra.CantCajas = Convert.ToInt64("0" + rrow.Cells["CantCajas"].Value);
                                adctra.TotPeso = Convert.ToDecimal("0" + rrow.Cells["TotPeso"].Value);
                                adctra.Tallos = Convert.ToInt64("0" + rrow.Cells["Tallos"].Value);
                                adctra.Fulls = Convert.ToDecimal("0" + rrow.Cells["Fulls"].Value);
                                adctra.ZonaProducto = rrow.Cells["ZonaProducto"].Value.ToString();
                                adctra.HTS = rrow.Cells["HTS"].Value.ToString();
                                adctra.Nandina = rrow.Cells["Nandina"].Value.ToString();
                            }
                        }
                        catch { }

                        adctra.moverAdctraDatarow(adctra, ref dr);

                        //if (i > table.Rows.Count - 1) 
                        table.Rows.Add(dr);
                        i++;
                    }
                }
                //tra_directorio	varchar(50)	Checked
                //tra_relacionado	varchar(50)	Checked
                //tra_codigoalterno	varchar(50)	Checked
                //Tra_EsCuenta	bit	Checked
                //tra_producto	varchar(50)	Checked

                //CodigoBase	varchar(20)	Checked
                //Tra_Talla	varchar(20)	Checked
                //Tra_Color	varchar(20)	Checked
                //Tra_Dibujo	varchar(20)	Checked
                //Tra_Genero	varchar(20)	Checked
                //Tra_Modelo	varchar(20)	Checked

                //if (malla.RowCount < table.Rows.Count)
                //{
                //    for (int j = table.Rows.Count - 1; j > malla.RowCount - 1; j--)
                //    {
                //        table.Rows[j].Delete();
                //    }
                //}
                adapter.Update(table);
            }
        }

        static public void grabarDetalleAdctraComp(DataGridView malla, AdcDocComp datDoc, string strConx)
        {
            string sel = "SELECT * FROM AdcTra WHERE doc_sucursal = '" + datDoc.Doc_sucursal + "' and opc_documento = '" + datDoc.Opc_documento + "' and idclavedoc = " + datDoc.IdClaveDoc.ToString();
            using (var adapter = new SqlDataAdapter(sel, strConx))
            using (new SqlCommandBuilder(adapter))
            {
                DataTable table = new DataTable();
                adapter.Fill(table);
                DataRow dr;
                ClassDoc.AdcTra adctra = new ClassDoc.AdcTra();
                adctra.Doc_sucursal = datDoc.Doc_sucursal;
                adctra.Doc_Bodega = datDoc.Doc_Bodega;
                adctra.Opc_documento = datDoc.Opc_documento;
                adctra.Doc_numero = datDoc.Doc_numero;
                adctra.IdClaveDoc = datDoc.IdClaveDoc;
                adctra.Tra_DocSop = datDoc.Doc_DocSop;
                adctra.Tra_NumSop = datDoc.Doc_NumSop;
                adctra.Tra_fecha = datDoc.Doc_fecha;
                adctra.Tra_TipoDoc = datDoc.Doc_TipoDoc;
                adctra.Tra_Estado = 1;
                adctra.Tra_Oculto = Convert.ToInt16(datDoc.Doc_Oculto);
                adctra.Tra_Ventas = datDoc.Doc_Ventas;
                adctra.Tra_Inventario = datDoc.Doc_Inventario;
                adctra.Tra_Compras = datDoc.Doc_Compras;
                adctra.Tra_Activo = datDoc.Doc_Activo;
                adctra.Tra_NroLoteDoc = datDoc.Doc_NroLoteDoc;

                adctra.tra_anio = adctra.Tra_fecha.Year;
                adctra.tra_mes = adctra.Tra_fecha.Month;
                adctra.tra_dia = adctra.Tra_fecha.Day;

                foreach (DataRow drow in table.Rows)
                {
                    drow.Delete();
                }

                Int32 i = 0;
                foreach (DataGridViewRow rrow in malla.Rows)
                {
                    if (rrow.Cells["COM_Codigo"].Value != null && (rrow.Cells["COM_Codigo"].Value).ToString() != string.Empty)
                    {
                        //if (i <= table.Rows.Count - 1) { dr = table.Rows[i]; } else { dr = table.NewRow(); }
                        dr = table.NewRow();
                        //campos obligatorios en todo programa de documentos con detalle
                        adctra.Tra_Codigo = rrow.Cells["COM_Codigo"].Value.ToString();
                        adctra.Tra_nombre = rrow.Cells["art_nombre"].Value.ToString();
                        adctra.Tra_cantidad = Convert.ToDecimal(rrow.Cells["Tra_cantidad"].Value);
                        adctra.Tra_medida = rrow.Cells["Tra_medida"].Value.ToString();
                        adctra.Tra_quetipo = rrow.Cells["tra_queTipo"].Value.ToString();  // Articulo, Servicio, Activo fijo
                        adctra.Tra_Individual = rrow.Cells["Tra_Individual"].Value.ToString(); // con Serie, Talla , Compuesto o Ninguno
                        adctra.Tra_sniva = false;
                        try
                        {
                            if (rrow.Cells["Tra_snIva"].Value != null) adctra.Tra_sniva = Convert.ToBoolean(rrow.Cells["Tra_snIva"].Value);
                        }
                        catch { }
                        adctra.Tra_multiplo = Convert.ToDecimal("0" + rrow.Cells["Tra_multiplo"].Value);
                        adctra.Tra_NroLote = rrow.Cells["Tra_NroLote"].Value.ToString();
                        adctra.tra_sucdestino = rrow.Cells["tra_sucdestino"].Value.ToString();    // transferencias
                        adctra.tra_boddestino = rrow.Cells["tra_boddestino"].Value.ToString();     //
                        adctra.Tra_piezas = Convert.ToDecimal("0" + rrow.Cells["Tra_piezas"].Value);
                        adctra.tra_peso = Convert.ToDecimal("0" + rrow.Cells["Tra_peso"].Value);
                        try
                        {
                            adctra.AuxVar3 = rrow.Cells["AuxVar3"].Value.ToString();
                        }
                        catch { }

                        //Tra_docotro	varchar(3)	Checked
                        //Tra_numotro	numeric(18, 0)	Checked
                        //Tra_descdes	varchar(40)	Checked
                        //Tra_valor	numeric(19, 4)	Checked
                        //Tra_extension	varchar(15)	Checked
                        //Tra_DepDes	varchar(50)	Checked

                        //Tra_Adicional1	numeric(19, 4)	Checked
                        //Tra_Adicional2	numeric(19, 4)	Checked
                        //Periodo1	datetime	Checked
                        //Periodo2	datetime	Checked
                        //FacDesde	datetime	Checked
                        //FacHasta	datetime	Checked
                        //Habitacion	varchar(15)	Checked
                        //Mesa	varchar(15)	Checked
                        //TipoPeriodo	varchar(20)	Checked
                        //AuxVar1	varchar(128)	Checked
                        //TipoCosto	char(1)	Checked
                        //Recosteo	bit	Checked

                        adctra.Tra_numlinea = i + 1;

                        // campos solo para progrmas con precios y costos
                        try
                        {
                            adctra.Tra_numprecio = rrow.Cells["Tra_numprecio"].Value.ToString();
                            adctra.Tra_precuni = Convert.ToDecimal("0" + rrow.Cells["Tra_precuni"].Value);
                            adctra.Tra_porcendes = Convert.ToDecimal("0" + rrow.Cells["Tra_porcendes"].Value);
                            adctra.Tra_valordes = Convert.ToDecimal("0" + rrow.Cells["Tra_valordes"].Value);
                            adctra.Tra_prectot = Convert.ToDecimal("0" + rrow.Cells["Tra_prectot"].Value);
                            //' 09 en esta columna se guradra  si es Talla, Serie o Ninguno
                            adctra.Tra_costuni = Convert.ToDecimal("0" + rrow.Cells["Tra_costouni"].Value);
                            adctra.Tra_costtot = Convert.ToDecimal("0" + rrow.Cells["Tra_costtot"].Value);
                            adctra.Despacho = Convert.ToDecimal("0" + rrow.Cells["Despacho"].Value.ToString());
                        }
                        catch { }

                        try
                        {
                            adctra.FacDesde = Convert.ToDateTime(rrow.Cells["FecDesde"].Value);
                            adctra.FacHasta = Convert.ToDateTime(rrow.Cells["FecHasta"].Value);
                            adctra.tra_Serie = rrow.Cells["Tra_Serie"].Value.ToString();
                        }
                        catch { }

                        try { adctra.Tra_vence = Convert.ToDateTime(rrow.Cells["Tra_vence"].Value); } catch { }


                        // con centros de costo
                        try
                        {
                            adctra.tra_costo = rrow.Cells["tra_costo"].Value.ToString();
                            adctra.tra_empleado = rrow.Cells["tra_empleado"].Value.ToString();
                            adctra.tra_centroproduccion = rrow.Cells["tra_centroproduccion"].Value.ToString();
                            adctra.tra_centroDistribucion = rrow.Cells["tra_centroDistribucion"].Value.ToString();
                            adctra.tra_proyecto = rrow.Cells["Tra_proyecto"].Value.ToString();
                            adctra.Tra_numprecio = rrow.Cells["Tra_numprecio"].Value.ToString();
                        }
                        catch { }
                        // solo floricolas
                        try
                        {
                            if (Convert.ToInt64("0" + rrow.Cells["Tallos"].Value) != 0)
                            {
                                adctra.Ramos = Convert.ToInt64("0" + rrow.Cells["Tra_Cantidad"].Value);
                                adctra.Largo = Convert.ToInt64("0" + rrow.Cells["Largo"].Value);
                                adctra.TallXramo = Convert.ToInt64("0" + rrow.Cells["TallXramo"].Value);
                                adctra.RamXcaja = Convert.ToInt64("0" + rrow.Cells["RamXcaja"].Value);
                                adctra.NroCaja = rrow.Cells["NroCaja"].Value.ToString();
                                adctra.TipCaja = rrow.Cells["TipCaja"].Value.ToString();
                                adctra.CantCajas = Convert.ToInt64("0" + rrow.Cells["CantCajas"].Value);
                                adctra.TotPeso = Convert.ToDecimal("0" + rrow.Cells["TotPeso"].Value);
                                adctra.Tallos = Convert.ToInt64("0" + rrow.Cells["Tallos"].Value);
                                adctra.Fulls = Convert.ToDecimal("0" + rrow.Cells["Fulls"].Value);
                                adctra.ZonaProducto = rrow.Cells["ZonaProducto"].Value.ToString();
                                adctra.HTS = rrow.Cells["HTS"].Value.ToString();
                                adctra.Nandina = rrow.Cells["Nandina"].Value.ToString();
                            }
                        }
                        catch { }

                        adctra.moverAdctraDatarow(adctra, ref dr);

                        //if (i > table.Rows.Count - 1) 
                        table.Rows.Add(dr);
                        i++;
                    }
                }
                //tra_directorio	varchar(50)	Checked
                //tra_relacionado	varchar(50)	Checked
                //tra_codigoalterno	varchar(50)	Checked
                //Tra_EsCuenta	bit	Checked
                //tra_producto	varchar(50)	Checked

                //CodigoBase	varchar(20)	Checked
                //Tra_Talla	varchar(20)	Checked
                //Tra_Color	varchar(20)	Checked
                //Tra_Dibujo	varchar(20)	Checked
                //Tra_Genero	varchar(20)	Checked
                //Tra_Modelo	varchar(20)	Checked

                //if (malla.RowCount < table.Rows.Count)
                //{
                //    for (int j = table.Rows.Count - 1; j > malla.RowCount - 1; j--)
                //    {
                //        table.Rows[j].Delete();
                //    }
                //}
                adapter.Update(table);
            }
        }


        static public void grabarDetalleAdctraPro(DataGridView malla, AdcDocPro datDocPro, string strConx)
        {
            string sel = "SELECT * FROM AdcTraPro WHERE doc_sucursal = '" + datDocPro.Doc_sucursal + "' and opc_documento = '" + datDocPro.Opc_documento + "' and idclavedoc = " + datDocPro.IdClaveDoc.ToString();
            using (var adapter = new SqlDataAdapter(sel, strConx))
            using (new SqlCommandBuilder(adapter))
            {
                DataTable table = new DataTable();
                adapter.Fill(table);
                DataRow dr;
                ClassDoc.AdcTraPro adctraPro = new ClassDoc.AdcTraPro();
                adctraPro.Doc_sucursal = datDocPro.Doc_sucursal;
                adctraPro.Opc_documento = datDocPro.Opc_documento;
                adctraPro.Doc_numero = datDocPro.Doc_numero;
                adctraPro.IdClaveDoc = datDocPro.IdClaveDoc;
                adctraPro.Tra_DocSop = datDocPro.Doc_DocSop;
                adctraPro.Tra_NumSop = datDocPro.Doc_NumSop;
                adctraPro.Tra_fecha = datDocPro.Doc_fecha;
                adctraPro.Tra_TipoDoc = datDocPro.Doc_TipoDoc;
                adctraPro.Tra_Estado = 1;
                adctraPro.Tra_Oculto = Convert.ToInt16(datDocPro.Doc_Oculto);
                adctraPro.Tra_Ventas = datDocPro.Doc_Ventas;
                adctraPro.Tra_Inventario = datDocPro.Doc_Inventario;
                adctraPro.Tra_Compras = datDocPro.Doc_Compras;
                adctraPro.Tra_Activo = datDocPro.Doc_Activo;
                adctraPro.Tra_NroLoteDoc = datDocPro.Doc_NroLoteDoc;

                adctraPro.tra_anio = adctraPro.Tra_fecha.Year;
                adctraPro.tra_mes = adctraPro.Tra_fecha.Month;
                adctraPro.tra_dia = adctraPro.Tra_fecha.Day;

                foreach (DataRow drow in table.Rows)
                {
                    drow.Delete();
                }

                Int32 i = 0;
                foreach (DataGridViewRow rrow in malla.Rows)
                {
                    if (rrow.Cells["TRA_Codigo"].Value != null && (rrow.Cells["TRA_Codigo"].Value).ToString() != string.Empty)
                    {
                        //if (i <= table.Rows.Count - 1) { dr = table.Rows[i]; } else { dr = table.NewRow(); }
                        dr = table.NewRow();
                        //campos obligatorios en todo programa de documentos con detalle
                        adctraPro.Tra_Codigo = rrow.Cells["Tra_Codigo"].Value.ToString();
                        adctraPro.Tra_nombre = rrow.Cells["Tra_nombre"].Value.ToString();
                        adctraPro.Tra_cantidad = Convert.ToDecimal(rrow.Cells["Tra_cantidad"].Value);
                        adctraPro.Tra_medida = rrow.Cells["Tra_medida"].Value.ToString();
                        adctraPro.Tra_quetipo = rrow.Cells["tra_queTipo"].Value.ToString();  // Articulo, Servicio, Activo fijo
                        adctraPro.Tra_Individual = rrow.Cells["Tra_Individual"].Value.ToString(); // con Serie, Talla , Compuesto o Ninguno
                        adctraPro.Tra_sniva = Convert.ToBoolean(rrow.Cells["Tra_snIva"].Value);
                        adctraPro.Tra_multiplo = Convert.ToDecimal("0" + rrow.Cells["Tra_multiplo"].Value);
                        adctraPro.Tra_NroLote = rrow.Cells["Tra_NroLote"].Value.ToString();
                        adctraPro.tra_sucdestino = rrow.Cells["tra_sucdestino"].Value.ToString();    // transferencias
                        adctraPro.tra_boddestino = rrow.Cells["tra_boddestino"].Value.ToString();     //
                        adctraPro.Tra_piezas = Convert.ToDecimal("0" + rrow.Cells["Tra_piezas"].Value);
                        adctraPro.tra_peso = Convert.ToDecimal("0" + rrow.Cells["Tra_peso"].Value);
                        if (rrow.Cells["Doc_Bodega"].Value.ToString().Length > 0) adctraPro.Doc_Bodega = rrow.Cells["Doc_Bodega"].Value.ToString(); else adctraPro.Doc_Bodega = datDocPro.Doc_Bodega;
                        adctraPro.DetalleItm = rrow.Cells["DetalleItm"].Value.ToString();
                        //Tra_docotro	varchar(3)	Checked
                        //Tra_numotro	numeric(18, 0)	Checked
                        //Tra_descdes	varchar(40)	Checked
                        //Tra_valor	numeric(19, 4)	Checked
                        //Tra_extension	varchar(15)	Checked
                        //Tra_DepDes	varchar(50)	Checked

                        //Tra_Adicional1	numeric(19, 4)	Checked
                        //Tra_Adicional2	numeric(19, 4)	Checked
                        //Periodo1	datetime	Checked
                        //Periodo2	datetime	Checked
                        //FacDesde	datetime	Checked
                        //FacHasta	datetime	Checked
                        //Habitacion	varchar(15)	Checked
                        //Mesa	varchar(15)	Checked
                        //TipoPeriodo	varchar(20)	Checked
                        //AuxVar1	varchar(128)	Checked
                        //TipoCosto	char(1)	Checked
                        //Recosteo	bit	Checked

                        adctraPro.Tra_numlinea = i + 1;

                        // campos solo para progrmas con precios y costos
                        try
                        {
                            adctraPro.Tra_numprecio = rrow.Cells["Tra_numprecio"].Value.ToString();
                            adctraPro.Tra_precuni = Convert.ToDecimal("0" + rrow.Cells["Tra_precuni"].Value);
                            adctraPro.Tra_porcendes = Convert.ToDecimal("0" + rrow.Cells["Tra_porcendes"].Value);
                            adctraPro.Tra_valordes = Convert.ToDecimal("0" + rrow.Cells["Tra_valordes"].Value);
                            adctraPro.Tra_prectot = Convert.ToDecimal("0" + rrow.Cells["Tra_prectot"].Value);
                            //' 09 en esta columna se guradra  si es Talla, Serie o Ninguno
                            adctraPro.Tra_costuni = Convert.ToDecimal("0" + rrow.Cells["Tra_costouni"].Value);
                            adctraPro.Tra_costtot = Convert.ToDecimal("0" + rrow.Cells["Tra_costtot"].Value);
                            adctraPro.Despacho = Convert.ToDecimal("0" + rrow.Cells["Despacho"].Value);
                        }
                        catch { }

                        try
                        {
                            adctraPro.FacDesde = Convert.ToDateTime(rrow.Cells["FecDesde"].Value);
                            adctraPro.FacHasta = Convert.ToDateTime(rrow.Cells["FecHasta"].Value);
                            //adctraPro.tra_Serie = rrow.Cells["Tra_Serie"].Value.ToString();
                        }
                        catch { }

                        try { adctraPro.Tra_vence = Convert.ToDateTime(rrow.Cells["Tra_vence"].Value); }
                        catch { }


                        // con centros de costo
                        try
                        {
                            adctraPro.tra_costo = rrow.Cells["tra_costo"].Value.ToString();
                            adctraPro.tra_empleado = rrow.Cells["tra_empleado"].Value.ToString();
                            adctraPro.tra_centroproduccion = rrow.Cells["tra_centroproduccion"].Value.ToString();
                            adctraPro.tra_centroDistribucion = rrow.Cells["tra_centroDistribucion"].Value.ToString();
                            adctraPro.tra_proyecto = rrow.Cells["Tra_proyecto"].Value.ToString();
                            adctraPro.Tra_numprecio = rrow.Cells["Tra_numprecio"].Value.ToString();
                        }
                        catch { }
                        // solo floricolas
                        try
                        {
                            if (Convert.ToInt64("0" + rrow.Cells["Tallos"].Value) > 0)
                            {
                                adctraPro.Ramos = Convert.ToInt64("0" + rrow.Cells["tra_cantidad"].Value);
                                adctraPro.Largo = Convert.ToInt64("0" + rrow.Cells["Largo"].Value);
                                adctraPro.TallXramo = Convert.ToInt64("0" + rrow.Cells["TallXramo"].Value);
                                adctraPro.RamXcaja = Convert.ToInt64("0" + rrow.Cells["RamXcaja"].Value);
                                adctraPro.NroCaja = rrow.Cells["NroCaja"].Value.ToString();
                                adctraPro.TipCaja = rrow.Cells["TipCaja"].Value.ToString();
                                adctraPro.CantCajas = Convert.ToInt64("0" + rrow.Cells["CantCajas"].Value);
                                adctraPro.TotPeso = Convert.ToDecimal("0" + rrow.Cells["TotPeso"].Value);
                                adctraPro.Tallos = Convert.ToInt64("0" + rrow.Cells["Tallos"].Value);
                                adctraPro.Fulls = Convert.ToDecimal("0" + rrow.Cells["Fulls"].Value);
                                adctraPro.ZonaProducto = rrow.Cells["ZonaProducto"].Value.ToString();
                                adctraPro.HTS = rrow.Cells["HTS"].Value.ToString();
                                adctraPro.Nandina = rrow.Cells["Nandina"].Value.ToString();
                            }
                        }
                        catch { }

                        adctraPro.MoverAdcTraPro2Row(adctraPro, ref dr);
                        table.Rows.Add(dr);
                        i++;
                    }
                }
                //tra_directorio	varchar(50)	Checked
                //tra_relacionado	varchar(50)	Checked
                //tra_codigoalterno	varchar(50)	Checked
                //Tra_EsCuenta	bit	Checked
                //tra_producto	varchar(50)	Checked

                //CodigoBase	varchar(20)	Checked
                //Tra_Talla	varchar(20)	Checked
                //Tra_Color	varchar(20)	Checked
                //Tra_Dibujo	varchar(20)	Checked
                //Tra_Genero	varchar(20)	Checked
                //Tra_Modelo	varchar(20)	Checked

                //if (malla.RowCount < table.Rows.Count)
                //{
                //    for (int j = table.Rows.Count - 1; j > malla.RowCount - 1; j--)
                //    {
                //        table.Rows[j].Delete();
                //    }
                //}
                adapter.Update(table);
            }
        }

        static public void grabarDetalleAdctraXML(DataGridView malla, AdcDoc datAdoc, string cadenaConexion)
        {
            string sel = "SELECT * FROM AdcTra WHERE doc_sucursal = '" + datAdoc.Doc_sucursal + "' and opc_documento = '" + datAdoc.Opc_documento + "' and idclavedoc = " + datAdoc.IdClaveDoc.ToString();

            using (var con = new SqlConnection(cadenaConexion))
            using (var adapter = new SqlDataAdapter(sel, cadenaConexion))
            using (new SqlCommandBuilder(adapter))
            {
                DataTable table = new DataTable();
                adapter.Fill(table);
                DataRow dr;
                ClassDoc.AdcTra adctra = new ClassDoc.AdcTra();

                // Primero, copiar los valores comunes una vez
                adctra.Doc_sucursal = datAdoc.Doc_sucursal;
                adctra.Opc_documento = datAdoc.Opc_documento;
                adctra.Doc_numero = datAdoc.Doc_numero;
                adctra.IdClaveDoc = datAdoc.IdClaveDoc;
                adctra.Doc_Bodega = datAdoc.Doc_Bodega;
                adctra.Tra_DocSop = datAdoc.Doc_DocSop;
                adctra.Tra_NumSop = datAdoc.Doc_NumSop;
                adctra.Tra_fecha = datAdoc.Doc_fecha;
                adctra.Tra_TipoDoc = datAdoc.Doc_TipoDoc;
                adctra.Tra_Estado = Convert.ToInt16(datAdoc.Doc_Estado);
                adctra.Tra_Oculto = Convert.ToInt16(datAdoc.Doc_Oculto);
                adctra.Tra_Ventas = datAdoc.Doc_Ventas;
                adctra.Tra_Inventario = datAdoc.Doc_Inventario;
                adctra.Tra_Compras = datAdoc.Doc_Compras;
                adctra.Tra_Activo = datAdoc.Doc_Activo;

                // ============================================
                // CALCULAR EL VALOR REAL TOTAL (14.73)
                // Sumando todas las líneas: base + IVA
                // ============================================
                decimal valorRealTotal = 0;
                int lineasProcesadas = 0;

                foreach (DataGridViewRow rrow in malla.Rows)
                {
                    if (rrow.IsNewRow || rrow.Cells["codProductoPropio"].Value == null)
                        continue;

                    try
                    {
                        lineasProcesadas++;

                        // Obtener base de la línea (Tra_prectot o calcular)
                        decimal baseLinea = 0;
                        if (malla.Columns.Contains("Tra_prectot") && rrow.Cells["Tra_prectot"]?.Value != null)
                        {
                            baseLinea = Convert.ToDecimal(rrow.Cells["Tra_prectot"].Value);
                        }
                        else if (rrow.Cells["Cantidad"].Value != null && rrow.Cells["PvUni"].Value != null)
                        {
                            decimal cantidad = Convert.ToDecimal(rrow.Cells["Cantidad"].Value);
                            decimal precioUnitario = Convert.ToDecimal(rrow.Cells["PvUni"].Value);
                            baseLinea = cantidad * precioUnitario;
                        }

                        // Obtener IVA de la línea
                        decimal ivaLinea = 0;
                        if (malla.Columns.Contains("Tra_valoriva") && rrow.Cells["Tra_valoriva"]?.Value != null)
                        {
                            ivaLinea = Convert.ToDecimal(rrow.Cells["Tra_valoriva"].Value);
                        }

                        // Sumar al total real
                        valorRealTotal += baseLinea + ivaLinea;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error calculando línea {lineasProcesadas}: {ex.Message}");
                    }
                }

                Console.WriteLine("\n=== RESUMEN DE VALORES ===");
                Console.WriteLine($"Valor del XML (Doc_valor): {datAdoc.Doc_valor}");
                Console.WriteLine($"Valor REAL calculado: {valorRealTotal}");
                Console.WriteLine($"Líneas procesadas: {lineasProcesadas}");

                // DECIDIR QUÉ VALOR USAR PARA Tra_valor
                decimal valorParaTraValor = datAdoc.Doc_valor; // Por defecto usar XML

                if (Math.Abs(valorRealTotal - datAdoc.Doc_valor) > 0.01m)
                {
                    Console.WriteLine($"¡INCONSISTENCIA! Diferencia: {Math.Abs(valorRealTotal - datAdoc.Doc_valor)}");
                    Console.WriteLine($"Usando valor REAL en Tra_valor: {valorRealTotal}");
                    valorParaTraValor = valorRealTotal; // Usar valor real si hay inconsistencia
                }
                else
                {
                    Console.WriteLine($"Valores consistentes. Usando valor del XML: {datAdoc.Doc_valor}");
                }

                Int32 i = 0;
                foreach (DataGridViewRow rrow in malla.Rows)
                {
                    if (rrow.IsNewRow) continue;

                    if (rrow.Cells["codProductoPropio"].Value != null &&
                        rrow.Cells["codProductoPropio"].Value.ToString() != string.Empty)
                    {
                        if (i <= table.Rows.Count - 1)
                        {
                            dr = table.Rows[i];
                        }
                        else
                        {
                            dr = table.NewRow();
                        }

                        // Código y descripción
                        adctra.Tra_Codigo = rrow.Cells["codProductoPropio"].Value.ToString();
                        adctra.Tra_nombre = rrow.Cells["DetalleAutilizar"].Value.ToString();
                        adctra.Tra_cantidad = Convert.ToDecimal(rrow.Cells["Cantidad"].Value);

                        // Determinar si es Producto (A) o Servicio/Concepto (S)
                        if (rrow.Cells["ConceptoProducto"].Value.ToString().ToUpper() == "PRODUCTO")
                            adctra.Tra_quetipo = "A";
                        else
                            adctra.Tra_quetipo = "S";

                        adctra.Tra_medida = "UND";
                        adctra.Tra_numlinea = i + 1;

                        // NUMERO DE PRECIO - SIEMPRE "1"
                        adctra.Tra_numprecio = "1";

                        // Precios por LÍNEA
                        adctra.Tra_precuni = Convert.ToDecimal(rrow.Cells["PvUni"].Value);
                        adctra.Tra_prectot = adctra.Tra_precuni * adctra.Tra_cantidad; // Subtotal de la línea
                        adctra.Tra_valordes = Convert.ToDecimal(rrow.Cells["PorcDes"].Value);

                        // ============================================
                        // ¡¡¡CORRECCIÓN IMPORTANTE!!!
                        // Tra_valor debe ser el VALOR TOTAL DE LA FACTURA
                        // Usar el valor REAL (14.73) no el del XML (13.85)
                        // ============================================
                        adctra.Tra_valor = valorParaTraValor; // ← 14.73 para TODAS las líneas

                        Console.WriteLine($"Línea {i + 1}: Tra_valor = {valorParaTraValor}");

                        // Lote y vencimiento
                        adctra.Tra_NroLote = rrow.Cells["Lote"].Value?.ToString() ?? "";
                        try
                        {
                            adctra.AuxVar1 = rrow.Cells["Vence"].Value?.ToString() ?? "";
                        }
                        catch { }
                        adctra.tra_codigoalterno = rrow.Cells["CodAlterno"].Value?.ToString() ?? "";

                        // Porcentaje de descuento
                        try
                        {
                            if (adctra.Tra_prectot > 0 && adctra.Tra_valordes > 0)
                            {
                                adctra.Tra_porcendes = (adctra.Tra_valordes / adctra.Tra_prectot) * 100;
                            }
                            else
                            {
                                adctra.Tra_porcendes = 0;
                            }
                        }
                        catch
                        {
                            adctra.Tra_porcendes = 0;
                        }

                        // IVA (por línea)
                        adctra.Tra_sniva = Convert.ToBoolean(rrow.Cells["iva"].Value);

                        // Porcentaje de IVA (por línea)
                        decimal porcIva = 0;
                        if (malla.Columns.Contains("Tra_porceniva") && rrow.Cells["Tra_porceniva"]?.Value != null)
                        {
                            try
                            {
                                porcIva = Convert.ToDecimal(rrow.Cells["Tra_porceniva"].Value);
                            }
                            catch
                            {
                                porcIva = adctra.Tra_sniva ? datAdoc.Doc_porceniva : 0;
                            }
                        }
                        else
                        {
                            porcIva = adctra.Tra_sniva ? datAdoc.Doc_porceniva : 0;
                        }
                        adctra.Tra_porceniva = porcIva;

                        // Valor de IVA (por línea)
                        decimal valorIva = 0;
                        if (malla.Columns.Contains("Tra_valoriva") && rrow.Cells["Tra_valoriva"]?.Value != null)
                        {
                            try
                            {
                                valorIva = Convert.ToDecimal(rrow.Cells["Tra_valoriva"].Value);
                            }
                            catch
                            {
                                // Calcular basado en el subtotal de la línea
                                valorIva = adctra.Tra_sniva ? (adctra.Tra_prectot * (porcIva / 100)) : 0;
                            }
                        }
                        else
                        {
                            // Calcular basado en el subtotal de la línea
                            valorIva = adctra.Tra_sniva ? (adctra.Tra_prectot * (porcIva / 100)) : 0;
                        }
                        adctra.Tra_valoriva = valorIva;

                        // Costos (por línea)
                        if (adctra.Tra_quetipo == "A") // Artículo
                        {
                            decimal costoUnitario = 0;
                            if (malla.Columns.Contains("Tra_costuni") && rrow.Cells["Tra_costuni"]?.Value != null)
                            {
                                try
                                {
                                    costoUnitario = Convert.ToDecimal(rrow.Cells["Tra_costuni"].Value);
                                }
                                catch
                                {
                                    costoUnitario = adctra.Tra_precuni;
                                }
                            }
                            else
                            {
                                costoUnitario = adctra.Tra_precuni;
                            }

                            adctra.Tra_costuni = costoUnitario;
                            adctra.Tra_costtot = costoUnitario * adctra.Tra_cantidad;
                        }
                        else // Servicio
                        {
                            adctra.Tra_costuni = 0;
                            adctra.Tra_costtot = 0;
                        }

                        // Campos adicionales
                        adctra.Tra_Individual = "N";
                        adctra.Tra_multiplo = 1;

                        // Campos de fecha para contabilidad
                        adctra.tra_anio = datAdoc.Doc_fecha.Year;
                        adctra.tra_mes = datAdoc.Doc_fecha.Month;
                        adctra.tra_dia = datAdoc.Doc_fecha.Day;

                        // Transferir a DataRow
                        adctra.moverAdctraDatarow(adctra, ref dr);

                        if (i > table.Rows.Count - 1)
                            table.Rows.Add(dr);

                        i++;
                    }
                }

                // Eliminar filas sobrantes si hay menos filas en la malla
                if (i < table.Rows.Count)
                {
                    for (int j = table.Rows.Count - 1; j >= i; j--)
                    {
                        table.Rows[j].Delete();
                    }
                }

                // Actualizar la base de datos
                int registrosActualizados = adapter.Update(table);
                Console.WriteLine($"\n✅ Registros guardados en AdcTra: {registrosActualizados}");
                Console.WriteLine($"✅ Valor guardado en Tra_valor: {valorParaTraValor}");

                // Calcular y actualizar totales por tipo en adcdoc
                CalcularYActualizarTotalesPorTipo(malla, datAdoc, cadenaConexion);
            }
        }


        //static public void grabarDetalleAdctraXML(DataGridView malla, AdcDoc datAdoc, string cadenaConexion)
        //{
        //	string sel = "SELECT * FROM AdcTra WHERE doc_sucursal = '" + datAdoc.Doc_sucursal + "' and opc_documento = '" + datAdoc.Opc_documento + "' and idclavedoc = " + datAdoc.IdClaveDoc.ToString();

        //	using (var con = new SqlConnection(cadenaConexion))
        //	using (var adapter = new SqlDataAdapter(sel, cadenaConexion))
        //	using (new SqlCommandBuilder(adapter))
        //	{
        //		DataTable table = new DataTable();
        //		adapter.Fill(table);
        //		DataRow dr;
        //		ClassDoc.AdcTra adctra = new ClassDoc.AdcTra();

        //		adctra.Doc_sucursal = datAdoc.Doc_sucursal;
        //		adctra.Opc_documento = datAdoc.Opc_documento;
        //		adctra.Doc_numero = datAdoc.Doc_numero;
        //		adctra.IdClaveDoc = datAdoc.IdClaveDoc;
        //		adctra.Doc_Bodega = datAdoc.Doc_Bodega;
        //		adctra.Tra_DocSop = datAdoc.Doc_DocSop;
        //		adctra.Tra_NumSop = datAdoc.Doc_NumSop;
        //		adctra.Tra_fecha = datAdoc.Doc_fecha;
        //		adctra.Tra_TipoDoc = datAdoc.Doc_TipoDoc;
        //		adctra.Tra_Estado = Convert.ToInt16(datAdoc.Doc_Estado);
        //		adctra.Tra_Oculto = Convert.ToInt16(datAdoc.Doc_Oculto);
        //		adctra.Tra_Ventas = datAdoc.Doc_Ventas;
        //		adctra.Tra_Inventario = datAdoc.Doc_Inventario;
        //		adctra.Tra_Compras = datAdoc.Doc_Compras;
        //		adctra.Tra_Activo = datAdoc.Doc_Activo;

        //		// VALOR TOTAL DE LA FACTURA (para todos los registros)
        //		decimal valorTotalFactura = datAdoc.Doc_valor; // Esto es 24.85

        //		Int32 i = 0;
        //		foreach (DataGridViewRow rrow in malla.Rows)
        //		{
        //			if (rrow.IsNewRow) continue;

        //			if (rrow.Cells["codProductoPropio"].Value != null &&
        //				rrow.Cells["codProductoPropio"].Value.ToString() != string.Empty)
        //			{
        //				if (i <= table.Rows.Count - 1)
        //				{
        //					dr = table.Rows[i];
        //				}
        //				else
        //				{
        //					dr = table.NewRow();
        //				}

        //				// Reiniciar adctra para cada línea (importante)
        //				adctra = new ClassDoc.AdcTra();

        //				// Copiar valores comunes
        //				adctra.Doc_sucursal = datAdoc.Doc_sucursal;
        //				adctra.Opc_documento = datAdoc.Opc_documento;
        //				adctra.Doc_numero = datAdoc.Doc_numero;
        //				adctra.IdClaveDoc = datAdoc.IdClaveDoc;
        //				adctra.Doc_Bodega = datAdoc.Doc_Bodega;
        //				adctra.Tra_DocSop = datAdoc.Doc_DocSop;
        //				adctra.Tra_NumSop = datAdoc.Doc_NumSop;
        //				adctra.Tra_fecha = datAdoc.Doc_fecha;
        //				adctra.Tra_TipoDoc = datAdoc.Doc_TipoDoc;
        //				adctra.Tra_Estado = Convert.ToInt16(datAdoc.Doc_Estado);
        //				adctra.Tra_Oculto = Convert.ToInt16(datAdoc.Doc_Oculto);
        //				adctra.Tra_Ventas = datAdoc.Doc_Ventas;
        //				adctra.Tra_Inventario = datAdoc.Doc_Inventario;
        //				adctra.Tra_Compras = datAdoc.Doc_Compras;
        //				adctra.Tra_Activo = datAdoc.Doc_Activo;

        //				// Código y descripción
        //				adctra.Tra_Codigo = rrow.Cells["codProductoPropio"].Value.ToString();
        //				adctra.Tra_nombre = rrow.Cells["DetalleAutilizar"].Value.ToString();
        //				adctra.Tra_cantidad = Convert.ToDecimal(rrow.Cells["Cantidad"].Value);

        //				// Determinar si es Producto (A) o Servicio/Concepto (S)
        //				if (rrow.Cells["ConceptoProducto"].Value.ToString().ToUpper() == "PRODUCTO")
        //					adctra.Tra_quetipo = "A";
        //				else
        //					adctra.Tra_quetipo = "S";

        //				adctra.Tra_medida = "UND";
        //				adctra.Tra_numlinea = i + 1;

        //				// NUMERO DE PRECIO - SIEMPRE "1"
        //				adctra.Tra_numprecio = "1";

        //				// Precios por LÍNEA (esto es por producto)
        //				adctra.Tra_precuni = Convert.ToDecimal(rrow.Cells["PvUni"].Value);
        //				adctra.Tra_prectot = adctra.Tra_precuni * adctra.Tra_cantidad; // Subtotal de la línea
        //				adctra.Tra_valordes = Convert.ToDecimal(rrow.Cells["PorcDes"].Value);

        //				// ¡¡¡CORRECCIÓN IMPORTANTE!!!
        //				// Tra_valor debe ser el VALOR TOTAL DE LA FACTURA, no por línea
        //				// Esto es lo que estás pidiendo
        //				adctra.Tra_valor = valorTotalFactura; // ← 24.85 para TODAS las líneas

        //				// Lote y vencimiento
        //				adctra.Tra_NroLote = rrow.Cells["Lote"].Value?.ToString() ?? "";
        //				try
        //				{
        //					adctra.AuxVar1 = rrow.Cells["Vence"].Value?.ToString() ?? "";
        //				}
        //				catch { }
        //				adctra.tra_codigoalterno = rrow.Cells["CodAlterno"].Value?.ToString() ?? "";

        //				// Porcentaje de descuento (por línea)
        //				try
        //				{
        //					if (adctra.Tra_prectot > 0 && adctra.Tra_valordes > 0)
        //					{
        //						adctra.Tra_porcendes = (adctra.Tra_valordes / adctra.Tra_prectot) * 100;
        //					}
        //					else
        //					{
        //						adctra.Tra_porcendes = 0;
        //					}
        //				}
        //				catch
        //				{
        //					adctra.Tra_porcendes = 0;
        //				}

        //				// IVA (por línea)
        //				adctra.Tra_sniva = Convert.ToBoolean(rrow.Cells["iva"].Value);

        //				// Porcentaje de IVA (por línea)
        //				decimal porcIva = 0;
        //				if (malla.Columns.Contains("Tra_porceniva") && rrow.Cells["Tra_porceniva"]?.Value != null)
        //				{
        //					try
        //					{
        //						porcIva = Convert.ToDecimal(rrow.Cells["Tra_porceniva"].Value);
        //					}
        //					catch
        //					{
        //						porcIva = adctra.Tra_sniva ? datAdoc.Doc_porceniva : 0;
        //					}
        //				}
        //				else
        //				{
        //					porcIva = adctra.Tra_sniva ? datAdoc.Doc_porceniva : 0;
        //				}
        //				adctra.Tra_porceniva = porcIva;

        //				// Valor de IVA (por línea)
        //				decimal valorIva = 0;
        //				if (malla.Columns.Contains("Tra_valoriva") && rrow.Cells["Tra_valoriva"]?.Value != null)
        //				{
        //					try
        //					{
        //						valorIva = Convert.ToDecimal(rrow.Cells["Tra_valoriva"].Value);
        //					}
        //					catch
        //					{
        //						// Calcular basado en el subtotal de la línea
        //						valorIva = adctra.Tra_sniva ? (adctra.Tra_prectot * (porcIva / 100)) : 0;
        //					}
        //				}
        //				else
        //				{
        //					// Calcular basado en el subtotal de la línea
        //					valorIva = adctra.Tra_sniva ? (adctra.Tra_prectot * (porcIva / 100)) : 0;
        //				}
        //				adctra.Tra_valoriva = valorIva;

        //				// Costos (por línea)
        //				if (adctra.Tra_quetipo == "A") // Artículo
        //				{
        //					decimal costoUnitario = 0;
        //					if (malla.Columns.Contains("Tra_costuni") && rrow.Cells["Tra_costuni"]?.Value != null)
        //					{
        //						try
        //						{
        //							costoUnitario = Convert.ToDecimal(rrow.Cells["Tra_costuni"].Value);
        //						}
        //						catch
        //						{
        //							costoUnitario = adctra.Tra_precuni;
        //						}
        //					}
        //					else
        //					{
        //						costoUnitario = adctra.Tra_precuni;
        //					}

        //					adctra.Tra_costuni = costoUnitario;
        //					adctra.Tra_costtot = costoUnitario * adctra.Tra_cantidad;
        //				}
        //				else // Servicio
        //				{
        //					adctra.Tra_costuni = 0;
        //					adctra.Tra_costtot = 0;
        //				}

        //				// Campos adicionales
        //				adctra.Tra_Individual = "N";
        //				adctra.Tra_multiplo = 1;

        //				// Campos de fecha para contabilidad
        //				adctra.tra_anio = datAdoc.Doc_fecha.Year;
        //				adctra.tra_mes = datAdoc.Doc_fecha.Month;
        //				adctra.tra_dia = datAdoc.Doc_fecha.Day;

        //				// DEBUG: Mostrar lo que se va a guardar
        //				Console.WriteLine($"Línea {i + 1}:");
        //				Console.WriteLine($"  Tra_valor (total factura): {adctra.Tra_valor}");
        //				Console.WriteLine($"  Tra_prectot (subtotal línea): {adctra.Tra_prectot}");
        //				Console.WriteLine($"  Tra_valoriva (IVA línea): {adctra.Tra_valoriva}");

        //				// Transferir a DataRow
        //				adctra.moverAdctraDatarow(adctra, ref dr);

        //				if (i > table.Rows.Count - 1)
        //					table.Rows.Add(dr);

        //				i++;
        //			}
        //		}

        //		// Eliminar filas sobrantes si hay menos filas en la malla
        //		if (i < table.Rows.Count)
        //		{
        //			for (int j = table.Rows.Count - 1; j >= i; j--)
        //			{
        //				table.Rows[j].Delete();
        //			}
        //		}

        //		// Actualizar la base de datos
        //		int registrosActualizados = adapter.Update(table);
        //		Console.WriteLine($"Registros guardados en AdcTra: {registrosActualizados}");

        //		// Calcular y actualizar totales por tipo en adcdoc
        //		CalcularYActualizarTotalesPorTipo(malla, datAdoc, cadenaConexion);
        //	}
        //}


        static private void CalcularYActualizarTotalesPorTipo(DataGridView malla, AdcDoc datAdoc, string cadenaConexion)
        {
        try
        {
        Console.WriteLine("=== CALCULANDO TOTALES POR TIPO ===");
        Console.WriteLine($"VALOR TOTAL FACTURA (Doc_valor): {datAdoc.Doc_valor}");
        Console.WriteLine($"BASE CON IVA (Doc_totciva): {datAdoc.Doc_totciva}");
        Console.WriteLine($"BASE SIN IVA (Doc_totsiva): {datAdoc.Doc_totsiva}");
        Console.WriteLine($"IVA TOTAL (Doc_valoriva): {datAdoc.Doc_valoriva}");
        
        // VERIFICAR CONSISTENCIA: Doc_valor = Doc_totciva + Doc_totsiva + Doc_valoriva
        decimal totalVerificado = datAdoc.Doc_totciva + datAdoc.Doc_totsiva + datAdoc.Doc_valoriva;
        Console.WriteLine($"Verificación: {datAdoc.Doc_totciva} + {datAdoc.Doc_totsiva} + {datAdoc.Doc_valoriva} = {totalVerificado}");
        
        if (Math.Abs(datAdoc.Doc_valor - totalVerificado) > 0.01m)
        {
            Console.WriteLine($"¡ADVERTENCIA! Inconsistencia: {datAdoc.Doc_valor} ≠ {totalVerificado}");
        }
        
        // SIMPLEMENTE asignar los totales que YA están en datAdoc
        // (calculados durante la importación del XML)
        
        // Como no sabemos qué parte es artículos y qué parte servicios,
        // ASIGNAR TODO como ARTÍCULOS (asumiendo que son compras de productos)
        decimal totArtCIva = datAdoc.Doc_totciva;    // Base con IVA (19.00)
        decimal totArtSIva = datAdoc.Doc_totsiva;    // Base sin IVA (4.00)
        decimal totSerCIva = 0;                      // Servicios con IVA (0.00)
        decimal totSerSIva = 0;                      // Servicios sin IVA (0.00)
        
        // Si quieres una distribución más precisa, analiza cada línea:
        decimal totArtCIvaCalculado = 0;
        decimal totArtSIvaCalculado = 0;
        decimal totSerCIvaCalculado = 0;
        decimal totSerSIvaCalculado = 0;
        
        foreach (DataGridViewRow row in malla.Rows)
        {
            if (row.IsNewRow || row.Cells["codProductoPropio"].Value == null) 
                continue;
            
            try
            {
                // Obtener si es artículo o servicio
                bool esArticulo = true;
                if (row.Cells["ConceptoProducto"].Value != null)
                {
                    string tipo = row.Cells["ConceptoProducto"].Value.ToString().ToUpper();
                    if (tipo == "CONCEPTO" || tipo == "S" || tipo == "SERVICIO")
                        esArticulo = false;
                }
                
                // Obtener si tiene IVA
                bool tieneIva = false;
                if (row.Cells["iva"].Value != null)
                {
                    object ivaVal = row.Cells["iva"].Value;
                    if (ivaVal is bool)
                        tieneIva = (bool)ivaVal;
                    else if (ivaVal.ToString() == "1" || ivaVal.ToString().ToUpper() == "TRUE" || ivaVal.ToString().ToUpper() == "S")
                        tieneIva = true;
                    else
                        bool.TryParse(ivaVal.ToString(), out tieneIva);
                }
                
                // Obtener base imponible de la línea
                decimal baseLinea = 0;
                
                // PRIMERO: Intentar de Tra_prectot (base sin IVA)
                if (malla.Columns.Contains("Tra_prectot") && row.Cells["Tra_prectot"].Value != null)
                {
                    baseLinea = Convert.ToDecimal(row.Cells["Tra_prectot"].Value);
                }
                // SEGUNDO: Calcular de Cantidad * PvUni
                else if (row.Cells["Cantidad"].Value != null && row.Cells["PvUni"].Value != null)
                {
                    baseLinea = Convert.ToDecimal(row.Cells["Cantidad"].Value) * 
                                Convert.ToDecimal(row.Cells["PvUni"].Value);
                }
                
                if (esArticulo)
                {
                    if (tieneIva)
                        totArtCIvaCalculado += baseLinea;
                    else
                        totArtSIvaCalculado += baseLinea;
                }
                else
                {
                    if (tieneIva)
                        totSerCIvaCalculado += baseLinea;
                    else
                        totSerSIvaCalculado += baseLinea;
                }
            }
            catch { }
        }
        
        // Si encontramos servicios, usar los cálculos detallados
        if (totSerCIvaCalculado > 0 || totSerSIvaCalculado > 0)
        {
            Console.WriteLine("\n=== DISTRIBUCIÓN DETALLADA ENCONTRADA ===");
            Console.WriteLine($"Artículos con IVA: {totArtCIvaCalculado}");
            Console.WriteLine($"Artículos sin IVA: {totArtSIvaCalculado}");
            Console.WriteLine($"Servicios con IVA: {totSerCIvaCalculado}");
            Console.WriteLine($"Servicios sin IVA: {totSerSIvaCalculado}");
            
            // Normalizar para que sumen los totales correctos
            decimal totalCalculado = totArtCIvaCalculado + totArtSIvaCalculado + 
                                    totSerCIvaCalculado + totSerSIvaCalculado;
            
            if (totalCalculado > 0 && Math.Abs(totalCalculado - (datAdoc.Doc_totciva + datAdoc.Doc_totsiva)) > 0.01m)
            {
                Console.WriteLine($"Ajustando proporciones...");
                decimal factor = (datAdoc.Doc_totciva + datAdoc.Doc_totsiva) / totalCalculado;
                
                totArtCIva = totArtCIvaCalculado * factor;
                totArtSIva = totArtSIvaCalculado * factor;
                totSerCIva = totSerCIvaCalculado * factor;
                totSerSIva = totSerSIvaCalculado * factor;
            }
            else
            {
                totArtCIva = totArtCIvaCalculado;
                totArtSIva = totArtSIvaCalculado;
                totSerCIva = totSerCIvaCalculado;
                totSerSIva = totSerSIvaCalculado;
            }
        }
        
        Console.WriteLine("\n=== TOTALES FINALES A GUARDAR ===");
        Console.WriteLine($"Artículos con IVA: {totArtCIva}");
        Console.WriteLine($"Artículos sin IVA: {totArtSIva}");
        Console.WriteLine($"Servicios con IVA: {totSerCIva}");
        Console.WriteLine($"Servicios sin IVA: {totSerSIva}");
        
        // ACTUALIZAR LA BASE DE DATOS
        string sqlUpdate = $@"
            UPDATE adcdoc SET 
                Doc_TotArtCIva = {totArtCIva},
                Doc_TotArtSIva = {totArtSIva},
                Doc_TotSerCIva = {totSerCIva},
                Doc_TotSerSIva = {totSerSIva}
            WHERE Doc_sucursal = '{datAdoc.Doc_sucursal}' 
              AND Opc_documento = '{datAdoc.Opc_documento}' 
              AND Doc_numero = {datAdoc.Doc_numero} 
              AND IdClaveDoc = {datAdoc.IdClaveDoc}";
        
        Console.WriteLine($"\nEjecutando SQL: {sqlUpdate}");
        
        using (SqlConnection conn = new SqlConnection(cadenaConexion))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(sqlUpdate, conn))
            {
                int rows = cmd.ExecuteNonQuery();
                Console.WriteLine($"Filas actualizadas: {rows}");
            }
        }
        
        // ACTUALIZAR EN MEMORIA
        datAdoc.Doc_TotArtCIva = totArtCIva;
        datAdoc.Doc_TotArtSIva = totArtSIva;
        datAdoc.Doc_TotSerCIva = totSerCIva;
        datAdoc.Doc_TotSerSIva = totSerSIva;
        
        Console.WriteLine("\n✅ TOTALES GUARDADOS EXITOSAMENTE");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"❌ ERROR: {ex.Message}");
    }
}
        
    }
}
