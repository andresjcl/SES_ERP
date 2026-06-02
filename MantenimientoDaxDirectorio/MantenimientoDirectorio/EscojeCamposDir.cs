using System;
using System.Data;
using System.Data.SqlClient;
using DattCom;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace directMnt
{
	internal partial class EscojeCamposDir
	{
		private string CamposAntes = "";
		private int LimSup = 0;
		private int LimInf = 0;
		private string[] MatCamposAntes;
		private string CamposCol = "";
		private string Sistema = "";

		public EscojeCamposDir()
		{
			InitializeComponent();
		}

		public string EscojeCampos(ref string Sistem)
		{
			string EscojeCamposRet = default;
			// If CamposCol = Nothing Then Return ""
			Sistema = Sistem;
			ShowDialog();
			Interaction.SaveSetting(Sistema, "Dir", "Campos", CamposCol);
			EscojeCamposRet = CamposCol;
			return EscojeCamposRet;
		}

		private void EscojeCamposDir_Load(object sender, EventArgs e)
		{
			// Dim prog As New DaxLib.DaxLibMalla
			// prog.ColorF(Me)
			// prog = Nothing

			CamposAntes = Interaction.GetSetting(Sistema, "Dir", "Campos", "");
			if (Operators.CompareString(CamposAntes, "", false) > 0)
			{
				MatCamposAntes = Strings.Split(CamposAntes, ",");
				LimSup = Information.UBound(MatCamposAntes);
				LimInf = Information.LBound(MatCamposAntes);
			}
			llenarMalla();
		}
		private void llenarMalla()
		{
			string sSQL = "select top 1 * from directorioList ";
			var conn = new SqlConnection(datosEmpresa.strConxAdcom);
			int I;
			conn.Open();
			var misqlDa = new SqlDataAdapter(sSQL, conn);
			var dato = new DataTable("datos");
			misqlDa.Fill(dato);
			{
				var withBlock = malla;
				var loopTo = dato.Columns.Count - 1;
				for (I = 0; I <= loopTo; I++)
					withBlock.Items.Add(dato.Columns[I].ColumnName);
			}

			// Dim rs As New DataTable
			// Dim DR As New SqlClient.SqlDataReader
			// Dim CONN As 
			// Dim prog As New DaxData.DaxLibDatos
			// 'Dim ConxAdcom As New ADODB.Connection
			// 'Dim PROG As New DaxLibBases
			// Dim i As Integer
			// Dim j As Integer

			// 'ConxAdcom.ConnectionString = Prog.StrAdcom    'prog.ArmStr(Emp.NombreBaseAlex, Emp.servidor, "", Emp.ClaveBD, Emp.UsuarioBd)
			// 'ConxAdcom.Open

			// 'rs = prog.DaxData("MSSQL", "sp_columns directorioadc") ' ConxAdcom.Execute("sp_columns directorioadc")
			// With malla
			// Do Until rs.EOF
			// If Not IsDBNull(rs.Fields("column_name").Value) Then .Items.Add(rs.Fields("column_name").Value)
			// rs.MoveNext()
			// Loop
			// End With
			if (LimSup > 0)
			{
				var loopTo1 = malla.Items.Count - 1;
				for (I = 0; I <= loopTo1; I++)
				{
					for (int j = 1, loopTo2 = LimSup; j <= loopTo2; j++)
					{
						if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(malla.Items[I], MatCamposAntes[j], false)))
							malla.SetItemChecked(I, true);
					}
				}
			}
			malla.SetItemChecked(0, true);
		}


		private void Command2_Click(object sender, EventArgs e)
		{
			int i;
			CamposCol = "Codigo";
			{
				var withBlock = malla;
				var loopTo = withBlock.Items.Count - 1;
				for (i = 1; i <= loopTo; i++)
				{
					if (malla.GetItemChecked(i) == true)
					{
						if (Operators.CompareString(CamposCol, "", false) > 0)
							CamposCol = CamposCol + ",";
						CamposCol = CamposCol + withBlock.Items[i].ToString();
					}
				}
			}
			Close();
		}

		private void Command1_Click(object sender, EventArgs e)
		{
			CamposCol = "";
			Interaction.SaveSetting(Sistema, "Dir", "Campos", CamposCol);
			Close();
		}

		private void Command3_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}