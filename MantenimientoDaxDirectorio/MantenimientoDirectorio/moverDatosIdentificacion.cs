using DattCom;
using Microsoft.VisualBasic.CompilerServices;

namespace directMnt
{
	public class moverDatosIdentificacion
	{
		public void movDatIdentificacion(DEEP01 frmId, Identificacion recide, string[] Lcodir)
		{
			var buscod = new EmpNomR.AdcNomb();
			recide.RegistroMunicp = "";
			recide.TipoPersona = frmId.tipoper;
			if (recide.TipoPersona != "J")
				recide.TipoPersona = "N";
			recide.TipoIdentificacion = TipoIdGenerall(frmId.TipoIdent.SelectedIndex.ToString());
			recide.Telefono1 = frmId.txtTelefono1.Text;
			recide.Telefono2 = frmId.txtTelefono2.Text;
			recide.Telefono3 = frmId.txtTelefono3.Text;
			recide.NroCtrbuyteEspecial = frmId.txtContribuyenteEspecial.Text;
			recide.ObligLlevarConta = frmId.chkObligaContabilidad.Checked;
			recide.RegimenMicroempresas = frmId.chkRegimenMicroempresas.Checked;

			recide.NroAcdoAgntRetencion = frmId.TxtResolucionAR.Text;

			recide.Codigo = frmId.Codigo.Text;
			recide.Apellidos = frmId.Apellidos.Text;
			recide.CedulaIdentidadRuc = frmId.TxtCedulaRuc.Text;
			recide.CodGrabo = datosEmpresa.usr;
			recide.CodAsociacion = Lcodir[3];
			recide.ComisionVenta = 0m;
			recide.CtaCobrarComisiones = "";
			recide.CorreoElectrónico = frmId.TxtData8.Text;
			recide.Domicilio = frmId.txtnomDireccion.Text;
			recide.EsCliente = frmId.Cliente.Checked;
			recide.EsProveedor = frmId.Proveedor.Checked;
			recide.EsEmpleado = frmId.Empleado.Checked;
			recide.EsBanco = frmId.Banco.Checked;
			recide.EsVendedor = frmId.EsVendedor.Checked;
			recide.EsAsociado = frmId.Asociacion.Checked;
			if (frmId.Directa.Checked)
				recide.EsDirecta = "SI";
			else
				recide.EsDirecta = "NO";
			recide.esRise = frmId.chkRise.Checked;
			recide.ExoneradoIva = frmId.ExoneradoIva.Checked;
			recide.FichaDental = "";
			recide.Grupo1 = frmId.txtGrupo1.Text;
			recide.Grupo2 = frmId.txtGrupo2.Text;
			recide.Grupo3 = frmId.txtGrupo3.Text;
			recide.HistoriaClinica = frmId.txtHistoriaclinica.Text;
			recide.Logotipo = frmId.CodigoFoto;
			recide.NombreImpresion = frmId.impresion.Text;
			recide.Nombres = frmId.TxtNombres.Text;
			recide.NúmeroFax = frmId.TxtData6.Text;
			recide.NumeroDomicilio = frmId.TxtNroDomicilio.Text;
			recide.Paginaweb = frmId.TxtData9.Text;

			if (frmId.cmbPaisDomicilio.SelectedValue == null == false)
				recide.País = frmId.cmbPaisDomicilio.SelectedValue.ToString(); // buscod.RetornaCodigoSyscod("Paises", frmId.txtNomPais.Text, datosEmpresa.strConxSyscod)
			if (frmId.cmbProvinciaDomicilio.SelectedValue == null == false)
				recide.Provincia = frmId.cmbProvinciaDomicilio.SelectedValue.ToString();  // //; buscod.RetornaCodigoSyscod("Provincias", frmId.cmbProvinciaDomicilio.Text, datosEmpresa.strConxSyscod)
			if (frmId.cmbCantonDomicilio.SelectedValue == null == false)
				recide.Sector = frmId.cmbCantonDomicilio.SelectedValue.ToString(); // buscod.RetornaCodigoSyscod("Cantones", frmId.cmbCantonDomicilio.Text, datosEmpresa.strConxSyscod)
			if (frmId.cmbParroquiaDomicilio.SelectedValue == null == false)
				recide.Casilla = frmId.cmbParroquiaDomicilio.SelectedValue.ToString(); // ; buscod.RetornaCodigoSyscod("Parroquias", frmId.cmbParroquiaDomicilio.Text, datosEmpresa.strConxSyscod)
			if (frmId.cmbCiudadDomicilio.SelectedValue == null == false)
				recide.Ciudad = frmId.cmbCiudadDomicilio.SelectedValue.ToString();  // buscod.RetornaCodigoSyscod("Ciudades", frmId.cmbCiudadDomicilio.Text, datosEmpresa.strConxSyscod)

			recide.regionDomicilio = frmId.cmbRegionDomicilio.Text;

			recide.SectorDomicilio = frmId.txtSector.Text;
		}
		public void movDatIdentificacion(DEEPPCTE frmId, Identificacion recide, string[] Lcodir)
		{
			var buscod = new EmpNomR.AdcNomb();
			recide.Codigo = frmId.Codigo.Text;
			recide.Apellidos = frmId.Apellidos.Text;
			recide.CedulaIdentidadRuc = frmId.TxtCedulaRuc.Text;
			recide.CodGrabo = datosEmpresa.usr;
			recide.CodAsociacion = Lcodir[3];
			recide.ComisionVenta = 0m;
			recide.CtaCobrarComisiones = "";
			recide.CorreoElectrónico = frmId.TxtData8.Text;
			recide.Domicilio = frmId.txtnomDireccion.Text;
			recide.EsCliente = false;
			recide.EsProveedor = false;
			recide.EsEmpleado = false;
			recide.EsBanco = false;
			recide.EsVendedor = false;
			recide.EsAsociado = false;
			// If frmId.Directa.Checked Then .EsDirecta = "SI" Else .EsDirecta = "NO"
			recide.esRise = frmId.chkRise.Checked;
			recide.ExoneradoIva = frmId.ExoneradoIva.Checked;
			recide.FichaDental = "";
			recide.Grupo1 = frmId.txtGrupo1.Text;
			recide.Grupo2 = frmId.txtGrupo2.Text;
			recide.Grupo3 = frmId.txtGrupo3.Text;
			recide.HistoriaClinica = frmId.txtHistoriaclinica.Text;
			recide.Logotipo = frmId.CodigoFoto;
			recide.NombreImpresion = frmId.impresion.Text;
			recide.Nombres = frmId.TxtNombres.Text;
			recide.NúmeroFax = frmId.TxtData6.Text;
			recide.NumeroDomicilio = frmId.TxtNroDomicilio.Text;
			recide.Paginaweb = frmId.TxtData9.Text;

			recide.País = frmId.cmbPaisDomicilio.SelectedValue.ToString(); // buscod.RetornaCodigoSyscod("Paises", frmId.txtNomPais.Text, datosEmpresa.strConxSyscod)
			recide.Provincia = frmId.cmbProvinciaDomicilio.SelectedValue.ToString(); // buscod.RetornaCodigoSyscod("Provincias", frmId.cmbProvinciaDomicilio.Text, datosEmpresa.strConxSyscod)
			recide.Sector = frmId.cmbCantonDomicilio.SelectedValue.ToString(); // buscod.RetornaCodigoSyscod("Cantones", frmId.cmbCantonDomicilio.Text, datosEmpresa.strConxSyscod)
			recide.Casilla = frmId.cmbParroquiaDomicilio.SelectedValue.ToString(); // ; buscod.RetornaCodigoSyscod("Parroquias", frmId.cmbParroquiaDomicilio.Text, datosEmpresa.strConxSyscod)
			recide.Ciudad = frmId.cmbCiudadDomicilio.SelectedValue.ToString(); // buscod.RetornaCodigoSyscod("Ciudades", frmId.cmbCiudadDomicilio.Text, datosEmpresa.strConxSyscod)
			recide.regionDomicilio = frmId.cmbRegionDomicilio.Text;


			recide.RegistroMunicp = "";
			recide.TipoPersona = frmId.tipoper;
			recide.TipoIdentificacion = TipoIdGenerall(frmId.TipoIdent.SelectedIndex.ToString());
			recide.Telefono1 = frmId.txtTelefono1.Text;
			recide.Telefono2 = frmId.txtTelefono2.Text;
			recide.Telefono3 = frmId.txtTelefono3.Text;
			recide.NroCtrbuyteEspecial = frmId.txtContribuyenteEspecial.Text;
			recide.ObligLlevarConta = frmId.chkObligaContabilidad.Checked;
			recide.RegimenMicroempresas = frmId.chkRegimenMicroempresas.Checked;

			recide.SectorDomicilio = frmId.txtSector.Text;
			recide.NroAcdoAgntRetencion = frmId.TxtResolucionAR.Text;
		}
		public void movDatIdentificacionCli(DEEPCLI frmId, Identificacion recide, string[] Lcodir)
		{
			var buscod = new EmpNomR.AdcNomb();
			recide.Codigo = frmId.Codigo.Text;
			recide.Apellidos = frmId.Apellidos.Text;
			recide.Casilla = buscod.RetornaCodigoSyscod("Parroquias", frmId.txtNomParroquia.Text, datosEmpresa.strConxSyscod);
			recide.CedulaIdentidadRuc = frmId.Datox0.Text;
			recide.Ciudad = buscod.RetornaCodigoSyscod("Ciudades", frmId.txtNomCiudad.Text, datosEmpresa.strConxSyscod);
			recide.CodGrabo = datosEmpresa.usr;
			recide.CodAsociacion = Lcodir[3];
			// .ComisionVenta = 0
			// .CtaCobrarComisiones = ""
			recide.CorreoElectrónico = frmId.TxtData8.Text;
			recide.Domicilio = frmId.txtnomDireccion.Text;
			recide.EsCliente = true;
			// .EsProveedor = False
			// .EsEmpleado = False
			// .EsBanco = frmId.Banco.Checked
			// .EsVendedor = frmId.EsVendedor.Checked
			// .EsAsociado = frmId.Asociacion.Checked
			// If frmId.Directa.Checked Then .EsDirecta = "SI" Else .EsDirecta = "NO"
			recide.esRise = frmId.chkRise.Checked;
			recide.ExoneradoIva = frmId.ExoneradoIva.Checked;
			// .FichaDental = ""
			recide.Grupo1 = frmId.txtGrupo1.Text;
			recide.Grupo2 = frmId.txtGrupo2.Text;
			recide.Grupo3 = frmId.txtGrupo3.Text;
			recide.HistoriaClinica = frmId.txtHistoriaclinica.Text;
			recide.Logotipo = frmId.CodigoFoto;
			recide.NombreImpresion = frmId.impresion.Text;
			recide.Nombres = frmId.Datox1.Text;
			recide.NúmeroFax = frmId.TxtData6.Text;
			recide.NumeroDomicilio = frmId.TxtData2.Text;
			recide.Paginaweb = frmId.TxtData9.Text;
			recide.País = buscod.RetornaCodigoSyscod("Paises", frmId.txtNomPais.Text, datosEmpresa.strConxSyscod);
			recide.Provincia = buscod.RetornaCodigoSyscod("Provincias", frmId.txtNomProvincia.Text, datosEmpresa.strConxSyscod);
			// .RegistroMunicp = ""
			recide.Sector = buscod.RetornaCodigoSyscod("Cantones", frmId.TxtNomCanton.Text, datosEmpresa.strConxSyscod);
			recide.TipoPersona = frmId.tipoper;
			recide.TipoIdentificacion = TipoIdGenerall(frmId.TipoIdent.SelectedIndex.ToString());
			recide.Telefono1 = frmId.txtTelefono1.Text;
			recide.Telefono2 = frmId.txtTelefono2.Text;
			recide.Telefono3 = frmId.txtTelefono3.Text;
			recide.NroCtrbuyteEspecial = frmId.txtContribuyenteEspecial.Text;
			recide.ObligLlevarConta = frmId.chkObligaContabilidad.Checked;
			recide.regionDomicilio = frmId.txtRegion.Text;
			recide.SectorDomicilio = frmId.txtSector.Text;
		}

