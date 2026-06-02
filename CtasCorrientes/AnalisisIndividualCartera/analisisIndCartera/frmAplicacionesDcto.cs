using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient ;

namespace CtasCorrientes
{
    public partial class frmAplicacionesDcto : Form
    {
        string DeDondeEs = "";
        string FechaHasta;
        //Boolean SwSalida = true;
        Int32 PosicionDoc = 0;
        string Docum = "";
        long Num = 0;
        string Sucursal="";
        double IdClaveDoc = 0;
        double TotalDoc=0;
        string strConxAdcom = "";
//        Boolean Act1 = false;

        public frmAplicacionesDcto(string strConxA, double IdClaveDocC, string Documento, long numero, double Adicional = 0, string fecha = "01/01/1900", string Dedonde = "", Int32 Posicion = 0, string DocSuc = "")
        {
            InitializeComponent();
                DeDondeEs = Dedonde;
                FechaHasta = fecha;
                //SwSalida = true;
                PosicionDoc = Posicion;
                Docum = Documento;
                Num = numero;
                Sucursal = DocSuc;
                IdClaveDoc = IdClaveDocC;
                TotalDoc = Adicional;
                strConxAdcom = strConxA;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            llenarmalla();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void llenarmalla()
        {
            //string StrComVen="";
            string StrFecha="";
            string cod;
            string Seleccion;
            //string  TablaActiva ;
            //long cont = 0;
            //'Boolean SalirSN = true;
            //if ( PosicionDoc == 3)  StrComVen = "Doc_Contabilidad";
            //if ( PosicionDoc == 4) StrComVen = "Doc_Banco";
            //if ( PosicionDoc == 5) StrComVen = "Doc_Inventario";
            //if ( PosicionDoc == 6) StrComVen = "Doc_Ventas";
            //if ( PosicionDoc == 7) StrComVen = "Doc_Compras";
            //if ( PosicionDoc == 8) StrComVen = "Doc_Activo";
            //SwSalida = false;
    
            try
            {
                DateTime f = Convert.ToDateTime(FechaHasta);
                StrFecha = " AND abb.apl_Fecha <= '" + FechaHasta + "' ";
            }
            catch{StrFecha="";}

            Seleccion = "APL_SUCAPLI = '" + Sucursal + "' AND  (APL_DOCAPLI = '" + Docum + "') AND idclavedocAPL = " + IdClaveDoc;

            cod = " SELECT   dd.idclavedoc,DD.DOC_SUCURSAL as SUC, ABB.opc_documento AS TIP, ABB.doc_numero AS NUMERO, ABB.Apl_fecha AS FechaAplica, ABB.Apl_valorapl as ValorAplica , DD.Doc_Bodega AS BOD, ";
            cod += " DD.Doc_NombreImp as NOMBRE, DD.Doc_codper, DD.doc_fecha";
            cod += " FROM  AdcDoc DD right JOIN Adcdocabonos2 ABB ON DD.idclavedoc = ABB.idclavedoc AND ";
            cod += " DD.Opc_documento = ABB.opc_documento AND ABB.Doc_sucursal = DD.Doc_sucursal ";
            cod += " WHERE  " + Seleccion + "  " + StrFecha + "   ";
            cod += " Order BY abb.Apl_Fecha, abb.Opc_Documento , dd.Doc_numero";
          
            SqlDataAdapter da = new SqlDataAdapter(cod,strConxAdcom);
            DataTable dt = new System.Data.DataTable();
            da.Fill(dt);
            if(dt.Rows.Count < 1)
            {
                //'SalirSN = false;
                MessageBox.Show ( "El Documento no tiene aplicaciones registradas al " + FechaHasta ,"Consulta aplicaciones");
                this.Close();
            }
            mallaDatos.DataSource=dt;
            diseñarMalla();
            totalizar();
        }
        private void totalizar()
        {
            string formato = "{0:0.00}";
            double totValor = 0;

            foreach (DataGridViewRow row in mallaDatos.Rows)
            {
                totValor += Convert.ToDouble(row.Cells["ValorAplica"].Value);
            }
            labValor.Text = string.Format(formato, totValor);        
        }

        private void diseñarMalla()
        {
            string formato = "#,#0.00;-#,#0.00;\"\";";

            mallaDatos.Columns["ValorAplica"].DefaultCellStyle.Format = formato;
            mallaDatos.Columns["ValorAplica"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            mallaDatos.Columns["BOD"].Visible = false;
            mallaDatos.Columns["DOC_CODPER"].Visible = false;
            mallaDatos.Columns["DOC_FECHA"].Visible = false;
            mallaDatos.Columns["IdClaveDoc"].Visible = false;
        }

    }
}
