using System;
using Microsoft.Reporting.WinForms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DattCom;

namespace DaxInvent
{
    public partial class repCatalogo : Form
    {
        public repCatalogo()
        {
            InitializeComponent();
        }
        //private bool botonOp = false;
        private string bodega = "";
        //private string TipoDoc = "";
        //private string TipoSop = "";
        private DateTime FechaIni = Convert.ToDateTime("0:0");
        private DateTime fecha = Convert.ToDateTime("0:0");
        private DateTime fechaFin = Convert.ToDateTime("0:0");
        private string codIni = "";
        private string codFin = "";
        //private int SaldoFecha = 0;
        private string medidas = "";
        private int articulosExiten = 0;
        private string categoria = "";
        private string clase = "";
        private string grupo = "";
        private string subg = "";
        private string costeo = "P";
        private string NomCosteo = "";
        private string titulo = "";
        private string CCat = "";
        private string CCla = "";
        private string CGru = "";
        private string CSub = "";
        //private bool inclCost = false;
        //private string Clasedoc = "E";
        //private string codDirectorio = "";
        //private int NumReporte;
        private string ConPrincipal = "S";
        private string ConTotal = "N";
        private string Ordenar = "";

        #region Datos Iniciales
        private void repInventario_Load(object sender, EventArgs e)
        {
            SplitContainer1.Panel1Collapsed = true;
            llenarCombos();
        }
        private void llenarCombos()
        {
            string ssql = "select niv_categor,'Todas las categorias' as Niv_nombre,'0' as Niv_abrevia from AdcNiv where Niv_categor =1 group by Niv_categor ";
            ssql += " union all select Niv_categor,Niv_nombre ,niv_abrevia  from AdcNiv where Niv_categor =1";
            llenarCategorias(ssql, cboCategoria, "Todas las categorias", "Niv_nombre", "Niv_abrevia", Label3, chkCategoria);
            ssql = " select niv_categor,'Todas las clases' as Niv_nombre,'0' as Niv_abrevia from AdcNiv where Niv_categor =2 group by Niv_categor ";
            ssql += " union all select Niv_categor,Niv_nombre ,niv_abrevia  from AdcNiv where Niv_categor =2";
            llenarCategorias(ssql, cboClase, "Todas las clases", "Niv_nombre", "Niv_abrevia", Label4, chkClase);
            ssql = " select niv_categor,'Todos los grupos' as Niv_nombre,'0' as Niv_abrevia from AdcNiv where Niv_categor =3 group by Niv_categor ";
            ssql += " union all select Niv_categor,Niv_nombre ,niv_abrevia  from AdcNiv where Niv_categor =3";
            llenarCategorias(ssql, cboGrupo, "Todos los grupos", "Niv_nombre", "Niv_abrevia", Label5, chkGrupo);
            ssql = " select niv_categor,'Todos los subgrupos' as Niv_nombre,'0' as Niv_abrevia from AdcNiv where Niv_categor =4 group by Niv_categor ";
            ssql += " union all select Niv_categor,Niv_nombre ,niv_abrevia  from AdcNiv where Niv_categor =4";
            llenarCategorias(ssql, cboSubg, "Todos los subgrupos", "Niv_nombre", "Niv_abrevia", Label6, chkSubg);
            llenarBodegas();
        }
        private void llenarCategorias(string ssql, ComboBox cbo, string op, string nombre, string cod, Label lcbo, CheckBox chkCbo)
        {
            var datS = new DataTable();
            datS = SqlDatos.leerTablaAdcom(ssql);
            cbo.DataSource = datS;
            cbo.DisplayMember = nombre;
            cbo.ValueMember = cod;
            if (cbo.Items.Count == 0)
            {
                cbo.Visible = false;
                lcbo.Visible = false;
                chkCbo.Visible = false;
                chkCbo.Checked = false;
            }
            else
            {
                cbo.SelectedIndex = 0;
            }
        }

        private void llenarBodegas()
        {
            string ssql = "Select 0 As Emp_Codigo ,'0' as Bod_Codigo,'Todas las Bodegas' as Bod_nombre  ";
            ssql += " union all";
            ssql += " select Emp_Codigo,Bod_codigo,Bod_nombre from Emp_Bod where Emp_Codigo =" + datosEmpresa.Emp_codigo + " order by bod_nombre";
            // ssql += " and  Suc_Codigo='PRI'"
            var datS = new DataTable();
            datS = SqlDatos.leerTablaIniSis(ssql);
            cboBodega.DataSource = datS;
            cboBodega.DisplayMember = "Bod_nombre";
            cboBodega.ValueMember = "Bod_Codigo";
            cboBodega.SelectedValue = "0";
        }
        #endregion

