using System;
using System.Windows.Forms;
using DattCom;

namespace IngSis
{
	public partial class Acceso : Form
	{
		Int32 Validaciones = 0;
		public Acceso(string Aplicativo = "SISTEMA-AC16")
		{
			InitializeComponent();
			iniciaAplicación();
			Text = "REGISTRAR INGRESO AL SISTEMA " + Aplicativo;
		}

        private void iniciaAplicación()
        {
            //Aqui se realizo el cambio por tema de licenciamiento. Y segenero el dll
            double Licencias = LicDefAct.ChequeoLicencias.ChequearLicencias(datosEmpresa.Major, datosEmpresa.pathServer, datosEmpresa.pathAppl, datosEmpresa.sistema, datosEmpresa.auto, "23031957");
            //double Licencias = 1;
            //DattCom.datosEmpresa.strConIniSis = datosEmpresa.strConxSyscod;
            //DattCom.datosEmpresa.auto = datosEmpresa.auto;
            if (Licencias == 0)
            {
                MessageBox.Show("Error 1112 - No existen licencias activadas para el sistema");
                Environment.Exit(0);
            }


            //             ControlUsuario = CONUSER.UsuarioAct;
            RecuerdaOpciones.leerOpciones(datosEmpresa.strConxSyscod);
            if (RecuerdaOpciones.usuario.Length > 0 && RecuerdaOpciones.clave.Length > 0)
            {
                IdIngreso.Text = RecuerdaOpciones.usuario;
                ClaveSecreta.Text = RecuerdaOpciones.clave;
            }

            chkGuardarClaves.Checked = (ClaveSecreta.Text != "");

            if (IdIngreso.Text == "")
            {
                IdIngreso.Text = System.Environment.UserName.ToString();
            }

            if (ClaveSecreta.Text != "" && IdIngreso.Text != "")
            {
                //if (DelUsuario.VerificarClave(ClaveSecreta.Text, IdIngreso.Text) != "")
                {
                    EmpresaInicio.cargarEmpresasUsuario(Convert.ToInt32(RecuerdaOpciones.empresa), IdIngreso.Text, DcEmp);
                    if (Convert.ToInt32(RecuerdaOpciones.empresa) == 0)
                    {
                        DcEmp.SelectedValue = EmpresaInicio.EmpresaDeInicio(IdIngreso.Text);
                    }
                }
                if (DatosUsuario.Estado == 0 && DcEmp.Items.Count > 0)
                {
                    if (DcEmp.SelectedValue == null)
                    {
                        DcEmp.SelectedIndex = 0;
                        BtnContinuar.Focus();
                    }
                    else
                    {
                        IdIngreso.Focus();
                    }
                }
            }
            BtnContinuar.Enabled = true;
        }
        private void chkGuardarClaves_CheckedChanged(object sender, EventArgs e)
		{

		}

		private void BtnContinuar_Click(object sender, EventArgs e)
		{
            if (verificacionDeSalida()) { RegistrarAcceso(); Close(); }
        }

        private Boolean verificacionDeSalida()
        {
            Validaciones++;
            if (Validaciones > 3)
            {
                MessageBox.Show("Ha llegado al máximo número de intentos el sistema se cerrará");
                Environment.Exit(0);
            }
            if (ClaveSecreta.Text == "")
            {
                MessageBox.Show("Debe digitar su clave secreta");
                ClaveSecreta.Focus();
                return false;
            }
            if (IdIngreso.Text == "")
            {
                MessageBox.Show("Debe digitar su identificación de acceso");
                IdIngreso.Focus();
                return false;
            }
            if (DcEmp.Items.Count < 1 || DcEmp.SelectedValue == null)
            {
                MessageBox.Show("No existe una empresa definida o seleccionada para procesar");
                return false;
            }
            //            string[] pasar = datosEmpresa.marca.Split(Convert.ToChar(","));
            datosEmpresa.Emp_codigo = Convert.ToInt16(DcEmp.SelectedValue);
            ManejoDatosEmpresa.LeerDatosEmpresa(datosEmpresa.strConxSyscod, datosEmpresa.UsuarioBd, datosEmpresa.ClaveBd, datosEmpresa.Servidor);
            if (datosEmpresa.Emp_codigo == 0)
            {
                MessageBox.Show("Existe error al cargar la empresa seleccionada");
                return false;
            }
            if (DelUsuario.VerificarClave(ClaveSecreta.Text, IdIngreso.Text).Length > 0)
            {
                //    datosEmpresa.Emp_codigo = Convert.ToInt16(DcEmp.SelectedValue);
                return true;
            }
            else
            {
                return false;
            }
        }

