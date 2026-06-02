using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using DattCom;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace directMnt
{
	public partial class frmCapacitacion
	{
		public string NombreEmpleado;
		public string CodigoEmpleado;
		// Public LosParientes As ColParientes
		private string Datobak;
		private int ColBak;
		private int LinBak;
		private int fila, columna, colAnt;
		private string codPais, codInstr;

		public frmCapacitacion()
		{
			InitializeComponent();
			LabEmpleado = _LabEmpleado;
			Label1 = _Label1;
			_LabEmpleado.Name = "LabEmpleado";
			_Label1.Name = "Label1";
		}

		private void btnGuardar_Click(object sender, EventArgs e)
		{
			if (ValidaMalla() == false)
			{
				Interaction.MsgBox("Los datos ingresado están errados" + Constants.vbCr + "Los campos mínimos de datos son: País,Institución y especialización");
				return;
			}
			GuardarMallaColeccion();
			Close();
		}
		private bool ValidaMalla()
		{
			if (malla.RowCount < 1)
				return false;
			{
				var withBlock = malla;
				for (int i = 0, loopTo = withBlock.RowCount - 2; i <= loopTo; i++)
				{
					if (withBlock.Rows[i].Cells["Pais"].Value is null | withBlock.Rows[i].Cells["Institucion"].Value is null | withBlock.Rows[i].Cells["Especializacion"].Value is null)
						return false;
				}
			}
			return true;
		}
		public void Capacitacion(string cod, string nombre)
		{
			NombreEmpleado = nombre;
			CodigoEmpleado = cod;
			ShowDialog();
		}

		private void frmCapacitacion_Load(object sender, EventArgs e)
		{
			// Dim prog As New DaxLib.DaxLibMalla
			// prog = Nothing
			malla.Columns[0].ReadOnly = true;
			LabEmpleado.Text = NombreEmpleado;
			CargarColeccionMalla();
		}
		private void CargarColeccionMalla()
		{
			var Conectar = new SqlConnection(datosEmpresa.strConxAdcom);
			int i = 0;
			int cont = 0;
			try
			{
				string CodRs;
				bool VF = false;
				CodRs = "Select CodEmpleado,Pais,Institucion,Titulo,Especialización,NivelEstudio,Retirado,EnCurso,Graduado,FechaFinal,CursosCarrera,CursosAprobados " + " from ADCcAPpER where CodEmpleado='" + CodigoEmpleado + "'";
				LabEmpleado.Text = NombreEmpleado;
				var cmd = new SqlCommand(CodRs, Conectar);
				SqlDataReader dat;
				Conectar.Open();
				dat = cmd.ExecuteReader();
				while (dat.Read())
				{

					{
						var withBlock = malla;
						withBlock.Rows.Add();
						withBlock.Rows[i].Cells["Pais"].Value = dat["Pais"];
						withBlock.Rows[i].Cells["Institucion"].Value = dat["Institucion"];
						withBlock.Rows[i].Cells["Titulo"].Value = dat["Titulo"];
						withBlock.Rows[i].Cells["Especializacion"].Value = dat["Especialización"];
						withBlock.Rows[i].Cells["NivelEstudio"].Value = dat["NivelEstudio"];
						if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dat["Retirado"], 1, false)))
							withBlock.Rows[i].Cells["Retirado"].Value = true;
						if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dat["EnCurso"], 1, false)))
							withBlock.Rows[i].Cells["EnCurso"].Value = true;
						if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dat["Graduado"], 1, false)))
							withBlock.Rows[i].Cells["Graduado"].Value = true;
						withBlock.Rows[i].Cells["FechaFinal"].Value = Strings.FormatDateTime(Conversions.ToDate(dat["FechaFinal"]), DateFormat.ShortDate);
						withBlock.Rows[i].Cells["CursosCarrera"].Value = dat["CursosCarrera"];
						withBlock.Rows[i].Cells["CursosAprobados"].Value = dat["CursosAprobados"];
						i = i + 1;
					}
				}
				Conectar.Close();
				Conectar.Dispose();
				return;
			}
			catch
			{

				Interaction.MsgBox(Information.Err().Description);
			}
		}

		private void GuardarMallaColeccion()
		{
			var Conectar = new SqlConnection(datosEmpresa.strConxAdcom);
			string ssql = "delete from adcCapPer where CodEmpleado='" + CodigoEmpleado + "'";
			var cmd = new SqlCommand(ssql, Conectar);
			Conectar.Open();
			cmd.ExecuteNonQuery();
			string Pais, NivelEstudio, Institucion, Titulo, Especializacion, CursosCarrera, CursosAprobados;
			int Retirado, EnCurso, Graduado;
			DateTime FechaFinal;
			{
				var withBlock = malla;
				for (int i = 0, loopTo = withBlock.RowCount - 2; i <= loopTo; i++)
				{
					Pais = Conversions.ToString(withBlock.Rows[i].Cells["Pais"].Value);
					NivelEstudio = Conversions.ToString(withBlock.Rows[i].Cells["NivelEstudio"].Value);
					Institucion = Conversions.ToString(withBlock.Rows[i].Cells["Institucion"].Value);
					Titulo = Conversions.ToString(withBlock.Rows[i].Cells["Titulo"].Value);
					Especializacion = Conversions.ToString(withBlock.Rows[i].Cells["Especializacion"].Value);
					if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(withBlock.Rows[i].Cells["Retirado"].Value, true, false)))
						Retirado = 1;
					else
						Retirado = 0;
					if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(withBlock.Rows[i].Cells["EnCurso"].Value, true, false)))
						EnCurso = 1;
					else
						EnCurso = 0;
					if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(withBlock.Rows[i].Cells["Graduado"].Value, true, false)))
						Graduado = 1;
					else
						Graduado = 0;
					FechaFinal = Conversions.ToDate(Strings.FormatDateTime(Conversions.ToDate(withBlock.Rows[i].Cells["FechaFinal"].Value), DateFormat.ShortDate));
					CursosCarrera = Conversions.ToString(withBlock.Rows[i].Cells["CursosCarrera"].Value);
					CursosAprobados = Conversions.ToString(withBlock.Rows[i].Cells["CursosAprobados"].Value);

					ssql = "insert into adcCapPer (CodEmpleado,Pais,NivelEstudio,Institucion,Titulo,Especialización,Retirado,EnCurso,Graduado,";
					ssql += "FechaFinal,CursosCarrera,CursosAprobados) values('" + CodigoEmpleado + "',";
					ssql += "'" + Pais + "',";
					ssql += "'" + NivelEstudio + "',";
					ssql += "'" + Institucion + "',";
					ssql += "'" + Titulo + "',";
					ssql += "'" + Especializacion + "',";
					ssql += " " + Retirado + ",";
					ssql += " " + EnCurso + ",";
					ssql += " " + Graduado + ",";
					ssql += "'" + Conversions.ToString(FechaFinal) + "',";
					ssql += "'" + CursosCarrera + "',";
					ssql += "'" + CursosAprobados + "')";

					cmd = new SqlCommand(ssql, Conectar);
					cmd.ExecuteNonQuery();
				}
				Conectar.Close();
				Conectar.Dispose();
			}
		}

		private void malla_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			{
				var withBlock = malla;
				if (columna == 5)
				{
					if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(withBlock.Rows[fila].Cells[5].Value, true, false)))
					{
						withBlock.Rows[fila].Cells[6].Value = false;
						withBlock.Rows[fila].Cells[7].Value = false;
					}
					colAnt = 5;
				}
				else if (columna == 6)
				{
					if (Conversions.ToBoolean(withBlock.Rows[fila].Cells[6].Value))
					{
						withBlock.Rows[fila].Cells[5].Value = false;
						withBlock.Rows[fila].Cells[7].Value = false;
					}
					colAnt = 6;
				}
				else if (columna == 7)
				{
					if (Conversions.ToBoolean(withBlock.Rows[fila].Cells[7].Value))
					{
						withBlock.Rows[fila].Cells[6].Value = false;
						withBlock.Rows[fila].Cells[5].Value = false;
					}
					colAnt = 7;
				}
				if (columna == 4 & colAnt == 5)
				{
					if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(withBlock.Rows[fila].Cells[5].Value, true, false)))
					{
						withBlock.Rows[fila].Cells[6].Value = false;
						withBlock.Rows[fila].Cells[7].Value = false;
					}
				}
				else if (columna == 8 & colAnt == 7)
				{
					if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(withBlock.Rows[fila].Cells[7].Value, true, false)))
					{
						withBlock.Rows[fila].Cells[6].Value = false;
						withBlock.Rows[fila].Cells[5].Value = false;
					}
				}
			}
		}

		private void malla_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			fila = e.RowIndex;
			columna = e.ColumnIndex;
		}

		private void Buscador(int indice, string tiporef)
		{
			string ElNombre = "";
			string ElCodigo = "";
			var Buscod = new Syscod.ManSysnetClass();
			ElCodigo = Buscod.BuscarReferencia(ref tiporef, ref ElCodigo, ref ElNombre);
			if (indice == 0)
				codPais = ElCodigo;
			else
				codInstr = ElCodigo;
			ElCodigo = "";
			malla.Rows[fila].Cells[columna].Value = ElNombre;
		}

		private void malla_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.F2)
			{
				if (columna == 0 | columna == 1)
				{
					if (columna == 0)
						Buscador(0, "Paises");
					else
						Buscador(1, "Instruccion");
				}
			}
		}

		private void Malla_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
		{
			TextBox ValidarNro = (TextBox)e.Control;
			ValidarNro.KeyPress -= ValidaNro_KeyPress;
			ValidarNro.KeyPress += ValidaNro_KeyPress;
		}

		private void ValidaNro_KeyPress(object sender, KeyPressEventArgs e)
		{
			// debe definirse un formato, en definir stilo de las columnas, SOLO para las columnas que deban aceptar números

			// Dim FormatoColumna As String = malla.Columns(malla.CurrentCell.ColumnIndex).DefaultCellStyle.Format.ToString
			// If FormatoColumna = "" Then Exit Sub       
			string nombre = malla.Columns[malla.CurrentCell.ColumnIndex].Name;
			if (nombre != "CursosAprobados" & nombre != "CursosCarrera")
				return;
			switch (e.KeyChar)
			{
				case var @case when '0' <= @case && @case <= '9':
				case '\b':
					{
						// Case "."
						// If FormatoColumna.Contains(".") Or Val(Mid(FormatoColumna, 2, 1)) > 0 Then
						// e.Handled = CType(sender, TextBox).Text.Contains(".")   ' verifica si ya tiene un punto decimal
						// Else
						// e.Handled = True
						// End If
						e.Handled = false;
						break;
					}

				default:
					{
						e.Handled = true;
						break;
					}
			}
		}

		private void Panel1_Paint(object sender, PaintEventArgs e)
		{

		}
	}
}