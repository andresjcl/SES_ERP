using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient ;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace daxEmiFacPv
{
    public partial class frmExporta : Form
    {
        public classExporta Export;
        string doc_sucursal;
        string opc_documento;
        decimal IdClaveDoc;

        public frmExporta()
        {
            InitializeComponent();
        }
        //public classExporta iniciaForm(classExporta export)
        //{
        //    Export=export;
        //    cargarDatos();
        //    this.ShowDialog();
        //    return Export;
        //}
        private void cargarDatos()
        {
            Syscod.ManSysnetClass sys = new Syscod.ManSysnetClass();

            if (Export.ClienteConsig  == string.Empty && Export.IdClaveDoc != 0)
            {
                Export = classExporta.Buscar(" doc_sucursal = '" + Export.Doc_Sucursal  + "' and  opc_documento = '" + Export.Opc_documento  + "' and idclavedoc = " + Export.IdClaveDoc);
                if (Export == null)
                { 
                    Export = new classExporta();
                    Export.Doc_Sucursal = doc_sucursal;
                    Export.Opc_documento = opc_documento;
                    Export.IdClaveDoc = IdClaveDoc;
                }
            }

            cmbTerminosVenta.Text = Export.TerminosVent;
            txtLugarEntrega.Text = Export.CiudadFOB;
            
            txtcodPaisOrgen.Text = Export.OrigProducto;
            txtnomPaisOrigen.Text = sys.QueNombre(Export.OrigProducto, "Paises");

            txtPuertoEmbarque.Text=Export.embarque;
            
            txtcodPaisDestino.Text=Export.Estado;
            txtnomPaisDestino.Text = sys.QueNombre(Export.Estado, "Paises");

            txtPuertoDestino.Text=Export.PuertoDest;
            txtcodPaisAdquisicion.Text = Export.paisAdquisicion;
            txtnomPaisAdquisicion.Text = sys.QueNombre(Export.paisAdquisicion, "Paises");
            txtSeguroInternacional.Text=Export.seguroInternacional;
            txtGastosAduana.Text = Export.gastosAduana;
            txtTransporteOtros.Text = Export.gastosTransporte;
                        
            txtConsigarCod.Text = Export.ClienteConsig;
            txtConsignarNom.Text = Export.consignarNom;
            txtcedulaTransportista.Text = Export.Transporte ;
            txtNomTransportadora.Text = Export.transportarNom;
            txtCondicionesVenta.Text = Export.condicionesVenta ;
            txtViaEmbarque.Text = Export.ViaEmbarque ;
            txtEndosarCod.Text = Export.EndosarCod ;
            txtEndosarNom.Text = Export.EndosarNom;
            txtFlete.Text = Export.Flete;
            txtValorFob.Text  = Export.valorFob ;
            txtPesoBruto.Text = Export.TotalPesoBruto.ToString();
            txtPesoNeto.Text = Export.TotalPesoNeto.ToString() ;

            chkConReferendo.Checked = (Export.exportacionDe == 1);
            txtDistrito.Text = Export.disAduanero;
            txtAnio.Text = Export.anio;
            txtRegimen.Text = Export.regimen;
            txtCorrelativo.Text = Export.correlativo;
            txtVerificador.Text = Export.verificador;
            txtNroDocTransporte.Text = Export.docTransp;
            try
            {
                dtFechaEmbarque.Value = Convert.ToDateTime(Export.fechaEmbarque);
            }
            catch { dtFechaEmbarque.Value = DateTime.Now; }
            txtValorfobcomprobante.Text = Export.valorFobComprobante;
            txtNroFue.Text = Export.Fue;
            sumarFob();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            MoverDatosAClase ();
            this.Close();
        }
        private void MoverDatosAClase()
        {

            Export.TerminosVent = cmbTerminosVenta.Text;
            Export.CiudadFOB = txtLugarEntrega.Text;
            Export.OrigProducto = txtcodPaisOrgen.Text;
            Export.embarque = txtPuertoEmbarque.Text ;
            Export.Estado = txtcodPaisDestino.Text;
            Export.PuertoDest = txtPuertoDestino.Text;
            Export.paisAdquisicion = txtcodPaisAdquisicion.Text;
            Export.seguroInternacional = txtSeguroInternacional.Text;
            Export.gastosAduana = txtGastosAduana.Text;
            Export.gastosTransporte = txtTransporteOtros.Text;

            Export.ClienteConsig = txtConsigarCod.Text ;
            Export.consignarNom = txtConsignarNom.Text ;
            Export.Transporte  = txtcedulaTransportista.Text ;
            Export.transportarNom =  txtNomTransportadora.Text ;
            Export.condicionesVenta   =  txtCondicionesVenta.Text ;

            Export.ViaEmbarque  = txtViaEmbarque.Text;
            Export.EndosarCod  = txtEndosarCod.Text;
            Export.EndosarNom = txtEndosarNom.Text;
            Export.Flete = txtFlete.Text;
            Export.valorFob = txtValorFob.Text;
            Export.TotalPesoBruto = Convert.ToDecimal(txtPesoBruto.Text);
            Export.TotalPesoNeto  = Convert.ToDecimal(txtPesoNeto.Text);

            if (chkConReferendo.Checked) { Export.exportacionDe = 1; } else { Export.exportacionDe = 2; }
            Export.disAduanero = txtDistrito.Text;
            Export.anio = txtAnio.Text;
            Export.regimen = txtRegimen.Text;
            Export.correlativo = txtCorrelativo.Text;
            Export.verificador = txtVerificador.Text;
            Export.docTransp = txtNroDocTransporte.Text;
            Export.fechaEmbarque = dtFechaEmbarque.Text;
            Export.valorFobComprobante = txtValorfobcomprobante.Text;
            Export.Fue = txtNroFue.Text;
       
        }

        private void button3_Click(object sender, EventArgs e)
        {            
            this.Close();
        }

        private void frmExporta_Load(object sender, EventArgs e)
        {
            doc_sucursal = Export.Doc_Sucursal;
            opc_documento = Export.Opc_documento;
            IdClaveDoc = Export.IdClaveDoc;
            cargarDatos();
        }

        private void btnBuscaDestinatario_Click(object sender, EventArgs e)
        {
            MantenimientoDirectorio.BuscaClien directorio = new MantenimientoDirectorio.BuscaClien();
            string cliente = "C";
            string codigo = "";
            string nombre = "";
            string conalias = "N";
            string connuevo = "N";
            codigo  = directorio.IniBuscaCliOPro(ref cliente, ref nombre, ref conalias, ref connuevo);
            if ((codigo + "").Length > 0) { txtConsigarCod.Text   = codigo; txtConsignarNom.Text  = nombre; }
            directorio.Close();
            directorio.Dispose();
        }
        private void btnEndosarA_Click(object sender, EventArgs e)
        {
            MantenimientoDirectorio.BuscaClien directorio = new MantenimientoDirectorio.BuscaClien();
            string cliente = "C";
            string codigo = "";
            string nombre = "";
            string conalias = "N";
            string connuevo = "N";
            codigo = directorio.IniBuscaCliOPro(ref cliente, ref nombre, ref conalias, ref connuevo);
            if ((codigo + "").Length > 0) { txtEndosarCod.Text = codigo; txtEndosarNom.Text = nombre; }
            directorio.Close();
            directorio.Dispose();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string codigo=txtEndosarCod.Text;
            string nombre=txtEndosarNom.Text;

            buscarDirectorio(ref codigo, ref nombre);

            txtEndosarCod.Text  = codigo;
            txtEndosarNom.Text  = nombre;
        }
        private void buscarDirectorio(ref string txtcodigo, ref string txtnombre)
        {
            MantenimientoDirectorio.BuscaClien directorio = new MantenimientoDirectorio.BuscaClien();
            string cliente = "C";
            string conalias = "N";
            string connuevo = "N";
            txtcodigo = directorio.IniBuscaCliOPro(ref cliente, ref txtnombre, ref conalias, ref connuevo);
            directorio.Close();
            directorio.Dispose();
        }

        private void btnBuscaTransportista_Click(object sender, EventArgs e)
        {
            string codigo = txtcedulaTransportista.Text ;
            string nombre = txtNomTransportadora.Text ;

            buscarDirectorio(ref codigo, ref nombre);

            txtcedulaTransportista.Text = codigo;
            txtNomTransportadora.Text = nombre;
        }

        private void txtValorFob_TextChanged(object sender, EventArgs e)
        {
            sumarFob();
        }
        private void txtFlete_TextChanged(object sender, EventArgs e)
        {
            sumarFob();
        }

        private void sumarFob()
        {
            double total = 0;
            total += Convert.ToDouble("0" + txtValorFob.Text);
            total += Convert.ToDouble("0" + txtFlete.Text);
            txtCYF.Text = string.Format("{0:#,#.00}",total);
        }

        private void CBuscador(ref TextBox lcod, string tipo)
        {
            string ElNombre = "";
            string ElCodigo = "";
            Syscod.ManSysnetClass  Buscod = new  Syscod.ManSysnetClass();
            ElCodigo = Buscod.BuscarReferencia (ref tipo, ref ElCodigo, ref ElNombre);
            lcod.Text = ElNombre;
            Buscod = null;
        }

        private void txtEmbarque_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2) { CBuscador(ref txtPuertoEmbarque, "PuertoEmbarque");}
        }

        private void txtDestino_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2) { CBuscador(ref txtPuertoDestino, "PuertoDestino"); }
        }

        private void txtCondicionesVenta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2) { CBuscador(ref txtCondicionesVenta, "CondicionVta"); }
        }

        private void txtViaEmbarque_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2) { CBuscador(ref txtViaEmbarque, "ViaEmbarque"); }
        }

        private void btnPaisOrigen_Click(object sender, EventArgs e)
        {
            Syscod.ManSysnetClass sys = new Syscod.ManSysnetClass();
            string tipoRef = "PAISES";
            string nom = "";
            string cod="";
            sys.BuscarReferencia(ref tipoRef, ref cod, ref nom);
            txtcodPaisOrgen.Text = cod;
            txtnomPaisOrigen.Text = nom;
        }

        private void btnPaisDestino_Click(object sender, EventArgs e)
        {
            Syscod.ManSysnetClass sys = new Syscod.ManSysnetClass();
            string tipoRef = "PAISES";
            string nom = "";
            string cod = "";
            sys.BuscarReferencia(ref tipoRef, ref cod, ref nom);
            txtcodPaisDestino.Text = cod;
            txtnomPaisDestino.Text = nom;
        }

        private void btnpaisAdquisicion_Click(object sender, EventArgs e)
        {
            Syscod.ManSysnetClass sys = new Syscod.ManSysnetClass();
            string tipoRef = "PAISES";
            string nom = "";
            string cod = "";
            sys.BuscarReferencia(ref tipoRef, ref cod, ref nom);
            txtcodPaisAdquisicion.Text = cod;
            txtnomPaisAdquisicion.Text = nom;
        }

        private void txtLugarEntrega_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2) { CBuscador(ref txtLugarEntrega, "LugarEntrega"); }
        }


    }
}
