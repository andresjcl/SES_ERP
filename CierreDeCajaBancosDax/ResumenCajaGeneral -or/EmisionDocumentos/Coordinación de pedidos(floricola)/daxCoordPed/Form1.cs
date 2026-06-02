using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient ;
using System.Text;
using System.Windows.Forms;

namespace daxFaxPed
{
    public partial class Form1 : Form
    {
        SqlConnection conexion = new SqlConnection();
        string strConxAdcom = string.Empty;
        string opciones = string.Empty;
        string camp = string.Empty;
        string numero = string.Empty;        

        AdcDax.DaxSofSys adcdax = new AdcDax.DaxSofSys();
        AdcDax.Empresa emp;

        DaxUsr.DaxsofUsr adcuser = new DaxUsr.DaxsofUsr();
        DaxUsr.CtrlUsuario usr;

        DaxLib.DaxLibBases libbas = new DaxLib.DaxLibBases();
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

        public Form1()
        {
            InitializeComponent();
            dateDesde.Value = DateTime.Now;
        }

        private void Form1_Load(object sender, EventArgs e)
        {        
            emp = adcdax.EmpresaAct;
            usr = adcuser.UsuarioAct;
            libbas.TipoBase = "10";
    //        if (emp.Lote != true) { Label10.Visible = false; txtNumDoc.Visible = false; }
            conectarBDD();

            DaxCbos.DaxCombobx llcbo = new DaxCbos.DaxCombobx();
            llcbo.DaxCombosSuc(Convert.ToString( emp.codigo),false , libbas.StrDaxsys(), ref cboSucursal);
            cboSucursal.SelectedValue = emp.SucActual;
    //        llcbo.DaxCombosDoc("PEC", "", false, strConxAdcom, ref cboTipoDoc);
            CargarMallaPedidos();
        }

    private void conectarBDD()
    {
        try{
            strConxAdcom = libbas.StrAdcom();
            conexion.ConnectionString = strConxAdcom;
        }
        catch
        {
            MessageBox.Show ("No existe conección a la base de datos del AdcomDX");
        }
    }
    
