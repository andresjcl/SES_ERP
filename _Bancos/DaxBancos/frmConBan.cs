using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using DattCom;
namespace DaxBan
{
    public partial class frmConBan : Form
    {
        DateTime fechaInicial;                                      //parametro para fecha inicial de la busqueda
        DateTime fechaFinal;                                        //parametro para fecha final de la busqueda
        String fechaActual = DateTime.Today.ToString("dd/MM/yyyy"); //fecha actual con el formato
        public DataTable dato;                                       //Conjunto de Datos
        public string consulta;                                    //Consulta para mostrar en el datagridview o reportViewer
        public BindingSource valor;                                //Recurso de datos
        public String banco;                                       //codigo del banco
        public Boolean botonOp = false ;
        public Double datSaldo;                                    //saldo ingresado por el usuario desde el formulario hijo
        DateTime fechaHoy = DateTime.Now;                           //fecha actual sin formato
        public String opcion;
        public Boolean cambiado =false ;
        public frmConBan()
        {
            InitializeComponent();
            fechaInicial = fechaHoy.AddDays(-fechaHoy.Day + 1);
            textBoxFechaDesde.Text = Convert.ToString(fechaInicial);
            textBoxFechaHasta.Text = DateTime.Today.ToString("dd/MM/yyyy");
            consultarBancos();
            consultarCuenta();
//            llenarCuentasBanco(comboBanco.SelectedValue.ToString());
            malla.Visible = false;
            //atras.Visible = false;
            btnCancelar.Visible = false;
            btnBorrar.Visible = false;
        }

        /// <summary>
        /// consulta los bancos existentes
        /// </summary>
        public void consultarBancos()
        {
            try
            {
                DaxCombobx.CargCmbBox combo = new DaxCombobx.CargCmbBox();
                combo.DaxCombosBancos(datosEmpresa.strConxAdcom , ref comboBanco);
            }
            catch { }
        }
        //public void llenarCuentasBanco(string codBanco)
        //{
        //    try
        //    {
        //        string ssql = "select Bco_Codigo,Bco_NumCta from AdcCtaBco";
        //        DataTable dt = SqlDatos.leerTablaAdcom(ssql);
        //        comboCuentaBanco.DataSource = dt;
        //        comboCuentaBanco.ValueMember = "Bco_codigo";
        //        comboCuentaBanco.DisplayMember = "Bco_numcta";
        //        comboCuentaBanco.SelectedIndex = 0;
        //    }
        //    catch { }
        //}

        public void llenarCuentasBanco(string codBanco)
        {
            try
            {
                string ssql = "select Bco_Codigo, Bco_NumCta, (Bco_Codigo + '-' + Bco_NumCta) as CuentaCompleta from AdcCtaBco";
                DataTable dt = SqlDatos.leerTablaAdcom(ssql);
                comboCuentaBanco.DataSource = dt;
                comboCuentaBanco.ValueMember = "Bco_Codigo";
                comboCuentaBanco.DisplayMember = "CuentaCompleta";
                comboCuentaBanco.SelectedIndex = 0;
            }
            catch { }
        }
        public void abrir_Click(object sender, EventArgs e)
        {
            if (cambiado)
            {
                if (MessageBox.Show("Confirma abrir nuevamente los resultados ?, los cambios realizados se perderán", "Conciliacion Bancaria", MessageBoxButtons.YesNo) == DialogResult.No) return;
            }
            listaDatos();
            btnConciliacion.Enabled = true;
        }

