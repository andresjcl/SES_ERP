using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace daxSri104
{
    public partial class frmDax104 : Form
    {
        public double tarifaIva = 0;
        Boolean saltar = true;
        public frmDax104(string ruc,string nomEmp)
        {
            InitializeComponent();
            formaMalls.armarmalla400(malla400);
            formaMalls.armarmalla500(malla500);
            formaMalls.armarmalla600(malla600);
            formaMalls.armarmalla700(malla700);
            llenarAños();
            SSTab1.SelectedIndex = 0;
            LbRuc.Text = ruc;
            LbNom.Text = nomEmp;
            saltar = true;
        }

        private void llenarAños()
        {
            int añoIni = DateTime.Now.Year - 10;
            for (int i = añoIni; i < añoIni + 20; i++)
            {
                cmbAños.Items.Add(i.ToString());
            }
            cmbAños.SelectedIndex = 10;

            cmbMeses.SelectedIndex = (DateTime.Now.Month - 1);
        }

        private void malla400_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            calcularCeldas();
        }
        private void malla500_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            calcularCeldas();
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            DaxLib.DaxLibBases dlib = new DaxLib.DaxLibBases();
            dlib.TipoBase = "10";
            cargaValor.CargarValores400(this, dlib.StrAdcom());
            cargaValor.CargarValores500(this, dlib.StrAdcom());
            cargaValor.CargarValores600(this, dlib.StrAdcom());
            cargaValor.CargarValores700(this, dlib.StrAdcom());
            calcularCeldas();
        }
        private void calcularCeldas()
        {
            calcValor.calculos400(this, tarifaIva);
            calcValor.calculos500(this);
            calcValor.calculos600(this);
            calcValor.calculos700(this);
            calcValor.calculos900(this);
        }

        private void Txt480_Validated(object sender, EventArgs e)
        {
            if(saltar==false) calcularCeldas();
        }

        private void btnGenerarXML_Click(object sender, EventArgs e)
        {
            genXml.generarXml(this);
        }
    }
}
