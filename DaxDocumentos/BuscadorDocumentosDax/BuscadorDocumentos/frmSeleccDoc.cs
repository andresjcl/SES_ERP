using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DattCom;
namespace BuscadorDocumentos
{
    public partial class frmSeleccDoc : Form
    {
        //string Solodoc = "";
        string DocInicial = "";
        string Codigo = "";
        string claseDoctosPermitidos = ""; // ES LA CLASE DE DOCUMENTOS QUE QUEREMOS BUSCAR (viene un solo string string  de  cdigos de doctos de tres en tres seguidos "FACEGRFAPPRO...etc")
        DateTime InicFec = new DateTime(1900, 1, 1);
        bool sinArticulos = false;
        bool estaConsolidando = false;
        public frmSeleccDoc(string claseDoc) //string claseDocumentos, string codCliente, string tipDocAConsultar, DateTime IniFec, ref string EsSuc, ref string EsTipDoc, ref double EsNumDoc, ref double idClaveDocapl, bool SinArt = false, string tipDocQueInicia = "", string TipoLiquidacion = "", string NroLiquidacion = "", string Tabla = "")
        {
            InitializeComponent();
            claseDoctosPermitidos = claseDoc;

            this.Load += frmBuscarDoc_Load;   // ← IMPORTANTE
        }
        private ClassDoc.idDocumento idDocumento = new ClassDoc.idDocumento();

        #region Consulta
        private listaDocumentos filasSelecc = new listaDocumentos();

        //public listaDocumentos EscojerVariosDocumentos(string claseDoc)
        //{
        //    claseDoctosPermitidos = claseDoc;
        //    this.ShowDialog();
        //    return filasSelecc;
        //}
        public listaDocumentos EscojerVariosDocumentos()
        {
            this.ShowDialog();
            return filasSelecc;
        }

