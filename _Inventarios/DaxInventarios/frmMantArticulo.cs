using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using ArtInvent;
using DattCom;

namespace DaxInvent
{
    internal partial class MantArticulo : Form
    {
       adcArticulo.AdcArt artDatos = new adcArticulo.AdcArt();
        DataTable dataTiket = new DataTable();
        int operacion = 0; // 0 ninguna 1 nuevo 2 abierto
        Boolean esSoloConsulta = false;
        string conArticulo = "";
       // string sSQLTIKETS = "";
        string detallelargo = "";
        string pathImagenes = "";
        string txtNombreImagen = "";
        //Boolean grabaNandina = false;
        internal MantArticulo(string codArticulo="",Boolean consulta=false) 
        {
            InitializeComponent();
            esSoloConsulta = consulta;
            conArticulo = codArticulo;
            llenarCombos();
            LeerPatDeImagenes();
            prepararBotones();
        }
        private void llenarCombos()
        {
            DaxCombobx.CargCmbBox cmb = new DaxCombobx.CargCmbBox();
            cmb.DaxCombosCat("C", "I", datosEmpresa.strConxAdcom, ref cmbCategoria);
            cmb.DaxCombosCat("CL", "I", datosEmpresa.strConxAdcom, ref cmbClase );
            cmb.DaxCombosCat("G", "I", datosEmpresa.strConxAdcom, ref cmbGrupo);
            cmb.DaxCombosCat("S", "I", datosEmpresa.strConxAdcom, ref cmbSubgrupo);
            cmb.DaxCombosReferencia("Medidas", datosEmpresa.strConxSyscod, ref cmbMedida, false);
        }
        private void moverCLaseADatos()
        {
            Syscod.ManSysnetClass sys = new Syscod.ManSysnetClass();

            txtCodigo.Text  = artDatos.Art_codigo;
            txtDescripcion.Text  = artDatos.Art_nombre;
            cmbCategoria.SelectedValue = artDatos.Art_categor;
            cmbClase.SelectedValue = artDatos.Art_clase;
            cmbGrupo.SelectedValue = artDatos.Art_grupo;
            cmbSubgrupo.SelectedValue = artDatos.Art_subgrup;
            // = artDatos.Art_tiporota;
            cmbMedida.SelectedValue  = artDatos.Art_unimed;
            chkNoParaVenta.Checked = artDatos.Art_snmed;
            chkSuspendido.Checked = artDatos.ArticuloSuspendido;
            txtFactor.Text = artDatos.Art_factor.ToString();
            txtLargo.Text  = artDatos.Art_largo.ToString();
            txtAlto.Text = artDatos.Art_alto.ToString();
            txtAncho.Text = artDatos.Art_ancho.ToString();
            txtAltoFlor.Text = artDatos.Art_alto.ToString();
            txtPeso.Text = artDatos.Art_peso.ToString();
            txtPesoFlor.Text = artDatos.Art_peso.ToString();
            chkGrabadoIva.Checked = artDatos.Art_sniva;
            txtCantTallos.Text = artDatos.cantTallos.ToString();
            textCoeficientePrecio.Text = artDatos.Art_CoefctePrecio.ToString();
            //oA.Art_fecucom = artDatos.Art_fecucom;
            //oA.Art_costucom = artDatos.Art_costucom;

            chkUnico.Checked = true;
            if (artDatos.Art_individ == "S") { chkSeries.Checked = true; }
            if (artDatos.Art_individ == "T" ) {chkTallas.Checked = true;}
            if (artDatos.Art_individ == "C") { chkRestaurante.Checked = true; }

            txtCantMinima.Text = artDatos.Art_minbod.ToString();
            txtCantMaxima.Text = artDatos.Art_maxbod.ToString();
            chkComponentes.Checked = artDatos.Art_sncomp;
            txtComisionVentas.Text  = artDatos.Art_PorCom.ToString();
            txtPrecio1.Text = artDatos.Art_precvta1.ToString();
            txtPrecio2.Text = artDatos.Art_precvta2.ToString();
            txtPrecio3.Text = artDatos.Art_precvta3.ToString();
            txtPrecio4.Text = artDatos.Art_precvta4.ToString();
            txtPrecio5.Text = artDatos.Art_precvta5.ToString();
            txtPorcDescuento.Text = artDatos.Art_descuen.ToString();
            chInclIva1.Checked = artDatos.Art_IncluyeIvaP1;
            chInclIva2.Checked = artDatos.Art_IncluyeIvaP2;
            chInclIva3.Checked = artDatos.Art_IncluyeIvaP3;
            chInclIva4.Checked = artDatos.Art_IncluyeIvaP4;
            chInclIva5.Checked = artDatos.Art_IncluyeIvaP5;
            dtDescuentoDesde.Value = artDatos.Art_fecinides;
            dtDescuentoHasta.Value = artDatos.Art_fecfindes;
            //oA.Art_usuario = artDatos.Art_usuario;
             txtcodProveedor1.Text = artDatos.Art_proveedor;
             //txtcodProveedor2.Text = artDatos.Art_proveedor;
             //txtcodProveedor3.Text = artDatos.Art_proveedor;
             txtCodArtProveedor1.Text = artDatos.Art_codpro;

            txtNombreImagen = artDatos.Art_logotipo;
            txtCostoEstandard.Text = artDatos.Art_CostoEstandard.ToString();
            //oA.Art_idcontable = artDatos.Art_idcontable;
            txtCodigoBase.Text = artDatos.Art_Codigobase;            
            //oA.Art_FechaCrea = artDatos.Art_FechaCrea;
            //oA.Art_FechaModifica = artDatos.Art_FechaModifica;
            chkGrabadoIce.Checked = artDatos.Art_Ice;
            txtMinimaCompra.Text = artDatos.Art_CompraMinima.ToString();
            txtComprarGrupos.Text = artDatos.Art_CompraUndsGrupo.ToString();
            // = artDatos.CompraCantidadMinima.ToString();
            //txtcan = artDatos.CompraCantidadPorGrupo;
            txtNombreCorto.Text = artDatos.NombreCorto;
            txtCodEmpaque1.Text = artDatos.CodEmpaque1;
            txtCantEmpaque1.Text = artDatos.ValEmpaque1.ToString();
            txtNomEmpaque1.Text = sys.QueNombre(artDatos.CodEmpaque1, "Empaque");

            txtCodEmpaque2.Text = artDatos.CodEmpaque2;
            txtCantEmpaque2.Text = artDatos.ValEmpaque2.ToString();
            txtNomEmpaque2.Text = sys.QueNombre(artDatos.CodEmpaque2, "Empaque");

            txtCodEmpaque3.Text = artDatos.CodEmpaque3;
            txtCantEmpaque3.Text = artDatos.ValEmpaque3.ToString();
            txtNomEmpaque3.Text = sys.QueNombre(artDatos.CodEmpaque3, "Empaque");

            txtCodEmpaque4.Text = artDatos.CodEmpaque4;
            txtCantEmpaque4.Text = artDatos.ValEmpaque4.ToString();
            txtNomEmpaque4.Text = sys.QueNombre(artDatos.CodEmpaque4, "Empaque");

            //if (chkTallas.Checked)
            {
                string ssql = "select * from adctik where tik_artcodi = '" + artDatos.Art_codigo  + "'";
                DataTable dt = SqlDatos.leerTablaAdcom(ssql);
                if (dt.Rows.Count > 0)
                {
                    txtCodigoBarras.Text = dt.Rows[0]["tik_numero"].ToString();
                    txtTalla.Text = dt.Rows[0]["tik_talla"].ToString();
                    txtColor.Text = dt.Rows[0]["tik_color"].ToString();
                }
                //}
            }
                        
            //frmCodBarr.cargaInicial(ref dataTiket, artDatos.Art_codigo);
            //sSQLTIKETS = frmCodBarr.Ssql;
            //if (dataTiket.Rows.Count > 0)
            //{
            //    txtCodigoBarras.Text = dataTiket.Rows[0]["tik_numero"].ToString();
            //}
            

            //txtCodEmpaque5.Text = artDatos.CodEmpaque5;
            //txtCantEmpaque5.Text= artDatos.ValEmpaque5;
            txtPorDescMaximo.Text  = artDatos.art_limDescuento.ToString();
            chkPresInmediata.Checked = artDatos.art_presentaInmediato;
            //oA.FechaCaduca = artDatos.FechaCaduca;
            //oA.NroLote = artDatos.NroLote;
            detallelargo=artDatos.detalleLargo;
            
            if (txtNombreImagen.Length > 0)
            {
                try { picArticulo.Load(pathImagenes + txtNombreImagen); } catch { }
            }
            txtHts.Text = artDatos.HTS;
            txtNandina.Text  = artDatos.Nandina;
            txtIdCont1.Text = artDatos.IdContable1;
            txtIdCont2.Text = artDatos.IdContable2;

            txtPorcIvaIndividual.Text = artDatos.Art_PorIVA.ToString();
            chkNegativoInventario.Checked = artDatos.Art_ExistBod;

            CtaMtn.Cuenta ctactb = new CtaMtn.Cuenta();
            string nomcta = txtIdCont1.Text;
            lblCuenta1.Text = ctactb.NombreCuentaContable(ref nomcta);
            nomcta = txtIdCont2.Text;
            lblCuenta2.Text = ctactb.NombreCuentaContable(ref nomcta);
            ctactb = null;
            sys = null;
        }
        private void moverDatosAClase()
        {
            artDatos.Art_codigo=txtCodigo.Text   ;
            artDatos.Art_nombre=txtDescripcion.Text   ;
            artDatos.Art_categor=cmbCategoria.SelectedValue.ToString().ToString();
            if ((cmbClase.SelectedValue != null )) { artDatos.Art_clase = cmbClase.SelectedValue.ToString(); }
            if ((cmbGrupo.SelectedValue != null  )) {artDatos.Art_grupo= cmbGrupo.SelectedValue.ToString();}
            if ((cmbSubgrupo.SelectedValue != null)) { artDatos.Art_subgrup = "" + cmbSubgrupo.SelectedValue.ToString(); }
            //  artDatos.Art_tiporota= value;
            artDatos.Art_unimed="" + cmbMedida.SelectedValue.ToString()   ;
            artDatos.Art_snmed=chkNoParaVenta.Checked  ;
            artDatos.ArticuloSuspendido = chkSuspendido.Checked;
            artDatos.Art_factor=Convert.ToDecimal("0"+txtFactor.Text); 
            artDatos.Art_largo=Convert.ToDecimal("0" + txtLargo.Text);
            artDatos.Art_alto=Convert.ToDecimal("0" + txtAlto.Text);
            artDatos.Art_ancho=Convert.ToDecimal("0" + txtAncho.Text);
            artDatos.Art_peso=Convert.ToDecimal("0" + txtPeso.Text);
            artDatos.Art_sniva=chkGrabadoIva.Checked  ;
            artDatos.cantTallos = Convert.ToDecimal("0" + txtCantTallos.Text);
            //oA.Art_fecucom  artDatos.Art_fecucom= value;
            //oA.Art_costucom  artDatos.Art_costucom= value;

            artDatos.Art_individ = "";
            if (chkSeries.Checked == true) { artDatos.Art_individ = "S";}
            if (chkTallas.Checked == true) { artDatos.Art_individ = "T" ;}
            if (chkRestaurante.Checked == true) { artDatos.Art_individ = "C";}

            artDatos.Art_minbod=Convert.ToDecimal("0" + txtCantMinima.Text);
            artDatos.Art_maxbod=Convert.ToDecimal("0" + txtCantMaxima.Text);
            artDatos.Art_sncomp=chkComponentes.Checked;
            artDatos.Art_PorCom=Convert.ToDecimal("0" + txtComisionVentas.Text);
            artDatos.Art_precvta1 = Convert.ToDecimal("0" + txtPrecio1.Text);
            artDatos.Art_precvta2 = Convert.ToDecimal("0" + txtPrecio2.Text);
            artDatos.Art_precvta3 = Convert.ToDecimal("0" + txtPrecio3.Text);
            artDatos.Art_precvta4 = Convert.ToDecimal("0" + txtPrecio4.Text);
            artDatos.Art_precvta5 = Convert.ToDecimal("0" + txtPrecio5.Text);
            artDatos.Art_descuen=Convert.ToDecimal("0" + txtPorcDescuento.Text);
            artDatos.Art_IncluyeIvaP1=chInclIva1.Checked  ;
            artDatos.Art_IncluyeIvaP2=chInclIva2.Checked  ;
            artDatos.Art_IncluyeIvaP3=chInclIva3.Checked  ;
            artDatos.Art_IncluyeIvaP4=chInclIva4.Checked  ;
            artDatos.Art_IncluyeIvaP5=chInclIva5.Checked  ;
            artDatos.Art_fecinides=dtDescuentoDesde.Value  ;
            artDatos.Art_fecfindes=dtDescuentoHasta.Value  ;
            artDatos.Art_CoefctePrecio= Convert.ToDecimal("0" + textCoeficientePrecio.Text);
            //oA.Art_usuario  artDatos.Art_usuario= value;
            //txtcodProveedor2.Text  artDatos.Art_codpro= value;
            //txtcodProveedor3.Text  artDatos.Art_codpro= value;

            artDatos.Art_logotipo=txtNombreImagen  ;
            artDatos.Art_CostoEstandard = Convert.ToDecimal("0" + txtCostoEstandard.Text);
            //oA.Art_idcontable  artDatos.Art_idcontable= value;
            artDatos.Art_Codigobase=txtCodigoBase.Text  ;            

            artDatos.Art_proveedor=txtcodProveedor1.Text;
            artDatos.Art_codpro = txtCodArtProveedor1.Text;
            try 
            { 
                DateTime fecha = artDatos.Art_FechaCrea;
            }
            catch { artDatos.Art_FechaCrea = DateTime.Now; }
            artDatos.Art_FechaModifica= DateTime.Now;
            artDatos.Art_Ice=chkGrabadoIce.Checked  ;
            artDatos.Art_CompraMinima=Convert.ToInt16("0" + txtMinimaCompra.Text);
            artDatos.Art_CompraUndsGrupo=Convert.ToInt16("0" + txtComprarGrupos.Text);
            artDatos.NombreCorto=txtNombreCorto.Text  ;
            artDatos.CodEmpaque1=txtCodEmpaque1.Text  ;
            artDatos.ValEmpaque1=Convert.ToDecimal("0" + txtCantEmpaque1.Text);
            artDatos.CodEmpaque2=txtCodEmpaque2.Text;
            artDatos.ValEmpaque2=Convert.ToDecimal("0" + txtCantEmpaque2.Text);
            artDatos.CodEmpaque3=txtCodEmpaque3.Text;
            artDatos.ValEmpaque3=Convert.ToDecimal("0" + txtCantEmpaque3.Text);
            artDatos.CodEmpaque4=txtCodEmpaque4.Text;
            artDatos.ValEmpaque4=Convert.ToDecimal("0" + txtCantEmpaque4.Text);
            //txtCodEmpaque5.Text  artDatos.CodEmpaque5= value;
            //txtCantEmpaque5.Text artDatos.ValEmpaque5= value;
            artDatos.art_limDescuento=Convert.ToDecimal("0" + txtPorDescMaximo.Text);
            artDatos.art_presentaInmediato = chkPresInmediata.Checked;
            artDatos.detalleLargo = detallelargo;
            //oA.FechaCaduca  artDatos.FechaCaduca= value;
            //oA.NroLote  artDatos.NroLote= value;
            artDatos.HTS = txtHts.Text;
            artDatos.Nandina = txtNandina.Text;
            artDatos.IdContable1 = txtIdCont1.Text;
            artDatos.IdContable2 = txtIdCont2.Text;

            artDatos.Art_PorIVA = Convert.ToDecimal("0" + txtPorcIvaIndividual.Text);
            artDatos.Art_ExistBod = chkNegativoInventario.Checked;
        }
        private void prepararBotones()
        {
            Boolean inicio = (operacion == 0);
            Boolean nuevo = (operacion == 1);
            Boolean modificando = (operacion == 2);
            tabControl1.Enabled = (!inicio);

            txtCodigo.Enabled = !modificando;

            btnAbre.Enabled = inicio;
            btnNuevo.Enabled = inicio;

            btnElimina.Enabled = modificando;
            btnGraba.Enabled = (!inicio && txtCodigo.Text.Length > 0);
            btnCierra.Enabled = !inicio;

            btnPreferenciaPlatos.Enabled = !inicio;
            btnDetalleLargo.Enabled = !inicio;
            btnMovimiento.Enabled = modificando;
            btnPendientes.Enabled = modificando;
            btnVentas.Enabled = modificando;
            btnCompras.Enabled = modificando;

            if (operacion == 2 && chkTallas.Checked )
            {
                txtTalla.Enabled = false;
                txtColor.Enabled = false;
            }
            else
            {
                txtTalla.Enabled = true;
                txtColor.Enabled = true;
            }

            habilitarComponentes();

            if (esSoloConsulta == true )
            {
                btnGraba.Enabled = false;
                btnElimina.Enabled = false;
                btnNuevo.Enabled = false;
                btnCierra.Enabled = false;
            }
        }
        private void limpiarControles()
        {
            txtCodigo.Enabled = true;
            txtCodigo.Text = "";
            txtDescripcion.Text = "";
            cmbCategoria.SelectedValue = "";
            cmbClase.SelectedValue = "";
            cmbGrupo.SelectedValue = "";
            cmbSubgrupo.SelectedValue = "";
            chkNoParaVenta.Checked = false;
            chkSuspendido.Checked = false;
            txtFactor.Text = "0";
            txtLargo.Text = "0";
            txtAlto.Text = "0";
            txtAncho.Text = "0";
            txtPeso.Text = "0";
            chkGrabadoIva.Checked = true;
            chkUnico.Checked = true;
            txtMinimaCompra.Text = "0";
            txtCantMaxima.Text = "0";
            chkComponentes.Checked = false;
            txtComisionVentas.Text = "0";
            txtPrecio1.Text = "0";
            txtPrecio2.Text = "0";
            txtPrecio3.Text = "0";
            txtPrecio4.Text = "0";
            txtPrecio5.Text = "0";
            txtPorcDescuento.Text = "0";
            chInclIva1.Checked = false;
            chInclIva2.Checked = false;
            chInclIva3.Checked = false;
            chInclIva4.Checked = false;
            chInclIva5.Checked = false;
            dtDescuentoDesde.Value = new DateTime(1900,1,1);
            dtDescuentoHasta.Value = new DateTime(1900, 1, 1);
            txtcodProveedor1.Text = "";
            txtcodProveedor2.Text = "";
            txtcodProveedor3.Text = "";

            txtNombreImagen = "";

            txtCostoEstandard.Text = "0";
            txtCodigoBase.Text = "";
            txtCodArtProveedor1.Text = "";
            chkGrabadoIce.Checked = false;
            txtMinimaCompra.Text = "0";
            txtComprarGrupos.Text = "";
            txtNombreCorto.Text = "";
            txtCodEmpaque1.Text = "";
            txtCantEmpaque1.Text = "";
            txtCodEmpaque2.Text = "";
            txtCantEmpaque2.Text = "";
            txtCodEmpaque3.Text = "";
            txtCantEmpaque3.Text = "";
            txtCodEmpaque4.Text = "";
            txtCantEmpaque4.Text = "";
            txtNomEmpaque1.Text = "";
            txtNomEmpaque2.Text = "";
            txtNomEmpaque3.Text = "";
            txtNomEmpaque4.Text = "";
            txtPorDescMaximo.Text = "0";
            txtCantMinima.Text = "0";
            textCoeficientePrecio.Text = "0";
            chkPresInmediata.Checked = false;
            txtCodigoBarras.Text = "";
            dataTiket = new DataTable();
            detallelargo = "";
            picArticulo.ImageLocation = null;
            picArticulo.BackgroundImage = null;
            picArticulo.Image = null;
            picArticulo.InitialImage = null;
            txtCodigo.Focus();
            operacion = 0;
            prepararBotones();
            txtNandina.Text = "";
            txtHts.Text = "";            
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            operacion = 1;
            artDatos = new adcArticulo.AdcArt(datosEmpresa.strConxAdcom);
            prepararBotones();
        }

