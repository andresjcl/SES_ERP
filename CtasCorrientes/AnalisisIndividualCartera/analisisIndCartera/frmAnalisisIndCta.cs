using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using DattCom;

namespace CtasCorrientes
{
    public partial class frmAnalisisIndCta : Form
    {
        string tit1 = "";
        string tit2 = "";
        //string codigoCliente = "";
        //Boolean consultandoDeFuera = false;        

        public frmAnalisisIndCta(string codCli="",string fecIni = "",string fecFin = "", string tipoCta="")
        {
            InitializeComponent();
            prepararOpciones(codCli,fecIni,fecFin,tipoCta);
            botones();
        }

        private void prepararOpciones(string codCli, string fecIni, string fecFin,string tipoCtas)
        {

            dtInicio.Value = new DateTime(DateTime.Now.Year, 1, 1);
            dtFinal.Value = DateTime.Now;

            cmbTipoDocumentos.Items.Add("CUENTAS POR COBRAR CLIENTES");
            cmbTipoDocumentos.Items.Add("CUENTAS POR COBRAR CLIENTE FINAL");
            cmbTipoDocumentos.Items.Add("CUENTAS POR PAGAR PROVEEDORES");
            cmbTipoDocumentos.Items.Add("CTAS.COBRAR Y CTAS.PAGAR");
            cmbTipoDocumentos.Items.Add("CTAS.COBRAR Y CTAS.PAGAR CLIENTE.FINAL");

            cmbTipoDocumentos.SelectedIndex = 0;

            if (codCli != "")
            {
                if (tipoCtas == "P")
                {
                    cmbTipoDocumentos.SelectedIndex = 2;
                }
//                consultandoDeFuera = true;
                try
                {
                    dtInicio.Value = Convert.ToDateTime(fecIni);
                    dtFinal.Value = Convert.ToDateTime(fecFin);
                }
                catch { };
                txtCodigo.Text = codCli;
            }
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            CargarMalla();
        }
        private void btnEstadoCta_Click(object sender, EventArgs e)
        {
            estadoDeCuenta();
        }
        private void CargarMalla()
        {
            string ssql = "ADC_CCIND " + stringCOnsulta();
            if (queOpcion() == "F" || queOpcion() == "T") ssql = "ADC_CCINDFIN " + stringCOnsulta();
            SqlDataAdapter da = new SqlDataAdapter(ssql, datosEmpresa.strConxAdcom);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dt.Rows.Add();
            dt.Rows.Add();
            mallaDatos.DataSource = dt;
            diseñarMalla();
            botones();
        }
        private void estadoDeCuenta()
        {
            datoReporte.ssql = "ADC_STDCTA " + stringCOnsulta();
            if (queOpcion() == "F" || queOpcion() == "T") datoReporte.ssql = "ADC_STDCTAFIN " + stringCOnsulta();
            datoReporte.Disponible = 0;
            if (dtInicio.Value < datosEmpresa.UltimoCierreAnual)
            {
                datoReporte.fechaDesde = datosEmpresa.UltimoCierreAnual.ToShortDateString();
            }
            else
            {
                datoReporte.fechaDesde = dtInicio.Text;
            }
            datoReporte.fechaSaldo = dtFinal.Text;
            datoReporte.limiteCredito = 0;
            datoReporte.nombreEmpresa = datosEmpresa.Emp_Nombre;
            datoReporte.saldo =0;
            datoReporte.telefono = " ";
            datoReporte.cliente = label2.Text;
            datoReporte.direccion = " ";

            frmVerEstdoCta prog = new frmVerEstdoCta(datosEmpresa.pathAppl, datosEmpresa.strConxAdcom);
            prog.ShowDialog();
        }

