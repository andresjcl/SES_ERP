using System;
using System.IO;
using System.Windows.Forms;

namespace SesFelec
{
    public partial class frmPreviewPdf : Form
    {
        string rutaPdf = "";

        public frmPreviewPdf(string pdf)
        {
            InitializeComponent();
            rutaPdf = pdf;
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
                MessageBox.Show("Error cargando PDF:\n" + ex.Message);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                axAcroPDF1.printAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al imprimir:\n" + ex.Message);
            }
        }
    }
}