        private void btnAbre_Click(object sender, EventArgs e)
        {
            string dato = "" + txtCodigo.Text;
            Buscar.frmBuscar busk = new Buscar.frmBuscar();
            string ssql = "select art_codigo as codigo, art_nombre as Descripción from adcart order by art_nombre";
            dato = busk.Buscar(datosEmpresa.strConxAdcom, ssql, "codigo", "Descripción", "", "BUSQUEDA DE ARTÍCULOS", dato);
            if (dato != "") cargarClas(dato);
        }
        private void cargarClas(string codigo)
        {
            Boolean existe = false;
            if (codigo == "") return;
            artDatos = new adcArticulo.AdcArt(datosEmpresa.strConxAdcom);
                artDatos = adcArticulo.AdcArt.Buscar("art_codigo = '" + codigo + "'");
            try
            {
                if (artDatos.Art_codigo.Length > 0) existe = true ;
            }
            catch 
            { 
                existe = false;
                artDatos = new adcArticulo.AdcArt();
            }
            if (existe == false)
            {
                if (operacion == 0)
                {
                    if (MessageBox.Show("EL código del artículo no existe \n Desea crear uno nuevo ?", "Mantenimiento artículos de inventario", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No) { txtCodigo.Focus(); return; }
                    operacion = 1;
                }                 
            }
            else
            {
                moverCLaseADatos();
                operacion = 2;
            }                
            prepararBotones();
        }

        private void btnElimina_Click(object sender, EventArgs e)
        {
            eliminar();
        }
        private void eliminar()
        {
            string ssql = "Select TOP (1) tra_codigo from adctra where tra_codigo = '" + txtCodigo.Text + "' ";
            ssql += " UNION ALL ";
            ssql += " Select TOP (1) tra_codigo from adctrapro where tra_codigo = '" + txtCodigo + "' ";
            SqlDataAdapter da = new SqlDataAdapter(ssql, datosEmpresa.strConxAdcom);
            DataTable dt = new DataTable();
            Int32 r = da.Fill(dt);
            if (r == 0)
            {
                if (MessageBox.Show ("Esta seguro que desea eliminar el artículo ?","Eliminar artículo de inventario",  MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    artDatos.Borrar();
                    limpiarControles();                     
                }
            }
            else
            {
                MessageBox.Show ("No puede eliminar este artículo, está siendo utilizado ","Eliminar artículo de inventario", MessageBoxButtons.OK , MessageBoxIcon.Error);
            }
            dt.Dispose();
            da.Dispose();
        }

        private void btnCierra_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro que desea cerrar este artículo ?", "Consultar artículo de inventario", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                limpiarControles();
            }
        }

