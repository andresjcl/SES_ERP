using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DattCom;
using Microsoft.VisualBasic.CompilerServices;

namespace directMnt
{
	internal partial class BuscaAlias
	{
		private string Seleccion2 = "";
		private string Seleccion = "";
		private string Selección3 = "";
		private string CodNom = "";
		private string ClioPro;
		private string CodigoRet;
		private Syscod.ManSysnetClass Buscod = new Syscod.ManSysnetClass();
		private string Alias_Renamed;
		private string Codigo;
		private int fila;

		public BuscaAlias()
		{
			InitializeComponent();
		}
		public string Buscando(ref string CodigoEmpresa)
		{
			string BuscandoRet = default;
			Codigo = CodigoEmpresa;
			ShowDialog();
			BuscandoRet = Alias_Renamed;
			return BuscandoRet;
		}

		private void btnbuscar_Click(object sender, EventArgs e)
		{
			Retorna();
		}

		private void btncancelarbusca_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void BuscaAlias_Activated(object sender, EventArgs e)
		{
			;
#error Cannot convert OnErrorResumeNextStatementSyntax - see comment for details
			/* Cannot convert OnErrorResumeNextStatementSyntax, CONVERSION ERROR: Conversion for OnErrorResumeNextStatement not implemented, please report this issue in 'On Error Resume Next' at character 1111


						Input:
								On Error Resume Next

						 */
			if (Operators.CompareString(TxtNombre.Text, "", false) > 0)
			{
				if (ListNombre.RowCount > 2)
				{
				}
				else
				{
					TxtNombre.Focus();
				}
			}
			else
			{
				TxtNombre.Focus();
			}
		}

		private void ListNombre_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			fila = e.RowIndex;
		}

		private void ListNombre_DoubleClick(object sender, EventArgs e)
		{
			Retorna();
		}

		private void ListNombre_KeyDown(object sender, KeyEventArgs e)
		{
			{
				var withBlock = ListNombre;
				if (e.KeyCode == Keys.Return)
				{
					Retorna();
				}
			}
		}

		private void BuscaAlias_Load(object sender, EventArgs e)
		{
			;
#error Cannot convert OnErrorResumeNextStatementSyntax - see comment for details
			/* Cannot convert OnErrorResumeNextStatementSyntax, CONVERSION ERROR: Conversion for OnErrorResumeNextStatement not implemented, please report this issue in 'On Error Resume Next' at character 2191


						Input:
								On Error Resume Next

						 */
			LLenarLista();
		}
		private void LLenarLista()
		{
			string sqlaux;
			sqlaux = "SELECT * From identificacionalias  WHERE codigoempresa ='" + Codigo + "' order by  NombreAlias ";
			var Conectar = new SqlConnection(datosEmpresa.strConxAdcom);
			var datt = new DataTable();
			var dataAd = new SqlDataAdapter(sqlaux, Conectar);
			Conectar.Open();
			dataAd.Fill(datt);
			ListNombre.DataSource = datt;
			ListNombre.ClearSelection();
			Conectar.Close();
			Conectar.Dispose();
			datt.Dispose();
			dataAd.Dispose();
			return;
			hayerrores:
			;

			// ControlaErrores
		}

		private void Retorna()
		{
			;
#error Cannot convert OnErrorResumeNextStatementSyntax - see comment for details
			/* Cannot convert OnErrorResumeNextStatementSyntax, CONVERSION ERROR: Conversion for OnErrorResumeNextStatement not implemented, please report this issue in 'On Error Resume Next' at character 3018


						Input:
								On Error Resume Next

						 */
			CodigoRet = ListNombre.Rows[fila].Cells[0].Value.ToString();
			CodNom = ListNombre.Rows[fila].Cells[1].Value.ToString();
			{
				var withBlock = ListNombre.Rows[fila];
				Alias_Renamed = withBlock.Cells[1].Value.ToString() + "," + withBlock.Cells[2].Value.ToString() + "," + withBlock.Cells[3].Value.ToString() + "," + withBlock.Cells[4].Value.ToString();
			}
			Close();
		}
		private void NombImpresion_Click()
		{
			LLenarLista();
		}

		private void Option_Click(ref short Index)
		{
			;
#error Cannot convert OnErrorResumeNextStatementSyntax - see comment for details
			/* Cannot convert OnErrorResumeNextStatementSyntax, CONVERSION ERROR: Conversion for OnErrorResumeNextStatement not implemented, please report this issue in 'On Error Resume Next' at character 3578


						Input:
								On Error Resume Next

						 */
			switch (Index)
			{
				case var @case when @case == 0:
					{
						Seleccion2 = "";
						break;
					}
				case var case1 when case1 == 1:
					{
						Seleccion2 = " AND tipopersona = 'N' ";
						break;
					}
				case var case2 when case2 == 2:
					{
						Seleccion2 = " AND TIPOPERSONA = 'J' ";
						break;
					}
			}
			LLenarLista();

		}

		private void Option1_Click(ref short Index)
		{
			;
#error Cannot convert OnErrorResumeNextStatementSyntax - see comment for details
			/* Cannot convert OnErrorResumeNextStatementSyntax, CONVERSION ERROR: Conversion for OnErrorResumeNextStatement not implemented, please report this issue in 'On Error Resume Next' at character 3980


						Input:
								On Error Resume Next

						 */
			switch (Index)
			{
				case var @case when @case == 0:
					{
						Seleccion = "";
						break;
					}
				case var case1 when case1 == 1:
					{
						Seleccion = " AND ESCLIENTE <> 0 ";
						break;
					}
				case var case2 when case2 == 2:
					{
						Seleccion = " AND ESPROVEEDOR <> 0 ";
						break;
					}
				case var case3 when case3 == 3:
					{
						Seleccion = " AND ESBANCO <> 0 ";
						break;
					}
				case var case4 when case4 == 4:
					{
						Seleccion = " AND ESEMPLEADO <> 0 ";
						break;
					}
			}
			LLenarLista();
		}

		private void TxtNombre_KeyDown(object sender, KeyEventArgs e)
		{
			short KeyCode = (short)e.KeyCode;
			short Shift = (short)((int)e.KeyData / 0x10000);
			if (KeyCode == (int)Keys.Return)
				LLenarLista();
		}

	}
}