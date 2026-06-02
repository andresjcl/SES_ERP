using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace inputDialogo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string inicio(string mensaje,string Defaultt)
        {
            label1.Text = mensaje;
            textBox1.Text = Defaultt;
            this.ShowDialog();
            return textBox1.Text;
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return) Salida();
        }
        private void Salida()
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Salida();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            Salida();
        }
    }
}
