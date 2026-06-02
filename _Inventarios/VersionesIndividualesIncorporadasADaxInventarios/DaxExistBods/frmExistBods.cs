using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace DaxInvLib

{
    public partial class frmExistBods : Form
    {
        public frmExistBods()
        {
            InitializeComponent();
            varbleComun.cargar.iniciar("", "");
            CargarBodegas();
        }

        private void cargarMalla()
        {
            Datos.CargarMalla(malla, cmbClasificdores.SelectedValue.ToString(), dtFechaFin.Value, chkAlfabetico.Checked);
            Datos.DiseñaMalla(malla);
        }
        private void dtFechaIni_ValueChanged(object sender, EventArgs e)
        {
            malla.Columns.Clear();
        }
        private void CargarBodegas()
        {
            DaxCbos.DaxCombobx prog = new DaxCbos.DaxCombobx();
            prog.DaxCombosBods("", true, varbleComun.VarCom.strConxSyscod, ref cmbClasificdores);
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
            SalidasDeMalla.enviandoMalla prog = new SalidasDeMalla.enviandoMalla(malla," EXITENCIAS POR BODEGA - " + cmbClasificdores.Text ,varbleComun.VarCom.nomEmpresa);
            prog.ShowDialog();
        }

        private void btnSumatoria_Click(object sender, EventArgs e)
        {
            Datos.SumatoriaMallaDat(malla);
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
    }
}



