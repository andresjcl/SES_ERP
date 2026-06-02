using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DaxMallaLib
{
    public partial class frmBuscMall : Form
    {
        public static string buscoEnMalla = "";
        static Int32 ultColumna = 0;
        static Int32 ultLinea = 0;

        private int estado = 0;
        Boolean esFecha = false;
//        Boolean esValor = false;
        DateTime fechaAbuscar= new DateTime();
//        double valoraBuscar = 0;
        DateTime fechaNueva = new DateTime();
//        double valorNuevo = 0;


//        DateTime fechaCelda = new DateTime();
        DataGridView mallaBusc = new DataGridView();
        Boolean conReemplazo = false;
        Boolean repiteBusqueda = false;
        //Boolean yaLeiEstaCelda = false;
        //comparar like = new comparar();
        public frmBuscMall(DataGridView vieneMalla, Boolean Reemplazar, Boolean buscaOtraVez = false)
        {
            InitializeComponent();
            mallaBusc = vieneMalla;
            this.mallaBusc.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.mallaBusc_DataError);
            cmbAmbitoBusqueda.SelectedIndex = 0;
            conReemplazo = Reemplazar;
            repiteBusqueda = buscaOtraVez;
            chkValor.Checked = false;
            if (mallaBusc.SelectedCells.Count > 1) cmbAmbitoBusqueda.SelectedIndex = 2;
            if (conReemplazo == false) { btnReemplazar.Visible = false; btnBuscar.Checked = true; }
        }
        private void btnInicia_Click(object sender, EventArgs e)
        {
            DaxMallaLib.busMallBuscar.inicializar();
            ejecutarBusqueda();
            this.Close();
        }
        public void buscaProxima()
        {
            repiteBusqueda = true;
            if (cmbAmbitoBusqueda.SelectedIndex == 0) { ultLinea = mallaBusc.CurrentCell.RowIndex + 1; if (ultLinea > mallaBusc.Rows.Count - 1) ultLinea = 0; }
            if (cmbAmbitoBusqueda.SelectedIndex == 1) { ultColumna = mallaBusc.CurrentCell.ColumnIndex + 1; if (ultColumna > mallaBusc.Columns.Count - 1) ultColumna = 0; }
            if (cmbAmbitoBusqueda.SelectedIndex == 3)
            {
                ultColumna = mallaBusc.CurrentCell.ColumnIndex + 1;
                ultLinea = mallaBusc.CurrentCell.RowIndex;
                if (ultColumna > mallaBusc.Columns.Count - 1)
                {
                    ultColumna = 0;
                    ultLinea++;
                    if (ultLinea > mallaBusc.Rows.Count - 1) ultLinea = 0;
                }
            }
            busMallBuscar.ultColumnaSeleccionada = ultColumna;
            busMallBuscar.ultLineaSeleccionada = ultLinea;
            ejecutarBusqueda();
            this.Cursor = Cursors.Default;
            this.Close();
        }
        private void ejecutarBusqueda()
        {
            this.Cursor = Cursors.WaitCursor;
            int buscarPorValor = 0;
            if (chkValor.Checked == true) buscarPorValor = 1;

            if (btnBuscar.Checked)
            {
                if (cmbAmbitoBusqueda.SelectedIndex == 0) { estado = busMallBuscar.buscarEnColumna(mallaBusc, txtBuscar.Text, buscarPorValor); return; }
                if (cmbAmbitoBusqueda.SelectedIndex == 1) { estado = busMallBuscar.buscarEnLinea(mallaBusc, txtBuscar.Text, buscarPorValor); return; }
                if (cmbAmbitoBusqueda.SelectedIndex == 2) { estado = busMallBuscar.buscarCeldasSeleccionadas(mallaBusc, txtBuscar.Text, buscarPorValor); return; }
                if (cmbAmbitoBusqueda.SelectedIndex == 3) { estado = busMallBuscar.buscarEnMalla(mallaBusc, txtBuscar.Text, fechaAbuscar, buscarPorValor); return; }
//                encontrado();
            }
            else
            {
                try
                {
                    fechaNueva = Convert.ToDateTime(txtReemplazar.Text);
                }
                catch { esFecha = false;};

                if (cmbAmbitoBusqueda.SelectedIndex == 0) { reemplazarEnColumna(mallaBusc, txtReemplazar.Text, txtBuscar.Text, fechaAbuscar); }
                if (cmbAmbitoBusqueda.SelectedIndex == 1) { reemplazarEnLinea(mallaBusc, txtReemplazar.Text, txtBuscar.Text, fechaAbuscar); }
                if (cmbAmbitoBusqueda.SelectedIndex == 2) { reemplazarCeldasSeleccionadas(mallaBusc, txtReemplazar.Text, txtBuscar.Text, fechaAbuscar); }
                if (cmbAmbitoBusqueda.SelectedIndex == 3) { reemplazarEnMalla(mallaBusc, txtReemplazar.Text, txtBuscar.Text, fechaAbuscar);}
  //              encontrado();
            }
            this.Cursor = Cursors.Default;
            this.Close();
        }
        private void reemplazarCeldasSeleccionadas(DataGridView malla, string nuevoValor,string valorBuscar, DateTime fechaBuscar)
        { 
            if (nuevoValor.Length == 0) return;
            try
            {
                fechaAbuscar = Convert.ToDateTime (malla.SelectedCells[0].Value);
                fechaAbuscar = Convert.ToDateTime(valorBuscar);
                esFecha = true;
            }
            catch { }
            estado = 0;
            foreach (DataGridViewCell cell in malla.SelectedCells)
            {
                reemplazarCelda(cell, valorBuscar, nuevoValor, fechaAbuscar);
                if (estado == 1) return;
            }
            this.Close();
        }
        private void reemplazarEnColumna(DataGridView malla, string nuevoValor, string valorBuscar, DateTime fechaBuscar)
        {
            if (nuevoValor.Length == 0) return;
            Int32 columna = malla.CurrentCell.ColumnIndex;
            estado = 0;
            
            for (Int32 i = 0; i < malla.Rows.Count; i++)
            {
                reemplazarCelda(malla.Rows[i].Cells[columna], valorBuscar, nuevoValor,fechaAbuscar);
                if (estado == 1) return;
            }
            this.Close();
        }
        private void reemplazarEnLinea(DataGridView malla, string nuevoValor, string valorBuscar, DateTime fechaBuscar)
        {
            if (nuevoValor.Length == 0) return;
            Int32 linea = malla.CurrentCell.RowIndex;
            try
            {
                fechaAbuscar = Convert.ToDateTime(malla.CurrentCell.Value);
                fechaAbuscar = Convert.ToDateTime(valorBuscar);
                esFecha = true;
            }
            catch { }
            estado = 0;
            for (Int32 i = 0; i < malla.Rows.Count; i++)
            {
                try
                {
                    reemplazarCelda(malla.Rows[linea].Cells[i], valorBuscar, nuevoValor, fechaBuscar);
                    if (estado == 1) return;
                }
                catch { }
            }
            this.Close();
        }
        private void reemplazarEnMalla(DataGridView malla, string nuevoValor, string valorBuscar, DateTime fechaBuscar)
        {
            if (nuevoValor.Length == 0) return;
            estado = 0;
            for (Int32 j = 0; j < malla.Columns.Count; j++)
            {
                try
                {
                    fechaAbuscar = Convert.ToDateTime(malla.Rows[0].Cells[j].Value);
                    fechaAbuscar = Convert.ToDateTime(valorBuscar);
                    esFecha = true;
                }
                catch { }
                for (Int32 i = 0; i < malla.Rows.Count; i++)
                try
                {
                    reemplazarCelda(malla.Rows[i].Cells[j], valorBuscar, nuevoValor, fechaBuscar);
                    if (estado == 1) return;
                }
                catch { }
            }
            this.Close();
        }
        private void reemplazarCelda(DataGridViewCell cell, string valorBuscar, string nuevoValor, DateTime fechaBuscar)
        {
            if (cell.Value  == null) return;
            if (esFecha)
            {
                if ((Convert.ToDateTime(cell.Value) == fechaAbuscar && valorBuscar.Length > 0) || valorBuscar.Length == 0) cell.Value = nuevoValor;
            }
            else
            {
                if ((cell.Value.ToString() == valorBuscar && valorBuscar.Length > 0) || valorBuscar.Length == 0) cell.Value = nuevoValor;
            }
        }

        private void btnCancela_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_CheckedChanged(object sender, EventArgs e)
        {
            cambiaReemplazar();
        }
        private void cambiaReemplazar()
        {
            label2.Visible = btnReemplazar.Checked;
            txtReemplazar.Visible = btnReemplazar.Checked;
            if (btnBuscar.Checked) chkValor.Checked = false;
            chkValor.Enabled = btnReemplazar.Checked;
        }
        private void mallaBusc_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Este tipo de operación no se puede realizar (verifique el tipo de datos)");
            estado = 1;
        }

        //private void cmbOperador_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    //if (cmbOperador.SelectedIndex == 1)
        //    //{ 
        //    //    txtBuscar.Text = "";
        //    //    txtBuscar.Enabled = false;
        //    //}
        //    //else
        //    //{
        //    //    txtBuscar.Enabled = true;
        //    //}
        //}

        private void Form1_Load(object sender, EventArgs e)
        {
            if (repiteBusqueda && buscoEnMalla != "") { txtBuscar.Text = buscoEnMalla; ejecutarBusqueda(); }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return) ejecutarBusqueda();
        }
        private void encontrado()
        {
            if (estado == 0) MessageBox.Show("No se encontró ninguna coincidencia", "Buscar valores en malla de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void chkValor_CheckedChanged(object sender, EventArgs e)
        {

        }

    }
}