    private void CargarMallaPedidos()
    {
        string Bus_tipDoc= string.Empty;
        string Bus_suc= string.Empty;
        string Bus_bod= string.Empty;
        string Bus_client= string.Empty;
        string Bus_art= string.Empty;
        string Bus_det= string.Empty;
        string Bus_valor= string.Empty;
        string Bus_tablaDoc = "ADCDOCPRO";

        string campo = camp;
        Bus_suc = " and doc_sucursal = '" + cboSucursal.SelectedValue + "' ";        
        {
        }
            TimeSpan ts = new TimeSpan(1,0,0,0);
            string ssql = "select doc_sucursal as SUC, opc_documento as TIP";
            ssql += ",doc_fecha as FECHA,doc_numero as NUM,Doc_NombreImp as NOMBRE";
            ssql += ",doc_codper, idClaveDoc  from " + Bus_tablaDoc + "";
            ssql += " where  doc_tipodoc = 'PEC' ";
            //ssql += " and isnull(Consolidar,0) = 0 ";
//            ssql += " and doc_fecha >= '" + dateDesde.Text + "' and doc_fecha < '" + dateHasta.Value.Add(ts).ToShortDateString() + "'";                
        if (conexion.State == ConnectionState.Closed) { conexion.Open(); }
            DataTable dats = new DataTable();
            SqlDataAdapter datAd = new SqlDataAdapter(ssql, conexion);        
            datAd.Fill(dats);
            mallaPedidos.DataSource = dats;
            mallaPedidos.ClearSelection();
            mallaPedidos.Columns["doc_codper"].Visible = false;
            mallaPedidos.Columns["idclavedoc"].Visible = false;
            mallaPedidos.Columns["TIP"].Visible = false;
            mallaPedidos.Columns["fecha"].DefaultCellStyle.Format = "dd/MMM/yyyy";
            //mallaPedidos.Columns["Valor"].DefaultCellStyle.Format = "###,###,###,##0.00";
            conexion.Close();
        } 
    private void CargarMallaDetalle(DataGridViewRow row)
    {

        string campo = camp;
        TimeSpan ts = new TimeSpan(1, 0, 0, 0);
        string ssql = "SELECT Tra_numlinea as Lin,nroCaja as IdCaja,cantCajas as CantCaj, TipCaja as TipCaja, Tra_Codigo as Codigo, Tra_nombre as Variedad, isnull(RamXcaja,0) as RmCj, tra_peso as Gramo,isnull(Largo,0) as Largo, Tra_cantidad as Ramos, Tra_precuni as PVtaUni, Tra_precTot as PVtaTot,isnull(TallXramo,0) as TllRmo,Tallos FROM AdcTraPro ";
        ssql += " where  doc_sucursal = '" + row.Cells["SUC"].Value.ToString() + "' and opc_documento = '" + row.Cells["TIP"].Value.ToString() + "' and idclavedoc=" + row.Cells["Idclavedoc"].Value.ToString();

        if (conexion.State == ConnectionState.Closed) { conexion.Open(); }
        DataTable dats = new DataTable();
        SqlDataAdapter datAd = new SqlDataAdapter(ssql, conexion);
        datAd.Fill(dats);
        mallaDetalle.DataSource = dats;
        mallaDetalle.ClearSelection();
        mallaDetalle.Columns["CantCaj"].DefaultCellStyle.Format = "#0";
        mallaDetalle.Columns["RmCj"].DefaultCellStyle.Format = "#0";
        mallaDetalle.Columns["Gramo"].DefaultCellStyle.Format = "#0";
        mallaDetalle.Columns["Largo"].DefaultCellStyle.Format = "#0";
        mallaDetalle.Columns["Ramos"].DefaultCellStyle.Format = "#0";
        mallaDetalle.Columns["TllRmo"].DefaultCellStyle.Format = "#0";
        mallaDetalle.Columns["Tallos"].DefaultCellStyle.Format = "#0";
        mallaDetalle.Columns["PVtaUni"].DefaultCellStyle.Format = "#0.00";
        mallaDetalle.Columns["PVtaTot"].DefaultCellStyle.Format = "#0.00";

        mallaDetalle.Columns["Codigo"].Width = 70;
        mallaDetalle.Columns["Lin"].Width = 25;
        //mallaDetalle.Columns["TipCaja"].Width = 30;
        mallaDetalle.Columns["Variedad"].Width = 280;
        mallaDetalle.Columns["TipCaja"].Width = 40;
        mallaDetalle.Columns["IdCaja"].Width = 40;
        mallaDetalle.Columns["CantCaj"].Width = 35;        
        mallaDetalle.Columns["RmCj"].Width = 40;
        mallaDetalle.Columns["Gramo"].Width = 40;
        mallaDetalle.Columns["Largo"].Width = 35;
        mallaDetalle.Columns["Ramos"].Width = 40;
        mallaDetalle.Columns["TllRmo"].Width = 40;
        mallaDetalle.Columns["Tallos"].Width = 40;
        mallaDetalle.Columns["PVtaUni"].Width = 70;
        mallaDetalle.Columns["PVtaTot"].Width = 70;

        mallaDetalle.Columns["CantCaj"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        mallaDetalle.Columns["RmCj"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        mallaDetalle.Columns["Gramo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        mallaDetalle.Columns["Largo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        mallaDetalle.Columns["Ramos"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        mallaDetalle.Columns["TllRmo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        mallaDetalle.Columns["Tallos"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        mallaDetalle.Columns["PVtaUni"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        mallaDetalle.Columns["PVtaTot"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


        //mallaPedidos.Columns["doc_codper"].Visible = false;
        //mallaPedidos.Columns["idclavedoc"].Visible = false;
        //mallaPedidos.Columns["TIP"].Visible = false;
        //mallaPedidos.Columns["fecha"].DefaultCellStyle.Format = "dd/MMM/yyyy";
        //mallaPedidos.Columns["Valor"].DefaultCellStyle.Format = "###,###,###,##0.00";


        conexion.Close();
        disMallFlor.diseñoMallaFlor.colorCaja(mallaDetalle);
    }
   
   
    private void limpiarGrid()
    {
            for (int i = mallaPedidos.RowCount;i>0;i--)
            {
                if (i <= mallaPedidos.Rows.Count) { mallaPedidos.Rows.RemoveAt(i);}
            }
    }

    private void btnBuscar_Click(object sender, EventArgs e)
    {
        CargarMallaPedidos();
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
        cargarFactura(mallaPedidos.SelectedRows[0].Index );
    }
    private void cargarFactura(Int32 fila)
    {
            BodegaRet = "";
            DocRet = "";
            NumRet = 0;
            idClaveDoc = 0;
            try
            { if (mallaPedidos.RowCount > 0) 
                {
                        //fila = malla.SelectedCells(0).RowIndex.Tostring();
                        BodegaRet = mallaPedidos.Rows[fila].Cells[0].Value.ToString();
                        DocRet = mallaPedidos.Rows[fila].Cells[1].Value.ToString();
                        NumRet = Convert.ToDouble (mallaPedidos.Rows[fila].Cells[3].Value.ToString());
                        idClaveDoc = Convert.ToDouble(mallaPedidos.Rows[fila].Cells[8].Value.ToString());
                        emidocicLib.emidoclib prog = new emidocicLib.emidoclib();
                        prog.FacIdclave = idClaveDoc;
                        prog.FacNumero = NumRet.ToString();
                        prog.FacSuc = BodegaRet;
                        prog.FacTipo = DocRet;
                        prog.copiando = true;
                        prog.adcRegDocumento();
                 }
            }
            catch (Exception ee)
            { MessageBox.Show("excepción: " + ee.Message); }
            CargarMallaPedidos();        
    }

    private void btnAceptar_Click(object sender, EventArgs e)
    {
        cargarFactura(mallaPedidos.SelectedRows[0].Index);
    }

    private void dateDesde_ValueChanged(object sender, EventArgs e)
    {
        CargarMallaPedidos();
    }

    private void dateHasta_ValueChanged(object sender, EventArgs e)
    {
        CargarMallaPedidos();
    }

    private void ToolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
    {

    }


    private void mallaPedidos_CellEnter(object sender, DataGridViewCellEventArgs e)
    {
        CargarMallaDetalle(mallaPedidos.Rows[e.RowIndex]);
    }

    private void btnAnula_Click(object sender, EventArgs e)
    {        
        // eliminar este void solo es para pruebas
        classPedPend.mntPerio pedidos = new classPedPend.mntPerio();
        classPedPend.periodoPedFijo.tipo=1;
        classPedPend.periodoPedFijo.diaSemana = "Martes";
        classPedPend.periodoPedFijo.fechaInicia = new DateTime(2016, 11, 01);
        classPedPend.periodoPedFijo.fechaFin = new DateTime(2017, 12, 31);
        pedidos.iniciar();  
    }

    private void dateDesde_ValueChanged_1(object sender, EventArgs e)
    {
        dateHasta.Value = dateDesde.Value;
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
    