        /// <summary>
        /// obtiene los datos para mostrar en el datagrirdview
        /// </summary>
        public void listaDatos()
        {
          //  try
        //    {
                fechaInicial = Convert.ToDateTime(textBoxFechaDesde.Text);
                fechaFinal = Convert.ToDateTime(textBoxFechaHasta.Text);
                malla.Visible = true;
                btnCancelar.Visible = true;
                btnBorrar.Visible = true;
                malla.Visible = true;
                banco = comboCuentaBanco.SelectedValue.ToString();
            //banco = comboCuentaBanco.Text;
                malla.Columns.Clear();
                totales.Columns.Clear();
                if (fechaFinal.Date >= fechaInicial.Date)
                {
                    if (checkRegBanco.Checked)
                    {
                        opcion = "s";
                    }            
                    else if (checkNoReg.Checked)
                    {
                        opcion = "n";
                    }
                    else
                    {
                        opcion = "sn";
                    }
                    consulta = "EXEC Dax_Conbc '" + textBoxFechaDesde.Text + "', '" + textBoxFechaHasta.Text + "', '" + banco + "', '" + opcion + "'";
                    DataTable valor = SqlDatos.leerTablaAdcom(consulta);
                    
                    //opcion = "";
                    malla.DataSource = valor;
                    if (malla.Rows.Count == 0 || malla.Columns.Count < 2 )  return ;                 
                    malla.Columns["idclavedoc"].Visible = false;
                    malla.RowHeadersWidth = 25;

                    malla.Columns["Registro"].ReadOnly = false;
                    malla.Columns["Fecha"].ReadOnly = true;
                    malla.Columns["Beneficiario"].ReadOnly = true;
                    malla.Columns["Detalle"].ReadOnly = true;
                    malla.Columns["SUC"].ReadOnly = true;
                    malla.Columns["DOC"].ReadOnly = true;
                    malla.Columns["Número"].ReadOnly = true;
                    malla.Columns["CheqDepst"].ReadOnly = true;
                    malla.Columns["Débitos"].ReadOnly = true;
                    malla.Columns["Créditos"].ReadOnly = true;
                    malla.Columns["Saldo"].ReadOnly = true;
                    
                    
                    malla.Columns["Débitos"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    malla.Columns["Créditos"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    malla.Columns["Saldo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    malla.Columns["Registro"].Width = 75;
                    malla.Columns["Fecha"].Width = 75;
                    malla.Columns["Beneficiario"].Width = 200;
                    malla.Columns["Detalle"].Width = 200;
                    malla.Columns["SUC"].Width = 32;
                    malla.Columns["DOC"].Width =32;
                    malla.Columns["Número"].Width = 50;
                    malla.Columns["CheqDepst"].Width = 75;
                    malla.Columns["Débitos"].Width =80;
                    malla.Columns["Créditos"].Width =80;
                    malla.Columns["Saldo"].Width =80;
                    
                    malla.Columns["Registro"].DefaultCellStyle.Format = "dd/MMM/yyyy";
                    malla.Columns["Fecha"].DefaultCellStyle.Format = "dd/MMM/yyyy";
                    malla.Columns["Débitos"].DefaultCellStyle.Format = "#,###,##0.00;(#,###,##0.00);\\";
                    malla.Columns["Créditos"].DefaultCellStyle.Format = "#,###,##0.00;(#,###,##0.00);\\";
                    malla.Columns["Saldo"].DefaultCellStyle.Format = "#,###,##0.00;(#,###,##0.00);\\";
                    int tamaño = malla.RowCount;
                    if (tamaño > 0)
                    {
                        //dataGridView1.Rows[0].Cells["Saldo"].Value = dataGridView1.Rows[0].Cells["Saldo"].Value;
                        calcularSaldo(tamaño);
                        btnConciliacion.Enabled = true;
                    }

                    consulta = "EXEC Dax_resConbc '" + textBoxFechaDesde.Text + "', '" + textBoxFechaHasta.Text + "', '" + banco + "', '" + opcion + "'";                    
                    totales.DataSource = SqlDatos.leerTablaAdcom(consulta);
                    opcion = "";
                    cambiado = false;
                }
                else
                {
                    MessageBox.Show("La fecha inicial es mayor que la fecha final" + "\n" +
                        "Corrija los campos", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
         // }
           // catch
          //  --{
             // --  MessageBox.Show("La fecha ingresada es incorrecta", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //--}
        }



        public void calcularSaldo(int tamaño)
        {
            malla.Rows[0].HeaderCell.Value = 1;
            double saldoFinal = Convert.ToDouble(malla.Rows[0].Cells["Saldo"].Value);
            int i = 0;
            foreach (DataGridViewRow row in malla.Rows)
            {
                if (i > 0) saldoFinal += Convert.ToDouble(row.Cells["Saldo"].Value);
                row.Cells["Saldo"].Value = saldoFinal;
                i += 1;
                row.HeaderCell.Value = i;
                if (celdaValida(row.Cells["Registro"])) cambiarColor(row.Cells["Registro"]);
            }
        }




        public void actualizar()
           
        {
            string aux = "";
            //try
            //{
                if (malla.Rows.Count>0)
                {
                    foreach (DataGridViewRow row in malla.Rows)
                    {
                        aux = Convert.ToString ( row.Cells["DOC"].Value) ;
                        if (aux.Length  > 0)
                        {
                        String fecha = Convert.ToString(row.Cells["Registro"].Value);
                        String updat = "UPDATE AdcDoc SET Doc_CobraCheque ='" + fecha + "'"; 
                        updat  += " WHERE opc_documento = '" + row.Cells["DOC"].Value + "' ";
                        updat  += " and doc_sucursal = '" + row.Cells["SUC"].Value + "' ";
                        updat += " and IdClaveDoc ='" + row.Cells["idclavedoc"].Value + "'";
                        SqlDatos.ejecutarComandoAdcom(updat);
                        cambiado  = false;
                        }
                     }
                    //dataGridView1.Columns.Clear();
                    //dataGridView1.Visible = false;
                    MessageBox.Show("La Información se ha actualizado correctamente");
                    }else{
                        MessageBox.Show("No existen datos para actualizar");
                }
            //}
            //catch
            //{
            //    MessageBox.Show("La Información NO se ha actualizado correctamente");
            //}
        }

        /// <summary>
        /// boton que llama al metodo actualizar();
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void guardar_Click(object sender, EventArgs e)
        {
            btnCancelar.Visible = false;
            btnBorrar.Visible = false;
            if (cambiado == true) actualizar();
            btnConciliacion.Enabled = true;
            //groupBox1.Enabled = true;
            //groupBox2.Enabled = true;

        }

        public void comboBanco_SelectedIndexChanged(object sender, EventArgs e)
        {
            cerrarMalla();
            consultarCuenta();
        }

        /// <summary>
        /// consulta las cuentas correspondiente al banco seleccionado
        /// </summary>
        //public void consultarCuenta()
        //{
        //    comboCuentaBanco.Enabled = true;
        //    consulta = "select Bco_Codigo,Bco_NumCta from AdcCtaBco where Bco_CodAlex = '" + comboBanco.SelectedValue + "'";
        //    DataTable dato = SqlDatos.leerTablaAdcom(consulta);
        //    try
        //    {
        //        if (dato.Rows.Count > 0)
        //        {
        //            comboCuentaBanco.DataSource = dato;
        //            comboCuentaBanco.DisplayMember = "Bco_NumCta";
        //            comboCuentaBanco.ValueMember = "Bco_Codigo";
        //        }
        //        else
        //        {
        //            comboCuentaBanco.Text = "No existen cuentas";
        //            comboCuentaBanco.Enabled = false;
        //        }
        //    }
        //    catch { }
        //}

        public void consultarCuenta()
        {
            comboCuentaBanco.Enabled = true;
            consulta = "select Bco_Codigo, Bco_NumCta, (Bco_Codigo + '-' + Bco_NumCta) as CuentaCompleta from AdcCtaBco where Bco_CodAlex = '" + comboBanco.SelectedValue + "'";
            DataTable dato = SqlDatos.leerTablaAdcom(consulta);
            try
            {
                if (dato.Rows.Count > 0)
                {
                    comboCuentaBanco.DataSource = dato;
                    comboCuentaBanco.DisplayMember = "CuentaCompleta";  // Cambiado a la columna concatenada
                    comboCuentaBanco.ValueMember = "Bco_Codigo";
                    comboCuentaBanco.SelectedIndex = 0; // Opcional: selecciona el primer item
                }
                else
                {
                    comboCuentaBanco.Text = "No existen cuentas";
                    comboCuentaBanco.Enabled = false;
                }
            }
            catch { }
        }

        /// <summary>
        /// guarda la fecha de registro segun las tecjas presionadas F2 o F3
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            Int32 selectedCellCount = malla.GetCellCount(DataGridViewElementStates.Selected);
            if (selectedCellCount > 0)
            {
                foreach (DataGridViewCell celda in malla.SelectedCells)
                {
                    if (celdaValida( celda) == true && malla.Columns[celda.ColumnIndex].Name=="Registro")
                    {
                        int fila = celda.RowIndex;
                        if (e.KeyCode == Keys.F2) { celda.Value = textBoxFechaDesde.Text; }
                        if (e.KeyCode == Keys.F3) { celda.Value = textBoxFechaHasta.Text; }
                        if (e.KeyCode == Keys.F4) { celda.Value = malla.Rows[fila].Cells["Fecha"].Value; }
                        cambiarColor(celda);
                    }
                }
             }

        }
        public void cambiarColor(DataGridViewCell celda)
        {
            if (celda.ColumnIndex != 0) return;
            DateTime fechaReg;
            try
            {
                fechaReg = Convert.ToDateTime(celda.Value);
            }
            catch 
            { fechaReg = Convert.ToDateTime("01/01/1900"); }


            celda.Style.BackColor = Color.White;
            if (fechaReg < Convert.ToDateTime(textBoxFechaDesde.Text))
            {
                celda.Style.BackColor = Color.Red;
            }

            if (fechaReg > Convert.ToDateTime(textBoxFechaHasta.Text))
            {
                celda.Style.BackColor = Color.Cyan;
            }
        }
        public void comboBanco_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        public void comboCuentaBanco_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        /// <summary>
        /// coloca la fecha inicial de busqueda en la columna  registro del datagrid , en la fila seleccionada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnFechaIni_Click(object sender, EventArgs e)
        {
            Int32 selectedCellCount = malla.GetCellCount(DataGridViewElementStates.Selected);
            if (selectedCellCount > 0)
            {
                foreach (DataGridViewCell celda in malla.SelectedCells)
                {
                    if (celdaValida (celda))
                    {
                        celda.Value = textBoxFechaDesde.Text;
                        cambiarColor(celda);
                    }
                }
            }
        }


        /// <summary>
        /// coloca la fecha finasl de busqueda en la columna  registro del datagrid , en la fila seleccionada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnFechaFin_Click(object sender, EventArgs e)
        {
            Int32 selectedCellCount = malla.GetCellCount(DataGridViewElementStates.Selected);
            if (selectedCellCount > 0)
            {
                foreach (DataGridViewCell celda in malla.SelectedCells)
                {
                    if (celdaValida(celda))
                    {
                        celda.Value = textBoxFechaHasta.Text;
                        cambiarColor(celda);
                    }
                }
            }
        }

        /// <summary>
        /// coloca la fecha de emision de documento en la columna  registro del datagrid , en la fila seleccionada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnFechaEmi_Click(object sender, EventArgs e)
        {
            Int32 selectedCellCount = malla.GetCellCount(DataGridViewElementStates.Selected);
            if (selectedCellCount > 0)
            {
                foreach (DataGridViewCell celda in malla.SelectedCells)
                {
                    if (celdaValida(celda))
                    {
                        celda.Value = malla.Rows[celda.RowIndex].Cells["Fecha"].Value;
                        cambiarColor(celda);
                    }
                }
            }
        }

        /// <summary>
        /// imprime los datos del datagrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void imprimir_Click(object sender, EventArgs e)
        {
            if (malla.RowCount > 1)
            {
                DataGridViewPrinterApplication1.frmMain imp = new DataGridViewPrinterApplication1.frmMain();
                imp.imprimir(malla, "Conciliación Bancaria", "", "");
            }
            else
            {
                MessageBox.Show("No existen datos para imprimir");
            }
        }

        public void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Activate();
            }
            else
            {
                splitContainer1.SplitterDistance = 275;
            }
        }

        public void Form1_Load_1(object sender, EventArgs e)
        {
            comboCuentaBanco.Enabled = true;
            consultarCuenta();
            btnConciliacion.Enabled = false;
        }

        
        /// <summary>
        /// muestra el formulario hijo para el ingreso del saldo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        public void datoSaldo(Double dat)
        { 
            datSaldo = dat; 
        }

        /// <summary>
        /// reporte
        /// </summary>


        public void toolCancelar_Click(object sender, EventArgs e)
        {
            if (cambiado == true)
            {
                if (MessageBox.Show("Confirma Cancelar los cambios realizados", "Conciliacion Bancaria", MessageBoxButtons.YesNo) == DialogResult.No) return;
            }
                malla.Columns.Clear();
                totales.Columns.Clear();
                btnCancelar.Visible = false;
                btnBorrar.Visible = false;
                btnConciliacion.Enabled = false;
                //groupBox1.Enabled = true;
                //groupBox2.Enabled = true;
        }

        /// <summary>
        /// borra las fechas de los registros seleccionados en el datagridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnBorrar_Click(object sender, EventArgs e)
        {
            Int32 selectedCellCount = malla.GetCellCount(DataGridViewElementStates.Selected);
            if (selectedCellCount > 0)
            {
                for (int i = 0; i < selectedCellCount; i++)
                {
                    if (malla.SelectedCells[i].ColumnIndex == 0)
                    {
                        int fila = Convert.ToInt32(malla.SelectedCells[i].RowIndex.ToString());
                        malla.Rows[fila].Cells[0].Value = "";
                        malla.Rows[fila].Cells[0].Style.BackColor = Color.Red;
                    }
                }
            }
        }

        public void toolStripButton1_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();            
        }

        public void btnConciliacion_Click(object sender, EventArgs e)
        {           
            //DialogResult dr = new DialogResult();
            int Linea = malla.RowCount - 1;
            frmVisConBan s = new frmVisConBan ();
            if (textSaldo.Text.Length == 0)
            {
                MessageBox.Show ("Ingrese el saldo que consta en el estado de cuenta bancaria");
                textSaldo.Focus();
                return;
            };
            s.textBoxFechaDesde = textBoxFechaDesde.Text ;
            s.textBoxFechaHasta = textBoxFechaHasta.Text;
            s.comboCuentaBanco = comboCuentaBanco.Text ;
            s.comboBanco = comboBanco.Text;
            s.Nombre = datosEmpresa.Emp_Nombre;
            s.conexion = null;
            s.pathappl = datosEmpresa.pathAppl;
            s.textSaldoBanco = textSaldo.Text;
            s.textSaldoSistema = Convert.ToString( malla.Rows[Linea].Cells["Saldo"].Value);
            s.textDiferencia = (Convert.ToDecimal(s.textSaldoSistema) - Convert.ToDecimal(textSaldo.Text)).ToString ();
            s.form2_load(); //ShowDialog(this);
            s.Dispose(); 

        }

        public void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnConciliacion.Enabled = false;
        }

