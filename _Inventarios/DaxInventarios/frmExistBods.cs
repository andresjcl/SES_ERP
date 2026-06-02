using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using DattCom;

namespace DaxInvent

{
    public partial class frmExistBods : Form
    {
        public frmExistBods()
        {
            InitializeComponent();
            CargarBodegas();
        }

        private void cargarMalla()
        {
            MallaSaldosBodegas.CargarMalla(malla, cmbClasificdores.SelectedValue.ToString(), dtFechaFin.Value, chkAlfabetico.Checked);
            MallaSaldosBodegas.DiseñaMalla(malla);
        }
        private void dtFechaIni_ValueChanged(object sender, EventArgs e)
        {
            malla.Columns.Clear();
        }
        private void CargarBodegas()
        {
            DaxCombobx.CargCmbBox prog = new DaxCombobx.CargCmbBox();
            prog.DaxCombosBods("", true, datosEmpresa.strConxSyscod, ref cmbClasificdores);
            cmbClasificdores.SelectedValue = "0";
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnActualiza_Click(object sender, EventArgs e)
        {
            cargarMalla();
        }

        private void btnImprime_Click(object sender, EventArgs e)
        {
            SalidasDeMalla.enviandoMalla prog = new SalidasDeMalla.enviandoMalla(malla," EXITENCIAS POR BODEGA - " + cmbClasificdores.Text ,datosEmpresa.nomEmpresa);
            prog.ShowDialog();
        }

        private void btnSumatoria_Click(object sender, EventArgs e)
        {
            MallaSaldosBodegas.SumatoriaMallaDat(malla);
        }
        private void malla_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            //MessageBox.Show("aqui sort");
        }

        private void cmbClasificdores_SelectedIndexChanged(object sender, EventArgs e)
        {
            malla.Columns.Clear();
        }

        private void chkAlfabetico_CheckedChanged(object sender, EventArgs e)
        {
            malla.Columns.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
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
            DataTable dt = SqlDatos.leerTablaAdcom("Select art_nombre from adcart where art_codigo = '" + codigo + "'");
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
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            limpiar();
            if (e.KeyCode == Keys.F2)
            {
                buscarArticulo();
            }
            if (e.KeyCode == Keys.Return & txtCodigo.Text.Length > 0) leerArticulo(txtCodigo.Text);
        }

        private void limpiar()
        {
            
        }
        private DataTable leerDatos(string ssql)
        {
            SqlConnection conexion = new SqlConnection(datosEmpresa.strConxAdcom);
            conexion.Open();
            DataTable ds = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter(ssql, conexion);
            adp.Fill(ds);
            return ds;
        }
    }
}



