using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using compararStrings;
namespace daxBuscMalla
{
    public partial class Form1 : Form
    {
        public static string buscoEnMalla = "";
        static Int32 ultColumna = 0;
        static Int32 ultLinea = 0;

        private int estado = 0;
        Boolean esFecha = false;
        DateTime fecha= new DateTime();

        DataGridView mallaBusc = new DataGridView();
        Boolean conReemplazo = false;
        Boolean repiteBusqueda = false;
        Boolean yaLeiEstaCelda = false;
        comparar like = new comparar();
        public Form1(DataGridView vieneMalla, Boolean Reemplazar, Boolean buscaOtraVez = false)
        {
            InitializeComponent();
            mallaBusc = vieneMalla;
            this.mallaBusc.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.mallaBusc_DataError);
            cmbAmbitoBusqueda.SelectedIndex = 0;
            cmbOperador.SelectedIndex = 0;
            if (mallaBusc.SelectedCells.Count > 1) cmbAmbitoBusqueda.SelectedIndex = 2;
            if (conReemplazo == false) { btnReemplazar.Visible = false; btnBuscar.Checked = true; }
            repiteBusqueda = buscaOtraVez;
        }
        private void btnInicia_Click(object sender, EventArgs e)
        {
            ejecutarBusqueda();
        }
        private void ejecutarBusqueda()
        {
            if (btnBuscar.Checked)
            {
                if (cmbAmbitoBusqueda.SelectedIndex == 0) { buscarEnColumna(mallaBusc, txtBuscar.Text); return; }
                if (cmbAmbitoBusqueda.SelectedIndex == 1) { buscarEnLinea(mallaBusc, txtBuscar.Text); return; }
                if (cmbAmbitoBusqueda.SelectedIndex == 2) { buscarCeldasSeleccionadas(mallaBusc, txtBuscar.Text); return; }
                if (cmbAmbitoBusqueda.SelectedIndex == 3) { buscarEnMalla(mallaBusc, txtBuscar.Text); return; }
            }
            else
            {
                if (cmbAmbitoBusqueda.SelectedIndex == 0) { reemplazarEnColumna(mallaBusc, txtReemplazar.Text, txtBuscar.Text); return; }
                if (cmbAmbitoBusqueda.SelectedIndex == 1) { reemplazarEnLinea(mallaBusc, txtReemplazar.Text, txtBuscar.Text); return; }
                if (cmbAmbitoBusqueda.SelectedIndex == 2) { reemplazarCeldasSeleccionadas(mallaBusc, txtReemplazar.Text, txtBuscar.Text); return; }
                if (cmbAmbitoBusqueda.SelectedIndex == 3) { reemplazarEnMalla(mallaBusc, txtReemplazar.Text, txtBuscar.Text); return; }
            }
        }
        private void reemplazarCeldasSeleccionadas(DataGridView malla, string nuevoValor,string valorBuscar)
        {
            if (nuevoValor.Length == 0) return;
            try
            {
                fecha = Convert.ToDateTime (malla.SelectedCells[0].Value);
                fecha = Convert.ToDateTime(valorBuscar);
                esFecha = true;
            }
            catch { }
            estado = 0;
            foreach (DataGridViewCell cell in malla.SelectedCells)
            {
                reemplazarCelda(cell, valorBuscar, nuevoValor);
                if (estado == 1) return;
            }
            this.Close();
        }
        private void buscarCeldasSeleccionadas(DataGridView malla,string valorBuscar)
        {
            try
            {
                fecha = Convert.ToDateTime(valorBuscar);
                esFecha = true;
            }
            catch { }
            estado = 0;
            foreach (DataGridViewCell cell in malla.SelectedCells)
            {
                BuscarCelda(cell,  valorBuscar);
                if (estado == 1) break;
            }
            this.Close();
        }
        private void reemplazarEnColumna(DataGridView malla, string nuevoValor, string valorBuscar)
        {
            if (nuevoValor.Length == 0) return;
            Int32 columna = malla.CurrentCell.ColumnIndex;
            try
            {
                fecha = Convert.ToDateTime(malla.CurrentCell.Value);
                fecha = Convert.ToDateTime(valorBuscar);
                esFecha = true;
            }
            catch { }
            estado = 0;
            for (Int32 i = 0; i < malla.Rows.Count; i++)
            {
                reemplazarCelda(malla.Rows[i].Cells[columna], valorBuscar, nuevoValor);
                if (estado == 1) return;
            }
            this.Close();
        }
        private void buscarEnColumna(DataGridView malla, string valorBuscar)
        {
            Int32 columna = malla.CurrentCell.ColumnIndex;
            try
            {
                fecha = Convert.ToDateTime(malla.CurrentCell.Value);
                fecha = Convert.ToDateTime(valorBuscar);
                esFecha = true;
            }
            catch { }
            estado = 0;
            for (Int32 i = 0; i < malla.Rows.Count; i++)
            {
                BuscarCelda(malla.Rows[i].Cells[columna], valorBuscar);
                if (estado == 1) break;
            }
            this.Close();
        }

