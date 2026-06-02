using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace adcArticulo
{
    public partial class frmComponente : Form
    {
        string tit1 = "";
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        public frmComponente(string cod)
        {
            InitializeComponent();
            verificarCodigoExterno(cod);
        }
        private void verificarCodigoExterno(string codigoExterno)
        {    
            if (codigoExterno != "") 
            {
                txtCodigo.Text = codigoExterno;
                labArticulo.Text = leerArticulo(codigoExterno);
                LlenarMalla(codigoExterno ); 
            }
        }
        private void ImprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {
        if (Malla.RowCount == 0) return;
        DataGridViewPrinterApplication1.frmMain imp = new DataGridViewPrinterApplication1.frmMain();
        preparaTitulo();
        imp.imprimir(Malla, tit1 , "",varbleComun.VarCom.nomEmpresa);
        }

        private void WordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Malla.RowCount == 0) return;
        ExportarGrid.Form1 exp = new ExportarGrid.Form1() ;
        preparaTitulo ();
        exp.Exportar(Malla , "W", varbleComun.VarCom.nomEmpresa, tit1  );
        }

        private void ExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Malla.RowCount == 0) return;
            ExportarGrid.Form1 exp = new ExportarGrid.Form1();
            preparaTitulo();
            exp.Exportar(Malla, "E", varbleComun.VarCom.nomEmpresa, tit1);
        }

        private void PDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Malla.RowCount == 0) return;
            ExportarGrid.Form1 exp = new ExportarGrid.Form1();
            preparaTitulo();
            exp.Exportar(Malla, "P", varbleComun.VarCom.nomEmpresa, tit1 );
        }

        private  void preparaTitulo()
        {
            tit1 = "Componentes del Articulo: " + txtCodigo.Text + " - " + labArticulo.Text ;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            
        }
        private void LlenarMalla(string codigoArt)
        {
            dt = new DataTable();
            string ssql = "SELECT com_tipo,COM_Codigo, a.Art_nombre, c.COM_Cantidad, c.COM_Detalle ";
            ssql += " FROM AdcCompon AS c LEFT OUTER JOIN ";
            ssql += " AdcArt AS a ON c.COM_Codigo = a.Art_codigo ";
            ssql += " where pro_codigo = '" + codigoArt + "'";
            ssql += " order by COM_Codigo";
            dt = new DataTable();            
            da = new SqlDataAdapter(ssql, varbleComun.VarCom.strConxAdcom);
            da.Fill(dt);
            Malla.DataSource = dt;
            DisenarMalla();
        }
        private void DisenarMalla()
        {
            Malla.Columns["COM_tipo"].Visible = false;

            Malla.Columns["Com_Cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            Malla.Columns["Com_Codigo"].HeaderText  = "Código";
            Malla.Columns["Com_Cantidad"].HeaderText = "Cantidad";
            Malla.Columns["Com_Detalle"].HeaderText = "Observaciones";
            Malla.Columns["Art_nombre"].HeaderText = "Descripción";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            buscarArticuloPrincipal();
        }

        private void buscarArticuloPrincipal()
        {
            txtCodigo.Text = buscador();
            if (txtCodigo.Text.Length > 0) labArticulo.Text = leerArticulo(txtCodigo.Text);
        }
        private void buscarArticuloComponente() 
        {
            string codigo = buscadorComponente();
            if (codigo.Length > 0)
            { 
               Malla.Rows[Malla.CurrentCell.RowIndex].Cells["art_nombre"].Value= leerArticulo(codigo);
            }
        }
        private string buscador()
        {
            Buscar.frmBuscar businv = new Buscar.frmBuscar();
            string ssql = "SELECT Art_codigo as Codigo, Art_nombre as Descripción, Art_unimed as UnMedida FROM AdcArt ";
            ssql += " where Art_sncomp = 1";

            string codart = businv.Buscar(varbleComun.VarCom.strConxAdcom, ssql, "art_codigo", "art_nombre", "C", "BUSQUEDA DE ARTÍCULO");
            return codart;
        }
        private string buscadorComponente()
        {
            frmBuscaArticuloSimple businv = new frmBuscaArticuloSimple(varbleComun.VarCom.suc,"","","");          
            string codart = businv.IniciaBuscaArt(Malla.CurrentCell.Value.ToString(), "");
            return codart;
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            limpiar();            
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            limpiar();
            if (e.KeyCode == Keys.F2)
            {
                buscarArticuloPrincipal();
            }
            if (e.KeyCode == Keys.Return & txtCodigo.Text.Length > 0) leerArticulo(txtCodigo.Text) ;
        }
        private string leerArticulo(string codigo)
        {
            string ssql = "Select art_nombre from adcart where art_codigo = '" + codigo + "'";
            SqlDataAdapter dad = new SqlDataAdapter(ssql, varbleComun.VarCom.strConxAdcom);
            DataTable dtt = new DataTable();
            dad.Fill(dtt);
            if (dtt.Rows.Count > 0) 
            {
                ssql= dtt.Rows[0][0].ToString();
            }
            else 
            {
                MessageBox.Show("El artículo digitado no existe", "Buscar articulo");
                ssql = "";
            }
            return ssql;
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void limpiar()
        {
            Malla.Columns.Clear ();
            CantiIni.Text = "0";
        }

        private void Malla_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2 && Malla.CurrentCell.ColumnIndex ==1)
            {

            }
        }
    }
}
