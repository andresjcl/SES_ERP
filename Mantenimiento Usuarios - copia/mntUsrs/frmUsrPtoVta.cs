using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace mntUsrs
{
    public partial class frmUsrPtoVta : Form
    {
        Boolean cambiado = false;
        string strConxDaxsys = "";
        string strConxAdcom = "";
        string usuario = "";
        int empresa = 0;
        string nomEmpresa = "";
        string sistema = "";
        string sucursal = "";
        //public frmUsrPtoVta(string strsys,string strConxadc, string usr, int emp, string nomEmp, string sys,string suc)
        public frmUsrPtoVta(string strsys, string strConxadc, string usr, int emp, string nomEmp, string sys)
        {
            InitializeComponent();
            strConxDaxsys = strsys;
            strConxAdcom = strConxadc;
            usuario = usr;
            empresa = emp;
            nomEmpresa = nomEmp;
            sistema = sys;
            //sucursal = suc;
            cargarRegistrosActuales();
        }
        private void cargarRegistrosActuales()
        {
            string Ssql = "select users.IdUsuario,users.Nombre,users.Suc_Codigo,users.Suc_Nombre,pv.CodptoVta ,pv.AutorizaPtoVta from";
            Ssql += "(";
            Ssql += "select suc.emp_codigo, usr.IdUsuario";
            Ssql += ", (SELECT id.NombreImpresion from Identificacion id where usr.CodUsuario = id.Codigo ) as Nombre";
            Ssql += ", suc.Suc_Codigo,suc.Suc_Nombre";
            Ssql += " FROM  daxsys.dbo.sys_usuario usr, daxsys.dbo.emp_suc suc";
            Ssql += " where suc.Emp_Codigo ="+ empresa.ToString() +" ";
            Ssql += " ) users";
            Ssql += " left join daxsys.dbo.sys_ptoVta pv";
            Ssql += " on pv.idusuario = users.idusuario and pv.IdEmpresa = users.Emp_Codigo and pv.CodSucursal = users.Suc_Codigo";

            ManejoBases progBas = new ManejoBases();
            malla.DataSource = progBas.leerTablas (strConxAdcom,Ssql);
            diseñoMallas.DiseñarMallaPtoVta(malla);
        }

        private void malla_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            cambiado = true;
        }

        private void malla_KeyDown(object sender, KeyEventArgs e)
        {

            string nombreCol = "";
            try
            {
                nombreCol = malla.Columns[malla.CurrentCell.ColumnIndex].Name;
            }
            catch { }
            if (nombreCol.Length == 0) return;
            if(e.KeyCode == Keys.F2)
            {
                /*AUMENTADO*/
                // Obtener fila actual
                int fila = malla.CurrentCell.RowIndex;

                // Obtener SUCURSAL de ESA fila (REA, PRI, etc.)
                sucursal = malla.Rows[fila].Cells["suc_codigo"].Value?.ToString();

                if (string.IsNullOrEmpty(sucursal))
                {
                    MessageBox.Show("La sucursal no está definida en la fila.",
                                    "Aviso",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }
                /*---*/


                if (nombreCol== "CodptoVta")
                {
                    string ssql = " select Pto_codigo as Id, Pto_nombre as NombrePuntoVta,Pto_IDTributario from emp_ptovta where emp_codigo = '" + empresa.ToString() + "' and suc_codigo = '" + sucursal + "'";
                    Buscar.frmBuscar busca = new Buscar.frmBuscar();
                    malla.CurrentCell.Value = busca.Buscar(strConxDaxsys, ssql, "Id", "NombrePuntoVta", "", "PUNTOS DE VENTA");
                }
                else if (nombreCol == "AutorizaPtoVta")
                {
                    if (malla.CurrentCell.Value.ToString() == "SI") malla.CurrentCell.Value = "NO"; else malla.CurrentCell.Value="SI";
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)

        {
            grabarDatos();
        }
        private void grabarDatos()
        {
            malla.EndEdit();
            string Ssql = "";
            SqlDataAdapter da=new SqlDataAdapter();
            DataTable dt=new DataTable();

            foreach (DataGridViewRow  row in malla.Rows)
            {
                if (row.Cells["codptoVta"] != null && row.Cells["codptoVta"].Value.ToString().Length > 0)
                {
                    Ssql = "select * from sys_ptoVta where ";
                    Ssql += " IdEmpresa = '" + empresa.ToString() + "'";
                    Ssql += " and codSucursal = '" + sucursal + "'";
                    Ssql += " and IdUsuario = '" + row.Cells["IdUsuario"].Value.ToString() + "'";

                    da = new SqlDataAdapter(Ssql, strConxDaxsys);
                    dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        dt.Rows[0]["codptoVta"] = row.Cells["codptoVta"].Value.ToString();
                        dt.Rows[0]["AutorizaPtoVta"] = row.Cells["AutorizaPtoVta"].Value.ToString();
                    }
                    else
                    {
                        DataRow nr = dt.NewRow();
                        nr["idUsuario"] = row.Cells["idUsuario"].Value.ToString();
                        nr["IdEmpresa"] = empresa;
                        nr["codSucursal"] = sucursal;
                        nr["codptoVta"] = row.Cells["codptoVta"].Value.ToString();
                        nr["AutorizaPtoVta"] = row.Cells["AutorizaPtoVta"].Value.ToString();
                        dt.Rows.Add(nr);
                    }
                    SqlCommandBuilder cb = new SqlCommandBuilder(da);
                    da.Update(dt);
                }
            }
            cambiado = false;
            Close();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (cambiado == true )
            if (MessageBox.Show ("Desea guardar los datos antes de salir ? ","Asignacion de puntos de venta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)== DialogResult.Yes)
            {
                grabarDatos();
            }
            Close();
        }

		private void frmUsrPtoVta_Load(object sender, EventArgs e)
		{

		}
	}
}
