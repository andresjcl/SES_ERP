using System;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using SysEmpDatt;

namespace MantCtb
{
    internal partial class BuscaCtaContab : Form
    {
        private string MovAgr, CodigoArt;
        private string CodigoRet;
        private bool Sw;
        private DateTime Ini, Fin;
        private bool Act1;
        private bool ConNombre;
        private int fila = 0;

        private void btnbuscar_Click()
        {
            Retorna();
        }

        public string IniciaCtas([Optional, DefaultParameterValue("")] ref string PriCta, [Optional, DefaultParameterValue("")] ref string mov)
        {
            string IniciaCtasRet = default;
            if (!Information.IsNothing(PriCta))
            {
                CodigoArt = PriCta;
            }
            else
            {
                CodigoArt = "";
            }

            MovAgr = Strings.Left(Strings.UCase(mov), 1);
            ShowDialog();
            IniciaCtasRet = CodigoRet;
            return IniciaCtasRet;
        }

        private void btAceptar_Click(object eventSender, EventArgs eventArgs)
        {
            ListNombre_DoubleClick(ListNombre, new EventArgs());
        }

        private void btncancelarbusca_Click(object eventSender, EventArgs eventArgs)
        {
            CodigoRet = "";
            Sw = false;
            Close();
        }

        private void BuscaCtaContab_FormClosed(object eventSender, FormClosedEventArgs eventArgs)
        {
            Interaction.SaveSetting("ADCOM", "BUSCAR", "Cta", Conversions.ToString(Interaction.IIf(OptNombre.Checked, 1, 0)));
        }

        private void btNuevo_Click(object eventSender, EventArgs eventArgs)
        {
            var prog = new CTBP01();
            prog.ShowDialog();
            prog.Close();
            prog = null;
        }

        // 'Private Sub BuscaCtaContab_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
        // '    On Error Resume Next
        // '    'TxtNombre.SetFocus
        // '    '' by Victor
        // '    'ListNombre.Col = 1
        // '    'ListNombre.Row = 1
        // '    'If ListNombre.Rows > 2 Then ListNombre.SetFocus
        // '    If Act1 = False Then
        // '        If TxtNombre.Text > "" Then
        // '            If ListNombre.Rows > 2 Then
        // '                With ListNombre
        // '                    .Row = 1
        // '                    .Col = 1
        // '                    .Focus()
        // '                End With
        // '            Else
        // '                TxtNombre.Focus()
        // '                '        PonerSel TxtNombre
        // '            End If
        // '        Else
        // '            TxtNombre.Focus()
        // '        End If
        // '        Act1 = True
        // '    End If
        // 'End Sub

        private void BuscaCtaContab_Load(object eventSender, EventArgs eventArgs)
        {
            Sw = false;
            // Me.Caption = "Busqueda de Artículos"
            if (Conversions.ToDouble(Interaction.GetSetting("ADCOM", "BUSCAR", "ARTICULO", 0.ToString())) == 1d)
            {
                OptNombre.Checked = true;
            }
            else
            {
                Optcodigo.Checked = true;
            }

            OpCentrosCosto.Visible = true; // Emp.Ccosto
            TextCodigo.Text = CodigoArt;
            Sw = true;
            ArreglaMalla();
        }

        private void OpCentrosCosto_CheckStateChanged(object eventSender, EventArgs eventArgs)
        {
            ArreglaMalla();
        }

        private void OpComodines_CheckStateChanged(object eventSender, EventArgs eventArgs)
        {
            ArreglaMalla();
            TxtNombre.Focus();
        }

        // Private Sub listnombre_KeyDown(KeyCode As Integer, Shift As Integer)
        // If KeyCode = vbKeyReturn Then listnombre_DblClick
        // If ListNombre.Rows = 0 Then Exit Sub
        // If KeyCode = vbKeyF5 Then
        // DetalleArt.ConsultaDetalle ListNombre.TextMatrix(ListNombre.Row, 1), ListNombre.TextMatrix(ListNombre.Row, 2)
        // ListNombre.SetFocus
        // Set DetalleArt = Nothing
        // ElseIf KeyCode = vbKeyF6 Then
        // Compatibles.ConsultarCompatibles ListNombre.TextMatrix(ListNombre.Row, 1), ListNombre.TextMatrix(ListNombre.Row, 2)
        // ListNombre.SetFocus
        // Set Compatibles = Nothing
        // ElseIf KeyCode = vbKeyF7 Then
        // ExistenciasArt.INIExistencia ListNombre.TextMatrix(ListNombre.Row, 1), "", "", Date, ""
        // Set ExistenciasArt = Nothing
        // End If
        // 
        // End Sub

