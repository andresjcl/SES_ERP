using DattCom;
using DaxInvent;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using SpreadsheetLight;

namespace DaxInvent
{
	public partial class frmExistenciaBod : Form
	{
		int flag = -1;
        private string codigoArt, nombreArt; private string _codigocategoria;
        private string _codigoclase;
        private string _codigogrupo;
        private SqlDataReader leer;
        private SqlConnection cnx;
        private SqlCommand comando;
        private string _nivelcategoria;
        private string _nivelclase;
        private string _nivelgrupo;
        private string _categoria;
        private string _clase;
        private string _grupo;
        string tit1 = "";
        public frmExistenciaBod()
		{
			InitializeComponent();
		}

		private void toolStripButton2_Click(object sender, EventArgs e)
		{

			flag *= -1;
			if (flag == 1)
			{
				plOpciones.Visible = false;
			}
			else
			{
				plOpciones.Visible = true;
			}
		}

		private void btnProcesar_Click(object sender, EventArgs e)
		{
            llenarMalla(cmbCategoria.Text, cmbClase.Text, cmbGrupo.Text);
			if (ValidateGrid(malla))
			{
				btnExcel.Visible = true;
				btnMovimiento.Visible = true;
				btnImprimir.Visible = true;
			}
		}
        private void llenarMalla(string categoria, string clase, string grupo)
        {
            if (categoria == "Todos" && clase == "Todos" && grupo == "Todos")
            {
                _codigocategoria = "";
                _codigoclase = "";
                _codigogrupo = "";
            }

            if (categoria != "Todos" && clase == "Todos" && grupo == "Todos")
            {
                _codigoclase = "";
                _codigogrupo = "";
            }
            if (categoria == "Todos" && clase != "Todos" && grupo == "Todos")
            {
                _codigocategoria = "";
                _codigogrupo = "";
            }
            if (categoria == "Todos" && clase == "Todos" && grupo != "Todos")
            {
                _codigocategoria = "";
                _codigoclase = "";
            }

            if (categoria == "Todos" && clase != "Todos" && grupo != "Todos")
            {
                _codigocategoria = "";

            }
            if (categoria != "Todos" && clase == "Todos" && grupo != "Todos")
            {
                _codigoclase = "";

            }

            //MallaSaldosBodegas.CargarMallafiltro(txtCodigo.Text, _codigocategoria, _codigoclase, _codigogrupo, malla, cboBodega.SelectedValue.ToString(), dtFechaFin.Value, chkAlfabetico.Checked);
            MallaSaldosBodegas.CargarMallafiltro(txtCodigo.Text, _codigocategoria, _codigoclase, _codigogrupo, malla, cboBodega.SelectedValue.ToString(), dtFechaFin.Value, chkAlfabetico.Checked);
            MallaSaldosBodegas.DiseñaMalla(malla);


        }

        private void llenarBodegas()
        {
            string selectCommandText = "select 0 AS Emp_Codigo ,'0' as Bod_Codigo,'Todas las Bodegas' as Bod_nombre  " + " union all" + " select Emp_Codigo,Bod_codigo,Bod_nombre from Emp_Bod where Emp_Codigo =" + datosEmpresa.codEmpresa;
            DataSet dataSet = new DataSet();
            new SqlDataAdapter(selectCommandText,datosEmpresa.strConIniSis).Fill(dataSet, "Datos");
            cboBodega.DataSource = dataSet.Tables[0];
            cboBodega.DisplayMember = "Bod_nombre";
            cboBodega.ValueMember = "Bod_Codigo";
        }

		private void malla_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
            int filaactual = e.RowIndex;
            if (filaactual != 1)
            {
                filaactual = malla.CurrentRow.Index;
                codigoArt = malla.Rows[filaactual].Cells[3].Value.ToString();
                nombreArt = (string)malla.Rows[filaactual].Cells[2].Value;
            }
        }

		private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
		{
            malla.Columns.Clear();
            cambioNombreCategoria();
            btnImprimir.Visible = false;
            btnExcel.Visible = false;
            btnMovimiento.Visible = false;
            codigoArt = "";
            nombreArt = "";
        }

		private void cmbClase_SelectedIndexChanged(object sender, EventArgs e)
		{
            malla.Columns.Clear();
            cambioNombreClase();
            btnImprimir.Visible = false;
            btnExcel.Visible = false;
            btnMovimiento.Visible = false;
            codigoArt = "";
            nombreArt = "";
        }

		private void cmbGrupo_SelectedIndexChanged(object sender, EventArgs e)
		{
            malla.Columns.Clear();
            cambioNombreGrupo();
            btnImprimir.Visible = false;
            btnExcel.Visible = false;
            btnMovimiento.Visible = false;
            codigoArt = "";
            nombreArt = "";
        }

		private bool ValidateGrid(DataGridView dgvListas)
        {
            if (dgvListas.RowCount != 0)
            {
                return true;
            }
            return false;
            
        }


