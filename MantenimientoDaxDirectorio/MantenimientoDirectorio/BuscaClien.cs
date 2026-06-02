using System;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using DattCom;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace directMnt
{
	public partial class BuscaClien : System.Windows.Forms.Form
	{
		private string Seleccion2 = "";
		private string Seleccion = "";
		private string Selección3 = "";
		private string CodNom = "";
		private string ClioPro = "";
		private string CodigoRet = "";
		private short Sw = 1;
		private string Alias_Renamed = "";
		private bool SinNuevo = false;
		private int fila;
		private bool esmedical;
		private string conHistoria;
		private string conTelefono;
		private bool Inicia = false;
		private double SueldoAnterior = 0d;
		private DateTime IngresoAnterior;
		private DateTime SalidaAnterior;

		public BuscaClien()
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

		private void btNuevo_Click(object sender, EventArgs e)
		{
			var PROG = new CreaCliAlex();
			string elcodigo = "";
			// PROG.ShowDialog()
			CodigoRet = PROG.IniCrearAlex(ref ClioPro, ref elcodigo);
			PROG.Dispose();
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

		public string IniBuscaCliOPro(ref string CliOProv, ref string CodigoNombre, [Optional, DefaultParameterValue("")] ref string ConAlias, [Optional, DefaultParameterValue("")] ref string ConNuevo, bool medical = false, string histClin = "", string telf = "")
		{
			string IniBuscaCliOProRet = default;
			Inicia = true;
			ClioPro = CliOProv;
			CodNom = CodigoNombre;
			SinNuevo = ConNuevo != "S";
			Label1.Visible = medical;
			TextBox1.Visible = medical;
			esmedical = medical;
			ShowDialog();
			IniBuscaCliOProRet = CodigoRet;
			CodigoNombre = CodNom;
			ConAlias = Alias_Renamed;
			Close();
			Dispose();
			return IniBuscaCliOProRet;
		}
		public string IniBuscaCliOPro(string CliOProv, bool medical, ref string CodigoNombre)
		{
			string IniBuscaCliOProRet = default;
			Inicia = true;
			ClioPro = CliOProv;
			CodNom = CodigoNombre;
			SinNuevo = false;
			Label1.Visible = medical;
			TextBox1.Visible = medical;
			esmedical = medical;
			ShowDialog();
			IniBuscaCliOProRet = CodigoRet;
			CodigoNombre = CodNom;
			Close();
			Dispose();
			return IniBuscaCliOProRet;
		}

		public string IniBuscaCliOProVacio(ref string CliOProv, ref string CodigoNombre, [Optional, DefaultParameterValue("")] ref string ConAlias, [Optional, DefaultParameterValue("")] ref string ConNuevo, bool medical = false, string histClin = "", string telf = "")
		{
			string IniBuscaCliOProVacioRet = default;
			Inicia = false;
			ClioPro = CliOProv;
			CodNom = CodigoNombre;
			SinNuevo = ConNuevo != "S";
			Label1.Visible = medical;
			TextBox1.Visible = medical;
			esmedical = medical;
			ShowDialog();
			IniBuscaCliOProVacioRet = CodigoRet;
			CodigoNombre = CodNom;
			ConAlias = Alias_Renamed;
			Close();
			Dispose();
			return IniBuscaCliOProVacioRet;
		}

		private void BuscaClien_Activated(object sender, EventArgs e)
		{
			;
#error Cannot convert OnErrorResumeNextStatementSyntax - see comment for details
			/* Cannot convert OnErrorResumeNextStatementSyntax, CONVERSION ERROR: Conversion for OnErrorResumeNextStatement not implemented, please report this issue in 'On Error Resume Next' at character 4509


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

		private void BuscaClien_Load(object sender, EventArgs e)
		{
			// On Error Resume Next
			Module1.Mainn();
			// Dim prog As New daaxLib.DaxLibMalla
			chkTodos.Checked = false;
			chkCliente.Checked = false;
			chkProveedor.Checked = false;
			chkFinanciera.Checked = false;
			chkEmpleado.Checked = false;
			chkVendedor.Checked = false;

			if (Operators.CompareString(ClioPro, "", false) > 0 & ClioPro != "T")
			{
				switch (ClioPro ?? "")
				{
					case "C":
						{
							chkCliente.Checked = true;
							break;
						}
					case "P":
						{
							chkProveedor.Checked = true;
							break;
						}
					case "F":
						{
							chkFinanciera.Checked = true;
							break;
						}
					case "E":
						{
							chkEmpleado.Checked = true;
							break;
						}
					case "V":
						{
							chkVendedor.Checked = true;
							break;
						}
					case "O":
						{
							chkOperador.Checked = true;
							break;
						}
					case "D":
						{
							chkMedico.Checked = true;
							break;
						}

					default:
						{
							chkTodos.Checked = true;
							break;
						}
				}
			}
			btNuevo.Visible = !SinNuevo;
			Sw = 1;
			TxtNombre.Text = CodNom;
			TextBox1.Text = conHistoria;
			TextBox2.Text = conTelefono;
			Sw = 0;
			if (Inicia == true)
				LLenarLista();
		}

		private void LLenarLista()
		{
			if (Sw == 1)
				return;
			string sqlaux;
			string seleccion3;
			var Buscod = new Syscod.ManSysnetClass();
			string busca;
			string bConInicio;
			if (ConInicio.Checked)
				bConInicio = "S";
			else
				bConInicio = "N";
			if (string.IsNullOrEmpty(Module1.Orden))
				Module1.Orden = "A";
			seleccion3 = "";
			busca = TxtNombre.Text;
			try
			{
				sqlaux = "EXEC Adc_CNSALX '" + Module1.Orden + "'," + ((int)NombImpresion.CheckState).ToString() + ",'" + Seleccion2 + "','" + Seleccion + "','" + bConInicio + "','" + busca + "','" + TextBox1.Text + "','" + TextBox2.Text + "'";
				var conectar = new SqlConnection(datosEmpresa.strConxAdcom);
				var dats = new DataSet();
				var dat = new SqlDataAdapter(sqlaux, conectar);
				conectar.Open();
				dat.Fill(dats, "Datos");
				ListNombre.DataSource = dats.Tables["Datos"];
				ListNombre.ClearSelection();
				ListNombre.Columns["Nombre"].Width = 300;
			}
			catch (Exception ee)
			{
				Interaction.MsgBox("excepción:llenarLista " + ee.Message);
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
					CodigoRet = Conversions.ToString(withBlock.Rows[fila].Cells[0].Value);
					CodNom = Conversions.ToString(withBlock.Rows[fila].Cells[1].Value);
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
			/* Cannot convert OnErrorResumeNextStatementSyntax, CONVERSION ERROR: Conversion for OnErrorResumeNextStatement not implemented, please report this issue in 'On Error Resume Next' at character 8413


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
			/* Cannot convert OnErrorResumeNextStatementSyntax, CONVERSION ERROR: Conversion for OnErrorResumeNextStatement not implemented, please report this issue in 'On Error Resume Next' at character 9290


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
						Seleccion = "O";
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
				case var case9 when case9 == 9:
					{
						Seleccion = "D";
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

		private void Option11_CheckedChanged(object sender, EventArgs e)
		{
			if (chkCliente.Checked)
				Options1(1);
		}

		private void Option12_CheckedChanged(object sender, EventArgs e)
		{
			if (chkProveedor.Checked)
				Options1(2);
		}

		private void Option13_CheckedChanged(object sender, EventArgs e)
		{
			if (chkFinanciera.Checked)
				Options1(3);
		}

		private void Option14_CheckedChanged(object sender, EventArgs e)
		{
			if (chkEmpleado.Checked)
				Options1(4);
		}

		private void Option15_CheckedChanged(object sender, EventArgs e)
		{
			if (chkVendedor.Checked)
				Options1(5);
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

		private void Option16_CheckedChanged(object sender, EventArgs e)
		{
			if (chkOperador.Checked)
				Options1(6);
		}

		private void Option17_CheckedChanged(object sender, EventArgs e)
		{
			if (chkAsociacion.Checked)
				Options1(7);
		}

		private void Option18_CheckedChanged(object sender, EventArgs e)
		{
			if (chkTransporte.Checked)
				Options1(8);
		}

		private void chkMedico_CheckedChanged(object sender, EventArgs e)
		{
			if (chkMedico.Checked)
				Options1(9);
		}
	}
}