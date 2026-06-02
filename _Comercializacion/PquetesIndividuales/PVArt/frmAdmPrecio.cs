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
using System.Data.SqlTypes;
using System.Globalization;
using Buscar;
using SysEmpDatt;
namespace adcArticulosPrecios
{
    public partial class frmAdmPrecio : Form
    {
   
        DaxFormPv datFormula = new DaxFormPv(datosEmpresa.strConxAdcom);
        private DataSet dato;
        private string consulta;
        private BindingSource valor;
        private SqlDataAdapter misqlDa;
        private double  nuevoValor;// nuevo valor del precio a cambiar
        private String cambiarPrecio;//precio a cambiar
        private String precioActual;//parametro para varia el precio en realacion al precio de venta actual
        private String categoria;
        private String clase;
        private String grupo;
        private String subgrupo;
        //private string[] valorOrigen = new string[8] ;
        //private string[] valorDestino = new string[8] ;
        //private string[] nombreCampos = new string[8];
        public frmAdmPrecio() 
        {
            InitializeComponent();            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            panelFórmula.Visible = true; //datEmpresa.EmpresaAct.CCosto;
            actualizar_Click(sender, e);
            consultarCategoria();
            consultarClase();
            consultarGrupo();
            consultarSubgrupo();
            llenarCombos();
            combPrecio.SelectedIndex = 0;
            txtValorInicial.SelectedIndex = 0;
        }

        private void llenarCombos()
        {
            adcArticulosPrecios.classVar.classVarIni();
            combPrecio.Items.Clear(); 
            for (int i=0; i<=6; i++)
            {
            combPrecio.Items.Add (adcArticulosPrecios.classVar.valorDestino [i]);
            }

            txtValorInicial.Items.Clear(); 

            for (int i=0; i<=5; i++)
            {
                txtValorInicial.Items.Add(adcArticulosPrecios.classVar.valorOrigen[i]);
            }
            llenarComboDatos();
            
        }
        //consulta las categorías
        public void consultarCategoria()
        {
            DaxCbos.DaxCombobx cmb = new DaxCbos.DaxCombobx();
            cmb.DaxCombosCat("C", "I", datosEmpresa.strConxAdcom, ref nivcategoria);
            nivcategoria.SelectedValue = "0";
        }

        //consulta todas las clases
        public void consultarClase()
        {
            DaxCbos.DaxCombobx cmb = new DaxCbos.DaxCombobx();
            cmb.DaxCombosCat("CL", "I", datosEmpresa.strConxAdcom, ref nivclase);
            nivclase.SelectedValue = "0";
        }

        //consulta todos los grupos

        public void consultarGrupo()
        {
            DaxCbos.DaxCombobx cmb = new DaxCbos.DaxCombobx();
            cmb.DaxCombosCat("G", "I", datosEmpresa.strConxAdcom, ref nivgrupo);
            nivgrupo.SelectedValue = "0";

        }

        //consulta todos los subgrupos
        public void consultarSubgrupo()
        {
            DaxCbos.DaxCombobx cmb = new DaxCbos.DaxCombobx();
            cmb.DaxCombosCat("S", "I", datosEmpresa.strConxAdcom, ref nivsubgrupo);
            nivsubgrupo.SelectedValue = "0";
        }


        //recibe una consulta sql para ejecutarlo en la base de datos
        //public void consultarDato(String consulta)
        //{
        //    try
        //    {
        //        misqlDa = new SqlDataAdapter(consulta, datosEmpresa.strConxAdcom);
        //        dato = new DataSet();
        //        valor = new BindingSource();
        //        misqlDa.Fill(dato, "lista");
        //        valor.DataSource = dato;
        //        valor.DataMember = "lista";
        //    }
        //    catch { }
        //}

        // muestra el  datagrid con la lista de datos para editar los precios
        private void editar_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            splitContainer1.Visible = false;
            dataGrid.BringToFront();
            dataGrid.Visible = true;
            dataGrid.ReadOnly = false;
            dataGrid.AllowUserToDeleteRows = false;
            dataGrid.AllowUserToAddRows = false;
            guardar.Visible = true;
            imprime.Visible = false;
            procesar.Visible = false;

