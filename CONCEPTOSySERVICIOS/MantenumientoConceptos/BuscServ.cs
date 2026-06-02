using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using DattCom;
namespace DaxConceptos
{
    public partial class BuscServ : Form
    {
        String CodigoRet = "";
        Boolean ManejandoServicios = true;        
        Boolean Escuentacontable = false;
        string filtroCategoria = "";
        string filtroTipo = "";
        bool saltar = true;
        public BuscServ(string busca,string ServOConcepto,string Tipo, string SoloCategoria, string ExceptoCategoria,bool conOpcionNuevo = false, Boolean llamadaDesdeMantenimiento = false, Boolean ctacont = false)
        {         
            InitializeComponent();
            OpcionesTipo(Tipo);
            filtroTipo = Tipo;
            DaxMedic.utility.CargaComboGruposServicios(cmbClase, datosEmpresa.strConxAdcom, "CL", true);
            DaxMedic.utility.CargaComboGruposServicios(cmbGrupos, datosEmpresa.strConxAdcom, "G", true);
            cargarPreferencias();
            OpcionesServicioConcepto(ServOConcepto,llamadaDesdeMantenimiento);
            btnNuevo.Visible = (conOpcionNuevo && !llamadaDesdeMantenimiento);
            filtroCategoria = armarFiltroCategoria(ExceptoCategoria, SoloCategoria);
            Escuentacontable = ctacont;
            saltar = false;
        }
        private void OpcionesTipo(string Tipo)
        {

            if (Tipo == "CC") Tipo = "C";
            Text = "BUSCAR CONCEPTOS ";
            if (ManejandoServicios) Text = "BUSCAR SERVICIOS ";
            switch (Tipo)
            {
                case "C":
                    chkCompras.Checked = true;
                    Text += " DE COMPRAS";
                    break;
                case "I":
                    chkIngBancos.Checked = true;
                    Text += " PARA INGRESOS A BANCOS";
                    break;
                case "E":
                    chkEgrBancos.Checked = true;
                    Text += " PARA EGRESOS DE BANCOS";
                    break;
                case "V":
                    chkVentas.Checked = true;
                    Text += " A CLIENTES";
                    break;
                default:
                    chkTodos.Checked = true;
                    Text = "BUSCAR SERVICIOS Y/O CONCEPTOS ";
                    break;
            }
        }
        private void OpcionesServicioConcepto(string opcion, bool desdeMantenimiento)
        {
            ManejandoServicios = (opcion == "S");
            panel1.Visible = desdeMantenimiento;
            chkCompras.Visible = ManejandoServicios;
            chkVentas.Visible = ManejandoServicios;
            chkEgrBancos.Visible = !ManejandoServicios;
            chkIngBancos.Visible = !ManejandoServicios;
        }
        private string armarFiltroCategoria(string Excepto, string Incluye)
        {
            if (Excepto == "" && Incluye == "" ) return "";
            string ssql = " and isnull(Sev_Categoria,'') = '' ";
            if (Incluye.Length > 0)
            {
                ssql = "  Sev_Categoria = '" + Incluye.Substring(0, 1) + "' ";
                if (Incluye.Length > 1)
                {
                    ssql += " or Sev_Categoria = '" + Incluye.Substring(1, 1) + "' ";
                    if (Incluye.Length > 2)
                    {
                        ssql += " or Sev_Categoria = '" + Incluye.Substring(2, 1) + "' ";
                    }
                }
                ssql = " and  (" + ssql + ") ";
            }
            if (Excepto.Length > 0)
            {
                ssql = " and (isnull(Sev_Categoria,'') <> '" + Excepto + "') ";
            }
            return ssql;
        }
        public string IniServicio()
        {
            this.ShowDialog();
            return CodigoRet;
        }

