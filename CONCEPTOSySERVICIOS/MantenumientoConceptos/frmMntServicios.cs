using System;
using System.Data;
using System.Data.SqlClient ;
using System.IO;
using System.Windows.Forms;
using DattCom;
namespace DaxConceptos
{
    public partial class frmMntServicios : Form
    {
        ClassDoc.Servicios datosServicio = new ClassDoc.Servicios();
        Int16 estadoOperacion = 0;  //0 ninguna 1 nuevo 2 abierto
        bool nuevoDeEntrada = false;
        string pathImagenes = "";
        string txtNombreImagen = "";

        public frmMntServicios(bool nuevo)
        {
            InitializeComponent();
            cargarCombos();            
            nuevoDeEntrada = nuevo;
            LeerPatDeImagenes();
        }
        private void frmMntServicios_Load(object sender, EventArgs e)
        {
            if (nuevoDeEntrada) IniciarNuevoRegistro();
            else actualizarBotones();
        }
        private void IniciarNuevoRegistro()
        {
            datosServicio = new ClassDoc.Servicios(datosEmpresa.strConxAdcom);
            estadoOperacion = 1;
            actualizarBotones();
        }
        private void cargarCombos()
        {
            DaxCombobx.CargCmbBox como = new DaxCombobx.CargCmbBox();
            como.DaxCombosReferencia("Medidas", datosEmpresa.strConxSyscod, ref cmbMedidas, false);
            //como.DaxCombosReferencia("GrupoConceptos", datosEmpresa.strConxSyscod, ref cmbGrupos, false);
           
            como.DaxCombosCat("C","S", datosEmpresa.strConxAdcom, ref cmbCategoria,false );
            como.DaxCombosCat("CL", "S", datosEmpresa.strConxAdcom, ref cmbClase, false);
            como.DaxCombosCat("G", "S", datosEmpresa.strConxAdcom, ref cmbGrupos, false);
            //DaxMedic.utility.CargaComboGruposServicios(cmbClase, datosEmpresa.strConxAdcom, "CL", false);
            //DaxMedic.utility.CargaComboGruposServicios(cmbGrupos, datosEmpresa.strConxAdcom, "G", false);
            if (cmbGrupos.Items.Count > 0) cmbGrupos.SelectedIndex = 0;
            if (cmbCategoria.Items.Count > 0) cmbCategoria.SelectedIndex = 0;
            if (cmbClase.Items.Count > 0 ) cmbClase.SelectedIndex = 0;
        }
        private void btnAbrir_Click(object sender, EventArgs e)
        {
            BuscServ prog = new BuscServ("", "S", "T", "", "D", false, true, false);
            string abreviacion = prog.IniServicio();
            cargarDatos(abreviacion);
            prog.Dispose();
        }
        private void cargarDatos(string abreviacion)
        {
            datosServicio = new ClassDoc.Servicios(datosEmpresa.strConxAdcom);
            datosServicio = ClassDoc.Servicios.Buscar(" sev_codigo = '" + abreviacion + "' and (isnull(sev_compras,0) <> 0 or isnull(sev_ventas,0) <> 0)  ");
            if (datosServicio != null) moverClaseADatos();
        }
        private void moverClaseADatos()
        {
            CtaMtn.Cuenta ctactb = new CtaMtn.Cuenta();

            txtAbreviacion.Text = datosServicio.Sev_codigo;
            txtDescripcion.Text = datosServicio.Sev_nombre;
            chkCompras.Checked = datosServicio.sev_compras;
            chkVentas.Checked = datosServicio.sev_ventas;
            //chkIngresoBancos.Checked = datosServicio.sev_ingbanco;
            //chkEgresoBancos.Checked = datosServicio.sev_egrbanco;
            btnBienes.Checked = (datosServicio.Sev_SriBien > 0);
            chkGrabaIva.Checked = datosServicio.Sev_sniva;
            txtPrecioVenta.Text = datosServicio.Sev_precvta.ToString();
            chkPrecioIncluyeIva.Checked = (datosServicio.Sev_IncIva > 0);
            //cmbTipoIva.SelectedValue = datosServicio.Sev_TipoSerSri;
            txtPorIVA.Text = datosServicio.Sev_PorIVA.ToString();
            cmbMedidas.SelectedValue = datosServicio.Sev_unimed;

            cmbGrupos.SelectedValue = datosServicio.Sev_Grupo;
            cmbCategoria.SelectedValue = datosServicio.Sev_Categoria;
            cmbClase.SelectedValue = datosServicio.Sev_Clase;

            txtIdCont1.Text = datosServicio.Sev_idcta;
            txtIdCont2.Text = datosServicio.Sev_idcta2;
            txtIdCont3.Text = datosServicio.Sev_idcta3;
            txtIdCont4.Text = datosServicio.Sev_idcta4;
            txtNombreImagen = datosServicio.sev_logotipo;
            if (txtNombreImagen.Length > 0)
            {
                try { picArticulo.Load(pathImagenes + txtNombreImagen); } catch { }
            }

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

            if (datosServicio.Sev_TipoCos == "") btnNoAfecta.Checked = true;
            else if (datosServicio.Sev_TipoCos == "U") btnPorUnidad.Checked = true;
            else if (datosServicio.Sev_TipoCos == "V") btnPorValor.Checked = true;
            else if (datosServicio.Sev_TipoCos == "P") btnPorPeso.Checked = true;

            chkPresentaInmediato.Checked = datosServicio.Sev_PresentaInmediato;
            txtPorComision.Text = datosServicio.Sev_PorctjComision.ToString();
            //chkAtencionMedica.Checked = (datosServicio.Sev_Categoria == "D");
            //chkHotel.Checked = (datosServicio.Sev_Categoria == "H");
            //chkRestaurante.Checked = (datosServicio.Sev_Categoria == "R");
            
            estadoOperacion = 2;
            actualizarBotones();
        }
        private void moverDatosAClase()
        {
            if (datosServicio == null) datosServicio = new ClassDoc.Servicios();           
            datosServicio.Sev_codigo = txtAbreviacion.Text;
            datosServicio.Sev_nombre = txtDescripcion.Text;
            datosServicio.sev_compras = chkCompras.Checked;
            datosServicio.sev_ventas = chkVentas.Checked;
            if (datosServicio.sev_compras == false && datosServicio.sev_ventas == false) datosServicio.sev_ventas = true;
            datosServicio.sev_ingbanco = false;    //chkIngresoBancos.Checked;
            datosServicio.sev_egrbanco = false;  //chkEgresoBancos.Checked;
            datosServicio.Sev_SriBien = 0;
            if (btnBienes.Checked == true) { datosServicio.Sev_SriBien = 1; }
            datosServicio.Sev_sniva = chkGrabaIva.Checked;
            datosServicio.Sev_precvta = Convert.ToDecimal("0" + txtPrecioVenta.Text);
            datosServicio.Sev_IncIva = 0;
            if (chkPrecioIncluyeIva.Checked == true) { datosServicio.Sev_IncIva = 1; }
            try
            {
                datosServicio.Sev_TipoSerSri = ""; //cmbTipoIva.SelectedValue.ToString();
            }
            catch { datosServicio.Sev_TipoSerSri = ""; }
            datosServicio.Sev_PorIVA = Convert.ToDecimal("0" + txtPorIVA.Text);
            try
            {
                datosServicio.Sev_unimed = cmbMedidas.SelectedValue.ToString();
            }
            catch { datosServicio.Sev_unimed = "UND"; }

            //try
            //{
            //    datosServicio.Sev_Grupo = cmbGrupos.SelectedValue.ToString();
            //}
            //catch { datosServicio.Sev_Grupo = ""; }

            // ✅ Forma segura: verificar null antes de ToString()
            if (cmbGrupos.SelectedValue != null && cmbGrupos.SelectedValue != DBNull.Value)
            {
                datosServicio.Sev_Grupo = cmbGrupos.SelectedValue.ToString();
            }
            else
            {
                datosServicio.Sev_Grupo = "";
            }

            //try
            //{
            //    datosServicio.Sev_Clase = cmbClase.SelectedValue.ToString();
            //}
            //catch { datosServicio.Sev_Clase = ""; }

            // ✅ Forma segura: verificar null antes de ToString()
            if (cmbClase.SelectedValue != null && cmbClase.SelectedValue != DBNull.Value)
            {
                datosServicio.Sev_Clase = cmbClase.SelectedValue.ToString();
            }
            else
            {
                datosServicio.Sev_Clase = "";
            }

            //try
            //{
            //    datosServicio.Sev_Categoria = cmbCategoria.SelectedValue.ToString();
            //}
            //catch { datosServicio.Sev_Categoria = ""; }

            if (cmbCategoria.SelectedValue != null && cmbCategoria.SelectedValue != DBNull.Value)
            {
                datosServicio.Sev_Categoria = cmbCategoria.SelectedValue.ToString();
            }
            else
            {
                datosServicio.Sev_Categoria = "";
            }

            datosServicio.sev_logotipo=txtNombreImagen;
            

            datosServicio.Sev_idcta = txtIdCont1.Text;
            datosServicio.Sev_idcta2 = txtIdCont2.Text;
            datosServicio.Sev_idcta3 = txtIdCont3.Text;
            datosServicio.Sev_idcta4 = txtIdCont4.Text;
            datosServicio.Sev_PorctjComision = Convert.ToDecimal("0" + txtPorComision.Text);
            //datosServicio.sev_cruceclientes=optAfectaVentas.Checked;
            //datosServicio.sev_cruceproveedores=optAfectaCompras.Checked;
            datosServicio.Sev_PresentaInmediato = false;
            if (chkPresentaInmediato.Checked) datosServicio.Sev_PresentaInmediato = true;
            estadoOperacion = 0;
            //if (chkHotel.Checked) datosServicio.Sev_Categoria = "H";
            //if (chkRestaurante.Checked) datosServicio.Sev_Categoria = "R";
            //if (chkAtencionMedica.Checked) datosServicio.Sev_Categoria = "D";

            if ( btnNoAfecta.Checked ) datosServicio.Sev_TipoCos = "";
            else if (btnPorUnidad.Checked )datosServicio.Sev_TipoCos = "U";
            else if (btnPorValor.Checked) datosServicio.Sev_TipoCos = "V";
            else if (btnPorPeso.Checked) datosServicio.Sev_TipoCos = "P" ;

            if (datosServicio.Actualizar().Substring(0, 5) != "Error") { limpiarDatos(); actualizarBotones(); }

        }

