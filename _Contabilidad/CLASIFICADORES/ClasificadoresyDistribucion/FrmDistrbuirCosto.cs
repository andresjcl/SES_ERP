using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static DaxClasificadores.ClasificadorMalla;

namespace DaxClasificadores
{
    public partial class FrmDistrbuirCosto : Form
    {

        Boolean ProcesaCostos = true;
        Boolean ProcesaUnidades = false;
        ClasificadoresMallas listaClasificadores = new ClasificadoresMallas();        
        string OrigenDatos = "";
        public FrmDistrbuirCosto(ClasificadoresMallas colClasificadores, string tipoClasificador, string origen, string tipoDirectorioBuscar, double ValorCosto, double CantidadUnidades = 0, Boolean SiCosto = true, Boolean SiUnidades = false)
        {

            InitializeComponent();
            txtUnidades.Text = CantidadUnidades.ToString();
            txtCosto.Text = ValorCosto.ToString();
            ProcesaCostos = SiCosto;
            ProcesaUnidades = SiUnidades;
            this.Text += " " + tipoClasificador;
            listaClasificadores = colClasificadores;
            IniciarValores();
            cargarMalla(origen, tipoDirectorioBuscar, tipoClasificador);

        }
        public ClasificadoresMallas iniciarDistribucionCostos()
        {
            this.ShowDialog();
            return listaClasificadores;
        }
        private void IniciarValores()
        {

            txtUnidades.Visible = ProcesaUnidades;
            txtCosto.Visible = ProcesaCostos;

            labCosto.Visible = ProcesaCostos;
            txtTotalCosto.Visible = ProcesaCostos;
            labTotalCosto.Visible = ProcesaCostos;
            btnDivideCosto.Visible = ProcesaCostos;
            btnRegistraCosto.Visible = ProcesaCostos;

            labunidades.Visible = ProcesaUnidades;
            txtTotUnidades.Visible = ProcesaUnidades;
            labTotalUnidades.Visible = ProcesaUnidades;
            btnDivideUnidad.Visible = ProcesaUnidades;
            btnBorrarUnidades.Visible = ProcesaUnidades;

        }
        private void cargarMalla(string origen, string tipoDirect, string tipoclasificador)
        {
            string ssql = "Select ";
            if (origen.ToUpper() == "DIRECTORIO")
            {
                ssql += " Codigo,NombreIMpresion as Nombre,0.00 as Unidades,0.00 as Costos from identificacion Where ";
                switch (tipoDirect.ToUpper())
                {
                    case "P":
                        ssql += " esproveedor = 1 ";
                        break;
                    case "C":
                        ssql += " escliente = 1 ";
                        break;
                    case "B":
                        ssql += " esbanco = 1 ";
                        break;
                    case "A":
                        ssql += " esasociado = 1 ";
                        break;
                    case "V":
                        ssql += " esvendedor = 1 ";
                        break;
                    case "E":
                        ssql += " esempleado = 1 ";
                        break;

                }
                ssql += " order by nombreimpresion";
            }
            else
            {
                ssql += " Abreviación as Codigo,Descripcion as Nombre,0.00 as Unidades,0.00 as Costos from syscod ";
                ssql += " Where abreviación <> '#' and tiporeferencia = '" + tipoclasificador + "'";
            }
            DataTable dt = DattCom.SqlDatos.leerTablaAdcom(ssql);
            Malla.DataSource = dt;
        }

