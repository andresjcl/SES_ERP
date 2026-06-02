using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DattCom;

namespace MantDirecOnline
{
	public partial class BuscaAlias : Form
	{
        private string Seleccion2 = string.Empty;
        private string Seleccion = string.Empty;
        private string Selección3 = string.Empty;
        private string CodNom = string.Empty;
        private string ClioPro = string.Empty;
        private string CodigoRet = string.Empty;
        private Syscod.ManSysnetClass Buscod = new Syscod.ManSysnetClass();
        private string Alias_Renamed = string.Empty;
        private string Codigo = string.Empty;
        private int fila;
        public BuscaAlias()
		{
			InitializeComponent();
		}

        public string Buscando(ref string CodigoEmpresa)
        {
            Codigo = CodigoEmpresa;
            this.ShowDialog();
            return Alias_Renamed;
        }

        private void btnbuscar_Click(object sender, EventArgs e)
		{
			Retorna();
		}

        private void Retorna()
        {
            try
            {
                // Get cell values with null checks
                var row = ListNombre.Rows[fila];

                CodigoRet = row.Cells[0].Value?.ToString() ?? string.Empty;
                CodNom = row.Cells[1].Value?.ToString() ?? string.Empty;

                // Build Alias string with null checks
                Alias_Renamed = string.Join(",",
                    row.Cells[1].Value?.ToString() ?? string.Empty,
                    row.Cells[2].Value?.ToString() ?? string.Empty,
                    row.Cells[3].Value?.ToString() ?? string.Empty,
                    row.Cells[4].Value?.ToString() ?? string.Empty);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in Retorna: {ex.Message}", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

		private void btncancelarbusca_Click(object sender, EventArgs e)
		{
            this.Close();
		}

		private void BuscaAlias_Activated(object sender, EventArgs e)
		{
            try
            {
                if (!string.IsNullOrEmpty(TxtNombre.Text))
                {
                    if (ListNombre.RowCount <= 2)
                    {
                        TxtNombre.Focus();
                    }
                }
                else
                {
                    TxtNombre.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in BuscaAlias_Activated: {ex.Message}",
                              "Error",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
        }

		private void BuscaAlias_Load(object sender, EventArgs e)
		{
            try
            {
                LLenarLista();
            }
            catch (Exception ex)
            {
                // Optional: Add error logging or handling here
                // Example: MessageBox.Show("Error in LLenarLista: " + ex.Message);
            }
        }

        private void LLenarLista()
        {
            DataTable datt = new DataTable();

            using (SqlConnection Conectar = new SqlConnection(datosEmpresa.strConxAdcom))
            using (SqlDataAdapter dataAd = new SqlDataAdapter())
            {
                try
                {
                    string sqlaux = $"SELECT * FROM identificacionalias WHERE codigoempresa = @Codigo ORDER BY NombreAlias";

                    dataAd.SelectCommand = new SqlCommand(sqlaux, Conectar);
                    dataAd.SelectCommand.Parameters.AddWithValue("@Codigo", Codigo);

                    Conectar.Open();
                    dataAd.Fill(datt);

                    ListNombre.DataSource = datt;
                    ListNombre.ClearSelection();
                }
                catch (Exception ex)
                {
                    // Handle errors (log or show message)
                    MessageBox.Show($"Error loading data: {ex.Message}", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // You could also rethrow if needed: throw;
                }
            }
        }

		private void TxtNombre_KeyDown(object sender, KeyEventArgs e)
		{
            // Convert the key code and shift state
            short KeyCode = (short)e.KeyCode;
            short Shift = (short)((long)e.KeyData >> 16);  // Correct way to get shift state

            // Check for Enter key press
            if (e.KeyCode == Keys.Return)
            {
                LLenarLista();
            }
        }

        private void NombImpresion_Click(object sender, EventArgs e)
        {
            LLenarLista();
        }

        private void Option_Click(ref short Index)
        {
            try
            {
                switch (Index)
                {
                    case 0:
                        Seleccion2 = "";
                        break;
                    case 1:
                        Seleccion2 = " AND tipopersona = 'N' ";
                        break;
                    case 2:
                        Seleccion2 = " AND TIPOPERSONA = 'J' ";
                        break;
                    default:
                        // Handle unexpected index values if needed
                        break;
                }

                LLenarLista();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in Option_Click: {ex.Message}",
                              "Error",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
        }

        private void Option1_Click(ref short Index)
        {
            try
            {
                switch (Index)
                {
                    case 0:
                        Seleccion = "";
                        break;
                    case 1:
                        Seleccion = " AND ESCLIENTE <> 0 ";
                        break;
                    case 2:
                        Seleccion = " AND ESPROVEEDOR <> 0 ";
                        break;
                    case 3:
                        Seleccion = " AND ESBANCO <> 0 ";
                        break;
                    case 4:
                        Seleccion = " AND ESEMPLEADO <> 0 ";
                        break;
                    default:
                        // Optionally handle unexpected index values
                        Seleccion = "";
                        break;
                }

                LLenarLista();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in Option1_Click: {ex.Message}",
                              "Error",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
        }
    }
}
