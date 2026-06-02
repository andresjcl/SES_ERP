using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient ;
using System.Text;
using System.Windows.Forms;
using DattCom;
using ClassDoc;

namespace DctosEmi
{
    public partial class emiFacPed : Form
    {
        SqlConnection conexion = new SqlConnection();
        string strConxAdcom = string.Empty;
        string opciones = string.Empty;
        string camp = string.Empty;
        string numero = string.Empty;

        //AdcDax.DaxSofSys adcdax = new AdcDax.DaxSofSys();
        //AdcDax.Empresa emp;

        public string adcuser = datosEmpresa.usr ;

        //DaxUsr.DaxsofUsr adcuser = new DaxUsr.DaxsofUsr();
        //DaxUsr.CtrlUsuario usr;

        //daaxLib.DaxLibBases libbas = new daaxLib.DaxLibBases();
        public string LisTipoDocu = string.Empty;
        public string opc_d = string.Empty;
        public string tabla = string.Empty;
        public string[] resp = new string[4];

        public double idClaveDoc = 0;
        public string Solodoc = string.Empty;
        public string LiquidacionTip = string.Empty;
        public string LiquidacionNum = string.Empty;
        public string DocInicial = string.Empty;
        public string Codigo = string.Empty;
        public string DocOrigen = string.Empty;
        public DateTime InicFec;

        public string DocRet = string.Empty;
        public double NumRet = 0;
        public string TipoDoc = string.Empty;
        public string BodegaRet = string.Empty;
        public Boolean sinArt = false;

        public emiFacPed()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
        //    emp = datosEmpresa.Emp_codigo; // adcdax.EmpresaAct;
        //    usr = datosEmpresa.
        //usr = adcuser.UsuarioAct;
        //libbas.TipoBase = "10";
        //if (emp.Lote != true) { Label10.Visible = false; txtNumDoc.Visible = false; }
        //string fec;
        //Int32 mes = DateTime.Now.Month ;
        //Int32 año = 0;
        //if (mes == 1) { año = DateTime.Now.Year - 1;} else {año = DateTime.Now.Year;}
        //if (mes == 1) {fec = "01/12/" + año.ToString();} else {fec = "01/" + (mes - 1).ToString() + "/" + año;}
        dateDesde.Value =DateTime.Now;
        dateHasta.Value =  DateTime.Now;
        // string datHasta = DateTime.Now.Add(ts).ToShortDateString() ;
        conectarBDD();
        DaxCombobx.CargCmbBox llcbo = new DaxCombobx.CargCmbBox();
        //DaxCbos.DaxCombobx llcbo = new DaxCbos.DaxCombobx();
        llcbo.DaxCombosSuc(Convert.ToString(datosEmpresa.Emp_codigo),false ,datosEmpresa.strConIniSis, ref cboSucursal);
        cboSucursal.SelectedValue = datosEmpresa.suc;
        llcbo.DaxCombosDoc("PEC", "", false, strConxAdcom, ref cboTipoDoc);
        //cboTipoDoc.SelectedValue = "PEC";
        CargarMalla();
        }

    private void conectarBDD()
    {
        try{
                strConxAdcom = datosEmpresa.strConxAdcom; ;
                conexion.ConnectionString = strConxAdcom;
        }
        catch
        {
            MessageBox.Show ("No existe conección a la base de datos del AdcomDX");
        }
    }
    
