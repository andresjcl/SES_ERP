using System;
using System.IO;
using System.Windows.Forms;

namespace ImpresionDocumentosDax
{
    public partial class frmPreviewPdf : Form
    {
        string rutaPdf = "";
        private bool _isDisposing = false;

        public frmPreviewPdf(string pdf)
        {
            InitializeComponent();
            rutaPdf = pdf;

            // Configurar el formulario
            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void frmPreviewPdf_Load(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(rutaPdf))
                {
                    MessageBox.Show("No se encontró el archivo PDF.");
                    this.Close();
                    return;
                }

                if (axAcroPDF1 == null)
                {
                    MessageBox.Show("Error: No se pudo inicializar el visor de PDF.", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }
                // Cargar PDF
                axAcroPDF1.LoadFile(rutaPdf);

                
                // Ir a la primera página
                axAcroPDF1.setCurrentPage(0);

                // Zoom 100%
                axAcroPDF1.setZoom(100);

                // Ajustar vista
                axAcroPDF1.setView("Fit");

                // Mostrar toolbar
                axAcroPDF1.setShowToolbar(true);

                // Refrescar visor
                axAcroPDF1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando PDF:\n{ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                if (axAcroPDF1 != null)
                {
                    axAcroPDF1.printAll();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al imprimir:\n{ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmPreviewPdf_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (axAcroPDF1 != null)
                {
                    axAcroPDF1.src = "";
                }
            }
            catch { }
        }
    }
}