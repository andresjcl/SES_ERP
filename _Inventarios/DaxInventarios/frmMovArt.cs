using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using DattCom;
namespace DaxInvent 
{
    internal partial class frmMovArt : Form
    {
        string tit1 = "";
        string tit2 = "";
        //string strConxadcom = "";
        string CodigoExterno = "";
        //Boolean conPiezas = false;
        //string nomArticulo = "";

        internal frmMovArt(string cod = "", string nomart = "")
        {
            CodigoExterno = cod;
            //nomArticulo = nomart;
            InitializeComponent();
            cargarCombos();
            valoresIniciales();
            diseñarPantalla();
        }
        private void cargarCombos()
        {
            DaxCombobx.CargCmbBox cmb = new DaxCombobx.CargCmbBox();
            cmb.DaxCombosBods ("", true,datosEmpresa.strConxSyscod, ref comboBox1);
        }
        private void diseñarPantalla()
        {
            if (tienePiezas()==false)
            {
                piezasLab.Visible = false;
                PiezasEgr.Visible = false;
                PiezasIng.Visible = false;
                PiezasIni.Visible = false;
                PiezasSaldo.Visible = false;
            }
        }
        private void valoresIniciales()
        {
            DateTime fecha = DateTime.Today;
            txtFechaFin.Text = fecha.ToString();
            txtFechaIni.Text = fecha.AddMonths(-1).ToString();
            if (CodigoExterno != "") txtCodigo.Text = CodigoExterno;
        }
        private void verificarCodigoExterno(string codigoExterno)
        {
            if (codigoExterno != "")
            {
                txtCodigo.Text = codigoExterno;
                leerArticulo(codigoExterno);
                ejecutarConsulta();
            }
        }
        private void ImprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {
        if (Malla.RowCount == 0) return;
        DataGridViewPrinterApplication1.frmMain imp = new DataGridViewPrinterApplication1.frmMain();
        preparaTitulo();
        imp.imprimir(Malla, tit1 , tit2, datosEmpresa.Emp_Nombre);
        }

