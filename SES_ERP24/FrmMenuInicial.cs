using DattCom;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using IvaRett;
using DctosEmi;
using adcDocumentos;

namespace SES_ERP24
{
	public partial class FrmMenuInicial : Form
	{
		private HashSet<string> _permisosCache = null;

		public FrmMenuInicial()
		{
			InitializeComponent();
			menugeneral.Renderer = new ExtendedToolStripRendered();
			cargarInformacionVisual();

			this.Load += FrmMenuInicial_LoadPermisos;
		}

		private void FrmMenuInicial_LoadPermisos(object sender, EventArgs e)
		{
			AplicarFiltroPermisosAutomatico();
		}

		#region Métodos Automáticos de Permisos (Usando SOLO el Tag)

		private HashSet<string> ObtenerPermisosUsuario()
		{
			if (_permisosCache != null)
			{
				return _permisosCache;
			}

			_permisosCache = new HashSet<string>();

			string usuarioActual = DattCom.datosEmpresa.usr;
			bool esAdministrador = usuarioActual.ToUpper() == "ADMINISTRADOR" || usuarioActual.ToUpper() == "ADMIN";

			if (esAdministrador)
			{
				return _permisosCache;
			}

			try
			{
				string usuario = DattCom.datosEmpresa.usr;

				if (!string.IsNullOrEmpty(usuario) && usuario.Contains(" "))
				{
					usuario = usuario.Split(' ')[0];
				}

				int empresa = Convert.ToInt32(DattCom.datosEmpresa.Emp_codigo);
				string sistema = "CNX";
				string strConx = DattCom.datosEmpresa.strConIniSis; 

				string ssql = $@"SELECT DISTINCT IdOpcion FROM sys_Accesos 
					   WHERE UPPER(LTRIM(RTRIM(IdUsuario))) = '{usuario.ToUpper().Trim()}' 
					   AND IdEmpresa = {empresa} 
					   AND IdSistema = '{sistema}' 
					   AND Accesos = 'T'";

				DataTable dtPermisos = DattCom.SqlDatos.leerTabla(ssql, strConx);

				if (dtPermisos != null)
				{
					foreach (DataRow row in dtPermisos.Rows)
					{
						string opcion = row["IdOpcion"].ToString().Trim();
						if (!string.IsNullOrEmpty(opcion))
						{
							_permisosCache.Add(opcion);
						}
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error al obtener permisos: " + ex.Message);
			}

			return _permisosCache;
		}

		private void AplicarFiltroPermisosAutomatico()
		{
			string usuarioActual = DattCom.datosEmpresa.usr;
			bool esAdministrador = usuarioActual.ToUpper() == "ADMINISTRADOR" || usuarioActual.ToUpper() == "ADMIN";

			if (esAdministrador)
			{
				MostrarTodosLosMenus();
				return;
			}

			HashSet<string> permisosUsuario = ObtenerPermisosUsuario();

			if (permisosUsuario.Count == 0)
			{
				MessageBox.Show("No se encontraron permisos para el usuario", "Advertencia");
				return;
			}

			// Ocultar TODOS los menús principales primero
			foreach (ToolStripMenuItem menu in menugeneral.Items)
			{
				menu.Visible = false;
			}

			// Recorrer cada menú principal y sus submenús
			foreach (ToolStripMenuItem menuPrincipal in menugeneral.Items)
			{
				bool tienePermisoEnEsteMenu = false;

				foreach (ToolStripItem subItem in menuPrincipal.DropDownItems)
				{
					if (subItem is ToolStripMenuItem subMenu)
					{
						string tag = subMenu.Tag?.ToString();

						if (!string.IsNullOrEmpty(tag) && permisosUsuario.Contains(tag))
						{
							subMenu.Visible = true;
							tienePermisoEnEsteMenu = true;
						}
						else
						{
							subMenu.Visible = false;
						}
					}
				}

				// Si el menú tiene al menos un submenú visible, mostrarlo
				if (tienePermisoEnEsteMenu)
				{
					menuPrincipal.Visible = true;
				}
			}

			// FORZAR el refresco del MenuStrip
			menugeneral.PerformLayout();
			menugeneral.Invalidate();
			panelOpciones.Invalidate();
			this.Refresh();
			Application.DoEvents();
		}

		private void MostrarTodosLosMenus()
		{
			foreach (ToolStripMenuItem menuPrincipal in menugeneral.Items)
			{
				menuPrincipal.Visible = true;

				foreach (ToolStripItem subItem in menuPrincipal.DropDownItems)
				{
					if (subItem is ToolStripMenuItem subMenu)
					{
						subMenu.Visible = true;
					}
				}
			}

			menugeneral.PerformLayout();
			menugeneral.Invalidate();
		}

		#endregion

		#region Clase Renderer

		class ExtendedToolStripRendered : ToolStripProfessionalRenderer
		{
			protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
			{
				e.Item.ForeColor = Color.White;

				if (e.Item.Selected)
				{
					e.Graphics.Clear(Color.Black);
				}
				else
					e.Graphics.Clear(Color.DimGray);
			}
		}

		#endregion

		#region Métodos Existentes

		private void ConfigurarMenuItem(ToolStripMenuItem item, Image icono)
		{
			item.Image = icono;
			item.ImageAlign = ContentAlignment.MiddleLeft;
			item.TextAlign = ContentAlignment.MiddleLeft;
			item.TextImageRelation = TextImageRelation.ImageBeforeText;
			item.ImageScaling = ToolStripItemImageScaling.None;
			item.AutoSize = false;
			item.Size = new Size(332, 36);
			item.Font = new Font("Calibri", 14.25F, FontStyle.Regular);
			item.ForeColor = Color.White;
			item.BackColor = Color.DimGray;
		}

		private void cargarInformacionVisual()
		{
			if (DattCom.DatosUsuario.codigo == "") { panelOpciones.Enabled = false; }
			DctosEmi.valoresPredefinidosSucursal.cargarValores();
			Text += "Sistema SES-ERP";
			label3.Text = DattCom.datosEmpresa.Emp_Nombre + " - " + datosEmpresa.suc + " - " + DattCom.datosEmpresa.SucursalNombre;
			labNombreProfesionalAtiende.Text = "Equipo: " + DctosEmi.valoresPredefinidosSucursal.nomPuntoVta + " - Usuario:  " + DattCom.datosEmpresa.usr.ToUpper();
			VisualizarFechaYhora();
		}

		private void VisualizarFechaYhora()
		{
			string ssql = "select getdate()";
			System.Data.SqlClient.SqlDataReader dr = DattCom.SqlDatos.leerBase(ssql, datosEmpresa.strConxSyscod);
			if (dr.Read())
			{
				labFecha.Text = Convert.ToDateTime(dr[0]).ToLongDateString();
			}
			else
			{
				labFecha.Text = DateTime.Now.ToLongDateString();
			}
			dr.Close();
		}

		#endregion

		#region Eventos de Menú

		private void btnEmitirFacturasDirectas_Click(object sender, EventArgs e)
		{
			if (!AutorizarLlamadas.VerificaAutorización("FACEmitir")) return;
			DctosEmi.FormFactCliente prog = new DctosEmi.FormFactCliente("FAC", "", true, false, false, false, null);
			prog.Show();
		}

		private void registrosToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!AutorizarLlamadas.VerificaAutorización("DGRegistros")) return;
			directMnt.BusDirectorio prog = new directMnt.BusDirectorio();
			string codigo = "";
			prog.ManDir(ref codigo);
			prog = null;
		}

