using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace GessDax
{
    class exportarTxt
    {
        public void iniciar(string separador, DataGridView tabla)
        {
            string file_name = direccion();

            System.IO.StreamWriter objWriter;

            objWriter = new System.IO.StreamWriter(file_name);

            foreach (DataGridViewRow rr in tabla.Rows)
            {
                string linea = "";
                for (int i = 0; i < tabla.ColumnCount; i++)
                {
                    linea += rr.Cells[i].Value.ToString() + separador;
                }
                    objWriter.WriteLine(linea);
            }
            objWriter.Close();
        }
        private string direccion()
        {
            string myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            //openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.CheckFileExists = false;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                myStream = openFileDialog1.FileName;
            }
            return myStream;
        }
        
    }    
}
