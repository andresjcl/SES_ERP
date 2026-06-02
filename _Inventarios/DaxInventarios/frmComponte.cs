using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using DattCom;
namespace DaxInvent
{
    internal partial class frmComponente : Form
    {
        string tit1 = "";
        internal frmComponente(string cod)
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

        private void LlenarMalla(string codigoArt)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter();
            dt = new DataTable();
            string ssql = "SELECT com_tipo,COM_Codigo, a.Art_nombre, c.COM_Cantidad, c.COM_Detalle ";
            ssql += " FROM AdcCompon AS c LEFT OUTER JOIN ";
            ssql += " AdcArt AS a ON c.COM_Codigo = a.Art_codigo ";
            ssql += " where pro_codigo = '" + codigoArt + "'";
            ssql += " order by COM_Codigo";
            dt = new DataTable();            
            da = new SqlDataAdapter(ssql, datosEmpresa.strConxAdcom);
            da.Fill(dt);
            Malla.DataSource = dt;
            DisenarMalla();
            dt.Dispose();
            da.Dispose();
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

        #region eventos de botones y teclas

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            limpiar();
        }
        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                buscarArticuloPrincipal();
            }
            if (e.KeyCode == Keys.Return & txtCodigo.Text.Length > 0)
            {
                limpiar();
                leerArticulo(txtCodigo.Text);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            buscarArticuloPrincipal();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string ssql = "select * FROM AdcCompon ";
            ssql += " where pro_codigo = '" + txtCodigo.Text + "'";
            //using (SqlConnection conn = new SqlConnection(datosEmpresa.strConxAdcom))
            //{
            //    conn.Open();
            //    SqlCommand comm = new SqlCommand(ssql, conn);
            //    SqlComman
            //}
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(ssql, datosEmpresa.strConxAdcom);
            da.Fill(dt);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);

            //verificar si lineas de malla existen en data
            foreach (DataGridViewRow grRow in Malla.Rows)
            {
                if (grRow.Cells["com_codigo"].Value != null && grRow.Cells["com_codigo"].Value.ToString().Length > 0)
                {
                    string codCompnte = grRow.Cells["com_codigo"].Value.ToString();
                    Boolean esIgual = false;
                    foreach (DataRow dtRow in dt.Rows)
                    {
                        if (codCompnte == dtRow["com_codigo"].ToString())
                        {

                            dtRow["com_cantidadBase"] = Convert.ToDecimal("0" + CantiIni.Text);
                            dtRow["com_cantidad"] = grRow.Cells["com_cantidad"].Value;
                            dtRow["com_detalle"] = grRow.Cells["com_detalle"].Value;
                            dtRow["com_tipo"] = grRow.Cells["com_tipo"].Value;
                            esIgual = true;
                        }
                    }
                    if (!esIgual)
                    {
                        DataRow nRow = dt.NewRow();
                        nRow["Pro_codigo"] = txtCodigo.Text;
                        nRow["com_codigo"] = grRow.Cells["com_codigo"].Value;
                        nRow["com_cantidadBase"] = Convert.ToDecimal("0" + CantiIni.Text);
                        nRow["com_cantidad"] = grRow.Cells["com_cantidad"].Value;
                        nRow["com_detalle"] = ""+grRow.Cells["com_detalle"].Value.ToString();
                        nRow["com_tipo"] = ""+grRow.Cells["com_tipo"].Value.ToString();
                        dt.Rows.Add(nRow);
                    }
                }
            }
            //    verificar si debe eliminarse una fila de la data
            Boolean seElimino = true;
            do
            {
                seElimino = false;
                try
                {
                    foreach (DataRow dtRow in dt.Rows)
                    {
                        if (!existeEnMalla(dtRow["com_codigo"].ToString()))
                        {
                            dtRow.Delete();
                            seElimino = true;
                        }
                    }
                }catch{ }
            } while (seElimino);

            da.Update(dt);
            dt.AcceptChanges();

            da.Dispose();
            dt.Dispose();
            cb.Dispose();


            Close();
            Dispose();
        }
        private Boolean existeEnMalla (string codigo)
        {
            bool existe = false;
            foreach (DataGridViewRow grRow in Malla.Rows)
            {
                if (grRow.Cells["com_codigo"].Value != null && grRow.Cells["com_codigo"].Value.ToString().Length > 0)
                {
                    if (codigo == grRow.Cells["com_codigo"].Value.ToString()) { existe = true; break; }
                }
            }
            return existe;
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Malla_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2 && Malla.CurrentCell.ColumnIndex == 1)
            {
                buscarArticuloComponente();
            }
        }
        #endregion
        private void limpiar()
        {
            Malla.Columns.Clear();
            CantiIni.Text = "1";           
        }
        private void buscarArticuloPrincipal()
        {
            txtCodigo.Text = buscadorArticulo();
            if (txtCodigo.Text.Length > 0) labArticulo.Text = leerArticulo(txtCodigo.Text);
        }
        private void buscarArticuloComponente() 
        {
            string codigo = buscadorComponente();
            Int32 indRow = Malla.CurrentCell.RowIndex;
            Malla.CurrentCell.Value = codigo;
            if (codigo.Length > 0)
            { 
               Malla.Rows[indRow].Cells["art_nombre"].Value = leerArticulo(codigo);
               Malla.Rows[indRow].Cells["com_tipo"].Value = "MAT";
            }
            Malla.CurrentCell = Malla.Rows[indRow].Cells["com_cantidad"]; 
        }
        private string buscadorArticulo()
        {
            Buscar.frmBuscar businv = new Buscar.frmBuscar();
            string ssql = "SELECT Art_codigo as Codigo, Art_nombre as Descripción, Art_unimed as UnMedida FROM AdcArt ";
            ssql += " where Art_sncomp = 1";
            string codart = businv.Buscar(datosEmpresa.strConxAdcom, ssql, "art_codigo", "art_nombre", "C", "BUSQUEDA DE ARTÍCULO");
            return codart;
        }
        private string buscadorComponente()
        {
            frmBuscaArticuloSimple businv = new frmBuscaArticuloSimple(datosEmpresa.suc,"","","");          
            string codart = businv.IniciaBuscaArt(Malla.CurrentCell.Value.ToString(), "");
            return codart;

        }

        private string leerArticulo(string codigo)
        {
            string ssql = "Select art_nombre from adcart where art_codigo = '" + codigo + "'";
            SqlDataAdapter dad = new SqlDataAdapter(ssql, datosEmpresa.strConxAdcom);
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

        #region envios de la malla
        private void ImprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Malla.RowCount == 0) return;
            DataGridViewPrinterApplication1.frmMain imp = new DataGridViewPrinterApplication1.frmMain();
            preparaTitulo();
            imp.imprimir(Malla, tit1, "", datosEmpresa.nomEmpresa);
        }

        private void WordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Malla.RowCount == 0) return;
            mallExp.Form1 exp = new mallExp.Form1();
            preparaTitulo();
            exp.Exportar(Malla, "W", datosEmpresa.nomEmpresa, tit1);
        }

        private void ExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Malla.RowCount == 0) return;
            mallExp.Form1 exp = new mallExp.Form1();
            preparaTitulo();
            exp.Exportar(Malla, "E", datosEmpresa.nomEmpresa, tit1);
        }

        private void PDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Malla.RowCount == 0) return;
            mallExp.Form1 exp = new mallExp.Form1();
            preparaTitulo();
            exp.Exportar(Malla, "P", datosEmpresa.nomEmpresa, tit1);
        }

        private void preparaTitulo()
        {
            tit1 = "Componentes del Articulo: " + txtCodigo.Text + " - " + labArticulo.Text;
        }
        #endregion
    }

}
