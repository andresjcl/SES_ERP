using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using DattCom;
using System.Windows.Forms;

namespace DaxInvent
{
    public partial class FrmMantMed : Form
    {
        //private string accion = "Nuevo";
        private int cambios = 0;
        private int fila = 0;
        private int columna = 0;
        private string TipoFuera = "";
        public FrmMantMed(string TipoMedida)
        {
            InitializeComponent();
            Bloquear(true);
            if (TipoMedida.Length > 0)
            {
                TipoFuera = TipoMedida;
                cargarDatos(TipoMedida);
                Bloquear(false);
            }
        }

        private void limpiar()
        {
            txtCodigo.Text = "";
            txtDescripcion.Text = "";
            MALLA.Rows.Clear();
        }
        private void Bloquear(bool op)
        {
            btnAbrir.Enabled = op;
            btnNuevo.Enabled = op;
            btnSalir.Enabled = op;
            btnGuardar.Enabled = !op;
            btnEliminar.Enabled = !op;
            btnCancelar.Enabled = !op;
            txtCodigo.Enabled = !op;
            txtDescripcion.Enabled = !op;
            MALLA.Enabled = !op;
        }

        private void btnAbrir_Click(System.Object sender, System.EventArgs e)
        {
            abrir();
        }
        private void abrir()
        {
            string cod = "";
            string Descripcion = "";
            Syscod.frmBuscarTipoRef Pbus = new Syscod.frmBuscarTipoRef();
            cod = Pbus.BuscarTipoRef("MEDIDAS", ref cod, ref Descripcion);
            if (cod != "")
            {
                txtCodigo.Text = cod;
                txtDescripcion.Text = Descripcion;
                cargarDatos(cod);
            }
        }
        private void cargarDatos(string cod)
        {
            DataTable dt = SqlDatos.leerTablaIniSis("select * from conversion where Cnv_DeMedida='" + cod + "'");
            MALLA.DataSource = dt;
            //accion = "Abrir";
            Bloquear(false);
        }

        private void btnNuevo_Click(System.Object sender, System.EventArgs e)
        {
            Nuevo();
        }
        private void Nuevo()
        {
            //accion = "Nuevo";
            limpiar();
            Bloquear(false);
            cambios = 0;
        }
        private void txtCodigo_LostFocus(object sender, System.EventArgs e)
        {

            cargarDatos(txtCodigo.Text);
        }

        private void btnGuardar_Click(System.Object sender, System.EventArgs e)
        {
            Guardar();
            if (TipoFuera != "")
            {
                this.Close(); this.Dispose();
            }
        }
        private void Guardar()
        {
            if (txtCodigo.Text == "") return;
            guardarSysCod(txtCodigo.Text);
            cancela();
        }
        private void guardarSysCod(string cod)
        {
            Syscod.ClassSyscod  s = new Syscod.ClassSyscod (datosEmpresa.strConIniSis);
            s.TipoReferencia = "Medidas";
            s.Abreviación = txtCodigo.Text;
            s.Descripcion = txtDescripcion.Text;
            s.Actualizar();
            guardarConv(cod);
        }

        private void guardarConv(string cod)
        {
            string ssql = "select * from conversion where Cnv_DeMedida ='" + cod + "'";
            using (SqlDataAdapter da = new SqlDataAdapter(ssql,datosEmpresa.strConIniSis))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach(DataRow row in dt.Rows)
                {
                    row.Delete();
                }
                foreach (DataGridViewRow dgvr in MALLA.Rows)
                {
                    DataRow drow = dt.NewRow();
                    drow["Cnv_Demedida"] = dgvr.Cells["Cnv_DeMedida"].Value;
                    drow["Cnv_Amedida"] = dgvr.Cells["Cnv_AMedida"].Value;
                    drow["Cnv_Multiplo"] = dgvr.Cells["Cnv_Multiplo"].Value;
                    dt.Rows.Add(drow);
                }
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                da.Update(dt);
                dt.AcceptChanges();
            }
        }

        private void btnEliminar_Click(System.Object sender, System.EventArgs e)
        {
            Eliminar(txtCodigo.Text);
            limpiar();
            Bloquear(true);
        }

        private void Eliminar(string cod)
        {
            if (MessageBox.Show ("Esta seguro de que quiere borrar el registro?","Mantenimiento de medidas de artículos", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SqlDatos.ejecutarComandoIniSis("Delete conversion where cnv_demedida = '" + cod + "'");
            }
        }

        private void txtCodigo_TextChanged(System.Object sender, System.EventArgs e)
        {
            cambios += 1;
        }

        private void txtDescripcion_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter & txtCodigo.Text != "")
                cargarDatos(txtCodigo.Text);
        }

        private void txtDescripcion_TextChanged(System.Object sender, System.EventArgs e)
        {
            cambios += 1;
        }

        private void MALLA_CellEnter(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            fila = e.RowIndex;
            columna = e.ColumnIndex;
        }

        private void MALLA_CellValueChanged(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            cambios += 1;
            MALLA.Rows[fila].Cells["CNV_Demedida"].Value = txtCodigo.Text;
        }

        private void btnCancelar_Click(System.Object sender, System.EventArgs e)
        {
            CancelarSalir();
            if (TipoFuera != "")
            {
                this.Close(); this.Dispose();
            }
        }

        private void btnSalir_Click(System.Object sender, System.EventArgs e)
        {
            if (cambios > 0)
            {
                if (MessageBox.Show ("Desea guardar los cambios?","Mantneimiento medidas de artículos", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    Guardar();
            }
            Saliendo();
        }
        private void CancelarSalir()
        {
            if (cambios > 0)
            {
                if (MessageBox.Show("Desea guardar los cambios?", "Mantneimiento medidas de artículos", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    Guardar();
            }
            cancela();
        }
        private void Saliendo()
        {
            this.Close();
            this.Dispose();
        }
        private void cancela()
        {
            limpiar();
            Bloquear(true);
            //accion = "Nuevo";
            cambios = 0;
        }

        private void MALLA_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2 & columna == 1)
            {
                string cod = "";
                string Descripcion = "";
                Syscod.frmBuscarTipoRef busk = new Syscod.frmBuscarTipoRef();
                cod = busk.BuscarTipoRef("MEDIDAS", ref cod, ref Descripcion);
                MALLA.Rows[fila].Cells[columna].Value = cod;
            }
        }

        private void MALLA_MouseLeave(object sender, System.EventArgs e)
        {
            MALLA.EndEdit();
        }
    }
}
