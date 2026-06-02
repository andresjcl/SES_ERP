using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using DattCom;
namespace DaxGesvta
{
    public partial class DaxGesvta : Form
    {
        int ColumnaActual = 0;
        int botonOp = 0;
        int NroCampos = 0;
        int numFiltro = 0;
        string[] tipoDato = new string[5];
        Boolean saltar = true;
        private sb_datosMalla datosMalla = new sb_datosMalla();
        private DataTable DatosLista;
        private SqlDataAdapter misqlDa;
        Int32 columnaTotal = 0;
        //AdcDax.DaxSofSys DAXSYS = new AdcDax.DaxSofSys();
       string emp;

        String StrConxadcom = "";
        String StrConxDaxsys = "";

        //DaxLib.DaxLibBases dxlib = new DaxLib.DaxLibBases();
        SqlConnection coneccionAdcom = new SqlConnection();
        SqlConnection coneccionDaxsys = new SqlConnection();

        //        Boolean conTotales = false;
        int porutilpromedio = 0;
        int porutilultimo = 0;
        int participacion = 0;
        int ultimaLineaVista = -1;
        string SSqlSelect = "";
        string GessConsulta = "GessVentas";
        string GessTipo = "01";

        public DaxGesvta()
        {
            InitializeComponent();
            iniciarVariables();
        }

        private void btnOpciones_Click(object sender, EventArgs e)
        {
            if (botonOp == 0)
            {
                btnOpciones.Checked = false;
                botonOp = 1;
            }
            else
            {
                btnOpciones.Checked = true;
                botonOp = 0;
            }
            SplitContainer1.Panel1Collapsed = true;
            if (botonOp == 0) SplitContainer1.Panel1Collapsed = false;
        }
        //private void CargarDatosDisponibles()
        //{

        //    string consulta = "select top 1 * from " + GessConsulta ;
        //    consultarDato(consulta);
        //    NroCampos = Data.Columns.Count;
        //    camposSeleccionados.Items.Clear();
        //    if ( NroCampos > 0)
        //    {
        //        tipoDato = new string[NroCampos];
        //        //Array.Resize(ref tipoDato, NroCampos);
        //        Array.Resize(ref anchoCol, NroCampos);
        //        Array.Resize(ref clavesOrden, NroCampos);
        //        Array.Resize(ref secuenciaOrden, NroCampos);                
        //        Array.Resize(ref sumar, NroCampos);
        //        Array.Resize(ref ordenVertical, NroCampos);
        //        Array.Resize(ref agrupar, NroCampos);
        //        Array.Resize(ref subtotal, NroCampos);

        //        for (int i = 0; i < NroCampos; ++i)
        //        {
        //            camposSeleccionados.Items.Add(Data.Columns[i].ColumnName);
        //            //if (Data.Tables[0].Columns[i].ColumnName.Substring(1,)
        //            datosMalla.tipoDato[i] = Data.Columns[i].DataType.Name.Substring(0, 3).ToUpper();
        //            datosMalla.anchoCol[i] = 100;
        //            datosMalla.clavesOrden[i] = "";
        //            datosMalla.secuenciaOrden[i] = 0;
        //            datosMalla.sumar[i] = false ;
        //            datosMalla.ordenVertical[i] = i;
        //            datosMalla.agrupar[i] = false;
        //        }
        //    }
        //}

        private void campos_CheckedChanged(Object sender, System.EventArgs e)
        {
            lista.Columns.Clear();
        }


