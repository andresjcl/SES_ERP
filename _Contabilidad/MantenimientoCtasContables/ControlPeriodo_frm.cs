using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using SysEmpDatt;

namespace MantCtb
{
    internal partial class ControlPeriodo : Form
    {
        public void iniciaPermisos()
        {
            Toolbar1.Items[6].Enabled = false;
            CargarPeriodos();
            Show();
        }

        private void CargarPeriodos()
        {
            string ssql = "Select año,mes,Contabilidad,OtrosModulos,ExcContabilidad,ExcOtrosModulos,idclave from AdcPeriodo  order by año,mes";
            Malla.DataSource = SqlDatos.leerTablaAdcom(ssql);
            Malla.Columns["idclave"].Visible = false;

            // Dim rs As SqlDataReader
            // Dim i As Short

            // Dim Conxadcom As New SqlConnection(datosEmpresa.strConxAdcom)
            // Conxadcom.Open()
            // Dim ssql As String = ""
            // ssql = "Select año,mes,Contabilidad,OtrosModulos,ExcContabilidad,ExcOtrosModulos,idclave from AdcPeriodo  order by año,mes"
            // Dim comm As New SqlCommand(ssql, Conxadcom)
            // rs = comm.ExecuteReader
            // With Malla
            // .ColumnCount = 7
            // .RowCount = 0
            // .RowHeadersVisible = True
            // .RowHeadersWidth = 30
            // .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

            // .Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            // .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            // .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            // .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            // .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            // .Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            // .Columns(6).Width = 50
            // .Columns(0).Name = "AÑO"
            // .Columns(1).Name = "MES"
            // .Columns(2).Name = "Contabilidad"
            // .Columns(3).Name = "OtrosMódulos"
            // .Columns(4).Name = "Excepto para contabilidad"
            // .Columns(5).Name = "Excepto para otros módulos"
            // .Columns(6).Name = "ID.Clv."
            // .Columns(6).Visible = False
            // End With
            // i = 0
            // With Me.Malla.Rows
            // Do Until rs.Read = False
            // .Add({rs.Item("Año").Value, rs.Item("Mes").Value, rs.Item("contabilidad").Value,
            // rs.Item("otrosmodulos").Value, rs.Item("exccontabilidad").Value,
            // rs.Item("excotrosmodulos").Value, rs.Item("Idclave").Value})
            // Loop
            // End With
            // rs.Close()
        }

        private void Malla_EnterCell(object eventSender, EventArgs eventArgs)
        {
            CambiarEstado();
        }

        private void CambiarEstado()
        {
            {
                var withBlock = Malla;
                if (withBlock.CurrentCell.ColumnIndex == 2 | withBlock.CurrentCell.ColumnIndex == 3)
                {
                    if (withBlock.CurrentCell.Value.ToString() == "Cerrado")
                    {
                        Toolbar1.Items["keyactivar"].Enabled = true;
                        Toolbar1.Items["keycerrar"].Enabled = false;
                    }
                    else
                    {
                        Toolbar1.Items["keycerrar"].Enabled = true;
                        Toolbar1.Items["keyactivar"].Enabled = false;
                    }
                }
            }
        }

        private void Toolbar1_ButtonClick(object eventSender, EventArgs eventArgs)
        {
            ToolStripItem Button = (ToolStripItem)eventSender;
            var progim = new DataGridViewPrinterApplication1.frmMain();
            switch (Button.Name ?? "")
            {
                case "keycrear":
                    {
                        int argAño = 0;
                        CrearPeriodo(ref argAño);
                        break;
                    }

                case "keyeliminar":
                    {
                        EliminarPeriodos();
                        break;
                    }

                case "keyactivar":
                    {
                        ActivarPeriodos();
                        break;
                    }

                case "keycerrar":
                    {
                        CerrarPeriodos();
                        break;
                    }

                case "keygrabar":
                    {
                        GuardarPeriodos();
                        break;
                    }

                case "btnsalir":
                    {
                        GuardarPeriodos();
                        Close();
                        return;
                    }

                case "keycancelar":
                    {
                        Close();
                        return;
                    }

                case "btnExcepto":
                    {
                        if (Malla.CurrentCell.ColumnIndex == 4 | Malla.CurrentCell.ColumnIndex == 5)
                            Malla.CurrentCell.Value = selectUser();
                        break;
                    }

                case "bnimprimir":
                    {
                        progim.imprimir(Malla, "Planificacion de control de períodos", Empresa: datosEmpresa.Emp_Nombre);
                        progim = null;
                        break;
                    }
            }
        }

