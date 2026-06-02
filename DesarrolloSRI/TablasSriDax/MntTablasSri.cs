using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Threading.Tasks;
using DattCom;
using System.Windows.Forms;

namespace IvaRett
{
    public partial class MntTablasSri : Form
    {
        private int cambios = 0;
        private int ColNum = 0;
        private int FilNum = 0;
        private DataTable dt = new DataTable();
        string nom = "";

        public MntTablasSri()
        {
            InitializeComponent();
            cargarCombo();
            Botones();
        }

        private void cargarCombo()
        {
            nombreTablas prog = new nombreTablas();
            string[] tablas = prog.listaTablas();
            for (Int16 i = 0; i <= System.Convert.ToInt16(tablas.Length - 1); i++)
                cboTipo.Items.Add(tablas[i]);
        }
        private void cboTipo_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            nom = cboTipo.SelectedItem.ToString();
            Malla.DataSource = null;
            dt = new DataTable();
            string ssql = "select * from " + nom;
            Malla.Columns.Clear();
            try
            {
                dt=SqlDatos.leerTablaIvaret(ssql);
                Malla.DataSource = dt;
            }
            catch
            {
                MessageBox.Show("No existe la tabla " + nom + " en las base de datos ", "Registrar datos tablas delSRI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (nom == nombreTablas.ConceptosRetencion | nom == nombreTablas.RetencionIvaBienes | nom == nombreTablas.RetencionIvaServicios)
                btncontabilidad.Enabled = true;
            else
                btncontabilidad.Enabled = false;
            Malla.ShowCellToolTips = false;
            cambios = 0;
            Botones();
        }
        private void Malla_CellValueChanged(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            cambios += 1;
            Botones();
        }

        private void btnGuardar_Click(System.Object sender, System.EventArgs e)
        {
            guardar();
        }

        private void guardar()
        {
            try
            {
                string ssql = "select * from " + nom;
                SqlDataAdapter da = new SqlDataAdapter(ssql, datosEmpresa.strConxIvaret);
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                da.Update(dt);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"excepcion guardando tablas-SRI \n" + ex.Message);
            }
        }

        private void Malla_CellEnter(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            ColNum = e.ColumnIndex;
            FilNum = e.RowIndex;
        }

        private void btnSalir_Click(System.Object sender, System.EventArgs e)
        {
            Salir();
        }
        private void frmTablasSri_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            Salir();
        }
        private void Salir()
        {
            if (cambios > 0)
            {
                if (MessageBox.Show("Desea guardar los cambios?", "Mantenimiento tablas del Sri ", MessageBoxButtons.YesNo) == DialogResult.No) return;
                {
                    guardar();
                    this.Dispose();
                }
            }
            else
            {
                this.Dispose();
                Botones();
            }
        }

