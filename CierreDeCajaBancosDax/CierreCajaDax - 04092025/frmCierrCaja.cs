using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using SysEmpDatt;

namespace CierreDeCaja
{
    public partial class frmCierrCaja
    {
        private bool botonOp = false;
        private DateTime fecHasta = DateAndTime.Now;
        private DateTime fecDesde = DateAndTime.Now;
        private DateTime fechaLim = new DateTime(1900, 1, 1, 0, 0, 0);
        private bool opSoloTot = false;
        private string codClienteIni = "";
        private string codClienteFin = "";
        private string tipo = "I";
        private string suc = "";
        private string ptovta = "";
        private string vend = "";
        private string det = "";
        private string tipoDoc = "";
        private bool ImprimeDetalle;
        private string codfac = "";
        private string coddev = "";
        private string codret = "";
        private string opcionreporte;
        private bool CierreConfirmado;
        private decimal valorEfectivo;
        private decimal valorCheques;
        private decimal valorTarjetas;
        private decimal nroCheques;
        private decimal nroTarjetas;
        private CierreDeCaja.DaxCiecaj DatosCierre = new CierreDeCaja.DaxCiecaj();
        private int proceso = 0;  // 0 sin operacion 1 actualizado  2 consultando
        private bool esgeneral = false;
        private DaxCombobx.CargCmbBox c = new DaxCombobx.CargCmbBox();

        #region Datos Iniciales
        public frmCierrCaja(CierreDeCaja.DaxCiecaj dc, bool general = false) : base()
        {
            this.InitializeComponent();
            DatosCierre = dc;
            esgeneral = general;
            _cmbSucursal.Name = "cmbSucursal";
            _cboPtoVta.Name = "cboPtoVta";
            _txtTarjetas.Name = "txtTarjetas";
            _txtEfectivo.Name = "txtEfectivo";
            _txtCheques.Name = "txtCheques";
            _txtFechaAl.Name = "txtFechaAl";
            _btnOpciones.Name = "btnOpciones";
            _btnActualizar.Name = "btnActualizar";
            _btnSalir.Name = "btnSalir";
            _BtnResumenGeneral.Name = "BtnResumenGeneral";
            _btnAbrir.Name = "btnAbrir";
            _btnCerrar.Name = "btnCerrar";
            _btnPdfOriginal.Name = "btnPdfOriginal";
            _btnMovimientos.Name = "btnMovimientos";
            _btnConfimaCierre.Name = "btnConfimaCierre";
        }

        private void frmCierrCaja_Load(object sender, EventArgs e)
        {
            CierreDeCaja.ModuloLstDoc.conectarBDD();
            DatosIniciales();
            // Me.ReportViewer1.RefreshReport()
        }

        private void DatosIniciales()
        {
            int mes = 0;
            int dia = 0;
            int año = 0;
            ImprimeDetalle = false;
            LlenarCombos();
            this.cmbSucursal.SelectedValue = DatosCierre.Sucursal;
            this.cboPtoVta.Text = DatosCierre.PuntoDeVenta;
            if (DatosCierre.FechaIni.Year == 1900)
            {
            }

            if (DatosCierre.FechaIni > fechaLim)
            {
                this.txtFechaDel.Value = DatosCierre.FechaIni;
                this.txtFechaAl.Value = DateAndTime.Now;
            }

            // btnConfimaCierre.Enabled = False
            proceso = 0;
            organizarBotones();
            this.Text = "PUNTTO - CIERRES DE CAJA DE PUNTOS DE VENTA";
            this.BtnResumenGeneral.Visible = false;
            if (esgeneral)
            {
                this.Text = "PUNTTO - CUADRE DE CAJA GENERAL";
                this.BtnResumenGeneral.Visible = true;
                this.GrupoEntregaCaja.Visible = false;
                // GrupoFiltros.Visible = False
                this.btnAbrir.Visible = false;
                this.btnActualizar.Visible = false;
                this.btnCerrar.Visible = false;
                this.btnConfimaCierre.Visible = false;
                // btnHorarios.Visible = False
                this.btnMovimientos.Visible = false;
                this.btnPdfOriginal.Visible = false;
            }
        }