        private string selectUser()
        {
            string selectUserRet = default;
            string pasar = "";
            var frm = new frmUsuarios();
            {
                var withBlock = Malla;
                selectUserRet = frm.iniciaUsuario(ref pasar);
            }

            return selectUserRet;
        }

        private void GuardarPeriodos()
        {
            short i;
            string sSql;
            {
                var withBlock = Malla;
                var loopTo = (short)(withBlock.RowCount - 1);
                for (i = 0; i <= loopTo; i++)
                {
                    if (Convert.ToBoolean(Operators.AndObject(Operators.ConditionalCompareObjectGreater(withBlock.Rows[i].Cells[0].Value, 0, false), Operators.ConditionalCompareObjectGreater(withBlock.Rows[i].Cells[1].Value, 0, false))))
                    {
                        if (Convert.ToBoolean(Operators.ConditionalCompareObjectEqual(withBlock.Rows[i].Cells[6].Value, 0, false)))
                        {
                            sSql = "INSERT INTO [AdcPeriodo]";
                            sSql = sSql + " ([Año],[Mes],[Contabilidad],[OtrosModulos],[ExcContabilidad],[ExcOtrosModulos]) ";
                            sSql = sSql + " Values (";
                            sSql = Conversions.ToString(Operators.ConcatenateObject(sSql, withBlock.Rows[i].Cells[0].Value));
                            sSql = Conversions.ToString(Operators.ConcatenateObject(sSql + ",", withBlock.Rows[i].Cells[1].Value));
                            sSql = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(sSql + ",'", withBlock.Rows[i].Cells[2].Value), "' "));
                            sSql = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(sSql + ",'", withBlock.Rows[i].Cells[3].Value), "'"));
                            sSql = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(sSql + ",'", withBlock.Rows[i].Cells[4].Value), "' "));
                            sSql = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(sSql + ",'", withBlock.Rows[i].Cells[5].Value), "') "));
                        }
                        else
                        {
                            sSql = "Update [AdcPeriodo]";
                            sSql = sSql + " Set ";
                            sSql = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(sSql + "[Contabilidad] = '", withBlock.Rows[i].Cells[2].Value), "'"));
                            sSql = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(sSql + ",[OtrosModulos] = '", withBlock.Rows[i].Cells[3].Value), "'"));
                            sSql = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(sSql + ",[ExcContabilidad] = '", withBlock.Rows[i].Cells[4].Value), "'"));
                            sSql = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(sSql + ",[ExcOtrosModulos] = '", withBlock.Rows[i].Cells[5].Value), "'"));
                            sSql = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(sSql + " WHERE año = ", withBlock.Rows[i].Cells[0].Value), " and mes = "), withBlock.Rows[i].Cells[1].Value));
                            // sSql = sSql & " and idclave = " & .Rows(i).Cells(5).Value
                        }
                        // linkdat.Adcom = True
                        SqlDatos.ejecutarComando(sSql, datosEmpresa.strConxAdcom);
                    }
                }
            }

            Malla.Rows.Clear();
            CargarPeriodos();
        }

        private void CrearPeriodo(ref int Año)
        {
            short Inicio;
            double TotalRegistros = 0d;
            // Dim rs As New ADODB.Recordset
            int i;
            {
                var withBlock = Malla;
                if (Año == 0)
                {
                    Año = (int)Math.Round(Conversion.Val(Interaction.InputBox("Digite al año en que desea crear los períodos", "Año para crear períodos", DateAndTime.Year(DateAndTime.Today).ToString())));
                    if (Año <= DateAndTime.Year(emp.InvUltAnu))
                    {
                        Interaction.MsgBox("No puede crear períodos menores a la última fecha de cierre anual");
                        return;
                    }

                    var loopTo = withBlock.Rows.Count - 1;
                    for (i = 0; i <= loopTo; i++)
                    {
                        if (Convert.ToBoolean(Operators.ConditionalCompareObjectEqual(withBlock.Rows[i].Cells[1].Value, Año, false)))
                        {
                            Interaction.MsgBox("El año para crear períodos ya existe ", MsgBoxStyle.Critical);
                            return;
                        }
                    }
                }

                Inicio = 0;
                var loopTo1 = withBlock.Rows.Count - 1;
                for (i = 0; i <= loopTo1; i++)
                {
                    if (Convert.ToBoolean(Operators.ConditionalCompareObjectEqual(withBlock.Rows[i].Cells[1].Value, 0, false)))
                        Inicio = (short)i;
                }

                if (Inicio == 0)
                    Inicio = 1;
                for (i = 1; i <= 12; i++)
                    Malla.Rows.Add(new[] { Año, i, "Abierto", "Abierto", "", "", (object)0 });
            }
        }

        private void EliminarPeriodos()
        {
            bool Existe;
            var TotalRegistros = default(double);
            int Año;
            int i;
            var Conxadcom = new SqlConnection(datosEmpresa.strConxAdcom);
            SqlDataReader rs;
            Conxadcom.Open();
            Año = (int)Math.Round(Conversion.Val(Interaction.InputBox("Digite al año en que desea ELIMINAR los períodos", "Año para eliminar períodos", DateAndTime.Year(DateAndTime.Today).ToString())));
            if (Año > DateAndTime.Year(emp.InvUltAnu))
            {
                Interaction.MsgBox("No se puede eliminar períodos mayores a la fecha de cierre anual");
                return;
            }

            var comm = new SqlCommand("select count(*) as total from  adcdoc where year(doc_fecha) = " + Año);
            rs = comm.ExecuteReader();
            if (rs.Read())
                TotalRegistros = Conversions.ToDouble(rs["Total"].ToString());
            rs.Close();
            if (TotalRegistros > 0d)
            {
                Interaction.MsgBox("No se puede eliminar un período utilizado actualmente", MsgBoxStyle.Critical);
                return;
            }

            {
                var withBlock = Malla;
                Existe = true;
                i = 0;
                while (Existe != false)
                {
                    if (Convert.ToBoolean(Operators.ConditionalCompareObjectEqual(Año, Malla.Rows[i].Cells[1].Value, false)))
                        Malla.Rows[i].Dispose();
                    else
                        i = i + 1;
                    if (i > Malla.RowCount - 1)
                    {
                        Existe = false;
                        break;
                    }
                }
            }

            Conxadcom.Dispose();
        }

        private void ActivarPeriodos()
        {
            int i;
            int col;
            col = Malla.CurrentCell.ColumnIndex;
            if (!(col == 2 | col == 3))
                return;
            if (Interaction.MsgBox("Confirma Activar los períodos seleccionados ? ", (MsgBoxStyle)((int)MsgBoxStyle.Question + (int)MsgBoxStyle.YesNo)) == MsgBoxResult.No)
                return;
            {
                var withBlock = Malla;
                var loopTo = withBlock.RowCount - 1;
                for (i = 0; i <= loopTo; i++)
                {
                    if (withBlock.Rows[i].Cells[col].Selected)
                    {
                        if (col == 3 & withBlock.Rows[i].Cells[2].Value.ToString() == "Cerrado")
                        {
                            Interaction.MsgBox("No se puede abrir 'OtrosModulos' cuando 'Contabilidad' está cerrado");
                            return;
                        }
                    }
                }

                var loopTo1 = withBlock.RowCount - 1;
                for (i = 0; i <= loopTo1; i++)
                {
                    if (withBlock.Rows[i].Cells[col].Selected)
                    {
                        withBlock.Rows[i].Cells[col].Value = "Abierto";
                        withBlock.Rows[i].Cells[col + 2].Value = "";
                    }
                }
            }

            CambiarEstado();
        }

        private void CerrarPeriodos()
        {
            int i;
            int col;
            col = Malla.CurrentCell.ColumnIndex;
            if (!(col == 2 | col == 3))
                return;
            if (Interaction.MsgBox("Confirma cerrar los períodos seleccionados ? ", (MsgBoxStyle)((int)MsgBoxStyle.Question + (int)MsgBoxStyle.YesNo)) == MsgBoxResult.No)
                return;
            {
                var withBlock = Malla;
                var loopTo = withBlock.RowCount - 1;
                for (i = 0; i <= loopTo; i++)
                {
                    if (withBlock.Rows[i].Cells[col].Selected)
                    {
                        if (col == 2 & withBlock.Rows[i].Cells[3].Value.ToString() == "Abierto")
                        {
                            Interaction.MsgBox("No se puede cerrar 'contabilidad' cuando 'OtrosModulos' está abierto");
                            return;
                        }
                    }
                }

                var loopTo1 = withBlock.RowCount - 1;
                for (i = 0; i <= loopTo1; i++)
                {
                    if (withBlock.Rows[i].Cells[col].Selected)
                    {
                        withBlock.Rows[i].Cells[col].Value = "Cerrado";
                        withBlock.Rows[i].Cells[col + 2].Value = "";
                    }
                }
            }

            CambiarEstado();
        }
    }
}