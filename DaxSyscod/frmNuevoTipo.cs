using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DattCom;
namespace Syscod
{
    public partial class frmNuevoTipo : Form
    {
        private int cambios = 0;
       // private string strcon = "";
        private string @ref = "";
        private string TipReferencia = "";
        private ClassSyscod syscodData = new ClassSyscod();
        public frmNuevoTipo( string tipo)
        {            
            InitializeComponent();
            @ref = tipo;
            iniciar();
        }

        private void iniciar()
        {
            if (@ref != "")
            {
                cargar(@ref); bloquear_desbloquear(false); txtTipoRef.Text = @ref;
            }
            GroupBox1.Enabled = true;
            bloquear_desbloquear(false);
        }

        private void btnNuevo_Click(System.Object sender, System.EventArgs e)
        {
            GroupBox1.Enabled = true;
            txtTipoRef.Focus();
            bloquear_desbloquear(false);
        }

        private void bloquear_desbloquear(bool op)
        {
            btnNuevo.Visible = op;
            btnAbrir.Visible = op;
            btnSalir.Visible = op;
            btnGuardar.Visible = !op;
            btnEliminar.Visible = !op;
            btnCancelar.Visible = !op;
            btnEliminarCaract.Visible = !op;
            GroupBox1.Enabled = !op;
        }

        private void limpiar()
        {
            txtTipoRef.Text = "";
            txtCaract1.Text = "";
            txtCaract2.Text = "";
            txtCaract3.Text = "";
            txtCaract4.Text = "";
            txtCaract5.Text = "";
            cboTipo1.Text = "";
            cboTipo2.Text = "";
            cboTipo3.Text = "";
            cboTipo4.Text = "";
            cboTipo5.Text = "";
            txtLong1.Text = "";
            txtLong2.Text = "";
            txtLong3.Text = "";
            txtLong4.Text = "";
            txtLong5.Text = "";
            txtdec1.Text = "";
            txtdec2.Text = "";
            txtdec3.Text = "";
            txtdec4.Text = "";
            txtdec5.Text = "";
        }

        private void btnCerrar_Click(System.Object sender, System.EventArgs e)
        {
            if (cambios > 0)
            {
                if (MessageBox.Show("Desea guardar los cambios?","", MessageBoxButtons.YesNo , MessageBoxIcon.Question) == DialogResult.Yes )
                {
                    Guardar();
                    limpiar();
                    bloquear_desbloquear(true);
                    cambios = 0;
                }
                else 
                {
                    limpiar();
                    bloquear_desbloquear(true);
                    cambios = 0;
                }
            }
            else
            {
                limpiar();
                bloquear_desbloquear(true);
                cambios = 0;
            }
        }


        private void btnGuardar_Click(System.Object sender, System.EventArgs e)
        {
            Guardar();
            limpiar();
            bloquear_desbloquear(true);
            cambios = 0;
        }

        private bool verificar()
        {
            bool bandera = true;
            // If txtTipoRef.Text = "" Then bandera = False
            // If txtCaract1.Text <> "" And cboTipo1.Text <> "" And txtLong1.Text = "" And txtdec1.Text = "" Then bandera = False
            // If txtCaract2.Text <> "" And cbotipo2.Text <> "" And txtLong2.Text = "" And txtdec2.Text = "" Then bandera = False
            // If txtCaract3.Text <> "" And cboTipo3.Text <> "" And txtLong3.Text = "" And txtdec3.Text = "" Then bandera = False
            // If txtCaract4.Text <> "" And cboTipo4.Text <> "" And txtLong4.Text = "" And txtdec4.Text = "" Then bandera = False
            // If txtCaract5.Text <> "" And cboTipo5.Text <> "" And txtLong5.Text = "" And txtdec5.Text = "" Then bandera = False
            return bandera;
        }

        private void eliminarRef(string tipoRef)
        {
            string ssql = "delete from syscod where TipoReferencia='" + tipoRef + "' and Abreviación='#'";
            SqlConnection conectar = new SqlConnection(datosEmpresa.strConxSyscod);
            conectar.Open();
            SqlCommand cmd = new SqlCommand(ssql, conectar);
            cmd.ExecuteNonQuery();
            conectar.Close();
        }

        private void Guardar()
        {
            if (verificar() == false)
            {
               MessageBox.Show ("Ingrese la información completa"); return;
            }
            syscodData = new ClassSyscod(datosEmpresa.strConxSyscod);
            syscodData.Abreviación = "#";
            syscodData.TipoReferencia = txtTipoRef.Text.Trim();
            syscodData.Descripcion = "Descripción";
            syscodData.Caracteristica1 = txtCaract1.Text.Trim();
            syscodData.Caracteristica2 = txtCaract2.Text.Trim();
            syscodData.Caracteristica3 = txtCaract3.Text.Trim();
            syscodData.Caracteristica4 = txtCaract4.Text.Trim();
            syscodData.Caracteristica5 = txtCaract5.Text.Trim();
            syscodData.Caracteristica1 = txtCaract1.Text.Trim();
            syscodData.decimales1 = Convert.ToInt32("0" + txtdec1.Text);
            syscodData.decimales2 = Convert.ToInt32("0" + txtdec2.Text);
            syscodData.decimales3 = Convert.ToInt32("0" + txtdec3.Text);
            syscodData.decimales4 = Convert.ToInt32("0" + txtdec4.Text);
            syscodData.decimales5 = Convert.ToInt32("0" + txtdec5.Text);
            syscodData.longitud1 = Convert.ToInt32("0" + txtLong1.Text);
            syscodData.longitud2 = Convert.ToInt32("0" + txtLong2.Text);
            syscodData.longitud3 = Convert.ToInt32("0" + txtLong3.Text);
            syscodData.longitud4 = Convert.ToInt32("0" + txtLong4.Text);
            syscodData.longitud5 = Convert.ToInt32("0" + txtLong5.Text);
            syscodData.Tipo1 = cboTipo1.Text;
            syscodData.Tipo2 = cboTipo2.Text;
            syscodData.Tipo3 = cboTipo3.Text;
            syscodData.Tipo4 = cboTipo4.Text;
            syscodData.Tipo5 = cboTipo5.Text;
            syscodData.Actualizar();
            TipReferencia = txtTipoRef.Text;
        }

