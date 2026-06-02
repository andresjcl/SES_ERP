using System;
using System.Windows.Forms;
using DattCom;
using Microsoft.VisualBasic;

namespace directMnt
{


	public partial class ActualizaDirectorio
	{

		// Dim RsAlex As New ADODB.Recordset
		private Identificacion datosDir;
		private bool Sicambio = false;

		public ActualizaDirectorio()
		{
			InitializeComponent();
			Label75 = _Label75;
			chkEmpresa = _chkEmpresa;
			TipoIdent = _TipoIdent;
			fTipo = _fTipo;
			chkPersona = _chkPersona;
			btncancelar = _btncancelar;
			fprincipal1 = _fprincipal1;
			fprincipal = _fprincipal;
			txtSector = _txtSector;
			lbsector = _lbsector;
			TxtEmail = _TxtEmail;
			TxtTelefono2 = _TxtTelefono2;
			TxtDireccion = _TxtDireccion;
			TxtApellidos = _TxtApellidos;
			TxtNombres = _TxtNombres;
			TxtTelefono1 = _TxtTelefono1;
			TxtNombreImpresion = _TxtNombreImpresion;
			Label7 = _Label7;
			Label9 = _Label9;
			Label5 = _Label5;
			Label2 = _Label2;
			Label6 = _Label6;
			rr = _rr;
			Label4 = _Label4;
			TxtRucCi = _TxtRucCi;
			Label1 = _Label1;
			btncontinuar = _btncontinuar;
			_Label75.Name = "Label75";
			_chkEmpresa.Name = "chkEmpresa";
			_TipoIdent.Name = "TipoIdent";
			_fTipo.Name = "fTipo";
			_chkPersona.Name = "chkPersona";
			_btncancelar.Name = "btncancelar";
			_fprincipal1.Name = "fprincipal1";
			_fprincipal.Name = "fprincipal";
			_txtSector.Name = "txtSector";
			_lbsector.Name = "lbsector";
			_TxtEmail.Name = "TxtEmail";
			_TxtTelefono2.Name = "TxtTelefono2";
			_TxtDireccion.Name = "TxtDireccion";
			_TxtApellidos.Name = "TxtApellidos";
			_TxtNombres.Name = "TxtNombres";
			_TxtTelefono1.Name = "TxtTelefono1";
			_TxtNombreImpresion.Name = "TxtNombreImpresion";
			_Label7.Name = "Label7";
			_Label9.Name = "Label9";
			_Label5.Name = "Label5";
			_Label2.Name = "Label2";
			_Label6.Name = "Label6";
			_rr.Name = "rr";
			_Label4.Name = "Label4";
			_TxtRucCi.Name = "TxtRucCi";
			_Label1.Name = "Label1";
			_btncontinuar.Name = "btncontinuar";
		}
		public bool Actualizacion(string codigo, string strConx)
		{
			datosDir = new Identificacion(strConx);
			datosDir = Identificacion.Buscar(" codigo = '" + codigo + "'");
			if (datosDir is not null)
			{

				{
					ref var withBlock = ref datosDir;
					TxtRucCi.Text = withBlock.CedulaIdentidadRuc;
					TxtNombres.Text = withBlock.Nombres;
					TxtApellidos.Text = withBlock.Apellidos;
					TxtDireccion.Text = withBlock.Domicilio;
					TxtTelefono1.Text = withBlock.Telefono1;
					TxtTelefono2.Text = withBlock.Telefono2;
					TxtEmail.Text = withBlock.CorreoElectrónico;
					TxtNombreImpresion.Text = withBlock.NombreImpresion;
					txtSector.Text = withBlock.Sector;
					string localArreglaId() { string argIdent = withBlock.TipoIdentificacion; var ret = ArreglaId(ref argIdent); withBlock.TipoIdentificacion = argIdent; return ret; }

					TipoIdent.SelectedIndex = Convert.ToInt16(localArreglaId());
					if (datosDir.TipoPersona == "N")
						chkPersona.Checked = true;
					else
						chkEmpresa.Checked = true;
				}
			}
			ShowDialog();
			return Sicambio;
		}
		private void apellidos_TextChanged(object sender, EventArgs e)
		{

			if (Emp.OrdenaPorApellidos == false)
			{
				TxtNombreImpresion.Text = Strings.Trim(TxtNombres.Text + " " + TxtApellidos.Text);
			}
			else
			{
				TxtNombreImpresion.Text = Strings.Trim(TxtApellidos.Text + " " + TxtNombres.Text);
			}
			Sicambio = true;

		}

