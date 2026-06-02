using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DattCom;

namespace DaxConceptos
{
    public partial class frmMantConceptos : Form
    {
        ClassDoc.Servicios datosConceptos = new ClassDoc.Servicios();
        Int16 estadoOperacion = 0;  //0 ninguna 1 nuevo 2 abierto
        bool nuevoDeEntrada = false;
        public frmMantConceptos(bool nuevo)
        {
                InitializeComponent();
                cargarCombos();
                nuevoDeEntrada = nuevo;
        }
        private void frmMantConceptos_Load(object sender, EventArgs e)
        {
            if (nuevoDeEntrada) IniciarNuevoRegistro();
            else actualizarBotones();
        }
        private void IniciarNuevoRegistro()
        {
            datosConceptos = new ClassDoc.Servicios(datosEmpresa.strConxAdcom);
            estadoOperacion = 1;
            actualizarBotones();
        }
        private void cargarCombos()
        {
            DaxCombobx.CargCmbBox como = new DaxCombobx.CargCmbBox();
            //como.DaxCombosReferencia("Medidas", datosEmpresa.strConxSyscod, ref cmbMedidas, false);
            como.DaxCombosReferencia("GrupoConceptos", datosEmpresa.strConxSyscod, ref cmbGrupos, false);
            cmbGrupos.SelectedValue = "";
            cmbGrupos.Text = "";
        }
        private void btnAbrir_Click(object sender, EventArgs e)
        {
            BuscServ prog = new BuscServ("", "C", "T", "", "D", false, true, false);
            string abreviacion = prog.IniServicio();
            cargarDatos(abreviacion);
            prog.Dispose();
        }
        private void cargarDatos(string abreviacion)
        {
            datosConceptos = new ClassDoc.Servicios(datosEmpresa.strConxAdcom);
            datosConceptos = ClassDoc.Servicios.Buscar(" sev_codigo = '" + abreviacion + "' and (isnull(sev_ingBanco,0) <> 0 or isnull(sev_egrBanco,0) <> 0)  ");
            if (datosConceptos != null) moverClaseADatos();
        }
        private void moverClaseADatos()
        {
            CtaMtn.Cuenta ctactb = new CtaMtn.Cuenta();

            txtAbreviacion.Text = datosConceptos.Sev_codigo;
            txtDescripcion.Text = datosConceptos.Sev_nombre;
            //chkCompras.Checked = datosConceptos.sev_compras;
            //chkVentas.Checked = datosConceptos.sev_ventas;
            chkIngresoBancos.Checked = datosConceptos.sev_ingbanco;
            chkEgresoBancos.Checked = datosConceptos.sev_egrbanco;
            //btnBienes.Checked = (datosConceptos.Sev_SriBien > 0);
            //chkGrabaIva.Checked = datosConceptos.Sev_sniva;
            //txtPrecioVenta.Text = datosConceptos.Sev_precvta.ToString();
            //chkPrecioIncluyeIva.Checked = (datosConceptos.Sev_IncIva > 0);
            //cmbTipoIva.SelectedValue = datosServicio.Sev_TipoSerSri;
            //cmbMedidas.SelectedValue = datosConceptos.Sev_unimed;
            cmbGrupos.SelectedValue = datosConceptos.Sev_Grupo;
            txtIdCont1.Text = datosConceptos.Sev_idcta;
            txtIdCont2.Text = datosConceptos.Sev_idcta2;
            txtIdCont3.Text = datosConceptos.Sev_idcta3;
            txtIdCont4.Text = datosConceptos.Sev_idcta4;

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

            //if (datosConceptos.Sev_TipoCos == "") btnNoAfecta.Checked = true;
            //else if (datosConceptos.Sev_TipoCos == "U") btnPorUnidad.Checked = true;
            //else if (datosConceptos.Sev_TipoCos == "V") btnPorValor.Checked = true;
            //else if (datosConceptos.Sev_TipoCos == "P") btnPorPeso.Checked = true;

            datosConceptos.Sev_TipoCos = "";

            //txtPorComision.Text = datosConceptos.Sev_PorctjComision.ToString();

            estadoOperacion = 2;
            actualizarBotones();

        }
        private void moverDatosAClase()
        {
            if (datosConceptos == null)
            {
                //MessageBox.Show("datosConceptos es NULL!");
                datosConceptos = new ClassDoc.Servicios(); // Reinstanciar
            }
            datosConceptos.Sev_codigo = txtAbreviacion.Text;
            datosConceptos.Sev_nombre = txtDescripcion.Text;
            datosConceptos.sev_compras = false;
            datosConceptos.sev_ventas = false;
            //if (datosConceptos.sev_compras == false && datosConceptos.sev_ventas == false) datosConceptos.sev_ventas = true;
            datosConceptos.sev_ingbanco = chkIngresoBancos.Checked;
            datosConceptos.sev_egrbanco = chkEgresoBancos.Checked;
            datosConceptos.Sev_SriBien = 0;
            datosConceptos.Sev_SriBien = 0; 
            datosConceptos.Sev_sniva = false;
            datosConceptos.Sev_precvta = 0;
            datosConceptos.Sev_IncIva = 0;
            datosConceptos.Sev_TipoSerSri = ""; //cmbTipoIva.SelectedValue.ToString();
            datosConceptos.Sev_unimed = "";

            try
            {
                datosConceptos.Sev_Grupo = cmbGrupos.SelectedValue.ToString();
            }
            catch { datosConceptos.Sev_Grupo = ""; }
            datosConceptos.Sev_idcta = txtIdCont1.Text;
            datosConceptos.Sev_idcta2 = txtIdCont2.Text;
            datosConceptos.Sev_idcta3 = txtIdCont3.Text;
            datosConceptos.Sev_idcta4 = txtIdCont4.Text;
            datosConceptos.Sev_PorctjComision = 0;

            //datosConceptos.Sev_PorctjComision = Convert.ToDecimal("0" + txtPorComision.Text);
            //datosServicio.sev_cruceclientes=optAfectaVentas.Checked;
            //datosServicio.sev_cruceproveedores=optAfectaCompras.Checked;

            estadoOperacion = 0;
            if (datosConceptos.Actualizar().Substring(0, 5) != "Error") { limpiarDatos(); actualizarBotones(); }
        }