        private void DaxGesvta_Load(object sender, EventArgs e)
        {
        }
        private void iniciarVariables()
        {
            try
            {
                //DaxLib.DaxLibBases prog = new DaxLib.DaxLibBases();
                emp = datosEmpresa.nomEmpresa; //  DAXSYS.EmpresaAct;
                //prog.TipoBase = "10";
                StrConxadcom = datosEmpresa.strConxAdcom;  //  prog.StrAdcom();
                StrConxDaxsys = datosEmpresa.strConIniSis;    //prog.StrDaxsys();
                coneccionAdcom = new SqlConnection(StrConxadcom);
                coneccionDaxsys = new SqlConnection(StrConxDaxsys);
                coneccionAdcom.Open();
                manejarBotones("0");
                actualizacion();
            }
            catch
            {
                MessageBox.Show("No se pudo conectar al servidor virtual del AdcomDX");
                this.Close();
                return;
            }
            string[] argumentos = Environment.GetCommandLineArgs();
            try
            {
                int i = 0;
                if (argumentos.Length > 1) i = 1;
                GessTipo = argumentos[i];
            }
            catch { }
            if (GessTipo == "01") { GessConsulta = "GESSVENTAS"; this.Text += " DE VENTAS"; }
            if (GessTipo == "02") { GessConsulta = "GESSCOMPRA"; this.Text += " DE COMPRAS"; }
            if (GessTipo == "03") { GessConsulta = "GESSINVENT"; this.Text += " DE INVENTARIOS"; }
            if (GessTipo == "04") { GessConsulta = "GESSDAXTIME"; this.Text += " DE DAXTIME"; }
            if (GessTipo == "05")
            {
                GessConsulta = "GESSNOMINA"; this.Text += " DE NOMINA";
                EjecutarConsulta(" exec daxConGesRol");
            }
            if (GessTipo == "06") { GessConsulta = "GESSDOCMTO"; this.Text += " DE DOCUMENTOS"; }

            txtFechaAl.Text = DateTime.Today.ToString();
            txtFechaDel.Text = DateTime.Today.ToString();
            txtFechaDel.Text = "01/" + txtFechaDel.Text.Substring(3, 2) + "/" + txtFechaDel.Text.Substring(6, 4);
            sb_cargDatos cd = new sb_cargDatos();
            cd.CargarDatosDisponibles(GessConsulta, StrConxadcom, ref camposSeleccionados, ref tipoDato, ref datosMalla);
            cd = null;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            //            conTotales = false;

            llenarlista();

        }
        private void llenarlista()
        {
            if (camposSeleccionados.CheckedIndices.Count == 0)
            {
                MessageBox.Show("No existen datos seleccionados");
                return;
            }

            Cursor c = this.Cursor;
            this.Cursor = Cursors.WaitCursor;

            DateTime dt;
            try
            {
                dt = Convert.ToDateTime(txtFechaDel.Text);
            }
            catch
            {
                MessageBox.Show("Registre fechas válidas", "Gestión de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            saltar = true;
            if (GessTipo == "05") { EjecutarConsulta("exec daxConGesRol"); }

            sb_util sbu = new sb_util();
            string SSqlorder = "";
            string SqlConsulta = sbu.armarSelectConsulta(txtFechaDel.Text, txtFechaAl.Text, GessConsulta, ref datosMalla, ref SSqlorder);

            sb_cargDatos dcarga = new sb_cargDatos();
            dcarga.leerDatosaGrid(SqlConsulta, StrConxadcom, SSqlorder, ref datosMalla, ref lista, ref DatosLista);

            if (GessTipo == "01" | GessTipo == "02") numerarFilarYUtilidad();
            this.Cursor = c;


            //}
            //else
            //{
            //    agregarFiltros(ref SSqlwhere, ref comawhere);
            //    Classsubtot subt = new Classsubtot() ;
            //    SSqlSelect = subt.armarSelectSubtotales(ref this.campos2 , sumar,ref dgSubtotales ,tipoDato,GessConsulta,SSqlwhere  );
            //    coneccionAdcom.Close();
            //    coneccionAdcom.Open();
            //    leerDatosaGrid(SSqlSelect, "");
            //}

            this.Cursor = c;
            saltar = false;
        }

        private void numerarFilarYUtilidad()
        {
            if (porutilpromedio == 0 & porutilultimo == 0 & participacion == 0) return;
            double valTotal = 0;
            double valor = 0;
            //double auxil = 0;
            for (int i = 0; i < lista.RowCount; ++i)
            {
                valor = 0;
                if (!(lista.Rows[i].Cells["ValorTotal."].Value is DBNull)) valor = Convert.ToDouble(lista.Rows[i].Cells["ValorTotal."].Value);
                valTotal += valor;
                //if (porutilpromedio > 0)
                //{
                //    try
                //    {
                //        auxil = 0;
                //        if (!(lista.Rows[i].Cells["UtilCostoProm"].Value is DBNull)) auxil = Convert.ToDouble(lista.Rows[i].Cells["UtilCostoProm"].Value);
                //        if (valor != 0) lista.Rows[i].Cells["UtiCstPro"].Value = (auxil / valor) * 100;
                //    }
                //    catch {}
                //}
                //if (porutilultimo > 0)
                //{
                //    try
                //    {
                //        auxil = 0;
                //        if (!(lista.Rows[i].Cells["UtilUltimoCost."].Value is DBNull)) auxil = Convert.ToDouble(lista.Rows[i].Cells["UtilUltimoCost."].Value);
                //        if (valor != 0) lista.Rows[i].Cells["UtiUltCst"].Value = (auxil / valor) * 100;
                //    }
                //    catch {}               
                //}
            }
            if (participacion > 0 & valTotal > 0)
            {
                for (int i = 0; i < lista.RowCount; ++i)
                {
                    if (!(lista.Rows[i].Cells["ValorTotal."].Value is DBNull)) lista.Rows[i].Cells["Participación"].Value = 100 * Convert.ToDouble(lista.Rows[i].Cells["ValorTotal."].Value) / valTotal;
                }

            }

        }

        private void btnSumar_Click(object sender, EventArgs e)
        {
            sumatoria();
        }
        //string SSqlorder = "";
        private void sumatoria()
        {
            llenarlista();

            for (int j = 0; j < lista.ColumnCount; ++j)
            {
                if (lista.Columns[j].ValueType.Name == "String") { columnaTotal = j; j = lista.ColumnCount + 5; }
            }

            double[] total = new double[lista.ColumnCount + 1];
            double[] TotValsub1 = new double[lista.ColumnCount + 1];
            double[] TotValsub2 = new double[lista.ColumnCount + 1];
            double[] TotValsub3 = new double[lista.ColumnCount + 1];
            double valor = 0;
            string subAnt = "";
            string subAnt2 = "";
            string subAnt3 = "";
            string subAct = "";
            string subAct2 = "";
            string subAct3 = "";
            string valSubtot1 = "";
            string valSubtot2 = "";
            string valSubtot3 = "";
            if (dgSubtotales.Items.Count > 0) valSubtot1 = dgSubtotales.Items[0].ToString();
            if (dgSubtotales.Items.Count > 1) valSubtot2 = dgSubtotales.Items[1].ToString();
            if (dgSubtotales.Items.Count > 2) valSubtot3 = dgSubtotales.Items[2].ToString();

            //if (conTotales == false) { Data.Tables[0].Rows.Add(); Data.Tables[0].Rows.Add(); }
            //conTotales = true;

            // inicia calculo por cada linea de la lista
            if (valSubtot1 != "") subAnt = lista.Rows[0].Cells[valSubtot1].Value.ToString();
            if (valSubtot2 != "") subAnt2 = lista.Rows[0].Cells[valSubtot2].Value.ToString();
            if (valSubtot3 != "") subAnt3 = lista.Rows[0].Cells[valSubtot3].Value.ToString();

            for (int i = 0; i < lista.RowCount; ++i)
            {
                string DefCelda = Convert.ToString("" + lista.Rows[i].HeaderCell.Value);
            
                if (DefCelda.Length > 1) DefCelda = DefCelda.Substring(1, 1);

                if (valSubtot1 != "") subAct = lista.Rows[i].Cells[valSubtot1].Value.ToString();
                if (valSubtot3 != "") subAct3 = lista.Rows[i].Cells[valSubtot3].Value.ToString();
                if (valSubtot2 != "") subAct2 = lista.Rows[i].Cells[valSubtot2].Value.ToString();
                
                if (valSubtot3 != "")  // debo calcular subtotal-3 ?
                {
                    if (subAct3 != subAnt3 | subAct2 != subAnt2 | subAct != subAnt)
                    {
                        PonerSubtotales(i, ref TotValsub3, 3, subAnt3, valSubtot3);
                        subAnt3 = subAct3;
                        i++;
                    }
                }


                if (valSubtot2 != "")  // debo calcular subtotal-2 ?
                {
                    if (subAct2 != subAnt2 | subAnt != subAct)
                    {
                        PonerSubtotales(i, ref TotValsub2, 2, subAnt2, valSubtot2);
                        subAnt2 = subAct2;
                        i++;
                    }
                }


                if (valSubtot1 != "")  // debo calcular subtotal-1 ?
                {
                    if (subAct != subAnt)
                    {
                        PonerSubtotales(i, ref TotValsub1, 1, subAnt, valSubtot1);
                        subAnt = subAct;
                        i++;
                    }
                }


                // SUMATORIA POR COLUMNAS
                for (int j = 0; j < lista.ColumnCount; ++j)
                {
                    sb_columna column = datosMalla.columna(j);
                    if (column.sumar == true)
                    {
                        valor = 0;
                        if (DefCelda != ".")
                        {
                            try { valor = Convert.ToDouble(lista.Rows[i].Cells[j].Value); }
                            catch { valor = 0; }
                            total[j] += valor;
                            if (valSubtot1 != "") TotValsub1[j] += valor;
                            if (valSubtot2 != "") TotValsub2[j] += valor;
                            if (valSubtot3 != "") TotValsub3[j] += valor;
                        }
                    }
                }
            }

            if (valSubtot3 != "") PonerSubtotales(lista.RowCount, ref TotValsub3, 3, subAnt3, valSubtot3);
            if (valSubtot2 != "") PonerSubtotales(lista.RowCount, ref TotValsub2, 2, subAnt2, valSubtot2);
            if (valSubtot1 != "") PonerSubtotales(lista.RowCount, ref TotValsub1, 1, subAnt, valSubtot1);
            PonerSubtotales(lista.RowCount, ref total, 4, "General", "0");
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscadtgv.BusDtgrd buscar = new Buscadtgv.BusDtgrd();
            string nombreCol = lista.Columns[ColumnaActual].Name;
            buscar.Buscar(txtBuscar.Text, nombreCol, ref lista, 0, ref ultimaLineaVista);
        }

        private void txtBuscar_Click(object sender, EventArgs e)
        {
            ultimaLineaVista = -1;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            DataGridViewPrinterApplication1.frmMain prog = new DataGridViewPrinterApplication1.frmMain();
            prog.imprimir(lista, armartitulo(), "", emp);
            prog = null;
        }
        private void btnExcel_Click(object sender, EventArgs e)
        {
            mallExp.Form1 prog = new mallExp.Form1();
            prog.Exportar(lista, "E", emp, armartitulo());
            prog.Dispose();
        }

        private void btnWord_Click(object sender, EventArgs e)
        {
            mallExp.Form1 prog = new mallExp.Form1();
            prog.Exportar(lista, "W", emp, armartitulo());
            prog.Dispose();
        }

        private void btnPdf_Click(object sender, EventArgs e)
        {
            mallExp.Form1 prog = new mallExp.Form1();
            prog.Exportar(lista, "P", "empresa", armartitulo());
            prog.Dispose();
        }

        private string armartitulo()
        {
            string resp = "";
            resp = "Reporte de gestión de ventas [" + txtNombreReporte + "] del " + txtFechaDel + " al " + txtFechaAl + "             imp:" + DateTime.Now.ToString();
            return resp;
        }

        private void Establecerfiltro(string tipo = "=", string valorFiltro = "")
        {
            if (lista.SelectedCells.Count == 0) return;

            if (numFiltro == 10)
            {
                MessageBox.Show("Se ha excedido el número máximo de filtros (10)", "FILTRAR INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (valorFiltro == "") valorFiltro = lista.CurrentCell.Value.ToString();
            ++numFiltro;
            sb_columna column = datosMalla.columna(ColumnaActual);
            column.filtros[0] = column.nombreCol;
            column.filtros[1] = tipo;
            column.filtros[2] = valorFiltro;
            dgFiltros.Items.Add(column.filtros[0] + " " + column.filtros[1] + " '" + column.filtros[2] + "'");
            lista.Columns.Clear();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            {
                for (int i = 0; i < camposSeleccionados.Items.Count; ++i)
                {
                    camposSeleccionados.SetItemChecked(i, true);
                }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            for (int i = 0; i < camposSeleccionados.Items.Count; ++i)
            {
                camposSeleccionados.SetItemChecked(i, false);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (sb_columna column in datosMalla.columnas)
            {
                column.filtros[0] = "";
                column.filtros[1] = "";
                column.filtros[2] = "";
            }

            dgFiltros.Items.Clear();
            numFiltro = 0;
            lista.Columns.Clear();
        }

        private void dgFiltros_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {

                int fila = dgFiltros.SelectedIndex;
                string nomCol = dgFiltros.Items[fila].ToString();
                sb_columna column = datosMalla.columna(nomCol);
                dgFiltros.Items.RemoveAt(fila);
                column.filtros[0] = "";
                column.filtros[1] = "";
                column.filtros[2] = "";
            }
        }


        private void filtrarPorValorActualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Establecerfiltro("=");
        }

        private void filtrarpordiferente_Click(object sender, EventArgs e)
        {
            Establecerfiltro(" <> ");
        }

        private void filtrarPorMayor_Click(object sender, EventArgs e)
        {
            Establecerfiltro(" > ");
        }

        private void filtrarporMenor_Click(object sender, EventArgs e)
        {
            Establecerfiltro(" < ");
        }

        private void lista_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3 & txtBuscar.Text != "")
            {
                Buscadtgv.BusDtgrd buscar = new Buscadtgv.BusDtgrd();
                string nombreCol = lista.Columns[lista.CurrentCell.ColumnIndex].Name;
                buscar.Buscar(txtBuscar.Text, nombreCol, ref lista, 1, ref ultimaLineaVista);
            }
        }
        private void chequearTotVta()
        {
            participacion = 0;
            porutilpromedio = 0;
            porutilultimo = 0;
            foreach (object itemChecked in camposSeleccionados.CheckedItems)
            {
                if (itemChecked.ToString() == "UtiCstPro") porutilpromedio = 1;
                if (itemChecked.ToString() == "UtiUltCst") porutilultimo = 1;
                if (itemChecked.ToString() == "Participación") participacion = 1;
                //if (itemChecked.ToString() == "ValorTotal") tieneventa = 1;
            }

            for (int i = 0; i < camposSeleccionados.Items.Count; ++i)
            {
                if (camposSeleccionados.Items[i].ToString().ToUpper() == "ValorTotal".ToUpper() & (porutilpromedio > 0 | porutilultimo > 0 | participacion > 0))
                {
                    camposSeleccionados.SetItemChecked(i, true);
                }

                if (camposSeleccionados.Items[i].ToString().ToUpper() == "UtilCostoProm".ToUpper() & porutilpromedio > 0)
                {
                    camposSeleccionados.SetItemChecked(i, true);
                }

                if (camposSeleccionados.Items[i].ToString().ToUpper() == "UtilUltimoCost.".ToUpper() & porutilultimo > 0)
                {
                    camposSeleccionados.SetItemChecked(i, true);
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Boolean ok = true;
            try
            {
                if (lista.Columns.Count < 1 || lista.RowCount < 1) { ok = false; }
            }
            catch
            {
                ok = false;
            }

            if (!ok) { MessageBox.Show("Para guardar el reporte debe ACTUALIZAR el analisis"); return; }

            if (txtNombreReporte.Text == "") { MessageBox.Show("Para guardar el reporte debe registrar un nombre"); return; }
            string foperando = "";
            string fvalcompara = "";
            string ssql = "UPDATE [sysdxgess] SET [reporte] = 'xxx' + reporte WHERE reporte = '" + txtNombreReporte.Text + "'";
            int i = 0;
            EjecutarConsulta(ssql);
            foreach (sb_columna column in datosMalla.columnas)
            {
                //object itemChecked = camposSeleccionados.Items[i];
                ssql = "INSERT INTO [sysdxgess] (";
                ssql += "[TipoGess]";
                ssql += ",[reporte]";
                ssql += ",[nomCampo]";
                ssql += ",[seleccionado]";
                ssql += ",[agrupado]";
                ssql += ",[sumar]";
                ssql += ",[orden]";
                ssql += ",[operador]";
                ssql += ",[valorcompara]";
                ssql += ",[tipo]";
                ssql += ",[ancho]";
                ssql += ",[Ordenar]";
                ssql += ",[Subtotal]";
                ssql += ",[secuenciaOrden]";
                ssql += ")";
                ssql += "VALUES(";
                ssql += "'" + GessTipo + "',";
                ssql += "'" + txtNombreReporte.Text + "'";
                ssql += ",'" + column.nombreCol.ToString() + "'";
                ssql += ",1";
                if (column.agrupar == true) { ssql += ",1"; } else { ssql += ",0"; }
                if (column.sumar == true) { ssql += ",1"; } else { ssql += ",0"; }
                // orden de visualizacion
                try
                {
                    ssql += "," + lista.Columns[column.nombreCol].DisplayIndex.ToString();
                }
                catch
                {
                    ssql += "," + i.ToString();
                }
                foperando = "";
                fvalcompara = "";
                //for (int j = 1; j <= numFiltro; ++j)
                //{
                //    if (datosMalla.filtros[j, 0] != "" & datosMalla.filtros[j, 1] != "" & datosMalla.filtros[j, 2] != "" & datosMalla.filtros[j, 0] == itemChecked.ToString())
                //    {
                foperando = column.filtros[1];
                fvalcompara = column.filtros[2];
                //    }
                //}
                ssql += ",'" + foperando + "' ";
                ssql += ",'" + fvalcompara + "' ";
                ssql += ",'" + column.tipoDato + "' ";

                if (lista.Columns.Count > 0 & lista.Columns[column.nombreCol].Width > 0)
                {
                    ssql += "," + lista.Columns[column.nombreCol].Width;
                }
                else
                {
                    ssql += ",100";
                }

                ssql += ",'" + column.clavesOrden + "' ";
                if (column.subtotal == true) { ssql += ",1"; } else { ssql += ",0"; }
                ssql += "," + column.secuenciaOrden;
                ssql += ")";
                EjecutarConsulta(ssql);
                i++;
            }
            ssql = "delete [sysdxgess]  WHERE reporte = 'xxx" + txtNombreReporte.Text + "'";
            EjecutarConsulta(ssql);
        }

        private void txtNombreReporte_TextChanged(object sender, EventArgs e)
        {
            lista.Columns.Clear();
            if (txtNombreReporte.Text != "") manejarBotones("A");
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            Buscar.frmBuscar prog = new Buscar.frmBuscar();
            string ssql = "select  DISTINCT(reporte) from sysdxgess where TipoGess = '" + GessTipo + "' ";
            string titulo = prog.Buscar(StrConxadcom, ssql, "reporte", "reporte", "", "BUSQUEDA REPORTES GESS");
            saltar = true;
            CargarConsulta(titulo);
        }

        private void CargarConsulta(string nombre)
        {
            string nombreCampo = "";
            numFiltro = 0;
            string ssql = "select nomCampo,seleccionado,isnull(orden,0) as orden,isnull(agrupado,0) as agrupado,isnull(sumar,0) as sumar ";
            ssql += ",isnull(ancho,0) as ancho,operador,valorcompara,Ordenar,isnull(secuenciaOrden,0) as secuenciaOrden ";
            ssql += ",isnull(subtotal,0) as subtotal from [sysdxgess] ";
            ssql += " WHERE reporte = '" + nombre + "' and TipoGess = '" + GessTipo + "' order by orden";
            misqlDa = new SqlDataAdapter(ssql, coneccionAdcom);
            DatosLista = new DataTable();
            misqlDa.Fill(DatosLista);

            if (DatosLista.Columns.Count == 0) { MessageBox.Show("No se pudo cargar el reporte" + nombre); return; }
            txtNombreReporte.Text = nombre;
            camposSeleccionados.ClearSelected();
            datosMalla = new sb_datosMalla();


            for (int r = 0; r < DatosLista.Rows.Count; ++r)
            {
                sb_columna column = new sb_columna();
                nombreCampo = DatosLista.Rows[r]["nomCampo"].ToString();
                column.nombreCol = nombreCampo;
                column.tipoDato = tipoDato[IndexCampo(nombreCampo)];

                if (Convert.ToBoolean(DatosLista.Rows[r]["seleccionado"]) == true) setChekCampo(nombreCampo);

                column.agrupar = Convert.ToBoolean(DatosLista.Rows[r]["agrupado"]);
                if (column.agrupar == true)
                {
                    dgAgrupacion.Items.Add(nombreCampo);
                }

                column.sumar = Convert.ToBoolean(DatosLista.Rows[r]["sumar"]);
                if (column.sumar == true)
                {
                    dgSumatorias.Items.Add(nombreCampo);
                }

                column.anchoCol = Convert.ToInt32(DatosLista.Rows[r]["ancho"]);
                column.ordenVertical = Convert.ToInt32(DatosLista.Rows[r]["orden"]);

                column.subtotal = Convert.ToBoolean(DatosLista.Rows[r]["subtotal"]);
                if (column.subtotal == true)
                {
                    this.dgSubtotales.Items.Add(nombreCampo);
                }

                column.clavesOrden = DatosLista.Rows[r]["Ordenar"].ToString();
                column.secuenciaOrden = Convert.ToInt32(DatosLista.Rows[r]["secuenciaOrden"].ToString());


                if (DatosLista.Rows[r]["operador"].ToString() != "" & DatosLista.Rows[r]["valorcompara"].ToString() != "")
                {
                    ++numFiltro;
                    column.filtros[0] = DatosLista.Rows[r]["nomCampo"].ToString();
                    column.filtros[1] = DatosLista.Rows[r]["operador"].ToString();
                    column.filtros[2] = DatosLista.Rows[r]["valorcompara"].ToString();
                    dgFiltros.Items.Add(column.filtros[0] + " " + column.filtros[1] + " '" + column.filtros[2] + "'");
                }
                datosMalla.columnas.Add(column);
            }
            //llenarlista();
            cargarOrdenamiento();
            llenarlista();
            manejarBotones("A");
        }

        private void setChekCampo(string nombreCampo)
        {
            for (int i = 0; i < camposSeleccionados.Items.Count - 1; i++)
            {
                if (camposSeleccionados.Items[i].ToString().ToUpper() == nombreCampo.ToUpper()) { camposSeleccionados.SetItemChecked(i, true); }
            }
        }
        private void cargarOrdenamiento()
        {
            Int32 posicionOrden = 0;
            dgOrdenar.Items.Clear();
            string[] tablaSort = new string[datosMalla.columnas.Count];
            for (int i = 0; i < datosMalla.columnas.Count; i++)
            { tablaSort[i] = ""; }

            int ii = 0;
            foreach (sb_columna column in datosMalla.columnas)
            {
                if (column.clavesOrden.Length > 0)
                {
                    if (column.secuenciaOrden > 0) { posicionOrden = column.secuenciaOrden; } else { posicionOrden = ii; }
                    tablaSort[posicionOrden] = column.nombreCol;
                    ii++;
                }
            }

            for (int i = 0; i < datosMalla.columnas.Count; i++)
            {
                if (tablaSort[i].Length > 0)
                {
                    string tipoorden = " en orden Ascendente ";
                    if (datosMalla.columna(tablaSort[i]).clavesOrden != "asc") tipoorden = " en orden Descendente ";
                    dgOrdenar.Items.Add(tablaSort[i].ToString() + tipoorden);
                }
            }
        }
        private void EjecutarConsulta(string consulta)
        {
            try
            {
                SqlCommand misqlDa = new SqlCommand("set dateformat dmy;" + consulta, coneccionAdcom);
                if (coneccionAdcom.State == ConnectionState.Closed) coneccionAdcom.Open();
                misqlDa.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show("No se pudo conectar a la base de datos de GESS " + e.Message);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma cerrar el analisis actual ?", "GESS cerrar analisis", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            BorrarAnalisisActual();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma ELIMINAR el analisis actual ?", "GESS ELIMINAR analisis", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            string ssql = "delete [sysdxgess] WHERE reporte = '" + txtNombreReporte.Text + "'";
            if (coneccionAdcom.State == ConnectionState.Closed) coneccionAdcom.Open();
            SqlCommand com = new SqlCommand(ssql, coneccionAdcom);
            com.ExecuteNonQuery();
            BorrarAnalisisActual();
        }

        private void BorrarAnalisisActual()
        {
            lista.Columns.Clear();
            dgFiltros.Items.Clear();
            dgAgrupacion.Items.Clear();
            dgOrdenar.Items.Clear();
            dgSumatorias.Items.Clear();
            dgSubtotales.Items.Clear();
            datosMalla = new sb_datosMalla();
            txtNombreReporte.Text = "";
            manejarBotones("");
        }

        int IndexCampo(string Campo)
        {
            int ix = -1;
            for (int i = 0; i < camposSeleccionados.Items.Count; ++i)
            {
                if (camposSeleccionados.Items[i].ToString().ToUpper() == Campo.ToUpper()) ix=i;
            }
            return ix;
        }

        private void lista_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            datosMalla.columna(e.Column.Name).anchoCol = e.Column.Width;
        }
        private void manejarBotones(string opcion)
        {
            Boolean est = false;
            if (opcion == "A") est = true;
            btnAbrir.Enabled = !est;
            btnActualizar.Enabled = true;
            btnCerrar.Enabled = est;
            btnEliminar.Enabled = est;
            btnEnviar.Enabled = est;
            btnSumar.Enabled = est;
            btnGuardar.Enabled = est;
        }


        private void checkBox1_Click(object sender, EventArgs e)
        {
            //    .Attributes.Add("style","Display:none;");
            //int j = 0;
            //for (int i = 0; i < campos.Count(); ++i)
            //{
            //    if (campos[i].CheckState == CheckState.Unchecked & checkBox1.CheckState == CheckState.Checked)
            //    {
            //        campos2.Items[i].Visible = false;
            //        grupos[i].Visible = false;
            //        datosMalla.sumar[i].Visible = false;
            //    }
            //    else
            //    {
            //        campos[i].Visible = true;
            //        grupos[i].Visible = true;
            //        datosMalla.sumar[i].Visible = true;

            //        campos[i].Top = 2 + (j) * 20;
            //        grupos[i].Top = campos[i].Top;
            //        datosMalla.sumar[i].Top = campos[i].Top;
            //        j = j + 1;
            //    }
            //}
            //Boolean chk = (checkBox1.CheckState == CheckState.Checked);
        }

        private void btnOrdenarAsc_Click(object sender, EventArgs e)
        {
            ReordenarMalla("asc");
        }

        private void btnOrdenarDesc_Click(object sender, EventArgs e)
        {
            ReordenarMalla("desc");
        }

        private void ReordenarMalla(string queOrden)
        {
            if (lista.RowCount == 0) return;
            //            Int32 columna = lista.CurrentCell.ColumnIndex;

            establecerOrden(queOrden);
        }

        private void campos2_SelectedIndexChanged(object sender, EventArgs e)
        {
            lista.Columns.Clear();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (lista.CurrentCell == null) return;
            Form1 ff = new Form1();
            ff.valorCampo = lista.CurrentCell.Value.ToString();
            ff.condicion = "=";
            ff.ShowDialog();
            if (ff.valorCampo == "") return;
            Establecerfiltro(ff.condicion, ff.valorCampo);
            ff.Dispose();
        }

        // PARA ORDENAMIENTO
        private void establecerOrden(string conOrden = "asc")
        {
            if (lista.SelectedCells.Count == 0) return;
            for (int i = lista.SelectedCells.Count - 1; i > -1; i--)
            {
                //int index = IndexCampo(lista.Columns[lista.SelectedCells[i].ColumnIndex].Name);
                sb_columna column = datosMalla.columna(lista.SelectedCells[i].ColumnIndex);
                if (column.clavesOrden.Length == 0)
                {
                    column.clavesOrden = conOrden;
                    string tipoorden = " en orden Ascendente ";
                    if (conOrden != "asc") tipoorden = " en orden Descendente ";
                    dgOrdenar.Items.Add(column.nombreCol + tipoorden);
                    column.secuenciaOrden = dgOrdenar.Items.Count;
                }
            }
            lista.Columns.Clear();

        }
        private void agregarOrdenamiento(ref string SSqlo, ref string comao, ref sb_datosMalla datosMalla)
        {
            string[] tablaSort = new string[NroCampos];
            Int32 posicionOrden = 0;
            for (int i = 0; i < NroCampos; i++)
            {
                tablaSort[i] = "";
            }

            SSqlo = "";
            comao = " order by ";
            int l = 0;
            foreach (sb_columna column in datosMalla.columnas)
            {
                if (column.clavesOrden != "" & column.clavesOrden != null)
                {
                    string nombre = "[" + column.nombreCol + "] ";
                    if (nombre == "[MES] ")
                    {
                        nombre = " case UPPER(MES) ";
                        nombre += " when 'ENERO' THEN 1 ";
                        nombre += " WHEN 'FEBRERO' THEN 2";
                        nombre += " WHEN 'MARZO' THEN 3";
                        nombre += " WHEN 'ABRIL' THEN 4";
                        nombre += " WHEN 'MAYO' THEN 5";
                        nombre += " WHEN 'JUNIO' THEN 6";
                        nombre += " WHEN 'JULIO' THEN 7";
                        nombre += " WHEN 'AGOSTO' THEN 8";
                        nombre += " WHEN 'SEPTIEMBRE' THEN 9";
                        nombre += " WHEN 'OCTUBRE' THEN 10";
                        nombre += " WHEN 'NOVIEMBRE' THEN 11";
                        nombre += " WHEN 'DICIEMBRE' THEN 12";
                        nombre += " END ";
                    }

                    if (nombre == "[NomDia] ")
                    {
                        nombre = " case UPPER(NomDia) ";
                        nombre += " when 'LUNES' THEN 1 ";
                        nombre += " WHEN 'MARTES' THEN 2";
                        nombre += " WHEN 'MIERCOLES' THEN 3";
                        nombre += " WHEN 'MIÉRCOLES' THEN 3";
                        nombre += " WHEN 'JUEVES' THEN 4";
                        nombre += " WHEN 'VIERNES' THEN 5";
                        nombre += " WHEN 'SABADO' THEN 6";
                        nombre += " WHEN 'SÁBADO' THEN 6";
                        nombre += " WHEN 'DOMINGO' THEN 7";
                        nombre += " END ";
                    }
                    if (column.secuenciaOrden > 0) { posicionOrden = column.secuenciaOrden; } else { posicionOrden = l; }
                    tablaSort[posicionOrden] = nombre + column.clavesOrden;
                }
            }
            for (int i = 0; i < NroCampos; i++)
            {
                if (tablaSort[i] != "")
                {
                    SSqlo += comao + tablaSort[i] + " ";
                    comao = ", ";
                }
            }
        }

        private void lista_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            ColumnaActual = e.ColumnIndex;
        }

        //  PARA SUMATORIA

        private void btnSumatoria_Click(object sender, EventArgs e)
        {
            establecerSumatoria();
        }
        private void establecerSumatoria()
        {
            if (lista.SelectedCells.Count == 0) return;
            for (int i = lista.SelectedCells.Count - 1; i > -1; i--)
            {
                //int index = IndexCampo(lista.Columns[lista.SelectedCells[i].ColumnIndex].Name);
                sb_columna column = datosMalla.columna(lista.SelectedCells[i].ColumnIndex);

                if (column.tipoDato == "DEC" & column.sumar == false)
                {
                    column.sumar = true;
                    dgSumatorias.Items.Add(column.nombreCol);
                }
            }
            llenarlista();
        }


        // PARA AGRUPAR
        private void btnAgrupar_Click(object sender, EventArgs e)
        {
            establecerAgrupacion();
        }

        private void establecerAgrupacion()
        {
            if (lista.SelectedCells.Count == 0) return;
            btnsubtotales.Enabled = false;
            calcularSubtotales.Enabled = false;
            try
            {
                for (int i = lista.SelectedCells.Count - 1; i > -1; i--)
                {
                    //int index = IndexCampo(lista.Columns[lista.SelectedCells[i].ColumnIndex].Name);
                    sb_columna column = datosMalla.columna(lista.SelectedCells[i].ColumnIndex);
                    if (column.agrupar != true)
                    {
                        column.agrupar = true;
                        dgAgrupacion.Items.Add(column.nombreCol);
                    }
                }
            }
            catch { }
        }


        private void BuscaTodo_Click(object sender, EventArgs e)
        {
            Buscadtgv.BusDtgrd buscar = new Buscadtgv.BusDtgrd();
            buscar.Buscar(txtBuscar.Text, "", ref lista, 0, ref ultimaLineaVista);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dgAgrupacion.Items.Count == 0) return;
            dgAgrupacion.Items.Clear();

            btnsubtotales.Enabled = true;
            calcularSubtotales.Enabled = true;

            foreach (sb_columna column in datosMalla.columnas)
            {
                column.agrupar = false;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dgOrdenar.Items.Clear();
            foreach (sb_columna column in datosMalla.columnas)
            {
                column.clavesOrden = "";
                column.secuenciaOrden = 0;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            dgSumatorias.Items.Clear();
            foreach (sb_columna column in datosMalla.columnas)
            {
                column.sumar = false;
            }

        }

        private void btnsubtotales_Click(object sender, EventArgs e)
        {
            establecerSubtotales();
        }
        private void establecerSubtotales()
        {
            if (lista.SelectedCells.Count == 0) return;
            if (dgSubtotales.Items.Count == 3) return;
            btnAgrupar.Enabled = false;
            agruparValores.Enabled = false;
            for (int i = lista.SelectedCells.Count - 1; i > -1; i--)
            {
                //int index = IndexCampo(lista.Columns[lista.SelectedCells[i].ColumnIndex].Name);
                sb_columna column = datosMalla.columna(lista.SelectedCells[i].ColumnIndex);
                column.subtotal = true;
                dgSubtotales.Items.Add(lista.Columns[lista.SelectedCells[i].ColumnIndex].Name);
            }
            llenarlista();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (dgSubtotales.Items.Count == 0) return;
            dgSubtotales.Items.Clear();
            btnAgrupar.Enabled = true;
            agruparValores.Enabled = true;
            foreach (sb_columna column in datosMalla.columnas)
            {
                column.subtotal = false;
            }
        }

        private void paraSumatoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            establecerSumatoria();
        }

        private void ordenarFilasPorEstaColumnaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            establecerOrden();
        }

        private void calcularSubtotalesPorEstaColumnaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            establecerSubtotales();
        }

        private void agruparValoresIgualesEnUnaFilaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            establecerAgrupacion();
        }
        private void PonerSubtotales(Int32 i, ref double[] total, int puntos, string titulo, string celda)
        {
            System.Data.DataRow newRow = DatosLista.NewRow();
            DatosLista.Rows.InsertAt(newRow, i);
            //if (i >= lista.Rows.Count) 
            //    { DatosLista.Rows.Add(DatosLista.NewRow()); lista.Refresh(); }
            ponerTotales(i, ref total);
            lista.Rows[i].HeaderCell.Value = ".....".Substring(1, puntos);
            if (puntos == 4)
            {
                try
                {
                    lista.Rows[i].Cells[columnaTotal].Value = "TOTAL: GENERAL";
                }
                catch
                { }

                lista.Rows[i].DefaultCellStyle.BackColor = Color.SteelBlue;
                lista.Rows[i].DefaultCellStyle.ForeColor = Color.White;
            }
            else
            {
                try { lista.Rows[i].Cells[celda].Value = "TOTAL: " + titulo; }
                catch { }
                if (puntos == 1) lista.Rows[i].DefaultCellStyle.BackColor = Color.Orange;
                if (puntos == 2) lista.Rows[i].DefaultCellStyle.BackColor = Color.Goldenrod;
                if (puntos == 3) lista.Rows[i].DefaultCellStyle.BackColor = Color.Khaki;
                lista.Rows[i].DefaultCellStyle.ForeColor = Color.White;
            }
        }
        private void ponerTotales(int Linea, ref double[] total)
        {
            for (int l = 0; l < lista.ColumnCount; ++l)
            {
                if (total[l] != 0) lista.Rows[Linea].Cells[l].Value = total[l];
                total[l] = 0;
            }
        }
        private void actualizacion()
        {
            try
            {
                SqlConnection conectar = new SqlConnection(StrConxadcom);
                conectar.Open();
                string ssql = "IF NOT EXISTS (SELECT col.name FROM sysobjects obj, syscolumns col WHERE obj.id = col.id and obj.name='sysdxgess' and col.name='secuenciaOrden')";
                ssql = ssql + "BEGIN ALTER TABLE sysdxgess Add [secuenciaOrden] [int] null End;";
                ssql = ssql + "IF NOT EXISTS (SELECT col.name FROM sysobjects obj, syscolumns col WHERE obj.id = col.id and obj.name='sysdxgess' and col.name='subtotal')";
                ssql = ssql + "BEGIN ALTER TABLE sysdxgess Add [subtotal] [bit] null End;";
                ssql = ssql + "IF NOT EXISTS (SELECT col.name FROM sysobjects obj, syscolumns col WHERE obj.id = col.id and obj.name='sysdxgess' and col.name='formato')";
                ssql = ssql + "BEGIN ALTER TABLE sysdxgess Add [formato] [varchar](50) null End;";
                ssql = ssql + "IF NOT EXISTS (SELECT col.name FROM sysobjects obj, syscolumns col WHERE obj.id = col.id and obj.name='sysdxgess' and col.name='valorFijo')";
                ssql = ssql + "BEGIN ALTER TABLE sysdxgess Add [valorFijo] [varchar](250) null End;";
                ssql = ssql + "IF NOT EXISTS (SELECT col.name FROM sysobjects obj, syscolumns col WHERE obj.id = col.id and obj.name='sysdxgess' and col.name='numeroCaracteres')";
                ssql = ssql + "BEGIN ALTER TABLE sysdxgess Add [numeroCaracteres] [int] null End;";
                SqlCommand datAd = new SqlCommand(ssql, conectar);
                datAd.ExecuteNonQuery();
            }
            catch { }
        }

