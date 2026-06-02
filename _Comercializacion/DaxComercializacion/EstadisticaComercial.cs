using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using DattCom;
using System.Windows.Forms;

namespace DaxComercia
{
    public partial class EstadisticaComercial : Form
    {
        string strSelect;
        string strGroup;
        string strOrder;

        public EstadisticaComercial()
        {
            InitializeComponent();
            DatosIniciales();
        }
        private void DatosIniciales()
        {
            DaxCombobx.CargCmbBox  cmbx = new DaxCombobx.CargCmbBox();
            cmbx.DaxCombosCat("C", "I", datosEmpresa.strConxAdcom, ref cmbCategoria);
            cmbx.DaxCombosCat("L", "I", datosEmpresa.strConxAdcom, ref cmbClase);
            cmbx.DaxCombosCat("G", "I", datosEmpresa.strConxAdcom, ref cmbGrupo);
            cmbx.DaxCombosSuc(datosEmpresa.Emp_codigo.ToString(), true, datosEmpresa.strConIniSis, ref cmbSucursal);

            cmbTipo.SelectedIndex = 0;
            cmbRubbros.SelectedIndex = 0;
            cmbPeriodo.SelectedIndex = 0;
            cmbObjetos.SelectedIndex = 0;
            cmbAnalisisSecundario.SelectedIndex = 0;
            cmbAnalisiPrincipal.SelectedIndex = 0;
        }
        private void btnProcesar_Click(object sender, EventArgs e)
        {
            WaitMensaje.WMensaje.verMensaje ("EJECUTANDO CONSULTA");
            arreglarTitulo();

            SqlConnection conn = new SqlConnection(datosEmpresa.strConxAdcom);
            conn.Open();
            SqlCommand cmd = new SqlCommand("DaxEstdComer", conn);
            cmd.CommandType =  CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@sucursal", cmbSucursal.SelectedValue);
            cmd.Parameters.AddWithValue("@tipo", cmbTipo.Text.Substring(0,1));
            cmd.Parameters.AddWithValue("@fechaIni", dtFechaIni.Text);
            cmd.Parameters.AddWithValue("@fechafin", dtFechaFin.Text );
            cmd.Parameters.AddWithValue("@objetos", cmbObjetos.Text.Substring(0,1));
            cmd.Parameters.AddWithValue("@Categoria", cmbCategoria.SelectedValue);
            cmd.Parameters.AddWithValue("@Clase", cmbClase.SelectedValue);
            cmd.Parameters.AddWithValue("@Grupo", cmbGrupo.SelectedValue);
            cmd.Parameters.AddWithValue("@sentenciaSql", FormarSentenciaSql());
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            malla.DataSource = dt;
            diseñarMalla(cmbPeriodo.Text);
            WaitMensaje.WMensaje.cierraMensaje();
        }
        private void arreglarTitulo()
        {
            string Titulo = " Resumen " + cmbPeriodo.Text + " de " + cmbTipo.Text + " por " + cmbRubbros.Text  + " de " + cmbObjetos.Text ;
            Titulo += " del " + dtFechaIni.Text + " al " + dtFechaFin;                      
        }

