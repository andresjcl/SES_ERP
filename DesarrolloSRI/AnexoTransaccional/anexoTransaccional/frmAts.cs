using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient ;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SysEmpDatt;
namespace anexoTransaccional
{   
    public partial class frmAts : Form
    {
        //Boolean esExterno = false;  // para enlazar a empresas que no tienen el adcomdax
        //bool buscancod = false;
        int operacion = 0;   //  0 ninguna 1 información importada  2 informacion abierta
        int queCopia = 0;    // 0 no copia, 1 celda, 2 linea, 3 columna
        DataGridViewCell celdaCopia;
        string strConxAdcom = "";
        string strConxIvaret = "";
        string regMicroempresa = "N";
        DataTable rs ; //=new DataTable();
        DaxMallaLib.frmBuscMall libBuscar;
        public frmAts()
        {
            InitializeComponent();
            IniciarCampos();
        }
        private void IniciarCampos()
        {
            strConxIvaret = datosEmpresa.strConxIvaret;
            strConxAdcom = datosEmpresa.strConxAdcom;
            Text += " " + datosEmpresa.Emp_Nombre;
            cmbTipo.SelectedIndex = 0;
            ponerBotones();
            CondicionesEmpresa();
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {            
            importarDatos(cmbTipo.SelectedIndex + 1, Convert.ToInt16(datosEmpresa.Emp_codigo ));            
        }
                    
        private void txtAño_TextChanged(object sender, EventArgs e)
        {
            try
            {
                malla.Columns.Clear();
                malla.Rows.Clear();
            }
            catch { }
        }

        private void mnuCopiarCelda_Click(object sender, EventArgs e)
        {
            queCopia = 1;    // 0 no copia, 1 celda, 2 linea, 3 columna
            celdaCopia = malla.CurrentCell;                        
        }

        private void btnCopiarLin_Click(object sender, EventArgs e)
        {
            queCopia = 2;    // 0 no copia, 1 celda, 2 linea, 3 columna
            celdaCopia = malla.CurrentCell;
            malla.Rows [celdaCopia.RowIndex].DefaultCellStyle.BackColor = Color.Linen;
        }

        private void btnInsertarLinea_Click(object sender, EventArgs e)
        {
            DataRow dr = rs.NewRow();
            rs.Rows.Add(dr);
//            malla.Rows.Add(1) ;
        }

        private void btnCopiarColumna_Click(object sender, EventArgs e)
        {
            queCopia = 3;    // 0 no copia, 1 celda, 2 linea, 3 columna
            celdaCopia = malla.CurrentCell;
            malla.Columns[celdaCopia.ColumnIndex].DefaultCellStyle.BackColor = Color.Linen;
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            leerDatosGuardados(cmbTipo.SelectedIndex + 1);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma cerrar la información actual ?", "Cerrar malla sin grabar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No) return;
            limpiarDatos();
        }
        private void limpiarDatos()
        {
            try { malla.Columns.Clear(); }
            catch { }
            operacion = 0;
            labRegistros.Text = "";
            ponerBotones();
        }
        private void leerDatosGuardados(Int32 TipTra)
        {
            WaitMensaje.WMensaje.verMensaje("Leyendo datos guardados ");
            this.Cursor = Cursors.WaitCursor;
            ConfMalla libMalla = new ConfMalla();
            rs = new DataTable();
            string nombreConsulta = "";
            string fechass =  dtFechaInicio.Value.ToShortDateString() + "','" + dtfechaFinal.Value.ToShortDateString() + "' ";

            if (TipTra == 1)
            {
                nombreConsulta = "leeOrdenCompras '" + fechass;
            }
            else if (TipTra == 2)
            {
                nombreConsulta = "leeOrdenVentas '" + fechass;
            }
            else if (TipTra == 3)
            {
                nombreConsulta = "leeOrdenExportacion '" + fechass;
            }
            else if (TipTra == 4)
            {
                nombreConsulta = "leeOrdenAnulados '" + fechass;
            }

            if (nombreConsulta == "")
            {
                this.Cursor = Cursors.Default;
                WaitMensaje.WMensaje.cierraMensaje();
                return;
            }

            DataTable dt = new DataTable();

            using (SqlDataAdapter da = new SqlDataAdapter(nombreConsulta, strConxIvaret))
            {
                try
                {
                    da.Fill(dt);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo accesar a la base de datos del Ivaret \n" + ex.Message);
                    this.Cursor = Cursors.Default;
                    WaitMensaje.WMensaje.cierraMensaje();
                    return;
                }
            }
            //if (dt.Rows.Count > 0)
            //{
                malla.DataSource = dt;
                libMalla.ConfigurarMalla(malla, TipTra);
                ocultarDefault();
                operacion = 1;
            //}
            //else { operacion = 0; }
            labRegistros.Text = "Numero total de registros : " + dt.Rows.Count.ToString();
            ponerBotones();
            libMalla = null;
            this.Cursor = Cursors.Default;
            WaitMensaje.WMensaje.cierraMensaje();

        }
        private void importarDatos(Int32 TipTra, Int16 empCodigo)
        {
            WaitMensaje.WMensaje.verMensaje ("Importando Datos ");
            ConfMalla libMalla = new ConfMalla();
            rs = new DataTable();
            string nombreConsulta = "";
            string fechass = "";
            fechass = " '" + dtFechaInicio.Value.ToShortDateString()  + "','" + dtfechaFinal.Value.ToShortDateString() + "' ";

            if (TipTra == 1)
            {
                nombreConsulta = "AtsComprasDax " + fechass;
            }
            else if (TipTra == 2)
            {
                nombreConsulta = "AtsVentasDax " + fechass ;
                verificarIdTributario(empCodigo);
            }
            else if (TipTra == 3)
            {
                nombreConsulta = "AtsExportaDax " + fechass;
            }
            else if (TipTra == 4)
            {
                nombreConsulta = "ATSAnulaDax " + fechass;
            }

            if (nombreConsulta == "") return;


            using (SqlDataAdapter da = new SqlDataAdapter(nombreConsulta, strConxAdcom))
            {
                DataTable dt = new DataTable();
                try
                {
                    da.Fill(dt);
                }
                catch (Exception ex)
                {
                    WaitMensaje.WMensaje.cierraMensaje();
                    this.Cursor = Cursors.Default;
                    MessageBox.Show("No se pudo accesar a la base de datos de Documentos \n" + ex.Message);
                    this.Cursor = Cursors.Default;
                    return;
                }
                //if (dt.Rows.Count > 0)
                //{
                malla.DataSource = dt;
                labRegistros.Text = "Numero total de registros : " + dt.Rows.Count.ToString();
            }
            libMalla.ConfigurarMalla(malla, TipTra);
                operacion = 1;
               // ocultarDefault();
                if (TipTra == 2) copiarResumenVentas(dtFechaInicio.Value,dtfechaFinal.Value);
            //}
            //else { operacion = 0; }
            ponerBotones();
            libMalla = null;
            WaitMensaje.WMensaje.cierraMensaje();
            this.Cursor = Cursors.Default;
        }
        private void verificarIdTributario(Int16 codigoEmpresa)
        {
            try
            {
                string Ssql = "UPDATE adcdoc SET doc_nroiddoc = R1.SUC_IDTRIBUTARIO  FROM";
                Ssql += "(SELECT SUC_CODIGO,SUC_IDTRIBUTARIO FROM DAXSYS.DBO.EMP_SUC WHERE EMP_CODIGO = " + codigoEmpresa.ToString();
                Ssql += ") R1 ";
                Ssql += "where isnull(doc_nroiddoc,'') = '' and DOC_ventAS <> 0 AND ADCDOC.DOC_SUCURSAL = SUC_CODIGO ";
                using (SqlConnection conn = new SqlConnection(strConxAdcom))
                using (SqlCommand comm = new SqlCommand(Ssql, conn))
                {
                    conn.Open();
                    comm.ExecuteNonQuery();
                    comm.Dispose();
                    conn.Dispose();
                }
            }
            catch { };
        }
        private void copiarResumenVentas(DateTime FechaIni,DateTime FechaFin)
        {

            using (SqlConnection conn = new SqlConnection(strConxIvaret))
            {
                conn.Open();
                string ssql = "Delete resventas where fechaini >= '" + FechaIni.ToShortDateString() + "' and fechafin <= '" + FechaFin.ToShortDateString() + "'";
                //string ssql = "Drop table resventas;";
                using (SqlCommand comm = new SqlCommand(ssql, conn))
                {
                    comm.ExecuteNonQuery();
                }
                ssql = "select * into resventas from " + datosEmpresa.nombreBaseAdcom + ".dbo.resventas where fechaini >= '" + FechaIni.ToShortDateString() + "' and fechafin <= '" + FechaFin.ToShortDateString() + "'";
                using (SqlCommand comm = new SqlCommand(ssql, conn))
                {
                    comm.ExecuteNonQuery();
                }
            }
        }
        private void CondicionesEmpresa()
        {
            string ssql = "select isnull(regimenMicroempresas,0) as regimenMicroempresas from identificacion where codigo = '" + datosEmpresa.Emp_RUC + "' or CedulaIdentidadRuc = '" + datosEmpresa.Emp_RUC + "'";
            SqlDataReader dr = SqlDatos.leerBaseAdcom(ssql);
            if (dr.Read())
            {
                try
                {
                    if ( Convert.ToBoolean (dr["regimenMicroempresas"]) == true) regMicroempresa = "S";
                    else regMicroempresa = "N";
                }catch { }

            }

            if (regMicroempresa == "S") dtfechaFinal.Visible = true; else dtfechaFinal.Visible = false;
            label1.Visible = dtfechaFinal.Visible;
        }
        private void ponerBotones()
        {
            Boolean cerrado = (operacion==0);
            Boolean abierto = (operacion > 0);
            Boolean importado = (operacion == 1);
            Boolean tipoSeleccion = (cmbTipo.SelectedIndex == 0);

            btnAbrir.Enabled = cerrado;
            btnImportar.Enabled = cerrado;
            btnCerrar.Enabled = abierto;
            btnEnviar.Enabled = abierto;
            btnGraba.Enabled = abierto;
            dtFechaInicio.Enabled = cerrado;
            cmbTipo.Enabled = cerrado;
            dtfechaFinal.Enabled = cerrado;

            btnBuscar.Enabled = abierto;
            btnCopiarColumna.Enabled = abierto;
            btnSiguiente.Enabled = abierto;
            btnInsertarLinea.Enabled = abierto;
            btnPegar.Enabled = abierto;
            btnSumatoria.Enabled = abierto;
            btnCopiarLin.Enabled = abierto;
            btnCopiarColumna.Enabled = abierto;
            btnOcultar.Enabled = abierto;
            btnDocModifica.Enabled = abierto;

            //btnReembolso.Enabled = (tipoSeleccion && abierto );
            btnDocModifica.Enabled = (tipoSeleccion && abierto);
            mnuDocModificados.Enabled = (tipoSeleccion && abierto);
            mnuReembolsos.Enabled = (tipoSeleccion && abierto);
            mnuDirectorio.Enabled = ((cmbTipo.SelectedIndex < 2) && abierto);
            mnuDetalleDocumentos.Enabled = ((cmbTipo.SelectedIndex == 1) && abierto);

            //btnConectar.Visible = (emp.Come == false);
            //btnGenerarXml.Enabled = (operacion > 0);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (malla.Rows.Count > 0)
            {
                if (MessageBox.Show("Confirma salir del proceso actual ?", "Cerrar aplicativo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No) return;
            }
            this.Close();
        }

        private void btnGraba_Click(object sender, EventArgs e)
        {
            WaitMensaje.WMensaje.verMensaje("Guardando datos ");
            ClassAts.grabaDatos  actualizar = new ClassAts.grabaDatos ();
            this.Cursor = Cursors.WaitCursor;
            actualizar.grabarAts(cmbTipo.SelectedIndex, malla, strConxIvaret, dtFechaInicio.Value,dtfechaFinal.Value);
            this.Cursor = Cursors.Default;
            operacion = 2;
            ponerBotones();
            WaitMensaje.WMensaje.cierraMensaje();
        }

        private void btnPegar_Click(object sender, EventArgs e)
        {
            ConfMalla libmalla = new ConfMalla();
            ConfMalla.estado = 0;
            libmalla.pegar(malla, celdaCopia,queCopia);
            libmalla = null;
        }

        private void malla_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Este tipo de operación no se puede realizar (verifique el tipo de datos)");
            ConfMalla.estado = 1;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.malla.DataError -= new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.malla_DataError);
            libBuscar = new DaxMallaLib.frmBuscMall(malla,true,false);
            libBuscar.ShowDialog();
            this.malla.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.malla_DataError);
        }
        private void btnSiguiente_Click(object sender, EventArgs e)
        {
                    
            this.malla.DataError -= new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.malla_DataError);
            //            libBuscar = new DaxMallaLib.Form1(malla, true, true);
            try
            {
                libBuscar.buscaProxima();
            }
            catch
            { btnBuscar_Click(sender, e); }
            this.malla.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.malla_DataError);
        }

        private void ImprimirToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
        {
            DataGridViewPrinterApplication1.frmMain imp = new DataGridViewPrinterApplication1.frmMain();
            string tit2 = "";
            imp.imprimir(malla, "Anexo Transaccional", tit2, datosEmpresa.Emp_Nombre);
        }

        //private void WordToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
        //{
        //    ExportarGrid.Form1 exp = new ExportarGrid.Form1();
        //    exp.Exportar(malla, "W", datosEmpresa.Emp_Nombre, "Anexo Transaccional");
        //}

        private void ExcelToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
        {
            ExportarGrid.Form1 exp = new ExportarGrid.Form1();
            exp.Exportar(malla, "E", datosEmpresa.Emp_Nombre, "Anexo Transaccional");
        }

        private void PDFToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
        {
            ExportarGrid.Form1 exp = new ExportarGrid.Form1();
            exp.Exportar(malla, "P", datosEmpresa.Emp_Nombre, "Anexo Transaccional");
        }

        private void mnuSumatoria_Click(object sender, EventArgs e)
        {
            sumarCeldas();
        }


        private void btnDocModifica_Click(object sender, EventArgs e)
        {
            Int32 col = malla.CurrentCell.ColumnIndex ;
            DataGridViewRow row = malla.Rows [malla.CurrentCell.RowIndex];
            
            string SUC = row.Cells["SUC"].Value.ToString();
            string DOC = row.Cells["DOC"].Value.ToString();
            double IDCLAVE = Convert.ToDouble(row.Cells["idclavedoc"].Value);
            //DateTime fecha = new DateTime(año,mes,DateTime.DaysInMonth (año,mes));
            string numero = row.Cells["secuencial"].Value.ToString();
            ConsAplicacion.frmAplica frapl = new ConsAplicacion.frmAplica(strConxAdcom,IDCLAVE,DOC,numero,dtfechaFinal.Value.ToShortDateString(),SUC);
            frapl.ShowDialog();
            frapl.Dispose();
        }

        private void btnOcultar_Click(object sender, EventArgs e)
        {
            //DaxMallaLib.classBuscMalla prog = new DaxMallaLib.classBuscMalla();
            DaxMallaLib.classBuscMalla.ocultarColumnas(malla);
            btnOcultar.Visible = false;
            btnVer.Visible = true;
            ocultarDefault();
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            //DaxMallaLib.classBuscMalla prog = new DaxMallaLib.classBuscMalla();
            DaxMallaLib.classBuscMalla.verColumnas(malla);
            // prog = null;
            btnOcultar.Visible = true;
            btnVer.Visible = false;
            ocultarDefault();
        }

        private void mnuOcultarColumna_Click(object sender, EventArgs e)
        {
            //DaxMallaLib.classBuscMalla prog = new DaxMallaLib.classBuscMalla();
            DaxMallaLib.classBuscMalla.ocultarColumnasEscojidas(malla);
            //prog = null;
            btnOcultar.Visible = false;
            btnVer.Visible = true;
        }
        private void ocultarDefault()
        {
            if (cmbTipo.SelectedIndex != 1 )
            {
                malla.Columns["Idclavedoc"].Visible = false;
                malla.Columns["suc"].Visible = false;
                malla.Columns["doc"].Visible = false;
            }
            malla.Columns["cl_anio"].Visible = false;
            malla.Columns["cl_mes"].Visible = false;
            malla.Columns["clave"].Visible = false;
        }

        private void btnReembolso_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = malla.Rows[malla.CurrentCell.RowIndex];
            string suc = row.Cells["SUC"].Value.ToString();
            string doc = row.Cells["DOC"].Value.ToString();
            double idclavedoc =0;double.TryParse (row.Cells["idclavedoc"].Value.ToString(),out idclavedoc);
            string establecimiento =row.Cells["establecimiento"].Value.ToString();
            string ptoemision = row.Cells["puntoemision"].Value.ToString();            
            string numero = row.Cells["secuencial"].Value.ToString();

            mntReembolso.manReembolso frmReem = new mntReembolso.manReembolso();
            frmReem.suc = suc;
            frmReem.doc = doc;
            frmReem.estab = establecimiento;
            frmReem.ptovta = ptoemision;
            frmReem.num = numero;
            frmReem.idclavedoc = idclavedoc;
            frmReem.strConx = strConxAdcom;
            frmReem.strSys = strConxIvaret;

            frmReem.ingresarReembolso ();
            frmReem = null;
        }
        #region manejo malla

        private void malla_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            foreach (DataGridViewRow rr in malla.Rows)
            {
                rr.HeaderCell.Value = (rr.Index + 1).ToString();
            }
        }

        protected override Boolean ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (malla.Focused == false && malla.IsCurrentCellInEditMode == false) return false;
            if (malla.IsCurrentCellInEditMode && keyData == Keys.Return) { malla.EndEdit(); return true; }
            if (!(keyData == Keys.Return || (keyData > Keys.F1 && keyData < Keys.F13))) return false;

            DataGridViewCell cell = malla.CurrentCell;