        private void Malla_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            {
                if (Malla.Columns[Convert.ToInt32(ColNum)].HeaderText == "IdCta1" | Malla.Columns[Convert.ToInt32(ColNum)].HeaderText == "IdCta2")
                {
                    if (e.KeyCode == Keys.F2)
                    {
                        string tipoMov = "S";
                        string nombre = "";
                        CtaMtn.BuscaCta ct = new CtaMtn.BuscaCta();
                        Malla.Rows[Convert.ToInt32(FilNum)].Cells[Convert.ToInt32(ColNum)].Value = ct.BuscaCtaCtb(ref nombre, ref tipoMov);
                    }
                }
            }
        }
        private void Malla_MouseLeave(object sender, System.EventArgs e)
        {
            Malla.EndEdit();
        }

        private void btnEnviar_ButtonClick(System.Object sender, System.EventArgs e)
        {
            btnEnviar.ShowDropDown();
        }

        private void ImprimirToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
               DataGridViewPrinterApplication1 .frmMain imp = new DataGridViewPrinterApplication1.frmMain();
                imp.imprimir(Malla, cboTipo.SelectedItem.ToString().ToUpper(), "", datosEmpresa.Emp_Nombre );
            }
            catch
            {
                MessageBox.Show ("Debe abrir una referencia para usar esta opción");
            }
        }

        private void WordToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                mallExp.Form1 exp = new mallExp.Form1();
                exp.Exportar(Malla, "W", datosEmpresa.Emp_Nombre, cboTipo.SelectedItem.ToString().ToUpper());
            }
            catch
            {
                MessageBox.Show ("Debe abrir una referencia para usar esta opción");
            }
        }

        private void ExcelToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                mallExp.Form1 exp = new mallExp.Form1();
                exp.Exportar(Malla, "E", datosEmpresa.Emp_Nombre, cboTipo.SelectedItem.ToString().ToUpper());
            }
            catch
            {
                MessageBox.Show("Debe abrir una referencia para usar esta opción");
            }
        }

        private void PDFToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                mallExp.Form1 exp = new mallExp.Form1();
                exp.Exportar(Malla, "P", datosEmpresa.Emp_Nombre , cboTipo.SelectedItem.ToString().ToUpper());
            }
            catch
            {
                MessageBox.Show("Debe abrir una referencia para usar esta opción");
            }
        }

        //    private void btnSalir_Click(System.Object sender, System.EventArgs e)
        //    {
        //        Salir();
        //    }
        //    private void frmTablasSri_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        //    {
        //        Salir();
        //    }
        //    private void Salir()
        //    {
        //        if (cambios > 0)
        //        {
        //            if (Interaction.MessageBox.Show("Desea guardar los cambios?", MessageBox.ShowStyle.YesNo) == Constants.vbYes)
        //            {
        //                guardar();
        //                this.Dispose();
        //            }
        //        }
        //        else
        //        {
        //            this.Dispose();
        //            Botones();
        //        }
        //    }


        private void CargarCodigos()
        {
            string codigoant = "";
            long porcentajeant = 0;
            string Codigo;
            long Porcentaje;
            string Concepto;
            string[] Pasar;
            int i;
            bool j = false;
            int l = 0;
            DateTime fechaini;
            DateTime fechafin;
            Pasar = new string[2];            
            foreach (DataGridViewRow RR in Malla.Rows)
            {
                if (RR.Cells["Descripción"].Value != null)
                {
                    Codigo = RR.Cells["código"].Value.ToString();
                    Porcentaje = 0;
                    if (cboTipo.Text.Substring(0, 12).ToUpper() == "RETENCIONIVA")
                    {
                        Concepto = cboTipo.Text + RR.Cells["Descripción"].Value.ToString();
                        Porcentaje = System.Convert.ToInt64("0" + RR.Cells["Descripción"].Value.ToString());
                    }
                    else
                    {
                        Porcentaje = System.Convert.ToInt64("0" + RR.Cells["porcentaje"].Value.ToString());
                        Concepto = System.Convert.ToString(RR.Cells["Descripción"].Value);
                    }

                    try
                    {
                        fechafin = (DateTime)RR.Cells["fechaFin"].Value;
                    }
                    catch { }
                    {
                        fechafin =  new DateTime (2999,12,31);
                    }

                    try
                    {
                        fechaini = (DateTime)RR.Cells["fechaInicio"].Value;
                    }
                    catch { }
                    {
                        fechaini = new DateTime(1900,1,1);
                    }

                    if (Porcentaje > 0 & DateTime.Now.Date >= fechaini & DateTime.Now.Date <= fechafin)
                    {
                        for (i = 0; i <= Pasar.Length; i++)
                        {
                            if (codigoant == Codigo & porcentajeant == Porcentaje)
                            {
                                j = true; break;
                            }
                        }
                        if (j == false)
                        {
                            l = l + 1;
                            var oldPasar = Pasar;
                            Pasar = new string[l + 1];
                            if (oldPasar != null)
                                Array.Copy(oldPasar, Pasar, Math.Min(l + 1, oldPasar.Length));
                            Pasar[l - 1] = Codigo + "," + Concepto.Replace ( ",", " ") + "," + Porcentaje;
                            codigoant = Codigo;
                            porcentajeant = Porcentaje;
                        }
                        j = false;
                    }
                }
            }
            ContabSri prog = new ContabSri(Malla, cboTipo.Text);
            // prog.tabla = cboTipo.Text
            // prog.Campos = Pasar
            prog.ShowDialog();
        }


        private void btncontabilidad_Click(System.Object sender, System.EventArgs e)
        {
            CargarCodigos();
        }
        private void Botones()
        {
            btnGuardar.Enabled = (cambios > 0);
        }
    }
}
//    private void cargarCombo()
//    {
//        nombreTablas prog = new nombreTablas();
//        string[] tablas = prog.listaTablas;
//        for (Int16 i = 0; i <= System.Convert.ToInt16(tablas.Length - 1); i++)
//            cboTipo.Items.Add(tablas[i]);
//    }
//    private void cboTipo_SelectedIndexChanged(System.Object sender, System.EventArgs e)
//    {
//        nombreTablas nomTabla = new nombreTablas();

