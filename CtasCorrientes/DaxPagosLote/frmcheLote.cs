using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using SysEmpDatt;
using ClassDoc;
namespace DaxPagosLote
{
    public partial class frmcheLote : Form
    {
        readonly PrySysp13.OpcDoc propiedadesDoc = new PrySysp13.OpcDoc();
        ClassDoc.idDocumento idDocumentoActual = new ClassDoc.idDocumento();
        List<idDocumento> EgresosCreados = new List<idDocumento>();
        public frmcheLote(string TipoLlamada = "")  // [N]omina, cuentas por pagar [P]roveedores
        {
            InitializeComponent();
            IniciarValores();
        }
        private void IniciarValores()
        {
            DaxCombobx.CargCmbBox cmb = new DaxCombobx.CargCmbBox();
            cmb.DaxCombosDoc("EGR", "", false, datosEmpresa.strConxAdcom, ref cmbDocumento);            

            string ssql = "select per_numero ,per_nombre from rolper order by per_numero desc";
            cmbPeriodosRol.DisplayMember = "per_nombre";
            cmbPeriodosRol.ValueMember = "per_numero";
            cmbPeriodosRol.DataSource = SqlDatos.leerTablaAdcom(ssql);

            ssql = "SELECT Bco_Codigo, Bco_Nombre +' - ' + bco_numcta as nombre FROM AdcCtaBco";
            cmbBancos.DisplayMember = "nombre";
            cmbBancos.ValueMember = "Bco_Codigo";
            cmbBancos.DataSource = SqlDatos.leerTablaAdcom(ssql);

            ssql = "select con_numero,con_descripcion from DefCon where (con_tipo = 'I' OR con_tipo = 'N')  and not (Con_Descripcion like ('%dia%') or Con_Descripcion like ('%hora%') or Con_Descripcion like ('%PREST%')) order by Con_Descripcion";
            cmbRubrosNomina.DisplayMember = "Con_Descripcion";
            cmbRubrosNomina.ValueMember = "Con_numero";
            cmbRubrosNomina.DataSource = SqlDatos.leerTablaAdcom(ssql);

            ssql = "select Sev_codigo, Sev_nombre from ADCSERV WHERE sev_egrbanco = 1 ORDER BY SEV_NOMBRE";
            cmbComceptosEgreso .DisplayMember = "sev_nombre";
            cmbComceptosEgreso.ValueMember = "sev_codigo";
            cmbComceptosEgreso.DataSource = SqlDatos.leerTablaAdcom(ssql);
            habilitarBotones();
        }
        private void habilitarBotones(int  marcando = 0)
        {
            // marcando 1 macando false  2 marcando true  0 desde otra parte
            btnEnviar.Enabled = (MallaDatos.Rows.Count > 0);
            if (marcando == 0) btnProcesar.Enabled = (ExistenMarcas());
            else btnProcesar.Enabled = (marcando == 2);
            btnCierra.Enabled = btnEnviar.Enabled;
            btnAbrir.Enabled = !btnCierra.Enabled;
        }
        private void btnOcultarParametros_Click(object sender, EventArgs e)
        {
            PanelParametros.Visible = !PanelParametros.Visible;
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            string ssql;
            {
                ssql = "select IdEmpleado,NombreImpresion, Liq_Valor as Valor, '' as X from Rolliq ";
                ssql += " LEFT JOIN Identificacion ON IdEmpleado = Codigo ";
                ssql += " where Liq_CodigoConcepto = '" + cmbRubrosNomina.SelectedValue.ToString() + "' and Liq_Periodo = " + cmbPeriodosRol.SelectedValue.ToString();
                ssql += " and liq_valor > 0";
                MallaDatos.DataSource = SqlDatos.leerTablaAdcom(ssql);
            }

            MallaDatos.Columns["valor"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            MallaDatos.Columns["valor"].DefaultCellStyle.Format = "0.00";
            habilitarBotones();
        }

        private void btnMarcarTodo_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow dgv in MallaDatos.Rows)
            {
                dgv.Cells["X"].Value = "X";
            }
            habilitarBotones(2);
        }

