using Microsoft.Reporting.WinForms;
using SysEmpDatt;
using System;
using System.Data;
using System.Windows.Forms;

namespace CierreDeCaja
{
    public partial class frmResumenGeneral : Form
    {
        string det = "";
#pragma warning disable CS0414 // El campo 'frmResumenGeneral.vend' está asignado pero su valor nunca se usa
        string vend = "";
#pragma warning restore CS0414 // El campo 'frmResumenGeneral.vend' está asignado pero su valor nunca se usa
        string suc = "";
        string ptovta = "";
#pragma warning disable CS0414 // El campo 'frmResumenGeneral.codfac' está asignado pero su valor nunca se usa
        string codfac = "";
#pragma warning restore CS0414 // El campo 'frmResumenGeneral.codfac' está asignado pero su valor nunca se usa
#pragma warning disable CS0414 // El campo 'frmResumenGeneral.coddev' está asignado pero su valor nunca se usa
        string coddev = "";
#pragma warning restore CS0414 // El campo 'frmResumenGeneral.coddev' está asignado pero su valor nunca se usa
#pragma warning disable CS0414 // El campo 'frmResumenGeneral.codret' está asignado pero su valor nunca se usa
        string codret = "";
#pragma warning restore CS0414 // El campo 'frmResumenGeneral.codret' está asignado pero su valor nunca se usa
        string prefBanco = "";
        string prefDocumento = "";
        string prefConcepto = "";
        DateTime fecDesde;
        DateTime fecHasta;
        string opcionreporte = "";
        DaxCombobx.CargCmbBox cmb = new DaxCombobx.CargCmbBox();
        DataTable datosCiere = new DataTable();
        public frmResumenGeneral()
        {
            InitializeComponent();
            llenarCombos();
        }
        private void llenarCombos()
        {
            cmb.DaxCombosDoc("ING", "", false, datosEmpresa.strConxAdcom, ref cmbDocumento);
            //cmb.DaxCombosSuc(datosEmpresa.codEmpresa.ToString(), true, datosEmpresa.strConxSyscod, ref cmbSucursal, true);
            string ssql = "select sev_codigo as Codigo ,sev_nombre  as Descripción from adcserv where sev_ingbanco <> 0 order by sev_nombre";
            cmbConepto.DataSource = SqlDatos.leerTablaAdcom(ssql);
            cmbConepto.DisplayMember = "Descripción";
            cmbConepto.ValueMember = "Codigo";
            llenarComboPtoVta();
            txtfecha.Value = DateTime.Now;
            leerPreferencias();
            if (prefConcepto != "") cmbConepto.SelectedValue = prefConcepto;
            if (prefDocumento != "") cmbDocumento.SelectedValue = prefDocumento;
            if (prefBanco != "") MostrarDatosBanco(prefBanco);
        }
        private void leerPreferencias()
        {
            prefBanco = registraEvntos.registrar.obtenerPreferencia(datosEmpresa.strConxDaxsys, datosEmpresa.codEmpresa.ToString(), DatosUsuario.Identifica, "PTO", "", "RESGENCAJAS", "BANCO");
            prefDocumento = registraEvntos.registrar.obtenerPreferencia(datosEmpresa.strConxDaxsys, datosEmpresa.codEmpresa.ToString(), DatosUsuario.Identifica, "PTO", "", "RESGENCAJAS", "INGBAN");
            prefConcepto = registraEvntos.registrar.obtenerPreferencia(datosEmpresa.strConxDaxsys, datosEmpresa.codEmpresa.ToString(), DatosUsuario.Identifica, "PTO", "", "RESGENCAJAS", "CONCEPTOING");
        }
        private void GuardarPreferencias()
        {
            registraEvntos.registrar.registraPreferencia(datosEmpresa.strConxDaxsys, datosEmpresa.codEmpresa.ToString(), DatosUsuario.Identifica, "PTO", "", "RESGENCAJAS", "BANCO", txtCodBanco.Text);
            registraEvntos.registrar.registraPreferencia(datosEmpresa.strConxDaxsys, datosEmpresa.codEmpresa.ToString(), DatosUsuario.Identifica, "PTO", "", "RESGENCAJAS", "INGBAN", cmbDocumento.SelectedValue.ToString());
            registraEvntos.registrar.registraPreferencia(datosEmpresa.strConxDaxsys, datosEmpresa.codEmpresa.ToString(), DatosUsuario.Identifica, "PTO", "", "RESGENCAJAS", "CONCEPTOING", cmbConepto.SelectedValue.ToString());
        }
        private void llenarComboPtoVta()
        {
            //cmb.DaxCombosPtoVtaReg(datosEmpresa.strConxAdcom, ref cboPtoVta, true, cmbSucursal.SelectedValue.ToString());
        }
        private void btnOpciones_Click(object sender, EventArgs e)
        {
            SplitContainer1.Panel1Collapsed = !SplitContainer1.Panel1Collapsed;
        }