//        nom = cboTipo.SelectedItem.ToString;
//        Malla.DataSource = null;
//        dt = new DataTable();
//        string ssql = "select * from " + nom;
//        Malla.Columns.Clear();
//        try
//        {
//            SqlDataAdapter da = new SqlDataAdapter(ssql, strConxIvaret);
//            da.Fill(dt);
//            Malla.DataSource = dt;
//        }
//        catch
//        {
//            MessageBox.Show("No existe la tabla " + nom + " en las base de datos ", "Registrar datos tablas delSRI", MessageBoxButtons.OK, MessageBoxIcon.Error);
//        }
//        if (nom == nomTabla.ConceptosRetencion | nom == nomTabla.RetencionIvaBienes | nom == nomTabla.RetencionIvaServicios)
//            btncontabilidad.Enabled = true;
//        else
//            btncontabilidad.Enabled = false;
//        Malla.ShowCellToolTips = false;
//        cambios = 0;
//        Botones();
//    }

//    private void Malla_CellValueChanged(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
//    {
//        cambios += 1;
//        Botones();
//    }

//    private void btnGuardar_Click(System.Object sender, System.EventArgs e)
//    {
//        Malla.EndEdit();
//        guardar();
//        cambios = 0;
//        Botones();
//        Malla.ClearSelection();
//    }

//    private void guardar()
//    {
//        try
//        {
//            string ssql = "select * from " + nom;
//            SqlDataAdapter da = new SqlDataAdapter(ssql, strConxIvaret);
//            SqlCommandBuilder cb = new SqlCommandBuilder(da);
//            da.Update(dt);
//        }
//        catch (Exception ex)
//        {
//            MessageBox.Show(@"excepcion guardando tablas-SRI \n" + ex.Message);
//        }
//    }
//    // Private Shared Function DataGridViewToDataTable(ByVal dtg As DataGridView, Optional ByVal DataTableName As String = "Tabla1") As DataTable
//    // Dim cont As Integer = 0
//    // Try
//    // Dim TablaDatos As New DataTable(DataTableName)
//    // Dim Fila As DataRow
//    // Dim TablaDatosTotalColumnas As Integer = dtg.ColumnCount - 1

//    // 'Agrega columna de datos
//    // For Each c As DataGridViewColumn In dtg.Columns
//    // Dim IColumna As DataColumn = New DataColumn()
//    // IColumna.ColumnName = c.Name
//    // TablaDatos.Columns.Add(IColumna)
//    // Next

//    // 'Ahora Iterar a través de Datagrid y crear la fila de datos

//    // For Each DataFila As DataGridViewRow In dtg.Rows
//    // 'Iterar a través de datagrid

//    // Fila = TablaDatos.NewRow 'Crear una línea nueva

//    // 'Iterar a través de la columna 1 hasta el número total de columnas de datagrid
//    // For cn As Integer = 0 To TablaDatosTotalColumnas
//    // Fila.Item(cn) = DataFila.Cells(cn).Value
//    // Next

//    // 'Ahora agregue la fila a la colección DataRow
//    // If cont <= dtg.RowCount - 2 Then TablaDatos.Rows.Add(Fila)
//    // cont += 1
//    // Next

//    // 'Ahora vuelve la tabla de datos
//    // Return TablaDatos
//    // Catch ex As Exception
//    // Return Nothing
//    // End Try
//    // End Function

//    private void Malla_CellEnter(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
//    {
//        ColNum = e.ColumnIndex;
//        FilNum = e.RowIndex;
//    }
//    private void Malla_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
//    {
//        {
//            var withBlock = Malla;
//            if (withBlock.Columns(Convert.ToInt32(ColNum)).HeaderText == "IdCta1" | withBlock.Columns(Convert.ToInt32(ColNum)).HeaderText == "IdCta2")
//            {
//                if (e.KeyCode == Keys.F2)
//                {
//                    MantCtb.BuscaCta ct = new MantCtb.BuscaCta();
//                    withBlock.Rows(Convert.ToInt32(FilNum)).Cells(Convert.ToInt32(ColNum)).Value = ct.BuscaCtaCtb("", "S");
//                }
//            }
//        }
//    }
//    private void Malla_MouseLeave(object sender, System.EventArgs e)
//    {
//        Malla.EndEdit();
//    }

//    private void btnEnviar_ButtonClick(System.Object sender, System.EventArgs e)
//    {
//        btnEnviar.ShowDropDown();
//    }

//    private void ImprimirToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
//    {
//        try
//        {
//            DataGridViewPrinterApplication1.frmMain imp = new DataGridViewPrinterApplication1.frmMain();
//            imp.imprimir(Malla, cboTipo.SelectedItem.ToString.ToUpper, "", SYSEMP.EmpresaAct.nombre);
//        }
//        catch
//        {
//            MessageBox.Show("Debe abrir una referencia para usar esta opción");
//        }
//    }

//    private void WordToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
//    {
//        try
//        {
//            mallExp.Form1 exp = new mallExp.Form1();
//            exp.Exportar(Malla, "W", SYSEMP.EmpresaAct.nombre, cboTipo.SelectedItem.ToString.ToUpper);
//        }
//        catch
//        {
//            MessageBox.Show("Debe abrir una referencia para usar esta opción");
//        }
//    }

