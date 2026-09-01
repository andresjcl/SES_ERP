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
using DattCom;
using DaxMallaLib;

namespace sesValCtb
{
    public partial class frmValidacionAsientos : Form
    {
        string strConxAdcom;
        string strConxDaxsys;
        //Int64 periodo = 0;
        //string nombrePeriodo = "";
        //string Cabecera;
        //string detalleDoc;
        DateTime fechaIniPeriodo=DateTime.Now;
        DateTime fechaFinPeriodo=DateTime.Now;        
        int estadoProceso = 0;  // 0 iniciando  1 cargado contabilidad
        public frmValidacionAsientos()
        {
            InitializeComponent();
            try
            {               
                strConxAdcom =datosEmpresa.strConxAdcom;
                strConxDaxsys = datosEmpresa.strConIniSis;
                ponerBotones();
                cargarCombos(datosEmpresa.Emp_codigo);
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
            string sSql = "ADC_ValCtb '" + doc + "','" + SUC + "','" + dtDesde.Text + "','" + dtHasta.Text + "','" +datosEmpresa.Par_RolCodMay + "'";
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
            mallExp.Form1 exp = new mallExp.Form1();
            String Empresa = datosEmpresa.Emp_Nombre;
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
            mallExp.Form1 exp = new mallExp.Form1();
            String Empresa = datosEmpresa.Emp_Nombre;
            exp.Exportar(mallaDatos, "P", Empresa, "Directorio");
        }

        private void btnword_Click(object sender, EventArgs e)
        {
            mallExp.Form1 exp = new mallExp.Form1();
            String Empresa = datosEmpresa.Emp_Nombre;
            exp.Exportar(mallaDatos, "W", Empresa, "Directorio");
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
        
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
            frmBuscMall libBuscar = new frmBuscMall(mallaDatos,false);
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
        //private void sumarCeldas()
        //{
        //    classBuscMalla summ = new classBuscMalla();
        //    summ.sumarMalla(mallaDatos);
        //    summ = null;
        //}

        private void sumarCeldas()
        {
            classBuscMalla.sumarMalla(mallaDatos);
        }

        private void mallaDatos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3 && frmBuscMall.buscoEnMalla != "")
            {
                frmBuscMall libBuscar = new frmBuscMall(mallaDatos, false, true);
                libBuscar.ShowDialog();
                libBuscar.Dispose();
            }                
        }
    }
}