        #region
        private string[] ObtenerDatosCategoria(string nombreCategoria)
        {
            this.cnx = new SqlConnection(datosEmpresa.strConxAdcom);
            this.comando = new SqlCommand("SELECT Niv_categor,Niv_nombre,Niv_abrevia FROM ADCNIV WHERE Niv_categor=1 and Niv_nombre='" + nombreCategoria + "'", this.cnx);
            this.cnx.Open();
            this.leer = this.comando.ExecuteReader();
            string[] strArray = (string[])null;
            while (this.leer.Read())
                strArray = new string[3]
                {
                      this.leer[0].ToString(),
                      this.leer[1].ToString(),
                      this.leer[2].ToString()
                };

            return strArray;
        }

        private void cambioNombreCategoria()
        {
            if (this.cmbCategoria.SelectedIndex <= 0)
                return;
            string[] strArray = ObtenerDatosCategoria(cmbCategoria.Text);
            this._nivelcategoria = strArray[0];
            this._categoria = strArray[1];
            this._codigocategoria = strArray[2];
        }

        private void llenarCombosCategoria()
        {
            this.cmbCategoria.Items.Clear();            
            this.cnx = new SqlConnection(datosEmpresa.strConxAdcom);
            this.comando = new SqlCommand("SELECT * FROM ADCNIV WHERE Niv_categor = 1 order by Niv_nombre", this.cnx);
            this.cnx.Open();
            this.leer = this.comando.ExecuteReader();
            while (this.leer.Read())
                this.cmbCategoria.Items.Add(this.leer[1]);
            this.cmbCategoria.Items.Insert(0, (object)"Todos");
            this.cmbCategoria.SelectedIndex = 0;
            this.cnx.Close();
        }


        private void llenarCombosClase()
        {
            this.cmbClase.Items.Clear();
            this.cnx = new SqlConnection(datosEmpresa.strConxAdcom);
            this.comando = new SqlCommand("SELECT * FROM ADCNIV WHERE Niv_categor = 2 order by Niv_nombre", this.cnx);
            this.cnx.Open();
            this.leer = this.comando.ExecuteReader();
            while (this.leer.Read())
                this.cmbClase.Items.Add(this.leer[1]);
            this.cmbClase.Items.Insert(0, (object)"Todos");
            this.cmbClase.SelectedIndex = 0;
            this.cnx.Close();
        }

        private string[] ObtenerDatosClase(string nombreClase)
        {
            this.cnx = new SqlConnection(datosEmpresa.strConxAdcom);
            this.comando = new SqlCommand("SELECT Niv_categor,Niv_nombre,Niv_abrevia FROM ADCNIV WHERE Niv_categor=2 and Niv_nombre='" + nombreClase + "'", this.cnx);
            this.cnx.Open();
            this.leer = this.comando.ExecuteReader();
            string[] strArray = (string[])null;
            while (this.leer.Read())
                strArray = new string[3]
                {
          this.leer[0].ToString(),
          this.leer[1].ToString(),
          this.leer[2].ToString()
                };
            this.cnx.Close();
            return strArray;
        }

        private void cambioNombreClase()
        {
            if (this.cmbClase.SelectedIndex <= 0)
                return;
            string[] strArray = this.ObtenerDatosClase(this.cmbClase.Text);
            this._nivelclase = strArray[0];
            this._clase = strArray[1];
            this._codigoclase = strArray[2];
        }

        //private void cmbClase_SelectedIndexChanged(object sender, EventArgs e) => cambioNombreClase();

        private void llenarCombosGrupo()
        {
            this.cmbGrupo.Items.Clear();
            this.cnx = new SqlConnection(datosEmpresa.strConxAdcom);
            this.comando = new SqlCommand("SELECT * FROM ADCNIV WHERE Niv_categor = 3 order by Niv_nombre", this.cnx);
            this.cnx.Open();
            this.leer = this.comando.ExecuteReader();
            while (this.leer.Read())
                this.cmbGrupo.Items.Add(this.leer[1]);
            this.cmbGrupo.Items.Insert(0, (object)"Todos");
            this.cmbGrupo.SelectedIndex = 0;
            this.cnx.Close();
        }

        //private void cmbGrupo_SelectedIndexChanged(object sender, EventArgs e) => cambioNombreGrupo();

        private string[] ObtenerDatosGrupo(string nombreGrupo)
        {
            this.cnx = new SqlConnection(datosEmpresa.strConxAdcom);
            this.comando = new SqlCommand("SELECT Niv_categor,Niv_nombre,Niv_abrevia FROM ADCNIV WHERE Niv_categor=3 and Niv_nombre='" + nombreGrupo + "'", this.cnx);
            this.cnx.Open();
            this.leer = this.comando.ExecuteReader();
            string[] strArray = (string[])null;
            while (this.leer.Read())
                strArray = new string[3]
                {
          this.leer[0].ToString(),
          this.leer[1].ToString(),
          this.leer[2].ToString()
                };
            this.cnx.Close();
            return strArray;
        }