//            if (cell.RowIndex > malla.Rows.Count - 3) { dtDetalleDocumento.Rows.Add(dtDetalleDocumento.NewRow()); }

            funcionesEspeciales(ref keyData, ref cell);

            if (keyData != Keys.Return) return true;
            moverCeldaMalla(cell);
            return true;
        }
        private void moverCeldaMalla(DataGridViewCell cell)
        {

            Int32 columnIndex = cell.ColumnIndex;
            Int32 rowIndex = cell.RowIndex;
            Int32 col = columnIndex;
            Int32 row = rowIndex;

            Boolean esVisible = false;
            do
            {
                if (col == malla.Columns.Count - 1)
                {
                    if (row == malla.Rows.Count - 1)
                    {
                        col = 0;
                        row = 0;
                    }
                    else
                    {
                        col = 0;
                        row++;
                    }
                }
                else
                {
                    col++;
                }
                cell = malla.Rows[row].Cells[col];
                esVisible = (cell.Visible && !cell.ReadOnly);
            } while (esVisible == false);
            malla.CurrentCell = cell;
        }
        private void malla_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell cell = malla.CurrentCell;
            string nombreCelda = malla.Columns[cell.ColumnIndex].Name;
            string datoNvo = "";
            switch (nombreCelda)
            {
                case "Color":
                case "Talla":
                    malla.CurrentRow.Cells["nombre" + nombreCelda].Value = datoNvo;
                    moverCeldaMalla(cell);
                    break;
            }
        }

        private Boolean funcionesEspeciales(ref Keys keyData, ref DataGridViewCell cell)
        {
            FuncionEspecial clasFuncion = new FuncionEspecial();
            malla.EndEdit();
            Boolean resp = true;
            string nombreCol = malla.Columns[cell.ColumnIndex].Name;
            string dato = cell.Value.ToString();

            if (cmbTipo.SelectedIndex == 0) clasFuncion.funcionesCompras(ref keyData,ref cell,ref dato,nombreCol,strConxIvaret,strConxAdcom );
            //else if (cmbTipo.SelectedIndex == 1) clasFuncion.funcionesexportacion(ref keyData, ref cell, ref dato, nombreCol, strConxIvaret, strConxAdcom);            
            return resp;
        }

        #endregion manejo malla

        private void mnuDirectorio_Click(object sender, EventArgs e)
        {
            string ruc = "";
            if (cmbTipo.SelectedIndex == 0 )ruc=malla.Rows[malla.CurrentCell.RowIndex].Cells["idProv"].Value.ToString();
            else if (cmbTipo.SelectedIndex == 1) ruc = malla.Rows[malla.CurrentCell.RowIndex].Cells["idCliente"].Value.ToString();

            Boolean clipro = false;
            string  solocodigo="";
            DaxMantDirectorio.DirectorioAlex alex = new DaxMantDirectorio.DirectorioAlex();
            alex.CargarAlex(ref ruc, ref clipro, ref solocodigo);
            string mensaje = "Nombres: " + alex.NombreImpresion + "\n Id.: " + alex.CiRuc + "\n Dirección: " + alex.direccion + "\n Tlf.: " + alex.telefono1 + "\n Tipo: " + alex.TipoCliente;
            MessageBox.Show(mensaje);
            alex = null;
        }

        private void btnSumatoria_Click(object sender, EventArgs e)
        {
            sumarCeldas();
        }

        private void btnGenerarXml_Click(object sender, EventArgs e)
        {
            string path = "";
            SaveFileDialog SaveFileDialog1 = new SaveFileDialog();
            SaveFileDialog1.Filter = "XML files|*.XML";
            SaveFileDialog1.Title = "Digite un nombre para el archivo XML";

            if (SaveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = SaveFileDialog1.FileName;
            }
            saveFileDialog1.Dispose();
            WaitMensaje.WMensaje.verMensaje("Generando archivo XML de Anexo Transaccional");            
            this.Cursor = Cursors.WaitCursor;
            atsgenxml.atsGenCom prog = new atsgenxml.atsGenCom();
            string proceso = prog.crear_ats_xml(path, datosEmpresa.pathAppl, dtFechaInicio.Value , dtfechaFinal.Value, strConxAdcom, datosEmpresa.Emp_RUC, datosEmpresa.Emp_Nombre, strConxIvaret,regMicroempresa);
            this.Cursor = Cursors.Default;
            WaitMensaje.WMensaje.cierraMensaje();
            if (proceso != "" )
            {
                MessageBox.Show (proceso,"Generación anexo transaccional");                                
            }
            else 
            {
                MessageBox.Show ("Anexo transaccional generado con éxito","Generación anexo transaccional");                                
            }
        }
        private void sumarCeldas()
        {
            //DaxMallaLib.classBuscMalla summ = new DaxMallaLib.classBuscMalla();
            DaxMallaLib.classBuscMalla.sumarMalla(malla);
            //summ = null;
        }

        private void mnuTablasSri_Click(object sender, EventArgs e)
        {
            IvaRett.MntTablasSri  prog = new IvaRett.MntTablasSri();
            prog.ShowDialog();
            prog.Dispose();
        }

        private void mnuDetalleDocumentos_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = malla.CurrentRow ;
            frmDetDocVta prog = new frmDetDocVta(strConxAdcom, row.Cells["idCliente"].Value.ToString(), dtFechaInicio.Value  , dtfechaFinal.Value , row.Cells["tipoComprobante"].Value.ToString());
            prog.ShowDialog();
            prog.Dispose();
        }

        private void mnuEliminarLinea_Click(object sender, EventArgs e)
        {
            try
            {
                if (malla.CurrentCell.RowIndex > -1)
                {
                    if (MessageBox.Show("Confirma Eliminar la linea actual ?", "Eliminar Linea", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No) return;
                }
                malla.Rows.RemoveAt (malla.CurrentCell.RowIndex);
            }
            catch { }
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            panelOpciones.Visible = !panelOpciones.Visible; 
            //frmConxServer prog = new frmConxServer();
            //prog.ShowDialog();
            //prog.Dispose();
        }

        private void malla_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnReembolso.Visible = false;
            try 
            {
                if (malla.CurrentRow.Cells["tipoComprobante"].Value.ToString() == "41" || malla.CurrentRow.Cells["tipoComprobante"].Value.ToString() == "tipoComprobante" || malla.CurrentRow.Cells["tipoComprobante"].Value.ToString() == "48")
                {
                    btnReembolso.Visible = true;                    
                }
            }
            catch { }
        }

 
        private void dtFechaInicio_ValueChanged(object sender, EventArgs e)
        {
            if (dtFechaInicio.Value.Day != 1)
            { dtFechaInicio.Value = new DateTime(dtFechaInicio.Value.Year, dtFechaInicio.Value.Month, 1); }
            if (regMicroempresa != "S") dtfechaFinal.Value = new DateTime(dtFechaInicio.Value.Year, dtFechaInicio.Value.Month, DateTime.DaysInMonth(dtFechaInicio.Value.Year, dtFechaInicio.Value.Month));
        }

        private void dtfechaFinal_ValueChanged(object sender, EventArgs e)
        {            
            if (dtfechaFinal.Value.Day != DateTime.DaysInMonth(dtfechaFinal.Value.Year, dtfechaFinal.Value.Month))            
            { dtfechaFinal.Value = new DateTime(dtfechaFinal.Value.Year, dtfechaFinal.Value.Month, DateTime.DaysInMonth(dtfechaFinal.Value.Year, dtfechaFinal.Value.Month)); }
        }

        private void btnEnviar_ButtonClick(object sender, EventArgs e)
        {
            //SalidasDeMalla.enviandoMalla prog = new SalidasDeMalla.enviandoMalla(malla ,Text,datosEmpresa.Emp_Nombre);
            //prog.ShowDialog();
            //prog.Dispose();
        }

		private void frmAts_Load(object sender, EventArgs e)
		{

		}
	}
}
