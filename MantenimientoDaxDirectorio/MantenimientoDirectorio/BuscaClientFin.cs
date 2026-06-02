using System;
using System.Data;
using System.Data.SqlClient;
using DattCom;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace directMnt
{
	public partial class BuscaClientFin
	{
		private string Seleccion2 = "";
		private string Seleccion = "";
		private string Selección3 = "";
		private string NombreRetorna = "";
		private string ClioPro = "";
		private string CodigoRetorna = "";
		private short Sw = 1;
		private string Alias_Renamed = "";
		private bool SinNuevo = false;
		private int fila;
		private bool esmedical;
		private string conHistoria;
		private string conTelefono;
		private bool Inicia = false;
		private string BuscaInicio = "";

		public BuscaClientFin()
		{
			InitializeComponent();
			Label3 = _Label3;
			_Label3.Name = "Label3";
		}
		private void btnbuscar_Click(object sender, EventArgs e)
		{
			Retorna();
		}

		private void btncancelarbusca_Click(object sender, EventArgs e)
		{
			Close();
		}
		private void ListNombre_CellEnter(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
		{
			fila = e.RowIndex;
		}

		private void ListNombre_DoubleClick(object sender, EventArgs e)
		{
			Retorna();
		}

		private void ListNombre_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			var PROG = new BuscaAlias();
			{
				var withBlock = ListNombre;
				if (e.KeyCode == System.Windows.Forms.Keys.Return)
				{
					Retorna();
				}
				else if (e.KeyCode == System.Windows.Forms.Keys.F3)
				{
					Alias_Renamed = PROG.Buscando(ref ListNombre.Rows[fila].Cells[0].Value.ToString());
					Retorna();
				}
			}
			PROG.Dispose();
		}

		public string IniBuscaCliFinal(string BuscarIni, string CodPrincipal, ref string NombrePrincipal, string ConAlias = "", string ConNuevo = "", bool medical = false, string histClin = "", string telf = "")
		{
			string IniBuscaCliFinalRet = default;
			Inicia = true;
			ClioPro = CodPrincipal;
			TxtNombre.Text = BuscarIni;
			SinNuevo = ConNuevo != "S";
			esmedical = medical;
			NomClienePrincipal.Text = CodPrincipal + " - " + NombrePrincipal;
			ShowDialog();
			IniBuscaCliFinalRet = CodigoRetorna;
			NombrePrincipal = NombreRetorna;
			ConAlias = Alias_Renamed;
			Close();
			Dispose();
			return IniBuscaCliFinalRet;
		}
		private void BuscaClien_Activated(object sender, EventArgs e)
		{
			;
#error Cannot convert OnErrorResumeNextStatementSyntax - see comment for details
			/* Cannot convert OnErrorResumeNextStatementSyntax, CONVERSION ERROR: Conversion for OnErrorResumeNextStatement not implemented, please report this issue in 'On Error Resume Next' at character 2820


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

		private void BuscaClienFin_Load(object sender, EventArgs e)
		{
			// On Error Resume Next
			Module1.Mainn();
			// Dim prog As New DaxLib.DaxLibMalla
			chkTodos.Checked = false;
			btNuevo.Visible = !SinNuevo;
			// Sw = 1
			// TxtNombre.Text = BuscaInicio
			Sw = 0;
			if (Inicia == true)
				LLenarLista();
		}
		private void LLenarLista()
		{
			if (Sw == 1)
				return;
			string sqlaux = "";
			string seleccion3 = "";
			string busca = "";
			string bConInicio = "";
			string TipoCliente = "F";
			if (ConInicio.Checked)
				bConInicio = "S";
			else
				bConInicio = "N";
			if (string.IsNullOrEmpty(Module1.Orden))
				Module1.Orden = "A";
			if (chkTodos.Checked)
				TipoCliente = "T";
			busca = TxtNombre.Text;
			try
			{
				// @clientePrincipal varchar(50)= ''
				// ,@apellido char(1) = 'A'
				// ,@connombreimpresion INTEGER = 0
				// ,@tipopersona char(1)= ''  
				// ,@relacion char(1)=''
				// ,@coninicio char(1)='N'
				// ,@busca varchar(256)= ''
				// ,@historiaclinica varchar(20)=''
				// ,@telefono varchar(20)=''

				sqlaux = "EXEC Adc_CNSALXF '" + ClioPro + "','" + Module1.Orden + "',0,'" + TipoCliente + "','','" + bConInicio + "','" + busca + "','',''";
				var dats = new DataTable();
				var dat = new SqlDataAdapter(sqlaux, datosEmpresa.strConxAdcom);
				dat.Fill(dats);
				ListNombre.DataSource = dats;
				ListNombre.Columns["Nombre"].Width = 300;
			}
			catch (Exception ee)
			{
				Interaction.MsgBox("excepción: llenarLista " + ee.Message);
			}
		}

		private void Retorna()
		{
			// On Error Resume Next
			if (ListNombre.CurrentCell is not null)
			{
				{
					var withBlock = ListNombre;
					// If .SelectedCells.Count > 0 Then
					fila = withBlock.CurrentCell.RowIndex;
					CodigoRetorna = Conversions.ToString(withBlock.Rows[fila].Cells[0].Value);
					NombreRetorna = Conversions.ToString(withBlock.Rows[fila].Cells[1].Value);
					// End If
				}
			}
			Dispose();
		}

		private void NombImpresion_CheckStateChanged(object sender, EventArgs e)
		{
			LLenarLista();
		}
		private void Options(int Index)
		{
			;
#error Cannot convert OnErrorResumeNextStatementSyntax - see comment for details
			/* Cannot convert OnErrorResumeNextStatementSyntax, CONVERSION ERROR: Conversion for OnErrorResumeNextStatement not implemented, please report this issue in 'On Error Resume Next' at character 5788


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
						Seleccion2 = "N";
						break;
					}
				case var case2 when case2 == 2:
					{
						Seleccion2 = "J";
						break;
					}
			}
			LLenarLista();

		}

		// Private Sub Option0_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
		// If sender.Checked Then Options(0)
		// End Sub

		// Private Sub Option1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Option1.CheckedChanged
		// If sender.Checked Then Options(1)
		// End Sub

		// Private Sub Option2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Option2.CheckedChanged
		// If sender.Checked Then Options(2)
		// End Sub
		private void Options1(int Index)
		{
			;
#error Cannot convert OnErrorResumeNextStatementSyntax - see comment for details
			/* Cannot convert OnErrorResumeNextStatementSyntax, CONVERSION ERROR: Conversion for OnErrorResumeNextStatement not implemented, please report this issue in 'On Error Resume Next' at character 6665


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
						Seleccion = "C";
						break;
					}
				case var case2 when case2 == 2:
					{
						Seleccion = "P";
						break;
					}
				case var case3 when case3 == 3:
					{
						Seleccion = "B";
						break;
					}
				case var case4 when case4 == 4:
					{
						Seleccion = "E";
						break;
					}
				case var case5 when case5 == 5:
					{
						Seleccion = "V";
						break;
					}
				case var case6 when case6 == 6:
					{
						Seleccion = "D";
						break;
					}
				case var case7 when case7 == 7:
					{
						Seleccion = "A";
						break;
					}
				case var case8 when case8 == 8:
					{
						Seleccion = "R";
						break;
					}
			}
			LLenarLista();
		}

		private void Option10_CheckedChanged(object sender, EventArgs e)
		{
			if (chkTodos.Checked)
				Options1(0);
		}


		private void TxtNombre_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			short KeyCode = (short)e.KeyCode;
			short Shift = (short)((int)e.KeyData / 0x10000);
			if (KeyCode == (int)System.Windows.Forms.Keys.Return)
				LLenarLista();
		}

		private void TxtNombre_TextChanged(object sender, EventArgs e)
		{
			if (Conversions.ToBoolean(ConInicio.CheckState))
				LLenarLista();
		}

		private void Button1_Click(object sender, EventArgs e)
		{
			LLenarLista();
		}
	}
}