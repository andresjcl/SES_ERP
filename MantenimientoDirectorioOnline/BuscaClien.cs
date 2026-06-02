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
using MantDirecOnline;

namespace MantenimientoDirectorioOnline
{
	public partial class BuscaClien : Form
	{
        string Seleccion2 = "";
        string Seleccion = "";
        string Selección3 = "";
        string CodNom = "";
        string ClioPro = "";
        string CodigoRet = "";
        short Sw = 1;
        string Alias_Renamed = "";  // Note: 'Alias' is a reserved keyword in C#
        bool SinNuevo = false;
        int fila;
        bool esmedical;
        string conHistoria;
        string conTelefono;
        bool Inicia = false;
        double SueldoAnterior = 0;
        DateTime IngresoAnterior;
        DateTime SalidaAnterior;

        
        public BuscaClien()
		{
			InitializeComponent();
		}

		private void BuscaClien_Load(object sender, EventArgs e)
		{
            try
            {
                Mainn();
                // var prog = new daaxLib.DaxLibMalla();
                chkTodos.Checked = false;
                chkCliente.Checked = false;
                chkProveedor.Checked = false;
                chkFinanciera.Checked = false;
                chkEmpleado.Checked = false;
                chkVendedor.Checked = false;

                if (!string.IsNullOrEmpty(ClioPro) && ClioPro != "T")
                {
                    switch (ClioPro)
                    {
                        case "C":
                            chkCliente.Checked = true;
                            break;
                        case "P":
                            chkProveedor.Checked = true;
                            break;
                        case "F":
                            chkFinanciera.Checked = true;
                            break;
                        case "E":
                            chkEmpleado.Checked = true;
                            break;
                        case "V":
                            chkVendedor.Checked = true;
                            break;
                        case "O":
                            chkOperador.Checked = true;
                            break;
                        case "D":
                            chkMedico.Checked = true;
                            break;
                        default:
                            chkTodos.Checked = true;
                            break;
                    }
                }
                btNuevo.Visible = !(SinNuevo);
                Sw = 1;
                TxtNombre.Text = CodNom;
                TextBox1.Text = conHistoria;
                TextBox2.Text = conTelefono;
                Sw = 0;
                if (Inicia)
                {
                    LLenarLista();
                }
            }
            catch
            {
                // This is the equivalent of "On Error Resume Next"
                // In C#, empty catch blocks are generally discouraged
                // Consider logging the exception or handling it appropriately
            }
        }

        private void LLenarLista()
        {
            if (Sw == 1) return;

            try
            {
                string bConInicio = ConInicio.Checked ? "S" : "N";
                if (Module1.Orden == null) Module1.Orden = "A";
                string busca = TxtNombre.Text;

                // Using parameterized query to prevent SQL injection
                string sqlaux = "EXEC Adc_CNSALX25 @Orden, @NombImpresion, @Seleccion2, @Seleccion, @bConInicio, @busca, @Historia, @Telefono";

                using (var conectar = new SqlConnection(datosEmpresa.strConxAdcom))
                using (var cmd = new SqlCommand(sqlaux, conectar))
                {
                    cmd.Parameters.AddWithValue("@Orden", Module1.Orden);
                    cmd.Parameters.AddWithValue("@NombImpresion", NombImpresion.CheckState);
                    cmd.Parameters.AddWithValue("@Seleccion2", Seleccion2 ?? string.Empty);
                    cmd.Parameters.AddWithValue("@Seleccion", Seleccion ?? string.Empty);
                    cmd.Parameters.AddWithValue("@bConInicio", bConInicio);
                    cmd.Parameters.AddWithValue("@busca", busca ?? string.Empty);
                    cmd.Parameters.AddWithValue("@Historia", TextBox1.Text ?? string.Empty);
                    cmd.Parameters.AddWithValue("@Telefono", TextBox2.Text ?? string.Empty);

                    var dats = new DataSet();
                    using (var dat = new SqlDataAdapter(cmd))
                    {
                        conectar.Open();
                        dat.Fill(dats, "Datos");

                        ListNombre.DataSource = dats.Tables["Datos"];
                        ListNombre.ClearSelection();

                        if (ListNombre.Columns.Contains("Nombre"))
                        {
                            ListNombre.Columns["Nombre"].Width = 300;
                        }
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show($"Error en LLenarLista: {ee.Message}", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Mainn()
        {
            try
            {
                // If datosEmpresa.strConxAdcom == "" Then varbleComun.cargar.iniciar("", "")
                if (string.IsNullOrWhiteSpace(datosEmpresa.strConxAdcom))
                    return;
            }
            catch (Exception ee)
            {
                MessageBox.Show("excepción mainn: " + ee.Message);
            }
            Emp.CargarValores();
        }

        public string IniBuscaCliOPro(string CliOProv,string CodigoNombre,string ConAlias = "",string ConNuevo = "",bool medical = false, string histClin = "",string telf = "")
        {
            try
            {
                Inicia = true;
                ClioPro = CliOProv;
                CodNom = CodigoNombre;
                SinNuevo = (ConNuevo != "S");
                Label1.Visible = medical;
                TextBox1.Visible = medical;
                esmedical = medical;
                conHistoria = histClin;
                conTelefono = telf;

                this.ShowDialog();

                string result = CodigoRet;
                CodigoNombre = CodNom;
                ConAlias = Alias_Renamed;

                this.Close();
                this.Dispose();

                return result;
            }
            catch (Exception ex)
            {
                // Consider adding error handling/logging
                throw;
            }
        }

		private void btncancelarbusca_Click(object sender, EventArgs e)
		{
            this.Close();
		}

		private void btnbuscar_Click(object sender, EventArgs e)
		{
            Retorna();

        }

        private void Retorna()
        {
            try
            {
                if (ListNombre?.CurrentCell != null)
                {
                    int rowIndex = ListNombre.CurrentCell.RowIndex;
                    if (rowIndex >= 0 && rowIndex < ListNombre.Rows.Count)
                    {
                        CodigoRet = ListNombre.Rows[rowIndex].Cells[0]?.Value?.ToString() ?? string.Empty;
                        CodNom = ListNombre.Rows[rowIndex].Cells[1]?.Value?.ToString() ?? string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                // Consider logging the error
                MessageBox.Show($"Error in Retorna: {ex.Message}");
            }
            finally
            {
                this.Dispose();
            }
        }

		private void ListNombre_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
            fila = e.RowIndex;

        }

		private void ListNombre_DoubleClick(object sender, EventArgs e)
		{
            Retorna();
        }

		private void ListNombre_KeyDown(object sender, KeyEventArgs e)
		{
            using (BuscaAlias PROG = new BuscaAlias())
            {
                if (e.KeyCode == Keys.Return)
                {
                    Retorna();
                }
                else if (e.KeyCode == Keys.F3)
                {
                    // Added null check for safety
                    var cellValue = ListNombre.Rows[fila].Cells[0].Value;
                    //Alias_Renamed = PROG.Buscando(cellValue?.ToString() ?? string.Empty);

                    string tempValue = cellValue?.ToString() ?? string.Empty;
                    Alias_Renamed = PROG.Buscando(ref tempValue);
                    cellValue = tempValue;

                    Retorna();
                }
            }
        }
	}
}