        private void lista_ColumnDisplayIndexChanged(object sender, DataGridViewColumnEventArgs e)
        {
            if (saltar == false)
            {
                foreach (sb_columna column in datosMalla.columnas)
                {
                    column.ordenVertical = lista.Columns[column.nombreCol].DisplayIndex;
                };

                //Int32 index = IndexCampo(e.Column.Name);
                //datosMalla.ordenVertical[index] = e.Column.DisplayIndex;
            }
        }

        private void tXTseparadorPuntoYComaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exportarTxt prog = new exportarTxt();
            prog.iniciar(";", lista);
            prog = null;
        }

        private void tXTseparadorComaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exportarTxt prog = new exportarTxt();
            prog.iniciar(",", lista);
            prog = null;
        }

        private void tXTseparadorEspacioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exportarTxt prog = new exportarTxt();
            prog.iniciar(" ", lista);
            prog = null;
        }

        private void tXTsinSeparadorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exportarTxt prog = new exportarTxt();
            prog.iniciar("", lista);
            prog = null;
        }


        private void camposSeleccionados_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            //camposSeleccionados.SetItemChecked(i, false);
            if (camposSeleccionados.SelectedIndex == -1) return;
            Boolean chek = camposSeleccionados.GetItemChecked(camposSeleccionados.SelectedIndex);
            string nombre = camposSeleccionados.SelectedItem.ToString();
            if (chek == false)
            {
                //chek = false;
                foreach (sb_columna column in datosMalla.columnas)
                {
                    if (nombre.ToUpper() == column.nombreCol.ToUpper()) chek = true;
                }
            }
            if (chek == false)
            {
                sb_columna column = new sb_columna();
                column.nombreCol = nombre;
                column.tipoDato = tipoDato[IndexCampo(nombre)];
                datosMalla.add(column);
            }
            else
            {
                try
                {
                    datosMalla.columnas.RemoveAt(camposSeleccionados.SelectedIndex);
                }
                catch
                { 
                }
            }
        }
    }
}