        private void limpiarDatos()
        {
            txtAbreviacion.Text = "";
            txtDescripcion.Text = "";
            btnBienes.Checked = (datosServicio.Sev_SriBien > 0);
            //chkGrabaIva.Checked = datosServicio.Sev_sniva;
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
            estadoOperacion = 0;
            actualizarBotones();

            txtPorComision.Text = "";
            txtPorIVA.Text = "";

            chkCompras.Checked = false;
            chkVentas.Checked = false;
            chkGrabaIva.Checked = false;

            btnBienes.Checked = false;
            btnNoAfecta.Checked = true;

            //chkHotel.Checked = false;
            //chkAtencionMedica.Checked = false;
            estadoOperacion = 0;
            actualizarBotones();

            cmbGrupos.SelectedValue = "";
            cmbGrupos.Text = "";
            chkPresentaInmediato.Checked = false;
            txtNombreImagen = "";
            picArticulo.Image = null;

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
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar) || e.KeyChar == Convert.ToChar(".")) return;
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

        private void picArticulo_Click(object sender, EventArgs e)
        {
            if (pathImagenes.Length != 0)
            {
                dialogoOpen.Title = "Escojer fotografía para directorio";
                dialogoOpen.Filter = "Imágenes (*.bmp;*.ico;*.jpg)|*.bmp;*.ico;*.jpg";
                dialogoOpen.InitialDirectory = pathImagenes;
                dialogoOpen.ShowDialog();
                if (dialogoOpen.FileName.Length > 0) GuardarImagenDelArticulo(dialogoOpen.FileName, dialogoOpen.SafeFileName);
            }
            else
            {
                MessageBox.Show("No se encuentra definido el lugar de almacenamiento de imágenes \n (Definir en administración del sistema)", "Almacenar imagenes de productos");
            }
        }
        private void GuardarImagenDelArticulo(string pathFile, string NameFile)
        {
            try
            {
                picArticulo.Load(pathFile);
                txtNombreImagen = NameFile;
                if (pathFile != pathImagenes + NameFile) File.Copy(pathFile, pathImagenes + NameFile, true);
            }
            catch (Exception ee)
            {
                MessageBox.Show("No se pudo cargar la imagen seleccionada)\n " + ee.Message, "Almacenar imagenes de productos");
                txtNombreImagen = "";
            }
        }
        private void LeerPatDeImagenes()
        {
            pathImagenes = "";
            DataTable dt = DattCom.datosEmpresa.leeParametrosEmp("Emp_PathImagenes");
            if (dt.Rows.Count > 0)
            {
                pathImagenes = "" + dt.Rows[0]["Emp_PathImagenes"].ToString();
            }
            dt.Dispose();
            if (pathImagenes.Length > 2)
            {
                if (pathImagenes.Substring(pathImagenes.Length - 1, 1) != "\\") pathImagenes += '\\';
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            sesSrv.FrmNivServ niv = new sesSrv.FrmNivServ();
            niv.ShowDialog();
        }

        private void txtPorIVA_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir control (backspace, delete, etc.)
            if (char.IsControl(e.KeyChar))
                return;

            // Permitir solo números y punto decimal
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
                return;
            }

            // Evitar más de un punto decimal
            TextBox txt = sender as TextBox;
            if (e.KeyChar == '.' && txt.Text.Contains("."))
            {
                e.Handled = true;
            }
        }

		private void txtPorIVA_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
            if (string.IsNullOrWhiteSpace(txtPorIVA.Text))
            {
                txtPorIVA.Text = "0";
                return;
            }

            if (!double.TryParse(txtPorIVA.Text, out double iva))
            {
                MessageBox.Show("Ingrese un porcentaje de IVA válido.",
                                "Validación",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                e.Cancel = true;
                return;
            }

            // Rango permitido (ajusta si necesitas)
            if (iva < 0 || iva > 100)
            {
                MessageBox.Show("El porcentaje de IVA debe estar entre 0 y 100.",
                                "Validación",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                e.Cancel = true;
            }
        }

		

	}
}