            //contenedor.Panel1Collapsed = true;
            //'dataGrid.Visible = true;
            consulta = "select Art_codigo, LTRIM(Art_nombre) as Art_nombre, isnull(Art_precvta1,0) as PrecioVta_1" ;
            consulta += ",isnull(Art_precvta2,0) as PrecioVta_2, isnull(Art_precvta3,0) as PrecioVta_3,isnull(Art_precvta4,0) as PrecioVta_4, isnull(Art_precvta5,0) as PrecioVta_5";
            consulta += ",isnull(Art_descuen,0) as Descuento,isnull(art_limDescuento,0) as DesctoMáximo,'' as cambio from AdcArt";
            consulta += " where art_codigo > '' ";
            
            if (textHasta.Text != "")
            {
                if (porCodigo.Checked == true) { consulta += " and art_codigo >='" + textDesde.Text + "' and art_codigo <='" + textHasta.Text + "' "; }
                else { consulta += " and art_nombre >='" + textDesde.Text + "' and art_nombre <='" + textHasta.Text + "' "; }
            }

            if (nivcategoria.Text != "Todo") { consulta += "and art_categor = '" + nivcategoria.SelectedValue + "' "; }
            if (nivclase.Text  != "Todo") { consulta += "and art_clase = '" + nivclase.SelectedValue + "' "; }
            if (nivgrupo.Text != "Todo") { consulta += "and art_grupo = '" + nivgrupo.SelectedValue + "' "; }
            if (nivsubgrupo.Text != "Todo") { consulta += "and art_subgrupo = '" + nivsubgrupo.SelectedValue + "' "; }

            dataGrid.DataSource = SqlDatos.leerTablaAdcom(consulta);
            dataGrid.Columns["Art_codigo"].ReadOnly = true;//bloqueo de columna
            dataGrid.Columns["Art_nombre"].ReadOnly = true;//bloqueo de columna
            dataGrid.Columns["cambio"].Visible  = false ;
        }

        // actualiza los datos modificados en el datagrid
        private void guardarLista()
        {
            dataGrid.EndEdit();
            //DaxLib.DaxLibDigDato dlib = new DaxLib.DaxLibDigDato();
            try
            {
                if (dataGrid.Rows.Count > 0)
                {
                    for (int i = 0; i < dataGrid.Rows.Count - 1; i++)
                    {
                        if (dataGrid.Rows[i].Cells["cambio"].Value.ToString() == "S")
                        {
                        String update = "UPDATE AdcArt SET " +
                        "Art_precvta1 ='" + dataGrid.Rows[i].Cells["PrecioVta_1"].Value + "', " +
                        "Art_precvta2 ='" + dataGrid.Rows[i].Cells["PrecioVta_2"].Value + "', " +
                        "Art_precvta3 ='" + dataGrid.Rows[i].Cells["PrecioVta_3"].Value + "', " +
                        "Art_precvta4 ='" + dataGrid.Rows[i].Cells["PrecioVta_4"].Value + "', " +
                        "Art_precvta5 ='" + dataGrid.Rows[i].Cells["PrecioVta_5"].Value + "', " +
                        "Art_descuen ='" + dataGrid.Rows[i].Cells["Descuento"].Value + "'," +
                        "art_limDescuento ='" + dataGrid.Rows[i].Cells["DesctoMáximo"].Value + "'" +                        
                        " WHERE Art_codigo ='" + dataGrid.Rows[i].Cells[0].Value + "'";
                         SqlDatos.ejecutarComandoAdcom(update);
                        }
                    }
                    MessageBox.Show("La Información se ha actualizado correctamente" );
                    //opcion = panel1.Visible = true;
                    //contenedor.Panel1Collapsed = false;
                }
                else
                {
                    MessageBox.Show("No existen datos para actualizar");
                }
            }
            catch
            {
                MessageBox.Show("La Información No se ha actualizado correctamente");
            }
        }

        //lista de articulos y precios
        private void lista_Click(object sender, EventArgs e)
        {
            splitContainer1.Visible = true;
            panel1.Visible = false;
            panel2.Visible = true;
            dataGrid.DataSource = null;
            dataGrid.Columns.Clear();
            dataGrid.Visible = false;
            procesar.Visible = false;
            guardar.Visible = false;
            imprime.Visible = true;
            label11.Visible = false;
            nivsubgrupo.Visible = false;           
            }

