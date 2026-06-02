using System;
using System.Windows.Forms;
using Buscar;
using DattCom;
using Microsoft.Reporting.WinForms;

namespace CtasCorrientes
{
    public partial class FrmListaCtasCorrientes : Form
    {
        private Boolean opcion = true;
        
public FrmListaCtasCorrientes()
        {
            InitializeComponent();
            tFecha.Value = DateTime.Now;
        }

        // metodo que recibe la consulta y  la conexion para ejecutar en la base de datos
        //public void consultarDato(String consulta, SqlConnection con)
        //{
        //    try
        //    {
        //        misqlDa = new SqlDataAdapter(consulta, con);
        //        dato = new DataSet();
        //        valor = new BindingSource();
        //        misqlDa.Fill(dato, "lista");
        //        valor.DataSource = dato;
        //        valor.DataMember = "lista";
        //    }
        //    catch { }
        //}

        //consulta las sucursales de la empresa actual
        public void consultarSucursales()
        {
            DaxCombobx.CargCmbBox combo = new DaxCombobx.CargCmbBox();
            combo.DaxCombosSuc(Convert.ToString(datosEmpresa.Emp_codigo), true, datosEmpresa.strConIniSis , ref cSucursal);
        }

        //consulta los vendedores de la empresa actual
        public void consultarVendedores()
        {
            DaxCombobx.CargCmbBox prog = new DaxCombobx.CargCmbBox() ;
            prog.DaxCombosVend(datosEmpresa.strConxAdcom, ref cVendedor, true);
            //String consulta = "select Nombres + Apellidos as Nombres from Identificacion where EsVendedor ='True'";
            //consultarDato(consulta, adcom);
            //comboBox("Todos", "Nombres", cVendedor);
        }

        public void ciudades()
        {
            try
            {
                String cad = "select Art_codigo, Art_nombre from AdcArt order by Art_codigo";
                Buscar.frmBuscar buscar = new frmBuscar();
                String codigo = (String)buscar.Buscar(datosEmpresa.strConxAdcom, cad, "", "", "", "");
                tRegion.Text = codigo;
            }
            catch { }
        }

        // método que asigna una lista, a un combo  específico
        // columna, nombre de la columna de la tabla que vamos a sacar los datos
        // combo, nombre del comboBox
        //public void comboBox(String texto, String columna, ComboBox combo)
        //{
        //    miTabla = dato.Tables[0];
        //    DataRow fila = miTabla.NewRow();
        //    fila[0] = texto;
        //    miTabla.Rows.Add(fila);
        //    if (dato.Tables[0].Rows.Count > 0)
        //    {
        //        combo.DataSource = dato.Tables[0].DefaultView;
        //        combo.DisplayMember = columna;
        //    }
        //}

