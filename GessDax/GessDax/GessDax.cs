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
namespace GessDax
{
    public partial class GessDax : Form
    {
        string textTitulo = "GESSDAX Gestionador de reportes para analisis de datos, actual : ";
        int ColumnaActual = 0;
        int botonOp = 0;
        int NroCampos = 0;
        int numFiltro = 0;
        bool[] mergge;
        //Boolean saltar = true;        
        Int32 columnaTotal = 0;
        DataTable datosTabla = new DataTable();
        int proceso = 0; // 0 sin proceso   1 = nuevo  2 = abierto

        int porutilpromedio = 0;
        int porutilultimo = 0;
        int participacion = 0;
        int ultimaLineaVista = -1;
        int GessTipo = 0;
        string opcionAnalisis = "";
        DaxMallaLib.frmBuscMall libBuscar;
        private string GessConsulta = "GessVentas";
        private string[] tipoDato = new string[5];
        public GessDax(string modulo)
        {
            InitializeComponent();
            opcionAnalisis = modulo;
            iniciarVariables();
        }
        public GessDax()
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
                manejarBotones(proceso);
				//if (opcionAnalisis=="01")
				//{
    //                EjecutarConsulta(" exec GessVtaIni '" + this.txtFechaAl.Value.ToShortDateString() + "' ",datosEmpresa.strConxAdcom.ToString());
    //                GessConsulta = "GESSVENTAS";
    //                Text += " DE VENTAS";

    //                string[] commandLineArgs = Environment.GetCommandLineArgs();
    //                try
    //                {
    //                    int index = 0;
    //                    if (commandLineArgs.Length > 1)
    //                        index = 1;
    //                    GessTipo = Convert.ToInt32(commandLineArgs[index]);
    //                }
    //                catch
    //                {
    //                }

