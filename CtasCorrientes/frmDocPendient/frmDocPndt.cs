using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassDoc;
using DattCom;

namespace DocPendientes
{
    public partial class frmDocPndt : Form
    {
        string dtInicio;
        string dtFinal;
        double ValorAaplicar = 0;
        bool esProveedor = false;
        bool esSoloConsulta = false;
        string QueCliente = "";
        idDocumento QueIdDocumento = new idDocumento();
        ListDocAplican listDocAplicados = new ListDocAplican();

        public frmDocPndt(ListDocAplican listaDocApl, string CodCliente , string NombCli,idDocumento IdDoc,string NroLote,double ValorAplica,string TipoCuenta, bool Consulta, DateTime FecIni, DateTime FecFin)
        {
            InitializeComponent();
            QueIdDocumento = IdDoc;
            QueCliente = CodCliente;
            txtNroLote.Text = NroLote;
            ValorAaplicar = ValorAplica;
            listDocAplicados = listaDocApl;
            esSoloConsulta = Consulta;

            if (CodCliente.Length > 0)
            {
                listDocAplicados = listaDocApl;
            }
            esProveedor = (TipoCuenta.ToUpper() == "P");

            prepararOpciones(FecIni.ToShortDateString(), FecFin.ToShortDateString());
        }
        public ListDocAplican iniciarDocsPendientes()
        {
            this.ShowDialog();
            return listDocAplicados;
        }
        private void prepararOpciones(string fecIni, string fecFin)
        {
            ClassDoc.idDocumento id = new ClassDoc.idDocumento();
            
            dtInicio = fecIni;
            dtFinal = fecFin;
            if (esProveedor) chkCliente.Checked = false;
            if (esProveedor) chkProveedor.Checked = true;
            if (esSoloConsulta)
            {
                label4.Visible = false;
                txtValorAplicado.Visible = false;
                txtValorPorAplicar.Visible = false;
                label2.Visible = false;
                btnAplicarValor.Visible = false;
                btnBorraAplicar.Visible = false;

            }
            txtValorAplicado.Text = "0";
            txtValorPorAplicar.Text = "0";
            txtValorPorAplicar.Text = "0";
            CargarDocumentos();
        }
        private void TotalizarAplicacion()
        {
            double totalAbono = 0;
//            double totalSaldo = 0;
            foreach (DataGridViewRow row in Malla.Rows)
            {
                try
                {
                    totalAbono += Convert.ToDouble( row.Cells["Abono"].Value);
                }
                catch { }
                //string aux = "0";
                //if (row.Cells["SaldoAct"].Value!= null) aux = row.Cells["SaldoAct"].Value.ToString().Trim();
                //totalSaldo += Convert.ToDouble(aux);
            }
            txtValorAplicado.Text = totalAbono.ToString("##0.00");
//            txtTotalPendiente.Text = totalSaldo.ToString("##0.00");
        }
        private void TotalizarValorPendiente()
        {
            double totalSaldo = 0;
            foreach (DataGridViewRow row in Malla.Rows)
            {
//                totalAbono += Convert.ToDouble("0" + row.Cells["Abono"].Value);
                string aux = "0";
                if (row.Cells["SaldoAct"].Value != null) aux = row.Cells["SaldoAct"].Value.ToString().Trim();
                totalSaldo += Convert.ToDouble(aux);
            }
//            txtValorAplicado.Text = totalAbono.ToString("##0.00");
            txtTotalPendiente.Text = totalSaldo.ToString("##0.00");
        }
        private void Malla_CellEndEdit(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            int col = e.ColumnIndex;
            {
                double Abono = 0;
                    try { Convert.ToDouble("0" + Malla.Rows[row].Cells["Abono"].ToString()); } catch { }
                if (Malla.Rows[row].Cells["SUC"].ToString() != datosEmpresa.sucursal && Abono > 0 && datosEmpresa.PermiteCruceDocSucursal == false)
                {
                    MessageBox.Show("No se puede afectar a un documento de otra sucursal", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Malla.Rows[row].Cells["Abono"].Value = 0;
                }
                else
                //{ datosCambiados = true; }
                TotalizarAplicacion();
            }
        }

        private void Malla_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            try
            {
                int roww = Malla.CurrentCell.RowIndex;
                int coll = Malla.CurrentCell.ColumnIndex;
                if (e.KeyCode == Keys.F2 & Malla.Rows[roww].Cells["SaldoAct"].ToString().Length > 0)
                    Malla.Rows[roww].Cells["Abono"].Value = Math.Abs(System.Convert.ToDouble(Malla.Rows[roww].Cells["SaldoAct"].Value)).ToString("#0.00");
                else if (e.KeyCode == Keys.F8)
                {
                    daxcalc.Calcula calculadora = new daxcalc.Calcula();
                    Malla.Rows[roww].Cells["Abono"].Value = System.Convert.ToString(calculadora.valor);
                }
            }
            catch
            {
            }
        }
        private void TxtValort_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            string dato = "";
            if (e.KeyCode == Keys.F8)
            {
                daxcalc.Calcula calculadora = new daxcalc.Calcula();
                dato = System.Convert.ToString(calculadora.valor);
            }
            else if (e.KeyCode == Keys.F3 & txtValorPorAplicar.Text.Length > 1) RepartirValor();
            TotalizarAplicacion();
        }

