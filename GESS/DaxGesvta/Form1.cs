using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DaxGesvta
{
    public partial class Form1 : Form
    {
        public Form1()
        { 
            InitializeComponent();
        }

        public string valorCampo = "";
        public string condicion = "";
        private void Aceptar_Click(object sender, EventArgs e)

        {
            valorCampo = ValorFiltro.Text;
            if (btnIgual.Checked == true) condicion = "=";
            if (btnDiferente .Checked == true) condicion = "<>";
            if (btnMayor.Checked == true) condicion = ">";
            if (btnMenor.Checked == true) condicion = "<";
            if (btnParecido.Checked == true) condicion = "PARECIDO A";
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ValorFiltro.Text = valorCampo;
            if (condicion == "=" ) btnIgual.Checked = true ;
            if (condicion == "<>") btnDiferente.Checked = true;
            if (condicion == ">") btnMayor.Checked = true;
            if (condicion == "<") btnMenor.Checked = true;
            if (condicion == "PARECIDO A") btnParecido.Checked = true;
        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            valorCampo = "";
            condicion = "";
        }

    }
}
