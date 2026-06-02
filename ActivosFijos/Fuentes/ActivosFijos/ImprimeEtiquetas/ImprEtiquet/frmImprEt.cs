using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
namespace ImprEtiquet

{
    public partial class frmImprEt : Form
    {
        public frmImprEt()
        {
            InitializeComponent();

            llenarMalla();
        }
        private void llenarMalla()
        {
            string ssql = "select Codigo, Nombre, TipoActivo, Categoria, Clase, Grupo, Cantidad FROM  AdcAcf ";
            using (SqlDataAdapter da = new SqlDataAdapter(ssql, varbleComun.VarCom.strConxAdcom))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                malla.DataSource = dt;
                disenarMalla();
            }
        }
        private void disenarMalla()
        {
            malla.Columns["Codigo"].ReadOnly=true;
            malla.Columns["Nombre"].ReadOnly = true;
            malla.Columns["TipoActivo"].ReadOnly = true;
            malla.Columns["Categoria"].ReadOnly = true;
            malla.Columns["Clase"].ReadOnly = true;
            malla.Columns["Grupo"].ReadOnly = true;
            malla.Columns["Cantidad"].DefaultCellStyle.Format = "####";
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

		private void CamposDisponibles_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{	
			if(CamposDisponibles.Items.Count==0) return;
			string s = CamposDisponibles.Items[CamposDisponibles.IndexFromPoint(e.X,e.Y)].ToString();			
			DragDropEffects dde1=DoDragDrop(s,DragDropEffects.All);
			
			if(dde1 == DragDropEffects.All )
			{
				CamposDisponibles.Items.RemoveAt(CamposDisponibles.IndexFromPoint(e.X,e.Y));				
			}		
			
		}

		private void CamposParaEtiqueta_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
		{
			if(e.Data.GetDataPresent(DataFormats.StringFormat))
			{				
				string str= (string)e.Data.GetData(DataFormats.StringFormat);
				CamposParaEtiqueta.Items.Add(str);				
			}
			
		}

		private void CamposParaEtiqueta_DragOver(object sender, System.Windows.Forms.DragEventArgs e)
		{
			e.Effect=DragDropEffects.All;
		}

        private void btnPasaUno_Click(object sender, EventArgs e)
        {
            if (CamposDisponibles.Items.Count == 0) return;
            if (CamposDisponibles.SelectedItem == null) return;
            CamposParaEtiqueta.Items.Add ( CamposDisponibles.Items[CamposDisponibles.SelectedIndex].ToString());
            CamposDisponibles.Items.Remove(CamposDisponibles.SelectedItem);
        }

        private void btnRegresaUno_Click(object sender, EventArgs e)
        {
            if (CamposParaEtiqueta.Items.Count == 0) return;
            if (CamposParaEtiqueta.SelectedItem == null) return;
            CamposDisponibles.Items.Add(CamposParaEtiqueta.Items[CamposParaEtiqueta.SelectedIndex].ToString());
            CamposParaEtiqueta.Items.Remove(CamposParaEtiqueta.SelectedItem);
        }

        private void btnPasaTodos_Click(object sender, EventArgs e)
        {
            if (CamposDisponibles.Items.Count == 0) return;
            for (int i = 0;i<CamposDisponibles.Items.Count;i++)
            {
                CamposParaEtiqueta.Items.Add(CamposDisponibles.Items[i]);
            }
            CamposDisponibles.Items.Clear();
        }

        private void btnRegresaTodos_Click(object sender, EventArgs e)
        {
            if (CamposParaEtiqueta.Items.Count == 0) return;
            for (int i = 0; i < CamposParaEtiqueta.Items.Count; i++)
            {
                CamposDisponibles.Items.Add(CamposParaEtiqueta.Items[i]);
            }
            CamposParaEtiqueta.Items.Clear();

        }

        private void CamposParaEtiqueta_KeyDown(object sender, KeyEventArgs e)
        {
            if (CamposParaEtiqueta.Items.Count == 0) return;
            if (CamposParaEtiqueta.SelectedItem == null) return;
            if (e.KeyCode == Keys.Up)
            {
                int ind = CamposParaEtiqueta.SelectedIndex;
                if (ind < 1) return;
                string bak = CamposParaEtiqueta.SelectedItem.ToString();
                CamposParaEtiqueta.Items[ind] = CamposParaEtiqueta.Items[ind - 1];
                CamposParaEtiqueta.Items[ind - 1] = bak;
                CamposParaEtiqueta.ClearSelected();
                CamposParaEtiqueta.SelectedItem = CamposParaEtiqueta.Items[ind - 1];                
            }
            else if (e.KeyCode == Keys.Down)
            {
                int ind = CamposParaEtiqueta.SelectedIndex;
                if (ind >= CamposParaEtiqueta.Items.Count - 1) return;
                string bak = CamposParaEtiqueta.SelectedItem.ToString();
                CamposParaEtiqueta.Items[ind] = CamposParaEtiqueta.Items[ind + 1];
                CamposParaEtiqueta.Items[ind + 1] = bak;
                CamposParaEtiqueta.ClearSelected();
                CamposParaEtiqueta.SelectedItem = CamposParaEtiqueta.Items[ind + 1];

            }
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            // PJC40L3429C1160;JH 040L MANGA LARGA 429 C1 16;40;7861145653741;21.12;429;160;C1;40

            if (CamposParaEtiqueta.Items.Count == 0) return;
            string ssqlRead = "";
            string separador = "";
            string armarLinea = "";
            string NomFile = NombreArchivo();
            if (NomFile == "") { return; }
            StreamWriter sw = new StreamWriter(NomFile,false);

            for(int i = 0;i<CamposParaEtiqueta.Items.Count;i++)
            {
                ssqlRead += separador + CamposParaEtiqueta.Items[i].ToString();
                separador = ",";
            }
            SqlConnection conn = new SqlConnection(varbleComun.VarCom.strConxAdcom);
            conn.Open();
            foreach (DataGridViewRow vro in malla.SelectedRows)
            {
                string ssql = "select " + ssqlRead + " from adcacf where codigo = '" + vro.Cells["codigo"].Value.ToString() + "'";
                SqlCommand comm =  new SqlCommand(ssql,conn);
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.Read())
                {
                    armarLinea = "";
                    separador = "";
                    for (int i = 0; i < CamposParaEtiqueta.Items.Count; i++)
                    {
                        armarLinea += separador + dr[CamposParaEtiqueta.Items[i].ToString()].ToString();
                        separador = ";";
                    }
                    armarLinea += separador + vro.Cells["Cantidad"].FormattedValue.ToString();
                    sw.WriteLine(armarLinea);
                }
                dr.Dispose();
                // guardar linea
            }
            sw.Close();
            sw.Dispose();
        }
        private string NombreArchivo()
        {
            string file = "";
            saveFileDialog1.Filter = "Archivos OTTAP (*.tto)|*.tto|Todos los archivos (*.*)|*.*";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                return saveFileDialog1.FileName;
            }
            return "";
        }
    }
}

//Write a text file - Version-1using System;
//using System.IO;

//namespace readwriteapp
//{
//class Class1
//{
//[STAThread]
//static void Main(string[] args) 
//{
//try 
//{

////Pass the filepath and filename to the StreamWriter Constructor
//StreamWriter sw = new StreamWriter("C:\\Test.txt");

////Write a line of text
//sw.WriteLine("Hello World!!");

////Write a second line of text
//sw.WriteLine("From the StreamWriter class");

////Close the file
//sw.Close();
//}
//catch(Exception e)
//{
//Console.WriteLine("Exception: " + e.Message);
//}
//finally 
//{
//Console.WriteLine("Executing finally block.");
//}
//}
//}
//}
