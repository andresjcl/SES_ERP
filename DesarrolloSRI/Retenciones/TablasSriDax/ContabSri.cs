using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SysEmpDatt;
namespace IvaRett
{
    public partial class ContabSri : Form
    {
        public ContabSri(DataGridView malla, string laTabla)
        {
            InitializeComponent();
            mallaSri = malla;
            tabla = laTabla;
        }

        private string tabla;
        private DataGridView mallaSri;
        private DataTable dt = new DataTable();
        private SqlDataAdapter da = new SqlDataAdapter();
        private string ssql = "";

        private void frmContabilidad_Load(System.Object sender, System.EventArgs e)
        {
            this.Text = "Registrar identificatvos contables para " + tabla;
            tabla = tabla.ToUpper();
            Arreglarmalla();
        }

        private void Arreglarmalla()
        {
            this.Cursor = Cursors.WaitCursor;
            ssql = "Select codigo,porcentaje,idcontable1,idcontable2 from adcsrictb where tabla = '" + tabla + "'";
            da = new SqlDataAdapter(ssql, datosEmpresa.strConxAdcom);
            da.Fill(dt);
            malla.DataSource = dt;
            int reg = dt.Rows.Count;
            bool existe;
            string porcentaje;
            DateTime hoy = DateTime.Now;
            DateTime fechaDato;
            for (int i = 0; i <= mallaSri.Rows.Count - 2; i++)
            {
                existe = false;
                DataGridViewRow rowSri = mallaSri.Rows[i];
                try
                {
                    fechaDato = Convert.ToDateTime(rowSri.Cells["fechaFin"].Value);
                }
                catch
                {
                    fechaDato = new DateTime(2999, 12, 31);
                }
                if (fechaDato.Year == 1900)
                    fechaDato = new DateTime(2999, 12, 31);
                if (((chkValidos.Checked & fechaDato >= hoy) | chkValidos.Checked == false))
                {
                    if (reg > 0)
                    {
                        if (tabla.Substring(0, 12).ToUpper() == "RETENCIONIVA")
                            porcentaje = rowSri.Cells["Descripción"].Value.ToString();
                        else
                            porcentaje = rowSri.Cells["porcentaje"].Value.ToString();
                        for (int j = 0; j <= reg - 1; j++)
                        {
                            if (malla.Rows[j].Cells["codigo"].Value.ToString() == rowSri.Cells["código"].Value.ToString())
                            {
                                if (malla.Rows[j].Cells["porcentaje"].Value.ToString() == porcentaje)
                                    // malla.Rows[j].Cells["IdContable1"].Value = rowSri.Cells["IdContable1"].Value.ToString()
                                    // malla.Rows[j].Cells["IdContable2"].Value = rowSri.Cells["IdContable2"].Value.ToString()
                                    existe = true;
                            }
                        }
                    }
                    if (existe == false)
                        insertarMallaData(rowSri, dt, "", "");
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void insertarMallaData(DataGridViewRow row, DataTable dt, string idctb1, string idctb2)
        {
            DataGridViewRow drow;
            double valor;
            string porc;
            if (row.Cells["código"].Value != null)
            {
                if (row.Cells["código"].Value.ToString() != "")
                {
                    dt.Rows.Add();
                    drow = malla.Rows[dt.Rows.Count - 1];
                    drow.Cells["codigo"].Value = row.Cells["código"].Value;
                    if (tabla.Substring(0, 12).ToUpper() == "RETENCIONIVA")
                        porc = row.Cells["Descripción"].Value.ToString();
                    else
                        porc = row.Cells["porcentaje"].Value.ToString();
                    try
                    {
                        valor = Convert.ToDouble(porc);
                    }
                    catch
                    {
                        valor = 0;
                    }
                    drow.Cells["porcentaje"].Value = valor;
                    drow.Cells["IdContable1"].Value = idctb1;
                    drow.Cells["IdContable2"].Value = idctb2;
                }
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            malla.EndEdit();

            SqlDatos.ejecutarComandoAdcom("delete from Adcsrictb where tabla = '" + tabla + "'");
            foreach (DataGridViewRow rr in malla.Rows)
            {
                try
                {
                    if (rr.Cells["codigo"].Value.ToString().Length > 0 && (rr.Cells["IdContable1"].Value.ToString().Length > 0 || rr.Cells["IdContable2"].Value.ToString().Length > 0))
                    {
                        ssql = "INSERT INTO [Adcsrictb] ([tabla], [codigo],[porcentaje],[IdContable1],[IdContable2]) VALUES (";
                        ssql += "'" + tabla + "'";
                        ssql += ",'" + rr.Cells["codigo"].Value.ToString() + "'";
                        ssql += "," + rr.Cells["porcentaje"].Value.ToString();
                        ssql += ",'" + rr.Cells["IdContable1"].Value.ToString() + "'";
                        ssql += ",'" + rr.Cells["IdContable2"].Value.ToString() + "'";
                        ssql += ")";
                        SqlDatos.ejecutarComandoAdcom(ssql);
                    }
                }
                catch (Exception Err)
                {
                    MessageBox.Show(Err.Message);
                }
            }
        }

        private void bntCancelar_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (mallaSri != null) Arreglarmalla();
        }
    }
}
