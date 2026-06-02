using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using MantCtb;
namespace DaxBan
{
     internal partial class CtasBanForm : Form
    {

        String consulta = "";
        String insertar = "";
        String actualizar = "";
        String eliminar = "";

        //variables a insertar en la tabla
        String Cta_Codigo = "";
        String Bco_Codigo = "";
        String Bco_Nombre = "";
        String Bco_NumCta = "";
        String Bco_TipoCta = "";
        double Bco_Saldo = 0;
        String Bco_Fecha = "";

        String codigoCta = "";
        String abreviaturaBanco = "";

        int contador = 0;

        internal  CtasBanForm()
        {
            InitializeComponent();
            modoInicial();
        }

        private void CtasBanForm_Load(object sender, EventArgs e)
        {
            consultarBancos();        
        }

        //CARGAR LOS BANCOS EN EL COMBOBOX
        public void consultarBancos()
        {
            try
            {
                DaxCbos.DaxCombobx combo = new DaxCbos.DaxCombobx();
                combo.DaxCombosBancos(SysEmpDatt.datosEmpresa.strConxAdcom, ref bancocomboBox);//conectarAdcom.ConnectionString
            }
            catch { }
        }

        //MUESTRA DATOS EN LOS CUADRO DE TEXTO CUANDO ABRIMOS UN REGISTRO
        public void mostrarDatos()
        {
            if (abreviaturaBanco == null) return;
            consulta = " select *  from AdcCtaBco where Bco_Codigo = '" + abreviaturaBanco.Trim() + "' ";
            DataTable dato = SysEmpDatt.SqlDatos.leerTablaAdcom(consulta);
            if (dato.Rows.Count > 0)
            {
                abrevtextBox.Text = Convert.ToString(dato.Rows[0]["Bco_Codigo"]).Trim();
                numeroCuentatextBox.Text = Convert.ToString(dato.Rows[0]["Bco_NumCta"]).Trim();
                ctatextBox.Text = Convert.ToString(dato.Rows[0]["Cta_Codigo"]).Trim();
                int index = bancocomboBox.FindString(Convert.ToString(dato.Rows[0]["Bco_Nombre"]).Trim());
                bancocomboBox.SelectedIndex = index;
                String tipo = Convert.ToString(dato.Rows[0]["Bco_TipoCta"]).Trim();
                if(tipo == "C"){
                    corrienteradioButton.Checked = true;
                }
                else if (tipo == "I")
                {
                    inversiradioButton.Checked = true;
                }
                else if (tipo == "A")
                {
                    ahorroradioButton.Checked = true;
                }
            }
            dato.Dispose();
        }

        //CONSULTA SI LA ABREVIATURA EXISTE 
        public int existeAbreviatura()
        {
            String abreviatura = abrevtextBox.Text.Trim();
            consulta = "select Bco_Codigo from AdcCtaBco where Bco_Codigo = '" + abreviatura + "'";
            DataTable dato = SysEmpDatt.SqlDatos.leerTablaAdcom(consulta);
            contador = 0;
            if (dato.Rows.Count > 0)
            {
                contador++;
            }
            dato.Dispose();
            return contador;
        }
        
        //CONSULTA SI EXISTE EL CODIGO DE LA CUENTA INGRESADA
        public int existeCuentaContable()
        {
            contador = 1;
            consulta = "select Cta_codigo from AdcCta where Cta_codigo = '" + ctatextBox.Text.Trim() + "'";
            DataTable dato = SysEmpDatt.SqlDatos.leerTablaAdcom(consulta);
            if (dato.Rows.Count == 0)  
                if (MessageBox.Show("Cuenta contable del banco errada, confirma crear la cuenta bancaria ? ", "CREACION CUENTA BANCARIA", MessageBoxButtons.YesNo ) == System.Windows.Forms.DialogResult.No)
                {
                    ctatextBox.Text = "";
                    contador=0;
                }
            dato.Dispose();
            return contador;
        }                   
        private Boolean  abreviaturaUtilizada(string Abreviatura)
        {
            String abreviatura = abrevtextBox.Text.Trim();
            consulta = "select top 1 Doc_BancoOrigen from AdcDoc where Doc_BancoOrigen = '" + abreviatura + "'";
            DataTable dato = SysEmpDatt.SqlDatos.leerTablaAdcom(consulta);
            if (dato.Rows.Count > 0)
            {
                MessageBox.Show("La cuenta bancaria está siendo utilizada, no puede eliminarse");
                abrevtextBox.Text = "";
                return true;
            }
            else
            dato.Dispose();
            return false;
        }

