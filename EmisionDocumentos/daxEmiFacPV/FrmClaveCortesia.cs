using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace adcDocumentos
{
    public partial class FrmClaveCortesia : Form
    {
        Boolean resp = false;
        string Usuario = "";
        string Clave = "";
        int veces = 0;
        public FrmClaveCortesia(string mensaje)
        {
            InitializeComponent();
            Text = "Ingrese clave para autorizar " + mensaje;
            leerClave();
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtClave.Text != Clave)
                {
                    MessageBox.Show("Clave errónea");
                    veces++;
                    if (veces < 3) { return; } else { resp = false; Close(); }
                }
                resp = true;
            } catch { resp = false; };
            Close();
        }
        public Boolean IngresarClaveCortesia(string IdUsuario)
        {
            Usuario = IdUsuario;
            leerClave();
            if (Clave.Length == 0) return true;
            ShowDialog();
            return resp;
        }
        private void leerClave()
        {
            string ssql = "select isnull(Par_ClvDsc,'') Par_ClvDsc from emp_par where Emp_Codigo = " + DattCom.datosEmpresa.codEmpresa.ToString();
            SqlDataReader dr = DattCom.SqlDatos.leerBaseIniSis(ssql);
            if (dr.Read()) Clave = dr[0].ToString();
            else Clave = "";
            dr.Close();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            resp = false;
            Close();
        }
    }
}