        private void LlenarCombos()
        {
            var argPasCombo = this.cboPtoVta;
            c.DaxCombosPtoVtaReg(datosEmpresa.strConxAdcom, ref argPasCombo, true, datosEmpresa.suc);
            this.cboPtoVta = argPasCombo;
            llenarComboPtoVta();
        }

        private void llenarComboPtoVta()
        {
            var argPasCombo = this.cmbSucursal;
            c.DaxCombosSuc(datosEmpresa.codEmpresa.ToString(), true, datosEmpresa.strConxSyscod, ref argPasCombo, true);
            this.cmbSucursal = argPasCombo;
        }

        private void txtFechaDel_LostFocus(object sender, EventArgs e)
        {
            if (this.txtFechaDel.Text != "  /  /")
            {
                if (!Information.IsDate(this.txtFechaDel.Text))
                {
                    Interaction.MsgBox("Ingrese una fecha válida", MsgBoxStyle.Information);
                    this.txtFechaDel.Text = "";
                    this.txtFechaDel.Focus();
                }
            }
        }

        private void txtFechaAl_LostFocus(object sender, EventArgs e)
        {
            if (this.txtFechaAl.Text != "  /  /")
            {
                if (!Information.IsDate(this.txtFechaAl.Text))
                {
                    Interaction.MsgBox("Ingrese una fecha válida", MsgBoxStyle.Information);
                    this.txtFechaAl.Text = "";
                    this.txtFechaAl.Focus();
                }
                else if (Operators.CompareString(this.txtFechaDel.Text, this.txtFechaAl.Text, false) > 0)
                {
                    Interaction.MsgBox("La fecha final debe ser mayor a la inicial", MsgBoxStyle.Information);
                    this.txtFechaAl.Text = "";
                    this.txtFechaAl.Focus();
                }
            }
        }
        #endregion

        #region Reporte
        private void Reporte()
        {
            string cad = "";
            leerOpciones();
            cad = "exec Adc_CieCajDax '" + (this.txtFechaDel.Text + "','") + this.txtFechaAl.Text + "','" + suc + "','" + ptovta + "','0" + this.txtEfectivo.Text + "','0" + this.txtCheques.Text + "','0" + this.txtTarjetas.Text + "'";
            CierreDeCaja.ValoresRecibidos.valorEfectivo = this.valorNumero(this.txtEfectivo.Text);
            CierreDeCaja.ValoresRecibidos.valorCheques = this.valorNumero(this.txtCheques.Text);
            CierreDeCaja.ValoresRecibidos.valorTarjetas = this.valorNumero(this.txtTarjetas.Text);
            CierreDeCaja.ValoresRecibidos.nroCheques = this.valorNumero(this.txtCantCheques.Text);
            CierreDeCaja.ValoresRecibidos.nroTarjetas = this.valorNumero(this.txtCantTarjetas.Text);
            var rds = new ReportDataSource();
            var Empresa = new ReportParameter("Empresa", datosEmpresa.nomEmpresa.ToString());
            var nombre = new ReportParameter("Titulo", "RESUMEN CIERRE DE CAJA ");
            var FechaD = new ReportParameter("FecDesde", this.txtFechaDel.Text);
            var FechaH = new ReportParameter("FecHasta", this.txtFechaAl.Text);
            var FechaE = new ReportParameter("FecEmision", DateAndTime.Now.Date.ToShortDateString());
            var tot = new ReportParameter("SoloTot", opSoloTot.ToString());
            var Detalle = new ReportParameter("DetalleRep", det);
            var Tipor = new ReportParameter("Tipor", tipo);
            var opcionesreporte = new ReportParameter("opcionesreporte", opcionreporte);
            var ValEfectivo = new ReportParameter("ValEfectivo", CierreDeCaja.ValoresRecibidos.valorEfectivo.ToString());
            var ValCheques = new ReportParameter("ValCheques", CierreDeCaja.ValoresRecibidos.valorCheques.ToString());
            var CantCheques = new ReportParameter("CantCheques", CierreDeCaja.ValoresRecibidos.nroCheques.ToString());
            var ValTarjetas = new ReportParameter("ValTarjetas", CierreDeCaja.ValoresRecibidos.valorTarjetas.ToString());
            var CantTarjetas = new ReportParameter("CantTarjetas", CierreDeCaja.ValoresRecibidos.nroTarjetas.ToString());
            var LoteTarjetas = new ReportParameter("LoteTarjetas", this.NroLoteTarjetas.Text);
            rds.Name = "DataSet1";
            rds.Value = SqlDatos.leerTablaAdcom(cad);
            this.ReportViewer1.Visible = true;
            this.ReportViewer1.LocalReport.DataSources.Clear();
            this.ReportViewer1.LocalReport.DataSources.Add(rds);
            this.ReportViewer1.LocalReport.ReportPath = datosEmpresa.pathAppl + @"BinNet\Rep\CierrCajTirllPtoVta.rdlc";
            this.ReportViewer1.LocalReport.SetParameters(Empresa);
            this.ReportViewer1.LocalReport.SetParameters(nombre);
            this.ReportViewer1.LocalReport.SetParameters(FechaD);
            this.ReportViewer1.LocalReport.SetParameters(FechaH);
            this.ReportViewer1.LocalReport.SetParameters(FechaE);
            this.ReportViewer1.LocalReport.SetParameters(tot);
            this.ReportViewer1.LocalReport.SetParameters(Detalle);
            this.ReportViewer1.LocalReport.SetParameters(Tipor);
            this.ReportViewer1.LocalReport.SetParameters(opcionesreporte);
            this.ReportViewer1.LocalReport.SetParameters(ValEfectivo);
            this.ReportViewer1.LocalReport.SetParameters(ValCheques);
            this.ReportViewer1.LocalReport.SetParameters(CantCheques);
            this.ReportViewer1.LocalReport.SetParameters(ValTarjetas);
            this.ReportViewer1.LocalReport.SetParameters(CantTarjetas);
            this.ReportViewer1.LocalReport.SetParameters(LoteTarjetas);
            this.ReportViewer1.RefreshReport();
            this.btnConfimaCierre.Enabled = true;
            if (proceso < 2)
                proceso = 1;
        }