        public void reporte()
        {
            Int16 conEmpleado = 0;
            String aux;
            String titulo = "Reporte de saldos de cuentas por cobrar y pagar";
            String ventas = "";
            
            if (!(tCuentasPagar.Checked && tCuentasCobrar.Checked))
            {
                if (tCuentasPagar.Checked) {ventas = "P"; titulo = "Reporte de saldos de cuentas por pagar";}
                if (tCuentasCobrar.Checked) {ventas = "C"; titulo = "Reporte de saldos de cuentas por cobrar";}
            }

            Int16 anticipos = 0;
                if (adAnticipos.Checked)  anticipos = 1;
            Int16 garantias = 0;
                if (adGarantias.Checked)  garantias = 1; 
            Int16 cheques = 0; 
                if (adDocumentosFechaVencidos.Checked) cheques = 1;
                if (adDocumentosFechaVencidosTodos.Checked) cheques = 2;
            String Suc = ""; 
                if (cSucursal.Text != "Todas las sucursales") Suc = cSucursal.SelectedValue.ToString();
            String elVendedor = ""; 
                if (cVendedor.Text != "Todos") elVendedor = cVendedor.SelectedValue.ToString()   ;
            String Ciudad =""; 
                if (tCiudad.Text.Length > 0) Ciudad = tCiudad.Text;
            String zona = ""; 
                if (tZonaVen.Text.Length > 0) zona = tZonaVen.Text;
            String TipoCli = ""; 
                if (tCliente.Text.Length > 0) TipoCli = tCliente.Text;
            String Pais = "";
            String Region = ""; 
                if (tRegion.Text.Length > 0) Region = tRegion.Text;
            String Provincia = ""; 
                if (tProvincia.Text.Length > 0) Provincia = tProvincia.Text;
            String Grupo1 = ""; 
                if (tGrupo1.Text.Length > 0) Grupo1 = tGrupo1.Text;
            String Grupo2 = ""; 
                if (tGrupo2.Text.Length > 0) Grupo2 = tGrupo2.Text;
            String Grupo3 = ""; 
                if (tGrupo3.Text.Length > 0) Grupo3 = tGrupo3.Text;
            String AgrupacionPor ="";
            if (adEmpleado.Checked )
            {
                conEmpleado = 1;
            }
            if (agVendedor.Checked) 
            {
                AgrupacionPor = "VEN";
                titulo += " agrupado por vendedor ";
            }
            if (agZonaVentas.Checked)
            { 
                AgrupacionPor = "ZON"; 
                titulo += " agrupado por Zonas "; 
            }
            if (agRegion.Checked)
            {
                AgrupacionPor = "REG"; 
                titulo += " agrupado por regiones ";
            }
            if (agProvincia.Checked)
            {
                AgrupacionPor = "PRO"; 
                titulo += " agrupado por provincias ";
            }
            if (agCiudad.Checked)
            {
                AgrupacionPor = "CIU";
                titulo += " agrupado por ciudades ";
            }
            if (agTipoCliente.Checked)
            {
                AgrupacionPor = "TIP";
                titulo += " agrupado por tipos ";
            }
            if (agGrupo1.Checked)
            {
                AgrupacionPor = "GR1"; 
                titulo += " ordenados por grupo-1 ";
            }
            if (agGrupo2.Checked)
            {
                AgrupacionPor = "GR2";
                titulo += " ordenados por grupo-2 ";
            }
            if (agGrupo3.Checked)
            {
                AgrupacionPor = "GR3";
                titulo += " ordenados por grupo-3 ";
            }
            string soloVencidos = "0";
            if (adVencimiento.Checked) soloVencidos = "1";
            ReportDataSource rds = new ReportDataSource();
            String consulta = "exec ADC_CCTOT_INI '" + tFecha.Text + "','" + anticipos.ToString()  +"','" ;
                consulta += garantias.ToString()  +"','" + ventas  +"','" + cheques.ToString()  +"','" + Suc  +"','" ;
                consulta += elVendedor.ToString()   +"','" + Ciudad  +"','" + zona  +"','" + TipoCli  +"','" + Pais  +"','" + Region  +"','" ;
                consulta += Provincia  +"','" + Grupo1  +"','" + Grupo2  +"','" + Grupo3  +"','" + AgrupacionPor  +"'," + conEmpleado + "," + soloVencidos ;
                titulo += " al: " + tFecha.Text;
           
            ReportParameter hasta = new ReportParameter("hasta", titulo);
            ReportParameter nombreEmpresa = new ReportParameter("nombreEmpresa", datosEmpresa.Emp_Nombre);

            aux = "N";
            if (cheSoloTotal.Checked ) aux= "S" ;
            ReportParameter solototales = new ReportParameter("solototales",aux);

            aux = "N";
            if (cheDetDoc.Checked) aux = "S";
            ReportParameter nodocumentos = new ReportParameter("nodocumentos", aux);

            aux = "N";
            if (chkDiasVencidos.Checked) aux = "S";
            ReportParameter DiasVencidos = new ReportParameter("DiasVencidos", aux);

            aux = "N";
            if (chkValorInicial.Checked) aux = "S";
            ReportParameter Valordocumento = new ReportParameter("Valordocumento", aux);

            aux = "N";
            if (chkValorVencido.Checked) aux = "S";
            ReportParameter ValorVencido = new ReportParameter("ValorVencido", aux);

            aux = "N";
            if (chkFechaVencimiento.Checked) aux = "S";
            ReportParameter FechaVence = new ReportParameter("FechaVence", aux);

            aux = "N";
            if (chUnaCuentaPorHoja.Checked) aux = "S";
            ReportParameter HojaPorcuenta = new ReportParameter("HojaPorcuenta", aux);

            rds.Name = "DataSet1";
            rds.Value = SqlDatos.leerTablaAdcom (consulta);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.LocalReport.ReportPath = datosEmpresa.pathAppl + "Rep\\RepCtaCorr.rdlc";

            reportViewer1.LocalReport.SetParameters(hasta);
            reportViewer1.LocalReport.SetParameters(nombreEmpresa);
            reportViewer1.LocalReport.SetParameters(solototales);
            reportViewer1.LocalReport.SetParameters(nodocumentos);
            reportViewer1.LocalReport.SetParameters(Valordocumento );
            reportViewer1.LocalReport.SetParameters(FechaVence);
            reportViewer1.LocalReport.SetParameters(HojaPorcuenta);
            reportViewer1.LocalReport.SetParameters(ValorVencido);
            reportViewer1.LocalReport.SetParameters(DiasVencidos);

            this.reportViewer1.RefreshReport();
        }

        //public DataSet CalcularDataSet(String consulta)
        //{
        //    SqlDataAdapter misqlDa = new SqlDataAdapter(consulta, adcom);
        //    DataSet dato = new DataSet();
        //    misqlDa.Fill(dato);
        //    return dato;
        //}

        private void salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void opciones_Click(object sender, EventArgs e)
        {
            if (opcion == true)
            {
                contenedor.Panel1Collapsed = true;
                opcion = false;
            }
            else
            {
                contenedor.Panel1Collapsed = false;
                opcion = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            consultarSucursales();
            int index1 = cSucursal.FindString("Todas las sucursales");
            cSucursal.SelectedIndex = index1;
            consultarVendedores();
            int index2 = cVendedor.FindString("Todos");
            cVendedor.SelectedIndex = index2;
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Activate();
            }
            else
            {
                contenedor.SplitterDistance = 310;
            }
        }

        private void imprimir_Click(object sender, EventArgs e)
        {
            reporte();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

    }

}