        private void nuevotoolStripButton_Click(object sender, EventArgs e)
        {
            limpiar();
            abrirtoolStripButton.Visible = false;
            permiteEscritura();
        }

        //BOTON ABRIR
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            limpiar();
            eliminartoolStripButton.Visible = true;
            permiteEscritura();
            abrevtextBox.ReadOnly = true;
            Buscar.frmBuscar buscar = new Buscar.frmBuscar();//INICIALIZA LA LIBRERIA BUSCAR PARA CARGAR EL BUSCADOR
            consulta = "SELECT Bco_Codigo, Bco_Nombre FROM AdcCtaBco";
            abreviaturaBanco = Convert.ToString(buscar.Buscar(SysEmpDatt.datosEmpresa.strConxAdcom, consulta, "Bco_Codigo", "Bco_Nombre", "", "BusquedaCuentasBancarias"));//
            mostrarDatos();

        //METODO MUESTRA DATOS DEL REGISTRO ABIERTO           
        }

        private void guardartoolStripButton_Click(object sender, EventArgs e)
        {

            if (existeCuentaContable() == 0 ) return;

                Bco_Nombre = Convert.ToString(bancocomboBox.Text);
                if (abrevtextBox.Text.Trim().Length > 3)
                {
                    MessageBox.Show("Utilice un máximo de 3 caracteres para la abreviación del Banco ");
                    abrevtextBox.Text = "";//si es mayor a tres debe de terminar la ejecucion
                    return;
                }

                if (abrevtextBox.Text.Trim() == "")
                {
                    abrevtextBox.Focus();
                    MessageBox.Show("No ha registrado la abrevición de la cuenta bancaria");
                    return;
                }
                if (numeroCuentatextBox.Text.Trim() == "")
                {
                    numeroCuentatextBox.Focus();
                    MessageBox.Show("No ha registrado el numero de la cuenta bancaria");
                    return;
                }
                if (abrevtextBox.Text.Trim().Length > 20)
                {
                    MessageBox.Show("Nº de cuenta incorrecto se excede de los 20 caracteres");
                    numeroCuentatextBox.Text = "";
                    return ;
                }

                Bco_Codigo = abrevtextBox.Text.Trim();
                Bco_NumCta = numeroCuentatextBox.Text.Trim();
                Cta_Codigo = ctatextBox.Text.Trim();
                if (corrienteradioButton.Checked) { Bco_TipoCta = "C"; }
                else if (ahorroradioButton.Checked) { Bco_TipoCta = "A"; }
                else if (inversiradioButton.Checked) { Bco_TipoCta = "I"; }

                if (existeAbreviatura() != 0)
                {
                    try
                    {
                        actualizar = "update AdcCtaBco set Bco_NumCta = '" + Bco_NumCta + "', Bco_TipoCta = '" + Bco_TipoCta + "', Cta_Codigo = '"
                    + Cta_Codigo + "', Bco_Codigo = '" + Bco_Codigo + "', Bco_Nombre = '" + Bco_Nombre + "', Bco_CodAlex = '" + bancocomboBox.SelectedValue + "'  where Bco_Codigo = '" + abreviaturaBanco.Trim() + "' ";
                        SysEmpDatt.SqlDatos.ejecutarComandoAdcom(actualizar);
                        modoInicial();
                    }
                    catch
                    {
                        MessageBox.Show("La Información NO se ha actualizado correctamente");
                    }
                }
                else
                {
                    try
                    {
                        insertar = "insert into AdcCtaBco values ('" + ctatextBox.Text.Trim() + "', '" + Bco_Codigo + "', '" + bancocomboBox.SelectedValue + "', '" + Bco_Nombre + "', '" + Bco_NumCta + "', '" + Bco_TipoCta + "', " + Bco_Saldo + ", '" + Bco_Fecha + "')";
                        SysEmpDatt.SqlDatos.ejecutarComandoAdcom(insertar);
                        modoInicial();
                    }
                    catch (Exception ee)
                    {
                        MessageBox.Show("No se pudo guardar correctamente la nueva cuenta bancaria /n" + ee.Message  );
                    }
                }
        }       