        private void btnGraba_Click(object sender, EventArgs e)
        {
            if (validacion())
            {
                moverDatosAClase();
                if (chkTallas.Checked || dataTiket.Rows.Count > 0)
                {
                    actualizarTikets();
                }
                else
                {
                    artDatos.Actualizar();
                    if (artDatos.Art_unimed.ToUpper() == "RAM" || artDatos.Art_unimed.ToUpper() == "TLL")
                    {
                        if (artDatos.Art_categor != "") actualizaNandinaHts(1, artDatos.Art_codigo);
                        if (artDatos.Art_clase != "") actualizaNandinaHts(2, artDatos.Art_codigo);
                        if (artDatos.Art_grupo != "") actualizaNandinaHts(3, artDatos.Art_codigo);
                        if (artDatos.Art_subgrup != "") actualizaNandinaHts(4, artDatos.Art_codigo);
                    }
                }
                limpiarControles();
            }
        }
        private bool ExisteCreacionTallas()
        {
            if (chkTallas.Checked && txtCodigoBase.TextLength > 0)
            {
                if (MessageBox.Show("Se crearán artículos con el código base, tallas y colores", "Creación de artícuslos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes) return true;
                else return false;
            }
            return true;
        }
        public void actualizaNandinaHts(int nivel, string Articulo)
        {
            SqlConnection conn = new SqlConnection(datosEmpresa.strConxAdcom);
            conn.Open();
            SqlCommand comm = new SqlCommand("DaxActArtNan " + nivel.ToString() + ",'"+ Articulo + "'", conn);
            comm.ExecuteNonQuery();
            conn.Close();
            conn.Dispose();
            comm.Dispose();
        }
        private Boolean validacion()
        {
            string error = "";
            if (chkTallas.Checked)
            {
                error = ChequearTallas();
                if (txtCodigo.Text == "") { error = "Falta el código del artículo \n"; }
            }
            else
            {
                if (txtCodigo.Text == "") { error = "Falta el código del artículo \n"; }
            }
            if (txtDescripcion.Text == "") { error = "Falta la descricpción del artículo \n"; }
            if (cmbCategoria.Text == "") { error += "El artículo debe pertenecer a una Categoría \n"; }
            if (cmbMedida.Text == "") { error += "El artículo debe tener unidad de medida \n"; }

            if (error != "") { MessageBox.Show(error, "Validación artículo", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
            return true;
        }
        private string ChequearTallas()
        {
            string error = "";
            if (dataTiket.Rows.Count == 0)
            {
                if (chkTallas.Checked) 
                { 
                    if (txtTalla.Text == "" || txtColor.Text == "") 
                    {
                        error += "Registre correctamente la talla y color del artículo \n";
                    }
                }
            }
            return error;
        }

        private void btnCodEmpaque1_Click(object sender, EventArgs e)
        {
            ponerEmpaque(ref txtCodEmpaque1,ref txtNomEmpaque1);
        }
        private void ponerEmpaque(ref TextBox txtcod, ref TextBox txtnom)
        {
            String  Nombre = "";
            String codigo = "";
            String tipo ="Empaque";
            Syscod.ManSysnetClass  Buscod =new Syscod.ManSysnetClass();

            txtnom.Text = Buscod.BuscarReferencia(ref tipo,ref  codigo, ref Nombre);
            txtcod.Text = codigo;
            Buscod=null;
        }
        private void btnCodEmpaque2_Click(object sender, EventArgs e)
        {
            ponerEmpaque(ref txtCodEmpaque2, ref txtNomEmpaque2);
        }

        private void btnCodEmpaque3_Click(object sender, EventArgs e)
        {
            ponerEmpaque(ref txtCodEmpaque3, ref txtNomEmpaque3);
        }

        private void btnCodEmpaque4_Click(object sender, EventArgs e)
        {
            ponerEmpaque(ref txtCodEmpaque4, ref txtNomEmpaque4);
        }

        private void btnMedida_Click(object sender, EventArgs e)
        {
           FrmMantMed MANMED = new FrmMantMed("");
            MANMED.ShowDialog();
            MANMED.Dispose();
        }

        private void btnProveedor1_Click(object sender, EventArgs e)
        {
            buscaProveedor(txtcodProveedor1, txtNomProveedor1);
        }
        private void buscaProveedor(TextBox cod,TextBox descripcion)
        {
            directMnt.BuscaClien directorio = new directMnt.BuscaClien();
            string cliente = "P";
            string codigo = "";
            string nombre = "";
            string conalias = "N";
            string connuevo = "N";
            codigo = directorio.IniBuscaCliOPro(ref cliente, ref nombre, ref conalias, ref connuevo);
            if (codigo.Length > 0) { cod.Text = codigo; descripcion.Text = nombre; }
            directorio.Dispose();
        }

        private void btnCrearTallasColores_Click(object sender, EventArgs e)
        {
            frmTallasColore prog = new frmTallasColore(txtCodigoBase.Text, txtDescripcion.Text, datosEmpresa.strConxAdcom, ref dataTiket);
            prog.ShowDialog();
            prog.Dispose();
        }

        private void txtCodigoBase_TextChanged(object sender, EventArgs e)
        {
            habilitarCodigoBase();
        }

        private void chkComponentes_CheckedChanged(object sender, EventArgs e)
        {
            habilitarComponentes();
        }
        private void habilitarComponentes()
        {
            btnComponentes.Enabled = (chkComponentes.Checked && operacion == 2);
        }
        private void habilitarCodigoBase()
        {
            btnCrearTallasColores.Enabled = (txtCodigoBase.Text.Length > 0 && chkTallas.Checked);
        }

        private void chkTallas_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTallas.Checked)
            {
                habilitarCodigoBase();
                label8.Visible = true;
                txtCodigoBase.Visible = true;
                btnCrearTallasColores.Visible = true;
                grpCaracteristicas.Visible = true;
                btnTikets.Visible = false;
            }
            else
            {
                label8.Visible = false;
                txtCodigoBase.Visible = false;
                btnCrearTallasColores.Visible = false;
                grpCaracteristicas.Visible = false;
                btnTikets.Visible = false;
            }
        }

        private void txtCodigo_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(txtCodigo.Text.Length > 0)
            {
                cargarClas(txtCodigo.Text);
            }
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) txtDescripcion.Focus();
        }