        private void RepartirValor()
        {
            double porRepartir = Convert.ToDouble("0" + txtValorPorAplicar.Text.Trim());
            if (porRepartir > Convert.ToDouble ( txtTotalPendiente.Text)) { MessageBox.Show("El valor a repartir supera el valor de los saldos pendientes"); return; }
            WaitMensaje.WMensaje.verMensaje("Calculando valor a aplicar por documento");
            Datos.RepartirValor(porRepartir, Malla);
            TotalizarAplicacion();
            WaitMensaje.WMensaje.cierraMensaje();
        }

        private void btnAplicarValor_Click(object sender, EventArgs e)
        {
            RepartirValor();
        }
        private void Malla_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            Malla.EndEdit();
        }
        private void CargarDocumentos()
        {
            if (Convert.ToDouble(txtValorAplicado.Text) > 0)
            { if (MessageBox.Show("Confirma recargar los datos actuales ?, las aplicaciones digitadas se perderán ", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;}
            WaitMensaje.WMensaje.verMensaje ("Cargando cuentas pendientes");
            Datos.CargarDocumentos(listDocAplicados, Malla, esProveedor, QueCliente, QueIdDocumento, txtNroLote.Text, chkCliente.Checked, chkProveedor.Checked, chkAnticipo.Checked);
            if (esSoloConsulta) Malla.Columns["Abono"].Visible = false;
            TotalizarValorPendiente();
            WaitMensaje.WMensaje.cierraMensaje();
        }

        private void Malla_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Dato registrado erróneo, digite nuevamente");
        }

        private void btnAceptar_Click(System.Object sender, System.EventArgs e)
        {
            Malla.EndEdit();
            TotalizarAplicacion();
            if (Convert.ToDouble(txtValorAplicado.Text) > Convert.ToDouble(txtValorPorAplicar.Text) & Convert.ToDouble(txtValorPorAplicar.Text) > 0)
            {
                MessageBox.Show("El valor de las aplicaciones es mayor al valor disponible \n No puede registrarse el movimiento","", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            foreach  (DataGridViewRow mrow in Malla.Rows)
            {
                double Abono = Convert.ToDouble("0"+mrow.Cells["Abono"].Value);
                if (Abono != 0)
                {
                    DocAplica campos = new DocAplica();
                    campos.ValorCruce = Abono;
                    campos.Sucursal = mrow.Cells["SUC"].Value.ToString();
                    campos.TipoDoc = mrow.Cells["TIP"].Value.ToString();
                    campos.Numero  = mrow.Cells["Numero"].Value.ToString();
                    campos.IdClaveDoc = Convert.ToDouble("0" + mrow.Cells["IdClaveDoc"].Value);
                    campos.CodigoCliente = mrow.Cells["doc_codper"].Value.ToString();
                    campos.fechaDocumento = mrow.Cells["Fecha"].Value.ToString();
                    campos.Nombre = mrow.Cells["Nombre"].Value.ToString();
                    listDocAplicados.ListaDocAplican.Add(campos);
                }
            }
            this.Close();
        }

        private void btnBorraAplicar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("El valor de las aplicaciones es mayor al valor disponible \n No puede registrarse el movimiento", "", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.No ) return;
            foreach  (DataGridViewRow mrow in Malla.Rows)
            {
                mrow.Cells["Abono"].Value = 0;
            }
            txtValorAplicado.Text = "0";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            listDocAplicados = new ListDocAplican();
            this.Close();
        }

        private void chkCliente_CheckedChanged(object sender, EventArgs e)
        {
            CargarDocumentos();
        }
        private void btnActualiza_Click(object sender, EventArgs e)
        {
            CargarDocumentos();
        }

        private void Malla_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