        private void frmBuscarDoc_Load(object sender, EventArgs e)
        {
            if (sinArticulos)
            {
                Label4.Visible = false;
                btnArticuloCod.Visible = false;
                btnServicioCod.Visible = false;
                txtArtCodigo.Visible = false;
                txtArticuloNombre.Visible = false;
            }

            txtFechaIn.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            txtFechaFin.Value = DateTime.Now;
            
            DaxCombobx.CargCmbBox llcbo = new DaxCombobx.CargCmbBox();

            llcbo.DaxCombosDoc(claseDoctosPermitidos, DocInicial, false, datosEmpresa.strConxAdcom, ref cboTipoDoc);
            llcbo.DaxCombosPtoVta(datosEmpresa.strConxAdcom, ref cboPtoVenta, true);
          

            // ✔ primero llenar sucursales
            llcbo.DaxCombosSuc(datosEmpresa.codEmpresa.ToString(), true, datosEmpresa.strConIniSis, ref cboSucursal);

            // ✔ luego cargar bodegas según la sucursal
            if (cboSucursal.SelectedValue != null)
            {
                llcbo.DaxCombosBods(cboSucursal.SelectedValue.ToString(), true, datosEmpresa.strConIniSis, ref cboBodega);
            }
            // ✔ luego asignar la sucursal del usuario
            if (!string.IsNullOrEmpty(datosEmpresa.suc))
            {
                cboSucursal.SelectedValue = "0";
            }

            if (!string.IsNullOrEmpty(datosEmpresa.Bodega))
            {
                cboBodega.SelectedValue = "0";
            }


            // Punto de venta
            try
            {
                cboPtoVenta.SelectedValue = Environment.MachineName;
            }
            catch
            {
                cboPtoVenta.SelectedValue = "0";
            }

            if (cboPtoVenta.SelectedValue == null)
                cboPtoVenta.SelectedValue = "0";

            // Tipo documento
            string aux = DocInicial.Replace("'", "");
            if (aux.Length >= 3)
            {
                try
                {
                    cboTipoDoc.SelectedValue = aux.Substring(0, 3);
                }
                catch { }
            }

            // Combos fijos
            cmbActivos.SelectedIndex = 1;
            cmbAutorizaciones.SelectedIndex = 1;

            // Cliente
            if (!string.IsNullOrEmpty(Codigo))
            {
                txtClienteCod.Text = Codigo;

                var prog = new EmpNomR.AdcNomb();
                txtClienteNombre.Text = prog.RetornaNombreDirectorio(
                    Codigo,
                    datosEmpresa.strConxAdcom);
            }

            // Cargar datos
            //CargarMalla();

            // Foco
            txtFechaIn.Focus();
        }
        private void CargarMalla()
        {
            string numero = "";
            string Bus_PtoVta = "";
            //string Bus_tipDoc = cboTipoDoc.SelectedValue.ToString();

            string Bus_tipDoc = "";

            if (cboTipoDoc.SelectedValue != null &&
                cboTipoDoc.SelectedValue.GetType() != typeof(DataRowView))
            {
                Bus_tipDoc = cboTipoDoc.SelectedValue.ToString();
            }
            else
            {
                return;
            }
            string Bus_suc = "";
            string Bus_bod = "";
            string Bus_client = "";
            string Bus_art = "";
            string Bus_det = "";
            string Bus_valor = "";
            string Bus_tablaDoc = "ADCDOC";
            string Bus_tablaTra = "ADCTRA";
            sesSys.OpcDoc opcdoc = new sesSys.OpcDoc();
            opcdoc.Cargar(ref Bus_tipDoc,ref Bus_suc);
            malla.DataSource = null;
            if (opcdoc.tablaDatosDoc.ToUpper() == "ADCDOCPRO")
            {
                Bus_tablaDoc = "AdcDocpro";
                Bus_tablaTra = "AdcTraPro";
            }

            if (cboTipoDoc.SelectedValue == null)
                return;
            //string campo = camp;

            if (estaConsolidando & DocInicial.Length > 3)
            {
                Bus_tipDoc = " and opc_documento in (" + DocInicial + ")";
            }
            else
            {
                Bus_tipDoc = " and opc_documento ='" + cboTipoDoc.SelectedValue.ToString() + "' ";
            }
          
            try
            {
                if (cboSucursal.SelectedValue != null)
                {
                    string suc = cboSucursal.SelectedValue.ToString();

                    if (!string.IsNullOrEmpty(suc) && suc != "0")
                    {
                        Bus_suc = " and doc_sucursal = '" + suc + "' ";
                    }
                }
            }
            catch
            {
            }
            
            var pto = cboPtoVenta.SelectedValue?.ToString();

            if (!string.IsNullOrEmpty(pto) && pto != "0")
            {
                Bus_PtoVta = " and puntovta = '" + pto + "' ";
            }
          
            string bod = cboBodega.SelectedValue?.ToString();

            if (!string.IsNullOrEmpty(bod) && bod != "0")
            {
                Bus_bod = " and doc_bodega = '" + bod + "' ";
            }

            if (!string.IsNullOrEmpty(txtClienteCod.Text))
            {
                Bus_client = " and (doc_codper ='" + txtClienteCod.Text + "' or Doc_CiRuc ='" + txtClienteCod.Text + "') ";
            }

            if (!string.IsNullOrEmpty(txtDetalle.Text))
            {
                Bus_det = " and doc_detalle like '%" + txtDetalle.Text + "%'";
            }

            if (!string.IsNullOrEmpty(txtArtCodigo.Text))
            {
                Bus_art = " and idClaveDoc in(select DISTINCT idclaveDoc from " + Bus_tablaTra + " where tra_codigo ='" + txtArtCodigo.Text + "') ";
            }

            if (!string.IsNullOrEmpty(txtvalor.Text))
            {
                Bus_valor = " and doc_valor like '%" + txtvalor.Text + "%'";
            }

            if (!string.IsNullOrEmpty(txtNumDoc.Text))
            {
                numero = " and Doc_NroLoteDoc ='" + txtNumDoc.Text + "'";
            }

            string ssql = "select doc_sucursal as SUC, opc_documento as TIP";
            ssql += ",doc_fecha as FECHA,doc_numero as NUM,Doc_NombreImp as NOMBRE, doc_valor as VALOR";
            ssql += ",Doc_detalle as DETALLE,doc_codper, idClaveDoc,isnull(estadosri,'') as EstadoSri  from " + Bus_tablaDoc + "";
            ssql += " where doc_fecha>= '" + txtFechaIn.Text + "' and doc_fecha<= '" + txtFechaFin.Text + " 23:59:59' ";
            ssql += Bus_tipDoc + Bus_suc + Bus_bod + Bus_PtoVta + Bus_client + Bus_art + Bus_det + Bus_valor + numero;
            if (cmbAutorizaciones.SelectedIndex == 2)
            {
                ssql += " and (isnull(EstadoSri,'') = 'Autorizado')";
            }
            else if (cmbAutorizaciones.SelectedIndex == 1)
            {
                ssql += " and (isnull(EstadoSri,'') <> 'Autorizado')";
            }

            if (cmbActivos.SelectedIndex == 2)
            {
                ssql += " and (isnull(doc_estado,0) = 0)";
            }
            else if (cmbAutorizaciones.SelectedIndex == 1)
            {
                ssql += " and (isnull(doc_estado,0) = 1)";
            }
            malla.DataSource = SqlDatos.leerTablaAdcom(ssql);
            malla.ClearSelection();
            malla.Columns["doc_codper"].Visible = false;
            malla.Columns["idclavedoc"].Visible = false;
            malla.Columns["fecha"].DefaultCellStyle.Format = "dd/MMM/yyyy";
            malla.Columns["Valor"].DefaultCellStyle.Format = "###,###,###,##0.00";
            malla.Columns["Detalle"].Visible = false;
        }