        private void reemplazarEnLinea(DataGridView malla, string nuevoValor, string valorBuscar)
        {
            if (nuevoValor.Length == 0) return;
            Int32 linea = malla.CurrentCell.RowIndex;
            try
            {
                fecha = Convert.ToDateTime(malla.CurrentCell.Value);
                fecha = Convert.ToDateTime(valorBuscar);
                esFecha = true;
            }
            catch { }
            estado = 0;
            for (Int32 i = 0; i < malla.Rows.Count; i++)
            {
                try
                {
                    reemplazarCelda(malla.Rows[linea].Cells[i], valorBuscar, nuevoValor);
                    if (estado == 1) return;
                }
                catch { }
            }
            this.Close();
        }
        private void buscarEnLinea(DataGridView malla, string valorBuscar)
        {
            Int32 linea = malla.CurrentCell.RowIndex;
            try
            {
                fecha = Convert.ToDateTime(malla.CurrentCell.Value);
                fecha = Convert.ToDateTime(valorBuscar);
                esFecha = true;
            }
            catch { }
            estado = 0;
            for (Int32 i = 0; i < malla.Rows.Count; i++)
            {
                try
                {
                    BuscarCelda(malla.Rows[linea].Cells[i], valorBuscar);
                    if (estado == 1) break;
                }
                catch { }
            }
            this.Close();
        }
        private void reemplazarEnMalla(DataGridView malla, string nuevoValor, string valorBuscar)
        {
            if (nuevoValor.Length == 0) return;
            estado = 0;
            for (Int32 j = 0; j < malla.Columns.Count; j++)
            {
                try
                {
                    fecha = Convert.ToDateTime(malla.Rows[0].Cells[j].Value);
                    fecha = Convert.ToDateTime(valorBuscar);
                    esFecha = true;
                }
                catch { }
                for (Int32 i = 0; i < malla.Rows.Count; i++)
                try
                {
                    reemplazarCelda(malla.Rows[i].Cells[j], valorBuscar, nuevoValor);
                    if (estado == 1) return;
                }
                catch { }
            }
            this.Close();
        }
        private void buscarEnMalla(DataGridView malla, string valorBuscar)
        {
            estado = 0;
            for (Int32 j = 0; j < malla.Columns.Count; j++)
            {
                try
                {
                    fecha = Convert.ToDateTime(malla.Rows[0].Cells[j].Value);
                    fecha = Convert.ToDateTime(valorBuscar);
                    esFecha = true;
                }
                catch { }
                for (Int32 i = 0; i < malla.Rows.Count; i++)
                    try
                    {
                        BuscarCelda(malla.Rows[i].Cells[j], valorBuscar);
                        if (estado == 1) break;
                    }
                    catch { }
            }
            this.Close();
        }

        private void reemplazarCelda(DataGridViewCell cell,string valorBuscar,string nuevoValor)
        {
            if (cell.Value  == null) return;
            if (esFecha)
            {
                if ((Convert.ToDateTime(cell.Value) == fecha && valorBuscar.Length > 0) || valorBuscar.Length == 0) cell.Value = nuevoValor;
            }
            else
            {
                if ((cell.Value.ToString() == valorBuscar && valorBuscar.Length > 0) || valorBuscar.Length == 0) cell.Value = nuevoValor;
            }
        }
        private void BuscarCelda(DataGridViewCell cell, string valorBuscar, int tipo=0)
        {
            if (cell.Value == null) return;
            if (repiteBusqueda == true)
            {
                if (yaLeiEstaCelda == false)
                {
                    if (cell.RowIndex == ultLinea && cell.ColumnIndex == ultColumna) { yaLeiEstaCelda = true; }
                    return;
                }
            }
            if (esFecha)
            {
                if (Convert.ToDateTime(cell.Value)  == fecha) 
                {
                    mallaBusc.CurrentCell = cell;
                    estado = 1;
                }
            }
            else
            {
                if (like.likke (cell.Value.ToString(),valorBuscar))
                {
                    mallaBusc.CurrentCell = cell;
                    estado = 1;
                }
            }
            if (estado == 1)
            {
                ultColumna = cell.ColumnIndex;
                ultLinea = cell.RowIndex;
                buscoEnMalla = txtBuscar.Text;                
            }
            else if(cell.RowIndex == mallaBusc.Rows.Count -1)
            {
                ultColumna = -1;
                ultLinea = -1;
                buscoEnMalla = "";
                MessageBox.Show("Se ha llegado al final de la búsqueda no exiten mas coincidencias");
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
            cmbOperador.Enabled = btnReemplazar.Checked;
            if (btnBuscar.Checked) cmbOperador.SelectedIndex = 0;
        }
        private void mallaBusc_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Este tipo de operación no se puede realizar (verifique el tipo de datos)");
            estado = 1;
        }

        private void cmbOperador_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbOperador.SelectedIndex == 1)
            { 
                txtBuscar.Text = "";
                txtBuscar.Enabled = false;
            }
            else
            {
                txtBuscar.Enabled = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (repiteBusqueda && buscoEnMalla != "") { txtBuscar.Text = buscoEnMalla; ejecutarBusqueda(); }
        }

    }
}