        private string stringCOnsulta ()
        {
            string conAnticipos = "0";
            string conGarantias = "0";
            string conPostfechados = "0";
            string StrSigno = "";
            string Movimiento = "0";
            string fechaIni=dtInicio.Text;

            if (fechaIni == "") fechaIni = "01/01/1900";

            StrSigno = queOpcion();
            if (StrSigno == "F") StrSigno = "C";
            if (StrSigno == "T") StrSigno = "";

            if (cmbTipoDocumentos.Text.Length == 0) { MessageBox.Show("Seleccione el tipo de documentos a emitir", "Analisis individual de cartera", MessageBoxButtons.OK, MessageBoxIcon.Error); return ""; }
            if (txtCodigo.Text.Length == 0) { MessageBox.Show("Seleccione el cliente o el proveedor que desea consultar", "Analisis individual de cartera", MessageBoxButtons.OK, MessageBoxIcon.Error); return ""; }

            if (rbMovimientos.Checked)
            {
                Movimiento = "1";
                if (fechaIni == "") fechaIni = dtInicio.Text;
            }
            else
            {             
                fechaIni = "01/01/1900";
            }

            if (verAnticipos.Checked) conAnticipos = "1";
            if (dtFinal.Text == "") dtFinal.Value = DateTime.Now;
            dtInicio.Value = Convert.ToDateTime(fechaIni);
            if (dtInicio.Value > dtFinal.Value) { MessageBox.Show("Las fechas del perído de consulta están erradas", "Analisis individual de cartera", MessageBoxButtons.OK, MessageBoxIcon.Error); return ""; }
            return "'" + txtCodigo.Text + "','" + fechaIni + "','" + dtFinal.Text + "'," + conAnticipos + "," + conGarantias + "," + Movimiento + ",'" + StrSigno + "','" + textNroLote.Text + "'," + conPostfechados + ",'','',0";
        }
        private string  queOpcion()
        {
            if (cmbTipoDocumentos.SelectedIndex == 1) return "F";
            if (cmbTipoDocumentos.SelectedIndex == 2) return "P";
            if (cmbTipoDocumentos.SelectedIndex == 3) return "T";
            if (cmbTipoDocumentos.SelectedIndex == 4) return "";
            return "C";
        }
        private void ImprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mallaDatos.RowCount == 0) return;
            DataGridViewPrinterApplication1.frmMain imp = new DataGridViewPrinterApplication1.frmMain();
            preparaTitulo();
            imp.imprimir(mallaDatos, tit1, tit2, datosEmpresa.Emp_Nombre);
            CargarMalla();
        }

        private void WordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mallaDatos.RowCount == 0) return;
            mallExp.Form1 exp = new mallExp.Form1();
            preparaTitulo();
            exp.Exportar(mallaDatos, "W", datosEmpresa.Emp_Nombre, tit1 + "\r\n" + tit2);
            CargarMalla();
        }

        private void ExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mallaDatos.RowCount == 0) return;
            mallExp.Form1 exp = new mallExp.Form1();
            preparaTitulo();
            exp.Exportar(mallaDatos, "E", datosEmpresa.Emp_Nombre, tit1);
            CargarMalla();
        }

        private void PDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mallaDatos.RowCount == 0) return;
            mallExp.Form1 exp = new mallExp.Form1();
            preparaTitulo();
            exp.Exportar(mallaDatos, "P", datosEmpresa.Emp_Nombre, tit1 + "\r\n" + tit2);
            CargarMalla();
        }

        private void preparaTitulo()
        {
            //'tit2 = "Del: " + txtFechaIni.Text + " Al: " + txtFechaFin.Text
            tit1 = "Estado de cuenta de : " + label2.Text + " al " + dtFinal.Text;
            totalesImpresion();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void diseñarMalla()
        {

            string formato = "#,#0.00;-#,#0.00;\"\";";

            mallaDatos.Columns["ValorAbonos"].HeaderText = "Abonos";
            mallaDatos.Columns["FechaVence"].HeaderText = "Vence";
            mallaDatos.Columns["SUC"].HeaderText = "Suc";
            mallaDatos.Columns["TIP"].HeaderText = "Doc";            

            mallaDatos.Columns["Valor"].DefaultCellStyle.Format = formato;
            mallaDatos.Columns["Valor"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            mallaDatos.Columns["ValorAbonos"].DefaultCellStyle.Format = formato;
            mallaDatos.Columns["ValorAbonos"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            mallaDatos.Columns["Contado"].DefaultCellStyle.Format = formato;
            mallaDatos.Columns["Contado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            mallaDatos.Columns["Saldo"].DefaultCellStyle.Format = formato;
            mallaDatos.Columns["Saldo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //mallaDatos.Columns["Saldo"].HeaderText  = "SaldoFecha";

            
            mallaDatos.Columns["Doc_nombreImp"].Visible=false;
            mallaDatos.Columns["Doc_TipoDoc"].Visible=false;
            mallaDatos.Columns["signo"].Visible=false;
            mallaDatos.Columns["Gar"].Visible=false;
            mallaDatos.Columns["doc_codper"].Visible=false;
            mallaDatos.Columns["IdClaveDoc"].Visible=false;
            mallaDatos.Columns["doc_venabre"].Visible = false;
            mallaDatos.Columns["NroLote"].Visible = false;

            reubicarTotales();
            sumarTotales();
        }

        private void reubicarTotales()
        {
            if (mallaDatos.Columns["Valor"].Displayed == true) labValor.Width = mallaDatos.Columns["Valor"].Width - 1;
            if (mallaDatos.Columns["Contado"].Displayed == true) labContado.Width = mallaDatos.Columns["Contado"].Width - 1;
            if (mallaDatos.Columns["ValorAbonos"].Displayed == true) labAbonos.Width = mallaDatos.Columns["ValorAbonos"].Width - 1;
            if (mallaDatos.Columns["Saldo"].Displayed == true) labSaldo.Width = mallaDatos.Columns["Saldo"].Width - 1;

            Int32 separacion = mallaDatos.Left;
            separacion = Convert.ToInt32( mallaDatos.RowHeadersWidth);
            separacion += mallaDatos.Columns["Suc"].Width + mallaDatos.Columns["Tip"].Width + mallaDatos.Columns["Numero"].Width + mallaDatos.Columns["Fecha"].Width + mallaDatos.Columns["FechaVence"].Width;

            labValor.Left = separacion + 1 ;
            labContado.Left = labValor.Left + 1 + labValor.Width ;
            labAbonos.Left = labContado.Left + 1 + labContado.Width;
            labSaldo.Left = labAbonos.Left + 1 + labAbonos.Width;
        }
        
        private void sumarTotales()
        {
            string formato = "{0:0.00}";
            double totValor = 0;
            double totContado = 0;
            double totAbonos = 0;
            double totSaldo = 0;

            foreach (DataGridViewRow row in mallaDatos.Rows)
            {
                if (row.Cells["Doc_TipoDoc"] != null && row.Cells["Doc_TipoDoc"].Value.ToString().Length > 0)
                {
                    totValor += Convert.ToDouble(row.Cells["Valor"].Value);
                    totContado += Convert.ToDouble(row.Cells["Contado"].Value);
                    totAbonos += Convert.ToDouble(row.Cells["ValorAbonos"].Value);
                    totSaldo += Convert.ToDouble(row.Cells["Saldo"].Value);
                }
            }
                labValor.Text = string.Format(formato, totValor);
                labContado.Text = string.Format(formato, totContado);
                labAbonos.Text = string.Format(formato, totAbonos);
                labSaldo.Text = string.Format(formato, totSaldo);
        }

        private void totalesImpresion()
        {
            double totValor = 0;
            double totContado = 0;
            double totAbonos = 0;
            double totSaldo = 0;
            
            foreach (DataGridViewRow row in mallaDatos.Rows)
            {
                if (row.Cells["Doc_TipoDoc"] != null && row.Cells["Doc_TipoDoc"].Value.ToString().Length > 0)
                {
                    totValor += Convert.ToDouble(row.Cells["Valor"].Value);
                    totContado += Convert.ToDouble(row.Cells["Contado"].Value);
                    totAbonos += Convert.ToDouble(row.Cells["ValorAbonos"].Value);
                    totSaldo += Convert.ToDouble(row.Cells["Saldo"].Value);
                }
            }
            DataGridViewRow rown = mallaDatos.Rows[mallaDatos.Rows.Count-1];
            rown.Cells["Valor"].Value = totValor;
            rown.Cells["Contado"].Value = totContado;
            rown.Cells["ValorAbonos"].Value = totAbonos;
            rown.Cells["Saldo"].Value = totSaldo;
        }
        private void limpiarMalla()
        {
            mallaDatos.Columns.Clear();
        }

        private void btnCodigoEmpleado_Click(object sender, EventArgs e)
        {
            limpiarMalla();
            string codigo = "";
            string nombre = "";
            string tipo = "T";
            string alias = "N";
            string nuevo = "N";
            directMnt.BuscaClien BUSCADOR = new directMnt.BuscaClien();
            codigo = BUSCADOR.IniBuscaCliOPro(ref  tipo, ref  nombre, ref alias, ref nuevo) + "";
            txtCodigo.Text = codigo;
            if (codigo.Length > 0) { label2.Text = nombre; }
            if (label2.Text == "") { classMenSistem.mensajesErrorDocumento.codigoContactoNoExiste("contacto"); txtCodigo.Text = ""; return;}
            BUSCADOR = null;
            if (txtCodigo.Text.Length > 0) CargarMalla();
        }
        private void taparFechaInicio()
        {
            if (rbSaldos.Checked) { label5.Visible = false; dtInicio.Visible = false; }
            else { label5.Visible = true; dtInicio.Visible = true;  }
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            limpiarMalla();
            taparFechaInicio();
            botones();
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            
        }

        private void btnAplicaciones_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            try
            {
                row = mallaDatos.CurrentRow;
            }
            catch 
            {
                MessageBox.Show("Seleccione una fila en la malla para la consulta");
                return ;
            }

            double idclave = Convert.ToDouble(row.Cells["idClaveDoc"].Value);
            string claseDoc = Convert.ToString(row.Cells["doc_TipoDoc"].Value);
            string tipoDoc = Convert.ToString(row.Cells["TIP"].Value);
            string controlaSig = Convert.ToString(row.Cells["SIGNO"].Value);
            long Numero = Convert.ToInt64(row.Cells["Numero"].Value);
            double Contado = Convert.ToDouble (row.Cells["Contado"].Value) * Convert.ToInt32(controlaSig) ;
            int posicion = 6;
            string sucursal = Convert.ToString(row.Cells["SUC"].Value);

            if (Convert.ToInt32(controlaSig) == -1) controlaSig = "0"; else controlaSig = "1";
            if (claseDoc == "FAP") 
            {
                controlaSig = "1";
                posicion = 7;
            }
                        
            frmAplicacionesDcto prog = new frmAplicacionesDcto(datosEmpresa.strConxAdcom, idclave,tipoDoc,Numero,Contado,dtFinal.Text,controlaSig,posicion,sucursal);    
            prog.ShowDialog();
        }

        private void mallaDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                if (cargarCliente()) CargarMalla();
            }
        }
        private Boolean cargarCliente()
        {
            EmpNomR.AdcNomb rn = new EmpNomR.AdcNomb();
            string nom = rn.RetornaNombreDirectorio(txtCodigo.Text, datosEmpresa.strConxAdcom);
            if (nom == "")
            {
                classMenSistem.mensajesErrorDocumento.codigoContactoNoExiste("contacto");
                txtCodigo.Text = "";
                label2.Text = "";
                return false;
            }
            label2.Text = nom;
            rn = null;
            return true;
        }

        private void frmAnalisisIndCta_Load(object sender, EventArgs e)
        {

            if (txtCodigo.Text !="") if (cargarCliente()) CargarMalla();            
        }
        private void botones()
        {
            btnEnviar.Enabled = (mallaDatos.Rows.Count > 0);
            btnProcesar.Enabled = (txtCodigo.Text.Length != 0 && label2.Text.Length != 0);
            btnAplicaciones.Enabled = (mallaDatos.CurrentRow!=null);
            btnEstadoCta.Enabled = (btnProcesar.Enabled && rbMovimientos.Checked==true);
        }

        private void btnEnviar_ButtonClick(object sender, EventArgs e)
        {

        }

        private void cmbTipoDocumentos_Click(object sender, EventArgs e)
        {

        }

    }
}
