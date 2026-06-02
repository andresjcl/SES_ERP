using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO ;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text  == string.Empty) return;
            string cambio = comboBox1.Text;
            //File.Delete("DAX.ini");
            File.Copy(cambio, "DXA.XML", true);
        }

        private static void cargarFiles(ComboBox cmb)
        {
        try
        {
            DirectoryInfo directory = new DirectoryInfo(@".");
            FileInfo[] files = directory.GetFiles("DXA_*");
            DirectoryInfo[] directories = directory.GetDirectories();
            for (int i = 0; i < files.Length; i++)
            {
                cmb.Items.Add(((FileInfo)files[i]).Name);
            }
        }
            catch {}
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargarFiles(comboBox1);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return) 
            {
                button1_Click(sender, e);
                return;
            }
            if (e.KeyData == Keys.Escape)
            {
                this.Close ();
            }

        }

    }
}
