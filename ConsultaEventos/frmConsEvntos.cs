using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
namespace registraEvntos
{
    public partial class frmConsEvntos : Form
    {
         const String VerDocumentos = "DO";
        //const String PREFERENCIAS = "PRE";
        const String VerUsuario = "US";
        const String VerNovedades = "NV";
        string strConxDaxsys = "";
        string nombreEmpresa;
        int codigoEmpresa = 0;
        DaxMallaLib.frmBuscMall libBuscar;
        public frmConsEvntos(string strConxSys,string EmpNombre,int EmpCod)
        {
            InitializeComponent();
            IniciarCampos();
            strConxDaxsys = strConxSys;
            nombreEmpresa = EmpNombre;
            codigoEmpresa = EmpCod;
        }
        private void IniciarCampos()
        {
            dtHasta.Value = DateTime.Now;
            dtDesde.Value = new DateTime(dtHasta.Value.Year, dtHasta.Value.Month, 1);
            cmbOpcion.SelectedIndex = 0;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (malla.Rows.Count > 0)
            {
                if (MessageBox.Show("Confirma salir del proceso actual ?", "Cerrar aplicativo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No) return;
            }
            this.Close();
        }


        private void malla_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Este tipo de operación no se puede realizar (verifique el tipo de datos)");
            ConfMalla.estado = 1;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.malla.DataError -= new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.malla_DataError);
            libBuscar = new DaxMallaLib.frmBuscMall(malla,false,false);
            libBuscar.ShowDialog();            
            this.malla.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.malla_DataError);
        }
        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.malla.DataError -= new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.malla_DataError);
            //            libBuscar = new daxBuscMalla.Form1(malla, true, true);
            try
            {
                libBuscar.buscaProxima();
            }
            catch { }
            this.malla.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.malla_DataError);
        }

        private void ImprimirToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
        {
               
            DataGridViewPrinterApplication1.frmMain imp = new DataGridViewPrinterApplication1.frmMain();
            string tit2 = "";
            imp.imprimir(malla,"Reporte eventos del sistema", tit2, nombreEmpresa);
        }

        private void WordToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
        {
            mallExp.Form1 exp = new mallExp.Form1();
            exp.Exportar(malla, "W", nombreEmpresa, "");
        }

        private void ExcelToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
        {
            mallExp.Form1 exp = new mallExp.Form1();
            exp.Exportar(malla, "E", nombreEmpresa, "");
        }

        private void PDFToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
        {
            mallExp.Form1 exp = new mallExp.Form1();
            exp.Exportar(malla, "P", nombreEmpresa, "");
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
          
            string seleccion = VerDocumentos;
            
            if (cmbOpcion.SelectedIndex == 1)
            {
                seleccion = VerUsuario;
            }
            else if (cmbOpcion.SelectedIndex == 2)
            {
                seleccion = VerNovedades;
            }
            string SSQL = "SELECT  Usuario,Fecha,Equipo, Sistema,Sys1 AS ACCIÓN,   DocSucursal + ' ' + DocTipo + '  ' + DocNumero as Documento, Valor";
            SSQL += " FROM sysEvnts WHERE tipo = '" + seleccion + "'";
            //if ()+ " and  EMPRESA = " + codigoEmpresa.ToString();
            SSQL += " and Tipo = '" + seleccion + "' ";
            DataTable dt = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter(SSQL, strConxDaxsys))
            {
                da.Fill(dt);
                malla.DataSource = dt;
            }

        }
    }
}
