using System;
using System.Windows.Forms;
using ClassDoc;
using DattCom;

namespace BuscadorDocumentos
{
    public partial class BuscDocSoporte : Form
    {
        string claseDoctosPermitidos;
        string CodClienteInicio;
        idDocumento docEscojido = new idDocumento();
        string Bus_tablaDoc = "ADCDOC";
        public BuscDocSoporte(string claseDocts, string ClienteProveedor)
        {
            InitializeComponent();
            claseDoctosPermitidos = claseDocts;
            CodClienteInicio = ClienteProveedor;
            IniciarValores();
        }
        public idDocumento BuscarDocParaRetencion()
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
            cmbBox.DaxCombosDoc(claseDoctosPermitidos, "", false, datosEmpresa.strConxAdcom, ref cboTipoDoc);
            cboTipoDoc.SelectedIndex = 0;

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

            if (cboTipoDoc.SelectedValue == null) return;
            try
            {
                if (cboTipoDoc.SelectedValue.ToString() != "0" && cboTipoDoc.SelectedValue.ToString() != "")
                    Bus_tipDoc = " and opc_documento = '" + cboTipoDoc.SelectedValue.ToString() + "' ";
            }
            catch { }

            try
            {
                if (cboSucursal.SelectedValue.ToString() != "0" && cboSucursal.SelectedValue.ToString() != "")
                    Bus_suc = " and doc_sucursal = '" + cboSucursal.SelectedValue.ToString() + "' ";
            }
            catch { }

            if (txtClienteCod.Text != "")
                Bus_client = " and (doc_codper ='" + txtClienteCod.Text + "' or Doc_CiRuc ='" + txtClienteCod.Text + "') ";


            string ssql = "select doc_sucursal as SUC, opc_documento as TIP";
            ssql += ",doc_fecha as FECHA,doc_numero as NUM,Doc_NombreImp as NOMBRE, doc_valor as VALOR";
            ssql += ",Doc_detalle as DETALLE,doc_codper, idClaveDoc,isnull(estadosri,'') as EstadoSri  from " + Bus_tablaDoc + "";
            ssql += " where doc_fecha >= '" + txtFechaIn.Text + "' and doc_fecha <= '" + txtFechaFin.Text + " 23:59:59' ";
            ssql += Bus_tipDoc + Bus_suc + Bus_client;

            malla.DataSource = SqlDatos.leerTablaAdcom(ssql);

            malla.ClearSelection();
            malla.Columns["doc_codper"].Visible = false;
            malla.Columns["idclavedoc"].Visible = false;
            malla.Columns["fecha"].DefaultCellStyle.Format = "dd/MMM/yyyy";
            malla.Columns["Valor"].DefaultCellStyle.Format = "###,###,###,##0.00";
            malla.Columns["Detalle"].Visible = false;

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
                    Sucursal = (row.Cells["SUC"].Value.ToString()),
                    Tipo = row.Cells["TIP"].Value.ToString(),
                    idClave = Convert.ToDouble(row.Cells["idClaveDoc"].Value.ToString()),
                    numero = Convert.ToDouble(row.Cells["num"].Value.ToString())
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

#pragma warning disable IDE1006 // Estilos de nombres
        private void btnBuscar_Click(object sender, EventArgs e)
#pragma warning restore IDE1006 // Estilos de nombres
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