        private void btnMovimiento_Click(object sender, EventArgs e)
        {            
            frmMovArt prog = new frmMovArt(txtCodigo.Text,txtDescripcion.Text);
            prog.ShowDialog();
            prog.Dispose();
        }

        private void btnPendientes_Click(object sender, EventArgs e)
        {
            EntregasPendientesClienteProv frm = new EntregasPendientesClienteProv(datosEmpresa.strConxAdcom, "P", txtCodigo.Text, txtDescripcion.Text);
            frm.ShowDialog();
            frm.Dispose();
        }

        private void btnDetalleLargo_Click(object sender, EventArgs e)
        {
            adcDocumentos.frmEditDoc frm = new adcDocumentos.frmEditDoc( datosEmpresa.strConxAdcom ,txtCodigo.Text,txtDescripcion.Text,detallelargo,"A" );
            frm.ShowDialog();
            detallelargo = frm.ingresoDetalle;
            frm.Dispose();
        }

        private void MantArticulo_Load(object sender, EventArgs e)
        {
            if (conArticulo != "") cargarClas(conArticulo);
        }

        private void txtCodigoBarras_TextChanged(object sender, EventArgs e)
        {
            //codbar.Caption = txtCodigoBarras.Text;
            BarcodeLib.Barcode prog = new BarcodeLib.Barcode
            {
                IncludeLabel = false
            };
            try
            {
                codbar.BackgroundImage = prog.Encode(BarcodeLib.TYPE.EAN13, txtCodigoBarras.Text, codbar.Width, codbar.Height);
            }
            catch {}
        }

