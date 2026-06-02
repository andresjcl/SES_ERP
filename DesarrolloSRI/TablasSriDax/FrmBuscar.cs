using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using DattCom;
namespace IvaRett
{
    public partial class FrmBuscar : Form
    {
        public FrmBuscar()
        {
            InitializeComponent();
        }
        private SqlConnection conectar = new SqlConnection();
        private string TipoTabla = "";
        //private string strConxIvaret = "";
        //private string strConxAdcom = "";
        //private string codigo = "";
        private string codRetorno = "";
        private string nomRetorno = "";
        private double valorPorcentaje = 0;
        //private string nombre = "";
        //private string formato = "";
        //private string NombreBusca = "";
        //private string pathArchivo = "";
        private nombreTablas clasTab = new nombreTablas();
        private Int16 tipoTransac = 0;
        private void frmBuscar_Load(System.Object sender, System.EventArgs e)
        {
            try
            {
                llenarMalla();
                txtNombre.Focus();
            }
            // txtNombre.Select(0, 0)
            catch
            {
            }
        }
        public string Buscar( Int16 tipTransacion, string tablaSri, ref string nombre, ref double porcentaje, string inicio = "")
        {
            tipoTransac = tipTransacion;
            //strConxAdcom = strcon;
            //strConxIvaret = striva;
            TipoTabla = tablaSri;
            this.Text = " Busqueda codigo retención de " + tablaSri;
            if (inicio != "")
                txtNombre.Text = inicio;
            this.ShowDialog();
            nombre = nomRetorno;
            porcentaje = valorPorcentaje;
            return codRetorno;
        }
        private void llenarMalla( bool ConCambio = true, string strInicio = "")
        {
            
            string ssql = clasTab.armarConsulta(TipoTabla,DateTime.Now.ToShortDateString(), tipoTransac, 0, 0);
            try
            {
                Malla.DataSource = SqlDatos.leerTablaIvaret(ssql);
            }
            catch
            {
                Malla.DataSource = null;
            }
        }

        //private string Camponombre(string cons)
        //{
        //    int i = cons.ToUpper().IndexOf("ORDER BY");
        //    if (i > -1)
        //        cons = cons.Substring(0, i - 1);
        //    string aux;
        //    aux = "select * from (" + cons + ") r1 where [" + NombreBusca + "] like '%" + txtNombre.Text + "%' order by [" + NombreBusca + "]";
        //    return aux;
        //}

        private void txtAbrevia_TextChanged(System.Object sender, System.EventArgs e)
        {
            llenarMalla();
        }


        private void btnCancelar_Click(System.Object sender, System.EventArgs e)
        {
            codRetorno = "";
            this.Dispose();
        }

        private void btnSalir_Click(System.Object sender, System.EventArgs e)
        {
            codRetorno = "";
            this.Dispose();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Malla.SelectedCells.Count > 0)  Malla_DoubleClick(sender, e);
            else  MessageBox.Show("Es necesario que seleccione algun registro");       
        }

        private void Malla_DoubleClick(object sender, EventArgs e)
        {
            try{
                if (Malla.CurrentCell != null)
                {
                    codRetorno = Malla.Rows[Malla.CurrentCell.RowIndex].Cells["Código"].Value.ToString();
                    nomRetorno = Malla.Rows[Malla.CurrentCell.RowIndex].Cells["Descripción"].Value.ToString();
                    valorPorcentaje = Convert.ToDouble(Malla.Rows[Malla.CurrentCell.RowIndex].Cells["porcentaje"].Value);
                }
                else 
                {
                    codRetorno = "";
                    nomRetorno = "";
                }
                Close();
            }
            catch { }
        }
    }

}