        private void BtnQuitarTodo_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgv in MallaDatos.Rows)
            {
                dgv.Cells["X"].Value = "";
            }
            habilitarBotones(1);
        }

        private void btnMarcarSeleccion_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgv in MallaDatos.SelectedRows)
            {
                dgv.Cells["X"].Value = "X";
            }
            habilitarBotones(2);
        }
        private void btnQutarSelecccion_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgv in MallaDatos.SelectedRows)
            {
                dgv.Cells["X"].Value = "X";
            }
        }

        private void ImprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewPrinterApplication1.frmMain imp = new DataGridViewPrinterApplication1.frmMain();
            string tit2 = "";
            imp.imprimir(MallaDatos, "Lista de valores ", tit2, datosEmpresa.Emp_Nombre);
        } 
        private void WordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportarGrid.Form1 exp = new ExportarGrid.Form1();
            exp.Exportar(MallaDatos, "W", datosEmpresa.Emp_Nombre, "");
        }

        private void ExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportarGrid.Form1 exp = new ExportarGrid.Form1();
            exp.Exportar(MallaDatos, "E", datosEmpresa.Emp_Nombre, "");
        }

        private void PDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportarGrid.Form1 exp = new ExportarGrid.Form1();
            exp.Exportar(MallaDatos, "P", datosEmpresa.Emp_Nombre, "");
        }

        private void btnCierra_Click(object sender, EventArgs e)
        {
            MallaDatos.Columns.Clear();
        }

        private void btnSalir2_Click(object sender, EventArgs e)
        {
            Close();
            this.Dispose();
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            if (!ExistenMarcas()) {MessageBox.Show("No existen registros seleccionados"); return; }
            WaitMensaje.WMensaje.verMensaje("Generando egeresos de " + cmbRubrosNomina.Text);
            string tipo = cmbDocumento.SelectedValue.ToString();
            string lugar = "";
            Int32  nroCheque;
            if (MessageBox.Show("Confirma generar los documentos según los valores actuales ?", "", MessageBoxButtons.YesNo) == DialogResult.No) return;
            propiedadesDoc.Cargar(ref tipo, ref lugar);
            ClassDoc.controlNumeracion cnum = new ClassDoc.controlNumeracion();
            idDocumentoActual = new ClassDoc.idDocumento 
            {
                familia = propiedadesDoc.TipoDoc,
                fecha = dtFechaDocumento.Value,
                numero = 0,
                Serie = "",
                Sucursal = datosEmpresa.suc,
                Tipo = cmbDocumento.SelectedValue.ToString()
            };
            idDocumentoActual.numero = cnum.NumeroMayor(idDocumentoActual, "", "", "", datosEmpresa.strConxAdcom);
            nroCheque = PonerNumeroCheque();

            foreach (DataGridViewRow dgvr in MallaDatos.Rows)
            {
                if (dgvr.Cells["X"].Value.ToString() == "X")
                {
                    GrabarDocumento(dgvr, nroCheque);
                    if (chkImprimeEgreso.Checked)
                    {
                        ImpresionesDeldocumento("", !chkPausaImprime.Checked);
                    }
                    else if (chkImprimeCheque.Checked)
                    {
                        ImpresionesDeldocumento("CHE", !chkPausaImprime.Checked);
                    }
                    EgresosCreados.Add(idDocumentoActual);
                    nroCheque++;
                    idDocumentoActual.numero++;
                }
            }
            if (nroCheque > 0 && EgresosCreados.Count > 0) ActualizarNroCheque(nroCheque);
            if (chkImprimeCheque.Checked && chkImprimeEgreso.Checked)
            {
                if (MessageBox.Show("Cuando este lista la impresión de CHEQUES, presione enter o cancele la impresón", "Impresion de egeresos/cheques ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)  return;
                foreach (ClassDoc.idDocumento  ID  in EgresosCreados)
                {
                    idDocumentoActual = ID;
                    ImpresionesDeldocumento("CHE", !chkPausaImprime.Checked);
                }
            }
            WaitMensaje.WMensaje.cierraMensaje();
            MallaDatos.Columns.Clear();
            habilitarBotones();
        }
        private void ActualizarNroCheque(Int32 numero)
        {
            string cod = "update AdcDocNUM set ultimonumero = " + numero.ToString() + " where ID_LUGAR ='" + cmbBancos.SelectedValue.ToString() + "' and ID_DOCUMENTO='" + cmbDocumento.SelectedValue.ToString() + "'";
            SqlDatos.ejecutarComandoAdcom(cod);
        }

        private bool ExistenMarcas()
        {
            foreach (DataGridViewRow dgvr in MallaDatos.Rows)
            {
                if (dgvr.Cells["X"].Value.ToString() == "X")
                {
                    return true;
                }
            }
            return false;   
        }
        private void ImpresionesDeldocumento(string OtroFormato = "", bool ImpresionDirecta = false)
        {
            ImpresionDocumentosDax.ImprimeDocumentoDoble impProg = new ImpresionDocumentosDax.ImprimeDocumentoDoble(datosEmpresa.nombreBaseIvaret, datosEmpresa.strConxAdcom, datosEmpresa.strConxIvaret, datosEmpresa.strConxDaxsys, datosEmpresa.strConxDaxpro, datosEmpresa.codEmpresa, datosEmpresa.pathServer);
            int imp;
            if (ImpresionDirecta)
            {
                imp = impProg.ImpDocFast(idDocumentoActual, "A", OtroFormato, false, true);
            }
            else
            {
                imp = impProg.ImpDoc(idDocumentoActual, "A", OtroFormato, false, false);
            }
        }

        private Int32  PonerNumeroCheque()
        {
            Int32 numero;
            string cod = "select isnull(ultimonumero,0) as ultimonumero from AdcDocNUM where ID_LUGAR ='" + cmbBancos.SelectedValue.ToString() + "' and ID_DOCUMENTO='" + cmbDocumento.SelectedValue.ToString() + "'";
            DataTable dt = SqlDatos.leerTablaAdcom(cod);
            if (dt.Rows.Count == 0)
            {
                numero =  1;
            }
            else
            {
                numero = Convert.ToInt32(dt.Rows[0]["ultimonumero"]) + 1;
            }
            return numero;
        }

        internal void GrabarDocumento(DataGridViewRow row ,Int32 NumeroDeCheque)
        {
            DaxMantDirectorio.DirectorioAlex  alx = new DaxMantDirectorio.DirectorioAlex();
            string codigo = row.Cells["IdEmpleado"].Value.ToString();
            bool clipro = false;
            string solocodigo = "";
            alx.CargarAlex(ref codigo,ref clipro,ref solocodigo);
            ClassDoc.AdcDoc datADCDOC = new ClassDoc.AdcDoc(datosEmpresa.strConxAdcom)
            {
                //datADCDOC.IdClaveDoc = Convert.ToDecimal(idDocumentoActual.idClave);
                Doc_sucursal = idDocumentoActual.Sucursal,
                Doc_Bodega = "",
                //datADCDOC.PuntoVta = valoresPredefinidosSucursal.idPuntoVta;
                Opc_documento = idDocumentoActual.Tipo,
                Doc_docnombre = cmbDocumento.Text,
                Doc_numero = Convert.ToDecimal(idDocumentoActual.numero),
                Doc_fecha = Convert.ToDateTime(idDocumentoActual.fecha.ToShortDateString()),
                Doc_codper = codigo,
                Doc_CiRuc = alx.CiRuc,
                Doc_NombreImp = row.Cells["NombreImpresion"].Value.ToString(),
                Doc_Direccion = alx.direccion,
                Doc_Telefono1 = alx.telefono1,
                Doc_detalle = "",
                //if (cmbVendedor.SelectedValue != null) datADCDOC.Doc_venabre = "" + cmbVendedor.SelectedValue.ToString();

                Doc_DocSop = "",
                Doc_NumSop = 0,
                IdClaveDocSop = 0,

                Doc_valor = Convert.ToDecimal(row.Cells["Valor"].Value),
                AuxVar9 = "",
                Doc_Hora = DateTime.Now,

                Doc_NroLoteDoc = cmbPeriodosRol.SelectedValue.ToString(),
                //datADCDOC.Doc_NroIdDoc = txtNroID.Text;
                //datADCDOC.Adi_TipoDocSri = propiedadesDoc.TipoSri;
                //datADCDOC.Adi_FechContab = IIf(FechaContab < TxtFecha, TxtFecha, FechaContab)
                //datADCDOC.Adi_CodigoNSR = TexCodigoExoneraRetencion.Text
                //datADCDOC.Adi_SustTrib = DatSustento.BoundText
                //datADCDOC'.Adi_SNDevIva = IIf(DerechoIva.Value = 1, "S", "N")
                //datADCDOC.Doc_docnombre = "";
                Doc_TipoDoc = idDocumentoActual.familia,
                Doc_FechaEfe = idDocumentoActual.fecha,
                Doc_extension = "",
                Doc_codusu = DatosUsuario.codigo,
                //datADCDOC.Doc_valoriva = totalesDocumento.TotIva;
                //datADCDOC.Doc_totciva = totalesDocumento.TotCiva;
                //datADCDOC.Doc_totsiva = totalesDocumento.TotSiva;
                //datADCDOC.doc_TotDesSiva = totalesDocumento.totdessiva;
                //datADCDOC.doc_TotDesCIva = totalesDocumento.totdesciva;            //datADCDOC.Doc_valorabon = totalesDocumento.ValorCon;
                //datADCDOC.Doc_DepDes = "";
                //datADCDOC.Doc_TotDesArt = totalesDocumento.TotDesArt;
                //datADCDOC.Doc_TotDesSer = totalesDocumento.TotDesSer;
                //datADCDOC.Doc_TotArtCIva = totalesDocumento.TotArtCIva;
                //datADCDOC.Doc_TotArtSIva = totalesDocumento.TotArtSIva;
                //datADCDOC.Doc_TotSerCIva = totalesDocumento.TotSerCIva;
                //datADCDOC.Doc_TotSerSIva = totalesDocumento.TotSerSIva;
                //datADCDOC.Doc_TotAcf = totalesDocumento.TotAcf;
                //datADCDOC.Doc_Contado = totalesDocumento.ValorEfec;
                Doc_Estado = 1,
                Doc_Oculto = propiedadesDoc.ClaveOculto,
                Doc_Contabilidad = propiedadesDoc.ClaveContable,
                Doc_Banco = Convert.ToInt16(propiedadesDoc.ClaveBanco),
                Doc_Inventario = Convert.ToInt16(propiedadesDoc.ClaveInventario),
                Doc_Ventas = Convert.ToInt16(propiedadesDoc.ClaveVentas),
                Doc_Compras = Convert.ToInt16(propiedadesDoc.ClaveCompras),
                Doc_Activo = Convert.ToInt16(propiedadesDoc.ClaveActivo),
                Doc_Adicional2 = 0,
                Doc_NumeroExterno = 0,
                Doc_FechaModifica = DateTime.Now,
                Cobranza = "",
                doc_BancoOrigen = cmbBancos.SelectedValue.ToString(),
                doc_NumeroCheque = NumeroDeCheque.ToString(),
                doc_Anticipo = false,
                Doc_FecGraba = DateTime.Now,

                //if (Estransferencia)
                //{
                //    datADCDOC.doc_BancoDestino = cmbCtasBacoDestino.SelectedValue.ToString();
                //}
                //else

                doc_BancoDestino = ""
            };
            string resp = datADCDOC.Crear();
            if (resp.Substring(0,3) != "ERR")
            {
                GuardarDetalleDoc(datADCDOC, row);
                idDocumentoActual.idClave = Convert.ToDouble(datADCDOC.IdClaveDoc);
            }                
        }

        public void GuardarDetalleDoc(ClassDoc.AdcDoc DatosDoc, DataGridViewRow DgvRow, string TipoPago = "")
        {
            string codsql = " FROM AdcApl WHERE doc_sucursal='" + DatosDoc.Doc_sucursal + "' and opc_documento='" + DatosDoc.Opc_documento + "' and idclavedoc=" + DatosDoc.IdClaveDoc;
            DataTable dataTab = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter("select * " + codsql, datosEmpresa.strConxAdcom))
            {
                da.Fill(dataTab);
                foreach (DataRow row in dataTab.Rows){row.Delete();}
                int I = 0;
                {
                    DataRow dtRow = dataTab.NewRow();
                    dtRow["Doc_sucursal"] = DatosDoc.Doc_sucursal;
                    dtRow["Doc_numero"] = DatosDoc.Doc_numero;
                    dtRow["Opc_documento"] = DatosDoc.Opc_documento;
                    dtRow["IdClaveDoc"] = DatosDoc.IdClaveDoc;

                    dtRow["apl_docapli"] = "";
                    dtRow["APL_NUMAPLI"] = 0;
                    dtRow["apl_sucapli"] = "";
                    dtRow["idClaveDocapl"] = 0;
                    dtRow["Apl_fecha"] = DatosDoc.Doc_fecha;
                    //try
                    {
                        dtRow["Apl_docfecha"] = DatosDoc.Doc_fecha;
                    }
                    //catch { dtRow["Apl_docfecha"] = DatosDoc.Doc_fecha; }
                    dtRow["Apl_valorapl"] = DatosDoc.Doc_valor;
                    dtRow["Apl_codbenef"] = DatosDoc.Doc_codper;
                    //if (DgvRow.Cells["Apl_codbenef"].Value.ToString() == "") dtRow["Apl_codbenef"] = DatosDoc.Doc_codper;
                    dtRow["Apl_SNContado"] = 0;
                    dtRow["CodConcepto"] = cmbComceptosEgreso.SelectedValue.ToString();
                    dtRow["descripcionconcepto"] = cmbComceptosEgreso.Text;
                    dtRow["TRa_Ventas"] = 0;
                    dtRow["TRa_Compras"] = 0;
                    dtRow["tra_esanticipo"] = 0;
                    dtRow["tra_Banco"] = -1;
                    dtRow["tra_escontable"] = 0;
                    dtRow["tra_CtasCobrar"] = -1;
                    dtRow["tra_CtasPagar"] = 0;

                    if (DatosDoc.Doc_TipoDoc == "ING")
                    {
                        if (Convert.ToInt16(DgvRow.Cells["espago"].Value) == 0) dtRow["ESPAGO"] = "E"; else dtRow["ESPAGO"] = "C";
                    }
                    else
                    {
                        dtRow["ESPAGO"] = "";
                    }
                    dtRow["idclaveapl"] = I;

                    //if (Val(DgvRow.Cells["idclaveapl"].Value) != 0)
                    //{ dtRow["idclaveaplapl"] = Val(DgvRow.Cells["idclaveapl"].Value); }
                    //else { Val(dtRow["idclaveapl"] = 0); }

                    dtRow["tra_costo"] = ""; // DgvRow.Cells["tra_costo"].Value.ToString();
                    dtRow["tra_centroproduccion"] = ""; // DgvRow.Cells["tra_centroproduccion"].Value.ToString();
                    dtRow["tra_centrodistribucion"] = ""; // DgvRow.Cells["tra_centrodistribucion"].Value.ToString();
                    dtRow["tra_empleado"] = ""; // DgvRow.Cells["tra_empleado"].Value.ToString();
                    dtRow["Tra_Proyecto"] = ""; // DgvRow.Cells["Tra_Proyecto"].Value.ToString();

                    I++;
                    dtRow["numLinApl"] = I;

                    dataTab.Rows.Add(dtRow);
                }
                SqlCommandBuilder CB = new SqlCommandBuilder(da);
                da.Update(dataTab);
                dataTab.AcceptChanges();
            }
        }
    }

}