		public void movControlADatIdentificacion(DEEP01 frmId, Identificacion recide, string[] Lcodir)
		{
			var buscod = new EmpNomR.AdcNomb();
			frmId.Codigo.Text = recide.Codigo;
			frmId.Apellidos.Text = recide.Apellidos;
			frmId.cmbParroquiaDomicilio.Text = buscod.RetornaNombreSyscod("Parroquias", recide.Casilla, datosEmpresa.strConxSyscod);
			frmId.TxtCedulaRuc.Text = recide.CedulaIdentidadRuc;
			frmId.cmbCiudadDomicilio.Text = buscod.RetornaNombreSyscod("Ciudades", recide.Ciudad, datosEmpresa.strConxSyscod);
			// .CodGrabo = datosEmpresa.usr
			Lcodir[3] = recide.CodAsociacion;
			// .ComisionVenta = 0
			// .CtaCobrarComisiones = ""
			frmId.TxtData8.Text = recide.CorreoElectrónico;
			frmId.txtnomDireccion.Text = recide.Domicilio;
			frmId.Cliente.Checked = recide.EsCliente;
			frmId.Proveedor.Checked = recide.EsProveedor;
			frmId.Empleado.Checked = recide.EsEmpleado;
			frmId.Banco.Checked = recide.EsBanco;
			frmId.EsVendedor.Checked = recide.EsVendedor;
			frmId.Asociacion.Checked = recide.EsAsociado;
			if (recide.EsDirecta == "SI")
				frmId.Directa.Checked = true;
			else
				frmId.Directa.Checked = false;
			frmId.chkRise.Checked = recide.esRise;
			frmId.ExoneradoIva.Checked = recide.ExoneradoIva;
			// .FichaDental = ""
			frmId.txtGrupo1.Text = recide.Grupo1;
			frmId.txtGrupo2.Text = recide.Grupo2;
			frmId.txtGrupo3.Text = recide.Grupo3;
			frmId.txtHistoriaclinica.Text = recide.HistoriaClinica;
			frmId.CodigoFoto = recide.Logotipo;
			frmId.impresion.Text = recide.NombreImpresion;
			frmId.TxtNombres.Text = recide.Nombres;
			frmId.TxtData6.Text = recide.NúmeroFax;
			frmId.TxtNroDomicilio.Text = recide.NumeroDomicilio;
			frmId.TxtData9.Text = recide.Paginaweb;
			frmId.cmbPaisDomicilio.Text = buscod.RetornaNombreSyscod("Paises", recide.País, datosEmpresa.strConxSyscod);
			frmId.cmbProvinciaDomicilio.Text = buscod.RetornaNombreSyscod("Provincias", recide.Provincia, datosEmpresa.strConxSyscod);
			// .RegistroMunicp = ""
			frmId.cmbCantonDomicilio.Text = buscod.RetornaNombreSyscod("Cantones", recide.Sector, datosEmpresa.strConxSyscod);
			frmId.tipoper = recide.TipoPersona;
			frmId.TipoIdent.SelectedIndex = Conversions.ToInteger(TipoIdGenerall(recide.TipoIdentificacion));
			frmId.txtTelefono1.Text = recide.Telefono1;
			frmId.txtTelefono2.Text = recide.Telefono2;
			frmId.txtTelefono3.Text = recide.Telefono3;
			frmId.txtContribuyenteEspecial.Text = recide.NroCtrbuyteEspecial;
			frmId.chkObligaContabilidad.Checked = recide.ObligLlevarConta;
			frmId.cmbRegionDomicilio.Text = recide.regionDomicilio;
			frmId.txtSector.Text = recide.SectorDomicilio;

			frmId.TxtResolucionAR.Text = recide.NroAcdoAgntRetencion;
		}
		private string TipoIdGenerall(string Ident)
		{

			switch (Ident ?? "")
			{
				case "O":
				case "0":
					{
						return "O";
					}
				case "R":
				case "1":
					{
						return "R";
					}
				case "C":
				case "2":
					{
						return "C";
					}
				case "P":
				case "3":
					{
						return "P";
					}
				case "F":
				case "4":
					{
						return "F";
					}
			}
			return "O";
		}

	}
}