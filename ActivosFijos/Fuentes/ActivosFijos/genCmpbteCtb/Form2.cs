using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace genCmpbteCtbAcf
{    
    public partial class Form2 : Form
    {
        string strConxAdcom = "";
        string strConxDaxsys = "";
        DataTable dataMalla = new DataTable();
        string sucursal = "";
        string sucursalAct = "";
        string usuario = "";
        decimal totalDoc = 0;
        string empresa = "";
        PrySysp13.OpcDoc opDoc = new PrySysp13.OpcDoc();
        decimal idClaveDoc = 0;
        Int32 numeroDocumento = 0;
        string nomPeriodo = "";
        string sucAnt = "";    

        public Form2(string suc,string user,string strconx,string strdaxs,decimal totDoc,string emp )
        {
            InitializeComponent();
            strConxAdcom = strconx;
            strConxDaxsys = strdaxs;
            //malla = mallaCtb;
            sucursal = suc;
            sucursalAct = suc;
            usuario = user;
            totalDoc = totDoc;
            //txtDetalle.Text = detalleDoc;
            empresa = emp;
            llenarCombos();
            //llenarSucursales();
            txtFechaDocumento.Text = DateTime.Now.ToShortDateString() ;
            //nomPeriodo = nombrePeriodo;
        }

        private void llenarCombos()
        {
            DaxCbos.DaxCombobx combo = new DaxCbos.DaxCombobx();
            this.cmbDocumento.SelectedValueChanged -= new System.EventHandler(this.cmbDocumento_SelectedValueChanged);
            combo.DaxCombosDoc("DIA", "DIA", false, strConxAdcom , ref cmbDocumento);
            txtNumeroDiario.Text = nuevoNumeroDoc().ToString();
            this.cmbDocumento.SelectedValueChanged += new System.EventHandler(this.cmbDocumento_SelectedValueChanged);
            Int32 año = DateTime.Now.Year - 10;
            for (Int32 i=año;i<año+21;i++)
            {
                cmbAño.Items.Add(i);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            cargarMalla();
            numeroDocumento = Convert.ToInt32(txtNumeroDiario.Text);                        
            grabaEncabezado();
            grabarDetalleAdcDia();
            MessageBox.Show("Proceso terminado correctamente");
                //}
                //catch (Exception ee) { MessageBox.Show ("Excepción creando diario del rol \n " + ee.Message); }
            this.Cursor = Cursors.Default;
        }
        private Boolean verificaExiste(Int32 numdoc)
        {
            idClaveDoc  = 0;

            string sel = " doc_sucursal = '" + sucursalAct + "' and ";
            string mens = "El documento ya existe, desea reemplazarlo ? ";
            sel += " opc_documento = '" + cmbDocumento.SelectedValue.ToString() + "' and doc_numero = " + numdoc.ToString();

            ClassDoc.AdcDoc Basdoc = new ClassDoc.AdcDoc(strConxAdcom);
            Basdoc = ClassDoc.AdcDoc.Buscar(sel);
            
            if (Basdoc == null) { Basdoc = new ClassDoc.AdcDoc(strConxAdcom); }
            if (Basdoc.IdClaveDoc > 0)
            {
                if (MessageBox.Show(mens, "Generar diario contable Activos Fijos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No) return true;
                idClaveDoc = Basdoc.IdClaveDoc;
            }
            return false;
        }
        private void eliminaExiste(Int32 numdoc)
        { 
            string sel = " doc_sucursal = '" + sucursalAct + "' and ";
            sel += " opc_documento = '" + cmbDocumento.SelectedValue.ToString() + "' and doc_numero = " + numdoc.ToString();
            sel = "DELETE from adcdoc where " + sel;
            ClassDoc.AdcDoc Basdoc = new ClassDoc.AdcDoc(strConxAdcom);
            ClassDoc.AdcDoc.Tabla(sel);
            //Basdoc.DBorrar(sel);
            Basdoc = null;
        }

        private void grabaEncabezado()
        {
            eliminaExiste(numeroDocumento);
            ClassDoc.AdcDoc Basdoc = new ClassDoc.AdcDoc(strConxAdcom);
            Basdoc.Doc_sucursal=sucursalAct ;
            Basdoc.Opc_documento=opDoc.Documento ;   
            Basdoc.Doc_numero= numeroDocumento;
            Basdoc.Doc_docnombre= cmbDocumento.Text;
            Basdoc.Doc_TipoDoc=opDoc.TipoDoc;    
            Basdoc.Doc_fecha=txtFechaDocumento.Value ;
            Basdoc.Doc_codusu=usuario;
            Basdoc.Doc_valor=totalDoc;
            Basdoc.Doc_detalle=txtDetalle.Text + " " + sucAnt;
            Basdoc.Doc_Estado= 1;
            Basdoc.Doc_Oculto= 1; 
            Basdoc.Doc_Contabilidad= 1;
            Basdoc.Doc_Banco=0;
            Basdoc.Doc_Inventario=0;
            Basdoc.Doc_Ventas=0;
            Basdoc.Doc_Compras=0;   
            Basdoc.Doc_Activo=0; 
            Basdoc.Doc_FechaModifica= DateTime.Now;
            Basdoc.Dia_Status= "S";
            Basdoc.Doc_FecGraba=DateTime.Now;
            Basdoc.Crear();
            idClaveDoc =  Basdoc.IdClaveDoc;            
        }

        public void grabarDetalleAdcDia()
        {
            string sel = "SELECT * FROM AdcDia WHERE doc_sucursal = '" + sucursalAct + "' and opc_documento = '" + cmbDocumento.SelectedValue.ToString() + "' and doc_numero = " + txtNumeroDiario.Text ;
            using (var adapter = new SqlDataAdapter(sel, strConxAdcom))
            using (new SqlCommandBuilder(adapter))
            {
                DataTable table = new DataTable();
                adapter.Fill(table);
                DataRow dr;

                double nr = table.Rows.Count;
                double mr = dataMalla.Rows.Count;

                
                foreach (DataRow drow in table.Rows)
                {
                    drow.Delete();
                }

                ClassDoc.AdcDia Basdia = new ClassDoc.AdcDia();

                Basdia.Doc_sucursal = sucursalAct;
                Basdia.Opc_documento = cmbDocumento.SelectedValue.ToString();
                Basdia.Doc_numero = numeroDocumento ;
                Basdia.IdClaveDoc = idClaveDoc;
                Basdia.Dia_fecha = txtFechaDocumento.Value; 
                Basdia.Dia_Status = "";

                Int32 i = 1;
                foreach (DataRow  rrow in dataMalla.Rows)
                {
                    if (rrow["Cuenta"] != null && rrow["Cuenta"].ToString() != string.Empty)
                    {
                        dr = table.NewRow();
                        Basdia.Cta_codigo = rrow["Cuenta"].ToString();
                        Basdia.Dia_ctanombre = rrow["NombreCuenta"].ToString();
                        Basdia.Dia_linea = i;
                        Basdia.Dia_detalle = txtDetalle.Text;
                        Basdia.Dia_Costo = ""; //rrow["CentroCosto"].ToString();                        
                        Basdia.Dia_empleado = "";//rrow["Empleado"].ToString();

                        if (Convert.ToDecimal(rrow["Debe"]) != 0)
                        {
                            Basdia.Dia_valor = Convert.ToDecimal(rrow["Debe"]);
                            Basdia.Dia_signo = 1;
                        }
                        else
                        {
                            Basdia.Dia_valor = Convert.ToDecimal(rrow["Haber"]);
                            Basdia.Dia_signo = -1;
                        }

                        //Basdia.dia_centroDistribucion = rrow.Cells["CDistribución"].Value.ToString();
                        //Basdia.dia_centroproduccion = rrow.Cells["CProducción"].Value.ToString();
                        //Basdia.Dia_Cliente = rrow.Cells["Cliente"].Value.ToString();
                        //Basdia.Dia_departamento = rrow.Cells["Departamento"].Value.ToString();
                        //Basdia.dia_directorio = rrow.Cells["Directorio"].Value.ToString();
                        //Basdia.Dia_PorCosto = Convert.ToDecimal(rrow.Cells["PorCosto"].Value.ToString());
                        //Basdia.Dia_Producto = rrow.Cells["Producto"].Value.ToString();
                        //Basdia.Dia_Proveedor = rrow.Cells["Proveedor"].Value.ToString();
                        //Basdia.Dia_Proyecto = rrow.Cells["Proyecto"].Value.ToString();
                        //Basdia.Dia_Relacionado = rrow.Cells["Relacionado"].Value.ToString();
                        //Basdia.Dia_Rubros = rrow.Cells["Rubros"].Value.ToString();
                        //Basdia.Dia_zona = rrow.Cells["Zona"].Value.ToString();
                        //Basdia.Nifs = Convert.ToBoolean(rrow.Cells["Nifs"].Value.ToString());

                        Basdia.moverAdcDiaDatarow (Basdia, ref dr);
                        table.Rows.Add(dr);
                        i++;
                    }
                }
                adapter.Update(table);
            }
        }

        private double nuevoNumeroDoc()
        {
            string lugar=sucursalAct;
            string doc =cmbDocumento.SelectedValue.ToString();
            string ban ="";
            opDoc.Cargar(ref doc, ref lugar);
            double num = opDoc.NumeroMayor(ref sucursalAct, ref doc, ref ban) ;
            return num;
        }

        private void cmbDocumento_SelectedValueChanged(object sender, EventArgs e)
        {
            txtNumeroDiario.Text = nuevoNumeroDoc().ToString();
        }
        private void cargarMalla()
        {
            string sSql = "acfCtb " + cmbAño.Text + "," + (cmbDeMes.SelectedIndex + 1).ToString() + "," + (cmbAMes.SelectedIndex + 1).ToString() +",'T'";
            SqlConnection conn = new SqlConnection(strConxAdcom);
            conn.Open();
            SqlCommand comm = new SqlCommand(sSql, conn);
            comm.ExecuteNonQuery();
            sSql = "alter table tmpctb add indice int identity(1,1); ";
            sSql += "alter table tmpctb add CONSTRAINT [PK_tmpCtb] PRIMARY KEY CLUSTERED ([indice] ASC)";
            comm = new SqlCommand(sSql, conn);
            comm.ExecuteNonQuery();

            chequearComodines();
            //sSql = "nomRevCos " + fechaIniPeriodo.Year.ToString() + "," + fechaIniPeriodo.Month.ToString();
           // comm = new SqlCommand(sSql, conn);
           // comm.ExecuteNonQuery();

            comm.Dispose();
            conn.Close();
            conn.Dispose();


            sSql = "acfCtb2 ''";
            ////if (cmbDetallado.SelectedIndex == 1) sSql += ",'S'";
            SqlDataAdapter misqlDa = new SqlDataAdapter(sSql, strConxAdcom);
            //DataTable dato = new DataTable();
            dataMalla = new DataTable();
            misqlDa.Fill(dataMalla);

            //mallaDatos.DataSource = dato;
            //arreglarMalla(mallaDatos);
            //dato.Dispose();
            //estadoProceso = 0;
            //if (mallaDatos.Rows.Count != 0) estadoProceso = 1;
            //ponerSucursales();
            //ponerBotones();
        }
        private void chequearComodines()
        {
            string sSql = "select * from tmpctb ";
            sSql += " where cuenta like '%d%' ";
            sSql += " or cuenta like '%&%' ";
            sSql += " or cuenta like '%P%' ";
            sSql += " or cuenta like '%S%'  ";
            sSql += " or cuenta like '%C%' ";
            sSql += " or cuenta like '%B%' ";
            sSql += " or cuenta like '%F%' ";
            sSql += " or cuenta like '%T%'";

            SqlDataAdapter misqlDa = new SqlDataAdapter(sSql, strConxAdcom);
            DataTable dato = new DataTable();
            misqlDa.Fill(dato);
            daxConta.reglCtb verificador = new daxConta.reglCtb();
            verificador.strConxAdcom = strConxAdcom;
            verificador.strConxSyscod = strConxDaxsys;
            verificador.empCodigo = empresa; // defemp.EmpresaAct.codigo.ToString();
            foreach (DataRow row in dato.Rows)
            {
                row["cuenta"] = verificador.VerificarComodines(row["cuenta"].ToString(), "", "", "", row["codigoActivo"].ToString(), "", "","", "", "");
            }
            SqlCommandBuilder cb = new SqlCommandBuilder(misqlDa);
            misqlDa.Update(dato);
            dato.AcceptChanges();
        }

    }
}