        private void txtFechaIn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                CargarMalla();
                return;
            }
        }

        private void txtFechaFin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                CargarMalla();
                return;
            }
        }

        #endregion

        #region Panel Opciones

        // Metodo para mostrar u ocultar el panel de opciones
        // Metodo para inicializar las cajas de texto del panel de opciones
        private void limpiar()
        {
            txtArtCodigo.Text = "";
            txtArticuloNombre.Text = "";
            txtClienteCod.Text = "";
            txtClienteNombre.Text = "";
            txtDetalle.Text = "";
            txtvalor.Text = "";
        }
        // Metodo para limpiar la malla
        private void cboTipoDoc_SelectedIndexChanged(object sender, EventArgs e)
        {
                CargarMalla();
        }

        private void cboSucursal_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarMalla();
        }

        private void cboBodega_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarMalla();
        }

        private void txtDetalle_TextChanged(object sender, EventArgs e)
        {
            CargarMalla();
        }

        private void txtArtCodigo_TextChanged(object sender, EventArgs e)
        {
            CargarMalla();
        }

        private void txtvalor_TextChanged(object sender, EventArgs e)
        {
            CargarMalla();
        }
        #endregion


        private void btnBorrar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarMalla();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            filasSelecc = new listaDocumentos();
            if (malla.SelectedRows.Count > 0) ArmarSeleccion();
            Close();
        }
        private void ArmarSeleccion()
        {
            foreach (DataGridViewRow row in malla.SelectedRows)
            {
                ClassDoc.idDocumento iddoc = new ClassDoc.idDocumento()
                {
                    idClave = Convert.ToDouble(row.Cells["idclavedoc"].Value),
                    Sucursal = row.Cells["SUC"].Value.ToString(),
                    Tipo = row.Cells["Tip"].Value.ToString(),
                    numero = Convert.ToDouble(row.Cells["Num"].Value),
                    familia = row.Cells["Doc_tipodoc"].Value.ToString()
                };
                filasSelecc.IdDocs.Add(iddoc);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtNumDoc_KeyPress(object sender, KeyPressEventArgs e)
        {

            if ("0123456789".IndexOf((e.KeyChar).ToString()) == -1)
                e.KeyChar = Convert.ToChar("");
        }

        private void txtNumDoc_TextChanged(object sender, EventArgs e)
        {
            CargarMalla();
        }

        private void btnClienteCod_Click(object sender, EventArgs e)
        {
            var prog = new directMnt.BusDirectorio();
            string nombre = "";
            string argcodigo = "";
            string argCEDULA = "";
            string argNombreAlias = "";
            string argTipo = "";
            string argConNuevo = "";
            txtClienteCod.Text = prog.BusDirect(ref argcodigo, ref argCEDULA, ref nombre, ref argNombreAlias, ref argTipo, ref argConNuevo);
            txtClienteNombre.Text = nombre;
        }

        private void btnArticuloCod_Click(object sender, EventArgs e)
        {
            var progbus = new Buscar.frmBuscar();
            var nombrar = new EmpNomR.AdcNomb();
            txtArtCodigo.Text = progbus.Buscar(datosEmpresa.strConxAdcom, "select art_codigo,art_nombre from adcart", "art_codigo", "art_nombre", "", "Busca Artículos");
            txtArticuloNombre.Text = nombrar.RetornaNombreArticulo(txtArtCodigo.Text, datosEmpresa.strConxAdcom);
        }

        private void btnServicioCod_Click(object sender, EventArgs e)
        {
            var progbus = new Buscar.frmBuscar();
            var nombrar = new EmpNomR.AdcNomb();
            txtArtCodigo.Text = progbus.Buscar(datosEmpresa.strConxAdcom, "select sev_codigo,sev_nombre from adcserv", "sev_codigo", "sev_nombre", "", "Busca Servicios");
            txtArticuloNombre.Text = nombrar.RetornaNombreServicio(txtArtCodigo.Text, datosEmpresa.strConxAdcom);
        }

        private void txtClienteCod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return & txtClienteCod.TextLength > 0)
                CargarMalla();
        }
    }
}