        private void WordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Malla.RowCount == 0) return;
        mallExp.Form1 exp = new mallExp.Form1() ;
        preparaTitulo ();
        exp.Exportar(Malla , "W", datosEmpresa.Emp_Nombre , tit1 + "\r\n" + tit2 );
        }

        private void ExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Malla.RowCount == 0) return;
            mallExp.Form1 exp = new mallExp.Form1();
            preparaTitulo();
            exp.Exportar(Malla, "E", datosEmpresa.Emp_Nombre , tit1 + "\r\n" + tit2);
        }

        private void PDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Malla.RowCount == 0) return;
            mallExp.Form1 exp = new mallExp.Form1();
            preparaTitulo();
            exp.Exportar(Malla, "P", datosEmpresa.Emp_Nombre, tit1 + "\r\n" + tit2);
        }

        private  void preparaTitulo()
        {
        tit2 =  "Del: " + txtFechaIni.Text + " Al: " + txtFechaFin.Text +  "  SaldoInicial:" + CantiIni.Text   +  " - " + CostoIni.Text   + "  SaldoFinal:" + CantiFin.Text  + " - " + CostoFin.Text ;
        tit1 = "Consulta de Movimientos del Articulo: " + txtCodigo.Text + " - " + labArticulo.Text ;
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            ejecutarConsulta();
        }
        private void ejecutarConsulta()
        {
            double cantidadIni = 0;
            double cantidadIniPiezas = 0;
            double costoIni = 0;
            double costoFinal = 0;
            double totalIngresos = 0;
            double totalEgresos = 0;
            double totalIngresosPiezas = 0;
            double totalEgresosPiezas = 0;
            double costoIngresos = 0;
            double costoEgresos = 0;
            double SaldoFinal = 0;
            double SaldoFinalPiezas = 0;
            string formaGrid = "#,##0." + "00000000".Substring(0, datosEmpresa.Par_DigitosCostos) + ";-#,##0." + "00000000".Substring(0, datosEmpresa.Par_DigitosCostos) + ";#";
            string formaGridUnidades = "#,##0." + "00000000".Substring(0, datosEmpresa.Par_DigitosPrecios) + ";-#,##0." + "00000000".Substring(0, datosEmpresa.Par_DigitosPrecios) + ";#";
            this.Cursor = Cursors.WaitCursor;          
             
            string bodega = comboBox1.SelectedValue.ToString();
            if (bodega == "0" ) bodega = "";
            // cargo el saldo incicial con la fecha inicial de consulta menos un dia

            DateTime fechaSaldo = Convert.ToDateTime(txtFechaIni.Text).AddDays(-1);
            string ssql = "exec DaxSalArt '" + fechaSaldo.ToString() + "','" + bodega  + "','" + txtCodigo.Text + "'"; //+ comboBox1.SelectedValue.ToString() +  "'" ;            
            DataTable ds = SqlDatos.leerTablaAdcom(ssql);
            if (ds.Rows.Count > 0 )  
            {
                cantidadIni = Convert.ToDouble(ds.Rows[0]["SaldoCantidad"].ToString());
                cantidadIniPiezas = Convert.ToDouble(ds.Rows[0]["SaldoPiezas"].ToString());
                costoIni = Convert.ToDouble(ds.Rows[0]["Promedio"].ToString()) * cantidadIni;
            }
            else
            {
                cantidadIni = 0;
                costoIni = 0;
                cantidadIniPiezas = 0;
            }            
            ds.Dispose();

            ssql = "exec Adc_MvtArt '" + txtFechaIni.Text + "','" + txtFechaFin.Text + "','" + txtCodigo.Text + "','" + bodega + "'"; //+ comboBox1.SelectedValue.ToString() +  "'" ;
            DataTable dt = SqlDatos.leerTablaAdcom(ssql);

            SaldoFinal = cantidadIni;
            costoFinal = costoIni;

            foreach (DataRow fila in dt.Rows)
            {
                SaldoFinal += Convert.ToDouble("0" + fila["Ingresos"]) - Convert.ToDouble("0" + fila["Egresos"]);
                SaldoFinalPiezas += Convert.ToDouble("0" + fila["IngresosPiezas"]) - Convert.ToDouble("0" + fila["EgresosPiezas"]);
                try
                {
                    costoFinal += Convert.ToDouble(fila["CostoMovi"]);
                }catch { }
                totalIngresos += Convert.ToDouble("0" + fila["Ingresos"]);
                totalEgresos += Convert.ToDouble("0" + fila["Egresos"]);

                totalIngresosPiezas += Convert.ToDouble("0" + fila["IngresosPiezas"]);
                totalEgresosPiezas += Convert.ToDouble("0" + fila["EgresosPiezas"]);
                try { 
                if (Convert.ToDouble(fila["CostoMovi"].ToString()) > 0)
                {
                    costoIngresos += Convert.ToDouble(fila["CostoMovi"].ToString());
                }
                else
                {
                    costoEgresos += Convert.ToDouble(fila["CostoMovi"].ToString());
                }
                }catch { }
                fila["SaldoAct"] = SaldoFinal;
                fila["SaldoActPiezas"] = SaldoFinalPiezas;
                
            }            
            

            Malla.RowHeadersWidth = 20;
            Malla.DataSource = dt;


            if (tienePiezas()==false)
            {
                Malla.Columns["IngresosPiezas"].Visible = false;
                Malla.Columns["EgresosPiezas"].Visible = false;
                Malla.Columns["SaldoActPiezas"].Visible = false;
            }
            Malla.Columns["BOD"].Width = 32;
            Malla.Columns["DOC"].Width = 32;
            Malla.Columns["Numero"].Width = 70;
            Malla.Columns["Origen/Destino"].Width = 250;
            Malla.Columns["Fecha"].Width = 70;
            Malla.Columns["Ingresos"].Width = 70;
            Malla.Columns["Egresos"].Width = 70;
            Malla.Columns["CostoUni"].Width = 70;
            Malla.Columns["CostoMovi"].Width = 70;
            Malla.Columns["SaldoAct"].Width = 70;

            //Malla.Columns["Ingresos"].DefaultCellStyle.Format = "N" + SYSEMP.EmpresaAct.NumeroDecimales.ToString()  ;
            //Malla.Columns["Ingresos"].DefaultCellStyle.NullValue  = "";
            Malla.Columns["Ingresos"].DefaultCellStyle.Format  = formaGrid;
            Malla.Columns["Ingresos"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            Malla.Columns["Egresos"].DefaultCellStyle = Malla.Columns["Ingresos"].DefaultCellStyle;
            Malla.Columns["CostoUni"].DefaultCellStyle = Malla.Columns["Ingresos"].DefaultCellStyle;
            Malla.Columns["CostoMovi"].DefaultCellStyle = Malla.Columns["Ingresos"].DefaultCellStyle;
            Malla.Columns["SaldoAct"].DefaultCellStyle = Malla.Columns["Ingresos"].DefaultCellStyle;
            Malla.Columns["EgresosPiezas"].DefaultCellStyle = Malla.Columns["Ingresos"].DefaultCellStyle;
            Malla.Columns["SaldoActPiezas"].DefaultCellStyle = Malla.Columns["Ingresos"].DefaultCellStyle;

            Malla.Columns["CostoUni"].DefaultCellStyle.Format = formaGrid;
            Malla.Columns["CostoMovi"].DefaultCellStyle.Format = formaGrid;

            
            //Malla.Columns["Egresos"].Width = 70;
            //Malla.Columns["CostoUni"].Width = 70;
            //Malla.Columns["CostoMovi"].Width = 70;
            //Malla.Columns["SaldoAct"].Width = 70;

           //1.textbox1.Text = string.Format("{0:#,##0.00}", Convert.ToDouble(textbox1


            CantiIni.Text = cantidadIni.ToString(formaGrid);
            PiezasIni.Text = cantidadIniPiezas.ToString(formaGrid);
            CostoIni.Text = costoIni.ToString(formaGrid);
            CantiIng.Text = totalIngresos.ToString(formaGrid);
            cantiEgr.Text = totalEgresos.ToString(formaGrid);
            CantiFin.Text = SaldoFinal.ToString(formaGrid);
            CostoFin.Text = costoFinal.ToString(formaGrid);
            CostoEgr.Text = costoEgresos.ToString(formaGrid);
            costoIng.Text = costoIngresos.ToString(formaGrid);
            PiezasIng.Text = totalIngresosPiezas.ToString(formaGrid);
            PiezasEgr.Text = totalEgresosPiezas.ToString(formaGrid);
            PiezasSaldo.Text = SaldoFinalPiezas.ToString(formaGrid);
            
            this.Cursor = Cursors.Default;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            buscarArticulo();
        }

        private void buscarArticulo()
        {
            Buscar.frmBuscar businv = new Buscar.frmBuscar();
            string codart = businv.Buscar(datosEmpresa.strConxAdcom , "SELECT Art_codigo as Codigo, Art_nombre as Descripción, Art_unimed as UnMedida FROM AdcArt ", "Codigo", "Descripción", "C", "BUSQUEDA DE ARTÍCULO");
            txtCodigo.Text  = codart;
            if (txtCodigo.Text.Length > 0) leerArticulo(txtCodigo.Text);
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
                buscarArticulo();
            }
            if (e.KeyCode == Keys.Return & txtCodigo.Text.Length > 0) leerArticulo(txtCodigo.Text) ;
        }
        private void leerArticulo(string codigo)
        {
            DataTable dt = SqlDatos.leerTablaAdcom ("Select art_nombre from adcart where art_codigo = '" + codigo + "'");
            if (dt.Rows.Count > 0)
            {
                labArticulo.Text = dt.Rows[0][0].ToString();
            }
            else 
            {
                MessageBox.Show("El artículo digitado no existe", "Buscar articulo");
                txtCodigo.Focus();
                labArticulo.Text = "";
            }
        }
        private DataTable leerDatos(string ssql) 
        {
            SqlConnection conexion = new SqlConnection(datosEmpresa.strConxAdcom);
            conexion.Open(); 
            DataTable ds = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter(ssql, conexion);
            adp.Fill(ds);
            return ds;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            limpiar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void limpiar()
        {
            Malla.Columns.Clear ();
            CantiIni.Text = "0";
            CostoIni.Text = "0";
            CantiIng.Text = "0";
            cantiEgr.Text = "0";
            CantiFin.Text = "0";
            CostoFin.Text = "0";
            CostoEgr.Text = "0";
            costoIng.Text = "0";
            PiezasIng.Text = "0";
            PiezasEgr.Text = "0";
            PiezasSaldo.Text = "0";            
        }

        private void txtFechaIni_ValueChanged(object sender, EventArgs e)
        {
            TimeSpan ts = new TimeSpan(1,0,0,0);
            if (txtFechaIni.Value < datosEmpresa.UltimoCierreAnual) txtFechaIni.Value = datosEmpresa.UltimoCierreAnual.Add(ts);
            limpiar();
        }
        private Boolean tienePiezas()
        {
            string ssql = "select * from adcopc where datosauxiliares like '%Piezas%'";
            if( leerDatos(ssql).Rows.Count == 0) return false;
            return true;
        }

    }
}