        private string FormarSentenciaSql()
        {
            strSelect = " Select ";
            strGroup = " Group by  ";
            strOrder = " order by ";

            armarSqlAnalisis(cmbAnalisiPrincipal.Text);
            if (chkAanalisisSecundario.Checked && cmbAnalisiPrincipal.Text != cmbAnalisisSecundario.Text ) armarSqlAnalisis(cmbAnalisisSecundario.Text);
            string rubro = "Cantidad";
            if (cmbRubbros.Text == "Valores") rubro = "Valor";
            armarPeriodo(rubro, cmbPeriodo.Text);

            string ssql = strSelect + " from ##tmp1 " + strGroup.Substring(0, strGroup.Length - 1) + " " + strOrder.Substring(0, strOrder.Length - 1);
            return ssql;
        }
        private void armarSqlAnalisis(string Condicion)
        {
            switch (Condicion)
            {
                case "Artículo":
                    strSelect += " codArticulo, min(NombreArtículo) as NombreArtículo ,";
                    strGroup += " codArticulo,";
                    strOrder += " NombreArtículo,";
                    break;
                case "Cliente/Proveedor":
                    strSelect += " codClienteProveedor, min(NombreCliente) as NombreCliente,";
                    strGroup += " codClienteProveedor,";
                    strOrder += " NombreCliente,";
                    break;
                case "Categoría Artículo":
                    strSelect += " Categoría,";
                    strGroup += " Categoría,";
                    strOrder += " Categoría,";
                    break;
                case "Clase Artículo":
                    strSelect += " Clase,";
                    strGroup += " Clase,";
                    strOrder += " Clase,";
                    break;
                case "Grupo Artículo":
                    strSelect += " Grupo,";
                    strGroup += " Grupo,";
                    strOrder += " Grupo,";
                    break;
                case "Sucursal":
                    strSelect += " SUC,";
                    strGroup += " SUC,";
                    strOrder += " SUC,";
                    break;

                case "Vendedor":
                    strSelect += " codVendedor, min(NombreVendedor) as NombreVendedor,";
                    strGroup += " codVendedor,";
                    strOrder += " NombreVendedor,";
                    break;
                default:
                    break;
            }
            strSelect = strSelect.Trim();
            strGroup = strGroup.Trim();
            strOrder = strOrder.Trim();
        }
        private void armarPeriodo(string rubro, string periodo)
        {
            if (periodo == "Mensual")
            {
                strSelect += "SUM(CASE WHEN mes = 1 THEN(" + rubro + ") ELSE 0 END) AS ENE,";
                strSelect += "SUM (CASE WHEN mes = 2 THEN(" + rubro + ") ELSE 0 END) AS FEB,";
                strSelect += "SUM (CASE WHEN mes = 3 THEN(" + rubro + ") ELSE 0 END) AS MAR,";
                strSelect += "SUM (CASE WHEN mes = 4 THEN(" + rubro + ") ELSE 0 END) AS ABR,";
                strSelect += "SUM (CASE WHEN mes = 5 THEN(" + rubro + ") ELSE 0 END) AS MAY,";
                strSelect += "SUM (CASE WHEN mes = 6 THEN(" + rubro + ") ELSE 0 END) AS JUN,";
                strSelect += "SUM (CASE WHEN mes = 7 THEN(" + rubro + ") ELSE 0 END) AS JUL,";
                strSelect += "SUM (CASE WHEN mes = 8 THEN(" + rubro + ") ELSE 0 END) AS AGS,";
                strSelect += "SUM (CASE WHEN mes = 9 THEN(" + rubro + ") ELSE 0 END) AS SEP,";
                strSelect += "SUM (CASE WHEN mes = 10 THEN(" + rubro + ") ELSE 0 END) AS OCT,";
                strSelect += "SUM (CASE WHEN mes = 11 THEN(" + rubro + ") ELSE 0 END) AS NOV,";
                strSelect += "SUM (CASE WHEN mes = 12 THEN(" + rubro + ") ELSE 0 END) AS DIC,";
                strSelect += "SUM (" + rubro + ") AS total";
            }
            else if (periodo == "Dias de la semana")
            {
                strSelect += "SUM(CASE WHEN DiaSemana = 'Lunes' THEN(" + rubro + ") ELSE 0 END) AS Lunes,";
                strSelect += "SUM (CASE WHEN DiaSemana = 'Martes' THEN(" + rubro + ") ELSE 0 END) AS Martes,";
                strSelect += "SUM (CASE WHEN DiaSemana = 'Miércoles' THEN(" + rubro + ") ELSE 0 END) AS Miércoles,";
                strSelect += "SUM (CASE WHEN DiaSemana = 'Jueves' THEN(" + rubro + ") ELSE 0 END) AS Jueves,";
                strSelect += "SUM (CASE WHEN DiaSemana = 'Viernes' THEN(" + rubro + ") ELSE 0 END) AS Viernes,";
                strSelect += "SUM (CASE WHEN DiaSemana = 'Sábado' THEN(" + rubro + ") ELSE 0 END) AS Sábado,";
                strSelect += "SUM (CASE WHEN DiaSemana = 'Domingo' THEN(" + rubro + ") ELSE 0 END) AS Domingo,";
                strSelect += "SUM (" + rubro + ") AS total";
            }
            else if (periodo == "Trimestral")
            {
                strSelect += "SUM(CASE WHEN mes < 4 THEN(" + rubro + ") ELSE 0 END) AS Trimst_1,";
                strSelect += "SUM (CASE WHEN mes > 3 and mes < 7 THEN(" + rubro + ") ELSE 0 END) AS Trimst_2,";
                strSelect += "SUM (CASE WHEN mes < 7 THEN(" + rubro + ") ELSE 0 END) AS Semest_1,";
                strSelect += "SUM (CASE WHEN mes > 6 and mes < 10 THEN(" + rubro + ") ELSE 0 END) AS Trimst_3,";
                strSelect += "SUM (CASE WHEN mes > 9 THEN(" + rubro + ") ELSE 0 END) AS Trimst_4,";
                strSelect += "SUM (CASE WHEN mes > 6 THEN(" + rubro + ") ELSE 0 END) AS Semest_2,";
                strSelect += "SUM (" + rubro + ") AS total";
            }



        }
        private void diseñarMalla(string periodo)
        {
            string formato = "#0.00;-0.00;#";
            if (periodo == "Mensual")
            {
                malla.Columns["ENE"].DefaultCellStyle.Alignment= DataGridViewContentAlignment.MiddleRight;
                malla.Columns["ENE"].DefaultCellStyle.Format = formato ;
                malla.Columns["FEB"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                malla.Columns["FEB"].DefaultCellStyle.Format = formato;
                malla.Columns["MAR"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                malla.Columns["MAR"].DefaultCellStyle.Format = formato;
                malla.Columns["ABR"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                malla.Columns["ABR"].DefaultCellStyle.Format = formato;
                malla.Columns["MAY"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                malla.Columns["MAY"].DefaultCellStyle.Format = formato;
                malla.Columns["JUN"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                malla.Columns["JUN"].DefaultCellStyle.Format = formato;
                malla.Columns["JUL"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                malla.Columns["JUL"].DefaultCellStyle.Format = formato;
                malla.Columns["AGS"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                malla.Columns["AGS"].DefaultCellStyle.Format = formato;
                malla.Columns["SEP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                malla.Columns["SEP"].DefaultCellStyle.Format = formato;
                malla.Columns["OCT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                malla.Columns["OCT"].DefaultCellStyle.Format = formato;
                malla.Columns["NOV"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                malla.Columns["NOV"].DefaultCellStyle.Format = formato;
                malla.Columns["DIC"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                malla.Columns["DIC"].DefaultCellStyle.Format = formato;
            }
            else if (periodo == "Dias de la semana")
            {
                malla.Columns["Lunes"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                malla.Columns["Lunes"].DefaultCellStyle.Format = formato;
                malla.Columns["Martes"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                malla.Columns["Martes"].DefaultCellStyle.Format = formato;
                malla.Columns["Miércoles"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                malla.Columns["Miércoles"].DefaultCellStyle.Format = formato;
                malla.Columns["Jueves"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                malla.Columns["Jueves"].DefaultCellStyle.Format = formato;
                malla.Columns["Viernes"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                malla.Columns["Viernes"].DefaultCellStyle.Format = formato;
                malla.Columns["Sábado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                malla.Columns["Sábado"].DefaultCellStyle.Format = formato;
                malla.Columns["Domingo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                malla.Columns["Domingo"].DefaultCellStyle.Format = formato;
            }
            else if (periodo == "Trimestral")
            {
                malla.Columns["Trimst_1"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                malla.Columns["Trimst_1"].DefaultCellStyle.Format = formato;
                malla.Columns["Trimst_2"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                malla.Columns["Trimst_2"].DefaultCellStyle.Format = formato;
                malla.Columns["Semest_1"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                malla.Columns["Semest_1"].DefaultCellStyle.Format = formato;
                malla.Columns["Trimst_3"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                malla.Columns["Trimst_3"].DefaultCellStyle.Format = formato;
                malla.Columns["Trimst_4"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                malla.Columns["Trimst_4"].DefaultCellStyle.Format = formato;
                malla.Columns["Semest_2"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                malla.Columns["Semest_2"].DefaultCellStyle.Format = formato;
            }
            malla.Columns["total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            malla.Columns["total"].DefaultCellStyle.Format = formato;


        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();

        }

        private void btnOpciones_Click(object sender, EventArgs e)
        {
            panel1.Visible = !panel1.Visible;
        }

    }
}
