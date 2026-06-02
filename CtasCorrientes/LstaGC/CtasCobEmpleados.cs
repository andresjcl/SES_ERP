using System;
using System.Windows.Forms;
using SysEmpDatt;
using Microsoft.Reporting.WinForms;

namespace adcCtasCorrientes
{
    public partial class CtasCobEmpleados : Form
    {
        private Boolean opcion = true;
        
public CtasCobEmpleados()
        {
            InitializeComponent();
            tFecha.Value = DateTime.Now;
        }

        //consulta las sucursales de la empresa actual
        public void consultarSucursales()
        {
            DaxCombobx.CargCmbBox combo = new DaxCombobx.CargCmbBox();
            combo.DaxCombosSuc(Convert.ToString(datosEmpresa.Emp_codigo), true, datosEmpresa.strConxDaxsys , ref cSucursal);
        }

        //consulta los vendedores de la empresa actual

        public void reporte()
        {
            Int16 conEmpleado = 1;
            String aux = "";
            String titulo = "Reporte de saldos de cuentas por cobrar y pagar";
            String ventas = "E";  // UTILIZA LA MISMA CONSULTA (procedimiento) DE CTAS POR COBRAR NORMAL Y SEGUN ESTE VALOR ESCOJE SOLO EMPLEADOS
            titulo = "Reporte de saldos de cuentas por cobrar empleados";
            

            Int16 anticipos = 1;
            Int16 garantias = 1;
            Int16 cheques = 2; 
            String Suc = ""; 
                if (cSucursal.Text != "Todas las sucursales") Suc = cSucursal.SelectedValue.ToString();
            String elVendedor = ""; 
            String Ciudad =""; 
            String zona = ""; 
            String TipoCli = ""; 
            String Pais = "";
            String Region = ""; 
            String Provincia = ""; 
            String Grupo1 = ""; 
            //    if (tGrupo1.Text.Length > 0) Grupo1 = tGrupo1.Text;
            String Grupo2 = ""; 
              //  if (tGrupo2.Text.Length > 0) Grupo2 = tGrupo2.Text;
            String Grupo3 = ""; 
                //if (tGrupo3.Text.Length > 0) Grupo3 = tGrupo3.Text;
            String AgrupacionPor ="";
            //if (adEmpleado.Checked )
            //{
            //    conEmpleado = 1;
            //}
            //if (agGrupo1.Checked)
            //{
            //    AgrupacionPor = "GR1"; 
            //    titulo += " ordenados por grupo-1 ";
            //}
            //if (agGrupo2.Checked)
            //{
            //    AgrupacionPor = "GR2";
            //    titulo += " ordenados por grupo-2 ";
            //}
            //if (agGrupo3.Checked)
            //{
            //    AgrupacionPor = "GR3";
            //    titulo += " ordenados por grupo-3 ";
            //}
            string soloVencidos = "0";
            if (adVencimiento.Checked) soloVencidos = "1";
            ReportDataSource rds = new ReportDataSource();
            String consulta = "exec ADC_CCTOT_INI '" + tFecha.Text + "','" + anticipos.ToString()  +"','" ;
                consulta += garantias.ToString()  +"','"+ventas+"','" + cheques.ToString()  +"','" + Suc  +"','" ;
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
            this.reportViewer1.LocalReport.ReportPath = datosEmpresa.pathAppl + "BinNet\\rep\\RepCtaCorrEmple.rdlc";

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
    }
}
