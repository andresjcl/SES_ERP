using DattCom;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DaxInvent
{
	internal partial class frmPlato : Form
	{
        string tit1 = "";
        internal frmPlato(string cod)
        {
            InitializeComponent();
            verificarCodigoExterno(cod);
        }
        private void verificarCodigoExterno(string codigoExterno)
        {
            if (codigoExterno != "")
            {
                txtCodigo.Text = codigoExterno;
                labArticulo.Text = leerArticulo(codigoExterno);
                LlenarMalla(codigoExterno);
            }
        }

        private void LlenarMalla(string codigoArt)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter();
            dt = new DataTable();
            string ssql = "SELECT PLA_Codigo, a.Descripcion ";
            ssql += " FROM AdcComponPlato AS c LEFT OUTER JOIN ";
            ssql += " syscod AS a ON c.PLA_Codigo = a.Abreviación ";
            ssql += " where pro_codigo = '" + codigoArt + "'";
            ssql += " and a.tiporeferencia= 'CambioPlatos'";
            ssql += " order by PLA_Codigo";
            dt = new DataTable();
            da = new SqlDataAdapter(ssql, datosEmpresa.strConxAdcom);
            da.Fill(dt);
            Malla.DataSource = dt;
            DisenarMalla();
            dt.Dispose();
            da.Dispose();
        }

        private void DisenarMalla()
        {
            Malla.Columns["PLA_Codigo"].HeaderText = "Código";
            Malla.Columns["Descripcion"].HeaderText = "Descripción";
        }

        //private string leerArticulo(string codigo)
        //{
        //    string ssql = "select Descripcion from syscod where tiporeferencia='CambioPlatos' and Abreviación<>'#' and Abreviación = '" + codigo + "'";
        //    SqlDataAdapter dad = new SqlDataAdapter(ssql, datosEmpresa.strConxAdcom);
        //    DataTable dtt = new DataTable();
        //    dad.Fill(dtt);
        //    if (dtt.Rows.Count > 0)
        //    {
        //        ssql = dtt.Rows[0][0].ToString();
        //    }
        //    else
        //    {
        //        MessageBox.Show("La Preferencia del plato digitado no existe", "Buscar plato");
        //        ssql = "";
        //    }
        //    return ssql;
        //}
        private string leerArticulo(string codigo)
        {
            string ssql = "Select art_nombre from adcart where art_codigo = '" + codigo + "'";
            SqlDataAdapter dad = new SqlDataAdapter(ssql, datosEmpresa.strConxAdcom);
            DataTable dtt = new DataTable();
            dad.Fill(dtt);
            if (dtt.Rows.Count > 0)
            {
                ssql = dtt.Rows[0][0].ToString();
            }
            else
            {
                MessageBox.Show("El artículo digitado no existe", "Buscar articulo");
                ssql = "";
            }
            return ssql;
        }

        private string leerPlatoNombre(string codigo)
        {
            string ssql = "select Descripcion from syscod where tiporeferencia='CambioPlatos' and Abreviación<>'#' and Abreviación = '" + codigo + "'";
            SqlDataAdapter dad = new SqlDataAdapter(ssql, datosEmpresa.strConxAdcom);
            DataTable dtt = new DataTable();
            dad.Fill(dtt);
            if (dtt.Rows.Count > 0)
            {
                ssql = dtt.Rows[0][0].ToString();
            }
            else
            {
                MessageBox.Show("El artículo digitado no existe", "Buscar articulo");
                ssql = "";
            }
            return ssql;
        }

        private void btnSalir_Click(object sender, EventArgs e)
		{
            this.Close();
		}

		private void btnGuardar_Click(object sender, EventArgs e)
		{
            string ssql = "select * FROM AdcComponPlato ";
            ssql += " where pro_codigo = '" + txtCodigo.Text + "'";
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(ssql, datosEmpresa.strConxAdcom);
            da.Fill(dt);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);

            //verificar si lineas de malla existen en data
            foreach (DataGridViewRow grRow in Malla.Rows)
            {
                if (grRow.Cells["pla_codigo"].Value != null && grRow.Cells["pla_codigo"].Value.ToString().Length > 0)
                {
                    string codCompnte = grRow.Cells["pla_codigo"].Value.ToString();
                    Boolean esIgual = false;
                    foreach (DataRow dtRow in dt.Rows)
                    {
                        if (codCompnte == dtRow["pla_codigo"].ToString())
                        {
                            dtRow["PRO_Codigo"] = grRow.Cells["PRO_Codigo"].Value;
                            dtRow["PLA_Codigo"] = grRow.Cells["PLA_Codigo"].Value;
                            dtRow["PLA_Detalle"] = grRow.Cells["PLA_Detalle"].Value;
                            esIgual = true;
                        }
                    }
                    if (!esIgual)
                    {
                        DataRow nRow = dt.NewRow();
                        nRow["PRO_Codigo"] = txtCodigo.Text;
                        nRow["PLA_Codigo"] = grRow.Cells["pla_codigo"].Value;
                        dt.Rows.Add(nRow);
                    }
                }
            }
            //    verificar si debe eliminarse una fila de la data
            Boolean seElimino = true;
            do
            {
                seElimino = false;
                try
                {
                    foreach (DataRow dtRow in dt.Rows)
                    {
                        if (!existeEnMalla(dtRow["pla_codigo"].ToString()))
                        {
                            dtRow.Delete();
                            seElimino = true;
                        }
                    }
                }
                catch { }
            } while (seElimino);

            da.Update(dt);
            dt.AcceptChanges();

            da.Dispose();
            dt.Dispose();
            cb.Dispose();


            Close();
            Dispose();
        }
        private Boolean existeEnMalla(string codigo)
        {
            bool existe = false;
            foreach (DataGridViewRow grRow in Malla.Rows)
            {
                if (grRow.Cells["pla_codigo"].Value != null && grRow.Cells["pla_codigo"].Value.ToString().Length > 0)
                {
                    if (codigo == grRow.Cells["pla_codigo"].Value.ToString()) { existe = true; break; }
                }
            }
            return existe;
        }

		private void Malla_KeyDown(object sender, KeyEventArgs e)
		{
            if (e.KeyCode == Keys.F2 && Malla.CurrentCell.ColumnIndex == 0)
            {
                buscarPreferenciaPlato();
            }
        }
        private void buscarPreferenciaPlato()
        {
            string codigo = buscadorPlato();
            Int32 indRow = Malla.CurrentCell.RowIndex;
            Malla.CurrentCell.Value = codigo;
            if (codigo.Length > 0)
            {
                Malla.Rows[indRow].Cells["Descripcion"].Value = leerPlatoNombre(codigo);                
            }
            
        }
        private string buscadorPlato()
        {
            frmBuscarPreferenciaPlato busplato = new frmBuscarPreferenciaPlato();
            string codart = busplato.IniciaBuscaPlato(Malla.CurrentCell.Value.ToString(), "");
            return codart;

        }

		private void txtCodigo_TextChanged(object sender, EventArgs e)
		{
            limpiar();
        }
        private void limpiar()
        {
            Malla.Columns.Clear();           
        }

		private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
		{
            if (e.KeyCode == Keys.F2)
            {
                buscarPlatoPrincipal();
            }
            if (e.KeyCode == Keys.Return & txtCodigo.Text.Length > 0)
            {
                limpiar();
                leerPlatoNombre(txtCodigo.Text);
            }
        }

        private void buscarPlatoPrincipal()
        {
            txtCodigo.Text = buscadorPlato();
            if (txtCodigo.Text.Length > 0) labArticulo.Text = leerArticulo(txtCodigo.Text);
        }

       
    }
}
