using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO ;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace adcValCtb
{
    public partial class Form1 : Form
    {
        string strConxAdcom;
        string strConxDaxsys;
        Int64 periodo = 0;
        string nombrePeriodo = "";
        string Cabecera;
        string detalleDoc;
        DateTime fechaIniPeriodo=DateTime.Now;
        DateTime fechaFinPeriodo=DateTime.Now;
        AdcDax.DaxSofSys defemp = new AdcDax.DaxSofSys();
        int estadoProceso = 0;  // 0 iniciando  1 cargado contabilidad
        public Form1()
        {
            InitializeComponent();
            try
            {
                daaxLib.DaxLibBases dlib = new daaxLib.DaxLibBases();
                dlib.TipoBase = "10";
                strConxAdcom = dlib.StrAdcom();
                strConxDaxsys = dlib.StrDaxsys();
                ponerBotones();
                cargarCombos(defemp.EmpresaAct.codigo);
            }
            catch { this.Close(); return; }
        }
        private void cargarCombos(Int32 emp)
        {
            DaxCbos.DaxCombobx cbox = new DaxCbos.DaxCombobx();
            cbox.DaxCombosDoc("TTB", "", true, strConxAdcom, ref cmbDocumentos);
            cbox.DaxCombosSuc(emp.ToString(), true, strConxDaxsys, ref cmbSucursal);
            cbox = null;
        }
        private void cargarMalla()
        { 
            string doc ="";
            if (cmbDocumentos.SelectedValue.ToString() != "0") doc=cmbDocumentos.SelectedValue.ToString();
            string SUC ="";
            if(cmbSucursal.SelectedValue.ToString() != "0") SUC =cmbSucursal.SelectedValue.ToString();
            string sSql = "ADC_ValCtb '" + doc + "','" + SUC + "','" + dtDesde.Text + "','" + dtHasta.Text + "','" + defemp.EmpresaAct.ConUltAnu.ToShortDateString() + "'";
            SqlDataAdapter misqlDa = new SqlDataAdapter(sSql, strConxAdcom);
            DataTable dato = new DataTable();
            misqlDa.Fill(dato);

            mallaDatos.DataSource = dato;
            arreglarMalla(mallaDatos);
            dato.Dispose();
            estadoProceso = 0;
            if (mallaDatos.Rows.Count != 0) estadoProceso = 1;
            ponerBotones();
        }
        private void arreglarMalla(DataGridView malla)
        {
            try
            {
                string formato = "0.00;;\\";
                malla.Columns["Valor"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                malla.Columns["Valor"].DefaultCellStyle.Format = formato;
                malla.Columns["IdClaveDoc"].Visible = false;
            }
            catch { }
        }

        private void btnexcel_Click(object sender, EventArgs e)
        {
            ExportarGrid.Form1 exp = new ExportarGrid.Form1();
            String Empresa = defemp.EmpresaAct.nombre;
            exp.Exportar(mallaDatos, "E", Empresa, "Directorio");
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close ();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            DataGridViewPrinterApplication1.frmMain imp = new DataGridViewPrinterApplication1.frmMain();
            imp.imprimir(mallaDatos);
        }

        private void btnpdf_Click(object sender, EventArgs e)
        {
            ExportarGrid.Form1 exp = new ExportarGrid.Form1();
            String Empresa = defemp.EmpresaAct.nombre;
            exp.Exportar(mallaDatos, "P", Empresa, "Directorio");
        }

        private void btnword_Click(object sender, EventArgs e)
        {
            ExportarGrid.Form1 exp = new ExportarGrid.Form1();
            String Empresa = defemp.EmpresaAct.nombre;
            exp.Exportar(mallaDatos, "W", Empresa, "Directorio");
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
        //RolPer.frmBuscarPeriodo  busk = new  RolPer.frmBuscarPeriodo();
        //periodo =Convert.ToInt32 ( busk.Buscar(strConxAdcom));

        //Cabecera = "Contabilización nómina  " + txtPeriodo.Text;
        //if (periodo == 0) return;
        //this.UseWaitCursor = true ;
        //this.Cursor = Cursors.WaitCursor;
        //CargarFechasPeriodo(periodo);
        //cargarMalla();
        //this.UseWaitCursor = false ;
        //this.Cursor = Cursors.Default;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            cargarMalla();
        }
        private void ponerBotones()
        {
            //btnActualizar.Enabled = (estadoProceso == 1);
            btnEnviar.Enabled = (estadoProceso == 1);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.mallaDatos.DataError -= new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.mallaDatos_DataError);
            daxBuscMalla.Form1 libBuscar = new daxBuscMalla.Form1(mallaDatos,false);
            libBuscar.ShowDialog();
            libBuscar.Dispose();
            this.mallaDatos.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.mallaDatos_DataError);
        }

        private void mallaDatos_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void btnSumatoria_Click(object sender, EventArgs e)
        {
            sumarCeldas();
        }
        private void sumarCeldas()
        {
            daxBuscMalla.classBuscMalla summ = new daxBuscMalla.classBuscMalla();
            summ.sumarMalla(mallaDatos);
            summ = null;
        }

        private void mallaDatos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3 && daxBuscMalla.Form1.buscoEnMalla != "")
            {
                daxBuscMalla.Form1 libBuscar = new daxBuscMalla.Form1(mallaDatos, false, true);
                libBuscar.ShowDialog();
                libBuscar.Dispose();
            }                
        }
    }
}

