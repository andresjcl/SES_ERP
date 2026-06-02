using System;
using System.Windows.Forms;
using ClassDoc;
using DattCom;

namespace BuscadorDocumentos
{
    public partial class BuscCajaChica : Form
    {
        string claseDoctosPermitidos;
        string CodClienteInicio;
        idDocumento docEscojido = new idDocumento();
        public BuscCajaChica(string claseDocts, string ClienteProveedor)
        {
            InitializeComponent();
            claseDoctosPermitidos = claseDocts;
            CodClienteInicio = ClienteProveedor;
            IniciarValores();
        }
        public idDocumento BuscarDocCajaChica()
        {
            this.ShowDialog();
            return docEscojido;
        }
        private void IniciarValores()
        {
            txtFechaIn.Value = new DateTime(txtFechaFin.Value.Year, txtFechaFin.Value.Month, 1);
            DaxCombobx.CargCmbBox cmbBox = new DaxCombobx.CargCmbBox();
            cmbBox.DaxCombosSuc(datosEmpresa.Emp_codigo.ToString(), true, datosEmpresa.strConIniSis, ref cboSucursal);
            cboSucursal.SelectedIndex = 0;

            if (CodClienteInicio.Length > 0)
            {
                txtClienteCod.Text = CodClienteInicio;
                EmpNomR.AdcNomb prog = new EmpNomR.AdcNomb();
                txtClienteNombre.Text = prog.RetornaNombreDirectorio(CodClienteInicio, datosEmpresa.strConxAdcom);
            }
            CargarMalla();
        }
        private void CargarMalla()
        {
            string Bus_suc = "";
            string Bus_client = "";
            string Bus_tipDoc = "";

            try
            {
                if (cboSucursal.SelectedValue.ToString() != "0" && cboSucursal.SelectedValue.ToString() != "")
                    Bus_suc = " and sucursal = '" + cboSucursal.SelectedValue.ToString() + "' ";
            }
            catch { }

            if (txtClienteCod.Text != "")
                Bus_client = " and (responsable ='" + txtClienteCod.Text + "') ";


            string ssql = "select Sucursal,FechaLiq as FECHA,NroLiquidacion as NUM,NombreImpresion as NOMBRE ";
            ssql += "from DaxLiqCajChica left join identificacion on codigo = responsable ";

            ssql += "  where isnull(nrolinea,0) < 2 and fechaliq >= '" + txtFechaIn.Text + "' and fechaliq <= '" + txtFechaFin.Text + " 23:59:59' ";
            ssql += Bus_tipDoc + Bus_suc + Bus_client;

            malla.DataSource = SqlDatos.leerTablaAdcom(ssql);

            malla.ClearSelection();
            //malla.Columns["doc_codper"].Visible = false;
            //malla.Columns["idclavedoc"].Visible = false;
            malla.Columns["fecha"].DefaultCellStyle.Format = "dd/MMM/yyyy";
            //malla.Columns["Valor"].DefaultCellStyle.Format = "###,###,###,##0.00";
            //malla.Columns["Detalle"].Visible = false;

        }

        private void malla_DoubleClick(object sender, EventArgs e)
        {
            SalirBusqueda();
        }
        private void SalirBusqueda()
        {
            if (malla.CurrentRow == null) return;
            try
            {
                DataGridViewRow row = malla.CurrentRow;
                docEscojido = new idDocumento
                {
                    Sucursal = (row.Cells["Sucursal"].Value.ToString()),
                    Tipo = "",
                    idClave = 0,
                    numero = Convert.ToDouble("0"+row.Cells["Num"].Value.ToString())
                };
                row.Dispose();
            }
            catch { }
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (malla.CurrentRow == null)
            {
                MessageBox.Show("Escoja un documento para aceptar ");
                return;
            }
            SalirBusqueda();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarMalla();
        }

        private void cboSucursal_SelectedValueChanged(object sender, EventArgs e)
        {
            btnBuscar.Select();
        }

        private void txtFechaFin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return) CargarMalla();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
