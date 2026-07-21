using DattCom;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DaxInvent
{
    internal partial class frmPlato : Form
    {
        string tit1 = "";

        internal frmPlato(string cod)
        {
            InitializeComponent();
            CrearTablaSiNoExiste();
            verificarCodigoExterno(cod);

            ConfigurarDataGridView();

            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(frmPlato_KeyDown);
        }

        private void ConfigurarDataGridView()
        {
            Malla.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Malla.MultiSelect = false;
            Malla.AllowUserToAddRows = false;
            Malla.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;

            Malla.KeyDown += new KeyEventHandler(Malla_KeyDown);
            Malla.KeyPress += new KeyPressEventHandler(Malla_KeyPress);

            // Agregar evento para cuando se selecciona una celda
            Malla.CellClick += new DataGridViewCellEventHandler(Malla_CellClick);
        }

        private void CrearTablaSiNoExiste()
        {
            try
            {
                string sql = @"
            IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AdcComponPlato]') AND type in (N'U'))
            BEGIN
                CREATE TABLE [dbo].[AdcComponPlato](
                    [PLA_Tipo] [nvarchar](3) NOT NULL,
                    [PRO_Codigo] [nvarchar](15) NOT NULL,
                    [PLA_Codigo] [nvarchar](15) NOT NULL
                ) ON [PRIMARY]

                ALTER TABLE [dbo].[AdcComponPlato] ADD CONSTRAINT [PK_AdcComponPlato] PRIMARY KEY CLUSTERED 
                (
                    [PLA_Tipo] ASC,
                    [PRO_Codigo] ASC,
                    [PLA_Codigo] ASC
                ) ON [PRIMARY]

                CREATE NONCLUSTERED INDEX [IX_AdcComponPlato_PRO_Codigo] ON [dbo].[AdcComponPlato]
                (
                    [PRO_Codigo] ASC
                ) ON [PRIMARY]
            END";

                using (SqlConnection conn = new SqlConnection(datosEmpresa.strConxAdcom))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error al crear la tabla: {ex.Message}");
            }
        }

        #region Métodos para obtener nombres de bases de datos

        private string ObtenerBaseDatosSis()
        {
            try
            {
                if (!string.IsNullOrEmpty(datosEmpresa.nombreBaseSis))
                {
                    return datosEmpresa.nombreBaseSis;
                }
            }
            catch { }
            return "Daxsys";
        }

        #endregion

        private void verificarCodigoExterno(string codigoExterno)
        {
            if (codigoExterno != "")
            {
                txtCodigo.Text = codigoExterno;
                labArticulo.Text = leerArticulo(codigoExterno);
                LlenarMalla(codigoExterno);

                // Agregar una fila vacía al final después de cargar
                DataTable dt = Malla.DataSource as DataTable;
                if (dt != null)
                {
                    // Verificar si ya hay una fila vacía al final
                    bool tieneFilaVacia = false;
                    if (dt.Rows.Count > 0)
                    {
                        object valor = dt.Rows[dt.Rows.Count - 1]["PLA_Codigo"];
                        if (valor == null || string.IsNullOrEmpty(valor.ToString()))
                        {
                            tieneFilaVacia = true;
                        }
                    }

                    if (!tieneFilaVacia)
                    {
                        DataRow newRow = dt.NewRow();
                        dt.Rows.Add(newRow);
                        Malla.Refresh();
                    }
                }
            }
        }

        private void LlenarMalla(string codigoArt)
        {
            try
            {
                string baseDatosSis = ObtenerBaseDatosSis();

                DataTable dt = new DataTable();
                string ssql = @"
                    SELECT PLA_Codigo, a.Descripcion 
                    FROM AdcComponPlato AS c 
                    LEFT OUTER JOIN " + baseDatosSis + @".dbo.Syscod AS a 
                        ON c.PLA_Codigo = a.Abreviación 
                    WHERE c.pro_codigo = @CodigoArt 
                        AND a.tiporeferencia = 'CambioPlatos' 
                    ORDER BY c.PLA_Codigo";

                using (SqlConnection conn = new SqlConnection(datosEmpresa.strConxAdcom))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(ssql, conn))
                    {
                        cmd.Parameters.AddWithValue("@CodigoArt", codigoArt);
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }

                Malla.DataSource = dt;
                DisenarMalla();
                dt.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisenarMalla()
        {
            try
            {
                if (Malla.Columns.Contains("PLA_Codigo"))
                {
                    Malla.Columns["PLA_Codigo"].HeaderText = "Código";
                    Malla.Columns["PLA_Codigo"].Width = 100;
                    Malla.Columns["PLA_Codigo"].ReadOnly = false;
                }

                if (Malla.Columns.Contains("Descripcion"))
                {
                    Malla.Columns["Descripcion"].HeaderText = "Descripción";
                    Malla.Columns["Descripcion"].Width = 300;
                    Malla.Columns["Descripcion"].ReadOnly = true;
                }
            }
            catch { }
        }

        private string leerArticulo(string codigo)
        {
            string resultado = "";
            try
            {
                string ssql = "SELECT art_nombre FROM adcart WHERE art_codigo = @Codigo";
                using (SqlConnection conn = new SqlConnection(datosEmpresa.strConxAdcom))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(ssql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Codigo", codigo);
                        object valor = cmd.ExecuteScalar();
                        if (valor != null)
                        {
                            resultado = valor.ToString();
                        }
                        else
                        {
                            MessageBox.Show("El artículo digitado no existe", "Buscar articulo");
                            resultado = "";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                resultado = "";
            }
            return resultado;
        }

        private string leerPlatoNombre(string codigo)
        {
            string resultado = "";
            try
            {
                string baseDatosSis = ObtenerBaseDatosSis();
                string ssql = @"
                    SELECT Descripcion 
                    FROM " + baseDatosSis + @".dbo.Syscod 
                    WHERE tiporeferencia = 'CambioPlatos' 
                        AND Abreviación <> '#' 
                        AND Abreviación = @Codigo";

                using (SqlConnection conn = new SqlConnection(datosEmpresa.strConxAdcom))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(ssql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Codigo", codigo);
                        object valor = cmd.ExecuteScalar();
                        if (valor != null)
                        {
                            resultado = valor.ToString();
                        }
                        else
                        {
                            MessageBox.Show("El plato digitado no existe", "Buscar plato");
                            resultado = "";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                resultado = "";
            }
            return resultado;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtCodigo.Text))
                {
                    MessageBox.Show("Debe seleccionar un artículo principal.", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string ssql = "SELECT * FROM AdcComponPlato WHERE pro_codigo = @Codigo";

                using (SqlConnection conn = new SqlConnection(datosEmpresa.strConxAdcom))
                {
                    conn.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(ssql, conn))
                    {
                        da.SelectCommand.Parameters.AddWithValue("@Codigo", txtCodigo.Text);

                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        SqlCommandBuilder cb = new SqlCommandBuilder(da);

                        string platoTipo = "PLA";

                        foreach (DataGridViewRow grRow in Malla.Rows)
                        {
                            if (grRow.Cells["PLA_Codigo"].Value == null) continue;
                            if (string.IsNullOrEmpty(grRow.Cells["PLA_Codigo"].Value.ToString())) continue;

                            string codCompnte = grRow.Cells["PLA_Codigo"].Value.ToString();
                            Boolean esIgual = false;

                            foreach (DataRow dtRow in dt.Rows)
                            {
                                if (codCompnte == dtRow["PLA_Codigo"].ToString())
                                {
                                    dtRow["PRO_Codigo"] = txtCodigo.Text;
                                    dtRow["PLA_Codigo"] = grRow.Cells["PLA_Codigo"].Value;
                                    dtRow["PLA_Tipo"] = platoTipo;
                                    esIgual = true;
                                    break;
                                }
                            }

                            if (!esIgual)
                            {
                                DataRow nRow = dt.NewRow();
                                nRow["PRO_Codigo"] = txtCodigo.Text;
                                nRow["PLA_Codigo"] = grRow.Cells["PLA_Codigo"].Value;
                                nRow["PLA_Tipo"] = platoTipo;
                                dt.Rows.Add(nRow);
                            }
                        }

                        Boolean seElimino = true;
                        do
                        {
                            seElimino = false;
                            try
                            {
                                foreach (DataRow dtRow in dt.Rows)
                                {
                                    if (!existeEnMalla(dtRow["PLA_Codigo"].ToString()))
                                    {
                                        dtRow.Delete();
                                        seElimino = true;
                                    }
                                }
                            }
                            catch { }
                        } while (seElimino);

                        da.Update(dt);
                        dt.AcceptChanges();
                    }
                }

                MessageBox.Show("Datos guardados correctamente", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error de base de datos: {ex.Message}\n\n" +
                    $"Número de error: {ex.Number}", "Error SQL",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Boolean existeEnMalla(string codigo)
        {
            foreach (DataGridViewRow grRow in Malla.Rows)
            {
                if (grRow.Cells["PLA_Codigo"].Value == null) continue;
                if (codigo == grRow.Cells["PLA_Codigo"].Value.ToString())
                {
                    return true;
                }
            }
            return false;
        }

        // ============================================
        // EVENTO KEYDOWN DEL FORMULARIO
        // ============================================
        private void frmPlato_KeyDown(object sender, KeyEventArgs e)
        {
            if (Malla.Focused && Malla.CurrentCell != null)
            {
                if (e.KeyCode == Keys.F2)
                {
                    string columnaActual = Malla.Columns[Malla.CurrentCell.ColumnIndex].Name;
                    if (columnaActual == "PLA_Codigo")
                    {
                        buscarPreferenciaPlato();
                        e.Handled = true;
                        e.SuppressKeyPress = true;
                    }
                }

                if (e.KeyCode == Keys.Enter)
                {
                    string columnaActual = Malla.Columns[Malla.CurrentCell.ColumnIndex].Name;
                    if (columnaActual == "PLA_Codigo")
                    {
                        int rowIndex = Malla.CurrentCell.RowIndex;
                        object valor = Malla.Rows[rowIndex].Cells["PLA_Codigo"].Value;
                        bool tieneValor = valor != null && !string.IsNullOrEmpty(valor.ToString());

                        if (tieneValor)
                        {
                            MoverASiguienteFilaVacia(rowIndex);
                            e.Handled = true;
                            e.SuppressKeyPress = true;
                        }
                        else
                        {
                            Malla.BeginEdit(true);
                            e.Handled = true;
                            e.SuppressKeyPress = true;
                        }
                    }
                }
            }
        }

        // ============================================
        // EVENTO KEYDOWN DEL DATAGRIDVIEW
        // ============================================
        private void Malla_KeyDown(object sender, KeyEventArgs e)
        {
            if (Malla.CurrentCell == null) return;

            string columnaActual = Malla.Columns[Malla.CurrentCell.ColumnIndex].Name;

            if (e.KeyCode == Keys.F2 && columnaActual == "PLA_Codigo")
            {
                buscarPreferenciaPlato();
                e.Handled = true;
                e.SuppressKeyPress = true;
                return;
            }

            if (e.KeyCode == Keys.Enter && columnaActual == "PLA_Codigo")
            {
                int rowIndex = Malla.CurrentCell.RowIndex;
                object valor = Malla.Rows[rowIndex].Cells["PLA_Codigo"].Value;
                bool tieneValor = valor != null && !string.IsNullOrEmpty(valor.ToString());

                if (tieneValor)
                {
                    MoverASiguienteFilaVacia(rowIndex);
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
                else
                {
                    Malla.BeginEdit(true);
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }
        }

        // ============================================
        // EVENTO KEYPRESS
        // ============================================
        private void Malla_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.F2)
            {
                e.Handled = true;
            }
        }

        // ============================================
        // EVENTO CLICK PARA SELECCIONAR CELDA
        // ============================================
        private void Malla_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Si se hace clic en la columna "PLA_Codigo" y la celda está vacía, comenzar edición
            if (e.ColumnIndex >= 0 && Malla.Columns[e.ColumnIndex].Name == "PLA_Codigo")
            {
                if (e.RowIndex >= 0 && e.RowIndex < Malla.Rows.Count)
                {
                    object valor = Malla.Rows[e.RowIndex].Cells["PLA_Codigo"].Value;
                    if (valor == null || string.IsNullOrEmpty(valor.ToString()))
                    {
                        // Si la celda está vacía, comenzar edición automáticamente
                        this.BeginInvoke((MethodInvoker)delegate
                        {
                            Malla.CurrentCell = Malla.Rows[e.RowIndex].Cells["PLA_Codigo"];
                            Malla.BeginEdit(true);
                        });
                    }
                }
            }
        }

        // ============================================
        // MOVER A LA SIGUIENTE FILA VACÍA
        // ============================================
        private void MoverASiguienteFilaVacia(int rowIndex)
        {
            DataTable dt = Malla.DataSource as DataTable;
            if (dt == null) return;

            try
            {
                int nextEmptyRow = -1;

                // Buscar la siguiente fila vacía desde la fila actual + 1
                for (int i = rowIndex + 1; i < dt.Rows.Count; i++)
                {
                    object val = dt.Rows[i]["PLA_Codigo"];
                    if (val == null || string.IsNullOrEmpty(val.ToString()))
                    {
                        nextEmptyRow = i;
                        break;
                    }
                }

                // Si no encontró fila vacía, crear una nueva al final
                if (nextEmptyRow == -1)
                {
                    DataRow newRow = dt.NewRow();
                    dt.Rows.Add(newRow);
                    Malla.Refresh();
                    nextEmptyRow = dt.Rows.Count - 1;
                }

                // Mover el foco a la fila vacía
                if (nextEmptyRow >= 0 && nextEmptyRow < Malla.Rows.Count)
                {
                    // Usar BeginInvoke para asegurar que se ejecute después de procesar el evento
                    this.BeginInvoke((MethodInvoker)delegate
                    {
                        Malla.CurrentCell = Malla.Rows[nextEmptyRow].Cells["PLA_Codigo"];
                        Malla.BeginEdit(true);
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================
        // AL FINALIZAR EDICIÓN
        // ============================================
        private void Malla_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0) return;
            if (Malla.Columns[e.ColumnIndex].Name != "PLA_Codigo") return;

            DataGridViewRow row = Malla.Rows[e.RowIndex];

            if (row.Cells["PLA_Codigo"].Value != null &&
                !string.IsNullOrEmpty(row.Cells["PLA_Codigo"].Value.ToString()))
            {
                DataTable dt = Malla.DataSource as DataTable;
                if (dt != null)
                {
                    // Verificar si hay una fila vacía al final
                    bool tieneFilaVacia = false;
                    for (int i = e.RowIndex + 1; i < dt.Rows.Count; i++)
                    {
                        object val = dt.Rows[i]["PLA_Codigo"];
                        if (val == null || string.IsNullOrEmpty(val.ToString()))
                        {
                            tieneFilaVacia = true;
                            break;
                        }
                    }

                    if (!tieneFilaVacia)
                    {
                        DataRow newRow = dt.NewRow();
                        dt.Rows.Add(newRow);
                        Malla.Refresh();
                    }
                }
            }
        }

        // ============================================
        // BUSCAR PLATO
        // ============================================
        private void buscarPreferenciaPlato()
        {
            string codigo = buscadorPlato();
            if (!string.IsNullOrEmpty(codigo))
            {
                Int32 indRow = Malla.CurrentCell.RowIndex;
                Malla.CurrentCell.Value = codigo;
                Malla.Rows[indRow].Cells["Descripcion"].Value = leerPlatoNombre(codigo);

                DataTable dt = Malla.DataSource as DataTable;
                if (dt != null)
                {
                    bool tieneFilaVacia = false;
                    for (int i = indRow + 1; i < dt.Rows.Count; i++)
                    {
                        object val = dt.Rows[i]["PLA_Codigo"];
                        if (val == null || string.IsNullOrEmpty(val.ToString()))
                        {
                            tieneFilaVacia = true;
                            break;
                        }
                    }

                    if (!tieneFilaVacia)
                    {
                        DataRow newRow = dt.NewRow();
                        dt.Rows.Add(newRow);
                        Malla.Refresh();
                    }
                }
            }
        }

        private string buscadorPlato()
        {
            frmBuscarPreferenciaPlato busplato = new frmBuscarPreferenciaPlato();
            string codart = busplato.IniciaBuscaPlato(Malla.CurrentCell.Value?.ToString() ?? "", "");
            return codart;
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            limpiar();
        }

        private void limpiar()
        {
            Malla.Columns.Clear();
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                buscarPlatoPrincipal();
            }
            if (e.KeyCode == Keys.Return && txtCodigo.Text.Length > 0)
            {
                limpiar();
                LlenarMalla(txtCodigo.Text);
                labArticulo.Text = leerArticulo(txtCodigo.Text);

                DataTable dt = Malla.DataSource as DataTable;
                if (dt != null && dt.Rows.Count > 0)
                {
                    bool tieneFilaVacia = false;
                    object valor = dt.Rows[dt.Rows.Count - 1]["PLA_Codigo"];
                    if (valor == null || string.IsNullOrEmpty(valor.ToString()))
                    {
                        tieneFilaVacia = true;
                    }

                    if (!tieneFilaVacia)
                    {
                        DataRow newRow = dt.NewRow();
                        dt.Rows.Add(newRow);
                        Malla.Refresh();
                    }
                }
            }
        }

        private void buscarPlatoPrincipal()
        {
            frmBuscarPreferenciaPlato busplato = new frmBuscarPreferenciaPlato();
            string codigo = busplato.IniciaBuscaPlato(txtCodigo.Text, "");
            if (!string.IsNullOrEmpty(codigo))
            {
                txtCodigo.Text = codigo;
                labArticulo.Text = leerArticulo(codigo);
                LlenarMalla(codigo);

                DataTable dt = Malla.DataSource as DataTable;
                if (dt != null && dt.Rows.Count > 0)
                {
                    bool tieneFilaVacia = false;
                    object valor = dt.Rows[dt.Rows.Count - 1]["PLA_Codigo"];
                    if (valor == null || string.IsNullOrEmpty(valor.ToString()))
                    {
                        tieneFilaVacia = true;
                    }

                    if (!tieneFilaVacia)
                    {
                        DataRow newRow = dt.NewRow();
                        dt.Rows.Add(newRow);
                        Malla.Refresh();
                    }
                }
            }
        }

        private void frmPlato_Load(object sender, EventArgs e)
        {
            DataTable dt = Malla.DataSource as DataTable;
            if (dt != null && dt.Rows.Count == 0)
            {
                DataRow newRow = dt.NewRow();
                dt.Rows.Add(newRow);
                Malla.Refresh();
            }

            this.ActiveControl = Malla;
        }
    }
}