    //                new sb_cargDatos().CargarDatosDisponibles(this.GessConsulta, datosEmpresa.strConxAdcom, ref this.camposSeleccionados, ref this.tipoDato);
    //            }
            }
            catch
            {
                MessageBox.Show("No se pudo conectar al servidor virtual del AdcomDX");
                this.Close();
                return;
            }
            libBuscar = new DaxMallaLib.frmBuscMall(lista, false, true);
			
        }

       


        private void btnActualizar_Click(object sender, EventArgs e)
        {
            //            conTotales = false;

            llenarlista();
        }
        private void llenarlista()
        {
            if (camposSeleccionados.Items.Count == 0)
            {
                MessageBox.Show("No existen datos seleccionados");
                return;
            }
            mergge = new bool [camposSeleccionados.Items.Count];
            for (Int16 i = 0; i < camposSeleccionados.Items.Count; i++)
            {
                mergge[i] = sb_datosMalla.columna(camposSeleccionados.Items[i].ToString()).merge;
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

            string strx = "";
            if (sb_reporte.baseDatos == "DX") strx = datosEmpresa.strConxAdcom;
            else if (sb_reporte.baseDatos == "IV") strx = datosEmpresa.strConxIvaret;
            else if (sb_reporte.baseDatos == "PR") strx = datosEmpresa.strConxDaxpro;
            else if (sb_reporte.baseDatos == "SY") strx = datosEmpresa.strConxSyscod;
            if (strx == "") return;

            //saltar = true;
            if (sb_reporte.procedInicial.Length > 3) EjecutarConsulta("exec " + sb_reporte.procedInicial + "'" + txtFechaDel.Value.ToShortDateString() + "','" + txtFechaAl.Value.ToShortDateString() + "' ", strx);
            string SSqlorder = "";
            string SqlConsulta = sb_util.armarSelectConsulta(txtFechaDel.Text, txtFechaAl.Text, sb_reporte.consultaFinal,camposSeleccionados, ref SSqlorder);
            sb_cargDatos dcarga = new sb_cargDatos();
            datosTabla = new DataTable();
            dcarga.leerDatosaGrid(SqlConsulta, strx, SSqlorder, ref lista,ref datosTabla);
            if (GessTipo == 1 | GessTipo == 2) numerarFilarYUtilidad();
            this.Cursor = c;
            //saltar = false;
            manejarBotones(proceso);
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
            //llenarlista();

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
                        PonerSubtotales(i, ref TotValsub3, 3, subAnt3, valSubtot3,datosTabla);
                        subAnt3 = subAct3;
                        i++;
                    }
                }


                if (valSubtot2 != "")  // debo calcular subtotal-2 ?
                {
                    if (subAct2 != subAnt2 | subAnt != subAct)
                    {
                        PonerSubtotales(i, ref TotValsub2, 2, subAnt2, valSubtot2,datosTabla);
                        subAnt2 = subAct2;
                        i++;
                    }
                }


                if (valSubtot1 != "")  // debo calcular subtotal-1 ?
                {
                    if (subAct != subAnt)
                    {
                        PonerSubtotales(i, ref TotValsub1, 1, subAnt, valSubtot1, datosTabla);
                        subAnt = subAct;
                        i++;
                    }
                }


                // SUMATORIA POR COLUMNAS
                for (int j = 0; j < lista.ColumnCount; ++j)
                {
                    sb_columna column = sb_datosMalla.columna(j);
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

            if (valSubtot3 != "") PonerSubtotales(lista.RowCount, ref TotValsub3, 3, subAnt3, valSubtot3,datosTabla);
            if (valSubtot2 != "") PonerSubtotales(lista.RowCount, ref TotValsub2, 2, subAnt2, valSubtot2, datosTabla);
            if (valSubtot1 != "") PonerSubtotales(lista.RowCount, ref TotValsub1, 1, subAnt, valSubtot1, datosTabla);
            PonerSubtotales(lista.RowCount, ref total, 4, "General", "0", datosTabla);
        }
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            DataGridViewPrinterApplication1.frmMain prog = new DataGridViewPrinterApplication1.frmMain();
            prog.imprimir(lista, armartitulo(), "", datosEmpresa.Emp_Nombre );
            prog = null;
        }
        private void btnExcel_Click(object sender, EventArgs e)
        {
            mallExp.Form1 prog = new mallExp.Form1();
            prog.Exportar(lista, "E", datosEmpresa.Emp_Nombre , armartitulo());
            prog.Dispose();
        }

        private void btnWord_Click(object sender, EventArgs e)
        {
            mallExp.Form1 prog = new mallExp.Form1();
            prog.Exportar(lista, "W", datosEmpresa.Emp_Nombre , armartitulo());
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
            resp = "Reporte de gestión de [" + sb_datosMalla.nombre + "] del " + txtFechaDel.Text + " al " + txtFechaAl.Text + "   imp:" + DateTime.Now.ToShortDateString();
            return resp;
        }

        private void Establecerfiltro(string tipo = "=", string valorFiltro = "")
        {
            if (lista.CurrentCell == null) return;
            string nomCol = lista.Columns[lista.CurrentCell.ColumnIndex].Name; 

            if (numFiltro == 10)
            {
                MessageBox.Show("Se ha excedido el número máximo de filtros (10)", "FILTRAR INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (valorFiltro == "") valorFiltro = lista.CurrentCell.Value.ToString();
            ++numFiltro;
            sb_columna column = sb_datosMalla.columna(nomCol);
            column.filtros[0] = column.nombreCol;
            column.filtros[1] = tipo;
            column.filtros[2] = valorFiltro;
            dgFiltros.Items.Add(column.filtros[0] + " " + column.filtros[1] + " '" + column.filtros[2] + "'");
            lista.Columns.Clear();
        }

        private void borrarFiltros_Click(object sender, EventArgs e)
        {
            foreach (sb_columna column in sb_datosMalla.columnas)
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
                sb_columna column = sb_datosMalla.columna(nomCol);
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
            if (e.KeyCode == Keys.F3 )
            {
                btnSiguiente_Click(sender, e);
            }
        }
        private void chequearTotVta()
        {
            //participacion = 0;
            //porutilpromedio = 0;
            //porutilultimo = 0;
            //foreach ( itemChecked in camposSeleccionados.CheckedItems)
            //{
            //    if (itemChecked.ToString() == "UtiCstPro") porutilpromedio = 1;
            //    if (itemChecked.ToString() == "UtiUltCst") porutilultimo = 1;
            //    if (itemChecked.ToString() == "Participación") participacion = 1;
            //    //if (itemChecked.ToString() == "ValorTotal") tieneventa = 1;
            //}

            //for (int i = 0; i < camposSeleccionados.Items.Count; ++i)
            //{
            //    if (camposSeleccionados.Items[i].ToString().ToUpper() == "ValorTotal".ToUpper() & (porutilpromedio > 0 | porutilultimo > 0 | participacion > 0))
            //    {
            //        camposSeleccionados.SetItemChecked(i, true);
            //    }

            //    if (camposSeleccionados.Items[i].ToString().ToUpper() == "UtilCostoProm".ToUpper() & porutilpromedio > 0)
            //    {
            //        camposSeleccionados.SetItemChecked(i, true);
            //    }

            //    if (camposSeleccionados.Items[i].ToString().ToUpper() == "UtilUltimoCost.".ToUpper() & porutilultimo > 0)
            //    {
            //        camposSeleccionados.SetItemChecked(i, true);
            //    }
            //}
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

            if (sb_datosMalla.nombre == "") { MessageBox.Show("Para guardar el reporte debe registrar un nombre"); return; }
            string foperando = "";
            string fvalcompara = "";
            string ssql = "UPDATE [sysdxgess] SET [reporte] = 'xxx' + reporte WHERE reporte = '" + sb_datosMalla.nombre + "'";
            EjecutarConsulta(ssql,datosEmpresa.strConxAdcom);
            for (int j = 0; j < camposSeleccionados.Items.Count;j++ )
                //foreach (sb_columna column in sb_datosMalla.columnas)
                {
                    sb_columna column = sb_datosMalla.columna(camposSeleccionados.Items[j].ToString());
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
                    ssql += ",[formato]";
                    ssql += ",[valorFijo]";
                    ssql += ",[numeroCaracteres]";
                    ssql += ",[mergge]";
                    ssql += ")";
                    ssql += "VALUES(";
                    ssql += "'" + GessTipo + "',";
                    ssql += "'" + sb_datosMalla.nombre + "'";
                    ssql += ",'" + column.nombreCol.ToString() + "'";
                    ssql += ",1";
                    if (column.agrupar == true) { ssql += ",1"; } else { ssql += ",0"; }
                    if (column.sumar == true) { ssql += ",1"; } else { ssql += ",0"; }
                    // orden de visualizacion
                    //try
                    //{
                    //    ssql += "," + lista.Columns[column.nombreCol].DisplayIndex.ToString();
                    //}
                    //catch
                    //{
                        ssql += "," + j.ToString();
                    //}
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

                    try
                    {
                        if (lista.Columns.Count > 0 & lista.Columns[column.nombreCol].Width > 0)
                        {
                            ssql += "," + lista.Columns[column.nombreCol].Width;
                        }
                        else
                        {
                            ssql += ",100";
                        }
                    }
                    catch { ssql += ",100"; }

                    ssql += ",'" + column.clavesOrden + "' ";
                    if (column.subtotal == true) { ssql += ",1"; } else { ssql += ",0"; }
                    ssql += "," + column.secuenciaOrden;
                    ssql += ",'" + column.formato + "' ";
                    ssql += ",'" + column.valorFijo + "' ";
                    ssql += "," + column.numeroCaracteres + " ";
                    if (column.merge == true) { ssql += ",1"; } else { ssql += ",0"; }

                    ssql += ")";
                    EjecutarConsulta(ssql, datosEmpresa.strConxAdcom);
                }
            ssql = "delete [sysdxgess]  WHERE reporte = 'xxx" + sb_datosMalla.nombre + "'";
            EjecutarConsulta(ssql, datosEmpresa.strConxAdcom);
            proceso = 2;
            manejarBotones(proceso);
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            Buscar.frmBuscar prog = new Buscar.frmBuscar();
            string ssql = "select  reporte from sysdxgess group by reporte order by reporte";
            string titulo = prog.Buscar(datosEmpresa.strConxAdcom, ssql, "reporte", "reporte", "", "BUSQUEDA REPORTES GESS");
            //saltar = true;
            CargarConsulta(titulo);
            this.Text = textTitulo + titulo;
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            sb_datosMalla.columnas.Clear();
            sb_reporte.idTipoDato = 0;
            frmDatos frmdat = new frmDatos();
            frmdat.ShowDialog();
            sb_datosMalla.cargarDatosAlista(camposSeleccionados);
            GessTipo = sb_reporte.idTipoDato;
            proceso=1;
            manejarBotones(proceso);
            this.Text = textTitulo + sb_datosMalla.nombre;
        }


        private void CargarConsulta(string nombre)
        {
            GessTipo = sb_datosMalla.cargarDatosReporte(nombre);
            if (GessTipo == 0) return;
            sb_reporte.cargar(GessTipo);
            sb_datosMalla.cargarDatosAlista(camposSeleccionados);
            sb_datosMalla.nombre = nombre;
            foreach (sb_columna column in sb_datosMalla.columnas)
            {

                if (column.agrupar == true) dgAgrupacion.Items.Add(column.nombreCol);

                if (column.sumar == true) dgSumatorias.Items.Add(column.nombreCol);

                if (column.subtotal == true) this.dgSubtotales.Items.Add(column.nombreCol);

                if (column.filtros[1] != "" && column.filtros[2] != "") dgFiltros.Items.Add(column.filtros[0] + " " + column.filtros[1] + " '" + column.filtros[2] + "'");
            }

            cargarOrdenamiento();
            llenarlista();
            proceso = 2;
            manejarBotones(proceso);
        }

        private void cargarOrdenamiento()
        {
            Int32 posicionOrden = 0;
            dgOrdenar.Items.Clear();
            string[] tablaSort = new string[sb_datosMalla.columnas.Count];
            for (int i = 0; i < sb_datosMalla.columnas.Count; i++)
            { tablaSort[i] = ""; }

            int ii = 0;
            foreach (object i in  camposSeleccionados.Items)
            {
                sb_columna column = sb_datosMalla.columna(i.ToString());
                if (column.clavesOrden.Length > 0)
                {
                    if (column.secuenciaOrden > 0) { posicionOrden = column.secuenciaOrden; } else { posicionOrden = ii; }
                    tablaSort[posicionOrden] = column.nombreCol;
                    ii++;
                }
            }

            for (int i = 0; i < sb_datosMalla.columnas.Count; i++)
            {
                if (tablaSort[i].Length > 0)
                {
                    string tipoorden = " en orden Ascendente ";
                    if (sb_datosMalla.columna(tablaSort[i]).clavesOrden != "asc") tipoorden = " en orden Descendente ";
                    dgOrdenar.Items.Add(tablaSort[i].ToString() + tipoorden);
                }
            }
        }
        private void EjecutarConsulta(string consulta,string strConx)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(strConx))
                {
                    conn.Open();
                    SqlCommand misqlDa = new SqlCommand("set dateformat dmy;" + consulta, conn);
                    misqlDa.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Exepción en la consulta " + consulta + " de GESSDAX \n" + e.Message);
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
            string ssql = "delete [sysdxgess] WHERE reporte = '" + sb_datosMalla.nombre + "'";
            EjecutarConsulta(ssql, datosEmpresa.strConxAdcom);
            BorrarAnalisisActual();
        }

        private void BorrarAnalisisActual()
        {
            lista.Columns.Clear();
            lista.DataSource = null;
            dgAgrupacion.Items.Clear();
            dgOrdenar.Items.Clear();
            dgSumatorias.Items.Clear();
            dgSubtotales.Items.Clear();
            sb_datosMalla.columnas.Clear();
            sb_datosMalla.nombre = "";
            sb_reporte.idTipoDato = 0;
            proceso = 0;
            manejarBotones(proceso);
            camposSeleccionados.Items.Clear();
        }

        private void lista_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            sb_datosMalla.columna(e.Column.Name).anchoCol = e.Column.Width;
        }
        private void manejarBotones(int opcion)
        {
            Boolean cerrado = (opcion == 0);
            Boolean abierto = (opcion == 1 || opcion == 2);
            Boolean existe = (opcion == 2);
            Boolean mallaLlena = (lista.RowCount > 0);
            btnAbrir.Enabled = cerrado;
            btnActualizar.Enabled = abierto;
            btnCerrar.Enabled = abierto;
            btnEliminar.Enabled = existe;
            btnEnviar.Enabled = mallaLlena;
            btnSumar.Enabled = mallaLlena;
            btnGuardar.Enabled = abierto;
            btnAgrupar.Enabled = abierto;
            btnAscendente.Enabled = abierto;
            btnDescendente.Enabled = abierto;
            btnFiltrar.Enabled = mallaLlena;
            btnImprimir.Enabled = mallaLlena;
            btnNuevo.Enabled = cerrado;
            btnsubtotales.Enabled = abierto;
            btnSumar.Enabled = mallaLlena;
            btnSumatoria.Enabled = abierto;
            btnOrdenar.Enabled = abierto;
            btnSeleccionDatos.Enabled = abierto;
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

            establecerOrden(queOrden);
        }

        private void campos2_SelectedIndexChanged(object sender, EventArgs e)
        {
            lista.Columns.Clear();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (lista.CurrentCell == null) return;
            frmFiltros ff = new frmFiltros();
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
                string nomCol = lista.Columns[lista.SelectedCells[i].ColumnIndex].Name; 
                sb_columna column = sb_datosMalla.columna(nomCol);
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

        private void agregarOrdenamiento(ref string SSqlo, ref string comao)
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
            foreach (sb_columna column in sb_datosMalla.columnas)
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
        // PARA MERGE

        private void combinar_Click(object sender, EventArgs e)
        {
            establecerMerge();
        }
        private void establecerMerge()
        {
            if (lista.SelectedCells.Count == 0) return;
            for (int i = lista.SelectedCells.Count - 1; i > -1; i--)
            {
                try
                {
                    string nomCol = lista.Columns[lista.SelectedCells[i].ColumnIndex].Name;
                    sb_columna column = sb_datosMalla.columna(nomCol);
                    column.merge = (!column.merge);
                }
                catch { }
            }
            llenarlista();            
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
                string nomCol = lista.Columns[lista.SelectedCells[i].ColumnIndex].Name; 
                sb_columna column = sb_datosMalla.columna(nomCol);

                if (column.tipoDato == "DEC" & column.sumar == false)
                {
                    column.sumar = true;
                    dgSumatorias.Items.Add(column.nombreCol);
                }
            }
            llenarlista();
        }


        // PARA AGRUPAR
        private void agruparValores_Click(object sender, EventArgs e)
        {
            establecerAgrupacion();
        }

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
                    string nomCol = lista.Columns[lista.SelectedCells[i].ColumnIndex].Name; 
                    sb_columna column = sb_datosMalla.columna(nomCol);
                    if (column.agrupar != true)
                    {
                        column.agrupar = true;
                        dgAgrupacion.Items.Add(column.nombreCol);
                    }
                }
            }
            catch { }
        }


        private void borrarAgrupa_Click(object sender, EventArgs e)
        {
            if (dgAgrupacion.Items.Count == 0) return;
            dgAgrupacion.Items.Clear();

            btnsubtotales.Enabled = true;
            calcularSubtotales.Enabled = true;

            foreach (sb_columna column in sb_datosMalla.columnas)
            {
                column.agrupar = false;
            }
        }

        private void borrarOrdena_Click(object sender, EventArgs e)
        {
            dgOrdenar.Items.Clear();
            foreach (sb_columna column in sb_datosMalla.columnas)
            {
                column.clavesOrden = "";
                column.secuenciaOrden = 0;
            }
        }

        private void borrarSumatorias_Click(object sender, EventArgs e)
        {
            dgSumatorias.Items.Clear();
            foreach (sb_columna column in sb_datosMalla.columnas)
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
                string nomCol = lista.Columns[lista.SelectedCells[i].ColumnIndex].Name; 
                sb_columna column = sb_datosMalla.columna(nomCol);
                column.subtotal = true;
                dgSubtotales.Items.Add(lista.Columns[lista.SelectedCells[i].ColumnIndex].Name);
            }
        }

        private void borrarSubtotales_Click(object sender, EventArgs e)
        {
            if (dgSubtotales.Items.Count == 0) return;
            dgSubtotales.Items.Clear();
            btnAgrupar.Enabled = true;
            agruparValores.Enabled = true;
            foreach (sb_columna column in sb_datosMalla.columnas)
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
        private void PonerSubtotales(Int32 i, ref double[] total, int puntos, string titulo, string celda,DataTable DatosLista)
        {
            System.Data.DataRow newRow = DatosLista.NewRow();
            DatosLista.Rows.InsertAt(newRow, i);
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

        //private void lista_ColumnDisplayIndexChanged(object sender, DataGridViewColumnEventArgs e)
        //{
        //    if (saltar == false)
        //    {
        //        foreach (sb_columna column in sb_datosMalla.columnas)
        //        {
        //            column.ordenVertical = lista.Columns[column.nombreCol].DisplayIndex;
        //        };

        //    }
        //}
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

        private void camposSeleccionados_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true)
            {
                if (e.KeyCode == Keys.Up) subirLinea();
                else if (e.KeyCode == Keys.Down) bajarLinea(); 
            }
            try
            {
                if (e.KeyData == Keys.Delete) 
                {
                    sb_datosMalla.columnas.Remove(sb_datosMalla.columna(camposSeleccionados.Items[camposSeleccionados.SelectedIndex].ToString()));
                    camposSeleccionados.Items.RemoveAt(camposSeleccionados.SelectedIndex);                     
                }

            }
            catch { }
        }
        private void subirLinea()
        {
            Int32 indx = camposSeleccionados.SelectedIndex;
            if (indx == 0) return;
            string lineaBak = camposSeleccionados.SelectedItem.ToString();
            camposSeleccionados.Items[indx] = camposSeleccionados.Items[indx-1];
            camposSeleccionados.Items[indx - 1] = lineaBak;
        }
        private void bajarLinea()
        {
            Int32 indx = camposSeleccionados.SelectedIndex;
            if (indx == camposSeleccionados.Items.Count || camposSeleccionados.Items.Count < 2) return;
            string lineaBak = camposSeleccionados.SelectedItem.ToString();
            camposSeleccionados.Items[indx] = camposSeleccionados.Items[indx + 1];
            camposSeleccionados.Items[indx + 1] = lineaBak;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmDatos frd = new frmDatos();
            frd.ShowDialog();
            frd.Dispose();
            sb_datosMalla.cargarDatosAlista(camposSeleccionados);
        }
    //}
    //public class GroupByGrid : DataGridView
    //{
        private void OnCellFormatting(DataGridViewCellFormattingEventArgs args)
        {
            // Call home to base
      //      base.OnCellFormatting(args);

            // First row always displays
            if (args.RowIndex == 0) return;
            try
            {
                if (IsRepeatedCellValue(args.RowIndex, args.ColumnIndex) && sb_datosMalla.columna(lista.Columns[args.ColumnIndex].Name).merge == true)
                {
                    args.Value = string.Empty;
                    args.FormattingApplied = true;
                }
            }
            catch { }
        }
        private void OnCellPainting(DataGridViewCellPaintingEventArgs args)
        {
            try //base.OnCellPainting(args);
            {
                args.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
                // Ignore column and row headers and first row
                if (args.RowIndex < 1 || args.ColumnIndex < 0) return;
                if (IsRepeatedCellValue(args.RowIndex, args.ColumnIndex) && sb_datosMalla.columna(lista.Columns[args.ColumnIndex].Name).merge == true)
                {
                    args.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;
                }
                else
                {
                    args.AdvancedBorderStyle.Top = lista.AdvancedCellBorderStyle.Top;
                }
            }
            catch { }
        }
        private bool IsRepeatedCellValue(int rowIndex, int colIndex)
        {
            DataGridViewCell currCell = lista.Rows[rowIndex].Cells[colIndex];
            DataGridViewCell prevCell = lista.Rows[rowIndex - 1].Cells[colIndex];
            if ((currCell.Value == prevCell.Value) || (currCell.Value != null && prevCell.Value != null && currCell.Value.ToString() == prevCell.Value.ToString()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void lista_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            OnCellFormatting(e);
        }
        private void lista_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            OnCellPainting(e);
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            //            libBuscar = new DaxMallaLib.Form1(malla, true, true);
            try
            {
                libBuscar.buscaProxima();
            }
            catch
            { btnBuscar_Click_1(sender, e); }
            //this.malla.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.malla_DataError);

        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
//            this.malla.DataError -= new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.malla_DataError);
            libBuscar = new DaxMallaLib.frmBuscMall(lista, true, false);
            libBuscar.ShowDialog();
  //          this.malla.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.malla_DataError);

        }
    }

}