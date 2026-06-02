using DattCom;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mntDirectorio
{
	public partial class MNT01 : Form
	{
		//private daaxLib.DaxLibDigDato DaaxLibDat = new daaxLib.DaxLibDigDato();
		//private EmpNomR.AdcNomb RetornaNombre = new EmpNomR.AdcNomb();
		internal string CodSuc;
		private string[] codigoDirectorio = new string[8];
		private bool Cambio;
		private string resp;
		private int ii;
		private string CodigoStr;
		private string entrega;
		private string CodigoBusca;
		public string tipoper = "N";
		public string cedulabusca;
		public string Sexo;
		private bool CambioAdicionales;
		public string CodigoFoto = "";
		private int Indice;
		private string[] TipCodSyscod = new string[51];
		private bool IniNvo;
		public string QUECODIGO;
        private bool propio;

		//private int EsNuevo;

		//private bool Act1;
		//private string[] Operacion = new string[4];
		private bool saltar = true;
		//private string accion = "";
		//private ClassCambios LosCambios = new ClassCambios();

		////private mntUsrs.autorizacion autorizaOpcion = new mntUsrs.autorizacion();
		//private string claveOpcion = "mnuoDirectorioGeneral";
		//private string ImgDirectorio = @"\Directorio\";
		DaxCombobx.CargCmbBox dc = new DaxCombobx.CargCmbBox();
		public MNT01()
		{
			InitializeComponent();			
		}

        public void IniciaNuevo()
        {
            try
            {
                IniNvo = true;
                this.ShowDialog();
            }
            catch (Exception ee)
            {
                MessageBox.Show("excepción iniNvo: " + ee.Message);
            }
        }

		private void LlenarCombos()
		{
			saltar = true;
			//dc.DaxCombosReferencia("Paises", datosEmpresa.strConxAdcom, cmbPaisDomicilio, "S");

			//dc.DaxCombosReferencia("Regiones", datosEmpresa.strConxAdcom, cmbRegionDomicilio, "S");


			//dc.DaxCombosReferencia("Paises", datosEmpresa.strConxAdcom, cmbPaisNace, "S");
			//cmbPaisNace.SelectedValue = "593";
			//dc.DaxCombosReferencia("Provincias", datosEmpresa.strConxAdcom, cmbProvinciaNace, "S");
			//dc.DaxCombosReferencia("Ciudades", datosEmpresa.strConxAdcom, cmbCiudadNace, "S");
			//dc.DaxCombosReferencia("Regiones", datosEmpresa.strConxAdcom, cmbRegionNace, "S");
			saltar = false;

			//dc.DaxCombosSuc(datosEmpresa.Emp_codigo.ToString(), false, datosEmpresa.strConIniSis, cmbSucursalRol, false);
			//dc.DaxCombosReferencia("Departamento", datosEmpresa.strConxAdcom, cmbDepartamentoRol, "S");
			//dc.DaxCombosReferencia("Seccion", datosEmpresa.strConxAdcom, cmbSeccionRol, "S");
			//dc.DaxCombosReferencia("Centro Costo", datosEmpresa.strConxAdcom, cmbCentroCostoRol, "S");
			//dc.DaxCombosReferencia("Módulo", datosEmpresa.strConxAdcom, cmbModuloRol, "S");
			//dc.DaxCombosReferencia("Cargos", datosEmpresa.strConxAdcom, cmbCargoRol, "S");

			//dc.DaxCombosReferencia("Nacionalidad", datosEmpresa.strConxAdcom, cmbNacionalidadPersonal, "S");

			//dc.DaxCombosReferencia("Profesion", datosEmpresa.strConxAdcom, cmbProfesion, "S");
			//dc.DaxCombosReferencia("Especialidad", datosEmpresa.strConxAdcom, cmbEspecialidad, "S");
			//dc.DaxCombosReferencia("Especialidad", datosEmpresa.strConxAdcom, cmbEspecialidad2, "S");
		}

		private bool leerIdentificacion()
		{
		//    Identificacion datosIdentificacion = new Identificacion(datosEmpresa.strConxAdcom);
		//    datosIdentificacion = Identificacion.Buscar(" codigo = '" + QUECODIGO + "' ");

		//    if (IsNothing(datosIdentificacion))
		//    {
		//        return false; return;
		//    }

		//    {
		//        var withBlock = datosIdentificacion;
		//        //Codigo.Text = withBlock.Codigo;
		//        tipoper = withBlock.TipoPersona;

		//        // If tipoper = "J" Then
		//        // Juridica.Checked = True
		//        // Else
		//        // tipoper = "N"
		//        // Natural.Checked = True
		//        // End If

		//        if (tipoper == "J")
		//        {
		//            Juridica.Checked = true; Natural.Checked = false;
		//        }
		//        if (tipoper == "N")
		//        {
		//            Juridica.Checked = false; Natural.Checked = true;
		//        }

		//        Cliente.Checked = withBlock.EsCliente;
		//        Proveedor.Checked = withBlock.EsProveedor;
		//        Empleado.Checked = withBlock.EsEmpleado;
		//        Banco.Checked = withBlock.EsBanco;
		//        EsVendedor.Checked = withBlock.EsVendedor;
		//        //Asociacion.Checked = withBlock.EsAsociado;

		//        // If CBool(.EsCliente")) = True Then Cliente.CheckState = CheckState.Checked Else Cliente.CheckState = CheckState.Unchecked
		//        // If CBool(.EsProveedor")) = True Then Proveedor.CheckState = CheckState.Checked Else Proveedor.CheckState = CheckState.Unchecked
		//        // If CBool(.EsEmpleado")) = True Then Empleado.CheckState = CheckState.Checked Else Empleado.CheckState = CheckState.Unchecked
		//        // If CBool(.EsBanco")) = True Then Banco.CheckState = CheckState.Checked Else Banco.CheckState = CheckState.Unchecked
		//        // If CBool(.EsVendedor")) = True Then EsVendedor.CheckState = CheckState.Checked Else EsVendedor.CheckState = CheckState.Unchecked
		//        // If CBool(.EsAsociado")) = True Then Asociacion.CheckState = CheckState.Checked Else Asociacion.CheckState = CheckState.Unchecked

		//        if (withBlock.EsDirecta == "SI")
		//            Directa.CheckState = CheckState.Checked;
		//        else
		//            Directa.CheckState = CheckState.Unchecked;

		//        //TipoIdent.SelectedIndex = System.Convert.ToInt32(Val(ArreglaId(System.Convert.ToHexString(CorrijeNulo(withBlock.TipoIdentificacion))))); // : TIPID = CStr(TipoIdent.SelectedIndex)
		//        TxtCedulaRuc.Text = withBlock.CedulaIdentidadRuc;
		//        TxtNombres.Text = withBlock.Nombres;
		//        //Apellidos.Text = withBlock.Apellidos;
		//        //impresion.Text = withBlock.NombreImpresion;

		//        //TxtNroDomicilio.Text = withBlock.NumeroDomicilio;
		//        //cmbPaisDomicilio.SelectedValue = withBlock.País;
		
					//cmbProvinciaDomicilio.SelectedValue = Provincia;
			//      cmbParroquiaDomicilio.SelectedValue = withBlock.Casilla;
			//      cmbCantonDomicilio.SelectedValue = withBlock.Sector;
			//      cmbCiudadDomicilio.SelectedValue = withBlock.Ciudad;
			//      cmbRegionDomicilio.Text = withBlock.regionDomicilio;

			//        txtnomDireccion.Text = withBlock.Domicilio;
			//        txtTelefono1.Text = withBlock.Telefono1;
			//        txtTelefono2.Text = withBlock.Telefono2;
			//        txtTelefono3.Text = withBlock.Telefono3;
			//        TxtData6.Text = withBlock.NúmeroFax;
			//        // !correoelectrónico = TxtData8.Text
			//        TxtData8.Text = withBlock.CorreoElectrónico;
			//        TxtData9.Text = withBlock.Paginaweb;
			//        //txtGrupo1.Text = withBlock.Grupo1;
			//        //txtGrupo2.Text = withBlock.Grupo2;
			//        //txtGrupo3.Text = withBlock.Grupo3;
			//        txtHistoriaclinica.Text = withBlock.HistoriaClinica;
			//        CodigoFoto = withBlock.Logotipo;
			//        // -----------------------------) Then PorComision.Text = .ComisionVenta")
			//        // -----------------------------ones Then Text1.Text = .CtaCobrarComisiones")

			//        if (datosEmpresa.usr != withBlock.CodGrabo & withBlock.CodGrabo > "")
			//            propio = false;
			//        else
			//            propio = true;

			//        ExoneradoIva.Checked = withBlock.ExoneradoIva;
			//        chkRise.Checked = withBlock.esRise;
			//        txtContribuyenteEspecial.Text = withBlock.NroCtrbuyteEspecial;
			//        chkObligaContabilidad.Checked = withBlock.ObligLlevarConta;
			//        chkRegimenMicroempresas.Checked = withBlock.RegimenMicroempresas;

			//        txtSector.Text = withBlock.SectorDomicilio;
			//        TxtResolucionAR.Text = withBlock.NroAcdoAgntRetencion;
			   //}
			    return true;
		}



		private void btnGuardar_Click(object sender, EventArgs e)
		{
			try
			{                           
                if (validacionDatos() == true)
                {
                    MessageBox.Show("");
                }

            }
			catch (Exception ex)
			{
                ex.Message.ToString();
			}
		}

		private Boolean validacionDatos()
		{           
            if (string.IsNullOrEmpty(TxtCedulaRuc.Text)) { MessageBox.Show("Digite una Identificacion Válida"); return false; }
            if (string.IsNullOrEmpty(TipoIdent.Text)) { MessageBox.Show("Falta el tipo de identificación"); return false; }
                       
            return true;
        }

		private void TxtCedulaRuc_TextChanged(object sender, EventArgs e)
		{

		}

		private void btnNuevo_Click(object sender, EventArgs e)
		{
            //CrearNuevo();
        }

		

		private void cmbProvinciaDomicilio_SelectedIndexChanged(object sender, EventArgs e)
		{
			CargarCantonDomicilio();
		}

		private void CargarProvinciasDomicilio()
		{
			// Calls the method DaxCombosReferencia on the dc object with the provided parameters.
			dc.DaxCombosReferencia("Provincias", datosEmpresa.strConxAdcom,ref cmbProvinciaDomicilio, "S");
		}

		private void CargarCantonDomicilio()
		{
			// Calls the method DaxCombosReferencia on the dc object with the provided parameters.
			dc.DaxCombosCantones(datosEmpresa.strConxAdcom, ref cmbCantonDomicilio, false,provincia(),true);
			CargarParroquiaDomicilio();
			CargarCiudadDomicilio();
		}

		private void CargarCiudadDomicilio()
		{
			string prov = provincia();
			if (prov == "")
				return;
			dc.DaxCombosCiudades(datosEmpresa.strConxAdcom, ref cmbCiudadDomicilio, false, prov, canton());
			regionDomicilio();
		}
		private void CargarParroquiaDomicilio()
		{
			// Calls the method DaxCombosReferencia on the dc object with the provided parameters.
			dc.DaxCombosParroquias(datosEmpresa.strConxAdcom, ref cmbParroquiaDomicilio, false, provincia(), canton(), true);
		}

		private string provincia()
		{
			string prv = "";
			try
			{
				prv = cmbProvinciaDomicilio.SelectedValue.ToString();
			}
			catch (Exception ex)
			{
				prv = "";
			}
			return prv;
		}

		private string canton()
		{
			string prv = "";
			try
			{
				prv = cmbCantonDomicilio.SelectedValue.ToString();
			}
			catch (Exception ex)
			{
				prv = "";
			}
			return prv;
		}
		private void regionDomicilio()
		{
			// Dim reg As String = "0"
			string reg = "0";
			// If IsNothing(cmbCiudadDomicilio.SelectedValue) = False Then
			if (cmbCiudadDomicilio.SelectedValue != null)
			{
				// reg = cmbCiudadDomicilio.SelectedValue.ToString().Substring(0, 1)
				reg = cmbCiudadDomicilio.SelectedValue.ToString().Substring(0, 1);
			}
			// cmbRegionDomicilio.SelectedValue = reg
			//cmbRegionDomicilio.SelectedValue = reg;
		}

		private void regionNacimiento()
		{
			string reg = "0";
			if (cmbCiudadNace.SelectedValue != null)
			{
				reg = cmbCiudadNace.SelectedValue.ToString().Substring(0, 1);
			}
			cmbRegionNace.SelectedValue = reg;
		}

		
		private void CargarCiudadNacimiento()
		{
			// Calls the method DaxCombosReferencia on the dc object with the provided parameters.
			dc.DaxCombosCiudades(datosEmpresa.strConxAdcom, ref cmbCiudadNace, false, provinciaN(), "");
		}
		private string provinciaN()
		{
			string prv = "";
			try
			{
				prv = cmbProvinciaNace.SelectedValue.ToString();
			}
			catch (Exception ex)
			{
				prv = "";
			}
			return prv;
		}

		private void MNT01_Load(object sender, EventArgs e)
		{

		}

		private void cmbPaisDomicilio_Leave(object sender, EventArgs e)
		{
			ComboBox cmb = sender as ComboBox;
			if (cmb != null && cmb.SelectedValue == null)
			{
				cmb.Text = "";
			}
		}

		private void cmbPaisDomicilio_SelectedIndexChanged(object sender, EventArgs e)
		{
			CargarProvinciasDomicilio();
		}
	}
}
