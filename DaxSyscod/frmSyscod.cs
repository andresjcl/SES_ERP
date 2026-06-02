using System;
using System.Windows.Forms;
using DattCom;

namespace Syscod
{
    public partial class frmSyscod : Form
    {

      //  private int cambios = 0;
        private int fila = 0;
        private int Columna = 0;
        private long Idclave = 0;
        private string Referencia = "";
        private ClassSyscod SyscodData = new ClassSyscod(datosEmpresa.strConxSyscod);
        public frmSyscod()
        {
            InitializeComponent();
        }
        public void Referencias(string tipoRef, bool fijo = false)
        {
            Referencia = tipoRef;
            cargarReferencias();
            if (Referencia.Length > 0)
            {
                cboTipoRef.SelectedValue = Referencia; cargarMalla(Referencia);
            }
            PonerBotones();
            if (fijo) cboTipoRef.Enabled = false;
            this.ShowDialog();
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmNuevoTipo nvaReferencia = new frmNuevoTipo("");
            nvaReferencia.ShowDialog();
            nvaReferencia.Dispose();
            cargarReferencias();
        }
        private void cboTipoRef_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3 & datosEmpresa.usr.ToUpper() == "ADMINISTRADOR")
                btnNuevo.Visible = !btnNuevo.Visible;
        }

        private void cboTipoRef_TextChanged(object sender, System.EventArgs e)
        {
            if (cboTipoRef.Text != "")
            {
                cargarMalla(cboTipoRef.Text.Trim()); btnGuardar.Visible = true; PonerBotones(); gridDatos.Focus();
            }
        }
        // Este método consulta todas las referencias existentes en la tabla Syscod
        private void cargarReferencias()
        {
            DaxCombobx.CargCmbBox Cargcmbox = new DaxCombobx.CargCmbBox();
            Cargcmbox.DaxCombosReferencia(datosEmpresa.strConxSyscod, ref cboTipoRef);
            PonerBotones();
        }
        // Este método carga la malla con los datos de la referencia escogida
        private void cargarMalla(string tipoRef)
        {
            string ssql = "Select Abreviación,Descripcion, Caracteristica1 ,Caracteristica2,Caracteristica3,Caracteristica4 ,Caracteristica5,isnull(Clave,0) as Clave from syscod where abreviación <>'#' and TipoReferencia='" + tipoRef + "'";
            gridDatos.DataSource = ClassSyscod.Tabla(ssql);
            ArreglarMalla(tipoRef);
        }
        private void ArreglarMalla(string TipoReferencia)
        {
            SyscodData = new ClassSyscod(datosEmpresa.strConxSyscod);
            SyscodData = ClassSyscod.Buscar(" abreviación ='#' and TipoReferencia='" + TipoReferencia + "'");
            if (SyscodData == null) return;
            if (SyscodData.Caracteristica1.Length == 0) gridDatos.Columns["Caracteristica1"].Visible = false;
            if (SyscodData.Caracteristica2.Length == 0) gridDatos.Columns["Caracteristica2"].Visible = false;
            if (SyscodData.Caracteristica3.Length == 0) gridDatos.Columns["Caracteristica3"].Visible = false;
            if (SyscodData.Caracteristica4.Length == 0) gridDatos.Columns["Caracteristica4"].Visible = false;
            if (SyscodData.Caracteristica5.Length == 0) gridDatos.Columns["Caracteristica5"].Visible = false;
            gridDatos.Columns["Clave"].Visible = false;
            gridDatos.Columns["Caracteristica1"].HeaderText = SyscodData.Caracteristica1;
            gridDatos.Columns["Caracteristica2"].HeaderText = SyscodData.Caracteristica2;
            gridDatos.Columns["Caracteristica3"].HeaderText = SyscodData.Caracteristica3;
            gridDatos.Columns["Caracteristica4"].HeaderText = SyscodData.Caracteristica4;
            gridDatos.Columns["Caracteristica5"].HeaderText = SyscodData.Caracteristica5;
        }

        // Metodo para verificar que se haya ingresado la información completa
        private bool verificarCampos()
        {
            bool bandera = false;
            {
                for (var i = 0; i <= gridDatos.RowCount - 2; i++)
                {
                    if (gridDatos.Rows[i].Cells[0].Value.ToString().Length == 0 | gridDatos.Rows[i].Cells[1].Value.ToString().Length == 0)
                    {
                        MessageBox.Show("Debe Ingresar la Abreviación y la descripción en la linea " + i + " antes de continuar");
                        bandera = true;
                        break;
                    }
                }
            }
            return bandera;
        }

        private void Eliminar(string tipoRef)
        {
            string ssql = "delete from syscod where abreviación <>'#' and TipoReferencia='" + tipoRef + "'";
            datos.ComandoSqlSys(ssql);
        }
        private void Guardar()
        {
            foreach (DataGridViewRow row in gridDatos.Rows)
            {
                long clv = 0;
                string abreviacion = "";
                try
                { clv = System.Convert.ToInt64(row.Cells["clave"].Value); }
                catch { }
                try { abreviacion = row.Cells["Abreviación"].Value.ToString(); } catch { }
                if (abreviacion != "")
                {
                    SyscodData = new ClassSyscod(datosEmpresa.strConxSyscod);
                    SyscodData.Clave = clv;
                    SyscodData.TipoReferencia = cboTipoRef.Text;
                    SyscodData.Descripcion = row.Cells["Descripcion"].Value.ToString();
                    SyscodData.Abreviación = abreviacion;
                    SyscodData.Caracteristica1 = row.Cells["Caracteristica1"].Value.ToString();
                    SyscodData.Caracteristica2 = row.Cells["Caracteristica2"].Value.ToString();
                    SyscodData.Caracteristica3 = row.Cells["Caracteristica3"].Value.ToString();
                    SyscodData.Caracteristica4 = row.Cells["Caracteristica4"].Value.ToString();
                    SyscodData.Caracteristica5 = row.Cells["Caracteristica5"].Value.ToString();
                    SyscodData.Actualizar();
                }
            }
        }
        private void btnSalir_Click(System.Object sender, System.EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
        private void gridDatos_CellEndEdit(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (gridDatos.Columns[e.ColumnIndex].Name == "Abreviación" & VerificarExistencia() == true)
            {
                {
                    MessageBox.Show("La Referencia  ''" + gridDatos.Rows[fila].Cells["Abreviación"].Value.ToString() + "  -  " + gridDatos.Rows[fila].Cells["Descripcion"].Value.ToString() + "''   ya existe");
                    gridDatos.Rows[fila].Cells[0].Selected = true;
                    gridDatos.Rows[fila].Cells[0].Value = "";
                    gridDatos.CancelEdit();
                }
            }
        }

        private void gridDatos_CellEnter(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            fila = e.RowIndex;
            Columna = e.ColumnIndex;
            try
            {
                Idclave = System.Convert.ToInt64(gridDatos.Rows[fila].Cells["Clave"].Value);
            }
            catch
            {
                Idclave = 0;
            }
        }

        private bool VerificarExistencia()
        {
            string strfila = gridDatos.Rows[fila].Cells["Abreviación"].Value.ToString().Trim();
            if (strfila == "") return false;
            foreach (DataGridViewRow row in gridDatos.Rows)
            {
                if (row.Cells["Abreviación"].Value != null)
                {
                    if (fila != row.Index & strfila == row.Cells["Abreviación"].Value.ToString().ToUpper().Trim())
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void PonerBotones()
        {
            bool si = false;
            if (cboTipoRef.Text != "") si = true;
            btnGuardar.Visible = si;
            btnCancelar.Visible = si;
        }

        private void gridDatos_CellLeave(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            try { gridDatos.EndEdit(); } catch { }
        }

        private void gridDatos_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (gridDatos.CurrentRow == null) return;
                if (MessageBox.Show("Confirma eliminar la linea actual ? ", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string ssql = "delete from syscod where Clave = " + Idclave.ToString();
                    datos.ComandoSqlSys(ssql);
                    gridDatos.Rows.Remove(gridDatos.CurrentRow);
                }
            }
        }

        private void gridDatos_RowHeaderMouseClick(object sender, System.Windows.Forms.DataGridViewCellMouseEventArgs e)
        {
            fila = e.RowIndex;
            try
            {
                Idclave = System.Convert.ToInt64(gridDatos.Rows[fila].Cells["Clave"].Value);
            }
            catch 
            {
                Idclave = 0;
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

    }
}