        private void BtnResumenGeneral_Click(object sender, EventArgs e)
        {
            CierreGeneral();
        }
        private void CierreGeneral()
        {
            leerOpciones();
            String cad = "exec Adc_CieCajGenDax '" + txtFechaDel.Text + "','" + txtFechaAl.Text + "','" + suc + "','" + ptovta + "'";
            Boolean opSoloTot = false;

            ReportDataSource rds = new ReportDataSource();
            ReportParameter Empresa = new ReportParameter("Empresa", datosEmpresa.nomEmpresa.ToString());
            ReportParameter nombre = new ReportParameter("Titulo", "RESUMEN CIERRE DE CAJA ");
            ReportParameter FechaD = new ReportParameter("FecDesde", txtFechaDel.Text);
            ReportParameter FechaH = new ReportParameter("FecHasta", txtFechaAl.Text);
            ReportParameter FechaE = new ReportParameter("FecEmision", DateTime.Now.ToShortDateString());
            ReportParameter tot = new ReportParameter("SoloTot", opSoloTot.ToString());
            ReportParameter Detalle = new ReportParameter("DetalleRep", det);
            ReportParameter Tipor = new ReportParameter("Tipor", "I");
            ReportParameter opcionesreporte = new ReportParameter("opcionesreporte", opcionreporte);

            ReportParameter ValEfectivo = new ReportParameter("ValEfectivo", "0");
            ReportParameter ValCheques = new ReportParameter("ValCheques", "0");
            ReportParameter CantCheques = new ReportParameter("CantCheques", "0");
            ReportParameter ValTarjetas = new ReportParameter("ValTarjetas", "0");
            ReportParameter CantTarjetas = new ReportParameter("CantTarjetas", "0");
            ReportParameter LoteTarjetas = new ReportParameter("LoteTarjetas", "0");
            rds.Name = "DataSet1";
            datosCiere = SqlDatos.leerTablaAdcom(cad);
            rds.Value = datosCiere;

            ReportViewer1.Visible = true;
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(rds);

            ReportViewer1.LocalReport.ReportPath = datosEmpresa.pathAppl + @"BinNet\Rep\CierrCajGeneral.rdlc";
            ReportViewer1.LocalReport.SetParameters(Empresa);
            ReportViewer1.LocalReport.SetParameters(nombre);
            ReportViewer1.LocalReport.SetParameters(FechaD);
            ReportViewer1.LocalReport.SetParameters(FechaH);
            ReportViewer1.LocalReport.SetParameters(FechaE);
            ReportViewer1.LocalReport.SetParameters(tot);
            ReportViewer1.LocalReport.SetParameters(Detalle);
            ReportViewer1.LocalReport.SetParameters(Tipor);
            ReportViewer1.LocalReport.SetParameters(opcionesreporte);
            ReportViewer1.LocalReport.SetParameters(ValEfectivo);
            ReportViewer1.LocalReport.SetParameters(ValCheques);
            ReportViewer1.LocalReport.SetParameters(CantCheques);
            ReportViewer1.LocalReport.SetParameters(ValTarjetas);
            ReportViewer1.LocalReport.SetParameters(CantTarjetas);
            ReportViewer1.LocalReport.SetParameters(LoteTarjetas);

            ReportViewer1.RefreshReport();
            double totalDeposito = 0;
            foreach (DataRow row in datosCiere.Rows)
            {
                totalDeposito += val(row["Deposito"]);// + val(row["Cheque"]) - val(row["Gastos"]) - val(row["Doc"]);
            }
            txtValor.Text = totalDeposito.ToString("0.00");
        }
        private double val(object ValOrigen)
        {
            double valor = 0;
            try { valor = Convert.ToDouble(ValOrigen.ToString()); } catch { }
            return valor;
        }
        private void leerOpciones()
        {
            fecDesde = txtFechaDel.Value;
            fecHasta = txtFechaAl.Value;

            //Dim esp As String = ""
            det = "";
            vend = "";
            suc = "";
            ptovta = "";
            codfac = "";
            coddev = "";
            codret = "";
            opcionreporte = "";
            //if (cboPtoVta.SelectedValue == null) cboPtoVta.SelectedValue = "0";
            //if (cboPtoVta.SelectedValue.ToString() == "0")
            //{
            ptovta = "";
            opcionreporte = "TODOS";
            //}
            //else 
            //{
            //    ptovta = cboPtoVta.Text;
            //    opcionreporte = ptovta;
            //}        
        }

