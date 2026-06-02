using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using SysEmpDatt;

namespace MantCtb
{
    internal partial class CTBP21 : Form
    {
        private string CtaAnt;
        private string[,] Tam = new string[6, 9];
        private double[] TotDoc = new double[7];
        private double[] TotSuc = new double[7];
        private double[] TotGen = new double[7];
        private double suma;
        private short alto, Pagina;
        private string AUXIL2, Auxil, titulo;
        // Dim RsCta As New ADODB.Recordset
        private short CbNiv = 1;
        private short ChTCtas = 1;
        private SqlConnection conectar = new SqlConnection();
        private SqlConnection conectarDaxys = new SqlConnection();

        // Private Sub conectarBDD()
        // Dim coneccion As New DaxLib.DaxLibBases
        // coneccion.TipoBase = "10"
        // conectar.ConnectionString = coneccion.StrAdcom
        // conectarDaxys.ConnectionString = coneccion.StrDaxsys
        // End Sub
        private void btImprimir_Click()
        {
            // Donde = frmenviar.EnviarImpresion
            // If Donde > "" Then ChequearSalida: Me.Refresh:
            Impresion();
        }

        private void btSalir_Click()
        {
            Close();
            Dispose();
        }

        private void CTBP21_Load(object eventSender, EventArgs eventArgs)
        {
            CbNiv = 6;
            ChTCtas = 2;
            CargarDatos();
        }

        public void Impresion()
        {
            var imp = new DataGridViewPrinterApplication1.frmMain();
            imp.imprimir(MALLA, "Plan de cuentas contables ", Empresa: datosEmpresa.Emp_Nombre);
        }

        private void CargarDatos()
        {
            short i;
            string Seleccion;
            var PosNiv = new short[11];
            short NumNiv;
            var Tniv = new short[11];
            string Espacios;
            // On Error GoTo HayErrores
            Espacios = Strings.Space(30);
            NumNiv = (short)emp.CtaNumNiveles;
            var loopTo = NumNiv;
            for (i = 1; i <= loopTo; i++)
                Tniv[i] = (short)Math.Round(Conversion.Val(Strings.Mid(emp.CtaNumDigNivel.ToString(), i, 1)));
            PosNiv[1] = 1;
            PosNiv[2] = (short)(PosNiv[1] + Tniv[1]);
            PosNiv[3] = (short)(PosNiv[2] + Tniv[2]);
            PosNiv[4] = (short)(PosNiv[3] + Tniv[3]);
            PosNiv[5] = (short)(PosNiv[4] + Tniv[4]);
            PosNiv[6] = (short)(PosNiv[5] + Tniv[5]);
            Pagina = 0;
            Seleccion = "";
            // If txtCtaIni.Text > "" And txtCtaFin.Text > txtCtaIni.Text Then
            // Seleccion = "AND Cta_codigo >= '" & txtCtaIni.Text & "' and Cta_codigo <= '" & txtCtaFin.Text & "' "
            // End If
            if (ChTCtas == 1)
                Seleccion += " AND CTA_AGRUPACION = 0 ";
            if (ChTCtas == 4)
                Seleccion += " AND ISNULL(clasificadores,'') <> '' ";
            string cod = "SELECT";
            cod = cod + " Case cta_nivel";
            cod = cod + " when 1 then cta_codigo";
            cod = cod + " when 2 then cta_codigo";
            cod = cod + " when 3 then cta_codigo";
            cod = cod + " when 4 then substring(cta_codigo,1," + (PosNiv[4] - 1) + ") + '.' + substring (cta_codigo," + PosNiv[4] + "," + Tniv[4] + " )";
            cod = cod + " when 5 then substring(cta_codigo,1," + (PosNiv[4] - 1) + ") + '.' + substring (cta_codigo," + PosNiv[4] + "," + Tniv[4] + " ) + '.' + substring (cta_codigo," + PosNiv[5] + "," + Tniv[5] + ") ";
            cod = cod + " when 6 then substring(cta_codigo,1," + (PosNiv[4] - 1) + ") + '.' + substring (cta_codigo," + PosNiv[4] + "," + Tniv[4] + " ) + '.' + substring (cta_codigo," + PosNiv[5] + "," + Tniv[5] + ") + '.' + substring (cta_codigo," + PosNiv[6] + "," + Tniv[6] + ") ";
            cod = cod + " End";
            cod = cod + " as Cuenta";
            cod = cod + ", Cta_nombre ";
            // cod = cod & " ,case cta_nivel"
            // cod = cod & " when 1 then  Cta_nombre"
            // cod = cod & " when 2 then '   ' + Cta_nombre"
            // cod = cod & " when 3 then '         ' + Cta_nombre"
            // cod = cod & " when 4 then '            ' + Cta_nombre"
            // cod = cod & " when 5 then '               ' + Cta_nombre"
            // cod = cod & " when 6 then '                  ' + Cta_nombre"
            // cod = cod & " End"
            cod = cod + " as NombreCuenta";
            cod = cod + " ,case  cta_grupo";
            cod = cod + " when 1 then 'Activos'";
            cod = cod + " when 2 then 'Pasivos'";
            cod = cod + " when 3 then 'Patrimonio'";
            cod = cod + " when 4 then 'Resultados'";
            cod = cod + " when 5 then 'Orden'";
            cod = cod + " End";
            cod = cod + " as CtaDe";
            cod = cod + ",ModuloAuxiliar";
            cod = cod + " ,case Cta_Agrupacion";
            cod = cod + " when 1 then 'Agrupación'";
            cod = cod + " Else  'Movimiento'";
            cod = cod + " End";
            cod = cod + " as TipoCta";
            cod = cod + ", Clasificadores";
            cod = cod + " From ADCCTA ";
            cod = cod + " WHERE Cta_Nivel<=" + Nivel.Text.Substring(Nivel.Text.Length - 1, 1) + " " + Seleccion + " ORDER BY Cta_Codigo , Cta_nombre ";
            if (ChTCtas == 3)
                cod = "Select IDCLAVECOM AS Nro,Com_Clave as Comodin,Com_Descripcion as Descripción from sys_Comodin ";
            var datS = new DataSet();
            var datA = new SqlDataAdapter(cod, datosEmpresa.strConxAdcom);
            datA.Fill(datS, "Datos");
            MALLA.DataSource = datS.Tables["Datos"];
            return;
        HayErrores:
            ;
        }

