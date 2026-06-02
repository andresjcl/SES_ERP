using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassDoc;
using directMnt;
namespace IvaRett 
{
    public partial class MntReembolso : Form
    {

         public string sucursal = "";
         public string tipoDoc = "";
         public string estab = "";
         public string ptovta = "";
         public string num = "";
         public double idClaveDoc = 0;
         public string strConxAdcom = "";
         public string strConxIvaret = "";
         public string fechaFactura = DateTime.Now.ToShortTimeString ();
         
            string ssql = "";

            //double porIva = 0;
            double porIce = 0;
            double porIvaStandard = 0;
        public MntReembolso()
        {
            InitializeComponent();
        }

        private void MntReembolso_Load(object sender,
                                       EventArgs e)
        {
            ActualizarCambios(strConxAdcom);
            labTitulo.Text = "Documentos de reembolso adjunto a : " + sucursal + "-" + tipoDoc + "-" + estab + ptovta + "-" + num;
            //if (dt != null && dt.Rows.Count > 0) { malla.DataSource = dt; diseñarMalla(); }
            if (malla.Rows.Count < 1 || ssql == "") 
            { cargarDatos(sucursal, tipoDoc, num, idClaveDoc, strConxAdcom,fechaFactura); }
        }

        private void cargarDatos(string suc, string doc, string numero, double idclavedoc, string strConxAdcom, string fechaDoc)
        {
            this.malla.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.malla_CellValueChanged);
            AdcDocReemb reem = new AdcDocReemb(strConxAdcom);
            ssql = " select * from adcdocreemb where doc_sucursal = '" + suc + "' and opc_documento = '" + doc + "' ";
            if (numero == "") numero = "0";
            ssql += " and idclavedoc = " + idclavedoc.ToString();
            DataTable dt = new DataTable();
            dt = AdcDocReemb.Tabla(ssql);
            if (dt == null) {MessageBox.Show("Existe una excepción con la tabla de reembolsos"); return;}
            if (dt.Rows.Count == 0) { dt.Rows.Add(dt.NewRow()); }
            malla.DataSource = dt;
            diseñarMalla();
             valorIva vIva = new valorIva();
            DateTime fecha= DateTime.Now ;
            try
            {
                fecha= Convert.ToDateTime(fechaDoc);
            }catch{}
            porIvaStandard = vIva.ValorIvaAfecha(fecha, strConxIvaret);
            this.malla.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.malla_CellValueChanged);
            Totalizar();
            // dt.Dispose();
        }

        private void diseñarMalla()
        {
            string formato = "#,0.00";

            malla.Columns["Doc_sucursal"].Visible = false;
            malla.Columns["idClaveDoc"].Visible = false;
            malla.Columns["Opc_documento"].Visible = false;
            malla.Columns["tpIdProvReemb"].Visible = false;
            malla.Columns["totbasesImpReemb"].Visible = false;
            malla.Columns["estado"].Visible = false;

            malla.Columns["tipoComprobanteReemb"].HeaderText = "Doc";
            malla.Columns["idProvReemb"].HeaderText = "RucProv";
            malla.Columns["establecimientoReemb"].HeaderText = "Est";
            malla.Columns["puntoEmisionReemb"].HeaderText = "Pto";
            malla.Columns["secuencialReemb"].HeaderText = "Número";
            malla.Columns["fechaEmisionReemb"].HeaderText = "Fecha";
            malla.Columns["autorizacionReemb"].HeaderText = "AutorizaciónSri";
            
            malla.Columns["baseImponibleReemb"].HeaderText = "BasIva_0";
            malla.Columns["baseImpGravReemb"].HeaderText = "BasConIva";
            malla.Columns["baseNoGraIvaReemb"].HeaderText = "BasNoIva";
            malla.Columns["baseImpExeReemb"].HeaderText = "BasExIva";
            malla.Columns["porcIva"].DisplayIndex = 15;
            malla.Columns["montoIvaRemb"].HeaderText = "ValIva";
            malla.Columns["montoIceRemb"].HeaderText = "ValIce";

            malla.Columns["tipoComprobanteReemb"].Width =30;
            malla.Columns["idProvReemb"].Width = 95;
            malla.Columns["establecimientoReemb"].Width = 30;
            malla.Columns["puntoEmisionReemb"].Width = 30;
            malla.Columns["secuencialReemb"].Width = 75;
            malla.Columns["fechaEmisionReemb"].Width = 75;
            malla.Columns["autorizacionReemb"].Width = 230;
            malla.Columns["porcIva"].Width = 75;

            malla.Columns["baseImponibleReemb"].Width =75;
            malla.Columns["baseImpGravReemb"].Width = 75;
            malla.Columns["baseNoGraIvaReemb"].Width = 75;
            malla.Columns["baseImpExeReemb"].Width = 75;
            malla.Columns["montoIvaRemb"].Width = 75;
            malla.Columns["montoIceRemb"].Width = 75;

            malla.Columns["montoIvaRemb"].ReadOnly = true;
            malla.Columns["montoIceRemb"].ReadOnly = true;
            malla.Columns["tipoComprobanteReemb"].ReadOnly = true;
            malla.Columns["idProvReemb"].ReadOnly = true;

            malla.Columns["baseImponibleReemb"].DefaultCellStyle.Format = formato;
            malla.Columns["baseImpGravReemb"].DefaultCellStyle.Format = formato;
            malla.Columns["baseNoGraIvaReemb"].DefaultCellStyle.Format = formato;
            malla.Columns["baseImpExeReemb"].DefaultCellStyle.Format = formato;
            malla.Columns["montoIvaRemb"].DefaultCellStyle.Format = formato;
            malla.Columns["montoIceRemb"].DefaultCellStyle.Format = formato;
            malla.Columns["porcIva"].DefaultCellStyle.Format = formato;        

        }
        #region manejo malla

        private void malla_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            foreach (DataGridViewRow rr in malla.Rows)
            {
                rr.HeaderCell.Value = (rr.Index + 1).ToString();
            }
        }

        protected override Boolean ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (malla.Focused == false && malla.IsCurrentCellInEditMode == false) return false;
            if (malla.IsCurrentCellInEditMode && keyData == Keys.Return) { malla.EndEdit(); return true; }
            if (!(keyData == Keys.Return || (keyData > Keys.F1 && keyData < Keys.F13))) return false;

            DataGridViewCell cell = malla.CurrentCell;
            //if (cell.RowIndex > malla.Rows.Count - 3) { malla.Rows.Add(malla.NewRow()); }

            funcionesEspeciales(ref keyData, ref cell);

            if (keyData != Keys.Return) return true;
            moverCeldaMalla(cell);
            return true;
        }
        private void moverCeldaMalla(DataGridViewCell cell)
        {
            Int32 columnIndex = cell.ColumnIndex;
            Int32 rowIndex = cell.RowIndex;
            Int32 col = columnIndex;
            Int32 row = rowIndex;

            Boolean esVisible;
            do
            {
                if (col == malla.Columns.Count - 1)
                {
                    if (row == malla.Rows.Count - 1)
                    {
                        col = 0;
                        row = 0;
                    }
                    else
                    {
                        col = 0;
                        row++;
                    }
                }
                else
                {
                    col++;
                }
                cell = malla.Rows[row].Cells[col];
                esVisible = (cell.Visible && !cell.ReadOnly);
            } while (esVisible == false);
            malla.CurrentCell = cell;
        }
        private void malla_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell cell = malla.CurrentCell;
            string nombreCelda = malla.Columns[cell.ColumnIndex].Name;
            string datoNvo = "";
            switch (nombreCelda)
            {
                case "Color":
                case "Talla":
                    malla.CurrentRow.Cells["nombre" + nombreCelda].Value = datoNvo;
                    moverCeldaMalla(cell);
                    break;
            }
        }

        private Boolean funcionesEspeciales(ref Keys keyData, ref DataGridViewCell cell)
        {
            Boolean resp = true;
            malla.EndEdit();
            //string dato = cell.Value.ToString();
            string nombreCelda = malla.Columns[cell.ColumnIndex].Name;
            if (keyData == Keys.F2)
            {
                if (nombreCelda == "tipoComprobanteReemb")
                {
                    buscarDocumentoSri();
                }
                if (nombreCelda == "idProvReemb")
                {
                   BuscaClien busProv = new BuscaClien();
                    string clioProv ="P";
                    string nombre = "";
                    string conAlias="N";
                    string conNuevo="N";
                    string codigoProv = busProv.IniBuscaCliOPro(ref clioProv, ref nombre, ref conAlias, ref conNuevo,false,"","");
                    if (codigoProv.Length > 0) registrarRucProveedor(codigoProv);
                    busProv.Dispose();
                }
                if (nombreCelda == "fecha")
                {
                    malla.CurrentCell.Value = DateTime.Now.ToShortDateString();
                }
            }

            return resp;
        }
        private void registrarRucProveedor(string codigo)
        {
            DirectorioAlex dalex = new DirectorioAlex();
            bool  clioProv = false;
            string soloCodigo = "";
            dalex.CargarAlex(ref codigo, ref clioProv , ref soloCodigo);
            malla.CurrentRow.Cells["idProvReemb"].Value = dalex.CiRuc;
            malla.CurrentRow.Cells["tpIdProvReemb"].Value = dalex.TipoId;
        }

        private void malla_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Totalizar();
        }

        #endregion manejo malla

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma cerrar reembolsos, los cambios efectuados se perderán", "Ingreso de reembolsos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No) return;
            malla.Rows.Clear();
            this.Close();
        }
        

        private void btnGraba_Click(object sender, EventArgs e)
        {
          if ( grabarReembolsos() == true ) this.Close();
        }
        public Boolean grabarReembolsos()
        {
            Boolean grabado = true;
            malla.EndEdit();            
            if (revisarMalla())
            {
                try
                {
                    ssql = " select * from adcdocreemb where doc_sucursal = '" + sucursal + "' and opc_documento = '" + tipoDoc + "' ";
                    ssql += " and idclavedoc = " + idClaveDoc.ToString();
                    SqlDataAdapter da = new SqlDataAdapter(ssql, strConxAdcom);
                    DataTable  rs = new DataTable();
                    da.Fill(rs);
                    moverDatosTabla(ref rs);
                    SqlCommandBuilder cb = new SqlCommandBuilder(da);
                    da.Update(rs);
                    cb.Dispose();
                    da.Dispose();
                    rs.Dispose();

                }
                catch (Exception ee) { MessageBox.Show(ee.Message); return false; }
            }
           
            return grabado;
        }

        private Boolean revisarMalla()
        {
            if (idClaveDoc == 0  || malla.Rows.Count == 0) return false;
            if (malla.Rows[0].Cells["idProvReemb"].Value == null) return false;

            //foreach (DataGridViewRow row in malla.Rows)
            //{
            //    row.Cells["Doc_sucursal"].Value = sucursal;
            //    row.Cells["idClaveDoc"].Value  = idClaveDoc;
            //    row.Cells["Opc_documento"].Value  = tipoDoc;
            //    row.Cells["estado"].Value = 0;
            //}
            return true;
        }
         private void moverDatosTabla(ref DataTable dt)
         {
             foreach (DataRow row in dt.Rows)
             {
                 row.Delete();
             }
            foreach (DataGridViewRow mRow in malla.Rows)
            {
                if (mRow.Cells["tipoComprobanteReemb"].Value  != null )
                {
                    if (mRow.Cells["tipoComprobanteReemb"].Value.ToString() != "")
                    {
                    DataRow row = dt.NewRow();
                    row["Doc_sucursal"] = sucursal;
                    row["Opc_documento"] = tipoDoc;
                    row["idClaveDoc"] = idClaveDoc;
                    row["tipoComprobanteReemb"] = mRow.Cells["tipoComprobanteReemb"].Value;
                    row["tpIdProvReemb"] = mRow.Cells["tpIdProvReemb"].Value;
                    row["idProvReemb"] = mRow.Cells["idProvReemb"].Value;
                    row["establecimientoReemb"] = mRow.Cells["establecimientoReemb"].Value;
                    row["puntoEmisionReemb"] = mRow.Cells["puntoEmisionReemb"].Value;
                    row["secuencialReemb"] = mRow.Cells["secuencialReemb"].Value;
                    row["fechaEmisionReemb"] = mRow.Cells["fechaEmisionReemb"].Value;
                    row["autorizacionReemb"] = mRow.Cells["autorizacionReemb"].Value;
                    row["baseImponibleReemb"] = mRow.Cells["baseImponibleReemb"].Value;
                    row["baseImpGravReemb"] = mRow.Cells["baseImpGravReemb"].Value;
                    row["baseNoGraIvaReemb"] = mRow.Cells["baseNoGraIvaReemb"].Value;
                    row["baseImpExeReemb"] = mRow.Cells["baseImpExeReemb"].Value;
                    row["montoIvaRemb"] = mRow.Cells["montoIvaRemb"].Value;
                    row["totbasesImpReemb"] = mRow.Cells["totbasesImpReemb"].Value;
                    row["montoIceRemb"] = mRow.Cells["montoIceRemb"].Value;
                    row["estado"] = 0;
                    row["porcIva"] = mRow.Cells["porcIva"].Value;
                    dt.Rows.Add(row);
                    }
                }
            }
        }
        private void Totalizar()
        {
            this.malla.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.malla_CellValueChanged);
            string formato = "#,0.00";
            double totGen = 0;
            double totGraba = 0;
            double totNoGrab = 0;
            double totExcto = 0;
            double totCero = 0;
            double totIva = 0;
            double totIce = 0;
            foreach (DataGridViewRow row in malla.Rows)
            {
                if (row.Cells["tipoComprobanteReemb"].Value != null && row.Cells["tipoComprobanteReemb"].Value.ToString().Length > 0)
                {
                    double montoBaseNoGraba = 0;
                    double montoBaseCero = 0;
                    double montoBaseGrav = 0;
                    double montoBaseExce = 0;
                    double totAux = 0;

                    double porIva = 0;
                    double valIva = 0;
                    double valIce = 0;

                    try
                    {
                        montoBaseCero = Convert.ToDouble(row.Cells["baseImponibleReemb"].Value);
                    }
                    catch { }
                    try
                    {
                        montoBaseNoGraba = Convert.ToDouble(row.Cells["baseNoGraIvaReemb"].Value);
                    }
                    catch { }
                    try
                    {
                        montoBaseGrav = Convert.ToDouble(row.Cells["baseImpGravReemb"].Value);
                    }
                    catch { }
                    try
                    {
                        montoBaseExce = Convert.ToDouble(row.Cells["baseImpExeReemb"].Value);
                    }
                    catch { }
                    try
                    {
                        porIva = Convert.ToDouble(row.Cells["porcIva"].Value);
                    }
                    catch 
                    { 
                        row.Cells["porcIva"].Value = porIvaStandard.ToString();
                        porIva = porIvaStandard;
                    }
                    valIva = Math.Round(montoBaseGrav * porIva, 2, MidpointRounding.AwayFromZero);
                    valIce = Math.Round(montoBaseGrav * porIce, 2, MidpointRounding.AwayFromZero);
                    totAux += montoBaseCero + montoBaseExce + montoBaseGrav + montoBaseNoGraba;
                    totCero += montoBaseCero;
                    totGraba += montoBaseGrav;
                    totNoGrab += montoBaseNoGraba;
                    totExcto += montoBaseExce;
                    totIce += valIce;
                    totIva += valIva;
                    totGen += montoBaseCero + montoBaseExce + montoBaseGrav + montoBaseNoGraba + valIce + valIva;

                    row.Cells["totbasesImpReemb"].Value = totAux;
                    row.Cells["montoIvaRemb"].Value = valIva;
                    row.Cells["montoIceRemb"].Value = valIce;

                    labTotalGeneral.Text = totGen.ToString(formato);
                    labTotalIce.Text = totIce.ToString(formato);
                    labTotIva.Text = totIva.ToString(formato);
                    labTotalIvaExcento.Text = totExcto.ToString(formato);
                    labTotIvaCero.Text = totCero.ToString(formato);
                    labTotIvaGrabado.Text = totGraba.ToString(formato);
                    labTotIvaNoGrabado.Text = totNoGrab.ToString(formato);
                }
            }
            this.malla.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.malla_CellValueChanged);
        }
        private void buscarDocumentoSri()
        {
            Buscar.frmBuscar busca = new Buscar.frmBuscar();
            nombreTablas Cons = new nombreTablas();
            string ssql = Cons.armarConsulta(nombreTablas. ComprobantesAutorizados, DateTime.Now.ToShortDateString(), 1, 0, 0);
            string codigo = busca.Buscar(strConxIvaret, ssql, "Código", "Descripción", "", "Buscar documento para reembolsos", "");
            malla.CurrentCell.Value = codigo;
            busca.Dispose();
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            malla.EndEdit();
            this.Close();
        }

         private void ActualizarCambios(string strConx)
        {
             using (SqlConnection conn = new SqlConnection(strConx))
             {
                conn.Open();
                string ssql = "IF NOT EXISTS (SELECT col.name FROM sysobjects obj, syscolumns col WHERE obj.id = col.id and obj.name='AdcDocReemb' and col.name='porcIva')";
                ssql += " BEGIN  ";
                ssql += " alter table AdcDocReemb add porcIva numeric(5,2) ";
                ssql += " End";
                using (SqlCommand comm = new SqlCommand(ssql, conn))
                {
                    comm.ExecuteNonQuery();
                }
            }
        }
    }
}