        private void btnGenerarIngresoBanco_Click(object sender, EventArgs e)
        {
            adcDocumentos.ListaConceptosBco listaConceptos = new adcDocumentos.ListaConceptosBco();
            adcDocumentos.ConceptoBco cnb = new adcDocumentos.ConceptoBco
            {
                Descrición = "DEPOSITO POR RECAUDACION VENTAS",
                TipoConcepto = cmbConepto.SelectedValue.ToString(),
                valor = Convert.ToDouble("0" + txtValor.Text)
            };
            listaConceptos.conceptoBcos.Add(cnb);
            adcDocumentos.GenerarIngBancos gib = new adcDocumentos.GenerarIngBancos();
            WaitMensaje.WMensaje.verMensaje("Generando documento de ingreso a caja");
            gib.GenerarIngresoSimple(cmbDocumento.SelectedValue.ToString(), 0, txtfecha.Value, txtCodBanco.Text, listaConceptos);
            WaitMensaje.WMensaje.cierraMensaje();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            GuardarPreferencias();
            Close();
            Dispose();
        }

        private void cmbSucursal_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenarComboPtoVta();
        }

        private void cmbSucursal_SelectedValueChanged(object sender, EventArgs e)
        {
            llenarComboPtoVta();
        }
        private void btnBuscaBanco_Click(object sender, EventArgs e)
        {
            Buscar.frmBuscar buscar = new Buscar.frmBuscar();
            string consulta = "SELECT Bco_Codigo, Bco_Nombre, bco_numcta as NumeroCta FROM AdcCtaBco";
            string abreviaturaBanco = Convert.ToString(buscar.Buscar(SysEmpDatt.datosEmpresa.strConxAdcom, consulta, "Bco_Codigo", "Bco_Nombre", "", "BusquedaCuentasBancarias"));//
            if (abreviaturaBanco.Length > 0) MostrarDatosBanco(abreviaturaBanco);
        }
        public void MostrarDatosBanco(string abreviaturaBanco)
        {
            if (abreviaturaBanco == null) return;
            string consulta = " select *  from AdcCtaBco where Bco_Codigo = '" + abreviaturaBanco.Trim() + "' ";
            DataTable dato = SysEmpDatt.SqlDatos.leerTablaAdcom(consulta);
            if (dato.Rows.Count > 0)
            {
                txtCodBanco.Text = Convert.ToString(dato.Rows[0]["Bco_Codigo"]).Trim();
                txtCtaBanco.Text = Convert.ToString(dato.Rows[0]["Bco_NumCta"]).Trim();
                txtNombreBanco.Text = dato.Rows[0]["Bco_Nombre"].ToString().Trim();
                //tipoDeCtaBancaria = dato.Rows[0]["Bco_TipoCta"].ToString().Trim();
            }
            dato.Dispose();
        }
    }
}