        private void salirtoolStripButton_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }

        private void cancelartoolStripButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro que desea cancelar?, Se perdera toda la información", "AdcomDx", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                modoInicial();
            }
        }

        //METODO QUE ESTABLECE EL MODO INICIAL DE LOS COMPONENTES 
        public void modoInicial()
        {
            abrevtextBox.Text = "";
            ctatextBox.Text = "";
            numeroCuentatextBox.Text = "";
            guardartoolStripButton.Visible = false;
            cancelartoolStripButton.Visible = false;
            eliminartoolStripButton.Visible = false;
            nuevotoolStripButton.Visible = true;
            abrirtoolStripButton.Visible = true;
            imprimirtoolStripButton.Visible = true;
            soloLectura();
        }

        //LIMPIA LOS COMPONENTES 
        public void limpiar()
        {
            abrevtextBox.Text = "";
            ctatextBox.Text = "";
            numeroCuentatextBox.Text = "";
            guardartoolStripButton.Visible = true;
            cancelartoolStripButton.Visible = true;
            eliminartoolStripButton.Visible = false;
            nuevotoolStripButton.Visible = true;
            abrirtoolStripButton.Visible = true;
            imprimirtoolStripButton.Visible = true;
            buscarbutton.Enabled = true;
            bancocomboBox.Enabled = true;
            tipoCtagroupBox.Enabled = true;
        }

        //PERMITE ESCRIBIR CUANDO ABRIMOS REGISTROS O CREAMOS NUEVO 
        public void permiteEscritura() {
            abrevtextBox.ReadOnly = false;
            numeroCuentatextBox.ReadOnly = false;
            ctatextBox.ReadOnly = false;
        }

        //NO PERMITE INGRESAR MIENTRAS NO DE CLIC EN NUEVO O ABRIR
        public void soloLectura()
        {
            abrevtextBox.ReadOnly = true;
            numeroCuentatextBox.ReadOnly = true;
            ctatextBox.ReadOnly = true;
            buscarbutton.Enabled = false;
            bancocomboBox.Enabled = false;
            tipoCtagroupBox.Enabled = false;
        }


        private void eliminartoolStripButton_Click(object sender, EventArgs e)
        {                        
            try
            {
                if (validaeliminar(abreviaturaBanco) == false)
                    return;
                eliminar = " delete from AdcCtaBco where Bco_Codigo = '" + abreviaturaBanco.Trim() + "' ";
                SysEmpDatt.SqlDatos.ejecutarComandoAdcom (eliminar);
                modoInicial();
            }
            catch
            {
                MessageBox.Show("El registro no se ha podido eliminar");
            }            
        }
        private Boolean  validaeliminar(string Codigo)
        {
            Boolean vale = false;
            DialogResult Resp;
            Resp = MessageBox.Show ("Seguro desea eliminar la cuenta bancaria " + codigoCta + " ","Eliminar Cuenta Bancaria",MessageBoxButtons.YesNo ) ;
            if (Resp == System.Windows.Forms.DialogResult.Yes)
            {
                if (abreviaturaUtilizada(Codigo) == false)
                    vale = true;
            }
            return vale;
        }
        private void imprimirtoolStripButton_Click(object sender, EventArgs e)
        {
            ImpForm impForm = new ImpForm();
            impForm.Show(this);
        }     

        private void bancocomboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void numeroCuentatextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == 45)//PERMITA LOS GUIONES 
            { }
            else if (e.KeyChar == 8)//PERMITE TECLA DELETE
            { }
            else
            { e.Handled = true; }
        }

        private void buscarCtaContable_Click(object sender, EventArgs e)
        {
            String nombre = "";
            String var = "S";
            MantCtb.BuscaCta busca = new BuscaCta();
            String codigo = busca.BuscaCtaCtb (ref nombre, ref var);
            ctatextBox.Text = codigo;
        }

        private void abrevtextBox_Validating(object sender, CancelEventArgs e)
        {

            if (existeAbreviatura() != 0)
            {
                abreviaturaBanco = abrevtextBox.Text ;
                mostrarDatos();//METODO MUESTRA DATOS DEL REGISTRO ABIERTO                        
            }
            
            }

        private void abrevlabel_Click(object sender, EventArgs e)
        {

        }
    }
}