		private void btncontinuar_Click(object sender, EventArgs e)
		{
			if (Sicambio)
			{
				if (validarDatos())
				{
					Grabar();
					Close();
				}
			}
		}
		private bool validarDatos()
		{

			if (string.IsNullOrEmpty(TipoIdent.Text))
			{
				Interaction.MsgBox("Falta el tipo de identificación", MsgBoxStyle.Critical);
				TipoIdent.Focus();
				return false;
			}
			if (string.IsNullOrEmpty(TxtRucCi.Text))
			{
				Interaction.MsgBox("Debe ingresar el RUC o CI", MsgBoxStyle.Information);
				TxtRucCi.Focus();
				return false;
			}

			if (ValidaNumeroId() == false)
			{
				Interaction.MsgBox("El numero del documento de identificacion está errado ", MsgBoxStyle.Critical);
				TxtRucCi.Focus();
				return false;
			}

			if (string.IsNullOrEmpty(TxtTelefono1.Text))
			{
				Interaction.MsgBox("Debe ingresar al menos un teléfono del cliente ", MsgBoxStyle.Information);
				TxtTelefono1.Focus();
				return false;
			}
			if (string.IsNullOrEmpty(TxtNombres.Text))
			{
				Interaction.MsgBox("Debe ingresar el nombre ", MsgBoxStyle.Information);
				TxtNombres.Focus();
				return false;
			}
			if (string.IsNullOrEmpty(TxtDireccion.Text))
			{
				Interaction.MsgBox("Debe ingresar la dirección ", MsgBoxStyle.Information);
				TxtDireccion.Focus();
				return false;
			}

			if (chkPersona.Checked)
			{
				if (string.IsNullOrEmpty(TxtApellidos.Text))
				{
					TxtApellidos.Focus();
					Interaction.MsgBox("Debe ingresar el apellido", MsgBoxStyle.Information);
					return false;
				}
			}

			var recIdOtr = new Identificacion(datosEmpresa.strConxAdcom);
			recIdOtr = Identificacion.Buscar("cedulaidentidadruc='" + TxtRucCi.Text + "' and codigo <> '" + datosDir.Codigo + "' ");
			if (recIdOtr is not null)
			{
				Interaction.MsgBox("El Nro. ID (cédula o ruc) ya existe ", MsgBoxStyle.Critical);
				recIdOtr = null;
				return false;
			}
			recIdOtr = null;
			return true;
		}
		private void btncancelar_Click(object sender, EventArgs e)
		{
			Close();
		}
		private void btnsalir_Click()
		{
			Close();
			Dispose();
		}
		private void ActualizaDir_FormClosed(object sender, FormClosedEventArgs e)
		{
			Dispose();
		}

		private void Grabar()
		{
			string resp = "";

			{
				ref var withBlock = ref datosDir;
				if (chkPersona.Checked == true)
				{
					withBlock.TipoPersona = "N";
				}
				else
				{
					withBlock.TipoPersona = "J";
				}
				withBlock.CedulaIdentidadRuc = TxtRucCi.Text;
				withBlock.Nombres = TxtNombres.Text;
				withBlock.Apellidos = TxtApellidos.Text;
				withBlock.NombreImpresion = TxtNombreImpresion.Text;
				withBlock.Telefono1 = TxtTelefono1.Text;
				withBlock.Telefono2 = TxtTelefono2.Text;
				withBlock.CorreoElectrónico = TxtEmail.Text;

				withBlock.Domicilio = TxtDireccion.Text;

				string argIdent = TipoIdent.SelectedIndex.ToString();
				withBlock.TipoIdentificacion = TipoIdGeneral(ref argIdent);

				withBlock.Sector = txtSector.Text;
				resp = withBlock.Actualizar();
			}
			if (resp.Substring(0, 5).ToUpper() == "ERROR")
			{
				if (MessageBox.Show(@"El registro no se puede actualizar \n" + resp + @"\n CONFIRMA SALIR ?", "Actualizar registro de directorio", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.OK)
				{
					Close();
					return;
				}
			}
		}
		private bool ValidaNumeroId()
		{
			bool ValidaNumeroIdRet = default;
			// Dim i As Integer
			string tipoId = "";
			string Persona = "P";
			;

#error Cannot convert OnErrorResumeNextStatementSyntax - see comment for details
			/* Cannot convert OnErrorResumeNextStatementSyntax, CONVERSION ERROR: Conversion for OnErrorResumeNextStatement not implemented, please report this issue in 'On Error Resume Next' at character 6405


						Input:
								On Error Resume Next

						 */
			switch (TipoIdent.SelectedIndex)
			{
				case 0:
					{
						tipoId = "R";
						break;
					}
				case 1:
					{
						tipoId = "C";
						break;
					}
				case 2:
					{
						tipoId = "P";
						break;
					}
			}
			if (chkEmpresa.Checked)
				Persona = "E";
			var prog = new valIdcedru.valcedruc();
			ValidaNumeroIdRet = prog.valCr(TxtRucCi.Text, tipoId, Persona);
			return ValidaNumeroIdRet;
		}

		private string ArreglaId(ref string Ident)
		{
			string ArreglaIdRet = default;
			ArreglaIdRet = Ident;
			switch (Ident ?? "")
			{
				case "R":
					{
						ArreglaIdRet = 0.ToString();
						break;
					}
				case "C":
					{
						ArreglaIdRet = 1.ToString();
						break;
					}
				case "P":
					{
						ArreglaIdRet = 2.ToString();
						break;
					}
			}

			return ArreglaIdRet;
		}

		private string TipoIdGeneral(ref string Ident)
		{
			string TipoIdGeneralRet = default;
			TipoIdGeneralRet = "O";
			switch (Ident ?? "")
			{
				case "R":
				case "0":
					{
						TipoIdGeneralRet = "R";
						break;
					}
				case "C":
				case "1":
					{
						TipoIdGeneralRet = "C";
						break;
					}
				case "P":
				case "2":
					{
						TipoIdGeneralRet = "P";
						break;
					}
			}

			return TipoIdGeneralRet;
		}

		private void TxtDireccion_TextChanged(object sender, EventArgs e)
		{
			Sicambio = true;
		}

		private void TxtTelefono1_TextChanged(object sender, EventArgs e)
		{
			Sicambio = true;
		}

		private void TxtTelefono2_TextChanged(object sender, EventArgs e)
		{
			Sicambio = true;
		}

		private void TxtEmail_TextChanged(object sender, EventArgs e)
		{
			Sicambio = true;
		}
	}
}