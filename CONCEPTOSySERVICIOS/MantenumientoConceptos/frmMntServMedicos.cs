using DattCom;
using System;
using System.Data;
using System.Windows.Forms;
namespace DaxConceptos
{
    public partial class frmMntServMedicos : Form
    {
        ClassDoc.Servicios datosServicio = new ClassDoc.Servicios();
        Int16 operacionCurso = 0;  //0 ninguna 1 nuevo 2 abierto
        bool nuevoDeEntrada = false;
        public frmMntServMedicos(bool nuevo)
        {
            InitializeComponent();
            cargarCombos();
            nuevoDeEntrada = nuevo;
        }
        private void frmMntServicios_Load(object sender, EventArgs e)
        {
            if (nuevoDeEntrada) IniciarNuevoRegistro();
            else actualizarBotones();
        }
        private void IniciarNuevoRegistro()
        {
            datosServicio = new ClassDoc.Servicios(datosEmpresa.strConxAdcom);
            operacionCurso = 1;
            actualizarBotones();
        }
        private void cargarCombos()
        {
            DaxCombobx.CargCmbBox como = new DaxCombobx.CargCmbBox();
            como.DaxCombosReferencia("Medidas", datosEmpresa.strConxSyscod, ref cmbMedidas, false);
            //Medclass.utility.CargaComboGrupoMedico(cmbGrupos,datosEmpresa.strConxAdcom);

            DaxMedic.utility.CargaComboGruposServicios(cmbClase, datosEmpresa.strConxAdcom, "CL", false);
            DaxMedic.utility.CargaComboGruposServicios(cmbGrupos, datosEmpresa.strConxAdcom, "G", false);
            try
            {
                cmbGrupos.SelectedIndex = 0;
                cmbClase.SelectedIndex = 0;
            }
            catch { }

            DataTable dt = SqlDatos.leerTablaIniSis("select Abreviación , Descripcion   from Daxsys.dbo.syscod where TipoReferencia ='TipServMedico' and Abreviación <> '#' ");
            cmbTipoServicio.ValueMember = "Abreviación";
            cmbTipoServicio.DisplayMember = "Descripcion";
            cmbTipoServicio.DataSource = dt;
            DaxMedic.utility.CargaComboGruposServicios(cmbGrupos, datosEmpresa.strConxAdcom, "G", false);

        }
        private void btnAbrir_Click(object sender, EventArgs e)
        {
            BuscaServMed prog = new BuscaServMed("", "", "", false, true);
            string abreviacion = prog.IniServicio();
            cargarDatos(abreviacion);
            prog.Dispose();
        }
        private void cargarDatos(string abreviacion)
        {
            datosServicio = new ClassDoc.Servicios(datosEmpresa.strConxAdcom);
            datosServicio = ClassDoc.Servicios.Buscar(" sev_codigo = '" + abreviacion + "' ");
            if (datosServicio != null) moverClaseADatos();
        }
        private void moverClaseADatos()
        {
            CtaMtn.Cuenta  ctactb = new CtaMtn.Cuenta();
            
            txtAbreviacion.Text = datosServicio.Sev_codigo;
            txtDescripcion.Text = datosServicio.Sev_nombre;
            //chkCompras.Checked = datosServicio.sev_compras;
            //chkVentas.Checked = datosServicio.sev_ventas;
            //chkIngresoBancos.Checked = datosServicio.sev_ingbanco;
            //chkEgresoBancos.Checked = datosServicio.sev_egrbanco;
            //btnBienes.Checked = (datosServicio.Sev_SriBien > 0);
            chkGrabaIva.Checked = datosServicio.Sev_sniva;
            txtPrecioVenta.Text = datosServicio.Sev_precvta.ToString();
            chkPrecioIncluyeIva.Checked = (datosServicio.Sev_IncIva > 0);
            //cmbTipoIva.SelectedValue = datosServicio.Sev_TipoSerSri;
            cmbMedidas.SelectedValue = datosServicio.Sev_unimed;
            cmbGrupos.SelectedValue = datosServicio.Sev_Grupo;
            //cmbCategoria.SelectedValue = datosServicio.Sev_Categoria;
            cmbClase.SelectedValue = datosServicio.Sev_Clase;
            txtIdCont1.Text = datosServicio.Sev_idcta;
            txtIdCont2.Text = datosServicio.Sev_idcta2;
            txtIdCont3.Text = datosServicio.Sev_idcta3;
            txtIdCont4.Text = datosServicio.Sev_idcta4;

            string nomcta = txtIdCont1.Text;
            lblCuenta1.Text = ctactb.NombreCuentaContable(ref nomcta);
            nomcta = txtIdCont2.Text;
            lblCuenta2.Text = ctactb.NombreCuentaContable(ref nomcta);
            nomcta = txtIdCont3.Text;
            lblCuenta3.Text = ctactb.NombreCuentaContable(ref nomcta);
            nomcta = txtIdCont4.Text;
            lblCuenta4.Text = ctactb.NombreCuentaContable(ref nomcta);

            //optNoafectaDoc.Checked = true;
            // optAfectaVentas.Checked = datosServicio.sev_cruceclientes;
            //optAfectaCompras.Checked = datosServicio.sev_cruceproveedores;

            //if (datosServicio.Sev_TipoCos == "") btnNoAfecta.Checked = true;
            //else if (datosServicio.Sev_TipoCos == "U") btnPorUnidad.Checked = true;
            //else if (datosServicio.Sev_TipoCos == "V") btnPorValor.Checked = true;
            //else if (datosServicio.Sev_TipoCos == "P") btnPorPeso.Checked = true;


            txtPorComision.Text = datosServicio.Sev_PorctjComision.ToString();
            cmbTipoServicio.SelectedValue = datosServicio.TipServMedico;
            //chkAtencionMedica.Checked = (datosServicio.Sev_Categoria == "D");
            //chkHotel.Checked = (datosServicio.Sev_Categoria == "H");
            //chkRestaurante.Checked = (datosServicio.Sev_Categoria == "R");
            operacionCurso = 2;
            actualizarBotones();

        }
        private void moverDatosAClase()
        {
            datosServicio = new ClassDoc.Servicios();
            datosServicio.Sev_codigo = txtAbreviacion.Text;
            datosServicio.Sev_nombre = txtDescripcion.Text;
            datosServicio.sev_compras = true;
            datosServicio.sev_ventas = true;
            //if (datosServicio.sev_compras == false && datosServicio.sev_ventas == false) datosServicio.sev_ventas = true;
            datosServicio.sev_ingbanco = false;    //chkIngresoBancos.Checked;
            datosServicio.sev_egrbanco = false;  //chkEgresoBancos.Checked;
            datosServicio.Sev_SriBien = 0;
            //if (btnBienes.Checked == true) { datosServicio.Sev_SriBien = 1; }
            datosServicio.Sev_sniva = chkGrabaIva.Checked;
            datosServicio.Sev_precvta = Convert.ToDecimal("0" + txtPrecioVenta.Text);
            datosServicio.Sev_IncIva = 0;
            if (chkPrecioIncluyeIva.Checked == true) { datosServicio.Sev_IncIva = 1; }
            try
            {
                datosServicio.Sev_TipoSerSri = ""; //cmbTipoIva.SelectedValue.ToString();
            }
            catch { datosServicio.Sev_TipoSerSri = ""; }


            try
            {
                datosServicio.Sev_unimed = cmbMedidas.SelectedValue.ToString();
            }
            catch { datosServicio.Sev_unimed = "UND"; }


            datosServicio.Sev_Categoria = "D";
            try
            {
                datosServicio.Sev_Clase = cmbClase.SelectedValue.ToString();
            }
            catch { datosServicio.Sev_Clase = ""; }
            try
            {
                datosServicio.Sev_Grupo = cmbGrupos.SelectedValue.ToString();
            }
            catch { datosServicio.Sev_Grupo = ""; }


            datosServicio.Sev_idcta = txtIdCont1.Text;
            datosServicio.Sev_idcta2 = txtIdCont2.Text;
            datosServicio.Sev_idcta3 = txtIdCont3.Text;
            datosServicio.Sev_idcta4 = txtIdCont4.Text;
            datosServicio.Sev_PorctjComision = Convert.ToDecimal("0" + txtPorComision.Text);
            //datosServicio.sev_cruceclientes=optAfectaVentas.Checked;
            //datosServicio.sev_cruceproveedores=optAfectaCompras.Checked;
            operacionCurso = 0;
            //if (chkHotel.Checked) datosServicio.Sev_Categoria = "H";
            //if (chkRestaurante.Checked) datosServicio.Sev_Categoria = "R";
            //if (chkAtencionMedica.Checked) 
            try
            {
                datosServicio.TipServMedico = cmbTipoServicio.SelectedValue.ToString();
            }catch { datosServicio.TipServMedico="";}
            if (datosServicio.Actualizar().Substring(0, 5) != "Error") { limpiarDatos(); actualizarBotones(); }
              
        }

