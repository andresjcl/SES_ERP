using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalidasDeMalla
{
    class NombreDestino
    {

        internal static string ArchivoDestino(string tipo, SaveFileDialog sfd)
        {
            string filename = "";
            sfd.Filter = tipo+" (*."+tipo+")|*."+tipo;
            sfd.FileName = "Output."+tipo;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                filename = sfd.FileName;
                if (File.Exists(filename))
                {
                        try
                        {
                            File.Delete(filename);
                        }
                        catch (IOException ex)
                        {
                            MessageBox.Show("No es posible guardar los datos en el archivo especificado " + ex.Message);
                            filename = "";
                        }
                }
            }
            return filename;
        }
        internal static string archivoGrabar(string opcion)
        {
            string NombreArchivo = "";
            string Extencion = "Archivos tipo excel(*.xls) | *.xls";
            if (opcion == "W") Extencion = "Archivos tipo word (*.doc)|*.doc";
            if (opcion == "P") Extencion = "Archivos tipo pdf (*.pdf)|*.pdf";
            if (opcion == "C") Extencion = "Archivos tipo pdf (*.pdf)|*.CSV";

            SaveFileDialog SaveFileDialog1 = new SaveFileDialog();
            SaveFileDialog1.OverwritePrompt = true;
            SaveFileDialog1.Title = "Registrar nombre de archivo para exportar información";
            SaveFileDialog1.InitialDirectory = "\tmp";
            SaveFileDialog1.Filter = Extencion;

            if (SaveFileDialog1.ShowDialog() == DialogResult.OK)
            { NombreArchivo = SaveFileDialog1.FileName; }
            else { NombreArchivo = ""; }



            return NombreArchivo;
        }

    }
}