		private void btnBuscar_Click(object sender, EventArgs e)
		{
            buscarArticulo();
        }
        private void buscarArticulo()
        {
            Buscar.frmBuscar businv = new Buscar.frmBuscar();
            string codart = businv.Buscar(datosEmpresa.strConxAdcom, "SELECT Art_codigo as Codigo, Art_nombre as Descripción, Art_unimed as UnMedida FROM AdcArt ", "Codigo", "Descripción", "C", "BUSQUEDA DE ARTÍCULO");
            txtCodigo.Text = codart;
            if (txtCodigo.Text.Length > 0) leerArticulo(txtCodigo.Text);
        }

        private void leerArticulo(string codigo)
        {
            string selectCommandText = "Select art_nombre from adcart where art_codigo = '" + codigo + "'";
            this.cnx = new SqlConnection(datosEmpresa.strConxAdcom);
            cnx.Open();
            comando = new SqlCommand(selectCommandText, cnx);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            sqlDataAdapter.SelectCommand = comando;
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                labArticulo.Text = dt.Rows[0][0].ToString();
            }
            else
            {
                MessageBox.Show("El artículo digitado no existe", "Buscar articulo");
                txtCodigo.Focus();
                labArticulo.Text = "";
            }

            cnx.Close();
        }

		private void toolStripButton1_Click(object sender, EventArgs e)
		{
            this.Close();
        }

		private void btnExcel_Click(object sender, EventArgs e)
		{
            string NombreArchivo = archivoGrabar("XLS");
            if (NombreArchivo != "")
            {
                WaitMensaje.WMensaje.verMensaje("Exportando datos a Excell");
                Cursor = Cursors.WaitCursor;
                //    Text = "EXPORTANDO A EXCEL";
                ExportarExcel exp = new ExportarExcel();
                preparaTitulo();
                if (exp.Exportar_Excel(malla, datosEmpresa.Emp_Nombre, tit1, NombreArchivo) == true)
                {
                    //Close(); Dispose();
                    exp = null;
                    WaitMensaje.WMensaje.cierraMensaje();
                }

            }
            Text = "";
            Cursor = Cursors.Default;
        }
        private void preparaTitulo()
        {
            tit1 = "Existencia de bodega Fecha:  " + dtFechaFin.Text;
        }

        private string archivoGrabar(string opcion)
        {
            try
            {
                opcion = opcion.Substring(0, 1);
            }
            catch { }

            string filename = "";
            string Extencion = "Archivos tipo excel(*.xls) | *.xls";


            SaveFileDialog sfd = new SaveFileDialog();
            Thread t = new Thread((ThreadStart)(() =>
            {
                sfd.OverwritePrompt = true;
                sfd.Title = "Registrar nombre de archivo para exportar información";
                sfd.InitialDirectory = "\tmp";
                sfd.Filter = Extencion;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    filename = sfd.FileName;
                    if (File.Exists(filename))
                    {
                        try
                        {
                            File.Delete(filename);
                        }
                        catch (IOException ex)
                        {
                            MessageBox.Show("No es posible guardar los datos en el archivo especificado " + ex.Message);
                            filename = "";
                        }
                    }
                }
                else { filename = ""; }
            }));

            // Run your code from a thread that joins the STA Thread
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            t.Join();

            return filename;
        }

        public void ExportarMallaExcel(DataGridView mallalista)
        {
            SLDocument sl = new SLDocument();

            int iC = 1;
            foreach (DataGridViewColumn column in mallalista.Columns)
            {
                sl.SetCellValue(1, iC, column.HeaderText.ToString());

                iC++;

            }



        }

		private void frmExistenciaBod_Load(object sender, EventArgs e)
		{
            llenarBodegas();
            llenarCombosCategoria();
            llenarCombosClase();
            llenarCombosGrupo();
            //llenarCombosSubgrupo();
        }

		private void ToolStrip3_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
            
        }

		private void btnImprimir_Click(object sender, EventArgs e)
		{
            if (malla.RowCount == 0) return;
            DataGridViewPrinterApplication1.frmMain imp = new DataGridViewPrinterApplication1.frmMain();
            preparaTitulo();

            imp.imprimir(malla, tit1,datosEmpresa.Emp_Nombre);
        }

		private void btnMovimiento_Click(object sender, EventArgs e)
		{
            frmMovArt artm = new frmMovArt(codigoArt);
            artm.ShowDialog();
        }

		private void cambioNombreGrupo()
        {
            if (this.cmbGrupo.SelectedIndex <= 0)
                return;
            string[] strArray = this.ObtenerDatosGrupo(this.cmbGrupo.Text);
            this._nivelgrupo = strArray[0];
            this._grupo = strArray[1];
            this._codigogrupo = strArray[2];
        }





        #endregion
    }
}