		private void DcEmp_Click(object sender, EventArgs e)
		{
            datosEmpresa.Emp_codigo = Convert.ToInt16(DcEmp.SelectedValue);
        }

		private void btnSalir_Click(object sender, EventArgs e)
		{
            DattCom.ManejoDatosEmpresa.ResetearEmpresaRegistrada();
            Environment.Exit(0);
        }

		private void IdIngreso_TextChanged(object sender, EventArgs e)
		{
            DcEmp.DataSource = null;
            BtnContinuar.Enabled = false;
        }

		private void IdIngreso_Leave(object sender, EventArgs e)
		{
            if (DcEmp.Items.Count == 0 && IdIngreso.Text.Length > 0)
            {
                if (IdIngreso.Text == RecuerdaOpciones.usuario)
                {
                    EmpresaInicio.cargarEmpresasUsuario(Convert.ToInt16(RecuerdaOpciones.empresa), IdIngreso.Text, DcEmp);
                }
                else
                {
                    EmpresaInicio.cargarEmpresasUsuario(0, IdIngreso.Text, DcEmp);
                }
                BtnContinuar.Enabled = true;
            }
        }

		private void Acceso_FormClosing(object sender, FormClosingEventArgs e)
		{
            string conclave = ClaveSecreta.Text;
            if (!chkGuardarClaves.Checked) { conclave = ""; }
            RecuerdaOpciones.guardarOpciones(datosEmpresa.strConxSyscod, conclave);
            if (e.CloseReason != CloseReason.ApplicationExitCall)
            {
                DattCom.ManejoDatosEmpresa.ResetearEmpresaRegistrada();
            }
        }

        private void RegistrarAcceso()
        {
			if (IdIngreso.Text.ToUpper() == "ADMINISTRADOR")
			{
                DattCom.ManejoDatosEmpresa.grabarEmpresaRegistrada(DcEmp.SelectedValue.ToString(), IdIngreso.Text);

                datosEmpresa.usr = IdIngreso.Text;
                //datosEmpresa.codEmpresa = Convert.ToInt16(datosEmpresa.Emp_codigo);
                //datosEmpresa.nomEmpresa = datosEmpresa.Emp_Nombre;
                //datosEmpresa.suc = datosEmpresa.sucursal;
                //datosEmpresa.sucNom = datosEmpresa.suc;

                datosEmpresa.codEmpresa = Convert.ToInt16(DcEmp.SelectedValue);
                //datosEmpresa. = DcEmp.Text;
                datosEmpresa.usr = IdIngreso.Text;

                // quitar cuando se elimine definitivamente varblecomun 

                //datosEmpresa.strConxAdcom = datosEmpresa.strConxAdcom;
                //datosEmpresa.strConxIvaret = datosEmpresa.strConxIvaret;
                //datosEmpresa.strConxDaxpro = datosEmpresa.strConxDaxpro;
                //datosEmpresa.suc = datosEmpresa.sucursal;
                //datosEmpresa.sucNom = datosEmpresa.SucursalNombre;

                //

                IngSis.EmpresaInicio.IniciaEmpresa();
            }
			else
			{
                DattCom.ManejoDatosUsuario.LeerDatosUsuarioDirectorio();
                //DattCom.datosEmpresa.sistema = datosEmpresa.sistema;
                //DattCom.datosEmpresa.pathAppl = datosEmpresa.pathAppl;
                DattCom.ManejoDatosEmpresa.grabarEmpresaRegistrada(DcEmp.SelectedValue.ToString(), IdIngreso.Text);

                datosEmpresa.usr = IdIngreso.Text;
                //datosEmpresa.codEmpresa = Convert.ToInt16(datosEmpresa.Emp_codigo);
                //datosEmpresa.nomEmpresa = datosEmpresa.Emp_Nombre;
                //datosEmpresa.suc = datosEmpresa.sucursal;
                //datosEmpresa.sucNom = datosEmpresa.suc;

                datosEmpresa.codEmpresa = Convert.ToInt16(DcEmp.SelectedValue);
                //datosEmpresa. = DcEmp.Text;
                datosEmpresa.usr = IdIngreso.Text;

                // quitar cuando se elimine definitivamente varblecomun 

                //datosEmpresa.strConxAdcom = datosEmpresa.strConxAdcom;
                //datosEmpresa.strConxIvaret = datosEmpresa.strConxIvaret;
                //datosEmpresa.strConxDaxpro = datosEmpresa.strConxDaxpro;
                //datosEmpresa.suc = datosEmpresa.sucursal;
                //datosEmpresa.sucNom = datosEmpresa.SucursalNombre;

                //

                IngSis.EmpresaInicio.IniciaEmpresa();
            }
            
            
        }

		private void label5_Click(object sender, EventArgs e)
		{

		}
	}
}