        //Botón que actualiza los precios a modificarse segun las opciones seleccionadas
        private void procesarCambios()
        {
            string bakSsql = "";
            string Ssql = "";
            string Where = "  ";
            string sqlWhere = "";
            int nroPrecio = 0;
            try
            {
                classVar.columnaPrecio(combPrecio.Text,txtValorInicial.Text,ref cambiarPrecio,ref precioActual,ref nroPrecio); 

                if (textDesde.Text != "" && textHasta.Text != "")
                {
                    if (textDesde.Text.CompareTo(textHasta.Text) > 0)
                    {
                        MessageBox.Show("Los códigos de artículos están errados", "Filtros de artículos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    Ssql += Where + " (ADCART.Art_codigo >='" + textDesde.Text + "' and ADCART.Art_codigo <='" + textHasta.Text + "')";
                    Where = " and ";
                }

                categoria = nivcategoria.SelectedValue.ToString () ;
                clase = nivclase.SelectedValue.ToString ();
                grupo = nivgrupo.SelectedValue.ToString();
                subgrupo = nivsubgrupo.SelectedValue.ToString ();
                
                if (categoria != "0") { Ssql += Where + " Art_categor ='" + categoria + "'"; Where = " and "; }
                if (clase != "0") {Ssql += Where + " Art_clase ='" + clase + "'";Where = " and "; }
                if (grupo != "0") { Ssql += Where + " Art_grupo ='" + grupo + "'"; Where = " and "; }
                if (subgrupo != "0") { Ssql += Where + " Art_subgrup ='" + subgrupo + "'"; }

                sqlWhere = Ssql;
                
                bakSsql = "select '" + DateTime.Now.ToShortDateString() + "' as fechaCambio";
                bakSsql += "," + (combPrecio.SelectedIndex + 1).ToString () + " as nroListaPrecios";
                bakSsql += ",'' as temporada";
                bakSsql += ",'" + DatosUsuario.Identifica + "' as usuario";
                bakSsql += ",'" + Environment.MachineName + "' as equipo";
                bakSsql += ",art_codigo as producto";
                bakSsql += "," + cambiarPrecio;
                bakSsql += "," + ultimoCambio().ToString();
                bakSsql += ",'" + cambiarPrecio + "' from adcart ";
                if (sqlWhere.Length > 0 ) bakSsql += " where (" + sqlWhere + ")";

                try{nuevoValor = Convert.ToDouble("0" + txtValorFijo.Text);}catch{nuevoValor=0;}
                if (txtConsulta.Text.Length > 10)
                {
                    string selec = "(select ISNULL( " + txtConsulta.Text + ",0) as valor, art_codigo FROM ";
                    selec += "( select *,19.37 as precioCompraDoc from DaxInvDatCalPrecios ";
                    if (sqlWhere.Length > 0)
                    {
                        selec += " where art_codigo in (";
                        selec += " select art_codigo from adcart where (" + sqlWhere + ")";
                        selec += ") ";
                    }
                    selec += ") d ) p";

                    Ssql = "update adcart set " + cambiarPrecio + " = valor from " + selec;
                    Ssql += " where adcart.art_codigo = p.art_codigo";
                    variarPrecio(Ssql,  bakSsql, cambiarPrecio);
                }
                
                else if (nuevoValor != 0)
                {
                    Ssql = "Update AdcArt set " + cambiarPrecio + " = " + nuevoValor.ToString();
                    if (sqlWhere.Length > 0) Ssql += " where (" + sqlWhere + ")";
                    variarPrecio(Ssql, bakSsql, cambiarPrecio);
                    return;
                }
                else if (precioActual.Length > 5)
                {
                    string multiplica = "1";
                    string sumar = "0";
                    if (txtValorMultiplica.Text != "") multiplica = txtValorMultiplica.Text;
                    if (txtValorSuma.Text != "" ) sumar = txtValorSuma.Text;
                    Ssql = "update adcart set " + cambiarPrecio + " = ( isnull(d." + precioActual + ",0) * " + multiplica + ") + " + sumar;
                    Ssql += " from (select art_codigo," + precioActual + " from ";
                    if (precioActual == "UltimaCompra") { Ssql += " DaxUltPrecio "; }
                    else
                    {
                        if (precioActual == "CostoPromedio") { Ssql += " DaxCosProm "; }
                        else Ssql += " AdcArt ";
                    }
                    Ssql += ") d ";
                    Ssql += " where adcart.Art_Codigo = d.Art_codigo ";
                    if (sqlWhere.Length > 0) Ssql += " and (" + sqlWhere + ")";
                    variarPrecio(Ssql, bakSsql, cambiarPrecio);
                }

                MessageBox.Show("Los cambios se han realizado correctamente", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Los cambios no se han podido realizar revise las opciones seleccionadas", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        
            //calcula los valores ingresados en el panel de opciones para actualizar los respectivos precios
                
            public void variarPrecio(string comando, string guardar, string campo)
            {
                SqlDatos.ejecutarComandoAdcom("insert into adcprvtabk " + guardar);
            }
    

        //Obtiene los codigos de categoria, clase, grupo, subgrupo
        public String codigoNivel(int tipo, String nombre)
        {
            String nivel = "";
            consulta = "select Niv_abrevia from AdcNiv where Niv_nombre ='" + nombre + "'";
            DataTable miTabla = SqlDatos.leerTablaAdcom(consulta);
            if (miTabla.Rows.Count > 0)
                nivel = miTabla.Rows[0][0].ToString();
            miTabla.Dispose();
            return nivel;
        }      
        private void actualizar_Click(object sender, EventArgs e)
        {
            splitContainer1.Visible = true;
            panel1.Visible = true;
            panel2.Visible = false;
           dataGrid.DataSource = null;
            dataGrid.Columns.Clear();
            dataGrid.Visible = false;
            procesar.Visible = true;
            guardar.Visible = false;
            imprime.Visible = false;
            label11.Visible = true;
            nivsubgrupo.Visible = true;           
        }

        private void dataGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            dataGrid.Rows[e.RowIndex].Cells["cambio"].Value = "S";
        }
        private void salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void guardar_Click(object sender, EventArgs e)
        {
            guardarLista();
        }

        private void procesar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma recalcular el valor de " + combPrecio.Text,"Administración de precios",MessageBoxButtons.YesNo,MessageBoxIcon.Question ) == System.Windows.Forms.DialogResult.No ) return;
            procesarCambios();
        }

        private void imprime_Click(object sender, EventArgs e)
        {
            frmImprime ff = new frmImprime ();
            if (porCodigo.Checked == true) { 
                ff.orden = "C";
                ff.CodigoInicial = textDesde.Text;
                ff.CodigoFinal = textHasta.Text;
            } 
            else 
            { 
                ff.orden = "N";
                ff.CodigoInicial = desdeNombre.Text ;
                ff.CodigoFinal = hastaNombre.Text;
            }

            if (nivcategoria.Text != "Todo") { ff.conCategoria = nivcategoria.Text; }
            if (nivclase.Text != "Todo") { ff.conClase  = nivclase.Text; }
            if (nivgrupo.Text != "Todo") { ff.conGrupo  = nivgrupo.Text; }
            if (nivsubgrupo.Text != "Todo") { ff.conSubgrupo = nivsubgrupo.Text; }
            ff.Patappl = datosEmpresa.pathAppl;
            if (checkPrec1.Checked == true){ ff.Pv1 = "S";} else {ff.Pv1 = "N";}
            if (checkPrec2.Checked == true){ ff.Pv2 = "S";} else  { ff.Pv2 = "N";}
            if (checkPrec3.Checked == true) {ff.Pv3 = "S";} else {ff.Pv3 = "N";}
            if (checkPrec4.Checked == true) {ff.Pv4 = "S";} else {ff.Pv4 = "N";}
            if (checkPrec5.Checked == true) {ff.Pv5 = "S";} else {ff.Pv5 = "N";}
            if (checkBox3.Checked == true) {ff.Desc = "S";} else {ff.Desc  = "N";}
            if (checkBox4.Checked == true) { ff.Lim = "S"; } else { ff.Lim = "N"; }
            if (chkConIva.Checked == true) { ff.ConIva = "S"; } else { ff.ConIva = "N"; }
            ff.ShowDialog();
        }

        private void desde_Click(object sender, EventArgs e)
        {
            string Desde = textDesde.Text; 
            string NombreArticulo ="";
            buscarArticulo(ref Desde, ref NombreArticulo );
            textDesde.Text = Desde;
            desdeNombre.Text = NombreArticulo;
        }

        private void hasta_Click(object sender, EventArgs e)
        {
            string Hasta = textHasta.Text ;
            string NombreArticulo = "";
            buscarArticulo(ref Hasta, ref NombreArticulo);
            textHasta.Text = Hasta;
            hastaNombre.Text = NombreArticulo;
        }

        private void buscarArticulo(ref string txtCodigo, ref string Nombre)
        {
            Nombre = "";
            Buscar.frmBuscar businv = new Buscar.frmBuscar();
            string codart = businv.Buscar( datosEmpresa.strConxAdcom , "SELECT Art_codigo as Codigo, Art_nombre as Descripción, Art_unimed as UnMedida FROM AdcArt ", "Codigo", "Descripción", "C", "BUSQUEDA DE ARTÍCULO");
            txtCodigo = codart;
            if (txtCodigo.Length > 0) Nombre = leerArticulo(txtCodigo, datosEmpresa.strConxAdcom);
        }

        private string leerArticulo(string codigo, string strConxadcom)
        {
            DataTable dt = leerDatos("Select art_nombre from adcart where art_codigo = '" + codigo + "'",strConxadcom);
            string labArticulo = "";
            if (dt.Rows.Count > 0)
            {
                labArticulo = dt.Rows[0][0].ToString();
            }
            else
            {
                MessageBox.Show("El artículo digitado no existe", "Buscar articulo");
                labArticulo = "";
            }
            return labArticulo;
        }

        private DataTable leerDatos(string ssql, string strConxadcom)
        {
            SqlConnection conexion = new SqlConnection(strConxadcom);
            conexion.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter(ssql, conexion);
            adp.Fill(ds, "Datos");
            return ds.Tables["Datos"];
        }
        private Int64 ultimoCambio()
        {
            Int64 clave = 0;
            string ssql = "select max(claveCambio) as clave from AdcPrvtabk";
            DataTable dt = SqlDatos.leerTablaAdcom(ssql);
            if (dt.Rows.Count > 0) clave = Convert.ToInt64("0" + dt.Rows[0]["clave"].ToString());
            clave = clave + 1;
            dt.Dispose();
            return clave;
        }
        private void recuperarValor_Click(object sender, EventArgs e)
        {
            Buscar.frmBuscar progBus = new frmBuscar();
            string clave = "";
            string ssql = "select distinct(clavecambio),temporada + ' ' + cast(nrolistaprecios as varchar(4)) as listaPrecios";
            ssql += ",cast(fechaCambio as varchar(16)) as fecha, usuario + ' - ' + equipo as CambiadoPor from adcprvtabk ";
            ssql += " order by clavecambio desc";

            clave=progBus.Buscar(datosEmpresa.strConxAdcom, ssql, "clavecambio", "listaPrecios", "", "Cambios de precio efectuados");

            if (MessageBox.Show("Confirma recuperar los precios de la lista " + queLista(clave, datosEmpresa.strConxAdcom) + "\n El cambio no podrá revertirse", "Recuperar Precios cambiados", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No) return;
            RecuperarPreciosAnteriores(clave, datosEmpresa.strConxAdcom);
        }

        private string queLista(string clave, string strConexion)
        {
            string laLista = "";
            string ssql = "select temporada + ' ' + cast(nrolistaprecios as varchar(4)) as listaPrecios, cast(fechaCambio as varchar(16)) as fecha from adcprvtabk";
            ssql += " where clavecambio = " + clave;
            DataTable dt = leerDatos(ssql, strConexion);
            if (dt.Rows.Count > 0)
            {
                laLista = dt.Rows[0]["listaPrecios"].ToString() + " cambiados el " + dt.Rows[0]["fecha"].ToString();
            }
            dt.Dispose();
            return laLista;
        }
        private void RecuperarPreciosAnteriores(string precioRecuperar, string strConxadcom)
        {
            string ssql = "select top(1) campo from adcprvtabk where claveCambio = " + precioRecuperar;
            DataTable dt = SqlDatos.leerTablaAdcom(ssql);
            string campo = "";
            if (dt.Rows.Count > 0) { campo = dt.Rows[0]["campo"].ToString (); }
            if (campo == "") { MessageBox.Show("No se pudo recuperar los precios, información incompleta"); return; }

            ssql = "update adcart set " + campo + " = r1.precioOriginal from ";
            ssql += " (select producto, precioOriginal from adcprvtabk where claveCambio = 3) as r1 ";
            ssql += " where r1.producto = adcart.art_codigo";

            //if (conexion.State == ConnectionState.Closed) conexion.Open();
            //SqlCommand cmd = new SqlCommand(, conexion);
            try
            {
                SqlDatos.ejecutarComandoAdcom(ssql);
            }
            catch (Exception ee) { MessageBox.Show("no se efectuó el cambio correctamente \n" + ee.Message); return; }
            MessageBox.Show("Se recuperó los precios correctamente ") ;
        }

        private void textValor_TextChanged(object sender, EventArgs e)
        {
            if (txtValorFijo.Text.Length > 0)
            {
                txtValorInicial.Text = "";
                txtValorInicial.SelectedIndex = -1;
                txtValorInicial.Enabled = false;
            }
            else
            {
                txtValorInicial.SelectedIndex = 0; txtValorInicial.Enabled = true;
            }
        }

        private void btnGuardaFormula_Click(object sender, EventArgs e)
        {
            if (txtNombreFormula.Text.Length == 0) {MessageBox.Show("La fórmula debe tener una descripción", "formulas precio de venta", MessageBoxButtons.OK, MessageBoxIcon.Information); return;}
            if (combPrecio.Text.Length == 0) { MessageBox.Show("Debe escojer un precio al que afecte la fórmula", "formulas precio de venta", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            try
            {
                try
                {
                    datFormula.IdFormulaPvta = Convert.ToDecimal(txtNumeroFormula.Text);
                }
                catch { datFormula.IdFormulaPvta = 1; }
                datFormula.ArticuloFin = textDesde.Text;
                datFormula.ArticuloIni = textHasta.Text;
                datFormula.Categoria = nivcategoria.SelectedValue.ToString();
                datFormula.Clase = nivclase.SelectedValue.ToString();
                datFormula.Grupo = nivgrupo.SelectedValue.ToString();
                datFormula.Subgrupo = nivsubgrupo.SelectedValue.ToString();
                datFormula.Descripción = txtNombreFormula.Text;
                datFormula.FormulaValFijo = Convert.ToDecimal("0" + txtValorFijo.Text);
                datFormula.FormulaValInicial = txtValorInicial.Text;
                datFormula.consultaSQL = txtConsulta.Text;
                if (chkUsarCoeficiente.Checked) 
                { 
                    datFormula.FormulaValMultiplica = 9999; 
                }
                else
                {
                    datFormula.FormulaValMultiplica = Convert.ToDecimal("0" + txtValorMultiplica.Text);
                }
                datFormula.PrecioActualiza = combPrecio.Text;
                datFormula.snConfirma = chkConfirmarEnLinea.Checked;
                datFormula.Actualizar("select * from daxFormPv where IdFormulaPvta = " + datFormula.IdFormulaPvta.ToString());
                txtNumeroFormula.Text = datFormula.IdFormulaPvta.ToString();
                MessageBox.Show ("La fórmula se guardó correctamente","formulas precio de venta", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
            catch (Exception ee) { MessageBox.Show("No se guardó correctamente la fórmula \n" + ee.Message, "formulas precio de venta", MessageBoxButtons.OK, MessageBoxIcon.Error);}
            
        }
        private void limpiarPantalla()
        {
        }
        private void txtNumeroFormula_Leave(object sender, EventArgs e)
        {
            if (txtNumeroFormula.Text.Length > 0) leerFormula(txtNumeroFormula.Text);
        }
        private void txtNumeroFormula_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtNumeroFormula.Text.Length > 0 && e.KeyCode == Keys.Return) leerFormula(txtNumeroFormula.Text);
        }
        private void leerFormula(string nroFormula)
        {
            datFormula = new DaxFormPv(datosEmpresa.strConxAdcom);
            datFormula = DaxFormPv.Buscar(" IdFormulaPvta = " + nroFormula);
            if (datFormula == null) { datFormula = new DaxFormPv(datosEmpresa.strConxAdcom); return;}
            txtNumeroFormula.Text = datFormula.IdFormulaPvta.ToString();
            textDesde.Text=datFormula.ArticuloFin;
            textHasta.Text=datFormula.ArticuloIni;
            nivcategoria.SelectedValue=datFormula.Categoria;
            nivclase.SelectedValue=datFormula.Clase;
            nivgrupo.SelectedValue=datFormula.Grupo;
            nivsubgrupo.SelectedValue=datFormula.Subgrupo;
            txtNombreFormula.Text=datFormula.Descripción;
            txtValorFijo.Text=datFormula.FormulaValFijo.ToString();
            txtValorInicial.Text=datFormula.FormulaValInicial;
            txtValorMultiplica.Text=datFormula.FormulaValMultiplica.ToString();
            txtValorSuma.Text=datFormula.FormulaValSuma.ToString();
            combPrecio.Text=datFormula.PrecioActualiza;
            chkConfirmarEnLinea.Checked=datFormula.snConfirma;
            if (datFormula.FormulaValMultiplica == 9999) { chkUsarCoeficiente.Checked = true; txtValorMultiplica.Text = ""; }
            txtConsulta.Text = datFormula.consultaSQL;
        }

        private void btnAbrirFormula_Click(object sender, EventArgs e)
        {
            Buscar.frmBuscar busca = new frmBuscar();
            string nroFormula = busca.Buscar(datosEmpresa.strConxAdcom, "select IdFormulaPvta, Descripción from daxFormPv","IdFormulaPvta","Descripción","","Buscar fórmulas cambio de precios");
            if (nroFormula.Length > 0) leerFormula(nroFormula);
            else MessageBox.Show("NO EXISTE LA FORMULA SOLICITADA", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUsarCoeficiente.Checked)
            {
                txtValorMultiplica.Text = "9999";
                txtValorMultiplica.Enabled = false;
            }
            else
            {
                if (txtValorMultiplica.Text == "9999") txtValorMultiplica.Text = "0";
                txtValorMultiplica.Enabled = true;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (combPrecio.Text.Length > 0 && txtConsulta.Text.Length > 0)
            {

                if (txtArtPrueba.Text.Length == 0 || txtArtPruebaNom.Text.Length == 0)
                {
                    MessageBox.Show("Debe registrar un artículo para evaluar la fórmula de precio");
                    return;
                }
                else
                {
                    MessageBox.Show("La consulta produjo el siguiente resultado : \n " + combPrecio.Text + " = " + Datos.probarConsultaSql(txtConsulta.Text,txtArtPrueba.Text));
                }
            }
            else
            {
                MessageBox.Show("Ingrese una ´consulta para poder evaluarla"); return;
            }
        }

        private void comboDatos_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtConsulta.Text += " " + comboDatos.Text + " ";
            txtConsulta.Focus();
            txtConsulta.Select(txtConsulta.TextLength, 1);
        }
        private void llenarComboDatos()
        {
            comboDatos.DataSource = null ;
            comboDatos.Items.Clear();
            string ssql = "select top(1) *,19.73 as precioCompraDoc from DaxInvDatCalPrecios  " ;
            DataTable dt = SqlDatos.leerTablaAdcom (ssql);
            foreach (DataColumn colm in dt.Columns)
            {
                if (colm.ColumnName.ToUpper() != "ART_CODIGO" && colm.ColumnName.ToUpper() != "ART_NOMBRE")
                {
                    comboDatos.Items.Add(colm.ColumnName);
                }
            }
            dt.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string ArtPrueba = txtArtPrueba.Text;
            string NombreArticulo = "";
            buscarArticulo(ref ArtPrueba, ref NombreArticulo);
            txtArtPrueba.Text = ArtPrueba;
            txtArtPruebaNom.Text = NombreArticulo;

        }
    }
}