//    private void ExcelToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
//    {
//        try
//        {
//            mallExp.Form1 exp = new mallExp.Form1();
//            exp.Exportar(Malla, "E", SYSEMP.EmpresaAct.nombre, cboTipo.SelectedItem.ToString.ToUpper);
//        }
//        catch
//        {
//            MessageBox.Show("Debe abrir una referencia para usar esta opción");
//        }
//    }

//    private void PDFToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
//    {
//        try
//        {
//            mallExp.Form1 exp = new mallExp.Form1();
//            exp.Exportar(Malla, "P", SYSEMP.EmpresaAct.nombre, cboTipo.SelectedItem.ToString.ToUpper);
//        }
//        catch
//        {
//            MessageBox.Show("Debe abrir una referencia para usar esta opción");
//        }
//    }

//    private void btnSalir_Click(System.Object sender, System.EventArgs e)
//    {
//        Salir();
//    }
//    private void frmTablasSri_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
//    {
//        Salir();
//    }
//    private void Salir()
//    {
//        if (cambios > 0)
//        {
//            if (Interaction.MessageBox.Show("Desea guardar los cambios?", MessageBox.ShowStyle.YesNo) == Constants.vbYes)
//            {
//                guardar();
//                this.Dispose();
//            }
//        }
//        else
//        {
//            this.Dispose();
//            Botones();
//        }
//    }

//    private void CargarCodigos()
//    {
//        // On Error Resume Next
//        string codigoant = "";
//        long porcentajeant = 0;
//        string Codigo;
//        long Porcentaje;
//        string Concepto;
//        string[] Pasar;
//        string PyC = "";
//        string Coma = ",";
//        int i;
//        bool j = false;
//        int l = 0;
//        DateTime fechaini;
//        DateTime fechafin;
//        Pasar = new string[2];
//        foreach (DataGridViewRow RR in Malla.Rows)
//        {
//            if (IsNothing(RR.Cells("Descripción").Value) == false)
//            {
//                Codigo = System.Convert.ToString(RR.Cells("código").Value);
//                Porcentaje = 0;
//                if (cboTipo.Text.Substring(0, 12).ToUpper == "RETENCIONIVA")
//                {
//                    Concepto = cboTipo.Text + RR.Cells("Descripción").Value.ToString();
//                    Porcentaje = System.Convert.ToInt64("0" + RR.Cells("Descripción").Value.ToString());
//                }
//                else
//                {
//                    Porcentaje = System.Convert.ToInt64("0" + RR.Cells("porcentaje").Value.ToString());
//                    Concepto = System.Convert.ToString(RR.Cells("Descripción").Value);
//                }

//                try
//                {
//                    fechafin = (DateTime)RR.Cells("fechaFin").Value;
//                }
//                catch (Exception ex)
//                {
//                    fechafin = (DateTime)"31/12/9999";
//                }

//                try
//                {
//                    fechaini = (DateTime)RR.Cells("fechaInicio").Value;
//                }
//                catch (Exception ex)
//                {
//                    fechaini = (DateTime)"01/01/1900";
//                }

//                if (Porcentaje > 0 & DateTime.Now.Date >= fechaini & DateTime.Now.Date <= fechafin)
//                {
//                    for (i = 0; i <= Pasar.Length; i++)
//                    {
//                        if (codigoant == Codigo & porcentajeant == Porcentaje)
//                        {
//                            j = true; break;
//                        }
//                    }
//                    if (j == false)
//                    {
//                        l = l + 1;
//                        var oldPasar = Pasar;
//                        Pasar = new string[l + 1];
//                        if (oldPasar != null)
//                            Array.Copy(oldPasar, Pasar, Math.Min(l + 1, oldPasar.Length));
//                        Pasar[l - 1] = Codigo + "," + Strings.Replace(Concepto, ",", " ") + "," + Porcentaje;
//                        codigoant = Codigo;
//                        porcentajeant = Porcentaje;
//                    }
//                    j = false;
//                }
//            }
//        }
//        frmContabilidad prog = new frmContabilidad(Malla, cboTipo.Text);
//        // prog.tabla = cboTipo.Text
//        // prog.Campos = Pasar
//        prog.ShowDialog();
//    }


//    private void btncontabilidad_Click(System.Object sender, System.EventArgs e)
//    {
//        CargarCodigos();
//    }
//    private void Botones()
//    {
//        btnGuardar.Enabled = System.Convert.ToBoolean(Interaction.IIf(cambios > 0, true, false));
//    }
//}
