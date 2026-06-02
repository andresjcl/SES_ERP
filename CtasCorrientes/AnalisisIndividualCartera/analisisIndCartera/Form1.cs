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

namespace analisisIndCart
{
    public partial class Form1 : Form
    {
        string strConxDaxCon = "";
        AdcDax.DaxSofSys SYSEMP = new AdcDax.DaxSofSys();
        DaxLib.DaxLibBases dxlib = new DaxLib.DaxLibBases();
        string tit1 = "";
        string tit2 = "";

        public Form1()
        {
            InitializeComponent();
            prepararOpciones();
        }

        private void prepararOpciones()
        {

            dtInicio.Value = new DateTime(DateTime.Now.Year, 1, 1);
            dtFinal.Value = DateTime.Now;
            cmbTipoDocumentos.Items.Add("CUENTAS POR COBRAR CLIENTES");
            cmbTipoDocumentos.Items.Add("CUENTAS POR PAGAR PROVEEDORES");
            cmbTipoDocumentos.Items.Add("CTAS.COBRAR Y CTAS.PAGAR");

            cmbTipoDocumentos.SelectedIndex = 0;

            dxlib.TipoBase = "10";
            strConxDaxCon = dxlib.StrAdcom();
            if (strConxDaxCon.IndexOf("server=;") > -1) this.Close();

        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            CargarMalla();
        }
        private void CargarMalla()
        {
            string conAnticipos = "0";
            string conGarantias = "0";
            string conPostfechados = "0";
            string StrSigno = "";
            string Movimiento = "0";

            if (cmbTipoDocumentos.SelectedIndex == 0) StrSigno = "C";
            if (cmbTipoDocumentos.SelectedIndex == 1) StrSigno = "P";

            if (cmbTipoDocumentos.Text.Length == 0) { MessageBox.Show("Seleccione el tipo de documentos a emitir", "Analisis individual decartera", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (txtCodigo.Text.Length == 0) { MessageBox.Show("Seleccione el cliente o el proveedor que desea consultar", "Analisis individual decartera", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            if (rbMovimientos.Checked) 
            {
                Movimiento = "1";
            }
            else
            {
                dtInicio.Value = Convert.ToDateTime("01/01/1900");
            }

            if (dtInicio.Value > dtFinal.Value ) {MessageBox.Show("Las fechas del perído de consulta están erradas", "Analisis individual decartera", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }


            string ssql = "ADC_CCIND '" + txtCodigo.Text + "','" + dtInicio.Text + "','" + dtFinal.Text  + "'," + conAnticipos + "," + conGarantias + "," + Movimiento + ",'" + StrSigno + "','" + textNroLote.Text + "'," + conPostfechados + ",'','',0";
            
            SqlDataAdapter da = new SqlDataAdapter(ssql,strConxDaxCon );
            DataTable dt = new DataTable();
            da.Fill(dt);
            mallaDatos.DataSource = dt;
            diseñarMalla();
        }

        private void ImprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mallaDatos.RowCount == 0) return;
            DataGridViewPrinterApplication1.frmMain imp = new DataGridViewPrinterApplication1.frmMain();
            preparaTitulo();
            imp.imprimir(mallaDatos, tit1, tit2, SYSEMP.EmpresaAct.nombre);
        }

        private void WordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mallaDatos.RowCount == 0) return;
            ExportarGrid.Form1 exp = new ExportarGrid.Form1();
            preparaTitulo();
            exp.Exportar(mallaDatos, "W", SYSEMP.EmpresaAct.nombre, tit1 + "\r\n" + tit2);
        }

        private void ExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mallaDatos.RowCount == 0) return;
            ExportarGrid.Form1 exp = new ExportarGrid.Form1();
            preparaTitulo();
            exp.Exportar(mallaDatos, "E", SYSEMP.EmpresaAct.nombre, tit1 + "\r\n" + tit2);
        }