        private void btnAbrir_Click(System.Object sender, System.EventArgs e)
        {
            string cod = "";
            frmBuscarTipoRef busk = new frmBuscarTipoRef();
            if (cod != "") cargar(cod);
            GroupBox1.Enabled = true; txtTipoRef.Text = cod;
            bloquear_desbloquear(false);
            cambios = 0;
        }

        private void cargar(string cod)
        {
            syscodData = new ClassSyscod(datosEmpresa.strConxSyscod);
            syscodData = ClassSyscod.Buscar(" Abreviación = '#' and TipoReferencia = '" + txtTipoRef.Text.Trim() + "'");
            txtTipoRef.Text = syscodData.TipoReferencia ;
            txtCaract1.Text = syscodData.Caracteristica1 ;
            txtCaract2.Text = syscodData.Caracteristica2 ;
            txtCaract3.Text = syscodData.Caracteristica3 ;
            txtCaract4.Text = syscodData.Caracteristica4 ;
            txtCaract5.Text = syscodData.Caracteristica5 ;
            txtCaract1.Text = syscodData.Caracteristica1 ;
            txtdec1.Text = syscodData.decimales1.ToString() ;
            txtdec2.Text = syscodData.decimales2.ToString();
            txtdec3.Text = syscodData.decimales3.ToString();
            txtdec4.Text = syscodData.decimales4.ToString();
            txtdec5.Text = syscodData.decimales5.ToString();
            txtLong1.Text = syscodData.longitud1.ToString();
            txtLong2.Text = syscodData.longitud2.ToString();
            txtLong3.Text = syscodData.longitud3.ToString();
            txtLong4.Text = syscodData.longitud4.ToString();
            txtLong5.Text = syscodData.longitud5.ToString();
            cboTipo1.Text = syscodData.Tipo1  ;
            cboTipo2.Text = syscodData.Tipo2  ;
            cboTipo3.Text = syscodData.Tipo3  ;
            cboTipo4.Text = syscodData.Tipo4  ;
            cboTipo5.Text = syscodData.Tipo5  ; 
            TipReferencia = txtTipoRef.Text;
        }

        private void txtTipoRef_TextChanged(System.Object sender, System.EventArgs e)
        {
            cambios += 1;
        }

        public string TipoReferencia(string cod)
        {
            @ref = cod;
            this.ShowDialog();
            return TipReferencia;
        }

        private void btnEliminar_Click(System.Object sender, System.EventArgs e)
        {
            if (txtTipoRef.Text == "")
            {
                MessageBox.Show ("Debe escojer primero el tipo de referencia","", MessageBoxButtons.OK ); return;
            }
            if (MessageBox.Show("Esta seguro que desea eliminar la referencia ","", MessageBoxButtons.YesNo , MessageBoxIcon.Question ) == DialogResult.Yes)
            {
                eliminarRef(txtTipoRef.Text);
                limpiar();
                bloquear_desbloquear(true);
            }
        }

        private void eliminar(string cod)
        {
            using (SqlConnection conectar = new SqlConnection(datosEmpresa.strConxSyscod))
            {
                string ssql = "delete from syscod where TipoReferencia='" + cod + "'";
                SqlCommand cmd = new SqlCommand(ssql, conectar);
                conectar.Open();
                cmd.ExecuteReader();
                cmd.Dispose();
            }
        }

        private void btnSalir_Click(System.Object sender, System.EventArgs e)
        {
            this.Dispose();
        }

        private void btnEliminarCaract_Click(System.Object sender, System.EventArgs e)
        {
            if (MessageBox.Show("Al eliminar las carcateristicas puede provocar que el sistema no funcione correctamente. Desea Continuar", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            string ssql = "update Syscod set Caracteristica1='', Caracteristica2='',Caracteristica3='',Caracteristica4='',Caracteristica5='' where TipoReferencia='" + txtTipoRef.Text + "' and Abreviación ='#'";
            using (SqlConnection conectar = new SqlConnection(datosEmpresa.strConxSyscod))
            {
                SqlCommand cmd = new SqlCommand(ssql, conectar);
                if (conectar.State == ConnectionState.Closed)
                    conectar.Open();
                cmd.ExecuteNonQuery();
                limpiar();
                txtTipoRef.Text = @ref;
                cmd.Dispose();
            }
        }
    }





}