        private void cmbMedida_SelectedIndexChanged(object sender, EventArgs e)
        {
            if((cmbMedida.Text + "    ").Substring(0,3).ToUpper() =="RAM")
            {
                grpFlores.Visible = true;
                grpMedidas.Visible = false;
            }
            else
            {
                grpFlores.Visible = false;
                grpMedidas.Visible = true;
            }
        }

        private void txtAltoFlor_TextChanged(object sender, EventArgs e)
        {
            txtAlto.Text = txtAltoFlor.Text;
        }

        private void txtPesoFlor_TextChanged(object sender, EventArgs e)
        {
            txtPeso.Text = txtPesoFlor.Text;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //Buscar.frmBuscar bus = new Buscar.frmBuscar();
            //bus.Buscar(ClassArt.strConxAdcom, "select tik_artCodi as codigo,tik_numero as codBarras from adctik where tik_artcodi = '" + txtCodigo.Text + "'", "codBarras", "codBarras", "", "Codigos de barras por artículo");
            frmCodBarr frmb = new frmCodBarr(txtCodigo.Text, txtDescripcion.Text, datosEmpresa.strConxAdcom, ref dataTiket);
            dataTiket = frmb.iniciarRegistro();
            frmb.Dispose();
        }
        private void actualizarTikets()
        {
            string ssql = "";
            SqlDataAdapter da ;
            if (dataTiket.Rows.Count == 0 && chkTallas.Checked)
            {
                artDatos.Actualizar();
                ssql = "select * from adctik where TIK_ARTCODI = '" + artDatos.Art_codigo + "'";
                da = new SqlDataAdapter(ssql, datosEmpresa.strConxAdcom);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DataRow dtRow = dt.NewRow();
                dtRow["TIK_ARTCODI"] = artDatos.Art_codigo;
                dtRow["TIK_TALLA"] = txtTalla.Text;
                dtRow["TIK_COLOR"] = txtColor.Text;
                dtRow["TIK_SERIE"] = "";
                dtRow["TIK_NUMERO"] = LibTallasColores.NumeroMayorTiket();
                dtRow["TIK_ALTERNO"] = "";
                dt.Rows.Add(dtRow);
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                da.Update(dt);
            }
            else
            {                  
                DataTable dt = new DataTable();
                ssql = "select * from adctik where TIK_ARTCODI = '" + artDatos.Art_codigo + "'";
                da = new SqlDataAdapter(ssql, datosEmpresa.strConxAdcom);
                dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow rrow in dt.Rows) { rrow.Delete(); }

                foreach (DataRow Nrow in dataTiket.Rows)
                {
                    try
                    {
                        if (Nrow["TIK_NUMERO"] != null)
                        {
                            if (Nrow["TIK_NUMERO"].ToString() != "")
                            {
                                DataRow dtRow = dt.NewRow();
                                dtRow["TIK_ARTCODI"] = Nrow["TIK_ARTCODI"];
                                dtRow["TIK_TALLA"] = Nrow["TIK_TALLA"];
                                dtRow["TIK_COLOR"] = Nrow["TIK_COLOR"];
                                dtRow["TIK_SERIE"] = Nrow["TIK_SERIE"];
                                dtRow["TIK_NUMERO"] = Nrow["TIK_NUMERO"];
                                dtRow["TIK_ALTERNO"] = Nrow["TIK_ALTERNO"];
                                dt.Rows.Add(dtRow);
                            }
                        }
                    }
                    catch { }
                }
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                da.Update(dt);
            }
        }
        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            txtCodigo.Text = txtCodigo.Text.Trim();
            prepararBotones();
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void btnComponentes_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text.Length > 0)
            {
                frmComponente prog = new frmComponente(txtCodigo.Text);
                prog.ShowDialog();
                prog.Dispose();
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
                    if (dialogoOpen.FileName.Length > 0) GuardarImagenDelArticulo(dialogoOpen.FileName,dialogoOpen.SafeFileName);
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
                picArticulo.Load (pathFile);
                txtNombreImagen = NameFile;
                if (pathFile != pathImagenes + NameFile) File.Copy(pathFile, pathImagenes + NameFile,true );            
            }
            catch(Exception ee)
            {
                MessageBox.Show("No se pudo cargar la imagen seleccionada)\n " +ee.Message, "Almacenar imagenes de productos");
                txtNombreImagen = "";
            }
        }
        private void LeerPatDeImagenes()
        {
            pathImagenes = "";
            DataTable dt = datosEmpresa.leeParametrosEmp("Emp_PathImagenes");
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

        private void txtNandina_Leave(object sender, EventArgs e)
        {
//            if (txtNandina.Text.Length  > 0) grabaNandina = true;
        }

        private void btnIdc1_Click(object sender, EventArgs e)
        {
            ponerCuentaContable(ref txtIdCont1, ref lblCuenta1);
        }
        private void btnIdc2_Click(object sender, EventArgs e)
        {
            ponerCuentaContable(ref txtIdCont2, ref lblCuenta2);
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

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

		private void btnPreferenciaPlatos_Click(object sender, EventArgs e)
		{
            if (txtCodigo.Text.Length > 0)
            {
                frmPlato prog = new frmPlato(txtCodigo.Text);
                prog.ShowDialog();
                prog.Dispose();
            }
        }

        private void btnCompras_Click(object sender, EventArgs e)
        {
            try
            {            
                string codigo = txtCodigo.Text;

                if (string.IsNullOrEmpty(codigo))
                {
                    MessageBox.Show("El artículo seleccionado no tiene un código válido.",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string descripcion = txtDescripcion.Text;                

                frmUltimasCompras frm = new frmUltimasCompras(datosEmpresa.strConxAdcom, codigo, descripcion, "C");
                frm.ShowDialog();
                frm.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir el historial de compras: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            try
            {
                string codigo = txtCodigo.Text;

                if (string.IsNullOrEmpty(codigo))
                {
                    MessageBox.Show("El artículo seleccionado no tiene un código válido.",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string descripcion = txtDescripcion.Text;

                frmUltimasCompras frm = new frmUltimasCompras(
                    datosEmpresa.strConxAdcom,
                    codigo,
                    descripcion,
                    "V"
                );
                frm.ShowDialog();
                frm.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir el historial de ventas: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