        private void btnDivideCosto_Click(object sender, EventArgs e)
        {
            DividirValor("Costos", Convert.ToDouble(txtCosto.Text));
        }
        private void btnBorrarCostos_Click(object sender, EventArgs e)
        {
            BorrarValores("Costos");
        }
        private void DividirValor(string rubro, double Arepartir)
        {
            long Cuantos = 0;
            double Valor;
            double repartido = 0;

            Cuantos = Malla.SelectedRows.Count;

            if (Cuantos == 0)
            {
                MessageBox.Show("Para dividir un valor debe marcar al menos una fila", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Valor = Math.Round(Arepartir / Cuantos, 2);
            DataGridViewRow dgvRowLast = new DataGridViewRow();
            foreach (DataGridViewRow dgvRow in Malla.SelectedRows)
            {
                dgvRowLast = dgvRow;
                dgvRow.Cells[rubro].Value = Valor;
                repartido += Valor;
            }
            Valor = Arepartir - repartido;
            dgvRowLast.Cells[rubro].Value = Convert.ToDouble(dgvRowLast.Cells["Costos"].Value) + Valor;
            SumarMalla();
        }
        private void RegistrarValor(string rubro, double ArRegistrar)
        {
            long Cuantos = 0;

            Cuantos = Malla.SelectedRows.Count;

            if (Cuantos == 0)
            {
                MessageBox.Show("Para registrar un valor debe marcar al menos una fila", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            foreach (DataGridViewRow dgvRow in Malla.SelectedRows)
            {
                dgvRow.Cells[rubro].Value = ArRegistrar;
            }
            SumarMalla();
        }
        private void BorrarValores(string rubro)
        {
            foreach (DataGridViewRow dgvRow in Malla.Rows)
            {
                dgvRow.Cells[rubro].Value = 0;
            }
            SumarMalla();
        }
        private void SumarMalla()
        {
            double totalUnidades = 0;
            double totalCostos = 0;
            foreach (DataGridViewRow dgvRow in Malla.Rows)
            {
                totalCostos += Convert.ToDouble (dgvRow.Cells["Costos"].Value);
                totalUnidades += Convert.ToDouble(dgvRow.Cells["Unidades"].Value);
            }

        }

        private void btnRegistraCosto_Click(object sender, EventArgs e)
        {
            RegistrarValor("Costos", Convert.ToDouble(txtCosto.Text));
        }

        private void btnDivideUnidad_Click(object sender, EventArgs e)
        {
            DividirValor("Unidades", Convert.ToDouble(txtUnidades.Text));
        }

        private void chkRegistraCantidad_Click(object sender, EventArgs e)
        {
            RegistrarValor("Unidades", Convert.ToDouble(txtUnidades.Text));
        }

        private void btnaceptar_Click(object sender, EventArgs e)
        {
            Malla.EndEdit();
            SumarMalla();
            listaClasificadores = new ClasificadoresMallas();
            foreach (DataGridViewRow mrow in Malla.Rows)
            {
                double Costo = Convert.ToDouble("0" + mrow.Cells["Costos"].Value);
                if (Costo != 0)
                {
                    ClasificadorMalla  campos = new ClasificadorMalla();
                    campos.Costo = Costo;
                    campos.Cantidad = 0;
                    campos.CtaCtb="";
                    if (OrigenDatos == "directorio") campos.IdClas = mrow.Cells["Codigo"].Value.ToString(); else campos.IdClas = mrow.Cells["Nombre"].Value.ToString(); 
                    campos.Nombre = mrow.Cells["Nombre"].Value.ToString();
                    listaClasificadores.ColClasificadoresMalla.Add(campos);
                }
            }
            this.Close();
        }
        private void CargarRegistrosExistentes(object sender, EventArgs e)
        {
            listaClasificadores.ColClasificadoresMalla.Clear();
            foreach (DataGridViewRow mrow in Malla.Rows)
            {
                double Costo = Convert.ToDouble("0" + mrow.Cells["Costos"].Value);
                if (Costo != 0)
                {
                    ClasificadorMalla campos = new ClasificadorMalla();
                    campos.Costo = Costo;
                    campos.Cantidad = 0;
                    campos.CtaCtb = "";
                    if (OrigenDatos == "directorio") campos.IdClas = mrow.Cells["Codigo"].Value.ToString(); else mrow.Cells["Nombre"].Value.ToString();
                    campos.Nombre = mrow.Cells["Nombre"].Value.ToString();
                    listaClasificadores.ColClasificadoresMalla.Add(campos);
                }
            }
            this.Close();
        }
    }
}

