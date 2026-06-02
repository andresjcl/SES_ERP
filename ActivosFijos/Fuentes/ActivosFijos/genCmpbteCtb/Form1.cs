using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace genCmpbteCtbAcf
{
    public partial class Form1 : Form
    {
        string strConxAdcom;
        string strConxDaxsys;
        Int64 periodo = 0;
        string nombrePeriodo = "";
        string Cabecera;
        double totDebe = 0;
        double totHaber = 0;
        double totSin = 0;
        string user = "";
        string detalleDoc;
        DateTime fechaIniPeriodo;
        DateTime fechaFinPeriodo;
        AdcDax.DaxSofSys defemp = new AdcDax.DaxSofSys();
        int estadoProceso = 0;  // 0 iniciando  1 cargado contabilidad
        //AdcDax.Empresa emp;

        public Form1(string usuario)
        {
            InitializeComponent();
            try
            {
                //emp = defemp.EmpresaAct;
                DaxLib.DaxLibBases dlib = new DaxLib.DaxLibBases();
                dlib.TipoBase = "10";
                strConxAdcom = dlib.StrAdcom();
                strConxDaxsys = dlib.StrDaxsys();
                btnCrearDiario.Visible = (defemp.EmpresaAct.Cont);
                ponerBotones();
                cmbDetallado.SelectedIndex = 0;
            }
            catch { this.Close(); return; }
        }

        private void cargarMalla(Int64 periodo)
        {
            mallaDatos.DataSource = null;
            mallaDatos.Columns.Clear();
            string sSql = "nomRevCtb " + periodo.ToString();
            if (cmbDetallado.SelectedIndex == 1) sSql += ",'S'";
            SqlConnection conn = new SqlConnection(strConxAdcom);
            conn.Open();
            SqlCommand comm = new SqlCommand(sSql, conn);
            comm.ExecuteNonQuery();
            sSql = "alter table tmpctb add indice int identity(1,1); ";
            sSql += "alter table tmpctb add CONSTRAINT [PK_tmpCtb] PRIMARY KEY CLUSTERED ([indice] ASC)";
            comm = new SqlCommand(sSql, conn);
            comm.ExecuteNonQuery();

            chequearComodines();

            sSql = "nomRevCos " + fechaIniPeriodo.Year.ToString() + "," + fechaIniPeriodo.Month.ToString();
            comm = new SqlCommand(sSql, conn);
            comm.ExecuteNonQuery();

            comm.Dispose();
            conn.Close();
            conn.Dispose();


            sSql = "nomRevCtb2 " + periodo.ToString();
            if (cmbDetallado.SelectedIndex == 1) sSql += ",'S'";
            SqlDataAdapter misqlDa = new SqlDataAdapter(sSql, strConxAdcom);
            DataTable dato = new DataTable();
            misqlDa.Fill(dato);

            mallaDatos.DataSource = dato;
            arreglarMalla(mallaDatos);
            dato.Dispose();
            estadoProceso = 0;
            if (mallaDatos.Rows.Count != 0) estadoProceso = 1;
            ponerSucursales();
            ponerBotones();
        }
        private void chequearComodines()
        {
            string sSql = "select * from tmpctb ";
            sSql += " where cuenta like '%d%' ";
            sSql += " or cuenta like '%&%' ";
            sSql += " or cuenta like '%P%' ";
            sSql += " or cuenta like '%S%'  ";
            sSql += " or cuenta like '%C%' ";
            sSql += " or cuenta like '%B%' ";
            sSql += " or cuenta like '%F%' ";
            sSql += " or cuenta like '%T%'";

            SqlDataAdapter misqlDa = new SqlDataAdapter(sSql, strConxAdcom);
            DataTable dato = new DataTable();
            misqlDa.Fill(dato);
            daxConta.reglCtb verificador = new daxConta.reglCtb();
            verificador.strConxAdcom = strConxAdcom;
            verificador.strConxSyscod = strConxDaxsys;
            verificador.empCodigo = defemp.EmpresaAct.codigo.ToString();
            foreach (DataRow row in dato.Rows)
            {
                row["cuenta"] = verificador.VerificarComodines(row["cuenta"].ToString(), row["sucursalRol"].ToString(), row["idEmpleado"].ToString(), "", "", "", "", row["DepartamentoRol"].ToString(), "", "");
            }
            SqlCommandBuilder cb = new SqlCommandBuilder(misqlDa);
            misqlDa.Update(dato);
            dato.AcceptChanges();
        }

        private void arreglarMalla(DataGridView malla)
        {
            string formato = "0.00;;\\";
            malla.Columns["Debe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            malla.Columns["Haber"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            try
            {
                malla.Columns["SinCuenta"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                malla.Columns["SinCuenta"].DefaultCellStyle.Format = formato;
            }
            catch { }
            try
            {
                malla.Columns["signo"].Visible = false;
            }
            catch { }
            malla.Columns["Debe"].DefaultCellStyle.Format = formato;
            malla.Columns["Haber"].DefaultCellStyle.Format = formato;

            DataGridViewRow row;
            totDebe = 0;
            totHaber = 0;
            totSin = 0;

            for (int i = 0; i < malla.Rows.Count; i++)
            {
                row = malla.Rows[i];
                totDebe += Convert.ToDouble(row.Cells["Debe"].Value);
                totHaber += Convert.ToDouble(row.Cells["Haber"].Value);
                try
                {
                    totSin += Convert.ToDouble(row.Cells["SinCuenta"].Value);
                }
                catch { }
            }

            label1.Text = "Total Débitos:  " + totDebe.ToString(formato) + "     Créditos:  " + totHaber.ToString(formato) + "   Conceptos sin cuenta contable: " + totSin.ToString(formato);
        }

        private void ponerSucursales()
        {
            //string sucAnt = "";
            //foreach (DataGridViewRow row in mallaDatos.Rows)
            //{ 
            //    if (sucAnt != row.Cells[""])
            //}


        }
        //private void EjecutarProgramaExterno(string programa, string NombreOpcion)
        //{
        //    string OPCION = "";
        //    string codigo = dataGridView1.CurrentRow.Cells["idEmpleado"].ToString();
        //    if (programa.Substring(0, 1) == "(" && programa.Substring(3, 1) == ")") { OPCION = programa.Substring(1, 2); programa = programa.Substring(4); }
        //    string[] filePaths = Directory.GetFiles(emp.PatAppl, programa);
        //    if (filePaths[0].Length != 0)
        //    {
        //        try
        //        {
        //            System.Diagnostics.ProcessStartInfo pi = new System.Diagnostics.ProcessStartInfo();
        //            pi.FileName = programa;
        //            pi.Arguments = OPCION;
        //            pi.WorkingDirectory = emp.PatAppl;
        //            pi.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
        //            //para pasar codigos a las consultas
        //            emp.String2 = pasarCodigoConsultas ;

        //            System.Diagnostics.Process.Start(pi);
        //        }
        //        catch { }
        //    }

        //}

        //private void btnNovedades_Click(object sender, EventArgs e)
        //{
        //    armarCodigoPasa();
        //    EjecutarProgramaExterno("( V)ProyRol.EXE", "");
        //}

        //private void btnPrestamos_Click(object sender, EventArgs e)
        //{
        //    armarCodigoPasa();
        //    EjecutarProgramaExterno("( M)ProyRol.EXE", "");
        //}

        //private void armarCodigoPasa()
        //{
        //    pasarCodigoConsultas = "id";
        //    pasarCodigoConsultas += ";" + dataGridView1.CurrentRow.Cells["idEmpleado"].Value.ToString();
        //    pasarCodigoConsultas += ";" + periodo.ToString();
        //}

        private void btnexcel_Click(object sender, EventArgs e)
        {
            ExportarGrid.Form1 exp = new ExportarGrid.Form1();
            String Empresa = defemp.EmpresaAct.nombre;
            exp.Exportar(mallaDatos, "E", Empresa, "Directorio");
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
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
            //RolPer.frmBuscarPeriodo busk = new RolPer.frmBuscarPeriodo();
            //periodo = Convert.ToInt32(busk.Buscar(strConxAdcom));

            Cabecera = "Contabilización nómina  " + txtPeriodo.Text;
            if (periodo == 0) return;
            this.UseWaitCursor = true;
            this.Cursor = Cursors.WaitCursor;
            CargarFechasPeriodo(periodo);
            cargarMalla(periodo);
            this.UseWaitCursor = false;
            this.Cursor = Cursors.Default;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            cargarMalla(periodo);
        }
        private void CargarFechasPeriodo(Int64 periodo)
        {
            DataTable dt = new DataTable();
            string sel = "SELECT * FROM ROLPER WHERE PER_NUMERO = " + periodo.ToString();
            SqlDataAdapter da = new SqlDataAdapter(sel, strConxAdcom);
            da.Fill(dt);
            txtPeriodo.Text = "Periodo: " + periodo.ToString() + " - " + string.Format("{0:dd/MMM/yyyy}", Convert.ToDateTime(dt.Rows[0]["per_fechaini"])) + " al " + string.Format("{0:dd/MMM/yyyy}", dt.Rows[0]["per_fechafin"]);
            detalleDoc = "Contabilización nómina " + nombrePeriodo;
            fechaIniPeriodo = Convert.ToDateTime(dt.Rows[0]["per_fechaIni"]);
            fechaFinPeriodo = Convert.ToDateTime(dt.Rows[0]["per_fechaFin"]);
            nombrePeriodo = dt.Rows[0]["per_fechaFin"].ToString();
            da.Dispose();
            dt.Dispose();
        }

        private void btnCrearDiario_Click(object sender, EventArgs e)
        {
            //Form2 prog = new Form2(defemp.EmpresaAct.SucActual, user, strConxAdcom, strConxDaxsys, mallaDatos, Convert.ToDecimal(totDebe), defemp.EmpresaAct.codigo.ToString(), ref detalleDoc, nombrePeriodo);
            //prog.ShowDialog();
            //prog.Dispose();
            //prog = null;
        }

        private void chkDetalle_CheckedChanged(object sender, EventArgs e)
        {
            mallaDatos.Columns.Clear();
            estadoProceso = 0;
            ponerBotones();
        }
        private void ponerBotones()
        {
            btnAbrir.Enabled = (estadoProceso == 0);
            btnActualizar.Enabled = (estadoProceso == 1);
            btnCrearDiario.Enabled = (estadoProceso == 1 && cmbDetallado.SelectedIndex == 1);
            btnEnviar.Enabled = (estadoProceso == 1);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.mallaDatos.DataError -= new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.mallaDatos_DataError);
            daxBuscMalla.frmBuscMall libBuscar = new daxBuscMalla.frmBuscMall(mallaDatos, false);
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
            daxBuscMalla.classBuscMalla.sumarMalla(mallaDatos);
        }

        private void mallaDatos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3 && daxBuscMalla.frmBuscMall.buscoEnMalla != "")
            {
                daxBuscMalla.frmBuscMall libBuscar = new daxBuscMalla.frmBuscMall(mallaDatos, false, true);
                libBuscar.ShowDialog();
                libBuscar.Dispose();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //private void mallaDatos_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        //{
        //    double sumaTotal = 0;
        //    double valor = 0;
        //    foreach (DataGridViewCell cell in mallaDatos.SelectedCells)
        //    {
        //        valor = 0;
        //        Double.TryParse(cell.Value.ToString(), out valor);
        //        sumaTotal += valor;
        //    }
        //    labTotalSuma.Text = "Suman Celdas : " + sumaTotal.ToString("#,0.00");

        //}
    }
}

