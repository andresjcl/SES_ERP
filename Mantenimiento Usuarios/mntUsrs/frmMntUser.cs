using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace mntUsrs
{
    public partial class frmMntUser : Form
    {
        Boolean usuarioExiste=false;     
        string strConxDaxsys="";
        readonly string strConxAdcom = "";
        Int16 CodigoEmpresa=0;
        string sistema="";
        string nombreEmpresa="";
        string pathAppl="";
        sys_Usuario datUsr;
        int proceso = 0;     // 0 ninguno 1 nuevo 2 consulta

        public frmMntUser(string pathapl, string strconsys,string strconadc, Int16 empCod,string empNom, string sys)
        {
            InitializeComponent();
            strConxDaxsys = strconsys;
            strConxAdcom = strconadc;
            CodigoEmpresa = empCod;
            nombreEmpresa = empNom;
            pathAppl = pathapl;
            sistema = sys;
            datUsr = new sys_Usuario(strConxDaxsys);
            opcionesIniciales();
            controlBotones();
        }
        private void opcionesIniciales()
        {
            btnAdcomDax.Visible = (sistema == "CNX");
            //btnMedica.Visible = (DattCom.datosEmpresa.ControlMedico || DattCom.datosEmpresa.sistema == "DDM");
            //btnNomina.Visible = (DattCom.datosEmpresa.RolDePagos || DattCom.datosEmpresa.sistema == "BEE");
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSistema_Click(object sender, EventArgs e)
        {
            mntUsrs.frmMntAutoriza prog = new mntUsrs.frmMntAutoriza(pathAppl, strConxDaxsys,strConxAdcom, txtIdentificacion.Text , CodigoEmpresa,nombreEmpresa , sistema);
            prog.ShowDialog();
            prog.Dispose();
            prog = null;
        }

        private void btnDirectorio_Click(object sender, EventArgs e)
        {
            mntUsrs.frmDirectorio prog = new mntUsrs.frmDirectorio(strConxDaxsys, txtIdentificacion.Text, CodigoEmpresa, nombreEmpresa, sistema);
            prog.ShowDialog();
            prog.Dispose();
            prog = null;
        }

        private void btnNomina_Click(object sender, EventArgs e)
        {
            mntUsrs.frmNomina prog = new mntUsrs.frmNomina(strConxDaxsys, txtIdentificacion.Text, CodigoEmpresa, nombreEmpresa, sistema);
            prog.ShowDialog();
            prog.Dispose();
            prog = null;
        }
        private void txtCodigoDirectorio_Leave(object sender, EventArgs e)
        {
            if (txtCodigoDirectorio.Text != "") buscarDatosConDirectorio(txtIdentificacion.Text);
        }

        private void controlBotones()
        {
            txtIdentificacion.ReadOnly = usuarioExiste;
            btnBuscaUsuarios.Enabled = !usuarioExiste;

            btnNomina.Enabled = usuarioExiste;
            btnAdcomDax.Enabled = usuarioExiste;
            btnMedica.Enabled = usuarioExiste;

            btnDirectorio.Enabled = usuarioExiste;
            btnDocumentos.Enabled = usuarioExiste;
            btnLocales.Enabled = usuarioExiste;

            btnGuardar.Enabled = (proceso > 0);
            btnCopiar.Enabled = (proceso == 1);
            btnElimina.Enabled = (proceso == 2);
            btnNuevo.Enabled = (proceso == 0);
        }

        private void CBuscador13_Click(object sender, EventArgs e)
        {
            Buscar.frmBuscar progBus = new Buscar.frmBuscar();
            EmpNomR.AdcNomb elNombre = new EmpNomR.AdcNomb();
            
            string ssql = "select Codigo,NombreImpresion from identificacion where esEmpleado = 1 or esvendedor = 1  ";
            string codigo = progBus.Buscar(strConxAdcom, ssql, "Codigo", "NombreImpresion", "", "Busqueda directorio empleados", "");
            txtCodigoDirectorio.Text = codigo;
            NombreDirectorio.Text  = elNombre.RetornaNombreDirectorio(codigo, strConxAdcom);
            progBus.Dispose ();
            
        }
        private void buscarDatosConDirectorio(string codigo)
        {
            usuarioExiste = false;
            datUsr = sys_Usuario.Buscar(" codUsuario ='" + codigo + "' ");
            if (datUsr != null) visualizarDatosUsuario(datUsr);
            else datUsr = new sys_Usuario();
            controlBotones();
        }

        private void buscarDatosConUsuario(string codigo)
        {
            usuarioExiste = false;
            datUsr = sys_Usuario.Buscar("idusuario = '" + codigo + "' ");
            if (datUsr != null) visualizarDatosUsuario(datUsr);
            else datUsr = new sys_Usuario();
            controlBotones();
        }

        private void visualizarDatosUsuario(sys_Usuario syus)
        {
            EmpNomR.AdcNomb qnombre = new EmpNomR.AdcNomb();
            txtIdentificacion.Text = syus.IdUsuario;
            txtCodigoDirectorio.Text = syus.CodUsuario;
            if (txtCodigoDirectorio.Text != "") NombreDirectorio.Text = qnombre.RetornaNombreDirectorio(syus.CodUsuario, strConxAdcom);
            try
            {
                dtValidoHasta.Value = syus.FechaCaduca;
            }
            catch
            {
                dtValidoHasta.Value = DateTime.Now;
            }
            txtPassword.Text = syus.Contraseña;
            txtDiasCambia.Text = syus.DíasDuraContraseña.ToString();
            usuarioExiste = (txtIdentificacion.Text.Length > 0);
            proceso = 2;
        }

        private void btnBuscaUsuarios_Click(object sender, EventArgs e)
        {
            Buscar.frmBuscar busc = new Buscar.frmBuscar();
            string ssql = "select idUsuario,codUsuario from sys_usuario where idusuario != 'Administrador'";
            string usuario = busc.Buscar(strConxDaxsys, ssql, "idUsusario", "codUsuario", "", "Busqueda de usuarios");
            busc.Dispose();
            if (usuario != "") buscarDatosConUsuario(usuario);
            //usuarioExiste = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtIdentificacion.Text.Length  == 0) return;
            if (txtPassword.Text != txtPasswordVerifica.Text) { MessageBox.Show("Las clave de seguridad no coincide con la verificación");return; }            
            datUsr.CodUsuario = txtCodigoDirectorio.Text ;
            datUsr.Contraseña = txtPassword.Text ;
            datUsr.DíasDuraContraseña =Convert.ToInt32( txtDiasCambia.Text);
            datUsr.FechaCaduca = dtValidoHasta.Value ;
            datUsr.IdUsuario = txtIdentificacion.Text;
            string resp = datUsr.Actualizar();
            if (resp.Substring(0, 3) == "ERR")
            {
                MessageBox.Show("Excepción grabando usuario \n" + resp);
                return;
            }
            else 
            {
                MessageBox.Show("Usuario registrado exitosamente ");
                usuarioExiste=true;
                controlBotones();
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            proceso = 1;
            controlBotones();
        }
        private void limpiar()
        {
            txtIdentificacion.Text = "";
            txtCodigoDirectorio.Text = "";
            NombreDirectorio.Text = "";
            dtValidoHasta.Value = DateTime.Now;
            txtPassword.Text = "";
            txtDiasCambia.Text = "";
            datUsr = new sys_Usuario();
            txtIdentificacion.ReadOnly = false;
            btnBuscaUsuarios.Enabled = true;
            usuarioExiste = false;
            proceso = 0;
            controlBotones();
        }

        private void btnCopiar_Click(object sender, EventArgs e)
        {
            Buscar.frmBuscar busc = new Buscar.frmBuscar();
            string ssql = "select idUsuario,codUsuario from sys_usuario where (idusuario <> 'Administrador' and idusuario <> '" + txtIdentificacion.Text + "') ";
            string userOrg = busc.Buscar(strConxDaxsys, ssql, "idUsusario", "codUsuario", "", "Busqueda de usuarios");
            busc.Dispose();
            busc = null;
            if (userOrg.Length > 0)
            {
                if (MessageBox.Show("Confirma copiar el perfil de autorizaciones \n desde el usuario: " + userOrg + " al usuario: " + txtIdentificacion.Text, "Copiar perfil de usuario", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No) return;
            }
            copiarDatosUsuario(userOrg, txtIdentificacion.Text, CodigoEmpresa, CodigoEmpresa);
        }

        private void copiarDatosUsuario(string usrOriginal, string usrDestino, Int32 empresaOrg, Int32 empresaDest )
        {
            Cursor = Cursors.WaitCursor;
            string ssql = "adcCopPerf " + empresaOrg.ToString () + "," + empresaDest.ToString() + ",'" + usrOriginal + "','" + usrDestino + "'";
            ManejoBases mb = new ManejoBases();
            mb.ejecutarComando(strConxDaxsys, ssql);
            Cursor = Cursors.Default ;
        }

        private void btnElimina_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Confirma eliminar el usuario actual del sistema ?,", "Eliminar perfil del usuario", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No) return;
            
            string ssql = "delete from sys_usuario where idusuario = '" + txtIdentificacion.Text + "'";
            SqlConnection conn = new SqlConnection ( strConxDaxsys);
            conn.Open() ;
            SqlCommand comm = new SqlCommand(ssql,conn) ;
            comm.ExecuteNonQuery();

            ssql = "delete from sys_accesos where idusuario = '" + txtIdentificacion.Text + "'";
            comm = new SqlCommand(ssql, conn);
            comm.ExecuteNonQuery();

            ssql = "delete from sys_bodegas where idusuario = '" + txtIdentificacion.Text + "'";
            comm = new SqlCommand(ssql, conn);
            comm.ExecuteNonQuery();

            ssql = "delete from sys_sucursales where idusuario = '" + txtIdentificacion.Text + "'";
            comm = new SqlCommand(ssql, conn);
            comm.ExecuteNonQuery();

            ssql = "delete from sys_documentos where idusuario = '" + txtIdentificacion.Text + "'";
            comm = new SqlCommand(ssql, conn);
            comm.ExecuteNonQuery();

            comm.Dispose();
            comm = null;
            ssql = null;
        }
        private void btnMedica_Click(object sender, EventArgs e)
        {
            FrmMedico progMed = new FrmMedico(strConxDaxsys ,txtIdentificacion.Text,CodigoEmpresa ,nombreEmpresa ,sistema);
            progMed.ShowDialog();
        }


        private void btnLocales_Click(object sender, EventArgs e)
        {
            mntUsrs.FrmSucursales prog = new mntUsrs.FrmSucursales (pathAppl, strConxDaxsys, strConxAdcom, txtIdentificacion.Text, CodigoEmpresa, nombreEmpresa, sistema);
            prog.ShowDialog();
            prog.Dispose();
            prog = null;
        }

        private void btnDocumentos_Click(object sender, EventArgs e)
        {
            mntUsrs.FrmDocumentos prog = new FrmDocumentos(pathAppl, strConxDaxsys, strConxAdcom, txtIdentificacion.Text, CodigoEmpresa, nombreEmpresa, sistema);
            prog.ShowDialog();
            prog.Dispose();
            prog = null;
        }
        private void txtIdentificacion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode== Keys.Return && txtIdentificacion.Text != "") buscarDatosConUsuario(txtIdentificacion.Text);
        }

        private void NombreDirectorio_Click(object sender, EventArgs e)
        {

        }

		private void frmMntUser_Load(object sender, EventArgs e)
		{

		}
	}
}