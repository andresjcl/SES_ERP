using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using DattCom;
namespace DaxConceptos
{
    public partial class BuscaServMed : Form
    {
        String CodigoRet = "";
        string tiposervicio = "";
        string[] VariosServicios;
        bool EsMultiple = false;
        //Boolean Escuentacontable = false;
        Boolean saltar = true;
        public BuscaServMed(string busca, string clase, string grupo,bool conOpcionNuevo = false, Boolean llamadaDesdeMantenimiento = false,string tiposerv="")
        {         
            InitializeComponent();
            DaxMedic.utility.CargaComboGruposServicios(cmbClase, datosEmpresa.strConxAdcom, "CL", true);
            DaxMedic.utility.CargaComboGruposServicios(cmbGrupos, datosEmpresa.strConxAdcom, "G", true);
            cargarPreferencias();
            tiposervicio = tiposerv;
            btnNuevo.Visible = (conOpcionNuevo && !llamadaDesdeMantenimiento);
            saltar = false;
        }
        public string IniServicio()
        {
            this.ShowDialog();
            return CodigoRet;
        }
        public string[] BuscarVarios()
        {
            EsMultiple = true;
            this.ShowDialog();
            return VariosServicios;
        }

        private void LlenarServicio()
        {
            if (saltar) return;
            string busca = "";
            string CodSql = "";

            busca = txtNombre.Text ;

            CodSql = "SELECT Sev_codigo as Abreviación,sev_NOMBRE as Descripción FROM  ADCSERV ";
            CodSql += " WHERE sev_codigo > '' and ( ISNULL(sev_ventas,0) = 1 ) ";
            //CodSql += " and isnull(Sev_Categoria,'') = 'D'";
            if (cmbClase.SelectedValue.ToString() != "0") CodSql += " and isnull(Sev_Clase,'') = '" + cmbClase.SelectedValue.ToString() +"' ";
            if (cmbGrupos.SelectedValue.ToString() != "0") CodSql += " and isnull(Sev_Grupo,'') = '" + cmbGrupos.SelectedValue.ToString() + "' ";
            if (busca.Length > 0 ) CodSql += " and sev_nombre like '%" + busca + "%' "; 
            if (tiposervicio.Length == 3) CodSql += " and TipServMedico = '" + tiposervicio  + "' ";
            if (tiposervicio.Length > 3) CodSql += " and SEV_CODIGO NOT IN (SELECT Sev_codigo  FROM ADCSERV WHERE TipServMedico IN (" + tiposervicio + ")) "  ;
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(CodSql, datosEmpresa.strConxAdcom );
            da.Fill(dt);
            mallaDatos.DataSource = dt;
        }

        private void Retorna()
        {

            CodigoRet = "";
            int ind = 0;
            if (EsMultiple)
            {
                if (mallaDatos.SelectedRows.Count > 0)
                {
                    VariosServicios = new string[mallaDatos.SelectedRows.Count + 1];
                    foreach (DataGridViewRow dgvr in mallaDatos.SelectedRows)
                    {
                        VariosServicios[ind] = dgvr.Cells["Abreviación"].Value.ToString();
                        ind++;
                    }
                }
            }
            else
            {
                try
                {
                    CodigoRet = mallaDatos.Rows[mallaDatos.CurrentCell.RowIndex].Cells["Abreviación"].Value.ToString();
                }
                catch { }
            }
            this.Close();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            Retorna();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            VariosServicios = new string[0];
            this.Close();
        }


        private void mallaDatos_DoubleClick(object sender, EventArgs e)
        {
            Retorna();
        }

        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
           // if (e.KeyData == Keys.Return && txtNombre.Text.Length > 0)
            {
                LlenarServicio();                
            }
        }
        private void chkTodos_CheckedChanged(object sender, EventArgs e)
        {
            LlenarServicio();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmMntServicios frm = new frmMntServicios(true);
            frm.ShowDialog();
        }

        private void BuscServ_Load(object sender, EventArgs e)
        {
            LlenarServicio();
            txtNombre.Focus();
        }

        private void BuscaServMed_FormClosing(object sender, FormClosingEventArgs e)
        {
            guardarPreferencias();
        }
        private void guardarPreferencias()
        {
            AuditSis.registrar.registraPreferencia(datosEmpresa.strConxSyscod, datosEmpresa.codEmpresa.ToString(), datosEmpresa.usr + Environment.MachineName, "MDD", datosEmpresa.suc, "DAXMED", "ClaseServicio", cmbClase.SelectedValue.ToString());
            AuditSis.registrar.registraPreferencia(datosEmpresa.strConxSyscod, datosEmpresa.codEmpresa.ToString(), datosEmpresa.usr + Environment.MachineName, "MDD", datosEmpresa.suc, "DAXMED", "GrupoServicio", cmbGrupos.SelectedValue.ToString());
        }
        private void cargarPreferencias()
        {
            string op = AuditSis.registrar.obtenerPreferencia(datosEmpresa.strConxSyscod, datosEmpresa.codEmpresa.ToString(), datosEmpresa.usr + Environment.MachineName, "MDD", datosEmpresa.suc, "DAXMED", "ClaseServicio");
            if (op.Length > 0) cmbClase.SelectedValue = op; else cmbClase.SelectedIndex  = 0;

            op = AuditSis.registrar.obtenerPreferencia(datosEmpresa.strConxSyscod, datosEmpresa.codEmpresa.ToString(), datosEmpresa.usr + Environment.MachineName, "MDD", datosEmpresa.suc, "DAXMED", "GrupoServicio");
            if (op.Length > 0) cmbGrupos.SelectedValue = op; else cmbGrupos.SelectedIndex = 0;
        }

        private void cmbClase_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarServicio();
        }
    }
}