        private void CierreGeneral()
        {
            string cad = "";
            leerOpciones();
            cad = "exec Adc_CieCajGenDax '" + (this.txtFechaDel.Text + "','") + this.txtFechaAl.Text + "','" + suc + "','" + ptovta + "'";
            var rds = new ReportDataSource();
            var Empresa = new ReportParameter("Empresa", datosEmpresa.nomEmpresa.ToString());
            var nombre = new ReportParameter("Titulo", "RESUMEN CIERRE DE CAJA ");
            var FechaD = new ReportParameter("FecDesde", this.txtFechaDel.Text);
            var FechaH = new ReportParameter("FecHasta", this.txtFechaAl.Text);
            var FechaE = new ReportParameter("FecEmision", DateAndTime.Now.Date.ToShortDateString());
            var tot = new ReportParameter("SoloTot", opSoloTot.ToString());
            var Detalle = new ReportParameter("DetalleRep", det);
            var Tipor = new ReportParameter("Tipor", tipo);
            var opcionesreporte = new ReportParameter("opcionesreporte", opcionreporte);
            var ValEfectivo = new ReportParameter("ValEfectivo", CierreDeCaja.ValoresRecibidos.valorEfectivo.ToString());
            var ValCheques = new ReportParameter("ValCheques", CierreDeCaja.ValoresRecibidos.valorCheques.ToString());
            var CantCheques = new ReportParameter("CantCheques", CierreDeCaja.ValoresRecibidos.nroCheques.ToString());
            var ValTarjetas = new ReportParameter("ValTarjetas", CierreDeCaja.ValoresRecibidos.valorTarjetas.ToString());
            var CantTarjetas = new ReportParameter("CantTarjetas", CierreDeCaja.ValoresRecibidos.nroTarjetas.ToString());
            var LoteTarjetas = new ReportParameter("LoteTarjetas", this.NroLoteTarjetas.Text);
            rds.Name = "DataSet1";
            rds.Value = SqlDatos.leerTablaAdcom(cad);
            this.ReportViewer1.Visible = true;
            this.ReportViewer1.LocalReport.DataSources.Clear();
            this.ReportViewer1.LocalReport.DataSources.Add(rds);
            this.ReportViewer1.LocalReport.ReportPath = datosEmpresa.pathAppl + @"BinNet\Rep\CierrCajGeneral.rdlc";
            this.ReportViewer1.LocalReport.SetParameters(Empresa);
            this.ReportViewer1.LocalReport.SetParameters(nombre);
            this.ReportViewer1.LocalReport.SetParameters(FechaD);
            this.ReportViewer1.LocalReport.SetParameters(FechaH);
            this.ReportViewer1.LocalReport.SetParameters(FechaE);
            this.ReportViewer1.LocalReport.SetParameters(tot);
            this.ReportViewer1.LocalReport.SetParameters(Detalle);
            this.ReportViewer1.LocalReport.SetParameters(Tipor);
            this.ReportViewer1.LocalReport.SetParameters(opcionesreporte);
            this.ReportViewer1.LocalReport.SetParameters(ValEfectivo);
            this.ReportViewer1.LocalReport.SetParameters(ValCheques);
            this.ReportViewer1.LocalReport.SetParameters(CantCheques);
            this.ReportViewer1.LocalReport.SetParameters(ValTarjetas);
            this.ReportViewer1.LocalReport.SetParameters(CantTarjetas);
            this.ReportViewer1.LocalReport.SetParameters(LoteTarjetas);
            this.ReportViewer1.RefreshReport();
            this.btnConfimaCierre.Enabled = true;
            if (proceso < 2)
                proceso = 1;
        }