        #region Botones de Busqueda
        private void btnCodIni_Click(object sender, EventArgs e)
        {
            txtcodIni.Text = ModuloCatalogo.ConsultaArt();
        }

        private void btnCodFin_Click(object sender, EventArgs e)
        {
            txtCodFin.Text = ModuloCatalogo.ConsultaArt();
        }
        #endregion

        #region Opciones
        private void btnOpciones_Click(object sender, EventArgs e)
        {
            SplitContainer1.Panel1Collapsed = !btnOpciones.Checked;
        }

        private void leerOpciones()
        {
            if (cboBodega.SelectedValue != null && cboBodega.SelectedValue.ToString() == "0") bodega = cboBodega.SelectedValue.ToString(); else bodega = "";
            if (bodega == "0")
                bodega = "";
            if (Orden.Checked) Ordenar = "A"; else Ordenar = "C";
            codIni = txtcodIni.Text;
            codFin = txtCodFin.Text;
            fecha = Convert.ToDateTime(txtFecha.Text);
            medidas = txtMedidas.Text;
            if (chkArtExis.Checked == true)
                articulosExiten = 1;
            else
                articulosExiten = 0;
            if (cboCategoria.SelectedValue is object)
            {
                if (cboCategoria.Visible == false) categoria = "";
                else { if (cboCategoria.SelectedValue.ToString() == "0") categoria = ""; else categoria = cboCategoria.SelectedValue.ToString(); }
            }

            if (cboClase.SelectedValue is object)
            {
                if (cboClase.Visible == false) clase = "";
                if (cboClase.SelectedValue.ToString() == "0") clase = ""; else clase = cboClase.SelectedValue.ToString();
            }

            if (cboGrupo.SelectedValue is object)
            {
                if (cboGrupo.Visible == false)
                    grupo = "";
                else
                    if (cboGrupo.SelectedValue.ToString() == "0") grupo = ""; else grupo = cboGrupo.SelectedValue.ToString();
            }
            // subg = IIf(cboSubg.Visible = False, "", IIf(cboSubg.SelectedValue.ToString = "0", "", cboSubg.SelectedValue.ToString))
            if (chkCategoria.Checked) CCat = "S"; else CCat = "N";
            if (chkClase.Checked) CCla = "S"; else CCla = "N";
            if (chkGrupo.Checked) CGru = "S"; else CGru = "N";
            if (chkSubg.Checked) CSub = "S"; else CSub = "N";
        }

        //private void optDocEmi_CheckedChanged(object sender, EventArgs e)
        //{
        //    Clasedoc = "E"; // docuemntos Emitidos
        //}

        //private void optDocSop_CheckedChanged(object sender, EventArgs e)
        //{
        //    Clasedoc = "S"; // documentos de Soporte
        //}

        private void optCostoPro_CheckedChanged(object sender, EventArgs e)
        {
            costeo = "P";
            NomCosteo = "Promedio";
            limpiarReporte();
        }

        private void optPvp1_CheckedChanged(object sender, EventArgs e)
        {
            costeo = "1";
            NomCosteo = "Precio 1";
            limpiarReporte();
        }

        private void optPvp3_CheckedChanged(object sender, EventArgs e)
        {
            costeo = "3";
            NomCosteo = "Precio 3";
            limpiarReporte();
        }

        private void optPvp5_CheckedChanged(object sender, EventArgs e)
        {
            costeo = "5";
            NomCosteo = "Precio 5";
            limpiarReporte();
        }

        private void optUltCost_CheckedChanged(object sender, EventArgs e)
        {
            costeo = "U";
            NomCosteo = "UltimaCompra";
            limpiarReporte();
        }

        private void optPvp2_CheckedChanged(object sender, EventArgs e)
        {
            costeo = "2";
            NomCosteo = "Precio 2";
            limpiarReporte();
        }

        private void optPvp4_CheckedChanged(object sender, EventArgs e)
        {
            costeo = "4";
            NomCosteo = "Precio 4";
            limpiarReporte();
        }

        private void optSinCost_CheckedChanged(object sender, EventArgs e)
        {
            costeo = "0";
            NomCosteo = "";
            limpiarReporte();
        }
        #endregion

        #region Reportes
        private void btnCatalogo() // _Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCatalogo.Click
        {
            Text = "REPORTES DE INVENTARIO :     'CATALOGO GENERAL DE ARTICULOS'";
            // verificaActualizador(btnCatalogo)
            //NumReporte = 1;
            limpiarReporte();
            // reporte(1)
        }