		private void toolStripMenuItem3_Click(object sender, EventArgs e)
		{
			if (!AutorizarLlamadas.VerificaAutorización("FAPEmitir")) return;
			DctosEmi.FormFactProveedor prog = new DctosEmi.FormFactProveedor("FAP", "", true, false, false, false, null);
			prog.Show();
		}

		private void reporteGeneralToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!AutorizarLlamadas.VerificaAutorización("DGReporteG")) return;
			directMnt.lisDir prog = new directMnt.lisDir();
			prog.MallaDir("D");
			prog = null;
		}

		private void mantenDocToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!AutorizarLlamadas.VerificaAutorización("MntDocumentos")) return;
			sesSys.ClsSysp13 PROG = new sesSys.ClsSysp13();
			PROG.SbSysp13();
		}

		private void btnManEmpresa_Click(object sender, EventArgs e)
		{
			if (!AutorizarLlamadas.VerificaAutorización("MtnEmpresa")) return;
			EmpMant.frmEmp ptovta = new EmpMant.frmEmp();
			ptovta.ShowDialog();
			ptovta.Dispose();
		}

		private void mntProductosToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!AutorizarLlamadas.VerificaAutorización("MntArticulos")) return;
			DaxInvent.DaxInventarios.MantenimientoArticulos();
		}

		private void menReporDoc_Click(object sender, EventArgs e)
		{
			if (!AutorizarLlamadas.VerificaAutorización("RepListadoDoc")) return;
			ListadoDocumentos.frmRepDoc prog = new ListadoDocumentos.frmRepDoc();
			prog.Show();
		}

		private void toolStripMenuItem5_Click(object sender, EventArgs e)
		{
			if (!AutorizarLlamadas.VerificaAutorización("NCPEmitir")) return;
			DctosEmi.FormDevProveedor prog = new DctosEmi.FormDevProveedor("DEP", "DEP", true, false, false, false, null);
			prog.Show();
		}

		private void btnRegistrarCitas_Click(object sender, EventArgs e)
		{
			if (!AutorizarLlamadas.VerificaAutorización("IMPEmitir")) return;
			DctosEmi.FormIngImportacion prog = new DctosEmi.FormIngImportacion("IMP", "", true, false, false, false, null);
			prog.Show();
		}

		private void btnEmitirFacturasPedidos_Click(object sender, EventArgs e)
		{
			if (!AutorizarLlamadas.VerificaAutorización("FACEmitirPed")) return;
			DctosEmi.emiFacPed prog = new DctosEmi.emiFacPed();
			prog.Show();
		}

		private void btnEmitirPedidos_Click(object sender, EventArgs e)
		{
			if (!AutorizarLlamadas.VerificaAutorización("PEDEmitir")) return;
			DctosEmi.FormPedCliente prog = new DctosEmi.FormPedCliente("PEC", "", true, false, false, false, null);
			prog.Show();
		}

		private void menRegistrarRTP_Click(object sender, EventArgs e)
		{
			if (!AutorizarLlamadas.VerificaAutorización("RTPEmitir")) return;
			IvaRett.MantRetencion prog = new MantRetencion("RTP", "RTP", 1, null, false);
			prog.Show();
		}

		private void btnlistaGeneral_Click(object sender, EventArgs e)
		{
			if (!AutorizarLlamadas.VerificaAutorización("CtaCorrListaGen")) return;
			CtasCorrientes.FrmListaCtasCorrientes prog = new CtasCorrientes.FrmListaCtasCorrientes();
			prog.Show();
		}

		private void egresosBco_Click(object sender, EventArgs e)
		{
			if (!AutorizarLlamadas.VerificaAutorización("DocBancos")) return;
			frmEgrBcoCaj prog = new frmEgrBcoCaj("EGR", "", true, false, false, false);
			prog.Show();
		}

		private void toolStripMenuItem6_Click(object sender, EventArgs e)
		{
			if (!AutorizarLlamadas.VerificaAutorización("SolicAutorizaSRI")) return;
			DaxCelec.FrmDaxCelec prog = new DaxCelec.FrmDaxCelec();
			prog.Show();
		}

		private void btnAnalisisIndividual_Click(object sender, EventArgs e)
		{
			if (!AutorizarLlamadas.VerificaAutorización("CtaCorrAnalisInd")) return;
			CtasCorrientes.frmAnalisisIndCta prog = new CtasCorrientes.frmAnalisisIndCta();
			prog.Show();
		}

		private void menuInvenDoc_Click(object sender, EventArgs e)
		{
			if (!AutorizarLlamadas.VerificaAutorización("IngInventario")) return;
			DctosEmi.FormDocInventario prog = new DctosEmi.FormDocInventario("IBG", "", true, false, false, false, null);
			prog.Show();
		}

		private void menuInvenEBG_Click(object sender, EventArgs e)
		{
			if (!AutorizarLlamadas.VerificaAutorización("EgrInventario")) return;
			DctosEmi.FormDocInventario prog = new DctosEmi.FormDocInventario("EBG", "", true, false, false, false, null);
			prog.Show();
		}

		private void serviciosToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!AutorizarLlamadas.VerificaAutorización("MntServiciosCprasVta")) return;
			DaxConceptos.frmMntServicios prog = new DaxConceptos.frmMntServicios(true);
			prog.Show();
		}

		private void serviciosBancosToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!AutorizarLlamadas.VerificaAutorización("MntServiciosBco")) return;
			DaxConceptos.frmMantConceptos prog = new DaxConceptos.frmMantConceptos(true);
			prog.Show();
		}

		private void FacPtoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!AutorizarLlamadas.VerificaAutorización("FACEmitirPto")) return;
			FormFacPV prog = new FormFacPV("FAC", "", true, false, false, false, null);
			prog.Show();
		}

		private void menRegistrarRTC_Click(object sender, EventArgs e)
		{
			if (!AutorizarLlamadas.VerificaAutorización("RTCEmitir")) return;
			IvaRett.MantRetencion prog = new MantRetencion("RTC", "RTC", 1, null, false);
			prog.Show();
		}

		private void autorizacionesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!AutorizarLlamadas.VerificaAutorización("MtnUsers")) return;
			mntUsrs.frmMntUser frmMntUser = new mntUsrs.frmMntUser(datosEmpresa.pathAppl, datosEmpresa.strConIniSis, datosEmpresa.strConxAdcom, Convert.ToInt16(datosEmpresa.Emp_codigo), datosEmpresa.Emp_Nombre, "CNX");
			frmMntUser.ShowDialog();
			frmMntUser.Dispose();
		}

		private void toolStripMenuItem12_Click(object sender, EventArgs e)
		{
			if (!AutorizarLlamadas.VerificaAutorización("ProfEmitir")) return;
			FormProforma prog = new FormProforma("PRC", "", true, false, false, false, null);
			prog.Show();
		}

		private void mnuMomivientoArt_Click(object sender, EventArgs e)
		{
			if (!AutorizarLlamadas.VerificaAutorización("MovtArticulos")) return;
			DaxInvent.DaxInventarios.MovimientosPorArtículo();
		}

		private void mnuExistenBod_Click(object sender, EventArgs e)
		{
			if (!AutorizarLlamadas.VerificaAutorización("ExisBod")) return;
			DaxInvent.frmExistenciaBod prog = new DaxInvent.frmExistenciaBod();
			prog.Show();
		}

		private void menMantMed_Click(object sender, EventArgs e)
		{
			if (!AutorizarLlamadas.VerificaAutorización("MntMedidas")) return;
			DaxInvent.FrmMantMed prog = new DaxInvent.FrmMantMed("");
			prog.Show();
		}

		private void menRecostear_Click(object sender, EventArgs e)
		{
			if (!AutorizarLlamadas.VerificaAutorización("Recostear")) return;
			DaxInvent.FrmRecosteo prog = new DaxInvent.FrmRecosteo();
			prog.Show();
		}

		private void mnuPlanCuentas_Click(object sender, EventArgs e)
		{
			if (!AutorizarLlamadas.VerificaAutorización("mnplanCuentas")) return;
			var prog = new CtaMtn.CTBP01();
			prog.Show();
		}

		private void menuFormasPago_Click(object sender, EventArgs e)
		{
			if (!AutorizarLlamadas.VerificaAutorización("MntFormaPago")) return;
			comercP.FormPago prog = new comercP.FormPago();
			prog.Show();
		}

		private void menuMatTablasSRI_Click(object sender, EventArgs e)
		{
			if (!AutorizarLlamadas.VerificaAutorización("MntTablasSRI")) return;
			IvaRett.MntTablasSri prog = new MntTablasSri();
			prog.Show();
		}

		private void mnBalances_Click(object sender, EventArgs e)
		{
			if (!AutorizarLlamadas.VerificaAutorización("MntBalances")) return;
			CtbRepBal.frmBalances prog = new CtbRepBal.frmBalances();
			prog.Show();
		}

		private void mnConciliacionBancaria_Click(object sender, EventArgs e)
		{
			if (!AutorizarLlamadas.VerificaAutorización("MnConciliacionBancos")) return;
			DaxBan.frmConBan prog = new DaxBan.frmConBan();
			prog.Show();
		}

		private void menDirectorioImp_Click(object sender, EventArgs e)
		{
			if (!AutorizarLlamadas.VerificaAutorización("importarDataCli")) return;
			importarData.ImportarDirectorio prog = new importarData.ImportarDirectorio();
			prog.Show();
		}

		private void menCuentasContables_Click(object sender, EventArgs e)
		{
			if (!AutorizarLlamadas.VerificaAutorización("importarDataCuentas")) return;
			importarData.ImportarPlanDeCuentas prog = new importarData.ImportarPlanDeCuentas();
			prog.Show();
		}

		private void menGuiaR_Click(object sender, EventArgs e)
		{
			if (!AutorizarLlamadas.VerificaAutorización("REMEmitir")) return;
			DctosEmi.FormRemision prog = new DctosEmi.FormRemision("REM", "", true, false, false, false, null);
			prog.Show();
		}

		private void menImportarProductos_Click(object sender, EventArgs e)
		{
			if (!AutorizarLlamadas.VerificaAutorización("importarDataProd")) return;
			importarData.ImportarPlanDeCuentas prog = new importarData.ImportarPlanDeCuentas();
			prog.Show();
		}

		#endregion

		#region Eventos de Formulario

		private void FrmMenuInicial_Load(object sender, EventArgs e) { }

		private void FrmMenuInicial_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason != CloseReason.ApplicationExitCall)
			{
				DattCom.ManejoDatosEmpresa.ResetearEmpresaRegistrada();
			}
		}

		private void btnMaximizar_Click(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Maximized;
			btnNormal.Visible = true;
			btnMaximizar.Visible = false;
		}

		private void btnNormal_Click(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Normal;
			btnNormal.Visible = false;
			btnMaximizar.Visible = true;
		}

		private void btnMinimizar_Click(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Minimized;
		}

		private void menAdministracion_Click(object sender, EventArgs e) { }
		private void menDirectorio_Click(object sender, EventArgs e) { }
		private void toolStripMenuItem1_Click(object sender, EventArgs e) { }
		private void MenImagenologia_Click(object sender, EventArgs e) { }
		private void defHorariosCajasToolStripMenuItem_Click(object sender, EventArgs e) { }
		private void eventosDelSistemaToolStripMenuItem_Click(object sender, EventArgs e) { }
		private void toolStripMenuItem7_Click(object sender, EventArgs e) { }

        #endregion

        private void mnCreacionBco_Click(object sender, EventArgs e)
        {
			if (!AutorizarLlamadas.VerificaAutorización("MnCrearBancos")) return;
			DaxBan.CtasBanForm prog = new DaxBan.CtasBanForm();
			prog.Show();



			

		}
    }
}