        private decimal valorNumero(string numero)
        {
            if (Conversion.Val(numero) == 0d)
                return 0m;
            // numero.Replace(".", ".")
            return Convert.ToDecimal(numero);
        }

        private void leerOpciones()
        {
            string esp = "";
            det = "";
            vend = "";
            suc = "";
            ptovta = "";
            codfac = "";
            coddev = "";
            codret = "";
            fecDesde = this.txtFechaDel.Value;
            fecHasta = this.txtFechaAl.Value;
            opcionreporte = "";
            if (this.cboPtoVta.SelectedValue is null)
                this.cboPtoVta.SelectedValue = "0";
            if (this.cboPtoVta.SelectedValue.ToString() == "0")
            {
                ptovta = "";
                opcionreporte = "TODOS";
            }
            else
            {
                ptovta = this.cboPtoVta.Text;
                opcionreporte = ptovta;
            }
        }

        private DataSet CalcularDataSet(string cadena)
        {
            string ssql = cadena;
            var sqlAdap = new SqlDataAdapter(ssql, datosEmpresa.strConxAdcom);
            // If conectar.State = ConnectionState.Closed Then conectar.Open()
            var datS = new DataSet();
            sqlAdap.Fill(datS, "Activos");
            // conectar.Close()
            sqlAdap.Dispose();
            return datS;
        }

        private void txtFechaDel_TextChanged(object sender, EventArgs e)
        {
            this.ReportViewer1.Clear();
        }

        private void txtFechaAl_TextChanged(object sender, EventArgs e)
        {
            this.ReportViewer1.Clear();
        }

        // Private Sub txtCodFin_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodFin.TextChanged
        // ReportViewer1.Clear()
        // End Sub
        private void cboSucursal_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ReportViewer1.Clear();
        }

