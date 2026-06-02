using System;
using DattCom;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace directMnt
{
	internal partial class AdcDir : System.Windows.Forms.Form
	{
		private string Sistema;
		private string Codigo, CodigoNombre;
		private string Autorizacion;
		private const short MARGIN_SIZE = 60; // en twips

		// variables para permitir el orden de columnas
		private short m_iSortCol;
		private short m_iSortType;

		// variables para arrastrar columnas
		private bool m_bDragOK;
		private short m_iDragCol;
		private short xdn, ydn;
		private string busca;
		private string Personas;
		private string Relacion;
		private bool Opckeyventas;
		private bool Opccompras;
		private bool Opckeypedidos;
		private bool Opckeymail;
		private int posX, posY;
		private int columna, fila;
		// Dim SYSEMP As New AdcDax.DaxSofSys
		public string tipo;

		public AdcDir()
		{
			InitializeComponent();
		}

		private void EscogerColumnasToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var prog = new EscojeCamposDir();
			var argSistem = datosEmpresa.sistema;
			prog.EscojeCampos(ref argSistem);
			cargarmalla();
		}

		private void AdcDir_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
		{
			bool Cancel = e.Cancel;
			var UnloadMode = e.CloseReason;
			Dispose();
			e.Cancel = Cancel;
		}

		private void AdcDir_Load(object sender, EventArgs e)
		{
			try
			{
				if (Operators.CompareString(tipo, "", false) > 0)
					btnRelacion.Visible = false;
				Sistema = datosEmpresa.sistema;
				// If Len(Trim(varbleComun.)) = 0 Then Me.Close() : Exit Sub
				if (Len(Strings.Trim(datosEmpresa.nombreBaseAdcom)) == 0)
				{
					Close();
					return;
				}
				Autorizacion = datosEmpresa.auto;
				Submenu.Visible = false;
				if (Operators.CompareString(tipo, "", false) > 0)
				{
					switch (tipo ?? "")
					{
						case "E":
							{
								Relacion = " and esempleado <> 0 ";
								Text = "Directorio de Empleados";
								break;
							}
						case "C":
							{
								Relacion = " and escliente <> 0 ";
								Text = "Directorio de Clientes";
								break;
							}
						case "P":
							{
								Relacion = " and esproveedor <> 0 ";
								Text = "Directorio de Proveedores";
								break;
							}
						case "V":
							{
								Text = "Directorio de Vendedores";
								Relacion = " and esvendedor <> 0 ";
								break;
							}
						case "F":
							{
								Text = "Directorio de Instituciónes Financieras";
								Relacion = " and esbanco <> 0";
								break;
							}
					}
				}
				// cargarmalla()
				return;
			}
			catch
			{

				Interaction.MsgBox("El sistema no tiene una configuración correcta, consulte al administrador" + Information.Err().Description);
				Close();
			}
		}
		private void ChequearOpciones()
		{
			bool abierto = Conversions.ToBoolean(Interaction.IIf(DelUsuario.AutorizarIngreso("mnuoDirectorioGeneral", datosEmpresa.usr) == "T", true, false));
			btnNuevo.Visible = abierto;
			NuevoRegistroToolStripMenuItem1.Visible = abierto;
		}

		private void cargarmalla()
		{
			string sSQL;
			WaitMensaje.WMensaje.verMensaje("Cargando lista de empleados");
			string OpcionStandard = "select [Codigo],[nombreImpresion] as [Nombre],[Provincia],[Ciudad],[Domicilio],[Telefono1],[NúmeroFax],[CorreoElectrónico] ";
			string CamposDir;
			CamposDir = Interaction.GetSetting(Sistema, "Dir", "Campos", "");
			if (Operators.CompareString(Strings.Trim(CamposDir), "", false) > 0)
			{
				sSQL = "select " + CamposDir;
			}
			else
			{
				sSQL = OpcionStandard;
			}
			try
			{
				sSQL = sSQL + " from [directorioList] ";
				sSQL = sSQL + " where [codigo] > '' " + Relacion + Personas + " order by [nombrecli] ";
				MallaDat.DataSource = SqlDatos.leerTablaAdcom(sSQL);
				MallaDat.ClearSelection();
			}
			catch (Exception e)
			{
				Interaction.MsgBox("Existe una excepción con los datos escojidos,el sistema regresa a los datos por defecto" + Constants.vbCr + e.Message);
				sSQL = OpcionStandard;
				sSQL = sSQL + " from [directorioList] ";
				sSQL = sSQL + " where [codigo] > '' " + Relacion + Personas + " order by [nombrecli] ";
				MallaDat.DataSource = SqlDatos.leerTablaAdcom(sSQL);
				MallaDat.ClearSelection();
			}
			WaitMensaje.WMensaje.cierraMensaje();
		}

		private void btnSalir_Click(object sender, EventArgs e)
		{
			Close();
		}

		private short _Busqueda_a = default;
		private void Busqueda(ref short Tipo)
		{
			int i;
			string buscomp;
			if (columna == 0)
				columna = 1;
			if (Tipo == 0)
			{
				_Busqueda_a = 0;
				busca = "";
				busca = Interaction.InputBox("BUSCAR:", "BUSQUEDA DE EXPRESIONES EN MALLAS");
			}
			{
				var withBlock = MallaDat;
				if (_Busqueda_a >= withBlock.RowCount - 1)
					_Busqueda_a = 0;
				if (Strings.Len(busca) == 1)
				{
					var loopTo = withBlock.RowCount - 1;
					for (i = _Busqueda_a + 1; i <= loopTo; i++)
					{
						if (withBlock.Rows[i].Cells[columna].Value.ToString() is DBNull)
							buscomp = "";
						else
							buscomp = withBlock.Rows[i].Cells[columna].Value.ToString();
						if ((Strings.UCase(buscomp) ?? "") == (Strings.UCase(busca) ?? ""))
						{
							withBlock.ClearSelection();
							withBlock.Rows[i].Cells[columna].Selected = true;
							_Busqueda_a = (short)i;
							if (!(withBlock.Rows[i].Displayed == true))
							{
								withBlock.FirstDisplayedScrollingRowIndex = i;
							}
							return;
						}
					}
					_Busqueda_a = (short)i;
				}
				else
				{
					var loopTo1 = withBlock.RowCount - 1;
					for (i = _Busqueda_a + 1; i <= loopTo1; i++)
					{
						if (withBlock.Rows[i].Cells[columna].Value.ToString() is DBNull)
							buscomp = "";
						else
							buscomp = withBlock.Rows[i].Cells[columna].Value.ToString();
						if (LikeOperator.LikeString(Strings.UCase(buscomp), "*" + Strings.UCase(busca) + "*", CompareMethod.Binary) == true)
						{
							withBlock.ClearSelection();
							withBlock.Rows[i].Cells[columna].Selected = true;
							_Busqueda_a = (short)i;
							if (!(withBlock.Rows[i].Displayed == true))
							{
								withBlock.FirstDisplayedScrollingRowIndex = i;
							}
							return;
						}
					}
					_Busqueda_a = (short)i;
				}
			}
		}

		private void borrarlinea(ref int Lin)
		{
			int j;
			var loopTo = MallaDat.ColumnCount - 1;
			for (j = 0; j <= loopTo; j++)
			{
			}
		}

		private void CopiarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Dim prog As New daaxLib.
			// prog.CopiarPegarMalla(MallaDat)
			// prog = Nothing
		}

		private void MallaDat_CellContextMenuStripNeeded(object sender, System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventArgs e)
		{
			Submenu.Show(MallaDat, posX, posY);
			Submenu.Focus();
		}

		private void MallaDat_DoubleClick(object sender, EventArgs e)
		{
			// -------------------------------------------------------------------------------------------
			// el código del evento DblClick de la cuadrícula permite ordenar columnas
			// -------------------------------------------------------------------------------------------

			short i;

			// sólo ordena cuando se hace clic en una fila
			// If MallaDat.MouseRow >= MallaDat.FixedRows Then Exit Sub

			i = m_iSortCol; // guarda la columna antigua
							// incrementa el tipo de orden
			if (i != m_iSortCol)
			{
				// si hace clic en una columna nueva, inicia con orden ascendente
				m_iSortType = 1;
			}
			else
			{
				// si hace clic en la misma columna, alterna entre orden ascendente y orden descendente
				m_iSortType = (short)(m_iSortType + 1);
				if (m_iSortType == 3)
					m_iSortType = 1;
			}

			DoColumnSort();
		}

		private void MallaDat_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
		{
			if (m_iDragCol == -1)
				return; // no se estaba arrastrando
						// If MallaDat.MouseRow <> 0 Then Exit Sub
						// If MallaDat.FixedCols = 1 And MallaDat.MouseCol = 0 Then Exit Sub

			// With MallaDat
			// .Redraw = False
			// .set_ColPosition(m_iDragCol, .MouseCol)
			// .Redraw = True
			// End With
		}

		private void MallaDat_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == System.Windows.Forms.Keys.F3)
			{
				short argTipo = 1;
				Busqueda(ref argTipo);
			}
			else if (e.KeyCode > System.Windows.Forms.Keys.Space & e.KeyCode <= System.Windows.Forms.Keys.Z)
			{
				busca = Conversions.ToString(Strings.Chr((int)e.KeyCode));
				short argTipo1 = 1;
				Busqueda(ref argTipo1);
			}
		}

		private void MallaDat_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			posX = e.Location.X;
			posY = e.Location.Y;
		}
		private void MallaDat_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			// -------------------------------------------------------------------------------------------
			// el código de los eventos DragDrop, MouseDown, MouseMove y MouseUp permite arrastrar columnas
			// -------------------------------------------------------------------------------------------
			if ((int)e.Button == 2)
			{
				return;
			}


			xdn = (short)e.X;
			ydn = (short)e.Y;
			m_iDragCol = -1; // borrar indicador de arrastre
			m_bDragOK = true;
		}

		private void MallaDat_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			// -------------------------------------------------------------------------------------------
			// el código de los eventos DragDrop, MouseDown, MouseMove y MouseUp permite arrastrar columnas
			// -------------------------------------------------------------------------------------------

			m_bDragOK = false;
		}

		public void DoColumnSort()
		{
			ordenarmalla();
		}

		private void ordenarmalla()
		{
			// Dim i As Integer
			// With MallaDat
			// .Redraw = False
			// For i = 1 To .Rows - 1
			// .set_TextMatrix(i, 0, i)
			// Next i
			// .Redraw = True
			// End With

		}

		private void MostrarPedidosCliente()
		{
			// Dim prog As New PedidosProducto
			// If Emp.Prod = False Then MsgBox "No tiene activado el módulo de produción", vbCritical: Exit Sub
			// With MallaDat
			// PedidosProducto.NombreConsulta = .TextMatrix(.Row, 2)
			// PedidosProducto.VerCliente = .TextMatrix(.Row, 1)
			// PedidosProducto.Show vbModal
			// Unload PedidosProducto
			// Set PedidosProducto = Nothing
			// End With
		}
		private void EstadoDeCuenta()
		{
			// Dim prog As New CLIP00
			// With MallaDat
			// prog.CodigoCliente = .TextMatrix(.Row, 1)
			// prog.Tipo = True
			// prog.Show
			// End With
		}

		private void RelaciónToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Personas = " and tipopersona = 'N' ";
			cargarmalla();
		}

		private void EmpresasToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Personas = " and tipopersona = 'J' ";
			cargarmalla();
		}

		private void TodosToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Personas = "";
			cargarmalla();
		}

		private void ClientesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Relacion = " and escliente <> 0 ";
			cargarmalla();
		}

		private void TodasToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Relacion = "";
			cargarmalla();
		}

		private void ProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
		{

			Relacion = " and esproveedor <> 0 ";
			cargarmalla();
		}

		private void FinancieraToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Relacion = " and esbanco <> 0 ";
			cargarmalla();
		}

		private void VendedorToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Relacion = " and esvendedor <> 0 ";
			cargarmalla();
		}

		private void EmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Relacion = " and esempleado <> 0 ";
			cargarmalla();
		}

		private void btnNuevo_Click(object sender, EventArgs e)
		{
			CrearNuevo();
			cargarmalla();
		}

		private void btnBusca_Click(object sender, EventArgs e)
		{
			BuscarToolStripMenuItem1_Click(sender, e);
		}

		private void btnAbrir_Click(object sender, EventArgs e)
		{
			PropiedadesToolStripMenuItem1_Click(sender, e);
			cargarmalla();
		}

		private void btnTodos_ButtonClick(object sender, EventArgs e)
		{
			cargarmalla();
		}

		private void btnRelacion_ButtonClick(object sender, EventArgs e)
		{
			cargarmalla();
		}
		private void CrearNuevo()
		{
			var prog = new BusDirectorio();
			string autoriza;
			autoriza = DelUsuario.AutorizarIngreso("mnuoDirectorioGeneral", datosEmpresa.usr);
			if (autoriza == "T")
			{
				datosEmpresa.auto = autoriza;
				string argConCodigo = "&&";
				prog.ManDir(ref argConCodigo);
				prog = null;
			}
			datosEmpresa.auto = Autorizacion;
		}
		// Private Sub BuscarRegistro()
		// Dim prog As New BuscaClien
		// Codigo = prog.IniBuscaCliOPro("", CodigoNombre)
		// 
		// End Sub

		private void BuscarToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			short argTipo = 0;
			Busqueda(ref argTipo);
		}

		private void FiltrarToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			int Col = 0;
			int j = 0;
			int i = 0;
			string Com = "";
			{
				var withBlock = MallaDat;
				Col = columna;
				Com = Interaction.InputBox("Filtrar por :", "Seleccionar filas por valores", Conversions.ToString(withBlock.Rows[fila].Cells[columna].Value));
				if (Operators.CompareString(Com, "", false) > 0)
				{
					j = 0;
					i = 1;
					while (j != 1)
					{
						if (Conversions.ToBoolean(!LikeOperator.LikeObject(withBlock.Rows[i].Cells[Col].Value, "*" + Com + "*", CompareMethod.Binary)))
						{
							if (i == withBlock.RowCount - 1)
							{
								int argLin = i;
								borrarlinea(ref argLin);
								break;
							}
							else
							{
								withBlock.Rows.RemoveAt(i);
							}
						}
						else
						{
							i = i + 1;
						}
						if (i > withBlock.RowCount - 1)
							j = 1;
					}

					FINALIN:
					;

					// System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
					ordenarmalla();
				}
			}
		}

		private void EscogerColumnasToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			var prog = new EscojeCamposDir();
			prog.EscojeCampos(ref datosEmpresa.sistema);
			cargarmalla();
		}

		private void CopiarToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			// Dim prog As New DaxLib.DaxLibMalla
			// prog.CopiarPegarMalla(MallaDat)
			// prog = Nothing
		}

		private void PropiedadesToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			var prog = new DEEP01();
			long ColAct;
			long LinAct;
			string autbak = DelUsuario.AutorizarIngreso("mnuoDirectorioGeneral", datosEmpresa.usr);
			if (Operators.CompareString(autbak, "", false) > 0)
			{
				{
					var withBlock = MallaDat;
					ColAct = withBlock.CurrentCell.ColumnIndex;
					LinAct = withBlock.CurrentCell.RowIndex;
					datosEmpresa.auto = autbak;
					prog.Directorio(Conversions.ToString(withBlock.Rows[(int)LinAct].Cells["Codigo"].Value));
					prog = null;
					cargarmalla();
				}
			}
			datosEmpresa.auto = Autorizacion;
		}

		private void NuevoRegistroToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			var prog = new DEEP01();
			string autbak = DelUsuario.AutorizarIngreso("mnuoDirectorioGeneral", datosEmpresa.usr);
			if (Operators.CompareString(autbak, "", false) > 0)
			{
				datosEmpresa.auto = autbak;
				prog.Directorio("");
				prog = null;
			}
			datosEmpresa.auto = Autorizacion;
		}

		private void ImprimirToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var imp = new DataGridViewPrinterApplication1.frmMain();
			imp.imprimir(MallaDat);
		}

		private void btnEnviar_ButtonClick(object sender, EventArgs e)
		{
			btnEnviar.ShowDropDown();
		}

		private void ExcelToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var exp = new global::mallExp.Form1();
			string Empresa = datosEmpresa.nomEmpresa;
			exp.Exportar(MallaDat, "E", Empresa, "Directorio");
		}

		private void WordToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var exp = new global::mallExp.Form1();
			exp.Exportar(MallaDat, "W", datosEmpresa.nomEmpresa, "Directorio");
		}

		private void PDFToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			var exp = new global::mallExp.Form1();
			exp.Exportar(MallaDat, "P", datosEmpresa.nomEmpresa, "Directorio");
		}

		private void MallaDat_CellEnter(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
		{
			columna = e.ColumnIndex;
			fila = e.RowIndex;
		}
	}
}