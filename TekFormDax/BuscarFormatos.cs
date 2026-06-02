using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TekFormDax
{
    public partial class BuscarFormatos : Form
    {
        bool SoloEspeciales = false;
        string DeDonde = "";
        string Seleccion = "";
        string strConxAdcom = "";
        


        public BuscarFormatos(string strCondax)
        {
            InitializeComponent();
            strConxAdcom = strCondax;
        }
        public string BuscarFormato(string busca, bool Especiales = false, string dedond = "")
        {
            DeDonde=dedond;
            SoloEspeciales = Especiales;
            llenarMalla("");
            txtnombre.Text = busca;
            this.ShowDialog();
            return Seleccion;
        }
        private void llenarMalla(string buscador)
        {
            string Categorias = "";
            string ssql = " SELECT l0 AS CODIGO, ISNULL(Ln, '') AS DESCRIPCION ";
            if (SoloEspeciales) Categorias = " AND ISNULL(S2,'') = 'E' ";
            ssql += " From sysforms WHERE l0 LIKE '%" + buscador.Trim() + "%' and s1 = 'A' " + Categorias + " ORDER BY l0 ";
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(ssql, strConxAdcom);
            da.Fill(dt);
            malla.DataSource = dt;
        }

        private void btncancelarbusca_Click(object sender, EventArgs e)
        {
            Seleccion = "";
            Close();
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            Seleccion = malla.CurrentCell.Value.ToString();
            Close();
        }
    }
}