        private void LlenarServicio()
        {
            if (saltar) return;
            string Aux = "";
            string QueTipo = "";
            string busca = "";
            string CodSql = "";

            if (chkSinTipo.Checked == true)
            {
                QueTipo = " and ISNULL(sev_ventas,0) = 0 and ISNULL(sev_compras,0) = 0  and ISNULL(sev_ingbanco,0) = 0  and ISNULL(sev_egrbanco,0) = 0 ";
            }
            else if (!chkTodos.Checked)
            {
                    if (chkVentas.Checked)
                    {
                        QueTipo = " and ( ISNULL(sev_ventas,0) = 1 ) ";
                    }
                    else if(chkCompras.Checked)
                    {
                        QueTipo = " and ( ISNULL(sev_compras, 0) = 1) ";
                    }                
                    else if (chkIngBancos.Checked)
                    {
                        QueTipo = " and ( ISNULL(sev_ingbanco,0) = 1 )";
                    }
                    else if (chkEgrBancos.Checked)
                    {
                        QueTipo = " and ( ISNULL(sev_egrbanco, 0) = 1 )";
                    }
            }
            if (Escuentacontable == true)
            {
                QueTipo += " and ISNULL(sev_escontable,0) = 1 ";
            }

            busca = txtNombre.Text ;
            Aux = "";

            CodSql = "SELECT Sev_codigo as Abreviación, case sev_sniva when 0 then 'S' Else 'C' END AS SEV_SNIVA,sev_NOMBRE as Descripción FROM  ADCSERV WHERE sev_codigo > '' ";
            CodSql += Aux + QueTipo + filtroCategoria + " and sev_nombre like '%" + busca + "%' ";
            if (cmbClase.SelectedValue != null && cmbClase.SelectedValue.ToString() != "0" && cmbClase.SelectedValue.ToString().Length > 0) CodSql +=  " and sev_Clase = '"+cmbClase.SelectedValue.ToString() +"' ";
            if (cmbGrupos.SelectedValue != null && cmbGrupos.SelectedValue.ToString() != "0" && cmbGrupos.SelectedValue.ToString().Length > 0) CodSql += " and sev_Grupo = '" + cmbGrupos.SelectedValue.ToString() + "' ";
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(CodSql, datosEmpresa.strConxAdcom );
            da.Fill(dt);
            mallaDatos.DataSource = dt;
        }

        private void Retorna()
        {
            try
            {
                CodigoRet = mallaDatos.Rows[mallaDatos.CurrentCell.RowIndex].Cells["Abreviación"].Value.ToString();
            }catch{ CodigoRet = ""; }
            this.Close();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            Retorna();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
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
        }
        private void guardarPreferencias()
        {
            if (cmbClase.SelectedValue != null) AuditSis.registrar.registraPreferencia(datosEmpresa.strConxSyscod, datosEmpresa.codEmpresa.ToString(), datosEmpresa.usr + Environment.MachineName, "MDD", datosEmpresa.suc, "DAXMED", "ClaseServicio", cmbClase.SelectedValue.ToString());
            if (cmbGrupos.SelectedValue != null) AuditSis.registrar.registraPreferencia(datosEmpresa.strConxSyscod, datosEmpresa.codEmpresa.ToString(), datosEmpresa.usr + Environment.MachineName, "MDD", datosEmpresa.suc, "DAXMED", "GrupoServicio", cmbGrupos.SelectedValue.ToString());
        }
        private void cargarPreferencias()
        {
            string op = AuditSis.registrar.obtenerPreferencia(datosEmpresa.strConxSyscod, datosEmpresa.codEmpresa.ToString(), datosEmpresa.usr + Environment.MachineName, "MDD", datosEmpresa.suc, "DAXMED", "ClaseServicio");
            if (op.Length > 0) cmbClase.SelectedValue = op; else cmbClase.SelectedIndex = 0;

            op = AuditSis.registrar.obtenerPreferencia(datosEmpresa.strConxSyscod, datosEmpresa.codEmpresa.ToString(), datosEmpresa.usr + Environment.MachineName, "MDD", datosEmpresa.suc, "DAXMED", "GrupoServicio");
            if (op.Length > 0) cmbGrupos.SelectedValue = op; else cmbGrupos.SelectedIndex = 0;
        }

        private void BuscServ_FormClosing(object sender, FormClosingEventArgs e)
        {
            guardarPreferencias();
        }

        private void cmbClase_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarServicio();
        }

        private void mallaDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
