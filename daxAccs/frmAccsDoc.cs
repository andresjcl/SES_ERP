using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace daxAccs
{
    public partial class frmAccsDoc : Form
    {
        Boolean cambiado = false;
        string strIniSis = "";
        string strConxadcom = "";
        string docAnt = ":";
        string usuario = "";
        Int32 empresa = 0;
        propiedadesDaxAuto prop= new propiedadesDaxAuto();

        public frmAccsDoc(Int32 codEmp, string coduser,string abrvDoc,string nomDoc,string strSys, string strAdc, string tipoDoc = "")
        {
            InitializeComponent();
            label2.Text = coduser;
            strConxadcom = strAdc;
            strIniSis = strSys;
            empresa = codEmp;
            usuario = coduser;
            if (abrvDoc == "") { abrvDoc = "FAC"; }
            if (tipoDoc == "") { tipoDoc = "FAC"; }            
            docAnt = abrvDoc;
            prop = new propiedadesDaxAuto();
            prop.iniciar(empresa, usuario, strIniSis);
            llenarComboDocumentos(abrvDoc,tipoDoc);
            //if (nomDoc == "") nomDoc = "FAC";
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            formarMalla();
        }
        private void llenarComboDocumentos(string abrvDoc,string tipoDoc)
        {
            try
            {
                 DaxCombobx.CargCmbBox  dxc = new DaxCombobx.CargCmbBox();
                dxc.DaxCombosDoc("", "", false, strConxadcom, ref cmbDocumentos);
                cmbDocumentos.SelectedValue = abrvDoc;
            }
            catch { }
        }
        private void formarMalla()
        {
            malla.Columns.Add("Abierto", "Abierto");
            malla.Columns.Add("Cantidad", "Cantidad");
            malla.Columns.Add("Mínimo", "Mínimo");
            malla.Columns.Add("Máximo", "Máximo");
            malla.Columns.Add("ValorFijo", "ValorFijo");
            malla.Rows.Add(12);

            for (int i = prop.InicioElementosMalla; i < prop.nroElementos; i++)
            {
                malla.Rows[i - prop.InicioElementosMalla].HeaderCell.Value = prop.ELEMENTOS[i];
            }

            foreach  (DataGridViewRow rr in malla.Rows )
            {
                for (int i = 0; i < rr.Cells.Count; i++)
               {
                   rr.Cells[i].ReadOnly = true;
                   rr.Cells[i].Style.BackColor = Color.LightGray;
               }
            }
            
            
            malla.Rows[0].Cells["Máximo"].ReadOnly = false;
            malla.Rows[0].Cells["Máximo"].Style.BackColor = Color.White ;

            malla.Rows[3].Cells["ValorFijo"].ReadOnly = false;
            malla.Rows[3].Cells["ValorFijo"].Style.BackColor = Color.White ;

            malla.Rows[4].Cells["ValorFijo"].ReadOnly = false;
            malla.Rows[4].Cells["ValorFijo"].Style.BackColor = Color.White;

            malla.Rows[6].Cells["ValorFijo"].ReadOnly = false;
            malla.Rows[6].Cells["ValorFijo"].Style.BackColor = Color.White;
            malla.Rows[6].Cells["Mínimo"].ReadOnly = false;
            malla.Rows[6].Cells["Mínimo"].Style.BackColor = Color.White;
            malla.Rows[6].Cells["Máximo"].ReadOnly = false;
            malla.Rows[6].Cells["Máximo"].Style.BackColor = Color.White;

            malla.Rows[7].Cells["ValorFijo"].ReadOnly = false;
            malla.Rows[7].Cells["ValorFijo"].Style.BackColor = Color.White;
            malla.Rows[7].Cells["Mínimo"].ReadOnly = false;
            malla.Rows[7].Cells["Mínimo"].Style.BackColor = Color.White;
            malla.Rows[7].Cells["Máximo"].ReadOnly = false;
            malla.Rows[7].Cells["Máximo"].Style.BackColor = Color.White;

            malla.Rows[8].Cells["ValorFijo"].ReadOnly = false;
            malla.Rows[8].Cells["ValorFijo"].Style.BackColor = Color.White;
            malla.Rows[8].Cells["Mínimo"].ReadOnly = false;
            malla.Rows[8].Cells["Mínimo"].Style.BackColor = Color.White;
            malla.Rows[8].Cells["Máximo"].ReadOnly = false;
            malla.Rows[8].Cells["Máximo"].Style.BackColor = Color.White;

            malla.Rows[10].Cells["ValorFijo"].ReadOnly = false;
            malla.Rows[10].Cells["ValorFijo"].Style.BackColor = Color.White;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {            
         if (cambiado == true)
         {
             if (MessageBox.Show("Desea guardar los cambios antes de salir ? ", "Guardar Autorizaciones", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
             {
                 
                     GuardarMalla();
             }
         }
            this.Close();
        }

        private void GuardarMalla()
        {
            cambiado = false;
        }


        private void malla_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            string dd = malla.Columns[malla.CurrentCell.ColumnIndex].Name.ToString().ToUpper() ;
            if ( !(dd == "ABIERTO" | dd == "VALORFIJO"))
            {
                TextBox txt = e.Control as TextBox;
                if (txt != null)
                {
                    txt.KeyPress -= new KeyPressEventHandler(malla_KeyPress);
                    txt.KeyPress += new KeyPressEventHandler(malla_KeyPress);
                }
            }
        }

        private void malla_KeyPress(object sender, KeyPressEventArgs e)
        {            
            string dd = malla.Columns[malla.CurrentCell.ColumnIndex].Name.ToString().ToUpper();
            if (!(dd == "ABIERTO" | dd == "VALORFIJO"))
            {
                if (e.KeyChar.ToString() == ".")
                {
                    string txt = (malla.CurrentCell.EditedFormattedValue  + "").ToString ();
                    if (txt.IndexOf(".") != -1) e.Handled = true;
                    else e.Handled = false;
                }
                else
                {
                    if (e.KeyChar == (char)Keys.Back || char.IsNumber(e.KeyChar) || e.KeyChar.ToString() == ".")
                        e.Handled = false;
                    else
                        e.Handled = true;
                }
            }
        }
        private void malla_KeyDown(object sender, KeyEventArgs e)
        {
            if (malla.Columns[malla.CurrentCell.ColumnIndex].Name == "Abierto" & e.KeyData == Keys.F2 )
            {
                if (malla.CurrentCell.Value == null) malla.CurrentCell.Value = "";
                if (malla.CurrentCell.Value.ToString() == "SI") malla.CurrentCell.Value = "NO";
                else malla.CurrentCell.Value = "SI";
            }
        }

        private void cmbDocumentos_SelectedValueChanged(object sender, EventArgs e)
        {

            limpiarFormulario();
            if (daxAccs.propiedadesDaxAuto.TipoDocumento(strConxadcom,cmbDocumentos.SelectedValue.ToString().ToUpper())=="FAC")
            {
                grpOpciones.Visible = true;
            }
            else
            {
                grpOpciones.Visible = false;
            }
            if (docAnt == ":") return;
            if (cmbDocumentos.SelectedValue == null) return;
            ClassDxSys.sysdocaccs data = new ClassDxSys.sysdocaccs(strIniSis);
            if (data == null) return;
            for (int i = 0; i < prop.InicioElementosMalla; i++)
            {
                data = ClassDxSys.sysdocaccs.Buscar(" empresa = " + empresa + " AND idusuario = '" + usuario + "' AND OPC_DOCUMENTO ='" + cmbDocumentos.SelectedValue.ToString() + "' and  opcion = '" + prop.ELEMENTOS[i] + "' ");
                if (data != null)
                {
                    if (i == 0) chkCrear.Checked = data.Abierto;
                    if (i == 1) chkModificar.Checked = data.Abierto;
                    if (i == 2) chkAnular.Checked = data.Abierto;
                    if (i == 3) chkEliminar.Checked = data.Abierto;
                    if (i == 4) chkConsultar.Checked = data.Abierto;
                    if (i == 5) chkIngresos.Checked = data.Abierto;
                    if (i == 6) chkGastos.Checked = data.Abierto;
                    if (i == 7) chkCierreCaja.Checked = data.Abierto;
                    if (i == 8) chkEntregaExpress.Checked = data.Abierto;
                }
            }

            for (int i = prop.InicioElementosMalla; i < prop.nroElementos; i++)
            {
                data = ClassDxSys.sysdocaccs.Buscar(" empresa = " + empresa + " AND idusuario = '" + usuario + "' AND OPC_DOCUMENTO ='" + cmbDocumentos.SelectedValue + "' and  opcion = '" + prop.ELEMENTOS[i] + "' ");
                if (data != null)
                    try
                    {
                        {
                            int ind = i - prop.InicioElementosMalla;
                            if (data.Abierto == true) { malla.Rows[ind].Cells["Abierto"].Value = "SI"; } else { malla.Rows[ind].Cells["Abierto"].Value = "NO"; }
                            malla.Rows[ind].Cells["Cantidad"].Value = data.Cantidad;
                            malla.Rows[ind].Cells["Mínimo"].Value = data.Minimo;
                            malla.Rows[ind].Cells["Máximo"].Value = data.Maximo;
                            malla.Rows[ind].Cells["ValorFijo"].Value = data.ValorFijo;
                        }
                    }
                    catch { }
            }            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {           
            ClassDxSys.sysdocaccs data = new ClassDxSys.sysdocaccs(strIniSis);
            data.empresa = empresa;
            data.idUsuario = usuario;
            data.opc_documento = cmbDocumentos.SelectedValue.ToString();
            data.Cantidad = 0;
            data.Minimo = 0;
            data.Maximo = 0;
            data.ValorFijo = "";

            data.empresa = empresa;
            data.idUsuario = usuario;
            data.opc_documento = cmbDocumentos.SelectedValue.ToString();
            for (int i = 0; i < prop.InicioElementosMalla; i++)
            {
                data.opcion = prop.ELEMENTOS[i];
                if (i == 0)  data.Abierto =  chkCrear.Checked;
                if (i == 1) data.Abierto = chkModificar.Checked;
                if (i == 2) data.Abierto = chkAnular.Checked;
                if (i == 3) data.Abierto = chkEliminar.Checked;
                if (i == 4) data.Abierto = chkConsultar.Checked;
                if (i == 5) data.Abierto = chkIngresos.Checked;
                if (i == 6) data.Abierto = chkGastos.Checked;
                if (i == 7) data.Abierto = chkCierreCaja.Checked;
                if (i == 8) data.Abierto = chkEntregaExpress.Checked;
                data.Actualizar(); //" SELECT * FROM sysdocaccs WHERE empresa = " + empresa + " AND idusuario = '" + usuario + "' AND OPC_DOCUMENTO ='" + cmbDocumentos.SelectedValue + "' and  opcion = '" + prop.ELEMENTOS[i] + "' ");
            }


            for (int i = prop.InicioElementosMalla; i < prop.nroElementos; i++)
            {
               // data = new ClassDxSys.sysdocaccs(strIniSis);
                data.empresa = empresa;
                data.idUsuario = usuario;
                data.opc_documento = cmbDocumentos.SelectedValue.ToString();
                data.opcion = prop.ELEMENTOS[i];
                DataGridViewRow rr = malla.Rows[i - prop.InicioElementosMalla];

                try { data.Abierto = (rr.Cells["Abierto"].Value.ToString() == "SI"); }
                catch { data.Abierto = false ; }
                try { data.Cantidad = Convert.ToInt32("0" + rr.Cells["Cantidad"].Value); }
                catch { data.Cantidad = 0; }

                try { data.Minimo = Convert.ToDecimal ( rr.Cells["Mínimo"].Value);}
                catch { data.Minimo  = 0; }
                
                try { data.Maximo = Convert.ToDecimal ( rr.Cells["Máximo"].Value);}
                catch { data.Maximo = 0; }
                
                data.ValorFijo = ("" + rr.Cells["ValorFijo"].Value).ToString();
                
                data.Actualizar(); //" SELECT * FROM sysdocaccs WHERE empresa = " + empresa + " AND idusuario = '" + usuario + "' AND OPC_DOCUMENTO ='" + cmbDocumentos.SelectedValue + "' and  opcion = '" + prop.ELEMENTOS[i] + "' ");
            }
            MessageBox.Show("Actualización terminada");
        }

        private void limpiarFormulario()
        {
            chkAnular.Checked = false;
            chkCrear.Checked = false;
            chkEliminar.Checked = false;
            chkModificar.Checked = false;
            chkConsultar.Checked = false;
            chkIngresos.Checked = false;
            chkGastos.Checked = false;
            chkCierreCaja.Checked = false;
            chkEntregaExpress.Checked = false;
            for (int i = 0; i < malla.RowCount; i++)
            {
                for (int j = 0; j < malla.ColumnCount; j++)
                {
                    malla.Rows[i].Cells[j].Value = "";
                }
            }
        }

        private void btnCopiarUsuario_Click(object sender, EventArgs e)
        {
            Buscar.frmBuscar busca = new Buscar.frmBuscar() ;
            string codigo = busca.Buscar(strIniSis, "select distinct(idusuario) from sysdocaccs where idusuario > '' order by idusuario ", "idUsuario", "IdUsuario", "", "Escojer usuario");
            if (MessageBox.Show("Confirma copiar las autorizaciones del usuario " + codigo + " al usuario actual ? \n Las autorizaciones existentes de " + usuario + " se eliminaran","Copiar Autorizaciones", MessageBoxButtons.YesNo ) == System.Windows.Forms.DialogResult.Yes)
            {
                string ssql = "sysAdcAuto P,'" + usuario + "','" + codigo + "'";
                ejecutarComando(ssql);
            }
        }
        private void ejecutarComando(string comandoSQL)
        {
            try
            {
                SqlConnection conn = new SqlConnection(strIniSis);
                conn.Open();
                SqlCommand comm = new SqlCommand(comandoSQL, conn);
                comm.ExecuteNonQuery();
                conn.Dispose();
                comm.Dispose();
            }
            catch( Exception ee)
                {
                    MessageBox.Show("No se pudo procesar el comando " + comandoSQL + "\n" + ee.Message);
                }
        }

        private void btnEliminaUsuario_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma eliminar todas las autorizaciones registradas para el usuario " + usuario , "Eliminar Autorizaciones", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                string ssql = "delete FROM sysdocaccs WHERE empresa = " + empresa + " AND idusuario = '" + usuario + "' ";
                ejecutarComando(ssql);
            }
        }

        private void btnEliminarDocumento_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma eliminar las autorizaciones del registro actual ? " , "Eliminar Autorizaciones", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                string ssql = "delete FROM sysdocaccs WHERE empresa = " + empresa + " AND idusuario = '" + usuario + "' AND OPC_DOCUMENTO ='" + cmbDocumentos.SelectedValue + "' ";
                ejecutarComando(ssql);
            }
        }
    }
}