        private void limpiarDatos()
        {
            txtAbreviacion.Text = "";
            txtDescripcion.Text = "";
            //btnBienes.Checked = (datosConceptos.Sev_SriBien > 0);
            //chkGrabaIva.Checked = datosConceptos.Sev_sniva;
            //txtPrecioVenta.Text = "";
            //chkPrecioIncluyeIva.Checked = (datosConceptos.Sev_IncIva > 0);
            //cmbTipoIva.SelectedValue = datosServicio.Sev_TipoSerSri;
            //cmbMedidas.SelectedValue = datosConceptos.Sev_unimed;
            txtIdCont1.Text = "";
            txtIdCont2.Text = "";
            txtIdCont3.Text = "";
            txtIdCont4.Text = "";

            lblCuenta1.Text = "";
            lblCuenta2.Text = "";
            lblCuenta3.Text = "";
            lblCuenta4.Text = "";

            optNoafectaDoc.Checked = true;
            estadoOperacion = 0;
            actualizarBotones();

            //txtPorComision.Text = "";

            //chkCompras.Checked = true;
            //chkVentas.Checked = false;

            //btnBienes.Checked = false;
            //btnNoAfecta.Checked = true;

            //chkHotel.Checked = false;
            //chkAtencionMedica.Checked = false;

            estadoOperacion = 0;
            actualizarBotones();

        }
        private void actualizarBotones()
        {
            btnAbrir.Enabled = (estadoOperacion == 0);
            btnGuardar.Enabled = (estadoOperacion != 0);
            btnCancelar.Enabled = (estadoOperacion == 1);
            btnEliminar.Enabled = (estadoOperacion == 2);
            BtnNuevo.Enabled = (estadoOperacion == 0);
            btnCerrar.Enabled = (estadoOperacion > 0);
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
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)) return;
            e.Handled = true;
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
