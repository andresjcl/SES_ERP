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
    public partial class frmBuscarPreferenciaPlato : Form
    {
        string CodigoRet = "";
        string Dedonde = "";
        string CodigoArt = "";

        public frmBuscarPreferenciaPlato()
        {
            InitializeComponent();
        }

        private void frmBuscarPreferenciaPlato_Load(object sender, EventArgs e)
        {
            ArreglaMalla();
        }

        private void ArreglaMalla()
        {
            try
            {
                DataTable Rs = new DataTable();
                string baseDatosSis = ObtenerBaseDatosSis();

                string codsql = @"
                    SELECT Abreviación, Descripcion 
                    FROM " + baseDatosSis + @".dbo.Syscod 
                    WHERE tiporeferencia = @TipoReferencia 
                        AND Abreviación <> @Excluir 
                    ORDER BY Descripcion";

                using (SqlConnection conn = new SqlConnection(datosEmpresa.strConxAdcom))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(codsql, conn))
                    {
                        cmd.Parameters.AddWithValue("@TipoReferencia", "CambioPlatos");
                        cmd.Parameters.AddWithValue("@Excluir", "#");

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(Rs);
                        }
                    }
                }

                // Asignar datos al DataGridView
                malla.DataSource = Rs;

                // Configurar columnas
                if (malla.Columns.Contains("Abreviación"))
                {
                    malla.Columns["Abreviación"].HeaderText = "Código";
                    malla.Columns["Abreviación"].Width = 80;
                }

                if (malla.Columns.Contains("Descripcion"))
                {
                    malla.Columns["Descripcion"].HeaderText = "Descripción";
                    malla.Columns["Descripcion"].Width = 300;
                }

                // Seleccionar la primera fila si existe
                if (Rs.Rows.Count > 0)
                {
                    malla.CurrentCell = malla.Rows[0].Cells[0];
                    malla.Rows[0].Selected = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la lista de platos: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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
            return "Daxsys"; // Valor por defecto
        }

        public string IniciaBuscaPlato(string codigo, string DeDon, string ipo = "", string fecha = "", string Bodega = "")
        {
            Dedonde = DeDon;
            CodigoArt = codigo;
            txtDescripcion.Text = codigo;
            this.ShowDialog();
            return CodigoRet;
        }

        private void btnSalida_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkOrdenCodigo_CheckedChanged(object sender, EventArgs e)
        {
            ArreglaMalla();
        }

        private void txtDescripcion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return) ArreglaMalla();
        }

        private void malla_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (malla.CurrentRow != null && malla.CurrentRow.Cells["Abreviación"].Value != null)
                {
                    CodigoRet = malla.CurrentRow.Cells["Abreviación"].Value.ToString();
                    this.Close();
                }
            }
            catch { CodigoRet = ""; }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ArreglaMalla();
        }
    }
}