        private void cboDoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ReportViewer1.Clear();
        }

        private void cboVendedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ReportViewer1.Clear();
        }

        #endregion


        #region Actualizar
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Reporte();
        }
        #endregion



        #region Opciones
        private void btnOpciones_Click(object sender, EventArgs e)
        {
            if (botonOp == false)
            {
                this.btnOpciones.Checked = false;
                botonOp = true;
            }
            else
            {
                this.btnOpciones.Checked = true;
                botonOp = false;
            }

            this.SplitContainer1.Panel1Collapsed = !this.btnOpciones.Checked;
        }

        private string BuscaCliente(string nom)
        {
            string BuscaClienteRet = default;
            string cod = "";
            var b = new DaxMantDirectorio.BusDirectorio();
            string argCEDULA = "";
            string argNombreAlias = "";
            string argTipo = "T";
            string argConNuevo = "";
            cod = b.BusDirect(ref cod, ref argCEDULA, ref nom, ref argNombreAlias, ref argTipo, ref argConNuevo);
            BuscaClienteRet = cod;
            return BuscaClienteRet;
        }

        private string nombre(string cod)
        {
            string nom = "";
            var conectar = new SqlConnection(datosEmpresa.strConxAdcom);
            conectar.Open();
            var cmd = new SqlCommand("select nombreImpresion from identificacion where codigo='" + cod + "'", conectar);
            SqlDataReader dat = null;
            dat = cmd.ExecuteReader();
            if (dat.Read())
            {
                if (!Information.IsDBNull(dat[0]))
                    nom = dat[0].ToString();
            }

            conectar.Close();
            conectar.Dispose();
            cmd.Dispose();
            dat.Close();
            return nom;
        }
        #endregion

        #region Salir
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
        #endregion

        private void txtEfectivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Information.IsNumeric(e.KeyChar) & !char.IsControl(e.KeyChar) & !(Conversions.ToString(e.KeyChar) == ".");
        }

        private void txtEfectivo_TextChanged(object sender, EventArgs e)
        {
            this.txtTotal.Text = (Conversion.Val(this.txtEfectivo.Text) + Conversion.Val(this.txtCheques.Text) + Conversion.Val(this.txtTarjetas.Text)).ToString();
        }

        private void btnMovimientos_Click(object sender, EventArgs e)
        {
            if (datosEmpresa.usr.ToUpper() != "ADMINISTRADOR")
                return;
            var prog = new DaxMovCaja.frmEdit();
            prog.ShowDialog();
            prog.Dispose();
        }

        private void btnConfirmaCierre_Click(object sender, EventArgs e)
        {
            if (CierreConfirmado == true)
            {
                MessageBox.Show("El cierre de caja para este período ya fue realizado ? ", "Cierre de caja", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CierreConfirmado = CierreDeCaja.RegistroCierresCaja.RegistrarcierreCaja(DatosCierre);
            if (CierreConfirmado == false)
            {
                MessageBox.Show("El cierre de caja no pudo registrarse ? ", "Cierre de caja", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.saveImagen(DatosCierre.IdClave);
            this.Close();
            this.Dispose();
        }

        private void saveImagen(decimal idclave)
        {
            this.ReportViewer1.ProcessingMode = ProcessingMode.Local;
            Warning[] Warnings = null;
            string[] streamdIds = null;
            string mimeType = null;
            string encoding = null;
            string extension = null;
            var bytes = this.ReportViewer1.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamdIds, out Warnings);
            int k = Information.UBound(bytes);
            if (k == 0)
                return;
            string pathFile = Path.Combine(PathDeImagenes(), @"CierresCaja\F" + DatosCierre.Sucursal + DatosCierre.PuntoDeVenta + DatosCierre.IdClave.ToString() + ".PDF");
            var fs = new FileStream(pathFile, FileMode.Create, FileAccess.Write);
            fs.Write(bytes, 0, k);
            fs.Close();
        }

        private string PathDeImagenes()
        {
            string pathImagenes = "";
            var dt = new DataTable();
            dt = datosEmpresa.leeParametrosEmp("Emp_PathImagenes");
            if (dt.Rows.Count > 0)
            {
                pathImagenes = "" + dt.Rows[0]["Emp_PathImagenes"].ToString();
                dt.Dispose();
                if (pathImagenes.Length > 2)
                {
                    if (pathImagenes.Substring(pathImagenes.Length - 1, 1) != @"\")
                        pathImagenes += @"\";
                }
            }

            return pathImagenes;
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            var prog = new Buscar.frmBuscar();
            string ssql = "SELECT cast(IdClave as varchar(20)) +' | '+ sucursal + ' | ' + PuntoDeVenta as Idclave, convert(varchar(17) ,FechaIni,13) as fechaini ";
            ssql += ", case when (isnull(FechaFin,'1900/01/01') < '1900/12/12') then '' else convert(varchar(17) ,FechaFin, 13 ) end as Fechafin ";
            ssql += " From DaxCiecaj ";
            // ssql += " where isnull(FechaFin,'1900/01/01') > '1900/30/12'"
            if (datosEmpresa.usr.ToUpper() != "ADMINISTRADOR")
            {
                ssql += " where PuntoDeVenta = '" + this.cboPtoVta.Text + "' ";
            }

            ssql += " order by fecha desc , FechaIni desc, sucursal, PuntoDeVenta ";
            string Ind = prog.Buscar(datosEmpresa.strConxAdcom, ssql, "IdClave", "Descripción", "", "BUSQUEDA DE CIERRES DE CAJA");
            var par = Ind.Split(Conversions.ToCharArrayRankOne("|"));
            if (par.Length > 1)
            {
                DatosCierre = CierreDeCaja.RegistroCierresCaja.CargarDatosCaja(Strings.Trim(par[1]), Strings.Trim(par[2]), Convert.ToDecimal(Strings.Trim(par[0])));
                cargarCierreLeido();
                proceso = 2;
                organizarBotones();
            }
        }

        private void organizarBotones()
        {
            this.cmbSucursal.Enabled = proceso < 2;
            this.cboPtoVta.Enabled = this.cmbSucursal.Enabled;
            this.Grupo.Enabled = this.cmbSucursal.Enabled;
            this.GrupoEntregaCaja.Enabled = this.cmbSucursal.Enabled;
            this.btnAbrir.Enabled = proceso == 0;
            // btnActualizar.Enabled = False
            this.btnCerrar.Enabled = proceso > 0;
            this.btnConfimaCierre.Enabled = proceso == 1;
            this.btnOpciones.Enabled = false;
            this.btnPdfOriginal.Enabled = proceso == 2;
            if (datosEmpresa.usr.ToUpper() != "ADMINISTRADOR")
            {
                this.Grupo.Enabled = false;
                this.cboPtoVta.Enabled = false;
                this.cmbSucursal.Enabled = false;
                this.btnMovimientos.Visible = false;
                // btnHorarios.Visible = False
            }
        }

        private void cargarCierreLeido()
        {
            {
                var withBlock = DatosCierre;
                this.txtCantCheques.Text = withBlock.RecibidoNroCheques.ToString();
                this.txtCantTarjetas.Text = withBlock.RecibidoNroTarjetas.ToString();
                this.txtCheques.Text = withBlock.RecibidoCheques.ToString();
                this.txtEfectivo.Text = withBlock.RecibidoEfectivo.ToString();
                this.txtFechaAl.Value = withBlock.FechaFin;
                this.txtFechaDel.Value = withBlock.FechaIni;
                this.txtTarjetas.Text = withBlock.RecibidoTarjetas.ToString();
                this.cboPtoVta.SelectedValue = withBlock.PuntoDeVenta;
                this.cmbSucursal.SelectedValue = datosEmpresa.suc;
                CierreConfirmado = true;
                Reporte();
            }
        }

        private void btnPdfOriginal_Click(object sender, EventArgs e)
        {
            string pathFile = Path.Combine(PathDeImagenes(), @"CierresCaja\F" + DatosCierre.Sucursal + DatosCierre.PuntoDeVenta + DatosCierre.IdClave.ToString() + ".PDF");
            try
            {
                Process.Start(pathFile);
            }
            catch (Exception ex)
            {
                MessageBox.Show("excepción : " + pathFile + Constants.vbCr + ex.Message);
            }
        }

        private void txtFechaAl_ValueChanged(object sender, EventArgs e)
        {
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            DatosIniciales();
        }

        private void btnHorarios_Click(object sender, EventArgs e)
        {
            var prog = new PtoVentaDefinicion.frmHorarios();
            prog.ShowDialog();
            prog.Dispose();
        }

        private void frmCierrCaja_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CierreConfirmado == false & esgeneral == false)
            {
                if (MessageBox.Show("Confirma salir sin registrar el cierre de caja ? ", "Cierre de caja", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void btnResumenGeneral_Click(object sender, EventArgs e)
        {
            CierreGeneral();
        }
    }
}