        private void Toolbar1_ButtonClick(object eventSender, EventArgs eventArgs)
        {
            ToolStripItem Button = (ToolStripItem)eventSender;
            switch (Button.Name ?? "")
            {
                case "btnactualizar":
                    {
                        CargarDatos();
                        break;
                    }

                case "btnimprimir":
                    {
                        break;
                    }
                // btImprimir_Click()
                case "btnsalir":
                    {
                        Close();
                        break;
                    }
            }
        }

        // Private Sub txtCtaFin_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs)
        // Dim KeyCode As Short = eventArgs.KeyCode
        // Dim Shift As Short = eventArgs.KeyData \ &H10000
        // Dim BCContab As New BuscaCtaContab
        // If System.Windows.Forms.Keys.F2 = KeyCode Then
        // txtCtaFin.Text = BCContab.IniciaCtas(txtCtaFin.Text)
        // '        Buscar(2)
        // ElseIf System.Windows.Forms.Keys.Return = KeyCode Then
        // Buscar(2)
        // End If
        // BCContab = Nothing
        // End Sub


        // Private Sub Buscar(ByRef op As Short)
        // '        Dim RsAux As New ADODB.Recordset
        // Dim cod As String = ""
        // '       Dim linkdat As New DaxData.DaxLibDatos
        // '        cod = "SELECT Cta_Codigo,Cta_Nombre FROM AdcCta WHERE Cta_Codigo='" & IIf(op = 1, txtCtaIni.Text, txtCtaFin.Text) & "'"
        // Dim RsAux = linkdat.DaxData("", cod) '.Open cod, ConxAdcom, adOpenKeyset, adLockOptimistic
        // If RsAux.EOF = False Then
        // If op = 1 Then
        // 'lbNomCta1 = RsAux!CTA_NOMBRE
        // Else
        // 'lbNomCta2 = RsAux!CTA_NOMBRE
        // End If
        // Else
        // 'If op = 1 Then
        // '    'lbNomCta1 = ""
        // '    txtCtaIni.Text = ""
        // 'Else
        // '    'lbNomCta2 = ""
        // '    txtCtaFin.Text = ""
        // 'End If
        // End If
        // RsAux = Nothing
        // linkdat = Nothing
        // End Sub

        // Private Sub txtCtaFin_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        // Buscar(2)
        // End Sub

        // Private Sub txtCtaIni_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs)
        // Dim KeyCode As Short = eventArgs.KeyCode
        // Dim Shift As Short = eventArgs.KeyData \ &H10000
        // Dim BCContab As New BuscaCtaContab

        // If System.Windows.Forms.Keys.F2 = KeyCode Then
        // '            txtCtaIni.Text = BCContab.IniciaCtas(txtCtaIni.Text)
        // Buscar(1)
        // ElseIf System.Windows.Forms.Keys.Return = KeyCode Then
        // Buscar(1)
        // End If
        // BCContab = Nothing
        // End Sub

        private void Nivel1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Nivel.Text = ((ToolStripMenuItem)sender).Text;
            CbNiv = 1;
        }

        private void Nivel2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Nivel.Text = ((ToolStripMenuItem)sender).Text;
            CbNiv = 2;
        }

        private void Nivel3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Nivel.Text = ((ToolStripMenuItem)sender).Text;
            CbNiv = 3;
        }

        private void Nivel4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Nivel.Text = ((ToolStripMenuItem)sender).Text;
            CbNiv = 4;
        }

        private void Nivel5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Nivel.Text = ((ToolStripMenuItem)sender).Text;
            CbNiv = 5;
        }

        private void Nivel6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Nivel.Text = ((ToolStripMenuItem)sender).Text;
            CbNiv = 6;
        }

        private void CtasMovimientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CuentaCtas.Text = ((ToolStripMenuItem)sender).Text;
            ChTCtas = 1;
        }

        private void TodasLasCtasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CuentaCtas.Text = ((ToolStripMenuItem)sender).Text;
            ChTCtas = 2;
        }

        private void ComodinesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CuentaCtas.Text = ((ToolStripMenuItem)sender).Text;
            ChTCtas = 3;
        }

        private void clasificadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CuentaCtas.Text = ((ToolStripMenuItem)sender).Text;
            ChTCtas = 4;
        }

        private void btnimprimir_ButtonClick(object sender, EventArgs e)
        {
            btnimprimir.ShowDropDown();
        }

        private void ImprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btImprimir_Click();
        }

        private void WordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var exp = new ExportarGrid.Form1();
            exp.Exportar(MALLA, "W", datosEmpresa.Emp_Nombre, "PLAN DE CUENTAS CONTABLES");
        }

        private void ExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var exp = new ExportarGrid.Form1();
            exp.Exportar(MALLA, "E", datosEmpresa.Emp_Nombre, "PLAN DE CUENTAS CONTABLES");
        }

        private void PDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var exp = new ExportarGrid.Form1();
            exp.Exportar(MALLA, "P", datosEmpresa.Emp_Nombre, "PLAN DE CUENTAS CONTABLES");
            CargarDatos();
        }
    }
}