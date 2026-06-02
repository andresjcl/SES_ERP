using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.SqlClient;
using System.Windows.Forms;
using DattCom;

namespace adcDocumentos
{
    public partial class frmCambPlto : Form
    {
        string retOpciones = "";
        public frmCambPlto(string opciones)
        {
            InitializeComponent();
            retOpciones = opciones;

        }

        public string obtenerCambios()
        {
            cargarOpciones();
            ShowDialog();
            return retOpciones;
        }
        private void cargarOpciones()
        {
           string ssql = "select Abreviación ,Descripcion  from syscod where TipoReferencia = 'cambioplatos' and Abreviación <> '#'";
           using (SqlDataAdapter da = new SqlDataAdapter(ssql, datosEmpresa.strConxAdcom))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                string[] opcion = retOpciones.Split(Convert.ToChar(","));
                foreach (DataRow row in dt.Rows)
                {
                    string campo = row["Descripcion"].ToString();
                    ListViewItem item = new ListViewItem(campo);
                    item.Name = row["Abreviación"].ToString();
                    for (int i = 0; i < opcion.Count(); i++)
                    {
                        if (campo == opcion[i]) { item.Checked = true; break;}
                    }
                    listOpciones.Items.Add(item);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            retOpciones = "";
            foreach (ListViewItem item in listOpciones.Items)
            {
                if (item.Checked)
                {
                    retOpciones += "," + item.Text;
                    if (item.Name.Substring(0, 1) == "#") actualizaSyscod(item.Text);
                }
            }
            Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string cambio = inputDialogo.inputDialogo.ingresar("Cambios a platos","Nuevo cambio : ","");
            if (cambio.Length > 0)
            {
                ListViewItem item = new ListViewItem(cambio);
                item.Checked = true;
                item.Name = "#" + cambio;
                listOpciones.Items.Add(item);
            }
        }
        private void actualizaSyscod(string opcion)
        {
            Int32 n = 100;
            string ssql = "select max(abreviación) as codMax, isnull(max(Clave),0) as maxclave from syscod where TipoReferencia = 'cambioplatos' and Abreviación <> '#'";
            using (SqlConnection conn = new SqlConnection(datosEmpresa.strConxAdcom))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand(ssql, conn);
                SqlDataReader dr = comm.ExecuteReader();
                
                if (dr.Read())
                {
                    try
                    {
                        n = Convert.ToInt32(dr[0].ToString()) + 10;
                    }catch { n = 10; }
                }
                else
                {
                    n = 10;
                }
                if ( n == 10 ) n = Convert.ToInt32(dr[1].ToString());
                n++;
            }
                ssql = "select TipoReferencia,abreviación,Descripcion,Caracteristica1 from syscod where TipoReferencia = 'cambioplatos' and Abreviación = '" + n.ToString() + "'";
            using (SqlDataAdapter da = new SqlDataAdapter(ssql,datosEmpresa.strConxSyscod))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                DataRow row = dt.NewRow();
                row["abreviación"] = n.ToString();
                row["Descripcion"] = opcion;
                row["TipoReferencia"] = "CambioPlatos";
                dt.Rows.Add(row);
                da.Update(dt);
                dt.AcceptChanges();
                dt.Dispose();
                cb.Dispose();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listOpciones.SelectedItems.Clear();
        }

        private void frmCambPlto_Load(object sender, EventArgs e)
        {

        }
    }
}
