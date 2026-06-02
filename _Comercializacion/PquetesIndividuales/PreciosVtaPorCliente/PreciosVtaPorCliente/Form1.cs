using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DaxComercia
{
    public partial class Form1 : Form
    {
        string strConxAdcom = "";
        string strConxDaxsys = "";
        string todos = "Todos";

        int accion = 0;
        Int32 cambios = 0;

        public Form1()
        {
            InitializeComponent();
            LlenarCombos();
            limpiar();
            cambios = 0;
        }
        private void LlenarCombos()
        {
            DaxCbos.DaxCombobx cmb = new DaxCbos.DaxCombobx();
            DaxLib.DaxLibBases dlib = new DaxLib.DaxLibBases();
            dlib.TipoBase = "10";
            strConxAdcom = dlib.StrAdcom();
            strConxDaxsys = dlib.StrDaxsys();
            cmb.DaxCombosCat("C", "I", strConxAdcom, ref cboCategoria);
            cboCategoria.SelectedValue = "0";

            cmb.DaxCombosCat("CL", "I", strConxAdcom, ref cboClase);
            cboClase.SelectedValue = "0";

            cmb.DaxCombosCat("G", "I", strConxAdcom, ref cboGrupo);
            cboGrupo.SelectedValue = "0";

            dlib = null;
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            buscaCliente(txtClienteCod.Text );
        }
        private void buscaCliente(string buscador)
        {
            MantenimientoDirectorio.BuscaClien directorio = new MantenimientoDirectorio.BuscaClien();
            string cliente = "C";
            string codigo = "";
            string nombre = "";
            string conalias = "N";
            string connuevo = "N";
            codigo = directorio.IniBuscaCliOPro(ref cliente, ref nombre, ref conalias, ref connuevo);
            txtClienteCod.Text  = codigo;
            txtClienteNombre.Text = nombre;
        }

        private void btnTipoCliente_Click(object sender, EventArgs e)
        {
            CBuscador(txtTipoClienteCod, txtTipocliente, "TipoCliente");
        }
        private void CBuscador( TextBox lcod , TextBox  lnom , string op)
        {
        string ElNombre = "";
        string ElCodigo = "";
        Syscod.ManSysnetClass Buscod = new Syscod.ManSysnetClass() ;
        
        Buscod.BuscarReferencia(ref op, ref ElCodigo, ref ElNombre);
        lcod.Text = ElCodigo;
        lnom.Text = ElNombre;
        }

        private void btnPAis_Click(object sender, EventArgs e)
        {
            if (txtClienteCod.Text == "" || txtClienteCod.Text == todos) CBuscador(txtPaisCod, txtPais, "Paises");
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {

            Buscar.frmBuscar  bus = new Buscar.frmBuscar();
            string lista  = "";
            lista = bus.Buscar(strConxAdcom , "select Lista, Descripción from  adcPrvtaLis where Lista <> '' ", "Lista", "Descripción", "Consulta", "LISTAS DE PRECIO:");
            if (lista != "" )
            {
                Cursor.Current = Cursors.WaitCursor;
                txtNumeroLst.Text = lista;
                cargarEncabezado(txtNumeroLst.Text );
                btnGuardar.Enabled = true ;
                btnCopiar.Enabled = true;
                Cursor.Current = Cursors.Default;
                cambios = 0;
                CargarMalla(Convert.ToInt64(lista));
            }
        }
        private void cargarEncabezado(string listaPvp)
        { 
            RetNombre.AdcNomb Nombres = new RetNombre.AdcNomb ();
            DaxComercia.AdcPrvtaLis lista = new DaxComercia.AdcPrvtaLis(strConxAdcom);
            lista = DaxComercia.AdcPrvtaLis.Buscar(" lista = " + listaPvp);
            txtDescripLst.Text = lista.Descripción;
            cboMoneda.SelectedValue = lista.Moneda;
            txtSQLPrecio.Text = lista.SQLPrecio;
            txtClienteCod.Text = lista.Cliente;

            if( txtClienteCod.Text != "" ) 
            {
                txtClienteNombre.Text = Nombres.RetornaNombreDirectorio  (txtClienteCod.Text ,strConxAdcom );
            }
            
            txtPaisCod.Text = lista.Pais;
            txtPais.Text = Nombres.RetornaNombreSyscod ("Paises",txtPaisCod.Text,strConxDaxsys);
            txtTipoClienteCod.Text = lista.TipoCliente;
            txtTipocliente.Text  = Nombres.RetornaNombreSyscod("TipoCliente", txtTipoClienteCod.Text, strConxDaxsys);
            chkIva.Checked = lista.IncluyeIva;

        }
        private void limpiar()
        {

            txtNumeroLst.Text = "";
            txtDescripLst.Text = "";
            txtClienteCod.Text  = "";
            txtClienteNombre.Text = "";
            txtPais.Text = "";
            txtPaisCod.Text = "";
            LimpiaMalla();
            cambios = 0;
            accion = 0;
            datosIniciales();
            botones(0);
        }
        private void LimpiaMalla()
        {
            malla.Columns.Clear();
        }

    private void btnNuevo_Click(object sender, EventArgs e)
    {
        this.UseWaitCursor = true;
        this.Cursor = Cursors.WaitCursor;
        limpiar();
        CargarNumLista();
        CargarMalla(Convert.ToInt64(txtNumeroLst.Text));
        //bloquearDesbloquear(False)
        btnGuardar.Enabled = true;
        txtNumeroLst.Focus();
        cambios = 0;
        btnCopiar.Enabled = true;
        this.UseWaitCursor = false;
        this.Cursor = Cursors.Default;
        botones(accion);
    }
    private void CargarMalla(Int64 numeroLista)
    {
        if (cambios > 0) 
        {
            if (MessageBox.Show("Confirma cambiar la lista de artículos ?, los cambios se perderán", "Precios de venta por clientes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No) return;
        }

        string ssql = " SELECT AdcArt.Art_codigo AS CODIGO, AdcArt.Art_nombre AS DESCRIPCIÓN, r1.PrecioProducto ";
        ssql += " FROM AdcArt LEFT OUTER JOIN ";
        ssql += " ( select CodigoProducto, PrecioProducto from AdcPrvta where lista =  " + txtNumeroLst.Text + ") r1 ";
        ssql += " ON AdcArt.Art_codigo = r1.CodigoProducto WHERE ART_CODIGO > '' ";
        
        if (cboCategoria.Text != "Todo") ssql += " and art_categor='" + cboCategoria.SelectedValue.ToString() + "'";
        if (cboClase.Text != "Todo") ssql += " and art_clase='" + cboClase.SelectedValue.ToString() + "'";
        if (cboGrupo.Text != "Todo") ssql += " and art_grupo='" + cboGrupo.SelectedValue.ToString() + "'";

        SqlDataAdapter da = new SqlDataAdapter(ssql,strConxAdcom);
        DataTable dt = new DataTable();
        da.Fill(dt);
        malla.DataSource = dt;
        da.Dispose();

        malla.Columns["CODIGO"].ReadOnly = true; 
        malla.Columns["DESCRIPCIÓN"].ReadOnly = true;
        malla.Columns["PrecioProducto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        malla.Columns["PrecioProducto"].DefaultCellStyle.Format = "0.00";
        accion = 2;
        botones(accion);        
    }
    private void CargarNumLista()
    {
        Int64 numeroLista = 0;
        SqlConnection conecta = new SqlConnection(strConxAdcom );
        conecta.Open ();
        string ssql = "select max(lista) from adcprvtalis";
        SqlCommand cmd = new SqlCommand(ssql, conecta );
        SqlDataReader  dat;
        dat = cmd.ExecuteReader();
        if( dat.Read()) if ((dat[0] != null ))  { numeroLista  =Convert.ToInt64( "0" + dat[0].ToString()) + 1;} else {numeroLista  = 101;}
        if (numeroLista < 100) numeroLista += 100;
        txtNumeroLst.Text = Convert.ToString(numeroLista);
        conecta.Close();
    }
    private void datosIniciales()
    {
        txtClienteCod.Text = todos;
        txtClienteNombre.Text = todos;
        txtPais.Text = todos;
        txtPaisCod.Text = todos;
        txtTipocliente.Text = todos;
        txtTipoClienteCod.Text = todos;
    }
    private void guardarListaDePrecios()
    {
        malla.EndEdit();
        DaxComercia.AdcPrvtaLis pvta = new DaxComercia.AdcPrvtaLis(strConxAdcom);
        pvta.Lista = txtNumeroLst.Text;
        pvta.Descripción = txtDescripLst.Text;
        pvta.FechaModifica = DateTime.Now;
        pvta.IncluyeIva = chkIva.Checked;
        pvta.Cliente = txtClienteCod.Text;
        pvta.TipoCliente = txtTipoClienteCod.Text;
        pvta.Pais = txtPaisCod.Text;
        string ssql = "select * from ";
        ssql = pvta.Actualizar();
        if (ssql.ToUpper() == "ERROR") { MessageBox.Show("excepción no se pudo grabar la lista", "Guardar lista de precios", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
        GuardarMalla();
        limpiar();
    }
    private void GuardarMalla()
    {
        string ssql = "select * from adcprvta where lista = " + txtNumeroLst.Text.ToString();
        SqlDataAdapter da = new SqlDataAdapter(ssql, strConxAdcom);
        DataTable dt = new DataTable();
        da.Fill(dt);
        SqlCommandBuilder cb = new SqlCommandBuilder(da);
        foreach (DataRow rr in dt.Rows)
        {
            rr.Delete();
        }

        foreach (DataGridViewRow row in malla.Rows)
        {
            double elPrecio = 0;
            DataRow dtrow = dt.NewRow();
            try
            {
                elPrecio = Convert.ToDouble(row.Cells["PrecioProducto"].Value);
            }
            catch { elPrecio = 0; }
            if (elPrecio > 0)
            {
                dtrow["Lista"] = txtNumeroLst.Text.ToString();
                dtrow["TipoProducto"] = "";
                dtrow["GrupoPrecios"] = "";
                dtrow["CodigoProducto"] = row.Cells["Codigo"].Value.ToString() ;
                dtrow["PrecioProducto"] = elPrecio;
                dtrow["Temporada"] = 0;
                dt.Rows.Add(dtrow);
            }
        }
        da.Update(dt);
        da.Dispose();
    }
    private void btnGuardar_Click(object sender, EventArgs e)
    {
        guardarListaDePrecios();
    }


    private void txtClienteCod_TextChanged(object sender, EventArgs e)
    {
        cambios++;
    }

    private void malla_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
        cambios++;
    }

    private void cboCategoria_SelectedIndexChanged(object sender, EventArgs e)
    {        
        if ((Convert.ToInt64("0" + txtNumeroLst.Text) == 0)) return ;
        CargarMalla(Convert.ToInt64(txtNumeroLst.Text));
    }

    private void btnCancelar_Click(object sender, EventArgs e)
    {
        if (cambios > 0)
        {
            if (MessageBox.Show("Confirma, cancelar las operaciones ?, los cambios se perderán", "Precios de venta por clientes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No) return;
        }

        limpiar();
        
    }

    private void btnEliminar_Click(object sender, EventArgs e)
    {
        {
            if (MessageBox.Show("Confirma eliminar la actual lista de precios ?", "Precios de venta por clientes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No) return;
        }
        string ssql = "delete from adcprvtalis where lista = " + txtNumeroLst.Text;
        SqlConnection conn = new SqlConnection(strConxAdcom);
        conn.Open();
        SqlCommand comm = new SqlCommand(ssql ,conn);
        comm.ExecuteNonQuery();
        comm = null;
        conn.Close();
        conn.Dispose();
    }
    private void botones(int operacion)
    {

        btnEliminar.Enabled = (operacion == 2);
        btnGuardar.Enabled = (operacion > 0);
        btnNuevo.Enabled = (operacion == 0);
        btnAbrir.Enabled = (operacion == 0);
        btnAgrupar.Enabled = (operacion > 0);
        btnCancelar.Enabled = (operacion > 0);
    }

    private void btnSalir_Click(object sender, EventArgs e)
    {
        if (cambios > 0)
        {
            if (MessageBox.Show("Confirma salir del proceso ?, los cambios se perderán", "Precios de venta por clientes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No) return;
        }
        this.Close();
    }

        //...........
    }
}
    