        private void limpiarDatos()
        {
            txtAbreviacion.Text = "";
            txtDescripcion.Text = "";
            //btnBienes.Checked = (datosServicio.Sev_SriBien > 0);
            chkGrabaIva.Checked = false;
            txtPrecioVenta.Text = "";
            chkPrecioIncluyeIva.Checked = (datosServicio.Sev_IncIva > 0);
            //cmbTipoIva.SelectedValue = datosServicio.Sev_TipoSerSri;
            cmbMedidas.SelectedValue = datosServicio.Sev_unimed;
            txtIdCont1.Text = "";
            txtIdCont2.Text = "";
            txtIdCont3.Text = "";
            txtIdCont4.Text = "";

            lblCuenta1.Text = "";
            lblCuenta2.Text = "";
            lblCuenta3.Text = "";
            lblCuenta4.Text = "";

            //optNoafectaDoc.Checked = true;
            operacionCurso = 0;
            actualizarBotones();

            txtPorComision.Text = "";

            //chkCompras.Checked = true;
            //chkVentas.Checked = false;

            //btnBienes.Checked = false;
            //btnNoAfecta.Checked = true;

            //chkHotel.Checked = false;
            //chkAtencionMedica.Checked = false;
            operacionCurso = 0;
            actualizarBotones();

            cmbGrupos.SelectedValue = "";
            cmbGrupos.Text = "";

        }
        private void actualizarBotones()
        {
            btnAbrir.Enabled = (operacionCurso == 0);
            btnGuardar.Enabled = (operacionCurso > 0);
            btnCancelar.Enabled = (operacionCurso == 1);
            btnEliminar.Enabled = (operacionCurso == 2);
            BtnNuevo.Enabled = (operacionCurso == 0);
            btnCerrar.Enabled = (operacionCurso > 0);
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            IniciarNuevoRegistro();
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma ELIMINAR el servicio actual ?", "Elimina servicios", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No) return;
            if (classConceptos.conceptoUtilizado(txtAbreviacion.Text))
            { MessageBox.Show("No se puede eliminar este servicio, existen documentos que lo utilizan"); }
            else
            {
                ClassDoc.Servicios datosServicio = new ClassDoc.Servicios(datosEmpresa.strConxAdcom);
                string resp = datosServicio.Borrar("select * from adcserv where sev_codigo = '" + txtAbreviacion.Text + "'");
                limpiarDatos();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma cancelar los cambios actuales ?", "CANCELAR CAMBIOS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No) return;
            limpiarDatos();
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma CERRAR el servicio actual ?", "CERRAR SERVICIO CONSULTADO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No) return;
            limpiarDatos();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            moverDatosAClase();
        }
        private void ponerCuentaContable(ref TextBox text, ref Label lab)
        {
            CtaMtn.BuscaCta prog = new CtaMtn.BuscaCta();
            string Nombre = "";
            string tipo = "I";
            text.Text = prog.BuscaCtaCtb(ref Nombre, ref tipo);
            lab.Text = Nombre;
            prog = null;
        }
        private void txtPrecioVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar) || e.KeyChar == Convert.ToChar(".")) return;
            e.Handled = true;
        }

        private void btnIdc1_Click(object sender, EventArgs e)
        {
            ponerCuentaContable(ref txtIdCont1, ref lblCuenta1);
        }
        private void btnIdc2_Click(object sender, EventArgs e)
        {
            ponerCuentaContable(ref txtIdCont2, ref lblCuenta2);
        }
        private void btnIdc3_Click(object sender, EventArgs e)
        {
            ponerCuentaContable(ref txtIdCont3, ref lblCuenta3);
        }
        private void btnIdc4_Click(object sender, EventArgs e)
        {
            ponerCuentaContable(ref txtIdCont4, ref lblCuenta4);
        }

        private void txtAbreviacion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtAbreviacion.Text.Length > 0)
            {
                cargarDatos(txtAbreviacion.Text);

            }
        }

        private void txtAbreviacion_Leave(object sender, EventArgs e)
        {
            if (txtDescripcion.Text.Length == 0 && txtAbreviacion.Text.Length > 0)
            {
                cargarDatos(txtAbreviacion.Text);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            sesSrv.FrmNivServ niv = new sesSrv.FrmNivServ();
            niv.ShowDialog();
        }
    }
}
