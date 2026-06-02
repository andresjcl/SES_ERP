using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Buscar
{
	public partial class buscarDet : Form
	{
		public buscarDet()
		{
			InitializeComponent();
		}
		private string cadena = "";
		private string conecStr = "";
		private string codigo = "";
		private string codRetorno = "";
		private string nombre = "";
		private string formato = "";
		private string NombreBusca = "";
		private string CodigoBusca = "";
		private void _btnAceptar_Click(object sender, EventArgs e)
		{
			if (gridDatos.SelectedCells.Count > 0)
			{
				gridDatos_DoubleClick(sender, e);
			}
			else
			{
				MessageBox.Show("Es necesario que seleccione un registro");
			}
		}

		private void gridDatos_DoubleClick(object sender, EventArgs e)
		{
			Int32 fila;
			try
			{
				fila = gridDatos.CurrentCell.RowIndex;
				//codRetorno = gridDatos.Rows[fila].Cells[0].Value.ToString();
				codRetorno = gridDatos.Rows[fila].Cells[4].Value.ToString();
				
			}
			catch
			{
			}

			Close();
		}

		public string Buscar(string strcon, string cad, string campoCod, string campoNom, string formatoGrid, string titulo, string inicio = "")
		{
			conecStr = strcon;
			cadena = cad;
			codigo = campoCod;
			nombre = campoNom;
			NombreBusca = campoNom;
			CodigoBusca = campoCod;
			formato = formatoGrid;
			//lblTitulo.Text = titulo;
			Text = "BUSCADOR DE " + titulo;
			if (inicio.Length > 0) txtNombre.Text = inicio;
			ShowDialog();
			return codRetorno;
		}

		private void _btnActualiza_Click(object sender, EventArgs e)
		{
			consulta();
		}

		private void consulta()
		{
			var dats = new DataTable();
			var datAd = new SqlDataAdapter();
			try
			{
				datAd = new SqlDataAdapter(Camponombre(cadena), conecStr);
				datAd.Fill(dats);
			}
			catch
			{
				datAd = new SqlDataAdapter(cadena, conecStr);
				datAd.Fill(dats);
			}

			if (dats == null)
			{
				MessageBox.Show("No se puede procesar la consulta \n" + cadena);
				return;
			}

			if (dats.Rows.Count > 0)
			{
				{
					gridDatos.DataSource = dats;
					gridDatos.ClearSelection();
				}
			}
			else
			{
				MessageBox.Show("No existen datos para escojer");
				this.Close();
				this.Dispose();
			}

			dats.Dispose();
			datAd.Dispose();
		}

		private string Camponombre(string cons)
		{
			int i = cons.ToUpper().IndexOf("ORDER BY");
			if (i >= 0)
			{
				cons = cons.Substring(0, i - 1);
			}

			if (chkInicial.Checked)
			{
				string cad = "select * from (" + cons + ") r1 where ([" + NombreBusca + "] like '" + txtNombre.Text + "%'  AND [" + CodigoBusca + "] like '" + txtAbrevia.Text + "%') order by [" + NombreBusca + "]";
				return cad;
			}
			else
			{
				return "select * from (" + cons + ") r1 where ([" + NombreBusca + "] like '%" + txtNombre.Text + "%'  and [" + CodigoBusca + "] like '%" + txtAbrevia.Text + "%') order by [" + NombreBusca + "]";
			}
		}

		private void txtNombre_TextChanged(object sender, EventArgs e)
		{
			consulta();
		}

		private void txtAbrevia_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				consulta();
			}
		}

		private void _btnSalir_Click(object sender, EventArgs e)
		{
			codRetorno = "";
			Dispose();
		}

		private void _btnCancelar_Click(object sender, EventArgs e)
		{
			codRetorno = "";
			Dispose();
		}
	}
}