        private void PDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mallaDatos.RowCount == 0) return;
            ExportarGrid.Form1 exp = new ExportarGrid.Form1();
            preparaTitulo();
            exp.Exportar(mallaDatos, "P", SYSEMP.EmpresaAct.nombre, tit1 + "\r\n" + tit2);
        }

        private void preparaTitulo()
        {
            //tit2 = "Del: " + txtFechaIni.Text + " Al: " + txtFechaFin.Text;
            //tit1 = "Analisis facturas y retenciones : ";
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void diseñarMalla()
        {

            string formato = "#,#0.00;-#,#0.00;\"\";";

            mallaDatos.Columns["Valor"].DefaultCellStyle.Format = formato;
            mallaDatos.Columns["Valor"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            mallaDatos.Columns["ValorAbonos"].DefaultCellStyle.Format = formato;
            mallaDatos.Columns["ValorAbonos"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            mallaDatos.Columns["Contado"].DefaultCellStyle.Format = formato;
            mallaDatos.Columns["Contado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            mallaDatos.Columns["Saldo"].DefaultCellStyle.Format = formato;
            mallaDatos.Columns["Saldo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            mallaDatos.Columns["Saldo"].HeaderText  = "SaldoFecha";

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
                totValor  += Convert.ToDouble(row.Cells["Valor"].Value );
                totContado += Convert.ToDouble(row.Cells["Contado"].Value );
                totAbonos  += Convert.ToDouble(row.Cells["ValorAbonos"].Value );
                totSaldo += Convert.ToDouble(row.Cells["Saldo"].Value );
            }
                labValor.Text = string.Format(formato, totValor);
                labContado.Text = string.Format(formato, totContado);
                labAbonos.Text = string.Format(formato, totAbonos);
                labSaldo.Text = string.Format(formato, totSaldo);
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
            MantenimientoDirectorio.BuscaClien BUSCADOR = new MantenimientoDirectorio.BuscaClien();
            codigo = BUSCADOR.IniBuscaCliOPro(ref  tipo, ref  nombre, ref alias, ref nuevo) + "";
            txtCodigo.Text = codigo;
            if (codigo.Length > 0) { label2.Text = nombre; }
            if (label2.Text == "") { MessageBox.Show("No existe el código digitado"); txtCodigo.Text = ""; return;}
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
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {

        }

        private void btnAplicaciones_Click(object sender, EventArgs e)
        {
            Int32 fila = 0;
            try
            {
            DataGridViewCell celda = mallaDatos.CurrentCell;
                fila=celda.RowIndex;
                
            }
            catch 
            {
                MessageBox.Show("Seleccione una celda en la malla para la consulta");
                return ;
            }

            double idclave = Convert.ToDouble(mallaDatos.Rows[fila].Cells["idClaveDoc"].Value);
            string claseDoc = Convert.ToString(mallaDatos.Rows[fila].Cells["doc_TipoDoc"].Value);
            string tipoDoc = Convert.ToString(mallaDatos.Rows[fila].Cells["TIP"].Value);
            string controlaSig = Convert.ToString(mallaDatos.Rows[fila].Cells["SIGNO"].Value);
            long Numero = Convert.ToInt64(mallaDatos.Rows[fila].Cells["Numero"].Value);
            double Contado = Convert.ToDouble (mallaDatos.Rows[fila].Cells["Contado"].Value) * Convert.ToInt32(controlaSig) ;
            int posicion = 6;
            string sucursal = Convert.ToString(mallaDatos.Rows[fila].Cells["SUC"].Value);

            if (Convert.ToInt32(controlaSig) == -1) controlaSig = "0"; else controlaSig = "1";
            if (claseDoc == "FAP") 
            {
                controlaSig = "1";
                posicion = 7;
            }
                        
            Form2 prog = new Form2( strConxDaxCon,idclave,tipoDoc,Numero,Contado,dtFinal.Text,controlaSig,posicion,sucursal);    
            prog.ShowDialog();
        }

        private void mallaDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