        private void optCodigo_CheckedChanged(object eventSender, EventArgs eventArgs)
        {
            if (_Optcodigo.Checked)
            {
                ArreglaMalla();
                TxtNombre.Focus();
            }
        }

        private void optNombre_CheckedChanged(object eventSender, EventArgs eventArgs)
        {
            if (_OptNombre.Checked)
            {
                ArreglaMalla();
                TxtNombre.Focus();
            }
        }

        private void ArreglaMalla()
        {
            string NomCod, CODSQL;
            string busca;
            string Seleccion; 
            var con = new SqlConnection();
            if (Sw == false)
                return;
            Seleccion = " Cta_grupo as Grupo,Cta_codigo AS CODIGO, Cta_Nombre AS Nombre ";
            if (OpCentrosCosto.Checked == true)
                Seleccion += ",Clasificadores ";
            NomCod = "";
            if (OptNombre.Checked == true)
            {
                NomCod = "cta_NOMBRE";
            }
            else
            {
                NomCod = "cta_codigo";
            }

            CODSQL = "SELECT " + Seleccion + " From adccta where cta_codigo > '' ";
            if (OpCentrosCosto.Checked == true)
                CODSQL += " and ISNULL(clasificadores,'') <> '' ";
            if (Operators.CompareString(TxtGrupo.Text, "", false) > 0)
            {
                if (Convert.ToBoolean(PorInicial.CheckState))
                {
                    CODSQL = CODSQL + " AND cta_grupo LIKE '" + TxtGrupo.Text + "%' ";
                }
                else
                {
                    CODSQL = CODSQL + " AND cta_grupo LIKE '%" + TxtGrupo.Text + "%' ";
                }
            }

            if (Operators.CompareString(TextCodigo.Text, "", false) > 0)
            {
                if (Convert.ToBoolean(PorInicial.CheckState))
                {
                    CODSQL = CODSQL + " AND cta_codigo LIKE '" + TextCodigo.Text + "%' ";
                }
                else
                {
                    CODSQL = CODSQL + " AND cta_codigo LIKE '%" + TextCodigo.Text + "%' ";
                }
            }

            if (Operators.CompareString(TxtNombre.Text, "", false) > 0)
            {
                if (Convert.ToBoolean(PorInicial.CheckState))
                {
                    CODSQL = CODSQL + " AND cta_NOMBRE LIKE '" + TxtNombre.Text + "%' ";
                }
                else
                {
                    CODSQL = CODSQL + " AND cta_NOMBRE LIKE '%" + TxtNombre.Text + "%' ";
                }
            }

            if (Convert.ToBoolean(OpCentrosCosto.CheckState))
            {
                CODSQL = CODSQL + " AND cta_ccosto ='S' ";
            }

            OpComodines.Visible = false;
            if (MovAgr == "S")
            {
                Text = "BUSCAR CUENTAS CONTABLES DE MOVIMIENTO";
                CODSQL = CODSQL + " AND cta_agrupacion = 0 ";
            }
            else if (MovAgr == "M")
            {
                Text = "BUSCAR CUENTAS CONTABLES MAYORES";
                CODSQL = CODSQL + " AND cta_agrupacion <> 0 ";
            }
            else if (MovAgr == "I")
            {
                Text = "Buscar cuentas para contabilización automática";
                CODSQL = CODSQL + " AND cta_agrupacion = 0 ";
                OpComodines.Visible = true;
            }

            busca = "";
            CODSQL = CODSQL + busca + " ORDER BY " + NomCod + " ; ";
            if (OpComodines.CheckState == 0)
            {
                ListNombre.DataSource = SqlDatos.leerTablaAdcom(CODSQL);
            }
            else
            {
                CODSQL = "Select IDCLAVECOM AS Nro,Com_Clave as Comodin,Com_Descripcion as Descripción from sys_Comodin ";
                ListNombre.DataSource = SqlDatos.leerTablaDaxsys(CODSQL);
            }

            Ini = DateAndTime.TimeOfDay;
            con.Close();
            {
                var withBlock = ListNombre;
                if (withBlock.RowCount > 1)
                    withBlock.Rows[1].Frozen = true;
                if (OpComodines.CheckState == 0)
                {
                    if (withBlock.ColumnCount > 0)
                        withBlock.Columns[0].HeaderText = "Grupo";
                    if (withBlock.ColumnCount > 0)
                        withBlock.Columns[1].HeaderText = "Codigo";
                    if (withBlock.ColumnCount > 0)
                        withBlock.Columns[2].HeaderText = "Nombre";
                }
            }

            Fin = DateAndTime.TimeOfDay;
        }