    private void CargarMalla()
    {
        string Bus_tipDoc= string.Empty;
        string Bus_suc= string.Empty;
        string Bus_bod= string.Empty;
        string Bus_client= string.Empty;
        string Bus_art= string.Empty;
        string Bus_det= string.Empty;
        string Bus_valor= string.Empty;
        string Bus_tablaDoc = "ADCDOCPRO";

        if (cboTipoDoc.SelectedValue == null ) { return ;}
        string campo = camp;
        Bus_tipDoc = cboTipoDoc.SelectedValue.ToString();
        Bus_suc = " and doc_sucursal = '" + cboSucursal.SelectedValue + "' ";        
        if (txtNumDoc.Text != "") 
        {
            numero = " and Doc_NroLoteDoc ='" + txtNumDoc.Text + "'";
        }
            TimeSpan ts = new TimeSpan(1,0,0,0);
            string ssql = "select doc_sucursal as SUC, opc_documento as TIP";
            ssql += ",doc_fecha as FECHA,doc_numero as NUM,Doc_NombreImp as NOMBRE, doc_valor as VALOR";
            ssql += ",Doc_detalle as DETALLE,doc_codper, idClaveDoc  from " + Bus_tablaDoc + "";
            ssql += " where  ";
            ssql += " isnull(Consolidar,0) = 0 and opc_documento ='" + Bus_tipDoc + "' " + Bus_suc + numero;
            ssql += " and doc_fecha >= '" + dateDesde.Text + "' and doc_fecha < '" + dateHasta.Value.Add(ts).ToShortDateString() + "'";                

           if (conexion.State == ConnectionState.Closed) { conexion.Open(); }
            DataTable dats = new DataTable();
            SqlDataAdapter datAd = new SqlDataAdapter(ssql, conexion);        
            datAd.Fill(dats);
            malla.DataSource = dats;
            malla.ClearSelection();
            malla.Columns["doc_codper"].Visible = false;
            malla.Columns["idclavedoc"].Visible = false;
            malla.Columns["fecha"].DefaultCellStyle.Format = "dd/MMM/yyyy";
            malla.Columns["Valor"].DefaultCellStyle.Format = "###,###,###,##0.00";
            conexion.Close();
        }

    private void limpiarGrid()
    {
            for (int i = malla.RowCount;i>0;i--)
            {
                if (i <= malla.Rows.Count) { malla.Rows.RemoveAt(i);}
            }
    }

    private void btnBuscar_Click(object sender, EventArgs e)
    {
        CargarMalla();
    }

    private void btnSalir_Click(object sender, EventArgs e)
    {
        this.Close();
    }


    //private void malla_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    //{
    //    cargarFactura(e.RowIndex);
    //}

    //private void malla_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
    //{
    //    cargarFactura(e.RowIndex);
    //}

    private void malla_DoubleClick(object sender, EventArgs e)
    {
        cargarFactura(malla.SelectedRows[0].Index );
    }
    private void cargarFactura(Int32 fila)
    {
            try
            { if (malla.RowCount > 0) 
                {                       
                        idDocumento idDoc = new  idDocumento();
                        idDoc.idClave = idClaveDoc = Convert.ToDouble(malla.Rows[fila].Cells["idClaveDoc"].Value.ToString());
                        idDoc.numero = Convert.ToDouble(malla.Rows[fila].Cells["NUM"].Value.ToString());
                        idDoc.Sucursal = malla.Rows[fila].Cells["SUC"].Value.ToString();
                        idDoc.Tipo = malla.Rows[fila].Cells["TIP"].Value.ToString();
                        DctosEmi.FormFactCliente prog = new DctosEmi.FormFactCliente("fac", "fac", false, true, false,false, idDoc);
                        prog.ShowDialog();
                 }
            }
            catch (Exception ee)
            { MessageBox.Show("excepción: " + ee.Message); }
            CargarMalla();        
    }

    private void btnAceptar_Click(object sender, EventArgs e)
    {
        cargarFactura(malla.SelectedRows[0].Index);
    }

    private void dateDesde_ValueChanged(object sender, EventArgs e)
    {
        CargarMalla();
    }

    private void dateHasta_ValueChanged(object sender, EventArgs e)
    {
        CargarMalla();
    }

        private void malla_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
    //private void malla_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles malla.DoubleClick
    //    Dim fila As Long
    //    BodegaRet = ""
    //    DocRet = ""
    //    NumRet = 0
    //    idClaveDoc = 0
    //    Try
    //        if malla.RowCount() > 0 {
    //            fila = malla.SelectedCells(0).RowIndex.Tostring()
    //            BodegaRet = (malla.Rows(fila).Cells(0).Value.Tostring())
    //            DocRet = malla.Rows(fila).Cells(1).Value.Tostring()
    //            NumRet = malla.Rows(fila).Cells(3).Value.Tostring()
    //            idClaveDoc = Convert.ToDouble(malla.Rows(fila).Cells(8).Value.Tostring())
    //        }
    //    Catch
    //    End Try
    //    Me.Dispose()
    //End void

    //private void txtNumDoc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumDoc.KeyPress
    //    if InStr(1, "0123456789" & Chr(8) & Chr(13), e.KeyChar) = 0 { e.KeyChar = ""
    //End void
}
    