        public void BtnOpciones_Click(object sender, EventArgs e)
        {
        if (botonOp == false)
            {
            BtnOpciones.Checked = false ;
            botonOp = true;
            }
        else
            {
            BtnOpciones.Checked = true ;
            botonOp = false;
            }        
        splitContainer1.Panel1Collapsed = ( BtnOpciones.Checked == false);
        }

        public void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            btnConciliacion.Enabled = radioButton1.Checked;
            cerrarMalla();
        }

        public void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            cambiado = true;
        }

        public void btnexcel_Click(object sender, EventArgs e)
        {
            string Titulo = armarTitulo() ;
            mallExp.Form1 exp = new mallExp.Form1() ;
            exp.Exportar(malla, "E", datosEmpresa.Emp_Nombre , Titulo);
        }
        public void btnword_Click(object sender, EventArgs e)
        {
            string Titulo = armarTitulo();
            mallExp.Form1 exp = new mallExp.Form1();
            exp.Exportar(malla, "W", datosEmpresa.Emp_Nombre, Titulo);
        }

        
        public string armarTitulo()
        {
            string titul = "";
            if (radioButton1.Checked) 
                { 
                titul += "Lista de todos los movimientos del banco :"; 
                }
            if (checkNoReg.Checked )
            {
                titul += "Lista de movimientos NO registrados del banco :";
            }
            if (checkRegBanco.Checked )
            {
                titul += "Lista de movimientos registrados del banco :";
            }            
            titul += comboBanco.Text;
            titul += "  CTA: " + comboCuentaBanco.Text;
            titul += "  del " + textBoxFechaDesde.Text  + " al " + textBoxFechaHasta.Text  ;
            return titul;
        }

        public void btnpdf_Click(object sender, EventArgs e)
        {
            string Titulo = armarTitulo();
            mallExp.Form1 exp = new mallExp.Form1();
            exp.Exportar(malla, "P", datosEmpresa.nomEmpresa , Titulo);
        }

        public void checkNoReg_CheckedChanged(object sender, EventArgs e)
        {
            cerrarMalla();            
        }

        public void checkRegBanco_CheckedChanged(object sender, EventArgs e)
        {
            cerrarMalla();
        }

        public void textBoxFechaDesde_TextChanged(object sender, EventArgs e)
        {
            cerrarMalla();
        }

        public void textBoxFechaHasta_TextChanged(object sender, EventArgs e)
        {
            cerrarMalla();
        }

        public void cerrarMalla()
        {
            if (cambiado)
            {
                if (MessageBox.Show("Desea guardar los cambios ? ", "Conciliacion Bancaria", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    actualizar();
                }
            }
            malla.Columns.Clear();
            totales.Columns.Clear();
            btnCancelar.Visible = false;
            btnBorrar.Visible = false;
            btnConciliacion.Enabled = false;
            cambiado = false;
        }

        public void comboCuentaBanco_SelectedIndexChanged(object sender, EventArgs e)
        {
            cerrarMalla();
         //   consultarCuenta();
        }

        public void textSaldo_KeyPress(object sender, KeyPressEventArgs e)
        {
            int isNumber = 0; 
            if (e.KeyChar == '.')      
            {
                e.Handled = false;
                return;
            }
            if (e.KeyChar == 8 )      
            {
                e.Handled = false;
                return;
            }
            if (e.KeyChar == Convert.ToChar ("-"))
            {
                e.Handled = false;
                return;
            }

            e.Handled = !int.TryParse(e.KeyChar.ToString(), out isNumber);                         
        }

        public void dataGridView1_CellValidated(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex == 0 & e.ColumnIndex == 0 & malla.Rows[e.RowIndex].Cells[2].Value.ToString() == "SALDO INICIAL") malla.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
         
        }

        public void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (celdaValida(malla.Rows[e.RowIndex].Cells[e.ColumnIndex]))
            {
                Boolean bien = true;
                if (FechaSinValor(e.RowIndex) == false)
                {
                    try
                    {
                        DateTime ff = Convert.ToDateTime(malla.Rows[e.RowIndex].Cells[0].Value.ToString());
                        DateTime f1 = Convert.ToDateTime(textBoxFechaDesde.Text);
                        DateTime f2 = Convert.ToDateTime(textBoxFechaHasta.Text);
                        if (ff < f1 || ff > f2) bien = false;
                    }
                    catch
                    {
                        bien = false;
                    }
                    if (bien == false)
                    {
                        MessageBox.Show("Fecha mal registrada " + malla.Rows[e.RowIndex].Cells[0].Value.ToString(), "Registro de documentos en banco");
                        malla.Rows[e.RowIndex].Cells[0].Value = "";
                    }
                }
            }            
        }
        public Boolean FechaSinValor(Int32 linea )
        {
            bool resp = false;
            try
            {
                if (malla.Rows[linea].Cells[0].Value.ToString().Trim().Length == 0) 
                    malla.Rows[linea].Cells[0].Value="";
                    resp=true;
            }
            catch
            {
                    malla.Rows[linea].Cells[0].Value="";
                    resp=true;                            
            }
            return resp;
        }
        public Boolean celdaValida(DataGridViewCell celda)
        {
            if (celda.RowIndex == 0 && malla.Rows[celda.RowIndex].Cells["Beneficiario"].Value.ToString().Trim() == "SALDO INICIAL") return false;
            else return true;
        }

        public void btnBuscar_Click(object sender, EventArgs e)
        {
            DaxMallaLib.frmBuscMall  buscador = new DaxMallaLib.frmBuscMall(malla,true,true);
            buscador.ShowDialog();
        }

        public void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        public void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void frmConBan_Load(object sender, EventArgs e)
        {
            comboCuentaBanco.Enabled = true;
            consultarCuenta();
            btnConciliacion.Enabled = false;
        }
    }
}