        private void limpiarReporte()
        {
            ReportViewer1.Clear();
        }

        private void reporte()
        {
            // On Error Resume Next
            ReportViewer1.Reset();
            string cad = "";
            string Ubicacion = "N";
            string Piezas = "N";
            if (chkUbicacion.Checked) Ubicacion = "S";
            if (chkPiezas.Checked) Piezas = "S";
            limpiarReporte();
            leerOpciones();
            titulo = "Catálogo de artículos bodega: " + cboBodega.Text;
            if (NomCosteo.Length > 0)
                titulo = titulo + "valorado por: " + NomCosteo;
            cad = "exec DaxInvCst '" + fecha + "','" + bodega + "','" + codIni + "','" + codFin + "'," + articulosExiten + ",'" + costeo + "','" + categoria + "','" + clase + "','" + grupo + "','" + subg + "'";
            var rds = new ReportDataSource();
            var Empresa = new ReportParameter("Empresa", datosEmpresa.nomEmpresa);
            var orden = new ReportParameter("orden", "C");
            var nombre = new ReportParameter("Titulo", titulo);
            var FechaR = new ReportParameter("FechaR", fecha.ToShortDateString());
            var FechaE = new ReportParameter("FechaE", fechaFin.ToShortDateString());
            var ConCategoria = new ReportParameter("ConCategoria", CCat.ToString());
            var ConClase = new ReportParameter("ConClase", CCla.ToString());
            var ConGrupo = new ReportParameter("ConGrupo", CGru.ToString());
            var ConSubgrupo = new ReportParameter("ConSubgrupo", CSub.ToString());
            var ConAlfabetico = new ReportParameter("ConAlfabetico", Ordenar.ToString());
            var PRINCIPAL = new ReportParameter("PRINCIPAL", ConPrincipal);
            var Totaldoc = new ReportParameter("Totaldoc", ConTotal);
            var conUbicación = new ReportParameter("conUbicación",Ubicacion);
            var conPiezas = new ReportParameter("conPiezas", Piezas);
            if (string.IsNullOrEmpty(cad))
                return;
            // If op = 4 Or op = 6 Then rds.Name = "DataSet2" Else 

            try
            {
                var DT = new DataTable();
                DT = SqlDatos.leerTablaAdcom(cad);
                if (DT.Rows.Count == 0)
                {
                    MessageBox.Show("No existen valores para visualizar");
                    return;
                }

                rds.Name = "DataSet1";
                rds.Value = DT;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción en emision de reporte de inventarios: \n" + ex.Message);
            }

            ReportViewer1.Visible = true;
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(rds);
            ReportViewer1.LocalReport.ReportPath = datosEmpresa.pathAppl + @"BinNet\Rep\Catalogo.rdlc";
            // If op <> 6 Then
            ReportViewer1.LocalReport.SetParameters(Empresa);
            ReportViewer1.LocalReport.SetParameters(nombre);
            ReportViewer1.LocalReport.SetParameters(FechaR);
            ReportViewer1.LocalReport.SetParameters(FechaE);
            ReportViewer1.LocalReport.SetParameters(ConAlfabetico);
            ReportViewer1.LocalReport.SetParameters(conUbicación);
            // End If
            ReportViewer1.LocalReport.SetParameters(ConCategoria);
            ReportViewer1.LocalReport.SetParameters(ConClase);
            ReportViewer1.LocalReport.SetParameters(ConGrupo);
            ReportViewer1.LocalReport.SetParameters(ConSubgrupo);
            ReportViewer1.LocalReport.SetParameters(conPiezas);
            ReportViewer1.RefreshReport();
            if (ReportViewer1.CanFocus == true)
                ReportViewer1.Focus();
        }
        #endregion
        private void Actualizar_Click(object sender, EventArgs e)
        {
            btnCatalogo();
            reporte();
        }

        private void chkCst_CheckedChanged(object sender, EventArgs e)
        {
            limpiarReporte();
        }

        private void txtcodDir_TextChanged(object sender, EventArgs e)
        {
            limpiarReporte();
        }

        private void txtArtIni_TextChanged(object sender, EventArgs e)
        {
            limpiarReporte();
        }

        private void txtArtFin_TextChanged(object sender, EventArgs e)
        {
            limpiarReporte();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }
        private void verificaActualizador(ToolStripButton boton)
        {
            Actualizar.Enabled = boton.CheckState == CheckState.Checked;
        }

        private void repCatalogo_Load(object sender, EventArgs e)
        {

        }

        private void ToolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
