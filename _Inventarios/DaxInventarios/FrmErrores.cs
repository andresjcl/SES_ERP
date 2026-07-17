using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using DattCom;

namespace ArtInvent
{
    public partial class FrmErrores : Form
    {
        private DataTable dtErrores;

        public FrmErrores()
        {
            InitializeComponent();
            CargarErrores();
        }

        private void CargarErrores()
        {
            try
            {
                dtErrores = SqlDatos.leerTablaAdcom(
                    "SELECT Tra_fecha, Doc_sucursal, Doc_Bodega, Opc_documento, " +
                    "Doc_numero, Tra_Codigo, Tra_nombre, Tra_cantidad, Tra_costuni, Errores " +
                    "FROM AdcTraErr ORDER BY Tra_fecha DESC");

                dgvErrores.DataSource = dtErrores;
                ConfigurarColumnas();
                ActualizarContador();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar errores: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private void ConfigurarColumnas()
        //{
        //    if (dgvErrores.Columns["Tra_fecha"] != null)
        //    {
        //        dgvErrores.Columns["Tra_fecha"].HeaderText = "Fecha";
        //        dgvErrores.Columns["Tra_fecha"].DefaultCellStyle.Format = "dd/MM/yyyy";
        //    }
        //    if (dgvErrores.Columns["Doc_sucursal"] != null)
        //        dgvErrores.Columns["Doc_sucursal"].HeaderText = "Sucursal";
        //    if (dgvErrores.Columns["Doc_Bodega"] != null)
        //        dgvErrores.Columns["Doc_Bodega"].HeaderText = "Bodega";
        //    if (dgvErrores.Columns["Opc_documento"] != null)
        //        dgvErrores.Columns["Opc_documento"].HeaderText = "Tipo Doc.";
        //    if (dgvErrores.Columns["Doc_numero"] != null)
        //        dgvErrores.Columns["Doc_numero"].HeaderText = "Nº Documento";
        //    if (dgvErrores.Columns["Tra_Codigo"] != null)
        //        dgvErrores.Columns["Tra_Codigo"].HeaderText = "Código Art.";
        //    if (dgvErrores.Columns["Tra_nombre"] != null)
        //        dgvErrores.Columns["Tra_nombre"].HeaderText = "Artículo";
        //    if (dgvErrores.Columns["Tra_cantidad"] != null)
        //        dgvErrores.Columns["Tra_cantidad"].HeaderText = "Cantidad";
        //    if (dgvErrores.Columns["Tra_costuni"] != null)
        //        dgvErrores.Columns["Tra_costuni"].HeaderText = "Costo Unit.";
        //    if (dgvErrores.Columns["Errores"] != null)
        //    {
        //        dgvErrores.Columns["Errores"].HeaderText = "Errores";
        //        dgvErrores.Columns["Errores"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        //    }

        //    foreach (DataGridViewColumn col in dgvErrores.Columns)
        //    {
        //        if (col.Name != "Errores")
        //            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        //    }
        //}


        private void ConfigurarColumnas()
        {
            // Primero, desactivar el autoajuste automático
            dgvErrores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvErrores.ScrollBars = ScrollBars.Both;

            if (dgvErrores.Columns["Tra_fecha"] != null)
            {
                dgvErrores.Columns["Tra_fecha"].HeaderText = "Fecha";
                dgvErrores.Columns["Tra_fecha"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvErrores.Columns["Tra_fecha"].Width = 100; // Ancho fijo
            }
            if (dgvErrores.Columns["Doc_sucursal"] != null)
            {
                dgvErrores.Columns["Doc_sucursal"].HeaderText = "Sucursal";
                dgvErrores.Columns["Doc_sucursal"].Width = 80;
            }
            if (dgvErrores.Columns["Doc_Bodega"] != null)
            {
                dgvErrores.Columns["Doc_Bodega"].HeaderText = "Bodega";
                dgvErrores.Columns["Doc_Bodega"].Width = 80;
            }
            if (dgvErrores.Columns["Opc_documento"] != null)
            {
                dgvErrores.Columns["Opc_documento"].HeaderText = "Tipo Doc.";
                dgvErrores.Columns["Opc_documento"].Width = 80;
            }
            if (dgvErrores.Columns["Doc_numero"] != null)
            {
                dgvErrores.Columns["Doc_numero"].HeaderText = "Nº Documento";
                dgvErrores.Columns["Doc_numero"].Width = 100;
            }
            if (dgvErrores.Columns["Tra_Codigo"] != null)
            {
                dgvErrores.Columns["Tra_Codigo"].HeaderText = "Código Art.";
                dgvErrores.Columns["Tra_Codigo"].Width = 120;
            }
            if (dgvErrores.Columns["Tra_nombre"] != null)
            {
                dgvErrores.Columns["Tra_nombre"].HeaderText = "Artículo";
                dgvErrores.Columns["Tra_nombre"].Width = 200;
            }
            if (dgvErrores.Columns["Tra_cantidad"] != null)
            {
                dgvErrores.Columns["Tra_cantidad"].HeaderText = "Cantidad";
                dgvErrores.Columns["Tra_cantidad"].Width = 80;
            }
            if (dgvErrores.Columns["Tra_costuni"] != null)
            {
                dgvErrores.Columns["Tra_costuni"].HeaderText = "Costo Unit.";
                dgvErrores.Columns["Tra_costuni"].Width = 100;
            }
            if (dgvErrores.Columns["Errores"] != null)
            {
                dgvErrores.Columns["Errores"].HeaderText = "Errores";
                dgvErrores.Columns["Errores"].Width = 300; // Ancho fijo más grande
                dgvErrores.Columns["Errores"].DefaultCellStyle.WrapMode = DataGridViewTriState.True; // Permitir wrapping
            }
        }

        private void ActualizarContador()
        {
            lblTotal.Text = $"Total de errores: {dgvErrores.Rows.Count}";
            lblSeleccionados.Text = $"Seleccionados: 0";
        }

        private void dgvErrores_SelectionChanged(object sender, EventArgs e)
        {
            lblSeleccionados.Text = $"Seleccionados: {dgvErrores.SelectedRows.Count}";
            btnEliminarSeleccionados.Enabled = dgvErrores.SelectedRows.Count > 0;
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            CargarErrores();
        }

        private void btnJustificarTodos_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de justificar TODOS los errores?\nEsta acción eliminará todos los registros de errores.",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    SqlDatos.ejecutarComandoAdcom("DELETE FROM AdcTraErr");
                    MessageBox.Show("Todos los errores han sido justificados.", "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarErrores();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al justificar: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEliminarSeleccionados_Click(object sender, EventArgs e)
        {
            if (dgvErrores.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione al menos un error para eliminar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"¿Eliminar {dgvErrores.SelectedRows.Count} error(es) seleccionado(s)?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    foreach (DataGridViewRow row in dgvErrores.SelectedRows)
                    {
                        string codigo = row.Cells["Tra_Codigo"].Value.ToString();
                        string fecha = Convert.ToDateTime(row.Cells["Tra_fecha"].Value).ToString("yyyy-MM-dd");
                        string docNumero = row.Cells["Doc_numero"].Value.ToString();

                        string sqlDelete = $"DELETE FROM AdcTraErr WHERE Tra_Codigo = '{codigo}' " +
                                          $"AND CAST(Tra_fecha AS DATE) = '{fecha}' AND Doc_numero = '{docNumero}'";
                        SqlDatos.ejecutarComandoAdcom(sqlDelete);
                    }

                    MessageBox.Show($"{dgvErrores.SelectedRows.Count} error(es) eliminado(s).", "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarErrores();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCopiar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvErrores.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Seleccione al menos una fila para copiar.", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                StringBuilder sb = new StringBuilder();
                // Encabezados
                foreach (DataGridViewColumn col in dgvErrores.Columns)
                {
                    sb.Append(col.HeaderText + "\t");
                }
                sb.AppendLine();

                // Datos
                foreach (DataGridViewRow row in dgvErrores.SelectedRows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        sb.Append(cell.Value?.ToString() + "\t");
                    }
                    sb.AppendLine();
                }

                Clipboard.SetText(sb.ToString());
                MessageBox.Show($"{dgvErrores.SelectedRows.Count} fila(s) copiadas al portapapeles.",
                    "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al copiar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                PrintDialog printDialog = new PrintDialog();
                PrintDocument printDocument = new PrintDocument();
                printDocument.PrintPage += PrintDocument_PrintPage;
                printDialog.Document = printDocument;

                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    printDocument.Print();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al imprimir: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Imprimir los errores seleccionados o todos
            DataTable dtPrint = dtErrores.Copy();
            if (dgvErrores.SelectedRows.Count > 0)
            {
                dtPrint.Clear();
                foreach (DataGridViewRow row in dgvErrores.SelectedRows)
                {
                    DataRow newRow = dtPrint.NewRow();
                    foreach (DataColumn col in dtPrint.Columns)
                    {
                        newRow[col.ColumnName] = row.Cells[col.ColumnName].Value;
                    }
                    dtPrint.Rows.Add(newRow);
                }
            }

            // Configurar impresión
            Font font = new Font("Courier New", 8);
            float y = 50;
            float x = 50;
            float lineHeight = font.GetHeight(e.Graphics) + 4;

            // Título
            Font titleFont = new Font("Arial", 14, FontStyle.Bold);
            e.Graphics.DrawString("REPORTE DE ERRORES DE RECOSTEO", titleFont, Brushes.Black, x, y);
            y += 30;

            // Fecha
            e.Graphics.DrawString($"Fecha: {DateTime.Now:dd/MM/yyyy HH:mm:ss}", font, Brushes.Black, x, y);
            y += 20;

            // Total
            e.Graphics.DrawString($"Total de errores: {dtPrint.Rows.Count}", font, Brushes.Black, x, y);
            y += 30;

            // Línea separadora
            e.Graphics.DrawLine(Pens.Black, x, y, e.PageBounds.Width - 50, y);
            y += 10;

            // Encabezados
            string[] headers = { "Fecha", "Suc", "Bod", "Tipo", "Nº Doc", "Código", "Artículo", "Cant", "Costo", "Errores" };
            float[] columnWidths = { 80, 40, 40, 50, 60, 70, 150, 50, 60, 200 };

            float currentX = x;
            for (int i = 0; i < headers.Length; i++)
            {
                e.Graphics.DrawString(headers[i], new Font("Courier New", 8, FontStyle.Bold), Brushes.Black, currentX, y);
                currentX += columnWidths[i];
            }
            y += lineHeight;

            // Línea separadora
            e.Graphics.DrawLine(Pens.Black, x, y, e.PageBounds.Width - 50, y);
            y += 5;

            // Datos
            foreach (DataRow row in dtPrint.Rows)
            {
                string fecha = Convert.ToDateTime(row["Tra_fecha"]).ToString("dd/MM/yy");
                string sucursal = row["Doc_sucursal"].ToString();
                string bodega = row["Doc_Bodega"].ToString();
                string tipoDoc = row["Opc_documento"].ToString();
                string numDoc = row["Doc_numero"].ToString();
                string codigo = row["Tra_Codigo"].ToString();
                string nombre = row["Tra_nombre"].ToString().Length > 15 ? row["Tra_nombre"].ToString().Substring(0, 15) + "..." : row["Tra_nombre"].ToString();
                string cantidad = row["Tra_cantidad"].ToString();
                string costo = row["Tra_costuni"].ToString();
                string errores = row["Errores"].ToString();

                string[] values = { fecha, sucursal, bodega, tipoDoc, numDoc, codigo, nombre, cantidad, costo, errores };

                currentX = x;
                for (int i = 0; i < values.Length; i++)
                {
                    e.Graphics.DrawString(values[i], font, Brushes.Black, currentX, y);
                    currentX += columnWidths[i];
                }
                y += lineHeight;

                // Si se acaba la página, pasar a la siguiente
                if (y > e.PageBounds.Height - 50)
                {
                    e.HasMorePages = true;
                    return;
                }
            }

            e.HasMorePages = false;
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Archivos CSV (*.csv)|*.csv|Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
                saveFileDialog.Title = "Exportar errores";
                saveFileDialog.DefaultExt = "csv";
                saveFileDialog.FileName = $"Errores_{DateTime.Now:yyyyMMdd_HHmmss}";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ExportarACSV(saveFileDialog.FileName);
                    MessageBox.Show($"Errores exportados correctamente a:\n{saveFileDialog.FileName}",
                        "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al exportar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportarACSV(string fileName)
        {
            // Obtener los datos a exportar (todas las filas o solo las seleccionadas)
            DataTable dtExport = dtErrores.Copy();

            // Si hay filas seleccionadas, exportar solo esas
            if (dgvErrores.SelectedRows.Count > 0)
            {
                dtExport.Clear();
                foreach (DataGridViewRow row in dgvErrores.SelectedRows)
                {
                    DataRow newRow = dtExport.NewRow();
                    foreach (DataColumn col in dtExport.Columns)
                    {
                        newRow[col.ColumnName] = row.Cells[col.ColumnName].Value;
                    }
                    dtExport.Rows.Add(newRow);
                }
            }

            // Crear el archivo CSV
            StringBuilder sb = new StringBuilder();

            // Encabezados
            string[] headers = { "Fecha", "Sucursal", "Bodega", "Tipo Doc", "Nº Documento",
                                "Código Art.", "Artículo", "Cantidad", "Costo Unit.", "Errores" };
            sb.AppendLine(string.Join(";", headers));

            // Datos
            foreach (DataRow row in dtExport.Rows)
            {
                string[] fields = new string[dtExport.Columns.Count];
                for (int i = 0; i < dtExport.Columns.Count; i++)
                {
                    string valor = row[i].ToString();
                    // Reemplazar comas y punto y coma para evitar problemas con CSV
                    valor = valor.Replace(";", ",");
                    // Si el campo contiene comillas, escaparlas
                    if (valor.Contains("\""))
                        valor = valor.Replace("\"", "\"\"");
                    // Encerrar en comillas si contiene caracteres especiales
                    if (valor.Contains(",") || valor.Contains("\n") || valor.Contains("\r"))
                        valor = $"\"{valor}\"";
                    fields[i] = valor;
                }
                sb.AppendLine(string.Join(";", fields));
            }

            // Guardar archivo con codificación UTF-8
            File.WriteAllText(fileName, sb.ToString(), Encoding.UTF8);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}