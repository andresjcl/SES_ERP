using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DaxInfDefinidos
{
    public partial class frmInfDef : Form
    {
        private bool MallaCambiada = false;
        private bool periodoCerrado = false;
        private string filtro = "";
        daxBuscMalla.frmBuscMall libBuscar;
        public frmInfDef()
        { 
            InitializeComponent();
            cargarSucursales();
            cargarDepartamentos();
            cargarCargos();
        }
        private void cargarPeriodo()
        {
            string ssql = "select per_numero, cast(per_numero as varchar(20))+ ' - ' + per_nombre as Periodo from rolper ";
            ssql += "ORDER BY PER_NUMERO desc";
            DataTable dat = new DataTable();
            SqlDataAdapter datA = new SqlDataAdapter(ssql, varbleComun.VarCom.strConxAdcom);
            datA.Fill(dat);
            cmbPeriodos.DataSource = dat;
            cmbPeriodos.DisplayMember = "Periodo";
            cmbPeriodos.ValueMember = "per_numero";
            datA.Dispose();
            dat.Dispose();
            cmbPeriodos.SelectedIndex = 0;
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            if (clasesBaseDatos.CargarMallaConceptos(MallaDatos, chkactivos.Checked, chkCesantes.Checked, cmbCargo.SelectedValue.ToString(), cmbCargo.SelectedValue.ToString(), txtAnual.Text, ref filtro) == false) return;
            MallaCambiada = false;
            arreglarBotones(false);
        }

        private void arreglarBotones(bool opcion)
        {
            btnAbrir.Enabled = opcion;
            btnCerrar.Enabled = !opcion;

            btnGuardar.Enabled = (opcion == false && periodoCerrado == false);

            Panel1.Enabled = opcion;

            btnReemplazaValor.Enabled = btnGuardar.Enabled;
            btnImportarExcel.Enabled = btnGuardar.Enabled;
        }

        private void btnImportarExcel_Click(object sender, EventArgs e)
        {
            ImporExcel.ImpExcel prog = new ImporExcel.ImpExcel();
            DataTable dt = new DataTable();
            dt = prog.iniciar();

            if (dt == null) return;
            double valor = 0;
            string codigo = "";

            if (dt.Rows.Count < 1) { MessageBox.Show("No existen datos para importar en la tabla de Excel"); return; }
            if (MessageBox.Show("CONFIRMA IMPORTAR LOS NUEVOS VALORES DESDE EXCEL ? \n" + " TODOS LOS VALORES ACTUALES SERÁN ELIMINADOS !!", "Importar datos de excell", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No) return;

            foreach (DataGridViewRow rr in MallaDatos.Rows)
            {
                rr.Cells["liq_Valor"].Value = 0;
            }

            foreach (DataRow dd in dt.Rows)
            {
                try
                {
                    valor = Convert.ToDouble(dd["VALOR"].ToString());
                }
                catch
                {
                    valor = 0;
                }
                if (valor != 0)
                {
                    codigo = dd["Codigo"].ToString();
                    foreach (DataGridViewRow rr in MallaDatos.Rows)
                    {
                        if (codigo == rr.Cells["Codigo"].Value.ToString())
                        {
                            try
                            {
                                rr.Cells["liq_Valor"].Value = valor.ToString();
                            }
                            catch
                            {
                                rr.Cells["liq_Valor"].Value = 0;
                            }
                        }
                    }
                }
            }
            MessageBox.Show("Termino la importación de valores", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            MallaDatos.EndEdit();
            if (!MallaCambiada) return;
            if (MessageBox.Show("Confirma guardar los valores registrados ", "Registrar valores de Impuesto a la renta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No) return;
            if (clasesBaseDatos.guardandoRegistros(MallaDatos, filtro, txtAnual.Text) == false) return;
            MallaCambiada = false;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            MallaDatos.EndEdit();
            if (MallaCambiada == true)
            {
                if (MessageBox.Show("Confirma cerrar los datos actuales, los cambios se perderán", "Cambio valores del rol ", MessageBoxButtons.OK, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                    return;
            }
            MallaDatos.Columns.Clear();
            arreglarBotones(true);

        }

        private void cargarSucursales()
        {
            DaxCbos.DaxCombobx pbox = new DaxCbos.DaxCombobx();
            pbox.DaxCombosSuc(Convert.ToString(varbleComun.VarCom.codEmpresa), true, varbleComun.VarCom.strConxSyscod, ref cmbSucursal);
            //   cmbSucursal.SelectedValue = "0";
        }

        private void cargarDepartamentos()
        {
            DaxCbos.DaxCombobx pbox = new DaxCbos.DaxCombobx();
            pbox.DaxCombosReferencia("Departamento", varbleComun.VarCom.strConxSyscod, ref cmbDepartamento, true);
        }

        private void cargarCargos()
        {
            DaxCbos.DaxCombobx pbox = new DaxCbos.DaxCombobx();
            pbox.DaxCombosReferencia("Cargos", varbleComun.VarCom.strConxSyscod, ref cmbCargo, true);
        }

        private void btnReemplazaValor_Click(object sender, EventArgs e)
        {
            string Valor = inputDialogo.inputDialogo.ingresar("Digite un valor para reemplazar en las filas seleccionadas", "Registro de novedades", "");
            int i = 0;
            if (Valor.Length == 0) return;
            foreach (DataGridViewCell cell in MallaDatos.SelectedCells)
            {
                cell.Value = Valor;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Panel1.Visible = !Panel1.Visible;
        }

        private void MallaDatos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            MallaCambiada = true;
            MallaDatos.Rows[e.RowIndex].Cells["st"].Value = 1;
        }


        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MallaCambiada)
            { if (MessageBox.Show("Confirma salir del proceso los valores cambiados se perderan ", "Registrar valores de Impuesto a la renta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No) return; }
            Close();
            Dispose();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.MallaDatos.DataError -= new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.MallaDatos_DataError);
            libBuscar = new daxBuscMalla.frmBuscMall(MallaDatos, true, false);
            libBuscar.ShowDialog();
            this.MallaDatos.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.MallaDatos_DataError);
        }

        private void MallaDatos_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("El tipo de datos registrado no es correcto");
        }

        private void btnProximo_Click(object sender, EventArgs e)
        {
            this.MallaDatos.DataError -= new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.MallaDatos_DataError);
            libBuscar.buscaProxima();
            this.MallaDatos.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.MallaDatos_DataError);
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            SalidasDeMalla.enviandoMalla envia = new SalidasDeMalla.enviandoMalla(MallaDatos,"Datos Impuesto a la Renta",varbleComun.VarCom.nomEmpresa);
            envia.ShowDialog();
            envia.Dispose();
        }

        private void frmInfDef_Load(object sender, EventArgs e)
        {

        }

        private void btnEnviar_Click_1(object sender, EventArgs e)
        {

        }
    }
}
