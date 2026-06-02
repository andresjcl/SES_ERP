using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using DattCom;
namespace Syscod
{
    public partial class frmBuscarTipoRef : Form
    {
        private string descripcion = "";
        private string codigo = "";
        private string @ref = "";

        public frmBuscarTipoRef()
        {
            InitializeComponent();
        }

        private void CargarMalla(string tipoRef)
        {
            
            SqlConnection conectar = new SqlConnection(datosEmpresa.strConxSyscod);
            conectar.Open();
            string ssql = "select * FROM syscod where TipoReferencia ='" + tipoRef + "' and Abreviación = '#'";
            SqlCommand conn = new SqlCommand(ssql, conectar);
            SqlDataReader datR;
            string Coma = ",";
            datR = conn.ExecuteReader();
            string Consulta = "";
            while (datR.Read())
            {
                if (datR["Caracteristica1"].ToString() != "")
                    Consulta = Coma + "Caracteristica1 as [" + datR["Caracteristica1"].ToString()+ "]";
                if (datR["Caracteristica2"].ToString()!= "")
                    Consulta += Coma + "Caracteristica2 as [" + datR["Caracteristica2"].ToString()+ "]";
                if (datR["Caracteristica3"].ToString()!= "")
                    Consulta += Coma + "Caracteristica3 as [" + datR["Caracteristica3"].ToString()+ "]";
                if (datR["Caracteristica4"].ToString()!= "")
                    Consulta += Coma + "Caracteristica4 as [" + datR["Caracteristica4"].ToString()+ "]";
                if (datR["Caracteristica5"].ToString()!= "")
                    Consulta += Coma + "Caracteristica5 as [" + datR["Caracteristica5"].ToString()+ "]";
            }
            datR.Close();
            conn.Dispose();
            conectar.Close();

            //DataTable datS = new DataTable();
            //SqlDataAdapter datos = new SqlDataAdapter(ssql, datosEmpresa.strConxSyscod);
            //datos.Fill(datS);

            ssql = "select Abreviación,Descripcion" + Consulta + "  from syscod where TipoReferencia ='" + tipoRef + "' and Abreviación <>'#'";

            if (TextNombre.Text != "")
            {
                if (EnInicio.Checked)
                    ssql = ssql + " and (DESCRIPCION LIKE '" + TextNombre.Text + "%') ";
                else
                    ssql = ssql + " and (DESCRIPCION LIKE '%" + TextNombre.Text + "%') ";
            }

            if (TextCodigo.Text != "")
            {
                if (EnInicio.Checked)
                    ssql = ssql + " and (abreviación LIKE '" + TextCodigo.Text + "%') ";
                else
                    ssql = ssql + " and (abreviación LIKE '%" + TextCodigo.Text + "%') ";
            }
            // MsgBox(ssql)

            DataTable dt = new DataTable();
            SqlDataAdapter datos = new SqlDataAdapter(ssql, datosEmpresa.strConxSyscod);
            datos.Fill(dt);
            gridTipo.DataSource = dt;
            gridTipo.ClearSelection();
        }

        private void gridTipo_DoubleClick(object sender, System.EventArgs e)
        {
            Int32 fila;
            {
                if (gridTipo.Rows.Count  > 0)
                {
                    fila = Convert.ToInt32(gridTipo.SelectedCells[0].RowIndex.ToString());
                    codigo = gridTipo.Rows[fila].Cells["Abreviación"].Value.ToString();
                    descripcion = gridTipo.Rows[fila].Cells["Descripcion"].Value.ToString();
                }
                else
                {
                    codigo = "";
                    descripcion = "";
                }
            }
            this.Close();
        }

        public string BuscarTipoRef(string tipoRef, ref string Codigoref, ref string Descripcionref)
        {
            @ref = tipoRef;
            CargarMalla(tipoRef);
            this.Text = ("Buscando " + tipoRef).ToUpper() ;
            this.ShowDialog();
            Codigoref = codigo;
            Descripcionref = descripcion;
            CargarMalla(tipoRef);
            return descripcion;
        }


        private void frmBuscarTipoRef_Load(object sender, EventArgs e)
        {
            // ref = "Provincias"
            CargarMalla(@ref);
            this.Text = "Buscando " + @ref;
        }

        private void BtnAceptar_Click(System.Object sender, System.EventArgs e)
        {
            Int32  fila;
            {
                if (gridTipo.Rows.Count > 0)
                {
                    fila = System.Convert.ToInt32(gridTipo.SelectedCells[0].RowIndex.ToString());
                    codigo = gridTipo.Rows[fila].Cells[0].Value.ToString();
                    descripcion = gridTipo.Rows[fila].Cells[1].Value.ToString();
                }
                else
                {
                    codigo = "";
                    descripcion = "";
                }
            }
            this.Close();
        }

        private void ToolStripButton2_Click(System.Object sender, System.EventArgs e)
        {
            frmSyscod tipo = new frmSyscod();
            tipo.Referencias(@ref);
            CargarMalla(@ref);
        }

        private void ToolStripButton1_Click(System.Object sender, System.EventArgs e)
        {
            codigo = "";
            descripcion = "";
            this.Close();
            this.Dispose();
        }

        private void TextNombre_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                CargarMalla(@ref);
        }

        private void TextNombre_TextChanged(System.Object sender, System.EventArgs e)
        {
            if (EnInicio.Checked)
                CargarMalla(@ref);
        }

        private void TextCodigo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                CargarMalla(@ref);
        }

        private void TextCodigo_TextChanged(System.Object sender, System.EventArgs e)
        {
            if (EnInicio.Checked)
                CargarMalla(@ref);
        }
    }
}