        private void Retorna()
        {
            OperacionesBuscaCta.CodigoCta = Conversions.ToString(ListNombre.Rows[fila].Cells[1].Value);
            OperacionesBuscaCta.NombreCta = Conversions.ToString(ListNombre.Rows[fila].Cells[2].Value);
            Sw = false;
            Close();
        }

        private void TextCodigo_KeyDown(object eventSender, KeyEventArgs eventArgs)
        {
            short KeyCode = (short)eventArgs.KeyCode;
            short Shift = (short)((int)eventArgs.KeyData / 0x10000);
            if (KeyCode == (int)Keys.Return)
                ArreglaMalla();
        }

        private void TextCodigo_KeyPress(object eventSender, KeyPressEventArgs eventArgs)
        {
            short KeyAscii = (short)Strings.Asc(eventArgs.KeyChar);
            if (KeyAscii == Strings.Asc(Constants.vbCr))
                KeyAscii = 0;
            eventArgs.KeyChar = (char)KeyAscii;
            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
        }

        private void TxtGrupo_KeyDown(object eventSender, KeyEventArgs eventArgs)
        {
            short KeyCode = (short)eventArgs.KeyCode;
            short Shift = (short)((int)eventArgs.KeyData / 0x10000);
            if (KeyCode == (int)Keys.Return)
                ArreglaMalla();
        }

        private void TxtGrupo_KeyPress(object eventSender, KeyPressEventArgs eventArgs)
        {
            short KeyAscii = (short)Strings.Asc(eventArgs.KeyChar);
            if (KeyAscii == Strings.Asc(Constants.vbCr))
                KeyAscii = 0;
            eventArgs.KeyChar = (char)KeyAscii;
            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
        }

        private void TxtNombre_TextChanged(object eventSender, EventArgs eventArgs)
        {
            if (Convert.ToBoolean(PorInicial.CheckState))
                ArreglaMalla();
        }

        private void txtNombre_KeyDown(object eventSender, KeyEventArgs eventArgs)
        {
            short KeyCode = (short)eventArgs.KeyCode;
            short Shift = (short)((int)eventArgs.KeyData / 0x10000);
            if (KeyCode == (int)Keys.Return)
                ArreglaMalla();
        }

        private void TxtNombre_KeyPress(object eventSender, KeyPressEventArgs eventArgs)
        {
            short KeyAscii = (short)Strings.Asc(eventArgs.KeyChar);
            if (KeyAscii == Strings.Asc(Constants.vbCr))
                KeyAscii = 0;
            eventArgs.KeyChar = (char)KeyAscii;
            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
        }

        private void ListNombre_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            fila = e.RowIndex;
        }

        private void ListNombre_DoubleClick(object sender, EventArgs e)
        {
            if (ListNombre.RowCount == 0)
                return;
            {
                var withBlock = ListNombre;
                if (Convert.ToBoolean(Operators.ConditionalCompareObjectGreater(withBlock.Rows[fila].Cells[1].Value, "", false)))
                    Retorna();
            }
        }

        private void ListNombre_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            string codigo;
            short j;
            short L;
            ;
            if ((int)OpComodines.CheckState == 0)
            {
                {
                    var withBlock = ListNombre;
                    j = Conversions.ToShort(withBlock.Rows[e.RowIndex].Cells[3].Value);
                    L = (short)Strings.Len(withBlock.Rows[e.RowIndex].Cells[1].Value);
                    if ((int)j > 1)
                    {
                        j = (short)Math.Round(Conversion.Val(Strings.Mid(emp.CtaNumDigNivel.ToString(), (int)j, 1)));
                        codigo = Strings.Mid(Conversions.ToString(withBlock.Rows[e.RowIndex].Cells[1].Value), 1, L - j);
                    }
                }

                codigo = "";
                string ssql = "SELECT CTA_CODIGO,CTA_NOMBRE,clasificadores FROM ADCCTA WHERE CTA_CODIGO = '" + codigo + "'";
                var dat = SqlDatos.leerBaseAdcom(ssql);
                if (!dat.Read())
                {
                    dat.Close();
                    return;
                }

                ToolTip1.SetToolTip(ListNombre, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(dat["CTA_CODIGO"].ToString(), "-"), dat["CTA_NOMBRE"].ToString())));
                dat.Close();
            }
            else
            {
                ToolTip1.SetToolTip(ListNombre, "El comodín se reemplaza por la cuenta contable registrada en:");
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            var imp = new DataGridViewPrinterApplication1.frmMain();
            imp.imprimir(ListNombre, "Plan de cuentas contables ", Empresa: datosEmpresa.Emp_Nombre);
        }

        private void PorInicial_CheckedChanged(object sender, EventArgs e)
        {
        }
    }
}