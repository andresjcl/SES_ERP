using System;
using System.IO;
using System.Windows.Forms;
using System.Text;

namespace SalidasDeMalla
{
    class ExportarCsv
    {
        public bool SaveToCSV(DataGridView DGV, string separador,bool conTitulos,SaveFileDialog sfd)
        {
            string FileName = NombreDestino.ArchivoDestino("CSV",sfd);
            if (FileName == "") return false;
            int columnCount = DGV.ColumnCount;
            string columnNames = "";
            string[] output = new string[DGV.RowCount + 1];
            int ini = 0;
            if (conTitulos)
            {
                for (int i = 0; i < columnCount; i++)
                {
                    columnNames += DGV.Columns[i].Name.ToString() + separador;
                }
                ini = 1;
                output[0] += columnNames;
            }
            for (int i = 0; i < DGV.RowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    output[ini] += DGV.Rows[i].Cells[j].FormattedValue.ToString() + separador;
                }
                ini++;
            }
            try
            {
                System.IO.File.WriteAllLines(FileName, output, System.Text.Encoding.UTF8);
                MessageBox.Show("Exportación a formato CSV correcta \n Su archivo a sido guardado como: " + FileName, "Exportacion datos AdcomDax", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("No se pudo exportar la información al archivo : " + FileName, "Exportacion datos AdcomDax", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            return true;
        }
       
    }
}
